using EterPharmaPro.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Models
{
	public class ValityExportModel
	{
		public long? ID_LOJA { get; set; }
		public string NAME { get; set; }

		public List<ProdutoValidadeDbModal> produtoValidadeDbModals { get; set; }
		public List<CategoriaDbModal> categoriasDbModals { get; set; }
	}
}
