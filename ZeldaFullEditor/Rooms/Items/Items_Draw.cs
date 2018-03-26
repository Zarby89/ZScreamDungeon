using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    [Serializable]
    public class PotItem
    {
        public byte x, y, id;
        public byte nx, ny;
        public bool selected = false;
        public byte layer = 0;
        public bool bg2 = false;
        public PotItem(byte id, byte x, byte y,bool bg2)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.nx = x;
            this.ny = y;
            this.bg2 = bg2;


        }

        //pots items
        public void Draw()
        {
            int id = this.id;
            if ((id & 0x80) == 0x80)
            {
                id = (byte)((id - 0x80) / 2);
                id += 23;
            }

            if (id == 0)//Nothing
            {
                draw_item_tile(x * 8, y * 8, 16, 16, 0x6C, 10, true);
            }
            else if (id == 1)//rupee
            {
                draw_item_tile(x*8 + 4, y*8, 8, 16, 0x80, 11);
            }
            else if (id == 2) //Rock Crab
            {
                draw_item_tile(x * 8, y * 8, 16, 16, 0x46, 10, true);
            }
            else if (id == 3) //bee
            {
                draw_item_tile((x * 8)+4, (y * 8)+4, 8, 8, 0xE4, 10, false, true);
            }
            else if (id == 4) //Random
            {
                draw_item_tile(x*8+4, y*8+4, 8, 8, 0x6A, 10, false);
            }
            else if (id == 5) //bomb
            {
                draw_item_tile(x*8, y*8, 16, 16, 0x44, 7);
            }
            else if (id == 6)//rupee
            {
                draw_item_tile(x*8 + 4, y*8, 8, 16, 0x80, 11);
            }
            else if (id == 7)//blue rupee
            {
                draw_item_tile(x*8 + 4, y*8, 8, 16, 0x80, 7);
            }
            else if (id == 8)//key*8
            {
                draw_item_tile(x*8 + 4, y*8, 8, 16, 0x2E, 11);
            }
            else if (id == 9)//arrow
            {
                draw_item_tile(x*8 + 4, y*8, 8, 16, 0xA8, 11);
            }
            else if (id == 10)//1bomb
            {
                draw_item_tile(x*8, y*8, 16, 16, 0x44, 7);
            }
            else if (id == 11)//heart
            {
                draw_item_tile(x*8 + 4, y*8, 8, 16, 0xA6, 5);
            }
            else if (id == 12)//magic
            {
                draw_item_tile(x*8 + 4, y*8, 8, 16, 0xA7, 11);
            }
            else if (id == 13)//big magic - need gfx
            {
                draw_item_tile((x*8+4), y*8, 8, 16, 0x62, 11,false,true); //2x22
            }
            else if (id == 14)//chicken 
            {
                draw_item_tile(x*8, y*8, 16, 16, 0xEA, 10,true, true);
            }
            else if (id == 15)//green soldier
            {
                draw_item_tile(x*8, y*8, 16, 16, 0x40, 12, true, true);
            }
            else if (id == 16)//alive rock
            {
                draw_item_tile(x*8, y*8, 16, 16, 0x46, 10, true);
            }
            else if (id == 17)//blue soldier
            {
                draw_item_tile(x*8, y*8, 16, 16, 0x40, 10, true, true);
            }
            else if (id == 18)//ground bomb
            {
                draw_item_tile(x * 8, y * 8, 16, 16, 0x48, 10, true);
            }
            else if (id == 19)//heart
            {
                draw_item_tile(x*8 + 4, y*8, 8, 16, 0xA6, 5);
            }
            else if (id == 20)//fairy*8
            {
                draw_item_tile(x*8, y*8, 16, 16, 0xEC, 10, false, true);
            }
            else if (id == 21)//heart
            {
                draw_item_tile(x*8 + 4, y*8, 8, 16, 0xA6, 5);
            }
            else if (id == 22)//nothing
            {
                draw_item_tile(x*8, y*8, 16, 16, 0x6C, 10, true);
            }
            else if (id == 23)//hole
            {
                draw_item_tile(x * 8, y * 8, 16, 16, 0x60, 9, false);
            }
            else if (id == 24)//warp
            {
                draw_item_tile(x*8, y*8, 16, 16, 0xC6, 11);
            }
            else if (id == 25)//staircase
            {

            }
            else if (id == 26)//bombale
            {

            }
            else if (id == 27)//switch
            {
                draw_item_tile(x*8, y*8, 8, 16, 0x0B, 5, true);
            }
        }





        public void draw_item_tile(int x, int y, int sx, int sy, int tid, int pid, bool nsheet = false,bool sprite = false)
        {

            if (nx != this.x || ny != this.y)
            {
                x -= (this.x * 8);
                y -= (this.y * 8);
                x += (this.nx * 8);
                y += (this.ny * 8);
            }

            int ty = ((tid & 0xF0) >> 4);
            if (nsheet)
            {
                ty += 16;
            }
            if (sprite)
            {
                ty += 32;
            }
            int tx = tid & 0x0F;
            for (int xx = 0; xx < (sx); xx++)
            {
                for (int yy = 0; yy < (sy); yy++)
                {
                    int x_dest = ((x) + (xx)) * 4;
                    int y_dest = (((y) + (yy)) * 512) * 4;
                    int dest = x_dest + y_dest;

                    int x_src = ((tx * 8) + (xx));
                    int y_src = (((ty * 8) + (yy)) * 128);

                    int src = x_src + y_src;
                    unsafe
                    {
                        if (dest < 1048576)
                        {
                            if (dest > 0)
                            {
                                if (sprite == false)
                                {
                                    if (GFX.itemsdataEDITOR[(src)] != 0)
                                    { 
                                        GFX.currentData[dest] = (GFX.spritesPalettes[GFX.itemsdataEDITOR[(src)], pid - 2].B);
                                        GFX.currentData[dest + 1] = (GFX.spritesPalettes[GFX.itemsdataEDITOR[(src)], pid - 2].G);
                                        GFX.currentData[dest + 2] = (GFX.spritesPalettes[GFX.itemsdataEDITOR[(src)], pid - 2].R);
                                        GFX.currentData[dest + 3] = 255;
                                    }
                                }
                                else
                                {
                                    if (GFX.singledata[(src)] != 0)
                                    {
                                        GFX.currentData[dest] = (GFX.spritesPalettes[GFX.singledata[(src)], pid - 2].B);
                                        GFX.currentData[dest + 1] = (GFX.spritesPalettes[GFX.singledata[(src)], pid - 2].G);
                                        GFX.currentData[dest + 2] = (GFX.spritesPalettes[GFX.singledata[(src)], pid - 2].R);
                                        GFX.currentData[dest + 3] = 255;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
