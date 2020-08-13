﻿using System;
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
                Console.WriteLine(mapParent.largeMap);
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
            scene.ow.worldOffset = 128;
            scene.Refresh();
        }

        private void dwButton_Click(object sender, EventArgs e)
        {
            scene.ow.worldOffset = 64;
            scene.Refresh();
        }

        private void lwButton_Click(object sender, EventArgs e)
        {
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
            e.Graphics.InterpolationMode = InterpolationMode.Bilinear;
            e.Graphics.Clear(Color.Black);
            if (mainForm.previewRoom.bg2 != Background2.Translucent || mainForm.previewRoom.bg2 != Background2.Transparent ||
                mainForm.previewRoom.bg2 != Background2.OnTop || mainForm.previewRoom.bg2 != Background2.Off)
            {
                e.Graphics.DrawImage(GFX.roomBg2Bitmap, new Rectangle(0, 0, 256, 256), 0, 0, 512, 512, GraphicsUnit.Pixel);
            }


            //e.Graphics.DrawImage(GFX.roomBgLayoutBitmap,0,0);
            e.Graphics.DrawImage(GFX.roomBg1Bitmap, new Rectangle(0, 0, 256, 256), 0, 0, 512, 512, GraphicsUnit.Pixel);

            if (mainForm.previewRoom.bg2 == Background2.Translucent || mainForm.previewRoom.bg2 == Background2.Transparent)
            {
                float[][] matrixItems ={
               new float[] {1f, 0, 0, 0, 0},
               new float[] {0, 1f, 0, 0, 0},
               new float[] {0, 0, 1f, 0, 0},
               new float[] {0, 0, 0, 0.5f, 0},
               new float[] {0, 0, 0, 0, 1}};
                ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

                // Create an ImageAttributes object and set its color matrix.
                ImageAttributes imageAtt = new ImageAttributes();
                imageAtt.SetColorMatrix(
                   colorMatrix,
                   ColorMatrixFlag.Default,
                   ColorAdjustType.Bitmap);
                //GFX.roomBg2Bitmap.MakeTransparent(Color.Black);
                e.Graphics.DrawImage(GFX.roomBg2Bitmap, new Rectangle(0, 0, 256, 256), 0, 0, 512, 512, GraphicsUnit.Pixel, imageAtt);
            }
            else if (mainForm.previewRoom.bg2 == Background2.OnTop)
            {
                e.Graphics.DrawImage(GFX.roomBg2Bitmap, new Rectangle(0, 0, 256, 256), 0, 0, 512, 512, GraphicsUnit.Pixel);
            }

            mainForm.activeScene.drawText(e.Graphics, 0, 0, "ROOM : " + mainForm.previewRoom.index.ToString());
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            scene.mainForm.undoButton_Click(sender, e);
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            scene.mainForm.redoButton_Click(sender, e);
        }
    }
}
