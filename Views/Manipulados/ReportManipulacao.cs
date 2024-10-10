using EterPharmaPro.Controllers.Manipulacao;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
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
			manipulacaoModelsBusca = await manipuladoController.GetManipulacaoFromUser(Convert.ToUInt32(comboBox_user.SelectedValue));
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
			RefreshGrid(manipulacaoModelsBusca.Where(x => x.DADOSATENDIMENTO.DATA?.ToShortDateString() == dateTimePicker_dataBusca.Value.ToShortDateString()).ToList());
		}

		private async void eDITARToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (listView1.SelectedItems.Count > 0)
				{
					var temp  = (await manipuladoController.GetManipulacao(Convert.ToUInt32(listView1.SelectedItems[0].SubItems[0].Text)));

					(new CreateManipulados(eterDb,temp)).ShowDialog();
					ePictureBox_seach_Click(null, null);
					//dateTimePicker_dataBusca_ValueChanged(null, null);
					
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
		}

		private async void eXCLUIRToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (eterDb.UserModelAcess.FUNCAO_NAME == "DEV" || eterDb.UserModelAcess.FUNCAO_NAME == "ADMIN" || eterDb.UserModelAcess.FUNCAO_NAME == "GERENTE")
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
						if (await manipuladoController.DeleteManipulacao(temp))
						{
							ePictureBox_seach_Click(null, null);
							//dateTimePicker_dataBusca_ValueChanged(null, null);
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
