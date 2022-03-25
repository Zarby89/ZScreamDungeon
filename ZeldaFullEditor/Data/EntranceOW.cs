using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	[Serializable]
	public class EntranceOWEditor
	{
		public int x { get; set; }
		public int y { get; set; }
		public ushort mapPos { get; set; }
		public byte entranceId { get; set; }
		public byte AreaX { get; set; }
		public byte AreaY { get; set; }
		public ushort mapId { get; set; }
		public bool isHole = false;
		public bool deleted = false;

		// mapId might be useless but we will need it to check if the entrance is in the darkworld or lightworld
		public EntranceOWEditor(int x, int y, byte entranceId, ushort mapId, ushort mapPos)
		{
			this.x = x;
			this.y = y;
			this.entranceId = entranceId;
			this.mapId = mapId;
			this.mapPos = mapPos;

			int mapX = (mapId - ((mapId / 8) * 8));
			int mapY = (mapId / 8);

			AreaX = (byte) ((Math.Abs(x - (mapX * 512)) / 16));
			AreaY = (byte) ((Math.Abs(y - (mapY * 512)) / 16));
		}

		public EntranceOWEditor Copy()
		{
			return new EntranceOWEditor(this.x, this.y, this.entranceId, this.mapId, this.mapPos);
		}

		public void updateMapStuff(ushort mapId)
		{
			this.mapId = mapId;

			if (mapId >= 64)
			{
				mapId -= 64;
			}

			int mapX = (mapId - ((mapId / 8) * 8));
			int mapY = (mapId / 8);

			AreaX = (byte) ((Math.Abs(x - (mapX * 512)) / 16));
			AreaY = (byte) ((Math.Abs(y - (mapY * 512)) / 16));

			int mx = (mapId - ((mapId / 8) * 8));
			int my = (mapId / 8);

			byte xx = (byte) ((x - (mx * 512)) / 16);
			byte yy = (byte) ((y - (my * 512)) / 16);

			mapPos = (ushort) ((((AreaY) << 6) | (AreaX & 0x3F)) << 1);
		}
	}
}
