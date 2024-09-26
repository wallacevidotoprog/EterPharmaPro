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
	public class EterDbCategoria : IEterDbCategoria
	{
		private readonly string _databaseConnection;

		public EterDbCategoria(string databaseConnection)
		{
			_databaseConnection = databaseConnection;
		}

		public async Task<long?> CreateCategory(CategoriaDbModal model, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				string Query = "INSERT INTO CATEGORIA_VALIDADE (NAME,ID_LOJA) VALUES (@NAME, @ID_LOJA)";
				using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
				{
					command.Parameters.AddWithValue("@NAME", model.NAME);
					command.Parameters.AddWithValue("@ID_LOJA", model.ID_LOJA);
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

		public async Task<bool> DeleteCategory(string id, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				string Query = "DELETE FROM CATEGORIA_VALIDADE WHERE ID = @ID";
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

		public async Task<List<CategoriaDbModal>> GetCategory(QueryWhereModel query)
		{
			try
			{
				return await new MapDbEter(_databaseConnection).QueryAsync<CategoriaDbModal>($"SELECT * FROM CATEGORIA_VALIDADE {query.ReturnSQLQuery()}");
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;
		}

		public async Task<bool> UpdateCategory(CategoriaDbModal model, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				string Query = "UPDATE CATEGORIA_VALIDADE SET NAME = @NAME , USER_ID = @USER_ID   WHERE ID = @ID";
				using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
				{
					command.Parameters.AddWithValue("@ID", model.ID);
					command.Parameters.AddWithValue("@NAME", model.NAME);
					command.Parameters.AddWithValue("@USER_ID", model.ID_LOJA);
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
