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
using System.IO;

namespace ZeldaFullEditor.Gui.MainTabs
{
    public partial class ScreenEditor : UserControl
    {
        public ScreenEditor()
        {
            
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        
        OAMTile[] oamData = new OAMTile[10];
        OAMTile selectedOamTile = null;
        OAMTile lastSelectedOamTile = null;
        byte[] mapdata = new byte[64 * 64];
        byte[] dwmapdata = new byte[64 * 64];
        int swordX = 0;
        public void Init()
        {
            tiles8Bitmap = new Bitmap(128, 512, 128, PixelFormat.Format8bppIndexed, tiles8Ptr);
            tilesBG1Bitmap = new Bitmap(256, 256, 256, PixelFormat.Format8bppIndexed, tilesBG1Ptr);
            tilesBG2Bitmap = new Bitmap(256, 256, 256, PixelFormat.Format8bppIndexed, tilesBG2Ptr);
            oamBGBitmap = new Bitmap(256, 256, 256, PixelFormat.Format8bppIndexed, oamBGPtr);

            Buildtileset();

            for (int i = 0; i<1024;i++)
            {
                tilesBG1Buffer[i] = 492;
                tilesBG2Buffer[i] = 492;
            }
            SetColorsPalette(Palettes.overworld_MainPalettes[5], Palettes.overworld_AnimatedPalettes[0],
                Palettes.overworld_AuxPalettes[3], Palettes.overworld_AuxPalettes[3],
                Palettes.HudPalettes[0], Color.FromArgb(0, 0, 0, 0), Palettes.spritesAux1_Palettes[1], Palettes.spritesAux1_Palettes[1]);


            int p = 0x54727;
            int p2 = 0x54727 + 0x400;
            int p3 = 0x54727 + 0x800;
            int p4 = 0x54727 + 0xC00;
            int p5 = 0x55727;
            bool rSide = false;
            int cSide = 0;
            int cInc = 0;
            int count = 0;
            while (count < 64 * 64)
            {
                if (count < 0x800)
                {
                    if (rSide == false)
                    {
                        mapdata[count] = ROM.DATA[p];
                        dwmapdata[count] = ROM.DATA[p];
                        p++;
                        if (cSide >= 31)
                        {
                            cSide = 0;
                            rSide = true;
                            count++;
                            continue;
                        }

                    }
                    else
                    {
                        mapdata[count] = ROM.DATA[p2];
                        dwmapdata[count] = ROM.DATA[p2];
                        p2++;
                        if (cSide >= 31)
                        {
                            cSide = 0;
                            rSide = false;
                            count++;
                            continue;
                        }
                    }
                }
                else
                {
                    if (rSide == false)
                    {
                        mapdata[count] = ROM.DATA[p3];
                        dwmapdata[count] = ROM.DATA[p3];
                        p3++;
                        if (cSide >= 31)
                        {
                            cSide = 0;
                            rSide = true;
                            count++;
                            continue;
                        }

                    }
                    else
                    {
                        mapdata[count] = ROM.DATA[p4];
                        dwmapdata[count] = ROM.DATA[p4];
                        p4++;
                        if (cSide >= 31)
                        {
                            cSide = 0;
                            rSide = false;
                            count++;
                            continue;
                        }
                    }
                }
                cSide++;
                count++;

            }
            count = 0;
            int line = 0;
            while(true)
            {
                dwmapdata[1040 + count+(line*64)] = ROM.DATA[p5];
                p5++;
                count++;
                if (count >= 32)
                {
                    count = 0;
                    line++;
                    if (line >= 32)
                    {
                        break;
                    }
                }
            }



            //palettes : 
            //Main5, Aux

            //Load Title Screen Data
            //Format : 
            //4 Bytes Header followed by "short tiles values"
            //byte 0 and 1 = Dest Address? Big Endian
            //byte 2 and 3 = Tile Count in Big Endian if 8XXX this is the last index
            //11 0B    00 19

            if ((ROM.DATA[0x67E92] & 0x01) == 0)
            {
                uppersprCheckbox.Checked = true;
            }
            else
            {
                uppersprCheckbox.Checked = false;
            }

            

            int xLowest = 256;
            for (int i = 0;i<10;i++)
            {
                oamData[i] = new OAMTile(ROM.DATA[0x67E26+i], (byte)(ROM.DATA[0x67E30+(i*2)]+22), ROM.DATA[0x67E1C+i], (byte)((ROM.DATA[0x67E92]>>1) & 0x07), uppersprCheckbox.Checked);
                if (ROM.DATA[0x67E26 + i] < xLowest)
                {
                    xLowest = ROM.DATA[0x67E26 + i];
                }
            }
            swordX = xLowest;
            //swordXPos = ROM.DATA[0x67E26];

            /*oamData[1] = new OAMTile(64, 54, 02, 00);
            oamData[2] = new OAMTile(48  ,62  ,32, 00);
            oamData[3] = new OAMTile(80  ,62  ,34, 00);
            oamData[4] = new OAMTile(64  ,70  ,04, 00);
            oamData[5] = new OAMTile(64  ,86  ,06, 00);
            oamData[6] = new OAMTile(64  ,102 ,08, 00);
            oamData[7] = new OAMTile(64  ,118 ,10, 00);
            oamData[8] = new OAMTile(64  ,134 ,12, 00);
            oamData[9] = new OAMTile(64  ,150 ,14, 00);*/
            int pos = (ROM.DATA[0x138C + 3] << 16) + (ROM.DATA[0x1383 + 3] << 8) + ROM.DATA[0x137A + 3];
            pos = Utils.SnesToPc(pos);
            while (true)
            {

                if ((ROM.DATA[pos] & 0x80) == 0x80)
                {
                    
                    break;
                }

                //Console.WriteLine(ROM.DATA[pos].ToString("X2") + " "+ ROM.DATA[pos+1].ToString("X2") + " "+ ROM.DATA[pos+2].ToString("X2") + " "+ ROM.DATA[pos+3].ToString("X2") + " ");
                ushort destAddr = (ushort)(ROM.ReadReverseShort(pos)); //$03 and $04
                pos += 2;
                short length = ROM.ReadReverseShort(pos);
                bool increment64 = ((length & 0x8000) == 0x8000 ? true : false);
                bool fixsource = ((length & 0x4000) == 0x4000 ? true : false);
                pos += 2;
                

                length = (short)((length & 0x07FF));
                
                int j = 0;
                int jj = 0;
                int posB = pos;
                while (j < (length/2)+1)
                {

                    ushort tiledata = (ushort)ROM.ReadShort(pos);
                    if (destAddr >= 0x1000)
                    {
                        //destAddr -= 0x1000;
                        if (destAddr < 0x2000)
                        {
                            tilesBG1Buffer[destAddr - 0x1000] = tiledata;
                        }
                    }
                    else
                    {
                        if (destAddr < 0x1000)
                        {
                            tilesBG2Buffer[destAddr] = tiledata;
                        }
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
            //label4.Text = count.ToString("X6");
            //label4.Text = "Break at position " + pos.ToString("X6");
            palSelected = (byte)(2);
            updateTiles();
            
        }


        public IntPtr tiles8Ptr = Marshal.AllocHGlobal(128 * 512);
        public Bitmap tiles8Bitmap;

        public ushort[] tilesBG1Buffer = new ushort[0x1000];
        public IntPtr tilesBG1Ptr = Marshal.AllocHGlobal(512*512);
        public Bitmap tilesBG1Bitmap;

        public ushort[] tilesBG2Buffer = new ushort[0x1000];
        public IntPtr tilesBG2Ptr = Marshal.AllocHGlobal(512*512);
        public Bitmap tilesBG2Bitmap;

        public IntPtr oamBGPtr = Marshal.AllocHGlobal(512 * 512);
        public Bitmap oamBGBitmap;
        

        public void Buildtileset()
        {
            byte[] staticgfx = new byte[16];

            //Main Blocksets

            for (int i = 0; i < 8; i++)
            {
                staticgfx[i] = ROM.DATA[Constants.overworldgfxGroups2 + (35 * 8) + i];
            }

            staticgfx[8] = 115 + 0;
            staticgfx[9] = (byte)(ROM.DATA[Constants.sprite_blockset_pointer + (125 * 4)+3] + 115);
            staticgfx[10] = 115 + 6;
            staticgfx[11] = 115 + 7;
            staticgfx[12] = (byte)(ROM.DATA[Constants.sprite_blockset_pointer + (125 * 4)] + 115);
            staticgfx[13] = (byte)(112);
            staticgfx[14] = (byte)(112);
            staticgfx[15] = (byte)(112);
            
            /*for (int i = 0; i < 4; i++)
            {
                
            }*/


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


        public void Buildtilesetmap()
        {
            byte[] staticgfx = new byte[16];

            //Main Blocksets

            for (int i = 0; i < 8; i++)
            {
                staticgfx[i] = 0;
            }

            staticgfx[8] = 115 + 0;
            staticgfx[9] = 115 + 5;
            staticgfx[10] = 115 + 6;
            staticgfx[11] = 115 + 7;
            staticgfx[12] = (byte)(112);
            staticgfx[13] = (byte)(112);
            staticgfx[14] = (byte)(112);
            staticgfx[15] = (byte)(112);

            /*for (int i = 0; i < 4; i++)
            {
                
            }*/


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
            if (editsprRadio.Checked)
            {
                e.Graphics.DrawRectangle(Pens.LimeGreen, new Rectangle(sx * 16, sy * 16, 32, 32));
            }
            else
            {
                e.Graphics.DrawRectangle(Pens.LimeGreen, new Rectangle(sx * 16, sy * 16, 16, 16));
            }
            
        }

        private void mirrorXCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            updateTiles();
        }

        public unsafe void DrawBGs(IntPtr destPtr, ushort[] tilesBgBuffer, bool onlyPrior = false)
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
                        if (onlyPrior)
                        {
                            if (t.o == 0)
                            {
                                continue;
                            }
                        }
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
        
        public unsafe void DrawSpr(IntPtr destPtr)
        {
            var alltilesData = (byte*)GFX.currentTileScreengfx16Ptr.ToPointer();
            byte* ptr = (byte*)destPtr.ToPointer();
            foreach(OAMTile t in oamData) //prevent draw if tile == 0xFFFF since it 0 indexed
            {
                for (var yl = 0; yl < 16; yl++)
                {
                    for (var xl = 0; xl < 8; xl++)
                    {
                        int ty = (t.tile / 16) * 512;
                        int tx = (t.tile % 16) * 4;
                        var pixel = alltilesData[(tx + ty) + (yl * 64) + xl];

                        int index = (t.x + (xl*2)) + (t.y * 256) + (yl*256);// + ((mx * 2) + (my * 256));

                        ptr[index + 1] = (byte)((pixel & 0x0F) + (t.pal+8) * 16);
                        ptr[index] = (byte)(((pixel >> 4) & 0x0F) + (t.pal+8) * 16);
                    }
                }
            }

        }

        public unsafe void ClearBG(IntPtr destPtr)
        {
            byte* ptr = (byte*)destPtr.ToPointer();
            for(int i = 0;i<(512*512);i++)
            {
                ptr[i] = 0;
            }
        }

            private void screenBox_Paint(object sender, PaintEventArgs e)
            {
            //e.Graphics.Clear(Color.Black);
            DrawBGs(tilesBG1Ptr, tilesBG1Buffer);
           
            DrawBGs(tilesBG2Ptr, tilesBG2Buffer);
            ClearBG(oamBGPtr);
            DrawSpr(oamBGPtr);

            

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            if (bg2Checkbox.Checked)
            {
                e.Graphics.DrawImage(tilesBG2Bitmap, new Rectangle(0, 0, 512, 512), new Rectangle(0, 0, 256, 256), GraphicsUnit.Pixel);
            }
            if (bg1checkbox.Checked)
            {
                e.Graphics.DrawImage(tilesBG1Bitmap, new Rectangle(0, 0, 512, 512), new Rectangle(0, 0, 256, 256), GraphicsUnit.Pixel);
            }
            
            if (oambgCheckbox.Checked)
            {
                e.Graphics.DrawImage(oamBGBitmap, new Rectangle(0, 0, 512, 512), new Rectangle(0, 0, 256, 256), GraphicsUnit.Pixel);
            }
            
            ClearBG(tilesBG1Ptr);
            DrawBGs(tilesBG1Ptr, tilesBG1Buffer, true);
            if (bg1checkbox.Checked)
            {
                e.Graphics.DrawImage(tilesBG1Bitmap, new Rectangle(0, 0, 512, 512), new Rectangle(0, 0, 256, 256), GraphicsUnit.Pixel);
            }

            if (editsprRadio.Checked)
            {
                if (lastSelectedOamTile != null)
                {
                    e.Graphics.DrawRectangle(Pens.LightGreen, new Rectangle((lastSelectedOamTile.x * 2), (lastSelectedOamTile.y * 2), 32, 32));
                }
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

            if (editsprRadio.Checked)
            {
                if (lastSelectedOamTile != null)
                {
                    lastSelectedOamTile.tile = selectedTile;
                    screenBox.Refresh();
                }
            }


        }
        bool mDown = false;
        byte lastX = 0;
        byte lastY = 0;
        int xIn = 0;
        int yIn = 0;
        bool swordSelected = false;
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
                if (movesprRadio.Checked)
                {
    
                    xIn = e.X - (swordX * 2);
                    swordSelected = true;
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

            if (editsprRadio.Checked)
            {
                int xP = (e.X / 2);
                int yP = (e.Y / 2);
                for (int i = 0; i < 10; i++)
                {
                    if (xP >= oamData[i].x && xP <= (oamData[i].x + 16) &&
                        yP >= oamData[i].y && yP <= (oamData[i].y + 16))
                    {
                        selectedOamTile = oamData[i];
                        break;
                    }
                }
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

                if (movesprRadio.Checked)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        oamData[i].x = (byte)(ROM.DATA[0x67E26 + i] + (e.X / 2) - swordX);
                       
                        screenBox.Refresh();
                    }
                    //swordX = (e.X / 2);
                    if (swordSelected)
                    {

                    }
                }

                if (editsprRadio.Checked)
                {
                    int xP = (e.X / 2);
                    int yP = (e.Y / 2);
                    /*for (int i = 0; i < 10; i++)
                    {
                        if (xP >= oamData[i].x && xP <= (oamData[i].x + 16) &&
                            yP >= oamData[i].y && yP <= (oamData[i].y + 16))
                        {
                            selectedOamTile = oamData[i];
                            break;
                        }
                    }*/
                    if (selectedOamTile != null)
                    {
                        if (lockCheckbox.Checked)
                        {
                            selectedOamTile.x = (byte)((xP / 8) * 8);
                            selectedOamTile.y = (byte)((yP / 8) * 8);
                        }
                        else
                        {
                            selectedOamTile.x = (byte)xP;
                            selectedOamTile.y = (byte)yP;
                        }
                    }

                    screenBox.Refresh();
                }


            }
        //selectedOamTile

    }

    private void screenBox_MouseUp(object sender, MouseEventArgs e)
        {
            mDown = false;
            if (selectedOamTile != null)
            {
                lastSelectedOamTile = selectedOamTile;
                selectedTile = lastSelectedOamTile.tile;
                palSelected = (byte)(lastSelectedOamTile.pal + 8);
                mirrorXCheckbox.Checked = lastSelectedOamTile.mx == 1 ? true : false;
                mirrorYCheckbox.Checked = lastSelectedOamTile.my == 1 ? true : false;
                updateTiles();
                paletteBox.Refresh();
                tilesBox.Refresh();
            }
            screenBox.Refresh();
            selectedOamTile = null;
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

            k = 0;
            for (int x = 1; x < 8; x++)
            {
                currentPalette[x + (16 * 8)] = Palettes.spritesAux1_Palettes[11][k];
                k++;
            }

            


            try
            {
                ColorPalette pal = tilesBG1Bitmap.Palette;
                for (int i = 0; i < 256; i++)
                {
                    pal.Entries[i] = currentPalette[i];
                    pal.Entries[i%16] = Color.Transparent;
                }
                GFX.currentTileScreengfx16Bitmap.Palette = pal;
                
                tilesBG1Bitmap.Palette = pal;
                tilesBG2Bitmap.Palette = pal;
                oamBGBitmap.Palette = pal;
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

            if (editsprRadio.Checked)
            {
                for(int i = 0;i<10;i++)
                {
                    oamData[i].pal = (byte)(palSelected - 8);
                }
            }
            screenBox.Refresh();
        }

        private void owMapTilesBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
           
            e.Graphics.DrawImage(GFX.overworldMapBitmap, new Rectangle(0,0,256,256));
            e.Graphics.DrawRectangle(Pens.LimeGreen, new Rectangle((selectedMapTile%16)*16, (selectedMapTile/16)*16, 16, 16));
        }
        bool v = false;


        bool darkWorld = false;
        public unsafe void DrawMapBG(IntPtr destPtr)
        {
            var alltilesData = (byte*)GFX.overworldMapPointer.ToPointer();
            byte* ptr = (byte*)destPtr.ToPointer();
            for (int yy = 0; yy < 64; yy++) //for each tile on the tile buffer
            {
                for (int xx = 0; xx < 64; xx++)
                {
                        for (var yl = 0; yl < 8; yl++)
                        {
                            for (var xl = 0; xl < 8; xl++)
                            {

                            byte tid = mapdata[xx + (yy * 64)];
                            if (darkWorld)
                            {
                                tid = dwmapdata[xx + (yy * 64)];
                            }
                                int ty = (tid / 16) * 1024;
                                int tx = (tid % 16) * 8;
                                var pixel = alltilesData[(tx + ty) + (yl * 128) + xl];

                                int index = (xx * 8) + (yy * 4096)+xl + (yl*512);
                                ptr[index] = (byte)((pixel));
                            }
                        }
                }
            }
        }


        
        int[] addresses = new int[]{ 0x53de4, 0x53e2c, 0x53e08, 0x53e50, 0x53e74, 0x53e98, 0x53ebc };
        int[] addressesgfx = new int[] { 0x53ee0, 0x53f04, 0x53ef2, 0x53f16, 0x53f28, 0x53f3a, 0x53f4c };
        private void mapPicturebox_Paint(object sender, PaintEventArgs e)
        {


            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

            DrawMapBG(GFX.owactualMapPointer);
            //DrawMapBGDW(GFX.owactualMapPointer);
            /*byte yData1 = (byte)((ROM.DATA[0x053DF6+ (comboBox1.SelectedIndex*2)]&0xF0) >> 4);
            byte yData2 = (byte)((ROM.DATA[0x053DF7+ (comboBox1.SelectedIndex * 2)] &0x0F) << 4);
            byte yData = (byte)(yData1 + yData2);

            byte xData1 = (byte)((ROM.DATA[0x053DE4+ (comboBox1.SelectedIndex * 2)] & 0xF0) >> 4);
            byte xData2 = (byte)((ROM.DATA[0x053DE5+ (comboBox1.SelectedIndex * 2)] & 0x0F) << 4);
            byte xData = (byte)(xData1 + xData2);*/
            e.Graphics.DrawImage(GFX.owactualMapBitmap, new Rectangle(0, 0, 1024, 1024), new Rectangle(0, 0, 512, 512), GraphicsUnit.Pixel);
            for (int i = 0; i < 7; i++)
            {
                short yPos = 0;
                short xPos = 0;
                if (comboBox1.SelectedIndex == 9)
                {
                    xPos = (short)((ROM.DATA[0x53763 + i] + (ROM.DATA[0x5376b + i] << 8)) >> 4);
                    yPos  = (short)((ROM.DATA[0x53773 + i] + (ROM.DATA[0x5377b + i] << 8)) >> 4);
                }
                else
                {

                    short xData = ROM.ReadRealShort(addresses[i] + comboBox1.SelectedIndex * 2);
                    if (xData < 0)
                    {
                        break;
                    }
                    xPos = (short)(xData >> 4);
                    short yData = ROM.ReadRealShort((addresses[i] + 18) + comboBox1.SelectedIndex * 2);
                    yPos = (short)(yData >> 4);
                    //rc->top = ((short*)(rom + wmmark_ofs[i] + 18))[b] >> 4

                }
                if (comboBox1.SelectedIndex != 9)
                {
                    short gfx = ROM.ReadRealShort(addressesgfx[i] + comboBox1.SelectedIndex * 2);

                    //e.Graphics.FillRectangle(Brushes.Fuchsia, new Rectangle(256 + (xPos * 2), 256 + (yPos * 2), 16, 16));
                    // e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), new Rectangle(256 + (xPos * 2), 256 + (yPos * 2), 16, 16));
                    if (gfx == 0) //red cross
                    {
                        e.Graphics.DrawImage(tiles8Bitmap, new Rectangle(256 + (xPos * 2), 256 + (yPos * 2), 16, 16), new Rectangle(64, 304, 8, 8), GraphicsUnit.Pixel);
                    }
                    else
                    {
                        GFX.drawText(e.Graphics, 256 + (xPos * 2), 256 + (yPos * 2), (i + 1).ToString(), null, true);
                    }
                }
                else
                {
                    GFX.drawText(e.Graphics, 256 + (xPos * 2), 256 + (yPos * 2), (i + 1).ToString(), null, true);
                }

                //GFX.drawText(e.Graphics, 256 + (xPos * 2), 256 + (yPos * 2), (i+1).ToString(),null, true);
                
            }




            

        }
        byte selectedMapTile = 0;
        private void mapPalettePicturebox_Paint(object sender, PaintEventArgs e)
        {
            for(int i = 0;i<256;i++)
            {
                e.Graphics.FillRectangle(new SolidBrush(GFX.overworldMapBitmap.Palette.Entries[i]), new Rectangle((i%16)*16, (i/16)*16, 16, 16));
                
            }
        }

        private void owMapTilesBox_MouseDown(object sender, MouseEventArgs e)
        {
            selectedMapTile = (byte)((e.X / 16) + ((e.Y / 16) * 16));
            owMapTilesBox.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {





        }

        public void Save()
        {
            for (int i = 0; i < 10; i++)
            {
                ROM.DATA[0x67E26 + i] = oamData[i].x;
                ROM.DATA[0x67E30 + (i * 2)] = (byte)(oamData[i].y - 22);
                if (uppersprCheckbox.Checked)
                {
                    ROM.DATA[0x67E1C + i] = (byte)(oamData[i].tile - 512);
                }
                else
                {
                    ROM.DATA[0x67E1C + i] = (byte)(oamData[i].tile - 768);
                }
            }


            //new position //PC:108000 / S:218000
            ROM.DATA[0x138C + 3] = 0x21;
            ROM.DATA[0x1383 + 3] = 0x80;
            ROM.DATA[0x137A + 3] = 0x00;

            //just do a full DMA of all tiles why not...
            //header bytes
            List<byte> allData = new List<byte>();
            allData.Add(0x10);
            allData.Add(0x00); //pos

            allData.Add(0x07); //length
            allData.Add(0xFF);

            for (int i = 0; i < 1024; i++)
            {
                allData.Add((byte)(tilesBG1Buffer[(i) + 0] & 0xFF));
                allData.Add((byte)((tilesBG1Buffer[(i)] & 0xFF00) >> 8));
            }

            allData.Add(0x00);
            allData.Add(0x00); //pos

            allData.Add(0x07); //length
            allData.Add(0xFF);

            for (int i = 0; i < 1024; i++)
            {
                allData.Add((byte)(tilesBG2Buffer[(i) + 0] & 0xFF));
                allData.Add((byte)((tilesBG2Buffer[(i)] & 0xFF00) >> 8));
            }

            allData.Add(0xFF);

            //label4.Text = allData.Count.ToString("X6");

            //TODO Move the upper sprite to a array as well there's space remaining at position 0x67FB1 - 0x67FFF

            if (uppersprCheckbox.Checked)
            {
                ROM.DATA[0x67E92] = (byte)(0x20 + ((oamData[0].pal << 1)));
            }
            else
            {
                ROM.DATA[0x67E92] = (byte)(0x21 + ((oamData[0].pal << 1)));
            }


            for (int i = 0; i < allData.Count; i++)
            {
                ROM.DATA[i + 0x108000] = allData[i];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            /*int pos = 0;
            while(pos < (64*64))
            {
                mapdata[pos] = ROM.DATA[p + pos];


                pos++;
            }*/




            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                if (darkWorld)
                {
                    fs.Write(dwmapdata, 0, (64 * 64));
                }
                else
                {
                    fs.Write(mapdata, 0, (64 * 64));
                }
                    
                fs.Close();
                //label4.Text = ;
               
                GFX.overworldMapBitmap.Save(Path.GetDirectoryName(Path.GetFullPath(sfd.FileName))+"Tileset.png");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mapPicturebox.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            darkWorld = !darkWorld;
            int offset = 0;
            if (darkWorld)
            {
                offset = 256;
            }
            ColorPalette cp = GFX.overworldMapBitmap.Palette;
            for (int i = 0; i < 256; i += 2)
            {
                //55B27 = US LW
                //55C27 = US DW
                cp.Entries[i / 2] = GFX.getColor((short)((ROM.DATA[0x55B27 + (i+offset) + 1] << 8) + ROM.DATA[0x55B27 + (i + offset)]));
                int k = 0;
                int j = 0;
                for (int y = 10; y < 14; y++)
                {
                    for (int x = 0; x < 15; x++)
                    {
                        cp.Entries[145+k] = Palettes.globalSprite_Palettes[0][j];
                        k++;
                        j++;
                    }
                    k++;
                }
            }
            
            GFX.overworldMapBitmap.Palette = cp;
            GFX.owactualMapBitmap.Palette = cp;
            Buildtilesetmap();
            mapPalettePicturebox.Refresh();
            mapPicturebox.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                if (darkWorld)
                {
                    fs.Read(dwmapdata, 0, (64 * 64));
                }
                else
                {
                    fs.Read(mapdata, 0, (64 * 64));
                }

                fs.Close();
            }
        }
    }
}
