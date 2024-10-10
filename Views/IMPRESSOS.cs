﻿using EterPharmaPro.DbProdutos.Services;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Utils.Extencions;
using EterPharmaPro.Views.LoteControlado;
using System;
using System.Windows.Forms;

namespace EterPharmaPro.Views
{
	public partial class IMPRESSOS : Form
	{
		private readonly IEterDb eterDb;
		private readonly DatabaseProdutosDb databaseProdutosDb;
		public IMPRESSOS(IEterDb _eterDb, DatabaseProdutosDb _databaseProdutosDb)
		{
			this.eterDb = _eterDb;
			this.databaseProdutosDb = _databaseProdutosDb;
			InitializeComponent();
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
			}
			catch (Exception ex)
			{
				ex.ErrorGet();

			}
		}

		private void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			//throw new NotImplementedException();
		}

		private void toolStripButton_exit_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Deseja sair ?", base.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.Close();
			}
		}


		private void lOTEVALIDAEToolStripMenuItem_Click_1(object sender, EventArgs e) => OpenForm(new CreateLoteControlados(eterDb, databaseProdutosDb));
	}
}