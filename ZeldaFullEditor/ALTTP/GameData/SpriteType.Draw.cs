﻿namespace ZeldaFullEditor.ALTTP.GameData
{
	public delegate void DrawSprite(IDrawArt artist, IDrawableSprite spr);

	// NOTE: consts in these draw functions indicate a global offset from the sprite's ROM coordinates that occurs when the game runs
	public partial class SpriteType
	{
		protected static void DrawTiles(IDrawArt artist, IDrawableSprite spr, params OAMDrawInfo[] instructions)
		{
			if (artist is PreviewArtist prvart && spr is ITypeID spp)
			{
				prvart.AddToObjectsPreview(spp, instructions);
			}
			else if (artist is TilemapArtist art)
			{
				art.DrawSprite(spr, instructions, useGlobal: false);
			}
		}

		//public void DrawKey(bool bigKey)
		//{
		//	int dx = (boundingbox.X + boundingbox.Width / 2) - 8;
		//	int dy = boundingbox.Y - 10;
		//
		//	if (bigKey)
		//	{
		//		draw_item_tile(dx, dy, 14, 826, 11);
		//	}
		//	else
		//	{
		//		draw_item_tile(dx + 4, dy, 14, 822, 11, false, false, 1);
		//	}
		//}

		public static void SpriteDraw_SmallKeyDrop(IDrawArt artist, IDrawableSprite spr)
		{
			throw new NotImplementedException();
		}

		public static void SpriteDraw_BigKeyDrop(IDrawArt artist, IDrawableSprite spr)
		{
			throw new NotImplementedException();
		}

		public static void SpriteDraw_GreenRupeeDrop(IDrawArt artist, IDrawableSprite spr)
		{
			throw new NotImplementedException();
		}










		protected static void SpriteDraw_Sprite00(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, -32, -22, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C8, -32, -32, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite01(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x186, 8, 0, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x186, -8, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite02(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x100, 0, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite03(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x100, 0, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite04(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1CE, 0, 0, Palette: 0, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1EE, 0, -1, Palette: 0, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite05(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1D2, -4, -3, Palette: 0, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x1D2, 12, -3, Palette: 0, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1C4, 0, 0, Palette: 0, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1E4, -4, 5, Palette: 0, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1E4, 4, 5, Palette: 0, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite06(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1CE, 0, 0, Palette: 0, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1EE, 0, -1, Palette: 0, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite07(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1A2, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A4, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite08(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A0, 0, 0, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1BB, 8, 6, Palette: 6, VFlip: false, HFlip: true, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite09(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x18C, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x188, 0, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A6, 8, 8, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A4, -8, 8, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x186, 8, -8, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x184, -8, -8, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A6, 8, 8, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A4, -8, 8, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x186, 8, -8, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x184, -8, -8, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A2, 8, 8, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A0, -8, 8, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x182, 8, -8, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x180, -8, -8, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AA, 15, 6, Palette: 0, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A8, 15, -6, Palette: 0, VFlip: true, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite0A(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A0, 0, 0, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1BB, 8, 6, Palette: 6, VFlip: false, HFlip: true, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite0B(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1EA, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite0C(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x184, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite0D(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1F0, 0, -8, Palette: 5, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1F0, 8, -8, Palette: 5, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x1E1, 0, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite0E(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18C, 4, 0, Palette: 4, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x18D, -4, 0, Palette: 4, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x18F, 4, -8, Palette: 4, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x19F, -4, -8, Palette: 4, VFlip: false, HFlip: true, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite0F(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18C, -4, -20, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18C, 4, -20, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x19C, -4, -12, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x19C, 4, -12, Palette: 6, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite10(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x038, 0, 3, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1BD, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite11(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x106, 0, 1, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x124, 8, -5, Palette: 3, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x124, -8, -5, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x100, 0, -13, Palette: 3, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite12(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18A, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x188, 0, -10, Palette: 4, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x190, -2, 11, Palette: 4, VFlip: true, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x191, -2, 3, Palette: 4, VFlip: true, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite13(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x166, 0, 0, Palette: 0, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite14(IDrawArt artist, IDrawableSprite spr)
		{
			//const int y = -8;

			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite15(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1E3, 4, 7, Palette: 1, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1E3, 9, 2, Palette: 1, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1E3, -1, 2, Palette: 1, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1E3, 4, -3, Palette: 1, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1E1, 4, 2, Palette: 1, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite16(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A2, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A0, 0, -9, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite17(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x046, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x046, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite18(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x15D, 4, 4, Palette: 3, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x162, 0, 0, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x160, 0, 0, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x14D, 10, 6, Palette: 3, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x14D, 10, 1, Palette: 3, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite19(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1E6, 0, -12, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x07C, 9, -3, Palette: 1, VFlip: false, HFlip: true, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite1A(IDrawArt artist, IDrawableSprite spr)
		{
			//const int x = 2, y = -3; // TODO only applies in light world

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x160, -11, -10, Palette: 4, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x140, 1, 0, Palette: 4, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite1B(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x03A, -8, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x03D, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite1C(IDrawArt artist, IDrawableSprite spr)
		{
			const int y = 7;

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1C0, 0, 0 + y, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C2, 8, -8 + y, Palette: 6, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x1C2, 0, -8 + y, Palette: 6, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite1D(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite1E(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1E4, 0, 0, Palette: 1, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite1F(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x10A, 8, 14, Palette: 6, VFlip: true, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x10A, -8, 14, Palette: 6, VFlip: true, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x10A, 8, 6, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x10A, -8, 6, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x10E, 0, -5, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x127, 4, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite20(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x182, 0, 0, Palette: 5, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite21(IDrawArt artist, IDrawableSprite spr)
		{
			const int y = 5;

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1CA, 0, 0 + y, Palette: 0, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1DD, 4, 12 + y, Palette: 0, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1DD, 4, 12 + y, Palette: 0, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1DD, 4, 12 + y, Palette: 0, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1DC, 4, 20 + y, Palette: 0, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite22(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x108, 0, 0, Palette: 1, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x127, 8, -8, Palette: 1, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x126, 0, -8, Palette: 1, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite23(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x132, 8, 2, Palette: 1, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x132, 0, 2, Palette: 1, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x122, 8, -6, Palette: 1, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x122, 0, -6, Palette: 1, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite24(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x132, 8, 2, Palette: 2, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x132, 0, 2, Palette: 2, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x122, 8, -6, Palette: 2, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x122, 0, -6, Palette: 2, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite25(IDrawArt artist, IDrawableSprite spr)
		{
			//const int x = -8;
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite26(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x142, 0, 2, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x140, 0, -4, Palette: 3, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite27(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C2, 0, 0, Palette: 5, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite28(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x14A, 0, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite29(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x188, 0, 0, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x186, 0, -7, Palette: 3, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite2A(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18A, 0, 5, Palette: 7, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18E, 0, -7, Palette: 7, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite2B(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1A7, 3, 3, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A6, -5, 3, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A7, 3, 3, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A6, -5, 3, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite2C(IDrawArt artist, IDrawableSprite spr)
		{
			const int x = 8;

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1A4, 31 + x, 4, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A8, 30 + x, -8, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A6, -32 + x, 4, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1A8, -32 + x, -8, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1BE, 25 + x, 5, Palette: 4, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x1BF, 17 + x, 5, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1BF, 9 + x, 5, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1BF, 1 + x, 5, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1BF, -7 + x, 5, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1BF, -15 + x, 5, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1BE, -23 + x, 5, Palette: 4, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite2D(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AA, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x182, 0, -16, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AE, 4, -14, Palette: 6, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite2E(IDrawArt artist, IDrawableSprite spr)
		{
			const int x = 8; // is 7 in light world but whatever

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1AA, 0 + x, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A8, 0 + x, -10, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AA, 0 + x, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite2F(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1E8, 0, 0, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1E0, 0, -8, Palette: 3, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite30(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x120, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x100, 0, -10, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite31(IDrawArt artist, IDrawableSprite spr)
		{
			const int x = 8, y = 8;

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x12C, 8 + x, -32 + y, Palette: 6, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x12C, 0 + x, -32 + y, Palette: 6, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x10C, 0 + x, -48 + y, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite32(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x10A, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x104, 0, -12, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite33(IDrawArt artist, IDrawableSprite spr)
		{
			//const int x = -8;

			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite34(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1E4, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x128, 0, -8, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite35(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1CA, 0, 0, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C4, 0, -8, Palette: 3, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite36(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x184, 0, 4, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x186, -3, 15, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x186, -11, 15, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x180, 0, -4, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1BE, -3, 16, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1AE, -3, 8, Palette: 4, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite37(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite38(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite39(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1EC, 0, 0, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1EA, 0, -8, Palette: 3, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite3A(IDrawArt artist, IDrawableSprite spr)
		{
			//const int x = 8;

			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite3B(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x038, 0, 11, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x07B, 0, 8, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x06B, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite3C(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AA, 0, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x182, 0, -8, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite3D(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1E4, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1E2, 0, -8, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite3E(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x044, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x044, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite3F(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 12, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x14E, 0, 0, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x142, 0, -9, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x139, 15, -11, Palette: 4, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x12A, 15, -3, Palette: 4, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x13A, 15, 5, Palette: 4, VFlip: false, HFlip: true, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite40(IDrawArt artist, IDrawableSprite spr)
		{
			const int x = 8, y = -4;

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1E6, 24 + x, 6 + y, Palette: 1, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1E6, 8 + x, 6 + y, Palette: 1, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1E6, -8 + x, 6 + y, Palette: 1, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1E6, -24 + x, 6 + y, Palette: 1, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1DA, 37 + x, 19 + y, Palette: 1, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x1CA, 37 + x, 11 + y, Palette: 1, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x1DA, -29 + x, 19 + y, Palette: 1, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1CA, -29 + x, 11 + y, Palette: 1, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1E8, 0 + x, 8 + y, Palette: 1, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite41(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 12, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x148, -4, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x149, 4, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x16D, 10, 2, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x17D, 10, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x17E, -3, 11, Palette: 4, VFlip: true, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x16E, -3, 19, Palette: 4, VFlip: true, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x142, 0, -7, Palette: 4, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite42(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 12, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x148, -4, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x149, 4, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x16D, 10, 2, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x17D, 10, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x17E, -3, 11, Palette: 5, VFlip: true, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x16E, -3, 19, Palette: 5, VFlip: true, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x142, 0, -7, Palette: 5, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite43(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 12, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x148, -4, 0, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x149, 4, 0, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x16D, 10, 2, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x17D, 10, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x17B, -3, 11, Palette: 3, VFlip: true, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x16B, -3, 19, Palette: 3, VFlip: true, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x142, 0, -7, Palette: 3, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite44(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 12, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x108, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x108, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x102, 0, -9, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x12F, 5, 1, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x16F, -10, -2, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x17F, -2, -2, Palette: 4, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite45(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 12, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, 0, 12, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x14D, -4, -2, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x15D, -4, 6, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x14E, 0, 1, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x14E, 0, 1, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x16C, -11, 8, Palette: 3, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x17C, -3, 8, Palette: 3, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x142, 0, -8, Palette: 3, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite46(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 12, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, 0, 12, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x14E, 0, 1, Palette: 4, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x14E, 0, 1, Palette: 4, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x142, 0, -8, Palette: 4, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x10B, 11, -2, Palette: 6, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x10B, 11, 6, Palette: 6, VFlip: true, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x03D, 18, 2, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x03A, 10, 2, Palette: 4, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite47(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x120, 0, 8, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x120, 0, 8, Palette: 1, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite48(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 12, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x108, 0, 0, Palette: 3, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x108, 0, 0, Palette: 3, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x102, 0, -9, Palette: 3, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x12F, 3, 1, Palette: 3, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x16C, 17, -2, Palette: 4, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x17C, 9, -2, Palette: 4, VFlip: false, HFlip: true, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite49(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x120, 0, 8, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x120, 0, 8, Palette: 1, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite4A(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x108, 0, 0, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x108, 0, 0, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x102, 0, -9, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x12F, 4, 1, Palette: 3, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x06E, 0, -12, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite4B(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18A, 2, 0, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x142, 0, -11, Palette: 5, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite4C(IDrawArt artist, IDrawableSprite spr)
		{
			//const int x = 8;

			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite4D(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite4E(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x140, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite4F(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x140, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite50(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x180, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite51(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1E0, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C0, 0, -16, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite52(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite53(IDrawArt artist, IDrawableSprite spr)
		{
			const int x = 8, y = 8;
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1E4, 8 + x, 12 + y, Palette: 2, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1E4, -8 + x, 12 + y, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C0, -8 + x, -8 + y, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C2, 8 + x, -8 + y, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1E0, -8 + x, 8 + y, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1E2, 8 + x, 8 + y, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite54(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 176, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, 0, 176, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, 0, 176, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, 0, 176, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, 0, 176, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, 0, 176, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, 0, 176, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, 0, 176, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1CC, 0, 176, Palette: 6, VFlip: true, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1C6, 0, 176, Palette: 6, VFlip: true, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1C6, 0, 176, Palette: 6, VFlip: true, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1C6, 0, 176, Palette: 6, VFlip: true, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1C6, 0, 176, Palette: 6, VFlip: true, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1C6, 0, 176, Palette: 6, VFlip: true, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1C6, 0, 176, Palette: 6, VFlip: true, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1C4, 0, 176, Palette: 6, VFlip: true, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite55(IDrawArt artist, IDrawableSprite spr)
		{
			//const int x = 8;

			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite56(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite57(IDrawArt artist, IDrawableSprite spr)
		{
			const int x = 8, y = 8;

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1AE, 8 + x, 8 + y, Palette: 0, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1AE, -8 + x, 8 + y, Palette: 0, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18E, 8 + x, -8 + y, Palette: 0, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x18E, -8 + x, -8 + y, Palette: 0, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite58(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18E, -8, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18E, 8, 0, Palette: 5, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite59(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1E3, 0, -64, Palette: 5, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite5A(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C5, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite5B(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x128, 0, 0, Palette: 1, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite5C(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x128, 0, 0, Palette: 1, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite5D(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x188, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x189, 16, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x189, 32, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x188, 48, 0, Palette: 6, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite5E(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x188, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x189, 16, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x189, 32, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x188, 48, 0, Palette: 6, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite5F(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x18E, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x19E, 0, 16, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x19E, 0, 32, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x19E, 0, 48, Palette: 6, VFlip: true, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x19E, 0, 64, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x19E, 0, 80, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x19E, 0, 96, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18E, 0, 112, Palette: 6, VFlip: true, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite60(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x18E, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x19E, 0, 16, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x19E, 0, 32, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x19E, 0, 48, Palette: 6, VFlip: true, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x19E, 0, 64, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x19E, 0, 80, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x19E, 0, 96, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18E, 0, 112, Palette: 6, VFlip: true, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite61(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x148, 0, -16, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x168, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite62(IDrawArt artist, IDrawableSprite spr)
		{
			const int x = 6, y = 6;

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1C3, -8 + x, -8 + y, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1C4, 0 + x, -8 + y, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1D3, -8 + x, 0 + y, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1D4, 0 + x, 0 + y, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1E0, -8 + x, 8 + y, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1F0, 0 + x, 8 + y, Palette: 4, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite63(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite64(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite65(IDrawArt artist, IDrawableSprite spr)
		{
			const int y = -8;

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10 + y, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x126, 0, 0 + y, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x106, 0, -10 + y, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x106, 0, -10 + y, Palette: 3, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite66(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x10E, 0, 0, Palette: 6, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite67(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x10E, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite68(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x10C, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite69(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x10C, 0, 0, Palette: 6, VFlip: true, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite6A(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 12, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x146, -4, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x106, 4, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x102, 0, -9, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x12F, 12, -4, Palette: 6, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x13F, 4, -2, Palette: 6, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x13F, 4, -2, Palette: 6, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x13F, 4, -2, Palette: 6, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x13F, 4, -2, Palette: 6, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x12A, 0, -6, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite6B(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x14E, -4, 0, Palette: 4, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x102, -4, -9, Palette: 4, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x126, 8, 0, Palette: 3, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x126, 8, 0, Palette: 3, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x126, 8, 0, Palette: 3, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite6C(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x04C, 0, 0, Palette: 2, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite6D(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x186, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite6E(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1A4, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite6F(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x184, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite70(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1CC, 0, 0, Palette: 1, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite71(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite72(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite73(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x120, 8, -19, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x120, -8, -19, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x108, 0, -28, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x005, 15, -4, Palette: 5, VFlip: true, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x015, 15, -12, Palette: 5, VFlip: true, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite74(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1CC, 0, 0, Palette: 7, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x12E, 0, -8, Palette: 3, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite75(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x188, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AC, 0, -7, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite76(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x022, 1, 3, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x020, 1, -7, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite77(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1E3, 4, 7, Palette: 1, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1E3, 9, 2, Palette: 1, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1E3, -1, 2, Palette: 1, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1E3, 4, -3, Palette: 1, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1E1, 4, 2, Palette: 1, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite78(IDrawArt artist, IDrawableSprite spr)
		{
			const int x = 8, y = 8;

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x128, 0 + x, 5 + y, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18E, 0 + x, -5 + y, Palette: 3, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite79(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite7A(IDrawArt artist, IDrawableSprite spr)
		{
			const int x = 8, y = 8;

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0 + x, 18 + y, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x182, -8 + x, -8 + y, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x182, 8 + x, -8 + y, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1A2, -8 + x, 8 + y, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A2, 8 + x, 8 + y, Palette: 5, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite7B(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1C6, 0, 0, Palette: 1, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite7C(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x102, 0, -9, Palette: 6, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite7D(IDrawArt artist, IDrawableSprite spr)
		{
			const int x = 8, y = 8;

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1C4, 8 + x, 8 + y, Palette: 4, VFlip: true, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1C4, -8 + x, 8 + y, Palette: 4, VFlip: true, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C4, 8 + x, -8 + y, Palette: 4, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1C4, -8 + x, -8 + y, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite7E(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x128, 0, 0, Palette: 1, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x128, 0, 0, Palette: 1, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x128, 0, 0, Palette: 1, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x128, 0, -64, Palette: 1, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite7F(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x128, 0, 0, Palette: 1, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x128, 0, 0, Palette: 1, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x128, 0, 0, Palette: 1, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x128, 0, -64, Palette: 1, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite80(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x128, 0, 0, Palette: 1, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite81(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x184, 0, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite82(IDrawArt artist, IDrawableSprite spr)
		{
			const int x = -10;

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1E3, 4 + x, 7, Palette: 1, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1E3, 9 + x, 2, Palette: 1, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1E3, -1 + x, 2, Palette: 1, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1E3, 4 + x, -3, Palette: 1, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1E1, 4 + x, 2, Palette: 1, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite83(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 14, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x19C, 4, 4, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x19C, -4, 4, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A2, 4, -4, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1A2, -4, -4, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite84(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 14, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x19C, 4, 4, Palette: 3, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x19C, -4, 4, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A2, 4, -4, Palette: 3, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1A2, -4, -4, Palette: 3, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite85(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x10A, 0, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x10A, 0, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x102, 0, -10, Palette: 5, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite86(IDrawArt artist, IDrawableSprite spr)
		{
			const int x = -5, y = 4;

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0 + x, 10 + y, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A0, 0 + x, 0 + y, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite87(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x18C, 0, 0, Palette: 1, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite88(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 16, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, 1, 16, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, 2, 16, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, 3, 16, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, 4, 16, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, -1, 16, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, -2, 16, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, -3, 16, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, -4, 16, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A8, 8, 8, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1A8, 8, 8, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1A8, -8, 8, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A8, -8, 8, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x188, 8, -8, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x188, 8, -8, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x188, -8, -8, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x188, -8, -8, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite89(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1AA, 0, 0, Palette: 1, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite8A(IDrawArt artist, IDrawableSprite spr)
		{
			const int y = -1;

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1E6, 0, 0 + y, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite8B(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18A, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x180, 0, -9, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite8C(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 6, 19, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, 0, 19, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, -6, 19, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A8, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A0, 8, -12, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1A0, -8, -12, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x180, 8, -28, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x180, -8, -28, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite8D(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1A6, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite8E(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18E, 0, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite8F(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite90(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 6, 19, Palette: 1, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, 0, 19, Palette: 1, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06C, -6, 19, Palette: 1, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A8, 4, 8, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1BA, -4, 16, Palette: 5, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1AA, 12, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1A6, -4, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite91(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite92(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1A4, -28, -12, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A2, -28, -28, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A8, -28, 28, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A6, -28, 12, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A4, 28, -4, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1A2, 28, -20, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1A8, 28, 28, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1A6, 28, 12, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1AC, 0, -40, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A0, 8, 32, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1A0, -8, 32, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18C, 24, 16, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x18E, 8, 16, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x18E, -8, 16, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18C, -24, 16, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x188, 24, 0, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x18A, 8, 0, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x18A, -8, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x188, -24, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x184, 24, -16, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x186, 8, -16, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x186, -8, -16, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x184, -24, -16, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x180, 24, -32, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x182, 8, -32, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x182, -8, -32, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x180, -24, -32, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C6, 8, 27, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1C6, -8, 27, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C2, 16, 11, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1C4, 0, 11, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C2, -16, 11, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AE, 16, -5, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1C0, 0, -5, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AE, -16, -5, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1CE, -3, 20, Palette: 5, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1CE, 11, 20, Palette: 5, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x1AC, 0, -40, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AC, 0, -40, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AC, 0, -40, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AC, 0, -40, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AC, 0, -40, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AC, 0, -40, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AC, 0, -40, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AC, 0, -40, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AC, 0, -40, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AC, 0, -40, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AC, 0, -40, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AC, 0, -40, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AC, 0, -40, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AC, 0, -40, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AC, 0, -40, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1E4, 0, -40, Palette: 5, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite93(IDrawArt artist, IDrawableSprite spr)
		{
			const int x = 8, y = 8;

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1EC, 8 + x, 8 + y, Palette: 2, VFlip: true, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1EC, -8 + x, 8 + y, Palette: 2, VFlip: true, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1EC, 8 + x, -8 + y, Palette: 2, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1EC, -8 + x, -8 + y, Palette: 2, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite94(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x187, 4, 4, Palette: 6, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite95(IDrawArt artist, IDrawableSprite spr)
		{
			// TODO offsets here are too fucking annoying
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1C8, 8, 12, Palette: 0, VFlip: true, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x1D8, 8, 4, Palette: 0, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x1C8, 8, -4, Palette: 0, VFlip: false, HFlip: true, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite96(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1C8, 0, 12, Palette: 0, VFlip: true, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1D8, 0, 4, Palette: 0, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1C8, 0, -4, Palette: 0, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite97(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1C6, 12, 8, Palette: 0, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x1C7, 4, 8, Palette: 0, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1C6, -4, 8, Palette: 0, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite98(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1C6, 12, 0, Palette: 0, VFlip: true, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x1C7, 4, 0, Palette: 0, VFlip: true, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1C6, -4, 0, Palette: 0, VFlip: true, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_Sprite99(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x188, 0, 0, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x182, 1, -8, Palette: 5, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite9A(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite9B(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite9C(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite9D(IDrawArt artist, IDrawableSprite spr)
		{
			//const int y = 8;

			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_Sprite9E(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 18, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A4, 4, 8, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A3, -4, 8, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x181, 4, -8, Palette: 3, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x180, -4, -8, Palette: 3, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_Sprite9F(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18A, 0, 0, Palette: 3, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteA0(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x186, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteA1(IDrawArt artist, IDrawableSprite spr)
		{
			const int yoff = 8;

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1A6, 8, 0 + yoff, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1A6, -8, 0 + yoff, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A6, 8, 0 + yoff, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1A6, -8, 0 + yoff, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteA2(IDrawArt artist, IDrawableSprite spr)
		{
			const int x = 8, y = 8;

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1A2, 8 + x, 8 + y, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A0, -8 + x, 8 + y, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x182, 8 + x, -8 + y, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x180, -8 + x, -8 + y, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AC, 8 + x, 0 + y, Palette: 6, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteA3(IDrawArt artist, IDrawableSprite spr)
		{
			//const int x = 8, y = 8;

			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteA4(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteA5(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A6, 0, 0, Palette: 4, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1A6, 0, 0, Palette: 4, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x182, 0, -9, Palette: 4, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteA6(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A6, 0, 0, Palette: 3, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1A6, 0, 0, Palette: 3, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x182, 0, -9, Palette: 3, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteA7(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x124, 0, 0, Palette: 4, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x12E, 3, 5, Palette: 4, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x102, 0, -10, Palette: 4, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteA8(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C6, 0, -16, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1C6, 0, -16, Palette: 5, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteA9(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C6, 0, -16, Palette: 4, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1C6, 0, -16, Palette: 4, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteAA(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C8, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C8, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteAB(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteAC(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteAD(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x022, 0, 8, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x020, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteAE(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x022, 0, 8, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x020, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteAF(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x022, 0, 8, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x020, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteB0(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x022, 0, 8, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x020, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteB1(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x022, 0, 8, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x020, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteB2(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteB3(IDrawArt artist, IDrawableSprite spr)
		{
			//const int x = 7; // only moves right in desert

			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteB4(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1EE, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteB5(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x148, 0, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteB6(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteB7(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x022, 1, 3, Palette: 7, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x020, 1, -7, Palette: 7, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteB8(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x038, 0, 11, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x126, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x120, 0, -8, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteB9(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C0, 0, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteBA(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteBB(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x120, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x102, 0, -6, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteBC(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x106, 0, 0, Palette: 0, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x122, 0, -9, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AE, 8, 2, Palette: 0, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_SpriteBD(IDrawArt artist, IDrawableSprite spr)
		{
			const int x = 8, y = -8;

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1E4, 8 + x, 8 + y, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1E4, -8 + x, 8 + y, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C4, 8 + x, -8 + y, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1C4, -8 + x, -8 + y, Palette: 5, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteBE(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1E6, 1, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteBF(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1CC, 0, 0, Palette: 0, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteC0(IDrawArt artist, IDrawableSprite spr)
		{
			//const int x = 8, y = -4;

			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteC1(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 18, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A2, 8, 8, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1A2, -8, 8, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x182, 8, -8, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x182, -8, -8, Palette: 5, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteC2(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x048, 0, 0, Palette: 0, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_SpriteC3(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x18C, -4, -12, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x18E, 12, -4, Palette: 5, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x18F, -4, -20, Palette: 5, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x18A, 4, -20, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AE, 0, -16, Palette: 5, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteC4(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x106, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x102, 0, -6, Palette: 6, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteC5(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteC6(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteC7(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A0, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A0, 0, -8, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A0, 0, -16, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A2, 0, -24, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteC8(IDrawArt artist, IDrawableSprite spr)
		{
			const int x = 8, z = 24;
			const int y = 8 + z;

			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0 + x, 10 + y, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1AE, 4 + x, -16 + y, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1AE, -4 + x, -16 + y, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18E, 4 + x, -32 + y, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x18E, -4 + x, -32 + y, Palette: 5, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteC9(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C8, 8, 0, Palette: 4, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1C8, -8, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteCA(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18B, 4, 4, Palette: 6, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x18B, 4, 4, Palette: 6, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x18B, 4, 4, Palette: 6, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x18B, 4, 4, Palette: 6, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x18B, 4, 4, Palette: 6, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x18B, 4, 4, Palette: 6, VFlip: false, HFlip: true, IsBig: false),
				new OAMDrawInfo(0x18C, 0, 0, Palette: 4, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteCB(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x12A, 36, 20, Palette: 0, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x10C, 36, 4, Palette: 0, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x12A, -20, 28, Palette: 0, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x10C, -20, 12, Palette: 0, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x12C, 32, -49, Palette: 0, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x12C, 24, -53, Palette: 0, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x128, 17, -53, Palette: 0, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x128, 11, -48, Palette: 0, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x106, 8, -40, Palette: 0, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1E0, 8, 8, Palette: 0, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1E0, -8, 8, Palette: 0, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1C0, 8, -8, Palette: 0, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1C0, -8, -8, Palette: 0, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteCC(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x10A, -14, -30, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x124, -6, -24, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x124, -22, -24, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x104, -6, -40, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x104, -22, -40, Palette: 5, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteCD(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x10A, 13, -30, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x124, 21, -24, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x124, 5, -24, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x104, 21, -40, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x104, 5, -40, Palette: 6, VFlip: false, HFlip: true, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteCE(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1A6, 19, 3, Palette: 5, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1A6, -19, 3, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x186, 0, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1A4, 8, 23, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x1A0, -8, 23, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x18E, 8, 7, Palette: 6, VFlip: false, HFlip: true, IsBig: true),
				new OAMDrawInfo(0x18E, -8, 7, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteCF(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteD0(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1E5, 4, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1E4, -4, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1CC, -5, -11, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteD1(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteD2(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteD3(IDrawArt artist, IDrawableSprite spr)
		{
			//const int y = -1;

			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteD4(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x070, 8, 4, Palette: 2, VFlip: false, HFlip: true, IsBig: false)
			);
		}

		protected static void SpriteDraw_SpriteD5(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x142, 0, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x142, 0, 0, Palette: 5, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x140, 0, -8, Palette: 5, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteD6(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteD7(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteD8(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x038, 0, 3, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x029, 0, 0, Palette: 1, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_SpriteD9(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x038, 0, 11, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x01B, 0, 8, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x00B, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_SpriteDA(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x038, 0, 11, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x01B, 0, 8, Palette: 2, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x00B, 0, 0, Palette: 2, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_SpriteDB(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x038, 0, 11, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x01B, 0, 8, Palette: 1, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x00B, 0, 0, Palette: 1, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_SpriteDC(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06E, 0, 0, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06E, 0, 0, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x068, 8, 8, Palette: 2, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_SpriteDD(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06E, 0, 0, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06E, 0, 0, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x078, 8, 8, Palette: 2, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_SpriteDE(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06E, 0, 0, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x06E, 0, 0, Palette: 2, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x079, 8, 8, Palette: 2, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_SpriteDF(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x038, 0, 3, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x060, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_SpriteE0(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x038, 0, 11, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x072, 0, 8, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x062, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_SpriteE1(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x038, 0, 11, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x063, 0, 0, Palette: 2, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x073, 0, 8, Palette: 2, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x069, 2, 8, Palette: 2, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_SpriteE2(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x038, 0, 11, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x063, 0, 0, Palette: 2, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x073, 0, 8, Palette: 2, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x06A, 2, 8, Palette: 2, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_SpriteE3(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x0EA, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteE4(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x038, 0, 11, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x07B, 0, 8, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x06B, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_SpriteE5(IDrawArt artist, IDrawableSprite spr)
		{
			const int x = 8;
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0 + x, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x024, 0 + x, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteE6(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x1EA, 0, 0, Palette: 7, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteE7(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x024, 0, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteE8(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x1F5, 4, 8, Palette: 4, VFlip: false, HFlip: false, IsBig: false),
				new OAMDrawInfo(0x1F4, 4, 0, Palette: 4, VFlip: false, HFlip: false, IsBig: false)
			);
		}

		protected static void SpriteDraw_SpriteE9(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x110, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x100, 0, -8, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteEA(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x024, 0, 0, Palette: 1, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteEB(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x0E0, 0, 0, Palette: 1, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteEC(IDrawArt artist, IDrawableSprite spr)
		{
			DrawTiles(artist, spr,
				new OAMDrawInfo(0x06C, 0, 10, Palette: 4, VFlip: false, HFlip: false, IsBig: true),
				new OAMDrawInfo(0x042, 0, 0, Palette: 6, VFlip: false, HFlip: false, IsBig: true)
			);
		}

		protected static void SpriteDraw_SpriteED(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteEE(IDrawArt artist, IDrawableSprite spr)
		{
			//const int x = 8, y = 3;

			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteEF(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteF0(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteF1(IDrawArt artist, IDrawableSprite spr)
		{
			//DrawTiles(artist, spr,
		}

		protected static void SpriteDraw_SpriteF2(IDrawArt artist, IDrawableSprite spr)
		{
			//const int x = 8; // but only if not ether tablet

			//DrawTiles(artist, spr,
		}


		protected static void SpriteDraw_Overlord01(IDrawArt artist, IDrawableSprite spr)
		{
			throw new NotImplementedException();
		}

		protected static void SpriteDraw_Overlord02(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord03(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord04(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord05(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord06(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord07(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord08(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord09(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord0A(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord0B(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord0C(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord0D(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord0E(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord0F(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord10(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord11(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord12(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord13(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord14(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord15(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord16(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord17(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord18(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord19(IDrawArt artist, IDrawableSprite spr) { }

		protected static void SpriteDraw_Overlord1A(IDrawArt artist, IDrawableSprite spr) { }

	}
}
