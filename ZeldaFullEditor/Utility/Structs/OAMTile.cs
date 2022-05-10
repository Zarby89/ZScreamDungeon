namespace ZeldaFullEditor
{
	class OAMTile
	{
		public byte x, y, mx, my, pal;
		public ushort tile;
		public OAMTile(byte x, byte y, ushort tile, byte pal, bool upper = false, byte mx = 0, byte my = 0)
		{
			this.x = x;
			this.y = y;

			if (upper)
			{
				this.tile = (ushort) (tile + 512);
			}
			else
			{
				this.tile = (ushort) (tile + 256 + 512);
			}

			this.pal = pal;
			this.mx = mx;
			this.my = my;
		}
	}
}
