using EterPharmaPro.Controllers.Configs;
using EterPharmaPro.Enums;
using EterPharmaPro.Models;
using EterPharmaPro.Services.DbProdutos;
using EterPharmaPro.Services.XLSX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro.Views.Configuracoes
{
	public partial class Produtos : Form
	{
		private readonly ConfigsPageController configsPageController;
		private List<ProdutosModel> tempProdutos;
		private ReadProdutoXLSX readProdutoXLSX;

		public Produtos(ConfigsPageController configsPageController)
		{
			InitializeComponent();
			UpdateDb(false);
			this.configsPageController = configsPageController;
			dataGridView_dados.DataSource = configsPageController.GetAllProdutos();
			comboBox_tipo.SelectedIndex = 0;
			configsPageController.ReloadProd += ConfigsPageController_ReloadProd;
		}

		private void ConfigsPageController_ReloadProd(object sender, EventArgs e)
		{
			dataGridView_dados.DataSource = configsPageController.GetAllProdutos();
		}

		private void textBox_codigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				ePictureBox_busca_Click(null,null);
			}
		}

		private void ePictureBox_busca_Click(object sender, EventArgs e)
		{
			dataGridView_dados.DataSource = configsPageController.GetProdutos(textBox_codigo.Text, (QueryProdutoEnum)comboBox_tipo.SelectedIndex) ;
		}

		private async void ePictureBox_opFile_ClickAsync(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			try
			{
				openFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;
				openFileDialog.Multiselect = false;
				if (openFileDialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				textBox_contador.Text = "AGUARDE, LENDO ARQUIVO ...";
				// tempProdutos = new List<ProdutosModel>();

				if (Path.GetExtension(openFileDialog.FileName.ToUpper()).Contains("XLSX"))
				{
					readProdutoXLSX = new ReadProdutoXLSX();
					readProdutoXLSX.ProgressUpdated += ((pro) =>
					{

						textBox_contador?.Invoke((Action)delegate { textBox_contador.Text = $"LENDO [ {pro.Progress.ToString().PadLeft(pro.Max.ToString().Length, '0')} - {pro.Max} ]"; });
					});

					tempProdutos = await readProdutoXLSX.ReadAllProdutos(openFileDialog.FileName);

					textBox_contador.Text = $"TOTAL DE LINHAS LIDAS [{tempProdutos.Count} ]";
					UpdateDb(true);

				}
				
			}
			finally
			{
				if (openFileDialog != null)
				{
					((IDisposable)openFileDialog).Dispose();
				}
			}
		}

		private void ePictureBox_import_Click(object sender, EventArgs e)
		{
			if (!(tempProdutos is null))
			{
				ActionBinary.WriteProdutos(tempProdutos);
				configsPageController.RefreshProd();
				textBox_contador.Text = $"Produtos salvos.";
				dataGridView_dados.DataSource = configsPageController.GetAllProdutos();
			}
		}

		private void UpdateDb(bool stats)
		{
			if (stats)
			{
				ePictureBox_import.Cursor = Cursors.Hand;
			}
			else
			{
				ePictureBox_import.Cursor = Cursors.No;
			}


		}
	}
}
