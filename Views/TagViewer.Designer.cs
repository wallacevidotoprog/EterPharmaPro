namespace EterPharmaPro.Views
{
	partial class TagViewer
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
			this.toolStripButton_print = new System.Windows.Forms.ToolStripButton();
			this.toolStrip_topMenu = new System.Windows.Forms.ToolStrip();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.dataGridView_validade = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.OLD_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.NEW_PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DATA_VALITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DELETE = new System.Windows.Forms.DataGridViewButtonColumn();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.numericUpDown_qtd = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox_new = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_old = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dateTimePicker_data = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_produto = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.pictureBox_addItem = new EterPharmaPro.Utils.eControl.ePictureBox();
			this.toolStripButtons_sair = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_clear = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStrip_topMenu.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_validade)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_qtd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_addItem)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStripButton_print
			// 
			this.toolStripButton_print.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton_print.AutoSize = false;
			this.toolStripButton_print.Font = new System.Drawing.Font("Segoe UI", 7F);
			this.toolStripButton_print.Image = global::EterPharmaPro.Properties.Resources.download__1_;
			this.toolStripButton_print.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_print.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton_print.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_print.Name = "toolStripButton_print";
			this.toolStripButton_print.Size = new System.Drawing.Size(90, 90);
			this.toolStripButton_print.Tag = "";
			this.toolStripButton_print.Text = "IMPRIMIR";
			this.toolStripButton_print.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripButton_print.ToolTipText = "Imprimir Tags de validade";
			this.toolStripButton_print.Click += new System.EventHandler(this.ePictureBox_gerar_Click);
			// 
			// toolStrip_topMenu
			// 
			this.toolStrip_topMenu.BackColor = System.Drawing.Color.WhiteSmoke;
			this.toolStrip_topMenu.Dock = System.Windows.Forms.DockStyle.Right;
			this.toolStrip_topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_print,
            this.toolStripButtons_sair,
            this.toolStripSeparator1,
            this.toolStripButton_clear});
			this.toolStrip_topMenu.Location = new System.Drawing.Point(884, 0);
			this.toolStrip_topMenu.Name = "toolStrip_topMenu";
			this.toolStrip_topMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.toolStrip_topMenu.Size = new System.Drawing.Size(91, 450);
			this.toolStrip_topMenu.TabIndex = 10;
			this.toolStrip_topMenu.Text = "toolStrip1";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(884, 450);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "VALIDADES";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.dataGridView_validade);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new System.Drawing.Point(3, 116);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(878, 331);
			this.groupBox3.TabIndex = 8;
			this.groupBox3.TabStop = false;
			// 
			// dataGridView_validade
			// 
			this.dataGridView_validade.AllowUserToAddRows = false;
			this.dataGridView_validade.AllowUserToDeleteRows = false;
			this.dataGridView_validade.AllowUserToResizeColumns = false;
			this.dataGridView_validade.AllowUserToResizeRows = false;
			this.dataGridView_validade.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView_validade.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
			this.dataGridView_validade.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.dataGridView_validade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridView_validade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.OLD_PRICE,
            this.NEW_PRICE,
            this.DATA_VALITY,
            this.DELETE});
			this.dataGridView_validade.Cursor = System.Windows.Forms.Cursors.Hand;
			this.dataGridView_validade.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView_validade.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.dataGridView_validade.Location = new System.Drawing.Point(3, 16);
			this.dataGridView_validade.MultiSelect = false;
			this.dataGridView_validade.Name = "dataGridView_validade";
			this.dataGridView_validade.RowHeadersVisible = false;
			this.dataGridView_validade.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dataGridView_validade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_validade.Size = new System.Drawing.Size(872, 312);
			this.dataGridView_validade.TabIndex = 6;
			this.dataGridView_validade.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_validade_CellContentClick);
			this.dataGridView_validade.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_validade_RowValidated);
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
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Nome";
			this.dataGridViewTextBoxColumn2.FillWeight = 200F;
			this.dataGridViewTextBoxColumn2.HeaderText = "NOME";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			// 
			// OLD_PRICE
			// 
			this.OLD_PRICE.HeaderText = "PREÇO ANTIGO";
			this.OLD_PRICE.Name = "OLD_PRICE";
			// 
			// NEW_PRICE
			// 
			this.NEW_PRICE.HeaderText = "NOVO PREÇO";
			this.NEW_PRICE.Name = "NEW_PRICE";
			// 
			// DATA_VALITY
			// 
			this.DATA_VALITY.HeaderText = "VALIDADE";
			this.DATA_VALITY.Name = "DATA_VALITY";
			this.DATA_VALITY.ReadOnly = true;
			// 
			// DELETE
			// 
			this.DELETE.FillWeight = 80F;
			this.DELETE.HeaderText = "DELETAR";
			this.DELETE.Name = "DELETE";
			this.DELETE.Text = "DELETAR";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.pictureBox_addItem);
			this.groupBox2.Controls.Add(this.numericUpDown_qtd);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.textBox_new);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.textBox_old);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.dateTimePicker_data);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.textBox_produto);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(3, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(878, 100);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			// 
			// numericUpDown_qtd
			// 
			this.numericUpDown_qtd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDown_qtd.Font = new System.Drawing.Font("Microsoft Tai Le", 15F);
			this.numericUpDown_qtd.Location = new System.Drawing.Point(599, 51);
			this.numericUpDown_qtd.Name = "numericUpDown_qtd";
			this.numericUpDown_qtd.Size = new System.Drawing.Size(52, 33);
			this.numericUpDown_qtd.TabIndex = 24;
			this.numericUpDown_qtd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(596, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 25);
			this.label4.TabIndex = 25;
			this.label4.Text = "QTD:";
			// 
			// textBox_new
			// 
			this.textBox_new.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_new.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox_new.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_new.Location = new System.Drawing.Point(456, 51);
			this.textBox_new.Name = "textBox_new";
			this.textBox_new.Size = new System.Drawing.Size(137, 33);
			this.textBox_new.TabIndex = 21;
			this.textBox_new.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_old_KeyPress);
			this.textBox_new.Validated += new System.EventHandler(this.textBox_old_Validated);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(451, 23);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(139, 25);
			this.label3.TabIndex = 22;
			this.label3.Text = "NOVO VALOR:";
			// 
			// textBox_old
			// 
			this.textBox_old.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_old.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox_old.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_old.Location = new System.Drawing.Point(311, 51);
			this.textBox_old.Name = "textBox_old";
			this.textBox_old.Size = new System.Drawing.Size(139, 33);
			this.textBox_old.TabIndex = 21;
			this.textBox_old.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_old_KeyPress);
			this.textBox_old.Validated += new System.EventHandler(this.textBox_old_Validated);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(309, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(141, 25);
			this.label2.TabIndex = 22;
			this.label2.Text = "VALOR ATUAL:";
			// 
			// dateTimePicker_data
			// 
			this.dateTimePicker_data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dateTimePicker_data.CustomFormat = "dd/MM/yyyy";
			this.dateTimePicker_data.Font = new System.Drawing.Font("Microsoft Tai Le", 15F);
			this.dateTimePicker_data.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker_data.Location = new System.Drawing.Point(662, 51);
			this.dateTimePicker_data.Name = "dateTimePicker_data";
			this.dateTimePicker_data.Size = new System.Drawing.Size(139, 33);
			this.dateTimePicker_data.TabIndex = 19;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(657, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 25);
			this.label1.TabIndex = 20;
			this.label1.Text = "VALIDADE:";
			// 
			// textBox_produto
			// 
			this.textBox_produto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_produto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox_produto.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_produto.Location = new System.Drawing.Point(14, 51);
			this.textBox_produto.Name = "textBox_produto";
			this.textBox_produto.Size = new System.Drawing.Size(291, 33);
			this.textBox_produto.TabIndex = 13;
			this.textBox_produto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_produto_KeyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(9, 23);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(107, 25);
			this.label5.TabIndex = 14;
			this.label5.Text = "PRODUTO:";
			// 
			// pictureBox_addItem
			// 
			this.pictureBox_addItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox_addItem.Image = global::EterPharmaPro.Properties.Resources.arquivo__1_;
			this.pictureBox_addItem.Location = new System.Drawing.Point(807, 30);
			this.pictureBox_addItem.Name = "pictureBox_addItem";
			this.pictureBox_addItem.Size = new System.Drawing.Size(64, 64);
			this.pictureBox_addItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox_addItem.TabIndex = 26;
			this.pictureBox_addItem.TabStop = false;
			this.pictureBox_addItem.ToolTipText = null;
			this.pictureBox_addItem.Click += new System.EventHandler(this.pictureBox_addItem_Click);
			// 
			// toolStripButtons_sair
			// 
			this.toolStripButtons_sair.AutoSize = false;
			this.toolStripButtons_sair.Font = new System.Drawing.Font("Segoe UI", 7F);
			this.toolStripButtons_sair.Image = global::EterPharmaPro.Properties.Resources.sair__1_;
			this.toolStripButtons_sair.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButtons_sair.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButtons_sair.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtons_sair.Name = "toolStripButtons_sair";
			this.toolStripButtons_sair.Size = new System.Drawing.Size(90, 90);
			this.toolStripButtons_sair.Tag = "";
			this.toolStripButtons_sair.Text = "SAIR";
			this.toolStripButtons_sair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButtons_sair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripButtons_sair.ToolTipText = "Sair";
			this.toolStripButtons_sair.Click += new System.EventHandler(this.toolStripButtons_sair_Click);
			// 
			// toolStripButton_clear
			// 
			this.toolStripButton_clear.AutoSize = false;
			this.toolStripButton_clear.Font = new System.Drawing.Font("Segoe UI", 7F);
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
			this.toolStripButton_clear.ToolTipText = "LIMPAR";
			this.toolStripButton_clear.Click += new System.EventHandler(this.toolStripButton_clear_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(88, 6);
			// 
			// TagViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(975, 450);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.toolStrip_topMenu);
			this.Name = "TagViewer";
			this.Text = "TagViewer";
			this.toolStrip_topMenu.ResumeLayout(false);
			this.toolStrip_topMenu.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_validade)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_qtd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_addItem)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStripButton toolStripButton_print;
		private System.Windows.Forms.ToolStrip toolStrip_topMenu;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.DataGridView dataGridView_validade;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn OLD_PRICE;
		private System.Windows.Forms.DataGridViewTextBoxColumn NEW_PRICE;
		private System.Windows.Forms.DataGridViewTextBoxColumn DATA_VALITY;
		private System.Windows.Forms.DataGridViewButtonColumn DELETE;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NumericUpDown numericUpDown_qtd;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox_new;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_old;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dateTimePicker_data;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_produto;
		private System.Windows.Forms.Label label5;
		private Utils.eControl.ePictureBox pictureBox_addItem;
		private System.Windows.Forms.ToolStripButton toolStripButton_clear;
		private System.Windows.Forms.ToolStripButton toolStripButtons_sair;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	}
}