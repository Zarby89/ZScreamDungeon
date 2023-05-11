using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	[Serializable]
	public class RoomPotSaveEditor
	{
		public byte gameX, gameY, id;
		public int x, y;
		public bool bg2 = false;
		public ushort roomMapId;
		public int uniqueID = 0;
		public bool deleted = false;
		public RoomPotSaveEditor(byte id, ushort roomMapId, int x, int y, bool bg2)
		{
			this.id = id;
			this.x = x;
			this.y = y;
			this.bg2 = bg2;
			this.roomMapId = roomMapId;

			int mapX = (roomMapId - ((roomMapId / 8) * 8));
			int mapY = ((roomMapId / 8));

			gameX = (byte) ((Math.Abs(x - (mapX * 512)) / 16));
			gameY = (byte) ((Math.Abs(y - (mapY * 512)) / 16));
			uniqueID = ROM.uniqueItemID++;
		}

		public void updateMapStuff(short mapId)
		{
			this.roomMapId = (ushort) mapId;

			if (mapId >= 64)
			{
				mapId -= 64;
			}

			int mapX = (mapId - ((mapId / 8) * 8));
			int mapY = ((mapId / 8));

			gameX = (byte) ((Math.Abs(x - (mapX * 512)) / 16));
			gameY = (byte) ((Math.Abs(y - (mapY * 512)) / 16));

			Console.WriteLine("Item:      " + id.ToString("X2") + " MapId: " + roomMapId.ToString("X2") + " X: " + gameX + " Y: " + gameY);
		}

		public RoomPotSaveEditor Copy()
		{
			return new RoomPotSaveEditor(this.id, this.roomMapId, this.x, this.y, this.bg2);
		}
	}
}
