using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui.ExtraForms.ZSESettings
{
    public partial class ZSEditorSettings : Form
    {
        public ZSEditorSettings()
        {
            InitializeComponent();
        }

        private void ZSEditorSettings_Load(object sender, EventArgs e)
        {
            ZSEDungeonSettings zSEDungeonSettings = new ZSEDungeonSettings();
            settingPropertygrid.SelectedObject = zSEDungeonSettings;
        }

        private void propertyGrid1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            settingPropertygrid.ResetSelectedProperty();

        }
    }
}
