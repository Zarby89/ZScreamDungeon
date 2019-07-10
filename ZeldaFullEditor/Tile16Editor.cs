using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
    public partial class Tile16Editor : Form
    {
        public Tile16Editor()
        {
            InitializeComponent();
        }
        public int editingTile = 0;
        public int tile8selected = 0;
        public int tileCount = 0;
        public SceneOW sceneOW;
        public TileInfo[] tinfos;
        private unsafe void Tile16Editor_Load(object sender, EventArgs e)
        {

            tinfos = sceneOW.ow.tiles16[editingTile].tilesinfos;
            updateTiles();
            updateTile16();
            this.Text = "Tile 16 Editor - Tile " + editingTile.ToString("D4");
            label3.Text = "That Tile is Used : " + tileCount.ToString();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void paletteTextbox_TextChanged(object sender, EventArgs e)
        {
            updateTiles();
        }

        private void mirrorXCheckbox_CheckStateChanged(object sender, EventArgs e)
        {
            updateTiles();
        }

        public unsafe void updateTiles()
        {
            byte p;
            ushort tempTile = 0;

            if (ushort.TryParse(tile8Textbox.Text, out tempTile))
            {
                tile8selected = tempTile;
            }
            if (byte.TryParse(paletteTextbox.Text, out p))
            {
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
                            CopyTile(x, y, xx, yy,i,p, destPtr, srcPtr);
                        }
                    }
                    xx += 8;
                    if (xx >= 128)
                    {
                        yy += 1024;
                        xx = 0;
                    }

                }
            }
            //Bitmap b = new Bitmap(128, 512, 64, System.Drawing.Imaging.PixelFormat.Format4bppIndexed, GFX.currentOWgfx16Ptr);
            GFX.editort16Bitmap.Palette = sceneOW.ow.allmaps[sceneOW.selectedMap].gfxBitmap.Palette;
            pictureboxTile8.Refresh();
        }
        //TODO: Add limit to palettes/tiles

        public unsafe void updateTile16()
        {
            byte p;
            if (byte.TryParse(paletteTextbox.Text, out p))
            {
                byte* destPtr = (byte*)GFX.editortilePtr.ToPointer();
                byte* srcPtr = (byte*)GFX.currentOWgfx16Ptr.ToPointer();
                int xx = 0;
                int yy = 0;
                int[] offsets = { 0, 8, 128, 136 };
                

                for (int i = 0; i < 4; i++)
                {
                    int offset = offsets[i];
                    for (var y = 0; y < 8; y++)
                    {
                        for (var x = 0; x < 4; x++)
                        {
                            CopyTile(x, y, xx, yy, tinfos[i],offset, destPtr, srcPtr);
                        }
                    }


                }
            }
            //Bitmap b = new Bitmap(128, 512, 64, System.Drawing.Imaging.PixelFormat.Format4bppIndexed, GFX.currentOWgfx16Ptr);
            GFX.editortileBitmap.Palette = sceneOW.ow.allmaps[sceneOW.selectedMap].gfxBitmap.Palette;
            pictureboxTile16.Refresh();
        }


        private unsafe void CopyTile(int x, int y, int xx, int yy, TileInfo tile,int offset, byte* gfx16Pointer, byte* gfx8Pointer)
        {
            int mx = x;
            int my = y;
            byte r = 0;

            if (tile.h)
            {
                mx = 3 - x;
                r = 1;
            }
            if (tile.v)
            {
                my = 7 - y;
            }

            int tx = ((tile.id / 16) * 512) + ((tile.id - ((tile.id / 16) * 16)) * 4);
            var index = xx + yy + offset + (mx * 2) + (my*16);
            var pixel = gfx8Pointer[tx + (y * 64) + x];

            gfx16Pointer[index + r ^ 1] = (byte)((pixel & 0x0F) + tile.palette * 16);
            gfx16Pointer[index + r] = (byte)(((pixel >> 4) & 0x0F) + tile.palette * 16);
        }


        private unsafe void CopyTile(int x, int y, int xx, int yy,int id,byte p, byte* gfx16Pointer, byte* gfx8Pointer)
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
            e.Graphics.DrawImage(GFX.editort16Bitmap, new Rectangle(0, 0, 512, 2048));

            int y = (tile8selected / 16);
            int x = tile8selected - (y * 16);

            e.Graphics.DrawRectangle(Pens.GreenYellow, new Rectangle(x*32, y*32, 32, 32));
        }

        private void pictureboxTile16_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            e.Graphics.DrawImage(GFX.editortileBitmap, new Rectangle(0, 0, 64, 64));
            e.Graphics.DrawLine(new Pen(Color.FromArgb(80,Color.White), 1), 32, 0, 32, 64);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(80, Color.White), 1), 0, 32, 64, 32);
        }


        private void updateTileInformation(int tile, MouseButtons e)
        {
            if (e == MouseButtons.Right)
            {
                mirrorXCheckbox.Checked = tinfos[tile].h;
                mirrorYCheckbox.Checked = tinfos[tile].v;
                infrontCheckbox.Checked = tinfos[tile].o;
                paletteTextbox.Text = tinfos[tile].palette.ToString();
                tile8Textbox.Text = tinfos[tile].id.ToString();
                updateTiles();
            }
            else if (e == MouseButtons.Left)
            {
                tinfos[tile].h = mirrorXCheckbox.Checked;
                tinfos[tile].v = mirrorYCheckbox.Checked;
                tinfos[tile].o = infrontCheckbox.Checked;
                byte p;
                ushort tempTile = 0;
                if (ushort.TryParse(tile8Textbox.Text, out tempTile))
                {
                    tinfos[tile].id = tempTile;
                }
                if (byte.TryParse(paletteTextbox.Text, out p))
                {
                    tinfos[tile].palette = p;
                }
                updateTile16();
            }

        }



        private void pictureboxTile16_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.X <= 32 && e.Y <= 32)
            {
                updateTileInformation(0, e.Button);
            }
            else if (e.X >= 32 && e.Y <= 32)
            {
                updateTileInformation(1, e.Button);
            }
            else if (e.X <= 32 && e.Y >= 32)
            {
                updateTileInformation(2, e.Button);
            }
            else if (e.X >= 32 && e.Y >= 32)
            {
                updateTileInformation(3, e.Button);
            }
        }

        private void pictureboxTile8_Click(object sender, EventArgs e)
        {

        }

        private void pictureboxTile8_MouseDown(object sender, MouseEventArgs e)
        {
            int x = (e.X / 32);
            int y = (e.Y / 32);
            
            tile8Textbox.Text = (x + (y * 16)).ToString();
            updateTiles();
            
        }
    }
}
