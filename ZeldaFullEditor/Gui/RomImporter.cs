using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui
{
    public partial class RomImporter : Form
    {
        public RomImporter()
        {
            InitializeComponent();
        }
        public Overworld ow;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog projectFile = new OpenFileDialog();
            projectFile.Filter = "Alttp US ROM .sfc|*.sfc;*.smc";
            projectFile.DefaultExt = ".sfc";
            if (projectFile.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(projectFile.FileName, FileMode.Open, FileAccess.Read);
                int size = (int)fs.Length;
                ROM.IMPORTDATA = new byte[size];
                fs.Read(ROM.IMPORTDATA, 0, (int)fs.Length);
                fs.Close();
            }
            if (entrancescheckBox.Checked)
            {
                loadEntrances();
            }
            if (exitscheckBox.Checked)
            {
                loadExits();
            }
            if (transportscheckBox.Checked)
            {
                loadTransports();
            }
            if (itemscheckBox.Checked)
            {
                loadItems();
            }
            if (propertiescheckbox.Checked)
            {

                for (int i = 0; i < 64; i++)
                {
                    ow.allmaps[i].sprgfx[0] = ROM.IMPORTDATA[Constants.overworldSpriteset + ow.allmaps[i].parent];
                    ow.allmaps[i].sprgfx[1] = ROM.IMPORTDATA[Constants.overworldSpriteset + ow.allmaps[i].parent + 64];
                    ow.allmaps[i].sprgfx[2] = ROM.IMPORTDATA[Constants.overworldSpriteset + ow.allmaps[i].parent + 128];
                    ow.allmaps[i].gfx = ROM.IMPORTDATA[Constants.mapGfx + ow.allmaps[i].parent];
                    ow.allmaps[i].palette = ROM.IMPORTDATA[Constants.overworldMapPalette + ow.allmaps[i].parent];
                    ow.allmaps[i].sprpalette[0] = ROM.IMPORTDATA[Constants.overworldSpritePalette + ow.allmaps[i].parent];
                    ow.allmaps[i].sprpalette[1] = ROM.IMPORTDATA[Constants.overworldSpritePalette + ow.allmaps[i].parent + 64];
                    ow.allmaps[i].sprpalette[2] = ROM.IMPORTDATA[Constants.overworldSpritePalette + ow.allmaps[i].parent + 128];

                }
                for (int i = 64; i < 128; i++)
                {
                    ow.allmaps[i].sprgfx[0] = ROM.IMPORTDATA[Constants.overworldSpriteset + ow.allmaps[i].parent + 128];
                    ow.allmaps[i].sprgfx[1] = ROM.IMPORTDATA[Constants.overworldSpriteset + ow.allmaps[i].parent + 128];
                    ow.allmaps[i].sprgfx[2] = ROM.IMPORTDATA[Constants.overworldSpriteset + ow.allmaps[i].parent + 128];
                    ow.allmaps[i].gfx = ROM.IMPORTDATA[Constants.mapGfx + ow.allmaps[i].parent];
                    ow.allmaps[i].palette = ROM.IMPORTDATA[Constants.overworldMapPalette + ow.allmaps[i].parent];
                    ow.allmaps[i].sprpalette[0] = ROM.IMPORTDATA[Constants.overworldSpritePalette + ow.allmaps[i].parent + 128];
                    ow.allmaps[i].sprpalette[1] = ROM.IMPORTDATA[Constants.overworldSpritePalette + ow.allmaps[i].parent + 128];
                    ow.allmaps[i].sprpalette[2] = ROM.IMPORTDATA[Constants.overworldSpritePalette + ow.allmaps[i].parent + 128];

                }

            }
            if (spritescheckBox.Checked)
            {
                for(int i = 0;i<160;i++)
                {
                    ow.allmaps[i].loadSprites(true);
                }
            }
            this.Close();

        }

        public void loadExits()
        {
            for (int i = 0; i < 0x4F; i++)
            {
                short[] e = new short[13];
                e[0] = (short)((ROM.IMPORTDATA[Constants.OWExitRoomId + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWExitRoomId + (i * 2)]));
                e[1] = (byte)((ROM.IMPORTDATA[Constants.OWExitMapId + i]));
                e[2] = (short)((ROM.IMPORTDATA[Constants.OWExitVram + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWExitVram + (i * 2)]));
                e[3] = (short)((ROM.IMPORTDATA[Constants.OWExitYScroll + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWExitYScroll + (i * 2)]));
                e[4] = (short)((ROM.IMPORTDATA[Constants.OWExitXScroll + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWExitXScroll + (i * 2)]));
                ushort py = (ushort)((ROM.IMPORTDATA[Constants.OWExitYPlayer + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWExitYPlayer + (i * 2)]));
                ushort px = (ushort)((ROM.IMPORTDATA[Constants.OWExitXPlayer + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWExitXPlayer + (i * 2)]));
                e[7] = (short)((ROM.IMPORTDATA[Constants.OWExitYCamera + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWExitYCamera + (i * 2)]));
                e[8] = (short)((ROM.IMPORTDATA[Constants.OWExitXCamera + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWExitXCamera + (i * 2)]));
                e[9] = (byte)((ROM.IMPORTDATA[Constants.OWExitUnk1 + i]));
                e[10] = (byte)((ROM.IMPORTDATA[Constants.OWExitUnk2 + i]));
                e[11] = (short)((ROM.IMPORTDATA[Constants.OWExitDoorType1 + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWExitDoorType1 + (i * 2)]));
                e[12] = (short)((ROM.IMPORTDATA[Constants.OWExitDoorType2 + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWExitDoorType2 + (i * 2)]));
                ExitOW eo = (new ExitOW(e[0], (byte)e[1], e[2], e[3], e[4], py, px, e[7], e[8], (byte)e[9], (byte)e[10], e[11], e[12]));
                if (eo.playerX == 0xFFFF)
                {

                }

                ow.allexits[i] = eo;
            }
        }


        public void loadTransports()
        {
            for (int i = 0; i < 0x11; i++)
            {
                short[] e = new short[13];
                e[0] = (byte)(((ROM.IMPORTDATA[Constants.OWExitMapIdWhirlpool + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWExitMapIdWhirlpool + (i * 2)])));
                e[1] = (short)((ROM.IMPORTDATA[Constants.OWExitVramWhirlpool + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWExitVramWhirlpool + (i * 2)]));
                e[2] = (short)((ROM.IMPORTDATA[Constants.OWExitYScrollWhirlpool + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWExitYScrollWhirlpool + (i * 2)]));
                e[3] = (short)((ROM.IMPORTDATA[Constants.OWExitXScrollWhirlpool + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWExitXScrollWhirlpool + (i * 2)]));
                e[4] = (short)((ROM.IMPORTDATA[Constants.OWExitYPlayerWhirlpool + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWExitYPlayerWhirlpool + (i * 2)]));
                e[5] = (short)((ROM.IMPORTDATA[Constants.OWExitXPlayerWhirlpool + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWExitXPlayerWhirlpool + (i * 2)]));
                e[6] = (short)((ROM.IMPORTDATA[Constants.OWExitYCameraWhirlpool + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWExitYCameraWhirlpool + (i * 2)]));
                e[7] = (short)((ROM.IMPORTDATA[Constants.OWExitXCameraWhirlpool + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWExitXCameraWhirlpool + (i * 2)]));
                e[8] = (byte)((ROM.IMPORTDATA[Constants.OWExitUnk1Whirlpool + i]));
                e[9] = (byte)((ROM.IMPORTDATA[Constants.OWExitUnk2Whirlpool + i]));
                e[10] = (short)((ROM.IMPORTDATA[Constants.OWWhirlpoolPosition + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWWhirlpoolPosition + (i * 2)]));
                if (i > 8)
                {
                    e[10] = (short)((ROM.IMPORTDATA[Constants.OWWhirlpoolPosition + ((i - 9) * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWWhirlpoolPosition + ((i - 9) * 2)]));
                }


                TransportOW eo = (new TransportOW((byte)e[0], e[1], e[2], e[3], e[4], e[5], e[6], e[7], (byte)e[8], (byte)e[9], e[10]));
                ow.allWhirlpools.Add(eo);
            }
        }


        public void loadEntrances()
        {

            for (int i = 0; i < 129; i++)
            {
                short mapId = (short)((ROM.IMPORTDATA[Constants.OWEntranceMap + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWEntranceMap + (i * 2)]));
                ushort mapPos = (ushort)((ROM.IMPORTDATA[Constants.OWEntrancePos + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWEntrancePos + (i * 2)]));

                byte entranceId = (byte)((ROM.IMPORTDATA[Constants.OWEntranceEntranceId + i]));
                int p = mapPos >> 1;
                int x = (p % 64);
                int y = (p >> 6);
                EntranceOWEditor eo = new EntranceOWEditor((x * 16) + (((mapId % 64) - (((mapId % 64) / 8) * 8)) * 512), (y * 16) + (((mapId % 64) / 8) * 512), entranceId, mapId, mapPos);
                if (mapPos == 0xFFFF)
                {
                    eo.deleted = true;
                }
                ow.allentrances[i] = eo;
                
            }


            for (int i = 0; i < 0x13; i++)
            {
                short mapId = (short)((ROM.IMPORTDATA[Constants.OWHoleArea + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWHoleArea + (i * 2)]));
                short mapPos = (short)((ROM.IMPORTDATA[Constants.OWHolePos + (i * 2) + 1] << 8) + (ROM.IMPORTDATA[Constants.OWHolePos + (i * 2)]));
                byte entranceId = (byte)((ROM.IMPORTDATA[Constants.OWHoleEntrance + i]));
                int p = (mapPos + 0x400) >> 1;
                int x = (p % 64);
                int y = (p >> 6);
                EntranceOWEditor eo = new EntranceOWEditor((x * 16) + (((mapId % 64) - (((mapId % 64) / 8) * 8)) * 512), (y * 16) + (((mapId % 64) / 8) * 512), entranceId, mapId, (ushort)(mapPos + 0x400));
                ow.allholes[i] = eo;

            }
        }



        public void loadItems()
        {
            ow.allitems.Clear();
            int ptr = (ROM.IMPORTDATA[Constants.overworldItemsAddress + 2] << 16) +
            (ROM.IMPORTDATA[Constants.overworldItemsAddress + 1] << 8) +
                (ROM.IMPORTDATA[Constants.overworldItemsAddress]); //1BC2F9
            for (int i = 0; i < 128; i++)
            {

                int ptrpc = Addresses.snestopc(ptr);//1BC2F9 -> 0DC2F9
                int addr = ((ptr & 0xFF0000)) + //1B
                            (ROM.IMPORTDATA[ptrpc + (i * 2) + 1] << 8) + //F9
                            (ROM.IMPORTDATA[ptrpc + (i * 2)]); //3C

                addr = Addresses.snestopc(addr);

                if (ow.allmaps[i].largeMap == true)
                {
                    if (ow.mapParent[i] != (byte)i)
                    {
                        continue;
                    }
                }
                while (true)
                {
                    byte b1 = ROM.IMPORTDATA[addr];
                    byte b2 = ROM.IMPORTDATA[addr + 1];
                    byte b3 = ROM.IMPORTDATA[addr + 2];
                    if (b1 == 0xFF && b2 == 0xFF)
                    {
                        break;
                    }

                    int p = (((b2 & 0x1F) << 8) + b1) >> 1;

                    int x = p % 64;
                    int y = p >> 6;

                    int fakeid = i;
                    if (fakeid >= 64)
                    {
                        fakeid -= 64;
                    }
                    int sy = (fakeid / 8);
                    int sx = fakeid - (sy * 8);

                    ow.allitems.Add(new RoomPotSaveEditor(b3, (ushort)i, (x * 16) + (sx * 512), (y * 16) + (sy * 512), false));
                    ow.allitems[ow.allitems.Count - 1].gameX = (byte)x;
                    ow.allitems[ow.allitems.Count - 1].gameY = (byte)y;
                    addr += 3;
                }
            }


        }
    }
}
