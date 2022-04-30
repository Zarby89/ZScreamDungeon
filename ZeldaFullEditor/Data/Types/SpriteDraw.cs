using System;
using ZeldaFullEditor.Data.Underworld;

namespace ZeldaFullEditor.Data
{
	public delegate void DrawSprite(ZScreamer ZS, IDrawableSprite spr);

	// NOTE: consts in these draw functions indicate a global offset from the sprite's ROM coordinates that occurs when the game runs
	public partial class SpriteType
	{
		public static unsafe void DrawTiles(ZScreamer ZS, IDrawableSprite spr, params OAMDrawInfo[] instructions)
		{
			var alltilesData = (spr is OverworldSprite)
				? (byte*) ZS.GFXManager.currentOWgfx16Ptr.ToPointer()
				: (byte*) ZS.GFXManager.currentgfx16Ptr.ToPointer();

			byte* ptr;

			int mult;
			int maxIndex;

			int xoff = 0;
			int yoff = 0;

			if (spr is SpritePreview)
			{
				if (ZS.GFXManager.useOverworldGFX)
				{
					alltilesData = (byte*) ZS.GFXManager.currentOWgfx16Ptr.ToPointer();
				}

				xoff = 16;
				yoff = 16;

				mult = 64;
				ptr = (byte*) ZS.GFXManager.previewSpritesPtr[spr.ID].ToPointer();
				maxIndex = 4096;
			}
			else
			{
				mult = 512;
				ptr = (byte*) ZS.GFXManager.roomBg1Ptr.ToPointer();
				maxIndex = 262144;
			}

			foreach (OAMDrawInfo ti in instructions)
			{
				int size = ti.RectSideSize;
				byte r = (byte) (ti.HFlip ? 1 : 0);
				int tx = (ti.TileIndex / 16 * 512) + ((ti.TileIndex & 0xF) << 2); // TODO verify
				int indexoff = spr.RealX + ti.XOff + xoff + (mult * (spr.RealY + ti.YOff + yoff));
				byte pal = (byte) (ti.Palette << 3);


				for (int yl = 0, yl2 = tx; yl < size; yl++, yl2 += 64)
				{
					int my = (mult * (ti.VFlip ? size - 1 - yl : yl)) + indexoff; // this is alltilesData additive, so it can go here

					for (int xl = 0, xl2 = yl2; xl < size; xl++, xl2++)
					{
						int mx = ti.HFlip ? size - 1 - xl : xl;
						var pixel = alltilesData[xl2];
						int index = (mx * 2) + my;

						if (index >= 0 && index <= maxIndex)
						{
							if (pixel.BitIsOn(0x0F))
							{
								ptr[index + r ^ 1] = (byte) ((pixel & 0x0F) + 112 + pal);
							}
							if (pixel.BitIsOn(0xF0))
							{
								ptr[index + r] = (byte) ((pixel >> 4) + 112 + pal);
							}
						}
					}
				}
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

		public static void SpriteDraw_SmallKeyDrop(ZScreamer ZS, IDrawableSprite spr)
		{
			throw new NotImplementedException();
		}

		public static void SpriteDraw_BigKeyDrop(ZScreamer ZS, IDrawableSprite spr)
		{
			throw new NotImplementedException();
		}

		public static void SpriteDraw_GreenRupeeDrop(ZScreamer ZS, IDrawableSprite spr)
		{
			throw new NotImplementedException();
		}










		public static void SpriteDraw_Sprite00(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, -32, -22, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1C8, -32, -32, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite01(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x186, 8, 0, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x186, -8, 0, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite02(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x100, 0, 0, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite03(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x100, 0, 0, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite04(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1CE, 0, 0, pal: 0x00, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1EE, 0, -1, pal: 0x00, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite05(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1D2, -4, -3, pal: 0x00, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x1D2, 12, -3, pal: 0x00, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1C4, 0, 0, pal: 0x00, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1E4, -4, 5, pal: 0x00, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1E4, 4, 5, pal: 0x00, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite06(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1CE, 0, 0, pal: 0x00, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1EE, 0, -1, pal: 0x00, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite07(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1A2, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A4, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite08(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A0, 0, 0, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1BB, 8, 6, pal: 0x06, vflip: false, hflip: true, big: false)
			);
		}

		public static void SpriteDraw_Sprite09(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x18C, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x188, 0, 0, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A6, 8, 8, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A4, -8, 8, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x186, 8, -8, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x184, -8, -8, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A6, 8, 8, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A4, -8, 8, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x186, 8, -8, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x184, -8, -8, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A2, 8, 8, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A0, -8, 8, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x182, 8, -8, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x180, -8, -8, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AA, 15, 6, pal: 0x00, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A8, 15, -6, pal: 0x00, vflip: true, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite0A(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A0, 0, 0, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1BB, 8, 6, pal: 0x06, vflip: false, hflip: true, big: false)
			);
		}

		public static void SpriteDraw_Sprite0B(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1EA, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite0C(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x184, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite0D(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1F0, 0, -8, pal: 0x05, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1F0, 8, -8, pal: 0x05, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x1E1, 0, 0, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite0E(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18C, 4, 0, pal: 0x04, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x18D, -4, 0, pal: 0x04, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x18F, 4, -8, pal: 0x04, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x19F, -4, -8, pal: 0x04, vflip: false, hflip: true, big: false)
			);
		}

		public static void SpriteDraw_Sprite0F(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18C, -4, -20, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18C, 4, -20, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x19C, -4, -12, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x19C, 4, -12, pal: 0x06, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite10(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x038, 0, 3, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1BD, 0, 0, pal: 0x06, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite11(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x106, 0, 1, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x124, 8, -5, pal: 0x03, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x124, -8, -5, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x100, 0, -13, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite12(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18A, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x188, 0, -10, pal: 0x04, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x190, -2, 11, pal: 0x04, vflip: true, hflip: false, big: false),
				new OAMDrawInfo(0x191, -2, 3, pal: 0x04, vflip: true, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite13(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x166, 0, 0, pal: 0x00, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite14(ZScreamer ZS, IDrawableSprite spr)
		{
			//const int y = -8;

			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite15(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1E3, 4, 7, pal: 0x01, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1E3, 9, 2, pal: 0x01, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1E3, -1, 2, pal: 0x01, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1E3, 4, -3, pal: 0x01, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1E1, 4, 2, pal: 0x01, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite16(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A2, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A0, 0, -9, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite17(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x046, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x046, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite18(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x15D, 4, 4, pal: 0x03, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x162, 0, 0, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x160, 0, 0, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x14D, 10, 6, pal: 0x03, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x14D, 10, 1, pal: 0x03, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite19(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1E6, 0, -12, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x07C, 9, -3, pal: 0x01, vflip: false, hflip: true, big: false)
			);
		}

		public static void SpriteDraw_Sprite1A(ZScreamer ZS, IDrawableSprite spr)
		{
			//const int x = 2, y = -3; // TODO only applies in light world

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x160, -11, -10, pal: 0x04, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x140, 1, 0, pal: 0x04, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite1B(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x03A, -8, 0, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x03D, 0, 0, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite1C(ZScreamer ZS, IDrawableSprite spr)
		{
			const int y = 7;

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1C0, 0, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1C2, 8, -8 + y, pal: 0x06, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x1C2, 0, -8 + y, pal: 0x06, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite1D(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite1E(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1E4, 0, 0, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite1F(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x10A, 8, 14, pal: 0x06, vflip: true, hflip: true, big: true),
				new OAMDrawInfo(0x10A, -8, 14, pal: 0x06, vflip: true, hflip: false, big: true),
				new OAMDrawInfo(0x10A, 8, 6, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x10A, -8, 6, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x10E, 0, -5, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x127, 4, 0, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite20(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x182, 0, 0, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite21(ZScreamer ZS, IDrawableSprite spr)
		{
			const int y = 5;

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1CA, 0, 0 + y, pal: 0x00, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1DD, 4, 12 + y, pal: 0x00, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1DD, 4, 12 + y, pal: 0x00, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1DD, 4, 12 + y, pal: 0x00, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1DC, 4, 20 + y, pal: 0x00, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite22(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x108, 0, 0, pal: 0x01, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x127, 8, -8, pal: 0x01, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x126, 0, -8, pal: 0x01, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite23(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x132, 8, 2, pal: 0x01, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x132, 0, 2, pal: 0x01, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x122, 8, -6, pal: 0x01, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x122, 0, -6, pal: 0x01, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite24(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x132, 8, 2, pal: 0x02, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x132, 0, 2, pal: 0x02, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x122, 8, -6, pal: 0x02, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x122, 0, -6, pal: 0x02, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite25(ZScreamer ZS, IDrawableSprite spr)
		{
			//const int x = -8;
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite26(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x142, 0, 2, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x140, 0, -4, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite27(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1C2, 0, 0, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite28(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x14A, 0, 0, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite29(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x188, 0, 0, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x186, 0, -7, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite2A(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18A, 0, 5, pal: 0x07, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18E, 0, -7, pal: 0x07, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite2B(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1A7, 3, 3, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A6, -5, 3, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A7, 3, 3, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A6, -5, 3, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite2C(ZScreamer ZS, IDrawableSprite spr)
		{
			const int x = 8;

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1A4, 31 + x, 4, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A8, 30 + x, -8, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A6, -32 + x, 4, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1A8, -32 + x, -8, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1BE, 25 + x, 5, pal: 0x04, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x1BF, 17 + x, 5, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1BF, 9 + x, 5, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1BF, 1 + x, 5, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1BF, -7 + x, 5, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1BF, -15 + x, 5, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1BE, -23 + x, 5, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite2D(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AA, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x182, 0, -16, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AE, 4, -14, pal: 0x06, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite2E(ZScreamer ZS, IDrawableSprite spr)
		{
			const int x = 8; // is 7 in light world but whatever

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1AA, 0 + x, 0, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A8, 0 + x, -10, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AA, 0 + x, 0, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite2F(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1E8, 0, 0, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1E0, 0, -8, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite30(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x120, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x100, 0, -10, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite31(ZScreamer ZS, IDrawableSprite spr)
		{
			const int x = 8, y = 8;

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x12C, 8 + x, -32 + y, pal: 0x06, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x12C, 0 + x, -32 + y, pal: 0x06, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x10C, 0 + x, -48 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite32(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x10A, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x104, 0, -12, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite33(ZScreamer ZS, IDrawableSprite spr)
		{
			//const int x = -8;

			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite34(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1E4, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x128, 0, -8, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite35(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1CA, 0, 0, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1C4, 0, -8, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite36(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x184, 0, 4, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x186, -3, 15, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x186, -11, 15, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x180, 0, -4, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1BE, -3, 16, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1AE, -3, 8, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite37(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite38(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite39(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1EC, 0, 0, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1EA, 0, -8, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite3A(ZScreamer ZS, IDrawableSprite spr)
		{
			//const int x = 8;

			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite3B(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x038, 0, 11, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x07B, 0, 8, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x06B, 0, 0, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite3C(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AA, 0, 0, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x182, 0, -8, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite3D(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1E4, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1E2, 0, -8, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite3E(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x044, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x044, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite3F(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 12, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x14E, 0, 0, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x142, 0, -9, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x139, 15, -11, pal: 0x04, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x12A, 15, -3, pal: 0x04, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x13A, 15, 5, pal: 0x04, vflip: false, hflip: true, big: false)
			);
		}

		public static void SpriteDraw_Sprite40(ZScreamer ZS, IDrawableSprite spr)
		{
			const int x = 8, y = -4;

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1E6, 24 + x, 6 + y, pal: 0x01, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1E6, 8 + x, 6 + y, pal: 0x01, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1E6, -8 + x, 6 + y, pal: 0x01, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1E6, -24 + x, 6 + y, pal: 0x01, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1DA, 37 + x, 19 + y, pal: 0x01, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x1CA, 37 + x, 11 + y, pal: 0x01, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x1DA, -29 + x, 19 + y, pal: 0x01, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1CA, -29 + x, 11 + y, pal: 0x01, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1E8, 0 + x, 8 + y, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite41(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 12, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x148, -4, 0, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x149, 4, 0, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x16D, 10, 2, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x17D, 10, 10, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x17E, -3, 11, pal: 0x04, vflip: true, hflip: false, big: false),
				new OAMDrawInfo(0x16E, -3, 19, pal: 0x04, vflip: true, hflip: false, big: false),
				new OAMDrawInfo(0x142, 0, -7, pal: 0x04, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite42(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 12, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x148, -4, 0, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x149, 4, 0, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x16D, 10, 2, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x17D, 10, 10, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x17E, -3, 11, pal: 0x05, vflip: true, hflip: false, big: false),
				new OAMDrawInfo(0x16E, -3, 19, pal: 0x05, vflip: true, hflip: false, big: false),
				new OAMDrawInfo(0x142, 0, -7, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite43(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 12, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x148, -4, 0, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x149, 4, 0, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x16D, 10, 2, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x17D, 10, 10, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x17B, -3, 11, pal: 0x03, vflip: true, hflip: false, big: false),
				new OAMDrawInfo(0x16B, -3, 19, pal: 0x03, vflip: true, hflip: false, big: false),
				new OAMDrawInfo(0x142, 0, -7, pal: 0x03, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite44(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 12, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x108, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x108, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x102, 0, -9, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x12F, 5, 1, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x16F, -10, -2, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x17F, -2, -2, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite45(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 12, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, 0, 12, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x14D, -4, -2, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x15D, -4, 6, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x14E, 0, 1, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x14E, 0, 1, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x16C, -11, 8, pal: 0x03, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x17C, -3, 8, pal: 0x03, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x142, 0, -8, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite46(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 12, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, 0, 12, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x14E, 0, 1, pal: 0x04, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x14E, 0, 1, pal: 0x04, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x142, 0, -8, pal: 0x04, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x10B, 11, -2, pal: 0x06, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x10B, 11, 6, pal: 0x06, vflip: true, hflip: true, big: false),
				new OAMDrawInfo(0x03D, 18, 2, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x03A, 10, 2, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite47(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x120, 0, 8, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x120, 0, 8, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite48(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 12, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x108, 0, 0, pal: 0x03, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x108, 0, 0, pal: 0x03, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x102, 0, -9, pal: 0x03, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x12F, 3, 1, pal: 0x03, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x16C, 17, -2, pal: 0x04, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x17C, 9, -2, pal: 0x04, vflip: false, hflip: true, big: false)
			);
		}

		public static void SpriteDraw_Sprite49(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x120, 0, 8, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x120, 0, 8, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite4A(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x108, 0, 0, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x108, 0, 0, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x102, 0, -9, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x12F, 4, 1, pal: 0x03, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x06E, 0, -12, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite4B(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18A, 2, 0, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x142, 0, -11, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite4C(ZScreamer ZS, IDrawableSprite spr)
		{
			//const int x = 8;

			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite4D(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite4E(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x140, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite4F(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x140, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite50(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x180, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite51(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1E0, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1C0, 0, -16, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite52(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite53(ZScreamer ZS, IDrawableSprite spr)
		{
			const int x = 8, y = 8;
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1E4, 8 + x, 12 + y, pal: 0x02, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1E4, -8 + x, 12 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1C0, -8 + x, -8 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1C2, 8 + x, -8 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1E0, -8 + x, 8 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1E2, 8 + x, 8 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite54(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 176, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, 0, 176, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, 0, 176, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, 0, 176, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, 0, 176, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, 0, 176, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, 0, 176, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, 0, 176, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1CC, 0, 176, pal: 0x06, vflip: true, hflip: true, big: true),
				new OAMDrawInfo(0x1C6, 0, 176, pal: 0x06, vflip: true, hflip: true, big: true),
				new OAMDrawInfo(0x1C6, 0, 176, pal: 0x06, vflip: true, hflip: true, big: true),
				new OAMDrawInfo(0x1C6, 0, 176, pal: 0x06, vflip: true, hflip: true, big: true),
				new OAMDrawInfo(0x1C6, 0, 176, pal: 0x06, vflip: true, hflip: true, big: true),
				new OAMDrawInfo(0x1C6, 0, 176, pal: 0x06, vflip: true, hflip: true, big: true),
				new OAMDrawInfo(0x1C6, 0, 176, pal: 0x06, vflip: true, hflip: true, big: true),
				new OAMDrawInfo(0x1C4, 0, 176, pal: 0x06, vflip: true, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite55(ZScreamer ZS, IDrawableSprite spr)
		{
			//const int x = 8;

			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite56(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite57(ZScreamer ZS, IDrawableSprite spr)
		{
			const int x = 8, y = 8;

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1AE, 8 + x, 8 + y, pal: 0x00, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1AE, -8 + x, 8 + y, pal: 0x00, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18E, 8 + x, -8 + y, pal: 0x00, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x18E, -8 + x, -8 + y, pal: 0x00, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite58(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18E, -8, 0, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18E, 8, 0, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite59(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1E3, 0, -64, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite5A(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1C5, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite5B(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x128, 0, 0, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite5C(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x128, 0, 0, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite5D(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x188, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x189, 16, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x189, 32, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x188, 48, 0, pal: 0x06, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite5E(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x188, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x189, 16, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x189, 32, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x188, 48, 0, pal: 0x06, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite5F(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x18E, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x19E, 0, 16, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x19E, 0, 32, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x19E, 0, 48, pal: 0x06, vflip: true, hflip: false, big: true),
				new OAMDrawInfo(0x19E, 0, 64, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x19E, 0, 80, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x19E, 0, 96, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18E, 0, 112, pal: 0x06, vflip: true, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite60(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x18E, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x19E, 0, 16, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x19E, 0, 32, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x19E, 0, 48, pal: 0x06, vflip: true, hflip: false, big: true),
				new OAMDrawInfo(0x19E, 0, 64, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x19E, 0, 80, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x19E, 0, 96, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18E, 0, 112, pal: 0x06, vflip: true, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite61(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x148, 0, -16, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x168, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite62(ZScreamer ZS, IDrawableSprite spr)
		{
			const int x = 6, y = 6;

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1C3, -8 + x, -8 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1C4, 0 + x, -8 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1D3, -8 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1D4, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1E0, -8 + x, 8 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1F0, 0 + x, 8 + y, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite63(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite64(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite65(ZScreamer ZS, IDrawableSprite spr)
		{
			const int y = -8;

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x126, 0, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x106, 0, -10 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x106, 0, -10 + y, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite66(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x10E, 0, 0, pal: 0x06, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite67(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x10E, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite68(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x10C, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite69(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x10C, 0, 0, pal: 0x06, vflip: true, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite6A(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 12, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x146, -4, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x106, 4, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x102, 0, -9, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x12F, 12, -4, pal: 0x06, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x13F, 4, -2, pal: 0x06, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x13F, 4, -2, pal: 0x06, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x13F, 4, -2, pal: 0x06, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x13F, 4, -2, pal: 0x06, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x12A, 0, -6, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite6B(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x14E, -4, 0, pal: 0x04, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x102, -4, -9, pal: 0x04, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x126, 8, 0, pal: 0x03, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x126, 8, 0, pal: 0x03, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x126, 8, 0, pal: 0x03, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite6C(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x04C, 0, 0, pal: 0x02, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite6D(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x186, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite6E(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1A4, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite6F(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x184, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite70(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1CC, 0, 0, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite71(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite72(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite73(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x120, 8, -19, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x120, -8, -19, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x108, 0, -28, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x005, 15, -4, pal: 0x05, vflip: true, hflip: false, big: false),
				new OAMDrawInfo(0x015, 15, -12, pal: 0x05, vflip: true, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite74(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1CC, 0, 0, pal: 0x07, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x12E, 0, -8, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite75(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x188, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AC, 0, -7, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite76(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x022, 1, 3, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x020, 1, -7, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite77(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1E3, 4, 7, pal: 0x01, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1E3, 9, 2, pal: 0x01, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1E3, -1, 2, pal: 0x01, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1E3, 4, -3, pal: 0x01, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1E1, 4, 2, pal: 0x01, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite78(ZScreamer ZS, IDrawableSprite spr)
		{
			const int x = 8, y = 8;

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x128, 0 + x, 5 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18E, 0 + x, -5 + y, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite79(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite7A(ZScreamer ZS, IDrawableSprite spr)
		{
			const int x = 8, y = 8;

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0 + x, 18 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x182, -8 + x, -8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x182, 8 + x, -8 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1A2, -8 + x, 8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A2, 8 + x, 8 + y, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite7B(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1C6, 0, 0, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite7C(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x102, 0, -9, pal: 0x06, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite7D(ZScreamer ZS, IDrawableSprite spr)
		{
			const int x = 8, y = 8;

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1C4, 8 + x, 8 + y, pal: 0x04, vflip: true, hflip: true, big: true),
				new OAMDrawInfo(0x1C4, -8 + x, 8 + y, pal: 0x04, vflip: true, hflip: false, big: true),
				new OAMDrawInfo(0x1C4, 8 + x, -8 + y, pal: 0x04, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1C4, -8 + x, -8 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite7E(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x128, 0, 0, pal: 0x01, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x128, 0, 0, pal: 0x01, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x128, 0, 0, pal: 0x01, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x128, 0, -64, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite7F(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x128, 0, 0, pal: 0x01, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x128, 0, 0, pal: 0x01, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x128, 0, 0, pal: 0x01, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x128, 0, -64, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite80(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x128, 0, 0, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite81(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x184, 0, 0, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite82(ZScreamer ZS, IDrawableSprite spr)
		{
			const int x = -10;

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1E3, 4 + x, 7, pal: 0x01, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1E3, 9 + x, 2, pal: 0x01, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1E3, -1 + x, 2, pal: 0x01, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1E3, 4 + x, -3, pal: 0x01, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1E1, 4 + x, 2, pal: 0x01, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite83(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 14, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x19C, 4, 4, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x19C, -4, 4, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A2, 4, -4, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1A2, -4, -4, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite84(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 14, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x19C, 4, 4, pal: 0x03, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x19C, -4, 4, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A2, 4, -4, pal: 0x03, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1A2, -4, -4, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite85(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x10A, 0, 0, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x10A, 0, 0, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x102, 0, -10, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite86(ZScreamer ZS, IDrawableSprite spr)
		{
			const int x = -5, y = 4;

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A0, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite87(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x18C, 0, 0, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite88(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 16, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, 1, 16, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, 2, 16, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, 3, 16, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, 4, 16, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, -1, 16, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, -2, 16, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, -3, 16, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, -4, 16, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A8, 8, 8, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1A8, 8, 8, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1A8, -8, 8, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A8, -8, 8, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x188, 8, -8, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x188, 8, -8, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x188, -8, -8, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x188, -8, -8, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite89(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1AA, 0, 0, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite8A(ZScreamer ZS, IDrawableSprite spr)
		{
			const int y = -1;

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1E6, 0, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite8B(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18A, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x180, 0, -9, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite8C(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 6, 19, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, 0, 19, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, -6, 19, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A8, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A0, 8, -12, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1A0, -8, -12, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x180, 8, -28, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x180, -8, -28, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite8D(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1A6, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite8E(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18E, 0, 0, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite8F(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite90(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 6, 19, pal: 0x01, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, 0, 19, pal: 0x01, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06C, -6, 19, pal: 0x01, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A8, 4, 8, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1BA, -4, 16, pal: 0x05, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1AA, 12, 0, pal: 0x05, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1A6, -4, 0, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite91(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite92(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1A4, -28, -12, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A2, -28, -28, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A8, -28, 28, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A6, -28, 12, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A4, 28, -4, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1A2, 28, -20, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1A8, 28, 28, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1A6, 28, 12, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1AC, 0, -40, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A0, 8, 32, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1A0, -8, 32, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18C, 24, 16, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x18E, 8, 16, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x18E, -8, 16, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18C, -24, 16, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x188, 24, 0, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x18A, 8, 0, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x18A, -8, 0, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x188, -24, 0, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x184, 24, -16, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x186, 8, -16, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x186, -8, -16, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x184, -24, -16, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x180, 24, -32, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x182, 8, -32, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x182, -8, -32, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x180, -24, -32, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1C6, 8, 27, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1C6, -8, 27, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1C2, 16, 11, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1C4, 0, 11, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1C2, -16, 11, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AE, 16, -5, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1C0, 0, -5, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AE, -16, -5, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1CE, -3, 20, pal: 0x05, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1CE, 11, 20, pal: 0x05, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x1AC, 0, -40, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AC, 0, -40, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AC, 0, -40, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AC, 0, -40, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AC, 0, -40, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AC, 0, -40, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AC, 0, -40, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AC, 0, -40, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AC, 0, -40, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AC, 0, -40, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AC, 0, -40, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AC, 0, -40, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AC, 0, -40, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AC, 0, -40, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AC, 0, -40, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1E4, 0, -40, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite93(ZScreamer ZS, IDrawableSprite spr)
		{
			const int x = 8, y = 8;

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1EC, 8 + x, 8 + y, pal: 0x02, vflip: true, hflip: true, big: true),
				new OAMDrawInfo(0x1EC, -8 + x, 8 + y, pal: 0x02, vflip: true, hflip: false, big: true),
				new OAMDrawInfo(0x1EC, 8 + x, -8 + y, pal: 0x02, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1EC, -8 + x, -8 + y, pal: 0x02, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite94(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x187, 4, 4, pal: 0x06, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite95(ZScreamer ZS, IDrawableSprite spr)
		{
			// TODO offsets here are too fucking annoying
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1C8, 8, 12, pal: 0x00, vflip: true, hflip: true, big: false),
				new OAMDrawInfo(0x1D8, 8, 4, pal: 0x00, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x1C8, 8, -4, pal: 0x00, vflip: false, hflip: true, big: false)
			);
		}

		public static void SpriteDraw_Sprite96(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1C8, 0, 12, pal: 0x00, vflip: true, hflip: false, big: false),
				new OAMDrawInfo(0x1D8, 0, 4, pal: 0x00, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1C8, 0, -4, pal: 0x00, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite97(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1C6, 12, 8, pal: 0x00, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x1C7, 4, 8, pal: 0x00, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1C6, -4, 8, pal: 0x00, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite98(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1C6, 12, 0, pal: 0x00, vflip: true, hflip: true, big: false),
				new OAMDrawInfo(0x1C7, 4, 0, pal: 0x00, vflip: true, hflip: false, big: false),
				new OAMDrawInfo(0x1C6, -4, 0, pal: 0x00, vflip: true, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite99(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x188, 0, 0, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x182, 1, -8, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite9A(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite9B(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite9C(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite9D(ZScreamer ZS, IDrawableSprite spr)
		{
			//const int y = 8;

			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite9E(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 18, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A4, 4, 8, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A3, -4, 8, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x181, 4, -8, pal: 0x03, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x180, -4, -8, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite9F(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18A, 0, 0, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteA0(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x186, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteA1(ZScreamer ZS, IDrawableSprite spr)
		{
			const int yoff = 8;

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1A6, 8, 0 + yoff, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1A6, -8, 0 + yoff, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A6, 8, 0 + yoff, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1A6, -8, 0 + yoff, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteA2(ZScreamer ZS, IDrawableSprite spr)
		{
			const int x = 8, y = 8;

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1A2, 8 + x, 8 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A0, -8 + x, 8 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x182, 8 + x, -8 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x180, -8 + x, -8 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AC, 8 + x, 0 + y, pal: 0x06, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteA3(ZScreamer ZS, IDrawableSprite spr)
		{
			//const int x = 8, y = 8;

			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteA4(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteA5(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A6, 0, 0, pal: 0x04, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1A6, 0, 0, pal: 0x04, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x182, 0, -9, pal: 0x04, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteA6(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A6, 0, 0, pal: 0x03, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1A6, 0, 0, pal: 0x03, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x182, 0, -9, pal: 0x03, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteA7(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x124, 0, 0, pal: 0x04, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x12E, 3, 5, pal: 0x04, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x102, 0, -10, pal: 0x04, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteA8(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1C6, 0, -16, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1C6, 0, -16, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteA9(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1C6, 0, -16, pal: 0x04, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1C6, 0, -16, pal: 0x04, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteAA(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1C8, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1C8, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteAB(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteAC(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteAD(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x022, 0, 8, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x020, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteAE(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x022, 0, 8, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x020, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteAF(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x022, 0, 8, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x020, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteB0(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x022, 0, 8, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x020, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteB1(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x022, 0, 8, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x020, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteB2(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteB3(ZScreamer ZS, IDrawableSprite spr)
		{
			//const int x = 7; // only moves right in desert

			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteB4(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1EE, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteB5(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x148, 0, 0, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteB6(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteB7(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x022, 1, 3, pal: 0x07, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x020, 1, -7, pal: 0x07, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteB8(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x038, 0, 11, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x126, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x120, 0, -8, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteB9(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1C0, 0, 0, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteBA(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteBB(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x120, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x102, 0, -6, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteBC(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x106, 0, 0, pal: 0x00, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x122, 0, -9, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AE, 8, 2, pal: 0x00, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteBD(ZScreamer ZS, IDrawableSprite spr)
		{
			const int x = 8, y = -8;

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1E4, 8 + x, 8 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1E4, -8 + x, 8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1C4, 8 + x, -8 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1C4, -8 + x, -8 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteBE(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1E6, 1, 0, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteBF(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1CC, 0, 0, pal: 0x00, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteC0(ZScreamer ZS, IDrawableSprite spr)
		{
			//const int x = 8, y = -4;

			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteC1(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 18, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A2, 8, 8, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1A2, -8, 8, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x182, 8, -8, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x182, -8, -8, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteC2(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x048, 0, 0, pal: 0x00, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteC3(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x18C, -4, -12, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x18E, 12, -4, pal: 0x05, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x18F, -4, -20, pal: 0x05, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x18A, 4, -20, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AE, 0, -16, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteC4(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x106, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x102, 0, -6, pal: 0x06, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteC5(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteC6(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteC7(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A0, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A0, 0, -8, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A0, 0, -16, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A2, 0, -24, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteC8(ZScreamer ZS, IDrawableSprite spr)
		{
			const int x = 8, z = 24;
			const int y = 8 + z;

			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1AE, 4 + x, -16 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1AE, -4 + x, -16 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18E, 4 + x, -32 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x18E, -4 + x, -32 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteC9(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1C8, 8, 0, pal: 0x04, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1C8, -8, 0, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteCA(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18B, 4, 4, pal: 0x06, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x18B, 4, 4, pal: 0x06, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x18B, 4, 4, pal: 0x06, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x18B, 4, 4, pal: 0x06, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x18B, 4, 4, pal: 0x06, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x18B, 4, 4, pal: 0x06, vflip: false, hflip: true, big: false),
				new OAMDrawInfo(0x18C, 0, 0, pal: 0x04, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteCB(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x12A, 36, 20, pal: 0x00, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x10C, 36, 4, pal: 0x00, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x12A, -20, 28, pal: 0x00, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x10C, -20, 12, pal: 0x00, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x12C, 32, -49, pal: 0x00, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x12C, 24, -53, pal: 0x00, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x128, 17, -53, pal: 0x00, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x128, 11, -48, pal: 0x00, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x106, 8, -40, pal: 0x00, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1E0, 8, 8, pal: 0x00, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1E0, -8, 8, pal: 0x00, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1C0, 8, -8, pal: 0x00, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1C0, -8, -8, pal: 0x00, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteCC(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x10A, -14, -30, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x124, -6, -24, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x124, -22, -24, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x104, -6, -40, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x104, -22, -40, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteCD(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x10A, 13, -30, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x124, 21, -24, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x124, 5, -24, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x104, 21, -40, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x104, 5, -40, pal: 0x06, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteCE(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1A6, 19, 3, pal: 0x05, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1A6, -19, 3, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x186, 0, 0, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1A4, 8, 23, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x1A0, -8, 23, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x18E, 8, 7, pal: 0x06, vflip: false, hflip: true, big: true),
				new OAMDrawInfo(0x18E, -8, 7, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteCF(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteD0(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1E5, 4, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1E4, -4, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1CC, -5, -11, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteD1(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteD2(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteD3(ZScreamer ZS, IDrawableSprite spr)
		{
			//const int y = -1;

			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteD4(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x070, 8, 4, pal: 0x02, vflip: false, hflip: true, big: false)
			);
		}

		public static void SpriteDraw_SpriteD5(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x142, 0, 0, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x142, 0, 0, pal: 0x05, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x140, 0, -8, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteD6(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteD7(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteD8(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x038, 0, 3, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x029, 0, 0, pal: 0x01, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteD9(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x038, 0, 11, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x01B, 0, 8, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x00B, 0, 0, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteDA(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x038, 0, 11, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x01B, 0, 8, pal: 0x02, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x00B, 0, 0, pal: 0x02, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteDB(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x038, 0, 11, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x01B, 0, 8, pal: 0x01, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x00B, 0, 0, pal: 0x01, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteDC(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06E, 0, 0, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06E, 0, 0, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x068, 8, 8, pal: 0x02, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteDD(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06E, 0, 0, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06E, 0, 0, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x078, 8, 8, pal: 0x02, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteDE(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06E, 0, 0, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x06E, 0, 0, pal: 0x02, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x079, 8, 8, pal: 0x02, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteDF(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x038, 0, 3, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x060, 0, 0, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteE0(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x038, 0, 11, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x072, 0, 8, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x062, 0, 0, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteE1(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x038, 0, 11, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x063, 0, 0, pal: 0x02, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x073, 0, 8, pal: 0x02, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x069, 2, 8, pal: 0x02, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteE2(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x038, 0, 11, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x063, 0, 0, pal: 0x02, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x073, 0, 8, pal: 0x02, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x06A, 2, 8, pal: 0x02, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteE3(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x0EA, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteE4(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x038, 0, 11, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x07B, 0, 8, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x06B, 0, 0, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteE5(ZScreamer ZS, IDrawableSprite spr)
		{
			const int x = 8;
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0 + x, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x024, 0 + x, 0, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteE6(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x1EA, 0, 0, pal: 0x07, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteE7(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x024, 0, 0, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteE8(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x1F5, 4, 8, pal: 0x04, vflip: false, hflip: false, big: false),
				new OAMDrawInfo(0x1F4, 4, 0, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteE9(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x110, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x100, 0, -8, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteEA(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x024, 0, 0, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteEB(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x0E0, 0, 0, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteEC(ZScreamer ZS, IDrawableSprite spr)
		{
			DrawTiles(ZS, spr,
				new OAMDrawInfo(0x06C, 0, 10, pal: 0x04, vflip: false, hflip: false, big: true),
				new OAMDrawInfo(0x042, 0, 0, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteED(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteEE(ZScreamer ZS, IDrawableSprite spr)
		{
			//const int x = 8, y = 3;

			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteEF(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteF0(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteF1(ZScreamer ZS, IDrawableSprite spr)
		{
			//DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteF2(ZScreamer ZS, IDrawableSprite spr)
		{
			//const int x = 8; // but only if not ether tablet

			//DrawTiles(ZS, spr,
		}



#pragma warning disable IDE0060 // Remove unused parameter
		public static void SpriteDraw_Overlord01(ZScreamer ZS, IDrawableSprite spr)
		{
			throw new NotImplementedException();
		}

		public static void SpriteDraw_Overlord02(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord03(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord04(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord05(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord06(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord07(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord08(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord09(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord0A(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord0B(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord0C(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord0D(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord0E(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord0F(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord10(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord11(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord12(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord13(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord14(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord15(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord16(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord17(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord18(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord19(ZScreamer ZS, IDrawableSprite spr) { }

		public static void SpriteDraw_Overlord1A(ZScreamer ZS, IDrawableSprite spr) { }

#pragma warning restore IDE0060 // Remove unused parameter

	}
}
