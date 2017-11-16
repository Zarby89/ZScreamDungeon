using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ZeldaFullEditor
{
    public class Room_Object
    {
        public byte x, y; //position of the object in the room (*8 for draw)
        public byte size; //size of the object
        public bool allBgs = false; //if the object is drawn on BG1 and BG2 regardless of type of BG
        public List<Tile> tiles = new List<Tile>();
        public short id; 
        public string name; //name of the object will be shown on the form
        public byte layer = 0;
        public Bitmap bitmap;
        public Room room;
        public int drawYFix = 0;
        public Room_Object(short id,byte x,byte y,byte size,byte layer = 0)
        {
            this.x = x;
            this.y = y;
            this.size = size;
            this.id = id;
            this.layer = layer;
            
            //GFX.tilebufferbitmap.MakeTransparent(Color.Black);
        }

        public void setRoom(Room r)
        {
            this.room = r;
        }

        public virtual void Draw()
        {
             
        }

        public void DrawOnBitmap()
        {
            if (image_size_x == 0 && image_size_y == 0)
            {
                bitmap = new Bitmap((8), (8));
            }
            else
            {
                bitmap = new Bitmap(((image_size_x)), ((image_size_y)));
            }

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(GFX.tilebufferbitmap, new Rectangle(0, 0, image_size_x, image_size_y), 0, 0, image_size_x, image_size_y, GraphicsUnit.Pixel);


            }
        }



        public void addTiles(int nbr,int pos)
        {
            for(int i = 0;i<nbr;i++)
            {
                tiles.Add(new Tile(ROM.DATA[pos + ((i * 2))], ROM.DATA[pos + ((i * 2)) +1]));
            }
        }

        public void draw_diagonal_up()
        {
            for (int s = 0; s < size + 6; s++)
            {
                draw_tile(tiles[0], ( (s)) * 8, (0 - s) * 8,((size+6)*8));
                draw_tile(tiles[1], ( (s)) * 8, (1 - s) * 8, ((size + 6) * 8));
                draw_tile(tiles[2], ( (s)) * 8, (2 - s) * 8, ((size + 6) * 8));
                draw_tile(tiles[3], ( (s)) * 8, (3 - s) * 8, ((size + 6) * 8));
                draw_tile(tiles[4], ( (s)) * 8, (4 - s) * 8, ((size + 6) * 8));
                drawYFix = -(size+6);
            }
        }

        public void draw_diagonal_down()
        {
            for (int s = 0; s < size + 6; s++)
            {
                draw_tile(tiles[0], ( (s)) * 8, (0 + s) * 8);
                draw_tile(tiles[1], ( (s)) * 8, (1 + s) * 8);
                draw_tile(tiles[2], ( (s)) * 8, (2 + s) * 8);
                draw_tile(tiles[3], ( (s)) * 8, (3 + s) * 8);
                draw_tile(tiles[4], ( (s)) * 8, (4 + s) * 8);
            }
        }
        //Object Initialization (Tiles and special stuff)
        public void init_objects()
        {

            //START OF THE VERTICAL OBJECTS
            /*else if (oid == 0x60)//0 - 15 (size+15, column1+column2 column2 column2+colum3)
            {
                tsizeX = 3;
                tsizeY = 1;
                name = "Long Horiz. Rail";
            }*/

        }

        //tile order is 1 4 7
        //              2 5 8
        //              3 6 9
        //Objects Draw

        int image_size_x = 0;
        int image_size_y = 0;


        public void draw_tile(Tile t, int x, int y, int yfix = 0)
        {
            y = y + yfix;

            if ((x + 8) >= image_size_x)
            {
                image_size_x = (x+8);
            }
            if ((y + 8) >= image_size_y)
            {
                image_size_y = (y+8);
            }

            using (Bitmap b = new Bitmap(8, 8))
            {
                int ty = (t.id / 16);
                int tx = t.id - (ty * 16);
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.DrawImage(GFX.blocksets[t.palette], new Rectangle(0, 0, 8, 8), tx * 8, ty * 8, 8, 8, GraphicsUnit.Pixel);
                }


                if (t.mirror_x) //mirror x
                    b.RotateFlip(RotateFlipType.RotateNoneFlipX);
                if (t.mirror_y) //mirror y
                    b.RotateFlip(RotateFlipType.RotateNoneFlipY);

                GFX.graphictilebuffer.DrawImage(b, x, y);
            }
        }

        public void makeTileTransparent(Bitmap b)
        {

        }



    }



}

