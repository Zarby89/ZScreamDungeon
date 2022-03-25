using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.Underworld
{
	[Serializable]
	public class DungeonSecret : IDungeonPlaceable, IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IMultilayered, IDrawableSprite, ITypeID
	{
		public byte GridX { get; set; } = 0;
		public byte GridY { get; set; } = 0;

		public byte ID => SecretType.ID;
		public int TypeID => SecretType.ID;

		public int RealX => NewX * 8;
		public int RealY => NewY * 8;
		public Rectangle OutlineBox => new Rectangle(RealX, RealY, 16, 16);

		private byte nx, ny;
		public byte NewX
		{
			get => nx;
			set => nx = value.Clamp(0, 63);
		}
		public byte NewY
		{
			get => ny;
			set => ny = value.Clamp(0, 63);
		}

		public RoomLayer Layer { get; set; } = RoomLayer.Layer1;

		public SecretItemType SecretType { get; set; }
		public string Name => SecretType.VanillaName;

		public DungeonSecret(SecretItemType s)
		{
			SecretType = s;
		}

		public void Draw(ZScreamer ZS)
		{
			SecretType.Draw(ZS, this);
		}

		public bool PointIsInHitbox(int x, int y)
		{
			return x >= (GridX * 8) && x <= (GridX * 8) + 16 &&
					y >= (GridY * 8) && y <= (GridY * 8) + 16;
		}

		public bool Equals(DungeonSecret s)
		{
			return GridX == s.GridX && GridY == s.GridY && SecretType.ID == s.SecretType.ID;
		}

		public byte[] GetByteData()
		{
			UWTilemapPosition.CreateLowAndHighBytesFromXYZ(GridX, GridY, (byte) Layer, out byte low, out byte high);
			return new byte[] { low, high, SecretType.ID };
			//ushort xy = (ushort) ((Y << 6) | (X << 1) | (Layer << 13));
			//return new byte[]
			//	{
			//		(byte) xy,
			//		(byte) (xy >> 8),
			//		SecretType.ID
			//	};

		}
	}
}
