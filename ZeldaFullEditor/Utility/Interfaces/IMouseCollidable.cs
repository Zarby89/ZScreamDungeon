using System.Drawing;
using System.Windows.Forms;

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

	public static class MouseExtensions
	{
		public static bool IsCapturedByRectangle(this IMouseCollidable me, Rectangle cap)
		{
			return cap.IntersectsWith(me.SquareHitbox);
		}

		public static bool MouseIsInHitbox(this IMouseCollidable me, MouseEventArgs e)
		{
			return me.PointIsInHitbox(e.X, e.Y);
		}
	}
}
