using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using ZeldaFullEditor.Properties;
using Microsoft.VisualBasic;
using System.IO.Compression;
using static ZeldaFullEditor.zscreamForm;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using WeifenLuo.WinFormsUI.Docking;

namespace ZeldaFullEditor
{
    public class SceneOW : Scene
    {
        public new RoomOW room;
        public Graphics graphicsOverlay;
        public Graphics graphicsMap;
        public Bitmap map_bitmap = new Bitmap(512, 512, PixelFormat.Format32bppRgb);
        public object selectedObject = null;
        public bool need_refresh_gfx = false;
        public SceneOW(zscreamForm f)
        {
            this.MouseDown += new MouseEventHandler(onMouseDown);
            this.MouseUp += new MouseEventHandler(onMouseUp);
            this.MouseMove += new MouseEventHandler(onMouseMove);
            this.MouseDoubleClick += new MouseEventHandler(onMouseDoubleClick);
            isDungeon = false;
            mainForm = f;
            graphicsOverlay = Graphics.FromImage(scene_bitmap_overlay);
            graphics = Graphics.FromImage(scene_bitmap);
        }

        public override void Clear()
        {
            graphics.Clear(this.BackColor);
        }

        public void ChangeRoom(RoomOW room)
        {
            this.room = room;
        }
        ushort selectedTile = 54;
        private void onMouseDown(object sender, MouseEventArgs e)
        {
            this.Focus();
            mainForm.activeScene = this;
            mainForm.mapPropertyGrid.SelectedObject = this;
            mouse_down = true;

            selectedObject = null;
            for (int i = 0; i < 0x4F; i++)
            {
                ExitOW o = OverworldGlobal.exits[i];
                o.selected = false;
                Rectangle bbox;
                if (o.mapId == room.index)
                {
                    int my = 0;
                    int mx = 0;
                    if (room.largeMap)
                    {
                        my = ((room.index) / 8);
                        mx = ((room.index) - (my * 8));
                        mx = mx << 9;
                        my = my << 9;
                        bbox = new Rectangle((o.playerX & 0x1FF) + (o.playerX & 0xFE00) - mx, (o.playerY & 0x1FF) + (o.playerY & 0xFE00) - my, 16, 16);
                    }
                    else
                    {
                        bbox = new Rectangle((o.playerX & 0x1FF), (o.playerY & 0x1FF), 16, 16);
                    }

                    if (e.X > bbox.X && e.Y > bbox.Y && e.X<bbox.X+16 && e.Y <bbox.Y+16)
                    {
                        o.selected = true;
                        selectedObject = o;
                    }
                }
            }
            

        }

        int prev_x;
        int prev_y;
        private void onMouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_down)
            {
                int mx = (e.X / 16);
                int my = (e.Y / 16);
                bool onNewTile = false;
                if (mx != prev_x )
                {
                    prev_x = mx;
                    onNewTile = true;
                }
                if (my != prev_y)
                {
                    prev_y = my;
                    onNewTile = true;
                }

                if (selectedObject != null)
                {
                    (selectedObject as ExitOW).playerX = (short)e.X;
                    (selectedObject as ExitOW).playerY = (short)e.Y;
                    need_refresh = true;
                }

                if (onNewTile)
                {

                }


            }
        }

        private void onMouseUp(object sender, MouseEventArgs e)
        {
            mouse_down = false;
        }

        private void onMouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        public void drawModifiedTile(int x, int y)
        {
            Bitmap tx = createTile16(GFX.tiles16[mapData16[(x), (y)]]);
            graphicsMap.DrawImage(tx, new Rectangle(x*16, y*16, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel);
            tx.Dispose();
        }

        public override void drawRoom() //Draw Overworld !
        {
            if (room == null)
            {
                return;
            }

            if (need_refresh_gfx)
            {
                room.GetSelectedMapGfx();
                DrawMap32Tiles();//draw everything back
                this.Image = scene_bitmap;
                need_refresh_gfx = false;
            }


            if (need_refresh)
            {
                //this.Image = scene_bitmap;
                graphics.DrawImage(map_bitmap, 0, 0);
                graphics.DrawImage(scene_bitmap_overlay, 0, 0);
                need_refresh = false;
            }


        }
        //
        //128,129
        //93-97 bgrs

        public void DrawMap32Tiles()
        {
            drawDecompressedTiles(room.index, 0, 0);
            drawExits();
            drawEntrances();
            drawHoles();
            drawItems();
            if (room.largeMap)
            {
                //GFX.begin_draw(scene_bitmap, 1024, 1024);
                drawSprites(1024);
            }
            else
            {
                //GFX.begin_draw(scene_bitmap);
                drawSprites(512);
            }
            
            //GFX.end_draw(scene_bitmap);

           
        }

        public ushort[,] mapData16 = new ushort[64, 64];
        public ushort[,] mapDataOverlay16 = new ushort[64, 64];
        public void drawDecompressedTiles(int idmap, int xPos, int yPos)
        {

            if (room.largeMap)
            {
                int tpos = idmap * 256;
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        mapData16[(x * 2), (y * 2)] = Compression.t32Unique[Compression.t32[tpos]].tile0;
                        mapData16[(x * 2) + 1, (y * 2)] = Compression.t32Unique[Compression.t32[tpos]].tile1;
                        mapData16[(x * 2), (y * 2) + 1] = Compression.t32Unique[Compression.t32[tpos]].tile2;
                        mapData16[(x * 2) + 1, (y * 2) + 1] = Compression.t32Unique[Compression.t32[tpos]].tile3;
                        tpos++;
                    }
                }
                tpos = (idmap+1) * 256;
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 16; x < 32; x++)
                    {
                        mapData16[(x * 2), (y * 2)] = Compression.t32Unique[Compression.t32[tpos]].tile0;
                        mapData16[(x * 2) + 1, (y * 2)] = Compression.t32Unique[Compression.t32[tpos]].tile1;
                        mapData16[(x * 2), (y * 2) + 1] = Compression.t32Unique[Compression.t32[tpos]].tile2;
                        mapData16[(x * 2) + 1, (y * 2) + 1] = Compression.t32Unique[Compression.t32[tpos]].tile3;
                        tpos++;
                    }
                }
                tpos = (idmap + 8) * 256;
                for (int y = 16; y < 32; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        mapData16[(x * 2), (y * 2)] = Compression.t32Unique[Compression.t32[tpos]].tile0;
                        mapData16[(x * 2) + 1, (y * 2)] = Compression.t32Unique[Compression.t32[tpos]].tile1;
                        mapData16[(x * 2), (y * 2) + 1] = Compression.t32Unique[Compression.t32[tpos]].tile2;
                        mapData16[(x * 2) + 1, (y * 2) + 1] = Compression.t32Unique[Compression.t32[tpos]].tile3;
                        tpos++;
                    }
                }
                tpos = (idmap + 9) * 256;
                for (int y = 16; y < 32; y++)
                {
                    for (int x = 16; x < 32; x++)
                    {
                        mapData16[(x * 2), (y * 2)] = Compression.t32Unique[Compression.t32[tpos]].tile0;
                        mapData16[(x * 2) + 1, (y * 2)] = Compression.t32Unique[Compression.t32[tpos]].tile1;
                        mapData16[(x * 2), (y * 2) + 1] = Compression.t32Unique[Compression.t32[tpos]].tile2;
                        mapData16[(x * 2) + 1, (y * 2) + 1] =Compression.t32Unique[Compression.t32[tpos]].tile3;
                        tpos++;
                    }
                }
            }
            else
            {
                int tpos = idmap * 256;
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        mapData16[(x * 2), (y * 2)] = Compression.t32Unique[Compression.t32[tpos]].tile0;
                        mapData16[(x * 2) + 1, (y * 2)] = Compression.t32Unique[Compression.t32[tpos]].tile1;
                        mapData16[(x * 2), (y * 2) + 1] = Compression.t32Unique[Compression.t32[tpos]].tile2;
                        mapData16[(x * 2) + 1, (y * 2) + 1] = Compression.t32Unique[Compression.t32[tpos]].tile3;
                        tpos++;
                    }
                }
                
            }
            drawOverlays();
            drawMap();

        }

        public void createTileset()
        {
            Bitmap b = new Bitmap(16, 16);
            Bitmap tileset = new Bitmap(1024,1024);
            Graphics g = Graphics.FromImage(tileset);
            int x = 0;
            int y = 0;
            for (int i = 0;i<3758;i++)
            {
                b = createTile16(GFX.tiles16[i]);
                g.DrawImage(b, x * 16, y * 16);
                x++;
                if (x >= 64)
                {
                    x = 0;
                    y++;
                }
            }
            tileset.Save("tileset.png");
        }

        public void createTilesetType()
        {

            Bitmap tileset = GFX.singletobmp(GFX.blocksetData, 0, 2, false);
            tileset.Save("tilesettype.png");
        }

        public void createTmx()
        {

            createTileset();
            int sx = 32;
            int sy = 32;
            if (room.largeMap)
            {
                sx = 64;
                sy = 64;
            }
            string s = "";
            s += "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n";
            s += "<map version=\"1.0\" tiledversion =\"1.1.3\" orientation =\"orthogonal\" renderorder =\"right - down\" width =\""+sx+"\" height =\""+sy+"\" tilewidth =\"16\" tileheight =\"16\" infinite =\"0\" nextobjectid =\"1\">\r\n";
            s += " <tileset firstgid=\"1\" source=\"Map.tsx\"/>\r\n";
            s += " <layer name=\"Map\" width=\""+sx+"\" height=\""+sy+"\">\r\n";
            s += "  <data encoding=\"csv\">\r\n";
            for (int y = 0;y<sy;y++)
            {
                for (int x = 0; x < sx; x++)
                {
                    s += (mapData16[x, y]+1).ToString() + ",";
                }
                s += "\r\n";
            }
            s = s.Remove(s.Length - 3, 1);
            s += "\r\n";
            s += "</data>\r\n";
            s += " </layer>\r\n";
            s += "<layer name=\"Overlay\" width=\""+sx+"\" height =\""+sy+"\">\r\n";
            s += "<data encoding=\"csv\">\r\n";
            for (int y = 0; y < sy; y++)
            {
                for (int x = 0; x < sx; x++)
                {
                    if (mapDataOverlay16[x, y] != 5000)
                    {
                        s += (mapDataOverlay16[x, y] + 1).ToString() + ",";
                    }
                    else
                    {
                        s += "0,";
                    }
                }
                s += "\r\n";
            }
            s = s.Remove(s.Length - 3, 1);
            s += "\r\n";
            s += "</data>\r\n";
            s += " </layer>\r\n";

            s += "</map>\r\n";
            SaveFileDialog of = new SaveFileDialog();
            of.DefaultExt = ".tmx";
            of.Filter = "Tiled Map .tmx|*.tmx";
            if (of.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(of.FileName, s);
            }
            s = "";

            s += "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n";
            s += "<tileset name=\"Map\" tilewidth=\"16\" tileheight=\"16\" tilecount=\"4096\" columns=\"64\">\r\n";
             s += "<image source=\"tileset.png\" width=\"1024\" height=\"1024\"/>\r\n";
            s += "</tileset>\r\n";
            File.WriteAllText("Map.tsx", s);

            createTilesetType();
            s = "";

            s += "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n";
            s += "<tileset name=\"Map\" tilewidth=\"8\" tileheight=\"8\" tilecount=\"512\" columns=\"64\">\r\n";
            s += "<image source=\"tilesettype.png\" width=\"128\" height=\"256\"/>\r\n";
            for (int i = 0; i < 512; i++)
            {
                s += "<tile id=\""+i+"\" type=\""+ ROM.DATA[Constants.overworldTilesType+i] + "\"/>";
            }


            s += "</tileset>\r\n";
            File.WriteAllText("TilesTypes.tsx", s);
        }

        ushort[,] mapload = new ushort[64,64];
        public void loadTmx()
        {

            //createTileset();
            int sx = 32;
            int sy = 32;
            if (room.largeMap)
            {
                sx = 64;
                sy = 64;
            }
            string[] s = new string[0];
            OpenFileDialog of = new OpenFileDialog();
            of.DefaultExt = ".tmx";
            of.Filter = "Tiled Map .tmx|*.tmx";
            if (of.ShowDialog() == DialogResult.OK)
            {
                s = File.ReadAllLines(of.FileName);
            }
            int line = 0;
            for(int i = 0;i<20;i++)
            {
                if (s[i].Contains("<data encoding=\"csv\">"))
                {
                    line = i+1;
                }
            }
            
            for (int y = 0; y < sy; y++)
            {
                string[] ss = s[line + y].Split(',');
                for (int x = 0; x < sx; x++)
                {
                    mapload[x, y] = (ushort)(Convert.ToInt16(ss[x])-1);
                }
            }
            Compression.AllMapTilesFromMap(room.index,mapload,room.largeMap);
            Compression.createMap32TilesFrom16();
            //Compression.Save32Tiles();
            DrawMap32Tiles();


        }

        //TODO IN ENEMIZER : FOR RETRO MODE REMOVE KEY DROP AND KEY POTS AND PUT HALF OF THEM IN CHESTS


        public void drawMap()
        {
            if (room.index == 159) { room.largeMap = false; }
            Bitmap bx = new Bitmap(32, 32);
            Graphics gx = Graphics.FromImage(bx);
            int sx = 16;
            int sy = 16;
            if (room.largeMap)
            {
                sx = 32;
                sy = 32;
            }
            gx.Clear(Color.Red);
            for (int y = 0; y < sx; y++)
            {
                for (int x = 0; x < sy; x++)
                {
                    if (mapData16[(x * 2), (y * 2)] >= GFX.tiles16.Count)
                    {
                        continue;
                    }
                    Bitmap tx = createTile16(GFX.tiles16[mapData16[(x*2),(y*2)]]);
                    gx.DrawImage(tx, new Rectangle(0, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel);
                    tx = createTile16(GFX.tiles16[mapData16[(x*2) + 1, (y*2)]]);
                    gx.DrawImage(tx, new Rectangle(16, 0, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel);
                    tx = createTile16(GFX.tiles16[mapData16[(x * 2), (y * 2) + 1]]);
                    gx.DrawImage(tx, new Rectangle(0, 16, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel);
                    tx = createTile16(GFX.tiles16[mapData16[(x * 2) + 1, (y * 2) + 1]]);
                    gx.DrawImage(tx, new Rectangle(16, 16, 16, 16), 0, 0, 16, 16, GraphicsUnit.Pixel);
                    tx.Dispose();
                    graphicsMap.DrawImage(bx, ((x * 32)), ((y * 32)));

                }
            }
            bx.Dispose();
            gx.Dispose();


            
        }

        //TODO : Change that to use bitlock instead of drawimage
        public Bitmap createTile16(Tile16 t16)
        {

            Bitmap t16bitmap = new Bitmap(16, 16);
            GFX.begin_draw(t16bitmap, 16, 16);
            drawTile16(0, t16);
            drawTile16(1, t16);
            drawTile16(2, t16);
            drawTile16(3, t16);
            GFX.end_draw(t16bitmap);
            return t16bitmap;
        }


        public void drawTile16(byte tid, Tile16 t16)
        {

            TileInfo t = t16.tile0;
            if (tid == 0)
            {
                t = t16.tile0;
                draw_tile(t, 0, 0, t.palette);
            }
            if (tid == 1)
            {
                t = t16.tile1;
                draw_tile(t, 8, 0, t.palette);
            }
            if (tid == 2)
            {
                t = t16.tile2;
                draw_tile(t, 0, 8, t.palette);
            }
            if (tid == 3)
            {
                t = t16.tile3;
                draw_tile(t, 8, 8, t.palette);
            }

        }

        public void draw_tile(TileInfo t, int x, int y, int pal)
        {
            int tid = t.id;

            int ty = (tid / 16);
            int tx = tid - (ty * 16);
            int mx = 0;
            int my = 0;


            if (t.h == true)
            {
                mx = 8;
            }

            for (int xx = 0; xx < 8; xx++)
            {
                if (mx > 0)
                {
                    mx--;
                }
                if (t.v == true)
                {
                    my = 8;
                }
                for (int yy = 0; yy < 8; yy++)
                {
                    if (my > 0)
                    {
                        my--;
                    }

                    int x_dest = (x + (xx)) * 4;
                    int y_dest = (((y) + (yy)) * 16) * 4;
                    int dest = x_dest + y_dest;

                    int x_src = ((tx * 8) + mx + (xx));
                    if (t.h)
                    {
                        x_src = ((tx * 8) + mx);
                    }
                    int y_src = (((ty * 8) + my + (yy)) * 128);
                    if (t.v)
                    {
                        y_src = (((ty * 8) + my) * 128);
                    }

                    int src = x_src + y_src;
                    int pp = 0;
                    int p = pal;
                    if (p >= 2)
                    {
                        p -= 2;
                    }
                    if (dest < (16 * 16 * 4))
                    {

                        unsafe
                        {
                            GFX.currentData[dest] = (GFX.loadedPalettes[GFX.singledata[(src)] + pp, p].B);
                            GFX.currentData[dest + 1] = (GFX.loadedPalettes[GFX.singledata[(src)] + pp, p].G);
                            GFX.currentData[dest + 2] = (GFX.loadedPalettes[GFX.singledata[(src)] + pp, p].R);
                            GFX.currentData[dest + 3] = 255;
                        }
                    }
                }
            }
        }


        List<Sprite> sprites = new List<Sprite>();
        public void addSprites(int address)
        {

            //09 bank ? Need to check if HM change that
            int sprite_address_snes = (09 << 16) +
            (ROM.DATA[address + (room.index * 2) + 1] << 8) +
            ROM.DATA[address + (room.index * 2)];
            int sprite_address = Addresses.snestopc(sprite_address_snes);
            
            while (true)
            {
                byte b1 = ROM.DATA[sprite_address];
                byte b2 = ROM.DATA[sprite_address + 1];
                byte b3 = ROM.DATA[sprite_address + 2];

                if (b1 == 0xFF) { break; }

                sprites.Add(new Sprite(null, b3, (byte)(b2 & 0x3F), (byte)(b1 & 0x3F), Sprites_Names.name[b3],0,0,0));
                sprite_address += 3;
            }
        }

        public void drawSprites(int sizeMap)
        {
            Brush bgrBrush = Brushes.Fuchsia;
            Pen contourPen = Pens.Black;
            foreach (Sprite spr in sprites)
            {
                //spr.sizeMap = sizeMap;
                //spr.Draw();
                graphicsOverlay.FillRectangle(bgrBrush, new Rectangle(spr.x * 16, spr.y * 16, 16, 16));
                graphicsOverlay.DrawRectangle(contourPen, new Rectangle(spr.x * 16, spr.y * 16, 16, 16));
                DrawText(graphicsOverlay,spr.name, new Point((spr.x * 16) - 1, (spr.y * 16) + 1));

            }
        }

        public void drawExits()
        {
            
            for (int i = 0;i<0x4F;i++)
            {
                ExitOW e = OverworldGlobal.exits[i];
                Font f2 = new Font("Courier New", 9,FontStyle.Bold);
                Brush bgrBrush = Brushes.WhiteSmoke;
                Brush fontBrush = Brushes.DarkSlateBlue;
                Pen contourPen = Pens.Black;
                if (e.selected)
                {
                    bgrBrush = Brushes.Black;
                    fontBrush = Brushes.LimeGreen;
                    contourPen = Pens.LimeGreen;
                }


                if (e.mapId == room.index)
                {
                    int my = 0;
                    int mx = 0;
                    if (room.largeMap)
                    {
                        my = ((room.index) / 8);
                        mx = ((room.index) - (my * 8));
                        mx = mx << 9;
                        my = my << 9;
                       // Console.WriteLine(mx + "," + my);
                        
                        graphicsOverlay.FillRectangle(bgrBrush, new Rectangle((e.playerX & 0x1FF) + (e.playerX & 0xFE00) - mx, (e.playerY & 0x1FF) + (e.playerY & 0xFE00) - my, 16, 16));
                        graphicsOverlay.DrawRectangle(contourPen, new Rectangle((e.playerX & 0x1FF) + (e.playerX & 0xFE00) - mx, (e.playerY & 0x1FF) + (e.playerY & 0xFE00) - my, 16, 16));
                        graphicsOverlay.DrawString(i.ToString("X2"), f2, fontBrush, new Point((e.playerX & 0x1FF)-1 + (e.playerX & 0xFE00) - mx, (e.playerY & 0x1FF) + (e.playerY & 0xFE00) - my+1));

                    }
                    else
                    {
                        graphicsOverlay.FillRectangle(bgrBrush, new Rectangle((e.playerX & 0x1FF), (e.playerY & 0x1FF), 16, 16));
                        graphicsOverlay.DrawRectangle(contourPen, new Rectangle((e.playerX & 0x1FF), (e.playerY & 0x1FF), 16, 16));
                        graphicsOverlay.DrawString(i.ToString("X2"), f2, fontBrush, new Point((e.playerX & 0x1FF)-1, (e.playerY & 0x1FF)+1));
                    }
                    
                }

            }
        }

        public void drawItems()
        {
            Brush bgrBrush = Brushes.Red;
            Brush fontBrush = Brushes.Aqua;
            Pen contourPen = Pens.Black;
            for (int i = 0; i < room.items.Count; i++)
            {
                byte nid = room.items[i].id;
                if ((room.items[i].id & 0x80) == 0x80)
                {
                    nid = (byte)(((room.items[i].id - 0x80) / 2) + 0x17);
                }
                graphicsOverlay.FillRectangle(bgrBrush, new Rectangle(room.items[i].x * 16, room.items[i].y * 16, 16, 16));
                graphicsOverlay.DrawRectangle(contourPen, new Rectangle(room.items[i].x * 16, room.items[i].y * 16, 16, 16));
                DrawText(graphicsOverlay, room.items[i].id.ToString("X2") + "-" + PotItems_Name.name[nid], new Point((room.items[i].x * 16) - 1, (room.items[i].y * 16)+1));
            }
        }

        public void drawEntrances()
        {

            for (int i = 0; i < 0x81; i++)
            {
                EntranceOW e = OverworldGlobal.entrances[i];
                Brush bgrBrush = Brushes.Yellow;
                Brush fontBrush = Brushes.Aqua;
                Pen contourPen = Pens.Black;
                if (e.selected)
                {
                    bgrBrush = Brushes.Black;
                    fontBrush = Brushes.LimeGreen;
                    contourPen = Pens.LimeGreen;
                }

                if (e.mapId == room.index)
                {
                    int p = e.mapPos >> 1;
                    int x = p % 64;
                    int y = p >> 6;
                    graphicsOverlay.FillRectangle(bgrBrush, new Rectangle(x*16, y*16, 16, 16));
                    graphicsOverlay.DrawRectangle(contourPen, new Rectangle(x * 16, y * 16, 16, 16));
                    DrawText(graphicsOverlay, i.ToString("X2") + "-" + ROMStructure.roomsNames[mainForm.entrances[e.entranceId].Room], new Point((x * 16) - 1, (y * 16) + 1));
                }

            }
        }

        public void drawHoles()
        {

            for (int i = 0; i < 0x13; i++)
            {
                EntranceOW e = OverworldGlobal.Holes[i];
                Brush bgrBrush = Brushes.Black;
                Brush fontBrush = Brushes.Aqua;
                Pen contourPen = Pens.Black;
                if (e.selected)
                {
                    bgrBrush = Brushes.White;
                    fontBrush = Brushes.LimeGreen;
                    contourPen = Pens.LimeGreen;
                }
                if (e.mapId == room.index)
                {
                    int p = (e.mapPos+0x400) >> 1;
                    int x = p % 64;
                    int y = p >> 6;
                    graphicsOverlay.FillRectangle(bgrBrush, new Rectangle(x * 16, y * 16, 16, 16));
                    graphicsOverlay.DrawRectangle(contourPen, new Rectangle(x * 16, y * 16, 16, 16));
                    DrawText(graphicsOverlay, i.ToString("X2") + "-" + ROMStructure.roomsNames[mainForm.entrances[e.entranceId].Room], new Point((x * 16) - 1, (y * 16) + 1));
                }

            }
        }

        public void DrawText(Graphics g,string text,Point position)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            GraphicsPath gpath = new GraphicsPath();
            gpath.AddString(text, new FontFamily("Courier New"), 1, 12, position, StringFormat.GenericDefault);
            Pen pen = new Pen(Color.FromArgb(30, 30, 30), 2);
            g.DrawPath(pen, gpath);
            SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
                g.FillPath(brush, gpath);
            g.SmoothingMode = SmoothingMode.None;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
        }

        public void drawOverlays()
        {
            //overlayPointers
            int addr = (Constants.overlayPointersBank << 16) +
                (ROM.DATA[Constants.overlayPointers + (room.index * 2) + 1] << 8) +
                ROM.DATA[Constants.overlayPointers + (room.index * 2)];
            addr = Addresses.snestopc(addr);

            int a = 0;
            int x = 0;
            int sta = 0;
            //16-bit mode : 
            //A9 (LDA #$)
            //A2 (LDX #$)
            //8D (STA $xxxx)
            //9D (STA $xxxx ,x)
            //8F (STA $xxxxxx)
            //1A (INC A)
            //4C (JMP)
            //60 (END)

            for(int i = 0;i<64;i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    mapDataOverlay16[i, j] = 5000;
                }
            }


            byte b = 0;
            while(b != 0x60)
            {
                b = ROM.DATA[addr];
                if (b == 0xA9) //LDA #$xxxx (Increase addr+3)
                {
                    a = (ROM.DATA[addr + 2] << 8) +
                    ROM.DATA[addr + 1];
                    addr += 3;
                    continue;
                }
                else if (b == 0xA2) //LDX #$xxxx (Increase addr+3)
                {
                    x = (ROM.DATA[addr + 2] << 8) +
                    ROM.DATA[addr + 1];
                    addr += 3;
                    continue;
                }
                else if (b == 0x8D) //STA $xxxx (Increase addr+3)
                {
                    sta = (ROM.DATA[addr + 2] << 8) +
                    ROM.DATA[addr + 1];

                    //draw tile at sta position
                    Console.WriteLine("Draw Tile" + a + " at " + sta.ToString("X4"));
                    //64
                    sta = sta  & 0x1FFF;
                    int yp = ((sta / 2) / 0x40);
                    int xp = (sta / 2) - (yp * 0x40);
                    mapDataOverlay16[xp, yp] = (ushort)a;

                    addr += 3;
                    continue;
                }
                else if (b == 0x9D) //STA $xxxx, x (Increase addr+3)
                {
                    sta = (ROM.DATA[addr + 2] << 8) +
                    ROM.DATA[addr + 1];
                    //draw tile at sta,X position
                    Console.WriteLine("Draw Tile" +a+" at " + (sta+x).ToString("X4"));

                    int stax = (sta & 0x1FFF)+x;
                    int yp = ((stax / 2) / 0x40);
                    int xp = (stax / 2) - (yp * 0x40);
                    mapDataOverlay16[xp, yp] = (ushort)a;
                    
                    addr += 3;
                    continue;
                }
                else if (b == 0x8F) //STA $xxxxxx (Increase addr+4)
                {
                    sta = (ROM.DATA[addr + 2] << 8) +
                    ROM.DATA[addr + 1];
                    //draw tile at sta,X position
                    Console.WriteLine("Draw Tile" + a + " at " + (sta + x).ToString("X4"));

                    int stax = (sta & 0x1FFF) + x;
                    int yp = ((stax / 2) / 0x40);
                    int xp = (stax / 2) - (yp * 0x40);
                    mapDataOverlay16[xp, yp] = (ushort)a;

                    addr += 4;
                    continue;
                }
                else if (b == 0x1A) //INC A (Increase addr+1)
                {
                    a += 1;
                    addr += 1;
                    continue;
                }
                else if (b == 0x4C) //JMP $xxxx (move addr to the new address)
                {
                    addr = (Constants.overlayPointersBank << 16) +
                    (ROM.DATA[addr + 2] << 8) +
                    ROM.DATA[addr + 1];
                    addr = Addresses.snestopc(addr);
                    continue;
                }
                else if (b == 0x60) //RTS
                {
                    break; //just to be sure
                }
            }


        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }

    public class DOWScene : DockContent
    {
        public SceneOW scene;
        zscreamForm mainform;
        public string nameText = "";
        public bool namedChanged = false;
        
        public DOWScene(zscreamForm mainform, string nameText)
        {
            scene = new SceneOW(mainform);


            this.nameText = nameText;
            this.mainform = mainform;
            GotFocus += DScene_GotFocus;

            FormClosing += DScene_FormClosing;
        }

        private void DScene_FormClosing(object sender, FormClosingEventArgs e)
        {


            if (scene.room.has_changed == true)
            {
                //prompt save message
                //e.Cancel = true;
                DialogResult dialogResult = MessageBox.Show("Map has changed. Do you want to save changes?", "Save", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes) //save
                {
                    scene.room.has_changed = false;
                    mainform.all_rooms[scene.room.index] = (Room)scene.room.Clone();

                    mainform.maps.Remove(this);
                    mainform.loadRoomList(0);
                    mainform.mapPicturebox.Refresh();
                }
                else if (dialogResult == DialogResult.No)
                {
                    mainform.maps.Remove(this);
                    mainform.loadRoomList(0);
                    mainform.mapPicturebox.Refresh();
                }
                else
                {
                    e.Cancel = true;
                }

            }
            else
            {
                mainform.maps.Remove(this);
                mainform.loadRoomList(0);
                mainform.mapPicturebox.Refresh();
            }
        }
        bool init = false;
        private void DScene_GotFocus(object sender, EventArgs e)
        {
            if (init == false)
            {
                if (scene.room.index != 0x80)
                {
                    if (scene.room.index <= 150)
                    {
                        if (ROM.DATA[Constants.overworldMapSize + (scene.room.index & 0x3F)] != 0)
                        {
                            scene.room.largeMap = true;
                            scene.map_bitmap = new Bitmap(1024, 1024, PixelFormat.Format32bppRgb);
                            scene.scene_bitmap = new Bitmap(1024, 1024, PixelFormat.Format32bppRgb);
                            this.AutoScrollMinSize = new System.Drawing.Size(1024, 1024);
                        }
                    }
                }

                

                scene.graphicsMap = Graphics.FromImage(scene.map_bitmap);
                scene.graphics = Graphics.FromImage(scene.scene_bitmap);
                if (scene.room.index < 0x40)
                {
                    scene.addSprites(Constants.overworldSpritesLW);
                }
                else
                {
                    scene.addSprites(Constants.overworldSpritesDW);
                }

                this.AutoScroll = true;
                mainform.activeScene = this.scene;
                mainform.mapPropertyGrid.SelectedObject = scene.room;
                scene.room.updateOverworldPalettes();
                
                scene.room.palette = (byte)(ROM.DATA[Constants.overworldMapPalette + scene.room.index] << 2);
                scene.room.blockset = ROM.DATA[Constants.mapGfx + scene.room.index];
                scene.room.sprite_palette = (byte)(ROM.DATA[Constants.overworldSpritePalette + scene.room.index]);
                scene.need_refresh = true;
                scene.need_refresh_gfx = true;
                init = true;
            }
            


        }
    }


}
