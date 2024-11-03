namespace EterPharmaPro.Models.DbModels
{
	public class DeliveryViewDbModel
	{
		public readonly EntregaDbModel entregaDbModel;
		public readonly EntregaInputDbModel entregaInputDbModel;
		public DeliveryViewDbModel(EntregaDbModel entregaDbModel, EntregaInputDbModel entregaInputDbModel)
		{
			this.entregaDbModel = entregaDbModel;
			this.entregaInputDbModel = entregaInputDbModel;
		}

		public string UserV {  get; set; }
		public string UserE { get; set; }
		public string Cliente { get; set; }
		public string Endereco { get; set; }
		public string Tipo { get; set; }
	}
}
