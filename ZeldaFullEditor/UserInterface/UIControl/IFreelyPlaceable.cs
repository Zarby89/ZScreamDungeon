namespace ZeldaFullEditor.UserInterface.UIControl;

/// <summary>
/// Defines properties common to objects that can be moved around freely with the mouse.
/// </summary>
public interface IFreelyPlaceable
{
	public byte GridX { get; set; }
	public byte GridY { get; set; }
	public int RealX { get; set; }
	public int RealY { get; set; }
	public int LockedX { get; set; }
	public int LockedY { get; set; }
}

public static class FreelyPlaceableFunctions
{
	public static void LockPosition(this IFreelyPlaceable f)
	{
		f.LockedX = f.RealX;
		f.LockedY = f.RealY;
	}

	public static void MoveByDelta(this IFreelyPlaceable f, int x, int y)
	{
		f.RealX = f.LockedX + x;
		f.RealY = f.LockedY + y;
	}
}
