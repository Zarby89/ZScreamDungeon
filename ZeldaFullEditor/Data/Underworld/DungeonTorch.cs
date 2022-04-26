using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.Underworld
{
	public unsafe class DungeonTorch : DungeonPlaceable, IFreelyPlaceable, IMouseCollidable, IMultilayered, IByteable
	{
		public byte GridX { get; set; } = 0;
		public byte GridY { get; set; } = 0;
		public byte NewX { get; set; }
		public byte NewY { get; set; }
		public byte Layer { get; set; } = 0;

		public int RealX => NewX * 8;
		public int RealY => NewY * 8;
		public bool Lit { get; set; } = false;

		public Rectangle OutlineBox => new Rectangle(RealX, RealY, 16, 16);

		public DungeonTorch()
		{

		}

		public void Draw(ZScreamer ZS)
		{

		}

		public bool PointIsInHitbox(int x, int y)
		{
			throw new NotImplementedException();
		}

		public byte[] GetByteData()
		{
			UWTilemapPosition.CreateLowAndHighBytesFromXYZ(GridX, GridY, Layer, out byte low, out byte high);
			return new byte[] { low, high };
		}
	}
}
