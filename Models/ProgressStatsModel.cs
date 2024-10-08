using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Models
{
	public class ProgressStatsModel
	{
		public int Max { get; set; } = 0;
		public int Min { get; set; } = 0;
		public int Progress { get; set; } = 0;
	}
}
