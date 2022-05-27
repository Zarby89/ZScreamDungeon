namespace ZeldaFullEditor.ALTTP.Overworld
{
	public class Gravestone
	{
		public ushort yTilePos;
		public ushort xTilePos;
		public ushort tilemapPos;
		public ushort gfx;

		public Gravestone(ushort x, ushort y, ushort tilemappos, ushort gfx)
		{
			xTilePos = x;
			yTilePos = y;
			tilemapPos = tilemappos;
			this.gfx = gfx;
		}
	}
}
