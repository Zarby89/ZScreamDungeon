using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public abstract class OverworldDestination : OverworldEntity, IMouseCollidable, IFreelyPlaceable
	{
		public ushort ScrollX { get; set; }
		public ushort ScrollY { get; set; }
		public ushort CameraX { get; set; }
		public ushort CameraY { get; set; }
		public ushort VRAMBase { get; set; }

		public void UpdateMapID(byte mapid, Overworld ow)
		{
			base.UpdateMapID(mapid);

			int large = 256;

			if (mapid < 128)
			{
				large = ow.allmaps[mapid].largeMap ? 768 : 256;
			}

			mapid &= 0x3F;

			int mapx = (mapid & 7) << 9;
			int mapy = ((mapid & 56) << 6);
			ScrollX = (ushort) (GlobalX - 134);
			ScrollY = (ushort) (GlobalY - 78);

			if (ScrollX < mapx)
			{
				ScrollX = (ushort) mapx;
			}

			if (ScrollY < mapy)
			{
				ScrollY = (ushort) mapy;
			}

			if (ScrollX > mapx + large)
			{
				ScrollX = (ushort) (mapx + large);
			}
			if (ScrollY > (mapy + large) + 30)
			{
				ScrollY = (ushort) (((mapy) + large) + 30);
			}

			CameraX = GlobalX;
			CameraY = (ushort) (GlobalY + 19);

			if (CameraX < mapx + 127)
			{
				CameraX = (ushort) (mapx + 127);
			}
			if (CameraY < mapy + 111)
			{
				CameraY = (ushort) (mapy + 111);
			}

			if (CameraX > mapx + 127 + large)
			{
				CameraX = (ushort) (mapx + 127 + large);
			}
			if (CameraY > mapy + 143 + large)
			{
				CameraY = (ushort) (mapy + 143 + large);
			}

			ushort vramXScroll = (ushort) (ScrollX - mapx);
			ushort vramYScroll = (ushort) (ScrollY - mapy);

			VRAMBase = (ushort) (((vramYScroll & 0xFFF0) << 3) | ((vramXScroll & 0xFFF0) >> 3));
		}
	}
}
