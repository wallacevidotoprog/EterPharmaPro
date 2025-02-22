using EterPharmaPro.API;
using EterPharmaPro.Controllers;
using EterPharmaPro.DatabaseFireBase;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseSQLite
{
	public class EterDb : IEterDb
	{
		public readonly string _databaseConnection;

		public bool ServeConnection { get; private set; }

		public DatabaseTransactionHandler _transactionHandler;

		public FirebaseDb firebaseDb { get; set; }

		public ActionAPI ActionAPI { get; set; }

		public IActionDbBase ActionDb { get; set; }

		public EterDbController EterDbController { get; set; }

		public string DatabaseConnection => _databaseConnection;

		public EterDb()
		{
			_databaseConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\DADOS\\database.db;Version=3;";
			try
			{
				SQLiteConnection connection = new SQLiteConnection(_databaseConnection);
				connection.Open();
				ServeConnection = true;
				SetDb();

				_transactionHandler = new DatabaseTransactionHandler(new SQLiteTransactionManager(connection));

				connection.Close();
			}
			catch (Exception ex)
			{
				ServeConnection = false;
				ex.ErrorGet();
			}
		}

		private void SetDb()
		{
			ActionDb = new ActionDbBase(_databaseConnection);
			EterDbController = new EterDbController(this);
			SetCache();
		}

		private async void SetCache()
		{

			
			(List<PaymentDbModal> paymente, List<SituationDbModal> situation, List<DeliveryMethodDbModal> deliveryMethod) temp = await EterDbController.ReturnPropsAsync();
			Cache.Instance.Situation = temp.situation;
			Cache.Instance.Paymente = temp.paymente;
			Cache.Instance.DeliveryMethod = temp.deliveryMethod;
		}

		public async Task<bool> ExecuteTransactionAsync(params Func<Task<bool>>[] databaseOperations)
		{
			return (bool)await _transactionHandler.ExecuteWithTransactionAsync(async () =>
			{
				foreach (var operation in databaseOperations)
				{
					bool result = await operation();
					if (!result)
					{
						return false;
					}
				}
				return true;
			});
		}

		public async Task<object> ExecuteTransactionAsync(Func<Task<object>> databaseOperations)
		{
			return (object)await _transactionHandler.ExecuteWithTransactionAsync(async () =>
			{
				return await databaseOperations();
			});
		}

		

		async void testeFb()
		{


			////cliente 53 end 43

			//var c = (await ActionDb.GETFIELDS<ClienteDbModel>(new QueryWhereModel().SetWhere("ID", 53))).FirstOrDefault();
			//var e = (await ActionDb.GETFIELDS<EnderecoClienteDbModel>(new QueryWhereModel().SetWhere("ID", 43))).FirstOrDefault();

			//EntregaDbModel entregaDbModel = new EntregaDbModel
			//{
			//	CLIENTE_ID = c.ID,
			//	ENDERECO_ID = e.ID,
			//	DATE = DateTime.Now,
			//	KM = 68954,
			//	USER_ID = 8,
			//	TYPE_DELIVERY = 10,
			//	VALUE = 50.23m
			//};
			//entregaDbModel.SetUID();



			//using (var connection = new SQLiteConnection(DatabaseConnection))
			//{
			//	await connection.OpenAsync().ConfigureAwait(false);
			//	using (var transaction = connection.BeginTransaction())
			//	{
			//		try
			//		{
			//			entregaDbModel.ID = await ActionDb.INSERT(entregaDbModel, connection, transaction);
			//			transaction.Commit();
			//		}
			//		catch (Exception ex)
			//		{
			//			transaction.Rollback();
			//			ex.ErrorGet();
			//		}
			//	}
			//}


			//EntregaFbModel entregaFbModel = new EntregaFbModel(entregaDbModel);
			//entregaFbModel.USER_ID = new INDENT(8, "WALLACE VIDOTO");
			//entregaFbModel.CLIENTE_ID = new INDENT(c.ID, c.NOME);
			//entregaFbModel.ENDERECO_ID = new INDENT(e.ID, e.ENDERECO, e.OBSERVACAO);

			
			//var t = await ActionDb.GETFIELDS<MedicamentosControladoDbModel>(new QueryWhereModel());
			//         for (int i = 0; i < t.Count; i++)
			//         {
			//	await actionAPI.INSERT(t[i], t[i].TABLE_NAME);

			//}
			//ActionAPI actionAPI = new ActionAPI();
			//var ts = entregaDbModel.FIREBASE_ID = await actionAPI.INSERT(entregaFbModel);
			//string stop = null;


			//var temp = await firebaseDb.AddDataAsync<EntregaFbModel>(entregaFbModel);
			//entregaDbModel.FIREBASE_ID = temp;
			//using (var connection = new SQLiteConnection(DatabaseConnection))
			//{
			//	await connection.OpenAsync().ConfigureAwait(false);
			//	using (var transaction = connection.BeginTransaction())
			//	{
			//		try
			//		{
			//			await ActionDb.UPDATE(entregaDbModel, connection, transaction);
			//			transaction.Commit();
			//		}
			//		catch (Exception ex)
			//		{
			//			transaction.Rollback();
			//			ex.ErrorGet();
			//		}
			//	}
			//}

			//var temp3 = await actionAPI.GETALL();
			//var temp3 = await actionAPI.GETALL();
			//var temp4 = await actionAPI.GET("-OAe-4PhLRFqbFnk3-b6");
			//var temp2 = await firebaseDb.GetDataAsync<EntregaFbModel>();
		}

		//------ EXEMPLO ------
		//public async Task<bool> AtualizarDadosComTransacaoAsync(UserModel cliente, UserModel endereco, UserModel usuario)
		//{
		//	return await eterDb.ExecuteTransactionAsync(
		//		() => DbCliente.UpdateClienteAsync(cliente),    
		//		() => DbEndereco.UpdateEnderecoAsync(endereco), 
		//		() => DbUser.UpdateUsuarioAsync(usuario)        
		//	);
		//}

		//void tt()
		//{
		//	using (var connection = new SQLiteConnection(eterDb.DatabaseConnection))
		//	{
		//		await connection.OpenAsync().ConfigureAwait(false);
		//		using (var transaction = connection.BeginTransaction())
		//		{
		//			try
		//			{

		//				var temps = requisicaoNotas.DisolveBySQL();

		//				await eterDb.ActionDb.UPDATE(temps.control, connection, transaction);

		//				temps.reqs.ForEach(req => { req.CQN_ID = temps.control.ID; });

		//				await eterDb.ActionDb.DELETE<ReqNotaDbModal>(new QueryDeleteModel().SetWhere("CQN_ID", requisicaoNotas.ID), connection, transaction);

		//				for (int i = 0; i < temps.reqs.Count; i++)
		//				{
		//					await eterDb.ActionDb.INSERT(temps.reqs[i], connection, transaction);
		//				}


		//				transaction.Commit();
		//				return true;
		//			}
		//			catch (Exception ex)
		//			{
		//				transaction.Rollback();
		//				ex.ErrorGet();
		//				return false;
		//			}
		//		}
		//	}
		//}
	}
}
