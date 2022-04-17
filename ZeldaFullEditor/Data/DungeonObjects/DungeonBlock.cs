using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public class DungeonBlock : IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IMultilayered
	{
		public byte X { get; set; }
		public byte Y { get; set; }
		public byte NX { get; set; }
		public byte NY { get; set; }
		public byte Layer { get; set; }



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
