using System.Drawing;

namespace ZeldaFullEditor
{
	/// <summary>
	/// Contains methods for objects to communicate collision with user control.
	/// </summary>
	public interface IMouseCollidable
	{
		int RealX { get; }
		int RealY { get; }

		Rectangle SquareHitbox { get; }

		bool PointIsInHitbox(int x, int y);
	}
}
