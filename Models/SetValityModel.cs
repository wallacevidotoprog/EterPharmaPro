using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Models
{
	public class SetValityModel
	{
		public long? user_id { get; set; }
		public int user_idLoja { get; set; }

		public DateTime dataCreate { get; set; }

		public long? vality_id { get; set; }

		public ProdutoSetValityModel produto { get; set; }

	}
	public class ProdutoSetValityModel
	{
		public long? id { get; set; }
		public int codigo { get; set; }

		public string descricao { get; set; }

		public int quantidade { get; set; }
		public DateTime dateVality { get; set; }
		public int category_id { get; set; }
	}
}
