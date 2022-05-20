namespace ZeldaFullEditor.View.Drawing.SNESGraphics
{
	public class GraphicsTile
	{
		private readonly byte[] _data;

		public byte this[int i] => _data[i];

		public byte this[int x, int y] => _data[x + 8 * y];

		public GraphicsTile(byte[] data)
		{
			if (data.Length != 64)
			{
				throw new ArgumentException($"{typeof(GraphicsTile).Name} instances must be initialized with an array exactly of length 64.");
			}
			_data = data.DeepCopy();
		}

		public byte GetPixelAt(int x, int y, bool hflip, bool vflip)
		{
			return this[hflip ? 7 - x : x, vflip ? 7 - y : y];
		}

		public void DrawToCanvas(IGraphicsCanvas canvas, int x, int y, byte pal, bool hflip, bool vflip)
		{
			throw new NotImplementedException();
		}

		public void DrawToCanvas(IGraphicsCanvas canvas, int x, int y, byte pal)
		{
			DrawToCanvas(canvas, x, y, pal, false, false);
		}

		public void DrawToCanvas(IGraphicsCanvas canvas, int x, int y, IPaletteFlip t)
		{
			DrawToCanvas(canvas, x, y, t.Palette, t.HFlip, t.VFlip);
		}
	}
}
