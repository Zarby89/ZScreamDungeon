namespace ZeldaFullEditor
{
	/// <summary>
	/// Contains methods for objects to communicate collision with user control.
	/// </summary>
	public interface IMouseCollidable
	{
		public int RealX { get; }
		public int RealY { get; }

		public Rectangle BoundingBox { get; }

		public bool PointIsInHitbox(int x, int y);
	}

	public static class MouseCollidableExtensions
	{
		public static bool IsCapturedByRectangle(this IMouseCollidable me, Rectangle cap)
		{
			return cap.IntersectsWith(me.BoundingBox);
		}

		public static bool PointIsInBoundingBox(this IMouseCollidable me, int x, int y)
		{
			return me.BoundingBox.Contains(x, y);
		}

		public static bool MouseIsInHitbox(this IMouseCollidable me, MouseEventArgs e)
		{
			return me.PointIsInHitbox(e.X, e.Y);
		}

		public static bool MouseIsInBoundingBox(this IMouseCollidable me, MouseEventArgs e)
		{
			return me.BoundingBox.Contains(e.X, e.Y);
		}
	}
}
