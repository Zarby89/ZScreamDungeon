namespace ZeldaFullEditor.Data
{
	public class RoomObjectTileLister
	{
		private readonly TilesList[] _list = new TilesList[0x300];

		public TilesList this[int i] => _list[i];

		private readonly DoorTilesList[] _doors = new DoorTilesList[0x80];

		private readonly ZScreamer ZS;
		public RoomObjectTileLister(ZScreamer zs)
		{
			ZS = zs;
		}

		public DoorTilesList GetDoorTileSet(byte id)
		{
			return _doors[id];
		}

		public void InitializeTilesFromROM()
		{
			AutoFindTiles(0x000, 4);
			AutoFindTiles(0x001, 8);
			AutoFindTiles(0x002, 8);
			AutoFindTiles(0x003, 8);
			AutoFindTiles(0x004, 8);
			AutoFindTiles(0x005, 8);
			AutoFindTiles(0x006, 8);
			AutoFindTiles(0x007, 8);
			AutoFindTiles(0x008, 4);
			AutoFindTiles(0x009, 5);
			AutoFindTiles(0x00A, 5);
			AutoFindTiles(0x00B, 5);
			AutoFindTiles(0x00C, 5);
			AutoFindTiles(0x00D, 5);
			AutoFindTiles(0x00E, 5);
			AutoFindTiles(0x00F, 5);
			AutoFindTiles(0x010, 5);
			AutoFindTiles(0x011, 5);
			AutoFindTiles(0x012, 5);
			AutoFindTiles(0x013, 5);
			AutoFindTiles(0x014, 5);
			AutoFindTiles(0x015, 5);
			AutoFindTiles(0x016, 5);
			AutoFindTiles(0x017, 5);
			AutoFindTiles(0x018, 5);
			AutoFindTiles(0x019, 5);
			AutoFindTiles(0x01A, 5);
			AutoFindTiles(0x01B, 5);
			AutoFindTiles(0x01C, 5);
			AutoFindTiles(0x01D, 5);
			AutoFindTiles(0x01E, 5);
			AutoFindTiles(0x01F, 5);
			AutoFindTiles(0x020, 5);
			AutoFindTiles(0x021, 9);
			AutoFindTiles(0x022, 3);
			AutoFindTiles(0x023, 3);
			AutoFindTiles(0x024, 3);
			AutoFindTiles(0x025, 3);
			AutoFindTiles(0x026, 3);
			AutoFindTiles(0x027, 3);
			AutoFindTiles(0x028, 3);
			AutoFindTiles(0x029, 3);
			AutoFindTiles(0x02A, 3);
			AutoFindTiles(0x02B, 3);
			AutoFindTiles(0x02C, 3);
			AutoFindTiles(0x02D, 3);
			AutoFindTiles(0x02E, 3);
			AutoFindTiles(0x02F, 6);
			AutoFindTiles(0x030, 6);
			AutoFindTiles(0x031, 0); // nothings
			AutoFindTiles(0x032, 0); // nothings
			AutoFindTiles(0x033, 16);
			AutoFindTiles(0x034, 1);
			AutoFindTiles(0x035, 1);
			AutoFindTiles(0x036, 16);
			AutoFindTiles(0x037, 16);
			AutoFindTiles(0x038, 6);
			AutoFindTiles(0x039, 8);
			AutoFindTiles(0x03A, 12);
			AutoFindTiles(0x03B, 12);
			AutoFindTiles(0x03C, 4);
			AutoFindTiles(0x03D, 8);
			AutoFindTiles(0x03E, 4);
			AutoFindTiles(0x03F, 3);
			AutoFindTiles(0x040, 3);
			AutoFindTiles(0x041, 3);
			AutoFindTiles(0x042, 3);
			AutoFindTiles(0x043, 3);
			AutoFindTiles(0x044, 3);
			AutoFindTiles(0x045, 3);
			AutoFindTiles(0x046, 3);
			AutoFindTiles(0x047, 0); // TODO
			AutoFindTiles(0x048, 0); // TODO
			AutoFindTiles(0x049, 8);
			AutoFindTiles(0x04A, 8);
			AutoFindTiles(0x04B, 4);
			AutoFindTiles(0x04C, 9);
			AutoFindTiles(0x04D, 16);
			AutoFindTiles(0x04E, 16);
			AutoFindTiles(0x04F, 16);
			AutoFindTiles(0x050, 1);
			AutoFindTiles(0x051, 18);
			AutoFindTiles(0x052, 18);
			AutoFindTiles(0x053, 4);
			AutoFindTiles(0x054, 0); // nothing
			AutoFindTiles(0x055, 8);
			AutoFindTiles(0x056, 8);
			AutoFindTiles(0x057, 0); // nothing
			AutoFindTiles(0x058, 0); // nothing
			AutoFindTiles(0x059, 0); // nothing
			AutoFindTiles(0x05A, 0); // nothing
			AutoFindTiles(0x05B, 18);
			AutoFindTiles(0x05C, 18);
			AutoFindTiles(0x05D, 15);
			AutoFindTiles(0x05E, 4);
			AutoFindTiles(0x05F, 3);
			AutoFindTiles(0x060, 4);
			AutoFindTiles(0x061, 8);
			AutoFindTiles(0x062, 8);
			AutoFindTiles(0x063, 8);
			AutoFindTiles(0x064, 8);
			AutoFindTiles(0x065, 8);
			AutoFindTiles(0x066, 8);
			AutoFindTiles(0x067, 4);
			AutoFindTiles(0x068, 4);
			AutoFindTiles(0x069, 3);
			AutoFindTiles(0x06A, 1);
			AutoFindTiles(0x06B, 1);
			AutoFindTiles(0x06C, 6);
			AutoFindTiles(0x06D, 6);
			AutoFindTiles(0x06E, 0); // nothing
			AutoFindTiles(0x06F, 0); // nothing
			AutoFindTiles(0x070, 16);
			AutoFindTiles(0x071, 1);
			AutoFindTiles(0x072, 0); // nothing
			AutoFindTiles(0x073, 16);
			AutoFindTiles(0x074, 16);
			AutoFindTiles(0x075, 8);
			AutoFindTiles(0x076, 16);
			AutoFindTiles(0x077, 16);
			AutoFindTiles(0x078, 4);
			AutoFindTiles(0x079, 1);
			AutoFindTiles(0x07A, 1);
			AutoFindTiles(0x07B, 4);
			AutoFindTiles(0x07C, 1);
			AutoFindTiles(0x07D, 4);
			AutoFindTiles(0x07E, 0); // nothing
			AutoFindTiles(0x07F, 8);
			AutoFindTiles(0x080, 8);
			AutoFindTiles(0x081, 12);
			AutoFindTiles(0x082, 12);
			AutoFindTiles(0x083, 12);
			AutoFindTiles(0x084, 12);
			AutoFindTiles(0x085, 18);
			AutoFindTiles(0x086, 18);
			AutoFindTiles(0x087, 8);
			AutoFindTiles(0x088, 12);
			AutoFindTiles(0x089, 4);
			AutoFindTiles(0x08A, 3);
			AutoFindTiles(0x08B, 3);
			AutoFindTiles(0x08C, 3);
			AutoFindTiles(0x08D, 1);
			AutoFindTiles(0x08E, 1);
			AutoFindTiles(0x08F, 6);
			AutoFindTiles(0x090, 8);
			AutoFindTiles(0x091, 8);
			AutoFindTiles(0x092, 4);
			AutoFindTiles(0x093, 4);
			AutoFindTiles(0x094, 16);
			AutoFindTiles(0x095, 4);
			AutoFindTiles(0x096, 4);
			AutoFindTiles(0x097, 0); // nothing
			AutoFindTiles(0x098, 0); // nothing
			AutoFindTiles(0x099, 0); // nothing
			AutoFindTiles(0x09A, 0); // nothing
			AutoFindTiles(0x09B, 0); // nothing
			AutoFindTiles(0x09C, 0); // nothing
			AutoFindTiles(0x09D, 0); // nothing
			AutoFindTiles(0x09E, 0); // nothing
			AutoFindTiles(0x09F, 0); // nothing
			AutoFindTiles(0x0A0, 1);
			AutoFindTiles(0x0A1, 1);
			AutoFindTiles(0x0A2, 1);
			AutoFindTiles(0x0A3, 1);
			AutoFindTiles(0x0A4, 24);
			AutoFindTiles(0x0A5, 1);
			AutoFindTiles(0x0A6, 1);
			AutoFindTiles(0x0A7, 1);
			AutoFindTiles(0x0A8, 1);
			AutoFindTiles(0x0A9, 1);
			AutoFindTiles(0x0AA, 1);
			AutoFindTiles(0x0AB, 1);
			AutoFindTiles(0x0AC, 1);
			AutoFindTiles(0x0AD, 0); // nothing
			AutoFindTiles(0x0AE, 0); // nothing
			AutoFindTiles(0x0AF, 0); // nothing
			AutoFindTiles(0x0B0, 1);
			AutoFindTiles(0x0B1, 1);
			AutoFindTiles(0x0B2, 16);
			AutoFindTiles(0x0B3, 3);
			AutoFindTiles(0x0B4, 3);
			AutoFindTiles(0x0B5, 8);
			AutoFindTiles(0x0B6, 8);
			AutoFindTiles(0x0B7, 8);
			AutoFindTiles(0x0B8, 4);
			AutoFindTiles(0x0B9, 4);
			AutoFindTiles(0x0BA, 16);
			AutoFindTiles(0x0BB, 4);
			AutoFindTiles(0x0BC, 4);
			AutoFindTiles(0x0BD, 4);
			AutoFindTiles(0x0BE, 0); // nothing
			AutoFindTiles(0x0BF, 0); // nothing
			AutoFindTiles(0x0C0, 1);
			AutoFindTiles(0x0C1, 68);
			AutoFindTiles(0x0C2, 1);
			AutoFindTiles(0x0C3, 1);
			AutoFindTiles(0x0C4, 8); // TODO handle floor 1
			AutoFindTiles(0x0C5, 8);
			AutoFindTiles(0x0C6, 8);
			AutoFindTiles(0x0C7, 8);
			AutoFindTiles(0x0C8, 8);
			AutoFindTiles(0x0C9, 8);
			AutoFindTiles(0x0CA, 8);
			AutoFindTiles(0x0CB, 0); // nothing
			AutoFindTiles(0x0CC, 0); // nothing


			// big boy stuff
			SetTilesFromMultipleAddresses(0x0CD,
				(ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subytype1TileDataPointers + (0xCD * 2), 2], 24),
				(ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subytype1TileDataPointers, 2], 4)
			);
			SetTilesFromMultipleAddresses(0x0CE,
				(ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subytype1TileDataPointers + (0xCE * 2), 2], 24),
				(ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.Subytype1TileDataPointers, 2], 4)
			);


			AutoFindTiles(0x0CF, 0); // nothing
			AutoFindTiles(0x0D0, 0); // nothing
			AutoFindTiles(0x0D1, 8);
			AutoFindTiles(0x0D2, 8);
			AutoFindTiles(0x0D3, 0); // ????
			AutoFindTiles(0x0D4, 0); // ????
			AutoFindTiles(0x0D5, 0); // ????
			AutoFindTiles(0x0D6, 0); // ????
			AutoFindTiles(0x0D7, 1);
			AutoFindTiles(0x0D8, 8);
			AutoFindTiles(0x0D9, 8);
			AutoFindTiles(0x0DA, 8);
			AutoFindTiles(0x0DB, 8); // TODO handle floor 2
			AutoFindTiles(0x0DC, 21);
			AutoFindTiles(0x0DD, 16);
			AutoFindTiles(0x0DE, 4);
			AutoFindTiles(0x0DF, 8);
			AutoFindTiles(0x0E0, 8);
			AutoFindTiles(0x0E1, 8);
			AutoFindTiles(0x0E2, 8);
			AutoFindTiles(0x0E3, 8);
			AutoFindTiles(0x0E4, 8);
			AutoFindTiles(0x0E5, 8);
			AutoFindTiles(0x0E6, 8);
			AutoFindTiles(0x0E7, 8);
			AutoFindTiles(0x0E8, 8);
			AutoFindTiles(0x0E9, 0); // nothing
			AutoFindTiles(0x0EA, 0); // nothing
			AutoFindTiles(0x0EB, 0); // nothing
			AutoFindTiles(0x0EC, 0); // nothing
			AutoFindTiles(0x0ED, 0); // nothing
			AutoFindTiles(0x0EE, 0); // nothing
			AutoFindTiles(0x0EF, 0); // nothing
			AutoFindTiles(0x0F0, 0); // nothing
			AutoFindTiles(0x0F1, 0); // nothing
			AutoFindTiles(0x0F2, 0); // nothing
			AutoFindTiles(0x0F3, 0); // nothing
			AutoFindTiles(0x0F4, 0); // nothing
			AutoFindTiles(0x0F5, 0); // nothing
			AutoFindTiles(0x0F6, 0); // nothing
			AutoFindTiles(0x0F7, 0); // nothing

			// subtype 2
			AutoFindTiles(0x100, 16);
			AutoFindTiles(0x101, 16);
			AutoFindTiles(0x102, 16);
			AutoFindTiles(0x103, 16);
			AutoFindTiles(0x104, 16);
			AutoFindTiles(0x105, 16);
			AutoFindTiles(0x106, 16);
			AutoFindTiles(0x107, 16);
			AutoFindTiles(0x108, 16);
			AutoFindTiles(0x109, 16);
			AutoFindTiles(0x10A, 16);
			AutoFindTiles(0x10B, 16);
			AutoFindTiles(0x10C, 16);
			AutoFindTiles(0x10D, 16);
			AutoFindTiles(0x10E, 16);
			AutoFindTiles(0x10F, 16);
			AutoFindTiles(0x110, 12);
			AutoFindTiles(0x111, 12);
			AutoFindTiles(0x112, 12);
			AutoFindTiles(0x113, 12);
			AutoFindTiles(0x114, 12);
			AutoFindTiles(0x115, 12);
			AutoFindTiles(0x116, 12);
			AutoFindTiles(0x117, 12);
			AutoFindTiles(0x118, 4);
			AutoFindTiles(0x119, 4);
			AutoFindTiles(0x11A, 4);
			AutoFindTiles(0x11B, 4);
			AutoFindTiles(0x11C, 16);
			AutoFindTiles(0x11D, 6);
			AutoFindTiles(0x11E, 4);
			AutoFindTiles(0x11F, 4);
			AutoFindTiles(0x120, 4);
			AutoFindTiles(0x121, 6);
			AutoFindTiles(0x122, 20);
			AutoFindTiles(0x123, 12);
			AutoFindTiles(0x124, 16);
			AutoFindTiles(0x125, 16);
			AutoFindTiles(0x126, 6);
			AutoFindTiles(0x127, 4);
			AutoFindTiles(0x128, 20);
			AutoFindTiles(0x129, 16);
			AutoFindTiles(0x12A, 8);
			AutoFindTiles(0x12B, 4);
			AutoFindTiles(0x12C, 18);
			AutoFindTiles(0x12D, 16);
			AutoFindTiles(0x12E, 16);
			AutoFindTiles(0x12F, 16);
			AutoFindTiles(0x130, 16);
			AutoFindTiles(0x131, 16);
			AutoFindTiles(0x132, 16);
			AutoFindTiles(0x133, 16);
			AutoFindTiles(0x134, 4);
			AutoFindTiles(0x135, 8);
			AutoFindTiles(0x136, 8);
			AutoFindTiles(0x137, 40);
			AutoFindTiles(0x138, 12);
			AutoFindTiles(0x139, 12);
			AutoFindTiles(0x13A, 12);
			AutoFindTiles(0x13B, 12);
			AutoFindTiles(0x13C, 24);
			AutoFindTiles(0x13D, 12);
			AutoFindTiles(0x13E, 16);
			AutoFindTiles(0x13F, 56);


			// subtype 3
			AutoFindTiles(0x200, 12);
			AutoFindTiles(0x201, 20);
			AutoFindTiles(0x202, 28);
			AutoFindTiles(0x203, 1);
			AutoFindTiles(0x204, 1);
			AutoFindTiles(0x205, 1);
			AutoFindTiles(0x206, 1);
			AutoFindTiles(0x207, 1);
			AutoFindTiles(0x208, 1);
			AutoFindTiles(0x209, 1);
			AutoFindTiles(0x20A, 1);
			AutoFindTiles(0x20B, 1);
			AutoFindTiles(0x20C, 1);
			AutoFindTiles(0x020D, 6);
			AutoFindTiles(0x20E, 1);
			AutoFindTiles(0x20F, 1);
			AutoFindTiles(0x210, 4);
			AutoFindTiles(0x211, 4);
			AutoFindTiles(0x212, 4);
			AutoFindTiles(0x213, 4);
			AutoFindTiles(0x214, 12);
			AutoFindTiles(0x215, 80);
			AutoFindTiles(0x216, 4);
			AutoFindTiles(0x217, 6);
			AutoFindTiles(0x218, 4);
			AutoFindTiles(0x219, 4);
			AutoFindTiles(0x21A, 4);
			AutoFindTiles(0x21B, 16);
			AutoFindTiles(0x21C, 16);
			AutoFindTiles(0x21D, 16);
			AutoFindTiles(0x21E, 16);
			AutoFindTiles(0x21F, 16);
			AutoFindTiles(0x220, 16);
			AutoFindTiles(0x221, 16);
			AutoFindTiles(0x222, 4);
			AutoFindTiles(0x223, 4);
			AutoFindTiles(0x224, 4);
			AutoFindTiles(0x225, 4);
			AutoFindTiles(0x226, 16);
			AutoFindTiles(0x227, 16);
			AutoFindTiles(0x228, 16);
			AutoFindTiles(0x229, 16);
			AutoFindTiles(0x22A, 16);
			AutoFindTiles(0x22B, 4);
			AutoFindTiles(0x22C, 16);
			SetTilesFromKnownOffset(0x22D, 0x1B4A, 84);
			SetTilesFromKnownOffset(0x22E, 0x1BF2, 127);
			AutoFindTiles(0x22F, 4);
			AutoFindTiles(0x230, 4);
			AutoFindTiles(0x231, 12);
			AutoFindTiles(0x232, 12);
			AutoFindTiles(0x233, 16);
			AutoFindTiles(0x234, 6);
			AutoFindTiles(0x235, 6);
			AutoFindTiles(0x236, 18);
			AutoFindTiles(0x237, 18);
			AutoFindTiles(0x238, 18);
			AutoFindTiles(0x239, 18);
			AutoFindTiles(0x23A, 24);
			AutoFindTiles(0x23B, 24);
			AutoFindTiles(0x23C, 24);
			AutoFindTiles(0x23D, 24);
			AutoFindTiles(0x23E, 4);
			AutoFindTiles(0x23F, 4);
			AutoFindTiles(0x240, 4);
			AutoFindTiles(0x241, 4);
			AutoFindTiles(0x242, 4);
			AutoFindTiles(0x243, 4);
			AutoFindTiles(0x244, 4);
			AutoFindTiles(0x245, 4);
			AutoFindTiles(0x246, 4);
			AutoFindTiles(0x247, 16);
			AutoFindTiles(0x248, 16);
			AutoFindTiles(0x249, 4);
			AutoFindTiles(0x24A, 4);
			AutoFindTiles(0x24B, 24);
			AutoFindTiles(0x24C, 48);
			AutoFindTiles(0x24D, 18);
			AutoFindTiles(0x24E, 12);
			AutoFindTiles(0x24F, 4);
			AutoFindTiles(0x250, 4);
			AutoFindTiles(0x251, 4);
			AutoFindTiles(0x252, 4);
			AutoFindTiles(0x253, 4);
			AutoFindTiles(0x254, 26);
			AutoFindTiles(0x255, 16);
			AutoFindTiles(0x256, 4);
			AutoFindTiles(0x257, 4);
			AutoFindTiles(0x258, 6);
			AutoFindTiles(0x259, 4);
			AutoFindTiles(0x25A, 8);
			AutoFindTiles(0x25B, 32);
			AutoFindTiles(0x25C, 24);
			AutoFindTiles(0x25D, 18);
			AutoFindTiles(0x25E, 4);
			AutoFindTiles(0x25F, 4);
			AutoFindTiles(0x260, 18);
			AutoFindTiles(0x261, 18);
			AutoFindTiles(0x262, 242);
			AutoFindTiles(0x263, 4);
			AutoFindTiles(0x264, 4);
			AutoFindTiles(0x265, 4);
			AutoFindTiles(0x266, 16);
			AutoFindTiles(0x267, 12);
			AutoFindTiles(0x268, 12);
			AutoFindTiles(0x269, 12);
			AutoFindTiles(0x26A, 12);
			AutoFindTiles(0x26B, 16);
			AutoFindTiles(0x26C, 12);
			AutoFindTiles(0x26D, 12);
			AutoFindTiles(0x26E, 12);
			AutoFindTiles(0x26F, 12);
			AutoFindTiles(0x270, 32);
			AutoFindTiles(0x271, 64);
			AutoFindTiles(0x272, 80);
			AutoFindTiles(0x273, 1);
			AutoFindTiles(0x274, 64);
			AutoFindTiles(0x275, 4);
			AutoFindTiles(0x276, 64);
			AutoFindTiles(0x277, 24);
			AutoFindTiles(0x278, 32);
			AutoFindTiles(0x279, 12);
			AutoFindTiles(0x27A, 16);
			AutoFindTiles(0x27B, 8);
			AutoFindTiles(0x27C, 4);
			AutoFindTiles(0x27D, 4);
			AutoFindTiles(0x27E, 4);

			// Doors
			AutoFindDoorTiles(0x00);
			AutoFindDoorTiles(0x02);
			AutoFindDoorTiles(0x04);
			AutoFindDoorTiles(0x06);
			AutoFindDoorTiles(0x08);
			AutoFindDoorTiles(0x0A);
			AutoFindDoorTiles(0x0C);
			AutoFindDoorTiles(0x0E);
			AutoFindDoorTiles(0x10);
			AutoFindDoorTiles(0x12);
			AutoFindDoorTiles(0x14);
			AutoFindDoorTiles(0x16);
			AutoFindDoorTiles(0x18);
			AutoFindDoorTiles(0x1A);
			AutoFindDoorTiles(0x1C);
			AutoFindDoorTiles(0x1E);
			AutoFindDoorTiles(0x20);
			AutoFindDoorTiles(0x22);
			AutoFindDoorTiles(0x24);
			AutoFindDoorTiles(0x26);
			AutoFindDoorTiles(0x28);
			AutoFindDoorTiles(0x2A);
			AutoFindDoorTiles(0x2C);
			AutoFindDoorTiles(0x2E);
			AutoFindDoorTiles(0x30);
			AutoFindDoorTiles(0x32);
			AutoFindDoorTiles(0x34);
			AutoFindDoorTiles(0x36);
			AutoFindDoorTiles(0x38);
			AutoFindDoorTiles(0x3A);
			AutoFindDoorTiles(0x3C);
			AutoFindDoorTiles(0x3E);
			AutoFindDoorTiles(0x40);
			AutoFindDoorTiles(0x42);
			AutoFindDoorTiles(0x44);
			AutoFindDoorTiles(0x46);
			AutoFindDoorTiles(0x48);
			AutoFindDoorTiles(0x4A);
			AutoFindDoorTiles(0x4C);
			AutoFindDoorTiles(0x4E);
			AutoFindDoorTiles(0x50);
			AutoFindDoorTiles(0x52);
			AutoFindDoorTiles(0x54);
			AutoFindDoorTiles(0x56);
			AutoFindDoorTiles(0x58);
			AutoFindDoorTiles(0x5A);
			AutoFindDoorTiles(0x5C);
			AutoFindDoorTiles(0x5E);
			AutoFindDoorTiles(0x60);
			AutoFindDoorTiles(0x62);
			AutoFindDoorTiles(0x64);
			AutoFindDoorTiles(0x66);
		}


		private void AutoFindTiles(ushort id, int count)
		{
			int typebase;
			switch (id >> 8)
			{
				case 0x00:
					typebase = ZS.Offsets.Subytype1TileDataPointers;
					break;

				case 0x01:
					typebase = ZS.Offsets.Subtype2TileDataPointers;
					break;

				case 0x02:
					typebase = ZS.Offsets.Subtype3TileDataPointers;
					break;

				default:
					return;
			}

			int pos = ZS.Offsets.tile_address + ZS.ROM[typebase + (((byte) id) * 2), 2];
			_list[id] = TilesList.CreateNewDefinition(ZS, pos, count);
		}


		private void SetTilesFromKnownOffset(ushort id, int offset, int count)
		{
			_list[id] = TilesList.CreateNewDefinition(ZS, ZS.Offsets.tile_address + offset, count);
		}

		private void SetTilesFromMultipleAddresses(ushort id, params (int address, int count)[] sources)
		{
			_list[id] = TilesList.CreateNewDefinitionFromMultipleAddresses(ZS, sources);
		}

		private void AutoFindDoorTiles(byte id)
		{
			_doors[id] = DoorTilesList.CreateNewDefinition(ZS,
				ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.door_gfx_up + id, 2],
				ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.door_gfx_down + id, 2],
				ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.door_gfx_left + id, 2],
				ZS.Offsets.tile_address + ZS.ROM[ZS.Offsets.door_gfx_right + id, 2]
			);
		}
	}
}
