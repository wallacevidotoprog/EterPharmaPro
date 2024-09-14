using EterPharmaPro.Enums;
using EterPharmaPro.Models.DbModels;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
namespace EterPharmaPro.Interfaces
{
	public interface IEterDbEndereco
	{
		Task<long?> CreateEndereco(EnderecoClienteModel  model, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> UpdateEndereco(EnderecoClienteModel model, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<bool> DeleteEndereco(string id, SQLiteConnection connection, SQLiteTransaction transaction);

		Task<List<EnderecoClienteModel>> GetEndereco(string queryID = null, QueryClienteEnum queryCliente = QueryClienteEnum.NONE);
	}
}
