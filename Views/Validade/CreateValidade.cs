using EterPharmaPro.Controllers.Validade;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EterPharmaPro.Views.Validade
{
	public partial class CreateValidade : Form
	{
		private readonly IEterDb eterDb;
		private readonly ValidadeController validadeController;


		bool isActionValidade = false;


		public CreateValidade(IEterDb _eterDb)
		{
			InitializeComponent();
			eterDb = _eterDb;
			validadeController = new ValidadeController(eterDb);
		}

		private void CreateValidade_Load(object sender, EventArgs e)
		{
			comboBox_user.Invoke((Action)delegate
			{
				comboBox_user.CBListUser(eterDb);
			});
		}

		private void toolStripButton_exit_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Deseja sair o formulário ?", base.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.Close();
			}
		}

		private void VisibleHeaderDoc(bool state)
		{
			groupBox_ne.Visible = state;
			comboBox_user.Enabled = state;
			dateTimePicker_dataD.Enabled = state;
			dateTimePicker_dataD.Value = DateTime.Today;


			groupBox_ne.Size = state ? new Size(566, 88) : new Size(566, 315);
			comboBox_user.Enabled = state;
			dateTimePicker_dataD.Enabled = state;
		}

		private void VisibleBodyDoc(bool state)
		{
			groupBox_ne.Size = state ? new Size(566, 315) : new Size(566, 88);
			groupBox_insert.Visible = state;
			comboBox_user.Enabled = !state;
			dateTimePicker_dataD.Enabled = !state;
		}


		private void NewDocValidade(bool stats)
		{
			VisibleHeaderDoc(stats);
			VisibleBodyDoc(!stats);
		}

		private void toolStripDropDownButton_new_Click(object sender, EventArgs e)
		{
			if (isActionValidade)
			{
				if (MessageBox.Show("Existe um arquivo aberto, deseja fecha-lo ?\n(As alterações serão salvas)", "ALERTA", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel)
				{

				}
			}
			NewDocValidade(true);
		}

		private void ePictureBox_create_Click(object sender, EventArgs e)
		{
			VisibleBodyDoc(true);
			isActionValidade = true;
		}
	}
}
