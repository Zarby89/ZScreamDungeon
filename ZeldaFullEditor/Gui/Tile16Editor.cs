using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui
{
    public partial class Tile16Editor : Form
    {
        public Tile16Editor(SceneOW scene)
        {
            this.scene = scene;
            InitializeComponent();
        }
        SceneOW scene;
        ushort tile8selected = 0;
        bool fromForm = false;
        public unsafe void updateTiles()
        {
            
            byte p;
            ushort tempTile = (ushort)tileUpDown.Value;

            
            tile8selected = tempTile;

            p = (byte)paletteUpDown.Value;
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
            pictureboxTile8.Refresh();

            
        }

        private unsafe void CopyTile(int x, int y, int xx, int yy, TileInfo tile, int offset, byte* gfx16Pointer, byte* gfx8Pointer)
        {
            int mx = x;
            int my = y;
            byte r = 0;

            if (tile.h != 0)
            {
                mx = 3 - x;
                r = 1;
            }
            if (tile.v != 0)
            {
                my = 7 - y;
            }

            int tx = ((tile.id / 16) * 512) + ((tile.id - ((tile.id / 16) * 16)) * 4);
            var index = xx + yy + offset + (mx * 2) + (my * 16);
            var pixel = gfx8Pointer[tx + (y * 64) + x];

            gfx16Pointer[index + r ^ 1] = (byte)((pixel & 0x0F) + tile.palette * 16);
            gfx16Pointer[index + r] = (byte)(((pixel >> 4) & 0x0F) + tile.palette * 16);
        }

        private unsafe void CopyTile(int x, int y, int xx, int yy, int id, byte p, byte* gfx16Pointer, byte* gfx8Pointer)
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
            var index = xx + yy + (mx * 2) + (my * 128);
            var pixel = gfx8Pointer[tx + (y * 64) + x];

            gfx16Pointer[index + r ^ 1] = (byte)((pixel & 0x0F) + p * 16);
            gfx16Pointer[index + r] = (byte)(((pixel >> 4) & 0x0F) + p * 16);
        }

        private void pictureboxTile8_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            e.Graphics.DrawImage(GFX.editort16Bitmap, new Rectangle(0, 0, 256, 1024));

            int y = (tile8selected / 16);
            int x = tile8selected - (y * 16);

            e.Graphics.DrawRectangle(Pens.GreenYellow, new Rectangle(x * 16, y * 16, 16, 16));
        }

        private void mirrorXCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (fromForm == false)
            {
                updateTiles();
            }
        }

        private void pictureboxTile16_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.AssumeLinear;
            //e.Graphics.DrawImage(GFX.editortileBitmap, new Rectangle(0, 0, 64, 64));
            e.Graphics.DrawImage(scene.ow.allmaps[scene.selectedMap].blocksetBitmap,new RectangleF(0f,0f,256.5f,7200f),new RectangleF(0,0,128,3600),GraphicsUnit.Pixel);
            e.Graphics.DrawImage(scene.ow.allmaps[scene.selectedMap].blocksetBitmap, new RectangleF(256f, 0f, 256.5f, 7200f), new RectangleF(0, 3600, 128, 3600), GraphicsUnit.Pixel);
            //e.Graphics.DrawLine(new Pen(Color.FromArgb(80, Color.White), 1), 32, 0, 32, 64);
            //e.Graphics.DrawLine(new Pen(Color.FromArgb(80, Color.White), 1), 0, 32, 64, 32);
        }

        private void pictureboxTile8_MouseDown(object sender, MouseEventArgs e)
        {
            int tid = (e.X / 16) + ((e.Y / 16) * 16);
            tileUpDown.Value = tid;
        }


        private void pictureboxTile16_MouseDown(object sender, MouseEventArgs e)
        {
            int offset = 0;
            if (e.X < 256)
            {
                offset = 0;
            }
            else
            {
                offset = 1792;
            }
            int t16 = offset + (e.X / 32) + ((e.Y / 32) * 8);
            int t8x = (e.X / 16) & 0x01;
            int t8y = (e.Y / 16) & 0x01;
            int t8i = 0;


            if (e.Button == MouseButtons.Left)
            {
                TileInfo t = new TileInfo(tile8selected, (byte)paletteUpDown.Value, (ushort)(mirrorYCheckbox.Checked ? 1 : 0), (ushort)(mirrorXCheckbox.Checked ? 1 : 0), (ushort)(inFrontCheckbox.Checked ? 1 : 0));
                if (t8x == 0 && t8y == 0)
                {
                    allTiles[t16] = new Tile16(t, allTiles[t16].tile1, allTiles[t16].tile2, allTiles[t16].tile3);
                }
                else if (t8x == 1 && t8y == 0)
                {
                    allTiles[t16] = new Tile16(allTiles[t16].tile0, t, allTiles[t16].tile2, allTiles[t16].tile3);
                }
                else if (t8x == 0 && t8y == 1)
                {
                    allTiles[t16] = new Tile16(allTiles[t16].tile0, allTiles[t16].tile1, t, allTiles[t16].tile3);
                }
                else if (t8x == 1 && t8y == 1)
                {
                    allTiles[t16] = new Tile16(allTiles[t16].tile0, allTiles[t16].tile1, allTiles[t16].tile2, t);
                }



                BuildTiles16Gfx();
                pictureboxTile16.Refresh();
            }
            else
            {
                if (t8x == 0 && t8y == 0)
                {
                    updateTileInfoFrom16(allTiles[t16].tile0);
                }
                else if (t8x == 1 && t8y == 0)
                {
                    updateTileInfoFrom16(allTiles[t16].tile1);
                }
                else if (t8x == 0 && t8y == 1)
                {
                    updateTileInfoFrom16(allTiles[t16].tile2);
                }
                else if (t8x == 1 && t8y == 1)
                {
                    updateTileInfoFrom16(allTiles[t16].tile3);
                }
            }
        }

        private void updateTileInfoFrom16(TileInfo t)
        {
            fromForm = true;
            tileUpDown.Value = t.id;
            paletteUpDown.Value = t.palette;
            mirrorXCheckbox.Checked = (t.h == 1 ? true : false);
            mirrorYCheckbox.Checked = (t.v == 1 ? true : false);
            inFrontCheckbox.Checked = (t.o == 1 ? true : false);
            fromForm = false;
            updateTiles();
        }

        private unsafe void BuildTiles16Gfx()
        {

            var gfx16Data = (byte*)scene.ow.allmaps[scene.selectedMap].blockset16.ToPointer();//(byte*)allgfx8Ptr.ToPointer();
            var gfx8Data = (byte*)GFX.currentOWgfx16Ptr.ToPointer();//(byte*)allgfx16Ptr.ToPointer();
            int[] offsets = { 0, 8, 1024, 1032 };
            var yy = 0;
            var xx = 0;

            for (var i = 0; i < 4096; i++) //number of tiles16 3748?
            {
                //8x8 tile draw
                //gfx8 = 4bpp so everyting is /2
                var tiles = allTiles[i];

                for (var tile = 0; tile < 4; tile++)
                {
                    TileInfo info = tiles.tilesinfos[tile];
                    int offset = offsets[tile];

                    for (var y = 0; y < 8; y++)
                    {
                        for (var x = 0; x < 4; x++)
                        {
                            CopyTile16(x, y, xx, yy, offset, info, gfx16Data, gfx8Data);
                        }
                    }
                }

                xx += 16;
                if (xx >= 128)
                {
                    yy += 2048;
                    xx = 0;
                }
            }



        }

        private unsafe void CopyTile16(int x, int y, int xx, int yy, int offset, TileInfo tile, byte* gfx16Pointer, byte* gfx8Pointer)//map,current
        {
            int mx = x;
            int my = y;
            byte r = 0;

            if (tile.h != 0)
            {
                mx = 3 - x;
                r = 1;
            }
            if (tile.v != 0)
            {
                my = 7 - y;
            }

            int tx = ((tile.id / 16) * 512) + ((tile.id - ((tile.id / 16) * 16)) * 4);
            var index = xx + yy + offset + (mx * 2) + (my * 128);
            var pixel = gfx8Pointer[tx + (y * 64) + x];

            gfx16Pointer[index + r ^ 1] = (byte)((pixel & 0x0F) + tile.palette * 16);
            gfx16Pointer[index + r] = (byte)(((pixel >> 4) & 0x0F) + tile.palette * 16);
        }


        Tile16[] allTiles = new Tile16[4096];
        private void Tile16Editor_Load(object sender, EventArgs e)
        {
            scene.ow.tiles16.CopyTo(allTiles);

            unsafe
            {
                //update gfx to be on selected map
                byte* currentmapgfx8Data = (byte*)GFX.currentOWgfx16Ptr.ToPointer();//loaded gfx for the current map (empty at this point)
                byte* allgfxData = (byte*)GFX.allgfx16Ptr.ToPointer(); //all gfx of the game pack of 2048 bytes (4bpp)
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 2048; j++)
                    {
                        byte mapByte = allgfxData[j + (scene.ow.allmaps[scene.selectedMap].staticgfx[i] * 2048)];
                        switch (i)
                        {
                            case 0:
                            case 3:
                            case 4:
                            case 5:
                                mapByte += 0x88;
                                break;
                        }

                        currentmapgfx8Data[(i * 2048) + j] = mapByte; //Upload used gfx data
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4096; i++)
            {
                scene.ow.tiles16[i] = allTiles[i];
            }

            for(int i = 0; i<159;i++)
            {
                scene.ow.allmaps[i].needRefresh = true;
            }

            scene.ow.allmaps[scene.selectedMap].BuildMap();
            scene.ow.allmaps[scene.selectedMap].needRefresh = false;

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
