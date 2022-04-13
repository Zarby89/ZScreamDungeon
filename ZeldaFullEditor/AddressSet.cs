using System;
using System.Reflection;

namespace ZeldaFullEditor
{
	public class AddressSet
	{
		private static readonly ROMAddress _tile_address = new ROMAddress(0x009B52, 0x009B52);
		private static readonly ROMAddress _tile_address_floor = new ROMAddress(0x009B5A, 0x009B5A);
		private static readonly ROMAddress _subtype1_tiles = new ROMAddress(0x018000, 0x018000);
		private static readonly ROMAddress _subtype2_tiles = new ROMAddress(0x0183F0, 0x0183F0);
		private static readonly ROMAddress _subtype3_tiles = new ROMAddress(0x0184F0, 0x0184F0);
		private static readonly ROMAddress _gfx_animated_pointer = new ROMAddress(0x028624, 0x028275);
		private static readonly ROMAddress _overworldgfxGroups2 = new ROMAddress(0x00E0B3, 0x00E073);
		private static readonly ROMAddress _gfx_1_pointer = new ROMAddress(0x00E7D0, 0x00E790);
		private static readonly ROMAddress _gfx_2_pointer = new ROMAddress(0x00E7D5, 0x00E795);
		private static readonly ROMAddress _gfx_3_pointer = new ROMAddress(0x00E7DA, 0x00E79A);
		private static readonly ROMAddress _maxGfx = new ROMAddress(0x18BFB5, 0x18BFB5);
		private static readonly ROMAddress _compressedAllMap32PointersHigh = new ROMAddress(0x02F6B1, 0x02F94D);
		private static readonly ROMAddress _compressedAllMap32PointersLow = new ROMAddress(0x02F891, 0x02FB2D);
		private static readonly ROMAddress _overworldgfxGroups = new ROMAddress(0x00DDD7, 0x00DD97);
		private static readonly ROMAddress _map16Tiles = new ROMAddress(0x0F8000, 0x0F8000);
		private static readonly ROMAddress _Map32DefinitionsTL = new ROMAddress(0x038000, 0x038000);
		private static readonly ROMAddress _Map32DefinitionsTR = new ROMAddress(0x03B3C0, 0x03B400);
		private static readonly ROMAddress _Map32DefinitionsBL = new ROMAddress(0x048000, 0x048000);
		private static readonly ROMAddress _Map32DefinitionsBR = new ROMAddress(0x04B3C0, 0x04B400);
		private static readonly ROMAddress _overworldPalGroup1 = new ROMAddress(0x1BE6C8, 0x1BE6C8);
		private static readonly ROMAddress _overworldPalGroup2 = new ROMAddress(0x1BE86C, 0x1BE86C);
		private static readonly ROMAddress _overworldPalGroup3 = new ROMAddress(0x1BE604, 0x1BE604);
		private static readonly ROMAddress _overworldMapPalette = new ROMAddress(0x00FD1C, 0x00FD1C);
		private static readonly ROMAddress _overworldSpritePalette = new ROMAddress(0x00FB41, 0x00FB41);
		private static readonly ROMAddress _overworldMapPaletteGroup = new ROMAddress(0x0CFE74, 0x0ED504);
		private static readonly ROMAddress _overworldSpritePaletteGroup = new ROMAddress(0x0ED580, 0x0ED580);
		private static readonly ROMAddress _overworldSpriteset = new ROMAddress(0x00FA41, 0x00FA41);
		private static readonly ROMAddress _overworldSpecialGFXGroup = new ROMAddress(0x02E821, 0x02E821);
		private static readonly ROMAddress _overworldSpecialPALGroup = new ROMAddress(0x02E831, 0x02E831);
		private static readonly ROMAddress _OverworldSpritesTableState0 = new ROMAddress(0x09C881, 0x09C881);
		private static readonly ROMAddress _OverworldSpritesTableState3 = new ROMAddress(0x09CA21, 0x09CA21);
		private static readonly ROMAddress _OverworldSpritesTableState2 = new ROMAddress(0x09C901, 0x09C901);
		//private static readonly ROMAddress _overworldSpritesBeginingEditor = new ROMAddress(0x218100, 0x218100);
		//private static readonly ROMAddress _overworldSpritesAgahnimEditor = new ROMAddress(0x218180, 0x218180);
		//private static readonly ROMAddress _overworldSpritesZeldaEditor = new ROMAddress(0x2182A0, 0x2182A0);
		private static readonly ROMAddress _overworldItemsPointers = new ROMAddress(0x1BC2F9, 0x1BC2F9);
		private static readonly ROMAddress _overworldItemsAddress = new ROMAddress(0x1BC8B9, 0x1BC8B9);
		private static readonly ROMAddress _overworldItemsBank = new ROMAddress(0x1BC8BF, 0x1BC8BF);
		private static readonly ROMAddress _overworldItemsEndData = new ROMAddress(0x1BC89C, 0x1BC89C);
		private static readonly ROMAddress _mapGfx = new ROMAddress(0x00FC9C, 0x00FC9C);
		private static readonly ROMAddress _overlayPointers = new ROMAddress(0x07FAF4, 0x0EF664);
		private static readonly ROMAddress _overlayPointersBank = new ROMAddress(0x070000, 0x0E0000);
		private static readonly ROMAddress _overworldTilesType = new ROMAddress(0x0FFD94, 0x0E9459);
		private static readonly ROMAddress _overworldMessages = new ROMAddress(0x07F51D, 0x07F51D);
		private static readonly ROMAddress _overworldMusicBegining = new ROMAddress(0x02C303, 0x02C303);
		private static readonly ROMAddress _overworldMusicZelda = new ROMAddress(0x02C343, 0x02C343);
		private static readonly ROMAddress _overworldMusicMasterSword = new ROMAddress(0x02C383, 0x02C383);
		private static readonly ROMAddress _overworldMusicAgahim = new ROMAddress(0x02C3C3, 0x02C3C3);
		private static readonly ROMAddress _overworldMusicDW = new ROMAddress(0x02C403, 0x02C403);
		private static readonly ROMAddress _overworldEntranceAllowedTilesLeft = new ROMAddress(0x1BB8C1, 0x1BB8C1);
		private static readonly ROMAddress _overworldEntranceAllowedTilesRight = new ROMAddress(0x1BB917, 0x1BB917);
		private static readonly ROMAddress _overworldMapSize = new ROMAddress(0x02A73B, 0x02A844);
		private static readonly ROMAddress _overworldMapSizeHighByte = new ROMAddress(0x02A884, 0x02A884);
		private static readonly ROMAddress _overworldMapParentId = new ROMAddress(0x02A5EC, 0x02A5EC);
		private static readonly ROMAddress _overworldTransitionPositionY = new ROMAddress(0x02A8C4, 0x02A8C4);
		private static readonly ROMAddress _overworldTransitionPositionX = new ROMAddress(0x02A944, 0x02A944);
		private static readonly ROMAddress _overworldScreenSize = new ROMAddress(0x02F88D, 0x02F88D);
		private static readonly ROMAddress _OverworldScreenSizeForLoading = new ROMAddress(0x09C635, 0x09C635);
		private static readonly ROMAddress _OverworldScreenTileMapChangeByScreen = new ROMAddress(0x02A634, 0x02A634);
		private static readonly ROMAddress _transition_target_north = new ROMAddress(0x02BEE2, 0x02BEE2);
		private static readonly ROMAddress _transition_target_west = new ROMAddress(0x02BF62, 0x02BF62);
		private static readonly ROMAddress _OWExitRoomId = new ROMAddress(0x02DAEE, 0x02DD8A);
		private static readonly ROMAddress _OWExitMapId = new ROMAddress(0x02DB8C, 0x02DE28);
		private static readonly ROMAddress _OWExitVram = new ROMAddress(0x02DBDB, 0x02DE77);
		private static readonly ROMAddress _OWExitYScroll = new ROMAddress(0x02DC79, 0x02DF15);
		private static readonly ROMAddress _OWExitXScroll = new ROMAddress(0x02DD17, 0x02DFB3);
		private static readonly ROMAddress _OWExitYPlayer = new ROMAddress(0x02DDB5, 0x02E051);
		private static readonly ROMAddress _OWExitXPlayer = new ROMAddress(0x02DE53, 0x02E0EF);
		private static readonly ROMAddress _OWExitYCamera = new ROMAddress(0x02DEF1, 0x02E18D);
		private static readonly ROMAddress _OWExitXCamera = new ROMAddress(0x02DF8F, 0x02E22B);
		private static readonly ROMAddress _OWExitDoorPosition = new ROMAddress(0x02D724, 0x02D724);
		private static readonly ROMAddress _OWExitUnk1 = new ROMAddress(0x02E02D, 0x02E2C9);
		private static readonly ROMAddress _OWExitUnk2 = new ROMAddress(0x02E07C, 0x02E318);
		private static readonly ROMAddress _OWExitDoorType1 = new ROMAddress(0x02E0CB, 0x02E367);
		private static readonly ROMAddress _OWExitDoorType2 = new ROMAddress(0x02E169, 0x02E405);
		private static readonly ROMAddress _OWEntranceMap = new ROMAddress(0x1BB96F, 0x1BB96F);
		private static readonly ROMAddress _OWEntrancePos = new ROMAddress(0x1BBA71, 0x1BBA71);
		private static readonly ROMAddress _OWEntranceEntranceId = new ROMAddress(0x1BBB73, 0x1BBB73);
		private static readonly ROMAddress _OWHolePos = new ROMAddress(0x1BB800, 0x1BB800);
		private static readonly ROMAddress _OWHoleArea = new ROMAddress(0x1BB826, 0x1BB826);
		private static readonly ROMAddress _OWHoleEntrance = new ROMAddress(0x1BB84C, 0x1BB84C);
		private static readonly ROMAddress _OWExitMapIdWhirlpool = new ROMAddress(0x02EAE5, 0x02EAE5);
		private static readonly ROMAddress _OWExitVramWhirlpool = new ROMAddress(0x02EB07, 0x02EB07);
		private static readonly ROMAddress _OWExitYScrollWhirlpool = new ROMAddress(0x02EB29, 0x02EB29);
		private static readonly ROMAddress _OWExitXScrollWhirlpool = new ROMAddress(0x02EB4B, 0x02EB4B);
		private static readonly ROMAddress _OWExitYPlayerWhirlpool = new ROMAddress(0x02EB6D, 0x02EB6D);
		private static readonly ROMAddress _OWExitXPlayerWhirlpool = new ROMAddress(0x02EB8F, 0x02EB8F);
		private static readonly ROMAddress _OWExitYCameraWhirlpool = new ROMAddress(0x02EBB1, 0x02EBB1);
		private static readonly ROMAddress _OWExitXCameraWhirlpool = new ROMAddress(0x02EBD3, 0x02EBD3);
		private static readonly ROMAddress _OWExitUnk1Whirlpool = new ROMAddress(0x02EBF5, 0x02EBF5);
		private static readonly ROMAddress _OWExitUnk2Whirlpool = new ROMAddress(0x02EC17, 0x02EC17);
		private static readonly ROMAddress _OWWhirlpoolPosition = new ROMAddress(0x02ECF8, 0x02ECF8);
		private static readonly ROMAddress _dungeons_palettes_groups = new ROMAddress(0x0CFDD0, 0x0ED460);
		private static readonly ROMAddress _dungeons_main_bg_palette_pointers = new ROMAddress(0x1BEC4B, 0x1BEC4B);
		private static readonly ROMAddress _dungeons_palettes = new ROMAddress(0x1BD734, 0x1BD734);
		private static readonly ROMAddress _room_items_pointers = new ROMAddress(0x01DB67, 0x01DB69);
		private static readonly ROMAddress _rooms_sprite_pointer = new ROMAddress(0x09C298, 0x09C298);
		private static readonly ROMAddress _room_header_pointer = new ROMAddress(0x01B5DD, 0x01B5DD);
		private static readonly ROMAddress _room_header_pointers_bank = new ROMAddress(0x01B5E7, 0x01B5E7);
		private static readonly ROMAddress _gfx_groups_pointer = new ROMAddress(0x00E277, 0x00E237);
		private static readonly ROMAddress _room_object_layout_pointer = new ROMAddress(0x01882D, 0x01882D);
		private static readonly ROMAddress _room_object_pointer = new ROMAddress(0x01874C, 0x01874C);
		private static readonly ROMAddress _chests_length_pointer = new ROMAddress(0x01EBF4, 0x01EBF6);
		private static readonly ROMAddress _chests_data_pointer1 = new ROMAddress(0x01EBF9, 0x01EBFB);
		private static readonly ROMAddress _chests_data_pointer2 = new ROMAddress(0x01EC0A, 0x01EC0A);
		private static readonly ROMAddress _chests_data_pointer3 = new ROMAddress(0x01EC10, 0x01EC10);
		private static readonly ROMAddress _blocks_length = new ROMAddress(0x018896, 0x018896);
		private static readonly ROMAddress _blocks_pointer1 = new ROMAddress(0x02D85E, 0x02DAFA);
		private static readonly ROMAddress _blocks_pointer2 = new ROMAddress(0x02D865, 0x02DB01);
		private static readonly ROMAddress _blocks_pointer3 = new ROMAddress(0x02D86C, 0x02DB08);
		private static readonly ROMAddress _blocks_pointer4 = new ROMAddress(0x02D873, 0x02DB0F);
		private static readonly ROMAddress _torch_data = new ROMAddress(0x04F04A, 0x04F36A);
		private static readonly ROMAddress _torches_length_pointer = new ROMAddress(0x0188C1, 0x0188C1);
		private static readonly ROMAddress _sprite_blockset_pointer = new ROMAddress(0x00DB97, 0x00DB57);
		private static readonly ROMAddress _sprites_data = new ROMAddress(0x09D8B0, 0x09D8B0);
		private static readonly ROMAddress _sprites_data_empty_room = new ROMAddress(0x09D8AE, 0x09D8AE);
		private static readonly ROMAddress _sprites_end_data = new ROMAddress(0x09EC9E, 0x09EC9E);
		private static readonly ROMAddress _pit_pointer = new ROMAddress(0x0794A2, 0x0794AB);
		private static readonly ROMAddress _pit_count = new ROMAddress(0x07949D, 0x0794A6);
		private static readonly ROMAddress _doorPointers = new ROMAddress(0x1F83C0, 0x1F83C0);
		private static readonly ROMAddress _door_gfx_up = new ROMAddress(0x00CD9E, 0x00CD9E);
		private static readonly ROMAddress _door_gfx_down = new ROMAddress(0x00CE06, 0x00CE06);
		private static readonly ROMAddress _door_gfx_left = new ROMAddress(0x00CE66, 0x00CE66);
		private static readonly ROMAddress _door_gfx_right = new ROMAddress(0x00CEC6, 0x00CEC6);
		private static readonly ROMAddress _door_pos_up = new ROMAddress(0x00997E, 0x00997E);
		private static readonly ROMAddress _door_pos_down = new ROMAddress(0x009996, 0x009996);
		private static readonly ROMAddress _door_pos_left = new ROMAddress(0x0099AE, 0x0099AE);
		private static readonly ROMAddress _door_pos_right = new ROMAddress(0x0099C6, 0x0099C6);
		private static readonly ROMAddress _gfx_font = new ROMAddress(0x0E8000, 0x0E8000);
		private static readonly ROMAddress _text_data = new ROMAddress(0x1C8000, 0x1C8000);
		private static readonly ROMAddress _text_data2 = new ROMAddress(0x0EDF40, 0x0EDF40);
		private static readonly ROMAddress _pointers_dictionaries = new ROMAddress(0x0EC703, 0x0EC703);
		private static readonly ROMAddress _characters_width = new ROMAddress(0x0ECADF, 0x0ECADF);
		private static readonly ROMAddress _entrance_room = new ROMAddress(0x02C577, 0x02C813);
		private static readonly ROMAddress _entrance_scrolledge = new ROMAddress(0x02C91D, 0x02C91D);
		private static readonly ROMAddress _entrance_cameray = new ROMAddress(0x02CBB3, 0x02CD45);
		private static readonly ROMAddress _entrance_camerax = new ROMAddress(0x02CAA9, 0x02CE4F);
		private static readonly ROMAddress _entrance_yposition = new ROMAddress(0x02CCBD, 0x02CF59);
		private static readonly ROMAddress _entrance_xposition = new ROMAddress(0x02CDC7, 0x02D063);
		private static readonly ROMAddress _entrance_cameraytrigger = new ROMAddress(0x02CED1, 0x02D16D);
		private static readonly ROMAddress _entrance_cameraxtrigger = new ROMAddress(0x02CFDB, 0x02D277);
		private static readonly ROMAddress _entrance_blockset = new ROMAddress(0x02D0E5, 0x02D381);
		private static readonly ROMAddress _entrance_floor = new ROMAddress(0x02D16A, 0x02D406);
		private static readonly ROMAddress _entrance_dungeon = new ROMAddress(0x02D1EF, 0x02D48B);
		private static readonly ROMAddress _entrance_door = new ROMAddress(0x02D274, 0x02D510);
		private static readonly ROMAddress _entrance_ladderbg = new ROMAddress(0x02D2F9, 0x02D595);
		private static readonly ROMAddress _entrance_scrolling = new ROMAddress(0x02D37E, 0x02D61A);
		private static readonly ROMAddress _entrance_scrollquadrant = new ROMAddress(0x02D403, 0x02D69F);
		private static readonly ROMAddress _entrance_exit = new ROMAddress(0x02D488, 0x02D724);
		private static readonly ROMAddress _entrance_music = new ROMAddress(0x02D592, 0x02D82E);
		private static readonly ROMAddress _startingentrance_room = new ROMAddress(0x02D8D2, 0x02DB6E);
		private static readonly ROMAddress _startingentrance_scrolledge = new ROMAddress(0x02D8E0, 0x02DB7C);
		private static readonly ROMAddress _startingentrance_cameray = new ROMAddress(0x02D918, 0x02DBB4);
		private static readonly ROMAddress _startingentrance_camerax = new ROMAddress(0x02D926, 0x02DBC2);
		private static readonly ROMAddress _startingentrance_yposition = new ROMAddress(0x02D934, 0x02DBD0);
		private static readonly ROMAddress _startingentrance_xposition = new ROMAddress(0x02D942, 0x02DBDE);
		private static readonly ROMAddress _startingentrance_cameraytrigger = new ROMAddress(0x02D950, 0x02DBEC);
		private static readonly ROMAddress _startingentrance_cameraxtrigger = new ROMAddress(0x02D95E, 0x02DBFA);
		private static readonly ROMAddress _startingentrance_blockset = new ROMAddress(0x02D96C, 0x02DC08);
		private static readonly ROMAddress _startingentrance_floor = new ROMAddress(0x02D973, 0x02DC0F);
		private static readonly ROMAddress _startingentrance_dungeon = new ROMAddress(0x02D97A, 0x02DC16);
		private static readonly ROMAddress _startingentrance_door = new ROMAddress(0x02D98F, 0x02DC2B);
		private static readonly ROMAddress _startingentrance_ladderbg = new ROMAddress(0x02D981, 0x02DC1D);
		private static readonly ROMAddress _startingentrance_scrolling = new ROMAddress(0x02D988, 0x02DC24);
		private static readonly ROMAddress _startingentrance_scrollquadrant = new ROMAddress(0x02D98F, 0x02DC2B);
		private static readonly ROMAddress _startingentrance_exit = new ROMAddress(0x02D996, 0x02DC32);
		private static readonly ROMAddress _startingentrance_music = new ROMAddress(0x02D9B2, 0x02DC4E);
		private static readonly ROMAddress _startingentrance_entrance = new ROMAddress(0x02D9A4, 0x02DC40);
		private static readonly ROMAddress _items_data_start = new ROMAddress(0x01DDE7, 0x01DDE9);
		private static readonly ROMAddress _items_data_end = new ROMAddress(0x01E6B0, 0x01E6B2);
		private static readonly ROMAddress _initial_equipement = new ROMAddress(0x04F1A6, 0x04F1A6);
		private static readonly ROMAddress _messages_id_dungeon = new ROMAddress(0x07F5F7, 0x07F61D);
		private static readonly ROMAddress _chests_backupitems = new ROMAddress(0x07B528, 0x07B528);
		private static readonly ROMAddress _chests_yoffset = new ROMAddress(0x09836C, 0x09836C);
		private static readonly ROMAddress _chests_xoffset = new ROMAddress(0x0983B8, 0x0983B8);
		private static readonly ROMAddress _chests_itemsgfx = new ROMAddress(0x098404, 0x098404);
		private static readonly ROMAddress _chests_itemswide = new ROMAddress(0x098450, 0x098450);
		private static readonly ROMAddress _chests_itemsproperties = new ROMAddress(0x09849C, 0x09849C);
		private static readonly ROMAddress _chests_sramaddress = new ROMAddress(0x0984E8, 0x0984E8);
		private static readonly ROMAddress _chests_sramvalue = new ROMAddress(0x098580, 0x098580);
		private static readonly ROMAddress _chests_msgid = new ROMAddress(0x08C2DD, 0x08C2DD);
		private static readonly ROMAddress _dungeons_startrooms = new ROMAddress(0x00F939, 0x00F939);
		private static readonly ROMAddress _dungeons_endrooms = new ROMAddress(0x00F92D, 0x00F92D);
		private static readonly ROMAddress _dungeons_bossrooms = new ROMAddress(0x028954, 0x028954);
		private static readonly ROMAddress _bedPositionX = new ROMAddress(0x079A37, 0x079A37);
		private static readonly ROMAddress _bedPositionY = new ROMAddress(0x079A32, 0x079A32);
		private static readonly ROMAddress _bedPositionResetXLow = new ROMAddress(0x05DE53, 0x05DE53);
		private static readonly ROMAddress _bedPositionResetXHigh = new ROMAddress(0x05DE58, 0x05DE58);
		private static readonly ROMAddress _bedPositionResetYLow = new ROMAddress(0x05DE5D, 0x05DE5D);
		private static readonly ROMAddress _bedPositionResetYHigh = new ROMAddress(0x05DE62, 0x05DE62);
		private static readonly ROMAddress _bedSheetPositionX = new ROMAddress(0x0980BD, 0x0980BD);
		private static readonly ROMAddress _bedSheetPositionY = new ROMAddress(0x0980B8, 0x0980B8);
		private static readonly ROMAddress _GravesYTilePos = new ROMAddress(0x099968, 0x099968);
		private static readonly ROMAddress _GravesXTilePos = new ROMAddress(0x099986, 0x099986);
		private static readonly ROMAddress _GravesTilemapPos = new ROMAddress(0x0999A4, 0x0999A4);
		private static readonly ROMAddress _GravesGFX = new ROMAddress(0x0999C2, 0x0999C2);
		private static readonly ROMAddress _GravesXPos = new ROMAddress(0x09994A, 0x09994A);
		private static readonly ROMAddress _GravesYLine = new ROMAddress(0x09993A, 0x09993A);
		private static readonly ROMAddress _GravesCountOnY = new ROMAddress(0x0999E0, 0x0999E0);
		private static readonly ROMAddress _GraveLinkSpecialHole = new ROMAddress(0x08EDD9, 0x08EDD9);
		private static readonly ROMAddress _GraveLinkSpecialStairs = new ROMAddress(0x08EDE0, 0x08EDE0);
		private static readonly ROMAddress _overworldPaletteMain = new ROMAddress(0x1BE6C8, 0x1BE6C8);
		private static readonly ROMAddress _overworldPaletteAuxialiary = new ROMAddress(0x1BE86C, 0x1BE86C);
		private static readonly ROMAddress _overworldPaletteAnimated = new ROMAddress(0x1BE604, 0x1BE604);
		private static readonly ROMAddress _globalSpritePalettesLW = new ROMAddress(0x1BD218, 0x1BD218);
		private static readonly ROMAddress _globalSpritePalettesDW = new ROMAddress(0x1BD290, 0x1BD290);
		private static readonly ROMAddress _armorPalettes = new ROMAddress(0x1BD308, 0x1BD308);
		private static readonly ROMAddress _spritePalettesAux1 = new ROMAddress(0x1BD39E, 0x1BD39E);
		private static readonly ROMAddress _spritePalettesAux2 = new ROMAddress(0x1BD446, 0x1BD446);
		private static readonly ROMAddress _spritePalettesAux3 = new ROMAddress(0x1BD4E0, 0x1BD4E0);
		private static readonly ROMAddress _swordPalettes = new ROMAddress(0x1BD630, 0x1BD630);
		private static readonly ROMAddress _shieldPalettes = new ROMAddress(0x1BD648, 0x1BD648);
		private static readonly ROMAddress _hudPalettes = new ROMAddress(0x1BD660, 0x1BD660);
		private static readonly ROMAddress _dungeonMapPalettes = new ROMAddress(0x1BD70A, 0x1BD70A);
		private static readonly ROMAddress _dungeonMainPalettes = new ROMAddress(0x1BD734, 0x1BD734);
		private static readonly ROMAddress _dungeonMapBgPalettes = new ROMAddress(0x1BE544, 0x1BE544);
		private static readonly ROMAddress _hardcodedGrassLW = new ROMAddress(0x0CFFE6, 0x0BFEA9);
		private static readonly ROMAddress _hardcodedGrassDW = new ROMAddress(0x0CFFF0, 0x0BFEB3);
		private static readonly ROMAddress _hardcodedGrassSpecial = new ROMAddress(0x0CFFE1, 0x0ED640);
		private static readonly ROMAddress _dungeonMap_rooms_ptr = new ROMAddress(0x0AF605, 0x0AF605);
		private static readonly ROMAddress _dungeonMap_floors = new ROMAddress(0x0AF5D9, 0x0AF5D9);
		private static readonly ROMAddress _dungeonMap_gfx_ptr = new ROMAddress(0x0AFBE4, 0x0AFBE4);
		private static readonly ROMAddress _dungeonMap_datastart = new ROMAddress(0x0AF039, 0x0AF039);
		private static readonly ROMAddress _dungeonMap_expCheck = new ROMAddress(0x0AE652, 0x0AE652);
		private static readonly ROMAddress _dungeonMap_tile16 = new ROMAddress(0x0AF009, 0x0AF009);
		private static readonly ROMAddress _dungeonMap_tile16Exp = new ROMAddress(0x219010, 0x219010);
		private static readonly ROMAddress _dungeonMap_bossrooms = new ROMAddress(0x0AE807, 0x0AE807);
		private static readonly ROMAddress _triforceVertices = new ROMAddress(0x09FFD2, 0x09FFD2);
		private static readonly ROMAddress _TriforceFaces = new ROMAddress(0x09FFE4, 0x09FFE4);
		private static readonly ROMAddress _crystalVertices = new ROMAddress(0x09FF98, 0x09FF98);


		public int tile_address { get; }
		public int tile_address_floor { get; }
		public int Subytype1TileDataPointers { get; }
		public int Subtype2TileDataPointers { get; }
		public int Subtype3TileDataPointers { get; }
		public int gfx_animated_pointer { get; }
		public int overworldgfxGroups2 { get; }
		public int gfx_1_pointer { get; }
		public int gfx_2_pointer { get; }
		public int gfx_3_pointer { get; }
		public int maxGfx { get; }
		public int compressedAllMap32PointersHigh { get; }
		public int compressedAllMap32PointersLow { get; }
		public int overworldgfxGroups { get; }
		public int map16Tiles { get; }
		public int Map32DefinitionsTL { get; }
		public int Map32DefinitionsTR { get; }
		public int Map32DefinitionsBL { get; }
		public int Map32DefinitionsBR { get; }
		public int overworldPalGroup1 { get; }
		public int overworldPalGroup2 { get; }
		public int overworldPalGroup3 { get; }
		public int overworldMapPalette { get; }
		public int overworldSpritePalette { get; }
		public int overworldMapPaletteGroup { get; }
		public int overworldSpritePaletteGroup { get; }
		public int overworldSpriteset { get; }
		public int overworldSpecialGFXGroup { get; }
		public int overworldSpecialPALGroup { get; }
		public int OverworldSpritesTableState0 { get; }
		public int OverworldSpritesTableState3 { get; }
		public int OverworldSpritesTableState2 { get; }
		public int overworldItemsPointers { get; }
		public int overworldItemsAddress { get; }
		public int overworldItemsBank { get; }
		public int overworldItemsEndData { get; }
		public int mapGfx { get; }
		public int overlayPointers { get; }
		public int overlayPointersBank { get; }
		public int overworldTilesType { get; }
		public int overworldMessages { get; }
		public int overworldMusicBegining { get; }
		public int overworldMusicZelda { get; }
		public int overworldMusicMasterSword { get; }
		public int overworldMusicAgahim { get; }
		public int overworldMusicDW { get; }
		public int overworldEntranceAllowedTilesLeft { get; }
		public int overworldEntranceAllowedTilesRight { get; }
		public int overworldMapSize { get; }
		public int overworldMapSizeHighByte { get; }
		public int overworldMapParentId { get; }
		public int overworldTransitionPositionY { get; }
		public int overworldTransitionPositionX { get; }
		public int overworldScreenSize { get; }
		public int OverworldScreenSizeForLoading { get; }
		public int OverworldScreenTileMapChangeByScreen { get; }
		public int transition_target_north { get; }
		public int transition_target_west { get; }
		public int OWExitRoomId { get; }
		public int OWExitMapId { get; }
		public int OWExitVram { get; }
		public int OWExitYScroll { get; }
		public int OWExitXScroll { get; }
		public int OWExitYPlayer { get; }
		public int OWExitXPlayer { get; }
		public int OWExitYCamera { get; }
		public int OWExitXCamera { get; }
		public int OWExitDoorPosition { get; }
		public int OWExitUnk1 { get; }
		public int OWExitUnk2 { get; }
		public int OWExitDoorType1 { get; }
		public int OWExitDoorType2 { get; }
		public int OWEntranceMap { get; }
		public int OWEntrancePos { get; }
		public int OWEntranceEntranceId { get; }
		public int OWHolePos { get; }
		public int OWHoleArea { get; }
		public int OWHoleEntrance { get; }
		public int OWExitMapIdWhirlpool { get; }
		public int OWExitVramWhirlpool { get; }
		public int OWExitYScrollWhirlpool { get; }
		public int OWExitXScrollWhirlpool { get; }
		public int OWExitYPlayerWhirlpool { get; }
		public int OWExitXPlayerWhirlpool { get; }
		public int OWExitYCameraWhirlpool { get; }
		public int OWExitXCameraWhirlpool { get; }
		public int OWExitUnk1Whirlpool { get; }
		public int OWExitUnk2Whirlpool { get; }
		public int OWWhirlpoolPosition { get; }
		public int dungeons_palettes_groups { get; }
		public int dungeons_main_bg_palette_pointers { get; }
		public int dungeons_palettes { get; }
		public int room_items_pointers { get; }
		public int rooms_sprite_pointer { get; }
		public int room_header_pointer { get; }
		public int room_header_pointers_bank { get; }
		public int gfx_groups_pointer { get; }
		public int room_object_layout_pointer { get; }
		public int room_object_pointer { get; }
		public int chests_length_pointer { get; }
		public int chests_data_pointer1 { get; }
		public int chests_data_pointer2 { get; }
		public int chests_data_pointer3 { get; }
		public int blocks_length { get; }
		public int blocks_pointer1 { get; }
		public int blocks_pointer2 { get; }
		public int blocks_pointer3 { get; }
		public int blocks_pointer4 { get; }
		public int torch_data { get; }
		public int torches_length_pointer { get; }
		public int sprite_blockset_pointer { get; }
		public int sprites_data { get; }
		public int sprites_data_empty_room { get; }
		public int sprites_end_data { get; }
		public int pit_pointer { get; }
		public int pit_count { get; }
		public int doorPointers { get; }
		public int door_gfx_up { get; }
		public int door_gfx_down { get; }
		public int door_gfx_left { get; }
		public int door_gfx_right { get; }
		public int door_pos_up { get; }
		public int door_pos_down { get; }
		public int door_pos_left { get; }
		public int door_pos_right { get; }
		public int gfx_font { get; }
		public int text_data { get; }
		public int text_data2 { get; }
		public int pointers_dictionaries { get; }
		public int characters_width { get; }
		public int entrance_room { get; }
		public int entrance_scrolledge { get; }
		public int entrance_cameray { get; }
		public int entrance_camerax { get; }
		public int entrance_yposition { get; }
		public int entrance_xposition { get; }
		public int entrance_cameraytrigger { get; }
		public int entrance_cameraxtrigger { get; }
		public int entrance_blockset { get; }
		public int entrance_floor { get; }
		public int entrance_dungeon { get; }
		public int entrance_door { get; }
		public int entrance_ladderbg { get; }
		public int entrance_scrolling { get; }
		public int entrance_scrollquadrant { get; }
		public int entrance_exit { get; }
		public int entrance_music { get; }
		public int startingentrance_room { get; }
		public int startingentrance_scrolledge { get; }
		public int startingentrance_cameray { get; }
		public int startingentrance_camerax { get; }
		public int startingentrance_yposition { get; }
		public int startingentrance_xposition { get; }
		public int startingentrance_cameraytrigger { get; }
		public int startingentrance_cameraxtrigger { get; }
		public int startingentrance_blockset { get; }
		public int startingentrance_floor { get; }
		public int startingentrance_dungeon { get; }
		public int startingentrance_door { get; }
		public int startingentrance_ladderbg { get; }
		public int startingentrance_scrolling { get; }
		public int startingentrance_scrollquadrant { get; }
		public int startingentrance_exit { get; }
		public int startingentrance_music { get; }
		public int startingentrance_entrance { get; }
		public int items_data_start { get; }
		public int items_data_end { get; }
		public int initial_equipement { get; }
		public int messages_id_dungeon { get; }
		public int chests_backupitems { get; }
		public int chests_yoffset { get; }
		public int chests_xoffset { get; }
		public int chests_itemsgfx { get; }
		public int chests_itemswide { get; }
		public int chests_itemsproperties { get; }
		public int chests_sramaddress { get; }
		public int chests_sramvalue { get; }
		public int chests_msgid { get; }
		public int dungeons_startrooms { get; }
		public int dungeons_endrooms { get; }
		public int dungeons_bossrooms { get; }
		public int bedPositionX { get; }
		public int bedPositionY { get; }
		public int bedPositionResetXLow { get; }
		public int bedPositionResetXHigh { get; }
		public int bedPositionResetYLow { get; }
		public int bedPositionResetYHigh { get; }
		public int bedSheetPositionX { get; }
		public int bedSheetPositionY { get; }
		public int GravesYTilePos { get; }
		public int GravesXTilePos { get; }
		public int GravesTilemapPos { get; }
		public int GravesGFX { get; }
		public int GravesXPos { get; }
		public int GravesYLine { get; }
		public int GravesCountOnY { get; }
		public int GraveLinkSpecialHole { get; }
		public int GraveLinkSpecialStairs { get; }
		public int overworldPaletteMain { get; }
		public int overworldPaletteAuxialiary { get; }
		public int overworldPaletteAnimated { get; }
		public int globalSpritePalettesLW { get; }
		public int globalSpritePalettesDW { get; }
		public int armorPalettes { get; }
		public int spritePalettesAux1 { get; }
		public int spritePalettesAux2 { get; }
		public int spritePalettesAux3 { get; }
		public int swordPalettes { get; }
		public int shieldPalettes { get; }
		public int hudPalettes { get; }
		public int dungeonMapPalettes { get; }
		public int dungeonMainPalettes { get; }
		public int dungeonMapBgPalettes { get; }
		public int hardcodedGrassLW { get; }
		public int hardcodedGrassDW { get; }
		public int hardcodedGrassSpecial { get; }
		public int dungeonMap_rooms_ptr { get; }
		public int dungeonMap_floors { get; }
		public int dungeonMap_gfx_ptr { get; }
		public int dungeonMap_datastart { get; }
		public int dungeonMap_expCheck { get; }
		public int dungeonMap_tile16 { get; }
		public int dungeonMap_tile16Exp { get; }
		public int dungeonMap_bossrooms { get; }
		public int triforceVertices { get; }
		public int TriforceFaces { get; }
		public int crystalVertices { get; }

		public AddressSet(SNESFunctions.ROMVersion version)
		{
			tile_address = _tile_address.GetOffsetForVersion(version);
			tile_address_floor = _tile_address_floor.GetOffsetForVersion(version);
			Subytype1TileDataPointers = _subtype1_tiles.GetOffsetForVersion(version);
			Subtype2TileDataPointers = _subtype2_tiles.GetOffsetForVersion(version);
			Subtype3TileDataPointers = _subtype3_tiles.GetOffsetForVersion(version);
			gfx_animated_pointer = _gfx_animated_pointer.GetOffsetForVersion(version);
			overworldgfxGroups2 = _overworldgfxGroups2.GetOffsetForVersion(version);
			gfx_1_pointer = _gfx_1_pointer.GetOffsetForVersion(version);
			gfx_2_pointer = _gfx_2_pointer.GetOffsetForVersion(version);
			gfx_3_pointer = _gfx_3_pointer.GetOffsetForVersion(version);
			maxGfx = _maxGfx.GetOffsetForVersion(version);
			compressedAllMap32PointersHigh = _compressedAllMap32PointersHigh.GetOffsetForVersion(version);
			compressedAllMap32PointersLow = _compressedAllMap32PointersLow.GetOffsetForVersion(version);
			overworldgfxGroups = _overworldgfxGroups.GetOffsetForVersion(version);
			map16Tiles = _map16Tiles.GetOffsetForVersion(version);
			Map32DefinitionsTL = _Map32DefinitionsTL.GetOffsetForVersion(version);
			Map32DefinitionsTR = _Map32DefinitionsTR.GetOffsetForVersion(version);
			Map32DefinitionsBL = _Map32DefinitionsBL.GetOffsetForVersion(version);
			Map32DefinitionsBR = _Map32DefinitionsBR.GetOffsetForVersion(version);
			overworldPalGroup1 = _overworldPalGroup1.GetOffsetForVersion(version);
			overworldPalGroup2 = _overworldPalGroup2.GetOffsetForVersion(version);
			overworldPalGroup3 = _overworldPalGroup3.GetOffsetForVersion(version);
			overworldMapPalette = _overworldMapPalette.GetOffsetForVersion(version);
			overworldSpritePalette = _overworldSpritePalette.GetOffsetForVersion(version);
			overworldMapPaletteGroup = _overworldMapPaletteGroup.GetOffsetForVersion(version);
			overworldSpritePaletteGroup = _overworldSpritePaletteGroup.GetOffsetForVersion(version);
			overworldSpriteset = _overworldSpriteset.GetOffsetForVersion(version);
			overworldSpecialGFXGroup = _overworldSpecialGFXGroup.GetOffsetForVersion(version);
			overworldSpecialPALGroup = _overworldSpecialPALGroup.GetOffsetForVersion(version);
			OverworldSpritesTableState0 = _OverworldSpritesTableState0.GetOffsetForVersion(version);
			OverworldSpritesTableState3 = _OverworldSpritesTableState3.GetOffsetForVersion(version);
			OverworldSpritesTableState2 = _OverworldSpritesTableState2.GetOffsetForVersion(version);
			overworldItemsPointers = _overworldItemsPointers.GetOffsetForVersion(version);
			overworldItemsAddress = _overworldItemsAddress.GetOffsetForVersion(version);
			overworldItemsBank = _overworldItemsBank.GetOffsetForVersion(version);
			overworldItemsEndData = _overworldItemsEndData.GetOffsetForVersion(version);
			mapGfx = _mapGfx.GetOffsetForVersion(version);
			overlayPointers = _overlayPointers.GetOffsetForVersion(version);
			overlayPointersBank = _overlayPointersBank.GetOffsetForVersion(version);
			overworldTilesType = _overworldTilesType.GetOffsetForVersion(version);
			overworldMessages = _overworldMessages.GetOffsetForVersion(version);
			overworldMusicBegining = _overworldMusicBegining.GetOffsetForVersion(version);
			overworldMusicZelda = _overworldMusicZelda.GetOffsetForVersion(version);
			overworldMusicMasterSword = _overworldMusicMasterSword.GetOffsetForVersion(version);
			overworldMusicAgahim = _overworldMusicAgahim.GetOffsetForVersion(version);
			overworldMusicDW = _overworldMusicDW.GetOffsetForVersion(version);
			overworldEntranceAllowedTilesLeft = _overworldEntranceAllowedTilesLeft.GetOffsetForVersion(version);
			overworldEntranceAllowedTilesRight = _overworldEntranceAllowedTilesRight.GetOffsetForVersion(version);
			overworldMapSize = _overworldMapSize.GetOffsetForVersion(version);
			overworldMapSizeHighByte = _overworldMapSizeHighByte.GetOffsetForVersion(version);
			overworldMapParentId = _overworldMapParentId.GetOffsetForVersion(version);
			overworldTransitionPositionY = _overworldTransitionPositionY.GetOffsetForVersion(version);
			overworldTransitionPositionX = _overworldTransitionPositionX.GetOffsetForVersion(version);
			overworldScreenSize = _overworldScreenSize.GetOffsetForVersion(version);
			OverworldScreenSizeForLoading = _OverworldScreenSizeForLoading.GetOffsetForVersion(version);
			OverworldScreenTileMapChangeByScreen = _OverworldScreenTileMapChangeByScreen.GetOffsetForVersion(version);
			transition_target_north = _transition_target_north.GetOffsetForVersion(version);
			transition_target_west = _transition_target_west.GetOffsetForVersion(version);
			OWExitRoomId = _OWExitRoomId.GetOffsetForVersion(version);
			OWExitMapId = _OWExitMapId.GetOffsetForVersion(version);
			OWExitVram = _OWExitVram.GetOffsetForVersion(version);
			OWExitYScroll = _OWExitYScroll.GetOffsetForVersion(version);
			OWExitXScroll = _OWExitXScroll.GetOffsetForVersion(version);
			OWExitYPlayer = _OWExitYPlayer.GetOffsetForVersion(version);
			OWExitXPlayer = _OWExitXPlayer.GetOffsetForVersion(version);
			OWExitYCamera = _OWExitYCamera.GetOffsetForVersion(version);
			OWExitXCamera = _OWExitXCamera.GetOffsetForVersion(version);
			OWExitDoorPosition = _OWExitDoorPosition.GetOffsetForVersion(version);
			OWExitUnk1 = _OWExitUnk1.GetOffsetForVersion(version);
			OWExitUnk2 = _OWExitUnk2.GetOffsetForVersion(version);
			OWExitDoorType1 = _OWExitDoorType1.GetOffsetForVersion(version);
			OWExitDoorType2 = _OWExitDoorType2.GetOffsetForVersion(version);
			OWEntranceMap = _OWEntranceMap.GetOffsetForVersion(version);
			OWEntrancePos = _OWEntrancePos.GetOffsetForVersion(version);
			OWEntranceEntranceId = _OWEntranceEntranceId.GetOffsetForVersion(version);
			OWHolePos = _OWHolePos.GetOffsetForVersion(version);
			OWHoleArea = _OWHoleArea.GetOffsetForVersion(version);
			OWHoleEntrance = _OWHoleEntrance.GetOffsetForVersion(version);
			OWExitMapIdWhirlpool = _OWExitMapIdWhirlpool.GetOffsetForVersion(version);
			OWExitVramWhirlpool = _OWExitVramWhirlpool.GetOffsetForVersion(version);
			OWExitYScrollWhirlpool = _OWExitYScrollWhirlpool.GetOffsetForVersion(version);
			OWExitXScrollWhirlpool = _OWExitXScrollWhirlpool.GetOffsetForVersion(version);
			OWExitYPlayerWhirlpool = _OWExitYPlayerWhirlpool.GetOffsetForVersion(version);
			OWExitXPlayerWhirlpool = _OWExitXPlayerWhirlpool.GetOffsetForVersion(version);
			OWExitYCameraWhirlpool = _OWExitYCameraWhirlpool.GetOffsetForVersion(version);
			OWExitXCameraWhirlpool = _OWExitXCameraWhirlpool.GetOffsetForVersion(version);
			OWExitUnk1Whirlpool = _OWExitUnk1Whirlpool.GetOffsetForVersion(version);
			OWExitUnk2Whirlpool = _OWExitUnk2Whirlpool.GetOffsetForVersion(version);
			OWWhirlpoolPosition = _OWWhirlpoolPosition.GetOffsetForVersion(version);
			dungeons_palettes_groups = _dungeons_palettes_groups.GetOffsetForVersion(version);
			dungeons_main_bg_palette_pointers = _dungeons_main_bg_palette_pointers.GetOffsetForVersion(version);
			dungeons_palettes = _dungeons_palettes.GetOffsetForVersion(version);
			room_items_pointers = _room_items_pointers.GetOffsetForVersion(version);
			rooms_sprite_pointer = _rooms_sprite_pointer.GetOffsetForVersion(version);
			room_header_pointer = _room_header_pointer.GetOffsetForVersion(version);
			room_header_pointers_bank = _room_header_pointers_bank.GetOffsetForVersion(version);
			gfx_groups_pointer = _gfx_groups_pointer.GetOffsetForVersion(version);
			room_object_layout_pointer = _room_object_layout_pointer.GetOffsetForVersion(version);
			room_object_pointer = _room_object_pointer.GetOffsetForVersion(version);
			chests_length_pointer = _chests_length_pointer.GetOffsetForVersion(version);
			chests_data_pointer1 = _chests_data_pointer1.GetOffsetForVersion(version);
			chests_data_pointer2 = _chests_data_pointer2.GetOffsetForVersion(version);
			chests_data_pointer3 = _chests_data_pointer3.GetOffsetForVersion(version);
			blocks_length = _blocks_length.GetOffsetForVersion(version);
			blocks_pointer1 = _blocks_pointer1.GetOffsetForVersion(version);
			blocks_pointer2 = _blocks_pointer2.GetOffsetForVersion(version);
			blocks_pointer3 = _blocks_pointer3.GetOffsetForVersion(version);
			blocks_pointer4 = _blocks_pointer4.GetOffsetForVersion(version);
			torch_data = _torch_data.GetOffsetForVersion(version);
			torches_length_pointer = _torches_length_pointer.GetOffsetForVersion(version);
			sprite_blockset_pointer = _sprite_blockset_pointer.GetOffsetForVersion(version);
			sprites_data = _sprites_data.GetOffsetForVersion(version);
			sprites_data_empty_room = _sprites_data_empty_room.GetOffsetForVersion(version);
			sprites_end_data = _sprites_end_data.GetOffsetForVersion(version);
			pit_pointer = _pit_pointer.GetOffsetForVersion(version);
			pit_count = _pit_count.GetOffsetForVersion(version);
			doorPointers = _doorPointers.GetOffsetForVersion(version);
			door_gfx_up = _door_gfx_up.GetOffsetForVersion(version);
			door_gfx_down = _door_gfx_down.GetOffsetForVersion(version);
			door_gfx_left = _door_gfx_left.GetOffsetForVersion(version);
			door_gfx_right = _door_gfx_right.GetOffsetForVersion(version);
			door_pos_up = _door_pos_up.GetOffsetForVersion(version);
			door_pos_down = _door_pos_down.GetOffsetForVersion(version);
			door_pos_left = _door_pos_left.GetOffsetForVersion(version);
			door_pos_right = _door_pos_right.GetOffsetForVersion(version);
			gfx_font = _gfx_font.GetOffsetForVersion(version);
			text_data = _text_data.GetOffsetForVersion(version);
			text_data2 = _text_data2.GetOffsetForVersion(version);
			pointers_dictionaries = _pointers_dictionaries.GetOffsetForVersion(version);
			characters_width = _characters_width.GetOffsetForVersion(version);
			entrance_room = _entrance_room.GetOffsetForVersion(version);
			entrance_scrolledge = _entrance_scrolledge.GetOffsetForVersion(version);
			entrance_cameray = _entrance_cameray.GetOffsetForVersion(version);
			entrance_camerax = _entrance_camerax.GetOffsetForVersion(version);
			entrance_yposition = _entrance_yposition.GetOffsetForVersion(version);
			entrance_xposition = _entrance_xposition.GetOffsetForVersion(version);
			entrance_cameraytrigger = _entrance_cameraytrigger.GetOffsetForVersion(version);
			entrance_cameraxtrigger = _entrance_cameraxtrigger.GetOffsetForVersion(version);
			entrance_blockset = _entrance_blockset.GetOffsetForVersion(version);
			entrance_floor = _entrance_floor.GetOffsetForVersion(version);
			entrance_dungeon = _entrance_dungeon.GetOffsetForVersion(version);
			entrance_door = _entrance_door.GetOffsetForVersion(version);
			entrance_ladderbg = _entrance_ladderbg.GetOffsetForVersion(version);
			entrance_scrolling = _entrance_scrolling.GetOffsetForVersion(version);
			entrance_scrollquadrant = _entrance_scrollquadrant.GetOffsetForVersion(version);
			entrance_exit = _entrance_exit.GetOffsetForVersion(version);
			entrance_music = _entrance_music.GetOffsetForVersion(version);
			startingentrance_room = _startingentrance_room.GetOffsetForVersion(version);
			startingentrance_scrolledge = _startingentrance_scrolledge.GetOffsetForVersion(version);
			startingentrance_cameray = _startingentrance_cameray.GetOffsetForVersion(version);
			startingentrance_camerax = _startingentrance_camerax.GetOffsetForVersion(version);
			startingentrance_yposition = _startingentrance_yposition.GetOffsetForVersion(version);
			startingentrance_xposition = _startingentrance_xposition.GetOffsetForVersion(version);
			startingentrance_cameraytrigger = _startingentrance_cameraytrigger.GetOffsetForVersion(version);
			startingentrance_cameraxtrigger = _startingentrance_cameraxtrigger.GetOffsetForVersion(version);
			startingentrance_blockset = _startingentrance_blockset.GetOffsetForVersion(version);
			startingentrance_floor = _startingentrance_floor.GetOffsetForVersion(version);
			startingentrance_dungeon = _startingentrance_dungeon.GetOffsetForVersion(version);
			startingentrance_door = _startingentrance_door.GetOffsetForVersion(version);
			startingentrance_ladderbg = _startingentrance_ladderbg.GetOffsetForVersion(version);
			startingentrance_scrolling = _startingentrance_scrolling.GetOffsetForVersion(version);
			startingentrance_scrollquadrant = _startingentrance_scrollquadrant.GetOffsetForVersion(version);
			startingentrance_exit = _startingentrance_exit.GetOffsetForVersion(version);
			startingentrance_music = _startingentrance_music.GetOffsetForVersion(version);
			startingentrance_entrance = _startingentrance_entrance.GetOffsetForVersion(version);
			items_data_start = _items_data_start.GetOffsetForVersion(version);
			items_data_end = _items_data_end.GetOffsetForVersion(version);
			initial_equipement = _initial_equipement.GetOffsetForVersion(version);
			messages_id_dungeon = _messages_id_dungeon.GetOffsetForVersion(version);
			chests_backupitems = _chests_backupitems.GetOffsetForVersion(version);
			chests_yoffset = _chests_yoffset.GetOffsetForVersion(version);
			chests_xoffset = _chests_xoffset.GetOffsetForVersion(version);
			chests_itemsgfx = _chests_itemsgfx.GetOffsetForVersion(version);
			chests_itemswide = _chests_itemswide.GetOffsetForVersion(version);
			chests_itemsproperties = _chests_itemsproperties.GetOffsetForVersion(version);
			chests_sramaddress = _chests_sramaddress.GetOffsetForVersion(version);
			chests_sramvalue = _chests_sramvalue.GetOffsetForVersion(version);
			chests_msgid = _chests_msgid.GetOffsetForVersion(version);
			dungeons_startrooms = _dungeons_startrooms.GetOffsetForVersion(version);
			dungeons_endrooms = _dungeons_endrooms.GetOffsetForVersion(version);
			dungeons_bossrooms = _dungeons_bossrooms.GetOffsetForVersion(version);
			bedPositionX = _bedPositionX.GetOffsetForVersion(version);
			bedPositionY = _bedPositionY.GetOffsetForVersion(version);
			bedPositionResetXLow = _bedPositionResetXLow.GetOffsetForVersion(version);
			bedPositionResetXHigh = _bedPositionResetXHigh.GetOffsetForVersion(version);
			bedPositionResetYLow = _bedPositionResetYLow.GetOffsetForVersion(version);
			bedPositionResetYHigh = _bedPositionResetYHigh.GetOffsetForVersion(version);
			bedSheetPositionX = _bedSheetPositionX.GetOffsetForVersion(version);
			bedSheetPositionY = _bedSheetPositionY.GetOffsetForVersion(version);
			GravesYTilePos = _GravesYTilePos.GetOffsetForVersion(version);
			GravesXTilePos = _GravesXTilePos.GetOffsetForVersion(version);
			GravesTilemapPos = _GravesTilemapPos.GetOffsetForVersion(version);
			GravesGFX = _GravesGFX.GetOffsetForVersion(version);
			GravesXPos = _GravesXPos.GetOffsetForVersion(version);
			GravesYLine = _GravesYLine.GetOffsetForVersion(version);
			GravesCountOnY = _GravesCountOnY.GetOffsetForVersion(version);
			GraveLinkSpecialHole = _GraveLinkSpecialHole.GetOffsetForVersion(version);
			GraveLinkSpecialStairs = _GraveLinkSpecialStairs.GetOffsetForVersion(version);
			overworldPaletteMain = _overworldPaletteMain.GetOffsetForVersion(version);
			overworldPaletteAuxialiary = _overworldPaletteAuxialiary.GetOffsetForVersion(version);
			overworldPaletteAnimated = _overworldPaletteAnimated.GetOffsetForVersion(version);
			globalSpritePalettesLW = _globalSpritePalettesLW.GetOffsetForVersion(version);
			globalSpritePalettesDW = _globalSpritePalettesDW.GetOffsetForVersion(version);
			armorPalettes = _armorPalettes.GetOffsetForVersion(version);
			spritePalettesAux1 = _spritePalettesAux1.GetOffsetForVersion(version);
			spritePalettesAux2 = _spritePalettesAux2.GetOffsetForVersion(version);
			spritePalettesAux3 = _spritePalettesAux3.GetOffsetForVersion(version);
			swordPalettes = _swordPalettes.GetOffsetForVersion(version);
			shieldPalettes = _shieldPalettes.GetOffsetForVersion(version);
			hudPalettes = _hudPalettes.GetOffsetForVersion(version);
			dungeonMapPalettes = _dungeonMapPalettes.GetOffsetForVersion(version);
			dungeonMainPalettes = _dungeonMainPalettes.GetOffsetForVersion(version);
			dungeonMapBgPalettes = _dungeonMapBgPalettes.GetOffsetForVersion(version);
			hardcodedGrassLW = _hardcodedGrassLW.GetOffsetForVersion(version);
			hardcodedGrassDW = _hardcodedGrassDW.GetOffsetForVersion(version);
			hardcodedGrassSpecial = _hardcodedGrassSpecial.GetOffsetForVersion(version);
			dungeonMap_rooms_ptr = _dungeonMap_rooms_ptr.GetOffsetForVersion(version);
			dungeonMap_floors = _dungeonMap_floors.GetOffsetForVersion(version);
			dungeonMap_gfx_ptr = _dungeonMap_gfx_ptr.GetOffsetForVersion(version);
			dungeonMap_datastart = _dungeonMap_datastart.GetOffsetForVersion(version);
			dungeonMap_expCheck = _dungeonMap_expCheck.GetOffsetForVersion(version);
			dungeonMap_tile16 = _dungeonMap_tile16.GetOffsetForVersion(version);
			dungeonMap_tile16Exp = _dungeonMap_tile16Exp.GetOffsetForVersion(version);
			dungeonMap_bossrooms = _dungeonMap_bossrooms.GetOffsetForVersion(version);
			triforceVertices = _triforceVertices.GetOffsetForVersion(version);
			TriforceFaces = _TriforceFaces.GetOffsetForVersion(version);
			crystalVertices = _crystalVertices.GetOffsetForVersion(version);
		}
	}
}
