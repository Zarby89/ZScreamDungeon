using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public interface IDelegatedDraw
	{
		void Draw(ZScreamer ZS);
	}
	public interface IMultilayered
	{
		byte Layer { get; set; }
	}

	public interface IMouseCollidable
	{
		bool PointIsInHitbox(int x, int y);
	}

	public interface IFreelyPlaceable
	{
		byte X { get; set; }
		byte Y { get; set; }
		byte NX { get; set; }
		byte NY { get; set; }
	}
}
