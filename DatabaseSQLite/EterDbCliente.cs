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
	public class EterDbCliente : IEterDbCliente
	{
		private readonly string _databaseConnection;

		public EterDbCliente(string databaseConnection)
		{
			_databaseConnection = databaseConnection;
		}

		public async Task<long> CreateCliente(ClienteModel model, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			long id = -1L;
			try
			{
				try
				{

					string Query = "INSERT INTO CLIENTES (CPF,RG,NOME,TELEFONE) VALUES (@CPF, @RG,@NOME,@TELEFONE)";
					using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
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
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return id;
		}

		public async Task<bool> UpdateCliente(ClienteModel model, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{
				try
				{

					string Query = "UPDATE CLIENTES SET CPF = @CPF ,RG = @RG, NOME = @NOME , TELEFONE = @TELEFONE WHERE ID = @ID";
					using (SQLiteCommand command = new SQLiteCommand(Query, connection, transaction))
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
			catch (Exception ex2)
			{
				Exception ex = ex2;
				ex.ErrorGet();
			}
			return false;
		}

		public async Task<bool> DeleteCliente(string id, SQLiteConnection connection, SQLiteTransaction transaction)
		{

			try
			{

				string Query = "DELETE FROM CLIENTES WHERE ID = @ID";
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
	}
}