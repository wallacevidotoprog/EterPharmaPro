using EterPharmaPro.Controllers.Validade;
using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.DbProdutos.Services;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
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

		(int user_id, DateTime dataCreate, long vality_id) Autor;
		(string codigo,string descricao,int quantidade, DateTime dataCreate) tempProduto;

		bool isActionValidade = false;


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


			Autor = (Convert.ToInt32(comboBox_user.SelectedValue), dateTimePicker_dataD.Value, -1);

			Autor = await validadeController.CreateNewDocVality(Autor);

		}

		private async void ePictureBox_addCat_ClickAsync(object sender, EventArgs e) { await validadeController.CreateCategory(Autor.user_id); }

		private async void ePictureBox_removeCat_ClickAsync(object sender, EventArgs e) { await validadeController.DeleteCategory(Autor.user_id); }

		private void textBox_codigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				if (textBox_codigo.Text.Trim().Replace(" ",null) == "")
				{
					List<ProdutosModel> tempQuery = validadeController.GetAllProdutos();
					textBox_codigo.Text = tempQuery == null ? string.Empty: InputListProduto.Show(tempQuery, "Busca de Produtos");
				}
				else
				{
					GetProduct();
				}
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
					tempProduto.codigo = tempProdutos.COD_PRODUTO;
					tempProduto.descricao = textBox_nproduto.Text = tempProdutos.DESCRICAO_PRODUTO;


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
	}
}
