using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.Underworld
{
	public class DungeonTorch : IDungeonPlaceable, IFreelyPlaceable, IMouseCollidable, IMultilayered, IByteable
	{
		private byte gridx, gridy;
		private const int Scale = 8;

		public byte GridX
		{
			get => gridx;
			set => gridy = value;
		}

		public byte GridY
		{
			get => gridy;
			set => gridy = value;
		}

		public int RealX
		{
			get => gridx * Scale;
			set => gridx = (byte) (value / Scale);
		}

		public int RealY
		{
			get => gridy * Scale;
			set => gridy = (byte) (value / Scale);
		}

		public RoomLayer Layer { get; set; } = RoomLayer.Layer1;
		public bool Lit { get; set; } = false;

		public Rectangle SquareHitbox => new Rectangle(RealX, RealY, 16, 16);

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
			UWTilemapPosition.CreateLowAndHighBytesFromXYZ(GridX, GridY, (byte) Layer, out byte low, out byte high);
			return new byte[] { low, high };
		}
	}
}
