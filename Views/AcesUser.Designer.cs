namespace EterPharmaPro.Views
{
	partial class AcesUser
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcesUser));
			this.comboBox_user = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.textBox_pass = new System.Windows.Forms.TextBox();
			this.groupBox_pass = new System.Windows.Forms.GroupBox();
			this.ePictureBox_acess = new EterPharmaPro.Utils.eControl.ePictureBox();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox_pass.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ePictureBox_acess)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBox_user
			// 
			this.comboBox_user.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.comboBox_user.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comboBox_user.Dock = System.Windows.Forms.DockStyle.Top;
			this.comboBox_user.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBox_user.FormattingEnabled = true;
			this.comboBox_user.Location = new System.Drawing.Point(3, 16);
			this.comboBox_user.Name = "comboBox_user";
			this.comboBox_user.Size = new System.Drawing.Size(328, 34);
			this.comboBox_user.TabIndex = 1;
			this.comboBox_user.Text = " ";
			this.comboBox_user.SelectedIndexChanged += new System.EventHandler(this.comboBox_user_SelectedIndexChanged);
			this.comboBox_user.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox_user_KeyDown);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Controls.Add(this.groupBox_pass);
			this.groupBox1.Controls.Add(this.comboBox_user);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(334, 216);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "USUÁRIO";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.ePictureBox_acess);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(3, 107);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(328, 108);
			this.panel1.TabIndex = 3;
			// 
			// textBox_pass
			// 
			this.textBox_pass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox_pass.Dock = System.Windows.Forms.DockStyle.Top;
			this.textBox_pass.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_pass.Location = new System.Drawing.Point(3, 16);
			this.textBox_pass.Name = "textBox_pass";
			this.textBox_pass.PasswordChar = '*';
			this.textBox_pass.Size = new System.Drawing.Size(322, 33);
			this.textBox_pass.TabIndex = 1;
			this.textBox_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_pass_KeyDown);
			// 
			// groupBox_pass
			// 
			this.groupBox_pass.Controls.Add(this.textBox_pass);
			this.groupBox_pass.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox_pass.Location = new System.Drawing.Point(3, 50);
			this.groupBox_pass.Name = "groupBox_pass";
			this.groupBox_pass.Size = new System.Drawing.Size(328, 57);
			this.groupBox_pass.TabIndex = 2;
			this.groupBox_pass.TabStop = false;
			this.groupBox_pass.Text = "SENHA";
			this.groupBox_pass.Visible = false;
			// 
			// ePictureBox_acess
			// 
			this.ePictureBox_acess.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ePictureBox_acess.Image = global::EterPharmaPro.Properties.Resources.acesso;
			this.ePictureBox_acess.Location = new System.Drawing.Point(110, 3);
			this.ePictureBox_acess.Name = "ePictureBox_acess";
			this.ePictureBox_acess.Size = new System.Drawing.Size(100, 100);
			this.ePictureBox_acess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ePictureBox_acess.TabIndex = 4;
			this.ePictureBox_acess.TabStop = false;
			this.ePictureBox_acess.ToolTipText = "Clique aqui para acessar com sua ID de loja";
			this.ePictureBox_acess.Click += new System.EventHandler(this.ePictureBox_acess_Click);
			// 
			// AcesUser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 216);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AcesUser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Acesso de Usuário";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AcesUser_FormClosing);
			this.Load += new System.EventHandler(this.AcesUser_LoadAsync);
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.groupBox_pass.ResumeLayout(false);
			this.groupBox_pass.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ePictureBox_acess)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox_user;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel1;
		private Utils.eControl.ePictureBox ePictureBox_acess;
		private System.Windows.Forms.GroupBox groupBox_pass;
		private System.Windows.Forms.TextBox textBox_pass;
	}
}