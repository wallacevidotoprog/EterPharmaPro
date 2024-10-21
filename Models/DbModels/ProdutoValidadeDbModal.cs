using EterPharmaPro.DatabaseSQLite;
using System;

namespace EterPharmaPro.Models.DbModels
{
	public class ProdutoValidadeDbModal : BaseDbModal
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string TABLE_NAME { get; private set; } = "PRODUTOS_VALIDADE";
		public int VALIDADE_ID { get; set; } = -1;
		public int PRODUTO_CODIGO { get; set; } = -1;
		public string PRODUTO_DESCRICAO { get; set; } = string.Empty;
		public int QUANTIDADE { get; set; } = -1;
		public int CATEGORIA_ID { get; set; } = 1;
		public long? DATA_VALIDADE { get; set; }

	}
}
