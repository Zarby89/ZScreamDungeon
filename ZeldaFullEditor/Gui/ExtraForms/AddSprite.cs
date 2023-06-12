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
    public partial class AddSprite : Form
    {
        public AddSprite()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddSprite_Load(object sender, EventArgs e)
        {
            spriteListBox.Items.Clear();
            spriteListBox.Items.AddRange(Sprites_Names.name);
            spriteListBox.SelectedIndex = 0;
        }
    }
}
