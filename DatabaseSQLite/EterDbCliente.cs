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
	internal class EterDbCliente : IEterDbCliente
	{
		private readonly string _databaseConnection;

		public EterDbCliente(string databaseConnection)
		{
			_databaseConnection = databaseConnection;
		}

		public async Task<long> CreateCliente(ClienteModel model)
		{
			long id = -1L;
			try
			{
				using (SQLiteConnection connection = new SQLiteConnection(_databaseConnection))
				{

					try
					{

						string Query = "INSERT INTO CLIENTES (CPF,RG,NOME,TELEFONE) VALUES (@CPF, @RG,@NOME,@TELEFONE)";
						using (SQLiteCommand command = new SQLiteCommand(Query, connection))
						{
							command.Parameters.AddWithValue("@CPF", model.CPF);
							command.Parameters.AddWithValue("@RG", model.RG);
							command.Parameters.AddWithValue("@NOME", model.NOME);
							command.Parameters.AddWithValue("@TELEFONE", model.TELEFONE);
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
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return id;
		}

		public async Task<bool> UpdateCliente(ClienteModel model)
		{
			try
			{
				using (SQLiteConnection connection = new SQLiteConnection(_databaseConnection))
				{

					try
					{

						string Query = "UPDATE CLIENTES SET CPF = @CPF ,RG = @RG, NOME = @NOME , TELEFONE = @TELEFONE WHERE ID = @ID";
						using (SQLiteCommand command = new SQLiteCommand(Query, connection))
						{
							command.Parameters.AddWithValue("@ID", model.ID);
							command.Parameters.AddWithValue("@CPF", model.CPF);
							command.Parameters.AddWithValue("@RG", model.RG);
							command.Parameters.AddWithValue("@NOME", model.NOME);
							command.Parameters.AddWithValue("@TELEFONE", model.TELEFONE);
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

		public async Task<bool> DeleteCliente(string id)
		{
			try
			{
				using (SQLiteConnection connection = new SQLiteConnection(_databaseConnection))
				{

					try
					{

						string Query = "DELETE FROM CLIENTES WHERE ID = @ID";
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
		public async Task<List<ClienteModel>> GetCliente(string query = null, TypeDoc typeDoc = TypeDoc.NONE)
		{
			try
			{
				return await new MapDbEter(_databaseConnection).QueryAsync<ClienteModel>($"SELECT * FROM CLIENTES {(typeDoc == TypeDoc.ID ? " WHERE ID = " + query : typeDoc == TypeDoc.CPF ? " WHERE CPF = " + query : typeDoc == TypeDoc.RG ? " WHERE RG = " + query : string.Empty)}");
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;
		}
		//public async Task<List<ClienteModel>> GetCliente(string queryID = null, TypeDoc typeDoc = TypeDoc.NONE)
		//{
		//	if (queryID != null && typeDoc == TypeDoc.NONE)
		//	{
		//		typeDoc = queryID.TypeDocs();
		//	}
		//	try
		//	{
		//		using (SQLiteConnection connection = new SQLiteConnection(_databaseConnection))
		//		{
		//			await connection.OpenAsync().ConfigureAwait(continueOnCapturedContext: false);
		//			List<ClienteModel> tempObj = null;
		//			if (typeDoc == TypeDoc.NONE)
		//			{
		//				string Query = "SELECT * FROM CLIENTES";
		//				using (SQLiteCommand sQLiteCommand = new SQLiteCommand(Query, connection))
		//				{

		//					using DbDataReader dbDataReader = await sQLiteCommand.ExecuteReaderAsync();
		//					tempObj = new List<DadosCliente>();
		//					while (await dbDataReader.ReadAsync())
		//					{
		//						tempObj.Add(new DadosCliente
		//						{
		//							ID = (long)dbDataReader["ID"],
		//							CPF = ((dbDataReader["CPF"].ToString() == "0") ? string.Empty : dbDataReader["CPF"].ToString()),
		//							RG = ((dbDataReader["RG"].ToString() == "0") ? string.Empty : dbDataReader["RG"].ToString()),
		//							NOME = ((dbDataReader["NOME"].ToString() == "0") ? string.Empty : dbDataReader["NOME"].ToString()),
		//							TELEFONE = ((dbDataReader["TELEFONE"].ToString() == "0") ? string.Empty : dbDataReader["TELEFONE"].ToString())
		//						});
		//					}
		//				}
		//			}

		//		}
		//		else
		//		{
		//			_ = string.Empty;
		//			using (SQLiteCommand command = new SQLiteCommand(typeDoc switch
		//			{
		//				TypeDoc.CPF => "SELECT * FROM CLIENTES WHERE CPF = @ID",
		//				TypeDoc.RG => "SELECT * FROM CLIENTES WHERE RG = @ID",
		//				TypeDoc.ID => "SELECT * FROM CLIENTES WHERE ID = @ID",
		//				_ => "SELECT * FROM CLIENTES",
		//			}, connection);
		//			command.Parameters.AddWithValue("@ID", queryID);
		//			using DbDataReader reader = await command.ExecuteReaderAsync();
		//			tempObj = new List<DadosCliente>();
		//			while (await reader.ReadAsync())
		//			{
		//				tempObj.Add(new DadosCliente
		//				{
		//					ID = (long)reader["ID"],
		//					CPF = ((reader["CPF"].ToString() == "0") ? string.Empty : reader["CPF"].ToString()),
		//					RG = ((reader["RG"].ToString() == "0") ? string.Empty : reader["RG"].ToString()),
		//					NOME = ((reader["NOME"].ToString() == "0") ? string.Empty : reader["NOME"].ToString()),
		//					TELEFONE = ((reader["TELEFONE"].ToString() == "0") ? string.Empty : reader["TELEFONE"].ToString())
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
