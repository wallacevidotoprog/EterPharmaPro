using EterPharmaPro.Utils.Log;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using ToastNotification;
using ToastNotification.Enum;

namespace EterPharmaPro.Utils.Extencions
{
	public static class ExceptionError
	{
		public static void ErrorGet(this Exception ex, bool popup = true)
		{
			SetLog(ex);
			SendAlertBox.Send(ex.Message, TypeAlertEnum.Error);
			if (popup)
			{
				MessageBox.Show($"{ex.Message}\n{ex}\n", new StackTrace(ex, fNeedFileInfo: true).GetFrame(0).GetMethod().DeclaringType.FullName ?? "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		private static void SetLog(Exception ex)
		{
			LogSistem.LogWriteLog(TypeLog.ERROR, new StackTrace(ex, fNeedFileInfo: true).GetFrame(0).GetMethod().DeclaringType.FullName ?? "", ex.Message, ex);
		}
	}
}