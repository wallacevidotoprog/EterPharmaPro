﻿using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.DbProdutos.Services;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using EterPharmaPro.Views.Manipulados;
using EterPharmaPro.Views.Validade;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro
{
	public partial class MainWindow : Form
	{
		private readonly IEterDb eterDb;
		private DatabaseProdutosDb DatabaseProdutosDb;

		private CancellationTokenSource cancellationTokenSource;
		public MainWindow()
		{
			InitializeComponent();
			eterDb = new EterDb();
			cancellationTokenSource = new CancellationTokenSource();
		}
		private void MainWindow_Load(object sender, EventArgs e)
		{
			DatabaseProdutosDb = new DatabaseProdutosDb(toolStripProgressBar_status, cancellationTokenSource.Token);
		}
		private void OpenForm(Form form)
		{
			try
			{
				if (panel_center.Controls.Count > 0)
				{
					panel_center.Controls.RemoveAt(0);
				}
				form.TopLevel = false;
				form.FormBorderStyle = FormBorderStyle.None;
				form.Dock = DockStyle.Fill;

				form.FormClosed += ChildForm_FormClosed;
				panel_center.Controls.Clear();
				panel_center.Controls.Add(form);
				form?.Show();
				toolStrip_menu.Visible = false;
			}
			catch (Exception ex)
			{
				ex.ErrorGet();

			}
		}

		private void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			toolStrip_menu.Visible = true;
		}

		private async void toolStripButton2_Click(object sender, EventArgs e)
		{
			var t = await eterDb.DbManipulados.GetManipulacao();
			var selec = t[1];

			var dc = (DadosClienteManipulacao)selec.DADOSCLIENTE;

			selec.DADOSCLIENTE = (await eterDb.DbCliente.GetCliente(dc.ID_CLIENTE.ToString(), Enums.TypeDoc.ID))[0];
			((ClienteModel)selec.DADOSCLIENTE).ENDERECO = await eterDb.DbEndereco.GetEndereco(dc.ID_ENDERECO.ToString(),Enums.QueryClienteEnum.ID);

			(new CreateManipulados(eterDb, selec)).Show();
		}

		private void fORMUToolStripMenuItem_Click(object sender, EventArgs e) => OpenForm(new CreateManipulados(eterDb));

		private void gERARVALIDADEDOMÊSToolStripMenuItem_Click(object sender, EventArgs e) => OpenForm(new CreateValidade(eterDb, DatabaseProdutosDb));

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (cancellationTokenSource != null)
			{
				cancellationTokenSource.Cancel();
			}
		}
	}
}