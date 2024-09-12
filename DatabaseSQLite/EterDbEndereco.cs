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
	internal class EterDbEndereco : IEterDbEndereco
	{
		private readonly string _databaseConnection;

		public EterDbEndereco(string databaseConnection)
		{
			_databaseConnection = databaseConnection;
		}

		public async Task<long?> CreateEndereco(EnderecoClienteModel model)
		{
			long id = -1L;
			try
			{
				using (SQLiteConnection connection = new SQLiteConnection(_databaseConnection))
				{

					try
					{

						string Query = "INSERT INTO ENDERECO_C (CLIENTE_ID,ENDERECO,OBSERVACAO) VALUES (@CLIENTE_ID,@ENDERECO,@OBSERVACAO)";
						using (SQLiteCommand command = new SQLiteCommand(Query, connection))
						{
							command.Parameters.AddWithValue("@CLIENTE_ID", model.CLIENTE_ID);
							command.Parameters.AddWithValue("@ENDERECO", model.ENDERECO);
							command.Parameters.AddWithValue("@OBSERVACAO", model.OBSERVACAO);
							await command.ExecuteNonQueryAsync().ConfigureAwait(continueOnCapturedContext: false);
							command.CommandText = "SELECT last_insert_rowid()";
							id = (long)(await command.ExecuteScalarAsync().ConfigureAwait(continueOnCapturedContext: false));
						}

						return id;
					}
					catch (Exception ex)
					{
						ex.ErrorGet();

						return id;
					}
				}
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				ex.ErrorGet();
			}
			return id;
		}

		public async Task<bool> UpdateEndereco(EnderecoClienteModel model)
		{
			try
			{
				using (SQLiteConnection connection = new SQLiteConnection(_databaseConnection))
				{

					try
					{

						string Query = "UPDATE ENDERECO_C SET CLIENTE_ID = @CLIENTE_ID , ENDERECO = @ENDERECO , OBSERVACAO = @OBSERVACAO WHERE ID = @ID;";
						using (SQLiteCommand command = new SQLiteCommand(Query, connection))
						{
							command.Parameters.AddWithValue("@ID", model.ID);
							command.Parameters.AddWithValue("@CLIENTE_ID", model.CLIENTE_ID);
							command.Parameters.AddWithValue("@ENDERECO", model.ENDERECO);
							command.Parameters.AddWithValue("@OBSERVACAO", model.OBSERVACAO);
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
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				ex.ErrorGet();
			}
			return false;
		}

		public async Task<bool> DeleteEndereco(string id)
		{
			try
			{
				using (SQLiteConnection connection = new SQLiteConnection(_databaseConnection))
				{
					try
					{

						string Query = "DELETE FROM ENDERECO_C WHERE ID = @ID";
						using (SQLiteCommand command = new SQLiteCommand(Query, connection))
						{
							command.Parameters.AddWithValue("@ID", id);
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
			catch (Exception ex2)
			{
				Exception ex = ex2;
				ex.ErrorGet();
			}
			return false;
		}

		public async Task<List<EnderecoClienteModel>> GetEndereco(string query = null, QueryClienteEnum queryCliente = QueryClienteEnum.NONE)
		{
			try
			{
				return await new MapDbEter(_databaseConnection).QueryAsync<EnderecoClienteModel>($"SELECT * FROM ENDERECO_C {(queryCliente == QueryClienteEnum.ID ? " WHERE ID = " + query : queryCliente == QueryClienteEnum.CLIENTE_ID ? " WHERE CLIENTE_ID = " + query : string.Empty)}");
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;
			//bool allUser = queryID == null;
			//try
			//{
			//	using SQLiteConnection connection = new SQLiteConnection(_databaseConnection);
			//	await connection.OpenAsync().ConfigureAwait(continueOnCapturedContext: false);
			//	object tempObj = null;
			//	if (allUser)
			//	{
			//		string Query = "SELECT * FROM ENDERECO_C";
			//		using SQLiteCommand command = new SQLiteCommand(Query, connection);
			//		using DbDataReader reader = await command.ExecuteReaderAsync();
			//		tempObj = new List<EnderecoCliente>();
			//		while (await reader.ReadAsync())
			//		{
			//			((List<EnderecoCliente>)tempObj).Add(new EnderecoCliente
			//			{
			//				ID_INDEX = (long)reader["ID"],
			//				ID_CLIENTE = reader["CLIENTE_ID"].ToString(),
			//				LOGRADOURO = reader["ENDERECO"].ToString(),
			//				OBS = reader["OBSERVACAO"].ToString()
			//			});
			//		}
			//	}
			//	else
			//	{
			//		string Query = ((!id) ? "SELECT * FROM ENDERECO_C WHERE CLIENTE_ID = @CLIENTE_ID" : "SELECT * FROM ENDERECO_C WHERE ID = @CLIENTE_ID");
			//		using SQLiteCommand sQLiteCommand = new SQLiteCommand(Query, connection);
			//		sQLiteCommand.Parameters.AddWithValue("@CLIENTE_ID", queryID);
			//		using DbDataReader dbDataReader = await sQLiteCommand.ExecuteReaderAsync();
			//		tempObj = new List<EnderecoCliente>();
			//		while (await dbDataReader.ReadAsync())
			//		{
			//			((List<EnderecoCliente>)tempObj).Add(new EnderecoCliente
			//			{
			//				ID_INDEX = (long)dbDataReader["ID"],
			//				ID_CLIENTE = dbDataReader["CLIENTE_ID"].ToString(),
			//				LOGRADOURO = dbDataReader["ENDERECO"].ToString(),
			//				OBS = dbDataReader["OBSERVACAO"].ToString()
			//			});
			//		}
			//	}
			//	connection.Close();
			//	return tempObj;
			//}
			//catch (Exception ex)
			//{
			//	ex.ErrorGet();
			//}
			return null;
		}
	}
}
