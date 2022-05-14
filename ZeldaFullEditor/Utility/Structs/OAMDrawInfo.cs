namespace ZeldaFullEditor
{
	/// <summary>
	/// Represents a set of instructions for how to draw a new sprite object.
	/// </summary>
	public record struct OAMDrawInfo(int TileIndex, int XOff, int YOff, byte Palette, bool HFlip, bool VFlip, bool IsBig)
	{
		public int RectSideSize => IsBig ? 16 : 8;
	}
}
