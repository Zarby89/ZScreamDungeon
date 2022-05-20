namespace ZeldaFullEditor.Gui.Drawing
{
	public interface IPaletteFlip
	{
		public bool HFlip { get; }
		public bool VFlip { get; }
		public byte Palette { get; }
	}
}
