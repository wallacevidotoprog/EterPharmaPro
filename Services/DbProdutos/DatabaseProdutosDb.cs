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
		CancellationToken cancellationToken;


		private bool Await;

		public event DatabaseProdutosLoadedEventHandler DatabaseProdutosLoaded;

		public DatabaseProdutosDb(ToolStripProgressBar progressBar, CancellationToken cancellationToken)
		{
			Await = false;
			_progressBar = progressBar;
			this.cancellationToken = cancellationToken;
			Init(cancellationToken);
		}

		private void Init(CancellationToken cancellationToken)
		{
			Await = true;
			produtos = ActionBinary.ReadProdutos(_progressBar, cancellationToken);
			Await = false;
			OnDatabaseLoaded();
		}

		public void Refresh() => Init(cancellationToken);

		public bool CheckingLoad()
		{
			if (Await) { MessageBox.Show("Aguarde o carregamento total de todos os PRODUTOS.\n Mais informações no todapé da aplicação.");}
			return !Await;
		}

		protected virtual void OnDatabaseLoaded()
		{
			this.DatabaseProdutosLoaded?.Invoke(complet: true);
		}
	}
}
