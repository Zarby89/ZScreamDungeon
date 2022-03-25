﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public class TransportOW
	{
		public ushort vramLocation { get; set; }
		public ushort xScroll { get; set; }
		public ushort yScroll { get; set; }
		public ushort playerX { get; set; }
		public ushort playerY { get; set; }
		public ushort cameraX { get; set; }
		public ushort cameraY { get; set; }
		public ushort mapId { get; set; }
		public ushort whirlpoolPos { get; set; }

		public byte unk1 { get; set; }
		public byte unk2 { get; set; }
		public byte AreaX { get; set; }
		public byte AreaY { get; set; }

		public bool isAutomatic = true;

		public TransportOW(byte mapId, ushort vramLocation, ushort yScroll, ushort xScroll,
			ushort playerY, ushort playerX, ushort cameraY, ushort cameraX,
			byte unk1, byte unk2, ushort whirlpoolPos)
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

			int mapX = (mapId - ((mapId / 8) * 8));
			int mapY = (mapId / 8);

			AreaX = (byte) ((Math.Abs(playerX - (mapX * 512)) / 16));
			AreaY = (byte) ((Math.Abs(playerY - (mapY * 512)) / 16));
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
				xScroll = (ushort) (playerX - 134);
				yScroll = (ushort) (playerY - 78);

				if (xScroll < mapx)
				{
					xScroll = (ushort) ((mapx));
				}
				if (yScroll < mapy)
				{
					yScroll = (ushort) ((mapy));
				}

				if (xScroll > mapx + large)
				{
					xScroll = (ushort) ((mapx) + large);
				}
				if (yScroll > (mapy + large) + 30)
				{
					yScroll = (ushort) (((mapy) + large) + 30);
				}

				cameraX = playerX;
				cameraY = (ushort) (playerY + 19);

				if (cameraX < mapx + 127)
				{
					cameraX = (ushort) (mapx + 127);
				}
				if (cameraY < mapy + 111)
				{
					cameraY = (ushort) (mapy + 111);
				}

				if (cameraX > mapx + 127 + large)
				{
					cameraX = (ushort) (mapx + 127 + large);
				}
				if (cameraY > mapy + 143 + large)
				{
					cameraY = (ushort) (mapy + 143 + large);
				}
			}

			ushort vramXScroll = (ushort) (xScroll - mapx);
			ushort vramYScroll = (ushort) (yScroll - mapy);

			vramLocation = (ushort) (((vramYScroll & 0xFFF0) << 3) | ((vramXScroll & 0xFFF0) >> 3));
		}
	}
}
