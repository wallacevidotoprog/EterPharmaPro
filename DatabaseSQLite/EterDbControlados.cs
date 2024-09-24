using EterPharmaPro.Interfaces;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseSQLite
{
	public class EterDbControlados : IEterDbControlados
	{
		private readonly string _databaseConnection;

		public EterDbControlados(string databaseConnection)
		{
			_databaseConnection = databaseConnection;
		}

		public async Task<long?> CreateControlado(string med, int qtd, DateTime val, string lote, string id, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			long idE = -1L;

			try
			{

				string Query = "INSERT INTO MEDICAMENTO_CONTROLADO (CLIENTE_ID,NAME_M,QTD,VALIDADE,LOTE) VALUES (@CLIENTE_ID, @NAME_M,@QTD,@VALIDADE,@LOTE)";
				using (SQLiteCommand command = new SQLiteCommand(Query, connection,transaction))
				{
					command.Parameters.AddWithValue("@CLIENTE_ID", id);
					command.Parameters.AddWithValue("@NAME_M", med);
					command.Parameters.AddWithValue("@QTD", qtd);
					command.Parameters.AddWithValue("@VALIDADE", val);
					command.Parameters.AddWithValue("@LOTE", lote);
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

		public async Task<bool> DeleteControlado(string id, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				string Query = "DELETE FROM MEDICAMENTO_CONTROLADO WHERE ID = @ID";
				using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
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
}
