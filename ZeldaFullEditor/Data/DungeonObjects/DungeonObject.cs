using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public abstract class DungeonPlaceable : IDelegatedDraw, IMouseCollidable
	{
		public abstract void Draw(ZScreamer ZS);
		public abstract bool PointIsInHitbox(int x, int y);
	}

	public abstract class DungeonObject : DungeonPlaceable, IByteable, IDelegatedDraw, IMouseCollidable
	{
		/// <summary>
		/// Returns a list of points representing the collision box of the object within the GUI.
		/// </summary>
		public virtual List<Point> CollisionPoints { get; } = new List<Point>();

		public abstract TilesList Tiles { get; }

		/// <summary>
		/// Returns an array of bytes representing the ROM data of the object in its current state.
		/// </summary>
		public abstract byte[] Data { get; }

		/// <summary>
		/// Draws this object to the given controller's graphics or tilemap buffer.
		/// </summary>
		/// <param name="ZS">Graphics controller parent</param>
		public abstract override void Draw(ZScreamer ZS);

		public abstract override bool PointIsInHitbox(int x, int y);
	}
}
