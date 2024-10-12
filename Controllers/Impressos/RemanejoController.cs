using DocumentFormat.OpenXml.Drawing.Charts;
using EterPharmaPro.Models;
using EterPharmaPro.Utils.Extencions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Diagnostics;
using System.IO;

namespace EterPharmaPro.Controllers.Impressos
{
	public class RemanejoController
	{
		public bool Print(RemanejoModel remanejoModel)
		{
			try
			{
				PrintPDF(remanejoModel);
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
			return false;
		}
		private void PrintPDF(RemanejoModel remanejoMode)
		{
			Font cellFon = new Font(Font.FontFamily.COURIER, 8, 1, BaseColor.BLACK);

			string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\REMANEJO" + DateTime.Now.ToString("ddddMMMMyyyyyHHmm") + ".pdf";
			Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
			PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
			document.Open();

			float tableWidth = 250;
			float spaceBetweenTables = 3;
			float marginLeft = document.LeftMargin;
			float marginRight = document.RightMargin;
			float pageWidth = PageSize.A4.Width;
			float pageHeight = PageSize.A4.Height;
			int tablesPerRow = (int)((pageWidth - marginLeft - marginRight) / (tableWidth + spaceBetweenTables));
			float yPosition = document.PageSize.Height - document.TopMargin;
			float minYPosition = document.BottomMargin;

			int current = 1;

			for (int x = 0; x < remanejoMode.QTD; x++)
            {
				PdfPTable table = new PdfPTable(2);
				table.SetWidths(new float[] { 300f, 25 });
				table.WidthPercentage = 100f;

				PdfPCell cell = new PdfPCell(new Phrase($"{remanejoMode.LOJA.ToUpper()}", new Font(Font.FontFamily.HELVETICA, 35, 1, BaseColor.BLACK)))
				{
					Colspan = 2,
					FixedHeight = 50f,
					HorizontalAlignment = 1,
					VerticalAlignment = 5,
					BorderWidth = 1f,
					NoWrap = false
				};				
				table.AddCell(cell);

				PdfPCell cell2= new PdfPCell(new Phrase($"N° REMANEJO: {remanejoMode.NUM.ToUpper()}", new Font(Font.FontFamily.HELVETICA, 20, 1, BaseColor.BLACK)))
				{
					Colspan = 2,
					FixedHeight = 50f,
					HorizontalAlignment = 1,
					VerticalAlignment = 5,
					BorderWidth = 1f,
					NoWrap = false
				};
				table.AddCell(cell2);

				PdfPCell cell3 = new PdfPCell(new Phrase($"DATA: {remanejoMode.DATA.ToShortDateString()}", new Font(Font.FontFamily.HELVETICA, 20, 1, BaseColor.BLACK)))
				{
					Colspan = 2,
					FixedHeight = 50f,
					HorizontalAlignment = 1,
					VerticalAlignment = 5,
					BorderWidth = 1f,
					NoWrap = false
				};
				table.AddCell(cell3);

				PdfPCell cell4 = new PdfPCell(new Phrase($"{current.ToString().PadLeft(3, '0')}/{remanejoMode.QTD.ToString().PadLeft(3,'0')}", new Font(Font.FontFamily.HELVETICA, 35, 1, BaseColor.BLACK)))
				{
					Colspan = 2,
					FixedHeight = 50f,
					HorizontalAlignment = 1,
					VerticalAlignment = 5,
					BorderWidth = 1f,
					NoWrap = false
				};
				table.AddCell(cell4);
				if (!string.IsNullOrEmpty(remanejoMode.OBS))
				{
					PdfPCell cell5 = new PdfPCell(new Phrase($"OBSERVAÇÕES: {remanejoMode.OBS.ToUpper()}", new Font(Font.FontFamily.HELVETICA, 10,1, BaseColor.BLACK)))
					{
						Colspan = 2,
						FixedHeight = 50f,
						HorizontalAlignment = 1,
						VerticalAlignment = 5,
						BorderWidth = 1f,
						NoWrap = false
					};
					table.AddCell(cell5);
				}
				





				table.TotalWidth = tableWidth;
				table.WidthPercentage = 100f;
				float xPosition = marginLeft + (float)(x % tablesPerRow) * (tableWidth + spaceBetweenTables);
				if (x > 0 && x % tablesPerRow == 0)
				{
					yPosition -= table.TotalHeight + 10f;
					if (yPosition - table.TotalHeight < minYPosition)
					{
						document.NewPage();
						yPosition = document.PageSize.Height - document.TopMargin;
					}
				}
				table.WriteSelectedRows(0, -1, xPosition, yPosition, writer.DirectContent);
				current++;
			}

			document.Close();
			Process.Start(new ProcessStartInfo(filePath)
			{
				UseShellExecute = true
			});
		}
	}
}
