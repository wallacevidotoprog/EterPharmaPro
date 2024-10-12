namespace EterPharmaPro.Views
{
	partial class IMPRESSOS
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
			this.panel_center = new System.Windows.Forms.Panel();
			this.toolStripButton_exit = new System.Windows.Forms.ToolStripButton();
			this.toolStripDropDownButton_new = new System.Windows.Forms.ToolStripDropDownButton();
			this.lOTEVALIDAEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton_gerencial = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripMenuItem_remanejo = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip_topMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip_topMenu
			// 
			this.toolStrip_topMenu.BackColor = System.Drawing.Color.WhiteSmoke;
			this.toolStrip_topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_exit,
            this.toolStripDropDownButton_new,
            this.toolStripDropDownButton_gerencial});
			this.toolStrip_topMenu.Location = new System.Drawing.Point(0, 0);
			this.toolStrip_topMenu.Name = "toolStrip_topMenu";
			this.toolStrip_topMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.toolStrip_topMenu.Size = new System.Drawing.Size(800, 93);
			this.toolStrip_topMenu.TabIndex = 6;
			this.toolStrip_topMenu.Text = "toolStrip1";
			// 
			// panel_center
			// 
			this.panel_center.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_center.Location = new System.Drawing.Point(0, 93);
			this.panel_center.Name = "panel_center";
			this.panel_center.Size = new System.Drawing.Size(800, 357);
			this.panel_center.TabIndex = 7;
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
			// toolStripDropDownButton_new
			// 
			this.toolStripDropDownButton_new.AutoSize = false;
			this.toolStripDropDownButton_new.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lOTEVALIDAEToolStripMenuItem});
			this.toolStripDropDownButton_new.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.toolStripDropDownButton_new.Image = global::EterPharmaPro.Properties.Resources.carimboS;
			this.toolStripDropDownButton_new.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripDropDownButton_new.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripDropDownButton_new.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton_new.Name = "toolStripDropDownButton_new";
			this.toolStripDropDownButton_new.Size = new System.Drawing.Size(90, 90);
			this.toolStripDropDownButton_new.Tag = "";
			this.toolStripDropDownButton_new.Text = "CARIMBO";
			this.toolStripDropDownButton_new.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripDropDownButton_new.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripDropDownButton_new.ToolTipText = "CARIMBOS";
			// 
			// lOTEVALIDAEToolStripMenuItem
			// 
			this.lOTEVALIDAEToolStripMenuItem.Name = "lOTEVALIDAEToolStripMenuItem";
			this.lOTEVALIDAEToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
			this.lOTEVALIDAEToolStripMenuItem.Text = "LOTE VALIDAE";
			this.lOTEVALIDAEToolStripMenuItem.Click += new System.EventHandler(this.lOTEVALIDAEToolStripMenuItem_Click_1);
			// 
			// toolStripDropDownButton_gerencial
			// 
			this.toolStripDropDownButton_gerencial.AutoSize = false;
			this.toolStripDropDownButton_gerencial.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_remanejo});
			this.toolStripDropDownButton_gerencial.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.toolStripDropDownButton_gerencial.Image = global::EterPharmaPro.Properties.Resources.gerenciamento;
			this.toolStripDropDownButton_gerencial.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripDropDownButton_gerencial.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripDropDownButton_gerencial.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton_gerencial.Name = "toolStripDropDownButton_gerencial";
			this.toolStripDropDownButton_gerencial.Size = new System.Drawing.Size(90, 90);
			this.toolStripDropDownButton_gerencial.Tag = "";
			this.toolStripDropDownButton_gerencial.Text = "GERENCIAL";
			this.toolStripDropDownButton_gerencial.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripDropDownButton_gerencial.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripDropDownButton_gerencial.ToolTipText = "GERENCIAL";
			// 
			// toolStripMenuItem_remanejo
			// 
			this.toolStripMenuItem_remanejo.Name = "toolStripMenuItem_remanejo";
			this.toolStripMenuItem_remanejo.Size = new System.Drawing.Size(180, 22);
			this.toolStripMenuItem_remanejo.Text = "REMANEJO";
			this.toolStripMenuItem_remanejo.Click += new System.EventHandler(this.toolStripMenuItem_remanejo_Click);
			// 
			// IMPRESSOS
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.panel_center);
			this.Controls.Add(this.toolStrip_topMenu);
			this.Name = "IMPRESSOS";
			this.Text = "IMPRESSOS";
			this.toolStrip_topMenu.ResumeLayout(false);
			this.toolStrip_topMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip_topMenu;
		private System.Windows.Forms.ToolStripButton toolStripButton_exit;
		private System.Windows.Forms.Panel panel_center;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_new;
		private System.Windows.Forms.ToolStripMenuItem lOTEVALIDAEToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_gerencial;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_remanejo;
	}
}