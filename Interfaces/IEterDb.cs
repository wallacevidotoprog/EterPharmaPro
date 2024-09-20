using EterPharmaPro.Controllers;
using EterPharmaPro.DatabaseSQLite;
using System;
using System.Threading.Tasks;

namespace EterPharmaPro.Interfaces
{
	public interface IEterDb
	{
		string DatabaseConnection { get; }
		EterDbController EterDbController { get; set; }
		IEterDbUser DbUser { get; set; }

		IEterDbCliente DbCliente { get; set; }

		IEterDbEndereco DbEndereco { get; set; }

		IEterDbManipulados DbManipulados { get; set; }

		IEterDbManipuladosMedicamentos DbManipuladosMedicamentos { get; set; }

		IEterDbRequisicoesNotas DbRequisicoesNotas { get; set; }

		IEterDbControlados DbControlados { get; set; }

		IEterDbValidade DbValidade { get; set; }

		IEterDbProdutoValidade DbProdutoValidade { get; set; }

		IEterDbCategoria DbCategoria { get; set; }

		Task<bool> ExecuteTransactionAsync(params Func<Task<bool>>[] databaseOperations);
	}
}
