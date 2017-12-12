using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
    class Save
    {
        Room[] all_rooms;
        public Save(Room[] all_rooms)
        {
            this.all_rooms = all_rooms;

            if (ROM.DATA.Length <= 0x100000)
            {
                DialogResult dialogResult = MessageBox.Show("Your ROM will be expanded to 2MB and move the rooms header to 0x110000", "Expand", MessageBoxButtons.OKCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    Array.Resize(ref ROM.DATA, 0x200000);
                    ROM.DATA[0x07FD7] = 0x0B;
                }
                else
                {
                    MessageBox.Show("Unable to save !, the header need to be moved in that version in order to save");
                    return;
                }
            }

        }

        public void saveRoomsHeaders()
        {
            if (Constants.Rando)
            {
                //24

                ROM.DATA[Constants.room_header_pointers_bank] = 0x24;
                for (int i = 0; i < 296; i++)
                {
                    ROM.DATA[Constants.room_header_pointers + (i * 2)] = (byte)((Addresses.pctosnes(0x120090 + (i * 14)) & 0xFF));
                    ROM.DATA[Constants.room_header_pointers + (i * 2) + 1] = (byte)((Addresses.pctosnes(0x120090 + (i * 14)) >> 8) & 0xFF);
                    saveHeader(0x120090, i);
                }
            }
            else
            {
                ROM.DATA[Constants.room_header_pointers_bank] = 0x22;
                for (int i = 0; i < 296; i++)
                {
                    ROM.DATA[Constants.room_header_pointers + (i * 2)] = (byte)((Addresses.pctosnes(0x110000 + (i * 14)) & 0xFF));
                    ROM.DATA[Constants.room_header_pointers + (i * 2) + 1] = (byte)((Addresses.pctosnes(0x110000 + (i * 14)) >> 8) & 0xFF);
                    saveHeader(0x110000, i);
                }
            }


        }

        public void saveHeader(int pos, int i)
        {
            ROM.DATA[pos + 0 + (i * 14)] = (byte)(((byte)all_rooms[i].bg2 << 5) + (all_rooms[i].collision << 2) + (all_rooms[i].light == true ? 1 : 0));
            ROM.DATA[pos + 1 + (i * 14)] = ((byte)all_rooms[i].palette);
            ROM.DATA[pos + 2 + (i * 14)] = ((byte)all_rooms[i].blockset);
            ROM.DATA[pos + 3 + (i * 14)] = ((byte)all_rooms[i].spriteset);
            ROM.DATA[pos + 4 + (i * 14)] = ((byte)all_rooms[i].effect);
            ROM.DATA[pos + 5 + (i * 14)] = ((byte)all_rooms[i].tag1);
            ROM.DATA[pos + 6 + (i * 14)] = ((byte)all_rooms[i].tag2);
            ROM.DATA[pos + 7 + (i * 14)] = (byte)((all_rooms[i].holewarp_plane) + (all_rooms[i].staircase_plane[0] << 2) + (all_rooms[i].staircase_plane[1] << 4) + (all_rooms[i].staircase_plane[2] << 6));
            ROM.DATA[pos + 8 + (i * 14)] = (byte)(all_rooms[i].staircase_plane[3]);
            ROM.DATA[pos + 9 + (i * 14)] = (byte)(all_rooms[i].holewarp);
            ROM.DATA[pos + 10 + (i * 14)] = (byte)(all_rooms[i].staircase_rooms[0]);
            ROM.DATA[pos + 11 + (i * 14)] = (byte)(all_rooms[i].staircase_rooms[1]);
            ROM.DATA[pos + 12 + (i * 14)] = (byte)(all_rooms[i].staircase_rooms[2]);
            ROM.DATA[pos + 13 + (i * 14)] = (byte)(all_rooms[i].staircase_rooms[3]);

            //floor 1, floor2
            ROM.DATA[Constants.tile_address] = all_rooms[i].floor1;
            ROM.DATA[Constants.tile_address + 1] = all_rooms[i].floor2;
        }


        public void saveAllRooms()//room settings floor1, floor2, blockset, spriteset, palette
        {
            /*for (int i = 0; i < 296; i++)
            {
                all_rooms[i]
            }*/
        }

        public void savePalettes()//room settings floor1, floor2, blockset, spriteset, palette
        {

        }

        public void saveallChests()
        {
            int pos = Constants.room_chest;
            for (int i = 0; i < 296; i++)
            {
                foreach (Chest c in all_rooms[i].chest_list)
                {
                    ushort room_index = (ushort)i;
                    if (c.bigChest == true)
                    {
                        room_index += 0x8000;
                    }
                    ROM.DATA[pos] = (byte)(room_index & 0xFF);
                    ROM.DATA[pos + 1] = (byte)((room_index >> 8) & 0xFF);
                    ROM.DATA[pos + 2] = (byte)(c.item);
                    pos += 3;
                }
            }
        }


        public void saveallSprites()
        {

            byte[] sprites_buffer = new byte[0x1670];
            //empty room data = 0x250
            //start of data = 0x252
            try
            {
                int pos = 0x252;
                //set empty room
                sprites_buffer[0x250] = 0x00;
                sprites_buffer[0x251] = 0xFF;

                for (int i = 0; i < 296; i++)
                {
                    if (all_rooms[i].sprites.Count <= 0)
                    {
                        sprites_buffer[(i * 2)] = (byte)((Addresses.pctosnes(Constants.sprites_data_empty_room) & 0xFF));
                        sprites_buffer[(i * 2) + 1] = (byte)((Addresses.pctosnes(Constants.sprites_data_empty_room) >> 8) & 0xFF);
                    }
                    else
                    {
                        //pointer : 
                        sprites_buffer[(i * 2)] = (byte)((Addresses.pctosnes(Constants.sprites_data + (pos - 0x252)) & 0xFF));
                        sprites_buffer[(i * 2) + 1] = (byte)((Addresses.pctosnes(Constants.sprites_data + (pos - 0x252)) >> 8) & 0xFF);

                        sprites_buffer[pos] = 0x00;//Unknown byte??
                        pos++;
                        foreach (Sprite spr in all_rooms[i].sprites) //3bytes
                        {
                            //BG2, Subtype, Y Position
                            //b1 = BSSY YYYY
                            //Overlord, X Position 
                            //b2 = OOOX XXXX
                            byte b1 = (byte)((spr.layer << 7) + (spr.subtype << 5) + spr.y);
                            byte b2 = (byte)((spr.overlord << 5) + spr.x);
                            byte b3 = (byte)((spr.id));

                            sprites_buffer[pos] = b1;
                            pos++;
                            sprites_buffer[pos] = b2;
                            pos++;
                            sprites_buffer[pos] = b3;
                            pos++;
                        }
                        sprites_buffer[pos] = 0xFF;//End of sprites
                        pos++;
                    }
                }

                sprites_buffer.CopyTo(ROM.DATA, Constants.room_sprites_pointers);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }


    }
}
