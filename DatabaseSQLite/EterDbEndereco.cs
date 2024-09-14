using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseSQLite
{
	public class EterDbEndereco : IEterDbEndereco
	{
		private readonly string _databaseConnection;

		public EterDbEndereco(string databaseConnection)
		{
			_databaseConnection = databaseConnection;
		}

		public async Task<long?> CreateEndereco(EnderecoClienteModel model, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			long id = -1L;
			try
			{
				try
				{

					string Query = "INSERT INTO ENDERECO_C (CLIENTE_ID,ENDERECO,OBSERVACAO) VALUES (@CLIENTE_ID,@ENDERECO,@OBSERVACAO)";
					using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
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
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return id;
		}

		public async Task<bool> UpdateEndereco(EnderecoClienteModel model, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{
				try
				{

					string Query = "UPDATE ENDERECO_C SET CLIENTE_ID = @CLIENTE_ID , ENDERECO = @ENDERECO , OBSERVACAO = @OBSERVACAO WHERE ID = @ID;";
					using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
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
			catch (Exception ex2)
			{
				Exception ex = ex2;
				ex.ErrorGet();
			}
			return false;
		}

		public async Task<bool> DeleteEndereco(string id, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				string Query = "DELETE FROM ENDERECO_C WHERE ID = @ID";
				using (SQLiteCommand command = new SQLiteCommand(Query, connection,transaction))
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

		}
	}
}
