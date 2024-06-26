﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ZeldaFullEditor.Gui.TextEditorExtra
{
	public partial class MessageAsBytes : Form
	{
		private byte[] datar;
		private byte[] datap;
		private bool showparsed = false;

		private int sep = 1;
		private int pre = 0;

		public MessageAsBytes()
		{
			InitializeComponent();
			SeparatorChoose.SelectedIndex = sep;
			PrefixChoose.SelectedIndex = pre;
		}

		public void ShowBytes(TextEditor.MessageData a)
		{
			datar = a.Data;
			datap = a.DataParsed;

			UpdateTextBox();
			ShowDialog();
		}

		private void UpdateTextBox()
		{
			byte[] data = showparsed ? datap : datar;

			if (data == null)
			{
				return;
			}

			StringBuilder s = new StringBuilder();
			SizeOfMessage.Text = string.Format("{0:D} (0x{0:X}) bytes", data.Length + 1);

			foreach (byte b in data)
			{
				switch (pre)
				{
					case 0:
					default:
						break;
					case 1:
						s.Append("0x");
						break;
					case 2:
						s.Append("$");
						break;
				}

				s.Append(b.ToString("X2"));
				switch (sep)
				{
					case 0:
					default:
						break;
					case 1:
						s.Append(" ");
						break;
					case 2:
						s.Append(", ");
						break;
				}
			}

			switch (pre)
			{
				case 0:
				default:
					break;
				case 1:
					s.Append("0x");
					break;
				case 2:
					s.Append("$");
					break;
			}

			s.Append(TextEditor.MESSAGETERMINATOR.ToString("X2"));

			this.textBox1.Text = s.ToString();
		}

		private void SeparatorChoose_SelectedIndexChanged(object sender, EventArgs e)
		{
			sep = SeparatorChoose.SelectedIndex;
			UpdateTextBox();
		}

		private void PrefixChoose_SelectedIndexChanged(object sender, EventArgs e)
		{
			pre = PrefixChoose.SelectedIndex;
			UpdateTextBox();
		}

		private void FormatCheckedChanged(object sender, EventArgs e)
		{
			showparsed = radioButton2.Checked;
			UpdateTextBox();
		}
	}
}
