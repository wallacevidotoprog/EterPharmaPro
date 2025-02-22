using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.Interfaces;
using System;

namespace EterPharmaPro.Models.DbModels
{
	public class DeliveryInputDbModel: BaseDbModal, IFirebaseDb
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string TABLE_NAME { get; private set; } = "DELIVERY_INPUT";

		public string UID { get; set; }

		public string FIREBASE_ID { get; set; }

		public long? USER_ID { get; set; }
		public DateTime? DATE { get; set; }

		public long? CLIENTE_ID { get; set; }

		public long? ENDERECO_ID { get; set; }

		public long? TYPE_DELIVERY { get; set; }

        public decimal VALUE { get; set; }
    }
}
