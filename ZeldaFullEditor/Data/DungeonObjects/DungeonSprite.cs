using System;
using System.Collections.Generic;
using System.Drawing;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public abstract unsafe class SomeSprite : DungeonObject, IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable
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

		public override TilesList Tiles { get; }

		public bool IsCurrentlyOverlord { get; protected set; }

		public abstract override byte[] Data { get; }

		public ushort ScreenID { get; set; }

		/// <summary>
		/// The intended type of the sprite or overlord.
		/// </summary>
		public SpriteType Species { get; }
		protected SpriteType stype { get; }
		protected OverlordType otype { get; }

		/// <summary>
		/// The current type, dependent on subtype
		/// </summary>
		public virtual SpriteType CurrentType => Species;

		public SomeSprite(SpriteType type, ushort screen = 0)
		{
			Species = type;

			stype = type.IsOverlord ? SpriteType.GetSpriteType(type.ID) : type;
			otype = (OverlordType) (type.IsOverlord ? type : OverlordType.GetOverlordType(type.ID));

			ScreenID = screen;
		}

		public override void Draw(ZScreamer ZS)
		{
			Species.Draw(ZS, this);
		}



		public override bool PointIsInHitbox(int x, int y)
		{
			throw new NotImplementedException();
		}
	}

	public unsafe class DungeonSprite : SomeSprite, IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable, IMultilayered
	{
		private byte subtype;
		public byte Subtype
		{
			get => subtype;

			set
			{
				subtype = value;
				IsCurrentlyOverlord = subtype.BitsAllSet(0x07);
			}
		}
		public bool HasBadSubtype => IsCurrentlyOverlord ^ (Species is OverlordType);

		public override SpriteType CurrentType => IsCurrentlyOverlord ? otype : stype;

		public byte Layer { get; set; } = 0;

		public byte KeyDrop { get; set; } = 0;

		public override byte[] Data
		{
			get
			{
				int size = (KeyDrop == 1 || KeyDrop == 2) ? 6 : 3;
				byte[] ret = new byte[size];
				ret[0] = (byte) ((Layer << 7) | ((Subtype & 0x18) << 2) | Y);
				ret[1] = (byte) ((Subtype << 5) | X);
				ret[2] = Species.ID;

				if (size == 6)
				{
					ret[3] = KeyDrop == 1 ? Constants.SmallKeyDropToken : Constants.BigKeyDropToken;
					ret[4] = 0x00;
					ret[5] = Constants.KeyDropID;
				}

				return ret;
			}
		}

		public DungeonSprite(SpriteType type, ushort screen = 0) : base(type, screen)
		{
			Subtype = (byte) (type.IsOverlord ? 7 : 0);
		}

		public DungeonSprite Clone()
		{
			return new DungeonSprite(Species, ScreenID)
			{
				X = X,
				Y = Y,
				Layer = Layer,
				Subtype = Subtype,
				KeyDrop = KeyDrop
			};
		}

		public override void Draw(ZScreamer ZS)
		{
			base.Draw(ZS);

			switch (KeyDrop)
			{
				case 0:
					return; // nothing

				case 1:
					SpriteType.SpriteDraw_SmallKeyDrop(ZS, this);
					break;

				case 2:
					SpriteType.SpriteDraw_BigKeyDrop(ZS, this);
					break;

				default:
					SpriteType.SpriteDraw_GreenRupeeDrop(ZS, this);
					break;
			}
		}
	}

	public class OverworldSprite : SomeSprite, IByteable, IFreelyPlaceable, IDelegatedDraw, IMouseCollidable
	{

		public override byte[] Data => throw new NotImplementedException();

		public OverworldSprite(SpriteType type, ushort screen = 0) : base(type, screen)
		{
			
		}

		public void UpdateMapID(ushort mapId)
		{
			ScreenID = mapId;

			if (mapId >= 64)
			{
				mapId -= 64;
			}

			X = (byte) ((map_x - ((mapId & 0x7) * 512)) / 16);
			Y = (byte) ((map_y - ((mapId / 8) * 512)) / 16);

		}
	}

	public class SpritePreview : SomeSprite
	{
		public SpritePreview(SpriteType type) : base(type, 0) { }

		public override byte[] Data => null;
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
