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

		public override void SnapToGrid()
		{
			GlobalX &= 0xFFF8;
			GlobalY &= 0xFFF8;
		}

		public void UpdateMapProperties(bool isLarge)
		{
			int large = 256;

			if (MapID < 128)
			{
				large = isLarge ? 768 : 256;
			}

			int mapx = (MapID & 7) << 9;
			int mapy = ((MapID & 0x38) << 6);
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
			if (ScrollY > (mapy + large + 30))
			{
				ScrollY = (ushort) (mapy + large + 30);
			}

			CameraX = GlobalX;
			CameraY = (ushort) (GlobalY + 19);

			if (CameraX < mapx + 127)
			{
				CameraX = (ushort) (mapx + 127);
			}
			else if (CameraX > mapx + 127 + large)
			{
				CameraX = (ushort) (mapx + 127 + large);
			}

			if (CameraY < mapy + 111)
			{
				CameraY = (ushort) (mapy + 111);
			}
			else if (CameraY > mapy + 143 + large)
			{
				CameraY = (ushort) (mapy + 143 + large);
			}

			ushort vramXScroll = (ushort) (ScrollX - mapx);
			ushort vramYScroll = (ushort) (ScrollY - mapy);

			VRAMBase = (ushort) (((vramYScroll & 0xFFF0) << 3) | ((vramXScroll & 0xFFF0) >> 3));
		}
	}
}
