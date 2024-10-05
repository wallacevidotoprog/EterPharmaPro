namespace EterPharmaPro.Views.Validade
{
	partial class ReportValidades
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
			this.toolStripButton_exit = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_clear = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton_excel = new System.Windows.Forms.ToolStripButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.dataGridView_validadeFile = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Action = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ePictureBox_busca = new EterPharmaPro.Utils.eControl.ePictureBox();
			this.dateTimePicker_dataBusca = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.listView_produtos = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.ePictureBox_import = new EterPharmaPro.Utils.eControl.ePictureBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.ePictureBox_export = new EterPharmaPro.Utils.eControl.ePictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dateTimePicker_ate = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker_de = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.toolStrip_topMenu.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_validadeFile)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ePictureBox_busca)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ePictureBox_import)).BeginInit();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ePictureBox_export)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip_topMenu
			// 
			this.toolStrip_topMenu.BackColor = System.Drawing.Color.WhiteSmoke;
			this.toolStrip_topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_exit,
            this.toolStripButton_clear,
            this.toolStripSeparator1,
            this.toolStripButton_excel});
			this.toolStrip_topMenu.Location = new System.Drawing.Point(0, 0);
			this.toolStrip_topMenu.Name = "toolStrip_topMenu";
			this.toolStrip_topMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.toolStrip_topMenu.Size = new System.Drawing.Size(1223, 93);
			this.toolStrip_topMenu.TabIndex = 5;
			this.toolStrip_topMenu.Text = "toolStrip1";
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
			this.toolStripButton_exit.Click += new System.EventHandler(this.toolStripButton_exit_Click);
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
			this.toolStripButton_clear.Click += new System.EventHandler(this.toolStripButton_clear_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 93);
			// 
			// toolStripButton_excel
			// 
			this.toolStripButton_excel.AutoSize = false;
			this.toolStripButton_excel.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.toolStripButton_excel.Image = global::EterPharmaPro.Properties.Resources.excel;
			this.toolStripButton_excel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_excel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton_excel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_excel.Name = "toolStripButton_excel";
			this.toolStripButton_excel.Size = new System.Drawing.Size(90, 90);
			this.toolStripButton_excel.Tag = "";
			this.toolStripButton_excel.Text = "SALVAR EXCEL";
			this.toolStripButton_excel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_excel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripButton_excel.ToolTipText = "Salvar documento em excel";
			this.toolStripButton_excel.Click += new System.EventHandler(this.toolStripButton_excel_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox1.Location = new System.Drawing.Point(0, 93);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(434, 436);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "AÇÕES";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.dataGridView_validadeFile);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox4.Location = new System.Drawing.Point(3, 77);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(428, 356);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			// 
			// dataGridView_validadeFile
			// 
			this.dataGridView_validadeFile.AllowUserToAddRows = false;
			this.dataGridView_validadeFile.AllowUserToDeleteRows = false;
			this.dataGridView_validadeFile.AllowUserToResizeColumns = false;
			this.dataGridView_validadeFile.AllowUserToResizeRows = false;
			this.dataGridView_validadeFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView_validadeFile.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
			this.dataGridView_validadeFile.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.dataGridView_validadeFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridView_validadeFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Action});
			this.dataGridView_validadeFile.Cursor = System.Windows.Forms.Cursors.Hand;
			this.dataGridView_validadeFile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView_validadeFile.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.dataGridView_validadeFile.Location = new System.Drawing.Point(3, 16);
			this.dataGridView_validadeFile.MultiSelect = false;
			this.dataGridView_validadeFile.Name = "dataGridView_validadeFile";
			this.dataGridView_validadeFile.ReadOnly = true;
			this.dataGridView_validadeFile.RowHeadersVisible = false;
			this.dataGridView_validadeFile.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dataGridView_validadeFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_validadeFile.Size = new System.Drawing.Size(422, 337);
			this.dataGridView_validadeFile.TabIndex = 5;
			this.dataGridView_validadeFile.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_validadeFile_CellContentClick);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
			this.dataGridViewTextBoxColumn1.HeaderText = "ID";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Nome";
			this.dataGridViewTextBoxColumn2.FillWeight = 200F;
			this.dataGridViewTextBoxColumn2.HeaderText = "NOME";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.DataPropertyName = "Data";
			this.dataGridViewTextBoxColumn3.FillWeight = 193.1035F;
			this.dataGridViewTextBoxColumn3.HeaderText = "DATA";
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Action
			// 
			this.Action.FillWeight = 30F;
			this.Action.HeaderText = "";
			this.Action.Name = "Action";
			this.Action.ReadOnly = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ePictureBox_busca);
			this.groupBox2.Controls.Add(this.dateTimePicker_dataBusca);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(3, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(428, 61);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			// 
			// ePictureBox_busca
			// 
			this.ePictureBox_busca.Image = global::EterPharmaPro.Properties.Resources.procurar;
			this.ePictureBox_busca.Location = new System.Drawing.Point(381, 11);
			this.ePictureBox_busca.Name = "ePictureBox_busca";
			this.ePictureBox_busca.Size = new System.Drawing.Size(40, 40);
			this.ePictureBox_busca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ePictureBox_busca.TabIndex = 16;
			this.ePictureBox_busca.TabStop = false;
			this.ePictureBox_busca.ToolTipText = null;
			this.ePictureBox_busca.Click += new System.EventHandler(this.ePictureBox_busca_ClickAsync);
			// 
			// dateTimePicker_dataBusca
			// 
			this.dateTimePicker_dataBusca.CustomFormat = "MM/yyyy";
			this.dateTimePicker_dataBusca.Font = new System.Drawing.Font("Microsoft Tai Le", 15F);
			this.dateTimePicker_dataBusca.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker_dataBusca.Location = new System.Drawing.Point(115, 16);
			this.dateTimePicker_dataBusca.Name = "dateTimePicker_dataBusca";
			this.dateTimePicker_dataBusca.ShowUpDown = true;
			this.dateTimePicker_dataBusca.Size = new System.Drawing.Size(260, 33);
			this.dateTimePicker_dataBusca.TabIndex = 0;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(3, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(106, 25);
			this.label6.TabIndex = 12;
			this.label6.Text = "MÊS/ANO:";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.listView_produtos);
			this.groupBox3.Controls.Add(this.groupBox5);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new System.Drawing.Point(434, 93);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(789, 436);
			this.groupBox3.TabIndex = 14;
			this.groupBox3.TabStop = false;
			// 
			// listView_produtos
			// 
			this.listView_produtos.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.listView_produtos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
			this.listView_produtos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.listView_produtos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView_produtos.FullRowSelect = true;
			this.listView_produtos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView_produtos.HideSelection = false;
			this.listView_produtos.HoverSelection = true;
			this.listView_produtos.Location = new System.Drawing.Point(3, 116);
			this.listView_produtos.Name = "listView_produtos";
			this.listView_produtos.Size = new System.Drawing.Size(783, 317);
			this.listView_produtos.TabIndex = 13;
			this.listView_produtos.UseCompatibleStateImageBehavior = false;
			this.listView_produtos.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "ID";
			this.columnHeader1.Width = 80;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "CÓDIGO";
			this.columnHeader8.Width = 115;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "DESCRIÇÃO";
			this.columnHeader9.Width = 300;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "QTD";
			this.columnHeader10.Width = 71;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "DATA VALIDADE";
			this.columnHeader11.Width = 200;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.ePictureBox_import);
			this.groupBox5.Controls.Add(this.groupBox6);
			this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox5.Location = new System.Drawing.Point(3, 16);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(783, 100);
			this.groupBox5.TabIndex = 0;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "IMPORTAÇÃO";
			// 
			// ePictureBox_import
			// 
			this.ePictureBox_import.Image = global::EterPharmaPro.Properties.Resources.exportar;
			this.ePictureBox_import.Location = new System.Drawing.Point(6, 19);
			this.ePictureBox_import.Name = "ePictureBox_import";
			this.ePictureBox_import.Size = new System.Drawing.Size(75, 75);
			this.ePictureBox_import.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ePictureBox_import.TabIndex = 15;
			this.ePictureBox_import.TabStop = false;
			this.ePictureBox_import.ToolTipText = "Importar validades selecionadas";
			this.ePictureBox_import.Click += new System.EventHandler(this.ePictureBox_import_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox6.Controls.Add(this.ePictureBox_export);
			this.groupBox6.Controls.Add(this.label2);
			this.groupBox6.Controls.Add(this.dateTimePicker_ate);
			this.groupBox6.Controls.Add(this.dateTimePicker_de);
			this.groupBox6.Controls.Add(this.label1);
			this.groupBox6.Location = new System.Drawing.Point(352, 16);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(425, 68);
			this.groupBox6.TabIndex = 14;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Exportar Produtos Próximo da Validade";
			// 
			// ePictureBox_export
			// 
			this.ePictureBox_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ePictureBox_export.Image = global::EterPharmaPro.Properties.Resources.excel;
			this.ePictureBox_export.Location = new System.Drawing.Point(379, 22);
			this.ePictureBox_export.Name = "ePictureBox_export";
			this.ePictureBox_export.Size = new System.Drawing.Size(40, 40);
			this.ePictureBox_export.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ePictureBox_export.TabIndex = 16;
			this.ePictureBox_export.TabStop = false;
			this.ePictureBox_export.ToolTipText = "Exportar validades selecionadas";
			this.ePictureBox_export.Click += new System.EventHandler(this.ePictureBox_export_ClickAsync);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(182, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 31);
			this.label2.TabIndex = 18;
			this.label2.Text = "ATE:";
			// 
			// dateTimePicker_ate
			// 
			this.dateTimePicker_ate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dateTimePicker_ate.CustomFormat = "MM/yyyy";
			this.dateTimePicker_ate.Font = new System.Drawing.Font("Microsoft Tai Le", 15F);
			this.dateTimePicker_ate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker_ate.Location = new System.Drawing.Point(263, 29);
			this.dateTimePicker_ate.Name = "dateTimePicker_ate";
			this.dateTimePicker_ate.ShowUpDown = true;
			this.dateTimePicker_ate.Size = new System.Drawing.Size(110, 33);
			this.dateTimePicker_ate.TabIndex = 17;
			this.dateTimePicker_ate.ValueChanged += new System.EventHandler(this.dateTimePicker_de_ValueChanged);
			// 
			// dateTimePicker_de
			// 
			this.dateTimePicker_de.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dateTimePicker_de.CustomFormat = "MM/yyyy";
			this.dateTimePicker_de.Font = new System.Drawing.Font("Microsoft Tai Le", 15F);
			this.dateTimePicker_de.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker_de.Location = new System.Drawing.Point(66, 27);
			this.dateTimePicker_de.Name = "dateTimePicker_de";
			this.dateTimePicker_de.ShowUpDown = true;
			this.dateTimePicker_de.Size = new System.Drawing.Size(110, 33);
			this.dateTimePicker_de.TabIndex = 17;
			this.dateTimePicker_de.ValueChanged += new System.EventHandler(this.dateTimePicker_de_ValueChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 31);
			this.label1.TabIndex = 16;
			this.label1.Text = "DE:";
			// 
			// ReportValidades
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1223, 529);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.toolStrip_topMenu);
			this.Name = "ReportValidades";
			this.Text = "ReportMenipulados";
			this.Load += new System.EventHandler(this.ReportValidades_Load);
			this.toolStrip_topMenu.ResumeLayout(false);
			this.toolStrip_topMenu.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_validadeFile)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ePictureBox_busca)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ePictureBox_import)).EndInit();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ePictureBox_export)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip_topMenu;
		private System.Windows.Forms.ToolStripButton toolStripButton_exit;
		private System.Windows.Forms.ToolStripButton toolStripButton_clear;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.DataGridView dataGridView_validadeFile;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DateTimePicker dateTimePicker_dataBusca;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ListView listView_produtos;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dateTimePicker_ate;
		private System.Windows.Forms.DateTimePicker dateTimePicker_de;
		private System.Windows.Forms.Label label1;
		private Utils.eControl.ePictureBox ePictureBox_import;
		private Utils.eControl.ePictureBox ePictureBox_busca;
		private Utils.eControl.ePictureBox ePictureBox_export;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Action;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolStripButton_excel;
	}
}