using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace EterPharmaPro.Utils.Extencions
{
	public static class ExceptionError
	{
		public static void ErrorGet(this Exception ex)
		{
			MessageBox.Show($"{ex.Message}\n{ex}\n", new StackTrace(ex, fNeedFileInfo: true).GetFrame(0).GetMethod().DeclaringType.FullName ?? "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}
}