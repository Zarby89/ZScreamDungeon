using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public class Room
    {
        int index;
        int header_location;
        byte layout;
        public byte floor1;
        public byte floor2;
        byte blockset;
        byte spriteset;
        byte palette;
        byte collision; //Need a better name for that
        byte bg2; //TODO : struct
        byte effect;//TODO : struct
        byte tag1;//TODO : struct
        byte tag2;//TODO : struct
        byte holewarp;
        byte staircase1;
        byte staircase2;
        byte staircase3;
        byte staircase4;
        bool light;
        byte holewarp_plane;
        byte staircase1_plane;
        byte staircase2_plane;
        byte staircase3_plane;
        byte staircase4_plane;
        byte messageid;
        bool damagepit;

        public Bitmap[] items_image = new Bitmap[75];
        public List<Chest> chest_list = new List<Chest>();
        //all room bitmap for tiles/floors all 512x512
        Bitmap floor1_bitmap; //used to draw the floor on
        Bitmap floor2_bitmap; //used to draw the floor on
        Bitmap bg2_buffer_bitmap;
        Bitmap bg2_bitmap;
        Bitmap bg1_bitmap;
        public Bitmap room_bitmap; //picturebox show that bitmap
        Bitmap tilebuffer_bitmap;
        public List<Room_Object> tilesObjects = new List<Room_Object>();
        public List<Room_Object> layouttilesObjects = new List<Room_Object>();
        public ChestItems_Name chest_items_name = new ChestItems_Name();
        public Sprites_Names sprites_name = new Sprites_Names();
        public PotItems_Name items_name = new PotItems_Name();
        public Room(int index)
        {
            this.index = index;
            loadHeader();

            byte[] blocks = new byte[14];
            for(int i = 0;i<8;i++)
            {
                blocks[i] = ROM.DATA[Constants.gfx_groups + (blockset * 8)+i];
            }

            for (int i = 0; i < 4; i++)
            {
                blocks[10+i] = ROM.DATA[Constants.sprite_blockset_pointer + ((spriteset+64) * 4) + i];
            }
            blocks[8] = 92;
            blocks[9] = ROM.DATA[Constants.gfx_animated + blockset];

            
            GFX.LoadDungeonPalette(palette);
            GFX.LoadSpritesPalette(palette);


            GFX.load4bpp(GFX.gfxdata, blocks);

            GFX.create_gfxs();

            GFX.animate_gfxs();

            loadTilesObjects(); //add all objects in tilesObjects array

            /*for (int i = 0; i < 24; i+=2)
            {
                tilesObjects.Add(new object_door_up((short)i, 0, 0, 0, 0));
                tilesObjects.Add(new object_door_down((short)i, 0, 0, 0, 0));
                tilesObjects.Add(new object_door_left((short)i, 0, 0, 0, 0));
                tilesObjects.Add(new object_door_right((short)i, 0, 0, 0, 0));
            }*/

            addDoors();



            addBlocks();
            addTorches();

           
            createBitmaps();
            //

            Stopwatch sw = new Stopwatch();
            sw.Start();
            DrawFloors();

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            InitDrawObjects();

            InitItemsDraw();



            DrawObjects(); //called every x frame for update
            
            redrawRoom();
            drawChestsItem();
            drawSprites();
            drawItems();
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
                }
                if (o.GetType() == typeof(object_door_down))
                {
                    short pos = (short)(((ROM.DATA[(0x1996 + 1 + (o.id & 0xFF))] << 8) + ROM.DATA[(0x1996 + (o.id & 0xFF))]) / 2);
                    float n = (((float)pos / 64) - (byte)(pos / 64)) * 64;
                    o.x = (byte)n;
                    o.y = (byte)(pos / 64);
                    //door fix ? position seems to be wrong from ROM for down and right doors
                    //if ((o.id & 0xFF) >= 12)
                    //{
                    o.y += 1;
                    //}
                }

                if (o.GetType() == typeof(object_door_left))
                {
                    short pos = (short)(((ROM.DATA[(0x19AE + 1 + (o.id & 0xFF))] << 8) + ROM.DATA[(0x19AE + (o.id & 0xFF))]) / 2);
                    float n = (((float)pos / 64) - (byte)(pos / 64)) * 64;
                    o.x = (byte)n;
                    o.y = (byte)(pos / 64);
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
                }
            }
        }



        public void addBlocks()
        {
            //288
            for(int i = 0;i<288;i+=4)
            {
                byte b1 = ROM.DATA[Constants.block_data+i];
                byte b2 = ROM.DATA[Constants.block_data+i + 1];
                byte b3 = ROM.DATA[Constants.block_data+i + 2];
                byte b4 = ROM.DATA[Constants.block_data + i + 3];
                if (b1 == 0xFF && b2 == 0xFF) { continue; }
                if (((b2 << 8) + b1) == index)
                {
                    int b = ((((b4 << 8) + b3) & 0x1FFF)>> 1);
                    float a = ((float)b / 64);
                    int py = (((((b4 << 8) + b3) & 0x1FFF) >> 1)/64);
                    a = (a - py) *64;
                    int px = (int)a;

                    addObject(0x5E, (byte)(px), (byte)(py), 0, 0);
                   
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

                        addObject(0x120, (byte)px, (byte)py, 0, 0);
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


        public void drawItems()
        {
            
            int item_address_snes = (01 << 16) +
            (ROM.DATA[Constants.room_items_pointers + (index * 2) + 1] << 8) +
            ROM.DATA[Constants.room_items_pointers + (index * 2)];
            int item_address = Addresses.snestopc(item_address_snes);
            using (Graphics g = Graphics.FromImage(room_bitmap))
            {
                while (true)
            {
                byte b1 = ROM.DATA[item_address];
                byte b2 = ROM.DATA[item_address + 1];
                byte b3 = ROM.DATA[item_address + 2];

                    if (b1 == 0xFF && b2 == 0xFF) { break; }
                    int b = (((b2 << 8) + b1) >> 1);
                    float a = ((float)b / 64);
                    int py = ((((b2 << 8) + b1) >> 1) / 64);
                    a = (a - py) * 64;
                    int px = (int)a;
                    if ((b3 & 0x80) == 0x80)
                    {

                        b3 = (byte)((b3 - 0x80) / 2);

                        b3 += 23;
                    }
                    g.FillEllipse(Brushes.Red, new Rectangle(((px) * 8), ((py) * 8), 16, 16));
                    g.DrawString(items_name.name[b3], new Font("Arial", 10, FontStyle.Bold), Brushes.Violet, new Point(((px) * 8), ((py) * 8)));
                    item_address += 3;
                }
            }
        }

        public void drawChestsItem()
        {
            using (Graphics g = Graphics.FromImage(room_bitmap))
            {
                foreach (Chest c in chest_list)
                {
                    //g.DrawString(chest_items_name.name[c.item], new Font("Arial", 10,FontStyle.Bold), Brushes.White, new Point(((c.x-1) * 8), ((c.y - 2) * 8)));
                    g.DrawImage(items_image[c.item], new Point((c.x*8), (c.y*8) - 16));
                    
                }
            }
        }


        public void createBitmaps()
        {
            floor1_bitmap = new Bitmap(512,512, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            floor2_bitmap = new Bitmap(512, 512, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            bg2_buffer_bitmap = new Bitmap(512, 512, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            bg2_bitmap = new Bitmap(512, 512);
            bg1_bitmap = new Bitmap(512, 512,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            room_bitmap = new Bitmap(512, 512, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            tilebuffer_bitmap = new Bitmap(512, 512);
        }
        //Lockbit Variables 
        Rectangle rect;
        IntPtr ptr;
        int bytes;
        byte[] rgbValues;
        System.Drawing.Imaging.BitmapData bmpData;
        public void redrawRoom() //redraw all layer over others
        {

            using (Graphics g = Graphics.FromImage(room_bitmap))
            {
                if (bg2 == 0) //off
                {
                    g.DrawImage(bg1_bitmap, 0, 0);
                    //g.DrawImage(bg2_buffer_bitmap, 0, 0);
                }
                else   if (bg2 == 3) //on top
                {
                    rect = new Rectangle(0, 0, 512, 512);
                    bmpData =
                        bg2_buffer_bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                        bg2_buffer_bitmap.PixelFormat);

                    ptr = bmpData.Scan0;
                    bytes = Math.Abs(bmpData.Stride) * bg1_bitmap.Height;
                    rgbValues = new byte[bytes];

                    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

                    for (int i = 3; i < (rgbValues.Length); i += 4)
                    {
                        if (rgbValues[i - 1] == 0 && rgbValues[i - 2] == 0 && rgbValues[i - 3] == 0) // color = black then transparent
                        {
                            rgbValues[(i)] = 0;
                        }
                    }

                    System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

                    bg2_buffer_bitmap.UnlockBits(bmpData);

                    g.DrawImage(bg1_bitmap, 0, 0);
                    g.DrawImage(bg2_buffer_bitmap, 0, 0);

                }
                else if (bg2 == 7) //transparent
                {
                    rect = new Rectangle(0, 0, 512, 512);
                    bmpData =
                        bg2_buffer_bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                        bg2_buffer_bitmap.PixelFormat);

                    ptr = bmpData.Scan0;
                    bytes = Math.Abs(bmpData.Stride) * bg1_bitmap.Height;
                    rgbValues = new byte[bytes];

                    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

                    for (int i = 3; i < (rgbValues.Length); i += 4)
                    {
                        if (rgbValues[i - 1] == 0 && rgbValues[i - 2] == 0 && rgbValues[i - 3] == 0) // color = black then transparent
                        {
                            rgbValues[(i)] = 0;
                        }
                        else
                        {
                            rgbValues[(i)] = 128;
                        }
                    }

                    System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

                    bg2_buffer_bitmap.UnlockBits(bmpData);

                    g.DrawImage(bg1_bitmap, 0, 0);
                    g.DrawImage(bg2_buffer_bitmap, 0, 0);

                }
                else
                {


                    rect = new Rectangle(0, 0, 512, 512);
                    bmpData =
                        bg1_bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                        bg1_bitmap.PixelFormat);

                    ptr = bmpData.Scan0;
                    bytes = Math.Abs(bmpData.Stride) * bg1_bitmap.Height;
                    rgbValues = new byte[bytes];

                    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

                    for (int i = 3; i < (rgbValues.Length); i += 4)
                    {
                        if (rgbValues[i - 1] == 0 && rgbValues[i - 2] == 0 && rgbValues[i - 3] == 0) // color = black then transparent
                        {
                            rgbValues[(i)] = 0;
                        }
                    }

                    System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

                    bg1_bitmap.UnlockBits(bmpData);

                    g.DrawImage(bg2_buffer_bitmap, 0, 0);
                    g.DrawImage(bg1_bitmap, 0, 0);

                }
                               

            }

        }

        public void DrawObjects()
        {
            /*using (Graphics g = Graphics.FromImage(bg1_bitmap))
            {
                g.Clear(Color.Transparent);
            }*/
            using (Graphics g = Graphics.FromImage(bg1_bitmap))
            {
                g.DrawImage(floor1_bitmap, 0, 0);
            }
            using (Graphics g = Graphics.FromImage(bg2_buffer_bitmap))
            {
                g.DrawImage(floor2_bitmap, 0, 0);
            }

            foreach (Room_Object o in tilesObjects)
            {
                if (o.id == 0xFF3)//full bg2 overlay
                {
                    o.x = 0;
                    o.y = 0;
                };


                if (o.allBgs)
                {

                    using (Graphics g = Graphics.FromImage(bg1_bitmap))
                    {
                        
                        g.DrawImage(o.bitmap, o.x * 8, (o.y+o.drawYFix) * 8);
                    }
                    using (Graphics g = Graphics.FromImage(bg2_buffer_bitmap))
                    {
                        g.DrawImage(o.bitmap, o.x * 8, (o.y + o.drawYFix) * 8);
                    }
                }
                else
                {
                    if (o.layer == 1)
                    {
                        using (Graphics g = Graphics.FromImage(bg2_buffer_bitmap))
                        {
                            g.DrawImage(o.bitmap, o.x * 8, (o.y + o.drawYFix)  * 8);
                        }
                    }
                    else
                    {
                        using (Graphics g = Graphics.FromImage(bg1_bitmap))
                        {
                           g.DrawImage(o.bitmap, o.x * 8, (o.y + o.drawYFix) * 8);
                        }
                    }
                }
            }

        }
        public void InitDrawObjects()
        {
            foreach (Room_Object o in tilesObjects)
            {
                GFX.graphictilebuffer.Clear(Color.Transparent);
                o.Draw();
                o.DrawOnBitmap();
            }
        }

        public void loadTilesObjects()
        {
            //adddress of the room objects
            int room_address = Constants.room_object_pointers + (index * 3);
            int tile_address = (ROM.DATA[room_address + 2] << 16) +
                (ROM.DATA[room_address + 1] << 8) +
                ROM.DATA[room_address];

            int objects_location = Addresses.snestopc(tile_address);


            floor1 = (byte)(ROM.DATA[objects_location] & 0x0F);
            floor2 = (byte)((ROM.DATA[objects_location] >> 4) & 0x0F);

            layout = (byte)((ROM.DATA[objects_location + 1] >> 2) & 0x07);
            int layout_address = (ROM.DATA[Constants.room_object_layout_pointers + 2  + (layout * 3)] << 16) +
    (ROM.DATA[(Constants.room_object_layout_pointers + 1) + (layout * 3)] << 8) +
    ROM.DATA[(Constants.room_object_layout_pointers) + 0 + (layout * 3)];
            int layout_location = Addresses.snestopc(layout_address);

            //(((ROM.DATA[Constants.room_chest + (i*3) +1] << 8) + (ROM.DATA[Constants.room_chest + (i * 3)])) & 0x7FFF) 
            List<byte> chests_in_room = new List<byte>();
            for(int i = 0; i<290;i++)
            {
                if ((((ROM.DATA[Constants.room_chest + (i*3) +1] << 8) + (ROM.DATA[Constants.room_chest + (i * 3)])) & 0x7FFF) == index)
                {
                    //there's a chest in that room !
                    chests_in_room.Add(ROM.DATA[Constants.room_chest + (i * 3) + 2]);
                    //Console.WriteLine((Constants.room_chest + (i * 3) + 2).ToString("X3") + " : " + ROM.DATA[Constants.room_chest + (i * 3) + 2] + " : " + chest_items_name.name[ROM.DATA[Constants.room_chest + (i * 3) + 2]]);
                }
            }



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

                    if (b1 >= 0xF8 && b1 < 0xFC) //subtype3 (scalable x,y)
                    {
                        oid = b3;
                        posX = (byte)((b1 & 0xFC) >> 2);
                        posY = (byte)((b2 & 0xFC) >> 2);
                        sizeX = (byte)((b1 & 0x03));
                        sizeY = (byte)((b2 & 0x03));
                        sizeXY = (byte)(((sizeX << 2) + sizeY));

                    }
                    else if (b1 >= 0xFC) //subtype2 (not scalable? )
                    {

                        oid = (short)((b3 & 0x3F) + 0x100);
                        
                        posX = (byte)(((b2 & 0xF0) >> 4) + ((b1 & 0x3) << 4));
                        posY = (byte)(((b2 & 0x0F) << 2) + ((b3 & 0xC0) >> 6));

                        sizeX = 0;
                        sizeY = 0;
                        sizeXY = 0;
                    }
                    else //subtype1
                    {
                        //3rd byte = object
                        //yyyy yycc	xxxx xxaa
                        oid = b3;
                        posX = (byte)((b1 & 0xFC) >> 2);
                        posY = (byte)((b2 & 0xFC) >> 2);
                        sizeX = (byte)((b1 & 0x03));
                        sizeY = (byte)((b2 & 0x03));
                        sizeXY = (byte)(((sizeX << 2) + sizeY));
                    }
                    addObject(oid, posX, posY, sizeXY,(byte)layer);



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
                        if (b3 >= 0xF8) //subtype3 (scalable x,y) //  && b3 < 0xFC
                        {
                            oid = (short)((b3 << 4) | 0x80 + (((b2 & 0x03) << 2) + ((b1 & 0x03))));
                            //Console.WriteLine(oid.ToString("X4"));
                            posX = (byte)((b1 & 0xFC) >> 2);
                            posY = (byte)((b2 & 0xFC) >> 2);
                            sizeX = (byte)((b1 & 0x03));
                            sizeY = (byte)((b2 & 0x03));
                            sizeXY = (byte)(((sizeX << 2) + sizeY));
                            //Subtype 3, | 0xFXX 

                        }
                        else //subtype1
                        {
                            //3rd byte = object
                            //yyyy yycc	xxxx xxaa
                            oid = b3;
                            posX = (byte)((b1 & 0xFC) >> 2);
                            posY = (byte)((b2 & 0xFC) >> 2);
                            sizeX = (byte)((b1 & 0x03));
                            sizeY = (byte)((b2 & 0x03));
                            sizeXY = (byte)(((sizeX << 2) + sizeY));
                            //subtype1 == XX

                        }
                        if (b1 >= 0xFC) //subtype2 (not scalable? )
                        {
                            //Console.WriteLine(oid.ToString("X4"));
                            oid = (short)((b3 & 0x3F) + 0x100);

                            posX = (byte)(((b2 & 0xF0) >> 4) + ((b1 & 0x3) << 4));
                            posY = (byte)(((b2 & 0x0F) << 2) + ((b3 & 0xC0) >> 6));

                            sizeX = 0;
                            sizeY = 0;
                            sizeXY = 0;
                            //subtype2 = 1XX
                        }
                        //tilesObjects.Add(new object_F99(0xF99, posX, posY, 0, 0));
                        addObject(oid, posX, posY, sizeXY, (byte)layer);

                        //IF Object is a chest loaded and there's object in the list chest
                        if (oid == 0xF99)
                        {
                            if (chests_in_room.Count > 0)
                            {
                                chest_list.Add(new Chest(posX, posY, chests_in_room[0]));
                                chests_in_room.RemoveAt(0);

                            }
                        }
                        else if (oid == 0xFB1)
                        {
                            if (chests_in_room.Count > 0)
                            {
                                chest_list.Add(new Chest((byte)(posX+1), posY, chests_in_room[0]));
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
                                tilesObjects.Add(new object_door_down((short)((door_type << 8) + (door_pos-12)), 0, 0, 0, (byte)layer));
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
                                tilesObjects.Add(new object_door_right((short)((door_type << 8) + (door_pos - 12)), 0, 0, 0, (byte)layer));
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

        public void addObject(short oid,byte x, byte y, byte size,byte layer)
        {
            if (oid <= 0xFF)
            {
                switch (oid)
                {
                    case 0x00:
                        tilesObjects.Add(new object_00(oid, x, y, size,layer));
                        break;
                    case 0x01:
                        tilesObjects.Add(new object_01(oid, x, y, size, layer));
                        break;
                    case 0x02:
                        tilesObjects.Add(new object_02(oid, x, y, size, layer));
                        break;
                    case 0x03:
                        tilesObjects.Add(new object_03(oid, x, y, size, layer));
                        break;
                    case 0x04:
                        tilesObjects.Add(new object_04(oid, x, y, size, layer));
                        break;
                    case 0x05:
                        tilesObjects.Add(new object_05(oid, x, y, size, layer));
                        break;
                    case 0x06:
                        tilesObjects.Add(new object_06(oid, x, y, size, layer));
                        break;
                    case 0x07:
                        tilesObjects.Add(new object_07(oid, x, y, size, layer));
                        break;
                    case 0x08:
                        tilesObjects.Add(new object_08(oid, x, y, size, layer));
                        break;
                    case 0x09:
                        tilesObjects.Add(new object_09(oid, x, y, size,layer));
                        break;
                    case 0x0A:
                        tilesObjects.Add(new object_0A(oid, x, y, size,layer));
                        break;
                    case 0x0B:
                        tilesObjects.Add(new object_0B(oid, x, y, size,layer));
                        break;
                    case 0x0C:
                        tilesObjects.Add(new object_0C(oid, x, y, size,layer));
                        break;
                    case 0x0D:
                        tilesObjects.Add(new object_0D(oid, x, y, size,layer));
                        break;
                    case 0x0E:
                        tilesObjects.Add(new object_0E(oid, x, y, size,layer));
                        break;
                    case 0x0F:
                        tilesObjects.Add(new object_0F(oid, x, y, size,layer));
                        break;
                    case 0x10:
                        tilesObjects.Add(new object_10(oid, x, y, size,layer));
                        break;
                    case 0x11:
                        tilesObjects.Add(new object_11(oid, x, y, size,layer));
                        break;
                    case 0x12:
                        tilesObjects.Add(new object_12(oid, x, y, size,layer));
                        break;
                    case 0x13:
                        tilesObjects.Add(new object_13(oid, x, y, size,layer));
                        break;
                    case 0x14:
                        tilesObjects.Add(new object_14(oid, x, y, size,layer));
                        break;
                    case 0x15:
                        tilesObjects.Add(new object_15(oid, x, y, size,layer));
                        break;
                    case 0x16:
                        tilesObjects.Add(new object_16(oid, x, y, size,layer));
                        break;
                    case 0x17:
                        tilesObjects.Add(new object_17(oid, x, y, size,layer));
                        break;
                    case 0x18:
                        tilesObjects.Add(new object_18(oid, x, y, size,layer));
                        break;
                    case 0x19:
                        tilesObjects.Add(new object_19(oid, x, y, size,layer));
                        break;
                    case 0x1A:
                        tilesObjects.Add(new object_1A(oid, x, y, size,layer));
                        break;
                    case 0x1B:
                        tilesObjects.Add(new object_1B(oid, x, y, size,layer));
                        break;
                    case 0x1C:
                        tilesObjects.Add(new object_1C(oid, x, y, size,layer));
                        break;
                    case 0x1D:
                        tilesObjects.Add(new object_1D(oid, x, y, size,layer));
                        break;
                    case 0x1E:
                        tilesObjects.Add(new object_1E(oid, x, y, size,layer));
                        break;
                    case 0x1F:
                        tilesObjects.Add(new object_1F(oid, x, y, size,layer));
                        break;
                    case 0x20:
                        tilesObjects.Add(new object_20(oid, x, y, size,layer));
                        break;
                    case 0x21:
                        tilesObjects.Add(new object_21(oid, x, y, size,layer));
                        break;
                    case 0x22:
                        tilesObjects.Add(new object_22(oid, x, y, size,layer));
                        break;
                    case 0x23:
                        tilesObjects.Add(new object_23(oid, x, y, size,layer));
                        break;
                    case 0x24:
                        tilesObjects.Add(new object_24(oid, x, y, size,layer));
                        break;
                    case 0x25:
                        tilesObjects.Add(new object_25(oid, x, y, size,layer));
                        break;
                    case 0x26:
                        tilesObjects.Add(new object_26(oid, x, y, size,layer));
                        break;
                    case 0x27:
                        tilesObjects.Add(new object_27(oid, x, y, size,layer));
                        break;
                    case 0x28:
                        tilesObjects.Add(new object_28(oid, x, y, size,layer));
                        break;
                    case 0x29:
                        tilesObjects.Add(new object_29(oid, x, y, size,layer));
                        break;
                    case 0x2A:
                        tilesObjects.Add(new object_2A(oid, x, y, size,layer));
                        break;
                    case 0x2B:
                        tilesObjects.Add(new object_2B(oid, x, y, size,layer));
                        break;
                    case 0x2C:
                        tilesObjects.Add(new object_2C(oid, x, y, size,layer));
                        break;
                    case 0x2D:
                        tilesObjects.Add(new object_2D(oid, x, y, size,layer));
                        break;
                    case 0x2E:
                        tilesObjects.Add(new object_2E(oid, x, y, size,layer));
                        break;
                    case 0x2F:
                        tilesObjects.Add(new object_2F(oid, x, y, size,layer));
                        break;
                    case 0x30:
                        tilesObjects.Add(new object_30(oid, x, y, size,layer));
                        break;
                    case 0x31:
                        tilesObjects.Add(new object_31(oid, x, y, size,layer));
                        break;
                    case 0x32:
                        tilesObjects.Add(new object_32(oid, x, y, size,layer));
                        break;
                    case 0x33:
                        tilesObjects.Add(new object_33(oid, x, y, size,layer));
                        break;
                    case 0x34:
                        tilesObjects.Add(new object_34(oid, x, y, size,layer));
                        break;
                    case 0x35:
                        tilesObjects.Add(new object_35(oid, x, y, size,layer));
                        break;
                    case 0x36:
                        tilesObjects.Add(new object_36(oid, x, y, size,layer));
                        break;
                    case 0x37:
                        tilesObjects.Add(new object_37(oid, x, y, size,layer));
                        break;
                    case 0x38:
                        tilesObjects.Add(new object_38(oid, x, y, size,layer));
                        break;
                    case 0x39:
                        tilesObjects.Add(new object_39(oid, x, y, size,layer));
                        break;
                    case 0x3A:
                        tilesObjects.Add(new object_3A(oid, x, y, size,layer));
                        break;
                    case 0x3B:
                        tilesObjects.Add(new object_3B(oid, x, y, size,layer));
                        break;
                    case 0x3C:
                        tilesObjects.Add(new object_3C(oid, x, y, size,layer));
                        break;
                    case 0x3D:
                        tilesObjects.Add(new object_3D(oid, x, y, size,layer));
                        break;
                    case 0x3E:
                        tilesObjects.Add(new object_3E(oid, x, y, size,layer));
                        break;
                    case 0x3F:
                        tilesObjects.Add(new object_3F(oid, x, y, size,layer));
                        break;
                    case 0x40:
                        tilesObjects.Add(new object_40(oid, x, y, size,layer));
                        break;
                    case 0x41:
                        tilesObjects.Add(new object_41(oid, x, y, size,layer));
                        break;
                    case 0x42:
                        tilesObjects.Add(new object_42(oid, x, y, size,layer));
                        break;
                    case 0x43:
                        tilesObjects.Add(new object_43(oid, x, y, size,layer));
                        break;
                    case 0x44:
                        tilesObjects.Add(new object_44(oid, x, y, size,layer));
                        break;
                    case 0x45:
                        tilesObjects.Add(new object_45(oid, x, y, size,layer));
                        break;
                    case 0x46:
                        tilesObjects.Add(new object_46(oid, x, y, size,layer));
                        break;
                    case 0x47:
                        tilesObjects.Add(new object_47(oid, x, y, size,layer));
                        break;
                    case 0x48:
                        tilesObjects.Add(new object_48(oid, x, y, size,layer));
                        break;
                    case 0x49:
                        tilesObjects.Add(new object_49(oid, x, y, size,layer));
                        break;
                    case 0x4A:
                        tilesObjects.Add(new object_4A(oid, x, y, size,layer));
                        break;
                    case 0x4B:
                        tilesObjects.Add(new object_4B(oid, x, y, size,layer));
                        break;
                    case 0x4C:
                        tilesObjects.Add(new object_4C(oid, x, y, size,layer));
                        break;
                    case 0x4D:
                        tilesObjects.Add(new object_4D(oid, x, y, size,layer));
                        break;
                    case 0x4E:
                        tilesObjects.Add(new object_4E(oid, x, y, size,layer));
                        break;
                    case 0x4F:
                        tilesObjects.Add(new object_4F(oid, x, y, size,layer));
                        break;
                    case 0x50:
                        tilesObjects.Add(new object_50(oid, x, y, size,layer));
                        break;
                    case 0x51:
                        tilesObjects.Add(new object_51(oid, x, y, size,layer));
                        break;
                    case 0x52:
                        tilesObjects.Add(new object_52(oid, x, y, size,layer));
                        break;
                    case 0x53:
                        tilesObjects.Add(new object_53(oid, x, y, size,layer));
                        break;
                    case 0x54:
                        tilesObjects.Add(new object_54(oid, x, y, size,layer));
                        break;
                    case 0x55:
                        tilesObjects.Add(new object_55(oid, x, y, size,layer));
                        break;
                    case 0x56:
                        tilesObjects.Add(new object_56(oid, x, y, size,layer));
                        break;
                    case 0x57:
                        tilesObjects.Add(new object_57(oid, x, y, size,layer));
                        break;
                    case 0x58:
                        tilesObjects.Add(new object_58(oid, x, y, size,layer));
                        break;
                    case 0x59:
                        tilesObjects.Add(new object_59(oid, x, y, size,layer));
                        break;
                    case 0x5A:
                        tilesObjects.Add(new object_5A(oid, x, y, size,layer));
                        break;
                    case 0x5B:
                        tilesObjects.Add(new object_5B(oid, x, y, size,layer));
                        break;
                    case 0x5C:
                        tilesObjects.Add(new object_5C(oid, x, y, size,layer));
                        break;
                    case 0x5D:
                        tilesObjects.Add(new object_5D(oid, x, y, size,layer));
                        break;
                    case 0x5E:
                        tilesObjects.Add(new object_5E(oid, x, y, size,layer));
                        break;
                    case 0x5F:
                        tilesObjects.Add(new object_5F(oid, x, y, size,layer));
                        break;
                    case 0x60:
                        tilesObjects.Add(new object_60(oid, x, y, size,layer));
                        break;
                    case 0x61:
                        tilesObjects.Add(new object_61(oid, x, y, size,layer));
                        break;
                    case 0x62:
                        tilesObjects.Add(new object_62(oid, x, y, size,layer));
                        break;
                    case 0x63:
                        tilesObjects.Add(new object_63(oid, x, y, size,layer));
                        break;
                    case 0x64:
                        tilesObjects.Add(new object_64(oid, x, y, size,layer));
                        break;
                    case 0x65:
                        tilesObjects.Add(new object_65(oid, x, y, size,layer));
                        break;
                    case 0x66:
                        tilesObjects.Add(new object_66(oid, x, y, size,layer));
                        break;
                    case 0x67:
                        tilesObjects.Add(new object_67(oid, x, y, size,layer));
                        break;
                    case 0x68:
                        tilesObjects.Add(new object_68(oid, x, y, size,layer));
                        break;
                    case 0x69:
                        tilesObjects.Add(new object_69(oid, x, y, size,layer));
                        break;
                    case 0x6A:
                        tilesObjects.Add(new object_6A(oid, x, y, size,layer));
                        break;
                    case 0x6B:
                        tilesObjects.Add(new object_6B(oid, x, y, size,layer));
                        break;
                    case 0x6C:
                        tilesObjects.Add(new object_6C(oid, x, y, size,layer));
                        break;
                    case 0x6D:
                        tilesObjects.Add(new object_6D(oid, x, y, size,layer));
                        break;
                    case 0x6E:
                        tilesObjects.Add(new object_6E(oid, x, y, size,layer));
                        break;
                    case 0x6F:
                        tilesObjects.Add(new object_6F(oid, x, y, size,layer));
                        break;
                    case 0x70:
                        tilesObjects.Add(new object_70(oid, x, y, size,layer));
                        break;
                    case 0x71:
                        tilesObjects.Add(new object_71(oid, x, y, size,layer));
                        break;
                    case 0x72:
                        tilesObjects.Add(new object_72(oid, x, y, size,layer));
                        break;
                    case 0x73:
                        tilesObjects.Add(new object_73(oid, x, y, size,layer));
                        break;
                    case 0x74:
                        tilesObjects.Add(new object_74(oid, x, y, size,layer));
                        break;
                    case 0x75:
                        tilesObjects.Add(new object_75(oid, x, y, size,layer));
                        break;
                    case 0x76:
                        tilesObjects.Add(new object_76(oid, x, y, size,layer));
                        break;
                    case 0x77:
                        tilesObjects.Add(new object_77(oid, x, y, size,layer));
                        break;
                    case 0x78:
                        tilesObjects.Add(new object_78(oid, x, y, size,layer));
                        break;
                    case 0x79:
                        tilesObjects.Add(new object_79(oid, x, y, size,layer));
                        break;
                    case 0x7A:
                        tilesObjects.Add(new object_7A(oid, x, y, size,layer));
                        break;
                    case 0x7B:
                        tilesObjects.Add(new object_7B(oid, x, y, size,layer));
                        break;
                    case 0x7C:
                        tilesObjects.Add(new object_7C(oid, x, y, size,layer));
                        break;
                    case 0x7D:
                        tilesObjects.Add(new object_7D(oid, x, y, size,layer));
                        break;
                    case 0x7E:
                        tilesObjects.Add(new object_7E(oid, x, y, size,layer));
                        break;
                    case 0x7F:
                        tilesObjects.Add(new object_7F(oid, x, y, size,layer));
                        break;
                    case 0x80:
                        tilesObjects.Add(new object_80(oid, x, y, size,layer));
                        break;
                    case 0x81:
                        tilesObjects.Add(new object_81(oid, x, y, size,layer));
                        break;
                    case 0x82:
                        tilesObjects.Add(new object_82(oid, x, y, size,layer));
                        break;
                    case 0x83:
                        tilesObjects.Add(new object_83(oid, x, y, size,layer));
                        break;
                    case 0x84:
                        tilesObjects.Add(new object_84(oid, x, y, size,layer));
                        break;
                    case 0x85:
                        tilesObjects.Add(new object_85(oid, x, y, size,layer));
                        break;
                    case 0x86:
                        tilesObjects.Add(new object_86(oid, x, y, size,layer));
                        break;
                    case 0x87:
                        tilesObjects.Add(new object_87(oid, x, y, size,layer));
                        break;
                    case 0x88:
                        tilesObjects.Add(new object_88(oid, x, y, size,layer));
                        break;
                    case 0x89:
                        tilesObjects.Add(new object_89(oid, x, y, size,layer));
                        break;
                    case 0x8A:
                        tilesObjects.Add(new object_8A(oid, x, y, size,layer));
                        break;
                    case 0x8B:
                        tilesObjects.Add(new object_8B(oid, x, y, size,layer));
                        break;
                    case 0x8C:
                        tilesObjects.Add(new object_8C(oid, x, y, size,layer));
                        break;
                    case 0x8D:
                        tilesObjects.Add(new object_8D(oid, x, y, size,layer));
                        break;
                    case 0x8E:
                        tilesObjects.Add(new object_8E(oid, x, y, size,layer));
                        break;
                    case 0x8F:
                        tilesObjects.Add(new object_8F(oid, x, y, size,layer));
                        break;
                    case 0x90:
                        tilesObjects.Add(new object_90(oid, x, y, size,layer));
                        break;
                    case 0x91:
                        tilesObjects.Add(new object_91(oid, x, y, size,layer));
                        break;
                    case 0x92:
                        tilesObjects.Add(new object_92(oid, x, y, size,layer));
                        break;
                    case 0x93:
                        tilesObjects.Add(new object_93(oid, x, y, size,layer));
                        break;
                    case 0x94:
                        tilesObjects.Add(new object_94(oid, x, y, size,layer));
                        break;
                    case 0x95:
                        tilesObjects.Add(new object_95(oid, x, y, size,layer));
                        break;
                    case 0x96:
                        tilesObjects.Add(new object_96(oid, x, y, size,layer));
                        break;
                    case 0x97:
                        tilesObjects.Add(new object_97(oid, x, y, size,layer));
                        break;
                    case 0x98:
                        tilesObjects.Add(new object_98(oid, x, y, size,layer));
                        break;
                    case 0x99:
                        tilesObjects.Add(new object_99(oid, x, y, size,layer));
                        break;
                    case 0x9A:
                        tilesObjects.Add(new object_9A(oid, x, y, size,layer));
                        break;
                    case 0x9B:
                        tilesObjects.Add(new object_9B(oid, x, y, size,layer));
                        break;
                    case 0x9C:
                        tilesObjects.Add(new object_9C(oid, x, y, size,layer));
                        break;
                    case 0x9D:
                        tilesObjects.Add(new object_9D(oid, x, y, size,layer));
                        break;
                    case 0x9E:
                        tilesObjects.Add(new object_9E(oid, x, y, size,layer));
                        break;
                    case 0x9F:
                        tilesObjects.Add(new object_9F(oid, x, y, size,layer));
                        break;
                    case 0xA0:
                        tilesObjects.Add(new object_A0(oid, x, y, size,layer));
                        break;
                    case 0xA1:
                        tilesObjects.Add(new object_A1(oid, x, y, size,layer));
                        break;
                    case 0xA2:
                        tilesObjects.Add(new object_A2(oid, x, y, size,layer));
                        break;
                    case 0xA3:
                        tilesObjects.Add(new object_A3(oid, x, y, size,layer));
                        break;
                    case 0xA4:
                        tilesObjects.Add(new object_A4(oid, x, y, size,layer));
                        break;
                    case 0xA5:
                        tilesObjects.Add(new object_A5(oid, x, y, size,layer));
                        break;
                    case 0xA6:
                        tilesObjects.Add(new object_A6(oid, x, y, size,layer));
                        break;
                    case 0xA7:
                        tilesObjects.Add(new object_A7(oid, x, y, size,layer));
                        break;
                    case 0xA8:
                        tilesObjects.Add(new object_A8(oid, x, y, size,layer));
                        break;
                    case 0xA9:
                        tilesObjects.Add(new object_A9(oid, x, y, size,layer));
                        break;
                    case 0xAA:
                        tilesObjects.Add(new object_AA(oid, x, y, size,layer));
                        break;
                    case 0xAB:
                        tilesObjects.Add(new object_AB(oid, x, y, size,layer));
                        break;
                    case 0xAC:
                        tilesObjects.Add(new object_AC(oid, x, y, size,layer));
                        break;
                    case 0xAD:
                        tilesObjects.Add(new object_AD(oid, x, y, size,layer));
                        break;
                    case 0xAE:
                        tilesObjects.Add(new object_AE(oid, x, y, size,layer));
                        break;
                    case 0xAF:
                        tilesObjects.Add(new object_AF(oid, x, y, size,layer));
                        break;
                    case 0xB0:
                        tilesObjects.Add(new object_B0(oid, x, y, size,layer));
                        break;
                    case 0xB1:
                        tilesObjects.Add(new object_B1(oid, x, y, size,layer));
                        break;
                    case 0xB2:
                        tilesObjects.Add(new object_B2(oid, x, y, size,layer));
                        break;
                    case 0xB3:
                        tilesObjects.Add(new object_B3(oid, x, y, size,layer));
                        break;
                    case 0xB4:
                        tilesObjects.Add(new object_B4(oid, x, y, size,layer));
                        break;
                    case 0xB5:
                        tilesObjects.Add(new object_B5(oid, x, y, size,layer));
                        break;
                    case 0xB6:
                        tilesObjects.Add(new object_B6(oid, x, y, size,layer));
                        break;
                    case 0xB7:
                        tilesObjects.Add(new object_B7(oid, x, y, size,layer));
                        break;
                    case 0xB8:
                        tilesObjects.Add(new object_B8(oid, x, y, size,layer));
                        break;
                    case 0xB9:
                        tilesObjects.Add(new object_B9(oid, x, y, size,layer));
                        break;
                    case 0xBA:
                        tilesObjects.Add(new object_BA(oid, x, y, size,layer));
                        break;
                    case 0xBB:
                        tilesObjects.Add(new object_BB(oid, x, y, size,layer));
                        break;
                    case 0xBC:
                        tilesObjects.Add(new object_BC(oid, x, y, size,layer));
                        break;
                    case 0xBD:
                        tilesObjects.Add(new object_BD(oid, x, y, size,layer));
                        break;
                    case 0xBE:
                        tilesObjects.Add(new object_BE(oid, x, y, size,layer));
                        break;
                    case 0xBF:
                        tilesObjects.Add(new object_BF(oid, x, y, size,layer));
                        break;
                    case 0xC0:
                        tilesObjects.Add(new object_C0(oid, x, y, size, layer));
                        break;
                    case 0xC1:
                        tilesObjects.Add(new object_C1(oid, x, y, size, layer));
                        break;
                    case 0xC2:
                        tilesObjects.Add(new object_C2(oid, x, y, size, layer));
                        break;
                    case 0xC3:
                        tilesObjects.Add(new object_C3(oid, x, y, size, layer));
                        break;
                    case 0xC4:
                        tilesObjects.Add(new object_C4(oid, x, y, size, layer));
                        break;
                    case 0xC5:
                        tilesObjects.Add(new object_C5(oid, x, y, size, layer));
                        break;
                    case 0xC6:
                        tilesObjects.Add(new object_C6(oid, x, y, size, layer));
                        break;
                    case 0xC7:
                        tilesObjects.Add(new object_C7(oid, x, y, size, layer));
                        break;
                    case 0xC8:
                        tilesObjects.Add(new object_C8(oid, x, y, size, layer));
                        break;
                    case 0xC9:
                        tilesObjects.Add(new object_C9(oid, x, y, size, layer));
                        break;
                    case 0xCA:
                        tilesObjects.Add(new object_CA(oid, x, y, size, layer));
                        break;
                    case 0xCB:
                        tilesObjects.Add(new object_CB(oid, x, y, size, layer));
                        break;
                    case 0xCC:
                        tilesObjects.Add(new object_CC(oid, x, y, size, layer));
                        break;
                    case 0xCD:
                        tilesObjects.Add(new object_CD(oid, x, y, size, layer));
                        break;
                    case 0xCE:
                        tilesObjects.Add(new object_CE(oid, x, y, size, layer));
                        break;
                    case 0xCF:
                        tilesObjects.Add(new object_CF(oid, x, y, size, layer));
                        break;
                    case 0xD0:
                        tilesObjects.Add(new object_D0(oid, x, y, size, layer));
                        break;
                    case 0xD1:
                        tilesObjects.Add(new object_D1(oid, x, y, size, layer));
                        break;
                    case 0xD2:
                        tilesObjects.Add(new object_D2(oid, x, y, size, layer));
                        break;
                    case 0xD3:
                        tilesObjects.Add(new object_D3(oid, x, y, size, layer));
                        break;
                    case 0xD4:
                        tilesObjects.Add(new object_D4(oid, x, y, size, layer));
                        break;
                    case 0xD5:
                        tilesObjects.Add(new object_D5(oid, x, y, size, layer));
                        break;
                    case 0xD6:
                        tilesObjects.Add(new object_D6(oid, x, y, size, layer));
                        break;
                    case 0xD7:
                        tilesObjects.Add(new object_D7(oid, x, y, size, layer));
                        break;
                    case 0xD8:
                        tilesObjects.Add(new object_D8(oid, x, y, size, layer));
                        break;
                    case 0xD9:
                        tilesObjects.Add(new object_D9(oid, x, y, size, layer));
                        break;
                    case 0xDA:
                        tilesObjects.Add(new object_DA(oid, x, y, size, layer));
                        break;
                    case 0xDB:
                        tilesObjects.Add(new object_DB(oid, x, y, size, layer));
                        break;
                    case 0xDC:
                        tilesObjects.Add(new object_DC(oid, x, y, size, layer));
                        break;
                    case 0xDD:
                        tilesObjects.Add(new object_DD(oid, x, y, size, layer));
                        break;
                    case 0xDE:
                        tilesObjects.Add(new object_DE(oid, x, y, size, layer));
                        break;
                    case 0xDF:
                        tilesObjects.Add(new object_DF(oid, x, y, size, layer));
                        break;
                    case 0xE0:
                        tilesObjects.Add(new object_E0(oid, x, y, size, layer));
                        break;
                    case 0xE1:
                        tilesObjects.Add(new object_E1(oid, x, y, size, layer));
                        break;
                    case 0xE2:
                        tilesObjects.Add(new object_E2(oid, x, y, size, layer));
                        break;
                    case 0xE3:
                        tilesObjects.Add(new object_E3(oid, x, y, size, layer));
                        break;
                    case 0xE4:
                        tilesObjects.Add(new object_E4(oid, x, y, size, layer));
                        break;
                    case 0xE5:
                        tilesObjects.Add(new object_E5(oid, x, y, size, layer));
                        break;
                    case 0xE6:
                        tilesObjects.Add(new object_E6(oid, x, y, size, layer));
                        break;
                    case 0xE7:
                        tilesObjects.Add(new object_E7(oid, x, y, size, layer));
                        break;
                    case 0xE8:
                        tilesObjects.Add(new object_E8(oid, x, y, size, layer));
                        break;
                    case 0xE9:
                        tilesObjects.Add(new object_E9(oid, x, y, size, layer));
                        break;
                    case 0xEA:
                        tilesObjects.Add(new object_EA(oid, x, y, size, layer));
                        break;
                    case 0xEB:
                        tilesObjects.Add(new object_EB(oid, x, y, size, layer));
                        break;
                    case 0xEC:
                        tilesObjects.Add(new object_EC(oid, x, y, size, layer));
                        break;
                    case 0xED:
                        tilesObjects.Add(new object_ED(oid, x, y, size, layer));
                        break;
                    case 0xEE:
                        tilesObjects.Add(new object_EE(oid, x, y, size, layer));
                        break;
                    case 0xEF:
                        tilesObjects.Add(new object_EF(oid, x, y, size, layer));
                        break;
                }
            }
            else
            {
                //subtype2
                if ((oid & 0x100) == 0x100) //subtype2? non scalable
                {
                    tilesObjects.Add(new Subtype2_Multiple(oid, x, y, 0,layer));
                }
                //subtype3
                if ((oid & 0xF00) == 0xF00)
                {
                    switch (oid)
                    {
                        case 0xF80:
                            tilesObjects.Add(new object_F80(oid, x, y, size, layer));
                            break;
                        case 0xF81:
                            tilesObjects.Add(new object_F81(oid, x, y, size, layer));
                            break;
                        case 0xF82:
                            tilesObjects.Add(new object_F82(oid, x, y, size, layer));
                            break;
                        case 0xF83:
                            tilesObjects.Add(new object_F83(oid, x, y, size, layer));
                            break;
                        case 0xF84:
                            tilesObjects.Add(new object_F84(oid, x, y, size, layer));
                            break;
                        case 0xF85:
                            tilesObjects.Add(new object_F85(oid, x, y, size, layer));
                            break;
                        case 0xF86:
                            tilesObjects.Add(new object_F86(oid, x, y, size, layer));
                            break;
                        case 0xF87:
                            tilesObjects.Add(new object_F87(oid, x, y, size, layer));
                            break;
                        case 0xF88:
                            tilesObjects.Add(new object_F88(oid, x, y, size, layer));
                            break;
                        case 0xF89:
                            tilesObjects.Add(new object_F89(oid, x, y, size, layer));
                            break;
                        case 0xF8A:
                            tilesObjects.Add(new object_F8A(oid, x, y, size, layer));
                            break;
                        case 0xF8B:
                            tilesObjects.Add(new object_F8B(oid, x, y, size, layer));
                            break;
                        case 0xF8C:
                            tilesObjects.Add(new object_F8C(oid, x, y, size, layer));
                            break;
                        case 0xF8D:
                            tilesObjects.Add(new object_F8D(oid, x, y, size, layer));
                            break;
                        case 0xF8E:
                            tilesObjects.Add(new object_F8E(oid, x, y, size, layer));
                            break;
                        case 0xF8F:
                            tilesObjects.Add(new object_F8F(oid, x, y, size, layer));
                            break;
                        case 0xF90:
                            tilesObjects.Add(new object_F90(oid, x, y, size, layer));
                            break;
                        case 0xF91:
                            tilesObjects.Add(new object_F91(oid, x, y, size, layer));
                            break;
                        case 0xF92:
                            tilesObjects.Add(new object_F92(oid, x, y, size, layer));
                            break;
                        case 0xF93:
                            tilesObjects.Add(new object_F93(oid, x, y, size, layer));
                            break;
                        case 0xF94:
                            tilesObjects.Add(new object_F94(oid, x, y, size, layer));
                            break;
                        case 0xF95:
                            tilesObjects.Add(new object_F95(oid, x, y, size, layer));
                            break;
                        case 0xF96:
                            tilesObjects.Add(new object_F96(oid, x, y, size, layer));
                            break;
                        case 0xF97:
                            tilesObjects.Add(new object_F97(oid, x, y, size, layer));
                            break;
                        case 0xF98:
                            tilesObjects.Add(new object_F98(oid, x, y, size, layer));
                            break;
                        case 0xF99:
                            tilesObjects.Add(new object_F99(oid, x, y, size, layer));
                            break;
                        case 0xF9A:
                            tilesObjects.Add(new object_F9A(oid, x, y, size, layer));
                            break;
                        case 0xF9B:
                            tilesObjects.Add(new object_F9B(oid, x, y, size, layer));
                            break;
                        case 0xF9C:
                            tilesObjects.Add(new object_F9C(oid, x, y, size, layer));
                            break;
                        case 0xF9D:
                            tilesObjects.Add(new object_F9D(oid, x, y, size, layer));
                            break;
                        case 0xF9E:
                            tilesObjects.Add(new object_F9E(oid, x, y, size, layer));
                            break;
                        case 0xF9F:
                            tilesObjects.Add(new object_F9F(oid, x, y, size, layer));
                            break;
                        case 0xFA0:
                            tilesObjects.Add(new object_FA0(oid, x, y, size, layer));
                            break;
                        case 0xFA1:
                            tilesObjects.Add(new object_FA1(oid, x, y, size, layer));
                            break;
                        case 0xFA2:
                            tilesObjects.Add(new object_FA2(oid, x, y, size, layer));
                            break;
                        case 0xFA3:
                            tilesObjects.Add(new object_FA3(oid, x, y, size, layer));
                            break;
                        case 0xFA4:
                            tilesObjects.Add(new object_FA4(oid, x, y, size, layer));
                            break;
                        case 0xFA5:
                            tilesObjects.Add(new object_FA5(oid, x, y, size, layer));
                            break;
                        case 0xFA6:
                            tilesObjects.Add(new object_FA6(oid, x, y, size, layer));
                            break;
                        case 0xFA7:
                            tilesObjects.Add(new object_FA7(oid, x, y, size, layer));
                            break;
                        case 0xFA8:
                            tilesObjects.Add(new object_FA8(oid, x, y, size, layer));
                            break;
                        case 0xFA9:
                            tilesObjects.Add(new object_FA9(oid, x, y, size, layer));
                            break;
                        case 0xFAA:
                            tilesObjects.Add(new object_FAA(oid, x, y, size, layer));
                            break;
                        case 0xFAB:
                            tilesObjects.Add(new object_FAB(oid, x, y, size, layer));
                            break;
                        case 0xFAC:
                            tilesObjects.Add(new object_FAC(oid, x, y, size, layer));
                            break;
                        case 0xFAD:
                            tilesObjects.Add(new object_FAD(oid, x, y, size, layer));
                            break;
                        case 0xFAE:
                            tilesObjects.Add(new object_FAE(oid, x, y, size, layer));
                            break;
                        case 0xFAF:
                            tilesObjects.Add(new object_FAF(oid, x, y, size, layer));
                            break;
                        case 0xFB0:
                            tilesObjects.Add(new object_FB0(oid, x, y, size, layer));
                            break;
                        case 0xFB1:
                            tilesObjects.Add(new object_FB1(oid, x, y, size, layer));
                            break;
                        case 0xFB2:
                            tilesObjects.Add(new object_FB2(oid, x, y, size, layer));
                            break;
                        case 0xFB3:
                            tilesObjects.Add(new object_FB3(oid, x, y, size, layer));
                            break;
                        case 0xFB4:
                            tilesObjects.Add(new object_FB4(oid, x, y, size, layer));
                            break;
                        case 0xFB5:
                            tilesObjects.Add(new object_FB5(oid, x, y, size, layer));
                            break;
                        case 0xFB6:
                            tilesObjects.Add(new object_FB6(oid, x, y, size, layer));
                            break;
                        case 0xFB7:
                            tilesObjects.Add(new object_FB7(oid, x, y, size, layer));
                            break;
                        case 0xFB8:
                            tilesObjects.Add(new object_FB8(oid, x, y, size, layer));
                            break;
                        case 0xFB9:
                            tilesObjects.Add(new object_FB9(oid, x, y, size, layer));
                            break;
                        case 0xFBA:
                            tilesObjects.Add(new object_FBA(oid, x, y, size, layer));
                            break;
                        case 0xFBB:
                            tilesObjects.Add(new object_FBA(oid, x, y, size, layer));
                            break;
                        case 0xFBC:
                            tilesObjects.Add(new object_FBC(oid, x, y, size, layer));
                            break;
                        case 0xFBD:
                            tilesObjects.Add(new object_FBD(oid, x, y, size, layer));
                            break;
                        case 0xFBE:
                            tilesObjects.Add(new object_FBE(oid, x, y, size, layer));
                            break;
                        case 0xFBF:
                            tilesObjects.Add(new object_FBF(oid, x, y, size, layer));
                            break;
                        case 0xFC0:
                            tilesObjects.Add(new object_FC0(oid, x, y, size, layer));
                            break;
                        case 0xFC1:
                            tilesObjects.Add(new object_FC1(oid, x, y, size, layer));
                            break;
                        case 0xFC2:
                            tilesObjects.Add(new object_FC2(oid, x, y, size, layer));
                            break;
                        case 0xFC3:
                            tilesObjects.Add(new object_FC3(oid, x, y, size, layer));
                            break;
                        case 0xFC4:
                            tilesObjects.Add(new object_FC4(oid, x, y, size, layer));
                            break;
                        case 0xFC5:
                            tilesObjects.Add(new object_FC5(oid, x, y, size, layer));
                            break;
                        case 0xFC6:
                            tilesObjects.Add(new object_FC6(oid, x, y, size, layer));
                            break;
                        case 0xFC7:
                            tilesObjects.Add(new object_FC7(oid, x, y, size, layer));
                            break;
                        case 0xFC8:
                            tilesObjects.Add(new object_FC8(oid, x, y, size, layer));
                            break;
                        case 0xFC9:
                            tilesObjects.Add(new object_FC9(oid, x, y, size, layer));
                            break;
                        case 0xFCA:
                            tilesObjects.Add(new object_FCA(oid, x, y, size, layer));
                            break;
                        case 0xFCB:
                            tilesObjects.Add(new object_FCB(oid, x, y, size, layer));
                            break;
                        case 0xFCC:
                            tilesObjects.Add(new object_FCC(oid, x, y, size, layer));
                            break;
                        case 0xFCD:
                            tilesObjects.Add(new object_FCD(oid, x, y, size, layer));
                            break;
                        case 0xFCE:
                            tilesObjects.Add(new object_FCE(oid, x, y, size, layer));
                            break;
                        case 0xFCF:
                            tilesObjects.Add(new object_FCF(oid, x, y, size, layer));
                            break;
                        case 0xFD0:
                            tilesObjects.Add(new object_FD0(oid, x, y, size, layer));
                            break;
                        case 0xFD1:
                            tilesObjects.Add(new object_FD1(oid, x, y, size, layer));
                            break;
                        case 0xFD2:
                            tilesObjects.Add(new object_FD2(oid, x, y, size, layer));
                            break;
                        case 0xFD3:
                            tilesObjects.Add(new object_FD3(oid, x, y, size, layer));
                            break;
                        case 0xFD4:
                            tilesObjects.Add(new object_FD4(oid, x, y, size, layer));
                            break;
                        case 0xFD5:
                            tilesObjects.Add(new object_FD5(oid, x, y, size, layer));
                            break;
                        case 0xFD6:
                            tilesObjects.Add(new object_FD6(oid, x, y, size, layer));
                            break;
                        case 0xFD7:
                            tilesObjects.Add(new object_FD7(oid, x, y, size, layer));
                            break;
                        case 0xFD8:
                            tilesObjects.Add(new object_FD8(oid, x, y, size, layer));
                            break;
                        case 0xFD9:
                            tilesObjects.Add(new object_FD9(oid, x, y, size, layer));
                            break;
                        case 0xFDA:
                            tilesObjects.Add(new object_FDA(oid, x, y, size, layer));
                            break;
                        case 0xFDB:
                            tilesObjects.Add(new object_FDB(oid, x, y, size, layer));
                            break;
                        case 0xFDC:
                            tilesObjects.Add(new object_FDC(oid, x, y, size, layer));
                            break;
                        case 0xFDD:
                            tilesObjects.Add(new object_FDD(oid, x, y, size, layer));
                            break;
                        case 0xFDE:
                            tilesObjects.Add(new object_FDE(oid, x, y, size, layer));
                            break;
                        case 0xFDF:
                            tilesObjects.Add(new object_FDF(oid, x, y, size, layer));
                            break;
                        case 0xFE0:
                            tilesObjects.Add(new object_FE0(oid, x, y, size, layer));
                            break;
                        case 0xFE1:
                            tilesObjects.Add(new object_FE1(oid, x, y, size, layer));
                            break;
                        case 0xFE2:
                            tilesObjects.Add(new object_FE2(oid, x, y, size, layer));
                            break;
                        case 0xFE3:
                            tilesObjects.Add(new object_FE3(oid, x, y, size, layer));
                            break;
                        case 0xFE4:
                            tilesObjects.Add(new object_FE4(oid, x, y, size, layer));
                            break;
                        case 0xFE5:
                            tilesObjects.Add(new object_FE5(oid, x, y, size, layer));
                            break;
                        case 0xFE6:
                            tilesObjects.Add(new object_FE6(oid, x, y, size, layer));
                            break;
                        case 0xFE7:
                            tilesObjects.Add(new object_FE7(oid, x, y, size, layer));
                            break;
                        case 0xFE8:
                            tilesObjects.Add(new object_FE8(oid, x, y, size, layer));
                            break;
                        case 0xFE9:
                            tilesObjects.Add(new object_FE9(oid, x, y, size, layer));
                            break;
                        case 0xFEA:
                            tilesObjects.Add(new object_FEA(oid, x, y, size, layer));
                            break;
                        case 0xFEB:
                            tilesObjects.Add(new object_FEB(oid, x, y, size, layer));
                            break;
                        case 0xFEC:
                            tilesObjects.Add(new object_FEC(oid, x, y, size, layer));
                            break;
                        case 0xFED:
                            tilesObjects.Add(new object_FED(oid, x, y, size, layer));
                            break;
                        case 0xFEE:
                            tilesObjects.Add(new object_FEE(oid, x, y, size, layer));
                            break;
                        case 0xFEF:
                            tilesObjects.Add(new object_FEF(oid, x, y, size, layer));
                            break;
                        case 0xFF0:
                            tilesObjects.Add(new object_FF0(oid, x, y, size, layer));
                            break;
                        case 0xFF1:
                            tilesObjects.Add(new object_FF1(oid, x, y, size, layer));
                            break;
                        case 0xFF2:
                            tilesObjects.Add(new object_FF2(oid, x, y, size, layer));
                            break;
                        case 0xFF3:
                            tilesObjects.Add(new object_FF3(oid, x, y, size, layer));
                            break;
                        case 0xFF4:
                            tilesObjects.Add(new object_FF4(oid, x, y, size, layer));
                            break;
                        case 0xFF5:
                            tilesObjects.Add(new object_FF5(oid, x, y, size, layer));
                            break;
                    }
                }

            }
        }


        public void DrawFloors()
        {

            BitmapData bdata = GFX.blocksets[2].LockBits(new Rectangle(0, 0, 128, 384), ImageLockMode.ReadWrite, GFX.blocksets[2].PixelFormat);
            IntPtr ptrx = bdata.Scan0;
            int bytes = Math.Abs(bdata.Stride) * GFX.blocksets[4].Height;
            GFX.blocksetData = new byte[bytes];
            Marshal.Copy(ptrx, GFX.blocksetData, 0, bytes);
            GFX.blocksets[2].UnlockBits(bdata);
            GFX.begin_draw(floor1_bitmap);

            

            

            byte f = (byte)(floor1 << 4);
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
                    floorTile1.Draw((xx * 4), (yy * 2), floor1_bitmap); floorTile2.Draw((xx * 4) + 1, (yy * 2), floor1_bitmap);
                    floorTile3.Draw((xx * 4) + 2, (yy * 2), floor1_bitmap); floorTile4.Draw((xx * 4) + 3, (yy * 2), floor1_bitmap);

                    floorTile5.Draw((xx * 4), (yy * 2) + 1, floor1_bitmap); floorTile6.Draw((xx * 4) + 1, (yy * 2) + 1, floor1_bitmap);
                    floorTile7.Draw((xx * 4) + 2, (yy * 2) + 1, floor1_bitmap); floorTile8.Draw((xx * 4) + 3, (yy * 2) + 1, floor1_bitmap);
                }
            }

            f = (byte)(floor2 << 4);
            //x x 4
            floorTile1 = new Tile(ROM.DATA[Constants.tile_address + f], ROM.DATA[Constants.tile_address + f + 1]);
            floorTile2 = new Tile(ROM.DATA[Constants.tile_address + f + 2], ROM.DATA[Constants.tile_address + f + 3]);
            floorTile3 = new Tile(ROM.DATA[Constants.tile_address + f + 4], ROM.DATA[Constants.tile_address + f + 5]);
            floorTile4 = new Tile(ROM.DATA[Constants.tile_address + f + 6], ROM.DATA[Constants.tile_address + f + 7]);

            floorTile5 = new Tile(ROM.DATA[Constants.tile_address_floor + f], ROM.DATA[Constants.tile_address_floor + f + 1]);
            floorTile6 = new Tile(ROM.DATA[Constants.tile_address_floor + f + 2], ROM.DATA[Constants.tile_address_floor + f + 3]);
            floorTile7 = new Tile(ROM.DATA[Constants.tile_address_floor + f + 4], ROM.DATA[Constants.tile_address_floor + f + 5]);
            floorTile8 = new Tile(ROM.DATA[Constants.tile_address_floor + f + 6], ROM.DATA[Constants.tile_address_floor + f + 7]);


            for (int xx = 0; xx < 16; xx++)
            {
                for (int yy = 0; yy < 32; yy++)
                {
                    floorTile1.Draw((xx * 4), (yy * 2), floor2_bitmap); floorTile2.Draw((xx * 4) + 1, (yy * 2), floor2_bitmap);
                    floorTile3.Draw((xx * 4) + 2, (yy * 2), floor2_bitmap); floorTile4.Draw((xx * 4) + 3, (yy * 2), floor2_bitmap);

                    floorTile5.Draw((xx * 4), (yy * 2) + 1, floor2_bitmap); floorTile6.Draw((xx * 4) + 1, (yy * 2) + 1, floor2_bitmap);
                    floorTile7.Draw((xx * 4) + 2, (yy * 2) + 1, floor2_bitmap); floorTile8.Draw((xx * 4) + 3, (yy * 2) + 1, floor2_bitmap);
                }
            }
            GFX.end_draw(floor1_bitmap);
        }


        public void Draw()
        {

            
        }

        public void InitItemsDraw()
        {
            for(int i = 0;i<75;i++)
            {
                items_image[i] = new Bitmap(16, 16);
            }

            //sword and shield
            draw_item_tile(items_image[0], -1, 0, 8, 16, 0x21, 0);
            draw_item_tile(items_image[0], 3, 0, 16, 16, 0x0E, 0);

            //swords - need to do something else?
            draw_item_tile(items_image[1], 4, 0, 8, 16, 0x21, 0);
            draw_item_tile(items_image[2], 4, 0, 8, 16, 0x21, 0);
            draw_item_tile(items_image[3], 4, 0, 8, 16, 0x21, 0);


            //shields - need to do something else?
            draw_item_tile(items_image[4], 0, 0, 16, 16, 0x0E, 0);
            draw_item_tile(items_image[5], 0, 0, 16, 16, 0x0C, 2);
            draw_item_tile(items_image[6], 0, 0, 16, 16, 0xA4, 2);
            
            draw_item_tile(items_image[7], 4, 0, 8, 16, 0x24, 1);
            draw_item_tile(items_image[8], 4, 0, 8, 16, 0x24, 0);
            draw_item_tile(items_image[9], 4, 0, 8, 16, 0x25, 1);
            draw_item_tile(items_image[10], 4, 0, 8, 16, 0x23, 1);
            draw_item_tile(items_image[11], 4, 0, 8, 16, 0x20, 1);
            draw_item_tile(items_image[12], 4, 0, 8, 16, 0x2F, 0);
            draw_item_tile(items_image[13], 0, 0, 16, 16, 0x26, 0);
            draw_item_tile(items_image[14], 0, 0, 16, 16, 0x8D, 0);
            draw_item_tile(items_image[15], 0, 0, 16, 16, 0x60, 2);
            draw_item_tile(items_image[16], 0, 0, 16, 16, 0x62, 2);
            draw_item_tile(items_image[17], 0, 0, 16, 16, 0x64, 2);
            draw_item_tile(items_image[18], 0, 0, 16, 16, 0x46, 1);
            draw_item_tile(items_image[19], 4, 0, 8, 16, 0x4F, 0);
            draw_item_tile(items_image[20], 0, 0, 16, 16, 0xA2, 0);
            draw_item_tile(items_image[21], 4, 0, 8, 16, 0x22, 1);
            draw_item_tile(items_image[22], 0, 0, 16, 16, 0x66, 0);
            draw_item_tile(items_image[23], 0, 0, 16, 16, 0xA0, 1);
            draw_item_tile(items_image[24], 4, 0, 8, 16, 0x22, 0);
            draw_item_tile(items_image[25], 0, 0, 16, 16, 0x48, 1);
            draw_item_tile(items_image[26], 0, 0, 16, 16, 0x42, 0);
            draw_item_tile(items_image[27], 0, 0, 16, 16, 0x2A, 1);
            draw_item_tile(items_image[28], 0, 0, 16, 16, 0x2A, 2);
            draw_item_tile(items_image[29], 0, 0, 16, 16, 0x2C, 2);
            draw_item_tile(items_image[30], 0, 0, 16, 16, 0x40, 0);
            draw_item_tile(items_image[31], 0, 0, 16, 16, 0x4C, 1);
            draw_item_tile(items_image[32], 0, 0, 16, 16, 0x85, 0);
            draw_item_tile(items_image[33], 0, 0, 16, 16, 0x83, 1);
            draw_item_tile(items_image[34], 0, 0, 16, 16, 0x08, 0);//blue mail
            draw_item_tile(items_image[35], 0, 0, 16, 16, 0x08, 1);
            draw_item_tile(items_image[36], 4, 0, 8, 16, 0x2E, 2);
            draw_item_tile(items_image[37], 0, 0, 16, 16, 0x4A, 0);
            draw_item_tile(items_image[38], 0, 0, 16, 16, 0x06, 1); //liar heart? lol
            draw_item_tile(items_image[39], 0, 0, 16, 16, 0x44, 0);
            draw_item_tile(items_image[40], 0, 0, 16, 16, 0x02, 0);
            draw_item_tile(items_image[41], 0, 0, 16, 16, 0x6A, 2);
            draw_item_tile(items_image[42], 4, 0, 8, 16, 0x2F, 1);
            draw_item_tile(items_image[43], 0, 0, 16, 16, 0x00, 1);
            draw_item_tile(items_image[44], 0, 0, 16, 16, 0x00, 2);
            draw_item_tile(items_image[45], 0, 0, 16, 16, 0x00, 0);
            draw_item_tile(items_image[46], 0, 0, 16, 16, 0x00, 1);
            draw_item_tile(items_image[47], 0, 0, 16, 16, 0x00, 2);
            draw_item_tile(items_image[48], 0, 0, 16, 16, 0x00, 0);
            draw_item_tile(items_image[49], 0, 0, 16, 16, 0x28, 0);
            draw_item_tile(items_image[50], 0, 0, 16, 16, 0x6E, 2);
            draw_item_tile(items_image[51], 0, 0, 16, 16, 0x6C, 2);
            draw_item_tile(items_image[52], 4, 0, 8, 16, 0x81, 2);
            draw_item_tile(items_image[53], 4, 0, 8, 16, 0x81, 0);
            draw_item_tile(items_image[54], 4, 0, 8, 16, 0x81, 1);
            draw_item_tile(items_image[55], 4, 0, 8, 16, 0xC4, 2);
            draw_item_tile(items_image[56], 4, 0, 8, 16, 0xC4, 0);
            draw_item_tile(items_image[57], 4, 0, 8, 16, 0xC4, 1);
            draw_item_tile(items_image[58], 0, 0, 16, 16, 0x89, 0);
            draw_item_tile(items_image[59], 0, 0, 16, 16, 0x87, 1);
            draw_item_tile(items_image[60], 0, 0, 16, 16, 0x8D, 0);
            draw_item_tile(items_image[61], 0, 0, 16, 16, 0x8B, 0);
            draw_item_tile(items_image[62], 0, 0, 16, 16, 0x06, 1); //boss heart
            draw_item_tile(items_image[63], 0, 0, 16, 16, 0x06, 1); //sanc heart?
            draw_item_tile(items_image[64], 0, 0, 16, 16, 0xA9, 2);
            draw_item_tile(items_image[65], 0, 0, 16, 16, 0xAB, 2);
            draw_item_tile(items_image[66], 4, 0, 8, 16, 0xA6, 1);
            draw_item_tile(items_image[67], 4, 0, 8, 16, 0xA8, 0);
            draw_item_tile(items_image[68], 0, 0, 16, 16, 0x04, 0);
            draw_item_tile(items_image[69], 4, 0, 8, 16, 0xA7, 0);
            draw_item_tile(items_image[70], 0, 0, 16, 16, 0xAD, 2);
            draw_item_tile(items_image[71], 0, 0, 16, 16, 0xC0, 2);
            draw_item_tile(items_image[72], 0, 0, 16, 16, 0x8B, 0);
            draw_item_tile(items_image[73], 4, 0, 8, 16, 0x21, 0);
            draw_item_tile(items_image[74], 0, 0, 16, 16, 0xA2, 0);
        }

        public void draw_item_tile(Bitmap b,int x,int y,int sx,int sy,int tid,int pid)
        {
            using (Graphics g = Graphics.FromImage(b))
            {
                int ty = (tid / 16);
                int tx = tid - (ty * 16);
                g.DrawImage(GFX.blocksets_items[pid], new Rectangle(x, y, sx, sy), tx * 8, ty * 8, sx, sy, GraphicsUnit.Pixel);
            }
            b.MakeTransparent(Color.Black);
        }


        public void loadHeader()
        {
            //address of the room header
            int address = (ROM.DATA[Constants.room_header_pointers_bank] << 16) +
                            (ROM.DATA[(Constants.room_header_pointers + 1)+ (index * 2)] << 8) +
                            ROM.DATA[(Constants.room_header_pointers) + (index*2)];

            header_location = Addresses.snestopc(address);

            bg2 = (byte)((ROM.DATA[header_location] >> 5) & 0x07);
            collision = (byte)((ROM.DATA[header_location] >> 2) & 0x07);
            light = (((ROM.DATA[header_location]) & 0x01) == 0 ? true : false);

            palette = (byte)((ROM.DATA[header_location + 1] & 0x3F));
            blockset = (byte)((ROM.DATA[header_location + 2]));
            spriteset = (byte)((ROM.DATA[header_location + 3]));
            effect = (byte)((ROM.DATA[header_location + 4]));
            tag1 = (byte)((ROM.DATA[header_location + 5]));
            tag2 = (byte)((ROM.DATA[header_location + 6]));

            holewarp_plane = (byte)((ROM.DATA[header_location + 7]) & 0x03);
            staircase1_plane = (byte)((ROM.DATA[header_location + 7]>>2) & 0x03);
            staircase2_plane = (byte)((ROM.DATA[header_location + 7]>>4) & 0x03);
            staircase3_plane = (byte)((ROM.DATA[header_location + 7]>>6) & 0x03);
            staircase4_plane = (byte)((ROM.DATA[header_location + 8]) & 0x03 );

            holewarp = (byte)((ROM.DATA[header_location + 9]));
            staircase1 = (byte)((ROM.DATA[header_location + 10]));
            staircase2 = (byte)((ROM.DATA[header_location + 11]));
            staircase3 = (byte)((ROM.DATA[header_location + 12]));
            staircase4 = (byte)((ROM.DATA[header_location + 13]));

        }


        public void drawSprites()
        {
            //sprites_name.name
            int sprite_address_snes = (09 << 16) +
            (ROM.DATA[Constants.room_sprites_pointers + (index * 2) + 1] << 8) +
            ROM.DATA[Constants.room_sprites_pointers + (index * 2)];
            int sprite_address = Addresses.snestopc(sprite_address_snes) + 1;




            using (Graphics g = Graphics.FromImage(room_bitmap))
            {
                while (true)
                {
                    byte b1 = ROM.DATA[sprite_address];
                    byte b2 = ROM.DATA[sprite_address + 1];
                    byte b3 = ROM.DATA[sprite_address + 2];

                    if (b1 == 0xFF) { break; }
                    //g.FillEllipse(Brushes.Fuchsia, new Rectangle(((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 16, 16));
                    //g.DrawString(sprites_name.name[b3*2], new Font("Arial", 10, FontStyle.Bold), Brushes.Blue, new Point(((b2 & 0x1F) * 16)-1, ((b1 & 0x1F) * 16)));

                    if (b3 == 0x00)
                    {
                        //9x10
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 4, 14,10);
                    }
                    else if (b3 == 0x01)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 4, 9, 10, false, false, 1, 4);
                        drawSpriteTile(g, ((b2 & 0x1F) * 16) + 8, ((b1 & 0x1F) * 16), 4, 9, 10, true, false, 1, 4);
                    }
                    else if (b3 == 0x02)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 0, 0, 10);
                    }
                    else if (b3 == 0x03)
                    {

                    }
                    else if (b3 == 0x04)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 12, 2);//TODO: Change palette
                    }
                    else if (b3 == 0x05)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 12, 2);//TODO: Change palette
                    }
                    else if (b3 == 0x06)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 12, 2);//TODO: Change palette
                    }
                    else if (b3 == 0x07)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 12, 2);//TODO: Change palette
                    }
                    else if (b3 == 0x08)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 0, 8, 6);
                        drawSpriteTile(g, ((b2 & 0x1F) * 16)+4, ((b1 & 0x1F) * 16)+6, 0, 8, 6,false,false,1,1);
                    }
                    else if (b3 == 0x09) //boss moldorm
                    {
                        //drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 0, 8, 4);
                        
                    }
                    else if (b3 == 0x0A)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 0, 8, 6);
                        drawSpriteTile(g, ((b2 & 0x1F) * 16) + 4, ((b1 & 0x1F) * 16) + 6, 0, 8, 6, false, false, 1, 1);
                    }
                    else if (b3 == 0x0B)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 10, 14, 10);
                    }
                    else if (b3 == 0x0C)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 0, 8, 8);
                        drawSpriteTile(g, ((b2 & 0x1F) * 16) + 4, ((b1 & 0x1F) * 16) + 6, 0, 8, 8, false, false, 1, 1);
                    }
                    else if (b3 == 0x0D)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 12, 6);
                    }
                    else if (b3 == 0x0E)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 8, 2, 10, false,false,3,2);
                    }
                    else if (b3 == 0x0F)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 8, 8, false, false, 2, 3);
                        drawSpriteTile(g, ((b2 & 0x1F) * 16)+16, ((b1 & 0x1F) * 16), 14, 8, 8, true, false, 1, 3);
                    }
                    else if (b3 == 0x10)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 12, 15, 8, false, false, 1, 1);
                    }
                    else if (b3 == 0x11)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 6, 0, 8, false, false, 2, 2); //feet
                        drawSpriteTile(g, ((b2 & 0x1F) * 16) - 8, ((b1 & 0x1F) * 16) + 8, 4, 2, 8, false, false, 2, 2); //body1
                        drawSpriteTile(g, ((b2 & 0x1F) * 16) + 8, ((b1 & 0x1F) * 16) + 8, 4, 2, 8, true, false, 2, 2); //body2
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16) + 16, 0, 0, 8, false, false, 2, 2); //head
                    }
                    else if (b3 == 0x12)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16)+8, 8, 10, 8);
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 6, 8, 8);
                    }
                    else if (b3 == 0x13)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 4, 6, 12);
                    }
                    else if (b3 == 0x14)
                    {
                        //TT Gate
                    }
                    else if (b3 == 0x15)
                    {
                        //Antifairy
                        drawSpriteTile(g, ((b2 & 0x1F) * 16)+2, ((b1 & 0x1F) * 16) + 8, 3, 14, 5, false, false, 1, 1);
                        drawSpriteTile(g, ((b2 & 0x1F) * 16) + 8, ((b1 & 0x1F) * 16)+2, 3, 14, 5, false, false, 1, 1);
                        drawSpriteTile(g, ((b2 & 0x1F) * 16) + 14, ((b1 & 0x1F) * 16)+8, 3, 14, 5, false, false, 1, 1);
                        drawSpriteTile(g, ((b2 & 0x1F) * 16)+8, ((b1 & 0x1F) * 16) + 14, 3, 14, 5, false, false, 1, 1);
                        drawSpriteTile(g, ((b2 & 0x1F) * 16)+8, ((b1 & 0x1F) * 16)+8, 1, 14, 5,false,false,1,1); //middle
                    }
                    else if (b3 == 0x16)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16)+8, 2, 10, 12);
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 0, 10, 12);
                    }
                    else if (b3 == 0x17) //bush hoarder
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 8, 14, 10);
                    }
                    else if (b3 == 0x18) //mini moldorm
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16)+13, ((b1 & 0x1F) * 16)+17, 13, 5, 8,false,false,1,1); //tail
                        drawSpriteTile(g, ((b2 & 0x1F) * 16)+5, ((b1 & 0x1F) * 16)+8, 2, 6, 8); //body
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 0, 6, 8); //head
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16)-4, 13, 4, 8,false,false,1,1); //eyes
                        drawSpriteTile(g, ((b2 & 0x1F) * 16)-4, ((b1 & 0x1F) * 16), 13, 4, 8,false,false,1,1); //eyes
                    }
                    else if (b3 == 0x19) //poe - ghost
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 6, 15, 12); //
                    }
                    else if (b3 == 0x1A) //smith
                    {
                        //drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 2, 4, 10,true); //smitty
                        //drawSpriteTile(g, ((b2 & 0x1F) * 16)+12, ((b1 & 0x1F) * 16) - 7, 0, 6, 10); //hammer
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 4, 6, 10);
                    }
                    else if (b3 == 0x1B) //arrow in wall
                    {
                        
                    }
                    else if (b3 == 0x1C) //Statue
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16)+8, 0, 12, 10); //TODO : FIND PALETTE
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16) , 2, 12, 10, false, false, 1, 1);
                        drawSpriteTile(g, ((b2 & 0x1F) * 16) + 8, ((b1 & 0x1F) * 16) , 2, 12, 10, true, false, 1, 1);
                    }
                    else if (b3 == 0x1D) //weathervane
                    {

                    }
                    else if (b3 == 0x1E) //crystal switch
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16) , 4, 14, 5);
                    }
                    else if (b3 == 0x1F) //sick kid
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16)-8, ((b1 & 0x1F) * 16)+8, 10, 0, 10);
                        drawSpriteTile(g, ((b2 & 0x1F) * 16)+16-8, ((b1 & 0x1F) * 16)+8, 10, 0, 10,true);
                        drawSpriteTile(g, ((b2 & 0x1F) * 16)-8, ((b1 & 0x1F) * 16)+16, 10, 0, 10, false,true,2,1);
                        drawSpriteTile(g, ((b2 & 0x1F) * 16)+16-8, ((b1 & 0x1F) * 16) + 16, 10, 0, 10, true, true, 2, 1);
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16)-4 , 14, 0, 10);
                    }
                    else if (b3 == 0x20) 
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 2, 8, 7);
                    }
                    else if (b3 == 0x21) //push switch
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16) - 14, ((b1 & 0x1F) * 16), 10, 12, 12, false, false, 2, 1); //TODO: find palette
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 10, 12, 12); //TODO: find palette
                    }
                    else if (b3 == 0x22) //rope
                    {
                      
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 8, 10, 5);
                    }
                    else if (b3 == 0x23) //red bari
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 2, 2, 4,false,false,1,2);
                        drawSpriteTile(g, ((b2 & 0x1F) * 16)+8, ((b1 & 0x1F) * 16), 2, 2, 4, true, false, 1,2 ); 
                    }
                    else if (b3 == 0x24) //blue bari
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 2, 2, 6, false, false, 1, 2);
                        drawSpriteTile(g, ((b2 & 0x1F) * 16) + 8, ((b1 & 0x1F) * 16), 2, 2, 6, true, false, 1, 2);
                    }
                    else if (b3 == 0x25) //red bari
                    {

                    }
                    else if (b3 == 0x26) //hardhat beetle
                    {
                        if (((b2 & 0x1F) & 0x01) == 0x00)
                        {
                            drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 4, 4, 8);
                            drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16) - 6, 0, 4, 8);
                        }
                        else
                        {
                            drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 4, 4, 10);
                            drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16) - 6, 0, 4, 10);
                        }
                        
                    }
                    else if (b3 == 0x27) //deadrock
                    {

                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 2, 14, 10);
                    }
                    else if (b3 == 0x28) //npcs
                    {

                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x29) //npcs
                    {

                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x2A) //npcs
                    {

                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x2B) //???
                    {

                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x2C) //npcs
                    {

                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x2D) //npcs
                    {

                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x2E) //npcs
                    {

                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x2F) //npcs
                    {

                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x30) //npcs
                    {

                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x31) //npcs
                    {

                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x32) //npcs
                    {

                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x33) //npcs
                    {

                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x34) //npcs
                    {

                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x35) //npcs
                    {

                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x36) //npcs
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x37) //npcs
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x38) //npcs
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x39) //npcs
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x3A) //npcs
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x3B) //npcs
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x3C) //npcs
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x3D) //npcs
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x3E) //npcs
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }
                    else if (b3 == 0x3F) //npcs
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 14, 6, 10);
                    }

                    else if (b3 == 0xAD)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16) + 8, 14, 10, 10);
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 12, 10, 10);
                    }
                    else if (b3 == 0x6F)
                    {
                        drawSpriteTile(g, ((b2 & 0x1F) * 16), ((b1 & 0x1F) * 16), 4, 8, 10);
                    }



                    sprite_address += 3;
                }
            }
        }

        public void drawSpriteTile(Graphics g, int x, int y, int srcx, int srcy, int pal,bool mx = false,bool my = false, int sx = 2, int sy = 2)
        {
            using (Bitmap b = new Bitmap(sx * 8, sy * 8))
            {
                using (Graphics gg = Graphics.FromImage(b))
                {
                    gg.DrawImage(GFX.blocksets[pal], new Rectangle(0, 0, sx * 8, sy * 8), (srcx * 8), (srcy * 8) + 320, sx * 8, sy * 8, GraphicsUnit.Pixel);
                }
                b.MakeTransparent(Color.Black);

                if (mx) //mirror x
                    b.RotateFlip(RotateFlipType.RotateNoneFlipX);
                if (my) //mirror y
                    b.RotateFlip(RotateFlipType.RotateNoneFlipY);

                g.DrawImage(b, x, y);
            }
        }


    }



}
