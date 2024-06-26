﻿namespace ZeldaFullEditor
{
    public static class GfxGroups
    {
        public static byte[][] mainGfx = new byte[37][];
        public static byte[][] roomGfx = new byte[82][];
        public static byte[][] spriteGfx = new byte[144][];
        public static byte[][] paletteGfx = new byte[72][];

        public static void LoadGfxGroups()
        {
            int gfxPointer = (ROM.DATA[Constants.gfx_groups_pointer + 1] << 8) + ROM.DATA[Constants.gfx_groups_pointer];
            gfxPointer = Utils.SnesToPc(gfxPointer);

            for (int i = 0; i < 37; i++)
            {
                mainGfx[i] = new byte[8];
                for (int j = 0; j < 8; j++)
                {
                    mainGfx[i][j] = ROM.DATA[gfxPointer + (i * 8) + j];
                }
            }

            for (int i = 0; i < 82; i++)
            {
                roomGfx[i] = new byte[4];
                for (int j = 0; j < 4; j++)
                {
                    roomGfx[i][j] = ROM.DATA[Constants.entrance_gfx_group + (i * 4) + j];
                }
            }

            for (int i = 0; i < 144; i++)
            {
                spriteGfx[i] = new byte[4];
                for (int j = 0; j < 4; j++)
                {
                    spriteGfx[i][j] = ROM.DATA[Constants.sprite_blockset_pointer + (i * 4) + j];
                }
            }

            for (int i = 0; i < 72; i++)
            {
                paletteGfx[i] = new byte[4];
                for (int j = 0; j < 4; j++)
                {
                    paletteGfx[i][j] = ROM.DATA[Constants.dungeons_palettes_groups + (i * 4) + j];
                }
            }
        }

        public static bool SaveGroupsToROM()
        {
            int gfxPointer = (ROM.DATA[Constants.gfx_groups_pointer + 1] << 8) + ROM.DATA[Constants.gfx_groups_pointer];
            gfxPointer = Utils.SnesToPc(gfxPointer);

            for (int i = 0; i < 37; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ROM.Write(gfxPointer + (i * 8) + j, mainGfx[i][j], true, "Gfx Groups");
                }
            }

            for (int i = 0; i < 82; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ROM.Write(Constants.entrance_gfx_group + (i * 4) + j, roomGfx[i][j], true, "Gfx Groups");
                }
            }

            for (int i = 0; i < 144; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ROM.Write(Constants.sprite_blockset_pointer + (i * 4) + j, spriteGfx[i][j], true, "sprGfx Groups");
                }
            }

            for (int i = 0; i < 72; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ROM.Write(Constants.dungeons_palettes_groups + (i * 4) + j, paletteGfx[i][j], true, "palGfx Groups");
                }
            }

            return false;
        }
    }
}
