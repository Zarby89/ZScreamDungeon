using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public unsafe class DungeonSecret : IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IMultilayered
	{
		public byte X { get; set; } = 0;
		public byte Y { get; set; } = 0;
		public byte NX { get; set; }
		public byte NY { get; set; }
		public byte Layer { get; set; } = 0;

		public SecretItemType SecretType { get; set; }

		public byte[] Data
		{
			get
			{
				ushort xy = (ushort) ((Y << 6) | (X << 1) | (Layer << 13));
				return new byte[]
					{
						(byte) xy,
						(byte) (xy >> 8),
						SecretType.ID
					};
			}
		}

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
			throw new NotImplementedException();
		}
	}
}
