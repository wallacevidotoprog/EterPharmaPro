using EterPharmaPro.Controllers.Configs;
using EterPharmaPro.DbProdutos.Services;
using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.Tag;
using EterPharmaPro.Services;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EterPharmaPro.Views
{
	public partial class TagViewer : Form
	{

		private List<PrintTagPriceModel> printTagPriceModels;
		private PrintTagValityService printTagVal;
		private ConfigsPageController configsPageController;
		private ProdutosModel produtoCurrent;

		public TagViewer(IEterDb eterDb, DatabaseProdutosDb databaseProdutos)
		{
			InitializeComponent();
			configsPageController = new ConfigsPageController(eterDb, databaseProdutos);

			printTagVal = new PrintTagValityService();
			printTagPriceModels = new List<PrintTagPriceModel>();
		}

		private void ePictureBox_gerar_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < printTagPriceModels.Count; i++)
			{
				printTagVal.Add(printTagPriceModels[i]);
			}
			printTagVal.Print();
		}

		private void dataGridView_validade_RowValidated(object sender, DataGridViewCellEventArgs e)
		{
			int rowIndex = e.RowIndex;
			int columnIndex = e.ColumnIndex;
			try
			{
				int index = Convert.ToInt32(dataGridView_validade.Rows[rowIndex].Cells[0].Value);
				decimal old = Convert.ToDecimal(dataGridView_validade.Rows[rowIndex].Cells[2].Value);
				decimal result = old - old * 0.3m;
				dataGridView_validade.Rows[rowIndex].Cells[2].Value = old.ToString("F2");
				dataGridView_validade.Rows[rowIndex].Cells[3].Value = result.ToString("F2");
				printTagPriceModels[index].OLD_PRICE = old;
				printTagPriceModels[index].NEW_PRICE = result;
			}
			catch (Exception)
			{
			}
		}

		private void dataGridView_validade_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == dataGridView_validade.Columns[5].Index && e.RowIndex >= 0)
			{
				dataGridView_validade.Rows.RemoveAt(e.RowIndex);
				printTagPriceModels.RemoveAt(e.RowIndex);
				RefrashGrid();
			}
		}

		private void RefrashGrid()
		{
			dataGridView_validade.Rows.Clear();
			for (int i = 0; i < printTagPriceModels.Count; i++)
			{
				dataGridView_validade.Rows.Add(i, printTagPriceModels[i].NAME_ITEM, printTagPriceModels[i].OLD_PRICE, printTagPriceModels[i].NEW_PRICE, printTagPriceModels[i].DATE_VALITY.ToShortDateString(), "DELETAR");
			}
		}

		private void textBox_produto_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{

				string codigo = string.Empty;

				if (textBox_produto.Text.Trim().Replace(" ", null) == "")
				{
					List<ProdutosModel> tempQuery = configsPageController.GetAllProdutos();

					string tempCod = tempQuery == null ? string.Empty : InputListProduto.Show(tempQuery, "Busca de Produtos").ToString();


					if (string.IsNullOrEmpty(tempCod)) return;


					produtoCurrent = configsPageController.GetProdutos(tempCod, QueryProdutoEnum.COD_INTERNO).FirstOrDefault();


					textBox_produto.Text = produtoCurrent?.DESCRICAO_PRODUTO;


				}
				else
				{
					produtoCurrent = configsPageController.GetProdutoCC(textBox_produto.Text.ReturnInt());


					textBox_produto.Text = produtoCurrent?.DESCRICAO_PRODUTO;
				}
				if (textBox_produto.Text.Trim().Replace(" ", null) == "")
				{
					return;
				}

				textBox_old.Focus();


			}
		}

		private void textBox_old_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
			{
				e.Handled = true;
			}
		}

		private void textBox_old_Validated(object sender, EventArgs e)
		{
			try
			{
				decimal old = Convert.ToDecimal(textBox_old.Text);
				decimal result = old - old * 0.3m;
				textBox_old.Text = old.ToString("F2");
				textBox_new.Text = result.ToString("F2");
			}
			catch (Exception)
			{
			}
		}

		private void pictureBox_addItem_Click(object sender, EventArgs e)
		{
			try
			{
				pictureBox_addItem.Focus();
				for (int i = 0; (decimal)i < numericUpDown_qtd.Value; i++)
				{
					printTagPriceModels.Add(new PrintTagPriceModel
					{
						PRODUTO = produtoCurrent,
						NAME_ITEM = textBox_produto.Text,
						OLD_PRICE = Convert.ToDecimal(textBox_old.Text),
						NEW_PRICE = Convert.ToDecimal(textBox_new.Text),
						DATE_VALITY = dateTimePicker_data.Value,
						TAG = new TableTagValidityModal(SizeTableTagEnum.PEQUENA)
					});
				}
				textBox_produto.Clear();
				textBox_old.Clear();
				textBox_new.Clear();
				numericUpDown_qtd.Value = 1m;
				textBox_produto.Focus();
				RefrashGrid();
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
		}

		private void toolStripButtons_sair_Click(object sender, EventArgs e) => this.Close();

		private void toolStripButton_clear_Click(object sender, EventArgs e)
		{
			printTagVal = new PrintTagValityService();
			printTagPriceModels = new List<PrintTagPriceModel>();
			textBox_produto.Clear();
			textBox_old.Clear();
			textBox_new.Clear();
			numericUpDown_qtd.Value = 1m;
			textBox_produto.Focus();
			dataGridView_validade.Rows.Clear();
		}
	}
}
