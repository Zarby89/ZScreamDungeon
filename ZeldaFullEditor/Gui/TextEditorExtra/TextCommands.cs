using System;
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
    public partial class TextCommands : Form
    {
        public TextCommands()
        {
            InitializeComponent();
        }
        public int cvalue = 0;
        public int selectedCommand = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out cvalue))
            {
                selectedCommand = listBox1.SelectedIndex;
                this.Close();
            }
            else
            {
                MessageBox.Show("Value is invalid.");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex <= 8)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
