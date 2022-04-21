using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	[Serializable]
	public class EntranceOWEditor : Data.OverworldEntity
	{
		public int x { get; set; }
		public int y { get; set; }
		public ushort mapPos { get; set; }
		public byte entranceId { get; set; }
		public byte MapX { get; set; }
		public byte MapY { get; set; }
		public byte MapID { get; set; }
		public bool isHole = false;
		public bool deleted = false;

		// mapId might be useless but we will need it to check if the entrance is in the darkworld or lightworld
		public EntranceOWEditor(int x, int y, byte entranceId, byte mapId, ushort mapPos)
		{
			this.x = x;
			this.y = y;
			this.entranceId = entranceId;
			this.MapID = mapId;
			this.mapPos = mapPos;

			int mapX = (mapId - ((mapId / 8) * 8));
			int mapY = (mapId / 8);

			MapX = (byte) ((Math.Abs(x - (mapX * 512)) / 16));
			MapY = (byte) ((Math.Abs(y - (mapY * 512)) / 16));
		}

		public EntranceOWEditor Copy()
		{
			return new EntranceOWEditor(this.x, this.y, this.entranceId, this.MapID, this.mapPos);
		}

		public void UpdateMapID(byte mapId)
		{
			MapID = mapId;

			if (mapId >= 64)
			{
				mapId -= 64;
			}

			int mapX = (mapId - ((mapId / 8) * 8));
			int mapY = (mapId / 8);

			MapX = (byte) ((Math.Abs(x - (mapX * 512)) / 16));
			MapY = (byte) ((Math.Abs(y - (mapY * 512)) / 16));

			int mx = (mapId - ((mapId / 8) * 8));
			int my = (mapId / 8);

			byte xx = (byte) ((x - (mx * 512)) / 16);
			byte yy = (byte) ((y - (my * 512)) / 16);

			mapPos = (ushort) ((((MapY) << 6) | (MapX & 0x3F)) << 1);
		}
	}
}
