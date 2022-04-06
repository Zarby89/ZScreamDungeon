namespace ZeldaFullEditor.Data.Sprites
{
	public unsafe class Sprite
	{
		public byte X { get; set; } = 0;
		public byte Y { get; set; } = 0;
		public byte Layer { get; set; } = 0;

		public byte KeyDrop { get; set; } = 0;

		private byte subtype;
		public byte Subtype {
			get => subtype;

			set
			{
				subtype = value;
				IsCurrentlyOverlord = subtype.BitsAllSet(0x07);
			}
		}

		public bool IsCurrentlyOverlord { get; private set; }

		public bool HasBadSubtype
		{
			get => IsCurrentlyOverlord ^ (Species is OverlordType);
		}

		public ushort ScreenID { get; set; }
		public bool OnOverworld { get; set; }

		/// <summary>
		/// The intended type of the sprite or overlord.
		/// </summary>
		public SpriteType Species { get; }
		private SpriteType stype { get; }
		private OverlordType otype { get; }

		/// <summary>
		/// The current type, dependent on subtype
		/// </summary>
		public SpriteType CurrentType
		{
			get => IsCurrentlyOverlord ? otype : stype;
		}

		public Sprite(SpriteType type, bool onow = false, ushort screen = 0)
		{
			Species = type;

			stype = type.IsOverlord ? SpriteType.GetSpriteType(type.ID) : type;
			otype = (OverlordType) (type.IsOverlord ? type : OverlordType.GetOverlordType(type.ID));

			Subtype = (byte) (type.IsOverlord ? 7 : 0);
			ScreenID = screen;
			OnOverworld = onow;
		}

		public void Draw(ZScreamer ZS)
		{
			Species.Draw(ZS, this);
		}

		public Sprite Clone()
		{
			return new Sprite(Species, OnOverworld, ScreenID)
			{
				X = X,
				Y = Y,
				Layer = Layer,
				Subtype = Subtype,
				KeyDrop = KeyDrop
			};
		}
	}

	public partial class SpriteType
	{
		public string VanillaName { get; }
		public byte ID { get; }
		public bool IsOverlord { get; }

		public DrawSprite Draw { get; }

		protected SpriteType(byte id, DrawSprite d, SpriteCategory[] categories, byte[] gsets, bool overlord = false)
		{
			Draw = d;
			ID = id;

			// intentionally doing this stupid shit because it looks funny
			VanillaName = (IsOverlord = overlord)
				? "L" // DefaultEntities.ListOfOverlords[id].Name
				: DefaultEntities.ListOfSprites[id].Name;
		}
	}

	public partial class OverlordType : SpriteType
	{
		private OverlordType(byte id, DrawSprite d, SpriteCategory[] categories, byte[] gsets)
			: base(id, d, categories, gsets, true) { }
	}


	public enum SpriteCategory
	{
		Enemy,
		NPC,
		Inanimate,
		Boss,
		Collectible,
		OverworldOnly,
		UnderworldOnly,
		PlacementLimited,
		NotIntendedToBePlacedDirectly,
	}
}
