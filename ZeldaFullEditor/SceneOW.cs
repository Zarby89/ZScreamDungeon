using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using ZeldaFullEditor.Properties;
using Microsoft.VisualBasic;
using System.IO.Compression;
using static ZeldaFullEditor.Form1;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using ZeldaFullEditor.OWSceneModes;

namespace ZeldaFullEditor
{
    public class SceneOW : Scene
    {

        //public IntPtr allgfx8array = Marshal.AllocHGlobal(32768);

        //  int selectedIndex = 0;
        public int selectedMap = 0;
        //must load all current map gfx
        public Overworld ow;
        public bool initialized = false;
        public bool needRedraw = true;
        public ushort[] selectedTile = new ushort[1] { 0 };
        public int selectedTileSizeX = 1;
        public int globalmouseTileDownX = 0;
        public int globalmouseTileDownY = 0;
        public int mouseX_Real = 0;
        public int mouseY_Real = 0;
        public int lastTileHoverX = 0;
        public int lastTileHoverY = 0;
        public int mapHover = 0;
        public bool selecting = false;
        public IntPtr overlaygfxPtr = Marshal.AllocHGlobal(1024 * 1024);
        public IntPtr temptilesgfxPtr = Marshal.AllocHGlobal(1024 * 1024);
        public Bitmap tilesgfxBitmap;
        public Bitmap tileBitmap;
        public IntPtr tileBitmapPtr;
        public bool snapToGrid = true;
        public TileMode tilemode;
        public ExitMode exitmode;
        public DoorMode doorMode;
        public EntranceMode entranceMode;
        public SpriteMode spriteMode;
        public ItemMode itemMode;
        public Sprite selectedFormSprite;
        public TransportMode transportMode;
        public bool showEntrances = true;
        public bool showExits = true;
        public bool showFlute = true;
        public bool showItems = true;
        public bool showSprites = true;
        public bool hideText = false;
        //int selectedMode = 0;
        public SceneOW(Form1 f)
        {
            //graphics = Graphics.FromImage(scene_bitmap);
            //this.Image = new Bitmap(4096, 4096);
            this.MouseUp += new MouseEventHandler(onMouseUp);
            this.MouseMove += new MouseEventHandler(onMouseMove);
            this.MouseDoubleClick += new MouseEventHandler(onMouseDoubleClick);
            this.MouseWheel += SceneOW_MouseWheel;
            mainForm = f;
            tilesgfxBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, temptilesgfxPtr);
            tilemode = new TileMode(this);
            exitmode = new ExitMode(this);
            doorMode = new DoorMode(this);
            entranceMode = new EntranceMode(this);
            selectedMode = ObjectMode.Tile;
            itemMode = new ItemMode(this);
            spriteMode = new SpriteMode(this);
            transportMode = new TransportMode(this);
            //this.Refresh();
        }

        public void CreateScene()
        {
            tileBitmapPtr = ow.allmaps[0].blockset16;
            tileBitmap = new Bitmap(128, 8192, 128, PixelFormat.Format8bppIndexed, tileBitmapPtr);
        }

        private void SceneOW_MouseWheel(object sender, MouseEventArgs e)
        {

        }

        public void updateMapGfx()
        {


            mainForm.groupBox4.Text = "Overworld : Selected Map " + ow.allmaps[selectedMap].parent.ToString() + " Properties : ";

            mainForm.propertiesChangedFromForm = true;
            if (selectedMap >= 64)
            {
                mainForm.OW_tilesetGFX.Text = ow.allmaps[ow.allmaps[selectedMap].parent].gfx.ToString();
                mainForm.OW_spriteGFX.Text = ow.allmaps[ow.allmaps[selectedMap].parent].sprgfx[0].ToString();
                mainForm.OW_tilesetPAL.Text = ow.allmaps[ow.allmaps[selectedMap].parent].palette.ToString();
                mainForm.OW_spritePAL.Text = ow.allmaps[ow.allmaps[selectedMap].parent].sprpalette[0].ToString();
            }
            else
            {
                mainForm.OW_tilesetGFX.Text = ow.allmaps[ow.allmaps[selectedMap].parent].gfx.ToString();
                mainForm.OW_spriteGFX.Text = ow.allmaps[ow.allmaps[selectedMap].parent].sprgfx[ow.gameState].ToString();
                mainForm.OW_tilesetPAL.Text = ow.allmaps[ow.allmaps[selectedMap].parent].palette.ToString();
                mainForm.OW_spritePAL.Text = ow.allmaps[ow.allmaps[selectedMap].parent].sprpalette[ow.gameState].ToString();
            }
            mainForm.propertiesChangedFromForm = false;
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            int tileX = (e.X / 16);
            int tileY = (e.Y / 16);
            int superX = (tileX / 32);
            int superY = (tileY / 32);
            int mapId = (superY * 8) + superX;
            globalmouseTileDownX = tileX;
            globalmouseTileDownY = tileY;
            selectedMap = mapId;
            updateMapGfx();

            if (selectedMode == ObjectMode.Tile)
            {
                tilemode.OnMouseDown(e);
            }
            else if (selectedMode == ObjectMode.Exits)
            {
                exitmode.onMouseDown(e);
            }
            else if (selectedMode == ObjectMode.OWDoor)
            {
                doorMode.OnMouseDown(e);
            }
            else if (selectedMode == ObjectMode.Entrances)
            {
                entranceMode.onMouseDown(e);
            }
            else if (selectedMode == ObjectMode.Itemmode)
            {
                itemMode.onMouseDown(e);
            }
            else if (selectedMode == ObjectMode.Spritemode)
            {
                spriteMode.onMouseDown(e);
            }
            else if (selectedMode == ObjectMode.Flute)
            {
                transportMode.onMouseDown(e);
            }
            Invalidate(new Rectangle(mainForm.panel5.HorizontalScroll.Value, mainForm.panel5.VerticalScroll.Value, mainForm.panel5.Width, mainForm.panel5.Height));
            base.OnMouseDown(e);
        }

        private unsafe void onMouseUp(object sender, MouseEventArgs e)
        {
            if (selectedMode == ObjectMode.Tile)
            {
                tilemode.OnMouseUp(e);
            }
            else if (selectedMode == ObjectMode.Exits)
            {
                exitmode.onMouseUp(e);
            }
            else if (selectedMode == ObjectMode.OWDoor)
            {
                //doorMode.onMouseUp(e);
            }
            else if (selectedMode == ObjectMode.Entrances)
            {
                entranceMode.onMouseUp(e);
            }
            else if (selectedMode == ObjectMode.Itemmode)
            {
                itemMode.onMouseUp(e);
            }
            else if (selectedMode == ObjectMode.Spritemode)
            {
                spriteMode.onMouseUp(e);
            }
            else if (selectedMode == ObjectMode.Flute)
            {
                transportMode.onMouseUp(e);
            }
        }

        private void onMouseMove(object sender, MouseEventArgs e)
        {
            if (selectedMode == ObjectMode.Tile)
            {
                tilemode.OnMouseMove(e);
            }
            else if (selectedMode == ObjectMode.Exits)
            {
                exitmode.onMouseMove(e);
            }
            else if (selectedMode == ObjectMode.OWDoor)
            {
                doorMode.onMouseMove(e);
            }
            else if (selectedMode == ObjectMode.Entrances)
            {
                entranceMode.onMouseMove(e);
            }
            else if (selectedMode == ObjectMode.Itemmode)
            {
                itemMode.onMouseMove(e);
            }
            else if (selectedMode == ObjectMode.Spritemode)
            {
                spriteMode.onMouseMove(e);
            }
            else if (selectedMode == ObjectMode.Flute)
            {
                transportMode.onMouseMove(e);
            }
        }

        public void Undo()
        {
            tilemode.Undo();
        }

        public void Redo()
        {
            tilemode.Redo();
        }

        public override void paste()
        {
            if (selectedMode == ObjectMode.Tile)
            {
                tilemode.Paste();
            }
            else if (selectedMode == ObjectMode.Exits)
            {
               exitmode.Paste();
            }
            else if (selectedMode == ObjectMode.Itemmode)
            {
                itemMode.Paste();
            }
            else if (selectedMode == ObjectMode.Spritemode)
            {
                spriteMode.Paste();
            }
            else if (selectedMode == ObjectMode.Entrances)
            {
                entranceMode.Paste();
            }
        }

        public override void copy()
        {
            if (selectedMode == ObjectMode.Tile)
            {
                tilemode.Copy();
            }
            else if (selectedMode == ObjectMode.Exits)
            {
                exitmode.Copy();
            }
            else if (selectedMode == ObjectMode.Itemmode)
            {
                itemMode.Copy();
            }
            else if (selectedMode == ObjectMode.Spritemode)
            {
                spriteMode.Copy();
            }
            else if (selectedMode == ObjectMode.Entrances)
            {
                entranceMode.Copy();
            }
        }

        public override void cut()
        {
            if (selectedMode == ObjectMode.Exits)
            {
                exitmode.Cut();
            }
            else if (selectedMode == ObjectMode.Itemmode)
            {
                itemMode.Cut();
            }
            else if (selectedMode == ObjectMode.Spritemode)
            {
                spriteMode.Cut();
            }
            else if (selectedMode == ObjectMode.Entrances)
            {
                entranceMode.Cut();
            }
        }

        public void SaveTiles()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            if (!ow.createMap32Tilesmap())
            {
                ow.Save32Tiles();
                ow.savemapstorom();
                ow.SaveMap16Tiles();
            }
            Console.WriteLine("Overworld Save Elapsed Milliseconds : " + sw.ElapsedMilliseconds);
            sw.Stop();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            ColorMatrix cm = new ColorMatrix();
            ImageAttributes ia = new ImageAttributes();
            cm.Matrix33 = 0.50f;
            cm.Matrix22 = 2f;
            ia.SetColorMatrix(cm);
            g.CompositingMode = CompositingMode.SourceCopy;
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            //g.FillRectangle(Brushes.Green, new Rectangle(0, 0, 4096, 4096));

            /*
            for (int x = 0; x < 128; x++)
            {
                drawText(g, x * 32, 0, ow.map16tiles[x].tile0.ToString());
            }*/

            if (initialized)
            {

                int x = 0;
                int y = 0;
                for (int i = (0 + ow.worldOffset); i < 64 + (ow.worldOffset); i++)
                {
                    g.DrawImage(ow.allmaps[i].gfxBitmap, new PointF(x * 512, y * 512));
                    x++;
                    if (x >= 8)
                    {
                        x = 0;
                        y++;
                    }
                }

                g.CompositingMode = CompositingMode.SourceOver;

                /*for (int yP = 0; yP < 32; yP+=2)
                {
                    for (int xP = 0; xP < 32; xP+=2)
                    {
                        drawText(g, xP * 16, yP * 16, ow.tiles16[ow.allmapsTilesLW[xP, yP]].tile0.id.ToString(), ia);
                        drawText(g, (xP * 16)+8, (yP * 16), ow.tiles16[ow.allmapsTilesLW[xP+1, yP]].tile1.id.ToString(), ia);
                        drawText(g, (xP * 16), (yP * 16)+8, ow.tiles16[ow.allmapsTilesLW[xP, yP+1]].tile2.id.ToString(), ia);
                        drawText(g, (xP * 16)+8, (yP * 16)+8, ow.tiles16[ow.allmapsTilesLW[xP+1, yP+1]].tile3.id.ToString(), ia);
                    }
                }*/


                //g.DrawImage(ow.allmaps[136].gfxBitmap, new PointF(0, 0));

                /*for (int i = 0; i < 64; i++)
                {
                    foreach (Sprite spr in ow.allmaps[i].sprites)
                    {
                        int yy = spr.mapid / 8;
                        int xx = spr.mapid - (yy * 8);
                        drawText(g, (spr.x * 16) + (xx * 512), ((spr.y * 16) - 16) + (yy * 512), spr.name);
                    }
                }*/



                if (selecting)
                {
                    g.DrawRectangle(Pens.White, new Rectangle((globalmouseTileDownX * 16), (globalmouseTileDownY * 16), (((mouseX_Real / 16) - globalmouseTileDownX) * 16) + 16, (((mouseY_Real / 16) - globalmouseTileDownY) * 16) + 16));
                }


                if (selectedMode == ObjectMode.OWDoor || selectedMode == ObjectMode.Tile)
                {
                    g.DrawImage(tilesgfxBitmap, new Rectangle((mouseX_Real / 16) * 16, (mouseY_Real / 16) * 16, selectedTileSizeX * 16, (selectedTile.Length / selectedTileSizeX) * 16), 0, 0, selectedTileSizeX * 16, (selectedTile.Length / selectedTileSizeX) * 16, GraphicsUnit.Pixel, ia);
                    g.DrawRectangle(Pens.LightGreen, new Rectangle((mouseX_Real / 16) * 16, (mouseY_Real / 16) * 16, selectedTileSizeX * 16, (selectedTile.Length / selectedTileSizeX) * 16));
                }
                int my = (ow.allmaps[mapHover].parent / 8);
                int mx = ow.allmaps[mapHover].parent - (my * 8);
                if (ow.allmaps[mapHover].largeMap)
                {
                    g.DrawRectangle(Pens.Orange, new Rectangle(mx * 512, my * 512, 1024, 1024));
                }
                else
                {
                    g.DrawRectangle(Pens.Orange, new Rectangle(mx * 512, my * 512, 512, 512));
                }

                if (showExits)
                {
                    exitmode.Draw(g);
                }
                if (showEntrances)
                {
                    entranceMode.Draw(g);
                }
                if (showItems)
                {
                    itemMode.Draw(g);
                }
                g.CompositingMode = CompositingMode.SourceOver;
                if (showSprites)
                {
                    if (!hideText)
                    {
                        spriteMode.Draw(g);
                    }
                }

                if (showFlute)
                {
                    transportMode.Draw(g);
                }
                g.CompositingMode = CompositingMode.SourceCopy;
                hideText = false;
            }
        }






        bool clickedObject = false;

        public void ReLoadPalettes()
        {
            ow.allmaps[selectedMap].LoadPalette();
        }

        public override void deleteSelected()
        {


            if (selectedMode == ObjectMode.Itemmode)
            {
                itemMode.Delete();
            }
            else if (selectedMode == ObjectMode.Spritemode)
            {
                spriteMode.Delete();
            }
            else if (selectedMode == ObjectMode.Entrances)
            {
                entranceMode.Delete();
            }
            else if (selectedMode == ObjectMode.Exits)
            {
                exitmode.Delete();
            }

        }


        public void drawGrid(Graphics graphics)
        {
            /*if (showGrid)
            {
                //int s = mainForm.gridSize;
                int wh = (512 / s)+1;

                for (int x = 0; x < wh; x++)
                {
                    graphics.DrawLine(new Pen(Color.FromArgb(128, 255, 255, 255)), x * s, 0, x * s, 512);
                }
                for (int y = 0; y < wh; y++)
                {
                    graphics.DrawLine(new Pen(Color.FromArgb(128, 255, 255, 255)), 0, y * s, 512, y * s);
                }
            }*/
        }


        public void SetPalettesTransparent()
        {
            int pindex = 0;
            ColorPalette palettes = GFX.roomBg1Bitmap.Palette;
            for (int y = 0; y < GFX.loadedPalettes.GetLength(1); y++)
            {
                for (int x = 0; x < GFX.loadedPalettes.GetLength(0); x++)
                {
                    palettes.Entries[pindex] = GFX.loadedPalettes[x, y];
                    pindex++;
                }
            }

            for (int y = 0; y < GFX.loadedSprPalettes.GetLength(1); y++)
            {
                for (int x = 0; x < GFX.loadedSprPalettes.GetLength(0); x++)
                {
                    if (pindex < 256)
                    {
                        palettes.Entries[pindex] = GFX.loadedSprPalettes[x, y];
                        pindex++;
                    }
                }
            }

            for (int i = 0; i < 16; i++)
            {
                palettes.Entries[i * 16] = Color.Transparent;
                palettes.Entries[(i * 16) + 8] = Color.Transparent;
            }
            GFX.roomBg1Bitmap.Palette = palettes;
            GFX.roomBg2Bitmap.Palette = palettes;
            GFX.roomBgLayoutBitmap.Palette = palettes;
        }

        public void SetPalettesBlack()
        {
            int pindex = 0;
            ColorPalette palettes = GFX.roomBg1Bitmap.Palette;
            for (int y = 0; y < GFX.loadedPalettes.GetLength(1); y++)
            {
                for (int x = 0; x < GFX.loadedPalettes.GetLength(0); x++)
                {
                    palettes.Entries[pindex] = GFX.loadedPalettes[x, y];
                    pindex++;
                }
            }

            for (int i = 0; i < 16; i++)
            {
                palettes.Entries[i * 16] = Color.Black;
                palettes.Entries[(i * 16) + 8] = Color.Black;
            }
            GFX.roomBg1Bitmap.Palette = palettes;
            GFX.roomBg2Bitmap.Palette = palettes;
            GFX.roomBgLayoutBitmap.Palette = palettes;
        }


        
        private void onMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (selectedMode == ObjectMode.Entrances)
            {
                entranceMode.onMouseDoubleClick(e);
            }
        }
        

        public void objects_ResizeMouseMove(MouseEventArgs e)
        {
            
        }

        public void setMouseSizeMode(MouseEventArgs e)
        {
            
        }
        
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void chestpicker_Load(object sender, EventArgs e)
        {

        }

        private void pObj_Load(object sender, EventArgs e)
        {

        }
        
    }

}
