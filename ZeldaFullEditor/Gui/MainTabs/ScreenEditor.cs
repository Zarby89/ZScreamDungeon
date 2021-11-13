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
using ZeldaFullEditor.Properties;
using System.Globalization;
using System.Diagnostics;
using ZeldaFullEditor.Data;

namespace ZeldaFullEditor.Gui.MainTabs
{
    public partial class ScreenEditor : UserControl
    {
        public ScreenEditor()
        {
            
            InitializeComponent();
            overworldCombobox.SelectedIndex = 0;
        }

        Point3D[] triforceVertices = new Point3D[6];
        Point3D[] crystalVertices = new Point3D[6];
        Point3D selectedVertice = null;
        OAMTile[] oamData = new OAMTile[10];
        OAMTile selectedOamTile = null;
        OAMTile lastSelectedOamTile = null;
        byte[] mapdata = new byte[64 * 64];
        byte[] dwmapdata = new byte[64 * 64];
        int swordX = 0;
        public void Init()
        {

            //triforce
            for(int i = 0;i<6;i++)
            {
                triforceVertices[i] = new Point3D(
                (sbyte)ROM.DATA[Constants.triforceVertices+0 +(i*3)],
                (sbyte)ROM.DATA[Constants.triforceVertices + 1 + (i * 3)],
                (sbyte)ROM.DATA[Constants.triforceVertices + 2 + (i * 3)]
                );

                crystalVertices[i] = new Point3D(
                (sbyte)ROM.DATA[Constants.crystalVertices + 0 + (i * 3)],
                (sbyte)ROM.DATA[Constants.crystalVertices + 1 + (i * 3)],
                (sbyte)ROM.DATA[Constants.crystalVertices + 2 + (i * 3)]
                );
            }


            tiles8Bitmap = new Bitmap(128, 512, 128, PixelFormat.Format8bppIndexed, tiles8Ptr);
            dungmaptiles8Bitmap = new Bitmap(128, 128, 128, PixelFormat.Format8bppIndexed, dungmaptiles8Ptr);
            dungmaptiles16Bitmap = new Bitmap(256, 192, 256, PixelFormat.Format8bppIndexed, dungmaptiles16Ptr);
            tilesBG1Bitmap = new Bitmap(256, 256, 256, PixelFormat.Format8bppIndexed, tilesBG1Ptr);
            tilesBG2Bitmap = new Bitmap(256, 256, 256, PixelFormat.Format8bppIndexed, tilesBG2Ptr);
            oamBGBitmap = new Bitmap(256, 256, 256, PixelFormat.Format8bppIndexed, oamBGPtr);
            floorSelector = new Bitmap(Resources.floorselector); ;
            Buildtileset();
            AssembleMapTiles();
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
            LoadTitleScreen();

            LoadOverworldMap();

            LoadDungeonMaps();

            LoadAllMapIcons();
            dungmapListbox.SelectedIndex = 0;



        }


        public void LoadOverworldMap()
        {

        }

        public void LoadTitleScreen(bool JP = false)
        {
            int pos = (ROM.DATA[0x138C + 3] << 16) + (ROM.DATA[0x1383 + 3] << 8) + ROM.DATA[0x137A + 3];

            for(int i =0;i<1024;i++)
            {
                tilesBG1Buffer[i] = 492;
                tilesBG2Buffer[i] = 492;
            }

            pos = Utils.SnesToPc(pos);
            if (JP)
            {
                pos = 0x065CC7;
            }
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
                while (j < (length / 2) + 1)
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

                    pos += 2;
                }
                else
                {
                    pos = posB + jj;
                }




            }
            //label4.Text = count.ToString("X6");
            //label4.Text = "Break at position " + pos.ToString("X6");
            palSelected = (byte)(2);
            updateTiles();
        }



        public IntPtr dungmaptiles8Ptr = Marshal.AllocHGlobal(0x8000);
        public Bitmap dungmaptiles8Bitmap;

        public IntPtr dungmaptiles16Ptr = Marshal.AllocHGlobal(0x20000);
        public Bitmap dungmaptiles16Bitmap;

        public IntPtr tiles8Ptr = Marshal.AllocHGlobal(0x20000);
        public Bitmap tiles8Bitmap;

        public ushort[] tilesBG1Buffer = new ushort[0x1000];
        public IntPtr tilesBG1Ptr = Marshal.AllocHGlobal(0x80000);
        public Bitmap tilesBG1Bitmap;

        public ushort[] tilesBG2Buffer = new ushort[0x1000];
        public IntPtr tilesBG2Ptr = Marshal.AllocHGlobal(0x80000);
        public Bitmap tilesBG2Bitmap;

        public IntPtr oamBGPtr = Marshal.AllocHGlobal(0x80000);
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

            ColorPalette cp = GFX.overworldMapBitmap.Palette;
            for (int i = 128; i < 256; i++)
            {
                cp.Entries[i] = currentPalette[i];
            }

            for (int i = 0; i < 80; i++)
            {
                cp.Entries[i + 32] = GFX.getColor(ROM.ReadRealShort(0xDE544 + (i * 2)));
                if ((i % 16) == 0)
                {
                    cp.Entries[i + 32] = Color.Transparent;
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


        private unsafe void CopyTile(int x, int y, int xx, int yy, int id, byte p,bool v, bool h, byte* gfx16Pointer, byte* gfx8Pointer)
        {
            int mx = x;
            int my = y;
            byte r = 0;

            if (h)
            {
                mx = 3 - x;
                r = 1;
            }
            if (v)
            {
                my = 7 - y;
            }

            int tx = ((id / 16) * 512) + ((id - ((id / 16) * 16)) * 4);
            var index = xx + yy + (mx * 2) + (my * 256);
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
                    for (int i = 0; i < 10; i++)
                    {
                        if (xP >= oamData[i].x && xP <= (oamData[i].x + 16) &&
                            yP >= oamData[i].y && yP <= (oamData[i].y + 16))
                        {
                            selectedOamTile = oamData[i];
                            break;
                        }
                    }
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
                    if ((i % 16) == 0)
                    {
                        pal.Entries[i] = Color.Transparent;
                    }
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

        List<MapIcon>[] allMapIcons = new List<MapIcon>[10];

        
        int[] addresses = new int[]{ 0x53de4, 0x53e2c, 0x53e08, 0x53e50, 0x53e74, 0x53e98, 0x53ebc };
        int[] addressesgfx = new int[] { 0x53ee0, 0x53f04, 0x53ef2, 0x53f16, 0x53f28, 0x53f3a, 0x53f4c };

        public void LoadAllMapIcons()
        {

            for (int e = 0; e < 10; e++)
            {
                allMapIcons[e] = new List<MapIcon>();
                for (int i = 0; i < 8; i++)
                {

                    short yPos = 0;
                    short xPos = 0;
                    if (e == 9)
                    {
                        xPos = (short)((ROM.DATA[0x53763 + i] + (ROM.DATA[0x5376b + i] << 8)) >> 4);
                        yPos = (short)((ROM.DATA[0x53773 + i] + (ROM.DATA[0x5377b + i] << 8)) >> 4);
                    }
                    else
                    {
                        if (i == 7)
                        {
                            break;
                        }
                        short xData = ROM.ReadRealShort(addresses[i] + e * 2);
                        if (xData < 0)
                        {
                            break;
                        }
                        xPos = (short)(xData >> 4);
                        short yData = ROM.ReadRealShort((addresses[i] + 18) + e * 2);
                        yPos = (short)(yData >> 4);
                        //rc->top = ((short*)(rom + wmmark_ofs[i] + 18))[b] >> 4

                    }
                    short gfx = 0;
                    if (e != 9)
                    {
                        gfx = ROM.ReadRealShort(addressesgfx[i] + e * 2);
                    }

                    allMapIcons[e].Add(new MapIcon(xPos, yPos, (ushort)gfx));
                }
            }

        }


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
            //for (int i = 0; i < 8; i++)
            //{

            for (int i = 0; i < allMapIcons[overworldCombobox.SelectedIndex].Count; i++)
            {
                int xpos = 256 + (allMapIcons[overworldCombobox.SelectedIndex][i].x * 2);
                int ypos = 256 + (allMapIcons[overworldCombobox.SelectedIndex][i].y * 2);
                if (allMapIcons[overworldCombobox.SelectedIndex][i] == selectedMapIcon)
                {
                    e.Graphics.FillRectangle(Brushes.Teal, new Rectangle(xpos, ypos, 24, 24));
                    e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), new Rectangle(xpos, ypos, 24, 24));
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.Yellow, new Rectangle(xpos, ypos, 24, 24));
                    e.Graphics.DrawRectangle(new Pen(Brushes.Black, 2), new Rectangle(xpos, ypos, 24, 24));
                }
                GFX.drawText(e.Graphics, xpos+6, ypos+4, (i + 1).ToString(), null, true);

            }

                
                
            //}




            

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
            }
            */



            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "all *.bin |*.bin";
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
               
                GFX.overworldMapBitmap.Save(sfd.FileName + "_Tileset.png");
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
            ofd.Filter =  "all *.bin |*.bin";
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

        public bool saveOverworldMap()
        {
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
                        ROM.DATA[p] = mapdata[count];
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
                        ROM.DATA[p2] = mapdata[count] ;
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
                        ROM.DATA[p3] = mapdata[count];
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
                        ROM.DATA[p4] = mapdata[count];
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
            while (true)
            {
                ROM.DATA[p5] = dwmapdata[1040 + count + (line * 64)];
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

            for (int e = 0; e < 10; e++)
            {
                
                for (int i = 0; i < 8; i++)
                {

                    if (allMapIcons[e].Count <= i)
                    {
                        break;
                    }
                    if (e < 9)
                    {
                        ROM.WriteShort(addresses[i] + (e * 2), (allMapIcons[e][i].x << 4));
                        ROM.WriteShort((addresses[i] + 18) + (e * 2), (allMapIcons[e][i].y << 4));
                        ROM.WriteShort((addressesgfx[i] + e * 2), allMapIcons[e][i].gfx);
                    }
                    else
                    {
                        short px = (short)(allMapIcons[e][i].x << 4);
                        short py = (short)(allMapIcons[e][i].y << 4);
                        ROM.DATA[0x53763 + i] = (byte)(px & 0xFF);
                        ROM.DATA[0x5376b + i] = (byte)((px>>8) & 0xFF);

                        ROM.DATA[0x53773 + i] = (byte)(py & 0xFF);
                        ROM.DATA[0x5377b + i] = (byte)((py >> 8) & 0xFF);
                    }
                }
            }





            return false;
        }



        //DUNGEON MAP START
        //
        //

        private void dungmapPicturebox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;


            Color r1 = GFX.getColor(ROM.ReadRealShort(0xDE56E));
            Color r2 = GFX.getColor(ROM.ReadRealShort(0xDE570));
            Color gridcolor = GFX.getColor(ROM.ReadRealShort(0xDE572));

            e.Graphics.DrawRectangle(new Pen(r2,2), new Rectangle(1, 1, 182, 182));
            e.Graphics.DrawRectangle(new Pen(r1, 2), new Rectangle(3, 3, 178, 178));

            for(int i = 0;i<6;i++)
            {
                e.Graphics.DrawLine(new Pen(gridcolor, 2), 10,12 + (i * 32),170, 12 + (i * 32));
                e.Graphics.DrawLine(new Pen(gridcolor, 2), 10 + (i * 32),12, 10 + (i * 32), 172);
            }

            if (dungmapListbox.SelectedIndex != -1)
            {

                for (int i = 0; i < 25; i++)
                {


                    if (currentFloorRooms[currentFloor][i] != 0x0F)
                    {


                        int gId = currentFloorGfx[currentFloor][i];
                         e.Graphics.DrawImage(dungmaptiles16Bitmap, new Rectangle(10 + ((i % 5) * 32), 12 + ((i / 5) * 32), 32, 32), new Rectangle((gId%16) * 16, (gId/16)*16, 16, 16), GraphicsUnit.Pixel);
                        if (currentFloorRooms[currentFloor][i] == bossRoom)
                        {
                            e.Graphics.DrawRectangle(new Pen(Color.Red, 4), new Rectangle(10 + ((i % 5) * 32), 12 + ((i / 5) * 32), 32, 32));
                        }


                        if (roomidshowCheckbox.Checked)
                        {
                            GFX.drawText(e.Graphics, 16 + ((i % 5) * 32), 20 + ((i / 5) * 32), currentFloorRooms[currentFloor][i].ToString("X2"), null, true);
                        }
                    }
                    if (dungmapSelectedTile == i)
                    {
                        e.Graphics.DrawRectangle(new Pen(Color.Azure, 2), new Rectangle(10 + ((i % 5) * 32), 12 + ((i / 5) * 32), 32, 32));
                        
                    }

                }
            }

        }

        byte[][] currentFloorRooms = new byte[1][];
        byte[][] currentFloorGfx = new byte[1][];
        int totalFloors = 0;
        byte currentFloor = 0;
        byte nbrBasement = 0;
        byte nbrFloor = 0;
        ushort bossRoom = 0x000F;

        public void LoadDungeonMaps()
        {

            List<byte[]> currentFloorRoomsD = new List<byte[]>();
            List<byte[]> currentFloorGfxD = new List<byte[]>();
            int totalFloorsD = 0;
            byte nbrFloorD = 0;
            byte nbrBasementD = 0;

            for (int d = 0; d < 14; d++)
            {
                currentFloorRoomsD.Clear();
                currentFloorGfxD.Clear();
                int ptr = ROM.ReadShort(Constants.dungeonMap_rooms_ptr + (d * 2));
                int ptrGFX = ROM.ReadShort(Constants.dungeonMap_gfx_ptr + (d * 2));
                ptr += 0x0A0000; //add bank to the short ptr
                ptrGFX += 0x0A0000; //add bank to the short ptr
                int pcPtr = Utils.SnesToPc(ptr); //Contains data for the next 25 rooms
                int pcPtrGFX = Utils.SnesToPc(ptrGFX); //Contains data for the next 25 rooms

                ushort bossRoomD = (ushort)(ROM.ReadShort(Constants.dungeonMap_bossrooms + (d * 2)));
                nbrBasementD = (byte)(ROM.ReadShort(Constants.dungeonMap_floors + (d * 2)) & 0xF);
                nbrFloorD = (byte)((ROM.ReadShort(Constants.dungeonMap_floors + (d * 2)) & 0xF0) >> 4);
                totalFloorsD = nbrBasementD + nbrFloorD;



                for (int i = 0; i < totalFloorsD; i++) //for each floor in the dungeon
                {
                    byte[] rdata = new byte[25];
                    byte[] gdata = new byte[25];
                    for (int j = 0; j < 25; j++) // for each room on the floor
                    {
                        rdata[j] = 0x0F;
                        gdata[j] = 0xFF;
                        rdata[j] = ROM.DATA[pcPtr + j + (i * 25)]; //set the rooms
                        if (rdata[j] == 0x0F)
                        {
                            gdata[j] = 0xFF;
                        }
                        else
                        {
                            gdata[j] = ROM.DATA[pcPtrGFX];
                            pcPtrGFX++;
                        }
                    }
                    currentFloorGfxD.Add(gdata); //add new floor gfx data
                    currentFloorRoomsD.Add(rdata); //add new floor data
                    
                }

                dungmaps[d] = new DungeonMap(bossRoomD, nbrFloorD, nbrBasementD, currentFloorRoomsD, currentFloorGfxD);

            }
        }


        DungeonMap[] dungmaps = new DungeonMap[14];


        private void dungmapListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (currentDungeonChanged)
            {
                if (MessageBox.Show("The previous selected dungeon had changes do you want to keep them?", "Save Changes?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    //do save
                }
                currentDungeonChanged = false;
            }
            updateDungMap();

        }

        public void updateDungMap()
        {
            currentFloorRooms = dungmaps[dungmapListbox.SelectedIndex].FloorRooms.ToArray();
            currentFloorGfx = dungmaps[dungmapListbox.SelectedIndex].FloorGfx.ToArray();
            nbrBasement = dungmaps[dungmapListbox.SelectedIndex].nbrOfBasement;
            nbrFloor = dungmaps[dungmapListbox.SelectedIndex].nbrOfFloor;
            totalFloors = nbrBasement + nbrFloor;
            currentFloor = nbrBasement;
            if (nbrFloor == 0)
            {
                currentFloor -= 1;
            }
            bossRoom = dungmaps[dungmapListbox.SelectedIndex].bossRoom;
            editedFromEditor = true;
            dungmaproomidTextbox.Text = currentFloorRooms[currentFloor][dungmapSelectedTile].ToString("X2");
            dungmapbossTextbox.Text = bossRoom.ToString("X2");
            editedFromEditor = false;
            //label8.Text = currentFloor.ToString();
            AssembleMapTiles();
            dungmapPicturebox.Refresh();
            floorselectorPicturebox.Refresh();
            dungmapSelected = dungmapListbox.SelectedIndex;
        }
        Bitmap floorSelector;
        private void floorselectorPicturebox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

            float[][] matrixItems ={
               new float[] {1f, 0, 0, 0, 0},
               new float[] {0, 1f, 0, 0, 0},
               new float[] {0, 0, 1f, 0, 0},
               new float[] {0, 0, 0, 0.35f, 0},
               new float[] {0, 0, 0, 0, 1}};
            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);
            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(colorMatrix);

            e.Graphics.DrawImage(floorSelector, new Rectangle(0, 0, 24, 240), 0, 0, 24, 240, GraphicsUnit.Pixel, ia);
            for(int i = 0;i<nbrFloor;i++)
            {
                e.Graphics.DrawImage(floorSelector, new Rectangle(0, 105 - (i * 15), 24, 15), new Rectangle(0, 105 - (i * 15), 24, 15), GraphicsUnit.Pixel);
            }

            for (int i = 0; i < nbrBasement; i++)
            {
                e.Graphics.DrawImage(floorSelector, new Rectangle(0, 121 + (i * 15), 24, 15), new Rectangle(0, 121 + (i * 15), 24, 15), GraphicsUnit.Pixel);
            }
            for(int i = 0;i<totalFloors;i++)
            {
                if (i == currentFloor)
                {

               matrixItems =new float[][]{
               new float[] {0f, 0, 0, 0, 0},
               new float[] {0, 1f, 0, 0, 0},
               new float[] {0, 0, 0f, 0, 0},
               new float[] {0, 0, 0, 1f, 0},
               new float[] {0, 0, 0, 0, 1}};
                    colorMatrix = new ColorMatrix(matrixItems);

                    
                    ia.SetColorMatrix(colorMatrix);
                    e.Graphics.DrawImage(floorSelector, new Rectangle(0, ((7*15)+(nbrBasement*15) ) - (i * 15), 24, 15), 0, ((7 * 15) + (nbrBasement * 15)) - (i * 15), 24, 15, GraphicsUnit.Pixel, ia) ;
                }
            }

        }

        public void dungmapBuildtileset()
        {
            byte[] staticgfx = new byte[4];

            //Main Blocksets

            for (int i = 0; i < 4; i++)
            {
                staticgfx[i] = (byte)(ROM.DATA[Constants.sprite_blockset_pointer + ((128+dungmapListbox.SelectedIndex) * 4) + i] + 115);
            }

            /*for (int i = 0; i < 4; i++)
            {
                
            }*/


            unsafe
            {
                //NEED TO BE EXECUTED AFTER THE TILESET ARE LOADED NOT BEFORE -_-
                byte* currentmapgfx8Data = (byte*)GFX.currentTileScreengfx16Ptr.ToPointer();//loaded gfx for the current map (empty at this point)
                byte* allgfxData = (byte*)GFX.allgfx16Ptr.ToPointer(); //all gfx of the game pack of 2048 bytes (4bpp)
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2048; j++)
                    {
                        byte mapByte = allgfxData[j + (staticgfx[i] * 2048)];
                        currentmapgfx8Data[(i * 2048) + j] = mapByte; //Upload used gfx data
                    }
                }
            }
        }

        public void AssembleMapTiles() //186 tiles?
        {
            /*for (int i = 0; i < 256; i++)
            {
                Tile16 t = ROM.ReadTile16(0x57009 + (i * 8));
            }*/
            dungmapBuildtileset();
            dungmapupdateTiles();
            dungmapupdateTiles16();
            ColorPalette cp = dungmaptiles8Bitmap.Palette;

            for (int i = 128; i < 256; i++)
            {
                cp.Entries[i] = currentPalette[i];
            }

            for(int i =0;i<80;i++)
            {
                cp.Entries[i + 32] = GFX.getColor(ROM.ReadRealShort(0xDE544 + (i * 2)));
                if ((i % 16) == 0)
                {
                    cp.Entries[i+32] = Color.Transparent;
                }
            }
            dungmaptiles8Bitmap.Palette = cp;
            dungmaptiles16Bitmap.Palette = cp;
            
            dungmaptilesPicturebox.Refresh();
            dungmaproomgfxPicturebox.Refresh();



        }

        public unsafe void dungmapupdateTiles()
        {

            byte p;
            ushort tempTile = (ushort)selectedTile;


            selectedTile = tempTile;

            p = 4;
            byte* destPtr = (byte*)dungmaptiles8Ptr.ToPointer();
            byte* srcPtr = (byte*)GFX.currentTileScreengfx16Ptr.ToPointer();
            int xx = 0;
            int yy = 0;
            for (int i = 0; i < 256; i++)
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

        }

        public unsafe void dungmapupdateTiles16()
        {

            byte* destPtr = (byte*)dungmaptiles16Ptr.ToPointer();
            byte* srcPtr = (byte*)GFX.currentTileScreengfx16Ptr.ToPointer();
            int xx = 0;
            int yy = 0;
            for (int i = 0; i < 186; i++) //372 tiles / 2 because we'll do 2 tile at once
            {
                int addr = Constants.dungeonMap_tile16;
                if (ROM.DATA[Constants.dungeonMap_expCheck] != 0xB9)
                {
                    addr = Constants.dungeonMap_tile16Exp;
                }
                TileInfo t1 = GFX.gettilesinfo(ROM.ReadShort(addr + (i * 8)));// top left
                TileInfo t2 = GFX.gettilesinfo(ROM.ReadShort(addr+2 + (i * 8)));//top right
                TileInfo t3 = GFX.gettilesinfo(ROM.ReadShort(addr+4 + (i * 8))); //bottom left
                TileInfo t4 = GFX.gettilesinfo(ROM.ReadShort(addr+6 + (i * 8))); //bottom right
                for (var y = 0; y < 8; y++)
                {
                    for (var x = 0; x < 4; x++)
                    {
                      
                        CopyTile(x, y, xx, yy, t1.id-768, t1.palette, (t1.v == 1 ? true : false), (t1.h == 1 ? true : false), destPtr, srcPtr);
                        CopyTile(x, y, xx+8, yy, t2.id - 768, t2.palette, (t2.v == 1 ? true : false), (t2.h == 1 ? true : false), destPtr, srcPtr);
                        CopyTile(x, y, xx, yy+ 2048, t3.id - 768, t3.palette, (t3.v == 1 ? true : false), (t3.h == 1 ? true : false), destPtr, srcPtr);
                        CopyTile(x, y, xx+8, yy + 2048, t4.id - 768, t4.palette, (t4.v == 1 ? true : false), (t4.h == 1 ? true : false), destPtr, srcPtr);
                    }
                }
                xx += 16;
                if (xx >= 256)
                {
                    yy += 4096; //skip 2 line of tiles
                    xx = 0;
                }

            }

        }

        private void dungmaptilesPicturebox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.DrawImage(dungmaptiles8Bitmap, new Rectangle(0,0,256,256), new Rectangle(0,0,128,128),GraphicsUnit.Pixel);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                Buildtileset();
                updateTiles();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                Buildtilesetmap();
                updateTiles();
            }
                else if (tabControl1.SelectedIndex == 2)
            {
                AssembleMapTiles();
            }
        }

        private void dungmaproomgfxPicturebox_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.DrawImage(dungmaptiles16Bitmap, new Rectangle(0, 0, 512, 384), new Rectangle(0, 0, 256, 192), GraphicsUnit.Pixel);




            for (int i = 0;i<16;i++)
            {
                e.Graphics.DrawLine(new Pen(Color.FromArgb(60,255,255,255)), i * 32, 0, i * 32, 384);
                if (i < 10)
                {
                    e.Graphics.DrawLine(new Pen(Color.FromArgb(60, 255, 255, 255)), 0, i * 32, 512, i * 32);
                }
            }

            
        }

        private void floorselectorPicturebox_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            currentFloor++;
            if (currentFloor >= totalFloors)
            {
                currentFloor = 0;
            }
            dungmapPicturebox.Refresh();
            floorselectorPicturebox.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (currentFloor == 0)
            {
                currentFloor = (byte)(totalFloors-1);
            }
            else
            {
                currentFloor--;
            }
            dungmapPicturebox.Refresh();
            floorselectorPicturebox.Refresh();
        }

        private void roomidshowCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            dungmapPicturebox.Refresh();
            floorselectorPicturebox.Refresh();
        }

        private void dungmaproomgfxPicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            currentFloorGfx[currentFloor][dungmapSelectedTile] = (byte)((((e.Y) / 32)*16) + ((e.X/32)));
            dungmapPicturebox.Refresh();
            floorselectorPicturebox.Refresh();

        }

        int dungmapSelectedTile = 0;
        int dungmapSelected = 0;
        bool currentDungeonChanged = false;
        bool editedFromEditor = false;
        private void dungmapPicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            dungmapSelectedTile = (((e.Y - 12) / 32)*5) + ((e.X - 10) / 32);
            editedFromEditor = true;
            dungmaproomidTextbox.Text = currentFloorRooms[currentFloor][dungmapSelectedTile].ToString("X2");
            editedFromEditor = false;
            dungmapPicturebox.Refresh();
            floorselectorPicturebox.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void dungmaproomidTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!editedFromEditor)
            {
                int i = 0;
                if (int.TryParse(dungmaproomidTextbox.Text, System.Globalization.NumberStyles.HexNumber, CultureInfo.CurrentCulture, out i))
                {
                    currentFloorRooms[currentFloor][dungmapSelectedTile] = (byte)i;
                }
                else
                {
                    currentFloorRooms[currentFloor][dungmapSelectedTile] = 0x0F;
                }

                if (currentDungeonChanged == false)
                {

                    currentDungeonChanged = true;
                }

                

                dungmapPicturebox.Refresh();
                floorselectorPicturebox.Refresh();
            }
        }

        private void dungmapbossTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!editedFromEditor)
            {
                int i = 0;
                if (int.TryParse(dungmapbossTextbox.Text, System.Globalization.NumberStyles.HexNumber, CultureInfo.CurrentCulture, out i))
                {
                    dungmaps[dungmapListbox.SelectedIndex].bossRoom = (byte)i;
                    bossRoom = (byte)i;
                }
                else
                {
                    dungmaps[dungmapListbox.SelectedIndex].bossRoom = 0x000F;
                    bossRoom = 0x000F;
                }

                dungmapPicturebox.Refresh();
                floorselectorPicturebox.Refresh();
            }
        }

        public bool dungmapSaveAllCurrentDungeon()
        {
            if (ROM.DATA[Constants.dungeonMap_expCheck] == 0xB9)
            {
                for (int i = 0; i < (372 * 4); i++)
                {
                    ROM.DATA[Constants.dungeonMap_tile16Exp + i] = ROM.DATA[Constants.dungeonMap_tile16 + i];
                }
                //Replace all these address by JSRs
                //0x56652
                //0x566B6
                //0x5671A
                //0x5677E
                string expAsm =
                    "org $0AE652\r\n" +
                    "JSR Load1\r\n" +
                    "org $0AE6B6\r\n" +
                    "JSR Load2\r\n" +
                    "org $0AE71A\r\n" +
                    "JSR Load3\r\n" +
                    "org $0AE77E\r\n" +
                    "JSR Load4\r\n" +
                    "org $219010\r\n" +
                    "NewTile16:\r\n" +
                    "org $0AF009\r\n" +
                    "Load1:\r\n" +
                    "PHX\r\n" +
                    "TYX\r\n" +
                    "LDA.l NewTile16, X\r\n" +
                    "TXY\r\n" +
                    "PLX\r\n" +
                    "RTS\r\n" +
                    "Load2:\r\n" +
                    "PHX\r\n" +
                    "TYX\r\n" +
                    "LDA.l NewTile16+2, X\r\n" +
                    "TXY\r\n" +
                    "PLX\r\n" +
                    "RTS\r\n" +
                    "Load3:\r\n" +
                    "PHX\r\n" +
                    "TYX\r\n" +
                    "LDA.l NewTile16+4, X\r\n" +
                    "TXY\r\n" +
                    "PLX\r\n" +
                    "RTS\r\n" +
                    "Load4:\r\n" +
                    "PHX\r\n" +
                    "TYX\r\n" +
                    "LDA.l NewTile16+6, X\r\n" +
                    "TXY\r\n" +
                    "PLX\r\n" +
                    "RTS\r\n"; //48 bytes
                File.WriteAllText("tempPatch.asm", expAsm);
                AsarCLR.Asar.init();
                if (AsarCLR.Asar.patch("tempPatch.asm",ref ROM.DATA) == false)
                {
                    MessageBox.Show("Error temp patch asm");
                }

                AsarCLR.Asar.close();


            }



            
            //dungeonMap_rooms_ptr

            int pos = Constants.dungeonMap_datastart;

            
            

            for (int d = 0; d<14;d++) //For all dungeons !
            {
                //Needs to write floors data
                int floors = 0;

                floors = ((dungmaps[d].nbrOfFloor << 4) | dungmaps[d].nbrOfBasement);
                

                ROM.WriteShort((Constants.dungeonMap_floors) + (d * 2), floors);
                ROM.WriteShort((Constants.dungeonMap_bossrooms) + (d * 2), dungmaps[d].bossRoom);
                bool searchBoss = true;
                if (dungmaps[d].bossRoom == 0x000F)
                {
                    ROM.WriteShort((0x56E79) + (d * 2), 0xFFFF);
                    searchBoss = false;
                }

                //Write that dungeon pointer
                ROM.WriteShort(Constants.dungeonMap_rooms_ptr + (d * 2), Utils.PcToSnes(pos));

                for (int f = 0; f < dungmaps[d].nbrOfFloor+dungmaps[d].nbrOfBasement; f++) //For all floors in that dungeon
                {
                    for(int r = 0; r <25; r++) //For all rooms on that floor
                    {
                        if (searchBoss == true)
                        {
                            if (dungmaps[d].bossRoom == (ushort)dungmaps[d].FloorRooms[f][r])
                            {
                                ROM.WriteShort((0x56E79) + (d * 2), f);
                                searchBoss = false;
                            }
                        }
                        ROM.DATA[pos] = dungmaps[d].FloorRooms[f][r];
                        pos++; //increment position at each write

                        if (pos >= 0x575D9 && pos <= 0x57620)
                        {
                            
                            pos = 0x57621;
                            f = 50; //restart the room since it was in reserved space
                            d -= 1;
                            searchBoss = false;
                            break;
                        }

                    }
                }

                //When it is done with the floors ROOMS do the gfx

                //Write that dungeon gfx pointer
                ROM.WriteShort(Constants.dungeonMap_gfx_ptr + (d * 2), Utils.PcToSnes(pos));
                for (int f = 0; f < dungmaps[d].nbrOfFloor + dungmaps[d].nbrOfBasement; f++) //For all floors in that dungeon
                {
                    for (int r = 0; r < 25; r++) //For all rooms on that floor
                    {
                        if (dungmaps[d].FloorGfx[f][r] != 0xFF)
                        {
                            ROM.DATA[pos] = dungmaps[d].FloorGfx[f][r];
                            pos++; //increment position at each write
                            if (pos >= 0x575D9 && pos <= 0x57620)
                            {
                                pos = 0x57621;
                                ROM.WriteShort(Constants.dungeonMap_gfx_ptr + (d * 2), Utils.PcToSnes(pos));
                                f = 50; //restart the room since it was in reserved space
                                d -= 1;
                                searchBoss = false;
                                break;
                            }
                        }
                    }


                }

                //Protection here if we're over pointers location we need to decrease loop by one and continue further
                if (pos >= 0x57CE0) //we reached the limit uh oh
                {
                    return true;
                }


                if (searchBoss == true)
                {
                    MessageBox.Show("One of the boss room in the dungeon map editor can't be found in dungeon id " + d.ToString());
                    return true;
                }




            }



            return false;

        }



        
        public void shiftAllGfx()
        {
            int nbrBasementShift = (byte)(ROM.ReadShort(Constants.dungeonMap_floors + (dungmapListbox.SelectedIndex * 2)) & 0xF);
            int nbrFloorShift = (byte)((ROM.ReadShort(Constants.dungeonMap_floors + (dungmapListbox.SelectedIndex * 2)) & 0xF0) >> 4);



        }

        private void dungmapaddfloorButton_Click(object sender, EventArgs e)
        {
            
            if (dungmaps[dungmapListbox.SelectedIndex].nbrOfFloor >= 8)
            {
                return;
            }

            byte[] rdata = new byte[25];
            byte[] gdata = new byte[25];
            for (int i = 0; i < 25; i++)
            {
                rdata[i] = 0x0F;
                gdata[i] = 0xFF;
            }
            dungmaps[dungmapListbox.SelectedIndex].FloorRooms.Add(rdata);
            dungmaps[dungmapListbox.SelectedIndex].FloorGfx.Add(gdata);
            currentFloor = 0;
            dungmaps[dungmapListbox.SelectedIndex].nbrOfFloor += 1;
            updateDungMap();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            if (of.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(of.FileName,FileMode.Open,FileAccess.Read);

                fs.Read(ROM.DATA, 0, (int)fs.Length);
                

                fs.Close();
            }
            Constants.Init_Jp();
            GFX.CreateAllGfxData(ROM.DATA);
            Buildtileset();
            LoadTitleScreen(true);
        }

        private void dungmapaddbaseButton_Click(object sender, EventArgs e)
        {
            if (dungmaps[dungmapListbox.SelectedIndex].nbrOfBasement >= 8)
            {
                return;
            }

            byte[] rdata = new byte[25];
            byte[] gdata = new byte[25];
            for (int i = 0; i < 25; i++)
            {
                rdata[i] = 0x0F;
                gdata[i] = 0xFF;
            }
            dungmaps[dungmapListbox.SelectedIndex].FloorRooms.Insert(0,rdata);
            dungmaps[dungmapListbox.SelectedIndex].FloorGfx.Insert(0,gdata);
            currentFloor = 0;
            dungmaps[dungmapListbox.SelectedIndex].nbrOfBasement += 1;
            updateDungMap();
        }

        private void dungmaprembaseButton_Click(object sender, EventArgs e)
        {
            if (dungmaps[dungmapListbox.SelectedIndex].nbrOfBasement == 0)
            {
                return;
            }
            dungmaps[dungmapListbox.SelectedIndex].FloorRooms.RemoveAt(0);
            dungmaps[dungmapListbox.SelectedIndex].FloorGfx.RemoveAt(0);
            dungmaps[dungmapListbox.SelectedIndex].nbrOfBasement -= 1;
            updateDungMap();
        }

        private void dungmapremfloorButton_Click(object sender, EventArgs e)
        {
            if (dungmaps[dungmapListbox.SelectedIndex].nbrOfFloor == 0)
            {
                return;
            }
            dungmaps[dungmapListbox.SelectedIndex].FloorRooms.RemoveAt(dungmaps[dungmapListbox.SelectedIndex].FloorRooms.Count-1);
            dungmaps[dungmapListbox.SelectedIndex].FloorGfx.RemoveAt(dungmaps[dungmapListbox.SelectedIndex].FloorGfx.Count-1);
            dungmaps[dungmapListbox.SelectedIndex].nbrOfFloor -= 1;
            updateDungMap();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        byte[] copiedDataRooms = new byte[25];
        byte[] copiedDataGfx = new byte[25];
        private void button8_Click(object sender, EventArgs e)
        {
            
            for(int i = 0;i<25;i++)
            {
                copiedDataRooms[i] = dungmaps[dungmapListbox.SelectedIndex].FloorRooms[currentFloor][i];
                copiedDataGfx[i] = dungmaps[dungmapListbox.SelectedIndex].FloorGfx[currentFloor][i];
            }
            updateDungMap();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 25; i++)
            {
                dungmaps[dungmapListbox.SelectedIndex].FloorRooms[currentFloor][i] = copiedDataRooms[i];
                dungmaps[dungmapListbox.SelectedIndex].FloorGfx[currentFloor][i] =  copiedDataGfx[i];
            }
            updateDungMap();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            /*if (File.Exists("temp.sfc"))
            {
                File.Delete("temp.sfc");
            }

            dungmapSaveAllCurrentDungeon();


            FileStream fs = new FileStream("temp.sfc", FileMode.OpenOrCreate, FileAccess.Write);
            fs.Write(ROM.DATA, 0, ROM.DATA.Length);
            fs.Close();
            Process p = Process.Start("temp.sfc");*/

        }
        MapIcon selectedMapIcon = null;
        bool mouseDown = false;
        int mxClick = 0;
        int myClick = 0;
        int mxDist = 0;
        int myDist = 0;
        private void mapPicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            selectedMapIcon = null;
            mxClick = (e.X - 256) / 2;
            myClick = (e.Y - 256) / 2;
            int id = 0;
            for (int i = 0;i<allMapIcons[overworldCombobox.SelectedIndex].Count;i++)
            {
                MapIcon mi = allMapIcons[overworldCombobox.SelectedIndex][i];
                if (mxClick >= mi.x && mxClick <= mi.x + 24 &&
                    (myClick >= mi.y && myClick <= mi.y + 24))
                {
                    selectedMapIcon = mi;
                    mxDist = mxClick - mi.x;
                    myDist = myClick - mi.y;
                    id = i;
                    break;
                }


            }

            if (selectedMapIcon == null)
            {
                mapiconGroupbox.Text = "Selected Icon Properties - No icon selected";
                xiconposLabel.Text = "X Position : ";
                yiconposLabel.Text = "Y Position : ";
                editedFromEditor = true;
                gfxiconTextbox.Text = "";
                editedFromEditor = false;
            }
            else
            {
                mapiconGroupbox.Text = "Selected Icon Properties - Icon " + id;
                xiconposLabel.Text = "X Position : " + selectedMapIcon.x.ToString();
                yiconposLabel.Text = "Y Position : " + selectedMapIcon.y.ToString();
                editedFromEditor = true;
                gfxiconTextbox.Text = selectedMapIcon.gfx.ToString("X4");
                editedFromEditor = false;
            }

            mapPicturebox.Refresh();
            mouseDown = true;


        }

        private void mapPicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            if (overworldCombobox.SelectedIndex == 9)
            {
                mouseDown = false;
                return;
            }
            mxClick = (e.X-256)/2;
            myClick = (e.Y-256)/2;
            if (e.Button == MouseButtons.Right)
            {
                if (mouseDown == true)
                {
                    ContextMenu cm;
                    if (selectedMapIcon != null)
                    {
                        cm = new ContextMenu(
                        new MenuItem[]
                        {
                        new MenuItem("Remove Map Icon",deleteMapIcon)
                        });
                    }
                    else
                    {
                        cm = new ContextMenu(
                            new MenuItem[]
                            {
                        new MenuItem("Insert Map Icon",insertMapIcon)
                            });
                    }


                    mouseDown = false;
                    cm.Show(mapPicturebox, new Point(e.X, e.Y));
                }
            }
            mouseDown = false;
        }

        public void insertMapIcon(Object sender, EventArgs e)
        {
            
            if (allMapIcons[overworldCombobox.SelectedIndex].Count < 8)
            {
                allMapIcons[overworldCombobox.SelectedIndex].Add(new MapIcon((short)mxClick, (short)myClick, 0));
                mapPicturebox.Refresh();

            }
            else
            {
                MessageBox.Show("Can't add more than 8 icons per event");
            }
            
        }

        public void deleteMapIcon(Object sender, EventArgs e)
        {
            allMapIcons[overworldCombobox.SelectedIndex].Remove(selectedMapIcon);
            mapPicturebox.Refresh();
        }

        private void mapPicturebox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                if (selectedMapIcon != null)
                {
                    mxClick = (e.X - 256) / 2;
                    myClick = (e.Y - 256) / 2;
                    if (mxClick<=0)
                    {
                        mxClick = 0;
                    }
                    if (myClick <= 0)
                    {
                        myClick = 0;
                    }
                    if (mxClick >= 256)
                    {
                        mxClick = 256;
                    }
                    if (myClick >= 256)
                    {
                        myClick = 256;
                    }
                    selectedMapIcon.x = (short)(mxClick - mxDist);
                    selectedMapIcon.y = (short)(myClick - myDist);
                    mapPicturebox.Refresh();
                }
            }
        }

        private void gfxiconTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!editedFromEditor)
            {
                int i = 0;
                if (int.TryParse(gfxiconTextbox.Text, System.Globalization.NumberStyles.HexNumber, CultureInfo.CurrentCulture, out i))
                {
                    selectedMapIcon.gfx = (ushort)i;
                }
                else
                {
                    selectedMapIcon.gfx = 0;
                }
                
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "indexed 8bpp image *.bmp |*.bmp";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                GFX.overworldMapBitmap.Save(sfd.FileName,ImageFormat.Bmp);
            }
        }

        private unsafe void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "indexed 8bpp image *.bmp |*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap b = new Bitmap(ofd.FileName);
                BitmapData bd = b.LockBits(new Rectangle(0, 0, 128, 128), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
                GFX.overworldMapBitmap = new Bitmap(128, 128, 128, PixelFormat.Format8bppIndexed, GFX.overworldMapPointer);
                int pos = 0;
                //Mode 7
                unsafe
                {
                    byte* ptr = (byte*)bd.Scan0.ToPointer();


                    
                    for (int sy = 0; sy < 16; sy++)
                    {
                        for (int sx = 0; sx < 16; sx++)
                        {
                            for (int y = 0; y < 8; y++)
                            {
                                for (int x = 0; x < 8; x++)
                                {
                                    ROM.DATA[0x0C4000 + pos] = ptr[x + (sx * 8) + (y * 128) + (sy * 1024)];
                                    pos++;
                                }
                            }
                        }
                    }

                }
                b.UnlockBits(bd);






                    pos = 0x55B27;
                    if (darkWorld)
                    {
                        pos = 0x55C27;
                    }


                Palettes.WritePalette(ROM.DATA, pos, b.Palette.Entries, 128);



                GFX.loadOverworldMap();
                owMapTilesBox.Refresh();
                mapPicturebox.Refresh();

            }
        }

        private void triforcebox1_Paint(object sender, PaintEventArgs e)
        {

            for(int i = 0;i<6;i++)
            {
                if (triforceRadio.Checked)
                {
                    e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + triforceVertices[i].x, 126 + triforceVertices[i].y, 4, 4));
                    if (selectedVertice != null)
                    {
                        if (selectedVertice == triforceVertices[i])
                        {
                            e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(126 + triforceVertices[i].x, 126 + triforceVertices[i].y, 4, 4));
                        }
                    }
                }
                else
                {
                    e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + crystalVertices[i].x, 126 + crystalVertices[i].y, 4, 4));
                    if (selectedVertice != null)
                    {
                        if (selectedVertice == crystalVertices[i])
                        {
                            e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(126 + crystalVertices[i].x, 126 + crystalVertices[i].y, 4, 4));
                        }
                    }
                }
            }

        }
        

        private void triforcebox2_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                if (triforceRadio.Checked)
                {
                    e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + triforceVertices[i].x, 126 + triforceVertices[i].z, 4, 4));
                    if (selectedVertice != null)
                    {
                        if (selectedVertice == triforceVertices[i])
                        {
                            e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(126 + triforceVertices[i].x, 126 + triforceVertices[i].z, 4, 4));
                        }
                    }
                }
                else
                {
                    e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + crystalVertices[i].x, 126 + crystalVertices[i].z, 4, 4));
                    if (selectedVertice != null)
                    {
                        if (selectedVertice == crystalVertices[i])
                        {
                            e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(126 + crystalVertices[i].x, 126 + crystalVertices[i].z, 4, 4));
                        }
                    }
                }
            }

        }

        private void triforcebox3_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                if (triforceRadio.Checked)
                {
                    e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + triforceVertices[i].z, 126 + triforceVertices[i].y, 4, 4));
                    if (selectedVertice != null)
                    {
                        if (selectedVertice == triforceVertices[i])
                        {
                            e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(126 + triforceVertices[i].z, 126 + triforceVertices[i].y, 4, 4));
                        }
                    }
                }
                else
                {
                    e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + crystalVertices[i].z, 126 + crystalVertices[i].y, 4, 4));
                    if (selectedVertice != null)
                    {
                        if (selectedVertice == crystalVertices[i])
                        {
                            e.Graphics.DrawRectangle(Pens.Blue, new Rectangle(126 + crystalVertices[i].z, 126 + crystalVertices[i].y, 4, 4));
                        }
                    }
                }
            }

        }
        bool mdown = false;
        private void triforcebox1_MouseDown(object sender, MouseEventArgs e)
        {
                    for (int i = 0; i < 6; i++)
                    {
                        if (triforceRadio.Checked)
                        {
                            //e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + triforceVertices[i].z, 126 + triforceVertices[i].y, 4, 4));
                            if (e.X >= triforceVertices[i].x + 124 && e.X <= triforceVertices[i].x + 130)
                            {
                                if (e.Y >= triforceVertices[i].y + 124 && e.Y <= triforceVertices[i].y + 130)
                                {
                                    selectedVertice = triforceVertices[i];
                                }
                            }
                        }
                        else
                        {
                            //e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + triforceVertices[i].z, 126 + triforceVertices[i].y, 4, 4));
                            if (e.X >= crystalVertices[i].x + 124 && e.X <= crystalVertices[i].x + 130)
                            {
                                if (e.Y >= crystalVertices[i].y + 124 && e.Y <= crystalVertices[i].y + 130)
                                {
                                    selectedVertice = crystalVertices[i];
                                }
                            }
                        }
                    }
            triforcebox1.Refresh();
            triforcebox2.Refresh();
            triforcebox3.Refresh();
            mdown = true;
        }

        private void triforcebox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mdown)
            {
                selectedVertice.x = (sbyte)((e.X - 128));
                selectedVertice.y = (sbyte)((e.Y - 128));
                triforcebox1.Refresh();
                triforcebox2.Refresh();
                triforcebox3.Refresh();
            }
        }

        private void triforcebox1_MouseUp(object sender, MouseEventArgs e)
        {
            mdown = false;
        }

        private void triforcebox2_MouseDown(object sender, MouseEventArgs e)
        {
                        if (triforceRadio.Checked)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                //e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + triforceVertices[i].z, 126 + triforceVertices[i].y, 4, 4));
                                if (e.X >= triforceVertices[i].x + 124 && e.X <= triforceVertices[i].x + 130)
                                {
                                    if (e.Y >= triforceVertices[i].z + 124 && e.Y <= triforceVertices[i].z + 130)
                                    {
                                        selectedVertice = triforceVertices[i];
                                    }
                                }
                            }
                        }
                        else
            {
                for (int i = 0; i < 6; i++)
                {
                    //e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + triforceVertices[i].z, 126 + triforceVertices[i].y, 4, 4));
                    if (e.X >= crystalVertices[i].x + 124 && e.X <= crystalVertices[i].x + 130)
                    {
                        if (e.Y >= crystalVertices[i].z + 124 && e.Y <= crystalVertices[i].z + 130)
                        {
                            selectedVertice = crystalVertices[i];
                        }
                    }
                }
            }
            triforcebox1.Refresh();
            triforcebox2.Refresh();
            triforcebox3.Refresh();
            mdown = true;
        }

        private void triforcebox3_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                if (triforceRadio.Checked)
                {
                    //e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + triforceVertices[i].z, 126 + triforceVertices[i].y, 4, 4));
                    if (e.X >= triforceVertices[i].z + 124 && e.X <= triforceVertices[i].z + 130)
                    {
                        if (e.Y >= triforceVertices[i].y + 124 && e.Y <= triforceVertices[i].y + 130)
                        {
                            selectedVertice = triforceVertices[i];
                        }
                    }
                }
                else
                {
                    //e.Graphics.DrawRectangle(Pens.Yellow, new Rectangle(126 + triforceVertices[i].z, 126 + triforceVertices[i].y, 4, 4));
                    if (e.X >= crystalVertices[i].z + 124 && e.X <= crystalVertices[i].z + 130)
                    {
                        if (e.Y >= crystalVertices[i].y + 124 && e.Y <= crystalVertices[i].y + 130)
                        {
                            selectedVertice = crystalVertices[i];
                        }
                    }
                }
            }
            triforcebox1.Refresh();
            triforcebox2.Refresh();
            triforcebox3.Refresh();
            mdown = true;
        }

        private void triforcebox2_MouseUp(object sender, MouseEventArgs e)
        {
            mdown = false;
        }

        private void triforcebox3_MouseUp(object sender, MouseEventArgs e)
        {
            mdown = false;
        }

        private void triforcebox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mdown)
            {
                selectedVertice.x = (sbyte)((e.X - 128));
                selectedVertice.z = (sbyte)((e.Y - 128));
                triforcebox1.Refresh();
                triforcebox2.Refresh();
                triforcebox3.Refresh();
            }

        }

        private void triforcebox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (mdown)
            {
                selectedVertice.z = (sbyte)((e.X - 128));
                selectedVertice.y = (sbyte)((e.Y - 128));
                triforcebox1.Refresh();
                triforcebox2.Refresh();
                triforcebox3.Refresh();
            }
        }

        public void saveTriforce()
        {
            for (int i = 0; i < 6; i++)
            {
                ROM.DATA[Constants.triforceVertices + 0 + (i * 3)] = (byte)triforceVertices[i].x;
                ROM.DATA[Constants.triforceVertices + 1 + (i * 3)] = (byte)triforceVertices[i].y;
                ROM.DATA[Constants.triforceVertices + 2 + (i * 3)] = (byte)triforceVertices[i].z;

                ROM.DATA[Constants.crystalVertices + 0 + (i * 3)] = (byte)crystalVertices[i].x;
                ROM.DATA[Constants.crystalVertices + 1 + (i * 3)] = (byte)crystalVertices[i].y;
                ROM.DATA[Constants.crystalVertices + 2 + (i * 3)] = (byte)crystalVertices[i].z;
            }
        }

        private void crystalRadio_CheckedChanged(object sender, EventArgs e)
        {
            triforcebox1.Refresh();
            triforcebox2.Refresh();
            triforcebox3.Refresh();
        }
    }
}
