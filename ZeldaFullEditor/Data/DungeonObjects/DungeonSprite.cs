using System;
using System.Collections.Generic;
using System.Drawing;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public unsafe class DungeonSprite : DungeonObject, IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IMultilayered
	{
		public byte X { get; set; } = 0;
		public byte Y { get; set; } = 0;

		private byte nx, ny;
		public byte NX
		{
			get => nx;
			set => nx = value.Clamp(0, 31);
		}
		public byte NY
		{
			get => ny;
			set => ny = value.Clamp(0, 31);
		}

		public byte Layer { get; set; } = 0;

		public byte KeyDrop { get; set; } = 0;

		public override TilesList Tiles { get; }

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

		public override byte[] Data => new byte[]
			{
				(byte) ((Layer << 7) | ((Subtype & 0x18) << 2) | Y),
				(byte) ((Subtype << 5) | X),
				Species.ID
			};


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

		public DungeonSprite(SpriteType type, bool onow = false, ushort screen = 0)
		{
			Species = type;

			stype = type.IsOverlord ? SpriteType.GetSpriteType(type.ID) : type;
			otype = (OverlordType) (type.IsOverlord ? type : OverlordType.GetOverlordType(type.ID));

			Subtype = (byte) (type.IsOverlord ? 7 : 0);
			ScreenID = screen;
			OnOverworld = onow;
		}

		public override void Draw(ZScreamer ZS)
		{
			Species.Draw(ZS, this);
		}

		public DungeonSprite Clone()
		{
			return new DungeonSprite(Species, OnOverworld, ScreenID)
			{
				X = X,
				Y = Y,
				Layer = Layer,
				Subtype = Subtype,
				KeyDrop = KeyDrop
			};
		}

		public override bool PointIsInHitbox(int x, int y)
		{
			throw new NotImplementedException();
		}
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
