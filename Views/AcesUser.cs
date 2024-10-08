using EterPharmaPro.Interfaces;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Windows.Forms;

namespace EterPharmaPro.Views
{
	public partial class AcesUser : Form
	{
		public bool loginSucced = false;
		readonly IEterDb eterDb;
		public AcesUser(IEterDb eterDb)
		{
			this.eterDb = eterDb;
			InitializeComponent();
			this.Size = new System.Drawing.Size(722, 200);
		}

		private async void ePictureBox_acess_Click(object sender, EventArgs e)
		{
			string pass = groupBox_pass.Visible == true ? textBox_pass.Text : null;

			var temp = await eterDb.Login(comboBox_user.SelectedValue.ToString(), pass);
			if (temp.acPass)
			{
				groupBox_pass.Visible = true;
				textBox_pass.Focus();
				this.Size = new System.Drawing.Size(722, 255);
				return;
			}
			if (temp.acOk)
			{
				loginSucced = true;
				this.Close();
			}
		}

		private void AcesUser_Load(object sender, EventArgs e)
		{
			comboBox_user.Invoke((Action)async delegate
			{
				await comboBox_user.CBListUserAsync(eterDb,true);
			});
		}

		private void comboBox_user_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				ePictureBox_acess_Click(null, null);
			}
		}

		private void textBox_pass_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				ePictureBox_acess_Click(null, null);
			}
		}
	}
}
