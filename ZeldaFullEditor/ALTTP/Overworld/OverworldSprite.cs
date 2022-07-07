namespace ZeldaFullEditor.ALTTP.Overworld;

public class OverworldSprite : OverworldEntity, IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IDrawableSprite, ITypeID, IHaveInfo, IComparable<OverworldSprite>
{
	public override string Name => Species.Name;
	public byte ID => Species.ID;
	public bool IsCurrentlyOverlord => ID > 0xF2;
	public int TypeID => ID;

	/// <summary>
	/// The intended type of the sprite or overlord.
	/// </summary>
	public SpriteType Species { get; set; }

	public OverworldSprite(SpriteType type, byte screen = 0)
	{
		Species = type;

		MapID = screen;
	}

	public void Draw(IDrawArt art)
	{
		Species.Draw(art, this);
	}

	public byte[] GetByteData()
	{
		return new byte[] { MapY, MapX, ID };
	}

	public override bool PointIsInHitbox(int x, int y)
	{
		return base.PointIsInHitbox(x, y);
	}
	public int CompareTo(OverworldSprite other)
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
