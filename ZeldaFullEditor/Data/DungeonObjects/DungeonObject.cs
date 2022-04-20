using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{

	/// <summary>
	/// Defines a method for items that require a ZScreamer to be passed to refer their drawing to.
	/// </summary>
	public interface IDelegatedDraw
	{
		void Draw(ZScreamer ZS);
	}

	/// <summary>
	/// Represents objects that have draw routines based on the Bank00 tiles tables.
	/// </summary>
	public interface ITilesTableBasedDraw
	{
		TilesList Tiles { get; set; }
	}

	/// <summary>
	/// Contains the <see cref="Layer">Layer</see> property indicating which layer an entity is on.
	/// </summary>
	public interface IMultilayered
	{
		byte Layer { get; set; }
	}

	/// <summary>
	/// Contains methods for objects to communicate collision with user control.
	/// </summary>
	public interface IMouseCollidable
	{
		bool PointIsInHitbox(int x, int y);
	}

	/// <summary>
	/// Contains properties common to objects that can be moved around freely with the mouse.
	/// </summary>
	public interface IFreelyPlaceable
	{
		byte X { get; set; }
		byte Y { get; set; }
		byte NX { get; set; }
		byte NY { get; set; }
	}

	/// <summary>
	/// Represents any object which can be placed inside a dungeon.
	/// </summary>
	public abstract class DungeonPlaceable : IDelegatedDraw, IMouseCollidable
	{
		public abstract void Draw(ZScreamer ZS);
		public abstract bool PointIsInHitbox(int x, int y);
	}
}
