namespace ZeldaFullEditor.UserInterface.UIControl;

/// <summary>
/// Defines functionality for objects to communicate collision with user control.
/// </summary>
public interface IMouseCollidable
{
	public int RealX { get; }
	public int RealY { get; }

	/// <summary>
	/// Gets a dynamically created <see cref="Rectangle"/> structure that forms a naively simple hitbox of this entity.
	/// </summary>
	/// <returns>
	/// Returns the smallest <see cref="Rectangle"/> that perfectly captures this entity.
	/// </returns>
	public Rectangle BoundingBox { get; }

	/// <summary>
	/// Checks the dynamically calculated hitbox specific to this entity in its current state against the specified coordinates.
	/// </summary>
	/// <returns><see langword="true"/> if the point falls within the entity's hitbox.</returns>
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
