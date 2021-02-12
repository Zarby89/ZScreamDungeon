using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace ZeldaFullEditor.Gui.MainTabs
{
    public partial class ScreenEditor : UserControl
    {
        public ScreenEditor()
        {
            InitializeComponent();
        }

        public void Init()
        {
            tiles8Bitmap = new Bitmap(128, 512, 128, PixelFormat.Format8bppIndexed, tiles8Ptr);
            tilesBG1Bitmap = new Bitmap(256, 256, 256, PixelFormat.Format8bppIndexed, tilesBG1Ptr);
            tilesBG2Bitmap = new Bitmap(256, 256, 256, PixelFormat.Format8bppIndexed, tilesBG2Ptr);
            Buildtileset();

            for (int i = 0; i<1024;i++)
            {
                tilesBG1Buffer[i] = 492;
                tilesBG2Buffer[i] = 492;
            }
            SetColorsPalette(Palettes.overworld_MainPalettes[5], Palettes.overworld_AnimatedPalettes[0],
                Palettes.overworld_AuxPalettes[3], Palettes.overworld_AuxPalettes[3],
                Palettes.HudPalettes[0], Color.FromArgb(0, 0, 0, 0), Palettes.spritesAux1_Palettes[1], Palettes.spritesAux1_Palettes[1]);

            //palettes : 
            //Main5, Aux

            //Load Title Screen Data
            //Format : 
            //4 Bytes Header followed by "short tiles values"
            //byte 0 and 1 = Dest Address? Big Endian
            //byte 2 and 3 = Tile Count in Big Endian if 8XXX this is the last index
            //11 0B    00 19

            /*
            int pos = (ROM.DATA[0x138C + 3] << 16) + (ROM.DATA[0x1383 + 3] << 8) + ROM.DATA[0x137A + 3];
            pos = Utils.SnesToPc(pos);
            while (true)
            {

                if ((ROM.DATA[pos] & 0x80) == 0x80)
                {
                    break;
                }

                Console.WriteLine(ROM.DATA[pos].ToString("X2") + " "+ ROM.DATA[pos+1].ToString("X2") + " "+ ROM.DATA[pos+2].ToString("X2") + " "+ ROM.DATA[pos+3].ToString("X2") + " ");
                ushort destAddr = (ushort)(ROM.ReadReverseShort(pos)); //$03 and $04
                pos += 2;
                short length = ROM.ReadReverseShort(pos);
                bool increment64 = ((length & 0x8000) == 0x8000 ? true : false);
                bool fixsource = ((length & 0x4000) == 0x4000 ? true : false);
                pos += 2;

                

                length = (short)((length & 0x03FF));
                
                int j = 0;
                int jj = 0;
                int posB = pos;
                while (j < (length/2)+1)
                {

                    ushort tiledata = (ushort)ROM.ReadShort(pos);
                    if (destAddr >= 0x1000)
                    {
                        //destAddr -= 0x1000;
                        tilesBG1Buffer[destAddr-0x1000] = tiledata;
                    }
                    else
                    {
                        tilesBG2Buffer[destAddr] = tiledata;
                    }

                    if (increment64)
                    {
                        destAddr += 32;
                    }
                    else
                    {
                        destAddr += 1;
                    }
                    if (!fixsource)
                    {
                        pos += 2;
                    }
                    jj += 2;
                    j++;
                }
                if (fixsource)
                {
                    pos +=2;
                }
                else
                {
                    pos = posB + jj ;
                }




            }


            palSelected = (byte)(2);
            updateTiles();
            */
        }

        public IntPtr tiles8Ptr = Marshal.AllocHGlobal(128 * 512);
        public Bitmap tiles8Bitmap;

        public ushort[] tilesBG1Buffer = new ushort[1024];
        public IntPtr tilesBG1Ptr = Marshal.AllocHGlobal(512*512);
        public Bitmap tilesBG1Bitmap;

        public ushort[] tilesBG2Buffer = new ushort[1024];
        public IntPtr tilesBG2Ptr = Marshal.AllocHGlobal(512*512);
        public Bitmap tilesBG2Bitmap;

        public void Buildtileset()
        {
            byte[] staticgfx = new byte[16];

            //Main Blocksets

            for (int i = 0; i < 8; i++)
            {
                staticgfx[i] = ROM.DATA[Constants.overworldgfxGroups2 + (35 * 8) + i];
            }

            staticgfx[8] = 115 + 0;
            staticgfx[9] = 115 + 1;
            staticgfx[10] = 115 + 6;
            staticgfx[11] = 115 + 7;
            for (int i = 0; i < 4; i++)
            {
                staticgfx[12 + i] = (byte)(ROM.DATA[Constants.sprite_blockset_pointer + (125 * 4) + i] + 115);
            }


            unsafe
            {
                //NEED TO BE EXECUTED AFTER THE TILESET ARE LOADED NOT BEFORE -_-
                byte* currentmapgfx8Data = (byte*)GFX.currentTileScreengfx16Ptr.ToPointer();//loaded gfx for the current map (empty at this point)
                byte* allgfxData = (byte*)GFX.allgfx16Ptr.ToPointer(); //all gfx of the game pack of 2048 bytes (4bpp)
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 2048; j++)
                    {
                        byte mapByte = allgfxData[j + (staticgfx[i] * 2048)];
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
        byte palSelected = 0;
        ushort selectedTile = 0;
        public unsafe void updateTiles()
        {

            byte p;
            ushort tempTile = (ushort)selectedTile;


            selectedTile = tempTile;

            p = palSelected;
            byte* destPtr = (byte*)tiles8Ptr.ToPointer();
            byte* srcPtr = (byte*)GFX.currentTileScreengfx16Ptr.ToPointer();
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


            // updated bitmap palette here
            tiles8Bitmap.Palette = tilesBG1Bitmap.Palette;
            tilesBox.Refresh();




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

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(tiles8Bitmap, new Rectangle(0, 0, 256, 1024), new Rectangle(0, 0, 128, 512), GraphicsUnit.Pixel);
            int sx = selectedTile % 16;
            int sy = selectedTile / 16;
            e.Graphics.DrawRectangle(Pens.LimeGreen, new Rectangle(sx * 16, sy * 16, 16, 16));
        }

        private void mirrorXCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            updateTiles();
        }

        public unsafe void DrawBGs(IntPtr destPtr, ushort[] tilesBgBuffer)
        {
            var alltilesData = (byte*)GFX.currentTileScreengfx16Ptr.ToPointer();
            byte* ptr = (byte*)destPtr.ToPointer();
            for (int yy = 0; yy < 32; yy++) //for each tile on the tile buffer
            {
                for (int xx = 0; xx < 32; xx++)
                {
                    if (tilesBgBuffer[xx + (yy * 32)] != 0xFFFF) //prevent draw if tile == 0xFFFF since it 0 indexed
                    {
                        TileInfo t = GFX.gettilesinfo(tilesBgBuffer[xx + (yy * 32)]);
                        for (var yl = 0; yl < 8; yl++)
                        {
                            for (var xl = 0; xl < 4; xl++)
                            {
                                int mx = xl * (1 - t.h) + (3 - xl) * (t.h);
                                int my = yl * (1 - t.v) + (7 - yl) * (t.v);

                                int ty = (t.id / 16) * 512;
                                int tx = (t.id % 16) * 4;
                                var pixel = alltilesData[(tx + ty) + (yl * 64) + xl];

                                int index = (xx * 8) + (yy * 2048) + ((mx * 2) + (my * 256));
                                ptr[index + t.h ^ 1] = (byte)((pixel & 0x0F) + t.palette * 16);
                                ptr[index + t.h] = (byte)(((pixel >> 4) & 0x0F) + t.palette * 16);
                            }
                        }
                    }
                }
            }
        }

        private void screenBox_Paint(object sender, PaintEventArgs e)
        {
            DrawBGs(tilesBG1Ptr, tilesBG1Buffer);
            DrawBGs(tilesBG2Ptr, tilesBG2Buffer);
           
            
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            if (bg2Checkbox.Checked)
            {
                e.Graphics.DrawImage(tilesBG2Bitmap, new Rectangle(0, 0, 512, 512), new Rectangle(0, 0, 256, 256), GraphicsUnit.Pixel);
            }
            if (bg1checkbox.Checked)
            {
                e.Graphics.DrawImage(tilesBG1Bitmap, new Rectangle(0, 0, 512, 512), new Rectangle(0, 0, 256, 256), GraphicsUnit.Pixel);
            }

        }

        private void bg1checkbox_CheckedChanged(object sender, EventArgs e)
        {
            screenBox.Refresh();
        }

        private void tilesBox_MouseDown(object sender, MouseEventArgs e)
        {
            int sx = (e.X / 16);
            int sy = (e.Y / 16);
            selectedTile = (ushort)(sx + (sy * 16));
            tilesBox.Refresh();

        }
        bool mDown = false;
        byte lastX = 0;
        byte lastY = 0;
        private void screenBox_MouseDown(object sender, MouseEventArgs e)
        {
            lastX = (byte)(e.X / 16);
            lastY = (byte)(e.Y / 16);
            if (e.Button == MouseButtons.Left)
            {

                mDown = true;
                //Set Tile
                TileInfo t = new TileInfo(selectedTile, palSelected, (ushort)(mirrorYCheckbox.Checked ? 1 : 0), (ushort)(mirrorXCheckbox.Checked ? 1 : 0), (ushort)(onTopCheckbox.Checked ? 1 : 0));
                if (bg1Radio.Checked)
                {
                    tilesBG1Buffer[lastX + (lastY * 32)] = t.toShort();
                }
                else if (bg2Radio.Checked)
                {
                    tilesBG2Buffer[lastX + (lastY * 32)] = t.toShort();
                }

                screenBox.Refresh();

            }
            else if(e.Button == MouseButtons.Right)
            {
                TileInfo t = new TileInfo(0,0,0,0,0);
                if (bg1Radio.Checked)
                {
                    t= GFX.gettilesinfo(tilesBG1Buffer[lastX + (lastY * 32)]);

                }
                else if (bg2Radio.Checked)
                {
                    t = GFX.gettilesinfo(tilesBG2Buffer[lastX + (lastY * 32)]);
                }
                selectedTile = t.id;
                palSelected = t.palette;
                mirrorXCheckbox.Checked = t.h == 1 ? true : false;
                mirrorYCheckbox.Checked = t.v == 1 ? true : false;
                onTopCheckbox.Checked = t.o == 1 ? true : false;
                updateTiles();
                paletteBox.Refresh();
                tilesBox.Refresh();
                //Copy Tile
            }
        }

        private void screenBox_MouseMove(object sender, MouseEventArgs e)
        {
            byte mX = (byte)(e.X / 16);
            byte mY = (byte)(e.Y / 16);
            if (mDown == true)
            {
                if (mX != lastX || mY != lastY)
                {
                    //Set Tile
                    TileInfo t = new TileInfo(selectedTile, palSelected, (ushort)(mirrorYCheckbox.Checked ? 1 : 0), (ushort)(mirrorXCheckbox.Checked ? 1 : 0), (ushort)(onTopCheckbox.Checked ? 1 : 0));
                    if (bg1Radio.Checked)
                    {
                        tilesBG1Buffer[mX + (mY * 32)] = t.toShort();
                    }
                    else if (bg2Radio.Checked)
                    {
                        tilesBG2Buffer[mX + (mY * 32)] = t.toShort();
                    }

                    screenBox.Refresh();

                    lastX = mX;
                    lastY = mY;
                }
            }


        }

        private void screenBox_MouseUp(object sender, MouseEventArgs e)
        {
            mDown = false;
        }


        Color[] currentPalette = new Color[256];
        private void SetColorsPalette(Color[] main, Color[] animated, Color[] aux1, Color[] aux2, Color[] hud, Color bgrcolor, Color[] spr, Color[] spr2)
        {
            //Palettes infos, color 0 of a palette is always transparent (the arrays contains 7 colors width wide)
            //there is 16 color per line so 16*Y

            //Left side of the palette - Main, Animated
            
            //Main Palette, Location 0,2 : 35 colors [7x5]
            int k = 0;
            for (int y = 2; y < 7; y++)
            {
                for (int x = 1; x < 8; x++)
                {
                    currentPalette[x + (16 * y)] = main[k];
                    k++;
                }
            }

            //Animated Palette, Location 0,7 : 7colors
            for (int x = 1; x < 8; x++)
            {
                currentPalette[(16 * 7) + (x)] = animated[(x - 1)];
            }


            //Right side of the palette - Aux1, Aux2 

            //Aux1 Palette, Location 8,2 : 21 colors [7x3]
            k = 0;
            for (int y = 2; y < 5; y++)
            {
                for (int x = 9; x < 16; x++)
                {
                    currentPalette[x + (16 * y)] = aux1[k];
                    k++;
                }
            }

            //Aux2 Palette, Location 8,5 : 21 colors [7x3]
            k = 0;
            for (int y = 5; y < 8; y++)
            {
                for (int x = 9; x < 16; x++)
                {
                    currentPalette[x + (16 * y)] = aux2[k];
                    k++;
                }
            }

            //Hud Palette, Location 0,0 : 32 colors [16x2]
            k = 0;
            for (int i = 0; i < 32; i++)
            {
                currentPalette[i] = hud[i];
            }

            //Hardcoded grass color (that might change to become invisible instead)
            for (int i = 0; i < 8; i++)
            {
                currentPalette[(i * 16)] = bgrcolor;
                currentPalette[(i * 16) + 8] = bgrcolor;
            }


            //Sprite Palettes
            k = 0;
            for (int y = 8; y < 9; y++)
            {
                for (int x = 1; x < 8; x++)
                {
                    currentPalette[x + (16 * y)] = Palettes.spritesAux1_Palettes[1][k];
                    k++;
                }
            }

            //Sprite Palettes
            k = 0;
            for (int y = 8; y < 9; y++)
            {
                for (int x = 9; x < 16; x++)
                {
                    currentPalette[x + (16 * y)] = Palettes.spritesAux3_Palettes[0][k];
                    k++;
                }
            }


            //Sprite Palettes
            k = 0;
            for (int y = 9; y < 13; y++)
            {
                for (int x = 1; x < 16; x++)
                {
                    currentPalette[x + (16 * y)] = Palettes.globalSprite_Palettes[0][k];
                    k++;
                }
            }



            //Sprite Palettes
            k = 0;
            for (int y = 13; y < 14; y++)
            {
                for (int x = 1; x < 8; x++)
                {
                    currentPalette[x + (16 * y)] = spr[k];
                    k++;
                }
            }

            //Sprite Palettes
            k = 0;
            for (int y = 14; y < 15; y++)
            {
                for (int x = 1; x < 8; x++)
                {
                    currentPalette[x + (16 * y)] = spr2[k];
                    k++;
                }
            }

            //Sprite Palettes
            k = 0;
            for (int y = 15; y < 16; y++)
            {
                for (int x = 1; x < 16; x++)
                {
                    currentPalette[x + (16 * y)] = Palettes.armors_Palettes[0][k];
                    k++;
                }
            }


            try
            {
                ColorPalette pal = tilesBG1Bitmap.Palette;
                for (int i = 0; i < 256; i++)
                {
                    pal.Entries[i] = currentPalette[i];
                }
                GFX.currentTileScreengfx16Bitmap.Palette = pal;
                
                tilesBG1Bitmap.Palette = pal;
                tilesBG2Bitmap.Palette = pal;
            }
            catch (Exception e)
            {

            }
        }

        private void paletteBox_Paint(object sender, PaintEventArgs e)
        {
            for(int i = 0;i<256;i++)
            {
                int x = i % 16;
                int y = i / 16;
                e.Graphics.FillRectangle(new SolidBrush(currentPalette[i]), new Rectangle(x*16, y*16, 16, 16));

            }
            e.Graphics.DrawRectangle(Pens.LimeGreen, new Rectangle(0, 16*palSelected, 256, 16));
        }

        private void paletteBox_MouseDown(object sender, MouseEventArgs e)
        {
            palSelected = (byte)(e.Y / 16);
            paletteBox.Refresh();
            updateTiles();
        }
    }
}
