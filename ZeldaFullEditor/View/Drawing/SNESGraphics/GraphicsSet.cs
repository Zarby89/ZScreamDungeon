using static ZeldaFullEditor.View.Drawing.SNESGraphics.PaletteID;

namespace ZeldaFullEditor.View.Drawing.SNESGraphics
{
	public class GraphicsDoubleBlock : IByteable
	{
		public GraphicsBlock Block1 { get; set; } = GraphicsBlock.Empty;

		public GraphicsBlock Block2 { get; set; } = GraphicsBlock.Empty;

		public byte[] GetByteData()
		{
			return (byte[]) Block1.GetByteData().Concat(Block2.GetByteData());
		}
	}

	public class GraphicsBlock : IByteable, IGraphicsSheet
	{
		public GraphicsSheet Sheet1 { get; set; } = GraphicsSheet.Empty;
		public GraphicsSheet Sheet2 { get; set; } = GraphicsSheet.Empty;
		public GraphicsSheet Sheet3 { get; set; } = GraphicsSheet.Empty;
		public GraphicsSheet Sheet4 { get; set; } = GraphicsSheet.Empty;

		public GraphicsTile this[int i] => i switch
		{
			< 0x040 => Sheet1[i & 0x3F],
			< 0x080 => Sheet2[i & 0x3F],
			< 0x0C0 => Sheet3[i & 0x3F],
			< 0x100 => Sheet4[i & 0x3F],
			_ => throw new IndexOutOfRangeException($"Cannot access tile with ID of {i:X3}")
		};

		public GraphicsBlock() { }

		public void CopyBlock(GraphicsBlock b)
		{
			Sheet1 = b.Sheet1;
			Sheet2 = b.Sheet2;
			Sheet3 = b.Sheet3;
			Sheet4 = b.Sheet4;
		}

		public void CopyBlockCautiously(GraphicsBlock b)
		{
			if (b.Sheet1.ID != 0x00)
			{
				Sheet1 = b.Sheet1;
			}

			if (b.Sheet2.ID != 0x00)
			{
				Sheet2 = b.Sheet2;
			}

			if (b.Sheet3.ID != 0x00)
			{
				Sheet3 = b.Sheet3;
			}

			if (b.Sheet4.ID != 0x00)
			{
				Sheet4 = b.Sheet4;
			}
		}

		public byte[] GetByteData()
		{
			return new[] { Sheet1.ID, Sheet2.ID, Sheet3.ID, Sheet4.ID };
		}

		public bool ContainsExpectedSheets(RequiredGraphicsSheets set, bool latter)
		{
			if (latter)
			{
				return (set.Sheet4?.Contains(Sheet1.ID) ?? true) &&
					(set.Sheet5?.Contains(Sheet2.ID) ?? true) &&
					(set.Sheet6?.Contains(Sheet3.ID) ?? true) &&
					(set.Sheet7?.Contains(Sheet4.ID) ?? true);
			}
			else
			{
				return (set.Sheet0?.Contains(Sheet1.ID) ?? true) &&
					(set.Sheet1?.Contains(Sheet2.ID) ?? true) &&
					(set.Sheet2?.Contains(Sheet3.ID) ?? true) &&
					(set.Sheet3?.Contains(Sheet4.ID) ?? true);
			}
		}

		public static GraphicsBlock Empty => new();
	}


	public unsafe class GraphicsSet : IGraphicsSheet
	{
		public GraphicsBlock BackgroundBlock1 { get; set; } = GraphicsBlock.Empty;
		public GraphicsBlock BackgroundBlock2 { get; set; } = GraphicsBlock.Empty;
		public GraphicsBlock SpriteBlock1 { get; set; } = GraphicsBlock.Empty;
		public GraphicsBlock SpriteBlock2 { get; set; } = GraphicsBlock.Empty;

		public GraphicsTile this[int i] => i switch
		{
			< 0x100 => BackgroundBlock1[i & 0xFF],
			< 0x200 => BackgroundBlock2[i & 0xFF],
			< 0x300 => SpriteBlock1[i & 0xFF],
			< 0x400 => SpriteBlock2[i & 0xFF],
			_ => throw new IndexOutOfRangeException($"Cannot access tile with ID of {i:X3}")
		};

		public GraphicsTile GetBackgroundGraphicsTile(int id) => this[id];

		public bool CheckIfSpriteWillLookGood(SpriteType t)
		{
			return SpriteBlock1.ContainsExpectedSheets(t.RequiredSheets, false) &&
				SpriteBlock2.ContainsExpectedSheets(t.RequiredSheets, true);
		}

		public bool CheckIfObjectWillLookGood(RoomObjectType t)
		{
			return BackgroundBlock1.ContainsExpectedSheets(t.RequiredSheets, false) &&
				BackgroundBlock2.ContainsExpectedSheets(t.RequiredSheets, true);
		}

		public void SetBackgroundGraphicsBlock1(GraphicsBlock b)
		{
			BackgroundBlock1.CopyBlock(b);
		}

		public void SetBackgroundGraphicsBlock2(GraphicsBlock b)
		{
			BackgroundBlock2.CopyBlock(b);
		}

		public void SetSpriteGraphicsBlock1(GraphicsBlock b)
		{
			SpriteBlock1.CopyBlock(b);
		}

		public void SetSpriteGraphicsBlock2(GraphicsBlock b)
		{
			SpriteBlock2.CopyBlock(b);
		}


		public GraphicsTile GetSpriteGraphicsTile(int id) => id switch
		{
			< 0x100 => SpriteBlock1[id & 0xFF],
			< 0x200 => SpriteBlock2[id & 0xFF],
			_ => throw new IndexOutOfRangeException($"Cannot access sprite tile with ID of {id:X3}")
		};

		public (GraphicsTile, PaletteID) GetBackgroundTileWithPalette(ushort tile, byte pal)
		{
			var r1 = this[tile];

			bool rightside = tile switch
			{
				< 0x0040 => true,
				>= 0x0040 and < 0x0080 => false,
				>= 0x0080 and < 0x00C0 => false,
				>= 0x00C0 and < 0x0100 => true,

				>= 0x0100 and < 0x0140 => true,
				>= 0x0140 and < 0x0180 => true,
				>= 0x0180 and < 0x01C0 => false,
				>= 0x01C0 and < 0x0200 => false,

				>= 0x0200 and < 0x0240 => SpriteBlock1.Sheet1.Info.UsesBackPalette,
				>= 0x0240 and < 0x0280 => SpriteBlock1.Sheet2.Info.UsesBackPalette,
				>= 0x0280 and < 0x02C0 => SpriteBlock1.Sheet3.Info.UsesBackPalette,
				>= 0x02C0 and < 0x0300 => SpriteBlock1.Sheet4.Info.UsesBackPalette,

				>= 0x0300 and < 0x0340 => SpriteBlock2.Sheet1.Info.UsesBackPalette,
				>= 0x0340 and < 0x0380 => SpriteBlock2.Sheet2.Info.UsesBackPalette,
				>= 0x0380 and < 0x03C0 => SpriteBlock2.Sheet3.Info.UsesBackPalette,
				>= 0x03C0 and < 0x0400 => SpriteBlock2.Sheet4.Info.UsesBackPalette,

				_ => false,
			} ?? false;

			PaletteID r2 = (pal, rightside) switch
			{
				(0, false) => BackgroundPalette0Left,
				(0, true) => BackgroundPalette0Right,
				(1, false) => BackgroundPalette1Left,
				(1, true) => BackgroundPalette1Right,
				(2, false) => BackgroundPalette2Left,
				(2, true) => BackgroundPalette2Right,
				(3, false) => BackgroundPalette3Left,
				(3, true) => BackgroundPalette3Right,
				(4, false) => BackgroundPalette4Left,
				(4, true) => BackgroundPalette4Right,
				(5, false) => BackgroundPalette5Left,
				(5, true) => BackgroundPalette5Right,
				(6, false) => BackgroundPalette6Left,
				(6, true) => BackgroundPalette6Right,
				(7, false) => BackgroundPalette7Left,
				(7, true) => BackgroundPalette7Right,
				_ => BackgroundPalette0Left,
			};

			return (r1, r2);
		}

		public (GraphicsTile, PaletteID) GetSpriteTileWithPalette(ushort tile, byte pal)
		{
			var r1 = GetSpriteGraphicsTile(tile);

			bool rightside = tile switch
			{
				>= 0x0000 and < 0x0040 => SpriteBlock1.Sheet1.Info.UsesBackPalette,
				>= 0x0040 and < 0x0080 => SpriteBlock1.Sheet2.Info.UsesBackPalette,
				>= 0x0080 and < 0x00C0 => SpriteBlock1.Sheet3.Info.UsesBackPalette,
				>= 0x00C0 and < 0x0100 => SpriteBlock1.Sheet4.Info.UsesBackPalette,

				>= 0x0100 and < 0x0140 => SpriteBlock2.Sheet1.Info.UsesBackPalette,
				>= 0x0140 and < 0x0180 => SpriteBlock2.Sheet2.Info.UsesBackPalette,
				>= 0x0180 and < 0x01C0 => SpriteBlock2.Sheet3.Info.UsesBackPalette,
				>= 0x01C0 and < 0x0200 => SpriteBlock2.Sheet4.Info.UsesBackPalette,

				_ => false,
			} ?? false;

			PaletteID r2 = (pal, rightside) switch
			{
				(0, false) => SpritePalette0Left,
				(0, true) => SpritePalette0Right,
				(1, false) => SpritePalette1Left,
				(1, true) => SpritePalette1Right,
				(2, false) => SpritePalette2Left,
				(2, true) => SpritePalette2Right,
				(3, false) => SpritePalette3Left,
				(3, true) => SpritePalette3Right,
				(4, false) => SpritePalette4Left,
				(4, true) => SpritePalette4Right,
				(5, false) => SpritePalette5Left,
				(5, true) => SpritePalette5Right,
				(6, false) => SpritePalette6Left,
				(6, true) => SpritePalette6Right,
				(7, false) => SpritePalette7Left,
				(7, true) => SpritePalette7Right,
				_ => SpritePalette0Left,
			};

			return (r1, r2);
		}

		public (GraphicsTile, PaletteID) GetBackgroundTileWithPalette(Tile tile)
		{
			return GetBackgroundTileWithPalette(tile.ID, tile.Palette);
		}

		public (GraphicsTile, PaletteID) GetSpriteTileWithPalette(OAMDrawInfo tile)
		{
			return GetSpriteTileWithPalette(tile.TileIndex, tile.Palette);
		}
	}
}
