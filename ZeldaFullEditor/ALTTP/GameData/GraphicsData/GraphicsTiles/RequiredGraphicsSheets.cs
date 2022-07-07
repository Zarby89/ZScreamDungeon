namespace ZeldaFullEditor.ALTTP.GameData.GraphicsData.GraphicsTiles;

public record RequiredGraphicsSheets(
	byte[] Sheet0 = null, byte[] Sheet1 = null, byte[] Sheet2 = null, byte[] Sheet3 = null,
	byte[] Sheet4 = null, byte[] Sheet5 = null, byte[] Sheet6 = null, byte[] Sheet7 = null)
{
	public static readonly RequiredGraphicsSheets AllTilesets = new();
}
