using EterPharmaPro.DatabaseSQLite;

namespace EterPharmaPro.Models.DbModels
{
	public class UserModel : BaseDbModal
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string TABLE_NAME { get; } = "USERS";

		public long? ID_LOJA { get; set; }

		public string NOME { get; set; } = string.Empty;

		public string PASS { get; set; } = string.Empty;

		public int FUNCAO { get; set; }

		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string FUNCAO_NAME { get; set; } = string.Empty;

		public bool STATUS { get; set; } = true;

	}
}
