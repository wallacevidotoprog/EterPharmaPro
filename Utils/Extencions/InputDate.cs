using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro.Utils.Extencions
{
	public partial class InputDate : Form
	{
		private static DateTime? date;
		public InputDate()
		{
			InitializeComponent();
		}

		public static new DateTime? Show()
		{
			
			using (InputDate inputDate = new InputDate())
			{
				return inputDate.ShowDialog() == DialogResult.OK ? date : null;
			}
		}

		private void button_ok_Click(object sender, EventArgs e)
		{
			this.Focus();

			date = dateTimePicker_data.Value;
			base.DialogResult = DialogResult.OK;
		}

		private void button_cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}
	}
}
