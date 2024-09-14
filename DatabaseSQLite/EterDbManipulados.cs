using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseSQLite
{ //
	public class EterDbManipulados : IEterDbManipulados
	{
		private readonly string _databaseConnection;

		public EterDbManipulados(string databaseConnection)
		{
			_databaseConnection = databaseConnection;
		}

		public async Task<long> CreateManipulacao(ManipulacaoModel model, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			long id = -1L;
			try
			{
				string Query = "INSERT INTO MANIPULADOS (ATEN_LOJA,DATA,ATEN_MANI,CLIENTE_ID,ENDERECO_ID,SITUCAO,FORMAPAGAMENTO,MODOENTREGA,VALORFINAL,OBSGERAL) " +
					"VALUES (@ATEN_LOJA,@DATA,@ATEN_MANI,@CLIENTE_ID , @ENDERECO_ID,@SITUCAO,@FORMAPAGAMENTO,@MODOENTREGA,@VALORFINAL,@OBSGERAL)";
				using (SQLiteCommand command = new SQLiteCommand(Query, connection))
				{
					command.Parameters.AddWithValue("@ATEN_LOJA", model.DADOSATENDIMENTO.ATEN_LOJA);
					command.Parameters.AddWithValue("@DATA", ((DateTimeOffset)model.DADOSATENDIMENTO.DATA).ToUnixTimeSeconds());
					command.Parameters.AddWithValue("@ATEN_MANI", model.DADOSATENDIMENTO.ATEN_MANI);
					command.Parameters.AddWithValue("@CLIENTE_ID", ((DadosClienteManipulacao)model.DADOSCLIENTE).ID_CLIENTE);
					command.Parameters.AddWithValue("@ENDERECO_ID", ((DadosClienteManipulacao)model.DADOSCLIENTE).ID_ENDERECO);
					command.Parameters.AddWithValue("@SITUCAO", model.SITUCAO);
					command.Parameters.AddWithValue("@FORMAPAGAMENTO", model.FORMAPAGAMENTO);
					command.Parameters.AddWithValue("@MODOENTREGA", model.MODOENTREGA);
					command.Parameters.AddWithValue("@VALORFINAL", model.VALORFINAL);
					command.Parameters.AddWithValue("@OBSGERAL", model.OBSGERAL);
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

		public async Task<bool> UpdateManipulacao(ManipulacaoModel model, SQLiteConnection connection, SQLiteTransaction transaction)
		{

			try
			{
				string Query = "UPDATE MANIPULADOS SET ATEN_LOJA = @ATEN_LOJA ,DATA = @DATA ,ATEN_MANI = @ATEN_MANI ,CLIENTE_ID = @CLIENTE_ID ,ENDERECO_ID = @ENDERECO_ID , SITUCAO = @SITUCAO,FORMAPAGAMENTO = @FORMAPAGAMENTO ,MODOENTREGA = @MODOENTREGA ,VALORFINAL = @VALORFINAL,  OBSGERAL = @OBSGERAL WHERE ID = @ID";
				using (SQLiteCommand command = new SQLiteCommand(Query, connection))
				{
					command.Parameters.AddWithValue("@ID", model.ID);
					command.Parameters.AddWithValue("@ATEN_LOJA", model.DADOSATENDIMENTO.ATEN_LOJA);
					command.Parameters.AddWithValue("@DATA", ((DateTimeOffset)model.DADOSATENDIMENTO.DATA).ToUnixTimeSeconds());
					command.Parameters.AddWithValue("@ATEN_MANI", model.DADOSATENDIMENTO.ATEN_MANI);
					command.Parameters.AddWithValue("@CLIENTE_ID", ((DadosClienteManipulacao)model.DADOSCLIENTE).ID_CLIENTE);
					command.Parameters.AddWithValue("@ENDERECO_ID", ((DadosClienteManipulacao)model.DADOSCLIENTE).ID_ENDERECO);
					command.Parameters.AddWithValue("@SITUCAO", model.SITUCAO);
					command.Parameters.AddWithValue("@FORMAPAGAMENTO", model.FORMAPAGAMENTO);
					command.Parameters.AddWithValue("@MODOENTREGA", model.MODOENTREGA);
					command.Parameters.AddWithValue("@VALORFINAL", model.VALORFINAL);
					command.Parameters.AddWithValue("@OBSGERAL", model.OBSGERAL);
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

		public async Task<bool> DeleteManipulacao(string id, SQLiteConnection connection, SQLiteTransaction transaction)
		{
			try
			{

				string Query = "DELETE FROM MANIPULADOS WHERE ID = @ID";
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

		public async Task<List<ManipulacaoModel>> GetManipulacao(string query = null)
		{

			try
			{
				List<ManipulacaoDbModel> models = await new MapDbEter(_databaseConnection).QueryAsync<ManipulacaoDbModel>($"SELECT * FROM MANIPULADOS {(query != null ? " WHERE ID = " + query : string.Empty)}");

				List<ManipulacaoModel> manipulacaos = new List<ManipulacaoModel>();

				for (int i = 0; i < models.Count; i++)
				{
					ManipulacaoModel m = new ManipulacaoModel();
					m.ConvertDb(models[i]);
					manipulacaos.Add(m);
				}

				return manipulacaos;

			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return null;

		}
	}
}
