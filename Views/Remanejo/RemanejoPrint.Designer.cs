namespace EterPharmaPro.Views.Remanejo
{
	partial class RemanejoPrint
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
			this.toolStripButton_print = new System.Windows.Forms.ToolStripButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox_obs = new System.Windows.Forms.TextBox();
			this.textBox_num = new System.Windows.Forms.TextBox();
			this.numericUpDown_qtd = new System.Windows.Forms.NumericUpDown();
			this.dateTimePicker_data = new System.Windows.Forms.DateTimePicker();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.toolStrip_topMenu.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_qtd)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip_topMenu
			// 
			this.toolStrip_topMenu.BackColor = System.Drawing.Color.WhiteSmoke;
			this.toolStrip_topMenu.Dock = System.Windows.Forms.DockStyle.Right;
			this.toolStrip_topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_print});
			this.toolStrip_topMenu.Location = new System.Drawing.Point(885, 0);
			this.toolStrip_topMenu.Name = "toolStrip_topMenu";
			this.toolStrip_topMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.toolStrip_topMenu.Size = new System.Drawing.Size(91, 606);
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
			this.toolStripButton_print.Tag = "Imprimir remanejo";
			this.toolStripButton_print.Text = "IMPRIMIR";
			this.toolStripButton_print.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripButton_print.ToolTipText = "SAIR";
			this.toolStripButton_print.Click += new System.EventHandler(this.toolStripButton_print_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox_obs);
			this.groupBox1.Controls.Add(this.textBox_num);
			this.groupBox1.Controls.Add(this.numericUpDown_qtd);
			this.groupBox1.Controls.Add(this.dateTimePicker_data);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(885, 606);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			// 
			// textBox_obs
			// 
			this.textBox_obs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_obs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox_obs.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_obs.Location = new System.Drawing.Point(191, 339);
			this.textBox_obs.Multiline = true;
			this.textBox_obs.Name = "textBox_obs";
			this.textBox_obs.Size = new System.Drawing.Size(533, 88);
			this.textBox_obs.TabIndex = 3;
			// 
			// textBox_num
			// 
			this.textBox_num.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_num.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox_num.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_num.Location = new System.Drawing.Point(191, 210);
			this.textBox_num.Name = "textBox_num";
			this.textBox_num.Size = new System.Drawing.Size(533, 33);
			this.textBox_num.TabIndex = 0;
			// 
			// numericUpDown_qtd
			// 
			this.numericUpDown_qtd.Font = new System.Drawing.Font("Microsoft Tai Le", 15F);
			this.numericUpDown_qtd.Location = new System.Drawing.Point(191, 275);
			this.numericUpDown_qtd.Name = "numericUpDown_qtd";
			this.numericUpDown_qtd.Size = new System.Drawing.Size(252, 33);
			this.numericUpDown_qtd.TabIndex = 1;
			// 
			// dateTimePicker_data
			// 
			this.dateTimePicker_data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dateTimePicker_data.CustomFormat = "dd/MM/yyyy";
			this.dateTimePicker_data.Font = new System.Drawing.Font("Microsoft Tai Le", 15F);
			this.dateTimePicker_data.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker_data.Location = new System.Drawing.Point(449, 275);
			this.dateTimePicker_data.Name = "dateTimePicker_data";
			this.dateTimePicker_data.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.dateTimePicker_data.Size = new System.Drawing.Size(275, 33);
			this.dateTimePicker_data.TabIndex = 2;
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(444, 247);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(66, 25);
			this.label8.TabIndex = 24;
			this.label8.Text = "DATA:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(186, 247);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(139, 25);
			this.label9.TabIndex = 23;
			this.label9.Text = "QUANTIDADE:";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(186, 311);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(148, 25);
			this.label1.TabIndex = 14;
			this.label1.Text = "OBSERVAÇÕES:";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(186, 182);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(239, 25);
			this.label3.TabIndex = 14;
			this.label3.Text = "NÚMERO DO REMANEJO:";
			// 
			// RemanejoPrint
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(976, 606);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.toolStrip_topMenu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "RemanejoPrint";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RemanejoPrint";
			this.toolStrip_topMenu.ResumeLayout(false);
			this.toolStrip_topMenu.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_qtd)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip_topMenu;
		private System.Windows.Forms.ToolStripButton toolStripButton_print;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numericUpDown_qtd;
		private System.Windows.Forms.DateTimePicker dateTimePicker_data;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_obs;
		private System.Windows.Forms.TextBox textBox_num;
	}
}