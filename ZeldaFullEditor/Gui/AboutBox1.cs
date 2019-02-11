using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
        }

        private void Donate_Click(object sender, EventArgs e)
        {
            var url = pbxDonate.Tag as string;
            Process.Start(url);
        }
    }
}
