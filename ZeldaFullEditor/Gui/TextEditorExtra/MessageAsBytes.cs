using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Data;

namespace ZeldaFullEditor.Gui.TextEditorExtra
{
    public partial class MessageAsBytes : Form
    {
        private byte[] rawData;
        private byte[] parsedData;
        private bool showParsed = false;

        private int separatorIndex = 1;
        private int prefixIndex = 0;

        public MessageAsBytes()
        {
            this.InitializeComponent();
            this.SeparatorChoose.SelectedIndex = this.separatorIndex;
            this.PrefixChoose.SelectedIndex = this.prefixIndex;
        }

        public void ShowBytes(MessageData a)
        {
            this.rawData = a.Data;
            this.parsedData = a.DataParsed;

            this.UpdateTextBox();
            this.ShowDialog();
        }

        private void UpdateTextBox()
        {
            byte[] data = this.showParsed ? this.parsedData : this.rawData;

            if (data == null)
            {
                return;
            }

            var stringBuilder = new StringBuilder();
            this.SizeOfMessage.Text = string.Format("{0:D} (0x{0:X}) bytes", data.Length + 1);

            foreach (byte value in data)
            {
                switch (this.prefixIndex)
                {
                    case 0:
                    default:
                        break;
                    case 1:
                        stringBuilder.Append("0x");
                        break;
                    case 2:
                        stringBuilder.Append("$");
                        break;
                }

                stringBuilder.Append(value.ToString("X2"));
                switch (this.separatorIndex)
                {
                    case 0:
                    default:
                        break;
                    case 1:
                        stringBuilder.Append(" ");
                        break;
                    case 2:
                        stringBuilder.Append(", ");
                        break;
                }
            }

            switch (this.prefixIndex)
            {
                case 0:
                default:
                    break;
                case 1:
                    stringBuilder.Append("0x");
                    break;
                case 2:
                    stringBuilder.Append("$");
                    break;
            }

            stringBuilder.Append(TextEditor.MessageTerminator.ToString("X2"));

            this.textBox1.Text = stringBuilder.ToString();
        }

        private void SeparatorChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.separatorIndex = this.SeparatorChoose.SelectedIndex;
            this.UpdateTextBox();
        }

        private void PrefixChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.prefixIndex = this.PrefixChoose.SelectedIndex;
            this.UpdateTextBox();
        }

        private void FormatCheckedChanged(object sender, EventArgs e)
        {
            this.showParsed = this.radioButton2.Checked;
            this.UpdateTextBox();
        }
    }
}
