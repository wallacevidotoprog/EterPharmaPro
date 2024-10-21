using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.Models.DbModels;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.Interfaces
{
	public interface IActionDbBase
	{
		Task<long?> INSERT<T>(T model, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> UPDATE<T>(T model, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> DELETE<T>(QueryDeleteModel query, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<List<T>> GETFIELDS<T>(QueryWhereModel query) where T : new();
	}
}
