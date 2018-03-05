using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    [Serializable]
    public class object_00 : Room_Object
    {
        
        public object_00(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Ceiling ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            if (this.size == 0)
            {
                this.size = 32;
            }
            for (int s = 0; s < size; s++)
            {
                draw_tile(tiles[0], ((s * 2)) * 8, 0); draw_tile(tiles[2], (1 + (s * 2)) * 8, 0);
                draw_tile(tiles[1], ((s * 2)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 2)) * 8, (1) * 8);

            }
        }
    }

    [Serializable]
    public class object_01 : Room_Object
    {
        public object_01(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Top Wall Horiz. ↔";
            sort = Sorting.Horizontal | Sorting.Wall;

        }

        public override void Draw()
        {
            if (this.size == 0)
            {
                this.size = 26;
            }
            for (int s = 0; s < size; s++)
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

        public object_02(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Bottom Wall Horiz. ↔";
            sort = Sorting.Horizontal | Sorting.Wall;
        }

        public override void Draw()
        {
            if (this.size == 0)
            {
                this.size = 26;
            }
            for (int s = 0; s < size; s++)
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

        public object_03(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            allBgs = true;
            name = "Top Wall Horiz. (Lower) ↔";
            sort = Sorting.Horizontal | Sorting.Wall;
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 1; s++)
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

        public object_04(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            allBgs = true;
            name = "Bottom Wall Horiz. (Lower) ↔";
            sort = Sorting.Horizontal | Sorting.Wall;
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 1; s++)
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

        public object_05(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Top Wall Column ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 1; s++)
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

        public object_06(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Bottom Wall Column ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 1; s++)
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

        public object_07(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Top Wall Pit ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 2)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 2)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 2)) * 8, (1) * 8);
            }
        }
    }

    [Serializable]
    public class object_08 : Room_Object
    {

        public object_08(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Bottom Wall Pit ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 2)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 2)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 2)) * 8, (1) * 8);
            }
        }
    }

    [Serializable]
    public class object_09 : Room_Object
    {

        public object_09(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◤";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_0A : Room_Object
    {

        public object_0A(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◣";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_0B : Room_Object
    {

        public object_0B(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◥";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_0C : Room_Object
    {

        public object_0C(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◢";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            draw_diagonal_up();
        }
    }


    [Serializable]
    public class object_0D : Room_Object
    {

        public object_0D(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◤";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_0E : Room_Object
    {

        public object_0E(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◣";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_0F : Room_Object
    {

        public object_0F(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◥";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_10 : Room_Object
    {

        public object_10(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◢";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_11 : Room_Object
    {

        public object_11(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◤";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_12 : Room_Object
    {

        public object_12(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◣";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_13 : Room_Object
    {

        public object_13(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◥";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_14 : Room_Object
    {

        public object_14(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◢ ";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_15 : Room_Object
    {

        public object_15(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◤";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_16 : Room_Object
    {

        public object_16(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◣";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_17 : Room_Object
    {

        public object_17(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◥";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_18 : Room_Object
    {

        public object_18(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◢";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_19 : Room_Object
    {

        public object_19(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◤";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_1A : Room_Object
    {

        public object_1A(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◣";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_1B : Room_Object
    {

        public object_1B(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◥";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            draw_diagonal_down();
        }
    }

    [Serializable]
    public class object_1C : Room_Object
    {

        public object_1C(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◢";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            draw_diagonal_up();
        }
    }

    [Serializable]
    public class object_1D : Room_Object
    {

        public object_1D(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◤";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            draw_diagonal_up();
        }
    }

    [Serializable] public class object_1E : Room_Object
    {

        public object_1E(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◣";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            draw_diagonal_down();
        }
    }

    [Serializable] public class object_1F : Room_Object
    {

        public object_1F(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◥";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            draw_diagonal_down();
        }
    }

    [Serializable] public class object_20 : Room_Object
    {

        public object_20(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(5, pos);
            name = "Diagonal Wall ◢";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            draw_diagonal_up();
        }
    }


    [Serializable] public class object_21 : Room_Object
    {

        public object_21(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(9, pos);
            name = "Mini Stairs ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[3], (1 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[3], (2 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[4], (1 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[4], (2 + (s * 2)) * 8, (1) * 8);
                draw_tile(tiles[5], (1 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[5], (2 + (s * 2)) * 8, (2) * 8);
            }
            draw_tile(tiles[0], 0, (0) * 8);
            draw_tile(tiles[1], 0, (1) * 8);
            draw_tile(tiles[2], 0, (2) * 8);

            draw_tile(tiles[6], ((size * 2) + 3) * 8, (0) * 8);
            draw_tile(tiles[7], ((size * 2) + 3) * 8, (1) * 8);
            draw_tile(tiles[8], ((size * 2) + 3) * 8, (2) * 8);

        }
    }


    [Serializable] public class object_22 : Room_Object
    {

        public object_22(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Horizontal Rail ↔";
            sort = Sorting.Horizontal | Sorting.Dungeons;
        }

        public override void Draw()
        {

            
            for (int s = 0; s < size + 2; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 2) + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_23 : Room_Object
    {

        public object_23(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Pit Top Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], 0, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_24 : Room_Object
    {

        public object_24(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Pit Top Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_25 : Room_Object
    {

        public object_25(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Pit Top Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_26 : Room_Object
    {

        public object_26(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Pit Top Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_27 : Room_Object
    {

        public object_27(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Pit Top Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_28 : Room_Object
    {

        public object_28(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Pit Bottom Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_29 : Room_Object
    {

        public object_29(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Pit Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_2A : Room_Object
    {

        public object_2A(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Pit Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_2B : Room_Object
    {

        public object_2B(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Pit Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_2C : Room_Object
    {

        public object_2C(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Pit Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_2D : Room_Object
    {

        public object_2D(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Pit Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_2E : Room_Object
    {

        public object_2E(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Pit Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_2F : Room_Object
    {

        public object_2F(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(6, pos);
            name = "Rail Wall ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 14; s++)
            {
                draw_tile(tiles[3], ((s * 1)) * 8, (0) * 8);
                draw_tile(tiles[0], ((s * 1)) * 8, (1) * 8);

            }


            draw_tile(tiles[1], (0) * 8, (0) * 8);
            draw_tile(tiles[2], (1) * 8, (0) * 8);

            draw_tile(tiles[4], (size + 12) * 8, (0) * 8);
            draw_tile(tiles[5], (size + 12 + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_30 : Room_Object
    {

        public object_30(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(6, pos);
            name = "Rail Wall ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 14; s++)
            {
                draw_tile(tiles[3], ((s * 1)) * 8, (1) * 8);
                draw_tile(tiles[0], ((s * 1)) * 8, (0) * 8);

            }


            draw_tile(tiles[1], (0) * 8, (1) * 8);
            draw_tile(tiles[2], (1) * 8, (1) * 8);

            draw_tile(tiles[4], (size + 12) * 8, (1) * 8);
            draw_tile(tiles[5], (size + 12 + 1) * 8, (1) * 8);

        }
    }

    [Serializable] public class object_31 : Room_Object
    {

        public object_31(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_32 : Room_Object
    {

        public object_32(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_33 : Room_Object
    {

        public object_33(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            name = "Carpet Floor ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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

    [Serializable] public class object_34 : Room_Object
    {

        public object_34(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Carpet Contour ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 4; s++)
            {
                draw_tile(tiles[0], ((s * 1)) * 8, (0) * 8);
            }

        }
    }

    [Serializable] public class object_35 : Room_Object
    {

        public object_35(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_36 : Room_Object
    {

        public object_36(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            name = "Curtain ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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

    [Serializable] public class object_37 : Room_Object
    {

        public object_37(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            name = "Side Curtain? ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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


    [Serializable] public class object_38 : Room_Object
    {

        public object_38(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(6, pos);
            name = "Statue ↔";
            sort = Sorting.Horizontal | Sorting.Dungeons;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 4)) * 8, (0) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 4)) * 8, (1) * 8); draw_tile(tiles[4], (1 + (s * 4)) * 8, (1) * 8);
                draw_tile(tiles[2], ((s * 4)) * 8, (2) * 8); draw_tile(tiles[5], (1 + (s * 4)) * 8, (2) * 8);
            }

        }
    }

    [Serializable] public class object_39 : Room_Object
    {

        public object_39(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Column ↔";
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 6)) * 8, (0) * 8); draw_tile(tiles[4], (1 + (s * 6)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 6)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 6)) * 8, (1) * 8);
                draw_tile(tiles[2], ((s * 6)) * 8, (2) * 8); draw_tile(tiles[6], (1 + (s * 6)) * 8, (2) * 8);
                draw_tile(tiles[3], ((s * 6)) * 8, (3) * 8); draw_tile(tiles[7], (1 + (s * 6)) * 8, (3) * 8);
            }
            sort = Sorting.Horizontal;
        }
    }


    [Serializable] public class object_3A : Room_Object
    {

        public object_3A(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(12, pos);
            name = "Top Wall Decoration ↔";
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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

    [Serializable] public class object_3B : Room_Object
    {

        public object_3B(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(12, pos);
            name = "Bottom Wall Decoration ↔";
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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

    [Serializable] public class object_3C : Room_Object
    {

        public object_3C(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Double Chair ↔";
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 4)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 4)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (1) * 8);

                draw_tile(tiles[0], ((s * 4)) * 8, (6) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (6) * 8);
                draw_tile(tiles[1], ((s * 4)) * 8, (7) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (7) * 8);
            }
            sort = Sorting.Horizontal;
        }
    }

    [Serializable] public class object_3D : Room_Object
    {

        public object_3D(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Floor Torch ↔";
            sort = Sorting.Horizontal | Sorting.Dungeons;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 6)) * 8, (0) * 8); draw_tile(tiles[4], (1 + (s * 6)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 6)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 6)) * 8, (1) * 8);
                draw_tile(tiles[2], ((s * 6)) * 8, (2) * 8); draw_tile(tiles[6], (1 + (s * 6)) * 8, (2) * 8);
                draw_tile(tiles[3], ((s * 6)) * 8, (3) * 8); draw_tile(tiles[7], (1 + (s * 6)) * 8, (3) * 8);
            }

        }
    }


    [Serializable] public class object_3E : Room_Object
    {

        public object_3E(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Top Wall Column ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 14)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 14)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 14)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 14)) * 8, (1) * 8);
            }

        }
    }





    [Serializable] public class object_3F : Room_Object
    {

        public object_3F(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Water Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_40 : Room_Object
    {

        public object_40(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Water Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_41 : Room_Object
    {

        public object_41(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Water Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_42 : Room_Object
    {

        public object_42(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Water Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_43 : Room_Object
    {

        public object_43(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Water Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_44 : Room_Object
    {

        public object_44(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Water Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }


    [Serializable] public class object_45 : Room_Object
    {

        public object_45(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Water Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }


    [Serializable] public class object_46 : Room_Object
    {

        public object_46(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Water Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 1) + 1) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_47 : Room_Object
    {

        public object_47(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused Waterfall ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            //TODO:
        }
    }

    [Serializable] public class object_48 : Room_Object
    {

        public object_48(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused Waterfall ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            //TODO:
        }
    }

    [Serializable] public class object_49 : Room_Object
    {

        public object_49(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "???";
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[4], (2 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[6], (3 + (s * 4)) * 8, (0) * 8);
                draw_tile(tiles[1], (0 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[5], (2 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[7], (3 + (s * 4)) * 8, (1) * 8);
            }
        }
    }

    [Serializable] public class object_4A : Room_Object
    {

        public object_4A(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "???";
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[4], (2 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[6], (3 + (s * 4)) * 8, (0) * 8);
                draw_tile(tiles[1], (0 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[5], (2 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[7], (3 + (s * 4)) * 8, (1) * 8);
            }
        }
    }

    [Serializable] public class object_4B : Room_Object
    {

        public object_4B(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Bottom Wall Column ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], ((s * 14)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 14)) * 8, (0) * 8);
                draw_tile(tiles[1], ((s * 14)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 14)) * 8, (1) * 8);
            }

        }
    }



    [Serializable] public class object_4C : Room_Object
    {

        public object_4C(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(9, pos);
            name = "Bar ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[3], (1 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[3], (2 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[4], (1 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[4], (2 + (s * 2)) * 8, (1) * 8);
                draw_tile(tiles[5], (1 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[5], (2 + (s * 2)) * 8, (2) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[1], (0) * 8, (1) * 8);
            draw_tile(tiles[2], (0) * 8, (2) * 8);

            draw_tile(tiles[6], ((size * 2) + 3) * 8, (0) * 8);
            draw_tile(tiles[7], ((size * 2) + 3) * 8, (1) * 8);
            draw_tile(tiles[8], ((size * 2) + 3) * 8, (2) * 8);

        }
    }

    [Serializable] public class object_4D : Room_Object
    {

        public object_4D(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            name = "Shelf ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
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

            draw_tile(tiles[12], ((size * 2) + 3) * 8, (0) * 8);
            draw_tile(tiles[13], ((size * 2) + 3) * 8, (1) * 8);
            draw_tile(tiles[14], ((size * 2) + 3) * 8, (2) * 8);
            draw_tile(tiles[15], ((size * 2) + 3) * 8, (3) * 8);
        }
    }

    [Serializable] public class object_4E : Room_Object
    {

        public object_4E(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            name = "Shelf ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
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

            draw_tile(tiles[12], ((size * 2) + 3) * 8, (0) * 8);
            draw_tile(tiles[13], ((size * 2) + 3) * 8, (1) * 8);
            draw_tile(tiles[14], ((size * 2) + 3) * 8, (2) * 8);
            draw_tile(tiles[15], ((size * 2) + 3) * 8, (3) * 8);
        }
    }

    [Serializable] public class object_4F : Room_Object
    {

        public object_4F(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            name = "Shelf ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
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

            draw_tile(tiles[12], ((size * 2) + 3) * 8, (0) * 8);
            draw_tile(tiles[13], ((size * 2) + 3) * 8, (1) * 8);
            draw_tile(tiles[14], ((size * 2) + 3) * 8, (2) * 8);
            draw_tile(tiles[15], ((size * 2) + 3) * 8, (3) * 8);
        }
    }

    [Serializable] public class object_50 : Room_Object
    {

        public object_50(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "??? ↔";
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 2; s++)
            {
                draw_tile(tiles[0], ((s * 1)) * 8, (0) * 8);

            }

        }
    }

    [Serializable] public class object_51 : Room_Object
    {

        public object_51(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(18, pos);
            name = "Canon Hole ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            //TODO : VERIFY IF THAT CODE IS RIGHT
            for (int s = 0; s < size; s++)
            {
                draw_tile(tiles[6], (2 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[9], (3 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[7], (2 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[10], (3 + (s * 2)) * 8, (1) * 8);
                draw_tile(tiles[8], (2 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[11], (3 + (s * 2)) * 8, (2) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (1) * 8, (0) * 8);
            draw_tile(tiles[1], (0) * 8, (1) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8);
            draw_tile(tiles[2], (0) * 8, (2) * 8); draw_tile(tiles[5], (1) * 8, (2) * 8);

            draw_tile(tiles[12], ((size * 2) + 2) * 8, (0) * 8); draw_tile(tiles[15], ((size * 2) + 3) * 8, (0) * 8);
            draw_tile(tiles[13], ((size * 2) + 2) * 8, (1) * 8); draw_tile(tiles[16], ((size * 2) + 3) * 8, (1) * 8);
            draw_tile(tiles[14], ((size * 2) + 2) * 8, (2) * 8); draw_tile(tiles[17], ((size * 2) + 3) * 8, (2) * 8);

        }
    }

    [Serializable] public class object_52 : Room_Object
    {

        public object_52(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(18, pos);
            name = "Canon Hole ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            //TODO : VERIFY IF THAT CODE IS RIGHT
            for (int s = 0; s < size; s++)
            {
                draw_tile(tiles[6], (2 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[9], (3 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[7], (2 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[10], (3 + (s * 2)) * 8, (1) * 8);
                draw_tile(tiles[8], (2 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[11], (3 + (s * 2)) * 8, (2) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (1) * 8, (0) * 8);
            draw_tile(tiles[1], (0) * 8, (1) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8);
            draw_tile(tiles[2], (0) * 8, (2) * 8); draw_tile(tiles[5], (1) * 8, (2) * 8);

            draw_tile(tiles[12], ((size * 2) + 2) * 8, (0) * 8); draw_tile(tiles[15], ((size * 2) + 3) * 8, (0) * 8);
            draw_tile(tiles[13], ((size * 2) + 2) * 8, (1) * 8); draw_tile(tiles[16], ((size * 2) + 3) * 8, (1) * 8);
            draw_tile(tiles[14], ((size * 2) + 2) * 8, (2) * 8); draw_tile(tiles[17], ((size * 2) + 3) * 8, (2) * 8);

        }
    }

    [Serializable] public class object_53 : Room_Object
    {

        public object_53(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "??? ↔";
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[1], (0 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 2)) * 8, (1) * 8);
            }

        }
    }

    [Serializable] public class object_54 : Room_Object
    {

        public object_54(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused ↔";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_55 : Room_Object
    {

        public object_55(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Wall Torches ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 12)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 12)) * 8, (0) * 8); draw_tile(tiles[1], (2 + (s * 12)) * 8, (0) * 8); draw_tile(tiles[3], (3 + (s * 12)) * 8, (0) * 8);
                draw_tile(tiles[4], (0 + (s * 12)) * 8, (1) * 8); draw_tile(tiles[6], (1 + (s * 12)) * 8, (1) * 8); draw_tile(tiles[5], (2 + (s * 12)) * 8, (1) * 8); draw_tile(tiles[7], (3 + (s * 12)) * 8, (1) * 8);
            }

        }
    }

    [Serializable] public class object_56 : Room_Object
    {

        public object_56(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Wall Torches ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 12)) * 8, (0) * 8); draw_tile(tiles[1], (1 + (s * 12)) * 8, (0) * 8); draw_tile(tiles[2], (2 + (s * 12)) * 8, (0) * 8); draw_tile(tiles[3], (3 + (s * 12)) * 8, (0) * 8);
                draw_tile(tiles[4], (0 + (s * 12)) * 8, (1) * 8); draw_tile(tiles[5], (1 + (s * 12)) * 8, (1) * 8); draw_tile(tiles[6], (2 + (s * 12)) * 8, (1) * 8); draw_tile(tiles[7], (3 + (s * 12)) * 8, (1) * 8);
            }

        }
    }

    [Serializable] public class object_57 : Room_Object
    {

        public object_57(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_58 : Room_Object
    {

        public object_58(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_59 : Room_Object
    {

        public object_59(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_5A : Room_Object
    {

        public object_5A(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_5B : Room_Object
    {

        public object_5B(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(18, pos);
            name = "Canon Hole ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            //TODO : VERIFY IF THAT CODE IS RIGHT
            for (int s = 0; s < size; s++)
            {
                draw_tile(tiles[6], (2 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[9], (3 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[7], (2 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[10], (3 + (s * 2)) * 8, (1) * 8);
                draw_tile(tiles[8], (2 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[11], (3 + (s * 2)) * 8, (2) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (1) * 8, (0) * 8);
            draw_tile(tiles[1], (0) * 8, (1) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8);
            draw_tile(tiles[2], (0) * 8, (2) * 8); draw_tile(tiles[5], (1) * 8, (2) * 8);

            draw_tile(tiles[12], ((size * 2) + 2) * 8, (0) * 8); draw_tile(tiles[15], ((size * 2) + 3) * 8, (0) * 8);
            draw_tile(tiles[13], ((size * 2) + 2) * 8, (1) * 8); draw_tile(tiles[16], ((size * 2) + 3) * 8, (1) * 8);
            draw_tile(tiles[14], ((size * 2) + 2) * 8, (2) * 8); draw_tile(tiles[17], ((size * 2) + 3) * 8, (2) * 8);

        }
    }

    [Serializable] public class object_5C : Room_Object
    {

        public object_5C(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(18, pos);
            name = "Canon Hole ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            //TODO : VERIFY IF THAT CODE IS RIGHT
            for (int s = 0; s < size; s++)
            {
                draw_tile(tiles[6], (2 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[9], (3 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[7], (2 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[10], (3 + (s * 2)) * 8, (1) * 8);
                draw_tile(tiles[8], (2 + (s * 2)) * 8, (2) * 8); draw_tile(tiles[11], (3 + (s * 2)) * 8, (2) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (1) * 8, (0) * 8);
            draw_tile(tiles[1], (0) * 8, (1) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8);
            draw_tile(tiles[2], (0) * 8, (2) * 8); draw_tile(tiles[5], (1) * 8, (2) * 8);

            draw_tile(tiles[12], ((size * 2) + 2) * 8, (0) * 8); draw_tile(tiles[15], ((size * 2) + 3) * 8, (0) * 8);
            draw_tile(tiles[13], ((size * 2) + 2) * 8, (1) * 8); draw_tile(tiles[16], ((size * 2) + 3) * 8, (1) * 8);
            draw_tile(tiles[14], ((size * 2) + 2) * 8, (2) * 8); draw_tile(tiles[17], ((size * 2) + 3) * 8, (2) * 8);

        }
    }


    [Serializable] public class object_5D : Room_Object
    {

        public object_5D(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(15, pos);
            name = "Large Horizontal Rail ↔";
            sort = Sorting.Horizontal | Sorting.Dungeons;
        }

        public override void Draw()
        {
            //TODO : VERIFY IF THAT CODE IS RIGHT
            for (int s = 0; s < size + 2; s++)
            {
                draw_tile(tiles[6], (2 + (s * 1)) * 8, (0) * 8);
                draw_tile(tiles[7], (2 + (s * 1)) * 8, (1) * 8);
                draw_tile(tiles[8], (2 + (s * 1)) * 8, (2) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[3], (1) * 8, (0) * 8);
            draw_tile(tiles[1], (0) * 8, (1) * 8); draw_tile(tiles[4], (1) * 8, (1) * 8);
            draw_tile(tiles[2], (0) * 8, (2) * 8); draw_tile(tiles[5], (1) * 8, (2) * 8);

            draw_tile(tiles[9], ((size * 1) + 4) * 8, (0) * 8); draw_tile(tiles[12], ((size * 1) + 5) * 8, (0) * 8);
            draw_tile(tiles[10], ((size * 1) + 4) * 8, (1) * 8); draw_tile(tiles[13], ((size * 1) + 5) * 8, (1) * 8);
            draw_tile(tiles[11], ((size * 1) + 4) * 8, (2) * 8); draw_tile(tiles[14], ((size * 1) + 5) * 8, (2) * 8);

        }
    }


    [Serializable] public class object_5E : Room_Object
    {

        public object_5E(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Block ↔";
            sort = Sorting.Horizontal | Sorting.Dungeons;
        }

        public override void Draw()
        {
            //TODO : VERIFY IF THAT CODE IS RIGHT
            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (0) * 8);
                draw_tile(tiles[1], (0 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (1) * 8);

            }
        }
    }


    [Serializable] public class object_5F : Room_Object
    {

        public object_5F(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Long Horizontal Rail ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 22; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 22) ) * 8, (0) * 8);

        }
    }
    [Serializable] public class object_60 : Room_Object
    {

        public object_60(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Ceiling ↕";
            sort = Sorting.Vertical;

        }
        
        public override void Draw()
        {
            if (this.size == 0)
            {
                this.size = 32;
            }
            for (int s = 0; s < size; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);

            }
        }
    }

    [Serializable] public class object_61 : Room_Object
    {

        public object_61(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Left Wall Vertic. ↕";
            sort = Sorting.Vertical | Sorting.Wall;

        }
        
        public override void Draw()
        {
            if (this.size == 0)
            {
                this.size = 26;
            }
            for (int s = 0; s < size; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 2)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 2)) * 8);
                draw_tile(tiles[4], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 2)) * 8);
            }

        }
    }

    [Serializable] public class object_62 : Room_Object
    {

        public object_62(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Right Wall Horiz. ↕";
            sort = Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            if (this.size == 0)
            {
                this.size = 26;
            }
            for (int s = 0; s < size; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 2)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 2)) * 8);
                draw_tile(tiles[4], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 2)) * 8);
            }
        }
    }

    [Serializable] public class object_63 : Room_Object
    {

        public object_63(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Left Wall Horiz. (Lower) ↕";
            sort = Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 2)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 2)) * 8);
                draw_tile(tiles[4], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 2)) * 8);
            }
        }
    }

    [Serializable] public class object_64 : Room_Object
    {

        public object_64(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Right Wall Horiz. (Lower) ↕";
            sort = Sorting.Vertical | Sorting.Wall;
            allBgs = true;
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 2)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 2)) * 8);
                draw_tile(tiles[4], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 2)) * 8);
            }
        }
    }


    [Serializable] public class object_65 : Room_Object
    {

        public object_65(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Left Wall Column ↕";
            sort = Sorting.Vertical;

        }

        public override void Draw()
        {
            for (int s = 0; s < size+1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 6)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 6)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 6)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 6)) * 8);
                draw_tile(tiles[4], (0) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 6)) * 8);
            }
        }
    }


    [Serializable] public class object_66 : Room_Object
    {

        public object_66(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Right Wall Column ↕";
            sort = Sorting.Vertical;

        }

        public override void Draw()
        {
            for (int s = 0; s < size+1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 6)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 6)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 6)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 6)) * 8);
                draw_tile(tiles[4], (0) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 6)) * 8);
            }
        }
    }

    [Serializable] public class object_67 : Room_Object
    {

        public object_67(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Left Wall Pit ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            for (int s = 0; s < size+1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
            }
        }
    }

    [Serializable] public class object_68 : Room_Object
    {

        public object_68(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Right Wall Pit ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            for (int s = 0; s < size+1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
            }
        }
    }


    [Serializable] public class object_69 : Room_Object
    {

        public object_69(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Vertical Rail ↕";
            sort = Sorting.Vertical | Sorting.Dungeons;
        }

        public override void Draw()
        {

                for (int s = 0; s < size + 2; s++)
            {
                draw_tile(tiles[1], (0) * 8, (1 + (s * 1)) * 8);
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], (0) * 8, ((size + 2) + 1) * 8);

        }
    }


    [Serializable] public class object_6A : Room_Object
    {

        public object_6A(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Left Pit Edge ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }

        }
    }

    [Serializable] public class object_6B : Room_Object
    {

        public object_6B(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Right Pit Edge ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }

        }
    }


    [Serializable] public class object_6C : Room_Object
    {

        public object_6C(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(6, pos);
            name = "Rail Wall Left ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 14; s++)
            {
                draw_tile(tiles[3], (0) * 8, (0 + (s * 1)) * 8);
                draw_tile(tiles[0], (0 + 1) * 8, (((s * 1)) * 8));

            }


            draw_tile(tiles[1], (0) * 8, (0) * 8);
            draw_tile(tiles[2], (0) * 8, (1) * 8);

            draw_tile(tiles[4], (0) * 8, (size + 12) * 8);
            draw_tile(tiles[5], (0) * 8, (size + 12 + 1) * 8);

        }
    }

    [Serializable] public class object_6D : Room_Object
    {

        public object_6D(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(6, pos);
            name = "Rail Wall Right ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 14; s++)
            {
                draw_tile(tiles[3], (0 + 1) * 8, (0 + (s * 1)) * 8);
                draw_tile(tiles[0], (0) * 8, (((s * 1)) * 8));

            }


            draw_tile(tiles[1], (0 + 1) * 8, (0) * 8);
            draw_tile(tiles[2], (0 + 1) * 8, (1) * 8);

            draw_tile(tiles[4], (0 + 1) * 8, (size + 12) * 8);
            draw_tile(tiles[5], (0 + 1) * 8, (size + 12 + 1) * 8);

        }
    }

    [Serializable] public class object_6E : Room_Object
    {

        public object_6E(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_6F : Room_Object
    {

        public object_6F(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_70 : Room_Object
    {

        public object_70(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            name = "Carpet Floor ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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

    [Serializable] public class object_71 : Room_Object
    {

        public object_71(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Carpet Floor Contour ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 4; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }
        }
    }


    [Serializable] public class object_72 : Room_Object
    {

        public object_72(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_73 : Room_Object
    {

        public object_73(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            name = "Left Curtain ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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

    [Serializable] public class object_74 : Room_Object
    {

        public object_74(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            name = "Right Curtain ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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


    [Serializable] public class object_75 : Room_Object
    {

        public object_75(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Column ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 6)) * 8); draw_tile(tiles[4], (1) * 8, ((s * 6)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 6)) * 8);
                draw_tile(tiles[2], (0) * 8, (2 + (s * 6)) * 8); draw_tile(tiles[6], (1) * 8, (2 + (s * 6)) * 8);
                draw_tile(tiles[3], (0) * 8, (3 + (s * 6)) * 8); draw_tile(tiles[7], (1) * 8, (3 + (s * 6)) * 8);
            }

        }
    }

    [Serializable] public class object_76 : Room_Object
    {

        public object_76(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            name = "Left Wall Decoration ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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


    [Serializable] public class object_77 : Room_Object
    {

        public object_77(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            name = "Right Wall Decoration ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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

    [Serializable] public class object_78 : Room_Object
    {

        public object_78(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Left Wall Top Column ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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

    [Serializable] public class object_79 : Room_Object
    {

        public object_79(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Water Edge ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }
        }
    }

    [Serializable] public class object_7A : Room_Object
    {

        public object_7A(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Water Edge ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }
        }
    }

    [Serializable] public class object_7B : Room_Object
    {

        public object_7B(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Right Wall Top Column ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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

    [Serializable] public class object_7C : Room_Object
    {

        public object_7C(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Water Edge ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 2; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }
        }
    }

    [Serializable] public class object_7D : Room_Object
    {

        public object_7D(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "???";
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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


    [Serializable] public class object_7E : Room_Object
    {

        public object_7E(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_7F : Room_Object
    {

        public object_7F(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Left Wall Torches ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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


    [Serializable] public class object_80 : Room_Object
    {

        public object_80(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Right Wall Torches ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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


    [Serializable] public class object_81 : Room_Object
    {

        public object_81(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(12, pos);
            name = "Left Wall Decoration ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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

    [Serializable] public class object_82 : Room_Object
    {

        public object_82(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(12, pos);
            name = "Right Wall Decoration ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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

    [Serializable] public class object_83 : Room_Object
    {

        public object_83(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(12, pos);
            name = "Left Wall Decoration?? ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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

    [Serializable] public class object_84 : Room_Object
    {

        public object_84(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(12, pos);
            name = "Right Wall Decoration?? ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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

    [Serializable] public class object_85 : Room_Object
    {

        public object_85(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(18, pos);
            name = "Left Wall Canon Hole ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            //TODO : Hard Draw Code !

        }
    }

    [Serializable] public class object_86 : Room_Object
    {

        public object_86(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(18, pos);
            name = "Right Wall Canon Hole ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            //TODO : Hard Draw Code !

        }
    }

    [Serializable] public class object_87 : Room_Object
    {

        public object_87(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Floor Torch ↕";
            sort = Sorting.Vertical |Sorting.Dungeons;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 6)) * 8); draw_tile(tiles[4], (1) * 8, ((s * 6)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 6)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 6)) * 8);
                draw_tile(tiles[2], (0) * 8, (2 + (s * 6)) * 8); draw_tile(tiles[6], (1) * 8, (2 + (s * 6)) * 8);
                draw_tile(tiles[3], (0) * 8, (3 + (s * 6)) * 8); draw_tile(tiles[7], (1) * 8, (3 + (s * 6)) * 8);
            }

        }
    }

    [Serializable] public class object_88 : Room_Object
    {

        public object_88(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(12, pos);
            name = "Large Vertical Rail ↕";
            sort = Sorting.Vertical | Sorting.Dungeons;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 2; s++)
            {
                draw_tile(tiles[4], (0) * 8, (0 + 2 + s) * 8); draw_tile(tiles[5], (1) * 8, (0 + 2 + s) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[2], (1) * 8, (0) * 8);
            draw_tile(tiles[1], (0) * 8, (0 + 1) * 8); draw_tile(tiles[3], (1) * 8, (1) * 8);

            draw_tile(tiles[6], (0) * 8, (size + 3) * 8); draw_tile(tiles[9], (1) * 8, (size + 3) * 8);
            draw_tile(tiles[7], (0) * 8, (1 + size + 3) * 8); draw_tile(tiles[10], (1) * 8, (1 + size + 3) * 8);
            draw_tile(tiles[8], (0) * 8, (2 + size + 3) * 8); draw_tile(tiles[11], (1) * 8, (2 + size + 3) * 8);
        }
    }

    [Serializable] public class object_89 : Room_Object
    {

        public object_89(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Block Vertical ↕";
            sort = Sorting.Vertical | Sorting.Dungeons;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 4)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 4)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 4)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 4)) * 8);
            }

        }
    }

    [Serializable] public class object_8A : Room_Object
    {

        public object_8A(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Long Vertical Rail ↕";
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 21; s++)
            {
                draw_tile(tiles[1], (0) * 8, (1 + (s * 1)) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], (0) * 8, ((size + 21) + 1) * 8);

        }
    }

    [Serializable] public class object_8B : Room_Object
    {

        public object_8B(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Left Vertical Jump Edge ↕";
            sort = Sorting.Vertical;

        }

        public override void Draw()
        {
            for (int s = 0; s < size + 8; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }

        }
    }

    [Serializable] public class object_8C : Room_Object
    {

        public object_8C(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "Right Vertical Jump Edge ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 8; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }

        }
    }


    [Serializable] public class object_8D : Room_Object
    {

        public object_8D(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Left Edge ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }

        }
    }

    [Serializable] public class object_8E : Room_Object
    {

        public object_8E(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Right Edge ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 1)) * 8);
            }

        }
    }

    [Serializable] public class object_8F : Room_Object
    {

        public object_8F(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(6, pos);
            name = "???";
        }
        //TODO : FIGURE OUT WHAT IS THAT OBJECT AND IF THE DRAW IS FINE
        public override void Draw()
        {
            for (int s = 0; s < size + 2; s++)
            {
                draw_tile(tiles[2], (0) * 8, (0 + 1 + (s * 2)) * 8); draw_tile(tiles[3], (0 + 1) * 8, (0 + 1 + (s * 2)) * 8);
                draw_tile(tiles[2], (0) * 8, (2 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (2 + (s * 2)) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8); draw_tile(tiles[1], (0 + 1) * 8, (0) * 8);

        }
    }



    [Serializable] public class object_90 : Room_Object
    {

        public object_90(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Left Wall Vertic. ↕";
            sort = Sorting.Vertical | Sorting.Wall;

        }

        public override void Draw()
        {
            if (this.size == 0)
            {
                this.size = 26;
            }
            for (int s = 0; s < size; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 2)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 2)) * 8);
                draw_tile(tiles[4], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 2)) * 8);
            }

        }
    }

    [Serializable] public class object_91 : Room_Object
    {

        public object_91(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Right Wall Horiz. ↕";
            sort = Sorting.Vertical | Sorting.Wall;
        }

        public override void Draw()
        {
            if (this.size == 0)
            {
                this.size = 26;
            }
            for (int s = 0; s < size; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[1], (1) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (2) * 8, ((s * 2)) * 8); draw_tile(tiles[3], (3) * 8, ((s * 2)) * 8);
                draw_tile(tiles[4], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[5], (1) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[6], (2) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[7], (3) * 8, (1 + (s * 2)) * 8);
            }
        }
    }


    [Serializable] public class object_92 : Room_Object
    {

        public object_92(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Blue Peg Block ↕";
            sort = Sorting.Vertical | Sorting.Dungeons;

        }
        
        public override void Draw()
        {
            if (size == 0)
            {
                size = 26;
            }

            for (int s = 0; s < size; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
            }

        }
    }

    [Serializable] public class object_93 : Room_Object
    {

        public object_93(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Orange Peg Block ↕";
            sort = Sorting.Vertical | Sorting.Dungeons;

        }

        public override void Draw()
        {
            if (size == 0)
            {
                size = 26;
            }
            for (int s = 0; s < size; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
            }

        }
    }


    [Serializable] public class object_94 : Room_Object
    {

        public object_94(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            name = "Invisible Floor ↕";
            sort = Sorting.Vertical | Sorting.Dungeons | Sorting.Floors;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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

    [Serializable] public class object_95 : Room_Object
    {

        public object_95(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Fake Pot ↕";
            sort = Sorting.Vertical;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
            }

        }
    }

    [Serializable] public class object_96 : Room_Object
    {

        public object_96(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Hammer Peg Block ↕";
            sort = Sorting.Vertical | Sorting.Dungeons;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0) * 8, ((s * 2)) * 8); draw_tile(tiles[2], (1) * 8, ((s * 2)) * 8);
                draw_tile(tiles[1], (0) * 8, (1 + (s * 2)) * 8); draw_tile(tiles[3], (1) * 8, (1 + (s * 2)) * 8);
            }

        }
    }

    [Serializable] public class object_97 : Room_Object
    {
        public object_97(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_98 : Room_Object
    {
        public object_98(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_99 : Room_Object
    {
        public object_99(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_9A : Room_Object
    {
        public object_9A(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_9B : Room_Object
    {
        public object_9B(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_9C : Room_Object
    {
        public object_9C(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_9D : Room_Object
    {
        public object_9D(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_9E : Room_Object
    {
        public object_9E(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_9F : Room_Object
    {
        public object_9F(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }

        public override void Draw()
        {

        }
    }

    [Serializable] public class object_A0 : Room_Object
    {
        public object_A0(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Diagonal Ceiling ◤";
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            int lenght = size + 4;
            for (int s = 0; s < size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], (0 + i) * 8, ((s)) * 8);
                }
                lenght -= 1;
            }

        }
    }


    [Serializable] public class object_A1 : Room_Object
    {
        public object_A1(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Diagonal Ceiling ◣";
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            int lenght = 1;
            for (int s = 0; s < size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], (i) * 8, ((s)) * 8);
                }
                lenght += 1;
            }

        }
    }


    [Serializable] public class object_A2 : Room_Object
    {
        public object_A2(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Diagonal Ceiling ◥";
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            int lenght = size + 4;
            for (int s = 0; s < size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], ((i) + s) * 8, ((s)) * 8);
                }
                lenght -= 1;
            }

        }
    }


    [Serializable] public class object_A3 : Room_Object
    {
        public object_A3(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Diagonal Ceiling ◢";
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {

            int lenght = size + 4;
            for (int s = 0; s < size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], ((i) + s) * 8, (0 - (s)) * 8, ((size + 4) * 8));
                }
                lenght -= 1;
            }
            drawYFix = -(size + 4);
        }
    }

    [Serializable] public class object_A4 : Room_Object
    {
        public object_A4(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(24, pos);
            name = "Hole ↔ ↕";
            sort = Sorting.Horizontal | Sorting.Vertical;
        }
        //TODO: Take the draw code from disassembly ("HARDCODED")
        public override void Draw()
        {
            draw_tile(tiles[8], (0) * 8, (0) * 8);//top left corner
            draw_tile(tiles[9], (1) * 8, (0) * 8); //vertical tile
                                                   //horizontal tile
            draw_tile(tiles[23], (size+3) * 8, (size+3) * 8);

            draw_tile(tiles[17], (0) * 8, (size+3) * 8);//bottom left corner
            


            draw_tile(tiles[14], (size+3) * 8, (0) * 8);
            
            for (int xx = 1; xx < size + 3; xx++)
            {
                for (int yy = 1; yy < size + 3; yy++)
                {
                    draw_tile(tiles[0], (xx) * 8, (yy) * 8);
                }
                draw_tile(tiles[19], (xx) * 8, (size+3) * 8);
                draw_tile(tiles[10], (xx) * 8, (0) * 8);
            }
            for (int yy = 1; yy < size + 3; yy++)
            {
                draw_tile(tiles[9], (0) * 8, (yy) * 8);
                draw_tile(tiles[15], (size+3) * 8, (yy) * 8);
            }


        }
    }

    [Serializable] public class object_A5 : Room_Object
    {
        public object_A5(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Diagonal Ceiling ◤";
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            int lenght = size + 4;
            for (int s = 0; s < size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], (i) * 8, ((s)) * 8);
                }
                lenght -= 1;
            }

        }
    }


    [Serializable] public class object_A6 : Room_Object
    {
        public object_A6(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Diagonal Ceiling ◣";
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            int lenght = 1;
            for (int s = 0; s < size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], (i) * 8, ((s)) * 8);
                }
                lenght += 1;
            }

        }
    }


    [Serializable] public class object_A7 : Room_Object
    {
        public object_A7(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Diagonal Ceiling ◥";
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            int lenght = size + 4;
            for (int s = 0; s < size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], ((i) + s) * 8, ((s)) * 8);
                }
                lenght -= 1;
            }

        }
    }


    [Serializable] public class object_A8 : Room_Object
    {
        public object_A8(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Diagonal Ceiling ◢";
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            int lenght = size + 4;
            for (int s = 0; s < size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], ((i) + s) * 8, (0 - (s)) * 8, ((size + 4) * 8));
                }
                lenght -= 1;
                drawYFix = -(size + 4);
            }

        }
    }


    [Serializable] public class object_A9 : Room_Object
    {
        public object_A9(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Diagonal Ceiling ◤";
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            int lenght = size + 4;
            for (int s = 0; s < size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], (i) * 8, ((s)) * 8);
                }
                lenght -= 1;
            }

        }
    }


    [Serializable] public class object_AA : Room_Object
    {
        public object_AA(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Diagonal Ceiling ◣";
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            int lenght = 1;
            for (int s = 0; s < size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], (i) * 8, ((s)) * 8);
                }
                lenght += 1;
            }

        }
    }


    [Serializable] public class object_AB : Room_Object
    {
        public object_AB(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Diagonal Ceiling ◥";
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            int lenght = size + 4;
            for (int s = 0; s < size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], ((i) + s) * 8, ((s)) * 8);
                }
                lenght -= 1;
            }

        }
    }


    [Serializable] public class object_AC : Room_Object
    {
        public object_AC(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Diagonal Ceiling ◢";
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            int lenght = size + 4;
            for (int s = 0; s < size + 4; s++)
            {
                for (int i = 0; i < lenght; i++)
                {
                    draw_tile(tiles[0], ((i) + s) * 8, (0 - (s)) * 8,((4+size)*8));
                }
                lenght -= 1;
            }
            drawYFix = -(size + 4);

        }
    }


    [Serializable] public class object_AD : Room_Object
    {
        public object_AD(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "???";

        }

        public override void Draw()
        {
            draw_tile(tiles[0], ((0) * 8), (0) * 8);
        }
    }
    [Serializable] public class object_AE : Room_Object
    {
        public object_AE(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "???";

        }

        public override void Draw()
        {
            draw_tile(tiles[0], ((0) * 8), (0) * 8);
        }
    }
    [Serializable] public class object_AF : Room_Object
    {
        public object_AF(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "???";

        }

        public override void Draw()
        {
            draw_tile(tiles[0], ((0) * 8), (0) * 8);
        }
    }

    [Serializable] public class object_B0 : Room_Object
    {

        public object_B0(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Bottom Horizontal Jump Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 8; s++)
            {
                draw_tile(tiles[0], ((s * 1)) * 8, (0) * 8);
            }

        }
    }

    [Serializable] public class object_B1 : Room_Object
    {

        public object_B1(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(1, pos);
            name = "Bottom Horizontal Jump Edge ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            for (int s = 0; s < size + 8; s++)
            {
                draw_tile(tiles[0], ((s * 1)) * 8, (0) * 8);
            }

        }
    }


    [Serializable] public class object_B2 : Room_Object
    {

        public object_B2(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            name = "Floor? ↔";
            sort = Sorting.Horizontal | Sorting.Floors;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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

    [Serializable] public class object_B3 : Room_Object
    {

        public object_B3(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "???";
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 2) ) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_B4 : Room_Object
    {

        public object_B4(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(3, pos);
            name = "???";
        }

        public override void Draw()
        {


            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[1], (1 + (s * 1)) * 8, (0) * 8);
            }
            draw_tile(tiles[0], (0) * 8, (0) * 8);
            draw_tile(tiles[2], ((size + 2)) * 8, (0) * 8);

        }
    }

    [Serializable] public class object_B5 : Room_Object
    {

        public object_B5(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "???";
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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

    [Serializable] public class object_B6 : Room_Object
    {

        public object_B6(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Top Wall? ↔";
            sort = Sorting.Horizontal | Sorting.Wall;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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

    [Serializable] public class object_B7 : Room_Object
    {

        public object_B7(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(8, pos);
            name = "Bottom Wall ↔";
            sort = Sorting.Horizontal | Sorting.Wall;
        }

        public override void Draw()
        {

            for (int s = 0; s < size; s++)
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


    [Serializable] public class object_B8 : Room_Object
    {

        public object_B8(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Blue Switch Block ↔";
            sort = Sorting.Horizontal | Sorting.Dungeons;
        }
        
        public override void Draw()
        {
            if (size == 0)
            {
                size =26;
            }
            for (int s = 0; s < size; s++)
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


    [Serializable] public class object_B9 : Room_Object
    {

        public object_B9(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Red Switch Block ↔";
            sort = Sorting.Horizontal | Sorting.Dungeons;
        }

        public override void Draw()
        {
            if (size == 0)
            {
                size = 26;
            }
            for (int s = 0; s < size; s++)
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

    [Serializable] public class object_BA : Room_Object
    {

        public object_BA(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(16, pos);
            name = "Invisible Floor ↔";
            sort = Sorting.Horizontal | Sorting.Floors;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
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

    [Serializable] public class object_BB : Room_Object
    {

        public object_BB(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "???";
        }

        public override void Draw()
        {
            //TODO : VERIFY IF THAT CODE IS RIGHT
            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (0) * 8);
                draw_tile(tiles[1], (0 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (1) * 8);

            }


        }
    }

    [Serializable] public class object_BC : Room_Object
    {

        public object_BC(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "fake pots ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            //TODO : VERIFY IF THAT CODE IS RIGHT
            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[1], (0 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 2)) * 8, (1) * 8);

            }


        }
    }


    [Serializable] public class object_BD : Room_Object
    {

        public object_BD(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Hammer Pegs ↔";
            sort = Sorting.Horizontal;
        }

        public override void Draw()
        {
            //TODO : VERIFY IF THAT CODE IS RIGHT
            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 2)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 2)) * 8, (0) * 8);
                draw_tile(tiles[1], (0 + (s * 2)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 2)) * 8, (1) * 8);

            }


        }
    }


    [Serializable] public class object_BE : Room_Object
    {

        public object_BE(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            name = "Unused";
        }

        public override void Draw()
        {

        }
    }


    [Serializable] public class object_BF : Room_Object
    {

        public object_BF(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            name = "Unused";
        }

        public override void Draw()
        {

        }
    }
    [Serializable] public class object_C0 : Room_Object
    {

        public object_C0(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Ceiling Large ↔ ↕";
            sort = Sorting.Horizontal | Sorting.Vertical;
            addTiles(1, pos);
        }

        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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

    [Serializable] public class object_C1 : Room_Object
    {

        public object_C1(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Chest Contour Floor ↔ ↕";
            addTiles(68, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);


            int i = 0;
            for (int xx = 0; xx < 3; xx++)
            {
                for (int yy = 0; yy < 3; yy++)
                {
                    draw_tile(tiles[i], xx * 8, yy * 8); //top left corner
                    draw_tile(tiles[i + 15], (xx + ((sizex + 4) * 2) + 3) * 8, yy * 8); //top right corner
                    draw_tile(tiles[i+40], xx * 8, (yy + ((sizey + 1) * 2) + 3) * 8);//bottom left corner
                    draw_tile(tiles[i + 55], (xx + ((sizex + 4) * 2) + 3) * 8, (yy + ((sizey + 1) * 2) + 3) * 8);//bottom left corner
                    i++;
                }
            }

            for (int sx = 0; sx < sizex + 4; sx++)
            {
                for (int sy = 0; sy < sizey + 1; sy++)
                {
                    draw_tile(tiles[30], (3 + (sx * 2)) * 8, (3 + (sy * 2)) * 8); draw_tile(tiles[31], (4 + (sx * 2)) * 8, (3 + (sy * 2)) *8);
                    draw_tile(tiles[32], (3 + (sx * 2)) * 8, (4 + (sy * 2)) * 8); draw_tile(tiles[33], (4 + (sx * 2)) * 8, (4 + (sy * 2)) *8);
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
            //30,31
            //32,33 //middle


            for (int sy = 0; sy < sizey +1; sy++)
            {
                draw_tile(tiles[24], (0) * 8, (3+sy*2) * 8); draw_tile(tiles[25], (1) * 8, (3 + sy * 2) * 8); draw_tile(tiles[26], (2) * 8, (3 + sy * 2) * 8);
                draw_tile(tiles[27], (0) * 8, (4 + sy * 2) * 8); draw_tile(tiles[28], (1) * 8, (4 + sy * 2) * 8); draw_tile(tiles[29], (2) * 8, (4 + sy * 2) * 8);

                draw_tile(tiles[34], (((sizex + 4) * 2) + 3) * 8, (3 + sy * 2) * 8); draw_tile(tiles[35], (((sizex + 4) * 2) + 4) * 8, (3 + sy * 2) * 8); draw_tile(tiles[36], (((sizex + 4) * 2) + 5) * 8, (3 + sy * 2) * 8);
                draw_tile(tiles[37], (((sizex + 4) * 2) + 3) * 8, (4 + sy * 2) * 8); draw_tile(tiles[38], (((sizex + 4) * 2) + 4) * 8, (4 + sy * 2) * 8); draw_tile(tiles[39], (((sizex + 4) * 2) + 5) * 8, (4 + sy * 2) * 8);
            }
        }
    }

    [Serializable] public class object_C2 : Room_Object
    {

        public object_C2(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Bg2 Large Overlay ↔ ↕";
            addTiles(1, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical;

        }

        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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

    [Serializable] public class object_C3 : Room_Object
    {

        public object_C3(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Bg2 Medium Overlay ↔ ↕";
            addTiles(1, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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

    [Serializable] public class object_C4 : Room_Object
    {

        public object_C4(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
            name = "Floor1 ↔ ↕";
        }



        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

            byte f = (byte)(room.floor1 << 4); //how can it be null oO ?
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

    [Serializable] public class object_C5 : Room_Object
    {

        public object_C5(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Floor3 ↔ ↕";
            addTiles(8, pos);//??
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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

    [Serializable] public class object_C6 : Room_Object
    {

        public object_C6(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Bg2 Large Overlay ↔ ↕";
            addTiles(8, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical;
        }

        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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


    [Serializable] public class object_C7 : Room_Object
    {

        public object_C7(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Floor4 ↔ ↕";
            addTiles(8, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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

    [Serializable] public class object_C8 : Room_Object
    {

        public object_C8(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Water Floor ↔ ↕";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
            addTiles(8, pos);//??
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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



    [Serializable] public class object_C9 : Room_Object
    {

        public object_C9(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Water Floor2 ↔ ↕";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
            addTiles(8, pos);//??
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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


    [Serializable] public class object_CA : Room_Object
    {

        public object_CA(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Floor5 ↔ ↕";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
            addTiles(8, pos);//??
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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

    [Serializable] public class object_CB : Room_Object
    {

        public object_CB(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {


            name = "Unused";

        }


        public override void Draw()
        {

        }
    }

    [Serializable] public class object_CC : Room_Object
    {

        public object_CC(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {


            name = "Unused";

        }


        public override void Draw()
        {

        }
    }

    [Serializable] public class object_CD : Room_Object
    {

        public object_CD(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Moving Wall Left ↔ ↕";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            addTiles(8, pos);//??
        }


        public override void Draw()
        {
            //TODO : Check Disassembly
        }
    }

    [Serializable] public class object_CE : Room_Object
    {

        public object_CE(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Moving Wall Left ↔ ↕";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Wall;
            addTiles(8, pos);//??
        }


        public override void Draw()
        {
            //TODO : Check Disassembly
        }
    }

    [Serializable] public class object_CF : Room_Object
    {

        public object_CF(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {


            name = "Unused";

        }


        public override void Draw()
        {

        }
    }

    [Serializable] public class object_D0 : Room_Object
    {

        public object_D0(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {


            name = "Unused";

        }


        public override void Draw()
        {

        }
    }

    [Serializable] public class object_D1 : Room_Object
    {

        public object_D1(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Water Floor3 ↔ ↕";
            addTiles(8, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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


    [Serializable] public class object_D2 : Room_Object
    {

        public object_D2(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Floor6 ↔ ↕";
            addTiles(8, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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

    [Serializable] public class object_D3 : Room_Object
    {

        public object_D3(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {


            name = "Unused";

        }


        public override void Draw()
        {

        }
    }

    [Serializable] public class object_D4 : Room_Object
    {

        public object_D4(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {


            name = "Unused";

        }


        public override void Draw()
        {

        }
    }

    [Serializable] public class object_D5 : Room_Object
    {

        public object_D5(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {


            name = "Unused";

        }


        public override void Draw()
        {

        }
    }

    [Serializable] public class object_D6 : Room_Object
    {

        public object_D6(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {


            name = "???";

        }


        public override void Draw()
        {

        }
    }

    [Serializable] public class object_D7 : Room_Object
    {

        public object_D7(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "overlay tile? ↔ ↕";
            addTiles(1, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical;
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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


    [Serializable] public class object_D8 : Room_Object
    {

        public object_D8(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Lava Background? ↔ ↕";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
            addTiles(8, pos);//??
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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

    [Serializable] public class object_D9 : Room_Object
    {

        public object_D9(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Hole?? ↔ ↕";
            addTiles(8, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical;
        }


        public override void Draw()
        {
            /*int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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
            }*/
        }
    }

    [Serializable] public class object_DA : Room_Object
    {

        public object_DA(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Lava Background 2 ↔ ↕";
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
            addTiles(8, pos);//??
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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

    [Serializable] public class object_DB : Room_Object
    {

        public object_DB(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
            name = "Floor2 ↔ ↕";
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

            byte f = (byte)(room.floor2 << 4);
            int pos = Constants.tile_address + f;
            tiles.Clear();
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

    [Serializable] public class object_DC : Room_Object
    {

        public object_DC(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Chest Platform? ↔ ↕";
            addTiles(21, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical;
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

            draw_tile(tiles[18], (9 + (sizex * 2)) * 8, 0); //top left rail border with size
            draw_tile(tiles[0], 0, 0); //top left rail border
            draw_tile(tiles[1], 0, (5 + (sizey * 2)) * 8); //bottom left rail border //Not sure why that tile exist but meh
            draw_tile(tiles[2], 0, (6 + (sizey * 2)) * 8); //bottom left rail corner

            draw_tile(tiles[19], (9 + (sizex * 2)) * 8, (5 + (sizey * 2)) * 8); //bottom right rail border //Not sure why that tile exist but meh
            draw_tile(tiles[20], (9 + (sizex * 2)) * 8, (6 + (sizey * 2)) * 8); //bottom right rail corner

            for (int yy = 0; yy < sizey + 2; yy++) //set size on 4 already
            {
                draw_tile(tiles[0], 0, (1 + (yy * 2)) * 8); //top left rail border with size
                draw_tile(tiles[0], 0, (2 + (yy * 2)) * 8); //top left rail border with size
                for (int xx = 0; xx < sizex + 1; xx++)
                {
                    draw_tile(tiles[3], ((xx + 1) * 8), (0 + (yy * 2)) * 8); //left side chunk
                    draw_tile(tiles[3], ((xx + 1) * 8), (1 + (yy * 2)) * 8); //left side chunk

                    draw_tile(tiles[15], ((xx + 8 + sizex) * 8), (0 + (yy * 2)) * 8); //right side chunk
                    draw_tile(tiles[15], ((xx + 8 + sizex) * 8), (1 + (yy * 2)) * 8); //right side chunk
                }
                draw_tile(tiles[6], (2 + sizex) * 8, (0 + (yy * 2)) * 8); //left side extra line
                draw_tile(tiles[6], (2 + sizex) * 8, (1 + (yy * 2)) * 8); //left side extra line

                draw_tile(tiles[12], (7 + sizex) * 8, (0 + (yy * 2)) * 8);//right side extra line
                draw_tile(tiles[12], (7 + sizex) * 8, (1 + (yy * 2)) * 8);//right side extra line

                draw_tile(tiles[9], (3 + sizex) * 8, (1 + (yy * 2)) * 8); //middle
                draw_tile(tiles[9], (4 + sizex) * 8, (1 + (yy * 2)) * 8); //middle
                draw_tile(tiles[9], (5 + sizex) * 8, (1 + (yy * 2)) * 8); //middle
                draw_tile(tiles[9], (6 + sizex) * 8, (1 + (yy * 2)) * 8); //middle
                draw_tile(tiles[9], (3 + sizex) * 8, (2 + (yy * 2)) * 8); //middle
                draw_tile(tiles[9], (4 + sizex) * 8, (2 + (yy * 2)) * 8); //middle
                draw_tile(tiles[9], (5 + sizex) * 8, (2 + (yy * 2)) * 8); //middle
                draw_tile(tiles[9], (6 + sizex) * 8, (2 + (yy * 2)) * 8); //middle

                draw_tile(tiles[18], (9 + (sizex * 2)) * 8, (1 + (yy * 2)) * 8); //top left rail border with size
                draw_tile(tiles[18], (9 + (sizex * 2)) * 8, (2 + (yy * 2)) * 8); //top left rail border with size
                                                                                 // draw_tile(tiles[15], ((xx + 8 + sizex) * 8), (4 + (sizey * 2)) * 8); //last line of carpet right side chunk
            }

            draw_tile(tiles[9], (3 + sizex) * 8, (0) * 8); //middle
            draw_tile(tiles[9], (4 + sizex) * 8, (0) * 8); //middle
            draw_tile(tiles[9], (5 + sizex) * 8, (0) * 8); //middle
            draw_tile(tiles[9], (6 + sizex) * 8, (0) * 8); //middle


            draw_tile(tiles[10], (3 + sizex) * 8, (5 + (sizey * 2)) * 8); //stairs1
            draw_tile(tiles[10], (4 + sizex) * 8, (5 + (sizey * 2)) * 8); //stairs1
            draw_tile(tiles[10], (5 + sizex) * 8, (5 + (sizey * 2)) * 8); //stairs1
            draw_tile(tiles[10], (6 + sizex) * 8, (5 + (sizey * 2)) * 8); //stairs1

            draw_tile(tiles[11], (3 + sizex) * 8, (6 + (sizey * 2)) * 8); //stairs2
            draw_tile(tiles[11], (4 + sizex) * 8, (6 + (sizey * 2)) * 8); //stairs2
            draw_tile(tiles[11], (5 + sizex) * 8, (6 + (sizey * 2)) * 8); //stairs2
            draw_tile(tiles[11], (6 + sizex) * 8, (6 + (sizey * 2)) * 8); //stairs2

            draw_tile(tiles[7], (2 + sizex) * 8, (5 + (sizey * 2)) * 8);
            draw_tile(tiles[6], (2 + sizex) * 8, (4 + (sizey * 2)) * 8);
            draw_tile(tiles[12], (7 + sizex) * 8, (4 + (sizey * 2)) * 8);
            draw_tile(tiles[13], (7 + sizex) * 8, (5 + (sizey * 2)) * 8);
            draw_tile(tiles[14], (7 + sizex) * 8, (6 + (sizey * 2)) * 8);
            draw_tile(tiles[8], (2 + sizex) * 8, (6 + (sizey * 2)) * 8);
            //draw_tile(tiles[6], (2 + sizex) * 8, (5 + (sizey * 2)) * 8);//last new line of carpet left side
            //draw_tile(tiles[6], (1 * 8), (5 + (sizey * 2)) * 8);//last new line of carpet left side
            for (int xx = 0; xx < sizex + 1; xx++)
            {
                draw_tile(tiles[3], ((1 + xx) * 8), (4 + (sizey * 2)) * 8);//last line of carpet left side
                draw_tile(tiles[15], ((xx + 8 + sizex) * 8), (4 + (sizey * 2)) * 8); //last line of carpet right side chunk
                draw_tile(tiles[4], ((1 + xx) * 8), (5 + (sizey * 2)) * 8);//last new line of carpet left side
                draw_tile(tiles[5], (1 + (xx)) * 8, (6 + (sizey * 2)) * 8);//last line bottom left rail

                draw_tile(tiles[16], (8 + sizex + xx) * 8, (5 + (sizey * 2)) * 8);//last new line of carpet left side
                draw_tile(tiles[17], (8 + sizex + xx) * 8, (6 + (sizey * 2)) * 8);//last line bottom left rail

            }


        }



    }

    [Serializable] public class object_DD : Room_Object
    {

        public object_DD(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Table / Rock ↔ ↕";
            sort = Sorting.Horizontal | Sorting.Vertical;
            addTiles(16, pos);

        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[5], (1 + (xx * 2)) * 8, (1 + (yy * 2)) * 8); //middle top
                    draw_tile(tiles[6], (2 + (xx * 2)) * 8, (1 + (yy * 2)) * 8); //middle top

                    draw_tile(tiles[9], (1 + (xx * 2)) * 8, (2 + (yy * 2)) * 8); //middle bottom
                    draw_tile(tiles[10], (2 + (xx * 2)) * 8, (2 + (yy * 2)) * 8); //middle bottom
                }
            }

            for (int yy = 0; yy < sizey + 1; yy++)
            {
                draw_tile(tiles[4], (0) * 8, (1 + (yy * 2)) * 8); //left border
                draw_tile(tiles[8], (0) * 8, (2 + (yy * 2)) * 8); //left border

                draw_tile(tiles[7], (3 + (sizex * 2)) * 8, (1 + (yy * 2)) * 8); //right border
                draw_tile(tiles[11], (3 + (sizex * 2)) * 8, (2 + (yy * 2)) * 8); //right border
            }

            draw_tile(tiles[0], (0) * 8, (0) * 8); //top left corner
            draw_tile(tiles[12], (0) * 8, (3 + (sizey * 2)) * 8); //bottom left corner
            for (int xx = 0; xx < sizex + 1; xx++)
            {
                draw_tile(tiles[1], (1 + (xx * 2)) * 8, (0) * 8); //top border
                draw_tile(tiles[2], (2 + (xx * 2)) * 8, (0) * 8); //top border

                draw_tile(tiles[13], (1 + (xx * 2)) * 8, (3 + (sizey * 2)) * 8); //bottom border
                draw_tile(tiles[14], (2 + (xx * 2)) * 8, (3 + (sizey * 2)) * 8); //bottom border
            }
            draw_tile(tiles[3], (3 + (sizex * 2)) * 8, (0) * 8); //top right corner
            draw_tile(tiles[15], (3 + (sizex * 2)) * 8, (3 + (sizey * 2)) * 8); //bottom right corner
            

            

        }
    }

    [Serializable] public class object_DE : Room_Object
    {

        public object_DE(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Spike Block ↔ ↕";
            addTiles(4, pos);
            sort = Sorting.Horizontal | Sorting.Vertical;
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

            for (int xx = 0; xx < sizex + 1; xx++)
            {
                for (int yy = 0; yy < sizey + 1; yy++)
                {
                    draw_tile(tiles[0], (0 + (xx * 2)) * 8, (0 + (yy * 2)) * 8); //middle top
                    draw_tile(tiles[2], (1 + (xx * 2)) * 8, (0 + (yy * 2)) * 8); //middle top

                    draw_tile(tiles[1], (0 + (xx * 2)) * 8, (1 + (yy * 2)) * 8); //middle bottom
                    draw_tile(tiles[3], (1 + (xx * 2)) * 8, (1 + (yy * 2)) * 8); //middle bottom
                }
            }
        }
    }


    [Serializable] public class object_DF : Room_Object
    {

        public object_DF(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Spike Floor ↔ ↕";
            addTiles(8, pos);
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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


    [Serializable] public class object_E0 : Room_Object
    {

        public object_E0(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Floor7 ↔ ↕";
            addTiles(8, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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

    [Serializable] public class object_E1 : Room_Object
    {

        public object_E1(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Floor9 ↔ ↕";
            addTiles(8, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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

    [Serializable] public class object_E2 : Room_Object
    {

        public object_E2(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Rupee Floor ↔ ↕";
            addTiles(8, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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

    [Serializable] public class object_E3 : Room_Object
    {

        public object_E3(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Moving Floor Up ↔ ↕";
            addTiles(8, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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

    [Serializable] public class object_E4 : Room_Object
    {

        public object_E4(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Moving Floor Down ↔ ↕";
            addTiles(8, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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

    [Serializable] public class object_E5 : Room_Object
    {

        public object_E5(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Moving Floor Left ↔ ↕";
            addTiles(8, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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

    [Serializable] public class object_E6 : Room_Object
    {

        public object_E6(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Moveing Floor Right ↔ ↕";
            addTiles(8, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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


    [Serializable] public class object_E7 : Room_Object
    {

        public object_E7(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Moving Floor? ↔ ↕";
            addTiles(8, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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

    [Serializable] public class object_E8 : Room_Object
    {

        public object_E8(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {

            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((id & 0xFF) * 2)]);
            name = "Weird Floor? ↔ ↕";
            addTiles(8, pos);//??
            sort = Sorting.Horizontal | Sorting.Vertical | Sorting.Floors;
        }


        public override void Draw()
        {
            int sizex = ((size >> 2) & 0x03);
            int sizey = ((size) & 0x03);

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

    [Serializable] public class object_E9 : Room_Object
    {
        public object_E9(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }
    }
    [Serializable] public class object_EA : Room_Object
    {
        public object_EA(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }
    }
    [Serializable] public class object_EB : Room_Object
    {
        public object_EB(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }
    }
    [Serializable] public class object_EC : Room_Object
    {
        public object_EC(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }
    }
    [Serializable] public class object_ED : Room_Object
    {
        public object_ED(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }
    }
    [Serializable] public class object_EE : Room_Object
    {
        public object_EE(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }
    }
    [Serializable] public class object_EF : Room_Object
    {
        public object_EF(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }
    }
    [Serializable] public class object_F0 : Room_Object
    {
        public object_F0(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }
    }
    [Serializable] public class object_F1 : Room_Object
    {
        public object_F1(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }
    }
    [Serializable] public class object_F2 : Room_Object
    {
        public object_F2(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }
    }
    [Serializable] public class object_F3 : Room_Object
    {
        public object_F3(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }
    }
    [Serializable] public class object_F4 : Room_Object
    {
        public object_F4(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }
    }
    [Serializable] public class object_F5 : Room_Object
    {
        public object_F5(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }
    }
    [Serializable] public class object_F6 : Room_Object
    {
        public object_F6(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }
    }
    [Serializable] public class object_F7 : Room_Object
    {
        public object_F7(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            name = "Unused";
        }
    }

    [Serializable]
    public class object_Block : Room_Object
    {

        public object_Block(short id, byte x, byte y, byte size, byte layer) : base(id, x, y, size, layer)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype1_tiles + ((0x5E & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype1_tiles + ((0x5E & 0xFF) * 2)]);
            addTiles(4, pos);
            name = "Pushable Block";//ID E00
            options = ObjectOption.Block;
        }

        public override void Draw()
        {

            for (int s = 0; s < size + 1; s++)
            {
                draw_tile(tiles[0], (0 + (s * 4)) * 8, (0) * 8); draw_tile(tiles[2], (1 + (s * 4)) * 8, (0) * 8);
                draw_tile(tiles[1], (0 + (s * 4)) * 8, (1) * 8); draw_tile(tiles[3], (1 + (s * 4)) * 8, (1) * 8);

            }
        }
    }
}
