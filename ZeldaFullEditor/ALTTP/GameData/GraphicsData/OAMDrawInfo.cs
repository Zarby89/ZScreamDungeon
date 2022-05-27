namespace ZeldaFullEditor.ALTTP.GameData.GraphicsData
{
	/// <summary>
	/// Represents a set of instructions for how to draw a new sprite object.
	/// </summary>
	public record struct OAMDrawInfo(ushort TileIndex, int XOff, int YOff, byte Palette, bool HFlip, bool VFlip, bool IsBig);
}
