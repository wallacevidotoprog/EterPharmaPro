using EterPharmaPro.Interfaces;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseSQLite
{
	internal class EterDbEndereco : IEterDbEndereco
	{
		private readonly string _databaseConnection;

		public EterDbEndereco(string databaseConnection)
		{
			_databaseConnection = databaseConnection;
		}

		//public async Task<long?> CreateEndereco(EnderecoCliente model)
		//{
		//	long id = -1L;
		//	try
		//	{
		//		using (SQLiteConnection connection = new SQLiteConnection(_databaseConnection))
		//		{
					
		//			try
		//			{
						
		//				string Query = "INSERT INTO ENDERECO_C (CLIENTE_ID,ENDERECO,OBSERVACAO) VALUES (@CLIENTE_ID,@ENDERECO,@OBSERVACAO)";
		//				using (SQLiteCommand command = new SQLiteCommand(Query, connection))
		//				{
		//					command.Parameters.AddWithValue("@CLIENTE_ID", model.ID_CLIENTE);
		//					command.Parameters.AddWithValue("@ENDERECO", model.LOGRADOURO);
		//					command.Parameters.AddWithValue("@OBSERVACAO", model.OBS);
		//					await command.ExecuteNonQueryAsync().ConfigureAwait(continueOnCapturedContext: false);
		//					command.CommandText = "SELECT last_insert_rowid()";
		//					id = (long)(await command.ExecuteScalarAsync().ConfigureAwait(continueOnCapturedContext: false));
		//				}
						
		//				return id;
		//			}
		//			catch (Exception ex)
		//			{
		//				ex.ErrorGet();
						
		//				return id;
		//			}
		//		}
		//	IL_041e:;
		//	}
		//	catch (Exception ex2)
		//	{
		//		Exception ex = ex2;
		//		ex.ErrorGet();
		//	}
		//	return id;
		//}

		//public async Task<bool> UpdateEndereco(EnderecoCliente model)
		//{
		//	try
		//	{
		//		using (SQLiteConnection connection = new SQLiteConnection(_databaseConnection))
		//		{
					
		//			try
		//			{
						
		//				string Query = "UPDATE ENDERECO_C SET CLIENTE_ID = @CLIENTE_ID , ENDERECO = @ENDERECO , OBSERVACAO = @OBSERVACAO WHERE ID = @ID;";
		//				using (SQLiteCommand command = new SQLiteCommand(Query, connection))
		//				{
		//					command.Parameters.AddWithValue("@ID", model.ID_INDEX);
		//					command.Parameters.AddWithValue("@CLIENTE_ID", model.ID_CLIENTE);
		//					command.Parameters.AddWithValue("@ENDERECO", model.LOGRADOURO);
		//					command.Parameters.AddWithValue("@OBSERVACAO", model.OBS);
		//					await command.ExecuteNonQueryAsync();
		//				}
						
		//				return true;
		//			}
		//			catch (Exception ex)
		//			{
		//				ex.ErrorGet();
						
		//				return false;
		//			}
		//		}
		//	IL_036f:;
		//	}
		//	catch (Exception ex2)
		//	{
		//		Exception ex = ex2;
		//		ex.ErrorGet();
		//	}
		//	return false;
		//}

		//public async Task<bool> DeleteEndereco(string id)
		//{
		//	try
		//	{
		//		using (SQLiteConnection connection = new SQLiteConnection(_databaseConnection))
		//		{
					
		//			try
		//			{
						
		//				string Query = "DELETE FROM ENDERECO_C WHERE ID_INDEX = @ID";
		//				using (SQLiteCommand command = new SQLiteCommand(Query, connection))
		//				{
		//					command.Parameters.AddWithValue("@ID", id);
		//					await command.ExecuteNonQueryAsync().ConfigureAwait(continueOnCapturedContext: false);
		//				}
						
		//				return true;
		//			}
		//			catch (Exception ex)
		//			{
		//				ex.ErrorGet();
						
		//				return false;
		//			}
		//		}
		//	IL_0309:;
		//	}
		//	catch (Exception ex2)
		//	{
		//		Exception ex = ex2;
		//		ex.ErrorGet();
		//	}
		//	return false;
		//}

		//public async Task<object> GetEndereco(string queryID = null, bool id = false)
		//{
		//	bool allUser = queryID == null;
		//	try
		//	{
		//		using SQLiteConnection connection = new SQLiteConnection(_databaseConnection);
		//		await connection.OpenAsync().ConfigureAwait(continueOnCapturedContext: false);
		//		object tempObj = null;
		//		if (allUser)
		//		{
		//			string Query = "SELECT * FROM ENDERECO_C";
		//			using SQLiteCommand command = new SQLiteCommand(Query, connection);
		//			using DbDataReader reader = await command.ExecuteReaderAsync();
		//			tempObj = new List<EnderecoCliente>();
		//			while (await reader.ReadAsync())
		//			{
		//				((List<EnderecoCliente>)tempObj).Add(new EnderecoCliente
		//				{
		//					ID_INDEX = (long)reader["ID"],
		//					ID_CLIENTE = reader["CLIENTE_ID"].ToString(),
		//					LOGRADOURO = reader["ENDERECO"].ToString(),
		//					OBS = reader["OBSERVACAO"].ToString()
		//				});
		//			}
		//		}
		//		else
		//		{
		//			string Query = ((!id) ? "SELECT * FROM ENDERECO_C WHERE CLIENTE_ID = @CLIENTE_ID" : "SELECT * FROM ENDERECO_C WHERE ID = @CLIENTE_ID");
		//			using SQLiteCommand sQLiteCommand = new SQLiteCommand(Query, connection);
		//			sQLiteCommand.Parameters.AddWithValue("@CLIENTE_ID", queryID);
		//			using DbDataReader dbDataReader = await sQLiteCommand.ExecuteReaderAsync();
		//			tempObj = new List<EnderecoCliente>();
		//			while (await dbDataReader.ReadAsync())
		//			{
		//				((List<EnderecoCliente>)tempObj).Add(new EnderecoCliente
		//				{
		//					ID_INDEX = (long)dbDataReader["ID"],
		//					ID_CLIENTE = dbDataReader["CLIENTE_ID"].ToString(),
		//					LOGRADOURO = dbDataReader["ENDERECO"].ToString(),
		//					OBS = dbDataReader["OBSERVACAO"].ToString()
		//				});
		//			}
		//		}
		//		connection.Close();
		//		return tempObj;
		//	}
		//	catch (Exception ex)
		//	{
		//		ex.ErrorGet();
		//	}
		//	return null;
		//}
	}
}
