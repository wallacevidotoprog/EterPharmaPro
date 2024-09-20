using EterPharmaPro.Controllers.Validade;
using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.DbProdutos.Services;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Properties;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro.Views.Validade
{
	public partial class CreateValidade : Form
	{
		private readonly IEterDb eterDb;
		private readonly ValidadeController validadeController;

		private SetValityModel setValityModel;

		bool isActionValidade = false;
		bool isEditProduto = false;


		public CreateValidade(IEterDb _eterDb, DatabaseProdutosDb _databaseProdutosDb)
		{
			InitializeComponent();
			eterDb = _eterDb;
			validadeController = new ValidadeController(eterDb, _databaseProdutosDb);
		}

		private void CreateValidade_Load(object sender, EventArgs e)
		{
			comboBox_user.Invoke((Action)async delegate
			{
				await comboBox_user.CBListUserAsync(eterDb);
			});
		}

		private void toolStripButton_exit_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Deseja sair o formulário ?", base.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.Close();
			}
		}

		private void VisibleHeaderDoc(bool state)
		{
			groupBox_ne.Visible = state;
			comboBox_user.Enabled = state;
			dateTimePicker_dataD.Enabled = state;
			dateTimePicker_dataD.Value = DateTime.Today;


			groupBox_ne.Size = state ? new Size(566, 88) : new Size(566, 315);
			comboBox_user.Enabled = state;
			dateTimePicker_dataD.Enabled = state;
		}

		private void VisibleBodyDoc(bool state)
		{
			groupBox_ne.Size = state ? new Size(566, 315) : new Size(566, 88);
			groupBox_insert.Visible = state;
			comboBox_user.Enabled = !state;
			dateTimePicker_dataD.Enabled = !state;
			listView1.Items.Clear();
		}

		private void NewDocValidade(bool stats)
		{
			VisibleHeaderDoc(stats);
			VisibleBodyDoc(!stats);
		}

		private void toolStripDropDownButton_new_Click(object sender, EventArgs e)
		{
			if (isActionValidade)
			{
				if (MessageBox.Show("Existe um arquivo aberto, deseja fecha-lo ?\n(As alterações serão salvas)", "ALERTA", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel)
				{

				}
			}
			NewDocValidade(true);
		}

		private async void ePictureBox_create_Click(object sender, EventArgs e)
		{
			VisibleBodyDoc(true);
			isActionValidade = true;

			this.Focus();

			setValityModel = new SetValityModel();
			setValityModel.user_id = Convert.ToInt32(comboBox_user.SelectedValue);
			setValityModel.dataCreate = dateTimePicker_dataD.Value;

			setValityModel.vality_id = await validadeController.CreateNewDocVality(setValityModel);

			await comboBox_categoria.CBListCategoryAsync(await validadeController.GetCategoryUser(setValityModel.user_id));
		}

		private async void ePictureBox_addCat_ClickAsync(object sender, EventArgs e) { await validadeController.CreateCategory(setValityModel.user_id); }

		private async void ePictureBox_removeCat_ClickAsync(object sender, EventArgs e) { await validadeController.DeleteCategory(setValityModel.user_id); }

		private void textBox_codigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				if (textBox_codigo.Text.Trim().Replace(" ", null) == "")
				{
					List<ProdutosModel> tempQuery = validadeController.GetAllProdutos();
					textBox_codigo.Text = tempQuery == null ? string.Empty : InputListProduto.Show(tempQuery, "Busca de Produtos");
				}
				GetProduct();
			}
		}
		private bool GetProduct()
		{
			bool tempBool = false;
			try
			{
				ProdutosModel tempProdutos = validadeController.GetProduto(textBox_codigo.Text);

				if (tempProdutos != null)
				{
					textBox_nproduto.Text = tempProdutos.DESCRICAO_PRODUTO;

					tempBool = (textBox_nproduto.ReadOnly = true);
					numericUpDown_qtd.Focus();
				}
				else
				{
					MessageBox.Show("Código não encontrado.\nDigite o nome do produto no campo a baixo do código.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					textBox_nproduto.ReadOnly = false;
					textBox_nproduto.Focus();
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return tempBool;
		}

		private async void ePictureBox_sava_up_Click(object sender, EventArgs e)
		{
			this.Focus();

			try
			{
				if (setValityModel.produto == null)
				{
					setValityModel.produto = new ProdutoSetValityModel();
				}

				setValityModel.produto.codigo = Convert.ToInt32(textBox_codigo.Text);
				setValityModel.produto.descricao = textBox_nproduto.Text;
				setValityModel.produto.quantidade = (int)numericUpDown_qtd.Value;
				setValityModel.produto.dateVality = dateTimePicker_data.Value;
				setValityModel.produto.category_id = Convert.ToInt32(comboBox_categoria.SelectedValue);

				bool isSetClear = false;

				if (!isEditProduto)
				{
					(bool result, long id) = await validadeController.CreateProdutoVality(setValityModel.produto);
					if (result)
					{
						setValityModel.produto.id = id;
					}

					isSetClear = result;
				}
				else if (isEditProduto)
				{
					isSetClear = await validadeController.UpdateProdutoVality(setValityModel.produto);
				}


				if (isSetClear)
				{
					setValityModel.produto = null;
					textBox_codigo.Clear();
					textBox_nproduto.Clear();
					textBox_nproduto.ReadOnly = true;
					numericUpDown_qtd.Value = 1;
					dateTimePicker_data.Value = DateTime.Today;
				}


			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
		}

		private void toolStripButton_clear_Click(object sender, EventArgs e)
		{
			setValityModel.produto = null;
			textBox_codigo.Clear();
			textBox_nproduto.Clear();
			textBox_nproduto.ReadOnly = true;
			numericUpDown_qtd.Value = 1;
			dateTimePicker_data.Value = DateTime.Today;
		}

		private void eDITARToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (listView1.SelectedItems.Count > 0)
				{
					int selectedItem =  int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
					isEditProduto = true;
					setValityModel.produto = new ProdutoSetValityModel();
					//pictureBox_addItem.Image = Resources.atualizar_ficheiro;

					setValityModel.produto.id = Convert.ToUInt32(listView1.SelectedItems[0].SubItems[0].Text);
					textBox_codigo.Text = setValityModel.produto.codigo = listView1.SelectedItems[0].SubItems[0].Text;
					textBox_nproduto.Text = setValityModel.produto.codigo = listView1.SelectedItems[0].SubItems[0].Text;
					numericUpDown_qtd.Value = setValityModel.produto.codigo = listView1.SelectedItems[0].SubItems[0].Text;
					dateTimePicker_data.Value = setValityModel.produto.codigo = listView1.SelectedItems[0].SubItems[0].Text;
					comboBox_categoria.SelectedIndex = vsetValityModel.produto.codigo = listView1.SelectedItems[0].SubItems[0].Text;
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
		}

		private void eXCLUIRToolStripMenuItem_Click(object sender, EventArgs e)
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
					validade.PRODUTOS.RemoveAt(temp);
					for (int i = 0; i < validade.PRODUTOS.Count; i++)
					{
						validade.PRODUTOS[i].ID = i;
					}
					RefrashGrid();
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
		}
	}
}
