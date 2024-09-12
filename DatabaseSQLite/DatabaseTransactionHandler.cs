using System;
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

		public async Task<bool> ExecuteWithTransactionAsync(Func<Task<bool>> databaseOperation)
		{
			try
			{
				await _transactionManager.BeginTransactionAsync();

				bool result = await databaseOperation();

				if (result)
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
	}
}
