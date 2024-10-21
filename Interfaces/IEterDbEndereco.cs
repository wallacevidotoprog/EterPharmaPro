using EterPharmaPro.Enums;
using EterPharmaPro.Models.DbModels;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
namespace EterPharmaPro.Interfaces
{
	public interface IEterDbEndereco
	{
		Task<long?> CreateEndereco(EnderecoClienteDbModel  model, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> UpdateEndereco(EnderecoClienteDbModel model, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> DeleteEndereco(string id, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<List<EnderecoClienteDbModel>> GetEndereco(QueryWhereModel query);
	}
}
