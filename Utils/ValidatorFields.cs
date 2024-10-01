using System.Collections.Generic;
using System.Windows.Forms;

namespace EterPharmaPro.Utils
{
	public class ValidatorFields
	{
		private List<Control> controls;

		public ValidatorFields()
		{
			controls = new List<Control>();
		}

		public void SetListControl(List<Control> _controls)
		{
			controls = _controls;
		}
		public bool ValidateFields()
		{
			bool allFieldsValid = true;
			int x = 0;
			foreach (var control in controls)
			{
				if (string.IsNullOrWhiteSpace(control.Text))
				{
					ToolTip validationToolTip = new ToolTip
					{
						IsBalloon = true,
						ToolTipIcon = ToolTipIcon.Warning,
						ToolTipTitle = "Campo Obrigatório"
					};
					validationToolTip.Show("Este campo é obrigatório", control, x, -40, 3000);
					x += 100;
					allFieldsValid = false;
				}
			}

			return allFieldsValid;
		}
	}
	
}
