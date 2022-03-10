using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public static class DoorData
    {
        //public byte[] door_index = new byte[] { 0x00, 0x02, 0x04, 0x06, 0x08, 0x40, 0x1C, 0x26, 0x0C, 0x44, 0x18, 0x36, 0x38, 0x1E, 0x2E, 0x28, 0x46, 0x0E, 0x0A, 0x30, 0x12, 0x16, 0x32, 0x20, 0x14, 0x2A, 0x22, 0x10 };

        public static Dictionary<byte, string> doors = new Dictionary<byte, string>
        {
            {0x00, "0x00 Normal Door"},
            {0x02, "0x02 Normal Door Layer2"},
            {0x04, "0x04 Cave Entrance Layer2"},
            {0x06, "0x06 Entrance Layer2"},
            {0x08, "0x08 Waterfall Layer2"},
            {0x0A, "0x0A Dungeon Entrance (Bottom Only)"},
            {0x0C, "0x0C Dungeon Entrance Layer2 (Bottom Only)"},
            {0x0E, "0x0E Cave Entrance (Bottom Only)"},
            {0x10, "0x10 Lit Cave Entrance (Bottom Only)"},
            {0x12, "0x12 Exit (Combine with other door)"},
            {0x14, "0x14 Throne Room Door"},
            {0x16, "0x16 To Bg2 (Combine with other door)"},
            {0x18, "0x18 Shutter Door (Both side)"},
            {0x1A, "0x1A Eye Watch Door"},
            {0x1C, "0x1C SmallKey Locked Door"},
            {0x1E, "0x1E BigKey Locked Door (Top Only)"},
            {0x20, "0x20 SmallKey Mask (Stairs Upwards)"},
            {0x22, "0x22 SmallKey Mask (Stairs Downwards)"},
            {0x24, "0x24 SmallKey Mask Layer2 (Stairs Upwards)"},
            {0x26, "0x26 SmallKey Mask Layer2 (Stairs Downwards)"},
            {0x28, "0x28 Bomb hole (Dash)"},
            {0x2A, "0x2A Bomb Entrance (Bottom Only)"},
            {0x2C, "0x2C (UNUSABLE) Big Key Door Both"},
            {0x2E, "0x2E Bomb Door"},
            {0x30, "0x30 Explosion Wall (triggered by switch)"},
            {0x32, "0x32 Curtain Door"},
            {0x34, "0x34 (UNUSABLE) Bottom Shutter Door"},
            {0x36, "0x36 Shutter Door (Trap Bottom)"},
            {0x38, "0x38 Shutter Door (Trap Top)"},
            {0x3A, "0x3A (UNUSABLE)"},
            {0x3C, "0x3C (UNUSABLE)"},
            {0x3E, "0x3E (UNUSABLE)"},
            {0x40, "0x40 Normal Door Layer2 (Combine Shutter)"},
            {0x42, "0x42 (UNUSABLE)"},
            {0x44, "0x44 Shutter Door Layer2"},
            {0x46, "0x46 Layer 2 Warp Door"},
            {0x48, "0x48 Shutter Door Layer2 (Trap Bottom)"},
            {0x4A, "0x4A Shutter Door Layer2 (Trap Top)"},
            {0x4C, "0x4C (UNUSABLE)"},
            {0x4E, "0x4E (UNUSABLE)"},
            {0x50, "0x50 (UNUSABLE)"},
            {0x52, "0x52 (UNUSABLE)"},
            {0x54, "0x54 (UNUSABLE)"},
            {0x56, "0x56 (UNUSABLE)"},
            {0x58, "0x58 (UNUSABLE)"},
            {0x5A, "0x5A (UNUSABLE)"},
            {0x5C, "0x5C (UNUSABLE)"},
            {0x5E, "0x5E (UNUSABLE)"},
            {0x60, "0x60 (UNUSABLE)"},
            {0x62, "0x62 (UNUSABLE)"},
            {0x64, "0x64 (UNUSABLE)"},
            {0x66, "0x66 (UNUSABLE)"},
        };
    }
}
