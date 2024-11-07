using EterPharmaPro.DatabaseSQLite;
using EterPharmaPro.Interfaces;

namespace EterPharmaPro.Models.DbModels
{
	public class DeliveryDbModel : BaseDbModal, IFirebaseDb
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string TABLE_NAME { get; private set; } = "DELIVERY";
		public string UID { get; set; }
		public string FIREBASE_ID { get; set; }

		public int USER_ID { get; set; }  

		public string DATE { get; set; }  

		public float VALUE { get; set; }

		public int KM { get; set; }

		public int COMPLETED { get; set; }  

		public long DATE_COMPLETED { get; set; } 
	}
}
