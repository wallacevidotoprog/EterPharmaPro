using EterPharmaPro.Models.DbModels;
using System;

namespace EterPharmaPro.Models
{
	public class ManipulacaoModel : BaseDbModal
	{

		public DadosAtendimentoModel DADOSATENDIMENTO { get; set; } = null;

		public object DADOSCLIENTE { get; set; } = null;

		public object MEDICAMENTOS { get; set; } = null;

		public string OBSGERAL { get; set; } = string.Empty;

		public int SITUCAO { get; set; } = -1;

		public int FORMAPAGAMENTO { get; set; } = -1;

		public int MODOENTREGA { get; set; } = -1;

		public decimal VALORFINAL { get; set; } = 0;


		public ManipulacaoModel ConvertDb(ManipulacaoDbModel db)
		{
			
			ID = db.ID;
			DADOSATENDIMENTO = new DadosAtendimentoModel { ATEN_LOJA = db.ATEN_LOJA, DATA = db.DATA, ATEN_MANI = db.ATEN_MANI };
			DADOSCLIENTE = new DadosClienteManipulacao { ID_CLIENTE = db.CLIENTE_ID, ID_ENDERECO = db.ENDERECO_ID };
			OBSGERAL= db.OBSGERAL;
			SITUCAO= db.SITUCAO;	
			FORMAPAGAMENTO= db.FORMAPAGAMENTO;
			MODOENTREGA= db.MODOENTREGA;
			VALORFINAL= db.VALORFINAL;
			CREATE = db.CREATE;
			UPDATE = db.UPDATE;

			return this;
		}
	}
}
