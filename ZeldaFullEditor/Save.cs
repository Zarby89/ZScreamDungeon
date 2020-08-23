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
    class Save
    {

        //ROM.DATA is a base rom loaded to get basic information it can either be JP1.0 or US1.2
        Room[] all_rooms;
        string[] texts;
        string debugstring = "";
        public Save(Room[] all_rooms)
        {
            this.all_rooms = all_rooms;
        }

        public bool saveEntrances(Entrance[] entrances, Entrance[] startingentrances)
        {
            for(int i = 0;i<0x84;i++)
            {
                entrances[i].save(i);
            }
            for (int i = 0; i < 0x07; i++)
            {
                startingentrances[i].save(i,true);
            }

            return false;
        }

        public bool saveRoomsHeaders()
        {
            
            //long??
            int headerPointer = getLongPointerSnestoPc(Constants.room_header_pointer);
            if (headerPointer < 0x100000)
            {
                MovePointer mp = new MovePointer();
                mp.ShowDialog();
                headerPointer = mp.address;
                
                int addr = Utils.PcToSnes(mp.address);
                ROM.WriteLong(Constants.room_header_pointer, addr, true, "Header Pointers Location");
                ROM.Write(Constants.room_header_pointers_bank, ROM.DATA[Constants.room_header_pointer + 2], true, "Header Bank");
            }
            ROM.StartBlockLogWriting("Room Headers", headerPointer);
            for (int i = 0; i < 296; i++)
            {
                int newsptraddr = (Utils.PcToSnes((headerPointer + 640) + (i * 14)));
                ROM.WriteShort((headerPointer) + (i * 2), newsptraddr,true,"Header " + i.ToString("D3") + " Pointer");
                saveHeader((headerPointer + 640), i);
            }
            ROM.EndBlockLogWriting();

            ROM.StartBlockLogWriting("Rooms Messages", Constants.messages_id_dungeon);
            //ROM.SaveLogs();
            for (int i = 0; i < 296; i++)
            {
                ROM.WriteShort(Constants.messages_id_dungeon + (i * 2), all_rooms[i].Messageid, true, "Message Room ID : " + i.ToString("D3"));
            }
            ROM.EndBlockLogWriting();
            return false; // False = no error


        }
        public int getLongPointerSnestoPc(int pos)
        {
            return (Utils.SnesToPc(ROM.ReadLong(pos)));
        }

  
        public bool saveBlocks()
        {
           
             //if we reach 0x80 size jump to pointer2 etc...
            int[] region = new int[4] { Constants.blocks_pointer1, Constants.blocks_pointer2, Constants.blocks_pointer3, Constants.blocks_pointer4 };
            int blockCount = 0;
            int r = 0;
            int pos = getLongPointerSnestoPc(region[r]);
            int count = 0;
            ROM.StartBlockLogWriting("Blocks Data", pos);
            for (int i = 0; i < 296; i++)
            {
                foreach(Room_Object o in all_rooms[i].tilesObjects)
                {
                    if ((o.options & ObjectOption.Block) == ObjectOption.Block) //if we find a block save it
                    {

                        int xy = (((o.y * 64) + o.x) << 1);
                        byte[] data = new byte[4] {
                            (byte)((i & 0xFF)),
                            (byte)(((i >> 8) & 0xFF)),
                            (byte)(xy & 0xFF),
                            ((byte)(((xy >> 8) & 0x1F) + (o.layer * 0x20)))
                        };
                        ROM.Write(pos, data, true, "Room:" + i.ToString("D3") +"X:"+ o.x.ToString("D2") + " Y:" + o.x.ToString("D2") + " L:" + o.x.ToString("D2"));

                        pos += 4;
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
            ROM.EndBlockLogWriting();

            /*if (b3 == 0xFF && b4 == 0xFF) { break; }
            int address = ((b4 & 0x1F) << 8 | b3) >> 1;
            int px = address % 64;
            int py = address >> 6;
            Room_Object r = addObject(0x0E00, (byte)(px), (byte)(py), 0, (byte)((b4 & 0x20) >> 5));*/
            return false; // False = no error
        }


        public bool saveTorches()
        {
            int bytes_count = ROM.ReadShort(Constants.torches_length_pointer);

            
            int pos = Constants.torch_data;
            ROM.StartBlockLogWriting("Torches Data", pos);
            //288 torches?
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
                            ROM.WriteShort(pos, i, true, "Torches in room " + i.ToString("D3"));

                            pos += 2;
                            room = true;
                        }



                        int xy = (((o.y * 64) + o.x) << 1);
                        byte b1 = (byte)(xy & 0xFF);
                        ROM.Write(pos, b1);
                        pos++;
                        byte b2 = (byte)((xy >> 8) & 0xFF);
                        if (o.layer == 1){b2 |= 0x20;}
                        b2 |= (byte)((o.lit ? 1:0) << 7);
                        ROM.Write(pos, b2);
                        pos++;

                    }
                }
                if (room == true)
                {
                    ROM.WriteShort(pos, 0xFFFF);
                    pos += 2;
                }
            }

            if ((pos - Constants.torch_data) > bytes_count)
            {
                return true;
            }
            else
            {
                short npos = (short)(pos - Constants.torch_data);
                ROM.WriteShort(Constants.torches_length_pointer, npos);
            }
            ROM.EndBlockLogWriting();
            return false; // False = no error
        }


        public void saveHeader(int pos, int i)
        {

            byte[] headerData = new byte[14]
            {
                (byte)((((byte)all_rooms[i].bg2 & 0x07) << 5) + (all_rooms[i].collision << 2) + (all_rooms[i].light == true ? 1 : 0)),
                ((byte)all_rooms[i].palette),
                ((byte)all_rooms[i].blockset),
                ((byte)all_rooms[i].spriteset),
                ((byte)all_rooms[i].effect),
                ((byte)all_rooms[i].tag1),
                ((byte)all_rooms[i].tag2),
                (byte)((all_rooms[i].holewarp_plane) + (all_rooms[i].staircase_plane[0] << 2) + (all_rooms[i].staircase_plane[1] << 4) + (all_rooms[i].staircase_plane[2] << 6)),
                (byte)(all_rooms[i].staircase_plane[3]),
                (byte)(all_rooms[i].holewarp),
                (byte)(all_rooms[i].staircase_rooms[0]),
                (byte)(all_rooms[i].staircase_rooms[1]),
                (byte)(all_rooms[i].staircase_rooms[2]),
                (byte)(all_rooms[i].staircase_rooms[3])
            };
            ROM.Write(pos + (i * 14), headerData, true, "Room Header " + i.ToString("D3"));
        }


        public bool saveAllPits()
        {
            
            int pitCount = (ROM.DATA[Constants.pit_count] / 2);
            int pitPointer = ROM.ReadLong(Constants.pit_pointer);
            pitPointer = Utils.SnesToPc(pitPointer);
            ROM.StartBlockLogWriting("Pits Data", pitPointer);
            int pitCountNew = 0;
            for (int i = 0; i < 296; i++)
            {
                if (all_rooms[i].damagepit)
                {
                    ROM.WriteShort(pitPointer, all_rooms[i].index,true,"");
                    pitPointer += 2;
                    pitCountNew++;
                }
            }
            if (pitCountNew > pitCount)
            {
                return true;
            }
            ROM.EndBlockLogWriting();
            return false;
        }


        int[] roomTilesPointers = new int[296];
        int[] roomDoorsPointers = new int[296];
        int saddr = 0;
        public bool saveAllObjects()
        {
            var section1Index = 0x50008; //0x50000 to 0x5374F  //53730
            var section2Index = 0xF878A; //0xF878A to 0xFFFFF
            var section3Index = 0x1EB90; //0x1EB90 to 0x1FFFF
            var section4Index = 0x1112C0; //if vanilla space is used use expanded region
            int section4Start = 0x1112C0;
            bool usedSection4 = false;
            /*while (ROM.DATA[section4Index] != 0)
            {
                 //section4Index += 0x010000;
            }*/
            //Check if room is already using that space first before skipping position!!
            section4Start = section4Index;
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
                    saveObjectBytes(all_rooms[i].index, section4Index, roomBytes, doorPos);
                    section4Index += roomBytes.Length;
                    usedSection4 = true;
                    continue;
                    //move to EXPANDED region
                    //Console.WriteLine("Room " + i + " no more space jump to 0x121210");
                    //currentPos = 0x121210;
                    //MessageBox.Show("We are running out space in the original portion of the ROM next data will be writed to : 0x121210");
                }
            }
            if (usedSection4)
            {
                Console.WriteLine("Used section4 for tiles index at location : " + section4Start.ToString("X6") + "Length of :" + (section4Index-section4Start).ToString("X6"));
            }

            int objectPointer = Utils.SnesToPc(ROM.ReadLong(Constants.room_object_pointer));
            ROM.StartBlockLogWriting("Room And Doors Pointers", objectPointer);
            for (int i = 0; i < 296; i++)
            {
                ROM.WriteLong(objectPointer + (i * 3), roomTilesPointers[i],true, "Room "+i.ToString("D3")+" Tiles Pointer");
                ROM.WriteLong(Constants.doorPointers + (i * 3), roomDoorsPointers[i], true, "Room " + i.ToString("D3") + " Doors Pointer");
            }
            ROM.EndBlockLogWriting();

            return false; // False = no error
        }

        void saveObjectBytes(int roomId, int position, byte[] bytes, int doorOffset)
        {
            int objectPointer = Utils.SnesToPc(ROM.ReadLong(Constants.room_object_pointer));
            saddr = Utils.PcToSnes(position);
            roomTilesPointers[roomId] = saddr;
            int daddr = Utils.PcToSnes(position + doorOffset);
            roomDoorsPointers[roomId] = daddr;
            // update the index


            ROM.StartBlockLogWriting("Room " + roomId.ToString("D3") + " Tiles Data", position);
            if (ROM.AdvancedLogs)
            {
                int bp = 2;
                ROM.romLog.Append(bytes[0].ToString("X2") + ", " + bytes[1].ToString("X2") + "// Room Layout and Floors\r\n");
                while (bp < bytes.Length)
                {

                        for (int i = 0; i < 32; i++)
                        {
                            if (bp >= bytes.Length)
                            {
                                break;
                            }
                            ROM.romLog.Append(bytes[bp].ToString("X2") + " ");
                            bp++;
                        }
                    ROM.romLog.Append("\r\n");
                }
            }
        
            Array.Copy(bytes, 0, ROM.DATA, position, bytes.Length);
            ROM.EndBlockLogWriting();

        }

        public void savePalettes()//room settings floor1, floor2, blockset, spriteset, palette
        {

        }

        public bool saveallChests()
        {
            
            int cpos = Utils.SnesToPc(ROM.ReadLong(Constants.chests_data_pointer1));
            int chestCount = 0;
            ROM.StartBlockLogWriting("Chests Data", cpos);
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
                    byte[] data = new byte[3]
                    {
                        (byte)(room_index & 0xFF),
                        (byte)((room_index >> 8) & 0xFF),
                        (byte)(c.item),
                    };
                    ROM.Write(cpos, data, true, "Chest Data " + i.ToString("D3"));
                    cpos += 3;
                    chestCount++;
                }
            }
            //Console.WriteLine("Nbr of chests : " + chestCount);
            if (chestCount > 168)
            {
                return true; // False = no error
            }
            ROM.EndBlockLogWriting();
            return false; // False = no error
        }

        public bool saveallPots()
        {
            int pos = Constants.items_data_start+2; //skip 2 FF FF that are empty pointer
            ROM.StartBlockLogWriting("Pots Items Data", pos);
            for (int i = 0; i < 296; i++)
            {
                if (all_rooms[i].pot_items.Count == 0)
                {
                    ROM.WriteShort(Constants.room_items_pointers, Utils.PcToSnes(Constants.items_data_start), true, "Items Pointer for Room " + i.ToString("D3"));
                    continue;
                }
                //pointer
                ROM.WriteShort(Constants.room_items_pointers + (i * 2), Utils.PcToSnes(pos), true, "Items Pointer for Room " + i.ToString("D3"));
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

                    byte[] data = new byte[3]
                    {
                       (byte)(xy & 0xFF),
                       (byte)(((xy >> 8) & 0xFF) + (all_rooms[i].pot_items[j].bg2 == true ? 0x20 : 0x00)),
                       all_rooms[i].pot_items[j].id
                    };
                    ROM.Write(pos, data, true, "Items Data for Room " + i.ToString("D3"));
                    pos+=3;
                }
                ROM.WriteShort(pos, 0xFFFF, true);
                pos+=2;
                if (pos > Constants.items_data_end)
                {
                    return true;
                }
            }
            ROM.EndBlockLogWriting();
            return false; // False = no error

        }

        public bool saveAllText(TextEditor te)
        {
            if (te.save())
            {
                return true;
            }
            return false;
        }


        public bool saveallSprites()
        {

            
            int spritePointer = (09 << 16) + (ROM.DATA[Constants.rooms_sprite_pointer + 1] << 8) + (ROM.DATA[Constants.rooms_sprite_pointer]);
            int spritePointerPC = Utils.SnesToPc(spritePointer);
            ROM.StartBlockLogWriting("Dungeon Sprites", spritePointerPC);
            byte[] sprites_buffer = new byte[Constants.sprites_end_data - Utils.SnesToPc(spritePointer)];
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
                        sprites_buffer[(i * 2)] = (byte)((Utils.PcToSnes(Utils.SnesToPc(spritePointer + 0x280)) & 0xFF));
                        sprites_buffer[(i * 2) + 1] = (byte)(((Utils.SnesToPc(spritePointer + 0x280)) >> 8) & 0xFF);
                    }
                    else
                    {
                            //pointer : 
                            sprites_buffer[(i * 2)] = (byte)((Utils.PcToSnes(Utils.SnesToPc(spritePointer + pos)) & 0xFF));
                            sprites_buffer[(i * 2) + 1] = (byte)((Utils.PcToSnes(Utils.SnesToPc(spritePointer + pos)) >> 8) & 0xFF);
                        
                        sprites_buffer[pos] = (byte)(all_rooms[i].sortSprites == true ? 0x01 : 0x00);//Unknown byte??
                        pos++;
                        foreach (Sprite spr in all_rooms[i].sprites) //3bytes
                        {
                            byte b1 = (byte)((spr.layer << 7) + ((spr.subtype & 0x18) << 2) + spr.y);
                            byte b2 = (byte)(((spr.subtype & 0x07) << 5) + spr.x);
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
                ROM.EndBlockLogWriting();
                sprites_buffer.CopyTo(ROM.DATA, spritePointerPC);
            }
            catch (Exception e)
            {
                return true;
            }

            return false; // False = no error

        }


        public bool saveOWExits(SceneOW scene)
        {
            ROM.StartBlockLogWriting("OW Exits", Constants.OWExitMapId);
            for (int i = 0; i < 78; i++)
            {

            ROM.Write(Constants.OWExitMapId + (i), (byte)((scene.ow.allexits[i].mapId) & 0xFF), true, "Exit[" +i.ToString("D2")+ "] Exit to map " + scene.ow.allexits[i].mapId.ToString("D3"));

            ROM.WriteShort(Constants.OWExitXScroll + (i * 2), ((scene.ow.allexits[i].xScroll)), true, "Exit[" + i.ToString("D2") + "] ScrollX " + scene.ow.allexits[i].xScroll.ToString("D3"));

            ROM.WriteShort(Constants.OWExitYScroll + (i * 2), ((scene.ow.allexits[i].yScroll)), true, "Exit[" + i.ToString("D2") + "] ScrollY " + scene.ow.allexits[i].yScroll.ToString("D3"));

            ROM.WriteShort(Constants.OWExitXCamera + (i * 2), ((scene.ow.allexits[i].cameraX) ), true, "Exit[" + i.ToString("D2") + "] CameraX " + scene.ow.allexits[i].cameraX.ToString("D3"));

            ROM.WriteShort(Constants.OWExitYCamera + (i * 2),((scene.ow.allexits[i].cameraY) ), true, "Exit[" + i.ToString("D2") + "] CameraY " + scene.ow.allexits[i].cameraY.ToString("D3"));

            ROM.WriteShort(Constants.OWExitVram + (i * 2), ((scene.ow.allexits[i].vramLocation) ), true, "Exit[" + i.ToString("D2") + "] VRAM " + scene.ow.allexits[i].vramLocation.ToString("D3"));

            ROM.WriteShort(Constants.OWExitRoomId + (i * 2), ((scene.ow.allexits[i].roomId) ), true, "Exit[" + i.ToString("D2") + "] RoomID " + scene.ow.allexits[i].roomId.ToString("D3"));

            ROM.WriteShort(Constants.OWExitXPlayer + (i * 2), ((scene.ow.allexits[i].playerX) ), true, "Exit[" + i.ToString("D2") + "] PlayerX " + scene.ow.allexits[i].playerX.ToString("D3"));

            ROM.WriteShort(Constants.OWExitYPlayer + (i * 2), ((scene.ow.allexits[i].playerY)), true, "Exit[" + i.ToString("D2") + "] PlayerY " + scene.ow.allexits[i].playerY.ToString("D3"));

            ROM.WriteShort(Constants.OWExitDoorType1 + (i * 2), ((scene.ow.allexits[i].doorType1)), true, "Exit[" + i.ToString("D2") + "] Door1 " + scene.ow.allexits[i].doorType1.ToString("D3"));

            ROM.WriteShort(Constants.OWExitDoorType2 + (i * 2), ((scene.ow.allexits[i].doorType2)), true, "Exit[" + i.ToString("D2") + "] Door2 " + scene.ow.allexits[i].doorType2.ToString("D3"));
        }
            ROM.EndBlockLogWriting();
            return false;
        }

        public bool saveOWEntrances(SceneOW scene)
        {
            ROM.StartBlockLogWriting("OW Entrances/Holes", Constants.OWEntranceMap);
            for (int i = 0; i < scene.ow.allentrances.Length; i++)
            {


                ROM.WriteShort(Constants.OWEntranceMap + (i * 2), ((scene.ow.allentrances[i].mapId)), true, "Entrance[" + i.ToString("D2")+"]" + " Map: " + scene.ow.allentrances[i].mapId.ToString("D3"));

                ROM.WriteShort(Constants.OWEntrancePos + (i * 2), ((scene.ow.allentrances[i].mapPos)), true, "Entrance[" + i.ToString("D2") + "]" + " Pos: " + scene.ow.allentrances[i].mapPos.ToString("D3"));

                ROM.Write(Constants.OWEntranceEntranceId + i, (byte)((scene.ow.allentrances[i].entranceId) & 0xFF), true, "Entrance[" + i.ToString("D2") + "]" + " Entrance Leading to: " + scene.ow.allentrances[i].entranceId.ToString("D3"));
            }

            for (int i = 0; i < scene.ow.allholes.Length; i++)
            {

                
                ROM.WriteShort(Constants.OWHoleArea + (i * 2), ((scene.ow.allholes[i].mapId)), true, "Hole[" + i.ToString("D2") + "]" + " Map: " + scene.ow.allentrances[i].mapId.ToString("D3"));

                ROM.WriteShort(Constants.OWHolePos + (i * 2), (((scene.ow.allholes[i].mapPos - 0x400))), true, "Hole[" + i.ToString("D2") + "]" + " Pos: " + scene.ow.allentrances[i].mapPos.ToString("D3"));

                ROM.Write(Constants.OWHoleEntrance + i, (byte)((scene.ow.allholes[i].entranceId) & 0xFF), true, "Hole[" + i.ToString("D2") + "]" + " Entrance Leading To: " + scene.ow.allentrances[i].entranceId.ToString("D3"));
            }
            ROM.EndBlockLogWriting();
            //WriteLog("Overworld Entrances data loaded properly", Color.Green);
            return false;
        }

        public bool saveOWItems(SceneOW scene)
        {

            ROM.StartBlockLogWriting("Items OW DATA & Pointers", Constants.overworldItemsPointers);
            List<RoomPotSaveEditor>[] roomItems = new List<RoomPotSaveEditor>[128];
            for (int i = 0; i < 128; i++)
            {
                roomItems[i] = new List<RoomPotSaveEditor>();
                foreach (RoomPotSaveEditor item in scene.ow.allitems)
                {
                    if (item.roomMapId == i)
                    {
                        roomItems[i].Add(item);
                    }
                }
            }
            

            int dataPos = Constants.overworldItemsPointers + 0x100;

            int[] itemPtrs = new int[128];
            int[] itemPtrsReuse = new int[128];

            for (int i = 0; i < 128; i++)
            {
                itemPtrsReuse[i] = -1;
                if (roomItems[i].Count == 0)
                {
                    itemPtrsReuse[i] = 500;
                }
                else
                {
                    for (int ci = 0; ci < 128; ci++)
                    {
                        if (ci >= i)
                        {
                            break;
                        }
                        if (i != ci)
                        {
                            if (compareItemsArrays(roomItems[i].ToArray(), roomItems[ci].ToArray()))
                            {

                                itemPtrsReuse[i] = ci;

                            }
                        }
                    }
                }
            }

            int emptyPtr = 0;
            for (int i = 0; i < 128; i++)
            {
                if (itemPtrsReuse[i] == -1)
                {
                    itemPtrs[i] = dataPos;
                    foreach (RoomPotSaveEditor item in roomItems[i])
                    {
                        short mapPos = (short)(((item.gameY << 6) + item.gameX) << 1);

                        byte b1 = (byte)((mapPos >> 8));//1111 1111 0000 0000
                        byte b2 = (byte)(mapPos & 0xFF);//0000 0000 1111 1111
                        byte b3 = (byte)(item.id);

                        byte[] data = new byte[3] { b2, b1, b3 };
                        ROM.Write(dataPos, data, true, "Item Data");
                        dataPos += 3;

                    }
                    emptyPtr = dataPos;
                    ROM.WriteShort(dataPos, 0xFFFF, true, "End Item Data");
                    dataPos += 2;
                }
                else if (itemPtrsReuse[i] == 500)
                {
                    itemPtrs[i] = emptyPtr;
                }
                else
                {
                    itemPtrs[i] = itemPtrs[itemPtrsReuse[i]];
                }

                int snesaddr = Utils.PcToSnes(itemPtrs[i]);
                ROM.WriteShort(Constants.overworldItemsPointers + (i * 2), (snesaddr), true, "Item Pointer for room"+i.ToString("D3"));
            }

            if (dataPos> Constants.overworldItemsEndData)
            {
                Console.WriteLine("Items : " + dataPos.ToString("X6"));
                return true;
            }
            ROM.EndBlockLogWriting();


            return false;

        }


        public bool SaveOWSprites(SceneOW scene)
        {
            ROM.StartBlockLogWriting("Sprites OW DATA & Pointers", Constants.overworldSpritesBegining);
            int[] sprPointers = new int[352]; // 352 all of them
            int[] sprPointersReused = new int[352]; // 352 all of them
            for(int j = 0; j<352;j++)
            {
                sprPointersReused[j] = -1;
            }
            //TODO : for the release compare every maps and reuses sprites
            List<Sprite>[] sprBegining = new List<Sprite>[64];
            List<Sprite>[] sprZelda = new List<Sprite>[144];
            List<Sprite>[] sprAgahnim = new List<Sprite>[144];
            for (int i = 0; i < 144; i++) //for each maps
            {
                sprZelda[i] = new List<Sprite>();
                sprAgahnim[i] = new List<Sprite>();
                if (i < 64)
                {
                    sprBegining[i] = new List<Sprite>();
                }
            }


            for (int i = 0; i < 144; i++) //for each maps
            {
                if (i < 64)
                {
                    foreach (Sprite spr in scene.ow.allmaps[i].sprites[0])
                    {
                        sprBegining[spr.mapid].Add(spr);
                    }

                }
                if (i >= 64)
                {
                    foreach (Sprite spr in scene.ow.allmaps[i].sprites[0])
                    {
                        sprZelda[spr.mapid].Add(spr);
                    }
                }
                else
                {
                    foreach (Sprite spr in scene.ow.allmaps[i].sprites[1])
                    {
                        sprZelda[spr.mapid].Add(spr);
                    }
                }

                foreach (Sprite spr in scene.ow.allmaps[i].sprites[2])
                {
                    sprAgahnim[spr.mapid].Add(spr);
                }
            }

            //CB41 = empty pointer
            int ii = 0; //pointer index
            int ci = 0; //compare index;
            for (int j = 0; j < 64; j++)
            {
                if (sprBegining[j].Count == 0)
                {
                    sprPointersReused[ii] = 0;
                }
                else
                {
                    //compare with every other
                    for (int k = 0; k < 64; k++)
                    {
                        if (ci != ii) //are we looking at the same map?
                        {
                            if (sprBegining[j].Count == sprBegining[k].Count) //do that map have same amount of sprites?
                            {
                                if (compareSpriteArrays(sprBegining[j].ToArray(), sprBegining[k].ToArray()))
                                {
                                    //Found a matching pointer we can use
                                    //pointer might not be assigned at that point...
                                    if (ci < ii)//if room id we're comparing is smaller than current room, otherwise not assigned will be later!
                                    {
                                        sprPointersReused[ii] = ci;
                                    }
                                }
                            }
                        }
                        ci++;
                    }

                }
                ii++;
            }
            for (int j = 0; j < 144; j++)
            {
                if (sprZelda[j].Count == 0)
                {
                    sprPointersReused[ii] = 0;
                }
                else
                {
                                        for (int k = 0; k < 144; k++)
                    {
                        if (ci != ii) //are we looking at the same map?
                        {
                            if (sprZelda[j].Count == sprZelda[k].Count) //do that map have same amount of sprites?
                            {
                                if (compareSpriteArrays(sprZelda[j].ToArray(), sprZelda[k].ToArray()))
                                {
                                    //Found a matching pointer we can use
                                    //pointer might not be assigned at that point...
                                    if (ci < ii)//if room id we're comparing is smaller than current room, otherwise not assigned will be later!
                                    {
                                        sprPointersReused[ii] = ci;
                                    }
                                }
                            }
                        }
                        ci++;
                    }
     
                }
                ii++;
            }
            for (int j = 0; j < 144; j++)
            {
                if (sprAgahnim[j].Count == 0)
                {
                    sprPointersReused[ii] = 0;
                }
                else
                {
                    for (int k = 0; k < 144; k++)
                    {
                        if (ci != ii) //are we looking at the same map?
                        {
                            if (sprAgahnim[j].Count == sprAgahnim[k].Count) //do that map have same amount of sprites?
                            {
                                if (compareSpriteArrays(sprAgahnim[j].ToArray(), sprAgahnim[k].ToArray()))
                                {
                                    //Found a matching pointer we can use
                                    //pointer might not be assigned at that point...
                                    if (ci < ii)//if room id we're comparing is smaller than current room, otherwise not assigned will be later!
                                    {
                                        sprPointersReused[ii] = ci;
                                    }
                                }
                            }
                        }
                        ci++;
                    }
                }
                ii++;
            }

            int dataPos = 0x4CB42;
            //END OF OW SPRITES DATA = 0x4D62E
            ROM.Write(0x4CB41,0xFF);//empty sprite data
                                     //0x4CB42 // start of rooms data saves
        
            //write sprite data if sprPointersReused[i] == -1


            ii = 0; //pointer index
            
            for (int j = 0; j < 64; j++)
            {
                if (sprPointersReused[ii] == -1)
                {
                    sprPointers[ii] = dataPos;
                    foreach (Sprite spr in sprBegining[j])
                    {

                        byte b1 = spr.y;
                        byte b2 = spr.x;
                        byte b3 = spr.id;
                        byte[] data = new byte[3] {b1,b2,b3 };
                        ROM.Write(dataPos, data, true, "Spr Data");
                        dataPos += 3;
                    }
                    //add FF to end the room
                    ROM.Write(dataPos, 0xFF, true, "Termination Byte");
                    dataPos++;
                }
                ii++;
            }
            for (int j = 0; j < 144; j++)
            {
                if (sprPointersReused[ii] == -1)
                {
                    sprPointers[ii] = dataPos;
                    foreach (Sprite spr in sprZelda[j])
                    {
                        byte b1 = spr.y;
                        byte b2 = spr.x;
                        byte b3 = spr.id;
                        byte[] data = new byte[3] { b1, b2, b3 };
                        ROM.Write(dataPos, data, true, "Spr Data");
                        dataPos += 3;
                    }
                    //add FF to end the room
                    ROM.Write(dataPos, 0xFF, true, "Termination Byte");
                    dataPos++;
                }
                ii++;
            }
            for (int j = 0; j < 144; j++)
            {
                if (sprPointersReused[ii] == -1)
                {
                    
                    sprPointers[ii] = dataPos;
                    foreach (Sprite spr in sprAgahnim[j])
                    {

                        byte b1 = spr.y;
                        byte b2 = spr.x;
                        byte b3 = spr.id;
                        byte[] data = new byte[3] { b1, b2, b3 };
                        ROM.Write(dataPos, data, true, "Spr Data");
                        dataPos += 3;
                    }
                    //add FF to end the room
                    ROM.Write(dataPos, 0xFF, true, "Termination Byte");
                    dataPos++;
                }
                ii++;
            }

            if (dataPos > 0x4D62E)
            {
                //Console.WriteLine("Position " + dataPos.ToString("X6"));
                return true; //error
            }

            sprPointers[0] = 0x4CB41;
            for (int j=0;j<352;j++)
            {
                if (sprPointersReused[j] != -1)
                {
                    sprPointers[j] = sprPointers[sprPointersReused[j]];
                }
                
                int snesaddr = Utils.PcToSnes(sprPointers[j]);
                ROM.WriteShort(Constants.overworldSpritesBegining + (j * 2), snesaddr, true, "Sprite Header");
            }
            ROM.EndBlockLogWriting();
            return false; //no errors
        }

        public bool compareSpriteArrays(Sprite[] spr1, Sprite[] spr2)
        {

            bool match = false;
            for (int i = 0; i < spr1.Length; i++)
            {

                match = false;
                for (int j = 0; j < spr2.Length; j++)
                {
                    //check all sprite in 2nd array if one match
                    if (spr1[i].x == spr2[j].x &&
                        spr1[i].y == spr2[j].y &&
                        spr1[i].id == spr2[j].id &&
                        spr1[i].mapid == spr2[j].mapid)
                    {
                        match = true;
                        break;
                    }
                }
                if (match == false)
                {
                    return false;
                }

            }
            return true;
        }

        public bool compareItemsArrays(RoomPotSaveEditor[] itm1, RoomPotSaveEditor[] itm2)
        {

            bool match = false;
            for (int i = 0; i < itm1.Length; i++)
            {

                match = false;
                for (int j = 0; j < itm2.Length; j++)
                {
                    //check all sprite in 2nd array if one match
                    if (itm1[i].x == itm2[j].x &&
                        itm1[i].y == itm2[j].y &&
                        itm1[i].id == itm2[j].id &&
                        itm1[i].roomMapId == itm2[j].roomMapId)
                    {
                        match = true;
                        break;
                    }
                }
                if (match == false)
                {
                    return false;
                }

            }
            return true;
        }



        public bool saveOWTransports(SceneOW scene)
        {
            ROM.StartBlockLogWriting("Transports Data", Constants.OWExitMapIdWhirlpool);
            for (int i = 0; i < 0x11; i++)
            {


                ROM.WriteShort(Constants.OWExitMapIdWhirlpool + (i * 2), (scene.ow.allWhirlpools[i].mapId), true, "MapId");

                ROM.WriteShort(Constants.OWExitXScrollWhirlpool + (i * 2), (scene.ow.allWhirlpools[i].xScroll), true, "XScroll");

                ROM.WriteShort(Constants.OWExitYScrollWhirlpool + (i * 2), (scene.ow.allWhirlpools[i].yScroll), true, "YScroll");

                ROM.WriteShort(Constants.OWExitXCameraWhirlpool + (i * 2), (scene.ow.allWhirlpools[i].cameraX), true, "XCamera");

                ROM.WriteShort(Constants.OWExitYCameraWhirlpool + (i * 2), (scene.ow.allWhirlpools[i].cameraY), true, "YCamera");

                ROM.WriteShort(Constants.OWExitVramWhirlpool + (i * 2), (scene.ow.allWhirlpools[i].vramLocation), true, "VRAM");

                ROM.WriteShort(Constants.OWExitXPlayerWhirlpool + (i * 2), (scene.ow.allWhirlpools[i].playerX), true, "XPlayer");

                ROM.WriteShort(Constants.OWExitYPlayerWhirlpool + (i * 2), (scene.ow.allWhirlpools[i].playerY), true, "YPlayer");

                if (i > 8)
                {
                    ROM.WriteShort(Constants.OWWhirlpoolPosition + ((i - 9) * 2), (scene.ow.allWhirlpools[i].whirlpoolPos), true, "Pos");
                }
            }
            ROM.EndBlockLogWriting();
            return false;
        }

        public bool saveMapProperties(SceneOW scene)
        {
            ROM.StartBlockLogWriting("Map Properties", Constants.mapGfx);

            for (int i = 0; i < 64; i++)
            {
                ROM.Write(Constants.mapGfx + i, scene.ow.allmaps[i].gfx,true, "Gfx");
                ROM.Write(Constants.overworldSpriteset + i, scene.ow.allmaps[i].sprgfx[0], true, "Spriteset");
                ROM.Write(Constants.overworldSpriteset + 64 + i, scene.ow.allmaps[i].sprgfx[1], true, "Spriteset");
                ROM.Write(Constants.overworldSpriteset + 128 + i, scene.ow.allmaps[i].sprgfx[2], true, "Spriteset");
                ROM.Write(Constants.overworldMapPalette + i, scene.ow.allmaps[i].palette, true, "Palette");
                ROM.Write(Constants.overworldSpritePalette + i, scene.ow.allmaps[i].sprpalette[0], true, "SprPalette");
                ROM.Write(Constants.overworldSpritePalette + 64 + i, scene.ow.allmaps[i].sprpalette[1], true, "SprPalette");
                ROM.Write(Constants.overworldSpritePalette + 128 + i, scene.ow.allmaps[i].sprpalette[2], true, "SprPalette");
            }
            for (int i = 64; i < 128; i++)
            {
                ROM.Write(Constants.mapGfx + i, scene.ow.allmaps[i].gfx, true, "Gfx");
                ROM.Write(Constants.overworldSpriteset + 128 + i, scene.ow.allmaps[i].sprgfx[0], true, "Spriteset");
                ROM.Write(Constants.overworldSpriteset + 128 + i, scene.ow.allmaps[i].sprgfx[1], true, "Spriteset");
                ROM.Write(Constants.overworldSpriteset + 128 + i, scene.ow.allmaps[i].sprgfx[2], true, "Spriteset");
                ROM.Write(Constants.overworldMapPalette + i, scene.ow.allmaps[i].palette, true, "Palette");
                ROM.Write(Constants.overworldSpritePalette + 128 + i, scene.ow.allmaps[i].sprpalette[0], true, "SprPalette");
                ROM.Write(Constants.overworldSpritePalette + 128 + i, scene.ow.allmaps[i].sprpalette[1], true, "SprPalette");
                ROM.Write(Constants.overworldSpritePalette + 128 + i, scene.ow.allmaps[i].sprpalette[2], true, "SprPalette");
            }
            ROM.EndBlockLogWriting();
            return false;
        }

        public bool saveMapOverlays(SceneOW scene)
        {
            ROM.StartBlockLogWriting("Map Overlays", Constants.mapGfx);


            byte[] newOverlayCode = new byte[]
            {
                0xC2, 0x30, //REP #$30
                0xA5, 0x8A, //LDA $8A
                0x0A, 0x18, //ASL : CLC
                0x65, 0x8A, //ADC $8A
                0xAA, //TAX
                0xBF, 0x00, 0x00, 0x00, //LDA, X 
                0x85, 0x00, //STA $00
                0xBF, 0x00, 0x00, 0x00, //LDA, X +2
                0x85, 0x02, //STA $02
                0x4B, //PHK
                0xF4, 0x00, 0x00, //this position +3 ?
                0xDC, 0x00, 0x00, //JML [$00 00]
                0xE2, 0x30, //SEP #$30
                0xAB, //PLB
                0x6B //RTL
            };
            //Pointers

            ROM.Write(0x77657, newOverlayCode, true, "New Overlay Code");

            int ptrStart = (0x77657 + 32);
            int snesptrstart = Utils.PcToSnes(ptrStart);
            //10, 16, 
            ROM.WriteLong(0x77657 + 10, snesptrstart, true, "Overlay Pointerp1");
            ROM.WriteLong(0x77657 + 16, snesptrstart+2, true, "Overlay Pointerp2");



            int peaAddr = Utils.PcToSnes(0x77657 + 27);

            ROM.WriteShort(0x77657 + 23, peaAddr, true, "Pea Addr (don't ask)");

            //TODO : Optimize that routine to be smaller

            //0x058000
            int pos = 0x58000;
            int ptrPos = 0x77657+32;
            for(int i = 0;i<128;i++)
            {
                int snesaddr = Utils.PcToSnes(pos);
                ROM.WriteLong(ptrPos, snesaddr, true, "Overlay actual Pointers");
                ptrPos += 3;

                for (int t = 0;t < scene.ow.alloverlays[i].tilesData.Count; t++)
                {
                    ushort addr = (ushort)((scene.ow.alloverlays[i].tilesData[t].x * 2) + (scene.ow.alloverlays[i].tilesData[t].y * 128) + 0x2000);
                    //LDA TileID : STA $addr
                    //A9 (LDA #$)
                    //A2 (LDX #$)
                    //8D (STA $xxxx)

                    //LDA :
                    ROM.Write(pos, 0xA9,true, "Overlay Data, LDA");
                    ROM.WriteShort(pos+1, (scene.ow.alloverlays[i].tilesData[t].tileId), true, "Overlay Data, TileID");
                    pos += 3;
                    //STA : 
                    ROM.Write(pos, 0x8D, true, "Overlay Data, STA");
                    ROM.WriteShort(pos+1, addr, true, "Overlay Data, TilePos");
                    pos += 3;


                }
                ROM.Write(pos, (byte)(0x6B),true,"RTL"); //RTL
                pos++;

            }


            ROM.EndBlockLogWriting();
            return false;
        }

        public bool saveOverworldTilesType(SceneOW scene)
        {
            ROM.StartBlockLogWriting("Overworld Tiles Types", Constants.overworldTilesType);
            for(int i = 0;i<0x200;i++)
            {
                ROM.Write(Constants.overworldTilesType + i, scene.ow.allTilesTypes[i], true, "Tile ID" + i.ToString("D3") + " Type:" + scene.ow.allTilesTypes[i].ToString("D3"));
            }
            ROM.EndBlockLogWriting();
            return false;
        }

        //ROM MAP
        //0x110000 (S:228000) are rooms header Length 0x12C0 (Always the same size)
        //120000 to 1343C0 (S:248000 to 26C3C0) are new overworld maps location always same size (fake compressed)
        //0x058000 (OLD MAP DATA) Now Used for Overlays data


        //0x6452A  // HOOK Replaced Code : INC $15 : LDA.b #$03
        //1351C0 / 26D1C0 end of tilemap data where the jump code should be for DMA


        public bool saveTitleScreen(DungeonMain mainForm)
        {
            /*int pos = 0x1343C0;
            //134AC0 = BG2
            for (int i = 0; i < 0x380; i++)
            {
                ROM.WriteShort(pos, mainForm.screenEditor.tilesBG1Buffer[i], true, "Screen");
                ROM.WriteShort(pos+0x700, mainForm.screenEditor.tilesBG2Buffer[i], true, "Screen");
                pos += 2;
                
            }
            */
            return false;
        }




        public bool saveOverworldMessagesIds(SceneOW scene)
        {
            ROM.StartBlockLogWriting("Overworld Messages IDs", Constants.overworldMessages);

            for (int i = 0;i <128;i++)
            {
                ROM.WriteShort(Constants.overworldMessages + (i*2),scene.ow.allmaps[i].messageID, true, "OW Message ID for map " + i.ToString("D3"));

            }
            ROM.EndBlockLogWriting();

            return false;

        }



        public bool saveOverworldMusics(SceneOW scene)
        {
            ROM.StartBlockLogWriting("Overworld Musics IDs", Constants.overworldMessages);

            for (int i = 0; i < 64; i++)
            {
                ROM.Write(Constants.overworldMusicBegining + i, scene.ow.allmaps[i].musics[0], true, "OW Musics ID for map " + i.ToString("D3"));
                ROM.Write(Constants.overworldMusicZelda + i, scene.ow.allmaps[i].musics[1], true, "OW Musics ID for map " + i.ToString("D3"));
                ROM.Write(Constants.overworldMusicMasterSword + i, scene.ow.allmaps[i].musics[2], true, "OW Musics ID for map " + i.ToString("D3"));
                ROM.Write(Constants.overworldMusicAgahim + i, scene.ow.allmaps[i].musics[3], true, "OW Musics ID for map " + i.ToString("D3"));

            }

            for (int i = 0; i < 64; i++)
            {
                ROM.Write(Constants.overworldMusicDW + i, scene.ow.allmaps[i].musics[0], true, "OW Musics ID for map " + (i+64).ToString("D3"));

            }
            ROM.EndBlockLogWriting();

            return false;

        }


        //TODO : OW Message Load/Save
        //OW Musics Saves


    }
}
