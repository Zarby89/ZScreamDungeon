namespace ZeldaFullEditor
{
	/// <summary>
	/// Represents a set of instructions for how to draw a new tile to the background.
	/// </summary>
	/// <param name="TileIndex">The index into the object's tile listing to use</param>
	/// <param name="XOff">The X-axis offset of the tile relative to the object's coordinates</param>
	/// <param name="YOff">The Y-axis offset of the tile relative to the object's coordinates</param>
	public record DrawInfo(int TileIndex, int XOff, int YOff)
	{
		/// <summary>
		/// The data this tile is forbidden to overwrite.
		/// </summary>
		public ushort? TileUnder { get; init; } = null;

		/// <summary>
		/// Forces the horizontal flip of the tile if not <see langword="null"/>
		/// </summary>
		public bool? HFlip { get; init; } = null;

		/// <summary>
		/// Forces the vertical flip of the tile if not <see langword="null"/>
		/// </summary>
		public bool? VFlip { get; init; } = null;

		/// <summary>
		/// Inverts HFlip of target tile if <see langword="true"/>
		/// </summary>
		public bool HXOR { get; init; } = false;

		/// <summary>
		/// Inverts VFlip of target tile if <see langword="true"/>
		/// </summary>
		public bool VXOR { get; init; } = false;
	}
}
