using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public class ItemReceipt
	{
		public delegate void DrawReceipt(ZScreamer ZS, DungeonChestItem s);

		public byte ID { get; }
		public string VanillaName { get; }

		public DrawReceipt Draw { get; }

		private ItemReceipt(byte id, DrawReceipt d)
		{
			ID = id;
			VanillaName = DefaultEntities.ListOfSecrets.GetNameFromVanillaList(id);
			Draw = d;
		}

		public static readonly ItemReceipt Receipt00 = new ItemReceipt(0x00, ItemReceiptDraw00);
		public static readonly ItemReceipt Receipt01 = new ItemReceipt(0x01, ItemReceiptDraw01);
		public static readonly ItemReceipt Receipt02 = new ItemReceipt(0x02, ItemReceiptDraw02);
		public static readonly ItemReceipt Receipt03 = new ItemReceipt(0x03, ItemReceiptDraw03);
		public static readonly ItemReceipt Receipt04 = new ItemReceipt(0x04, ItemReceiptDraw04);
		public static readonly ItemReceipt Receipt05 = new ItemReceipt(0x05, ItemReceiptDraw05);
		public static readonly ItemReceipt Receipt06 = new ItemReceipt(0x06, ItemReceiptDraw06);
		public static readonly ItemReceipt Receipt07 = new ItemReceipt(0x07, ItemReceiptDraw07);
		public static readonly ItemReceipt Receipt08 = new ItemReceipt(0x08, ItemReceiptDraw08);
		public static readonly ItemReceipt Receipt09 = new ItemReceipt(0x09, ItemReceiptDraw09);
		public static readonly ItemReceipt Receipt0A = new ItemReceipt(0x0A, ItemReceiptDraw0A);
		public static readonly ItemReceipt Receipt0B = new ItemReceipt(0x0B, ItemReceiptDraw0B);
		public static readonly ItemReceipt Receipt0C = new ItemReceipt(0x0C, ItemReceiptDraw0C);
		public static readonly ItemReceipt Receipt0D = new ItemReceipt(0x0D, ItemReceiptDraw0D);
		public static readonly ItemReceipt Receipt0E = new ItemReceipt(0x0E, ItemReceiptDraw0E);
		public static readonly ItemReceipt Receipt0F = new ItemReceipt(0x0F, ItemReceiptDraw0F);
		public static readonly ItemReceipt Receipt10 = new ItemReceipt(0x10, ItemReceiptDraw10);
		public static readonly ItemReceipt Receipt11 = new ItemReceipt(0x11, ItemReceiptDraw11);
		public static readonly ItemReceipt Receipt12 = new ItemReceipt(0x12, ItemReceiptDraw12);
		public static readonly ItemReceipt Receipt13 = new ItemReceipt(0x13, ItemReceiptDraw13);
		public static readonly ItemReceipt Receipt14 = new ItemReceipt(0x14, ItemReceiptDraw14);
		public static readonly ItemReceipt Receipt15 = new ItemReceipt(0x15, ItemReceiptDraw15);
		public static readonly ItemReceipt Receipt16 = new ItemReceipt(0x16, ItemReceiptDraw16);
		public static readonly ItemReceipt Receipt17 = new ItemReceipt(0x17, ItemReceiptDraw17);
		public static readonly ItemReceipt Receipt18 = new ItemReceipt(0x18, ItemReceiptDraw18);
		public static readonly ItemReceipt Receipt19 = new ItemReceipt(0x19, ItemReceiptDraw19);
		public static readonly ItemReceipt Receipt1A = new ItemReceipt(0x1A, ItemReceiptDraw1A);
		public static readonly ItemReceipt Receipt1B = new ItemReceipt(0x1B, ItemReceiptDraw1B);
		public static readonly ItemReceipt Receipt1C = new ItemReceipt(0x1C, ItemReceiptDraw1C);
		public static readonly ItemReceipt Receipt1D = new ItemReceipt(0x1D, ItemReceiptDraw1D);
		public static readonly ItemReceipt Receipt1E = new ItemReceipt(0x1E, ItemReceiptDraw1E);
		public static readonly ItemReceipt Receipt1F = new ItemReceipt(0x1F, ItemReceiptDraw1F);
		public static readonly ItemReceipt Receipt20 = new ItemReceipt(0x20, ItemReceiptDraw20);
		public static readonly ItemReceipt Receipt21 = new ItemReceipt(0x21, ItemReceiptDraw21);
		public static readonly ItemReceipt Receipt22 = new ItemReceipt(0x22, ItemReceiptDraw22);
		public static readonly ItemReceipt Receipt23 = new ItemReceipt(0x23, ItemReceiptDraw23);
		public static readonly ItemReceipt Receipt24 = new ItemReceipt(0x24, ItemReceiptDraw24);
		public static readonly ItemReceipt Receipt25 = new ItemReceipt(0x25, ItemReceiptDraw25);
		public static readonly ItemReceipt Receipt26 = new ItemReceipt(0x26, ItemReceiptDraw26);
		public static readonly ItemReceipt Receipt27 = new ItemReceipt(0x27, ItemReceiptDraw27);
		public static readonly ItemReceipt Receipt28 = new ItemReceipt(0x28, ItemReceiptDraw28);
		public static readonly ItemReceipt Receipt29 = new ItemReceipt(0x29, ItemReceiptDraw29);
		public static readonly ItemReceipt Receipt2A = new ItemReceipt(0x2A, ItemReceiptDraw2A);
		public static readonly ItemReceipt Receipt2B = new ItemReceipt(0x2B, ItemReceiptDraw2B);
		public static readonly ItemReceipt Receipt2C = new ItemReceipt(0x2C, ItemReceiptDraw2C);
		public static readonly ItemReceipt Receipt2D = new ItemReceipt(0x2D, ItemReceiptDraw2D);
		public static readonly ItemReceipt Receipt2E = new ItemReceipt(0x2E, ItemReceiptDraw2E);
		public static readonly ItemReceipt Receipt2F = new ItemReceipt(0x2F, ItemReceiptDraw2F);
		public static readonly ItemReceipt Receipt30 = new ItemReceipt(0x30, ItemReceiptDraw30);
		public static readonly ItemReceipt Receipt31 = new ItemReceipt(0x31, ItemReceiptDraw31);
		public static readonly ItemReceipt Receipt32 = new ItemReceipt(0x32, ItemReceiptDraw32);
		public static readonly ItemReceipt Receipt33 = new ItemReceipt(0x33, ItemReceiptDraw33);
		public static readonly ItemReceipt Receipt34 = new ItemReceipt(0x34, ItemReceiptDraw34);
		public static readonly ItemReceipt Receipt35 = new ItemReceipt(0x35, ItemReceiptDraw35);
		public static readonly ItemReceipt Receipt36 = new ItemReceipt(0x36, ItemReceiptDraw36);
		public static readonly ItemReceipt Receipt37 = new ItemReceipt(0x37, ItemReceiptDraw37);
		public static readonly ItemReceipt Receipt38 = new ItemReceipt(0x38, ItemReceiptDraw38);
		public static readonly ItemReceipt Receipt39 = new ItemReceipt(0x39, ItemReceiptDraw39);
		public static readonly ItemReceipt Receipt3A = new ItemReceipt(0x3A, ItemReceiptDraw3A);
		public static readonly ItemReceipt Receipt3B = new ItemReceipt(0x3B, ItemReceiptDraw3B);
		public static readonly ItemReceipt Receipt3C = new ItemReceipt(0x3C, ItemReceiptDraw3C);
		public static readonly ItemReceipt Receipt3D = new ItemReceipt(0x3D, ItemReceiptDraw3D);
		public static readonly ItemReceipt Receipt3E = new ItemReceipt(0x3E, ItemReceiptDraw3E);
		public static readonly ItemReceipt Receipt3F = new ItemReceipt(0x3F, ItemReceiptDraw3F);
		public static readonly ItemReceipt Receipt40 = new ItemReceipt(0x40, ItemReceiptDraw40);
		public static readonly ItemReceipt Receipt41 = new ItemReceipt(0x41, ItemReceiptDraw41);
		public static readonly ItemReceipt Receipt42 = new ItemReceipt(0x42, ItemReceiptDraw42);
		public static readonly ItemReceipt Receipt43 = new ItemReceipt(0x43, ItemReceiptDraw43);
		public static readonly ItemReceipt Receipt44 = new ItemReceipt(0x44, ItemReceiptDraw44);
		public static readonly ItemReceipt Receipt45 = new ItemReceipt(0x45, ItemReceiptDraw45);
		public static readonly ItemReceipt Receipt46 = new ItemReceipt(0x46, ItemReceiptDraw46);
		public static readonly ItemReceipt Receipt47 = new ItemReceipt(0x47, ItemReceiptDraw47);
		public static readonly ItemReceipt Receipt48 = new ItemReceipt(0x48, ItemReceiptDraw48);
		public static readonly ItemReceipt Receipt49 = new ItemReceipt(0x49, ItemReceiptDraw49);
		public static readonly ItemReceipt Receipt4A = new ItemReceipt(0x4A, ItemReceiptDraw4A);
		public static readonly ItemReceipt Receipt4B = new ItemReceipt(0x4B, ItemReceiptDraw4B);

		public static ItemReceipt FindFromID(byte id)
		{
			switch (id)
			{
				case 0x00: return Receipt00;
				case 0x01: return Receipt01;
				case 0x02: return Receipt02;
				case 0x03: return Receipt03;
				case 0x04: return Receipt04;
				case 0x05: return Receipt05;
				case 0x06: return Receipt06;
				case 0x07: return Receipt07;
				case 0x08: return Receipt08;
				case 0x09: return Receipt09;
				case 0x0A: return Receipt0A;
				case 0x0B: return Receipt0B;
				case 0x0C: return Receipt0C;
				case 0x0D: return Receipt0D;
				case 0x0E: return Receipt0E;
				case 0x0F: return Receipt0F;
				case 0x10: return Receipt10;
				case 0x11: return Receipt11;
				case 0x12: return Receipt12;
				case 0x13: return Receipt13;
				case 0x14: return Receipt14;
				case 0x15: return Receipt15;
				case 0x16: return Receipt16;
				case 0x17: return Receipt17;
				case 0x18: return Receipt18;
				case 0x19: return Receipt19;
				case 0x1A: return Receipt1A;
				case 0x1B: return Receipt1B;
				case 0x1C: return Receipt1C;
				case 0x1D: return Receipt1D;
				case 0x1E: return Receipt1E;
				case 0x1F: return Receipt1F;
				case 0x20: return Receipt20;
				case 0x21: return Receipt21;
				case 0x22: return Receipt22;
				case 0x23: return Receipt23;
				case 0x24: return Receipt24;
				case 0x25: return Receipt25;
				case 0x26: return Receipt26;
				case 0x27: return Receipt27;
				case 0x28: return Receipt28;
				case 0x29: return Receipt29;
				case 0x2A: return Receipt2A;
				case 0x2B: return Receipt2B;
				case 0x2C: return Receipt2C;
				case 0x2D: return Receipt2D;
				case 0x2E: return Receipt2E;
				case 0x2F: return Receipt2F;
				case 0x30: return Receipt30;
				case 0x31: return Receipt31;
				case 0x32: return Receipt32;
				case 0x33: return Receipt33;
				case 0x34: return Receipt34;
				case 0x35: return Receipt35;
				case 0x36: return Receipt36;
				case 0x37: return Receipt37;
				case 0x38: return Receipt38;
				case 0x39: return Receipt39;
				case 0x3A: return Receipt3A;
				case 0x3B: return Receipt3B;
				case 0x3C: return Receipt3C;
				case 0x3D: return Receipt3D;
				case 0x3E: return Receipt3E;
				case 0x3F: return Receipt3F;
				case 0x40: return Receipt40;
				case 0x41: return Receipt41;
				case 0x42: return Receipt42;
				case 0x43: return Receipt43;
				case 0x44: return Receipt44;
				case 0x45: return Receipt45;
				case 0x46: return Receipt46;
				case 0x47: return Receipt47;
				case 0x48: return Receipt48;
				case 0x49: return Receipt49;
				case 0x4A: return Receipt4A;
				case 0x4B: return Receipt4B;
			}
			return null;
		}

		public static unsafe void DrawTiles(ZScreamer ZS, DungeonChestItem sec, params OAMDrawInfo[] instructions)
		{
			var alltilesData = (byte*) ZS.GFXManager.currentOWgfx16Ptr.ToPointer();

			byte* ptr = (byte*) ZS.GFXManager.roomBg1Ptr.ToPointer(); ;

			// TODO poorly copied and shit
			foreach (OAMDrawInfo ti in instructions)
			{
				int size = ti.RectSideSize;
				byte r = (byte) (ti.HFlip ? 1 : 0);
				int tx = (ti.TileIndex / 16 * 512) + ((ti.TileIndex & 0xF) << 2); // TODO verify

				// TODO add stuff for automatic chest positioning
				int indexoff = sec.X + ti.XOff + (512 * (sec.Y + ti.YOff));
				byte pal = (byte) (ti.Palette << 3);


				for (int yl = 0, yl2 = tx; yl < size; yl++, yl2 += 64)
				{
					int my = (512 * (ti.VFlip ? size - 1 - yl : yl)) + indexoff; // this is alltilesData additive, so it can go here

					for (int xl = 0, xl2 = yl2; xl < size; xl++, xl2++)
					{
						int mx = ti.HFlip ? size - 1 - xl : xl;
						var pixel = alltilesData[xl2];
						int index = (mx * 2) + my;

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

		public static void ItemReceiptDraw00(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw01(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw02(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw03(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw04(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw05(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw06(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw07(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw08(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw09(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw0A(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw0B(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw0C(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw0D(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw0E(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw0F(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw10(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw11(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw12(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw13(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw14(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw15(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw16(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw17(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw18(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw19(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw1A(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw1B(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw1C(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw1D(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw1E(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw1F(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw20(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw21(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw22(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw23(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw24(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw25(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw26(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw27(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw28(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw29(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw2A(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw2B(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw2C(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw2D(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw2E(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw2F(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw30(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw31(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw32(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw33(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw34(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw35(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw36(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw37(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw38(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw39(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw3A(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw3B(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw3C(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw3D(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw3E(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw3F(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw40(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw41(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw42(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw43(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw44(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw45(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw46(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw47(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw48(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw49(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw4A(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw4B(ZScreamer ZS, DungeonChestItem d)
		{
			DrawTiles(ZS, d, new OAMDrawInfo());
		}

	}
}
