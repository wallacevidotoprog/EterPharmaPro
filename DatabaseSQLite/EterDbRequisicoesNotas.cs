using EterPharmaPro.Interfaces;

namespace EterPharmaPro.DatabaseSQLite
{
	internal class EterDbRequisicoesNotas : IEterDbRequisicoesNotas
	{
		private readonly string _databaseConnection;

		public EterDbRequisicoesNotas(string databaseConnection)
		{
			_databaseConnection = databaseConnection;
		}
	}
}
