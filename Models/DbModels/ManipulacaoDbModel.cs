using EterPharmaPro.DatabaseSQLite;

using EterPharmaPro.Utils.Extencions;
using System;

namespace EterPharmaPro.Models.DbModels
{
	public class ManipulacaoDbModel : BaseDbModal
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string TABLE_NAME { get; private set; } = "MANIPULADOS";
		public int ATEN_LOJA { get; set; } = -1;

		public long? DATA { get; set; }

		public string ATEN_MANI { get; set; } = string.Empty;

		public long? CLIENTE_ID { get; set; } = -1;

		public long? ENDERECO_ID { get; set; } = -1;

		public int SITUCAO { get; set; } = -1;

		public int FORMAPAGAMENTO { get; set; } = -1;

		public int MODOENTREGA { get; set; } = -1;

		public decimal VALORFINAL { get; set; } = 0;

		public string OBSGERAL { get; set; } = string.Empty;


		public ManipulacaoDbModel Convert(ManipulacaoModel model)
		{
			return new ManipulacaoDbModel
			{
				ID = model.ID,
				ATEN_LOJA = model.DADOSATENDIMENTO.ATEN_LOJA,
				DATA = model.DADOSATENDIMENTO.DATA.ToDatetimeUnix(),
				ATEN_MANI = model.DADOSATENDIMENTO.ATEN_MANI,
				CLIENTE_ID = ((DadosClienteManipulacao)model.DADOSCLIENTE).ID_CLIENTE,
				ENDERECO_ID = ((DadosClienteManipulacao)model.DADOSCLIENTE).ID_ENDERECO,
				SITUCAO = model.SITUCAO,
				FORMAPAGAMENTO = model.FORMAPAGAMENTO,
				MODOENTREGA = model.MODOENTREGA,
				VALORFINAL = model.VALORFINAL,
				OBSGERAL = model.OBSGERAL

			};
		}

	}


}
