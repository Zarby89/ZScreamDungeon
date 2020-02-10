using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui
{
    public partial class WarpsForm : Form
    {
        public WarpsForm()
        {
            InitializeComponent();
        }
        public byte[] properties = new byte[10];
        private void roomProperty_hole_TextChanged(object sender, EventArgs e)
        {
            byte p = 0;
            byte.TryParse(roomProperty_hole.Text, out p);
            properties[0] = p;
            byte.TryParse(roomProperty_holeplane.Text, out p);
            properties[1] = p;
            byte.TryParse(roomProperty_stair1.Text, out p);
            properties[2] = p;
            byte.TryParse(roomProperty_stair1plane.Text, out p);
            properties[3] = p;
            byte.TryParse(roomProperty_stair2.Text, out p);
            properties[4] = p;
            byte.TryParse(roomProperty_stair2plane.Text, out p);
            properties[5] = p;
            byte.TryParse(roomProperty_stair3.Text, out p);
            properties[6] = p;
            byte.TryParse(roomProperty_stair3plane.Text, out p);
            properties[7] = p;
            byte.TryParse(roomProperty_stair4.Text, out p);
            properties[8] = p;
            byte.TryParse(roomProperty_stair4plane.Text, out p);
            properties[9] = p;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
