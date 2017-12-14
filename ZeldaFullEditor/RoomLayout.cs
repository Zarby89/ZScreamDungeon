using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
    public partial class RoomLayout : Form
    {
        public RoomLayout()
        {
            InitializeComponent();
            foreach (string s in Directory.EnumerateDirectories("Layout\\"))
            {
                tabControl1.TabPages.Add(Path.GetFileName(s));
            }



        }

        private void RoomLayout_Load(object sender, EventArgs e)
        {

            
        }
    }
}
