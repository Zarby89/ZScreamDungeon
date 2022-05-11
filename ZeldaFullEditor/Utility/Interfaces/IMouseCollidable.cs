namespace ZeldaFullEditor
{
	/// <summary>
	/// Contains methods for objects to communicate collision with user control.
	/// </summary>
	public interface IMouseCollidable
	{
		public int RealX { get; }
		public int RealY { get; }

		public Rectangle SquareHitbox { get; }

		public bool PointIsInHitbox(int x, int y);
	}

	public static class MouseCollidableExtensions
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
