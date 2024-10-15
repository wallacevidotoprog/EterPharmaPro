using DocumentFormat.OpenXml.EMMA;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.Controllers.Impressos
{
	public class ControleReqNotaController
	{
		private readonly IEterDb eterDb;
		public ControleReqNotaController(IEterDb eterDb)
		{
			this.eterDb = eterDb;
		}

		public async Task<bool> CreateCREQ(RequisicaoNotasModel requisicaoNotas)
		{
			try
			{
				using (var connection = new SQLiteConnection(eterDb.DatabaseConnection))
				{
					await connection.OpenAsync().ConfigureAwait(false);
					using (var transaction = connection.BeginTransaction())
					{
						try
						{
							var temps = requisicaoNotas.Disolve();
							long? id = await eterDb.DbRequisicoesNotas.CreateControl(temps.control, connection, transaction);

							temps.reqs.ForEach(req => { req.CQN_ID = id; });

							for (int i = 0; i < temps.reqs.Count; i++)
							{
								await eterDb.DbRequisicoesNotas.CreateReqNota(temps.reqs[i], connection, transaction);
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
			}
			return false;
		}

		public async Task<bool> SendReq(List<long> list)
		{
			try
			{
				using (var connection = new SQLiteConnection(eterDb.DatabaseConnection))
				{
					await connection.OpenAsync().ConfigureAwait(false);
					using (var transaction = connection.BeginTransaction())
					{
						try
						{


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
			}
			return false;
		}
	}
}
