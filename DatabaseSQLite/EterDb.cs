using EterPharmaPro.Controllers;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Data.SQLite;
using System.IO;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseSQLite
{
	public class EterDb : IEterDb
	{
		public readonly string _databaseConnection;

		public bool ServeConnection { get; private set; }

		public DatabaseTransactionHandler _transactionHandler;

		public IEterDbUser DbUser { get; set; }

		public IEterDbCliente DbCliente { get; set; }

		public IEterDbEndereco DbEndereco { get; set; }

		public IEterDbManipulados DbManipulados { get; set; }

		public IEterDbManipuladosMedicamentos DbManipuladosMedicamentos { get; set; }

		public IEterDbRequisicoesNotas DbRequisicoesNotas { get; set; }

		public IEterDbControlados DbControlados { get; set; }
		public EterDbController EterDbController { get; set; }

		public string DatabaseConnection => _databaseConnection;

		public EterDb()
		{
			_databaseConnection = "Data Source=" + Directory.GetCurrentDirectory() + "\\DADOS\\database.db;Version=3;";
			try
			{
				SQLiteConnection connection = new SQLiteConnection(_databaseConnection);
				connection.Open();
				ServeConnection = true;
				SetDb();

				_transactionHandler = new DatabaseTransactionHandler(new SQLiteTransactionManager(connection));

				connection.Close();
			}
			catch (Exception ex)
			{
				ServeConnection = false;
				ex.ErrorGet();
			}
		}

		private void SetDb()
		{
			
			DbUser = new EterDbUser(_databaseConnection);
			DbCliente = new EterDbCliente(_databaseConnection);
			DbEndereco = new EterDbEndereco(_databaseConnection);
			DbManipulados = new EterDbManipulados(_databaseConnection);
			DbManipuladosMedicamentos = new EterDbManipuladosMedicamentos(_databaseConnection);
			DbRequisicoesNotas = new EterDbRequisicoesNotas(_databaseConnection);
			DbControlados = new EterDbControlados(_databaseConnection);

			EterDbController = new EterDbController(this);
		}

		public async Task<bool> ExecuteTransactionAsync(params Func<Task<bool>>[] databaseOperations)
		{
			return await _transactionHandler.ExecuteWithTransactionAsync(async () =>
			{
				foreach (var operation in databaseOperations)
				{
					bool result = await operation();
					if (!result)
					{
						return false;
					}
				}
				return true;
			});
		}
		//------ EXEMPLO ------
		//public async Task<bool> AtualizarDadosComTransacaoAsync(UserModel cliente, UserModel endereco, UserModel usuario)
		//{
		//	return await eterDb.ExecuteTransactionAsync(
		//		() => DbCliente.UpdateClienteAsync(cliente),    
		//		() => DbEndereco.UpdateEnderecoAsync(endereco), 
		//		() => DbUser.UpdateUsuarioAsync(usuario)        
		//	);
		//}
	}
}
