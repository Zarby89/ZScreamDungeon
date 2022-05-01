using System;
using System.Drawing;

namespace ZeldaFullEditor
{
	public abstract class OverworldEntity : IMouseCollidable, IFreelyPlaceable
	{
		private ushort globalx, globaly;
		private byte mapx, mapy;

		public Rectangle SquareHitbox => new Rectangle(GlobalX, GlobalY, 16, 16);

		public ushort GlobalX {
			get => globalx;
			set
			{
				globalx = value;
				RecalculateLocalFromGlobal();
			}
		}

		public ushort GlobalY {
			get => globaly;
			set
			{
				globaly = value;
				RecalculateLocalFromGlobal();
			}
		}

		public byte MapX {
			get => mapx;
			set
			{
				mapx = value;
				RecalculateGlobalFromLocal();
			}
		}
		
		public byte MapY {
			get => mapy;
			set
			{
				mapy = value;
				RecalculateGlobalFromLocal();
			}
		}
		public int RealX
		{
			get => GlobalX;
			set => GlobalX = (ushort) value;
		}

		public int RealY
		{
			get => GlobalY;
			set => GlobalY = (ushort) value;
		}

		private byte mapid;
		public byte MapID {
			get => mapid;
			set
			{
				mapid = value;
				RecalculateLocalFromGlobal();
			}
		}

		public byte GridX {
			get => MapX;
			set => MapX = value;
		}
		public byte GridY {
			get => MapY;
			set => MapY = value;
		}

		public ushort MapPos => (ushort) (((MapY << 6) | (MapX & 0x3F)) << 1);

		private void RecalculateLocalFromGlobal()
		{
			mapx = (byte) (Math.Abs(GlobalX - (MapID & 0x87) << 9) >> 4);
			mapy = (byte) (Math.Abs(GlobalY - (MapID & 0x38) << 6) >> 4);
		}

		private void RecalculateGlobalFromLocal()
		{
			globalx = (ushort) (((MapID & 0x7) * 512) + (mapx * 16));
			globaly = (ushort) (((MapID & 0x3F) / 8 * 512) + (mapy * 16));
		}

		public virtual bool PointIsInHitbox(int x, int y)
		{
			return x >= GlobalX && x < GlobalX + 16 && y >= GlobalY && y < GlobalY + 16;
		}

		public bool IsInThisWorld(Worldiness world)
		{
			int w = (int) world;
			return MapID >= w && MapID < 64 + w;
		}

		public virtual void SnapToGrid()
		{
			GlobalX &= 0xFFF0;
			GlobalY &= 0xFFF0;
		}
	}
}
