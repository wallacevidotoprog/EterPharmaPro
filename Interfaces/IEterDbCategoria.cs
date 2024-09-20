using EterPharmaPro.Models.DbModels;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.Interfaces
{
	public interface IEterDbCategoria
	{
		Task<long> CreateCategory(CategoriaDbModal model, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> UpdateCategory(CategoriaDbModal modele, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> DeleteCategory(string id, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<List<CategoriaDbModal>> GetCategory(string queryID = null);
	}
}
