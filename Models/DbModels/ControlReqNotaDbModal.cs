using EterPharmaPro.DatabaseSQLite;
using System;

namespace EterPharmaPro.Models.DbModels
{
	public class ControlReqNotaDbModal : BaseDbModal
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string TABLE_NAME { get; private set; } = "CONTROL_REQ_NOTA";
		public long? VENDEDOR { get; set; }
		public long? AUTHOR { get; set; }

		public DateTime DATA_VENDA { get; set; }
		public DateTime DATA_ENVIO { get; set; }
	}
}
