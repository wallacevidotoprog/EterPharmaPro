using System;

namespace EterPharmaPro.Models.Tag
{
	public class PrintTagPriceModel
	{
		public ProdutosModel PRODUTO { get; set; }


		public string NAME_ITEM { get; set; }
		public decimal OLD_PRICE { get; set; }

		public decimal NEW_PRICE { get; set; }

		public DateTime DATE_VALITY { get; set; }

		public TableTagValidityModal TAG { get; set; }
	}
}
