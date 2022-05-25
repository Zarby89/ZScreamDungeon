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

		public GraphicsSet LoadedGraphics { get; private set; }

		/// <summary>
		/// Gets his screen's corresponding <see cref="ScreenArtist"/>, which handles the graphical display of the screen.
		/// </summary>
		public ScreenArtist MyArtist { get; }

		private OverworldScreen parent;
		/// <summary>
		/// The <see cref="OverworldScreen"/> from which this screen should derive its graphics, sprites, and others properties.
		/// In essence, this is a reference to the screen which is the north-west corner of the containing screen when this
		/// map is part of a larger screen. When this screen is a normal sized screen, then this property should be a reference
		/// back to <see langword="this"/> screen.
		/// </summary>
		public OverworldScreen ParentMap
		{
			get => parent;
			set
			{
				parent = value;
				if (IsOwnParent) return;
				Tileset = parent.Tileset;
				MessageID = parent.MessageID;
				ScreenPalette = parent.ScreenPalette;
				State0SpriteGraphics = parent.State0SpriteGraphics;
				State2SpriteGraphics = parent.State2SpriteGraphics;
				State3SpriteGraphics = parent.State3SpriteGraphics;
				State0SpritePalette = parent.State0SpritePalette;
				State2SpritePalette = parent.State2SpritePalette;
				State3SpritePalette = parent.State3SpritePalette;
			}
		}

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

		private byte tileset;
		public byte Tileset
		{
			get => tileset;
			set
			{
				if (tileset == value) return;
				tileset = value;
				RefreshTileset();
			}
		}

		private byte screenpal;
		public byte ScreenPalette
		{
			get => screenpal;
			set
			{
				if (screenpal == value) return;
				screenpal = value;
				RefreshPalette();
			}
		}

		private byte state2gfx, state3gfx;
		private byte state2pal, state3pal;

		private byte state0gfx;
		public byte State0SpriteGraphics
		{
			get => state0gfx;
			set
			{
				if (state0gfx == value) return;
				state0gfx = value;
				RefreshTileset();
			}
		}

		public byte State2SpriteGraphics
		{
			get => World == Worldiness.LightWorld ? state2gfx : State0SpriteGraphics;
			set
			{
				if (World == Worldiness.LightWorld)
				{
					if (state2gfx == value) return;
					state2gfx = value;
					RefreshTileset();
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
					if (state3gfx == value) return;
					state3gfx = value;
					RefreshTileset();
				}
				else
				{
					State0SpriteGraphics = value;
				}
			}
		}

		private byte st0pal;

		public byte State0SpritePalette
		{
			get => st0pal;
			set
			{
				if (st0pal == value) return;
				st0pal = value;
				CGPaletteState0 = ZScreamer.ActivePaletteManager.CreateOverworldPalette(ScreenPalette, State0SpritePalette, World);
				NotifyArtist();
			}
		}
		public byte State2SpritePalette
		{
			get => World == Worldiness.LightWorld ? state2pal : State0SpritePalette;
			set
			{
				if (World == Worldiness.LightWorld)
				{
					if (state2pal == value) return;
					state2pal = value;
					CGPaletteState2 = ZScreamer.ActivePaletteManager.CreateOverworldPalette(ScreenPalette, State2SpritePalette, World);
					NotifyArtist();
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
					if (state3pal == value) return;
					state3pal = value;
					CGPaletteState3 = ZScreamer.ActivePaletteManager.CreateOverworldPalette(ScreenPalette, State3SpritePalette, World);
					NotifyArtist();
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


		public FullPalette CGPaletteState0 { get; private set; }
		public FullPalette CGPaletteState2 { get; private set; }
		public FullPalette CGPaletteState3 { get; private set; }

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
			NotifyArtist();
		}

		public void RefreshPalette()
		{
			
			CGPaletteState0 = ZScreamer.ActivePaletteManager.CreateOverworldPalette(ScreenPalette, State0SpritePalette, World);
			CGPaletteState2 = ZScreamer.ActivePaletteManager.CreateOverworldPalette(ScreenPalette, State2SpritePalette, World);
			CGPaletteState3 = ZScreamer.ActivePaletteManager.CreateOverworldPalette(ScreenPalette, State3SpritePalette, World);
			NotifyArtist();
		}

		public void RefreshTileset()
		{
			LoadedGraphics = ZScreamer.ActiveGraphicsManager.CreateOverworldGraphicsSet(Tileset, State0SpriteGraphics, World == Worldiness.DarkWorld);
			NotifyArtist();
		}

		public FullPalette GetPaletteForGameState(GameState gamestate) => gamestate switch
		{
			GameState.RainState => CGPaletteState0,
			GameState.UncleState => CGPaletteState0,
			GameState.RescueState => CGPaletteState2,
			GameState.AgaState => CGPaletteState3,
			_ => throw new ArgumentOutOfRangeException(nameof(gamestate), "BAD GAME STATE")
		};

		public void NotifyArtist()
		{
			MyArtist.Invalidate();
		}

		public byte GetSpriteGraphicsForGameState(GameState gamestate) => gamestate switch
		{
			GameState.RainState => State0SpriteGraphics,
			GameState.UncleState => State0SpriteGraphics,
			GameState.RescueState => State2SpriteGraphics,
			GameState.AgaState => State3SpriteGraphics,
			_ => 0x00,
		};

		public byte GetSpritePaletteForGameState(GameState gamestate) => gamestate switch
		{
			GameState.RainState => State0SpritePalette,
			GameState.UncleState => State0SpritePalette,
			GameState.RescueState => State2SpritePalette,
			GameState.AgaState => State3SpritePalette,
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
