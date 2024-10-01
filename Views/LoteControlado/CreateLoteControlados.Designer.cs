namespace EterPharmaPro.Views.LoteControlado
{
	partial class CreateLoteControlados
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
			this.toolStripButton_print = new System.Windows.Forms.ToolStripButton();
			this.toolStripDropDownButton_clear = new System.Windows.Forms.ToolStripButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox_cel = new System.Windows.Forms.TextBox();
			this.textBox_end = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_nome = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.numericUpDown_qtd = new System.Windows.Forms.NumericUpDown();
			this.dateTimePicker_validade = new System.Windows.Forms.DateTimePicker();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.cod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.contextMenuStrip_produtos = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.eXCLUIRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.textBox_lote = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox_medicamento = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.ePictureBox1 = new EterPharmaPro.Utils.eControl.ePictureBox();
			this.textBox_rg = new EterPharmaPro.Utils.eControl.eTextBoxWithButton();
			this.toolStrip_topMenu.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_qtd)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.contextMenuStrip_produtos.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ePictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip_topMenu
			// 
			this.toolStrip_topMenu.BackColor = System.Drawing.Color.WhiteSmoke;
			this.toolStrip_topMenu.Dock = System.Windows.Forms.DockStyle.Right;
			this.toolStrip_topMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip_topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_print,
            this.toolStripDropDownButton_clear});
			this.toolStrip_topMenu.Location = new System.Drawing.Point(834, 0);
			this.toolStrip_topMenu.Name = "toolStrip_topMenu";
			this.toolStrip_topMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.toolStrip_topMenu.Size = new System.Drawing.Size(91, 683);
			this.toolStrip_topMenu.TabIndex = 7;
			this.toolStrip_topMenu.Text = "toolStrip1";
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
			this.toolStripButton_print.Tag = "IMPRIMIR";
			this.toolStripButton_print.Text = "IMPRIMIR";
			this.toolStripButton_print.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripButton_print.ToolTipText = "IMPRIMIR";
			this.toolStripButton_print.Click += new System.EventHandler(this.toolStripButton_print_Click);
			// 
			// toolStripDropDownButton_clear
			// 
			this.toolStripDropDownButton_clear.AutoSize = false;
			this.toolStripDropDownButton_clear.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.toolStripDropDownButton_clear.Image = global::EterPharmaPro.Properties.Resources.limpar_limpo__1_;
			this.toolStripDropDownButton_clear.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripDropDownButton_clear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripDropDownButton_clear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton_clear.Name = "toolStripDropDownButton_clear";
			this.toolStripDropDownButton_clear.Size = new System.Drawing.Size(90, 90);
			this.toolStripDropDownButton_clear.Tag = "";
			this.toolStripDropDownButton_clear.Text = "LIMPAR";
			this.toolStripDropDownButton_clear.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripDropDownButton_clear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripDropDownButton_clear.ToolTipText = "Limpar Formulário";
			this.toolStripDropDownButton_clear.Click += new System.EventHandler(this.toolStripDropDownButton_clear_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox_rg);
			this.groupBox1.Controls.Add(this.textBox_cel);
			this.groupBox1.Controls.Add(this.textBox_end);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textBox_nome);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(834, 232);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "DADOS DO CLIENTE";
			// 
			// textBox_cel
			// 
			this.textBox_cel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_cel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox_cel.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_cel.Location = new System.Drawing.Point(192, 186);
			this.textBox_cel.Name = "textBox_cel";
			this.textBox_cel.Size = new System.Drawing.Size(624, 33);
			this.textBox_cel.TabIndex = 3;
			this.textBox_cel.Validated += new System.EventHandler(this.textBox_cel_Validated);
			// 
			// textBox_end
			// 
			this.textBox_end.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_end.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox_end.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_end.Location = new System.Drawing.Point(192, 100);
			this.textBox_end.Multiline = true;
			this.textBox_end.Name = "textBox_end";
			this.textBox_end.Size = new System.Drawing.Size(624, 80);
			this.textBox_end.TabIndex = 2;
			this.textBox_end.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_end_KeyDownAsync);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(144, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 25);
			this.label3.TabIndex = 12;
			this.label3.Text = "RG:";
			// 
			// textBox_nome
			// 
			this.textBox_nome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_nome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox_nome.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_nome.Location = new System.Drawing.Point(192, 52);
			this.textBox_nome.Name = "textBox_nome";
			this.textBox_nome.Size = new System.Drawing.Size(624, 33);
			this.textBox_nome.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(72, 100);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 25);
			this.label1.TabIndex = 12;
			this.label1.Text = "ENDEREÇO:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(81, 189);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 25);
			this.label2.TabIndex = 12;
			this.label2.Text = "TELEFONE:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(2, 60);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(184, 25);
			this.label6.TabIndex = 12;
			this.label6.Text = "NOME DO CLIENTE:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ePictureBox1);
			this.groupBox2.Controls.Add(this.numericUpDown_qtd);
			this.groupBox2.Controls.Add(this.dateTimePicker_validade);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Controls.Add(this.textBox_lote);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.textBox_medicamento);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 232);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(834, 451);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "DADOS DO MEDICAMENTO";
			// 
			// numericUpDown_qtd
			// 
			this.numericUpDown_qtd.Font = new System.Drawing.Font("Microsoft Tai Le", 15F);
			this.numericUpDown_qtd.Location = new System.Drawing.Point(192, 58);
			this.numericUpDown_qtd.Name = "numericUpDown_qtd";
			this.numericUpDown_qtd.Size = new System.Drawing.Size(252, 33);
			this.numericUpDown_qtd.TabIndex = 1;
			// 
			// dateTimePicker_validade
			// 
			this.dateTimePicker_validade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dateTimePicker_validade.CustomFormat = "dd/MM/yyyy";
			this.dateTimePicker_validade.Font = new System.Drawing.Font("Microsoft Tai Le", 15F);
			this.dateTimePicker_validade.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker_validade.Location = new System.Drawing.Point(562, 58);
			this.dateTimePicker_validade.Name = "dateTimePicker_validade";
			this.dateTimePicker_validade.Size = new System.Drawing.Size(139, 33);
			this.dateTimePicker_validade.TabIndex = 2;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(450, 64);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(106, 25);
			this.label8.TabIndex = 20;
			this.label8.Text = "VALIDADE:";
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.listView1);
			this.groupBox3.Location = new System.Drawing.Point(11, 136);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(805, 309);
			this.groupBox3.TabIndex = 14;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "MEDICAMENTOS";
			// 
			// listView1
			// 
			this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cod,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
			this.listView1.ContextMenuStrip = this.contextMenuStrip_produtos;
			this.listView1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.HideSelection = false;
			this.listView1.HoverSelection = true;
			this.listView1.Location = new System.Drawing.Point(3, 16);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(799, 290);
			this.listView1.TabIndex = 13;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// cod
			// 
			this.cod.Text = "CÓDIGO";
			this.cod.Width = 95;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "MEDICAMENTO";
			this.columnHeader7.Width = 262;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "QTD";
			this.columnHeader8.Width = 43;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "VALIDADE";
			this.columnHeader9.Width = 131;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "LOTE";
			this.columnHeader10.Width = 240;
			// 
			// contextMenuStrip_produtos
			// 
			this.contextMenuStrip_produtos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eXCLUIRToolStripMenuItem});
			this.contextMenuStrip_produtos.Name = "contextMenuStrip1";
			this.contextMenuStrip_produtos.Size = new System.Drawing.Size(120, 26);
			// 
			// eXCLUIRToolStripMenuItem
			// 
			this.eXCLUIRToolStripMenuItem.Image = global::EterPharmaPro.Properties.Resources.arquivo__;
			this.eXCLUIRToolStripMenuItem.Name = "eXCLUIRToolStripMenuItem";
			this.eXCLUIRToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
			this.eXCLUIRToolStripMenuItem.Text = "EXCLUIR";
			this.eXCLUIRToolStripMenuItem.Click += new System.EventHandler(this.eXCLUIRToolStripMenuItem_Click);
			// 
			// textBox_lote
			// 
			this.textBox_lote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_lote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox_lote.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_lote.Location = new System.Drawing.Point(192, 97);
			this.textBox_lote.Name = "textBox_lote";
			this.textBox_lote.Size = new System.Drawing.Size(509, 33);
			this.textBox_lote.TabIndex = 2;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(47, 58);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(139, 25);
			this.label9.TabIndex = 12;
			this.label9.Text = "QUANTIDADE:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(126, 105);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(60, 25);
			this.label7.TabIndex = 12;
			this.label7.Text = "LOTE:";
			// 
			// textBox_medicamento
			// 
			this.textBox_medicamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_medicamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox_medicamento.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_medicamento.Location = new System.Drawing.Point(192, 11);
			this.textBox_medicamento.Name = "textBox_medicamento";
			this.textBox_medicamento.Size = new System.Drawing.Size(509, 33);
			this.textBox_medicamento.TabIndex = 0;
			this.textBox_medicamento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_medicamento_KeyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(30, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(156, 25);
			this.label5.TabIndex = 12;
			this.label5.Text = "MEDICAMENTO:";
			// 
			// ePictureBox1
			// 
			this.ePictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ePictureBox1.Image = global::EterPharmaPro.Properties.Resources.arquivo__1_;
			this.ePictureBox1.Location = new System.Drawing.Point(748, 65);
			this.ePictureBox1.Name = "ePictureBox1";
			this.ePictureBox1.Size = new System.Drawing.Size(65, 65);
			this.ePictureBox1.TabIndex = 21;
			this.ePictureBox1.TabStop = false;
			this.ePictureBox1.ToolTipText = null;
			this.ePictureBox1.Click += new System.EventHandler(this.ePictureBox1_Click);
			// 
			// textBox_rg
			// 
			this.textBox_rg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_rg.ButtonText = "CLIENTE EXISTENTE";
			this.textBox_rg.ButtonVisible = false;
			this.textBox_rg.Font = new System.Drawing.Font("Microsoft Tai Le", 15F);
			this.textBox_rg.Location = new System.Drawing.Point(192, 12);
			this.textBox_rg.Name = "textBox_rg";
			this.textBox_rg.Size = new System.Drawing.Size(624, 34);
			this.textBox_rg.TabIndex = 0;
			this.textBox_rg.ButtonClick += new System.EventHandler(this.textBox_rg_ButtonClick);
			this.textBox_rg.TexBoxValidated += new System.EventHandler(this.textBox_rg_TexBoxValidated);
			// 
			// CreateLoteControlados
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(925, 683);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.toolStrip_topMenu);
			this.Name = "CreateLoteControlados";
			this.Text = "CreateLoteControlados";
			this.Load += new System.EventHandler(this.CreateLoteControlados_Load);
			this.toolStrip_topMenu.ResumeLayout(false);
			this.toolStrip_topMenu.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_qtd)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.contextMenuStrip_produtos.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ePictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip_topMenu;
		private System.Windows.Forms.ToolStripButton toolStripButton_print;
		private System.Windows.Forms.ToolStripButton toolStripDropDownButton_clear;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox_cel;
		private System.Windows.Forms.TextBox textBox_end;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox_nome;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NumericUpDown numericUpDown_qtd;
		private System.Windows.Forms.DateTimePicker dateTimePicker_validade;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.TextBox textBox_lote;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox_medicamento;
		private System.Windows.Forms.Label label5;
		private Utils.eControl.ePictureBox ePictureBox1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip_produtos;
		private System.Windows.Forms.ToolStripMenuItem eXCLUIRToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader cod;
		private Utils.eControl.eTextBoxWithButton textBox_rg;
	}
}