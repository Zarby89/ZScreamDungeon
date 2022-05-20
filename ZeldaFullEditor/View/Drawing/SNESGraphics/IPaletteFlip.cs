namespace ZeldaFullEditor.View.Drawing.SNESGraphics
{
	public interface IPaletteFlip
	{
		public bool HFlip { get; }
		public bool VFlip { get; }
		public byte Palette { get; }
	}
}
