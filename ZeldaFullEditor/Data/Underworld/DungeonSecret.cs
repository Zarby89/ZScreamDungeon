using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.Underworld
{
	public unsafe class DungeonSecret : DungeonPlaceable, IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IMultilayered, IDrawableSprite
	{
		public byte X { get; set; } = 0;
		public byte Y { get; set; } = 0;

		public byte ID => SecretType.ID;
		public int RealX => X;
		public int RealY => Y;


		private byte nx, ny;
		public byte NX
		{
			get => nx;
			set => nx = value.Clamp(0, 63);
		}
		public byte NY
		{
			get => ny;
			set => ny = value.Clamp(0, 63);
		}

		public byte Layer { get; set; } = 0;

		public SecretItemType SecretType { get; set; }
		public string Name => SecretType.VanillaName;

		public byte[] Data
		{
			get
			{
				UWTilemapPosition.CreateLowAndHighBytesFromXYZ(X, Y, Layer, out byte low, out byte high);
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

		public DungeonSecret(SecretItemType s)
		{
			SecretType = s;
		}

		public override void Draw(ZScreamer ZS)
		{
			SecretType.Draw(ZS, this);
		}

		public override bool PointIsInHitbox(int x, int y)
		{
			return x >= (X * 8) && x <= (X * 8) + 16 &&
					y >= (Y * 8) && y <= (Y * 8) + 16;
		}

		public bool Equals(DungeonSecret s)
		{
			return X == s.X && Y == s.Y && SecretType.ID == s.SecretType.ID;
		}
	}
}
