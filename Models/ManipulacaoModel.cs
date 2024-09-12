using System;

namespace EterPharmaPro.Models
{
	public class ManipulacaoModel
	{
		public long? ID { get; set; }

		public DadosAtendimentoModel DADOSATENDIMENTO { get; set; } = null;

		public object DADOSCLIENTE { get; set; } = null;

		public object MEDICAMENTO { get; set; } = null;

		public string OBSGERAL { get; set; } = string.Empty;

		public int SITUCAO { get; set; } = -1;

		public int FORMAPAGAMENTO { get; set; } = -1;

		public int MODOENTREGA { get; set; } = -1;

		public decimal VALORFINAL { get; set; } = 0;

		public DateTime? CREATE { get; set; }

		public DateTime? UPDATE { get; set; }
	}
}
