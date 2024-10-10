using EterPharmaPro.Controllers.Manipulacao;
using EterPharmaPro.Controllers.Validade;
using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.eControl;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro.Views.Manipulados
{
	public partial class ReportManipulacao : Form
	{
		private readonly IEterDb eterDb;
		private readonly ManipuladoController manipuladoController;

		private List<ManipulacaoModel> manipulacaoModelsBusca;
		public ReportManipulacao(IEterDb eterDb)
		{
			InitializeComponent();
			this.eterDb = eterDb;
			manipuladoController = new ManipuladoController(eterDb);
		}

		private void toolStrip_topMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) => this.Close();

		private async void ReportManipulacao_Load(object sender, EventArgs e)
		{
			await comboBox_user.CBListUserAsync(eterDb);

		}

		private async void ePictureBox_seach_Click(object sender, EventArgs e)
		{
			this.Focus();
			manipulacaoModelsBusca = await manipuladoController.GetManipulacao(Convert.ToUInt32(comboBox_user.SelectedValue));
			RefreshGrid(manipulacaoModelsBusca);
		}

		private void RefreshGrid(List<ManipulacaoModel> query)
		{
			ListViewItem item = null;
			listView1.Items.Clear();
			for (int i = 0; i < query.Count; i++)
			{

				item = new ListViewItem(query[i].ID.ToString());
				item.SubItems.Add(query[i].DADOSATENDIMENTO.ATEN_LOJA_NAME);
				item.SubItems.Add(query[i].DADOSATENDIMENTO.DATA?.ToShortDateString());
				item.SubItems.Add(query[i].DADOSCLIENTE.ToString());
				item.SubItems.Add(string.Format(CultureInfo.CurrentCulture, "{0:C2}", query[i].VALORFINAL));
				item.SubItems.Add(query[i].OBSGERAL.ToString());
				listView1.Items.Add(item);
			}

		}

		private void dateTimePicker_dataBusca_ValueChanged(object sender, EventArgs e)
		{
			RefreshGrid(manipulacaoModelsBusca.Where(x => x.DADOSATENDIMENTO.DATA?.ToShortDateString() == dateTimePicker_dataBusca.Value.ToShortDateString()).ToList()) ;
		}

		private void eDITARToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (listView1.SelectedItems.Count > 0)
				{
					ProdutoValidadeDbModal tempProduto = await validadeController.GetProdutoDb(listView1.SelectedItems[0].SubItems[0].Text);
					if (tempProduto != null)
					{
						isEditProduto = true;
						setValityModel.produto = new ProdutoSetValityModel();
						indexEditLv = Convert.ToInt32(listView1.SelectedItems[0].Index);
						setValityModel.produto.id = tempProduto.ID;
						textBox_codigo.Text = (setValityModel.produto.codigo = tempProduto.PRODUTO_CODIGO).ToString().PadLeft(6, '0');
						textBox_nproduto.Text = setValityModel.produto.descricao = tempProduto.PRODUTO_DESCRICAO;
						numericUpDown_qtd.Value = setValityModel.produto.quantidade = Convert.ToInt32(tempProduto.QUANTIDADE);
						dateTimePicker_data.Value = setValityModel.produto.dateVality = Convert.ToDateTime(tempProduto.DATA_VALIDADE);
						setValityModel.produto.category_id = Convert.ToInt32(tempProduto.CATEGORIA_ID);
						comboBox_categoria.SelectedIndex = comboBox_categoria.ReturnIndexCategoryCB(setValityModel.produto.category_id);

						ePictureBox_sava_up.Image = Resources.arquivo_update;
					}

				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
		}

		private void eXCLUIRToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (eterDb.UserModelAcess.FUNCAO == "DEV" || eterDb.UserModelAcess.FUNCAO == "ADMIN" || eterDb.UserModelAcess.FUNCAO == "GERENTE")
			{
				try
				{
					if (listView1.SelectedItems.Count <= 0)
					{
						return;
					}
					int temp = int.Parse(listView1.SelectedItems[0]?.SubItems[0].Text);
					if (MessageBox.Show("Deseja excluir esse item ?\n" + listView1.SelectedItems[0]?.SubItems[3].Text, "Excluir Item", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK && temp >= 0)
					{
						if (await validadeController.DeleteProduto(temp))
						{
							ListViewAction(listView1.SelectedItems[0], ListViewActionsEnum.REMOVE);
						}

					}
				}
				catch (Exception ex)
				{
					ex.ErrorGet();
				}
			}
			else
			{
				MessageBox.Show("Você não tem permissão.");
			}
		}
	}
}
