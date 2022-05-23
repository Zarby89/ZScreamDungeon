using static ZeldaFullEditor.Modeling.GameData.GraphicsData.Palettes.PaletteType;

namespace ZeldaFullEditor.Modeling.GameData.GraphicsData.Palettes
{
	public class PaletteHandler
	{
		private static readonly ImmutableArray<PaletteInfo> AllPalettesMeta = new()
		{
			new(0x1BD218, FullSpritePalette),
			new(0x1BD290, FullSpritePalette),

			new(0x1BD308, MailPalette),
			new(0x1BD326, MailPalette),
			new(0x1BD344, MailPalette),
			new(0x1BD362, MailPalette),
			new(0x1BD380, MailPalette),

			new(0x1BD39E, SpriteAux1Palette),
			new(0x1BD3AC, SpriteAux1Palette),
			new(0x1BD3BA, SpriteAux1Palette),
			new(0x1BD3C8, SpriteAux1Palette),
			new(0x1BD3D6, SpriteAux1Palette),
			new(0x1BD3E4, SpriteAux1Palette),
			new(0x1BD3F2, SpriteAux1Palette),
			new(0x1BD400, SpriteAux1Palette),
			new(0x1BD40E, SpriteAux1Palette),
			new(0x1BD41C, SpriteAux1Palette),
			new(0x1BD42A, SpriteAux1Palette),
			new(0x1BD438, SpriteAux1Palette),

			new(0x1BD446, SpriteAux2Palette),
			new(0x1BD454, SpriteAux2Palette),
			new(0x1BD462, SpriteAux2Palette),
			new(0x1BD470, SpriteAux2Palette),
			new(0x1BD47E, SpriteAux2Palette),
			new(0x1BD48C, SpriteAux2Palette),
			new(0x1BD49A, SpriteAux2Palette),
			new(0x1BD4A8, SpriteAux2Palette),
			new(0x1BD4B6, SpriteAux2Palette),
			new(0x1BD4C4, SpriteAux2Palette),
			new(0x1BD4D2, SpriteAux2Palette),

			new(0x1BD4E0, SpriteAux3Palette),
			new(0x1BD4EE, SpriteAux3Palette),
			new(0x1BD4FC, SpriteAux3Palette),
			new(0x1BD50A, SpriteAux3Palette),
			new(0x1BD518, SpriteAux3Palette),
			new(0x1BD526, SpriteAux3Palette),
			new(0x1BD534, SpriteAux3Palette),
			new(0x1BD542, SpriteAux3Palette),
			new(0x1BD550, SpriteAux3Palette),
			new(0x1BD55E, SpriteAux3Palette),
			new(0x1BD56C, SpriteAux3Palette),
			new(0x1BD57A, SpriteAux3Palette),
			new(0x1BD588, SpriteAux3Palette),
			new(0x1BD596, SpriteAux3Palette),
			new(0x1BD5A4, SpriteAux3Palette),
			new(0x1BD5B2, SpriteAux3Palette),
			new(0x1BD5C0, SpriteAux3Palette),
			new(0x1BD5CE, SpriteAux3Palette),
			new(0x1BD5DC, SpriteAux3Palette),
			new(0x1BD5EA, SpriteAux3Palette),
			new(0x1BD5F8, SpriteAux3Palette),
			new(0x1BD606, SpriteAux3Palette),
			new(0x1BD614, SpriteAux3Palette),
			new(0x1BD622, SpriteAux3Palette),

			new(0x1BD630, SwordPalette),
			new(0x1BD636, SwordPalette),
			new(0x1BD63C, SwordPalette),
			new(0x1BD642, SwordPalette),

			new(0x1BD648, ShieldPalette),
			new(0x1BD650, ShieldPalette),
			new(0x1BD658, ShieldPalette),


			new(0x1BD660, HUDPalette),
			new(0x1BD668, HUDPalette),
			new(0x1BD670, HUDPalette),
			new(0x1BD678, HUDPalette),
			new(0x1BD680, HUDPalette),
			new(0x1BD688, HUDPalette),
			new(0x1BD690, HUDPalette),
			new(0x1BD698, HUDPalette),
			new(0x1BD6A0, HUDPalette),
			new(0x1BD6A8, HUDPalette),
			new(0x1BD6B0, HUDPalette),
			new(0x1BD6B8, HUDPalette),
			new(0x1BD6C0, HUDPalette),
			new(0x1BD6C8, HUDPalette),
			new(0x1BD6D0, HUDPalette),
			new(0x1BD6D8, HUDPalette),

			//new(0x1BD6E0, Unused),
			//new(0x1BD6E6, Unused),
			//new(0x1BD6EE, Unused),

			new(0x1BD70A, UWMapSpritePalette),

			new(0x1BD734, DungeonPalette),
			new(0x1BD7E8, DungeonPalette),
			new(0x1BD89C, DungeonPalette),
			new(0x1BD950, DungeonPalette),
			new(0x1BDA04, DungeonPalette),
			new(0x1BDAB8, DungeonPalette),
			new(0x1BDB6C, DungeonPalette),
			new(0x1BDC20, DungeonPalette),
			new(0x1BDCD4, DungeonPalette),
			new(0x1BDD88, DungeonPalette),
			new(0x1BDE3C, DungeonPalette),
			new(0x1BDEF0, DungeonPalette),
			new(0x1BDFA4, DungeonPalette),
			new(0x1BE058, DungeonPalette),
			new(0x1BE10C, DungeonPalette),
			new(0x1BE1C0, DungeonPalette),
			new(0x1BE274, DungeonPalette),
			new(0x1BE328, DungeonPalette),
			new(0x1BE3DC, DungeonPalette),
			new(0x1BE490, DungeonPalette),

			new(0x1BE544, UWMapPalette),

			new(0x1BE604, OWAnim),
			new(0x1BE612, OWAnim),
			new(0x1BE620, OWAnim),
			new(0x1BE62E, OWAnim),
			new(0x1BE63C, OWAnim),
			new(0x1BE64A, OWAnim),
			new(0x1BE658, OWAnim),
			new(0x1BE666, OWAnim),
			new(0x1BE674, OWAnim),
			new(0x1BE682, OWAnim),
			new(0x1BE690, OWAnim),
			new(0x1BE69E, OWAnim),
			new(0x1BE6AC, OWAnim),
			new(0x1BE6BA, OWAnim),

			new(0x1BE6C8, OWMain),
			new(0x1BE70E, OWMain),
			new(0x1BE754, OWMain),
			new(0x1BE79A, OWMain),
			new(0x1BE7E0, OWMain),
			new(0x1BE826, OWMain),

			new(0x1BE86C, OWAux),
			new(0x1BE896, OWAux),
			new(0x1BE8C0, OWAux),
			new(0x1BE8EA, OWAux),
			new(0x1BE914, OWAux),
			new(0x1BE93E, OWAux),
			new(0x1BE968, OWAux),
			new(0x1BE992, OWAux),
			new(0x1BE9BC, OWAux),
			new(0x1BE9E6, OWAux),
			new(0x1BEA10, OWAux),
			new(0x1BEA3A, OWAux),
			new(0x1BEA64, OWAux),
			new(0x1BEA8E, OWAux),
			new(0x1BEAB8, OWAux),
			new(0x1BEAE2, OWAux),
			new(0x1BEB0C, OWAux),
			new(0x1BEB36, OWAux),
			new(0x1BEB60, OWAux),
			new(0x1BEB8A, OWAux),

			//new(0x07F97B, MountainLightning),
			//new(0x07F989, MountainLightning),
			//new(0x07F997, MountainLightning),
			//new(0x07F9A5, MountainLightning),
			//new(0x07F9B3, MountainLightning),

			//new(0x07F9C1, GanonTowerFlash),
			//new(0x07F9D1, GanonTowerFlash),
			//new(0x07F9E1, GanonTowerFlash),
			//new(0x07F9F1, GanonTowerFlash),
			//new(0x07FA01, GanonTowerFlash),

			new(0x0CC3F3, PolyhedralPalette),
			new(0x1ECCCD, PolyhedralPalette),

			new(0x0ADB39, OWMapPalette),
			new(0x0ADC39, OWMapPalette),
		};

		public Dictionary<PaletteType, List<PartialPalette>> AllPalettes { get; } = new();

		public PartialPalette GetPaletteAt(PaletteType type, int index)
		{
			return AllPalettes[type][index];
		}







		public Color[][] HUD { get; set; } = new Color[2][]; // 32 (0,0)
		public Color[][] OverworldMain { get; set; } = new Color[6][]; // 35 colors each, 7x5 (0,2 on grid)
		public Color[][] OverworldAux { get; set; } = new Color[20][]; // 21 colors each, 7x3 (8,2 and 8,5 on grid)
		public Color[][] OverworldAnimated { get; set; } = new Color[14][]; // 7 colors each 7x1 (0,7 on grid)
		public Color[] OverworldGrass { get; set; } = new Color[3]; // 3 hardcoded grass colors
		public Color[][] PlayerMail { get; set; } = new Color[5][]; // 15
		public Color[][] PlayerSword { get; set; } = new Color[4][]; // 3
		public Color[][] PlayerShield { get; set; } = new Color[3][]; // 4
		public Color[][] SpriteGlobal { get; set; } = new Color[2][]; // 60 (1,9) 
		public Color[][] SpriteAux1 { get; set; } = new Color[12][]; // 7
		public Color[][] SpriteAux2 { get; set; } = new Color[11][]; // 7
		public Color[][] SpriteAux3 { get; set; } = new Color[24][]; // 7
		public Color[][] UnderworldMain { get; set; } = new Color[20][]; // 15*6
		public Color[][] Polyhedral { get; set; } = new Color[2][]; // 15*6
		public Color[] OverworldBackground { get; set; } = new Color[Constants.NumberOfOWMaps]; // 8*20

		private readonly ZScreamer ZS;
		public PaletteHandler(ZScreamer zs)
		{
			ZS = zs;
		}

		public void CreateAllPalettes()
		{
			foreach (var i in AllPalettesMeta)
			{
				// Create new list for this type, if necessary
				List<PartialPalette> pset;

				if (AllPalettes.ContainsKey(i.Type))
				{
					pset = AllPalettes[i.Type];
				}
				else
				{
					pset = new();
					AllPalettes[i.Type] = pset;
				}

				var coldata = ZS.ROM.Read16Many(i.Address.SNEStoPC(), i.Type.GetRealSize());

				pset.Add(new(coldata, i));

			}

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

		public void SavePalettesToROM()
		{
			foreach (var (_, list) in AllPalettes)
			{
				foreach (var pal in list)
				{
					ZS.ROM.Write(pal.Info.Address.SNEStoPC(), pal.GetByteData());
				}
			}

			WriteSinglePalette(ZS.Offsets.hardcodedGrassLW, OverworldGrass[0]);
			WriteSinglePalette(ZS.Offsets.hardcodedGrassDW, OverworldGrass[1]);
			WriteSinglePalette(ZS.Offsets.hardcodedGrassSpecial, OverworldGrass[2]);
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
