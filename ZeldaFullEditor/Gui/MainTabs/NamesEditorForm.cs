using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui.MainTabs
{
    public partial class NamesEditorForm : UserControl
    {
        public NamesEditorForm()
        {
            InitializeComponent();
        }

        private void NamesEditorForm_Load(object sender, EventArgs e)
        {

            ChestItemsSubPanel.Height = 0x4C * 24;
            for (int i = 0; i < 0x4C; i++)
            {
                Panel panel = new Panel() { Height = 24, Dock = DockStyle.Top };
                Label label = new Label() { Text = "Chest Item " + i.ToString("X2") + " {" + ChestItems_Name.Defaultnames[i] + "}", Dock = DockStyle.Left, Width = 200 };
                TextBox textbox = new TextBox() { Text = ChestItems_Name.name[i], Dock = DockStyle.Left, Width = 400 };

                panel.Controls.Add(textbox);
                panel.Controls.Add(label);
                ChestItemsSubPanel.Controls.Add(panel);
                panel.BringToFront();
            }

            ItemsSubPanel.Height = 0x1C * 24;
            for (int i = 0; i < 0x1C; i++)
            {
                Panel panel = new Panel() { Height = 24, Dock = DockStyle.Top };
                Label label = new Label() { Text = "Item " + i.ToString("X2") + " {" + Constants.SecretItemNames[i] + "}", Dock = DockStyle.Left, Width = 200 };
                TextBox textbox = new TextBox() { Text = ItemsNames.name[i], Dock = DockStyle.Left, Width = 400 };

                panel.Controls.Add(textbox);
                panel.Controls.Add(label);
                ItemsSubPanel.Controls.Add(panel);
                panel.BringToFront();
            }


        }
    }
}
