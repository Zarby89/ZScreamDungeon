using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
namespace ZeldaFullEditor
{
    class SaveJP
    {

        //ROM.DATA is a base rom loaded to get basic information it can either be JP1.0 or US1.2
        //can still use it for load but must not be used 
        public int newHeaderPos = 0x122000;
        Room[] all_rooms;
        string[] texts;
        string debugstring = "";
        public SaveJP(Room[] all_rooms)
        {
            this.all_rooms = all_rooms;
        }

        public bool saveEntrances(Entrance[] entrances, Entrance[] startingentrances)
        {
            for(int i = 0;i<0x84;i++)
            {
                entrances[i].save(i,false,true);
            }
            for (int i = 0; i < 0x07; i++)
            {
                startingentrances[i].save(i,true,true);
            }

            return false;
        }

        public bool saveTexts(string[] texts, Charactertable table)
        {
            int pos = 0xE0000;
            for(int i = 0;i<395;i++)
            {
                byte[] b = table.textToHex(texts[i]);
                for (int j = 0; j < b.Length; j++)
                {
                    ROM.DATA[pos] = b[j];
                    pos++;
                }
            }

            if (pos > 0xE7355)
            {
                return true;
            }
            return false;
        }


        public bool saveRoomsHeaders()
        {

            //long??
            int headerPointer = getLongPointerSnestoPc(ConstantsJP.room_header_pointer);
            if (headerPointer < 0x100000)
            {
                MovePointer mp = new MovePointer();
                mp.ShowDialog();
                headerPointer = mp.address;
                int addr = Addresses.pctosnes(mp.address);
                ROM.DATA[ConstantsJP.room_header_pointer] = (byte)(addr & 0xFF);
                ROM.DATA[ConstantsJP.room_header_pointer+1] = (byte)((addr>>8) & 0xFF);
                ROM.DATA[ConstantsJP.room_header_pointer+2] = (byte)((addr>>16) & 0xFF);

            }
            ROM.DATA[ConstantsJP.room_header_pointers_bank] = ROM.DATA[ConstantsJP.room_header_pointer+2];
            
            for (int i = 0; i < 296; i++)
            {
                ROM.DATA[(headerPointer) + (i * 2)] = (byte)((Addresses.pctosnes((headerPointer + 640) + (i * 14)) & 0xFF));
                ROM.DATA[(headerPointer) + (i * 2) + 1] = (byte)((Addresses.pctosnes((headerPointer + 640) + (i * 14)) >> 8) & 0xFF);
                saveHeader((headerPointer + 640), i);

                ROM.DATA[ConstantsJP.messages_id_dungeon + (i * 2) + 1] = (byte)((all_rooms[i].Messageid << 8) & 0xFF);
                ROM.DATA[ConstantsJP.messages_id_dungeon + (i * 2)] = (byte)((all_rooms[i].Messageid) & 0xFF); ;
            }
            return false; // False = no error

        }
        public int getLongPointerSnestoPc(int pos)
        {
            int p = (ROM.DATA[pos + 2] << 16) + (ROM.DATA[pos + 1] << 8) + (ROM.DATA[pos]);
            return (Addresses.snestopc(p));
        }

        /*public bool saveEntrances()
        {
            int id = 0;
            foreach(Entrance e in entrances)
            {
                e.save(id);
                id++;
            }

            id = 0;
            foreach (Entrance e in startingentrances)
            {
                e.save(id,true);
                id++;
            }



            return false;
        }*/


        public bool saveBlocks()
        {
             //if we reach 0x80 size jump to pointer2 etc...
            int[] region = new int[4] { ConstantsJP.blocks_pointer1, ConstantsJP.blocks_pointer2, ConstantsJP.blocks_pointer3, ConstantsJP.blocks_pointer4 };
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
                        ROM.DATA[pos] = (byte)((i & 0xFF));//b1
                        pos++;
                        ROM.DATA[pos] = (byte)(((i>> 8) & 0xFF));//b2
                        pos++;
                        int xy = (((o.y * 64) + o.x) << 1);
                        ROM.DATA[pos] = (byte)(xy & 0xFF);//b3
                        pos++;
                        ROM.DATA[pos] = (byte)((byte)(((xy >> 8) & 0x1F) + (o.layer*0x20)));//b4
                        //((b4 & 0x20) >> 5)
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


        public bool saveTorches()
        {
            int bytes_count = (ROM.DATA[ConstantsJP.torches_length_pointer + 1] << 8) + ROM.DATA[ConstantsJP.torches_length_pointer];
            int pos = ConstantsJP.torch_data;
            
            for (int i = 0; i < 296; i++)
            {
                bool room = false;
                foreach (Room_Object o in all_rooms[i].tilesObjects)
                {
                    if ((o.options & ObjectOption.Torch) == ObjectOption.Torch) //if we find a torch
                    {
                        //if we find a torch then store room if it not stored
                        
                        if (room == false)
                        {
                            ROM.DATA[pos] = (byte)((i & 0xFF));
                            pos++;
                            ROM.DATA[pos] = (byte)(((i >> 8) & 0xFF));
                            pos++;
                            room = true;
                        }

                        int xy = (((o.y * 64) + o.x) << 1);
                        byte b1 = (byte)(xy & 0xFF);
                        ROM.DATA[pos] = b1;
                        pos++;
                        byte b2 = (byte)((xy >> 8) & 0xFF);
                        if (o.layer == 1){b2 |= 0x20;}
                        b2 |= (byte)((o.lit ? 1:0) << 7);
                        ROM.DATA[pos] = b2;
                        pos++;

                    }
                }
                if (room == true)
                {
                    ROM.DATA[pos] = (byte)(0xFF);
                    pos++;
                    ROM.DATA[pos] = (byte)(0xFF);
                    pos++;
                }
            }

            if ((pos - ConstantsJP.torch_data) > bytes_count)
            {
                return true;
            }
            else
            {
                //(ROM.DATA[ConstantsJP.torches_length_pointer + 1] << 8) + ROM.DATA[ConstantsJP.torches_length_pointer]
                short npos = (short)(pos - ConstantsJP.torch_data);
                ROM.DATA[ConstantsJP.torches_length_pointer] = (byte)(npos & 0xFF);
                ROM.DATA[ConstantsJP.torches_length_pointer + 1] = (byte)((npos >> 8) & 0xFF);
                /*for(int i = (pos - ConstantsJP.torch_data);i < bytes_count;i++)
                {
                    ROM.DATA[i] = 0xFF;
                }*/
            }
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
            int pitCount = (ROM.DATA[ConstantsJP.pit_count] / 2);
            int pitPointer = (ROM.DATA[ConstantsJP.pit_pointer + 2] << 16) + (ROM.DATA[ConstantsJP.pit_pointer + 1] << 8) + (ROM.DATA[ConstantsJP.pit_pointer]);
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
            if (pitCountNew > pitCount)
            {
                return true;
            }
            return false;
        }



        int saddr = 0;
        public bool saveAllObjects()
        {
            var section1Index = 0x50008; //0x50000 to 0x5374F  //53730
            var section2Index = 0xF878A; //0xF878A to 0xFFFFF
            var section3Index = 0x1EB90; //0x1EB90 to 0x1FFFF
           // var section4Index = 0x121210; // 0x121210 to ????? expanded region. need to find max safe for rando roms

            //reorder room from bigger to lower

            for (int i = 0; i < 296; i++)
            {

                
                var roomBytes = all_rooms[i].getTilesBytes();
                int doorPos = roomBytes.Length-2;


                if (roomBytes.Length < 10)
                {
                    saveObjectBytes(all_rooms[i].index, 0x50000, roomBytes, doorPos); //empty room pointer
                    continue;
                }
                while (true)
                {
                    
                    if (doorPos >= 04)
                    {
                        if (roomBytes[doorPos] == 0xF0 && roomBytes[doorPos+1] == 0xFF)
                        {
                            doorPos += 2;
                            break;
                        }
                        doorPos -= 2;
                    }
                    else
                    {
                        break;
                    }
                }

                if (section1Index + roomBytes.Length <= 0x53730) //0x50000 to 0x5374F
                {
                    // write the room
                    saveObjectBytes(all_rooms[i].index, section1Index, roomBytes,doorPos);
                    section1Index += roomBytes.Length;
                    continue;
                }
                else if (section2Index + roomBytes.Length <= 0xFFFFF) //0xF878A to 0xFFFF7
                {
                    // write the room
                    saveObjectBytes(all_rooms[i].index, section2Index, roomBytes, doorPos);
                    section2Index += roomBytes.Length;
                    continue;
                }
                else if (section3Index + roomBytes.Length <= 0x1FFFF) //0x1EB90 to 0x1FFFF
                {
                    // write the room
                    saveObjectBytes(all_rooms[i].index, section3Index, roomBytes, doorPos);
                    section3Index += roomBytes.Length;
                    continue;
                }
                else
                {
                    // ran out of space
                    // write the room
                    //saveObjectBytes(i, section4Index, roomBytes);
                    //section4Index += roomBytes.Length;

                    return true;

                    //move to EXPANDED region
                    //Console.WriteLine("Room " + i + " no more space jump to 0x121210");
                    //currentPos = 0x121210;
                    //MessageBox.Show("We are running out space in the original portion of the ROM next data will be writed to : 0x121210");
                }
            }
            return false; // False = no error
        }

        void saveObjectBytes(int roomId, int position, byte[] bytes, int doorOffset)
        {
            int objectPointer = (ROM.DATA[ConstantsJP.room_object_pointer + 2] << 16) + (ROM.DATA[ConstantsJP.room_object_pointer + 1] << 8) + (ROM.DATA[ConstantsJP.room_object_pointer]);
            objectPointer = Addresses.snestopc(objectPointer);
            saddr = Addresses.pctosnes(position);
            int daddr = Addresses.pctosnes(position+doorOffset);
            // update the index
            ROM.DATA[objectPointer + (roomId * 3)] = (byte)(saddr & 0xFF);
            ROM.DATA[objectPointer + (roomId * 3) + 1] = (byte)((saddr >> 8) & 0xFF);
            ROM.DATA[objectPointer + (roomId * 3) + 2] = (byte)((saddr >> 16) & 0xFF);

            ROM.DATA[ConstantsJP.doorPointers + (roomId * 3)] = (byte)(daddr & 0xFF);
            ROM.DATA[ConstantsJP.doorPointers + (roomId * 3) + 1] = (byte)((daddr >> 8) & 0xFF);
            ROM.DATA[ConstantsJP.doorPointers + (roomId * 3) + 2] = (byte)((daddr >> 16) & 0xFF);

            Array.Copy(bytes, 0, ROM.DATA, position, bytes.Length);
        }

        public void savePalettes()//room settings floor1, floor2, blockset, spriteset, palette
        {

        }

        public bool saveallChests()
        {
            int cpos = (ROM.DATA[ConstantsJP.chests_data_pointer1 + 2] << 16) + (ROM.DATA[ConstantsJP.chests_data_pointer1 + 1] << 8) + (ROM.DATA[ConstantsJP.chests_data_pointer1]);
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
            //Console.WriteLine("Nbr of chests : " + chestCount);
            if (chestCount > 168)
            {
                return true; // False = no error
            }
            return false; // False = no error
        }

        public bool saveallPots()
        {
            int pos = ConstantsJP.items_data_start+2; //skip 2 FF FF that are empty pointer
            for (int i = 0; i < 296; i++)
            {
                if (all_rooms[i].pot_items.Count == 0)
                {
                    ROM.DATA[ConstantsJP.room_items_pointers + (i * 2)] = (byte)((Addresses.pctosnes(ConstantsJP.items_data_start) & 0xFF));
                    ROM.DATA[ConstantsJP.room_items_pointers + (i * 2) + 1] = (byte)((Addresses.pctosnes(ConstantsJP.items_data_start) >> 8) & 0xFF);
                    continue;
                }
                //pointer
                ROM.DATA[ConstantsJP.room_items_pointers + (i * 2)] = (byte)((Addresses.pctosnes(pos) & 0xFF));
                ROM.DATA[ConstantsJP.room_items_pointers + (i * 2) + 1] = (byte)((Addresses.pctosnes(pos) >> 8) & 0xFF);
                for (int j = 0; j < all_rooms[i].pot_items.Count;j++)
                {
                    if (all_rooms[i].pot_items[j].layer == 0)
                    {
                        all_rooms[i].pot_items[j].bg2 = false;
                    }
                    else
                    {
                        all_rooms[i].pot_items[j].bg2 = true;
                    }

                    int xy = (((all_rooms[i].pot_items[j].y * 64) + all_rooms[i].pot_items[j].x) << 1);
                    ROM.DATA[pos] = (byte)(xy & 0xFF);
                    pos++;
                    ROM.DATA[pos] = (byte)(((xy>>8) & 0xFF) + (all_rooms[i].pot_items[j].bg2 == true ? 0x20 : 0x00));
                    pos++;
                    ROM.DATA[pos] = all_rooms[i].pot_items[j].id;
                    pos++;
                }
                ROM.DATA[pos] = 0xFF;
                pos++;
                ROM.DATA[pos] = 0xFF;
                pos++;
                if (pos > ConstantsJP.items_data_end)
                {
                    return true;
                }
            }
            return false; // False = no error

        }


        public bool saveallSprites()
        {
            
            byte[] sprites_buffer = new byte[0x1670];
            //empty room data = 0x280
            //start of data = 0x282
            try
            {
                int pos = 0x282;
                //set empty room
                sprites_buffer[0x280] = 0x00;
                sprites_buffer[0x281] = 0xFF;

                for (int i = 0; i < 320; i++)
                {
                    if (i >= 296 || all_rooms[i].sprites.Count <= 0)
                    {
                        sprites_buffer[(i * 2)] = (byte)((Addresses.pctosnes(ConstantsJP.sprites_data_empty_room) & 0xFF));
                        sprites_buffer[(i * 2) + 1] = (byte)((Addresses.pctosnes(ConstantsJP.sprites_data_empty_room) >> 8) & 0xFF);
                    }
                    else
                    {
                        //pointer : 
                        sprites_buffer[(i * 2)] = (byte)((Addresses.pctosnes(ConstantsJP.sprites_data + (pos - 0x282)) & 0xFF));
                        sprites_buffer[(i * 2) + 1] = (byte)((Addresses.pctosnes(ConstantsJP.sprites_data + (pos - 0x282)) >> 8) & 0xFF);
                        //ROM.DATA[sprite_address] == 1 ? true : false;
                        sprites_buffer[pos] = (byte)(all_rooms[i].sortSprites == true ? 0x01 : 0x00);//Unknown byte??
                        pos++;
                        foreach (Sprite spr in all_rooms[i].sprites) //3bytes
                        {
                            byte b1 = (byte)((spr.layer << 7) + (spr.subtype << 5) + spr.y);
                            byte b2 = (byte)((spr.overlord << 5) + spr.x);
                            byte b3 = (byte)((spr.id));

                            sprites_buffer[pos] = b1;
                            pos++;
                            sprites_buffer[pos] = b2;
                            pos++;
                            sprites_buffer[pos] = b3;
                            pos++;

                            //if current sprite hold a key then save it before 
                            if (spr.keyDrop == 1)
                            {
                                byte bb1 = (byte)(0xFE);
                                byte bb2 = (byte)(0x00);
                                byte bb3 = (byte)(0xE4);

                                sprites_buffer[pos] = bb1;
                                pos++;
                                sprites_buffer[pos] = bb2;
                                pos++;
                                sprites_buffer[pos] = bb3;
                                pos++;
                            }
                            if (spr.keyDrop == 2)
                            {
                                byte bb1 = (byte)(0xFD);
                                byte bb2 = (byte)(0x00);
                                byte bb3 = (byte)(0xE4);

                                sprites_buffer[pos] = bb1;
                                pos++;
                                sprites_buffer[pos] = bb2;
                                pos++;
                                sprites_buffer[pos] = bb3;
                                pos++;
                            }
                        }
                        sprites_buffer[pos] = 0xFF;//End of sprites
                        pos++;
                    }
                }
                int spritePointer = (04 << 16) + (ROM.DATA[ConstantsJP.rooms_sprite_pointer + 1] << 8) + (ROM.DATA[ConstantsJP.rooms_sprite_pointer]);
                sprites_buffer.CopyTo(ROM.DATA, spritePointer);
            }
            catch (Exception e)
            {
                return true;
            }
            return false; // False = no error
        }


    }
}
