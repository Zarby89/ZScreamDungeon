using System;
using System.Collections.Generic;
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
        /// <summary>
        ///     Gets or sets the list of all 16x16 overworld tiles.
        /// </summary>
        public List<Tile16> Tile16List { get; set; } = new List<Tile16>();

        /// <summary>
        ///     Gets or sets the list of all Tile32 found on the whole overworld map.
        /// </summary>
        public List<ushort> Tile32List { get; set; } = new List<ushort>();

        /// <summary>
        ///     Gets or sets the list of all unique 32x32 overworld tiles.
        /// </summary>
        public List<Tile32> UniqueTile32List { get; set; } = new List<Tile32>();

        /// <summary>
        ///     Gets or sets a list of Tile32.
        ///     TODO: Was possibly used in loading maps tiles but appears unused. Needs more investigation.
        /// </summary>
        public Tile32[] Map16Tiles { get; set; } = new Tile32[Constants.NumberOfMap32];

        /// <summary>
        ///     Gets or sets a list of LW TileInfo (8x8 tiles).
        ///     TODO: Was possibly used in loading maps tiles but appears unused. Needs more investigation.
        /// </summary>
        public TileInfo[,] TempTile8ArrayLW { get; set; } = new TileInfo[512, 512];

        /// <summary>
        ///     Gets or sets a list of DW TileInfo (8x8 tiles).
        ///     TODO: Was possibly used in loading maps tiles but appears unused. Needs more investigation.
        /// </summary>
        public TileInfo[,] TempTile8ArrayDW { get; set; } = new TileInfo[512, 512]; // all maps tiles8.

        /// <summary>
        ///     Gets or sets a list of SP TileInfo (8x8 tiles).
        ///     TODO: Was possibly used in loading maps tiles but appears unused. Needs more investigation.
        /// </summary>
        public TileInfo[,] TempTile8ArraySP { get; set; } = new TileInfo[512, 512]; // all maps tiles8.

        /// <summary>
        ///     Gets or sets an array of all ExitOW.
        /// </summary>
        public ExitOW[] AllExits { get; set; } = new ExitOW[0x4F];

        /// <summary>
        ///     Gets or sets an array of all Tile8 collision types.
        /// </summary>
        public byte[] AllTileTypes { get; set; } = new byte[0x200];

        /// <summary>
        ///     Gets or sets a 2D array of all light world area tile maps.
        ///     64 maps * (32*32 tiles).
        /// </summary>
        public ushort[,] AllMapTile32LW { get; set; } = new ushort[512, 512];

        /// <summary>
        ///     Gets or sets a 2D array of all light world area tile maps.
        ///     64 maps * (32*32 tiles).
        /// </summary>
        public ushort[,] AllMapTile32DW { get; set; } = new ushort[512, 512];

        /// <summary>
        ///     Gets or sets a 2D array of all light world area tile maps.
        ///     32 maps * (32*32 tiles).
        /// </summary>
        public ushort[,] AllMapTile32SP { get; set; } = new ushort[512, 512];

        /// <summary>
        ///     Gets or sets a list of all overworld maps.
        /// </summary>
        public OverworldMap[] AllMaps { get; set; } = new OverworldMap[Constants.NumberOfOWMaps];

        /// <summary>
        ///     Gets or sets an array of all overworld entrances.
        /// </summary>
        public EntranceOW[] AllEntrances { get; set; } = new EntranceOW[129];

        /// <summary>
        ///     Gets or sets an array of all overoworld holes.
        /// </summary>
        public EntranceOW[] AllHoles { get; set; } = new EntranceOW[0x13];

        /// <summary>
        ///     Gets or sets a list of all overoworld items.
        /// </summary>
        public List<RoomPotSaveEditor> AllItems { get; set; } = new List<RoomPotSaveEditor>();

        /// <summary>
        ///     Gets or sets an array of all overlays.
        /// </summary>
        public OverlayData[] AllOverlays { get; set; } = new OverlayData[128];

        /// <summary>
        ///     Gets or sets a list of 3 separate lists of sprites, one for each phase of the game.
        /// </summary>
        public List<Sprite>[] AllSprites { get; set; } = new List<Sprite>[3] { new List<Sprite>(), new List<Sprite>(), new List<Sprite>() };

        /// <summary>
        ///     TODO: Investigate what this is because its everywhere.
        /// </summary>
        public int WorldOffset { get; set; } = 0;

        /// <summary>
        ///     Gets or sets a list of all whirlpools.
        ///     TODO: Fix Whirlpools on large maps.
        /// </summary>
        public List<TransportOW> AllWhirlpools { get; set; } = new List<TransportOW>();

        /// <summary>
        ///     Gets or sets a list of all bird locations.
        ///     TODO: Is referenced but currently unused as all the bird locations are stored in the same list as the whirlpools.
        /// </summary>
        public List<TransportOW> AllBirds { get; set; } = new List<TransportOW>();

        /// <summary>
        ///     Gets or sets the current game state or phase (rain, before agah, after agah).
        /// </summary>
        public byte GameState { get; set; } = 1;

        /// <summary>
        ///     Gets or sets a value indicating whether the overworld loading has finished.
        /// </summary>
        public bool IsLoaded { get; set; } = false;

        /// <summary>
        ///     Gets or sets an array of all the left entrance tiles (the Tile16 that are considered doors).
        /// </summary>
        public ushort[] LeftTileEntrance { get; set; } = new ushort[0x2B];

        /// <summary>
        ///     Gets or sets an array of all the right entrance tiles (the Tile16 that are considered doors).
        /// </summary>
        public ushort[] RightTileEntrance { get; set; } = new ushort[0x2B];

        /// <summary>
        ///     Gets or sets an array of all graves.
        /// </summary>
        public Gravestone[] AllGraves { get; set; } = new Gravestone[0x0F];

        /// <summary>
        ///     Initializes a new instance of the <see cref="Overworld"/> class.
        /// </summary>

        public OverlayAnimationData[] AllAnimationOverlays { get; set; } = new OverlayAnimationData[128];

        public Overworld()
        {
            for (int i = 0; i < 0x2B; i++)
            {
                this.LeftTileEntrance[i] = ROM.ReadShort(Constants.overworldEntranceAllowedTilesLeft + (i * 2));
                this.RightTileEntrance[i] = ROM.ReadShort(Constants.overworldEntranceAllowedTilesRight + (i * 2));

                /* Console.WriteLine(tileLeftEntrance[i].ToString("D4") + " , " + tileRightEntrance[i].ToString("D4")); */
            }

            this.UniqueTile32List = this.AssembleMap32Tiles();
            this.Tile16List = this.AssembleMap16Tiles();
            (ushort[,] tilesLW, ushort[,] tilesDW, ushort[,] tilesSP) = this.DecompressAllMapTiles();
            this.AllMapTile32LW = tilesLW;
            this.AllMapTile32DW = tilesDW;
            this.AllMapTile32SP = tilesSP;

            this.AllOverlays = this.LoadOverlays();
            this.AllAnimationOverlays = new OverlayAnimationData[128]; // one for each map
            for (int i = 0; i < 128; i++)
            {
                AllAnimationOverlays[i] = new OverlayAnimationData();
                for (int j = 0; j < 255; j++)
                {
                    AllAnimationOverlays[i].FramesList[j] = new List<TilePos>();
                }

            }
            this.AllTileTypes = this.LoadTileTypes();
            this.AllGraves = this.LoadGraves();

            // Map Initialization:
            for (int i = 0; i < Constants.NumberOfOWMaps; i++)
            {
                this.AllMaps[i] = new OverworldMap((byte)i, this);
            }

            this.AllMaps = this.AssignLargeMaps(this.AllMaps);

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
        ///     Writes all Tile16 to ROM.
        /// </summary>
        public void SaveMap16Tiles()
        {

            // Write all new pointers (all in snes address)

            ROM.WriteLong(Utils.SnesToPc(0x008865), Utils.PcToSnes(Constants.map16TilesEx));
            ROM.WriteLong(Utils.SnesToPc(0x0EDE4F), Utils.PcToSnes(Constants.map16TilesEx));
            ROM.WriteLong(Utils.SnesToPc(0x0EDEE9), Utils.PcToSnes(Constants.map16TilesEx));

            ROM.WriteLong(Utils.SnesToPc(0x1BBC2D), Utils.PcToSnes(Constants.map16TilesEx+2));
            ROM.WriteLong(Utils.SnesToPc(0x1BBC4C), Utils.PcToSnes(Constants.map16TilesEx));
            ROM.WriteLong(Utils.SnesToPc(0x1BBCC2), Utils.PcToSnes(Constants.map16TilesEx+4));
            ROM.WriteLong(Utils.SnesToPc(0x1BBCCB), Utils.PcToSnes(Constants.map16TilesEx+6));

            ROM.WriteLong(Utils.SnesToPc(0x1BBEF6), Utils.PcToSnes(Constants.map16TilesEx));
            ROM.WriteLong(Utils.SnesToPc(0x1BBF23), Utils.PcToSnes(Constants.map16TilesEx));
            ROM.WriteLong(Utils.SnesToPc(0x1BC041), Utils.PcToSnes(Constants.map16TilesEx));
            ROM.WriteLong(Utils.SnesToPc(0x1BC9B3), Utils.PcToSnes(Constants.map16TilesEx));

            ROM.WriteLong(Utils.SnesToPc(0x1BC9BA), Utils.PcToSnes(Constants.map16TilesEx+2));
            ROM.WriteLong(Utils.SnesToPc(0x1BC9C1), Utils.PcToSnes(Constants.map16TilesEx+4));
            ROM.WriteLong(Utils.SnesToPc(0x1BC9C8), Utils.PcToSnes(Constants.map16TilesEx+6));

            ROM.WriteLong(Utils.SnesToPc(0x1BCA40), Utils.PcToSnes(Constants.map16TilesEx));
            ROM.WriteLong(Utils.SnesToPc(0x1BCA47), Utils.PcToSnes(Constants.map16TilesEx +2));
            ROM.WriteLong(Utils.SnesToPc(0x1BCA4E), Utils.PcToSnes(Constants.map16TilesEx+4));
            ROM.WriteLong(Utils.SnesToPc(0x1BCA55), Utils.PcToSnes(Constants.map16TilesEx+6));

            ROM.WriteLong(Utils.SnesToPc(0x02F457), Utils.PcToSnes(Constants.map16TilesEx));
            ROM.WriteLong(Utils.SnesToPc(0x02F45E), Utils.PcToSnes(Constants.map16TilesEx+2));
            ROM.WriteLong(Utils.SnesToPc(0x02F467), Utils.PcToSnes(Constants.map16TilesEx+4));
            ROM.WriteLong(Utils.SnesToPc(0x02F46E), Utils.PcToSnes(Constants.map16TilesEx+6));
            ROM.WriteLong(Utils.SnesToPc(0x02F51F), Utils.PcToSnes(Constants.map16TilesEx));
            ROM.WriteLong(Utils.SnesToPc(0x02F526), Utils.PcToSnes(Constants.map16TilesEx+4));
            ROM.WriteLong(Utils.SnesToPc(0x02F52F), Utils.PcToSnes(Constants.map16TilesEx+2));
            ROM.WriteLong(Utils.SnesToPc(0x02F536), Utils.PcToSnes(Constants.map16TilesEx+6));
            ROM.WriteLong(Utils.SnesToPc(0x02FE1C), Utils.PcToSnes(Constants.map16TilesEx));
            ROM.WriteLong(Utils.SnesToPc(0x02FE23), Utils.PcToSnes(Constants.map16TilesEx+4));
            ROM.WriteLong(Utils.SnesToPc(0x02FE2C), Utils.PcToSnes(Constants.map16TilesEx+2));
            ROM.WriteLong(Utils.SnesToPc(0x02FE33), Utils.PcToSnes(Constants.map16TilesEx+6));



            ROM.Write(Utils.SnesToPc(0x02FD28), (byte)(Utils.PcToSnes(Constants.map16TilesEx)>>16));
            ROM.Write(Utils.SnesToPc(0x02FD39), (byte)(Utils.PcToSnes(Constants.map16TilesEx)>>16));



            int tpos = Constants.map16TilesEx;
            for (int i = 0; i < Constants.NumberOfMap16Ex; i += 1) // 4096
            {
                ROM.WriteShort(tpos, this.Tile16List[i].Tile0.toShort(), WriteType.Tile16);
                tpos += 2;
                ROM.WriteShort(tpos, this.Tile16List[i].Tile1.toShort(), WriteType.Tile16);
                tpos += 2;
                ROM.WriteShort(tpos, this.Tile16List[i].Tile2.toShort(), WriteType.Tile16);
                tpos += 2;
                ROM.WriteShort(tpos, this.Tile16List[i].Tile3.toShort(), WriteType.Tile16);
                tpos += 2;
            }
        }

        /// <summary>
        ///     Loads all maps from ROM to see if they are a large area or not.
        /// </summary>
        /// <param name="givenMaps"> The maps to update. </param>
        /// <returns> An array of overworld areas. </returns>
        public OverworldMap[] AssignLargeMaps(OverworldMap[] givenMaps)
        {
            OverworldMap[] allMaps = givenMaps;

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
                    if (allMaps[i].LargeMap)
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

        /// <summary>
        ///     This function takes all the current Tile16 maps and calculates the amount of unique Tile32.
        ///     It also adds all Tile32 in to one whole big list of all maps not seperated by areas so that can be written to ROM on save later.
        /// </summary>
        /// <param name="onlyShow"> If True, calculate the unique number of tiles and send a message box with the result. </param>
        /// <returns> True if there were too many unique Tile32. </returns>
        public bool CreateTile32Tilemap(bool onlyShow = false)
        {
            this.UniqueTile32List.Clear();
            this.Tile32List.Clear();

            // Create tile32 from tiles16.
            List<ulong> allTile16 = new List<ulong>();

            int sx = 0;
            int sy = 0;
            int c = 0;
            for (int i = 0; i < Constants.NumberOfOWMaps; i++)
            {
                ushort[,] tilesused;
                if (i < 64)
                {
                    tilesused = this.AllMapTile32LW;
                }
                else if (i < 128 && i >= 64)
                {
                    tilesused = this.AllMapTile32DW;
                }
                else
                {
                    tilesused = this.AllMapTile32SP;
                }

                for (int y = 0; y < 32; y += 2)
                {
                    for (int x = 0; x < 32; x += 2)
                    {
                        allTile16.Add(
                            new Tile32(
                                tilesused[x + (sx * 32), y + (sy * 32)],
                                tilesused[x + 1 + (sx * 32), y + (sy * 32)],
                                tilesused[x + (sx * 32), y + 1 + (sy * 32)],
                                tilesused[x + 1 + (sx * 32), y + 1 + (sy * 32)]).GetLongValue());
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

            // This gets rid of duplicate tiles using linq.
            // alltiles16 = all tiles32...
            // tiles = all tiles32 that are uniques double are removed.
            List<ulong> uniqueTiles = allTile16.Distinct().ToList();

            Dictionary<ulong, ushort> alltilesIndexed = new Dictionary<ulong, ushort>();

            for (int i = 0; i < uniqueTiles.Count; i++)
            {
                // Index the uniques tiles with a dictionary
                alltilesIndexed.Add(uniqueTiles[i], (ushort)i);
            }

            for (int i = 0; i < Constants.NumberOfMap32; i++)
            {
                // Add all tiles32 from all maps.
                // Convert all tiles32 non-unique IDs into unique array of IDs.
                this.Tile32List.Add(alltilesIndexed[allTile16[i]]);
            }

            // For each uniques tile32.
            for (int i = 0; i < uniqueTiles.Count; i++)
            {
                // Create new tileunique.
                this.UniqueTile32List.Add(new Tile32(uniqueTiles[i]));
            }

            // Prevents a bug if tilecount is not a multiple of 4.
            while (this.UniqueTile32List.Count % 4 != 0)
            {
                this.UniqueTile32List.Add(new Tile32(0));
            }

            allTile16.Clear();

            int limit = Constants.LimitOfMap32;
            if (ROM.DATA[0x1772E] != 4)
            {
                limit = Constants.LimitOfMap32*2;
            }


            if (onlyShow)
            {
                MessageBox.Show($"Unique Tiles32 count: {uniqueTiles.Count} | Max: {limit}");
            }
            else if (this.UniqueTile32List.Count > limit)
            {
                UIText.CryAboutSaving(
                    $"There are too many unique Tile32 definitions.\r\n" +
                    $"(Found: {uniqueTiles.Count} | Max: {limit}\r\n" +
                    $"To reduce this count, decrease the complexity of your overworld\r\n" +
                    $"by filling more of the map with common tiles such as grass\r\n" +
                    $"or empty the Dark World with the \"Clear DW Tiles\" option\r\n" +
                    $"in the Overworld menu."
                   );
                return true;
            }

            Console.WriteLine($"Unique Tiles32 count: {uniqueTiles.Count} | Saved: {UniqueTile32List.Count} | Max: {limit}");

            // Fill any extra space with some blank tiles.
            int v = this.UniqueTile32List.Count;
            for (int i = v; i < limit; i++)
            {
                // Create new tileunique.
                this.UniqueTile32List.Add(new Tile32(420, 420, 420, 420));
            }

            return false;
        }

        /// <summary>
        ///     Saves all the unique Tile32 to ROM.
        /// </summary>
        public void Save32Tiles()
        {
            /*int bottomLeft = Constants.map32TilesBL;
            int bottomRight = Constants.map32TilesBR;
            int topRight = Constants.map32TilesTR;
            int limit = 0x4540;
            if (ROM.DATA[0x1772E] != 4)
            {*/
            // always save expanded
                int bottomLeft = Constants.map32TilesBLEx;
                int bottomRight = Constants.map32TilesBREx;
                int topRight = Constants.map32TilesTREx;
                int limit = 0x8A80;
            //}

            // Updates the pointers too for the tile32
            //Top Right
            ROM.WriteLong(0x0176EC, Utils.PcToSnes(Constants.map32TilesTREx));
            ROM.WriteLong(0x0176F3, Utils.PcToSnes(Constants.map32TilesTREx+1));
            ROM.WriteLong(0x0176FA, Utils.PcToSnes(Constants.map32TilesTREx+2));
            ROM.WriteLong(0x017701, Utils.PcToSnes(Constants.map32TilesTREx+3));
            ROM.WriteLong(0x017708, Utils.PcToSnes(Constants.map32TilesTREx+4));
            ROM.WriteLong(0x01771A, Utils.PcToSnes(Constants.map32TilesTREx+5));

            //BottomLeft
            ROM.WriteLong(0x01772C, Utils.PcToSnes(Constants.map32TilesBLEx));
            ROM.WriteLong(0x017733, Utils.PcToSnes(Constants.map32TilesBLEx + 1));
            ROM.WriteLong(0x01773A, Utils.PcToSnes(Constants.map32TilesBLEx + 2));
            ROM.WriteLong(0x017741, Utils.PcToSnes(Constants.map32TilesBLEx + 3));
            ROM.WriteLong(0x017748, Utils.PcToSnes(Constants.map32TilesBLEx + 4));
            ROM.WriteLong(0x01775A, Utils.PcToSnes(Constants.map32TilesBLEx + 5));

            //BottomRight
            ROM.WriteLong(0x01776C, Utils.PcToSnes(Constants.map32TilesBREx));
            ROM.WriteLong(0x017773, Utils.PcToSnes(Constants.map32TilesBREx + 1));
            ROM.WriteLong(0x01777A, Utils.PcToSnes(Constants.map32TilesBREx + 2));
            ROM.WriteLong(0x017781, Utils.PcToSnes(Constants.map32TilesBREx + 3));
            ROM.WriteLong(0x017788, Utils.PcToSnes(Constants.map32TilesBREx + 4));
            ROM.WriteLong(0x01779A, Utils.PcToSnes(Constants.map32TilesBREx + 5));


            int index = 0;
            int c = this.UniqueTile32List.Count;
            for (int i = 0; i < c; i += 6)
            {
                if (index >= limit) // 3C87??
                {
                    Console.WriteLine("Too many unique tiles!");
                    break;
                }

                // Top Left.
                ROM.Write(Constants.map32TilesTL + i, (byte)(this.UniqueTile32List[index].Tile0 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTL + (i + 1), (byte)(this.UniqueTile32List[index + 1].Tile0 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTL + (i + 2), (byte)(this.UniqueTile32List[index + 2].Tile0 & 0xFF), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTL + (i + 3), (byte)(this.UniqueTile32List[index + 3].Tile0 & 0xFF), WriteType.Tile32);

                ROM.Write(Constants.map32TilesTL + (i + 4), (byte)(((this.UniqueTile32List[index].Tile0 >> 4) & 0xF0) + ((this.UniqueTile32List[index + 1].Tile0 >> 8) & 0x0F)), WriteType.Tile32);
                ROM.Write(Constants.map32TilesTL + (i + 5), (byte)(((this.UniqueTile32List[index + 2].Tile0 >> 4) & 0xF0) + ((this.UniqueTile32List[index + 3].Tile0 >> 8) & 0x0F)), WriteType.Tile32);

                // Top Right.
                ROM.Write(topRight + i, (byte)(this.UniqueTile32List[index].Tile1 & 0xFF), WriteType.Tile32);
                ROM.Write(topRight + (i + 1), (byte)(this.UniqueTile32List[index + 1].Tile1 & 0xFF), WriteType.Tile32);
                ROM.Write(topRight + (i + 2), (byte)(this.UniqueTile32List[index + 2].Tile1 & 0xFF), WriteType.Tile32);
                ROM.Write(topRight + (i + 3), (byte)(this.UniqueTile32List[index + 3].Tile1 & 0xFF), WriteType.Tile32);

                ROM.Write(topRight + (i + 4), (byte)(((this.UniqueTile32List[index].Tile1 >> 4) & 0xF0) | ((this.UniqueTile32List[index + 1].Tile1 >> 8) & 0x0F)), WriteType.Tile32);
                ROM.Write(topRight + (i + 5), (byte)(((this.UniqueTile32List[index + 2].Tile1 >> 4) & 0xF0) | ((this.UniqueTile32List[index + 3].Tile1 >> 8) & 0x0F)), WriteType.Tile32);



                // Bottom Left.
                ROM.Write(bottomLeft + i, (byte)(this.UniqueTile32List[index].Tile2 & 0xFF), WriteType.Tile32);
                ROM.Write(bottomLeft + (i + 1), (byte)(this.UniqueTile32List[index + 1].Tile2 & 0xFF), WriteType.Tile32);
                ROM.Write(bottomLeft + (i + 2), (byte)(this.UniqueTile32List[index + 2].Tile2 & 0xFF), WriteType.Tile32);
                ROM.Write(bottomLeft + (i + 3), (byte)(this.UniqueTile32List[index + 3].Tile2 & 0xFF), WriteType.Tile32);

                ROM.Write(bottomLeft + (i + 4), (byte)(((this.UniqueTile32List[index].Tile2 >> 4) & 0xF0) | ((this.UniqueTile32List[index + 1].Tile2 >> 8) & 0x0F)), WriteType.Tile32);
                ROM.Write(bottomLeft + (i + 5), (byte)(((this.UniqueTile32List[index + 2].Tile2 >> 4) & 0xF0) | ((this.UniqueTile32List[index + 3].Tile2 >> 8) & 0x0F)), WriteType.Tile32);

                // Bottom Right.
                ROM.Write(bottomRight + i, (byte)(this.UniqueTile32List[index].Tile3 & 0xFF), WriteType.Tile32);
                ROM.Write(bottomRight + (i + 1), (byte)(this.UniqueTile32List[index + 1].Tile3 & 0xFF), WriteType.Tile32);
                ROM.Write(bottomRight + (i + 2), (byte)(this.UniqueTile32List[index + 2].Tile3 & 0xFF), WriteType.Tile32);
                ROM.Write(bottomRight + (i + 3), (byte)(this.UniqueTile32List[index + 3].Tile3 & 0xFF), WriteType.Tile32);

                ROM.Write(bottomRight + (i + 4), (byte)(((this.UniqueTile32List[index].Tile3 >> 4) & 0xF0) | ((this.UniqueTile32List[index + 1].Tile3 >> 8) & 0x0F)), WriteType.Tile32);
                ROM.Write(bottomRight + (i + 5), (byte)(((this.UniqueTile32List[index + 2].Tile3 >> 4) & 0xF0) | ((this.UniqueTile32List[index + 3].Tile3 >> 8) & 0x0F)), WriteType.Tile32);




                index += 4;
                c += 2;
            }
        }

        /// <summary>
        ///     Load all tile types from the ROM and return them as an array.
        /// </summary>
        /// <returns> An array of bytes. </returns>
        private byte[] LoadTileTypes()
        {
            var tileTypes = new List<byte>();
            for (int i = 0; i < this.AllTileTypes.Length; i++)
            {
                tileTypes.Add(ROM.DATA[Constants.overworldTilesType + i]);
            }

            return tileTypes.ToArray();
        }

        /// <summary>
        ///     Load all of the graves and return them in an array.
        /// </summary>
        /// <returns> An array of graves. </returns>
        private Gravestone[] LoadGraves()
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

        /// <summary>
        ///     Loads all Tile16 from the ROM.
        /// </summary>
        /// <returns> A list of Tile16. </returns>
        private List<Tile16> AssembleMap16Tiles()
        {
            var tile16List = new List<Tile16>();
            int tpos = Constants.map16Tiles;

            if (ROM.DATA[Utils.SnesToPc(0x02FD28)] == 0x0F)
            {

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
                TileInfo tempty = new TileInfo(0xAA, 2, false,false, false);
                // fill the rest with empty tiles
                while (tile16List.Count < 4096)
                {
                    tile16List.Add(new Tile16(tempty, tempty, tempty, tempty));
                }

            }
            else
            {
                tpos = Constants.map16TilesEx;
                for (int i = 0; i < Constants.NumberOfMap16Ex; i += 1)
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
            }




            return tile16List;
        }

        /// <summary>
        ///     Loads all Tile32 from the ROM.
        /// </summary>
        /// <returns> A list of Tile32. </returns>
        private List<Tile32> AssembleMap32Tiles()
        {
            var tile32List = new List<Tile32>();

            // Constants.Map32TilesCount is divided by 6 bytes, multiplied by 4 because chunks of 4 tiles

            // Is the data expanded?
            // 04 by default that's the bank of BL tiles
            if (ROM.DATA[0x01772E] == 4)
            {
                for (int i = 0; i < Constants.Map32TilesCount; i += 6)
                {
                    ushort tl, tr, bl, br;

                    for (int k = 0; k < 4; k++)
                    {
                        tl = this.ReadTile32(i, k, Constants.map32TilesTL);
                        tr = this.ReadTile32(i, k, Constants.map32TilesTR);
                        bl = this.ReadTile32(i, k, Constants.map32TilesBL);
                        br = this.ReadTile32(i, k, Constants.map32TilesBR);
                        tile32List.Add(new Tile32(tl, tr, bl, br));
                    }

                }
            }
            else
            {
                for (int i = 0; i < Constants.Map32TilesCountEx; i += 6)
                {
                    ushort tl, tr, bl, br;

                    for (int k = 0; k < 4; k++)
                    {
                        tl = this.ReadTile32(i, k, Constants.map32TilesTL);
                        tr = this.ReadTile32(i, k, Constants.map32TilesTREx);
                        bl = this.ReadTile32(i, k, Constants.map32TilesBLEx);
                        br = this.ReadTile32(i, k, Constants.map32TilesBREx);
                        tile32List.Add(new Tile32(tl, tr, bl, br));
                    }

                }
            }

            return tile32List;
        }

        /// <summary>
        ///     Reads Tile32 data from the given address and given indexes.
        /// </summary>
        /// <param name="i"> TODO: Figure out exactly what i is and document it. </param>
        /// <param name="k"> TODO: Figure out exactly what k is and document it. </param>
        /// <param name="address"> Address of the tile corner. </param>
        /// <returns> A ushort containing one corner of a Tile32. </returns>
        private ushort ReadTile32(int i, int k, int address)
        {
            // TODO: Document all this math -_-.
            return (ushort)(ROM.DATA[address + k + i] + (((ROM.DATA[address + i + (k <= 1 ? 4 : 5)] >> (k % 2 == 0 ? 4 : 0)) & 0x0F) * 256));
        }

        /// <summary>
        ///     Decompresses the area maps and stores them in 2D arrays of ushorts.
        /// </summary>
        /// <returns> A tuple with 3 2D arrays of ushorts. </returns>
        private (ushort[,], ushort[,], ushort[,]) DecompressAllMapTiles()
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

                /*
                 if (p1 > furthestPtr)
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
				 }
                */

                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        ushort tidD = (ushort)((bytes2[ttpos] << 8) + bytes[ttpos]);

                        int tpos = tidD;
                        if (tpos < this.UniqueTile32List.Count)
                        {
                            /* map16tiles[npos] = new Tile32(tiles32[tpos].tile0, tiles32[tpos].tile1, tiles32[tpos].tile2, tiles32[tpos].tile3); */

                            if (i < 64)
                            {
                                allMapTile32_LW[(x * 2) + (sx * 32), (y * 2) + (sy * 32)] = this.UniqueTile32List[tpos].Tile0;
                                allMapTile32_LW[(x * 2) + 1 + (sx * 32), (y * 2) + (sy * 32)] = this.UniqueTile32List[tpos].Tile1;
                                allMapTile32_LW[(x * 2) + (sx * 32), (y * 2) + 1 + (sy * 32)] = this.UniqueTile32List[tpos].Tile2;
                                allMapTile32_LW[(x * 2) + 1 + (sx * 32), (y * 2) + 1 + (sy * 32)] = this.UniqueTile32List[tpos].Tile3;
                            }
                            else if (i < 128 && i >= 64)
                            {
                                allMapTile32_DW[(x * 2) + (sx * 32), (y * 2) + (sy * 32)] = this.UniqueTile32List[tpos].Tile0;
                                allMapTile32_DW[(x * 2) + 1 + (sx * 32), (y * 2) + (sy * 32)] = this.UniqueTile32List[tpos].Tile1;
                                allMapTile32_DW[(x * 2) + (sx * 32), (y * 2) + 1 + (sy * 32)] = this.UniqueTile32List[tpos].Tile2;
                                allMapTile32_DW[(x * 2) + 1 + (sx * 32), (y * 2) + 1 + (sy * 32)] = this.UniqueTile32List[tpos].Tile3;
                            }
                            else
                            {
                                allMapTile32_SP[(x * 2) + (sx * 32), (y * 2) + (sy * 32)] = this.UniqueTile32List[tpos].Tile0;
                                allMapTile32_SP[(x * 2) + 1 + (sx * 32), (y * 2) + (sy * 32)] = this.UniqueTile32List[tpos].Tile1;
                                allMapTile32_SP[(x * 2) + (sx * 32), (y * 2) + 1 + (sy * 32)] = this.UniqueTile32List[tpos].Tile2;
                                allMapTile32_SP[(x * 2) + 1 + (sx * 32), (y * 2) + 1 + (sy * 32)] = this.UniqueTile32List[tpos].Tile3;
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

            Console.WriteLine($"Map pointers (lowest): {lowest:X6}");
            Console.WriteLine($"Map pointers (highest): {highest:X6}");

            return (allMapTile32_LW, allMapTile32_DW, allMapTile32_SP);
        }

        /// <summary>
        ///     Loads all overworld exits from ROM.
        /// </summary>
        /// <returns> An array of ExitOW. </returns>
        private ExitOW[] LoadExits()
        {
            var exits = new List<ExitOW>();
            for (int i = 0; i < this.AllExits.Count(); i++)
            {
                ushort exitRoomID = (ushort)((ROM.DATA[Constants.OWExitRoomId + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitRoomId + (i * 2)]);
                byte exitMapID = ROM.DATA[Constants.OWExitMapId + i];
                ushort exitVRAM = (ushort)((ROM.DATA[Constants.OWExitVram + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitVram + (i * 2)]);
                ushort exitYScroll = (ushort)((ROM.DATA[Constants.OWExitYScroll + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitYScroll + (i * 2)]);
                ushort exitXScroll = (ushort)((ROM.DATA[Constants.OWExitXScroll + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitXScroll + (i * 2)]);
                ushort py = (ushort)((ROM.DATA[Constants.OWExitYPlayer + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitYPlayer + (i * 2)]);
                ushort px = (ushort)((ROM.DATA[Constants.OWExitXPlayer + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitXPlayer + (i * 2)]);
                ushort exitYCamera = (ushort)((ROM.DATA[Constants.OWExitYCamera + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitYCamera + (i * 2)]);
                ushort exitXCamera = (ushort)((ROM.DATA[Constants.OWExitXCamera + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitXCamera + (i * 2)]);
                byte exitScrollModY = ROM.DATA[Constants.OWExitUnk1 + i];
                byte exitScrollModX = ROM.DATA[Constants.OWExitUnk2 + i];
                ushort exitDoorType1 = (ushort)((ROM.DATA[Constants.OWExitDoorType1 + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitDoorType1 + (i * 2)]);
                ushort exitDoorType2 = (ushort)((ROM.DATA[Constants.OWExitDoorType2 + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitDoorType2 + (i * 2)]);
                ExitOW exit = new ExitOW(exitRoomID, exitMapID, exitVRAM, exitYScroll, exitXScroll, py, px, exitYCamera, exitXCamera, exitScrollModY, exitScrollModX, exitDoorType1, exitDoorType2);

                if (px == 0xFFFF && py == 0xFFFF)
                {
                    exit.Deleted = true;
                }

                exits.Add(exit);
            }

            return exits.ToArray();
        }

        /// <summary>
        ///     Loads all whirlpools form ROM.
        ///     Is what it's supposed to do but actually loads all transport locations (Whirlpools, birds, and the other event ones).
        /// </summary>
        /// <returns> A list of TransportOW. </returns>
        private List<TransportOW> LoadWhirlpools()
        {
            var allWhirlpools = new List<TransportOW>();
            for (int i = 0; i < Constants.OWWhirlpoolCount; i++)
            {
                byte whirlpoolMapID = (byte)((ROM.DATA[Constants.OWExitMapIdWhirlpool + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitMapIdWhirlpool + (i * 2)]);
                ushort whirlpoolVRAM = (ushort)((ROM.DATA[Constants.OWExitVramWhirlpool + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitVramWhirlpool + (i * 2)]);
                ushort whirlpoolYScroll = (ushort)((ROM.DATA[Constants.OWExitYScrollWhirlpool + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitYScrollWhirlpool + (i * 2)]);
                ushort whirlpoolXScroll = (ushort)((ROM.DATA[Constants.OWExitXScrollWhirlpool + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitXScrollWhirlpool + (i * 2)]);
                ushort whirlpoolYPlayer = (ushort)((ROM.DATA[Constants.OWExitYPlayerWhirlpool + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitYPlayerWhirlpool + (i * 2)]);
                ushort whirlpoolXPlayer = (ushort)((ROM.DATA[Constants.OWExitXPlayerWhirlpool + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitXPlayerWhirlpool + (i * 2)]);
                ushort whirlpoolYCamera = (ushort)((ROM.DATA[Constants.OWExitYCameraWhirlpool + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitYCameraWhirlpool + (i * 2)]);
                ushort whirlpoolXCamera = (ushort)((ROM.DATA[Constants.OWExitXCameraWhirlpool + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWExitXCameraWhirlpool + (i * 2)]);
                byte whirlpoolScrollModY = ROM.DATA[Constants.OWExitScrollModYWhirlpool + i];
                byte whirlpoolScrollModX = ROM.DATA[Constants.OWExitScrollModXWhirlpool + i];
                ushort whirlpoolPosition = (ushort)((ROM.DATA[Constants.OWWhirlpoolPosition + (i * 2) + 1] << 8) + ROM.DATA[Constants.OWWhirlpoolPosition + (i * 2)]);

                if (i > 8)
                {
                    whirlpoolPosition = (ushort)((ROM.DATA[Constants.OWWhirlpoolPosition + ((i - 9) * 2) + 1] << 8) + ROM.DATA[Constants.OWWhirlpoolPosition + ((i - 9) * 2)]);
                }

                var transport = new TransportOW(whirlpoolMapID, whirlpoolVRAM, whirlpoolYScroll, whirlpoolXScroll, whirlpoolYPlayer, whirlpoolXPlayer, whirlpoolYCamera, whirlpoolXCamera, whirlpoolScrollModY, whirlpoolScrollModX, whirlpoolPosition);
                allWhirlpools.Add(transport);
            }

            return allWhirlpools;
        }

        /// <summary>
        ///     Loads all overworld entrances from ROM.
        /// </summary>
        /// <returns> An array of EntranceOW. </returns>
        private EntranceOW[] LoadEntrances()
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

        /// <summary>
        ///     Loads all overworld holes from ROM.
        /// </summary>
        /// <returns> An array of EntranceOW. </returns>
        private EntranceOW[] LoadHoles()
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

                if (eo.MapPos == 0xFFFF)
                {
                    eo.Deleted = true;
                }

                allHoles[i] = eo;
            }

            return allHoles;
        }

        /// <summary>
        ///     Loads all overworld items from ROM.
        /// </summary>
        /// <returns> A list of Items. </returns>
        private List<RoomPotSaveEditor> LoadItems()
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

                if (this.AllMaps[i].LargeMap)
                {
                    if (this.AllMaps[i].ParentID != (byte)i)
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
                    allItems[allItems.Count - 1].GameX = (byte)x;
                    allItems[allItems.Count - 1].GameY = (byte)y;
                    addr += 3;
                }
            }

            return allItems;
        }

        /// <summary>
        ///     Loads all overlays from ROM.
        /// </summary>
        /// <returns> An array of OverlayData. </returns>
        private OverlayData[] LoadOverlays()
        {
            /*
                0x7765B: ;Original byte = 0x0A
                22 9C 87 00 EA ;JSL long jump table
            */

            var allOverlays = new OverlayData[this.AllOverlays.Length];

            for (int index = 0; index < this.AllOverlays.Length; index++)
            {
                allOverlays[index] = new OverlayData();

                // OverlayPointers.
                Console.WriteLine($"MapIndex Overlay: {index:X2}");

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

                        // Draw tile at sta,X position.
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

        /// <summary>
        ///     Loads all overworld sprites from ROM.
        /// </summary>
        /// <returns> A list of Sprites. </returns>
        private List<Sprite>[] LoadSprites()
        {
            // LW[0] = RainState 0 to 63 there's no data for DW.
            // LW[1] = ZeldaState 0 to 128 ; Contains LW and DW <128 or 144 wtf.
            // LW[2] = AgahState 0 to ?? ;Contains data for LW and DW.

            /*
               Console.WriteLine(((Constants.overworldSpritesBegining & 0xFFFF) + (09 << 16)).ToString("X6"));
            */

            var allSprites = new List<Sprite>[3] { new List<Sprite>(), new List<Sprite>(), new List<Sprite>() };
            for (int i = 0; i < 64; i++)
            {
                if (this.AllMaps[i].ParentID == i)
                {
                    // Beginning Sprites.
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
                if (this.AllMaps[i].ParentID == i)
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
                if (this.AllMaps[i].ParentID == i)
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

        #region Unused

        /// <summary>
        ///     Imports overworld maps from a give file.
        ///     TODO: Currently unused, needs more investigation.
        /// </summary>
        public void ImportMaps()
        {
            string path = string.Empty;
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
                    tilesused = this.AllMapTile32LW;
                }
                else if (i < 128 && i >= 64)
                {
                    tilesused = this.AllMapTile32DW;
                }
                else
                {
                    tilesused = this.AllMapTile32SP;
                }

                for (int y = 0; y < 32; y++)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        tilesused[x + (sx * 32), y + (sy * 32)] = bw.ReadUInt16();
                        /*
                        alltiles16.Add(
                            new Tile32(
                                tilesused[x + (sx * 32), y + (sy * 32)],
                                tilesused[x + 1 + (sx * 32), y + (sy * 32)],
                                tilesused[x + (sx * 32), y + 1 + (sy * 32)],
                                tilesused[x + 1 + (sx * 32), y + 1 + (sy * 32)]).getLongValue());
                        */
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
                this.AllMaps[i].BuildMap();
            }
        }

        /// <summary>
        ///     Exports overworld maps to a file.
        ///     TODO: Currently unused, needs more investigation.
        /// </summary>
        public void ExportMaps()
        {
            string path = string.Empty;
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
                // TODO: file name in UIText.
                BinaryWriter bw = new BinaryWriter(new FileStream(path + "\\map" + i.ToString(), FileMode.Create, FileAccess.Write));
                ushort[,] tilesused;
                if (i < 64)
                {
                    tilesused = this.AllMapTile32LW;
                }
                else if (i < 128 && i >= 64)
                {
                    tilesused = this.AllMapTile32DW;
                }
                else
                {
                    tilesused = this.AllMapTile32SP;
                }

                for (int y = 0; y < 32; y++)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        bw.Write(tilesused[x + (sx * 32), y + (sy * 32)]);
                        /*
                        alltiles16.Add(
                            new Tile32(
                                tilesused[x + (sx * 32), y + (sy * 32)],
                                tilesused[x + 1 + (sx * 32), y + (sy * 32)],
                                tilesused[x + (sx * 32), y + 1 + (sy * 32)],
                                tilesused[x + 1 + (sx * 32), y + 1 + (sy * 32)]).getLongValue());
                        */
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

        /// <summary>
        ///     Takes map data and exports it as a string?
        ///     TODO: Currently unused, needs more invatigation into its actual use.
        /// </summary>
        /// <param name="mapID"> The map ID. </param>
        /// <param name="tiles"> The Tile16. </param>
        /// <param name="large"> Whether the area is large or not? Currently unused. </param>
        public void AllMapTilesFromMap(int mapID, ushort[,] tiles, bool large = false)
        {
            string s = string.Empty;
            int tpos = mapID * 256;
            for (int y = 0; y < 16; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    this.Map16Tiles[tpos] = new Tile32(tiles[x * 2, y * 2], tiles[(x * 2) + 1, y * 2], tiles[x * 2, (y * 2) + 1], tiles[(x * 2) + 1, (y * 2) + 1]);
                    /* s += "[" + map16tiles[tpos].tile0.ToString("D4") + "," + map16tiles[tpos].tile1.ToString("D4") + "," + map16tiles[tpos].tile2.ToString("D4") + "," + map16tiles[tpos].tile3.ToString("D4") + "] "; */
                    tpos++;
                }

                s += "\r\n";
            }

            /* File.WriteAllText("TileDebug.txt", s); */
        }

        /// <summary>
        ///     Creates a list of tile32 given a list of Tile16.
        ///     TODO: Currently unused. Possible old code, needs more investigation.
        /// </summary>
        public void CreateMap32TilesFrom16()
        {
            this.Tile32List.Clear();
            int tile32Count = 0;

            const int nullVal = -1;
            for (int i = 0; i < Constants.NumberOfMap32; i++)
            {
                short foundIndex = nullVal;
                for (int j = 0; j < tile32Count; j++)
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
                    this.UniqueTile32List[tile32Count] = new Tile32(this.Map16Tiles[i].Tile0, this.Map16Tiles[i].Tile1, this.Map16Tiles[i].Tile2, this.Map16Tiles[i].Tile3);
                    this.Tile32List.Add((ushort)tile32Count);
                    tile32Count++;
                }
                else
                {
                    this.Tile32List.Add((ushort)foundIndex);
                }
            }

            Console.WriteLine("Nbr of tiles32 = " + tile32Count);
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

        /// <summary>
        ///     Creates a list of Tile16 with the given TileInfo list.
        ///     TODO: Currently unused, looks to be very similar to the CreateTile32Tilemap() function above which is used. Possibly old code, needs more investigation.
        /// </summary>
        /// <returns> True if we loaded too many tiles. </returns>
        public bool CreateTile16Tilemap()
        {
            List<Tile16> uniqueTile16List = new List<Tile16>();
            List<ushort> t16 = new List<ushort>();

            // Create tile32 from tiles16.
            List<ulong> alltiles8 = new List<ulong>();

            int sx = 0;
            int sy = 0;
            int c = 0;
            for (int i = 0; i < Constants.NumberOfOWMaps; i++)
            {
                TileInfo[,] tilesused;
                if (i < 64)
                {
                    tilesused = this.TempTile8ArrayLW;
                }
                else if (i < 128 && i >= 64)
                {
                    tilesused = this.TempTile8ArrayDW;
                }
                else
                {
                    tilesused = this.TempTile8ArraySP;
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

            // That get rid of duplicated tiles using linq. alltiles16 = all tiles32... Tiles = all tiles32 that are uniques double are removed.
            List<ulong> tiles = alltiles8.Distinct().ToList();

            Dictionary<ulong, ushort> alltilesIndexed = new Dictionary<ulong, ushort>();

            for (int i = 0; i < tiles.Count; i++)
            {
                // Index the uniques tiles with a dictionary.
                alltilesIndexed.Add(tiles[i], (ushort)i);
            }

            for (int i = 0; i < Constants.NumberOfOWMaps * 32 * 32; i++) // 163840 = numbers of 16x16 tiles (160 * (32*32))
            {
                // Add all tiles32 from all maps. Convert all tiles32 non-unique ids into unique array of ids.
                t16.Add(alltilesIndexed[alltiles8[i]]);
            }

            // For each uniques tile32.
            for (int i = 0; i < tiles.Count; i++)
            {
                // Create new tileunique.
                uniqueTile16List.Add(new Tile16(tiles[i]));
            }

            // This prevents a bug if tilecount is not a multiple of 4.
            while (uniqueTile16List.Count % 4 != 0)
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

            this.Tile16List.Clear();
            for (int i = 0; i < uniqueTile16List.Count; i++)
            {
                ulong t = uniqueTile16List[i].GetLongData();
                this.Tile16List.Add(new Tile16(t));
            }

            alltiles8.Clear();

            Console.WriteLine("Nbr of uniquetiles16 = " + tiles.Count + " " + uniqueTile16List.Count);
            return false;
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

        #endregion
    }
}
