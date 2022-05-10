using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data
{
	public class OverworldSecret : OverworldEntity, IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IDrawableSprite, IEquatable<OverworldSecret>
	{
		public byte ID => SecretType?.ID ?? 0;
		public SecretItemType SecretType { get; set; }
		public string Name => SecretType?.VanillaName ?? "Secret";

		public OverworldSecret(SecretItemType s)
		{
			SecretType = s;
		}

		public void Draw(Artist art)
		{
			SecretType.Draw(art, this);
		}

		public override bool PointIsInHitbox(int x, int y)
		{
			return base.PointIsInHitbox(x, y);
		}

		public bool Equals(OverworldSecret other) => other switch
		{
			null => false,
			not null => ID == other.ID && MapX == other.MapX && MapY == other.MapY,
		};

		public override bool Equals(object obj) => Equals(obj as OverworldSecret);


		public override int GetHashCode()
		{
			throw new NotImplementedException();
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
