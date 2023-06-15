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
    /// <summary>
    ///     A data class containing all the data and properties for the 3 overworlds.
    /// </summary>
    public class Overworld
    {
        public List<Tile16> Tile16List = new List<Tile16>();
        public List<Tile32> Tile32List = new List<Tile32>();

        private readonly int[] map32Address = { Constants.map32TilesTL, Constants.map32TilesTR, Constants.map32TilesBL, Constants.map32TilesBR };

        public Tile32[] Map16Tiles = new Tile32[Constants.NumberOfMap32];
        public List<Size> PositionSize = new List<Size>();

        public TileInfo[,] TempTile8Array_LW = new TileInfo[512, 512]; // all maps tiles8.
        public TileInfo[,] TempTile8Array_DW = new TileInfo[512, 512]; // all maps tiles8.
        public TileInfo[,] TempTile8Array_SP = new TileInfo[512, 512]; // all maps tiles8.

        public List<Tile32> UniqueTile32List = new List<Tile32>();
        public List<ushort> t32 = new List<ushort>();

        public ExitOW[] AllExits = new ExitOW[0x4F];

        public byte[] AllTileTypes = new byte[0x200];

        public bool ShowSprites = true;

        // That must stay global - that's a problem.
        public ushort[,] AllMapTile32_LW = new ushort[512, 512]; // 64 maps * (32*32 tiles).
        public ushort[,] AllMapTile32_DW = new ushort[512, 512]; // 64 maps * (32*32 tiles).
        public ushort[,] AllMapTile32_SP = new ushort[512, 512]; // 32 maps * (32*32 tiles).
        public OverworldMap[] AllMaps = new OverworldMap[Constants.NumberOfOWMaps];
        public EntranceOW[] AllEntrances = new EntranceOW[129];
        public EntranceOW[] AllHoles = new EntranceOW[0x13];
        public List<RoomPotSaveEditor> AllItems = new List<RoomPotSaveEditor>();
        public OverlayData[] AllOverlays = new OverlayData[128];

        public List<Sprite>[] AllSprites = new List<Sprite>[3] { new List<Sprite>(), new List<Sprite>(), new List<Sprite>() };

        public int WorldOffset = 0;

        // TODO : Fix Whirlpool on large maps.
        public List<TransportOW> AllWhirlpools = new List<TransportOW>();
        public List<TransportOW> AllBirds = new List<TransportOW>();

        public byte GameState = 1;

        public bool IsLoaded = false;

        public ushort[] LeftTileEntrance = new ushort[0x2B];
        public ushort[] RightTileEntrance = new ushort[0x2B];

        public Gravestone[] AllGraves = new Gravestone[0x0F];

        public int Tile32Count = 0;

        private List<Tile16> uniqueTile16List = new List<Tile16>();
        private List<ushort> t16 = new List<ushort>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="Overworld"/> class.
        /// </summary>
        public Overworld()
        {
            for (int i = 0; i < 0x2B; i++)
            {
                this.LeftTileEntrance[i] = ROM.ReadShort(Constants.overworldEntranceAllowedTilesLeft + (i * 2));
                this.RightTileEntrance[i] = ROM.ReadShort(Constants.overworldEntranceAllowedTilesRight + (i * 2));

                //Console.WriteLine(tileLeftEntrance[i].ToString("D4") + " , " + tileRightEntrance[i].ToString("D4"));
            }

            this.Tile32List = this.AssembleMap32Tiles();
            this.Tile16List = this.AssembleMap16Tiles();
            (ushort[,] tilesLW, ushort[,] tilesDW, ushort[,] tilesSP) = this.DecompressAllMapTiles();
            this.AllMapTile32_LW = tilesLW;
            this.AllMapTile32_LW = tilesDW;
            this.AllMapTile32_LW = tilesSP;

            this.AllOverlays = this.LoadOverlays();
            this.AllTileTypes = this.LoadTileTypes();
            this.AllGraves = this.LoadGraves();

            this.AllMaps = this.AssignLargeMaps();

            this.AllExits = this.LoadExits();
            this.AllEntrances = this.LoadEntrances();
            this.AllHoles = this.LoadHoles();
            this.AllItems = this.LoadItems();
            this.AllWhirlpools = this.LoadWhirlpools();
            this.AllSprites = this.LoadSprites();
            GFX.LoadOverworldMap();

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                for (int i = 0; i < Constants.NumberOfOWMaps; i++)
                {
                    this.AllMaps[i].BuildMap();
                }
            }).Start();

            this.IsLoaded = true;
        }

        /// <summary>
        ///     This function loads all tile types from the ROM and returns them as an array.
        /// </summary>
        /// <returns> An array of bytes. </returns>
        public byte[] LoadTileTypes()
        {
            var tileTypes = new List<byte>();
            for (int i = 0; i < this.AllTileTypes.Length; i++)
            {
                tileTypes.Add(ROM.DATA[Constants.overworldTilesType + i]);
            }

            return tileTypes.ToArray();
        }

        public Gravestone[] LoadGraves()
        {
            var graves = new List<Gravestone>();
            for (int i = 0; i < this.AllGraves.Length; i++)
            {
                ushort x = ROM.ReadShort(Constants.GravesXTilePos + (i * 2));
                ushort y = ROM.ReadShort(Constants.GravesYTilePos + (i * 2));
                ushort gfx = ROM.ReadShort(Constants.GravesGFX + (i * 2));
                ushort tilemap = ROM.ReadShort(Constants.GravesTilemapPos + (i * 2));
                graves.Add(new Gravestone(x, y, tilemap, gfx));
            }

            return graves.ToArray();
        }

        public OverworldMap[] AssignLargeMaps()
        {
            var allMaps = new OverworldMap[this.AllMaps.Length];

            // Map Initialization:
            for (int i = 0; i < Constants.NumberOfOWMaps; i++)
            {
                allMaps[i] = new OverworldMap((byte)i, this);
            }

            for (int i = 128; i < 145; i++)
            {
                allMaps[i].SetAsSmallMap(0);
            }

            allMaps[128].SetAsSmallMap();
            allMaps[129].SetAsLargeMap(129, 0);
            allMaps[130].SetAsLargeMap(129, 1);
            allMaps[137].SetAsLargeMap(129, 2);
            allMaps[138].SetAsLargeMap(129, 3);

            allMaps[136].SetAsSmallMap();

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
                    if (allMaps[i].largeMap)
                    {
                        mapChecked[i] = true;
                        allMaps[i].SetAsLargeMap((byte)i, 0);
                        allMaps[i + 64].SetAsLargeMap((byte)(i + 64), 0);

                        mapChecked[i + 1] = true;
                        allMaps[i + 1].SetAsLargeMap((byte)i, 1);
                        allMaps[i + 65].SetAsLargeMap((byte)(i + 64), 1);

                        mapChecked[i + 8] = true;
                        allMaps[i + 8].SetAsLargeMap((byte)i, 2);
                        allMaps[i + 72].SetAsLargeMap((byte)(i + 64), 2);

                        mapChecked[i + 9] = true;
                        allMaps[i + 9].SetAsLargeMap((byte)i, 3);
                        allMaps[i + 73].SetAsLargeMap((byte)(i + 64), 3);
                        xx++;
                    }
                    else
                    {
                        mapChecked[i] = true;
                        allMaps[i].SetAsSmallMap();
                        allMaps[i + 64].SetAsSmallMap();
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

            return allMaps;
        }

        public List<Tile16> AssembleMap16Tiles()
        {
            var tile16List = new List<Tile16>();
            int tpos = Constants.map16Tiles;
            for (int i = 0; i < Constants.NumberOfMap16; i += 1)
            {
                TileInfo t0 = GFX.gettilesinfo((ushort)BitConverter.ToInt16(ROM.DATA, tpos));
                tpos += 2;
                TileInfo t1 = GFX.gettilesinfo((ushort)BitConverter.ToInt16(ROM.DATA, tpos));
                tpos += 2;
                TileInfo t2 = GFX.gettilesinfo((ushort)BitConverter.ToInt16(ROM.DATA, tpos));
                tpos += 2;
                TileInfo t3 = GFX.gettilesinfo((ushort)BitConverter.ToInt16(ROM.DATA, tpos));
                tpos += 2;

                tile16List.Add(new Tile16(t0, t1, t2, t3));
            }

            return tile16List;
        }

        public void SaveMap16Tiles()
        {
            int tpos = Constants.map16Tiles;
            for (int i = 0; i < Constants.NumberOfMap16; i += 1) // 3760
            {
                ROM.WriteShort(tpos, this.Tile16List[i].Tile0.toShort(), WriteType.Tile16);
                //ROM.DATA[tpos] = (byte)(tiles16[i].tile0.toShort() & 0xFF);
                //ROM.DATA[tpos + 1] = (byte)((tiles16[i].tile0.toShort() >> 8) & 0xFF);
                tpos += 2;
                ROM.WriteShort(tpos, this.Tile16List[i].Tile1.toShort(), WriteType.Tile16);
                //ROM.DATA[tpos] = (byte)(tiles16[i].tile1.toShort() & 0xFF);
                //ROM.DATA[tpos + 1] = (byte)((tiles16[i].tile1.toShort() >> 8) & 0xFF);
                tpos += 2;
                ROM.WriteShort(tpos, this.Tile16List[i].Tile2.toShort(), WriteType.Tile16);
                //ROM.DATA[tpos] = (byte)(tiles16[i].tile2.toShort() & 0xFF);
                //ROM.DATA[tpos + 1] = (byte)((tiles16[i].tile2.toShort() >> 8) & 0xFF);
                tpos += 2;
                ROM.WriteShort(tpos, this.Tile16List[i].Tile3.toShort(), WriteType.Tile16);
                //ROM.DATA[tpos] = (byte)(tiles16[i].tile3.toShort() & 0xFF);
                //ROM.DATA[tpos + 1] = (byte)((tiles16[i].tile3.toShort() >> 8) & 0xFF);
                tpos += 2;
            }
        }

        public List<Tile32> AssembleMap32Tiles()
        {
            var tile32List = new List<Tile32>();
            for (int i = 0; i < 0x33F0; i += 6)
            {
                ushort[,] b = new ushort[4, 4];
                ushort tl, tr, bl, br;

                for (int k = 0; k < 4; k++)
                {
                    tl = this.ReadTile32(i, k, 0);
                    tr = this.ReadTile32(i, k, 1);
                    bl = this.ReadTile32(i, k, 2);
                    br = this.ReadTile32(i, k, 3);
                    tile32List.Add(new Tile32(tl, tr, bl, br));
                }
            }

            return tile32List;
        }

        private ushort ReadTile32(int i, int k, int dimension)
        {
            return (ushort)(ROM.DATA[this.map32Address[dimension] + k + i]
                + (((ROM.DATA[this.map32Address[dimension] + i + (k <= 1 ? 4 : 5)] >> (k % 2 == 0 ? 4 : 0)) & 0x0F) * 256));
        }

        public (ushort[,], ushort[,], ushort[,]) DecompressAllMapTiles()
        {
            ushort[,] allMapTile32_LW = new ushort[512, 512]; // 64 maps * (32*32 tiles).
            ushort[,] allMapTile32_DW = new ushort[512, 512]; // 64 maps * (32*32 tiles).
            ushort[,] allMapTile32_SP = new ushort[512, 512]; // 32 maps * (32*32 tiles).

            int lowest = 0x0FFFFF;
            int highest = 0x0F8000;
            int sx = 0;
            int sy = 0;
            int c = 0;
            for (int i = 0; i < Constants.NumberOfOWMaps; i++)
            {
                int p1 =
                (ROM.DATA[Constants.compressedAllMap32PointersHigh + 2 + (3 * i)] << 16) +
                (ROM.DATA[Constants.compressedAllMap32PointersHigh + 1 + (3 * i)] << 8) +
                ROM.DATA[Constants.compressedAllMap32PointersHigh + (3 * i)];
                p1 = Utils.SnesToPc(p1);

                int p2 =
                (ROM.DATA[Constants.compressedAllMap32PointersLow + 2 + (3 * i)] << 16) +
                (ROM.DATA[Constants.compressedAllMap32PointersLow + 1 + (3 * i)] << 8) +
                ROM.DATA[Constants.compressedAllMap32PointersLow + (3 * i)];
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
                        if (tpos < this.Tile32List.Count)
                        {
                            //map16tiles[npos] = new Tile32(tiles32[tpos].tile0, tiles32[tpos].tile1, tiles32[tpos].tile2, tiles32[tpos].tile3);

                            if (i < 64)
                            {
                                allMapTile32_LW[(x * 2) + (sx * 32), (y * 2) + (sy * 32)] = this.Tile32List[tpos].Tile0;
                                allMapTile32_LW[(x * 2) + 1 + (sx * 32), (y * 2) + (sy * 32)] = this.Tile32List[tpos].Tile1;
                                allMapTile32_LW[(x * 2) + (sx * 32), (y * 2) + 1 + (sy * 32)] = this.Tile32List[tpos].Tile2;
                                allMapTile32_LW[(x * 2) + 1 + (sx * 32), (y * 2) + 1 + (sy * 32)] = this.Tile32List[tpos].Tile3;
                            }
                            else if (i < 128 && i >= 64)
                            {
                                allMapTile32_DW[(x * 2) + (sx * 32), (y * 2) + (sy * 32)] = this.Tile32List[tpos].Tile0;
                                allMapTile32_DW[(x * 2) + 1 + (sx * 32), (y * 2) + (sy * 32)] = this.Tile32List[tpos].Tile1;
                                allMapTile32_DW[(x * 2) + (sx * 32), (y * 2) + 1 + (sy * 32)] = this.Tile32List[tpos].Tile2;
                                allMapTile32_DW[(x * 2) + 1 + (sx * 32), (y * 2) + 1 + (sy * 32)] = this.Tile32List[tpos].Tile3;
                            }
                            else
                            {
                                allMapTile32_SP[(x * 2) + (sx * 32), (y * 2) + (sy * 32)] = this.Tile32List[tpos].Tile0;
                                allMapTile32_SP[(x * 2) + 1 + (sx * 32), (y * 2) + (sy * 32)] = this.Tile32List[tpos].Tile1;
                                allMapTile32_SP[(x * 2) + (sx * 32), (y * 2) + 1 + (sy * 32)] = this.Tile32List[tpos].Tile2;
                                allMapTile32_SP[(x * 2) + 1 + (sx * 32), (y * 2) + 1 + (sy * 32)] = this.Tile32List[tpos].Tile3;
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

            return (allMapTile32_LW, allMapTile32_DW, allMapTile32_SP);
        }

        public void CreateMap32TilesFrom16()
        {
            this.t32.Clear();
            this.Tile32Count = 0;

            const int nullVal = -1;
            for (int i = 0; i < Constants.NumberOfMap32; i++)
            {
                short foundIndex = nullVal;
                for (int j = 0; j < this.Tile32Count; j++)
                {
                    if (this.UniqueTile32List[j].Tile0 == this.Map16Tiles[i].Tile0 &&
                        this.UniqueTile32List[j].Tile1 == this.Map16Tiles[i].Tile1 &&
                        this.UniqueTile32List[j].Tile2 == this.Map16Tiles[i].Tile2 &&
                        this.UniqueTile32List[j].Tile3 == this.Map16Tiles[i].Tile3)
                    {
                        foundIndex = (short)j;
                        break;
                    }
                }

                if (foundIndex == nullVal)
                {
                    this.UniqueTile32List[this.Tile32Count] = new Tile32(this.Map16Tiles[i].Tile0, this.Map16Tiles[i].Tile1, this.Map16Tiles[i].Tile2, this.Map16Tiles[i].Tile3);
                    this.t32.Add((ushort)this.Tile32Count);
                    this.Tile32Count++;
                }
                else
                {
                    this.t32.Add((ushort)foundIndex);
                }
            }

            Console.WriteLine("Nbr of tiles32 = " + this.Tile32Count);
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

        public ExitOW[] LoadExits()
        {
            var exits = new List<ExitOW>();
            for (int i = 0; i < this.AllExits.Count(); i++)
            {
                ushort exitRoomID = (ushort)((ROM.DATA[Constants.OWExitRoomId + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitRoomId + (i * 2)]);
                byte exitMapID = ROM.DATA[Constants.OWExitMapId + i];
                byte exitVRAM = (byte)((ROM.DATA[Constants.OWExitVram + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitVram + (i * 2)]);
                short exitYScroll = (short)((ROM.DATA[Constants.OWExitYScroll + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitYScroll + (i * 2)]);
                short exitXScroll = (short)((ROM.DATA[Constants.OWExitXScroll + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitXScroll + (i * 2)]);
                ushort py = (ushort)((ROM.DATA[Constants.OWExitYPlayer + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitYPlayer + (i * 2)]);
                ushort px = (ushort)((ROM.DATA[Constants.OWExitXPlayer + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitXPlayer + (i * 2)]);
                short exitYCamera = (short)((ROM.DATA[Constants.OWExitYCamera + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitYCamera + (i * 2)]);
                short exitXCamera = (short)((ROM.DATA[Constants.OWExitXCamera + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitXCamera + (i * 2)]);
                byte exitScrollModY = ROM.DATA[Constants.OWExitUnk1 + i];
                byte exitScrollModX = ROM.DATA[Constants.OWExitUnk2 + i];
                short exitDoorType1 = (short)((ROM.DATA[Constants.OWExitDoorType1 + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitDoorType1 + (i * 2)]);
                short exitDoorType2 = (short)((ROM.DATA[Constants.OWExitDoorType2 + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitDoorType2 + (i * 2)]);
                ExitOW exit = new ExitOW(exitRoomID, exitMapID, exitVRAM, exitYScroll, exitXScroll, py, px, exitYCamera, exitXCamera, exitScrollModY, exitScrollModX, exitDoorType1, exitDoorType2);

                if (px == 0xFFFF && py == 0xFFFF)
                {
                    exit.Deleted = true;
                }

                exits.Add(exit);
            }

            return exits.ToArray();
        }

        public List<TransportOW> LoadWhirlpools()
        {
            var allWhirlpools = new List<TransportOW>();
            for (int i = 0; i < Constants.OWWhirlpoolCount; i++)
            {
                byte whirlpoolMapID = (byte)((ROM.DATA[Constants.OWExitMapIdWhirlpool + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitMapIdWhirlpool + (i * 2)]);
                short whirlpoolVRAM = (short)((ROM.DATA[Constants.OWExitVramWhirlpool + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitVramWhirlpool + (i * 2)]);
                short whirlpoolYScroll = (short)((ROM.DATA[Constants.OWExitYScrollWhirlpool + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitYScrollWhirlpool + (i * 2)]);
                short whirlpoolXScroll = (short)((ROM.DATA[Constants.OWExitXScrollWhirlpool + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitXScrollWhirlpool + (i * 2)]);
                short whirlpoolYPlayer = (short)((ROM.DATA[Constants.OWExitYPlayerWhirlpool + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitYPlayerWhirlpool + (i * 2)]);
                short whirlpoolXPlayer = (short)((ROM.DATA[Constants.OWExitXPlayerWhirlpool + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitXPlayerWhirlpool + (i * 2)]);
                short whirlpoolYCamera = (short)((ROM.DATA[Constants.OWExitYCameraWhirlpool + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitYCameraWhirlpool + (i * 2)]);
                short whirlpoolXCamera = (short)((ROM.DATA[Constants.OWExitXCameraWhirlpool + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitXCameraWhirlpool + (i * 2)]);
                byte whirlpoolScrollModY = ROM.DATA[Constants.OWExitScrollModYWhirlpool + i];
                byte whirlpoolScrollModX = ROM.DATA[Constants.OWExitScrollModXWhirlpool + i];
                short whirlpoolPosition = (short)((ROM.DATA[Constants.OWWhirlpoolPosition + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWWhirlpoolPosition + (i * 2)]);

                if (i > 8)
                {
                    whirlpoolPosition = (short)((ROM.DATA[Constants.OWWhirlpoolPosition + ((i - 9) * 2) + 1] << 8) + ROM.DATA[Constants.OWWhirlpoolPosition + ((i - 9) * 2)]);
                }

                var transport = new TransportOW(whirlpoolMapID, whirlpoolVRAM, whirlpoolYScroll, whirlpoolXScroll, whirlpoolYPlayer, whirlpoolXPlayer, whirlpoolYCamera, whirlpoolXCamera, whirlpoolScrollModY, whirlpoolScrollModX, whirlpoolPosition);
                allWhirlpools.Add(transport);
            }

            return allWhirlpools;
        }

        public EntranceOW[] LoadEntrances()
        {
            var allEntrances = new EntranceOW[this.AllEntrances.Length];
            for (int i = 0; i < 129; i++)
            {
                short mapId = (short)((ROM.DATA[Constants.OWEntranceMap + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWEntranceMap + (i * 2)]);
                ushort mapPos = (ushort)((ROM.DATA[Constants.OWEntrancePos + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWEntrancePos + (i * 2)]);
                byte entranceId = ROM.DATA[Constants.OWEntranceEntranceId + i];
                int p = mapPos >> 1;
                int x = p % 64;
                int y = p >> 6;
                EntranceOW eo = new EntranceOW((x * 16) + (((mapId % 64) - (((mapId % 64) / 8) * 8)) * 512), (y * 16) + (((mapId % 64) / 8) * 512), entranceId, mapId, mapPos, false);

                if (eo.MapPos == 0xFFFF)
                {
                    eo.Deleted = true;
                }

                allEntrances[i] = eo;
            }

            return allEntrances;
        }

        public EntranceOW[] LoadHoles()
        {
            var allHoles = new EntranceOW[this.AllHoles.Length];
            for (int i = 0; i < 0x13; i++)
            {
                short mapId = (short)((ROM.DATA[Constants.OWHoleArea + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWHoleArea + (i * 2)]);
                short mapPos = (short)((ROM.DATA[Constants.OWHolePos + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWHolePos + (i * 2)]);
                byte entranceId = ROM.DATA[Constants.OWHoleEntrance + i];
                int p = (mapPos + 0x400) >> 1;
                int x = p % 64;
                int y = p >> 6;
                EntranceOW eo = new EntranceOW((x * 16) + (((mapId % 64) - (((mapId % 64) / 8) * 8)) * 512), (y * 16) + (((mapId % 64) / 8) * 512), entranceId, mapId, (ushort)(mapPos + 0x400), true);
                AllHoles[i] = eo;
            }

            return allHoles;
        }

        public void showTile32Count()
        {
            UniqueTile32List.Clear();
            t32.Clear();
            // Create tile32 from tiles16
            List<ulong> alltiles16 = new List<ulong>();

            int sx = 0;
            int sy = 0;
            int c = 0;
            for (int i = 0; i < Constants.NumberOfOWMaps; i++)
            {
                ushort[,] tilesused = AllMapTile32_LW;
                if (i < 64)
                {
                    tilesused = AllMapTile32_LW;
                }
                else if (i < 128 && i >= 64)
                {
                    tilesused = AllMapTile32_DW;
                }
                else
                {
                    tilesused = AllMapTile32_SP;
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
                UniqueTile32List.Add(new Tile32(tiles[i])); // create new tileunique
            }

            while (UniqueTile32List.Count % 4 != 0) // prevent a bug if tilecount is not a multiple of 4
            {
                UniqueTile32List.Add(new Tile32(0));
            }

            MessageBox.Show("Number of unique Tiles32: " + tiles.Count + " Out of: " + Constants.LimitOfMap32);

            alltiles16.Clear();

            Console.WriteLine("Number of unique Tiles32: " + tiles.Count + " Saved:" + UniqueTile32List.Count + " Out of: " + Constants.LimitOfMap32);
            int v = UniqueTile32List.Count;
            for (int i = v; i < Constants.LimitOfMap32; i++)
            {
                UniqueTile32List.Add(new Tile32(666, 666, 666, 666)); // create new tileunique
            }
        }

        public bool createMap32Tilesmap()
        {
            UniqueTile32List.Clear();
            t32.Clear();
            // Create tile32 from tiles16
            List<ulong> alltiles16 = new List<ulong>();

            int sx = 0;
            int sy = 0;
            int c = 0;
            for (int i = 0; i < Constants.NumberOfOWMaps; i++)
            {
                ushort[,] tilesused = AllMapTile32_LW;
                if (i < 64)
                {
                    tilesused = AllMapTile32_LW;
                }
                else if (i < 128 && i >= 64)
                {
                    tilesused = AllMapTile32_DW;
                }
                else
                {
                    tilesused = AllMapTile32_SP;
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
                UniqueTile32List.Add(new Tile32(tiles[i])); // create new tileunique
            }

            while (UniqueTile32List.Count % 4 != 0) // prevent a bug if tilecount is not a multiple of 4
            {
                UniqueTile32List.Add(new Tile32(0));
            }

            alltiles16.Clear();

            if (UniqueTile32List.Count > Constants.LimitOfMap32)
            {
                MessageBox.Show("Number of unique Tiles32: " + tiles.Count + " Out of: " + Constants.LimitOfMap32 + "\r\nUnique Tile32 count exceed the limit\r\nThe ROM Has not been saved\r\nYou can fill maps with grass tiles to free some space\r\nOr use the option Clear DW Tiles in the Overworld Menu");
                return true;
            }

            Console.WriteLine("Number of unique Tiles32: " + tiles.Count + " Saved:" + UniqueTile32List.Count + " Out of: " + Constants.LimitOfMap32);
            int v = UniqueTile32List.Count;
            for (int i = v; i < Constants.LimitOfMap32; i++)
            {
                UniqueTile32List.Add(new Tile32(666, 666, 666, 666)); // create new tileunique
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
                ushort[,] tilesused = AllMapTile32_LW;
                if (i < 64)
                {
                    tilesused = AllMapTile32_LW;
                }
                else if (i < 128 && i >= 64)
                {
                    tilesused = AllMapTile32_DW;
                }
                else
                {
                    tilesused = AllMapTile32_SP;
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
                AllMaps[i].BuildMap();
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
                ushort[,] tilesused = AllMapTile32_LW;
                if (i < 64)
                {
                    tilesused = AllMapTile32_LW;
                }
                else if (i < 128 && i >= 64)
                {
                    tilesused = AllMapTile32_DW;
                }
                else
                {
                    tilesused = AllMapTile32_SP;
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
                    Map16Tiles[tpos] = new Tile32(tiles[(x * 2), (y * 2)], tiles[(x * 2) + 1, (y * 2)], tiles[(x * 2), (y * 2) + 1], tiles[(x * 2) + 1, (y * 2) + 1]);
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
            int c = UniqueTile32List.Count;
            for (int i = 0; i < c; i += 6)
            {
                if (index >= 0x4540) // 3C87??
                {
                    Console.WriteLine("Too many unique tiles!");
                    break;
                }

                // Top Left
                ROM.Write(Constants.map32TilesTL + (i), (byte)(UniqueTile32List[index].Tile0 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTL + (i + 1), (byte)(UniqueTile32List[index + 1].Tile0 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTL + (i + 2), (byte)(UniqueTile32List[index + 2].Tile0 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTL + (i + 3), (byte)(UniqueTile32List[index + 3].Tile0 & 0xFF), WriteType.Tile32);

                ROM.Write(Constants.map32TilesTL + (i + 4), (byte)(((UniqueTile32List[index].Tile0 >> 4) & 0xF0) + ((UniqueTile32List[index + 1].Tile0 >> 8) & 0x0F)), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTL + (i + 5), (byte)(((UniqueTile32List[index + 2].Tile0 >> 4) & 0xF0) + ((UniqueTile32List[index + 3].Tile0 >> 8) & 0x0F)), WriteType.Tile32);

                // Top Right
                ROM.Write(Constants.map32TilesTR + (i), (byte)(UniqueTile32List[index].Tile1 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTR + (i + 1), (byte)(UniqueTile32List[index + 1].Tile1 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTR + (i + 2), (byte)(UniqueTile32List[index + 2].Tile1 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTR + (i + 3), (byte)(UniqueTile32List[index + 3].Tile1 & 0xFF), WriteType.Tile32);

                ROM.Write(Constants.map32TilesTR + (i + 4), (byte)(((UniqueTile32List[index].Tile1 >> 4) & 0xF0) | ((UniqueTile32List[index + 1].Tile1 >> 8) & 0x0F)), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTR + (i + 5), (byte)(((UniqueTile32List[index + 2].Tile1 >> 4) & 0xF0) | ((UniqueTile32List[index + 3].Tile1 >> 8) & 0x0F)), WriteType.Tile32);

                // Bottom Left
                ROM.Write(Constants.map32TilesBL + (i), (byte)(UniqueTile32List[index].Tile2 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesBL + (i + 1), (byte)(UniqueTile32List[index + 1].Tile2 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesBL + (i + 2), (byte)(UniqueTile32List[index + 2].Tile2 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesBL + (i + 3), (byte)(UniqueTile32List[index + 3].Tile2 & 0xFF), WriteType.Tile32);

                ROM.Write(Constants.map32TilesBL + (i + 4), (byte)(((UniqueTile32List[index].Tile2 >> 4) & 0xF0) | ((UniqueTile32List[index + 1].Tile2 >> 8) & 0x0F)), WriteType.Tile32);
                ROM.Write(Constants.map32TilesBL + (i + 5), (byte)(((UniqueTile32List[index + 2].Tile2 >> 4) & 0xF0) | ((UniqueTile32List[index + 3].Tile2 >> 8) & 0x0F)), WriteType.Tile32);

                // Bottom Right
                ROM.Write(Constants.map32TilesBR + (i), (byte)(UniqueTile32List[index].Tile3 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesBR + (i + 1), (byte)(UniqueTile32List[index + 1].Tile3 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesBR + (i + 2), (byte)(UniqueTile32List[index + 2].Tile3 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesBR + (i + 3), (byte)(UniqueTile32List[index + 3].Tile3 & 0xFF), WriteType.Tile32);

                ROM.Write(Constants.map32TilesBR + (i + 4), (byte)(((UniqueTile32List[index].Tile3 >> 4) & 0xF0) | ((UniqueTile32List[index + 1].Tile3 >> 8) & 0x0F)), WriteType.Tile32);
                ROM.Write(Constants.map32TilesBR + (i + 5), (byte)(((UniqueTile32List[index + 2].Tile3 >> 4) & 0xF0) | ((UniqueTile32List[index + 3].Tile3 >> 8) & 0x0F)), WriteType.Tile32);

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

        public List<RoomPotSaveEditor> LoadItems()
        {
            var allItems = new List<RoomPotSaveEditor>();

            int pointer = ROM.ReadLong(Constants.overworldItemsAddress);
            int oointerPC = Utils.SnesToPc(pointer); // 1BC2F9 -> 0DC2F9
            for (int i = 0; i < 128; i++)
            {
                int addr = (pointer & 0xFF0000) + // 1B
                            (ROM.DATA[oointerPC + (i * 2) + 1] << 8) + // F9
                            ROM.DATA[oointerPC + (i * 2)]; // 3C

                addr = Utils.SnesToPc(addr);

                if (this.AllMaps[i].largeMap)
                {
                    if (this.AllMaps[i].parent != (byte)i)
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

                    int fakeID = i;
                    if (fakeID >= 64)
                    {
                        fakeID -= 64;
                    }

                    int sy = fakeID / 8;
                    int sx = fakeID - (sy * 8);

                    allItems.Add(new RoomPotSaveEditor(b3, (ushort)i, (x * 16) + (sx * 512), (y * 16) + (sy * 512), false));
                    allItems[allItems.Count - 1].gameX = (byte)x;
                    allItems[allItems.Count - 1].gameY = (byte)y;
                    addr += 3;
                }
            }

            return allItems;
        }

        public OverlayData[] LoadOverlays()
        {
            /*
                0x7765B: ;Original byte = 0x0A
                22 9C 87 00 EA ;JSL long jump table
            */

            var allOverlays = new OverlayData[this.AllOverlays.Length];

            for (int index = 0; index < this.AllOverlays.Length; index++)
            {
                allOverlays[index] = new OverlayData();

                // OverlayPointers
                Console.WriteLine("MapIndex Overlay : " + index.ToString());

                int address = (Constants.overlayPointersBank << 16) +
                (ROM.DATA[Constants.overlayPointers + (index * 2) + 1] << 8) +
                ROM.DATA[Constants.overlayPointers + (index * 2)];
                address = Utils.SnesToPc(address);

                if (ROM.DATA[Constants.overlayData1] == 0x6B)
                {
                    address = Utils.SnesToPc((ROM.DATA[Constants.overlayData2 + 2 + (index * 3)] << 16) + (ROM.DATA[Constants.overlayData2 + 1 + (index * 3)] << 8) + ROM.DATA[Constants.overlayData2 + (index * 3)]);

                    // Load New Address.
                }

                /*
                    16-bit mode:
                    A9 (LDA #$)
                    A2 (LDX #$)
                    8D (STA $xxxx)
                    9D (STA $xxxx ,x)
                    8F (STA $xxxxxx)
                    1A (INC A)
                    4C (JMP)
                    60 (END)
                */

                int a = 0;
                int x = 0;
                byte value = 0;
                while (value != 0x60)
                {
                    value = ROM.DATA[address];
                    if (value == 0xFF)
                    {
                        break;
                    }
                    else if (value == 0xA9) // LDA #$xxxx (Increase addr+3)
                    {
                        a = (ROM.DATA[address + 2] << 8) +
                        ROM.DATA[address + 1];

                        address += 3;
                        continue;
                    }
                    else if (value == 0xA2) // LDX #$xxxx (Increase addr+3)
                    {
                        x = (ROM.DATA[address + 2] << 8) +
                        ROM.DATA[address + 1];

                        address += 3;
                        continue;
                    }
                    else if (value == 0x8D) // STA $xxxx (Increase addr+3)
                    {
                        int sta = (ROM.DATA[address + 2] << 8) +
                        ROM.DATA[address + 1];

                        sta &= 0x1FFF;
                        int yp = (sta / 2) / 0x40;
                        int xp = (sta / 2) - (yp * 0x40);
                        allOverlays[index].TileDataList.Add(new TilePos((byte)xp, (byte)yp, (ushort)a));

                        address += 3;
                        continue;
                    }
                    else if (value == 0x9D) // STA $xxxx, x (Increase addr+3)
                    {
                        int sta = (ROM.DATA[address + 2] << 8) +
                        ROM.DATA[address + 1];

                        // Draw tile at sta,X position
                        int stax = (sta & 0x1FFF) + x;
                        int yp = (stax / 2) / 0x40;
                        int xp = (stax / 2) - (yp * 0x40);
                        allOverlays[index].TileDataList.Add(new TilePos((byte)xp, (byte)yp, (ushort)a));

                        address += 3;
                        continue;
                    }
                    else if (value == 0x8F) // STA $xxxxxx (Increase addr+4)
                    {
                        int sta = (ROM.DATA[address + 2] << 8) +
                        ROM.DATA[address + 1];

                        int stax = (sta & 0x1FFF) + x;
                        int yp = (stax / 2) / 0x40;
                        int xp = (stax / 2) - (yp * 0x40);
                        allOverlays[index].TileDataList.Add(new TilePos((byte)xp, (byte)yp, (ushort)a));

                        address += 4;
                        continue;
                    }
                    else if (value == 0x1A) // INC A (Increase addr+1)
                    {
                        a += 1;

                        address += 1;
                        continue;
                    }
                    else if (value == 0x4C) // JMP $xxxx (move addr to the new address)
                    {
                        address = (Constants.overlayPointersBank << 16) +
                        (ROM.DATA[address + 2] << 8) +
                        ROM.DATA[address + 1];
                        address = Utils.SnesToPc(address);

                        // THAT SHOULD NOT EXIST IN MOVED CODE SO NO NEED TO CHANGE IT.
                        continue;
                    }
                    else if (value == 0x60) // RTS
                    {
                        break; // Just to be sure.
                    }
                    else if (value == 0x6B) // RTL
                    {
                        break; // Just to be sure.
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
                }
            }

            return allOverlays;
        }

        public List<Sprite>[] LoadSprites()
        {
            // LW[0] = RainState 0 to 63 there's no data for DW.
            // LW[1] = ZeldaState 0 to 128 ; Contains LW and DW <128 or 144 wtf.
            // LW[2] = AgahState 0 to ?? ;Contains data for LW and DW.

            //Console.WriteLine(((Constants.overworldSpritesBegining & 0xFFFF) + (09 << 16)).ToString("X6"));

            var allSprites = new List<Sprite>[3] { new List<Sprite>(), new List<Sprite>(), new List<Sprite>() };
            for (int i = 0; i < 64; i++)
            {
                if (this.AllMaps[i].parent == i)
                {
                    // Beginning Sprites
                    int ptrPos = Constants.overworldSpritesBegining + (i * 2);
                    int spriteAddress = Utils.SnesToPc((09 << 16) + ROM.ReadShort(ptrPos));
                    while (true)
                    {
                        byte b1 = ROM.DATA[spriteAddress];
                        byte b2 = ROM.DATA[spriteAddress + 1];
                        byte b3 = ROM.DATA[spriteAddress + 2];
                        if (b1 == 0xFF)
                        {
                            break;
                        }

                        int mapY = i / 8;
                        int mapX = i % 8;

                        int realX = ((b2 & 0x3F) * 16) + (mapX * 512);
                        int realY = ((b1 & 0x3F) * 16) + (mapY * 512);

                        allSprites[0].Add(new Sprite((byte)i, b3, (byte)(b2 & 0x3F), (byte)(b1 & 0x3F), realX, realY));

                        spriteAddress += 3;
                    }
                }
            }

            for (int i = 0; i < 144; i++)
            {
                if (this.AllMaps[i].parent == i)
                {
                    // Zelda Saved Sprites.
                    int ptrPos = Constants.overworldSpritesZelda + (i * 2);
                    int spriteAddress = Utils.SnesToPc((09 << 16) + ROM.ReadShort(ptrPos));
                    while (true)
                    {
                        byte b1 = ROM.DATA[spriteAddress];
                        byte b2 = ROM.DATA[spriteAddress + 1];
                        byte b3 = ROM.DATA[spriteAddress + 2];
                        if (b1 == 0xFF)
                        {
                            break;
                        }

                        int editorMapIndex = i;
                        if (editorMapIndex >= 128)
                        {
                            editorMapIndex = i - 128;
                        }
                        else if (editorMapIndex >= 64)
                        {
                            editorMapIndex = i - 64;
                        }

                        int mapY = editorMapIndex / 8;
                        int mapX = editorMapIndex % 8;

                        int realX = ((b2 & 0x3F) * 16) + (mapX * 512);
                        int realY = ((b1 & 0x3F) * 16) + (mapY * 512);

                        allSprites[1].Add(new Sprite((byte)i, b3, (byte)(b2 & 0x3F), (byte)(b1 & 0x3F), realX, realY));

                        spriteAddress += 3;
                    }
                }

                // Agahnim Dead Sprites.
                if (this.AllMaps[i].parent == i)
                {
                    int ptrPos = Constants.overworldSpritesAgahnim + (i * 2);
                    int spriteAddress = Utils.SnesToPc((09 << 16) + ROM.ReadShort(ptrPos));
                    while (true)
                    {
                        byte b1 = ROM.DATA[spriteAddress];
                        byte b2 = ROM.DATA[spriteAddress + 1];
                        byte b3 = ROM.DATA[spriteAddress + 2];
                        if (b1 == 0xFF)
                        {
                            break;
                        }

                        int editorMapIndex = i;
                        if (editorMapIndex >= 128)
                        {
                            editorMapIndex = i - 128;
                        }
                        else if (editorMapIndex >= 64)
                        {
                            editorMapIndex = i - 64;
                        }

                        int mapY = editorMapIndex / 8;
                        int mapX = editorMapIndex % 8;

                        int realX = ((b2 & 0x3F) * 16) + (mapX * 512);
                        int realY = ((b1 & 0x3F) * 16) + (mapY * 512);

                        allSprites[2].Add(new Sprite((byte)i, b3, (byte)(b2 & 0x3F), (byte)(b1 & 0x3F), realX, realY));

                        spriteAddress += 3;
                    }
                }
            }

            return allSprites;
        }

        public bool createMap16Tilesmap()
        {
            uniqueTile16List.Clear();
            t16.Clear();

            // Create tile32 from tiles16
            List<ulong> alltiles8 = new List<ulong>();

            int sx = 0;
            int sy = 0;
            int c = 0;
            for (int i = 0; i < Constants.NumberOfOWMaps; i++)
            {
                TileInfo[,] tilesused = TempTile8Array_LW;
                if (i < 64)
                {
                    tilesused = TempTile8Array_LW;
                }
                else if (i < 128 && i >= 64)
                {
                    tilesused = TempTile8Array_DW;
                }
                else
                {
                    tilesused = TempTile8Array_SP;
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
                uniqueTile16List.Add(new Tile16(tiles[i])); // create new tileunique
            }

            while (uniqueTile16List.Count % 4 != 0) // prevent a bug if tilecount is not a multiple of 4
            {
                uniqueTile16List.Add(new Tile16(0));
            }

            if (uniqueTile16List.Count > Constants.LimitOfMap32)
            {
                if (MessageBox.Show("Unique Tiles16 count exceed the limit in the rom\nTiles data won't be saved would you like to export map data?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // TODO: add something here?
                }

                return true;
            }

            Tile16List.Clear();
            for (int i = 0; i < uniqueTile16List.Count; i++)
            {
                ulong t = uniqueTile16List[i].GetLongData();
                Tile16List.Add(new Tile16(t));
            }

            alltiles8.Clear();

            Console.WriteLine("Nbr of uniquetiles16 = " + tiles.Count + " " + uniqueTile16List.Count);
            return false;
        }
    }
}
