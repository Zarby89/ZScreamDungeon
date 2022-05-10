namespace ZeldaFullEditor.SceneModes.ClipboardData
{
	[Serializable]
	public class TileData
	{
		public ushort[] tiles;
		public int length;

		public TileData(ushort[] tiles, int length)
		{
			this.tiles = tiles;
			this.length = length;
		}
	}
}
