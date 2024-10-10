using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EterPharmaPro.Utils.eControl
{
	public class eTextBoxWithButton : UserControl
	{

		private TextBox textBox;
		private Button rightButton;

		public eTextBoxWithButton()
		{
			// Inicializando o TextBox
			textBox = new TextBox
			{
				Dock = DockStyle.Fill,
			};

			// Inicializando o Button
			rightButton = new Button
			{
				Text = "...",
				AutoSize = true,
				Dock = DockStyle.Right,
				Visible = true,
				Cursor = Cursors.Hand,
				BackColor = System.Drawing.Color.DarkGreen,
				ForeColor = System.Drawing.Color.White,

			};


			// Adicionando controles ao UserControl
			 this.Controls.Add(rightButton);
			this.Controls.Add(textBox);

			// Associar o evento de clique padrão ao botão
			rightButton.Click += RightButton_Click;
			textBox.Validated += TexBox_Validated;
		}

		

		public void Clear()
		{
			textBox.Clear();
		}
		public TextBox ReturnTexBox()=>textBox;
		


		// Propriedade para o texto do TextBox
		[Browsable(true)]
		[Category("Custom Properties")]
		[Description("Texto exibido no TextBox.")]
		public string GetText
		{
			get { return textBox.Text; }
			set { textBox.Text = value; }
		}

		// Propriedade para a visibilidade do botão
		[Browsable(true)]
		[Category("Custom Properties")]
		[Description("Define se o botão à direita está visível.")]
		public bool ButtonVisible
		{
			get { return rightButton.Visible; }
			set { rightButton.Visible = value; }
		}

		// Propriedade para o texto do botão
		[Browsable(true)]
		[Category("Custom Properties")]
		[Description("Texto ou ícone exibido no botão.")]
		public string ButtonText
		{
			get { return rightButton.Text; }
			set { rightButton.Text = value; }
		}

		// Evento de clique do botão exposto no designer
		[Browsable(true)]
		[Category("Custom")] // Categoria "Action", usada para eventos como em controles padrão
		[Description("Ocorre quando o botão é clicado.")]
		public event EventHandler ButtonClick;

		// Método interno que lida com o clique do botão
		private void RightButton_Click(object sender, EventArgs e)
		{
			// Disparar o evento ButtonClick, se houver assinantes
			if (ButtonClick != null)
			{
				ButtonClick.Invoke(this, e); // Disparar o evento público
			}
		}


		[Browsable(true)]
		[Category("Custom")] // Categoria "Action", usada para eventos como em controles padrão
		[Description("Ocorre quando o campo é validado.")]
		public event EventHandler TexBoxValidated;
		private void TexBox_Validated(object sender, EventArgs e)
		{
			if (TexBoxValidated != null)
			{
				TexBoxValidated.Invoke(this, e); // Disparar o evento público
			}
		}
	}
}
