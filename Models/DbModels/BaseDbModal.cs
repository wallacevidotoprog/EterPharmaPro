using EterPharmaPro.DatabaseSQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Models.DbModels
{

	public abstract class BaseDbModal
	{
		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: false)]
		public long? ID { get; set; }

		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public DateTime? CREATE { get; set; }

		[Ignore(ignoreOnInsert: true, ignoreOnUpdate: true)]
		public DateTime? UPDATE { get; set; }

		public string ReturnName()=> nameof(ID);

	}
}
