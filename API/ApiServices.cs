using EterPharmaPro.API.Enum;
using EterPharmaPro.API.Models;
using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils;
using EterPharmaPro.Utils.Extencions;
using Newtonsoft.Json;
using System;
using System.Data.SQLite;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace EterPharmaPro.API
{
	public class ApiServices
	{
		private readonly WebSocketClient webSocketClient;
		private readonly IEterDb eterDb;

		public ApiServices(WebSocketClient webSocketClient, IEterDb eterDb)
		{
			this.eterDb = eterDb;
			this.webSocketClient = webSocketClient;

			webSocketClient.MessageReceived += WebSocketClient_MessageReceived;
		}

		public void AccessUser(UserModel userModelAcess)
		{
			webSocketClient.InitClient(new MessageWebSockerModel
			{
				type = TypesReciverWebSocketConst.Register,
				user = userModelAcess
			});
		}

		private async void WebSocketClient_MessageReceived(object sender, MessageWebSockerModel e)
		{	

			if (e.type == TypesReciverWebSocketConst.Delivery)
			{
				ResponseDeliveryModel resp = JsonConvert.DeserializeObject<ResponseDeliveryModel>(e.data.ToString());

				Type classType = GetClassByTableName(resp.table);


				object classData = resp.type== ResponseDeliveryConst.UPDATE?  JsonConvert.DeserializeObject(resp.data.ToString(), classType):null;

				switch (resp.type)
				{
					case ResponseDeliveryConst.INSERT:
						await INSERT(classData);
						break;
					case ResponseDeliveryConst.UPDATE:
						await UPDATE(classData);
						break;
					case ResponseDeliveryConst.DELETE:
						await DELETE(classData);
						break;
					default:
						break;
				}
			}
			EventGlobal.Publish(e);
		}



		private async Task INSERT( object classData)
		{

		}
		private async Task UPDATE(object classData)
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
							await eterDb.ActionDb.UPDATE(classData, connection, transaction);

							transaction.Commit();
							//return true;
						}
						catch (Exception ex)
						{
							transaction.Rollback();
							ex.ErrorGet();
						}
					}
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			
			
		}
		private async Task DELETE(object classData)
		{
			using (var connection = new SQLiteConnection(eterDb.DatabaseConnection))
			{
				await connection.OpenAsync().ConfigureAwait(false);
				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						/// ex: await eterDb.ActionDb.DELETE<ReqNotaDbModal>(new QueryDeleteModel().SetWhere("CQN_ID", requisicaoNotas.ID), connection, transaction);
						/// 

						//object tempObj = model.data;

						//Type objectType = tempObj.GetType();

						//var tempID = tempObj.GetType().GetProperty("ID", BindingFlags.Public | BindingFlags.Instance).GetValue(tempObj)?.ToString();

						////await eterDb.ActionDb.DELETE<tempObj> (new QueryDeleteModel().SetWhere("ID", tempID), connection, transaction);

						//// Obter o método DELETE da classe ActionDb
						//var deleteMethod = eterDb.ActionDb.GetType().GetMethod("DELETE");
						//if (deleteMethod == null)
						//{
						//	throw new Exception("Método DELETE não encontrado.");
						//}

						//// Criar a versão concreta do método DELETE com o tipo de tempObj
						//var genericDeleteMethod = deleteMethod.MakeGenericMethod(objectType);

						//// Criar a consulta de exclusão
						//var queryModel = new QueryDeleteModel().SetWhere("ID", tempID);

						//// Invocar o método DELETE dinamicamente
						//var task = (Task)genericDeleteMethod.Invoke(eterDb.ActionDb, new object[] { queryModel, connection, transaction });

						//// Aguardar a execução assíncrona
						//await task;

						//transaction.Commit();
						////return true;
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						ex.ErrorGet();
					}
				}
			}
		}


		private static Type GetClassByTableName(string tableName)
		{
			var types = Assembly.GetExecutingAssembly().GetTypes();

			foreach (var type in types)
			{
				var tableNameProperty = type.GetProperty("TABLE_NAME", BindingFlags.Public | BindingFlags.Instance);

				if (tableNameProperty != null && tableNameProperty.PropertyType == typeof(string))
				{
					var instance = Activator.CreateInstance(type);
					string value = tableNameProperty.GetValue(instance) as string;

					if (value == tableName)
					{
						return type; 
					}
				}
			}

			return null; 
		}

	}
}
