using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaFullEditor.Data;

namespace ZeldaFullEditor.Data.Underworld
{
	/// <summary>
	/// Represents any object which can be placed inside a dungeon.
	/// </summary>
	public abstract class DungeonPlaceable : IDelegatedDraw, IMouseCollidable
	{
		public abstract void Draw(ZScreamer ZS);
		public abstract bool PointIsInHitbox(int x, int y);
	}
}
