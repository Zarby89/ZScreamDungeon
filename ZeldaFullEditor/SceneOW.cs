﻿using System;
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
using static ZeldaFullEditor.DungeonMain;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using ZeldaFullEditor.OWSceneModes;
using ZeldaFullEditor.Gui;

namespace ZeldaFullEditor
{
    public class SceneOW : Scene
    {

        //public IntPtr allgfx8array = Marshal.AllocHGlobal(32768);

        //  int selectedIndex = 0;
        public int selectedMap = 0;
        //must load all current map gfx
        public Overworld ow;
        public bool initialized = false;
        public bool needRedraw = true;
        public ushort[] selectedTile = new ushort[1] { 0 };
        public int selectedTileSizeX = 1;
        public int globalmouseTileDownX = 0;
        public int globalmouseTileDownY = 0;
        public int mouseX_Real = 0;
        public int mouseY_Real = 0;
        public int lastTileHoverX = 0;
        public int lastTileHoverY = 0;
        public int mapHover = 0;
        public bool selecting = false;
        public IntPtr overlaygfxPtr = Marshal.AllocHGlobal(1024 * 1024);
        public IntPtr temptilesgfxPtr = Marshal.AllocHGlobal(1024 * 1024);
        public Bitmap tilesgfxBitmap;
        public Bitmap tileBitmap;
        public IntPtr tileBitmapPtr;
        public bool snapToGrid = true;
        public TileMode tilemode;
        public ExitMode exitmode;
        public DoorMode doorMode;
        public EntranceMode entranceMode;
        public SpriteMode spriteMode;
        public ItemMode itemMode;
        public Sprite selectedFormSprite;
        public TransportMode transportMode;
        public bool showEntrances = true;
        public bool showExits = true;
        public bool showFlute = true;
        public bool showItems = true;
        public bool showSprites = true;
        public bool hideText = false;
        public OverworldEditor owForm;
        public bool entrancePreview = false;
        //int selectedMode = 0;
        public SceneOW(OverworldEditor f,Overworld ow, DungeonMain mform)
        {
            owForm = f;
            mainForm = mform;
            this.ow = ow;
            //graphics = Graphics.FromImage(scene_bitmap);
            //this.Image = new Bitmap(4096, 4096);
            this.MouseUp += new MouseEventHandler(onMouseUp);
            this.MouseMove += new MouseEventHandler(onMouseMove);
            this.MouseDoubleClick += new MouseEventHandler(onMouseDoubleClick);
            this.MouseWheel += SceneOW_MouseWheel;
            tilesgfxBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, temptilesgfxPtr);
            tilemode = new TileMode(this);
            exitmode = new ExitMode(this);
            doorMode = new DoorMode(this);
            entranceMode = new EntranceMode(this);
            selectedMode = ObjectMode.Tile;
            itemMode = new ItemMode(this);
            spriteMode = new SpriteMode(this);
            transportMode = new TransportMode(this);
            //this.Refresh();
        }

        public void CreateScene()
        {
            //tileBitmapPtr = ow.allmaps[0].blockset16;
           // tileBitmap = new Bitmap(128, 8192, 128, PixelFormat.Format8bppIndexed, tileBitmapPtr);
        }

        private void SceneOW_MouseWheel(object sender, MouseEventArgs e)
        {

        }

        public void updateMapGfx()
        {
            if (selectedMap + ow.worldOffset <= 159)
            {
                if (ow.allmaps[selectedMap + ow.worldOffset].needRefresh)
                {
                    ow.allmaps[selectedMap + ow.worldOffset].BuildMap();
                    ow.allmaps[selectedMap + ow.worldOffset].needRefresh = false;
                }
                owForm.mapGroupbox.Text = "Selected Map - " + ow.allmaps[selectedMap + ow.worldOffset].parent.ToString() + " Properties : ";

                owForm.propertiesChangedFromForm = true;
                if (ow.worldOffset >= 64)
                {

                    owForm.gfxTextbox.Text = ow.allmaps[ow.allmaps[selectedMap + ow.worldOffset].parent].gfx.ToString();
                    owForm.sprgfxTextbox.Text = ow.allmaps[ow.allmaps[selectedMap + ow.worldOffset].parent].sprgfx[0].ToString();
                    owForm.paletteTextbox.Text = ow.allmaps[ow.allmaps[selectedMap + ow.worldOffset].parent].palette.ToString();
                    owForm.sprpaletteTextbox.Text = ow.allmaps[ow.allmaps[selectedMap + ow.worldOffset].parent].sprpalette[0].ToString();
                }
                else
                {
                    owForm.gfxTextbox.Text = ow.allmaps[ow.allmaps[selectedMap].parent].gfx.ToString();
                    owForm.sprgfxTextbox.Text = ow.allmaps[ow.allmaps[selectedMap].parent].sprgfx[ow.gameState].ToString();
                    owForm.paletteTextbox.Text = ow.allmaps[ow.allmaps[selectedMap].parent].palette.ToString();
                    owForm.sprpaletteTextbox.Text = ow.allmaps[ow.allmaps[selectedMap].parent].sprpalette[ow.gameState].ToString();
                }
                owForm.propertiesChangedFromForm = false;

                owForm.tilePictureBox.Refresh();
            }
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            int tileX = (e.X / 16);
            int tileY = (e.Y / 16);
            int superX = (tileX / 32);
            int superY = (tileY / 32);
            int mapId = (superY * 8) + superX;
            globalmouseTileDownX = tileX;
            globalmouseTileDownY = tileY;
            selectedMap = mapId;
            updateMapGfx();

            if (selectedMode == ObjectMode.Tile)
            {
                tilemode.OnMouseDown(e);
            }
            else if (selectedMode == ObjectMode.Exits)
            {
                exitmode.onMouseDown(e);
            }
            else if (selectedMode == ObjectMode.OWDoor)
            {
                doorMode.OnMouseDown(e);
            }
            else if (selectedMode == ObjectMode.Entrances)
            {
                entranceMode.onMouseDown(e);
            }
            else if (selectedMode == ObjectMode.Itemmode)
            {
                itemMode.onMouseDown(e);
            }
            else if (selectedMode == ObjectMode.Spritemode)
            {
                spriteMode.onMouseDown(e);
            }
            else if (selectedMode == ObjectMode.Flute)
            {
                transportMode.onMouseDown(e);
            }
            Invalidate(new Rectangle(owForm.splitContainer1.Panel2.HorizontalScroll.Value, owForm.splitContainer1.Panel2.VerticalScroll.Value, owForm.splitContainer1.Panel2.Width, owForm.splitContainer1.Panel2.Height));
            base.OnMouseDown(e);
        }

        private unsafe void onMouseUp(object sender, MouseEventArgs e)
        {
            owForm.objCombobox.Items.Clear();
            owForm.objCombobox.SelectedIndexChanged -= ObjCombobox_SelectedIndexChangedSprite;
            owForm.objCombobox.SelectedIndexChanged -= ObjCombobox_SelectedIndexChangedItem;
            string text = "Selected Object - ";
            if (selectedMode == ObjectMode.Tile)
            {
                tilemode.OnMouseUp(e);
            }
            else if (selectedMode == ObjectMode.Exits)
            {
                exitmode.onMouseUp(e);
                text += "Exit";
                if (exitmode.lastselectedExit != null)
                {
                    owForm.objinfoLabel.Text = "Map ID : " + exitmode.lastselectedExit.mapId + "\n" +
                        "X : " + exitmode.lastselectedExit.playerX + "\n" +
                        "Y : " + exitmode.lastselectedExit.playerY;

                }
            }
            else if (selectedMode == ObjectMode.OWDoor)
            {
                //doorMode.onMouseUp(e);
            }
            else if (selectedMode == ObjectMode.Entrances)
            {
                entranceMode.onMouseUp(e);
                text += "Entrance";
                if (entranceMode.lastselectedEntrance != null)
                {
                    owForm.objinfoLabel.Text = "Entrance ID : " + entranceMode.lastselectedEntrance.entranceId + "\n" +

                        "X : " + entranceMode.lastselectedEntrance.x + "\n" +
                        "Y : " + entranceMode.lastselectedEntrance.y;
                }
            }
            else if (selectedMode == ObjectMode.Itemmode)
            {
                itemMode.onMouseUp(e);
                text += "Item";
                if (itemMode.lastselectedItem != null)
                {
                    owForm.objinfoLabel.Text = "ID : 0x" + itemMode.lastselectedItem.id.ToString("X2") + "\n" +

                        "X : " + itemMode.lastselectedItem.x + "\n" +
                        "Y : " + itemMode.lastselectedItem.y;
                    owForm.objCombobox.Items.AddRange(ItemsNames.name);
                    if ((itemMode.lastselectedItem.id & 0x80) == 0x80)
                    {
                        owForm.objCombobox.SelectedIndex = (23 + (itemMode.lastselectedItem.id / 2));
                    }
                    else
                    {
                        owForm.objCombobox.SelectedIndex = itemMode.lastselectedItem.id;
                    }

                    owForm.objCombobox.SelectedIndexChanged += ObjCombobox_SelectedIndexChangedItem;
                }
            }
            else if (selectedMode == ObjectMode.Spritemode)
            {
                spriteMode.onMouseUp(e);
                text += "Sprite";
                if (spriteMode.lastselectedSprite != null)
                {
                    owForm.objinfoLabel.Text = "ID : 0x" + spriteMode.lastselectedSprite.id.ToString("X2") + "\n" +

                        "X : " + spriteMode.lastselectedSprite.x + "\n" +
                        "Y : " + spriteMode.lastselectedSprite.y;
                    owForm.objCombobox.Items.AddRange(Sprites_Names.name);
                    owForm.objCombobox.SelectedIndex = spriteMode.lastselectedSprite.id;

                    owForm.objCombobox.SelectedIndexChanged += ObjCombobox_SelectedIndexChangedSprite;


                }
            }
            else if (selectedMode == ObjectMode.Flute)
            {
                transportMode.onMouseUp(e);
                text += "Transport";

                if (transportMode.lastselectedTransport != null)
                {
                    owForm.objinfoLabel.Text = "Map ID : " + transportMode.lastselectedTransport.mapId + "\n" +

                        "X : " + transportMode.lastselectedTransport.playerX + "\n" +
                        "Y : " + transportMode.lastselectedTransport.playerY;
                }
            }
            owForm.objectGroupbox.Text = text;
            Invalidate(new Rectangle((owForm.splitContainer1.Panel2.HorizontalScroll.Value), (owForm.splitContainer1.Panel2.VerticalScroll.Value), (owForm.splitContainer1.Panel2.Width), (owForm.splitContainer1.Panel2.Height)));
        }

        private void ObjCombobox_SelectedIndexChangedSprite(object sender, EventArgs e)
        {
            spriteMode.lastselectedSprite.id = (byte)owForm.objCombobox.SelectedIndex;
            spriteMode.lastselectedSprite.name = owForm.objCombobox.Text;
            Invalidate(new Rectangle((owForm.splitContainer1.Panel2.HorizontalScroll.Value), (owForm.splitContainer1.Panel2.VerticalScroll.Value), (owForm.splitContainer1.Panel2.Width), (owForm.splitContainer1.Panel2.Height)));


        }
        private void ObjCombobox_SelectedIndexChangedItem(object sender, EventArgs e)
        {

            byte id = (byte)owForm.objCombobox.SelectedIndex;
            if (owForm.objCombobox.SelectedIndex >= 23)
            {
                id = (byte)(((owForm.objCombobox.SelectedIndex - 23) * 2) + 0x80);
                
            }
            itemMode.lastselectedItem.id = id;
            Invalidate(new Rectangle((owForm.splitContainer1.Panel2.HorizontalScroll.Value), (owForm.splitContainer1.Panel2.VerticalScroll.Value), (owForm.splitContainer1.Panel2.Width), (owForm.splitContainer1.Panel2.Height)));

        }

        private void onMouseMove(object sender, MouseEventArgs e)
        {
            if (selectedMode == ObjectMode.Tile)
            {
                tilemode.OnMouseMove(e);
            }
            else if (selectedMode == ObjectMode.Exits)
            {
                exitmode.onMouseMove(e);
            }
            else if (selectedMode == ObjectMode.OWDoor)
            {
                doorMode.onMouseMove(e);
            }
            else if (selectedMode == ObjectMode.Entrances)
            {
                entranceMode.onMouseMove(e);
            }
            else if (selectedMode == ObjectMode.Itemmode)
            {
                itemMode.onMouseMove(e);
            }
            else if (selectedMode == ObjectMode.Spritemode)
            {
                spriteMode.onMouseMove(e);
            }
            else if (selectedMode == ObjectMode.Flute)
            {
                transportMode.onMouseMove(e);
            }
            Invalidate(new Rectangle((owForm.splitContainer1.Panel2.HorizontalScroll.Value), (owForm.splitContainer1.Panel2.VerticalScroll.Value), (owForm.splitContainer1.Panel2.Width), (owForm.splitContainer1.Panel2.Height)));
        }

        public void Undo()
        {
            tilemode.Undo();
            Invalidate(new Rectangle((owForm.splitContainer1.Panel2.HorizontalScroll.Value), (owForm.splitContainer1.Panel2.VerticalScroll.Value), (owForm.splitContainer1.Panel2.Width), (owForm.splitContainer1.Panel2.Height)));
        }

        public void Redo()
        {
            tilemode.Redo();
            Invalidate(new Rectangle((owForm.splitContainer1.Panel2.HorizontalScroll.Value), (owForm.splitContainer1.Panel2.VerticalScroll.Value), (owForm.splitContainer1.Panel2.Width), (owForm.splitContainer1.Panel2.Height)));
        }

        public override void paste()
        {
            if (selectedMode == ObjectMode.Tile)
            {
                tilemode.Paste();
            }
            else if (selectedMode == ObjectMode.Exits)
            {
               exitmode.Paste();
            }
            else if (selectedMode == ObjectMode.Itemmode)
            {
                itemMode.Paste();
            }
            else if (selectedMode == ObjectMode.Spritemode)
            {
                spriteMode.Paste();
            }
            else if (selectedMode == ObjectMode.Entrances)
            {
                entranceMode.Paste();
            }
            Invalidate(new Rectangle((owForm.splitContainer1.Panel2.HorizontalScroll.Value), (owForm.splitContainer1.Panel2.VerticalScroll.Value), (owForm.splitContainer1.Panel2.Width), (owForm.splitContainer1.Panel2.Height)));
        }

        public override void copy()
        {
            if (selectedMode == ObjectMode.Tile)
            {
                tilemode.Copy();
            }
            else if (selectedMode == ObjectMode.Exits)
            {
                exitmode.Copy();
            }
            else if (selectedMode == ObjectMode.Itemmode)
            {
                itemMode.Copy();
            }
            else if (selectedMode == ObjectMode.Spritemode)
            {
                spriteMode.Copy();
            }
            else if (selectedMode == ObjectMode.Entrances)
            {
                entranceMode.Copy();
            }
            Invalidate(new Rectangle((owForm.splitContainer1.Panel2.HorizontalScroll.Value), (owForm.splitContainer1.Panel2.VerticalScroll.Value), (owForm.splitContainer1.Panel2.Width), (owForm.splitContainer1.Panel2.Height)));
        }

        public override void cut()
        {
            if (selectedMode == ObjectMode.Exits)
            {
                exitmode.Cut();
            }
            else if (selectedMode == ObjectMode.Itemmode)
            {
                itemMode.Cut();
            }
            else if (selectedMode == ObjectMode.Spritemode)
            {
                spriteMode.Cut();
            }
            else if (selectedMode == ObjectMode.Entrances)
            {
                entranceMode.Cut();
            }
            Invalidate(new Rectangle((owForm.splitContainer1.Panel2.HorizontalScroll.Value), (owForm.splitContainer1.Panel2.VerticalScroll.Value), (owForm.splitContainer1.Panel2.Width), (owForm.splitContainer1.Panel2.Height)));
        }

        public void SaveTiles()
        {


            if (!ow.createMap32Tilesmap())
            {
                ow.Save32Tiles();
                ow.savemapstorom();
                ow.SaveMap16Tiles();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            ColorMatrix cm = new ColorMatrix();
            ImageAttributes ia = new ImageAttributes();
            cm.Matrix33 = 0.50f;
            cm.Matrix22 = 2f;
            ia.SetColorMatrix(cm);
            g.CompositingMode = CompositingMode.SourceCopy;
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            //g.FillRectangle(Brushes.Green, new Rectangle(0, 0, 4096, 4096));

            /*
            for (int x = 0; x < 128; x++)
            {
                drawText(g, x * 32, 0, ow.map16tiles[x].tile0.ToString());
            }*/

            if (initialized)
            {

                int x = 0;
                int y = 0;
                for (int i = (0 + ow.worldOffset); i < 64 + (ow.worldOffset); i++)
                {
                    if (i <= 159)
                    {

                        g.DrawImage(ow.allmaps[i].gfxBitmap, new PointF(x * 512, y * 512));
                        x++;
                        if (x >= 8)
                        {
                            x = 0;
                            y++;
                        }
                    }
                }

                g.CompositingMode = CompositingMode.SourceOver;

                /*for (int yP = 0; yP < 32; yP+=2)
                {
                    for (int xP = 0; xP < 32; xP+=2)
                    {
                        drawText(g, xP * 16, yP * 16, ow.tiles16[ow.allmapsTilesLW[xP, yP]].tile0.id.ToString(), ia);
                        drawText(g, (xP * 16)+8, (yP * 16), ow.tiles16[ow.allmapsTilesLW[xP+1, yP]].tile1.id.ToString(), ia);
                        drawText(g, (xP * 16), (yP * 16)+8, ow.tiles16[ow.allmapsTilesLW[xP, yP+1]].tile2.id.ToString(), ia);
                        drawText(g, (xP * 16)+8, (yP * 16)+8, ow.tiles16[ow.allmapsTilesLW[xP+1, yP+1]].tile3.id.ToString(), ia);
                    }
                }*/


                //g.DrawImage(ow.allmaps[136].gfxBitmap, new PointF(0, 0));

                /*for (int i = 0; i < 64; i++)
                {
                    foreach (Sprite spr in ow.allmaps[i].sprites)
                    {
                        int yy = spr.mapid / 8;
                        int xx = spr.mapid - (yy * 8);
                        drawText(g, (spr.x * 16) + (xx * 512), ((spr.y * 16) - 16) + (yy * 512), spr.name);
                    }
                }
                */


                if (selecting)
                {
                    g.DrawRectangle(Pens.White, new Rectangle((globalmouseTileDownX * 16), (globalmouseTileDownY * 16), (((mouseX_Real / 16) - globalmouseTileDownX) * 16) + 16, (((mouseY_Real / 16) - globalmouseTileDownY) * 16) + 16));
                }


                if (selectedMode == ObjectMode.OWDoor || selectedMode == ObjectMode.Tile)
                {
                    g.DrawImage(tilesgfxBitmap, new Rectangle((mouseX_Real / 16) * 16, (mouseY_Real / 16) * 16, selectedTileSizeX * 16, (selectedTile.Length / selectedTileSizeX) * 16), 0, 0, selectedTileSizeX * 16, (selectedTile.Length / selectedTileSizeX) * 16, GraphicsUnit.Pixel, ia);
                    g.DrawRectangle(Pens.LightGreen, new Rectangle((mouseX_Real / 16) * 16, (mouseY_Real / 16) * 16, selectedTileSizeX * 16, (selectedTile.Length / selectedTileSizeX) * 16));
                }
                int my = (ow.allmaps[mapHover].parent / 8);
                int mx = ow.allmaps[mapHover].parent - (my * 8);
                if (ow.allmaps[mapHover].largeMap)
                {
                    g.DrawRectangle(Pens.Orange, new Rectangle(mx * 512, my * 512, 1024, 1024));
                }
                else
                {
                    g.DrawRectangle(Pens.Orange, new Rectangle(mx * 512, my * 512, 512, 512));
                }

                if (showExits)
                {
                    exitmode.Draw(g);
                }
                if (showEntrances)
                {
                    entranceMode.Draw(g);
                }
                if (showItems)
                {
                    itemMode.Draw(g);
                }
                
                if (showSprites)
                {
                    //if (!hideText)
                    //{
                        spriteMode.Draw(g);
                    //}
                }

                if (showFlute)
                {
                    transportMode.Draw(g);
                }

                if (entrancePreview)
                {
                    if (entranceMode.selectedEntrance != null)
                    {
                        e.Graphics.InterpolationMode = InterpolationMode.Bilinear;
                        if (mainForm.previewRoom.bg2 != Background2.Translucent || mainForm.previewRoom.bg2 != Background2.Transparent ||
                         mainForm.previewRoom.bg2 != Background2.OnTop || mainForm.previewRoom.bg2 != Background2.Off)
                        {
                            e.Graphics.DrawImage(GFX.roomBg2Bitmap, new Rectangle(entranceMode.selectedEntrance.x + 16, entranceMode.selectedEntrance.y + 16, 256, 256), 0, 0, 512, 512, GraphicsUnit.Pixel);
                        }

                        e.Graphics.DrawImage(GFX.roomBg1Bitmap, new Rectangle(entranceMode.selectedEntrance.x + 16, entranceMode.selectedEntrance.y + 16, 256, 256), 0, 0, 512, 512, GraphicsUnit.Pixel);

                        if (mainForm.previewRoom.bg2 == Background2.Translucent || mainForm.previewRoom.bg2 == Background2.Transparent)
                        {
                            float[][] matrixItems ={
               new float[] {1f, 0, 0, 0, 0},
               new float[] {0, 1f, 0, 0, 0},
               new float[] {0, 0, 1f, 0, 0},
               new float[] {0, 0, 0, 0.5f, 0},
               new float[] {0, 0, 0, 0, 1}};
                            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

                            // Create an ImageAttributes object and set its color matrix.
                            ImageAttributes imageAtt = new ImageAttributes();
                            imageAtt.SetColorMatrix(
                               colorMatrix,
                               ColorMatrixFlag.Default,
                               ColorAdjustType.Bitmap);
                            //GFX.roomBg2Bitmap.MakeTransparent(Color.Black);
                            e.Graphics.DrawImage(GFX.roomBg2Bitmap, new Rectangle(entranceMode.selectedEntrance.x + 16, entranceMode.selectedEntrance.y + 16, 256, 256), 0, 0, 512, 512, GraphicsUnit.Pixel, imageAtt);
                        }
                        else if (mainForm.previewRoom.bg2 == Background2.OnTop)
                        {
                            e.Graphics.DrawImage(GFX.roomBg2Bitmap, new Rectangle(entranceMode.selectedEntrance.x + 16, entranceMode.selectedEntrance.y + 16, 256, 256), 0, 0, 512, 512, GraphicsUnit.Pixel);
                        }

                        mainForm.activeScene.drawText(e.Graphics, entranceMode.selectedEntrance.x + 16, entranceMode.selectedEntrance.y + 16, "ROOM : " + mainForm.previewRoom.index.ToString());
                        e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                    }
                }


                g.CompositingMode = CompositingMode.SourceCopy;
                //hideText = false;
            }
        }






        bool clickedObject = false;

        public void ReLoadPalettes()
        {
            ow.allmaps[selectedMap].LoadPalette();
        }

        public override void deleteSelected()
        {


            if (selectedMode == ObjectMode.Itemmode)
            {
                itemMode.Delete();
            }
            else if (selectedMode == ObjectMode.Spritemode)
            {
                spriteMode.Delete();
            }
            else if (selectedMode == ObjectMode.Entrances)
            {
                entranceMode.Delete();
            }
            else if (selectedMode == ObjectMode.Exits)
            {
                exitmode.Delete();
            }

        }


        public void drawGrid(Graphics graphics)
        {
            /*if (showGrid)
            {
                //int s = mainForm.gridSize;
                int wh = (512 / s)+1;

                for (int x = 0; x < wh; x++)
                {
                    graphics.DrawLine(new Pen(Color.FromArgb(128, 255, 255, 255)), x * s, 0, x * s, 512);
                }
                for (int y = 0; y < wh; y++)
                {
                    graphics.DrawLine(new Pen(Color.FromArgb(128, 255, 255, 255)), 0, y * s, 512, y * s);
                }
            }*/
        }


        public void SetPalettesTransparent()
        {
            int pindex = 0;
            ColorPalette palettes = GFX.roomBg1Bitmap.Palette;
            for (int y = 0; y < GFX.loadedPalettes.GetLength(1); y++)
            {
                for (int x = 0; x < GFX.loadedPalettes.GetLength(0); x++)
                {
                    palettes.Entries[pindex] = GFX.loadedPalettes[x, y];
                    pindex++;
                }
            }

            for (int y = 0; y < GFX.loadedSprPalettes.GetLength(1); y++)
            {
                for (int x = 0; x < GFX.loadedSprPalettes.GetLength(0); x++)
                {
                    if (pindex < 256)
                    {
                        palettes.Entries[pindex] = GFX.loadedSprPalettes[x, y];
                        pindex++;
                    }
                }
            }

            for (int i = 0; i < 16; i++)
            {
                palettes.Entries[i * 16] = Color.Transparent;
                palettes.Entries[(i * 16) + 8] = Color.Transparent;
            }
            GFX.roomBg1Bitmap.Palette = palettes;
            GFX.roomBg2Bitmap.Palette = palettes;
            GFX.roomBgLayoutBitmap.Palette = palettes;
        }

        public void SetPalettesBlack()
        {
            int pindex = 0;
            ColorPalette palettes = GFX.roomBg1Bitmap.Palette;
            for (int y = 0; y < GFX.loadedPalettes.GetLength(1); y++)
            {
                for (int x = 0; x < GFX.loadedPalettes.GetLength(0); x++)
                {
                    palettes.Entries[pindex] = GFX.loadedPalettes[x, y];
                    pindex++;
                }
            }

            for (int i = 0; i < 16; i++)
            {
                palettes.Entries[i * 16] = Color.Black;
                palettes.Entries[(i * 16) + 8] = Color.Black;
            }
            GFX.roomBg1Bitmap.Palette = palettes;
            GFX.roomBg2Bitmap.Palette = palettes;
            GFX.roomBgLayoutBitmap.Palette = palettes;
        }


        
        private void onMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (selectedMode == ObjectMode.Entrances)
            {
                entranceMode.onMouseDoubleClick(e);
            }
        }
        

        public void objects_ResizeMouseMove(MouseEventArgs e)
        {
            
        }

        public void setMouseSizeMode(MouseEventArgs e)
        {
            
        }
        
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void chestpicker_Load(object sender, EventArgs e)
        {

        }

        private void pObj_Load(object sender, EventArgs e)
        {

        }
        
    }

}
