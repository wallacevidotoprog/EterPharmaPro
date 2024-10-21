using EterPharmaPro.Interfaces;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseSQLite
{
	public class EterDbProdutoValidade : IEterDbProdutoValidade
	{
		private readonly string _databaseConnection;

		public EterDbProdutoValidade(string databaseConnection)
		{
			_databaseConnection = databaseConnection;
		}

		public async Task<long?> CreateProdutoVality(ProdutoValidadeDbModal model, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				string Query = "INSERT INTO PRODUTOS_VALIDADE (VALIDADE_ID,PRODUTO_CODIGO,PRODUTO_DESCRICAO,QUANTIDADE,DATA_VALIDADE,CATEGORIA_ID) VALUES (@VALIDADE_ID, @PRODUTO_CODIGO,@PRODUTO_DESCRICAO, @QUANTIDADE,@DATA_VALIDADE,@CATEGORIA_ID)";
				using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
				{
					command.Parameters.AddWithValue("@VALIDADE_ID", model.VALIDADE_ID);
					command.Parameters.AddWithValue("@PRODUTO_CODIGO", model.PRODUTO_CODIGO);
					command.Parameters.AddWithValue("@PRODUTO_DESCRICAO", model.PRODUTO_DESCRICAO);
					command.Parameters.AddWithValue("@QUANTIDADE", model.QUANTIDADE);
					command.Parameters.AddWithValue("@DATA_VALIDADE", model.DATA_VALIDADE);
					command.Parameters.AddWithValue("@CATEGORIA_ID", model.CATEGORIA_ID);
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

		public async Task<bool> DeleteProdutoVality(string id, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				string Query = "DELETE FROM PRODUTOS_VALIDADE WHERE ID = @ID";
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

		public async Task<List<ProdutoValidadeDbModal>> GetProdutoVality(QueryWhereModel query)
		{
			try
			{
				return await new MapDbEter(_databaseConnection).QueryAsync<ProdutoValidadeDbModal>($"SELECT * FROM PRODUTOS_VALIDADE {query.ReturnSQLQuery()}");
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;
		}

		public async Task<bool> UpdateProdutoVality(ProdutoValidadeDbModal model, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				string Query = "UPDATE PRODUTOS_VALIDADE SET VALIDADE_ID = @VALIDADE_ID , PRODUTO_CODIGO = @PRODUTO_CODIGO , PRODUTO_DESCRICAO = @PRODUTO_DESCRICAO , QUANTIDADE = @QUANTIDADE , DATA_VALIDADE = @DATA_VALIDADE , CATEGORIA_ID = @CATEGORIA_ID  WHERE ID = @ID";
				using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
				{
					command.Parameters.AddWithValue("@ID", model.ID);
					command.Parameters.AddWithValue("@VALIDADE_ID", model.VALIDADE_ID);
					command.Parameters.AddWithValue("@PRODUTO_CODIGO", model.PRODUTO_CODIGO);
					command.Parameters.AddWithValue("@PRODUTO_DESCRICAO", model.PRODUTO_DESCRICAO);
					command.Parameters.AddWithValue("@QUANTIDADE", model.QUANTIDADE);
					command.Parameters.AddWithValue("@DATA_VALIDADE", model.DATA_VALIDADE);
					command.Parameters.AddWithValue("@CATEGORIA_ID", model.CATEGORIA_ID);
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
