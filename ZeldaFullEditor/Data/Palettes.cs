using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public static class Palettes
	{
		public static Color[][] HudPalettes = new Color[2][]; // 32 (0,0)
		public static Color[][] overworld_MainPalettes = new Color[6][]; // 35 colors each, 7x5 (0,2 on grid)
		public static Color[][] overworld_AuxPalettes = new Color[20][]; // 21 colors each, 7x3 (8,2 and 8,5 on grid)
		public static Color[][] overworld_AnimatedPalettes = new Color[14][]; // 7 colors each 7x1 (0,7 on grid)
		public static Color[][] globalSprite_Palettes = new Color[2][]; // 60 (1,9) 
		public static Color[][] armors_Palettes = new Color[5][]; // 15
		public static Color[][] swords_Palettes = new Color[4][]; // 3
		public static Color[][] spritesAux1_Palettes = new Color[12][]; // 7
		public static Color[][] spritesAux2_Palettes = new Color[11][]; // 7
		public static Color[][] spritesAux3_Palettes = new Color[24][]; // 7
		public static Color[][] shields_Palettes = new Color[3][]; // 4
		public static Color[][] dungeonsMain_Palettes = new Color[20][]; // 15*6
		public static Color[] overworld_BackgroundPalette = new Color[Constants.NumberOfOWMaps]; // 8*20

		public static Color[] overworld_GrassPalettes = new Color[3]; // 3 hardcoded grass colors
		public static Color[][] object3D_Palettes = new Color[2][]; // 15*6
		public static Color[][] overworld_Mini_Map_Palettes = new Color[2][]; // 16*8

		static string asmString = "";

		public static Color[] ReadPalette(byte[] romData, int romPosition, int colorCount)
		{
			// Lets write new palette code since i can't find the old one :scream:
			int colorPos = 0;
			Color[] colors = new Color[colorCount];
			while (colorPos < colorCount)
			{
				short color = (short) ((romData[romPosition + 1] << 8) + romData[romPosition]);
				colors[colorPos] = Color.FromArgb((color & 0x1F) * 8, ((color >> 5) & 0x1F) * 8, ((color >> 10) & 0x1F) * 8);
				colorPos++;
				romPosition += 2;
			}

			return colors;
		}

		public static Color ReadPaletteSingle(byte[] romData, int romPosition)
		{
			// Lets write new palette code since i can't find the old one :scream:
			Color colors;
			short color = (short) ((romData[romPosition + 1] << 8) + romData[romPosition]);
			colors = Color.FromArgb((color & 0x1F) * 8, ((color >> 5) & 0x1F) * 8, ((color >> 10) & 0x1F) * 8);

			return colors;
		}

		public static void CreateAllPalettes(byte[] romData)
		{
			//public static Color[][] overworld_MainPalettes = new Color[6][]; 
			//public static Color[][] overworld_AuxPalettes = new Color[20][]; 
			//public static Color[][] overworld_AnimatedPalettes = new Color[14][]; 

			// 35 colors each, 7x5 (0,2 on grid)
			for (int i = 0; i < 6; i++)
			{
				overworld_MainPalettes[i] = ReadPalette(romData, Constants.overworldPaletteMain + (i * (35 * 2)), 35);
			}
			// 21 colors each, 7x3 (8,2 and 8,5 on grid)
			for (int i = 0; i < 20; i++)
			{
				overworld_AuxPalettes[i] = ReadPalette(romData, Constants.overworldPaletteAuxialiary + (i * (21 * 2)), 21);
			}
			// 7 colors each 7x1 (0,7 on grid)
			for (int i = 0; i < 14; i++)
			{
				overworld_AnimatedPalettes[i] = ReadPalette(romData, Constants.overworldPaletteAnimated + (i * (7 * 2)), 7);
			}
			// 32 colors each 16x2 (0,0 on grid)
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

			globalSprite_Palettes[0] = ReadPalette(romData, Constants.globalSpritePalettesLW, 60);
			globalSprite_Palettes[1] = ReadPalette(romData, Constants.globalSpritePalettesDW, 60);
			for (int i = 0; i < 5; i++)
			{
				armors_Palettes[i] = ReadPalette(romData, Constants.armorPalettes + (i * 30), 15);
			}
			for (int i = 0; i < 4; i++)
			{
				swords_Palettes[i] = ReadPalette(romData, Constants.swordPalettes + (i * 6), 3);
			}
			for (int i = 0; i < 3; i++)
			{
				shields_Palettes[i] = ReadPalette(romData, Constants.shieldPalettes + (i * 8), 4);
			}
			for (int i = 0; i < 12; i++)
			{
				spritesAux1_Palettes[i] = ReadPalette(romData, Constants.spritePalettesAux1 + (i * 14), 7);
			}
			for (int i = 0; i < 11; i++)
			{
				spritesAux2_Palettes[i] = ReadPalette(romData, Constants.spritePalettesAux2 + (i * 14), 7);
			}
			for (int i = 0; i < 24; i++)
			{
				spritesAux3_Palettes[i] = ReadPalette(romData, Constants.spritePalettesAux3 + (i * 14), 7);
			}
			for (int i = 0; i < 20; i++)
			{
				dungeonsMain_Palettes[i] = ReadPalette(romData, Constants.dungeonMainPalettes + (i * 180), 90);
			}

			overworld_GrassPalettes[0] = ReadPaletteSingle(romData, Constants.hardcodedGrassLW);
			overworld_GrassPalettes[1] = ReadPaletteSingle(romData, Constants.hardcodedGrassDW);
			overworld_GrassPalettes[2] = ReadPaletteSingle(romData, Constants.hardcodedGrassSpecial);

			object3D_Palettes[0] = ReadPalette(romData, Constants.triforcePalette, 8);
			object3D_Palettes[1] = ReadPalette(romData, Constants.crystalPalette, 8);

			for (int i = 0; i < 2; i++)
			{
				overworld_Mini_Map_Palettes[i] = ReadPalette(romData, Constants.overworldMiniMapPalettes + (i * 256), 128);
			}

			// TODO: check for the paletts in the empty bank space that kan will allocate and read them in here
			// TODO magic colors
			// LW
			int j = 0;
			while (j < 64)
			{
				overworld_BackgroundPalette[j++] = Color.FromArgb(0xFF, 0x48, 0x98, 0x48);
			}

			// DW
			while (j < 128)
			{
				overworld_BackgroundPalette[j++] = Color.FromArgb(0xFF, 0x90, 0x88, 0x50);
			}

			// SP
			while (j < Constants.NumberOfOWMaps)
			{
				overworld_BackgroundPalette[j++] = Color.FromArgb(0xFF, 0x48, 0x98, 0x48);
			}

			overworld_BackgroundPalette = ReadPalette(romData, Constants.customAreaSpecificBGPalette, 160);
		}

		public static Color getColorShade(Color col, byte shade)
		{
			int r = col.R;
			int g = col.G;
			int b = col.B;

			for (int i = 0; i < shade; i++)
			{
				r = (r - (r / 5));
				g = (g - (g / 5));
				b = (b - (b / 5));
			}

			r = (int) (r / 255f * 0x1F);
			g = (int) (g / 255f * 0x1F);
			b = (int) (b / 255f * 0x1F);

			return Color.FromArgb(r * 8, g * 8, b * 8);
		}

		public static void WritePalette(byte[] romData, int romPosition, Color[] colors, int max = -1)
		{
			if (max == -1)
			{
				max = colors.Length;
			}

			int colorPos = 0;
			while (colorPos < max)
			{
				short color = (short) (((colors[colorPos].B / 8) << 10) | ((colors[colorPos].G / 8) << 5) | ((colors[colorPos].R / 8)));
				romData[romPosition++] = (byte) (color);
				romData[romPosition++] = (byte) (color >> 8);
				colorPos++;
			}
		}

		public static void WriteSinglePalette(byte[] romData, int romPosition, Color colorC)
		{
			short color = (short) (((colorC.B / 8) << 10) | ((colorC.G / 8) << 5) | ((colorC.R / 8)));
			romData[romPosition] = (byte) (color);
			romData[romPosition + 1] = (byte) (color >> 8);
		}

		// TODO string.format and string builder
		public static void WritePaletteAsm(Color[] colors, int width, string comment, int romPosition)
		{
			string s = "\r\n\r\n\r\n;" + comment + "\r\norg $" + Utils.PcToSnes(romPosition).ToString("X6") + "\r\ndw ";
			int colorPos = 0;
			int x = 0;

			while (colorPos < colors.Length)
			{
				short color = (short) (((colors[colorPos].B / 8) << 10) | ((colors[colorPos].G / 8) << 5) | ((colors[colorPos].R / 8)));
				x++;

				if (x == width)
				{
					if (colorPos == colors.Length - 1)
					{
						s += "#$" + color.ToString("X4") + "\r\n";
					}
					else
					{
						s += "#$" + color.ToString("X4") + "\r\ndw ";
					}

					x = 0;
				}
				else
				{
					s += "#$" + color.ToString("X4") + ", ";
				}

				colorPos++;
			}

			asmString += s;
		}

		public static bool SavePalettesToROM(byte[] romData)
		{
			WriteSinglePalette(romData, Constants.hardcodedGrassLW, overworld_GrassPalettes[0]);
			WriteSinglePalette(romData, Constants.hardcodedGrassDW, overworld_GrassPalettes[1]);
			WriteSinglePalette(romData, Constants.hardcodedGrassSpecial, overworld_GrassPalettes[2]);

			// 35 colors each, 7x5 (0,2 on grid)
			for (int i = 0; i < 6; i++)
			{
				WritePalette(romData, Constants.overworldPaletteMain + (i * (35 * 2)), overworld_MainPalettes[i]);
			}
			// 21 colors each, 7x3 (8,2 and 8,5 on grid)
			for (int i = 0; i < 20; i++)
			{
				WritePalette(romData, Constants.overworldPaletteAuxialiary + (i * (21 * 2)), overworld_AuxPalettes[i]);
			}
			// 7 colors each 7x1 (0,7 on grid)
			for (int i = 0; i < 14; i++)
			{
				WritePalette(romData, Constants.overworldPaletteAnimated + (i * (7 * 2)), overworld_AnimatedPalettes[i]);
			}
			// 32 colors each 16x2 (0,0 on grid)
			for (int i = 0; i < 2; i++)
			{
				WritePalette(romData, Constants.hudPalettes + (i * 64), HudPalettes[i]);
			}

			WritePalette(romData, Constants.globalSpritePalettesLW, globalSprite_Palettes[0]);
			WritePalette(romData, Constants.globalSpritePalettesDW, globalSprite_Palettes[1]);

			for (int i = 0; i < 5; i++)
			{
				WritePalette(romData, Constants.armorPalettes + (i * 30), armors_Palettes[i]);
			}
			for (int i = 0; i < 4; i++)
			{
				WritePalette(romData, Constants.swordPalettes + (i * 6), swords_Palettes[i]);
			}
			for (int i = 0; i < 3; i++)
			{
				WritePalette(romData, Constants.shieldPalettes + (i * 8), shields_Palettes[i]);
			}
			for (int i = 0; i < 12; i++)
			{
				WritePalette(romData, Constants.spritePalettesAux1 + (i * 14), spritesAux1_Palettes[i]);
			}
			for (int i = 0; i < 11; i++)
			{
				WritePalette(romData, Constants.spritePalettesAux2 + (i * 14), spritesAux2_Palettes[i]);
			}
			for (int i = 0; i < 24; i++)
			{
				WritePalette(romData, Constants.spritePalettesAux3 + (i * 14), spritesAux3_Palettes[i]);
			}
			for (int i = 0; i < 20; i++)
			{
				WritePalette(romData, Constants.dungeonMainPalettes + (i * 180), dungeonsMain_Palettes[i]);
			}

			WritePalette(romData, Constants.hardcodedGrassLW, new Color[1] { overworld_GrassPalettes[0] });
			WritePalette(romData, Constants.hardcodedGrassDW, new Color[1] { overworld_GrassPalettes[1] });
			WritePalette(romData, Constants.hardcodedGrassSpecial, new Color[1] { overworld_GrassPalettes[2] });

			WritePalette(romData, Constants.triforcePalette, object3D_Palettes[0]);
			WritePalette(romData, Constants.crystalPalette, object3D_Palettes[1]);

			for (int i = 0; i < 2; i++)
			{
				WritePalette(romData, Constants.overworldMiniMapPalettes + (i * 256), overworld_Mini_Map_Palettes[i]);
			}

			WritePalette(romData, Constants.customAreaSpecificBGPalette, overworld_BackgroundPalette);

			return false;
		}

		public static string SavePalettesToAsm(byte[] romData)
		{
			asmString = "";
			WritePaletteAsm(overworld_GrassPalettes, 1, "Grass Color", Constants.hardcodedGrassLW);
			// 35 colors each, 7x5 (0,2 on grid)
			for (int i = 0; i < 6; i++)
			{
				WritePaletteAsm(overworld_MainPalettes[i], 7, "Main Overworld " + i.ToString("X2"), Constants.overworldPaletteMain + (i * (35 * 2)));
			}
			// 21 colors each, 7x3 (8,2 and 8,5 on grid)
			for (int i = 0; i < 20; i++)
			{
				WritePaletteAsm(overworld_AuxPalettes[i], 7, "Overworld Aux Palettes " + i.ToString("X2"), Constants.overworldPaletteAuxialiary + (i * (21 * 2)));
			}
			// 7 colors each 7x1 (0,7 on grid)
			for (int i = 0; i < 14; i++)
			{
				WritePaletteAsm(overworld_AnimatedPalettes[i], 7, "Overworld Animated Palettes " + i.ToString("X2"), Constants.overworldPaletteAnimated + (i * (7 * 2)));
			}
			// 32 colors each 16x2 (0,0 on grid)
			for (int i = 0; i < 2; i++)
			{
				WritePaletteAsm(HudPalettes[i], 16, "Hud Palettes " + i.ToString("X2"), Constants.hudPalettes + (i * 64));
			}

			WritePaletteAsm(globalSprite_Palettes[0], 15, "LW Global Sprite Palettes ", Constants.globalSpritePalettesLW);
			WritePaletteAsm(globalSprite_Palettes[1], 15, "DW Global Sprite Palettes ", Constants.globalSpritePalettesDW);
			for (int i = 0; i < 5; i++)
			{
				WritePaletteAsm(armors_Palettes[i], 16, "Mails Palettes / bunny / electrocuted " + i.ToString("X2"), Constants.armorPalettes + (i * 30));
			}
			for (int i = 0; i < 4; i++)
			{
				WritePaletteAsm(swords_Palettes[i], 3, "Sword Palettes " + i.ToString("X2"), Constants.swordPalettes + (i * 6));
			}
			for (int i = 0; i < 3; i++)
			{
				WritePaletteAsm(shields_Palettes[i], 4, "Shield Palettes " + i.ToString("X2"), Constants.shieldPalettes + (i * 8));
			}
			for (int i = 0; i < 12; i++)
			{
				WritePaletteAsm(spritesAux1_Palettes[i], 7, "Sprite Aux1 Palettes " + i.ToString("X2"), Constants.spritePalettesAux1 + (i * 14));
			}
			for (int i = 0; i < 11; i++)
			{
				WritePaletteAsm(spritesAux2_Palettes[i], 7, "Sprite Aux2 Palettes " + i.ToString("X2"), Constants.spritePalettesAux2 + (i * 14));
			}
			for (int i = 0; i < 24; i++)
			{
				WritePaletteAsm(spritesAux3_Palettes[i], 7, "Sprite Aux3 Palettes " + i.ToString("X2"), Constants.spritePalettesAux3 + (i * 14));
			}
			for (int i = 0; i < 20; i++)
			{
				WritePaletteAsm(dungeonsMain_Palettes[i], 15, "Dungeon Palettes " + i.ToString("X2"), Constants.dungeonMainPalettes + (i * 180));
			}

			WritePaletteAsm(new Color[1] { overworld_GrassPalettes[0] }, 1, "Hardcoded LW Overworld Grass Palettes", Constants.hardcodedGrassLW);
			WritePaletteAsm(new Color[1] { overworld_GrassPalettes[1] }, 1, "Hardcoded DW Overworld Grass Palettes", Constants.hardcodedGrassDW);
			WritePaletteAsm(new Color[1] { overworld_GrassPalettes[2] }, 1, "Hardcoded SP Overworld Grass Palettes", Constants.hardcodedGrassSpecial);

			WritePaletteAsm(object3D_Palettes[0], 8, "Triforce Palette", Constants.triforcePalette);
			WritePaletteAsm(object3D_Palettes[1], 8, "Crystal Palette", Constants.crystalPalette);

			for (int i = 0; i < 2; i++)
			{
				WritePaletteAsm(overworld_Mini_Map_Palettes[i], 16, "Overworld Mini Map Palettes " + i.ToString("X2"), Constants.overworldMiniMapPalettes + (i * 256));
			}

			return asmString;
		}
	}
}
