using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public static class OverworldGlobal
    {

        public static List<ExitOW> exits = new List<ExitOW>();
        public static void loadExits()
        {
            for (int i = 0; i < 0x4F; i++)
            {
                short[] e = new short[13];
                e[0] = (short)((ROM.DATA[Constants.OWExitRoomId + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitRoomId + (i * 2)]));
                e[1] = (byte)((ROM.DATA[Constants.OWExitMapId + i]));
                e[2] = (short)((ROM.DATA[Constants.OWExitVram + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitVram + (i * 2)]));
                e[3] = (short)((ROM.DATA[Constants.OWExitYScroll + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitYScroll + (i * 2)]));
                e[4] = (short)((ROM.DATA[Constants.OWExitXScroll + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitXScroll + (i * 2)]));
                e[5] = (short)((ROM.DATA[Constants.OWExitYPlayer + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitYPlayer + (i * 2)]));
                e[6] = (short)((ROM.DATA[Constants.OWExitXPlayer + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitXPlayer + (i * 2)]));
                e[7] = (short)((ROM.DATA[Constants.OWExitYCamera + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitYCamera + (i * 2)]));
                e[8] = (short)((ROM.DATA[Constants.OWExitXCamera + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWExitXCamera + (i * 2)]));
                e[9] = (byte)((ROM.DATA[Constants.OWExitUnk1+i]));
                e[10] = (byte)((ROM.DATA[Constants.OWExitUnk2+i]));
                e[11] = (byte)((ROM.DATA[Constants.OWExitDoorType1+i]));
                e[12] = (byte)((ROM.DATA[Constants.OWExitDoorType2+i]));
                exits.Add(new ExitOW(e[0], (byte)e[1], e[2], e[3], e[4], e[5], e[6], e[7], e[8], (byte)e[9], (byte)e[10], (byte)e[11], (byte)e[12]));

            }
        }


        public static List<EntranceOW> entrances = new List<EntranceOW>();
        public static void loadEntrances()
        {
            for (int i = 0; i < 0x81; i++)
            {
                short[] e = new short[13];
                e[0] = (short)((ROM.DATA[Constants.OWEntranceMap + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWEntranceMap + (i * 2)]));
                e[1] = (short)((ROM.DATA[Constants.OWEntrancePos + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWEntrancePos + (i * 2)]));
                e[2] = (short)((ROM.DATA[Constants.OWEntranceEntranceId + i]));
                entrances.Add(new EntranceOW(e[0], e[1], (byte)e[2]));
            }

        }

        public static List<EntranceOW> Holes = new List<EntranceOW>();
        public static void loadHoles()
        {
            for (int i = 0; i < 0x13; i++)
            {
                short[] e = new short[13];
                e[0] = (short)((ROM.DATA[Constants.OWHoleArea + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWHoleArea + (i * 2)]));
                e[1] = (short)((ROM.DATA[Constants.OWHolePos + (i * 2) + 1] << 8) + (ROM.DATA[Constants.OWHolePos + (i * 2)]));
                e[2] = (short)((ROM.DATA[Constants.OWHoleEntrance + i]));
                Holes.Add(new EntranceOW(e[0], e[1], (byte)e[2]));
            }

        }


    }
}
