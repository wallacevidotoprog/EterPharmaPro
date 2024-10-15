using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Models.DbModels
{
	public class ControlReqNotaDbModal : BaseDbModal
	{
        public long? VENDEDOR { get; set; }
		public long? AUTHOR { get; set; }

		public DateTime DATA_VENDA { get; set; }
		public DateTime DATA_ENVIO { get; set; }
	}
}
