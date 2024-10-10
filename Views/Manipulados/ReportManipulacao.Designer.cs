namespace EterPharmaPro.Views.Manipulados
{
	partial class ReportManipulacao
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
			this.components = new System.ComponentModel.Container();
			this.toolStrip_topMenu = new System.Windows.Forms.ToolStrip();
			this.toolStripButton_exit = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_clear = new System.Windows.Forms.ToolStripButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.comboBox_user = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ePictureBox_seach = new EterPharmaPro.Utils.eControl.ePictureBox();
			this.dateTimePicker_dataBusca = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.listView1 = new System.Windows.Forms.ListView();
			this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ATEN_LOJA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DATA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.CLIENTE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.VALORFINAL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.OBSGERAL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.contextMenuStrip_produtos = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.eDITARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.eXCLUIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip_topMenu.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ePictureBox_seach)).BeginInit();
			this.contextMenuStrip_produtos.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip_topMenu
			// 
			this.toolStrip_topMenu.BackColor = System.Drawing.Color.WhiteSmoke;
			this.toolStrip_topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_clear,
            this.toolStripButton_exit});
			this.toolStrip_topMenu.Location = new System.Drawing.Point(0, 0);
			this.toolStrip_topMenu.Name = "toolStrip_topMenu";
			this.toolStrip_topMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.toolStrip_topMenu.Size = new System.Drawing.Size(800, 93);
			this.toolStrip_topMenu.TabIndex = 5;
			this.toolStrip_topMenu.Text = "toolStrip1";
			this.toolStrip_topMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_topMenu_ItemClicked);
			// 
			// toolStripButton_exit
			// 
			this.toolStripButton_exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton_exit.AutoSize = false;
			this.toolStripButton_exit.Font = new System.Drawing.Font("Segoe UI", 7F);
			this.toolStripButton_exit.Image = global::EterPharmaPro.Properties.Resources.sair__1_;
			this.toolStripButton_exit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_exit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton_exit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_exit.Name = "toolStripButton_exit";
			this.toolStripButton_exit.Size = new System.Drawing.Size(90, 90);
			this.toolStripButton_exit.Tag = "SAIR";
			this.toolStripButton_exit.Text = "SAIR";
			this.toolStripButton_exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripButton_exit.ToolTipText = "SAIR";
			// 
			// toolStripButton_clear
			// 
			this.toolStripButton_clear.AutoSize = false;
			this.toolStripButton_clear.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.toolStripButton_clear.Image = global::EterPharmaPro.Properties.Resources.limpar_limpo__1_;
			this.toolStripButton_clear.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_clear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton_clear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_clear.Name = "toolStripButton_clear";
			this.toolStripButton_clear.Size = new System.Drawing.Size(90, 90);
			this.toolStripButton_clear.Tag = "";
			this.toolStripButton_clear.Text = "LIMPAR";
			this.toolStripButton_clear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_clear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripButton_clear.ToolTipText = "Limpar formulário";
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.groupBox1.Controls.Add(this.comboBox_user);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.ePictureBox_seach);
			this.groupBox1.Controls.Add(this.dateTimePicker_dataBusca);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(105, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(515, 89);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			// 
			// comboBox_user
			// 
			this.comboBox_user.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.comboBox_user.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comboBox_user.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBox_user.FormattingEnabled = true;
			this.comboBox_user.Location = new System.Drawing.Point(17, 44);
			this.comboBox_user.Name = "comboBox_user";
			this.comboBox_user.Size = new System.Drawing.Size(257, 33);
			this.comboBox_user.TabIndex = 15;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(147, 25);
			this.label1.TabIndex = 17;
			this.label1.Text = "FUNCIONÁRIO:";
			// 
			// ePictureBox_seach
			// 
			this.ePictureBox_seach.Image = global::EterPharmaPro.Properties.Resources.procurar;
			this.ePictureBox_seach.Location = new System.Drawing.Point(428, 13);
			this.ePictureBox_seach.Name = "ePictureBox_seach";
			this.ePictureBox_seach.Size = new System.Drawing.Size(64, 64);
			this.ePictureBox_seach.TabIndex = 18;
			this.ePictureBox_seach.TabStop = false;
			this.ePictureBox_seach.ToolTipText = "Buscar por data";
			this.ePictureBox_seach.Click += new System.EventHandler(this.ePictureBox_seach_Click);
			// 
			// dateTimePicker_dataBusca
			// 
			this.dateTimePicker_dataBusca.CustomFormat = "MM/yyyy";
			this.dateTimePicker_dataBusca.Font = new System.Drawing.Font("Microsoft Tai Le", 15F);
			this.dateTimePicker_dataBusca.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker_dataBusca.Location = new System.Drawing.Point(280, 44);
			this.dateTimePicker_dataBusca.Name = "dateTimePicker_dataBusca";
			this.dateTimePicker_dataBusca.ShowUpDown = true;
			this.dateTimePicker_dataBusca.Size = new System.Drawing.Size(142, 33);
			this.dateTimePicker_dataBusca.TabIndex = 14;
			this.dateTimePicker_dataBusca.ValueChanged += new System.EventHandler(this.dateTimePicker_dataBusca_ValueChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(275, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(102, 25);
			this.label6.TabIndex = 16;
			this.label6.Text = "MÊS/ANO";
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.ATEN_LOJA,
            this.DATA,
            this.CLIENTE,
            this.VALORFINAL,
            this.OBSGERAL});
			this.listView1.ContextMenuStrip = this.contextMenuStrip_produtos;
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(0, 93);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(800, 357);
			this.listView1.TabIndex = 7;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// ID
			// 
			this.ID.Text = "ID";
			this.ID.Width = 251;
			// 
			// ATEN_LOJA
			// 
			this.ATEN_LOJA.Text = "ATENDENTE LOJA";
			this.ATEN_LOJA.Width = 138;
			// 
			// DATA
			// 
			this.DATA.Text = "DATA";
			this.DATA.Width = 132;
			// 
			// CLIENTE
			// 
			this.CLIENTE.Text = "CLIENTE";
			this.CLIENTE.Width = 266;
			// 
			// VALORFINAL
			// 
			this.VALORFINAL.Text = "VALOR FINAL";
			this.VALORFINAL.Width = 158;
			// 
			// OBSGERAL
			// 
			this.OBSGERAL.Text = "OBSERVAÇÕES GERAIS";
			this.OBSGERAL.Width = 377;
			// 
			// contextMenuStrip_produtos
			// 
			this.contextMenuStrip_produtos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eDITARToolStripMenuItem,
            this.eXCLUIRToolStripMenuItem});
			this.contextMenuStrip_produtos.Name = "contextMenuStrip1";
			this.contextMenuStrip_produtos.Size = new System.Drawing.Size(120, 48);
			// 
			// eDITARToolStripMenuItem
			// 
			this.eDITARToolStripMenuItem.Image = global::EterPharmaPro.Properties.Resources.arquivo_v;
			this.eDITARToolStripMenuItem.Name = "eDITARToolStripMenuItem";
			this.eDITARToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.eDITARToolStripMenuItem.Text = "EDITAR";
			this.eDITARToolStripMenuItem.Click += new System.EventHandler(this.eDITARToolStripMenuItem_Click);
			// 
			// eXCLUIRToolStripMenuItem
			// 
			this.eXCLUIRToolStripMenuItem.Image = global::EterPharmaPro.Properties.Resources.arquivo__;
			this.eXCLUIRToolStripMenuItem.Name = "eXCLUIRToolStripMenuItem";
			this.eXCLUIRToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.eXCLUIRToolStripMenuItem.Text = "EXCLUIR";
			this.eXCLUIRToolStripMenuItem.Click += new System.EventHandler(this.eXCLUIRToolStripMenuItem_Click);
			// 
			// ReportManipulacao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.toolStrip_topMenu);
			this.Name = "ReportManipulacao";
			this.Text = "ReportManipulacao";
			this.Load += new System.EventHandler(this.ReportManipulacao_Load);
			this.toolStrip_topMenu.ResumeLayout(false);
			this.toolStrip_topMenu.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ePictureBox_seach)).EndInit();
			this.contextMenuStrip_produtos.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip_topMenu;
		private System.Windows.Forms.ToolStripButton toolStripButton_exit;
		private System.Windows.Forms.ToolStripButton toolStripButton_clear;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox comboBox_user;
		private System.Windows.Forms.Label label1;
		private Utils.eControl.ePictureBox ePictureBox_seach;
		private System.Windows.Forms.DateTimePicker dateTimePicker_dataBusca;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader ID;
		private System.Windows.Forms.ColumnHeader ATEN_LOJA;
		private System.Windows.Forms.ColumnHeader DATA;
		private System.Windows.Forms.ColumnHeader CLIENTE;
		private System.Windows.Forms.ColumnHeader VALORFINAL;
		private System.Windows.Forms.ColumnHeader OBSGERAL;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip_produtos;
		private System.Windows.Forms.ToolStripMenuItem eDITARToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem eXCLUIRToolStripMenuItem;
	}
}