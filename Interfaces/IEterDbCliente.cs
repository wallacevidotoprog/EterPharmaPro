using EterPharmaPro.Enums;
using EterPharmaPro.Models.DbModels;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.Interfaces
{
	public interface IEterDbCliente
	{
		Task<long?> CreateCliente(ClienteDbModel model, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> UpdateCliente(ClienteDbModel modele, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> DeleteCliente(string id, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<List<ClienteDbModel>> GetCliente(QueryWhereModel query);
	}
}
