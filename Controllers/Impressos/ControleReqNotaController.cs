using DocumentFormat.OpenXml.EMMA;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

		public async Task<DataTable> GetByDate(DateTimePicker dateTimePicker_dataQ = null)
		{
			DataTable tabela = new DataTable();
			List<ControlReqNotaDbModal> controleReqNotaControllers = await eterDb.ActionDb.GETFIELDS<ControlReqNotaDbModal>(new QueryWhereModel());
			List<ReqNotaDbModal> reqNotaDbModal = await eterDb.ActionDb.GETFIELDS<ReqNotaDbModal>(new QueryWhereModel());
			tabela.Columns.Add("ID");
			tabela.Columns.Add("REDIGENTE");
			tabela.Columns.Add("VENDEDOR");
			tabela.Columns.Add("DATAV");
			tabela.Columns.Add("DATAE");
			tabela.Columns.Add("REQS");
			tabela.Columns.Add("ACTION",typeof(bool));

            for (int i = 0; i < controleReqNotaControllers.Count; i++)
            {
				var temp1 = reqNotaDbModal.Where(x => x.CQN_ID == controleReqNotaControllers[i].ID);
				string temp = string.Join(" | ", temp1.Select(p => p.REQ));
				tabela.Rows.Add(
					controleReqNotaControllers[i].ID,
					controleReqNotaControllers[i].AUTHOR,
					controleReqNotaControllers[i].VENDEDOR,
					controleReqNotaControllers[i].DATA_VENDA,
					controleReqNotaControllers[i].DATA_ENVIO,
					string.Join(" | ", temp1.Select(p => p.REQ)),
					false
					);

			}
			return tabela;
		}
	}
}
