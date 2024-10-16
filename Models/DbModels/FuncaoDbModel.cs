using EterPharmaPro.DatabaseSQLite;

namespace EterPharmaPro.Models.DbModels
{
	public class FuncaoDbModel : BaseDbModal
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string TABLE_NAME { get; private set; } = "FUNCAO";
		public string NOME { get; set; } = string.Empty;
	}
}
