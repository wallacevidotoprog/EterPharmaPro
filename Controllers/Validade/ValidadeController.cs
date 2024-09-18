using EterPharmaPro.DbProdutos.Services;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro.Controllers.Validade
{
	public class ValidadeController
	{
		private readonly IEterDb eterDb;
		private readonly DatabaseProdutosDb databaseProdutosDb;

		private bool isLoadProd=false;
		public ValidadeController(IEterDb _eterDb, DatabaseProdutosDb _databaseProdutosDb)
		{
			eterDb = _eterDb;
			databaseProdutosDb = _databaseProdutosDb;
			databaseProdutosDb.DatabaseProdutosLoaded += DatabaseProdutosLoaded;


		}

		public async Task<(int user_id, DateTime dataCreate, long vality_id)> CreateNewDocVality((int user_id, DateTime dataCreate, long vality_id) autor)
		{
			return (autor.user_id, autor.dataCreate, 0);
		}

		public async Task CreateCategory(int user_id)
		{
			throw new NotImplementedException();
		}

		public async Task DeleteCategory(int user_id)
		{
			throw new NotImplementedException();
		}

		public  List<ProdutosModel> GetAllProdutos()
		{
			if (!databaseProdutosDb.CheckingLoad())
			{
				return null;
			}
			return databaseProdutosDb.produtos;
		}

		private void DatabaseProdutosLoaded(bool complet) => isLoadProd= complet;

		public ProdutosModel GetProduto(string text)
		{
			if (!databaseProdutosDb.CheckingLoad())
			{
				return null;
			}
			return ((text.Trim().Length >= 7) ? databaseProdutosDb.produtos.Find((ProdutosModel x) => x.EAN.Contains(text.Trim())) : databaseProdutosDb.produtos.Find((ProdutosModel x) => x.COD_PRODUTO.Contains(text.Trim().Replace(" ", null).PadLeft(6, '0'))));
		}
	}
}
