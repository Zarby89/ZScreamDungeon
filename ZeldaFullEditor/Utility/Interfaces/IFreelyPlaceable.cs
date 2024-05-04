namespace ZeldaFullEditor
{
	/// <summary>
	/// Contains properties common to objects that can be moved around freely with the mouse.
	/// </summary>
	public interface IFreelyPlaceable
	{
		byte GridX { get; set; }
		byte GridY { get; set; }
		int RealX { get; set; }
		int RealY { get; set; }
	}
}
