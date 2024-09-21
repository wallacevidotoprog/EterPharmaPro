using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.Interfaces
{
	public interface IEterDbManipuladosMedicamentos
	{
		Task<long?> CreateMedicamento(string model, string id, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> UpdateMedicamento(string model, string id, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> DeleteMedicamento(string id, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<List<string>> GetMedicamento(string queryID = null);
	}
}
