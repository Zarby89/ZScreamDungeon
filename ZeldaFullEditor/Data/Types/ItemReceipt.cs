namespace ZeldaFullEditor.Data
{
	public class ItemReceipt : IEntityType<ItemReceipt>
	{
		public delegate void DrawReceipt(Artist art, DungeonChestItem s);

		public byte ID { get; }
		public string VanillaName { get; }

		public DrawReceipt Draw { get; }

		private ItemReceipt(byte id, DrawReceipt d)
		{
			ID = id;
			VanillaName = DefaultEntities.ListOfItemReceipts.GetNameFromVanillaList(id);
			Draw = d;
		}


		public static readonly ItemReceipt Receipt00 = new(0x00, ItemReceiptDraw00);
		public static readonly ItemReceipt Receipt01 = new(0x01, ItemReceiptDraw01);
		public static readonly ItemReceipt Receipt02 = new(0x02, ItemReceiptDraw02);
		public static readonly ItemReceipt Receipt03 = new(0x03, ItemReceiptDraw03);
		public static readonly ItemReceipt Receipt04 = new(0x04, ItemReceiptDraw04);
		public static readonly ItemReceipt Receipt05 = new(0x05, ItemReceiptDraw05);
		public static readonly ItemReceipt Receipt06 = new(0x06, ItemReceiptDraw06);
		public static readonly ItemReceipt Receipt07 = new(0x07, ItemReceiptDraw07);
		public static readonly ItemReceipt Receipt08 = new(0x08, ItemReceiptDraw08);
		public static readonly ItemReceipt Receipt09 = new(0x09, ItemReceiptDraw09);
		public static readonly ItemReceipt Receipt0A = new(0x0A, ItemReceiptDraw0A);
		public static readonly ItemReceipt Receipt0B = new(0x0B, ItemReceiptDraw0B);
		public static readonly ItemReceipt Receipt0C = new(0x0C, ItemReceiptDraw0C);
		public static readonly ItemReceipt Receipt0D = new(0x0D, ItemReceiptDraw0D);
		public static readonly ItemReceipt Receipt0E = new(0x0E, ItemReceiptDraw0E);
		public static readonly ItemReceipt Receipt0F = new(0x0F, ItemReceiptDraw0F);
		public static readonly ItemReceipt Receipt10 = new(0x10, ItemReceiptDraw10);
		public static readonly ItemReceipt Receipt11 = new(0x11, ItemReceiptDraw11);
		public static readonly ItemReceipt Receipt12 = new(0x12, ItemReceiptDraw12);
		public static readonly ItemReceipt Receipt13 = new(0x13, ItemReceiptDraw13);
		public static readonly ItemReceipt Receipt14 = new(0x14, ItemReceiptDraw14);
		public static readonly ItemReceipt Receipt15 = new(0x15, ItemReceiptDraw15);
		public static readonly ItemReceipt Receipt16 = new(0x16, ItemReceiptDraw16);
		public static readonly ItemReceipt Receipt17 = new(0x17, ItemReceiptDraw17);
		public static readonly ItemReceipt Receipt18 = new(0x18, ItemReceiptDraw18);
		public static readonly ItemReceipt Receipt19 = new(0x19, ItemReceiptDraw19);
		public static readonly ItemReceipt Receipt1A = new(0x1A, ItemReceiptDraw1A);
		public static readonly ItemReceipt Receipt1B = new(0x1B, ItemReceiptDraw1B);
		public static readonly ItemReceipt Receipt1C = new(0x1C, ItemReceiptDraw1C);
		public static readonly ItemReceipt Receipt1D = new(0x1D, ItemReceiptDraw1D);
		public static readonly ItemReceipt Receipt1E = new(0x1E, ItemReceiptDraw1E);
		public static readonly ItemReceipt Receipt1F = new(0x1F, ItemReceiptDraw1F);
		public static readonly ItemReceipt Receipt20 = new(0x20, ItemReceiptDraw20);
		public static readonly ItemReceipt Receipt21 = new(0x21, ItemReceiptDraw21);
		public static readonly ItemReceipt Receipt22 = new(0x22, ItemReceiptDraw22);
		public static readonly ItemReceipt Receipt23 = new(0x23, ItemReceiptDraw23);
		public static readonly ItemReceipt Receipt24 = new(0x24, ItemReceiptDraw24);
		public static readonly ItemReceipt Receipt25 = new(0x25, ItemReceiptDraw25);
		public static readonly ItemReceipt Receipt26 = new(0x26, ItemReceiptDraw26);
		public static readonly ItemReceipt Receipt27 = new(0x27, ItemReceiptDraw27);
		public static readonly ItemReceipt Receipt28 = new(0x28, ItemReceiptDraw28);
		public static readonly ItemReceipt Receipt29 = new(0x29, ItemReceiptDraw29);
		public static readonly ItemReceipt Receipt2A = new(0x2A, ItemReceiptDraw2A);
		public static readonly ItemReceipt Receipt2B = new(0x2B, ItemReceiptDraw2B);
		public static readonly ItemReceipt Receipt2C = new(0x2C, ItemReceiptDraw2C);
		public static readonly ItemReceipt Receipt2D = new(0x2D, ItemReceiptDraw2D);
		public static readonly ItemReceipt Receipt2E = new(0x2E, ItemReceiptDraw2E);
		public static readonly ItemReceipt Receipt2F = new(0x2F, ItemReceiptDraw2F);
		public static readonly ItemReceipt Receipt30 = new(0x30, ItemReceiptDraw30);
		public static readonly ItemReceipt Receipt31 = new(0x31, ItemReceiptDraw31);
		public static readonly ItemReceipt Receipt32 = new(0x32, ItemReceiptDraw32);
		public static readonly ItemReceipt Receipt33 = new(0x33, ItemReceiptDraw33);
		public static readonly ItemReceipt Receipt34 = new(0x34, ItemReceiptDraw34);
		public static readonly ItemReceipt Receipt35 = new(0x35, ItemReceiptDraw35);
		public static readonly ItemReceipt Receipt36 = new(0x36, ItemReceiptDraw36);
		public static readonly ItemReceipt Receipt37 = new(0x37, ItemReceiptDraw37);
		public static readonly ItemReceipt Receipt38 = new(0x38, ItemReceiptDraw38);
		public static readonly ItemReceipt Receipt39 = new(0x39, ItemReceiptDraw39);
		public static readonly ItemReceipt Receipt3A = new(0x3A, ItemReceiptDraw3A);
		public static readonly ItemReceipt Receipt3B = new(0x3B, ItemReceiptDraw3B);
		public static readonly ItemReceipt Receipt3C = new(0x3C, ItemReceiptDraw3C);
		public static readonly ItemReceipt Receipt3D = new(0x3D, ItemReceiptDraw3D);
		public static readonly ItemReceipt Receipt3E = new(0x3E, ItemReceiptDraw3E);
		public static readonly ItemReceipt Receipt3F = new(0x3F, ItemReceiptDraw3F);
		public static readonly ItemReceipt Receipt40 = new(0x40, ItemReceiptDraw40);
		public static readonly ItemReceipt Receipt41 = new(0x41, ItemReceiptDraw41);
		public static readonly ItemReceipt Receipt42 = new(0x42, ItemReceiptDraw42);
		public static readonly ItemReceipt Receipt43 = new(0x43, ItemReceiptDraw43);
		public static readonly ItemReceipt Receipt44 = new(0x44, ItemReceiptDraw44);
		public static readonly ItemReceipt Receipt45 = new(0x45, ItemReceiptDraw45);
		public static readonly ItemReceipt Receipt46 = new(0x46, ItemReceiptDraw46);
		public static readonly ItemReceipt Receipt47 = new(0x47, ItemReceiptDraw47);
		public static readonly ItemReceipt Receipt48 = new(0x48, ItemReceiptDraw48);
		public static readonly ItemReceipt Receipt49 = new(0x49, ItemReceiptDraw49);
		public static readonly ItemReceipt Receipt4A = new(0x4A, ItemReceiptDraw4A);
		public static readonly ItemReceipt Receipt4B = new(0x4B, ItemReceiptDraw4B);

		public static ItemReceipt GetTypeFromID(int id) => id switch
		{
			0x00 => Receipt00,
			0x01 => Receipt01,
			0x02 => Receipt02,
			0x03 => Receipt03,
			0x04 => Receipt04,
			0x05 => Receipt05,
			0x06 => Receipt06,
			0x07 => Receipt07,
			0x08 => Receipt08,
			0x09 => Receipt09,
			0x0A => Receipt0A,
			0x0B => Receipt0B,
			0x0C => Receipt0C,
			0x0D => Receipt0D,
			0x0E => Receipt0E,
			0x0F => Receipt0F,
			0x10 => Receipt10,
			0x11 => Receipt11,
			0x12 => Receipt12,
			0x13 => Receipt13,
			0x14 => Receipt14,
			0x15 => Receipt15,
			0x16 => Receipt16,
			0x17 => Receipt17,
			0x18 => Receipt18,
			0x19 => Receipt19,
			0x1A => Receipt1A,
			0x1B => Receipt1B,
			0x1C => Receipt1C,
			0x1D => Receipt1D,
			0x1E => Receipt1E,
			0x1F => Receipt1F,
			0x20 => Receipt20,
			0x21 => Receipt21,
			0x22 => Receipt22,
			0x23 => Receipt23,
			0x24 => Receipt24,
			0x25 => Receipt25,
			0x26 => Receipt26,
			0x27 => Receipt27,
			0x28 => Receipt28,
			0x29 => Receipt29,
			0x2A => Receipt2A,
			0x2B => Receipt2B,
			0x2C => Receipt2C,
			0x2D => Receipt2D,
			0x2E => Receipt2E,
			0x2F => Receipt2F,
			0x30 => Receipt30,
			0x31 => Receipt31,
			0x32 => Receipt32,
			0x33 => Receipt33,
			0x34 => Receipt34,
			0x35 => Receipt35,
			0x36 => Receipt36,
			0x37 => Receipt37,
			0x38 => Receipt38,
			0x39 => Receipt39,
			0x3A => Receipt3A,
			0x3B => Receipt3B,
			0x3C => Receipt3C,
			0x3D => Receipt3D,
			0x3E => Receipt3E,
			0x3F => Receipt3F,
			0x40 => Receipt40,
			0x41 => Receipt41,
			0x42 => Receipt42,
			0x43 => Receipt43,
			0x44 => Receipt44,
			0x45 => Receipt45,
			0x46 => Receipt46,
			0x47 => Receipt47,
			0x48 => Receipt48,
			0x49 => Receipt49,
			0x4A => Receipt4A,
			0x4B => Receipt4B,
			_ => null,
		};

		public static unsafe void DrawTiles(Artist art, DungeonChestItem sec, params OAMDrawInfo[] instructions)
		{
			int xoff, yoff;

			// TODO
			if (sec.AssociatedChest.IsBigChest)
			{
				xoff = 0;
				yoff = 0;
			}
			else
			{
				xoff = 0;
				yoff = 0;
			}

			art.DrawSprite(sec, instructions, xoff: xoff, yoff: yoff, useGlobal: true);
		}


		/*
		 * 			if (id == 0)
			{
				// TODO : NEED TO CHANGE PALETTE TO SWORD & SHIELD PALETTE
				// Sword and shield
				draw_item_tile(x, y + 0, 14, 824, 7, false, false, 1);
				draw_item_tile(x + 8, y + 0, 15, 828, 7, false, false, 1);
			}
			else if (id == 1)
			{
				// Sword2 - need to do something else?
				draw_item_tile(x + 4, y + 0, 14, 824, 7, false, false, 1);
			}
			else if (id == 2)
			{
				// Sword3
				draw_item_tile(x + 4, y + 0, 14, 824, 7, false, false, 1);
			}
			else if (id == 3)
			{
				// Sword4
				draw_item_tile(x + 4, y + 0, 14, 824, 5, false, false, 1);
			}
			else if (id == 4)
			{
				// Shields - need to do something else?
				draw_item_tile(x, y + 0, 14, 820, 7);
			}
			else if (id == 5)
			{
				// Shield2
				draw_item_tile(x, y + 0, 12, 820, 11);
			}
			else if (id == 6)
			{
				// Shield3
				draw_item_tile(x, y, 4, 830, 11);
			}
			else if (id == 7) // Fire rod
			{
				draw_item_tile(x + 4, y + 0, 4, 822, 5, false, false, 1);
			}
			else if (id == 8) // Ice rod
			{
				draw_item_tile(x + 4, y + 0, 4, 822, 7, false, false, 1);
			}
			else if (id == 9) // Hammer
			{
				draw_item_tile(x + 4, y + 0, 5, 822, 5, false, false, 1);
			}
			else if (id == 10) // Hookshot
			{
				draw_item_tile(x + 4, y + 0, 3, 822, 5, false, false, 1);
			}
			else if (id == 11) // Bow
			{
				draw_item_tile(x + 4, y + 0, 0, 822, 5, false, false, 1);
			}
			else if (id == 12) // Boomerang
			{
				draw_item_tile(x + 4, y + 0, 15, 822, 7, false, false, 1);
			}
			else if (id == 13) // Powder
			{
				draw_item_tile(x, y + 0, 6, 822, 7);
			}
			else if (id == 14) // Bee
			{
				draw_item_tile(x + 0, y + 0, 13, 828, 7);
			}
			else if (id == 15) // Bombos
			{
				draw_item_tile(x + 0, y + 0, 2, 826, 11);
			}
			else if (id == 16) // Ether
			{
				draw_item_tile(x + 0, y + 0, 0, 826, 11);
			}
			else if (id == 17) // Quake
			{
				draw_item_tile(x + 0, y + 0, 4, 826, 11);
			}
			else if (id == 18) // Lamp
			{
				draw_item_tile(x, y, 6, 824, 5); // Lamp
			}
			else if (id == 19) // Shovel
			{
				draw_item_tile(x + 4, y + 0, 15, 824, 5, false, false, 1);
			}
			else if (id == 20) // Flute
			{
				draw_item_tile(x, y, 2, 830, 7);
			}
			else if (id == 21) // Somaria
			{
				draw_item_tile(x + 4, y + 0, 2, 822, 5, false, false, 1);
			}
			else if (id == 22) // Bottle
			{
				draw_item_tile(x + 0, y + 0, 6, 826, 11);
			}
			else if (id == 23) // Heart piece
			{
				draw_item_tile(x, y, 0, 830, 5);
			}
			else if (id == 24) // Byrna
			{
				draw_item_tile(x + 4, y + 0, 2, 822, 7, false, false, 1);
			}
			else if (id == 25) // Cape
			{
				draw_item_tile(x, y, 8, 824, 5); // Lamp
			}
			else if (id == 26) // Mirror
			{
				draw_item_tile(x + 0, y + 0, 2, 824, 7);
			}
			else if (id == 27) // Power glove
			{
				draw_item_tile(x, y + 0, 10, 822, 5);
			}
			else if (id == 28) // Titan mitts
			{
				draw_item_tile(x, y + 0, 10, 822, 11);
			}
			else if (id == 29) // Book
			{
				draw_item_tile(x, y + 0, 12, 822, 11);
			}
			else if (id == 30) // Flippers
			{
				draw_item_tile(x + 0, y + 0, 0, 824, 7);
			}
			else if (id == 31) // Moon pearl
			{
				draw_item_tile(x, y + 0, 12, 824, 5);
			}
			else if (id == 32) // Crystal
			{
				draw_item_tile(x + 0, y + 0, 5, 828, 6);
			}
			else if (id == 33) // Net
			{
				draw_item_tile(x + 0, y + 0, 3, 828, 5);
			}
			else if (id == 34) // Blue mail
			{
				draw_item_tile(x, y + 0, 8, 820, 7);
			}
			else if (id == 35) // Red mail
			{
				draw_item_tile(x, y + 0, 8, 820, 5);
			}
			else if (id == 36) // Key
			{
				draw_item_tile(x + 4, y + 0, 14, 822, 11, false, false, 1);
			}
			else if (id == 37) // Compass
			{
				draw_item_tile(x, y + 0, 10, 824, 7);
			}
			else if (id == 38) // Liar heart?
			{
				draw_item_tile(x, y + 0, 6, 820, 5);
			}
			else if (id == 39) // Bomb
			{
				draw_item_tile(x + 0, y + 0, 4, 824, 7);
			}
			else if (id == 40) // 3Bombs
			{
				draw_item_tile(x, y + 0, 2, 820, 7);
			}
			else if (id == 41) // Mushroom
			{
				draw_item_tile(x, y + 0, 10, 826, 11);
			}
			else if (id == 42) // Red Boomerang
			{
				draw_item_tile(x + 4, y + 0, 15, 822, 5, false, false, 1);
			}
			else if (id == 43) // Red pot
			{
				draw_item_tile(x, y, 8, 826, 5);
			}
			else if (id == 44) // Green pot
			{
				draw_item_tile(x, y, 8, 826, 11);
			}
			else if (id == 45) // Blue pot
			{
				draw_item_tile(x, y, 8, 826, 7);
			}
			else if (id == 46) // Red pot
			{
				draw_item_tile(x, y + 0, 0, 820, 5);
			}
			else if (id == 47) // Green pot
			{
				draw_item_tile(x, y + 0, 0, 820, 11);
			}
			else if (id == 48) // Blue pot
			{
				draw_item_tile(x, y + 0, 0, 820, 7);
			}
			else if (id == 49) // 10 bombs
			{
				draw_item_tile(x, y + 0, 8, 822, 7);
			}
			else if (id == 50) // Big Key
			{
				draw_item_tile(x, y + 0, 14, 826, 11);
			}
			else if (id == 51) // Map
			{
				draw_item_tile(x, y + 0, 12, 826, 11);
			}
			else if (id == 52) // 1 rupee
			{
				draw_item_tile(x + 4, y + 0, 0, 828, 11, false, false, 1);
			}
			else if (id == 53) // 5 rupee
			{
				draw_item_tile(x + 4, y + 0, 0, 828, 7, false, false, 1);
			}
			else if (id == 54) // 20 rupees
			{
				draw_item_tile(x + 4, y + 0, 0, 828, 5, false, false, 1);
			}
			else if (id == 55) // Green Pendant
			{
				draw_item_tile(x + 0, y + 0, 4, 832, 11);
			}
			else if (id == 56) // Blue Pendant
			{
				draw_item_tile(x + 0, y + 0, 4, 832, 7);
			}
			else if (id == 57) // Red Pendant
			{
				draw_item_tile(x + 0, y + 0, 4, 832, 5);
			}
			else if (id == 58) // Bow & Arrows
			{
				draw_item_tile(x + 0, y + 0, 7, 828, 5);
			}
			else if (id == 59) // Bow & Silver Arrows
			{
				draw_item_tile(x + 0, y + 0, 9, 828, 7);
			}
			else if (id == 60) // Bee
			{
				draw_item_tile(x + 0, y + 0, 13, 828, 7);
			}
			else if (id == 61) // Fairy
			{
				draw_item_tile(x + 0, y + 0, 11, 828, 7);
			}
			else if (id == 62) // Boss Heart
			{
				draw_item_tile(x, y + 0, 6, 820, 5);
			}
			else if (id == 63) // Sanctuary heart?
			{
				draw_item_tile(x, y + 0, 6, 820, 5);
			}
			else if (id == 64) // 100 rupees
			{
				draw_item_tile(x, y, 9, 830, 11);
			}
			else if (id == 65) // 50 rupees
			{
				draw_item_tile(x, y, 11, 830, 11);
			}
			else if (id == 66) // Small heart
			{
				draw_item_tile(x + 4, y, 6, 830, 5, false, false, 1);
			}
			else if (id == 67) // 1 Arrow
			{
				draw_item_tile(x + 4, y, 8, 830, 11, false, false, 1);
			}
			else if (id == 68) // 10 Arrow
			{
				draw_item_tile(x, y + 0, 4, 820, 11);
			}
			else if (id == 69) // Magic
			{
				draw_item_tile(x + 4, y, 7, 830, 11, false, false, 1);
			}
			else if (id == 70) // 300 Rupees
			{
				draw_item_tile(x, y, 13, 830, 11);
			}
			else if (id == 71) // 20 rupees
			{
				draw_item_tile(x + 0, y + 0, 0, 832, 11);
			}
			else if (id == 72) // Bee
			{
				draw_item_tile(x + 0, y + 0, 13, 828, 7);
			}
			else if (id == 73) // Sword 1
			{
				draw_item_tile(x + 4, y + 0, 1, 822, 7, false, false, 1);
			}
			else if (id == 74) // Flute activated
			{
				draw_item_tile(x, y, 2, 830, 7);
			}
			else if (id == 75) // Boots
			{
				draw_item_tile(x + 0, y + 0, 2, 832, 5);
			}
		}*/




		public static void ItemReceiptDraw00(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw01(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw02(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw03(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw04(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw05(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw06(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw07(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw08(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw09(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw0A(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw0B(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw0C(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw0D(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw0E(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw0F(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw10(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw11(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw12(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw13(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw14(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw15(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw16(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw17(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw18(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw19(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw1A(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw1B(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw1C(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw1D(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw1E(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw1F(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw20(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw21(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw22(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw23(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw24(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw25(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw26(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw27(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw28(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw29(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw2A(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw2B(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw2C(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw2D(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw2E(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw2F(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw30(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw31(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw32(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw33(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw34(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw35(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw36(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw37(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw38(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw39(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw3A(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw3B(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw3C(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw3D(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw3E(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw3F(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw40(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw41(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw42(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw43(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw44(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw45(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw46(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw47(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw48(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw49(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw4A(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

		public static void ItemReceiptDraw4B(Artist art, DungeonChestItem d)
		{
			DrawTiles(art, d, new OAMDrawInfo());
		}

	}
}
