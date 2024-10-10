using System;

namespace EterPharmaPro.Models
{
	public class DadosAtendimentoModel
	{
		public string ATEN_LOJA_NAME { get; set; } = null;
		public int ATEN_LOJA { get; set; } = -1;

		public DateTime? DATA { get; set; }

		public string ATEN_MANI { get; set; } = string.Empty;
	}
}
