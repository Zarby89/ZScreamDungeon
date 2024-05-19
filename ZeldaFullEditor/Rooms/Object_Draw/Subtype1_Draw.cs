using System;

namespace ZeldaFullEditor
{
    [Serializable]
    public class object_00 : Room_Object
    {
        public object_00(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x00];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();
            if (this.Size == 0)
            {
                this.Size = 32;
            }

            for (int s = 0; s < Size; s++)
            {
                draw_tile(tiles[0], ((s * 2)) * 8, 0); draw_tile(tiles[2], (1 + (s * 2)) * 8, 0);
                draw_tile(tiles[1], ((s * 2)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 2)) * 8, (1) * 8);
            }
        }
    }

    [Serializable]
    public class object_01 : Room_Object
    {
        public object_01(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x01];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Horizontal | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();
            if (this.Size == 0)
            {
                this.Size = 26;
            }

            for (int s = 0; s < Size; s++)
            {
                draw_tile(tiles[0], ((s * 2)) * 8, (0) * 8); draw_tile(tiles[4], (1 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 2)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 2)) * 8, (1) * 8);
                draw_tile(tiles[2], ((s * 2)) * 8, (2) * 8); draw_tile(tiles[6], (1 + (s * 2)) * 8, (2) * 8);
                draw_tile(tiles[3], ((s * 2)) * 8, (3) * 8); draw_tile(tiles[7], (1 + (s * 2)) * 8, (3) * 8);
            }
        }
    }

    [Serializable]
    public class object_02 : Room_Object
    {
        public object_02(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x02];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Horizontal | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();
            if (this.Size == 0)
            {
                this.Size = 26;
            }

            for (int s = 0; s < Size; s++)
            {
                draw_tile(tiles[0], ((s * 2)) * 8, (0) * 8); draw_tile(tiles[4], (1 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 2)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 2)) * 8, (1) * 8);
                draw_tile(tiles[2], ((s * 2)) * 8, (2) * 8); draw_tile(tiles[6], (1 + (s * 2)) * 8, (2) * 8);
                draw_tile(tiles[3], ((s * 2)) * 8, (3) * 8); draw_tile(tiles[7], (1 + (s * 2)) * 8, (3) * 8);
            }
        }
    }

    [Serializable]
    public class object_03 : Room_Object
    {
        public object_03(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x03];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            allBgs = true;
            sort = Sorting.Horizontal | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();
            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 2)) * 8, (0) * 8); draw_tile(tiles[4], (1 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 2)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 2)) * 8, (1) * 8);
                draw_tile(tiles[2], ((s * 2)) * 8, (2) * 8); draw_tile(tiles[6], (1 + (s * 2)) * 8, (2) * 8);
                draw_tile(tiles[3], ((s * 2)) * 8, (3) * 8); draw_tile(tiles[7], (1 + (s * 2)) * 8, (3) * 8);
            }
        }
    }

    [Serializable]
    public class object_04 : Room_Object
    {
        public object_04(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x04];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            allBgs = true;
            sort = Sorting.Horizontal | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();
            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 2)) * 8, (0) * 8); draw_tile(tiles[4], (1 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 2)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 2)) * 8, (1) * 8);
                draw_tile(tiles[2], ((s * 2)) * 8, (2) * 8); draw_tile(tiles[6], (1 + (s * 2)) * 8, (2) * 8);
                draw_tile(tiles[3], ((s * 2)) * 8, (3) * 8); draw_tile(tiles[7], (1 + (s * 2)) * 8, (3) * 8);
            }
        }
    }

    [Serializable]
    public class object_05 : Room_Object
    {
        public object_05(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x05];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();
            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 6)) * 8, (0) * 8); draw_tile(tiles[4], (1 + (s * 6)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 6)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 6)) * 8, (1) * 8);
                draw_tile(tiles[2], ((s * 6)) * 8, (2) * 8); draw_tile(tiles[6], (1 + (s * 6)) * 8, (2) * 8);
                draw_tile(tiles[3], ((s * 6)) * 8, (3) * 8); draw_tile(tiles[7], (1 + (s * 6)) * 8, (3) * 8);
            }
        }
    }

    [Serializable]
    public class object_06 : Room_Object
    {
        public object_06(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x06];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();
            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 6)) * 8, (0) * 8); draw_tile(tiles[4], (1 + (s * 6)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 6)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 6)) * 8, (1) * 8);
                draw_tile(tiles[2], ((s * 6)) * 8, (2) * 8); draw_tile(tiles[6], (1 + (s * 6)) * 8, (2) * 8);
                draw_tile(tiles[3], ((s * 6)) * 8, (3) * 8); draw_tile(tiles[7], (1 + (s * 6)) * 8, (3) * 8);
            }
        }
    }

    [Serializable]
    public class object_07 : Room_Object
    {
        public object_07(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x07];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();
            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 2)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 2)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 2)) * 8, (1) * 8);
            }
        }
    }

    [Serializable]
    public class object_08 : Room_Object
    {
        public object_08(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x08];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();
            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 2)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 2)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 2)) * 8, (1) * 8);
            }
        }
    }

    [Serializable]
    public class object_09 : Room_Object
    {
        public object_09(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x09];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_0A : Room_Object
    {
        public object_0A(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x0A];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_0B : Room_Object
    {
        public object_0B(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x0B];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_0C : Room_Object
    {
        public object_0C(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x0C];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_0D : Room_Object
    {
        public object_0D(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x0D];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_0E : Room_Object
    {
        public object_0E(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x0E];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_0F : Room_Object
    {
        public object_0F(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x0F];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_10 : Room_Object
    {
        public object_10(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x10];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_11 : Room_Object
    {
        public object_11(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x11];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_12 : Room_Object
    {
        public object_12(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x12];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_13 : Room_Object
    {
        public object_13(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x13];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_14 : Room_Object
    {
        public object_14(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x14];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_15 : Room_Object
    {
        public object_15(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x15];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_16 : Room_Object
    {
        public object_16(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x16];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_17 : Room_Object
    {
        public object_17(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x17];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_18 : Room_Object
    {
        public object_18(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x18];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_19 : Room_Object
    {
        public object_19(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x19];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_1A : Room_Object
    {
        public object_1A(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x1A];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_1B : Room_Object
    {
        public object_1B(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x1B];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_1C : Room_Object
    {
        public object_1C(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x1C];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_1D : Room_Object
    {
        public object_1D(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x1D];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_1E : Room_Object
    {
        public object_1E(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x1E];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_1F : Room_Object
    {
        public object_1F(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x1F];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_20 : Room_Object
    {
        public object_20(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x20];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            base.Draw();
            draw_diagonal_up();
        }
    }


    [Serializable]
    public class object_21 : Room_Object
    {
        public object_21(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x21];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(9, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[3], (1 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[3], (2 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[4], (1 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[4], (2 + (s * 2)) * 8, (1) * 8);
                draw_tile(tiles[5], (1 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[5], (2 + (s * 2)) * 8, (2) * 8);
            }

            draw_tile(tiles[0], 0, (0) * 8);
            draw_tile(tiles[1], 0, (1) * 8);
            draw_tile(tiles[2], 0, (2) * 8);

            draw_tile(tiles[6], ((Size * 2) + 3) * 8, (0) * 8);
            draw_tile(tiles[7], ((Size * 2) + 3) * 8, (1) * 8);
            draw_tile(tiles[8], ((Size * 2) + 3) * 8, (2) * 8);
        }
    }


    [Serializable]
    public class object_22 : Room_Object
    {
        public object_22(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x22];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Horizontal | Sorting.Dungeons;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 2; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 2) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_23 : Room_Object
    {
        public object_23(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x23];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], 0, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_24 : Room_Object
    {
        public object_24(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x24];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_25 : Room_Object
    {
        public object_25(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x25];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_26 : Room_Object
    {
        public object_26(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x26];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_27 : Room_Object
    {
        public object_27(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x27];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_28 : Room_Object
    {
        public object_28(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x28];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_29 : Room_Object
    {
        public object_29(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x29];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_2A : Room_Object
    {
        public object_2A(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x2A];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_2B : Room_Object
    {
        public object_2B(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x2B];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_2C : Room_Object
    {
        public object_2C(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x2C];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);

            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_2D : Room_Object
    {
        public object_2D(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x2D];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);

            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_2E : Room_Object
    {
        public object_2E(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x2E];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);

            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_2F : Room_Object
    {
        public object_2F(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x2F];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(6, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 14; s++)
            {
                draw_tile(tiles[3], ((s * 1)) * 8, (0) * 8);
                draw_tile(tiles[0], ((s * 1)) * 8, (1) * 8);
            }

            draw_tile(tiles[1], (0) * 8, (0) * 8);
            draw_tile(tiles[2], (1) * 8, (0) * 8);

            draw_tile(tiles[4], (Size + 12) * 8, (0) * 8);
            draw_tile(tiles[5], (Size + 12 + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_30 : Room_Object
    {
        public object_30(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x30];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(6, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 14; s++)
            {
                draw_tile(tiles[3], ((s * 1)) * 8, (1) * 8);
                draw_tile(tiles[0], ((s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[1], (0) * 8, (1) * 8);
            draw_tile(tiles[2], (1) * 8, (1) * 8);

            draw_tile(tiles[4], (Size + 12) * 8, (1) * 8);
            draw_tile(tiles[5], (Size + 12 + 1) * 8, (1) * 8);
        }
    }

    [Serializable]
    public class object_31 : Room_Object
    {
        public object_31(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x31];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_32 : Room_Object
    {
        public object_32(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_33 : Room_Object
    {
        public object_33(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x33];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 4; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx + (s * 4)) * 8, (yy) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_34 : Room_Object

    {
        public object_34(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x34];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 4; s++)
            {
                draw_tile(tiles[0], ((s * 1)) * 8, (0) * 8);
            }
        }
    }

    [Serializable]
    public class object_35 : Room_Object
    {
        public object_35(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x35];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
        }

        public override void Draw()
        {
            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 1)) * 8, (0) * 8);
            }

            base.Draw();
        }
    }

    [Serializable]
    public class object_36 : Room_Object
    {
        public object_36(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x36];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 4; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx + (s * 6)) * 8, (yy) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_37 : Room_Object
    {
        public object_37(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x37];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 4; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx + (s * 6)) * 8, (yy) * 8);
                        tid++;
                    }
                }
            }
        }
    }


    [Serializable]
    public class object_38 : Room_Object
    {
        public object_38(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x38];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(6, pos);
            sort = Sorting.Horizontal | Sorting.Dungeons;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 4)) * 8, (0) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 4)) * 8, (1) * 8); draw_tile(tiles[4], (1 + (s * 4)) * 8, (1) * 8);
                draw_tile(tiles[2], ((s * 4)) * 8, (2) * 8); draw_tile(tiles[5], (1 + (s * 4)) * 8, (2) * 8);
            }
        }
    }

    [Serializable]
    public class object_39 : Room_Object
    {
        public object_39(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x39];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 6)) * 8, (0) * 8); draw_tile(tiles[4], (1 + (s * 6)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 6)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 6)) * 8, (1) * 8);
                draw_tile(tiles[2], ((s * 6)) * 8, (2) * 8); draw_tile(tiles[6], (1 + (s * 6)) * 8, (2) * 8);
                draw_tile(tiles[3], ((s * 6)) * 8, (3) * 8); draw_tile(tiles[7], (1 + (s * 6)) * 8, (3) * 8);
            }

            sort = Sorting.Horizontal;
        }
    }

    [Serializable]
    public class object_3A : Room_Object
    {
        public object_3A(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x3A];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(12, pos);
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 4; xx++)
                {
                    for (int yy = 0; yy < 3; yy++)
                    {
                        draw_tile(tiles[tid], (xx + (s * 8)) * 8, (yy) * 8);
                        tid++;
                    }
                }
            }

            sort = Sorting.Horizontal;
        }
    }

    [Serializable]
    public class object_3B : Room_Object
    {
        public object_3B(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x3B];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(12, pos);
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 4; xx++)
                {
                    for (int yy = 0; yy < 3; yy++)
                    {
                        draw_tile(tiles[tid], (xx + (s * 8)) * 8, (yy) * 8);
                        tid++;
                    }
                }
            }

            sort = Sorting.Horizontal;
        }
    }

    [Serializable]
    public class object_3C : Room_Object
    {
        public object_3C(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x3C];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 4)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 4)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (1) * 8);

                draw_tile(tiles[0], ((s * 4)) * 8, (6) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (6) * 8);
                draw_tile(tiles[1], ((s * 4)) * 8, (7) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (7) * 8);
            }

            sort = Sorting.Horizontal;
        }
    }

    [Serializable]
    public class object_3D : Room_Object
    {
        public object_3D(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x3D];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Horizontal | Sorting.Dungeons;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 6)) * 8, (0) * 8); draw_tile(tiles[4], (1 + (s * 6)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 6)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 6)) * 8, (1) * 8);
                draw_tile(tiles[2], ((s * 6)) * 8, (2) * 8); draw_tile(tiles[6], (1 + (s * 6)) * 8, (2) * 8);
                draw_tile(tiles[3], ((s * 6)) * 8, (3) * 8); draw_tile(tiles[7], (1 + (s * 6)) * 8, (3) * 8);
            }
        }
    }


    [Serializable]
    public class object_3E : Room_Object
    {
        public object_3E(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x3E];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 14)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 14)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 14)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 14)) * 8, (1) * 8);
            }
        }
    }

    [Serializable]
    public class object_3F : Room_Object
    {
        public object_3F(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x3F];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_40 : Room_Object
    {
        public object_40(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x40];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_41 : Room_Object
    {
        public object_41(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x41];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_42 : Room_Object
    {
        public object_42(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x42];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_43 : Room_Object
    {
        public object_43(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x43];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_44 : Room_Object
    {
        public object_44(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x44];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_45 : Room_Object
    {
        public object_45(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x45];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }


    [Serializable]
    public class object_46 : Room_Object
    {
        public object_46(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x46];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], ((Size + 1) + 1) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_47 : Room_Object
    {
        public object_47(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x47];
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();
            // TODO:
        }
    }

    [Serializable]
    public class object_48 : Room_Object
    {
        public object_48(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x48];
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();
            // TODO:
        }
    }

    [Serializable]
    public class object_49 : Room_Object
    {
        public object_49(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x49];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
        }

        public override void Draw()
        {
            base.Draw();
            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[4], (2 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[6], (3 + (s * 4)) * 8, (0) * 8);
                draw_tile(tiles[1], (0 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[5], (2 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[7], (3 + (s * 4)) * 8, (1) * 8);
            }
        }
    }

    [Serializable]
    public class object_4A : Room_Object

    {
        public object_4A(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x4A];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[4], (2 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[6], (3 + (s * 4)) * 8, (0) * 8);
                draw_tile(tiles[1], (0 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[5], (2 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[7], (3 + (s * 4)) * 8, (1) * 8);
            }
        }
    }

    [Serializable]
    public class object_4B : Room_Object
    {
        public object_4B(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x4B];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 14)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 14)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 14)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 14)) * 8, (1) * 8);
            }
        }
    }

    [Serializable]
    public class object_4C : Room_Object
    {
        public object_4C(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x4C];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(9, pos);
            sort = Sorting.Horizontal;
        }
        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[3], (1 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[3], (2 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[4], (1 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[4], (2 + (s * 2)) * 8, (1) * 8);
                draw_tile(tiles[5], (1 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[5], (2 + (s * 2)) * 8, (2) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[1], (0) * 8, (1) * 8);
            draw_tile(tiles[2], (0) * 8, (2) * 8);

            draw_tile(tiles[6], ((Size * 2) + 3) * 8, (0) * 8);
            draw_tile(tiles[7], ((Size * 2) + 3) * 8, (1) * 8);
            draw_tile(tiles[8], ((Size * 2) + 3) * 8, (2) * 8);
        }
    }

    [Serializable]
    public class object_4D : Room_Object
    {
        public object_4D(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x4D];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[4], (1 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[8], (2 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[5], (1 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[9], (2 + (s * 2)) * 8, (1) * 8);
                draw_tile(tiles[6], (1 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[10], (2 + (s * 2)) * 8, (2) * 8);
                draw_tile(tiles[7], (1 + (s * 2)) * 8, (3) * 8); draw_tile(tiles[11], (2 + (s * 2)) * 8, (3) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[1], (0) * 8, (1) * 8);
            draw_tile(tiles[2], (0) * 8, (2) * 8);
            draw_tile(tiles[3], (0) * 8, (3) * 8);

            draw_tile(tiles[12], ((Size * 2) + 3) * 8, (0) * 8);
            draw_tile(tiles[13], ((Size * 2) + 3) * 8, (1) * 8);
            draw_tile(tiles[14], ((Size * 2) + 3) * 8, (2) * 8);
            draw_tile(tiles[15], ((Size * 2) + 3) * 8, (3) * 8);
        }
    }

    [Serializable]
    public class object_4E : Room_Object
    {
        public object_4E(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x4E];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[4], (1 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[8], (2 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[5], (1 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[9], (2 + (s * 2)) * 8, (1) * 8);
                draw_tile(tiles[6], (1 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[10], (2 + (s * 2)) * 8, (2) * 8);
                draw_tile(tiles[7], (1 + (s * 2)) * 8, (3) * 8); draw_tile(tiles[11], (2 + (s * 2)) * 8, (3) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[1], (0) * 8, (1) * 8);
            draw_tile(tiles[2], (0) * 8, (2) * 8);
            draw_tile(tiles[3], (0) * 8, (3) * 8);

            draw_tile(tiles[12], ((Size * 2) + 3) * 8, (0) * 8);
            draw_tile(tiles[13], ((Size * 2) + 3) * 8, (1) * 8);
            draw_tile(tiles[14], ((Size * 2) + 3) * 8, (2) * 8);
            draw_tile(tiles[15], ((Size * 2) + 3) * 8, (3) * 8);
        }
    }

    [Serializable]
    public class object_4F : Room_Object
    {
        public object_4F(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x4F];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[4], (1 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[8], (2 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[5], (1 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[9], (2 + (s * 2)) * 8, (1) * 8);
                draw_tile(tiles[6], (1 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[10], (2 + (s * 2)) * 8, (2) * 8);
                draw_tile(tiles[7], (1 + (s * 2)) * 8, (3) * 8); draw_tile(tiles[11], (2 + (s * 2)) * 8, (3) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[1], (0) * 8, (1) * 8);
            draw_tile(tiles[2], (0) * 8, (2) * 8);
            draw_tile(tiles[3], (0) * 8, (3) * 8);

            draw_tile(tiles[12], ((Size * 2) + 3) * 8, (0) * 8);
            draw_tile(tiles[13], ((Size * 2) + 3) * 8, (1) * 8);
            draw_tile(tiles[14], ((Size * 2) + 3) * 8, (2) * 8);
            draw_tile(tiles[15], ((Size * 2) + 3) * 8, (3) * 8);
        }
    }

    [Serializable]
    public class object_50 : Room_Object
    {
        public object_50(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x50];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 2; s++)
            {
                draw_tile(tiles[0], ((s * 1)) * 8, (0) * 8);
            }
        }
    }

    [Serializable]
    public class object_51 : Room_Object
    {
        public object_51(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x51];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(18, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size; s++)
            {
                draw_tile(tiles[6], (2 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[9], (3 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[7], (2 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[10], (3 + (s * 2)) * 8, (1) * 8);
                draw_tile(tiles[8], (2 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[11], (3 + (s * 2)) * 8, (2) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (1) * 8, (0) * 8);
            draw_tile(tiles[1], (0) * 8, (1) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8);
            draw_tile(tiles[2], (0) * 8, (2) * 8); draw_tile(tiles[5], (1) * 8, (2) * 8);

            draw_tile(tiles[12], ((Size * 2) + 2) * 8, (0) * 8); draw_tile(tiles[15], ((Size * 2) + 3) * 8, (0) * 8);
            draw_tile(tiles[13], ((Size * 2) + 2) * 8, (1) * 8); draw_tile(tiles[16], ((Size * 2) + 3) * 8, (1) * 8);
            draw_tile(tiles[14], ((Size * 2) + 2) * 8, (2) * 8); draw_tile(tiles[17], ((Size * 2) + 3) * 8, (2) * 8);
        }
    }

    [Serializable]
    public class object_52 : Room_Object
    {
        public object_52(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x52];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(18, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size; s++)
            {
                draw_tile(tiles[6], (2 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[9], (3 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[7], (2 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[10], (3 + (s * 2)) * 8, (1) * 8);
                draw_tile(tiles[8], (2 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[11], (3 + (s * 2)) * 8, (2) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (1) * 8, (0) * 8);
            draw_tile(tiles[1], (0) * 8, (1) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8);
            draw_tile(tiles[2], (0) * 8, (2) * 8); draw_tile(tiles[5], (1) * 8, (2) * 8);

            draw_tile(tiles[12], ((Size * 2) + 2) * 8, (0) * 8); draw_tile(tiles[15], ((Size * 2) + 3) * 8, (0) * 8);
            draw_tile(tiles[13], ((Size * 2) + 2) * 8, (1) * 8); draw_tile(tiles[16], ((Size * 2) + 3) * 8, (1) * 8);
            draw_tile(tiles[14], ((Size * 2) + 2) * 8, (2) * 8); draw_tile(tiles[17], ((Size * 2) + 3) * 8, (2) * 8);
        }
    }

    [Serializable]
    public class object_53 : Room_Object
    {
        public object_53(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x53];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[1], (0 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 2)) * 8, (1) * 8);
            }
        }
    }

    [Serializable]
    public class object_54 : Room_Object
    {
        public object_54(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_55 : Room_Object
    {
        public object_55(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x55];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();
            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 12)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 12)) * 8, (0) * 8); draw_tile(tiles[1], (2 + (s * 12)) * 8, (0) * 8); draw_tile(tiles[3], (3 + (s * 12)) * 8, (0) * 8);
                draw_tile(tiles[4], (0 + (s * 12)) * 8, (1) * 8); draw_tile(tiles[6], (1 + (s * 12)) * 8, (1) * 8); draw_tile(tiles[5], (2 + (s * 12)) * 8, (1) * 8); draw_tile(tiles[7], (3 + (s * 12)) * 8, (1) * 8);
            }
        }
    }

    [Serializable]
    public class object_56 : Room_Object
    {
        public object_56(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x56];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();
            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 12)) * 8, (0) * 8); draw_tile(tiles[1], (1 + (s * 12)) * 8, (0) * 8); draw_tile(tiles[2], (2 + (s * 12)) * 8, (0) * 8); draw_tile(tiles[3], (3 + (s * 12)) * 8, (0) * 8);
                draw_tile(tiles[4], (0 + (s * 12)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 12)) * 8, (1) * 8); draw_tile(tiles[6], (2 + (s * 12)) * 8, (1) * 8); draw_tile(tiles[7], (3 + (s * 12)) * 8, (1) * 8);
            }
        }
    }

    [Serializable]
    public class object_57 : Room_Object
    {
        public object_57(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_58 : Room_Object
    {
        public object_58(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_59 : Room_Object
    {
        public object_59(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_5A : Room_Object
    {
        public object_5A(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_5B : Room_Object
    {
        public object_5B(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x5B];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(18, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size; s++)
            {
                draw_tile(tiles[6], (2 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[9], (3 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[7], (2 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[10], (3 + (s * 2)) * 8, (1) * 8);
                draw_tile(tiles[8], (2 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[11], (3 + (s * 2)) * 8, (2) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (1) * 8, (0) * 8);
            draw_tile(tiles[1], (0) * 8, (1) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8);
            draw_tile(tiles[2], (0) * 8, (2) * 8); draw_tile(tiles[5], (1) * 8, (2) * 8);

            draw_tile(tiles[12], ((Size * 2) + 2) * 8, (0) * 8); draw_tile(tiles[15], ((Size * 2) + 3) * 8, (0) * 8);
            draw_tile(tiles[13], ((Size * 2) + 2) * 8, (1) * 8); draw_tile(tiles[16], ((Size * 2) + 3) * 8, (1) * 8);
            draw_tile(tiles[14], ((Size * 2) + 2) * 8, (2) * 8); draw_tile(tiles[17], ((Size * 2) + 3) * 8, (2) * 8);
        }
    }

    [Serializable]
    public class object_5C : Room_Object
    {
        public object_5C(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x5C];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(18, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size; s++)
            {
                draw_tile(tiles[6], (2 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[9], (3 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[7], (2 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[10], (3 + (s * 2)) * 8, (1) * 8);
                draw_tile(tiles[8], (2 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[11], (3 + (s * 2)) * 8, (2) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (1) * 8, (0) * 8);
            draw_tile(tiles[1], (0) * 8, (1) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8);
            draw_tile(tiles[2], (0) * 8, (2) * 8); draw_tile(tiles[5], (1) * 8, (2) * 8);

            draw_tile(tiles[12], ((Size * 2) + 2) * 8, (0) * 8); draw_tile(tiles[15], ((Size * 2) + 3) * 8, (0) * 8);
            draw_tile(tiles[13], ((Size * 2) + 2) * 8, (1) * 8); draw_tile(tiles[16], ((Size * 2) + 3) * 8, (1) * 8);
            draw_tile(tiles[14], ((Size * 2) + 2) * 8, (2) * 8); draw_tile(tiles[17], ((Size * 2) + 3) * 8, (2) * 8);
        }
    }

    [Serializable]
    public class object_5D : Room_Object
    {
        public object_5D(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x5D];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(15, pos);
            sort = Sorting.Horizontal | Sorting.Dungeons;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 2; s++)
            {
                draw_tile(tiles[6], (2 + (s * 1)) * 8, (0) * 8);
                draw_tile(tiles[7], (2 + (s * 1)) * 8, (1) * 8);
                draw_tile(tiles[8], (2 + (s * 1)) * 8, (2) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (1) * 8, (0) * 8);
            draw_tile(tiles[1], (0) * 8, (1) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8);
            draw_tile(tiles[2], (0) * 8, (2) * 8); draw_tile(tiles[5], (1) * 8, (2) * 8);

            draw_tile(tiles[9], ((Size * 1) + 4) * 8, (0) * 8); draw_tile(tiles[12], ((Size * 1) + 5) * 8, (0) * 8);
            draw_tile(tiles[10], ((Size * 1) + 4) * 8, (1) * 8); draw_tile(tiles[13], ((Size * 1) + 5) * 8, (1) * 8);
            draw_tile(tiles[11], ((Size * 1) + 4) * 8, (2) * 8); draw_tile(tiles[14], ((Size * 1) + 5) * 8, (2) * 8);
        }
    }

    [Serializable]
    public class object_5E : Room_Object
    {
        public object_5E(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x5E];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Horizontal | Sorting.Dungeons;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (0) * 8);
                draw_tile(tiles[1], (0 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (1) * 8);
            }
        }
    }


    [Serializable]
    public class object_5F : Room_Object
    {
        public object_5F(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x5F];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 22; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((Size + 22)) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_60 : Room_Object
    {
        public object_60(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x60];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            if (this.Size == 0)
            {
                this.Size = 32;
            }

            for (int s = 0; s < Size; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
            }
        }
    }

    [Serializable]
    public class object_61 : Room_Object
    {
        public object_61(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x61];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();

            if (this.Size == 0)
            {
                this.Size = 26;
            }

            for (int s = 0; s < Size; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 2)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 2)) * 8);
                draw_tile(tiles[4], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 2)) * 8);
            }
        }
    }

    [Serializable]
    public class object_62 : Room_Object
    {
        public object_62(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x62];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();

            if (this.Size == 0)
            {
                this.Size = 26;
            }

            for (int s = 0; s < Size; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 2)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 2)) * 8);
                draw_tile(tiles[4], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 2)) * 8);
            }
        }
    }

    [Serializable]
    public class object_63 : Room_Object
    {
        public object_63(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x63];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 2)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 2)) * 8);
                draw_tile(tiles[4], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 2)) * 8);
            }
        }
    }

    [Serializable]
    public class object_64 : Room_Object
    {
        public object_64(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x64];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 2)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 2)) * 8);
                draw_tile(tiles[4], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 2)) * 8);
            }
        }
    }

    [Serializable]
    public class object_65 : Room_Object
    {
        public object_65(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x65];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Vertical;

        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 6)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 6)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 6)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 6)) * 8);
                draw_tile(tiles[4], (0) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 6)) * 8);
            }
        }
    }


    [Serializable]
    public class object_66 : Room_Object
    {
        public object_66(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x66];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 6)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 6)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 6)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 6)) * 8);
                draw_tile(tiles[4], (0) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 6)) * 8);
            }
        }
    }

    [Serializable]
    public class object_67 : Room_Object
    {
        public object_67(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x67];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
            }
        }
    }

    [Serializable]
    public class object_68 : Room_Object
    {
        public object_68(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x68];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
            }
        }
    }

    [Serializable]
    public class object_69 : Room_Object
    {

        public object_69(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x69];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Vertical | Sorting.Dungeons;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 2; s++)
            {
                draw_tile(tiles[1], (0) * 8, (1 + (s * 1)) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8, tiles[1].getshortileinfo());
            draw_tile(tiles[2], (0) * 8, ((Size + 2) + 1) * 8);
        }
    }


    [Serializable]
    public class object_6A : Room_Object
    {
        public object_6A(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x6A];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }
        }
    }

    [Serializable]
    public class object_6B : Room_Object
    {
        public object_6B(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x6B];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }
        }
    }


    [Serializable]
    public class object_6C : Room_Object
    {
        public object_6C(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x6C];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(6, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 14; s++)
            {
                draw_tile(tiles[3], (0) * 8, (0 + (s * 1)) * 8);
                draw_tile(tiles[0], (0 + 1) * 8, (((s * 1)) * 8));
            }

            draw_tile(tiles[1], (0) * 8, (0) * 8);
            draw_tile(tiles[2], (0) * 8, (1) * 8);

            draw_tile(tiles[4], (0) * 8, (Size + 12) * 8);
            draw_tile(tiles[5], (0) * 8, (Size + 12 + 1) * 8);
        }
    }

    [Serializable]
    public class object_6D : Room_Object
    {
        public object_6D(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x6D];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(6, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 14; s++)
            {
                draw_tile(tiles[3], (0 + 1) * 8, (0 + (s * 1)) * 8);
                draw_tile(tiles[0], (0) * 8, (((s * 1)) * 8));
            }

            draw_tile(tiles[1], (0 + 1) * 8, (0) * 8);
            draw_tile(tiles[2], (0 + 1) * 8, (1) * 8);

            draw_tile(tiles[4], (0 + 1) * 8, (Size + 12) * 8);
            draw_tile(tiles[5], (0 + 1) * 8, (Size + 12 + 1) * 8);
        }
    }

    [Serializable]
    public class object_6E : Room_Object
    {
        public object_6E(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_6F : Room_Object
    {
        public object_6F(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_70 : Room_Object
    {
        public object_70(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x70];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 4; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx) * 8, (yy + (s * 4)) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_71 : Room_Object
    {
        public object_71(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x71];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 4; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }
        }
    }


    [Serializable]
    public class object_72 : Room_Object
    {
        public object_72(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_73 : Room_Object
    {
        public object_73(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x73];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 4; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx) * 8, (yy + (s * 6)) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_74 : Room_Object
    {
        public object_74(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x74];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 4; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx) * 8, (yy + (s * 6)) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_75 : Room_Object
    {
        public object_75(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x75];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 6)) * 8); draw_tile(tiles[4], (1) * 8, ((s * 6)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 6)) * 8);
                draw_tile(tiles[2], (0) * 8, (2 + (s * 6)) * 8); draw_tile(tiles[6], (1) * 8, (2 + (s * 6)) * 8);
                draw_tile(tiles[3], (0) * 8, (3 + (s * 6)) * 8); draw_tile(tiles[7], (1) * 8, (3 + (s * 6)) * 8);
            }
        }
    }

    [Serializable]
    public class object_76 : Room_Object
    {
        public object_76(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x76];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 3; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx) * 8, (yy + (s * 8)) * 8);
                        tid++;
                    }
                }
            }
        }
    }


    [Serializable]
    public class object_77 : Room_Object
    {
        public object_77(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x77];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 3; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx) * 8, (yy + (s * 8)) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_78 : Room_Object
    {
        public object_78(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x78];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 2; xx++)
                {
                    for (int yy = 0; yy < 2; yy++)
                    {
                        draw_tile(tiles[tid], (xx) * 8, (yy + (s * 14)) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_79 : Room_Object
    {
        public object_79(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x79];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }
        }
    }

    [Serializable]
    public class object_7A : Room_Object
    {
        public object_7A(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x7A];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }
        }
    }

    [Serializable]
    public class object_7B : Room_Object
    {
        public object_7B(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x7B];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 2; xx++)
                {
                    for (int yy = 0; yy < 2; yy++)
                    {
                        draw_tile(tiles[tid], (xx) * 8, (yy + (s * 14)) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_7C : Room_Object
    {
        public object_7C(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x7C];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 2; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }
        }
    }

    [Serializable]
    public class object_7D : Room_Object
    {
        public object_7D(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x7D];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 2; xx++)
                {
                    for (int yy = 0; yy < 2; yy++)
                    {
                        draw_tile(tiles[tid], (xx) * 8, (yy + (s * 2)) * 8);
                        tid++;
                    }
                }
            }
        }
    }


    [Serializable]
    public class object_7E : Room_Object
    {
        public object_7E(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_7F : Room_Object
    {
        public object_7F(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x7F];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 2; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx) * 8, (yy + (s * 12)) * 8);
                        tid++;
                    }
                }
            }
        }
    }


    [Serializable]
    public class object_80 : Room_Object
    {
        public object_80(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x80];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 2; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx) * 8, (yy + (s * 12)) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_81 : Room_Object
    {
        public object_81(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x81];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(12, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 3; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx) * 8, (yy + (s * 6)) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_82 : Room_Object
    {
        public object_82(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x82];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(12, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 3; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx) * 8, (yy + (s * 6)) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_83 : Room_Object
    {
        public object_83(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x83];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(12, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 3; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx) * 8, (yy + (s * 6)) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_84 : Room_Object
    {
        public object_84(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x84];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(12, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 3; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx) * 8, (yy + (s * 6)) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_85 : Room_Object
    {
        public object_85(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x85];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(18, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size; s++)
            {
                draw_tile(tiles[6], (0) * 8, (2 + (s * 2)) * 8); draw_tile(tiles[9], (0) * 8, (3 + (s * 2)) * 8);
                draw_tile(tiles[7], (1) * 8, (2 + (s * 2)) * 8); draw_tile(tiles[10], (1) * 8, (3 + (s * 2)) * 8);
                draw_tile(tiles[8], (2) * 8, (2 + (s * 2)) * 8); draw_tile(tiles[11], (2) * 8, (3 + (s * 2)) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (0) * 8, (1) * 8);
            draw_tile(tiles[1], (1) * 8, (0) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8);
            draw_tile(tiles[2], (2) * 8, (0) * 8); draw_tile(tiles[5], (2) * 8, (1) * 8);

            draw_tile(tiles[12], (0) * 8, ((Size * 2) + 2) * 8); draw_tile(tiles[15], (0) * 8, ((Size * 2) + 3) * 8);
            draw_tile(tiles[13], (1) * 8, ((Size * 2) + 2) * 8); draw_tile(tiles[16], (1) * 8, ((Size * 2) + 3) * 8);
            draw_tile(tiles[14], (2) * 8, ((Size * 2) + 2) * 8); draw_tile(tiles[17], (2) * 8, ((Size * 2) + 3) * 8);
        }
    }

    [Serializable]
    public class object_86 : Room_Object
    {
        public object_86(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x86];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(18, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size; s++)
            {
                draw_tile(tiles[6], (0) * 8, (2 + (s * 2)) * 8); draw_tile(tiles[9], (0) * 8, (3 + (s * 2)) * 8);
                draw_tile(tiles[7], (1) * 8, (2 + (s * 2)) * 8); draw_tile(tiles[10], (1) * 8, (3 + (s * 2)) * 8);
                draw_tile(tiles[8], (2) * 8, (2 + (s * 2)) * 8); draw_tile(tiles[11], (2) * 8, (3 + (s * 2)) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (0) * 8, (1) * 8);
            draw_tile(tiles[1], (1) * 8, (0) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8);
            draw_tile(tiles[2], (2) * 8, (0) * 8); draw_tile(tiles[5], (2) * 8, (1) * 8);

            draw_tile(tiles[12], (0) * 8, ((Size * 2) + 2) * 8); draw_tile(tiles[15], (0) * 8, ((Size * 2) + 3) * 8);
            draw_tile(tiles[13], (1) * 8, ((Size * 2) + 2) * 8); draw_tile(tiles[16], (1) * 8, ((Size * 2) + 3) * 8);
            draw_tile(tiles[14], (2) * 8, ((Size * 2) + 2) * 8); draw_tile(tiles[17], (2) * 8, ((Size * 2) + 3) * 8);
        }
    }

    [Serializable]
    public class object_87 : Room_Object
    {
        public object_87(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x87];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Vertical | Sorting.Dungeons;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 6)) * 8); draw_tile(tiles[4], (1) * 8, ((s * 6)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 6)) * 8);
                draw_tile(tiles[2], (0) * 8, (2 + (s * 6)) * 8); draw_tile(tiles[6], (1) * 8, (2 + (s * 6)) * 8);
                draw_tile(tiles[3], (0) * 8, (3 + (s * 6)) * 8); draw_tile(tiles[7], (1) * 8, (3 + (s * 6)) * 8);
            }
        }
    }

    [Serializable]
    public class object_88 : Room_Object
    {
        public object_88(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x88];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(12, pos);
            sort = Sorting.Vertical | Sorting.Dungeons;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 2; s++)
            {
                draw_tile(tiles[4], (0) * 8, (0 + 2 + s) * 8); draw_tile(tiles[5], (1) * 8, (0 + 2 + s) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[2], (1) * 8, (0) * 8);
            draw_tile(tiles[1], (0) * 8, (0 + 1) * 8); draw_tile(tiles[3], (1) * 8, (1) * 8);

            draw_tile(tiles[6], (0) * 8, (Size + 3) * 8); draw_tile(tiles[9], (1) * 8, (Size + 3) * 8);
            draw_tile(tiles[7], (0) * 8, (1 + Size + 3) * 8); draw_tile(tiles[10], (1) * 8, (1 + Size + 3) * 8);
            draw_tile(tiles[8], (0) * 8, (2 + Size + 3) * 8); draw_tile(tiles[11], (1) * 8, (2 + Size + 3) * 8);
        }
    }

    [Serializable]
    public class object_89 : Room_Object
    {
        public object_89(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x89];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Vertical | Sorting.Dungeons;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 4)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 4)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 4)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 4)) * 8);
            }
        }
    }

    [Serializable]
    public class object_8A : Room_Object
    {
        public object_8A(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x8A];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 21; s++)
            {
                draw_tile(tiles[1], (0) * 8, (1 + (s * 1)) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], (0) * 8, ((Size + 21) + 1) * 8);
        }
    }

    [Serializable]
    public class object_8B : Room_Object
    {
        public object_8B(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x8B];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 8; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }
        }
    }

    [Serializable]
    public class object_8C : Room_Object
    {
        public object_8C(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x8C];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();
            for (int s = 0; s < Size + 8; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }
        }
    }


    [Serializable]
    public class object_8D : Room_Object
    {
        public object_8D(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x8D];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Vertical;
            LimitClass = DungeonLimits.GeneralManipulable;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }
        }
    }

    [Serializable]
    public class object_8E : Room_Object
    {
        public object_8E(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x8E];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }
        }
    }

    [Serializable]
    public class object_8F : Room_Object
    {
        public object_8F(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x8F];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(6, pos);
        }

        public override void Draw()
        {
            base.Draw();
            for (int s =
                0; s < Size + 2; s++)
            {
                draw_tile(tiles[2], (0) * 8, (0 + 1 + (s * 2)) * 8); draw_tile(tiles[3], (0 + 1) * 8, (0 + 1 + (s * 2)) * 8);
                draw_tile(tiles[2], (0) * 8, (2 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (2 + (s * 2)) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[1], (0 + 1) * 8, (0) * 8);
        }
    }



    [Serializable]
    public class object_90 : Room_Object
    {
        public object_90(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x90];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();

            if (this.Size == 0)
            {
                this.Size = 26;
            }

            for (int s = 0; s < Size; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 2)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 2)) * 8);
                draw_tile(tiles[4], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 2)) * 8);
            }
        }
    }

    [Serializable]
    public class object_91 : Room_Object
    {
        public object_91(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x91];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();

            if (this.Size == 0)
            {
                this.Size = 26;
            }

            for (int s = 0; s < Size; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 2)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 2)) * 8);
                draw_tile(tiles[4], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 2)) * 8);
            }
        }
    }


    [Serializable]
    public class object_92 : Room_Object
    {
        public object_92(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x92];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Vertical | Sorting.Dungeons;
        }

        public override void Draw()
        {
            base.Draw();

            if (Size == 0)
            {
                Size = 26;
            }

            for (int s = 0; s < Size; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
            }
        }
    }

    [Serializable]
    public class object_93 : Room_Object
    {
        public object_93(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x93];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Vertical | Sorting.Dungeons;
        }

        public override void Draw()
        {
            base.Draw();

            if (Size == 0)
            {
                Size = 26;
            }

            for (int s = 0; s < Size; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
            }
        }
    }

    [Serializable]
    public class object_94 : Room_Object
    {
        public object_94(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x94];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            sort = Sorting.Vertical | Sorting.Dungeons | Sorting.Floors;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 4; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx) * 8, (yy + (s * 4)) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_95 : Room_Object
    {
        public object_95(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x95];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Vertical;
            LimitClass = DungeonLimits.GeneralManipulableLengthy;

		}

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
            }
        }
    }

    [Serializable]
    public class object_96 : Room_Object
    {
        public object_96(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x96];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Vertical | Sorting.Dungeons;
            LimitClass = DungeonLimits.GeneralManipulableLengthy;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
            }
        }
    }

    [Serializable]
    public class object_97 : Room_Object
    {
        public object_97(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_98 : Room_Object
    {
        public object_98(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_99 : Room_Object
    {
        public object_99(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_9A : Room_Object
    {
        public object_9A(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_9B : Room_Object
    {
        public object_9B(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_9C : Room_Object
    {
        public object_9C(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_9D : Room_Object
    {
        public object_9D(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_9E : Room_Object
    {
        public object_9E(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_9F : Room_Object
    {
        public object_9F(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_A0 : Room_Object
    {
        public object_A0(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xA0];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            int lenght = Size + 4;
            for (int s = 0; s < Size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], (0 + i) * 8, ((s)) * 8);
                }

                lenght -= 1;
            }
        }
    }

    [Serializable]
    public class object_A1 : Room_Object
    {
        public object_A1(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xA1];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            //height = (size + 10) * 8;
            //width = (size + 6) * 8;
            //diagonalFix = true;

            base.Draw();

            int lenght = 1;
            for (int s = 0; s < Size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], (i) * 8, ((s)) * 8);
                }

                lenght += 1;
            }
        }
    }


    [Serializable]
    public class object_A2 : Room_Object
    {
        public object_A2(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xA2];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            int lenght = Size + 4;
            for (int s = 0; s < Size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], ((i) + s) * 8, ((s)) * 8);
                }

                lenght -= 1;
            }
        }
    }


    [Serializable]
    public class object_A3 : Room_Object
    {
        public object_A3(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xA3];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();
            height = (Size + 10) * 8;
            width = (Size + 6) * 8;
            diagonalFix = true;
            int lenght = Size + 4;

            for (int s = 0; s < Size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], ((i) + s) * 8, (0 - (s)) * 8);
                }

                lenght -= 1;
            }
        }
    }

    [Serializable]
    public class object_A4 : Room_Object
    {
        public object_A4(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xA4];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(24, pos);
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            draw_tile(tiles[8], (0) * 8, (0) * 8);//top left corner
            draw_tile(tiles[9], (1) * 8, (0) * 8); //vertical tile
                                                   //horizontal tile
            draw_tile(tiles[23], (Size + 3) * 8, (Size + 3) * 8);

            draw_tile(tiles[17], (0) * 8, (Size + 3) * 8);//bottom left corner

            draw_tile(tiles[14], (Size + 3) * 8, (0) * 8);

            for (int xx = 1; xx < Size + 3; xx++)
            {
                for (int yy = 1; yy < Size + 3; yy++)
                {
                    draw_tile(tiles[0], (xx) * 8, (yy) * 8);
                }

                draw_tile(tiles[19], (xx) * 8, (Size + 3) * 8);
                draw_tile(tiles[10], (xx) * 8, (0) * 8);
            }

            for (int yy = 1; yy < Size + 3; yy++)
            {
                draw_tile(tiles[9], (0) * 8, (yy) * 8);
                draw_tile(tiles[15], (Size + 3) * 8, (yy) * 8);
            }
        }
    }

    [Serializable]
    public class object_A5 : Room_Object
    {
        public object_A5(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xA5];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            int lenght = Size + 4;
            for (int s = 0; s < Size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], (i) * 8, ((s)) * 8);
                }

                lenght -= 1;
            }
        }
    }

    [Serializable]
    public class object_A6 : Room_Object
    {
        public object_A6(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xA6];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            int lenght = 1;
            for (int s = 0; s < Size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], (i) * 8, ((s)) * 8);
                }

                lenght += 1;
            }
        }
    }


    [Serializable]
    public class object_A7 : Room_Object
    {
        public object_A7(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xA7];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            int lenght = Size + 4;
            for (int s = 0; s < Size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], ((i) + s) * 8, ((s)) * 8);
                }

                lenght -= 1;
            }
        }
    }


    [Serializable]
    public class object_A8 : Room_Object
    {
        public object_A8(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xA8];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            int lenght = Size + 4;
            for (int s = 0; s < Size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], ((i) + s) * 8, (0 - (s)) * 8);
                }

                lenght -= 1;
            }
        }
    }

    [Serializable]
    public class object_A9 : Room_Object
    {
        public object_A9(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xA9];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Horizontal | Sorting.Vertical;
            showRectangle = true;
        }

        public override void Draw()
        {
            base.Draw();

            int lenght = Size + 4;
            for (int s = 0; s < Size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], (i) * 8, ((s)) * 8);
                }

                lenght -= 1;
            }
        }
    }

    [Serializable]
    public class object_AA : Room_Object
    {
        public object_AA(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xAA];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Horizontal | Sorting.Vertical;
            showRectangle = true;
        }

        public override void Draw()
        {
            base.Draw();

            int lenght = 1;
            for (int s = 0; s < Size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], (i) * 8, ((s)) * 8);
                }

                lenght += 1;
            }
        }
    }

    [Serializable]
    public class object_AB : Room_Object
    {
        public object_AB(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xAB];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Horizontal | Sorting.Vertical;
            showRectangle = true;
        }

        public override void Draw()
        {
            base.Draw();

            int lenght = Size + 4;
            for (int s = 0; s < Size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], ((i) + s) * 8, ((s)) * 8);
                }

                lenght -= 1;
            }
        }
    }


    [Serializable]
    public class object_AC : Room_Object
    {
        public object_AC(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xAC];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Horizontal | Sorting.Vertical;
            showRectangle = true;

            diagonalFix = true;
        }

        public override void Draw()
        {
            base.Draw();

            int lenght = Size + 4;
            for (int s = 0; s < Size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], ((i) + s) * 8, (0 - (s)) * 8);
                }

                lenght -= 1;
            }

            height = (Size + 7) * 8;
            width = (Size + 4) * 8;
        }
    }


    [Serializable]
    public class object_AD : Room_Object
    {
        public object_AD(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_AE : Room_Object
    {
        public object_AE(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_AF : Room_Object
    {
        public object_AF(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_B0 : Room_Object
    {
        public object_B0(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xB0];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 8; s++)
            {
                draw_tile(tiles[0], ((s * 1)) * 8, (0) * 8);
            }
        }
    }

    [Serializable]
    public class object_B1 : Room_Object
    {
        public object_B1(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xB1];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 8; s++)
            {
                draw_tile(tiles[0], ((s * 1)) * 8, (0) * 8);
            }
        }
    }


    [Serializable]
    public class object_B2 : Room_Object
    {
        public object_B2(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xB2];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            sort = Sorting.Horizontal | Sorting.Floors;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 4; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx + (s * 4)) * 8, (yy) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_B3 : Room_Object
    {
        public object_B3(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xB3];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((Size + 2)) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_B4 : Room_Object
    {
        public object_B4(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xB4];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
        }

        public override void Draw()
        {

            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((Size + 2)) * 8, (0) * 8);
        }
    }

    [Serializable]
    public class object_B5 : Room_Object
    {

        public object_B5(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xB5];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 2; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx + (s * 2)) * 8, (yy) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_B6 : Room_Object
    {
        public object_B6(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xB6];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Horizontal | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();
            if (this.Size == 0)
            {
                this.Size = 26;
            }

            for (int s = 0; s < Size; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 2; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx + (s * 2)) * 8, (yy) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_B7 : Room_Object
    {
        public object_B7(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xB7];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Horizontal | Sorting.Wall;
        }

        public override void Draw()
        {
            base.Draw();
            if (this.Size == 0)
            {
                this.Size = 26;
            }

            for (int s = 0; s < Size; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 2; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx + (s * 2)) * 8, (yy) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_B8 : Room_Object
    {
        public object_B8(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xB8];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Horizontal | Sorting.Dungeons;
        }

        public override void Draw()
        {
            base.Draw();

            if (Size == 0)
            {
                Size = 26;
            }

            for (int s = 0; s < Size; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 2; xx++)
                {
                    for (int yy = 0; yy < 2; yy++)
                    {
                        draw_tile(tiles[tid], (xx + (s * 2)) * 8, (yy) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_B9 : Room_Object
    {
        public object_B9(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xB9];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Horizontal | Sorting.Dungeons;
        }

        public override void Draw()
        {
            base.Draw();

            if (Size == 0)
            {
                Size = 26;
            }

            for (int s = 0; s < Size; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 2; xx++)
                {
                    for (int yy = 0; yy < 2; yy++)
                    {
                        draw_tile(tiles[tid], (xx + (s * 2)) * 8, (yy) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_BA : Room_Object
    {
        public object_BA(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xBA];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            sort = Sorting.Horizontal | Sorting.Floors;
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                int tid = 0;
                for (int xx = 0; xx < 4; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        draw_tile(tiles[tid], (xx + (s * 4)) * 8, (yy) * 8);
                        tid++;
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_BB : Room_Object
    {

        public object_BB(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xBB];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
        }

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (0) * 8);
                draw_tile(tiles[1], (0 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (1) * 8);
            }
        }
    }

    [Serializable]
    public class object_BC : Room_Object
    {
        public object_BC(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xBC];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Horizontal;
            LimitClass = DungeonLimits.GeneralManipulableLengthy;

		}

        public override void Draw()
        {
            base.Draw();
            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[1], (0 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 2)) * 8, (1) * 8);
            }
        }
    }


    [Serializable]
    public class object_BD : Room_Object
    {
        public object_BD(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xBD];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Horizontal;
            LimitClass = DungeonLimits.GeneralManipulableLengthy;

		}

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[1], (0 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 2)) * 8, (1) * 8);
            }
        }
    }


    [Serializable]
    public class object_BE : Room_Object
    {
        public object_BE(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }


    [Serializable]
    public class object_BF : Room_Object
    {
        public object_BF(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_C0 : Room_Object
    {
        public object_C0(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xC0];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            sort = Sorting.Horizontal | Sorting.Vertical;
            addTiles(1, pos);
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    for (int xxxx = 0; xxxx < 4; xxxx++)
                    {
                        for (int yyyy = 0; yyyy < 4; yyyy++)
                        {
                            draw_tile(tiles[0], (xxxx + (xx * 4)) * 8, (yyyy + (yy * 4)) * 8);
                        }
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_C1 : Room_Object
    {
        public object_C1(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xC1];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(68, pos); // ??
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            int i = 0;
            for (int xx = 0; xx < 3; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[i], xx * 8, yy * 8); // Top left corner
                    draw_tile(tiles[i + 15], (xx + ((sizex + 4) * 2) + 3) * 8, yy * 8); // Top right corner
                    draw_tile(tiles[i + 40], xx * 8, (yy + ((sizey + 1) * 2) + 3) * 8); // bottom left corner
                    draw_tile(tiles[i + 55], (xx + ((sizex + 4) * 2) + 3) * 8, (yy + ((sizey + 1) * 2) + 3) * 8); // Bottom left corner
                    i++;
                }
            }

            for (int sx = 0; sx < sizex + 4; sx++)
            {
                for (int sy = 0; sy < sizey + 1; sy++)
                {
                    draw_tile(tiles[30], (3 + (sx * 2)) * 8, (3 + (sy * 2)) * 8); draw_tile(tiles[31], (4 + (sx * 2)) * 8, (3 + (sy * 2)) * 8);
                    draw_tile(tiles[32], (3 + (sx * 2)) * 8, (4 + (sy * 2)) * 8); draw_tile(tiles[33], (4 + (sx * 2)) * 8, (4 + (sy * 2)) * 8);
                }
            }

            draw_tile(tiles[64], (6 + (sizex * 1)) * 8, (3 + (sizey * 1)) * 8); draw_tile(tiles[66], (7 + (sizex * 1)) * 8, (3 + (sizey * 1)) * 8);
            draw_tile(tiles[65], (6 + (sizex * 1)) * 8, (4 + (sizey * 1)) * 8); draw_tile(tiles[67], (7 + (sizex * 1)) * 8, (4 + (sizey * 1)) * 8);

            for (int sx = 0; sx < sizex + 4; sx++)
            {
                draw_tile(tiles[9], (3 + (sx * 2)) * 8, 0 * 8); draw_tile(tiles[12], (4 + (sx * 2)) * 8, 0 * 8);
                draw_tile(tiles[10], (3 + (sx * 2)) * 8, 1 * 8); draw_tile(tiles[13], (4 + (sx * 2)) * 8, 1 * 8);
                draw_tile(tiles[11], (3 + (sx * 2)) * 8, 2 * 8); draw_tile(tiles[14], (4 + (sx * 2)) * 8, 2 * 8);

                draw_tile(tiles[49], (3 + (sx * 2)) * 8, (((sizey + 1) * 2) + 3) * 8); draw_tile(tiles[52], (4 + (sx * 2)) * 8, (((sizey + 1) * 2) + 3) * 8);
                draw_tile(tiles[50], (3 + (sx * 2)) * 8, (((sizey + 1) * 2) + 4) * 8); draw_tile(tiles[53], (4 + (sx * 2)) * 8, (((sizey + 1) * 2) + 4) * 8);
                draw_tile(tiles[51], (3 + (sx * 2)) * 8, (((sizey + 1) * 2) + 5) * 8); draw_tile(tiles[54], (4 + (sx * 2)) * 8, (((sizey + 1) * 2) + 5) * 8);
            }

            // 30,31
            // 32,33 // middle

            for (int sy = 0; sy < sizey + 1; sy++)
            {
                draw_tile(tiles[24], (0) * 8, (3 + sy * 2) * 8); draw_tile(tiles[25], (1) * 8, (3 + sy * 2) * 8); draw_tile(tiles[26], (2) * 8, (3 + sy * 2) * 8);
                draw_tile(tiles[27], (0) * 8, (4 + sy * 2) * 8); draw_tile(tiles[28], (1) * 8, (4 + sy * 2) * 8); draw_tile(tiles[29], (2) * 8, (4 + sy * 2) * 8);

                draw_tile(tiles[34], (((sizex + 4) * 2) + 3) * 8, (3 + sy * 2) * 8); draw_tile(tiles[35], (((sizex + 4) * 2) + 4) * 8, (3 + sy * 2) * 8); draw_tile(tiles[36], (((sizex + 4) * 2) + 5) * 8, (3 + sy * 2) * 8);
                draw_tile(tiles[37], (((sizex + 4) * 2) + 3) * 8, (4 + sy * 2) * 8); draw_tile(tiles[38], (((sizex + 4) * 2) + 4) * 8, (4 + sy * 2) * 8); draw_tile(tiles[39], (((sizex + 4) * 2) + 5) * 8, (4 + sy * 2) * 8);
            }
        }
    }

    [Serializable]
    public class object_C2 : Room_Object
    {
        public object_C2(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xC2];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
            sort = Sorting.Horizontal | Sorting.Vertical;
            showRectangle = true;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    for (int xxxx = 0; xxxx < 4; xxxx++)
                    {
                        for (int yyyy = 0; yyyy < 4; yyyy++)
                        {
                            draw_tile(tiles[0], (xxxx + (xx * 4)) * 8, (yyyy + (yy * 4)) * 8);
                        }
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_C3 : Room_Object
    {
        public object_C3(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xC3];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical;
            showRectangle = true;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    for (int xxxx = 0; xxxx < 3; xxxx++)
                    {
                        for (int yyyy = 0; yyyy < 3; yyyy++)
                        {
                            draw_tile(tiles[0], (xxxx + (xx * 3)) * 8, (yyyy + (yy * 3)) * 8);
                        }
                    }
                }
            }
        }
    }

    [Serializable]
    public class object_C4 : Room_Object
    {
        public object_C4(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xC4];
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }

        public override void Draw()
        {

            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            byte f = (byte)(room.floor1 << 4); // How can it be null oO ?
            int pos = Constants.tile_address + f;
            addTiles(8, pos);//??

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_C5 : Room_Object
    {
        public object_C5(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xC5];
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_C6 : Room_Object
    {
        public object_C6(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xC6];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos); // ??
            sort = Sorting.Horizontal | Sorting.Vertical;
            showRectangle = true;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }


    [Serializable]
    public class object_C7 : Room_Object
    {
        public object_C7(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xC7];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_C8 : Room_Object
    {
        public object_C8(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xC8];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
            addTiles(8, pos);//??
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_C9 : Room_Object
    {
        public object_C9(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xC9];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
            addTiles(8, pos);//??
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_CA : Room_Object
    {
        public object_CA(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xCA];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
            addTiles(8, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_CB : Room_Object
    {
        public object_CB(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_CC : Room_Object
    {
        public object_CC(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_CD : Room_Object
    {
        public object_CD(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xCD];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            addTiles(24, pos); // ??
            pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((0 & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((0 & 0xFF) * 2)]);
            addTiles(4, pos);
            offsetX = -8;
            LimitClass = DungeonLimits.MovingWalls;

		}

        public override void Draw()
        {
            base.Draw();

            int sizey = ((Size >> 2) & 0x03);
            int sizex = ((Size) & 0x03);
            draw_tile(tiles[0], ((sizex * 8) + 8) * 8, (0) * 8); draw_tile(tiles[3], ((sizex * 8) + 9) * 8, (0) * 8); draw_tile(tiles[6], ((sizex * 8) + 10) * 8, (0) * 8);
            draw_tile(tiles[1], ((sizex * 8) + 8) * 8, (1) * 8); draw_tile(tiles[4], ((sizex * 8) + 9) * 8, (1) * 8); draw_tile(tiles[7], ((sizex * 8) + 10) * 8, (1) * 8);
            draw_tile(tiles[2], ((sizex * 8) + 8) * 8, (2) * 8); draw_tile(tiles[5], ((sizex * 8) + 9) * 8, (2) * 8); draw_tile(tiles[8], ((sizex * 8) + 10) * 8, (2) * 8);

            draw_tile(tiles[15], ((sizex * 8) + 8) * 8, ((0 + 13) + sizey * 4) * 8); draw_tile(tiles[18], ((sizex * 8) + 9) * 8, ((0 + 13) + sizey * 4) * 8); draw_tile(tiles[21], ((sizex * 8) + 10) * 8, ((0 + 13) + sizey * 4) * 8);
            draw_tile(tiles[16], ((sizex * 8) + 8) * 8, ((1 + 13) + sizey * 4) * 8); draw_tile(tiles[19], ((sizex * 8) + 9) * 8, ((1 + 13) + sizey * 4) * 8); draw_tile(tiles[22], ((sizex * 8) + 10) * 8, ((1 + 13) + sizey * 4) * 8);
            draw_tile(tiles[17], ((sizex * 8) + 8) * 8, ((2 + 13) + sizey * 4) * 8); draw_tile(tiles[20], ((sizex * 8) + 9) * 8, ((2 + 13) + sizey * 4) * 8); draw_tile(tiles[23], ((sizex * 8) + 10) * 8, ((2 + 13) + sizey * 4) * 8);

            for (int xx = 0; xx < 4 + (sizex * 4); xx++)
            {
                for (int yy = 0; yy < 8 + (sizey * 2); yy++)
                {
                    draw_tile(tiles[24], ((xx * 2)) * 8, (yy * 2) * 8); draw_tile(tiles[25], ((xx * 2) + 1) * 8, (yy * 2) * 8);
                    draw_tile(tiles[26], ((xx * 2)) * 8, ((yy * 2) + 1) * 8); draw_tile(tiles[27], ((xx * 2) + 1) * 8, ((yy * 2) + 1) * 8);
                }
            }

            for (int yy = 0; yy < 5 + (sizey * 2); yy++)
            {
                draw_tile(tiles[9], ((sizex * 8) + 8) * 8, ((yy * 2) + 3) * 8); draw_tile(tiles[10], ((sizex * 8) + 9) * 8, ((yy * 2) + 3) * 8); draw_tile(tiles[11], ((sizex * 8) + 10) * 8, ((yy * 2) + 3) * 8);
                draw_tile(tiles[12], ((sizex * 8) + 8) * 8, ((yy * 2) + 4) * 8); draw_tile(tiles[13], ((sizex * 8) + 9) * 8, ((yy * 2) + 4) * 8); draw_tile(tiles[14], ((sizex * 8) + 10) * 8, ((yy * 2) + 4) * 8);
            }
        }
    }

    [Serializable]
    public class object_CE : Room_Object
    {
        public object_CE(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xCE];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            addTiles(24, pos); // ??
                               // Ceiling tiles
            pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((0 & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((0 & 0xFF) * 2)]);
            addTiles(4, pos);
            LimitClass = DungeonLimits.MovingWalls;

		}

        public override void Draw()
        {
            base.Draw();

            int sizey = ((Size >> 2) & 0x03);
            int sizex = ((Size) & 0x03);

            draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (1) * 8, (0) * 8); draw_tile(tiles[6], (2) * 8, (0) * 8);
            draw_tile(tiles[1], (0) * 8, (1) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8); draw_tile(tiles[7], (2) * 8, (1) * 8);
            draw_tile(tiles[2], (0) * 8, (2) * 8); draw_tile(tiles[5], (1) * 8, (2) * 8); draw_tile(tiles[8], (2) * 8, (2) * 8);

            draw_tile(tiles[15], (0) * 8, ((0 + 13) + sizey * 4) * 8); draw_tile(tiles[18], (1) * 8, ((0 + 13) + sizey * 4) * 8); draw_tile(tiles[21], (2) * 8, ((0 + 13) + sizey * 4) * 8);
            draw_tile(tiles[16], (0) * 8, ((1 + 13) + sizey * 4) * 8); draw_tile(tiles[19], (1) * 8, ((1 + 13) + sizey * 4) * 8); draw_tile(tiles[22], (2) * 8, ((1 + 13) + sizey * 4) * 8);
            draw_tile(tiles[17], (0) * 8, ((2 + 13) + sizey * 4) * 8); draw_tile(tiles[20], (1) * 8, ((2 + 13) + sizey * 4) * 8); draw_tile(tiles[23], (2) * 8, ((2 + 13) + sizey * 4) * 8);

            for (int xx = 0; xx < 4 + (sizex * 4); xx++)
            {
                for (int yy = 0; yy < 8 + (sizey * 2); yy++)
                {
                    draw_tile(tiles[24], ((xx * 2) + 3) * 8, (yy * 2) * 8); draw_tile(tiles[25], ((xx * 2) + 4) * 8, (yy * 2) * 8);
                    draw_tile(tiles[26], ((xx * 2) + 3) * 8, ((yy * 2) + 1) * 8); draw_tile(tiles[27], ((xx * 2) + 4) * 8, ((yy * 2) + 1) * 8);
                }
            }

            for (int yy = 0; yy < 5 + (sizey * 2); yy++)
            {
                draw_tile(tiles[9], (0) * 8, ((yy * 2) + 3) * 8); draw_tile(tiles[10], (1) * 8, ((yy * 2) + 3) * 8); draw_tile(tiles[11], (2) * 8, ((yy * 2) + 3) * 8);
                draw_tile(tiles[12], (0) * 8, ((yy * 2) + 4) * 8); draw_tile(tiles[13], (1) * 8, ((yy * 2) + 4) * 8); draw_tile(tiles[14], (2) * 8, ((yy * 2) + 4) * 8);
            }

        }
    }

    [Serializable]
    public class object_CF : Room_Object
    {
        public object_CF(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_D0 : Room_Object
    {
        public object_D0(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_D1 : Room_Object
    {
        public object_D1(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xD1];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos); // ??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_D2 : Room_Object
    {
        public object_D2(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xD2];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos); // ??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_D3 : Room_Object
    {
        public object_D3(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xD3];
        }

        public override void Draw()
        {
            base.Draw();
        }
    }

    [Serializable]
    public class object_D4 : Room_Object
    {
        public object_D4(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xD4];
        }

        public override void Draw()
        {
            base.Draw();
        }
    }

    [Serializable]
    public class object_D5 : Room_Object
    {
        public object_D5(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xD5];
        }

        public override void Draw()
        {
            base.Draw();
        }
    }

    [Serializable]
    public class object_D6 : Room_Object
    {
        public object_D6(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xD6];
        }

        public override void Draw()
        {
            base.Draw();
        }
    }

    [Serializable]
    public class object_D7 : Room_Object
    {
        public object_D7(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xD7];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
            sort = Sorting.Horizontal | Sorting.Vertical;
            showRectangle = true;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 3) * 8, (yy * 3) * 8); draw_tile(tiles[0], ((xx * 3) + 1) * 8, (yy * 3) * 8);
                    draw_tile(tiles[0], ((xx * 3) + 2) * 8, (yy * 3) * 8);

                    draw_tile(tiles[0], (xx * 3) * 8, ((yy * 3) + 1) * 8); draw_tile(tiles[0], ((xx * 3) + 1) * 8, ((yy * 3) + 1) * 8);
                    draw_tile(tiles[0], ((xx * 3) + 2) * 8, ((yy * 3) + 1) * 8);

                    draw_tile(tiles[0], (xx * 3) * 8, ((yy * 3) + 2) * 8); draw_tile(tiles[0], ((xx * 3) + 1) * 8, ((yy * 3) + 2) * 8);
                    draw_tile(tiles[0], ((xx * 3) + 2) * 8, ((yy * 3) + 2) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_D8 : Room_Object
    {
        public object_D8(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xD8];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
            addTiles(8, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 2; xx++)
            {
                for (int yy = 0; yy < sizey + 2; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_D9 : Room_Object
    {
        public object_D9(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xD9];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos); // ??
            sort = Sorting.Horizontal | Sorting.Vertical;
            showRectangle = true;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_DA : Room_Object
    {
        public object_DA(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xDA];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
            addTiles(8, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 2; xx++)
            {
                for (int yy = 0; yy < sizey + 2; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_DB : Room_Object
    {

        public object_DB(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xDB];
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            byte f = (byte)(room.floor2 << 4);
            int pos = Constants.tile_address + f;
            tiles.Clear();
            addTiles(8, pos);// ??

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_DC : Room_Object
    {
        public object_DC(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xDC];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(21, pos); // ??
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            draw_tile(tiles[18], (9 + (sizex * 2)) * 8, 0); // Top left rail border with size
            draw_tile(tiles[0], 0, 0); // Top left rail border
            draw_tile(tiles[1], 0, (5 + (sizey * 2)) * 8); // Bottom left rail border // Not sure why that tile exist but meh
            draw_tile(tiles[2], 0, (6 + (sizey * 2)) * 8); // Bottom left rail corner

            draw_tile(tiles[19], (9 + (sizex * 2)) * 8, (5 + (sizey * 2)) * 8); // Bottom right rail border // Not sure why that tile exist but meh
            draw_tile(tiles[20], (9 + (sizex * 2)) * 8, (6 + (sizey * 2)) * 8); // Bottom right rail corner

            for (int yy = 0; yy < sizey + 2; yy++) // Set size on 4 already
            {
                draw_tile(tiles[0], 0, (1 + (yy * 2)) * 8); // Top left rail border with size
                draw_tile(tiles[0], 0, (2 + (yy * 2)) * 8); // Top left rail border with size

                for (int xx = 0; xx < sizex + 1; xx++)
                {
                    draw_tile(tiles[3], ((xx + 1) * 8), (0 + (yy * 2)) * 8); // Left side chunk
                    draw_tile(tiles[3], ((xx + 1) * 8), (1 + (yy * 2)) * 8); // Left side chunk

                    draw_tile(tiles[15], ((xx + 8 + sizex) * 8), (0 + (yy * 2)) * 8); // Right side chunk
                    draw_tile(tiles[15], ((xx + 8 + sizex) * 8), (1 + (yy * 2)) * 8); // Right side chunk
                }

                draw_tile(tiles[6], (2 + sizex) * 8, (0 + (yy * 2)) * 8); // Left side extra line
                draw_tile(tiles[6], (2 + sizex) * 8, (1 + (yy * 2)) * 8); // Left side extra line

                draw_tile(tiles[12], (7 + sizex) * 8, (0 + (yy * 2)) * 8); // Right side extra line
                draw_tile(tiles[12], (7 + sizex) * 8, (1 + (yy * 2)) * 8); // Right side extra line

                draw_tile(tiles[9], (3 + sizex) * 8, (1 + (yy * 2)) * 8); // Middle
                draw_tile(tiles[9], (4 + sizex) * 8, (1 + (yy * 2)) * 8); // Middle
                draw_tile(tiles[9], (5 + sizex) * 8, (1 + (yy * 2)) * 8); // Middle
                draw_tile(tiles[9], (6 + sizex) * 8, (1 + (yy * 2)) * 8); // Middle
                draw_tile(tiles[9], (3 + sizex) * 8, (2 + (yy * 2)) * 8); // Middle
                draw_tile(tiles[9], (4 + sizex) * 8, (2 + (yy * 2)) * 8); // Middle
                draw_tile(tiles[9], (5 + sizex) * 8, (2 + (yy * 2)) * 8); // Middle
                draw_tile(tiles[9], (6 + sizex) * 8, (2 + (yy * 2)) * 8); // Middle

                draw_tile(tiles[18], (9 + (sizex * 2)) * 8, (1 + (yy * 2)) * 8); // Top left rail border with size
                draw_tile(tiles[18], (9 + (sizex * 2)) * 8, (2 + (yy * 2)) * 8); // Top left rail border with size   

                // draw_tile(tiles[15], ((xx + 8 + sizex) * 8), (4 + (sizey * 2)) * 8); // Last line of carpet right side chunk
            }

            draw_tile(tiles[9], (3 + sizex) * 8, (0) * 8); // Middle
            draw_tile(tiles[9], (4 + sizex) * 8, (0) * 8); // Middle
            draw_tile(tiles[9], (5 + sizex) * 8, (0) * 8); // Middle
            draw_tile(tiles[9], (6 + sizex) * 8, (0) * 8); // Middle

            draw_tile(tiles[10], (3 + sizex) * 8, (5 + (sizey * 2)) * 8); // Stairs1
            draw_tile(tiles[10], (4 + sizex) * 8, (5 + (sizey * 2)) * 8); // Stairs1
            draw_tile(tiles[10], (5 + sizex) * 8, (5 + (sizey * 2)) * 8); // Stairs1
            draw_tile(tiles[10], (6 + sizex) * 8, (5 + (sizey * 2)) * 8); // Stairs1

            draw_tile(tiles[11], (3 + sizex) * 8, (6 + (sizey * 2)) * 8); // Stairs2
            draw_tile(tiles[11], (4 + sizex) * 8, (6 + (sizey * 2)) * 8); // Stairs2
            draw_tile(tiles[11], (5 + sizex) * 8, (6 + (sizey * 2)) * 8); // Stairs2
            draw_tile(tiles[11], (6 + sizex) * 8, (6 + (sizey * 2)) * 8); // Stairs2

            draw_tile(tiles[7], (2 + sizex) * 8, (5 + (sizey * 2)) * 8);
            draw_tile(tiles[6], (2 + sizex) * 8, (4 + (sizey * 2)) * 8);
            draw_tile(tiles[12], (7 + sizex) * 8, (4 + (sizey * 2)) * 8);
            draw_tile(tiles[13], (7 + sizex) * 8, (5 + (sizey * 2)) * 8);
            draw_tile(tiles[14], (7 + sizex) * 8, (6 + (sizey * 2)) * 8);
            draw_tile(tiles[8], (2 + sizex) * 8, (6 + (sizey * 2)) * 8);

            //draw_tile(tiles[6], (2 + sizex) * 8, (5 + (sizey * 2)) * 8); // Last new line of carpet left side
            //draw_tile(tiles[6], (1 * 8), (5 + (sizey * 2)) * 8); // Last new line of carpet left side

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                draw_tile(tiles[3], ((1 + xx) * 8), (4 + (sizey * 2)) * 8); // Last line of carpet left side
                draw_tile(tiles[15], ((xx + 8 + sizex) * 8), (4 + (sizey * 2)) * 8); // Last line of carpet right side chunk
                draw_tile(tiles[4], ((1 + xx) * 8), (5 + (sizey * 2)) * 8); // last new line of carpet left side
                draw_tile(tiles[5], (1 + (xx)) * 8, (6 + (sizey * 2)) * 8); // Last line bottom left rail

                draw_tile(tiles[16], (8 + sizex + xx) * 8, (5 + (sizey * 2)) * 8); // Last new line of carpet left side
                draw_tile(tiles[17], (8 + sizex + xx) * 8, (6 + (sizey * 2)) * 8); // Last line bottom left rail
            }
        }
    }

    [Serializable]
    public class object_DD : Room_Object
    {
        public object_DD(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xDD];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            sort = Sorting.Horizontal | Sorting.Vertical;
            addTiles(16, pos);
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[5], (1 + (xx * 2)) * 8, (1 + (yy * 2)) * 8); // Middle top
                    draw_tile(tiles[6], (2 + (xx * 2)) * 8, (1 + (yy * 2)) * 8); // middle top

                    draw_tile(tiles[9], (1 + (xx * 2)) * 8, (2 + (yy * 2)) * 8); // Middle bottom
                    draw_tile(tiles[10], (2 + (xx * 2)) * 8, (2 + (yy * 2)) * 8); // Middle bottom
                }
            }

            for (int yy = 0; yy < sizey + 1; yy++)
            {
                draw_tile(tiles[4], (0) * 8, (1 + (yy * 2)) * 8); // Left border
                draw_tile(tiles[8], (0) * 8, (2 + (yy * 2)) * 8); // Left border

                draw_tile(tiles[7], (3 + (sizex * 2)) * 8, (1 + (yy * 2)) * 8); // Right border
                draw_tile(tiles[11], (3 + (sizex * 2)) * 8, (2 + (yy * 2)) * 8); // Right border
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8); // Top left corner
            draw_tile(tiles[12], (0) * 8, (3 + (sizey * 2)) * 8); // Bottom left corner

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                draw_tile(tiles[1], (1 + (xx * 2)) * 8, (0) * 8); // Top border
                draw_tile(tiles[2], (2 + (xx * 2)) * 8, (0) * 8); // Top border

                draw_tile(tiles[13], (1 + (xx * 2)) * 8, (3 + (sizey * 2)) * 8); // Bottom border
                draw_tile(tiles[14], (2 + (xx * 2)) * 8, (3 + (sizey * 2)) * 8); // Bottom border
            }

            draw_tile(tiles[3], (3 + (sizex * 2)) * 8, (0) * 8); // Top right corner
            draw_tile(tiles[15], (3 + (sizex * 2)) * 8, (3 + (sizey * 2)) * 8); // Bottom right corner
        }
    }

    [Serializable]
    public class object_DE : Room_Object
    {
        public object_DE(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xDE];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (0 + (xx * 2)) * 8, (0 + (yy * 2)) * 8); // Middle top
                    draw_tile(tiles[2], (1 + (xx * 2)) * 8, (0 + (yy * 2)) * 8); // Middle top

                    draw_tile(tiles[1], (0 + (xx * 2)) * 8, (1 + (yy * 2)) * 8); // Middle bottom
                    draw_tile(tiles[3], (1 + (xx * 2)) * 8, (1 + (yy * 2)) * 8); // Middle bottom
                }
            }
        }
    }

    [Serializable]
    public class object_DF : Room_Object
    {
        public object_DF(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xDF];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_E0 : Room_Object
    {
        public object_E0(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xE0];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_E1 : Room_Object
    {
        public object_E1(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xE1];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos); // ??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_E2 : Room_Object
    {
        public object_E2(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xE2];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos); // ??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_E3 : Room_Object
    {
        public object_E3(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xE3];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos); // ??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_E4 : Room_Object
    {
        public object_E4(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xE4];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos); // ??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }

        public override void Draw()
        {
            base.Draw();
            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_E5 : Room_Object
    {
        public object_E5(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xE5];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos); // ??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_E6 : Room_Object
    {
        public object_E6(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xE6];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos); // ??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_E7 : Room_Object
    {
        public object_E7(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xE7];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos); // ??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_E8 : Room_Object
    {

        public object_E8(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0xE8];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos); // ??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }

        public override void Draw()
        {
            base.Draw();

            int sizex = ((Size >> 2) & 0x03);
            int sizey = ((Size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (xx * 4) * 8, (yy * 4) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, (yy * 4) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, (yy * 4) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, (yy * 4) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 1) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 1) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 1) * 8);

                    draw_tile(tiles[0], (xx * 4) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[1], ((xx * 4) + 1) * 8, ((yy * 4) + 2) * 8);
                    draw_tile(tiles[2], ((xx * 4) + 2) * 8, ((yy * 4) + 2) * 8); draw_tile(tiles[3], ((xx * 4) + 3) * 8, ((yy * 4) + 2) * 8);

                    draw_tile(tiles[4], (xx * 4) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[5], ((xx * 4) + 1) * 8, ((yy * 4) + 3) * 8);
                    draw_tile(tiles[6], ((xx * 4) + 2) * 8, ((yy * 4) + 3) * 8); draw_tile(tiles[7], ((xx * 4) + 3) * 8, ((yy * 4) + 3) * 8);
                }
            }
        }
    }

    [Serializable]
    public class object_E9 : Room_Object
    {
        public object_E9(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_EA : Room_Object
    {
        public object_EA(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_EB : Room_Object
    {
        public object_EB(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_EC : Room_Object
    {
        public object_EC(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_ED : Room_Object
    {
        public object_ED(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_EE : Room_Object
    {
        public object_EE(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_EF : Room_Object
    {
        public object_EF(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_F0 : Room_Object
    {
        public object_F0(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_F1 : Room_Object
    {
        public object_F1(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_F2 : Room_Object
    {
        public object_F2(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_F3 : Room_Object
    {
        public object_F3(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_F4 : Room_Object
    {
        public object_F4(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_F5 : Room_Object
    {
        public object_F5(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_F6 : Room_Object
    {
        public object_F6(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_F7 : Room_Object
    {
        public object_F7(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = Constants.Type1RoomObjectNames[0x32];
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos); // ??
        }

        public override void Draw()
        {
            base.Draw();
            draw_tile(tiles[0], 0 * 8, 0 * 8);
            draw_tile(tiles[0], 1 * 8, 0 * 8);
            draw_tile(tiles[0], 0 * 8, 1 * 8);
            draw_tile(tiles[0], 1 * 8, 1 * 8);
        }
    }

    [Serializable]
    public class object_Block : Room_Object
    {
        public object_Block(ushort id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((0x5E & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((0x5E & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Pushable Block"; // ID E00
            options = ObjectOption.Block;
			LimitClass = DungeonLimits.GeneralManipulable;
		}

        public override void Draw()
        {
            base.Draw();

            for (int s = 0; s < Size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (0) * 8);
                draw_tile(tiles[1], (0 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (1) * 8);
            }
        }
    }
}
