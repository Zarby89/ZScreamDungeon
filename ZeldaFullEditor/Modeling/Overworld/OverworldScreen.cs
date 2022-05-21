namespace ZeldaFullEditor.Modeling.Overworld
{
	public class OverworldScreen
	{
		public ushort[] Tile16Map { get; } = new ushort[Constants.NumberOfTile16PerScreen];

		/// <summary>
		/// Gets the in-game value of this screen's ID.
		/// </summary>
		public byte MapID { get; }

		/// <summary>
		/// Gets the world this screen appears in, as determined by its <see cref="MapID">MapID</see>.
		/// </summary>
		public Worldiness World { get; }

		/// <summary>
		/// Gets the lower 6 bits of this screen's <see cref="MapID">MapID</see>.
		/// </summary>
		public byte VirtualMapID => (byte) (MapID & 0x3F);

		/// <summary>
		/// Gets his screen's corresponding <see cref="ScreenArtist"/>, which handles the graphical display of the screen.
		/// </summary>
		public ScreenArtist MyArtist { get; }

		/// <summary>
		/// The <see cref="OverworldScreen"/> from which this screen should derive its graphics, sprites, and others properties.
		/// In essence, this is a reference to the screen which is the north-west corner of the containing screen when this
		/// map is part of a larger screen. When this screen is a normal sized screen, then this property should be a reference
		/// back to <see langword="this"/> screen.
		/// </summary>
		public OverworldScreen ParentMap { get; set; }

		/// <summary>
		/// Whether or not this screen's <see cref="ParentMap">ParentMap</see> is
		/// a reference back to <see langword="this"/> screen.
		/// Note that this property being <see langword="true"/> is not the same as this map screen being part
		/// of a larger screen (<see cref="IsPartOfLargeMap">IsPartOfLargeMap</see>).
		/// </summary>
		public bool IsOwnParent => ParentMap == this;

		/// <summary>
		/// The map ID of this screen's <see cref="ParentMap">ParentMap</see>.
		/// </summary>
		public byte ParentMapID => ParentMap.MapID;

		/// <summary>
		/// Whether or not this screen is a smaller constituent of a larger screen.
		/// </summary>
		public bool IsPartOfLargeMap { get; set; }

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

		public byte[] musics { get; } = new byte[4];

		public ushort MessageID { get; set; }

		public byte[] staticgfx = new byte[16]; // Need to be used to display map and not pre render it!
		public ushort[,] tilesUsed;


		public OverworldScreen(byte index)
		{
			MyArtist = new ScreenArtist(this);

			MapID = index;

			World = MapID switch
			{
				< 64 => Worldiness.LightWorld,
				>= 64 and < 128 => Worldiness.DarkWorld,
				_ => Worldiness.SpecialWorld
			};

			ParentMap = this;
			NotifyArtistOfChange();
		}

		public void HardRefresh()
		{
			MyArtist.HardRefresh();
			throw new NotImplementedException();
		}

		public void NotifyArtistOfChange()
		{

		}

		public byte GetSpriteGraphicsForGameState(int gamestate) => gamestate switch
		{
			0 => State0SpriteGraphics,
			1 => State2SpriteGraphics,
			2 => State3SpriteGraphics,
			_ => 0x00,
		};

		public byte GetSpritePaletteForGameState(int gamestate) => gamestate switch
		{
			0 => State0SpritePalette,
			1 => State2SpritePalette,
			2 => State3SpritePalette,
			_ => 0x00,
		};


		public void SetTile16At(ushort tile, int x, int y)
		{
			Tile16Map[x + y * Constants.NumberOfTile16PerStrip] = tile;
		}

		public void CopyTile8bpp16(int x, int y, int tile)
		{
			//MyArtist.CopyTile8bpp16(x, y, tile);
		}
	}
}
