using EterPharmaPro.Enums;
using EterPharmaPro.Interfaces;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Models.Print;
using EterPharmaPro.Services.Prints;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

		public async void PrintDocManipulado80mm(ManipulacaoModel model)
		{
			printerHelper = new RawPrinterHelper();
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				symbol = SymbolPrintEnum.Space
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				texto = "Formulário de Manipulados".ToUpper(),
				alignmentText = AlignmentTextPrintEnum.Center,
				fontStyle = FormatTextPrintEnum.Title
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				symbol = SymbolPrintEnum.Space
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "Vendedor(a): ",
				texto = model.DADOSATENDIMENTO.ATEN_LOJA + " - " + (await _eterDb.DbUser.GetUser(new QueryWhereModel().SetWhere("ID_LOJA", model.DADOSATENDIMENTO.ATEN_LOJA))).FirstOrDefault().NOME,
				alignmentText = AlignmentTextPrintEnum.Left,
				fontStyle = FormatTextPrintEnum.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "Atendente: ",
				texto = model.DADOSATENDIMENTO.ATEN_MANI,
				alignmentText = AlignmentTextPrintEnum.Left,
				fontStyle = FormatTextPrintEnum.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "Data do Pedido: ",
				texto = model.DADOSATENDIMENTO.DATA?.ToShortDateString(),
				alignmentText = AlignmentTextPrintEnum.Left,
				fontStyle = FormatTextPrintEnum.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				symbol = SymbolPrintEnum.Space
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "NOME: ",
				texto = ((ClienteModel)model.DADOSCLIENTE).NOME,
				alignmentText = AlignmentTextPrintEnum.Left,
				fontStyle = FormatTextPrintEnum.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "CPF: ",
				texto = ((ClienteModel)model.DADOSCLIENTE).CPF.ReturnFormation(FormatationEnum.CPF),
				alignmentText = AlignmentTextPrintEnum.Left,
				fontStyle = FormatTextPrintEnum.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "RG: ",
				texto = ((ClienteModel)model.DADOSCLIENTE).RG.ReturnFormation(FormatationEnum.RG),
				alignmentText = AlignmentTextPrintEnum.Left,
				fontStyle = FormatTextPrintEnum.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "TELEFONE: ",
				texto = ((ClienteModel)model.DADOSCLIENTE).TELEFONE.ReturnFormation(FormatationEnum.TELEFONE),
				alignmentText = AlignmentTextPrintEnum.Left,
				fontStyle = FormatTextPrintEnum.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "ENDEREÇO: ",
				texto = ((EnderecoClienteModel)((ClienteModel)model.DADOSCLIENTE).ENDERECO).ENDERECO,
				alignmentText = AlignmentTextPrintEnum.Left,
				fontStyle = FormatTextPrintEnum.Default
			});
			if (((EnderecoClienteModel)((ClienteModel)model.DADOSCLIENTE).ENDERECO).OBSERVACAO != string.Empty)
			{
				printerHelper.AddLine(new TextPrintFormaterModel
				{
					tilte = "OBS. DO ENDEREÇO: ",
					texto = ((EnderecoClienteModel)((ClienteModel)model.DADOSCLIENTE).ENDERECO).OBSERVACAO,
					alignmentText = AlignmentTextPrintEnum.Left,
					fontStyle = FormatTextPrintEnum.Default
				});
			}
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				symbol = SymbolPrintEnum.Space
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				texto = "MEDICAMENTOS PARA MANIPULAÇÃO".ToUpper(),
				alignmentText = AlignmentTextPrintEnum.Center,
				fontStyle = FormatTextPrintEnum.Title
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				symbol = SymbolPrintEnum.Space
			});
			for (int i = 0; i < ((List<string>)model.MEDICAMENTO).Count; i++)
			{
				printerHelper.AddLine(new TextPrintFormaterModel
				{
					tilte = "■ ",
					texto = ((List<string>)model.MEDICAMENTO)[i].ToUpper(),
					alignmentText = AlignmentTextPrintEnum.Left,
					fontStyle = FormatTextPrintEnum.Default
				});
			}
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				symbol = SymbolPrintEnum.Space
			});
			if (model.OBSGERAL != "")
			{
				printerHelper.AddLine(new TextPrintFormaterModel
				{
					texto = "OBSERVAÇÕES".ToUpper(),
					alignmentText = AlignmentTextPrintEnum.Center,
					fontStyle = FormatTextPrintEnum.Title
				});
				printerHelper.AddLine(new TextPrintFormaterModel
				{
					symbol = SymbolPrintEnum.Space
				});
				printerHelper.AddLine(new TextPrintFormaterModel
				{
					texto = model.OBSGERAL.ToUpper(),
					alignmentText = AlignmentTextPrintEnum.Left,
					fontStyle = FormatTextPrintEnum.Default
				});
				printerHelper.AddLine(new TextPrintFormaterModel
				{
					symbol = SymbolPrintEnum.Space
				});
			}
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				texto = "DADOS GERAIS".ToUpper(),
				alignmentText = AlignmentTextPrintEnum.Center,
				fontStyle = FormatTextPrintEnum.Title
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				symbol = SymbolPrintEnum.Space
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "SITUAÇÃO: ",
				//texto = DGERAL.SITUACAO(model.SITUCAO),
				alignmentText = AlignmentTextPrintEnum.Left,
				fontStyle = FormatTextPrintEnum.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "FORMA DE PAGAMENTO: ",
				//texto = DGERAL.FORMAPAGAMENTO(model.FORMAPAGAMENTO),
				alignmentText = AlignmentTextPrintEnum.Left,
				fontStyle = FormatTextPrintEnum.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				tilte = "MODO DE ENTREGA: ",
				//texto = DGERAL.MODOENTREGA(model.MODOENTREGA),
				alignmentText = AlignmentTextPrintEnum.Left,
				fontStyle = FormatTextPrintEnum.Default
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				symbol = SymbolPrintEnum.Space
			});
			printerHelper.AddLine(new TextPrintFormaterModel
			{
				texto = ("VALOR TOTAL " + string.Format(CultureInfo.CurrentCulture, "{0:C2}", Convert.ToDecimal(model.VALORFINAL))).ToUpper(),
				alignmentText = AlignmentTextPrintEnum.Right,
				fontStyle = FormatTextPrintEnum.Header
			});
			printerHelper.AddLine(new TextPrintFormaterModel());
			printerHelper.PrintDocument();
		}

		public void PrintDocManipuladoA4(ManipulacaoModel model)
		{
		}
	}
}
