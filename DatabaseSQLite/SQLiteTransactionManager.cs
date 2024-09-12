using System;
using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseSQLite
{
	public class SQLiteTransactionManager : IDisposable
	{
		private SQLiteConnection _connection;
		private SQLiteTransaction _transaction;

		public SQLiteTransactionManager(SQLiteConnection connection)
		{
			_connection = connection;
		}

		public async Task BeginTransactionAsync()
		{
			if (_connection.State != ConnectionState.Open)
			{
				await _connection.OpenAsync();
			}
			_transaction = _connection.BeginTransaction();
		}

		public async Task CommitTransactionAsync()
		{
			if (_transaction == null) return;

			try
			{
				await Task.Run(() => _transaction.Commit());
			}
			finally
			{
				_transaction.Dispose();
			}
		}

		public async Task RollbackTransactionAsync()
		{
			if (_transaction == null) return;

			try
			{
				await Task.Run(() => _transaction.Rollback());
			}
			finally
			{
				_transaction.Dispose();
			}
		}

		public void Dispose()
		{
			_transaction?.Dispose();
			if (_connection.State == ConnectionState.Open)
			{
				_connection.Close();
			}
		}
	}

}
