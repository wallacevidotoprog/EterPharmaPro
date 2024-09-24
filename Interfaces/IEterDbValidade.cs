using EterPharmaPro.Enums;
using EterPharmaPro.Models.DbModels;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.Interfaces
{
	public interface IEterDbValidade
	{
		Task<long?> CreateVality(ValidadeDbModal model, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> UpdateVality(ValidadeDbModal model, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> DeleteVality(string id, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<List<ValidadeDbModal>> GetVality(string queryID = null);
	}
}
