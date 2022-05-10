namespace ZeldaFullEditor
{
	internal interface IGraphicsCanvas
	{
		byte this[int i] { get; set; }

		Bitmap Bitmap { get; }

		ColorPalette Palette { get; set; }
	}
}
