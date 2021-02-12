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
        public Bitmap tmpPreviewBitmap = new Bitmap(256, 256);
        public Bitmap scratchPadBitmap = new Bitmap(256, 3600);
        public ushort[,] scratchPadTiles = new ushort[16, 225];
        public void InitOpen(DungeonMain mainForm)
        {
            overworld = new Overworld();
            scene = new SceneOW(this, overworld, mainForm);
            scene.Location = new Point(0, 0);
            scene.Size = new Size(4096, 4096);
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
            stateCombobox.SelectedIndex = 1;
            scratchPicturebox.Image = scratchPadBitmap;
            //setTilesGfx();
            bool fromFile = false;
            byte[] file = new byte[(225*16)*2];
            if (File.Exists("ScratchPad.dat"))
            {
                using (FileStream fs = new FileStream("ScratchPad.dat", FileMode.Open, FileAccess.Read))
                {
                    fs.Read(file,0,(int)fs.Length);
                    fs.Close();
                    fromFile = true;
                }
            }
            int t = 0;
            for (ushort x = 0; x < 225; x++)
            {
                for (ushort y = 0; y < 16; y++)
                {
                    if (fromFile)
                    {
                        scratchPadTiles[y, x] = (ushort)((file[t]<<8)+ file[t+1]);
                    }
                    else
                    {
                        scratchPadTiles[y, x] = (ushort)0;
                    }
                    t+=2;
                }
            }

        }

        public void saveScratchPad()
        {
            byte[] file = new byte[(225 * 16) * 2];

            int t = 0;
            for (ushort x = 0; x < 225; x++)
            {
                for (ushort y = 0; y < 16; y++)
                {
                    file[t] = (byte)((scratchPadTiles[y, x] >> 8) & 0xFF);
                    file[t+1] = (byte)((scratchPadTiles[y, x]) & 0xFF);
                    t +=2;
                }
            }
            using (FileStream fs = new FileStream("ScratchPad.dat", FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Write(file, 0, (int)fs.Length);
                fs.Close();
            }
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
            if (GFX.mapblockset16Bitmap != null)
            {

                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                e.Graphics.DrawImage(GFX.mapblockset16Bitmap, new Rectangle(0, 0, 128, 3600), new Rectangle(0, 0, 128, 3600), GraphicsUnit.Pixel);
                e.Graphics.DrawImage(GFX.mapblockset16Bitmap, new Rectangle(128, 0, 128, 3600), new Rectangle(0, 3600, 128, 3600), GraphicsUnit.Pixel);
                if (scene.selectedTile.Length > 0)
                {
                    int x = (scene.selectedTile[0] % 8) * 16;
                    int y = ((scene.selectedTile[0] / 8)) * 16;
                    if (scene.selectedTile[0] >= 1800)
                    {
                        y -= 3600;
                        x += 128;
                    }
                    e.Graphics.DrawRectangle(Pens.LimeGreen, new Rectangle(x, y, 16, 16));
                    selectedTileLabel.Text = "Selected Tile : " + scene.selectedTile[0].ToString();
                }

            }
        }

        private void tilePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            scene.selectedTileSizeX = 1;
            if (e.X > 128)
            {
                scene.selectedTile = new ushort[1] { (ushort)(((e.X - 128) / 16) + ((e.Y / 16) * 8) + 1800) };
            }
            else
            {
                scene.selectedTile = new ushort[1] { (ushort)((e.X / 16) + ((e.Y / 16) * 8)) };
            }
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

        }

        private void tilePictureBox_DoubleClick(object sender, EventArgs e)
        {

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

        private void scratchPicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            int tileX = (e.X / 16);
            int tileY = (e.Y / 16);
            globalmouseTileDownX = tileX;
            globalmouseTileDownY = tileY;
            


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
                    ushort[] undotiles = new ushort[scene.selectedTile.Length];
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

                        scene.selectedTileSizeX = sizeX;
                        scene.selectedTile = new ushort[(sizeX) * (sizeY)];
                        for (int y = 0; y < sizeY; y++)
                        {
                            for (int x = 0; x < sizeX; x++)
                            {
                                int pX = globalmouseTileDownX;
                                int pY = globalmouseTileDownY;

                                if (reverseX) { pX = tileX; }
                                if (reverseY) { pY = tileY; }
                                scene.selectedTile[x + (y * sizeX)] = scratchPadTiles[(pX) + x, (pY) + y];
                            }
                        }
                    }
                }

            }
            selecting = false;
            mouse_down = false;
            scratchPicturebox.Refresh();
        }
        bool mouse_down = false;
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
        bool initialized = false;
        bool selecting = false;
        int globalmouseTileDownX = 0;
        int globalmouseTileDownY = 0;
        int mouseX_Real = 0;
        int mouseY_Real = 0;
        int lastTileHoverX = 0;
        int lastTileHoverY = 0;
        protected override void OnPaint(PaintEventArgs e)
        {

        }

        private void scratchPicturebox_Paint(object sender, PaintEventArgs e)
        {
            if (GFX.mapblockset16Bitmap != null)
            {
                //USE mapblockset16 to draw tiles on this !! :GRIMACING:
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

                g.DrawImage(GFX.scratchblockset16Bitmap,0,0);
                
                //if (initialized)
                //{

                int x = 0;
                int y = 0;
                //DRAW ALL THE TILES 16x225

                g.CompositingMode = CompositingMode.SourceOver;



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
            //}
        }



        public unsafe void BuildScratchTilesGfx()
        {
            GFX.scratchblockset16Bitmap.Palette = GFX.mapblockset16Bitmap.Palette;
            var gfx16Data = (byte*)GFX.mapblockset16.ToPointer();//(byte*)allgfx8Ptr.ToPointer();
            var gfx16DataScratch = (byte*)GFX.scratchblockset16.ToPointer();//(byte*)allgfx16Ptr.ToPointer();
            int ytile = 0;
            int xtile = 0;
            for (var i = 0; i < 3600; i++) //number of tiles16 3748?
            {
                ushort srcTile = scratchPadTiles[xtile, ytile];
                //Console.WriteLine(srcTile);
                int srcTileY = (srcTile / 8);
                int srcTileX = srcTile - (srcTileY*8);
                int tPos = (xtile * 16) + (ytile * 4096);
                int srctPos = (srcTileX * 16) + (srcTileY * 2048);

                int pxPos = 0;
                int pxPosSrc = 0;
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        pxPos = (x + (y * 256));
                        pxPosSrc = (x + (y * 128));
                        gfx16DataScratch[tPos + pxPos] = gfx16Data[srctPos + pxPosSrc];
                    }
                }
                

                xtile++;
                if (xtile>=16)
                {
                    xtile = 0;
                    ytile++;
                }
            }


        }
    }
}
