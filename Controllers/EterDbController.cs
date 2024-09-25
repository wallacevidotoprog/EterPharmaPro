using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models.DbModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EterPharmaPro.Controllers
{
	public class EterDbController
	{
		private readonly IEterDb eterDb;

		public EterDbController(IEterDb _eterDb)
		{
			eterDb = _eterDb;
		}

		public async Task<(bool exist, EnderecoClienteModel end)> ExistAdressCliente(EnderecoClienteModel enderecoCliente)
		{
			List<EnderecoClienteModel> tempA = await eterDb.DbEndereco.GetEndereco(
				new QueryWhereModel().SetWhere(nameof(enderecoCliente.CLIENTE_ID), enderecoCliente.CLIENTE_ID)
				);
			for (int i = 0; i < tempA.Count; i++)
			{
				if (tempA[i].ENDERECO.ToUpper().Trim().Replace(" ", null) == enderecoCliente.ENDERECO.ToUpper().Trim().Replace(" ", null))
				{
					return (exist: true, end: tempA[i]);
				}
			}
			return (exist: false, end: null);
		}

		public async Task<ClienteModel> ExistCliente(ClienteModel dadosCliente, bool exist = false)//refaazer mais simples com o novo query
		{
			if (exist)
			{
				List<ClienteModel> aex = await eterDb.DbCliente.GetCliente(new QueryWhereModel().SetWhere(nameof(dadosCliente.ID), dadosCliente.ID));//ID
				return (aex.Count > 0) ? aex[0] : null;
			}
			List<ClienteModel> t1 = dadosCliente.CPF != string.Empty ? await eterDb.DbCliente.GetCliente(new QueryWhereModel().SetWhere(nameof(dadosCliente.CPF), dadosCliente.CPF)) : new List<ClienteModel>();
			List<ClienteModel> t2 = dadosCliente.RG != string.Empty ? await eterDb.DbCliente.GetCliente(new QueryWhereModel().SetWhere(nameof(dadosCliente.RG), dadosCliente.RG)) : new List<ClienteModel>();
			return (t1.Count > 0) ? t1[0] : ((t2.Count > 0) ? t2[0] : null);
		}
	}
}
