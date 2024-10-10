using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
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

		public async Task<List<ClienteModel>> GetCliente(string query = null, TypeDoc typeDoc = TypeDoc.NONE)
		{
			List<ClienteModel> dadosCliente;
			switch (typeDoc)
			{
				case TypeDoc.CPF:
					dadosCliente = await eterDb.DbCliente.GetCliente(new QueryWhereModel().SetWhere("CPF", query));
					break;
				case TypeDoc.RG:
					dadosCliente = await eterDb.DbCliente.GetCliente(new QueryWhereModel().SetWhere("RG", query));
					break;
				default:
					dadosCliente = await eterDb.DbCliente.GetCliente(new QueryWhereModel());
					break;
			}


			for (int i = 0; i < dadosCliente.Count; i++)
			{
				dadosCliente[i].ENDERECO = await eterDb.DbEndereco.GetEndereco(new QueryWhereModel().SetWhere("CLIENTE_ID", dadosCliente[i].ID));
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

				(long? IDC, long? IDE) = await eterDb.EterDbController.RegisterCliente((ClienteModel)model.DADOSCLIENTE);

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
								await eterDb.DbManipuladosMedicamentos.DeleteMedicamento(model.ID.ToString(), connection, transaction);
								await eterDb.DbManipulados.UpdateManipulacao(model, connection, transaction);

								foreach (var medicamento in (List<string>)model.MEDICAMENTOS)
								{
									await eterDb.DbManipuladosMedicamentos.CreateMedicamento(medicamento, model.ID.ToString(), connection, transaction);
								}
							}
							else
							{
								long? tempCM = await eterDb.DbManipulados.CreateManipulacao(model, connection, transaction);
								await eterDb.DbManipuladosMedicamentos.DeleteMedicamento(tempCM.ToString(), connection, transaction);
								foreach (var medicamento in (List<string>)model.MEDICAMENTOS)
								{
									await eterDb.DbManipuladosMedicamentos.CreateMedicamento(medicamento, tempCM.ToString(), connection, transaction);
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

				List<ManipulacaoDbModel> tempM = await eterDb.DbManipulados.GetManipulacao(new QueryWhereModel().SetWhere("ATEN_LOJA", idUser));


				for (int i = 0; i < tempM.Count; i++)
				{
					ManipulacaoModel temp = new ManipulacaoModel().ConvertDb(tempM[i]);
					DadosClienteManipulacao dadosClienteManipulacao = (DadosClienteManipulacao)temp.DADOSCLIENTE;

					temp.DADOSATENDIMENTO.ATEN_LOJA_NAME = (await eterDb.DbUser.GetUser(new QueryWhereModel().SetWhere("ID", temp.DADOSATENDIMENTO.ATEN_LOJA))).FirstOrDefault().NOME;

					temp.DADOSCLIENTE = (await eterDb.DbCliente.GetCliente(new QueryWhereModel().SetWhere("ID", tempM[i].CLIENTE_ID))).FirstOrDefault().NOME;
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

				ManipulacaoDbModel tempM = (await eterDb.DbManipulados.GetManipulacao(new QueryWhereModel().SetWhere("ID", id))).FirstOrDefault();

				ManipulacaoModel temp = new ManipulacaoModel().ConvertDb(tempM);
				DadosClienteManipulacao dadosClienteManipulacao = (DadosClienteManipulacao)temp.DADOSCLIENTE;

				temp.DADOSCLIENTE = (await eterDb.DbCliente.GetCliente(new QueryWhereModel().SetWhere("ID", tempM.CLIENTE_ID))).FirstOrDefault();

				((ClienteModel)temp.DADOSCLIENTE).ENDERECO = (await eterDb.DbEndereco.GetEndereco(new QueryWhereModel().SetWhere("ID", tempM.ENDERECO_ID))).FirstOrDefault();

				temp.MEDICAMENTOS = await eterDb.DbManipuladosMedicamentos.GetMedicamento(new QueryWhereModel().SetWhere("MANIPULADOS_ID", tempM.ID));


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
						await eterDb.DbManipulados.DeleteManipulacao(temp.ToString(), connection, transaction);

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
