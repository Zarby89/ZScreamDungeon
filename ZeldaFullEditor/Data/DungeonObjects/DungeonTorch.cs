using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public unsafe class DungeonTorch : DungeonPlaceable, IFreelyPlaceable, IMouseCollidable, IMultilayered
	{

		public byte X { get; set; } = 0;
		public byte Y { get; set; } = 0;
		public byte NX { get; set; }
		public byte NY { get; set; }
		public byte Layer { get; set; } = 0;


		public DungeonTorch()
		{
		}

		public override void Draw(ZScreamer ZS)
		{

		}

		public override bool PointIsInHitbox(int x, int y)
		{
			throw new NotImplementedException();
		}
	}
}
