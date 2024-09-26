using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseSQLite
{
	internal class EterDbUser : IEterDbUser
	{
		private readonly string _databaseConnection;

		public EterDbUser(string databaseConnection)
		{
			_databaseConnection = databaseConnection;
		}

		public async Task<long?> CreateUser(UserModel model, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				try
				{

					string Query = "INSERT INTO USERS (ID_LOJA,NOME,FUNCAO,STATUS) VALUES (@ID, @NOME,@FUNCAO,@STATUS)";
					using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
					{
						command.Parameters.AddWithValue("@ID_LOJA", model.ID_LOJA);
						command.Parameters.AddWithValue("@NOME", model.NOME);
						command.Parameters.AddWithValue("@FUNCAO", model.FUNCAO);
						command.Parameters.AddWithValue("@STATUS", model.STATUS);
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
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return -1;
		}

		public async Task<bool> UpdateUser(UserModel model, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{
				try
				{

					string Query = "UPDATE USERS SET NOME = @NOME, FUNCAO = @FUNCAO, STATUS = @STATUS WHERE ID = @ID";
					using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
					{
						command.Parameters.AddWithValue("@ID", model.ID);
						command.Parameters.AddWithValue("@NOME", model.NOME);
						command.Parameters.AddWithValue("@FUNCAO", model.FUNCAO);
						command.Parameters.AddWithValue("@STATUS", model.STATUS);
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
			catch (Exception ex2)
			{
				Exception ex = ex2;
				ex.ErrorGet();
			}
			return false;
		}

		public async Task<bool> DeleteUser(string id, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				string Query = "DELETE FROM USERS WHERE ID = @ID";
				using (SQLiteCommand command = new SQLiteCommand(Query, connection,transaction))
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

		public async Task<List<UserModel>> GetUser(QueryWhereModel query)
		{
			try
			{
				return await new MapDbEter(_databaseConnection).QueryAsync<UserModel>($"SELECT * FROM USERS {query.ReturnSQLQuery()}");
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;
		}
	}
}
