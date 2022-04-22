using System;

namespace ZeldaFullEditor
{
	public abstract class OverworldEntity : IMouseCollidable, IFreelyPlaceable
	{
		public ushort GlobalX { get; set; }
		public ushort GlobalY { get; set; }
		public byte MapID { get; set; }
		public byte MapX { get; set; }
		public byte MapY { get; set; }

		public byte X { get; set; }
		public byte Y { get; set; }
		public byte NX { get; set; }
		public byte NY { get; set; }

		public ushort MapPos => (ushort) (((MapY << 6) | (MapX & 0x3F)) << 1);

		public virtual void UpdateMapID(byte mapid)
		{
			MapID = mapid;
			mapid &= 0x3F;

			MapX = (byte) (Math.Abs(GlobalX - (mapid & 0x7) << 9) >> 4);
			MapY = (byte) (Math.Abs(GlobalY - (mapid >> 3) << 9) >> 4);
		}

		public abstract bool PointIsInHitbox(int x, int y);
	}
}
