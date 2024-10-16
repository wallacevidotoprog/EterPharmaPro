using EterPharmaPro.Controllers.Impressos;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Properties;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EterPharmaPro.Views.ReqNota
{
	public partial class ControleReqNota : Form
	{
		private RequisicaoNotasModel requisicaoNotas;
		private bool isNew = false;

		private readonly ControleReqNotaController controller;
		private readonly IEterDb eterDb;
		public ControleReqNota(IEterDb eterDb)
		{
			this.eterDb = eterDb;
			controller = new ControleReqNotaController(eterDb);
			InitializeComponent();
			ClearFieldReq();
		}

		private void ClearFieldReq()
		{
			comboBox_vend.SelectedIndex = -1;
			dateTimePicker_data.Value = DateTime.Today;
			textBox_req.Clear();
			dataGridView_reqs.Rows.Clear();
		}
		private void dataGridView_reqs_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{

				var temp = dataGridView_reqs.SelectedCells[0].RowIndex;
				dataGridView_reqs.Rows.RemoveAt(temp);
			}
		}

		private void ePictureBox_addR_Click(object sender, System.EventArgs e)
		{
			dataGridView_reqs.Rows.Add(new object[] { textBox_req.Text.ToUpper() });
			textBox_req.Clear();
			textBox_req.Focus();

		}

		private async void toolStripButton_new_save_Click(object sender, System.EventArgs e)
		{
			if (!isNew)
			{
				requisicaoNotas = new RequisicaoNotasModel();

				toolStripButton_new_save.Image = Resources.salve;
				toolStripButton_cancel.Visible = true;
				groupBox_addReq.Visible = true;
				toolStripButton_send.Visible = false;
				ClearFieldReq();
				isNew = true;
			}
			else
			{
				requisicaoNotas.REQS = requisicaoNotas.REQS ?? new List<string>();

				for (int i = 0; i < dataGridView_reqs.Rows.Count; i++)
				{
					string sTemp = dataGridView_reqs.Rows[i].Cells[0].Value.ToString();

					if (!string.IsNullOrEmpty(sTemp))
					{
						requisicaoNotas.REQS.Add(sTemp);
					}

				}

				requisicaoNotas.REG_USERID = Convert.ToInt32(comboBox_user_red.SelectedValue);
				requisicaoNotas.USERID = Convert.ToInt32(comboBox_vend.SelectedValue);
				requisicaoNotas.DATA_VENDA = dateTimePicker_data.Value;

				if (await controller.CreateCREQ(requisicaoNotas))
				{
					toolStripButton_cancel_Click(null, null);
				}
			}

		}

		private void toolStripButton_cancel_Click(object sender, EventArgs e)
		{
			requisicaoNotas = null;
			toolStripButton_new_save.Image = Resources.documento_new;
			toolStripButton_cancel.Visible = false;
			groupBox_addReq.Visible = false;
			toolStripButton_send.Visible = true;
			ClearFieldReq();
			isNew = false;
		}

		private async void toolStripButton_send_Click(object sender, EventArgs e)
		{
			List<long> list = new List<long>();
			for (int i = 0; i < dataGridView_resqDb.Rows.Count; i++)
			{
				if ((bool)dataGridView_resqDb.Rows[i].Cells[3].Value)
				{
					list.Add(Convert.ToUInt32(dataGridView_resqDb.Rows[i].Cells[0].Value));
				}
			}

			if (list.Count > 0)
			{
				if (await controller.SendReq(list))
				{

				}
			}
		}

		private void dataGridView_resqDb_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			bool temp = (bool)dataGridView_resqDb.Rows[e.RowIndex].Cells[6].Value;
			dataGridView_resqDb.Rows[e.RowIndex].Cells[6].Value = !temp;
		}

		private async void ControleReqNota_LoadAsync(object sender, EventArgs e)
		{
			await comboBox_user_red.CBListUserAsync(eterDb);
			comboBox_user_red.SelectedIndex = comboBox_user_red.ReturnIndexUserCB(eterDb.UserModelAcess.ID);
			await comboBox_vend.CBListUserAsync(eterDb);
			RefreshDataGrid();
		}

		private void textBox_req_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				ePictureBox_addR_Click(null, null);
			}
		}

		private async void RefreshDataGrid(bool queryData=false)
		{
			if (queryData)
			{
				dataGridView_resqDb.DataSource = await controller.GetByDate(dateTimePicker_dataQ);
			}
			else
			{
				dataGridView_resqDb.DataSource = await controller.GetByDate(null);
			}
		}
	}
}
