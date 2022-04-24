using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using ZeldaFullEditor.Data;
using ZeldaFullEditor.Data.Underworld;

namespace ZeldaFullEditor
{
	public class Overworld
	{
		public List<Tile16> Tile16List;
		public List<Tile32> Tile32List;

		private int[] map32address;

		public Tile32[] map16tiles;
		public List<Size> posSize;

		public Tile[,] tempTiles8_LW = new Tile[512, 512]; //all maps tiles8
		public Tile[,] tempTiles8_DW = new Tile[512, 512]; //all maps tiles8
		public Tile[,] tempTiles8_SP = new Tile[512, 512]; //all maps tiles8

		public List<Tile32> t32Unique = new List<Tile32>();
		public List<ushort> t32;

		public ExitOW[] allexits = new ExitOW[Constants.NumberOfOverworldExits];

		public byte[] allTilesTypes = new byte[0x200];

		public bool showSprites = true;

		// That must stay global - that's a problem
		public ushort[,] allmapsTilesLW = new ushort[512, 512]; //64 maps * (32*32 tiles)
		public ushort[,] allmapsTilesDW = new ushort[512, 512]; //64 maps * (32*32 tiles)
		public ushort[,] allmapsTilesSP = new ushort[512, 512]; //32 maps * (32*32 tiles)
		public OverworldMap[] allmaps = new OverworldMap[Constants.NumberOfOWMaps];
		public EntranceOWEditor[] allentrances = new EntranceOWEditor[129];
		public EntranceOWEditor[] allholes = new EntranceOWEditor[0x13];
		public List<OverworldSecret> allitems = new List<OverworldSecret>();
		public OverlayData[] alloverlays = new OverlayData[128];

		public List<OverworldSprite>[] allsprites = new List<OverworldSprite>[3];

		public int worldOffset = 0;

		// TODO : Fix Whirlpool on large maps
		public List<TransportOW> allWhirlpools = new List<TransportOW>();
		public List<TransportOW> allBirds = new List<TransportOW>();

		public byte gameState = 1;

		public byte[] mapParent = new byte[Constants.NumberOfOWMaps];

		public bool isLoaded = false;

		public ushort[] tileLeftEntrance = new ushort[Constants.NumberOfEntranceTypes];
		public ushort[] tileRightEntrance = new ushort[Constants.NumberOfEntranceTypes];

		public Gravestone[] graves = new Gravestone[Constants.NumberOfOverworldGraves];

		public int tiles32count = 0;

		List<Tile16> t16Unique = new List<Tile16>();
		List<ushort> t16 = new List<ushort>();

		private readonly ZScreamer ZS;
		public ZScreamer Screamer { get => ZS; }
		public Overworld(ZScreamer zs)
		{
			ZS = zs;
			Tile16List = new List<Tile16>();
			Tile32List = new List<Tile32>();

			map16tiles = new Tile32[Constants.NumberOfMap32];
			posSize = new List<Size>();

			t32 = new List<ushort>();

			for (int i = 0, j = 0; i < Constants.NumberOfEntranceTypes; i++, j += 2)
			{
				tileLeftEntrance[i] = ZS.ROM.Read16(ZS.Offsets.overworldEntranceAllowedTilesLeft + j);
				tileRightEntrance[i] = ZS.ROM.Read16(ZS.Offsets.overworldEntranceAllowedTilesRight + j);
				//Console.WriteLine(tileLeftEntrance[i].ToString("D4") + " , " + tileRightEntrance[i].ToString("D4"));
			}

			allsprites[0] = new List<OverworldSprite>();
			allsprites[1] = new List<OverworldSprite>();
			allsprites[2] = new List<OverworldSprite>();
		}
		public void Init()
		{
			AssembleMap32Tiles();
			AssembleMap16Tiles();
			DecompressAllMapTiles();
			loadOverlays();
			loadTilesTypes();
			loadGravesStone();

			// Map Initialization :
			for (int i = 0; i < Constants.NumberOfOWMaps; i++)
			{
				allmaps[i] = new OverworldMap((byte) i, ZS);
			}
			getLargeMaps();

			LoadOverworldExitsFromROM();
			LoadOverworldEntrancesFromROM();
			LoadOverworldSecretsFromROM();
			LoadOverworldTransportsFromROM();
			LoadOverworldSpritesFromROM();
			ZS.GFXManager.loadOverworldMap();

			new Thread(() =>
			{
				Thread.CurrentThread.IsBackground = true;
				for (int i = 0; i < Constants.NumberOfOWMaps; i++)
				{
					allmaps[i].BuildMap();
				}
			}).Start();

			isLoaded = true;
		}

		public void loadTilesTypes()
		{
			for (int i = 0; i < 0x200; i++)
			{
				allTilesTypes[i] = ZS.ROM[ZS.Offsets.overworldTilesType + i];
			}
		}

		public void loadGravesStone()
		{
			for (int i = 0, j = 0; i < Constants.NumberOfOverworldGraves; i++, j += 2)
			{
				ushort x = ZS.ROM.Read16(ZS.Offsets.GravesXTilePos + j);
				ushort y = ZS.ROM.Read16(ZS.Offsets.GravesYTilePos + j);
				ushort gfx = ZS.ROM.Read16(ZS.Offsets.GravesGFX + j);
				ushort tilemap = ZS.ROM.Read16(ZS.Offsets.GravesTilemapPos + j);
				graves[i] = new Gravestone(x, y, tilemap, gfx);
			}
		}

		public void getLargeMaps()
		{
			for (int i = 128; i < 145; i++)
			{
				mapParent[i] = 0;
			}

			mapParent[128] = 128;
			mapParent[129] = 129;
			mapParent[130] = 129;
			mapParent[137] = 129;
			mapParent[138] = 129;
			mapParent[136] = 136;
			allmaps[136].largeMap = false;

			bool[] mapChecked = new bool[64];
			for (int i = 0; i < 64; i++)
			{
				mapChecked[i] = false;
			}

			int xx = 0;
			int yy = 0;
			while (true)
			{
				byte i = (byte) (xx + (yy << 3));
				byte j = (byte) (i + 64);
				if (!mapChecked[i])
				{
					if (allmaps[i].largeMap)
					{
						mapChecked[i] = true;
						mapParent[i] = i;
						mapParent[j] = j;

						mapChecked[i + 1] = true;
						mapParent[i + 1] = i;
						mapParent[j + 1] = j;

						mapChecked[i + 8] = true;
						mapParent[i + 8] = i;
						mapParent[j + 8] = j;

						mapChecked[i + 9] = true;
						mapParent[i + 9] = i;
						mapParent[j + 9] = j;
						xx++;
					}
					else
					{
						mapParent[i] = i;
						mapParent[j] = j;
						mapChecked[i] = true;
					}
				}

				xx++;
				if (xx >= 8)
				{
					xx = 0;
					yy++;

					if (yy >= 8)
					{
						break;
					}
				}
			}
		}

		public void AssembleMap16Tiles()
		{
			int tpos = ZS.Offsets.map16Tiles;
			for (int i = 0; i < Constants.NumberOfMap16; i += 1)
			{
				Tile t0 = new Tile(ZS.ROM[tpos++], ZS.ROM[tpos++]);
				Tile t1 = new Tile(ZS.ROM[tpos++], ZS.ROM[tpos++]);
				Tile t2 = new Tile(ZS.ROM[tpos++], ZS.ROM[tpos++]);
				Tile t3 = new Tile(ZS.ROM[tpos++], ZS.ROM[tpos++]);

				Tile16List.Add(new Tile16(t0, t1, t2, t3));
			}
		}

		public void SaveMap16DefinitionsToROM()
		{
			int tpos = ZS.Offsets.map16Tiles;
			for (int i = 0; i < Constants.NumberOfMap16; i++)
			{
				ZS.ROM.WriteContinuous(ref tpos, Tile16List[i].GetByteData());
			}
		}

		public void AssembleMap32Tiles()
		{
			map32address = new int[]
			{
				ZS.Offsets.Map32DefinitionsTL,
				ZS.Offsets.Map32DefinitionsTR,
				ZS.Offsets.Map32DefinitionsBL,
				ZS.Offsets.Map32DefinitionsBR
			};

			// TODO magic number
			for (int i = 0; i < 0x33F0; i += 6)
			{
				ushort tl, tr, bl, br;

				for (int k = 0; k < 4; k++)
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

		private ushort generate(int i, int k, int dimension)
		{
			return (ushort) (ZS.ROM[map32address[dimension] + k + (i)]
				+ (((ZS.ROM[map32address[dimension] + (i) + (k <= 1 ? 4 : 5)] >> (k % 2 == 0 ? 4 : 0)) & 0x0F) * 256));
		}

		public void DecompressAllMapTiles()
		{
			int lowest = 0x0FFFFF;
			int highest = 0x0F8000;
			//int npos = 0;
			int sx = 0;
			int sy = 0;
			int c = 0;
			//int furthestPtr = 0;

			for (int i = 0; i < Constants.NumberOfOWMaps; i++)
			{
				int p1 = ZS.ROM.Read24(ZS.Offsets.compressedAllMap32PointersHigh + (3 * i)).SNEStoPC();
				int p2 = ZS.ROM.Read24(ZS.Offsets.compressedAllMap32PointersLow + (3 * i)).SNEStoPC();

				int ttpos = 0;
				int compressedSize1 = 0;
				int compressedSize2 = 0;

				if (p1 >= highest)
				{
					highest = p1;
				}
				if (p2 >= highest)
				{
					highest = p2;
				}

				if (p1 <= lowest)
				{
					if (p1 > 0x0F8000)
					{
						lowest = p1;
					}
				}
				if (p2 <= lowest)
				{
					if (p2 > 0x0F8000)
					{
						lowest = p2;
					}
				}

				byte[] bytes = ZCompressLibrary.Decompress.ALTTPDecompressOverworld(ZS.ROM.DataStream, p2, 1000, ref compressedSize1);
				byte[] bytes2 = ZCompressLibrary.Decompress.ALTTPDecompressOverworld(ZS.ROM.DataStream, p1, 1000, ref compressedSize2);

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
				ushort[,] buffer;

				if (i < 64)
				{
					buffer = allmapsTilesLW;
				}
				else if (i < 128)
				{
					buffer = allmapsTilesDW;
				}
				else
				{
					buffer = allmapsTilesSP;
				}

				int sx2 = sx << 5;
				int sy2 = sy << 5;

				for (int y = sy2; y < (sy2 + (16 * 2)); y += 2)
				{
					for (int x = sx2; x < (sx2 + (16 * 2)); x += 2)
					{
						ushort tpos = (ushort) ((bytes2[ttpos] << 8) | bytes[ttpos]);
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

		public void createMap32TilesFrom16()
		{
			t32.Clear();
			tiles32count = 0;

			for (int i = 0; i < Constants.NumberOfMap32; i++)
			{
				ushort? foundIndex = null;
				for (int j = 0; j < tiles32count; j++)
				{
					if (t32Unique[j].Tile0 == map16tiles[i].Tile0 &&
						t32Unique[j].Tile1 == map16tiles[i].Tile1 &&
						t32Unique[j].Tile2 == map16tiles[i].Tile2 &&
						t32Unique[j].Tile3 == map16tiles[i].Tile3)
						{
							foundIndex = (ushort) j;
							break;
						}
				}

				if (foundIndex == null)
				{
					t32Unique[tiles32count] = new Tile32(map16tiles[i].Tile0, map16tiles[i].Tile1, map16tiles[i].Tile2, map16tiles[i].Tile3);
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
				ushort py = ZS.ROM.Read16(ZS.Offsets.OWExitYPlayer + j);
				ushort px = ZS.ROM.Read16(ZS.Offsets.OWExitXPlayer + j);

				allexits[i] = new ExitOW(
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
				)
				{
					deleted = (px & py) == 0xFFFF
				};
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

				allWhirlpools.Add(
					new TransportOW(
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
				ushort mapId = ZS.ROM.Read16(ZS.Offsets.OWEntranceMap + j);
				ushort mapPos = ZS.ROM.Read16(ZS.Offsets.OWEntrancePos + j);
				byte entranceId = ZS.ROM[ZS.Offsets.OWEntranceEntranceId + i];
				int p = mapPos >> 1;
				int x = p & 0x3F;
				int y = p >> 6;
				EntranceOWEditor eo = new EntranceOWEditor(
					(ushort) ((x * 16) + ((mapId & 0x7) * 512)),
					(ushort) ((y * 16) + (((mapId % 64) / 8) * 512)),
					entranceId,
					(byte) mapId,
					mapPos
				);

				eo.deleted = eo.mapPos == 0xFFFF;

				allentrances[i] = eo;
			}

			for (int i = 0, j = 0; i < 0x13; i++, j += 2)
			{
				ushort mapId = ZS.ROM.Read16(ZS.Offsets.OWHoleArea + j);
				ushort mapPos = ZS.ROM.Read16(ZS.Offsets.OWHolePos + j);
				byte entranceId = ZS.ROM[ZS.Offsets.OWHoleEntrance + i];
				int p = mapPos + 0x400;
				int x = (p >> 1) & 0x3F;
				int y = p >> 7;
				allholes[i] = new EntranceOWEditor(
					(ushort) ((x * 16) + ((mapId & 0x07) * 512)),
					(ushort) ((y * 16) + (((mapId % 64) / 8) * 512)),
					entranceId,
					(byte) mapId,
					(ushort) p
				);
			}
		}


		public bool createMap32Tilesmap()
		{
			t32Unique.Clear();
			t32.Clear();
			// Create tile32 from tiles16
			List<ulong> alltiles16 = new List<ulong>();

			int sx = 0;
			int sy = 0;
			int c = 0;
			for (int i = 0; i < Constants.NumberOfOWMaps; i++)
			{
				ushort[,] tilesused;
				if (i < 64)
				{
					tilesused = allmapsTilesLW;
				}
				else if (i >= 128)
				{
					tilesused = allmapsTilesSP;
				}
				else
				{
					tilesused = allmapsTilesDW;
				}

				int sx2 = sx << 5;
				int sy2 = sy << 5;
				for (int y = sy2; y < (sy2 + 32); y += 2)
				{
					for (int x = sx2; x < (sx2 + 32); x += 2)
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

			List<ulong> tiles = alltiles16.Distinct().ToList(); // that get rid of duplicated tiles using linq
																// alltiles16 = all tiles32...
																// tiles = all tiles32 that are uniques double are removed
			Dictionary<ulong, ushort> alltilesIndexed = new Dictionary<ulong, ushort>();

			for (int i = 0; i < tiles.Count; i++)
			{
				alltilesIndexed.Add(tiles[i], (ushort) i); // index the uniques tiles with a dictionary
			}

			for (int i = 0; i < Constants.NumberOfMap32; i++)
			{
				t32.Add(alltilesIndexed[alltiles16[i]]); //add all tiles32 from all maps
														 // convert all tiles32 non-unique ids into unique array of ids
			}

			for (int i = 0; i < tiles.Count; i++) // for each uniques tile32
			{
				t32Unique.Add(new Tile32(tiles[i])); // create new tileunique
			}

			while (t32Unique.Count % 4 != 0) // prevent a bug if tilecount is not a multiple of 4
			{
				t32Unique.Add(new Tile32(0));
			}

			if (t32Unique.Count > Constants.LimitOfMap32)
			{
				if (MessageBox.Show("Unique Tile32 count exceed the limit in the rom\n    ====== " + t32Unique.Count +
					" Used out of " + Constants.LimitOfMap32 + " ======    \nThe ROM will NOT be saved, would you like to export map data?",
					"Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					ExportMaps();
				}

				return true;
			}

			alltiles16.Clear();

			int v = t32Unique.Count;
			for (int i = v; i < Constants.LimitOfMap32; i++)
			{
				t32Unique.Add(new Tile32(666, 666, 666, 666)); // create new tileunique
			}

			return false;
		}

		public void ImportMaps()
		{
			string path = "";
			using (FolderBrowserDialog fd = new FolderBrowserDialog())
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

			int sx = 0;
			int sy = 0;
			int c = 0;

			for (int i = 0; i < Constants.NumberOfOWMaps; i++)
			{
				BinaryReader bw = new BinaryReader(new FileStream(path + "\\map" + i.ToString(), FileMode.Open, FileAccess.Read));
				ushort[,] tilesused;
				if (i < 64)
				{
					tilesused = allmapsTilesLW;
				}
				else if (i >= 128)
				{
					tilesused = allmapsTilesSP;
				}
				else
				{
					tilesused = allmapsTilesDW;
				}

				int sx2 = sx << 5;
				int sy2 = sy << 5;
				for (int y = sy2; y < (sy2 + 32); y++)
				{
					for (int x = sx2; x < (sx2 + 32); x++)
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
				allmaps[i].BuildMap();
			}
		}

		public void ExportMaps()
		{
			string path = "";
			using (FolderBrowserDialog fd = new FolderBrowserDialog())
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

			int sx = 0;
			int sy = 0;
			int c = 0;
			for (int i = 0; i < Constants.NumberOfOWMaps; i++)
			{
				// TODO file name in UIText
				BinaryWriter bw = new BinaryWriter(new FileStream(path + "\\map" + i.ToString(), FileMode.Create, FileAccess.Write));
				ushort[,] tilesused;
				if (i < 64)
				{
					tilesused = allmapsTilesLW;
				}
				else if (i >= 128)
				{
					tilesused = allmapsTilesSP;
				}
				else
				{
					tilesused = allmapsTilesDW;
				}

				int sx2 = sx << 5;
				int sy2 = sy << 5;
				for (int y = sy2; y < (sy2 + 32); y++)
				{
					for (int x = sx2; x < (sx2 + 32); x++)
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


		// UNUSED CODE
		public void AllMapTilesFromMap(int mapid, ushort[,] tiles, bool large = false)
		{
			int tpos = mapid * 256;
			for (int y = 0; y < 16 * 2; y += 2)
			{
				for (int x = 0; x < 16 * 2; x += 2)
				{
					map16tiles[tpos++] = new Tile32(tiles[x, y], tiles[x + 1, y], tiles[x, y + 1], tiles[x + 1, y + 1]);
				}
			}
		}

		public void SaveMap32DefinitionsToROM()
		{
			int index = 0;
			int c = t32Unique.Count;
			for (int i = 0; i < c; i += 6, index += 4)
			{
				if (index >= 0x4540) // 3C87??
				{
					// TODO messagebox for failure "Too many unique tiles!"
					break;
				}

				for (int j = i, k = index; j < (i + 4); j++, k++)
				{
					ZS.ROM[ZS.Offsets.Map32DefinitionsTL + j] = (byte) t32Unique[k].Tile0;
					ZS.ROM[ZS.Offsets.Map32DefinitionsTR + j] = (byte) t32Unique[k].Tile1;
					ZS.ROM[ZS.Offsets.Map32DefinitionsBL + j] = (byte) t32Unique[k].Tile2;
					ZS.ROM[ZS.Offsets.Map32DefinitionsBR + j] = (byte) t32Unique[k].Tile3;
				}

				ZS.ROM.Write16(ZS.Offsets.Map32DefinitionsTL + i + 4, ((t32Unique[index].Tile0 >> 4) & 0x00F0) | ((t32Unique[index + 1].Tile0 >> 8) & 0x000F) | ((t32Unique[index + 2].Tile0 << 4) & 0xF000) | (t32Unique[index + 3].Tile0 & 0x0F00));
				ZS.ROM.Write16(ZS.Offsets.Map32DefinitionsTR + i + 4, ((t32Unique[index].Tile1 >> 4) & 0x00F0) | ((t32Unique[index + 1].Tile1 >> 8) & 0x000F) | ((t32Unique[index + 2].Tile1 << 4) & 0xF000) | (t32Unique[index + 3].Tile1 & 0x0F00));
				ZS.ROM.Write16(ZS.Offsets.Map32DefinitionsBL + i + 4, ((t32Unique[index].Tile2 >> 4) & 0x00F0) | ((t32Unique[index + 1].Tile2 >> 8) & 0x000F) | ((t32Unique[index + 2].Tile2 << 4) & 0xF000) | (t32Unique[index + 3].Tile2 & 0x0F00));
				ZS.ROM.Write16(ZS.Offsets.Map32DefinitionsBR + i + 4, ((t32Unique[index].Tile3 >> 4) & 0x00F0) | ((t32Unique[index + 1].Tile3 >> 8) & 0x000F) | ((t32Unique[index + 2].Tile3 << 4) & 0xF000) | (t32Unique[index + 3].Tile3 & 0x0F00));

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
			int ptr = ZS.ROM.Read24(ZS.Offsets.overworldItemsAddress);
			int ptrpc = ptr.SNEStoPC(); // 1BC2F9 -> 0DC2F9
			for (int i = 0; i < 128; i++)
			{
				int addr = ((ptr & 0xFF0000) | ZS.ROM.Read16(ptrpc + (i * 2))).SNEStoPC();

				if (allmaps[i].largeMap)
				{
					if (mapParent[i] != (byte) i)
					{
						continue;
					}
				}

				while (true)
				{
					byte b1 = ZS.ROM[addr];
					byte b2 = ZS.ROM[addr + 1];

					if ((b1 & b2) == 0xFF) // checks for both being 0xFF
					{
						break;
					}

					byte b3 = ZS.ROM[addr + 2];

					int p = (((b2 & 0x1F) << 8) | b1) >> 1;

					int x = p & 0x3F;
					int y = p >> 6;

					int fakeid = i;
					if (fakeid >= 64)
					{
						fakeid -= 64;
					}

					int sy = (fakeid / 8);
					int sx = fakeid - (sy * 8);

					allitems.Add(new RoomPotSaveEditor(b3, (ushort) i, (x * 16) + (sx * 512), (y * 16) + (sy * 512), false));
					allitems[allitems.Count - 1].MapX = (byte) x;
					allitems[allitems.Count - 1].MapY = (byte) y;
					addr += 3;
				}
			}
		}

		public void loadOverlays()
		{
			/*
            0x7765B: ;Original byte = 0x0A
            22 9C 87 00 EA ;JSL long jump table
            */

			for (int index = 0; index < 128; index++)
			{
				alloverlays[index] = new OverlayData();
				// OverlayPointers

				int addr = ZS.Offsets.overlayPointersBank.PCtoSNES() | ZS.ROM.Read16(ZS.Offsets.overlayPointers + (index * 2));
				addr = addr.SNEStoPC();

				// TODO magic numbers
				if (ZS.ROM[0x77676] == 0x6B)
				{
					addr = SNESFunctions.SNEStoPC(ZS.ROM.Read16(0x077677 + (index * 3)));
					// Load New Address
				}

				int a = 0;
				int x = 0;
				int sta = 0;

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
						int yp = ((sta / 2) / 0x40);
						int xp = (sta / 2) - (yp * 0x40);
						alloverlays[index].tilesData.Add(new TilePos((byte) xp, (byte) yp, (ushort) a));
						addr += 3;
						continue;
					}
					else if (b == 0x9D) // STA $xxxx, x (Increase addr+3)
					{
						sta = ZS.ROM.Read16(addr + 1);
						// Draw tile at sta,X position

						int stax = (sta & 0x1FFF) + x;
						int yp = ((stax / 2) / 0x40);
						int xp = (stax / 2) - (yp * 0x40);
						alloverlays[index].tilesData.Add(new TilePos((byte) xp, (byte) yp, (ushort) a));

						addr += 3;
						continue;
					}
					else if (b == 0x8F) // STA $xxxxxx (Increase addr+4)
					{
						sta = ZS.ROM.Read16(addr + 1);

						int stax = (sta & 0x1FFF) + x;
						int yp = ((stax / 2) / 0x40);
						int xp = (stax / 2) - (yp * 0x40);
						alloverlays[index].tilesData.Add(new TilePos((byte) xp, (byte) yp, (ushort) a));

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
						addr = SNESFunctions.SNEStoPC(ZS.Offsets.overlayPointersBank.PCtoSNES() | ZS.ROM.Read16(addr + 1));
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

		private void LoadScreenOfSprites(int gamestate, int screen)
		{
			int spriteAddress;
			switch (gamestate)
			{
				case 0:
					spriteAddress = ZS.Offsets.OverworldSpritesTableState0 + (screen * 2);
					break;

				case 1:
					spriteAddress = ZS.Offsets.OverworldSpritesTableState2 + (screen * 2);
					break;

				case 2:
					spriteAddress = ZS.Offsets.OverworldSpritesTableState3 + (screen * 2);
					break;

				default:
					return;
			}

			spriteAddress = SNESFunctions.SNEStoPC(Constants.OverworldSpritePointers | ZS.ROM.Read16(spriteAddress));

			int screenX = (screen % 8) * 512;
			int screenY = (screen / 8) * 512;

			while (true)
			{
				byte b1 = ZS.ROM[spriteAddress++];

				if (b1 == Constants.SpriteTerminator)
				{
					return;
				}

				byte b2 = (byte) (ZS.ROM[spriteAddress++] & 0x3F);
				byte b3 = (byte) (ZS.ROM[spriteAddress++] & 0x3F);

				allsprites[gamestate].Add(new Sprite((byte) screen, b3, b2, b1, screenX + (b2 * 16), screenY + (b1 * 16)));
			}
		}


		public void LoadOverworldSpritesFromROM()
		{
			// LW[0] = RainState 0 to 63 there's no data for DW
			// LW[1] = ZeldaState 0 to 128 ; Contains LW and DW <128 or 144 wtf
			// LW[2] = AgahState 0 to ?? ;Contains data for LW and DW

			//Console.WriteLine(((ZS.Offsets.overworldSpritesBegining & 0xFFFF) + (09 << 16)).ToString("X6"));
			for (int i = 0; i < 144; i++)
			{
				if (mapParent[i] == i)
				{
					if (i < 64)
					{
						LoadScreenOfSprites(0, i);
					}
					LoadScreenOfSprites(1, i);
					LoadScreenOfSprites(2, i);
				}
			}

			//Console.WriteLine("Finished loading sprites");
		}

		public bool createMap16Tilesmap()
		{
			t16Unique.Clear();
			t16.Clear();

			// Create tile32 from tiles16
			List<ulong> alltiles8 = new List<ulong>();

			int sx = 0;
			int sy = 0;
			int c = 0;
			for (int i = 0; i < Constants.NumberOfOWMaps; i++)
			{
				Tile[,] tilesused;
				if (i < 64)
				{
					tilesused = tempTiles8_LW;
				}
				else if (i >= 128)
				{
					tilesused = tempTiles8_SP;
				}
				else
				{
					tilesused = tempTiles8_DW;
				}

				for (int y = 0; y < 64; y += 2)
				{
					for (int x = 0; x < 64; x += 2)
					{
						ushort tf00 = tilesused[x + (sx * 64), y + (sy * 64)].ToUnsignedShort();
						ushort tf01 = tilesused[x + 1 + (sx * 64), y + (sy * 64)].ToUnsignedShort();
						ushort tf02 = tilesused[x + (sx * 64), y + 1 + (sy * 64)].ToUnsignedShort();
						ushort tf03 = tilesused[x + 1 + (sx * 64), y + 1 + (sy * 64)].ToUnsignedShort();

						alltiles8.Add(Tile16.CreateLongValue(tf00, tf01, tf02, tf03));
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

			List<ulong> tiles = alltiles8.Distinct().ToList(); // that get rid of duplicated tiles using linq
															   // alltiles16 = all tiles32...
															   // tiles = all tiles32 that are uniques double are removed
			Dictionary<ulong, ushort> alltilesIndexed = new Dictionary<ulong, ushort>();

			for (int i = 0; i < tiles.Count; i++)
			{
				alltilesIndexed.Add(tiles[i], (ushort) i); // index the uniques tiles with a dictionary
			}

			for (int i = 0; i < Constants.NumberOfOWMaps * 32 * 32; i++) // 163840 = numbers of 16x16 tiles (160 * (32*32))
			{
				t16.Add(alltilesIndexed[alltiles8[i]]); // add all tiles32 from all maps
														// convert all tiles32 non-unique ids into unique array of ids
			}

			foreach (ulong tt in tiles) // for each uniques tile32
			{
				t16Unique.Add(new Tile16(tt)); // create new tileunique
			}

			while (t16Unique.Count % 4 != 0) // prevent a bug if tilecount is not a multiple of 4
			{
				t16Unique.Add(new Tile16(0));
			}

			if (t16Unique.Count > Constants.LimitOfMap32)
			{
				if (MessageBox.Show("Unique Tiles16 count exceed the limit in the rom\nTiles data won't be saved would you like to export map data?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					// TODO: add something here?
				}

				return true;
			}

			Tile16List.Clear();
			foreach (Tile16 t16 in t16Unique)
			{
				Tile16List.Add(t16.Clone());
			}

			alltiles8.Clear();

			return false;
		}
	}
}
