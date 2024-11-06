using EterPharmaPro.API;
using EterPharmaPro.Controllers;
using System;
using System.Threading.Tasks;

namespace EterPharmaPro.Interfaces
{
	public interface IEterDb
	{
		string DatabaseConnection { get; }
		EterDbController EterDbController { get; set; }

		IActionDbBase ActionDb { get; set; }

		ActionAPI actionAPI { get; set; }

		Task<bool> ExecuteTransactionAsync(params Func<Task<bool>>[] databaseOperations);
		Task<object> ExecuteTransactionAsync(Func<Task<object>> databaseOperations);

	}
}
