using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    /*
    ALL THESE ARRAYS CONTAINS LOCATION IN TILEMAP SNES FORMAT TO WHERE TO DRAW DOOR ON SCREEN

    ALL PC ADDRESS

    doors are 4x3 up/down, 3x4 left/right

        TODO : Put those in Constants

    X = position(0, 2, 4, ..., 24)

    Door_Up
    197E,X /2 = numberoftiles 8x8 from 0,0 to the position
    Door_Down
    1996,X
    Door_Left
    19AE,X
    Door_Right
    19C6,X


    Y = ??

    GFX TILESET FOR DOORS 
    Door_Up
    4D9E,Y
    Door_Down
    4E06,Y
    Door_Left
    4E66,Y
    Door_Right
    4EC6,Y
         */

    public class object_door_up : Room_Object
    {
        public object_door_up(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[(0x4D9E + ((id>>8) & 0xFF))+1] << 8) + ROM.DATA[0x4D9E + ((id >> 8) & 0xFF)]);
            name = "Door Up";
            addTiles(12, pos);//??
        }
        public override void Draw()
        {
            if ((((id >> 8) & 0xFF) != 22) && (((id >> 8) & 0xFF) != 18))
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
    }

    public class object_door_down : Room_Object
    {
        public object_door_down(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[0x4E06+ ((id >> 8) & 0xFF)+1] << 8) + ROM.DATA[0x4E06+ ((id >> 8) & 0xFF)]);
            name = "Door down";
            addTiles(12, pos);//??
        }
        public override void Draw()
        {
            if ((((id >> 8) & 0xFF) != 22) && (((id >> 8) & 0xFF) != 18))
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
    }

    public class object_door_left : Room_Object
    {
        public object_door_left(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[0x4E66+ ((id >> 8) & 0xFF) +1] << 8) + ROM.DATA[0x4E66+ ((id >> 8) & 0xFF)]);
            name = "Door left";
            addTiles(12, pos);//??
        }
        public override void Draw()
        {
            if ((((id >> 8) & 0xFF) != 22) && (((id >> 8) & 0xFF) != 18))
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
    }

    public class object_door_right : Room_Object
    {
        public object_door_right(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[0x4EC6 + ((id >> 8) & 0xFF) +1] << 8) + ROM.DATA[0x4EC6 + ((id >> 8) & 0xFF)]);
            name = "Door right";
            addTiles(12, pos);//??
            //Console.WriteLine("Right Door ID : " + ((id >> 8) & 0xFF));
        }
        public override void Draw()
        {
            if ((((id >> 8) & 0xFF) != 22) && (((id >> 8) & 0xFF) != 18))
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
    }
}
