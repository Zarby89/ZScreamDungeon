﻿using System.Collections.Immutable;
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

		public static readonly SpriteType Sprite00 = new(0x00, SpriteDraw_Sprite00,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite01 = new(0x01, SpriteDraw_Sprite01,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite02 = new(0x02, SpriteDraw_Sprite02,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite03 = new(0x03, SpriteDraw_Sprite03,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite04 = new(0x04, SpriteDraw_Sprite04,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite05 = new(0x05, SpriteDraw_Sprite05,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite06 = new(0x06, SpriteDraw_Sprite06,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite07 = new(0x07, SpriteDraw_Sprite07,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite08 = new(0x08, SpriteDraw_Sprite08,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite09 = new(0x09, SpriteDraw_Sprite09,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite0A = new(0x0A, SpriteDraw_Sprite0A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite0B = new(0x0B, SpriteDraw_Sprite0B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite0C = new(0x0C, SpriteDraw_Sprite0C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite0D = new(0x0D, SpriteDraw_Sprite0D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite0E = new(0x0E, SpriteDraw_Sprite0E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite0F = new(0x0F, SpriteDraw_Sprite0F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite10 = new(0x10, SpriteDraw_Sprite10,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite11 = new(0x11, SpriteDraw_Sprite11,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite12 = new(0x12, SpriteDraw_Sprite12,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite13 = new(0x13, SpriteDraw_Sprite13,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite14 = new(0x14, SpriteDraw_Sprite14,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite15 = new(0x15, SpriteDraw_Sprite15,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite16 = new(0x16, SpriteDraw_Sprite16,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite17 = new(0x17, SpriteDraw_Sprite17,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite18 = new(0x18, SpriteDraw_Sprite18,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite19 = new(0x19, SpriteDraw_Sprite19,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite1A = new(0x1A, SpriteDraw_Sprite1A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite1B = new(0x1B, SpriteDraw_Sprite1B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite1C = new(0x1C, SpriteDraw_Sprite1C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite1D = new(0x1D, SpriteDraw_Sprite1D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite1E = new(0x1E, SpriteDraw_Sprite1E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite1F = new(0x1F, SpriteDraw_Sprite1F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite20 = new(0x20, SpriteDraw_Sprite20,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite21 = new(0x21, SpriteDraw_Sprite21,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite22 = new(0x22, SpriteDraw_Sprite22,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite23 = new(0x23, SpriteDraw_Sprite23,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite24 = new(0x24, SpriteDraw_Sprite24,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite25 = new(0x25, SpriteDraw_Sprite25,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite26 = new(0x26, SpriteDraw_Sprite26,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite27 = new(0x27, SpriteDraw_Sprite27,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite28 = new(0x28, SpriteDraw_Sprite28,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite29 = new(0x29, SpriteDraw_Sprite29,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite2A = new(0x2A, SpriteDraw_Sprite2A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite2B = new(0x2B, SpriteDraw_Sprite2B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite2C = new(0x2C, SpriteDraw_Sprite2C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite2D = new(0x2D, SpriteDraw_Sprite2D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite2E = new(0x2E, SpriteDraw_Sprite2E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite2F = new(0x2F, SpriteDraw_Sprite2F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite30 = new(0x30, SpriteDraw_Sprite30,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite31 = new(0x31, SpriteDraw_Sprite31,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite32 = new(0x32, SpriteDraw_Sprite32,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite33 = new(0x33, SpriteDraw_Sprite33,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite34 = new(0x34, SpriteDraw_Sprite34,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite35 = new(0x35, SpriteDraw_Sprite35,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite36 = new(0x36, SpriteDraw_Sprite36,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite37 = new(0x37, SpriteDraw_Sprite37,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite38 = new(0x38, SpriteDraw_Sprite38,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite39 = new(0x39, SpriteDraw_Sprite39,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite3A = new(0x3A, SpriteDraw_Sprite3A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite3B = new(0x3B, SpriteDraw_Sprite3B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite3C = new(0x3C, SpriteDraw_Sprite3C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite3D = new(0x3D, SpriteDraw_Sprite3D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite3E = new(0x3E, SpriteDraw_Sprite3E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite3F = new(0x3F, SpriteDraw_Sprite3F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite40 = new(0x40, SpriteDraw_Sprite40,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite41 = new(0x41, SpriteDraw_Sprite41,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite42 = new(0x42, SpriteDraw_Sprite42,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite43 = new(0x43, SpriteDraw_Sprite43,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite44 = new(0x44, SpriteDraw_Sprite44,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite45 = new(0x45, SpriteDraw_Sprite45,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite46 = new(0x46, SpriteDraw_Sprite46,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite47 = new(0x47, SpriteDraw_Sprite47,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite48 = new(0x48, SpriteDraw_Sprite48,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite49 = new(0x49, SpriteDraw_Sprite49,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite4A = new(0x4A, SpriteDraw_Sprite4A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite4B = new(0x4B, SpriteDraw_Sprite4B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite4C = new(0x4C, SpriteDraw_Sprite4C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite4D = new(0x4D, SpriteDraw_Sprite4D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite4E = new(0x4E, SpriteDraw_Sprite4E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite4F = new(0x4F, SpriteDraw_Sprite4F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite50 = new(0x50, SpriteDraw_Sprite50,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite51 = new(0x51, SpriteDraw_Sprite51,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite52 = new(0x52, SpriteDraw_Sprite52,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite53 = new(0x53, SpriteDraw_Sprite53,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite54 = new(0x54, SpriteDraw_Sprite54,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite55 = new(0x55, SpriteDraw_Sprite55,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite56 = new(0x56, SpriteDraw_Sprite56,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite57 = new(0x57, SpriteDraw_Sprite57,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite58 = new(0x58, SpriteDraw_Sprite58,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite59 = new(0x59, SpriteDraw_Sprite59,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite5A = new(0x5A, SpriteDraw_Sprite5A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite5B = new(0x5B, SpriteDraw_Sprite5B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite5C = new(0x5C, SpriteDraw_Sprite5C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite5D = new(0x5D, SpriteDraw_Sprite5D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite5E = new(0x5E, SpriteDraw_Sprite5E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite5F = new(0x5F, SpriteDraw_Sprite5F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite60 = new(0x60, SpriteDraw_Sprite60,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite61 = new(0x61, SpriteDraw_Sprite61,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite62 = new(0x62, SpriteDraw_Sprite62,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite63 = new(0x63, SpriteDraw_Sprite63,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite64 = new(0x64, SpriteDraw_Sprite64,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite65 = new(0x65, SpriteDraw_Sprite65,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite66 = new(0x66, SpriteDraw_Sprite66,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite67 = new(0x67, SpriteDraw_Sprite67,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite68 = new(0x68, SpriteDraw_Sprite68,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite69 = new(0x69, SpriteDraw_Sprite69,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite6A = new(0x6A, SpriteDraw_Sprite6A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite6B = new(0x6B, SpriteDraw_Sprite6B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite6C = new(0x6C, SpriteDraw_Sprite6C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite6D = new(0x6D, SpriteDraw_Sprite6D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite6E = new(0x6E, SpriteDraw_Sprite6E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite6F = new(0x6F, SpriteDraw_Sprite6F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite70 = new(0x70, SpriteDraw_Sprite70,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite71 = new(0x71, SpriteDraw_Sprite71,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite72 = new(0x72, SpriteDraw_Sprite72,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite73 = new(0x73, SpriteDraw_Sprite73,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite74 = new(0x74, SpriteDraw_Sprite74,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite75 = new(0x75, SpriteDraw_Sprite75,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite76 = new(0x76, SpriteDraw_Sprite76,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite77 = new(0x77, SpriteDraw_Sprite77,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite78 = new(0x78, SpriteDraw_Sprite78,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite79 = new(0x79, SpriteDraw_Sprite79,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite7A = new(0x7A, SpriteDraw_Sprite7A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite7B = new(0x7B, SpriteDraw_Sprite7B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite7C = new(0x7C, SpriteDraw_Sprite7C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite7D = new(0x7D, SpriteDraw_Sprite7D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite7E = new(0x7E, SpriteDraw_Sprite7E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite7F = new(0x7F, SpriteDraw_Sprite7F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite80 = new(0x80, SpriteDraw_Sprite80,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite81 = new(0x81, SpriteDraw_Sprite81,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite82 = new(0x82, SpriteDraw_Sprite82,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite83 = new(0x83, SpriteDraw_Sprite83,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite84 = new(0x84, SpriteDraw_Sprite84,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite85 = new(0x85, SpriteDraw_Sprite85,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite86 = new(0x86, SpriteDraw_Sprite86,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite87 = new(0x87, SpriteDraw_Sprite87,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite88 = new(0x88, SpriteDraw_Sprite88,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite89 = new(0x89, SpriteDraw_Sprite89,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite8A = new(0x8A, SpriteDraw_Sprite8A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite8B = new(0x8B, SpriteDraw_Sprite8B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite8C = new(0x8C, SpriteDraw_Sprite8C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite8D = new(0x8D, SpriteDraw_Sprite8D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite8E = new(0x8E, SpriteDraw_Sprite8E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite8F = new(0x8F, SpriteDraw_Sprite8F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite90 = new(0x90, SpriteDraw_Sprite90,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite91 = new(0x91, SpriteDraw_Sprite91,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite92 = new(0x92, SpriteDraw_Sprite92,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite93 = new(0x93, SpriteDraw_Sprite93,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite94 = new(0x94, SpriteDraw_Sprite94,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite95 = new(0x95, SpriteDraw_Sprite95,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite96 = new(0x96, SpriteDraw_Sprite96,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite97 = new(0x97, SpriteDraw_Sprite97,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite98 = new(0x98, SpriteDraw_Sprite98,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite99 = new(0x99, SpriteDraw_Sprite99,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite9A = new(0x9A, SpriteDraw_Sprite9A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite9B = new(0x9B, SpriteDraw_Sprite9B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite9C = new(0x9C, SpriteDraw_Sprite9C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite9D = new(0x9D, SpriteDraw_Sprite9D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite9E = new(0x9E, SpriteDraw_Sprite9E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType Sprite9F = new(0x9F, SpriteDraw_Sprite9F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA0 = new(0xA0, SpriteDraw_SpriteA0,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA1 = new(0xA1, SpriteDraw_SpriteA1,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA2 = new(0xA2, SpriteDraw_SpriteA2,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA3 = new(0xA3, SpriteDraw_SpriteA3,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA4 = new(0xA4, SpriteDraw_SpriteA4,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA5 = new(0xA5, SpriteDraw_SpriteA5,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA6 = new(0xA6, SpriteDraw_SpriteA6,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA7 = new(0xA7, SpriteDraw_SpriteA7,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA8 = new(0xA8, SpriteDraw_SpriteA8,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteA9 = new(0xA9, SpriteDraw_SpriteA9,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteAA = new(0xAA, SpriteDraw_SpriteAA,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteAB = new(0xAB, SpriteDraw_SpriteAB,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteAC = new(0xAC, SpriteDraw_SpriteAC,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteAD = new(0xAD, SpriteDraw_SpriteAD,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteAE = new(0xAE, SpriteDraw_SpriteAE,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteAF = new(0xAF, SpriteDraw_SpriteAF,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB0 = new(0xB0, SpriteDraw_SpriteB0,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB1 = new(0xB1, SpriteDraw_SpriteB1,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB2 = new(0xB2, SpriteDraw_SpriteB2,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB3 = new(0xB3, SpriteDraw_SpriteB3,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB4 = new(0xB4, SpriteDraw_SpriteB4,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB5 = new(0xB5, SpriteDraw_SpriteB5,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB6 = new(0xB6, SpriteDraw_SpriteB6,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB7 = new(0xB7, SpriteDraw_SpriteB7,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB8 = new(0xB8, SpriteDraw_SpriteB8,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteB9 = new(0xB9, SpriteDraw_SpriteB9,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteBA = new(0xBA, SpriteDraw_SpriteBA,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteBB = new(0xBB, SpriteDraw_SpriteBB,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteBC = new(0xBC, SpriteDraw_SpriteBC,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteBD = new(0xBD, SpriteDraw_SpriteBD,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteBE = new(0xBE, SpriteDraw_SpriteBE,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteBF = new(0xBF, SpriteDraw_SpriteBF,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC0 = new(0xC0, SpriteDraw_SpriteC0,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC1 = new(0xC1, SpriteDraw_SpriteC1,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC2 = new(0xC2, SpriteDraw_SpriteC2,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC3 = new(0xC3, SpriteDraw_SpriteC3,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC4 = new(0xC4, SpriteDraw_SpriteC4,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC5 = new(0xC5, SpriteDraw_SpriteC5,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC6 = new(0xC6, SpriteDraw_SpriteC6,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC7 = new(0xC7, SpriteDraw_SpriteC7,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC8 = new(0xC8, SpriteDraw_SpriteC8,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteC9 = new(0xC9, SpriteDraw_SpriteC9,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteCA = new(0xCA, SpriteDraw_SpriteCA,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteCB = new(0xCB, SpriteDraw_SpriteCB,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteCC = new(0xCC, SpriteDraw_SpriteCC,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteCD = new(0xCD, SpriteDraw_SpriteCD,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteCE = new(0xCE, SpriteDraw_SpriteCE,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteCF = new(0xCF, SpriteDraw_SpriteCF,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD0 = new(0xD0, SpriteDraw_SpriteD0,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD1 = new(0xD1, SpriteDraw_SpriteD1,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD2 = new(0xD2, SpriteDraw_SpriteD2,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD3 = new(0xD3, SpriteDraw_SpriteD3,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD4 = new(0xD4, SpriteDraw_SpriteD4,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD5 = new(0xD5, SpriteDraw_SpriteD5,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD6 = new(0xD6, SpriteDraw_SpriteD6,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD7 = new(0xD7, SpriteDraw_SpriteD7,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD8 = new(0xD8, SpriteDraw_SpriteD8,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteD9 = new(0xD9, SpriteDraw_SpriteD9,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteDA = new(0xDA, SpriteDraw_SpriteDA,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteDB = new(0xDB, SpriteDraw_SpriteDB,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteDC = new(0xDC, SpriteDraw_SpriteDC,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteDD = new(0xDD, SpriteDraw_SpriteDD,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteDE = new(0xDE, SpriteDraw_SpriteDE,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteDF = new(0xDF, SpriteDraw_SpriteDF,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE0 = new(0xE0, SpriteDraw_SpriteE0,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE1 = new(0xE1, SpriteDraw_SpriteE1,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE2 = new(0xE2, SpriteDraw_SpriteE2,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE3 = new(0xE3, SpriteDraw_SpriteE3,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE4 = new(0xE4, SpriteDraw_SpriteE4,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE5 = new(0xE5, SpriteDraw_SpriteE5,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE6 = new(0xE6, SpriteDraw_SpriteE6,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE7 = new(0xE7, SpriteDraw_SpriteE7,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE8 = new(0xE8, SpriteDraw_SpriteE8,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteE9 = new(0xE9, SpriteDraw_SpriteE9,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteEA = new(0xEA, SpriteDraw_SpriteEA,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteEB = new(0xEB, SpriteDraw_SpriteEB,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteEC = new(0xEC, SpriteDraw_SpriteEC,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteED = new(0xED, SpriteDraw_SpriteED,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteEE = new(0xEE, SpriteDraw_SpriteEE,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteEF = new(0xEF, SpriteDraw_SpriteEF,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteF0 = new(0xF0, SpriteDraw_SpriteF0,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteF1 = new(0xF1, SpriteDraw_SpriteF1,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly SpriteType SpriteF2 = new(0xF2, SpriteDraw_SpriteF2,
			new SpriteCategory[] { },
			new byte[] { });

		public static SpriteType GetTypeFromID(int b)
		{
			return b switch
			{
				0x00 => Sprite00,
				0x01 => Sprite01,
				0x02 => Sprite02,
				0x03 => Sprite03,
				0x04 => Sprite04,
				0x05 => Sprite05,
				0x06 => Sprite06,
				0x07 => Sprite07,
				0x08 => Sprite08,
				0x09 => Sprite09,
				0x0A => Sprite0A,
				0x0B => Sprite0B,
				0x0C => Sprite0C,
				0x0D => Sprite0D,
				0x0E => Sprite0E,
				0x0F => Sprite0F,
				0x10 => Sprite10,
				0x11 => Sprite11,
				0x12 => Sprite12,
				0x13 => Sprite13,
				0x14 => Sprite14,
				0x15 => Sprite15,
				0x16 => Sprite16,
				0x17 => Sprite17,
				0x18 => Sprite18,
				0x19 => Sprite19,
				0x1A => Sprite1A,
				0x1B => Sprite1B,
				0x1C => Sprite1C,
				0x1D => Sprite1D,
				0x1E => Sprite1E,
				0x1F => Sprite1F,
				0x20 => Sprite20,
				0x21 => Sprite21,
				0x22 => Sprite22,
				0x23 => Sprite23,
				0x24 => Sprite24,
				0x25 => Sprite25,
				0x26 => Sprite26,
				0x27 => Sprite27,
				0x28 => Sprite28,
				0x29 => Sprite29,
				0x2A => Sprite2A,
				0x2B => Sprite2B,
				0x2C => Sprite2C,
				0x2D => Sprite2D,
				0x2E => Sprite2E,
				0x2F => Sprite2F,
				0x30 => Sprite30,
				0x31 => Sprite31,
				0x32 => Sprite32,
				0x33 => Sprite33,
				0x34 => Sprite34,
				0x35 => Sprite35,
				0x36 => Sprite36,
				0x37 => Sprite37,
				0x38 => Sprite38,
				0x39 => Sprite39,
				0x3A => Sprite3A,
				0x3B => Sprite3B,
				0x3C => Sprite3C,
				0x3D => Sprite3D,
				0x3E => Sprite3E,
				0x3F => Sprite3F,
				0x40 => Sprite40,
				0x41 => Sprite41,
				0x42 => Sprite42,
				0x43 => Sprite43,
				0x44 => Sprite44,
				0x45 => Sprite45,
				0x46 => Sprite46,
				0x47 => Sprite47,
				0x48 => Sprite48,
				0x49 => Sprite49,
				0x4A => Sprite4A,
				0x4B => Sprite4B,
				0x4C => Sprite4C,
				0x4D => Sprite4D,
				0x4E => Sprite4E,
				0x4F => Sprite4F,
				0x50 => Sprite50,
				0x51 => Sprite51,
				0x52 => Sprite52,
				0x53 => Sprite53,
				0x54 => Sprite54,
				0x55 => Sprite55,
				0x56 => Sprite56,
				0x57 => Sprite57,
				0x58 => Sprite58,
				0x59 => Sprite59,
				0x5A => Sprite5A,
				0x5B => Sprite5B,
				0x5C => Sprite5C,
				0x5D => Sprite5D,
				0x5E => Sprite5E,
				0x5F => Sprite5F,
				0x60 => Sprite60,
				0x61 => Sprite61,
				0x62 => Sprite62,
				0x63 => Sprite63,
				0x64 => Sprite64,
				0x65 => Sprite65,
				0x66 => Sprite66,
				0x67 => Sprite67,
				0x68 => Sprite68,
				0x69 => Sprite69,
				0x6A => Sprite6A,
				0x6B => Sprite6B,
				0x6C => Sprite6C,
				0x6D => Sprite6D,
				0x6E => Sprite6E,
				0x6F => Sprite6F,
				0x70 => Sprite70,
				0x71 => Sprite71,
				0x72 => Sprite72,
				0x73 => Sprite73,
				0x74 => Sprite74,
				0x75 => Sprite75,
				0x76 => Sprite76,
				0x77 => Sprite77,
				0x78 => Sprite78,
				0x79 => Sprite79,
				0x7A => Sprite7A,
				0x7B => Sprite7B,
				0x7C => Sprite7C,
				0x7D => Sprite7D,
				0x7E => Sprite7E,
				0x7F => Sprite7F,
				0x80 => Sprite80,
				0x81 => Sprite81,
				0x82 => Sprite82,
				0x83 => Sprite83,
				0x84 => Sprite84,
				0x85 => Sprite85,
				0x86 => Sprite86,
				0x87 => Sprite87,
				0x88 => Sprite88,
				0x89 => Sprite89,
				0x8A => Sprite8A,
				0x8B => Sprite8B,
				0x8C => Sprite8C,
				0x8D => Sprite8D,
				0x8E => Sprite8E,
				0x8F => Sprite8F,
				0x90 => Sprite90,
				0x91 => Sprite91,
				0x92 => Sprite92,
				0x93 => Sprite93,
				0x94 => Sprite94,
				0x95 => Sprite95,
				0x96 => Sprite96,
				0x97 => Sprite97,
				0x98 => Sprite98,
				0x99 => Sprite99,
				0x9A => Sprite9A,
				0x9B => Sprite9B,
				0x9C => Sprite9C,
				0x9D => Sprite9D,
				0x9E => Sprite9E,
				0x9F => Sprite9F,
				0xA0 => SpriteA0,
				0xA1 => SpriteA1,
				0xA2 => SpriteA2,
				0xA3 => SpriteA3,
				0xA4 => SpriteA4,
				0xA5 => SpriteA5,
				0xA6 => SpriteA6,
				0xA7 => SpriteA7,
				0xA8 => SpriteA8,
				0xA9 => SpriteA9,
				0xAA => SpriteAA,
				0xAB => SpriteAB,
				0xAC => SpriteAC,
				0xAD => SpriteAD,
				0xAE => SpriteAE,
				0xAF => SpriteAF,
				0xB0 => SpriteB0,
				0xB1 => SpriteB1,
				0xB2 => SpriteB2,
				0xB3 => SpriteB3,
				0xB4 => SpriteB4,
				0xB5 => SpriteB5,
				0xB6 => SpriteB6,
				0xB7 => SpriteB7,
				0xB8 => SpriteB8,
				0xB9 => SpriteB9,
				0xBA => SpriteBA,
				0xBB => SpriteBB,
				0xBC => SpriteBC,
				0xBD => SpriteBD,
				0xBE => SpriteBE,
				0xBF => SpriteBF,
				0xC0 => SpriteC0,
				0xC1 => SpriteC1,
				0xC2 => SpriteC2,
				0xC3 => SpriteC3,
				0xC4 => SpriteC4,
				0xC5 => SpriteC5,
				0xC6 => SpriteC6,
				0xC7 => SpriteC7,
				0xC8 => SpriteC8,
				0xC9 => SpriteC9,
				0xCA => SpriteCA,
				0xCB => SpriteCB,
				0xCC => SpriteCC,
				0xCD => SpriteCD,
				0xCE => SpriteCE,
				0xCF => SpriteCF,
				0xD0 => SpriteD0,
				0xD1 => SpriteD1,
				0xD2 => SpriteD2,
				0xD3 => SpriteD3,
				0xD4 => SpriteD4,
				0xD5 => SpriteD5,
				0xD6 => SpriteD6,
				0xD7 => SpriteD7,
				0xD8 => SpriteD8,
				0xD9 => SpriteD9,
				0xDA => SpriteDA,
				0xDB => SpriteDB,
				0xDC => SpriteDC,
				0xDD => SpriteDD,
				0xDE => SpriteDE,
				0xDF => SpriteDF,
				0xE0 => SpriteE0,
				0xE1 => SpriteE1,
				0xE2 => SpriteE2,
				0xE3 => SpriteE3,
				0xE4 => SpriteE4,
				0xE5 => SpriteE5,
				0xE6 => SpriteE6,
				0xE7 => SpriteE7,
				0xE8 => SpriteE8,
				0xE9 => SpriteE9,
				0xEA => SpriteEA,
				0xEB => SpriteEB,
				0xEC => SpriteEC,
				0xED => SpriteED,
				0xEE => SpriteEE,
				0xEF => SpriteEF,
				0xF0 => SpriteF0,
				0xF1 => SpriteF1,
				0xF2 => SpriteF2,
				_ => null,
			};
		}

	}

	//=============================================================================================
	// Overlords
	//=============================================================================================
	public partial class OverlordType : SpriteType, IEntityType<OverlordType>
	{
		private OverlordType(byte id, DrawSprite d, SpriteCategory[] categories, byte[] gsets)
			: base(id, d, categories, gsets, true) { }

		public static readonly OverlordType Overlord01 = new(0x01, SpriteDraw_Overlord01,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord02 = new(0x02, SpriteDraw_Overlord02,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord03 = new(0x03, SpriteDraw_Overlord03,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord04 = new(0x04, SpriteDraw_Overlord04,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord05 = new(0x05, SpriteDraw_Overlord05,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord06 = new(0x06, SpriteDraw_Overlord06,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord07 = new(0x07, SpriteDraw_Overlord07,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord08 = new(0x08, SpriteDraw_Overlord08,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord09 = new(0x09, SpriteDraw_Overlord09,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord0A = new(0x0A, SpriteDraw_Overlord0A,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord0B = new(0x0B, SpriteDraw_Overlord0B,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord0C = new(0x0C, SpriteDraw_Overlord0C,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord0D = new(0x0D, SpriteDraw_Overlord0D,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord0E = new(0x0E, SpriteDraw_Overlord0E,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord0F = new(0x0F, SpriteDraw_Overlord0F,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord10 = new(0x10, SpriteDraw_Overlord10,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord11 = new(0x11, SpriteDraw_Overlord11,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord12 = new(0x12, SpriteDraw_Overlord12,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord13 = new(0x13, SpriteDraw_Overlord13,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord14 = new(0x14, SpriteDraw_Overlord14,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord15 = new(0x15, SpriteDraw_Overlord15,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord16 = new(0x16, SpriteDraw_Overlord16,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord17 = new(0x17, SpriteDraw_Overlord17,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord18 = new(0x18, SpriteDraw_Overlord18,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord19 = new(0x19, SpriteDraw_Overlord19,
			new SpriteCategory[] { },
			new byte[] { });

		public static readonly OverlordType Overlord1A = new(0x1A, SpriteDraw_Overlord1A,
			new SpriteCategory[] { },
			new byte[] { });

		public static new OverlordType GetTypeFromID(int b)
		{
			return b switch
			{
				0x01 => Overlord01,
				0x02 => Overlord02,
				0x03 => Overlord03,
				0x04 => Overlord04,
				0x05 => Overlord05,
				0x06 => Overlord06,
				0x07 => Overlord07,
				0x08 => Overlord08,
				0x09 => Overlord09,
				0x0A => Overlord0A,
				0x0B => Overlord0B,
				0x0C => Overlord0C,
				0x0D => Overlord0D,
				0x0E => Overlord0E,
				0x0F => Overlord0F,
				0x10 => Overlord10,
				0x11 => Overlord11,
				0x12 => Overlord12,
				0x13 => Overlord13,
				0x14 => Overlord14,
				0x15 => Overlord15,
				0x16 => Overlord16,
				0x17 => Overlord17,
				0x18 => Overlord18,
				0x19 => Overlord19,
				0x1A => Overlord1A,
				_ => null,
			};
		}
	}
}
