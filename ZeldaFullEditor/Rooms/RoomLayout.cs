namespace ZeldaFullEditor.Rooms
{
    class RoomLayout : Room
    {
        public RoomLayout() : base(-1)
        {
            // TODO: Add something here?
        }

        public void loadLayout(int layout)
        {
            int pointer = ROM.ReadLong(Constants.room_object_layout_pointer);
            pointer = Utils.SnesToPc(pointer);
            int layout_address = ROM.ReadLong(pointer + (layout * 3));

            int layout_location = Utils.SnesToPc(layout_address);

            int pos = layout_location;
            byte b1 = 0;
            byte b2 = 0;
            byte b3 = 0;
            byte posX = 0;
            byte posY = 0;
            byte sizeX = 0;
            byte sizeY = 0;
            byte sizeXY = 0;
            short oid = 0;
            int layer = 0;

            while (true)
            {
                b1 = ROM.DATA[pos];
                b2 = ROM.DATA[pos + 1];
                if (b1 == 0xFF && b2 == 0xFF)
                {
                    break;
                }

                b3 = ROM.DATA[pos + 2];
                pos += 3; // We jump to layer2

                if (b3 >= 0xF8)
                {
                    oid = (short)((b3 << 4) | 0x80 + (((b2 & 0x03) << 2) + ((b1 & 0x03))));
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

                if (b1 >= 0xFC) // Subtype2 (not scalable? )
                {
                    oid = (short)((b3 & 0x3F) + 0x100);
                    posX = (byte)(((b2 & 0xF0) >> 4) + ((b1 & 0x3) << 4));
                    posY = (byte)(((b2 & 0x0F) << 2) + ((b3 & 0xC0) >> 6));
                    sizeXY = 0;
                }

                Room_Object r = addObject(oid, posX, posY, sizeXY, (byte)layer);
                if (r != null)
                {
                    r.options |= ObjectOption.Bgr;
                    tilesLayoutObjects.Add(r);
                }
            }
        }
    }
}
