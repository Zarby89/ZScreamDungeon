﻿namespace ZeldaFullEditor
{
	public class GraphicsDoubleBlock : IByteable
	{
		public GraphicsBlock Block1 { get; set; }

		public GraphicsBlock Block2 { get; set; }

		public byte[] GetByteData()
		{
			return (byte[]) Block1.GetByteData().Concat(Block2.GetByteData());
		}
	}

	public class GraphicsBlock : IByteable, IGraphicsSheet
	{
		public GraphicsSheet Sheet1 { get; set; }
		public GraphicsSheet Sheet2 { get; set; }
		public GraphicsSheet Sheet3 { get; set; }
		public GraphicsSheet Sheet4 { get; set; }

		public GraphicsTile this[int i] => i switch
		{
			< 0x040 => Sheet1[i & 0x3F],
			< 0x080 => Sheet2[i & 0x3F],
			< 0x0C0 => Sheet3[i & 0x3F],
			< 0x100 => Sheet4[i & 0x3F],
			_ => throw new IndexOutOfRangeException($"Cannot access tile with ID of {i:X3}")
		};

		public GraphicsBlock() { }

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
	}


	public unsafe class GraphicsSet : IGraphicsSheet
	{
		public GraphicsBlock BackgroundBlock1 { get; set; }
		public GraphicsBlock BackgroundBlock2 { get; set; }
		public GraphicsBlock SpriteBlock1 { get; set; }
		public GraphicsBlock SpriteBlock2 { get; set; }

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


		public GraphicsTile GetSpriteGraphicsTile(int id) => id switch
		{
			< 0x100 => SpriteBlock1[id & 0xFF],
			< 0x200 => SpriteBlock2[id & 0xFF],
			_ => throw new IndexOutOfRangeException($"Cannot access sprite tile with ID of {id:X3}")
		};
	}
}
