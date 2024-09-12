﻿namespace EterPharmaPro
{
	partial class MainWindow
	{
		/// <summary>
		/// Variável de designer necessária.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpar os recursos que estão sendo usados.
		/// </summary>
		/// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código gerado pelo Windows Form Designer

		/// <summary>
		/// Método necessário para suporte ao Designer - não modifique 
		/// o conteúdo deste método com o editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
			this.panel_center = new System.Windows.Forms.Panel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton_manipulacao = new System.Windows.Forms.ToolStripDropDownButton();
			this.fORMUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rELATÓRIOToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.gERARVALIDADEDOMÊSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rELATÓRIOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripButton_conf = new System.Windows.Forms.ToolStripButton();
			this.toolStripDropDownButton_impressos = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel_center
			// 
			this.panel_center.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_center.Location = new System.Drawing.Point(0, 93);
			this.panel_center.Name = "panel_center";
			this.panel_center.Size = new System.Drawing.Size(800, 357);
			this.panel_center.TabIndex = 4;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripButton_manipulacao,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripButton_conf,
            this.toolStripSeparator3,
            this.toolStripDropDownButton_impressos,
            this.toolStripButton2});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.toolStrip1.Size = new System.Drawing.Size(800, 93);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 93);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 93);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 93);
			// 
			// toolStripButton_manipulacao
			// 
			this.toolStripButton_manipulacao.AutoSize = false;
			this.toolStripButton_manipulacao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fORMUToolStripMenuItem,
            this.rELATÓRIOToolStripMenuItem1});
			this.toolStripButton_manipulacao.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.toolStripButton_manipulacao.Image = global::EterPharmaPro.Properties.Resources.farmaceutico;
			this.toolStripButton_manipulacao.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_manipulacao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton_manipulacao.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_manipulacao.Name = "toolStripButton_manipulacao";
			this.toolStripButton_manipulacao.Size = new System.Drawing.Size(90, 90);
			this.toolStripButton_manipulacao.Tag = "MANIPULAÇÃO";
			this.toolStripButton_manipulacao.Text = "MANIPULAÇÃO";
			this.toolStripButton_manipulacao.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_manipulacao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripButton_manipulacao.ToolTipText = "MANIPULAÇÃO";
			// 
			// fORMUToolStripMenuItem
			// 
			this.fORMUToolStripMenuItem.Name = "fORMUToolStripMenuItem";
			this.fORMUToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.fORMUToolStripMenuItem.Text = "FORMULÁRIO";
			this.fORMUToolStripMenuItem.Click += new System.EventHandler(this.fORMUToolStripMenuItem_Click);
			// 
			// rELATÓRIOToolStripMenuItem1
			// 
			this.rELATÓRIOToolStripMenuItem1.Name = "rELATÓRIOToolStripMenuItem1";
			this.rELATÓRIOToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
			this.rELATÓRIOToolStripMenuItem1.Text = "RELATÓRIO";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.AutoSize = false;
			this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gERARVALIDADEDOMÊSToolStripMenuItem,
            this.rELATÓRIOToolStripMenuItem});
			this.toolStripButton1.Image = global::EterPharmaPro.Properties.Resources.expirado;
			this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(90, 90);
			this.toolStripButton1.Tag = "VALIDADES";
			this.toolStripButton1.Text = "VALIDADES";
			this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripButton1.ToolTipText = "VALIDADES";
			// 
			// gERARVALIDADEDOMÊSToolStripMenuItem
			// 
			this.gERARVALIDADEDOMÊSToolStripMenuItem.Name = "gERARVALIDADEDOMÊSToolStripMenuItem";
			this.gERARVALIDADEDOMÊSToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.gERARVALIDADEDOMÊSToolStripMenuItem.Text = "GERAR VALIDADE DO MÊS";
			// 
			// rELATÓRIOToolStripMenuItem
			// 
			this.rELATÓRIOToolStripMenuItem.Name = "rELATÓRIOToolStripMenuItem";
			this.rELATÓRIOToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.rELATÓRIOToolStripMenuItem.Text = "RELATÓRIO";
			// 
			// toolStripButton_conf
			// 
			this.toolStripButton_conf.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton_conf.AutoSize = false;
			this.toolStripButton_conf.Font = new System.Drawing.Font("Segoe UI", 7F);
			this.toolStripButton_conf.Image = global::EterPharmaPro.Properties.Resources.configuracao;
			this.toolStripButton_conf.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_conf.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton_conf.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_conf.Name = "toolStripButton_conf";
			this.toolStripButton_conf.Size = new System.Drawing.Size(90, 90);
			this.toolStripButton_conf.Tag = "CONFIGURAÇÕES";
			this.toolStripButton_conf.Text = "CONFIGURAÇÕES";
			this.toolStripButton_conf.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_conf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripButton_conf.ToolTipText = "CONFIGURAÇÕES";
			// 
			// toolStripDropDownButton_impressos
			// 
			this.toolStripDropDownButton_impressos.AutoSize = false;
			this.toolStripDropDownButton_impressos.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.toolStripDropDownButton_impressos.Image = global::EterPharmaPro.Properties.Resources.papel_impresso;
			this.toolStripDropDownButton_impressos.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripDropDownButton_impressos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripDropDownButton_impressos.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton_impressos.Name = "toolStripDropDownButton_impressos";
			this.toolStripDropDownButton_impressos.Size = new System.Drawing.Size(90, 90);
			this.toolStripDropDownButton_impressos.Tag = "IMPRESSOS";
			this.toolStripDropDownButton_impressos.Text = "IMPRESSOS";
			this.toolStripDropDownButton_impressos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripDropDownButton_impressos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripDropDownButton_impressos.ToolTipText = "IMPRESSOS";
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 90);
			this.toolStripButton2.Text = "toolStripButton2";
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.panel_center);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ETER PHARMA PRO";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel_center;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripDropDownButton toolStripButton_manipulacao;
		private System.Windows.Forms.ToolStripMenuItem fORMUToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rELATÓRIOToolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
		private System.Windows.Forms.ToolStripMenuItem gERARVALIDADEDOMÊSToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rELATÓRIOToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton toolStripButton_conf;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton toolStripDropDownButton_impressos;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
	}
}

