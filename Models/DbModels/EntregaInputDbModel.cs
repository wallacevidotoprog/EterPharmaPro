using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.Models.API;
using System;

namespace EterPharmaPro.Models.DbModels
{
	public class EntregaInputDbModel : BaseDbModal, IBaseFbModel
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string TABLE_NAME { get; set; } = "DELIVERY_INPUT";
		public string UID { get; set; }
		public string FIREBASE_ID { get; set; }

		public long? USER_ID { get; set; }
		public long? CLIENTE_ID { get; set; }

		public long? ENDERECO_ID { get; set; }

		public decimal VALUE { get; set; }

		public int TYPE_DELIVERY { get; set; }

		public DateTime? DATA { get; set; }


	}
}
