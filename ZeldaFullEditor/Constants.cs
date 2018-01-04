﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public static class Constants
    {

        public static int tile_address = 0x1B52; // JP = Same //i don't think that need a pointer
        public static int tile_address_floor = 0x1B5A; // JP = Same //i don't think that need a pointer

        public static int subtype1_tiles = 0x8000; // JP = Same //i don't think that need a pointer
        public static int subtype2_tiles = 0x83F0; // JP = Same //i don't think that need a pointer
        public static int subtype3_tiles = 0x84F0; // JP = Same //i don't think that need a pointer

       

        public static int gfx_animated_pointer = 0x10275; //JP 0x10624 //long pointer

        //That could be turned into a pointer : 
        public static int dungeons_palettes_groups = 0x75460; //JP 0x67DD0
        public static int dungeons_main_bg_palette_pointers = 0xDEC4B; //JP Same
        public static int dungeons_palettes = 0xDD734; //JP Same (where all dungeons palettes are) 

        //That could be turned into a pointer : 
        public static int room_items_pointers = 0xDB69;//JP 0xDB67

        public static int rooms_sprite_pointer = 0x4C298; //JP Same //2byte bank 04
        public static int room_header_pointer = 0xB5DD; //LONG
        public static int room_header_pointers_bank = 0xB5E7; //JP Same

        public static int gfx_1_pointer = 0x6790; //2byte pointer bank 00 pc -> 0x4320
        public static int gfx_2_pointer = 0x6795;
        public static int gfx_3_pointer = 0x679A;

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
        public static int sprite_blockset_pointer = 0x5B57;
        public static int sprites_data = 0x4D880; //JP : //It use the unused pointers to have more space //Save purpose
        public static int sprites_data_empty_room = 0x4D87E;

        public static int pit_pointer = 0x394AB;
        public static int pit_count = 0x394A6;
        //doors
        public static int door_gfx_up = 0x4D9E;
        public static int door_gfx_down = 0x4E06;
        public static int door_gfx_left = 0x4E66;
        public static int door_gfx_right = 0x4EC6;

        public static int door_pos_up = 0x197E;
        public static int door_pos_down = 0x1996;
        public static int door_pos_left = 0x19AE;
        public static int door_pos_right = 0x19C6;


        //Entrances

        public static int entrance_room = 0x14813; //0x14577 //word value for each room
        public static int entrance_scrolledge = 0x1491D; //0x14681 //8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
        public static int entrance_yscroll = 0x14D45; // 0x14AA9 //2bytes each room
        public static int entrance_xscroll = 0x14E4F; // 0x14BB3 //2bytes
        public static int entrance_yposition = 0x14F59; //0x14CBD 2bytes
        public static int entrance_xposition = 0x15063;// 0x14DC7 2bytes
        public static int entrance_camerayposition = 0x1516D;// 0x14ED1 2bytes
        public static int entrance_cameraxposition = 0x15277;// 0x14FDB 2bytes
        public static int entrance_blockset = 0x15381; //0x150E5 1byte
        public static int entrance_floor = 0x15406; // 0x1516A 1byte
        public static int entrance_dungeon = 0x1548B; // 0x151EF 1byte (dungeon id)
        public static int entrance_door = 0x15510; // 0x15274 1byte
        public static int entrance_ladderbg = 0x15595; //0x152F9 //1 byte, ---b ---a b = bg2, a = need to check -_-
        public static int entrance_scrolling = 0x1561A;//0x1537E //1byte --h- --v- 
        public static int entrance_scrollquadrant = 0x1569F; //0x15403 1byte
        public static int entrance_exit = 0x15724; //0x15488 //2byte word
        public static int entrance_music = 0x1582E; //0x15592
        public static int items_data_start = 0xDDE9; //save purpose
        public static int items_data_end = 0xE6B2; //save purpose


        public static int game_font = 0x70000;
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
            game_font = 0x70000; //compressed 2bpp
            //04EF2F
            dungeons_palettes_groups = 0x67DD0;
            room_items_pointers = 0xDB67;
            torch_data = 0x2704A;
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
            gfx_2_pointer = 0x67D5;
            gfx_3_pointer = 0x67DA;

            gfx_animated_pointer = 0x10624;

            

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



            Rando = rando;
            if (rando == true)
            {

            }
        }



    }
}
