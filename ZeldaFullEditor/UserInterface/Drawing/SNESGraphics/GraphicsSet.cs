namespace ZeldaFullEditor.UserInterface.Drawing.SNESGraphics
{
	public unsafe class GraphicsSet : IGraphicsSheet
	{
		public SlottedSheet BGSheet0 { get; init; } = new(GraphicsSheet.Empty, false);
		public SlottedSheet BGSheet1 { get; init; } = new(GraphicsSheet.Empty, false);
		public SlottedSheet BGSheet2 { get; init; } = new(GraphicsSheet.Empty, false);
		public SlottedSheet BGSheet3 { get; init; } = new(GraphicsSheet.Empty, false);

		public SlottedSheet BGSheet4 { get; init; } = new(GraphicsSheet.Empty, false);
		public SlottedSheet BGSheet5 { get; init; } = new(GraphicsSheet.Empty, false);
		public SlottedSheet BGSheet6 { get; init; } = new(GraphicsSheet.Empty, false);
		public SlottedSheet BGSheet7 { get; init; } = new(GraphicsSheet.Empty, false);

		public SlottedSheet BGSheetA { get; init; } = null;

		public SlottedSheet SPRSheet0 { get; init; } = new(GraphicsSheet.Empty, false);
		public SlottedSheet SPRSheet1 { get; init; } = new(GraphicsSheet.Empty, false);
		public SlottedSheet SPRSheet2 { get; init; } = new(GraphicsSheet.Empty, false);
		public SlottedSheet SPRSheet3 { get; init; } = new(GraphicsSheet.Empty, false);

		public SlottedSheet SPRSheet4 { get; init; } = new(GraphicsSheet.Empty, false);
		public SlottedSheet SPRSheet5 { get; init; } = new(GraphicsSheet.Empty, false);
		public SlottedSheet SPRSheet6 { get; init; } = new(GraphicsSheet.Empty, false);
		public SlottedSheet SPRSheet7 { get; init; } = new(GraphicsSheet.Empty, false);

		public GraphicsTile this[int i] => i switch
		{
			< 0x400 => GetSheetForID(i).Sheet[i & 0x3F],
			_ => throw new IndexOutOfRangeException($"Cannot access tile with ID of {i:X3}")
		};

		private SlottedSheet GetSheetForID(int id) => (id >> 6) switch
		{
			0x00 => BGSheet0,
			0x01 => BGSheet1,
			0x02 => BGSheet2,
			0x03 => BGSheet3,
			0x04 => BGSheet4,
			0x05 => BGSheet5,
			0x06 => BGSheet6,

			// account for animated sheet, when it exists
			0x07 when (id & 0x3F) is >= 0x10 => BGSheet7,
			0x07 when (id & 0x3F) is < 0x10 => BGSheetA ?? BGSheet7,

			0x08 => SPRSheet0,
			0x09 => SPRSheet1,
			0x0A => SPRSheet2,
			0x0B => SPRSheet3,
			0x0C => SPRSheet4,
			0x0D => SPRSheet5,
			0x0E => SPRSheet6,
			0x0F => SPRSheet7,

			_ => null
		};

		public GraphicsTile GetBackgroundGraphicsTile(int id) => this[id];

		public bool CheckIfEntityWillLookGood(object t) => t switch
		{
			SpriteType s => CheckIfSpriteWillLookGood(s),
			RoomObjectType r => CheckIfObjectWillLookGood(r),
			_ => true
		};


		public bool CheckIfSpriteWillLookGood(SpriteType t)
		{
			return
				(t.RequiredSheets.Sheet0?.Contains(SPRSheet0.Sheet.ID ?? 0xFF) ?? true) &&
				(t.RequiredSheets.Sheet1?.Contains(SPRSheet1.Sheet.ID ?? 0xFF) ?? true) &&
				(t.RequiredSheets.Sheet2?.Contains(SPRSheet2.Sheet.ID ?? 0xFF) ?? true) &&
				(t.RequiredSheets.Sheet3?.Contains(SPRSheet3.Sheet.ID ?? 0xFF) ?? true) &&
				(t.RequiredSheets.Sheet4?.Contains(SPRSheet4.Sheet.ID ?? 0xFF) ?? true) &&
				(t.RequiredSheets.Sheet5?.Contains(SPRSheet5.Sheet.ID ?? 0xFF) ?? true) &&
				(t.RequiredSheets.Sheet6?.Contains(SPRSheet6.Sheet.ID ?? 0xFF) ?? true) &&
				(t.RequiredSheets.Sheet7?.Contains(SPRSheet7.Sheet.ID ?? 0xFF) ?? true);
		}

		public bool CheckIfObjectWillLookGood(RoomObjectType t)
		{
			return
				(t.RequiredSheets.Sheet0?.Contains(BGSheet0.Sheet.ID ?? 0xFF) ?? true) &&
				(t.RequiredSheets.Sheet1?.Contains(BGSheet1.Sheet.ID ?? 0xFF) ?? true) &&
				(t.RequiredSheets.Sheet2?.Contains(BGSheet2.Sheet.ID ?? 0xFF) ?? true) &&
				(t.RequiredSheets.Sheet3?.Contains(BGSheet3.Sheet.ID ?? 0xFF) ?? true) &&
				(t.RequiredSheets.Sheet4?.Contains(BGSheet4.Sheet.ID ?? 0xFF) ?? true) &&
				(t.RequiredSheets.Sheet5?.Contains(BGSheet5.Sheet.ID ?? 0xFF) ?? true) &&
				(t.RequiredSheets.Sheet6?.Contains(BGSheet6.Sheet.ID ?? 0xFF) ?? true) &&
				(t.RequiredSheets.Sheet7?.Contains(BGSheet7.Sheet.ID ?? 0xFF) ?? true);
		}

		public (GraphicsTile, PaletteID) GetBackgroundTileWithPalette(ushort tile, byte pal)
		{
			var r1 = GetSheetForID(tile);
			var r2 = (r1.RightSide ? 0x08 : 0x00) | (pal << 4);
			return (r1.Sheet[tile & 0x3F], (PaletteID) r2);
		}

		public (GraphicsTile, PaletteID) GetSpriteTileWithPalette(ushort tile, byte pal)
		{
			tile |= 0x200;
			return GetBackgroundTileWithPalette(tile, pal);
		}

		public (GraphicsTile, PaletteID) GetBackgroundTileWithPalette(Tile tile)
		{
			return GetBackgroundTileWithPalette(tile.ID, tile.Palette);
		}

		public (GraphicsTile, PaletteID) GetSpriteTileWithPalette(OAMDrawInfo tile)
		{
			return GetSpriteTileWithPalette(tile.ID, tile.Palette);
		}

		public void DrawSpriteTileToCanvas(IGraphicsCanvas canvas, OAMDrawInfo tile)
		{
			var (gfx, pal) = GetSpriteTileWithPalette(tile);
			gfx.DrawToCanvas(canvas, tile.X, tile.Y, (byte) pal, tile.HFlip, tile.VFlip);
		}

		public void DrawPreviewTileToCanvas(IGraphicsCanvas canvas, PreviewInfo tile)
		{
			var (gfx, pal) = GetBackgroundTileWithPalette(tile.ID, tile.Palette);
			gfx.DrawToCanvas(canvas, tile.X, tile.Y, (byte) pal, tile.HFlip, tile.VFlip);
		}
	}
}
