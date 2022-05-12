namespace ZeldaFullEditor
{
	public readonly struct OverlayTile
	{
		public byte MapX { get; }
		public byte MapY { get; }
		public ushort Map16Value { get; }

		public bool IsGarbage => Map16Value == 0xFFFF;

		public OverlayTile(byte x, byte y, ushort tileId)
		{
			MapX = x;
			MapY = y;
			Map16Value = tileId;
		}

		public static readonly OverlayTile GarbageTile = new(0xFF, 0xFF, 0xFFFF);
	}
}
