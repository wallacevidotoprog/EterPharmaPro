using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Models.DbModels
{
	public class ProdutoValidadeDbModal : BaseDbModal
	{
        public int VALIDADE_ID { get; set; }
        public int PRODUTO_CODIGO { get; set; }
		public string PRODUTO_DESCRICAO { get; set; }
		public int QUANTIDADE { get; set; }
        public int CATEGORIA_ID { get; set; }
    }
}
