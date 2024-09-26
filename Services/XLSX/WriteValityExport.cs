using ClosedXML.Excel;
using EterPharmaPro.Models;
using EterPharmaPro.Models.DbModels;
using EterPharmaPro.Utils.Extencions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro.Services.XLSX
{
	public static class WriteValityExport
	{
		public static async Task<bool> ExportValityExcel(ValityExportModel validade, string salveFile, bool inCategory = false)
		{
			try
			{
				using (XLWorkbook workbook = new XLWorkbook())
				{


					IXLWorksheet worksheet = workbook.Worksheets.Add(validade.NAME);
					worksheet.Cell("A1").Value = "CÓDIGO";
					worksheet.Cell("B1").Value = "DESCRIÇÃO DO PRODUTO";
					worksheet.Cell("C1").Value = "QUANTIDADE";
					worksheet.Cell("D1").Value = "VALIDADE";
					IXLRange title = worksheet.Range("A1:D1");
					title.Style.Font.SetBold().Font.FontSize = 16.0;
					title.Style.Fill.SetBackgroundColor(XLColor.FromArgb(189, 189, 183));
					int line = 2;
					if (inCategory)
					{
						int i;
						for (i = 0; i < validade.categoriasDbModals.Count; i++)
						{
							List<ProdutoValidadeDbModal> tp = validade.produtoValidadeDbModals.Where(x => x.CATEGORIA_ID == validade.categoriasDbModals[i].ID).ToList();



							if (tp.Count > 0)
							{
								worksheet.Cell($"A{line}").Value = validade.categoriasDbModals[i].NAME;
								IXLRange range = worksheet.Range($"A{line}:D{line}");
								range.Merge().Style.Font.SetBold().Font.FontSize = 16.0;
								range.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
								line++;
								for (int x = 0; x < tp.Count; x++)
								{
									worksheet.Cell($"A{line}").Value = tp[x].PRODUTO_CODIGO.ToString().PadLeft(6, '0'); ;
									worksheet.Cell($"B{line}").Value = tp[x].PRODUTO_DESCRICAO;
									worksheet.Cell($"C{line}").Value = tp[x].QUANTIDADE;
									worksheet.Cell($"D{line}").Value = tp[x].DATA_VALIDADE.ToShortDateString();
									line++;
								}
							}
						}
					}
					else
					{
						for (int i = 0; i < validade.produtoValidadeDbModals.Count; i++)
						{
							worksheet.Cell($"A{line}").Value = validade.produtoValidadeDbModals[i].PRODUTO_CODIGO.ToString().PadLeft(6, '0'); ;
							worksheet.Cell($"B{line}").Value = validade.produtoValidadeDbModals[i].PRODUTO_DESCRICAO;
							worksheet.Cell($"C{line}").Value = validade.produtoValidadeDbModals[i].QUANTIDADE;
							worksheet.Cell($"D{line}").Value = validade.produtoValidadeDbModals[i].DATA_VALIDADE.ToShortDateString();
							line++;
						}	
					}
					line--;
					worksheet.Range($"A1:D{line}").Style.Border.TopBorder = XLBorderStyleValues.Thin;
					worksheet.Range($"A1:D{line}").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
					worksheet.Range($"A1:D{line}").Style.Border.InsideBorder = XLBorderStyleValues.Thin;
					worksheet.Range($"A1:D{line}").Style.Border.LeftBorder = XLBorderStyleValues.Thin;
					worksheet.Range($"A1:D{line}").Style.Border.RightBorder = XLBorderStyleValues.Thin;
					worksheet.Columns().AdjustToContents();
					workbook.SaveAs(salveFile);
				};
				MessageBox.Show("Planilha criada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return true;
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
				return false;
			}
		}
	}
}
