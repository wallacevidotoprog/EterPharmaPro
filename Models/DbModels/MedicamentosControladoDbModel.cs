using EterPharmaPro.DatabaseSQLite;
using System;

namespace EterPharmaPro.Models.DbModels
{
	public class MedicamentosControladoDbModel : BaseDbModal
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string TABLE_NAME { get; private set; } = "MEDICAMENTO_CONTROLADO";

		public long? CLIENTE_ID { get; set; }

		public int? CODIGO { get; set; }

		public string NAME_M { get; set; }

		public int QTD { get; set; }

		public long? VALIDADE { get; set; }

		public string LOTE { get; set; }
	}
}
