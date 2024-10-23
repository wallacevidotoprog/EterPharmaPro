namespace EterPharmaPro.Views.Configuracoes
{
	partial class Produtos
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
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.dataGridView_dados = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox_tipo = new System.Windows.Forms.ComboBox();
			this.textBox_codigo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.textBox_contador = new System.Windows.Forms.TextBox();
			this.ePictureBox_busca = new EterPharmaPro.Utils.eControl.ePictureBox();
			this.ePictureBox_import = new EterPharmaPro.Utils.eControl.ePictureBox();
			this.ePictureBox_opFile = new EterPharmaPro.Utils.eControl.ePictureBox();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_dados)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ePictureBox_busca)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ePictureBox_import)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ePictureBox_opFile)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.dataGridView_dados);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox4.Location = new System.Drawing.Point(3, 104);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(954, 360);
			this.groupBox4.TabIndex = 1;
			this.groupBox4.TabStop = false;
			// 
			// dataGridView_dados
			// 
			this.dataGridView_dados.AllowUserToAddRows = false;
			this.dataGridView_dados.AllowUserToDeleteRows = false;
			this.dataGridView_dados.AllowUserToResizeColumns = false;
			this.dataGridView_dados.AllowUserToResizeRows = false;
			this.dataGridView_dados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView_dados.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
			this.dataGridView_dados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.dataGridView_dados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridView_dados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6});
			this.dataGridView_dados.Cursor = System.Windows.Forms.Cursors.Hand;
			this.dataGridView_dados.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView_dados.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.dataGridView_dados.Location = new System.Drawing.Point(3, 16);
			this.dataGridView_dados.MultiSelect = false;
			this.dataGridView_dados.Name = "dataGridView_dados";
			this.dataGridView_dados.ReadOnly = true;
			this.dataGridView_dados.RowHeadersVisible = false;
			this.dataGridView_dados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dataGridView_dados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_dados.Size = new System.Drawing.Size(948, 341);
			this.dataGridView_dados.TabIndex = 0;
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "EAN";
			this.Column1.FillWeight = 68.96552F;
			this.Column1.HeaderText = "EAN";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			// 
			// Column2
			// 
			this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.Column2.DataPropertyName = "COD_PRODUTO";
			this.Column2.HeaderText = "COD PRODUTO";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 112;
			// 
			// Column3
			// 
			this.Column3.DataPropertyName = "DESCRICAO_PRODUTO";
			this.Column3.FillWeight = 193.1035F;
			this.Column3.HeaderText = "DESCRIÇÃO PRODUTO";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			// 
			// Column5
			// 
			this.Column5.DataPropertyName = "LABORATORIO";
			this.Column5.FillWeight = 68.96552F;
			this.Column5.HeaderText = "LABORATÓRIO";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Column6
			// 
			this.Column6.DataPropertyName = "GRUPO";
			this.Column6.FillWeight = 68.96552F;
			this.Column6.HeaderText = "GRUPO";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.groupBox4);
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 104);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(960, 467);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "DADOS";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.ePictureBox_busca);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.comboBox_tipo);
			this.groupBox3.Controls.Add(this.textBox_codigo);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new System.Drawing.Point(3, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(954, 88);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "BUSCA";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(227, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 25);
			this.label1.TabIndex = 15;
			this.label1.Text = "CÓDIGO:";
			// 
			// comboBox_tipo
			// 
			this.comboBox_tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_tipo.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBox_tipo.FormattingEnabled = true;
			this.comboBox_tipo.Items.AddRange(new object[] {
            "EAN",
            "COD INTERNO",
            "DESCRIÇÃO",
            "LABORATÓRIO",
            "GRUPO"});
			this.comboBox_tipo.Location = new System.Drawing.Point(6, 44);
			this.comboBox_tipo.Name = "comboBox_tipo";
			this.comboBox_tipo.Size = new System.Drawing.Size(218, 33);
			this.comboBox_tipo.TabIndex = 12;
			// 
			// textBox_codigo
			// 
			this.textBox_codigo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_codigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox_codigo.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_codigo.Location = new System.Drawing.Point(230, 44);
			this.textBox_codigo.Name = "textBox_codigo";
			this.textBox_codigo.Size = new System.Drawing.Size(634, 33);
			this.textBox_codigo.TabIndex = 14;
			this.textBox_codigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_codigo_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(6, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 25);
			this.label2.TabIndex = 13;
			this.label2.Text = "TIPO:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox5);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(960, 104);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "AÇÕES";
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.groupBox5.Controls.Add(this.ePictureBox_import);
			this.groupBox5.Controls.Add(this.textBox_contador);
			this.groupBox5.Controls.Add(this.ePictureBox_opFile);
			this.groupBox5.Location = new System.Drawing.Point(338, 16);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(285, 85);
			this.groupBox5.TabIndex = 13;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "IMPORTAÇÃO";
			// 
			// textBox_contador
			// 
			this.textBox_contador.Dock = System.Windows.Forms.DockStyle.Left;
			this.textBox_contador.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_contador.Location = new System.Drawing.Point(69, 16);
			this.textBox_contador.Multiline = true;
			this.textBox_contador.Name = "textBox_contador";
			this.textBox_contador.ReadOnly = true;
			this.textBox_contador.Size = new System.Drawing.Size(147, 66);
			this.textBox_contador.TabIndex = 13;
			this.textBox_contador.Text = "TOTAL DE LINHAS LIDAS {0}";
			this.textBox_contador.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ePictureBox_busca
			// 
			this.ePictureBox_busca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ePictureBox_busca.Image = global::EterPharmaPro.Properties.Resources.procurar;
			this.ePictureBox_busca.Location = new System.Drawing.Point(870, 16);
			this.ePictureBox_busca.Name = "ePictureBox_busca";
			this.ePictureBox_busca.Size = new System.Drawing.Size(74, 66);
			this.ePictureBox_busca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.ePictureBox_busca.TabIndex = 16;
			this.ePictureBox_busca.TabStop = false;
			this.ePictureBox_busca.ToolTipText = null;
			this.ePictureBox_busca.Click += new System.EventHandler(this.ePictureBox_busca_Click);
			// 
			// ePictureBox_import
			// 
			this.ePictureBox_import.Cursor = System.Windows.Forms.Cursors.No;
			this.ePictureBox_import.Dock = System.Windows.Forms.DockStyle.Left;
			this.ePictureBox_import.Image = global::EterPharmaPro.Properties.Resources.database_security;
			this.ePictureBox_import.Location = new System.Drawing.Point(216, 16);
			this.ePictureBox_import.Name = "ePictureBox_import";
			this.ePictureBox_import.Size = new System.Drawing.Size(66, 66);
			this.ePictureBox_import.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.ePictureBox_import.TabIndex = 18;
			this.ePictureBox_import.TabStop = false;
			this.ePictureBox_import.ToolTipText = "Salvar no banco de dados";
			this.ePictureBox_import.Click += new System.EventHandler(this.ePictureBox_import_Click);
			// 
			// ePictureBox_opFile
			// 
			this.ePictureBox_opFile.Dock = System.Windows.Forms.DockStyle.Left;
			this.ePictureBox_opFile.Image = global::EterPharmaPro.Properties.Resources.exportar;
			this.ePictureBox_opFile.Location = new System.Drawing.Point(3, 16);
			this.ePictureBox_opFile.Name = "ePictureBox_opFile";
			this.ePictureBox_opFile.Size = new System.Drawing.Size(66, 66);
			this.ePictureBox_opFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.ePictureBox_opFile.TabIndex = 17;
			this.ePictureBox_opFile.TabStop = false;
			this.ePictureBox_opFile.ToolTipText = "Importar dados do Excel";
			this.ePictureBox_opFile.Click += new System.EventHandler(this.ePictureBox_opFile_ClickAsync);
			// 
			// Produtos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(960, 571);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Produtos";
			this.Text = "Produtos";
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_dados)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ePictureBox_busca)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ePictureBox_import)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ePictureBox_opFile)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.DataGridView dataGridView_dados;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox_tipo;
		private System.Windows.Forms.TextBox textBox_codigo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.TextBox textBox_contador;
		private Utils.eControl.ePictureBox ePictureBox_busca;
		private Utils.eControl.ePictureBox ePictureBox_opFile;
		private Utils.eControl.ePictureBox ePictureBox_import;
	}
}