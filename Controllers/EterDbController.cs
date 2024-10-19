using DocumentFormat.OpenXml.EMMA;
using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace EterPharmaPro.Controllers
{
	public class EterDbController
	{
		private readonly IEterDb eterDb;

		public UserModel UserModelAcess { get; private set; }

		public EterDbController(IEterDb eterDb)
		{
			this.eterDb = eterDb;
		}

		public async Task<(bool exist, EnderecoClienteModel end)> ExistAdressCliente(EnderecoClienteModel enderecoCliente)
		{
			List<EnderecoClienteModel> tempA = await eterDb.ActionDb.GETFIELDS<EnderecoClienteModel>(
				new QueryWhereModel().SetWhere("CLIENTE_ID", enderecoCliente.CLIENTE_ID)
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
			try
			{
				if (exist)
				{
					return (await eterDb.ActionDb.GETFIELDS<ClienteModel>(new QueryWhereModel().SetWhere("ID", dadosCliente.ID))).FirstOrDefault();
				}

				ClienteModel t1 = !string.IsNullOrEmpty(dadosCliente.CPF) ? (await eterDb.ActionDb.GETFIELDS<ClienteModel>(new QueryWhereModel().SetWhere("CPF", dadosCliente.CPF))).FirstOrDefault() : null;

				ClienteModel t2 = !string.IsNullOrEmpty(dadosCliente.RG) ? (await eterDb.ActionDb.GETFIELDS<ClienteModel>(new QueryWhereModel().SetWhere("RG", dadosCliente.RG))).FirstOrDefault() : null;

				return !(t1 is null) ? t1 : !(t2 is null) ? t2 : null;
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;

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
								await eterDb.ActionDb.UPDATE(dadosCliente, connection, transaction);

								var (exist, tempEnderecos) = await ExistAdressCliente(enderecoCliente);

								if (!exist)
								{
									enderecoCliente.CLIENTE_ID = tempCliente.ID;
									ide = await eterDb.ActionDb.INSERT(enderecoCliente, connection, transaction);
								}
								else
								{
									enderecoCliente.ID = tempEnderecos.ID;
									enderecoCliente.CLIENTE_ID = tempCliente.ID;

									ide = enderecoCliente.ID;
									await eterDb.ActionDb.UPDATE(enderecoCliente, connection, transaction);
								}
							}
							else
							{
								idc = await eterDb.ActionDb.INSERT(dadosCliente, connection, transaction);
								enderecoCliente.CLIENTE_ID = idc;
								ide = await eterDb.ActionDb.INSERT(enderecoCliente, connection, transaction);
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
		}

		public async Task<(bool acPass, bool acOk)> Login(string user, string pass = null)
		{

			try
			{
				UserModel userModel = (await eterDb.ActionDb.GETFIELDS<UserModel>(new QueryWhereModel().SetWhere("ID", user))).FirstOrDefault();
				if (userModel == null)
				{ return (false, false); }


				userModel.FUNCAO_NAME = (await eterDb.ActionDb.GETFIELDS<FuncaoDbModel>(new QueryWhereModel().SetWhere("ID", userModel.FUNCAO))).FirstOrDefault()?.NOME;

				if (userModel.PASS == string.Empty)
				{

					UserModelAcess = userModel;
					return (false, true);
				}
				else if (userModel.PASS != string.Empty && pass == null)
				{
					return (true, false);
				}
				else
				{
					if (userModel.PASS == pass)
					{
						UserModelAcess = userModel;
						return (false, true);
					}
				}
				return (false, false);

			}
			catch (Exception ex)
			{
				ex.ErrorGet();
				return (false, false);
			}
		}


	}
}
