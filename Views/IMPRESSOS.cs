using EterPharmaPro.Controllers;
using EterPharmaPro.DbProdutos.Services;
using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Utils.Extencions;
using EterPharmaPro.Views.LoteControlado;
using EterPharmaPro.Views.Remanejo;
using EterPharmaPro.Views.ReqNota;
using System;
using System.Windows.Forms;

namespace EterPharmaPro.Views
{
	public partial class IMPRESSOS : Form
	{
		private readonly IEterDb eterDb;
		private readonly DatabaseProdutosDb databaseProdutosDb;
		private readonly PermissoesController permissoesController;
		public IMPRESSOS(IEterDb _eterDb, DatabaseProdutosDb _databaseProdutosDb)
		{
			this.eterDb = _eterDb;
			this.databaseProdutosDb = _databaseProdutosDb;
			InitializeComponent();

		//atualizar para setout
			permissoesController = new PermissoesController(new PermissionsEnum[] { PermissionsEnum.Dev,PermissionsEnum.Admin,PermissionsEnum.Supervisor,PermissionsEnum.Gerente });

			toolStripDropDownButton_gerencial.Visible = permissoesController.HasPermission(eterDb.EterDbController.UserModelAcess.PERMISSION);

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
			
		}

		private void toolStripButton_exit_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Deseja sair ?", base.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.Close();
			}
		}


		private void lOTEVALIDAEToolStripMenuItem_Click_1(object sender, EventArgs e) => OpenForm(new CreateLoteControlados(eterDb, databaseProdutosDb));

		private void toolStripMenuItem_remanejo_Click(object sender, EventArgs e) => OpenForm(new RemanejoPrint());

		private void IMPRESSOS_Load(object sender, EventArgs e)
		{
		}

		private void cONTROLEDEREQNOTAToolStripMenuItem_Click(object sender, EventArgs e) => OpenForm(new ControleReqNota(eterDb));
		
	}
}
