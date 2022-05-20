namespace ZeldaFullEditor.Modeling.Overworld
{
	public class OverworldTransport : OverworldDestination, IMouseCollidable, IFreelyPlaceable, IHaveInfo
	{
		public ushort whirlpoolPos { get; set; }

		public byte unk1 { get; set; }
		public byte unk2 { get; set; }

		public bool isAutomatic = true;

		public override string Name => "Transport";

		public OverworldTransport(byte mapId, ushort vramLocation, ushort yScroll, ushort xScroll,
			ushort playerY, ushort playerX, ushort cameraY, ushort cameraX,
			byte unk1, byte unk2, ushort whirlpoolPos)
		{
			MapID = mapId;
			VRAMBase = vramLocation;
			ScrollX = xScroll;
			ScrollY = yScroll;
			GlobalX = playerX;
			GlobalY = playerY;
			CameraX = cameraX;
			CameraY = cameraY;
			this.unk1 = unk1;
			this.unk2 = unk2;
			this.whirlpoolPos = whirlpoolPos;
		}

		public override bool PointIsInHitbox(int x, int y)
		{
			return base.PointIsInHitbox(x, y);
		}

	}
}
