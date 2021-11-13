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
    public partial class RoomMover : Form
    {
        public RoomMover()
        {
            InitializeComponent();
        }
        string filePath = "";

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Alttp US ROM .sfc|*.sfc;*.smc";
            of.DefaultExt = ".sfc";
            if (of.ShowDialog() == DialogResult.OK)
            {
                filePath = of.FileName;
                textBox1.Text = filePath;
            }


        }

        private void RoomMover_Load(object sender, EventArgs e)
        {
            for(int i =0; i<296;i++)
            {
                checkedListBox1.Items.Add("Room " + i.ToString("X3") + " - " + Room_Name.room_name[i],true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
