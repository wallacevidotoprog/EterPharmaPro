using System.Collections.Generic;
using System.Threading.Tasks;

namespace EterPharmaPro.Interfaces
{
	public interface IEterDbManipuladosMedicamentos
	{
		Task<long> CreateMedicamento(string model, string id);

		Task<bool> UpdateMedicamento(string model, string id);

		Task<bool> DeleteMedicamento(string id);

		Task<List<string>> GetMedicamento(string queryID = null);
	}
}
