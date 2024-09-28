using EterPharmaPro.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EterPharmaPro.Models
{
	public class ControladoLoteModel
	{
        public ClienteModel CLIENTE_ID { get; set; }
		List<MedicamentosControladoLoteModel> loteModels {  get; set; }

		
	}
	public class MedicamentosControladoLoteModel
	{
		public string CODIGO_MED { get; set; }
		public string NOME_MED { get; set; }

		public int QUANTIDADE { get; set; }

		public DateTime DATA_VALIDADE { get; set; }

		public string LOTE { get; set; }
	}
}
