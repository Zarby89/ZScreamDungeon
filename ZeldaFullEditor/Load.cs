using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public class Load
    {
        Scene activeScene;
        public void loadSingleRoom(int i, Scene activeScene)
        {
            this.activeScene = activeScene;

            activeScene.room.tilesObjects.Clear();
            activeScene.room.pot_items.Clear();
            activeScene.room.chest_list.Clear();
            activeScene.room.sprites.Clear();

            ZipArchive zipfile = new ZipArchive(new FileStream("PROJECTFILE.zip", FileMode.Open), ZipArchiveMode.Read);
            activeScene.room.has_changed = true;
            ZipArchiveEntry entry = zipfile.GetEntry("Rooms\\Room" + i.ToString("D3") + ".zrm");

            BinaryReader br = new BinaryReader(entry.Open());

            readHeader(br);
            activeScene.room.messageid = br.ReadInt16();
            activeScene.room.damagepit = br.ReadBoolean();
            activeScene.room.layout = br.ReadByte();
            activeScene.room.floor1 = br.ReadByte();
            activeScene.room.floor2 = br.ReadByte();
            readTiles(br);
            readSprites(br);
            readItems(br);
            readChests(br);
            br.Close();
   
            activeScene.room.reloadGfx();
            activeScene.need_refresh = true;

            zipfile.Dispose();
        }







        public void readTiles(BinaryReader br)
        {
            short count = br.ReadInt16();
            for (int j = 0; j < count; j++)
            {
                //<Tiles Objects Data>
                //short ID ,byte X, byte Y, byte Layer
                short id = br.ReadInt16();
                byte x = br.ReadByte();
                byte y = br.ReadByte();
                byte size = br.ReadByte();
                byte layer = br.ReadByte();
                ObjectOption options = (ObjectOption)br.ReadByte();



                if ((options & ObjectOption.Door) == ObjectOption.Door)
                {
                    Room_Object o = new object_door(id, x, y, size, layer);
                    if (o != null)
                    {
                        o.options = (ObjectOption)options;
                        o.setRoom(activeScene.room);
                        activeScene.room.tilesObjects.Add(o);
                    }
                }
                else
                {
                    Room_Object o = activeScene.room.addObject(id, x, y, size, layer);
                    if (o != null)
                    {
                        o.options = (ObjectOption)options;
                        o.setRoom(activeScene.room);
                        activeScene.room.tilesObjects.Add(o);
                    }
                }
                    


               
                

            }
        }

        public void readSprites(BinaryReader br)
        {
            short count = br.ReadInt16();
            for (int j = 0; j < count; j++)
            {
                //<Sprites Data>
                //byte ID ,byte X, byte Y, byte Layer, byte KeyDrop, byte overlord, byte subtype

                byte id = br.ReadByte();
                byte x = br.ReadByte();
                byte y = br.ReadByte();
                byte layer = br.ReadByte();
                byte keyDrop = br.ReadByte();
                byte overlord = br.ReadByte();
                byte subtype = br.ReadByte();
                Sprite spr = new Sprite(activeScene.room, id, x, y, Sprites_Names.name[id], overlord, subtype, layer);
                activeScene.room.sprites.Add(spr);
            }
        }

        public void readItems(BinaryReader br)
        {
            short count = br.ReadInt16();
            for (int j = 0; j < count; j++)
            {
                //<Items Data>
                //byte ID ,byte X, byte Y, byte Layer
                byte id = br.ReadByte();
                byte x = br.ReadByte();
                byte y = br.ReadByte();
                bool bg2 = br.ReadBoolean();

                PotItem p = new PotItem(id, x, y, bg2);
                activeScene.room.pot_items.Add(p);
            }
        }

        public void readChests(BinaryReader br)
        {
            short count = br.ReadInt16();
            for (int j = 0; j < count; j++)
            {
                //<Items Data>
                //byte Item ID, bool isBigChest
                byte item = br.ReadByte();
                bool bigChest = br.ReadBoolean();
                Chest c = new Chest(0,0,item,bigChest);
                activeScene.room.chest_list.Add(c);
            }
        }

        public void readHeader(BinaryReader br)
        {
            byte headerInfos = br.ReadByte();
            activeScene.room.bg2 = (Background2)((headerInfos >> 5) & 0x07);
            activeScene.room.collision = (byte)((headerInfos >> 2) & 0x07);
            activeScene.room.light = (((headerInfos) & 0x01) == 1 ? true : false);
            if (activeScene.room.light)
            {
                activeScene.room.bg2 = Background2.DarkRoom;
            }

            activeScene.room.palette = (byte)((br.ReadByte() & 0x3F));
            activeScene.room.blockset = (byte)((br.ReadByte()));
            activeScene.room.spriteset = (byte)((br.ReadByte()));
            activeScene.room.effect = (byte)((br.ReadByte()));
            activeScene.room.tag1 = (TagKey)((br.ReadByte()));
            activeScene.room.tag2 = (TagKey)((br.ReadByte()));

            headerInfos = br.ReadByte();
            activeScene.room.holewarp_plane = (byte)((headerInfos) & 0x03);
            activeScene.room.staircase_plane[0] = (byte)((headerInfos >> 2) & 0x03);
            activeScene.room.staircase_plane[1] = (byte)((headerInfos + 7 >> 4) & 0x03);
            activeScene.room.staircase_plane[2] = (byte)((headerInfos + 7 >> 6) & 0x03);

            activeScene.room.staircase_plane[3] = (byte)((br.ReadByte()) & 0x03);

            activeScene.room.holewarp = (byte)((br.ReadByte()));
            activeScene.room.staircase_rooms[0] = (byte)((br.ReadByte()));
            activeScene.room.staircase_rooms[1] = (byte)((br.ReadByte()));
            activeScene.room.staircase_rooms[2] = (byte)((br.ReadByte()));
            activeScene.room.staircase_rooms[3] = (byte)((br.ReadByte()));
        }

        



    }
}
