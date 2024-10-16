using EterPharmaPro.DatabaseSQLite;

namespace EterPharmaPro.Models.DbModels
{
	public class ReqNotaDbModal : BaseDbModal
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string TABLE_NAME { get; private set; } = "REQ_NOTA";
		public long? CQN_ID { get; set; }
		public string REQ { get; set; } = string.Empty;
	}
}
