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
		private byte gridx, gridy;
		private const int Scale = 8;

		public byte GridX
		{
			get => gridx;
			set => gridy = value;
		}

		public byte GridY
		{
			get => gridy;
			set => gridy = value;
		}

		public int RealX
		{
			get => gridx * Scale;
			set => gridx = (byte) (value / Scale);
		}

		public int RealY
		{
			get => gridy * Scale;
			set => gridy = (byte) (value / Scale);
		}

		public byte ID => SecretType.ID;
		public int TypeID => SecretType.ID;

		public Rectangle SquareHitbox => new Rectangle(RealX, RealY, 16, 16);

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
