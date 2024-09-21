using EterPharmaPro.Models.DbModels;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace EterPharmaPro.Interfaces
{
	public interface IEterDbProdutoValidade
	{
		Task<long?> CreateProdutoVality(ProdutoValidadeDbModal model, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> UpdateProdutoVality(ProdutoValidadeDbModal modele, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> DeleteProdutoVality(string id, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<List<ProdutoValidadeDbModal>> GetProdutoVality(string queryID = null);
	}
}
