using EterPharmaPro.DatabaseSQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Models.DbModels
{
	public class MedicamentosManipuladosDbModal:BaseDbModal
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public string TABLE_NAME { get; private set; } = "MEDICAMENTO_MANIPULACAO";

		public long? MANIPULADOS_ID { get; set; }
		public string NAME_M { get; set; }
	}
}
