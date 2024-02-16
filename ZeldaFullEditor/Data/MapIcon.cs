namespace ZeldaFullEditor.Data
{
	/// <summary>
	///     A data class containing all the info for map icons.
	/// </summary>
	public class MapIcon
	{
		/// <summary>
		///     Gets or sets the X postion for the map icon.
		/// </summary>
		public short X { get; set; } = 0;

		/// <summary>
		///     Gets or sets the Y position for the map icon.
		/// </summary>
		public short Y { get; set; } = 0;

		/// <summary>
		///     Gets or sets the GFX index for the map icon.
		/// </summary>
		public ushort GFX { get; set; } = 0;

		/// <summary>
		///     Initializes a new instance of the <see cref="MapIcon"/> class.
		/// </summary>
		/// <param name="x"> The X position. </param>
		/// <param name="y"> The Y position. </param>
		/// <param name="gfx"> The GFX index. </param>
		public MapIcon(short x, short y, ushort gfx)
		{
			this.X = x;
			this.Y = y;
			this.GFX = gfx;
		}
	}
}
