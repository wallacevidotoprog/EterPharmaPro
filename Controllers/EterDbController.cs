using DocumentFormat.OpenXml.EMMA;
using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.Controllers
{
	public class EterDbController
	{
		private readonly IEterDb eterDb;

		public EterDbController(IEterDb eterDb)
		{
			this.eterDb = eterDb;
		}

		public async Task<(bool exist, EnderecoClienteModel end)> ExistAdressCliente(EnderecoClienteModel enderecoCliente)
		{
			List<EnderecoClienteModel> tempA = await eterDb.DbEndereco.GetEndereco(
				new QueryWhereModel().SetWhere(nameof(enderecoCliente.CLIENTE_ID), enderecoCliente.CLIENTE_ID)
				);
			for (int i = 0; i < tempA.Count; i++)
			{
				if (tempA[i].ENDERECO.ToUpper().Trim().Replace(" ", null) == enderecoCliente.ENDERECO.ToUpper().Trim().Replace(" ", null))
				{
					return (exist: true, end: tempA[i]);
				}
			}
			return (exist: false, end: null);
		}

		public async Task<ClienteModel> ExistCliente(ClienteModel dadosCliente, bool exist = false)
		{
			if (exist)
			{
				List<ClienteModel> aex = await eterDb.DbCliente.GetCliente(new QueryWhereModel().SetWhere(nameof(dadosCliente.ID), dadosCliente.ID));
				return (aex.Count > 0) ? aex[0] : null;
			}
			List<ClienteModel> t1 = dadosCliente.CPF != string.Empty ? await eterDb.DbCliente.GetCliente(new QueryWhereModel().SetWhere(nameof(dadosCliente.CPF), dadosCliente.CPF)) : new List<ClienteModel>();
			List<ClienteModel> t2 = dadosCliente.RG != string.Empty ? await eterDb.DbCliente.GetCliente(new QueryWhereModel().SetWhere(nameof(dadosCliente.RG), dadosCliente.RG)) : new List<ClienteModel>();
			return (t1.Count > 0) ? t1[0] : ((t2.Count > 0) ? t2[0] : null);
		}

		public async Task<(long? idC, long? idE)> RegisterCliente(ClienteModel dadosCliente)
		{
			long? idc = null;
			long? ide = null;
			try
			{
				EnderecoClienteModel enderecoCliente = (EnderecoClienteModel)dadosCliente.ENDERECO;

				using (var connection = new SQLiteConnection(eterDb.DatabaseConnection))
				{
					await connection.OpenAsync().ConfigureAwait(false);
					using (var transaction = connection.BeginTransaction())
					{
						try
						{
							ClienteModel tempCliente = await ExistCliente(dadosCliente);

							if (tempCliente != null)
							{

								enderecoCliente.CLIENTE_ID = idc = dadosCliente.ID = tempCliente.ID;
								await eterDb.DbCliente.UpdateCliente(dadosCliente, connection, transaction);

								var (exist, tempEnderecos) = await ExistAdressCliente(enderecoCliente);

								if (!exist)
								{
									ide = await eterDb.DbEndereco.CreateEndereco(enderecoCliente, connection, transaction);
								}
								else
								{
									enderecoCliente.ID = tempEnderecos.ID;
									enderecoCliente.CLIENTE_ID = tempCliente.ID;

									ide = enderecoCliente.ID;
									await eterDb.DbEndereco.UpdateEndereco(enderecoCliente, connection, transaction);
								}
							}
							else
							{
								idc = await eterDb.DbCliente.CreateCliente(dadosCliente, connection, transaction);
								enderecoCliente.CLIENTE_ID = idc;
								ide = await eterDb.DbEndereco.CreateEndereco(enderecoCliente, connection, transaction);
							}							

							transaction.Commit();
						}
						catch (Exception ex)
						{
							transaction.Rollback();
							ex.ErrorGet();
						}
					}
				}

				return (idc, ide);
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
				return (idc, ide);
			}
			return (idc, ide);
		}



	}
}
