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
		public byte TargetEntranceID { get; set; }
		public bool IsPitEntrance { get; set; }

		// TODO make this based on map position and make deleted map position consistent
		public bool deleted { get; set; }

		public EntranceOWEditor(ushort x, ushort y, byte entranceId, byte mapId, ushort mapPos)
		{
			GlobalX = x;
			GlobalY = y;
			TargetEntranceID = entranceId;
			MapID = mapId;
			this.mapPos = mapPos;

			int mapX = mapId & 0x7;
			int mapY = mapId / 8;

			MapX = (byte) (Math.Abs(x - (mapX * 512)) / 16);
			MapY = (byte) (Math.Abs(y - (mapY * 512)) / 16);
		}

		public override bool PointIsInHitbox(int x, int y)
		{
			throw new NotImplementedException();
		}
	}
}
