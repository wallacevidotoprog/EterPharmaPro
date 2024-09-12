using EterPharmaPro.Enums;
using EterPharmaPro.Models.DbModels;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace EterPharmaPro.Interfaces
{
	public interface IEterDbEndereco
	{
		Task<long?> CreateEndereco(EnderecoClienteModel  model);

		Task<bool> UpdateEndereco(EnderecoClienteModel model);

		Task<bool> DeleteEndereco(string id);

		Task<List<EnderecoClienteModel>> GetEndereco(string queryID = null, QueryClienteEnum queryCliente = QueryClienteEnum.NONE);
	}
}
