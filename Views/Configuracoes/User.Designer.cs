namespace EterPharmaPro.Views.Configuracoes
{
	partial class User
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
			this.toolStrip_topMenu = new System.Windows.Forms.ToolStrip();
			this.toolStripButton_send = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_new_save = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_cancel = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.groupBox_create = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBox_funcao = new System.Windows.Forms.ComboBox();
			this.textBox_id = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox_pass = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_nome = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.dataGridView_user = new System.Windows.Forms.DataGridView();
			this.dataGridViewCheckBoxImageColumn1 = new EterPharmaPro.Utils.Extencions.DataGridViewCheckBoxImageColumn();
			this.eSwitchControl_stats = new EterPharmaPro.Utils.eControl.eSwitchControl();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ID_LOJA = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.stats = new EterPharmaPro.Utils.Extencions.DataGridViewCheckBoxImageColumn();
			this.toolStrip_topMenu.SuspendLayout();
			this.groupBox_create.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_user)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip_topMenu
			// 
			this.toolStrip_topMenu.BackColor = System.Drawing.Color.WhiteSmoke;
			this.toolStrip_topMenu.Dock = System.Windows.Forms.DockStyle.Right;
			this.toolStrip_topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_send,
            this.toolStripButton_new_save,
            this.toolStripButton_cancel,
            this.toolStripSeparator1});
			this.toolStrip_topMenu.Location = new System.Drawing.Point(909, 0);
			this.toolStrip_topMenu.Name = "toolStrip_topMenu";
			this.toolStrip_topMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.toolStrip_topMenu.Size = new System.Drawing.Size(91, 583);
			this.toolStrip_topMenu.TabIndex = 9;
			this.toolStrip_topMenu.Text = "toolStrip1";
			// 
			// toolStripButton_send
			// 
			this.toolStripButton_send.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton_send.AutoSize = false;
			this.toolStripButton_send.Font = new System.Drawing.Font("Segoe UI", 7F);
			this.toolStripButton_send.Image = global::EterPharmaPro.Properties.Resources.inserir;
			this.toolStripButton_send.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_send.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton_send.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_send.Name = "toolStripButton_send";
			this.toolStripButton_send.Size = new System.Drawing.Size(90, 90);
			this.toolStripButton_send.Tag = "";
			this.toolStripButton_send.Text = "ENVIAR";
			this.toolStripButton_send.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_send.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripButton_send.ToolTipText = "Marcar como enviado";
			// 
			// toolStripButton_new_save
			// 
			this.toolStripButton_new_save.AutoSize = false;
			this.toolStripButton_new_save.Font = new System.Drawing.Font("Segoe UI", 7F);
			this.toolStripButton_new_save.Image = global::EterPharmaPro.Properties.Resources.documento_new;
			this.toolStripButton_new_save.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_new_save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton_new_save.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_new_save.Name = "toolStripButton_new_save";
			this.toolStripButton_new_save.Size = new System.Drawing.Size(90, 90);
			this.toolStripButton_new_save.Tag = "";
			this.toolStripButton_new_save.Text = "NOVO";
			this.toolStripButton_new_save.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_new_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripButton_new_save.ToolTipText = " ";
			this.toolStripButton_new_save.Click += new System.EventHandler(this.toolStripButton_new_save_Click);
			// 
			// toolStripButton_cancel
			// 
			this.toolStripButton_cancel.AutoSize = false;
			this.toolStripButton_cancel.Font = new System.Drawing.Font("Segoe UI", 7F);
			this.toolStripButton_cancel.Image = global::EterPharmaPro.Properties.Resources.cancelar;
			this.toolStripButton_cancel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_cancel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton_cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_cancel.Name = "toolStripButton_cancel";
			this.toolStripButton_cancel.Size = new System.Drawing.Size(90, 90);
			this.toolStripButton_cancel.Tag = "";
			this.toolStripButton_cancel.Text = "CANCELAR";
			this.toolStripButton_cancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripButton_cancel.ToolTipText = "Cancelar";
			this.toolStripButton_cancel.Visible = false;
			this.toolStripButton_cancel.Click += new System.EventHandler(this.toolStripButton_cancel_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(88, 6);
			// 
			// groupBox_create
			// 
			this.groupBox_create.Controls.Add(this.label2);
			this.groupBox_create.Controls.Add(this.eSwitchControl_stats);
			this.groupBox_create.Controls.Add(this.label3);
			this.groupBox_create.Controls.Add(this.comboBox_funcao);
			this.groupBox_create.Controls.Add(this.textBox_id);
			this.groupBox_create.Controls.Add(this.label6);
			this.groupBox_create.Controls.Add(this.textBox_pass);
			this.groupBox_create.Controls.Add(this.label1);
			this.groupBox_create.Controls.Add(this.textBox_nome);
			this.groupBox_create.Controls.Add(this.label4);
			this.groupBox_create.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox_create.Location = new System.Drawing.Point(0, 0);
			this.groupBox_create.Name = "groupBox_create";
			this.groupBox_create.Size = new System.Drawing.Size(909, 282);
			this.groupBox_create.TabIndex = 25;
			this.groupBox_create.TabStop = false;
			this.groupBox_create.Visible = false;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(810, 213);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 25);
			this.label2.TabIndex = 25;
			this.label2.Text = "STATS:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(6, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 25);
			this.label3.TabIndex = 17;
			this.label3.Text = "ID:";
			// 
			// comboBox_funcao
			// 
			this.comboBox_funcao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox_funcao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_funcao.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBox_funcao.FormattingEnabled = true;
			this.comboBox_funcao.Items.AddRange(new object[] {
            "EAN",
            "COD INTERNO"});
			this.comboBox_funcao.Location = new System.Drawing.Point(11, 236);
			this.comboBox_funcao.Name = "comboBox_funcao";
			this.comboBox_funcao.Size = new System.Drawing.Size(784, 33);
			this.comboBox_funcao.TabIndex = 22;
			// 
			// textBox_id
			// 
			this.textBox_id.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_id.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_id.Location = new System.Drawing.Point(11, 44);
			this.textBox_id.MaxLength = 4;
			this.textBox_id.Name = "textBox_id";
			this.textBox_id.Size = new System.Drawing.Size(893, 33);
			this.textBox_id.TabIndex = 16;
			this.textBox_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(6, 208);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(91, 25);
			this.label6.TabIndex = 23;
			this.label6.Text = "FUNÇÃO";
			// 
			// textBox_pass
			// 
			this.textBox_pass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_pass.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_pass.Location = new System.Drawing.Point(11, 172);
			this.textBox_pass.Name = "textBox_pass";
			this.textBox_pass.PasswordChar = '*';
			this.textBox_pass.Size = new System.Drawing.Size(893, 33);
			this.textBox_pass.TabIndex = 18;
			this.textBox_pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(6, 144);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 25);
			this.label1.TabIndex = 19;
			this.label1.Text = "SENHA:";
			// 
			// textBox_nome
			// 
			this.textBox_nome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_nome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox_nome.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_nome.Location = new System.Drawing.Point(11, 108);
			this.textBox_nome.Name = "textBox_nome";
			this.textBox_nome.Size = new System.Drawing.Size(893, 33);
			this.textBox_nome.TabIndex = 18;
			this.textBox_nome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(6, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(74, 25);
			this.label4.TabIndex = 19;
			this.label4.Text = "NOME:";
			// 
			// dataGridView_user
			// 
			this.dataGridView_user.AllowUserToAddRows = false;
			this.dataGridView_user.AllowUserToDeleteRows = false;
			this.dataGridView_user.AllowUserToResizeColumns = false;
			this.dataGridView_user.AllowUserToResizeRows = false;
			this.dataGridView_user.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView_user.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
			this.dataGridView_user.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dataGridView_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridView_user.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.ID_LOJA,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.stats});
			this.dataGridView_user.Cursor = System.Windows.Forms.Cursors.Hand;
			this.dataGridView_user.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView_user.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.dataGridView_user.Location = new System.Drawing.Point(0, 282);
			this.dataGridView_user.MultiSelect = false;
			this.dataGridView_user.Name = "dataGridView_user";
			this.dataGridView_user.ReadOnly = true;
			this.dataGridView_user.RowHeadersVisible = false;
			this.dataGridView_user.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dataGridView_user.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_user.Size = new System.Drawing.Size(909, 301);
			this.dataGridView_user.TabIndex = 26;
			// 
			// dataGridViewCheckBoxImageColumn1
			// 
			this.dataGridViewCheckBoxImageColumn1.DataPropertyName = "STATS";
			this.dataGridViewCheckBoxImageColumn1.FillWeight = 25F;
			this.dataGridViewCheckBoxImageColumn1.HeaderText = "STATS";
			this.dataGridViewCheckBoxImageColumn1.Name = "dataGridViewCheckBoxImageColumn1";
			this.dataGridViewCheckBoxImageColumn1.Width = 46;
			// 
			// eSwitchControl_stats
			// 
			this.eSwitchControl_stats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.eSwitchControl_stats.AutoSize = true;
			this.eSwitchControl_stats.Checked = true;
			this.eSwitchControl_stats.CheckState = System.Windows.Forms.CheckState.Checked;
			this.eSwitchControl_stats.Cursor = System.Windows.Forms.Cursors.Hand;
			this.eSwitchControl_stats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.eSwitchControl_stats.Location = new System.Drawing.Point(826, 241);
			this.eSwitchControl_stats.MinimumSize = new System.Drawing.Size(45, 22);
			this.eSwitchControl_stats.Name = "eSwitchControl_stats";
			this.eSwitchControl_stats.OffBackColor = System.Drawing.Color.Black;
			this.eSwitchControl_stats.OffToggleColor = System.Drawing.Color.White;
			this.eSwitchControl_stats.OnBackColor = System.Drawing.Color.SeaGreen;
			this.eSwitchControl_stats.OnToggleColor = System.Drawing.Color.White;
			this.eSwitchControl_stats.Size = new System.Drawing.Size(45, 22);
			this.eSwitchControl_stats.TabIndex = 24;
			this.eSwitchControl_stats.UseVisualStyleBackColor = true;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
			this.dataGridViewTextBoxColumn1.FillWeight = 68.96552F;
			this.dataGridViewTextBoxColumn1.HeaderText = "ID";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Width = 43;
			// 
			// ID_LOJA
			// 
			this.ID_LOJA.DataPropertyName = "ID_LOJA";
			this.ID_LOJA.FillWeight = 50F;
			this.ID_LOJA.HeaderText = "ID LOJA";
			this.ID_LOJA.Name = "ID_LOJA";
			this.ID_LOJA.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "NOME";
			this.dataGridViewTextBoxColumn2.FillWeight = 200F;
			this.dataGridViewTextBoxColumn2.HeaderText = "NOME";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.DataPropertyName = "FUNCAO";
			this.dataGridViewTextBoxColumn3.FillWeight = 193.1035F;
			this.dataGridViewTextBoxColumn3.HeaderText = "FUNÇÃO";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			// 
			// stats
			// 
			this.stats.DataPropertyName = "STATS";
			this.stats.FillWeight = 25F;
			this.stats.HeaderText = "STATS";
			this.stats.Name = "stats";
			this.stats.ReadOnly = true;
			// 
			// User
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1000, 583);
			this.Controls.Add(this.dataGridView_user);
			this.Controls.Add(this.groupBox_create);
			this.Controls.Add(this.toolStrip_topMenu);
			this.Name = "User";
			this.Text = "User";
			this.Load += new System.EventHandler(this.User_Load);
			this.toolStrip_topMenu.ResumeLayout(false);
			this.toolStrip_topMenu.PerformLayout();
			this.groupBox_create.ResumeLayout(false);
			this.groupBox_create.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_user)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip_topMenu;
		private System.Windows.Forms.ToolStripButton toolStripButton_send;
		private System.Windows.Forms.ToolStripButton toolStripButton_new_save;
		private System.Windows.Forms.ToolStripButton toolStripButton_cancel;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.GroupBox groupBox_create;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox_funcao;
		private System.Windows.Forms.TextBox textBox_id;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox_nome;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_pass;
		private System.Windows.Forms.Label label1;
		private Utils.eControl.eSwitchControl eSwitchControl_stats;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dataGridView_user;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID_LOJA;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private Utils.Extencions.DataGridViewCheckBoxImageColumn stats;
		private Utils.Extencions.DataGridViewCheckBoxImageColumn dataGridViewCheckBoxImageColumn1;
	}
}