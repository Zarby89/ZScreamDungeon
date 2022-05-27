namespace ZeldaFullEditor.ALTTP.Overworld
{
	[Serializable]
	public class OverworldExit : OverworldDestination, IMouseCollidable, IFreelyPlaceable, IHaveInfo
	{
		public byte unk1 { get; set; }
		public byte unk2 { get; set; }

		// TODO these are never in sync and they need to be or some shit i don't know
		public byte doorXEditor { get; set; }
		public byte doorYEditor { get; set; }

		public ushort TargetRoomID { get; set; }

		public override string Name => "Exit";
		public ushort doorType1 { get; set; }
		public ushort doorType2 { get; set; }

		public bool isAutomatic = true;

		public OverworldExit(ushort roomId, byte mapId, ushort vramLocation,
			ushort yScroll, ushort xScroll, ushort playerY, ushort playerX,
			ushort cameraY, ushort cameraX, byte unk1, byte unk2, ushort doorType1, ushort doorType2)
		{
			TargetRoomID = roomId;
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
			this.doorType1 = doorType1;
			this.doorType2 = doorType2;

			if (doorType1 != 0)
			{
				var p = (doorType1 & 0x7FFF) >> 1;
				doorXEditor = (byte) (p % 64);
				doorYEditor = (byte) (p >> 6);
			}

			if (doorType2 != 0)
			{
				var p = (doorType2 & 0x7FFF) >> 1;
				doorXEditor = (byte) (p % 64);
				doorYEditor = (byte) (p >> 6);
			}
		}

		public override bool PointIsInHitbox(int x, int y)
		{
			return base.PointIsInHitbox(x, y);
		}
	}
}
