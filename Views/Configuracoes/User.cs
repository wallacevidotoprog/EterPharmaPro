using EterPharmaPro.Controllers.Configs;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Properties;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro.Views.Configuracoes
{

	public partial class User : Form
	{
		private bool isNew = false;
		private bool isEdit;
		UserModel userModel = null;

		private readonly ConfigsPageController configsPageController;
		public User(ConfigsPageController configsPageController)
		{
			this.configsPageController = configsPageController;
			InitializeComponent();
		}
		private void OpenSaveUp()
		{
			toolStripButton_new_save.Image = Resources.salve;
			toolStripButton_cancel.Visible = true;
			groupBox_create.Visible = true;
			toolStripButton_send.Visible = false;
		}

		private void ClearFieldReq()
		{
			groupBox_create.Visible = false;
		}
		private async void toolStripButton_new_save_Click(object sender, EventArgs e)
		{
			if (!isNew && !isEdit)
			{
				OpenSaveUp();
				isNew = true;
			}
			else
			{
				userModel = userModel ?? new UserModel();
				
				userModel.ID_LOJA = Convert.ToUInt32(textBox_id.Text.ReturnInt());
				userModel.NOME = textBox_nome.Text.ToUpper();
				userModel.PASS = string.IsNullOrEmpty(textBox_pass.Text) ? null : textBox_pass.Text;
				userModel.FUNCAO = Convert.ToInt32(comboBox_funcao.SelectedValue);
				userModel.STATUS = eSwitchControl_stats.Checked;


				if (isEdit)
				{
					if (await configsPageController.UpdateUser(userModel))
					{
						toolStripButton_cancel_Click(null, null);
						return;
					}
				}
				if (await configsPageController.CreateUser(userModel))
				{
					toolStripButton_cancel_Click(null, null);
					return;
				}
			}
		}

		private void toolStripButton_cancel_Click(object sender, EventArgs e)
		{
			userModel = null;
			toolStripButton_new_save.Image = Resources.documento_new;
			toolStripButton_cancel.Visible = false;
			toolStripButton_send.Visible = true;
			ClearFieldReq();
			isNew = false;
			isEdit = false;
		}

		private async void User_Load(object sender, EventArgs e)
		{
			comboBox_funcao.CBListUserFuncao(await configsPageController.GetAllFuncao());
			dataGridView_user.DataSource = await configsPageController.GetAllUser();
		}
	}
}
