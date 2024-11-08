using EterPharmaPro.Enums;
using System.Drawing;

namespace EterPharmaPro.Utils.Extencions
{
	public class StatsDeliveryDataGridViewColumn
	{
		public static Image ObterIconeEstado(StatsDeliveryEnum estado)
		{
			switch (estado)
			{
				case StatsDeliveryEnum.NEW:
					return Properties.Resources.delivery_open;
				case StatsDeliveryEnum.FINALIZED:
					return Properties.Resources.delivery_finalized;
				case StatsDeliveryEnum.ON_ROUTE:
					return Properties.Resources.on_route;
				case StatsDeliveryEnum.CANCELED:
					return Properties.Resources.delivery_canceled;
				default:
					return null;
			}
		}
	}
}
