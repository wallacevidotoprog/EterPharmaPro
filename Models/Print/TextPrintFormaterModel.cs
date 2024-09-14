using EterPharmaPro.Enums;

namespace EterPharmaPro.Models.Print
{
	public class TextPrintFormaterModel
	{
		public string tilte { get; set; } = string.Empty;


		public string texto { get; set; } = "";
		public FormatTextPrintEnum fontStyle { get; set; } = FormatTextPrintEnum.Default;


		public AlignmentTextPrintEnum alignmentText { get; set; } = AlignmentTextPrintEnum.Left;


		public SymbolPrintEnum symbol { get; set; } = SymbolPrintEnum.None;

	}
}
