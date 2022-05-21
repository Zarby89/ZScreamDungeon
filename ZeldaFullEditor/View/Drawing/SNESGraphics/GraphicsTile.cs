namespace ZeldaFullEditor.View.Drawing.SNESGraphics
{
	/// <summary>
	/// Represents the smallest possible graphical unit on the SNES: an 8-by-8 square pixel tile.
	/// This class treats its indices as 256 bits per pixel, but any lower bit depth may be represented
	/// by simply not using higher indices.
	/// </summary>
	public class GraphicsTile
	{
		private readonly byte[] _data;

		public byte this[int i] => _data[i];

		public byte this[int x, int y] => _data[x + 8 * y];

		/// <summary>
		/// <para>
		/// Initializes a new instance of the <see cref="GraphicsTile"/> class with the specified data stream.
		/// </para>
		/// <para>
		/// If <paramref name="data"/> is not exactly 64 bytes in length, an <see cref="ArgumentException"/> will be thrown.
		/// </para>
		/// </summary>
		/// <exception cref="ArgumentException"></exception>
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
	}
}
