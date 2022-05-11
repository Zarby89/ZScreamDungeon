namespace ZeldaFullEditor
{
	internal interface IGraphicsCanvas
	{
		public byte this[int i] { get; set; }

		public Bitmap Bitmap { get; }

		public ColorPalette Palette { get; set; }
	}
}
