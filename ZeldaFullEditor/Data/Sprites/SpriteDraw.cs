namespace ZeldaFullEditor.Data.Sprites
{
	public delegate void DrawSprite(ZScreamer ZS, Sprite spr);

	public readonly struct SpriteDrawInfo
	{
		public ushort TileIndex { get; }
		public int XOff { get; }
		public int YOff { get; }
		public bool HFlip { get; }
		public bool VFlip { get; }
		public bool IsBig { get; }
		public byte Palette { get; }
		public SpriteDrawInfo(ushort i, int x, int y, bool hflip, bool vflip, bool big, byte pal)
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
		public static unsafe void DrawTiles(ZScreamer ZS, Sprite spr, params SpriteDrawInfo[] instructions)
		{
			// TODO
		}



		public static unsafe void DrawSprite_SpriteXX(ZScreamer ZS, Sprite spr)
		{
			DrawTiles(ZS, spr,
				new SpriteDrawInfo(0x99, 0, 0, hflip: false, vflip: true, big:false, pal: 3),
				new SpriteDrawInfo(0x99, 8, 0, hflip: true, vflip: true, big:false, pal: 3)
				);
		}

		public static void SpriteDraw_Sprite00(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite01(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite02(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite03(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite04(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite05(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite06(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite07(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite08(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite09(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite0A(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite0B(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite0C(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite0D(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite0E(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite0F(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite10(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite11(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite12(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite13(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite14(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite15(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite16(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite17(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite18(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite19(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite1A(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite1B(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite1C(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite1D(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite1E(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite1F(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite20(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite21(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite22(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite23(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite24(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite25(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite26(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite27(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite28(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite29(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite2A(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite2B(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite2C(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite2D(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite2E(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite2F(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite30(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite31(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite32(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite33(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite34(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite35(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite36(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite37(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite38(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite39(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite3A(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite3B(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite3C(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite3D(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite3E(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite3F(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite40(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite41(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite42(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite43(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite44(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite45(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite46(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite47(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite48(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite49(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite4A(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite4B(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite4C(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite4D(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite4E(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite4F(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite50(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite51(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite52(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite53(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite54(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite55(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite56(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite57(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite58(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite59(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite5A(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite5B(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite5C(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite5D(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite5E(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite5F(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite60(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite61(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite62(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite63(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite64(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite65(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite66(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite67(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite68(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite69(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite6A(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite6B(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite6C(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite6D(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite6E(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite6F(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite70(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite71(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite72(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite73(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite74(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite75(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite76(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite77(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite78(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite79(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite7A(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite7B(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite7C(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite7D(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite7E(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite7F(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite80(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite81(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite82(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite83(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite84(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite85(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite86(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite87(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite88(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite89(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite8A(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite8B(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite8C(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite8D(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite8E(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite8F(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite90(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite91(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite92(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite93(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite94(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite95(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite96(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite97(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite98(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite99(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite9A(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite9B(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite9C(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite9D(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite9E(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Sprite9F(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteA0(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteA1(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteA2(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteA3(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteA4(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteA5(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteA6(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteA7(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteA8(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteA9(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteAA(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteAB(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteAC(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteAD(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteAE(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteAF(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteB0(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteB1(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteB2(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteB3(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteB4(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteB5(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteB6(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteB7(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteB8(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteB9(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteBA(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteBB(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteBC(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteBD(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteBE(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteBF(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteC0(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteC1(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteC2(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteC3(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteC4(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteC5(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteC6(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteC7(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteC8(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteC9(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteCA(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteCB(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteCC(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteCD(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteCE(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteCF(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteD0(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteD1(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteD2(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteD3(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteD4(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteD5(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteD6(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteD7(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteD8(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteD9(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteDA(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteDB(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteDC(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteDD(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteDE(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteDF(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteE0(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteE1(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteE2(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteE3(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteE4(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteE5(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteE6(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteE7(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteE8(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteE9(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteEA(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteEB(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteEC(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteED(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteEE(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteEF(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteF0(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteF1(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteF2(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteF3(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteF4(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteF5(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteF6(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteF7(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_SpriteF8(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord01(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord02(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord03(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord04(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord05(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord06(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord07(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord08(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord09(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord0A(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord0B(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord0C(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord0D(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord0E(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord0F(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord10(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord11(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord12(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord13(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord14(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord15(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord16(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord17(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord18(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord19(ZScreamer ZS, Sprite spr) { }

		public static void SpriteDraw_Overlord1A(ZScreamer ZS, Sprite spr) { }

	}
}
