using EterPharmaPro.Models;
using EterPharmaPro.Services.DbProdutos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro.DbProdutos.Services
{
	public class DatabaseProdutosDb
	{
		public delegate void DatabaseProdutosLoadedEventHandler(bool complet);

		public ToolStripProgressBar _progressBar;

		public List<ProdutosModel> produtos;

		//public List<PriceProdutoModel> priceProdutoModels;

		public bool Await { get; private set; }

		public event DatabaseProdutosLoadedEventHandler DatabaseProdutosLoaded;

		public DatabaseProdutosDb(ref ToolStripProgressBar progressBar)
		{
			Await = false;
			_progressBar = progressBar;
			Init();
		}

		private async void Init()
		{
			Await = true;
			//Task.Run(() => priceProdutoModels = ReadDb.ReadProdutosPrice());
			await Task.Run(() => produtos = ActionBinary.ReadProdutos(ref _progressBar));
			Await = false;
			OnDatabaseLoaded();
		}

		protected virtual void OnDatabaseLoaded()
		{
			this.DatabaseProdutosLoaded?.Invoke(complet: true);
		}
		public string ReturnNameProduto(string cod)
		{
			string ret = produtos.Find((ProdutosModel x) => x.EAN.Contains(cod.Trim()))?.DESCRICAO_PRODUTO;
			if (ret == null)
			{
				ret = produtos.Find((ProdutosModel x) => x.COD_PRODUTO.Contains(cod.Trim())).DESCRICAO_PRODUTO;
			}
			return ret;
		}
	}
}
