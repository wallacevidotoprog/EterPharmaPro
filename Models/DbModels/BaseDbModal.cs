using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Models.DbModels
{
	public abstract class BaseDbModal
	{
		public long? ID { get; set; }

		public DateTime? CREATE { get; set; }

		public DateTime? UPDATE { get; set; }

	}
}
