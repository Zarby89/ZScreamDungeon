namespace ZeldaFullEditor.UserInterface.Drawing
{
	public readonly record struct PreviewInfo(ushort ID, int X, int Y, byte Palette, bool HFlip, bool VFlip, bool GlobalSheet = false);
}
