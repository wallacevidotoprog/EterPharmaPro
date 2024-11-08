using EterPharmaPro.API;
using EterPharmaPro.API.Models;
using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.API;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace EterPharmaPro.Controllers.Entrega
{
	public class EntregaController
	{
		public event EventHandler loadCompleteLists;
		public event EventHandler loadCompleteListsDelivery;

		private readonly IEterDb eterDb;
		public List<UserModel> listUser { get; private set; }
		public List<TypeDeliveryDbModel> listTypeDelivery { get; private set; }

		public List<DeliveryViewDbModel> deliveryViewDbModels { get; private set; }


		public EntregaController(IEterDb eterDb)
		{
			this.eterDb = eterDb;
			_ = GetAllUserAsync();
			EventGlobal.Subscribe<MessageWebSockerModel>(SocketDelivery);
		}
		void SocketDelivery(MessageWebSockerModel e)
		{
			ReloadModelViewDeliveryAsync();
		}
		private async Task GetAllUserAsync()
		{
			listUser = await eterDb.ActionDb.GETFIELDS<UserModel>(new QueryWhereModel());
			listTypeDelivery = await eterDb.ActionDb.GETFIELDS<TypeDeliveryDbModel>(new QueryWhereModel());

			loadCompleteLists?.Invoke(this, new EventArgs());

			deliveryViewDbModels = await ModelViewDeliveryAsync();

			loadCompleteListsDelivery?.Invoke(this, new EventArgs());
		}

		private async void ReloadModelViewDeliveryAsync()
		{
			deliveryViewDbModels = await ModelViewDeliveryAsync();

			loadCompleteListsDelivery?.Invoke(this, new EventArgs());
		}
		private async Task<List<DeliveryViewDbModel>> ModelViewDeliveryAsync()
		{
			
			List<DeliveryViewDbModel> models = new List<DeliveryViewDbModel>();

			var di = await eterDb.ActionDb.GETFIELDS<EntregaInputDbModel>(new QueryWhereModel());
			var d = await eterDb.ActionDb.GETFIELDS<EntregaDbModel>(new QueryWhereModel());

			for (int i = 0; i < di.Count; i++)
			{
				string clienteName = (await eterDb.ActionDb.GETFIELDS<ClienteDbModel>(new QueryWhereModel().SetWhere("ID", di[i].CLIENTE_ID))).FirstOrDefault()?.NOME;
				EnderecoClienteDbModel tempEnd = (await eterDb.ActionDb.GETFIELDS<EnderecoClienteDbModel>(new QueryWhereModel().SetWhere("ID", di[i].ENDERECO_ID))).FirstOrDefault();
				string endereco = $"{tempEnd?.ENDERECO} - {tempEnd?.OBSERVACAO}";
				EntregaDbModel tempc = d.Where(x => x.DELIVERY_INPUT_ID == di[i].ID).FirstOrDefault();
				string dMan = listUser.Where(x => x.ID == tempc?.USER_ID)?.FirstOrDefault()?.NOME;
				string dVend = listUser.Where(x => x.ID == d[i].USER_ID).FirstOrDefault()?.NOME;

				models.Add(new DeliveryViewDbModel(tempc, di[i])
				{
					Cliente = clienteName,
					Endereco = endereco,
					UserE = dMan,
					UserV = dVend,
					Tipo = listTypeDelivery.Where(x => x.ID == di[i].TYPE_DELIVERY).FirstOrDefault()?.NAME

				});

			}
			return models;
		}

		public List<DeliveryViewDbModel> ModelViewDeliveryByDate(DateTime? dateTime)
		{
			return !(dateTime is null) ? deliveryViewDbModels.Where(x =>
			x.entregaInputDbModel.DATA?.Day == dateTime?.Day &&
			x.entregaInputDbModel.DATA?.Month == dateTime?.Month &&
			x.entregaInputDbModel.DATA?.Year == dateTime?.Year
			).ToList() : deliveryViewDbModels;
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

		public async Task<bool> CreateDeliveryInput(EntregaInputModel model, bool edit = false)
		{
			try
			{

				(long? IDC, long? IDE) = await eterDb.EterDbController.RegisterCliente(model.clienteDbModel);

				if ( IDC is null || IDE is null)
				{
					throw new Exception($"Erro ao cadatrar o cliente IDC={IDC} e IDE={IDE}");
				}
				//UserModel modeU = (await eterDb.ActionDb.GETFIELDS<UserModel>(new QueryWhereModel().SetWhere("ID", model.useridvend))).FirstOrDefault();
				ClienteDbModel modelC = (await eterDb.ActionDb.GETFIELDS<ClienteDbModel>(new QueryWhereModel().SetWhere("ID", IDC))).FirstOrDefault();
				EnderecoClienteDbModel modelE = (await eterDb.ActionDb.GETFIELDS<EnderecoClienteDbModel>(new QueryWhereModel().SetWhere("ID", IDE))).FirstOrDefault();

				DeliveryInputDbModel inputDbModel = new DeliveryInputDbModel
				{
					UID = Guid.NewGuid().ToString(),
					CLIENTE_ID = IDC,
					ENDERECO_ID = IDE,
					DATA = model.data.ToDatetimeUnix(),
					VALUE = model.valor,
					USER_ID=model.useridvend,
					TYPE_DELIVERY=model.tipo
				};				

				using (var connection = new SQLiteConnection(eterDb.DatabaseConnection))
				{
					await connection.OpenAsync().ConfigureAwait(false);
					using (var transaction = connection.BeginTransaction())
					{
						try
						{


							if (edit)
							{
								//await eterDb.ActionDb.DELETE<MedicamentosManipuladosDbModal>(new QueryDeleteModel().SetWhere("ID", model.ID), connection, transaction);
								//await eterDb.ActionDb.UPDATE(model, connection, transaction);

								//((List<MedicamentosManipuladosDbModal>)model.MEDICAMENTOS).ForEach(m => m.MANIPULADOS_ID = model.ID);

								//foreach (var medicamento in (List<MedicamentosManipuladosDbModal>)model.MEDICAMENTOS)
								//{
								//	await eterDb.ActionDb.INSERT(medicamento, connection, transaction);
								//}
							}
							else
							{
								long? tempID  = await eterDb.ActionDb.INSERT(inputDbModel, connection, transaction);
								inputDbModel.ID = tempID;
							}

							transaction.Commit();
							//return true;
						}
						catch (Exception ex)
						{
							transaction.Rollback();
							ex.ErrorGet();
							return false;
						}
					}
				}

				EntregaApiModel modelApi = new EntregaApiModel(inputDbModel);
				modelApi.SetUSERID(listUser.Where(x=>x.ID == inputDbModel.USER_ID).FirstOrDefault());
				modelApi.SetCliente(modelC);
				modelApi.SetEndereco(modelE);
				modelApi.SetType(listTypeDelivery.Where(x => x.ID == inputDbModel.TYPE_DELIVERY).FirstOrDefault());


				(string IDF, bool isSucess) = await INSERT_CLOUD(modelApi, inputDbModel.TABLE_NAME);

				if (!isSucess)
				{
					throw new Exception($"Erro ao cadatrar a entrega na Cloud");
				}


				using (var connection = new SQLiteConnection(eterDb.DatabaseConnection))
				{
					await connection.OpenAsync().ConfigureAwait(false);
					using (var transaction = connection.BeginTransaction())
					{
						try
						{
							await eterDb.ActionDb.UPDATE(new DeliveryInputDbModel
							{
								ID = inputDbModel.ID,
								FIREBASE_ID = IDF
							} , connection, transaction);

							transaction.Commit();
						}
						catch (Exception ex)
						{
							transaction.Rollback();
							ex.ErrorGet();
							return false;
						}
					}
				}
				ReloadModelViewDeliveryAsync();
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
				return false;
			}
			return false;
		}

		private async Task<(string IDF,bool isSucess)> INSERT_CLOUD<T>(T model,string table)
		{

			try
			{
				return (
					await eterDb.ActionAPI.INSERT(model, table),
					true
					);
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
				return (string.Empty, false);
			}

			return (string.Empty, false);
		}
	}
}
