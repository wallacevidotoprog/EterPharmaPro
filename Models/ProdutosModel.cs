using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Models
{
	public class ProdutosModel
	{
		public string EAN { get; set; }

		public string COD_PRODUTO { get; set; }

		public string DESCRICAO_PRODUTO { get; set; }

		public bool STATUS { get; set; }

		public string LABORATORIO { get; set; }

		public string GRUPO { get; set; }
	}
}
