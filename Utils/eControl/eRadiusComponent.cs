using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EterPharmaPro.Utils.eControl
{
	public class eRadiusComponent : Component
	{
		private Control _targetControl;
		//Fields
		private int borderSize = 0;
		private int borderRadius = 0;
		private Color borderColor = Color.Black;

		//Properties
		[Category("Custom")]
		public int BorderSize
		{
			get { return borderSize; }
			set
			{
				borderSize = value;
				if (!(_targetControl is null))
				{
					_targetControl.Invalidate();
				}

			}
		}

		[Category("Custom")]
		public int BorderRadius
		{
			get { return borderRadius; }
			set
			{
				borderRadius = value;
				if (!(_targetControl is null))
				{
					_targetControl.Invalidate();
				}
			}
		}

		[Category("Custom")]
		public Color BorderColor
		{
			get { return borderColor; }
			set
			{
				borderColor = value;
				if (!(_targetControl is null))
				{
					_targetControl.Invalidate();
				}
			}
		}

		


		[Browsable(true)]
		[Category("Behavior")]
		[Description("The target control in the same form.")]
		public Control TargetControl
		{
			get => _targetControl;
			set
			{
				_targetControl = value;
				OnTargetControlChanged();
			}
		}

		protected virtual void OnTargetControlChanged()
		{
			if (_targetControl != null)
			{
				UpdateRadiusCode();
			}
		}

		private void UpdateRadiusCode()
		{

			if (_targetControl is TextBox textBox)
			{
				_targetControl.Paint += _targetControl_Paint;
				_targetControl.HandleCreated += _targetControl_HandleCreated;
				_targetControl.Resize += _targetControl_Resize;
			}
		}

		private void _targetControl_Resize(object sender, EventArgs e)
		{
			if (!(_targetControl is null))
			{
				if (borderRadius > _targetControl.Height)
					borderRadius = _targetControl.Height;
			}
		}

		private void _targetControl_HandleCreated(object sender, EventArgs e)
		{
			_targetControl.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
		}

		private void _targetControl_Paint(object sender, PaintEventArgs pevent)
		{
			Rectangle rectSurface = _targetControl.ClientRectangle;
			Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
			int smoothSize = 2;
			if (borderSize > 0)
				smoothSize = borderSize;

			if (borderRadius > 2) //Rounded button
			{
				using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
				using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
				using (Pen penSurface = new Pen(_targetControl.Parent.BackColor, smoothSize))
				using (Pen penBorder = new Pen(borderColor, borderSize))
				{
					pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

					_targetControl.Region = new Region(pathSurface);

					pevent.Graphics.DrawPath(penSurface, pathSurface);


					if (borderSize >= 1)

						pevent.Graphics.DrawPath(penBorder, pathBorder);
				}
			}
			else
			{
				pevent.Graphics.SmoothingMode = SmoothingMode.None;

				_targetControl.Region = new Region(rectSurface);

				if (borderSize >= 1)
				{
					using (Pen penBorder = new Pen(borderColor, borderSize))
					{
						penBorder.Alignment = PenAlignment.Inset;
						pevent.Graphics.DrawRectangle(penBorder, 0, 0, _targetControl.Width - 1, _targetControl.Height - 1);
					}
				}
			}
		}

		private GraphicsPath GetFigurePath(Rectangle rect, int radius)
		{
			GraphicsPath path = new GraphicsPath();
			float curveSize = radius * 2F;

			path.StartFigure();
			path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
			path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
			path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
			path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
			path.CloseFigure();
			return path;
		}

		private void Container_BackColorChanged(object sender, EventArgs e)
		{
			_targetControl.Invalidate();
		}
	}
}


