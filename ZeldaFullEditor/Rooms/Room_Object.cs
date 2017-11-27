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
            /*if (image_size_x == 0 && image_size_y == 0)
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


            }*/
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


        int ty = (t.id / 16);
        int tx = t.id - (ty * 16);
        int mx = 0;
        int my = 0;


        if (t.mirror_x == true)
        {
            mx = 8;
        }

        for (int xx = 0; xx < 8; xx++)
        {
            if (mx > 0)
            {
                mx--;
            }
            if (t.mirror_y == true)
            {
                my = 8;
            }
            for (int yy = 0; yy < 8; yy++)
            {
                if (my > 0)
                {
                    my--;
                }
                int x_dest = ((this.x * 8) + x + (xx)) * 4;
                int y_dest = (((this.y * 8) + y + (yy)) * 512) * 4;
                int dest = x_dest + y_dest;

                int x_src = ((tx * 8) + mx + (xx));
                if (t.mirror_x)
                {
                    x_src = ((tx * 8) + mx);
                }
                int y_src = (((ty * 8) + my + (yy)) * 128);
                if (t.mirror_y)
                {
                    y_src = (((ty * 8) + my) * 128);
                }
                    
                int src = x_src + y_src;
                int pp = 0;
                if (src < 16384)
                {
                    pp = 8;
                }
                if (dest < GFX.currentData.Length)
                {
                    byte alpha = 255;

                    if (GFX.singledata[(src)] == 0)
                    {
                        if (room.bg2 != 0)
                        {
                            if (layer != 1)
                            {
                                alpha = 0;
                            }
                        }
                        if (room.bg2 == Background2.OnTop)
                        {
                            if (layer != 0)
                            {
                                alpha = 0;
                            }
                            else
                            {
                                alpha = 255;
                            }
                        }
                        if (room.bg2 == Background2.Transparent)
                        {
                            alpha = 0;
                        }

                    }
                    else
                    {
                        if (room.bg2 == Background2.Transparent)
                        {
                            if (layer == 1)
                            {
                                alpha = 128;
                            }
                        }
                    }

                    if (allBgs)
                    {
                        alpha = 255;
                    }
                    GFX.currentData[dest] = (GFX.loadedPalettes[GFX.singledata[(src)] + pp, t.palette].B);
                    GFX.currentData[dest + 1] = (GFX.loadedPalettes[GFX.singledata[(src)] + pp, t.palette].G);
                    GFX.currentData[dest + 2] = (GFX.loadedPalettes[GFX.singledata[(src)] + pp, t.palette].R);
                    GFX.currentData[dest + 3] = alpha;//A
                }
            }
        }
    }


        public void makeTileTransparent(Bitmap b)
        {

        }



    }



}

