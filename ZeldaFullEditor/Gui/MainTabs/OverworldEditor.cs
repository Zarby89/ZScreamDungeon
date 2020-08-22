using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Drawing.Drawing2D;
using ZeldaFullEditor.Gui.ExtraForms;

namespace ZeldaFullEditor.Gui
{
    public partial class OverworldEditor : UserControl
    {
        public OverworldEditor()
        {
            InitializeComponent();
        }
        public Overworld overworld;
        public SceneOW scene;
        public bool propertiesChangedFromForm = false;
        public DungeonMain mainForm;
        public Bitmap tmpPreviewBitmap = new Bitmap(256,256);
        public void InitOpen(DungeonMain mainForm)
        {
            overworld = new Overworld();
            scene = new SceneOW(this, overworld, mainForm);
            scene.Location = new Point(0, 0);
            scene.Size = new Size(4096, 4096);
            splitContainer1.Panel2.Controls.Add(scene);
            this.mainForm = mainForm;
            scene.CreateScene();
            scene.initialized = true;
            scene.Refresh();
            penModeButton.Tag = ObjectMode.Tile;
            fillModeButton.Tag = ObjectMode.Tile;
            entranceModeButton.Tag = ObjectMode.Entrances;
            exitModeButton.Tag = ObjectMode.Exits;
            itemModeButton.Tag = ObjectMode.Itemmode;
            spriteModeButton.Tag = ObjectMode.Spritemode;
            transportModeButton.Tag = ObjectMode.Flute;
            overlayButton.Tag = ObjectMode.Overlay;
            stateCombobox.SelectedIndex = 1;
            //setTilesGfx();
            
        }

        public void setTilesGfx()
        {
           //tilePictureBox.Image = overworld.allmaps[0].blocksetBitmap;
        }

        private void ModeButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < owToolStrip.Items.Count; i++) //uncheck every modes
            {
                if (owToolStrip.Items[i] is ToolStripButton)
                {
                    (owToolStrip.Items[i] as ToolStripButton).Checked = false;
                }
            }
            (sender as ToolStripButton).Checked = true;
            scene.selectedMode = (ObjectMode)((sender as ToolStripButton).Tag);
        }

        private void stateCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            overworld.gameState = (byte)stateCombobox.SelectedIndex;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            mainForm.saveToolStripMenuItem_Click(sender, e);
        }

        private void gfxTextbox_TextChanged(object sender, EventArgs e)
        {

            if (propertiesChangedFromForm == false)
            {
                
                byte result = 0;
                OverworldMap mapParent = scene.ow.allmaps[scene.ow.allmaps[scene.selectedMap].parent];
                
                if (scene.ow.allmaps[scene.selectedMap].parent == 255)
                {
                    mapParent = scene.ow.allmaps[scene.selectedMap];
                }

                if (byte.TryParse(gfxTextbox.Text, out result))
                {
                    mapParent.gfx = result;
                }
                if (byte.TryParse(sprgfxTextbox.Text, out result))
                {
                    if (mapParent.index >= 64)
                    {
                        mapParent.sprgfx[0] = result;
                    }
                    else
                    {
                        mapParent.sprgfx[scene.ow.gameState] = result;
                    }
                }
                if (byte.TryParse(sprpaletteTextbox.Text, out result))
                {
                    if (mapParent.index >= 64)
                    {
                        mapParent.sprpalette[0] = result;
                    }
                    else
                    {
                        mapParent.sprpalette[scene.ow.gameState] = result;
                    }

                }
                if (byte.TryParse(paletteTextbox.Text, out result))
                {
                    mapParent.palette = result;
                }
                short msgid = 0;
                if (short.TryParse(textidTextbox.Text, out msgid))
                {
                    mapParent.messageID = msgid;

                    if (msgid < mainForm.textEditor.textListbox.Items.Count)
                    {
                        mainForm.textEditor.textListbox.SelectedIndex = msgid;
                    }

                    mainForm.textEditor.Refresh();
                    previewTextPicturebox.Size = new Size(340, 102);
                    previewTextPicturebox.Visible = true;
                    previewTextPicturebox.Refresh();


                }

                if (mapParent.largeMap)
                {

                    scene.ow.allmaps[mapParent.index + 1].gfx = mapParent.gfx;
                    scene.ow.allmaps[mapParent.index + 1].sprgfx = mapParent.sprgfx;
                    scene.ow.allmaps[mapParent.index + 1].palette = mapParent.palette;
                    scene.ow.allmaps[mapParent.index + 1].sprpalette = mapParent.sprpalette;

                    scene.ow.allmaps[mapParent.index + 8].gfx = mapParent.gfx;
                    scene.ow.allmaps[mapParent.index + 8].sprgfx = mapParent.sprgfx;
                    scene.ow.allmaps[mapParent.index + 8].palette = mapParent.palette;
                    scene.ow.allmaps[mapParent.index + 8].sprpalette = mapParent.sprpalette;

                    scene.ow.allmaps[mapParent.index + 9].gfx = mapParent.gfx;
                    scene.ow.allmaps[mapParent.index + 9].sprgfx = mapParent.sprgfx;
                    scene.ow.allmaps[mapParent.index + 9].palette = mapParent.palette;
                    scene.ow.allmaps[mapParent.index + 9].sprpalette = mapParent.sprpalette;

                    mapParent.BuildMap();
                    scene.ow.allmaps[mapParent.index + 1].BuildMap();
                    scene.ow.allmaps[mapParent.index + 8].BuildMap();
                    scene.ow.allmaps[mapParent.index + 9].BuildMap();
                }
                else
                {
                    mapParent.BuildMap();
                }
                scene.Refresh();
            }
        }

        private void tilePictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (overworld.allmaps[scene.selectedMap].blocksetBitmap != null)
            {
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                e.Graphics.DrawImage(overworld.allmaps[scene.selectedMap].blocksetBitmap,0,0);
                if (scene.selectedTile.Length >0)
                {
                    int x = (scene.selectedTile[0] % 8)*16;
                    int y = ((scene.selectedTile[0] / 8))*16;
                    e.Graphics.DrawRectangle(Pens.LimeGreen, new Rectangle(x, y, 16, 16));
                    selectedTileLabel.Text = "Selected Tile : " + scene.selectedTile[0].ToString();
                }

            }
        }

        private void tilePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            scene.selectedTileSizeX = 1;
            scene.selectedTile = new ushort[1] { (ushort)((e.X / 16) + ((e.Y / 16) * 8)) };
            tilePictureBox.Refresh();
            
        }

        private void spButton_Click(object sender, EventArgs e)
        {
            scene.selectedMap = 128;
            scene.ow.worldOffset = 128;
            scene.Refresh();
        }

        private void dwButton_Click(object sender, EventArgs e)
        {
            scene.selectedMap = 64;
            scene.ow.worldOffset = 64;
            scene.Refresh();
        }

        private void lwButton_Click(object sender, EventArgs e)
        {
            scene.selectedMap = 0;
            scene.ow.worldOffset = 0;
            scene.Refresh();
        }

        private void runtestButton_Click(object sender, EventArgs e)
        {
            mainForm.runtestButton_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            scene.ow.allmaps[128].Buildtileset();
            unsafe
            {
                FileStream fs = new FileStream("cgxTest.cgx", FileMode.OpenOrCreate, FileAccess.Write);

                byte* currentmapgfx8Data = (byte*)GFX.currentOWgfx16Ptr.ToPointer();
                byte[] d = new byte[(128 * 512)];
                for (int i = 0; i< (128 * 512)/2;i++)
                {
                    d[(i*2)] = (byte)((currentmapgfx8Data[i]>>4) & 0x0F);
                    d[(i*2)+1] = (byte)((currentmapgfx8Data[i]) & 0x0F);
                }
                fs.Write(d, 0, d.Length);
                fs.Close();
            }

        }

        private void tilePictureBox_DoubleClick(object sender, EventArgs e)
        {
            Tile16Editor ted = new Tile16Editor(scene);
            if (ted.ShowDialog() == DialogResult.OK)
            {
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    for (int i = 0; i < 159; i++)
                    {
                        if (scene.ow.allmaps[i].needRefresh == true)
                        {
                            scene.ow.allmaps[i].BuildMap();
                            scene.ow.allmaps[i].needRefresh = false;
                        }
                    }
                }).Start();

            }
        }

        private void thumbnailBox_Paint(object sender, PaintEventArgs e)
        {

        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            scene.mainForm.undoButton_Click(sender, e);
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            scene.mainForm.redoButton_Click(sender, e);
        }

        private void tilePictureBox_Click(object sender, EventArgs e)
        {

        }

        private void refreshToolStrip_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                for (int i = 0; i < 159; i++)
                {
                    if (mainForm.overworldEditor.scene.ow.allmaps[i].needRefresh == true)
                    {
                        mainForm.overworldEditor.scene.ow.allmaps[i].BuildMap();
                        mainForm.overworldEditor.scene.ow.allmaps[i].needRefresh = false;
                    }
                }
            }).Start();
        }

        private void musicButton_Click(object sender, EventArgs e)
        {
            OWMusicForm owmf = new OWMusicForm();
            owmf.mapIndex = (byte)scene.selectedMap;
            owmf.musics[0] = scene.ow.allmaps[scene.selectedMap].musics[0];
            owmf.musics[1] = scene.ow.allmaps[scene.selectedMap].musics[1];
            owmf.musics[2] = scene.ow.allmaps[scene.selectedMap].musics[2];
            owmf.musics[3] = scene.ow.allmaps[scene.selectedMap].musics[3];
            if (owmf.ShowDialog() == DialogResult.OK)
            {
                scene.ow.allmaps[scene.selectedMap].musics[0] = owmf.musics[0];
                scene.ow.allmaps[scene.selectedMap].musics[1] = owmf.musics[1];
                scene.ow.allmaps[scene.selectedMap].musics[2] = owmf.musics[2];
                scene.ow.allmaps[scene.selectedMap].musics[3] = owmf.musics[3];
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int v = 0;
            if (int.TryParse(textidTextbox.Text, out v))
            {
                if (v < mainForm.textEditor.textListbox.Items.Count)
                {
                    mainForm.textEditor.textListbox.SelectedIndex = v;
                }
            }
            mainForm.editorsTabControl.SelectTab(3);
            mainForm.textEditor.Refresh();

        }

        private void previewTextPicturebox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            ColorPalette cp = GFX.currentfontgfx16Bitmap.Palette;
            int defaultColor = 6;

            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    cp.Entries[i] = Color.Transparent;
                }
                else
                {
                    cp.Entries[i] = GFX.roomBg1Bitmap.Palette.Entries[(defaultColor * 4) + i];

                }
            }
            GFX.currentfontgfx16Bitmap.Palette = cp;

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(GFX.currentfontgfx16Bitmap, new Rectangle(0, 0, 340, 102), new Rectangle(0, 0, 170, 51), GraphicsUnit.Pixel);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 255, 0, 0)), new Rectangle(344 - 8, 0, 4, 102));
        }

        private void textidTextbox_Click(object sender, EventArgs e)
        {
            int v = 0;
            if (int.TryParse(textidTextbox.Text, out v))
            {
                if (v < mainForm.textEditor.textListbox.Items.Count)
                {
                    mainForm.textEditor.textListbox.SelectedIndex = v;
                }
            }

            mainForm.textEditor.Refresh();
            previewTextPicturebox.Size = new Size(340, 102);
            previewTextPicturebox.Visible = true;
            previewTextPicturebox.Refresh();
        }

        private void textidTextbox_Leave(object sender, EventArgs e)
        {
            previewTextPicturebox.Visible = false;
        }
    }
}
