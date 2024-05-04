namespace ZeldaFullEditor
{
	/// <summary>
	/// Represents a set of instructions for how to draw a new tile to the background.
	/// </summary>
	public readonly struct DrawInfo
	{
		/// <summary>
		/// Index into the object's tile listing to use
		/// </summary>
		public int TileIndex { get; }

		/// <summary>
		/// X-axis offset of the tile relative to the object's coordinates
		/// </summary>
		public int XOff { get; }

		/// <summary>
		/// Y-axis offset of the tile relative to the object's coordinates
		/// </summary>
		public int YOff { get; }

		/// <summary>
		/// The data this tile is forbidden to overwrite.
		/// </summary>
		public ushort? TileUnder { get; }

		/// <summary>
		/// Forces the horizontal flip of the tile if not <see langword="null"/>
		/// </summary>
		public bool? HFlip { get; }

		/// <summary>
		/// Forces the vertical flip of the tile if not <see langword="null"/>
		/// </summary>
		public bool? VFlip { get; }

		/// <summary>
		/// Represents a set of instructions for how to draw a new tile to the background.
		/// </summary>
		/// <param name="i">The index into the object's tile listing to use</param>
		/// <param name="x">The X-axis offset of the tile relative to the object's coordinates</param>
		/// <param name="y">The Y-axis offset of the tile relative to the object's coordinates</param>
		/// <param name="hflip">Forces the horizontal flip of the tile; set to <see langword="null"/> to leave it unchanged.</param>
		/// <param name="vflip">Forces the vertical flip of the tile; set to <see langword="null"/> to leave it unchanged.</param>
		/// <param name="under">The data this tile is forbidden to overwrite.</param>
		public DrawInfo(int i, int x, int y, bool? hflip = null, bool? vflip = null, ushort? under = null)
		{
			TileIndex = i;
			XOff = x;
			YOff = y;
			TileUnder = under;
			HFlip = hflip;
			VFlip = vflip;
		}
	}
}
