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
        byte[] tempTiletype = new byte[0x200];

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

            if (gridcheckBox.Checked)
            {
                for (int xs = 0; xs < 16; xs++)
                {
                    e.Graphics.DrawLine(new Pen(Color.FromArgb(80, Color.White), 1), xs * 16, 0, xs * 16, 1024);

                }
                for (int ys = 0; ys < 256; ys++)
                {
                    e.Graphics.DrawLine(new Pen(Color.FromArgb(80, Color.White), 1), 0, ys * 16, 256, ys * 16);
                }
            }

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

            if (tile8selected >= 512)
            {
                tileTypeBox.Enabled = false;
            }
            else
            {

                tileTypeBox.Enabled = true;
                tileTypeBox.SelectedIndex = tempTiletype[tile8selected];
            }
        }

        private void pictureboxTile16_Paint(object sender, PaintEventArgs e)
        {
            
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.AssumeLinear;
            //e.Graphics.DrawImage(GFX.editortileBitmap, new Rectangle(0, 0, 64, 64));
            e.Graphics.DrawImage(GFX.mapblockset16Bitmap, new RectangleF(0f,0f,256.5f,16000f),new RectangleF(0,0,128, 8000),GraphicsUnit.Pixel);
            //e.Graphics.DrawImage(GFX.mapblockset16Bitmap, new RectangleF(256f, 0f, 256.5f, 8000f), new RectangleF(0, 4000, 128, 4000-192), GraphicsUnit.Pixel);
            if (gridcheckBox.Checked)
            {
                for (int x = 0; x < 16; x++)
                {
                    e.Graphics.DrawLine(new Pen(Color.FromArgb(80, Color.White), 1), x * 32, 0, x * 32, 8000);

                }
                for (int y = 0; y < 256; y++)
                {
                    e.Graphics.DrawLine(new Pen(Color.FromArgb(80, Color.White), 1), 0, y * 32, 256, y * 32);
                }
            }
            int xP = (scene.selectedTile[0] % 8) * 32;
            int yP = ((scene.selectedTile[0] / 8)) * 32;
            /*if (scene.selectedTile[0] >= 2000)
            {
                yP -= 8000;
                xP += 256;
            }*/
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(180, Color.Red), 1), new Rectangle(xP, yP, 32, 32));
            
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
            int yp = e.Y;
            if (e.X < 256)
            {
                offset = 0;
            }
            else
            {
                offset = 1992;
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
            tileTypeBox.SelectedIndex = tempTiletype[t.id];
            fromForm = false;

            updateTiles();
        }

        private unsafe void BuildTiles16Gfx()
        {

            var gfx16Data = (byte*)GFX.mapblockset16.ToPointer();//(byte*)allgfx8Ptr.ToPointer();
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
            for(int i = 0;i<0xFF;i++)
            {
                tilesTypesNames[i] = i.ToString("X2") + " - ????";
            }
            loadTilesNames();

            for (int i = 0;i<0x200;i++)
            {
                tempTiletype[i] = scene.ow.allTilesTypes[i];
            }

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

            for(int i = 0; i<0x200;i++)
            {
                scene.ow.allTilesTypes[i] = tempTiletype[i];
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

        private void tileTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fromForm == false)
            {
                tempTiletype[tile8selected] = (byte)tileTypeBox.SelectedIndex;
            }
        }

        public void loadTilesNames()
        {
            tilesTypesNames[0x00] = "0x00 - Normal tile(no interaction)";
            tilesTypesNames[0x01] = "0x01 - Blocked";
            tilesTypesNames[0x02] = "0x02 - Blocked)";
            tilesTypesNames[0x03] = "0x03 - Blocked";
            tilesTypesNames[0x05] = "0x05 - Normal tile(no interaction)";
            tilesTypesNames[0x06] = "0x06 - Normal tile(no interaction)";
            tilesTypesNames[0x07] = "0x07 - Normal tile(no interaction)";

            tilesTypesNames[0x08] = "0x08 - Deep Water";
            tilesTypesNames[0x09] = "0x09 - Shallow Water";

            tilesTypesNames[0x0C] = "0x0C - Moving Floor";
            tilesTypesNames[0x0D] = "0x0D - Sprite Floor";

            tilesTypesNames[0x1C] = "0x1C - Top of in room staircase";

            tilesTypesNames[0x20] = "0x20 - Hole Tile";
            tilesTypesNames[0x22] = "0x22 - Wooden steps(slow you down)";
            tilesTypesNames[0x27] = "0x27 - (empty chest and maybe others)";

            tilesTypesNames[0x28] = "0x28 - Ledge leading up";
            tilesTypesNames[0x29] = "0x29 - Ledge leading down";
            tilesTypesNames[0x2A] = "0x2A - Ledge leading left";
            tilesTypesNames[0x2B] = "0x2B - Ledge leading right";
            tilesTypesNames[0x2C] = "0x2C - Ledge leading up + left";
            tilesTypesNames[0x2D] = "0x2D - Ledge leading down + left";
            tilesTypesNames[0x2E] = "0x2E - Ledge leading up + right";
            tilesTypesNames[0x2F] = "0x2F - Ledge leading down + right";

            tilesTypesNames[0x40] = "0x40 - Grass Tile";
            tilesTypesNames[0x44] = "0x44 - Cactus Tile";
            tilesTypesNames[0x48] = "0x48 - aftermath tiles of picking things up?";
            tilesTypesNames[0x4A] = "0x4A - aftermath tiles of picking things up?";
            tilesTypesNames[0x4B] = "0x4B - Warp Tile";
            tilesTypesNames[0x4C] = "0x4C - Certain mountain tiles?";
            tilesTypesNames[0x4D] = "0x4D - Certain mountain tiles?";
            tilesTypesNames[0x4E] = "0x4E - Certain mountain tiles?";
            tilesTypesNames[0x4F] = "0x4F - Certain mountain tiles?";


            tilesTypesNames[0x50] = "0x50 - bush";
            tilesTypesNames[0x51] = "0x51 - off color bush";
            tilesTypesNames[0x52] = "0x52 - small light rock";
            tilesTypesNames[0x53] = "0x53 - small heavy rock";
            tilesTypesNames[0x54] = "0x54 - sign";
            tilesTypesNames[0x55] = "0x55 - large light rock";
            tilesTypesNames[0x56] = "0x56 - large heavy rock";

            tilesTypesNames[0x58] = "0x58 - Chest block";
            tilesTypesNames[0x59] = "0x59 - Chest block";
            tilesTypesNames[0x5A] = "0x5A - Chest block";
            tilesTypesNames[0x5B] = "0x5B - Chest block";
            tilesTypesNames[0x5C] = "0x5C - Chest block";
            tilesTypesNames[0x5D] = "0x5D - Chest block";

            tilesTypesNames[0x63] = "0x63 - Minigame chest tile";
            tilesTypesNames[0xB0] = "0xB0 - Hole Tile or Somaria?";

            tilesTypesNames[0xC0] = "0xC0 - Torch";
            tilesTypesNames[0xC1] = "0xC1 - Torch";
            tilesTypesNames[0xC2] = "0xC2 - Torch";
            tilesTypesNames[0xC3] = "0xC3 - Torch";
            tilesTypesNames[0xC4] = "0xC4 - Torch";
            tilesTypesNames[0xC5] = "0xC5 - Torch";
            tilesTypesNames[0xC6] = "0xC6 - Torch";
            tilesTypesNames[0xC7] = "0xC7 - Torch";
            tilesTypesNames[0xC8] = "0xC8 - Torch";
            tilesTypesNames[0xC9] = "0xC9 - Torch";
            tilesTypesNames[0xCA] = "0xCA - Torch";
            tilesTypesNames[0xCB] = "0xCB - Torch";
            tilesTypesNames[0xCC] = "0xCC - Torch";
            tilesTypesNames[0xCD] = "0xCD - Torch";
            tilesTypesNames[0xCE] = "0xCE - Torch";
            tilesTypesNames[0xCF] = "0xCF - Torch";

            tilesTypesNames[0xF0] = "0xF0 - Key door 1";
            tilesTypesNames[0xF1] = "0xF1 - Key door 2";

            tileTypeBox.Items.Clear();
            tileTypeBox.Items.AddRange(tilesTypesNames);
        }

        string[] tilesTypesNames = new string[0xFF];

        private void gridcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            pictureboxTile16.Refresh();
            pictureboxTile8.Refresh();
        }

        private void pictureboxTile8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            scene.mainForm.editorsTabControl.SelectedIndex = 2;
            scene.mainForm.gfxEditor.selectedSheet = scene.ow.allmaps[scene.selectedMap].staticgfx[(e.Y/64)];
            scene.mainForm.gfxEditor.allgfxPicturebox.Refresh();
            this.Close();
        }
    }
}
