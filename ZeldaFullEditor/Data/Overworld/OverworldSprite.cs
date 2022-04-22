﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaFullEditor.Data.Underworld;

namespace ZeldaFullEditor.Data
{
	public class OverworldSprite : OverworldEntity, IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IEquatable<OverworldSprite>, IDrawableSprite
	{

		public int RealX { get; }
		public int RealY { get; }

		public byte[] Data => throw new NotImplementedException();
		public string Name => Species.VanillaName;
		public byte ID => Species.ID;

		public bool IsCurrentlyOverlord => ID > 0xF2;

		/// <summary>
		/// The intended type of the sprite or overlord.
		/// </summary>
		public SpriteType Species { get; set; }

		public OverworldSprite(SpriteType type, byte screen = 0)
		{
			Species = type;

			MapID = screen;
		}

		public void Draw(ZScreamer ZS)
		{
			Species.Draw(ZS, this);
		}



		public override bool PointIsInHitbox(int x, int y)
		{
			throw new NotImplementedException();
		}

		public bool Equals(OverworldSprite s)
		{
			return MapX == s.MapX && MapY == s.MapY && ID == s.ID;
		}
	}
}
