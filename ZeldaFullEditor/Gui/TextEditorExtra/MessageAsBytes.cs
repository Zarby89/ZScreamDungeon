using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ZeldaFullEditor.Data;

namespace ZeldaFullEditor.Gui.TextEditorExtra
{
	public partial class MessageAsBytes : Form
	{
		private bool showParsed = false;
		private MessageData displayedMessage = null;

		private string SeparatorString = string.Empty;
		private string PrefixString = string.Empty;

		public MessageAsBytes()
		{
			InitializeComponent();
			SeparatorChoose.SelectedIndex = 1;
			PrefixChoose.SelectedIndex = 0;
		}

		public void ShowBytes(MessageData a)
		{
			displayedMessage = a;
			UpdateTextBox();
			ShowDialog();
		}

		private void UpdateTextBox()
		{
			byte[] msgData = showParsed ? displayedMessage?.DataParsed : displayedMessage?.Data;

			if (msgData == null)
			{
				textBox1.Text = "ERROR";
				SizeOfMessage.Text = "ERROR";
				return;
			}

			var data = msgData.Append(TextEditor.MessageTerminator);

			var dataReadable = data.Select(b => $"{PrefixString}{b:X2}");

			textBox1.Text = string.Join(SeparatorString, dataReadable);

			SizeOfMessage.Text = string.Format("{0:D} bytes (0x{0:X3})", data.Count());
		}

		private void SeparatorChoose_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (SeparatorChoose.SelectedIndex)
			{
				case 0:
				default:
					SeparatorString = string.Empty;
					break;
				case 1:
					SeparatorString = " ";
					break;
				case 2:
					SeparatorString = ", ";
					break;
			}

			UpdateTextBox();
		}

		private void PrefixChoose_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (PrefixChoose.SelectedIndex)
			{
				case 0:
				default:
					PrefixString = string.Empty;
					break;
				case 1:
					PrefixString = "0x";
					break;
				case 2:
					PrefixString = "$";
					break;
			}

			UpdateTextBox();
		}

		private void FormatCheckedChanged(object sender, EventArgs e)
		{
			showParsed = radioButton2.Checked;
			UpdateTextBox();
		}
	}
}
