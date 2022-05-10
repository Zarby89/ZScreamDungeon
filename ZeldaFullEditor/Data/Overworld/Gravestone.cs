namespace ZeldaFullEditor.Data
{
	public class Gravestone
	{
		public ushort yTilePos;
		public ushort xTilePos;
		public ushort tilemapPos;
		public ushort gfx;

		public Gravestone(ushort x, ushort y, ushort tilemappos, ushort gfx)
		{
			this.xTilePos = x;
			this.yTilePos = y;
			this.tilemapPos = tilemappos;
			this.gfx = gfx;
		}
	}
}
