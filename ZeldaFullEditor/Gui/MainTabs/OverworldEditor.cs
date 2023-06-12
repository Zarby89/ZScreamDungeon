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
using System.Globalization;
using ZeldaFullEditor.Data;
using Lidgren.Network;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor.Gui
{
    public partial class OverworldEditor : UserControl
    {
        public Overworld overworld;
        public SceneOW scene;
        public bool propertiesChangedFromForm = false;
        public DungeonMain mainForm;
        public Bitmap tmpPreviewBitmap = new Bitmap(256, 256);
        public Bitmap scratchPadBitmap = new Bitmap(256, 3600);
        public ushort[,] scratchPadTiles = new ushort[16, 225];
        public byte gridDisplay = 0;

        private bool mouse_down = false;

        private bool selecting = false;
        private int globalmouseTileDownX = 0;
        private int globalmouseTileDownY = 0;
        private int mouseX_Real = 0;
        private int mouseY_Real = 0;
        private int lastTileHoverX = 0;
        private int lastTileHoverY = 0;

        private byte palSelected = 0;
        private int tile8selected = 0;

        private readonly ColorDialog cd = new ColorDialog();

        public static bool UseAreaSpecificBgColor = false;
        public static bool scratchPadGrid = false;

        public OverworldEditor()
        {
            InitializeComponent();
        }

        public void InitOpen(DungeonMain mainForm)
        {
            overworld = new Overworld();
            scene = new SceneOW(this, overworld, mainForm);
            scene.Location = Constants.Point_0_0;
            scene.Size = Constants.Size4096x4096;
            splitContainer1.Panel2.Controls.Clear();
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
            gravestoneButton.Tag = ObjectMode.Gravestone;
            stateCombobox.SelectedIndex = 1;
            scratchPicturebox.Image = scratchPadBitmap;

            //setTilesGfx();
            bool fromFile = false;
            byte[] file = new byte[(225 * 16) * 2];

            if (File.Exists("ScratchPad.dat"))
            {
                using (FileStream fs = new FileStream("ScratchPad.dat", FileMode.Open, FileAccess.Read))
                {
                    fs.Read(file, 0, (int)fs.Length);
                    fs.Close();
                    fromFile = true;
                }
            }

            int t = 0;
            for (ushort x = 0; x < 225; x++)
            {
                for (ushort y = 0; y < 16; y++, t += 2)
                {
                    scratchPadTiles[y, x] = fromFile ? (ushort)((file[t] << 8) + file[t + 1]) : (ushort)0;
                }
            }

            GFX.editort16Bitmap.Palette = scene.ow.allmaps[scene.selectedMap].gfxBitmap.Palette;
            updateTiles();
            pictureBox1.Refresh();
        }


        public void saveScratchPad()
        {
            byte[] file = new byte[(225 * 16) * 2];

            int t = 0;
            for (ushort x = 0; x < 225; x++)
            {
                for (ushort y = 0; y < 16; y++)
                {
                    file[t++] = (byte)((scratchPadTiles[y, x] >> 8) & 0xFF);
                    file[t++] = (byte)((scratchPadTiles[y, x]) & 0xFF);
                }
            }

            using (FileStream fs = new FileStream("ScratchPad.dat", FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Write(file, 0, (int)fs.Length);
                fs.Close();
            }
        }

        public void UpdateGUIProperties(OverworldMap m, int gamestate = 0)
        {
            propertiesChangedFromForm = true;
            OWProperty_BGGFX.HexValue = m.gfx;
            OWProperty_BGPalette.HexValue = m.palette;
            OWProperty_SPRGFX.HexValue = m.sprgfx[gamestate];
            OWProperty_SPRPalette.HexValue = m.sprpalette[gamestate];

            largemapCheckbox.Checked = m.largeMap;
            mosaicCheckBox.Checked = m.mosaic;
            propertiesChangedFromForm = false;
        }

        private void ModeButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < owToolStrip.Items.Count; i++) // Uncheck all the other modes.
            {
                if (owToolStrip.Items[i] is ToolStripButton tt)
                {
                    tt.Checked = false;
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
            if (!propertiesChangedFromForm)
            {
                OverworldMap mapParent = scene.ow.allmaps[scene.ow.allmaps[scene.selectedMap].parent];
                UpdateMapProperties(mapParent);
                SendMapProperties(mapParent);
            }
        }

        public void UpdateMapProperties(OverworldMap mapParent)
        {
            if (scene.ow.allmaps[scene.selectedMap].parent == 255)
            {
                mapParent = scene.ow.allmaps[scene.selectedMap];
            }

            mapParent.palette = (byte)OWProperty_BGPalette.HexValue;
            mapParent.gfx = (byte)OWProperty_BGGFX.HexValue;
            mapParent.messageID = (short)OWProperty_MessageID.HexValue;

            if (mapParent.index >= 64)
            {
                mapParent.sprgfx[0] = (byte)OWProperty_SPRGFX.HexValue;
                mapParent.sprpalette[0] = (byte)OWProperty_SPRPalette.HexValue;
            }
            else
            {
                scene.ow.allmaps[mapParent.index].sprgfx[scene.ow.gameState] = (byte)OWProperty_SPRGFX.HexValue;
                mapParent.sprpalette[scene.ow.gameState] = (byte)OWProperty_SPRPalette.HexValue;
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

            //scene.updateMapGfx();
            scene.Invalidate();
            //scene.Refresh();

        }

        private void tilePictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (GFX.mapblockset16Bitmap != null)
            {
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                e.Graphics.CompositingMode = CompositingMode.SourceOver;
                e.Graphics.DrawImage(GFX.mapblockset16Bitmap,
                    Constants.Rect_0_0_128_4096,
                    Constants.Rect_0_0_128_4096,
                    GraphicsUnit.Pixel);
                e.Graphics.DrawImage(GFX.mapblockset16Bitmap,
                    Constants.Rect_128_0_128_4096,
                    Constants.Rect_0_4096_128_4096,
                    GraphicsUnit.Pixel);

                if (scene.selectedTile.Length > 0)
                {
                    int x = (scene.selectedTile[0] % 8) * 16;
                    int y = ((scene.selectedTile[0] / 8)) * 16;

                    if (scene.selectedTile[0] >= 2048)
                    {
                        y -= 4096;
                        x += 128;
                    }

                    // TODO copy
                    e.Graphics.DrawRectangle(Pens.LimeGreen, new Rectangle(x, y, 16, 16));
                    selectedTileLabel.Text = "Selected Tile : " + scene.selectedTile[0].ToString("X4");
                }

                e.Graphics.FillRectangle(Brushes.Black, new RectangleF(128, 3408, 128, 688));
            }
        }

        public void AdjustTile16BoxScrollBar()
        {
            int y = ((scene.selectedTile[0] / 8)) * 16;

            if (scene.selectedTile[0] >= 2048)
            {
                y -= 4096;
            }

            if (y + tabPage1.Size.Height > tilePictureBox.Size.Height)
            {
                y = tilePictureBox.Size.Height - tabPage1.Size.Height;
            }

            // TODO: fix this garbage, it doesn't update all of the time for some reason but works better without the if. -Jared_Brian_
            //if (y < tabPage1.VerticalScroll.Value || y > tabPage1.VerticalScroll.Value + tabPage1.Size.Height)
            //{
            tabPage1.VerticalScroll.Value = y;
            tilePictureBox.Refresh();
            tabPage1.Update();
            tabPage1.Refresh();
            //
        }

        private void tilePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            scene.selectedTileSizeX = 1;
            if (e.X > 128)
            {
                scene.selectedTile = new ushort[1] { (ushort)(((e.X - 128) / 16) + ((e.Y / 16) * 8) + 2048) };
                if (scene.selectedTile[0] > 3751)
                {
                    scene.selectedTile[0] = 3751;
                }
            }
            else
            {
                scene.selectedTile = new ushort[1] { (ushort)((e.X / 16) + ((e.Y / 16) * 8)) };
            }

            tilePictureBox.Refresh();
        }

        /// <summary>
        /// Called when the LW button on the overworld editor form is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lwButton_Click(object sender, EventArgs e)
        {
            SelectMapOffset(0);
        }

        /// <summary>
        /// Called when the DW button on the overworld editor form is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dwButton_Click(object sender, EventArgs e)
        {
            SelectMapOffset(64);
        }

        /// <summary>
        /// Called when the SP button on the overworld editor form is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spButton_Click(object sender, EventArgs e)
        {
            SelectMapOffset(128);
        }

        private void SelectMapOffset(int o)
        {
            scene.selectedMap = o;
            scene.selectedMapParent = scene.ow.allmaps[o].parent;
            scene.ow.worldOffset = o;
            scene.Refresh();
        }

        private void runtestButton_Click(object sender, EventArgs e)
        {
            mainForm.runtestButton_Click(sender, e);
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
                        if (scene.ow.allmaps[i].needRefresh)
                        {
                            scene.ow.allmaps[i].BuildMap();
                            scene.ow.allmaps[i].needRefresh = false;
                        }
                    }
                }).Start();
            }
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            scene.mainForm.undoButton_Click(sender, e);
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            scene.mainForm.redoButton_Click(sender, e);
        }

        private void refreshToolStrip_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                for (int i = 0; i < 159; i++)
                {
                    if (mainForm.overworldEditor.scene.ow.allmaps[i].needRefresh)
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
            mainForm.textEditor.SelectMessageID(OWProperty_MessageID.HexValue);

            mainForm.editorsTabControl.SelectTab(3);
            mainForm.textEditor.Refresh();
        }

        private void previewTextPicturebox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
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

            // TODO make new brushes
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(GFX.currentfontgfx16Bitmap, Constants.Rect_0_0_340_102, Constants.Rect_0_0_170_51, GraphicsUnit.Pixel);
            e.Graphics.FillRectangle(Constants.HalfRedBrush, Constants.Rect_336_0_4_102);
        }

        private void textidTextbox_Click(object sender, EventArgs e)
        {
            mainForm.textEditor.SelectMessageID(OWProperty_MessageID.HexValue);
            mainForm.textEditor.Refresh();
            previewTextPicturebox.Size = Constants.Size340x102;
            previewTextPicturebox.Visible = true;
            previewTextPicturebox.Refresh();
        }

        private void textidTextbox_Leave(object sender, EventArgs e)
        {
            previewTextPicturebox.Visible = false;
        }

        private void scratchPicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            globalmouseTileDownX = e.X / 16;
            globalmouseTileDownY = e.Y / 16;

            if (scene.needRedraw)
            {
                scene.needRedraw = false;
                return;
            }

            mouse_down = true;

            if (e.Button == MouseButtons.Left)
            {
                if (scene.selectedTile.Length >= 1)
                {
                    int y = 0;
                    int x = 0;
                    //ushort[] undotiles = new ushort[scene.selectedTile.Length];

                    for (int i = 0; i < scene.selectedTile.Length; i++)
                    {
                        if (globalmouseTileDownX + x <= 15)
                        {
                            scratchPadTiles[globalmouseTileDownX + x, globalmouseTileDownY + y] = scene.selectedTile[i];
                        }

                        x++;

                        if (x >= scene.selectedTileSizeX)
                        {
                            y++;
                            x = 0;
                        }
                    }
                }
                else
                {
                    scratchPadTiles[globalmouseTileDownX, globalmouseTileDownY] = scene.selectedTile[0];
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                selecting = true;
            }

            BuildScratchTilesGfx();
            scratchPicturebox.Refresh();
        }

        private void scratchPicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouse_down)
            {
                int tileX = (e.X / 16);
                int tileY = (e.Y / 16);

                if (e.Button == MouseButtons.Right)
                {
                    if (tileX == globalmouseTileDownX && tileY == globalmouseTileDownY)
                    {
                        scene.selectedTile = new ushort[1] { scratchPadTiles[globalmouseTileDownX, globalmouseTileDownY] };
                        scene.selectedTileSizeX = 1;
                    }
                    else
                    {
                        bool reverseX = false;
                        bool reverseY = false;
                        int sizeX = (tileX - globalmouseTileDownX) + 1;
                        int sizeY = (tileY - globalmouseTileDownY) + 1;

                        if (tileX < globalmouseTileDownX)
                        {
                            sizeX = (globalmouseTileDownX - tileX) + 1;
                            reverseX = true;
                        }
                        if (tileY < globalmouseTileDownY)
                        {
                            sizeY = (globalmouseTileDownY - tileY) + 1;
                            reverseY = true;
                        }

                        int pX = reverseX ? tileX : globalmouseTileDownX;
                        int pY = reverseY ? tileY : globalmouseTileDownY;

                        if (pX < 0)
                        {
                            pX = 0;
                        }
                        if (pY < 0)
                        {
                            pY = 0;
                        }

                        int rows = scratchPadTiles.GetLength(0);
                        int columns = scratchPadTiles.GetLength(1);
                        if (sizeX + pX >= rows)
                        {
                            sizeX = rows - pX;
                        }
                        if (sizeY + pY >= columns)
                        {
                            sizeY = columns - pY;
                        }

                        scene.selectedTileSizeX = sizeX;
                        scene.selectedTile = new ushort[sizeX * sizeY];

                        for (int y = 0; y < sizeY; y++)
                        {
                            for (int x = 0; x < sizeX; x++)
                            {
                                scene.selectedTile[x + (y * sizeX)] = scratchPadTiles[pX + x, pY + y];
                            }
                        }
                    }
                }
            }

            selecting = false;
            mouse_down = false;
            scratchPicturebox.Refresh();
        }

        private void scratchPicturebox_MouseMove(object sender, MouseEventArgs e)
        {
            if (scene.initialized)
            {
                mouseX_Real = e.X;
                mouseY_Real = e.Y;
                int mouseTileX = e.X / 16;
                int mouseTileY = e.Y / 16;

                if (lastTileHoverX != mouseTileX || lastTileHoverY != mouseTileY)
                {
                    if (mouse_down)
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            int tileX = (e.X / 16);
                            int tileY = (e.Y / 16);
                            if (tileX <= 0) { tileX = 0; }
                            if (tileY <= 0) { tileY = 0; }
                            if (tileX > 16) { tileX = 16; }
                            if (tileY > 225) { tileY = 225; }
                            globalmouseTileDownX = tileX;
                            globalmouseTileDownY = tileY;

                            if (scene.selectedTile.Length >= 1)
                            {
                                int y = 0;
                                int x = 0;
                                for (int i = 0; i < scene.selectedTile.Length; i++)
                                {
                                    if (globalmouseTileDownX + x < 16 && globalmouseTileDownY + y < 225)
                                    {
                                        scratchPadTiles[globalmouseTileDownX + x, globalmouseTileDownY + y] = scene.selectedTile[i];
                                    }

                                    x++;

                                    if (x >= scene.selectedTileSizeX)
                                    {
                                        y++;
                                        x = 0;
                                    }
                                }
                            }
                        }

                        BuildScratchTilesGfx();
                    }

                    scratchPicturebox.Refresh();
                    lastTileHoverX = mouseTileX;
                    lastTileHoverY = mouseTileY;
                }
            }
        }

        private void scratchPicturebox_Paint(object sender, PaintEventArgs e)
        {
            if (GFX.mapblockset16Bitmap != null)
            {
                // USE mapblockset16 to draw tiles on this !! :GRIMACING:
                //public static IntPtr mapblockset16 = Marshal.AllocHGlobal(1048576);
                //public static Bitmap mapblockset16Bitmap;
                //base.OnPaint(e);
                Graphics g = e.Graphics;
                ColorMatrix cm = new ColorMatrix();
                ImageAttributes ia = new ImageAttributes();
                cm.Matrix33 = 0.50f;
                cm.Matrix22 = 2f;
                ia.SetColorMatrix(cm);
                g.CompositingMode = CompositingMode.SourceCopy;
                g.CompositingQuality = CompositingQuality.HighSpeed;
                g.InterpolationMode = InterpolationMode.NearestNeighbor;

                g.DrawImage(GFX.scratchblockset16Bitmap, 0, 0);

                // DRAW ALL THE TILES 16x225

                g.CompositingMode = CompositingMode.SourceOver;

                if (scratchPadGrid)
                {
                    int gridsizeX = 256;
                    int gridsizeY = 3600;

                    for (int gx = 0; gx < (gridsizeX / 32); gx++)
                    {
                        g.DrawLine(Constants.ThirdWhitePen1,
                            new Point(gx * 32, 0),
                            new Point(gx * 32, gridsizeY));
                    }

                    for (int gy = 0; gy < ((gridsizeY / 32) + 1); gy++)
                    {
                        g.DrawLine(Constants.ThirdWhitePen1,
                            new Point(0, (gy * 32)),
                            new Point(gridsizeX, (gy * 32)));
                    }
                }

                if (selecting)
                {
                    g.DrawRectangle(Pens.White, new Rectangle((globalmouseTileDownX * 16), (globalmouseTileDownY * 16), (((mouseX_Real / 16) - globalmouseTileDownX) * 16) + 16, (((mouseY_Real / 16) - globalmouseTileDownY) * 16) + 16));
                }

                g.DrawImage(scene.tilesgfxBitmap, new Rectangle((mouseX_Real / 16) * 16, (mouseY_Real / 16) * 16, scene.selectedTileSizeX * 16, (scene.selectedTile.Length / scene.selectedTileSizeX) * 16), 0, 0, scene.selectedTileSizeX * 16, (scene.selectedTile.Length / scene.selectedTileSizeX) * 16, GraphicsUnit.Pixel, ia);
                g.DrawRectangle(Pens.LightGreen, new Rectangle((mouseX_Real / 16) * 16, (mouseY_Real / 16) * 16, scene.selectedTileSizeX * 16, (scene.selectedTile.Length / scene.selectedTileSizeX) * 16));

                g.DrawImage(scene.tilesgfxBitmap, new Rectangle((mouseX_Real / 16) * 16, (mouseY_Real / 16) * 16, scene.selectedTileSizeX * 16, (scene.selectedTile.Length / scene.selectedTileSizeX) * 16), 0, 0, scene.selectedTileSizeX * 16, (scene.selectedTile.Length / scene.selectedTileSizeX) * 16, GraphicsUnit.Pixel, ia);
                g.DrawRectangle(Pens.LightGreen, new Rectangle((mouseX_Real / 16) * 16, (mouseY_Real / 16) * 16, scene.selectedTileSizeX * 16, (scene.selectedTile.Length / scene.selectedTileSizeX) * 16));

                g.CompositingMode = CompositingMode.SourceCopy;
                //hideText = false;
            }
        }

        public unsafe void BuildScratchTilesGfx()
        {
            GFX.scratchblockset16Bitmap.Palette = GFX.mapblockset16Bitmap.Palette;
            var gfx16Data = (byte*)GFX.mapblockset16.ToPointer(); //(byte*)allgfx8Ptr.ToPointer();
            var gfx16DataScratch = (byte*)GFX.scratchblockset16.ToPointer(); //(byte*)allgfx16Ptr.ToPointer();
            int ytile = 0;
            int xtile = 0;

            for (var i = 0; i < 3600; i++) // Number of tiles16 3748?
            {
                ushort srcTile = scratchPadTiles[xtile, ytile];
                //Console.WriteLine(srcTile);
                int srcTileY = (srcTile / 8);
                int srcTileX = srcTile - (srcTileY * 8);
                int tPos = (xtile * 16) + (ytile * 4096);
                int srctPos = (srcTileX * 16) + (srcTileY * 2048);

                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        gfx16DataScratch[tPos + (x + (y * 256))] = gfx16Data[srctPos + (x + (y * 128))];
                    }
                }

                xtile++;
                if (xtile >= 16)
                {
                    xtile = 0;
                    ytile++;
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.None;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            //e.Graphics.DrawImage(GFX.currentOWgfx16Bitmap,new Rectangle(0,0,512,1024), new Rectangle(0,0,256,512),GraphicsUnit.Pixel);

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            e.Graphics.DrawImage(GFX.editort16Bitmap, Constants.Rect_0_0_256_1024);

            int y = (tile8selected / 16);
            int x = tile8selected - (y * 16);

            e.Graphics.DrawRectangle(Pens.GreenYellow, new Rectangle(x * 16, y * 16, 16, 16));
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO copy
            if (tabControl1.SelectedTab.Name == "Tiles8")
            {
                // TODO: Add something here?

                /*
                int sx = 0;
                int sy = 0;
                int c = 0;

                int nx = 0;
                int ny = 0;
                for (int i = 0; i < 64; i++)
                {
                    for (int y = 0; y < 64; y += 2)
                    {
                        for (int x = 0; x < 64; x += 2)
                        {
                            //Console.WriteLine(overworld.tiles16[overworld.allmapsTilesLW[nx + (sx * 32), ny + (sy * 32)]].tile0.id);

                            overworld.tempTiles8_LW[x + (sx * 64), y + (sy * 64)] = overworld.tiles16[overworld.allmapsTilesLW[nx + (sx * 32), ny + (sy * 32)]].tile0;
                            overworld.tempTiles8_LW[x + (sx * 64) + 1, y + (sy * 64)] = overworld.tiles16[overworld.allmapsTilesLW[nx + (sx * 32), ny + (sy * 32)]].tile1;
                            overworld.tempTiles8_LW[x + (sx * 64), y + (sy * 64) + 1] = overworld.tiles16[overworld.allmapsTilesLW[nx + (sx * 32), ny + (sy * 32)]].tile2;
                            overworld.tempTiles8_LW[x + (sx * 64) + 1, y + (sy * 64) + 1] = overworld.tiles16[overworld.allmapsTilesLW[nx + (sx * 32), ny + (sy * 32)]].tile3;

                            overworld.tempTiles8_DW[x + (sx * 64), y + (sy * 64)] = overworld.tiles16[overworld.allmapsTilesDW[nx + (sx * 32), ny + (sy * 32)]].tile0;
                            overworld.tempTiles8_DW[x + (sx * 64) + 1, y + (sy * 64)] = overworld.tiles16[overworld.allmapsTilesDW[nx + (sx * 32), ny + (sy * 32)]].tile1;
                            overworld.tempTiles8_DW[x + (sx * 64), y + (sy * 64) + 1] = overworld.tiles16[overworld.allmapsTilesDW[nx + (sx * 32), ny + (sy * 32)]].tile2;
                            overworld.tempTiles8_DW[x + (sx * 64) + 1, y + (sy * 64) + 1] = overworld.tiles16[overworld.allmapsTilesDW[nx + (sx * 32), ny + (sy * 32)]].tile3;

                            if (i < 32)
                            {
                                overworld.tempTiles8_SP[x + (sx * 64), y + (sy * 64)] = overworld.tiles16[overworld.allmapsTilesSP[nx + (sx * 32), ny + (sy * 32)]].tile0;
                                overworld.tempTiles8_SP[x + (sx * 64) + 1, y + (sy * 64)] = overworld.tiles16[overworld.allmapsTilesSP[nx + (sx * 32), ny + (sy * 32)]].tile1;
                                overworld.tempTiles8_SP[x + (sx * 64), y + (sy * 64) + 1] = overworld.tiles16[overworld.allmapsTilesSP[nx + (sx * 32), ny + (sy * 32)]].tile2;
                                overworld.tempTiles8_SP[x + (sx * 64) + 1, y + (sy * 64) + 1] = overworld.tiles16[overworld.allmapsTilesSP[nx + (sx * 32), ny + (sy * 32)]].tile3;
                            }

                            nx++;
                        }

                        nx = 0;
                        ny++;
                    }

                    sx++;
                    if (sx >= 8)
                    {
                        sy++;
                        sx = 0;
                    }

                    c++;
                    if (c >= 64)
                    {
                        sx = 0;
                        sy = 0;
                        c = 0;
                    }

                    nx = 0;
                    ny = 0;
                }
                */
            }
            else
            {
                //overworld.createMap16Tilesmap();
                //Convert them back in tiles16
            }
        }

        public unsafe void updateSelectedTile16()
        {
            byte p = palSelected;
            tile8selected = 0;
            byte* destPtr = (byte*)GFX.editingtile16.ToPointer();
            byte* srcPtr = (byte*)GFX.currentOWgfx16Ptr.ToPointer();
            Tile16 t = overworld.tiles16[scene.selectedTile[0]];

            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 4; x++)
                {
                    CopyTile(x, y, 0, 0, t.tile0.id, p, destPtr, srcPtr, 16);
                }
            }

            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 4; x++)
                {
                    CopyTile(x, y, 8, 0, t.tile1.id, p, destPtr, srcPtr, 16);
                }
            }

            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 4; x++)
                {
                    CopyTile(x, y, 0, 8, t.tile2.id, p, destPtr, srcPtr, 16);
                }
            }

            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 4; x++)
                {
                    CopyTile(x, y, 8, 8, t.tile3.id, p, destPtr, srcPtr, 16);
                }
            }

            //Bitmap b = new Bitmap(128, 512, 64, System.Drawing.Imaging.PixelFormat.Format4bppIndexed, GFX.currentOWgfx16Ptr);
            GFX.editort16Bitmap.Palette = scene.ow.allmaps[scene.selectedMap].gfxBitmap.Palette;
        }

        public unsafe void updateTiles()
        {
            byte p = palSelected;

            tile8selected = 0;
            byte* destPtr = (byte*)GFX.editort16Ptr.ToPointer();
            byte* srcPtr = (byte*)GFX.currentOWgfx16Ptr.ToPointer();
            int xx = 0;
            int yy = 0;
            for (int i = 0; i < 1024; i++)
            {
                for (var y = 0; y < 8; y++)
                {
                    for (var x = 0; x < 4; x++)
                    {
                        CopyTile(x, y, xx, yy, i, p, destPtr, srcPtr);
                    }
                }

                xx += 8;
                if (xx >= 128)
                {
                    yy += 1024;
                    xx = 0;
                }
            }

            //Bitmap b = new Bitmap(128, 512, 64, System.Drawing.Imaging.PixelFormat.Format4bppIndexed, GFX.currentOWgfx16Ptr);
            GFX.editort16Bitmap.Palette = scene.ow.allmaps[scene.selectedMap].gfxBitmap.Palette;
            pictureBox1.Refresh();
            palette8Box.Refresh();
        }

        private unsafe void CopyTile(int x, int y, int xx, int yy, TileInfo tile, int offset, byte* gfx16Pointer, byte* gfx8Pointer)
        {
            int mx = x;
            int my = y;
            byte r = 0;

            if (tile.H)
            {
                mx = 3 - x;
                r = 1;
            }
            if (tile.V)
            {
                my = 7 - y;
            }

            int tx = ((tile.id / 16) * 512) + ((tile.id - ((tile.id / 16) * 16)) * 4);
            int index = xx + yy + offset + (mx * 2) + (my * 16);
            int pixel = gfx8Pointer[tx + (y * 64) + x];

            gfx16Pointer[index + r ^ 1] = (byte)((pixel & 0x0F) + tile.palette * 16);
            gfx16Pointer[index + r] = (byte)(((pixel >> 4) & 0x0F) + tile.palette * 16);
        }

        private unsafe void CopyTile(int x, int y, int xx, int yy, int id, byte p, byte* gfx16Pointer, byte* gfx8Pointer, int destwidth = 128)
        {
            int mx = x;
            int my = y;
            byte r = 0;

            if (mirrorXCheckbox.Checked)
            {
                mx = 3 - x;
                r = 1;
            }
            if (mirrorYCheckbox.Checked)
            {
                my = 7 - y;
            }

            int tx = ((id / 16) * 512) + ((id - ((id / 16) * 16)) * 4);
            int index = xx + yy + (mx * 2) + (my * destwidth);
            int pixel = gfx8Pointer[tx + (y * 64) + x];

            gfx16Pointer[index + r ^ 1] = (byte)((pixel & 0x0F) + p * 16);
            gfx16Pointer[index + r] = (byte)(((pixel >> 4) & 0x0F) + p * 16);
        }

        private void mirrorXCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            updateTiles();
        }

        private void palette8Box_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 128; i++)
            {
                Color c = scene.ow.allmaps[scene.selectedMap].gfxBitmap.Palette.Entries[i];
                e.Graphics.FillRectangle(new SolidBrush(c), new Rectangle((i % 16) * 16, (i / 16) * 16, 16, 16));
            }

            e.Graphics.DrawRectangle(Pens.GreenYellow, new Rectangle(0, palSelected * 16, 256, 16));
        }

        private void palette8Box_MouseDown(object sender, MouseEventArgs e)
        {
            palSelected = (byte)(e.Y / 16);
            updateTiles();
        }

        private void searchtilesButton_Click(object sender, EventArgs e)
        {
            Dictionary<ushort, ushort> alltilesIndexed = new Dictionary<ushort, ushort>();
            int sx = 0;
            int sy = 0;

            for (ushort i = 0; i < 3752; i++)
            {
                alltilesIndexed.Add(i, 0);
            }

            for (int i = 0; i < 64; i++)
            {
                for (int y = 0; y < 32; y += 1)
                {
                    for (int x = 0; x < 32; x += 1)
                    {
                        ushort LWTile = overworld.allmapsTilesLW[x + (sx * 32), y + (sy * 32)];
                        alltilesIndexed[LWTile]++;
                        ushort DWTile = overworld.allmapsTilesDW[x + (sx * 32), y + (sy * 32)];
                        alltilesIndexed[DWTile]++;

                        if (i < 32)
                        {
                            alltilesIndexed[overworld.allmapsTilesSP[x + (sx * 32), y + (sy * 32)]]++;
                        }
                    }
                }

                foreach (TilePos t in overworld.alloverlays[i].tilesData)
                {
                    alltilesIndexed[t.tileId]++;
                }

                foreach (TilePos t in overworld.alloverlays[i + 64].tilesData)
                {
                    alltilesIndexed[t.tileId]++;
                }

                sx++;
                if (sx >= 8)
                {
                    sy++;
                    sx = 0;
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<ushort, ushort> tiles in alltilesIndexed.OrderBy(key => key.Value))
            {
                // TODO copy
                sb.AppendLine("Tile - " + tiles.Key.ToString("X4") + " : " + tiles.Value.ToString("X4"));
            }

            SearchTilesForm stf = new SearchTilesForm();
            stf.textBox1.Text = sb.ToString();
            stf.ShowDialog();
        }

        private void textidTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!propertiesChangedFromForm)
            {
                OverworldMap mapParent = scene.ow.allmaps[scene.ow.allmaps[scene.selectedMap].parent];

                if (scene.ow.allmaps[scene.selectedMap].parent == 255)
                {
                    mapParent = scene.ow.allmaps[scene.selectedMap];
                }

                mapParent.messageID = (short)OWProperty_MessageID.HexValue;

                mainForm.textEditor.SelectMessageID(OWProperty_MessageID.HexValue);
                mainForm.textEditor.Refresh();
                previewTextPicturebox.Size = new Size(340, 102);
                previewTextPicturebox.Visible = true;
                previewTextPicturebox.Refresh();
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    overworld.allmaps[scene.selectedMap].tilesUsed[x, y] = 0052;

                    //overworld.allmapsTilesLW[x, y] = 0052;
                }
            }

            scene.Refresh();
        }

        private void tilePictureBox_MouseEnter(object sender, EventArgs e)
        {
            scene.ow.allmaps[scene.selectedMap].BuildMap();
            tilePictureBox.Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            tile8selected = (e.X / 16) + ((e.Y / 16) * 16);
            pictureBox1.Refresh();
        }

        private void currentTile8Box_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            updateSelectedTile16();
            e.Graphics.DrawImage(GFX.editingtile16Bitmap, Constants.Rect_0_0_64_64);
        }

        /// <summary>
        /// Called when the largemap checkbox is clicke, upataes the world layout and then updates all of the sprites within that area.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // TODO copy and string builder
        private void largemapCheckbox_Clicked(object sender, EventArgs e)
        {
            if (!propertiesChangedFromForm)
            {
                int m = scene.ow.allmaps[scene.selectedMap].parent;
                SendLargeMapChanged(m, largemapCheckbox.Checked);
                UpdateLargeMap(m, largemapCheckbox.Checked);
            }
        }

        public void UpdateLargeMap(int m, bool largemapChecked)
        {
            if (largemapChecked) // Large map
            {
                // If we are trying to overlap large areas, fail.
                if (scene.ow.allmaps[m + 1].largeMap || scene.ow.allmaps[m + 8].largeMap || scene.ow.allmaps[m + 9].largeMap)
                {
                    int i = 0;
                    string temp = "";

                    if (scene.ow.allmaps[m + 1].largeMap)
                    {
                        temp += (m + 1).ToString("X2") + ", ";
                        i++;
                    }
                    if (scene.ow.allmaps[m + 8].largeMap)
                    {
                        temp += (m + 8).ToString("X2") + ", ";
                        i++;
                    }
                    if (scene.ow.allmaps[m + 9].largeMap)
                    {
                        temp += (m + 9).ToString("X2") + ", ";
                        i++;
                    }

                    temp = temp.Remove(temp.Length - 2);
                    if (i == 1)
                    {
                        MessageBox.Show("Cannot make overlapping large area. Area: " + temp + " is already part of a large area.", "Bad Error", MessageBoxButtons.OK);
                    }
                    else if (i == 2)
                    {
                        temp = temp.Remove(2, 1);
                        temp = temp.Insert(temp.Length - 2, "and ");
                        MessageBox.Show("Cannot make overlapping large area. Areas: " + temp + " are already part of a large area.", "Bad Error", MessageBoxButtons.OK);
                    }
                    else
                    {
                        temp = temp.Insert(temp.Length - 2, "and ");
                        MessageBox.Show("Cannot make overlapping large area. Areas: " + temp + " are already part of a large area.", "Bad Error", MessageBoxButtons.OK);
                    }

                    largemapCheckbox.Checked = false;
                }
                else
                {
                    scene.ow.allmaps[m].SetAsLargeMap((byte)m, 0);
                    scene.ow.allmaps[m + 1].SetAsLargeMap((byte)m, 1);
                    scene.ow.allmaps[m + 8].SetAsLargeMap((byte)m, 2);
                    scene.ow.allmaps[m + 9].SetAsLargeMap((byte)m, 3);

                    // If we are in the light world, set the dark world opposite too.
                    if (m < 64)
                    {
                        scene.ow.allmaps[m + 64].SetAsLargeMap((byte)(m + 64), 0);
                        scene.ow.allmaps[m + 64 + 1].SetAsLargeMap((byte)(m + 64), 1 + 64);
                        scene.ow.allmaps[m + 64 + 8].SetAsLargeMap((byte)(m + 64), 2 + 64);
                        scene.ow.allmaps[m + 64 + 9].SetAsLargeMap((byte)(m + 64), 3 + 64);
                    }
                    // If we are in the dark world, set the light world opposite too.
                    else if (m >= 64 && m < 128)
                    {
                        scene.ow.allmaps[m - 64].SetAsLargeMap((byte)(m - 64), 0);
                        scene.ow.allmaps[m - 64 + 1].SetAsLargeMap((byte)(m - 64), 1 + 64);
                        scene.ow.allmaps[m - 64 + 8].SetAsLargeMap((byte)(m - 64), 2 + 64);
                        scene.ow.allmaps[m - 64 + 9].SetAsLargeMap((byte)(m - 64), 3 + 64);
                    }

                    scene.ow.getLargeMaps();

                    Console.WriteLine("Updating object locations.");

                    if (m < 64)
                    {
                        int[] mtable = new int[8] { 0, 1, 8, 9, 64, 64 + 1, 64 + 8, 64 + 9 };

                        for (int i = 0; i < 8; i++)
                        {
                            m = scene.ow.allmaps[scene.selectedMap].parent + mtable[i];

                            foreach (EntranceOWEditor o in scene.ow.allentrances)
                            {
                                if (o.mapId == m)
                                {
                                    o.updateMapStuff(scene.ow.allmaps[m].parent);
                                }
                            }
                            foreach (EntranceOWEditor o in scene.ow.allholes)
                            {
                                if (o.mapId == m)
                                {
                                    o.updateMapStuff(scene.ow.allmaps[m].parent);
                                }
                            }
                            foreach (TransportOW o in scene.ow.allBirds)
                            {
                                if (o.mapId == m)
                                {
                                    o.updateMapStuff(scene.ow.allmaps[m].parent, scene.ow);
                                }
                            }
                            foreach (TransportOW o in scene.ow.allWhirlpools)
                            {
                                if (o.mapId == m)
                                {
                                    o.updateMapStuff(scene.ow.allmaps[m].parent, scene.ow);
                                }
                            }
                            foreach (ExitOW o in scene.ow.allexits)
                            {
                                if (o.mapId == m)
                                {
                                    o.updateMapStuff(scene.ow.allmaps[m].parent, scene.ow);
                                }
                            }
                            foreach (RoomPotSaveEditor o in scene.ow.allitems)
                            {
                                if (o.roomMapId == m)
                                {
                                    o.updateMapStuff(scene.ow.allmaps[m].parent);
                                }
                            }
                            foreach (Sprite o in scene.ow.allsprites[0])
                            {
                                if (o.mapid == m)
                                {
                                    o.updateMapStuff(scene.ow.allmaps[m].parent);
                                }
                            }
                            foreach (Sprite o in scene.ow.allsprites[1])
                            {
                                if (o.mapid == m)
                                {
                                    o.updateMapStuff(scene.ow.allmaps[m].parent);
                                }
                            }
                            foreach (Sprite o in scene.ow.allsprites[2])
                            {
                                if (o.mapid == m)
                                {
                                    o.updateMapStuff(scene.ow.allmaps[m].parent);
                                }
                            }
                        }
                    }
                    else if (m >= 64 && m < 128)
                    {
                        int[] mtable = new int[8] { 0, 1, 8, 9, -64, -64 + 1, -64 + 8, -64 + 9 };

                        for (int i = 0; i < 8; i++)
                        {
                            m = scene.ow.allmaps[scene.selectedMap].parent + mtable[i];

                            foreach (EntranceOWEditor o in scene.ow.allentrances)
                            {
                                if (o.mapId == m)
                                {
                                    o.updateMapStuff(scene.ow.allmaps[m].parent);
                                }
                            }
                            foreach (EntranceOWEditor o in scene.ow.allholes)
                            {
                                if (o.mapId == m)
                                {
                                    o.updateMapStuff(scene.ow.allmaps[m].parent);
                                }
                            }
                            foreach (TransportOW o in scene.ow.allBirds)
                            {
                                if (o.mapId == m)
                                {
                                    o.updateMapStuff(scene.ow.allmaps[m].parent, scene.ow);
                                }
                            }
                            foreach (TransportOW o in scene.ow.allWhirlpools)
                            {
                                if (o.mapId == m)
                                {
                                    o.updateMapStuff(scene.ow.allmaps[m].parent, scene.ow);
                                }
                            }
                            foreach (ExitOW o in scene.ow.allexits)
                            {
                                if (o.mapId == m)
                                {
                                    o.updateMapStuff(scene.ow.allmaps[m].parent, scene.ow);
                                }
                            }
                            foreach (RoomPotSaveEditor o in scene.ow.allitems)
                            {
                                if (o.roomMapId == m)
                                {
                                    o.updateMapStuff(scene.ow.allmaps[m].parent);
                                }
                            }
                            foreach (Sprite o in scene.ow.allsprites[0])
                            {
                                if (o.mapid == m)
                                {
                                    o.updateMapStuff(scene.ow.allmaps[m].parent);
                                }
                            }
                            foreach (Sprite o in scene.ow.allsprites[1])
                            {
                                if (o.mapid == m)
                                {
                                    o.updateMapStuff(scene.ow.allmaps[m].parent);
                                }
                            }
                            foreach (Sprite o in scene.ow.allsprites[2])
                            {
                                if (o.mapid == m)
                                {
                                    o.updateMapStuff(scene.ow.allmaps[m].parent);
                                }
                            }
                        }
                    }

                    Console.WriteLine("Done updating object locations ");
                }
            }
            else // Small maps
            {
                scene.ow.allmaps[m].SetAsSmallMap();
                scene.ow.allmaps[m + 1].SetAsSmallMap();
                scene.ow.allmaps[m + 8].SetAsSmallMap();
                scene.ow.allmaps[m + 9].SetAsSmallMap();

                // If we are in the light world, set the dark world opposite too.
                if (m < 64)
                {
                    scene.ow.allmaps[m + 64].SetAsSmallMap();
                    scene.ow.allmaps[m + 64 + 1].SetAsSmallMap();
                    scene.ow.allmaps[m + 64 + 8].SetAsSmallMap();
                    scene.ow.allmaps[m + 64 + 9].SetAsSmallMap();
                }
                // If we are in the dark world, set the light world opposite too.
                else if (m >= 64 && m < 128)
                {
                    scene.ow.allmaps[m - 64].SetAsSmallMap();
                    scene.ow.allmaps[m - 64 + 1].SetAsSmallMap();
                    scene.ow.allmaps[m - 64 + 8].SetAsSmallMap();
                    scene.ow.allmaps[m - 64 + 9].SetAsSmallMap();
                }

                scene.ow.getLargeMaps();

                Console.WriteLine("Updating object locations.");

                if (m < 64)
                {
                    int[] mtable = new int[2] { 0, 64 };

                    for (int i = 0; i < 2; i++)
                    {
                        m = scene.ow.allmaps[scene.selectedMap].parent + mtable[i];

                        int j = 0;
                        // We are unchecking the large map box so all sprites on map00 are returning to other maps
                        foreach (EntranceOWEditor o in scene.ow.allentrances)
                        {
                            if (o.mapId == m)
                            {
                                if (o.AreaX < 32)
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m].index);
                                        j++;
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 8].index);
                                        j++;
                                    }
                                }
                                else
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 1].index);
                                        j++;
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 9].index);
                                        j++;
                                    }
                                }
                            }
                        }
                        Console.WriteLine("Total entrances moved: " + j);
                        j = 0;
                        foreach (EntranceOWEditor o in scene.ow.allholes)
                        {
                            if (o.mapId == m)
                            {
                                if (o.AreaX < 32)
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m].index);
                                        j++;
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 8].index);
                                        j++;
                                    }
                                }
                                else
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 1].index);
                                        j++;
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 9].index);
                                        j++;
                                    }
                                }
                            }
                        }
                        Console.WriteLine("Total holes moved: " + j);
                        j = 0;
                        foreach (TransportOW o in scene.ow.allBirds)
                        {
                            if (o.mapId == m)
                            {
                                if (o.AreaX < 32)
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m].index, scene.ow);
                                        j++;
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 8].index, scene.ow);
                                        j++;
                                    }
                                }
                                else
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 1].index, scene.ow);
                                        j++;
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 9].index, scene.ow);
                                        j++;
                                    }
                                }
                            }
                        }
                        Console.WriteLine("Total brids moved: " + j);
                        j = 0;
                        foreach (TransportOW o in scene.ow.allWhirlpools)
                        {
                            if (o.mapId == m)
                            {
                                if (o.AreaX < 32)
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m].index, scene.ow);
                                        j++;
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 8].index, scene.ow);
                                        j++;
                                    }
                                }
                                else
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 1].index, scene.ow);
                                        j++;
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 9].index, scene.ow);
                                        j++;
                                    }
                                }
                            }
                        }
                        Console.WriteLine("Total whirlpools moved: " + j);
                        j = 0;
                        foreach (ExitOW o in scene.ow.allexits)
                        {
                            if (o.mapId == m)
                            {
                                if (o.AreaX < 32)
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m].index, scene.ow);
                                        j++;
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 8].index, scene.ow);
                                        j++;
                                    }
                                }
                                else
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 1].index, scene.ow);
                                        j++;
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 9].index, scene.ow);
                                        j++;
                                    }
                                }
                            }
                        }
                        Console.WriteLine("Total exits moved: " + j);
                        j = 0;
                        foreach (RoomPotSaveEditor o in scene.ow.allitems)
                        {
                            if (o.roomMapId == m)
                            {
                                if (o.gameX < 32)
                                {
                                    if (o.gameY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m].index);
                                        j++;
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 8].index);
                                        j++;
                                    }
                                }
                                else
                                {
                                    if (o.gameY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 1].index);
                                        j++;
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 9].index);
                                        j++;
                                    }
                                }
                            }
                        }
                        Console.WriteLine("Total items moved: " + j);
                        j = 0;
                        foreach (Sprite o in scene.ow.allsprites[0])
                        {
                            if (o.mapid == m)
                            {
                                if (o.x < 32)
                                {
                                    if (o.y < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m].index);
                                        j++;
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 8].index);
                                        j++;
                                    }
                                }
                                else
                                {
                                    if (o.y < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 1].index);
                                        j++;
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 9].index);
                                        j++;
                                    }
                                }
                            }
                        }
                        Console.WriteLine("Total sprites (0,1) moved: " + j);
                        j = 0;
                        foreach (Sprite o in scene.ow.allsprites[1])
                        {
                            if (o.mapid == m)
                            {
                                if (o.x < 32)
                                {
                                    if (o.y < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m].index);
                                        j++;
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 8].index);
                                        j++;
                                    }
                                }
                                else
                                {
                                    if (o.y < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 1].index);
                                        j++;
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 9].index);
                                        j++;
                                    }
                                }
                            }
                        }
                        Console.WriteLine("Total sprites (2) moved: " + j);
                        j = 0;
                        foreach (Sprite o in scene.ow.allsprites[2])
                        {
                            if (o.mapid == m)
                            {
                                if (o.x < 32)
                                {
                                    if (o.y < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m].index);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 8].index);
                                    }
                                }
                                else
                                {
                                    if (o.y < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 1].index);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 9].index);
                                    }
                                }
                                j++;
                            }
                        }
                        Console.WriteLine("Total sprites (3) moved: " + j);
                        j = 0;
                    }
                }
                else if (m >= 64 && m < 128)
                {
                    int[] mtable = new int[2] { 0, -64 };

                    for (int i = 0; i < 2; i++)
                    {
                        m = scene.ow.allmaps[scene.selectedMap].parent + mtable[i];

                        // We are unchecking the large map box so all sprites on map00 are returning to other maps.
                        foreach (EntranceOWEditor o in scene.ow.allentrances)
                        {
                            if (o.mapId == m)
                            {
                                if (o.AreaX < 32)
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m].index);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 8].index);
                                    }
                                }
                                else
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 1].index);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 9].index);
                                    }
                                }
                            }
                        }
                        foreach (EntranceOWEditor o in scene.ow.allholes)
                        {
                            if (o.mapId == m)
                            {
                                if (o.AreaX < 32)
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m].index);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 8].index);
                                    }
                                }
                                else
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 1].index);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 9].index);
                                    }
                                }
                            }
                        }
                        foreach (TransportOW o in scene.ow.allBirds)
                        {
                            if (o.mapId == m)
                            {
                                if (o.AreaX < 32)
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m].index, scene.ow);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 8].index, scene.ow);
                                    }
                                }
                                else
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 1].index, scene.ow);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 9].index, scene.ow);
                                    }
                                }
                            }
                        }
                        foreach (TransportOW o in scene.ow.allWhirlpools)
                        {
                            if (o.mapId == m)
                            {
                                if (o.AreaX < 32)
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m].index, scene.ow);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 8].index, scene.ow);
                                    }
                                }
                                else
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 1].index, scene.ow);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 9].index, scene.ow);
                                    }
                                }
                            }
                        }
                        foreach (ExitOW o in scene.ow.allexits)
                        {
                            if (o.mapId == m)
                            {
                                if (o.AreaX < 32)
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m].index, scene.ow);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 8].index, scene.ow);
                                    }
                                }
                                else
                                {
                                    if (o.AreaY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 1].index, scene.ow);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 9].index, scene.ow);
                                    }
                                }
                            }
                        }
                        foreach (RoomPotSaveEditor o in scene.ow.allitems)
                        {
                            if (o.roomMapId == m)
                            {
                                if (o.gameX < 32)
                                {
                                    if (o.gameY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m].index);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 8].index);
                                    }
                                }
                                else
                                {
                                    if (o.gameY < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 1].index);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 9].index);
                                    }
                                }
                            }
                        }
                        foreach (Sprite o in scene.ow.allsprites[0])
                        {
                            if (o.mapid == m)
                            {
                                if (o.x < 32)
                                {
                                    if (o.y < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m].index);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 8].index);
                                    }
                                }
                                else
                                {
                                    if (o.y < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 1].index);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 9].index);
                                    }
                                }
                            }
                        }
                        foreach (Sprite o in scene.ow.allsprites[1])
                        {
                            if (o.mapid == m)
                            {
                                if (o.x < 32)
                                {
                                    if (o.y < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m].index);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 8].index);
                                    }
                                }
                                else
                                {
                                    if (o.y < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 1].index);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 9].index);
                                    }
                                }
                            }
                        }
                        foreach (Sprite o in scene.ow.allsprites[2])
                        {
                            if (o.mapid == m)
                            {
                                if (o.x < 32)
                                {
                                    if (o.y < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m].index);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 8].index);
                                    }
                                }
                                else
                                {
                                    if (o.y < 32)
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 1].index);
                                    }
                                    else
                                    {
                                        o.updateMapStuff(scene.ow.allmaps[m + 9].index);
                                    }
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("Done updating object locations ");
            }
        }



        /// <summary>
        /// Clears all overworld sprites of the selected stage (beginning, 1st, and 2nd phase)
        /// </summary>
        /// <param name="phase"></param>
        public void clearOverworldSprites(int phase)
        {
            overworld.allsprites[phase].Clear();
        }

        /// <summary>
        /// Clears all overworld items
        /// </summary>
        public void clearOverworldItems()
        {
            overworld.allitems.Clear();
        }

        /// <summary>
        /// Clears all overworld entrances
        /// </summary>
        public void clearOverworldEntrances()
        {
            for (int i = 0; i < overworld.allentrances.Length; i++)
            {
                var entrance = overworld.allentrances[i];

                entrance.x = 0xFFFF;
                entrance.y = 0xFFFF;
                entrance.mapId = 0;
                entrance.mapPos = 0xFFFF;
                entrance.entranceId = 0;
                entrance.deleted = true;

                //Console.WriteLine(Room_Name.room_name[i] + " X:" + entrance.x + " Y:" + entrance.y + " MapID:" + entrance.mapId + " MapPos:" + entrance.mapPos + " EntranceID:" + entrance.entranceId + " Deleted:" + entrance.deleted);
            }
        }

        /// <summary>
        /// Clears all overworld entrances
        /// </summary>
        public void clearOverworldHoles()
        {
            for (int i = 0; i < overworld.allholes.Length; i++)
            {
                var entrance = overworld.allholes[i];

                entrance.x = 0xFFFF;
                entrance.y = 0xFFFF;
                entrance.mapId = 0;
                entrance.mapPos = 0xFFFF;
                entrance.entranceId = 0;
                entrance.deleted = true;
            }
        }

        /// <summary>
        /// Clears all overworld exits
        /// </summary>
        public void clearOverworldExits()
        {
            foreach (var exit in overworld.allexits)
            {
                exit.playerX = 0xFFFF;
                exit.playerY = 0xFFFF;
                exit.mapId = 0;
                exit.roomId = 0;
                exit.deleted = true;
            }
        }

        /// <summary>
        /// Clears all of the overworld overlays
        /// </summary>
        public void clearOverworldOverlays()
        {
            foreach (var overlay in overworld.alloverlays)
            {
                overlay.tilesData.Clear();
            }
        }

        /// <summary>
        /// Clears all overworld sprites of the selected stage (beginning, 1st, and 2nd phase)
        /// </summary>
        /// <param name="phase"></param>
        public void clearAreaSprites(int phase)
        {
            overworld.allsprites[phase].RemoveAll(o => o.mapid == scene.selectedMapParent);
        }

        /// <summary>
        /// Clears all of the selected area's items
        /// </summary>
        public void clearAreaItems()
        {
            overworld.allitems.RemoveAll(o => o.roomMapId == scene.selectedMapParent);
        }

        /// <summary>
        /// Clears all the selected area's entrances
        /// </summary>
        public void clearAreaEntrances()
        {
            foreach (EntranceOWEditor entrance in overworld.allentrances)
            {
                if (entrance.mapId == scene.selectedMapParent)
                {
                    entrance.x = 0xFFFF;
                    entrance.y = 0xFFFF;
                    entrance.mapId = 0;
                    entrance.mapPos = 0xFFFF;
                    entrance.entranceId = 0;
                    entrance.deleted = true;
                }
            }
        }

        /// <summary>
        /// Clears all the slected area's entrances
        /// </summary>
        public void clearAreaHoles()
        {
            foreach (var hole in overworld.allholes)
            {
                if (hole.mapId == scene.selectedMapParent)
                {
                    hole.x = 0xFFFF;
                    hole.y = 0xFFFF;
                    hole.mapId = 0;
                    hole.mapPos = 0xFFFF;
                    hole.entranceId = 0;
                    hole.deleted = true;
                }
            }
        }

        /// <summary>
        /// Clears all of the selected area's exits
        /// </summary>
        public void clearAreaExits()
        {
            foreach (var exit in overworld.allexits)
            {
                if (exit.mapId == scene.selectedMapParent)
                {
                    exit.playerX = 0xFFFF;
                    exit.playerY = 0xFFFF;
                    exit.mapId = 0;
                    exit.roomId = 0;
                    exit.deleted = true;
                }
            }
        }

        /// <summary>
        /// Clears all of the selected area's overlays
        /// </summary>
        public void clearAreaOverlays()
        {
            overworld.alloverlays[scene.selectedMapParent].tilesData.Clear();
            scene.Refresh();
        }

        /// <summary>
        /// Called when the area background color box is double cliked, brings up color editor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AreaBGColorPicturebox_MouseDoubleClick(object sender, EventArgs e)
        {
            int selectedParent = scene.ow.allmaps[scene.selectedMap].parent;

            cd.Color = Palettes.overworld_BackgroundPalette[selectedParent];
            if (cd.ShowDialog() == DialogResult.OK)
            {
                Palettes.overworld_BackgroundPalette[selectedParent] = cd.Color;
                areaBGColorPictureBox.Refresh();
            }

            mainForm.overworldEditor.overworld.allmaps[selectedParent].LoadPalette();
        }

        /// <summary>
        /// Paints the Area Background color box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AreaBGColorPicturebox_Paint(object sender, PaintEventArgs e)
        {
            int selectedParent = scene.ow.allmaps[scene.selectedMap].parent;

            if (selectedParent < Palettes.overworld_BackgroundPalette.Length)
            {
                e.Graphics.FillRectangle(new SolidBrush(Palettes.overworld_BackgroundPalette[selectedParent]), Constants.Rect_0_0_24_24);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Black), Constants.Rect_0_0_24_24);
            }
        }

        public void SetSelectedObjectLabels(int id, int x, int y)
        {
            SelectedObjectID.Text = id.ToString("X2");
            SelectedObjectX.Text = x.ToString("X2");
            SelectedObjectY.Text = y.ToString("X2");
        }

        private void exportmultipleROMPNG()
        {

        }

        private void exportPNGToolStripButton_Click(object sender, EventArgs e)
        {
            Bitmap temp = new Bitmap(4096, 4096);
            Graphics g = Graphics.FromImage(temp);

            if (UseAreaSpecificBgColor)
            {
                for (int i = 0; i < 64; i++)
                {
                    int x = (i % 8) * 512;
                    int y = (i / 8) * 512;

                    int k = overworld.allmaps[i].parent;
                    g.FillRectangle(new SolidBrush(Palettes.overworld_BackgroundPalette[k]), new Rectangle(x, y, 512, 512));
                }
            }
            else
            {
                g.FillRectangle(new SolidBrush(Palettes.overworld_GrassPalettes[0]), new Rectangle(0, 0, 4096, 4096));
            }

            for (int i = 0; i < 64; i++)
            {
                int x = (i % 8) * 512;
                int y = (i / 8) * 512;

                g.DrawImage(overworld.allmaps[i].gfxBitmap, x, y, new Rectangle(0, 0, 512, 512), GraphicsUnit.Pixel);
            }

            temp.Save("LW.png");

            temp = new Bitmap(4096, 4096);
            g = Graphics.FromImage(temp);

            if (UseAreaSpecificBgColor)
            {
                for (int i = 0; i < 64; i++)
                {
                    int x = (i % 8) * 512;
                    int y = (i / 8) * 512;

                    int k = overworld.allmaps[i].parent;
                    g.FillRectangle(new SolidBrush(Palettes.overworld_BackgroundPalette[k + 64]), new Rectangle(x, y, 512, 512));
                }
            }
            else
            {
                g.FillRectangle(new SolidBrush(Palettes.overworld_GrassPalettes[1]), new Rectangle(0, 0, 4096, 4096));
            }

            for (int i = 0; i < 64; i++)
            {
                int x = (i % 8) * 512;
                int y = (i / 8) * 512;

                g.DrawImage(overworld.allmaps[i + 64].gfxBitmap, x, y, new Rectangle(0, 0, 512, 512), GraphicsUnit.Pixel);
            }

            temp.Save("DW.png");

            temp = new Bitmap(4096, 4096);
            g = Graphics.FromImage(temp);

            if (UseAreaSpecificBgColor)
            {
                for (int i = 0; i < 32; i++)
                {
                    int x = (i % 8) * 512;
                    int y = (i / 8) * 512;

                    int k = overworld.allmaps[i].parent;
                    g.FillRectangle(new SolidBrush(Palettes.overworld_BackgroundPalette[k + 128]), new Rectangle(x, y, 512, 512));
                }
            }
            else
            {
                g.FillRectangle(new SolidBrush(Palettes.overworld_GrassPalettes[1]), new Rectangle(0, 0, 4096, 4096));
            }

            for (int i = 0; i < 32; i++)
            {
                int x = (i % 8) * 512;
                int y = (i / 8) * 512;

                g.DrawImage(overworld.allmaps[i + 128].gfxBitmap, x, y, new Rectangle(0, 0, 512, 512), GraphicsUnit.Pixel);
            }

            temp.Save("SP.png");
        }

        public void UpdateBGColorVisibility(bool x)
        {
            label7.Visible = x;
            areaBGColorPictureBox.Visible = x;
        }

        private void mosaicCheckBox_Click(object sender, EventArgs e)
        {
            scene.ow.allmaps[scene.ow.allmaps[scene.selectedMap].parent].mosaic = mosaicCheckBox.Checked;
        }

        private void openfileButton_Click(object sender, EventArgs e)
        {

        }

        public void SendLargeMapChanged(int m, bool c)
        {
            if (!NetZS.connected) { return; }
            NetZSBuffer buffer = new NetZSBuffer(8);
            buffer.Write((byte)12); // sprite data
            buffer.Write((byte)NetZS.userID); //user ID
            buffer.Write((int)m);
            buffer.Write((byte)(c ? 1 : 0)); //is checked
            NetOutgoingMessage msg = NetZS.client.CreateMessage();
            msg.Write(buffer.buffer);
            NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
            NetZS.client.FlushSendQueue();
        }


        public void SendMapProperties(OverworldMap map)
        {
            if (!NetZS.connected) { return; }
            NetZSBuffer buffer = new NetZSBuffer(16);
            buffer.Write((byte)13); // map properties
            buffer.Write((byte)NetZS.userID); //user ID
            buffer.Write((byte)map.index);
            buffer.Write((byte)map.palette);
            buffer.Write((byte)map.gfx);
            buffer.Write((short)map.messageID);

            if (map.index >= 64)
            {
                buffer.Write((byte)0);
                buffer.Write((byte)map.sprgfx[0]);
                buffer.Write((byte)map.sprpalette[0]);
            }
            else
            {
                buffer.Write((byte)scene.ow.gameState);
                buffer.Write((byte)map.sprgfx[scene.ow.gameState]);
                buffer.Write((byte)map.sprpalette[scene.ow.gameState]);
            }

            NetOutgoingMessage msg = NetZS.client.CreateMessage();
            msg.Write(buffer.buffer);
            NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
            NetZS.client.FlushSendQueue();

        }

    }
}
