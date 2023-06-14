namespace ZeldaFullEditor.Data
{
    /// <summary>
    ///     A class containing all the info for each grave.
    /// </summary>
    public class Gravestone
    {
        /// <summary>
        ///     Gets or sets the unique ID for the grave.
        /// </summary>
        public int UniqueID { get; set; } = 0;

        /// <summary>
        ///     Gets or sets the Y tile position for the grave.
        /// </summary>
        public ushort YTilePos { get; set; }

        /// <summary>
        ///     Gets or sets the X tile position for the grave.
        /// </summary>
        public ushort XTilePos { get; set; }

        /// <summary>
        ///     Gets or sets the tilemap position for the grave.
        /// </summary>
        public ushort TilemapPos { get; set; }

        /// <summary>
        ///     Gets or sets the GFX index for the grave.
        /// </summary>
        public ushort GFX { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Gravestone"/> class.
        /// </summary>
        /// <param name="x"> The X position. </param>
        /// <param name="y"> The Y position. </param>
        /// <param name="tilemapPos"> The tilemap position. </param>
        /// <param name="gfx"> The GFX index. </param>
        public Gravestone(ushort x, ushort y, ushort tilemapPos, ushort gfx)
        {
            this.XTilePos = x;
            this.YTilePos = y;
            this.TilemapPos = tilemapPos;
            this.GFX = gfx;
            this.UniqueID = ROM.uniqueGraveID++;
        }
    }
}
