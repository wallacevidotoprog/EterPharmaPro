using EterPharmaPro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro.Utils.Extencions
{
	public class InputListProduto : Form
	{
		private List<ProdutosModel> objectsList;

		private IContainer components = null;

		private Label label3;

		private TextBox textBox_busca;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn Column3;
		private DataGridViewCheckBoxColumn Column4;
		private DataGridViewTextBoxColumn Column5;
		private DataGridViewTextBoxColumn Column6;
		private DataGridView dataGridView_dados;

		public static string inputIndex { get; private set; }

		public InputListProduto(List<ProdutosModel> objects, string title)
		{
			InitializeComponent();
			objectsList = objects;
			dataGridView_dados.DataSource = objects;
		}

		public static string Show(List<ProdutosModel> objects, string title)
		{
			using (InputListProduto inputBox = new InputListProduto(objects, title))
			{
				return (inputBox.ShowDialog() == DialogResult.OK) ? inputIndex : string.Empty;

			}
		}

		private void InputList_Load(object sender, EventArgs e)
		{
		}

		private async void textBox_busca_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(textBox_busca.Text))
				{
					dataGridView_dados.DataSource = objectsList;
					return;
				}
				string searchText = textBox_busca.Text.ToUpper();
				List<ProdutosModel> filteredList = await Task.Run(() => objectsList.Where((ProdutosModel x) => x.DESCRICAO_PRODUTO.ToUpper().Contains(searchText)).ToList());
				dataGridView_dados.DataSource = filteredList;
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				ex.ErrorGet();
			}
		}

		private void dataGridView_dados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.RowIndex != -1)
			{
				inputIndex = dataGridView_dados.Rows[e.RowIndex].Cells[1].Value.ToString();
				base.DialogResult = DialogResult.OK;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_busca = new System.Windows.Forms.TextBox();
			this.dataGridView_dados = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_dados)).BeginInit();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 25);
			this.label3.TabIndex = 14;
			this.label3.Text = "BUSCA:";
			// 
			// textBox_busca
			// 
			this.textBox_busca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_busca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox_busca.Font = new System.Drawing.Font("Microsoft Tai Le", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_busca.Location = new System.Drawing.Point(17, 37);
			this.textBox_busca.Name = "textBox_busca";
			this.textBox_busca.Size = new System.Drawing.Size(991, 33);
			this.textBox_busca.TabIndex = 13;
			this.textBox_busca.TextChanged += new System.EventHandler(this.textBox_busca_TextChanged);
			// 
			// dataGridView_dados
			// 
			this.dataGridView_dados.AllowUserToAddRows = false;
			this.dataGridView_dados.AllowUserToDeleteRows = false;
			this.dataGridView_dados.AllowUserToResizeColumns = false;
			this.dataGridView_dados.AllowUserToResizeRows = false;
			this.dataGridView_dados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView_dados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView_dados.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
			this.dataGridView_dados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.dataGridView_dados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.dataGridView_dados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
			this.dataGridView_dados.Cursor = System.Windows.Forms.Cursors.Hand;
			this.dataGridView_dados.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.dataGridView_dados.Location = new System.Drawing.Point(17, 76);
			this.dataGridView_dados.MultiSelect = false;
			this.dataGridView_dados.Name = "dataGridView_dados";
			this.dataGridView_dados.ReadOnly = true;
			this.dataGridView_dados.RowHeadersVisible = false;
			this.dataGridView_dados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dataGridView_dados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView_dados.Size = new System.Drawing.Size(991, 335);
			this.dataGridView_dados.TabIndex = 15;
			this.dataGridView_dados.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_dados_CellMouseDoubleClick);
			// 
			// Column1
			// 
			this.Column1.DataPropertyName = "EAN";
			this.Column1.FillWeight = 68.96552F;
			this.Column1.HeaderText = "EAN";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Visible = false;
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
			// Column4
			// 
			this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.Column4.DataPropertyName = "STATUS";
			this.Column4.HeaderText = "STATUS";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column4.Visible = false;
			this.Column4.Width = 56;
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
			this.Column5.Visible = false;
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
			this.Column6.Visible = false;
			// 
			// InputListProduto
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1020, 423);
			this.Controls.Add(this.dataGridView_dados);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox_busca);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InputListProduto";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "InputList";
			this.Load += new System.EventHandler(this.InputList_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_dados)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
