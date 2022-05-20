using ZeldaFullEditor.View.Drawing;
using ZeldaFullEditor.View.UserInterface;

namespace ZeldaFullEditor.Modeling.Underworld
{
	[Serializable]
	public class DungeonSprite : IDungeonPlaceable, IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IMultilayered, IDrawableSprite, ITypeID, IHaveInfo
	{
		private const int Scale = 16;
		public byte GridX { get; set; }
		public byte GridY { get; set; }

		public int RealX
		{
			get => GridX * Scale;
			set => GridX = (byte) (value / Scale);
		}

		public int RealY
		{
			get => GridY * Scale;
			set => GridY = (byte) (value / Scale);
		}

		public ushort RoomID { get; set; } = 0;

		public Rectangle BoundingBox => new(RealX, RealY, 16, 16); // TODO

		public string Name => Species.VanillaName;
		public byte ID => Species.ID;
		public int TypeID => Species.ID;

		private byte nx, ny;
		public byte NewX
		{
			get => nx;
			set => nx = value.Clamp(0, 31);
		}
		public byte NewY
		{
			get => ny;
			set => ny = value.Clamp(0, 31);
		}

		public bool IsCurrentlyOverlord => Subtype.BitsAllSet(0x07);

		/// <summary>
		/// The intended type of the sprite or overlord.
		/// </summary>
		public SpriteType Species { get; }
		protected SpriteType stype { get; }
		protected OverlordType otype { get; }

		public byte Subtype { get; set; }

		public bool HasBadSubtype => IsCurrentlyOverlord ^ Species is OverlordType;

		/// <summary>
		/// The current type, dependent on subtype
		/// </summary>
		public SpriteType CurrentType => IsCurrentlyOverlord ? otype : stype;

		public RoomLayer Layer { get; set; } = RoomLayer.Layer1;

		public byte KeyDrop { get; set; } = 0;

		public DungeonSprite(SpriteType type)
		{
			Species = type;

			stype = type.IsOverlord ? SpriteType.GetTypeFromID(type.ID) : type;
			otype = (OverlordType) (type.IsOverlord ? type : OverlordType.GetTypeFromID(type.ID));

			Subtype = (byte) (type.IsOverlord ? 7 : 0);
		}

		public DungeonSprite Clone()
		{
			return new DungeonSprite(Species)
			{
				RoomID = RoomID,
				GridX = GridX,
				GridY = GridY,
				Layer = Layer,
				Subtype = Subtype,
				KeyDrop = KeyDrop
			};
		}
		public byte[] GetByteData()
		{
			var size = KeyDrop == 1 || KeyDrop == 2 ? 6 : 3;
			var ret = new byte[size];
			ret[0] = (byte) ((int) Layer << 7 | (Subtype & 0x18) << 2 | GridY);
			ret[1] = (byte) (Subtype << 5 | GridX);
			ret[2] = Species.ID;

			if (size == 6)
			{
				ret[3] = KeyDrop == 1 ? Constants.SmallKeyDropToken : Constants.BigKeyDropToken;
				ret[4] = 0x00;
				ret[5] = Constants.KeyDropID;
			}

			return ret;
		}
		public bool PointIsInHitbox(int x, int y)
		{
			throw new NotImplementedException();
		}

		public bool Equals(DungeonSprite s)
		{
			return GridX == s.GridX && GridY == s.GridY && ID == s.ID && Subtype == s.Subtype;
		}

		public void Draw(Artist art)
		{
			Species.Draw(art, this);

			switch (KeyDrop)
			{
				case 0:
					return; // nothing

				case 1:
					SpriteType.SpriteDraw_SmallKeyDrop(art, this);
					break;

				case 2:
					SpriteType.SpriteDraw_BigKeyDrop(art, this);
					break;

				default:
					SpriteType.SpriteDraw_GreenRupeeDrop(art, this);
					break;
			}
		}
	}

	public class SpritePreview : IDelegatedDraw, IDrawableSprite
	{
		public byte X { get; set; } = 0;
		public byte Y { get; set; } = 0;
		public int RealX => 16;
		public int RealY => 16;
		public byte ID => Species.ID;
		public SpriteType Species { get; }
		public string Name => Species.VanillaName;

		public SpritePreview(SpriteType type)
		{
			Species = type;
		}

		public void Draw(Artist art)
		{
			Species.Draw(art, this);
		}
	}
}
