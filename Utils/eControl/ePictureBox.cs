using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EterPharmaPro.Utils.eControl
{
	public class ePictureBox : PictureBox
	{
		private ToolTip toolTip;

		private string toolTipText;

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Category("Appearance")]
		[Description("Define o texto do ToolTip exibido quando o mouse passa sobre o controle.")]
		public string ToolTipText
		{
			get
			{
				return toolTipText;
			}
			set
			{
				toolTipText = value;
				toolTip.SetToolTip(this, toolTipText);
			}
		}

		public ePictureBox()
		{
			toolTip = new ToolTip();
			base.MouseHover += OnMouseHover;
		}

		private void OnMouseHover(object sender, EventArgs e)
		{
			toolTip.SetToolTip(this, toolTipText);
		}
	}
}
