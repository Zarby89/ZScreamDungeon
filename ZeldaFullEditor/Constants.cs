using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public static class Constants
    {
        public static int tile_address = 0x1B52; // JP = Same
        public static int tile_address_floor = 0x1B5A; // JP = Same
        public static int subtype1_tiles = 0x8000; // JP = Same
        public static int subtype2_tiles = 0x83F0; // JP = Same
        public static int subtype3_tiles = 0x84F0; // JP = Same
        public static int gfx_pointer_1 = 0x4F80; //JP = 0x4FC0
        public static int gfx_pointer_2 = 0x505F; //JP = 0x509F
        public static int gfx_pointer_3 = 0x513E; //JP = 0x517E
        public static int gfx_groups = 0x6073; //JP = 0x60B3
        public static int gfx_animated = 0x1011E; //JP = 0x1002E //Use ROM.DATA[gfx_groups]
        public static int dungeons_palettes_groups = 0x75460; //JP 0x67DD0
        public static int dungeons_main_bg_palette_pointers = 0xDEC4B; //JP Same
        public static int dungeons_palettes = 0xDD734; //JP Same (where all dungeons palettes are) 
        public static int room_object_pointers = 0xF8000; //JP Same (3 bytes LONG pointers)
        public static int room_object_layout_pointers = 0x26F2F; //JP 0x26C0F 00027065
        public static int room_items_pointers = 0xDB69;//JP 0xDB67
        public static int room_sprites_pointers = 0x4D62E; //JP same
        public static int room_header_pointers = 0x27502; //JP 0x271E2
        public static int room_header_pointers_bank = 0xB5E7; //JP Same
        public static int room_chest = 0xE96E; //JP 0xE96C
        public static int block_data = 0x271DE; //JP 0x26EBE
        public static int torch_data = 0x2736A; //JP 0x2704A
        public static int sprite_blockset_pointer = 0x5B57;
        //0000
        //TODO : On ROM Load if Pointers are at original location
        //Expand ROM to 2MB if US, 4MB if VT, move Headers to new location
        public static void Init_Jp()
        {
            //04EF2F
            gfx_pointer_1 = 0x4FC0;
            gfx_pointer_2 = 0x509F;
            gfx_pointer_3 = 0x517E;
            dungeons_palettes_groups = 0x67DD0;
            room_items_pointers = 0xDB67;
            room_object_layout_pointers = 0x26C0F;
            room_header_pointers = 0x271E2;
            gfx_groups = 0x60B3;
            gfx_animated = 0x1002E;
            room_chest = 0xE96C;
            block_data = 0x26EBE;
            torch_data = 0x2704A;
        }


    }
}
