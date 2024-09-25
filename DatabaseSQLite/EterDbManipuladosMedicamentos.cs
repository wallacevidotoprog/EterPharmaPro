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
	public class EterDbManipuladosMedicamentos : IEterDbManipuladosMedicamentos
	{
		private readonly string _databaseConnection;

		public EterDbManipuladosMedicamentos(string databaseConnection)
		{
			_databaseConnection = databaseConnection;
		}

		public async Task<long?> CreateMedicamento(string model, string id, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			long idE = -1L;
			try
			{

				string Query = "INSERT INTO MEDICAMENTO_MANIPULACAO (MANIPULADOS_ID,NAME_M) VALUES (@MANIPULADOS_ID, @NAME_M)";
				using (SQLiteCommand command = new SQLiteCommand(Query, connection))
				{
					command.Parameters.AddWithValue("@MANIPULADOS_ID", id);
					command.Parameters.AddWithValue("@NAME_M", model);
					await command.ExecuteNonQueryAsync().ConfigureAwait(continueOnCapturedContext: false);
					command.CommandText = "SELECT last_insert_rowid()";
					idE = (long)(await command.ExecuteScalarAsync().ConfigureAwait(continueOnCapturedContext: false));
				}

				return idE;
			}
			catch (Exception ex)
			{
				ex.ErrorGet();

				return idE;
			}

		}

		public async Task<bool> UpdateMedicamento(string model, string id, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				string Query = "UPDATE MEDICAMENTO_MANIPULACAO SET NAME_M = @NAME_M WHERE MANIPULADOS_ID = @MANIPULADOS_ID";
				using (SQLiteCommand command = new SQLiteCommand(Query, connection))
				{
					command.Parameters.AddWithValue("@MANIPULADOS_ID", id);
					command.Parameters.AddWithValue("@NAME_M", model);
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

		public async Task<bool> DeleteMedicamento(string id, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{
				string Query = "DELETE FROM MEDICAMENTO_MANIPULACAO WHERE MANIPULADOS_ID = @MANIPULADOS_ID";
				using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
				{
					command.Parameters.AddWithValue("@MANIPULADOS_ID", id);
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

		public async Task<List<string>> GetMedicamento(QueryWhereModel query)
		{
			//bool allUser = queryID == null;
			try
			{
				//using SQLiteConnection connection = new SQLiteConnection(_databaseConnection);
				//await connection.OpenAsync().ConfigureAwait(continueOnCapturedContext: false);
				//List<string> tempObj = null;
				//if (allUser)
				//{
				//	string Query = "SELECT * FROM MEDICAMENTO_MANIPULACAO";
				//	using SQLiteCommand command = new SQLiteCommand(Query, connection);
				//	using DbDataReader reader = await command.ExecuteReaderAsync();
				//	tempObj = new List<string>();
				//	while (await reader.ReadAsync())
				//	{
				//		tempObj.Add(reader["NAME_M"].ToString());
				//	}
				//}
				//else
				//{
				//	string Query = "SELECT * FROM MEDICAMENTO_MANIPULACAO WHERE MANIPULADOS_ID= @MANIPULADOS_ID";
				//	using SQLiteCommand sQLiteCommand = new SQLiteCommand(Query, connection);
				//	sQLiteCommand.Parameters.AddWithValue("@MANIPULADOS_ID", queryID);
				//	using DbDataReader dbDataReader = await sQLiteCommand.ExecuteReaderAsync();
				//	tempObj = new List<string>();
				//	while (await dbDataReader.ReadAsync())
				//	{
				//		tempObj.Add(dbDataReader["NAME_M"].ToString());
				//	}
				//}
				//connection.Close();
				//return tempObj;
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;
		}
	}
}
