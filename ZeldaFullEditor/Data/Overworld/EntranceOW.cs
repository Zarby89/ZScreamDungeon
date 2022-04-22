using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	[Serializable]
	public class EntranceOWEditor : OverworldEntity, IFreelyPlaceable, IMouseCollidable
	{
		public ushort mapPos { get; set; }
		public byte entranceId { get; set; }
		public bool isHole = false;
		public bool deleted = false;

		public EntranceOWEditor(ushort x, ushort y, byte entranceId, byte mapId, ushort mapPos)
		{
			this.GlobalX = x;
			this.GlobalY = y;
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
			return new EntranceOWEditor(this.GlobalX, this.GlobalY, this.entranceId, this.MapID, this.mapPos);
		}

		public override bool PointIsInHitbox(int x, int y)
		{
			throw new NotImplementedException();
		}
	}
}
