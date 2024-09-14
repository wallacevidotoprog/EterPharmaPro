using System;

namespace EterPharmaPro.Models
{
	public class DadosAtendimentoModel
	{
		public int ATEN_LOJA { get; set; } = -1;

		public DateTime? DATA { get; set; }

		public string ATEN_MANI { get; set; } = string.Empty;
	}
}
