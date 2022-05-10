namespace ZeldaFullEditor
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

		public byte this[int i]
		{
			get
			{
				int sheet = i / (128 * 32);
				int pixel = i % (128 * 32);

				return sheet switch
				{
					0x0 => Sheet1[pixel],
					0x1 => Sheet2[pixel],
					0x2 => Sheet3[pixel],
					0x3 => Sheet4[pixel],
					_ => 0x00,
				};
			}
		}

		public GraphicsBlock() { }

		public byte[] GetByteData()
		{
			return new byte[] { Sheet1.ID, Sheet2.ID, Sheet3.ID, Sheet4.ID };
		}
	}


	public unsafe class GraphicsSet : IGraphicsSheet
	{
		public GraphicsBlock BackgroundBlock1 { get; set; }
		public GraphicsBlock BackgroundBlock2 { get; set; }
		public GraphicsBlock SpriteBlock1 { get; set; }
		public GraphicsBlock SpriteBlock2 { get; set; }

		public byte this[int i]
		{
			get
			{
				int sheet = i / (128 * 32 * 4);
				int pixel = i % (128 * 32 * 4);

				return sheet switch
				{
					0x0 => BackgroundBlock1[pixel],
					0x1 => BackgroundBlock2[pixel],
					0x2 => SpriteBlock1[pixel],
					0x3 => SpriteBlock2[pixel],
					_ => 0x00,
				};
			}
		}

	}
}
