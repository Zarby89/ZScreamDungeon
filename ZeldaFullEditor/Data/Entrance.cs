using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public class Entrance //can be used for starting entrance as well
    {
        short room;//word value for each room

        public byte scrolledge_HU;//8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
        public byte scrolledge_FU;
        public byte scrolledge_HD;
        public byte scrolledge_FD;
        public byte scrolledge_HL;
        public byte scrolledge_FL;
        public byte scrolledge_HR;
        public byte scrolledge_FR;

        short yscroll;//2bytes each room
        short xscroll; //2bytes
        short yposition;//2bytes
        short xposition;//2bytes
        short ycamera;//2bytes
        short xcamera;//2bytes
        byte blockset; //1byte
        byte floor; //1byte
        byte dungeon; //1byte (dungeon id) //Same as music might use the project dungeon name instead
        byte door; //1byte
        byte ladderbg; ////1 byte, ---b ---a b = bg2, a = need to check -_-
        byte scrolling;////1byte --h- --v- 
        byte scrollquadrant; //1byte
        short exit;//2byte word 
        byte music; //1byte //Will need to be renamed and changed to add support to MSU1

        [DisplayName("Room Id"), Description("The room id the entrance is leading to"), Category("Entrance")]
        public short Room
        {
            get
            {
                return room;
            }
            set
            {
                room = value;

            }
        }

        [DisplayName("X Scroll"), Description("FILL ME"), Category("Entrance")]
        public short XScroll
        {
            get
            {
                return xscroll;
            }
            set
            {
                xscroll = value;

            }
        }
        [DisplayName("Y Scroll"), Description("FILL ME"), Category("Entrance")]
        public short YScroll
        {
            get
            {
                return yscroll;
            }
            set
            {
                yscroll = value;

            }
        }
        [DisplayName("X Position"), Description("The X position the player will enter the room (0,0) origin"), Category("Entrance")]
        public short XPosition
        {
            get
            {
                return xposition;
            }
            set
            {
                xposition = value;

            }
        }
        [DisplayName("Y Position"), Description("The Y position the player will enter the room (0,0) origin"), Category("Entrance")]
        public short YPosition
        {
            get
            {
                return yposition;
            }
            set
            {
                yposition = value;

            }
        }
        [DisplayName("X Camera"), Description("The X position of the camera when entering that room"), Category("Entrance")]
        public short XCamera
        {
            get
            {
                return xcamera;
            }
            set
            {
                xcamera = value;

            }
        }
        [DisplayName("Y Camera"), Description("The Y position of the camera when entering that room"), Category("Entrance")]
        public short YCamera
        {
            get
            {
                return ycamera;
            }
            set
            {
                ycamera = value;

            }
        }
        [DisplayName("Blockset"), Description("Used to determine the walls gfx of the dungeon"), Category("Entrance")]
        public byte Blockset
        {
            get
            {
                return blockset;
            }
            set
            {
                blockset = value;

            }
        }

        [DisplayName("Floor"), Description("FILL ME ?"), Category("Entrance")]
        public byte Floor
        {
            get
            {
                return floor;
            }
            set
            {
                floor = value;
                /*if (floor >= 2)
                {
                    floor = 1;
                }*/
            }
        }

        [DisplayName("Dungeon Id"), Description("Used to determine what dungeon we are in when entering from that entrance"), Category("Entrance")]
        public byte Dungeon
        {
            get
            {
                return dungeon;
            }
            set
            {
                dungeon = value;

            }
        }

        [DisplayName("Ladder Bg"), Description("Used to determine the layer we will be on when entering"), Category("Entrance")]
        public byte Ladderbg
        {
            get
            {
                return ladderbg;
            }
            set
            {
                ladderbg = value;
                /*if (ladderbg >= 2)
                {
                    ladderbg = 1;
                }*/
            }
        }

        [DisplayName("Scrolling"), Description("Used to determine if you can scroll or not the room you are entering"), Category("Entrance")]
        public byte Scrolling
        {
            get
            {
                return scrolling;
            }
            set
            {
                scrolling = value;
                /*if (scrolling >= 2)
                {
                    scrolling = 1;
                }*/
            }
        }

        [DisplayName("Scroll Quadrant"), Description("Used to determine if you can scrollquadrant or not the room you are entering"), Category("Entrance")]
        public byte Scrollquadrant
        {
            get
            {
                return scrollquadrant;
            }
            set
            {
                scrollquadrant = value;
                /*if (scrollquadrant >= 2)
                {
                    scrollquadrant = 1;
                }*/
            }
        }
        //why is that even a thing?
        [DisplayName("Exit"), Description("Used to determine where you will exit ?"), Category("Entrance")]
        public short Exit
        {
            get
            {
                return exit;
            }
            set
            {
                exit = value;
            }
        }

        [DisplayName("Music"), Description("Determine the music playing when entering from that entrance"), Category("Entrance")]
        public byte Music
        {
            get
            {
                return music;
            }
            set
            {
                music = value;
            }
        }

        
        public Entrance(byte entranceId, bool startingEntrance = false)
        {
            room = (short)((ROM.DATA[(Constants.entrance_room + (entranceId * 2)) + 1] << 8) + ROM.DATA[Constants.entrance_room + (entranceId * 2)]);
            yposition = (short)(((ROM.DATA[(Constants.entrance_yposition + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.entrance_yposition + (entranceId * 2)]);
            xposition = (short)(((ROM.DATA[(Constants.entrance_xposition + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.entrance_xposition + (entranceId * 2)]);
            xscroll = (short)(((ROM.DATA[(Constants.entrance_xscroll + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.entrance_xscroll + (entranceId * 2)]);
            yscroll = (short)(((ROM.DATA[(Constants.entrance_yscroll + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.entrance_yscroll + (entranceId * 2)]);
            ycamera = (short)(((ROM.DATA[(Constants.entrance_camerayposition + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.entrance_camerayposition + (entranceId * 2)]);
            xcamera = (short)(((ROM.DATA[(Constants.entrance_cameraxposition + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.entrance_cameraxposition + (entranceId * 2)]);
            blockset = (byte)(ROM.DATA[(Constants.entrance_blockset + entranceId)]);
            music = (byte)(ROM.DATA[(Constants.entrance_music + entranceId)]);
            dungeon = (byte)(ROM.DATA[(Constants.entrance_dungeon + entranceId)]);
            floor = (byte)(ROM.DATA[(Constants.entrance_floor + entranceId)]);
            door = (byte)(ROM.DATA[(Constants.entrance_door + entranceId)]);
            ladderbg = (byte)(ROM.DATA[(Constants.entrance_ladderbg + entranceId)]);
            scrolling = (byte)(ROM.DATA[(Constants.entrance_scrolling + entranceId)]);
            scrollquadrant = (byte)(ROM.DATA[(Constants.entrance_scrollquadrant + entranceId)]);
            exit = (short)(((ROM.DATA[(Constants.entrance_exit + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.entrance_exit + (entranceId * 2)]);

            scrolledge_HU = (ROM.DATA[(Constants.entrance_scrolledge + 0 + (entranceId * 8))]);//8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
            scrolledge_FU = (ROM.DATA[(Constants.entrance_scrolledge + 1 + (entranceId * 8))]);
            scrolledge_HD = (ROM.DATA[(Constants.entrance_scrolledge + 2 + (entranceId * 8))]);
            scrolledge_FD = (ROM.DATA[(Constants.entrance_scrolledge + 3 + (entranceId * 8))]);
            scrolledge_HL = (ROM.DATA[(Constants.entrance_scrolledge + 4 + (entranceId * 8))]);
            scrolledge_FL = (ROM.DATA[(Constants.entrance_scrolledge + 5 + (entranceId * 8))]);
            scrolledge_HR = (ROM.DATA[(Constants.entrance_scrolledge + 6 + (entranceId * 8))]);
            scrolledge_FR = (ROM.DATA[(Constants.entrance_scrolledge + 7 + (entranceId * 8))]);


            if (startingEntrance == true)
            {
                room = (short)((ROM.DATA[(Constants.startingentrance_room + ((entranceId) * 2)) + 1] << 8) + ROM.DATA[Constants.startingentrance_room + ((entranceId) * 2)]);
                //yposition = (short)(((ROM.DATA[(Constants.startingentrance_yposition + ((entranceId) * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_yposition + ((entranceId) * 2)]);
                //xposition = (short)(((ROM.DATA[(Constants.startingentrance_xposition + ((entranceId) * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_xposition + ((entranceId) * 2)]);
                //xscroll = (short)(((ROM.DATA[(Constants.startingentrance_xscroll + ((entranceId) * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_xscroll + ((entranceId) * 2)]);
                //yscroll = (short)(((ROM.DATA[(Constants.startingentrance_yscroll + ((entranceId) * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_yscroll + ((entranceId) * 2)]);
                //ycamera = (short)(((ROM.DATA[(Constants.startingentrance_camerayposition + ((entranceId) * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_camerayposition + ((entranceId) * 2)]);
                //xcamera = (short)(((ROM.DATA[(Constants.startingentrance_cameraxposition + ((entranceId) * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_cameraxposition + ((entranceId) * 2)]);
                yposition = (short)(((ROM.DATA[(Constants.startingentrance_yposition + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.startingentrance_yposition + (entranceId * 2)]);
                xposition = (short)(((ROM.DATA[(Constants.startingentrance_xposition + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.startingentrance_xposition + (entranceId * 2)]);
                xscroll = (short)(((ROM.DATA[(Constants.startingentrance_xscroll + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.startingentrance_xscroll + (entranceId * 2)]);
                yscroll = (short)(((ROM.DATA[(Constants.startingentrance_yscroll + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.startingentrance_yscroll + (entranceId * 2)]);
                ycamera = (short)(((ROM.DATA[(Constants.startingentrance_camerayposition + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.startingentrance_camerayposition + (entranceId * 2)]);
                xcamera = (short)(((ROM.DATA[(Constants.startingentrance_cameraxposition + (entranceId * 2)) + 1]) << 8) + ROM.DATA[Constants.startingentrance_cameraxposition + (entranceId * 2)]);
                blockset = (byte)(ROM.DATA[(Constants.startingentrance_blockset + entranceId)]);
                music = (byte)(ROM.DATA[(Constants.startingentrance_music + entranceId)]);
                dungeon = (byte)(ROM.DATA[(Constants.startingentrance_dungeon + entranceId)]);
                floor = (byte)(ROM.DATA[(Constants.startingentrance_floor + entranceId)]);
                door = (byte)(ROM.DATA[(Constants.startingentrance_door + entranceId)]);
                ladderbg = (byte)(ROM.DATA[(Constants.startingentrance_ladderbg + entranceId)]);
                scrolling = (byte)(ROM.DATA[(Constants.startingentrance_scrolling + entranceId)]);
                scrollquadrant = (byte)(ROM.DATA[(Constants.startingentrance_scrollquadrant + entranceId)]);
                exit = (short)(((ROM.DATA[(Constants.startingentrance_exit + (entranceId * 2)) + 1] & 0x01) << 8) + ROM.DATA[Constants.startingentrance_exit + (entranceId * 2)]);
                scrolledge_HU = (ROM.DATA[(Constants.startingentrance_scrolledge + 0 + (entranceId * 8))]);//8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
                scrolledge_FU = (ROM.DATA[(Constants.startingentrance_scrolledge + 1 + (entranceId * 8))]);
                scrolledge_HD = (ROM.DATA[(Constants.startingentrance_scrolledge + 2 + (entranceId * 8))]);
                scrolledge_FD = (ROM.DATA[(Constants.startingentrance_scrolledge + 3 + (entranceId * 8))]);
                scrolledge_HL = (ROM.DATA[(Constants.startingentrance_scrolledge + 4 + (entranceId * 8))]);
                scrolledge_FL = (ROM.DATA[(Constants.startingentrance_scrolledge + 5 + (entranceId * 8))]);
                scrolledge_HR = (ROM.DATA[(Constants.startingentrance_scrolledge + 6 + (entranceId * 8))]);
                scrolledge_FR = (ROM.DATA[(Constants.startingentrance_scrolledge + 7 + (entranceId * 8))]);
            }
        }


        public void save(int entranceId, bool startingentrance = false, bool jp = false)
        {
            //TODO: Change these save
            if (startingentrance == false)
            {
                ROM.DATA[(Constants.entrance_room + (entranceId * 2) + 1)] = (byte)((room >> 8) & 0xFF);
                ROM.DATA[Constants.entrance_room + (entranceId * 2)] = (byte)(room & 0xFF);

                ROM.DATA[(Constants.entrance_yposition + (entranceId * 2)) + 1] = (byte)((yposition >> 8) & 0xFF);
                ROM.DATA[Constants.entrance_yposition + (entranceId * 2)] = (byte)(yposition & 0xFF);

                ROM.DATA[(Constants.entrance_xposition + (entranceId * 2)) + 1] = (byte)((xposition >> 8) & 0xFF);
                ROM.DATA[Constants.entrance_xposition + (entranceId * 2)] = (byte)(xposition & 0xFF);

                ROM.DATA[(Constants.entrance_xscroll + (entranceId * 2)) + 1] = (byte)((xscroll >> 8) & 0xFF);
                ROM.DATA[Constants.entrance_xscroll + (entranceId * 2)] = (byte)(xscroll & 0xFF);

                ROM.DATA[(Constants.entrance_yscroll + (entranceId * 2)) + 1] = (byte)((yscroll >> 8) & 0xFF);
                ROM.DATA[Constants.entrance_yscroll + (entranceId * 2)] = (byte)(yscroll & 0xFF);

                ROM.DATA[(Constants.entrance_cameraxposition + (entranceId * 2)) + 1] = (byte)((xcamera >> 8) & 0xFF);
                ROM.DATA[Constants.entrance_cameraxposition + (entranceId * 2)] = (byte)(xcamera & 0xFF);

                ROM.DATA[(Constants.entrance_camerayposition + (entranceId * 2)) + 1] = (byte)((ycamera >> 8) & 0xFF);
                ROM.DATA[Constants.entrance_camerayposition + (entranceId * 2)] = (byte)(ycamera & 0xFF);

                ROM.DATA[Constants.entrance_blockset + entranceId] = (byte)(blockset & 0xFF);
                ROM.DATA[Constants.entrance_music + entranceId] = (byte)(music & 0xFF);
                ROM.DATA[Constants.entrance_dungeon + entranceId] = (byte)(dungeon & 0xFF);
                ROM.DATA[Constants.entrance_door + entranceId] = (byte)(door & 0xFF);
                ROM.DATA[Constants.entrance_floor + entranceId] = (byte)(floor & 0xFF);
                ROM.DATA[Constants.entrance_ladderbg + entranceId] = (byte)(ladderbg & 0xFF);
                ROM.DATA[Constants.entrance_scrolling + entranceId] = (byte)(scrolling & 0xFF);
                ROM.DATA[Constants.entrance_scrollquadrant + entranceId] = (byte)(scrollquadrant & 0xFF);
                (ROM.DATA[(Constants.entrance_scrolledge + 0 + (entranceId * 8))]) = scrolledge_HU; //8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
                (ROM.DATA[(Constants.entrance_scrolledge + 1 + (entranceId * 8))]) = scrolledge_FU;
                (ROM.DATA[(Constants.entrance_scrolledge + 2 + (entranceId * 8))]) = scrolledge_HD;
                (ROM.DATA[(Constants.entrance_scrolledge + 3 + (entranceId * 8))]) = scrolledge_FD;
                (ROM.DATA[(Constants.entrance_scrolledge + 4 + (entranceId * 8))]) = scrolledge_HL;
                (ROM.DATA[(Constants.entrance_scrolledge + 5 + (entranceId * 8))]) = scrolledge_FL;
                (ROM.DATA[(Constants.entrance_scrolledge + 6 + (entranceId * 8))]) = scrolledge_HR;
                (ROM.DATA[(Constants.entrance_scrolledge + 7 + (entranceId * 8))]) = scrolledge_FR;


            }
            else
            {
                ROM.DATA[(Constants.startingentrance_room + (entranceId * 2) + 1)] = (byte)((room >> 8) & 0xFF);
                ROM.DATA[Constants.startingentrance_room + (entranceId * 2)] = (byte)(room & 0xFF);

                ROM.DATA[(Constants.startingentrance_yposition + (entranceId * 2)) + 1] = (byte)((yposition >> 8) & 0xFF);
                ROM.DATA[Constants.startingentrance_yposition + (entranceId * 2)] = (byte)(yposition & 0xFF);

                ROM.DATA[(Constants.startingentrance_xposition + (entranceId * 2)) + 1] = (byte)((xposition >> 8) & 0xFF);
                ROM.DATA[Constants.startingentrance_xposition + (entranceId * 2)] = (byte)(xposition & 0xFF);

                ROM.DATA[(Constants.startingentrance_xscroll + (entranceId * 2)) + 1] = (byte)((xscroll >> 8) & 0xFF);
                ROM.DATA[Constants.startingentrance_xscroll + (entranceId * 2)] = (byte)(xscroll & 0xFF);

                ROM.DATA[(Constants.startingentrance_yscroll + (entranceId * 2)) + 1] = (byte)((yscroll >> 8) & 0xFF);
                ROM.DATA[Constants.startingentrance_yscroll + (entranceId * 2)] = (byte)(yscroll & 0xFF);

                ROM.DATA[(Constants.startingentrance_cameraxposition + (entranceId * 2)) + 1] = (byte)((xcamera >> 8) & 0xFF);
                ROM.DATA[Constants.startingentrance_cameraxposition + (entranceId * 2)] = (byte)(xcamera & 0xFF);

                ROM.DATA[(Constants.startingentrance_camerayposition + (entranceId * 2)) + 1] = (byte)((ycamera >> 8) & 0xFF);
                ROM.DATA[Constants.startingentrance_camerayposition + (entranceId * 2)] = (byte)(ycamera & 0xFF);

                ROM.DATA[Constants.startingentrance_blockset + entranceId] = (byte)(blockset & 0xFF);
                ROM.DATA[Constants.startingentrance_music + entranceId] = (byte)(music & 0xFF);
                ROM.DATA[Constants.startingentrance_dungeon + entranceId] = (byte)(dungeon & 0xFF);
                ROM.DATA[Constants.startingentrance_door + entranceId] = (byte)(door & 0xFF);
                ROM.DATA[Constants.startingentrance_floor + entranceId] = (byte)(floor & 0xFF);
                ROM.DATA[Constants.startingentrance_ladderbg + entranceId] = (byte)(ladderbg & 0xFF);
                ROM.DATA[Constants.startingentrance_scrolling + entranceId] = (byte)(scrolling & 0xFF);
                ROM.DATA[Constants.startingentrance_scrollquadrant + entranceId] = (byte)(scrollquadrant & 0xFF);
                ROM.DATA[(Constants.startingentrance_scrolledge + 0 + (entranceId * 8))] = scrolledge_HU; //8 bytes per room, HU, FU, HD, FD, HL, FL, HR, FR
                ROM.DATA[(Constants.startingentrance_scrolledge + 1 + (entranceId * 8))] = scrolledge_FU;
                ROM.DATA[(Constants.startingentrance_scrolledge + 2 + (entranceId * 8))] = scrolledge_HD;
                ROM.DATA[(Constants.startingentrance_scrolledge + 3 + (entranceId * 8))] = scrolledge_FD;
                ROM.DATA[(Constants.startingentrance_scrolledge + 4 + (entranceId * 8))] = scrolledge_HL;
                ROM.DATA[(Constants.startingentrance_scrolledge + 5 + (entranceId * 8))] = scrolledge_FL;
                ROM.DATA[(Constants.startingentrance_scrolledge + 6 + (entranceId * 8))] = scrolledge_HR;
                ROM.DATA[(Constants.startingentrance_scrolledge + 7 + (entranceId * 8))] = scrolledge_FR;
            }
        }


    }
}
