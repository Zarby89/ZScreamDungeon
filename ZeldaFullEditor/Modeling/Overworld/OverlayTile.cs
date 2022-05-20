namespace ZeldaFullEditor.Modeling.Overworld
{
	public readonly struct OverlayTile
	{
		public byte MapX { get; }
		public byte MapY { get; }
		public ushort Tile16ID { get; }

		public bool IsGarbage => Tile16ID == 0xFFFF;

		public OverlayTile(byte x, byte y, ushort tileId)
		{
			MapX = x;
			MapY = y;
			Tile16ID = tileId;
		}

		public static readonly OverlayTile GarbageTile = new(0xFF, 0xFF, 0xFFFF);
	}
}
