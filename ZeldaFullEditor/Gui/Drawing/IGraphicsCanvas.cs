namespace ZeldaFullEditor
{
	public interface IGraphicsCanvas
	{
		public byte this[int i] { get; set; }

		public byte this[int x, int y] { get; set; }

		public Bitmap Bitmap { get; }

		public ColorPalette Palette { get; set; }
	}
}
