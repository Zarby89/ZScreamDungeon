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
                //sword and shield
                draw_item_tile(-1 + x, y + 0, 8, 16, 0x21, 5);
                draw_item_tile(x + 3, y + 0, 16, 16, 0x0E, 5);
            }
            else if (id == 1)
            {
                //swords - need to do something else?
                draw_item_tile(x + 4, y + 0, 8, 16, 0x21, 5);
            }
            else if (id == 2)
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0x21, 5);
            }
            else if (id == 3)
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0x21, 5);
            }
            else if (id == 4)
            {

                //shields - need to do something else?
                draw_item_tile(x + 0, y + 0, 16, 16, 0x0E, 7);
            }
            else if (id == 5)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x0C, 11);
            }
            else if (id == 6)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0xA4, 11);
            }
            else if (id == 7)//fire rod
            {

                draw_item_tile(x + 4, y + 0, 8, 16, 0x24, 5);
            }
            else if (id == 8)
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0x24, 7);
            }
            else if (id == 9)
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0x25, 11);
            }
            else if (id == 10)
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0x23, 5);
            }
            else if (id == 11)//bow
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0x20, 5);
            }
            else if (id == 12)
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0x2F, 7);
            }
            else if (id == 13)//powder
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x26, 7);
            }
            else if (id == 14) //bee
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x8D, 7);
            }
            else if (id == 15)//bombos
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x62, 11);
            }
            else if (id == 16)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x60, 11);
            }
            else if (id == 17)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x64, 11);
            }
            else if (id == 18)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x46, 5);//lamp
            }
            else if (id == 19)
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0x4F, 5);
            }
            else if (id == 20)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0xA2, 7);
            }
            else if (id == 21)
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0x22, 5);
            }
            else if (id == 22)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x66, 7);
            }
            else if (id == 23)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0xA0, 5);
            }
            else if (id == 24)
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0x22, 7);
            }
            else if (id == 25)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x48, 5);
            }
            else if (id == 26)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x42, 7);
            }
            else if (id == 27)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x2A, 5);
            }
            else if (id == 28)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x2A, 11);
            }
            else if (id == 29)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x2C, 11);
            }
            else if (id == 30)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x40, 7);
            }
            else if (id == 31)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x4C, 5);
            }
            else if (id == 32)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x85, 7);
            }
            else if (id == 33)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x83, 5);
            }
            else if (id == 34)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x08, 7);//blue mail
            }
            else if (id == 35)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x08, 5);
            }
            else if (id == 36)
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0x2E, 11);
            }
            else if (id == 37)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x4A, 7);
            }
            else if (id == 38)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x06, 5); //liar heart? lol
            }
            else if (id == 39)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x44, 7);
            }
            else if (id == 40)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x02, 7);
            }
            else if (id == 41)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x6A, 11);
            }
            else if (id == 42)
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0x2F, 5);
            }
            else if (id == 43)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x00, 5);
            }
            else if (id == 44)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x00, 11);
            }
            else if (id == 45)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x00, 7);
            }
            else if (id == 46)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x00, 5);
            }
            else if (id == 47)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x00, 11);
            }
            else if (id == 48)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x00, 7);
            }
            else if (id == 49)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x28, 7);
            }
            else if (id == 50)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x6E, 11);
            }
            else if (id == 51)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x6C, 11);
            }
            else if (id == 52)
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0x81, 11);
            }
            else if (id == 53)
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0x81, 7);
            }
            else if (id == 54)
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0x81, 5);
            }
            else if (id == 55)
            {
                draw_item_tile(x, y + 0, 16, 16, 0xC4, 11);
            }
            else if (id == 56)
            {
                draw_item_tile(x, y + 0, 16, 16, 0xC4, 7);
            }
            else if (id == 57)
            {
                draw_item_tile(x, y + 0, 16, 16, 0xC4, 5);
            }
            else if (id == 58)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x89, 7);
            }
            else if (id == 59)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x87, 5);
            }
            else if (id == 60)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x8D, 7);
            }
            else if (id == 61)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x8B, 7);
            }
            else if (id == 62)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x06, 5); //boss heart
            }
            else if (id == 63)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x06, 5); //sanc heart?
            }
            else if (id == 64)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0xA9, 11);
            }
            else if (id == 65)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0xAB, 11);
            }
            else if (id == 66)
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0xA6, 5);
            }
            else if (id == 67)
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0xA8, 7);
            }
            else if (id == 68)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x04, 7);
            }
            else if (id == 69)
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0xA7, 7);
            }
            else if (id == 70)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0xAD, 11);
            }
            else if (id == 71)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0xC0, 11);
            }
            else if (id == 72)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x8D, 7);
            }
            else if (id == 73)
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0x21, 7);
            }
            else if (id == 74)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0xA2, 7);
            }
            else if (id == 75)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0xC2, 5);
            }
            //ADDED RANDOMIZER
            else if (id == 76)
            {
                draw_item_tile(x, y + 0, 16, 16, 0x00, 11, true);//Bomb Updgrade
            }
            else if (id == 77)
            {
                draw_item_tile(x, y + 0, 16, 16, 0x02, 11, true);//Arrow Upgrade
            }
            else if (id == 78)
            {
                draw_item_tile(x, y + 0, 16, 16, 0x04, 11, true);//halfmagic
            }
            else if (id == 79)
            {
                draw_item_tile(x, y + 0, 16, 16, 0x06, 11, true);//quartermagic
            }
            else if (id == 80)
            {
                draw_item_tile(x, y + 0, 16, 16, 0x24, 7, true);//sword
            }
            else if (id == 81)
            {
                draw_item_tile(x, y + 0, 16, 16, 0x08, 11, true);//Bomb Updgrade
            }
            else if (id == 82)
            {
                draw_item_tile(x, y + 0, 16, 16, 0x0A, 11, true);//Bomb Updgrade
            }
            else if (id == 83)
            {
                draw_item_tile(x, y + 0, 16, 16, 0x0C, 11, true);//Arrow Upgrade
            }
            else if (id == 84)
            {
                draw_item_tile(x, y + 0, 16, 16, 0x0E, 11, true);//Arrow Upgrade
            }
            else if (id == 88)
            {
                draw_item_tile(x, y + 0, 8, 16, 0x20, 5, true);//silver arrows
            }
            else if (id == 89)
            {
                draw_item_tile(x, y + 0, 8, 16, 0x80, 9);//rupoor
            }
            else if (id == 90)
            {
                draw_item_tile(x, y + 0, 8, 16, 0xC8, 8);//null item?
            }
            else if (id == 91)
            {
                draw_item_tile(x, y + 0, 16, 16, 0x68, 10, true);
            }
            else if (id == 92)
            {
                draw_item_tile(x, y + 0, 16, 16, 0x68, 7, true);
            }
            else if (id == 93)
            {
                draw_item_tile(x, y + 0, 16, 16, 0x68, 11, true);
            }
            else if (id == 94)
            {
                draw_item_tile(x, y + 0, 16, 16, 0x22, 11, true);//sword
            }
            else if (id == 95)
            {
                draw_item_tile(x, y + 0, 16, 16, 0x0E, 11);//shield
            }
            else if (id == 96)
            {
                draw_item_tile(x, y + 0, 16, 16, 0x08, 11);//armor
            }
            else if (id == 97)
            {
                draw_item_tile(x, y + 0, 16, 16, 0x2A, 11);//armor
            }
            else if (id >= 112 && id < 128)
            {
                draw_item_tile(x, y + 0, 16, 16, 0x6C, 11);//map
            }
            else if (id >= 128 && id < 144)
            {
                draw_item_tile(x, y + 0, 16, 16, 0x4A, 5);//compass
            }
            else if (id >= 144 && id < 160)
            {
                draw_item_tile(x + 0, y + 0, 16, 16, 0x6E, 11);//Big Keys
            }
            else if (id >= 160 && id < 176)
            {
                draw_item_tile(x + 4, y + 0, 8, 16, 0x2E, 11);//Small keys
            }
        }


        public void draw_item_tile(int x, int y, int sx, int sy, int tid, int pid, bool rando = false)
        {

            int ty = ((tid & 0xF0) >> 4);
            if (rando == true) { ty += 16; };
            int tx = tid & 0x0F;

            if (picker)
            {
                x = 0;//x - this.x;
                y = 0;//y - this.y;
            }

            for (int xx = 0; xx < (sx); xx++)
            {
                for (int yy = 0; yy < (sy); yy++)
                {
                    int x_dest = ((x) + (xx)) * 4;
                    int y_dest = (((y) + (yy)) * 512) * 4;
                    if (picker)
                    {
                        y_dest = (((y) + (yy)) * 16) * 4;
                    }
                    int dest = x_dest + y_dest;

                    int x_src = ((tx * 8) + (xx));
                    int y_src = (((ty * 8) + (yy)) * 128);

                    int src = x_src + y_src;
                    unsafe
                    {
                        if (dest < 4096)
                        {
                            if (dest > 0)
                            {

                                if (GFX.itemsdataEDITOR[(src)] == 0)
                                {

                                }
                                else
                                {
                                    GFX.currentData[dest] = (GFX.spritesPalettes[GFX.itemsdataEDITOR[(src)], pid - 2].B);
                                    GFX.currentData[dest + 1] = (GFX.spritesPalettes[GFX.itemsdataEDITOR[(src)], pid - 2].G);
                                    GFX.currentData[dest + 2] = (GFX.spritesPalettes[GFX.itemsdataEDITOR[(src)], pid - 2].R);
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