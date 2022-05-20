namespace ZeldaFullEditor.View.Drawing.SNESGraphics
{
	public interface IPowerfulGraphicsSheet
	{
		public (GraphicsTile, PaletteID) GetBackgroundTileWithPalette(ushort tile, byte pal, bool hflip, bool vflip);
		public (GraphicsTile, PaletteID) GetSpriteTileWithPalette(ushort tile, byte pal, bool hflip, bool vflip);
	}

	public static class GraphicsSheetExtensions
	{
		public static (GraphicsTile, PaletteID) GetBackgroundTileWithPalette(this IPowerfulGraphicsSheet sheet, ushort tile, byte pal)
		{
			return sheet.GetBackgroundTileWithPalette(tile, pal, false, false);
		}

		public static (GraphicsTile, PaletteID) GetSpriteTileWithPalette(this IPowerfulGraphicsSheet sheet, ushort tile, byte pal)
		{
			return sheet.GetSpriteTileWithPalette(tile, pal, false, false);
		}
	}
}
