using static ZeldaFullEditor.ALTTP.GameData.GraphicsData.Palettes.PaletteType;

namespace ZeldaFullEditor.ALTTP.GameData.GraphicsData.Palettes
{
	public class PaletteHandler
	{
		private const int BGPalIndex0 = 0 * 16;
		private const int BGPalIndex1 = 1 * 16;
		private const int BGPalIndex2 = 2 * 16;
		private const int BGPalIndex3 = 3 * 16;
		private const int BGPalIndex4 = 4 * 16;
		private const int BGPalIndex5 = 5 * 16;
		private const int BGPalIndex6 = 6 * 16;
		private const int BGPalIndex7 = 7 * 16;
		private const int SPRPalIndex0 = 8 * 16;
		private const int SPRPalIndex1 = 9 * 16;
		private const int SPRPalIndex2 = 10 * 16;
		private const int SPRPalIndex3 = 11 * 16;
		private const int SPRPalIndex4 = 12 * 16;
		private const int SPRPalIndex5 = 13 * 16;
		private const int SPRPalIndex6 = 14 * 16;
		private const int SPRPalIndex7 = 15 * 16;

		private static readonly ImmutableArray<PaletteInfo> AllPalettesMeta = new PaletteInfo[]
		{
			new(0x1BD308, MailPalette),
			new(0x1BD326, MailPalette),
			new(0x1BD344, MailPalette),
			new(0x1BD362, MailPalette),
			new(0x1BD380, MailPalette),

			new(0x1BD630, SwordPalette),
			new(0x1BD636, SwordPalette),
			new(0x1BD63C, SwordPalette),
			new(0x1BD642, SwordPalette),

			new(0x1BD648, ShieldPalette),
			new(0x1BD650, ShieldPalette),
			new(0x1BD658, ShieldPalette),

			new(0x1BD218, FullSpritePalette),
			new(0x1BD290, FullSpritePalette),

			new(0x1BD39E, SpritePal0),
			new(0x1BD3AC, SpritePal0),
			new(0x1BD3BA, SpritePal0),
			new(0x1BD3C8, SpritePal0),
			new(0x1BD3D6, SpritePal0),
			new(0x1BD3E4, SpritePal0),
			new(0x1BD3F2, SpritePal0),
			new(0x1BD400, SpritePal0),
			new(0x1BD40E, SpritePal0),
			new(0x1BD41C, SpritePal0),
			new(0x1BD42A, SpritePal0),
			new(0x1BD438, SpritePal0),

			new(0x1BD446, SpriteEnvironment),
			new(0x1BD454, SpriteEnvironment),
			new(0x1BD462, SpriteEnvironment),
			new(0x1BD470, SpriteEnvironment),
			new(0x1BD47E, SpriteEnvironment),
			new(0x1BD48C, SpriteEnvironment),
			new(0x1BD49A, SpriteEnvironment),
			new(0x1BD4A8, SpriteEnvironment),
			new(0x1BD4B6, SpriteEnvironment),
			new(0x1BD4C4, SpriteEnvironment),
			new(0x1BD4D2, SpriteEnvironment),

			new(0x1BD4E0, SpriteAux),
			new(0x1BD4EE, SpriteAux),
			new(0x1BD4FC, SpriteAux),
			new(0x1BD50A, SpriteAux),
			new(0x1BD518, SpriteAux),
			new(0x1BD526, SpriteAux),
			new(0x1BD534, SpriteAux),
			new(0x1BD542, SpriteAux),
			new(0x1BD550, SpriteAux),
			new(0x1BD55E, SpriteAux),
			new(0x1BD56C, SpriteAux),
			new(0x1BD57A, SpriteAux),
			new(0x1BD588, SpriteAux),
			new(0x1BD596, SpriteAux),
			new(0x1BD5A4, SpriteAux),
			new(0x1BD5B2, SpriteAux),
			new(0x1BD5C0, SpriteAux),
			new(0x1BD5CE, SpriteAux),
			new(0x1BD5DC, SpriteAux),
			new(0x1BD5EA, SpriteAux),
			new(0x1BD5F8, SpriteAux),
			new(0x1BD606, SpriteAux),
			new(0x1BD614, SpriteAux),
			new(0x1BD622, SpriteAux),

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
			
			new(0x1BE544, UWMapPalette),
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

			new(0x0CC425, PolyhedralPalette), // JP : 0x0CC3F3
			new(0x1ECCD3, PolyhedralPalette), // JP : 0x1ECCCD

			new(0x0ADB27, OWMapPalette), // JP : 0x0ADB39
			new(0x0ADC47, OWMapPalette), // JP : 0x0ADC39
		}.ToImmutableArray();

		public Dictionary<PaletteType, List<PartialPalette>> AllPalettes { get; } = new();

		public PaletteSet[] AllPaletteSets { get; } = new PaletteSet[72];
		public OverworldSpritePaletteSet[] OWSpritePaletteSets { get; } = new OverworldSpritePaletteSet[20];

		public PartialPalette GetPaletteAt(PaletteType type, int index)
		{
			int i = type switch
			{
				DungeonPalette => index / 2,
				_ => index,
			};

			return AllPalettes[type][i];
		}



		public Color[][] HUD { get; set; } = new Color[2][]; // 32 (0,0)
		public Color[][] OverworldMain { get; set; } = new Color[6][]; // 35 colors each, 7x5 (0,2 on grid)
		public Color[][] OverworldAux { get; set; } = new Color[20][]; // 21 colors each, 7x3 (8,2 and 8,5 on grid)
		public Color[][] OverworldAnimated { get; set; } = new Color[14][]; // 7 colors each 7x1 (0,7 on grid)
		public Color[] OverworldGrass { get; set; } = new Color[3]; // 3 hardcoded grass colors
		public Color[][] PlayerMail { get; set; } = new Color[5][]; // 15


		public Color[][] SpriteGlobal { get; set; } = new Color[2][]; // 60 (1,9) 
		public Color[][] SpriteAux1 { get; set; } = new Color[12][]; // 7

		public Color[][] SpriteAux3 { get; set; } = new Color[24][]; // 7

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
				var pset = AllPalettes.GetOrMakeListForKey(i.Type);

				int size = i.Type.GetRealSize();
				var coldata = ZS.ROM.Read16Many(i.Address.SNEStoPC(), size);

				var parsed = new SNESColor[size];

				for (int a = 0; a < size; a++)
				{
					parsed[a] = SNESColor.FromUnsignedShort(coldata[a]);
				}

				pset.Add(new(parsed, i));

			}

			var offset = ZS.Offsets.dungeons_palettes_groups;

			for (var i = 0; i < AllPaletteSets.Length; i++)
			{
				AllPaletteSets[i] = new()
				{
					Palette0 = ZS.ROM[offset++],
					Palette1 = ZS.ROM[offset++],
					Palette2 = ZS.ROM[offset++],
					Palette3 = ZS.ROM[offset++],
				};
			}

			for (var i = 0; i < OWSpritePaletteSets.Length; i++)
			{
				OWSpritePaletteSets[i] = new()
				{
					Palette0 = ZS.ROM[offset++],
					Palette1 = ZS.ROM[offset++],
				};
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
				ZS.ROM.Write16(address, SNESColor.FromColor(colors[i]).CGRAMValue);
				address += 2;
			}
		}

		public void WriteSinglePalette(int address, Color col)
		{
			ZS.ROM.Write16(address, SNESColor.FromColor(col).CGRAMValue);
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

			int offset = ZS.Offsets.dungeons_palettes_groups;

			foreach (var s in AllPaletteSets)
			{
				ZS.ROM.WriteContinuous(ref offset, s.GetByteData());
			}

			foreach (var s in OWSpritePaletteSets)
			{
				ZS.ROM[offset++] = s.Palette0;
				ZS.ROM[offset++] = s.Palette1;
			}

			WriteSinglePalette(ZS.Offsets.hardcodedGrassLW, OverworldGrass[0]);
			WriteSinglePalette(ZS.Offsets.hardcodedGrassDW, OverworldGrass[1]);
			WriteSinglePalette(ZS.Offsets.hardcodedGrassSpecial, OverworldGrass[2]);
		}

		public FullPalette CreateOverworldPalette(byte mainid, byte bgid, byte sprid, Worldiness w)
		{
			// TODO where is animated from
			FullPalette ret = new();

			if (bgid > 31) return ret;
			var bgpal = AllPaletteSets[bgid + 41];
			var sprpal = OWSpritePaletteSets[sprid];

			AddPartialPaletteToFullPalette(ret, OWMain, mainid, BGPalIndex2);

			AddPartialPaletteToFullPalette(ret, OWAux, bgpal.Palette0, BGPalIndex2 + 9);
			AddPartialPaletteToFullPalette(ret, OWAux, bgpal.Palette1, BGPalIndex5 + 9);
			AddPartialPaletteToFullPalette(ret, OWAnim, bgpal.Palette2, BGPalIndex7 + 1);

			AddPartialPaletteToFullPalette(ret, SpriteAux, sprpal.Palette0, SPRPalIndex5 + 1);
			AddPartialPaletteToFullPalette(ret, SpriteAux, sprpal.Palette1, SPRPalIndex6 + 1);

			AddPartialPaletteToFullPalette(ret, SpriteAux, 
				(w == Worldiness.LightWorld) ? 7 : 8,
				SPRPalIndex6 + 9);

			AddHUDToFullPalette(ret);
			AddLinkColorsToFullPalette(ret);

			return ret;
		}


		public FullPalette CreateDungeonPalette(byte setid)
		{
			FullPalette ret = new();

			var palset = AllPaletteSets[setid];

			AddPartialPaletteToFullPalette(ret, DungeonPalette, palset.Palette0, BGPalIndex2);
			AddPartialPaletteToFullPalette(ret, FullSpritePalette, 0, SPRPalIndex1);

			AddPartialPaletteToFullPalette(ret, SpritePal0, palset.Palette1, SPRPalIndex5 + 1);
			AddPartialPaletteToFullPalette(ret, SpriteEnvironment, 10, SPRPalIndex6 + 9);

			ret.DuplicateHalfPalette(BGPalIndex2, SPRPalIndex0 + 8);

			AddHUDToFullPalette(ret);
			AddLinkColorsToFullPalette(ret);

			return ret;
		}

		private void AddPartialPaletteToFullPalette(FullPalette fullpal, PaletteType type, int paletteid, int index)
		{
			// TODO
			if (paletteid == 0xFF) return;
			
			fullpal.AddPartialPalette(GetPaletteAt(type, paletteid), index);
		}

		private void AddHUDToFullPalette(FullPalette pal)
		{
			for (int i = 0, index = BGPalIndex0; i < 8; i++, index += 4)
			{
				AddPartialPaletteToFullPalette(pal, HUDPalette, i, index);
			}
		}

		private void AddLinkColorsToFullPalette(FullPalette pal)
		{

			AddPartialPaletteToFullPalette(pal, MailPalette, 0, SPRPalIndex7 + 1);
			AddPartialPaletteToFullPalette(pal, SwordPalette, 1, SPRPalIndex5 + 9);
			AddPartialPaletteToFullPalette(pal, ShieldPalette, 1, SPRPalIndex5 + 9 + 3);
		}
	}
}
