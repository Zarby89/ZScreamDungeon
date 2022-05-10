namespace ZeldaFullEditor
{
	public class OverworldScreen
	{
		public byte ParentMapID => ParentMap.MapID;

		public ScreenArtist MyArtist { get; }
		public OverworldScreen ParentMap { get; set; }

		public Worldiness World { get; }
		public bool IsOwnParent => ParentMap == this;

		public byte MapID { get; }

		public byte VirtualMapID => (byte) (MapID & 0x3F);

		public byte Tileset { get; set; }

		public byte ScreenPalette { get; set; }

		private byte state2gfx, state3gfx;
		private byte state2pal, state3pal;

		public byte State0SpriteGraphics { get; set; }
		public byte State2SpriteGraphics
		{
			get => World == Worldiness.LightWorld ? state2gfx : State0SpriteGraphics;
			set
			{
				if (World == Worldiness.LightWorld)
				{
					state2gfx = value;
				}
				else
				{
					State0SpriteGraphics = value;
				}
			}
		}
		public byte State3SpriteGraphics
		{
			get => World == Worldiness.LightWorld ? state3gfx : State0SpriteGraphics;
			set
			{
				if (World == Worldiness.LightWorld)
				{
					state3gfx = value;
				}
				else
				{
					State0SpriteGraphics = value;
				}
			}
		}

		public byte State0SpritePalette { get; set; }
		public byte State2SpritePalette
		{
			get => World == Worldiness.LightWorld ? state2pal : State0SpritePalette;
			set
			{
				if (World == Worldiness.LightWorld)
				{
					state2pal = value;
				}
				else
				{
					State0SpritePalette = value;
				}
			}
		}
		public byte State3SpritePalette
		{
			get => World == Worldiness.LightWorld ? state3pal : State0SpritePalette;
			set
			{
				if (World == Worldiness.LightWorld)
				{
					state3pal = value;
				}
				else
				{
					State0SpritePalette = value;
				}
			}
		}
		public byte[] sprpalette = new byte[3];
		public byte[] musics = new byte[4];
		public ushort MessageID { get; set; }

		public bool IsPartOfLargeMap { get; set; }

		public IntPtr gfxPtr = Marshal.AllocHGlobal(512 * 512); // Needs to be removed
																//public IntPtr blockset16 = Marshal.AllocHGlobal(1048576); // Needs to be removed
																//public Bitmap blocksetBitmap; // Needs to be removed
		public Bitmap gfxBitmap; // Needs to be removed

		public byte[] staticgfx = new byte[16]; // Need to be used to display map and not pre render it!
		public ushort[,] tilesUsed;

		public bool NeedsRefresh { get; set; }


		public OverworldScreen(byte index)
		{
			MyArtist = new ScreenArtist(this);

			MapID = index;
			if (MapID < 64)
			{
				World = Worldiness.LightWorld;
			}
			else if (MapID < 128)
			{
				World = Worldiness.DarkWorld;
			}
			else
			{
				World = Worldiness.SpecialWorld;
			}

			ParentMap = this;
		}

		public void HardRefresh()
		{
			throw new NotImplementedException();
		}

		public byte GetSpriteGraphicsForGameState(int gamestate)
		{
			return gamestate switch
			{
				0 => State0SpriteGraphics,
				1 => State2SpriteGraphics,
				2 => State3SpriteGraphics,
				_ => 0x00,
			};
		}

		public byte GetSpritePaletteForGameState(int gamestate)
		{
			return gamestate switch
			{
				0 => State0SpritePalette,
				1 => State2SpritePalette,
				2 => State3SpritePalette,
				_ => 0x00,
			};
		}


		public void CopyTile8bpp16(int x, int y, int tile)
		{
			//MyArtist.CopyTile8bpp16(x, y, tile);
		}
	}
}
