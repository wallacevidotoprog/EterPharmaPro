using DocumentFormat.OpenXml.Office2016.Excel;
using EterPharmaPro.DbProdutos.Services;
using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Controllers.Configs
{
	public class ConfigsPageController
	{
		private readonly IEterDb eterDb;
		private readonly DatabaseProdutosDb databaseProdutosDb;
		public ConfigsPageController(IEterDb eterDb, DatabaseProdutosDb databaseProdutosDb)
		{
			this.eterDb = eterDb;
			this.databaseProdutosDb = databaseProdutosDb;
		}

		public List<ProdutosModel> GetAllProdutos() => databaseProdutosDb.produtos;

		public List<ProdutosModel> GetProdutos(object query, QueryProdutoEnum queryProdutoEnum)
		{
			if (string.IsNullOrEmpty(query.ToString()))
			{
				return databaseProdutosDb.produtos;
			}
			List<ProdutosModel> temp = null;

			switch (queryProdutoEnum)
			{
				case QueryProdutoEnum.EAN:
					temp = databaseProdutosDb.produtos.Where(p => p.EAN == (string)query).ToList();
					break;
				case QueryProdutoEnum.COD_INTERNO:
					temp = databaseProdutosDb.produtos.Where(p => p.COD_PRODUTO == (string)query).ToList();
					break;
				case QueryProdutoEnum.DESCRICAO:
					temp = databaseProdutosDb.produtos.Where(p => p.DESCRICAO_PRODUTO.Contains((string)query)).ToList();
					break;
				case QueryProdutoEnum.LABORATORIO:
					temp = databaseProdutosDb.produtos.Where(p => p.LABORATORIO.Contains((string)query)).ToList();
					break;
				case QueryProdutoEnum.GRUPO:
					temp = databaseProdutosDb.produtos.Where(p => p.GRUPO.Contains((string)query)).ToList();
					break;
			}

			return temp;
		}

		public void RefreshProd() => databaseProdutosDb.Refresh();
	}
}
