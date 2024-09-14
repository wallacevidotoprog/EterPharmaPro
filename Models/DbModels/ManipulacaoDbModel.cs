using System;

namespace EterPharmaPro.Models.DbModels
{
	public class ManipulacaoDbModel
	{
		public long? ID { get; set; }

		public int ATEN_LOJA { get; set; } = -1;

		public DateTime? DATA { get; set; }

		public string ATEN_MANI { get; set; } = string.Empty;

		public int CLIENTE_ID { get; set; } = -1;

		public int ENDERECO_ID { get; set; } = -1;

		public int SITUCAO { get; set; } = -1;

		public int FORMAPAGAMENTO { get; set; } = -1;

		public int MODOENTREGA { get; set; } = -1;

		public decimal VALORFINAL { get; set; } = 0;

		public string OBSGERAL { get; set; } = string.Empty;

		public DateTime? CREATE { get; set; }

		public DateTime? UPDATE { get; set; }
	}
}
