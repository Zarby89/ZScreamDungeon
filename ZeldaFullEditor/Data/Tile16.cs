namespace ZeldaFullEditor
{
    /// <summary>
    ///     A class to contain individual Tile16 data.
    /// </summary>
    public class Tile16
    {
        /// <summary>
        ///      Gets or sets the 1st 8x8 tile of the Tile16.
        /// </summary>
        public TileInfo Tile0 { get; set; }

        /// <summary>
        ///      Gets or sets the 2nd 8x8 tile of the Tile16.
        /// </summary>
        public TileInfo Tile1 { get; set; }

        /// <summary>
        ///      Gets or sets the 3rd 8x8 tile of the Tile16.
        /// </summary>
        public TileInfo Tile2 { get; set; }

        /// <summary>
        ///     Gets or sets the 4th 8x8 tile of the Tile16.
        /// </summary>
        public TileInfo Tile3 { get; set; }

        /// <summary>
        ///     Gets the 1st 8x8 tile of the Tile16.
        /// </summary>
        public TileInfo[] TileInfoArray => new[] { this.Tile0, this.Tile1, this.Tile2, this.Tile3 };

        /// <summary>
        ///     Initializes a new instance of the <see cref="Tile16"/> class.
        ///     [0,1]
        ///     [2,3].
        /// </summary>
        /// <param name="tile0"> The 1st tile. </param>
        /// <param name="tile1"> The 2nd tile. </param>
        /// <param name="tile2"> The 3rd tile. </param>
        /// <param name="tile3"> The 4th tile. </param>
        public Tile16(TileInfo tile0, TileInfo tile1, TileInfo tile2, TileInfo tile3)
        {
            this.Tile0 = tile0;
            this.Tile1 = tile1;
            this.Tile2 = tile2;
            this.Tile3 = tile3;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Tile16"/> class.
        /// </summary>
        /// <param name="tiles"> All 4 tiles together as a ulong. </param>
        public Tile16(ulong tiles)
        {
            this.Tile0 = GFX.gettilesinfo((ushort)tiles);
            this.Tile1 = GFX.gettilesinfo((ushort)(tiles >> 16));
            this.Tile2 = GFX.gettilesinfo((ushort)(tiles >> 32));
            this.Tile3 = GFX.gettilesinfo((ushort)(tiles >> 48));
        }

        /// <summary>
        ///     Returns the 4 sub tiles as a long.
        /// </summary>
        /// <returns> A long. </returns>
        public ulong GetLongData()
        {
            return ((ulong)this.Tile3.toShort()) << 48 | (((ulong)this.Tile2.toShort()) << 32) | (((ulong)this.Tile1.toShort()) << 16) | this.Tile0.toShort();
        }
    }
}
