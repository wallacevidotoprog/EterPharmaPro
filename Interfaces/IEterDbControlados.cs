using System;
using System.Threading.Tasks;

namespace EterPharmaPro.Interfaces
{
	public interface IEterDbControlados
	{
		Task<long> CreateControlado(string med, int qtd, DateTime val, string lote, string id);
	}
}
