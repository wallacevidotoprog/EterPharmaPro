using System;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.Interfaces
{
	public interface IEterDbControlados
	{
		Task<long?> CreateControlado(string med, int qtd, DateTime val, string lote, string id, SQLiteConnection connection, SQLiteTransaction transaction);
		Task<bool> DeleteControlado(string id, SQLiteConnection connection, SQLiteTransaction transaction);
	}
}
