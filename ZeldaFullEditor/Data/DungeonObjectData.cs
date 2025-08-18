using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data
{
    public static class DungeonObjectData
    {
        public static Tile[][] tiles = new Tile[0xF8][];
        public static void Load()
        {
            for (int i = 0; i < 0xF8; i++)
            {
                int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((i & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((i & 0xFF) * 2)]);
                tiles[i] = addTiles(subtype1Lengths[i], pos);
            }
        }

        public static Tile[] addTiles(int nbr, int pos)
        {
            Tile[] data = new Tile[nbr];
            for (int i = 0; i < nbr; i++)
            {
                data[i] = (new Tile(ROM.DATA[pos + ((i * 2))], ROM.DATA[pos + ((i * 2)) + 1]));
            }
            return data;
        }
        /*
        public static byte[] subtype1_routines = new byte[0xF8]
        {
            0, // RoomDraw_Rightwards2x2_1to15or32 (00)             0x00
            1, // RoomDraw_Rightwards2x4_1to15or26 (01)             0x01
            1, // RoomDraw_Rightwards2x4_1to15or26 (01)             0x02
            2, // RoomDraw_Rightwards2x4spaced4_1to16 (02)          0x03
            2, // RoomDraw_Rightwards2x4spaced4_1to16 (02)          0x04
            3, // RoomDraw_Rightwards2x4spaced4_1to16_BothBG (03)   0x05
            3, // RoomDraw_Rightwards2x4spaced4_1to16_BothBG (03)   0x06
            4, // RoomDraw_Rightwards2x2_1to16 (04)                 0x07
            4, // RoomDraw_Rightwards2x2_1to16 (04)                 0x08
            5, // RoomDraw_DiagonalAcute_1to16 (05)                 0x09
            6, // RoomDraw_DiagonalGrave_1to16 (06)                 0x0A
            6, // RoomDraw_DiagonalGrave_1to16 (06)                 0x0B
            5, // RoomDraw_DiagonalAcute_1to16 (05)                 0x0C
            5, // RoomDraw_DiagonalAcute_1to16 (05)                 0x0D
            6, // RoomDraw_DiagonalGrave_1to16 (06)                 0x0E
            6, // RoomDraw_DiagonalGrave_1to16 (06)                 0x0F

            5, // RoomDraw_DiagonalAcute_1to16 (05)                 0x10
            5, // RoomDraw_DiagonalAcute_1to16 (05)                 0x11
            6, // RoomDraw_DiagonalGrave_1to16 (06)                 0x12
            6, // RoomDraw_DiagonalGrave_1to16 (06)                 0x13
            5, // RoomDraw_DiagonalAcute_1to16 (05)                 0x14
            7, // RoomDraw_DiagonalAcute_1to16_BothBG               0x15
            8, // RoomDraw_DiagonalGrave_1to16_BothBG               0x16
            8, // RoomDraw_DiagonalGrave_1to16_BothBG               0x17
            7, // RoomDraw_DiagonalAcute_1to16_BothBG               0x18
            7, // RoomDraw_DiagonalAcute_1to16_BothBG               0x19
            8, // RoomDraw_DiagonalGrave_1to16_BothBG               0x1A
            8, // RoomDraw_DiagonalGrave_1to16_BothBG               0x1B
            7, // RoomDraw_DiagonalAcute_1to16_BothBG               0x1C
            7, // RoomDraw_DiagonalAcute_1to16_BothBG               0x1D
            8, // RoomDraw_DiagonalGrave_1to16_BothBG               0x1E
            8, // RoomDraw_DiagonalGrave_1to16_BothBG               0x1F

            7, // RoomDraw_DiagonalAcute_1to16_BothBG               0x20
            9, // RoomDraw_Rightwards1x2_1to16_plus2                0x21
            10,// RoomDraw_RightwardsHasEdge1x1_1to16_plus3         0x22
            11,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x23
            11,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x24
            11,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x25
            11,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x26
            11,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x27
            11,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x28
            11,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x29
            11,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x2A
            11,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x2B
            11,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x2C
            11,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x2D
            11,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x2E
            12,// RoomDraw_RightwardsTopCorners1x2_1to16_plus13     0x2F

            13,// RoomDraw_RightwardsBottomCorners1x2_1to16_plus13  0x30
            14,// CUSTOMDRAW                                        0x31
            14,// CUSTOMDRAW                                        0x32
            15,// RoomDraw_Rightwards4x4_1to16                      0x33
            16,// RoomDraw_Rightwards1x1Solid_1to16_plus3           0x34
            17,// RoomDraw_DoorSwitcherer                           0x35
            18,// RoomDraw_RightwardsDecor4x4spaced2_1to16          0x36
            18,// RoomDraw_RightwardsDecor4x4spaced2_1to16          0x37
            19,// RoomDraw_RightwardsStatue2x3spaced2_1to16         0x38
            20,// RoomDraw_RightwardsPillar2x4spaced4_1to16         0x39
            21,// RoomDraw_RightwardsDecor4x3spaced4_1to16          0x3A
            21,// RoomDraw_RightwardsDecor4x3spaced4_1to16          0x3B
            22,// RoomDraw_RightwardsDoubled2x2spaced2_1to16        0x3C
            20,// RoomDraw_RightwardsPillar2x4spaced4_1to16         0x3D
            23,// RoomDraw_RightwardsDecor2x2spaced12_1to16         0x3E
            24,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x3F
            24,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x40
            24,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x41
            24,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x42
            24,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x43
            24,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x44
            24,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x45
            24,// RoomDraw_RightwardsHasEdge1x1_1to16_plus2         0x46
            25,// RoomDraw_Waterfall47                              0x47
            26,// RoomDraw_Waterfall48                              0x48
            27,// RoomDraw_RightwardsFloorTile4x2_1to16             0x49
            27,// RoomDraw_RightwardsFloorTile4x2_1to16             0x4A
            23,// RoomDraw_RightwardsDecor2x2spaced12_1to16         0x4B
            28,// RoomDraw_RightwardsBar4x3_1to16                   0x4C
            29,// RoomDraw_RightwardsShelf4x4_1to16                 0x4D
            29,// RoomDraw_RightwardsShelf4x4_1to16                 0x4E
            29,// RoomDraw_RightwardsShelf4x4_1to16                 0x4F
            30,// RoomDraw_RightwardsLine1x1_1to16plus1             0x50
            31,// RightwardsCannonHole4x3_1to16                     0x51
            31,// RightwardsCannonHole4x3_1to16                     0x52
            4, // RoomDraw_Rightwards2x2_1to16                      0x53
            14,// CUSTOMDRAW                                        0x54
            32,// RoomDraw_RightwardsDecor4x2spaced8_1to16          0x55
            32,// RoomDraw_RightwardsDecor4x2spaced8_1to16          0x56
            14,// CUSTOMDRAW                                        0x57
            14,// CUSTOMDRAW                                        0x58
            14,// CUSTOMDRAW                                        0x59
            14,// CUSTOMDRAW                                        0x5A
            31,// RightwardsCannonHole4x3_1to16                     0x5B
            31,// RightwardsCannonHole4x3_1to16                     0x5C
            33,// RoomDraw_RightwardsBigRail1x3_1to16plus5          0x5D
            34,// RoomDraw_RightwardsBlock2x2spaced2_1to16          0x5E
            35,// RoomDraw_RightwardsHasEdge1x1_1to16_plus23        0x5F
            36,// RoomDraw_Downwards2x2_1to15or32                   0x60
            37,// RoomDraw_Downwards4x2_1to15or26                   0x61
            37,// RoomDraw_Downwards4x2_1to15or26                   0x62
            38,// RoomDraw_Downwards4x2_1to16_BothBG                0x63
            38,// RoomDraw_Downwards4x2_1to16_BothBG                0x64
            39,// RoomDraw_DownwardsDecor4x2spaced4_1to16           0x65
            39,// RoomDraw_DownwardsDecor4x2spaced4_1to16           0x66
            40,// RoomDraw_Downwards2x2_1to16                       0x67
            40,// RoomDraw_Downwards2x2_1to16                       0x68
            41,// RoomDraw_DownwardsHasEdge1x1_1to16_plus3          0x69
            42,// RoomDraw_DownwardsEdge1x1_1to16                   0x6A
            42,// RoomDraw_DownwardsEdge1x1_1to16                   0x6B
            43,// RoomDraw_DownwardsLeftCorners2x1_1to16_plus12     0x6C
            44,// RoomDraw_DownwardsRightCorners2x1_1to16_plus1     0x6D
            14,// CUSTOMDRAW                                        0x6E
            14,// CUSTOMDRAW                                        0x6F
            45,// RoomDraw_DownwardsFloor4x4_1to16                  0x70
            46,// RoomDraw_Downwards1x1Solid_1to16_plus3            0x71
            14,// CUSTOMDRAW                                        0x72
            47,// RoomDraw_DownwardsDecor4x4spaced2_1to16           0x73
            47,// RoomDraw_DownwardsDecor4x4spaced2_1to16           0x74
            48,// RoomDraw_DownwardsPillar2x4spaced2_1to16          0x75
            49,// RoomDraw_DownwardsDecor3x4spaced4_1to16           0x76
            49,// RoomDraw_DownwardsDecor3x4spaced4_1to16           0x77
            50,// RoomDraw_DownwardsDecor2x2spaced12_1to16          0x78
            42,// RoomDraw_DownwardsEdge1x1_1to16                   0x79
            42,// RoomDraw_DownwardsEdge1x1_1to16                   0x7A
            50,// RoomDraw_DownwardsDecor2x2spaced12_1to16          0x7B
            51,// RoomDraw_DownwardsLine1x1_1to16plus1              0x7C
            40,// RoomDraw_Downwards2x2_1to16                       0x7D
            14,// CUSTOMDRAW                                        0x7E
            52,// RoomDraw_DownwardsDecor2x4spaced8_1to16           0x7F
            52,// RoomDraw_DownwardsDecor2x4spaced8_1to16           0x80
            53,// RoomDraw_DownwardsDecor3x4spaced2_1to16           0x81
            53,// RoomDraw_DownwardsDecor3x4spaced2_1to16           0x82
            53,// RoomDraw_DownwardsDecor3x4spaced2_1to16           0x83
            53,// RoomDraw_DownwardsDecor3x4spaced2_1to16           0x84
            54,// RoomDraw_DownwardsCannonHole3x4_1to16             0x85
            54,// RoomDraw_DownwardsCannonHole3x4_1to16             0x86
            48,// RoomDraw_DownwardsPillar2x4spaced2_1to16          0x87
            55,// RoomDraw_DownwardsBigRail3x1_1to16plus5           0x88
            56,// RoomDraw_DownwardsBlock2x2spaced2_1to16           0x89
            57,// RoomDraw_DownwardsHasEdge1x1_1to16_plus23         0x8A
            58,// RoomDraw_DownwardsEdge1x1_1to16plus7              0x8B
            59,// RoomDraw_DownwardsEdge1x1_1to16plus7              0x8C
            60,// RoomDraw_DownwardsEdge1x1_1to16                   0x8D
            61,// RoomDraw_DownwardsEdge1x1_1to16                   0x8E
            62,// RoomDraw_DownwardsBar2x5_1to16                    0x8F
            63,// RoomDraw_Downwards4x2_1to15or26                   0x90
        }

        */
        public static byte[] subtype1Lengths = new byte[0xF8]
        {
            04,08,08,08,08,08,08,04,04,05,05,05,05,05,05,05,
            05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,05,
            05,09,03,03,03,03,03,03,03,03,03,03,03,03,03,06,
            06,01,01,16,01,01,16,16,06,08,12,12,04,08,04,03,
            03,03,03,03,03,03,03,00,00,08,08,04,09,16,16,16,
            01,18,18,04,01,08,08,01,01,01,01,18,18,15,04,03,
            04,08,08,08,08,08,08,04,04,03,01,01,06,06,01,01,
            16,01,01,16,16,08,16,16,04,01,01,04,01,04,01,08,
            08,12,12,12,12,18,18,08,12,04,03,03,03,01,01,06,
            08,08,04,04,16,04,04,01,01,01,01,01,01,01,01,01,
            01,01,01,01,24,01,01,01,01,01,01,01,01,01,01,01,
            01,01,16,03,03,08,08,08,04,04,16,04,04,04,01,01,
            01,68,01,01,08,08,08,08,08,08,08,01,01,28,28,01,
            01,08,08,00,00,00,00,01,08,08,08,08,21,16,04,08,
            08,08,08,08,08,08,08,08,08,01,01,01,01,01,01,01,
            01,01,01,01,01,01,01,01
        };
    }
}
