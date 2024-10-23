namespace EterPharmaPro.Views.Configuracoes
{
	partial class ConfigsPage
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
			this.toolStripDropDownButton_produto = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton_user = new System.Windows.Forms.ToolStripButton();
			this.toolStrip_topMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip_topMenu
			// 
			this.toolStrip_topMenu.BackColor = System.Drawing.Color.WhiteSmoke;
			this.toolStrip_topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_exit,
            this.toolStripDropDownButton_produto,
            this.toolStripButton_user});
			this.toolStrip_topMenu.Location = new System.Drawing.Point(0, 0);
			this.toolStrip_topMenu.Name = "toolStrip_topMenu";
			this.toolStrip_topMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.toolStrip_topMenu.Size = new System.Drawing.Size(1220, 93);
			this.toolStrip_topMenu.TabIndex = 5;
			this.toolStrip_topMenu.Text = "toolStrip1";
			// 
			// panel_center
			// 
			this.panel_center.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_center.Location = new System.Drawing.Point(0, 93);
			this.panel_center.Name = "panel_center";
			this.panel_center.Size = new System.Drawing.Size(1220, 511);
			this.panel_center.TabIndex = 6;
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
			// toolStripDropDownButton_produto
			// 
			this.toolStripDropDownButton_produto.AutoSize = false;
			this.toolStripDropDownButton_produto.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.toolStripDropDownButton_produto.Image = global::EterPharmaPro.Properties.Resources.inventario;
			this.toolStripDropDownButton_produto.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripDropDownButton_produto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripDropDownButton_produto.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton_produto.Name = "toolStripDropDownButton_produto";
			this.toolStripDropDownButton_produto.Size = new System.Drawing.Size(90, 90);
			this.toolStripDropDownButton_produto.Tag = "";
			this.toolStripDropDownButton_produto.Text = "PRODUTOS";
			this.toolStripDropDownButton_produto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripDropDownButton_produto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripDropDownButton_produto.ToolTipText = "PRODUTOS";
			this.toolStripDropDownButton_produto.Click += new System.EventHandler(this.toolStripDropDownButton_produto_Click);
			// 
			// toolStripButton_user
			// 
			this.toolStripButton_user.AutoSize = false;
			this.toolStripButton_user.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.toolStripButton_user.Image = global::EterPharmaPro.Properties.Resources.user;
			this.toolStripButton_user.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_user.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripButton_user.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton_user.Name = "toolStripButton_user";
			this.toolStripButton_user.Size = new System.Drawing.Size(90, 90);
			this.toolStripButton_user.Tag = "";
			this.toolStripButton_user.Text = "USUÁRIO";
			this.toolStripButton_user.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.toolStripButton_user.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripButton_user.ToolTipText = "USUÁRIO";
			this.toolStripButton_user.Click += new System.EventHandler(this.toolStripButton_user_Click);
			// 
			// ConfigsPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1220, 604);
			this.Controls.Add(this.panel_center);
			this.Controls.Add(this.toolStrip_topMenu);
			this.Name = "ConfigsPage";
			this.Text = "Configs";
			this.Load += new System.EventHandler(this.ConfigsPage_Load);
			this.toolStrip_topMenu.ResumeLayout(false);
			this.toolStrip_topMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip_topMenu;
		private System.Windows.Forms.ToolStripButton toolStripButton_exit;
		private System.Windows.Forms.ToolStripButton toolStripDropDownButton_produto;
		private System.Windows.Forms.ToolStripButton toolStripButton_user;
		private System.Windows.Forms.Panel panel_center;
	}
}