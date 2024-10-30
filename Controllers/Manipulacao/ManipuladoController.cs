using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Services;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Controllers.Manipulacao
{
	public class ManipuladoController
	{
		private readonly IEterDb eterDb;

		private readonly ManipuladoService manipuladoService;

		public ManipuladoController(IEterDb eterDb)
		{
			this.eterDb = eterDb;
			manipuladoService = new ManipuladoService(this.eterDb);
		}

		public async Task<List<ClienteDbModel>> GetCliente(string query = null, TypeDoc typeDoc = TypeDoc.NONE)
		{
			List<ClienteDbModel> dadosCliente;
			switch (typeDoc)
			{
				case TypeDoc.CPF:
					dadosCliente = await eterDb.ActionDb.GETFIELDS<ClienteDbModel>(new QueryWhereModel().SetWhere("CPF", query));
					break;
				case TypeDoc.RG:
					dadosCliente = await eterDb.ActionDb.GETFIELDS<ClienteDbModel>(new QueryWhereModel().SetWhere("RG", query));
					break;
				default:
					dadosCliente = await eterDb.ActionDb.GETFIELDS<ClienteDbModel>(new QueryWhereModel());
					break;
			}


			for (int i = 0; i < dadosCliente.Count; i++)
			{
				dadosCliente[i].ENDERECO = await eterDb.ActionDb.GETFIELDS<EnderecoClienteDbModel>(new QueryWhereModel().SetWhere("CLIENTE_ID", dadosCliente[i].ID));
			}
			return dadosCliente;
		}

		public async Task<bool> PrintDocManipulado(ManipulacaoModel model, EnumManipulado enumManipulado, bool edit = false)
		{
			try
			{
				switch (enumManipulado)
				{
					case EnumManipulado.P_80:
						manipuladoService.PrintDocManipulado80mm(model);
						break;
					case EnumManipulado.A4:
						manipuladoService.PrintDocManipuladoA4(model);
						break;
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}

			try
			{

				(long? IDC, long? IDE) = await eterDb.EterDbController.RegisterCliente((ClienteDbModel)model.DADOSCLIENTE);

				model.DADOSCLIENTE = new DadosClienteManipulacao { ID_CLIENTE = IDC, ID_ENDERECO = IDE };

				using (var connection = new SQLiteConnection(eterDb.DatabaseConnection))
				{
					await connection.OpenAsync().ConfigureAwait(false);
					using (var transaction = connection.BeginTransaction())
					{
						try
						{


							if (edit)
							{
								await eterDb.ActionDb.DELETE<MedicamentosManipuladosDbModal>(new QueryDeleteModel().SetWhere("ID", model.ID), connection, transaction);
								await eterDb.ActionDb.UPDATE(model, connection, transaction);

								((List<MedicamentosManipuladosDbModal>)model.MEDICAMENTOS).ForEach(m => m.MANIPULADOS_ID = model.ID);

								foreach (var medicamento in (List<MedicamentosManipuladosDbModal>)model.MEDICAMENTOS)
								{
									await eterDb.ActionDb.INSERT(medicamento, connection, transaction);
								}
							}
							else
							{
								long? tempCM = await eterDb.ActionDb.INSERT(model, connection, transaction);

								((List<MedicamentosManipuladosDbModal>)model.MEDICAMENTOS).ForEach(m => m.MANIPULADOS_ID = tempCM);

								foreach (var medicamento in (List<MedicamentosManipuladosDbModal>)model.MEDICAMENTOS)
								{
									await eterDb.ActionDb.INSERT(medicamento, connection, transaction);
								}
							}

							transaction.Commit();
							return true;
						}
						catch (Exception ex)
						{
							transaction.Rollback();
							ex.ErrorGet();
							return false;
						}
					}
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
				return false;
			}

		}

		public async Task<List<ManipulacaoModel>> GetManipulacaoFromUser(object idUser)
		{

			List<ManipulacaoModel> manipulacaoModels = new List<ManipulacaoModel>();
			try
			{

				List<ManipulacaoDbModel> tempM = await eterDb.ActionDb.GETFIELDS<ManipulacaoDbModel>(new QueryWhereModel().SetWhere("ATEN_LOJA", idUser));


				for (int i = 0; i < tempM.Count; i++)
				{
					ManipulacaoModel temp = new ManipulacaoModel().ConvertDb(tempM[i]);
					DadosClienteManipulacao dadosClienteManipulacao = (DadosClienteManipulacao)temp.DADOSCLIENTE;

					temp.DADOSATENDIMENTO.ATEN_LOJA_NAME = (await eterDb.ActionDb.GETFIELDS<UserModel>(new QueryWhereModel().SetWhere("ID", temp.DADOSATENDIMENTO.ATEN_LOJA))).FirstOrDefault().NOME;

					temp.DADOSCLIENTE = (await eterDb.ActionDb.GETFIELDS<UserModel>(new QueryWhereModel().SetWhere("ID", tempM[i].CLIENTE_ID))).FirstOrDefault().NOME;
					manipulacaoModels.Add(temp);
				}



			}
			catch (Exception ex)
			{
				ex.ErrorGet();

			}
			return manipulacaoModels;


		}
		public async Task<ManipulacaoModel> GetManipulacao(object id)
		{

			try
			{

				ManipulacaoDbModel tempM = (await eterDb.ActionDb.GETFIELDS<ManipulacaoDbModel>(new QueryWhereModel().SetWhere("ID", id))).FirstOrDefault();

				ManipulacaoModel temp = new ManipulacaoModel().ConvertDb(tempM);
				DadosClienteManipulacao dadosClienteManipulacao = (DadosClienteManipulacao)temp.DADOSCLIENTE;

				temp.DADOSCLIENTE = (await eterDb.ActionDb.GETFIELDS<ClienteDbModel>(new QueryWhereModel().SetWhere("ID", tempM.CLIENTE_ID))).FirstOrDefault();

				((ClienteDbModel)temp.DADOSCLIENTE).ENDERECO = (await eterDb.ActionDb.GETFIELDS<EnderecoClienteDbModel>(new QueryWhereModel().SetWhere("ID", tempM.ENDERECO_ID))).FirstOrDefault();

				temp.MEDICAMENTOS = await eterDb.ActionDb.GETFIELDS<MedicamentosManipuladosDbModal>(new QueryWhereModel().SetWhere("MANIPULADOS_ID", tempM.ID));


				return temp;
			}
			catch (Exception ex)
			{
				ex.ErrorGet();

			}
			return null;


		}

		public async Task<bool> DeleteManipulacao(int temp)
		{
			using (var connection = new SQLiteConnection(eterDb.DatabaseConnection))
			{
				await connection.OpenAsync().ConfigureAwait(false);
				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						await eterDb.ActionDb.DELETE<ManipulacaoDbModel>(new QueryDeleteModel().SetWhere("ID",temp), connection, transaction);

						transaction.Commit();
						return true;
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						ex.ErrorGet();
						return false;
					}
				}
			}
		}
	}
}
