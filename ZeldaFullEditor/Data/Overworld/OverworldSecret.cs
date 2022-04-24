﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data
{
	public unsafe class OverworldSecret : OverworldEntity, IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IDrawableSprite, IEquatable<OverworldSecret>
	{
		public byte ID => SecretType.ID;
		public int RealX { get; }
		public int RealY { get; }
		public SecretItemType SecretType { get; set; }
		public string Name => SecretType.VanillaName;

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

		public byte[] GetByteData()
		{
			throw new NotImplementedException();
		}

		internal object Clone()
		{
			return new OverworldSecret(SecretType);
		}
	}
}
