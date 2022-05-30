namespace ZeldaFullEditor.ALTTP.GameData.GraphicsData
{
	/// <summary>
	/// Represents a set of instructions for how to draw a new sprite object.
	/// </summary>
	public record struct OAMDrawInfo(ushort ID, int X, int Y, byte Palette, bool HFlip, bool VFlip, bool IsBig);
}
