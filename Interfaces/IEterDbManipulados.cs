using EterPharmaPro.Models;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.Interfaces
{
	public interface IEterDbManipulados
	{
		Task<long?> CreateManipulacao(ManipulacaoModel model, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> UpdateManipulacao(ManipulacaoModel model, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> DeleteManipulacao(string id, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<List<ManipulacaoModel>> GetManipulacao(string queryID = null);
	}
}
