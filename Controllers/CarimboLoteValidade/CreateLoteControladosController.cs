using EterPharmaPro.DbProdutos.Services;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Controllers.CarimboLoteValidade
{
	public class CreateLoteControladosController
	{
		private readonly IEterDb eterDb;
		private readonly DatabaseProdutosDb databaseProdutosDb;

		public bool inLoadProd =true;

		public CreateLoteControladosController(IEterDb eterDb, DatabaseProdutosDb databaseProdutosDb)
		{
			this.eterDb = eterDb;
			this.databaseProdutosDb = databaseProdutosDb;

			databaseProdutosDb.DatabaseProdutosLoaded += DatabaseProdutosLoaded;

		}

		public List<ProdutosModel> GetAllProdutos()
		{
			if (!databaseProdutosDb.CheckingLoad())
			{
				return null;
			}

			return databaseProdutosDb.produtos;
		}
		public bool CheckingLoadDbProd() => !databaseProdutosDb.CheckingLoad();
		public ProdutosModel GetProduto(string cod_produt)
		{
			if (!databaseProdutosDb.CheckingLoad())
			{
				return null;
			}
			return (cod_produt.Trim().Length >= 7) ?
				databaseProdutosDb.produtos.FirstOrDefault((ProdutosModel x) => x.EAN.Contains(cod_produt.Trim())) :
				databaseProdutosDb.produtos.FirstOrDefault((ProdutosModel x) => x.COD_PRODUTO.Contains(cod_produt.Trim().Replace(" ", null).PadLeft(6, '0')));
		}

		public async Task<ClienteModel> GetCliente(string value)
		{
			ClienteModel tempCliente = (await eterDb.DbCliente.GetCliente(new QueryWhereModel().SetWhere("RG", value))).FirstOrDefault();
			if(tempCliente is null)
			{
				return null;
			}
			tempCliente.ENDERECO = await eterDb.DbEndereco.GetEndereco(new QueryWhereModel().SetWhere("CLIENTE_ID", tempCliente.ID));

			return tempCliente;
		}

		private void DatabaseProdutosLoaded(bool complet) => inLoadProd = !complet;
	}
}
