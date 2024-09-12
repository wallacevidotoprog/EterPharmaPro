using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Controllers.Manipulacao
{
	public class ManipuladoController
	{
		private readonly IEterDb _eterDb;

		//private ManipuladoService manipuladoService;

		public ManipuladoController(IEterDb eterDb)
		{
			_eterDb = eterDb;
			//manipuladoService = new ManipuladoService(_eterDb);
		}

		public async Task<List<ClienteModel>> GetCliente(string query = null, TypeDoc typeDoc = TypeDoc.NONE)
		{
			List<ClienteModel> dadosCliente = await _eterDb.DbCliente.GetCliente();
			for (int i = 0; i < dadosCliente.Count; i++)
			{
				dadosCliente[i].ENDERECO = await _eterDb.DbEndereco.GetEndereco(dadosCliente[i].ID.ToString());
			}
			return dadosCliente;
		}

		public async Task<bool> PrintDocManipulado(ManipulacaoModel model, EnumManipulado enumManipulado, bool edit = false)
		{
			try
			{
				switch (enumManipulado)
				{
					case EnumManipulado.P_80:
						manipuladoService.PrintDocManipulado80mm(model);
						break;
					case EnumManipulado.A4:
						manipuladoService.PrintDocManipuladoA4(model);
						break;
				}
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				ex.ErrorGet();
			}
			//	try
			//	{
			//		DadosCliente dadosCliente = (DadosCliente)model.DADOSCLIENTE;
			//		EnderecoCliente enderecoCliente = (EnderecoCliente)dadosCliente.ENDERECO;
			//		model.DADOSCLIENTE = new DadosClienteManipulacao();
			//		DadosCliente tempCliente = await ExistCliente(dadosCliente, edit);
			//		if (tempCliente != null)
			//		{
			//			((DadosClienteManipulacao)model.DADOSCLIENTE).ID_CLIENTE = tempCliente.ID;
			//			await _eterDb.DbCliente.UpdateCliente(dadosCliente);
			//			(bool exist, int id) tempEnd = await ExistAdressC(enderecoCliente);
			//			if (!tempEnd.exist)
			//			{
			//				enderecoCliente.ID_CLIENTE = tempCliente.ID;
			//				DadosClienteManipulacao dadosClienteManipulacao = (DadosClienteManipulacao)model.DADOSCLIENTE;
			//				dadosClienteManipulacao.ID_ENDERECO = await _eterDb.DbEndereco.CreateEndereco(enderecoCliente);
			//			}
			//			else
			//			{
			//				List<EnderecoCliente> tempA = (List<EnderecoCliente>)(await _eterDb.DbEndereco.GetEndereco(enderecoCliente.ID_CLIENTE.ToString()));
			//				if (tempA[tempEnd.id].OBS.ToUpper().Trim().Replace(" ", null) != enderecoCliente.OBS.ToUpper().Trim().Replace(" ", null))
			//				{
			//					EnderecoCliente enderecoCliente2 = tempA[tempEnd.id];
			//					enderecoCliente2.OBS = enderecoCliente2.OBS + " - " + enderecoCliente.OBS;
			//				}
			//				((DadosClienteManipulacao)model.DADOSCLIENTE).ID_ENDERECO = tempA[tempEnd.id].ID_INDEX;
			//				await _eterDb.DbEndereco.UpdateEndereco(tempA[tempEnd.id]);
			//			}
			//		}
			//		else
			//		{
			//			DadosClienteManipulacao dadosClienteManipulacao2 = (DadosClienteManipulacao)model.DADOSCLIENTE;
			//			dadosClienteManipulacao2.ID_CLIENTE = await _eterDb.DbCliente.CreateCliente(dadosCliente);
			//			enderecoCliente.ID_CLIENTE = ((DadosClienteManipulacao)model.DADOSCLIENTE).ID_CLIENTE;
			//			DadosClienteManipulacao dadosClienteManipulacao3 = (DadosClienteManipulacao)model.DADOSCLIENTE;
			//			dadosClienteManipulacao3.ID_ENDERECO = await _eterDb.DbEndereco.CreateEndereco(enderecoCliente);
			//		}
			//		if (edit)
			//		{
			//			await _eterDb.DbManipuladosMedicamentos.DeleteMedicamento(model.ID.ToString());
			//			await _eterDb.DbManipulados.UpdateManipulacao(model);
			//			for (int i = 0; i < ((List<string>)model.MEDICAMENTO).Count; i++)
			//			{
			//				await _eterDb.DbManipuladosMedicamentos.CreateMedicamento(((List<string>)model.MEDICAMENTO)[i], model.ID.ToString());
			//			}
			//		}
			//		else
			//		{
			//			long? tempCM = await _eterDb.DbManipulados.CreateManipulacao(model);
			//			for (int i = 0; i < ((List<string>)model.MEDICAMENTO).Count; i++)
			//			{
			//				await _eterDb.DbManipuladosMedicamentos.CreateMedicamento(((List<string>)model.MEDICAMENTO)[i], tempCM.ToString());
			//			}
			//		}
			//		return true;
			//	}
			//	catch (Exception ex2)
			//	{
			//		Exception ex = ex2;
			//		ex.ErrorGet();
			//	}
			return false;
		}

		//private async Task<(bool exist, int id)> ExistAdressC(EnderecoCliente enderecoCliente)
		//{
		//	List<EnderecoCliente> tempA = (List<EnderecoCliente>)(await _eterDb.DbEndereco.GetEndereco(enderecoCliente.ID_CLIENTE.ToString()));
		//	for (int i = 0; i < tempA.Count; i++)
		//	{
		//		if (tempA[i].LOGRADOURO.ToUpper().Trim().Replace(" ", null) == enderecoCliente.LOGRADOURO.ToUpper().Trim().Replace(" ", null))
		//		{
		//			return (exist: true, id: i);
		//		}
		//	}
		//	return (exist: false, id: -1);
		//}

		//private async Task<DadosCliente> ExistCliente(DadosCliente dadosCliente, bool exist)
		//{
		//	if (exist)
		//	{
		//		List<DadosCliente> aex = await _eterDb.DbCliente.GetCliente(dadosCliente.ID.ToString(), TypeDoc.ID);
		//		return (aex.Count > 0) ? aex[0] : null;
		//	}
		//	List<DadosCliente> a1 = await _eterDb.DbCliente.GetCliente(dadosCliente.CPF, TypeDoc.CPF);
		//	List<DadosCliente> a2 = await _eterDb.DbCliente.GetCliente(dadosCliente.RG, TypeDoc.RG);
		//	return (a1.Count > 0) ? a1[0] : ((a2.Count > 0) ? a2[0] : null);
		//}

		//public async Task<object> GetCliente(string id)
		//{
		//	List<DadosCliente> dadosCliente = await _eterDb.DbCliente.GetCliente(id);
		//	for (int i = 0; i < dadosCliente.Count; i++)
		//	{
		//		DadosCliente dadosCliente2 = dadosCliente[i];
		//		dadosCliente2.ENDERECO = await _eterDb.DbEndereco.GetEndereco(dadosCliente[i].ID.ToString());
		//	}
		//	return dadosCliente;
		//}



		//public async Task<bool> DeleteManipulacao(string id)
		//{
		//	return await _eterDb.DbManipulados.DeleteManipulacao(id);
		//}

		//public async Task<List<ManipulacaoModel>> GetAllManip()
		//{
		//	List<ManipulacaoModel> manipulacaoModels = await _eterDb.DbManipulados.GetManipulacao();
		//	for (int i = 0; i < manipulacaoModels.Count; i++)
		//	{
		//		DadosClienteManipulacao dadosCliente = (DadosClienteManipulacao)manipulacaoModels[i].DADOSCLIENTE;
		//		DadosCliente dt = _eterDb.DbCliente.GetCliente(dadosCliente.ID_CLIENTE.ToString()).Result[0];
		//		dt.ENDERECO = _eterDb.DbEndereco.GetEndereco(dadosCliente.ID_ENDERECO.ToString(), id: true).Result;
		//		manipulacaoModels[i].DADOSCLIENTE = dt;
		//		ManipulacaoModel manipulacaoModel = manipulacaoModels[i];
		//		manipulacaoModel.MEDICAMENTO = await _eterDb.DbManipuladosMedicamentos.GetMedicamento(manipulacaoModels[i].ID.ToString());
		//	}
		//	return manipulacaoModels;
		//}
	}
}
