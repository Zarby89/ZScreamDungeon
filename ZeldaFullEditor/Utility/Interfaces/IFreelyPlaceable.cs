namespace ZeldaFullEditor
{
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
}
