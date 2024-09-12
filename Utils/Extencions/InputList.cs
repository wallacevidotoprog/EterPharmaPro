using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EterPharmaPro.Utils.Extencions
{
	public class InputList : Form
	{
		private object[] objectsList;

		private IContainer components = null;

		private ListBox listBox_list;

		private Label label3;

		private TextBox textBox_busca;

		public int inputIndex { get; private set; }

		public InputList(object[] objects, string title)
		{
			InitializeComponent();
			objectsList = objects;
			listBox_list.Items.Clear();
			for (int i = 0; i < objects.Length; i++)
			{
				listBox_list.Items.Add($"{((object[])objects[i])[0]} - {((object[])objects[i])[1]}");
			}
		}

		public static int Show(object[] objects, string title)
		{
			using (InputList inputBox = new InputList(objects, title))
			{
				return (inputBox.ShowDialog() == DialogResult.OK) ? inputBox.inputIndex : (-1);
			}
		}

		private void listBox_list_DoubleClick(object sender, EventArgs e)
		{
			if (listBox_list.SelectedIndex != -1)
			{
				inputIndex = Convert.ToInt32(listBox_list.Items[listBox_list.SelectedIndex].ToString().Split('-')[0].Trim().Replace(" ", ""));
				base.DialogResult = DialogResult.OK;
			}
			else
			{
				MessageBox.Show("No item selected.");
			}
		}

		private void InputList_Load(object sender, EventArgs e)
		{
		}

		private void textBox_busca_TextChanged(object sender, EventArgs e)
		{
			try
			{
				listBox_list.Items.Clear();
				for (int i = 0; i < objectsList.Length; i++)
				{
					if (((object[])objectsList[i])[1].ToString().Contains(textBox_busca.Text))
					{
						listBox_list.Items.Add($"{((object[])objectsList[i])[0]} - {((object[])objectsList[i])[1]}");
					}
				}
			}
			catch (Exception ex)
			{
				ex.ErrorGet();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.listBox_list = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox_busca = new System.Windows.Forms.TextBox();
			base.SuspendLayout();
			this.listBox_list.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.listBox_list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listBox_list.Font = new System.Drawing.Font("Mongolian Baiti", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.listBox_list.FormattingEnabled = true;
			this.listBox_list.ItemHeight = 21;
			this.listBox_list.Location = new System.Drawing.Point(17, 76);
			this.listBox_list.Name = "listBox_list";
			this.listBox_list.Size = new System.Drawing.Size(991, 338);
			this.listBox_list.TabIndex = 0;
			this.listBox_list.DoubleClick += new System.EventHandler(listBox_list_DoubleClick);
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new System.Drawing.Point(12, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 25);
			this.label3.TabIndex = 14;
			this.label3.Text = "BUSCA:";
			this.textBox_busca.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textBox_busca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.textBox_busca.Font = new System.Drawing.Font("Microsoft Tai Le", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.textBox_busca.Location = new System.Drawing.Point(17, 37);
			this.textBox_busca.Name = "textBox_busca";
			this.textBox_busca.Size = new System.Drawing.Size(991, 33);
			this.textBox_busca.TabIndex = 13;
			this.textBox_busca.TextChanged += new System.EventHandler(textBox_busca_TextChanged);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1020, 423);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.textBox_busca);
			base.Controls.Add(this.listBox_list);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "InputList";
			base.ShowIcon = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "InputList";
			base.Load += new System.EventHandler(InputList_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
