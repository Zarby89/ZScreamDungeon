namespace ZeldaFullEditor.UserInterface.UserControl
{
	/// <summary>
	/// Defines properties common to objects that can be moved around freely with the mouse.
	/// </summary>
	public interface IFreelyPlaceable
	{
		public byte GridX { get; set; }
		public byte GridY { get; set; }
		public int RealX { get; set; }
		public int RealY { get; set; }
	}
}
