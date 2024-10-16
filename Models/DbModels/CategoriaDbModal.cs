using EterPharmaPro.DatabaseSQLite;

namespace EterPharmaPro.Models.DbModels
{
	public class CategoriaDbModal : BaseDbModal
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string TABLE_NAME { get; private set; } = "CATEGORIA_VALIDADE";

		public string NAME { get; set; } =string.Empty;
		public long? ID_LOJA { get; set; }
	}
}
