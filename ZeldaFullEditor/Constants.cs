using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public static class Constants
    {
        // ===========================================================================================
        // Magic numbers
        // ===========================================================================================
        /// <summary>
        /// Bit set for object priority
        /// </summary>
        public const ushort TilePriorityBit = 0x2000;

        /// <summary>
        /// Bit set for object hflip
        /// </summary>
        public const ushort TileHFlipBit = 0x4000;

        /// <summary>
        /// Bit set for object vflip
        /// </summary>
        public const ushort TileVFlipBit = 0x8000;

        /// <summary>
        /// Bits used for tile name
        /// </summary>
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
        public const int NumberOfColors = 3415; //3143

        // TODO zarby stop making magic numbers
        public const int IDKZarby = 0x54727;

        public static byte[] FontSpacings = new byte[] { 4, 3, 5, 7, 5, 6, 5, 3, 4, 4, 5, 5, 3, 5, 3, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 3, 3, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 5, 5, 6, 5, 5, 7, 6, 5, 5, 5, 5, 5, 5, 5, 5, 7, 5, 5, 5, 4, 5, 4, 6, 6, 6, 6 };

        // ===========================================================================================
        // Geometry - shapes and points we don't need to constantly reinstantiate
        // ===========================================================================================
        public static readonly Point Point_0_0 = new Point(0, 0);
        public static readonly Point Point_512_0 = new Point(512, 0);

        // TODO these could probably use more descriptive names
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

        // ===========================================================================================
        // Fonts
        // ===========================================================================================
        public static readonly Font Arial7 = new Font("Arial", 7);

        // ===========================================================================================
        // Colors - colors we use for consistency and avoiding redundant instantiations
        // ===========================================================================================
        public static readonly Color HalfWhite = Color.FromArgb(128, 255, 255, 255);
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

        // ===========================================================================================
        // GFX Related Variables
        // ===========================================================================================
        public static int tile_address = 0x1B52; // JP = Same //i don't think that need a pointer
        public static int tile_address_floor = 0x1B5A; // JP = Same //i don't think that need a pointer
        public static int subtype1_tiles = 0x8000; // JP = Same //i don't think that need a pointer
        public static int subtype2_tiles = 0x83F0; // JP = Same //i don't think that need a pointer
        public static int subtype3_tiles = 0x84F0; // JP = Same //i don't think that need a pointer
        public static int gfx_animated_pointer = 0x10275; // JP 0x10624 //long pointer
        public static int overworldgfxGroups2 = 0x6073; // 0x60B3
        public static int gfx_1_pointer = 0x6790; // 2byte pointer bank 00 pc -> 0x4320  CF80  ; 004F80
        public static int gfx_2_pointer = 0x6795; // D05F ; 00505F
        public static int gfx_3_pointer = 0x679A; // D13E ; 00513E
        public static int hud_palettes = 0xDD660;
        public static int maxGfx = 0xC3FB5;

        // ===========================================================================================
        // Overworld Related Variables
        // ===========================================================================================
        public static int compressedAllMap32PointersHigh = 0x1794D;
        public static int compressedAllMap32PointersLow = 0x17B2D;
        public static int overworldgfxGroups = 0x05D97;
        public static int map16Tiles = 0x78000;
        public static int map32TilesTL = 0x18000;
        public static int map32TilesTR = 0x1B400;
        public static int map32TilesBL = 0x20000;
        public static int map32TilesBR = 0x23400;
        public static int Map32TilesCount = 0x33F0;
        public static int overworldPalGroup1 = 0xDE6C8;
        public static int overworldPalGroup2 = 0xDE86C;
        public static int overworldPalGroup3 = 0xDE604;
        public static int overworldMapPalette = 0x7D1C;
        public static int overworldSpritePalette = 0x7B41;
        public static int overworldMapPaletteGroup = 0x75504;
        public static int overworldSpritePaletteGroup = 0x75580;
        public static int overworldSpriteset = 0x7A41;
        public static int overworldSpecialGFXGroup = 0x16821;
        public static int overworldSpecialPALGroup = 0x16831;

        public static int overworldSpritesBegining = 0x4C881;
        public static int overworldSpritesAgahnim = 0x4CA21;
        public static int overworldSpritesZelda = 0x4C901;

        /*
        public static int overworldSpritesBeginingEditor = 0x108100;
        public static int overworldSpritesAgahnimEditor = 0x108180;
        public static int overworldSpritesZeldaEditor = 0x1082A0;
        */

        public static int overworldItemsPointers = 0xDC2F9;
        public static int overworldItemsAddress = 0xDC8B9; // 1BC2F9
        public static int overworldItemsBank = 0xDC8BF;
        public static int overworldItemsEndData = 0xDC89C; // 0DC89E

        public static int mapGfx = 0x7C9C;
        public static int overlayPointers = 0x77664;
        public static int overlayPointersBank = 0x0E;
        public static int overlayData1 = 0x77676;
        public static int overlayData2 = 0x077677;

        public static int overworldTilesType = 0x71459;
        public static int overworldMessages = 0x3F51D;

        // TODO:
        public static int overworldMusicBegining = 0x14303; // 0x40
        public static int overworldMusicZelda = 0x14303 + 0x40; // 0x40
        public static int overworldMusicMasterSword = 0x14303 + 0x80; // 0x40
        public static int overworldMusicAgahim = 0x14303 + 0xC0; // 0x40
        public static int overworldMusicDW = 0x14403; // 0x60

        public static int overworldEntranceAllowedTilesLeft = 0xDB8C1;
        public static int overworldEntranceAllowedTilesRight = 0xDB917;

        public static int overworldMapSize = 0x12844; // 0x00 = small maps, 0x20 = large maps
        public static int overworldMapSizeHighByte = 0x12884; // 0x01 = small maps, 0x03 = large maps

        // relative to the WORLD + 0x200 per map
        // large map that are not == parent id = same position as their parent!
        // eg for X position small maps :
        // 0000, 0200, 0400, 0600, 0800, 0A00, 0C00, 0E00

        // all Large map would be :
        // 0000, 0000, 0400, 0400, 0800, 0800, 0C00, 0C00

        public static int overworldMapParentId = 0x125EC;

        public static int overworldTransitionPositionY = 0x128C4;
        public static int overworldTransitionPositionX = 0x12944;

        public static int overworldScreenSize = 0x1788D;

        public static int OverworldScreenSizeForLoading = 0x4C635;
        public static int OverworldScreenTileMapChangeByScreen1 = 0x12634;
        public static int OverworldScreenTileMapChangeByScreen2 = 0x126B4;
        public static int OverworldScreenTileMapChangeByScreen3 = 0x12734;
        public static int OverworldScreenTileMapChangeByScreen4 = 0x127B4;

        public static int OverworldScreenTileMapChangeMask = 0x1262C;

        public static int OverowrldMapDataOverflow = 0x130000;

        public static int transition_target_north = 0x13EE2;
        public static int transition_target_west = 0x13F62;

        public static int OverworldCustomASMHasBeenApplied = 0x140145; // 1 byte, not 0 if enabled

        public static int customAreaSpecificBGPalette = 0x140000; // 2 bytes for each overworld area (0x140)
        public static int customAreaSpecificBGEnabled = 0x140140; // 1 byte, not 0 if enabled

        public static int OverworldCustomMainPaletteArray = 0x140160; // 1 byte for each overworld area (0xA0)
        public static int OverworldCustomMainPaletteEnabled = 0x140141; // 1 byte, not 0 if enabled

        public static int OverworldCustomMosaicArray = 0x140200; // 1 byte for each overworld area (0xA0)
        public static int OverworldCustomMosaicEnabled = 0x140142; // 1 byte, not 0 if enabled

        public static int OverworldCustomAnimatedGFXArray = 0x1402A0; // 1 byte for each overworld area (0xA0)
        public static int OverworldCustomAnimatedGFXEnabled = 0x140143; // 1 byte, not 0 if enabled

        public static int OverworldCustomSubscreenOverlayArray = 0x140340; // 2 bytes for each overworld area (0x140)
        public static int OverworldCustomSubscreenOverlayEnabled = 0x140144; // 1 byte, not 0 if enabled

        // ===========================================================================================
        // Overworld Exits/Entrances Variables
        // ===========================================================================================
        public static int OWExitRoomId = 0x15D8A; // 0x15E07 Credits sequences
                                                  // 105C2 Ending maps
                                                  // 105E2 Sprite Group Table for Ending
        public static int OWExitMapId = 0x15E28;
        public static int OWExitVram = 0x15E77;
        public static int OWExitYScroll = 0x15F15;
        public static int OWExitXScroll = 0x15FB3;
        public static int OWExitYPlayer = 0x16051;
        public static int OWExitXPlayer = 0x160EF;
        public static int OWExitYCamera = 0x1618D;
        public static int OWExitXCamera = 0x1622B;
        public static int OWExitDoorPosition = 0x15724;
        public static int OWExitUnk1 = 0x162C9;
        public static int OWExitUnk2 = 0x16318;
        public static int OWExitDoorType1 = 0x16367;
        public static int OWExitDoorType2 = 0x16405;
        public static int OWEntranceMap = 0xDB96F;
        public static int OWEntrancePos = 0xDBA71;
        public static int OWEntranceEntranceId = 0xDBB73;
        public static int OWHolePos = 0xDB800; // (0x13 entries, 2 bytes each) modified(less 0x400) map16 coordinates for each hole
        public static int OWHoleArea = 0xDB826; // (0x13 entries, 2 bytes each) corresponding area numbers for each hole
        public static int OWHoleEntrance = 0xDB84C; // (0x13 entries, 1 byte each)  corresponding entrance numbers

        public static int OWExitMapIdWhirlpool = 0x16AE5;  // JP = ;016849
        public static int OWExitVramWhirlpool = 0x16B07;   // JP = ;01686B
        public static int OWExitYScrollWhirlpool = 0x16B29;// JP = ;01688D
        public static int OWExitXScrollWhirlpool = 0x16B4B;// JP = ;016DE7
        public static int OWExitYPlayerWhirlpool = 0x16B6D;// JP = ;016E09
        public static int OWExitXPlayerWhirlpool = 0x16B8F;// JP = ;016E2B
        public static int OWExitYCameraWhirlpool = 0x16BB1;// JP = ;016E4D
        public static int OWExitXCameraWhirlpool = 0x16BD3;// JP = ;016E6F
        public static int OWExitScrollModYWhirlpool = 0x16BF5;   // JP = ;016E91
        public static int OWExitScrollModXWhirlpool = 0x16C17;   // JP = ;016EB3
        public static int OWWhirlpoolPosition = 0x16CF8;   // JP = ;016F94
        public static int OWWhirlpoolCount = 0x11;

        // ===========================================================================================
        // Dungeon Related Variables
        // ===========================================================================================
        // That could be turned into a pointer :
        public static int dungeons_palettes_groups = 0x75460; // JP 0x67DD0
        public static int dungeons_main_bg_palette_pointers = 0xDEC4B; // JP Same
        public static int dungeons_palettes = 0xDD734; // JP Same (where all dungeons palettes are)

        // That could be turned into a pointer :
        public static int room_items_pointers = 0xDB69;// JP 0xDB67

        public static int rooms_sprite_pointer = 0x4C298; // JP Same //2byte bank 09D62E
        public static int room_header_pointer = 0xB5DD; // LONG
        public static int room_header_pointers_bank = 0xB5E7; // JP Same

        public static int gfx_groups_pointer = 0x6237;
        public static int room_object_layout_pointer = 0x882D;

        public static int room_object_pointer = 0x874C; // Long pointer

        public static int chests_length_pointer = 0xEBF6;
        public static int chests_data_pointer1 = 0xEBFB;
        //public static int chests_data_pointer2 = 0xEC0A; // Disabled for now could be used for expansion
        //public static int chests_data_pointer3 = 0xEC10; // Disabled for now could be used for expansion

        public static int blocks_length = 0x8896; // Word value
        public static int blocks_pointer1 = 0x15AFA;
        public static int blocks_pointer2 = 0x15B01;
        public static int blocks_pointer3 = 0x15B08;
        public static int blocks_pointer4 = 0x15B0F;

        public static int torch_data = 0x2736A; // JP 0x2704A
        public static int torches_length_pointer = 0x88C1;

        public static int sprite_blockset_pointer = 0x5B57;
        public static int sprites_data = 0x4D8B0; // It use the unused pointers to have more space //Save purpose
        public static int sprites_data_empty_room = 0x4D8AE;
        public static int sprites_end_data = 0x4EC9E;

        public static int pit_pointer = 0x394AB;
        public static int pit_count = 0x394A6;

        public static int doorPointers = 0xF83C0;

        // doors
        public static int door_gfx_up = 0x4D9E;
        public static int door_gfx_down = 0x4E06;
        public static int door_gfx_cavexit_down = 0x4E06;
        public static int door_gfx_left = 0x4E66;
        public static int door_gfx_right = 0x4EC6;

        public static int door_pos_up = 0x197E;
        public static int door_pos_down = 0x1996;
        public static int door_pos_left = 0x19AE;
        public static int door_pos_right = 0x19C6;

        // TEXT EDITOR RELATED CONSTANTS
        public static int gfx_font = 0x70000; // 2bpp format
        public static int text_data = 0xE0000;
        public static int text_data_end = 0xE7FFF;
        public static int text_data2 = 0x75F40;
        public static int text_data2_end = 0x773FF;
        public static int pointers_dictionaries = 0x74703;
        public static int characters_width = 0x74ADF;

        // ===========================================================================================
        // Dungeon Entrances Related Variables
        // ===========================================================================================
        public static int entrance_room = 0x14813; // 0x14577 // Word value for each room
        public static int entrance_scrolledge = 0x1491D; // 0x14681 // 8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
                                                         // TODO: Swap CameraX and CameraY position because X is stored first!!

        public static int entrance_cameray = 0x14D45; // 0x14AA9 // 2bytes each room
        public static int entrance_camerax = 0x14E4F; // 0x14BB3 // 2bytes
        public static int entrance_yposition = 0x14F59; // 0x14CBD 2bytes
        public static int entrance_xposition = 0x15063;// 0x14DC7 2bytes
        public static int entrance_cameraytrigger = 0x1516D;// 0x14ED1 2bytes
        public static int entrance_cameraxtrigger = 0x15277;// 0x14FDB 2bytes

        /// <summary>
        /// 128 is the valid low X range where the camera can be placed.
        /// Any less than the valid amount would result in the camera showing outside of the room and the camera not clipping correctly to walls.
        /// </summary>
        public static int CameraTriggerXLow = 128;

        /// <summary>
        /// 383 is the valid high X range where the camera can be placed.
        /// Any more than the valid amount would result in the camera showing outside of the room and the camera not clipping correctly to walls.
        /// </summary>
        public static int CameraTriggerXHigh = 383;

        /// <summary>
        /// 112 is the valid low Y range where the camera can be placed.
        /// Any less than the valid amount would result in the camera showing outside of the room and the camera not clipping correctly to walls.
        /// </summary>
        public static int CameraTriggerYLow = 112;

        /// <summary>
        /// 392 is the valid high Y range where the camera can be placed.
        /// Any more than the valid amount would result in the camera showing outside of the room and the camera not clipping correctly to walls.
        /// </summary>
        public static int CameraTriggerYHigh = 392;

        public static int entrance_gfx_group = 0x5D97;
        public static int entrance_blockset = 0x15381; // 0x150E5 1byte
        public static int entrance_floor = 0x15406; // 0x1516A 1byte
        public static int entrance_dungeon = 0x1548B; // 0x151EF 1byte (dungeon id)
        public static int entrance_door = 0x15510; // 0x15274 1byte
        public static int entrance_ladderbg = 0x15595; //0x152F9 // 1byte, ---b ---a b = bg2, a = need to check -_-
        public static int entrance_scrolling = 0x1561A; // 0x1537E // 1byte --h- --v-
        public static int entrance_scrollquadrant = 0x1569F; // 0x15403 1byte
        public static int entrance_exit = 0x15724; // 0x15488 // 2byte word
        public static int entrance_music = 0x1582E; // 0x15592

        public static int startingentrance_room = 0x15B6E; // 0x158D2 // Word value for each room
        public static int startingentrance_scrolledge = 0x15B7C; // 0x158E0 // 8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
        public static int startingentrance_cameray = 0x15BB4; // 0x14AA9 // 2bytes each room
        public static int startingentrance_camerax = 0x15BC2; // 0x14BB3 // 2bytes
        public static int startingentrance_yposition = 0x15BD0; // 0x14CBD 2bytes
        public static int startingentrance_xposition = 0x15BDE; // 0x14DC7 2bytes
        public static int startingentrance_cameraytrigger = 0x15BEC; // 0x14ED1 2bytes
        public static int startingentrance_cameraxtrigger = 0x15BFA; // 0x14FDB 2bytes

        public static int startingentrance_blockset = 0x15C08; // 0x150E5 1byte
        public static int startingentrance_floor = 0x15C0F; // 0x1516A 1byte
        public static int startingentrance_dungeon = 0x15C16; // 0x151EF 1byte (dungeon id)

        public static int startingentrance_door = 0x15C2B; // 0x15274 1byte

        public static int startingentrance_ladderbg = 0x15C1D; // 0x152F9 // 1byte, ---b ---a b = bg2, a = need to check -_-
        public static int startingentrance_scrolling = 0x15C24; // 0x1537E // 1byte --h- --v-
        public static int startingentrance_scrollquadrant = 0x15C2B; // 0x15403 1byte
        public static int startingentrance_exit = 0x15C32; // 0x15488 // 2byte word
        public static int startingentrance_music = 0x15C4E; // 0x15592
        public static int startingentrance_entrance = 0x15C40;

        public static int items_data_start = 0xDDE9; // Save purpose
        public static int items_data_end = 0xE6B2; // Save purpose
        public static int initial_equipement = 0x271A6;
        public static int messages_id_dungeon = 0x3F61D;

        public static int chests_backupitems = 0x3B528; // Item id you get instead if you already have that item
        public static int chests_yoffset = 0x4836C;
        public static int chests_xoffset = 0x4836C + (76 * 1);
        public static int chests_itemsgfx = 0x4836C + (76 * 2);
        public static int chests_itemswide = 0x4836C + (76 * 3);
        public static int chests_itemsproperties = 0x4836C + (76 * 4);
        public static int chests_sramaddress = 0x4836C + (76 * 5);
        public static int chests_sramvalue = 0x4836C + (76 * 7);
        public static int chests_msgid = 0x442DD;

        public static int dungeons_startrooms = 0x7939;
        public static int dungeons_endrooms = 0x792D;
        public static int dungeons_bossrooms = 0x10954; // Short value

        // Bed Related Values (Starting location)

        public static int bedPositionX = 0x039A37; // Short value
        public static int bedPositionY = 0x039A32; // Short value

        public static int bedPositionResetXLow = 0x02DE53;  // Short value(on 2 different bytes)
        public static int bedPositionResetXHigh = 0x02DE58; // ^^^^^^

        public static int bedPositionResetYLow = 0x02DE5D; // Short value(on 2 different bytes)
        public static int bedPositionResetYHigh = 0x02DE62;// ^^^^^^

        public static int bedSheetPositionX = 0x0480BD; // Short value
        public static int bedSheetPositionY = 0x0480B8; // Short value

        // ===========================================================================================
        // Gravestones related variables
        // ===========================================================================================
        public static int GravesYTilePos = 0x49968; // Short (0x0F entries)
        public static int GravesXTilePos = 0x49986; // Short (0x0F entries)
        public static int GravesTilemapPos = 0x499A4; // Short (0x0F entries)
        public static int GravesGFX = 0x499C2; // Short (0x0F entries)

        public static int GravesXPos = 0x4994A;  // Short (0x0F entries)
        public static int GravesYLine = 0x4993A; // Short (0x08 entries)
        public static int GravesCountOnY = 0x499E0; // Byte 0x09 entries

        public static int GraveLinkSpecialStairs = 0x46DD9; // Short
        public static int GraveLinkSpecialHole = 0x46DE0; // Short

        // ===========================================================================================
        // Palettes Related Variables - This contain all the palettes of the game
        // ===========================================================================================  asdfasdfasdfasfadf
        public static int overworldPaletteMain = 0xDE6C8;
        public static int overworldPaletteAuxialiary = 0xDE86C;
        public static int overworldPaletteAnimated = 0xDE604;
        public static int globalSpritePalettesLW = 0xDD218;
        public static int globalSpritePalettesDW = 0xDD290;
        public static int armorPalettes = 0xDD308; // Green, Blue, Red, Bunny, Electrocuted (15 colors each)
        public static int spritePalettesAux1 = 0xDD39E; // 7 colors each
        public static int spritePalettesAux2 = 0xDD446; // 7 colors each
        public static int spritePalettesAux3 = 0xDD4E0; // 7 colors each
        public static int swordPalettes = 0xDD630; // 3 colors each - 4 entries
        public static int shieldPalettes = 0xDD648; // 4 colors each - 3 entries
        public static int hudPalettes = 0xDD660;
        public static int dungeonMapPalettes = 0xDD70A; // 21 colors
        public static int dungeonMainPalettes = 0xDD734; // (15*6) colors each - 20 entries
        public static int dungeonMapBgPalettes = 0xDE544; // 16*6
        public static int hardcodedGrassLW1 = 0x05FEA9;
        public static int hardcodedGrassLW2 = 0x075645;
        public static int hardcodedGrassLW3 = 0x075625;
        public static int hardcodedGrassDW1 = 0x05FEB3;
        public static int hardcodedGrassDW2 = 0x07564F;
        public static int hardcodedGrassSpecial = 0x75640;
        public static int overworldMiniMapPalettes = 0x55B27;
        public static int triforcePalette = 0x64425;
        public static int crystalPalette = 0xF4CD3;

        // ===========================================================================================
        // Dungeon Map Related Variables
        // ===========================================================================================
        public static int dungeonMap_rooms_ptr = 0x57605; // 14 pointers of map data
        public static int dungeonMap_floors = 0x575D9; // 14 words values

        public static int dungeonMap_gfx_ptr = 0x57BE4; // 14 pointers of gfx data
        public static int dungeonMap_datastart = 0x57039; // Data start for floors/gfx MUST skip 575D9 to 57621 (pointers)

        public static int dungeonMap_expCheck = 0x56652; // IF Byte = 0xB9 dungeon maps are not expanded
        public static int dungeonMap_tile16 = 0x57009;
        public static int dungeonMap_tile16Exp = 0x109010;
        public static int dungeonMap_bossrooms = 0x56807; // 14 words values 0x000F = no boss

        public static int crystalVerticesCount = 0x4FF8C;
        public static int crystalFaceCount = 0x4FF8D;

        public static int crystalVerticesPointer = 0x4FF8E;
        public static int crystalFacesPointer = 0x4FF90;
        public static int crystalMaxSize = 0x3A;

        public static int triforceVerticesCount = 0x4FF92;
        public static int triforceFaceCount = 0x4FF93;

        public static int triforceVerticesPointer = 0x4FF94;
        public static int triforceFacesPointer = 0x4FF96;
        public static int triforceMaxSize = 0x2E;

        // ===========================================================================================
        // Title screen GFX group set
        // ===========================================================================================
        public static int titleScreenTilesGFX = 0x64207; // 1 Byte
        public static int titleScreenSpritesGFX = 0x6420C; // 1 Byte
        public static int titleScreenExtraTilesGFX = 0x64211; // 1 Byte
        public static int titleScreenExtraSpritesGFX = 0x64216; // 1 Byte

        // ===========================================================================================
        // Custom Collision
        // ===========================================================================================
        public static int customCollisionRoomPointers = 0x128090; // Array 3 bytes per room
        public static int customCollisionDataPosition = 0x128450; // A bunch of FFFF ended arrays

        // ===========================================================================================
        // End Main Addresses
        // ===========================================================================================

        public static bool Rando = false; // Is it a rando rom?

        public static void Init_Jp(bool rando = false)
        {
            pit_pointer = 0x394A2;
            pit_count = 0x3949D;
            // 04EF2F
            dungeons_palettes_groups = 0x67DD0;
            room_items_pointers = 0xDB67;
            torch_data = 0x2704A;

            entrance_gfx_group = 0x5DD7;
            sprite_blockset_pointer = 0x5B97;
            blocks_pointer1 = 0x1585E;
            blocks_pointer2 = 0x15865;
            blocks_pointer3 = 0x1586C;
            blocks_pointer4 = 0x15873;
            chests_length_pointer = 0xEBF4;
            chests_data_pointer1 = 0xEBF9;
            gfx_groups_pointer = 0x6277;
            items_data_start = 0xDDE7;
            items_data_end = 0xE6B0;
            gfx_1_pointer = 0x67D0; // 2byte pointer bank 00 -> pc 0x4FC0
            gfx_2_pointer = 0x67D5; // 509F
            gfx_3_pointer = 0x67DA; // 517E
            messages_id_dungeon = 0x3F5F7;
            gfx_animated_pointer = 0x10624;
            initial_equipement = 0x183000;

            // Entrances
            entrance_room = 0x14577; // Word value for each room
            entrance_scrolledge = 0x1491D; // 0x14681 / /8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
            entrance_camerax = 0x14AA9; // 2bytes each room
            entrance_cameray = 0x14BB3; // 2bytes
            entrance_yposition = 0x14CBD; // 2bytes
            entrance_xposition = 0x14DC7; // 2bytes
            entrance_cameraytrigger = 0x14ED1; // 2bytes
            entrance_cameraxtrigger = 0x14FDB; // 2bytes
            entrance_blockset = 0x150E5; // 1byte
            entrance_floor = 0x1516A; // 1byte
            entrance_dungeon = 0x151EF; // 1byte (dungeon id)
            entrance_door = 0x15274; // 1byte
            entrance_ladderbg = 0x152F9; //1 byte, ---b ---a b = bg2, a = need to check -_-
            entrance_scrolling = 0x1537E; //1byte --h- --v-
            entrance_scrollquadrant = 0x15403; // 1byte
            entrance_exit = 0x15488; // 2byte word
            entrance_music = 0x15592;

            startingentrance_room -= 0x29C; // 0x158D2 // word value for each room
            startingentrance_scrolledge -= 0x29C; // 0x158E0 //8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
            startingentrance_cameray -= 0x29C; // 0x14AA9 // 2bytes each room
            startingentrance_camerax -= 0x29C; // 0x14BB3 // 2bytes
            startingentrance_yposition -= 0x29C; // 0x14CBD 2bytes
            startingentrance_xposition -= 0x29C; // 0x14DC7 2bytes
            startingentrance_cameraytrigger -= 0x29C; // 0x14ED1 2bytes
            startingentrance_cameraxtrigger -= 0x29C; // 0x14FDB 2bytes

            startingentrance_blockset -= 0x29C; // 0x150E5 1byte
            startingentrance_floor -= 0x29C; // 0x1516A 1byte
            startingentrance_dungeon -= 0x29C; // 0x151EF 1byte (dungeon id)

            startingentrance_door -= 0x29C; // 0x15274 1byte

            startingentrance_ladderbg -= 0x29C; // 0x152F9 //1 byte, ---b ---a b = bg2, a = need to check -_-
            startingentrance_scrolling -= 0x29C; // 0x1537E //1byte --h- --v-
            startingentrance_scrollquadrant -= 0x29C; // 0x15403 1byte
            startingentrance_exit -= 0x29C; // 0x15488 // 2byte word
            startingentrance_music -= 0x29C; // 0x15592
            startingentrance_entrance -= 0x29C;

            // us = 0x05D97 / jp = 0x05DD7
            overworldgfxGroups = 0x05DD7;
            hardcodedGrassLW1 = 0x67FE6;
            hardcodedGrassDW1 = 0x67FF0; // map>40
            hardcodedGrassSpecial = 0x67FE1; // map 183,182,180

            OWExitRoomId = 0x15D8A - 0x29C;
            OWExitMapId = 0x15E28 - 0x29C;
            OWExitVram = 0x15E77 - 0x29C;
            OWExitYScroll = 0x15F15 - 0x29C;
            OWExitXScroll = 0x15FB3 - 0x29C;
            OWExitYPlayer = 0x16051 - 0x29C;
            OWExitXPlayer = 0x160EF - 0x29C;
            OWExitYCamera = 0x1618D - 0x29C;
            OWExitXCamera = 0x1622B - 0x29C;
            OWExitUnk1 = 0x162C9 - 0x29C;
            OWExitUnk2 = 0x16318 - 0x29C;
            OWExitDoorType1 = 0x16367 - 0x29C;
            OWExitDoorType2 = 0x16405 - 0x29C;

            overworldgfxGroups2 = 0x60B3;

            /*
            public static int map32TilesTL = 0x18000;
            public static int map32TilesTR = 0x1B400;
            public static int map32TilesBL = 0x20000;
            public static int map32TilesBR = 0x23400;
            */

            map32TilesTL = 0x18000;
            map32TilesTR = 0x1B3C0;
            map32TilesBL = 0x20000;
            map32TilesBR = 0x233C0;
            compressedAllMap32PointersHigh = 0x176B1; // LONGPointers all tiles of maps[High] (mapid* 3)
            compressedAllMap32PointersLow = 0x17891; // LONGPointers all tiles of maps[Low] (mapid* 3)
            overworldMapPalette = 0x7D1C; // JP
            overworldMapPaletteGroup = 0x67E74;
            overworldMapSize = 0x1273B; // JP
            overlayPointers = 0x3FAF4;
            overlayPointersBank = 0x07;
            overworldTilesType = 0x7FD94;
            Rando = rando;

            if (rando)
            {
                // TODO: Add condition here?
            }
        }

        // ===========================================================================================
        // Things
        // ===========================================================================================

        public class FloorNumber
        {
            private readonly string nom; public string Name { get => nom; }
            private readonly byte val; public byte ByteValue { get => val; }

            public FloorNumber(string n, byte v)
            {
                nom = n;
                val = v;
            }

            public override string ToString()
            {
                return nom;
            }

            public static int FindFloorIndex(byte b)
            {
                for (int i = 0; i < floors.Length; i++)
                {
                    if (b == floors[i].ByteValue)
                    {
                        return i;
                    }
                }
                return -1;
            }
        }

        public static FloorNumber[] floors = new FloorNumber[] {
            new FloorNumber("B8", 0xF8),
            new FloorNumber("B7", 0xF9),
            new FloorNumber("B6", 0xFA),
            new FloorNumber("B5", 0xFB),
            new FloorNumber("B4", 0xFC),
            new FloorNumber("B3", 0xFD),
            new FloorNumber("B2", 0xFE),
            new FloorNumber("B1", 0xFF),
            new FloorNumber("1F", 0x00),
            new FloorNumber("2F", 0x01),
            new FloorNumber("3F", 0x02),
            new FloorNumber("4F", 0x03),
            new FloorNumber("5F", 0x04),
            new FloorNumber("6F", 0x05),
            new FloorNumber("7F", 0x06),
            new FloorNumber("8F", 0x07)
        };

        // ===========================================================================================
        // Names
        // TODO moved to DefaultEntities.cs once we start working on projects
        // ===========================================================================================
        public static string[] RoomEffects = new string[]
        {
            "Nothing",
            "Nothing",
            "Moving Floor",
            "Moving Water",
            "Trinexx Shell",
            "Red Flashes",
            "Light Torch to See Floor",
            "Ganon's Darkness"
        };

        public static string[] RoomTags = new string[]
        {
            "Nothing",

            "NW Kill Enemy to Open",
            "NE Kill Enemy to Open",
            "SW Kill Enemy to Open",
            "SE Kill Enemy to Open",
            "W Kill Enemy to Open",
            "E Kill Enemy to Open",
            "N Kill Enemy to Open",
            "S Kill Enemy to Open",
            "Clear Quadrant to Open",
            "Clear Full Tile to Open",

            "NW Push Block to Open",
            "NE Push Block to Open",
            "SW Push Block to Open",
            "SE Push Block to Open",
            "W Push Block to Open",
            "E Push Block to Open",
            "N Push Block to Open",
            "S Push Block to Open",
            "Push Block to Open",
            "Pull Lever to Open",
            "Collect Prize to Open",

            "Hold Switch Open Door",
            "Toggle Switch to Open Door",
            "Turn off Water",
            "Turn on Water",
            "Water Gate",
            "Water Twin",
            "Moving Wall Right",
            "Moving Wall Left",
            "Crash",
            "Crash",
            "Push Switch Exploding Wall",
            "Holes 0",
            "Open Chest (Holes 0)",
            "Holes 1",
            "Holes 2",
            "Defeat Boss for Dungeon Prize",

            "SE Kill Enemy to Push Block",
            "Trigger Switch Chest",
            "Pull Lever Exploding Wall",
            "NW Kill Enemy for Chest",
            "NE Kill Enemy for Chest",
            "SW Kill Enemy for Chest",
            "SE Kill Enemy for Chest",
            "W Kill Enemy for Chest",
            "E Kill Enemy for Chest",
            "N Kill Enemy for Chest",
            "S Kill Enemy for Chest",
            "Clear Quadrant for Chest",
            "Clear Full Tile for Chest",

            "Light Torches to Open",
            "Holes 3",
            "Holes 4",
            "Holes 5",
            "Holes 6",
            "Agahnim Room",
            "Holes 7",
            "Holes 8",
            "Open Chest for Holes 8",
            "Push Block for Chest",
            "Clear Room for Triforce Door",
            "Light Torches for Chest",
            "Kill Boss Again"
        };

        public static string[] SecretItemNames = new string[]
        {
            "Nothing",
            "Green Rupee",
            "Rock hoarder",
            "Bee",
            "Health pack",
            "Bomb",
            "Heart ",
            "Blue Rupee",

            "Key",
            "Arrow",
            "Bomb",
            "Heart",
            "Magic",
            "Full Magic",
            "Cucco",
            "Green Soldier",
            "Bush Stal",
            "Blue Soldier",

            "Landmine",
            "Heart",
            "Fairy",
            "Heart",
            "Nothing ", // 22

            "Hole",
            "Warp",
            "Staircase",
            "Bombable",
            "Switch"
           };

        public static string[] Type1RoomObjectNames = new string[]
        {
             "Ceiling ↔",
             "Wall (top, north) ↔",
             "Wall (top, south) ↔",
             "Wall (bottom, north) ↔",
             "Wall (bottom, south) ↔",
             "Wall columns (north) ↔",
             "Wall columns (south) ↔",
             "Deep wall (north) ↔",
             "Deep wall (south) ↔",
             "Diagonal wall A ◤ (top) ↔",
             "Diagonal wall A ◣ (top) ↔",
             "Diagonal wall A ◥ (top) ↔",
             "Diagonal wall A ◢ (top) ↔",
             "Diagonal wall B ◤ (top) ↔",
             "Diagonal wall B ◣ (top) ↔",
             "Diagonal wall B ◥ (top) ↔",
             "Diagonal wall B ◢ (top) ↔",
             "Diagonal wall C ◤ (top) ↔",
             "Diagonal wall C ◣ (top) ↔",
             "Diagonal wall C ◥ (top) ↔",
             "Diagonal wall C ◢ (top) ↔",
             "Diagonal wall A ◤ (bottom) ↔",
             "Diagonal wall A ◣ (bottom) ↔",
             "Diagonal wall A ◥ (bottom) ↔",
             "Diagonal wall A ◢ (bottom) ↔",
             "Diagonal wall B ◤ (bottom) ↔",
             "Diagonal wall B ◣ (bottom) ↔",
             "Diagonal wall B ◥ (bottom) ↔",
             "Diagonal wall B ◢ (bottom) ↔",
             "Diagonal wall C ◤ (bottom) ↔",
             "Diagonal wall C ◣ (bottom) ↔",
             "Diagonal wall C ◥ (bottom) ↔",
             "Diagonal wall C ◢ (bottom) ↔",
             "Platform stairs ↔",
             "Rail ↔",
             "Pit edge ┏━┓ A (north) ↔",
             "Pit edge ┏━┓ B (north) ↔",
             "Pit edge ┏━┓ C (north) ↔",
             "Pit edge ┏━┓ D (north) ↔",
             "Pit edge ┏━┓ E (north) ↔",
             "Pit edge ┗━┛ (south) ↔",
             "Pit edge ━━━ (south) ↔",
             "Pit edge ━━━ (north) ↔",
             "Pit edge ━━┛ (south) ↔",
             "Pit edge ┗━━ (south) ↔",
             "Pit edge ━━┓ (north) ↔",
             "Pit edge ┏━━ (north) ↔",
             "Rail wall (north) ↔",
             "Rail wall (south) ↔",
             "Nothing",
             "Nothing",
             "Carpet ↔",
             "Carpet trim ↔",
             "Weird door", // TODO: WEIRD DOOR OBJECT NEEDS INVESTIGATION
             "Drapes (north) ↔",
             "Drapes (west, odd) ↔",
             "Statues ↔",
             "Columns ↔",
             "Wall decors (north) ↔",
             "Wall decors (south) ↔",
             "Chairs in pairs ↔",
             "Tall torches ↔",
             "Supports (north) ↔",
             "Water edge ┏━┓ (concave) ↔",
             "Water edge ┗━┛ (concave) ↔",
             "Water edge ┏━┓ (convex) ↔",
             "Water edge ┗━┛ (convex) ↔",
             "Water edge ┏━┛ (concave) ↔",
             "Water edge ┗━┓ (concave) ↔",
             "Water edge ┗━┓ (convex) ↔",
             "Water edge ┏━┛ (convex) ↔",
             "Unknown", // TODO: NEEDS IN GAME CHECKING
             "Unknown", // TODO: NEEDS IN GAME CHECKING
             "Unknown", // TODO: NEEDS IN GAME CHECKING
             "Unknown", // TODO: NEEDS IN GAME CHECKING
             "Supports (south) ↔",
             "Bar ↔",
             "Shelf A ↔",
             "Shelf B ↔",
             "Shelf C ↔",
             "Somaria path ↔",
             "Cannon hole A (north) ↔",
             "Cannon hole A (south) ↔",
             "Pipe path ↔",
             "Nothing",
             "Wall torches (north) ↔",
             "Wall torches (south) ↔",
             "Nothing",
             "Nothing",
             "Nothing",
             "Nothing",
             "Cannon hole B (north) ↔",
             "Cannon hole B (south) ↔",
             "Thick rail ↔",
             "Blocks ↔",
             "Long rail ↔",
             "Ceiling ↕",
             "Wall (top, west) ↕",
             "Wall (top, east) ↕",
             "Wall (bottom, west) ↕",
             "Wall (bottom, east) ↕",
             "Wall columns (west) ↕",
             "Wall columns (east) ↕",
             "Deep wall (west) ↕",
             "Deep wall (east) ↕",
             "Rail ↕",
             "Pit edge (west) ↕",
             "Pit edge (east) ↕",
             "Rail wall (west) ↕",
             "Rail wall (east) ↕",
             "Nothing",
             "Nothing",
             "Carpet ↕",
             "Carpet trim ↕",
             "Nothing",
             "Drapes (west) ↕",
             "Drapes (east) ↕",
             "Columns ↕",
             "Wall decors (west) ↕",
             "Wall decors (east) ↕",
             "Supports (west) ↕",
             "Water edge (west) ↕",
             "Water edge (east) ↕",
             "Supports (east) ↕",
             "Somaria path ↕",
             "Pipe path ↕",
             "Nothing",
             "Wall torches (west) ↕",
             "Wall torches (east) ↕",
             "Wall decors tight A (west) ↕",
             "Wall decors tight A (east) ↕",
             "Wall decors tight B (west) ↕",
             "Wall decors tight B (east) ↕",
             "Cannon hole (west) ↕",
             "Cannon hole (east) ↕",
             "Tall torches ↕",
             "Thick rail ↕",
             "Blocks ↕",
             "Long rail ↕",
             "Jump ledge (west) ↕",
             "Jump ledge (east) ↕",
             "Rug trim (west) ↕",
             "Rug trim (east) ↕",
             "Bar ↕",
             "Wall flair (west) ↕",
             "Wall flair (east) ↕",
             "Blue pegs ↕",
             "Orange pegs ↕",
             "Invisible floor ↕",
             "Fake pots ↕",
             "Hammer pegs ↕",
             "Nothing",
             "Nothing",
             "Nothing",
             "Nothing",
             "Nothing",
             "Nothing",
             "Nothing",
             "Nothing",
             "Nothing",
             "Diagonal ceiling A ◤",
             "Diagonal ceiling A ◣",
             "Diagonal ceiling A ◥",
             "Diagonal ceiling A ◢",
             "Pit ⇲",
             "Diagonal layer 2 mask A ◤",
             "Diagonal layer 2 mask A ◣",
             "Diagonal layer 2 mask A ◥",
             "Diagonal layer 2 mask A ◢",
             "Diagonal layer 2 mask B ◤", // TODO: VERIFY
             "Diagonal layer 2 mask B ◣", // TODO: VERIFY
             "Diagonal layer 2 mask B ◥", // TODO: VERIFY
             "Diagonal layer 2 mask B ◢", // TODO: VERIFY
             "Nothing",
             "Nothing",
             "Nothing",
             "Jump ledge (north) ↔",
             "Jump ledge (south) ↔",
             "Rug ↔",
             "Rug trim (north) ↔",
             "Rug trim (south) ↔",
             "Archery game curtains ↔",
             "Wall flair (north) ↔",
             "Wall flair (south) ↔",
             "Blue pegs ↔",
             "Orange pegs ↔",
             "Invisible floor ↔",
             "Fake pressure plates ↔",
             "Fake pots ↔",
             "Hammer pegs ↔",
             "Nothing",
             "Nothing",
             "Ceiling (large) ⇲",
             "Chest platform (tall) ⇲",
             "Layer 2 pit mask (large) ⇲",
             "Layer 2 pit mask (medium) ⇲",
             "Floor 1 ⇲",
             "Floor 3 ⇲",
             "Layer 2 mask (large) ⇲",
             "Floor 4 ⇲",
             "Water floor ⇲ ",
             "Flood water (medium) ⇲ ",
             "Conveyor floor ⇲ ",
             "Nothing",
             "Nothing",
             "Moving wall (west) ⇲",
             "Moving wall (east) ⇲",
             "Nothing",
             "Nothing",
             "Icy floor A ⇲",
             "Icy floor B ⇲",
             "Moving wall flag", // TODO: WTF IS THIS?
             "Moving wall flag", // TODO: WTF IS THIS?
             "Moving wall flag", // TODO: WTF IS THIS?
             "Moving wall flag", // TODO: WTF IS THIS?
             "Layer 2 mask (medium) ⇲",
             "Flood water (large) ⇲",
             "Layer 2 swim mask ⇲",
             "Flood water B (large) ⇲",
             "Floor 2 ⇲",
             "Chest platform (short) ⇲",
             "Table / rock ⇲",
             "Spike blocks ⇲",
             "Spiked floor ⇲",
             "Floor 7 ⇲",
             "Tiled floor ⇲",
             "Rupee floor ⇲",
             "Conveyor upwards ⇲",
             "Conveyor downwards ⇲",
             "Conveyor leftwards ⇲",
             "Conveyor rightwards ⇲",
             "Heavy current water ⇲",
             "Floor 10 ⇲",
             "Nothing",
             "Nothing",
             "Nothing",
             "Nothing",
             "Nothing",
             "Nothing",
             "Nothing",
             "Nothing",
             "Nothing",
             "Nothing",
             "Nothing",
             "Nothing",
             "Nothing",
             "Nothing",
             "Nothing",
        };

        public static string[] Type2RoomObjectNames = new string[]
        {
            "Corner (top, concave) ▛",
            "Corner (top, concave) ▙",
            "Corner (top, concave) ▜",
            "Corner (top, concave) ▟",
            "Corner (top, convex) ▟",
            "Corner (top, convex) ▜",
            "Corner (top, convex) ▙",
            "Corner (top, convex) ▛",
            "Corner (bottom, concave) ▛",
            "Corner (bottom, concave) ▙",
            "Corner (bottom, concave) ▜",
            "Corner (bottom, concave) ▟",
            "Corner (bottom, convex) ▟",
            "Corner (bottom, convex) ▜",
            "Corner (bottom, convex) ▙",
            "Corner (bottom, convex) ▛",
            "Kinked corner north (bottom) ▜",
            "Kinked corner south (bottom) ▟",
            "Kinked corner north (bottom) ▛",
            "Kinked corner south (bottom) ▙",
            "Kinked corner west (bottom) ▙",
            "Kinked corner west (bottom) ▛",
            "Kinked corner east (bottom) ▟",
            "Kinked corner east (bottom) ▜",
            "Deep corner (concave) ▛",
            "Deep corner (concave) ▙",
            "Deep corner (concave) ▜",
            "Deep corner (concave) ▟",
            "Large brazier",
            "Statue",
            "Star tile (disabled)",
            "Star tile (enabled)",
            "Small torch (lit)",
            "Barrel",
            "Unknown", // TODO: NEEDS IN GAME CHECKING
            "Table",
            "Fairy statue",
            "Unknown", // TODO: NEEDS IN GAME CHECKING
            "Unknown", // TODO: NEEDS IN GAME CHECKING
            "Chair",
            "Bed",
            "Fireplace",
            "Mario portrait",
            "Unknown", // TODO: NEEDS IN GAME CHECKING
            "Unknown", // TODO: NEEDS IN GAME CHECKING
            "Interroom stairs (up)",
            "Interroom stairs (down)",
            "Interroom stairs B (down)",
            "Intraroom stairs north B", // TODO: VERIFY LAYER HANDLING
            "Intraroom stairs north (separate layers)",
            "Intraroom stairs north (merged layers)",
            "Intraroom stairs north (swim layer)",
            "Block",
            "Water ladder (north)",
            "Water ladder (south)", // TODO: NEEDS IN GAME VERIFICATION
            "Dam floodgate",
            "Interroom spiral stairs up (top)",
            "Interroom spiral stairs down (top)",
            "Interroom spiral stairs up (bottom)",
            "Interroom spiral stairs down (bottom)",
            "Sanctuary wall (north)",
            "Unknown", // TODO: NEEDS IN GAME CHECKING
            "Pew",
            "Magic bat altar",
        };

        public static string[] Type3RoomObjectNames = new string[]
        {
            "Waterfall face (empty)",
            "Waterfall face (short)",
            "Waterfall face (long)",
            "Somaria path endpoint",
            "Somaria path intersection ╋",
            "Somaria path corner ┏",
            "Somaria path corner ┗",
            "Somaria path corner ┓",
            "Somaria path corner ┛",
            "Somaria path intersection ┳",
            "Somaria path intersection ┻",
            "Somaria path intersection ┣",
            "Somaria path intersection ┫",
            "Unknown", // TODO: NEEDS IN GAME CHECKING
            "Somaria path 2-way endpoint",
            "Somaria path crossover",
            "Babasu hole (north)",
            "Babasu hole (south)",
            "9 blue rupees",
            "Telepathy tile",
            "Warp door", // TODO: NEEDS IN GAME VERIFICATION THAT THIS IS USELESS
            "Kholdstare's shell",
            "Hammer peg",
            "Prison cell",
            "Big key lock",
            "Chest",
            "Chest (open)",
            "Intraroom stairs south", // TODO: VERIFY LAYER HANDLING
            "Intraroom stairs south (separate layers)",
            "Intraroom stairs south (merged layers)",
            "Interroom straight stairs up (north, top)",
            "Interroom straight stairs down (north, top)",
            "Interroom straight stairs up (south, top)",
            "Interroom straight stairs down (south, top)",
            "Deep corner (convex) ▟",
            "Deep corner (convex) ▜",
            "Deep corner (convex) ▙",
            "Deep corner (convex) ▛",
            "Interroom straight stairs up (north, bottom)",
            "Interroom straight stairs down (north, bottom)",
            "Interroom straight stairs up (south, bottom)",
            "Interroom straight stairs down (south, bottom)",
            "Lamp cones",
            "Unknown", // TODO: NEEDS IN GAME CHECKING
            "Liftable large block",
            "Agahnim's altar",
            "Agahnim's boss room",
            "Pot",
            "Unknown", // TODO: NEEDS IN GAME CHECKING
            "Big chest",
            "Big chest (open)",
            "Intraroom stairs south (swim layer)",
            "Unknown", // TODO: NEEDS IN GAME CHECKING
            "Unknown", // TODO: NEEDS IN GAME CHECKING
            "Unknown", // TODO: NEEDS IN GAME CHECKING
            "Unknown", // TODO: NEEDS IN GAME CHECKING
            "Unknown", // TODO: NEEDS IN GAME CHECKING
            "Unknown", // TODO: NEEDS IN GAME CHECKING
            "Pipe end (south)",
            "Pipe end (north)",
            "Pipe end (east)",
            "Pipe end (west)",
            "Pipe corner ▛",
            "Pipe corner ▙",
            "Pipe corner ▜",
            "Pipe corner ▟",
            "Pipe-rock intersection ⯊",
            "Pipe-rock intersection ⯋",
            "Pipe-rock intersection ◖",
            "Pipe-rock intersection ◗",
            "Pipe crossover",
            "Bombable floor",
            "Fake bombable floor",
            "Unknown", // TODO: NEEDS IN GAME CHECKING
            "Warp tile",
            "Tool rack",
            "Furnace",
            "Tub (wide)",
            "Anvil",
            "Warp tile (disabled)",
            "Pressure plate",
            "Unknown", // TODO: NEEDS IN GAME CHECKING
            "Blue peg",
            "Orange peg",
            "Fortune teller room",
            "Unknown", // TODO: NEEDS IN GAME CHECKING
            "Bar corner ▛",
            "Bar corner ▙",
            "Bar corner ▜",
            "Bar corner ▟",
            "Decorative bowl",
            "Tub (tall)",
            "Bookcase",
            "Range",
            "Suitcase",
            "Bar bottles",
            "Arrow game hole (west)",
            "Arrow game hole (east)",
            "Vitreous goo graphics",
            "Fake pressure plate",
            "Medusa head",
            "4-way shooter block",
            "Pit",
            "Wall crack (north)",
            "Wall crack (south)",
            "Wall crack (west)",
            "Wall crack (east)",
            "Large decor",
            "Water grate (north)",
            "Water grate (south)",
            "Water grate (west)",
            "Water grate (east)",
            "Window sunlight",
            "Floor sunlight",
            "Trinexx's shell",
            "Layer 2 mask (full)",
            "Boss entrance",
            "Minigame chest",
            "Ganon door",
            "Triforce wall ornament",
            "Triforce floor tiles",
            "Freezor hole",
            "Pile of bones",
            "Vitreous goo damage",
            "Arrow tile ↑",
            "Arrow tile ↓",
            "Arrow tile →",
            "Nothing",
        };

        public static string[] TileTypeNames = new string[]
        {
            "Nothing (standard floor)",
            "Collision",
            "Collision",
            "Collision",
            "Collision",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Deep water",
            "Shallow water",
            "Unknown? Possibly unused",
            "Collision (different in Overworld and unknown)",
            "Overlay mask",
            "Spike floor",
            "GT ice",
            "Ice palace ice",
            "Slope ◤",
            "Slope ◥",
            "Slope ◣",
            "Slope ◢",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Slope ◤",
            "Slope ◥",
            "Slope ◣",
            "Slope ◢",
            "Layer 2 overlay",
            "North single-layer auto stairs",
            "North layer-swap auto stairs",
            "North layer-swap auto stairs",
            "Pit",
            "Nothing (unused?)",
            "Manual stairs",
            "Pot switch",
            "Pressure switch",
            "Nothing (unused but referenced by somaria blocks)",
            "Collision (near stairs?)",
            "Brazier/Fence/Statue/Block/General hookable things",
            "North ledge",
            "South ledge",
            "East ledge",
            "West ledge",
            "◤ ledge",
            "◣ ledge",
            "◥ ledge",
            "◢ ledge",
            "Straight inter-room stairs south/up 0",
            "Straight inter-room stairs south/up 1",
            "Straight inter-room stairs south/up 2",
            "Straight inter-room stairs south/up 3",
            "Straight inter-room stairs north/down 0",
            "Straight inter-room stairs north/down 1",
            "Straight inter-room stairs north/down 2",
            "Straight inter-room stairs north/down 3",
            "Straight inter-room stairs north/down edge",
            "Straight inter-room stairs south/up edge",
            "Star tile (inactive on load)",
            "Star tile (active on load)",
            "Nothing (unused?)",
            "South single-layer auto stairs",
            "South layer-swap auto stairs",
            "South layer-swap auto stairs",
            "Thick grass",
            "Nothing (unused?)",
            "Gravestone / Tower of hera ledge shadows??",
            "Skull Woods entrance/Hera columns???",
            "Spike",
            "Nothing (unused?)",
            "Desert Tablet",
            "Nothing (unused?)",
            "Diggable ground",
            "Nothing (unused?)",
            "Diggable ground",
            "Warp tile",
            "Nothing (unused?) | Something unknown in overworld",
            "Nothing (unused?) | Something unknown in overworld",
            "Square corners in EP overworld",
            "Square corners in EP overworld",
            "Green bush",
            "Dark bush",
            "Gray rock",
            "Black rock",
            "Hint tile/Sign",
            "Big gray rock",
            "Big black rock",
            "Bonk rocks",
            "Chest 0",
            "Chest 1",
            "Chest 2",
            "Chest 3",
            "Chest 4",
            "Chest 5",
            "Spiral stairs",
            "Spiral stairs",
            "Rupee tile",
            "Nothing (unused?)",
            "Bombable floor",
            "Minigame chest",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Crystal peg down",
            "Crystal peg up",
            "Upwards conveyor",
            "Downwards conveyor",
            "Leftwards conveyor",
            "Rightwards conveyor",
            "North vines",
            "South vines",
            "West vines",
            "East vines",
            "Pot/Hammer peg/Push block 00",
            "Pot/Hammer peg/Push block 01",
            "Pot/Hammer peg/Push block 02",
            "Pot/Hammer peg/Push block 03",
            "Pot/Hammer peg/Push block 04",
            "Pot/Hammer peg/Push block 05",
            "Pot/Hammer peg/Push block 06",
            "Pot/Hammer peg/Push block 07",
            "Pot/Hammer peg/Push block 08",
            "Pot/Hammer peg/Push block 09",
            "Pot/Hammer peg/Push block 0A",
            "Pot/Hammer peg/Push block 0B",
            "Pot/Hammer peg/Push block 0C",
            "Pot/Hammer peg/Push block 0D",
            "Pot/Hammer peg/Push block 0E",
            "Pot/Hammer peg/Push block 0F",
            "North/South door",
            "East/West door",
            "North/South shutter door",
            "East/West shutter door",
            "North/South layer 2 door",
            "East/West layer 2 door",
            "North/South layer 2 shutter door",
            "East/West layer 2 shutter door",
            "Some type of door (?)",
            "East/West transport door",
            "Some type of door (?)",
            "Some type of door (?)",
            "Some type of door (?)",
            "Some type of door (?)",
            "Entrance door",
            "Entrance door",
            "Layer toggle shutter door (?)",
            "Layer toggle shutter door (?)",
            "Layer toggle shutter door (?)",
            "Layer toggle shutter door (?)",
            "Layer toggle shutter door (?)",
            "Layer toggle shutter door (?)",
            "Layer toggle shutter door (?)",
            "Layer toggle shutter door (?)",
            "Layer+Dungeon toggle shutter door (?)",
            "Layer+Dungeon toggle shutter door (?)",
            "Layer+Dungeon toggle shutter door (?)",
            "Layer+Dungeon toggle shutter door (?)",
            "Layer+Dungeon toggle shutter door (?)",
            "Layer+Dungeon toggle shutter door (?)",
            "Layer+Dungeon toggle shutter door (?)",
            "Layer+Dungeon toggle shutter door (?)",
            "North/South Dungeon swap door",
            "Dungeon toggle door (?)",
            "Dungeon toggle door (?)",
            "Dungeon toggle door (?)",
            "Dungeon toggle door (?)",
            "Dungeon toggle door (?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Layer+Dungeon toggle shutter door (?)",
            "Layer+Dungeon toggle shutter door (?)",
            "Layer+Dungeon toggle shutter door (?)",
            "Layer+Dungeon toggle shutter door (?)",
            "Layer+Dungeon toggle shutter door (?)",
            "Layer+Dungeon toggle shutter door (?)",
            "Layer+Dungeon toggle shutter door (?)",
            "Layer+Dungeon toggle shutter door (?)",
            "Somaria ─",
            "Somaria │",
            "Somaria ┌",
            "Somaria └",
            "Somaria ┐",
            "Somaria ┘",
            "Somaria ⍰ 1 way",
            "Somaria ┬",
            "Somaria ┴",
            "Somaria ├",
            "Somaria ┤",
            "Somaria ┼",
            "Somaria ⍰ 2 way",
            "Somaria ┼ crossover",
            "Pipe entrance",
            "Nothing (unused?)",
            "Torch 00",
            "Torch 01",
            "Torch 02",
            "Torch 03",
            "Torch 04",
            "Torch 05",
            "Torch 06",
            "Torch 07",
            "Torch 08",
            "Torch 09",
            "Torch 0A",
            "Torch 0B",
            "Torch 0C",
            "Torch 0D",
            "Torch 0E",
            "Torch 0F",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Nothing (unused?)",
            "Door 0 bottom",
            "Door 1 bottom",
            "Door 2 bottom",
            "Door 3 bottom",
            "Door X bottom? (unused?)",
            "Door X bottom? (unused?)",
            "Door X bottom? (unused?)",
            "Door X bottom? (unused?)",
            "Door 0 top",
            "Door 1 top",
            "Door 2 top",
            "Door 3 top",
            "Door X top? (unused?)",
            "Door X top? (unused?)",
            "Door X top? (unused?)",
            "Door X top? (unused?)"
        };
    }
}
