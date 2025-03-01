using System;
using System.Drawing;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui
{
    public partial class NoteAdd : Form
    {
        public Color color = Color.White;

        public NoteAdd()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                label1.Font = fontDialog1.Font;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog1.Color;
                label1.ForeColor = color;
            }
        }
    }
}
