using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ZeldaFullEditor.Data;

namespace ZeldaFullEditor
{
    public class Overworld
    {
        public List<Tile16> tiles16;
        public List<Tile32> tiles32;

        private int[] map32address;

        public Tile32[] map16tiles;
        public List<Size> posSize;

        public TileInfo[,] tempTiles8_LW = new TileInfo[512, 512]; //all maps tiles8
        public TileInfo[,] tempTiles8_DW = new TileInfo[512, 512]; //all maps tiles8
        public TileInfo[,] tempTiles8_SP = new TileInfo[512, 512]; //all maps tiles8

        public List<Tile32> t32Unique = new List<Tile32>();
        public List<ushort> t32;

        public ExitOW[] allexits = new ExitOW[0x4F];

        public byte[] allTilesTypes = new byte[0x200];

        public bool showSprites = true;

        // That must stay global - that's a problem
        public ushort[,] allmapsTilesLW = new ushort[512, 512]; //64 maps * (32*32 tiles)
        public ushort[,] allmapsTilesDW = new ushort[512, 512]; //64 maps * (32*32 tiles)
        public ushort[,] allmapsTilesSP = new ushort[512, 512]; //32 maps * (32*32 tiles)
        public OverworldMap[] allmaps = new OverworldMap[Constants.NumberOfOWMaps];
        public EntranceOW[] allentrances = new EntranceOW[129];
        public EntranceOW[] allholes = new EntranceOW[0x13];
        public List<RoomPotSaveEditor> allitems = new List<RoomPotSaveEditor>();
        public OverlayData[] alloverlays = new OverlayData[128];

        public List<Sprite>[] allsprites = new List<Sprite>[3];

        public int worldOffset = 0;

        // TODO : Fix Whirlpool on large maps
        public List<TransportOW> allWhirlpools = new List<TransportOW>();
        public List<TransportOW> allBirds = new List<TransportOW>();

        public byte gameState = 1;

        public bool isLoaded = false;

        public ushort[] tileLeftEntrance = new ushort[0x2B];
        public ushort[] tileRightEntrance = new ushort[0x2B];

        public Gravestone[] graves = new Gravestone[0x0F];

        public int tiles32count = 0;

        private List<Tile16> t16Unique = new List<Tile16>();
        private List<ushort> t16 = new List<ushort>();

        public Overworld()
        {
            tiles16 = new List<Tile16>();
            tiles32 = new List<Tile32>();

            map16tiles = new Tile32[Constants.NumberOfMap32];
            posSize = new List<Size>();

            t32 = new List<ushort>();

            for (int i = 0; i < 0x2B; i++)
            {
                tileLeftEntrance[i] = ROM.ReadShort(Constants.overworldEntranceAllowedTilesLeft + (i * 2));
                tileRightEntrance[i] = ROM.ReadShort(Constants.overworldEntranceAllowedTilesRight + (i * 2));

                //Console.WriteLine(tileLeftEntrance[i].ToString("D4") + " , " + tileRightEntrance[i].ToString("D4"));
            }

            allsprites[0] = new List<Sprite>();
            allsprites[1] = new List<Sprite>();
            allsprites[2] = new List<Sprite>();

            AssembleMap32Tiles();
            AssembleMap16Tiles();
            DecompressAllMapTiles();
            loadOverlays();
            loadTilesTypes();
            loadGravesStone();

            // Map Initialization :
            for (int i = 0; i < Constants.NumberOfOWMaps; i++)
            {
                allmaps[i] = new OverworldMap((byte)i, this);
            }
            getLargeMaps();

            loadExits();
            loadEntrances();
            loadItems();
            loadTransports();
            loadSprites();
            GFX.loadOverworldMap();

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
                allTilesTypes[i] = ROM.DATA[Constants.overworldTilesType + i];
            }
        }

        public void loadGravesStone()
        {
            for (int i = 0; i < 0x0F; i++)
            {
                ushort x = ROM.ReadShort(Constants.GravesXTilePos + (i * 2));
                ushort y = ROM.ReadShort(Constants.GravesYTilePos + (i * 2));
                ushort gfx = ROM.ReadShort(Constants.GravesGFX + (i * 2));
                ushort tilemap = ROM.ReadShort(Constants.GravesTilemapPos + (i * 2));
                graves[i] = new Gravestone(x, y, tilemap, gfx);
            }
        }

        public void getLargeMaps()
        {
            for (int i = 128; i < 145; i++)
            {
                allmaps[i].SetAsSmallMap(0);
            }

            allmaps[128].SetAsSmallMap();
            allmaps[129].SetAsLargeMap(129, 0);
            allmaps[130].SetAsLargeMap(129, 1);
            allmaps[137].SetAsLargeMap(129, 2);
            allmaps[138].SetAsLargeMap(129, 3);

            allmaps[136].SetAsSmallMap();

            bool[] mapChecked = new bool[64];
            for (int i = 0; i < 64; i++)
            {
                mapChecked[i] = false;
            }

            int xx = 0;
            int yy = 0;
            while (true)
            {
                int i = xx + (yy * 8);
                if (!mapChecked[i])
                {
                    if (allmaps[i].largeMap)
                    {
                        mapChecked[i] = true;
                        allmaps[i].SetAsLargeMap((byte)i, 0);
                        allmaps[i + 64].SetAsLargeMap((byte)(i + 64), 0);

                        mapChecked[i + 1] = true;
                        allmaps[i + 1].SetAsLargeMap((byte)i, 1);
                        allmaps[i + 65].SetAsLargeMap((byte)(i + 64), 1);

                        mapChecked[i + 8] = true;
                        allmaps[i + 8].SetAsLargeMap((byte)i, 2);
                        allmaps[i + 72].SetAsLargeMap((byte)(i + 64), 2);

                        mapChecked[i + 9] = true;
                        allmaps[i + 9].SetAsLargeMap((byte)i, 3);
                        allmaps[i + 73].SetAsLargeMap((byte)(i + 64), 3);
                        xx++;
                    }
                    else
                    {
                        mapChecked[i] = true;
                        allmaps[i].SetAsSmallMap();
                        allmaps[i + 64].SetAsSmallMap();
                    }
                }

                xx++;
                if (xx >= 8)
                {
                    xx = 0;
                    yy += 1;

                    if (yy >= 8)
                    {
                        break;
                    }
                }
            }
        }

        public void AssembleMap16Tiles()
        {
            int tpos = Constants.map16Tiles;
            for (int i = 0; i < Constants.NumberOfMap16; i += 1)
            {
                TileInfo t0 = GFX.gettilesinfo((ushort)BitConverter.ToInt16(ROM.DATA, (tpos)));
                tpos += 2;
                TileInfo t1 = GFX.gettilesinfo((ushort)BitConverter.ToInt16(ROM.DATA, (tpos)));
                tpos += 2;
                TileInfo t2 = GFX.gettilesinfo((ushort)BitConverter.ToInt16(ROM.DATA, (tpos)));
                tpos += 2;
                TileInfo t3 = GFX.gettilesinfo((ushort)BitConverter.ToInt16(ROM.DATA, (tpos)));
                tpos += 2;

                tiles16.Add(new Tile16(t0, t1, t2, t3));
            }
        }

        public void SaveMap16Tiles()
        {
            int tpos = Constants.map16Tiles;
            for (int i = 0; i < Constants.NumberOfMap16; i += 1) // 3760
            {
                ROM.WriteShort(tpos, tiles16[i].Tile0.toShort(), WriteType.Tile16);
                //ROM.DATA[tpos] = (byte)(tiles16[i].tile0.toShort() & 0xFF);
                //ROM.DATA[tpos + 1] = (byte)((tiles16[i].tile0.toShort() >> 8) & 0xFF);
                tpos += 2;
                ROM.WriteShort(tpos, tiles16[i].Tile1.toShort(), WriteType.Tile16);
                //ROM.DATA[tpos] = (byte)(tiles16[i].tile1.toShort() & 0xFF);
                //ROM.DATA[tpos + 1] = (byte)((tiles16[i].tile1.toShort() >> 8) & 0xFF);
                tpos += 2;
                ROM.WriteShort(tpos, tiles16[i].Tile2.toShort(), WriteType.Tile16);
                //ROM.DATA[tpos] = (byte)(tiles16[i].tile2.toShort() & 0xFF);
                //ROM.DATA[tpos + 1] = (byte)((tiles16[i].tile2.toShort() >> 8) & 0xFF);
                tpos += 2;
                ROM.WriteShort(tpos, tiles16[i].Tile3.toShort(), WriteType.Tile16);
                //ROM.DATA[tpos] = (byte)(tiles16[i].tile3.toShort() & 0xFF);
                //ROM.DATA[tpos + 1] = (byte)((tiles16[i].tile3.toShort() >> 8) & 0xFF);
                tpos += 2;
            }
        }

        public void AssembleMap32Tiles()
        {
            map32address = new int[]
            {
                    Constants.map32TilesTL,
                    Constants.map32TilesTR,
                    Constants.map32TilesBL,
                    Constants.map32TilesBR
            };

            for (int i = 0; i < 0x33F0; i += 6)
            {
                ushort[,] b = new ushort[4, 4];
                ushort tl, tr, bl, br;

                for (int k = 0; k < 4; k++)
                {
                    tl = generate(i, k, (int)Dimension.map32TilesTL);
                    tr = generate(i, k, (int)Dimension.map32TilesTR);
                    bl = generate(i, k, (int)Dimension.map32TilesBL);
                    br = generate(i, k, (int)Dimension.map32TilesBR);
                    tiles32.Add(new Tile32(tl, tr, bl, br));
                }
            }
        }

        private enum Dimension
        {
            map32TilesTL = 0,
            map32TilesTR = 1,
            map32TilesBL = 2,
            map32TilesBR = 3
        }

        private ushort generate(int i, int k, int dimension)
        {
            return (ushort)(ROM.DATA[map32address[dimension] + k + (i)]
                + (((ROM.DATA[map32address[dimension] + (i) + (k <= 1 ? 4 : 5)] >> (k % 2 == 0 ? 4 : 0)) & 0x0F) * 256));
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
                int p1 =
                (ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 2 + 3 * i] << 16) +
                (ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 1 + 3 * i] << 8) +
                (ROM.DATA[(Constants.compressedAllMap32PointersHigh + 3 * i)]);
                p1 = Utils.SnesToPc(p1);

                int p2 =
                (ROM.DATA[(Constants.compressedAllMap32PointersLow) + 2 + 3 * i] << 16) +
                (ROM.DATA[(Constants.compressedAllMap32PointersLow) + 1 + 3 * i] << 8) +
                (ROM.DATA[(Constants.compressedAllMap32PointersLow + 3 * i)]);
                p2 = Utils.SnesToPc(p2);

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

                byte[] bytes = ZCompressLibrary.Decompress.ALTTPDecompressOverworld(ROM.DATA, p2, 1000, ref compressedSize1);
                byte[] bytes2 = ZCompressLibrary.Decompress.ALTTPDecompressOverworld(ROM.DATA, p1, 1000, ref compressedSize2);

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

                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        ushort tidD = (ushort)((bytes2[ttpos] << 8) + bytes[ttpos]);

                        int tpos = tidD;
                        if (tpos < tiles32.Count)
                        {
                            //map16tiles[npos] = new Tile32(tiles32[tpos].tile0, tiles32[tpos].tile1, tiles32[tpos].tile2, tiles32[tpos].tile3);

                            if (i < 64)
                            {
                                allmapsTilesLW[(x * 2) + (sx * 32), (y * 2) + (sy * 32)] = tiles32[tpos].Tile0;
                                allmapsTilesLW[(x * 2) + 1 + (sx * 32), (y * 2) + (sy * 32)] = tiles32[tpos].Tile1;
                                allmapsTilesLW[(x * 2) + (sx * 32), (y * 2) + 1 + (sy * 32)] = tiles32[tpos].Tile2;
                                allmapsTilesLW[(x * 2) + 1 + (sx * 32), (y * 2) + 1 + (sy * 32)] = tiles32[tpos].Tile3;
                            }
                            else if (i < 128 && i >= 64)
                            {
                                allmapsTilesDW[(x * 2) + (sx * 32), (y * 2) + (sy * 32)] = tiles32[tpos].Tile0;
                                allmapsTilesDW[(x * 2) + 1 + (sx * 32), (y * 2) + (sy * 32)] = tiles32[tpos].Tile1;
                                allmapsTilesDW[(x * 2) + (sx * 32), (y * 2) + 1 + (sy * 32)] = tiles32[tpos].Tile2;
                                allmapsTilesDW[(x * 2) + 1 + (sx * 32), (y * 2) + 1 + (sy * 32)] = tiles32[tpos].Tile3;
                            }
                            else
                            {
                                allmapsTilesSP[(x * 2) + (sx * 32), (y * 2) + (sy * 32)] = tiles32[tpos].Tile0;
                                allmapsTilesSP[(x * 2) + 1 + (sx * 32), (y * 2) + (sy * 32)] = tiles32[tpos].Tile1;
                                allmapsTilesSP[(x * 2) + (sx * 32), (y * 2) + 1 + (sy * 32)] = tiles32[tpos].Tile2;
                                allmapsTilesSP[(x * 2) + 1 + (sx * 32), (y * 2) + 1 + (sy * 32)] = tiles32[tpos].Tile3;
                            }
                        }

                        ttpos += 1;
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

            Console.WriteLine("Map pointers (lowest) : " + lowest.ToString("X6"));
            Console.WriteLine("Map pointers (highest) : " + highest.ToString("X6"));
        }

        public void createMap32TilesFrom16()
        {
            t32.Clear();
            tiles32count = 0;

            const int nullVal = -1;
            for (int i = 0; i < Constants.NumberOfMap32; i++)
            {
                short foundIndex = nullVal;
                for (int j = 0; j < tiles32count; j++)
                {
                    if (t32Unique[j].Tile0 == map16tiles[i].Tile0 &&
                        t32Unique[j].Tile1 == map16tiles[i].Tile1 &&
                        t32Unique[j].Tile2 == map16tiles[i].Tile2 &&
                        t32Unique[j].Tile3 == map16tiles[i].Tile3)
                    {
                        foundIndex = (short)j;
                        break;
                    }
                }

                if (foundIndex == nullVal)
                {
                    t32Unique[tiles32count] = new Tile32(map16tiles[i].Tile0, map16tiles[i].Tile1, map16tiles[i].Tile2, map16tiles[i].Tile3);
                    t32.Add((ushort)tiles32count);
                    tiles32count++;
                }
                else t32.Add((ushort)foundIndex);
            }

            Console.WriteLine("Nbr of tiles32 = " + tiles32count);
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

        public void loadExits()
        {
            for (int i = 0; i < 0x4F; i++)
            {
                short[] e = new short[13];
                ushort exitRoomID = (ushort)((ROM.DATA[Constants.OWExitRoomId + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitRoomId + (i * 2)]));
                e[1] = (ROM.DATA[Constants.OWExitMapId + i]);
                e[2] = (short)((ROM.DATA[Constants.OWExitVram + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitVram + (i * 2)]));
                e[3] = (short)((ROM.DATA[Constants.OWExitYScroll + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitYScroll + (i * 2)]));
                e[4] = (short)((ROM.DATA[Constants.OWExitXScroll + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitXScroll + (i * 2)]));
                ushort py = (ushort)((ROM.DATA[Constants.OWExitYPlayer + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitYPlayer + (i * 2)]));
                ushort px = (ushort)((ROM.DATA[Constants.OWExitXPlayer + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitXPlayer + (i * 2)]));
                e[7] = (short)((ROM.DATA[Constants.OWExitYCamera + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitYCamera + (i * 2)]));
                e[8] = (short)((ROM.DATA[Constants.OWExitXCamera + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitXCamera + (i * 2)]));
                e[9] = (ROM.DATA[Constants.OWExitUnk1 + i]);
                e[10] = (ROM.DATA[Constants.OWExitUnk2 + i]);
                e[11] = (short)((ROM.DATA[Constants.OWExitDoorType1 + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitDoorType1 + (i * 2)]));
                e[12] = (short)((ROM.DATA[Constants.OWExitDoorType2 + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitDoorType2 + (i * 2)]));
                ExitOW eo = (new ExitOW(exitRoomID, (byte)e[1], e[2], e[3], e[4], py, px, e[7], e[8], (byte)e[9], (byte)e[10], e[11], e[12]));

                if (px == 0xFFFF && py == 0xFFFF)
                {
                    eo.Deleted = true;
                }

                allexits[i] = eo;
            }
        }

        public void loadTransports()
        {
            for (int i = 0; i < 0x11; i++)
            {
                short[] e = new short[13];
                e[0] = (byte)(((ROM.DATA[Constants.OWExitMapIdWhirlpool + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitMapIdWhirlpool + (i * 2)])));
                e[1] = (short)((ROM.DATA[Constants.OWExitVramWhirlpool + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitVramWhirlpool + (i * 2)]));
                e[2] = (short)((ROM.DATA[Constants.OWExitYScrollWhirlpool + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitYScrollWhirlpool + (i * 2)]));
                e[3] = (short)((ROM.DATA[Constants.OWExitXScrollWhirlpool + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitXScrollWhirlpool + (i * 2)]));
                e[4] = (short)((ROM.DATA[Constants.OWExitYPlayerWhirlpool + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitYPlayerWhirlpool + (i * 2)]));
                e[5] = (short)((ROM.DATA[Constants.OWExitXPlayerWhirlpool + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitXPlayerWhirlpool + (i * 2)]));
                e[6] = (short)((ROM.DATA[Constants.OWExitYCameraWhirlpool + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitYCameraWhirlpool + (i * 2)]));
                e[7] = (short)((ROM.DATA[Constants.OWExitXCameraWhirlpool + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitXCameraWhirlpool + (i * 2)]));
                e[8] = (ROM.DATA[Constants.OWExitUnk1Whirlpool + i]);
                e[9] = (ROM.DATA[Constants.OWExitUnk2Whirlpool + i]);
                e[10] = (short)((ROM.DATA[Constants.OWWhirlpoolPosition + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWWhirlpoolPosition + (i * 2)]));

                if (i > 8)
                {
                    e[10] = (short)((ROM.DATA[Constants.OWWhirlpoolPosition + ((i - 9) * 2) + 1] << 8) + (ROM.DATA[Constants.OWWhirlpoolPosition + ((i - 9) * 2)]));
                }

                TransportOW eo = (new TransportOW((byte)e[0], e[1], e[2], e[3], e[4], e[5], e[6], e[7], (byte)e[8], (byte)e[9], e[10]));
                allWhirlpools.Add(eo);
            }
        }

        public void loadEntrances()
        {
            for (int i = 0; i < 129; i++)
            {
                short mapId = (short)((ROM.DATA[Constants.OWEntranceMap + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWEntranceMap + (i * 2)]));
                ushort mapPos = (ushort)((ROM.DATA[Constants.OWEntrancePos + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWEntrancePos + (i * 2)]));
                byte entranceId = (ROM.DATA[Constants.OWEntranceEntranceId + i]);
                int p = mapPos >> 1;
                int x = (p % 64);
                int y = (p >> 6);
                EntranceOW eo = new EntranceOW((x * 16) + (((mapId % 64) - (((mapId % 64) / 8) * 8)) * 512), (y * 16) + (((mapId % 64) / 8) * 512), entranceId, mapId, mapPos, false);

                if (eo.MapPos == 0xFFFF)
                {
                    eo.Deleted = true;
                }

                allentrances[i] = eo;
            }

            for (int i = 0; i < 0x13; i++)
            {
                short mapId = (short)((ROM.DATA[Constants.OWHoleArea + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWHoleArea + (i * 2)]));
                short mapPos = (short)((ROM.DATA[Constants.OWHolePos + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWHolePos + (i * 2)]));
                byte entranceId = (ROM.DATA[Constants.OWHoleEntrance + i]);
                int p = (mapPos + 0x400) >> 1;
                int x = (p % 64);
                int y = (p >> 6);
                EntranceOW eo = new EntranceOW((x * 16) + (((mapId % 64) - (((mapId % 64) / 8) * 8)) * 512), (y * 16) + (((mapId % 64) / 8) * 512), entranceId, mapId, (ushort)(mapPos + 0x400), true);
                allholes[i] = eo;
            }
        }

        public void showTile32Count()
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
                ushort[,] tilesused = allmapsTilesLW;
                if (i < 64)
                {
                    tilesused = allmapsTilesLW;
                }
                else if (i < 128 && i >= 64)
                {
                    tilesused = allmapsTilesDW;
                }
                else
                {
                    tilesused = allmapsTilesSP;
                }

                for (int y = 0; y < 32; y += 2)
                {
                    for (int x = 0; x < 32; x += 2)
                    {
                        alltiles16.Add(new Tile32(tilesused[x + (sx * 32), y + (sy * 32)], tilesused[x + 1 + (sx * 32), y + (sy * 32)],
                        tilesused[x + (sx * 32), y + 1 + (sy * 32)], tilesused[x + 1 + (sx * 32), y + 1 + (sy * 32)]).GetLongValue());
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
                alltilesIndexed.Add(tiles[i], (ushort)i); // index the uniques tiles with a dictionary
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

            MessageBox.Show("Number of unique Tiles32: " + tiles.Count + " Out of: " + Constants.LimitOfMap32);

            alltiles16.Clear();

            Console.WriteLine("Number of unique Tiles32: " + tiles.Count + " Saved:" + t32Unique.Count + " Out of: " + Constants.LimitOfMap32);
            int v = t32Unique.Count;
            for (int i = v; i < Constants.LimitOfMap32; i++)
            {
                t32Unique.Add(new Tile32(666, 666, 666, 666)); // create new tileunique
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
                ushort[,] tilesused = allmapsTilesLW;
                if (i < 64)
                {
                    tilesused = allmapsTilesLW;
                }
                else if (i < 128 && i >= 64)
                {
                    tilesused = allmapsTilesDW;
                }
                else
                {
                    tilesused = allmapsTilesSP;
                }

                for (int y = 0; y < 32; y += 2)
                {
                    for (int x = 0; x < 32; x += 2)
                    {
                        alltiles16.Add(new Tile32(tilesused[x + (sx * 32), y + (sy * 32)], tilesused[x + 1 + (sx * 32), y + (sy * 32)],
                        tilesused[x + (sx * 32), y + 1 + (sy * 32)], tilesused[x + 1 + (sx * 32), y + 1 + (sy * 32)]).GetLongValue());
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
                alltilesIndexed.Add(tiles[i], (ushort)i); // index the uniques tiles with a dictionary
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

            alltiles16.Clear();

            if (t32Unique.Count > Constants.LimitOfMap32)
            {
                MessageBox.Show("Number of unique Tiles32: " + tiles.Count + " Out of: " + Constants.LimitOfMap32 + "\r\nUnique Tile32 count exceed the limit\r\nThe ROM Has not been saved\r\nYou can fill maps with grass tiles to free some space\r\nOr use the option Clear DW Tiles in the Overworld Menu");
                return true;
            }

            Console.WriteLine("Number of unique Tiles32: " + tiles.Count + " Saved:" + t32Unique.Count + " Out of: " + Constants.LimitOfMap32);
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
                ushort[,] tilesused = allmapsTilesLW;
                if (i < 64)
                {
                    tilesused = allmapsTilesLW;
                }
                else if (i < 128 && i >= 64)
                {
                    tilesused = allmapsTilesDW;
                }
                else
                {
                    tilesused = allmapsTilesSP;
                }

                for (int y = 0; y < 32; y++)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        tilesused[x + (sx * 32), y + (sy * 32)] = bw.ReadUInt16();
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
                ushort[,] tilesused = allmapsTilesLW;
                if (i < 64)
                {
                    tilesused = allmapsTilesLW;
                }
                else if (i < 128 && i >= 64)
                {
                    tilesused = allmapsTilesDW;
                }
                else
                {
                    tilesused = allmapsTilesSP;
                }

                for (int y = 0; y < 32; y++)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        bw.Write(tilesused[x + (sx * 32), y + (sy * 32)]);
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
            string s = "";
            int tpos = mapid * 256;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    map16tiles[tpos] = new Tile32(tiles[(x * 2), (y * 2)], tiles[(x * 2) + 1, (y * 2)], tiles[(x * 2), (y * 2) + 1], tiles[(x * 2) + 1, (y * 2) + 1]);
                    //s += "[" + map16tiles[tpos].tile0.ToString("D4") + "," + map16tiles[tpos].tile1.ToString("D4") + "," + map16tiles[tpos].tile2.ToString("D4") + "," + map16tiles[tpos].tile3.ToString("D4") + "] ";
                    tpos++;
                }

                s += "\r\n";
            }

            //File.WriteAllText("TileDebug.txt", s);
        }

        public void Save32Tiles()
        {
            int index = 0;
            int c = t32Unique.Count;
            for (int i = 0; i < c; i += 6)
            {
                if (index >= 0x4540) // 3C87??
                {
                    Console.WriteLine("Too many unique tiles!");
                    break;
                }

                // Top Left
                ROM.Write(Constants.map32TilesTL + (i), (byte)(t32Unique[index].Tile0 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTL + (i + 1), (byte)(t32Unique[index + 1].Tile0 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTL + (i + 2), (byte)(t32Unique[index + 2].Tile0 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTL + (i + 3), (byte)(t32Unique[index + 3].Tile0 & 0xFF), WriteType.Tile32);

                ROM.Write(Constants.map32TilesTL + (i + 4), (byte)(((t32Unique[index].Tile0 >> 4) & 0xF0) + ((t32Unique[index + 1].Tile0 >> 8) & 0x0F)), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTL + (i + 5), (byte)(((t32Unique[index + 2].Tile0 >> 4) & 0xF0) + ((t32Unique[index + 3].Tile0 >> 8) & 0x0F)), WriteType.Tile32);

                // Top Right
                ROM.Write(Constants.map32TilesTR + (i), (byte)(t32Unique[index].Tile1 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTR + (i + 1), (byte)(t32Unique[index + 1].Tile1 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTR + (i + 2), (byte)(t32Unique[index + 2].Tile1 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTR + (i + 3), (byte)(t32Unique[index + 3].Tile1 & 0xFF), WriteType.Tile32);

                ROM.Write(Constants.map32TilesTR + (i + 4), (byte)(((t32Unique[index].Tile1 >> 4) & 0xF0) | ((t32Unique[index + 1].Tile1 >> 8) & 0x0F)), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTR + (i + 5), (byte)(((t32Unique[index + 2].Tile1 >> 4) & 0xF0) | ((t32Unique[index + 3].Tile1 >> 8) & 0x0F)), WriteType.Tile32);

                // Bottom Left
                ROM.Write(Constants.map32TilesBL + (i), (byte)(t32Unique[index].Tile2 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesBL + (i + 1), (byte)(t32Unique[index + 1].Tile2 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesBL + (i + 2), (byte)(t32Unique[index + 2].Tile2 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesBL + (i + 3), (byte)(t32Unique[index + 3].Tile2 & 0xFF), WriteType.Tile32);

                ROM.Write(Constants.map32TilesBL + (i + 4), (byte)(((t32Unique[index].Tile2 >> 4) & 0xF0) | ((t32Unique[index + 1].Tile2 >> 8) & 0x0F)), WriteType.Tile32);
                ROM.Write(Constants.map32TilesBL + (i + 5), (byte)(((t32Unique[index + 2].Tile2 >> 4) & 0xF0) | ((t32Unique[index + 3].Tile2 >> 8) & 0x0F)), WriteType.Tile32);

                // Bottom Right
                ROM.Write(Constants.map32TilesBR + (i), (byte)(t32Unique[index].Tile3 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesBR + (i + 1), (byte)(t32Unique[index + 1].Tile3 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesBR + (i + 2), (byte)(t32Unique[index + 2].Tile3 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesBR + (i + 3), (byte)(t32Unique[index + 3].Tile3 & 0xFF), WriteType.Tile32);

                ROM.Write(Constants.map32TilesBR + (i + 4), (byte)(((t32Unique[index].Tile3 >> 4) & 0xF0) | ((t32Unique[index + 1].Tile3 >> 8) & 0x0F)), WriteType.Tile32);
                ROM.Write(Constants.map32TilesBR + (i + 5), (byte)(((t32Unique[index + 2].Tile3 >> 4) & 0xF0) | ((t32Unique[index + 3].Tile3 >> 8) & 0x0F)), WriteType.Tile32);

                /*
                ROM.DATA[Constants.map32TilesTL + (i)] = (byte)(t32Unique[index].tile0 & 0xFF);
                ROM.DATA[Constants.map32TilesTL + (i + 1)] = (byte)(t32Unique[index + 1].tile0 & 0xFF);
                ROM.DATA[Constants.map32TilesTL + (i + 2)] = (byte)(t32Unique[index + 2].tile0 & 0xFF);
                ROM.DATA[Constants.map32TilesTL + (i + 3)] = (byte)(t32Unique[index + 3].tile0 & 0xFF);

                ROM.DATA[Constants.map32TilesTL + (i + 4)] = (byte)(((t32Unique[index].tile0 >> 4) & 0xF0) + ((t32Unique[index + 1].tile0 >> 8) & 0x0F));
                ROM.DATA[Constants.map32TilesTL + (i + 5)] = (byte)(((t32Unique[index + 2].tile0 >> 4) & 0xF0) + ((t32Unique[index + 3].tile0 >> 8) & 0x0F));

                // Top Right
                ROM.DATA[Constants.map32TilesTR + (i)] = (byte)(t32Unique[index].tile1 & 0xFF);
                ROM.DATA[Constants.map32TilesTR + (i + 1)] = (byte)(t32Unique[index + 1].tile1 & 0xFF);
                ROM.DATA[Constants.map32TilesTR + (i + 2)] = (byte)(t32Unique[index + 2].tile1 & 0xFF);
                ROM.DATA[Constants.map32TilesTR + (i + 3)] = (byte)(t32Unique[index + 3].tile1 & 0xFF);

                ROM.DATA[Constants.map32TilesTR + (i + 4)] = (byte)(((t32Unique[index].tile1 >> 4) & 0xF0) | ((t32Unique[index + 1].tile1 >> 8) & 0x0F));
                ROM.DATA[Constants.map32TilesTR + (i + 5)] = (byte)(((t32Unique[index + 2].tile1 >> 4) & 0xF0) | ((t32Unique[index + 3].tile1 >> 8) & 0x0F));

                // Bottom Left
                ROM.DATA[Constants.map32TilesBL + (i)] = (byte)(t32Unique[index].tile2 & 0xFF);
                ROM.DATA[Constants.map32TilesBL + (i + 1)] = (byte)(t32Unique[index + 1].tile2 & 0xFF);
                ROM.DATA[Constants.map32TilesBL + (i + 2)] = (byte)(t32Unique[index + 2].tile2 & 0xFF);
                ROM.DATA[Constants.map32TilesBL + (i + 3)] = (byte)(t32Unique[index + 3].tile2 & 0xFF);

                ROM.DATA[Constants.map32TilesBL + (i + 4)] = (byte)(((t32Unique[index].tile2 >> 4) & 0xF0) | ((t32Unique[index + 1].tile2 >> 8) & 0x0F));
                ROM.DATA[Constants.map32TilesBL + (i + 5)] = (byte)(((t32Unique[index + 2].tile2 >> 4) & 0xF0) | ((t32Unique[index + 3].tile2 >> 8) & 0x0F));

                // Bottom Right
                ROM.DATA[Constants.map32TilesBR + (i)] = (byte)(t32Unique[index].tile3 & 0xFF);
                ROM.DATA[Constants.map32TilesBR + (i + 1)] = (byte)(t32Unique[index + 1].tile3 & 0xFF);
                ROM.DATA[Constants.map32TilesBR + (i + 2)] = (byte)(t32Unique[index + 2].tile3 & 0xFF);
                ROM.DATA[Constants.map32TilesBR + (i + 3)] = (byte)(t32Unique[index + 3].tile3 & 0xFF);

                ROM.DATA[Constants.map32TilesBR + (i + 4)] = (byte)(((t32Unique[index].tile3 >> 4) & 0xF0) | ((t32Unique[index + 1].tile3 >> 8) & 0x0F));
                ROM.DATA[Constants.map32TilesBR + (i + 5)] = (byte)(((t32Unique[index + 2].tile3 >> 4) & 0xF0) | ((t32Unique[index + 3].tile3 >> 8) & 0x0F));
                */

                index += 4;
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
				ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 0 + (int)(3 * i)] = (byte)(snesPos & 0xFF);
				ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 1 + (int)(3 * i)] = (byte)((snesPos >> 8) & 0xFF);
				ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 2 + (int)(3 * i)] = (byte)((snesPos >> 16) & 0xFF);

				ROM.DATA[pos] = 0xE0;
				ROM.DATA[pos + 1] = 0xFF;
				pos += 2;

				for (int j = 0; j < 256; j++)
				{
					ROM.DATA[pos] = singlemap2[j];
					pos += 1;
				}

				ROM.DATA[pos] = 0xFF;
				pos += 1;
				snesPos = Utils.PcToSnes(pos);
				ROM.DATA[(Constants.compressedAllMap32PointersLow) + 0 + (int)(3 * i)] = (byte)((snesPos >> 00) & 0xFF);
				ROM.DATA[(Constants.compressedAllMap32PointersLow) + 1 + (int)(3 * i)] = (byte)((snesPos >> 08) & 0xFF);
				ROM.DATA[(Constants.compressedAllMap32PointersLow) + 2 + (int)(3 * i)] = (byte)((snesPos >> 16) & 0xFF);

				ROM.DATA[pos] = 0xE0;
				ROM.DATA[pos + 1] = 0xFF;
				pos += 2;

				for (int j = 0; j < 256; j++)
				{
					ROM.DATA[pos] = singlemap1[j];
					pos += 1;
				}

				ROM.DATA[pos] = 0xFF;
				pos += 1;
			}

			//Console.WriteLine();
			//Save32Tiles();
		}
		*/

        public void loadItems()
        {
            int ptr = ROM.ReadLong(Constants.overworldItemsAddress);
            int ptrpc = Utils.SnesToPc(ptr); // 1BC2F9 -> 0DC2F9
            for (int i = 0; i < 128; i++)
            {
                int addr = ((ptr & 0xFF0000) + // 1B
                            (ROM.DATA[ptrpc + (i * 2) + 1] << 8) + // F9
                            (ROM.DATA[ptrpc + (i * 2)]) // 3C
                            );

                addr = Utils.SnesToPc(addr);

                if (allmaps[i].largeMap)
                {
                    if (allmaps[i].parent != (byte)i)
                    {
                        continue;
                    }
                }

                while (true)
                {
                    byte b1 = ROM.DATA[addr];
                    byte b2 = ROM.DATA[addr + 1];
                    byte b3 = ROM.DATA[addr + 2];

                    if (b1 == 0xFF && b2 == 0xFF)
                    {
                        break;
                    }

                    int p = (((b2 & 0x1F) << 8) + b1) >> 1;

                    int x = p % 64;
                    int y = p >> 6;

                    int fakeid = i;
                    if (fakeid >= 64)
                    {
                        fakeid -= 64;
                    }

                    int sy = (fakeid / 8);
                    int sx = fakeid - (sy * 8);

                    allitems.Add(new RoomPotSaveEditor(b3, (ushort)i, (x * 16) + (sx * 512), (y * 16) + (sy * 512), false));
                    allitems[allitems.Count - 1].gameX = (byte)x;
                    allitems[allitems.Count - 1].gameY = (byte)y;
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
                Console.WriteLine("MapIndex Overlay : " + index.ToString());

                int addr = (Constants.overlayPointersBank << 16) +
                (ROM.DATA[Constants.overlayPointers + (index * 2) + 1] << 8) +
                ROM.DATA[Constants.overlayPointers + (index * 2)];
                addr = Utils.SnesToPc(addr);

                if (index == 112)
                {
                    index = index;
                }

                if (ROM.DATA[0x77676] == 0x6B)
                {
                    addr = (ROM.DATA[(0x077677 + 2) + (index * 3)] << 16) +
                    (ROM.DATA[(0x077677 + 1) + (index * 3)] << 8) +
                    ROM.DATA[(0x077677 + 0) + (index * 3)];
                    addr = Utils.SnesToPc(addr);
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
                    b = ROM.DATA[addr];
                    if (b == 0xFF)
                    {
                        break;
                    }
                    /*
					else if (b == 0xC2) // Add me back in to open goddess of wisdom at least in the dungeon editor.
					{
						break;
					}
					else if (b == 0x0E) // Add me back in to open milk utopia at least in the dungeon editor.
					{
						break;
					}
					*/
                    else if (b == 0xA9) // LDA #$xxxx (Increase addr+3)
                    {
                        a = (ROM.DATA[addr + 2] << 8) +
                        ROM.DATA[addr + 1];
                        addr += 3;
                        continue;
                    }
                    else if (b == 0xA2) // LDX #$xxxx (Increase addr+3)
                    {
                        x = (ROM.DATA[addr + 2] << 8) +
                        ROM.DATA[addr + 1];
                        addr += 3;
                        continue;
                    }
                    else if (b == 0x8D) // STA $xxxx (Increase addr+3)
                    {
                        sta = (ROM.DATA[addr + 2] << 8) +
                        ROM.DATA[addr + 1];

                        sta = sta & 0x1FFF;
                        int yp = ((sta / 2) / 0x40);
                        int xp = (sta / 2) - (yp * 0x40);
                        alloverlays[index].TileDataList.Add(new TilePos((byte)xp, (byte)yp, (ushort)a));
                        addr += 3;
                        continue;
                    }
                    else if (b == 0x9D) // STA $xxxx, x (Increase addr+3)
                    {
                        sta = (ROM.DATA[addr + 2] << 8) +
                        ROM.DATA[addr + 1];
                        // Draw tile at sta,X position

                        int stax = (sta & 0x1FFF) + x;
                        int yp = ((stax / 2) / 0x40);
                        int xp = (stax / 2) - (yp * 0x40);
                        alloverlays[index].TileDataList.Add(new TilePos((byte)xp, (byte)yp, (ushort)a));

                        addr += 3;
                        continue;
                    }
                    else if (b == 0x8F) // STA $xxxxxx (Increase addr+4)
                    {
                        sta = (ROM.DATA[addr + 2] << 8) +
                        ROM.DATA[addr + 1];

                        int stax = (sta & 0x1FFF) + x;
                        int yp = ((stax / 2) / 0x40);
                        int xp = (stax / 2) - (yp * 0x40);
                        alloverlays[index].TileDataList.Add(new TilePos((byte)xp, (byte)yp, (ushort)a));

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
                        addr = (Constants.overlayPointersBank << 16) +
                        (ROM.DATA[addr + 2] << 8) +
                        ROM.DATA[addr + 1];
                        addr = Utils.SnesToPc(addr);
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

        public void loadSprites()
        {
            // LW[0] = RainState 0 to 63 there's no data for DW
            // LW[1] = ZeldaState 0 to 128 ; Contains LW and DW <128 or 144 wtf
            // LW[2] = AgahState 0 to ?? ;Contains data for LW and DW

            //Console.WriteLine(((Constants.overworldSpritesBegining & 0xFFFF) + (09 << 16)).ToString("X6"));
            for (int i = 0; i < 64; i++)
            {
                if (allmaps[i].parent == i)
                {
                    // Beginning Sprites
                    int ptrPos = Constants.overworldSpritesBegining + (i * 2);
                    int spriteAddress = Utils.SnesToPc((09 << 16) + ROM.ReadShort(ptrPos));
                    while (true)
                    {
                        byte b1 = ROM.DATA[spriteAddress];
                        byte b2 = ROM.DATA[spriteAddress + 1];
                        byte b3 = ROM.DATA[spriteAddress + 2];
                        if (b1 == 0xFF) { break; }

                        int mapY = (i / 8);
                        int mapX = (i % 8);

                        int realX = ((b2 & 0x3F) * 16) + mapX * 512;
                        int realY = ((b1 & 0x3F) * 16) + mapY * 512;

                        allsprites[0].Add(new Sprite((byte)i, b3, (byte)(b2 & 0x3F), (byte)(b1 & 0x3F), realX, realY));

                        spriteAddress += 3;
                    }
                }
            }

            for (int i = 0; i < 144; i++)
            {
                if (allmaps[i].parent == i)
                {
                    // Zelda Saved Sprites
                    int ptrPos = Constants.overworldSpritesZelda + (i * 2);
                    int spriteAddress = Utils.SnesToPc((09 << 16) + ROM.ReadShort(ptrPos));
                    while (true)
                    {
                        byte b1 = ROM.DATA[spriteAddress];
                        byte b2 = ROM.DATA[spriteAddress + 1];
                        byte b3 = ROM.DATA[spriteAddress + 2];
                        if (b1 == 0xFF) { break; }

                        int editorMapIndex = i;
                        if (editorMapIndex >= 128)
                        {
                            editorMapIndex = i - 128;
                        }
                        else if (editorMapIndex >= 64)
                        {
                            editorMapIndex = i - 64;
                        }

                        int mapY = (editorMapIndex / 8);
                        int mapX = (editorMapIndex % 8);

                        int realX = ((b2 & 0x3F) * 16) + mapX * 512;
                        int realY = ((b1 & 0x3F) * 16) + mapY * 512;

                        allsprites[1].Add(new Sprite((byte)i, b3, (byte)(b2 & 0x3F), (byte)(b1 & 0x3F), realX, realY));

                        spriteAddress += 3;
                    }
                }

                // Agahnim Dead Sprites
                if (allmaps[i].parent == i)
                {
                    int ptrPos = Constants.overworldSpritesAgahnim + (i * 2);
                    int spriteAddress = Utils.SnesToPc((09 << 16) + ROM.ReadShort(ptrPos));
                    while (true)
                    {
                        byte b1 = ROM.DATA[spriteAddress];
                        byte b2 = ROM.DATA[spriteAddress + 1];
                        byte b3 = ROM.DATA[spriteAddress + 2];
                        if (b1 == 0xFF) { break; }

                        int editorMapIndex = i;
                        if (editorMapIndex >= 128)
                        {
                            editorMapIndex = i - 128;
                        }
                        else if (editorMapIndex >= 64)
                        {
                            editorMapIndex = i - 64;
                        }

                        int mapY = (editorMapIndex / 8);
                        int mapX = (editorMapIndex % 8);

                        int realX = ((b2 & 0x3F) * 16) + mapX * 512;
                        int realY = ((b1 & 0x3F) * 16) + mapY * 512;

                        allsprites[2].Add(new Sprite((byte)i, b3, (byte)(b2 & 0x3F), (byte)(b1 & 0x3F), realX, realY));

                        spriteAddress += 3;
                    }
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
                TileInfo[,] tilesused = tempTiles8_LW;
                if (i < 64)
                {
                    tilesused = tempTiles8_LW;
                }
                else if (i < 128 && i >= 64)
                {
                    tilesused = tempTiles8_DW;
                }
                else
                {
                    tilesused = tempTiles8_SP;
                }

                for (int y = 0; y < 64; y += 2)
                {
                    for (int x = 0; x < 64; x += 2)
                    {
                        ushort tf00 = tilesused[x + (sx * 64), y + (sy * 64)].toShort();
                        ushort tf01 = tilesused[x + 1 + (sx * 64), y + (sy * 64)].toShort();
                        ushort tf02 = tilesused[x + (sx * 64), y + 1 + (sy * 64)].toShort();
                        ushort tf03 = tilesused[x + 1 + (sx * 64), y + 1 + (sy * 64)].toShort();

                        alltiles8.Add(new Tile16(GFX.gettilesinfo(tf00), GFX.gettilesinfo(tf01), GFX.gettilesinfo(tf02), GFX.gettilesinfo(tf03)).GetLongData());
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
                alltilesIndexed.Add(tiles[i], (ushort)i); // index the uniques tiles with a dictionary
            }

            for (int i = 0; i < Constants.NumberOfOWMaps * 32 * 32; i++) // 163840 = numbers of 16x16 tiles (160 * (32*32))
            {
                t16.Add(alltilesIndexed[alltiles8[i]]); // add all tiles32 from all maps
                                                        // convert all tiles32 non-unique ids into unique array of ids
            }

            for (int i = 0; i < tiles.Count; i++) // for each uniques tile32
            {
                t16Unique.Add(new Tile16(tiles[i])); // create new tileunique
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

            tiles16.Clear();
            for (int i = 0; i < t16Unique.Count; i++)
            {
                ulong t = t16Unique[i].GetLongData();
                tiles16.Add(new Tile16(t));
            }

            alltiles8.Clear();

            Console.WriteLine("Nbr of uniquetiles16 = " + tiles.Count + " " + t16Unique.Count);
            return false;
        }
    }
}
