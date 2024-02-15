using System;
using System.Globalization;
using System.Windows.Forms;

namespace ZeldaFullEditor
{

	// TODO KAN REFACTOR : add a field for SNES address
	public partial class MovePointer : Form
    {
        public int address;

        public MovePointer()
        {
            InitializeComponent();

            this.address = Constants.room_header_expanded_default;
            this.textBox1.Text = this.address.ToString("X2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out this.address);
            this.Close();
        }
    }
}
