using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

				switch (sheet)
				{
					case 0x0: return Sheet1[pixel];
					case 0x1: return Sheet2[pixel];
					case 0x2: return Sheet3[pixel];
					case 0x3: return Sheet4[pixel];
				}

				return 0x00;
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

				switch (sheet)
				{
					case 0x0: return BackgroundBlock1[pixel];
					case 0x1: return BackgroundBlock2[pixel];

					case 0x2: return SpriteBlock1[pixel];
					case 0x3: return SpriteBlock2[pixel];
				}

				return 0x00;
			}
		}

	}
}
