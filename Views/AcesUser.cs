using EterPharmaPro.Interfaces;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro.Views
{
	public partial class AcesUser : Form
	{
		readonly IEterDb eterDb;
		private readonly List<UserModel> userModels;
		public bool loginSucced = false;

		private Timer timer;
		private int targetY;
		private const int animationStep = 20;
		private bool pClose = false;


		public AcesUser(IEterDb eterDb)
		{
			userModels = eterDb.DbUser.GetUser(new QueryWhereModel()).Result;
			timer = new Timer();
			timer.Interval = 15;
			timer.Tick += Timer_Tick;

			this.eterDb = eterDb;
			InitializeComponent();
			this.Size = new System.Drawing.Size(350, 200);
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			if (this.Top > targetY)
			{

				this.Top -= animationStep;


				if (this.Top <= targetY)
				{
					pClose = true;
					this.Close();
					timer.Stop();
				}
			}
		}

		private async void ePictureBox_acess_Click(object sender, EventArgs e)
		{
			string pass = groupBox_pass.Visible == true ? textBox_pass.Text : null;

			var temp = await eterDb.Login(comboBox_user.SelectedValue.ToString(), pass);
			if (temp.acPass)
			{
				groupBox_pass.Visible = true;
				textBox_pass.Focus();
				this.Size = new System.Drawing.Size(350, 255);
				return;
			}
			if (temp.acOk)
			{
				loginSucced = true;
				this.Close();
			}
		}

		private async void AcesUser_LoadAsync(object sender, EventArgs e)
		{
			await comboBox_user.CBListUserAsync(eterDb, true);
			comboBox_user.SelectedIndex = 0;
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

		private void AcesUser_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!pClose)
			{
				targetY = this.Top - 255 - 200;
				timer.Start();
				e.Cancel = true;
			}


		}

		private void comboBox_user_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				var temp = userModels.FirstOrDefault(x => x.ID == Convert.ToUInt32(comboBox_user?.SelectedValue?.ToString()));
				if (temp == null) { return; }
				if (temp.PASS == string.Empty)
				{
					this.Size = new System.Drawing.Size(350, 200);
					groupBox_pass.Visible = false;
				}
				else
				{
					groupBox_pass.Visible = true;
					this.Size = new System.Drawing.Size(350, 255);
				}
			}
			catch (Exception ex)
			{
				//ex.ErrorGet(false);
			}


		}
	}
}
