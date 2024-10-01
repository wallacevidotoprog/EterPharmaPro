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
		private readonly IEterDb _eterDb;

		private ManipuladoService manipuladoService;

		public ManipuladoController(IEterDb eterDb)
		{
			_eterDb = eterDb;
			manipuladoService = new ManipuladoService(_eterDb);
		}

		public async Task<List<ClienteModel>> GetCliente(string query = null, TypeDoc typeDoc = TypeDoc.NONE)
		{
			List<ClienteModel> dadosCliente;
			switch (typeDoc)
			{
				case TypeDoc.CPF:
					dadosCliente = await _eterDb.DbCliente.GetCliente(new QueryWhereModel().SetWhere("CPF",query));
					break;				
				case TypeDoc.RG:
					dadosCliente = await _eterDb.DbCliente.GetCliente(new QueryWhereModel().SetWhere("RG", query));
					break;
				default:
					dadosCliente = await _eterDb.DbCliente.GetCliente(new QueryWhereModel());
					break;
			}


			for (int i = 0; i < dadosCliente.Count; i++)
			{
				dadosCliente[i].ENDERECO = await _eterDb.DbEndereco.GetEndereco( new QueryWhereModel ().SetWhere("CLIENTE_ID", dadosCliente[i].ID));
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
				ClienteModel dadosCliente = (ClienteModel)model.DADOSCLIENTE;
				EnderecoClienteModel enderecoCliente = (EnderecoClienteModel)dadosCliente.ENDERECO;

				model.DADOSCLIENTE = new DadosClienteManipulacao();

				using (var connection = new SQLiteConnection(_eterDb.DatabaseConnection))
				{
					await connection.OpenAsync().ConfigureAwait(false);
					using (var transaction = connection.BeginTransaction())
					{
						try
						{
							ClienteModel tempCliente = await _eterDb.EterDbController.ExistCliente(dadosCliente, edit);

							if (tempCliente != null)
							{
								((DadosClienteManipulacao)model.DADOSCLIENTE).ID_CLIENTE = tempCliente.ID;
								dadosCliente.ID = tempCliente.ID;
								await _eterDb.DbCliente.UpdateCliente(dadosCliente, connection, transaction);

								var (exist, tempEnderecos) = await _eterDb.EterDbController.ExistAdressCliente(enderecoCliente);

								if (!exist)
								{
									enderecoCliente.CLIENTE_ID = tempCliente.ID;
									((DadosClienteManipulacao)model.DADOSCLIENTE).ID_ENDERECO = await _eterDb.DbEndereco.CreateEndereco(enderecoCliente, connection, transaction);
								}
								else
								{
									enderecoCliente.OBSERVACAO += " - " + tempEnderecos.OBSERVACAO.Replace(enderecoCliente.OBSERVACAO,string.Empty);
									enderecoCliente.ID = tempEnderecos.ID;
									enderecoCliente.CLIENTE_ID = tempCliente.ID;

									((DadosClienteManipulacao)model.DADOSCLIENTE).ID_ENDERECO = enderecoCliente.ID;
									await _eterDb.DbEndereco.UpdateEndereco(enderecoCliente, connection, transaction);
								}
							}
							else
							{
								((DadosClienteManipulacao)model.DADOSCLIENTE).ID_CLIENTE = await _eterDb.DbCliente.CreateCliente(dadosCliente, connection, transaction);
								enderecoCliente.CLIENTE_ID = ((DadosClienteManipulacao)model.DADOSCLIENTE).ID_CLIENTE;
								((DadosClienteManipulacao)model.DADOSCLIENTE).ID_ENDERECO = await _eterDb.DbEndereco.CreateEndereco(enderecoCliente, connection, transaction);
							}

							if (edit)
							{
								await _eterDb.DbManipuladosMedicamentos.DeleteMedicamento(model.ID.ToString(), connection, transaction);
								await _eterDb.DbManipulados.UpdateManipulacao(model, connection, transaction);

								foreach (var medicamento in (List<string>)model.MEDICAMENTO)
								{
									await _eterDb.DbManipuladosMedicamentos.CreateMedicamento(medicamento, model.ID.ToString(), connection, transaction);
								}
							}
							else
							{
								long? tempCM = await _eterDb.DbManipulados.CreateManipulacao(model, connection, transaction);

								foreach (var medicamento in (List<string>)model.MEDICAMENTO)
								{
									await _eterDb.DbManipuladosMedicamentos.CreateMedicamento(medicamento, tempCM.ToString(), connection, transaction);
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
				return false;
			}

		}
		
		

		//public async Task<object> GetCliente(string id)
		//{
		//	List<DadosCliente> dadosCliente = await _eterDb.DbCliente.GetCliente(id);
		//	for (int i = 0; i < dadosCliente.Count; i++)
		//	{
		//		DadosCliente dadosCliente2 = dadosCliente[i];
		//		dadosCliente2.ENDERECO = await _eterDb.DbEndereco.GetEndereco(dadosCliente[i].ID.ToString());
		//	}
		//	return dadosCliente;
		//}



		//public async Task<bool> DeleteManipulacao(string id)
		//{
		//	return await _eterDb.DbManipulados.DeleteManipulacao(id);
		//}

		//public async Task<List<ManipulacaoModel>> GetAllManip()
		//{
		//	List<ManipulacaoModel> manipulacaoModels = await _eterDb.DbManipulados.GetManipulacao();
		//	for (int i = 0; i < manipulacaoModels.Count; i++)
		//	{
		//		DadosClienteManipulacao dadosCliente = (DadosClienteManipulacao)manipulacaoModels[i].DADOSCLIENTE;
		//		DadosCliente dt = _eterDb.DbCliente.GetCliente(dadosCliente.ID_CLIENTE.ToString()).Result[0];
		//		dt.ENDERECO = _eterDb.DbEndereco.GetEndereco(dadosCliente.ID_ENDERECO.ToString(), id: true).Result;
		//		manipulacaoModels[i].DADOSCLIENTE = dt;
		//		ManipulacaoModel manipulacaoModel = manipulacaoModels[i];
		//		manipulacaoModel.MEDICAMENTO = await _eterDb.DbManipuladosMedicamentos.GetMedicamento(manipulacaoModels[i].ID.ToString());
		//	}
		//	return manipulacaoModels;
		//}
	}
}
