using EterPharmaPro.Controllers.Entrega;
using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Properties;
using EterPharmaPro.Utils.Extencions;
using Google.Type;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro.Views.Entrega
{
	public partial class Delivery : Form
	{
		private readonly EntregaController entregaController;
		public Delivery(IEterDb eterDb)
		{
			InitializeComponent();
			entregaController = new EntregaController(eterDb);
			entregaController.loadCompleteLists += EntregaController_loadComplete;
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
			switch (delivery)
			{
				case ModeDeliveryEnum.DELIVERY:
					groupBox_deliveryman.Visible = false;
					break;
				case ModeDeliveryEnum.DELIVERY_MAN:
					groupBox_deliveryman.Visible = true;
					break;
			}
		}

		private void toolStripDropDownButton_new_Click(object sender, EventArgs e)
		{
			SendDelivery(ModeDeliveryEnum.DELIVERY);
		}

		private void toolStripDropDownButton_cancel_Click(object sender, EventArgs e)
		{

			toolStripDropDownButton_new.Image = Resources.documento_new;
			toolStripDropDownButton_cancel.Visible = false;
			groupBox_input.Visible = false;


		}

		private void Delivery_Load(object sender, EventArgs e)
		{
			comboBox_user.CBListUser(entregaController.listUser);
			comboBox_userDM.CBListUser(entregaController.listUser);
			comboBox_typeD.CBListTypeDelivery(entregaController.listTypeDelivery);

			dateTimePicker_dataD.Value = dateTimePicker_dataE.Value = System.DateTime.Now;
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

		}
		private void InsertDatagrid(List<DeliveryViewDbModel> model)
		{
			for (int i = 0; i < model.Count; i++)
			{
				dataGridView_report.Rows.Add(new object[]
				{
					model[i].entregaInputDbModel.ID,
					model[i].UserV,
					model[i].Cliente,
					model[i].Endereco,
					model[i].Tipo,
					string.Format(CultureInfo.CurrentCulture, "{0:C2}", model[i].entregaInputDbModel.VALUE),
					false,
					"Finalizar"

				});
			}

		}

	}
}