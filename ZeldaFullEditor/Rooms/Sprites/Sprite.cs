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
        Room room;
        public Rectangle boundingbox;
        bool picker = false;
        public bool selected = false;
        public Sprite(Room room, byte id, byte x, byte y, string name, byte overlord, byte subtype, byte layer)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.name = name;
            this.room = room;
            this.overlord = overlord;
            this.subtype = subtype;
            this.layer = layer;
            this.nx = x;
            this.ny = y;
        }

        public void updateBBox()
        {
            lowerX = 1;
            lowerY = 1;
            higherX = 15;
            higherY = 15;
        }
        
        public void DrawKey()
        {
            int dx = (boundingbox.X + boundingbox.Width/2)-4;
            int dy = boundingbox.Y-10;
            drawSpriteTile(dx, dy, 11, 22, 11, false, false, 1, 2, true);
        }


        public void Draw(bool picker = false)
        {
            this.picker = picker;
            if (overlord == 0x07)
            {
                if (id == 0x1A)
                {
                    drawSpriteTile((x * 16) , (y * 16), 14, 22, 11);//bomb
                }
                return;
            }

            if (id == 0x00)
            {
                drawSpriteTile((x * 16), (y * 16), 4, 14, 10);
            }
            else if (id == 0x01)
            {
                drawSpriteTile((x * 16), (y * 16), 4, 9, 10, false, false, 1, 4);
                drawSpriteTile((x * 16) + 8, (y * 16), 4, 9, 10, true, false, 1, 4);
            }
            else if (id == 0x02)
            {
                drawSpriteTile((x * 16), (y * 16), 0, 0, 10);
            }
            else if (id == 0x04)
            {
                byte p = 3;
                if (room.blocks[13] == 83) { p = 15; };
                drawSpriteTile((x * 16), (y * 16), 14, 12, p);//TODO: Change palette
                drawSpriteTile((x * 16), (y * 16), 14, 14, p);//TODO: Change palette
            }
            else if (id == 0x05)
            {
                byte p = 3;
                if (room.blocks[13] == 83) { p = 15; };
                drawSpriteTile((x * 16), (y * 16), 14, 12, p);//TODO: Change palette
                drawSpriteTile((x * 16), (y * 16), 14, 14, p);//TODO: Change palette
            }
            else if (id == 0x06)
            {
                byte p = 3;
                if (room.blocks[13] == 83) { p = 15; };
                drawSpriteTile((x * 16), (y * 16), 14, 12, p);//TODO: Change palette
                drawSpriteTile((x * 16), (y * 16), 14, 14, p);//TODO: Change palette
            }
            else if (id == 0x07)
            {
                byte p = 3;
                if (room.blocks[13] == 83) { p = 15; };
                drawSpriteTile((x * 16), (y * 16), 14, 12, p);//TODO: Change palette
                drawSpriteTile((x * 16), (y * 16), 14, 14, p);//TODO: Change palette
            }
            else if (id == 0x08)
            {
                drawSpriteTile((x * 16), (y * 16), 0, 8, 6);
                drawSpriteTile((x * 16) + 4, (y * 16) + 6, 0, 8, 6, false, false, 1, 1);
            }
            else if (id == 0x0A)
            {
                drawSpriteTile((x * 16), (y * 16), 0, 8, 6);
                drawSpriteTile((x * 16) + 4, (y * 16) + 6, 0, 8, 6, false, false, 1, 1);
            }
            else if (id == 0x0B)
            {
                drawSpriteTile((x * 16), (y * 16), 10, 14, 10);
            }
            else if (id == 0x0C)
            {
                drawSpriteTile((x * 16), (y * 16), 0, 8, 8);
                drawSpriteTile((x * 16) + 4, (y * 16) + 6, 0, 8, 8, false, false, 1, 1);
            }
            else if (id == 0x0D)
            {
                drawSpriteTile((x * 16), (y * 16), 14, 12, 6);
            }
            else if (id == 0x0E)
            {
                drawSpriteTile((x * 16), (y * 16), 8, 2, 10, false, false, 3, 2);
            }
            else if (id == 0x0F)
            {
                drawSpriteTile((x * 16), (y * 16), 14, 8, 8, false, false, 2, 3);
                drawSpriteTile((x * 16) + 16, (y * 16), 14, 8, 8, true, false, 1, 3);
            }
            else if (id == 0x10)
            {
                drawSpriteTile((x * 16), (y * 16), 12, 15, 8, false, false, 1, 1);
            }
            else if (id == 0x11)
            {
                drawSpriteTile((x * 16), (y * 16) + 16, 6, 0, 8, false, false, 2, 2); //feet
                drawSpriteTile((x * 16) - 8, (y * 16) + 8, 4, 2, 8, false, false, 2, 2); //body1
                drawSpriteTile((x * 16) + 8, (y * 16) + 8, 4, 2, 8, true, false, 2, 2); //body2
                drawSpriteTile((x * 16), (y * 16), 0, 0, 8, false, false, 2, 2); //head
            }
            else if (id == 0x12)
            {
                drawSpriteTile((x * 16), (y * 16) + 8, 8, 10, 8);
                drawSpriteTile((x * 16), (y * 16), 6, 8, 8);
            }
            else if (id == 0x13)
            {
                drawSpriteTile((x * 16), (y * 16), 4, 6, 2);
            }
            else if (id == 0x15)
            {
                //Antifairy
                drawSpriteTile((x * 16) + 2, (y * 16) + 8, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x * 16) + 8, (y * 16) + 2, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x * 16) + 14, (y * 16) + 8, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x * 16) + 8, (y * 16) + 14, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x * 16) + 8, (y * 16) + 8, 1, 14, 5, false, false, 1, 1); //middle
            }
            else if (id == 0x16)
            {
                drawSpriteTile((x * 16), (y * 16) + 8, 2, 10, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 10, 2);
            }
            else if (id == 0x17) //bush hoarder
            {
                drawSpriteTile((x * 16), (y * 16), 8, 14, 10);
            }
            else if (id == 0x18) //mini moldorm
            {
                drawSpriteTile((x * 16) + 13, (y * 16) + 17, 13, 5, 8, false, false, 1, 1); //tail
                drawSpriteTile((x * 16) + 5, (y * 16) + 8, 2, 6, 8); //body
                drawSpriteTile((x * 16), (y * 16), 0, 6, 8); //head
                drawSpriteTile((x * 16), (y * 16) - 4, 13, 4, 8, false, false, 1, 1); //eyes
                drawSpriteTile((x * 16) - 4, (y * 16), 13, 4, 8, false, false, 1, 1); //eyes
            }
            else if (id == 0x19) //poe - ghost
            {
                drawSpriteTile((x * 16), (y * 16), 6, 15, 2); //
            }
            else if (id == 0x1A) //smith
            {
                //drawSpriteTile((x*16), (y*16), 2, 4, 10,true); //smitty
                //drawSpriteTile((x*16)+12, (y*16) - 7, 0, 6, 10); //hammer
                drawSpriteTile((x * 16), (y * 16), 4, 6, 10);
            }
            else if (id == 0x1C) //Statue
            {
                drawSpriteTile((x * 16), (y * 16) + 8, 0, 12, 15); //TODO : FIND PALETTE
                drawSpriteTile((x * 16), (y * 16), 2, 12, 15, false, false, 1, 1);
                drawSpriteTile((x * 16) + 8, (y * 16), 2, 12, 15, true, false, 1, 1);
            }
            else if (id == 0x1E) //crystal switch
            {
                drawSpriteTile((x * 16), (y * 16), 4, 14, 5);
            }
            else if (id == 0x1F) //sick kid
            {
                drawSpriteTile((x * 16) - 8, (y * 16) + 8, 10, 0, 14);
                drawSpriteTile((x * 16) + 16 - 8, (y * 16) + 8, 10, 0, 14, true);
                drawSpriteTile((x * 16) - 8, (y * 16) + 16, 10, 0, 14, false, true, 2, 2);
                drawSpriteTile((x * 16) + 16 - 8, (y * 16) + 16, 10, 0, 14, true, true, 2, 2);
                drawSpriteTile((x * 16), (y * 16) - 4, 14, 0, 10);
            }
            else if (id == 0x20)
            {
                drawSpriteTile((x * 16), (y * 16), 2, 8, 7);
            }
            else if (id == 0x21) //push switch
            {
                drawSpriteTile((x * 16) + 4, (y * 16) + 20, 13, 13, 3, false, false, 1, 1);
                drawSpriteTile((x * 16) + 4, (y * 16) + 28, 12, 13, 3, false, false, 1, 1);
                drawSpriteTile((x * 16), (y * 16) + 8, 10, 12, 3);
            }
            else if (id == 0x22) //rope
            {

                drawSpriteTile((x * 16), (y * 16), 8, 10, 5);
            }
            else if (id == 0x23) //red bari
            {
                drawSpriteTile((x * 16), (y * 16), 2, 2, 4, false, false, 1, 2);
                drawSpriteTile((x * 16) + 8, (y * 16), 2, 2, 4, true, false, 1, 2);
            }
            else if (id == 0x24) //blue bari
            {
                drawSpriteTile((x * 16), (y * 16), 2, 2, 6, false, false, 1, 2);
                drawSpriteTile((x * 16) + 8, (y * 16), 2, 2, 6, true, false, 1, 2);
            }
            else if (id == 0x25) //red bari
            {

            }
            else if (id == 0x26) //hardhat beetle
            {
                if ((x & 0x01) == 0x00)
                {
                    drawSpriteTile((x * 16), (y * 16), 4, 4, 8);
                    drawSpriteTile((x * 16), (y * 16) - 6, 0, 4, 8);
                }
                else
                {
                    drawSpriteTile((x * 16), (y * 16), 4, 4, 10);
                    drawSpriteTile((x * 16), (y * 16) - 6, 0, 4, 10);
                }

            }
            else if (id == 0x27) //deadrock
            {

                drawSpriteTile((x * 16), (y * 16), 2, 14, 10);
            }
            else if (id == 0x28) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x29) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x2A) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x2B) //???
            {

                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x2C) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x2D) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x2E) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x2F) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x30) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x31) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x32) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x33) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x34) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x35) //npcs
            {

                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x36) //npcs
            {
                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x37) //waterfall
            {
                //drawSpriteTile((x*16), (y*16), 14, 6, 10);
            }
            else if (id == 0x38) //npcs
            {
                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x39) //npcs
            {
                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x3A) //npcs
            {
                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x3B) //dash item
            {
                if (room.index == 263)//library
                {
                    drawSpriteTile((x * 16), (y * 16), 12, 2 + 32, 11); //book
                }
                else
                {
                    drawSpriteTile((x * 16), (y * 16), 14, 2 + 32, 11, false, false, 1, 2); //key
                }
            }
            else if (id == 0x3C) //npcs
            {
                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x3D) //npcs
            {
                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x3E) //npcs
            {
                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x3F) //npcs
            {
                drawSpriteTile((x * 16), (y * 16), 14, 6, 10);
            }
            else if (id == 0x40) //npcs
            {
                drawSpriteTile((x * 16) - 24, (y * 16), 10, 12, 2, false, false, 1, 2);
                drawSpriteTile((x * 16) - 16, (y * 16), 6, 14, 2);
                drawSpriteTile((x * 16), (y * 16), 8, 14, 2);
                drawSpriteTile((x * 16) + 16, (y * 16), 6, 14, 2);
                drawSpriteTile((x * 16) + 24, (y * 16), 10, 12, 2, false, false, 1, 2);
            }
            else if (id == 0x41) //blue soldier
            {
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 4, 10);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 6, 4, 10, true, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 4, 10);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 13, 6, 10, false, false, 1, 2);//shield
                drawSpriteTile((x * 16) - 4, (y * 16) + 16, 14, 6, 10, false, true, 1, 2);//sword
            }
            else if (id == 0x42) //green soldier
            {
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 4, 12);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 6, 4, 12, true, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 4, 12);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 13, 6, 12, false, false, 1, 2);//shield
                drawSpriteTile((x * 16) - 4, (y * 16) + 16, 14, 6, 12, false, true, 1, 2);//sword
            }
            else if (id == 0x43) //red spear soldier
            {
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 4, 8);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 6, 4, 8, true, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 4, 8);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 13, 6, 8, false, false, 1, 2);//shield
                drawSpriteTile((x * 16) - 4, (y * 16) + 16, 11, 6, 8, false, true, 1, 2);//spear
            }
            else if (id == 0x44) //sword blue holding up
            {
                drawSpriteTile((x * 16) + 4, (y * 16) + 8, 6, 0, 10);
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 4, 10, false, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 0, 10);//head
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 14, 6, 10, false, true, 1, 2);//sword
            }
            else if (id == 0x45) //green spear soldier
            {
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 4, 12);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 6, 4, 12, true, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 4, 12);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 13, 6, 12, false, false, 1, 2);//shield
                drawSpriteTile((x * 16) - 4, (y * 16) + 16, 11, 6, 12, false, true, 1, 2);//spear
            }
            else if (id == 0x46) //blue archer
            {
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 4, 10);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 6, 4, 10, true, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 2, 10);
                drawSpriteTile((x * 16), (y * 16) + 16, 10, 0, 10, false, false, 1, 1);//bow1
                drawSpriteTile((x * 16) + 8, (y * 16) + 16, 10, 0, 10, true, false, 1, 1);//bow2
            }
            else if (id == 0x47) //green archer
            {
                drawSpriteTile((x * 16), (y * 16) + 8, 14, 0, 12);
                drawSpriteTile((x * 16), (y * 16), 0, 4, 12);
                drawSpriteTile((x * 16), (y * 16) + 16, 10, 0, 12, false, false, 1, 1);//bow1
                drawSpriteTile((x * 16) + 8, (y * 16) + 16, 10, 0, 12, true, false, 1, 1);//bow2

            }
            else if (id == 0x48) //javelin soldier red
            {
                drawSpriteTile((x * 16) + 4, (y * 16) + 8, 6, 0, 8);
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 4, 8, false, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 0, 8);//head
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 11, 6, 8, false, true, 1, 2);//sword

            }
            else if (id == 0x49) //javelin soldier red from bush
            {
                drawSpriteTile((x * 16) + 4, (y * 16) + 8, 6, 0, 8);
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 4, 8, false, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 2, 8);//head
                drawSpriteTile((x * 16), (y * 16) + 24, 0, 4, 2);
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 11, 6, 8, false, true, 1, 2);//sword

            }
            else if (id == 0x4A) //red bomb soldier
            {
                drawSpriteTile((x * 16) + 4, (y * 16) + 8, 6, 0, 8);
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 4, 8, false, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 0, 8);//head
                drawSpriteTile((x * 16) + 8, (y * 16) - 8, 14, 6, 11);//bomb

            }
            else if (id == 0x4B) //green soldier recruit
            {//0,4
                drawSpriteTile((x * 16), (y * 16), 6, 8, 12);
                drawSpriteTile((x * 16), (y * 16) - 10, 0, 4, 12);
            }
            else if (id == 0x4C) //jazzhand
            {
                drawSpriteTile((x * 16), (y * 16), 0, 10, 12, false, false, 6, 2);
            }
            else if (id == 0x4D) //rabit??
            {
                drawSpriteTile((x * 16), (y * 16), 0, 10, 12, false, false, 6, 2);
            }
            else if (id == 0x4E) //popo1
            {
                drawSpriteTile((x * 16), (y * 16), 0, 4, 10);
            }
            else if (id == 0x4F) //popo2
            {
                drawSpriteTile((x * 16), (y * 16), 2, 4, 10);
            }
            else if (id == 0x50) //canon ball
            {
                drawSpriteTile((x * 16), (y * 16), 0, 8, 10);
            }
            else if (id == 0x51) //armos
            {
                drawSpriteTile((x * 16), (y * 16), 0, 12, 11, false, false, 2, 4);
            }
            else if (id == 0x53) //Armos Knight
            {
                drawSpriteTile((x * 16), (y * 16), 0, 12, 10, false, false, 4, 4);
            }
            else if (id == 0x55) //Fireball Zora
            {
                drawSpriteTile((x * 16), (y * 16), 10, 4, 2);
            }
            else if (id == 0x56) //Zora
            {
                drawSpriteTile((x * 16), (y * 16), 10, 4, 2);
                drawSpriteTile((x * 16), (y * 16) + 8, 8, 14, 2);
            }
            else if (id == 0x58) //crab
            {
                drawSpriteTile((x * 16), (y * 16), 14, 8, 12);
                drawSpriteTile((x * 16) + 16, (y * 16), 8, 14, 12, true);
            }
            else if (id == 0x5B) //spark
            {
                drawSpriteTile((x * 16), (y * 16), 8, 2, 4);
            }
            else if (id == 0x5C) //spark
            {
                drawSpriteTile((x * 16), (y * 16), 8, 2, 4, true);
            }
            else if (id == 0x5D) //roller vertical1
            {
                //subset3
                if (((y * 16) & 0x10) == 0x10)
                {
                    drawSpriteTile((x * 16), (y * 16), 8, 8, 11);
                    for (int i = 0; i < 7; i++)
                    {
                        drawSpriteTile((x * 16) + 8 + (i * 16), (y * 16), 9, 8, 11);
                    }
                    drawSpriteTile((x * 16) + (16 * 7), (y * 16), 8, 8, 11, true);
                }
                else
                {
                    drawSpriteTile((x * 16), (y * 16), 8, 8, 11);
                    drawSpriteTile((x * 16) + 16, (y * 16), 9, 8, 11);
                    drawSpriteTile((x * 16) + 32, (y * 16), 9, 8, 11);
                    drawSpriteTile((x * 16) + 48, (y * 16), 8, 8, 11, true);

                }

            }
            else if (id == 0x5E) //roller vertical2
            {
                //subset3
                if (((y * 16) & 0x10) == 0x10)
                {
                    drawSpriteTile((x * 16), (y * 16), 8, 8, 11);
                    for (int i = 0; i < 7; i++)
                    {
                        drawSpriteTile((x * 16) + 8 + (i * 16), (y * 16), 9, 8, 11);
                    }
                    drawSpriteTile((x * 16) + (16 * 7), (y * 16), 8, 8, 11, true);
                }
                else
                {
                    drawSpriteTile((x * 16), (y * 16), 8, 8, 11);
                    drawSpriteTile((x * 16) + 16, (y * 16), 9, 8, 11);
                    drawSpriteTile((x * 16) + 32, (y * 16), 9, 8, 11);
                    drawSpriteTile((x * 16) + 48, (y * 16), 8, 8, 11, true);

                }

            }
            else if (id == 0x5F) //roller horizontal
            {
                if (((x * 16) & 0x10) == 0x10)
                {
                    drawSpriteTile((x * 16), (y * 16), 14, 8, 11);
                    drawSpriteTile((x * 16), (y * 16) + 16, 14, 9, 11);
                    drawSpriteTile((x * 16), (y * 16) + 32, 14, 9, 11);
                    drawSpriteTile((x * 16), (y * 16) + 48, 14, 8, 11, false, true);
                }
                else
                {
                    
                    for (int i = 0; i < 7; i++)
                    {
                        drawSpriteTile((x * 16), (y * 16) + i * 16, 14, 9, 11);
                    }
                    drawSpriteTile((x * 16), (y * 16), 14, 8, 11);
                    drawSpriteTile((x * 16), (y * 16) + (7*16), 14, 8, 11, false, true);
                }

            }
            else if (id == 0x60) //roller horizontal2 (right to left)
            {
                //subset3
                if (((x * 16) & 0x10) ==  0x10)
                {
                    drawSpriteTile((x * 16), (y * 16), 14, 8, 11);
                    drawSpriteTile((x * 16), (y * 16) + 16, 14, 9, 11);
                    drawSpriteTile((x * 16), (y * 16) + 32, 14, 9, 11);
                    drawSpriteTile((x * 16), (y * 16) + 48, 14, 8, 11, false, true);
                }
                else
                {

                    for (int i = 0; i < 7; i++)
                    {
                        drawSpriteTile((x * 16), (y * 16) + i * 16, 14, 9, 11);
                    }
                    drawSpriteTile((x * 16), (y * 16), 14, 8, 11);
                    drawSpriteTile((x * 16), (y * 16) + (7 * 16), 14, 8, 11, false, true);
                }

            }
            else if (id == 0x61) //beamos
            {
                drawSpriteTile((x * 16), (y * 16) - 16, 8, 4, 14, false, false, 2, 4);
                drawSpriteTile((x * 16) + 4, (y * 16) - 8, 10, 4, 14, false, false, 1, 1);

            }
            else if (id == 0x63) //devalant non-shooter
            {
                drawSpriteTile((x * 16) - 8, (y * 16) - 8, 2, 0, 2);
                drawSpriteTile((x * 16) + 8, (y * 16) - 8, 2, 0, 2, true);
                drawSpriteTile((x * 16) - 8, (y * 16) + 8, 2, 0, 2, false, true);
                drawSpriteTile((x * 16) + 8, (y * 16) + 8, 2, 0, 2, true, true);
                drawSpriteTile((x * 16), (y * 16), 0, 0, 10);
            }
            else if (id == 0x64) //devalant non-shooter
            {
                drawSpriteTile((x * 16) - 8, (y * 16) - 8, 2, 0, 2);
                drawSpriteTile((x * 16) + 8, (y * 16) - 8, 2, 0, 2, true);
                drawSpriteTile((x * 16) - 8, (y * 16) + 8, 2, 0, 2, false, true);
                drawSpriteTile((x * 16) + 8, (y * 16) + 8, 2, 0, 2, true, true);
                drawSpriteTile((x * 16), (y * 16), 0, 0, 8);
            }
            else if (id == 0x66) //moving wall canon right
            {
                drawSpriteTile((x * 16), (y * 16), 14, 0, 14, true);
            }
            else if (id == 0x67) //moving wall canon right
            {
                drawSpriteTile((x * 16), (y * 16), 14, 0, 14);
            }
            else if (id == 0x68) //moving wall canon right
            {
                drawSpriteTile((x * 16), (y * 16), 12, 0, 14);
            }
            else if (id == 0x69) //moving wall canon right
            {
                drawSpriteTile((x * 16), (y * 16), 12, 0, 14, false, true);
            }
            else if (id == 0x6A) //chainball soldier
            {
                drawSpriteTile((x * 16) + 4, (y * 16) + 8, 6, 0, 14);
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 4, 14, false, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 0, 14);//head
                drawSpriteTile((x * 16) + 12, (y * 16) - 16, 10, 2, 14);//ball
            }
            else if (id == 0x6B) //cannon soldier
            {
                drawSpriteTile((x * 16) + 4, (y * 16) + 8, 6, 0, 14);
                drawSpriteTile((x * 16) - 4, (y * 16) + 8, 6, 4, 14, false, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16), 0, 0, 14);//head
                drawSpriteTile((x * 16) + 12, (y * 16) + 8, 4, 2, 14);//cannon
            }
            else if (id == 0x6C) //mirror portal
            {
                //useless
            }
            else if (id == 0x6D) //rat
            {
                drawSpriteTile((x * 16), (y * 16), 14, 8, 5);
            }
            else if (id == 0x6E) //rope
            {
                drawSpriteTile((x * 16), (y * 16), 10, 10, 5);
            }
            else if (id == 0x6F)
            {
                drawSpriteTile((x * 16), (y * 16), 4, 8, 10);
            }
            else if (id == 0x70) //helma fireball
            {
                drawSpriteTile((x * 16), (y * 16), 10, 12, 4);
            }
            else if (id == 0x71) //leever
            {
                drawSpriteTile((x * 16), (y * 16), 6, 0, 4);
            }
            else if (id == 0x73) //uncle priest
            {
                if (room.index == 260)//link's house draw uncle sit
                {

                    drawSpriteTile((x * 16) + 8, (y * 16), 6, 0,12);
                    drawSpriteTile((x * 16) + 8, (y * 16) - 10, 0, 0, 10);
                }
                else if (room.index == 85)
                {
                    drawSpriteTile((x * 16) - 8, (y * 16) - 16, 0, 2, 10);
                    drawSpriteTile((x * 16) + 8, (y * 16) - 16, 0, 2, 10, true);
                    drawSpriteTile((x * 16), (y * 16) - 26, 8, 0, 10);
                }
            }
            else if (id == 0x7A)
            {
                drawSpriteTile((x * 16), (y * 16) - 16, 2, 8, 12, false, false, 2, 4);
                drawSpriteTile((x * 16) + 16, (y * 16) - 16, 2, 8, 12, true, false, 2, 4);
            }
            else if (id == 0x7C) //skull head
            {
                drawSpriteTile((x * 16), (y * 16), 0, 0, 10); //
            }
            else if (id == 0x7D) //big spike
            {
                drawSpriteTile((x * 16), (y * 16), 4, 12, 11); //
                drawSpriteTile((x * 16) + 16, (y * 16), 4, 12, 11, true); //
                drawSpriteTile((x * 16), (y * 16) + 16, 4, 12, 11, false, true); //
                drawSpriteTile((x * 16) + 16, (y * 16) + 16, 4, 12, 11, true, true); //
            }
            else if (id == 0x7E) //guruguru clockwise
            {
                drawSpriteTile((x * 16), (y * 16) - 14, 8, 2, 4); //
                drawSpriteTile((x * 16), (y * 16) - 28, 8, 2, 4); //
                drawSpriteTile((x * 16), (y * 16) - 42, 8, 2, 4); //
                drawSpriteTile((x * 16), (y * 16) - 56, 8, 2, 4); //
            }
            else if (id == 0x7F) //guruguru Counterclockwise
            {
                drawSpriteTile((x * 16), (y * 16) - 14, 8, 2, 4); //
                drawSpriteTile((x * 16), (y * 16) - 28, 8, 2, 4); //
                drawSpriteTile((x * 16), (y * 16) - 42, 8, 2, 4); //
                drawSpriteTile((x * 16), (y * 16) - 56, 8, 2, 4); //
            }
            else if (id == 0x80) //winder (moving firebar)
            {
                drawSpriteTile((x * 16), (y * 16), 8, 2, 4); //
                drawSpriteTile((x * 16) - 14, (y * 16), 8, 2, 4); //
                drawSpriteTile((x * 16) - 28, (y * 16), 8, 2, 4); //
                drawSpriteTile((x * 16) - 42, (y * 16), 8, 2, 4); //
                drawSpriteTile((x * 16) - 56, (y * 16), 8, 2, 4); //
            }
            else if (id == 0x81) //water tektite
            {
                drawSpriteTile((x * 16), (y * 16), 0, 8, 11); //
            }
            else if (id == 0x82)//circle antifairy
            {
                //Antifairy top
                drawSpriteTile((x*16 + 2) - 4, (y*16 + 8) - 16, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x*16 + 8) - 4, (y*16 + 2) - 16, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x*16 + 14) - 4, (y*16 + 8) - 16, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x*16 + 8) - 4, (y*16 + 14) - 16, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x*16 + 8) - 4, (y*16 + 8) - 16, 1, 14, 5, false, false, 1, 1); //middle
                                                                                         //left
                drawSpriteTile((x*16 + 2) - 16, (y*16 + 8) - 4, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x*16 + 8) - 16, (y*16 + 2) - 4, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x*16 + 14) - 16, (y*16 + 8) - 4, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x*16 + 8) - 16, (y*16 + 14) - 4, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x*16 + 8) - 16, (y*16 + 8) - 4, 1, 14, 5, false, false, 1, 1); //middle

                drawSpriteTile((x*16 + 2) - 4, (y*16 + 8) + 8, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x*16 + 8) - 4, (y*16 + 2) + 8, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x*16 + 14) - 4, (y*16 + 8) + 8, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x*16 + 8) - 4, (y*16 + 14) + 8, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x*16 + 8) - 4, (y*16 + 8) + 8, 1, 14, 5, false, false, 1, 1); //middle
                                                                                        //left
                drawSpriteTile((x*16 + 2) + 8, (y*16 + 8) - 4, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x*16 + 8) + 8, (y*16 + 2) - 4, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x*16 + 14) + 8, (y*16 + 8) - 4, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x*16 + 8) + 8, (y*16 + 14) - 4, 3, 14, 5, false, false, 1, 1);
                drawSpriteTile((x*16 + 8) + 8, (y*16 + 8) - 4, 1, 14, 5, false, false, 1, 1); //middle
            }
            else if (id == 0x83) //green eyegore
            {
                drawSpriteTile((x * 16), (y * 16), 12, 8, 14, false, false, 2, 3); //
                drawSpriteTile((x * 16) + 16, (y * 16), 12, 8, 14, true, false, 1, 3); //
            }
            else if (id == 0x84) //red eyegore
            {
                drawSpriteTile((x * 16), (y * 16), 12, 8, 8, false, false, 2, 3); //
                drawSpriteTile((x * 16) + 16, (y * 16), 12, 8, 8, true, false, 1, 3); //
            }
            else if (id == 0x85) //yellow stalfos
            {
                drawSpriteTile((x * 16), (y * 16), 10, 0, 11); //
                drawSpriteTile((x * 16), (y * 16) - 12, 0, 0, 11); //head
            }
            else if (id == 0x86) //kodongo
            {
                drawSpriteTile((x * 16), (y * 16), 4, 10, 14);
            }
            else if (id == 0x88) //mothula
            {
                drawSpriteTile((x * 16), (y * 16), 8, 8, 14, false, false, 2, 4);
                drawSpriteTile((x * 16) + 16, (y * 16), 8, 8, 14, true, false, 2, 4);
            }
            else if (id == 0x8A) //spike
            {
                drawSpriteTile((x * 16), (y * 16), 6, 14, 15);
            }
            else if (id == 0x8B) //gibdo
            {
                drawSpriteTile((x * 16), (y * 16), 10, 8, 14);
                drawSpriteTile((x * 16), (y * 16) - 8, 0, 8, 14);
            }
            else if (id == 0x8C) //arrghus
            {
                drawSpriteTile((x * 16), (y * 16), 0, 8, 14, false, false, 2, 4);
                drawSpriteTile((x * 16) + 16, (y * 16), 0, 8, 14, true, false, 2, 4);
            }
            else if (id == 0x8D) //arrghus spawn
            {
                drawSpriteTile((x * 16), (y * 16), 6, 8, 14);
            }
            else if (id == 0x8E) //terrorpin
            {
                drawSpriteTile((x * 16), (y * 16), 14, 8, 12);
            }
            else if (id == 0x8F) //slime
            {
                drawSpriteTile((x * 16), (y * 16), 0, 4, 12);
            }
            else if (id == 0x90) //wall master
            {
                drawSpriteTile((x * 16), (y * 16), 6, 10, 12);
                drawSpriteTile((x * 16) + 16, (y * 16), 15, 10, 12, false, false, 1, 1);
                drawSpriteTile((x * 16) + 16, (y * 16) + 8, 9, 10, 12, false, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16) + 16, 10, 11, 12, false, false, 1, 1);
                drawSpriteTile((x * 16) + 8, (y * 16) + 16, 8, 11, 12, false, false, 1, 1);
            }
            else if (id == 0x91) //stalfos knight
            {
                drawSpriteTile((x * 16) - 2, (y * 16) + 12, 4, 6, 12, false, false, 1, 2);
                drawSpriteTile((x * 16) + 10, (y * 16) + 12, 4, 6, 12, true, false, 1, 2);
                drawSpriteTile((x * 16) - 4, (y * 16) + 4, 1, 6, 12);
                drawSpriteTile((x * 16) + 12, (y * 16) + 4, 3, 6, 12, false, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16) - 8, 6, 4, 12);

            }
            else if (id == 0x92) //helmaking
            {
                drawSpriteTile((x * 16), (y * 16) + 32, 14, 10, 14);
                drawSpriteTile((x * 16) + 16, (y * 16) + 32, 0, 12, 14);
                drawSpriteTile((x * 16) + 32, (y * 16) + 32, 14, 10, 14, true);


                drawSpriteTile((x * 16), (y * 16) + 16 + 32, 2, 12, 14);
                drawSpriteTile((x * 16) + 16, (y * 16) + 16 + 32, 4, 12, 14);
                drawSpriteTile((x * 16) + 32, (y * 16) + 16 + 32, 2, 12, 14, true);

                drawSpriteTile((x * 16) + 8, (y * 16) + 32 + 32, 6, 12, 14);
                drawSpriteTile((x * 16) + 24, (y * 16) + 32 + 32, 6, 12, 14, true);
            }
            else if (id == 0x93) //bumper
            {
                drawSpriteTile((x * 16), (y * 16), 12, 14, 7);
                drawSpriteTile((x * 16) + 16, (y * 16), 12, 14, 7, true);
                drawSpriteTile((x * 16) + 16, (y * 16) + 16, 12, 14, 7, true, true);
                drawSpriteTile((x * 16), (y * 16) + 16, 12, 14, 7, false, true);
            }
            else if (id == 0x95) //right laser eye
            {
                drawSpriteTile((x * 16), (y * 16), 9, 12, 3, true, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16) + 16, 9, 12, 3, true, true, 1, 1);
            }
            else if (id == 0x96) //left laser eye
            {
                drawSpriteTile((x * 16), (y * 16), 9, 12, 3, false, false, 1, 2);
                drawSpriteTile((x * 16), (y * 16) + 16, 9, 12, 3, false, true, 1, 1);
            }
            else if (id == 0x97) //right laser eye
            {
                drawSpriteTile((x * 16), (y * 16), 6, 12, 3, false, false, 2, 1);
                drawSpriteTile((x * 16) + 16, (y * 16), 6, 12, 3, true, false, 1, 1);
            }
            else if (id == 0x98) //right laser eye
            {
                drawSpriteTile((x * 16), (y * 16), 6, 12, 3, false, true, 2, 1);
                drawSpriteTile((x * 16) + 16, (y * 16), 6, 12, 3, true, true, 1, 1);
            }
            else if (id == 0x99)
            {
                drawSpriteTile((x * 16), (y * 16), 6, 8, 12);
                drawSpriteTile((x * 16), (y * 16) - 8, 0, 8, 12);
            }
            else if (id == 0x9A)//water bubble kyameron
            {
                drawSpriteTile((x * 16), (y * 16), 10, 8, 6);
            }
            else if (id == 0x9B)//water bubble kyameron
            {
                drawSpriteTile((x * 16), (y * 16), 6, 8, 11);
                drawSpriteTile((x * 16), (y * 16) - 8, 2, 11, 11, false, false, 2, 1);
            }
            else if (id == 0x9C)//water bubble kyameron
            {
                drawSpriteTile((x * 16), (y * 16), 12, 6, 11);
                drawSpriteTile((x * 16) + 16, (y * 16), 13, 6, 11, false, false, 1, 2);
            }
            else if (id == 0x9D)//water bubble kyameron
            {
                drawSpriteTile((x * 16), (y * 16), 14, 5, 11);
                drawSpriteTile((x * 16), (y * 16) - 16, 14, 4, 11, false, false, 2, 1);

            }
            else if (id == 0xA1)
            {
                drawSpriteTile((x * 16)-8, (y * 16) + 8, 6, 10, 14);
                drawSpriteTile((x * 16) + 8, (y * 16) + 8, 6, 10, 14, true);
            }
            else if (id == 0xA2)
            {
                drawSpriteTile((x * 16), (y * 16) + 8, 0, 8, 14, false, false, 4, 4);
            }
            else if (id == 0xA5)
            {
                drawSpriteTile((x * 16), (y * 16), 0, 10, 10, false, false, 3, 2);
                drawSpriteTile((x * 16) + 4, (y * 16) - 8, 0, 8, 10);

            }
            else if (id == 0xA6)
            {
                drawSpriteTile((x * 16), (y * 16), 0, 10, 8, false, false, 3, 2);
                drawSpriteTile((x * 16) + 4, (y * 16) - 8, 0, 8, 8);

            }
            else if (id == 0xA7)
            {
                drawSpriteTile((x * 16), (y * 16) + 12, 12, 0, 10);
                drawSpriteTile((x * 16), (y * 16), 0, 0, 10);

            }
            else if (id == 0xAD)
            {
                drawSpriteTile((x * 16), (y * 16) + 8, 14, 10, 10);
                drawSpriteTile((x * 16), (y * 16), 12, 10, 10);
            }
            else if (id == 0xC3)
            {
                drawSpriteTile((x * 16), (y * 16), 10, 14, 12);

            }
            else if (id == 0xC4)
            {
                drawSpriteTile((x * 16), (y * 16) + 8, 0, 2, 12);
                drawSpriteTile((x * 16), (y * 16), 0, 0, 12);
            }
            else if (id == 0xC7)
            {
                drawSpriteTile((x * 16), (y * 16), 0, 8, 4);
                drawSpriteTile((x * 16), (y * 16) - 10, 0, 8, 4);
                drawSpriteTile((x * 16), (y * 16) - 20, 0, 8, 4);
                drawSpriteTile((x * 16), (y * 16) - 30, 2, 8, 4);
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
            else if (id == 0xE3)
            {
                drawSpriteTile((x * 16), (y * 16), 10, 30, 10);
            }
            else if (id == 0xE4)//key
            {
                drawSpriteTile((x * 16), (y * 16), 11, 22, 11,false,false,1,2);
            }
            else if (id == 0xEB)
            {
                drawSpriteTile((x * 16), (y * 16), 0, 30, 5);
            }
            else
            {
                //stringtodraw.Add(new SpriteName(x, (y*16), sprites_name.name[id]));
                drawSpriteTile((x * 16), (y * 16), 4, 22, 5);
            }
            if (nx != this.x || ny != this.y)
            {
                boundingbox = new Rectangle((lowerX + (nx * 16)), (lowerY + (ny * 16)), width, height);
            }
            else
            {
                boundingbox = new Rectangle((lowerX + (x * 16)), (lowerY + (y * 16)), width, height);
            }

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
        public void drawSpriteTile(int x, int y, int srcx, int srcy, int pal, bool mirror_x = false, bool mirror_y = false, int sx = 2, int sy = 2,bool iskey = false)
        {
            int zx = x - (this.x * 16);
            int zy = y - (this.y * 16);
            if (iskey == false)
            {


                if (lowerX > zx)
                {
                    lowerX = zx;
                }

                if (lowerY > zy)
                {
                    lowerY = zy;
                }

                if (higherX < zx + (sx * 8))
                {
                    higherX = zx + (sx * 8);
                }

                if (higherY < zy + (sy * 8))
                {
                    higherY = zy + (sy * 8);
                }

                width = higherX - lowerX;
                height = higherY - lowerY;
                if (picker)
                {
                    x += 8;
                    y += 8;
                }

                if (nx != this.x || ny != this.y)
                {
                    x -= (this.x * 16);
                    y -= (this.y * 16);
                    x += (this.nx * 16);
                    y += (this.ny * 16);
                }
            }
            int ty = srcy + 40;
            int tx = srcx;
            int mx = 0;
            int my = 0;
            pal = pal - 2;
            if (mirror_x == true)
            {
                mx = sx * 8;
            }

            for (int xx = 0; xx < (sx * 8); xx++)
            {
                if (mx > 0)
                {
                    mx--;
                }
                if (mirror_y == true)
                {
                    my = sy * 8;
                }
                for (int yy = 0; yy < (sy * 8); yy++)
                {
                    if (my > 0)
                    {
                        my--;
                    }


                       
                    int x_dest = ((x) + (xx)) * 4;
                    int y_dest = (((y) + (yy)) * 512) * 4;
                    if (picker)
                    {
                        y_dest = (((y) + (yy)) * 32) * 4;
                    }
                    int dest = x_dest + y_dest;

                    int x_src = ((tx * 8) + (xx));
                    if (mirror_x)
                    {
                        x_src = ((tx * 8) + mx);
                    }
                    int y_src = (((ty * 8) + (yy)) * 128);
                    if (mirror_y)
                    {
                        y_src = (((ty * 8) + my) * 128);
                    }

                    int src = x_src + y_src;
                    unsafe
                    {
                        if (dest < 1048576)
                        {
                            if (dest > 0)
                            {
                                byte alpha = 255;


                                if (GFX.singledata[(src)] == 0)
                                {
                                    alpha = 0;
                                }
                                else
                                {
                                    /*if (iskey)
                                    {
                                        GFX.currentData[dest] = (byte)(GFX.spritesPalettes[GFX.singledata[(src)], pal].B ^ 0xFF);
                                        GFX.currentData[dest + 1] = (byte)(GFX.spritesPalettes[GFX.singledata[(src)], pal].G ^ 0xFF);
                                        GFX.currentData[dest + 2] = (byte)(GFX.spritesPalettes[GFX.singledata[(src)], pal].R ^ 0xFF);
                                        GFX.currentData[dest + 3] = 255;
                                    }
                                    else
                                    {*/
                                        GFX.currentData[dest] = (GFX.spritesPalettes[GFX.singledata[(src)], pal].B);
                                        GFX.currentData[dest + 1] = (GFX.spritesPalettes[GFX.singledata[(src)], pal].G);
                                        GFX.currentData[dest + 2] = (GFX.spritesPalettes[GFX.singledata[(src)], pal].R);
                                        GFX.currentData[dest + 3] = 255;
                                    //}
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}