using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using AsarCLR;
using ZCompressLibrary;

namespace ZeldaFullEditor
{
    internal class Save
    {
        // ROM.DATA is a base rom loaded to get basic information it can either be JP1.0 or US1.2.
        private Room[] AllRooms;

        private int[] roomTilesPointers = new int[Constants.NumberOfRooms];
        private int[] roomDoorsPointers = new int[Constants.NumberOfRooms];
        private int saddr = 0;

        private byte[][] mapDatap1 = new byte[Constants.NumberOfOWMaps][];
        private byte[][] mapDatap2 = new byte[Constants.NumberOfOWMaps][];
        private int[] mapPointers1id = new int[Constants.NumberOfOWMaps];
        private int[] mapPointers2id = new int[Constants.NumberOfOWMaps];

        private int[] mapPointers1 = new int[Constants.NumberOfOWMaps];
        private int[] mapPointers2 = new int[Constants.NumberOfOWMaps];

        private DungeonMain MainForm;

        public Save(Room[] allRooms, DungeonMain mainForm)
        {
            this.AllRooms = allRooms;
            this.MainForm = mainForm;
        }

        public bool saveEntrances(Entrance[] entrances, Entrance[] startingentrances)
        {
            for (int i = 0; i < 0x84; i++)
            {
                entrances[i].save(i);
            }
            for (int i = 0; i < 0x07; i++)
            {
                startingentrances[i].save(i, true);
            }

            return false;
        }

        public bool saveRoomsHeaders()
        {
            // Long??
            int headerPointer = GetLongPointerSNESToPC(Constants.room_header_pointer);
            if (headerPointer < 0x100000)
            {
                var movePointer = new MovePointer();
                movePointer.ShowDialog();
                headerPointer = movePointer.address;

                int address = Utils.PcToSnes(movePointer.address);
                ROM.WriteLong(Constants.room_header_pointer, address, true, "Header Pointers Location");
                ROM.Write(Constants.room_header_pointers_bank, ROM.DATA[Constants.room_header_pointer + 2], true, "Header Bank");
            }

            ROM.StartBlockLogWriting("Room Headers", headerPointer);
            for (int i = 0; i < Constants.NumberOfRooms; i++)
            {
                int newPointerAddress = (Utils.PcToSnes((headerPointer + 640) + (i * 14)));
                ROM.WriteShort((headerPointer) + (i * 2), newPointerAddress, true, "Header " + i.ToString("D3") + " Pointer");
                saveHeader((headerPointer + 640), i);
            }

            ROM.EndBlockLogWriting();

            ROM.StartBlockLogWriting("Rooms Messages", Constants.messages_id_dungeon);
            //ROM.SaveLogs();
            for (int i = 0; i < Constants.NumberOfRooms; i++)
            {
                ROM.WriteShort(Constants.messages_id_dungeon + (i * 2), this.AllRooms[i].messageid, true, "Message Room ID : " + i.ToString("D3"));
            }

            ROM.EndBlockLogWriting();
            return false; // False = no error.
        }

        public int GetLongPointerSNESToPC(int pos)
        {
            return (Utils.SnesToPc(ROM.ReadLong(pos)));
        }

        public bool saveBlocks()
        {
            // If we reach 0x80 size jump to pointer2 etc...
            int[] region = new int[4] { Constants.blocks_pointer1, Constants.blocks_pointer2, Constants.blocks_pointer3, Constants.blocks_pointer4 };
            int blockCount = 0;
            int roomIndex = 0;
            int pos = this.GetLongPointerSNESToPC(region[roomIndex]);
            int count = 0;
            ROM.StartBlockLogWriting("Blocks Data", pos);

            for (int i = 0; i < Constants.NumberOfRooms; i++)
            {
                foreach (Room_Object rooom in this.AllRooms[i].tilesObjects)
                {
                    if ((rooom.options & ObjectOption.Block) == ObjectOption.Block) // If we find a block save it.
                    {
                        int xy = (((rooom.Y * 64) + rooom.X) << 1);
                        byte[] data = new byte[4] {
                            (byte)((i & 0xFF)),
                            (byte)(((i >> 8) & 0xFF)),
                            (byte)(xy & 0xFF),
                            (byte)(((xy >> 8) & 0x1F) + ((byte)rooom.Layer * 0x20))
                        };

                        ROM.Write(pos, data, true, string.Format("Room: {0:3X} | X: {1:2X}, Y: {2:2X}, L: {3:2X}", i, rooom.X, rooom.Y, rooom.Size));

                        pos += 4;
                        count += 4;
                        if (count >= 0x80)
                        {
                            roomIndex++;
                            pos = this.GetLongPointerSNESToPC(region[roomIndex]);
                            count = 0;
                        }

                        blockCount++;
                    }
                }
            }

            if (blockCount > 99)
            {
                return true; // False = no error.
            }

            ROM.EndBlockLogWriting();

            /*
            if (b3 == 0xFF && b4 == 0xFF) { break; }
            int address = ((b4 & 0x1F) << 8 | b3) >> 1;
            int px = address % 64;
            int py = address >> 6;
            Room_Object r = addObject(0x0E00, (byte)(px), (byte)(py), 0, (byte)((b4 & 0x20) >> 5));
            */

            return false; // False = no error.
        }

        public bool saveCustomCollision()
        {
            Console.WriteLine("Saving Custom Collision");
            /*
            Format:
                dw<offset> : db width, height
                dw < tile data >, ...
                if < offset > == $F0F0, start doing single tiles
                format:
                dw<offset> : db<tiledata>
                if < offset > == $FFFF, stop
            */

            int room_pointer = Constants.customCollisionRoomPointers; // @zarby: save all 320 rooms pointers to 0x128000.
            int data_pointer = Constants.customCollisionDataPosition; // @zarby: the actual data at 0x1283C0.

            Console.WriteLine(room_pointer + " " + data_pointer);

            //for ( int i = 0; i < Constants.NumberOfRooms; i++ )
            foreach (Room room in this.AllRooms)
            {
                // @zarby: for each room -> ROM.WriteLong(0x100000), Utils.PcToSnes(ptrsCounter))
                //         write pointers where data start + previous room data length.

                // Clear the room's rectangle list and then re-populate it.
                room.ClearCollisionLayout();
                room.loadCollisionLayout(false);

                // If there is triangle in the room, write the room pointer, otherwise wrtie 000000.
                if (room.collision_rectangles.Count() > 0)
                {
                    ROM.WriteLong(room_pointer, Utils.PcToSnes(data_pointer));
                }
                else
                {
                    ROM.WriteLong(room_pointer, 0x000000);
                }

                room_pointer += 3;

                foreach (var rectangle in room.collision_rectangles)
                {
                    Console.WriteLine(rectangle.ToString());

                    ROM.WriteShort(data_pointer, rectangle.index_data);
                    data_pointer += 2;
                    ROM.WriteShort(data_pointer, rectangle.width);
                    data_pointer += 1;
                    ROM.WriteShort(data_pointer, rectangle.height);
                    data_pointer += 1;
                    for (int j = 0; j < rectangle.width * rectangle.height; j++)
                    {
                        ROM.WriteShort(data_pointer, rectangle.tile_data[j]);
                        data_pointer += 1;
                    }

                    //ROM.WriteLong(data_pointer, 0x000000);
                    //data_pointer += 3;
                }

                // Add 0xFFFF to the end of this rooms list to tell the ASM to stop here.
                if (room.collision_rectangles.Count() > 0)
                {
                    ROM.WriteLong(data_pointer, 0x00FFFF);
                    data_pointer += 2;
                }
            }

            string projectFilename = MainForm.projectFilename;

            Asar.init();

            // TODO: handle differently in projects.
            if (File.Exists("CustomCollision.asm"))
            {
                Console.WriteLine("Applying Custom Collision ASM");
                Asar.patch("CustomCollision.asm", ref ROM.DATA);
            }
            else
            {
                UIText.CryAboutSaving("Missing ASM file 'CustomCollision.asm'.\nSaving will continue but the ASM will not be applied.");
            }

            foreach (Asarerror error in Asar.geterrors())
            {
                Console.WriteLine(error.Fullerrdata.ToString());
                return true;
            }

            return false;
        }

        public bool saveAreaSpecificBG(bool enabled)
        {
            Asar.init();

            // TODO: handle differently in projects.
            if (File.Exists("AreaSpecificBGColor.asm"))
            {
                Console.WriteLine("Saving Area Specific BG colors ASM");
                Asar.patch("AreaSpecificBGColor.asm", ref ROM.DATA);
            }
            else
            {
                UIText.CryAboutSaving("Missing ASM file 'AreaSpecificBGColor.asm'.\nSaving will continue but the ASM will not be applied.");
            }

            if (enabled)
            {
                ROM.Write(Constants.customAreaSpecificBGEnabled, 0xFF, true, "Enabled area specific BG color");
            }
            else
            {
                ROM.Write(Constants.customAreaSpecificBGEnabled, 0x00, true, "Disabled area specific BG color");
            }

            foreach (Asarerror error in Asar.geterrors())
            {
                Console.WriteLine(error.Fullerrdata.ToString());
                return true;
            }

            return false;
        }

        public bool saveOverworldMosaic(SceneOW scene)
        {
            Console.WriteLine("Saving Overworld Custom Mosaic ASM");

            for (int i = 0; i < scene.ow.allmaps.Length; i++)
            {
                if (scene.ow.allmaps[i].mosaic)
                {
                    ROM.Write(Constants.overworldCustomMosaicArray + i, 0x01);
                }
                else
                {
                    ROM.Write(Constants.overworldCustomMosaicArray + i, 0x00);
                }
            }

            Asar.init();

            // TODO: handle differently in projects.
            if (File.Exists("MosaicChange.asm"))
            {
                Asar.patch("MosaicChange.asm", ref ROM.DATA);
            }
            else
            {
                UIText.CryAboutSaving("Missing ASM file 'MosaicChange.asm'.\nSaving will continue but the ASM will not be applied.");
            }

            foreach (Asarerror error in Asar.geterrors())
            {
                Console.WriteLine(error.Fullerrdata.ToString());
                return true;
            }

            return false;
        }

        public bool saveTorches()
        {
            int bytes_count = ROM.ReadShort(Constants.torches_length_pointer);

            int pos = Constants.torch_data;
            ROM.StartBlockLogWriting("Torches Data", pos);
            // 288 torches?

            for (int i = 0; i < Constants.NumberOfRooms; i++)
            {
                bool foundTorchInRoom = false;
                foreach (Room_Object room in this.AllRooms[i].tilesObjects)
                {
                    // If we find a torch.
                    if ((room.options & ObjectOption.Torch) == ObjectOption.Torch)
                    {
                        // If we find a torch then store room if it not stored.
                        if (!foundTorchInRoom)
                        {
                            ROM.WriteShort(pos, i, true, "Torches in room " + i.ToString("D3"));
                            pos += 2;
                            foundTorchInRoom = true;
                        }

                        int xy = (((room.Y * 64) + room.X) << 1);
                        byte value1 = (byte)(xy & 0xFF);
                        ROM.Write(pos++, value1, WriteType.TorchData);
                        byte value2 = (byte)((xy >> 8) & 0xFF);

                        if ((byte)room.Layer == 1)
                        {
                            value2 |= 0x20;
                        }

                        value2 |= (byte)((room.lit ? 1 : 0) << 7);
                        ROM.Write(pos++, value2, WriteType.TorchData);
                    }
                }
                if (foundTorchInRoom)
                {
                    ROM.WriteShort(pos, 0xFFFF);
                    pos += 2;
                }
            }

            if ((pos - Constants.torch_data) > 0x120)
            {
                return true;
            }
            else
            {
                short npos = (short)(pos - Constants.torch_data);
                ROM.WriteShort(Constants.torches_length_pointer, npos);
            }

            ROM.EndBlockLogWriting();
            return false; // False = no error.
        }

        public void saveHeader(int pos, int i)
        {
            byte[] headerData = new byte[14]
            {
                (byte)((((byte)this.AllRooms[i].bg2 & 0x07) << 5) + ((int)this.AllRooms[i].collision << 2) + (this.AllRooms[i].light ? 1 : 0)),
                this.AllRooms[i].palette,
                this.AllRooms[i].blockset,
                this.AllRooms[i].spriteset,
                ((byte)this.AllRooms[i].effect),
                ((byte)this.AllRooms[i].tag1),
                ((byte)this.AllRooms[i].tag2),
                (byte)((this.AllRooms[i].holewarp_plane) + (this.AllRooms[i].staircase1Plane << 2) + (this.AllRooms[i].staircase2Plane << 4) + (this.AllRooms[i].staircase3Plane << 6)),
                this.AllRooms[i].staircase4Plane,
                this.AllRooms[i].holewarp,
                this.AllRooms[i].staircase1,
                this.AllRooms[i].staircase2,
                this.AllRooms[i].staircase3,
                this.AllRooms[i].staircase4,
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

            for (int i = 0; i < Constants.NumberOfRooms; i++)
            {
                if (this.AllRooms[i].damagepit)
                {
                    ROM.WriteShort(pitPointer, this.AllRooms[i].index, true);
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

        public bool saveAllObjects()
        {
            var section1Index = 0x50008; // 0x50000 to 0x5374F  // 53730.
            var section2Index = 0xF878A; // 0xF878A to 0xFFFFF.
            var section3Index = 0x1EB90; // 0x1EB90 to 0x1FFFF.
            var section4Index = 0x1112C0; // If vanilla space is used use expanded region.
            int section4Start = 0x1112C0;
            bool usedSection4 = false;
            /*
            while (ROM.DATA[section4Index] != 0)
            {
                 //section4Index += 0x010000;
            }
            */

            // Check if room is already using that space first before skipping position!!
            section4Start = section4Index;
            // Reorder room from bigger to lower.

            for (int i = 0; i < Constants.NumberOfRooms; i++)
            {
                var roomBytes = this.AllRooms[i].getTilesBytes();
                int doorPos = roomBytes.Length - 2;

                if (roomBytes.Length < 10)
                {
                    this.saveObjectBytes(this.AllRooms[i].index, 0x50000, roomBytes, doorPos); // Empty room pointer.
                    continue;
                }

                while (true)
                {
                    if (doorPos >= 04)
                    {
                        if (roomBytes[doorPos] == 0xF0 && roomBytes[doorPos + 1] == 0xFF)
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

                if (section1Index + roomBytes.Length <= 0x53730) // 0x50000 to 0x5374F.
                {
                    // Write the room.
                    this.saveObjectBytes(this.AllRooms[i].index, section1Index, roomBytes, doorPos);
                    section1Index += roomBytes.Length;
                    continue;
                }
                else if (section2Index + roomBytes.Length <= 0xFFFFF) // 0xF878A to 0xFFFF7.
                {
                    // Write the room.
                    this.saveObjectBytes(this.AllRooms[i].index, section2Index, roomBytes, doorPos);
                    section2Index += roomBytes.Length;
                    continue;
                }
                else if (section3Index + roomBytes.Length <= 0x1FFFF) // 0x1EB90 to 0x1FFFF.
                {
                    // Write the room.
                    this.saveObjectBytes(this.AllRooms[i].index, section3Index, roomBytes, doorPos);
                    section3Index += roomBytes.Length;
                    continue;
                }
                else
                {
                    // Ran out of space.
                    // Write the room.
                    //saveObjectBytes(i, section4Index, roomBytes);
                    //section4Index += roomBytes.Length;
                    saveObjectBytes(this.AllRooms[i].index, section4Index, roomBytes, doorPos);
                    section4Index += roomBytes.Length;
                    usedSection4 = true;
                    continue;
                    // Move to EXPANDED region.
                    //Console.WriteLine("Room " + i + " no more space jump to 0x121210");
                    //currentPos = 0x121210;
                    //MessageBox.Show("We are running out space in the original portion of the ROM next data will be writed to : 0x121210");
                }
            }

            if (usedSection4)
            {
                Console.WriteLine("Used section4 for tiles index at location : " + section4Start.ToString("X6") + "Length of :" + (section4Index - section4Start).ToString("X6"));
            }

            int objectPointer = Utils.SnesToPc(ROM.ReadLong(Constants.room_object_pointer));
            ROM.StartBlockLogWriting("Room And Doors Pointers", objectPointer);
            for (int i = 0; i < Constants.NumberOfRooms; i++)
            {
                ROM.WriteLong(objectPointer + (i * 3), roomTilesPointers[i], true, "Room " + i.ToString("D3") + " Tiles Pointer");
                ROM.WriteLong(Constants.doorPointers + (i * 3), roomDoorsPointers[i], true, "Room " + i.ToString("D3") + " Doors Pointer");
            }

            ROM.EndBlockLogWriting();

            return false; // False = no error.
        }

        private void saveObjectBytes(int roomId, int position, byte[] bytes, int doorOffset)
        {
            int objectPointer = Utils.SnesToPc(ROM.ReadLong(Constants.room_object_pointer));
            this.saddr = Utils.PcToSnes(position);
            this.roomTilesPointers[roomId] = this.saddr;
            int daddr = Utils.PcToSnes(position + doorOffset);
            this.roomDoorsPointers[roomId] = daddr;
            // Update the index.

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

                        ROM.romLog.Append(bytes[bp++].ToString("X2") + " ");
                    }

                    ROM.romLog.Append("\r\n");
                }
            }

            Array.Copy(bytes, 0, ROM.DATA, position, bytes.Length);
            ROM.EndBlockLogWriting();
        }

        public bool saveallChests()
        {
            int chestPosition = Utils.SnesToPc(ROM.ReadLong(Constants.chests_data_pointer1));
            int chestCount = 0;
            ROM.StartBlockLogWriting("Chests Data", chestPosition);

            for (int i = 0; i < Constants.NumberOfRooms; i++)
            {
                // Number of possible chests.
                foreach (Chest chest in this.AllRooms[i].chest_list)
                {
                    ushort room_index = (ushort)i;
                    if (chest.bigChest)
                    {
                        room_index |= 0x8000;
                    }

                    byte[] data = new byte[3]
                    {
                        (byte)(room_index & 0xFF),
                        (byte)((room_index >> 8) & 0xFF),
                        chest.item,
                    };

                    ROM.Write(chestPosition, data, true, string.Format("Chest: {0:2X}", i));
                    chestPosition += 3;
                    chestCount++;
                }
            }

            //Console.WriteLine("Nbr of chests : " + chestCount);
            if (chestCount > 168)
            {
                return true; // False = no error.
            }

            ROM.EndBlockLogWriting();
            return false; // False = no error.
        }

        public bool saveallPots()
        {
            int pos = Constants.items_data_start + 2; // Skip 2 FF FF that are empty pointer.
            ROM.StartBlockLogWriting("Pots Items Data", pos);

            for (int i = 0; i < Constants.NumberOfRooms; i++)
            {
                if (this.AllRooms[i].pot_items.Count == 0)
                {
                    ROM.WriteShort(Constants.room_items_pointers + (i * 2), Utils.PcToSnes(Constants.items_data_start), true, "Items Pointer for Room " + i.ToString("D3"));
                    continue;
                }

                // Pointer.
                ROM.WriteShort(Constants.room_items_pointers + (i * 2), Utils.PcToSnes(pos), true, "Items Pointer for Room " + i.ToString("D3"));
                for (int j = 0; j < this.AllRooms[i].pot_items.Count; j++)
                {
                    if (this.AllRooms[i].pot_items[j].layer == 0)
                    {
                        this.AllRooms[i].pot_items[j].bg2 = false;
                    }
                    else
                    {
                        this.AllRooms[i].pot_items[j].bg2 = true;
                    }

                    int xy = (((this.AllRooms[i].pot_items[j].y * 64) + this.AllRooms[i].pot_items[j].x) << 1);

                    byte[] data = new byte[3]
                    {
                       (byte)(xy & 0xFF),
                       (byte)(((xy >> 8) & 0xFF) + (this.AllRooms[i].pot_items[j].bg2 ? 0x20 : 0x00)),
                       this.AllRooms[i].pot_items[j].id
                    };
                    ROM.Write(pos, data, true, "Items Data for Room " + i.ToString("D3"));
                    pos += 3;
                }

                ROM.WriteShort(pos, 0xFFFF, true);
                pos += 2;
                if (pos > Constants.items_data_end)
                {
                    ROM.SaveLogs();
                    return true;
                }
            }

            ROM.EndBlockLogWriting();
            return false; // False = no error.
        }

        /// <summary>
        ///		Tells the text editor to save all the texts.
        /// </summary>
        /// <param name="textEditor"></param>
        /// <returns></returns>
        /// Jared_Brian_: The check box save for the text editor was removed per redundancy.
        public bool saveAllText(TextEditor textEditor)
        {
            return textEditor.Save();
        }

        public bool saveallSprites()
        {
            int spritePointer = (09 << 16) + (ROM.DATA[Constants.rooms_sprite_pointer + 1] << 8) + (ROM.DATA[Constants.rooms_sprite_pointer]);
            int spritePointerPC = Utils.SnesToPc(spritePointer);
            ROM.StartBlockLogWriting("Dungeon Sprites", spritePointerPC);
            byte[] sprites_buffer = new byte[Constants.sprites_end_data - Utils.SnesToPc(spritePointer)];

            // Empty room data = 0x280
            // Start of data = 0x282
            try
            {
                int pos = 0x282;
                // Set empty room.
                sprites_buffer[0x280] = 0x00;
                sprites_buffer[0x281] = 0xFF;

                for (int i = 0; i < 320; i++)
                {
                    if (i >= Constants.NumberOfRooms || this.AllRooms[i].sprites.Count <= 0)
                    {
                        sprites_buffer[(i * 2)] = (byte)((Utils.PcToSnes(Utils.SnesToPc(spritePointer + 0x280)) & 0xFF));
                        sprites_buffer[(i * 2) + 1] = (byte)(((Utils.SnesToPc(spritePointer + 0x280)) >> 8) & 0xFF);
                    }
                    else
                    {
                        // Pointer:
                        sprites_buffer[(i * 2)] = (byte)((Utils.PcToSnes(Utils.SnesToPc(spritePointer + pos)) & 0xFF));
                        sprites_buffer[(i * 2) + 1] = (byte)((Utils.PcToSnes(Utils.SnesToPc(spritePointer + pos)) >> 8) & 0xFF);

                        sprites_buffer[pos++] = (byte)(this.AllRooms[i].sortsprites ? 0x01 : 0x00); // Unknown byte??

                        foreach (Sprite spr in this.AllRooms[i].sprites) // 3bytes
                        {
                            sprites_buffer[pos++] = (byte)((spr.layer << 7) + ((spr.subtype & 0x18) << 2) + spr.y);
                            sprites_buffer[pos++] = (byte)(((spr.subtype & 0x07) << 5) + spr.x);
                            sprites_buffer[pos++] = (spr.id);

                            // If current sprite hold a key then save it before.
                            if (spr.keyDrop == 1)
                            {
                                sprites_buffer[pos++] = 0xFE;
                                sprites_buffer[pos++] = 0x00;
                                sprites_buffer[pos++] = 0xE4;
                            }
                            else if (spr.keyDrop == 2)
                            {
                                sprites_buffer[pos++] = 0xFD;
                                sprites_buffer[pos++] = 0x00;
                                sprites_buffer[pos++] = 0xE4;
                            }
                        }

                        sprites_buffer[pos++] = 0xFF; // End of sprites.
                    }
                }

                ROM.EndBlockLogWriting();
                sprites_buffer.CopyTo(ROM.DATA, spritePointerPC);
            }
            catch (Exception)
            {
                return true;
            }

            return false; // False = no error.
        }

        public bool saveOWExits(SceneOW scene)
        {
            ROM.StartBlockLogWriting("OW Exits", Constants.OWExitMapId);

            for (int i = 0; i < 78; i++)
            {
                ROM.Write(Constants.OWExitMapId + (i), (byte)((scene.ow.allexits[i].mapId) & 0xFF), WriteType.ExitProperties);
                ROM.WriteShort(Constants.OWExitXScroll + (i * 2), ((scene.ow.allexits[i].xScroll)), WriteType.ExitProperties);
                ROM.WriteShort(Constants.OWExitYScroll + (i * 2), ((scene.ow.allexits[i].yScroll)), WriteType.ExitProperties);
                ROM.WriteShort(Constants.OWExitXCamera + (i * 2), ((scene.ow.allexits[i].cameraX)), WriteType.ExitProperties);
                ROM.WriteShort(Constants.OWExitYCamera + (i * 2), ((scene.ow.allexits[i].cameraY)), WriteType.ExitProperties);
                ROM.WriteShort(Constants.OWExitVram + (i * 2), ((scene.ow.allexits[i].vramLocation)), WriteType.ExitProperties);
                ROM.WriteShort(Constants.OWExitRoomId + (i * 2), ((scene.ow.allexits[i].roomId)), WriteType.ExitProperties);
                ROM.WriteShort(Constants.OWExitXPlayer + (i * 2), ((scene.ow.allexits[i].playerX)), WriteType.ExitProperties);
                ROM.WriteShort(Constants.OWExitYPlayer + (i * 2), ((scene.ow.allexits[i].playerY)), WriteType.ExitProperties);
                ROM.WriteShort(Constants.OWExitDoorType1 + (i * 2), ((scene.ow.allexits[i].doorType1)), WriteType.ExitProperties);
                ROM.WriteShort(Constants.OWExitDoorType2 + (i * 2), ((scene.ow.allexits[i].doorType2)), WriteType.ExitProperties);
            }

            ROM.EndBlockLogWriting();
            return false;
        }

        public bool saveOWEntrances(SceneOW scene)
        {
            ROM.StartBlockLogWriting("OW Entrances/Holes", Constants.OWEntranceMap);

            for (int i = 0; i < scene.ow.allentrances.Length; i++)
            {
                ROM.WriteShort(Constants.OWEntranceMap + (i * 2), ((scene.ow.allentrances[i].mapId)), WriteType.EntranceProperties);
                ROM.WriteShort(Constants.OWEntrancePos + (i * 2), ((scene.ow.allentrances[i].mapPos)), WriteType.EntranceProperties);
                ROM.Write(Constants.OWEntranceEntranceId + i, (byte)((scene.ow.allentrances[i].entranceId) & 0xFF), WriteType.EntranceProperties);
            }

            for (int i = 0; i < scene.ow.allholes.Length; i++)
            {
                ROM.WriteShort(Constants.OWHoleArea + (i * 2), ((scene.ow.allholes[i].mapId)), WriteType.EntranceProperties);
                ROM.WriteShort(Constants.OWHolePos + (i * 2), (((scene.ow.allholes[i].mapPos - 0x400))), WriteType.EntranceProperties);
                ROM.Write(Constants.OWHoleEntrance + i, (byte)((scene.ow.allholes[i].entranceId) & 0xFF), WriteType.EntranceProperties);
            }

            ROM.EndBlockLogWriting();
            //WriteLog("Overworld Entrances data loaded properly", Color.Green);
            return false;
        }

        public bool saveOWItems(SceneOW scene)
        {
            ROM.StartBlockLogWriting("Items OW DATA & Pointers", Constants.overworldItemsPointers);
            var roomItems = new List<RoomPotSaveEditor>[128];

            for (int i = 0; i < 128; i++)
            {
                roomItems[i] = new List<RoomPotSaveEditor>();
                foreach (RoomPotSaveEditor item in scene.ow.allitems)
                {
                    if (item.roomMapId == i)
                    {
                        roomItems[i].Add(item);
                        if (item.id == 0x86)
                        {
                            ROM.WriteShort(0x16DC5 + (i * 2), (item.gameX + (item.gameY * 64)) * 2);
                        }
                    }
                }
            }

            int dataPos = Constants.overworldItemsPointers + 0x100;

            int[] itemPointers = new int[128];
            int[] itemPointersReuse = new int[128];
            int emptyPointer = 0;

            for (int i = 0; i < 128; i++)
            {
                itemPointersReuse[i] = -1;
                for (int ci = 0; ci < i; ci++)
                {
                    if (roomItems[i].Count == 0)
                    {
                        itemPointersReuse[i] = -2;
                        break;
                    }
                    if (this.compareItemsArrays(roomItems[i].ToArray(), roomItems[ci].ToArray()))
                    {
                        itemPointersReuse[i] = ci;
                        break;
                    }
                }
            }

            for (int i = 0; i < 128; i++)
            {
                if (itemPointersReuse[i] == -1)
                {
                    itemPointers[i] = dataPos;
                    foreach (RoomPotSaveEditor item in roomItems[i])
                    {
                        short mapPos = (short)(((item.gameY << 6) + item.gameX) << 1);

                        ROM.Write(
                            dataPos,
                            new byte[3] { (byte)(mapPos & 0xFF), (byte)(mapPos >> 8), (byte)(item.id) },
                            WriteType.PotItemData
                        );

                        dataPos += 3;
                    }

                    emptyPointer = dataPos;
                    ROM.WriteShort(dataPos, 0xFFFF, true, "End Item Data");
                    dataPos += 2;
                }
                else if (itemPointersReuse[i] == -2)
                {
                    itemPointers[i] = emptyPointer;
                }
                else
                {
                    itemPointers[i] = itemPointers[itemPointersReuse[i]];
                }

                int snesaddr = Utils.PcToSnes(itemPointers[i]);
                ROM.WriteShort(Constants.overworldItemsPointers + (i * 2), (snesaddr), true, "Item Pointer for room" + i.ToString("D3"));
            }

            if (dataPos > Constants.overworldItemsEndData)
            {
                return true;
            }

            ROM.EndBlockLogWriting();
            Console.WriteLine("End of Items : " + dataPos.ToString("X6"));

            return false;
        }

        public bool SaveOWSprites(SceneOW scene)
        {
            ROM.StartBlockLogWriting("Sprites OW DATA & Pointers", Constants.overworldSpritesBegining);
            var spritePointers = new int[Constants.NumberOfOWSprites];
            var spritePointersReused = new int[Constants.NumberOfOWSprites];
            var allSprites = new List<Sprite>[Constants.NumberOfOWSprites];

            for (int j = 0; j < Constants.NumberOfOWSprites; j++)
            {
                spritePointersReused[j] = -1;
                allSprites[j] = new List<Sprite>();
            }

            for (int i = 0; i < Constants.NumberOfOWSprites; i++) // For each pointers.
            {
                if (i < 64) // LW[0]
                {
                    Sprite[] sprArray = scene.ow.allsprites[0].Where(sprite => sprite.mapid == i).ToArray();
                    foreach (Sprite spr in sprArray)
                    {
                        allSprites[i].Add(spr);
                    }
                }
                else if (i >= 64 && i < 208) // LW & DW[1]
                {
                    Sprite[] sprArray = scene.ow.allsprites[1].Where(sprite => sprite.mapid == (i - 64)).ToArray();
                    foreach (Sprite spr in sprArray)
                    {
                        allSprites[i].Add(spr);
                    }
                }
                else if (i >= 208 && i < Constants.NumberOfOWSprites) // LW[2]
                {
                    Sprite[] sprArray = scene.ow.allsprites[2].Where(sprite => sprite.mapid == (i - 208)).ToArray();
                    foreach (Sprite spr in sprArray)
                    {
                        allSprites[i].Add(spr);
                    }
                }
            }

            for (int i = 0; i < Constants.NumberOfOWSprites; i++)
            {
                spritePointersReused[i] = -1;
                for (int ci = 0; ci < Constants.NumberOfOWSprites; ci++)
                {
                    if (ci >= i)
                    {
                        break;
                    }

                    // the i != ci condition is useless, because it would have hit the break if we were equal
                    if (compareSpriteArrays(allSprites[i].ToArray(), allSprites[ci].ToArray()))
                    {
                        spritePointersReused[i] = ci;
                    }
                }
            }

            int dataPos = 0x4CB41;
            // END OF OW SPRITES DATA = 0x4D62E
            //ROM.Write(0x4CB41,0xFF); // empty sprite data
            // 0x4CB42 // start of rooms data saves

            // write sprite data if sprPointersReused[i] == -1

            for (int i = 0; i < Constants.NumberOfOWSprites; i++)
            {
                if (spritePointersReused[i] == -1)
                {
                    spritePointers[i] = dataPos;
                    foreach (Sprite spr in allSprites[i])
                    {
                        ROM.Write(dataPos, new byte[] { spr.y, spr.x, spr.id }, WriteType.SpriteData);
                        dataPos += 3;
                    }

                    ROM.Write(dataPos++, 0xFF, true, "Termination Byte");
                }
                else
                {
                    spritePointers[i] = spritePointers[spritePointersReused[i]];
                }

                int SNESAddress = Utils.PcToSnes(spritePointers[i]);
                ROM.WriteShort(Constants.overworldSpritesBegining + (i * 2), (SNESAddress), true, "Sprite Pointer for map" + i.ToString("D3"));
            }

            if (dataPos > 0x4D62E)
            {
                Console.WriteLine("Position " + dataPos.ToString("X6"));
                return true; // Error.
            }

            ROM.EndBlockLogWriting();
            return false; // No errors.
        }

        public bool compareSpriteArrays(Sprite[] spriteArray1, Sprite[] spriteArray2)
        {
            if (spriteArray1.Length != spriteArray2.Length)
            {
                return false;
            }

            bool match;
            for (int i = 0; i < spriteArray1.Length; i++)
            {
                match = false;
                for (int j = 0; j < spriteArray2.Length; j++)
                {
                    // Check all sprite in 2nd array if one match
                    if (spriteArray1[i].x == spriteArray2[j].x &&
                        spriteArray1[i].y == spriteArray2[j].y &&
                        spriteArray1[i].id == spriteArray2[j].id)
                    {
                        match = true;
                        break;
                    }
                }

                if (!match)
                {
                    return false;
                }
            }

            return true;
        }

        public bool compareItemsArrays(RoomPotSaveEditor[] itemArray1, RoomPotSaveEditor[] itemArray2)
        {
            if (itemArray1.Length != itemArray2.Length)
            {
                return false;
            }

            bool match;
            for (int i = 0; i < itemArray1.Length; i++)
            {
                match = false;
                for (int j = 0; j < itemArray2.Length; j++)
                {
                    // Check all sprite in 2nd array if one match
                    if (itemArray1[i].x == itemArray2[j].x &&
                        itemArray1[i].y == itemArray2[j].y &&
                        itemArray1[i].id == itemArray2[j].id)
                    {
                        match = true;
                        break;
                    }
                }

                if (!match)
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
                ROM.Write(Constants.mapGfx + i, scene.ow.allmaps[i].gfx, WriteType.GFX);
                ROM.Write(Constants.overworldSpriteset + i, scene.ow.allmaps[i].sprgfx[0], WriteType.SpriteSet);
                ROM.Write(Constants.overworldSpriteset + 64 + i, scene.ow.allmaps[i].sprgfx[1], WriteType.SpriteSet);
                ROM.Write(Constants.overworldSpriteset + 128 + i, scene.ow.allmaps[i].sprgfx[2], WriteType.SpriteSet);
                ROM.Write(Constants.overworldMapPalette + i, scene.ow.allmaps[i].palette, WriteType.Palette);
                ROM.Write(Constants.overworldSpritePalette + i, scene.ow.allmaps[i].sprpalette[0], WriteType.SpritePalette);
                ROM.Write(Constants.overworldSpritePalette + 64 + i, scene.ow.allmaps[i].sprpalette[1], WriteType.SpritePalette);
                ROM.Write(Constants.overworldSpritePalette + 128 + i, scene.ow.allmaps[i].sprpalette[2], WriteType.SpritePalette);
            }

            for (int i = 64; i < 128; i++)
            {
                ROM.Write(Constants.mapGfx + i, scene.ow.allmaps[i].gfx, WriteType.GFX);
                ROM.Write(Constants.overworldSpriteset + 128 + i, scene.ow.allmaps[i].sprgfx[0], WriteType.SpriteSet);
                ROM.Write(Constants.overworldSpriteset + 128 + i, scene.ow.allmaps[i].sprgfx[1], WriteType.SpriteSet);
                ROM.Write(Constants.overworldSpriteset + 128 + i, scene.ow.allmaps[i].sprgfx[2], WriteType.SpriteSet);
                ROM.Write(Constants.overworldMapPalette + i, scene.ow.allmaps[i].palette, WriteType.Palette);
                ROM.Write(Constants.overworldSpritePalette + 128 + i, scene.ow.allmaps[i].sprpalette[0], WriteType.SpritePalette);
                ROM.Write(Constants.overworldSpritePalette + 128 + i, scene.ow.allmaps[i].sprpalette[1], WriteType.SpritePalette);
                ROM.Write(Constants.overworldSpritePalette + 128 + i, scene.ow.allmaps[i].sprpalette[2], WriteType.SpritePalette);
            }

            ROM.EndBlockLogWriting();
            return false;
        }

        public bool saveMapOverlays(SceneOW scene)
        {
            ROM.StartBlockLogWriting("Map Overlays", Constants.mapGfx);

            byte[] newOverlayCode = new byte[]
            {
                0xC2, 0x30, // REP #$30
                0xA5, 0x8A, // LDA $8A
                0x0A, 0x18, // ASL : CLC
                0x65, 0x8A, // ADC $8A
                0xAA, // TAX
                0xBF, 0x00, 0x00, 0x00, // LDA, X
                0x85, 0x00, // STA $00
                0xBF, 0x00, 0x00, 0x00, // LDA, X +2
                0x85, 0x02, // STA $02
                0x4B, // PHK
                0xF4, 0x00, 0x00, // This position +3 ?
                0xDC, 0x00, 0x00, // JML [$00 00]
                0xE2, 0x30, // SEP #$30
                0xAB, // PLB
                0x6B // RTL
            };

            // Pointers

            ROM.Write(0x77657, newOverlayCode, true, "New Overlay Code");

            int ptrStart = (0x77657 + 32);
            int snesptrstart = Utils.PcToSnes(ptrStart);
            // 10, 16,
            ROM.WriteLong(0x77657 + 10, snesptrstart, true, "Overlay Pointerp1");
            ROM.WriteLong(0x77657 + 16, snesptrstart + 2, true, "Overlay Pointerp2");

            int peaAddr = Utils.PcToSnes(0x77657 + 27);

            ROM.WriteShort(0x77657 + 23, peaAddr, true, "Pea Addr (don't ask)");

            // TODO : Optimize that routine to be smaller

            // 0x058000
            int pos = 0x120000;
            int ptrPos = 0x77657 + 32;
            for (int i = 0; i < 128; i++)
            {
                int snesaddr = Utils.PcToSnes(pos);
                ROM.WriteLong(ptrPos, snesaddr, true, "Overlay actual Pointers");
                ptrPos += 3;

                for (int t = 0; t < scene.ow.alloverlays[i].tilesData.Count; t++)
                {
                    ushort addr = (ushort)((scene.ow.alloverlays[i].tilesData[t].x * 2) + (scene.ow.alloverlays[i].tilesData[t].y * 128) + 0x2000);
                    // LDA TileID : STA $addr
                    // A9 (LDA #$)
                    // A2 (LDX #$)
                    // 8D (STA $xxxx)

                    // LDA :
                    ROM.Write(pos, 0xA9, true, "Overlay Data, LDA");
                    ROM.WriteShort(pos + 1, (scene.ow.alloverlays[i].tilesData[t].tileId), true, "Overlay Data, TileID");
                    pos += 3;

                    // STA :
                    ROM.Write(pos, 0x8D, true, "Overlay Data, STA");
                    ROM.WriteShort(pos + 1, addr, true, "Overlay Data, TilePos");
                    pos += 3;
                }

                ROM.Write(pos, 0x6B, true, "RTL"); // RTL
                pos++;
            }

            ROM.EndBlockLogWriting();
            return false;
        }

        public bool saveOverworldTilesType(SceneOW scene)
        {
            ROM.StartBlockLogWriting("Overworld Tiles Types", Constants.overworldTilesType);
            for (int i = 0; i < 0x200; i++)
            {
                ROM.Write(Constants.overworldTilesType + i, scene.ow.allTilesTypes[i], true, "Tile ID" + i.ToString("D3") + " Type:" + scene.ow.allTilesTypes[i].ToString("D3"));
            }

            ROM.EndBlockLogWriting();
            return false;
        }

        // ROM MAP
        // 0x110000 (S:228000) are rooms header Length 0x12C0 (Always the same size).
        // 120000 to 1343C0 (S:248000 to 26C3C0) are new overworld maps location always same size (fake compressed).
        // 0x058000 (OLD MAP DATA) Now Used for Overlays data.

        // 0x6452A  // HOOK Replaced Code : INC $15 : LDA.b #$03
        // 1351C0 / 26D1C0 end of tilemap data where the jump code should be for DMA.

        /*
        public bool saveTitleScreen()
        {
            int pos = 0x1343C0;
            // 134AC0 = BG2
            for (int i = 0; i < 0x380; i++)
            {
                ROM.WriteShort(pos, mainForm.screenEditor.tilesBG1Buffer[i], true, "Screen");
                ROM.WriteShort(pos+0x700, mainForm.screenEditor.tilesBG2Buffer[i], true, "Screen");
                pos += 2;
            }

            return false;
        }
        */

        public bool saveOverworldMessagesIds(SceneOW scene)
        {
            ROM.StartBlockLogWriting("Overworld Messages IDs", Constants.overworldMessages);

            for (int i = 0; i < 128; i++)
            {
                ROM.WriteShort(Constants.overworldMessages + (i * 2), scene.ow.allmaps[i].messageID, true, "OW Message ID for map " + i.ToString("D3"));
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
                ROM.Write(Constants.overworldMusicDW + i, scene.ow.allmaps[i + 64].musics[0], true, "OW Musics ID for map " + (i + 64).ToString("D3"));
            }

            ROM.EndBlockLogWriting();

            return false;
        }

        public bool compareArray(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public bool saveOverworldMaps(SceneOW scene)
        {
            for (int i = 0; i < 160; i++)
            {
                this.mapPointers1id[i] = -1;
                this.mapPointers2id[i] = -1;
            }

            int pos = 0x058000;
            for (int i = 0; i < 160; i++)
            {
                int npos = 0;
                byte[]
                    singleMap1 = new byte[512],
                    singleMap2 = new byte[512];

                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        singleMap1[npos] = (byte)(scene.ow.t32[npos + (i * 256)] & 0xFF);
                        singleMap2[npos] = (byte)((scene.ow.t32[npos + (i * 256)] >> 8) & 0xFF);
                        npos++;
                    }
                }

                if (singleMap1.Length > 512)
                {
                    Console.WriteLine("Test.");
                }

                byte[] a = Compress.ALTTPCompressOverworld(singleMap1, 0, 256);
                byte[] b = Compress.ALTTPCompressOverworld(singleMap2, 0, 256);

                if (a == null || b == null)
                {
                    Console.WriteLine("Error compressing map gfx.");
                    return true;
                }

                this.mapDatap1[i] = new byte[a.Length];
                this.mapDatap2[i] = new byte[b.Length];
                if (i == 0x54)
                {
                    //Console.WriteLine((pos + a.Length).ToString("X6"));
                    //Console.WriteLine((pos + b.Length).ToString("X6"));
                }

                // 05FE1C
                // 05FE05

                // 05FFA7
                // 05FF78
                if ((pos + a.Length) >= 0x5FE70 && (pos + a.Length) <= 0x60000)
                {
                    pos = 0x60000;
                }

                if ((pos + a.Length) >= 0x6411F && (pos + a.Length) <= 0x70000)
                {
                    pos = Constants.OverowrldMapDataOverflow; // 0x0F8780;
                }

                for (int j = 0; j < i; j++)
                {
                    if (this.compareArray(a, this.mapDatap1[j]))
                    {
                        // Reuse pointer id j for P1 (a)
                        this.mapPointers1id[i] = j;
                    }

                    if (this.compareArray(b, this.mapDatap2[j]))
                    {
                        this.mapPointers2id[i] = j;
                        // Reuse pointer id j for P2 (b)
                    }
                }

                // Before Saving it to the ROM check if it match an existing map already
                if (this.mapPointers1id[i] == -1)
                {
                    a.CopyTo(mapDatap1[i], 0);
                    int snesPos = Utils.PcToSnes(pos);
                    this.mapPointers1[i] = snesPos;
                    ROM.Write((Constants.compressedAllMap32PointersLow) + 0 + 3 * i, (byte)(snesPos & 0xFF), WriteType.OverworldMapPointer);
                    ROM.Write((Constants.compressedAllMap32PointersLow) + 1 + 3 * i, (byte)((snesPos >> 8) & 0xFF), WriteType.OverworldMapPointer);
                    ROM.Write((Constants.compressedAllMap32PointersLow) + 2 + 3 * i, (byte)((snesPos >> 16) & 0xFF), WriteType.OverworldMapPointer);
                    /*
                    ROM.DATA[(Constants.compressedAllMap32PointersLow) + 0 + (int)(3 * i)] = (byte)(snesPos & 0xFF);
                    ROM.DATA[(Constants.compressedAllMap32PointersLow) + 1 + (int)(3 * i)] = (byte)((snesPos >> 8) & 0xFF);
                    ROM.DATA[(Constants.compressedAllMap32PointersLow) + 2 + (int)(3 * i)] = (byte)((snesPos >> 16) & 0xFF);
                    */

                    ROM.Write(pos, a);
                    for (int j = 0; j < a.Length; j++)
                    {
                        //ROM.DATA[pos] = a[j];
                        pos += 1;
                    }
                }
                else
                {
                    int snesPos = this.mapPointers1[mapPointers1id[i]];
                    ROM.Write((Constants.compressedAllMap32PointersLow) + 0 + 3 * i, (byte)(snesPos & 0xFF), WriteType.OverworldMapPointer);
                    ROM.Write((Constants.compressedAllMap32PointersLow) + 1 + 3 * i, (byte)((snesPos >> 8) & 0xFF), WriteType.OverworldMapPointer);
                    ROM.Write((Constants.compressedAllMap32PointersLow) + 2 + 3 * i, (byte)((snesPos >> 16) & 0xFF), WriteType.OverworldMapPointer);
                    /*
                    ROM.DATA[(Constants.compressedAllMap32PointersLow) + 0 + (int)(3 * i)] = (byte)(snesPos & 0xFF);
                    ROM.DATA[(Constants.compressedAllMap32PointersLow) + 1 + (int)(3 * i)] = (byte)((snesPos >> 8) & 0xFF);
                    ROM.DATA[(Constants.compressedAllMap32PointersLow) + 2 + (int)(3 * i)] = (byte)((snesPos >> 16) & 0xFF);
                    */
                }

                if ((pos + b.Length) >= 0x5FE70 && (pos + b.Length) <= 0x60000)
                {
                    pos = 0x60000;
                }
                if ((pos + b.Length) >= 0x6411F && (pos + b.Length) <= 0x70000)
                {
                    pos = Constants.OverowrldMapDataOverflow;
                }

                // Map2
                if (mapPointers2id[i] == -1)
                {
                    b.CopyTo(mapDatap2[i], 0);
                    int snesPos = Utils.PcToSnes(pos);
                    this.mapPointers2[i] = snesPos;

                    ROM.Write((Constants.compressedAllMap32PointersHigh) + 0 + 3 * i, (byte)(snesPos & 0xFF), WriteType.OverworldMapPointer);
                    ROM.Write((Constants.compressedAllMap32PointersHigh) + 1 + 3 * i, (byte)((snesPos >> 8) & 0xFF), WriteType.OverworldMapPointer);
                    ROM.Write((Constants.compressedAllMap32PointersHigh) + 2 + 3 * i, (byte)((snesPos >> 16) & 0xFF), WriteType.OverworldMapPointer);

                    ROM.Write(pos, b);

                    for (int j = 0; j < b.Length; j++)
                    {
                        //ROM.DATA[pos] = b[j];
                        pos += 1;
                    }
                }
                else
                {
                    int snesPos = this.mapPointers2[mapPointers2id[i]];
                    /*
                    ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 0 + (int)(3 * i)] = (byte)(snesPos & 0xFF);
                    ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 1 + (int)(3 * i)] = (byte)((snesPos >> 8) & 0xFF);
                    ROM.DATA[(Constants.compressedAllMap32PointersHigh) + 2 + (int)(3 * i)] = (byte)((snesPos >> 16) & 0xFF);
                    */

                    ROM.Write((Constants.compressedAllMap32PointersHigh) + 0 + 3 * i, (byte)(snesPos & 0xFF), WriteType.OverworldMapPointer);
                    ROM.Write((Constants.compressedAllMap32PointersHigh) + 1 + 3 * i, (byte)((snesPos >> 8) & 0xFF), WriteType.OverworldMapPointer);
                    ROM.Write((Constants.compressedAllMap32PointersHigh) + 2 + 3 * i, (byte)((snesPos >> 16) & 0xFF), WriteType.OverworldMapPointer);
                }
            }

            if (pos > 0x137FFF)
            {
                Console.WriteLine("Too many maps data " + pos.ToString("X6"));
                return true;
            }

            SaveLargeMaps(scene);

            return false;

            //Console.WriteLine("Map Pos Length: " + pos.ToString("X6"));
            //Save32Tiles();
        }

        /// <summary>
        ///		Saves the overworld area layout (whether the area is big or small).
        ///		**** IMPORTANT **** this function changes how the big and small area transitioning works so the data in theses tables will NOT look the same as in a vanilla ROM.
        /// </summary>
        /// <param name="scene"> The active SceneOW. </param>
        /// <returns> True if the saving failed. </returns>
        public bool SaveLargeMaps(SceneOW scene)
        {
            string parentMapLine = "";

            string[] parentMap = new string[8];

            Console.WriteLine("\n");
            List<byte> checkedMap = new List<byte>();

            for (int i = 0; i < 64; i++)
            {
                int yPos = i / 8;
                int xPos = i % 8;
                int parentyPos = scene.ow.allmaps[i].parent / 8;
                int parentxPos = scene.ow.allmaps[i].parent % 8;

                // Always write the map parent since it should not matter.
                ROM.Write(Constants.overworldMapParentId + i, scene.ow.allmaps[i].parent);
                parentMapLine += scene.ow.allmaps[i].parent.ToString("X2").PadLeft(2, '0') + " ";

                if ((i + 1) % 8 == 0)
                {
                    parentMap[((i + 1) / 8) - 1] = parentMapLine;

                    parentMapLine = "";
                }

                if (checkedMap.Contains((byte)i))
                {
                    continue; // Ignore that map we already checked it.
                }

                if (scene.ow.allmaps[i].largeMap) // If it's large then save parent pos * 0x200 otherwise pos * 0x200.
                {
                    // Check 1.
                    ROM.Write(Constants.overworldMapSize + i, 0x20);
                    ROM.Write(Constants.overworldMapSize + i + 1, 0x20);
                    ROM.Write(Constants.overworldMapSize + i + 8, 0x20);
                    ROM.Write(Constants.overworldMapSize + i + 9, 0x20);

                    // Check 2.
                    ROM.Write(Constants.overworldMapSizeHighByte + i, 0x03);
                    ROM.Write(Constants.overworldMapSizeHighByte + i + 1, 0x03);
                    ROM.Write(Constants.overworldMapSizeHighByte + i + 8, 0x03);
                    ROM.Write(Constants.overworldMapSizeHighByte + i + 9, 0x03);

                    // Check 3.
                    ROM.Write(Constants.overworldScreenSize + i, 0x00);
                    ROM.Write(Constants.overworldScreenSize + i + 64, 0x00);

                    ROM.Write(Constants.overworldScreenSize + i + 1, 0x00);
                    ROM.Write(Constants.overworldScreenSize + i + 1 + 64, 0x00);

                    ROM.Write(Constants.overworldScreenSize + i + 8, 0x00);
                    ROM.Write(Constants.overworldScreenSize + i + 8 + 64, 0x00);

                    ROM.Write(Constants.overworldScreenSize + i + 9, 0x00);
                    ROM.Write(Constants.overworldScreenSize + i + 9 + 64, 0x00);

                    // Check 4.
                    ROM.Write(Constants.OverworldScreenSizeForLoading + i, 0x04);
                    ROM.Write(Constants.OverworldScreenSizeForLoading + i + 64, 0x04);
                    ROM.Write(Constants.OverworldScreenSizeForLoading + i + 128, 0x04);

                    ROM.Write(Constants.OverworldScreenSizeForLoading + i + 1, 0x04);
                    ROM.Write(Constants.OverworldScreenSizeForLoading + i + 1 + 64, 0x04);
                    ROM.Write(Constants.OverworldScreenSizeForLoading + i + 1 + 128, 0x04);

                    ROM.Write(Constants.OverworldScreenSizeForLoading + i + 8, 0x04);
                    ROM.Write(Constants.OverworldScreenSizeForLoading + i + 8 + 64, 0x04);
                    ROM.Write(Constants.OverworldScreenSizeForLoading + i + 8 + 128, 0x04);

                    ROM.Write(Constants.OverworldScreenSizeForLoading + i + 9, 0x04);
                    ROM.Write(Constants.OverworldScreenSizeForLoading + i + 9 + 64, 0x04);
                    ROM.Write(Constants.OverworldScreenSizeForLoading + i + 9 + 128, 0x04);

                    // Check 5 and 6.
                    ROM.WriteShort(Constants.transition_target_north + (i * 2), (ushort)((parentyPos * 0x200) - 0xE0)); // (ushort) is placed to reduce the int to 2 bytes.
                    ROM.WriteShort(Constants.transition_target_west + (i * 2), (ushort)((parentxPos * 0x200) - 0x100));

                    ROM.WriteShort(Constants.transition_target_north + (i * 2) + 2, (ushort)((parentyPos * 0x200) - 0xE0)); // (ushort) is placed to reduce the int to 2 bytes.
                    ROM.WriteShort(Constants.transition_target_west + (i * 2) + 2, (ushort)((parentxPos * 0x200) - 0x100));

                    ROM.WriteShort(Constants.transition_target_north + (i * 2) + 16, (ushort)((parentyPos * 0x200) - 0xE0)); // (ushort) is placed to reduce the int to 2 bytes.
                    ROM.WriteShort(Constants.transition_target_west + (i * 2) + 16, (ushort)((parentxPos * 0x200) - 0x100));

                    ROM.WriteShort(Constants.transition_target_north + (i * 2) + 18, (ushort)((parentyPos * 0x200) - 0xE0)); // (ushort) is placed to reduce the int to 2 bytes.
                    ROM.WriteShort(Constants.transition_target_west + (i * 2) + 18, (ushort)((parentxPos * 0x200) - 0x100));

                    // Check 7 and 8.
                    ROM.WriteShort(Constants.overworldTransitionPositionX + (i * 2), (parentxPos * 0x200));
                    ROM.WriteShort(Constants.overworldTransitionPositionY + (i * 2), (parentyPos * 0x200));

                    ROM.WriteShort(Constants.overworldTransitionPositionX + (i * 2) + 2, (parentxPos * 0x200));
                    ROM.WriteShort(Constants.overworldTransitionPositionY + (i * 2) + 2, (parentyPos * 0x200));

                    ROM.WriteShort(Constants.overworldTransitionPositionX + (i * 2) + 16, (parentxPos * 0x200));
                    ROM.WriteShort(Constants.overworldTransitionPositionY + (i * 2) + 16, (parentyPos * 0x200));

                    ROM.WriteShort(Constants.overworldTransitionPositionX + (i * 2) + 18, (parentxPos * 0x200));
                    ROM.WriteShort(Constants.overworldTransitionPositionY + (i * 2) + 18, (parentyPos * 0x200));

                    // Check 9.
                    ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen1 + (i * 2) + 00, 0x0060); // Always 0x0060.
                    ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen1 + (i * 2) + 02, 0x0060); // Always 0x0060.

                    // If parentX == 0 then lower submaps == 0x0060 too.
                    if (parentxPos == 0)
                    {
                        ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen1 + (i * 2) + 16, 0x0060);
                        ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen1 + (i * 2) + 18, 0x0060);
                    }
                    else
                    {
                        // Otherwise lower submaps == 0x1060.
                        ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen1 + (i * 2) + 16, 0x1060);
                        ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen1 + (i * 2) + 18, 0x1060);

                        // If the area to the left is a large map, we don't need to add an offset to it. otherwise leave it the same.
                        // Just to make sure where don't try to read outside of the array.
                        if ((i - 1) >= 0)
                        {
                            // If the area to the left is a large area.
                            if (scene.ow.allmaps[i - 1].largeMap)
                            {
                                // If the area to the left is the bottom right of a large area.
                                if (scene.ow.allmaps[i - 1].largeIndex == 1)
                                {
                                    ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen1 + (i * 2) + 16, 0x0060);
                                }
                            }
                        }
                    }

                    ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen2 + (i * 2) + 00, 0x0080); // Always 0x0080.
                    ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen2 + (i * 2) + 02, 0x0080); // Always 0x0080.
                                                                                                            // Lower are always 8010.
                    ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen2 + (i * 2) + 16, 0x1080); // Always 0x1080.
                    ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen2 + (i * 2) + 18, 0x1080); // Always 0x1080.

                    // If the area to the right is a large map, we don't need to add an offset to it. otherwise leave it the same.
                    // Just to make sure where don't try to read outside of the array.
                    if ((i + 2) < 64)
                    {
                        // If the area to the right is a large area.
                        if (scene.ow.allmaps[i + 2].largeMap)
                        {
                            // If the area to the right is the top left of a large area.
                            if (scene.ow.allmaps[i + 2].largeIndex == 0)
                            {
                                ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen2 + (i * 2) + 18, 0x0080); // Always 0x1080.
                            }
                        }
                    }

                    ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen3 + (i * 2) + 00, 0x1800); // Always 0x1800.
                    ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen3 + (i * 2) + 16, 0x1800); // Always 0x1800.
                                                                                                            // Right side is always 1840.
                    ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen3 + (i * 2) + 02, 0x1840); // Always 0x1840.
                    ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen3 + (i * 2) + 18, 0x1840); // Always 0x1840.

                    // If the area above is a large map, we don't need to add an offset to it. otherwise leave it the same.
                    // Just to make sure where don't try to read outside of the array.
                    if (i - 8 >= 0)
                    {
                        // If the area just above us is a large area.
                        if (scene.ow.allmaps[i - 8].largeMap)
                        {
                            // If the area just above us is the bottom left of a large area.
                            if (scene.ow.allmaps[i - 8].largeIndex == 2)
                            {
                                ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen3 + (i * 2) + 02, 0x1800);
                            }
                        }
                    }

                    ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen4 + (i * 2) + 00, 0x2000); // Always 0x2000.
                    ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen4 + (i * 2) + 16, 0x2000); // Always 0x2000.
                                                                                                            // Right side is always 0x2040.
                    ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen4 + (i * 2) + 02, 0x2040); // Always 0x2040.
                    ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen4 + (i * 2) + 18, 0x2040); // Always 0x2040.

                    // If the area below is a large map, we don't need to add an offset to it. otherwise leave it the same.
                    // Just to make sure where don't try to read outside of the array.
                    if (i + 16 < 64)
                    {
                        // If the area just below us is a large area.
                        if (scene.ow.allmaps[i + 16].largeMap)
                        {
                            // If the area just below us is the top left of a large area.
                            if (scene.ow.allmaps[i + 16].largeIndex == 0)
                            {
                                ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen4 + (i * 2) + 18, 0x2000);
                            }
                        }
                    }

                    checkedMap.Add((byte)i);
                    checkedMap.Add((byte)(i + 1));
                    checkedMap.Add((byte)(i + 8));
                    checkedMap.Add((byte)(i + 9));
                }
                else
                {
                    ROM.Write(Constants.overworldMapSize + i, 0x00);
                    ROM.Write(Constants.overworldMapSizeHighByte + i, 0x01);

                    ROM.Write(Constants.overworldScreenSize + i, 0x01);
                    ROM.Write(Constants.overworldScreenSize + i + 64, 0x01);

                    ROM.Write(Constants.OverworldScreenSizeForLoading + i, 0x02);
                    ROM.Write(Constants.OverworldScreenSizeForLoading + i + 64, 0x02);
                    ROM.Write(Constants.OverworldScreenSizeForLoading + i + 128, 0x02);

                    ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen1 + (i * 2), 0x0060);
                    // If the area to the left is a large map, we don't need to add an offset to it. otherwise leave it the same.
                    // Just to make sure where don't try to read outside of the array.
                    if (i - 1 >= 0 && parentxPos != 0)
                    {
                        // If the area to the left is a large area.
                        if (scene.ow.allmaps[i - 1].largeMap)
                        {
                            // If the area to the left is the bottom right area of a large map.
                            if (scene.ow.allmaps[i - 1].largeIndex == 3)
                            {
                                ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen1 + (i * 2), 0xF060);
                            }
                        }
                    }

                    ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen2 + (i * 2), 0x0040);
                    // If the area to the right is a large map, we don't need to add an offset to it. otherwise leave it the same.
                    // Just to make sure where don't try to read outside of the array.
                    if (i + 1 < 64 && parentxPos != 7)
                    {
                        // If the area to the right is a large area.
                        if (scene.ow.allmaps[i + 1].largeMap)
                        {
                            // If the area to the right is the bottom left area of a large map.
                            if (scene.ow.allmaps[i + 1].largeIndex == 2)
                            {
                                ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen2 + (i * 2), 0xF040);
                            }
                        }
                    }

                    ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen3 + (i * 2), 0x1800);
                    // If the area above is a large map, we don't need to add an offset to it. otherwise leave it the same.
                    // Just to make sure where don't try to read outside of the array.
                    if (i - 8 >= 0)
                    {
                        // If the area just above us is a large area.
                        if (scene.ow.allmaps[i - 8].largeMap)
                        {
                            // If we are under the bottom right of the large area.
                            if (scene.ow.allmaps[i - 8].largeIndex == 3)
                            {
                                ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen3 + (i * 2), 0x17C0);
                            }
                        }
                    }

                    ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen4 + (i * 2), 0x1000);
                    // If the area below is a large map, we don't need to add an offset to it. otherwise leave it the same.
                    // Just to make sure where don't try to read outside of the array.
                    if (i + 8 < 64)
                    {
                        // If the area just below us is a large area.
                        if (scene.ow.allmaps[i + 8].largeMap)
                        {
                            // If we are on top of the top right of the large area.
                            if (scene.ow.allmaps[i + 8].largeIndex == 1)
                            {
                                ROM.WriteShort(Constants.OverworldScreenTileMapChangeByScreen4 + (i * 2), 0x0FC0);
                            }
                        }
                    }

                    ROM.WriteShort(Constants.transition_target_north + (i * 2), (ushort)((yPos * 0x200) - 0xE0));
                    ROM.WriteShort(Constants.transition_target_west + (i * 2), (ushort)((xPos * 0x200) - 0x100));

                    ROM.WriteShort(Constants.overworldTransitionPositionX + (i * 2), (xPos * 0x200));
                    ROM.WriteShort(Constants.overworldTransitionPositionY + (i * 2), (yPos * 0x200));

                    checkedMap.Add((byte)i);
                }
            }

            // Change one of the calculation masks to save the offset so that we can just store it in the tables instead.
            // This is done to allow link to move from one big area to another.
            ROM.WriteShort(Constants.OverworldScreenTileMapChangeMask + 0, 0x1F80);
            ROM.WriteShort(Constants.OverworldScreenTileMapChangeMask + 2, 0x1F80);
            ROM.WriteShort(Constants.OverworldScreenTileMapChangeMask + 4, 0x007F);
            ROM.WriteShort(Constants.OverworldScreenTileMapChangeMask + 6, 0x007F);

            string temp = "";
            Console.WriteLine("Overworld parent map: \n");
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(parentMap[i]);
            }

            Console.WriteLine("\nCheck 1: overworldMapSize \n");
            for (int i = 0; i < 8; i++)
            {
                temp = "";
                for (int j = 0; j < 8; j++)
                {
                    temp += " " + ROM.DATA[Constants.overworldMapSize + (j + (i * 8))].ToString("X2").PadLeft(2, '0');
                }

                Console.WriteLine(temp);
            }

            Console.WriteLine("\nCheck 2: overworldMapSizeHighByte \n");
            for (int i = 0; i < 8; i++)
            {
                temp = "";
                for (int j = 0; j < 8; j++)
                {
                    temp += " " + ROM.DATA[Constants.overworldMapSizeHighByte + (j + (i * 8))].ToString("X2").PadLeft(2, '0');
                }
                Console.WriteLine(temp);
            }

            Console.WriteLine("\nCheck 3: overworldScreenSize \n");
            for (int i = 0; i < 8; i++)
            {
                temp = "";
                for (int j = 0; j < 8; j++)
                {
                    temp += " " + ROM.DATA[Constants.overworldScreenSize + (j + (i * 8))].ToString("X2").PadLeft(2, '0');
                }
                Console.WriteLine(temp);
            }

            Console.WriteLine("\nCheck 4: OverworldScreenSizeForLoading \n");
            for (int i = 0; i < 8; i++)
            {
                temp = "";
                for (int j = 0; j < 8; j++)
                {
                    temp += " " + ROM.DATA[Constants.OverworldScreenSizeForLoading + (j + (i * 8))].ToString("X2").PadLeft(2, '0');
                }
                Console.WriteLine(temp);
            }

            Console.WriteLine("\nCheck 5: transition_target_north \n");
            for (int i = 0; i < 64; i++)
            {
                Console.Write(ROM.DATA[Constants.transition_target_north + (i * 2) + 1].ToString("X2").PadLeft(2, '0') + ROM.DATA[Constants.transition_target_north + (i * 2)].ToString("X2").PadLeft(2, '0') + " ");

                if ((i + 1) % 8 == 0)
                {
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("\nCheck 6: transition_target_west \n");
            for (int i = 0; i < 64; i++)
            {
                Console.Write(ROM.DATA[Constants.transition_target_west + (i * 2) + 1].ToString("X2").PadLeft(2, '0') + ROM.DATA[Constants.transition_target_west + (i * 2)].ToString("X2").PadLeft(2, '0') + " ");

                if ((i + 1) % 8 == 0)
                {
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("\nCheck 7: overworldTransitionPositionX \n");
            for (int i = 0; i < 64; i++)
            {
                Console.Write(ROM.DATA[Constants.overworldTransitionPositionX + (i * 2) + 1].ToString("X2").PadLeft(2, '0') + ROM.DATA[Constants.overworldTransitionPositionX + (i * 2)].ToString("X2").PadLeft(2, '0') + " ");

                if ((i + 1) % 8 == 0)
                {
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("\nCheck 8: overworldTransitionPositionY \n");
            for (int i = 0; i < 64; i++)
            {
                Console.Write(ROM.DATA[Constants.overworldTransitionPositionY + (i * 2) + 1].ToString("X2").PadLeft(2, '0') + ROM.DATA[Constants.overworldTransitionPositionY + (i * 2)].ToString("X2").PadLeft(2, '0') + " ");

                if ((i + 1) % 8 == 0)
                {
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("\nCheck 9:");
            Console.WriteLine(".OverworldScreenTileMapChangeByScreen1 'right'\n");
            for (int i = 0; i < 64; i++)
            {
                Console.Write(ROM.DATA[Constants.OverworldScreenTileMapChangeByScreen1 + (i * 2) + 1].ToString("X2").PadLeft(2, '0') + ROM.DATA[Constants.OverworldScreenTileMapChangeByScreen1 + (i * 2)].ToString("X2").PadLeft(2, '0') + " ");

                if ((i + 1) % 8 == 0)
                {
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("\n.OverworldScreenTileMapChangeByScreen2 'left'\n");
            for (int i = 0; i < 64; i++)
            {
                Console.Write(ROM.DATA[Constants.OverworldScreenTileMapChangeByScreen2 + (i * 2) + 1].ToString("X2").PadLeft(2, '0') + ROM.DATA[Constants.OverworldScreenTileMapChangeByScreen2 + (i * 2)].ToString("X2").PadLeft(2, '0') + " ");

                if ((i + 1) % 8 == 0)
                {
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("\n.OverworldScreenTileMapChangeByScreen3 'Down'\n");
            for (int i = 0; i < 64; i++)
            {
                Console.Write(ROM.DATA[Constants.OverworldScreenTileMapChangeByScreen3 + (i * 2) + 1].ToString("X2").PadLeft(2, '0') + ROM.DATA[Constants.OverworldScreenTileMapChangeByScreen3 + (i * 2)].ToString("X2").PadLeft(2, '0') + " ");

                if ((i + 1) % 8 == 0)
                {
                    Console.WriteLine("");
                }
            }

            Console.WriteLine("\n.OverworldScreenTileMapChangeByScreen4 'Up'\n");
            for (int i = 0; i < 64; i++)
            {
                Console.Write(ROM.DATA[Constants.OverworldScreenTileMapChangeByScreen4 + (i * 2) + 1].ToString("X2").PadLeft(2, '0') + ROM.DATA[Constants.OverworldScreenTileMapChangeByScreen4 + (i * 2)].ToString("X2").PadLeft(2, '0') + " ");

                if ((i + 1) % 8 == 0)
                {
                    Console.WriteLine("");
                }
            }
            Console.WriteLine("");

            return false;
        }

        public bool SaveGravestones(SceneOW scene)
        {
            for (int i = 0; i < 0x0F; i++)
            {
                ROM.WriteShort(Constants.GravesXTilePos + (i * 2), scene.ow.graves[i].xTilePos, WriteType.Gravestone);
                ROM.WriteShort(Constants.GravesYTilePos + (i * 2), scene.ow.graves[i].yTilePos, WriteType.Gravestone);
                ROM.WriteShort(Constants.GravesTilemapPos + (i * 2), scene.ow.graves[i].tilemapPos, WriteType.Gravestone);

                if (i == 0x0E)
                {
                    ROM.WriteShort(Constants.GraveLinkSpecialStairs, scene.ow.graves[i].tilemapPos - 0x80, WriteType.Gravestone);
                }
                if (i == 0x0D)
                {
                    ROM.WriteShort(Constants.GraveLinkSpecialHole, scene.ow.graves[i].tilemapPos - 0x80, WriteType.Gravestone);
                }
            }

            Asar.init();

            // TODO: handle differently in projects.
            if (File.Exists("newgraves.asm"))
            {
                Console.WriteLine("Applying Custom Grave ASM");
                Asar.patch("newgraves.asm", ref ROM.DATA);
            }
            else
            {
                UIText.CryAboutSaving("Missing ASM file 'newgraves.asm'.\nSaving will continue but the ASM will not be applied.");
            }

            foreach (Asarerror error in Asar.geterrors())
            {
                Console.WriteLine(error.Fullerrdata.ToString());
                return true;
            }

            return false;
        }

        public bool SaveTitleScreen()
        {
            this.MainForm.screenEditor.Save();
            return false;
        }

        public bool SaveDungeonMaps()
        {
            return this.MainForm.screenEditor.dungmapSaveAllCurrentDungeon();
        }

        public bool SaveOverworldMiniMap()
        {
            this.MainForm.screenEditor.saveOverworldMap();
            return false;
        }

        public bool SaveTriforce()
        {
            this.MainForm.screenEditor.saveTriforce();
            return false;
        }

        // TODO: OW Message Load/Save.
        // OW Music Saves.
        // Move ROOM FEATURES.
        public bool saveRoomsHeaders2()
        {
            // Long??
            int headerPointer = GetLongPointerSNESToPC(Constants.room_header_pointer);
            if (headerPointer < 0x100000)
            {
                var movePointer = new MovePointer();
                movePointer.ShowDialog();
                headerPointer = movePointer.address;

                int address = Utils.PcToSnes(movePointer.address);
                ROM.WriteLong2(Constants.room_header_pointer, address, true, "Header Pointers Location");
                ROM.Write2(Constants.room_header_pointers_bank, ROM.DATA2[Constants.room_header_pointer + 2], true, "Header Bank");
            }

            ROM.StartBlockLogWriting("Room Headers", headerPointer);
            for (int i = 0; i < Constants.NumberOfRooms; i++)
            {
                int newPointerAddress = (Utils.PcToSnes((headerPointer + 640) + (i * 14)));
                ROM.WriteShort2((headerPointer) + (i * 2), newPointerAddress, true, "Header " + i.ToString("D3") + " Pointer");
                this.saveHeader2((headerPointer + 640), i);
            }

            ROM.EndBlockLogWriting();

            ROM.StartBlockLogWriting("Rooms Messages", Constants.messages_id_dungeon);
            //ROM.SaveLogs();
            for (int i = 0; i < Constants.NumberOfRooms; i++)
            {
                ROM.WriteShort2(Constants.messages_id_dungeon + (i * 2), this.AllRooms[i].messageid, true, "Message Room ID : " + i.ToString("D3"));
            }

            ROM.EndBlockLogWriting();
            return false; // False = no error.
        }

        public void saveHeader2(int pos, int i)
        {
            byte[] headerData = new byte[14]
            {
                (byte)((((byte)this.AllRooms[i].bg2 & 0x07) << 5) + ((int)this.AllRooms[i].collision << 2) + (this.AllRooms[i].light ? 1 : 0)),
                this.AllRooms[i].palette,
                this.AllRooms[i].blockset,
                this.AllRooms[i].spriteset,
                ((byte)this.AllRooms[i].effect),
                ((byte)this.AllRooms[i].tag1),
                ((byte)this.AllRooms[i].tag2),
                (byte)((this.AllRooms[i].holewarp_plane) + (this.AllRooms[i].staircase1Plane << 2) + (this.AllRooms[i].staircase2Plane << 4) + (this.AllRooms[i].staircase3Plane << 6)),
                this.AllRooms[i].staircase4Plane,
                this.AllRooms[i].holewarp,
                this.AllRooms[i].staircase1,
                this.AllRooms[i].staircase2,
                this.AllRooms[i].staircase3,
                this.AllRooms[i].staircase4
            };

            ROM.Write2(pos + (i * 14), headerData, true, "Room Header " + i.ToString("D3"));
        }

        public bool saveallChests2()
        {
            int cpos = Utils.SnesToPc(ROM.ReadLong(Constants.chests_data_pointer1));
            int chestCount = 0;
            ROM.StartBlockLogWriting("Chests Data", cpos);
            for (int i = 0; i < Constants.NumberOfRooms; i++)
            {
                // Number of possible chests.
                foreach (Chest c in this.AllRooms[i].chest_list)
                {
                    ushort room_index = (ushort)i;
                    if (c.bigChest)
                    {
                        room_index += 0x8000;
                    }

                    byte[] data = new byte[3]
                    {
                        (byte)(room_index & 0xFF),
                        (byte)((room_index >> 8) & 0xFF),
                        c.item,
                    };

                    ROM.Write2(cpos, data, true, "Chest Data " + i.ToString("D3"));
                    cpos += 3;
                    chestCount++;
                }
            }

            //Console.WriteLine("Nbr of chests : " + chestCount);
            if (chestCount > 168)
            {
                return true; // False = no error.
            }

            ROM.EndBlockLogWriting();
            return false; // False = no error.
        }

        public bool saveallSprites2(short[] listofrooms)
        {
            int spritePointer = (09 << 16) + (ROM.DATA2[Constants.rooms_sprite_pointer + 1] << 8) + (ROM.DATA2[Constants.rooms_sprite_pointer]);
            int spritePointerPC = Utils.SnesToPc(spritePointer);
            ROM.StartBlockLogWriting("Dungeon Sprites", spritePointerPC);
            byte[] sprites_buffer = new byte[Constants.sprites_end_data - Utils.SnesToPc(spritePointer)];

            // Empty room data = 0x280.
            // Start of data = 0x282.
            try
            {
                int pos = 0x282;
                // Set empty room.
                sprites_buffer[0x280] = 0x00;
                sprites_buffer[0x281] = 0xFF;

                for (int i = 0; i < 320; i++)
                {
                    if (listofrooms.Contains((short)i))
                    {
                        if (i >= Constants.NumberOfRooms || this.AllRooms[i].sprites.Count <= 0)
                        {
                            sprites_buffer[(i * 2)] = (byte)((Utils.PcToSnes(Utils.SnesToPc(spritePointer + 0x280)) & 0xFF));
                            sprites_buffer[(i * 2) + 1] = (byte)(((Utils.SnesToPc(spritePointer + 0x280)) >> 8) & 0xFF);
                        }
                        else
                        {
                            // Pointer:
                            sprites_buffer[(i * 2)] = (byte)((Utils.PcToSnes(Utils.SnesToPc(spritePointer + pos)) & 0xFF));
                            sprites_buffer[(i * 2) + 1] = (byte)((Utils.PcToSnes(Utils.SnesToPc(spritePointer + pos)) >> 8) & 0xFF);

                            sprites_buffer[pos] = (byte)(this.AllRooms[i].sortsprites ? 0x01 : 0x00); // Unknown byte??
                            pos++;
                            foreach (Sprite spr in this.AllRooms[i].sprites) // 3bytes
                            {
                                byte b1 = (byte)((spr.layer << 7) + ((spr.subtype & 0x18) << 2) + spr.y);
                                byte b2 = (byte)(((spr.subtype & 0x07) << 5) + spr.x);
                                byte b3 = (spr.id);

                                sprites_buffer[pos] = b1;
                                pos++;
                                sprites_buffer[pos] = b2;
                                pos++;
                                sprites_buffer[pos] = b3;
                                pos++;

                                // If current sprite hold a key then save it before.
                                if (spr.keyDrop == 1)
                                {
                                    byte bb1 = 0xFE;
                                    byte bb2 = 0x00;
                                    byte bb3 = 0xE4;

                                    sprites_buffer[pos] = bb1;
                                    pos++;
                                    sprites_buffer[pos] = bb2;
                                    pos++;
                                    sprites_buffer[pos] = bb3;
                                    pos++;
                                }

                                if (spr.keyDrop == 2)
                                {
                                    byte bb1 = 0xFD;
                                    byte bb2 = 0x00;
                                    byte bb3 = 0xE4;

                                    sprites_buffer[pos] = bb1;
                                    pos++;
                                    sprites_buffer[pos] = bb2;
                                    pos++;
                                    sprites_buffer[pos] = bb3;
                                    pos++;
                                }
                            }

                            sprites_buffer[pos] = 0xFF; // End of sprites.
                            pos++;
                        }
                    }
                    else
                    {
                        if (i >= Constants.NumberOfRooms || DungeonsData.all_rooms_moved[i].sprites.Count <= 0)
                        {
                            sprites_buffer[(i * 2)] = (byte)((Utils.PcToSnes(Utils.SnesToPc(spritePointer + 0x280)) & 0xFF));
                            sprites_buffer[(i * 2) + 1] = (byte)(((Utils.SnesToPc(spritePointer + 0x280)) >> 8) & 0xFF);
                        }
                        else
                        {
                            // Pointer:
                            sprites_buffer[(i * 2)] = (byte)((Utils.PcToSnes(Utils.SnesToPc(spritePointer + pos)) & 0xFF));
                            sprites_buffer[(i * 2) + 1] = (byte)((Utils.PcToSnes(Utils.SnesToPc(spritePointer + pos)) >> 8) & 0xFF);

                            sprites_buffer[pos] = (byte)(DungeonsData.all_rooms_moved[i].sortsprites ? 0x01 : 0x00); // Unknown byte??
                            pos++;

                            foreach (Sprite spr in DungeonsData.all_rooms_moved[i].sprites) // 3bytes.
                            {
                                byte b1 = (byte)((spr.layer << 7) + ((spr.subtype & 0x18) << 2) + spr.y);
                                byte b2 = (byte)(((spr.subtype & 0x07) << 5) + spr.x);
                                byte b3 = (spr.id);

                                sprites_buffer[pos] = b1;
                                pos++;
                                sprites_buffer[pos] = b2;
                                pos++;
                                sprites_buffer[pos] = b3;
                                pos++;

                                // If current sprite hold a key then save it before.
                                if (spr.keyDrop == 1)
                                {
                                    byte bb1 = 0xFE;
                                    byte bb2 = 0x00;
                                    byte bb3 = 0xE4;

                                    sprites_buffer[pos] = bb1;
                                    pos++;
                                    sprites_buffer[pos] = bb2;
                                    pos++;
                                    sprites_buffer[pos] = bb3;
                                    pos++;
                                }

                                if (spr.keyDrop == 2)
                                {
                                    byte bb1 = 0xFD;
                                    byte bb2 = 0x00;
                                    byte bb3 = 0xE4;

                                    sprites_buffer[pos] = bb1;
                                    pos++;
                                    sprites_buffer[pos] = bb2;
                                    pos++;
                                    sprites_buffer[pos] = bb3;
                                    pos++;
                                }
                            }

                            sprites_buffer[pos] = 0xFF; // End of sprites.
                            pos++;
                        }
                    }
                }

                ROM.EndBlockLogWriting();
                sprites_buffer.CopyTo(ROM.DATA2, spritePointerPC);
            }
            catch (Exception)
            {
                return true;
            }

            return false; // False = no error
        }

        public bool saveAllObjects2(short[] listofrooms)
        {
            var section1Index = 0x50008; // 0x50000 to 0x5374F  // 53730
            var section2Index = 0xF878A; // 0xF878A to 0xFFFFF.
            var section3Index = 0x1EB90; // 0x1EB90 to 0x1FFFF.
            var section4Index = 0x1112C0; // If vanilla space is used use expanded region.
            int section4Start = 0x1112C0;
            bool usedSection4 = false;
            /*
            while (ROM.DATA[section4Index] != 0)
            {
                 //section4Index += 0x010000;
            }
            */

            // Check if room is already using that space first before skipping position!!
            section4Start = section4Index;
            // Reorder room from bigger to lower.

            for (int i = 0; i < Constants.NumberOfRooms; i++)
            {
                if (listofrooms.Contains((short)i))
                {
                    var roomBytes = this.AllRooms[i].getTilesBytes();
                    int doorPos = roomBytes.Length - 2;

                    if (roomBytes.Length < 10)
                    {
                        saveObjectBytes2(this.AllRooms[i].index, 0x50000, roomBytes, doorPos); // Empty room pointer.
                        continue;
                    }

                    while (true)
                    {
                        if (doorPos >= 04)
                        {
                            if (roomBytes[doorPos] == 0xF0 && roomBytes[doorPos + 1] == 0xFF)
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

                    if (section1Index + roomBytes.Length <= 0x53730) // 0x50000 to 0x5374F.
                    {
                        // Write the room.
                        saveObjectBytes2(this.AllRooms[i].index, section1Index, roomBytes, doorPos);
                        section1Index += roomBytes.Length;
                        continue;
                    }
                    else if (section2Index + roomBytes.Length <= 0xFFFFF) // 0xF878A to 0xFFFF7.
                    {
                        // Write the room.
                        saveObjectBytes2(this.AllRooms[i].index, section2Index, roomBytes, doorPos);
                        section2Index += roomBytes.Length;
                        continue;
                    }
                    else if (section3Index + roomBytes.Length <= 0x1FFFF) // 0x1EB90 to 0x1FFFF.
                    {
                        // Write the room.
                        saveObjectBytes2(this.AllRooms[i].index, section3Index, roomBytes, doorPos);
                        section3Index += roomBytes.Length;
                        continue;
                    }
                    else
                    {
                        // Ran out of space.
                        // Write the room.
                        //saveObjectBytes(i, section4Index, roomBytes);
                        //section4Index += roomBytes.Length;

                        saveObjectBytes2(this.AllRooms[i].index, section4Index, roomBytes, doorPos);
                        section4Index += roomBytes.Length;
                        usedSection4 = true;
                        continue;

                        // Move to EXPANDED region.
                        //Console.WriteLine("Room " + i + " no more space jump to 0x121210");
                        //currentPos = 0x121210;
                        //MessageBox.Show("We are running out space in the original portion of the ROM next data will be writed to : 0x121210");
                    }
                }
                else
                {
                    var roomBytes = DungeonsData.all_rooms_moved[i].getTilesBytes();
                    int doorPos = roomBytes.Length - 2;

                    if (roomBytes.Length < 10)
                    {
                        this.saveObjectBytes2(DungeonsData.all_rooms_moved[i].index, 0x50000, roomBytes, doorPos); // Empty room pointer
                        continue;
                    }
                    while (true)
                    {
                        if (doorPos >= 04)
                        {
                            if (roomBytes[doorPos] == 0xF0 && roomBytes[doorPos + 1] == 0xFF)
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

                    if (section1Index + roomBytes.Length <= 0x53730) // 0x50000 to 0x5374F.
                    {
                        // Write the room.
                        saveObjectBytes2(DungeonsData.all_rooms_moved[i].index, section1Index, roomBytes, doorPos);
                        section1Index += roomBytes.Length;
                        continue;
                    }
                    else if (section2Index + roomBytes.Length <= 0xFFFFF) // 0xF878A to 0xFFFF7.
                    {
                        // Write the room.
                        saveObjectBytes2(DungeonsData.all_rooms_moved[i].index, section2Index, roomBytes, doorPos);
                        section2Index += roomBytes.Length;
                        continue;
                    }
                    else if (section3Index + roomBytes.Length <= 0x1FFFF) // 0x1EB90 to 0x1FFFF.
                    {
                        // Write the room.
                        saveObjectBytes2(DungeonsData.all_rooms_moved[i].index, section3Index, roomBytes, doorPos);
                        section3Index += roomBytes.Length;
                        continue;
                    }
                    else
                    {
                        // Ran out of space.
                        // Write the room.
                        //saveObjectBytes(i, section4Index, roomBytes);
                        //section4Index += roomBytes.Length;

                        saveObjectBytes2(DungeonsData.all_rooms_moved[i].index, section4Index, roomBytes, doorPos);
                        section4Index += roomBytes.Length;
                        usedSection4 = true;
                        continue;

                        // Move to EXPANDED region
                        //Console.WriteLine("Room " + i + " no more space jump to 0x121210");
                        //currentPos = 0x121210;
                        //MessageBox.Show("We are running out space in the original portion of the ROM next data will be writed to : 0x121210");
                    }
                }
            }

            if (usedSection4)
            {
                Console.WriteLine("Used section4 for tiles index at location : " + section4Start.ToString("X6") + "Length of :" + (section4Index - section4Start).ToString("X6"));
            }

            int objectPointer = Utils.SnesToPc(ROM.ReadLong(Constants.room_object_pointer));
            ROM.StartBlockLogWriting("Room And Doors Pointers", objectPointer);
            for (int i = 0; i < Constants.NumberOfRooms; i++)
            {
                ROM.WriteLong2(objectPointer + (i * 3), roomTilesPointers[i], true, "Room " + i.ToString("D3") + " Tiles Pointer");
                ROM.WriteLong2(Constants.doorPointers + (i * 3), roomDoorsPointers[i], true, "Room " + i.ToString("D3") + " Doors Pointer");
            }

            ROM.EndBlockLogWriting();

            return false; // False = no error.
        }

        private void saveObjectBytes2(int roomId, int position, byte[] bytes, int doorOffset)
        {
            this.roomTilesPointers[roomId] = Utils.PcToSnes(position);
            this.roomDoorsPointers[roomId] = Utils.PcToSnes(position + doorOffset);
            // Update the index.

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

            Array.Copy(bytes, 0, ROM.DATA2, position, bytes.Length);
            ROM.EndBlockLogWriting();
        }

        public bool saveallPots2(short[] listofrooms)
        {
            int pos = Constants.items_data_start + 2; // Skip 2 FF FF that are empty pointer
            ROM.StartBlockLogWriting("Pots Items Data", pos);
            for (int i = 0; i < Constants.NumberOfRooms; i++)
            {
                if (listofrooms.Contains((short)i))
                {
                    if (this.AllRooms[i].pot_items.Count == 0)
                    {
                        ROM.WriteShort2(Constants.room_items_pointers + (i * 2), Utils.PcToSnes(Constants.items_data_start), true, "Items Pointer for Room " + i.ToString("D3"));
                        continue;
                    }

                    // Pointer:
                    ROM.WriteShort2(Constants.room_items_pointers + (i * 2), Utils.PcToSnes(pos), true, "Items Pointer for Room " + i.ToString("D3"));
                    for (int j = 0; j < this.AllRooms[i].pot_items.Count; j++)
                    {
                        if (this.AllRooms[i].pot_items[j].layer == 0)
                        {
                            this.AllRooms[i].pot_items[j].bg2 = false;
                        }
                        else
                        {
                            this.AllRooms[i].pot_items[j].bg2 = true;
                        }

                        int xy = (((this.AllRooms[i].pot_items[j].y * 64) + this.AllRooms[i].pot_items[j].x) << 1);

                        byte[] data = new byte[3]
                        {
                           (byte)(xy & 0xFF),
                           (byte)(((xy >> 8) & 0xFF) + (this.AllRooms[i].pot_items[j].bg2 ? 0x20 : 0x00)),
                           this.AllRooms[i].pot_items[j].id
                        };

                        ROM.Write2(pos, data, true, "Items Data for Room " + i.ToString("D3"));
                        pos += 3;
                    }

                    ROM.WriteShort2(pos, 0xFFFF, true);
                    pos += 2;
                    if (pos > Constants.items_data_end)
                    {
                        ROM.SaveLogs();
                        return true;
                    }
                }
                else
                {
                    if (DungeonsData.all_rooms_moved[i].pot_items.Count == 0)
                    {
                        ROM.WriteShort2(Constants.room_items_pointers + (i * 2), Utils.PcToSnes(Constants.items_data_start), true, "Items Pointer for Room " + i.ToString("D3"));
                        continue;
                    }

                    // Pointer:
                    ROM.WriteShort2(Constants.room_items_pointers + (i * 2), Utils.PcToSnes(pos), true, "Items Pointer for Room " + i.ToString("D3"));
                    for (int j = 0; j < DungeonsData.all_rooms_moved[i].pot_items.Count; j++)
                    {
                        if (DungeonsData.all_rooms_moved[i].pot_items[j].layer == 0)
                        {
                            DungeonsData.all_rooms_moved[i].pot_items[j].bg2 = false;
                        }
                        else
                        {
                            DungeonsData.all_rooms_moved[i].pot_items[j].bg2 = true;
                        }

                        int xy = (((DungeonsData.all_rooms_moved[i].pot_items[j].y * 64) + DungeonsData.all_rooms_moved[i].pot_items[j].x) << 1);

                        byte[] data = new byte[3]
                        {
                           (byte)(xy & 0xFF),
                           (byte)(((xy >> 8) & 0xFF) + (DungeonsData.all_rooms_moved[i].pot_items[j].bg2 ? 0x20 : 0x00)),
                           DungeonsData.all_rooms_moved[i].pot_items[j].id
                        };

                        ROM.Write2(pos, data, true, "Items Data for Room " + i.ToString("D3"));
                        pos += 3;
                    }

                    ROM.WriteShort2(pos, 0xFFFF, true);
                    pos += 2;
                    if (pos > Constants.items_data_end)
                    {
                        ROM.SaveLogs();
                        return true;
                    }
                }
            }

            ROM.EndBlockLogWriting();
            return false; // False = no error.
        }

        public bool saveBlocks2()
        {
            // If we reach 0x80 size jump to pointer2 etc...
            int[] region = new int[4] { Constants.blocks_pointer1, Constants.blocks_pointer2, Constants.blocks_pointer3, Constants.blocks_pointer4 };
            int blockCount = 0;
            int roomIndex = 0;
            int pos = GetLongPointerSNESToPC(region[roomIndex]);
            int count = 0;
            ROM.StartBlockLogWriting("Blocks Data", pos);

            for (int i = 0; i < Constants.NumberOfRooms; i++)
            {
                foreach (Room_Object room in this.AllRooms[i].tilesObjects)
                {
                    if ((room.options & ObjectOption.Block) == ObjectOption.Block) // If we find a block save it.
                    {
                        int xy = (((room.Y * 64) + room.X) << 1);
                        byte[] data = new byte[4]
                        {
                            (byte)((i & 0xFF)),
                            (byte)(((i >> 8) & 0xFF)),
                            (byte)(xy & 0xFF),
                            ((byte)(((xy >> 8) & 0x1F) + ((byte)room.Layer * 0x20)))
                        };

                        ROM.Write2(pos, data, true, "Room:" + i.ToString("D3") + "X:" + room.X.ToString("D2") + " Y:" + room.X.ToString("D2") + " L:" + room.X.ToString("D2"));

                        pos += 4;
                        count += 4;
                        if (count >= 0x80)
                        {
                            roomIndex++;
                            pos = GetLongPointerSNESToPC(region[roomIndex]);
                            count = 0;
                        }

                        blockCount++;
                    }
                }
            }

            if (blockCount > 99)
            {
                // Too many blocks.
                return true; // False = no error.
            }

            ROM.EndBlockLogWriting();

            /*
            if (b3 == 0xFF && b4 == 0xFF)
            {
                break;
            }

            int address = ((b4 & 0x1F) << 8 | b3) >> 1;
            int px = address % 64;
            int py = address >> 6;
            Room_Object r = addObject(0x0E00, (byte)(px), (byte)(py), 0, (byte)((b4 & 0x20) >> 5));
            */

            return false; // False = no error.
        }

        public bool saveTorches2()
        {
            int bytes_count = ROM.ReadShort(Constants.torches_length_pointer);

            int pos = Constants.torch_data;
            ROM.StartBlockLogWriting("Torches Data", pos);

            // 288 torches?
            for (int i = 0; i < Constants.NumberOfRooms; i++)
            {
                bool torchInRoom = false;
                foreach (Room_Object room in this.AllRooms[i].tilesObjects)
                {
                    if ((room.options & ObjectOption.Torch) == ObjectOption.Torch) // If we find a torch.
                    {
                        // If we find a torch then store room if it not stored.
                        if (!torchInRoom)
                        {
                            ROM.WriteShort2(pos, i, true, "Torches in room " + i.ToString("D3"));

                            pos += 2;
                            torchInRoom = true;
                        }

                        int xy = ((room.Y * 64) + room.X) << 1;
                        byte value1 = (byte)(xy & 0xFF);
                        ROM.Write2(pos, value1);
                        pos++;
                        byte value2 = (byte)((xy >> 8) & 0xFF);

                        if ((byte)room.Layer == 1)
                        {
                            value2 |= 0x20;
                        }

                        value2 |= (byte)((room.lit ? 1 : 0) << 7);
                        ROM.Write2(pos, value2);
                        pos++;
                    }
                }

                if (torchInRoom)
                {
                    ROM.WriteShort2(pos, 0xFFFF);
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
                ROM.WriteShort2(Constants.torches_length_pointer, npos);
            }

            ROM.EndBlockLogWriting();
            return false; // False = no error.
        }
    }
}

