using EterPharmaPro.Controllers.Validade;
using EterPharmaPro.DbProdutos.Services;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro.Views.Validade
{
	public partial class ReportValidades : Form
	{
		private readonly IEterDb eterDb;
		private readonly ValidadeController validadeController;

		List<ProdutoValidadeDbModal> produtoValidadeDbs;
		public ReportValidades(IEterDb eterDb, DatabaseProdutosDb databaseProdutosDb)
		{
			this.eterDb = eterDb;
			validadeController = new ValidadeController(eterDb, databaseProdutosDb);
			InitializeComponent();
		}

		private void ReportValidades_Load(object sender, EventArgs e)
		{
			DateTime timenew = dateTimePicker_ate.Value.AddMonths(4);
			dateTimePicker_ate.Value = timenew;
		}
		private void toolStripButton_exit_Click(object sender, EventArgs e) => this.Close();

		private async void ePictureBox_busca_ClickAsync(object sender, EventArgs e)
		{
			var t = await validadeController.GetValityDate(dateTimePicker_dataBusca.Value);
			if (t != null)
			{
				dataGridView_validadeFile.Rows.Clear();
				for (int i = 0; i < t.Count; i++)
				{
					dataGridView_validadeFile.Rows.Add(new object[]
					{
						t[i].id.ToString(),
						t[i].nameUser,
						t[i].date,
						true,
					});
				}
			}
		}

		private void dataGridView_validadeFile_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			bool temp = (bool)dataGridView_validadeFile.Rows[e.RowIndex].Cells[3].Value;
			dataGridView_validadeFile.Rows[e.RowIndex].Cells[3].Value = !temp;
		}

		private async void ePictureBox_import_Click(object sender, EventArgs e)
		{
			List<long> imports = new List<long>();

			for (int i = 0; i < dataGridView_validadeFile.Rows.Count; i++)
			{
				if ((bool)dataGridView_validadeFile.Rows[i].Cells[3].Value)
				{
					imports.Add(Convert.ToUInt32(dataGridView_validadeFile.Rows[i].Cells[0].Value));
				}
			}
			await ListViewImportsAsync(imports);

		}

		private async Task ListViewImportsAsync(List<long> imports)
		{
			listView_produtos.Items.Clear();
			listView_produtos.Groups.Clear();
			produtoValidadeDbs = new List<ProdutoValidadeDbModal>();
			try
			{
				ListViewItem item = null;
				for (int i = 0; i < imports.Count; i++)
				{
					var tempEditVality = await validadeController.GetEditVality(imports[i]);
					UserModel userModel = await validadeController.GetUser(tempEditVality.v.USER_ID);

					ListViewGroup group = new ListViewGroup($" Funcionário: [{userModel.ID_LOJA.ToString().PadLeft(4, '0')} - {userModel.NOME}]  |  Total de Itens: [{tempEditVality.p.Count}]", HorizontalAlignment.Left);
					listView_produtos.Groups.Add(group);
					for (int j = 0; j < tempEditVality.p.Count; j++)
					{
						produtoValidadeDbs.Add(tempEditVality.p[j]);

						item = new ListViewItem(tempEditVality.p[j].ID.ToString().PadLeft(6, '0'));
						item.SubItems.Add(tempEditVality.p[j].PRODUTO_CODIGO.ToString().PadLeft(6, '0'));
						item.SubItems.Add(tempEditVality.p[j].PRODUTO_DESCRICAO);
						item.SubItems.Add(tempEditVality.p[j].QUANTIDADE.ToString());
						item.SubItems.Add(tempEditVality.p[j].DATA_VALIDADE.ToString("dd/MM/yyyy"));
						item.Group = group;
						listView_produtos.Items.Add(item);
					}
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}


			dateTimePicker_de_ValueChanged(null, null);

		}

		private void dateTimePicker_de_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				for (int i = 0; i < listView_produtos.Items.Count; i++)
				{
					if (BetweenDate(listView_produtos.Items[i]))
					{
						listView_produtos.Items[i].BackColor = Color.FromArgb(255, 204, 204);
					}
					else
					{
						listView_produtos.Items[i].BackColor = Color.White;
					}
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
		}
		private bool BetweenDate(object value)
		{
			DateTime dateItem = DateTime.Now;
			if (value.GetType() == typeof(ListViewItem))
			{
				dateItem = Convert.ToDateTime(((ListViewItem)value).SubItems[4].Text);
			}
			else
			{
				dateItem = Convert.ToDateTime(value.ToString());
			}


			int fromMonth = dateTimePicker_de.Value.Month;
			int fromYear = dateTimePicker_de.Value.Year;
			int toMonth = dateTimePicker_ate.Value.Month;
			int toYear = dateTimePicker_ate.Value.Year;

			int itemMonth = dateItem.Month;
			int itemYear = dateItem.Year;

			if ((itemYear > fromYear || (itemYear == fromYear && itemMonth >= fromMonth)) &&
				(itemYear < toYear || (itemYear == toYear && itemMonth <= toMonth)))
			{
				return true;
			}

			return false;

		}

		private async void toolStripButton_excel_Click(object sender, EventArgs e)
		{
			try
			{
				SaveFileDialog op = new SaveFileDialog();

				op.FileName = "Listagem de validade de " + dateTimePicker_dataBusca.Value.ToString("MMMM-yyyy") + ".xlsx";
				op.Filter = "Excel Files|*.xlsx";
				op.Title = "Save an Excel File";
				if (op.ShowDialog() == DialogResult.OK)
				{
					await validadeController.ExportValityXLSX(produtoValidadeDbs, op.FileName);
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
		}

		private async void ePictureBox_export_ClickAsync(object sender, EventArgs e)
		{
			try
			{
				List<ProdutoValidadeDbModal> temp = produtoValidadeDbs.Where(x => BetweenDate(x.DATA_VALIDADE)).ToList();

				SaveFileDialog op = new SaveFileDialog();

				op.FileName = "Listagem de validade de " + dateTimePicker_dataBusca.Value.ToString("MMMM-yyyy") + ".xlsx";
				op.Filter = "Excel Files|*.xlsx";
				op.Title = "Save an Excel File";
				if (op.ShowDialog() == DialogResult.OK)
				{
					await validadeController.ExportValityXLSX(temp, op.FileName);
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
		}


		private void toolStripButton_clear_Click(object sender, EventArgs e)
		{
			listView_produtos.Items.Clear();
			listView_produtos.Groups.Clear();
			produtoValidadeDbs = null;
			dataGridView_validadeFile.Rows.Clear();
			dateTimePicker_dataBusca.Value = DateTime.Now.DateTimeDay();
			dateTimePicker_de.Value = DateTime.Now.DateTimeDay();
			DateTime timenew = dateTimePicker_ate.Value.DateTimeDay().AddMonths(4);
			dateTimePicker_ate.Value = timenew;
		}
	}
}
