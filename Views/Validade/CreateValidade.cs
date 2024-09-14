using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro.Views.Validade
{
	public partial class CreateValidade : Form
	{
		public CreateValidade()
		{
			InitializeComponent();
		}

		private void CreateValidade_Load(object sender, EventArgs e)
		{

		}

		private void toolStripButton_exit_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Deseja sair o formulário ?", base.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.Close();
			}
		}
	}
}
