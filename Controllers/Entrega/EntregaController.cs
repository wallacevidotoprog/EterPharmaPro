using EterPharmaPro.Interfaces;
using EterPharmaPro.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EterPharmaPro.Controllers.Entrega
{
	public class EntregaController
	{
		public event EventHandler loadCompleteLists;

		private readonly IEterDb eterDb;
		public List<UserModel> listUser { get; private set; }
		public List<TypeDeliveryDbModel> listTypeDelivery { get; private set; }

		public List<DeliveryViewDbModel> deliveryViewDbModels { get; private set; }

		public EntregaController(IEterDb eterDb)
		{
			this.eterDb = eterDb;
			_ = GetAllUserAsync();
		}
		private async Task GetAllUserAsync()
		{
			listUser = await eterDb.ActionDb.GETFIELDS<UserModel>(new QueryWhereModel());
			listTypeDelivery = await eterDb.ActionDb.GETFIELDS<TypeDeliveryDbModel>(new QueryWhereModel());
			deliveryViewDbModels = await ModelViewDeliveryAsync();

			loadCompleteLists?.Invoke(this, new EventArgs());
		}
		private async Task<List<DeliveryViewDbModel>> ModelViewDeliveryAsync()
		{
			List<DeliveryViewDbModel> models = new List<DeliveryViewDbModel>();

			var di = await eterDb.ActionDb.GETFIELDS<EntregaInputDbModel>(new QueryWhereModel());
			var d = await eterDb.ActionDb.GETFIELDS<EntregaDbModel>(new QueryWhereModel());

			for (int i = 0; i < di.Count; i++)
            {
				string clienteName = (await eterDb.ActionDb.GETFIELDS<ClienteDbModel>(new QueryWhereModel().SetWhere("ID", di[i].CLIENTE_ID))).FirstOrDefault()?.NOME;
				EnderecoClienteDbModel tempEnd = (await eterDb.ActionDb.GETFIELDS<EnderecoClienteDbModel>(new QueryWhereModel().SetWhere("ID", di[i].ENDERECO_ID))).FirstOrDefault();
				string endereco = $"{tempEnd?.ENDERECO} - {tempEnd?.OBSERVACAO}";
				EntregaDbModel tempc = d.Where(x => x.DELIVERY_INPUT_ID == di[i].ID).FirstOrDefault();
				string dMan = listUser.Where(x => x.ID == tempc.USER_ID).FirstOrDefault()?.NOME;
				string dVend = listUser.Where(x => x.ID == d[i].USER_ID).FirstOrDefault()?.NOME;

				models.Add(new DeliveryViewDbModel(tempc, di[i])
				{
					Cliente = clienteName,
					Endereco = endereco,
					UserE = dMan,
					UserV = dVend,
					Tipo = listTypeDelivery.Where(x => x.ID == di[i].TYPE_DELIVERY).FirstOrDefault()?.NAME

				});

			}
            return models;
		}

		public List<DeliveryViewDbModel> ModelViewDeliveryByDate( DateTime? dateTime)
		{
			return !(dateTime is null) ? deliveryViewDbModels.Where(x => x.entregaInputDbModel.DATA == dateTime).ToList() : deliveryViewDbModels;
		}

	}
}
