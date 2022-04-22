using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	[Serializable]
	public class ExitOW : OverworldDestination, IMouseCollidable, IFreelyPlaceable
	{
		public byte unk1 { get; set; }
		public byte unk2 { get; set; }
		public byte doorXEditor { get; set; }
		public byte doorYEditor { get; set; }

		public ushort roomId { get; set; }

		public ushort doorType1 { get; set; }
		public ushort doorType2 { get; set; }

		public bool isAutomatic = true;
		public bool deleted = false;

		public ExitOW(ushort roomId, byte mapId, ushort vramLocation,
			ushort yScroll, ushort xScroll, ushort playerY, ushort playerX,
			ushort cameraY, ushort cameraX, byte unk1, byte unk2, ushort doorType1, ushort doorType2)
		{
			this.roomId = roomId;
			this.MapID = mapId;
			this.VRAMBase = vramLocation;
			this.ScrollX = xScroll;
			this.ScrollY = yScroll;
			this.GlobalX = playerX;
			this.GlobalY = playerY;
			this.CameraX = cameraX;
			this.CameraY = cameraY;
			this.unk1 = unk1;
			this.unk2 = unk2;
			this.doorType1 = doorType1;
			this.doorType2 = doorType2;

			if (doorType1 != 0)
			{
				int p = (doorType1 & 0x7FFF) >> 1;
				doorXEditor = (byte) (p % 64);
				doorYEditor = (byte) (p >> 6);
			}

			if (doorType2 != 0)
			{
				int p = (doorType2 & 0x7FFF) >> 1;
				doorXEditor = (byte) (p % 64);
				doorYEditor = (byte) (p >> 6);
			}

			int mapX = (mapId - ((mapId / 8) * 8));
			int mapY = (mapId / 8);

			MapX = (byte) ((Math.Abs(playerX - (mapX * 512)) / 16));
			MapY = (byte) ((Math.Abs(playerY - (mapY * 512)) / 16));
		}

		public ExitOW Copy()
		{
			return new ExitOW(
			roomId,
			MapID,
			VRAMBase,
			ScrollX,
			ScrollY,
			GlobalX,
			GlobalY,
			CameraX,
			CameraY,
			unk1,
			unk2,
			doorType1,
			doorType2);
		}

		public override bool PointIsInHitbox(int x, int y)
		{
			throw new NotImplementedException();
		}
	}
}
