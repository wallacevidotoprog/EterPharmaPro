using EterPharmaPro.Controllers.Manipulacao;
using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
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

		private void toolStripButton_sair_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Deseja sair o formulário ?", base.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.Close();
			}
		}

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
			comboBox_user.Invoke((Action)async delegate
			{
				await comboBox_user.CBListUserAsync(_eterDb);
			});

			if (manipulados != null)
			{
				dateTimePicker_data.Value = (DateTime)manipulados.DADOSATENDIMENTO.DATA;
				textBox_atn.Text = manipulados?.DADOSATENDIMENTO.ATEN_MANI;
				//comboBox_user.SelectedIndex = ExtensionsDefault.ReturnIndexUserCB(manipulados.DADOSATENDIMENTO?.ATEN_LOJA.ToString(), comboBox_user);
				textBox_cpf.Text = ((ClienteModel)manipulados.DADOSCLIENTE)?.CPF.ReturnFormation(FormatationEnum.CPF);
				textBox_rg.Text = ((ClienteModel)manipulados.DADOSCLIENTE)?.RG.ReturnFormation(FormatationEnum.RG);
				textBox_nomeC.Text = ((ClienteModel)manipulados.DADOSCLIENTE)?.NOME;
				textBox5_tel.Text = ((ClienteModel)manipulados.DADOSCLIENTE)?.TELEFONE.ReturnFormation(FormatationEnum.TELEFONE);
				textBox_log.Text = ((((List<EnderecoClienteModel>)(((ClienteModel)manipulados.DADOSCLIENTE)?.ENDERECO)).Count <= 0) ? string.Empty : ((List<EnderecoClienteModel>)(((ClienteModel)manipulados.DADOSCLIENTE)?.ENDERECO))[0]?.ENDERECO);
				textBox_obsEnd.Text = ((((List<EnderecoClienteModel>)(((ClienteModel)manipulados.DADOSCLIENTE)?.ENDERECO)).Count <= 0) ? string.Empty : ((List<EnderecoClienteModel>)((ClienteModel)manipulados.DADOSCLIENTE).ENDERECO)[0]?.OBSERVACAO);
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

		private bool Validade()
		{
			return textBox_nomeC.Text != "" && textBox5_tel.Text != "" && textBox_log.Text != "" && comboBox_situacao.SelectedIndex != -1 && comboBox_pag.SelectedIndex != -1 && comboBox_modo.SelectedIndex != -1 && Convert.ToDecimal(textBox_valorT.Text) > 0m;
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

		private async void BuscaCliente_Click(object sender, EventArgs e)
		{
			List<ClienteModel> temp = null;
			ClienteModel tempSelect = null;
			try
			{
				temp = ((textBox_cpf.Text != "") ? manipuladoController.GetCliente(textBox_cpf.Text.ReturnInt(), TypeDoc.CPF).Result :
					(((textBox_rg.Text != "")) ? manipuladoController.GetCliente(textBox_rg.Text.ReturnInt(), TypeDoc.RG).Result :
					manipuladoController.GetCliente().Result));

				if (temp.Count <= 0)
				{
					return;
				}
				object[] tempEnd;
				int retList;
				if (temp.Count > 1)
				{
					tempEnd = new object[temp.Count];
					for (int i = 0; i < tempEnd.Length; i++)
					{
						tempEnd[i] = new object[2]
						{
							i,
							"CLIENTE: " + temp[i].NOME + $" | TOTAL DE ENDEREÇOS: {(((List<EnderecoClienteModel>)temp[i].ENDERECO != null) ? ((List<EnderecoClienteModel>)temp[i].ENDERECO).Count : 0)}"
						};
					}
					retList = InputList.Show(tempEnd, "Clientes");
					if (retList == -1)
					{
						return;
					}
					tempSelect = temp[retList];
				}
				else
				{
					tempSelect = temp[0];
				}

				textBox_cpf.Text = tempSelect.CPF.ReturnFormation(FormatationEnum.CPF);
				textBox_rg.Text = tempSelect.RG.ReturnFormation(FormatationEnum.RG);
				textBox_nomeC.Text = tempSelect.NOME;
				textBox5_tel.Text = tempSelect.TELEFONE.ReturnFormation(FormatationEnum.TELEFONE);
				if (((List<EnderecoClienteModel>)tempSelect.ENDERECO).Count == 0)
				{
					return;
				}
				if (((List<EnderecoClienteModel>)tempSelect.ENDERECO).Count == 1)
				{
					textBox_log.Text = ((List<EnderecoClienteModel>)tempSelect.ENDERECO)[0].ENDERECO;
					textBox_obsEnd.Text = ((List<EnderecoClienteModel>)tempSelect.ENDERECO)[0].OBSERVACAO;
					return;
				}
				tempEnd = new object[((List<EnderecoClienteModel>)tempSelect.ENDERECO).Count];
				for (int i = 0; i < tempEnd.Length; i++)
				{
					tempEnd[i] = new object[2]
					{
					i,
					((List<EnderecoClienteModel>)tempSelect.ENDERECO)[i].ENDERECO
					};
				}
				retList = InputList.Show(tempEnd, "Enderecos Cliente");
				if (retList != -1)
				{
					textBox_log.Text = ((List<EnderecoClienteModel>)tempSelect.ENDERECO)[retList].ENDERECO;
					textBox_obsEnd.Text = ((List<EnderecoClienteModel>)tempSelect.ENDERECO)[retList].OBSERVACAO;
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
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

		private async void SavePrint(object sender, EventArgs e)
		{
			this.Focus();
			if (!Validade())
			{
				MessageBox.Show("Falta Preencher Algo.", "VALIDAÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			try
			{
				List<string> list = new List<string>();
				for (int i = 0; i < dataGridView_medicamentos.Rows.Count; i++)
				{
					if (dataGridView_medicamentos.Rows[i].Cells[0].Value != null && dataGridView_medicamentos.Rows[i].Cells[0].Value.ToString() != "")
					{
						list.Add(dataGridView_medicamentos.Rows[i].Cells[0].Value.ToString().ToUpper());
					}
				}
				ManipulacaoModel manipulacaoModel = new ManipulacaoModel
				{
					ID = ((!edit) ? null : manipulados.ID),
					DADOSATENDIMENTO = new DadosAtendimentoModel
					{
						ATEN_LOJA = Convert.ToInt32(comboBox_user.SelectedValue.ToString()),
						DATA = dateTimePicker_data.Value,
						ATEN_MANI = textBox_atn.Text
					},
					DADOSCLIENTE = new ClienteModel
					{
						ID = ((!edit) ? null : ((ClienteModel)manipulados.DADOSCLIENTE).ID),
						CPF = (textBox_cpf.Text.ReturnInt().StartsWith("0000000") ? string.Empty : textBox_cpf.Text.ReturnInt()),
						RG = (textBox_rg.Text.ReturnInt().StartsWith("0000000") ? string.Empty : textBox_rg.Text.ReturnInt()),
						NOME = textBox_nomeC.Text,
						TELEFONE = textBox5_tel.Text.ReturnInt(),
						ENDERECO = new EnderecoClienteModel
						{
							CLIENTE_ID = ((!edit) ? ((object)(-1)) : ((((List<EnderecoClienteModel>)((ClienteModel)manipulados.DADOSCLIENTE).ENDERECO).Count > 0) ? ((List<EnderecoClienteModel>)((ClienteModel)manipulados.DADOSCLIENTE).ENDERECO)[0].CLIENTE_ID : ((object)(-1)))),
							ID = ((!edit) ? (-1) : ((((List<EnderecoClienteModel>)((ClienteModel)manipulados.DADOSCLIENTE).ENDERECO).Count > 0) ? ((List<EnderecoClienteModel>)((ClienteModel)manipulados.DADOSCLIENTE).ENDERECO)[0].ID : (-1))),
							ENDERECO = textBox_log.Text,
							OBSERVACAO = textBox_obsEnd.Text
						}
					},
					MEDICAMENTO = list,
					OBSGERAL = textBox_obsGeral.Text,
					SITUCAO = comboBox_situacao.SelectedIndex,
					FORMAPAGAMENTO = comboBox_pag.SelectedIndex,
					MODOENTREGA = comboBox_modo.SelectedIndex,
					VALORFINAL = Convert.ToDecimal(textBox_valorT.Text)
				};


				if (await manipuladoController.PrintDocManipulado(manipulacaoModel, EnumManipulado.P_80, edit))
				{
					if (edit)
					{
						Close();
					}
					else if (MessageBox.Show("TUDO OK!!\nDeseja limpar o formulário ?", base.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						CleanAll(null, null);
					}
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
		}
	}
}
