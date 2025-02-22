using EterPharmaPro.DatabaseSQLite;

namespace EterPharmaPro.Models.DbModels
{
	public class DeliveryMethodDbModal : BaseDbModal
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string TABLE_NAME { get; private set; } = "DELIVERY_METHOD";

		public string NAME { get; set; } =string.Empty;
	}
}
