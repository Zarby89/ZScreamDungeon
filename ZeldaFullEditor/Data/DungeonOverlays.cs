using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ZeldaFullEditor.Room_Object;

namespace ZeldaFullEditor.Data
{
    public static class DungeonOverlays
    {
        public static List<Room_Object> loadedOverlay = new List<Room_Object>();
        public static List<Room_Object>[] overlays = new List<Room_Object>[0x14];
        public static void LoadOverlays()
        {
            int pointer = ROM.ReadLong(Constants.DungeonOverlayLoadPtr); // pointer of ptrs list
            pointer = Utils.SnesToPc(pointer);


            for (int i = 0; i < 0x14; i++)
            {
                int pointerdata = ROM.ReadLong(pointer + (i * 3)); // pointer of ptrs list
                pointerdata = Utils.SnesToPc(pointerdata);

                if (i == 0x13)
                {
                    pointerdata = Utils.SnesToPc(ROM.ReadShort(Constants.DungeonOverlayWaterPtr1) + (ROM.ReadByte(Constants.DungeonOverlayWaterPtr1Bank)<<16));
                }
                int pos = pointerdata;
                byte b1 = 0;
                byte b2 = 0;
                byte b3 = 0;
                byte posX = 0;
                byte posY = 0;
                byte sizeX = 0;
                byte sizeY = 0;
                byte sizeXY = 0;
                ushort oid = 0;
                int layer = 0;
                overlays[i] = new List<Room_Object>();
                while (true)
                {
                    b1 = ROM.DATA[pos];
                    b2 = ROM.DATA[pos + 1];

                    if (b1 == 0xFF && b2 == 0xFF)
                    {
                        break;
                    }

                    b3 = ROM.DATA[pos + 2];
                    pos += 3; // We advance to next object for next loop

                    if (b3 >= 0xF8)
                    {
                        oid = (ushort)((b3 << 4) | 0x80 + (((b2 & 0x03) << 2) + ((b1 & 0x03))));
                        posX = (byte)((b1 & 0xFC) >> 2);
                        posY = (byte)((b2 & 0xFC) >> 2);
                        sizeXY = (byte)((((b1 & 0x03) << 2) + (b2 & 0x03)));
                    }
                    else // Subtype1
                    {
                        oid = b3;
                        posX = (byte)((b1 & 0xFC) >> 2);
                        posY = (byte)((b2 & 0xFC) >> 2);
                        sizeX = (byte)((b1 & 0x03));
                        sizeY = (byte)((b2 & 0x03));
                        sizeXY = (byte)(((sizeX << 2) + sizeY));
                    }
                    if (b1 >= 0xFC) // Subtype2 (not scalable?)
                    {
                        oid = (ushort)((b3 & 0x3F) + 0x100);
                        posX = (byte)(((b2 & 0xF0) >> 4) + ((b1 & 0x3) << 4));
                        posY = (byte)(((b2 & 0x0F) << 2) + ((b3 & 0xC0) >> 6));
                        sizeXY = 0;
                    }

                    Room_Object r = DungeonsData.AllRooms[0].addObject(oid, posX, posY, sizeXY, (byte)layer);
                    if (r != null)
                    {
                        r.options = ObjectOption.Overlay;
                        overlays[i].Add(r);
                    }
                }


            }

            loadedOverlay = overlays[0];
        }


        public static bool SaveOverlays()
        {

            // move the new pointer main pointer to 04EC1C instead of 04ECC0
            // no need to change anything else the load code will adapt to that pointer
            ROM.WriteLong(Constants.DungeonOverlayLoadPtr,Utils.PcToSnes(Constants.DungeonOverlayNewPosition));
            ROM.WriteLong(Constants.DungeonOverlayLoadPtr2, Utils.PcToSnes(Constants.DungeonOverlayNewPosition+1));
            


            int writingPtrPos = Constants.DungeonOverlayNewPosition; // +0x36 to skip the 0x12 pointers
            int writingDataPos = Constants.DungeonOverlayNewPosition+0x36;

            



            List<byte> objectsBytes = new List<byte>();
            for (int i = 0; i < overlays.Length; i++)
            {

                if (i == 0x13) // if it's water overlay then save pointer somewhere else
                {
                    // write the new water position at the end
                    int waterAddr = Utils.PcToSnes(writingDataPos);
                    ROM.WriteShort(Constants.DungeonOverlayWaterPtr1, waterAddr);
                    ROM.WriteShort(Constants.DungeonOverlayWaterPtr2, waterAddr);

                    ROM.Write(Constants.DungeonOverlayWaterPtr1Bank, (byte)(waterAddr>>16));
                    ROM.Write(Constants.DungeonOverlayWaterPtr2Bank, (byte)(waterAddr>>16));
                }
                else
                {
                    // write pointer of the new writing address
                    ROM.WriteLong(writingPtrPos, Utils.PcToSnes(writingDataPos));
                    writingPtrPos += 3;
                }

                objectsBytes.Clear();
                for (int j = 0; j < overlays[i].Count; j++) 
                {
                    Room_Object o = overlays[i][j];

                    // xxxxxxss yyyyyyss iiiiiiii
                    if (o.Size > 16)
                    {
                        o.Size = 0;
                    }

                    byte b1 = (byte)((o.X << 2) + ((o.Size >> 2) & 0x03));
                    byte b2 = (byte)((o.Y << 2) + (o.Size & 0x03));
                    byte b3 = (byte)(o.id);

                    objectsBytes.Add(b1);
                    objectsBytes.Add(b2);
                    objectsBytes.Add(b3);
                }
                objectsBytes.Add(0xFF);
                objectsBytes.Add(0xFF);

                ROM.Write(writingDataPos, objectsBytes.ToArray());
                writingDataPos += objectsBytes.Count;
            }

            if (writingDataPos > Constants.DungeonOverlayDataLimit)
            {
                return true;
            }

            return false;


        }
    }
}
