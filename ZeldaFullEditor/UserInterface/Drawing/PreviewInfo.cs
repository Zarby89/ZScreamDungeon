namespace ZeldaFullEditor.UserInterface.Drawing
{
	public record PreviewInfo(ushort ID, int X, int Y, byte Palette, bool HFlip, bool VFlip, bool GlobalSheet = false);
}
