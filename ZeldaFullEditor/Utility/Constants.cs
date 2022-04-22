using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public static partial class Constants
	{
		//===========================================================================================
		// Magic numbers
		//===========================================================================================
		public const ushort TilePriorityBit = 0x2000;
		public const ushort TileHFlipBit = 0x4000;
		public const ushort TileVFlipBit = 0x8000;
		public const ushort TileNameMask = 0x03FF;

		public const int Uncompressed3BPPSize = 0x0600;
		public const int UncompressedSheetSize = 0x0800;

		public const int NumberOfSheets = 223;
		public const int LimitOfMap32 = 8864;
		public const int NumberOfRooms = 296;

		public const int NumberOfOWMaps = 160;
		public const int Map32PerScreen = 256;
		public const int NumberOfMap16 = 3752; // 4096
		public const int NumberOfMap32 = Map32PerScreen * NumberOfOWMaps;
		public const int NumberOfOWSprites = 352;
		public const int NumberOfColors = 3143;

		public const int NumberOfEntranceTypes = 0x2B;
		public const int NumberOfOverworldExits = 0x4F;
		public const int NumberOfOverworldGraves = 0x0F;
		public const int NumberOfEntrances = 0x85;
		public const int NumberOfChests = 168;


		public const int ROMSize = 0x200000;
		public const int ROMHeaderSize = 0x200;

		public const int RoomsPerFloorOnMap = 25;
		public const int TilesPerUnderworldRoom = 4096;
		public const int TilesPerTilemap = 4096;

		public const int ColorsPerPalette = 16;
		public const int ColorsPerHalfPalette = 8;
		public const int NumberOfPalettes = 16;
		public const int TotalPaletteSize = ColorsPerPalette * NumberOfPalettes;

		// TODO zarby stop making magic numbers
		public const int IDKZarby = 0x54727;

		public static byte[] FontSpacings = new byte[] {
			4, 3, 5, 7, 5, 6, 5, 3, 4, 4, 5, 5, 3, 5, 3, 5,
			5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 3, 3, 5, 5, 5, 5,
			5, 5, 5, 5, 5, 5, 5, 6, 5, 5, 6, 5, 5, 7, 6, 5,
			5, 5, 5, 5, 5, 5, 5, 7, 5, 5, 5, 4, 5, 4, 6, 6, 6, 6 };

		//===========================================================================================
		// Yes
		//===========================================================================================
		public const int OverworldSpritePointers = 0x09_0000;
		public const int DungeonSpritePointers = 0x09_0000;

		public const byte BigKeyDropToken = 0xFD;
		public const byte SmallKeyDropToken = 0xFE;
		public const byte KeyDropID = 0xE4;

		//===========================================================================================
		// IDs
		//===========================================================================================
		public const ushort ChestID = 0x219;
		public const ushort BigChestID = 0x231;
		public const ushort TorchPseudoID = 0x0E00;

		public const byte SpriteTerminator = 0xFF;

		public const byte LayerMergeOff = 0x00;
		public const byte LayerMergeParallax = 0x01;
		public const byte LayerMergeDark = 0x02;
		public const byte LayerMergeOnTop = 0x03;
		public const byte LayerMergeTranslucent = 0x04;
		public const byte LayerMergeAddition = 0x05;
		public const byte LayerMergeNormal = 0x06;
		public const byte LayerMergeTransparent = 0x07;
		public const byte LayerMergeDarkRoom = 0x08;

		//===========================================================================================
		// Clipboard stuff
		//===========================================================================================
		public const string OverworldSpriteClipboardData = "owsprite";
		public const string OverworldTilesClipboardData = "owtiles";
		public const string OverworldEntranceClipboardData = "owentrance";
		public const string OverworldExitClipboardData = "owexit";
		public const string OverworldItemClipboardData = "owitem";

		public const string ObjectZClipboardData = "objectz";

		//===========================================================================================
		// Geometry - for consistency and we should probably give them better names
		//===========================================================================================
		public static readonly Point Point_0_0 = new Point(0, 0);
		public static readonly Point Point_512_0 = new Point(512, 0);

		public static readonly Rectangle Rect_0_0_24_24 = new Rectangle(0, 0, 24, 24);
		public static readonly Rectangle Rect_0_0_64_64 = new Rectangle(0, 0, 64, 64);
		public static readonly Rectangle Rect_0_0_64_128 = new Rectangle(0, 0, 64, 128);
		public static readonly Rectangle Rect_0_0_128_128 = new Rectangle(0, 0, 128, 128);
		public static readonly Rectangle Rect_0_0_128_512 = new Rectangle(0, 0, 128, 512);
		public static readonly Rectangle Rect_0_0_128_4096 = new Rectangle(0, 0, 128, 4096);
		public static readonly Rectangle Rect_0_0_256_192 = new Rectangle(0, 0, 256, 192);
		public static readonly Rectangle Rect_0_0_256_256 = new Rectangle(0, 0, 256, 256);
		public static readonly Rectangle Rect_0_0_256_1024 = new Rectangle(0, 0, 256, 1024);
		public static readonly Rectangle Rect_0_0_1024_1024 = new Rectangle(0, 0, 1024, 1024);
		public static readonly Rectangle Rect_0_0_512_384 = new Rectangle(0, 0, 512, 384);
		public static readonly Rectangle Rect_0_0_512_512 = new Rectangle(0, 0, 512, 512);
		public static readonly Rectangle Rect_0_0_128_40 = new Rectangle(0, 0, 128, 40);
		public static readonly Rectangle Rect_0_0_256_14272 = new Rectangle(0, 0, 256, 14272);
		public static readonly Rectangle Rect_0_0_128_7136 = new Rectangle(0, 0, 128, 7136);

		public static readonly Rectangle Rect_128_0_128_4096 = new Rectangle(128, 0, 128, 4096);
		public static readonly Rectangle Rect_0_4096_128_4096 = new Rectangle(0, 4096, 128, 4096);

		public static readonly Rectangle Rect_0_0_340_102 = new Rectangle(0, 0, 170, 102);
		public static readonly Rectangle Rect_0_0_170_51 = new Rectangle(0, 0, 170, 51);
		public static readonly Rectangle Rect_336_0_4_102 = new Rectangle(336, 0, 4, 102);

		public static readonly Rectangle Rect_1_1_182_182 = new Rectangle(1, 1, 182, 182);
		public static readonly Rectangle Rect_3_3_178_178 = new Rectangle(3, 3, 178, 178);
		public static readonly Rectangle Rect_0_0_24_240 = new Rectangle(0, 0, 24, 240);

		public static readonly Size Size340x102 = new Size(340, 102);
		public static readonly Size Size512x512 = new Size(512, 512);
		public static readonly Size Size1024x1024 = new Size(1024, 1024);
		public static readonly Size Size4096x4096 = new Size(4096, 4096);

		//===========================================================================================
		// Fonts
		//===========================================================================================
		public static readonly Font Arial7 = new Font("Arial", 7);

		//===========================================================================================
		// Colors - colors we use for consistency and we should probably give them better names
		//===========================================================================================
		public static readonly Color HalfWhite = Color.FromArgb(128, 255, 255, 255);
		public static readonly Color HalfWhite2 = Color.FromArgb(255, 255, 255);
		public static readonly Pen HalfWhitePen = new Pen(HalfWhite);

		public static readonly Color ThirdWhite = Color.FromArgb(85, 255, 255, 255);
		public static readonly Pen ThirdWhitePen = new Pen(ThirdWhite);
		public static readonly Pen ThirdWhitePen1 = new Pen(ThirdWhite, 1);

		public static readonly Color White100 = Color.FromArgb(100, 255, 255, 255);
		public static readonly Pen White100Pen = new Pen(White100);
		public static readonly Pen White100Pen1 = new Pen(White100, 1);

		public static readonly Color HalfRed = Color.FromArgb(128, 255, 0, 0);
		public static readonly Pen HalfRedPen = new Pen(HalfRed);
		public static readonly Brush HalfRedBrush = new SolidBrush(HalfRed);

		public static readonly Color ThirdGreen = Color.FromArgb(100, 0, 200, 0);
		public static readonly Pen ThirdGreenPen = new Pen(ThirdGreen);
		public static readonly Brush ThirdGreenBrush = new SolidBrush(ThirdGreen);

		public static readonly Color QuarterWhite = Color.FromArgb(60, 255, 255, 255);
		public static readonly Pen QuarterWhitePen = new Pen(QuarterWhite);

		public static readonly Color FifthBlue = Color.FromArgb(50, 0, 0, 255);
		public static readonly Brush FifthBlueBrush = new SolidBrush(FifthBlue);

		public static readonly Pen Orange220Pen1 = new Pen(Color.FromArgb(220, Color.Orange), 1);
		public static readonly Pen Red220Pen1 = new Pen(Color.FromArgb(220, Color.Red), 1);

		public static readonly Pen WhitePen = new Pen(Brushes.White);
		public static readonly Pen LimeGreenPen2 = new Pen(Brushes.LimeGreen, 2);
		public static readonly Pen AquaPen2 = new Pen(Brushes.Aqua, 2);
		public static readonly Pen BlackPen2 = new Pen(Brushes.Black, 2);
		public static readonly Pen AzurePen2 = new Pen(Color.Azure, 2);
		public static readonly Pen RedPen4 = new Pen(Color.Red, 2);


		public static readonly Color Black200 = Color.FromArgb(200, 0, 0, 0);
		public static readonly Pen Black200Pen = new Pen(Black200);
		public static readonly Brush Black200Brush = new SolidBrush(Black200);

		public static readonly Color Scarlet200 = Color.FromArgb(200, 200, 0, 0);
		public static readonly Pen Scarlet200Pen = new Pen(Scarlet200);
		public static readonly Brush Scarlet200Brush = new SolidBrush(Scarlet200);

		public static readonly Color Turquoise200 = Color.FromArgb(200, 0, 200, 200);
		public static readonly Pen Turquoise200Pen = new Pen(Turquoise200);
		public static readonly Brush Turquoise200Brush = new SolidBrush(Turquoise200);

		public static readonly Color VibrantMagenta200 = Color.FromArgb(200, 255, 0, 255);
		public static readonly Pen VibrantMagenta200Pen = new Pen(VibrantMagenta200);
		public static readonly Brush VibrantMagenta200Brush = new SolidBrush(VibrantMagenta200);

		public static readonly Color Magenta200 = Color.FromArgb(200, 222, 16, 145);
		public static readonly Pen Magenta200Pen = new Pen(Magenta200);
		public static readonly Brush Magenta200Brush = new SolidBrush(Magenta200);

		public static readonly Color MediumGray200 = Color.FromArgb(200, 160, 160, 160);
		public static readonly Pen MediumGray200Pen = new Pen(MediumGray200);
		public static readonly Brush MediumGray200Brush = new SolidBrush(MediumGray200);

		public static readonly Color LightGray200 = Color.FromArgb(200, 222, 222, 222);
		public static readonly Pen LightGray200Pen = new Pen(LightGray200);
		public static readonly Brush LightGray200Brush = new SolidBrush(LightGray200);

		public static readonly Color DarkMint200 = Color.FromArgb(200, 48, 188, 142);
		public static readonly Pen DarkMint200Pen = new Pen(DarkMint200);
		public static readonly Brush DarkMint200Brush = new SolidBrush(DarkMint200);

		public static readonly Color MediumMint200 = Color.FromArgb(200, 14, 224, 146);
		public static readonly Pen MediumMint200Pen = new Pen(MediumMint200);
		public static readonly Brush MediumMint200Brush = new SolidBrush(MediumMint200);

		public static readonly Color Charcoal200 = Color.FromArgb(200, 32, 32, 32);
		public static readonly Pen Charcoal200Pen = new Pen(Charcoal200);
		public static readonly Brush Charcoal200Brush = new SolidBrush(Charcoal200);

		public static readonly Color Goldenrod200 = Color.FromArgb(200, 255, 200, 16);
		public static readonly Pen Goldenrod200Pen = new Pen(Goldenrod200);
		public static readonly Brush Goldenrod200Brush = new SolidBrush(Goldenrod200);

		public static readonly Color Azure200 = Color.FromArgb(200, 0, 55, 240);
		public static readonly Pen Azure200Pen = new Pen(Azure200);
		public static readonly Brush Azure200Brush = new SolidBrush(Azure200);

		//===========================================================================================
		// GFX Related Variables
		//===========================================================================================
//		public static int tile_address = 0x1B52; // JP = Same //i don't think that need a pointer
//		public static int tile_address_floor = 0x1B5A; // JP = Same //i don't think that need a pointer
//		public static int subtype1_tiles = 0x8000; // JP = Same //i don't think that need a pointer
//		public static int subtype2_tiles = 0x83F0; // JP = Same //i don't think that need a pointer
//		public static int subtype3_tiles = 0x84F0; // JP = Same //i don't think that need a pointer
//		public static int gfx_animated_pointer = 0x10275; // JP 0x10624 //long pointer
//		public static int overworldgfxGroups2 = 0x6073; // 0x60B3
//		public static int gfx_1_pointer = 0x6790; // 2byte pointer bank 00 pc -> 0x4320  CF80  ; 004F80
//		public static int gfx_2_pointer = 0x6795; // D05F ; 00505F
//		public static int gfx_3_pointer = 0x679A; // D13E ; 00513E
//		public static int hud_palettes = 0xDD660;
//		public static int maxGfx = 0xC3FB5;
//
//		//===========================================================================================
//		// Overworld Related Variables
//		//===========================================================================================
//		public static int compressedAllMap32PointersHigh = 0x1794D;
//		public static int compressedAllMap32PointersLow = 0x17B2D;
//		public static int overworldgfxGroups = 0x05D97;
//		public static int map16Tiles = 0x78000;
//		public static int Map32DefinitionsTL = 0x18000;
//		public static int Map32DefinitionsTR = 0x1B400;
//		public static int Map32DefinitionsBL = 0x20000;
//		public static int Map32DefinitionsBR = 0x23400;
//		public static int overworldPalGroup1 = 0xDE6C8;
//		public static int overworldPalGroup2 = 0xDE86C;
//		public static int overworldPalGroup3 = 0xDE604;
//		public static int overworldMapPalette = 0x7D1C;
//		public static int overworldSpritePalette = 0x7B41;
//		public static int overworldMapPaletteGroup = 0x75504;
//		public static int overworldSpritePaletteGroup = 0x75580;
//		public static int overworldSpriteset = 0x7A41;
//		public static int overworldSpecialGFXGroup = 0x16821;
//		public static int overworldSpecialPALGroup = 0x16831;
//
//		public static int OverworldSpritesTableState0 = 0x4C881;
//		public static int OverworldSpritesTableState3 = 0x4CA21;
//		public static int OverworldSpritesTableState2 = 0x4C901;
//
//
//		public static int overworldSpritesBeginingEditor = 0x108100;
//		public static int overworldSpritesAgahnimEditor = 0x108180;
//		public static int overworldSpritesZeldaEditor = 0x1082A0;
//
//		public static int overworldItemsPointers = 0xDC2F9;
//		public static int overworldItemsAddress = 0xDC8B9; // 1BC2F9
//		public static int overworldItemsBank = 0xDC8BF;
//		public static int overworldItemsEndData = 0xDC89C; // 0DC89E
//
//		public static int mapGfx = 0x7C9C;
//		public static int overlayPointers = 0x77664;
//		public static int overlayPointersBank = 0x0E0000;
//
//		public static int overworldTilesType = 0x71459;
//		public static int overworldMessages = 0x3F51D;
//
//		// TODO:
//		public static int overworldMusicBegining = 0x14303;
//		public static int overworldMusicZelda = 0x14303 + 0x40;
//		public static int overworldMusicMasterSword = 0x14303 + 0x80;
//		public static int overworldMusicAgahim = 0x14303 + 0xC0;
//		public static int overworldMusicDW = 0x14403;
//
//		public static int overworldEntranceAllowedTilesLeft = 0xDB8C1;
//		public static int overworldEntranceAllowedTilesRight = 0xDB917;
//
//		public static int overworldMapSize = 0x12844; // 0x00 = small maps, 0x20 = large maps
//		public static int overworldMapSizeHighByte = 0x12884; // 0x01 = small maps, 0x03 = large maps
//
//		// relative to the WORLD + 0x200 per map
//		// large map that are not == parent id = same position as their parent!
//		// eg for X position small maps :
//		// 0000, 0200, 0400, 0600, 0800, 0A00, 0C00, 0E00
//
//		// all Large map would be :
//		// 0000, 0000, 0400, 0400, 0800, 0800, 0C00, 0C00
//
//		public static int overworldMapParentId = 0x125EC;
//
//		public static int overworldTransitionPositionY = 0x128C4;
//		public static int overworldTransitionPositionX = 0x12944;
//
//		public static int overworldScreenSize = 0x1788D;
//
//		public static int OverworldScreenSizeForLoading = 0x4C635;
//		public static int OverworldScreenTileMapChangeByScreen = 0x12634;
//
//		public static int transition_target_north = 0x13EE2;
//		public static int transition_target_west = 0x13F62;
//
//		//===========================================================================================
//		// Overworld Exits/Entrances Variables
//		//===========================================================================================
//		public static int OWExitRoomId = 0x15D8A; // 0x15E07 Credits sequences
//												  // 105C2 Ending maps
//												  // 105E2 Sprite Group Table for Ending
//		public static int OWExitMapId = 0x15E28;
//		public static int OWExitVram = 0x15E77;
//		public static int OWExitYScroll = 0x15F15;
//		public static int OWExitXScroll = 0x15FB3;
//		public static int OWExitYPlayer = 0x16051;
//		public static int OWExitXPlayer = 0x160EF;
//		public static int OWExitYCamera = 0x1618D;
//		public static int OWExitXCamera = 0x1622B;
//		public static int OWExitDoorPosition = 0x15724;
//		public static int OWExitUnk1 = 0x162C9;
//		public static int OWExitUnk2 = 0x16318;
//		public static int OWExitDoorType1 = 0x16367;
//		public static int OWExitDoorType2 = 0x16405;
//		public static int OWEntranceMap = 0xDB96F;
//		public static int OWEntrancePos = 0xDBA71;
//		public static int OWEntranceEntranceId = 0xDBB73;
//		public static int OWHolePos = 0xDB800; // (0x13 entries, 2 bytes each) modified(less 0x400) map16 coordinates for each hole
//		public static int OWHoleArea = 0xDB826; // (0x13 entries, 2 bytes each) corresponding area numbers for each hole
//		public static int OWHoleEntrance = 0xDB84C; // (0x13 entries, 1 byte each)  corresponding entrance numbers
//
//		public static int OWExitMapIdWhirlpool = 0x16AE5;  // JP = ;016849
//		public static int OWExitVramWhirlpool = 0x16B07;   // JP = ;01686B
//		public static int OWExitYScrollWhirlpool = 0x16B29;// JP = ;01688D
//		public static int OWExitXScrollWhirlpool = 0x16B4B;// JP = ;016DE7
//		public static int OWExitYPlayerWhirlpool = 0x16B6D;// JP = ;016E09
//		public static int OWExitXPlayerWhirlpool = 0x16B8F;// JP = ;016E2B
//		public static int OWExitYCameraWhirlpool = 0x16BB1;// JP = ;016E4D
//		public static int OWExitXCameraWhirlpool = 0x16BD3;// JP = ;016E6F
//		public static int OWExitUnk1Whirlpool = 0x16BF5;   // JP = ;016E91
//		public static int OWExitUnk2Whirlpool = 0x16C17;   // JP = ;016EB3
//		public static int OWWhirlpoolPosition = 0x16CF8;   // JP = ;016F94
//
//		//===========================================================================================
//		// Dungeon Related Variables
//		//===========================================================================================
//		// That could be turned into a pointer : 
//		public static int dungeons_palettes_groups = 0x75460; // JP 0x67DD0
//		public static int dungeons_main_bg_palette_pointers = 0xDEC4B; // JP Same
//		public static int dungeons_palettes = 0xDD734; // JP Same (where all dungeons palettes are) 
//
//		// That could be turned into a pointer : 
//		public static int room_items_pointers = 0xDB69;// JP 0xDB67
//
//		public static int rooms_sprite_pointer = 0x4C298; // JP Same //2byte bank 09D62E
//		public static int room_header_pointer = 0xB5DD; // LONG
//		public static int room_header_pointers_bank = 0xB5E7; // JP Same
//
//		public static int gfx_groups_pointer = 0x6237;
//		public static int room_object_layout_pointer = 0x882D;
//
//		public static int room_object_pointer = 0x874C; // Long pointer
//
//		public static int chests_length_pointer = 0xEBF6;
//		public static int chests_data_pointer1 = 0xEBFB;
//		public static int chests_data_pointer2 = 0xEC0A; // Disabled for now could be used for expansion
//		public static int chests_data_pointer3 = 0xEC10; // Disabled for now could be used for expansion
//
//		public static int blocks_length = 0x8896; // Word value 
//		public static int blocks_pointer1 = 0x15AFA;
//		public static int blocks_pointer2 = 0x15B01;
//		public static int blocks_pointer3 = 0x15B08;
//		public static int blocks_pointer4 = 0x15B0F;
//
//		public static int torch_data = 0x2736A; // JP 0x2704A
//		public static int torches_length_pointer = 0x88C1;
//
//		public static int sprite_blockset_pointer = 0x5B57;
//		public static int sprites_data = 0x4D8B0; // It use the unused pointers to have more space //Save purpose
//		public static int sprites_data_empty_room = 0x4D8AE;
//		public static int sprites_end_data = 0x4EC9E;
//
//		public static int pit_pointer = 0x394AB;
//		public static int pit_count = 0x394A6;
//
//		public static int doorPointers = 0xF83C0;
//
//		// doors
//		public static int door_gfx_up = 0x4D9E;
//		public static int door_gfx_down = 0x4E06;
//		public static int door_gfx_cavexit_down = 0x4E06;
//		public static int door_gfx_left = 0x4E66;
//		public static int door_gfx_right = 0x4EC6;
//
//		public static int door_pos_up = 0x197E;
//		public static int door_pos_down = 0x1996;
//		public static int door_pos_left = 0x19AE;
//		public static int door_pos_right = 0x19C6;
//
//		// TEXT EDITOR RELATED CONSTANTS
//		public static int gfx_font = 0x70000; // 2bpp format
//		public static int text_data = 0xE0000;
//		public static int text_data2 = 0x75F40;
//		public static int pointers_dictionaries = 0x74703;
//		public static int characters_width = 0x74ADF;
//
//		//===========================================================================================
//		//Dungeon Entrances Related Variables
//		//===========================================================================================
//		public static int entrance_room = 0x14813; // 0x14577 // Word value for each room
//		public static int entrance_scrolledge = 0x1491D; // 0x14681 // 8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
//		public static int entrance_cameray = 0x14D45; // 0x14AA9 // 2bytes each room
//		public static int entrance_camerax = 0x14E4F; // 0x14BB3 // 2bytes
//		public static int entrance_yposition = 0x14F59; //0x14CBD 2bytes
//		public static int entrance_xposition = 0x15063;// 0x14DC7 2bytes
//		public static int entrance_cameraytrigger = 0x1516D;// 0x14ED1 2bytes
//		public static int entrance_cameraxtrigger = 0x15277;// 0x14FDB 2bytes
//
//		public static int entrance_gfx_group = 0x5D97;
//		public static int entrance_blockset = 0x15381; // 0x150E5 1byte
//		public static int entrance_floor = 0x15406; // 0x1516A 1byte
//		public static int entrance_dungeon = 0x1548B; // 0x151EF 1byte (dungeon id)
//		public static int entrance_door = 0x15510; // 0x15274 1byte
//		public static int entrance_ladderbg = 0x15595; //0x152F9 // 1byte, ---b ---a b = bg2, a = need to check -_-
//		public static int entrance_scrolling = 0x1561A; // 0x1537E // 1byte --h- --v- 
//		public static int entrance_scrollquadrant = 0x1569F; // 0x15403 1byte
//		public static int entrance_exit = 0x15724; // 0x15488 // 2byte word
//		public static int entrance_music = 0x1582E; // 0x15592
//
//		public static int startingentrance_room = 0x15B6E; // 0x158D2 // Word value for each room
//		public static int startingentrance_scrolledge = 0x15B7C; // 0x158E0 // 8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
//		public static int startingentrance_cameray = 0x15BB4; // 0x14AA9 // 2bytes each room
//		public static int startingentrance_camerax = 0x15BC2; // 0x14BB3 // 2bytes
//		public static int startingentrance_yposition = 0x15BD0; // 0x14CBD 2bytes
//		public static int startingentrance_xposition = 0x15BDE; // 0x14DC7 2bytes
//		public static int startingentrance_cameraytrigger = 0x15BEC; // 0x14ED1 2bytes
//		public static int startingentrance_cameraxtrigger = 0x15BFA; // 0x14FDB 2bytes
//
//		public static int startingentrance_blockset = 0x15C08; // 0x150E5 1byte
//		public static int startingentrance_floor = 0x15C0F; // 0x1516A 1byte
//		public static int startingentrance_dungeon = 0x15C16; // 0x151EF 1byte (dungeon id)
//
//		public static int startingentrance_door = 0x15C2B; // 0x15274 1byte
//
//		public static int startingentrance_ladderbg = 0x15C1D; // 0x152F9 // 1byte, ---b ---a b = bg2, a = need to check -_-
//		public static int startingentrance_scrolling = 0x15C24; // 0x1537E // 1byte --h- --v- 
//		public static int startingentrance_scrollquadrant = 0x15C2B; // 0x15403 1byte
//		public static int startingentrance_exit = 0x15C32; // 0x15488 // 2byte word
//		public static int startingentrance_music = 0x15C4E; // 0x15592
//		public static int startingentrance_entrance = 0x15C40;
//
//		public static int items_data_start = 0xDDE9; // Save purpose
//		public static int items_data_end = 0xE6B2; // Save purpose
//		public static int initial_equipement = 0x271A6;
//		public static int messages_id_dungeon = 0x3F61D;
//
//		public static int chests_backupitems = 0x3B528; // Item id you get instead if you already have that item
//		public static int chests_yoffset = 0x4836C;
//		public static int chests_xoffset = 0x4836C + (76 * 1);
//		public static int chests_itemsgfx = 0x4836C + (76 * 2);
//		public static int chests_itemswide = 0x4836C + (76 * 3);
//		public static int chests_itemsproperties = 0x4836C + (76 * 4);
//		public static int chests_sramaddress = 0x4836C + (76 * 5);
//		public static int chests_sramvalue = 0x4836C + (76 * 7);
//		public static int chests_msgid = 0x442DD;
//
//		public static int dungeons_startrooms = 0x7939;
//		public static int dungeons_endrooms = 0x792D;
//		public static int dungeons_bossrooms = 0x10954; // Short value
//
//		// Bed Related Values (Starting location)
//
//		public static int bedPositionX = 0x039A37; // Short value
//		public static int bedPositionY = 0x039A32; // Short value
//
//		public static int bedPositionResetXLow = 0x02DE53;  // Short value(on 2 different bytes)
//		public static int bedPositionResetXHigh = 0x02DE58; // ^^^^^^
//
//		public static int bedPositionResetYLow = 0x02DE5D; // Short value(on 2 different bytes)
//		public static int bedPositionResetYHigh = 0x02DE62;// ^^^^^^
//
//		public static int bedSheetPositionX = 0x0480BD; // Short value
//		public static int bedSheetPositionY = 0x0480B8; // Short value
//
//		//===========================================================================================
//		// Gravestones related variables
//		//===========================================================================================
//
//		public static int GravesYTilePos = 0x49968; // Short (0x0F entries)
//		public static int GravesXTilePos = 0x49986; // Short (0x0F entries)
//		public static int GravesTilemapPos = 0x499A4; // Short (0x0F entries)
//		public static int GravesGFX = 0x499C2; // Short (0x0F entries)
//
//		public static int GravesXPos = 0x4994A;  // Short (0x0F entries)
//		public static int GravesYLine = 0x4993A; // Short (0x08 entries)
//		public static int GravesCountOnY = 0x499E0; // Byte 0x09 entries
//
//		public static int GraveLinkSpecialHole = 0x46DD9; // Short
//		public static int GraveLinkSpecialStairs = 0x46DE0; // Short
//
//		//===========================================================================================
//		// Palettes Related Variables - This contain all the palettes of the game
//		//===========================================================================================
//		public static int overworldPaletteMain = 0xDE6C8;
//		public static int overworldPaletteAuxialiary = 0xDE86C;
//		public static int overworldPaletteAnimated = 0xDE604;
//		public static int globalSpritePalettesLW = 0xDD218;
//		public static int globalSpritePalettesDW = 0xDD290;
//		public static int armorPalettes = 0xDD308; // Green, Blue, Red, Bunny, Electrocuted (15 colors each)
//		public static int spritePalettesAux1 = 0xDD39E; // 7 colors each
//		public static int spritePalettesAux2 = 0xDD446; // 7 colors each
//		public static int spritePalettesAux3 = 0xDD4E0; // 7 colors each
//		public static int swordPalettes = 0xDD630; // 3 colors each - 4 entries
//		public static int shieldPalettes = 0xDD648; // 4 colors each - 3 entries
//		public static int hudPalettes = 0xDD660;
//		public static int dungeonMapPalettes = 0xDD70A; // 21 colors
//		public static int dungeonMainPalettes = 0xDD734; // (15*6) colors each - 20 entries
//		public static int dungeonMapBgPalettes = 0xDE544; // 16*6
//		public static int hardcodedGrassLW = 0x5FEA9; // Mirrored Value at 0x75645 : 0x75625
//		public static int hardcodedGrassDW = 0x05FEB3; // 0x7564F;
//		public static int hardcodedGrassSpecial = 0x75640;
//
//		//===========================================================================================
//		// Dungeon Map Related Variables
//		//===========================================================================================
//		public static int dungeonMap_rooms_ptr = 0x57605; // 14 pointers of map data
//		public static int dungeonMap_floors = 0x575D9; // 14 words values
//
//		public static int dungeonMap_gfx_ptr = 0x57BE4; // 14 pointers of gfx data
//		public static int dungeonMap_datastart = 0x57039; // Data start for floors/gfx MUST skip 575D9 to 57621 (pointers)
//
//
//		public static int dungeonMap_expCheck = 0x56652; // IF Byte = 0xB9 dungeon maps are not expanded
//		public static int dungeonMap_tile16 = 0x57009;
//		public static int dungeonMap_tile16Exp = 0x109010;
//		public static int dungeonMap_bossrooms = 0x56807; // 14 words values 0x000F = no boss
//
//		public static int triforceVertices = 0x04FFD2; // Group of 3, X, Y ,Z
//		public static int TriforceFaces = 0x04FFE4; // Group of 5
//
//		public static int crystalVertices = 0x04FF98;
//
//		public static bool Rando = false; // Is it a rando rom?
//
//		//===========================================================================================
//		// Stuff
//		//===========================================================================================
//		public const int DungeonSpritePointers = 0x09_0000;
//		public const int OverworldSpritePointers = 0x09_0000;
//
//		public static void Init_Jp(bool rando = false)
//		{
//			pit_pointer = 0x394A2;
//			pit_count = 0x3949D;
//			// 04EF2F
//			dungeons_palettes_groups = 0x67DD0;
//			room_items_pointers = 0xDB67;
//			torch_data = 0x2704A;
//
//			entrance_gfx_group = 0x5DD7;
//			sprite_blockset_pointer = 0x5B97;
//			blocks_pointer1 = 0x1585E;
//			blocks_pointer2 = 0x15865;
//			blocks_pointer3 = 0x1586C;
//			blocks_pointer4 = 0x15873;
//			chests_length_pointer = 0xEBF4;
//			chests_data_pointer1 = 0xEBF9;
//			gfx_groups_pointer = 0x6277;
//			items_data_start = 0xDDE7;
//			items_data_end = 0xE6B0;
//			gfx_1_pointer = 0x67D0; // 2byte pointer bank 00 -> pc 0x4FC0
//			gfx_2_pointer = 0x67D5; // 509F
//			gfx_3_pointer = 0x67DA; // 517E
//			messages_id_dungeon = 0x3F5F7;
//			gfx_animated_pointer = 0x10624;
//			initial_equipement = 0x183000;
//
//			// Entrances
//			entrance_room = 0x14577; // Word value for each room
//			entrance_scrolledge = 0x1491D; // 0x14681 / /8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
//			entrance_camerax = 0x14AA9; // 2bytes each room
//			entrance_cameray = 0x14BB3; // 2bytes
//			entrance_yposition = 0x14CBD; // 2bytes
//			entrance_xposition = 0x14DC7; // 2bytes
//			entrance_cameraytrigger = 0x14ED1; // 2bytes
//			entrance_cameraxtrigger = 0x14FDB; // 2bytes
//			entrance_blockset = 0x150E5; // 1byte
//			entrance_floor = 0x1516A; // 1byte
//			entrance_dungeon = 0x151EF; // 1byte (dungeon id)
//			entrance_door = 0x15274; // 1byte
//			entrance_ladderbg = 0x152F9; //1 byte, ---b ---a b = bg2, a = need to check -_-
//			entrance_scrolling = 0x1537E; //1byte --h- --v- 
//			entrance_scrollquadrant = 0x15403; // 1byte
//			entrance_exit = 0x15488; // 2byte word
//			entrance_music = 0x15592;
//
//			startingentrance_room -= 0x29C; // 0x158D2 // word value for each room
//			startingentrance_scrolledge -= 0x29C; // 0x158E0 //8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
//			startingentrance_cameray -= 0x29C; // 0x14AA9 // 2bytes each room
//			startingentrance_camerax -= 0x29C; // 0x14BB3 // 2bytes
//			startingentrance_yposition -= 0x29C; // 0x14CBD 2bytes
//			startingentrance_xposition -= 0x29C; // 0x14DC7 2bytes
//			startingentrance_cameraytrigger -= 0x29C; // 0x14ED1 2bytes
//			startingentrance_cameraxtrigger -= 0x29C; // 0x14FDB 2bytes
//
//			startingentrance_blockset -= 0x29C; // 0x150E5 1byte
//			startingentrance_floor -= 0x29C; // 0x1516A 1byte
//			startingentrance_dungeon -= 0x29C; // 0x151EF 1byte (dungeon id)
//
//			startingentrance_door -= 0x29C; // 0x15274 1byte
//
//			startingentrance_ladderbg -= 0x29C; // 0x152F9 //1 byte, ---b ---a b = bg2, a = need to check -_-
//			startingentrance_scrolling -= 0x29C; // 0x1537E //1byte --h- --v- 
//			startingentrance_scrollquadrant -= 0x29C; // 0x15403 1byte
//			startingentrance_exit -= 0x29C; // 0x15488 // 2byte word
//			startingentrance_music -= 0x29C; // 0x15592
//			startingentrance_entrance -= 0x29C;
//
//			// us = 0x05D97 / jp = 0x05DD7
//			overworldgfxGroups = 0x05DD7;
//			hardcodedGrassLW = 0x67FE6;
//			hardcodedGrassDW = 0x67FF0; // map>40
//			hardcodedGrassSpecial = 0x67FE1; // map 183,182,180
//
//			OWExitRoomId = 0x15D8A - 0x29C;
//			OWExitMapId = 0x15E28 - 0x29C;
//			OWExitVram = 0x15E77 - 0x29C;
//			OWExitYScroll = 0x15F15 - 0x29C;
//			OWExitXScroll = 0x15FB3 - 0x29C;
//			OWExitYPlayer = 0x16051 - 0x29C;
//			OWExitXPlayer = 0x160EF - 0x29C;
//			OWExitYCamera = 0x1618D - 0x29C;
//			OWExitXCamera = 0x1622B - 0x29C;
//			OWExitUnk1 = 0x162C9 - 0x29C;
//			OWExitUnk2 = 0x16318 - 0x29C;
//			OWExitDoorType1 = 0x16367 - 0x29C;
//			OWExitDoorType2 = 0x16405 - 0x29C;
//
//			overworldgfxGroups2 = 0x60B3;
//
//			/*
//            public static int Map32DefinitionsTL = 0x18000;
//            public static int Map32DefinitionsTR = 0x1B400;
//            public static int Map32DefinitionsBL = 0x20000;
//            public static int Map32DefinitionsBR = 0x23400;
//            */
//
//			Map32DefinitionsTL = 0x18000;
//			Map32DefinitionsTR = 0x1B3C0;
//			Map32DefinitionsBL = 0x20000;
//			Map32DefinitionsBR = 0x233C0;
//			compressedAllMap32PointersHigh = 0x176B1; // LONGPointers all tiles of maps[High] (mapid* 3)
//			compressedAllMap32PointersLow = 0x17891; // LONGPointers all tiles of maps[Low] (mapid* 3)
//			overworldMapPalette = 0x7D1C; // JP
//			overworldMapPaletteGroup = 0x67E74;
//			overworldMapSize = 0x1273B; // JP
//			overlayPointers = 0x3FAF4;
//			overlayPointersBank = 0x070000;
//			overworldTilesType = 0x7FD94;
//			Rando = rando;
//
//			if (rando)
//			{
//				// TODO: Add condition here?
//			}
//		}
	}

}
