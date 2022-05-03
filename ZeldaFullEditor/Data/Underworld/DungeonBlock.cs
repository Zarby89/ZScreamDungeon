using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.Underworld
{
	public class DungeonBlock : IDungeonPlaceable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IMultilayered
	{
		private byte gridx, gridy;
		private const int Scale = 8;

		public byte GridX
		{
			get => gridx;
			set => gridx = value;
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

		public RoomLayer Layer { get; set; }

		public Rectangle SquareHitbox => new Rectangle(RealX, RealY, 16, 16);

		public void Draw(ZScreamer ZS)
		{
			throw new NotImplementedException();
		}

		public bool PointIsInHitbox(int x, int y)
		{
			throw new NotImplementedException();
		}
	}
}
