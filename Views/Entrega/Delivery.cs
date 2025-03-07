﻿using EterPharmaPro.Controllers.Entrega;
using EterPharmaPro.Controllers.Manipulacao;
using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Properties;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace EterPharmaPro.Views.Entrega
{
	public partial class Delivery : Form
	{
		private readonly EntregaController entregaController;

		private bool isNew = false;
		private bool isEdit = false;
		private bool isDMan = false;
		private long? DELIVERY_INPUT_ID = null;

		public Delivery(IEterDb eterDb)
		{
			InitializeComponent();
			entregaController = new EntregaController(eterDb);
			entregaController.loadCompleteLists += EntregaController_loadComplete;
			entregaController.loadCompleteListsDelivery += EntregaController_loadCompleteListsDelivery;
		}

		private void EntregaController_loadCompleteListsDelivery(object sender, EventArgs e)
		{
			SetDatagrid();
			return;//modo dev
			InsertDatagrid(entregaController.ModelViewDeliveryByDate(dateTime: System.DateTime.Now));
		}

		private void EntregaController_loadComplete(object sender, EventArgs e)
		{
			comboBox_user.CBListUser(entregaController.listUser);
			comboBox_userDM.CBListUser(entregaController.listUser);
			comboBox_typeD.CBListTypeDelivery(entregaController.listTypeDelivery);
		}

		private void toolStripButton_exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void SendDelivery(ModeDeliveryEnum delivery)
		{
			groupBox_input.Visible = true;
			toolStripDropDownButton_cancel.Visible = true;
			toolStripDropDownButton_new.Image = Resources.salve;
			Size xz = groupBox_input.Size;
			switch (delivery)
			{
				case ModeDeliveryEnum.DELIVERY:
					groupBox_deliveryman.Visible = false;

					if (xz.Height == 315)
					{
						groupBox_input.Size = new Size(groupBox_input.Width, groupBox_input.Height - groupBox_deliveryman.Height);
					}


					break;
				case ModeDeliveryEnum.DELIVERY_MAN:
					groupBox_deliveryman.Visible = true;
					if (xz.Height != 315)
					{
						groupBox_input.Size = new Size(groupBox_input.Width, groupBox_input.Height + groupBox_deliveryman.Height);
					}
					break;
			}
		}

		private async void toolStripDropDownButton_new_Click(object sender, EventArgs e)
		{

			if (isNew && !isEdit && !isDMan)
			{
				if (await entregaController.CreateDeliveryInput(new EntregaInputModel
				{
					useridvend = Convert.ToInt32(comboBox_user.SelectedValue.ToString()),
					clienteDbModel = new ClienteDbModel
					{
						CPF = !string.IsNullOrEmpty(textBox_cpf.Text.ReturnInt()) ? textBox_cpf.Text.ReturnInt() : null,
						RG = !string.IsNullOrEmpty(textBox_rg.Text.ReturnInt()) ? textBox_rg.Text.ReturnInt() : null,
						NOME = textBox_nomeC.Text,
						TELEFONE = textBox5_tel.Text.ReturnInt(),
						ENDERECO = new EnderecoClienteDbModel
						{
							ENDERECO = textBox_log.Text,
							OBSERVACAO = !string.IsNullOrEmpty(textBox_obsEnd.Text.ReturnInt()) ? textBox_obsEnd.Text.ReturnInt() : null,
						}
					},
					data = dateTimePicker_dataD.Value,
					tipo = Convert.ToInt32(comboBox_typeD.SelectedValue.ToString()),
					valor = Convert.ToDecimal(textBox_valor.Text)
				}))
				{
					toolStripDropDownButton_cancel_Click(null,null);
				}
			}
			else if (!isNew && isEdit && !isDMan)
			{

			}
			else if (!isNew && !isEdit && isDMan)
			{
				if (await entregaController.CreateDelivery(new EntregaDbModel
				{
					DELIVERY_INPUT_ID = DELIVERY_INPUT_ID,
					DATE = dateTimePicker_dataE.Value,
					USER_ID = Convert.ToInt32(comboBox_userDM.SelectedValue.ToString()),
					KM = Convert.ToInt32(textBox_km.Text.ReturnInt()),
					STATS = (int)StatsDeliveryEnum.NEW,

					
				}))
				{
					toolStripDropDownButton_cancel_Click(null, null);
					DELIVERY_INPUT_ID = null;
				}
			}
			else if (!isNew && !isEdit && !isDMan)
			{
				SendDelivery(ModeDeliveryEnum.DELIVERY);
				isNew = true;
			}


		}

		private void toolStripDropDownButton_cancel_Click(object sender, EventArgs e)
		{

			toolStripDropDownButton_new.Image = Resources.documento_new;
			toolStripDropDownButton_cancel.Visible = false;
			groupBox_input.Visible = false;
			isNew = false;
			isEdit = false;
			isDMan = false;


		}

		private void Delivery_Load(object sender, EventArgs e)
		{
			comboBox_user.CBListUser(entregaController.listUser);
			comboBox_userDM.CBListUser(entregaController.listUser);
			comboBox_typeD.CBListTypeDelivery(entregaController.listTypeDelivery);

			dateTimePicker_dataD.Value = dateTimePicker_dataE.Value = System.DateTime.Now;

			SetDatagrid();

		}

		private void textBox_cpf_Validated(object sender, EventArgs e)
		{
			textBox_cpf.Text = textBox_cpf.Text.ReturnFormation(FormatationEnum.CPF);
		}

		private void textBox_rg_Validated(object sender, EventArgs e)
		{
			textBox_rg.Text = textBox_rg.Text.ReturnFormation(FormatationEnum.RG);
		}

		private void textBox5_tel_Validated(object sender, EventArgs e)
		{
			textBox5_tel.Text = textBox5_tel.Text.ReturnFormation(FormatationEnum.TELEFONE);
		}

		private void textBox_valorT_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
			{
				e.Handled = true;
			}
		}

		private void textBox_km_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}


		private async void textBox_log_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F10)
			{
				string tempCEP = InputBox.Show("Digite o CEP:", "Buscar endereço por CEP");
				if (tempCEP != string.Empty)
				{
					AddressHttpModel temResp = await ExtensionsDefault.BuscaCepAsync(tempCEP);
					textBox_log.Text = ((temResp != null) ? (temResp.logradouro + ", N°: ," + temResp.bairro + ", " + temResp.localidade + "-" + temResp.uf) : string.Empty);
				}
			}
		}


		private void SetDatagrid()
		{
			InsertDatagrid(entregaController.ModelViewDeliveryByDate(null));
		}
		private void InsertDatagrid(List<DeliveryViewDbModel> model)
		{
			if (model is null)
			{
				return;
			}
			dataGridView_report.Invoke((Action)delegate
			{
				dataGridView_report.Rows.Clear();
				for (int i = 0; i < model.Count; i++)
				{
					dataGridView_report.Rows.Add(new object[]
					{
					model[i]?.entregaInputDbModel.ID,
					model[i]?.UserV,
					model[i]?.entregaInputDbModel.DATA.ToString(),
					model[i]?.Cliente,
					model[i]?.Endereco,
					model[i]?.Tipo,
					string.Format(CultureInfo.CurrentCulture, "{0:C2}", model[i]?.entregaInputDbModel?.VALUE),
					 StatsDeliveryDataGridViewColumn.ObterIconeEstado((StatsDeliveryEnum)model[i]?.Stats),
					"Finalizar"

					});
				}
			});


		}

		private async void ePictureBox_search_Click(object sender, EventArgs e)
		{
			List<ClienteDbModel> temp = null;
			ClienteDbModel tempSelect = null;
			try
			{
				temp = ((textBox_cpf.Text != "") ? await entregaController.GetCliente(textBox_cpf.Text.ReturnInt(), TypeDoc.CPF) :
					(((textBox_rg.Text != "")) ? await entregaController.GetCliente(textBox_rg.Text.ReturnInt(), TypeDoc.RG) :
					 await entregaController.GetCliente()));

				if (temp.Count <= 0)
				{
					return;
				}
				tempSelect = temp.GetClienteArray();

				textBox_cpf.Text = tempSelect?.CPF.ReturnFormation(FormatationEnum.CPF);
				textBox_rg.Text = tempSelect?.RG.ReturnFormation(FormatationEnum.RG);
				textBox_nomeC.Text = tempSelect?.NOME;
				textBox5_tel.Text = tempSelect?.TELEFONE.ReturnFormation(FormatationEnum.TELEFONE);
				textBox_log.Text = ((EnderecoClienteDbModel)tempSelect?.ENDERECO).ENDERECO;
				textBox_obsEnd.Text = ((EnderecoClienteDbModel)tempSelect?.ENDERECO).OBSERVACAO;

			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
		}


		private void lANÇARToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!isNew && !isEdit && !isDMan)
			{
				SendDelivery(ModeDeliveryEnum.DELIVERY_MAN);
				isDMan = true;

				if (dataGridView_report.CurrentRow != null)
				{
					DELIVERY_INPUT_ID = (long)dataGridView_report.CurrentRow.Cells[0].Value;
				}
			}
		}

		private void dataGridView_report_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
			{
				dataGridView_report.ClearSelection();
				dataGridView_report.Rows[e.RowIndex].Selected = true;
			}
		}
	}
}