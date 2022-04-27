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
		public byte GridX { get; set; }
		public byte GridY { get; set; }
		public byte NewX { get; set; }
		public byte NewY { get; set; }
		public RoomLayer Layer { get; set; }
		public int RealX => NewX * 8;
		public int RealY => NewY * 8;

		public Rectangle OutlineBox => new Rectangle(RealX, RealY, 16, 16);

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
