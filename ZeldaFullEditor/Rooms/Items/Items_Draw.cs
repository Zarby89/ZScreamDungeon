using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public partial class Room
    {
        //pots items
        public void PotsItemsDraw(byte id, int x, int y)
        {
            if (id == 0)//Nothing
            {

            }
            else if (id == 1)//rupee
            {
                draw_item_tile(x + 4, y, 8, 16, 0x80, 11);
            }
            else if (id == 2) //Rock Crab
            {
                draw_item_tile(x, y, 8, 16, 0x80, 11);
            }
            else if (id == 3) //bee
            {
                draw_item_tile(x, y, 8, 16, 0x80, 11);
            }
            else if (id == 4) //Random
            {
                // draw_item_tile(x, y, 8, 16, 0x80, 11);
            }
            else if (id == 5) //bomb
            {
                draw_item_tile(x, y, 16, 16, 0x44, 7);
            }
            else if (id == 6)//rupee
            {
                draw_item_tile(x + 4, y, 8, 16, 0x80, 11);
            }
            else if (id == 7)//blue rupee
            {
                draw_item_tile(x + 4, y, 8, 16, 0x80, 7);
            }
            else if (id == 8)//key
            {
                draw_item_tile(x + 4, y, 8, 16, 0x2E, 11);
            }
            else if (id == 9)//arrow
            {
                draw_item_tile(x + 4, y, 8, 16, 0xA8, 11);
            }
            else if (id == 10)//1bomb
            {
                draw_item_tile(x, y, 16, 16, 0x44, 7);
            }
            else if (id == 11)//heart
            {
                draw_item_tile(x + 4, y, 8, 16, 0xA6, 5);
            }
            else if (id == 12)//magic
            {
                draw_item_tile(x + 4, y, 8, 16, 0xA7, 11);
            }
            else if (id == 13)//big magic - need gfx
            {
                draw_item_tile(x, y, 16, 16, 0xA7, 11);
            }
            else if (id == 14)//chicken
            {

            }
            else if (id == 15)//green soldier
            {

            }
            else if (id == 16)//alive rock
            {

            }
            else if (id == 17)//blue soldier
            {

            }
            else if (id == 18)//ground bomb
            {

            }
            else if (id == 19)//heart
            {
                draw_item_tile(x + 4, y, 8, 16, 0xA6, 5);
            }
            else if (id == 20)//fairy
            {

            }
            else if (id == 21)//heart
            {
                draw_item_tile(x + 4, y, 8, 16, 0xA6, 5);
            }
            else if (id == 22)//nothing
            {

            }
            else if (id == 23)//hole
            {

            }
            else if (id == 24)//warp
            {
                draw_item_tile(x, y, 16, 16, 0xC6, 11);
            }
            else if (id == 25)//staircase
            {

            }
            else if (id == 26)//bombale
            {

            }
            else if (id == 27)//switch
            {

            }
        }




        public void draw_item_tile(int x, int y, int sx, int sy, int tid, int pid, bool rando = false)
        {
            int ty = 72 + ((tid & 0xF0) >> 4);
            if (rando == true) { ty += 16; };
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
                    if (dest < GFX.currentData.Length)
                    {
                        if (dest > 0)
                        {

                            if (GFX.singledata[(src)] == 0)
                            {

                            }
                            else
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
