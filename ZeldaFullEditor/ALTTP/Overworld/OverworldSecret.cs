namespace ZeldaFullEditor.ALTTP.Overworld
{
	public class OverworldSecret : OverworldEntity, IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IDrawableSprite, IHaveInfo, ITypeID, IComparable<OverworldSecret>
	{
		public byte ID => SecretType?.ID ?? 0;
		public SecretItemType SecretType { get; set; }
		public override string Name => SecretType?.Name ?? "Secret";

		public int TypeID => ID;

		public OverworldSecret(SecretItemType s)
		{
			SecretType = s;
		}

		public void Draw(IDrawArt art)
		{
			SecretType.Draw(art, this);
		}

		public override bool PointIsInHitbox(int x, int y)
		{
			return base.PointIsInHitbox(x, y);
		}

		public byte[] GetByteData()
		{
			throw new NotImplementedException();
		}

		internal object Clone()
		{
			return new OverworldSecret(SecretType);
		}

		public int CompareTo(OverworldSecret other)
		{
			int ret = ID - other.ID;
			if (ret != 0)
			{
				return ret;
			}

			ret = MapX - other.MapX;
			if (ret != 0)
			{
				return ret;
			}

			return MapY - other.MapY;
		}
	}
}
