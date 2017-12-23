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



        int currentRegion = 0;
        int currentPos = 0x50000;
        int saddr = 0;
        int totalBytes = 0;
        public void saveAllObjects()
        {
            List<short> roomFitted = new List<short>();
            for (int i = 0; i < 296; i++)
            {
                int addr = Addresses.snestopc((ROM.DATA[Constants.room_object_pointers + (i * 3) + 2] << 16) + (ROM.DATA[Constants.room_object_pointers + (i * 3) + 1] << 8) + ROM.DATA[Constants.room_object_pointers + (i * 3) + 0]);
                if (addr == 0xF8780) //Clone Rooms // skip them for now
                {
                    continue;
                }
                
                byte[] roomBytes = all_rooms[i].getTilesBytes();
                Console.WriteLine("Room :" + i + " Difference load to save" + (all_rooms[i].roomSize - roomBytes.Length));
                totalBytes += roomBytes.Length;
                if (currentRegion == 0)
                {
                    if ((currentPos + roomBytes.Length) >= 0x5374F)
                    {
                        //save current i
                        for(int j = 0;j<296;j++)
                        {
                            if (j > i)
                            {
                                byte[] jroomBytes = all_rooms[j].getTilesBytes();
                                if (jroomBytes.Length < roomBytes.Length)
                                {
                                    //check if it fit otherwise continue
                                    if ((currentPos + jroomBytes.Length) >= 0x5374F)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        //is the room already in the forced room?
                                        if (roomFitted.Contains((short)i))
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            saddr = Addresses.pctosnes(currentPos);
                                            ROM.DATA[0xF8000 + (j * 3)] = (byte)(saddr & 0xFF);
                                            ROM.DATA[0xF8000 + (j * 3) + 1] = (byte)((saddr >> 8) & 0xFF);
                                            ROM.DATA[0xF8000 + (j * 3) + 2] = (byte)((saddr >> 16) & 0xFF);
                                            for (int k = 0; k < roomBytes.Length; k++)
                                            {
                                                ROM.DATA[currentPos] = roomBytes[k];
                                                currentPos++;
                                            }
                                            roomFitted.Add((short)j);
                                            break;
                                        }
                                    }
                                    
                                }
                            }
                        }

                        Console.WriteLine("Room " + i + " no more space jump to 0xF878A");



                        //move to F8 region
                        currentPos = 0xF878A;
                        currentRegion++;
                    }
                    else
                    {
                        //save new pointer
                        saddr = Addresses.pctosnes(currentPos);
                        ROM.DATA[0xF8000 + (i * 3)] = (byte)(saddr & 0xFF);
                        ROM.DATA[0xF8000 + (i * 3) + 1] = (byte)((saddr >> 8) & 0xFF);
                        ROM.DATA[0xF8000 + (i * 3) + 2] = (byte)((saddr >> 16) & 0xFF);
                        for (int j = 0; j < roomBytes.Length; j++)
                        {
                            ROM.DATA[currentPos] = roomBytes[j];
                            currentPos++;
                        }
                        continue;
                    }
                }
                if (currentRegion == 1)
                {
                    if ((currentPos + roomBytes.Length) >= 0xFFFF7)
                    {
                        //save current i
                        for (int j = 0; j < 296; j++)
                        {
                            if (j > i)
                            {
                                byte[] jroomBytes = all_rooms[j].getTilesBytes();
                                if (jroomBytes.Length < roomBytes.Length)
                                {
                                    //check if it fit otherwise continue
                                    if ((currentPos + jroomBytes.Length) >= 0xFFFF7)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        //is the room already in the forced room?
                                        if (roomFitted.Contains((short)i))
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            saddr = Addresses.pctosnes(currentPos);
                                            ROM.DATA[0xF8000 + (j * 3)] = (byte)(saddr & 0xFF);
                                            ROM.DATA[0xF8000 + (j * 3) + 1] = (byte)((saddr >> 8) & 0xFF);
                                            ROM.DATA[0xF8000 + (j * 3) + 2] = (byte)((saddr >> 16) & 0xFF);
                                            for (int k = 0; k < roomBytes.Length; k++)
                                            {
                                                ROM.DATA[currentPos] = roomBytes[k];
                                                currentPos++;
                                            }
                                            roomFitted.Add((short)j);
                                            break;
                                        }
                                    }

                                }
                            }
                        }
                        Console.WriteLine("Room " + i + " no more space jump to 0x1EBA0");
                        //move to 1E region
                        currentPos = 0x1EB90;
                        currentRegion++;
                    }
                    else
                    {
                        if (roomFitted.Contains((short)i))
                        {
                            continue;
                        }
                        saddr = Addresses.pctosnes(currentPos);
                        ROM.DATA[0xF8000 + (i * 3)] = (byte)(saddr & 0xFF);
                        ROM.DATA[0xF8000 + (i * 3) + 1] = (byte)((saddr >> 8) & 0xFF);
                        ROM.DATA[0xF8000 + (i * 3) + 2] = (byte)((saddr >> 16) & 0xFF);
                        for (int j = 0; j < roomBytes.Length; j++)
                        {
                            ROM.DATA[currentPos] = roomBytes[j];
                            currentPos++;
                        }
                        continue;
                    }
                }
                if (currentRegion == 2)
                {

                    if ((currentPos + roomBytes.Length) >= 0x1FFFF)
                    {
                        //save current i
                        for (int j = 0; j < 296; j++)
                        {
                            if (j > i)
                            {
                                byte[] jroomBytes = all_rooms[j].getTilesBytes();
                                if (jroomBytes.Length < roomBytes.Length)
                                {
                                    //check if it fit otherwise continue
                                    if ((currentPos + jroomBytes.Length) >= 0x1FFFF)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        //is the room already in the forced room?
                                        if (roomFitted.Contains((short)i))
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            saddr = Addresses.pctosnes(currentPos);
                                            ROM.DATA[0xF8000 + (j * 3)] = (byte)(saddr & 0xFF);
                                            ROM.DATA[0xF8000 + (j * 3) + 1] = (byte)((saddr >> 8) & 0xFF);
                                            ROM.DATA[0xF8000 + (j * 3) + 2] = (byte)((saddr >> 16) & 0xFF);
                                            for (int k = 0; k < roomBytes.Length; k++)
                                            {
                                                ROM.DATA[currentPos] = roomBytes[k];
                                                currentPos++;
                                            }
                                            roomFitted.Add((short)j);
                                            break;
                                        }
                                    }

                                }
                            }
                        }
                        //move to EXPANDED region
                        Console.WriteLine("Room " + i + " no more space jump to 0x121210");
                        currentPos = 0x121210;
                        MessageBox.Show("We are running out space in the original portion of the ROM next data will be writed to : 0x121210");
                        currentRegion++;
                    }
                    else
                    {
                        if (roomFitted.Contains((short)i))
                        {
                            continue;
                        }
                        saddr = Addresses.pctosnes(currentPos);
                        ROM.DATA[0xF8000 + (i * 3)] = (byte)(saddr & 0xFF);
                        ROM.DATA[0xF8000 + (i * 3) + 1] = (byte)((saddr >> 8) & 0xFF);
                        ROM.DATA[0xF8000 + (i * 3) + 2] = (byte)((saddr >> 16) & 0xFF);
                        for (int j = 0; j < roomBytes.Length; j++)
                        {
                            ROM.DATA[currentPos] = roomBytes[j];
                            currentPos++;
                        }
                        continue;
                    }
                }
                if (currentRegion == 3)
                {
                    if (roomFitted.Contains((short)i))
                    {
                        continue;
                    }
                    saddr = Addresses.pctosnes(currentPos);
                    ROM.DATA[0xF8000 + (i * 3)] = (byte)(saddr & 0xFF);
                    ROM.DATA[0xF8000 + (i * 3) + 1] = (byte)((saddr >> 8) & 0xFF);
                    ROM.DATA[0xF8000 + (i * 3) + 2] = (byte)((saddr >> 16) & 0xFF);
                    for (int j = 0; j < roomBytes.Length; j++)
                    {
                        ROM.DATA[currentPos] = roomBytes[j];
                        currentPos++;
                    }
                    continue;
                }
                //0x50000 to 0x5374F
                //0xF878A to 0xFFFF7
                //0x1EB90 to 0x01FFFF


            }
            Console.WriteLine("Number of bytes total loaded/saved : " + totalBytes.ToString("X6"));
            if (currentRegion == 3)
            {
                Console.WriteLine("Had to save some room in expanded rom :(");
            }
            else
            {
                Console.WriteLine("no need expanded rom :) (last room : " + currentPos.ToString("X6"));
            }
        }
            /*byte[] objects_array = all_rooms[260].getTilesBytes();
            int jump = 0;
            Console.WriteLine("New Data : ");
            for(int i = 0;i<objects_array.Length;i+=1)
            {
                ROM.DATA[0x50000 + i] = objects_array[i];
                Console.Write(objects_array[i].ToString("X2") + " ");

                jump++;
                if (jump >= 16)
                {
                    Console.Write("\n");
                    jump = 0;
                }

            }
            
        }*/

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
