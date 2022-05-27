namespace ZeldaFullEditor.UserInterface.Drawing.SNESGraphics
{
	/// <summary>
	/// Supports treating an object as an indexed image to which <see cref="GraphicsTile"/> objects may be drawn.
	/// </summary>
	public interface IGraphicsCanvas
	{
		public byte this[int i] { get; set; }

		public byte this[int x, int y] { get; set; }

		public Bitmap Bitmap { get; }

		public ColorPalette Palette { get; set; }
	}
}
