using EterPharmaPro.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Models
{
	public class SetValityModel
	{
		public bool isEdit { get; set; } = false;
		public long? id { get; set; }
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

		public ProdutoSetValityModel ConvertDbModel(ProdutoValidadeDbModal modal,long? id = null)
		{
			return new ProdutoSetValityModel
			{
				id = id,
				codigo = modal.PRODUTO_CODIGO,
				descricao = modal.PRODUTO_DESCRICAO,
				quantidade = modal.QUANTIDADE,
				dateVality = modal.DATA_VALIDADE,
				category_id = modal.CATEGORIA_ID
			};
		}
	}
}
