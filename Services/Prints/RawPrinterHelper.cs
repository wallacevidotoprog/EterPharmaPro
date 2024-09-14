using EterPharmaPro.Enums;
using EterPharmaPro.Models.Print;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EterPharmaPro.Services.Prints
{
	public class RawPrinterHelper
	{
		private PrintDocument printDocument = null;

		private PrintPreviewDialog printPreviewDialog;

		private IniFile ini;

		private List<TextPrintFormaterModel> linesToPrint = new List<TextPrintFormaterModel>();

		public RawPrinterHelper()
		{
			ini = new IniFile("config.ini");
			printDocument = new PrintDocument();
			printDocument.DefaultPageSettings.PaperSize = new PaperSize("80mm Thermal Printer", 290, 0);
			printDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
			printPreviewDialog = new PrintPreviewDialog();
			printPreviewDialog.ClientSize = new Size(700, 700);
			printPreviewDialog.Document = printDocument;
			printDocument.PrintPage += PrintPage;
		}	

		public void AddLine(TextPrintFormaterModel printFormater)
		{
			linesToPrint.Add(printFormater);
		}

		public void PrintDocument()
		{
			Print();
		}

		private void Print()
		{
			printDocument.PrinterSettings.PrinterName = ini.Read("IMPRESSORAS", "DYNAMIC");
			printDocument.Print();
		}

		private void PrintPage(object sender, PrintPageEventArgs e)
		{
			float leftMargin = e.MarginBounds.Left;
			float topMargin = e.MarginBounds.Top;
			float rightMargin = e.MarginBounds.Right;
			float pageWidth = e.MarginBounds.Width;
			float pageHeight = e.MarginBounds.Height;
			float linhaAtual = topMargin;

			string TITLE = "REDE CENTRAL LOJA 15";
			SizeF stringSize = e.Graphics.MeasureString(TITLE, GetFont(FormatTextPrintEnum.Header));
			e.Graphics.DrawString(TITLE, GetFont(FormatTextPrintEnum.Header), Brushes.Black, leftMargin + (pageWidth - stringSize.Width) / 2f, 0f);
			linhaAtual += GetFont(FormatTextPrintEnum.Header).GetHeight() + 10f;
			e.Graphics.DrawLine(Pens.Black, leftMargin, linhaAtual, leftMargin + 300f, linhaAtual);
			for (int i = 0; i < linesToPrint.Count; i++)
			{
				if (linesToPrint[i].symbol != 0)
				{
					switch (linesToPrint[i].symbol)
					{
						case SymbolPrintEnum.Line:
							e.Graphics.DrawLine(Pens.Black, leftMargin, linhaAtual, leftMargin + 300f, linhaAtual);
							break;
						case SymbolPrintEnum.Space:
							linhaAtual += GetFont(FormatTextPrintEnum.Default).GetHeight();
							break;
					}
					continue;
				}
				List<string> tempC = BreakStringIntoLines(linesToPrint[i].tilte + linesToPrint[i].texto, GetFont(linesToPrint[i].fontStyle), pageWidth, e.Graphics);
				for (int l = 0; l < tempC.Count; l++)
				{
					int tts = e.PageBounds.Width;
					SizeF stringSizeText = e.Graphics.MeasureString(tempC[l], GetFont(linesToPrint[i].fontStyle));
					float xPos = 0f;
					switch (linesToPrint[i].alignmentText)
					{
						case AlignmentTextPrintEnum.Center:
							xPos = leftMargin + (pageWidth - stringSizeText.Width) / 2f;
							break;
						case AlignmentTextPrintEnum.Right:
							xPos = rightMargin - stringSizeText.Width;
							break;
						case AlignmentTextPrintEnum.Left:
							xPos = leftMargin;
							break;
					}
					e.Graphics.DrawString(tempC[l], GetFont(linesToPrint[i].fontStyle), Brushes.Black, xPos, linhaAtual);
					linhaAtual += GetFont(linesToPrint[i].fontStyle).GetHeight();
				}
			}
			e.Graphics.DrawLine(Pens.Black, leftMargin, linhaAtual, leftMargin + 300f, linhaAtual);
			e.Graphics.DrawString(DateTime.Now.ToString("dddd dd/MMMM/yyyy - HH:mm").ToUpper(), GetFont(FormatTextPrintEnum.Italic), Brushes.Black, leftMargin, linhaAtual);
			linhaAtual += GetFont(FormatTextPrintEnum.Italic).GetHeight();
			e.HasMorePages = false;
		}

		private List<string> BreakStringIntoLines(string text, Font font, float maxWidth, Graphics eg)
		{
			List<string> lines = new List<string>();
			string[] words = (from x in text.Split(' ')
							  where x != string.Empty
							  select x).ToArray();
			StringBuilder line = new StringBuilder();
			float lineWidth = 0f;
			string[] array = words;
			foreach (string word in array)
			{
				SizeF wordSize = eg.MeasureString(word + " ", font);
				if (lineWidth + wordSize.Width > maxWidth)
				{
					lines.Add(line.ToString().TrimEnd());
					line.Clear();
					lineWidth = 0f;
				}
				line.Append(word + " ");
				lineWidth += wordSize.Width;
			}
			if (line.Length > 0)
			{
				lines.Add(line.ToString().TrimEnd());
			}
			return lines;
		}

		private Font GetFont(FormatTextPrintEnum formatText)
		{
			switch (formatText)
			{
				case FormatTextPrintEnum.Default:
					return new Font("Arial Narrow", 8f);
				case FormatTextPrintEnum.Bolt:
					return new Font("Arial Narrow", 8f, FontStyle.Bold);
				case FormatTextPrintEnum.Italic:
					return new Font("Arial Narrow", 8f, FontStyle.Italic);
				case FormatTextPrintEnum.Title:
					return new Font("Arial Narrow", 10f, FontStyle.Bold);
				case FormatTextPrintEnum.Header:
					return new Font("Arial Narrow", 15f, FontStyle.Bold);
			}
			return new Font("Arial Narrow", 8f);
		}
	}
}
