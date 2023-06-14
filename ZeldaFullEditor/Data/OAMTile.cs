namespace ZeldaFullEditor
{
    class OAMTile
    {
        /// <summary>
        ///     Gets or sets the X position of the tile.
        /// </summary>
        public byte X { get; set; }

        /// <summary>
        ///     Gets or sets the Y position of the tile.
        /// </summary>
        public byte Y { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the tile is horizontally flipped. 0 = not flipped, 1 = flipped.
        /// </summary>
        public byte MirrorX { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the tile is vertically flipped. 0 = not flipped, 1 = flipped.
        /// </summary>
        public byte MirrorY { get; set; }

        /// <summary>
        ///     Gets or sets the palette of the tile.
        /// </summary>
        public byte Palette { get; set; }

        /// <summary>
        ///     Gets or sets the actual tile (char) of the tile.
        /// </summary>
        public ushort Tile { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="OAMTile"/> class.
        /// </summary>
        /// <param name="x"> The X position. </param>
        /// <param name="y"> The Y position. </param>
        /// <param name="tile"> The tile. </param>
        /// <param name="pal"> The palette. </param>
        /// <param name="upper"> A value to indicate the extra c (char) bit for the tile. </param>
        /// <param name="mirrorX"> The X mirror setting. </param>
        /// <param name="mirrorY"> The Y mirror setting. </param>
        public OAMTile(byte x, byte y, ushort tile, byte pal, bool upper = false, byte mirrorX = 0, byte mirrorY = 0)
        {
            this.X = x;
            this.Y = y;

            if (upper)
            {
                this.Tile = (ushort)(tile + 512);
            }
            else
            {
                this.Tile = (ushort)(tile + 256 + 512);
            }

            this.Palette = pal;
            this.MirrorX = mirrorX;
            this.MirrorY = mirrorY;
        }
    }
}
