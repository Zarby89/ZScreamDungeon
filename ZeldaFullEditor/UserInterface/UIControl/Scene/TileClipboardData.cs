namespace ZeldaFullEditor.UserInterface.UIControl.Scene
{
	[Serializable]
	public class TileClipboardData
	{
		public ushort[] tiles;
		public int length;

		public TileClipboardData(ushort[] tiles, int length)
		{
			this.tiles = tiles;
			this.length = length;
		}
	}
}
