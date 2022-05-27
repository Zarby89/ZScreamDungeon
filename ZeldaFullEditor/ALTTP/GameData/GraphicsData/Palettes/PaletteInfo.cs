namespace ZeldaFullEditor.ALTTP.GameData.GraphicsData.Palettes
{
	/// <summary>
	/// Encapsulates meta information about a particular palette.
	/// </summary>
	/// <param name="Address">The SNES address where this palette is located.</param>
	/// <param name="Type">The type of palette this is, which will determine its real and virtual size.</param>
	public record PaletteInfo(int Address, PaletteType Type);
}
