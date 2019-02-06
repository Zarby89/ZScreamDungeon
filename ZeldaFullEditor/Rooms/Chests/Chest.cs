using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    [Serializable]
    public class Chest
    {
        public byte x, y, item;
        public bool picker = false;
        public bool bigChest = false;
        public Chest(byte x, byte y, byte item, bool bigChest, bool picker = false)
        {
            this.x = x;
            this.y = y;
            this.item = item;
            this.picker = picker;
            this.bigChest = bigChest;
        }


        //Chests Items
        public void ItemsDraw(byte id, int x, int y)
        {
            if (id == 0)
            {
                //TODO : NEED TO CHANGE PALETTE TO SWORD & SHIELD PALETTE
                //sword and shield
                draw_item_tile(x, y + 0, 14, 824, 7,false,false,1);
                draw_item_tile(x + 8, y + 0, 15, 828, 7,false,false,1);
            }
            else if (id == 1)
            {
                //sword2 - need to do something else?
                draw_item_tile(x+4, y + 0, 14, 824, 7, false, false, 1);
            }
            else if (id == 2)
            {
                //sword3
                draw_item_tile(x + 4, y + 0, 14, 824, 7, false, false, 1);
            }
            else if (id == 3)
            {
                //sword4
                draw_item_tile(x + 4, y + 0, 14, 824, 5, false, false, 1);
            }
            else if (id == 4)
            {

                //shields - need to do something else?
                draw_item_tile(x, y + 0, 14, 820, 7);
            }
            else if (id == 5)
            {
                //shield2
                draw_item_tile(x , y + 0, 12, 820, 11);
            }
            else if (id == 6)
            {
                //shield3
                draw_item_tile(x , y, 4, 830, 11);
            }
            else if (id == 7)//fire rod
            {

                draw_item_tile(x + 4, y + 0, 4, 822, 5, false, false, 1);
            }
            else if (id == 8)//ice rod
            {
                draw_item_tile(x + 4, y + 0, 4, 822, 7, false, false, 1);
            }
            else if (id == 9) //hammer
            {
                draw_item_tile(x + 4, y + 0, 5, 822, 5, false, false, 1);
            }
            else if (id == 10)//Hookshot
            {
                draw_item_tile(x + 4, y + 0, 3, 822, 5, false, false, 1);
            }
            else if (id == 11)//bow
            {
                draw_item_tile(x + 4, y + 0, 0, 822, 5, false, false, 1);
            }
            else if (id == 12)//Boomerang
            {
                draw_item_tile(x + 4, y + 0, 15, 822, 7, false, false, 1);
            }
            else if (id == 13)//powder
            {
                draw_item_tile(x, y + 0, 6, 822, 7);
            }
            else if (id == 14) //bee
            {
                draw_item_tile(x + 0, y + 0, 13, 828, 7);
            }
            else if (id == 15)//bombos
            {
                draw_item_tile(x + 0, y + 0, 2, 826, 11);
            }
            else if (id == 16)//ether
            {
                draw_item_tile(x + 0, y + 0, 0, 826, 11);
            }
            else if (id == 17)//quake
            {
                draw_item_tile(x + 0, y + 0, 4, 826, 11);
            }
            else if (id == 18)//lamp
            {
                draw_item_tile(x , y, 6, 824, 5);//lamp
            }
            else if (id == 19)//shovel
            {
                draw_item_tile(x+4, y + 0, 15, 824, 5, false, false, 1);
            }
            else if (id == 20)//flute
            {
                draw_item_tile(x, y, 2, 830, 7);
            }
            else if (id == 21)//somaria
            {
                draw_item_tile(x + 4, y + 0, 2, 822, 5, false, false, 1);
            }
            else if (id == 22)//bottle
            {
                draw_item_tile(x + 0, y + 0, 6, 826, 11);
            }
            else if (id == 23)//heart piece
            {
                draw_item_tile(x, y, 0, 830, 5);
            }
            else if (id == 24)//byrna
            {
                draw_item_tile(x + 4, y + 0, 2, 822, 7, false, false, 1);
            }
            else if (id == 25)//cape
            {
                draw_item_tile(x, y, 8, 824, 5);//lamp
            }
            else if (id == 26)//mirror
            {
                draw_item_tile(x + 0, y + 0, 2, 824, 7);
            }
            else if (id == 27)//power glove
            {
                draw_item_tile(x , y + 0, 10, 822, 5);
            }
            else if (id == 28)//titan mitts
            {
                draw_item_tile(x , y + 0, 10, 822, 11);
            }
            else if (id == 29)//book
            {
                draw_item_tile(x , y + 0, 12, 822, 11);
            }
            else if (id == 30)//flippers
            {
                draw_item_tile(x + 0, y + 0, 0, 824, 7);
            }
            else if (id == 31)//moon pearl
            {
                draw_item_tile(x, y + 0, 12, 824, 5);
            }
            else if (id == 32)//crystal
            {
                draw_item_tile(x + 0, y + 0, 5, 828, 6);
            }
            else if (id == 33)//net
            {
                draw_item_tile(x + 0, y + 0, 3, 828, 5);
            }
            else if (id == 34)//blue mail
            {
                draw_item_tile(x, y + 0, 8, 820, 7);
            }
            else if (id == 35)//red mail
            {
                draw_item_tile(x, y + 0, 8, 820, 5);
            }
            else if (id == 36)//Key
            {
                draw_item_tile(x+4, y + 0, 14, 822, 11,false,false,1);
            }
            else if (id == 37)//compass
            {
                draw_item_tile(x, y + 0, 10, 824, 7);
            }
            else if (id == 38)//liar heart?
            {
                draw_item_tile(x, y + 0, 6, 820, 5);
            }
            else if (id == 39)//Bomb
            {
                draw_item_tile(x + 0, y + 0, 4, 824, 7);
            }
            else if (id == 40)//3Bombs
            {
                draw_item_tile(x, y + 0, 2, 820, 7);
            }
            else if (id == 41)//Mushroom
            {
                draw_item_tile(x, y + 0, 10, 826, 11);
            }
            else if (id == 42)//Red Boomerang
            {
                draw_item_tile(x + 4, y + 0, 15, 822, 5, false, false, 1);
            }
            else if (id == 43) //red pot
            {
                draw_item_tile(x, y, 8, 826, 5);
            }
            else if (id == 44) //green pot
            {
                draw_item_tile(x, y, 8, 826, 11);
            }
            else if (id == 45) //blue pot
            {
                draw_item_tile(x, y, 8, 826, 7);
            }
            else if (id == 46)//red pot
            {
                draw_item_tile(x, y + 0, 0, 820, 5);
            }
            else if (id == 47)//green pot
            {
                draw_item_tile(x, y + 0, 0, 820,11);
            }
            else if (id == 48) //blue pot
            {
                draw_item_tile(x, y + 0, 0, 820, 7);
            }
            else if (id == 49)//10 bombs
            {
                draw_item_tile(x, y + 0, 8, 822, 7);
            }
            else if (id == 50)//Big Key
            {
                draw_item_tile(x, y + 0, 14, 826, 11);
            }
            else if (id == 51)//map
            {
                draw_item_tile(x, y + 0, 12, 826, 11);
            }
            else if (id == 52)//1 rupee
            {
                draw_item_tile(x + 4, y + 0, 0, 828, 11, false, false, 1);
            }
            else if (id == 53)//5 rupee
            {
                draw_item_tile(x + 4, y + 0, 0, 828, 7, false, false, 1);
            }
            else if (id == 54)//20 rupees
            {
                draw_item_tile(x + 4, y + 0, 0, 828, 5, false, false, 1);
            }
            else if (id == 55)//Green Pendant
            {
                draw_item_tile(x + 0, y + 0, 4, 832, 11);
            }
            else if (id == 56)//Blue Pendant
            {
                draw_item_tile(x + 0, y + 0, 4, 832, 7);
            }
            else if (id == 57) //Red Pendant
            {
                draw_item_tile(x + 0, y + 0, 4, 832, 5);
            }
            else if (id == 58)//Bow & Arrows
            {
                draw_item_tile(x + 0, y + 0, 7, 828, 5);
            }
            else if (id == 59)//Bow & Silver Arrows
            {
                draw_item_tile(x + 0, y + 0, 9, 828, 7);
            }
            else if (id == 60) //Bee
            {
                draw_item_tile(x + 0, y + 0, 13, 828, 7);
            }
            else if (id == 61)//Fairy
            {
                draw_item_tile(x + 0, y + 0, 11, 828, 7);
            }
            else if (id == 62)//Boss Heart
            {
                draw_item_tile(x, y + 0, 6, 820, 5);
            }
            else if (id == 63)//sanc heart?
            {
                draw_item_tile(x, y + 0, 6, 820, 5);
            }
            else if (id == 64)//100 rupees
            {
                draw_item_tile(x, y, 9, 830, 11);
            }
            else if (id == 65)//50 rupees
            {
                draw_item_tile(x, y, 11, 830, 11);
            }
            else if (id == 66)//small heart
            {
                draw_item_tile(x+4, y, 6, 830, 5,false,false,1);
            }
            else if (id == 67)//1 Arrow
            {
                draw_item_tile(x+4, y, 8, 830, 11, false, false, 1);
            }
            else if (id == 68)//10 Arrow
            {
                draw_item_tile(x, y + 0, 4, 820, 11);
            }
            else if (id == 69)//Magic
            {
                draw_item_tile(x+4, y, 7, 830, 11, false, false, 1);
            }
            else if (id == 70)//300 Rupees
            {
                draw_item_tile(x, y, 13, 830, 11);
            }
            else if (id == 71)//20 rupees
            {
                draw_item_tile(x + 0, y + 0, 0, 832, 11);
            }
            else if (id == 72)//bee
            {
                draw_item_tile(x + 0, y + 0, 13, 828, 7);
            }
            else if (id == 73)//sword 1
            {
                draw_item_tile(x + 4, y + 0, 1, 822, 7, false, false, 1);
            }
            else if (id == 74) //flute activated
            {
                draw_item_tile(x, y, 2, 830, 7);
            }
            else if (id == 75) //Boots
            {
                draw_item_tile(x + 0, y + 0, 2, 832, 5);
            }

        }


        public unsafe void draw_item_tile(int x, int y, int srcx, int srcy, int pal, bool mirror_x = false, bool mirror_y = false, int sizex = 2, int sizey = 2)
        {

            var alltilesData = (byte*)GFX.allgfx16Ptr.ToPointer();
            byte* ptr = (byte*)GFX.roomBg1Ptr.ToPointer();

            if (picker == false)
            {

                int drawid = (srcx + (srcy * 16));
                for (var yl = 0; yl < sizey * 8; yl++)
                {
                    for (var xl = 0; xl < (sizex * 8) / 2; xl++)
                    {
                        int mx = xl;
                        int my = yl;
                        byte r = 0;

                        if (mirror_x)
                        {
                            mx = (((sizex * 8) / 2) - 1) - xl;
                            r = 1;
                        }
                        if (mirror_y)
                        {
                            my = (((sizey * 8)) - 1) - yl;
                        }
                        //Formula information to get tile index position in the array
                        //((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
                        int tx = ((drawid / 16) * 512) + ((drawid - ((drawid / 16) * 16)) * 4);
                        var pixel = alltilesData[tx + (yl * 64) + xl];
                        //nx,ny = object position, xx,yy = tile position, xl,yl = pixel position
                        int index = (x) + (y * 512) + ((mx * 2) + (my * (512)));
                        if ((pixel & 0x0F) != 0)
                        {
                            ptr[index + r ^ 1] = (byte)((pixel & 0x0F) + 112 + (pal * 8));
                        }
                        if (((pixel >> 4) & 0x0F) != 0)
                        {
                            ptr[index + r] = (byte)(((pixel >> 4) & 0x0F) + 112 + (pal * 8));
                        }
                    }
                }
            }
            else
            {
                ptr = (byte*)GFX.previewChestsPtr[item].ToPointer();
                int drawid = (srcx + (srcy * 16));
                for (var yl = 0; yl < sizey * 8; yl++)
                {
                    for (var xl = 0; xl < (sizex * 8) / 2; xl++)
                    {
                        int mx = xl;
                        int my = yl;
                        byte r = 0;

                        if (mirror_x)
                        {
                            mx = (((sizex * 8) / 2) - 1) - xl;
                            r = 1;
                        }
                        if (mirror_y)
                        {
                            my = (((sizey * 8)) - 1) - yl;
                        }
                        //Formula information to get tile index position in the array
                        //((ID / nbrofXtiles) * (imgwidth/2) + (ID - ((ID/16)*16) ))
                        int tx = ((drawid / 16) * 512) + ((drawid - ((drawid / 16) * 16)) * 4);
                        var pixel = alltilesData[tx + (yl * 64) + xl];
                        //nx,ny = object position, xx,yy = tile position, xl,yl = pixel position
                        int index = (x) + (y * 64) + ((mx * 2) + (my * (64)));
                        if ((pixel & 0x0F) != 0)
                        {
                            ptr[index + r ^ 1] = (byte)((pixel & 0x0F) + 112 + (pal * 8));
                        }
                        if (((pixel >> 4) & 0x0F) != 0)
                        {
                            ptr[index + r] = (byte)(((pixel >> 4) & 0x0F) + 112 + (pal * 8));
                        }
                    }
                }
            }
        }
    }
}