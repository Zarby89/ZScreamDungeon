using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Data;

namespace ZeldaFullEditor.Gui.MainTabs
{
    public partial class PaletteEditorTab : UserControl
    {
        List<Panel> palettespanelsList = new List<Panel>();
        int selectedColorIndex = 0;
        PictureBox selectedPalettePicturebox = null;
        int selectedColorLength = 0;
        public PaletteEditorTab()
        {
            InitializeComponent();
        }
        
        private void PaletteEditorTab_Load(object sender, EventArgs e)
        {
            CreatePaletteGroup("HUD", Palettes.HudPalettes);
        }

        private void CreatePaletteGroup(string name, PaletteGroupInfo paletteGroupInfo)
        {
            Panel groupPanel = new Panel();


            for(int i =0;i< paletteGroupInfo.palettes[i].colors.Length;i++)
            {
                Panel palPanel = new Panel();

                Label label = new Label() {Text = name + " " + i.ToString("X2") };
                label.Dock = DockStyle.Top;
                palPanel.Controls.Add(label);

                //create a panel for each colors
                PictureBox palPicturebox = new PictureBox();
                palPicturebox.BackColor = Color.Black;
                palPicturebox.Dock = DockStyle.Top;
                palPicturebox.Tag = paletteGroupInfo.palettes[i].colors[i];
                palPicturebox.Paint += PalPicturebox_Paint;


                palPanel.Controls.Add(palPicturebox);


                palPanel.Dock = DockStyle.Top;
                groupPanel.Controls.Add(palPanel);
            }

            palettespanelsList.Add(groupPanel);


        }

        private void PalPicturebox_Paint(object sender, PaintEventArgs e)
        {
            PaletteInfo pal = (PaletteInfo)(sender as PictureBox).Tag;

            for (int i = 0; i < pal.colors.Length; i++)
            {
                e.Graphics.FillRectangle(new SolidBrush(pal.colors[i]), new Rectangle(((i % pal.width) * 24), (i / pal.width) * 24, 24, 24));
                if (selectedColorIndex != -1 && selectedColorIndex < pal.colors.Length && selectedPalettePicturebox == (sender as PictureBox))
                {
                    e.Graphics.DrawRectangle(new Pen(Color.Aqua, 2), new Rectangle(((selectedColorIndex % pal.width) * 24), (selectedColorIndex / pal.width) * 24, 24, 24));
                    if (selectedColorLength > 1)
                    {
                        e.Graphics.DrawRectangle(new Pen(Color.Aqua, 1), new Rectangle(((selectedColorIndex % pal.width) * 24), (selectedColorIndex / pal.width) * 24, 24 * selectedColorLength, 24));
                    }
                }

            }
        }
    }
}
