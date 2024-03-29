﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor {
    public static class Constants {
        //===========================================================================================
        //GFX Related Variables
        //===========================================================================================
        public static int tile_address = 0x1B52; // JP = Same //i don't think that need a pointer
        public static int tile_address_floor = 0x1B5A; // JP = Same //i don't think that need a pointer
        public static int subtype1_tiles = 0x8000; // JP = Same //i don't think that need a pointer
        public static int subtype2_tiles = 0x83F0; // JP = Same //i don't think that need a pointer
        public static int subtype3_tiles = 0x84F0; // JP = Same //i don't think that need a pointer
        public static int gfx_animated_pointer = 0x10275; //JP 0x10624 //long pointer
        public static int overworldgfxGroups2 = 0x6073; //0x60B3
        public static int gfx_1_pointer = 0x6790; //2byte pointer bank 00 pc -> 0x4320  CF80  ; 004F80
        public static int gfx_2_pointer = 0x6795; //D05F ; 00505F
        public static int gfx_3_pointer = 0x679A; //D13E ; 00513E
        public static int hud_palettes = 0xDD660;
        public static int maxGfx = 0xC3FB5;
        //===========================================================================================
        //Overworld Related Variables
        //===========================================================================================
        public static int compressedAllMap32PointersHigh = 0x1794D;
        public static int compressedAllMap32PointersLow = 0x17B2D;
        public static int overworldgfxGroups = 0x05D97;
        public static int map16Tiles = 0x78000;
        public static int map32TilesTL = 0x18000;
        public static int map32TilesTR = 0x1B400;
        public static int map32TilesBL = 0x20000;
        public static int map32TilesBR = 0x23400;
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

        /*public static int overworldSpritesBeginingEditor = 0x108100;
        public static int overworldSpritesAgahnimEditor = 0x108180;
        public static int overworldSpritesZeldaEditor = 0x1082A0;*/

        public static int overworldItemsPointers = 0xDC2F9;
        public static int overworldItemsAddress = 0xDC8B9; //1BC2F9
        public static int overworldItemsBank = 0xDC8BF;
        public static int overworldItemsEndData = 0xDC89C; //0DC89E

        public static int mapGfx = 0x7C9C;
        public static int overlayPointers = 0x77664;
        public static int overlayPointersBank = 0x0E;

        public static int overworldTilesType = 0x71459;
        public static int overworldMessages = 0x3F51D;

        //TODO:
        public static int overworldMusicBegining = 0x14303;
        public static int overworldMusicZelda = 0x14303 + 0x40;
        public static int overworldMusicMasterSword = 0x14303 + 0x80;
        public static int overworldMusicAgahim = 0x14303 + 0xC0;
        public static int overworldMusicDW = 0x14403;

        public static int overworldEntranceAllowedTilesLeft = 0xDB8C1;
        public static int overworldEntranceAllowedTilesRight = 0xDB917;

        public static int overworldMapSize = 0x12844; //0x00 = small maps, 0x20 = large maps
        public static int overworldMapSizeHighByte = 0x12884; //0x01 = small maps, 0x03 = large maps

        //relative to the WORLD + 0x200 per map
        //large map that are not == parent id = same position as their parent!
        //eg for X position small maps :
        //0000, 0200, 0400, 0600, 0800, 0A00, 0C00, 0E00
        //all Large map would be :
        //0000, 0000, 0400, 0400, 0800, 0800, 0C00, 0C00

        public static int overworldTransitionPositionY = 0x128C4;
        public static int overworldTransitionPositionX = 0x12944;

        public static int overworldScreenSize = 0x1788D;

        //===========================================================================================
        //Overworld Exits/Entrances Variables
        //===========================================================================================
        public static int OWExitRoomId = 0x15D8A; // 0x15E07 Credits sequences
        //105C2 Ending maps
        //105E2 Sprite Group Table for Ending
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
        public static int OWHolePos = 0xDB800;//(0x13 entries, 2 bytes each) modified(less 0x400) map16 coordinates for each hole
        public static int OWHoleArea = 0xDB826;//(0x13 entries, 2 bytes each) corresponding area numbers for each hole
        public static int OWHoleEntrance = 0xDB84C;//(0x13 entries, 1 byte each)  corresponding entrance numbers

        public static int OWExitMapIdWhirlpool = 0x16AE5; //  JP = ;016849
        public static int OWExitVramWhirlpool = 0x16B07;  //  JP = ;01686B
        public static int OWExitYScrollWhirlpool = 0x16B29;// JP = ;01688D
        public static int OWExitXScrollWhirlpool = 0x16B4B;// JP = ;016DE7
        public static int OWExitYPlayerWhirlpool = 0x16B6D;// JP = ;016E09
        public static int OWExitXPlayerWhirlpool = 0x16B8F;// JP = ;016E2B
        public static int OWExitYCameraWhirlpool = 0x16BB1;// JP = ;016E4D
        public static int OWExitXCameraWhirlpool = 0x16BD3;// JP = ;016E6F
        public static int OWExitUnk1Whirlpool = 0x16BF5;//    JP = ;016E91
        public static int OWExitUnk2Whirlpool = 0x16C17;//    JP = ;016EB3
        public static int OWWhirlpoolPosition = 0x16CF8;//    JP = ;016F94

        //===========================================================================================
        //Dungeon Related Variables
        //===========================================================================================
        //That could be turned into a pointer : 
        public static int dungeons_palettes_groups = 0x75460; //JP 0x67DD0
        public static int dungeons_main_bg_palette_pointers = 0xDEC4B; //JP Same
        public static int dungeons_palettes = 0xDD734; //JP Same (where all dungeons palettes are) 

        //That could be turned into a pointer : 
        public static int room_items_pointers = 0xDB69;//JP 0xDB67

        public static int rooms_sprite_pointer = 0x4C298; //JP Same //2byte bank 09D62E
        public static int room_header_pointer = 0xB5DD; //LONG
        public static int room_header_pointers_bank = 0xB5E7; //JP Same

        public static int gfx_groups_pointer = 0x6237;
        public static int room_object_layout_pointer = 0x882D;

        public static int room_object_pointer = 0x874C; //Long pointer

        public static int chests_length_pointer = 0xEBF6;
        public static int chests_data_pointer1 = 0xEBFB;
        //public static int chests_data_pointer2 = 0xEC0A; //Disabled for now could be used for expansion
        //public static int chests_data_pointer3 = 0xEC10; //Disabled for now could be used for expansion

        public static int blocks_length = 0x8896; //word value 
        public static int blocks_pointer1 = 0x15AFA;
        public static int blocks_pointer2 = 0x15B01;
        public static int blocks_pointer3 = 0x15B08;
        public static int blocks_pointer4 = 0x15B0F;

        public static int torch_data = 0x2736A; //JP 0x2704A
        public static int torches_length_pointer = 0x88C1;

        public static int sprite_blockset_pointer = 0x5B57;
        public static int sprites_data = 0x4D8B0;//It use the unused pointers to have more space //Save purpose
        public static int sprites_data_empty_room = 0x4D8AE;
        public static int sprites_end_data = 0x4EC9E;

        public static int pit_pointer = 0x394AB;
        public static int pit_count = 0x394A6;

        public static int doorPointers = 0xF83C0;

        //doors
        public static int door_gfx_up = 0x4D9E;
        //
        public static int door_gfx_down = 0x4E06;
        public static int door_gfx_cavexit_down = 0x4E06;
        public static int door_gfx_left = 0x4E66;
        public static int door_gfx_right = 0x4EC6;

        public static int door_pos_up = 0x197E;
        public static int door_pos_down = 0x1996;
        public static int door_pos_left = 0x19AE;
        public static int door_pos_right = 0x19C6;

        //TEXT EDITOR RELATED CONSTANTS
        public static int gfx_font = 0x70000; //2bpp format
        public static int text_data = 0xE0000;
        public static int text_data2 = 0x75F40;
        public static int pointers_dictionaries = 0x74703;
        public static int characters_width = 0x74ADF;

        //===========================================================================================
        //Dungeon Entrances Related Variables
        //===========================================================================================
        public static int entrance_room = 0x14813; //0x14577 //word value for each room
        public static int entrance_scrolledge = 0x1491D; //0x14681 //8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
        public static int entrance_yscroll = 0x14D45; // 0x14AA9 //2bytes each room
        public static int entrance_xscroll = 0x14E4F; // 0x14BB3 //2bytes
        public static int entrance_yposition = 0x14F59; //0x14CBD 2bytes
        public static int entrance_xposition = 0x15063;// 0x14DC7 2bytes
        public static int entrance_camerayposition = 0x1516D;// 0x14ED1 2bytes
        public static int entrance_cameraxposition = 0x15277;// 0x14FDB 2bytes

        public static int entrance_gfx_group = 0x5D97;
        public static int entrance_blockset = 0x15381; //0x150E5 1byte
        public static int entrance_floor = 0x15406; // 0x1516A 1byte
        public static int entrance_dungeon = 0x1548B; // 0x151EF 1byte (dungeon id)
        public static int entrance_door = 0x15510; // 0x15274 1byte
        public static int entrance_ladderbg = 0x15595; //0x152F9 //1 byte, ---b ---a b = bg2, a = need to check -_-
        public static int entrance_scrolling = 0x1561A;//0x1537E //1byte --h- --v- 
        public static int entrance_scrollquadrant = 0x1569F; //0x15403 1byte
        public static int entrance_exit = 0x15724; //0x15488 //2byte word
        public static int entrance_music = 0x1582E; //0x15592

        public static int startingentrance_room = 0x15B6E; //0x158D2 //word value for each room
        public static int startingentrance_scrolledge = 0x15B7C; //0x158E0 //8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
        public static int startingentrance_yscroll = 0x15BB4; // 0x14AA9 //2bytes each room
        public static int startingentrance_xscroll = 0x15BC2; // 0x14BB3 //2bytes
        public static int startingentrance_yposition = 0x15BD0; //0x14CBD 2bytes
        public static int startingentrance_xposition = 0x15BDE;// 0x14DC7 2bytes
        public static int startingentrance_camerayposition = 0x15BEC;// 0x14ED1 2bytes
        public static int startingentrance_cameraxposition = 0x15BFA;// 0x14FDB 2bytes

        public static int startingentrance_blockset = 0x15C08; //0x150E5 1byte
        public static int startingentrance_floor = 0x15C0F; // 0x1516A 1byte
        public static int startingentrance_dungeon = 0x15C16; // 0x151EF 1byte (dungeon id)

        public static int startingentrance_door = 0x15C2B; // 0x15274 1byte

        public static int startingentrance_ladderbg = 0x15C1D; //0x152F9 //1 byte, ---b ---a b = bg2, a = need to check -_-
        public static int startingentrance_scrolling = 0x15C24;//0x1537E //1byte --h- --v- 
        public static int startingentrance_scrollquadrant = 0x15C2B; //0x15403 1byte
        public static int startingentrance_exit = 0x15C32; //0x15488 //2byte word
        public static int startingentrance_music = 0x15C4E; //0x15592
        public static int startingentrance_entrance = 0x15C40;

        public static int items_data_start = 0xDDE9; //save purpose
        public static int items_data_end = 0xE6B2; //save purpose
        public static int initial_equipement = 0x271A6;
        public static int messages_id_dungeon = 0x3F61D;

        public static int chests_backupitems = 0x3B528; //item id you get instead if you already have that item
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
        public static int dungeons_bossrooms = 0x10954;//short value

        //Bed Related Values (Starting location)

        public static int bedPositionX = 0x039A37; //short value
        public static int bedPositionY = 0x039A32; //short value

        public static int bedPositionResetXLow = 0x02DE53;  //short value(on 2 different bytes)
        public static int bedPositionResetXHigh = 0x02DE58; //^^^^^^

        public static int bedPositionResetYLow = 0x02DE5D; //short value(on 2 different bytes)
        public static int bedPositionResetYHigh = 0x02DE62;//^^^^^^

        public static int bedSheetPositionX = 0x0480BD; //short value
        public static int bedSheetPositionY = 0x0480B8; //short value

        //===========================================================================================
        //Gravestones related variables
        //===========================================================================================

        public static int GravesYTilePos = 0x49968; //short (0x0F entries)
        public static int GravesXTilePos = 0x49986; //short (0x0F entries)
        public static int GravesTilemapPos = 0x499A4; //short (0x0F entries)
        public static int GravesGFX = 0x499C2; //short (0x0F entries)

        public static int GravesXPos = 0x4994A;  //short (0x0F entries)
        public static int GravesYLine = 0x4993A; //short (0x08 entries)
        public static int GravesCountOnY = 0x499E0; //Byte 0x09 entries

        public static int GraveLinkSpecialHole = 0x46DD9; //short
        public static int GraveLinkSpecialStairs = 0x46DE0; //short

        //===========================================================================================
        //Palettes Related Variables - This contain all the palettes of the game
        //===========================================================================================
        public static int overworldPaletteMain = 0xDE6C8;
        public static int overworldPaletteAuxialiary = 0xDE86C;
        public static int overworldPaletteAnimated = 0xDE604;
        public static int globalSpritePalettesLW = 0xDD218;
        public static int globalSpritePalettesDW = 0xDD290;
        public static int armorPalettes = 0xDD308;//Green, Blue, Red, Bunny, Electrocuted (15 colors each)
        public static int spritePalettesAux1 = 0xDD39E; //7 colors each
        public static int spritePalettesAux2 = 0xDD446; //7 colors each
        public static int spritePalettesAux3 = 0xDD4E0; //7 colors each
        public static int swordPalettes = 0xDD630;//3 colors each - 4 entries
        public static int shieldPalettes = 0xDD648;//4 colors each - 3 entries
        public static int hudPalettes = 0xDD660;
        public static int dungeonMapPalettes = 0xDD70A; //21 colors
        public static int dungeonMainPalettes = 0xDD734;//(15*6) colors each - 20 entries
        public static int dungeonMapBgPalettes = 0xDE544; //16*6
        public static int hardcodedGrassLW = 0x5FEA9;//Mirrored Value at 0x75645 : 0x75625
        public static int hardcodedGrassDW = 0x05FEB3;//0x7564F;
        public static int hardcodedGrassSpecial = 0x75640;

        //===========================================================================================
        //Dungeon Map Related Variables
        //===========================================================================================
        public static int dungeonMap_rooms_ptr = 0x57605; //14 pointers of map data
        public static int dungeonMap_floors = 0x575D9; //14 words values

        public static int dungeonMap_gfx_ptr = 0x57BE4; //14 pointers of gfx data
        public static int dungeonMap_datastart = 0x57039; //data start for floors/gfx MUST skip 575D9 to 57621 (pointers)


        public static int dungeonMap_expCheck = 0x56652; //IF Byte = 0xB9 dungeon maps are not expanded
        public static int dungeonMap_tile16 = 0x57009;
        public static int dungeonMap_tile16Exp = 0x109010;
        public static int dungeonMap_bossrooms = 0x56807; //14 words values 0x000F = no boss

        public static int triforceVertices = 0x04FFD2; //group of 3, X, Y ,Z
        public static int TriforceFaces = 0x04FFE4; //group of 5

        public static int crystalVertices = 0x04FF98;

        public static bool Rando = false; //is it a rando rom?

        public static void Init_Jp(bool rando = false) {
            pit_pointer = 0x394A2;
            pit_count = 0x3949D;
            //04EF2F
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
            gfx_1_pointer = 0x67D0; //2byte pointer bank 00 -> pc 0x4FC0
            gfx_2_pointer = 0x67D5; //509F
            gfx_3_pointer = 0x67DA; //517E
            messages_id_dungeon = 0x3F5F7;
            gfx_animated_pointer = 0x10624;
            initial_equipement = 0x183000;

            //Entrances
            entrance_room = 0x14577; //word value for each room
            entrance_scrolledge = 0x1491D; //0x14681 //8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
            entrance_xscroll = 0x14AA9; //2bytes each room
            entrance_yscroll = 0x14BB3; //2bytes
            entrance_yposition = 0x14CBD;// 2bytes
            entrance_xposition = 0x14DC7;// 2bytes
            entrance_camerayposition = 0x14ED1;// 2bytes
            entrance_cameraxposition = 0x14FDB;// 2bytes
            entrance_blockset = 0x150E5;// 1byte
            entrance_floor = 0x1516A;// 1byte
            entrance_dungeon = 0x151EF;// 1byte (dungeon id)
            entrance_door = 0x15274;// 1byte
            entrance_ladderbg = 0x152F9; //1 byte, ---b ---a b = bg2, a = need to check -_-
            entrance_scrolling = 0x1537E; //1byte --h- --v- 
            entrance_scrollquadrant = 0x15403;// 1byte
            entrance_exit = 0x15488; //2byte word
            entrance_music = 0x15592;

            startingentrance_room -= 0x29C; //0x158D2 //word value for each room
            startingentrance_scrolledge -= 0x29C; //0x158E0 //8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
            startingentrance_yscroll -= 0x29C; // 0x14AA9 //2bytes each room
            startingentrance_xscroll -= 0x29C; // 0x14BB3 //2bytes
            startingentrance_yposition -= 0x29C; //0x14CBD 2bytes
            startingentrance_xposition -= 0x29C;// 0x14DC7 2bytes
            startingentrance_camerayposition -= 0x29C;// 0x14ED1 2bytes
            startingentrance_cameraxposition -= 0x29C;// 0x14FDB 2bytes

            startingentrance_blockset -= 0x29C; //0x150E5 1byte
            startingentrance_floor -= 0x29C; // 0x1516A 1byte
            startingentrance_dungeon -= 0x29C;// 0x151EF 1byte (dungeon id)

            startingentrance_door -= 0x29C; // 0x15274 1byte

            startingentrance_ladderbg -= 0x29C; //0x152F9 //1 byte, ---b ---a b = bg2, a = need to check -_-
            startingentrance_scrolling -= 0x29C;//0x1537E //1byte --h- --v- 
            startingentrance_scrollquadrant -= 0x29C; //0x15403 1byte
            startingentrance_exit -= 0x29C; //0x15488 //2byte word
            startingentrance_music -= 0x29C; //0x15592
            startingentrance_entrance -= 0x29C;

            //us = 0x05D97 / jp = 0x05DD7
            overworldgfxGroups = 0x05DD7;
            hardcodedGrassLW = 0x67FE6;
            hardcodedGrassDW = 0x67FF0;//map>40
            hardcodedGrassSpecial = 0x67FE1;//map 183,182,180

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

            overworldgfxGroups2 = 0x60B3; //

            /* public static int map32TilesTL = 0x18000;
             public static int map32TilesTR = 0x1B400;
             public static int map32TilesBL = 0x20000;
             public static int map32TilesBR = 0x23400;*/

            map32TilesTL = 0x18000;
            map32TilesTR = 0x1B3C0;
            map32TilesBL = 0x20000;
            map32TilesBR = 0x233C0;
            compressedAllMap32PointersHigh = 0x176B1; //LONGPointers all tiles of maps[High] (mapid* 3)
            compressedAllMap32PointersLow = 0x17891; //LONGPointers all tiles of maps[Low] (mapid* 3)
            overworldMapPalette = 0x7D1C; //JP
            overworldMapPaletteGroup = 0x67E74;
            overworldMapSize = 0x1273B; //JP
            overlayPointers = 0x3FAF4;
            overlayPointersBank = 0x07;
            overworldTilesType = 0x7FD94;
            Rando = rando;

            if (rando == true) {
                //TODO: Add condition here?
            }
        }











        //===========================================================================================
        // Names
        //===========================================================================================
        public static string[] RoomEffect = new string[]
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

        public static string[] RoomTag = new string[]
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
            "Nothing ", //22

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
            "$00 Nothing (standard floor)",
            "$01 Collision",
            "$02 Collision",
            "$03 Collision",
            "$04 Collision",
            "$05 Nothing (unused?)",
            "$06 Nothing (unused?)",
            "$07 Nothing (unused?)",
            "$08 Deep water",
            "$09 Shallow water",
            "$0A Unknown? Possibly unused",
            "$0B Collision (different in Overworld and unknown)",
            "$0C Overlay mask",
            "$0D Spike floor",
            "$0E GT ice",
            "$0F Ice palace ice",
            "$10 Slope ◤",
            "$11 Slope ◥",
            "$12 Slope ◣",
            "$13 Slope ◢",
            "$14 Nothing (unused?)",
            "$15 Nothing (unused?)",
            "$16 Nothing (unused?)",
            "$17 Nothing (unused?)",
            "$18 Slope ◤",
            "$19 Slope ◥",
            "$1A Slope ◣",
            "$1B Slope ◢",
            "$1C Layer 2 overlay",
            "$1D North single-layer auto stairs",
            "$1E North layer-swap auto stairs",
            "$1F North layer-swap auto stairs",
            "$20 Pit",
            "$21 Nothing (unused?)",
            "$22 Manual stairs",
            "$23 Pot switch",
            "$24 Pressure switch",
            "$25 Nothing (unused but referenced by somaria blocks)",
            "$26 Collision (near stairs?)",
            "$27 Brazier/Fence/Statue/Block/General hookable things",
            "$28 North ledge",
            "$29 South ledge",
            "$2A East ledge",
            "$2B West ledge",
            "$2C ◤ ledge",
            "$2D ◣ ledge",
            "$2E ◥ ledge",
            "$2F ◢ ledge",
            "$30 Straight inter-room stairs south/up 0",
            "$31 Straight inter-room stairs south/up 1",
            "$32 Straight inter-room stairs south/up 2",
            "$33 Straight inter-room stairs south/up 3",
            "$34 Straight inter-room stairs north/down 0",
            "$35 Straight inter-room stairs north/down 1",
            "$36 Straight inter-room stairs north/down 2",
            "$37 Straight inter-room stairs north/down 3",
            "$38 Straight inter-room stairs north/down edge",
            "$39 Straight inter-room stairs south/up edge",
            "$3A Star tile (inactive on load)",
            "$3B Star tile (active on load)",
            "$3C Nothing (unused?)",
            "$3D South single-layer auto stairs",
            "$3E South layer-swap auto stairs",
            "$3F South layer-swap auto stairs",
            "$40 Thick grass",
            "$41 Nothing (unused?)",
            "$42 Gravestone / Tower of hera ledge shadows??",
            "$43 Skull Woods entrance/Hera columns???",
            "$44 Spike",
            "$45 Nothing (unused?)",
            "$46 Desert Tablet",
            "$47 Nothing (unused?)",
            "$48 Diggable ground",
            "$49 Nothing (unused?)",
            "$4A Diggable ground",
            "$4B Warp tile",
            "$4C Nothing (unused?) | Something unknown in overworld",
            "$4D Nothing (unused?) | Something unknown in overworld",
            "$4E Square corners in EP overworld",
            "$4F Square corners in EP overworld",
            "$50 Green bush",
            "$51 Dark bush",
            "$52 Gray rock",
            "$53 Black rock",
            "$54 Hint tile/Sign",
            "$55 Big gray rock",
            "$56 Big black rock",
            "$57 Bonk rocks",
            "$58 Chest 0",
            "$59 Chest 1",
            "$5A Chest 2",
            "$5B Chest 3",
            "$5C Chest 4",
            "$5D Chest 5",
            "$5E Spiral stairs",
            "$5F Spiral stairs",
            "$60 Rupee tile",
            "$61 Nothing (unused?)",
            "$62 Bombable floor",
            "$63 Minigame chest",
            "$64 Nothing (unused?)",
            "$65 Nothing (unused?)",
            "$66 Crystal peg down",
            "$67 Crystal peg up",
            "$68 Upwards conveyor",
            "$69 Downwards conveyor",
            "$6A Leftwards conveyor",
            "$6B Rightwards conveyor",
            "$6C North vines",
            "$6D South vines",
            "$6E West vines",
            "$6F East vines",
            "$70 Pot/Hammer peg/Push block 00",
            "$71 Pot/Hammer peg/Push block 01",
            "$72 Pot/Hammer peg/Push block 02",
            "$73 Pot/Hammer peg/Push block 03",
            "$74 Pot/Hammer peg/Push block 04",
            "$75 Pot/Hammer peg/Push block 05",
            "$76 Pot/Hammer peg/Push block 06",
            "$77 Pot/Hammer peg/Push block 07",
            "$78 Pot/Hammer peg/Push block 08",
            "$79 Pot/Hammer peg/Push block 09",
            "$7A Pot/Hammer peg/Push block 0A",
            "$7B Pot/Hammer peg/Push block 0B",
            "$7C Pot/Hammer peg/Push block 0C",
            "$7D Pot/Hammer peg/Push block 0D",
            "$7E Pot/Hammer peg/Push block 0E",
            "$7F Pot/Hammer peg/Push block 0F",
            "$80 North/South door",
            "$81 East/West door",
            "$82 North/South shutter door",
            "$83 East/West shutter door",
            "$84 North/South layer 2 door",
            "$85 East/West layer 2 door",
            "$86 North/South layer 2 shutter door",
            "$87 East/West layer 2 shutter door",
            "$88 Some type of door (?)",
            "$89 East/West transport door",
            "$8A Some type of door (?)",
            "$8B Some type of door (?)",
            "$8C Some type of door (?)",
            "$8D Some type of door (?)",
            "$8E Entrance door",
            "$8F Entrance door",
            "$90 Layer toggle shutter door (?)",
            "$91 Layer toggle shutter door (?)",
            "$92 Layer toggle shutter door (?)",
            "$93 Layer toggle shutter door (?)",
            "$94 Layer toggle shutter door (?)",
            "$95 Layer toggle shutter door (?)",
            "$96 Layer toggle shutter door (?)",
            "$97 Layer toggle shutter door (?)",
            "$98 Layer+Dungeon toggle shutter door (?)",
            "$99 Layer+Dungeon toggle shutter door (?)",
            "$9A Layer+Dungeon toggle shutter door (?)",
            "$9B Layer+Dungeon toggle shutter door (?)",
            "$9C Layer+Dungeon toggle shutter door (?)",
            "$9D Layer+Dungeon toggle shutter door (?)",
            "$9E Layer+Dungeon toggle shutter door (?)",
            "$9F Layer+Dungeon toggle shutter door (?)",
            "$A0 North/South Dungeon swap door",
            "$A1 Dungeon toggle door (?)",
            "$A2 Dungeon toggle door (?)",
            "$A3 Dungeon toggle door (?)",
            "$A4 Dungeon toggle door (?)",
            "$A5 Dungeon toggle door (?)",
            "$A6 Nothing (unused?)",
            "$A7 Nothing (unused?)",
            "$A8 Layer+Dungeon toggle shutter door (?)",
            "$A9 Layer+Dungeon toggle shutter door (?)",
            "$AA Layer+Dungeon toggle shutter door (?)",
            "$AB Layer+Dungeon toggle shutter door (?)",
            "$AC Layer+Dungeon toggle shutter door (?)",
            "$AD Layer+Dungeon toggle shutter door (?)",
            "$AE Layer+Dungeon toggle shutter door (?)",
            "$AF Layer+Dungeon toggle shutter door (?)",
            "$B0 Somaria ─",
            "$B1 Somaria │",
            "$B2 Somaria ┌",
            "$B3 Somaria └",
            "$B4 Somaria ┐",
            "$B5 Somaria ┘",
            "$B6 Somaria ⍰ 1 way",
            "$B7 Somaria ┬",
            "$B8 Somaria ┴",
            "$B9 Somaria ├",
            "$BA Somaria ┤",
            "$BB Somaria ┼",
            "$BC Somaria ⍰ 2 way",
            "$BD Somaria ┼ crossover",
            "$BE Pipe entrance",
            "$BF Nothing (unused?)",
            "$C0 Torch 00",
            "$C1 Torch 01",
            "$C2 Torch 02",
            "$C3 Torch 03",
            "$C4 Torch 04",
            "$C5 Torch 05",
            "$C6 Torch 06",
            "$C7 Torch 07",
            "$C8 Torch 08",
            "$C9 Torch 09",
            "$CA Torch 0A",
            "$CB Torch 0B",
            "$CC Torch 0C",
            "$CD Torch 0D",
            "$CE Torch 0E",
            "$CF Torch 0F",
            "$D0 Nothing (unused?)",
            "$D1 Nothing (unused?)",
            "$D2 Nothing (unused?)",
            "$D3 Nothing (unused?)",
            "$D4 Nothing (unused?)",
            "$D5 Nothing (unused?)",
            "$D6 Nothing (unused?)",
            "$D7 Nothing (unused?)",
            "$D8 Nothing (unused?)",
            "$D9 Nothing (unused?)",
            "$DA Nothing (unused?)",
            "$DB Nothing (unused?)",
            "$DC Nothing (unused?)",
            "$DD Nothing (unused?)",
            "$DE Nothing (unused?)",
            "$DF Nothing (unused?)",
            "$E0 Nothing (unused?)",
            "$E1 Nothing (unused?)",
            "$E2 Nothing (unused?)",
            "$E3 Nothing (unused?)",
            "$E4 Nothing (unused?)",
            "$E5 Nothing (unused?)",
            "$E6 Nothing (unused?)",
            "$E7 Nothing (unused?)",
            "$E8 Nothing (unused?)",
            "$E9 Nothing (unused?)",
            "$EA Nothing (unused?)",
            "$EB Nothing (unused?)",
            "$EC Nothing (unused?)",
            "$ED Nothing (unused?)",
            "$EE Nothing (unused?)",
            "$EF Nothing (unused?)",
            "$F0 Door 0 bottom",
            "$F1 Door 1 bottom",
            "$F2 Door 2 bottom",
            "$F3 Door 3 bottom",
            "$F4 Door X bottom? (unused?)",
            "$F5 Door X bottom? (unused?)",
            "$F6 Door X bottom? (unused?)",
            "$F7 Door X bottom? (unused?)",
            "$F8 Door 0 top",
            "$F9 Door 1 top",
            "$FA Door 2 top",
            "$FB Door 3 top",
            "$FC Door X top? (unused?)",
            "$FD Door X top? (unused?)",
            "$FE Door X top? (unused?)",
            "$FF Door X top? (unused?)"
        };
    }
}
