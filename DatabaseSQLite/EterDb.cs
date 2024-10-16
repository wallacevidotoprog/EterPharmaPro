using EterPharmaPro.Controllers;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EterPharmaPro.DatabaseSQLite
{
	public class EterDb : IEterDb
	{
		public readonly string _databaseConnection;

		public bool ServeConnection { get; private set; }

		public DatabaseTransactionHandler _transactionHandler;

		public UserModel UserModelAcess { get; set; }


		public IActionDbBase ActionDb { get; set; }
		public IEterDbUser DbUser { get; set; }

		public IEterDbCliente DbCliente { get; set; }

		public IEterDbEndereco DbEndereco { get; set; }

		public IEterDbManipulados DbManipulados { get; set; }

		public IEterDbManipuladosMedicamentos DbManipuladosMedicamentos { get; set; }

		public IEterDbRequisicoesNotas DbRequisicoesNotas { get; set; }

		public IEterDbControlados DbControlados { get; set; }

		public IEterDbValidade DbValidade { get; set; }

		public IEterDbProdutoValidade DbProdutoValidade { get; set; }

		public IEterDbCategoria DbCategoria { get; set; }

		public IEterProps DbProps { get; set; }


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
			ActionDb = new ActionDbBase(_databaseConnection);

			DbUser = new EterDbUser(_databaseConnection);
			DbCliente = new EterDbCliente(_databaseConnection);
			DbEndereco = new EterDbEndereco(_databaseConnection);
			DbManipulados = new EterDbManipulados(_databaseConnection);
			DbManipuladosMedicamentos = new EterDbManipuladosMedicamentos(_databaseConnection);
			DbRequisicoesNotas = new EterDbRequisicoesNotas(_databaseConnection);
			DbControlados = new EterDbControlados(_databaseConnection);
			DbValidade = new EterDbValidade(_databaseConnection);
			DbProdutoValidade = new EterDbProdutoValidade(_databaseConnection);
			DbCategoria = new EterDbCategoria(_databaseConnection);
			DbProps = new EterProps(_databaseConnection);
			EterDbController = new EterDbController(this);
		}

		public async Task<bool> ExecuteTransactionAsync(params Func<Task<bool>>[] databaseOperations)
		{
			return (bool)await _transactionHandler.ExecuteWithTransactionAsync(async () =>
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

		public async Task<object> ExecuteTransactionAsync(Func<Task<object>> databaseOperations)
		{
			return (object)await _transactionHandler.ExecuteWithTransactionAsync(async () =>
			{
				return await databaseOperations();
			});
		}

		public async Task<(bool acPass, bool acOk)> Login(string user, string pass = null)
		{

			try
			{
				UserModel userModel = (await DbUser.GetUser(new QueryWhereModel().SetWhere("ID", user))).FirstOrDefault();
				if (userModel == null)
				{ return (false, false); }


				userModel.FUNCAO_NAME = (await DbProps.GetFuncao(new QueryWhereModel().SetWhere("ID", userModel.FUNCAO))).FirstOrDefault()?.NOME;

				if (userModel.PASS == string.Empty)
				{

					UserModelAcess = userModel;
					return (false, true);
				}
				else if (userModel.PASS != string.Empty && pass == null)
				{
					return (true, false);
				}
				else
				{
					if (userModel.PASS == pass)
					{
						UserModelAcess = userModel;
						return (false, true);
					}
				}
				return (false, false);

			}
			catch (Exception ex)
			{
				ex.ErrorGet();
				return (false, false);
			}
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
