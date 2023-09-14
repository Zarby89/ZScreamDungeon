using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
    public partial class MovePointer : Form
    {
        public int address = 0x110000;

        public MovePointer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out address);
            this.Close();
        }
    }
}
