using EterPharmaPro.Models;
using EterPharmaPro.Services;
using EterPharmaPro.Services.DbProdutos;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro.DbProdutos.Services
{
	public class DatabaseProdutosDb
	{
		public delegate void DatabaseProdutosLoadedEventHandler(bool complet);

		public ToolStripProgressBar _progressBar;
		private FileSystemWatcher _fileSystemWatcher;
		private DateTime _lastReadTime;
		private IniFile ini;

		public List<ProdutosModel> produtos;
		CancellationToken cancellationToken;


		private bool Await;

		public event DatabaseProdutosLoadedEventHandler DatabaseProdutosLoaded;

		public DatabaseProdutosDb(ToolStripProgressBar progressBar, CancellationToken cancellationToken)
		{
			try
			{
				ini = new IniFile("config.ini");
				//InitWatch();
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			
			Await = false;
			_progressBar = progressBar;
			this.cancellationToken = cancellationToken;
			Init(cancellationToken);
		}

		private void InitWatch()
		{
			_fileSystemWatcher = new FileSystemWatcher(ini.Read("IMPORTPRODUT", "FILE_WATCH"));
			_fileSystemWatcher.Filter = "*.xlsx";
			_fileSystemWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size;
			_fileSystemWatcher.EnableRaisingEvents = true;

			_fileSystemWatcher.Changed += _fileSystemWatcher_Changed;
			_fileSystemWatcher.Created += _fileSystemWatcher_Changed;
		}

		private void _fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
		{
			if (e.Name.StartsWith(ini.Read("IMPORTPRODUT", "FILENAME_WATCH")))
			{
				MessageBox.Show(e.FullPath);
			}
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
			if (Await) { MessageBox.Show("Aguarde o carregamento total de todos os PRODUTOS.\n Mais informações no todapé da aplicação."); }
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
