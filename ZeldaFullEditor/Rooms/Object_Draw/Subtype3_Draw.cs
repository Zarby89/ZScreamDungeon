using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    [Serializable] public class object_F80 : Room_Object
    {
        public object_F80(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF)-0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF)-0x80) * 2)]);
            name = "Water Face";
            addTiles(12, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int yy = 0; yy < 3; yy++)
            {
                for (int xx = 0; xx < 4; xx++)
                {

                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;

                }
            }
        }
    }

    [Serializable] public class object_F81 : Room_Object
    {
        public object_F81(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Waterfall Face";
            sort = Sorting.NonScalable;
            addTiles(20, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int yy = 0; yy < 5; yy++)
            {
                for (int xx = 0; xx < 4; xx++)
                {

                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_F82 : Room_Object
    {
        public object_F82(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Waterfall Face Longer";
            sort = Sorting.NonScalable;
            addTiles(28, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int yy = 0; yy < 7; yy++)
            {
                for (int xx = 0; xx < 4; xx++)
                {

                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_F83 : Room_Object
    {
        public object_F83(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "?";
            sort = Sorting.NonScalable;
            addTiles(1, pos);//??
        }
        public override void Draw()
        {
            draw_tile(tiles[0], (0) * 8, (0) * 8);
        }
    }

    [Serializable] public class object_F84 : Room_Object
    {
        public object_F84(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "?";
            sort = Sorting.NonScalable;
            addTiles(1, pos);//??
        }
        public override void Draw()
        {
            draw_tile(tiles[0], (0) * 8, (0) * 8);
        }
    }

    [Serializable] public class object_F85 : Room_Object
    {
        public object_F85(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "?";
            sort = Sorting.NonScalable;
            addTiles(1, pos);//??
        }
        public override void Draw()
        {
            draw_tile(tiles[0], (0) * 8, (0) * 8);
        }
    }

    [Serializable] public class object_F86 : Room_Object
    {
        public object_F86(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "?";
            sort = Sorting.NonScalable;
            addTiles(1, pos);//??
        }
        public override void Draw()
        {
            draw_tile(tiles[0], (0) * 8, (0) * 8);
        }
    }
    [Serializable] public class object_F87 : Room_Object
    {
        public object_F87(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "?";
            sort = Sorting.NonScalable;
            addTiles(1, pos);//??
        }
        public override void Draw()
        {
            draw_tile(tiles[0], (0) * 8, (0) * 8);
        }
    }
    [Serializable] public class object_F88 : Room_Object
    {
        public object_F88(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "?";
            sort = Sorting.NonScalable;
            addTiles(1, pos);//??
        }
        public override void Draw()
        {
            draw_tile(tiles[0], (0) * 8, (0) * 8);
        }
    }

    [Serializable] public class object_F89 : Room_Object
    {
        public object_F89(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "?";
            sort = Sorting.NonScalable;
            addTiles(1, pos);//??
        }
        public override void Draw()
        {
            draw_tile(tiles[0], (0) * 8, (0) * 8);
        }
    }
    [Serializable] public class object_F8A : Room_Object
    {
        public object_F8A(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "?";
            addTiles(1, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            draw_tile(tiles[0], (0) * 8, (0) * 8);
        }
    }
    [Serializable] public class object_F8B : Room_Object
    {
        public object_F8B(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "?";
            addTiles(1, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            draw_tile(tiles[0], (0) * 8, (0) * 8);
        }
    }
    [Serializable] public class object_F8C : Room_Object
    {
        public object_F8C(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "?";
            addTiles(1, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            draw_tile(tiles[0], (0) * 8, (0) * 8);
        }
    }
    [Serializable] public class object_F8D : Room_Object
    {
        public object_F8D(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Cell";
            addTiles(6, pos);
            addTiles(6, pos);
            sort = Sorting.NonScalable;
            for (int i = 6;i<12;i++)
            {
                tiles[i].mirror_x = true;
            }
        }
        public override void Draw()
        {
            draw_tile(tiles[0], 0, 0);
            draw_tile(tiles[1], (1) * 8, 0);

            draw_tile(tiles[6], (15) * 8, 0);
            draw_tile(tiles[7], (14) * 8, 0);

            draw_tile(tiles[3], (1) * 8, 2 * 8);
            draw_tile(tiles[9], (14) * 8, 2 * 8);
            for (int xx = 0; xx < 5; xx++)
            {
                draw_tile(tiles[1], (xx + 2) * 8, (0) * 8); draw_tile(tiles[7], (xx + 9) * 8, (0) * 8);
                draw_tile(tiles[2], (xx + 2) * 8, (1) * 8); draw_tile(tiles[8], (xx + 9) * 8, (1) * 8);
                draw_tile(tiles[4], (xx + 2) * 8, (2) * 8); draw_tile(tiles[10], (xx + 9) * 8, (2) * 8);
                draw_tile(tiles[5], (xx + 2) * 8, (3) * 8); draw_tile(tiles[11], (xx + 9) * 8, (3) * 8);
            }
        }
    }
    [Serializable] public class object_F8E : Room_Object
    {
        public object_F8E(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "?";
            addTiles(1, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            draw_tile(tiles[0], (0) * 8, (0) * 8);
        }
    }
    [Serializable] public class object_F8F : Room_Object
    {
        public object_F8F(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "?";
            addTiles(1, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            draw_tile(tiles[0], (0) * 8, (0) * 8);
        }
    }
    [Serializable] public class object_F90 : Room_Object
    {
        public object_F90(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "?";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {

                for (int yy = 0; yy < 2; yy++)
            {

                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_F91 : Room_Object
    {
        public object_F91(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "?";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
            {


                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_F92 : Room_Object
    {
        public object_F92(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Rupee Floor";
            addTiles(4, pos);//??
            sort = Sorting.Floors |Sorting.NonScalable; 
        }
        public override void Draw()
        {
            for (int yy = 0; yy < 3; yy++)
            {
                for (int xx = 0; xx < 3; xx++)
                {
                    draw_tile(tiles[0], (xx*2) * 8, ((yy *3)) * 8);
                    draw_tile(tiles[1], (xx*2) * 8, (1+(yy *3)) * 8);
                }
            }
        }
    }

    [Serializable] public class object_F93 : Room_Object
    {
        public object_F93(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Telepathic Tile";
            sort = Sorting.NonScalable;
            addTiles(4, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;

                for (int xx = 0; xx < 2; xx++)
                {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_F94 : Room_Object
    {
        public object_F94(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Down Warp Door";
            sort = Sorting.NonScalable;
            addTiles(12, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int yy = 0; yy < 3; yy++)
            {
                for (int xx = 0; xx < 4; xx++)
                {

                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_F95 : Room_Object
    {
        public object_F95(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Kholdstare Shell";
            sort = Sorting.NonScalable;
            addTiles(80, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int yy = 0; yy < 8; yy++)
            {
                for (int xx = 0; xx < 10; xx++)
                {

                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_F96 : Room_Object
    {
        public object_F96(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Single Hammer Peg";
            sort = Sorting.NonScalable;
            addTiles(4, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
            {


                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }


    [Serializable] public class object_F97 : Room_Object
    {
        public object_F97(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Cell";
            sort = Sorting.NonScalable;
            addTiles(6, pos);
            addTiles(6, pos);
            for (int i = 6; i < 12; i++)
            {
                tiles[i].mirror_x = true;
            }
        }
        public override void Draw()
        {
            draw_tile(tiles[0], 0, 0);
            draw_tile(tiles[1], (1) * 8, 0);

            draw_tile(tiles[6], (15)*8, 0);
            draw_tile(tiles[7], (14) * 8, 0);

            draw_tile(tiles[3], (1) * 8, 2 * 8);
            draw_tile(tiles[9], (14) * 8, 2 * 8);
            for (int xx = 0; xx < 5; xx++)
            {
                draw_tile(tiles[1], (xx + 2) * 8, (0) * 8); draw_tile(tiles[7], (xx + 9) * 8, (0) * 8);
                draw_tile(tiles[2], (xx + 2) * 8, (1) * 8); draw_tile(tiles[8], (xx + 9) * 8, (1) * 8);
                draw_tile(tiles[4], (xx + 2) * 8, (2) * 8); draw_tile(tiles[10], (xx + 9) * 8, (2) * 8);
                draw_tile(tiles[5], (xx + 2) * 8, (3) * 8); draw_tile(tiles[11], (xx + 9) * 8, (3) * 8);
            }
            
        }
    }


    [Serializable] public class object_F98 : Room_Object
    {
        public object_F98(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Cell Lock";
            sort = Sorting.NonScalable;
            addTiles(4, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;

                for (int xx = 0; xx < 2; xx++)
                {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }


    [Serializable] public class object_F99 : Room_Object
    {
        public object_F99(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Chest";
            sort = Sorting.NonScalable;
            addTiles(4, pos);//??
            this.options |= ObjectOption.Chest;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
            {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }


    [Serializable] public class object_F9A : Room_Object
    {
        public object_F9A(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Open Chest";
            sort = Sorting.NonScalable;
            addTiles(4, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_F9B : Room_Object
    {
        public object_F9B(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Stair";
            sort = Sorting.NonScalable | Sorting.Stairs;
            allBgs = true;
            addTiles(16, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_F9C : Room_Object
    {
        public object_F9C(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Stair";
            allBgs = true;
            sort = Sorting.NonScalable | Sorting.Stairs;
            addTiles(16, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_F9D : Room_Object
    {
        public object_F9D(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Stair";
            allBgs = true;
            sort = Sorting.NonScalable | Sorting.Stairs;
            addTiles(16, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_F9E : Room_Object
    {
        public object_F9E(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Staircase going Up(Up)";
            addTiles(16, pos);//??
            sort = Sorting.NonScalable | Sorting.Stairs;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_F9F : Room_Object
    {
        public object_F9F(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Staircase Going Down (Up)";
            addTiles(16, pos);//??
            sort = Sorting.NonScalable | Sorting.Stairs;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FA0 : Room_Object
    {
        public object_FA0(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Staircase Going Up (Down)";
            addTiles(16, pos);//??
            sort = Sorting.NonScalable | Sorting.Stairs;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FA1 : Room_Object
    {
        public object_FA1(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Staircase Going Down (Down)";
            addTiles(16, pos);//??
            sort = Sorting.NonScalable | Sorting.Stairs;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FA2 : Room_Object
    {
        public object_FA2(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Pit Wall Corner";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FA3 : Room_Object
    {
        public object_FA3(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Pit Wall Corner";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FA4 : Room_Object
    {
        public object_FA4(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Pit Wall Corner";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FA5 : Room_Object
    {
        public object_FA5(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Pit Wall Corner";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FA6 : Room_Object
    {
        public object_FA6(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Staircase Going Up (Lower)";
            addTiles(16, pos);//??
            sort = Sorting.NonScalable | Sorting.Stairs;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FA7 : Room_Object
    {
        public object_FA7(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Staircase Going Up (Lower)";
            sort = Sorting.NonScalable | Sorting.Stairs;
            addTiles(16, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FA8 : Room_Object
    {
        public object_FA8(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Staircase Going Down (Lower)";
            sort = Sorting.NonScalable | Sorting.Stairs;
            addTiles(16, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FA9 : Room_Object
    {
        public object_FA9(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Staircase Going Down (Lower)";
            sort = Sorting.NonScalable | Sorting.Stairs;
            addTiles(16, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FAA : Room_Object
    {
        public object_FAA(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "LAMP !? WTF";
            addTiles(16, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {

        }
    }

    [Serializable] public class object_FAB : Room_Object
    {
        public object_FAB(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Staircase Going Down (Lower)";
            sort = Sorting.NonScalable | Sorting.Stairs;
            addTiles(4, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FAC : Room_Object
    {
        public object_FAC(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Rock";
            sort = Sorting.NonScalable;
            addTiles(16, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    draw_tile(tiles[tid+4], (xx+2) * 8, (yy) * 8);
                    draw_tile(tiles[tid+8], (xx) * 8, (yy+2) * 8);
                    draw_tile(tiles[tid+12], (xx+2) * 8, (yy+2) * 8);
                    tid++;
                }
            }
        }
    }


    [Serializable] public class object_FAD : Room_Object
    {
        public object_FAD(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            //harcoded position wtf ?!?
            int pos = Constants.tile_address + 0x1B4A;
            name = "Agahnim Altar?";
            sort = Sorting.NonScalable;
            addTiles(84, pos);//??
        }
        public override void Draw()
        {

            int tid = 0;
            for (int yy = 0; yy < 14; yy++)
            {
                //390

                tiles[tid].mirror_x = false;
                draw_tile(tiles[tid], (0) * 8, (yy) * 8);
                tiles[tid + 14].mirror_x = false;
                draw_tile(tiles[tid+14], (1) * 8, (yy) * 8);
                draw_tile(tiles[tid+14], (2) * 8, (yy) * 8);
                tiles[tid + 28].mirror_x = false;
                draw_tile(tiles[tid+28], (3) * 8, (yy) * 8);
                tiles[tid + 48].mirror_x = true;
                draw_tile(tiles[tid+42], (4) * 8, (yy) * 8);
                tiles[tid + 56].mirror_x = false;
                draw_tile(tiles[tid + 56], (5) * 8, (yy) * 8);

                tiles[tid + 70].mirror_x = false;
                draw_tile(tiles[tid + 70], (6) * 8, (yy) * 8);
                tiles[tid + 70].mirror_x = true;
                draw_tile(tiles[tid + 70], (7) * 8, (yy) * 8);
                tiles[tid + 56].mirror_x = true;
                draw_tile(tiles[tid + 56], (8) * 8, (yy) * 8);
                tiles[tid + 48].mirror_x = true;
                draw_tile(tiles[tid + 42], (9) * 8, (yy) * 8);
                tiles[tid + 28].mirror_x = true;
                draw_tile(tiles[tid + 28], (10) * 8, (yy) * 8);
                tiles[tid + 14].mirror_x = true;
                draw_tile(tiles[tid + 14], (11) * 8, (yy) * 8);
                draw_tile(tiles[tid + 14], (12) * 8, (yy) * 8);
                tiles[tid].mirror_x = true;
                draw_tile(tiles[tid], (13) * 8, (yy) * 8);
                tid++;
            }
       
        }
    }

    [Serializable] public class object_FAE : Room_Object
    {
        public object_FAE(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + 0x1BF2;
            name = "Agahnim Room";
            addTiles(127, pos);//??
            sort = Sorting.NonScalable;
            //6x4 (top wall) 24
            //1x5 (diago left) 5
            //4x6 (side wall) (left need to be mirrored to right) 24
            //6x2 (top light) 12
            //2x6 (left light) 12
            //5x5 (diagonal light) 25
        }
        public override void Draw()
        {
            //Top Wall
            int tid = 0;
            for (int i = 0; i < 3; i++)
            {
                tid = 0;
                for (int xx = 0; xx < 6; xx++)
                {
                    for (int yy = 0; yy < 4; yy++)
                    {
                        //5
                        draw_tile(tiles[tid], (7+xx + (i*6)) * 8, (4+yy) * 8);
                        tid++;
                    }

                }
            }

            //diagonals wall
            for (int xx = 0; xx < 7; xx++)
            {
                //5
                tiles[24].mirror_x = false;
                tiles[25].mirror_x = false;
                tiles[26].mirror_x = false;
                tiles[27].mirror_x = false;
                tiles[28].mirror_x = false;
                draw_tile(tiles[24], (8 - xx) * 8, (4 + xx) * 8);
                draw_tile(tiles[25], (8 - xx) * 8, (5 + xx) * 8);
                draw_tile(tiles[26], (8 - xx) * 8, (6 + xx) * 8);
                draw_tile(tiles[27], (8 - xx) * 8, (7 + xx) * 8);
                draw_tile(tiles[28], (8 - xx) * 8, (8 + xx) * 8);

                tiles[24].mirror_x = true;
                tiles[25].mirror_x = true;
                tiles[26].mirror_x = true;
                tiles[27].mirror_x = true;
                tiles[28].mirror_x = true;
                draw_tile(tiles[24], (23 + xx) * 8, (4 + xx) * 8);
                draw_tile(tiles[25], (23 + xx) * 8, (5 + xx) * 8);
                draw_tile(tiles[26], (23 + xx) * 8, (6 + xx) * 8);
                draw_tile(tiles[27], (23 + xx) * 8, (7 + xx) * 8);
                draw_tile(tiles[28], (23 + xx) * 8, (8 + xx) * 8);
            }


            //sides walls
            for (int i = 0; i < 3; i++)
            {
                tid = 29;
                for (int yy = 0; yy < 6; yy++)
                {
                    for (int xx = 0; xx < 4; xx++)
                    {
                        //5
                        tiles[tid].mirror_x = false;
                        draw_tile(tiles[tid], (2 + xx) * 8, (11 + yy + (i * 6)) * 8);
                        tiles[tid].mirror_x = true;
                        draw_tile(tiles[tid], (29 - xx) * 8, (11 + yy + (i * 6)) * 8);
                        tid++;
                    }

                }
            }


            //53
            for (int i = 0; i < 2; i++)
            {
                tid = 53;
                for (int yy = 0; yy < 2; yy++)
                {
                    for (int xx = 0; xx < 6; xx++)
                {
                        draw_tile(tiles[tid], (12 + xx + (i * 6)) * 8, (9 + yy ) * 8);
                        //tiles[tid].mirror_x = true;
                        //draw_tile(tiles[tid], (29 - xx + (i * 6)) * 8, (8 + yy ) * 8);
                        tid++;
                    }

                }
            }

            for (int i = 0; i < 2; i++)
            {
                tid = 65;
                for (int yy = 0; yy < 6; yy++)
                {
                    for (int xx = 0; xx < 2; xx++)
                    {
                        draw_tile(tiles[tid], (7 + xx ) * 8, (14 + yy + (i * 6)) * 8);
                        //tiles[tid].mirror_x = true;
                        //draw_tile(tiles[tid], (29 - xx + (i * 6)) * 8, (8 + yy ) * 8);
                        tid++;
                    }

                }
            }


                tid = 77;

                    for (int xx = 0; xx < 5; xx++)
                    {
                for (int yy = 0; yy < 5; yy++)
                {
                    draw_tile(tiles[tid], (7 + xx) * 8, (9 + yy) * 8);
                        tid++;
                    }

                }
        }
    }

    [Serializable] public class object_FAF : Room_Object
    {
        public object_FAF(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Pot";
            //0x0E92; for skulls
            addTiles(4, pos);//??
            sort = Sorting.NonScalable | Sorting.Dungeons;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FB0 : Room_Object
    {
        public object_FB0(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "??";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FB1 : Room_Object
    {
        public object_FB1(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Big Chest";
            addTiles(12, pos);//??
            sort = Sorting.NonScalable | Sorting.Dungeons;
            options |= ObjectOption.Chest;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }


    [Serializable] public class object_FB2 : Room_Object
    {
        public object_FB2(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Big Chest Open";
            addTiles(12, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }


    [Serializable] public class object_FB3 : Room_Object
    {
        public object_FB3(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Stairs";
            allBgs = true;
            addTiles(16, pos);//??
            sort = Sorting.NonScalable | Sorting.Stairs;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FB4 : Room_Object
    {
        public object_FB4(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            sort = Sorting.NonScalable;
            addTiles(6, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 3; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FB5 : Room_Object
    {
        public object_FB5(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(6, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 3; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FB6 : Room_Object
    {
        public object_FB6(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(18, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 6; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FB7 : Room_Object
    {
        public object_FB7(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(18, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 6; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FB8 : Room_Object
    {
        public object_FB8(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(18, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 6; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FB9 : Room_Object
    {
        public object_FB9(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(18, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 6; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FBA : Room_Object
    {
        public object_FBA(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(24, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    draw_tile(tiles[tid+6], (xx+2) * 8, (yy) * 8);
                    tid++;
                }
            }

                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid + 6], 0 * 8, (yy+3) * 8);
                    draw_tile(tiles[tid + 9], (1) * 8, (yy+3) * 8);
                    draw_tile(tiles[tid + 12], (2) * 8, (yy+3) * 8);
                    draw_tile(tiles[tid + 15], (3) * 8, (yy+3) * 8);
                    tid++;
                }
        }
    }

    [Serializable] public class object_FBB : Room_Object
    {
        public object_FBB(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(24, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    draw_tile(tiles[tid + 6], (xx + 2) * 8, (yy) * 8);
                    tid++;
                }
            }

            for (int yy = 0; yy < 3; yy++)
            {
                draw_tile(tiles[tid + 6], 0 * 8, (yy + 3) * 8);
                draw_tile(tiles[tid + 9], (1) * 8, (yy + 3) * 8);
                draw_tile(tiles[tid + 12], (2) * 8, (yy + 3) * 8);
                draw_tile(tiles[tid + 15], (3) * 8, (yy + 3) * 8);
                tid++;
            }
        }
    }

    [Serializable] public class object_FBC : Room_Object
    {
        public object_FBC(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(24, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 6; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FBD : Room_Object
    {
        public object_FBD(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(24, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 6; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FBE : Room_Object
    {
        public object_FBE(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }
    [Serializable] public class object_FBF : Room_Object
    {
        public object_FBF(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }
    [Serializable] public class object_FC : Room_Object
    {
        public object_FC(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }
    [Serializable] public class object_FC0 : Room_Object
    {
        public object_FC0(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }
    [Serializable] public class object_FC1 : Room_Object
    {
        public object_FC1(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }
    [Serializable] public class object_FC2 : Room_Object
    {
        public object_FC2(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }
    [Serializable] public class object_FC3 : Room_Object
    {
        public object_FC3(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }
    [Serializable] public class object_FC4 : Room_Object
    {
        public object_FC4(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }
    [Serializable] public class object_FC5 : Room_Object
    {
        public object_FC5(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }
    [Serializable] public class object_FC6 : Room_Object
    {
        public object_FC6(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FC7 : Room_Object
    {
        public object_FC7(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(16, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FC8 : Room_Object
    {
        public object_FC8(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(16, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FC9 : Room_Object
    {
        public object_FC9(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FCA : Room_Object
    {
        public object_FCA(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Warp Tile";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FCB : Room_Object
    {
        public object_FCB(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(24, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 8; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FCC : Room_Object
    {
        public object_FCC(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(48, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int yy = 0; yy < 8; yy++)
            {
                for (int xx = 0; xx < 6; xx++)
            {

                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FCD : Room_Object
    {
        public object_FCD(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(18, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 6; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);

                    tid++;
                }
                for (int yy = 0; yy < 3; yy++)
                {

                }
            }

        }
    }

    [Serializable] public class object_FCE : Room_Object
    {
        public object_FCE(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(12, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }


    [Serializable] public class object_FCF : Room_Object
    {
        public object_FCF(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Inactive Warp";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }


    [Serializable] public class object_FD0 : Room_Object
    {
        public object_FD0(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Floor Switch";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }


    [Serializable] public class object_FD1 : Room_Object
    {
        public object_FD1(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }


    [Serializable] public class object_FD2 : Room_Object
    {
        public object_FD2(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Single Blue Peg";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }


    [Serializable] public class object_FD3 : Room_Object
    {
        public object_FD3(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Single Red Peg";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }


    [Serializable] public class object_FD4 : Room_Object
    {
        public object_FD4(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FD5 : Room_Object
    {
        public object_FD5(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(9, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 3; xx++)
            {
                for (int yy = 0; yy < 1; yy++)
                {
                    //draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }

                for (int yy = 0; yy < 3; yy++)
                {
                    //draw_tile(tiles[tid], (xx) * 8, (yy+1) * 8);
                    //draw_tile(tiles[tid+1], (xx) * 8, (yy+1) * 8);
                    //draw_tile(tiles[tid+2], (xx) * 8, (yy+1) * 8);
                }
                tid += 3;
                for (int yy = 0; yy < 1; yy++)
                {
                    //draw_tile(tiles[tid], (xx) * 8, (yy+4) * 8);
                }
            }

        }
    }

    [Serializable] public class object_FD6 : Room_Object
    {
        public object_FD6(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy <2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FD7 : Room_Object
    {
        public object_FD7(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FD8 : Room_Object
    {
        public object_FD8(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(6, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FD9 : Room_Object
    {
        public object_FD9(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FDA : Room_Object
    {
        public object_FDA(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(8, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int yy = 0; yy < 2; yy++)
            {
                for (int xx = 0; xx < 4; xx++)
            {

                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FDB : Room_Object
    {
        public object_FDB(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(32, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;


            for (int xx = 0; xx < 3; xx++)
            {
                tid = 0+xx;
                for (int yy = 0; yy < 1; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                }
                tid = 1+xx;
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy + 1) * 8);
                    draw_tile(tiles[tid + 1], (xx) * 8, (yy + 1) * 8);
                    draw_tile(tiles[tid + 2], (xx) * 8, (yy + 1) * 8);
                }
                tid = 6 + xx;
                for (int yy = 0; yy < 1; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy + 4) * 8);
                }
            }

        }
    }

    [Serializable] public class object_FDC : Room_Object
    {
        public object_FDC(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(24, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 6; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FDD : Room_Object
    {
        public object_FDD(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(18, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 6; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FDE : Room_Object
    {
        public object_FDE(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }


    [Serializable] public class object_FDF : Room_Object
    {
        public object_FDF(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }


    [Serializable] public class object_FE0 : Room_Object
    {
        public object_FE0(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Left Warp Door";
            addTiles(18, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 3; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy+2) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FE1 : Room_Object
    {
        public object_FE1(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Right Warp Door";
            addTiles(18, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 3; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy + 2) * 8);
                    tid++;
                }
            }

        }
    }


    [Serializable] public class object_FE2 : Room_Object
    {
        public object_FE2(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(242, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FE3 : Room_Object
    {
        public object_FE3(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }


    [Serializable] public class object_FE4 : Room_Object
    {
        public object_FE4(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Medusa Head";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }
    [Serializable] public class object_FE5 : Room_Object
    {
        public object_FE5(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Fireball Shooter";
            addTiles(4, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FE6 : Room_Object
    {
        public object_FE6(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Hole";
            addTiles(16, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FE7 : Room_Object
    {
        public object_FE7(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Top Crack Wall";
            addTiles(12, pos);//??
            sort = Sorting.NonScalable | Sorting.Wall;
        }
        public override void Draw()
        {
            int tid = 0;

                for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FE8 : Room_Object
    {
        public object_FE8(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Bottom Crack Wall";
            addTiles(12, pos);//??
            sort = Sorting.NonScalable | Sorting.Wall;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FE9 : Room_Object
    {
        public object_FE9(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Left Crack Wall";
            addTiles(12, pos);//??
            sort = Sorting.NonScalable | Sorting.Wall;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 3; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FEA : Room_Object
    {
        public object_FEA(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Right Crack Wall";
            addTiles(12, pos);//??
            sort = Sorting.NonScalable | Sorting.Wall;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 3; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FEB : Room_Object
    {
        public object_FEB(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Throne/ Decoration Object";
            sort = Sorting.NonScalable;
            addTiles(16, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FEC : Room_Object
    {
        public object_FEC(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            sort = Sorting.NonScalable;
            addTiles(12, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FED : Room_Object
    {
        public object_FED(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            sort = Sorting.NonScalable;
            addTiles(12, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FEE : Room_Object
    {
        public object_FEE(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            sort = Sorting.NonScalable;
            addTiles(12, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 3; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FEF : Room_Object
    {
        public object_FEF(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            sort = Sorting.NonScalable;
            addTiles(12, pos);//??

        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 3; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FF0 : Room_Object
    {
        public object_FF0(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Floor Light";
            sort = Sorting.NonScalable;
            addTiles(32, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }

            }
            draw_tile(tiles[0], (0) * 8, (4) * 8);
            draw_tile(tiles[1], (1) * 8, (4) * 8);
            draw_tile(tiles[2], (2) * 8, (4) * 8);
            draw_tile(tiles[3], (3) * 8, (4) * 8);

            draw_tile(tiles[0], (0) * 8, (5) * 8);
            draw_tile(tiles[1], (1) * 8, (5) * 8);
            draw_tile(tiles[2], (2) * 8, (5) * 8);
            draw_tile(tiles[3], (3) * 8, (5) * 8);
            tid = 16;
            for (int xx = 0; xx < 4; xx++)
            {
               
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy+6) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FF1 : Room_Object
    {
        public object_FF1(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            sort = Sorting.NonScalable;
            addTiles(64, pos);//??
        }
        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 8; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    draw_tile(tiles[tid+32], (xx) * 8, (yy+4) * 8);
                    tid++;
                }
            }

        }
    }

    [Serializable] public class object_FF2 : Room_Object
    {
        public object_FF2(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Trinexx Shell";
            addTiles(80, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {
            int tid = 0;
            for (int yy = 0; yy < 8; yy++)
            {
                for (int xx = 0; xx < 10; xx++)
                {

                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }


    [Serializable] public class object_FF3 : Room_Object
    {
        public object_FF3(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Bg2 Full Mask";
            addTiles(1, pos);//??
            sort = Sorting.NonScalable;
        }

        public override void Draw()
        {
           /* for (int yy = 0; yy < 64; yy++)
            {
                for (int xx = 0; xx < 64; xx++)
                {
                    draw_tile(tiles[0], (xx) * 8, (yy) * 8);
                }
            }*/
        }
    }

    [Serializable] public class object_FF4 : Room_Object
    {
        public object_FF4(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Boss Entrance";
            addTiles(64, pos);//??
            sort = Sorting.NonScalable;
        }

        public override void Draw()
        {
            int tid = 0;
            for (int xx = 0; xx < 8; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    draw_tile(tiles[tid + 32], (xx) * 8, (yy + 4) * 8);
                    tid++;
                }
            }
        }
    }


    [Serializable] public class object_FF5 : Room_Object
    {
        public object_FF5(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "Minigame Chest";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {

            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FF6 : Room_Object
    {
        public object_FF6(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(24, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {

            int tid = 0;
            for (int xx = 0; xx < 8; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FF7 : Room_Object
    {
        public object_FF7(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(24, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {

            int tid = 0;
            for (int xx = 0; xx < 8; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FF8 : Room_Object
    {
        public object_FF8(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(24, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {

        }
    }


    [Serializable] public class object_FF9 : Room_Object
    {
        public object_FF9(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(12, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {

            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FFA : Room_Object
    {
        public object_FFA(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(16, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {

            int tid = 0;
            for (int xx = 0; xx < 4; xx++)
            {
                for (int yy = 0; yy < 4; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FFB : Room_Object
    {
        public object_FFB(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(12, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {


        }
    }

    [Serializable] public class object_FFC : Room_Object
    {
        public object_FFC(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {

            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FFD : Room_Object
    {
        public object_FFD(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {

            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }

    [Serializable] public class object_FFE : Room_Object
    {
        public object_FFE(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2) + 1] << 8) + ROM.DATA[Constants.subtype3_tiles + (((id & 0xFF) - 0x80) * 2)]);
            name = "???";
            addTiles(4, pos);//??
            sort = Sorting.NonScalable;
        }
        public override void Draw()
        {

            int tid = 0;
            for (int xx = 0; xx < 2; xx++)
            {
                for (int yy = 0; yy < 2; yy++)
                {
                    draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                    tid++;
                }
            }
        }
    }
}
