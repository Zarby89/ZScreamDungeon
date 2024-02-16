using System;

namespace ZeldaFullEditor
{
	public class TransportOW
	{
		public ushort
			vramLocation,
			xScroll,
			yScroll,
			playerX,
			playerY,
			cameraX,
			cameraY,
			mapId,
			whirlpoolPos;

		public byte
			unk1,
			unk2,
			AreaX,
			AreaY;

		public bool isAutomatic = true;

		public int uniqueID = 0;

		public TransportOW(byte mapId, ushort vramLocation, ushort yScroll, ushort xScroll, ushort playerY, ushort playerX, ushort cameraY, ushort cameraX, byte unk1, byte unk2, ushort whirlpoolPos)
		{
			this.mapId = mapId;
			this.vramLocation = vramLocation;
			this.xScroll = xScroll;
			this.yScroll = yScroll;
			this.playerX = playerX;
			this.playerY = playerY;
			this.cameraX = cameraX;
			this.cameraY = cameraY;
			this.unk1 = unk1;
			this.unk2 = unk2;
			this.whirlpoolPos = whirlpoolPos;

			int mapX = mapId - ((mapId / 8) * 8);
			int mapY = mapId / 8;

			AreaX = (byte) (Math.Abs(playerX - (mapX * 512)) / 16);
			AreaY = (byte) (Math.Abs(playerY - (mapY * 512)) / 16);

			uniqueID = ROM.uniqueTransportID++;
		}

		public void updateMapStuff(byte mapId, Overworld ow)
		{
			var large = 256;

			if (mapId < 128)
			{
				large = ow.AllMaps[mapId].LargeMap ? 768 : 256;
			}
			this.mapId = mapId;
			var mapx = (mapId & 7) << 9;
			var mapy = (mapId & 0x38) << 6;
			xScroll = (ushort) (playerX - 134);
			yScroll = (ushort) (playerY - 78);

			if (xScroll < mapx)
			{
				xScroll = (ushort) mapx;
			}

			if (yScroll < mapy)
			{
				yScroll = (ushort) mapy;
			}

			if (xScroll > mapx + large)
			{
				xScroll = (ushort) (mapx + large);
			}
			if (yScroll > mapy + large + 30)
			{
				yScroll = (ushort) (mapy + large + 30);
			}

			cameraX = playerX;
			cameraY = (ushort) (playerY + 19);

			if (cameraX < mapx + 127)
			{
				cameraX = (ushort) (mapx + 127);
			}
			else if (cameraX > mapx + 127 + large)
			{
				cameraX = (ushort) (mapx + 127 + large);
			}

			if (cameraY < mapy + 111)
			{
				cameraY = (ushort) (mapy + 111);
			}
			else if (cameraY > mapy + 143 + large)
			{
				cameraY = (ushort) (mapy + 143 + large);
			}

			var vramXScroll = (ushort) (xScroll - mapx);
			var vramYScroll = (ushort) (yScroll - mapy);

			vramLocation = (ushort) ((vramYScroll & 0xFFF0) << 3 | (vramXScroll & 0xFFF0) >> 3);

			// Console.WriteLine("Transport: " + mapId + " MapId: " + mapid.ToString("X2") + " X: " + AreaX + " Y: " + AreaY);
		}
	}
}
