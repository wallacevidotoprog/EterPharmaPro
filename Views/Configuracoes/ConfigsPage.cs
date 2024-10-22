using EterPharmaPro.Controllers.Configs;
using EterPharmaPro.DbProdutos.Services;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Windows.Forms;

namespace EterPharmaPro.Views.Configuracoes
{
	public partial class ConfigsPage : Form
	{
		private ConfigsPageController configController;
		public ConfigsPage(IEterDb eterDb, DatabaseProdutosDb databaseProdutosDb)
		{
			InitializeComponent();
			configController = new ConfigsPageController(eterDb, databaseProdutosDb);

		}

		private void toolStripButton_exit_Click(object sender, EventArgs e) => this.Close();

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

		private void toolStripDropDownButton_produto_Click(object sender, EventArgs e) => OpenForm(new Produtos(configController));

		private void ConfigsPage_Load(object sender, EventArgs e)
		{

		}


	}
}
