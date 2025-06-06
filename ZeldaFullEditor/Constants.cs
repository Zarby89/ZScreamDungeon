using System.Drawing;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
    /// <summary>
    ///     This is a class to hold all addresses, "magic numbers", and other constants used accross the editor.
    /// </summary>
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

        public const int NumberOfOWMaps = 0xA0;
        public const int Map32PerScreen = 256;
        public const int NumberOfMap16 = 3752; // 4096
        public const int NumberOfMap16Ex = 4096; // 4096
        public const int NumberOfMap32 = Map32PerScreen * NumberOfOWMaps;
        public const int NumberOfOWSprites = 352;
        public const int NumberOfColors = 3415; // 3143
        public const int Tile16EdiorBitmapSize = 0x2000;
        public const int Tile16EdiorBitmapSizex2 = Tile16EdiorBitmapSize * 2;

        // TODO zarby stop making magic numbers
        public const int IDKZarby = 0x054727;

        public static byte[] FontSpacings = new byte[]
        {
            4, 3, 5, 7, 5, 6, 5, 3,
            4, 4, 5, 5, 3, 5, 3, 5,
            5, 5, 5, 5, 5, 5, 5, 5,
            5, 5, 3, 3, 5, 5, 5, 5,
            5, 5, 5, 5, 5, 5, 5, 6,
            5, 5, 6, 5, 5, 7, 6, 5,
            5, 5, 5, 5, 5, 5, 5, 7,
            5, 5, 5, 4, 5, 4, 6, 6,
            6, 6,
        };

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

        public static readonly Pen CameraPen = new Pen(Color.Red, 2);

        public static readonly Color DefaultLWBGColor = Color.FromArgb(0xFF, 0x48, 0x98, 0x48);
        public static readonly Color DefaultDWBGColor = Color.FromArgb(0xFF, 0x90, 0x88, 0x50);
        public static readonly Color DefaultSWBGColor = Color.FromArgb(0xFF, 0x30, 0x70, 0x30);
        public static readonly Color TransparentColor = Color.FromArgb(0x00, 0x00, 0x00, 0x00);
        public static readonly Color BlackColor = Color.FromArgb(0xFF, 0x00, 0x00, 0x00);
        public static readonly Color DefaultCloudBGColor = Color.FromArgb(0xFF, 0x3B, 0x73, 0x73);

        // ===========================================================================================
        // GFX Related Variables
        // ===========================================================================================
        public static int tile_address = 0x001B52; // JP = Same //i don't think that need a pointer
        public static int tile_address_floor = 0x001B5A; // JP = Same //i don't think that need a pointer
        public static int subtype1_tiles = 0x008000; // JP = Same //i don't think that need a pointer
        public static int subtype2_tiles = 0x0083F0; // JP = Same //i don't think that need a pointer
        public static int subtype3_tiles = 0x0084F0; // JP = Same //i don't think that need a pointer
        public static int gfx_animated_pointer = 0x010275; // JP 0x10624 //long pointer
        public static int overworldgfxGroups = 0x005D97;
        public static int overworldgfxGroups2 = 0x006073; // 0x60B3
        public static int gfx_1_pointer = 0x006790; // 2byte pointer bank 00 pc -> 0x4320  CF80  ; 004F80
        public static int gfx_2_pointer = 0x006795; // D05F ; 00505F
        public static int gfx_3_pointer = 0x00679A; // D13E ; 00513E
        public static int hud_palettes = 0x0DD660;
        public static int maxGfx = 0x0C3FFF;

        // ===========================================================================================
        // Overworld Related Variables
        // ===========================================================================================
        public static int compressedAllMap32PointersHigh = 0x01794D;
        public static int compressedAllMap32PointersLow = 0x017B2D;
        public static int map16Tiles = 0x078000;
        public static int map16TilesEx = 0x1E8000;
        public static int map16TilesBank = 0x017D28;

        public static int map32TilesTL = 0x018000;
        public static int map32TilesTR = 0x01B400;
        public static int map32TilesBL = 0x020000;
        public static int map32TilesBR = 0x023400;

        public static int map32TilesTREx = 0x020000;
        public static int map32TilesBLEx = 0x1F0000;
        public static int map32TilesBREx = 0x1F8000;

        public static int Map32TilesCount = 0x0033F0;
        public static int Map32TilesCountEx = 0x0067E0;
        public static int Map32Tiles_BottomLeft_0 = 0x01772E;

        public static int overworldPalGroup1 = 0x0DE6C8;
        public static int overworldPalGroup2 = 0x0DE86C;
        public static int overworldPalGroup3 = 0x0DE604;
        public static int overworldMapPalette = 0x007D1C;
        public static int overworldSpritePalette = 0x007B41;
        public static int overworldMapPaletteGroup = 0x075504;
        public static int overworldSpritePaletteGroup = 0x075580;
        public static int overworldSpriteset = 0x007A41;
        public static int overworldSpecialGFXGroup = 0x016821;
        public static int overworldSpecialPALGroup = 0x016831;

        public static int HudPalettesMax = 2;
        public static int OverworldMainPalettesMax = 6;
        public static int OverworldAuxPalettesMax = 20;
        public static int OverworldAnimatedPalettesMax = 14;
        public static int GlobalSpritePalettesMax = 2;
        public static int ArmorPalettesMax = 5;
        public static int SwordsPalettesMax = 4;
        public static int SpritesAux1PalettesMax = 12;
        public static int SpritesAux2PalettesMax = 11;
        public static int SpritesAux3PalettesMax = 24;
        public static int ShieldsPalettesMax = 3;
        public static int DungeonsMainPalettesMax = 20;
        public static int OverworldBackgroundPaletteMax = NumberOfOWMaps;
        public static int OverworldGrassPalettesMax = 3;
        public static int Object3DPalettesMax = 2;
        public static int OverworldMiniMapPalettesMax = 2;

        public static int overworldSpritesBegining = 0x04C881;
        public static int overworldSpritesAgahnim = 0x04CA21;
        public static int overworldSpritesZelda = 0x04C901;

        /*
        public static int overworldSpritesBeginingEditor = 0x108100;
        public static int overworldSpritesAgahnimEditor = 0x108180;
        public static int overworldSpritesZeldaEditor = 0x1082A0;
        */

        public static int overworldItemsPointers = 0x0DC2F9;
        public static int overworldItemsAddress = 0x0DC8B9; // 1BC2F9
        public static int overworldItemsBank = 0x0DC8BF;
        public static int overworldItemsEndData = 0xD0C89C; // 0DC89E

        public static int mapGfx = 0x007C9C;
        public static int overlayPointers = 0x077664;
        public static int overlayPointersBank = 0x0E;
        public static int overlayData1 = 0x077676;
        public static int overlayData2 = 0x077677;

        public static int ExpandedOverlaySpace = 0x120000;

        public static int overworldTilesType = 0x071459;
        public static int overworldMessages = 0x03F51D;

        // TODO:
        public static int overworldMusicBegining = 0x014303; // 0x40
        public static int overworldMusicZelda = 0x014303 + 0x40; // 0x40
        public static int overworldMusicMasterSword = 0x014303 + 0x80; // 0x40
        public static int overworldMusicAgahim = 0x014303 + 0xC0; // 0x40
        public static int overworldMusicDW = 0x014403; // 0x60

        public static int overworldEntranceAllowedTilesLeft = 0x0DB8C1;
        public static int overworldEntranceAllowedTilesRight = 0x0DB917;

        public static int overworldMapSize = 0x012844; // 0x00 = small maps, 0x20 = large maps
        public static int overworldMapSizeHighByte = 0x012884; // 0x01 = small maps, 0x03 = large maps

        // relative to the WORLD + 0x200 per map
        // large map that are not == parent id = same position as their parent!
        // eg for X position small maps :
        // 0000, 0200, 0400, 0600, 0800, 0A00, 0C00, 0E00

        // all Large map would be :
        // 0000, 0000, 0400, 0400, 0800, 0800, 0C00, 0C00

        public static int overworldMapParentID = 0x0125EC;
        public static int overworldMapParentIDExpanded = 0x140998;

        public static int overworldTransitionPositionY = 0x0128C4;
        public static int overworldTransitionPositionX = 0x012944;

        public static int overworldTransitionPositionYExpanded = 0x140F38;
        public static int overworldTransitionPositionXExpanded = 0x141078;

        public static int overworldScreenSize = 0x01788D;

        public static int OverworldScreenSizeForLoading = 0x04C635;
        public static int OverworldScreenTileMapChangeByScreen1 = 0x012634;
        public static int OverworldScreenTileMapChangeByScreen2 = 0x0126B4;
        public static int OverworldScreenTileMapChangeByScreen3 = 0x012734;
        public static int OverworldScreenTileMapChangeByScreen4 = 0x0127B4;

        public static int OverworldScreenTileMapChangeByScreen1Expanded = 0x140A38;
        public static int OverworldScreenTileMapChangeByScreen2Expanded = 0x140B78;
        public static int OverworldScreenTileMapChangeByScreen3Expanded = 0x140CB8;
        public static int OverworldScreenTileMapChangeByScreen4Expanded = 0x140DF8;

        public static int OverworldMapDataOverflow = 0x130000;

        public static int transition_target_north = 0x013EE2;
        public static int transition_target_west = 0x013F62;

        public static int transition_target_northExpanded = 0x1411B8;
        public static int transition_target_westExpanded = 0x1412F8;

        public static int OverworldCustomASMHasBeenApplied = 0x140145; // 1 byte, corresponds to the version number. 0 if not applied at all.

        public static int OverworldCustomAreaSpecificBGPalette = 0x140000; // 2 bytes for each overworld area (0x140)
        public static int OverworldCustomAreaSpecificBGEnabled = 0x140140; // 1 byte, not 0 if enabled

        public static int OverworldCustomMainPaletteArray = 0x140160; // 1 byte for each overworld area (0xA0)
        public static int OverworldCustomMainPaletteEnabled = 0x140141; // 1 byte, not 0 if enabled

        public static int OverworldCustomMosaicArray = 0x140200; // 1 byte for each overworld area (0xA0)
        public static int OverworldCustomMosaicEnabled = 0x140142; // 1 byte, not 0 if enabled

        public static int OverworldCustomTileGFXGroupArray = 0x140480; // 8 bytes for each overworld area (0x500)
        public static int OverworldCustomTileGFXGroupEnabled = 0x140148; // 1 byte, not 0 if enabled

        public static int OverworldCustomSubscreenOverlayArray = 0x140340; // 2 bytes for each overworld area (0x140)
        public static int OverworldCustomSubscreenOverlayEnabled = 0x140144; // 1 byte, not 0 if enabled

        public static int OverworldCustomAnimatedGFXArray = 0x1402A0; // 1 byte for each overworld area (0xA0)
        public static int OverworldCustomAnimatedGFXEnabled = 0x140143; // 1 byte, not 0 if enabled

        public static int[] OverworldCustomDefaultTileGFX = { 0x3A, 0x3B, 0x3C, 0x3D, 0x53, 0x4D, 0x3E, 0x5B,   // LW
                                                              0x42, 0x43, 0x44, 0x45, 0x2F, 0x30, 0x3F, 0x5B,   // DW
                                                              0x3A, 0x3B, 0x3C, 0x3D, 0x47, 0x48, 0x3E, 0x5B }; // SW

        // ===========================================================================================
        // Overworld Exits/Entrances Variables
        // ===========================================================================================
        public static int OWExitRoomId = 0x015D8A; // 0x15E07 Credits sequences
                                                  // 105C2 Ending maps
                                                  // 105E2 Sprite Group Table for Ending
        public static int OWExitMapId = 0x015E28;
        public static int OWExitVram = 0x015E77;
        public static int OWExitYScroll = 0x015F15;
        public static int OWExitXScroll = 0x015FB3;
        public static int OWExitYPlayer = 0x016051;
        public static int OWExitXPlayer = 0x0160EF;
        public static int OWExitYCamera = 0x01618D;
        public static int OWExitXCamera = 0x01622B;
        public static int OWExitDoorPosition = 0x015724;
        public static int OWExitUnk1 = 0x0162C9;
        public static int OWExitUnk2 = 0x016318;
        public static int OWExitDoorType1 = 0x016367;
        public static int OWExitDoorType2 = 0x016405;
        public static int OWEntranceMap = 0x0DB96F;
        public static int OWEntrancePos = 0x0DBA71;
        public static int OWEntranceEntranceId = 0x0DBB73;
        public static int OWHolePos = 0x0DB800; // (0x13 entries, 2 bytes each) modified(less 0x400) map16 coordinates for each hole
        public static int OWHoleArea = 0x0DB826; // (0x13 entries, 2 bytes each) corresponding area numbers for each hole
        public static int OWHoleEntrance = 0x0DB84C; // (0x13 entries, 1 byte each)  corresponding entrance numbers

        public static int OWExitMapIdWhirlpool = 0x016AE5;  // JP = ;016849
        public static int OWExitVramWhirlpool = 0x016B07;   // JP = ;01686B
        public static int OWExitYScrollWhirlpool = 0x016B29;// JP = ;01688D
        public static int OWExitXScrollWhirlpool = 0x016B4B;// JP = ;016DE7
        public static int OWExitYPlayerWhirlpool = 0x016B6D;// JP = ;016E09
        public static int OWExitXPlayerWhirlpool = 0x016B8F;// JP = ;016E2B
        public static int OWExitYCameraWhirlpool = 0x016BB1;// JP = ;016E4D
        public static int OWExitXCameraWhirlpool = 0x016BD3;// JP = ;016E6F
        public static int OWExitScrollModYWhirlpool = 0x016BF5;   // JP = ;016E91
        public static int OWExitScrollModXWhirlpool = 0x016C17;   // JP = ;016EB3
        public static int OWWhirlpoolPosition = 0x016CF8;   // JP = ;016F94
        public static int OWWhirlpoolCount = 0x11;

        // ===========================================================================================
        // Dungeon Related Variables
        // ===========================================================================================
        // That could be turned into a pointer :
        public static int dungeons_palettes_groups = 0x075460; // JP 0x67DD0
        public static int dungeons_main_bg_palette_pointers = 0x0DEC4B; // JP Same
        public static int dungeons_palettes = 0x0DD734; // JP Same (where all dungeons palettes are)

        // That could be turned into a pointer :
        //public static int room_items_pointers = 0x00DB69; // JP 0xDB67
        public static int room_items_pointers_ptr = 0x00E6C2;


        public static int rooms_sprite_pointer = 0x04C298; // JP Same //2byte bank 09D62E
        public static int room_header_pointer = 0x00B5DD; // LONG
        public static int room_header_pointers_bank = 0x00B5E7; // JP Same

        public static int room_header_expanded_default = 0x110000;

        public static int gfx_groups_pointer = 0x006237;
        public static int room_object_layout_pointer = 0x00882D;

        public static int room_object_pointer = 0x00874C; // Long pointer

        public static int chests_length_pointer = 0x00EBF6;
        public static int chests_data_pointer1 = 0x00EBFB;
        // public static int chests_data_pointer2 = 0x00EC0A; // Disabled for now could be used for expansion
        // public static int chests_data_pointer3 = 0x00EC10; // Disabled for now could be used for expansion

        public static int blocks_length = 0x008896; // Word value
        public static int blocks_pointer1 = 0x015AFA;
        public static int blocks_pointer2 = 0x015B01;
        public static int blocks_pointer3 = 0x015B08;
        public static int blocks_pointer4 = 0x015B0F;

        public static int torch_data = 0x02736A; // JP 0x2704A
        public static int torches_length_pointer = 0x0088C1;

        public static int sprite_blockset_pointer = 0x005B57;
        //04D62E
        public static int sprites_data = 0x04D880; // It use the unused pointers to have more space //Save purpose
        public static int sprites_data_empty_room = 0x04D87E;
        public static int sprites_end_data = 0x04EC9E;

        public static int pit_pointer = 0x0394AB;
        public static int pit_count = 0x0394A6;

        public static int doorPointers = 0x0F83C0;

        // doors
        public static int door_gfx_up = 0x004D9E;
        public static int door_gfx_down = 0x004E06;
        public static int door_gfx_cavexit_down = 0x004E06;
        public static int door_gfx_left = 0x004E66;
        public static int door_gfx_right = 0x004EC6;

        public static int door_pos_up = 0x00197E;
        public static int door_pos_down = 0x001996;
        public static int door_pos_left = 0x0019AE;
        public static int door_pos_right = 0x0019C6;

        // TEXT EDITOR RELATED CONSTANTS
        public static int gfx_font = 0x070000; // 2bpp format

        public static int text_data = 0x0E0000;
        public static int text_data_end = 0x0E7FFF;
        public static int text_data2 = 0x075F40;
        public static int text_data2_end = 0x0773FF;
        public static int text_data3 = 0x000000; // find free space (half bank should give us
        public static int text_data3_end = 0x000000; // use half of that bank reserve rest for other stuff
        public static int text_expanded_check = 0x075436;
        public static byte text_expanded_check_value = 0xA9; // if not A9 text has been expanded


        public static int pointers_dictionaries = 0x074703;
        public static int characters_width = 0x074ADF;

        public static int DungeonSection1Index = 0x050008; // 0x50000 to 0x5374F
        public static int DungeonSection1EndIndex = 0x053730;

        public static int DungeonSection2Index = 0x0F878A; // 0xF878A to 0xFFFFF.
        public static int DungeonSection2EndIndex = 0x0FFFFF;

        public static int DungeonSection3Index = 0x01EB90; // 0x1EB90 to 0x1FFFF.
        public static int DungeonSection3EndIndex = 0x01FFFF;

        public static int DungeonSection4Index = 0x138000; // 0x138000 to 0x13FFFF.
        public static int DungeonSection4EndIndex = 0x13FFFF;

        public static int DungeonSection5Index = 0x148000; // 0x148000 to 0x14FFFF.
        public static int DungeonSection5EndIndex = 0x14FFFF;

        public static int DungeonOverlayLoadPtr = 0x00B857; //# _01B856: LDA.l OverlayDataPointers+0,X ( orig value = C0 EC 04 ) *load & save* 0x12 ptrs
        public static int DungeonOverlayLoadPtr2 = 0x00B851; //# _01B850: LDA.l OverlayDataPointers+1,X ( orig value = C1 EC 04 ) *saving only*

        public static int DungeonOverlayWaterPtr1 = 0x009C2A;
        public static int DungeonOverlayWaterPtr1Bank = 0x009C25;


        public static int DungeonOverlayWaterPtr2 = 0x00CBB2;
        public static int DungeonOverlayWaterPtr2Bank = 0x00CBAD;

        public static int DungeonOverlayNewPosition = 0x026C1C; // 04EC1C pc address
        public static int DungeonOverlayDataLimit = 0x026F2E;


        // ===========================================================================================
        // Dungeon Entrances Related Variables
        // ===========================================================================================

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
        public static int entrance_gfx_group = 0x005D97;


        public static int entrance_room = 0x014813; // 0x14577 // Word value for each room
        public static int entrance_scrolledge = 0x01491D; // 0x14681 // 8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
        public static int entrance_cameray = 0x014D45; // 0x14AA9 // 2bytes each room
        public static int entrance_camerax = 0x014E4F; // 0x14BB3 // 2bytes
        public static int entrance_yposition = 0x014F59; // 0x14CBD 2bytes
        public static int entrance_xposition = 0x015063;// 0x14DC7 2bytes
        public static int entrance_cameraytrigger = 0x01516D;// 0x14ED1 2bytes
        public static int entrance_cameraxtrigger = 0x015277;// 0x14FDB 2bytes
        public static int entrance_blockset = 0x015381; // 0x150E5 1byte
        public static int entrance_floor = 0x015406; // 0x1516A 1byte
        public static int entrance_dungeon = 0x01548B; // 0x151EF 1byte (dungeon id)
        public static int entrance_door = 0x015510; // 0x15274 1byte
        public static int entrance_ladderbg = 0x015595; // 0x152F9 // 1byte, ---b ---a b = bg2, a = need to check -_-
        public static int entrance_scrolling = 0x01561A; // 0x1537E // 1byte --h- --v-
        public static int entrance_scrollquadrant = 0x01569F; // 0x15403 1byte
        public static int entrance_exit = 0x015724; // 0x15488 // 2byte word
        public static int entrance_music = 0x01582E; // 0x15592


        // EXPANDED to 0x78000 to 0x7A000
        public static int entrance_roomEXP = 0x078000; 
        public static int entrance_scrolledgeEXP = 0x078200;
        public static int entrance_camerayEXP = 0x078A00;
        public static int entrance_cameraxEXP = 0x078C00;
        public static int entrance_ypositionEXP = 0x078E00;
        public static int entrance_xpositionEXP = 0x079000;
        public static int entrance_cameraytriggerEXP = 0x079200;
        public static int entrance_cameraxtriggerEXP = 0x079400;
        public static int entrance_blocksetEXP = 0x079600;
        public static int entrance_floorEXP = 0x079700;
        public static int entrance_dungeonEXP = 0x079800;
        public static int entrance_doorEXP = 0x079900;
        public static int entrance_ladderbgEXP = 0x079A00; 
        public static int entrance_scrollingEXP = 0x079B00;
        public static int entrance_scrollquadrantEXP = 0x079C00;
        public static int entrance_exitEXP = 0x079D00;
        public static int entrance_musicEXP = 0x079F00;
        public static int entrance_ExtraEXP = 0x07A000;
        public static int entrance_TotalEXP = 0xFF;
        public static int entrance_Total = 0x84;
        public static int entrance_LinkSpawn = 0x00;
        public static int entrance_NorthTavern = 0x43;

        public static int entrance_EXP = 0x07F000;

        public static int startingentrance_room = 0x015B6E; // 0x158D2 // Word value for each room
        public static int startingentrance_scrolledge = 0x015B7C; // 0x158E0 // 8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
        public static int startingentrance_cameray = 0x015BB4; // 0x14AA9 // 2bytes each room
        public static int startingentrance_camerax = 0x015BC2; // 0x14BB3 // 2bytes
        public static int startingentrance_yposition = 0x015BD0; // 0x14CBD 2bytes
        public static int startingentrance_xposition = 0x015BDE; // 0x14DC7 2bytes
        public static int startingentrance_cameraytrigger = 0x015BEC; // 0x14ED1 2bytes
        public static int startingentrance_cameraxtrigger = 0x015BFA; // 0x14FDB 2bytes

        public static int startingentrance_blockset = 0x015C08; // 0x150E5 1byte
        public static int startingentrance_floor = 0x015C0F; // 0x1516A 1byte
        public static int startingentrance_dungeon = 0x015C16; // 0x151EF 1byte (dungeon id)

        public static int startingentrance_door = 0x015C2B; // 0x15274 1byte

        public static int startingentrance_ladderbg = 0x015C1D; // 0x152F9 // 1byte, ---b ---a b = bg2, a = need to check -_-
        public static int startingentrance_scrolling = 0x015C24; // 0x1537E // 1byte --h- --v-
        public static int startingentrance_scrollquadrant = 0x015C2B; // 0x15403 1byte
        public static int startingentrance_exit = 0x015C32; // 0x15488 // 2byte word
        public static int startingentrance_music = 0x015C4E; // 0x15592
        public static int startingentrance_entrance = 0x015C40;

        //public static int items_data_start = 0x00DDE9; // Save purpose
        public static int items_data_end = 0x00E6B2; // Save purpose
        public static int initial_equipement = 0x0271A6;
        public static int messages_id_dungeon = 0x03F61D;

        public static int chests_backupitems = 0x03B528; // Item id you get instead if you already have that item
        public static int chests_yoffset = 0x04836C;
        public static int chests_xoffset = 0x4836C + (76 * 1);
        public static int chests_itemsgfx = 0x4836C + (76 * 2);
        public static int chests_itemswide = 0x4836C + (76 * 3);
        public static int chests_itemsproperties = 0x4836C + (76 * 4);
        public static int chests_sramaddress = 0x4836C + (76 * 5);
        public static int chests_sramvalue = 0x4836C + (76 * 7);
        public static int chests_msgid = 0x0442DD;

        public static int dungeons_startrooms = 0x007939;
        public static int dungeons_endrooms = 0x00792D;
        public static int dungeons_bossrooms = 0x010954; // Short value

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
        public static int GravesYTilePos = 0x049968; // Short (0x0F entries)
        public static int GravesXTilePos = 0x049986; // Short (0x0F entries)
        public static int GravesTilemapPos = 0x0499A4; // Short (0x0F entries)
        public static int GravesGFX = 0x0499C2; // Short (0x0F entries)

        public static int GravesXPos = 0x04994A;  // Short (0x0F entries)
        public static int GravesYLine = 0x04993A; // Short (0x08 entries)
        public static int GravesCountOnY = 0x0499E0; // Byte 0x09 entries

        public static int GraveLinkSpecialStairs = 0x046DD9; // Short
        public static int GraveLinkSpecialHole = 0x046DE0; // Short

        // ===========================================================================================
        // Palettes Related Variables - This contain all the palettes of the game
        // ===========================================================================================  asdfasdfasdfasfadf
        public static int overworldPaletteMain = 0x0DE6C8;
        public static int overworldPaletteAuxialiary = 0x0DE86C;
        public static int overworldPaletteAnimated = 0x0DE604;
        public static int globalSpritePalettesLW = 0x0DD218;
        public static int globalSpritePalettesDW = 0x0DD290;
        public static int armorPalettes = 0x0DD308; // Green, Blue, Red, Bunny, Electrocuted (15 colors each)
        public static int spritePalettesAux1 = 0x0DD39E; // 7 colors each
        public static int spritePalettesAux2 = 0x0DD446; // 7 colors each
        public static int spritePalettesAux3 = 0x0DD4E0; // 7 colors each
        public static int swordPalettes = 0x0DD630; // 3 colors each - 4 entries
        public static int shieldPalettes = 0x0DD648; // 4 colors each - 3 entries
        public static int hudPalettes = 0x0DD660;
        public static int dungeonMapPalettes = 0x0DD70A; // 21 colors
        public static int dungeonMainPalettes = 0x0DD734; // (15*6) colors each - 20 entries
        public static int dungeonMapBgPalettes = 0x0DE544; // 16*6
        public static int hardcodedGrassLW1 = 0x05FEA9;
        public static int hardcodedGrassLW2 = 0x075645;
        public static int hardcodedGrassLW3 = 0x075625;
        public static int hardcodedGrassDW1 = 0x05FEB3;
        public static int hardcodedGrassDW2 = 0x07564F;
        public static int hardcodedGrassSpecial = 0x075640;
        public static int overworldMiniMapPalettes = 0x055B27;
        public static int triforcePalette = 0x064425;
        public static int crystalPalette = 0x0F4CD3;

        // ===========================================================================================
        // Dungeon Map Related Variables
        // ===========================================================================================
        public static int dungeonMap_rooms_ptr = 0x057605; // 14 pointers of map data
        public static int dungeonMap_floors = 0x0575D9; // 14 words values

        public static int dungeonMap_gfx_ptr = 0x057BE4; // 14 pointers of gfx data
        public static int dungeonMap_datastart = 0x057039; // Data start for floors/gfx MUST skip 575D9 to 57621 (pointers)

        public static int dungeonMap_expCheck = 0x056652; // IF Byte = 0xB9 dungeon maps are not expanded
        public static int dungeonMap_tile16 = 0x057009;
        public static int dungeonMap_tile16Exp = 0x109010;
        public static int dungeonMap_bossrooms = 0x056807; // 14 words values 0x000F = no boss

        public static int crystalVerticesCount = 0x04FF8C;
        public static int crystalFaceCount = 0x04FF8D;

        public static int crystalVerticesPointer = 0x04FF8E;
        public static int crystalFacesPointer = 0x04FF90;
        public static int crystalMaxSize = 0x3A;

        public static int triforceVerticesCount = 0x04FF92;
        public static int triforceFaceCount = 0x04FF93;

        public static int triforceVerticesPointer = 0x04FF94;
        public static int triforceFacesPointer = 0x04FF96;
        public static int triforceMaxSize = 0x2E;

        // ===========================================================================================
        // Title screen GFX group set
        // ===========================================================================================
        public static int titleScreenTilesGFX = 0x064207; // 1 Byte
        public static int titleScreenSpritesGFX = 0x06420C; // 1 Byte
        public static int titleScreenExtraTilesGFX = 0x064211; // 1 Byte
        public static int titleScreenExtraSpritesGFX = 0x064216; // 1 Byte

        public static int TitleScreenPosition = 0x108000;

        // ===========================================================================================
        // Custom Collision
        // ===========================================================================================
        public static int customCollisionRoomPointers = 0x128090; // Array 3 bytes per room
        public static int customCollisionDataPosition = 0x128450; // A bunch of FFFF ended arrays

        // ===========================================================================================
        // Sprite Properties
        // ===========================================================================================
        public static int Sprite_0DB080 = 0x06B080;
        public static int Sprite_Health = 0x06B173;
        public static int Sprite_0DB266 = 0x06B266;
        public static int Sprite_0DB359 = 0x06B359;
        public static int Sprite_0DB44C = 0x06B44C;
        public static int Sprite_0DB53F = 0x06B53F;
        public static int Sprite_0DB632 = 0x06B632;
        public static int Sprite_0DB725 = 0x06B725;
        public static int Sprite_DamageTaken = 0x01E800;
        public static int DamageClass = 0x06B8F1;
        public static int BumpDamageGroups = 0x037427;

        // ===========================================================================================
        // End Main Addresses
        // ===========================================================================================

        public static bool Rando = false; // Is it a rando rom?

        public static void Init_Jp(bool rando = false)
        {
            pit_pointer = 0x0394A2;
            pit_count = 0x03949D;
            // 04EF2F
            dungeons_palettes_groups = 0x067DD0;
            //room_items_pointers = 0x00DB67;
            torch_data = 0x02704A;

            entrance_gfx_group = 0x005DD7;
            sprite_blockset_pointer = 0x005B97;
            blocks_pointer1 = 0x01585E;
            blocks_pointer2 = 0x015865;
            blocks_pointer3 = 0x01586C;
            blocks_pointer4 = 0x015873;
            chests_length_pointer = 0x00EBF4;
            chests_data_pointer1 = 0x00EBF9;
            gfx_groups_pointer = 0x006277;
            //items_data_start = 0x00DDE7;
            //items_data_end = 0x00E6B0;
            gfx_1_pointer = 0x0067D0; // 2byte pointer bank 00 -> pc 0x4FC0
            gfx_2_pointer = 0x0067D5; // 509F
            gfx_3_pointer = 0x0067DA; // 517E
            messages_id_dungeon = 0x03F5F7;
            gfx_animated_pointer = 0x010624;
            initial_equipement = 0x183000;

            // Entrances
            entrance_room = 0x014577; // Word value for each room
            entrance_scrolledge = 0x01491D; // 0x14681 / /8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
            entrance_camerax = 0x014AA9; // 2bytes each room
            entrance_cameray = 0x014BB3; // 2bytes
            entrance_yposition = 0x014CBD; // 2bytes
            entrance_xposition = 0x014DC7; // 2bytes
            entrance_cameraytrigger = 0x014ED1; // 2bytes
            entrance_cameraxtrigger = 0x014FDB; // 2bytes
            entrance_blockset = 0x0150E5; // 1byte
            entrance_floor = 0x01516A; // 1byte
            entrance_dungeon = 0x0151EF; // 1byte (dungeon id)
            entrance_door = 0x015274; // 1byte
            entrance_ladderbg = 0x0152F9; // 1 byte, ---b ---a b = bg2, a = need to check -_-
            entrance_scrolling = 0x01537E; // 1byte --h- --v-
            entrance_scrollquadrant = 0x015403; // 1byte
            entrance_exit = 0x015488; // 2byte word
            entrance_music = 0x015592;

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
            overworldgfxGroups = 0x005DD7;
            hardcodedGrassLW1 = 0x067FE6;
            hardcodedGrassDW1 = 0x067FF0; // map>40
            hardcodedGrassSpecial = 0x067FE1; // map 183,182,180

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

            overworldgfxGroups2 = 0x0060B3;

            /*
            public static int map32TilesTL = 0x018000;
            public static int map32TilesTR = 0x01B400;
            public static int map32TilesBL = 0x020000;
            public static int map32TilesBR = 0x023400;
            */

            map32TilesTL = 0x018000;
            map32TilesTR = 0x01B3C0;
            map32TilesBL = 0x020000;
            map32TilesBR = 0x0233C0;
            compressedAllMap32PointersHigh = 0x0176B1; // LONGPointers all tiles of maps[High] (mapid* 3)
            compressedAllMap32PointersLow = 0x017891; // LONGPointers all tiles of maps[Low] (mapid* 3)
            overworldMapPalette = 0x007D1C; // JP
            overworldMapPaletteGroup = 0x067E74;
            overworldMapSize = 0x01273B; // JP
            overlayPointers = 0x03FAF4;
            overlayPointersBank = 0x07;
            overworldTilesType = 0x07FD94;
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
            private readonly string nom;

            public string Name { get => nom; }

            private readonly byte val;

            public byte ByteValue { get => val; }

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

        public static FloorNumber[] floors = new FloorNumber[]
        {
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
            new FloorNumber("8F", 0x07),
        };

        public static string PalName_HUD = "HudPal";
        public static string PalName_OWMain = "OverworldMainPal";
        public static string PalName_OWAux = "OverworldAuxPal";
        public static string PalName_OWAni = "OverworldAnimatedPal";
        public static string PalName_DunMain = "DungeonMainPal";
        public static string PalName_SprGlobal = "GlobalSpritesPal";
        public static string PalName_SprAux1 = "SpritesAux1Pal";
        public static string PalName_SprAux2 = "SpritesAux2Pal";
        public static string PalName_SprAux3 = "SpritesAux3Pal";
        public static string PalName_Shield = "ShieldsPal";
        public static string PalName_Sword = "SwordsPal";
        public static string PalName_Armor = "ArmorsPal";
        public static string PalName_OWGrass = "OverworldGrassPal";
        public static string PalName_Obj3D = "Objects3DPal";
        public static string PalName_OWMap = "OverworldMapsPal";

        public static string PalDisplayName_HUD = "Hud";
        public static string PalDisplayName_OWMain = "Overworld Main";
        public static string PalDisplayName_OWAux = "Overworld Aux";
        public static string PalDisplayName_OWAni = "Overworld Animated";
        public static string PalDisplayName_DunMain = "Dungeon Main";
        public static string PalDisplayName_SprGlobal = "Global Sprites";
        public static string PalDisplayName_SprAux1 = "Sprites Aux1";
        public static string PalDisplayName_SprAux2 = "Sprites Aux2";
        public static string PalDisplayName_SprAux3 = "Sprites Aux3";
        public static string PalDisplayName_Shield = "Shields";
        public static string PalDisplayName_Sword = "Swords";
        public static string PalDisplayName_Armor = "Armors";
        public static string PalDisplayName_OWGrass = "Overworld Grass";
        public static string PalDisplayName_Obj3D = "3D Objects";
        public static string PalDisplayName_OWMap = "OverworldMaps";
        public static string PalDisplayName_Triforce = "Triforce";
        public static string PalDisplayName_Crystals = "Crystal";

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
            "Ganon's Darkness",
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
            "Kill Boss Again",
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
            "Switch",
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
            "Door X top? (unused?)",
        };


        public static string[] musicNames = new string[]
            {
                "00_No Music",
                "01_TriforceIntro",
                "02_LightWorldOverture",
                "03_Rain",
                "04_BunnyTheme",
                "05_LostWoods",
                "06_LegendsTheme_Attract",
                "07_KakarikoVillage",
                "08_MirrorWarp",
                "09_DarkWorld",
                "0A_PullingTheMasterSword",
                "0B_FairyTheme",
                "0C_Fugitive",
                "0D_SkullWoodsMarch",
                "0E_MinigameTheme",
                "0F_IntroFanfare",
                "10_HyruleCastle",
                "11_PendantDungeon",
                "12_Cave",
                "13_Fanfare",
                "14_Sanctuary",
                "15_Boss",
                "16_CrystalDungeon",
                "17_Shop",
                "12_Cavea",
                "19_ZeldaRescue",
                "1A_CrystalMaiden",
                "1B_BigFairy",
                "1C_Suspense",
                "1D_AgahnimEscapes",
                "1E_MeetingGanon",
                "1F_KingOfThieves",
                "20_TriforceRoom",
                "21_EndingTheme",
                "22_Credits"
            };


        // TODO move to DefaultEntities
        public static string[] musicNamesOW = new string[]
        {
            "0x00 None",
            "0x01 Triforce Opening",
            "0x02 Light World",
            "0x03 Rain",
            "0x04 Bunny Link",
            "0x05 Lost woods",
            "0x06 Legends theme (attract mode)",
            "0x07 Kakariko Village",
            "0x08 Mirror warp",
            "0x09 Dark World",
            "0x0A Restoring Master Sword",
            "0x0B Faerie Theme",
            "0x0C Chase Theme",
            "0x0D Skull Woods",
            "0x0E Game theme",
            "0x0F Intro no Triforce"
        };

        public static string[] ambientNamesOW = new string[]
        {
            "0x00 Nothing",
            "0x01 Rain / Zora area",
            "0x02 Quiet rain",
            "0x03 More rain",
            "0x04 Even more rain",
            "0x05 Silence",
            "0x06 Silence 2",
            "0x07 Rumbling",
            "0x08 Endless rumbling",
            "0x09 Wind",
            "0x0A Quiet wind",
            "0x0B Flute song",
            "0x0C Flute again",
            "0x0D Magic bat/Witch shroom",
            "0x0E Magic bat",
            "0x0F Crystal get / Save and quit",
            "0x10 SQ sound",
            "0x11 Choir melody",
            "0x12 Choir countermelody",
            "0x13 Lanmo/Blind swoosh",
            "0x14 Another swoosh",
            "0x15 Triforce door/Pyramid hole opening",
            "0x16 VOMP",
            "0x17 Flute again again",
            "0x18 Why is there so much flute",
            "0x19 Nothing",
            "0x1A Nothing",
            "0x1B All flute and no play",
            "0x1C Makes flute a flutey flute",
            "0x1D Some jingle",
            "0x1E That broken jingle again",
            "0x1F Crystal get again",
            "0x20 Crystal get again again"
        };




        public static string[] textsLocations = new string[]
        {
            "Empty", // 00
            "", // 01
            "", // 02
            "", // 03
            "", // 04
            "", // 05
            "", // 06
            "", // 07
            "", // 08
            "", // 09
            "", // 0A
            "", // 0B
            "", // 0C
            "Uncle 1st message (when you wake up)", // 0D
            "Uncle 2nd message (when dying and giving sword & shield)", // 0E
            "Tutorial Guard Message 1 (loop from message 1 to 7 in order)", // 0F
            "Tutorial Guard Message 2", // 10
            "Tutorial Guard Message 3", // 11
            "Tutorial Guard Message 4", // 12
            "Tutorial Guard Message 5", // 13
            "Tutorial Guard Message 6", // 14
            "Tutorial Guard Message 7", // 15
            "Priest message (when you talk to him after rescuing zelda)", // 16
            "1st Priest message (when you rescue zelda)", // 17
            "3rd Priest message", // 18
            "4th Priest message (after talking to sahasrahla)", // 19
            "5th Priest message (when you have 3 pendants)", // 1A
            "Priest message (dying on ground, after you get master sword)", // 1B
            "Zelda 1st message (when touching her in cell)", // 1C
            "2nd Priest message (when zelda moved beside priest)", // 1D
            "Zelda message (when you talk to her after rescuing beside priest)", // 1E
            "Zelda telepathic 1st message (when sleeping in bed)", // 1F
            "Zelda telepathic message (every minute poping before you get sword)", // 20
            "Zelda message (when entering castle lobby while following you)", // 21
            "Zelda message (when entering throne room while following you)", // 22
            "Zelda message (when entering the room with 2 lever to pull)", // 23
            "Zelda 1st message (after you saved her in cell)", // 24
            "Zelda 2nd message (after you saved her in cell)", // 25
            "Zelda message (after talking to sahasrahla)", // 26
            "Zelda message (when you have 3 pendants)", // 27
            "Priest Telepathic Message (when you exit master sword area after getting it)", // 28
            "Zelda message (when entering the sewers)", // 29
            "Zelda message (when entering when approaching a switch)", // 2A
            "Lady in elder house 1st message (after rescuing zelda)", // 2B
            "Lady in elder house 2nd message", // 2C
            "Lady in elder house 3rd message", // 2D
            "Lady in elder house (after getting master sword)", // 2E
            "Snitches in kakariko village", // 2F
            "Sahasrahla (when you have the 3 pendants and ice rod)", // 30
            "Sahasrahla (when you have mastersword and ice rod)", // 31
            "Sahasrahla 1st message", // 32
            "Sahasrahla 2nd message (when you accept his quest)", // 33
            "Sahasrahla (when you have ice rod but not the 3 pendants)", // 34
            "Message (when reaching top of the pyramid)", // 35
            "", // 36
            "", // 37
            "", // 38
            "", // 39
            "", // 3A
            "", // 3B
            "", // 3C
            "", // 3D
            "", // 3E
            "", // 3F

            "", // 40
            "", // 41
            "", // 42
            "", // 43
            "", // 44
            "", // 45
            "", // 46
            "", // 47
            "", // 48
            "", // 49
            "", // 4A
            "", // 4B
            "", // 4C
            "", // 4D
            "", // 4E
            "", // 4F

            "", // 50
            "", // 51
            "", // 52
            "", // 53
            "", // 54
            "", // 55
            "", // 56
            "", // 57
            "", // 58
            "", // 59
            "", // 5A
            "", // 5B
            "", // 5C
            "", // 5D
            "", // 5E
            "", // 5F

            "", // 60
            "", // 61
            "", // 62
            "", // 63
            "", // 64
            "", // 65
            "", // 66
            "", // 67
            "", // 68
            "", // 69
            "", // 6A
            "", // 6B
            "", // 6C
            "", // 6D
            "", // 6E
            "", // 6F

            "Telepathic message (right after you get master sword)", // 70
            "", // 71
            "", // 72
            "", // 73
            "", // 74
            "", // 75
            "", // 76
            "", // 77
            "", // 78
            "", // 79
            "", // 7A
            "", // 7B
            "", // 7C
            "", // 7D
            "", // 7E
            "", // 7F

            "", // 80
            "", // 81
            "", // 82
            "", // 83
            "", // 84
            "", // 85
            "", // 86
            "", // 87
            "", // 88
            "", // 89
            "", // 8A
            "", // 8B
            "", // 8C
            "", // 8D
            "", // 8E
            "", // 8F

            "", // 90
            "", // 91
            "", // 92
            "", // 93
            "", // 94
            "", // 95
            "", // 96
            "", // 97
            "", // 98
            "", // 99
            "", // 9A
            "", // 9B
            "", // 9C
            "", // 9D
            "", // 9E
            "", // 9F

            "", // A0
            "", // A1
            "", // A2
            "", // A3
            "", // A4
            "", // A5
            "", // A6
            "", // A7
            "", // A8
            "", // A9
            "", // AA
            "", // AB
            "", // AC
            "", // AD
            "", // AE
            "", // AF

            "", // B0
            "", // B1
            "", // B2
            "", // B3
            "", // B4
            "", // B5
            "", // B6
            "", // B7
            "", // B8
            "", // B9
            "", // BA
            "", // BB
            "", // BC
            "", // BD
            "", // BE
            "", // BF

            "", // C0
            "", // C1
            "", // C2
            "", // C3
            "", // C4
            "", // C5
            "", // C6
            "", // C7
            "", // C8
            "", // C9
            "", // CA
            "", // CB
            "", // CC
            "", // CD
            "", // CE
            "", // CF

            "", // D0
            "", // D1
            "", // D2
            "", // D3
            "", // D4
            "", // D5
            "", // D6
            "", // D7
            "", // D8
            "", // D9
            "", // DA
            "", // DB
            "", // DC
            "", // DD
            "", // DE
            "", // DF

            "", // E0
            "", // E1
            "", // E2
            "", // E3
            "", // E4
            "", // E5
            "", // E6
            "", // E7
            "", // E8
            "", // E9
            "", // EA
            "", // EB
            "", // EC
            "", // ED
            "", // EE
            "", // EF

            "", // F0
            "", // F1
            "", // F2
            "", // F3
            "", // F4
            "", // F5
            "", // F6
            "", // F7
            "", // F8
            "", // F9
            "", // FA
            "", // FB
            "", // FC
            "", // FD
            "", // FE
            "", // FF
                        "", // 100
            "", // 101
            "", // 102
            "", // 103
            "", // 104
            "", // 105
            "", // 106
            "", // 107
            "", // 108
            "", // 109
            "", // 10A
            "", // 10B
            "", // 10C
            "", // 10D
            "", // 10E
            "", // 10F

            "", // 110
            "", // 111
            "", // 112
            "", // 113
            "", // 114
            "", // 115
            "", // 116
            "", // 117
            "", // 118
            "", // 119
            "", // 11A
            "", // 11B
            "", // 11C
            "", // 11D
            "", // 11E
            "", // 11F
            
            "", // 120
            "", // 121
            "", // 122
            "", // 123
            "", // 124
            "", // 125
            "", // 126
            "", // 127
            "", // 128
            "", // 129
            "", // 12A
            "", // 12B
            "", // 12C
            "", // 12D
            "", // 12E
            "", // 12F

            "", // 130
            "", // 131
            "", // 132
            "", // 133
            "", // 134
            "", // 135
            "", // 136
            "", // 137
            "", // 138
            "", // 139
            "", // 13A
            "", // 13B
            "", // 13C
            "", // 13D
            "", // 13E
            "", // 13F

            "", // 140
            "", // 141
            "", // 142
            "", // 143
            "", // 144
            "", // 145
            "", // 146
            "kid in kakariko (after you rescued zelda putting a X on your map)", // 147
            "", // 148
            "", // 149
            "", // 14A
            "", // 14B
            "", // 14C
            "", // 14D
            "", // 14E
            "", // 14F

            "", // 150
            "", // 151
            "", // 152
            "", // 153
            "", // 154
            "", // 155
            "", // 156
            "", // 157
            "", // 158
            "", // 159
            "", // 15A
            "", // 15B
            "", // 15C
            "", // 15D
            "", // 15E
            "", // 15F

            "", // 160
            "", // 161
            "", // 162
            "", // 163
            "", // 164
            "", // 165
            "", // 166
            "", // 167
            "", // 168
            "", // 169
            "", // 16A
            "", // 16B
            "", // 16C
            "", // 16D
            "", // 16E
            "", // 16F

            "", // 170
            "", // 171
            "", // 172
            "", // 173
            "", // 174
            "", // 175
            "", // 176
            "", // 177
            "", // 178
            "", // 179
            "", // 17A
            "", // 17B
            "", // 17C
            "", // 17D
            "", // 17E
            "", // 17F

            "", // 180
            "", // 181
            "", // 182
            "", // 183
            "", // 184
            "", // 185
            "", // 186
            "", // 187
            "", // 188
            "", // 189
            "", // 18A
            "", // 18B
            "", // 18C
            "", // 18D
            "", // 18E
            "", // 18F
        };
    }
}
