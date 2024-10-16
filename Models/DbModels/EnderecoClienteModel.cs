using EterPharmaPro.DatabaseSQLite;

namespace EterPharmaPro.Models.DbModels
{
	public class EnderecoClienteModel : BaseDbModal
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string TABLE_NAME { get; private set; } = "ENDERECO_C";

		public object CLIENTE_ID { get; set; } = string.Empty;

		public string ENDERECO { get; set; } = string.Empty;

		public string OBSERVACAO { get; set; } = string.Empty;

	}
}
