using ZeldaFullEditor.Data.DungeonObjects;

namespace ZeldaFullEditor.Data
{
	public delegate void DrawSprite(ZScreamer ZS, DungeonSprite spr);

	public readonly struct SpriteDrawInfo
	{
		public ushort TileIndex { get; }
		public int XOff { get; }
		public int YOff { get; }
		public bool HFlip { get; }
		public bool VFlip { get; }
		public bool IsBig { get; }
		public byte Palette { get; }
		public SpriteDrawInfo(ushort i, int x, int y, byte pal, bool hflip, bool vflip, bool big)
		{
			TileIndex = i;
			XOff = x;
			YOff = y;
			HFlip = hflip;
			VFlip = vflip;
			IsBig = big;
			Palette = pal;
		}
	}

	public partial class SpriteType
	{
		public static unsafe void DrawTiles(ZScreamer ZS, DungeonSprite spr, params SpriteDrawInfo[] instructions)
		{
			// TODO
		}

		public static void SpriteDraw_Sprite00(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, -32 + x, -22 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1C8, -32 + x, -32 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite01(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x186, 8 + x, 0 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x186, -8 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite02(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x100, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite03(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x100, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite04(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1CE, 0 + x, 0 + y, pal: 0x00, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1EE, 0 + x, -1 + y, pal: 0x00, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite05(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1D2, -4 + x, -3 + y, pal: 0x00, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x1D2, 12 + x, -3 + y, pal: 0x00, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1C4, 0 + x, 0 + y, pal: 0x00, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1E4, -4 + x, 5 + y, pal: 0x00, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1E4, 4 + x, 5 + y, pal: 0x00, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite06(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1CE, 0 + x, 0 + y, pal: 0x00, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1EE, 0 + x, -1 + y, pal: 0x00, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite07(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1A2, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A4, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite08(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A0, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1BB, 8 + x, 6 + y, pal: 0x06, vflip: false, hflip: true, big: false)
			);
		}

		public static void SpriteDraw_Sprite09(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x18C, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x188, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A6, 8 + x, 8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A4, -8 + x, 8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x186, 8 + x, -8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x184, -8 + x, -8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A6, 8 + x, 8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A4, -8 + x, 8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x186, 8 + x, -8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x184, -8 + x, -8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A2, 8 + x, 8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A0, -8 + x, 8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x182, 8 + x, -8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x180, -8 + x, -8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AA, 15 + x, 6 + y, pal: 0x00, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A8, 15 + x, -6 + y, pal: 0x00, vflip: true, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite0A(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A0, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1BB, 8 + x, 6 + y, pal: 0x06, vflip: false, hflip: true, big: false)
			);
		}

		public static void SpriteDraw_Sprite0B(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1EA, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite0C(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x184, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite0D(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1F0, 0 + x, -8 + y, pal: 0x05, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1F0, 8 + x, -8 + y, pal: 0x05, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x1E1, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite0E(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18C, 4 + x, 0 + y, pal: 0x04, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x18D, -4 + x, 0 + y, pal: 0x04, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x18F, 4 + x, -8 + y, pal: 0x04, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x19F, -4 + x, -8 + y, pal: 0x04, vflip: false, hflip: true, big: false)
			);
		}

		public static void SpriteDraw_Sprite0F(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18C, -4 + x, -20 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18C, 4 + x, -20 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x19C, -4 + x, -12 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x19C, 4 + x, -12 + y, pal: 0x06, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite10(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x038, 0 + x, 3 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1BD, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite11(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x106, 0 + x, 1 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x124, 8 + x, -5 + y, pal: 0x03, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x124, -8 + x, -5 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x100, 0 + x, -13 + y, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite12(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18A, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x188, 0 + x, -10 + y, pal: 0x04, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x190, -2 + x, 11 + y, pal: 0x04, vflip: true, hflip: false, big: false),
				new SpriteDrawInfo(0x191, -2 + x, 3 + y, pal: 0x04, vflip: true, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite13(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x166, 0 + x, 0 + y, pal: 0x00, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite14(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite15(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1E3, 4 + x, 7 + y, pal: 0x01, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1E3, 9 + x, 2 + y, pal: 0x01, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1E3, -1 + x, 2 + y, pal: 0x01, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1E3, 4 + x, -3 + y, pal: 0x01, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1E1, 4 + x, 2 + y, pal: 0x01, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite16(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A2, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A0, 0 + x, -9 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite17(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x046, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x046, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite18(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x15D, 4 + x, 4 + y, pal: 0x03, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x162, 0 + x, 0 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x160, 0 + x, 0 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x14D, 10 + x, 6 + y, pal: 0x03, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x14D, 10 + x, 1 + y, pal: 0x03, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite19(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1E6, 0 + x, -12 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x07C, 9 + x, -3 + y, pal: 0x01, vflip: false, hflip: true, big: false)
			);
		}

		public static void SpriteDraw_Sprite1A(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x160, -11 + x, -10 + y, pal: 0x04, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x140, 1 + x, 0 + y, pal: 0x04, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite1B(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x03A, -8 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x03D, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite1C(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1C0, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1C2, 8 + x, -8 + y, pal: 0x06, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x1C2, 0 + x, -8 + y, pal: 0x06, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite1D(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite1E(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1E4, 0 + x, 0 + y, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite1F(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x10A, 8 + x, 14 + y, pal: 0x06, vflip: true, hflip: true, big: true),
				new SpriteDrawInfo(0x10A, -8 + x, 14 + y, pal: 0x06, vflip: true, hflip: false, big: true),
				new SpriteDrawInfo(0x10A, 8 + x, 6 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x10A, -8 + x, 6 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x10E, 0 + x, -5 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x127, 4 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite20(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x182, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite21(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1CA, 0 + x, 0 + y, pal: 0x00, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1DD, 4 + x, 12 + y, pal: 0x00, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1DD, 4 + x, 12 + y, pal: 0x00, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1DD, 4 + x, 12 + y, pal: 0x00, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1DC, 4 + x, 20 + y, pal: 0x00, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite22(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x108, 0 + x, 0 + y, pal: 0x01, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x127, 8 + x, -8 + y, pal: 0x01, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x126, 0 + x, -8 + y, pal: 0x01, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite23(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x132, 8 + x, 2 + y, pal: 0x01, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x132, 0 + x, 2 + y, pal: 0x01, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x122, 8 + x, -6 + y, pal: 0x01, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x122, 0 + x, -6 + y, pal: 0x01, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite24(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x132, 8 + x, 2 + y, pal: 0x02, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x132, 0 + x, 2 + y, pal: 0x02, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x122, 8 + x, -6 + y, pal: 0x02, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x122, 0 + x, -6 + y, pal: 0x02, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite25(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite26(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x142, 0 + x, 2 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x140, 0 + x, -4 + y, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite27(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1C2, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite28(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x14A, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite29(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x188, 0 + x, 0 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x186, 0 + x, -7 + y, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite2A(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18A, 0 + x, 5 + y, pal: 0x07, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18E, 0 + x, -7 + y, pal: 0x07, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite2B(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1A7, 3 + x, 3 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A6, -5 + x, 3 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A7, 3 + x, 3 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A6, -5 + x, 3 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite2C(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1A4, 31 + x, 4 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A8, 30 + x, -8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A6, -32 + x, 4 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1A8, -32 + x, -8 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1BE, 25 + x, 5 + y, pal: 0x04, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x1BF, 17 + x, 5 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1BF, 9 + x, 5 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1BF, 1 + x, 5 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1BF, -7 + x, 5 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1BF, -15 + x, 5 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1BE, -23 + x, 5 + y, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite2D(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AA, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x182, 0 + x, -16 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AE, 4 + x, -14 + y, pal: 0x06, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite2E(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1AA, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A8, 0 + x, -10 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AA, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite2F(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1E8, 0 + x, 0 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1E0, 0 + x, -8 + y, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite30(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x120, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x100, 0 + x, -10 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite31(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x12C, 8 + x, -32 + y, pal: 0x06, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x12C, 0 + x, -32 + y, pal: 0x06, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x10C, 0 + x, -48 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite32(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x10A, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x104, 0 + x, -12 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite33(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite34(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1E4, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x128, 0 + x, -8 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite35(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1CA, 0 + x, 0 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1C4, 0 + x, -8 + y, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite36(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x184, 0 + x, 4 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x186, -3 + x, 15 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x186, -11 + x, 15 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x180, 0 + x, -4 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1BE, -3 + x, 16 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1AE, -3 + x, 8 + y, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite37(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite38(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite39(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1EC, 0 + x, 0 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1EA, 0 + x, -8 + y, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite3A(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite3B(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x038, 0 + x, 11 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x07B, 0 + x, 8 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x06B, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite3C(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AA, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x182, 0 + x, -8 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite3D(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1E4, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1E2, 0 + x, -8 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite3E(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x044, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x044, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite3F(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 12 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x14E, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x142, 0 + x, -9 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x139, 15 + x, -11 + y, pal: 0x04, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x12A, 15 + x, -3 + y, pal: 0x04, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x13A, 15 + x, 5 + y, pal: 0x04, vflip: false, hflip: true, big: false)
			);
		}

		public static void SpriteDraw_Sprite40(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1E6, 24 + x, 6 + y, pal: 0x01, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1E6, 8 + x, 6 + y, pal: 0x01, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1E6, -8 + x, 6 + y, pal: 0x01, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1E6, -24 + x, 6 + y, pal: 0x01, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1DA, 37 + x, 19 + y, pal: 0x01, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x1CA, 37 + x, 11 + y, pal: 0x01, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x1DA, -29 + x, 19 + y, pal: 0x01, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1CA, -29 + x, 11 + y, pal: 0x01, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1E8, 0 + x, 8 + y, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite41(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 12 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x148, -4 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x149, 4 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x16D, 10 + x, 2 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x17D, 10 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x17E, -3 + x, 11 + y, pal: 0x04, vflip: true, hflip: false, big: false),
				new SpriteDrawInfo(0x16E, -3 + x, 19 + y, pal: 0x04, vflip: true, hflip: false, big: false),
				new SpriteDrawInfo(0x142, 0 + x, -7 + y, pal: 0x04, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite42(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 12 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x148, -4 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x149, 4 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x16D, 10 + x, 2 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x17D, 10 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x17E, -3 + x, 11 + y, pal: 0x05, vflip: true, hflip: false, big: false),
				new SpriteDrawInfo(0x16E, -3 + x, 19 + y, pal: 0x05, vflip: true, hflip: false, big: false),
				new SpriteDrawInfo(0x142, 0 + x, -7 + y, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite43(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 12 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x148, -4 + x, 0 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x149, 4 + x, 0 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x16D, 10 + x, 2 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x17D, 10 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x17B, -3 + x, 11 + y, pal: 0x03, vflip: true, hflip: false, big: false),
				new SpriteDrawInfo(0x16B, -3 + x, 19 + y, pal: 0x03, vflip: true, hflip: false, big: false),
				new SpriteDrawInfo(0x142, 0 + x, -7 + y, pal: 0x03, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite44(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 12 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x108, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x108, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x102, 0 + x, -9 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x12F, 5 + x, 1 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x16F, -10 + x, -2 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x17F, -2 + x, -2 + y, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite45(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 12 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, 0 + x, 12 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x14D, -4 + x, -2 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x15D, -4 + x, 6 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x14E, 0 + x, 1 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x14E, 0 + x, 1 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x16C, -11 + x, 8 + y, pal: 0x03, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x17C, -3 + x, 8 + y, pal: 0x03, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x142, 0 + x, -8 + y, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite46(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 12 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, 0 + x, 12 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x14E, 0 + x, 1 + y, pal: 0x04, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x14E, 0 + x, 1 + y, pal: 0x04, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x142, 0 + x, -8 + y, pal: 0x04, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x10B, 11 + x, -2 + y, pal: 0x06, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x10B, 11 + x, 6 + y, pal: 0x06, vflip: true, hflip: true, big: false),
				new SpriteDrawInfo(0x03D, 18 + x, 2 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x03A, 10 + x, 2 + y, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite47(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x120, 0 + x, 8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x120, 0 + x, 8 + y, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite48(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 12 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x108, 0 + x, 0 + y, pal: 0x03, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x108, 0 + x, 0 + y, pal: 0x03, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x102, 0 + x, -9 + y, pal: 0x03, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x12F, 3 + x, 1 + y, pal: 0x03, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x16C, 17 + x, -2 + y, pal: 0x04, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x17C, 9 + x, -2 + y, pal: 0x04, vflip: false, hflip: true, big: false)
			);
		}

		public static void SpriteDraw_Sprite49(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x120, 0 + x, 8 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x120, 0 + x, 8 + y, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite4A(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x108, 0 + x, 0 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x108, 0 + x, 0 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x102, 0 + x, -9 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x12F, 4 + x, 1 + y, pal: 0x03, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x06E, 0 + x, -12 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite4B(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18A, 2 + x, 0 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x142, 0 + x, -11 + y, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite4C(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite4D(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite4E(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x140, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite4F(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x140, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite50(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x180, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite51(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1E0, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1C0, 0 + x, -16 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite52(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite53(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1E4, 8 + x, 12 + y, pal: 0x02, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1E4, -8 + x, 12 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1C0, -8 + x, -8 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1C2, 8 + x, -8 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1E0, -8 + x, 8 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1E2, 8 + x, 8 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite54(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 176 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, 0 + x, 176 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, 0 + x, 176 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, 0 + x, 176 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, 0 + x, 176 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, 0 + x, 176 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, 0 + x, 176 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, 0 + x, 176 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1CC, 0 + x, 176 + y, pal: 0x06, vflip: true, hflip: true, big: true),
				new SpriteDrawInfo(0x1C6, 0 + x, 176 + y, pal: 0x06, vflip: true, hflip: true, big: true),
				new SpriteDrawInfo(0x1C6, 0 + x, 176 + y, pal: 0x06, vflip: true, hflip: true, big: true),
				new SpriteDrawInfo(0x1C6, 0 + x, 176 + y, pal: 0x06, vflip: true, hflip: true, big: true),
				new SpriteDrawInfo(0x1C6, 0 + x, 176 + y, pal: 0x06, vflip: true, hflip: true, big: true),
				new SpriteDrawInfo(0x1C6, 0 + x, 176 + y, pal: 0x06, vflip: true, hflip: true, big: true),
				new SpriteDrawInfo(0x1C6, 0 + x, 176 + y, pal: 0x06, vflip: true, hflip: true, big: true),
				new SpriteDrawInfo(0x1C4, 0 + x, 176 + y, pal: 0x06, vflip: true, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite55(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite56(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite57(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1AE, 8 + x, 8 + y, pal: 0x00, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1AE, -8 + x, 8 + y, pal: 0x00, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18E, 8 + x, -8 + y, pal: 0x00, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x18E, -8 + x, -8 + y, pal: 0x00, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite58(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18E, -8 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18E, 8 + x, 0 + y, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite59(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1E3, 0 + x, -64 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite5A(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1C5, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite5B(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x128, 0 + x, 0 + y, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite5C(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x128, 0 + x, 0 + y, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite5D(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x188, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x189, 16 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x189, 32 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x188, 48 + x, 0 + y, pal: 0x06, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite5E(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x188, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x189, 16 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x189, 32 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x188, 48 + x, 0 + y, pal: 0x06, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite5F(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x18E, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x19E, 0 + x, 16 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x19E, 0 + x, 32 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x19E, 0 + x, 48 + y, pal: 0x06, vflip: true, hflip: false, big: true),
				new SpriteDrawInfo(0x19E, 0 + x, 64 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x19E, 0 + x, 80 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x19E, 0 + x, 96 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18E, 0 + x, 112 + y, pal: 0x06, vflip: true, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite60(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x18E, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x19E, 0 + x, 16 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x19E, 0 + x, 32 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x19E, 0 + x, 48 + y, pal: 0x06, vflip: true, hflip: false, big: true),
				new SpriteDrawInfo(0x19E, 0 + x, 64 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x19E, 0 + x, 80 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x19E, 0 + x, 96 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18E, 0 + x, 112 + y, pal: 0x06, vflip: true, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite61(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x148, 0 + x, -16 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x168, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite62(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1C3, -8 + x, -8 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1C4, 0 + x, -8 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1D3, -8 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1D4, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1E0, -8 + x, 8 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1F0, 0 + x, 8 + y, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite63(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite64(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite65(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x126, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x106, 0 + x, -10 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x106, 0 + x, -10 + y, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite66(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x10E, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite67(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x10E, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite68(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x10C, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite69(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x10C, 0 + x, 0 + y, pal: 0x06, vflip: true, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite6A(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 12 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x146, -4 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x106, 4 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x102, 0 + x, -9 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x12F, 12 + x, -4 + y, pal: 0x06, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x13F, 4 + x, -2 + y, pal: 0x06, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x13F, 4 + x, -2 + y, pal: 0x06, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x13F, 4 + x, -2 + y, pal: 0x06, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x13F, 4 + x, -2 + y, pal: 0x06, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x12A, 0 + x, -6 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite6B(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x14E, -4 + x, 0 + y, pal: 0x04, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x102, -4 + x, -9 + y, pal: 0x04, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x126, 8 + x, 0 + y, pal: 0x03, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x126, 8 + x, 0 + y, pal: 0x03, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x126, 8 + x, 0 + y, pal: 0x03, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite6C(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x04C, 0 + x, 0 + y, pal: 0x02, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite6D(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x186, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite6E(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1A4, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite6F(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x184, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite70(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1CC, 0 + x, 0 + y, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite71(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite72(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite73(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x120, 8 + x, -19 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x120, -8 + x, -19 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x108, 0 + x, -28 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x005, 15 + x, -4 + y, pal: 0x05, vflip: true, hflip: false, big: false),
				new SpriteDrawInfo(0x015, 15 + x, -12 + y, pal: 0x05, vflip: true, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite74(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1CC, 0 + x, 0 + y, pal: 0x07, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x12E, 0 + x, -8 + y, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite75(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x188, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AC, 0 + x, -7 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite76(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x022, 1 + x, 3 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x020, 1 + x, -7 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite77(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1E3, 4 + x, 7 + y, pal: 0x01, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1E3, 9 + x, 2 + y, pal: 0x01, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1E3, -1 + x, 2 + y, pal: 0x01, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1E3, 4 + x, -3 + y, pal: 0x01, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1E1, 4 + x, 2 + y, pal: 0x01, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite78(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x128, 0 + x, 5 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18E, 0 + x, -5 + y, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite79(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite7A(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 18 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x182, -8 + x, -8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x182, 8 + x, -8 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1A2, -8 + x, 8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A2, 8 + x, 8 + y, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite7B(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1C6, 0 + x, 0 + y, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite7C(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x102, 0 + x, -9 + y, pal: 0x06, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite7D(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1C4, 8 + x, 8 + y, pal: 0x04, vflip: true, hflip: true, big: true),
				new SpriteDrawInfo(0x1C4, -8 + x, 8 + y, pal: 0x04, vflip: true, hflip: false, big: true),
				new SpriteDrawInfo(0x1C4, 8 + x, -8 + y, pal: 0x04, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1C4, -8 + x, -8 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite7E(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x128, 0 + x, 0 + y, pal: 0x01, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x128, 0 + x, 0 + y, pal: 0x01, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x128, 0 + x, 0 + y, pal: 0x01, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x128, 0 + x, -64 + y, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite7F(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x128, 0 + x, 0 + y, pal: 0x01, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x128, 0 + x, 0 + y, pal: 0x01, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x128, 0 + x, 0 + y, pal: 0x01, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x128, 0 + x, -64 + y, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite80(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x128, 0 + x, 0 + y, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite81(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x184, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite82(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1E3, 4 + x, 7 + y, pal: 0x01, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1E3, 9 + x, 2 + y, pal: 0x01, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1E3, -1 + x, 2 + y, pal: 0x01, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1E3, 4 + x, -3 + y, pal: 0x01, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1E1, 4 + x, 2 + y, pal: 0x01, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite83(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 14 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x19C, 4 + x, 4 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x19C, -4 + x, 4 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A2, 4 + x, -4 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1A2, -4 + x, -4 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite84(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 14 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x19C, 4 + x, 4 + y, pal: 0x03, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x19C, -4 + x, 4 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A2, 4 + x, -4 + y, pal: 0x03, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1A2, -4 + x, -4 + y, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite85(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x10A, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x10A, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x102, 0 + x, -10 + y, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite86(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A0, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite87(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x18C, 0 + x, 0 + y, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite88(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 16 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, 1 + x, 16 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, 2 + x, 16 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, 3 + x, 16 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, 4 + x, 16 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, -1 + x, 16 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, -2 + x, 16 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, -3 + x, 16 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, -4 + x, 16 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A8, 8 + x, 8 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1A8, 8 + x, 8 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1A8, -8 + x, 8 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A8, -8 + x, 8 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x188, 8 + x, -8 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x188, 8 + x, -8 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x188, -8 + x, -8 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x188, -8 + x, -8 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite89(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1AA, 0 + x, 0 + y, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite8A(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1E6, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite8B(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18A, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x180, 0 + x, -9 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite8C(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 6 + x, 19 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, 0 + x, 19 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, -6 + x, 19 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A8, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A0, 8 + x, -12 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1A0, -8 + x, -12 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x180, 8 + x, -28 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x180, -8 + x, -28 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite8D(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1A6, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite8E(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18E, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite8F(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite90(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 6 + x, 19 + y, pal: 0x01, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, 0 + x, 19 + y, pal: 0x01, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06C, -6 + x, 19 + y, pal: 0x01, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A8, 4 + x, 8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1BA, -4 + x, 16 + y, pal: 0x05, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1AA, 12 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1A6, -4 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite91(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite92(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1A4, -28 + x, -12 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A2, -28 + x, -28 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A8, -28 + x, 28 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A6, -28 + x, 12 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A4, 28 + x, -4 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1A2, 28 + x, -20 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1A8, 28 + x, 28 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1A6, 28 + x, 12 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1AC, 0 + x, -40 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A0, 8 + x, 32 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1A0, -8 + x, 32 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18C, 24 + x, 16 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x18E, 8 + x, 16 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x18E, -8 + x, 16 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18C, -24 + x, 16 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x188, 24 + x, 0 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x18A, 8 + x, 0 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x18A, -8 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x188, -24 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x184, 24 + x, -16 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x186, 8 + x, -16 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x186, -8 + x, -16 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x184, -24 + x, -16 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x180, 24 + x, -32 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x182, 8 + x, -32 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x182, -8 + x, -32 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x180, -24 + x, -32 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1C6, 8 + x, 27 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1C6, -8 + x, 27 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1C2, 16 + x, 11 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1C4, 0 + x, 11 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1C2, -16 + x, 11 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AE, 16 + x, -5 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1C0, 0 + x, -5 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AE, -16 + x, -5 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1CE, -3 + x, 20 + y, pal: 0x05, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1CE, 11 + x, 20 + y, pal: 0x05, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x1AC, 0 + x, -40 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AC, 0 + x, -40 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AC, 0 + x, -40 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AC, 0 + x, -40 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AC, 0 + x, -40 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AC, 0 + x, -40 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AC, 0 + x, -40 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AC, 0 + x, -40 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AC, 0 + x, -40 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AC, 0 + x, -40 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AC, 0 + x, -40 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AC, 0 + x, -40 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AC, 0 + x, -40 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AC, 0 + x, -40 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AC, 0 + x, -40 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1E4, 0 + x, -40 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite93(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1EC, 8 + x, 8 + y, pal: 0x02, vflip: true, hflip: true, big: true),
				new SpriteDrawInfo(0x1EC, -8 + x, 8 + y, pal: 0x02, vflip: true, hflip: false, big: true),
				new SpriteDrawInfo(0x1EC, 8 + x, -8 + y, pal: 0x02, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1EC, -8 + x, -8 + y, pal: 0x02, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite94(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x187, 4 + x, 4 + y, pal: 0x06, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite95(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1C8, 8 + x, 12 + y, pal: 0x00, vflip: true, hflip: true, big: false),
				new SpriteDrawInfo(0x1D8, 8 + x, 4 + y, pal: 0x00, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x1C8, 8 + x, -4 + y, pal: 0x00, vflip: false, hflip: true, big: false)
			);
		}

		public static void SpriteDraw_Sprite96(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1C8, 0 + x, 12 + y, pal: 0x00, vflip: true, hflip: false, big: false),
				new SpriteDrawInfo(0x1D8, 0 + x, 4 + y, pal: 0x00, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1C8, 0 + x, -4 + y, pal: 0x00, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite97(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1C6, 12 + x, 8 + y, pal: 0x00, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x1C7, 4 + x, 8 + y, pal: 0x00, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1C6, -4 + x, 8 + y, pal: 0x00, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite98(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1C6, 12 + x, 0 + y, pal: 0x00, vflip: true, hflip: true, big: false),
				new SpriteDrawInfo(0x1C7, 4 + x, 0 + y, pal: 0x00, vflip: true, hflip: false, big: false),
				new SpriteDrawInfo(0x1C6, -4 + x, 0 + y, pal: 0x00, vflip: true, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_Sprite99(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x188, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x182, 1 + x, -8 + y, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_Sprite9A(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite9B(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite9C(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite9D(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_Sprite9E(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 18 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A4, 4 + x, 8 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A3, -4 + x, 8 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x181, 4 + x, -8 + y, pal: 0x03, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x180, -4 + x, -8 + y, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_Sprite9F(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18A, 0 + x, 0 + y, pal: 0x03, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteA0(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x186, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteA1(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1A6, 8 + x, 0 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1A6, -8 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A6, 8 + x, 0 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1A6, -8 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteA2(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1A2, 8 + x, 8 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A0, -8 + x, 8 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x182, 8 + x, -8 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x180, -8 + x, -8 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AC, 8 + x, 0 + y, pal: 0x06, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteA3(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteA4(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteA5(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A6, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1A6, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x182, 0 + x, -9 + y, pal: 0x04, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteA6(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A6, 0 + x, 0 + y, pal: 0x03, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1A6, 0 + x, 0 + y, pal: 0x03, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x182, 0 + x, -9 + y, pal: 0x03, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteA7(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x124, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x12E, 3 + x, 5 + y, pal: 0x04, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x102, 0 + x, -10 + y, pal: 0x04, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteA8(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1C6, 0 + x, -16 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1C6, 0 + x, -16 + y, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteA9(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1C6, 0 + x, -16 + y, pal: 0x04, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1C6, 0 + x, -16 + y, pal: 0x04, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteAA(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1C8, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1C8, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteAB(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteAC(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteAD(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x022, 0 + x, 8 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x020, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteAE(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x022, 0 + x, 8 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x020, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteAF(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x022, 0 + x, 8 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x020, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteB0(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x022, 0 + x, 8 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x020, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteB1(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x022, 0 + x, 8 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x020, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteB2(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteB3(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteB4(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1EE, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteB5(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x148, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteB6(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteB7(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x022, 1 + x, 3 + y, pal: 0x07, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x020, 1 + x, -7 + y, pal: 0x07, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteB8(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x038, 0 + x, 11 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x126, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x120, 0 + x, -8 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteB9(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1C0, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteBA(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteBB(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x120, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x102, 0 + x, -6 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteBC(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x106, 0 + x, 0 + y, pal: 0x00, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x122, 0 + x, -9 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AE, 8 + x, 2 + y, pal: 0x00, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteBD(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1E4, 8 + x, 8 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1E4, -8 + x, 8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1C4, 8 + x, -8 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1C4, -8 + x, -8 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteBE(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1E6, 1 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteBF(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1CC, 0 + x, 0 + y, pal: 0x00, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteC0(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteC1(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 18 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A2, 8 + x, 8 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1A2, -8 + x, 8 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x182, 8 + x, -8 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x182, -8 + x, -8 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteC2(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x048, 0 + x, 0 + y, pal: 0x00, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteC3(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x18C, -4 + x, -12 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x18E, 12 + x, -4 + y, pal: 0x05, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x18F, -4 + x, -20 + y, pal: 0x05, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x18A, 4 + x, -20 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AE, 0 + x, -16 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteC4(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x106, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x102, 0 + x, -6 + y, pal: 0x06, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteC5(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteC6(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteC7(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A0, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A0, 0 + x, -8 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A0, 0 + x, -16 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A2, 0 + x, -24 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteC8(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1AE, 4 + x, -16 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1AE, -4 + x, -16 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18E, 4 + x, -32 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x18E, -4 + x, -32 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteC9(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1C8, 8 + x, 0 + y, pal: 0x04, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1C8, -8 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteCA(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18B, 4 + x, 4 + y, pal: 0x06, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x18B, 4 + x, 4 + y, pal: 0x06, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x18B, 4 + x, 4 + y, pal: 0x06, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x18B, 4 + x, 4 + y, pal: 0x06, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x18B, 4 + x, 4 + y, pal: 0x06, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x18B, 4 + x, 4 + y, pal: 0x06, vflip: false, hflip: true, big: false),
				new SpriteDrawInfo(0x18C, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteCB(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x12A, 36 + x, 20 + y, pal: 0x00, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x10C, 36 + x, 4 + y, pal: 0x00, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x12A, -20 + x, 28 + y, pal: 0x00, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x10C, -20 + x, 12 + y, pal: 0x00, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x12C, 32 + x, -49 + y, pal: 0x00, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x12C, 24 + x, -53 + y, pal: 0x00, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x128, 17 + x, -53 + y, pal: 0x00, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x128, 11 + x, -48 + y, pal: 0x00, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x106, 8 + x, -40 + y, pal: 0x00, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1E0, 8 + x, 8 + y, pal: 0x00, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1E0, -8 + x, 8 + y, pal: 0x00, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1C0, 8 + x, -8 + y, pal: 0x00, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1C0, -8 + x, -8 + y, pal: 0x00, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteCC(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x10A, -14 + x, -30 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x124, -6 + x, -24 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x124, -22 + x, -24 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x104, -6 + x, -40 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x104, -22 + x, -40 + y, pal: 0x05, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteCD(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x10A, 13 + x, -30 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x124, 21 + x, -24 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x124, 5 + x, -24 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x104, 21 + x, -40 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x104, 5 + x, -40 + y, pal: 0x06, vflip: false, hflip: true, big: true)
			);
		}

		public static void SpriteDraw_SpriteCE(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1A6, 19 + x, 3 + y, pal: 0x05, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1A6, -19 + x, 3 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x186, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1A4, 8 + x, 23 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x1A0, -8 + x, 23 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x18E, 8 + x, 7 + y, pal: 0x06, vflip: false, hflip: true, big: true),
				new SpriteDrawInfo(0x18E, -8 + x, 7 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteCF(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteD0(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1E5, 4 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1E4, -4 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1CC, -5 + x, -11 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteD1(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteD2(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteD3(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteD4(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x070, 8 + x, 4 + y, pal: 0x02, vflip: false, hflip: true, big: false)
			);
		}

		public static void SpriteDraw_SpriteD5(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x142, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x142, 0 + x, 0 + y, pal: 0x05, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x140, 0 + x, -8 + y, pal: 0x05, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteD6(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteD7(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteD8(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x038, 0 + x, 3 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x029, 0 + x, 0 + y, pal: 0x01, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteD9(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x038, 0 + x, 11 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x01B, 0 + x, 8 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x00B, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteDA(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x038, 0 + x, 11 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x01B, 0 + x, 8 + y, pal: 0x02, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x00B, 0 + x, 0 + y, pal: 0x02, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteDB(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x038, 0 + x, 11 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x01B, 0 + x, 8 + y, pal: 0x01, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x00B, 0 + x, 0 + y, pal: 0x01, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteDC(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06E, 0 + x, 0 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06E, 0 + x, 0 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x068, 8 + x, 8 + y, pal: 0x02, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteDD(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06E, 0 + x, 0 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06E, 0 + x, 0 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x078, 8 + x, 8 + y, pal: 0x02, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteDE(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06E, 0 + x, 0 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x06E, 0 + x, 0 + y, pal: 0x02, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x079, 8 + x, 8 + y, pal: 0x02, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteDF(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x038, 0 + x, 3 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x060, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteE0(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x038, 0 + x, 11 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x072, 0 + x, 8 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x062, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteE1(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x038, 0 + x, 11 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x063, 0 + x, 0 + y, pal: 0x02, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x073, 0 + x, 8 + y, pal: 0x02, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x069, 2 + x, 8 + y, pal: 0x02, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteE2(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x038, 0 + x, 11 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x063, 0 + x, 0 + y, pal: 0x02, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x073, 0 + x, 8 + y, pal: 0x02, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x06A, 2 + x, 8 + y, pal: 0x02, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteE3(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x0EA, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteE4(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x038, 0 + x, 11 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x07B, 0 + x, 8 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x06B, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteE5(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x024, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteE6(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x1EA, 0 + x, 0 + y, pal: 0x07, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteE7(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x024, 0 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteE8(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x1F5, 4 + x, 8 + y, pal: 0x04, vflip: false, hflip: false, big: false),
				new SpriteDrawInfo(0x1F4, 4 + x, 0 + y, pal: 0x04, vflip: false, hflip: false, big: false)
			);
		}

		public static void SpriteDraw_SpriteE9(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x110, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x100, 0 + x, -8 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteEA(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x024, 0 + x, 0 + y, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteEB(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x0E0, 0 + x, 0 + y, pal: 0x01, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteEC(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x06C, 0 + x, 10 + y, pal: 0x04, vflip: false, hflip: false, big: true),
				new SpriteDrawInfo(0x042, 0 + x, 0 + y, pal: 0x06, vflip: false, hflip: false, big: true)
			);
		}

		public static void SpriteDraw_SpriteED(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteEE(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteEF(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteF0(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteF1(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static void SpriteDraw_SpriteF2(ZScreamer ZS, DungeonSprite spr)
		{
			const int x = 0, y = 0; // TODO get from sprite prep

			//	DrawTiles(ZS, spr,
		}

		public static unsafe void DrawSprite_SpriteXX(ZScreamer ZS, DungeonSprite spr)
		{
			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x99, 0, 0, hflip: false, vflip: true, big:false, pal: 3),
				new SpriteDrawInfo(0x99, 8, 0, hflip: true, vflip: true, big:false, pal: 3)
				);
		}



		public static void SpriteDraw_Overlord01(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord02(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord03(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord04(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord05(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord06(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord07(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord08(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord09(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord0A(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord0B(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord0C(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord0D(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord0E(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord0F(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord10(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord11(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord12(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord13(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord14(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord15(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord16(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord17(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord18(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord19(ZScreamer ZS, DungeonSprite spr) { }

		public static void SpriteDraw_Overlord1A(ZScreamer ZS, DungeonSprite spr) { }

	}
}
