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

    X = position(0, 2, 4, ..., 24)

    Door_Up

         */
    //TODO : Fix exploded wall doors

    [Serializable]
    public class object_door : Room_Object
    {
        public byte door_pos = 0;
        public byte door_dir = 0;
        public byte door_type = 0;
        public object_door(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            options |= ObjectOption.Door;
            door_pos = (byte)((id & 0xF0) >> 3);
            door_dir = (byte)((id & 0x03));
            door_type = (byte)((id >> 8) & 0xFF);
            name = "Door";

        }

        public void updateId()
        {
            byte b1 = (byte)((door_pos << 3) + door_dir);
            byte b2 = door_type;
            id = (short)((b2 << 8) + b1);

        }

       /* public void setDoorDir(byte dir)
        {
            id = (short)((id & 0xFFFC)+dir);
            door_dir = dir;
        }

        public void setDoorPos(byte pos)
        {
            door_pos = pos;
            id = (short)(id | (short)(pos << 4));
        }*/

        public override void Draw()
        {

            tiles.Clear();
            int address = 0;
            if (door_dir == 0) { address = Constants.door_gfx_up; }
            if (door_dir == 1) { address = Constants.door_gfx_down; }
            if (door_dir == 2) { address = Constants.door_gfx_left; }
            if (door_dir == 3) { address = Constants.door_gfx_right; }
            int pos = Constants.tile_address + (short)((ROM.DATA[(address + ((id >> 8) & 0xFF)) + 1] << 8) + ROM.DATA[address + ((id >> 8) & 0xFF)]);
            addTiles(12, pos);//??

            int addresspos = 0;
            if (door_dir == 0) { addresspos = Constants.door_pos_up; }
            if (door_dir == 1) { addresspos = Constants.door_pos_down; }
            if (door_dir == 2) { addresspos = Constants.door_pos_left; }
            if (door_dir == 3) { addresspos = Constants.door_pos_right; }

            short posxy = (short)(((ROM.DATA[(addresspos + 1 + (door_pos))] << 8) + ROM.DATA[(addresspos + (door_pos))]) / 2);
            float n = (((float)posxy / 64) - (byte)(posxy / 64)) * 64;
            x = (byte)n;
            y = (byte)(posxy / 64);


            int w = 0, h = 0;
            if (door_dir == 0 || door_dir == 1) //up / down
            {
                w = 4;
                h = 3;
            }
            if (door_dir == 1)
            {
                y += 1;
            }
            else if (door_dir == 2 || door_dir == 3)//left / right
            {
                h = 4;
                w = 3;
            }
            if (door_dir == 3)
            {
                x += 1;
            }
            nx = x;
            ny = y;
            ox = x;
            oy = y;
            if ((((id >> 8) & 0xFF) == 22) || (((id >> 8) & 0xFF) == 18))
            {
                tiles.Clear();
                addTiles(12, 0);//??
            }

                int tid = 0;
                for (int xx = 0; xx < w; xx++)
                {
                    for (int yy = 0; yy < h; yy++)
                    {
                        draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                        tid++;
                    }
                }
            
        }

    }
}
