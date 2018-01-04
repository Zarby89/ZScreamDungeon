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

        public bool saveRoomsHeaders()
        {
            //long??
            int headerPointer = (ROM.DATA[Constants.room_header_pointer + 2] << 16) + (ROM.DATA[Constants.room_header_pointer + 1] << 8) + (ROM.DATA[Constants.room_header_pointer]);
            headerPointer = Addresses.snestopc(headerPointer);
            //headerPointer = 04F1E2 topc -> 0271E2
            if (Constants.Rando)
            {
                //24
                ROM.DATA[Constants.room_header_pointers_bank] = 0x24;
                for (int i = 0; i < 296; i++)
                {
                    ROM.DATA[headerPointer + (i * 2)] = (byte)((Addresses.pctosnes(0x120090 + (i * 14)) & 0xFF));
                    ROM.DATA[headerPointer + (i * 2) + 1] = (byte)((Addresses.pctosnes(0x120090 + (i * 14)) >> 8) & 0xFF);
                    saveHeader(0x120090, i);
                }
            }
            else
            {
                ROM.DATA[Constants.room_header_pointers_bank] = 0x22;
                for (int i = 0; i < 296; i++)
                {
                    ROM.DATA[headerPointer + (i * 2)] = (byte)((Addresses.pctosnes(0x110000 + (i * 14)) & 0xFF));
                    ROM.DATA[headerPointer + (i * 2) + 1] = (byte)((Addresses.pctosnes(0x110000 + (i * 14)) >> 8) & 0xFF);
                    saveHeader(0x110000, i);
                }
            }
            return false; // False = no error

        }
        public int getLongPointerSnestoPc(int pos)
        {
            int p = (ROM.DATA[pos + 2] << 16) + (ROM.DATA[pos + 1] << 8) + (ROM.DATA[pos]);
            return (Addresses.snestopc(p));
        }

        public bool saveBlocks()
        {
             //if we reach 0x80 size jump to pointer2 etc...
            int[] region = new int[4] { Constants.blocks_pointer1, Constants.blocks_pointer2, Constants.blocks_pointer3, Constants.blocks_pointer4 };
            int blockCount = 0;
            int r = 0;
            int pos = getLongPointerSnestoPc(region[r]);
            int count = 0;
            for (int i = 0; i < 296; i++)
            {
                foreach(Room_Object o in all_rooms[i].tilesObjects)
                {
                    if ((o.options & ObjectOption.Block) == ObjectOption.Block) //if we find a block save it
                    {
                        ROM.DATA[pos] = (byte)((i & 0xFF));
                        pos++;
                        ROM.DATA[pos] = (byte)(((i>> 8) & 0xFF));
                        pos++;
                        int xy = (((o.y * 64) + o.x) << 1);
                        ROM.DATA[pos] = (byte)(xy & 0xFF);
                        pos++;
                        ROM.DATA[pos] = (byte)((byte)(((xy >> 8) & 0xFF) + (o.layer*0x80)));
                        pos++;

                        count += 4;
                        if (count >= 0x80)
                        {
                            r++;
                            pos = getLongPointerSnestoPc(region[r]);
                            count = 0;
                        }
                        blockCount++;
                    }
                    
                }
            }
            if (blockCount > 99)
            {
                return true; // False = no error
            }
            /*if (b3 == 0xFF && b4 == 0xFF) { break; }
            int address = ((b4 & 0x1F) << 8 | b3) >> 1;
            int px = address % 64;
            int py = address >> 6;
            Room_Object r = addObject(0x0E00, (byte)(px), (byte)(py), 0, (byte)((b4 & 0x20) >> 5));*/
            return false; // False = no error
        }

        public void saveHeader(int pos, int i)
        {
            ROM.DATA[pos + 0 + (i * 14)] = (byte)((((byte)all_rooms[i].bg2 & 0x07) << 5) + (all_rooms[i].collision << 2) + (all_rooms[i].light == true ? 1 : 0));
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
        }


        public bool saveAllPits()
        {
            int pitCount = (ROM.DATA[Constants.pit_count] / 2);
            int pitPointer = (ROM.DATA[Constants.pit_pointer + 2] << 16) + (ROM.DATA[Constants.pit_pointer + 1] << 8) + (ROM.DATA[Constants.pit_pointer]);
            pitPointer = Addresses.snestopc(pitPointer);
            int pitCountNew = 0;
            for (int i = 0; i < 296; i++)
            {
                if (all_rooms[i].damagepit)
                {
                    ROM.DATA[pitPointer+1] = (byte)(all_rooms[i].index >> 8);
                    ROM.DATA[pitPointer] = (byte)(all_rooms[i].index);
                    pitPointer += 2;
                    pitCountNew++;
                }
            }
            return false;
        }



        int saddr = 0;
        public bool saveAllObjects()
        {
            var section1Index = 0x50008; //0x50000 to 0x5374F
            var section2Index = 0xF878A; //0xF878A to 0xFFFF7
            var section3Index = 0x1EB90; //0x1EB90 to 0x1FFFF
            var section4Index = 0x121210; // 0x121210 to ????? expanded region. need to find max safe for rando roms

            for (int i = 0; i < 296; i++)
            {
                int objectPointer = (ROM.DATA[Constants.room_object_pointer + 2] << 16) + (ROM.DATA[Constants.room_object_pointer + 1] << 8) + (ROM.DATA[Constants.room_object_pointer]);
                objectPointer = Addresses.snestopc(objectPointer);

                var roomBytes = all_rooms[i].getTilesBytes();
                if (roomBytes.Length < 10)
                {
                    saveObjectBytes(i, 0x50000, roomBytes); //empty room pointer
                    continue;
                }

                if (section1Index + roomBytes.Length <= 0x5374F) //0x50000 to 0x5374F
                {
                    // write the room
                    saveObjectBytes(i, section1Index, roomBytes);
                    section1Index += roomBytes.Length;
                    continue;
                }
                else if (section2Index + roomBytes.Length <= 0xFFFF7) //0xF878A to 0xFFFF7
                {
                    // write the room
                    saveObjectBytes(i, section2Index, roomBytes);
                    section2Index += roomBytes.Length;
                    continue;
                }
                else if (section3Index + roomBytes.Length <= 0x1FFFF) //0x1EB90 to 0x1FFFF
                {
                    // write the room
                    saveObjectBytes(i, section3Index, roomBytes);
                    section3Index += roomBytes.Length;
                    continue;
                }
                else
                {
                    // ran out of space
                    // write the room
                    saveObjectBytes(i, section4Index, roomBytes);
                    section4Index += roomBytes.Length;

                    //move to EXPANDED region
                    //Console.WriteLine("Room " + i + " no more space jump to 0x121210");
                    //currentPos = 0x121210;
                    //MessageBox.Show("We are running out space in the original portion of the ROM next data will be writed to : 0x121210");
                }
            }
            return false; // False = no error
        }

        void saveObjectBytes(int roomId, int position, byte[] bytes)
        {
            int objectPointer = (ROM.DATA[Constants.room_object_pointer + 2] << 16) + (ROM.DATA[Constants.room_object_pointer + 1] << 8) + (ROM.DATA[Constants.room_object_pointer]);
            objectPointer = Addresses.snestopc(objectPointer);
            saddr = Addresses.pctosnes(position);
            // update the index
            ROM.DATA[objectPointer + (roomId * 3)] = (byte)(saddr & 0xFF);
            ROM.DATA[objectPointer + (roomId * 3) + 1] = (byte)((saddr >> 8) & 0xFF);
            ROM.DATA[objectPointer + (roomId * 3) + 2] = (byte)((saddr >> 16) & 0xFF);

            Array.Copy(bytes, 0, ROM.DATA, position, bytes.Length);
        }

        public void savePalettes()//room settings floor1, floor2, blockset, spriteset, palette
        {

        }

        public bool saveallChests()
        {
            int cpos = (ROM.DATA[Constants.chests_data_pointer1 + 2] << 16) + (ROM.DATA[Constants.chests_data_pointer1 + 1] << 8) + (ROM.DATA[Constants.chests_data_pointer1]);
            cpos = Addresses.snestopc(cpos);
            int chestCount = 0;

            for (int i = 0; i < 296; i++)
            {
                //number of possible chests
                foreach (Chest c in all_rooms[i].chest_list)
                {
                    ushort room_index = (ushort)i;
                    if (c.bigChest == true)
                    {
                        room_index += 0x8000;
                    }
                    ROM.DATA[cpos] = (byte)(room_index & 0xFF);
                    ROM.DATA[cpos + 1] = (byte)((room_index >> 8) & 0xFF);
                    ROM.DATA[cpos + 2] = (byte)(c.item);
                    cpos += 3;
                    chestCount++;
                }
            }
            if (chestCount > 168)
            {
                return true; // False = no error
            }
            return false; // False = no error
        }

        public bool saveallPots()
        {
            int pos = Constants.items_data_start+2; //skip 2 FF FF that are empty pointer
            for (int i = 0; i < 296; i++)
            {
                if (all_rooms[i].pot_items.Count == 0)
                {
                    ROM.DATA[Constants.room_items_pointers + (i * 2)] = (byte)((Addresses.pctosnes(Constants.items_data_start) & 0xFF));
                    ROM.DATA[Constants.room_items_pointers + (i * 2) + 1] = (byte)((Addresses.pctosnes(Constants.items_data_start) >> 8) & 0xFF);
                    continue;
                }
                //pointer
                ROM.DATA[Constants.room_items_pointers + (i * 2)] = (byte)((Addresses.pctosnes(pos) & 0xFF));
                ROM.DATA[Constants.room_items_pointers + (i * 2) + 1] = (byte)((Addresses.pctosnes(pos) >> 8) & 0xFF);
                for (int j = 0; j < all_rooms[i].pot_items.Count;j++)
                {

                    int xy = (((all_rooms[i].pot_items[j].y * 64) + all_rooms[i].pot_items[j].x) << 1);
                    ROM.DATA[pos] = (byte)(xy & 0xFF);
                    pos++;
                    ROM.DATA[pos] = (byte)(((xy>>8) & 0xFF) + (all_rooms[i].pot_items[j].bg2 == true ? 0x80 : 0x00));
                    pos++;
                    ROM.DATA[pos] = all_rooms[i].pot_items[j].id;
                    pos++;
                }
                ROM.DATA[pos] = 0xFF;
                pos++;
                ROM.DATA[pos] = 0xFF;
                pos++;
                if (pos > Constants.items_data_end)
                {
                    Console.WriteLine("Warning items are outside of the allowed range!");
                }
            }
            return false; // False = no error

        }


        public bool saveallSprites()
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
                int spritePointer = (04 << 16) + (ROM.DATA[Constants.rooms_sprite_pointer + 1] << 8) + (ROM.DATA[Constants.rooms_sprite_pointer]);
                sprites_buffer.CopyTo(ROM.DATA, spritePointer);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false; // False = no error
        }


    }
}
