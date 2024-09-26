using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseSQLite
{
	public class EterDbValidade : IEterDbValidade
	{
		private readonly string _databaseConnection;

		public EterDbValidade(string databaseConnection)
		{
			_databaseConnection = databaseConnection;
		}

		public async Task<long?> CreateVality(ValidadeDbModal model, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				string Query = "INSERT INTO VALIDADES (USER_ID ,DATE) VALUES (@USER_ID, @DATE)";
				using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
				{
					command.Parameters.AddWithValue("@USER_ID", model.USER_ID);
					command.Parameters.AddWithValue("@DATE", model.DATE.ToDatetimeUnix());
					await command.ExecuteNonQueryAsync();
					command.CommandText = "SELECT last_insert_rowid()";
					return (long)(await command.ExecuteScalarAsync().ConfigureAwait(continueOnCapturedContext: false));
				}

			}
			catch (Exception ex)
			{
				ex.ErrorGet();

				return -1;
			}
		}

		public async Task<bool> DeleteVality(string id, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				string Query = "DELETE FROM VALIDADES WHERE ID = @ID";
				using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
				{
					command.Parameters.AddWithValue("@ID", id);
					await command.ExecuteNonQueryAsync();
				}

				return true;
			}
			catch (Exception ex)
			{
				ex.ErrorGet();

				return false;
			}
		}

		public async Task<List<ValidadeDbModal>> GetVality(QueryWhereModel query)
		{
			try
			{
				return await new MapDbEter(_databaseConnection).QueryAsync<ValidadeDbModal>($"SELECT * FROM VALIDADES {query.ReturnSQLQuery()}");
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;
		}

		public async Task<bool> UpdateVality(ValidadeDbModal model, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				string Query = "UPDATE VALIDADES SET USER_ID = @USER_ID , DATE = @DATE   WHERE ID = @ID";
				using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
				{
					command.Parameters.AddWithValue("@ID", model.ID);
					command.Parameters.AddWithValue("@USER_ID", model.USER_ID);
					command.Parameters.AddWithValue("@DATE", model.DATE);
					await command.ExecuteNonQueryAsync().ConfigureAwait(continueOnCapturedContext: false);
				}

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
