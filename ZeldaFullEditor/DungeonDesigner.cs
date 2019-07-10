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
    public partial class DungeonDesigner : Form
    {
        public DungeonDesigner()
        {
            InitializeComponent();
        }

        private void layoutPicturebox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkSlateGray, new Rectangle(0, 0, 512, 512));
            for(int i = 0;i<8;i++)
            {
                e.Graphics.DrawLine(Pens.LightSlateGray, 0, i * 64, 512, i * 64);
                e.Graphics.DrawLine(Pens.LightSlateGray, i * 64, 0, i * 64,512);
            }
            
        }

        private void DungeonDesigner_Load(object sender, EventArgs e)
        {

        }
    }
}
