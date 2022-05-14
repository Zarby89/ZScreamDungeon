namespace ZeldaFullEditor.Gui.Drawing
{
	public interface IGraphicsTile
	{
		public byte GetPixelAt(int x, int y, bool hflip, bool vflip);
	}


	public class GraphicsTile : IGraphicsTile
	{
		private readonly byte[] _data;

		public byte this[int i] => _data[i];

		public byte this[int x, int y] => _data[x + 8 * y];

		public GraphicsTile(byte[] data)
		{
			if (data.Length != 64)
			{
				throw new ArgumentException($"{typeof(GraphicsTile).Name} must be initialized with an array of exactly length 64.");
			}
			_data = data.DeepCopy();
		}

		public byte GetPixelAt(int x, int y, bool hflip, bool vflip)
		{

			return _data[(hflip ? 7 - x : x) + (8 * (vflip ? 7 - y : y))];
		}
	}

	public class BigSpriteTile : IGraphicsTile
	{
		private readonly GraphicsTile tile1;
		private readonly GraphicsTile tile2;
		private readonly GraphicsTile tile3;
		private readonly GraphicsTile tile4;

		public BigSpriteTile(GraphicsTile t1, GraphicsTile t2, GraphicsTile t3, GraphicsTile t4)
		{
			tile1 = t1;
			tile2 = t2;
			tile3 = t3;
			tile4 = t4;
		}

		public byte GetPixelAt(int x, int y, bool hflip, bool vflip)
		{
			x = hflip ? 15 - x : x;
			y = vflip ? 15 - y : y;

			throw new NotImplementedException("Hello BhaaLseN");

			return (x, y) switch
			{
				( >= 0 and < 8, >= 0 and < 8) => 0,
				( >= 0 and < 8, > 7 and < 16) => 0,
				( > 7 and < 16, >= 0 and < 8) => 0,
				( > 7 and < 16, > 7 and < 16) => 0,
				_ => 0,
			};
		}
	}
}
