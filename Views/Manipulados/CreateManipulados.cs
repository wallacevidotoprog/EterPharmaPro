using EterPharmaPro.Controllers.Manipulacao;
using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EterPharmaPro.Views.Manipulados
{
	public partial class CreateManipulados : Form
	{
		private readonly IEterDb _eterDb;

		private ManipulacaoModel manipulados;

		private bool edit = false;

		private readonly ManipuladoController manipuladoController;
		public CreateManipulados(IEterDb eterDb)
		{
			_eterDb = eterDb;
			manipuladoController = new ManipuladoController(eterDb);
			InitializeComponent();
		}

		public CreateManipulados(IEterDb eterDb, ManipulacaoModel model)
		{
			_eterDb = eterDb;
			InitializeComponent();
			manipuladoController = new ManipuladoController(eterDb);
			if (model != null)
			{
				edit = true;
				manipulados = model;
			}
		}

		private void toolStripButton_sair_Click(object sender, EventArgs e) => this.Close();

		private void CleanAll(object sender, EventArgs e)
		{
			dateTimePicker_data.Value = DateTime.Now;
			textBox_atn.Clear();
			textBox_cpf.Clear();
			textBox_rg.Clear();
			textBox_nomeC.Clear();
			textBox5_tel.Clear();
			textBox_log.Clear();
			textBox_obsEnd.Clear();
			dataGridView_medicamentos.Rows.Clear();
			textBox_obsGeral.Clear();
			comboBox_situacao.SelectedIndex = -1;
			comboBox_pag.SelectedIndex = -1;
			comboBox_modo.SelectedIndex = -1;
			textBox_valorT.Text = "0,00";
		}

		private void CreateManipulados_Load(object sender, EventArgs e)
		{
			CleanAll(null, null);
			comboBox_user.Invoke((Action)delegate
			{
				comboBox_user.CBListUser(_eterDb);
			});

			if (manipulados != null)
			{
				dateTimePicker_data.Value = (DateTime)manipulados.DADOSATENDIMENTO.DATA;
				textBox_atn.Text = manipulados?.DADOSATENDIMENTO.ATEN_MANI;
				comboBox_user.SelectedIndex = ExtensionsDefault.ReturnIndexUserCB(manipulados.DADOSATENDIMENTO?.ATEN_LOJA, comboBox_user);
				textBox_cpf.Text = ((ClienteModel)manipulados.DADOSCLIENTE)?.CPF.ReturnFormation(FormatationEnum.CPF);
				textBox_rg.Text = ((ClienteModel)manipulados.DADOSCLIENTE)?.RG.ReturnFormation(FormatationEnum.RG);
				textBox_nomeC.Text = ((ClienteModel)manipulados.DADOSCLIENTE)?.NOME;
				textBox5_tel.Text = ((ClienteModel)manipulados.DADOSCLIENTE)?.TELEFONE.ReturnFormation(FormatationEnum.TELEFONE);
				textBox_log.Text = ((((List<EnderecoCliente>)(((ClienteModel)manipulados.DADOSCLIENTE)?.ENDERECO)).Count <= 0) ? string.Empty : ((List<EnderecoCliente>)(((ClienteModel)manipulados.DADOSCLIENTE)?.ENDERECO))[0]?.LOGRADOURO);
				textBox_obsEnd.Text = ((((List<EnderecoCliente>)(((ClienteModel)manipulados.DADOSCLIENTE)?.ENDERECO)).Count <= 0) ? string.Empty : ((List<EnderecoCliente>)((ClienteModel)manipulados.DADOSCLIENTE).ENDERECO)[0]?.OBS);
				dataGridView_medicamentos.Rows.Clear();
				for (int i = 0; i < ((List<string>)manipulados.MEDICAMENTO)?.Count; i++)
				{
					dataGridView_medicamentos.Rows.Add(((List<string>)manipulados.MEDICAMENTO)[i].ToString());
				}
				textBox_obsGeral.Text = manipulados?.OBSGERAL;
				comboBox_situacao.SelectedIndex = manipulados.SITUCAO;
				comboBox_pag.SelectedIndex = manipulados.FORMAPAGAMENTO;
				comboBox_modo.SelectedIndex = manipulados.MODOENTREGA;
				textBox_valorT.Text = manipulados.VALORFINAL.ToString("F2");
			}
		}
	}
}
