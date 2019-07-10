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
    public partial class DuplicateSpriteStateForm : Form
    {
        public DuplicateSpriteStateForm()
        {
            InitializeComponent();
        }
        public SceneOW scene;
        private void button1_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                Sprite[] sprites = new Sprite[scene.ow.allmaps[scene.selectedMap].sprites[comboBox1.SelectedIndex].Count];
                scene.ow.allmaps[scene.selectedMap].sprites[comboBox1.SelectedIndex].CopyTo(sprites, 0);
                scene.ow.allmaps[scene.selectedMap].sprites[comboBox2.SelectedIndex] = sprites.ToList();
            }
            else
            {
                for (int i = 0; i < 160; i++)
                {
                    if (scene.ow.allmaps[i].sprites[comboBox1.SelectedIndex] != null)
                    {
                        Sprite[] sprites = new Sprite[scene.ow.allmaps[i].sprites[comboBox1.SelectedIndex].Count];
                        scene.ow.allmaps[i].sprites[comboBox1.SelectedIndex].CopyTo(sprites, 0);
                        scene.ow.allmaps[i].sprites[comboBox2.SelectedIndex] = sprites.ToList();
                    }
                }
            }


            this.Close();
        }
    }
}
