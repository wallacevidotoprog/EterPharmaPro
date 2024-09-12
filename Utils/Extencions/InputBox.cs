using System;
using System.Drawing;
using System.Windows.Forms;

namespace EterPharmaPro.Utils.Extencions
{
	public class InputBox : Form
	{
		private TextBox inputTextBox;

		private Button okButton;

		private Button cancelButton;

		public string InputText { get; private set; }

		public InputBox(string prompt, string title, bool pass)
		{
			Text = title;
			base.Width = 300;
			base.Height = 150;
			base.StartPosition = FormStartPosition.CenterParent;
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.AcceptButton = okButton;
			base.CancelButton = cancelButton;
			Label promptLabel = new Label
			{
				Text = prompt,
				AutoSize = true,
				Location = new Point(10, 10)
			};
			base.Controls.Add(promptLabel);
			inputTextBox = new TextBox
			{
				Location = new Point(10, 40),
				Width = 260,
				CharacterCasing = CharacterCasing.Upper
			};
			if (pass)
			{
				inputTextBox.PasswordChar = '*';
			}
			inputTextBox.KeyDown += OkButton_KeyDown;
			base.Controls.Add(inputTextBox);
			okButton = new Button
			{
				Text = "OK",
				DialogResult = DialogResult.OK,
				Location = new Point(110, 70)
			};
			okButton.Click += OkButton_Click;
			base.Controls.Add(okButton);
			cancelButton = new Button
			{
				Text = "Cancelar",
				DialogResult = DialogResult.Cancel,
				Location = new Point(200, 70)
			};
			base.Controls.Add(cancelButton);
		}

		private void OkButton_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				InputText = inputTextBox.Text;
				base.DialogResult = DialogResult.OK;
			}
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			InputText = inputTextBox.Text;
		}

		public static string Show(string prompt, string title, bool pass = false)
		{
			using (InputBox inputBox = new InputBox(prompt, title, pass))
			{
				return (inputBox.ShowDialog() == DialogResult.OK) ? inputBox.InputText : null;
			}
		}
	}
}

