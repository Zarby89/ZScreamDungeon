using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data
{
	public unsafe class OverworldSecret : OverworldEntity, IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IDrawableSprite, IEquatable<OverworldSecret>
	{
		public byte ID => SecretType.ID;
		public byte X { get; set; }
		public byte Y { get; set; }
		public byte NX { get; set; }
		public byte NY { get; set; }
		public int RealX { get; }
		public int RealY { get; }
		public SecretItemType SecretType { get; set; }
		public string Name => SecretType.VanillaName;

		public byte[] Data => throw new NotImplementedException();

		/*
		 * 

			int mapX = (roomMapId - ((roomMapId / 8) * 8));
			int mapY = ((roomMapId / 8));

			gameX = (byte) ((Math.Abs(x - (mapX * 512)) / 16));
			gameY = (byte) ((Math.Abs(y - (mapY * 512)) / 16));
		 */
		public OverworldSecret(SecretItemType s)
		{
			SecretType = s;
		}

		public void Draw(ZScreamer ZS)
		{
			throw new NotImplementedException();
		}

		public override bool PointIsInHitbox(int x, int y)
		{
			throw new NotImplementedException();
		}

		public bool Equals(OverworldSecret other)
		{
			return ID == other.ID && MapX == other.MapX && MapY == other.MapY;
		}
	}
}
