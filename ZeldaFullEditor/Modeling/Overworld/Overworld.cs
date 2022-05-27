namespace ZeldaFullEditor.Modeling.Overworld
{
	public class Overworld
	{
		public List<Tile32> Tile32List;
		public Tile16MasterSheet Tile16Sheet { get; } = new Tile16MasterSheet();

		private int[] map32address;

		public List<Tile32> t32Unique = new();
		public List<ushort> t32;

		public OverworldExit[] allexits = new OverworldExit[Constants.NumberOfOverworldExits];

		public byte[] allTilesTypes = new byte[0x200];


		// That must stay global - that's a problem
		public ushort[,] allmapsTilesLW = new ushort[512, 512]; //64 maps * (32*32 tiles)
		public ushort[,] allmapsTilesDW = new ushort[512, 512]; //64 maps * (32*32 tiles)
		public ushort[,] allmapsTilesSP = new ushort[512, 512]; //32 maps * (32*32 tiles)
		public OverworldScreen[] allmaps = new OverworldScreen[Constants.NumberOfOWMaps];
		public OverworldEntrance[] allentrances = new OverworldEntrance[129];
		public OverworldEntrance[] allholes = new OverworldEntrance[0x13];
		public List<OverworldSecret> allitems = new();
		public OverlayData[] alloverlays = new OverlayData[128];

		public List<OverworldSprite> RainStateSprites { get; set; } = new();
		public List<OverworldSprite> RescueStateSprites { get; set; } = new();
		public List<OverworldSprite> AgaStateSprites { get; set; } = new();

		public List<OverworldSprite> CurrentStateSprites => GetSpritesForState(ActiveGameState);

		public List<OverworldSprite> GetSpritesForState(GameState state) => state switch {
			GameState.RainState => RainStateSprites,
			GameState.UncleState => RainStateSprites,
			GameState.RescueState => RescueStateSprites,
			GameState.AgaState => AgaStateSprites,
			_ => throw new ArgumentOutOfRangeException($"Invalid {nameof(GameState)}")
		};


		// TOGO ugh
		public Worldiness World { get; set; } = Worldiness.LightWorld;
		public int WorldOffset => (int) World;
		public int WorldOffsetEnd => WorldOffset + 64;

		// TODO : Fix Whirlpool on large maps
		public List<OverworldTransport> AllTransports = new();
		public List<OverworldTransport> allBirds = new();

		public GameState ActiveGameState { get; set; } = GameState.RescueState;
		public byte ActiveGameStateIndex => (byte) ActiveGameState;

		public Gravestone[] graves = new Gravestone[Constants.NumberOfOverworldGraves];

		public int tiles32count = 0;

		public ZScreamer ZS { get; }

		public Overworld(ZScreamer zs)
		{
			ZS = zs;
			Tile32List = new List<Tile32>();

			t32 = new List<ushort>();
		}

		public void Init()
		{
			AssembleTile32Definitions();
			AssembleTile16Definitions();
			DecompressAllMapTiles();
			loadOverlays();
			loadTilesTypes();
			LoadGravestoneData();

			// initialize as objects first to avoid null pointers
			for (byte i = 0; i < Constants.NumberOfOWMaps; i++)
			{
				allmaps[i] = new OverworldScreen(i);
			}

			foreach (var map in allmaps)
			{
				map.MessageID = ZS.ROM.Read16(ZS.Offsets.overworldMessages + map.MapID * 2);

				if (map.MapID < 0x80)
				{
					map.IsPartOfLargeMap = ZS.ROM[ZS.Offsets.overworldMapSize + map.VirtualMapID] != 0;
				}
				else if (map.MapID > 0x80)
				{
					map.IsPartOfLargeMap = map.MapID == 129 || map.MapID == 130 || map.MapID == 137 || map.MapID == 138;
				} // nothing for exactly 128

				if (map.IsPartOfLargeMap && map.IsOwnParent) // this should properly hit the top left corner first always
				{
					allmaps[map.MapID + 1].ParentMap = map;
					allmaps[map.MapID + 8].ParentMap = map;
					allmaps[map.MapID + 9].ParentMap = map;
				}

				switch (map.World)
				{
					case Worldiness.LightWorld:
						map.State0SpriteGraphics = ZS.ROM[ZS.Offsets.overworldSpriteset + map.MapID];
						map.State2SpriteGraphics = ZS.ROM[ZS.Offsets.overworldSpriteset + map.MapID + 64];
						map.State3SpriteGraphics = ZS.ROM[ZS.Offsets.overworldSpriteset + map.MapID + 128];
						map.Tileset = ZS.ROM[ZS.Offsets.OverworldIDToMainGFXSet + map.MapID];
						map.ScreenPalette = ZS.ROM[ZS.Offsets.overworldMapPalette + map.MapID];
						map.State0SpritePalette = ZS.ROM[ZS.Offsets.overworldSpritePalette + map.MapID];
						map.State2SpritePalette = ZS.ROM[ZS.Offsets.overworldSpritePalette + map.MapID + 64];
						map.State3SpritePalette = ZS.ROM[ZS.Offsets.overworldSpritePalette + map.MapID + 128];
						map.musics[0] = ZS.ROM[ZS.Offsets.overworldMusicBegining + map.MapID];
						map.musics[1] = ZS.ROM[ZS.Offsets.overworldMusicZelda + map.MapID];
						map.musics[2] = ZS.ROM[ZS.Offsets.overworldMusicMasterSword + map.MapID];
						map.musics[3] = ZS.ROM[ZS.Offsets.overworldMusicAgahim + map.MapID];
						break;

					case Worldiness.DarkWorld:
						map.State0SpriteGraphics = ZS.ROM[ZS.Offsets.overworldSpriteset + map.MapID + 128];
						map.State2SpriteGraphics = ZS.ROM[ZS.Offsets.overworldSpriteset + map.MapID + 128];
						map.State3SpriteGraphics = ZS.ROM[ZS.Offsets.overworldSpriteset + map.MapID + 128];
						map.Tileset = ZS.ROM[ZS.Offsets.OverworldIDToMainGFXSet + map.MapID];
						map.ScreenPalette = ZS.ROM[ZS.Offsets.overworldMapPalette + map.MapID];
						map.State0SpritePalette = ZS.ROM[ZS.Offsets.overworldSpritePalette + map.MapID + 128];
						map.State2SpritePalette = ZS.ROM[ZS.Offsets.overworldSpritePalette + map.MapID + 128];
						map.State3SpritePalette = ZS.ROM[ZS.Offsets.overworldSpritePalette + map.MapID + 128];
						map.musics[0] = ZS.ROM[ZS.Offsets.overworldMusicDW + map.VirtualMapID];
						break;

					case Worldiness.SpecialWorld when map.MapID < Constants.NumberOfRealOWMaps:
						// TODO prevent message IDs?
						map.MessageID = ZS.ROM[ZS.Offsets.overworldMessages + map.MapID];

						// TODO verify this
						map.State0SpriteGraphics = ZS.ROM[ZS.Offsets.overworldSpriteset + map.MapID];
						map.State2SpriteGraphics = ZS.ROM[ZS.Offsets.overworldSpriteset + map.MapID];
						map.State3SpriteGraphics = ZS.ROM[ZS.Offsets.overworldSpriteset + map.MapID];
						map.State0SpritePalette = ZS.ROM[ZS.Offsets.overworldSpritePalette + map.MapID];
						map.State2SpritePalette = ZS.ROM[ZS.Offsets.overworldSpritePalette + map.MapID];
						map.State3SpritePalette = ZS.ROM[ZS.Offsets.overworldSpritePalette + map.MapID];

						map.ScreenPalette = ZS.ROM[ZS.Offsets.overworldSpecialPALGroup + map.VirtualMapID];
						break;

					default:
						if (map.MapID == 0x88)
						{
							map.Tileset = 81;
							map.ScreenPalette = 0;
						}
						else if (map.MapID is >= 0x80 and <= 0x8A or 0x94)
						{
							map.Tileset = ZS.ROM[ZS.Offsets.overworldSpecialGFXGroup + map.VirtualMapID];
							map.ScreenPalette = ZS.ROM[ZS.Offsets.overworldSpecialPALGroup + 1];
						}
						else // Pyramid bg use 0x5B map
						{
							map.Tileset = ZS.ROM[ZS.Offsets.OverworldIDToMainGFXSet + map.MapID];
							map.ScreenPalette = ZS.ROM[ZS.Offsets.overworldMapPalette + map.MapID];
						}
						break;
				}
			}

			LoadOverworldExitsFromROM();
			LoadOverworldEntrancesFromROM();
			LoadOverworldSecretsFromROM();
			LoadOverworldTransportsFromROM();
			LoadOverworldSpritesFromROM();
			ZS.GFXManager.loadOverworldMap();

			new Thread(() =>
			{
				Thread.CurrentThread.IsBackground = true;
				ForAllScreens(map => map.InvalidateArtist());
			}).Start();
		}

		public void loadTilesTypes()
		{
			for (var i = 0; i < 0x200; i++)
			{
				allTilesTypes[i] = ZS.ROM[ZS.Offsets.overworldTilesType + i];
			}
		}

		/// <summary>
		/// Performs some action on screen IDs 0x00 to 0x7F
		/// </summary>
		public void ForAllMainScreens(Action<OverworldScreen> action)
		{
			for (int i = 0; i < 128; i++)
			{
				action(allmaps[i]);
			}
		}

		/// <summary>
		/// Performs some action on every screen
		/// </summary>
		public void ForAllScreens(Action<OverworldScreen> action)
		{
			foreach(var map in allmaps)
			{
				action(map);
			}
		}



		public void LoadGravestoneData()
		{
			for (int i = 0, j = 0; i < Constants.NumberOfOverworldGraves; i++, j += 2)
			{
				var x = ZS.ROM.Read16(ZS.Offsets.GravesXTilePos + j);
				var y = ZS.ROM.Read16(ZS.Offsets.GravesYTilePos + j);
				var gfx = ZS.ROM.Read16(ZS.Offsets.GravesGFX + j);
				var tilemap = ZS.ROM.Read16(ZS.Offsets.GravesTilemapPos + j);
				graves[i] = new(x, y, tilemap, gfx);
			}
		}

		public void AssembleTile16Definitions()
		{
			var tpos = ZS.Offsets.Map16DefinitionAddress;
			for (ushort i = 0; i < Constants.NumberOfUniqueTile16Definitions; i += 1)
			{
				Tile t0 = new(ZS.ROM.Read16(tpos));
				tpos += 2;
				Tile t1 = new(ZS.ROM.Read16(tpos));
				tpos += 2;
				Tile t2 = new(ZS.ROM.Read16(tpos));
				tpos += 2;
				Tile t3 = new(ZS.ROM.Read16(tpos));
				tpos += 2;

				Tile16Sheet.SetTile16At(i, new(t0, t1, t2, t3));
			}
		}

		public void SaveTile16DefinitionsToROM()
		{
			ZS.ROM.Write(ZS.Offsets.Map16DefinitionAddress, Tile16Sheet.GetByteData());
		}

		public void AssembleTile32Definitions()
		{
			map32address = new int[]
			{
				ZS.Offsets.Map32DefinitionsTL,
				ZS.Offsets.Map32DefinitionsTR,
				ZS.Offsets.Map32DefinitionsBL,
				ZS.Offsets.Map32DefinitionsBR
			};

			// TODO magic number
			for (var i = 0; i < 0x33F0; i += 6)
			{
				ushort tl, tr, bl, br;

				for (var k = 0; k < 4; k++)
				{
					tl = generate(i, k, (int) Dimension.Map32DefinitionsTL);
					tr = generate(i, k, (int) Dimension.Map32DefinitionsTR);
					bl = generate(i, k, (int) Dimension.Map32DefinitionsBL);
					br = generate(i, k, (int) Dimension.Map32DefinitionsBR);
					Tile32List.Add(new Tile32(tl, tr, bl, br));
				}
			}
		}

		private enum Dimension
		{
			Map32DefinitionsTL = 0,
			Map32DefinitionsTR = 1,
			Map32DefinitionsBL = 2,
			Map32DefinitionsBR = 3
		}

		// this is fucking stupid and needs to be destroyed what the fuck
		private ushort generate(int i, int k, int dimension)
		{
			return (ushort) (ZS.ROM[map32address[dimension] + k + i]
				+ (ZS.ROM[map32address[dimension] + i + (k <= 1 ? 4 : 5)] >> (k % 2 == 0 ? 4 : 0) & 0x0F) * 256);
		}

		public void DecompressAllMapTiles()
		{
			var lowest = 0x0FFFFF;
			var highest = 0x0F8000;
			//int npos = 0;
			var sx = 0;
			var sy = 0;
			var c = 0;
			//int furthestPtr = 0;

			for (var i = 0; i < Constants.NumberOfOWMaps; i++)
			{
				var p1 = ZS.ROM.Read24(ZS.Offsets.compressedAllMap32PointersHigh + 3 * i).SNEStoPC();
				var p2 = ZS.ROM.Read24(ZS.Offsets.compressedAllMap32PointersLow + 3 * i).SNEStoPC();

				var ttpos = 0;
				var compressedSize1 = 0;
				var compressedSize2 = 0;

				if (p1 >= highest)
				{
					highest = p1;
				}
				if (p2 >= highest)
				{
					highest = p2;
				}

				if (p1 <= lowest && p1 > 0x0F8000)
				{
					lowest = p1;
				}
				if (p2 <= lowest && p2 > 0x0F8000)
				{
					lowest = p2;
				}

				var bytes = Decompress.ALTTPDecompressOverworld(ZS.ROM.DataStream, p2, 1000, ref compressedSize1);
				var bytes2 = Decompress.ALTTPDecompressOverworld(ZS.ROM.DataStream, p1, 1000, ref compressedSize2);

				/* if (p1 > furthestPtr)
				 {
					 furthestPtr = p1;
				 }
				 if (p2 > furthestPtr)
				 {
					 furthestPtr = p2;
				 }

				 if (i == 159)
				 {
					 Console.WriteLine(furthestPtr.ToString("X6") + " Length " + bytes.Length.ToString("X4"));
				 }*/
				var buffer = i switch
				{
					< 64 => allmapsTilesLW,
					>= 128 => allmapsTilesSP,
					_ => allmapsTilesDW,
				};

				var sx2 = sx << 5;
				var sy2 = sy << 5;

				for (var y = sy2; y < sy2 + 16 * 2; y += 2)
				{
					for (var x = sx2; x < sx2 + 16 * 2; x += 2)
					{
						var tpos = (ushort) (bytes2[ttpos] << 8 | bytes[ttpos]);
						if (tpos < Tile32List.Count)
						{
							//map16tiles[npos] = new Tile32(tiles32[tpos].tile0, tiles32[tpos].tile1, tiles32[tpos].tile2, tiles32[tpos].tile3);


							buffer[x, y] = Tile32List[tpos].Tile0;
							buffer[x + 1, y] = Tile32List[tpos].Tile1;
							buffer[x, y + 1] = Tile32List[tpos].Tile2;
							buffer[x + 1, y + 1] = Tile32List[tpos].Tile3;
						}

						ttpos++;
					}
				}

				sx++;
				if (sx >= 8)
				{
					sy++;
					sx = 0;

				}

				c++;
				if (c >= 64)
				{
					sx = 0;
					sy = 0;
					c = 0;
				}
			}
		}

		public void CreateMap32Definitions()
		{
			t32.Clear();
			tiles32count = 0;

			var creating = new Tile32[Constants.NumberOfTile32Total];

			for (var i = 0; i < Constants.NumberOfTile32Total; i++)
			{
				ushort? foundIndex = null;
				for (var j = 0; j < tiles32count; j++)
				{
					if (t32Unique[j].Tile0 == creating[i].Tile0 &&
						t32Unique[j].Tile1 == creating[i].Tile1 &&
						t32Unique[j].Tile2 == creating[i].Tile2 &&
						t32Unique[j].Tile3 == creating[i].Tile3)
					{
						foundIndex = (ushort) j;
						break;
					}
				}

				if (foundIndex == null)
				{
					t32Unique[tiles32count] = new Tile32(creating[i].Tile0, creating[i].Tile1, creating[i].Tile2, creating[i].Tile3);
					t32.Add((ushort) tiles32count);
					tiles32count++;
				}
				else
				{
					t32.Add((ushort) foundIndex);
				}
			}
		}

		/*
            for (int i = 0; i < 128; i++)
            {
                byte m = entranceOWs[i].entranceId;
                short s = (short)(entranceOWs[i].mapId);
                int p = entranceOWs[i].mapPos >> 1;
                int x = (p % 64);
                int y = (p >> 6);
                entranceOWsEditor[i] = new EntranceOWEditor((x * 16) + (((s % 64) - (((s % 64) / 8) * 8)) * 512), (y * 16) + (((s % 64) / 8) * 512), m, s, entranceOWs[i].mapPos);
            }
         */
		public void LoadOverworldExitsFromROM()
		{
			for (int i = 0, j = 0; i < Constants.NumberOfOverworldExits; i++, j += 2)
			{
				var py = ZS.ROM.Read16(ZS.Offsets.OWExitYPlayer + j);
				var px = ZS.ROM.Read16(ZS.Offsets.OWExitXPlayer + j);

				allexits[i] = new OverworldExit(
					ZS.ROM.Read16(ZS.Offsets.OWExitRoomId + j),
					ZS.ROM[ZS.Offsets.OWExitMapId + i],
					ZS.ROM.Read16(ZS.Offsets.OWExitVram + j),
					ZS.ROM.Read16(ZS.Offsets.OWExitYScroll + j),
					ZS.ROM.Read16(ZS.Offsets.OWExitXScroll + j),
					py,
					px,
					ZS.ROM.Read16(ZS.Offsets.OWExitYCamera + j),
					ZS.ROM.Read16(ZS.Offsets.OWExitXCamera + j),
					ZS.ROM[ZS.Offsets.OWExitUnk1 + j],
					ZS.ROM[ZS.Offsets.OWExitUnk2 + j],
					ZS.ROM.Read16(ZS.Offsets.OWExitDoorType1 + j),
					ZS.ROM.Read16(ZS.Offsets.OWExitDoorType2 + j)
				);
			}
		}

		public void LoadOverworldTransportsFromROM()
		{
			for (int i = 0, j = 0; i < 0x11; i++, j += 2)
			{
				ushort e10;

				if (i > 8)
				{
					e10 = ZS.ROM.Read16(ZS.Offsets.OWWhirlpoolPosition - 18 + j);
				}
				else
				{
					e10 = ZS.ROM.Read16(ZS.Offsets.OWWhirlpoolPosition + j);
				}

				AllTransports.Add(
					new OverworldTransport(
						ZS.ROM[ZS.Offsets.OWExitMapIdWhirlpool + j],
						ZS.ROM.Read16(ZS.Offsets.OWExitVramWhirlpool + j),
						ZS.ROM.Read16(ZS.Offsets.OWExitYScrollWhirlpool + j),
						ZS.ROM.Read16(ZS.Offsets.OWExitXScrollWhirlpool + j),
						ZS.ROM.Read16(ZS.Offsets.OWExitYPlayerWhirlpool + j),
						ZS.ROM.Read16(ZS.Offsets.OWExitXPlayerWhirlpool + j),
						ZS.ROM.Read16(ZS.Offsets.OWExitYCameraWhirlpool + j),
						ZS.ROM.Read16(ZS.Offsets.OWExitXCameraWhirlpool + j),
						ZS.ROM[ZS.Offsets.OWExitUnk1Whirlpool + i],
						ZS.ROM[ZS.Offsets.OWExitUnk2Whirlpool + i],
						e10
					));
			}
		}


		public void LoadOverworldEntrancesFromROM()
		{
			for (int i = 0, j = 0; i < 129; i++, j += 2)
			{
				var mapId = ZS.ROM.Read16(ZS.Offsets.OWEntranceMap + j);
				var mapPos = ZS.ROM.Read16(ZS.Offsets.OWEntrancePos + j);
				var entranceId = ZS.ROM[ZS.Offsets.OWEntranceEntranceId + i];
				var p = mapPos >> 1;
				var x = p & 0x3F;
				var y = p >> 6;
				var eo = new OverworldEntrance(
					(ushort) (x * 16 + (mapId & 0x7) * 512),
					(ushort) (y * 16 + mapId % 64 / 8 * 512),
					entranceId,
					(byte) mapId,
					mapPos
				);

				allentrances[i] = eo;
			}

			for (int i = 0, j = 0; i < 0x13; i++, j += 2)
			{
				var mapId = ZS.ROM.Read16(ZS.Offsets.OWHoleArea + j);
				var mapPos = ZS.ROM.Read16(ZS.Offsets.OWHolePos + j);
				var entranceId = ZS.ROM[ZS.Offsets.OWHoleEntrance + i];
				var p = mapPos + 0x400;
				var x = p >> 1 & 0x3F;
				var y = p >> 7;
				allholes[i] = new OverworldEntrance(
					(ushort) (x * 16 + (mapId & 0x07) * 512),
					(ushort) (y * 16 + mapId % 64 / 8 * 512),
					entranceId,
					(byte) mapId,
					(ushort) p
				);
			}
		}


		public void CreateTile32Maps()
		{
			t32Unique.Clear();
			t32.Clear();
			// Create tile32 from tiles16
			var alltiles16 = new List<ulong>();

			var sx = 0;
			var sy = 0;
			var c = 0;
			for (var i = 0; i < Constants.NumberOfOWMaps; i++)
			{
				var tilesused = i switch
				{
					< 64 => allmapsTilesLW,
					>= 128 => allmapsTilesSP,
					_ => allmapsTilesDW,
				};

				var sx2 = sx << 5;
				var sy2 = sy << 5;
				for (var y = sy2; y < sy2 + 32; y += 2)
				{
					for (var x = sx2; x < sx2 + 32; x += 2)
					{
						alltiles16.Add(
							new Tile32(
								tilesused[x, y],
								tilesused[x + 1, y],
								tilesused[x, y + 1],
								tilesused[x + 1, y + 1]
							).getLongValue()
						);
					}
				}

				sx++;
				if (sx >= 8)
				{
					sy++;
					sx = 0;
				}

				c++;
				if (c >= 64)
				{
					sx = 0;
					sy = 0;
					c = 0;
				}
			}

			var tiles = alltiles16.Distinct().ToList(); // that get rid of duplicated tiles using linq
														// alltiles16 = all tiles32...
														// tiles = all tiles32 that are uniques double are removed
			var alltilesIndexed = new Dictionary<ulong, ushort>();

			for (var i = 0; i < tiles.Count; i++)
			{
				alltilesIndexed.Add(tiles[i], (ushort) i); // index the uniques tiles with a dictionary
			}

			for (var i = 0; i < Constants.NumberOfTile32Total; i++)
			{
				t32.Add(alltilesIndexed[alltiles16[i]]); //add all tiles32 from all maps
														 // convert all tiles32 non-unique ids into unique array of ids
			}

			for (var i = 0; i < tiles.Count; i++) // for each uniques tile32
			{
				t32Unique.Add(new Tile32(tiles[i])); // create new tileunique
			}

			while (t32Unique.Count % 4 != 0) // prevent a bug if tilecount is not a multiple of 4
			{
				t32Unique.Add(new Tile32(0));
			}

			if (t32Unique.Count > Constants.MaximumNumberOfTile32)
			{
				if (MessageBox.Show("Unique Tile32 count exceed the limit in the rom\n    ====== " + t32Unique.Count +
					" Used out of " + Constants.MaximumNumberOfTile32 + " ======    \nThe ROM will NOT be saved, would you like to export map data?",
					"Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					ExportMaps();
				}
				throw new ZeldaException("overworld map save failed");
			}

			alltiles16.Clear();

			var v = t32Unique.Count;
			for (var i = v; i < Constants.MaximumNumberOfTile32; i++)
			{
				t32Unique.Add(Tile32.Empty);
			}
		}

		public void ImportMaps()
		{
			var path = "";
			using (FolderBrowserDialog fd = new())
			{
				if (fd.ShowDialog() == DialogResult.OK)
				{
					if (Directory.Exists(fd.SelectedPath))
					{
						path = fd.SelectedPath;
					}
				}
				else
				{
					MessageBox.Show("Failed to imports maps");
					return;
				}
			}

			var sx = 0;
			var sy = 0;
			var c = 0;

			for (var i = 0; i < Constants.NumberOfOWMaps; i++)
			{
				var bw = new BinaryReader(new FileStream(path + "\\map" + i.ToString(), FileMode.Open, FileAccess.Read));
				var tilesused = i switch
				{
					< 64 => allmapsTilesLW,
					>= 128 => allmapsTilesSP,
					_ => allmapsTilesDW,
				};

				var sx2 = sx << 5;
				var sy2 = sy << 5;
				for (var y = sy2; y < sy2 + 32; y++)
				{
					for (var x = sx2; x < sx2 + 32; x++)
					{
						tilesused[x, y] = bw.ReadUInt16();
						//alltiles16.Add(new Tile32(tilesused[x + (sx * 32), y + (sy * 32)], tilesused[x + 1 + (sx * 32), y + (sy * 32)],
						//tilesused[x + (sx * 32), y + 1 + (sy * 32)], tilesused[x + 1 + (sx * 32), y + 1 + (sy * 32)]).getLongValue());
					}
				}

				sx++;
				if (sx >= 8)
				{
					sy++;
					sx = 0;

				}

				c++;
				if (c >= 64)
				{
					sx = 0;
					sy = 0;
					c = 0;
				}

				bw.Close();
				allmaps[i].InvalidateArtist();
			}
		}

		public void ExportMaps()
		{
			var path = "";
			using (FolderBrowserDialog fd = new())
			{
				if (fd.ShowDialog() == DialogResult.OK)
				{
					if (Directory.Exists(fd.SelectedPath))
					{
						path = fd.SelectedPath;
					}
				}
				else
				{
					MessageBox.Show("Failed to export maps");
				}
			}

			var sx = 0;
			var sy = 0;
			var c = 0;
			for (var i = 0; i < Constants.NumberOfOWMaps; i++)
			{
				// TODO file name in UIText
				var bw = new BinaryWriter(new FileStream(path + "\\map" + i.ToString(), FileMode.Create, FileAccess.Write));
				var tilesused = i switch
				{
					< 64 => allmapsTilesLW,
					>= 128 => allmapsTilesSP,
					_ => allmapsTilesDW,
				};

				var sx2 = sx << 5;
				var sy2 = sy << 5;
				for (var y = sy2; y < sy2 + 32; y++)
				{
					for (var x = sx2; x < sx2 + 32; x++)
					{
						bw.Write(tilesused[x, y]);
						//alltiles16.Add(new Tile32(tilesused[x + (sx * 32), y + (sy * 32)], tilesused[x + 1 + (sx * 32), y + (sy * 32)],
						//tilesused[x + (sx * 32), y + 1 + (sy * 32)], tilesused[x + 1 + (sx * 32), y + 1 + (sy * 32)]).getLongValue());
					}
				}

				sx++;
				if (sx >= 8)
				{
					sy++;
					sx = 0;

				}

				c++;
				if (c >= 64)
				{
					sx = 0;
					sy = 0;
					c = 0;
				}

				bw.Close();
			}
		}

		public void SaveTile32DefinitionsToROM()
		{
			var index = 0;
			var c = t32Unique.Count;
			for (var i = 0; i < c; i += 6, index += 4)
			{
				if (index >= 0x4540) // 3C87??
				{
					throw new ZeldaException("TOO MANY MAP32");
				}

				for (int j = i, k = index; j < i + 4; j++, k++)
				{
					ZS.ROM[ZS.Offsets.Map32DefinitionsTL + j] = (byte) t32Unique[k].Tile0;
					ZS.ROM[ZS.Offsets.Map32DefinitionsTR + j] = (byte) t32Unique[k].Tile1;
					ZS.ROM[ZS.Offsets.Map32DefinitionsBL + j] = (byte) t32Unique[k].Tile2;
					ZS.ROM[ZS.Offsets.Map32DefinitionsBR + j] = (byte) t32Unique[k].Tile3;
				}

				ZS.ROM.Write16(ZS.Offsets.Map32DefinitionsTL + i + 4, t32Unique[index].Tile0 >> 4 & 0x00F0 | t32Unique[index + 1].Tile0 >> 8 & 0x000F | t32Unique[index + 2].Tile0 << 4 & 0xF000 | t32Unique[index + 3].Tile0 & 0x0F00);
				ZS.ROM.Write16(ZS.Offsets.Map32DefinitionsTR + i + 4, t32Unique[index].Tile1 >> 4 & 0x00F0 | t32Unique[index + 1].Tile1 >> 8 & 0x000F | t32Unique[index + 2].Tile1 << 4 & 0xF000 | t32Unique[index + 3].Tile1 & 0x0F00);
				ZS.ROM.Write16(ZS.Offsets.Map32DefinitionsBL + i + 4, t32Unique[index].Tile2 >> 4 & 0x00F0 | t32Unique[index + 1].Tile2 >> 8 & 0x000F | t32Unique[index + 2].Tile2 << 4 & 0xF000 | t32Unique[index + 3].Tile2 & 0x0F00);
				ZS.ROM.Write16(ZS.Offsets.Map32DefinitionsBR + i + 4, t32Unique[index].Tile3 >> 4 & 0x00F0 | t32Unique[index + 1].Tile3 >> 8 & 0x000F | t32Unique[index + 2].Tile3 << 4 & 0xF000 | t32Unique[index + 3].Tile3 & 0x0F00);

				c += 2;
			}
		}

		/* 
		public void savemapstorom()
		{
			int pos = 0x120000;
			for (int i = 0; i < Constants.NumberOfOWMaps; i++)
			{
				int npos = 0;
				byte[]
					singlemap1 = new byte[256],
					singlemap2 = new byte[256];

				for (int y = 0; y < 16; y++)
				{
					for (int x = 0; x < 16; x++)
					{
						singlemap1[npos] = (byte)(t32[npos + (i * 256)] & 0xFF);
						singlemap2[npos] = (byte)((t32[npos + (i * 256)] >> 8) & 0xFF);
						npos++;
					}
				}

				int snesPos = Utils.PcToSnes(pos);
				ZS.ROM.DATA[(ZS.Offsets.compressedAllMap32PointersHigh) + 0 + (int)(3 * i)] = (byte)(snesPos & 0xFF);
				ZS.ROM.DATA[(ZS.Offsets.compressedAllMap32PointersHigh) + 1 + (int)(3 * i)] = (byte)((snesPos >> 8) & 0xFF);
				ZS.ROM.DATA[(ZS.Offsets.compressedAllMap32PointersHigh) + 2 + (int)(3 * i)] = (byte)((snesPos >> 16) & 0xFF);

				ZS.ROM.DATA[pos] = 0xE0;
				ZS.ROM.DATA[pos + 1] = 0xFF;
				pos += 2;

				for (int j = 0; j < 256; j++)
				{
					ZS.ROM.DATA[pos] = singlemap2[j];
					pos += 1;
				}

				ZS.ROM.DATA[pos] = 0xFF;
				pos += 1;
				snesPos = Utils.PcToSnes(pos);
				ZS.ROM.DATA[(ZS.Offsets.compressedAllMap32PointersLow) + 0 + (int)(3 * i)] = (byte)((snesPos >> 00) & 0xFF);
				ZS.ROM.DATA[(ZS.Offsets.compressedAllMap32PointersLow) + 1 + (int)(3 * i)] = (byte)((snesPos >> 08) & 0xFF);
				ZS.ROM.DATA[(ZS.Offsets.compressedAllMap32PointersLow) + 2 + (int)(3 * i)] = (byte)((snesPos >> 16) & 0xFF);

				ZS.ROM.DATA[pos] = 0xE0;
				ZS.ROM.DATA[pos + 1] = 0xFF;
				pos += 2;

				for (int j = 0; j < 256; j++)
				{
					ZS.ROM.DATA[pos] = singlemap1[j];
					pos += 1;
				}

				ZS.ROM.DATA[pos] = 0xFF;
				pos += 1;

			}

			//Console.WriteLine();
			//Save32Tiles();
		}
		*/

		public void LoadOverworldSecretsFromROM()
		{
			var ptr = ZS.ROM.Read24(ZS.Offsets.overworldItemsAddress);
			var ptrpc = ptr.SNEStoPC(); // 1BC2F9 -> 0DC2F9

			ForAllMainScreens(map =>
			{
				if (!map.IsOwnParent) return;

				var addr = (ptr & 0xFF0000 | ZS.ROM.Read16(ptrpc + map.MapID * 2)).SNEStoPC();

				while (true)
				{
					var b1 = ZS.ROM[addr++];
					var b2 = ZS.ROM[addr++];

					if ((b1 & b2) == 0xFF) return;

					var b3 = ZS.ROM[addr++];

					var p = ((b2 & 0x1F) << 8 | b1) >> 1;

					allitems.Add(new(SecretItemType.GetTypeFromID(b3))
					{
						MapID = map.MapID,
						MapX = (byte) (p & 0x3F),
						MapY = (byte) (p >> 6),

					});
				}
			});
		}

		public void loadOverlays()
		{
			/*
            0x7765B: ;Original byte = 0x0A
            22 9C 87 00 EA ;JSL long jump table
            */

			for (var index = 0; index < 128; index++)
			{
				alloverlays[index] = new();
				// OverlayPointers

				var addr = ZS.Offsets.overlayPointersBank.PCtoSNES() | ZS.ROM.Read16(ZS.Offsets.overlayPointers + index * 2);
				addr = addr.SNEStoPC();

				// TODO magic numbers
				if (ZS.ROM[0x77676] == 0x6B)
				{
					addr = SNESFunctions.SNEStoPC(ZS.ROM.Read16(0x077677 + index * 3));
					// Load New Address
				}

				var a = 0;
				var x = 0;
				var sta = 0;

				// 16-bit mode : 
				// A9 (LDA #$)
				// A2 (LDX #$)
				// 8D (STA $xxxx)
				// 9D (STA $xxxx ,x)
				// 8F (STA $xxxxxx)
				// 1A (INC A)
				// 4C (JMP)
				// 60 (END)

				byte b = 0;
				while (b != 0x60)
				{
					b = ZS.ROM[addr];
					if (b == 0xFF)
					{
						break;
					}
					else if (b == 0xA9) // LDA #$xxxx (Increase addr+3)
					{
						a = ZS.ROM.Read16(addr + 1);
						addr += 3;
						continue;
					}
					else if (b == 0xA2) // LDX #$xxxx (Increase addr+3)
					{
						x = ZS.ROM.Read16(addr + 1);
						addr += 3;
						continue;
					}
					else if (b == 0x8D) // STA $xxxx (Increase addr+3)
					{
						sta = ZS.ROM.Read16(addr + 1) & 0x1FFF;
						var yp = sta / 2 / 0x40;
						var xp = sta / 2 - yp * 0x40;
						alloverlays[index].tilesData.Add(new OverlayTile((byte) xp, (byte) yp, (ushort) a));
						addr += 3;
						continue;
					}
					else if (b == 0x9D) // STA $xxxx, x (Increase addr+3)
					{
						sta = ZS.ROM.Read16(addr + 1);
						// Draw tile at sta,X position

						var stax = (sta & 0x1FFF) + x;
						var yp = stax / 2 / 0x40;
						var xp = stax / 2 - yp * 0x40;
						alloverlays[index].tilesData.Add(new OverlayTile((byte) xp, (byte) yp, (ushort) a));

						addr += 3;
						continue;
					}
					else if (b == 0x8F) // STA $xxxxxx (Increase addr+4)
					{
						sta = ZS.ROM.Read16(addr + 1);

						var stax = (sta & 0x1FFF) + x;
						var yp = stax / 2 / 0x40;
						var xp = stax / 2 - yp * 0x40;
						alloverlays[index].tilesData.Add(new OverlayTile((byte) xp, (byte) yp, (ushort) a));

						addr += 4;
						continue;
					}
					else if (b == 0x1A) // INC A (Increase addr+1)
					{
						a += 1;
						addr += 1;
						continue;
					}
					else if (b == 0x4C) // JMP $xxxx (move addr to the new address)
					{
						addr = (ZS.Offsets.overlayPointersBank.PCtoSNES() | ZS.ROM.Read16(addr + 1)).SNEStoPC();
						// THAT SHOULD NOT EXIST IN MOVED CODE SO NO NEED TO CHANGE IT
						continue;
					}
					else if (b == 0x60) // RTS
					{
						break; // Just to be sure
					}
					else if (b == 0x6B) // RTL
					{
						break; // Just to be sure
					}
				}
			}
		}

		private void LoadScreenOfSprites(GameState gamestate, byte screen)
		{
			var spriteAddress = screen * 2 +
				gamestate switch
				{
					GameState.RainState => ZS.Offsets.OverworldSpritesTableState0,
					GameState.UncleState => ZS.Offsets.OverworldSpritesTableState0,
					GameState.RescueState => ZS.Offsets.OverworldSpritesTableState2,
					GameState.AgaState => ZS.Offsets.OverworldSpritesTableState3,
					_ => throw new ZeldaException("That's a bad gamestate")
				};

			spriteAddress = (Constants.OverworldSpritePointers | ZS.ROM.Read16(spriteAddress)).SNEStoPC();

			while (true)
			{
				var b1 = ZS.ROM[spriteAddress++];

				if (b1 == Constants.SpriteSentinel)
				{
					return;
				}

				b1 &= 0x3F;
				var b2 = (byte) (ZS.ROM[spriteAddress++] & 0x3F);
				var b3 = ZS.ROM[spriteAddress++];

				SpriteType st;

				if (b3 > 0xF2)
				{
					st = OverlordType.GetTypeFromID(b3 - 0xF2);
				}
				else
				{
					st = SpriteType.GetTypeFromID(b3);
				}

				GetSpritesForState(gamestate).Add(new(st)
				{
					MapID = screen,
					MapX = b2,
					MapY = b1,
				});
			}
		}


		public void LoadOverworldSpritesFromROM()
		{
			for (byte i = 0; i < 144; i++)
			{
				if (allmaps[i].IsOwnParent)
				{
					if (i < 64)
					{
						LoadScreenOfSprites(GameState.RainState, i);
					}
					LoadScreenOfSprites(GameState.RescueState, i);
					LoadScreenOfSprites(GameState.AgaState, i);
				}
			}
		}

		public bool CreateMap16Maps()
		{
			throw new NotImplementedException();
			//t16Unique.Clear();
			//t16.Clear();
			//
			//// Create tile32 from tiles16
			//List<ulong> alltiles8 = new List<ulong>();
			//
			//int sx = 0;
			//int sy = 0;
			//int c = 0;
			//for (int i = 0; i < Constants.NumberOfOWMaps; i++)
			//{
			//	Tile[,] tilesused;
			//	if (i < 64)
			//	{
			//		tilesused = tempTiles8_LW;
			//	}
			//	else if (i >= 128)
			//	{
			//		tilesused = tempTiles8_SP;
			//	}
			//	else
			//	{
			//		tilesused = tempTiles8_DW;
			//	}
			//
			//	for (int y = 0; y < 64; y += 2)
			//	{
			//		for (int x = 0; x < 64; x += 2)
			//		{
			//			ushort tf00 = tilesused[x + (sx * 64), y + (sy * 64)].ToUnsignedShort();
			//			ushort tf01 = tilesused[x + 1 + (sx * 64), y + (sy * 64)].ToUnsignedShort();
			//			ushort tf02 = tilesused[x + (sx * 64), y + 1 + (sy * 64)].ToUnsignedShort();
			//			ushort tf03 = tilesused[x + 1 + (sx * 64), y + 1 + (sy * 64)].ToUnsignedShort();
			//
			//			alltiles8.Add(Tile16.CreateLongValue(tf00, tf01, tf02, tf03));
			//		}
			//	}
			//
			//	sx++;
			//	if (sx >= 8)
			//	{
			//		sy++;
			//		sx = 0;
			//	}
			//
			//	c++;
			//	if (c >= 64)
			//	{
			//		sx = 0;
			//		sy = 0;
			//		c = 0;
			//	}
			//}
			//
			//List<ulong> tiles = alltiles8.Distinct().ToList(); // that get rid of duplicated tiles using linq
			//												   // alltiles16 = all tiles32...
			//												   // tiles = all tiles32 that are uniques double are removed
			//Dictionary<ulong, ushort> alltilesIndexed = new Dictionary<ulong, ushort>();
			//
			//for (int i = 0; i < tiles.Count; i++)
			//{
			//	alltilesIndexed.Add(tiles[i], (ushort) i); // index the uniques tiles with a dictionary
			//}
			//
			//for (int i = 0; i < Constants.NumberOfOWMaps * 32 * 32; i++) // 163840 = numbers of 16x16 tiles (160 * (32*32))
			//{
			//	t16.Add(alltilesIndexed[alltiles8[i]]); // add all tiles32 from all maps
			//											// convert all tiles32 non-unique ids into unique array of ids
			//}
			//
			//foreach (ulong tt in tiles) // for each uniques tile32
			//{
			//	t16Unique.Add(new Tile16(tt)); // create new tileunique
			//}
			//
			//while (t16Unique.Count % 4 != 0) // prevent a bug if tilecount is not a multiple of 4
			//{
			//	t16Unique.Add(new Tile16(0));
			//}
			//
			//if (t16Unique.Count > Constants.LimitOfMap32)
			//{
			//	if (MessageBox.Show("Unique Tiles16 count exceed the limit in the rom\nTiles data won't be saved would you like to export map data?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
			//	{
			//		// TODO: add something here?
			//	}
			//
			//	return true;
			//}
			//
			//Tile16List.ListOf.Clear();
			//foreach (Tile16 t16 in t16Unique)
			//{
			//	Tile16List.ListOf.Add(t16.Clone());
			//}
			//
			//alltiles8.Clear();
			//
			//return false;
		}
	}
}
