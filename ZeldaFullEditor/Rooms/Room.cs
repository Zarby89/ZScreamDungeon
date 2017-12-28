using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor
{
    [Serializable]
    public class Room : ICloneable
    {
        //List<SpriteName> stringtodraw = new List<SpriteName>();
        public int index;
        int header_location;
        public byte layout;
        public byte floor1;
        public byte floor2;
        public byte blockset;
        public byte spriteset;
        public byte palette;
        public byte collision; //Need a better name for that
        public Background2 bg2;
        public byte effect;//TODO : enum
        public byte tag1;//TODO : enum
        public byte tag2;//TODO : enum
        public byte holewarp;
        public byte[] staircase_rooms = new byte[4];
        public byte[] staircase_plane = new byte[4];
        public bool light;
        public byte holewarp_plane;
        public byte messageid;
        public bool damagepit;
        public byte[] blocks = new byte[24];
        public List<Chest> chest_list = new List<Chest>();
        public List<Room_Object> tilesObjects = new List<Room_Object>();
        public List<Room_Object> layouttilesObjects = new List<Room_Object>();
        public PotItems_Name items_name = new PotItems_Name();
        public List<Sprite> sprites = new List<Sprite>();
        public List<PotItem> pot_items = new List<PotItem>();
        public List<Object> selectedObject = new List<object>();
        public bool objectInitialized = false;
        public bool needGfxRefresh = false;
        public Room(int index)
        {
            this.index = index;
            loadHeader();

            loadTilesObjects();
            addSprites();
            addBlocks(); //TODO : Change them to have their own GFX
            addTorches(); //TODO : Change them to have their own GFX
            addDoors(); //TODO : Fix exploded wall doors
            addPotsItems();


        }

        public void reloadGfx(bool noPalette = false)
        {


            for (int i = 0; i < 8; i++)
            {
                blocks[i] = ROM.DATA[Constants.gfx_groups + (blockset * 8) + i];
            }

            for (int i = 0; i < 4; i++)
            {
                blocks[10 + i] = ROM.DATA[Constants.sprite_blockset_pointer + ((spriteset + 64) * 4) + i];
            }

            blocks[8] = 92; //static animated tile
            blocks[9] = ROM.DATA[Constants.gfx_animated + blockset];

            blocks[14] = 0; blocks[15] = 10; blocks[16] = 6; blocks[17] = 7; //Static Sprites Blocksets (fairy,pot,ect...)
            blocks[18] = 90; blocks[19] = 91; blocks[20] = 92; blocks[21] = 93;//Items Sprites
            if (Constants.Rando)
            {
                blocks[22] = 101;//rando sprites
                blocks[23] = 96;//rando sprites
            }
            else
            {
                blocks[22] = 0;
                blocks[23] = 0;
            }


            if (noPalette == false)
            {
                GFX.LoadDungeonPalette(palette);
                GFX.LoadSpritesPalette(palette);
            }

            foreach (Room_Object o in tilesObjects)
            {
                if ((o.options & ObjectOption.Door) == ObjectOption.Door)
                {
                    Console.WriteLine("Door found");
                }
            }


            GFX.load4bpp(GFX.gfxdata, blocks);


            needGfxRefresh = true;
            objectInitialized = false;
            update();
        }


        public void addSprites()
        {

            //sprites_name.name
            int sprite_address_snes = (09 << 16) +
            (ROM.DATA[Constants.room_sprites_pointers + (index * 2) + 1] << 8) +
            ROM.DATA[Constants.room_sprites_pointers + (index * 2)];
            int sprite_address = Addresses.snestopc(sprite_address_snes) + 1;


            while (true)
            {
                byte b1 = ROM.DATA[sprite_address];
                byte b2 = ROM.DATA[sprite_address + 1];
                byte b3 = ROM.DATA[sprite_address + 2];


                if (b1 == 0xFF) { break; }

                sprites.Add(new Sprite(this, b3, (byte)(b2 & 0x1F), (byte)(b1 & 0x1F), Sprites_Names.name[b3], (byte)((b2 & 0xE0) >> 5), (byte)((b1 & 0x60) >> 5), (byte)((b1 & 0x80) >> 7)));

                sprite_address += 3;

            }
        }

        public void update()
        {
            Bitmap mblockBitmap = (Bitmap)Properties.Resources.Mblock;


            foreach (Room_Object ro in tilesObjects)
            {
                if (objectInitialized == false)
                {
                    ro.resetSize();
                    ro.get_scroll_x();
                    ro.get_scroll_y();
                    ro.DrawOnBitmap();
                    if ((ro.options & ObjectOption.Block) == ObjectOption.Block)
                    {
                        using (Graphics g = Graphics.FromImage(ro.bitmap))
                        {
                            g.DrawImage(mblockBitmap, 0, 0);
                        }
                    }
                }
            }

            if (objectInitialized == false)
            {
                GFX.begin_draw(GFX.bgr_bitmap);
                DrawFloors();
                GFX.end_draw(GFX.bgr_bitmap);
                GFX.begin_draw(GFX.floor2_bitmap);
                DrawFloors(2);
                GFX.end_draw(GFX.floor2_bitmap);
            }

            objectInitialized = true;
        }


        public void DrawLayout()
        {
            foreach (Room_Object ro in tilesObjects)
            {
                
                ro.get_scroll_x();
                ro.get_scroll_y();
                ro.Draw();
            }
        }

        public void drawSprites()
        {
            Sprite prevSprite = null;
            foreach (Sprite spr in sprites)
            {
                
                if (spr.id != 0xE4)
                {
                    spr.Draw();
                }
                if (spr.id == 0xE4 && spr.x == 0x00 && spr.y == 0x1E && spr.layer == 1 && ((spr.subtype << 3)+spr.overlord)== 0x18)
                {
                    if (prevSprite != null)
                    {
                        prevSprite.DrawKey();
                    }
                }

                prevSprite = spr;
            }
        }

        public bool getLayerTiles(byte layer, ref List<byte> objectsBytes, ref List<byte> doorsBytes)
        {
            bool doorfound = false;
            for (int j = 0; j < tilesObjects.Count; j++) // save layer1 object 
            {
                Room_Object o = tilesObjects[j];
                if ((o.options & ObjectOption.Bgr) != ObjectOption.Bgr && (o.options & ObjectOption.Block) != ObjectOption.Block && (o.options & ObjectOption.Torch) != ObjectOption.Torch)
                {
                    if (o.layer == layer)
                    {
                        //if we encounter a door store it somewhere else for now and wait the end of objects layer1
                        if ((tilesObjects[j].options & ObjectOption.Door) == ObjectOption.Door)
                        {
                            byte p = 0;
                            if (o is object_door_up)
                            {
                                p = 0;
                            }
                            if (o is object_door_down)
                            {
                                p = 1;
                            }
                            if (o is object_door_left)
                            {
                                p = 2;
                            }
                            if (o is object_door_right)
                            {
                                p = 3;
                            }
                            doorfound = true;
                            byte b1 = (byte)(((o.id & 0x1E) << 3) + p);
                            byte b2 = (byte)(((o.id & 0xFF00) >> 8));
                            doorsBytes.Add(b1);
                            doorsBytes.Add(b2);
                        }
                        else
                        {
                            if ((tilesObjects[j].id & 0xF00) == 0xF00) // type3
                            {
                                //xxxxxxii yyyyyyii 11111iii
                                byte b3 = (byte)(o.id >> 4);
                                byte b1 = (byte)((o.x << 2) + (o.id & 0x03));
                                byte b2 = (byte)((o.y << 2) + ((o.id >> 2) & 0x03));
                                objectsBytes.Add(b1);
                                objectsBytes.Add(b2);
                                objectsBytes.Add(b3);
                            }
                            else if ((tilesObjects[j].id & 0x100) == 0x100) // type2
                            {
                                //111111xx xxxxyyyy yyiiiiii
                                byte b1 = (byte)(0xFC + (((o.x & 0x30) >> 4)));
                                byte b2 = (byte)(((o.x & 0x0F) << 4) + ((o.y & 0x3C) >> 2));
                                byte b3 = (byte)(((o.y & 0x03) << 6) + ((o.id & 0x3F))); //wtf? 
                                objectsBytes.Add(b1);
                                objectsBytes.Add(b2);
                                objectsBytes.Add(b3);
                            }
                            else //type1
                            {
                                //xxxxxxss yyyyyyss iiiiiiii
                                byte b1 = (byte)((o.x << 2) + ((o.size >> 2) & 0x03));
                                byte b2 = (byte)((o.y << 2) + (o.size & 0x03));
                                byte b3 = (byte)(o.id);
                                objectsBytes.Add(b1);
                                objectsBytes.Add(b2);
                                objectsBytes.Add(b3);

                            }
                        }
                    }
                }
            }
            return doorfound;
        }

        public byte[] getTilesBytes()
        {
            List<byte> objectsBytes = new List<byte>();
            List<byte> doorsBytes = new List<byte>();
            bool found_door = false;

            byte floorbyte = (byte)((floor2 << 4) + floor1);
            byte layoutbyte = (byte)(layout<<2);
            objectsBytes.Add(floorbyte);
            objectsBytes.Add(layoutbyte);

            doorsBytes.Clear();
            found_door = getLayerTiles(0, ref objectsBytes, ref doorsBytes);
  
            if (found_door)//if we found door during layer1
            {
                objectsBytes.Add(0xF0);
                objectsBytes.Add(0xFF);
                foreach (byte b in doorsBytes)
                {
                    objectsBytes.Add(b);
                }

            }
            objectsBytes.Add(0xFF);//end layer1
            objectsBytes.Add(0xFF);//end layer1

            doorsBytes.Clear();
            found_door = getLayerTiles(1, ref objectsBytes, ref doorsBytes);

            if (found_door)//if we found door during layer2
            {
                objectsBytes.Add(0xF0);
                objectsBytes.Add(0xFF);
                foreach (byte b in doorsBytes)
                {
                    objectsBytes.Add(b);
                }

            }
            objectsBytes.Add(0xFF);//end layer2
            objectsBytes.Add(0xFF);//end layer2


            doorsBytes.Clear();
            found_door = getLayerTiles(2, ref objectsBytes, ref doorsBytes);

            if (found_door)//if we found door during layer3
            {
                objectsBytes.Add(0xF0);
                objectsBytes.Add(0xFF);
                foreach (byte b in doorsBytes)
                {
                    objectsBytes.Add(b);
                }

            }
            objectsBytes.Add(0xFF);//end layer3
            objectsBytes.Add(0xFF);//end layer3


            return objectsBytes.ToArray();
        }


        public void drawPotsItems()
        {
            foreach (PotItem item in pot_items)
            {
                item.Draw();
            }
        }



        public void addDoors()
        {
            foreach (Room_Object o in tilesObjects)
            {

                o.setRoom(this);

                if (o.GetType() == typeof(object_door_up))
                {
                    short pos = (short)(((ROM.DATA[(0x197E + 1 + (o.id & 0xFF))] << 8) + ROM.DATA[(0x197E + (o.id & 0xFF))]) / 2);
                    float n = (((float)pos / 64) - (byte)(pos / 64)) * 64;
                    o.x = (byte)n;
                    o.y = (byte)(pos / 64);
                    o.options |= ObjectOption.Door;
                    o.nx = o.x;
                    o.ny = o.y;
                    o.ox = o.x;
                    o.oy = o.y;
                    
                }
                if (o.GetType() == typeof(object_door_down))
                {
                    short pos = (short)(((ROM.DATA[(0x1996 + 1 + (o.id & 0xFF))] << 8) + ROM.DATA[(0x1996 + (o.id & 0xFF))]) / 2);
                    float n = (((float)pos / 64) - (byte)(pos / 64)) * 64;
                    o.x = (byte)n;
                    o.y = (byte)(pos / 64);
                    o.y += 1;
                    o.options |= ObjectOption.Door;
                    o.nx = o.x;
                    o.ny = o.y;
                    o.ox = o.x;
                    o.oy = o.y;
                }

                if (o.GetType() == typeof(object_door_left))
                {
                    short pos = (short)(((ROM.DATA[(0x19AE + 1 + (o.id & 0xFF))] << 8) + ROM.DATA[(0x19AE + (o.id & 0xFF))]) / 2);
                    float n = (((float)pos / 64) - (byte)(pos / 64)) * 64;
                    o.x = (byte)n;
                    o.y = (byte)(pos / 64);
                    o.options |= ObjectOption.Door;
                    o.nx = o.x;
                    o.ny = o.y;
                    o.ox = o.x;
                    o.oy = o.y;

                }
                if (o.GetType() == typeof(object_door_right))
                {
                    short pos = (short)(((ROM.DATA[(0x19C6 + 1 + (o.id & 0xFF))] << 8) + ROM.DATA[(0x19C6 + (o.id & 0xFF))]) / 2);
                    float n = (((float)pos / 64) - (byte)(pos / 64)) * 64;
                    o.x = (byte)n;
                    o.y = (byte)(pos / 64);
                    //if ((o.id & 0xFF) >= 12)
                    //{
                    o.x += 1;
                    //}
                    o.options |= ObjectOption.Door;
                    o.nx = o.x;
                    o.ny = o.y;
                    o.ox = o.x;
                    o.oy = o.y;
                }
            }
        }

        short[] stairsObjects = new short[] { 0x139, 0x138,0x13B, 0x12E, 0x12D };
        public List<StaircaseRoom> staircaseRooms = new List<StaircaseRoom>();


        public void addlistBlock(ref byte[] blocksdata, int maxCount)
        {
            int pos1 = (ROM.DATA[Constants.blocks_pointer1 + 2] << 16) + (ROM.DATA[Constants.blocks_pointer1 + 1] << 8) + (ROM.DATA[Constants.blocks_pointer1]);
            pos1 = Addresses.snestopc(pos1);
            int pos2 = (ROM.DATA[Constants.blocks_pointer2 + 2] << 16) + (ROM.DATA[Constants.blocks_pointer2 + 1] << 8) + (ROM.DATA[Constants.blocks_pointer2]);
            pos2 = Addresses.snestopc(pos2);
            int pos3 = (ROM.DATA[Constants.blocks_pointer3 + 2] << 16) + (ROM.DATA[Constants.blocks_pointer3 + 1] << 8) + (ROM.DATA[Constants.blocks_pointer3]);
            pos3 = Addresses.snestopc(pos3);
            int pos4 = (ROM.DATA[Constants.blocks_pointer4 + 2] << 16) + (ROM.DATA[Constants.blocks_pointer4 + 1] << 8) + (ROM.DATA[Constants.blocks_pointer4]);
            pos4 = Addresses.snestopc(pos4);
            for (int i = 0; i < 0x80; i += 1)
            {
                blocksdata[i] = (ROM.DATA[i + pos1]);
                blocksdata[i + 0x80] = (ROM.DATA[i + pos2]);
                blocksdata[i + 0x100] = (ROM.DATA[i + pos3]);
                blocksdata[i + 0x180] = (ROM.DATA[i + pos4]);
            }
        }

        public void addBlocks()
        {
            //288
            
            int blocksCount = (short)((ROM.DATA[Constants.blocks_length+1]<<8) + ROM.DATA[Constants.blocks_length]);
            byte[] blocksdata = new byte[blocksCount * 4];
            //int blocksCount = (short)((ROM.DATA[Constants.blocks_length + 1] << 8) + ROM.DATA[Constants.blocks_length]);
            addlistBlock(ref blocksdata, blocksCount);

            for (int i = 0;i<blocksdata.Length;i+=4)
            {
                byte b1 = blocksdata[i];
                byte b2 = blocksdata[i+1];
                byte b3 = blocksdata[i+2];
                byte b4 = blocksdata[i+3];
                if (((b2 << 8) + b1) == index)
                {
                    int b = ((((b4 << 8) + b3) & 0x1FFF)>> 1);
                    float a = ((float)b / 64);
                    int py = (((((b4 << 8) + b3) & 0x1FFF) >> 1)/64);
                    a = (a - py) *64;
                    int px = (int)a;
                    Room_Object r = addObject(0x0E00, (byte)(px), (byte)(py), 0, 0);
                    if (r != null)
                    {
                        r.options |= ObjectOption.Block;
                        tilesObjects.Add(r);
                    }
                }

            }
        }
        public void addTorches()
        {
            for (int i = 0; i < 288; i += 2)
            {
                //Console.WriteLine(i);
                byte b1 = ROM.DATA[Constants.torch_data + i];
                byte b2 = ROM.DATA[Constants.torch_data + i + 1];
                if (b1 == 0xFF && b2 == 0xFF) { continue; }
                if (((b2 << 8) + b1) == index)
                {
                    i += 2;
                    while (true)
                    {
                       
                        b1 = ROM.DATA[Constants.torch_data + i];
                        b2 = ROM.DATA[Constants.torch_data + i + 1];
                       
                        if (b1 == 0xFF && b2 == 0xFF) { break; }
                        int b = ((((b2 << 8) + b1) & 0x1FFF) >> 1);
                        float a = ((float)b / 64);
                        int py = (((((b2 << 8) + b1) & 0x1FFF) >> 1) / 64);
                        a = (a - py) * 64;
                        int px = (int)a;

                        Room_Object r = addObject(0x150, (byte)px, (byte)py, 0, 0);
                        if (r != null)
                        {
                            r.options |= ObjectOption.Torch;
                            tilesObjects.Add(r);
                        }
                        //tilesObjects[tilesObjects.Count - 1].is_torch = true;
                        i += 2;
                    }
                }
                else
                {
                    while (true)
                    {
                        b1 = ROM.DATA[Constants.torch_data + i];
                        b2 = ROM.DATA[Constants.torch_data + i + 1];
                        if (b1 == 0xFF && b2 == 0xFF) { break; }
                        i += 2;
                    }
                }
            }
        }


        public void addPotsItems()
        {
            //WTF is that (01 << 16) ??
            int item_address_snes = (01 << 16) +
            (ROM.DATA[Constants.room_items_pointers + (index * 2) + 1] << 8) +
            ROM.DATA[Constants.room_items_pointers + (index * 2)];
            int item_address = Addresses.snestopc(item_address_snes);

            while (true)
            {
                byte b1 = ROM.DATA[item_address];
                byte b2 = ROM.DATA[item_address + 1];
                byte b3 = ROM.DATA[item_address + 2];
                //0x20 = bg2
                
                if (b1 == 0xFF && b2 == 0xFF) { break; }
                int address = ((b2 & 0x1F) << 8 | b1) >> 1;
                int px = address % 64;
                int py = address >> 6;
                pot_items.Add(new PotItem(b3, (byte)((px)), (byte)((py)),(b2 & 0x20) == 0x20 ? true : false ));
                item_address += 3; 
                }
        }
        

        /*public void DrawSpritesNames(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            foreach (SpriteName sprname in stringtodraw)
            {
                    GraphicsPath gpath = new GraphicsPath();
                    gpath.AddString(sprname.name, new FontFamily("Consolas"), 1, 12, new Point(sprname.x, sprname.y), StringFormat.GenericDefault);
                    Pen pen = new Pen(Color.FromArgb(30, 30, 30), 2);
                    g.DrawPath(pen, gpath);
                    SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
                    g.FillPath(brush, gpath);
            }
        }*/




        public void InitDrawBgr()
        {
            foreach (Room_Object o in tilesObjects)
            {
                if ((o.options & ObjectOption.Bgr) == ObjectOption.Bgr)
                {
                    draw_tiles(o,255);
                }
            }
        }

        public void InitDrawObjects(byte layer = 255)
        {

            foreach (Room_Object o in tilesObjects)
            {
                if ((o.options & ObjectOption.Bgr) != ObjectOption.Bgr)
                {
                    //o.DrawOnBitmap();
                    //draw_tiles(o);
                    o.Draw();
                }

            }

        }

        public void draw_tiles(Room_Object o,byte layer = 255)
        {

            if (o.id == 0xFF3)//full bg2 overlay
            {
                o.x = 0;
                o.y = 0;
            }
            if (o.allBgs)
            {
                using (Graphics g = Graphics.FromImage(GFX.room_bitmap))
                {
                    g.DrawImage(o.bitmap, new Point(o.x, o.y));
                }
            }
            else
            {
                if (layer == 255)
                {
                    using (Graphics g = Graphics.FromImage(GFX.room_bitmap))
                    {
                        g.DrawImage(o.bitmap, new Point(o.x, o.y));
                    }
                }
                else if (layer == 1)
                {
                    if (o.layer == 1)
                    {
                        using (Graphics g = Graphics.FromImage(GFX.room_bitmap))
                        {
                            g.DrawImage(o.bitmap, new Point(o.x, o.y));
                        }
                    }
                }
                else
                {
                    if (o.layer != 1)
                    {
                        using (Graphics g = Graphics.FromImage(GFX.room_bitmap))
                        {
                            g.DrawImage(o.bitmap, new Point(o.x, o.y));
                        }
                    }
                }
            }
        }
        public int roomSize = 0;


        public void loadChests(ref List<ChestData> chests_in_room)
        {
            int cpos = (ROM.DATA[Constants.chests_data_pointer1 + 2] << 16) + (ROM.DATA[Constants.chests_data_pointer1 + 1] << 8) + (ROM.DATA[Constants.chests_data_pointer1]);
            cpos = Addresses.snestopc(cpos);
            int clength = (ROM.DATA[Constants.chests_length_pointer + 1] << 8) + (ROM.DATA[Constants.chests_length_pointer + 1]);

            for (int i = 0; i < clength; i++)
            {
                if ((((ROM.DATA[cpos + (i * 3) + 1] << 8) + (ROM.DATA[cpos + (i * 3)])) & 0x7FFF) == index)
                {
                    //there's a chest in that room !
                    bool big = false;
                    if ((((ROM.DATA[cpos + (i * 3) + 1] << 8) + (ROM.DATA[cpos + (i * 3)])) & 0x8000) == 0x800)
                    {
                        big = true;
                    }
                    chests_in_room.Add(new ChestData(ROM.DATA[cpos + (i * 3) + 2], big));
                    //
                }
            }
        }



        public void loadTilesObjects(bool floor = true)
        {
            //adddress of the room objects
            int room_address = Constants.room_object_pointers + (index * 3);
            int tile_address = (ROM.DATA[room_address + 2] << 16) +
                (ROM.DATA[room_address + 1] << 8) +
                ROM.DATA[room_address];

            int objects_location = Addresses.snestopc(tile_address);

            if (floor)
            {
                floor1 = (byte)(ROM.DATA[objects_location] & 0x0F);
                floor2 = (byte)((ROM.DATA[objects_location] >> 4) & 0x0F);
            }
            layout = (byte)((ROM.DATA[objects_location + 1] >> 2) & 0x07);
            int layout_address = (ROM.DATA[Constants.room_object_layout_pointers + 2  + (layout * 3)] << 16) +
                                (ROM.DATA[(Constants.room_object_layout_pointers + 1) + (layout * 3)] << 8) +
                                ROM.DATA[(Constants.room_object_layout_pointers) + 0 + (layout * 3)];
            int layout_location = Addresses.snestopc(layout_address);

            List<ChestData> chests_in_room = new List<ChestData>();
            loadChests(ref chests_in_room);

            staircaseRooms.Clear();
            int nbr_of_staircase = 0;

            int pos = layout_location;

            byte b1 = 0;
            byte b2 = 0;
            byte b3 = 0;
            byte posX = 0;
            byte posY = 0;
            byte sizeX = 0;
            byte sizeY = 0;
            byte sizeXY = 0;
            short oid = 0;
            int layer = 0;
            bool door = false;
            bool endRead = false;
            bool drawlayout = true;
            bool fix = true;
            while (endRead == false)
            {
                if (drawlayout == true)
                {

                    b1 = ROM.DATA[pos];
                    b2 = ROM.DATA[pos + 1];
                    fix = false;
                    if (b1 == 0xFF && b2 == 0xFF)
                    {
                        pos = objects_location + 2;

                        drawlayout = false;
                        //endRead = true;
                        continue;
                    }
                    b3 = ROM.DATA[pos + 2];
                    pos += 3; //we jump to layer2

                    if (b3 >= 0xF8)
                    {
                        oid = (short)((b3 << 4) | 0x80 + (((b2 & 0x03) << 2) + ((b1 & 0x03))));
                        posX = (byte)((b1 & 0xFC) >> 2);
                        posY = (byte)((b2 & 0xFC) >> 2);
                        sizeXY = (byte)((((b1 & 0x03) << 2) + (b2 & 0x03)));
                    }
                    else //subtype1
                    {
                        oid = b3;
                        posX = (byte)((b1 & 0xFC) >> 2);
                        posY = (byte)((b2 & 0xFC) >> 2);
                        sizeX = (byte)((b1 & 0x03));
                        sizeY = (byte)((b2 & 0x03));
                        sizeXY = (byte)(((sizeX << 2) + sizeY));
                    }
                    if (b1 >= 0xFC) //subtype2 (not scalable? )
                    {
                        oid = (short)((b3 & 0x3F) + 0x100);
                        posX = (byte)(((b2 & 0xF0) >> 4) + ((b1 & 0x3) << 4));
                        posY = (byte)(((b2 & 0x0F) << 2) + ((b3 & 0xC0) >> 6));
                        sizeXY = 0;
                    }

                    Room_Object r = addObject(oid, posX, posY, sizeXY, (byte)layer);
                    if (r != null)
                    {
                        r.options |= ObjectOption.Bgr;
                        tilesObjects.Add(r);
                    }

                }
                else
                {
                    b1 = ROM.DATA[pos];
                    b2 = ROM.DATA[pos + 1];
                    fix = true;
                    if (b1 == 0xFF && b2 == 0xFF)
                    {
                        pos += 2; //we jump to layer2
                        layer++;
                        door = false;
                        if (layer == 3)
                        {
                            endRead = true;
                            break;
                        }
                        continue;
                    }

                    if (b1 == 0xF0 && b2 == 0xFF)
                    {
                        pos += 2; //we jump to layer2
                        door = true;
                        continue;
                    }
                    b3 = ROM.DATA[pos + 2];
                    if (door)
                    {
                        pos += 2;

                    }
                    else
                    {
                        pos += 3;
                    }

                    if (door == false)
                    {
                        if (b3 >= 0xF8)
                        {
                            oid = (short)((b3 << 4) | 0x80 + (((b2 & 0x03) << 2) + ((b1 & 0x03))));
                            posX = (byte)((b1 & 0xFC) >> 2);
                            posY = (byte)((b2 & 0xFC) >> 2);
                            sizeXY = (byte)((((b1 & 0x03) << 2) + (b2 & 0x03)));
                        }
                        else //subtype1
                        {
                            oid = b3;
                            posX = (byte)((b1 & 0xFC) >> 2);
                            posY = (byte)((b2 & 0xFC) >> 2);
                            sizeX = (byte)((b1 & 0x03));
                            sizeY = (byte)((b2 & 0x03));
                            sizeXY = (byte)(((sizeX << 2) + sizeY));
                        }
                        if (b1 >= 0xFC) //subtype2 (not scalable? )
                        {
                            oid = (short)((b3 & 0x3F) + 0x100);
                            posX = (byte)(((b2 & 0xF0) >> 4) + ((b1 & 0x3) << 4));
                            posY = (byte)(((b2 & 0x0F) << 2) + ((b3 & 0xC0) >> 6));
                            sizeXY = 0;
                        }
                        Room_Object r = addObject(oid, posX, posY, sizeXY, (byte)layer);
                        if (r != null)
                        {
                            tilesObjects.Add(r);
                        }
                        foreach (short stair in stairsObjects)
                        {
                            if (stair == oid) //we found stairs that lead to another room
                            {
                                
                                if (nbr_of_staircase < 4)
                                {
                                    tilesObjects[tilesObjects.Count - 1].options |= ObjectOption.Stairs;
                                    staircaseRooms.Add(new StaircaseRoom(posX, posY, "To " + staircase_rooms[nbr_of_staircase]));
                                    nbr_of_staircase++;
                                }
                                else
                                {
                                    tilesObjects[tilesObjects.Count - 1].options |= ObjectOption.Stairs;
                                    staircaseRooms.Add(new StaircaseRoom(posX, posY, "To ???"));
                                }
                                
                            }
                        }

                        //IF Object is a chest loaded and there's object in the list chest
                        if (oid == 0xF99)
                        {
                            if (chests_in_room.Count > 0)
                            {
                                tilesObjects[tilesObjects.Count - 1].options |= ObjectOption.Chest;
                                chest_list.Add(new Chest(posX, posY, chests_in_room[0].itemIn, chests_in_room[0].bigChest));
                                chests_in_room.RemoveAt(0);

                            }
                        }
                        else if (oid == 0xFB1)
                        {
                            if (chests_in_room.Count > 0)
                            {
                                tilesObjects[tilesObjects.Count - 1].options |= ObjectOption.Chest;
                                chest_list.Add(new Chest((byte)(posX+1), posY, chests_in_room[0].itemIn, chests_in_room[0].bigChest));
                                chests_in_room.RemoveAt(0);

                            }
                        }
                    }
                    else
                    {
                        byte door_pos = (byte)((b1 & 0xF0) >> 3);
                        byte door_type = b2;

                        if ((b1 & 0x03) == 00) //up
                        {
                            tilesObjects.Add(new object_door_up((short)((door_type <<8) + door_pos),0,0,0,(byte)layer));
                            if (door_pos >= 12)
                            {
                                //tilesObjects.Add(new object_door_down((short)((door_type << 8) + (door_pos-12)), 0, 0, 0, (byte)layer));
                            }
                        }
                        if ((b1 & 0x03) == 01) //down
                        {
                            tilesObjects.Add(new object_door_down((short)((door_type << 8) + door_pos), 0, 0, 0, (byte)layer));
                        }
                        if ((b1 & 0x03) == 02) //left
                        {
                            tilesObjects.Add(new object_door_left((short)((door_type << 8) + door_pos), 0, 0, 0, (byte)layer));
                            if (door_pos >= 12)
                            {
                                //tilesObjects.Add(new object_door_right((short)((door_type << 8) + (door_pos - 12)), 0, 0, 0, (byte)layer));
                            }
                        }
                        if ((b1 & 0x03) == 03) //right
                        {
                            tilesObjects.Add(new object_door_right((short)((door_type << 8) + door_pos), 0, 0, 0, (byte)layer));

                        }
                        continue;
                    }
                }

            }


        }

        public Room_Object addObject(short oid,byte x, byte y, byte size,byte layer)
        {
            if (oid <= 0xFF)
            {
                switch (oid)
                {
                    case 0x00:
                       return new object_00(oid, x, y, size,layer);
                        
                    case 0x01:
                       return new object_01(oid, x, y, size, layer);
                        
                    case 0x02:
                       return new object_02(oid, x, y, size, layer);
                        
                    case 0x03:
                       return new object_03(oid, x, y, size, layer);
                        
                    case 0x04:
                       return new object_04(oid, x, y, size, layer);
                        
                    case 0x05:
                       return new object_05(oid, x, y, size, layer);
                        
                    case 0x06:
                       return new object_06(oid, x, y, size, layer);
                        
                    case 0x07:
                       return new object_07(oid, x, y, size, layer);
                        
                    case 0x08:
                       return new object_08(oid, x, y, size, layer);
                        
                    case 0x09:
                       return new object_09(oid, x, y, size,layer);
                        
                    case 0x0A:
                       return new object_0A(oid, x, y, size,layer);
                        
                    case 0x0B:
                       return new object_0B(oid, x, y, size,layer);
                        
                    case 0x0C:
                       return new object_0C(oid, x, y, size,layer);
                        
                    case 0x0D:
                       return new object_0D(oid, x, y, size,layer);
                        
                    case 0x0E:
                       return new object_0E(oid, x, y, size,layer);
                        
                    case 0x0F:
                       return new object_0F(oid, x, y, size,layer);
                        
                    case 0x10:
                       return new object_10(oid, x, y, size,layer);
                        
                    case 0x11:
                       return new object_11(oid, x, y, size,layer);
                        
                    case 0x12:
                       return new object_12(oid, x, y, size,layer);
                        
                    case 0x13:
                       return new object_13(oid, x, y, size,layer);
                        
                    case 0x14:
                       return new object_14(oid, x, y, size,layer);
                        
                    case 0x15:
                       return new object_15(oid, x, y, size,layer);
                        
                    case 0x16:
                       return new object_16(oid, x, y, size,layer);
                        
                    case 0x17:
                       return new object_17(oid, x, y, size,layer);
                        
                    case 0x18:
                       return new object_18(oid, x, y, size,layer);
                        
                    case 0x19:
                       return new object_19(oid, x, y, size,layer);
                        
                    case 0x1A:
                       return new object_1A(oid, x, y, size,layer);
                        
                    case 0x1B:
                       return new object_1B(oid, x, y, size,layer);
                        
                    case 0x1C:
                       return new object_1C(oid, x, y, size,layer);
                        
                    case 0x1D:
                       return new object_1D(oid, x, y, size,layer);
                        
                    case 0x1E:
                       return new object_1E(oid, x, y, size,layer);
                        
                    case 0x1F:
                       return new object_1F(oid, x, y, size,layer);
                        
                    case 0x20:
                       return new object_20(oid, x, y, size,layer);
                        
                    case 0x21:
                       return new object_21(oid, x, y, size,layer);
                        
                    case 0x22:
                       return new object_22(oid, x, y, size,layer);
                        
                    case 0x23:
                       return new object_23(oid, x, y, size,layer);
                        
                    case 0x24:
                       return new object_24(oid, x, y, size,layer);
                        
                    case 0x25:
                       return new object_25(oid, x, y, size,layer);
                        
                    case 0x26:
                       return new object_26(oid, x, y, size,layer);
                        
                    case 0x27:
                       return new object_27(oid, x, y, size,layer);
                        
                    case 0x28:
                       return new object_28(oid, x, y, size,layer);
                        
                    case 0x29:
                       return new object_29(oid, x, y, size,layer);
                        
                    case 0x2A:
                       return new object_2A(oid, x, y, size,layer);
                        
                    case 0x2B:
                       return new object_2B(oid, x, y, size,layer);
                        
                    case 0x2C:
                       return new object_2C(oid, x, y, size,layer);
                        
                    case 0x2D:
                       return new object_2D(oid, x, y, size,layer);
                        
                    case 0x2E:
                       return new object_2E(oid, x, y, size,layer);
                        
                    case 0x2F:
                       return new object_2F(oid, x, y, size,layer);
                        
                    case 0x30:
                       return new object_30(oid, x, y, size,layer);
                        
                    case 0x31:
                       return new object_31(oid, x, y, size,layer);
                        
                    case 0x32:
                       return new object_32(oid, x, y, size,layer);
                        
                    case 0x33:
                       return new object_33(oid, x, y, size,layer);
                        
                    case 0x34:
                       return new object_34(oid, x, y, size,layer);
                        
                    case 0x35:
                       return new object_35(oid, x, y, size,layer);
                        
                    case 0x36:
                       return new object_36(oid, x, y, size,layer);
                        
                    case 0x37:
                       return new object_37(oid, x, y, size,layer);
                        
                    case 0x38:
                       return new object_38(oid, x, y, size,layer);
                        
                    case 0x39:
                       return new object_39(oid, x, y, size,layer);
                        
                    case 0x3A:
                       return new object_3A(oid, x, y, size,layer);
                        
                    case 0x3B:
                       return new object_3B(oid, x, y, size,layer);
                        
                    case 0x3C:
                       return new object_3C(oid, x, y, size,layer);
                        
                    case 0x3D:
                       return new object_3D(oid, x, y, size,layer);
                        
                    case 0x3E:
                       return new object_3E(oid, x, y, size,layer);
                        
                    case 0x3F:
                       return new object_3F(oid, x, y, size,layer);
                        
                    case 0x40:
                       return new object_40(oid, x, y, size,layer);
                        
                    case 0x41:
                       return new object_41(oid, x, y, size,layer);
                        
                    case 0x42:
                       return new object_42(oid, x, y, size,layer);
                        
                    case 0x43:
                       return new object_43(oid, x, y, size,layer);
                        
                    case 0x44:
                       return new object_44(oid, x, y, size,layer);
                        
                    case 0x45:
                       return new object_45(oid, x, y, size,layer);
                        
                    case 0x46:
                       return new object_46(oid, x, y, size,layer);
                        
                    case 0x47:
                       return new object_47(oid, x, y, size,layer);
                        
                    case 0x48:
                       return new object_48(oid, x, y, size,layer);
                        
                    case 0x49:
                       return new object_49(oid, x, y, size,layer);
                        
                    case 0x4A:
                       return new object_4A(oid, x, y, size,layer);
                        
                    case 0x4B:
                       return new object_4B(oid, x, y, size,layer);
                        
                    case 0x4C:
                       return new object_4C(oid, x, y, size,layer);
                        
                    case 0x4D:
                       return new object_4D(oid, x, y, size,layer);
                        
                    case 0x4E:
                       return new object_4E(oid, x, y, size,layer);
                        
                    case 0x4F:
                       return new object_4F(oid, x, y, size,layer);
                        
                    case 0x50:
                       return new object_50(oid, x, y, size,layer);
                        
                    case 0x51:
                       return new object_51(oid, x, y, size,layer);
                        
                    case 0x52:
                       return new object_52(oid, x, y, size,layer);
                        
                    case 0x53:
                       return new object_53(oid, x, y, size,layer);
                        
                    case 0x54:
                       return new object_54(oid, x, y, size,layer);
                        
                    case 0x55:
                       return new object_55(oid, x, y, size,layer);
                        
                    case 0x56:
                       return new object_56(oid, x, y, size,layer);
                        
                    case 0x57:
                       return new object_57(oid, x, y, size,layer);
                        
                    case 0x58:
                       return new object_58(oid, x, y, size,layer);
                        
                    case 0x59:
                       return new object_59(oid, x, y, size,layer);
                        
                    case 0x5A:
                       return new object_5A(oid, x, y, size,layer);
                        
                    case 0x5B:
                       return new object_5B(oid, x, y, size,layer);
                        
                    case 0x5C:
                       return new object_5C(oid, x, y, size,layer);
                        
                    case 0x5D:
                       return new object_5D(oid, x, y, size,layer);
                        
                    case 0x5E:
                       return new object_5E(oid, x, y, size,layer);
                        
                    case 0x5F:
                       return new object_5F(oid, x, y, size,layer);
                        
                    case 0x60:
                       return new object_60(oid, x, y, size,layer);
                        
                    case 0x61:
                       return new object_61(oid, x, y, size,layer);
                        
                    case 0x62:
                       return new object_62(oid, x, y, size,layer);
                        
                    case 0x63:
                       return new object_63(oid, x, y, size,layer);
                        
                    case 0x64:
                       return new object_64(oid, x, y, size,layer);
                        
                    case 0x65:
                       return new object_65(oid, x, y, size,layer);
                        
                    case 0x66:
                       return new object_66(oid, x, y, size,layer);
                        
                    case 0x67:
                       return new object_67(oid, x, y, size,layer);
                        
                    case 0x68:
                       return new object_68(oid, x, y, size,layer);
                        
                    case 0x69:
                       return new object_69(oid, x, y, size,layer);
                        
                    case 0x6A:
                       return new object_6A(oid, x, y, size,layer);
                        
                    case 0x6B:
                       return new object_6B(oid, x, y, size,layer);
                        
                    case 0x6C:
                       return new object_6C(oid, x, y, size,layer);
                        
                    case 0x6D:
                       return new object_6D(oid, x, y, size,layer);
                        
                    case 0x6E:
                       return new object_6E(oid, x, y, size,layer);
                        
                    case 0x6F:
                       return new object_6F(oid, x, y, size,layer);
                        
                    case 0x70:
                       return new object_70(oid, x, y, size,layer);
                        
                    case 0x71:
                       return new object_71(oid, x, y, size,layer);
                        
                    case 0x72:
                       return new object_72(oid, x, y, size,layer);
                        
                    case 0x73:
                       return new object_73(oid, x, y, size,layer);
                        
                    case 0x74:
                       return new object_74(oid, x, y, size,layer);
                        
                    case 0x75:
                       return new object_75(oid, x, y, size,layer);
                        
                    case 0x76:
                       return new object_76(oid, x, y, size,layer);
                        
                    case 0x77:
                       return new object_77(oid, x, y, size,layer);
                        
                    case 0x78:
                       return new object_78(oid, x, y, size,layer);
                        
                    case 0x79:
                       return new object_79(oid, x, y, size,layer);
                        
                    case 0x7A:
                       return new object_7A(oid, x, y, size,layer);
                        
                    case 0x7B:
                       return new object_7B(oid, x, y, size,layer);
                        
                    case 0x7C:
                       return new object_7C(oid, x, y, size,layer);
                        
                    case 0x7D:
                       return new object_7D(oid, x, y, size,layer);
                        
                    case 0x7E:
                       return new object_7E(oid, x, y, size,layer);
                        
                    case 0x7F:
                       return new object_7F(oid, x, y, size,layer);
                        
                    case 0x80:
                       return new object_80(oid, x, y, size,layer);
                        
                    case 0x81:
                       return new object_81(oid, x, y, size,layer);
                        
                    case 0x82:
                       return new object_82(oid, x, y, size,layer);
                        
                    case 0x83:
                       return new object_83(oid, x, y, size,layer);
                        
                    case 0x84:
                       return new object_84(oid, x, y, size,layer);
                        
                    case 0x85:
                       return new object_85(oid, x, y, size,layer);
                        
                    case 0x86:
                       return new object_86(oid, x, y, size,layer);
                        
                    case 0x87:
                       return new object_87(oid, x, y, size,layer);
                        
                    case 0x88:
                       return new object_88(oid, x, y, size,layer);
                        
                    case 0x89:
                       return new object_89(oid, x, y, size,layer);
                        
                    case 0x8A:
                       return new object_8A(oid, x, y, size,layer);
                        
                    case 0x8B:
                       return new object_8B(oid, x, y, size,layer);
                        
                    case 0x8C:
                       return new object_8C(oid, x, y, size,layer);
                        
                    case 0x8D:
                       return new object_8D(oid, x, y, size,layer);
                        
                    case 0x8E:
                       return new object_8E(oid, x, y, size,layer);
                        
                    case 0x8F:
                       return new object_8F(oid, x, y, size,layer);
                        
                    case 0x90:
                       return new object_90(oid, x, y, size,layer);
                        
                    case 0x91:
                       return new object_91(oid, x, y, size,layer);
                        
                    case 0x92:
                       return new object_92(oid, x, y, size,layer);
                        
                    case 0x93:
                       return new object_93(oid, x, y, size,layer);
                        
                    case 0x94:
                       return new object_94(oid, x, y, size,layer);
                        
                    case 0x95:
                       return new object_95(oid, x, y, size,layer);
                        
                    case 0x96:
                       return new object_96(oid, x, y, size,layer);
                        
                    case 0x97:
                       return new object_97(oid, x, y, size,layer);
                        
                    case 0x98:
                       return new object_98(oid, x, y, size,layer);
                        
                    case 0x99:
                       return new object_99(oid, x, y, size,layer);
                        
                    case 0x9A:
                       return new object_9A(oid, x, y, size,layer);
                        
                    case 0x9B:
                       return new object_9B(oid, x, y, size,layer);
                        
                    case 0x9C:
                       return new object_9C(oid, x, y, size,layer);
                        
                    case 0x9D:
                       return new object_9D(oid, x, y, size,layer);
                        
                    case 0x9E:
                       return new object_9E(oid, x, y, size,layer);
                        
                    case 0x9F:
                       return new object_9F(oid, x, y, size,layer);
                        
                    case 0xA0:
                       return new object_A0(oid, x, y, size,layer);
                        
                    case 0xA1:
                       return new object_A1(oid, x, y, size,layer);
                        
                    case 0xA2:
                       return new object_A2(oid, x, y, size,layer);
                        
                    case 0xA3:
                       return new object_A3(oid, x, y, size,layer);
                        
                    case 0xA4:
                       return new object_A4(oid, x, y, size,layer);
                        
                    case 0xA5:
                       return new object_A5(oid, x, y, size,layer);
                        
                    case 0xA6:
                       return new object_A6(oid, x, y, size,layer);
                        
                    case 0xA7:
                       return new object_A7(oid, x, y, size,layer);
                        
                    case 0xA8:
                       return new object_A8(oid, x, y, size,layer);
                        
                    case 0xA9:
                       return new object_A9(oid, x, y, size,layer);
                        
                    case 0xAA:
                       return new object_AA(oid, x, y, size,layer);
                        
                    case 0xAB:
                       return new object_AB(oid, x, y, size,layer);
                        
                    case 0xAC:
                       return new object_AC(oid, x, y, size,layer);
                        
                    case 0xAD:
                       return new object_AD(oid, x, y, size,layer);
                        
                    case 0xAE:
                       return new object_AE(oid, x, y, size,layer);
                        
                    case 0xAF:
                       return new object_AF(oid, x, y, size,layer);
                        
                    case 0xB0:
                       return new object_B0(oid, x, y, size,layer);
                        
                    case 0xB1:
                       return new object_B1(oid, x, y, size,layer);
                        
                    case 0xB2:
                       return new object_B2(oid, x, y, size,layer);
                        
                    case 0xB3:
                       return new object_B3(oid, x, y, size,layer);
                        
                    case 0xB4:
                       return new object_B4(oid, x, y, size,layer);
                        
                    case 0xB5:
                       return new object_B5(oid, x, y, size,layer);
                        
                    case 0xB6:
                       return new object_B6(oid, x, y, size,layer);
                        
                    case 0xB7:
                       return new object_B7(oid, x, y, size,layer);
                        
                    case 0xB8:
                       return new object_B8(oid, x, y, size,layer);
                        
                    case 0xB9:
                       return new object_B9(oid, x, y, size,layer);
                        
                    case 0xBA:
                       return new object_BA(oid, x, y, size,layer);
                        
                    case 0xBB:
                       return new object_BB(oid, x, y, size,layer);
                        
                    case 0xBC:
                       return new object_BC(oid, x, y, size,layer);
                        
                    case 0xBD:
                       return new object_BD(oid, x, y, size,layer);
                        
                    case 0xBE:
                       return new object_BE(oid, x, y, size,layer);
                        
                    case 0xBF:
                       return new object_BF(oid, x, y, size,layer);
                        
                    case 0xC0:
                       return new object_C0(oid, x, y, size, layer);
                        
                    case 0xC1:
                       return new object_C1(oid, x, y, size, layer);
                        
                    case 0xC2:
                       return new object_C2(oid, x, y, size, layer);
                        
                    case 0xC3:
                       return new object_C3(oid, x, y, size, layer);
                        
                    case 0xC4:
                       return new object_C4(oid, x, y, size, layer);
                        
                    case 0xC5:
                       return new object_C5(oid, x, y, size, layer);
                        
                    case 0xC6:
                       return new object_C6(oid, x, y, size, layer);
                        
                    case 0xC7:
                       return new object_C7(oid, x, y, size, layer);
                        
                    case 0xC8:
                       return new object_C8(oid, x, y, size, layer);
                        
                    case 0xC9:
                       return new object_C9(oid, x, y, size, layer);
                        
                    case 0xCA:
                       return new object_CA(oid, x, y, size, layer);
                        
                    case 0xCB:
                       return new object_CB(oid, x, y, size, layer);
                        
                    case 0xCC:
                       return new object_CC(oid, x, y, size, layer);
                        
                    case 0xCD:
                       return new object_CD(oid, x, y, size, layer);
                        
                    case 0xCE:
                       return new object_CE(oid, x, y, size, layer);
                        
                    case 0xCF:
                       return new object_CF(oid, x, y, size, layer);
                        
                    case 0xD0:
                       return new object_D0(oid, x, y, size, layer);
                        
                    case 0xD1:
                       return new object_D1(oid, x, y, size, layer);
                        
                    case 0xD2:
                       return new object_D2(oid, x, y, size, layer);
                        
                    case 0xD3:
                       return new object_D3(oid, x, y, size, layer);
                        
                    case 0xD4:
                       return new object_D4(oid, x, y, size, layer);
                        
                    case 0xD5:
                       return new object_D5(oid, x, y, size, layer);
                        
                    case 0xD6:
                       return new object_D6(oid, x, y, size, layer);
                        
                    case 0xD7:
                       return new object_D7(oid, x, y, size, layer);
                        
                    case 0xD8:
                       return new object_D8(oid, x, y, size, layer);
                        
                    case 0xD9:
                       return new object_D9(oid, x, y, size, layer);
                        
                    case 0xDA:
                       return new object_DA(oid, x, y, size, layer);
                        
                    case 0xDB:
                       return new object_DB(oid, x, y, size, layer);
                        
                    case 0xDC:
                       return new object_DC(oid, x, y, size, layer);
                        
                    case 0xDD:
                       return new object_DD(oid, x, y, size, layer);
                        
                    case 0xDE:
                       return new object_DE(oid, x, y, size, layer);
                        
                    case 0xDF:
                       return new object_DF(oid, x, y, size, layer);
                        
                    case 0xE0:
                       return new object_E0(oid, x, y, size, layer);
                        
                    case 0xE1:
                       return new object_E1(oid, x, y, size, layer);
                        
                    case 0xE2:
                       return new object_E2(oid, x, y, size, layer);
                        
                    case 0xE3:
                       return new object_E3(oid, x, y, size, layer);
                        
                    case 0xE4:
                       return new object_E4(oid, x, y, size, layer);
                        
                    case 0xE5:
                       return new object_E5(oid, x, y, size, layer);
                        
                    case 0xE6:
                       return new object_E6(oid, x, y, size, layer);
                        
                    case 0xE7:
                       return new object_E7(oid, x, y, size, layer);
                        
                    case 0xE8:
                       return new object_E8(oid, x, y, size, layer);
                        
                    case 0xE9:
                       return new object_E9(oid, x, y, size, layer);
                        
                    case 0xEA:
                       return new object_EA(oid, x, y, size, layer);
                        
                    case 0xEB:
                       return new object_EB(oid, x, y, size, layer);
                        
                    case 0xEC:
                       return new object_EC(oid, x, y, size, layer);
                        
                    case 0xED:
                       return new object_ED(oid, x, y, size, layer);
                        
                    case 0xEE:
                       return new object_EE(oid, x, y, size, layer);
                        
                    case 0xEF:
                       return new object_EF(oid, x, y, size, layer);
                        
                }
            }
            else
            {
                if (oid == 0xE00) //Block
                {
                   return new object_Block(oid, x, y, 0, layer);
                }


                if (oid  >= 0xF00)                //subtype3
                {
                    switch (oid)
                    {
                        case 0xF80:
                           return new object_F80(oid, x, y, size, layer);
                            
                        case 0xF81:
                           return new object_F81(oid, x, y, size, layer);
                            
                        case 0xF82:
                           return new object_F82(oid, x, y, size, layer);
                            
                        case 0xF83:
                           return new object_F83(oid, x, y, size, layer);
                            
                        case 0xF84:
                           return new object_F84(oid, x, y, size, layer);
                            
                        case 0xF85:
                           return new object_F85(oid, x, y, size, layer);
                            
                        case 0xF86:
                           return new object_F86(oid, x, y, size, layer);
                            
                        case 0xF87:
                           return new object_F87(oid, x, y, size, layer);
                            
                        case 0xF88:
                           return new object_F88(oid, x, y, size, layer);
                            
                        case 0xF89:
                           return new object_F89(oid, x, y, size, layer);
                            
                        case 0xF8A:
                           return new object_F8A(oid, x, y, size, layer);
                            
                        case 0xF8B:
                           return new object_F8B(oid, x, y, size, layer);
                            
                        case 0xF8C:
                           return new object_F8C(oid, x, y, size, layer);
                            
                        case 0xF8D:
                           return new object_F8D(oid, x, y, size, layer);
                            
                        case 0xF8E:
                           return new object_F8E(oid, x, y, size, layer);
                            
                        case 0xF8F:
                           return new object_F8F(oid, x, y, size, layer);
                            
                        case 0xF90:
                           return new object_F90(oid, x, y, size, layer);
                            
                        case 0xF91:
                           return new object_F91(oid, x, y, size, layer);
                            
                        case 0xF92:
                           return new object_F92(oid, x, y, size, layer);
                            
                        case 0xF93:
                           return new object_F93(oid, x, y, size, layer);
                            
                        case 0xF94:
                           return new object_F94(oid, x, y, size, layer);
                            
                        case 0xF95:
                           return new object_F95(oid, x, y, size, layer);
                            
                        case 0xF96:
                           return new object_F96(oid, x, y, size, layer);
                            
                        case 0xF97:
                           return new object_F97(oid, x, y, size, layer);
                            
                        case 0xF98:
                           return new object_F98(oid, x, y, size, layer);
                            
                        case 0xF99:
                           return new object_F99(oid, x, y, size, layer);
                            
                        case 0xF9A:
                           return new object_F9A(oid, x, y, size, layer);
                            
                        case 0xF9B:
                           return new object_F9B(oid, x, y, size, layer);
                            
                        case 0xF9C:
                           return new object_F9C(oid, x, y, size, layer);
                            
                        case 0xF9D:
                           return new object_F9D(oid, x, y, size, layer);
                            
                        case 0xF9E:
                           return new object_F9E(oid, x, y, size, layer);
                            
                        case 0xF9F:
                           return new object_F9F(oid, x, y, size, layer);
                            
                        case 0xFA0:
                           return new object_FA0(oid, x, y, size, layer);
                            
                        case 0xFA1:
                           return new object_FA1(oid, x, y, size, layer);
                            
                        case 0xFA2:
                           return new object_FA2(oid, x, y, size, layer);
                            
                        case 0xFA3:
                           return new object_FA3(oid, x, y, size, layer);
                            
                        case 0xFA4:
                           return new object_FA4(oid, x, y, size, layer);
                            
                        case 0xFA5:
                           return new object_FA5(oid, x, y, size, layer);
                            
                        case 0xFA6:
                           return new object_FA6(oid, x, y, size, layer);
                            
                        case 0xFA7:
                           return new object_FA7(oid, x, y, size, layer);
                            
                        case 0xFA8:
                           return new object_FA8(oid, x, y, size, layer);
                            
                        case 0xFA9:
                           return new object_FA9(oid, x, y, size, layer);
                            
                        case 0xFAA:
                           return new object_FAA(oid, x, y, size, layer);
                            
                        case 0xFAB:
                           return new object_FAB(oid, x, y, size, layer);
                            
                        case 0xFAC:
                           return new object_FAC(oid, x, y, size, layer);
                            
                        case 0xFAD:
                           return new object_FAD(oid, x, y, size, layer);
                            
                        case 0xFAE:
                           return new object_FAE(oid, x, y, size, layer);
                            
                        case 0xFAF:
                           return new object_FAF(oid, x, y, size, layer);
                            
                        case 0xFB0:
                           return new object_FB0(oid, x, y, size, layer);
                            
                        case 0xFB1:
                           return new object_FB1(oid, x, y, size, layer);
                            
                        case 0xFB2:
                           return new object_FB2(oid, x, y, size, layer);
                            
                        case 0xFB3:
                           return new object_FB3(oid, x, y, size, layer);
                            
                        case 0xFB4:
                           return new object_FB4(oid, x, y, size, layer);
                            
                        case 0xFB5:
                           return new object_FB5(oid, x, y, size, layer);
                            
                        case 0xFB6:
                           return new object_FB6(oid, x, y, size, layer);
                            
                        case 0xFB7:
                           return new object_FB7(oid, x, y, size, layer);
                            
                        case 0xFB8:
                           return new object_FB8(oid, x, y, size, layer);
                            
                        case 0xFB9:
                           return new object_FB9(oid, x, y, size, layer);
                            
                        case 0xFBA:
                           return new object_FBA(oid, x, y, size, layer);
                            
                        case 0xFBB:
                           return new object_FBA(oid, x, y, size, layer);
                            
                        case 0xFBC:
                           return new object_FBC(oid, x, y, size, layer);
                            
                        case 0xFBD:
                           return new object_FBD(oid, x, y, size, layer);
                            
                        case 0xFBE:
                           return new object_FBE(oid, x, y, size, layer);
                            
                        case 0xFBF:
                           return new object_FBF(oid, x, y, size, layer);
                            
                        case 0xFC0:
                           return new object_FC0(oid, x, y, size, layer);
                            
                        case 0xFC1:
                           return new object_FC1(oid, x, y, size, layer);
                            
                        case 0xFC2:
                           return new object_FC2(oid, x, y, size, layer);
                            
                        case 0xFC3:
                           return new object_FC3(oid, x, y, size, layer);
                            
                        case 0xFC4:
                           return new object_FC4(oid, x, y, size, layer);
                            
                        case 0xFC5:
                           return new object_FC5(oid, x, y, size, layer);
                            
                        case 0xFC6:
                           return new object_FC6(oid, x, y, size, layer);
                            
                        case 0xFC7:
                           return new object_FC7(oid, x, y, size, layer);
                            
                        case 0xFC8:
                           return new object_FC8(oid, x, y, size, layer);
                            
                        case 0xFC9:
                           return new object_FC9(oid, x, y, size, layer);
                            
                        case 0xFCA:
                           return new object_FCA(oid, x, y, size, layer);
                            
                        case 0xFCB:
                           return new object_FCB(oid, x, y, size, layer);
                            
                        case 0xFCC:
                           return new object_FCC(oid, x, y, size, layer);
                            
                        case 0xFCD:
                           return new object_FCD(oid, x, y, size, layer);
                            
                        case 0xFCE:
                           return new object_FCE(oid, x, y, size, layer);
                            
                        case 0xFCF:
                           return new object_FCF(oid, x, y, size, layer);
                            
                        case 0xFD0:
                           return new object_FD0(oid, x, y, size, layer);
                            
                        case 0xFD1:
                           return new object_FD1(oid, x, y, size, layer);
                            
                        case 0xFD2:
                           return new object_FD2(oid, x, y, size, layer);
                            
                        case 0xFD3:
                           return new object_FD3(oid, x, y, size, layer);
                            
                        case 0xFD4:
                           return new object_FD4(oid, x, y, size, layer);
                            
                        case 0xFD5:
                           return new object_FD5(oid, x, y, size, layer);
                            
                        case 0xFD6:
                           return new object_FD6(oid, x, y, size, layer);
                            
                        case 0xFD7:
                           return new object_FD7(oid, x, y, size, layer);
                            
                        case 0xFD8:
                           return new object_FD8(oid, x, y, size, layer);
                            
                        case 0xFD9:
                           return new object_FD9(oid, x, y, size, layer);
                            
                        case 0xFDA:
                           return new object_FDA(oid, x, y, size, layer);
                            
                        case 0xFDB:
                           return new object_FDB(oid, x, y, size, layer);
                            
                        case 0xFDC:
                           return new object_FDC(oid, x, y, size, layer);
                            
                        case 0xFDD:
                           return new object_FDD(oid, x, y, size, layer);
                            
                        case 0xFDE:
                           return new object_FDE(oid, x, y, size, layer);
                            
                        case 0xFDF:
                           return new object_FDF(oid, x, y, size, layer);
                            
                        case 0xFE0:
                           return new object_FE0(oid, x, y, size, layer);
                            
                        case 0xFE1:
                           return new object_FE1(oid, x, y, size, layer);
                            
                        case 0xFE2:
                           return new object_FE2(oid, x, y, size, layer);
                            
                        case 0xFE3:
                           return new object_FE3(oid, x, y, size, layer);
                            
                        case 0xFE4:
                           return new object_FE4(oid, x, y, size, layer);
                            
                        case 0xFE5:
                           return new object_FE5(oid, x, y, size, layer);
                            
                        case 0xFE6:
                           return new object_FE6(oid, x, y, size, layer);
                            
                        case 0xFE7:
                           return new object_FE7(oid, x, y, size, layer);
                            
                        case 0xFE8:
                           return new object_FE8(oid, x, y, size, layer);
                            
                        case 0xFE9:
                           return new object_FE9(oid, x, y, size, layer);
                            
                        case 0xFEA:
                           return new object_FEA(oid, x, y, size, layer);
                            
                        case 0xFEB:
                           return new object_FEB(oid, x, y, size, layer);
                            
                        case 0xFEC:
                           return new object_FEC(oid, x, y, size, layer);
                            
                        case 0xFED:
                           return new object_FED(oid, x, y, size, layer);
                            
                        case 0xFEE:
                           return new object_FEE(oid, x, y, size, layer);
                            
                        case 0xFEF:
                           return new object_FEF(oid, x, y, size, layer);
                            
                        case 0xFF0:
                           return new object_FF0(oid, x, y, size, layer);
                            
                        case 0xFF1:
                           return new object_FF1(oid, x, y, size, layer);
                            
                        case 0xFF2:
                           return new object_FF2(oid, x, y, size, layer);
                            
                        case 0xFF3:
                           return new object_FF3(oid, x, y, size, layer);
                            
                        case 0xFF4:
                           return new object_FF4(oid, x, y, size, layer);
                            
                        case 0xFF5:
                           return new object_FF5(oid, x, y, size, layer);
                            
                    }
                }
                else if ((oid & 0x100) == 0x100) //subtype2? non scalable
                {
                   return new Subtype2_Multiple(oid, x, y, 0, layer);
                }

            }
            return null;
        }

        public void DrawFloors(byte floor = 0)
        {
            byte f = (byte)(floor1 << 4);
            if (floor == 2)
            {
                f = (byte)(floor2 << 4);
            }
            //x x 4
            Tile floorTile1 = new Tile(ROM.DATA[Constants.tile_address + f], ROM.DATA[Constants.tile_address + f + 1]);
                Tile floorTile2 = new Tile(ROM.DATA[Constants.tile_address + f + 2], ROM.DATA[Constants.tile_address + f + 3]);
                Tile floorTile3 = new Tile(ROM.DATA[Constants.tile_address + f + 4], ROM.DATA[Constants.tile_address + f + 5]);
                Tile floorTile4 = new Tile(ROM.DATA[Constants.tile_address + f + 6], ROM.DATA[Constants.tile_address + f + 7]);

                Tile floorTile5 = new Tile(ROM.DATA[Constants.tile_address_floor + f], ROM.DATA[Constants.tile_address_floor + f + 1]);
                Tile floorTile6 = new Tile(ROM.DATA[Constants.tile_address_floor + f + 2], ROM.DATA[Constants.tile_address_floor + f + 3]);
                Tile floorTile7 = new Tile(ROM.DATA[Constants.tile_address_floor + f + 4], ROM.DATA[Constants.tile_address_floor + f + 5]);
                Tile floorTile8 = new Tile(ROM.DATA[Constants.tile_address_floor + f + 6], ROM.DATA[Constants.tile_address_floor + f + 7]);

                for (int xx = 0; xx < 16; xx++)
                {
                    for (int yy = 0; yy < 32; yy++)
                    {
                        floorTile1.Draw((xx * 4), (yy * 2)); floorTile2.Draw((xx * 4) + 1, (yy * 2));
                        floorTile3.Draw((xx * 4) + 2, (yy * 2)); floorTile4.Draw((xx * 4) + 3, (yy * 2));

                        floorTile5.Draw((xx * 4), (yy * 2) + 1); floorTile6.Draw((xx * 4) + 1, (yy * 2) + 1);
                        floorTile7.Draw((xx * 4) + 2, (yy * 2) + 1); floorTile8.Draw((xx * 4) + 3, (yy * 2) + 1);
                    }
                }

            



        }


        public void Draw()
        {

            
        }




        public void loadHeader()
        {
            //address of the room header
            int address = (ROM.DATA[Constants.room_header_pointers_bank] << 16) +
                            (ROM.DATA[(Constants.room_header_pointers + 1)+ (index * 2)] << 8) +
                            ROM.DATA[(Constants.room_header_pointers) + (index*2)];

            header_location = Addresses.snestopc(address);

            bg2 = (Background2)((ROM.DATA[header_location] >> 5) & 0x07);
            collision = (byte)((ROM.DATA[header_location] >> 2) & 0x07);
            light = (((ROM.DATA[header_location]) & 0x01) == 1 ? true : false);

            palette = (byte)((ROM.DATA[header_location + 1] & 0x3F));
            blockset = (byte)((ROM.DATA[header_location + 2]));
            spriteset = (byte)((ROM.DATA[header_location + 3]));
            effect = (byte)((ROM.DATA[header_location + 4]));
            tag1 = (byte)((ROM.DATA[header_location + 5]));
            tag2 = (byte)((ROM.DATA[header_location + 6]));

            holewarp_plane = (byte)((ROM.DATA[header_location + 7]) & 0x03);
            staircase_plane[0] = (byte)((ROM.DATA[header_location + 7]>>2) & 0x03);
            staircase_plane[1] = (byte)((ROM.DATA[header_location + 7]>>4) & 0x03);
            staircase_plane[2] = (byte)((ROM.DATA[header_location + 7]>>6) & 0x03);
            staircase_plane[3] = (byte)((ROM.DATA[header_location + 8]) & 0x03 );

            holewarp = (byte)((ROM.DATA[header_location + 9]));
            staircase_rooms[0] = (byte)((ROM.DATA[header_location + 10]));
            staircase_rooms[1] = (byte)((ROM.DATA[header_location + 11]));
            staircase_rooms[2] = (byte)((ROM.DATA[header_location + 12]));
            staircase_rooms[3] = (byte)((ROM.DATA[header_location + 13]));
        }

        public object Clone()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;

                return (Room)formatter.Deserialize(ms);
            }
        }
    }

    [Serializable]
    public class SpriteName
    {
        public int x;
        public int y;
        public string name;
        public SpriteName(int x,int y,string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }
    }

    [Serializable]
    public class StaircaseRoom
    {
        public int x;
        public int y;
        public string name;
        public StaircaseRoom(int x, int y,string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }
    }
    [Serializable]
    public class ChestData
    {
        public bool bigChest = false;
        public byte itemIn = 0;
        public ChestData(byte itemIn, bool bigChest)
        {
            this.itemIn = itemIn;
            this.bigChest = bigChest;
        }
    }
}
