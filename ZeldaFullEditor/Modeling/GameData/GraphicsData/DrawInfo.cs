namespace ZeldaFullEditor.Modeling.GameData.GraphicsData
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
		/// Forces the horizontal flip of the tile.
		/// </summary>
		public FlipBehavior HFlip { get; init; } = FlipBehavior.LeaveAlone;

		/// <summary>
		/// Forces the vertical flip of the tile.
		/// </summary>
		public FlipBehavior VFlip { get; init; } = FlipBehavior.LeaveAlone;
	}
}
