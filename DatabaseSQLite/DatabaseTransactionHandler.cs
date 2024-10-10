using System;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseSQLite
{
	public class DatabaseTransactionHandler
	{
		private readonly SQLiteTransactionManager _transactionManager;

		public DatabaseTransactionHandler(SQLiteTransactionManager transactionManager)
		{
			_transactionManager = transactionManager;
		}

		public async Task<object> ExecuteWithTransactionAsync(Func<Task<object>> databaseOperation)
		{
			try
			{
				await _transactionManager.BeginTransactionAsync();

				object result = await databaseOperation();

				bool resp = result.GetType() == typeof(long?) ? (long?)result == -1 ? false : true : (bool)result;

				if (resp)
				{
					await _transactionManager.CommitTransactionAsync();
				}
				else
				{
					await _transactionManager.RollbackTransactionAsync();
				}

				return result;
			}
			catch
			{
				await _transactionManager.RollbackTransactionAsync();
				return false;
			}
		}

		//public async Task<object> ExecuteWithTransactionAsync<T>(Func<T, SQLiteConnection, SQLiteTransaction, Task<object>> databaseOperation, T genericParam)
		//{
		//	//try
		//	//{

		//	//	await _transactionManager.BeginTransactionAsync();


		//	//	var connection = "";// _transactionManager.GetConnection();  
		//	//	var transaction = "";// _transactionManager.GetTransaction();  

		//	//	object result = await databaseOperation(genericParam, connection, transaction);

		//	//	/
		//	//	bool resp = result.GetType() == typeof(long?) ? (long?)result == -1 ? false : true : (bool)result;

		//	//	if (resp)
		//	//	{
		//	//		await _transactionManager.CommitTransactionAsync();
		//	//	}
		//	//	else
		//	//	{
		//	//		await _transactionManager.RollbackTransactionAsync();
		//	//	}

		//	//	return result;
		//	//}
		//	//catch
		//	//{
		//	//	await _transactionManager.RollbackTransactionAsync();
		//	return false;
		//	//}
		//}

	}
}
