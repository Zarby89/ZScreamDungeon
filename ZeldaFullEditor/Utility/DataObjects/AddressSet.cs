﻿using System;
using System.Reflection;

namespace ZeldaFullEditor
{
	public class AddressSet
	{
		public int tile_address => new ROMAddress(0x009B52, 0x009B52).GetOffsetForVersion(Version);
		public int tile_address_floor => new ROMAddress(0x009B5A, 0x009B5A).GetOffsetForVersion(Version);
		public int subtype1_tiles => new ROMAddress(0x018000, 0x018000).GetOffsetForVersion(Version);
		public int subtype2_tiles => new ROMAddress(0x0183F0, 0x0183F0).GetOffsetForVersion(Version);
		public int subtype3_tiles => new ROMAddress(0x0184F0, 0x0184F0).GetOffsetForVersion(Version);
		public int gfx_animated_pointer => new ROMAddress(0x028624, 0x028275).GetOffsetForVersion(Version);
		public int overworldgfxGroups2 => new ROMAddress(0x00E0B3, 0x00E073).GetOffsetForVersion(Version);
		public int gfx_1_pointer => new ROMAddress(0x00E7D0, 0x00E790).GetOffsetForVersion(Version);
		public int gfx_2_pointer => new ROMAddress(0x00E7D5, 0x00E795).GetOffsetForVersion(Version);
		public int gfx_3_pointer => new ROMAddress(0x00E7DA, 0x00E79A).GetOffsetForVersion(Version);
		public int maxGfx => new ROMAddress(0x18BFB5, 0x18BFB5).GetOffsetForVersion(Version);
		public int compressedAllMap32PointersHigh => new ROMAddress(0x02F6B1, 0x02F94D).GetOffsetForVersion(Version);
		public int compressedAllMap32PointersLow => new ROMAddress(0x02F891, 0x02FB2D).GetOffsetForVersion(Version);
		public int overworldgfxGroups => new ROMAddress(0x00DDD7, 0x00DD97).GetOffsetForVersion(Version);
		public int map16Tiles => new ROMAddress(0x0F8000, 0x0F8000).GetOffsetForVersion(Version);
		public int Map32DefinitionsTL => new ROMAddress(0x038000, 0x038000).GetOffsetForVersion(Version);
		public int Map32DefinitionsTR => new ROMAddress(0x03B3C0, 0x03B400).GetOffsetForVersion(Version);
		public int Map32DefinitionsBL => new ROMAddress(0x048000, 0x048000).GetOffsetForVersion(Version);
		public int Map32DefinitionsBR => new ROMAddress(0x04B3C0, 0x04B400).GetOffsetForVersion(Version);
		public int overworldPalGroup1 => new ROMAddress(0x1BE6C8, 0x1BE6C8).GetOffsetForVersion(Version);
		public int overworldPalGroup2 => new ROMAddress(0x1BE86C, 0x1BE86C).GetOffsetForVersion(Version);
		public int overworldPalGroup3 => new ROMAddress(0x1BE604, 0x1BE604).GetOffsetForVersion(Version);
		public int overworldMapPalette => new ROMAddress(0x00FD1C, 0x00FD1C).GetOffsetForVersion(Version);
		public int overworldSpritePalette => new ROMAddress(0x00FB41, 0x00FB41).GetOffsetForVersion(Version);
		public int overworldMapPaletteGroup => new ROMAddress(0x0CFE74, 0x0ED504).GetOffsetForVersion(Version);
		public int overworldSpritePaletteGroup => new ROMAddress(0x0ED580, 0x0ED580).GetOffsetForVersion(Version);
		public int overworldSpriteset => new ROMAddress(0x00FA41, 0x00FA41).GetOffsetForVersion(Version);
		public int overworldSpecialGFXGroup => new ROMAddress(0x02E821, 0x02E821).GetOffsetForVersion(Version);
		public int overworldSpecialPALGroup => new ROMAddress(0x02E831, 0x02E831).GetOffsetForVersion(Version);
		public int OverworldSpritesTableState0 => new ROMAddress(0x09C881, 0x09C881).GetOffsetForVersion(Version);
		public int OverworldSpritesTableState3 => new ROMAddress(0x09CA21, 0x09CA21).GetOffsetForVersion(Version);
		public int OverworldSpritesTableState2 => new ROMAddress(0x09C901, 0x09C901).GetOffsetForVersion(Version);
		public int overworldItemsPointers => new ROMAddress(0x1BC2F9, 0x1BC2F9).GetOffsetForVersion(Version);
		public int overworldItemsAddress => new ROMAddress(0x1BC8B9, 0x1BC8B9).GetOffsetForVersion(Version);
		public int overworldItemsBank => new ROMAddress(0x1BC8BF, 0x1BC8BF).GetOffsetForVersion(Version);
		public int overworldItemsEndData => new ROMAddress(0x1BC89C, 0x1BC89C).GetOffsetForVersion(Version);
		public int mapGfx => new ROMAddress(0x00FC9C, 0x00FC9C).GetOffsetForVersion(Version);
		public int overlayPointers => new ROMAddress(0x07FAF4, 0x0EF664).GetOffsetForVersion(Version);
		public int overlayPointersBank => new ROMAddress(0x070000, 0x0E0000).GetOffsetForVersion(Version);
		public int overworldTilesType => new ROMAddress(0x0FFD94, 0x0E9459).GetOffsetForVersion(Version);
		public int overworldMessages => new ROMAddress(0x07F51D, 0x07F51D).GetOffsetForVersion(Version);
		public int overworldMusicBegining => new ROMAddress(0x02C303, 0x02C303).GetOffsetForVersion(Version);
		public int overworldMusicZelda => new ROMAddress(0x02C343, 0x02C343).GetOffsetForVersion(Version);
		public int overworldMusicMasterSword => new ROMAddress(0x02C383, 0x02C383).GetOffsetForVersion(Version);
		public int overworldMusicAgahim => new ROMAddress(0x02C3C3, 0x02C3C3).GetOffsetForVersion(Version);
		public int overworldMusicDW => new ROMAddress(0x02C403, 0x02C403).GetOffsetForVersion(Version);
		public int overworldEntranceAllowedTilesLeft => new ROMAddress(0x1BB8C1, 0x1BB8C1).GetOffsetForVersion(Version);
		public int overworldEntranceAllowedTilesRight => new ROMAddress(0x1BB917, 0x1BB917).GetOffsetForVersion(Version);
		public int overworldMapSize => new ROMAddress(0x02A73B, 0x02A844).GetOffsetForVersion(Version);
		public int overworldMapSizeHighByte => new ROMAddress(0x02A884, 0x02A884).GetOffsetForVersion(Version);
		public int overworldMapParentId => new ROMAddress(0x02A5EC, 0x02A5EC).GetOffsetForVersion(Version);
		public int overworldTransitionPositionY => new ROMAddress(0x02A8C4, 0x02A8C4).GetOffsetForVersion(Version);
		public int overworldTransitionPositionX => new ROMAddress(0x02A944, 0x02A944).GetOffsetForVersion(Version);
		public int overworldScreenSize => new ROMAddress(0x02F88D, 0x02F88D).GetOffsetForVersion(Version);
		public int OverworldScreenSizeForLoading => new ROMAddress(0x09C635, 0x09C635).GetOffsetForVersion(Version);
		public int OverworldScreenTileMapChangeByScreen => new ROMAddress(0x02A634, 0x02A634).GetOffsetForVersion(Version);
		public int transition_target_north => new ROMAddress(0x02BEE2, 0x02BEE2).GetOffsetForVersion(Version);
		public int transition_target_west => new ROMAddress(0x02BF62, 0x02BF62).GetOffsetForVersion(Version);
		public int OWExitRoomId => new ROMAddress(0x02DAEE, 0x02DD8A).GetOffsetForVersion(Version);
		public int OWExitMapId => new ROMAddress(0x02DB8C, 0x02DE28).GetOffsetForVersion(Version);
		public int OWExitVram => new ROMAddress(0x02DBDB, 0x02DE77).GetOffsetForVersion(Version);
		public int OWExitYScroll => new ROMAddress(0x02DC79, 0x02DF15).GetOffsetForVersion(Version);
		public int OWExitXScroll => new ROMAddress(0x02DD17, 0x02DFB3).GetOffsetForVersion(Version);
		public int OWExitYPlayer => new ROMAddress(0x02DDB5, 0x02E051).GetOffsetForVersion(Version);
		public int OWExitXPlayer => new ROMAddress(0x02DE53, 0x02E0EF).GetOffsetForVersion(Version);
		public int OWExitYCamera => new ROMAddress(0x02DEF1, 0x02E18D).GetOffsetForVersion(Version);
		public int OWExitXCamera => new ROMAddress(0x02DF8F, 0x02E22B).GetOffsetForVersion(Version);
		public int OWExitDoorPosition => new ROMAddress(0x02D724, 0x02D724).GetOffsetForVersion(Version);
		public int OWExitUnk1 => new ROMAddress(0x02E02D, 0x02E2C9).GetOffsetForVersion(Version);
		public int OWExitUnk2 => new ROMAddress(0x02E07C, 0x02E318).GetOffsetForVersion(Version);
		public int OWExitDoorType1 => new ROMAddress(0x02E0CB, 0x02E367).GetOffsetForVersion(Version);
		public int OWExitDoorType2 => new ROMAddress(0x02E169, 0x02E405).GetOffsetForVersion(Version);
		public int OWEntranceMap => new ROMAddress(0x1BB96F, 0x1BB96F).GetOffsetForVersion(Version);
		public int OWEntrancePos => new ROMAddress(0x1BBA71, 0x1BBA71).GetOffsetForVersion(Version);
		public int OWEntranceEntranceId => new ROMAddress(0x1BBB73, 0x1BBB73).GetOffsetForVersion(Version);
		public int OWHolePos => new ROMAddress(0x1BB800, 0x1BB800).GetOffsetForVersion(Version);
		public int OWHoleArea => new ROMAddress(0x1BB826, 0x1BB826).GetOffsetForVersion(Version);
		public int OWHoleEntrance => new ROMAddress(0x1BB84C, 0x1BB84C).GetOffsetForVersion(Version);
		public int OWExitMapIdWhirlpool => new ROMAddress(0x02EAE5, 0x02EAE5).GetOffsetForVersion(Version);
		public int OWExitVramWhirlpool => new ROMAddress(0x02EB07, 0x02EB07).GetOffsetForVersion(Version);
		public int OWExitYScrollWhirlpool => new ROMAddress(0x02EB29, 0x02EB29).GetOffsetForVersion(Version);
		public int OWExitXScrollWhirlpool => new ROMAddress(0x02EB4B, 0x02EB4B).GetOffsetForVersion(Version);
		public int OWExitYPlayerWhirlpool => new ROMAddress(0x02EB6D, 0x02EB6D).GetOffsetForVersion(Version);
		public int OWExitXPlayerWhirlpool => new ROMAddress(0x02EB8F, 0x02EB8F).GetOffsetForVersion(Version);
		public int OWExitYCameraWhirlpool => new ROMAddress(0x02EBB1, 0x02EBB1).GetOffsetForVersion(Version);
		public int OWExitXCameraWhirlpool => new ROMAddress(0x02EBD3, 0x02EBD3).GetOffsetForVersion(Version);
		public int OWExitUnk1Whirlpool => new ROMAddress(0x02EBF5, 0x02EBF5).GetOffsetForVersion(Version);
		public int OWExitUnk2Whirlpool => new ROMAddress(0x02EC17, 0x02EC17).GetOffsetForVersion(Version);
		public int OWWhirlpoolPosition => new ROMAddress(0x02ECF8, 0x02ECF8).GetOffsetForVersion(Version);
		public int dungeons_palettes_groups => new ROMAddress(0x0CFDD0, 0x0ED460).GetOffsetForVersion(Version);
		public int dungeons_main_bg_palette_pointers => new ROMAddress(0x1BEC4B, 0x1BEC4B).GetOffsetForVersion(Version);
		public int dungeons_palettes => new ROMAddress(0x1BD734, 0x1BD734).GetOffsetForVersion(Version);
		public int room_items_pointers => new ROMAddress(0x01DB67, 0x01DB69).GetOffsetForVersion(Version);
		public int rooms_sprite_pointer => new ROMAddress(0x09C298, 0x09C298).GetOffsetForVersion(Version);
		public int room_header_pointer => new ROMAddress(0x01B5DD, 0x01B5DD).GetOffsetForVersion(Version);
		public int room_header_pointers_bank => new ROMAddress(0x01B5E7, 0x01B5E7).GetOffsetForVersion(Version);
		public int gfx_groups_pointer => new ROMAddress(0x00E277, 0x00E237).GetOffsetForVersion(Version);
		public int room_object_layout_pointer => new ROMAddress(0x01882D, 0x01882D).GetOffsetForVersion(Version);
		public int room_object_pointer => new ROMAddress(0x01874C, 0x01874C).GetOffsetForVersion(Version);
		public int chests_length_pointer => new ROMAddress(0x01EBF4, 0x01EBF6).GetOffsetForVersion(Version);
		public int chests_data_pointer1 => new ROMAddress(0x01EBF9, 0x01EBFB).GetOffsetForVersion(Version);
		public int chests_data_pointer2 => new ROMAddress(0x01EC0A, 0x01EC0A).GetOffsetForVersion(Version);
		public int chests_data_pointer3 => new ROMAddress(0x01EC10, 0x01EC10).GetOffsetForVersion(Version);
		public int blocks_length => new ROMAddress(0x018896, 0x018896).GetOffsetForVersion(Version);
		public int blocks_pointer1 => new ROMAddress(0x02D85E, 0x02DAFA).GetOffsetForVersion(Version);
		public int blocks_pointer2 => new ROMAddress(0x02D865, 0x02DB01).GetOffsetForVersion(Version);
		public int blocks_pointer3 => new ROMAddress(0x02D86C, 0x02DB08).GetOffsetForVersion(Version);
		public int blocks_pointer4 => new ROMAddress(0x02D873, 0x02DB0F).GetOffsetForVersion(Version);
		public int torch_data => new ROMAddress(0x04F04A, 0x04F36A).GetOffsetForVersion(Version);
		public int torches_length_pointer => new ROMAddress(0x0188C1, 0x0188C1).GetOffsetForVersion(Version);
		public int sprite_blockset_pointer => new ROMAddress(0x00DB97, 0x00DB57).GetOffsetForVersion(Version);
		public int sprites_data => new ROMAddress(0x09D8B0, 0x09D8B0).GetOffsetForVersion(Version);
		public int sprites_data_empty_room => new ROMAddress(0x09D8AE, 0x09D8AE).GetOffsetForVersion(Version);
		public int sprites_end_data => new ROMAddress(0x09EC9E, 0x09EC9E).GetOffsetForVersion(Version);
		public int pit_pointer => new ROMAddress(0x0794A2, 0x0794AB).GetOffsetForVersion(Version);
		public int pit_count => new ROMAddress(0x07949D, 0x0794A6).GetOffsetForVersion(Version);
		public int doorPointers => new ROMAddress(0x1F83C0, 0x1F83C0).GetOffsetForVersion(Version);
		public int door_gfx_up => new ROMAddress(0x00CD9E, 0x00CD9E).GetOffsetForVersion(Version);
		public int door_gfx_down => new ROMAddress(0x00CE06, 0x00CE06).GetOffsetForVersion(Version);
		public int door_gfx_left => new ROMAddress(0x00CE66, 0x00CE66).GetOffsetForVersion(Version);
		public int door_gfx_right => new ROMAddress(0x00CEC6, 0x00CEC6).GetOffsetForVersion(Version);
		public int door_pos_up => new ROMAddress(0x00997E, 0x00997E).GetOffsetForVersion(Version);
		public int door_pos_down => new ROMAddress(0x009996, 0x009996).GetOffsetForVersion(Version);
		public int door_pos_left => new ROMAddress(0x0099AE, 0x0099AE).GetOffsetForVersion(Version);
		public int door_pos_right => new ROMAddress(0x0099C6, 0x0099C6).GetOffsetForVersion(Version);
		public int gfx_font => new ROMAddress(0x0E8000, 0x0E8000).GetOffsetForVersion(Version);
		public int text_data => new ROMAddress(0x1C8000, 0x1C8000).GetOffsetForVersion(Version);
		public int text_data2 => new ROMAddress(0x0EDF40, 0x0EDF40).GetOffsetForVersion(Version);
		public int pointers_dictionaries => new ROMAddress(0x0EC703, 0x0EC703).GetOffsetForVersion(Version);
		public int characters_width => new ROMAddress(0x0ECADF, 0x0ECADF).GetOffsetForVersion(Version);
		public int entrance_room => new ROMAddress(0x02C577, 0x02C813).GetOffsetForVersion(Version);
		public int entrance_scrolledge => new ROMAddress(0x02C91D, 0x02C91D).GetOffsetForVersion(Version);
		public int entrance_cameray => new ROMAddress(0x02CBB3, 0x02CD45).GetOffsetForVersion(Version);
		public int entrance_camerax => new ROMAddress(0x02CAA9, 0x02CE4F).GetOffsetForVersion(Version);
		public int entrance_yposition => new ROMAddress(0x02CCBD, 0x02CF59).GetOffsetForVersion(Version);
		public int entrance_xposition => new ROMAddress(0x02CDC7, 0x02D063).GetOffsetForVersion(Version);
		public int entrance_cameraytrigger => new ROMAddress(0x02CED1, 0x02D16D).GetOffsetForVersion(Version);
		public int entrance_cameraxtrigger => new ROMAddress(0x02CFDB, 0x02D277).GetOffsetForVersion(Version);
		public int entrance_blockset => new ROMAddress(0x02D0E5, 0x02D381).GetOffsetForVersion(Version);
		public int entrance_floor => new ROMAddress(0x02D16A, 0x02D406).GetOffsetForVersion(Version);
		public int entrance_dungeon => new ROMAddress(0x02D1EF, 0x02D48B).GetOffsetForVersion(Version);
		public int entrance_door => new ROMAddress(0x02D274, 0x02D510).GetOffsetForVersion(Version);
		public int entrance_ladderbg => new ROMAddress(0x02D2F9, 0x02D595).GetOffsetForVersion(Version);
		public int entrance_scrolling => new ROMAddress(0x02D37E, 0x02D61A).GetOffsetForVersion(Version);
		public int entrance_scrollquadrant => new ROMAddress(0x02D403, 0x02D69F).GetOffsetForVersion(Version);
		public int entrance_exit => new ROMAddress(0x02D488, 0x02D724).GetOffsetForVersion(Version);
		public int entrance_music => new ROMAddress(0x02D592, 0x02D82E).GetOffsetForVersion(Version);
		public int startingentrance_room => new ROMAddress(0x02D8D2, 0x02DB6E).GetOffsetForVersion(Version);
		public int startingentrance_scrolledge => new ROMAddress(0x02D8E0, 0x02DB7C).GetOffsetForVersion(Version);
		public int startingentrance_cameray => new ROMAddress(0x02D918, 0x02DBB4).GetOffsetForVersion(Version);
		public int startingentrance_camerax => new ROMAddress(0x02D926, 0x02DBC2).GetOffsetForVersion(Version);
		public int startingentrance_yposition => new ROMAddress(0x02D934, 0x02DBD0).GetOffsetForVersion(Version);
		public int startingentrance_xposition => new ROMAddress(0x02D942, 0x02DBDE).GetOffsetForVersion(Version);
		public int startingentrance_cameraytrigger => new ROMAddress(0x02D950, 0x02DBEC).GetOffsetForVersion(Version);
		public int startingentrance_cameraxtrigger => new ROMAddress(0x02D95E, 0x02DBFA).GetOffsetForVersion(Version);
		public int startingentrance_blockset => new ROMAddress(0x02D96C, 0x02DC08).GetOffsetForVersion(Version);
		public int startingentrance_floor => new ROMAddress(0x02D973, 0x02DC0F).GetOffsetForVersion(Version);
		public int startingentrance_dungeon => new ROMAddress(0x02D97A, 0x02DC16).GetOffsetForVersion(Version);
		public int startingentrance_door => new ROMAddress(0x02D98F, 0x02DC2B).GetOffsetForVersion(Version);
		public int startingentrance_ladderbg => new ROMAddress(0x02D981, 0x02DC1D).GetOffsetForVersion(Version);
		public int startingentrance_scrolling => new ROMAddress(0x02D988, 0x02DC24).GetOffsetForVersion(Version);
		public int startingentrance_scrollquadrant => new ROMAddress(0x02D98F, 0x02DC2B).GetOffsetForVersion(Version);
		public int startingentrance_exit => new ROMAddress(0x02D996, 0x02DC32).GetOffsetForVersion(Version);
		public int startingentrance_music => new ROMAddress(0x02D9B2, 0x02DC4E).GetOffsetForVersion(Version);
		public int startingentrance_entrance => new ROMAddress(0x02D9A4, 0x02DC40).GetOffsetForVersion(Version);
		public int items_data_start => new ROMAddress(0x01DDE7, 0x01DDE9).GetOffsetForVersion(Version);
		public int items_data_end => new ROMAddress(0x01E6B0, 0x01E6B2).GetOffsetForVersion(Version);
		public int initial_equipement => new ROMAddress(0x04F1A6, 0x04F1A6).GetOffsetForVersion(Version);
		public int messages_id_dungeon => new ROMAddress(0x07F5F7, 0x07F61D).GetOffsetForVersion(Version);
		public int chests_backupitems => new ROMAddress(0x07B528, 0x07B528).GetOffsetForVersion(Version);
		public int chests_yoffset => new ROMAddress(0x09836C, 0x09836C).GetOffsetForVersion(Version);
		public int chests_xoffset => new ROMAddress(0x0983B8, 0x0983B8).GetOffsetForVersion(Version);
		public int chests_itemsgfx => new ROMAddress(0x098404, 0x098404).GetOffsetForVersion(Version);
		public int chests_itemswide => new ROMAddress(0x098450, 0x098450).GetOffsetForVersion(Version);
		public int chests_itemsproperties => new ROMAddress(0x09849C, 0x09849C).GetOffsetForVersion(Version);
		public int chests_sramaddress => new ROMAddress(0x0984E8, 0x0984E8).GetOffsetForVersion(Version);
		public int chests_sramvalue => new ROMAddress(0x098580, 0x098580).GetOffsetForVersion(Version);
		public int chests_msgid => new ROMAddress(0x08C2DD, 0x08C2DD).GetOffsetForVersion(Version);
		public int dungeons_startrooms => new ROMAddress(0x00F939, 0x00F939).GetOffsetForVersion(Version);
		public int dungeons_endrooms => new ROMAddress(0x00F92D, 0x00F92D).GetOffsetForVersion(Version);
		public int dungeons_bossrooms => new ROMAddress(0x028954, 0x028954).GetOffsetForVersion(Version);
		public int bedPositionX => new ROMAddress(0x079A37, 0x079A37).GetOffsetForVersion(Version);
		public int bedPositionY => new ROMAddress(0x079A32, 0x079A32).GetOffsetForVersion(Version);
		public int bedPositionResetXLow => new ROMAddress(0x05DE53, 0x05DE53).GetOffsetForVersion(Version);
		public int bedPositionResetXHigh => new ROMAddress(0x05DE58, 0x05DE58).GetOffsetForVersion(Version);
		public int bedPositionResetYLow => new ROMAddress(0x05DE5D, 0x05DE5D).GetOffsetForVersion(Version);
		public int bedPositionResetYHigh => new ROMAddress(0x05DE62, 0x05DE62).GetOffsetForVersion(Version);
		public int bedSheetPositionX => new ROMAddress(0x0980BD, 0x0980BD).GetOffsetForVersion(Version);
		public int bedSheetPositionY => new ROMAddress(0x0980B8, 0x0980B8).GetOffsetForVersion(Version);
		public int GravesYTilePos => new ROMAddress(0x099968, 0x099968).GetOffsetForVersion(Version);
		public int GravesXTilePos => new ROMAddress(0x099986, 0x099986).GetOffsetForVersion(Version);
		public int GravesTilemapPos => new ROMAddress(0x0999A4, 0x0999A4).GetOffsetForVersion(Version);
		public int GravesGFX => new ROMAddress(0x0999C2, 0x0999C2).GetOffsetForVersion(Version);
		public int GravesXPos => new ROMAddress(0x09994A, 0x09994A).GetOffsetForVersion(Version);
		public int GravesYLine => new ROMAddress(0x09993A, 0x09993A).GetOffsetForVersion(Version);
		public int GravesCountOnY => new ROMAddress(0x0999E0, 0x0999E0).GetOffsetForVersion(Version);
		public int GraveLinkSpecialHole => new ROMAddress(0x08EDD9, 0x08EDD9).GetOffsetForVersion(Version);
		public int GraveLinkSpecialStairs => new ROMAddress(0x08EDE0, 0x08EDE0).GetOffsetForVersion(Version);
		public int overworldPaletteMain => new ROMAddress(0x1BE6C8, 0x1BE6C8).GetOffsetForVersion(Version);
		public int overworldPaletteAuxialiary => new ROMAddress(0x1BE86C, 0x1BE86C).GetOffsetForVersion(Version);
		public int overworldPaletteAnimated => new ROMAddress(0x1BE604, 0x1BE604).GetOffsetForVersion(Version);
		public int globalSpritePalettesLW => new ROMAddress(0x1BD218, 0x1BD218).GetOffsetForVersion(Version);
		public int globalSpritePalettesDW => new ROMAddress(0x1BD290, 0x1BD290).GetOffsetForVersion(Version);
		public int armorPalettes => new ROMAddress(0x1BD308, 0x1BD308).GetOffsetForVersion(Version);
		public int spritePalettesAux1 => new ROMAddress(0x1BD39E, 0x1BD39E).GetOffsetForVersion(Version);
		public int spritePalettesAux2 => new ROMAddress(0x1BD446, 0x1BD446).GetOffsetForVersion(Version);
		public int spritePalettesAux3 => new ROMAddress(0x1BD4E0, 0x1BD4E0).GetOffsetForVersion(Version);
		public int swordPalettes => new ROMAddress(0x1BD630, 0x1BD630).GetOffsetForVersion(Version);
		public int shieldPalettes => new ROMAddress(0x1BD648, 0x1BD648).GetOffsetForVersion(Version);
		public int hudPalettes => new ROMAddress(0x1BD660, 0x1BD660).GetOffsetForVersion(Version);
		public int dungeonMapPalettes => new ROMAddress(0x1BD70A, 0x1BD70A).GetOffsetForVersion(Version);
		public int dungeonMainPalettes => new ROMAddress(0x1BD734, 0x1BD734).GetOffsetForVersion(Version);
		public int dungeonMapBgPalettes => new ROMAddress(0x1BE544, 0x1BE544).GetOffsetForVersion(Version);
		public int hardcodedGrassLW => new ROMAddress(0x0CFFE6, 0x0BFEA9).GetOffsetForVersion(Version);
		public int hardcodedGrassDW => new ROMAddress(0x0CFFF0, 0x0BFEB3).GetOffsetForVersion(Version);
		public int hardcodedGrassSpecial => new ROMAddress(0x0CFFE1, 0x0ED640).GetOffsetForVersion(Version);
		public int dungeonMap_rooms_ptr => new ROMAddress(0x0AF605, 0x0AF605).GetOffsetForVersion(Version);
		public int dungeonMap_floors => new ROMAddress(0x0AF5D9, 0x0AF5D9).GetOffsetForVersion(Version);
		public int dungeonMap_gfx_ptr => new ROMAddress(0x0AFBE4, 0x0AFBE4).GetOffsetForVersion(Version);
		public int dungeonMap_datastart => new ROMAddress(0x0AF039, 0x0AF039).GetOffsetForVersion(Version);
		public int dungeonMap_expCheck => new ROMAddress(0x0AE652, 0x0AE652).GetOffsetForVersion(Version);
		public int dungeonMap_tile16 => new ROMAddress(0x0AF009, 0x0AF009).GetOffsetForVersion(Version);
		public int dungeonMap_tile16Exp => new ROMAddress(0x219010, 0x219010).GetOffsetForVersion(Version);
		public int dungeonMap_bossrooms => new ROMAddress(0x0AE807, 0x0AE807).GetOffsetForVersion(Version);
		public int triforceVertices => new ROMAddress(0x09FFD2, 0x09FFD2).GetOffsetForVersion(Version);
		public int TriforceFaces => new ROMAddress(0x09FFE4, 0x09FFE4).GetOffsetForVersion(Version);
		public int crystalVertices => new ROMAddress(0x09FF98, 0x09FF98).GetOffsetForVersion(Version);




		public int SpriteOAMHarmData => new ROMAddress(0x0DB080, 0x0DB080).GetOffsetForVersion(Version);
		public int SpriteHealthData => new ROMAddress(0x0DB173, 0x0DB173).GetOffsetForVersion(Version);
		public int SpriteBumpData => new ROMAddress(0x0DB266, 0x0DB266).GetOffsetForVersion(Version);
		public int SpriteOAMPropData => new ROMAddress(0x0DB359, 0x0DB359).GetOffsetForVersion(Version);
		public int SpriteHitboxData => new ROMAddress(0x0DB44C, 0x0DB44C).GetOffsetForVersion(Version);
		public int SpriteTileIntData => new ROMAddress(0x0DB53F, 0x0DB53F).GetOffsetForVersion(Version);
		public int SpritePrizePackData => new ROMAddress(0x0DB632, 0x0DB632).GetOffsetForVersion(Version);
		public int SpriteDeflectionData => new ROMAddress(0x0DB725, 0x0DB725).GetOffsetForVersion(Version);





		public SNESFunctions.ROMVersion Version { get; }
		public AddressSet(SNESFunctions.ROMVersion version)
		{
			Version = version;
		}
	}
}
