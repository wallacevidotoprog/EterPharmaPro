using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using EterPharmaPro.Views.Manipulados;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro
{
	public partial class MainWindow : Form
	{
		private readonly IEterDb eterDb;
		public MainWindow()
		{
			InitializeComponent();
			eterDb = new EterDb();
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
				toolStrip1.Visible = false;
			}
			catch (Exception ex)
			{
				ex.ErrorGet();

			}
		}

		private void ChildForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			toolStrip1.Visible = true;
		}

		private async void toolStripButton2_Click(object sender, EventArgs e)
		{
			//var t = await eterDb.DbUser.GetUser();
			//var t1 = await eterDb.DbUser.GetUser("5", QueryUserEnum.ID);
			//var t2 = await eterDb.DbUser.GetUser("1504", QueryUserEnum.ID_LOJA);
		}

		private void fORMUToolStripMenuItem_Click(object sender, EventArgs e) => OpenForm(new CreateManipulados(eterDb));
	}
}
