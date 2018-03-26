using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    [Serializable]
    public class RoomOW : ICloneable
    {
        public bool largeMap = false;

        public byte spriteset = 0;
        public short index = 0;
        public byte palette = 0;
        public byte sprite_palette = 0;
        public byte blockset = 0;
        public bool has_changed = false;
        public List<PotItem> items = new List<PotItem>();

        [DisplayName("Spriteset"), Description("The sprite gfx id used for that map"), Category("Header")]
        public byte Spriteset
        {
            get
            {
                return spriteset;
            }
            set
            {
                spriteset = value;
                if (spriteset >= 65)
                {
                    spriteset = 64;
                }
            }
        }

        [DisplayName("Palette Set"), Description("The palette set used for that map"), Category("Header")]
        public byte Palette
        {
            get
            {
                return palette;
            }
            set
            {
                palette = value;
                if (palette >= 72)
                {
                    palette = 71;
                }
            }
        }

        [DisplayName("Sprite Palette Set"), Description("The palette set used for that map"), Category("Header")]
        public byte SpritePalette
        {
            get
            {
                return sprite_palette;
            }
            set
            {
                sprite_palette = value;
                if (sprite_palette >= 72)
                {
                    sprite_palette = 71;
                }
            }
        }

        [DisplayName("Blockset"), Description("The gfx id used for that map"), Category("Header")]
        public byte Blockset
        {
            get
            {
                return blockset;
            }
            set
            {
                blockset = value;
                if (blockset >= 80)
                {
                    blockset = 79;
                }
            }
        }



        public RoomOW(short id) 
        {
            index = id;
            spriteset = ROM.DATA[Constants.overworldSpriteset + index];
            addItems();
        }

        public void addItems()
        {
            int addr = (Constants.overworldItemsBank << 16) +
                        (ROM.DATA[Constants.overworldItemsPointers + (index*2) + 1] << 8) +
                        (ROM.DATA[Constants.overworldItemsPointers + (index * 2)]);
            addr = Addresses.snestopc(addr);
            
            while (true)
            {
                byte b1 = ROM.DATA[addr];
                byte b2 = ROM.DATA[addr+1];
                byte b3 = ROM.DATA[addr+2];
                if (b1 == 0xFF && b2 == 0xFF)
                {
                    break;
                }

                int p = (((b2 & 0x1F) << 8) + b1) >> 1; 
                 
                int x = p % 64;
                int y = p >> 6;
                
                items.Add(new PotItem(b3, (byte)x, (byte)y, false));
                addr += 3;
            }
        }


        public void GetSelectedMapGfx()
        {

            updateOverworldPalettes();
            byte[] staticgfx = new byte[] { 58, 59, 60, 61, 0, 0, 89, 0, 0, 0, 0, 0, 0, 0, 0 }; //89 DM Animated
            byte animatedGfxPart2 = 91;
            //Should be 8 total not 9
            //TODO Find why there's 9 probably because of animated tiles

            if (blockset >= 48)
            {
                staticgfx = new byte[] { 66, 67, 68, 69, 0, 0, 63, 89, 0, 0, 0, 0, 0, 0, 0, 0 };
            }
            else if (blockset < 48)
            {
                staticgfx = new byte[] { 58, 59, 60, 61, 0, 0, 62, 89, 0, 0, 0, 0, 0, 0, 0, 0 };
            }

            staticgfx[4] = ROM.DATA[(int)(Constants.overworldgfxGroups + (blockset * 4) + 1)];
            staticgfx[5] = ROM.DATA[(int)(Constants.overworldgfxGroups + (blockset * 4) + 2)];

            if (index >= 128)
            {
                staticgfx[4] = 71;
                staticgfx[5] = 72;
            }
            if (index >= 136)
            {
                staticgfx = new byte[] { 0, 70, 66, 65, 66, 65, 66, 65, 66, 0, 0, 0, 0, 0, 0, 0, 0 };
            }
            //TODO : Need to find the position of these values for now they are hardcoded
            if (index >= 3 && index < 8)
            {
                staticgfx[7] = 89;
            }
            else if (index >= 11 && index < 15)
            {
                staticgfx[7] = 89;
            }
            else if (index >= 64 + 3 && index < 64 + 8)
            {
                staticgfx[7] = 89;
            }
            else if (index >= 64 + 11 && index < 64 + 15)
            {
                staticgfx[7] = 89;
            }
            else
            {
                staticgfx[7] = 91;
            }

            staticgfx[8] = 115 + 0; staticgfx[9] = 115 + 10; staticgfx[10] = 115 + 6; staticgfx[11] = 115 + 7; //Static Sprites Blocksets (fairy,pot,ect...)
            for (int i = 0; i < 4; i++)
            {
                staticgfx[12 + i] = (byte)(ROM.DATA[Constants.sprite_blockset_pointer + ((spriteset) * 4) + i] + 115);
            }
            GFX.singledata = new byte[staticgfx.Length * 0x1000];
            for (int i = 0; i < staticgfx.Length; i++)
            {
                byte[] d = GFX.bpp3snestoindexed(GFX.gfxdata, staticgfx[i]);
                byte[] dd = new byte[0];
                if (i == 7)
                {
                    dd = GFX.bpp3snestoindexed(GFX.gfxdata, animatedGfxPart2);
                }

                for (int j = 0; j < d.Length; j++)
                {
                    int pp = 0;
                    if (i == 0)
                    {
                        pp = 8;
                    }
                    else if (i == 1)
                    {
                        pp = 0;
                    }
                    else if (i == 2)
                    {
                        pp = 0;
                    }
                    else if (i == 3)
                    {
                        pp = 8;
                    }
                    else if (i == 4)
                    {
                        pp = 8;
                    }
                    else if (i == 5)
                    {
                        pp = 8;
                    }
                    else if (i == 6)
                    {
                        pp = 0;
                    }
                    else if (i == 7)
                    {
                        pp = 0;
                    }

                    GFX.singledata[(i * 0x1000) + j] = (byte)(d[j] + pp);
                    if (i == 7)
                    {
                        if (j > d.Length / 2)
                        {
                            GFX.singledata[(i * 0x1000) + j] = (byte)(dd[j] + pp);
                        }
                    }
                }
            }


        }



        public void updateOverworldPalettes()
        {

            //public static int hardcodedGrassLW = 0x75645;
            // public static int hardcodedGrassDW = 0x7564F;//map>40
            //public static int hardcodedGrassSpecial = 0x75640;//map 183,182,180
            
            int paletteG0 = 0;
            int paletteG1 = ROM.DATA[Constants.overworldMapPaletteGroup + palette];
            int paletteG2 = ROM.DATA[Constants.overworldMapPaletteGroup + palette + 1];
            int paletteG3 = ROM.DATA[Constants.overworldMapPaletteGroup + palette + 2];



            if (index >= 0x40)
            {
                paletteG0 = 1;
                for (int j = 0; j < 6; j++)
                {
                    GFX.loadedPalettes[0, j] = GFX.getColor((short)((ROM.DATA[Constants.hardcodedGrassDW + 1] << 8) + ROM.DATA[Constants.hardcodedGrassDW]));
                    GFX.loadedPalettes[8, j] = GFX.getColor((short)((ROM.DATA[Constants.hardcodedGrassDW + 1] << 8) + ROM.DATA[Constants.hardcodedGrassDW]));
                }
            }
            else
            {

                for (int j = 0; j < 6; j++)
                {

                    GFX.loadedPalettes[0, j] = GFX.getColor((short)((ROM.DATA[Constants.hardcodedGrassLW + 1] << 8) + ROM.DATA[Constants.hardcodedGrassLW]));
                    GFX.loadedPalettes[8, j] = GFX.getColor((short)((ROM.DATA[Constants.hardcodedGrassLW + 1] << 8) + ROM.DATA[Constants.hardcodedGrassLW]));
                }
            }
            if (index >= 0x80)
            {
                paletteG0 = 0;
                for (int j = 0; j < 6; j++)
                {
                    GFX.loadedPalettes[0, j] = GFX.getColor((short)((ROM.DATA[Constants.hardcodedGrassSpecial + 1] << 8) + ROM.DATA[Constants.hardcodedGrassSpecial]));
                    GFX.loadedPalettes[8, j] = GFX.getColor((short)((ROM.DATA[Constants.hardcodedGrassSpecial + 1] << 8) + ROM.DATA[Constants.hardcodedGrassSpecial]));
                }
            }

            if (index >= 0x43 && index <= 0x47)
            {
                paletteG0 = 3;
            }
            if (index >= 0x4B && index <= 0x4E)
            {
                paletteG0 = 3;
            }
            if (index == 136)
            {
                paletteG0 = 4;
            }

            if (index >= 03 && index <= 07)
            {
                paletteG0 = 2;
            }
            if (index >= 0x0B && index <= 0x0E)
            {
                paletteG0 = 2;
            }

            int i = (int)(70 * paletteG0);
            for (int y = 0; y < 5; y++)
            {
                for (int x = 1; x < 8; x++)
                {
                    GFX.loadedPalettes[x, y] = GFX.getColor((short)((ROM.DATA[(Constants.overworldPalGroup1 + i) + 1] << 8) + ROM.DATA[(Constants.overworldPalGroup1 + i)]));
                    i += 2;
                }
            }
            i = (int)(42 * paletteG1);
            for (int y = 0; y < 3; y++)
            {
                for (int x = 9; x < 16; x++)
                {
                    GFX.loadedPalettes[x, y] = GFX.getColor((short)((ROM.DATA[(Constants.overworldPalGroup2 + i) + 1] << 8) + ROM.DATA[(Constants.overworldPalGroup2 + i)]));
                    i += 2;
                }
            }
            i = (int)(42 * paletteG2);
            for (int y = 3; y < 6; y++)
            {
                for (int x = 9; x < 16; x++)
                {
                    GFX.loadedPalettes[x, y] = GFX.getColor((short)((ROM.DATA[(Constants.overworldPalGroup2 + i) + 1] << 8) + ROM.DATA[(Constants.overworldPalGroup2 + i)]));
                    i += 2;
                }
            }
            i = (int)(14 * paletteG3);
            for (int y = 5; y < 6; y++)
            {
                for (int x = 1; x < 8; x++)
                {
                    GFX.loadedPalettes[x, y] = GFX.getColor((short)((ROM.DATA[(Constants.overworldPalGroup3 + i) + 1] << 8) + ROM.DATA[(Constants.overworldPalGroup3 + i)]));
                    i += 2;
                }
            }
        }

        public object Clone()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;

                return (Room)formatter.Deserialize(ms);
            }
        }
    }
}
