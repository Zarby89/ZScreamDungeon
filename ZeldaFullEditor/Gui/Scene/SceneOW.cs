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
using static ZeldaFullEditor.DungeonMain;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using ZeldaFullEditor.OWSceneModes;
using ZeldaFullEditor.Gui;
using ZeldaFullEditor.Data;
namespace ZeldaFullEditor
{
    public class SceneOW : Scene
    {
        //public IntPtr allgfx8array = Marshal.AllocHGlobal(32768);

        //int selectedIndex = 0;
        public int selectedMap = 0;
        public int selectedMapParent = 0;
        //public int lockedMap = -1;
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
        public int lastHover = -1;
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
        public OverlayMode overlayMode;
        public GravestoneMode gravestoneMode;
        public bool showEntrances = true;
        public bool showExits = true;
        public bool showFlute = true;
        public bool showItems = true;
        public bool showSprites = true;
        public bool hideText = false;
        public OverworldEditor owForm;
        public bool entrancePreview = false;
        //int selectedMode = 0;

        public bool lowEndMode = false;

        public SceneOW(OverworldEditor f, Overworld ow, DungeonMain mform)
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
            overlayMode = new OverlayMode(this);
            gravestoneMode = new GravestoneMode(this);

            //this.Width = 8192;
            //this.Height = 8192;
            //this.Size = new Size(8192, 8192);
            //this.Refresh();
        }

        public void CreateScene()
        {
            //tileBitmapPtr = ow.allmaps[0].blockset16;
            //tileBitmap = new Bitmap(128, 8192, 128, PixelFormat.Format8bppIndexed, tileBitmapPtr);
        }

        private void SceneOW_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
            int xPos = owForm.splitContainer1.Panel2.HorizontalScroll.Value;
            int yPos = owForm.splitContainer1.Panel2.VerticalScroll.Value;

            if (ModifierKeys == Keys.Shift)
            {
                if (e.Delta < 0)
                {
                    xPos += 128;
                }
                else
                {
                    xPos -= 128;
                }
            }
            else
            {

                if (ModifierKeys == Keys.Control)
                {
                    if (e.Delta < 0)
                    {
                        yPos += 48;
                    }
                    else
                    {
                        yPos -= 48;
                    }
                }
                else
                {
                    if (e.Delta < 0)
                    {
                        yPos += 96;
                    }
                    else
                    {
                        yPos -= 96;
                    }
                }
            }

            owForm.splitContainer1.Panel2.AutoScrollPosition = new Point(xPos, yPos);
            //e.Delta
        }

        public void updateMapGfx()
        {
            if (selectedMap + ow.worldOffset <= 159)
            {
                owForm.propertiesChangedFromForm = true;
                OverworldMap map = ow.allmaps[selectedMap + ow.worldOffset];
                if (map.needRefresh)
                {
                    map.BuildMap();
                    map.needRefresh = false;
                }

                owForm.mapGroupbox.Text = string.Format(
                    mainForm.showMapIndexInHexToolStripMenuItem.Checked ? "Selected map: {0}" : "Selected map: {0}",
                    map.parent.ToString("X2")
                    );

                owForm.OWProperty_MessageID.HexValue = ow.allmaps[map.parent].messageID;

                owForm.UpdateGUIProperties(ow.allmaps[map.parent], ow.worldOffset >= 64 ? 0 : ow.gameState);

                owForm.propertiesChangedFromForm = false;
                owForm.tilePictureBox.Refresh();

                owForm.areaBGColorPictureBox.Refresh();
            }

            owForm.BuildScratchTilesGfx();
            owForm.scratchPicturebox.Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            int tileX = (e.X / 16);
            int tileY = (e.Y / 16);
            int superX = (tileX / 32);
            int superY = (tileY / 32);
            int mapId = (superY * 8) + superX;

            if (mapId + ow.worldOffset < ow.allmaps.Length)
            {
                globalmouseTileDownX = tileX;
                globalmouseTileDownY = tileY;

                mainForm.anychange = true;
                selectedMap = mapId;

                selectedMapParent = ow.allmaps[selectedMap + ow.worldOffset].parent;

                owForm.previewTextPicturebox.Visible = false;
                updateMapGfx();
                owForm.updateTiles();

                switch (selectedMode)
                {
                    case ObjectMode.Tile:
                        tilemode.OnMouseDown(e);
                        break;
                    case ObjectMode.Overlay:
                        overlayMode.OnMouseDown(e);
                        break;
                    case ObjectMode.Exits:
                        exitmode.onMouseDown(e);
                        break;
                    case ObjectMode.OWDoor:
                        doorMode.OnMouseDown(e);
                        break;
                    case ObjectMode.Entrances:
                        entranceMode.onMouseDown(e);
                        break;
                    case ObjectMode.Itemmode:
                        itemMode.onMouseDown(e);
                        break;
                    case ObjectMode.Spritemode:
                        spriteMode.onMouseDown(e);
                        break;
                    case ObjectMode.Flute:
                        transportMode.onMouseDown(e);
                        break;
                    case ObjectMode.Gravestone:
                        gravestoneMode.onMouseDown(e);
                        break;
                }

                InvalidateHighEnd();

                base.OnMouseDown(e);
            }
            else
            {
                Console.WriteLine("Invalid area selected");
            }
        }

        // TODO switch statements
        private unsafe void onMouseUp(object sender, MouseEventArgs e)
        {
            owForm.objCombobox.Items.Clear();
            owForm.objCombobox.SelectedIndexChanged -= ObjCombobox_SelectedIndexChangedSprite;
            owForm.objCombobox.SelectedIndexChanged -= ObjCombobox_SelectedIndexChangedItem;
            string text = "Selected object: ";

            if (selectedMode == ObjectMode.Tile)
            {
                tilemode.OnMouseUp(e);
            }
            else if (selectedMode == ObjectMode.Overlay)
            {
                overlayMode.OnMouseUp(e);
            }
            else if (selectedMode == ObjectMode.Exits)
            {
                exitmode.onMouseUp(e);
                text += "Exit";
                if (exitmode.lastselectedExit != null)
                {
                    owForm.SetSelectedObjectLabels(
                        exitmode.lastselectedExit.mapId,
                        exitmode.lastselectedExit.playerX,
                        exitmode.lastselectedExit.playerY);
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
                    owForm.SetSelectedObjectLabels(
                        entranceMode.lastselectedEntrance.EntranceID,
                        entranceMode.lastselectedEntrance.X,
                        entranceMode.lastselectedEntrance.Y);
                }
            }
            else if (selectedMode == ObjectMode.Itemmode)
            {
                itemMode.onMouseUp(e);
                text += "Item";

                if (itemMode.lastselectedItem != null)
                {
                    owForm.SetSelectedObjectLabels(
                        itemMode.lastselectedItem.id,
                        itemMode.lastselectedItem.x,
                        itemMode.lastselectedItem.y);

                    owForm.objCombobox.Items.AddRange(ItemsNames.name);

                    if ((itemMode.lastselectedItem.id & 0x80) == 0x80)
                    {
                        owForm.objCombobox.SelectedIndex = (23 + ((itemMode.lastselectedItem.id - 0x80) / 2));
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
                    owForm.SetSelectedObjectLabels(
                        spriteMode.lastselectedSprite.id,
                        spriteMode.lastselectedSprite.x,
                        spriteMode.lastselectedSprite.y);
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
                    owForm.SetSelectedObjectLabels(
                        transportMode.lastselectedTransport.mapId,
                        transportMode.lastselectedTransport.playerX,
                        transportMode.lastselectedTransport.playerY);
                }
            }
            else if (selectedMode == ObjectMode.Gravestone)
            {
                gravestoneMode.onMouseUp(e);
            }

            owForm.objectGroupbox.Text = text;
            InvalidateHighEnd();
        }


        private void ObjCombobox_SelectedIndexChangedSprite(object sender, EventArgs e)
        {
            spriteMode.lastselectedSprite.id = (byte)owForm.objCombobox.SelectedIndex;
            spriteMode.lastselectedSprite.name = owForm.objCombobox.Text;

            InvalidateHighEnd();
        }

        private void InvalidateHighEnd()
        {
            if (lowEndMode)
            {
                int x = ow.allmaps[selectedMap].parent % 8;
                int y = ow.allmaps[selectedMap].parent / 8;
                if (!ow.allmaps[ow.allmaps[selectedMap].parent].largeMap)
                {
                    Invalidate(new Rectangle(x * 512, y * 512, 512, 512));
                }
                else
                {
                    Invalidate(new Rectangle(x * 512, y * 512, 1024, 1024));
                }
            }
            else
            {
                Invalidate(new Rectangle(
                    owForm.splitContainer1.Panel2.HorizontalScroll.Value,
                    owForm.splitContainer1.Panel2.VerticalScroll.Value,
                    owForm.splitContainer1.Panel2.Width,
                    owForm.splitContainer1.Panel2.Height
                    ));
            }
        }



        private void ObjCombobox_SelectedIndexChangedItem(object sender, EventArgs e)
        {
            byte id = (byte)owForm.objCombobox.SelectedIndex;
            if (owForm.objCombobox.SelectedIndex >= 23)
            {
                id = (byte)(((owForm.objCombobox.SelectedIndex - 23) * 2) + 0x80);

            }


            itemMode.lastselectedItem.id = id;
            itemMode.SendItemData(itemMode.lastselectedItem);
            InvalidateHighEnd();
        }

        private void onMouseMove(object sender, MouseEventArgs e)
        {
            switch (selectedMode)
            {
                case ObjectMode.Tile:
                    tilemode.OnMouseMove(e);
                    break;
                case ObjectMode.Overlay:
                    overlayMode.OnMouseMove(e);
                    break;
                case ObjectMode.Exits:
                    exitmode.onMouseMove(e);
                    break;
                case ObjectMode.OWDoor:
                    doorMode.onMouseMove(e);
                    break;
                case ObjectMode.Entrances:
                    entranceMode.onMouseMove(e);
                    break;
                case ObjectMode.Itemmode:
                    itemMode.onMouseMove(e);
                    break;
                case ObjectMode.Spritemode:
                    spriteMode.onMouseMove(e);
                    break;
                case ObjectMode.Flute:
                    transportMode.onMouseMove(e);
                    break;
                case ObjectMode.Gravestone:
                    gravestoneMode.onMouseMove(e);
                    break;
            }

            InvalidateHighEnd();

        }

        public void Undo()
        {
            if (!NetZS.connected)
            {
                tilemode.Undo();
                InvalidateHighEnd();
            }
        }

        public void Redo()
        {
            if (!NetZS.connected)
            {
                tilemode.Redo();
                InvalidateHighEnd();
            }
        }

        public override void paste()
        {
            switch (selectedMode)
            {
                case ObjectMode.Tile:
                    tilemode.Paste();
                    break;
                case ObjectMode.Overlay:
                    //overlayMode.Paste();
                    break;
                case ObjectMode.Exits:
                    exitmode.Paste();
                    break;
                case ObjectMode.OWDoor:
                    //doorMode.Paste();
                    break;
                case ObjectMode.Entrances:
                    entranceMode.Paste();
                    break;
                case ObjectMode.Itemmode:
                    itemMode.Paste();
                    break;
                case ObjectMode.Spritemode:
                    spriteMode.Paste();
                    break;
                case ObjectMode.Flute:
                    //transportMode.Paste();
                    break;
                case ObjectMode.Gravestone:
                    //gravestoneMode.Paste();
                    break;
            }

            InvalidateHighEnd();
        }

        public override void copy()
        {
            switch (selectedMode)
            {
                case ObjectMode.Tile:
                    tilemode.Copy();
                    break;
                case ObjectMode.Overlay:
                    //overlayMode.Copy();
                    break;
                case ObjectMode.Exits:
                    exitmode.Copy();
                    break;
                case ObjectMode.OWDoor:
                    //doorMode.Copy();
                    break;
                case ObjectMode.Entrances:
                    entranceMode.Copy();
                    break;
                case ObjectMode.Itemmode:
                    itemMode.Copy();
                    break;
                case ObjectMode.Spritemode:
                    spriteMode.Copy();
                    break;
                case ObjectMode.Flute:
                    //transportMode.Copy();
                    break;
                case ObjectMode.Gravestone:
                    //gravestoneMode.Copy();
                    break;
            }

            InvalidateHighEnd();
        }

        public override void cut()
        {
            switch (selectedMode)
            {
                case ObjectMode.Tile:
                    //tilemode.Cut();
                    break;
                case ObjectMode.Overlay:
                    //overlayMode.Cut();
                    break;
                case ObjectMode.Exits:
                    exitmode.Cut();
                    break;
                case ObjectMode.OWDoor:
                    //doorMode.Cut();
                    break;
                case ObjectMode.Entrances:
                    entranceMode.Cut();
                    break;
                case ObjectMode.Itemmode:
                    itemMode.Cut();
                    break;
                case ObjectMode.Spritemode:
                    spriteMode.Cut();
                    break;
                case ObjectMode.Flute:
                    //transportMode.Cut();
                    break;
                case ObjectMode.Gravestone:
                    //gravestoneMode.Cut();
                    break;
            }

            InvalidateHighEnd();
        }

        /// <summary>
        /// Creates a map32 tile map and saves the overworld tiles in the rom. 
        /// </summary>
        /// <returns>True if saving failed. For example if the unique tile32 limit was passed. </returns>
        public bool SaveTiles()
        {
            if (!ow.createMap32Tilesmap())
            {
                ow.Save32Tiles();
                //ow.savemapstorom();
                ow.SaveMap16Tiles();

                return false;
            }
            else
            {
                return true;
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

            if (initialized)
            {
                if (lowEndMode)
                {
                    int x = ow.allmaps[selectedMap].parent % 8;
                    int y = ow.allmaps[selectedMap].parent / 8;

                    if (ow.allmaps[ow.allmaps[selectedMap].parent].largeMap)
                    {
                        if (OverworldEditor.UseAreaSpecificBgColor)
                        {
                            g.FillRectangle(new SolidBrush(Palettes.overworld_BackgroundPalette[ow.allmaps[selectedMap].parent]), new RectangleF(x * 512, y * 512, 1024, 1024));
                        }
                        else
                        {
                            g.FillRectangle(new SolidBrush(Palettes.overworld_GrassPalettes[0]), new RectangleF(x * 512, y * 512, 1024, 1024));
                        }

                        g.DrawImage(ow.allmaps[ow.allmaps[selectedMap].parent].gfxBitmap, new PointF(x * 512, y * 512));
                        g.DrawImage(ow.allmaps[ow.allmaps[selectedMap].parent + 1].gfxBitmap, new PointF((x + 1) * 512, y * 512));
                        g.DrawImage(ow.allmaps[ow.allmaps[selectedMap].parent + 8].gfxBitmap, new PointF((x) * 512, (y + 1) * 512));
                        g.DrawImage(ow.allmaps[ow.allmaps[selectedMap].parent + 9].gfxBitmap, new PointF((x + 1) * 512, (y + 1) * 512));
                    }
                    else
                    {
                        if (OverworldEditor.UseAreaSpecificBgColor)
                        {
                            g.FillRectangle(new SolidBrush(Palettes.overworld_BackgroundPalette[ow.allmaps[selectedMap].parent]), new RectangleF(x * 512, y * 512, 512, 512));
                        }
                        else
                        {
                            g.FillRectangle(new SolidBrush(Palettes.overworld_GrassPalettes[0]), new RectangleF(x * 512, y * 512, 512, 512));
                        }

                        g.DrawImage(ow.allmaps[ow.allmaps[selectedMap].parent].gfxBitmap, new PointF(x * 512, y * 512));
                    }
                }
                else
                {
                    if (ow.worldOffset == 64)
                    {
                        g.Clear(Palettes.overworld_GrassPalettes[1]);
                    }
                    else if (ow.worldOffset == 128)
                    {
                        g.Clear(Palettes.overworld_GrassPalettes[2]);
                    }
                    else
                    {
                        g.Clear(Palettes.overworld_GrassPalettes[0]);
                    }

                    // TODO make a single PointF and Rectangle variable to reuse
                    int x = 0;
                    int y = 0;
                    for (int i = (0 + ow.worldOffset); i < 64 + (ow.worldOffset); i++)
                    {
                        if (i <= 159)
                        {
                            if (mainForm.overworldOverlayVisibleToolStripMenuItem.Checked)
                            {
                                if (i == 0x03)
                                {
                                    g.CompositingMode = CompositingMode.SourceOver;
                                    g.DrawImage(ow.allmaps[149].gfxBitmap, new PointF(x * 512, y * 512));
                                }
                                else if (i == 0x04)
                                {
                                    g.CompositingMode = CompositingMode.SourceOver;
                                    g.DrawImage(ow.allmaps[149].gfxBitmap, new PointF(x * 512, y * 512));
                                }
                                else if (i == 0x05)
                                {
                                    g.CompositingMode = CompositingMode.SourceOver;
                                    g.DrawImage(ow.allmaps[149].gfxBitmap, new PointF(x * 512, y * 512));
                                }
                                else if (i == 0x06)
                                {
                                    g.CompositingMode = CompositingMode.SourceOver;
                                    g.DrawImage(ow.allmaps[149].gfxBitmap, new PointF(x * 512, y * 512));
                                }
                                else if (i == 0x07)
                                {
                                    g.CompositingMode = CompositingMode.SourceOver;
                                    g.DrawImage(ow.allmaps[149].gfxBitmap, new PointF(x * 512, y * 512));
                                }
                                else if (i == 91)
                                {
                                    g.CompositingMode = CompositingMode.SourceOver;
                                    g.DrawImage(ow.allmaps[150].gfxBitmap, new PointF(x * 512, y * 512));
                                }
                                else if (i == 92)
                                {
                                    g.CompositingMode = CompositingMode.SourceOver;
                                    g.DrawImage(ow.allmaps[150].gfxBitmap, new PointF(x * 512, y * 512));
                                }
                            }
                            else
                            {
                                if (i < 64)
                                {
                                    g.CompositingMode = CompositingMode.SourceOver;

                                    if (OverworldEditor.UseAreaSpecificBgColor)
                                    {
                                        g.FillRectangle(new SolidBrush(Palettes.overworld_BackgroundPalette[ow.allmaps[i].parent]), new RectangleF(x * 512, y * 512, 512, 512));
                                    }
                                    else
                                    {
                                        g.FillRectangle(new SolidBrush(Palettes.overworld_GrassPalettes[0]), new RectangleF(x * 512, y * 512, 512, 512));
                                    }
                                }
                                else if (i >= 64 && i < 128)
                                {
                                    g.CompositingMode = CompositingMode.SourceOver;

                                    if (OverworldEditor.UseAreaSpecificBgColor)
                                    {
                                        g.FillRectangle(new SolidBrush(Palettes.overworld_BackgroundPalette[ow.allmaps[i].parent]), new RectangleF(x * 512, y * 512, 512, 512));
                                    }
                                    else
                                    {
                                        g.FillRectangle(new SolidBrush(Palettes.overworld_GrassPalettes[1]), new RectangleF(x * 512, y * 512, 512, 512));
                                    }
                                }
                                else
                                {
                                    g.CompositingMode = CompositingMode.SourceOver;

                                    if (OverworldEditor.UseAreaSpecificBgColor)
                                    {
                                        g.FillRectangle(new SolidBrush(Palettes.overworld_BackgroundPalette[ow.allmaps[i].parent]), new RectangleF(x * 512, y * 512, 512, 512));
                                    }
                                    else
                                    {
                                        g.FillRectangle(new SolidBrush(Palettes.overworld_GrassPalettes[2]), new RectangleF(x * 512, y * 512, 512, 512));
                                    }
                                }
                            }

                            g.DrawImage(ow.allmaps[i].gfxBitmap, new PointF(x * 512, y * 512));

                            if (mainForm.overworldOverlayVisibleToolStripMenuItem.Checked)
                            {
                                if (i == 0)
                                {
                                    g.CompositingMode = CompositingMode.SourceOver;
                                    g.DrawImage(ow.allmaps[157].gfxBitmap, new Rectangle(x * 512, y * 512, 512, 512), 0, 0, 512, 512, GraphicsUnit.Pixel, ia);
                                }
                                else if (i == 1)
                                {
                                    g.CompositingMode = CompositingMode.SourceOver;
                                    g.DrawImage(ow.allmaps[157].gfxBitmap, new Rectangle(x * 512, y * 512, 512, 512), 0, 0, 512, 512, GraphicsUnit.Pixel, ia);
                                }
                                else if (i == 8)
                                {
                                    g.CompositingMode = CompositingMode.SourceOver;
                                    g.DrawImage(ow.allmaps[157].gfxBitmap, new Rectangle(x * 512, y * 512, 512, 512), 0, 0, 512, 512, GraphicsUnit.Pixel, ia);

                                }
                                else if (i == 9)
                                {
                                    g.CompositingMode = CompositingMode.SourceOver;
                                    g.DrawImage(ow.allmaps[157].gfxBitmap, new Rectangle(x * 512, y * 512, 512, 512), 0, 0, 512, 512, GraphicsUnit.Pixel, ia);
                                }
                            }

                            x++;
                            if (x >= 8)
                            {
                                x = 0;
                                y++;
                            }
                        }
                    }
                }

                g.CompositingMode = CompositingMode.SourceOver;

                if (selecting)
                {
                    g.DrawRectangle(Pens.White, new Rectangle((globalmouseTileDownX * 16), (globalmouseTileDownY * 16), (((mouseX_Real / 16) - globalmouseTileDownX) * 16) + 16, (((mouseY_Real / 16) - globalmouseTileDownY) * 16) + 16));
                }

                if (selectedMode == ObjectMode.OWDoor || selectedMode == ObjectMode.Tile)
                {
                    g.DrawImage(tilesgfxBitmap, new Rectangle((mouseX_Real / 16) * 16, (mouseY_Real / 16) * 16, selectedTileSizeX * 16, (selectedTile.Length / selectedTileSizeX) * 16), 0, 0, selectedTileSizeX * 16, (selectedTile.Length / selectedTileSizeX) * 16, GraphicsUnit.Pixel, ia);
                    g.DrawRectangle(Pens.LightGreen, new Rectangle((mouseX_Real / 16) * 16, (mouseY_Real / 16) * 16, selectedTileSizeX * 16, (selectedTile.Length / selectedTileSizeX) * 16));
                }

                int offset = 0;
                if (selectedMap >= 128)
                {
                    offset = 128;
                }

                if ((mapHover + offset) < ow.allmaps.Length)
                {
                    int my = (ow.allmaps[mapHover + offset].parent - offset) / 8;
                    int mx = (ow.allmaps[mapHover + offset].parent - offset) - (my * 8);

                    if (ow.allmaps[mapHover + offset].largeMap)
                    {
                        g.DrawRectangle(Pens.Orange, new Rectangle(mx * 512, my * 512, 1024, 1024));
                    }
                    else
                    {
                        g.DrawRectangle(Pens.Orange, new Rectangle(mx * 512, my * 512, 512, 512));
                    }
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

                gravestoneMode.Draw(g);

                if (showSprites)
                {
                    spriteMode.Draw(g);
                }
                if (showFlute)
                {
                    transportMode.Draw(g);
                }
                if (entrancePreview)
                {
                    if (entranceMode.selectedEntrance != null)
                    {
                        g.DrawImage(owForm.tmpPreviewBitmap, entranceMode.selectedEntrance.X + 16, entranceMode.selectedEntrance.Y + 16);
                    }
                    if (exitmode.selectedExit != null)
                    {
                        g.DrawImage(owForm.tmpPreviewBitmap, exitmode.selectedExit.playerX + 16, exitmode.selectedExit.playerY + 16);
                    }
                }

                if (selectedMode == ObjectMode.Overlay)
                {
                    int mid = ow.allmaps[selectedMap].parent;
                    int msy = ((ow.allmaps[selectedMap].parent - ow.worldOffset) / 8);
                    int msx = (ow.allmaps[selectedMap].parent - ow.worldOffset) - (msy * 8);
                    drawText(g, 0 + 4, 0 + 64, "Selected Map : " + selectedMap.ToString("X2"));
                    drawText(g, 0 + 4, 0 + 80, "Selected Map PARENT : " + ow.allmaps[selectedMap].parent.ToString("X2"));
                    drawText(g, (msx * 512) + 4, (msy * 512) + 4, "use ctrl key + click to delete overlay tiles");

                    for (int i = 0; i < ow.alloverlays[mid].tilesData.Count; i++)
                    {
                        int xo = ow.alloverlays[mid].tilesData[i].x * 16;
                        int yo = ow.alloverlays[mid].tilesData[i].y * 16;
                        int to = ow.alloverlays[mid].tilesData[i].tileId;
                        int toy = (to / 8) * 16;
                        int tox = (to % 8) * 16;
                        g.DrawImage(GFX.mapblockset16Bitmap, new Rectangle((msx * 512) + xo, (msy * 512) + yo, 16, 16), new Rectangle(tox, toy, 16, 16), GraphicsUnit.Pixel);
                        //g.DrawImage(GFX.currentOWgfx16Bitmap, new Rectangle(0, 0, 64, 64), new Rectangle(0, 0, 64, 64), GraphicsUnit.Pixel);
                        byte detect = compareTilePos(ow.alloverlays[mid].tilesData[i], ow.alloverlays[mid].tilesData.ToArray());

                        if (detect == 0)
                        {
                            g.DrawRectangle(Pens.White, new Rectangle((msx * 512) + xo, (msy * 512) + yo, (msx * 512) + 16, (msy * 512) + 16));
                        }
                        if ((detect & 0x01) != 0x01)
                        {
                            g.DrawLine(Pens.White, (msx * 512) + xo, (msy * 512) + yo, (msx * 512) + xo, (msy * 512) + yo + 16);
                        }
                        if ((detect & 0x02) != 0x02)
                        {
                            g.DrawLine(Pens.White, (msx * 512) + xo, (msy * 512) + yo, (msx * 512) + xo + 16, (msy * 512) + yo);
                        }
                        if ((detect & 0x04) != 0x04)
                        {
                            g.DrawLine(Pens.White, (msx * 512) + xo + 16, (msy * 512) + yo, (msx * 512) + xo + 16, (msy * 512) + yo + 16);
                        }
                        if ((detect & 0x08) != 0x08)
                        {
                            g.DrawLine(Pens.White, (msx * 512) + xo, (msy * 512) + yo + 16, (msx * 512) + xo + 16, (msy * 512) + yo + 16);
                        }
                    }

                    g.DrawImage(tilesgfxBitmap, new Rectangle((mouseX_Real / 16) * 16, (mouseY_Real / 16) * 16, selectedTileSizeX * 16, (selectedTile.Length / selectedTileSizeX) * 16), 0, 0, selectedTileSizeX * 16, (selectedTile.Length / selectedTileSizeX) * 16, GraphicsUnit.Pixel, ia);
                    g.DrawRectangle(Pens.LightGreen, new Rectangle((mouseX_Real / 16) * 16, (mouseY_Real / 16) * 16, selectedTileSizeX * 16, (selectedTile.Length / selectedTileSizeX) * 16));

                    drawText(g, 4, 24, globalmouseTileDownX.ToString());
                    drawText(g, 4, 48, globalmouseTileDownY.ToString());
                }

                if (owForm.gridDisplay != 0)
                {
                    int gridsize = 512;
                    if (ow.allmaps[ow.allmaps[selectedMap].parent].largeMap)
                    {
                        gridsize = 1024;
                    }

                    int temp = selectedMap;
                    temp = temp % 64;

                    int x = ow.allmaps[temp].parent % 8;
                    int y = ow.allmaps[temp].parent / 8;

                    for (int gx = 0; gx < (gridsize / owForm.gridDisplay); gx++)
                    {
                        g.DrawLine(Constants.ThirdWhitePen1,
                            new Point((x * 512) + gx * owForm.gridDisplay, y * 512),
                            new Point((x * 512) + gx * owForm.gridDisplay, (y * 512) + gridsize));
                    }

                    for (int gy = 0; gy < (gridsize / owForm.gridDisplay); gy++)
                    {
                        g.DrawLine(Constants.ThirdWhitePen1,
                            new Point((x * 512), (y * 512) + (gy * owForm.gridDisplay)),
                            new Point((x * 512) + gridsize, (y * 512) + (gy * owForm.gridDisplay)));
                    }
                }

                g.CompositingMode = CompositingMode.SourceCopy;
                //hideText = false;
            }
        }

        // 0 = none
        // 1 = left
        // 2 = up
        // 4 = right
        // 8 = bottom

        public byte compareTilePos(TilePos tpc, TilePos[] tpa)
        {
            byte detected = 0;
            foreach (TilePos t in tpa)
            {
                if (t.x == tpc.x - 1 && t.y == tpc.y)
                {
                    detected |= 1;
                }
                else if (t.x == tpc.x + 1 && t.y == tpc.y)
                {
                    detected |= 4;
                }
                else if (t.x == tpc.x && t.y == tpc.y - 1)
                {
                    detected |= 2;
                }
                else if (t.x == tpc.x && t.y == tpc.y + 1)
                {
                    detected |= 8;
                }
                else if (t.x == tpc.x && t.y == tpc.y)
                {
                    detected |= 0x80;
                }
            }

            return detected;
        }

        public TilePos compareTilePosT(TilePos tpc, TilePos[] tpa)
        {
            foreach (TilePos t in tpa)
            {
                if (t.x == tpc.x && t.y == tpc.y)
                {
                    return t;
                }
            }
            return null;
        }

        public void ReLoadPalettes()
        {
            ow.allmaps[selectedMap].LoadPalette();
        }

        public override void deleteSelected()
        {
            switch (selectedMode)
            {
                case ObjectMode.Tile:
                    //tilemode.Delete();
                    break;
                case ObjectMode.Overlay:
                    //overlayMode.Delete();
                    break;
                case ObjectMode.Exits:
                    exitmode.Delete();
                    break;
                case ObjectMode.OWDoor:
                    //doorMode.Delete();
                    break;
                case ObjectMode.Entrances:
                    entranceMode.Delete();
                    break;
                case ObjectMode.Itemmode:
                    itemMode.Delete();
                    break;
                case ObjectMode.Spritemode:
                    spriteMode.Delete();
                    break;
                case ObjectMode.Flute:
                    //transportMode.Delete();
                    break;
                case ObjectMode.Gravestone:
                    //gravestoneMode.Delete();
                    break;
            }
        }


        public void drawGrid(Graphics graphics)
        {
            // TODO: Add something here?

            /*
            if (showGrid)
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
            }
            */
        }


        public void SetPalettesTransparent()
        {
            int pindex = 0;
            ColorPalette palettes = GFX.roomBg1Bitmap.Palette;
            for (int y = 0; y < GFX.loadedPalettes.GetLength(1); y++)
            {
                for (int x = 0; x < GFX.loadedPalettes.GetLength(0); x++)
                {
                    palettes.Entries[pindex++] = GFX.loadedPalettes[x, y];
                }
            }

            for (int y = 0; y < GFX.loadedSprPalettes.GetLength(1); y++)
            {
                for (int x = 0; x < GFX.loadedSprPalettes.GetLength(0); x++)
                {
                    if (pindex < 256)
                    {
                        palettes.Entries[pindex++] = GFX.loadedSprPalettes[x, y];
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
                    palettes.Entries[pindex++] = GFX.loadedPalettes[x, y];
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

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
