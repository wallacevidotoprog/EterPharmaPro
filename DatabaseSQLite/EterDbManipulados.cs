using EterPharmaPro.Interfaces;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseSQLite
{
	public class EterDbManipulados : IEterDbManipulados
	{
		private readonly string _databaseConnection;

		public EterDbManipulados(string databaseConnection)
		{
			_databaseConnection = databaseConnection;
		}

		//public async Task<long> CreateManipulacao(ManipulacaoModel model)
		//{
		//	long id = -1L;
		//	try
		//	{
		//		using (SQLiteConnection connection = new SQLiteConnection(_databaseConnection))
		//		{
					
		//			try
		//			{
						
		//				string Query = "INSERT INTO MANIPULADOS (ATEN_LOJA,DATA,ATEN_MANI,CLIENTE_ID,ENDERECO_ID,SITUCAO,FORMAPAGAMENTO,MODOENTREGA,VALORFINAL,OBSGERAL) VALUES (@ATEN_LOJA,@DATA,@ATEN_MANI,@CLIENTE_ID , @ENDERECO_ID,@SITUCAO,@FORMAPAGAMENTO,@MODOENTREGA,@VALORFINAL,@OBSGERAL)";
		//				using (SQLiteCommand command = new SQLiteCommand(Query, connection))
		//				{
		//					command.Parameters.AddWithValue("@ATEN_LOJA", model.DADOSATENDIMENTO.ATEN_LOJA);
		//					command.Parameters.AddWithValue("@DATA", ((DateTimeOffset)model.DADOSATENDIMENTO.DATA).ToUnixTimeSeconds());
		//					command.Parameters.AddWithValue("@ATEN_MANI", model.DADOSATENDIMENTO.ATEN_MANI);
		//					command.Parameters.AddWithValue("@CLIENTE_ID", ((DadosClienteManipulacao)model.DADOSCLIENTE).ID_CLIENTE);
		//					command.Parameters.AddWithValue("@ENDERECO_ID", ((DadosClienteManipulacao)model.DADOSCLIENTE).ID_ENDERECO);
		//					command.Parameters.AddWithValue("@SITUCAO", model.SITUCAO);
		//					command.Parameters.AddWithValue("@FORMAPAGAMENTO", model.FORMAPAGAMENTO);
		//					command.Parameters.AddWithValue("@MODOENTREGA", model.MODOENTREGA);
		//					command.Parameters.AddWithValue("@VALORFINAL", model.VALORFINAL);
		//					command.Parameters.AddWithValue("@OBSGERAL", model.OBSGERAL);
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
		//	}
		//	catch (Exception ex2)
		//	{
		//		Exception ex = ex2;
		//		ex.ErrorGet();
		//	}
		//	return id;
		//}

		//public async Task<bool> UpdateManipulacao(ManipulacaoModel model)
		//{
		//	try
		//	{
		//		using (SQLiteConnection connection = new SQLiteConnection(_databaseConnection))
		//		{
					
		//			try
		//			{
						
		//				string Query = "UPDATE MANIPULADOS SET ATEN_LOJA = @ATEN_LOJA ,DATA = @DATA ,ATEN_MANI = @ATEN_MANI ,CLIENTE_ID = @CLIENTE_ID ,ENDERECO_ID = @ENDERECO_ID , SITUCAO = @SITUCAO,FORMAPAGAMENTO = @FORMAPAGAMENTO ,MODOENTREGA = @MODOENTREGA ,VALORFINAL = @VALORFINAL,  OBSGERAL = @OBSGERAL WHERE ID = @ID";
		//				using (SQLiteCommand command = new SQLiteCommand(Query, connection))
		//				{
		//					command.Parameters.AddWithValue("@ID", model.ID);
		//					command.Parameters.AddWithValue("@ATEN_LOJA", model.DADOSATENDIMENTO.ATEN_LOJA);
		//					command.Parameters.AddWithValue("@DATA", ((DateTimeOffset)model.DADOSATENDIMENTO.DATA).ToUnixTimeSeconds());
		//					command.Parameters.AddWithValue("@ATEN_MANI", model.DADOSATENDIMENTO.ATEN_MANI);
		//					command.Parameters.AddWithValue("@CLIENTE_ID", ((DadosClienteManipulacao)model.DADOSCLIENTE).ID_CLIENTE);
		//					command.Parameters.AddWithValue("@ENDERECO_ID", ((DadosClienteManipulacao)model.DADOSCLIENTE).ID_ENDERECO);
		//					command.Parameters.AddWithValue("@SITUCAO", model.SITUCAO);
		//					command.Parameters.AddWithValue("@FORMAPAGAMENTO", model.FORMAPAGAMENTO);
		//					command.Parameters.AddWithValue("@MODOENTREGA", model.MODOENTREGA);
		//					command.Parameters.AddWithValue("@VALORFINAL", model.VALORFINAL);
		//					command.Parameters.AddWithValue("@OBSGERAL", model.OBSGERAL);
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
		//	IL_04c4:;
		//	}
		//	catch (Exception ex2)
		//	{
		//		Exception ex = ex2;
		//		ex.ErrorGet();
		//	}
		//	return false;
		//}

		//public async Task<bool> DeleteManipulacao(string id)
		//{
		//	try
		//	{
		//		using (SQLiteConnection connection = new SQLiteConnection(_databaseConnection))
		//		{
					
		//			try
		//			{
						
		//				string Query = "DELETE FROM MANIPULADOS WHERE ID = @ID";
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
		//	IL_0319:;
		//	}
		//	catch (Exception ex2)
		//	{
		//		Exception ex = ex2;
		//		ex.ErrorGet();
		//	}
		//	return false;
		//}

		//public async Task<List<ManipulacaoModel>> GetManipulacao(string queryID = null)
		//{
		//	bool allUser = queryID != null;
		//	try
		//	{
		//		using SQLiteConnection connection = new SQLiteConnection(_databaseConnection);
		//		await connection.OpenAsync().ConfigureAwait(continueOnCapturedContext: false);
		//		List<ManipulacaoModel> tempObj = null;
		//		if (!allUser)
		//		{
		//			string Query = "SELECT * FROM MANIPULADOS";
		//			using SQLiteCommand sQLiteCommand = new SQLiteCommand(Query, connection);
		//			using DbDataReader reader = await sQLiteCommand.ExecuteReaderAsync();
		//			tempObj = new List<ManipulacaoModel>();
		//			while (await reader.ReadAsync())
		//			{
		//				tempObj.Add(new ManipulacaoModel
		//				{
		//					ID = (long)reader["ID"],
		//					DADOSATENDIMENTO = new DadosAtemdimento
		//					{
		//						ATEN_LOJA = reader["ATEN_LOJA"].ToString(),
		//						DATA = DateTimeOffset.FromUnixTimeSeconds(Convert.ToUInt32(reader["DATA"].ToString())).DateTime,
		//						ATEN_MANI = reader["ATEN_MANI"].ToString()
		//					},
		//					DADOSCLIENTE = new DadosClienteManipulacao
		//					{
		//						ID_CLIENTE = (long)reader["CLIENTE_ID"],
		//						ID_ENDERECO = (long)reader["ENDERECO_ID"]
		//					},
		//					OBSGERAL = reader["OBSGERAL"].ToString(),
		//					SITUCAO = Convert.ToInt32(reader["SITUCAO"].ToString()),
		//					FORMAPAGAMENTO = Convert.ToInt32(reader["FORMAPAGAMENTO"].ToString()),
		//					MODOENTREGA = Convert.ToInt32(reader["MODOENTREGA"].ToString()),
		//					VALORFINAL = Convert.ToDecimal(reader["VALORFINAL"].ToString())
		//				});
		//			}
		//		}
		//		else
		//		{
		//			string Query = "SELECT * FROM MANIPULADOS WHERE ID= @ID";
		//			using SQLiteCommand command = new SQLiteCommand(Query, connection);
		//			command.Parameters.AddWithValue("@ID", queryID);
		//			using DbDataReader dbDataReader = await command.ExecuteReaderAsync();
		//			tempObj.Add(new ManipulacaoModel
		//			{
		//				ID = (long)dbDataReader["ID"],
		//				DADOSATENDIMENTO = new DadosAtemdimento
		//				{
		//					ATEN_LOJA = dbDataReader["ATEN_LOJA"].ToString(),
		//					DATA = DateTimeOffset.FromUnixTimeSeconds(Convert.ToUInt32(dbDataReader["DATA"].ToString())).DateTime,
		//					ATEN_MANI = dbDataReader["ATEN_MANI"].ToString()
		//				},
		//				DADOSCLIENTE = dbDataReader["CLIENTE_ID"],
		//				OBSGERAL = dbDataReader["OBSGERAL"].ToString(),
		//				SITUCAO = Convert.ToInt32(dbDataReader["SITUCAO"].ToString()),
		//				FORMAPAGAMENTO = Convert.ToInt32(dbDataReader["FORMAPAGAMENTO"].ToString()),
		//				MODOENTREGA = Convert.ToInt32(dbDataReader["MODOENTREGA"].ToString()),
		//				VALORFINAL = Convert.ToDecimal(dbDataReader["VALORFINAL"].ToString())
		//			});
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
