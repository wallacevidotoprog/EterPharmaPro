using EterPharmaPro.Enums;
using EterPharmaPro.Models.DbModels;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.Interfaces
{
	public interface IEterDbCliente
	{
		Task<long?> CreateCliente(ClienteModel model, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> UpdateCliente(ClienteModel modele, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> DeleteCliente(string id, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<List<ClienteModel>> GetCliente(string queryID = null, TypeDoc typeDoc = TypeDoc.NONE);
	}
}
