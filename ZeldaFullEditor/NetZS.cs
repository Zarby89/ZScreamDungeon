using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Lidgren.Network;
using ZeldaFullEditor.Data;

namespace ZeldaFullEditor.Properties
{
    internal class NetZS
    {

        internal static NetClient client;
        internal static byte userID;
        internal static bool connected = false;
        private DungeonMain form;
        internal int romPos = 0;
        internal byte uniqueUserID = 0;
        internal volatile byte[] romData = new byte[0x200000];
        internal NetServer server;
        internal bool host = false;
        internal List<NetPeer> allClients = new List<NetPeer>();
        internal NetPeer connectedTo;

        internal NetZS(DungeonMain form, bool server = false)
        {
            this.form = form;
            this.host = server;
        }

        internal void ReadIncomingMessages()
        {

            while (true)
            {
                if (host)
                {
                    NetIncomingMessage im;
                    while ((im = server.ReadMessage()) != null)
                    {
                        switch (im.MessageType)
                        {
                            case NetIncomingMessageType.Data:

                                Console.WriteLine("Received data from client " + im.Data.ToString());
                                if (im.Data[0] == 04) // tile draw
                                {
                                    ReceivedTileDraw(im);
                                    SendBackToOthers(im);
                                }
                                else if (im.Data[0] == 05) // tile draw move
                                {
                                    ReceivedTileDrawMove(im);
                                    SendBackToOthers(im);
                                }
                                else if (im.Data[0] == 0x80) // wait signal
                                {
                                    Console.WriteLine("Client is fully connected and have rom loaded tell the others!");
                                    SendBackToOthers(im);
                                }
                                else if (im.Data[0] == 64) // Save signal
                                {
                                    Console.WriteLine("Client requested a save!");
                                    form.SaveToolStripMenuItem_Click(null, null);

                                }
                                else if (im.Data[0] == 03) //checksum request for LW
                                {
                                    ServerChecksum(im);
                                }
                                else if (im.Data[0] == 06) //entrance data
                                {
                                    ReceivedEntranceData(im);
                                    SendBackToOthers(im);
                                }
                                else if (im.Data[0] == 07) //sprite data
                                {
                                    ReceivedSpriteData(im);
                                    SendBackToOthers(im);
                                }
                                else if (im.Data[0] == 08) //exit data
                                {
                                    ReceivedExitData(im);
                                    SendBackToOthers(im);
                                }
                                else if (im.Data[0] == 09) //Item data
                                {
                                    ReceivedItemData(im);
                                    SendBackToOthers(im);
                                }
                                else if (im.Data[0] == 10) // transport data
                                {
                                    ReceivedTransportData(im);
                                    SendBackToOthers(im);
                                }
                                else if (im.Data[0] == 11) // transport data
                                {
                                    ReceivedGraveData(im);
                                    SendBackToOthers(im);
                                }
                                else if (im.Data[0] == 12) // large map changed
                                {
                                    ReceivedLargeMapChanged(im);
                                    SendBackToOthers(im);
                                }
                                else if (im.Data[0] == 13) // map properties changed
                                {
                                    ReceivedMapProperties(im);
                                    SendBackToOthers(im);
                                }
                                else if (im.Data[0] == 16) // map properties changed
                                {
                                    ReceivedTileDrawOverlay(im);
                                    SendBackToOthers(im);
                                }
                                else if (im.Data[0] == 17) // map properties changed
                                {
                                    ReceivedTileDrawMoveOverlay(im);
                                    SendBackToOthers(im);
                                }
                                else if (im.Data[0] == 18) // tile116 changed
                                {
                                    ReceivedTile16Changes(im);
                                    SendBackToOthers(im);
                                }
                                else if (im.Data[0] == 19) // room objects moved
                                {
                                    ReceivedRoomObjectsMoved(im);
                                    SendBackToOthers(im);
                                }
                                else if (im.Data[0] == 20) // room objects resized
                                {
                                    ReceivedRoomObjectsResized(im);
                                    SendBackToOthers(im);
                                }
                                break;

                            case NetIncomingMessageType.VerboseDebugMessage:
                            case NetIncomingMessageType.DebugMessage:
                            case NetIncomingMessageType.WarningMessage:
                            case NetIncomingMessageType.ErrorMessage:
                                Console.WriteLine(im.ReadString());
                                break;
                            case NetIncomingMessageType.StatusChanged:
                                switch ((NetConnectionStatus)im.ReadByte())
                                {
                                    case NetConnectionStatus.Connected:
                                        PlayerConnected(im);
                                        break;
                                    case NetConnectionStatus.Disconnected:
                                        Console.WriteLine("{0} Disconnected", im.SenderEndPoint);
                                        allClients.Remove(im.SenderConnection.Peer);
                                        break;
                                    case NetConnectionStatus.RespondedAwaitingApproval:
                                        im.SenderConnection.Approve();

                                        break;
                                }

                                break;
                        }

                        server.Recycle(im);
                    }

                    Thread.Sleep(1);
                }
                else
                {
                    NetIncomingMessage im;
                    while ((im = NetZS.client.ReadMessage()) != null)
                    {
                        Console.WriteLine("client start listening for messages");
                        switch (im.MessageType)
                        {
                            case NetIncomingMessageType.Data:
                                //Console.WriteLine("Received data from server " + im.Data.Length.ToString());
                                Console.WriteLine("CMD BYTE ==  " + im.Data[0].ToString());

                                if (im.Data[0] == 0) // ROM DATA start also user unique id
                                {
                                    form.networkstatusLabel.Text = "Network Status : Receiving ROM";
                                    uniqueUserID = im.Data[1];
                                    NetZS.userID = uniqueUserID;

                                    break;
                                }

                                if (im.Data[0] == 0x80)
                                {
                                    ReceivedWaitSignal(im);
                                    break;
                                }

                                if (im.Data[0] == 1) // ROM DATA
                                {
                                    ReceivedROMData(im);
                                    break;
                                }

                                if (im.Data[0] == 2) // ROM DATA END
                                {
                                    form.networkstatusLabel.Text = "Network Status : Received ROM";
                                    ReceivedROMENDData(im);

                                    break;
                                }

                                if (im.Data[0] == 04) // tile draw
                                {
                                    if (im.Data[1] == NetZS.userID)
                                    {
                                        break;
                                    }

                                    ReceivedTileDraw(im);
                                    break;
                                }

                                if (im.Data[0] == 05) // tile draw move
                                {
                                    if (im.Data[1] == NetZS.userID)
                                    {
                                        break;
                                    }

                                    ReceivedTileDrawMove(im);
                                    break;
                                }

                                if (im.Data[0] == 06) //entrance data
                                {
                                    if (im.Data[1] == NetZS.userID)
                                    {
                                        break;
                                    }

                                    ReceivedEntranceData(im);
                                }

                                if (im.Data[0] == 07) //sprite data
                                {
                                    if (im.Data[1] == NetZS.userID)
                                    {
                                        break;
                                    }

                                    ReceivedSpriteData(im);
                                }

                                if (im.Data[0] == 08) //exit data
                                {
                                    if (im.Data[1] == NetZS.userID)
                                    {
                                        break;
                                    }

                                    ReceivedExitData(im);
                                }

                                if (im.Data[0] == 09) //item data
                                {
                                    if (im.Data[1] == NetZS.userID)
                                    {
                                        break;
                                    }

                                    ReceivedItemData(im);
                                }

                                if (im.Data[0] == 10) //item data
                                {
                                    if (im.Data[1] == NetZS.userID)
                                    {
                                        break;
                                    }
                                    ReceivedTransportData(im);
                                }
                                if (im.Data[0] == 11) //item data
                                {
                                    if (im.Data[1] == NetZS.userID)
                                    {
                                        break;
                                    }

                                    ReceivedGraveData(im);
                                }

                                if (im.Data[0] == 12) //large map changed
                                {
                                    if (im.Data[1] == NetZS.userID)
                                    {
                                        break;
                                    }

                                    ReceivedLargeMapChanged(im);
                                }

                                if (im.Data[0] == 13) //large map changed
                                {
                                    if (im.Data[1] == NetZS.userID)
                                    {
                                        break;
                                    }

                                    ReceivedMapProperties(im);
                                }

                                if (im.Data[0] == 16) //large map changed
                                {
                                    if (im.Data[1] == NetZS.userID)
                                    {
                                        break;
                                    }

                                    ReceivedTileDrawOverlay(im);
                                }

                                if (im.Data[0] == 17) //large map changed
                                {
                                    if (im.Data[1] == NetZS.userID)
                                    {
                                        break;
                                    }

                                    ReceivedTileDrawMoveOverlay(im);
                                }

                                if (im.Data[0] == 18) //large map changed
                                {
                                    if (im.Data[1] == NetZS.userID)
                                    {
                                        break;
                                    }

                                    ReceivedTile16Changes(im);
                                }

                                if (im.Data[0] == 19) //dungeon objects moved
                                {
                                    if (im.Data[1] == NetZS.userID)
                                    {
                                        break;
                                    }

                                    ReceivedRoomObjectsMoved(im);
                                }

                                break;

                            case NetIncomingMessageType.VerboseDebugMessage:
                            case NetIncomingMessageType.DebugMessage:
                            case NetIncomingMessageType.WarningMessage:
                            case NetIncomingMessageType.ErrorMessage:
                                Console.WriteLine(im.ReadString());
                                break;
                        }

                        NetZS.client.Recycle(im);
                    }

                    Thread.Sleep(1);
                }
            }
        }

        private void ReceivedRoomObjectsResized(NetIncomingMessage im)
        {
            NetZSBuffer buffer = new NetZSBuffer(im.Data);
            buffer.ReadByte(); // cmd id 20
            buffer.ReadByte(); // user id
            int roomindex = buffer.ReadInt();
            int uID = buffer.ReadInt(); // tiles changed count
            Room_Object[] ro = DungeonsData.AllRooms[roomindex].tilesObjects.Where(x => x.uniqueID == uID).ToArray();
            if (ro.Length == 0)
            {
                Console.WriteLine("Oops object ID " + uID + " Is not found!");
                return;
            }

            Room_Object o = ro[0];
            o.Size = buffer.ReadByte();
            if (form.activeScene.room == DungeonsData.AllRooms[roomindex])
            {
                form.activeScene.DrawRoom();
                form.activeScene.Refresh();
            }
        }

        private void ReceivedRoomObjectsMoved(NetIncomingMessage im)
        {
            NetZSBuffer buffer = new NetZSBuffer(im.Data);
            buffer.ReadByte(); // cmd id 19
            buffer.ReadByte(); // user id
            int roomindex = buffer.ReadInt();
            int count = buffer.ReadInt(); // tiles changed count

            /*buffer.Write((o as Room_Object).uniqueID); // 4bytes

			buffer.Write((o as Room_Object).id);
			buffer.Write((o as Room_Object).x);
			buffer.Write((o as Room_Object).y);
			buffer.Write((o as Room_Object).ox);
			buffer.Write((o as Room_Object).oy);
			buffer.Write((o as Room_Object).layer);
			buffer.Write((o as Room_Object).size);*/

            for (int i = 0; i < count; i++)
            {
                int uID = buffer.ReadInt(); // tiles changed count
                Room_Object[] ro = DungeonsData.AllRooms[roomindex].tilesObjects.Where(x => x.uniqueID == uID).ToArray();
                Room_Object o = null;
                if (ro.Length == 0)
                {
                    Console.WriteLine("Oops object ID " + uID + " Is not found! Creating it !");
                    ushort id = buffer.ReadUShort();
                    byte x = buffer.ReadByte();
                    byte y = buffer.ReadByte();
                    byte ox = buffer.ReadByte();
                    byte oy = buffer.ReadByte();
                    byte layer = buffer.ReadByte();
                    byte size = buffer.ReadByte();
                    bool deleted = (bool)(buffer.ReadByte() == 1 ? true : false);
                    short zindex = buffer.ReadShort();

                    if (!deleted)
                    {
                        o = DungeonsData.AllRooms[roomindex].addObject(id, x, y, size, layer);
                        o.uniqueID = uID;
                        DungeonsData.AllRooms[roomindex].tilesObjects.Insert(zindex, o);
                    }

                }
                else
                {
                    o = ro[0];
                    o.id = buffer.ReadUShort();
                    o.X = buffer.ReadByte();
                    o.Y = buffer.ReadByte();
                    o.nx = o.X;
                    o.ny = o.Y;
                    o.ox = buffer.ReadByte();
                    o.oy = buffer.ReadByte();
                    o.Layer = (Room_Object.LayerType)buffer.ReadByte();
                    o.Size = buffer.ReadByte();
                    bool deleted = (bool)(buffer.ReadByte() == 1 ? true : false);
                    short zindex = buffer.ReadShort();

                    DungeonsData.AllRooms[roomindex].tilesObjects.Remove(o);
                    if (!deleted)
                    {
                        DungeonsData.AllRooms[roomindex].tilesObjects.Insert(zindex, o);
                    }
                }

                if (o != null)
                {
                    Console.WriteLine("Moved ObjectID to position " + o.X + " , " + o.Y);
                }
            }

            if (form.activeScene.room == DungeonsData.AllRooms[roomindex])
            {
                form.activeScene.DrawRoom();
                form.activeScene.Refresh();
            }

        }

        private void ReceivedTile16Changes(NetIncomingMessage im)
        {
            NetZSBuffer buffer = new NetZSBuffer(im.Data);
            buffer.ReadByte(); // cmd id 18
            buffer.ReadByte(); // user id
            short count = buffer.ReadShort(); // tiles changed count
            for (int i = 0; i < count; i++)
            {
                ushort tileChanged = buffer.ReadUShort();
                form.overworldEditor.scene.ow.Tile16List[tileChanged].Tile0 = GFX.gettilesinfo(buffer.ReadUShort());
                form.overworldEditor.scene.ow.Tile16List[tileChanged].Tile1 = GFX.gettilesinfo(buffer.ReadUShort());
                form.overworldEditor.scene.ow.Tile16List[tileChanged].Tile2 = GFX.gettilesinfo(buffer.ReadUShort());
                form.overworldEditor.scene.ow.Tile16List[tileChanged].Tile3 = GFX.gettilesinfo(buffer.ReadUShort());
            }
        }

        private void ReceivedGraveData(NetIncomingMessage im)
        {
            NetZSBuffer buffer = new NetZSBuffer(im.Data);
            buffer.ReadByte(); // cmd id 11
            buffer.ReadByte(); // user id
            int uId = buffer.ReadInt(); // item unique id

            Gravestone[] graves = form.overworldEditor.scene.ow.AllGraves.Where(x => x.UniqueID == uId).ToArray();
            Gravestone gravestone = graves[0];

            gravestone.YTilePos = buffer.ReadUShort();
            gravestone.XTilePos = buffer.ReadUShort();
            gravestone.TilemapPos = buffer.ReadUShort();
            gravestone.GFX = buffer.ReadUShort();

            form.overworldEditor.scene.Invalidate();
            Console.WriteLine("Transport " + uId + " changed!");
        }

        private void ReceivedTransportData(NetIncomingMessage im)
        {
            NetZSBuffer buffer = new NetZSBuffer(im.Data);
            buffer.ReadByte(); // cmd id 10
            buffer.ReadByte(); // user id
            int uId = buffer.ReadInt(); // item unique id
            TransportOW[] transports = form.overworldEditor.scene.ow.AllWhirlpools.Where(x => x.ID == uId).ToArray();
            TransportOW transport = transports[0];
            transport.unk1 = buffer.ReadByte();
            transport.unk2 = buffer.ReadByte();
            transport.AreaX = buffer.ReadByte();
            transport.AreaY = buffer.ReadByte();

            transport.vramLocation = buffer.ReadUShort();
            transport.xScroll = buffer.ReadUShort();
            transport.yScroll = buffer.ReadUShort();
            transport.playerX = buffer.ReadUShort();
            transport.playerY = buffer.ReadUShort();
            transport.cameraX = buffer.ReadUShort();
            transport.cameraY = buffer.ReadUShort();
            transport.MapID = buffer.ReadUShort();
            transport.whirlpoolPos = buffer.ReadUShort();

            form.overworldEditor.scene.Invalidate();
            Console.WriteLine("Transport " + uId + " changed!");
        }

        private void ReceivedItemData(NetIncomingMessage im)
        {
            NetZSBuffer buffer = new NetZSBuffer(im.Data);
            buffer.ReadByte(); // cmd id 09
            buffer.ReadByte(); // user id

            int uId = buffer.ReadInt(); // item unique id
            RoomPotSaveEditor[] items = form.overworldEditor.scene.ow.AllItems.Where(x => x.UniqueID == uId).ToArray();
            RoomPotSaveEditor item = null;
            if (items.Length == 0)
            {
                item = new RoomPotSaveEditor(0, 0, 0, 0, false);
                item.UniqueID = uId;
                form.overworldEditor.scene.ow.AllItems.Add(item);
            }
            else
            {
                item = items[0];
            }

            item.GameX = buffer.ReadByte();
            item.GameY = buffer.ReadByte();
            item.ID = buffer.ReadByte();
            item.X = buffer.ReadInt();
            item.Y = buffer.ReadInt();
            item.RoomMapID = buffer.ReadUShort();
            item.BG2 = buffer.ReadByte() == 1 ? true : false;
            item.Deleted = buffer.ReadByte() == 1 ? true : false;
            form.overworldEditor.scene.Invalidate();
            Console.WriteLine("Item " + uId + " changed!");
        }

        private void ReceivedSpriteData(NetIncomingMessage im)
        {
            NetZSBuffer buffer = new NetZSBuffer(im.Data);
            buffer.ReadByte(); // cmd id 07
            buffer.ReadByte(); // user id
            int sId = buffer.ReadInt(); // sprite unique id
            byte sprstate = buffer.ReadByte();
            byte sprid = buffer.ReadByte();
            Sprite[] sprites = form.overworldEditor.scene.ow.AllSprites[sprstate].Where(x => x.uniqueID == sId).ToArray();
            Sprite spr = null;

            if (sprites.Length == 0)
            {
                spr = new Sprite(0, sprid, 0, 0, 0, 0);
                spr.uniqueID = sId;
                form.overworldEditor.scene.ow.AllSprites[sprstate].Add(spr);
            }
            else
            {
                spr = sprites[0];
            }

            spr.id = sprid;
            spr.mapid = buffer.ReadByte();
            spr.map_x = buffer.ReadInt();
            spr.map_y = buffer.ReadInt();
            spr.x = buffer.ReadByte();
            spr.y = buffer.ReadByte();
            spr.deleted = (buffer.ReadByte() == 1 ? true : false); // deleted?

            form.overworldEditor.scene.Invalidate();
            Console.WriteLine("Sprite " + sId + " changed!");
        }

        private void ReceivedEntranceData(NetIncomingMessage im)
        {
            NetZSBuffer buffer = new NetZSBuffer(im.Data);
            buffer.ReadByte(); // cmd id 06
            buffer.ReadByte(); // user id
            int uId = buffer.ReadInt(); // unique id
            byte eId = buffer.ReadByte(); // entrance id
            EntranceOW entrance = null;
            EntranceOW[] entrances = form.overworldEditor.scene.ow.AllEntrances.Where(x => x.UniqueID == uId).ToArray();
            if (entrances.Length == 0)
            {
                EntranceOW[] entrancesHoles = form.overworldEditor.scene.ow.AllHoles.Where(x => x.UniqueID == uId).ToArray();
                entrance = entrancesHoles[0];
            }
            else
            {
                entrance = entrances[0];
            }

            entrance.EntranceID = eId;
            entrance.MapPos = buffer.ReadUShort();
            entrance.X = buffer.ReadInt();
            entrance.Y = buffer.ReadInt();
            entrance.AreaX = buffer.ReadByte();
            entrance.AreaY = buffer.ReadByte();
            entrance.MapID = buffer.ReadShort();
            entrance.IsHole = buffer.ReadByte() == 1 ? true : false;
            entrance.Deleted = buffer.ReadByte() == 1 ? true : false;
            form.overworldEditor.scene.Invalidate();
            Console.WriteLine("Entrance " + eId + " changed!");
        }

        private void ReceivedExitData(NetIncomingMessage im)
        {
            NetZSBuffer buffer = new NetZSBuffer(im.Data);
            buffer.ReadByte(); // cmd id 08
            buffer.ReadByte(); // user id
            int uId = buffer.ReadInt(); // unique id
            ExitOW exit = form.overworldEditor.scene.ow.AllExits.Where(x => x.UniqueID == uId).ToArray()[0];

            exit.ScrollModY = buffer.ReadByte();
            exit.ScrollModX = buffer.ReadByte();
            exit.DoorXEditor = buffer.ReadByte();
            exit.DoorYEditor = buffer.ReadByte();
            exit.AreaX = buffer.ReadByte();
            exit.AreaY = buffer.ReadByte();
            exit.VRAMLocation = buffer.ReadUShort();
            exit.RoomID = buffer.ReadUShort();
            exit.XScroll = buffer.ReadUShort();
            exit.YScroll = buffer.ReadUShort();
            exit.CameraX = buffer.ReadUShort();
            exit.CameraY = buffer.ReadUShort();
            exit.DoorType1 = buffer.ReadUShort();
            exit.DoorType2 = buffer.ReadUShort();
            exit.PlayerX = buffer.ReadUShort();
            exit.PlayerY = buffer.ReadUShort();
            exit.IsAutomatic = buffer.ReadByte() == 1 ? true : false;
            exit.Deleted = buffer.ReadByte() == 1 ? true : false;
            form.overworldEditor.scene.Invalidate();
            Console.WriteLine("Exit " + uId + " changed!");
        }

        private void ServerChecksum(NetIncomingMessage im)
        {
            int checksum = 0;
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 256; y++)
                {
                    checksum += form.overworldEditor.scene.ow.AllMapTile32LW[x, y];
                }
            }

            int clientChecksum = im.Data[2] | im.Data[3] << 8 | im.Data[4] << 16 | im.Data[5] << 24;

            if (clientChecksum != checksum)
            {
                // uh oh that client doesn't have proper LW !
            }
        }

        private void SendBackToOthers(NetIncomingMessage im)
        {
            NetOutgoingMessage msg = server.CreateMessage();
            byte[] data = new byte[im.Data.Length];
            Array.Copy(im.Data, data, data.Length);
            msg.Write(data);

            server.SendToAll(msg, NetDeliveryMethod.ReliableOrdered);
            server.FlushSendQueue();
        }

        private void ReceivedROMENDData(NetIncomingMessage im)
        {
            form.Invoke((MethodInvoker)delegate
            {
                form.loadTimer.Enabled = true;
                form.loadTimer.Start();
            });
            Console.WriteLine("Loading Project! ROM");
        }

        private void ReceivedROMData(NetIncomingMessage im)
        {
            for (int i = 0; i < im.Data.Length - 1; i++)
            {
                romData[i + romPos] = im.Data[i + 1];
            }
            romPos += 0x1000;
        }

        private void ReceivedWaitSignal(NetIncomingMessage im)
        {
            if (im.Data[1] == 0x00)
            {
                Console.WriteLine("Wait signal received");
                //this.Enabled = false;
            }
            else if (im.Data[1] == 0x01)
            {
                Console.WriteLine("WaitEND signal received");
                //this.Enabled = true;
            }
        }

        private void ReceivedLargeMapChanged(NetIncomingMessage im)
        {
            NetZSBuffer buffer = new NetZSBuffer(im.Data);
            buffer.ReadByte(); // cmd id 12
            buffer.ReadByte(); // user id
            int map = buffer.ReadInt(); // unique id
            bool largeCheck = buffer.ReadByte() == 1 ? true : false;
            form.overworldEditor.UpdateLargeMap(map, largeCheck);
        }

        private void ReceivedMapProperties(NetIncomingMessage im)
        {
            NetZSBuffer buffer = new NetZSBuffer(im.Data);
            buffer.ReadByte(); // cmd id 13
            buffer.ReadByte(); // user id
            byte map = buffer.ReadByte(); // map id

            OverworldMap[] owmaps = form.overworldEditor.scene.ow.AllMaps.Where(x => x.Index == map).ToArray();
            OverworldMap owmap = null;
            if (owmaps.Length > 0)
            {
                owmap = owmaps[0];

                owmap.AuxPalette = buffer.ReadByte();
                owmap.GFX = buffer.ReadByte();
                owmap.MessageID = buffer.ReadShort();
                byte state = buffer.ReadByte();
                owmap.SpriteGFX[state] = buffer.ReadByte();
                owmap.SpritePalette[state] = buffer.ReadByte();
                form.overworldEditor.UpdateGUIProperties(owmap, state);

                if (owmap.LargeMap)
                {
                    form.overworldEditor.scene.ow.AllMaps[owmap.Index + 1].GFX = owmap.GFX;
                    form.overworldEditor.scene.ow.AllMaps[owmap.Index + 1].SpriteGFX = owmap.SpriteGFX;
                    form.overworldEditor.scene.ow.AllMaps[owmap.Index + 1].AuxPalette = owmap.AuxPalette;
                    form.overworldEditor.scene.ow.AllMaps[owmap.Index + 1].SpritePalette = owmap.SpritePalette;

                    form.overworldEditor.scene.ow.AllMaps[owmap.Index + 8].GFX = owmap.GFX;
                    form.overworldEditor.scene.ow.AllMaps[owmap.Index + 8].SpriteGFX = owmap.SpriteGFX;
                    form.overworldEditor.scene.ow.AllMaps[owmap.Index + 8].AuxPalette = owmap.AuxPalette;
                    form.overworldEditor.scene.ow.AllMaps[owmap.Index + 8].SpritePalette = owmap.SpritePalette;

                    form.overworldEditor.scene.ow.AllMaps[owmap.Index + 9].GFX = owmap.GFX;
                    form.overworldEditor.scene.ow.AllMaps[owmap.Index + 9].SpriteGFX = owmap.SpriteGFX;
                    form.overworldEditor.scene.ow.AllMaps[owmap.Index + 9].AuxPalette = owmap.AuxPalette;
                    form.overworldEditor.scene.ow.AllMaps[owmap.Index + 9].SpritePalette = owmap.SpritePalette;

                    owmap.BuildMap();
                    form.overworldEditor.scene.ow.AllMaps[owmap.Index + 1].BuildMap();
                    form.overworldEditor.scene.ow.AllMaps[owmap.Index + 8].BuildMap();
                    form.overworldEditor.scene.ow.AllMaps[owmap.Index + 9].BuildMap();
                }

                form.overworldEditor.scene.Invalidate();
            }
        }

        private void ReceivedTileDrawMove(NetIncomingMessage im)
        {
            NetZSBuffer buffer = new NetZSBuffer(im.Data);
            buffer.ReadByte(); // cmd id 16
            buffer.ReadByte(); // user id

            int tileX = buffer.ReadInt();
            int tileY = buffer.ReadInt();
            int tilesizex = buffer.ReadInt();
            byte worldoffset = buffer.ReadByte(); // user id
            int tilecount = buffer.ReadInt();

            ushort[] selectedTiles = new ushort[tilecount];
            for (int i = 0; i < tilecount; i++)
            {
                selectedTiles[i] = (ushort)buffer.ReadUShort();
            }

            int y = 0;
            int x = 0;

            for (int i = 0; i < selectedTiles.Length; i++)
            {
                int superX = (tileX + x) / 32;
                int superY = (tileY + y) / 32;
                int mapId = (superY * 8) + superX + worldoffset;

                if (tileX + x < 256 && tileY + y < 256)
                {
                    form.overworldEditor.scene.ow.AllMaps[mapId].TilesUsed[tileX + x, tileY + y] = selectedTiles[i];
                    form.overworldEditor.scene.ow.AllMaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), selectedTiles[i], form.overworldEditor.scene.ow.AllMaps[mapId].GFXPointer, GFX.mapblockset16);
                }

                x++;
                if (x >= tilesizex)
                {
                    y++;
                    x = 0;
                }
            }

            form.overworldEditor.scene.Invalidate();
        }

        private void ReceivedTileDraw(NetIncomingMessage im)
        {

            NetZSBuffer buffer = new NetZSBuffer(im.Data);
            buffer.ReadByte(); // cmd id 16
            buffer.ReadByte(); // user id

            int tileX = buffer.ReadInt();
            int tileY = buffer.ReadInt();
            int tilesizex = buffer.ReadInt();
            byte worldoffset = buffer.ReadByte(); // user id
            int tilecount = buffer.ReadInt();

            ushort[] selectedTiles = new ushort[tilecount];
            for (int i = 0; i < tilecount; i++)
            {
                selectedTiles[i] = (ushort)buffer.ReadUShort();
            }

            int y = 0;
            int x = 0;

            for (int i = 0; i < selectedTiles.Length; i++)
            {
                int superX = (tileX + x) / 32;
                int superY = (tileY + y) / 32;
                int mapId = (superY * 8) + superX + worldoffset;
                form.overworldEditor.scene.ow.AllMaps[mapId].TilesUsed[tileX + x, tileY + y] = selectedTiles[i];
                form.overworldEditor.scene.ow.AllMaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), selectedTiles[i], form.overworldEditor.scene.ow.AllMaps[mapId].GFXPointer, GFX.mapblockset16);
                x++;
                if (x >= tilesizex)
                {
                    y++;
                    x = 0;
                }
            }

            form.overworldEditor.scene.Invalidate();
        }

        private void ReceivedTileDrawMoveOverlay(NetIncomingMessage im) //17
        {
            NetZSBuffer buffer = new NetZSBuffer(im.Data);
            buffer.ReadByte(); // cmd id 16
            buffer.ReadByte(); // user id

            int tileX = buffer.ReadInt();
            int tileY = buffer.ReadInt();
            int tilesizex = buffer.ReadInt();
            bool deleting = buffer.ReadByte() == 1 ? true : false; // user id
            byte worldoffset = buffer.ReadByte(); // user id
            int tilecount = buffer.ReadInt();

            ushort[] selectedTiles = new ushort[tilecount];
            for (int i = 0; i < tilecount; i++)
            {
                selectedTiles[i] = (ushort)buffer.ReadUShort();
            }

            int y = 0;
            int x = 0;

            int superX = (tileX + x) / 32;
            int superY = (tileY + y) / 32;
            int mapId = (superY * 8) + superX + worldoffset;

            int mid = form.overworldEditor.scene.ow.AllMaps[mapId].ParentID;
            int superMX = (mid % 8) * 32;
            int superMY = (mid / 8) * 32;

            for (int i = 0; i < selectedTiles.Length; i++)
            {
                superX = (tileX + x) / 32;
                superY = (tileY + y) / 32;
                mapId = (superY * 8) + superX + worldoffset;
                if (tileX + x < 255 && tileY + y < 255)
                {
                    /*
					undotiles[i] = scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y];
					scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y] = scene.selectedTile[i];
					scene.ow.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), scene.selectedTile[i], scene.ow.allmaps[mapId].gfxPtr, scene.ow.allmaps[mapId].blockset16);
					*/

                    TilePos tp = new TilePos((byte)((tileX + x) - (superMX)), (byte)((tileY + y) - (superMY)), selectedTiles[i]);
                    TilePos tf = form.overworldEditor.scene.compareTilePosT(tp, form.overworldEditor.scene.ow.AllOverlays[mid].TileDataList.ToArray());
                    if (deleting)
                    {
                        form.overworldEditor.scene.ow.AllOverlays[mid].TileDataList.Remove(tf);
                        x++;
                        if (x >= tilesizex)
                        {
                            y++;
                            x = 0;
                        }

                        continue;
                    }

                    if (tf == null)
                    {
                        form.overworldEditor.scene.ow.AllOverlays[mid].TileDataList.Add(tp);
                    }
                    else
                    {
                        form.overworldEditor.scene.ow.AllOverlays[mid].TileDataList.Remove(tf);
                        form.overworldEditor.scene.ow.AllOverlays[mid].TileDataList.Add(tp);
                    }
                }

                x++;
                if (x >= tilesizex)
                {
                    y++;
                    x = 0;
                }
            }

            form.overworldEditor.scene.Invalidate();
        }

        private void PlayerConnected(NetIncomingMessage im)
        {
            Console.WriteLine("{0} Connected", im.SenderEndPoint);

            // Send wait signal to all users
            NetOutgoingMessage msg = server.CreateMessage();
            byte[] data = new byte[02] { 0x80, 0x00 };
            msg.Write(data); // wait signal
            server.SendToAll(msg, NetDeliveryMethod.ReliableOrdered);
            server.FlushSendQueue();

            // Send rom send initialization to connecting user
            msg = server.CreateMessage();
            data = new byte[0x02] { 0x00, uniqueUserID }; // init the rom transfer
            uniqueUserID++; // increase the ID of the users
            data[0] = 00;
            msg.Write(data);
            server.SendMessage(msg, im.SenderConnection, NetDeliveryMethod.ReliableOrdered);
            server.FlushSendQueue();

            for (int i = 0; i < 0x200; i++) // send the rom in 0x200 packets
            {
                msg = server.CreateMessage();
                data = new byte[0x1001];
                for (int j = 0; j < 0x1000; j++)
                {
                    data[j + 1] = ROM.DATA[(i * 0x1000) + j];
                }

                data[0] = 01;
                msg.Write(data);
                server.SendMessage(msg, im.SenderConnection, NetDeliveryMethod.ReliableOrdered);
                server.FlushSendQueue();
            }

            msg = server.CreateMessage(); // send signal we finished transfering rom data
            data = new byte[0x01];
            data[0] = 02;
            msg.Write(data);
            server.SendMessage(msg, im.SenderConnection, NetDeliveryMethod.ReliableOrdered);
            server.FlushSendQueue();
        }

        private void ReceivedTileDrawOverlay(NetIncomingMessage im)//16
        {
            NetZSBuffer buffer = new NetZSBuffer(im.Data);
            buffer.ReadByte(); // cmd id 16
            buffer.ReadByte(); // user id

            int tileX = buffer.ReadInt();
            int tileY = buffer.ReadInt();
            int tilesizex = buffer.ReadInt();
            bool deleting = buffer.ReadByte() == 1 ? true : false; // user id
            byte worldoffset = buffer.ReadByte(); // user id
            int tilecount = buffer.ReadInt();

            ushort[] selectedTiles = new ushort[tilecount];
            for (int i = 0; i < tilecount; i++)
            {
                selectedTiles[i] = (ushort)buffer.ReadUShort();
            }

            int y = 0;
            int x = 0;

            int superX = (tileX + x) / 32;
            int superY = (tileY + y) / 32;
            int mapId = (superY * 8) + superX + worldoffset;

            int mid = form.overworldEditor.scene.ow.AllMaps[mapId].ParentID;
            int superMX = (mid % 8) * 32;
            int superMY = (mid / 8) * 32;

            for (int i = 0; i < selectedTiles.Length; i++)
            {
                superX = (tileX + x) / 32;
                superY = (tileY + y) / 32;
                mapId = (superY * 8) + superX + worldoffset;

                /*
				undotiles[i] = scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y];
				scene.ow.allmaps[mapId].tilesUsed[scene.globalmouseTileDownX + x, scene.globalmouseTileDownY + y] = scene.selectedTile[i];
				scene.ow.allmaps[mapId].CopyTile8bpp16(((tileX + x) * 16) - (superX * 512), ((tileY + y) * 16) - (superY * 512), scene.selectedTile[i], scene.ow.allmaps[mapId].gfxPtr, scene.ow.allmaps[mapId].blockset16);
				*/

                TilePos tp = new TilePos((byte)((tileX + x) - (superMX)), (byte)((tileY + y) - (superMY)), selectedTiles[i]);
                TilePos tf = form.overworldEditor.scene.compareTilePosT(tp, form.overworldEditor.scene.ow.AllOverlays[mid].TileDataList.ToArray());

                if (deleting)
                {
                    form.overworldEditor.scene.ow.AllOverlays[mid].TileDataList.Remove(tf);
                    x++;
                    if (x >= tilesizex)
                    {
                        y++;
                        x = 0;
                    }

                    continue;
                }

                if (tf == null)
                {
                    form.overworldEditor.scene.ow.AllOverlays[mid].TileDataList.Add(tp);
                }
                else
                {
                    form.overworldEditor.scene.ow.AllOverlays[mid].TileDataList.Remove(tf);
                    form.overworldEditor.scene.ow.AllOverlays[mid].TileDataList.Add(tp);
                }

                x++;
                if (x >= tilesizex)
                {
                    y++;
                    x = 0;
                }
            }

            form.overworldEditor.scene.Invalidate();
        }
    }

    internal class NetZSBuffer
    {
        public byte[] buffer;
        int bufferPos = 0;

        public NetZSBuffer(short size)
        {
            buffer = new byte[size];
            bufferPos = 0;
        }

        public NetZSBuffer(byte[] data)
        {
            buffer = new byte[data.Length];
            Array.Copy(data, buffer, data.Length);
            bufferPos = 0;
        }

        public byte ReadByte()
        {
            byte b = buffer[bufferPos];
            bufferPos += 1;
            return b;
        }

        public short ReadShort()
        {
            short s = (short)(buffer[bufferPos] | (buffer[bufferPos + 1] << 8));
            bufferPos += 2;
            return s;
        }

        public ushort ReadUShort()
        {
            ushort s = (ushort)(buffer[bufferPos] | (buffer[bufferPos + 1] << 8));
            bufferPos += 2;
            return s;
        }

        public int ReadInt()
        {
            int i = buffer[bufferPos] | (buffer[bufferPos + 1] << 8) | (buffer[bufferPos + 2] << 16) | (buffer[bufferPos + 3] << 24);
            bufferPos += 4;
            return i;
        }

        public void Write(byte data)
        {
            buffer[bufferPos++] = data;
        }

        public void Write(ushort data)
        {
            buffer[bufferPos++] = (byte)data;
            buffer[bufferPos++] = (byte)(data >> 8);
        }

        public void Write(short data)
        {
            buffer[bufferPos++] = (byte)data;
            buffer[bufferPos++] = (byte)(data >> 8);
        }

        public void Write(int data)
        {
            buffer[bufferPos++] = (byte)data;
            buffer[bufferPos++] = (byte)(data >> 8);
            buffer[bufferPos++] = (byte)(data >> 16);
            buffer[bufferPos++] = (byte)(data >> 24);
        }

        public void Write(ulong data)
        {
            buffer[bufferPos++] = (byte)data;
            buffer[bufferPos++] = (byte)(data >> 8);
            buffer[bufferPos++] = (byte)(data >> 16);
            buffer[bufferPos++] = (byte)(data >> 24);
            buffer[bufferPos++] = (byte)(data >> 32);
            buffer[bufferPos++] = (byte)(data >> 40);
            buffer[bufferPos++] = (byte)(data >> 48);
            buffer[bufferPos++] = (byte)(data >> 56);
        }
    }
}
