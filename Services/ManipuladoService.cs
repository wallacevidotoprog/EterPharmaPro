using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace EterPharmaPro.Services
{
	public class ManipuladoService
	{
		private readonly IEterDb _eterDb;

		private static RawPrinterHelper printerHelper;

		public ManipuladoService(IEterDb eterDb)
		{
			_eterDb = eterDb;
		}

		public void PrintDocManipulado80mm(ManipulacaoModel model)
		{
			printerHelper = new RawPrinterHelper();
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				symbol = Symbol.Space
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				texto = "Formulário de Manipulados".ToUpper(),
				alignmentText = AlignmentText.Center,
				fontStyle = FormatText.Title
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				symbol = Symbol.Space
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "Vendedor(a): ",
				texto = model.DADOSATENDIMENTO.ATEN_LOJA + " - " + _eterDb.DbUser.GetUser(model.DADOSATENDIMENTO.ATEN_LOJA).Result[0].Nome,
				alignmentText = AlignmentText.Left,
				fontStyle = FormatText.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "Atendente: ",
				texto = model.DADOSATENDIMENTO.ATEN_MANI,
				alignmentText = AlignmentText.Left,
				fontStyle = FormatText.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "Data do Pedido: ",
				texto = model.DADOSATENDIMENTO.DATA.ToShortDateString(),
				alignmentText = AlignmentText.Left,
				fontStyle = FormatText.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				symbol = Symbol.Space
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "NOME: ",
				texto = ((DadosCliente)model.DADOSCLIENTE).NOME,
				alignmentText = AlignmentText.Left,
				fontStyle = FormatText.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "CPF: ",
				texto = ((DadosCliente)model.DADOSCLIENTE).CPF.ReturnFormation(Formatation.CPF),
				alignmentText = AlignmentText.Left,
				fontStyle = FormatText.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "RG: ",
				texto = ((DadosCliente)model.DADOSCLIENTE).RG.ReturnFormation(Formatation.RG),
				alignmentText = AlignmentText.Left,
				fontStyle = FormatText.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "TELEFONE: ",
				texto = ((DadosCliente)model.DADOSCLIENTE).TELEFONE.ReturnFormation(Formatation.TELEFONE),
				alignmentText = AlignmentText.Left,
				fontStyle = FormatText.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "ENDEREÇO: ",
				texto = ((EnderecoCliente)((DadosCliente)model.DADOSCLIENTE).ENDERECO).LOGRADOURO,
				alignmentText = AlignmentText.Left,
				fontStyle = FormatText.Default
			});
			if (((EnderecoCliente)((DadosCliente)model.DADOSCLIENTE).ENDERECO).OBS != string.Empty)
			{
				printerHelper.AddLine(new TextPrintFormaterModel
				{
					tilte = "OBS. DO ENDEREÇO: ",
					texto = ((EnderecoCliente)((DadosCliente)model.DADOSCLIENTE).ENDERECO).OBS,
					alignmentText = AlignmentText.Left,
					fontStyle = FormatText.Default
				});
			}
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				symbol = Symbol.Space
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				texto = "MEDICAMENTOS PARA MANIPULAÇÃO".ToUpper(),
				alignmentText = AlignmentText.Center,
				fontStyle = FormatText.Title
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				symbol = Symbol.Space
			});
			for (int i = 0; i < ((List<string>)model.MEDICAMENTO).Count; i++)
			{
				printerHelper.AddLine(new TextPrintFormaterModel
				{
					tilte = "■ ",
					texto = ((List<string>)model.MEDICAMENTO)[i].ToUpper(),
					alignmentText = AlignmentText.Left,
					fontStyle = FormatText.Default
				});
			}
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				symbol = Symbol.Space
			});
			if (model.OBSGERAL != "")
			{
				printerHelper.AddLine(new TextPrintFormaterModel
				{
					texto = "OBSERVAÇÕES".ToUpper(),
					alignmentText = AlignmentText.Center,
					fontStyle = FormatText.Title
				});
				printerHelper.AddLine(new TextPrintFormaterModel
				{
					symbol = Symbol.Space
				});
				printerHelper.AddLine(new TextPrintFormaterModel
				{
					texto = model.OBSGERAL.ToUpper(),
					alignmentText = AlignmentText.Left,
					fontStyle = FormatText.Default
				});
				printerHelper.AddLine(new TextPrintFormaterModel
				{
					symbol = Symbol.Space
				});
			}
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				texto = "DADOS GERAIS".ToUpper(),
				alignmentText = AlignmentText.Center,
				fontStyle = FormatText.Title
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				symbol = Symbol.Space
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "SITUAÇÃO: ",
				texto = DGERAL.SITUACAO(model.SITUCAO),
				alignmentText = AlignmentText.Left,
				fontStyle = FormatText.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "FORMA DE PAGAMENTO: ",
				texto = DGERAL.FORMAPAGAMENTO(model.FORMAPAGAMENTO),
				alignmentText = AlignmentText.Left,
				fontStyle = FormatText.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "MODO DE ENTREGA: ",
				texto = DGERAL.MODOENTREGA(model.MODOENTREGA),
				alignmentText = AlignmentText.Left,
				fontStyle = FormatText.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				symbol = Symbol.Space
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				texto = ("VALOR TOTAL " + string.Format(CultureInfo.CurrentCulture, "{0:C2}", Convert.ToDecimal(model.VALORFINAL))).ToUpper(),
				alignmentText = AlignmentText.Right,
				fontStyle = FormatText.Header
			});
			printerHelper.AddLine(new TextPrintFormaterModel());
			printerHelper.PrintDocument();
		}

		public void PrintDocManipuladoA4(ManipulacaoModel model)
		{
		}
	}
}
