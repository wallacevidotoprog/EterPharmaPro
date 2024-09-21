using EterPharmaPro.Controllers.Validade;
using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.DbProdutos.Services;
using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Properties;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
			setValityModel.user_id = Convert.ToUInt32(comboBox_user.SelectedValue);
			setValityModel.dataCreate = dateTimePicker_dataD.Value;

			setValityModel.vality_id = await validadeController.CreateNewDocVality(setValityModel);

			await comboBox_categoria.CBListCategoryAsync(await validadeController.GetCategoryUser(setValityModel.user_id));
			listView1.Groups.Add(new ListViewGroup(1.ToString(), "SEM CATEGORIA"));
			RefreshCategoryAsync();
		}

		private async void ePictureBox_addCat_ClickAsync(object sender, EventArgs e)
		{
			string result = InputBox.Show("Por favor, insira a categoria:", "Categoria");
			if (result != "")
			{
				await validadeController.CreateCategory(setValityModel.user_id, result);
				await comboBox_categoria.CBListCategoryAsync(await validadeController.GetCategoryUser(setValityModel.user_id));
				RefreshCategoryAsync();
			}

		}

		private async void ePictureBox_removeCat_ClickAsync(object sender, EventArgs e)
		{
			if (await validadeController.DeleteCategory((int)setValityModel.user_id))
			{
				await comboBox_categoria.CBListCategoryAsync(await validadeController.GetCategoryUser(setValityModel.user_id));

				//sql => renomear e troca para id 1
				//viwe => remover e troca para id 1

			}

		}

		private async void RefreshCategoryAsync()
		{
			var temp = await validadeController.GetCategoryUser(setValityModel.user_id);
			for (int i = 0; i < temp.Count; i++)
			{
				var groupAd = listView1.Groups.Cast<ListViewGroup>().Where(x => x.Header == temp[i].NAME).FirstOrDefault();
				if (groupAd is null)
				{
					listView1.Groups.Add(new ListViewGroup(temp[i].ID.ToString(), temp[i].NAME));

				}
				
			}
			
		}

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

				setValityModel.produto = setValityModel.produto ?? new ProdutoSetValityModel();

				setValityModel.produto.codigo = Convert.ToInt32(textBox_codigo.Text);
				setValityModel.produto.descricao = textBox_nproduto.Text;
				setValityModel.produto.quantidade = (int)numericUpDown_qtd.Value;
				setValityModel.produto.dateVality = dateTimePicker_data.Value;
				setValityModel.produto.category_id = Convert.ToInt32(comboBox_categoria.SelectedValue);

				bool isSetClear = false;

				if (!isEditProduto)
				{
					(bool result, long? id) = await validadeController.CreateProdutoVality(setValityModel);
					if (result)
					{
						setValityModel.produto.id = id;

						ListViewAction(setValityModel.produto, ListViewActionsEnum.ADD);
					}

					isSetClear = result;
				}
				else if (isEditProduto)
				{
					isSetClear = await validadeController.UpdateProdutoVality(setValityModel);
					isEditProduto = false;
					if (isSetClear)
					{
						ListViewAction(setValityModel.produto, ListViewActionsEnum.UPDATE);
					}
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

		private async void eDITARToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (listView1.SelectedItems.Count > 0)
				{
					ProdutoValidadeDbModal tempProduto = await validadeController.GetProdutoDb(listView1.SelectedItems[0].SubItems[0].Text);
					if (tempProduto!= null)
					{
						isEditProduto = true;
						setValityModel.produto = new ProdutoSetValityModel();
						setValityModel.produto.id = tempProduto.ID;
						textBox_codigo.Text = (setValityModel.produto.codigo = tempProduto.PRODUTO_CODIGO).ToString().PadLeft(6, '0');
						textBox_nproduto.Text = setValityModel.produto.descricao = tempProduto.PRODUTO_DESCRICAO;
						numericUpDown_qtd.Value = setValityModel.produto.quantidade = Convert.ToInt32(tempProduto.QUANTIDADE);
						dateTimePicker_data.Value = setValityModel.produto.dateVality = Convert.ToDateTime(tempProduto.DATA_VALIDADE);
						comboBox_categoria.SelectedIndex = setValityModel.produto.category_id = Convert.ToInt32(tempProduto.CATEGORIA_ID);
					}

				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
		}

		private async void eXCLUIRToolStripMenuItem_ClickAsync(object sender, EventArgs e)
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

		private async void ListViewAction(object action, ListViewActionsEnum actionsEnum = ListViewActionsEnum.NONE)
		{
			ListViewItem item = null;
			try
			{
				switch (actionsEnum)
				{
					case ListViewActionsEnum.ADD:
						ProdutoSetValityModel tempObjAd = (ProdutoSetValityModel)action;


						var groupAd = listView1.Groups.Cast<ListViewGroup>().Where(x => x.Header == comboBox_categoria.Text).FirstOrDefault();//se não tiver add

						groupAd = groupAd ?? listView1.Groups.Cast<ListViewGroup>().Where(x => x.Header == "SEM CATEGORIA").FirstOrDefault();



						item = new ListViewItem(tempObjAd.id.ToString());
						item.SubItems.Add(tempObjAd.codigo.ToString().PadLeft(6, '0'));
						item.SubItems.Add(tempObjAd.descricao);
						item.SubItems.Add(tempObjAd.quantidade.ToString());
						item.SubItems.Add(tempObjAd.dateVality.ToString("dd/MM/yyyy"));
						item.Group = groupAd;
						listView1.Items.Add(item);

						break;
					case ListViewActionsEnum.UPDATE:
						(int indexUp, ProdutoSetValityModel newUp) tempObjUp = ((int indexUp, ProdutoSetValityModel newUp))action;
						listView1.Items[tempObjUp.indexUp].Text = tempObjUp.newUp.id.ToString();
						listView1.Items[tempObjUp.indexUp].SubItems[1].Text = tempObjUp.newUp.codigo.ToString().PadLeft(6, '0');
						listView1.Items[tempObjUp.indexUp].SubItems[2].Text = tempObjUp.newUp.descricao.ToString();
						listView1.Items[tempObjUp.indexUp].SubItems[3].Text = tempObjUp.newUp.quantidade.ToString();
						listView1.Items[tempObjUp.indexUp].SubItems[4].Text = tempObjUp.newUp.dateVality.ToString();
						break;
					case ListViewActionsEnum.REMOVE:
						listView1.Items.Remove((ListViewItem)action);//listView1.Items[0]
						break;
					case ListViewActionsEnum.UPGRADE:
						List<ProdutoValidadeDbModal> tempObjUg = (List<ProdutoValidadeDbModal>)action;

						List<(int cat_id, string cat_name)> tempCategoriasSelect = await validadeController.GetCategoryList(tempObjUg.GroupBy(p => p.CATEGORIA_ID).Select(g => g.Key).ToList());


						for (int i = 0; i < tempCategoriasSelect.Count; i++)
						{
							ListViewGroup groupUp = new ListViewGroup(tempCategoriasSelect[i].cat_name, HorizontalAlignment.Left);
							listView1.Groups.Add(groupUp);

							List<ProdutoValidadeDbModal> tp = tempObjUg.Where(x => x.CATEGORIA_ID == tempCategoriasSelect[i].cat_id).ToList();

							for (int x = 0; x < tp.Count; x++)
							{
								item = new ListViewItem(tp[x].ID.ToString());
								item.SubItems.Add(tp[x].PRODUTO_CODIGO.ToString().PadLeft(6, '0'));
								item.SubItems.Add(tp[x].PRODUTO_DESCRICAO);
								item.SubItems.Add(tp[x].QUANTIDADE.ToString());
								item.SubItems.Add(tp[x].DATA_VALIDADE.ToString("dd/MM/yyyy"));
								item.Group = groupUp;
								listView1.Items.Add(item);
							}
						}
						break;
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}

		}
	}
}
