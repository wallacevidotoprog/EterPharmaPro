using EterPharmaPro.Enums;
using EterPharmaPro.Models.DbModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EterPharmaPro.Interfaces
{
	public interface IEterDbCliente
	{
		Task<long> CreateCliente(ClienteModel model);

		Task<bool> UpdateCliente(ClienteModel modele);

		Task<bool> DeleteCliente(string id);

		Task<List<ClienteModel>> GetCliente(string queryID = null, TypeDoc typeDoc = TypeDoc.NONE);
	}
}
