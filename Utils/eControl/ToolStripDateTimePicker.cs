using System;
using System.Drawing;
using System.Windows.Forms;

namespace EterPharmaPro.Utils.eControl
{
	public class ToolStripDateTimePicker : ToolStripItem
	{
		// Armazena a data selecionada
		private DateTime selectedDate;

		// Propriedade para expor a data selecionada
		public DateTime SelectedDate
		{
			get { return selectedDate; }
			set
			{
				selectedDate = value;
				Invalidate();  // Redesenha o controle quando a data muda
			}
		}

		// Construtor
		public ToolStripDateTimePicker()
		{
			selectedDate = DateTime.Now; // Data inicial
		}

		// Método para pintar o componente no ToolStrip
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			// Desenha uma "caixa de texto" com a data
			using (Brush textBrush = new SolidBrush(SystemColors.ControlText))
			{
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, Width, Height));
				e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(0, 0, Width - 1, Height - 1));
				e.Graphics.DrawString(selectedDate.ToShortDateString(), Font, textBrush, new PointF(5, 5));
			}
		}

		// Método para tratar eventos de clique
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);

			// Abre um DateTimePicker para selecionar a data
			using (MonthCalendar calendar = new MonthCalendar())
			{
				Form calendarForm = new Form
				{
					FormBorderStyle = FormBorderStyle.None,
					ShowInTaskbar = false,
					StartPosition = FormStartPosition.Manual,
					Location = new Point(Cursor.Position.X, Cursor.Position.Y),
					Size = calendar.Size
				};

				calendarForm.Controls.Add(calendar);

				calendar.DateSelected += (sender, args) =>
				{
					// Atualiza a data selecionada quando o usuário escolher uma data
					SelectedDate = args.Start;
					calendarForm.Close();  // Fecha o calendário
				};

				calendarForm.ShowDialog(); // Exibe o calendário
			}
		}

		// Define o tamanho do item
		protected override Size DefaultSize
		{
			get { return new Size(100, 25); }
		}
	}
}
