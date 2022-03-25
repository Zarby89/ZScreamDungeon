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
		public int RealX { get; }
		public int RealY { get; }

		public byte GridX { get; set; }
		public byte GridY { get; set; }
		public byte NewX { get; set; }
		public byte NewY { get; set; }

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
