using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    [Serializable]
    public class Sprite
    {
        public byte x, y, id;
        public byte nx, ny;
        public byte layer = 0;
        public byte subtype = 0;
        public byte overlord = 0;
        public string name;
        public byte keyDrop = 0;
        public int sizeMap = 512;
        public bool preview = false;
        public byte mapid = 0;
        public int map_x = 0;
        public int map_y = 0;
        Room room;
        public Rectangle boundingbox;
        bool picker = false;
        public bool selected = false;
        public Sprite(Room room,byte id, byte x, byte y, byte overlord, byte subtype, byte layer)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.room = room;
            this.overlord = overlord;
            this.subtype = subtype;
            this.layer = layer;
            this.nx = x;
            this.ny = y;
            this.name = Sprites_Names.name[id];
            if (overlord != 0)
            {
                if (id > 0 && id <= 0x19)
                this.name = Sprites_Names.overlordnames[id-1];
            }
        }

        public void updateBBox()
        {
            lowerX = 1;
            lowerY = 1;
            higherX = 15;
            higherY = 15;
        }
        
        public void DrawKey(bool bigKey = false)
        {
            if (bigKey == false)
            {
                int dx = (boundingbox.X + boundingbox.Width / 2) - 8;
                int dy = boundingbox.Y - 10;
                draw_item_tile(dx + 4, dy + 0, 14, 822, 11, false, false, 1);
            }
            else
            {
                int dx = (boundingbox.X + boundingbox.Width / 2) - 8;
                int dy = boundingbox.Y - 10;
                draw_item_tile(dx, dy + 0, 14, 826, 11);
            }
        }

        
        public void Draw(bool picker = false)
        {

            byte x = this.nx;
            byte y = this.ny;
            this.picker = picker;
            if (overlord == 0x07)
            {
                if (id == 0x1A)
                {
                    drawSpriteTile((x * 16) , (y * 16), 14, 6, 11);//bomb
                }
                else if (id == 0x05)
                {
                    drawSpriteTile((x * 16), (y * 16) - 12, 12, 16, 12, false, true);
                    drawSpriteTile((x * 16), (y * 16), 0, 16, 12, false, true);
                }
                else if (id == 0x06)
                {
                    drawSpriteTile((x * 16), (y * 16), 10, 26, 14, true, true, 2, 2);//snek
                }
                else if (id == 0x09)
                {
                    drawSpriteTile((x * 16), (y * 16), 6, 26, 14);
                    drawSpriteTile((x * 16) + 8, (y * 16) + 8, 8, 26, 14);
                    drawSpriteTile((x * 16), (y * 16) + 16, 10, 27, 14,false,false,1,1);
                }
                else if (id == 0x14)
                {
                    drawSpriteTile((x * 16), (y * 16) + 8, 12, 06, 12, false, false, 2, 1);//shadow tile
                    drawSpriteTile((x * 16), (y * 16) - 8, 3, 29, 8, false, false, 1, 1);//tile
                    drawSpriteTile((x * 16) + 8, (y * 16) - 8, 3, 29, 8, true, false, 1, 1);//tile
                    drawSpriteTile((x * 16), (y * 16), 3, 29, 8, false, true, 1, 1);//tile
                    drawSpriteTile((x * 16) + 8, (y * 16), 3, 29, 8, true, true, 1, 1);//tile
                }
                else
                {
                    drawSpriteTile((x * 16), (y * 16), 4, 4, 5);
                }
                if (nx != this.x || ny != this.y)
                {
                    boundingbox = new Rectangle((lowerX + (nx * 16)), (lowerY + (ny * 16)), width, height);
                }
                else
                {
                    boundingbox = new Rectangle((lowerX + (x * 16)), (lowerY + (y * 16)), width, height);
                }
                return;
            }

            if (id == 0x00)
            {
                drawSpriteTile((x * 16), (y * 16), 4, 28, 10);
            }
            else if (id == 0x01)
            {
                drawSpriteTile((x * 16)-8, (y * 16), 6, 24, 12, false, false, 2,2);
                drawSpriteTile((x * 16) + 8, (y * 16), 6, 24, 12, true, false, 2, 2);

            }
            else if (id == 0x02)
            {
                drawSpriteTile((x * 16), (y * 16), 0, 16, 10);
            }
            else if (id == 0x04)
            {
                byte p = 3;
                if (room != null)
                {
                    if (room.blocks[13] == 83) { p = 15; };
                }
                drawSpriteTile((x * 16), (y * 16), 14, 28, p);
                drawSpriteTile((x * 16), (y * 16), 14, 30, p);
            }
            else if (id == 0x05)
            {
                byte p = 3;
                if (room != null)
                {
                    if (room.blocks[13] == 83) { p = 15; };
                }
                drawSpriteTile((x * 16), (y * 16), 14, 28, p);
                drawSpriteTile((x * 16), (y * 16), 14, 30, p);
            }
            else if (id == 0x06)
            {
                byte p = 3;
                if (room != null)
                {
                    if (room.blocks[13] == 83) { p = 15; };
                }
                drawSpriteTile((x * 16), (y * 16), 14, 28, p);
                drawSpriteTile((x * 16), (y * 16), 14, 30, p);
            }
            else if (id == 0x07)
            {
                byte p = 3;
                if (room != null)
                {
                    if (room.blocks[13] == 83) { p = 15; };
                }
                drawSpriteTile((x * 16), (y * 16), 14, 28, p);
                drawSpriteTile((x * 16), (y * 16), 14, 30, p);
            }
            else if (id == 0x08)
            {
                drawSpriteTile((x * 16), (y * 16), 0, 24, 6);
                drawSpriteTile((x * 16) + 4, (y * 16) + 6, 0, 24, 6, false, false, 1, 1);
            }
            else if (id == 0x09)
            {
                drawSpriteTile((x * 16) - 22, (y * 16) - 24, 12, 24, 12, false, false, 2, 2);//moldorm tail
                drawSpriteTile((x * 16) - 16, (y * 16) - 20, 8, 24, 12, false, false, 2, 2);//moldorm b2
                drawSpriteTile((x * 16) - 12, (y * 16) - 16, 4, 24, 12, false, false, 4, 4);//moldorm b
                drawSpriteTile((x * 16), (y * 16), 0, 24, 12, false, false, 4, 4);//moldorm head

                drawSpriteTile((x * 16) + 20, (y * 16) + 12, 8, 26, 14, false, false, 2, 2);//moldorm eye
                drawSpriteTile((x * 16) + 12, (y * 16) + 20, 8, 26, 14, false, false, 2, 2);//moldorm eye

            }
            else if (id == 0x0A)
            {
                drawSpriteTile((x * 16), (y * 16), 0, 24, 8);
                drawSpriteTile((x * 16) + 4, (y * 16) + 6, 0, 24, 8, false, false, 1, 1);
            }
            else if (id == 0x0B)
            {
                drawSpriteTile((x * 16), (y * 16), 10, 30, 10);
            }
            else if (id == 0x0C)
            {
                drawSpriteTile((x * 16), (y * 16), 0, 24, 8);
                drawSpriteTile((x * 16) + 4, (y * 16) + 6, 0, 24, 8, false, false, 1, 1);
            }
            else if (id == 0x0D)
            {
                drawSpriteTile((x * 16), (y * 16), 14, 28, 12);
            }
            else if (id == 0x0E)
            {
                drawSpriteTile((x * 16), (y * 16), 8, 18, 10, false, false, 3, 2);
            }
            else if (id == 0x0F)
            {
                drawSpriteTile((x * 16), (y * 16), 14, 24, 8, false, false, 2, 3);
                drawSpriteTile((x * 16) + 16, (y * 16), 30, 8, 8, true, false, 1, 3);
            }
            else if (id == 0x10)
            {
                drawSpriteTile((x * 16), (y * 16), 12, 31, 8, false, false, 1, 1);
            }
            else if (id == 0x11)
            {
                drawSpriteTile((x * 16), (y * 16) + 16, 6, 16, 8, false, false, 2, 2); //feet
                drawSpriteTile((x * 16) - 8, (y * 16) + 8, 4, 18, 8, false, false, 2, 2); //body1
                drawSpriteTile((x * 16) + 8, (y * 16) + 8, 4, 18, 8, true, false, 2, 2); //body2
                drawSpriteTile((x * 16), (y * 16), 0, 16, 8, false, false, 2, 2); //head
            }
            else if (id == 0x12)
            {
                drawSpriteTile((x * 16), (y * 16) + 8, 8, 26, 8);
                drawSpriteTile((x * 16), (y * 16), 6, 24, 8);
            }
            else if (id == 0x13)
            {
                drawSpriteTile((x * 16), (y * 16), 4, 22, 2);
            }
            else if (id == 0x15)
            {
                //Antifairy
                drawSpriteTile((x * 16) + 2, (y * 16) + 8, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16) + 8, (y * 16) + 2, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16) + 14, (y * 16) + 8, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16) + 8, (y * 16) + 14, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16) + 8, (y * 16) + 8, 1, 30, 5, false, false, 1, 1); //middle
            }
            else if (id == 0x16)
            {
                drawSpriteTile((x * 16), (y * 16) + 8, 2, 26, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 26, 2);
            }
            else if (id == 0x17) //bush hoarder
            {
                drawSpriteTile((x * 16), (y * 16), 8, 30, 10);
            }
            else if (id == 0x18) //mini moldorm
            {
                drawSpriteTile((x * 16) + 13, (y * 16) + 17, 13, 21, 8, false, false, 1, 1); //tail
                drawSpriteTile((x * 16) + 5, (y * 16) + 8, 2, 22, 8); //body
                drawSpriteTile((x * 16), (y * 16), 0, 22, 8); //head
                drawSpriteTile((x * 16), (y * 16) - 4, 13, 20, 8, false, false, 1, 1); //eyes
                drawSpriteTile((x * 16) - 4, (y * 16), 13, 20, 8, false, false, 1, 1); //eyes
            }
            else if (id == 0x19) //poe - ghost
            {
                drawSpriteTile((x * 16), (y * 16), 6, 31, 2); //
            }
            else if (id == 0x1A) //smith
            {
                //drawSpriteTile((x*16), (y*16), 2, 4, 10,true); //smitty
                //drawSpriteTile((x*16)+12, (y*16) - 7, 0, 6, 10); //hammer
                drawSpriteTile((x * 16), (y * 16), 4, 22, 10);
            }
            else if (id == 0x1C) //Statue
            {
                drawSpriteTile((x * 16), (y * 16) + 8, 0, 28, 15);
                drawSpriteTile((x * 16), (y * 16), 2, 28, 15, false, false, 1, 1);
                drawSpriteTile((x * 16) + 8, (y * 16), 2, 28, 15, true, false, 1, 1);
            }
            else if (id == 0x1E) //crystal switch
            {
                drawSpriteTile((x * 16), (y * 16), 4, 30, 5);
            }
            else if (id == 0x1F) //sick kid
            {
                drawSpriteTile((x * 16) - 8, (y * 16) + 8, 10, 16, 14);
                drawSpriteTile((x * 16) + 16 - 8, (y * 16) + 8, 10, 16, 14, true);
                drawSpriteTile((x * 16) - 8, (y * 16) + 16, 10, 16, 14, false, true, 2, 2);
                drawSpriteTile((x * 16) + 16 - 8, (y * 16) + 16, 10, 16, 14, true, true, 2, 2);
                drawSpriteTile((x * 16), (y * 16) - 4, 14, 16, 10);
            }
            else if (id == 0x20)
            {
                drawSpriteTile((x * 16), (y * 16), 2, 24, 7);
            }
            else if (id == 0x21) //push switch
            {
                drawSpriteTile((x * 16) + 4, (y * 16) + 20, 13, 29, 3, false, false, 1, 1);
                drawSpriteTile((x * 16) + 4, (y * 16) + 28, 12, 29, 3, false, false, 1, 1);
                drawSpriteTile((x * 16), (y * 16) + 8, 10, 28, 3);
            }
            else if (id == 0x22) //rope
            {

                drawSpriteTile((x * 16), (y * 16), 8, 26, 5);
            }
            else if (id == 0x23) //red bari
            {
                drawSpriteTile((x * 16), (y * 16), 2, 18, 4, false, false, 1, 2);
                drawSpriteTile((x * 16) + 8, (y * 16), 2, 18, 4, true, false, 1, 2);
            }
            else if (id == 0x24) //blue bari
            {
                drawSpriteTile((x * 16), (y * 16), 2, 18, 6, false, false, 1, 2);
                drawSpriteTile((x * 16) + 8, (y * 16), 2, 18, 6, true, false, 1, 2);
            }
            else if (id == 0x25) //talking tree?
            {

            }
            else if (id == 0x26) //hardhat beetle
            {
                if ((x & 0x01) == 0x00)
                {
                    drawSpriteTile((x * 16), (y * 16), 4, 20, 8);
                    drawSpriteTile((x * 16), (y * 16) - 6, 0, 20, 8);
                }
                else
                {
                    drawSpriteTile((x * 16), (y * 16), 4, 20, 10);
                    drawSpriteTile((x * 16), (y * 16) - 6, 0, 20, 10);
                }

            }
            else if (id == 0x27) //deadrock
            {

                drawSpriteTile((x * 16), (y * 16), 2, 30, 10);
            }
            else if (id == 0x28) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            else if (id == 0x29) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            else if (id == 0x2A) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            else if (id == 0x2B) //???
            {

                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            else if (id == 0x2C) //lumberjack
            {

                drawSpriteTile((x * 16) - 24, (y * 16) + 12, 6, 26, 12, true);//body
                drawSpriteTile((x * 16) - 24, (y * 16), 8, 26, 12, true);//head

                drawSpriteTile((x * 16) - 14, (y * 16) + 12, 14, 27, 10, false, false, 1, 1);//saw left edge
                drawSpriteTile((x * 16) - 6, (y * 16) + 12, 15, 27, 10, false, false, 1, 1);//saw left edge
                drawSpriteTile((x * 16) + 2, (y * 16) + 12, 15, 27, 10, false, false, 1, 1);//saw left edge
                drawSpriteTile((x * 16) + 10, (y * 16) + 12, 15, 27, 10, false, false, 1, 1);//saw left edge
                drawSpriteTile((x * 16) + 18, (y * 16) + 12, 15, 27, 10, false, false, 1, 1);//saw left edge
                drawSpriteTile((x * 16) + 26, (y * 16) + 12, 15, 27, 10, false, false, 1, 1);//saw left edge
                drawSpriteTile((x * 16) + 34, (y * 16) + 12, 14, 27, 10, true, false, 1, 1);//saw left edge


                drawSpriteTile((x * 16) + 40, (y * 16) + 12, 4, 26, 12);//body
                drawSpriteTile((x * 16) + 40, (y * 16), 8, 26, 12);//head
            }
            else if (id == 0x2D) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            else if (id == 0x2E) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            else if (id == 0x2F) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            else if (id == 0x30) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            else if (id == 0x31) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            else if (id == 0x32) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            /*else if (id == 0x33) //pull for rupees
            {

            }*/
            else if (id == 0x34) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            else if (id == 0x35) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            else if (id == 0x36) //npcs
            {
                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            else if (id == 0x37) //waterfall
            {
                //drawSpriteTile((x*16), (y*16), 14, 6, 10);
            }
            else if (id == 0x38) //arrowtarget
            {
                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            else if (id == 0x39) //npcs
            {
                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            else if (id == 0x3A) //npcs
            {
                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            else if (id == 0x3B) //dash item
            {
                if (room != null)
                {
                    if (room.index == 263)//library
                    {
                        drawSpriteTile((x * 16), (y * 16), 12, 18, 11); //TODO:BONK ITEM MUST BE MODIFIED TO USE ISKEY VALUE
                    }
                    else
                    {
                        drawSpriteTile((x * 16), (y * 16), 11, 06, 11, false, false, 1, 2);
                    }
                }
            }
            else if (id == 0x3C) //npcs
            {
                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            else if (id == 0x3D) //npcs
            {
                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            else if (id == 0x3E) //npcs
            {
                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            else if (id == 0x3F) //npcs
            {
                drawSpriteTile((x * 16), (y * 16), 14, 22, 10);
            }
            else if (id == 0x40) //lightning lock (agah tower)
            {
                drawSpriteTile((x * 16) - 24, (y * 16), 10, 28, 2, false, false, 1, 2);
                drawSpriteTile((x * 16) - 16, (y * 16), 6, 30, 2);
                drawSpriteTile((x * 16), (y * 16), 8, 30, 2);
                drawSpriteTile((x * 16) + 16, (y * 16), 6, 30, 2);
                drawSpriteTile((x * 16) + 24, (y * 16), 10, 28, 2, false, false, 1, 2);
            }
            else if (id == 0x41) //blue soldier
            {
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 20, 10);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 6, 20, 10, true, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 20, 10);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 13, 22, 10, false, false, 1, 2);//shield
                drawSpriteTile((x * 16) - 4, (y * 16) + 16, 14, 22, 10, false, true, 1, 2);//sword
            }
            else if (id == 0x42) //green soldier
            {
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 20, 12);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 6, 20, 12, true, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 20, 12);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 13, 22, 12, false, false, 1, 2);//shield
                drawSpriteTile((x * 16) - 4, (y * 16) + 16, 14, 22, 12, false, true, 1, 2);//sword
            }
            else if (id == 0x43) //red spear soldier
            {
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 20, 8);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 6, 20, 8, true, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 20, 8);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 13, 22, 8, false, false, 1, 2);//shield
                drawSpriteTile((x * 16) - 4, (y * 16) + 16, 11, 22, 8, false, true, 1, 2);//spear
            }
            else if (id == 0x44) //sword blue holding up
            {
                drawSpriteTile((x * 16) + 4, (y * 16) + 8, 6, 16, 10);
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 20, 10, false, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 16, 10);//head
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 14, 22, 10, false, true, 1, 2);//sword
            }
            else if (id == 0x45) //green spear soldier
            {
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 20, 12);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 6, 20, 12, true, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 20, 12);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 13, 22, 12, false, false, 1, 2);//shield
                drawSpriteTile((x * 16) - 4, (y * 16) + 16, 11, 22, 12, false, true, 1, 2);//spear
            }
            else if (id == 0x46) //blue archer
            {
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 20, 10);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 6, 20, 10, true, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 20, 10);//head
                drawSpriteTile((x * 16), (y * 16) + 16, 10, 16, 10, false, false, 1, 1);//bow1
                drawSpriteTile((x * 16) + 8, (y * 16) + 16, 10, 16, 10, true, false, 1, 1);//bow2
            }
            else if (id == 0x47) //green archer
            {
                drawSpriteTile((x * 16), (y * 16) + 8, 14, 16, 12);
                drawSpriteTile((x * 16), (y * 16), 0, 20, 12);
                drawSpriteTile((x * 16), (y * 16) + 16, 10, 16, 12, false, false, 1, 1);//bow1
                drawSpriteTile((x * 16) + 8, (y * 16) + 16, 10, 16, 12, true, false, 1, 1);//bow2

            }
            else if (id == 0x48) //javelin soldier red
            {
                drawSpriteTile((x * 16) + 4, (y * 16) + 8, 6, 16, 8);
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 20, 8, false, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 16, 8);//head
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 11, 22, 8, false, true, 1, 2);//sword

            }
            else if (id == 0x49) //javelin soldier red from bush
            {
                drawSpriteTile((x * 16) + 4, (y * 16) + 8, 6, 16, 8);
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 20, 8, false, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 18, 8);//head
                drawSpriteTile((x * 16), (y * 16) + 24, 0, 20, 2);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 11, 22, 8, false, true, 1, 2);//sword

            }
            else if (id == 0x4A) //red bomb soldier
            {
                drawSpriteTile((x * 16) + 4, (y * 16) + 8, 6, 16, 8);
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 20, 8, false, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 16, 8);//head
                drawSpriteTile((x * 16) + 8, (y * 16) - 8, 14, 22, 11);//bomb

            }
            else if (id == 0x4B) //green soldier recruit
            {//0,4
                drawSpriteTile((x * 16), (y * 16), 6, 24, 12);
                drawSpriteTile((x * 16), (y * 16) - 10, 0, 20, 12);
            }
            else if (id == 0x4C) //jazzhand
            {
                drawSpriteTile((x * 16), (y * 16), 0, 26, 14, false, false, 6, 2);
            }
            else if (id == 0x4D) //rabit??
            {
                drawSpriteTile((x * 16), (y * 16), 0, 26, 12, false, false, 6, 2);
            }
            else if (id == 0x4E) //popo1
            {
                drawSpriteTile((x * 16), (y * 16), 0, 20, 10);
            }
            else if (id == 0x4F) //popo2
            {
                drawSpriteTile((x * 16), (y * 16), 2, 20, 10);
            }
            else if (id == 0x50) //canon ball
            {
                drawSpriteTile((x * 16), (y * 16), 0, 24, 10);
            }
            else if (id == 0x51) //armos
            {
                drawSpriteTile((x * 16), (y * 16), 0, 28, 11, false, false, 2, 4);
            }
            else if (id == 0x53) //Armos Knight
            {
                drawSpriteTile((x * 16), (y * 16), 0, 28, 10, false, false, 4, 4);
            }
            else if (id == 0x54)
            {
                drawSpriteTile((x * 16), (y * 16), 2, 28, 12);
                drawSpriteTile((x * 16) + 8, (y * 16) + 10, 6, 28, 12);
                drawSpriteTile((x * 16) + 16, (y * 16) + 18, 10, 28, 12);
            }
            else if (id == 0x55) //Fireball Zora
            {
                drawSpriteTile((x * 16), (y * 16), 4, 26, 11);
            }
            else if (id == 0x56) //Zora
            {
                drawSpriteTile((x * 16), (y * 16), 10, 20, 2);
                drawSpriteTile((x * 16), (y * 16) + 8, 8, 30, 2);
            }
            else if (id == 0x57) //Desert Rocks
            {
                drawSpriteTile((x * 16), (y * 16), 14, 24, 2, false, false, 2, 4);
                drawSpriteTile((x * 16) + 16, (y * 16), 14, 24, 2, true, false, 2, 4);
            }
            else if (id == 0x58) //crab
            {
                drawSpriteTile((x * 16), (y * 16), 14, 24, 12);
                drawSpriteTile((x * 16) + 16, (y * 16), 14, 24, 12, true);
            }
            else if (id == 0x5B) //spark
            {
                drawSpriteTile((x * 16), (y * 16), 8, 18, 4);
            }
            else if (id == 0x5C) //spark
            {
                drawSpriteTile((x * 16), (y * 16), 8, 18, 4, true);
            }
            else if (id == 0x5D) //roller vertical1
            {
                //subset3
                if (((y * 16) & 0x10) == 0x10)
                {
                    drawSpriteTile((x * 16), (y * 16), 8, 24, 11);
                    for (int i = 0; i < 7; i++)
                    {
                        drawSpriteTile((x * 16) + 8 + (i * 16), (y * 16), 9, 24, 11);
                    }
                    drawSpriteTile((x * 16) + (16 * 7), (y * 16), 8, 24, 11, true);
                }
                else
                {
                    drawSpriteTile((x * 16), (y * 16), 8, 24, 11);
                    drawSpriteTile((x * 16) + 16, (y * 16), 9, 24, 11);
                    drawSpriteTile((x * 16) + 32, (y * 16), 9, 24, 11);
                    drawSpriteTile((x * 16) + 48, (y * 16), 8, 24, 11, true);

                }

            }
            else if (id == 0x5E) //roller vertical2
            {
                //subset3
                if (((y * 16) & 0x10) == 0x10)
                {
                    drawSpriteTile((x * 16), (y * 16), 8, 24, 11);
                    for (int i = 0; i < 7; i++)
                    {
                        drawSpriteTile((x * 16) + 8 + (i * 16), (y * 16), 9, 24, 11);
                    }
                    drawSpriteTile((x * 16) + (16 * 7), (y * 16), 8, 24, 11, true);
                }
                else
                {
                    drawSpriteTile((x * 16), (y * 16), 8, 24, 11);
                    drawSpriteTile((x * 16) + 16, (y * 16), 9, 24, 11);
                    drawSpriteTile((x * 16) + 32, (y * 16), 9, 24, 11);
                    drawSpriteTile((x * 16) + 48, (y * 16), 8, 24, 11, true);

                }

            }
            else if (id == 0x5F) //roller horizontal
            {
                if (((x * 16) & 0x10) == 0x10)
                {
                    drawSpriteTile((x * 16), (y * 16), 14, 24, 11);
                    drawSpriteTile((x * 16), (y * 16) + 16, 14, 25, 11);
                    drawSpriteTile((x * 16), (y * 16) + 32, 14, 25, 11);
                    drawSpriteTile((x * 16), (y * 16) + 48, 14, 24, 11, false, true);
                }
                else
                {

                    for (int i = 0; i < 7; i++)
                    {
                        drawSpriteTile((x * 16), (y * 16) + i * 16, 14, 25, 11);
                    }
                    drawSpriteTile((x * 16), (y * 16), 14, 24, 11);
                    drawSpriteTile((x * 16), (y * 16) + (7 * 16), 14, 24, 11, false, true);
                }

            }
            else if (id == 0x60) //roller horizontal2 (right to left)
            {
                //subset3
                if (((x * 16) & 0x10) == 0x10)
                {
                    drawSpriteTile((x * 16), (y * 16), 14, 24, 11);
                    drawSpriteTile((x * 16), (y * 16) + 16, 14, 25, 11);
                    drawSpriteTile((x * 16), (y * 16) + 32, 14, 25, 11);
                    drawSpriteTile((x * 16), (y * 16) + 48, 14, 24, 11, false, true);
                }
                else
                {

                    for (int i = 0; i < 7; i++)
                    {
                        drawSpriteTile((x * 16), (y * 16) + i * 16, 14, 25, 11);
                    }
                    drawSpriteTile((x * 16), (y * 16), 14, 24, 11);
                    drawSpriteTile((x * 16), (y * 16) + (7 * 16), 14, 24, 11, false, true);
                }

            }
            else if (id == 0x61) //beamos
            {
                drawSpriteTile((x * 16), (y * 16) - 16, 8, 20, 14, false, false, 2, 4);
                drawSpriteTile((x * 16) + 4, (y * 16) - 8, 10, 20, 14, false, false, 1, 1);

            }
            else if (id == 0x63) //devalant non-shooter
            {
                drawSpriteTile((x * 16) - 8, (y * 16) - 8, 2, 16, 2);
                drawSpriteTile((x * 16) + 8, (y * 16) - 8, 2, 16, 2, true);
                drawSpriteTile((x * 16) - 8, (y * 16) + 8, 2, 16, 2, false, true);
                drawSpriteTile((x * 16) + 8, (y * 16) + 8, 2, 16, 2, true, true);
                drawSpriteTile((x * 16), (y * 16), 0, 16, 10);
            }
            else if (id == 0x64) //devalant non-shooter
            {
                drawSpriteTile((x * 16) - 8, (y * 16) - 8, 2, 16, 2);
                drawSpriteTile((x * 16) + 8, (y * 16) - 8, 2, 16, 2, true);
                drawSpriteTile((x * 16) - 8, (y * 16) + 8, 2, 16, 2, false, true);
                drawSpriteTile((x * 16) + 8, (y * 16) + 8, 2, 16, 2, true, true);
                drawSpriteTile((x * 16), (y * 16), 0, 16, 8);
            }
            else if (id == 0x66) //moving wall canon right
            {
                drawSpriteTile((x * 16), (y * 16), 14, 16, 14, true);
            }
            else if (id == 0x67) //moving wall canon right
            {
                drawSpriteTile((x * 16), (y * 16), 14, 16, 14);
            }
            else if (id == 0x68) //moving wall canon right
            {
                drawSpriteTile((x * 16), (y * 16), 12, 16, 14);
            }
            else if (id == 0x69) //moving wall canon right
            {
                drawSpriteTile((x * 16), (y * 16), 12, 16, 14, false, true);
            }
            else if (id == 0x6A) //chainball soldier
            {
                drawSpriteTile((x * 16) + 4, (y * 16) + 8, 6, 16, 14);
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 20, 14, false, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 16, 14);//head
                drawSpriteTile((x * 16) + 12, (y * 16) - 16, 10, 18, 14);//ball
            }
            else if (id == 0x6B) //cannon soldier
            {
                drawSpriteTile((x * 16) + 4, (y * 16) + 8, 6, 16, 14);
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 20, 14, false, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 16, 14);//head
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 4, 18, 14);//cannon
            }
            else if (id == 0x6C) //mirror portal
            {
                //useless
            }
            else if (id == 0x6D) //rat
            {
                drawSpriteTile((x * 16), (y * 16), 14, 24, 5);
            }
            else if (id == 0x6E) //rope
            {
                drawSpriteTile((x * 16), (y * 16), 10, 26, 5);
            }
            else if (id == 0x6F)
            {
                drawSpriteTile((x * 16), (y * 16), 4, 24, 10);
            }
            else if (id == 0x70) //helma fireball
            {
                drawSpriteTile((x * 16), (y * 16), 10, 28, 4);
            }
            else if (id == 0x71) //leever
            {
                drawSpriteTile((x * 16), (y * 16), 6, 16, 4);
            }
            else if (id == 0x73) //uncle priest
            {
                if (room != null)
                {
                    if (room.index == 260)//link's house draw uncle sit
                    {

                        drawSpriteTile((x * 16) + 8, (y * 16), 6, 16, 12);
                        drawSpriteTile((x * 16) + 8, (y * 16) - 10, 0, 16, 10);
                    }
                    else if (room.index == 18)
                    {
                        drawSpriteTile((x * 16), (y * 16) + 12, 14, 16, 12);
                        drawSpriteTile((x * 16), (y * 16), 4, 18, 12);
                    }
                    else
                    {
                        drawSpriteTile((x * 16) - 8, (y * 16) - 16, 0, 18, 10);
                        drawSpriteTile((x * 16) + 8, (y * 16) - 16, 0, 18, 10, true);
                        drawSpriteTile((x * 16), (y * 16) - 26, 8, 16, 10);
                    }

                }
            }

            else if (id == 0x79) //bee
            {
                drawSpriteTile((x * 16), (y * 16), 4, 14, 11, false, false, 1, 1);
            }
            else if (id == 0x7A)
            {
                drawSpriteTile((x * 16), (y * 16) - 16, 2, 24, 12, false, false, 2, 4);
                drawSpriteTile((x * 16) + 16, (y * 16) - 16, 2, 24, 12, true, false, 2, 4);
            }
            else if (id == 0x7C) //skull head
            {
                drawSpriteTile((x * 16), (y * 16), 0, 16, 10); //
            }
            else if (id == 0x7D) //big spike
            {
                drawSpriteTile((x * 16), (y * 16), 4, 28, 11); //
                drawSpriteTile((x * 16) + 16, (y * 16), 4, 28, 11, true); //
                drawSpriteTile((x * 16), (y * 16) + 16, 4, 28, 11, false, true); //
                drawSpriteTile((x * 16) + 16, (y * 16) + 16, 4, 28, 11, true, true); //
            }
            else if (id == 0x7E) //guruguru clockwise
            {
                drawSpriteTile((x * 16), (y * 16) - 14, 8, 18, 4); //
                drawSpriteTile((x * 16), (y * 16) - 28, 8, 18, 4); //
                drawSpriteTile((x * 16), (y * 16) - 42, 8, 18, 4); //
                drawSpriteTile((x * 16), (y * 16) - 56, 8, 18, 4); //
            }
            else if (id == 0x7F) //guruguru Counterclockwise
            {
                drawSpriteTile((x * 16), (y * 16) - 14, 8, 18, 4); //
                drawSpriteTile((x * 16), (y * 16) - 28, 8, 18, 4); //
                drawSpriteTile((x * 16), (y * 16) - 42, 8, 18, 4); //
                drawSpriteTile((x * 16), (y * 16) - 56, 8, 18, 4); //
            }
            else if (id == 0x80) //winder (moving firebar)
            {
                drawSpriteTile((x * 16), (y * 16), 8, 18, 4); //
                drawSpriteTile((x * 16) - 14, (y * 16), 8, 18, 4); //
                drawSpriteTile((x * 16) - 28, (y * 16), 8, 18, 4); //
                drawSpriteTile((x * 16) - 42, (y * 16), 8, 18, 4); //
                drawSpriteTile((x * 16) - 56, (y * 16), 8, 18, 4); //
            }
            else if (id == 0x81) //water tektite
            {
                drawSpriteTile((x * 16), (y * 16), 0, 24, 11); //
            }
            else if (id == 0x82)//circle antifairy
            {
                //Antifairy top
                drawSpriteTile((x * 16 + 2) - 4, (y * 16 + 8) - 16, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16 + 8) - 4, (y * 16 + 2) - 16, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16 + 14) - 4, (y * 16 + 8) - 16, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16 + 8) - 4, (y * 16 + 14) - 16, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16 + 8) - 4, (y * 16 + 8) - 16, 1, 30, 5, false, false, 1, 1); //middle
                                                                                                   //left
                drawSpriteTile((x * 16 + 2) - 16, (y * 16 + 8) - 4, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16 + 8) - 16, (y * 16 + 2) - 4, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16 + 14) - 16, (y * 16 + 8) - 4, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16 + 8) - 16, (y * 16 + 14) - 4, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16 + 8) - 16, (y * 16 + 8) - 4, 1, 30, 5, false, false, 1, 1); //middle

                drawSpriteTile((x * 16 + 2) - 4, (y * 16 + 8) + 8, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16 + 8) - 4, (y * 16 + 2) + 8, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16 + 14) - 4, (y * 16 + 8) + 8, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16 + 8) - 4, (y * 16 + 14) + 8, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16 + 8) - 4, (y * 16 + 8) + 8, 1, 30, 5, false, false, 1, 1); //middle
                                                                                                  //left
                drawSpriteTile((x * 16 + 2) + 8, (y * 16 + 8) - 4, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16 + 8) + 8, (y * 16 + 2) - 4, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16 + 14) + 8, (y * 16 + 8) - 4, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16 + 8) + 8, (y * 16 + 14) - 4, 3, 30, 5, false, false, 1, 1);
                drawSpriteTile((x * 16 + 8) + 8, (y * 16 + 8) - 4, 1, 30, 5, false, false, 1, 1); //middle
            }
            else if (id == 0x83) //green eyegore
            {
                drawSpriteTile((x * 16), (y * 16), 12, 24, 14, false, false, 2, 3); //
                drawSpriteTile((x * 16) + 16, (y * 16), 12, 24, 14, true, false, 1, 3); //
            }
            else if (id == 0x84) //red eyegore
            {
                drawSpriteTile((x * 16), (y * 16), 12, 24, 8, false, false, 2, 3); //
                drawSpriteTile((x * 16) + 16, (y * 16), 12, 24, 8, true, false, 1, 3); //
            }
            else if (id == 0x85) //yellow stalfos
            {
                drawSpriteTile((x * 16), (y * 16), 10, 16, 11); //
                drawSpriteTile((x * 16), (y * 16) - 12, 0, 16, 11); //head
            }
            else if (id == 0x86) //kodongo
            {
                drawSpriteTile((x * 16), (y * 16), 4, 26, 14);
            }
            else if (id == 0x88) //mothula
            {
                drawSpriteTile((x * 16), (y * 16), 8, 24, 14, false, false, 2, 4);
                drawSpriteTile((x * 16) + 16, (y * 16), 8, 24, 14, true, false, 2, 4);
            }
            else if (id == 0x8A) //spike
            {
                drawSpriteTile((x * 16), (y * 16), 6, 30, 15);
            }
            else if (id == 0x8B) //gibdo
            {
                drawSpriteTile((x * 16), (y * 16), 10, 24, 14);
                drawSpriteTile((x * 16), (y * 16) - 8, 0, 24, 14);
            }
            else if (id == 0x8C) //arrghus
            {
                drawSpriteTile((x * 16), (y * 16), 0, 24, 14, false, false, 2, 4);
                drawSpriteTile((x * 16) + 16, (y * 16), 0, 24, 14, true, false, 2, 4);
            }
            else if (id == 0x8D) //arrghus spawn
            {
                drawSpriteTile((x * 16), (y * 16), 6, 24, 14);
            }
            else if (id == 0x8E) //terrorpin
            {
                drawSpriteTile((x * 16), (y * 16), 14, 24, 12);
            }
            else if (id == 0x8F) //slime
            {
                drawSpriteTile((x * 16), (y * 16), 0, 20, 12);
            }
            else if (id == 0x90) //wall master
            {
                drawSpriteTile((x * 16), (y * 16), 6, 26, 12);
                drawSpriteTile((x * 16) + 16, (y * 16), 15, 26, 12, false, false, 1, 1);
                drawSpriteTile((x * 16) + 16, (y * 16) + 8, 9, 26, 12, false, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16) + 16, 10, 27, 12, false, false, 1, 1);
                drawSpriteTile((x * 16) + 8, (y * 16) + 16, 8, 27, 12, false, false, 1, 1);
            }
            else if (id == 0x91) //stalfos knight
            {
                drawSpriteTile((x * 16) - 2, (y * 16) + 12, 4, 22, 12, false, false, 1, 2);
                drawSpriteTile((x * 16) + 10, (y * 16) + 12, 4, 22, 12, true, false, 1, 2);
                drawSpriteTile((x * 16) - 4, (y * 16) + 4, 1, 22, 12);
                drawSpriteTile((x * 16) + 12, (y * 16) + 4, 3, 22, 12, false, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16) - 8, 6, 20, 12);

            }
            else if (id == 0x92) //helmaking
            {
                drawSpriteTile((x * 16), (y * 16) + 32, 14, 26, 14);
                drawSpriteTile((x * 16) + 16, (y * 16) + 32, 0, 28, 14);
                drawSpriteTile((x * 16) + 32, (y * 16) + 32, 14, 26, 14, true);


                drawSpriteTile((x * 16), (y * 16) + 16 + 32, 2, 28, 14);
                drawSpriteTile((x * 16) + 16, (y * 16) + 16 + 32, 4, 28, 14);
                drawSpriteTile((x * 16) + 32, (y * 16) + 16 + 32, 2, 28, 14, true);

                drawSpriteTile((x * 16) + 8, (y * 16) + 32 + 32, 6, 28, 14);
                drawSpriteTile((x * 16) + 24, (y * 16) + 32 + 32, 6, 28, 14, true);
            }
            else if (id == 0x93) //bumper
            {
                drawSpriteTile((x * 16), (y * 16), 12, 30, 7);
                drawSpriteTile((x * 16) + 16, (y * 16), 12, 30, 7, true);
                drawSpriteTile((x * 16) + 16, (y * 16) + 16, 12, 30, 7, true, true);
                drawSpriteTile((x * 16), (y * 16) + 16, 12, 30, 7, false, true);
            }
            else if (id == 0x95) //right laser eye
            {
                drawSpriteTile((x * 16), (y * 16), 9, 28, 3, true, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16) + 16, 9, 28, 3, true, true, 1, 1);
            }
            else if (id == 0x96) //left laser eye
            {
                drawSpriteTile((x * 16)+8, (y * 16)-4, 9, 28, 3, false, false, 1, 2);
                drawSpriteTile((x * 16)+8, (y * 16) + 12, 9, 28, 3, false, true, 1, 1);
            }
            else if (id == 0x97) //right laser eye
            {
                drawSpriteTile((x * 16), (y * 16), 6, 28, 3, false, false, 2, 1);
                drawSpriteTile((x * 16) + 16, (y * 16), 6, 28, 3, true, false, 1, 1);
            }
            else if (id == 0x98) //right laser eye
            {
                drawSpriteTile((x * 16), (y * 16), 6, 28, 3, false, true, 2, 1);
                drawSpriteTile((x * 16) + 16, (y * 16), 6, 28, 3, true, true, 1, 1);
            }
            else if (id == 0x99)
            {
                drawSpriteTile((x * 16), (y * 16), 6, 24, 12);
                drawSpriteTile((x * 16), (y * 16) - 8, 0, 24, 12);
            }
            else if (id == 0x9A)//water bubble kyameron
            {
                drawSpriteTile((x * 16), (y * 16), 10, 24, 6);
            }
            else if (id == 0x9B)//water bubble kyameron
            {
                drawSpriteTile((x * 16), (y * 16), 6, 24, 11);
                drawSpriteTile((x * 16), (y * 16) - 8, 2, 27, 11, false, false, 2, 1);
            }
            else if (id == 0x9C)//water bubble kyameron
            {
                drawSpriteTile((x * 16), (y * 16), 12, 22, 11);
                drawSpriteTile((x * 16) + 16, (y * 16), 13, 22, 11, false, false, 1, 2);
            }
            else if (id == 0x9D)//water bubble kyameron
            {
                drawSpriteTile((x * 16), (y * 16), 14, 21, 11);
                drawSpriteTile((x * 16), (y * 16) - 16, 14, 20, 11, false, false, 2, 1);

            }
            else if (id == 0xA1)
            {
                drawSpriteTile((x * 16) - 8, (y * 16) + 8, 6, 26, 14);
                drawSpriteTile((x * 16) + 8, (y * 16) + 8, 6, 26, 14, true);
            }
            else if (id == 0xA2)
            {
                drawSpriteTile((x * 16), (y * 16) + 8, 0, 24, 14, false, false, 4, 4);
            }
            else if (id == 0xA5)
            {
                drawSpriteTile((x * 16), (y * 16), 0, 26, 10, false, false, 3, 2);
                drawSpriteTile((x * 16) + 4, (y * 16) - 8, 0, 24, 10);

            }
            else if (id == 0xA6)
            {
                drawSpriteTile((x * 16), (y * 16), 0, 26, 8, false, false, 3, 2);
                drawSpriteTile((x * 16) + 4, (y * 16) - 8, 0, 24, 8);

            }
            else if (id == 0xA7)
            {
                drawSpriteTile((x * 16), (y * 16) + 12, 12, 16, 10);
                drawSpriteTile((x * 16), (y * 16), 0, 16, 10);

            }
            else if (id == 0xAC)
            {
                drawSpriteTile((x * 16), (y * 16), 5, 14, 4);
            }
            else if (id == 0xAD)
            {
                drawSpriteTile((x * 16), (y * 16) + 8, 14, 10, 10);
                drawSpriteTile((x * 16), (y * 16), 12, 10, 10);
            }
            else if (id == 0xBA)
            {
                drawSpriteTile((x * 16), (y * 16), 14, 14, 6);
            }
            else if (id == 0xC1)
            {
                drawSpriteTile((x * 16), (y * 16) - 16, 2, 24, 12, false, false, 2, 4);
                drawSpriteTile((x * 16) + 16, (y * 16) - 16, 2, 24, 12, true, false, 2, 4);
            }
            else if (id == 0xC3)
            {
                drawSpriteTile((x * 16), (y * 16), 10, 14, 12);

            }
            else if (id == 0xC4)
            {
                drawSpriteTile((x * 16), (y * 16), 0, 18, 14);
                drawSpriteTile((x * 16), (y * 16) - 8, 0, 16, 14);
            }
            else if (id == 0xC5)
            {
                if (room == null)
                {
                    drawSpriteTile((x * 16), (y * 16), 6, 30, 7);
                }
                else
                {
                    drawSpriteTile((x * 16)+10, (y * 16)+10, 13, 9, 8, false, false, 1, 1);
                    drawSpriteTile((x * 16)+6, (y * 16)+6, 13, 8, 8,false,false,1,1);
                }
            }
            else if (id == 0xC6)
            {
                drawSpriteTile((x * 16)+4, (y * 16) + 14, 3, 30, 14,false,false,1,1);
                drawSpriteTile((x * 16) + 14, (y * 16)+4, 3, 30, 14, false, false, 1, 1);
                drawSpriteTile((x * 16)+4, (y * 16)+2, 1, 31, 14, false, false, 1, 1);
                drawSpriteTile((x * 16) - 6, (y * 16)+4, 3, 30, 14, false, false, 1, 1);
                drawSpriteTile((x * 16)+4, (y * 16) - 6, 3, 30, 14, false, false, 1, 1);
            }
            else if (id == 0xC7)
            {
                drawSpriteTile((x * 16), (y * 16), 0, 26, 4);
                drawSpriteTile((x * 16), (y * 16) - 10, 0, 26, 4);
                drawSpriteTile((x * 16), (y * 16) - 20, 0, 26, 4);
                drawSpriteTile((x * 16), (y * 16) - 30, 2, 26, 4);
            }
            else if (id == 0xC8)
            {
                drawSpriteTile((x * 16), (y * 16), 12, 24, 12, false, false, 2, 3);
                drawSpriteTile((x * 16) + 16, (y * 16), 12, 24, 12, true, false, 1, 3);
            }
            else if (id == 0xC9)
            {
                drawSpriteTile((x * 16), (y * 16), 8, 28, 8,false);
                drawSpriteTile((x * 16)+16, (y * 16), 8, 28, 8, true);
            }
            else if (id == 0xCA)
            {
                drawSpriteTile((x * 16), (y * 16), 8, 10, 10);

            }
            else if (id == 0xD0)
            {

                drawSpriteTile((x * 16), (y * 16), 7, 14, 11, false, false, 3, 2);
                drawSpriteTile((x * 16), (y * 16) - 10, 8, 12, 11);
            }
            else if (id == 0xD1)
            {
                drawSpriteTile((x * 16) + 2, (y * 16) + 8, 7, 13, 11, true, true, 1, 1);
                drawSpriteTile((x * 16) + 8, (y * 16) + 2, 7, 13, 11, true, false, 1, 1);
                drawSpriteTile((x * 16) + 14, (y * 16) + 8, 7, 13, 11, true, true, 1, 1);
                drawSpriteTile((x * 16) + 8, (y * 16) + 14, 7, 13, 11, false, true, 1, 1);
                drawSpriteTile((x * 16) + 8, (y * 16) + 8, 7, 13, 11, false, false, 1, 1); //middle
                //6,7 / 13
            }
            else if (id == 0xD4)
            {

                drawSpriteTile((x * 16)-4, (y * 16), 0, 7, 7, false, false, 1, 1);
                drawSpriteTile((x * 16)+4, (y * 16), 0, 7, 7,true,false,1,1);
            }
            else if (id == 0xE3) //fairy
            {
                drawSpriteTile((x * 16), (y * 16), 10, 14, 10);
            }
            else if (id == 0xE4)//key
            {
                drawSpriteTile((x * 16), (y * 16), 11, 06, 11, false, false, 1, 2);
            }
            else if (id == 0xE7)//mushroom
            {
                drawSpriteTile((x * 16), (y * 16), 14, 30, 16);
            }
            else if (id == 0xE8)//fake ms
            {
                drawSpriteTile((x * 16) + 4, (y * 16), 4, 31, 10, false, false, 1, 1);
                drawSpriteTile((x * 16) + 4, (y * 16) + 8, 5, 31, 10, false, false, 1, 1);
            }
            else if (id == 0xEB)
            {
                drawSpriteTile((x * 16), (y * 16), 0, 14, 5);
            }
            else if (id == 0xF2)
            {
                drawSpriteTile((x * 16), (y * 16) - 16, 12, 24, 2, false, false, 2, 4);
                drawSpriteTile((x * 16) + 16, (y * 16) - 16, 12, 24, 2, true, false, 2, 4);
            }
            else if (id == 0xF4)
            {
                drawSpriteTile((x * 16), (y * 16), 12, 28, 5, false, false, 4, 4);
            }
            else
            {
                //stringtodraw.Add(new SpriteName(x, (y*16), sprites_name.name[id]));
                drawSpriteTile((x * 16), (y * 16), 4, 4, 5);
            }

                boundingbox = new Rectangle((lowerX + (x * 16)), (lowerY + (y * 16)), width, height);
        }

        public void update()
        {

        }

        int lowerX = 32;
        int lowerY = 32;
        int higherX = 0;
        int higherY = 0;
        int width = 16;
        int height = 16;
        public unsafe void drawSpriteTile(int x, int y, int srcx, int srcy, int pal, bool mirror_x = false, bool mirror_y = false, int sizex = 2, int sizey = 2, bool iskey = false)
        {
            var alltilesData = (byte*)GFX.currentgfx16Ptr.ToPointer();
            

            if (preview)
            {
                byte* ptr = (byte*)GFX.previewSpritesPtr[id].ToPointer();
                x += 16;
                y += 16;
                int drawid = (srcx + (srcy * 16)) + 512;
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
                        if (index >= 0 && index <= 4096)
                        {
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
            else
            {
                int subx = 0;
                int suby = 0;
                byte* ptr = (byte*)GFX.roomBg1Ptr.ToPointer();


                if (iskey == false)
                {
                    if (lowerX > (x - (this.nx * 16)))
                    {
                        lowerX = (x - (this.nx * 16));
                    }
                    if (lowerY > (y - (this.ny * 16)))
                    {
                        lowerY = (y - (this.ny * 16));
                    }
                    if (higherX < x + (sizex * 8) - (this.nx * 16))
                    {
                        higherX = x + (sizex * 8) - (this.nx * 16);
                    }
                    if (higherY < y + (sizey * 8) - (this.ny * 16))
                    {
                        higherY = y + (sizey * 8) - (this.ny * 16);
                    }
                    width = (higherX - lowerX);
                    height = (higherY - lowerY);
                }
                int drawid = (srcx + (srcy * 16)) + 512;
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
                        int index = ((x+subx)) + ((y+suby) * 512) + ((mx * 2) + (my * (512)));
                        if (index >= 0 && index <= 262144)
                        {
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


            public unsafe void draw_item_tile(int x, int y, int srcx, int srcy, int pal, bool mirror_x = false, bool mirror_y = false, int sizex = 2, int sizey = 2)
            {
                var alltilesData = (byte*)GFX.allgfx16Ptr.ToPointer();
                byte* ptr = (byte*)GFX.roomBg1Ptr.ToPointer();

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



        public void updateMapStuff(short mapId)
        {
            this.mapid = (byte)mapId;
            if (mapId >= 64)
            {
                mapId -= 64;
            }

            int mx = (mapId - ((mapId / 8) * 8));
            int my = ((mapId / 8));

            x = (byte)((map_x - (mx * 512)) / 16);
            y = (byte)((map_y - (my * 512)) / 16);


            //Console.WriteLine("X:{0} Y:{1}", gameX, gameY);

        }

    }
}