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

namespace ZeldaFullEditor
{

    public class Overworld
    {
        public List<Tile16> tiles16;
        public List<Tile32> tiles32;
        private int[] map32address;

        public Tile32[] map16tiles;
        public List<Size> posSize;

        public List<Tile32> t32Unique = new List<Tile32>();
        public List<ushort> t32;

        public ExitOW[] allexits = new ExitOW[0x4F];

        public bool showSprites = true;

        //That must stay global - that's a problem
        public ushort[,] allmapsTilesLW = new ushort[512, 512]; //64 maps * (32*32 tiles)
        public ushort[,] allmapsTilesDW = new ushort[512, 512]; //64 maps * (32*32 tiles)
        public ushort[,] allmapsTilesSP = new ushort[512, 512]; //32 maps * (32*32 tiles)
        public OverworldMap[] allmaps = new OverworldMap[160];
        public EntranceOWEditor[] allentrances = new EntranceOWEditor[129];
        public EntranceOWEditor[] allholes = new EntranceOWEditor[0x13];
        public List<RoomPotSaveEditor> allitems = new List<RoomPotSaveEditor>();

        public int worldOffset = 0;

        //TODO : Fix Whirlpool on large maps
        public List<TransportOW> allWhirlpools = new List<TransportOW>();
        public List<TransportOW> allBirds = new List<TransportOW>();

        public byte gameState = 1;

        public byte[] mapParent = new byte[160];

        public bool isLoaded = false;

        public Overworld()
        {
            tiles16 = new List<Tile16>();
            tiles32 = new List<Tile32>();

            map16tiles = new Tile32[40960];
            posSize = new List<Size>();

            t32 = new List<ushort>();

            
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                AssembleMap32Tiles();
                AssembleMap16Tiles();
                DecompressAllMapTiles();
                //Map Initialization :
                for (int i = 0; i < 160; i++)
                {
                    allmaps[i] = new OverworldMap((byte)i, this);
                }
                getLargeMaps();
                for (int i = 0; i < 160; i++)
                {
                    allmaps[i].BuildMap();
                }
                loadExits();
                loadEntrances();
                loadItems();
                loadTransports();
                isLoaded = true;

            }).Start();





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

                int i = xx + (yy * 8);
                if (mapChecked[i] == false)
                {
                    if (allmaps[i].largeMap == true)
                    {
                        mapChecked[i] = true;
                        mapParent[i] = (byte)i;
                        mapParent[i + 64] = (byte)(i + 64);

                        mapChecked[i + 1] = true;
                        mapParent[i + 1] = (byte)i;
                        mapParent[i + 65] = (byte)(i + 64);

                        mapChecked[i + 8] = true;
                        mapParent[i + 8] = (byte)i;
                        mapParent[i + 72] = (byte)(i + 64);

                        mapChecked[i + 9] = true;
                        mapParent[i + 9] = (byte)i;
                        mapParent[i + 73] = (byte)(i + 64);
                        xx++;
                    }
                    else
                    {
                        mapParent[i] = (byte)i;
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
            for (int i = 0; i < 4096; i += 1)//3760
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
            for (int i = 0; i < 3760; i += 1)//3760
            {
                ROM.DATA[tpos] = (byte)(tiles16[i].tile0.toShort() & 0xFF);
                ROM.DATA[tpos + 1] = (byte)((tiles16[i].tile0.toShort() >> 8) & 0xFF);
                tpos += 2;
                ROM.DATA[tpos] = (byte)(tiles16[i].tile1.toShort() & 0xFF);
                ROM.DATA[tpos + 1] = (byte)((tiles16[i].tile1.toShort() >> 8) & 0xFF);
                tpos += 2;
                ROM.DATA[tpos] = (byte)(tiles16[i].tile2.toShort() & 0xFF);
                ROM.DATA[tpos + 1] = (byte)((tiles16[i].tile2.toShort() >> 8) & 0xFF);
                tpos += 2;
                ROM.DATA[tpos] = (byte)(tiles16[i].tile3.toShort() & 0xFF);
                ROM.DATA[tpos + 1] = (byte)((tiles16[i].tile3.toShort() >> 8) & 0xFF);
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
            //int npos = 0;
            int sx = 0;
            int sy = 0;
            int c = 0;
            for (int i = 0; i < 160; i++)
            {

                int p1 =
                (ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 2 + (int)(3 * i)] << 16) +
                (ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 1 + (int)(3 * i)] << 8) +
                (ROM.DATA[(Constants.compressedAllMap32PointersHigh + (int)(3 * i))]);
                p1 = Utils.SnesToPc(p1);

                int p2 =
                (ROM.DATA[(Constants.compressedAllMap32PointersLow) + 2 + (int)(3 * i)] << 16) +
                (ROM.DATA[(Constants.compressedAllMap32PointersLow) + 1 + (int)(3 * i)] << 8) +
                (ROM.DATA[(Constants.compressedAllMap32PointersLow + (int)(3 * i))]);
                p2 = Utils.SnesToPc(p2);

                int ttpos = 0;
                int compressedSize1 = 0;
                int compressedSize2 = 0;


                byte[] bytes = ZCompressLibrary.Decompress.ALTTPDecompressOverworld(ROM.DATA, p2, 1000, ref compressedSize1);
                byte[] bytes2 = ZCompressLibrary.Decompress.ALTTPDecompressOverworld(ROM.DATA, p1, 1000, ref compressedSize2);

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
                                allmapsTilesLW[(x * 2) + (sx * 32), (y * 2) + (sy * 32)] = tiles32[tpos].tile0;
                                allmapsTilesLW[(x * 2) + 1 + (sx * 32), (y * 2) + (sy * 32)] = tiles32[tpos].tile1;
                                allmapsTilesLW[(x * 2) + (sx * 32), (y * 2) + 1 + (sy * 32)] = tiles32[tpos].tile2;
                                allmapsTilesLW[(x * 2) + 1 + (sx * 32), (y * 2) + 1 + (sy * 32)] = tiles32[tpos].tile3;
                            }
                            else if (i < 128 && i >= 64)
                            {
                                allmapsTilesDW[(x * 2) + (sx * 32), (y * 2) + (sy * 32)] = tiles32[tpos].tile0;
                                allmapsTilesDW[(x * 2) + 1 + (sx * 32), (y * 2) + (sy * 32)] = tiles32[tpos].tile1;
                                allmapsTilesDW[(x * 2) + (sx * 32), (y * 2) + 1 + (sy * 32)] = tiles32[tpos].tile2;
                                allmapsTilesDW[(x * 2) + 1 + (sx * 32), (y * 2) + 1 + (sy * 32)] = tiles32[tpos].tile3;
                            }
                            else
                            {
                                allmapsTilesSP[(x * 2) + (sx * 32), (y * 2) + (sy * 32)] = tiles32[tpos].tile0;
                                allmapsTilesSP[(x * 2) + 1 + (sx * 32), (y * 2) + (sy * 32)] = tiles32[tpos].tile1;
                                allmapsTilesSP[(x * 2) + (sx * 32), (y * 2) + 1 + (sy * 32)] = tiles32[tpos].tile2;
                                allmapsTilesSP[(x * 2) + 1 + (sx * 32), (y * 2) + 1 + (sy * 32)] = tiles32[tpos].tile3;
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
        }

        public int tiles32count = 0;
        public void createMap32TilesFrom16()
        {
            t32.Clear();
            tiles32count = 0;


            const int nullVal = -1;
            for (int i = 0; i < 40960; i++) //40960 = numbers of 32x32 tiles
            {
                short foundIndex = nullVal;
                for (int j = 0; j < tiles32count; j++)
                    if (t32Unique[j].tile0 == map16tiles[i].tile0)
                        if (t32Unique[j].tile1 == map16tiles[i].tile1)
                            if (t32Unique[j].tile2 == map16tiles[i].tile2)
                                if (t32Unique[j].tile3 == map16tiles[i].tile3)
                                {
                                    foundIndex = (short)j;
                                    break;
                                }


                if (foundIndex == nullVal)
                {
                    t32Unique[tiles32count] = new Tile32(map16tiles[i].tile0, map16tiles[i].tile1, map16tiles[i].tile2, map16tiles[i].tile3);
                    t32.Add((ushort)tiles32count);
                    tiles32count++;
                }
                else t32.Add((ushort)foundIndex);
            }

            Console.WriteLine("Nbr of tiles32 = " + tiles32count);
        }

        /*
         * 
            for (int i = 0; i < 128; i++)
            {
                byte m = entranceOWs[i].entranceId;
                short s = (short)(entranceOWs[i].mapId);
                int p = entranceOWs[i].mapPos >> 1;
                int x = (p % 64);
                int y = (p >> 6);
                entranceOWsEditor[i] = new EntranceOWEditor((x * 16) + (((s % 64) - (((s % 64) / 8) * 8)) * 512), (y * 16) + (((s % 64) / 8) * 512), m, s, entranceOWs[i].mapPos);
            }
         * */
        public void loadExits()
        {
            for (int i = 0; i < 0x4F; i++)
            {
                short[] e = new short[13];
                e[0] = (short)((ROM.DATA[Constants.OWExitRoomId + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitRoomId + (i * 2)]));
                e[1] = (byte)((ROM.DATA[Constants.OWExitMapId + i]));
                e[2] = (short)((ROM.DATA[Constants.OWExitVram + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitVram + (i * 2)]));
                e[3] = (short)((ROM.DATA[Constants.OWExitYScroll + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitYScroll + (i * 2)]));
                e[4] = (short)((ROM.DATA[Constants.OWExitXScroll + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitXScroll + (i * 2)]));
                ushort py = (ushort)((ROM.DATA[Constants.OWExitYPlayer + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitYPlayer + (i * 2)]));
                ushort px = (ushort)((ROM.DATA[Constants.OWExitXPlayer + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitXPlayer + (i * 2)]));
                e[7] = (short)((ROM.DATA[Constants.OWExitYCamera + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitYCamera + (i * 2)]));
                e[8] = (short)((ROM.DATA[Constants.OWExitXCamera + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitXCamera + (i * 2)]));
                e[9] = (byte)((ROM.DATA[Constants.OWExitUnk1 + i]));
                e[10] = (byte)((ROM.DATA[Constants.OWExitUnk2 + i]));
                e[11] = (short)((ROM.DATA[Constants.OWExitDoorType1 + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitDoorType1 + (i * 2)]));
                e[12] = (short)((ROM.DATA[Constants.OWExitDoorType2 + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitDoorType2 + (i * 2)]));
                ExitOW eo = (new ExitOW(e[0], (byte)e[1], e[2], e[3], e[4], py, px, e[7], e[8], (byte)e[9], (byte)e[10], e[11], e[12]));
                if (px == 0xFFFF && py == 0xFFFF)
                {
                    eo.deleted = true;
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
                e[8] = (byte)((ROM.DATA[Constants.OWExitUnk1Whirlpool + i]));
                e[9] = (byte)((ROM.DATA[Constants.OWExitUnk2Whirlpool + i]));
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
                byte entranceId = (byte)((ROM.DATA[Constants.OWEntranceEntranceId + i]));
                int p = mapPos >> 1;
                int x = (p % 64);
                int y = (p >> 6);
                EntranceOWEditor eo = new EntranceOWEditor((x * 16) + (((mapId % 64) - (((mapId % 64) / 8) * 8)) * 512), (y * 16) + (((mapId % 64) / 8) * 512), entranceId, mapId, mapPos);
                if (eo.mapPos == 0xFFFF)
                {
                    eo.deleted = true;
                }
                allentrances[i] = eo;


            }


            for (int i = 0; i < 0x13; i++)
            {
                short mapId = (short)((ROM.DATA[Constants.OWHoleArea + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWHoleArea + (i * 2)]));
                short mapPos = (short)((ROM.DATA[Constants.OWHolePos + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWHolePos + (i * 2)]));
                byte entranceId = (byte)((ROM.DATA[Constants.OWHoleEntrance + i]));
                int p = (mapPos + 0x400) >> 1;
                int x = (p % 64);
                int y = (p >> 6);
                EntranceOWEditor eo = new EntranceOWEditor((x * 16) + (((mapId % 64) - (((mapId % 64) / 8) * 8)) * 512), (y * 16) + (((mapId % 64) / 8) * 512), entranceId, mapId, (ushort)(mapPos + 0x400));
                allholes[i] = eo;

            }
        }


        public bool createMap32Tilesmap()
        {
            t32Unique.Clear();
            t32.Clear();
            //Create tile32 from tiles16
            List<ulong> alltiles16 = new List<ulong>();

            int sx = 0;
            int sy = 0;
            int c = 0;
            for (int i = 0; i < 160; i++)
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
                            tilesused[x + (sx * 32), y + 1 + (sy * 32)], tilesused[x + 1 + (sx * 32), y + 1 + (sy * 32)]).getLongValue());
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


            List<ulong> tiles = alltiles16.Distinct().ToList();//that get rid of duplicated tiles using linq
            //alltiles16 = all tiles32...
            //tiles = all tiles32 that are uniques double are removed
            Dictionary<ulong, ushort> alltilesIndexed = new Dictionary<ulong, ushort>();

            for (int i = 0; i < tiles.Count; i++)
            {
                alltilesIndexed.Add(tiles[i], (ushort)i); //index the uniques tiles with a dictionary
            }

            for (int i = 0; i < 40960; i++) //40960 = numbers of 32x32 tiles (160 * (16*16))
            {
                t32.Add(alltilesIndexed[alltiles16[i]]); //add all tiles32 from all maps
                //convert all tiles32 non-unique ids into unique array of ids
            }

            for (int i = 0; i < tiles.Count; i++) //for each uniques tile32
            {
                t32Unique.Add(new Tile32(tiles[i])); //create new tileunique
            }

            while (t32Unique.Count % 4 != 0) //prevent a bug if tilecount is not a multiple of 4
            {
                t32Unique.Add(new Tile32(0));
            }

            if (t32Unique.Count > 8864)
            {

                if (MessageBox.Show("Unique Tiles32 count exceed the limit in the rom\nTiles data won't be saved would you like to export map data?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ExportMaps();
                }
                return true;
            }

            alltiles16.Clear();

            Console.WriteLine("Nbr of uniquetiles32 = " + tiles.Count + " " + t32Unique.Count);
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
            for (int i = 0; i < 160; i++)
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
            for (int i = 0; i < 160; i++)
            {
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


        //UNUSED CODE
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
                if (i >= 0x3C87)
                {
                    Console.WriteLine("Too Many Unique Tiles !");
                    break;
                }

                //Top Left
                ROM.DATA[Constants.map32TilesTL + (i)] = (byte)(t32Unique[index].tile0 & 0xFF);
                ROM.DATA[Constants.map32TilesTL + (i + 1)] = (byte)(t32Unique[index + 1].tile0 & 0xFF);
                ROM.DATA[Constants.map32TilesTL + (i + 2)] = (byte)(t32Unique[index + 2].tile0 & 0xFF);
                ROM.DATA[Constants.map32TilesTL + (i + 3)] = (byte)(t32Unique[index + 3].tile0 & 0xFF);

                ROM.DATA[Constants.map32TilesTL + (i + 4)] = (byte)(((t32Unique[index].tile0 >> 4) & 0xF0) + ((t32Unique[index + 1].tile0 >> 8) & 0x0F));
                ROM.DATA[Constants.map32TilesTL + (i + 5)] = (byte)(((t32Unique[index + 2].tile0 >> 4) & 0xF0) + ((t32Unique[index + 3].tile0 >> 8) & 0x0F));

                //Top Right
                ROM.DATA[Constants.map32TilesTR + (i)] = (byte)(t32Unique[index].tile1 & 0xFF);
                ROM.DATA[Constants.map32TilesTR + (i + 1)] = (byte)(t32Unique[index + 1].tile1 & 0xFF);
                ROM.DATA[Constants.map32TilesTR + (i + 2)] = (byte)(t32Unique[index + 2].tile1 & 0xFF);
                ROM.DATA[Constants.map32TilesTR + (i + 3)] = (byte)(t32Unique[index + 3].tile1 & 0xFF);

                ROM.DATA[Constants.map32TilesTR + (i + 4)] = (byte)(((t32Unique[index].tile1 >> 4) & 0xF0) | ((t32Unique[index + 1].tile1 >> 8) & 0x0F));
                ROM.DATA[Constants.map32TilesTR + (i + 5)] = (byte)(((t32Unique[index + 2].tile1 >> 4) & 0xF0) | ((t32Unique[index + 3].tile1 >> 8) & 0x0F));

                //Bottom Left
                ROM.DATA[Constants.map32TilesBL + (i)] = (byte)(t32Unique[index].tile2 & 0xFF);
                ROM.DATA[Constants.map32TilesBL + (i + 1)] = (byte)(t32Unique[index + 1].tile2 & 0xFF);
                ROM.DATA[Constants.map32TilesBL + (i + 2)] = (byte)(t32Unique[index + 2].tile2 & 0xFF);
                ROM.DATA[Constants.map32TilesBL + (i + 3)] = (byte)(t32Unique[index + 3].tile2 & 0xFF);

                ROM.DATA[Constants.map32TilesBL + (i + 4)] = (byte)(((t32Unique[index].tile2 >> 4) & 0xF0) | ((t32Unique[index + 1].tile2 >> 8) & 0x0F));
                ROM.DATA[Constants.map32TilesBL + (i + 5)] = (byte)(((t32Unique[index + 2].tile2 >> 4) & 0xF0) | ((t32Unique[index + 3].tile2 >> 8) & 0x0F));

                //Bottom Right
                ROM.DATA[Constants.map32TilesBR + (i)] = (byte)(t32Unique[index].tile3 & 0xFF);
                ROM.DATA[Constants.map32TilesBR + (i + 1)] = (byte)(t32Unique[index + 1].tile3 & 0xFF);
                ROM.DATA[Constants.map32TilesBR + (i + 2)] = (byte)(t32Unique[index + 2].tile3 & 0xFF);
                ROM.DATA[Constants.map32TilesBR + (i + 3)] = (byte)(t32Unique[index + 3].tile3 & 0xFF);

                ROM.DATA[Constants.map32TilesBR + (i + 4)] = (byte)(((t32Unique[index].tile3 >> 4) & 0xF0) | ((t32Unique[index + 1].tile3 >> 8) & 0x0F));
                ROM.DATA[Constants.map32TilesBR + (i + 5)] = (byte)(((t32Unique[index + 2].tile3 >> 4) & 0xF0) | ((t32Unique[index + 3].tile3 >> 8) & 0x0F));


                index += 4;
                c += 2;
            }

        }


        public void savemapstorom()
        {
            int pos = 0x120000;
            for (int i = 0; i < 160; i++)
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

       /* public void savemapstorom()
        {
            int pos = 0x058000;
            for (int i = 0; i < 160; i++)
            {
                int npos = 0;
                byte[]
                    singlemap1 = new byte[512],
                    singlemap2 = new byte[512];
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        singlemap1[npos] = (byte)(t32[npos + (i * 256)] & 0xFF);
                        singlemap2[npos] = (byte)((t32[npos + (i * 256)] >> 8) & 0xFF);
                        npos++;
                    }
                }
                byte[] a = ZCompressLibrary.Compress.ALTTPCompressOverworld(singlemap1, 0, 262);
                byte[] b = ZCompressLibrary.Compress.ALTTPCompressOverworld(singlemap2, 0, 262);

                int snesPos = Utils.PcToSnes(pos);
                ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 0 + (int)(3 * i)] = (byte)(snesPos & 0xFF);
                ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 1 + (int)(3 * i)] = (byte)((snesPos >> 8) & 0xFF);
                ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 2 + (int)(3 * i)] = (byte)((snesPos >> 16) & 0xFF);

                //ROM.DATA[pos] = 0xE0;
                //ROM.DATA[pos + 1] = 0xFF;
                //pos += 2;
                for (int j = 0; j < b.Length; j++)
                {
                    ROM.DATA[pos] = b[j];
                    pos += 1;
                }
                //ROM.DATA[pos] = 0xFF;
                //pos += 1;
                snesPos = Utils.PcToSnes(pos);
                ROM.DATA[(Constants.compressedAllMap32PointersLow) + 0 + (int)(3 * i)] = (byte)((snesPos >> 00) & 0xFF);
                ROM.DATA[(Constants.compressedAllMap32PointersLow) + 1 + (int)(3 * i)] = (byte)((snesPos >> 08) & 0xFF);
                ROM.DATA[(Constants.compressedAllMap32PointersLow) + 2 + (int)(3 * i)] = (byte)((snesPos >> 16) & 0xFF);

                //ROM.DATA[pos] = 0xE0;
                //ROM.DATA[pos + 1] = 0xFF;
                //pos += 2;
                for (int j = 0; j < a.Length; j++)
                {
                    ROM.DATA[pos] = a[j];
                    pos += 1;
                }
                //ROM.DATA[pos] = 0xFF;
                //pos += 1;

            }
            Console.WriteLine("Map Pos Length: " + pos.ToString("X6"));
            //Save32Tiles();
        }*/

        public void loadItems()
        {
            int ptr = (ROM.DATA[Constants.overworldItemsAddress + 2] << 16) +
            (ROM.DATA[Constants.overworldItemsAddress + 1] << 8) +
                (ROM.DATA[Constants.overworldItemsAddress]); //1BC2F9
            for (int i = 0; i < 128; i++)
            {

                int ptrpc = Utils.SnesToPc(ptr);//1BC2F9 -> 0DC2F9
                int addr = ((ptr & 0xFF0000)) + //1B
                            (ROM.DATA[ptrpc + (i * 2) + 1] << 8) + //F9
                            (ROM.DATA[ptrpc + (i * 2)]); //3C

                addr = Utils.SnesToPc(addr);

                if (allmaps[i].largeMap == true)
                {
                    if (mapParent[i] != (byte)i)
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
                    if (i == 64)
                    {
                        Console.WriteLine("X : " + x * 16 + ", Y:" + y * 16);
                    }
                    allitems[allitems.Count - 1].gameX = (byte)x;
                    allitems[allitems.Count - 1].gameY = (byte)y;
                    addr += 3;
                }
            }


        }

        /*public void savemapstoromNEW(MapSave[] allmaps)
        {
            int pos = 0x19FE20;
            int pointerPos = 0x19FE20;
            for (int i = 0; i < 159; i++)
            {
                pointerPos = 0x19FE20 + (i * 3);
                pos = 0x1A0000 + (i * 2048);
                int snesPos = Utils.PcToSnes(pos);
                ROM.DATA[pointerPos + 0] = (byte)(snesPos & 0xFF);
                ROM.DATA[pointerPos + 1] = (byte)((snesPos >> 8) & 0xFF);
                ROM.DATA[pointerPos + 2] = (byte)((snesPos >> 16) & 0xFF);
                for (int y = 0; y < 32; y++)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        ROM.DATA[pos + 1] = (byte)((allmaps[i].tiles[x, y] >> 8) & 0xFF);
                        ROM.DATA[pos] = (byte)((allmaps[i].tiles[x, y]) & 0xFF);
                        pos += 2;
                    }
                }
            }
        }*/
    }

}