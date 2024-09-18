using EterPharmaPro.Models;
using EterPharmaPro.Services.DbProdutos;
using System;
using System.Collections.Generic;
using System.Threading;
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

		private bool Await;

		public event DatabaseProdutosLoadedEventHandler DatabaseProdutosLoaded;

		public DatabaseProdutosDb(ToolStripProgressBar progressBar, CancellationToken cancellationToken)
		{
			Await = false;
			_progressBar = progressBar;
			Init(cancellationToken);
		}

		private async void Init(CancellationToken cancellationToken)
		{
			Await = true;
			//Task.Run(() => priceProdutoModels = ReadDb.ReadProdutosPrice());
			produtos = await ActionBinary.ReadProdutosAsync(_progressBar, cancellationToken);
			Await = false;
			OnDatabaseLoaded();
		}

		public bool CheckingLoad()
		{
			if (Await) { MessageBox.Show("Aguarde o carregamento total de todos os PRODUTOS.\n Mais informações no todapé da aplicação.");}
			return !Await;
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
