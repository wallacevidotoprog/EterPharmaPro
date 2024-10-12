using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastNotification.Enum;
using ToastNotification;

namespace EterPharmaPro.Utils
{
	public static class Notification
	{
		public static void SendNotification(string msg, TypeAlertEnum typeAlert)
		{
			AlertBox alertBox = new AlertBox();
			alertBox.ShowAlert(msg, typeAlert);
		}
	}
}
