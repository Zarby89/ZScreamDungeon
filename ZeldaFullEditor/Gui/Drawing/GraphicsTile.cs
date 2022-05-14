namespace ZeldaFullEditor.Gui.Drawing
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
				throw new ArgumentException($"{typeof(GraphicsTile).Name} must be initialized with an array of exactly length 64.");
			}
			_data = data.DeepCopy();
		}

		public byte GetPixelAt(int x, int y, bool hflip, bool vflip)
		{

			return _data[(hflip ? 7 - x : x) + (8 * (vflip ? 7 - y : y))];
		}
	}
}
