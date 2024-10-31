using EterPharmaPro.DatabaseSQLite;
using System;

namespace EterPharmaPro.Models.DbModels
{
	public class EntregaDbModel : BaseDbModal
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string TABLE_NAME { get; set; } = "DELIVERY";

		public string FIREBASE_ID { get; set; }
		public string UID { get; set; }
		public long? USER_ID { get; set; }

		public DateTime? DATE { get; set; }

		public decimal VALUE { get; set; }

		public int? KM { get; set; }

		public long? CLIENTE_ID { get; set; }

		public long? ENDERECO_ID { get; set; }

		public int? TYPE_DELIVERY { get; set; }

		public void SetUID()
		{
			UID = Guid.NewGuid().ToString().ToUpper();
		}
	}
}
