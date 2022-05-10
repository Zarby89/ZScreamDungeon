using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaFullEditor.Data.Underworld;

namespace ZeldaFullEditor.Data
{
	public class OverworldSprite : OverworldEntity, IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IDrawableSprite, IEquatable<OverworldSprite>
	{
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

		public void Draw(Artist art)
		{
			Species.Draw(art, this);
		}

		public byte[] GetByteData()
		{
			throw new NotImplementedException();
		}

		public override bool PointIsInHitbox(int x, int y)
		{
			return base.PointIsInHitbox(x, y);
		}

		public bool Equals(OverworldSprite s) => s switch
		{
			null => false,
			not null => MapX == s.MapX && MapY == s.MapY && ID == s.ID,
		};

		public override bool Equals(object obj) => Equals(obj as OverworldSprite);
	}
}
