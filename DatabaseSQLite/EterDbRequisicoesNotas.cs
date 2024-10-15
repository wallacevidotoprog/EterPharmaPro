using DocumentFormat.OpenXml.EMMA;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseSQLite
{
	internal class EterDbRequisicoesNotas : IEterDbRequisicoesNotas
	{
		private readonly string _databaseConnection;

		public EterDbRequisicoesNotas(string databaseConnection)
		{
			_databaseConnection = databaseConnection;
		}

		public async Task<long?> CreateControl(ControlReqNotaDbModal model, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				try
				{

					string Query = "INSERT INTO CONTROL_REQ_NOTA (VENDEDOR,AUTHOR,DATA_VENDA) VALUES (@VENDEDOR,@AUTHOR,@DATA_VENDA );";
					using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
					{
						command.Parameters.AddWithValue("@VENDEDOR", model.VENDEDOR);
						command.Parameters.AddWithValue("@AUTHOR", model.AUTHOR);
						command.Parameters.AddWithValue("@DATA_VENDA", model.DATA_VENDA);
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

		public async Task<long?> CreateReqNota(ReqNotaDbModal model, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				try
				{

					string Query = "INSERT INTO REQ_NOTA (CQN_ID,REQ) VALUES (@CQN_ID,@REQ);";
					using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
					{
						command.Parameters.AddWithValue("@CQN_ID", model.CQN_ID);
						command.Parameters.AddWithValue("@REQ", model.REQ);
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

		public async Task<bool> DeleteControl(string id, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				string Query = "DELETE FROM CONTROL_REQ_NOTA WHERE ID = @ID";
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

		public async Task<bool> DeleteReqNota(string id, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				string Query = "DELETE FROM REQ_NOTA WHERE ID = @ID";
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

		public async Task<List<ControlReqNotaDbModal>> GetControl(QueryWhereModel query)
		{
			try
			{
				return await new MapDbEter(_databaseConnection).QueryAsync<ControlReqNotaDbModal>($"SELECT * FROM CONTROL_REQ_NOTA {query.ReturnSQLQuery()}");
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;
		}

		public async Task<List<ReqNotaDbModal>> GetReqNota(QueryWhereModel query)
		{
			try
			{
				return await new MapDbEter(_databaseConnection).QueryAsync<ReqNotaDbModal>($"SELECT * FROM REQ_NOTA {query.ReturnSQLQuery()}");
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;
		}

		public async Task<bool> UpdateControl(ControlReqNotaDbModal model, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{
				try
				{

					string Query = "UPDATE USERS SET VENDEDOR = @VENDEDOR, AUTHOR = @AUTHOR, DATA_VENDA = @DATA_VENDA , DATA_ENVIO = @DATA_ENVIO WHERE ID = @ID";
					using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
					{
						command.Parameters.AddWithValue("@ID", model.ID);
						command.Parameters.AddWithValue("@VENDEDOR", model.VENDEDOR);
						command.Parameters.AddWithValue("@AUTHOR", model.AUTHOR);
						command.Parameters.AddWithValue("@DATA_VENDA", model.DATA_VENDA);
						command.Parameters.AddWithValue("@DATA_ENVIO", model.DATA_ENVIO);

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

		public async Task<bool> UpdateReqNota(ReqNotaDbModal model, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{
				try
				{

					string Query = "UPDATE USERS SET CQN_ID = @CQN_ID, REQ = @REQ WHERE ID = @ID";
					using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
					{
						command.Parameters.AddWithValue("@ID", model.ID);
						command.Parameters.AddWithValue("@CQN_ID", model.CQN_ID);
						command.Parameters.AddWithValue("@REQ", model.REQ);

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
	}
}
