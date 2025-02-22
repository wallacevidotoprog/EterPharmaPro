using DocumentFormat.OpenXml.EMMA;
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
		private async void SocketDelivery(MessageWebSockerModel e) => await ReloadModelViewDeliveryAsync();// MUDAR
		private async Task GetAllUserAsync()
		{
			listUser = await eterDb.ActionDb.GETFIELDS<UserModel>(new QueryWhereModel());
			listTypeDelivery = await eterDb.ActionDb.GETFIELDS<TypeDeliveryDbModel>(new QueryWhereModel());
			deliveryViewDbModels = await ModelViewDeliveryAsync();

			loadCompleteLists?.Invoke(this, new EventArgs());

			loadCompleteListsDelivery?.Invoke(this, new EventArgs());
		}

		private async Task ReloadModelViewDeliveryAsync()
		{
			deliveryViewDbModels = await ModelViewDeliveryAsync();

			loadCompleteListsDelivery?.Invoke(this, new EventArgs());
		}

		public async Task<List<DeliveryViewDbModel>> RetModelViewDeliveryAsync() => await ModelViewDeliveryAsync();

		private async Task<List<DeliveryViewDbModel>> ModelViewDeliveryAsync()
		{
			List<DeliveryViewDbModel> models = new List<DeliveryViewDbModel>();
			try
			{

				var entregaInputDbModel = await eterDb.ActionDb.GETFIELDS<EntregaInputDbModel>(new QueryWhereModel());
				var entregaDbModel = await eterDb.ActionDb.GETFIELDS<EntregaDbModel>(new QueryWhereModel());

				for (int i = 0; i < entregaInputDbModel.Count; i++)
				{
					string clienteName = (await eterDb.ActionDb.GETFIELDS<ClienteDbModel>(new QueryWhereModel().SetWhere("ID", entregaInputDbModel[i].CLIENTE_ID))).FirstOrDefault()?.NOME;

					EnderecoClienteDbModel tempEnd = (await eterDb.ActionDb.GETFIELDS<EnderecoClienteDbModel>(new QueryWhereModel().SetWhere("ID", entregaInputDbModel[i].ENDERECO_ID))).FirstOrDefault();
					string endereco = $"{tempEnd?.ENDERECO} - {tempEnd?.OBSERVACAO}";

					string dVend = listUser.Where(x => x.ID == entregaInputDbModel[i]?.USER_ID).FirstOrDefault()?.NOME;

					EntregaDbModel tempc = entregaDbModel.Where(x => x.DELIVERY_INPUT_ID == entregaInputDbModel[i].ID).FirstOrDefault();
					string dMan = listUser.Where(x => x.ID == tempc?.USER_ID)?.FirstOrDefault()?.NOME;

					models.Add(new DeliveryViewDbModel(tempc, entregaInputDbModel[i])
					{
						Cliente = clienteName,
						Endereco = endereco,
						UserE = dMan,
						UserV = dVend,
						Tipo = listTypeDelivery.Where(x => x.ID == entregaInputDbModel[i].TYPE_DELIVERY).FirstOrDefault()?.NAME,
						Stats = tempc?.STATS??0

					});

				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
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

				if (IDC is null || IDE is null)
				{
					throw new Exception($"Erro ao cadatrar o cliente IDC={IDC} e IDE={IDE}");
				}

				ClienteDbModel modelC = (await eterDb.ActionDb.GETFIELDS<ClienteDbModel>(new QueryWhereModel().SetWhere("ID", IDC))).FirstOrDefault();
				EnderecoClienteDbModel modelE = (await eterDb.ActionDb.GETFIELDS<EnderecoClienteDbModel>(new QueryWhereModel().SetWhere("ID", IDE))).FirstOrDefault();

				DeliveryInputDbModel inputDbModel = new DeliveryInputDbModel
				{
					UID = Guid.NewGuid().ToString(),
					CLIENTE_ID = IDC,
					ENDERECO_ID = IDE,
					DATE = model.data,
					VALUE = model.valor,
					USER_ID = model.useridvend,
					TYPE_DELIVERY = model.tipo
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
								long? tempID = await eterDb.ActionDb.INSERT(inputDbModel, connection, transaction);
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

				EntregaApiModel modelApi = new EntregaApiModel(
					inputDbModel,
					listUser.Where(x => x.ID == inputDbModel.USER_ID).FirstOrDefault(),
					modelC,
					modelE,
					listTypeDelivery.Where(x => x.ID == inputDbModel.TYPE_DELIVERY).FirstOrDefault()
					);
				//modelApi.SetUSERID(listUser.Where(x => x.ID == inputDbModel.USER_ID).FirstOrDefault());
				//modelApi.SetCliente(modelC);
				//modelApi.SetEndereco(modelE);
				//modelApi.SetType(listTypeDelivery.Where(x => x.ID == inputDbModel.TYPE_DELIVERY).FirstOrDefault());


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
							}, connection, transaction);

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
				_ = ReloadModelViewDeliveryAsync();
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
				return false;
			}
			return false;
		}

		private async Task<(string IDF, bool isSucess)> INSERT_CLOUD<T>(T model, string table)
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

		}

		public async Task<bool> CreateDelivery(EntregaDbModel entregaDbModel, bool edit = false)
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
								entregaDbModel.UID = Guid.NewGuid().ToString();
								long? tempID = await eterDb.ActionDb.INSERT(entregaDbModel, connection, transaction);
								entregaDbModel.ID = tempID;
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

				(string IDF, bool isSucess) = await INSERT_CLOUD(entregaDbModel, entregaDbModel.TABLE_NAME);

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
							await eterDb.ActionDb.UPDATE(new EntregaDbModel
							{
								ID = entregaDbModel.ID,
								FIREBASE_ID = IDF
							}, connection, transaction);

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

				_ = ReloadModelViewDeliveryAsync();
				return true;
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
				return false;
			}

		}
	}
}
