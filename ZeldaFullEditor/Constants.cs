using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public static class Constants
    {

        
        //===========================================================================================
        //GFX Related Variables
        //===========================================================================================
        public static int tile_address = 0x1B52; // JP = Same //i don't think that need a pointer
        public static int tile_address_floor = 0x1B5A; // JP = Same //i don't think that need a pointer
        public static int subtype1_tiles = 0x8000; // JP = Same //i don't think that need a pointer
        public static int subtype2_tiles = 0x83F0; // JP = Same //i don't think that need a pointer
        public static int subtype3_tiles = 0x84F0; // JP = Same //i don't think that need a pointer
        public static int gfx_animated_pointer = 0x10275; //JP 0x10624 //long pointer

        public static int gfx_1_pointer = 0x6790; //2byte pointer bank 00 pc -> 0x4320
        public static int gfx_2_pointer = 0x6795;
        public static int gfx_3_pointer = 0x679A;
        public static int hud_palettes = 0xDD660;

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
        public static int overworldSpritePalette = 0x7B81;
        public static int overworldMapPaletteGroup = 0x75504;
        public static int overworldSpriteset = 0x7A81;
        public static int overworldSpritesBegining = 0x4C881;
        public static int overworldSpritesLW = 0x4C901;
        public static int overworldSpritesDW = 0x4CA21;
        public static int overworldItemsPointers = 0xDC2F9;
        public static int overworldItemsBank = 0x1B;
        public static int overworldMapSize = 0x12844;
        public static int hardcodedGrassLW = 0x75645;
        public static int hardcodedGrassDW = 0x7564F;
        public static int hardcodedGrassSpecial = 0x75640;
        public static int mapGfx = 0x7C9C;
        public static int overlayPointers = 0x77664;
        public static int overlayPointersBank = 0x0E;
        public static int overworldTilesType = 0x71459;
        //===========================================================================================
        //Overworld Exits/Entrances Variables
        //===========================================================================================
        public static int OWExitRoomId = 0x15D8A;
        public static int OWExitMapId = 0x15E28;
        public static int OWExitVram = 0x15E77;
        public static int OWExitYScroll = 0x15F15;
        public static int OWExitXScroll = 0x15FB3;
        public static int OWExitYPlayer = 0x16051;
        public static int OWExitXPlayer = 0x160EF;
        public static int OWExitYCamera = 0x1618D;
        public static int OWExitXCamera = 0x1622B;
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

        //===========================================================================================
        //Dungeon Related Variables
        //===========================================================================================
        //That could be turned into a pointer : 
        public static int dungeons_palettes_groups = 0x75460; //JP 0x67DD0
        public static int dungeons_main_bg_palette_pointers = 0xDEC4B; //JP Same
        public static int dungeons_palettes = 0xDD734; //JP Same (where all dungeons palettes are) 

        //That could be turned into a pointer : 
        public static int room_items_pointers = 0xDB69;//JP 0xDB67

        public static int rooms_sprite_pointer = 0x4C298; //JP Same //2byte bank 04
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
        public static int sprites_data = 0x4D880; //JP : //It use the unused pointers to have more space //Save purpose
        public static int sprites_data_empty_room = 0x4D87E;

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
        public static int startingentrance_scrolling = 0x1561A;//0x1537E //1byte --h- --v- 
        public static int startingentrance_scrollquadrant = 0x1569F; //0x15403 1byte
        public static int startingentrance_exit = 0x15C32; //0x15488 //2byte word
        public static int startingentrance_music = 0x15C4E; //0x15592
        public static int startingentrance_entrance = 0x15C40;

        public static int items_data_start = 0xDDE9; //save purpose
        public static int items_data_end = 0xE6B2; //save purpose
        public static int initial_equipement = 0x271A6;
        public static int messages_id_dungeon = 0x3F61D;

        public static string[] RoomEffect = new string[]
        {
            "Nothing", "01", "Moving Floor", "Moving Water", "04", "Red Flashes", "Light Torchto See Floor", "Ganon Room"
        };

        public static string[] RoomTag = new string[]
        {
            "Nothing", "NW Kill Enemy to Open", "NE Kill Enemy to Open", "SW Kill Enemy to Open", "SE Kill Enemy to Open", "W Kill Enemy to Open", "E Kill Enemy to Open", "N Kill Enemy to Open", "S Kill Enemy to Open", "Clear Quadrant to Open", "Clear Room to Open",
            "NW Push Block to Open", "NE Push Block to Open", "SW Push Block to Open", "SE Push Block to Open", "W Push Block to Open", "E Push Block to Open", "N Push Block to Open", "S Push Block to Open", "Push Block to Open", "Pull Lever to Open", "Clear Level to Open",
            "Switch Open Door(Hold)","Switch Open Door(Toggle)","Turn off Water","Turn on Water","Water Gate","Water Twin","Secret Wall Right", "Secret Wall Left", "Crash","Crash","Pull Switch to bomb Wall","Holes 0","Open Chest (Holes 0)","Holes 1", "Holes 2","Kill Enemy to clear level",
            "SE Kill enemy to move block","Trigger activated Chest","Pull lever to bomb wall","NW Kill Enemy for chest", "NE Kill Enemy for chest", "SW Kill Enemy for chest", "SE Kill Enemy for chest", "W Kill Enemy for chest", "E Kill Enemy for chest", "N Kill Enemy for chest", "S Kill Enemy for chest", "Clear Quadrant for chest", "Clear Room for chest",
            "Light Torches to open","Holes 3","Holes 4","Holes 5","Holes 6","Agahnim Room","Holes 7","Holes 8","Open Chest for Holes 8","Push block for Chest","Kill to open Ganon Door","Light Torches to get Chest","Kill boss Again"
        };


        //TODO : On ROM Load if Pointers are at original location
        //Expand ROM to 2MB if US, 4MB if VT, move Headers to new location
        public static bool Rando = false; //is it a rando rom?
        public static void Init_Jp(bool rando = false)
        {
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
            entrance_yscroll = 0x14AA9; //2bytes each room
            entrance_xscroll = 0x14BB3; //2bytes
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
            if (rando == true)
            {

            }
        }



    }
}
