namespace ZeldaFullEditor.Modeling.GameData.GraphicsData
{
	public class PaletteHandler
	{
		public Color[][] HUD = new Color[2][]; // 32 (0,0)
		public Color[][] OverworldMain = new Color[6][]; // 35 colors each, 7x5 (0,2 on grid)
		public Color[][] OverworldAux = new Color[20][]; // 21 colors each, 7x3 (8,2 and 8,5 on grid)
		public Color[][] OverworldAnimated = new Color[14][]; // 7 colors each 7x1 (0,7 on grid)
		public Color[] OverworldGrass = new Color[3]; // 3 hardcoded grass colors
		public Color[][] PlayerMail = new Color[5][]; // 15
		public Color[][] PlayerSword = new Color[4][]; // 3
		public Color[][] PlayerShield = new Color[3][]; // 4
		public Color[][] SpriteGlobal = new Color[2][]; // 60 (1,9) 
		public Color[][] SpriteAux1 = new Color[12][]; // 7
		public Color[][] SpriteAux2 = new Color[11][]; // 7
		public Color[][] SpriteAux3 = new Color[24][]; // 7
		public Color[][] UnderworldMain = new Color[20][]; // 15*6
		public Color[][] Polyhedral = new Color[2][]; // 15*6
		public Color[] OverworldBackground = new Color[Constants.NumberOfOWMaps]; // 8*20

		private string asmString = "";

		private readonly ZScreamer ZS;
		public PaletteHandler(ZScreamer zs)
		{
			ZS = zs;
		}

		public Color ReadPaletteSingle(int romPosition)
		{
			// Lets write new palette code since i can't find the old one :scream:
			return ZS.ROM.Read16(romPosition).ToColor();
		}

		public Color[] ReadPalette(int address, int count)
		{
			// Lets write new palette code since i can't find the old one :scream:
			var colors = new Color[count];

			for (var i = 0; i < count; i++)
			{
				colors[i] = ZS.ROM.Read16(address).ToColor();
				address += 2;
			}

			return colors;
		}

		public void CreateAllPalettes()
		{
			//public static Color[][] overworld_MainPalettes = new Color[6][]; 
			//public static Color[][] overworld_AuxPalettes = new Color[20][]; 
			//public static Color[][] overworld_AnimatedPalettes = new Color[14][]; 
			OverworldGrass[0] = ReadPaletteSingle(ZS.Offsets.hardcodedGrassLW);
			OverworldGrass[1] = ReadPaletteSingle(ZS.Offsets.hardcodedGrassDW);
			OverworldGrass[2] = ReadPaletteSingle(ZS.Offsets.hardcodedGrassSpecial);

			// 35 colors each, 7x5 (0,2 on grid)
			for (var i = 0; i < 6; i++)
			{
				OverworldMain[i] = ReadPalette(ZS.Offsets.overworldPaletteMain + i * 35 * 2, 35);
			}
			// 21 colors each, 7x3 (8,2 and 8,5 on grid)
			for (var i = 0; i < 20; i++)
			{
				OverworldAux[i] = ReadPalette(ZS.Offsets.overworldPaletteAuxialiary + i * 21 * 2, 21);
			}
			// 7 colors each 7x1 (0,7 on grid)
			for (var i = 0; i < 14; i++)
			{
				OverworldAnimated[i] = ReadPalette(ZS.Offsets.overworldPaletteAnimated + i * 7 * 2, 7);
			}
			// 32 colors each 16x2 (0,0 on grid)
			for (var i = 0; i < 2; i++)
			{
				HUD[i] = ReadPalette(ZS.Offsets.hudPalettes + i * 64, 32);
			}

			/*
            public static Color[][] globalSprite_Palettes = new Color[2][]; // 32 (1,9)
            public static Color[][] armors_Palettes = new Color[5][]; // 15
            public static Color[][] swords_Palettes = new Color[4][]; // 3
            public static Color[][] spritesAux_Palettes = new Color[47][]; // 7
            public static Color[][] shields_Palettes = new Color[3][]; // 4
            public static Color[][] dungeonsMain_Palettes = new Color[20][]; // 15*6
            */

			SpriteGlobal[0] = ReadPalette(ZS.Offsets.globalSpritePalettesLW, 60);
			SpriteGlobal[1] = ReadPalette(ZS.Offsets.globalSpritePalettesDW, 60);

			for (var i = 0; i < 5; i++)
			{
				PlayerMail[i] = ReadPalette(ZS.Offsets.armorPalettes + i * 30, 15);
			}

			for (var i = 0; i < 4; i++)
			{
				PlayerSword[i] = ReadPalette(ZS.Offsets.swordPalettes + i * 6, 3);
			}

			for (var i = 0; i < 3; i++)
			{
				PlayerShield[i] = ReadPalette(ZS.Offsets.shieldPalettes + i * 8, 4);
			}

			for (var i = 0; i < 12; i++)
			{
				SpriteAux1[i] = ReadPalette(ZS.Offsets.spritePalettesAux1 + i * 14, 7);
			}

			for (var i = 0; i < 11; i++)
			{
				SpriteAux2[i] = ReadPalette(ZS.Offsets.spritePalettesAux2 + i * 14, 7);
			}

			for (var i = 0; i < 24; i++)
			{
				SpriteAux3[i] = ReadPalette(ZS.Offsets.spritePalettesAux3 + i * 14, 7);
			}

			for (var i = 0; i < 20; i++)
			{
				UnderworldMain[i] = ReadPalette(ZS.Offsets.dungeonMainPalettes + i * 180, 90);
			}
			/*
            for (int i = 0; i < 20; i++)
            {
                object3D_Palettes[i] = ReadPalette(romData, Constants.dungeonMainPalettes + (i * 180), 90);
            }
            */

			// TODO: check for the paletts in the empty bank space that kan will allocate and read them in here
			// TODO magic colors
			// LW
			var j = 0;
			while (j < 64)
			{
				OverworldBackground[j++] = Color.FromArgb(0xFF, 0x48, 0x98, 0x48);
			}

			// DW
			while (j < 128)
			{
				OverworldBackground[j++] = Color.FromArgb(0xFF, 0x90, 0x88, 0x50);
			}

			// SP
			while (j < Constants.NumberOfOWMaps)
			{
				OverworldBackground[j++] = Color.FromArgb(0xFF, 0x48, 0x98, 0x48);
			}
		}

		public static Color getColorShade(Color col, byte shade)
		{
			int r = col.R;
			int g = col.G;
			int b = col.B;

			for (var i = 0; i < shade; i++)
			{
				r -= r / 5;
				g -= g / 5;
				b -= b / 5;
			}

			r = (int) (r / 255f * 0x1F);
			g = (int) (g / 255f * 0x1F);
			b = (int) (b / 255f * 0x1F);

			return Color.FromArgb(r * 8, g * 8, b * 8);
		}

		public void WritePalette(int address, Color[] colors, int max = -1)
		{
			if (max == -1)
			{
				max = colors.Length;
			}

			for (var i = 0; i < max; i++)
			{
				ZS.ROM.Write16(address, colors[i].To555Short());
				address += 2;
			}
		}

		public void WriteSinglePalette(int address, Color col)
		{
			ZS.ROM.Write16(address, col.To555Short());
		}

		// TODO string.format and string builder
		public void WritePaletteAsm(Color[] colors, int width, string comment, int address)
		{
			var s = "\r\n\r\n\r\n;" + comment + "\r\norg $" + address.PCtoSNES().ToString("X6") + "\r\ndw ";
			var x = 0;

			for (var i = 0; i < colors.Length; i++)
			{
				var color = colors[i].To555Short(); ;
				x++;

				if (x == width)
				{
					s += "$" + color.ToString("X4") + "\r\n";

					if (i < colors.Length)
					{
						s += "dw ";
					}

					x = 0;
				}
				else
				{
					s += "$" + color.ToString("X4") + ", ";
				}
			}

			asmString += s;
		}

		public void SavePalettesToROM()
		{
			WriteSinglePalette(ZS.Offsets.hardcodedGrassLW, OverworldGrass[0]);
			WriteSinglePalette(ZS.Offsets.hardcodedGrassDW, OverworldGrass[1]);
			WriteSinglePalette(ZS.Offsets.hardcodedGrassSpecial, OverworldGrass[2]);

			// 35 colors each, 7x5 (0,2 on grid)
			for (var i = 0; i < 6; i++)
			{
				WritePalette(ZS.Offsets.overworldPaletteMain + i * 35 * 2, OverworldMain[i]);
			}
			// 21 colors each, 7x3 (8,2 and 8,5 on grid)
			for (var i = 0; i < 20; i++)
			{
				WritePalette(ZS.Offsets.overworldPaletteAuxialiary + i * 21 * 2, OverworldAux[i]);
			}
			// 7 colors each 7x1 (0,7 on grid)
			for (var i = 0; i < 14; i++)
			{
				WritePalette(ZS.Offsets.overworldPaletteAnimated + i * 7 * 2, OverworldAnimated[i]);
			}
			// 32 colors each 16x2 (0,0 on grid)
			for (var i = 0; i < 2; i++)
			{
				WritePalette(ZS.Offsets.hudPalettes + i * 64, HUD[i]);
			}

			WritePalette(ZS.Offsets.globalSpritePalettesLW, SpriteGlobal[0]);
			WritePalette(ZS.Offsets.globalSpritePalettesDW, SpriteGlobal[1]);

			for (var i = 0; i < 5; i++)
			{
				WritePalette(ZS.Offsets.armorPalettes + i * 30, PlayerMail[i]);
			}
			for (var i = 0; i < 4; i++)
			{
				WritePalette(ZS.Offsets.swordPalettes + i * 6, PlayerSword[i]);
			}
			for (var i = 0; i < 3; i++)
			{
				WritePalette(ZS.Offsets.shieldPalettes + i * 8, PlayerShield[i]);
			}
			for (var i = 0; i < 12; i++)
			{
				WritePalette(ZS.Offsets.spritePalettesAux1 + i * 14, SpriteAux1[i]);
			}
			for (var i = 0; i < 11; i++)
			{
				WritePalette(ZS.Offsets.spritePalettesAux2 + i * 14, SpriteAux2[i]);
			}
			for (var i = 0; i < 24; i++)
			{
				WritePalette(ZS.Offsets.spritePalettesAux3 + i * 14, SpriteAux3[i]);
			}
			for (var i = 0; i < 20; i++)
			{
				WritePalette(ZS.Offsets.dungeonMainPalettes + i * 180, UnderworldMain[i]);
			}
		}

		public string SavePalettesToAsm()
		{
			asmString = "";
			WritePaletteAsm(OverworldGrass, 1, "Grass Color", ZS.Offsets.hardcodedGrassLW);
			// 35 colors each, 7x5 (0,2 on grid)
			for (var i = 0; i < 6; i++)
			{
				WritePaletteAsm(OverworldMain[i], 7, "Main Overworld " + i.ToString("X2"), ZS.Offsets.overworldPaletteMain + i * 35 * 2);
			}
			// 21 colors each, 7x3 (8,2 and 8,5 on grid)
			for (var i = 0; i < 20; i++)
			{
				WritePaletteAsm(OverworldAux[i], 7, "Overworld Aux Palettes " + i.ToString("X2"), ZS.Offsets.overworldPaletteAuxialiary + i * 21 * 2);
			}
			// 7 colors each 7x1 (0,7 on grid)
			for (var i = 0; i < 14; i++)
			{
				WritePaletteAsm(OverworldAnimated[i], 7, "Overworld Animated Palettes " + i.ToString("X2"), ZS.Offsets.overworldPaletteAnimated + i * 7 * 2);
			}
			// 32 colors each 16x2 (0,0 on grid)
			for (var i = 0; i < 2; i++)
			{
				WritePaletteAsm(HUD[i], 16, "Hud Palettes " + i.ToString("X2"), ZS.Offsets.hudPalettes + i * 64);
			}

			WritePaletteAsm(SpriteGlobal[0], 15, "LW Global Sprite Palettes ", ZS.Offsets.globalSpritePalettesLW);
			WritePaletteAsm(SpriteGlobal[1], 15, "DW Global Sprite Palettes ", ZS.Offsets.globalSpritePalettesDW);
			for (var i = 0; i < 5; i++)
			{
				WritePaletteAsm(PlayerMail[i], 16, "Mails Palettes / bunny / electrocuted " + i.ToString("X2"), ZS.Offsets.armorPalettes + i * 30);
			}
			for (var i = 0; i < 4; i++)
			{
				WritePaletteAsm(PlayerSword[i], 3, "Sword Palettes " + i.ToString("X2"), ZS.Offsets.swordPalettes + i * 6);
			}
			for (var i = 0; i < 3; i++)
			{
				WritePaletteAsm(PlayerShield[i], 4, "Shield Palettes " + i.ToString("X2"), ZS.Offsets.shieldPalettes + i * 8);
			}
			for (var i = 0; i < 12; i++)
			{
				WritePaletteAsm(SpriteAux1[i], 7, "Sprite Aux1 Palettes " + i.ToString("X2"), ZS.Offsets.spritePalettesAux1 + i * 14);
			}
			for (var i = 0; i < 11; i++)
			{
				WritePaletteAsm(SpriteAux2[i], 7, "Sprite Aux2 Palettes " + i.ToString("X2"), ZS.Offsets.spritePalettesAux2 + i * 14);
			}
			for (var i = 0; i < 24; i++)
			{
				WritePaletteAsm(SpriteAux3[i], 7, "Sprite Aux3 Palettes " + i.ToString("X2"), ZS.Offsets.spritePalettesAux3 + i * 14);
			}
			for (var i = 0; i < 20; i++)
			{
				WritePaletteAsm(UnderworldMain[i], 15, "Dungeon Palettes " + i.ToString("X2"), ZS.Offsets.dungeonMainPalettes + i * 180);
			}

			return asmString;
		}

		private Color[,] lastDungeonPalette;

		public Color[,] LoadDungeonPalette(byte id)
		{
			var palettes = new Color[16, 8];

			// id = dungeon palette id
			var dungeon_palette_ptr = ZS.GFXManager.paletteGfx[id][0];
			int paletteid = ZS.ROM.Read16(0xDEC4B + dungeon_palette_ptr);
			var pId = paletteid / 180;

			var i = 0;

			var j = 0;
			for (var y = 0; y < 2; y++)
			{
				for (var x = 0; x < 16; x++)
				{
					palettes[x, y] = HUD[0][j++];
				}
			}

			for (var y = 2; y < 8; y++)
			{
				for (var x = 0; x < 16; x++)
				{
					if (x == 0)
					{
						palettes[x, y] = Color.Black;
						continue;
					}

					palettes[x, y] = UnderworldMain[pId][i];
					if (x == 8)
					{
						palettes[x, y] = Color.Black;
					}

					i++;
				}
			}

			lastDungeonPalette = palettes;
			return palettes;
		}


		public Color[,] GetSpritePaletteSet(byte id)
		{
			var palettes = new Color[16, 8];
			var sprite1_palette_ptr = ZS.ROM[ZS.Offsets.dungeons_palettes_groups + id * 4 + 1];
			var sprite2_palette_ptr = (byte) (ZS.ROM[ZS.Offsets.dungeons_palettes_groups + id * 4 + 2] * 2);
			var sprite3_palette_ptr = (byte) (ZS.ROM[ZS.Offsets.dungeons_palettes_groups + id * 4 + 3] * 2);

			ushort palette_pos1 = ZS.ROM[0xDEBC6 + sprite1_palette_ptr];
			var palette_pos2 = ZS.ROM.Read16(0xDEBD6 + sprite2_palette_ptr);
			var palette_pos3 = ZS.ROM.Read16(0xDEBD6 + sprite3_palette_ptr);

			// ID = dungeon palette id
			palettes[9, 5] = PlayerSword[0][0];
			palettes[10, 5] = PlayerSword[0][1];
			palettes[11, 5] = PlayerSword[0][2];
			palettes[12, 5] = PlayerShield[0][0];
			palettes[13, 5] = PlayerShield[0][1];
			palettes[14, 5] = PlayerShield[0][2];
			palettes[15, 5] = PlayerShield[0][3];

			for (var x = 0; x < 15; x++)
			{
				if (x < 7)
				{
					palettes[x + 1, 0] = SpriteAux1[palette_pos1 / 14][x];
					palettes[x + 1, 5] = SpriteAux3[palette_pos2 / 14][x];
					palettes[x + 1, 6] = SpriteAux3[palette_pos3 / 14][x];
				}
				else
				{
					palettes[x + 1, 0] = lastDungeonPalette[x - 7, 2];
					if (x < 14)
					{
						palettes[x + 2, 6] = SpriteAux2[10][x - 7];
					}
				}
				palettes[x + 1, 1] = SpriteGlobal[0][x];
				palettes[x + 1, 2] = SpriteGlobal[0][x + 15];
				palettes[x + 1, 3] = SpriteGlobal[0][x + 30];
				palettes[x + 1, 4] = SpriteGlobal[0][x + 45];
			}

			return palettes;
		}
	}
}
