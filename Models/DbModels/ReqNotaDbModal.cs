using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Models.DbModels
{
	public class ReqNotaDbModal : BaseDbModal
	{
        public long? CQN_ID { get; set; }
        public string REQ { get; set; }
    }
}
