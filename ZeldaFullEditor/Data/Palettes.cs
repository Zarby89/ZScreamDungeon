﻿using System.Drawing;
using System.Linq;
using System.Text;

namespace ZeldaFullEditor
{
    /// <summary>
    ///     A data class containing all the palette related data.
    /// </summary>
    public static class Palettes
    {
        /// <summary>
        ///     Gets or sets a 2 dimentional array containing the HUD palettes.
        ///     32 (0,0)
        /// </summary>
        public static Color[][] HudPalettes { get; set; } = new Color[2][];

        /// <summary>
        ///      Gets or sets a 2 dimentional array containing the main overworld palettes.
        ///     35 colors each, 7x5 (0,2 on grid)
        /// </summary>
        public static Color[][] OverworldMainPalettes { get; set; } = new Color[6][];

        /// <summary>
        ///      Gets or sets a 2 dimentional array containing the auxilary overworld palettes.
        ///     21 colors each, 7x3 (8,2 and 8,5 on grid)
        /// </summary>
        public static Color[][] OverworldAuxPalettes { get; set; } = new Color[20][];

        /// <summary>
        ///      Gets or sets a 2 dimentional array containing the animated overworld palettes.
        ///     7 colors each 7x1 (0,7 on grid)
        /// </summary>
        public static Color[][] OverworldAnimatedPalettes { get; set; } = new Color[14][];

        /// <summary>
        ///      Gets or sets a 2 dimentional array containing the global sprite palettes.
        ///     60 (1,9)
        /// </summary>
        public static Color[][] GlobalSpritePalettes { get; set; } = new Color[2][];

        /// <summary>
        ///      Gets or sets a 2 dimentional array containing the armor palettes.
        ///     15
        /// </summary>
        public static Color[][] ArmorPalettes { get; set; } = new Color[5][];

        /// <summary>
        ///      Gets or sets a 2 dimentional array containing the sword palettes.
        ///     3
        /// </summary>
        public static Color[][] SwordsPalettes { get; set; } = new Color[4][];

        /// <summary>
        ///      Gets or sets a 2 dimentional array containing the first group of auxilary sprite palettes.
        ///     7
        /// </summary>
        public static Color[][] SpritesAux1Palettes { get; set; } = new Color[12][];

        /// <summary>
        ///      Gets or sets a 2 dimentional array containing the second group of auxilary sprite palettes.
        ///     7
        /// </summary>
        public static Color[][] SpritesAux2Palettes { get; set; } = new Color[11][];

        /// <summary>
        ///      Gets or sets a 2 dimentional array containing the third group of auxilary sprite palettes.
        ///     7
        /// </summary>
        public static Color[][] SpritesAux3Palettes { get; set; } = new Color[24][];

        /// <summary>
        ///      Gets or sets a 2 dimentional array containing the shield palettes.
        ///     4
        /// </summary>
        public static Color[][] ShieldsPalettes { get; set; } = new Color[3][];

        /// <summary>
        ///      Gets or sets a 2 dimentional array containing the main dungeon palettes.
        ///     15*6
        /// </summary>
        public static Color[][] DungeonsMainPalettes { get; set; } = new Color[20][];

        /// <summary>
        ///      Gets or sets an containing the overworld background palettes.
        ///     8*20
        /// </summary>
        public static Color[] OverworldBackgroundPalette { get; set; } = new Color[Constants.NumberOfOWMaps];

        /// <summary>
        ///      Gets or sets an array containing the overworld grass palettes.
        ///     3 hardcoded grass colors
        /// </summary>
        public static Color[] OverworldGrassPalettes { get; set; } = new Color[3];

        /// <summary>
        ///      Gets or sets a 2 dimentional array containing the 3D object palettes.
        ///     15*6
        /// </summary>
        public static Color[][] Object3DPalettes { get; set; } = new Color[2][];

        /// <summary>
        ///      Gets or sets a 2 dimentional array containing the main overworld palettes.
        ///     16*8
        /// </summary>
        public static Color[][] OverworldMiniMapPalettes { get; set; } = new Color[2][];

        /// <summary>
        ///     Reads all paletted data from ROM and stores them into their appropriate arrays.
        /// </summary>
        /// <param name="romData"> The ROM to read from. </param>
        public static void CreateAllPalettes(byte[] romData)
        {
            // 35 colors each, 7x5 (0,2 on grid).
            for (int i = 0; i < 6; i++)
            {
                OverworldMainPalettes[i] = ReadPalette(romData, Constants.overworldPaletteMain + (i * (35 * 2)), 35);
            }

            // 21 colors each, 7x3 (8,2 and 8,5 on grid).
            for (int i = 0; i < 20; i++)
            {
                OverworldAuxPalettes[i] = ReadPalette(romData, Constants.overworldPaletteAuxialiary + (i * (21 * 2)), 21);
            }

            // 7 colors each 7x1 (0,7 on grid).
            for (int i = 0; i < 14; i++)
            {
                OverworldAnimatedPalettes[i] = ReadPalette(romData, Constants.overworldPaletteAnimated + (i * (7 * 2)), 7);
            }

            // 32 colors each 16x2 (0,0 on grid).
            for (int i = 0; i < 2; i++)
            {
                HudPalettes[i] = ReadPalette(romData, Constants.hudPalettes + (i * 64), 32);
            }

            /*
            public static Color[][] globalSprite_Palettes = new Color[2][]; // 32 (1,9)
            public static Color[][] armors_Palettes = new Color[5][]; // 15
            public static Color[][] swords_Palettes = new Color[4][]; // 3
            public static Color[][] spritesAux_Palettes = new Color[47][]; // 7
            public static Color[][] shields_Palettes = new Color[3][]; // 4
            public static Color[][] dungeonsMain_Palettes = new Color[20][]; // 15*6
            */

            GlobalSpritePalettes[0] = ReadPalette(romData, Constants.globalSpritePalettesLW, 60);
            GlobalSpritePalettes[1] = ReadPalette(romData, Constants.globalSpritePalettesDW, 60);
            for (int i = 0; i < 5; i++)
            {
                ArmorPalettes[i] = ReadPalette(romData, Constants.armorPalettes + (i * 30), 15);
            }

            for (int i = 0; i < 4; i++)
            {
                SwordsPalettes[i] = ReadPalette(romData, Constants.swordPalettes + (i * 6), 3);
            }

            for (int i = 0; i < 3; i++)
            {
                ShieldsPalettes[i] = ReadPalette(romData, Constants.shieldPalettes + (i * 8), 4);
            }

            for (int i = 0; i < 12; i++)
            {
                SpritesAux1Palettes[i] = ReadPalette(romData, Constants.spritePalettesAux1 + (i * 14), 7);
            }

            for (int i = 0; i < 11; i++)
            {
                SpritesAux2Palettes[i] = ReadPalette(romData, Constants.spritePalettesAux2 + (i * 14), 7);
            }

            for (int i = 0; i < 24; i++)
            {
                SpritesAux3Palettes[i] = ReadPalette(romData, Constants.spritePalettesAux3 + (i * 14), 7);
            }

            for (int i = 0; i < 20; i++)
            {
                DungeonsMainPalettes[i] = ReadPalette(romData, Constants.dungeonMainPalettes + (i * 180), 90);
            }

            OverworldGrassPalettes[0] = ReadPaletteSingle(romData, Constants.hardcodedGrassLW1);
            OverworldGrassPalettes[1] = ReadPaletteSingle(romData, Constants.hardcodedGrassDW1);
            OverworldGrassPalettes[2] = ReadPaletteSingle(romData, Constants.hardcodedGrassSpecial);

            Object3DPalettes[0] = ReadPalette(romData, Constants.triforcePalette, 8);
            Object3DPalettes[1] = ReadPalette(romData, Constants.crystalPalette, 8);

            for (int i = 0; i < 2; i++)
            {
                OverworldMiniMapPalettes[i] = ReadPalette(romData, Constants.overworldMiniMapPalettes + (i * 256), 128);
            }

            if (ROM.DATA[Constants.OverworldCustomASMHasBeenApplied] == 0x00)
            {
                // TODO: Magic colors.
                // LW
                int j = 0;
                while (j < 64)
                {
                    OverworldBackgroundPalette[j++] = Color.FromArgb(0xFF, 0x48, 0x98, 0x48);
                }

                // DW
                while (j < 128)
                {
                    OverworldBackgroundPalette[j++] = Color.FromArgb(0xFF, 0x90, 0x88, 0x50);
                }

                // SW
                while (j < Constants.NumberOfOWMaps)
                {
                    OverworldBackgroundPalette[j++] = Color.FromArgb(0xFF, 0x30, 0x70, 0x30);
                }

                // Certain other areas start out with a BG color of black so that the subscreen overlay BGs look correct.

                // LW Death Mountain
                OverworldBackgroundPalette[0x03] = Color.FromArgb(0x00, 0x00, 0x00, 0x00);
                OverworldBackgroundPalette[0x05] = Color.FromArgb(0x00, 0x00, 0x00, 0x00);
                OverworldBackgroundPalette[0x07] = Color.FromArgb(0x00, 0x00, 0x00, 0x00);

                // DW Death Mountain
                OverworldBackgroundPalette[0x43] = Color.FromArgb(0x00, 0x00, 0x00, 0x00);
                OverworldBackgroundPalette[0x45] = Color.FromArgb(0x00, 0x00, 0x00, 0x00);
                OverworldBackgroundPalette[0x47] = Color.FromArgb(0x00, 0x00, 0x00, 0x00);

                // The pyramid area
                OverworldBackgroundPalette[0x5B] = Color.FromArgb(0x00, 0x00, 0x00, 0x00);

                // Under the bridge area
                OverworldBackgroundPalette[0x94] = Color.FromArgb(0xFF, 0x48, 0x98, 0x48);
            }
            else
            {
                OverworldBackgroundPalette = ReadPalette(romData, Constants.OverworldCustomAreaSpecificBGPalette, 160);
            }
        }

        /// <summary>
        ///     Writes the given array of colors to the given ROM.
        /// </summary>
        /// <param name="romData"> The ROM to write to. </param>
        /// <param name="romPosition"> The position in the ROM to write to. </param>
        /// <param name="colors"> The colors to write. </param>
        /// <param name="max"> The max amount of colors to write. </param>
        public static void WritePalette(byte[] romData, int romPosition, Color[] colors, int max = -1)
        {
            if (max == -1)
            {
                max = colors.Length;
            }

            int colorPos = 0;
            while (colorPos < max)
            {
                short color = (short)(((colors[colorPos].B / 8) << 10) | ((colors[colorPos].G / 8) << 5) | (colors[colorPos].R / 8));
                romData[romPosition++] = (byte)color;
                romData[romPosition++] = (byte)(color >> 8);
                colorPos++;
            }
        }

        /// <summary>
        ///     Writes all palette data to the given ROM.
        /// </summary>
        /// <param name="romData"> The ROM to write to. </param>
        /// <returns> True if failed to write to ROM. </returns>
        public static bool SavePalettesToROM(byte[] romData)
        {
            WriteSinglePalette(romData, Constants.hardcodedGrassLW1, OverworldGrassPalettes[0]);
            WriteSinglePalette(romData, Constants.hardcodedGrassLW2, OverworldGrassPalettes[0]);
            WriteSinglePalette(romData, Constants.hardcodedGrassLW3, OverworldGrassPalettes[0]);
            WriteSinglePalette(romData, Constants.hardcodedGrassDW1, OverworldGrassPalettes[1]);
            WriteSinglePalette(romData, Constants.hardcodedGrassDW2, OverworldGrassPalettes[1]);
            WriteSinglePalette(romData, Constants.hardcodedGrassSpecial, OverworldGrassPalettes[2]);

            // 35 colors each, 7x5 (0,2 on grid).
            for (int i = 0; i < 6; i++)
            {
                WritePalette(romData, Constants.overworldPaletteMain + (i * (35 * 2)), OverworldMainPalettes[i]);
            }

            // 21 colors each, 7x3 (8,2 and 8,5 on grid).
            for (int i = 0; i < 20; i++)
            {
                WritePalette(romData, Constants.overworldPaletteAuxialiary + (i * (21 * 2)), OverworldAuxPalettes[i]);
            }

            // 7 colors each 7x1 (0,7 on grid).
            for (int i = 0; i < 14; i++)
            {
                WritePalette(romData, Constants.overworldPaletteAnimated + (i * (7 * 2)), OverworldAnimatedPalettes[i]);
            }

            // 32 colors each 16x2 (0,0 on grid).
            for (int i = 0; i < 2; i++)
            {
                WritePalette(romData, Constants.hudPalettes + (i * 64), HudPalettes[i]);
            }

            WritePalette(romData, Constants.globalSpritePalettesLW, GlobalSpritePalettes[0]);
            WritePalette(romData, Constants.globalSpritePalettesDW, GlobalSpritePalettes[1]);

            for (int i = 0; i < 5; i++)
            {
                WritePalette(romData, Constants.armorPalettes + (i * 30), ArmorPalettes[i]);
            }

            for (int i = 0; i < 4; i++)
            {
                WritePalette(romData, Constants.swordPalettes + (i * 6), SwordsPalettes[i]);
            }

            for (int i = 0; i < 3; i++)
            {
                WritePalette(romData, Constants.shieldPalettes + (i * 8), ShieldsPalettes[i]);
            }

            for (int i = 0; i < 12; i++)
            {
                WritePalette(romData, Constants.spritePalettesAux1 + (i * 14), SpritesAux1Palettes[i]);
            }

            for (int i = 0; i < 11; i++)
            {
                WritePalette(romData, Constants.spritePalettesAux2 + (i * 14), SpritesAux2Palettes[i]);
            }

            for (int i = 0; i < 24; i++)
            {
                WritePalette(romData, Constants.spritePalettesAux3 + (i * 14), SpritesAux3Palettes[i]);
            }

            for (int i = 0; i < 20; i++)
            {
                WritePalette(romData, Constants.dungeonMainPalettes + (i * 180), DungeonsMainPalettes[i]);
            }

            /* Removed because its dupicate code? Jared_Brain_
			WritePalette(romData, Constants.hardcodedGrassLW1, new Color[1] { overworld_GrassPalettes[0] });
			WritePalette(romData, Constants.hardcodedGrassDW1, new Color[1] { overworld_GrassPalettes[1] });
			WritePalette(romData, Constants.hardcodedGrassSpecial, new Color[1] { overworld_GrassPalettes[2] });
			*/

            WritePalette(romData, Constants.triforcePalette, Object3DPalettes[0]);
            WritePalette(romData, Constants.crystalPalette, Object3DPalettes[1]);

            for (int i = 0; i < 2; i++)
            {
                WritePalette(romData, Constants.overworldMiniMapPalettes + (i * 256), OverworldMiniMapPalettes[i]);
            }

            WritePalette(romData, Constants.OverworldCustomAreaSpecificBGPalette, OverworldBackgroundPalette, 160);

            return false;
        }

        private static Color[] ReadPalette(byte[] romData, int romPosition, int colorCount)
        {
            // Let's write new palette code since i can't find the old one :scream:.
            int colorPos = 0;
            Color[] colors = new Color[colorCount];
            while (colorPos < colorCount)
            {
                short color = (short)((romData[romPosition + 1] << 8) + romData[romPosition]);
                colors[colorPos] = Color.FromArgb((color & 0x1F) * 8, ((color >> 5) & 0x1F) * 8, ((color >> 10) & 0x1F) * 8);
                colorPos++;
                romPosition += 2;
            }

            return colors;
        }

        private static Color ReadPaletteSingle(byte[] romData, int romPosition)
        {
            // Let's write new palette code since i can't find the old one :scream:.
            Color colors;
            short color = (short)((romData[romPosition + 1] << 8) + romData[romPosition]);
            colors = Color.FromArgb((color & 0x1F) * 8, ((color >> 5) & 0x1F) * 8, ((color >> 10) & 0x1F) * 8);

            return colors;
        }

        private static void WriteSinglePalette(byte[] romData, int romPosition, Color colorC)
        {
            short color = (short)(((colorC.B / 8) << 10) | ((colorC.G / 8) << 5) | (colorC.R / 8));
            romData[romPosition] = (byte)color;
            romData[romPosition + 1] = (byte)(color >> 8);
        }

        #region Unused

        private static Color GetColorShade(Color col, byte shade)
        {
            int r = col.R;
            int g = col.G;
            int b = col.B;

            for (int i = 0; i < shade; i++)
            {
                r -= r / 5;
                g -= g / 5;
                b -= b / 5;
            }

            r = (int)(r / 255f * 0x1F);
            g = (int)(g / 255f * 0x1F);
            b = (int)(b / 255f * 0x1F);

            return Color.FromArgb(r * 8, g * 8, b * 8);
        }

		private static string SavePalettesToAsm(byte[] romData)
		{
			var asmString = new StringBuilder();

			WritePaletteAsm(OverworldGrassPalettes, 1, "Grass Color", Constants.hardcodedGrassLW1);

			// 35 colors each, 7x5 (0,2 on grid).
			for (int i = 0; i < 6; i++)
			{
				WritePaletteAsm(OverworldMainPalettes[i], 7, $"Main Overworld {i:X2}", Constants.overworldPaletteMain + (i * (35 * 2)));
			}

			// 21 colors each, 7x3 (8,2 and 8,5 on grid).
			for (int i = 0; i < 20; i++)
			{
				WritePaletteAsm(OverworldAuxPalettes[i], 7, $"Overworld Aux Palettes {i:X2}", Constants.overworldPaletteAuxialiary + (i * (21 * 2)));
			}

			// 7 colors each 7x1 (0,7 on grid).
			for (int i = 0; i < 14; i++)
			{
				WritePaletteAsm(OverworldAnimatedPalettes[i], 7, $"Overworld Animated Palettes {i:X2}", Constants.overworldPaletteAnimated + (i * (7 * 2)));
			}

			// 32 colors each 16x2 (0,0 on grid).
			for (int i = 0; i < 2; i++)
			{
				WritePaletteAsm(HudPalettes[i], 16, $"Hud Palettes {i:X2}", Constants.hudPalettes + (i * 64));
			}

			WritePaletteAsm(GlobalSpritePalettes[0], 15, "LW Global Sprite Palettes ", Constants.globalSpritePalettesLW);
			WritePaletteAsm(GlobalSpritePalettes[1], 15, "DW Global Sprite Palettes ", Constants.globalSpritePalettesDW);

			for (int i = 0; i < 5; i++)
			{
				WritePaletteAsm(ArmorPalettes[i], 16, $"Mails Palettes / bunny / electrocuted {i:X2}", Constants.armorPalettes + (i * 30));
			}

			for (int i = 0; i < 4; i++)
			{
				WritePaletteAsm(SwordsPalettes[i], 3, $"Sword Palettes {i:X2}", Constants.swordPalettes + (i * 6));
			}

			for (int i = 0; i < 3; i++)
			{
				WritePaletteAsm(ShieldsPalettes[i], 4, $"Shield Palettes {i:X2}", Constants.shieldPalettes + (i * 8));
			}

			for (int i = 0; i < 12; i++)
			{
				WritePaletteAsm(SpritesAux1Palettes[i], 7, $"Sprite Aux1 Palettes {i:X2}", Constants.spritePalettesAux1 + (i * 14));
			}

			for (int i = 0; i < 11; i++)
			{
				WritePaletteAsm(SpritesAux2Palettes[i], 7, $"Sprite Aux2 Palettes {i:X2}", Constants.spritePalettesAux2 + (i * 14));
			}

			for (int i = 0; i < 24; i++)
			{
				WritePaletteAsm(SpritesAux3Palettes[i], 7, $"Sprite Aux3 Palettes {i:X2}", Constants.spritePalettesAux3 + (i * 14));
			}

			for (int i = 0; i < 20; i++)
			{
				WritePaletteAsm(DungeonsMainPalettes[i], 15, $"Dungeon Palettes {i:X2}", Constants.dungeonMainPalettes + (i * 180));
			}

			WritePaletteAsm(new Color[1] { OverworldGrassPalettes[0] }, 1, "Hardcoded LW Overworld Grass Palettes", Constants.hardcodedGrassLW1);
			WritePaletteAsm(new Color[1] { OverworldGrassPalettes[1] }, 1, "Hardcoded DW Overworld Grass Palettes", Constants.hardcodedGrassDW1);
			WritePaletteAsm(new Color[1] { OverworldGrassPalettes[2] }, 1, "Hardcoded SP Overworld Grass Palettes", Constants.hardcodedGrassSpecial);

			WritePaletteAsm(Object3DPalettes[0], 8, "Triforce Palette", Constants.triforcePalette);
			WritePaletteAsm(Object3DPalettes[1], 8, "Crystal Palette", Constants.crystalPalette);

			for (int i = 0; i < 2; i++)
			{
				WritePaletteAsm(OverworldMiniMapPalettes[i], 16, $"Overworld Mini Map Palettes {i:X2}", Constants.overworldMiniMapPalettes + (i * 256));
			}

			return asmString.ToString();

			void WritePaletteAsm(Color[] colors, int width, string comment, int romPosition)
			{
				asmString.AppendLine();
				asmString.AppendLine();
				asmString.AppendLine($"; {comment}");
				asmString.AppendLine($"org ${romPosition.PcToSnes():X6}");

				var colS = colors.Select(c => $"${c.ToSNESColor():X4}").ToList();

				while (colS.Count > 0)
				{
					asmString.AppendLine($"\tdw {string.Join(", ", colS.Take(width))}");

					colS.RemoveRange(0, width);
				}
			}
		}

		#endregion
	}
}
