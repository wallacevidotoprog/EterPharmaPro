using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.DbProdutos.Services;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

		public async Task<long> CreateNewDocVality(SetValityModel model)
		{
			using (var connection = new SQLiteConnection(eterDb.DatabaseConnection))
			{
				await connection.OpenAsync().ConfigureAwait(false);
				using (var transaction = connection.BeginTransaction())
				{
					try
					{
						long tempIdV = await eterDb.DbValidade.CreateVality(new ValidadeDbModal { USER_ID = model.user_id, DATE = model.dataCreate }, connection, transaction);

						transaction.Commit();
						return tempIdV;
					}
					catch (Exception ex)
					{
						transaction.Rollback();
						ex.ErrorGet();
						return -1;
					}
				}
			}
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

		public async Task<(bool,long)> CreateProdutoVality(ProdutoSetValityModel produtoSetValityModel)
		{
			throw new NotImplementedException();
		}

		public async Task<List<CategoriaDbModal>> GetCategoryUser(int user_id)
		{
			return await eterDb.DbCategoria.GetCategory(user_id.ToString());
		}

		internal async Task<bool> UpdateProdutoVality(ProdutoSetValityModel produto)
		{
			throw new NotImplementedException();
		}
	}
}
