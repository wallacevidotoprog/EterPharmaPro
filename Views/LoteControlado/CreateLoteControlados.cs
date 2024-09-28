using EterPharmaPro.Controllers.CarimboLoteValidade;
using EterPharmaPro.Controllers.Validade;
using EterPharmaPro.DbProdutos.Services;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace EterPharmaPro.Views.LoteControlado
{
	public partial class CreateLoteControlados : Form
	{
		private readonly CreateLoteControladosController controladosController;
		private ControladoLoteModel controladoLoteModel;
		private List<MedicamentosControladoLoteModel> medicamentosControladoLoteModel;
		private ProdutosModel tempProdutosModel;
		private ClienteModel ClienteModel;
		private ToolTip toolTip;

		public CreateLoteControlados(IEterDb eterDb, DatabaseProdutosDb databaseProdutosDb)
		{
			controladosController = new CreateLoteControladosController(eterDb, databaseProdutosDb);
			InitializeComponent();
			numericUpDown_qtd.Value = 1m;
			toolTip = new ToolTip();


		}

		private async void textBox_end_KeyDownAsync(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F10)
			{
				string tempCEP = InputBox.Show("Digite o CEP:", "Buscar endereço por CEP");
				if (tempCEP != string.Empty)
				{
					AddressHttpModel temResp = await ExtensionsDefault.BuscaCepAsync(tempCEP);
					textBox_end.Text = ((temResp != null) ? (temResp.logradouro + ", N°: ," + temResp.bairro + ", " + temResp.localidade + "-" + temResp.uf) : string.Empty);
				}
			}
		}

		private void textBox_medicamento_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (!controladosController.CheckingLoadDbProd())
				{
					string codigo = string.Empty;

					if (textBox_medicamento.Text.Trim().Replace(" ", null) == "")
					{
						List<ProdutosModel> tempQuery = controladosController.GetAllProdutos();
						textBox_medicamento.Text = tempQuery == null ? string.Empty : InputListProduto.Show(tempQuery, "Busca de Produtos").ToString();
					}
					if (textBox_medicamento.Text.Trim().Replace(" ", null) == "")
					{
						return;
					}
					tempProdutosModel = controladosController.GetProduto(textBox_medicamento.Text.Trim());
					textBox_medicamento.Clear();
					
					textBox_medicamento.Text = (tempProdutosModel is null)? string.Empty: tempProdutosModel.DESCRICAO_PRODUTO;
					textBox_lote.Focus();

				}
				else
				{

				}
			}
		}

		private void ePictureBox1_Click(object sender, EventArgs e)
		{
			medicamentosControladoLoteModel = medicamentosControladoLoteModel ?? new List<MedicamentosControladoLoteModel>();
			var med = new MedicamentosControladoLoteModel
			{
				CODIGO_MED = (tempProdutosModel is null) ? string.Empty : tempProdutosModel.COD_PRODUTO,
				NOME_MED = textBox_medicamento.Text.ToUpper(),
				QUANTIDADE = (int)numericUpDown_qtd.Value,
				DATA_VALIDADE = dateTimePicker_validade.Value,
				LOTE = textBox_lote.Text.ToUpper()
			};
			medicamentosControladoLoteModel.Add(med);
			RefreshListViwe(med, ListViewActionsEnum.ADD);
			tempProdutosModel = null;
			ClearInserMedicamento();



		}

		private void toolStripDropDownButton_clear_Click(object sender, EventArgs e)
		{
			textBox_nome.Clear();
			textBox_end.Clear();
			textBox_rg.Clear();
			textBox_cel.Clear();
			textBox_medicamento.Clear();
			numericUpDown_qtd.Value = 1m;
			dateTimePicker_validade.Value = DateTime.Today;
			textBox_lote.Clear();
			listView1.Items.Clear();
			controladoLoteModel = null;
			medicamentosControladoLoteModel = null;
			textBox_rg.ButtonVisible = true;
		}

		private void toolStripButton_print_Click(object sender, EventArgs e)
		{

		}

		private void eXCLUIRToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (listView1.SelectedItems.Count > 0)
				{
					int temp = listView1.SelectedItems[0].Index;
					if (MessageBox.Show("Deseja excluir esse item ?\n" + listView1.SelectedItems[0]?.SubItems[0].Text, "Excluir Item", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK && temp >= 0)
					{
						medicamentosControladoLoteModel.RemoveAt(temp);
						RefreshListViwe(temp, ListViewActionsEnum.REMOVE);
					}
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
		}

		public void RefreshListViwe(object data, ListViewActionsEnum listViewActionsEnum = ListViewActionsEnum.NONE)
		{
			switch (listViewActionsEnum)
			{
				case ListViewActionsEnum.ADD:
					MedicamentosControladoLoteModel tempDataAdd = data as MedicamentosControladoLoteModel;

					ListViewItem item = new ListViewItem(tempDataAdd.CODIGO_MED);
					item.SubItems.Add(tempDataAdd.NOME_MED);
					item.SubItems.Add(tempDataAdd.QUANTIDADE.ToString());
					item.SubItems.Add(tempDataAdd.DATA_VALIDADE.ToShortDateString());
					item.SubItems.Add(tempDataAdd.LOTE);
					listView1.Items.Add(item);
					break;
				case ListViewActionsEnum.REMOVE:
					int tempDataDel = (int)data;
					listView1.Items.Remove(listView1.SelectedItems[0]);
					break;
			}
		}

		public void ClearInserMedicamento()
		{
			textBox_medicamento.Clear();
			numericUpDown_qtd.Value = 1m;
			dateTimePicker_validade.Value = DateTime.Today;
			textBox_lote.Clear();
			textBox_medicamento.Focus();
		}

		private void textBox_rg_ButtonClick(object sender, EventArgs e)
		{
			if (!(ClienteModel is null))
			{
				textBox_nome.Text = ClienteModel.NOME;
				textBox_cel.Text = ClienteModel.TELEFONE;

				if (ClienteModel.ENDERECO is null)
				{
					return;
				}

				List<EnderecoClienteModel> enderecoClienteModels = ClienteModel.ENDERECO as List<EnderecoClienteModel>;

				if (enderecoClienteModels.Count == 0)
				{
					return;
				}
				if (enderecoClienteModels.Count == 1)
				{
					textBox_end.Text = enderecoClienteModels[0].ENDERECO;
					return;
				}
				var tempEnd = new object[enderecoClienteModels.Count];
				for (int i = 0; i < tempEnd.Length; i++)
				{
					tempEnd[i] = new object[2]
					{
					i,
					enderecoClienteModels[i].ENDERECO
					};
				}
				var retList = InputList.Show(tempEnd, "Enderecos Cliente");
				if (retList != -1)
				{
					textBox_end.Text = enderecoClienteModels[retList].ENDERECO;
				}
			}
		}

		private async void textBox_rg_TexBoxValidated(object sender, EventArgs e)
		{
			textBox_rg.Text = textBox_rg.Text.ReturnFormation(FormatationEnum.RG);
			ClienteModel = (textBox_rg.Text.Trim().Replace(" ", null) != string.Empty) ? await controladosController.GetCliente(textBox_rg.Text.ReturnInt()) : null;
			textBox_rg.ButtonVisible = (!(ClienteModel is null)) ? true : false;
		}

		private void textBox_cel_Validated(object sender, EventArgs e) => textBox_cel.Text = textBox_cel.Text.ReturnFormation(FormatationEnum.TELEFONE);
	}
}
