using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
    public partial class GotoRoom : Form
    {
        public GotoRoom()
        {
            InitializeComponent();
        }
        public int selectedRoom = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            selectedRoom = Convert.ToInt32(textBox1.Text);
        }

        private void GotoRoom_Load(object sender, EventArgs e)
        {

        }
    }
}
