using DocumentFormat.OpenXml.EMMA;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Events;
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
		public event EventHandler<ControlReqsViewEventArgs> LoadReqs;
		private (List<ControlReqNotaDbModal> c, List<ReqNotaDbModal> r) cache_CR =(null,null);

		private readonly IEterDb eterDb;
		public ControleReqNotaController(IEterDb eterDb)
		{
			this.eterDb = eterDb;
			//_ = LoadControlReqs();
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
				//using (var connection = new SQLiteConnection(eterDb.DatabaseConnection))
				//{
				//	await connection.OpenAsync().ConfigureAwait(false);
				//	using (var transaction = connection.BeginTransaction())
				//	{
				//		try
				//		{


				//			transaction.Commit();
				//			return true;
				//		}
				//		catch (Exception ex)
				//		{
				//			transaction.Rollback();
				//			ex.ErrorGet();
				//			return false;
				//		}
				//	}
				//}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return false;
		}

		public async Task LoadControlReqs()
		{
			try
			{
				DataTable tabela = Create();
				List<ControlReqNotaDbModal> controleReqNotaControllers = await eterDb.ActionDb.GETFIELDS<ControlReqNotaDbModal>(new QueryWhereModel());
				List<ReqNotaDbModal> reqNotaDbModal = await eterDb.ActionDb.GETFIELDS<ReqNotaDbModal>(new QueryWhereModel());

				cache_CR.c = controleReqNotaControllers;
				cache_CR.r = reqNotaDbModal;


				for (int i = 0; i < controleReqNotaControllers.Count; i++)
				{
					var temp1 = reqNotaDbModal.Where(x => x.CQN_ID == controleReqNotaControllers[i].ID);

					UserModel userA = (await eterDb.ActionDb.GETFIELDS<UserModel>(new QueryWhereModel().SetWhere("ID", controleReqNotaControllers[i].AUTHOR))).FirstOrDefault();
					UserModel userV = (await eterDb.ActionDb.GETFIELDS<UserModel>(new QueryWhereModel().SetWhere("ID", controleReqNotaControllers[i].VENDEDOR))).FirstOrDefault();
					tabela.Rows.Add(
						controleReqNotaControllers[i].ID,
						$"{userA.ID_LOJA.ToString().PadLeft(4, '0')} - {userA.NOME}",
						$"{userV.ID_LOJA.ToString().PadLeft(4, '0')} - {userV.NOME}",
						controleReqNotaControllers[i].DATA_VENDA?.ToShortDateString(),
						controleReqNotaControllers[i].DATA_ENVIO?.ToShortDateString(),
						string.Join(" | ", temp1.Select(p => p.REQ)),
						false
						); ;

				}
				OnLoadControlReqs(tabela);
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
		}

		protected virtual void OnLoadControlReqs(DataTable dataTable) => LoadReqs?.Invoke(this, new ControlReqsViewEventArgs(dataTable));

		public async Task<DataTable> GetByDate(object sender)
		{
			List<ControlReqNotaDbModal> tempC = null;
			DateTime value = ((DateTimePicker)sender).Value;

			switch (((DateTimePicker)sender).Name)
			{
				
				case "dateTimePicker_dataVenda":
					tempC = cache_CR.c.Where(x => x.DATA_VENDA?.Month == value.Month && x.DATA_VENDA?.Year == value.Year).ToList();
					break;
				case "dateTimePicker_dataEnvio":
					tempC = cache_CR.c.Where(x => x.DATA_ENVIO?.Month == value.Month && x.DATA_ENVIO?.Year == value.Year).ToList();
					break;
			}
			DataTable tabela = Create();
			

			for (int i = 0; i < tempC.Count; i++)
			{
				var tempR = cache_CR.r.Where(x => x.CQN_ID == tempC[i].ID);

				UserModel userA = (await eterDb.ActionDb.GETFIELDS<UserModel>(new QueryWhereModel().SetWhere("ID", tempC[i].AUTHOR))).FirstOrDefault();
				UserModel userV = (await eterDb.ActionDb.GETFIELDS<UserModel>(new QueryWhereModel().SetWhere("ID", tempC[i].VENDEDOR))).FirstOrDefault();
				tabela.Rows.Add(
					tempC[i].ID,
					$"{userA.ID_LOJA.ToString().PadLeft(4, '0')} - {userA.NOME}",
					$"{userV.ID_LOJA.ToString().PadLeft(4, '0')} - {userV.NOME}",
					tempC[i].DATA_VENDA?.ToShortDateString(),
					tempC[i].DATA_ENVIO?.ToShortDateString(),
					string.Join(" | ", tempR.Select(p => p.REQ)),
					false
					);
			}
			return tabela;


		}

		private DataTable Create()
		{
			DataTable tabela = new DataTable();
			tabela.Columns.Add("ID");
			tabela.Columns.Add("REDIGENTE");
			tabela.Columns.Add("VENDEDOR");
			tabela.Columns.Add("DATAV");
			tabela.Columns.Add("DATAE");
			tabela.Columns.Add("REQS");
			tabela.Columns.Add("ACTION", typeof(bool));
			return tabela;
		}
	}
}
