using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor
{
	[Serializable]
	public class ExitOW
	{
		public byte
			mapId,
			unk1,
			unk2,
			doorXEditor,
			doorYEditor,
			AreaX,
			AreaY;

		public short
			vramLocation,
			roomId,
			xScroll,
			yScroll,
			cameraX,
			cameraY,
			doorType1,
			doorType2;

		public ushort
			playerX,
			playerY;

		public bool isAutomatic = true;
		public bool deleted = false;
		public int uniqueID = 0;
		public ExitOW(short roomId, byte mapId, short vramLocation, short yScroll, short xScroll, ushort playerY, ushort playerX, short cameraY, short cameraX, byte unk1, byte unk2, short doorType1, short doorType2)
		{
			this.roomId = roomId;
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

			AreaX = (byte) ((Math.Abs(playerX - (mapX * 512)) / 16));
			AreaY = (byte) ((Math.Abs(playerY - (mapY * 512)) / 16));


			uniqueID = ROM.uniqueExitID;
			ROM.uniqueExitID += 1;
		}

		public ExitOW Copy()
		{
			return new ExitOW(
			roomId,
			mapId,
			vramLocation,
			xScroll,
			yScroll,
			playerX,
			playerY,
			cameraX,
			cameraY,
			unk1,
			unk2,
			doorType1,
			doorType2);
		}

		public void updateMapStuff(byte mapId, Overworld ow)
		{
			this.mapId = mapId;

			int large = 256;
			int mapid = mapId;

			if (mapId < 128)
			{
				large = ow.allmaps[mapId].largeMap ? 768 : 256;
				if (ow.allmaps[mapId].parent != mapId)
				{
					mapid = ow.allmaps[mapId].parent;
				}
			}

			int mapX = (mapId - ((mapId / 8) * 8));
			int mapY = (mapId / 8);

			AreaX = (byte) ((Math.Abs(playerX - (mapX * 512)) / 16));
			AreaY = (byte) ((Math.Abs(playerY - (mapY * 512)) / 16));

			// If map is large, large = 768, otherwise 256

			// mapx, mapy = "super map" position on the grid *512

			if (mapId >= 64)
			{
				mapId -= 64;
			}

			int mapx = (mapId & 7) << 9;
			int mapy = ((mapId & 56) << 6);
			if (isAutomatic)
			{
				/*
				Zarby:
				vanilla values of link's house are ->
				ScrollY: 0A9A
				ScrollX: 0832

				PY: 0AE8
				PX: 08B8

				if you subtract these you get -134 and -78 

				Jared_Brain_: further testing by zarby revealed that these values are different for every entrance.
				completly centered is -120 and -80
				*/

				xScroll = (short) (playerX - 120); //134
				yScroll = (short) (playerY - 80); //78

				if (xScroll < mapx) { xScroll = (short) ((mapx)); }
				if (yScroll < mapy) { yScroll = (short) ((mapy)); }

				if (xScroll > mapx + large) { xScroll = (short) ((mapx) + large); }
				if (yScroll > (mapy + large) + 32) { yScroll = (short) (((mapy) + large) + 32); }

				cameraX = (short) (playerX + 0x07);
				cameraY = (short) (playerY + 0x1F);

				if (cameraX < mapx + 127) { cameraX = (short) (mapx + 127); }
				if (cameraY < mapy + 111) { cameraY = (short) (mapy + 111); }

				if (cameraX > mapx + 127 + large) { cameraX = (short) (mapx + 127 + large); }
				if (cameraY > mapy + 143 + large) { cameraY = (short) (mapy + 143 + large); }
			}

			short vramXScroll = (short) (xScroll - mapx);
			short vramYScroll = (short) (yScroll - mapy);

			vramLocation = (short) (((vramYScroll & 0xFFF0) << 3) | ((vramXScroll & 0xFFF0) >> 3));

			Console.WriteLine("Exit:      " + roomId + " MapId: " + mapid.ToString("X2") + " X: " + AreaX + " Y: " + AreaY);
		}


	}
}
