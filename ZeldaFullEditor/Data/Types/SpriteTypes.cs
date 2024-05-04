using System.Collections.Immutable;
using ZeldaFullEditor.Data;
using ZeldaFullEditor.Data.Underworld;

namespace ZeldaFullEditor.Data
{
	public partial class SpriteType : IEntityType<SpriteType>
	{
		public string VanillaName { get; }
		public byte ID { get; }
		public bool IsOverlord { get; }

		public DrawSprite Draw { get; }
		public ImmutableArray<SpriteCategory> Categories { get; }
		public ImmutableArray<byte> PrettyTileSets { get; }

		protected SpriteType(byte id, DrawSprite d, SpriteCategory[] categories, byte[] gsets, bool overlord = false)
		{
			Draw = d;
			ID = id;

			Categories = categories.ToImmutableArray();
			PrettyTileSets = gsets.ToImmutableArray();

			// intentionally doing this stupid shit because it looks funny
			VanillaName = (IsOverlord = overlord)
				? "L" // DefaultEntities.ListOfOverlords[id].Name
				: DefaultEntities.ListOfSprites[id].Name;
		}

		public static readonly SpriteType Sprite00 = new SpriteType(0x00, SpriteDraw_Sprite00,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite01 = new SpriteType(0x01, SpriteDraw_Sprite01,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite02 = new SpriteType(0x02, SpriteDraw_Sprite02,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite03 = new SpriteType(0x03, SpriteDraw_Sprite03,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite04 = new SpriteType(0x04, SpriteDraw_Sprite04,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite05 = new SpriteType(0x05, SpriteDraw_Sprite05,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite06 = new SpriteType(0x06, SpriteDraw_Sprite06,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite07 = new SpriteType(0x07, SpriteDraw_Sprite07,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite08 = new SpriteType(0x08, SpriteDraw_Sprite08,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite09 = new SpriteType(0x09, SpriteDraw_Sprite09,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite0A = new SpriteType(0x0A, SpriteDraw_Sprite0A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite0B = new SpriteType(0x0B, SpriteDraw_Sprite0B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite0C = new SpriteType(0x0C, SpriteDraw_Sprite0C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite0D = new SpriteType(0x0D, SpriteDraw_Sprite0D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite0E = new SpriteType(0x0E, SpriteDraw_Sprite0E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite0F = new SpriteType(0x0F, SpriteDraw_Sprite0F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite10 = new SpriteType(0x10, SpriteDraw_Sprite10,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite11 = new SpriteType(0x11, SpriteDraw_Sprite11,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite12 = new SpriteType(0x12, SpriteDraw_Sprite12,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite13 = new SpriteType(0x13, SpriteDraw_Sprite13,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite14 = new SpriteType(0x14, SpriteDraw_Sprite14,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite15 = new SpriteType(0x15, SpriteDraw_Sprite15,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite16 = new SpriteType(0x16, SpriteDraw_Sprite16,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite17 = new SpriteType(0x17, SpriteDraw_Sprite17,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite18 = new SpriteType(0x18, SpriteDraw_Sprite18,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite19 = new SpriteType(0x19, SpriteDraw_Sprite19,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite1A = new SpriteType(0x1A, SpriteDraw_Sprite1A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite1B = new SpriteType(0x1B, SpriteDraw_Sprite1B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite1C = new SpriteType(0x1C, SpriteDraw_Sprite1C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite1D = new SpriteType(0x1D, SpriteDraw_Sprite1D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite1E = new SpriteType(0x1E, SpriteDraw_Sprite1E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite1F = new SpriteType(0x1F, SpriteDraw_Sprite1F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite20 = new SpriteType(0x20, SpriteDraw_Sprite20,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite21 = new SpriteType(0x21, SpriteDraw_Sprite21,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite22 = new SpriteType(0x22, SpriteDraw_Sprite22,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite23 = new SpriteType(0x23, SpriteDraw_Sprite23,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite24 = new SpriteType(0x24, SpriteDraw_Sprite24,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite25 = new SpriteType(0x25, SpriteDraw_Sprite25,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite26 = new SpriteType(0x26, SpriteDraw_Sprite26,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite27 = new SpriteType(0x27, SpriteDraw_Sprite27,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite28 = new SpriteType(0x28, SpriteDraw_Sprite28,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite29 = new SpriteType(0x29, SpriteDraw_Sprite29,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite2A = new SpriteType(0x2A, SpriteDraw_Sprite2A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite2B = new SpriteType(0x2B, SpriteDraw_Sprite2B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite2C = new SpriteType(0x2C, SpriteDraw_Sprite2C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite2D = new SpriteType(0x2D, SpriteDraw_Sprite2D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite2E = new SpriteType(0x2E, SpriteDraw_Sprite2E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite2F = new SpriteType(0x2F, SpriteDraw_Sprite2F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite30 = new SpriteType(0x30, SpriteDraw_Sprite30,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite31 = new SpriteType(0x31, SpriteDraw_Sprite31,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite32 = new SpriteType(0x32, SpriteDraw_Sprite32,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite33 = new SpriteType(0x33, SpriteDraw_Sprite33,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite34 = new SpriteType(0x34, SpriteDraw_Sprite34,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite35 = new SpriteType(0x35, SpriteDraw_Sprite35,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite36 = new SpriteType(0x36, SpriteDraw_Sprite36,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite37 = new SpriteType(0x37, SpriteDraw_Sprite37,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite38 = new SpriteType(0x38, SpriteDraw_Sprite38,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite39 = new SpriteType(0x39, SpriteDraw_Sprite39,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite3A = new SpriteType(0x3A, SpriteDraw_Sprite3A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite3B = new SpriteType(0x3B, SpriteDraw_Sprite3B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite3C = new SpriteType(0x3C, SpriteDraw_Sprite3C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite3D = new SpriteType(0x3D, SpriteDraw_Sprite3D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite3E = new SpriteType(0x3E, SpriteDraw_Sprite3E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite3F = new SpriteType(0x3F, SpriteDraw_Sprite3F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite40 = new SpriteType(0x40, SpriteDraw_Sprite40,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite41 = new SpriteType(0x41, SpriteDraw_Sprite41,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite42 = new SpriteType(0x42, SpriteDraw_Sprite42,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite43 = new SpriteType(0x43, SpriteDraw_Sprite43,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite44 = new SpriteType(0x44, SpriteDraw_Sprite44,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite45 = new SpriteType(0x45, SpriteDraw_Sprite45,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite46 = new SpriteType(0x46, SpriteDraw_Sprite46,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite47 = new SpriteType(0x47, SpriteDraw_Sprite47,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite48 = new SpriteType(0x48, SpriteDraw_Sprite48,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite49 = new SpriteType(0x49, SpriteDraw_Sprite49,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite4A = new SpriteType(0x4A, SpriteDraw_Sprite4A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite4B = new SpriteType(0x4B, SpriteDraw_Sprite4B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite4C = new SpriteType(0x4C, SpriteDraw_Sprite4C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite4D = new SpriteType(0x4D, SpriteDraw_Sprite4D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite4E = new SpriteType(0x4E, SpriteDraw_Sprite4E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite4F = new SpriteType(0x4F, SpriteDraw_Sprite4F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite50 = new SpriteType(0x50, SpriteDraw_Sprite50,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite51 = new SpriteType(0x51, SpriteDraw_Sprite51,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite52 = new SpriteType(0x52, SpriteDraw_Sprite52,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite53 = new SpriteType(0x53, SpriteDraw_Sprite53,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite54 = new SpriteType(0x54, SpriteDraw_Sprite54,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite55 = new SpriteType(0x55, SpriteDraw_Sprite55,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite56 = new SpriteType(0x56, SpriteDraw_Sprite56,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite57 = new SpriteType(0x57, SpriteDraw_Sprite57,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite58 = new SpriteType(0x58, SpriteDraw_Sprite58,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite59 = new SpriteType(0x59, SpriteDraw_Sprite59,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite5A = new SpriteType(0x5A, SpriteDraw_Sprite5A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite5B = new SpriteType(0x5B, SpriteDraw_Sprite5B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite5C = new SpriteType(0x5C, SpriteDraw_Sprite5C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite5D = new SpriteType(0x5D, SpriteDraw_Sprite5D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite5E = new SpriteType(0x5E, SpriteDraw_Sprite5E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite5F = new SpriteType(0x5F, SpriteDraw_Sprite5F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite60 = new SpriteType(0x60, SpriteDraw_Sprite60,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite61 = new SpriteType(0x61, SpriteDraw_Sprite61,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite62 = new SpriteType(0x62, SpriteDraw_Sprite62,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite63 = new SpriteType(0x63, SpriteDraw_Sprite63,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite64 = new SpriteType(0x64, SpriteDraw_Sprite64,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite65 = new SpriteType(0x65, SpriteDraw_Sprite65,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite66 = new SpriteType(0x66, SpriteDraw_Sprite66,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite67 = new SpriteType(0x67, SpriteDraw_Sprite67,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite68 = new SpriteType(0x68, SpriteDraw_Sprite68,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite69 = new SpriteType(0x69, SpriteDraw_Sprite69,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite6A = new SpriteType(0x6A, SpriteDraw_Sprite6A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite6B = new SpriteType(0x6B, SpriteDraw_Sprite6B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite6C = new SpriteType(0x6C, SpriteDraw_Sprite6C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite6D = new SpriteType(0x6D, SpriteDraw_Sprite6D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite6E = new SpriteType(0x6E, SpriteDraw_Sprite6E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite6F = new SpriteType(0x6F, SpriteDraw_Sprite6F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite70 = new SpriteType(0x70, SpriteDraw_Sprite70,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite71 = new SpriteType(0x71, SpriteDraw_Sprite71,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite72 = new SpriteType(0x72, SpriteDraw_Sprite72,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite73 = new SpriteType(0x73, SpriteDraw_Sprite73,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite74 = new SpriteType(0x74, SpriteDraw_Sprite74,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite75 = new SpriteType(0x75, SpriteDraw_Sprite75,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite76 = new SpriteType(0x76, SpriteDraw_Sprite76,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite77 = new SpriteType(0x77, SpriteDraw_Sprite77,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite78 = new SpriteType(0x78, SpriteDraw_Sprite78,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite79 = new SpriteType(0x79, SpriteDraw_Sprite79,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite7A = new SpriteType(0x7A, SpriteDraw_Sprite7A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite7B = new SpriteType(0x7B, SpriteDraw_Sprite7B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite7C = new SpriteType(0x7C, SpriteDraw_Sprite7C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite7D = new SpriteType(0x7D, SpriteDraw_Sprite7D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite7E = new SpriteType(0x7E, SpriteDraw_Sprite7E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite7F = new SpriteType(0x7F, SpriteDraw_Sprite7F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite80 = new SpriteType(0x80, SpriteDraw_Sprite80,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite81 = new SpriteType(0x81, SpriteDraw_Sprite81,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite82 = new SpriteType(0x82, SpriteDraw_Sprite82,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite83 = new SpriteType(0x83, SpriteDraw_Sprite83,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite84 = new SpriteType(0x84, SpriteDraw_Sprite84,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite85 = new SpriteType(0x85, SpriteDraw_Sprite85,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite86 = new SpriteType(0x86, SpriteDraw_Sprite86,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite87 = new SpriteType(0x87, SpriteDraw_Sprite87,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite88 = new SpriteType(0x88, SpriteDraw_Sprite88,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite89 = new SpriteType(0x89, SpriteDraw_Sprite89,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite8A = new SpriteType(0x8A, SpriteDraw_Sprite8A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite8B = new SpriteType(0x8B, SpriteDraw_Sprite8B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite8C = new SpriteType(0x8C, SpriteDraw_Sprite8C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite8D = new SpriteType(0x8D, SpriteDraw_Sprite8D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite8E = new SpriteType(0x8E, SpriteDraw_Sprite8E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite8F = new SpriteType(0x8F, SpriteDraw_Sprite8F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite90 = new SpriteType(0x90, SpriteDraw_Sprite90,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite91 = new SpriteType(0x91, SpriteDraw_Sprite91,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite92 = new SpriteType(0x92, SpriteDraw_Sprite92,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite93 = new SpriteType(0x93, SpriteDraw_Sprite93,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite94 = new SpriteType(0x94, SpriteDraw_Sprite94,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite95 = new SpriteType(0x95, SpriteDraw_Sprite95,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite96 = new SpriteType(0x96, SpriteDraw_Sprite96,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite97 = new SpriteType(0x97, SpriteDraw_Sprite97,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite98 = new SpriteType(0x98, SpriteDraw_Sprite98,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite99 = new SpriteType(0x99, SpriteDraw_Sprite99,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite9A = new SpriteType(0x9A, SpriteDraw_Sprite9A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite9B = new SpriteType(0x9B, SpriteDraw_Sprite9B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite9C = new SpriteType(0x9C, SpriteDraw_Sprite9C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite9D = new SpriteType(0x9D, SpriteDraw_Sprite9D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite9E = new SpriteType(0x9E, SpriteDraw_Sprite9E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite9F = new SpriteType(0x9F, SpriteDraw_Sprite9F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA0 = new SpriteType(0xA0, SpriteDraw_SpriteA0,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA1 = new SpriteType(0xA1, SpriteDraw_SpriteA1,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA2 = new SpriteType(0xA2, SpriteDraw_SpriteA2,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA3 = new SpriteType(0xA3, SpriteDraw_SpriteA3,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA4 = new SpriteType(0xA4, SpriteDraw_SpriteA4,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA5 = new SpriteType(0xA5, SpriteDraw_SpriteA5,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA6 = new SpriteType(0xA6, SpriteDraw_SpriteA6,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA7 = new SpriteType(0xA7, SpriteDraw_SpriteA7,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA8 = new SpriteType(0xA8, SpriteDraw_SpriteA8,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA9 = new SpriteType(0xA9, SpriteDraw_SpriteA9,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteAA = new SpriteType(0xAA, SpriteDraw_SpriteAA,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteAB = new SpriteType(0xAB, SpriteDraw_SpriteAB,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteAC = new SpriteType(0xAC, SpriteDraw_SpriteAC,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteAD = new SpriteType(0xAD, SpriteDraw_SpriteAD,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteAE = new SpriteType(0xAE, SpriteDraw_SpriteAE,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteAF = new SpriteType(0xAF, SpriteDraw_SpriteAF,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB0 = new SpriteType(0xB0, SpriteDraw_SpriteB0,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB1 = new SpriteType(0xB1, SpriteDraw_SpriteB1,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB2 = new SpriteType(0xB2, SpriteDraw_SpriteB2,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB3 = new SpriteType(0xB3, SpriteDraw_SpriteB3,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB4 = new SpriteType(0xB4, SpriteDraw_SpriteB4,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB5 = new SpriteType(0xB5, SpriteDraw_SpriteB5,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB6 = new SpriteType(0xB6, SpriteDraw_SpriteB6,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB7 = new SpriteType(0xB7, SpriteDraw_SpriteB7,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB8 = new SpriteType(0xB8, SpriteDraw_SpriteB8,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB9 = new SpriteType(0xB9, SpriteDraw_SpriteB9,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteBA = new SpriteType(0xBA, SpriteDraw_SpriteBA,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteBB = new SpriteType(0xBB, SpriteDraw_SpriteBB,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteBC = new SpriteType(0xBC, SpriteDraw_SpriteBC,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteBD = new SpriteType(0xBD, SpriteDraw_SpriteBD,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteBE = new SpriteType(0xBE, SpriteDraw_SpriteBE,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteBF = new SpriteType(0xBF, SpriteDraw_SpriteBF,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC0 = new SpriteType(0xC0, SpriteDraw_SpriteC0,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC1 = new SpriteType(0xC1, SpriteDraw_SpriteC1,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC2 = new SpriteType(0xC2, SpriteDraw_SpriteC2,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC3 = new SpriteType(0xC3, SpriteDraw_SpriteC3,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC4 = new SpriteType(0xC4, SpriteDraw_SpriteC4,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC5 = new SpriteType(0xC5, SpriteDraw_SpriteC5,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC6 = new SpriteType(0xC6, SpriteDraw_SpriteC6,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC7 = new SpriteType(0xC7, SpriteDraw_SpriteC7,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC8 = new SpriteType(0xC8, SpriteDraw_SpriteC8,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC9 = new SpriteType(0xC9, SpriteDraw_SpriteC9,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteCA = new SpriteType(0xCA, SpriteDraw_SpriteCA,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteCB = new SpriteType(0xCB, SpriteDraw_SpriteCB,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteCC = new SpriteType(0xCC, SpriteDraw_SpriteCC,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteCD = new SpriteType(0xCD, SpriteDraw_SpriteCD,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteCE = new SpriteType(0xCE, SpriteDraw_SpriteCE,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteCF = new SpriteType(0xCF, SpriteDraw_SpriteCF,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD0 = new SpriteType(0xD0, SpriteDraw_SpriteD0,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD1 = new SpriteType(0xD1, SpriteDraw_SpriteD1,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD2 = new SpriteType(0xD2, SpriteDraw_SpriteD2,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD3 = new SpriteType(0xD3, SpriteDraw_SpriteD3,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD4 = new SpriteType(0xD4, SpriteDraw_SpriteD4,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD5 = new SpriteType(0xD5, SpriteDraw_SpriteD5,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD6 = new SpriteType(0xD6, SpriteDraw_SpriteD6,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD7 = new SpriteType(0xD7, SpriteDraw_SpriteD7,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD8 = new SpriteType(0xD8, SpriteDraw_SpriteD8,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD9 = new SpriteType(0xD9, SpriteDraw_SpriteD9,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteDA = new SpriteType(0xDA, SpriteDraw_SpriteDA,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteDB = new SpriteType(0xDB, SpriteDraw_SpriteDB,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteDC = new SpriteType(0xDC, SpriteDraw_SpriteDC,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteDD = new SpriteType(0xDD, SpriteDraw_SpriteDD,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteDE = new SpriteType(0xDE, SpriteDraw_SpriteDE,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteDF = new SpriteType(0xDF, SpriteDraw_SpriteDF,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE0 = new SpriteType(0xE0, SpriteDraw_SpriteE0,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE1 = new SpriteType(0xE1, SpriteDraw_SpriteE1,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE2 = new SpriteType(0xE2, SpriteDraw_SpriteE2,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE3 = new SpriteType(0xE3, SpriteDraw_SpriteE3,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE4 = new SpriteType(0xE4, SpriteDraw_SpriteE4,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE5 = new SpriteType(0xE5, SpriteDraw_SpriteE5,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE6 = new SpriteType(0xE6, SpriteDraw_SpriteE6,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE7 = new SpriteType(0xE7, SpriteDraw_SpriteE7,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE8 = new SpriteType(0xE8, SpriteDraw_SpriteE8,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE9 = new SpriteType(0xE9, SpriteDraw_SpriteE9,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteEA = new SpriteType(0xEA, SpriteDraw_SpriteEA,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteEB = new SpriteType(0xEB, SpriteDraw_SpriteEB,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteEC = new SpriteType(0xEC, SpriteDraw_SpriteEC,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteED = new SpriteType(0xED, SpriteDraw_SpriteED,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteEE = new SpriteType(0xEE, SpriteDraw_SpriteEE,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteEF = new SpriteType(0xEF, SpriteDraw_SpriteEF,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteF0 = new SpriteType(0xF0, SpriteDraw_SpriteF0,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteF1 = new SpriteType(0xF1, SpriteDraw_SpriteF1,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteF2 = new SpriteType(0xF2, SpriteDraw_SpriteF2,
			new SpriteCategory[] { },
			new byte[] { });

		public static SpriteType GetTypeFromID(int b)
		{
			switch (b)
			{
				case 0x00: return Sprite00;
				case 0x01: return Sprite01;
				case 0x02: return Sprite02;
				case 0x03: return Sprite03;
				case 0x04: return Sprite04;
				case 0x05: return Sprite05;
				case 0x06: return Sprite06;
				case 0x07: return Sprite07;
				case 0x08: return Sprite08;
				case 0x09: return Sprite09;
				case 0x0A: return Sprite0A;
				case 0x0B: return Sprite0B;
				case 0x0C: return Sprite0C;
				case 0x0D: return Sprite0D;
				case 0x0E: return Sprite0E;
				case 0x0F: return Sprite0F;
				case 0x10: return Sprite10;
				case 0x11: return Sprite11;
				case 0x12: return Sprite12;
				case 0x13: return Sprite13;
				case 0x14: return Sprite14;
				case 0x15: return Sprite15;
				case 0x16: return Sprite16;
				case 0x17: return Sprite17;
				case 0x18: return Sprite18;
				case 0x19: return Sprite19;
				case 0x1A: return Sprite1A;
				case 0x1B: return Sprite1B;
				case 0x1C: return Sprite1C;
				case 0x1D: return Sprite1D;
				case 0x1E: return Sprite1E;
				case 0x1F: return Sprite1F;
				case 0x20: return Sprite20;
				case 0x21: return Sprite21;
				case 0x22: return Sprite22;
				case 0x23: return Sprite23;
				case 0x24: return Sprite24;
				case 0x25: return Sprite25;
				case 0x26: return Sprite26;
				case 0x27: return Sprite27;
				case 0x28: return Sprite28;
				case 0x29: return Sprite29;
				case 0x2A: return Sprite2A;
				case 0x2B: return Sprite2B;
				case 0x2C: return Sprite2C;
				case 0x2D: return Sprite2D;
				case 0x2E: return Sprite2E;
				case 0x2F: return Sprite2F;
				case 0x30: return Sprite30;
				case 0x31: return Sprite31;
				case 0x32: return Sprite32;
				case 0x33: return Sprite33;
				case 0x34: return Sprite34;
				case 0x35: return Sprite35;
				case 0x36: return Sprite36;
				case 0x37: return Sprite37;
				case 0x38: return Sprite38;
				case 0x39: return Sprite39;
				case 0x3A: return Sprite3A;
				case 0x3B: return Sprite3B;
				case 0x3C: return Sprite3C;
				case 0x3D: return Sprite3D;
				case 0x3E: return Sprite3E;
				case 0x3F: return Sprite3F;
				case 0x40: return Sprite40;
				case 0x41: return Sprite41;
				case 0x42: return Sprite42;
				case 0x43: return Sprite43;
				case 0x44: return Sprite44;
				case 0x45: return Sprite45;
				case 0x46: return Sprite46;
				case 0x47: return Sprite47;
				case 0x48: return Sprite48;
				case 0x49: return Sprite49;
				case 0x4A: return Sprite4A;
				case 0x4B: return Sprite4B;
				case 0x4C: return Sprite4C;
				case 0x4D: return Sprite4D;
				case 0x4E: return Sprite4E;
				case 0x4F: return Sprite4F;
				case 0x50: return Sprite50;
				case 0x51: return Sprite51;
				case 0x52: return Sprite52;
				case 0x53: return Sprite53;
				case 0x54: return Sprite54;
				case 0x55: return Sprite55;
				case 0x56: return Sprite56;
				case 0x57: return Sprite57;
				case 0x58: return Sprite58;
				case 0x59: return Sprite59;
				case 0x5A: return Sprite5A;
				case 0x5B: return Sprite5B;
				case 0x5C: return Sprite5C;
				case 0x5D: return Sprite5D;
				case 0x5E: return Sprite5E;
				case 0x5F: return Sprite5F;
				case 0x60: return Sprite60;
				case 0x61: return Sprite61;
				case 0x62: return Sprite62;
				case 0x63: return Sprite63;
				case 0x64: return Sprite64;
				case 0x65: return Sprite65;
				case 0x66: return Sprite66;
				case 0x67: return Sprite67;
				case 0x68: return Sprite68;
				case 0x69: return Sprite69;
				case 0x6A: return Sprite6A;
				case 0x6B: return Sprite6B;
				case 0x6C: return Sprite6C;
				case 0x6D: return Sprite6D;
				case 0x6E: return Sprite6E;
				case 0x6F: return Sprite6F;
				case 0x70: return Sprite70;
				case 0x71: return Sprite71;
				case 0x72: return Sprite72;
				case 0x73: return Sprite73;
				case 0x74: return Sprite74;
				case 0x75: return Sprite75;
				case 0x76: return Sprite76;
				case 0x77: return Sprite77;
				case 0x78: return Sprite78;
				case 0x79: return Sprite79;
				case 0x7A: return Sprite7A;
				case 0x7B: return Sprite7B;
				case 0x7C: return Sprite7C;
				case 0x7D: return Sprite7D;
				case 0x7E: return Sprite7E;
				case 0x7F: return Sprite7F;
				case 0x80: return Sprite80;
				case 0x81: return Sprite81;
				case 0x82: return Sprite82;
				case 0x83: return Sprite83;
				case 0x84: return Sprite84;
				case 0x85: return Sprite85;
				case 0x86: return Sprite86;
				case 0x87: return Sprite87;
				case 0x88: return Sprite88;
				case 0x89: return Sprite89;
				case 0x8A: return Sprite8A;
				case 0x8B: return Sprite8B;
				case 0x8C: return Sprite8C;
				case 0x8D: return Sprite8D;
				case 0x8E: return Sprite8E;
				case 0x8F: return Sprite8F;
				case 0x90: return Sprite90;
				case 0x91: return Sprite91;
				case 0x92: return Sprite92;
				case 0x93: return Sprite93;
				case 0x94: return Sprite94;
				case 0x95: return Sprite95;
				case 0x96: return Sprite96;
				case 0x97: return Sprite97;
				case 0x98: return Sprite98;
				case 0x99: return Sprite99;
				case 0x9A: return Sprite9A;
				case 0x9B: return Sprite9B;
				case 0x9C: return Sprite9C;
				case 0x9D: return Sprite9D;
				case 0x9E: return Sprite9E;
				case 0x9F: return Sprite9F;
				case 0xA0: return SpriteA0;
				case 0xA1: return SpriteA1;
				case 0xA2: return SpriteA2;
				case 0xA3: return SpriteA3;
				case 0xA4: return SpriteA4;
				case 0xA5: return SpriteA5;
				case 0xA6: return SpriteA6;
				case 0xA7: return SpriteA7;
				case 0xA8: return SpriteA8;
				case 0xA9: return SpriteA9;
				case 0xAA: return SpriteAA;
				case 0xAB: return SpriteAB;
				case 0xAC: return SpriteAC;
				case 0xAD: return SpriteAD;
				case 0xAE: return SpriteAE;
				case 0xAF: return SpriteAF;
				case 0xB0: return SpriteB0;
				case 0xB1: return SpriteB1;
				case 0xB2: return SpriteB2;
				case 0xB3: return SpriteB3;
				case 0xB4: return SpriteB4;
				case 0xB5: return SpriteB5;
				case 0xB6: return SpriteB6;
				case 0xB7: return SpriteB7;
				case 0xB8: return SpriteB8;
				case 0xB9: return SpriteB9;
				case 0xBA: return SpriteBA;
				case 0xBB: return SpriteBB;
				case 0xBC: return SpriteBC;
				case 0xBD: return SpriteBD;
				case 0xBE: return SpriteBE;
				case 0xBF: return SpriteBF;
				case 0xC0: return SpriteC0;
				case 0xC1: return SpriteC1;
				case 0xC2: return SpriteC2;
				case 0xC3: return SpriteC3;
				case 0xC4: return SpriteC4;
				case 0xC5: return SpriteC5;
				case 0xC6: return SpriteC6;
				case 0xC7: return SpriteC7;
				case 0xC8: return SpriteC8;
				case 0xC9: return SpriteC9;
				case 0xCA: return SpriteCA;
				case 0xCB: return SpriteCB;
				case 0xCC: return SpriteCC;
				case 0xCD: return SpriteCD;
				case 0xCE: return SpriteCE;
				case 0xCF: return SpriteCF;
				case 0xD0: return SpriteD0;
				case 0xD1: return SpriteD1;
				case 0xD2: return SpriteD2;
				case 0xD3: return SpriteD3;
				case 0xD4: return SpriteD4;
				case 0xD5: return SpriteD5;
				case 0xD6: return SpriteD6;
				case 0xD7: return SpriteD7;
				case 0xD8: return SpriteD8;
				case 0xD9: return SpriteD9;
				case 0xDA: return SpriteDA;
				case 0xDB: return SpriteDB;
				case 0xDC: return SpriteDC;
				case 0xDD: return SpriteDD;
				case 0xDE: return SpriteDE;
				case 0xDF: return SpriteDF;
				case 0xE0: return SpriteE0;
				case 0xE1: return SpriteE1;
				case 0xE2: return SpriteE2;
				case 0xE3: return SpriteE3;
				case 0xE4: return SpriteE4;
				case 0xE5: return SpriteE5;
				case 0xE6: return SpriteE6;
				case 0xE7: return SpriteE7;
				case 0xE8: return SpriteE8;
				case 0xE9: return SpriteE9;
				case 0xEA: return SpriteEA;
				case 0xEB: return SpriteEB;
				case 0xEC: return SpriteEC;
				case 0xED: return SpriteED;
				case 0xEE: return SpriteEE;
				case 0xEF: return SpriteEF;
				case 0xF0: return SpriteF0;
				case 0xF1: return SpriteF1;
				case 0xF2: return SpriteF2;
				default: return null;
			}
		}

	}

	//=============================================================================================
	// Overlords
	//=============================================================================================
	public partial class OverlordType : SpriteType, IEntityType<OverlordType>
	{
		private OverlordType(byte id, DrawSprite d, SpriteCategory[] categories, byte[] gsets)
			: base(id, d, categories, gsets, true) { }

		public static readonly OverlordType Overlord01 = new OverlordType(0x01, SpriteDraw_Overlord01,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord02 = new OverlordType(0x02, SpriteDraw_Overlord02,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord03 = new OverlordType(0x03, SpriteDraw_Overlord03,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord04 = new OverlordType(0x04, SpriteDraw_Overlord04,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord05 = new OverlordType(0x05, SpriteDraw_Overlord05,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord06 = new OverlordType(0x06, SpriteDraw_Overlord06,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord07 = new OverlordType(0x07, SpriteDraw_Overlord07,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord08 = new OverlordType(0x08, SpriteDraw_Overlord08,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord09 = new OverlordType(0x09, SpriteDraw_Overlord09,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord0A = new OverlordType(0x0A, SpriteDraw_Overlord0A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord0B = new OverlordType(0x0B, SpriteDraw_Overlord0B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord0C = new OverlordType(0x0C, SpriteDraw_Overlord0C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord0D = new OverlordType(0x0D, SpriteDraw_Overlord0D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord0E = new OverlordType(0x0E, SpriteDraw_Overlord0E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord0F = new OverlordType(0x0F, SpriteDraw_Overlord0F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord10 = new OverlordType(0x10, SpriteDraw_Overlord10,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord11 = new OverlordType(0x11, SpriteDraw_Overlord11,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord12 = new OverlordType(0x12, SpriteDraw_Overlord12,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord13 = new OverlordType(0x13, SpriteDraw_Overlord13,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord14 = new OverlordType(0x14, SpriteDraw_Overlord14,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord15 = new OverlordType(0x15, SpriteDraw_Overlord15,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord16 = new OverlordType(0x16, SpriteDraw_Overlord16,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord17 = new OverlordType(0x17, SpriteDraw_Overlord17,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord18 = new OverlordType(0x18, SpriteDraw_Overlord18,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord19 = new OverlordType(0x19, SpriteDraw_Overlord19,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord1A = new OverlordType(0x1A, SpriteDraw_Overlord1A,
			new SpriteCategory[] { },
			new byte[] { });

		public static new OverlordType GetTypeFromID(int b)
		{
			switch (b)
			{
				case 0x01: return Overlord01;
				case 0x02: return Overlord02;
				case 0x03: return Overlord03;
				case 0x04: return Overlord04;
				case 0x05: return Overlord05;
				case 0x06: return Overlord06;
				case 0x07: return Overlord07;
				case 0x08: return Overlord08;
				case 0x09: return Overlord09;
				case 0x0A: return Overlord0A;
				case 0x0B: return Overlord0B;
				case 0x0C: return Overlord0C;
				case 0x0D: return Overlord0D;
				case 0x0E: return Overlord0E;
				case 0x0F: return Overlord0F;
				case 0x10: return Overlord10;
				case 0x11: return Overlord11;
				case 0x12: return Overlord12;
				case 0x13: return Overlord13;
				case 0x14: return Overlord14;
				case 0x15: return Overlord15;
				case 0x16: return Overlord16;
				case 0x17: return Overlord17;
				case 0x18: return Overlord18;
				case 0x19: return Overlord19;
				case 0x1A: return Overlord1A;
				default: return null;
			}
		}
	}
}
