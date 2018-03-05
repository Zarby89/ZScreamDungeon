using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    [Serializable]
    public class Subtype2_Multiple : Room_Object
    {
        public int tx = 0;
        public int ty = 0;

        public Subtype2_Multiple(short id, byte x, byte y, byte size,byte layer) : base(id, x, y, size,layer)
        {
            byte oid = (byte)(id & 0xFF);
            if (oid == 0)
            {
                setdata("Wall Inner Corner ▛", 4, 4);
                sort = Sorting.Wall | Sorting.NonScalable;
            }
            if (oid == 1)
            {
                setdata("Wall Inner Corner ▙", 4, 4);
                sort = Sorting.Wall | Sorting.NonScalable;
            }
            if (oid == 2)
            {
                setdata("Wall Inner Corner ▜", 4, 4);
                sort = Sorting.Wall | Sorting.NonScalable;
            }
            if (oid == 3)
            {
                setdata("Wall Inner Corner ▟", 4, 4);
                sort = Sorting.Wall | Sorting.NonScalable;
            }
            if (oid == 4)
            {
                setdata("Wall Outer Corner ▟", 4, 4);
                sort = Sorting.Wall | Sorting.NonScalable;
            }
            if (oid == 5)
            {
                setdata("Wall Outer Corner ▜", 4, 4);
                sort = Sorting.Wall | Sorting.NonScalable;
            }
            if (oid == 6)
            {
                setdata("Wall Outer Corner ▙", 4, 4);
                sort = Sorting.Wall | Sorting.NonScalable;
            }
            if (oid == 7)
            {
                setdata("Wall Outer Corner ▛", 4, 4);
                sort = Sorting.Wall | Sorting.NonScalable;
            }
            if (oid >= 8 && oid <= 15)
            {
                setdata("Wall Corner (Lower)", 4, 4, true); // Corners
                sort = Sorting.Wall | Sorting.NonScalable; ;
            }
            if (oid >= 16 && oid <= 19)
            {
                setdata("Wall S (Lower)",3, 4, true); // Corners
                sort = Sorting.Wall | Sorting.NonScalable; ;
            }
            if (oid >= 20 && oid <= 23)
            {
                setdata("Wall S (Lower)", 4, 3, true); // Corners
                sort = Sorting.Wall | Sorting.NonScalable; ;
            }
            if (oid >= 24 && oid <= 27)
            {
                setdata("Pit Edge Corner", 2, 2); // Pit Edge
                sort = Sorting.Wall | Sorting.NonScalable; ;
            }
            if (oid == 0x1C)
            {
                setdata("Fairy Pot", 4, 4);
                sort = Sorting.Dungeons | Sorting.NonScalable; ;
            }
            else if (oid == 0x1D)
            {
                setdata("Statue", 2, 3);
                sort = Sorting.Dungeons | Sorting.NonScalable; ;
            }
            else if (oid == 0x1E)
            {
                setdata("Star Tile Off", 2, 2);
                sort = Sorting.Dungeons | Sorting.NonScalable; ;
            }
            else if (oid == 0x1F)
            {
                setdata("Star Tile On", 2, 2);
                sort = Sorting.Dungeons | Sorting.NonScalable; ;
            }
            else if (oid == 0x20)
            {
                setdata("Torch Lit", 2, 2);
                sort = Sorting.Dungeons | Sorting.NonScalable;
            }
            else if (oid == 0x21)
            {
                setdata("Barrel", 2, 3);
                sort = Sorting.NonScalable;
            }
            else if (oid == 0x22)
            {
                setdata("Weird Bed", 4, 5);
                sort = Sorting.NonScalable;
            }
            else if (oid == 0x23)
            {
                setdata("Table", 4, 3);
                sort = Sorting.NonScalable;
            }
            else if (oid == 0x24)
            {
                setdata("Decoration", 4, 4);
                sort = Sorting.NonScalable;
            }
            else if (oid == 0x25)
            {
                setdata("???", 4, 4);
                sort = Sorting.NonScalable;
            }
            else if (oid == 0x26)
            {
                setdata("???", 2, 3);
                sort = Sorting.NonScalable;
            }
            else if (oid == 0x27)
            {
                setdata("Chair", 2, 2);
                sort = Sorting.NonScalable;
            }
            else if (oid == 0x28)
            {
                setdata("Bed", 4, 5);
                sort = Sorting.NonScalable;
            }
            else if (oid == 0x29)
            {
                setdata("Decoration", 4, 4);
                sort = Sorting.NonScalable;
            }
            else if (oid == 0x2A)
            {
                setdata("Wall Painting",  4, 2);
                sort = Sorting.NonScalable;
            }
            else if (oid == 0x2B)
            {
                setdata("???", 2, 2);
                sort = Sorting.NonScalable;
            }
            else if (oid == 0x2C)
            {
                setdata("???",  2, 2);
                sort = Sorting.NonScalable;
            }
            else if (oid == 0x2D)
            {
                setdata("Stairs Going Up (room)", 4, 4);
                sort = Sorting.Stairs | Sorting.NonScalable;
            }
            else if (oid == 0x2E)
            {
                setdata("Stairs Going Down (room)", 4, 4);
                sort = Sorting.Stairs | Sorting.NonScalable;
            }
            else if (oid == 0x2F)
            {
                setdata("Stairs Going Down2 (room)", 4, 4);
                sort = Sorting.Stairs | Sorting.NonScalable;
            }
            else if (oid == 0x30)
            {
                setdata("Stairs Going Up (layer)", 4, 4, true);
                sort = Sorting.Stairs | Sorting.NonScalable;
            }
            else if (oid == 0x31)
            {
                setdata("Stairs Going Up2 (layer)", 4, 4, true);
                sort = Sorting.Stairs | Sorting.NonScalable;
            }
            else if (oid == 0x32)
            {
                setdata("Stairs Going Up (layer)",  4, 4);
                sort = Sorting.Stairs | Sorting.NonScalable;
            }
            else if (oid == 0x33)
            {
                setdata("Stairs Going Up (layer)", 4, 4);
                sort = Sorting.Stairs | Sorting.NonScalable;
            }
            else if (oid == 0x34)
            {
                setdata("Block", 2, 2);
                sort = Sorting.NonScalable;
            }
            else if (oid == 0x35)
            {
                setdata("Water Stair",  4, 2);
                sort = Sorting.Stairs | Sorting.NonScalable;
            }
            else if (oid == 0x36)
            {
                setdata("Water Stair2", 4, 2, true);
                sort = Sorting.Stairs | Sorting.NonScalable;
            }
            else if (oid == 0x37)
            {
                setdata("Water Gate",  10, 4);
                sort = Sorting.NonScalable;
            }
            else if (oid == 0x38)
            {
                setdata("Spiral Staircase Up",  4, 3);
                sort = Sorting.Stairs | Sorting.NonScalable;
            }
            else if (oid == 0x39)
            {
                setdata("Spiral Staircase Down", 4, 3);
                sort = Sorting.Stairs | Sorting.NonScalable;
            }
            else if (oid == 0x3A)
            {
                setdata("Spiral Staircase Up (Lower)", 4, 3);
                sort = Sorting.Stairs | Sorting.NonScalable;
            }
            else if (oid == 0x3B)
            {
                setdata("Spiral Staircase Down (Lower)", 4, 3);
                sort = Sorting.Stairs | Sorting.NonScalable;
            }
            else if (oid == 0x3C)
            {
                setdata("Sanctuary Wall", 4, 4);
                sort = Sorting.NonScalable;
            }
            else if (oid == 0x3D)
            {
                setdata("???", 4, 3);
                sort = Sorting.NonScalable;
            }
            else if (oid == 0x3E)
            {
                setdata("???",  6, 3);
                sort = Sorting.NonScalable;
            }
            else if (oid == 0x3F)
            {
                setdata("???", 8, 7);
                sort = Sorting.NonScalable;
            }
            else if (oid == 0x50) //special object id doesnt matter (Torches)
            {
                //setdata("Torch", 2, 2);
                tiles.Add(new Tile(480, false, false, 0, 3));
                tiles.Add(new Tile(496, false, false, 0, 3));
                tiles.Add(new Tile(480, true, false, 0, 3));
                tiles.Add(new Tile(496, true, false, 0, 3));
                options |= ObjectOption.Torch;
                this.name = "Torch";
                tx = 2;
                ty = 2;
            }
        }


        public override void Draw()
        {
            byte oid = (byte)(id & 0xFF);
            if (oid == 0x28 || oid == 0x35 || oid == 0x36 || oid == 0x2A)
            {
                //bed ? WTF WHY THIS IS REVERSED...
                int tid = 0;
                for (int yy = 0; yy < ty; yy++)
                {
                    for (int xx = 0; xx < tx; xx++)
                {

                        draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                        tid++;
                    }
                }
            }
            else
            {
                int tid = 0;
                for (int xx = 0; xx < tx; xx++)
                {
                    for (int yy = 0; yy < ty; yy++)
                    {
                        draw_tile(tiles[tid], (xx) * 8, (yy) * 8);
                        tid++;
                    }
                }
            }
        }

        public void setdata(string name, int tx, int ty, bool allbg = false)
        {
            int pos = Constants.tile_address + (short)((ROM.DATA[Constants.subtype2_tiles + ((id & 0xFF) * 2) + 1] << 8) + ROM.DATA[Constants.subtype2_tiles + ((id & 0xFF) * 2)]);
            addTiles(tx*ty, pos);
            this.name = name;
            this.tx = tx;
            this.ty = ty;
            this.allBgs = allbg;
        }
    }
}
