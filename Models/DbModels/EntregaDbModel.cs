using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.Models.API;
using System;

namespace EterPharmaPro.Models.DbModels
{
	public class EntregaDbModel : BaseDbModal, IBaseFbModel
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string TABLE_NAME { get; set; } = "DELIVERY";

		public string UID { get; set; }
		public string FIREBASE_ID { get; set; }

		public long? USER_ID { get; set; }

		public DateTime? DATE { get; set; }
		public DateTime? DATE_COMPLETED { get; set; }
		public int  STATS { get; set; }

		public int? KM { get; set; }

		public long? DELIVERY_INPUT_ID { get; set; }

	}
}
