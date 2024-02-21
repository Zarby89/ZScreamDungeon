using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor.Gui.ExtraForms.ZSESettings
{
    public partial class ZSEDungeon : UserControl
    {
        public ZSEDungeon()
        {
            InitializeComponent();
        }
        
        private void openedroomColorPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private unsafe void ZSEDungeon_Load(object sender, EventArgs e)
        {
            UpdateColors();


        }

        private void Colors_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            colorPicker.Color = (sender as Panel).BackColor;
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                if (sender == openedselectedroomColorPanel) { Settings.Default.SelectedRoomOutline = colorPicker.Color; };
                if (sender == openedroomColorPanel) { Settings.Default.OpenedRoomOutline = colorPicker.Color; };
                if (sender == selectedforexportColorPanel) { Settings.Default.OpenedExportedRoomOutline = colorPicker.Color; };
                if (sender == openedroomexportColorPanel) { Settings.Default.ExportedRoomOutline = colorPicker.Color; };
            }

            UpdateColors();

        }

        private void UpdateColors()
        {
            openedselectedroomColorPanel.BackColor = Settings.Default.SelectedRoomOutline;
            openedroomColorPanel.BackColor = Settings.Default.OpenedRoomOutline;
            selectedforexportColorPanel.BackColor = Settings.Default.OpenedExportedRoomOutline;
            openedroomexportColorPanel.BackColor = Settings.Default.ExportedRoomOutline;
        }
    }
}
