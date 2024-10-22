using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ZeldaFullEditor.Gui;
using ZeldaFullEditor.OWSceneModes;
using ZeldaFullEditor.Properties;

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
        public OverlayAnimationMode overlayAnimationMode;
        public GravestoneMode gravestoneMode;
        public NoteMode noteMode;
        public bool showEntrances = true;
        public bool showExits = true;
        public bool showFlute = true;
        public bool showItems = true;
        public bool showSprites = true;
        public bool hideText = false;
        public bool showOverlayText = true;
        public OverworldEditor owForm;
        public bool entrancePreview = false;
        private Point startingPoint = Point.Empty;
        private Point scrollingPoint = Point.Empty;
        private Point startpanPoint = Point.Empty;
        public bool showLinkCamera = false;
        bool pan = false;
        //int selectedMode = 0;
        public List<OWNote> owNotesList = new List<OWNote>();

        public bool lowEndMode = false;

        public SceneOW(OverworldEditor f, Overworld ow, DungeonMain mform)
        {
            this.owForm = f;
            this.mainForm = mform;
            this.ow = ow;
            //graphics = Graphics.FromImage(scene_bitmap);
            //this.Image = new Bitmap(4096, 4096);
            this.MouseUp += new MouseEventHandler(this.onMouseUp);
            this.MouseMove += new MouseEventHandler(this.onMouseMove);
            this.MouseDoubleClick += new MouseEventHandler(this.onMouseDoubleClick);
            this.MouseWheel += SceneOW_MouseWheel;
            
            this.tilesgfxBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, this.temptilesgfxPtr);
            this.tilemode = new TileMode(this);
            this.exitmode = new ExitMode(this);
            this.doorMode = new DoorMode(this);
            this.entranceMode = new EntranceMode(this);
            this.selectedMode = ObjectMode.Tile;
            this.itemMode = new ItemMode(this);
            this.spriteMode = new SpriteMode(this);
            this.transportMode = new TransportMode(this);
            this.overlayMode = new OverlayMode(this);
            this.gravestoneMode = new GravestoneMode(this);
            this.overlayAnimationMode = new OverlayAnimationMode(this);
            this.noteMode = new NoteMode(this);

        }


        public void CreateScene()
        {
            //tileBitmapPtr = ow.allmaps[0].blockset16;
            //tileBitmap = new Bitmap(128, 8192, 128, PixelFormat.Format8bppIndexed, tileBitmapPtr);
        }

        private void SceneOW_MouseWheel(object sender, MouseEventArgs e)
        {
            if (selectedMode == ObjectMode.OverlayAnimation)
            {
                if (e.Delta < 0)
                {
                    if (overlayAnimationMode.selectedFrame > 0)
                    {
                        overlayAnimationMode.selectedFrame -= 1;
                    }
                }
                else
                {
                    if (overlayAnimationMode.selectedFrame < 255)
                    {
                        overlayAnimationMode.selectedFrame += 1;
                    }

                }
                this.InvalidateHighEnd();
                ((HandledMouseEventArgs)e).Handled = true;
                return;
            }


            ((HandledMouseEventArgs)e).Handled = true;
            int xPos = this.owForm.splitContainer1.Panel2.HorizontalScroll.Value;
            int yPos = this.owForm.splitContainer1.Panel2.VerticalScroll.Value;

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

            this.owForm.splitContainer1.Panel2.AutoScrollPosition = new Point(xPos, yPos);

            //e.Delta
        }

        public void updateMapGfx()
        {
            if (this.selectedMap <= 159)
            {
                this.owForm.propertiesChangedFromForm = true;
                OverworldMap map = this.ow.AllMaps[this.selectedMap];
                if (map.NeedRefresh)
                {
                    map.BuildMap();
                    map.NeedRefresh = false;
                }

                this.owForm.mapGroupbox.Text = string.Format(
                    this.mainForm.showMapIndexInHexToolStripMenuItem.Checked ? "Selected map: {0}" : "Selected map: {0}",
                    map.ParentID.ToString("X2"));

                this.owForm.OWProperty_MessageID.HexValue = this.ow.AllMaps[map.ParentID].MessageID;

                this.owForm.UpdateGUIProperties(this.ow.AllMaps[map.ParentID], this.ow.WorldOffset >= 64 ? 0 : this.ow.GameState);

                this.owForm.propertiesChangedFromForm = false;
                this.owForm.tilePictureBox.Refresh();

                this.owForm.areaBGColorPictureBox.Refresh();
            }

            this.owForm.BuildScratchTilesGfx();
            this.owForm.scratchPicturebox.Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Middle)
            {
                startingPoint = mainForm.PointToClient(Cursor.Position);
                scrollingPoint = mainForm.PointToClient(Cursor.Position); // use mainform since it doesn't scroll!
                startpanPoint = new Point(owForm.splitContainer1.Panel2.HorizontalScroll.Value, owForm.splitContainer1.Panel2.VerticalScroll.Value);
                pan = true;
            }


            int tileX = e.X / 16;
            int tileY = e.Y / 16;
            int superX = tileX / 32;
            int superY = tileY / 32;
            int mapId = (superY * 8) + superX;

            if (mapId + this.ow.WorldOffset >= this.ow.AllMaps.Length)
            {
                Console.WriteLine("Invalid area selected");
                return;
            }

            this.selectedMap = mapId + this.ow.WorldOffset;

            this.globalmouseTileDownX = tileX;
            this.globalmouseTileDownY = tileY;

            this.mainForm.anychange = true;

            this.selectedMapParent = this.ow.AllMaps[this.selectedMap].ParentID;

            this.owForm.previewTextPicturebox.Visible = false;
            this.updateMapGfx();
            this.owForm.UpdateTiles();

            switch (this.selectedMode)
            {
                case ObjectMode.Tile:
                    this.tilemode.OnMouseDown(e);
                    break;
                case ObjectMode.Overlay:
                    this.overlayMode.OnMouseDown(e);
                    break;
                case ObjectMode.OverlayAnimation:
                    this.overlayAnimationMode.OnMouseDown(e);
                    break;
                case ObjectMode.Exits:
                    this.exitmode.onMouseDown(e);
                    break;
                case ObjectMode.OWDoor:
                    this.doorMode.OnMouseDown(e);
                    break;
                case ObjectMode.Entrances:
                    this.entranceMode.onMouseDown(e);
                    break;
                case ObjectMode.Itemmode:
                    this.itemMode.onMouseDown(e);
                    break;
                case ObjectMode.Spritemode:
                    this.spriteMode.onMouseDown(e);
                    break;
                case ObjectMode.Flute:
                    this.transportMode.onMouseDown(e);
                    break;
                case ObjectMode.Gravestone:
                    this.gravestoneMode.onMouseDown(e);
                    break;
                case ObjectMode.Notemode:
                    this.noteMode.onMouseDown(e);
                    break;
            }

            this.InvalidateHighEnd();

            base.OnMouseDown(e);
        }

        // TODO switch statements
        private unsafe void onMouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Middle)
            {
                pan = false;
            }


            this.owForm.objCombobox.Items.Clear();
            this.owForm.objCombobox.SelectedIndexChanged -= this.ObjCombobox_SelectedIndexChangedSprite;
            this.owForm.objCombobox.SelectedIndexChanged -= this.ObjCombobox_SelectedIndexChangedItem;
            string text = "Selected object: ";

            if (this.selectedMode == ObjectMode.Tile)
            {
                text = "Selected Tile " + selectedTile[0].ToString("X4") + "   Selected Map " + ow.AllMaps[selectedMap].ParentID.ToString("X2");
                this.tilemode.OnMouseUp(e);
            }
            else if (this.selectedMode == ObjectMode.Overlay)
            {
                this.overlayMode.OnMouseUp(e);
            }
            else if (this.selectedMode == ObjectMode.OverlayAnimation)
            {
                this.overlayAnimationMode.OnMouseUp(e);
            }
            else if (this.selectedMode == ObjectMode.Exits)
            {
                this.exitmode.onMouseUp(e);
                text += "Exit";
                if (this.exitmode.lastselectedExit != null)
                {
                    this.owForm.SetSelectedObjectLabels(
                        this.exitmode.lastselectedExit.MapID,
                        this.exitmode.lastselectedExit.PlayerX,
                        this.exitmode.lastselectedExit.PlayerY);
                }
            }
            else if (this.selectedMode == ObjectMode.OWDoor)
            {
                //doorMode.onMouseUp(e);
            }
            else if (this.selectedMode == ObjectMode.Entrances)
            {
                this.entranceMode.onMouseUp(e);
                text += "Entrance";

                if (this.entranceMode.lastselectedEntrance != null)
                {
                    this.owForm.SetSelectedObjectLabels(
                        this.entranceMode.lastselectedEntrance.EntranceID,
                        this.entranceMode.lastselectedEntrance.X,
                        this.entranceMode.lastselectedEntrance.Y);
                }
            }
            else if (this.selectedMode == ObjectMode.Itemmode)
            {
                this.itemMode.onMouseUp(e);
                text += "Item";

                if (this.itemMode.lastselectedItem != null)
                {
                    this.owForm.SetSelectedObjectLabels(
                        this.itemMode.lastselectedItem.ID,
                        this.itemMode.lastselectedItem.X,
                        this.itemMode.lastselectedItem.Y);

                    this.owForm.objCombobox.Items.AddRange(ItemsNames.name);

                    if ((this.itemMode.lastselectedItem.ID & 0x80) == 0x80)
                    {
                        this.owForm.objCombobox.SelectedIndex = (23 + ((this.itemMode.lastselectedItem.ID - 0x80) / 2));
                    }
                    else
                    {
                        this.owForm.objCombobox.SelectedIndex = this.itemMode.lastselectedItem.ID;
                    }

                    this.owForm.objCombobox.SelectedIndexChanged += this.ObjCombobox_SelectedIndexChangedItem;
                }
            }
            else if (this.selectedMode == ObjectMode.Spritemode)
            {
                this.spriteMode.onMouseUp(e);
                text += "Sprite";

                if (this.spriteMode.lastselectedSprite != null)
                {
                    this.owForm.SetSelectedObjectLabels(
                        this.spriteMode.lastselectedSprite.id,
                        this.spriteMode.lastselectedSprite.x,
                        this.spriteMode.lastselectedSprite.y);
                    this.owForm.objCombobox.Items.AddRange(Sprites_Names.name);
                    this.owForm.objCombobox.SelectedIndex = this.spriteMode.lastselectedSprite.id;

                    this.owForm.objCombobox.SelectedIndexChanged += this.ObjCombobox_SelectedIndexChangedSprite;
                }
            }
            else if (this.selectedMode == ObjectMode.Flute)
            {
                this.transportMode.onMouseUp(e);
                text += "Transport";

                if (this.transportMode.lastselectedTransport != null)
                {
                    this.owForm.SetSelectedObjectLabels(
                        this.transportMode.lastselectedTransport.mapId,
                        this.transportMode.lastselectedTransport.playerX,
                        this.transportMode.lastselectedTransport.playerY);
                }
            }
            else if (this.selectedMode == ObjectMode.Gravestone)
            {
                this.gravestoneMode.OnMouseUp(e);
            }
            else if (this.selectedMode == ObjectMode.Notemode)
            {
                    this.noteMode.onMouseUp(e);
            }

            this.owForm.objectGroupbox.Text = text;
            this.InvalidateHighEnd();
        }

        private void ObjCombobox_SelectedIndexChangedSprite(object sender, EventArgs e)
        {
            this.spriteMode.lastselectedSprite.id = (byte)this.owForm.objCombobox.SelectedIndex;
            this.spriteMode.lastselectedSprite.name = this.owForm.objCombobox.Text;

            this.InvalidateHighEnd();
        }

        private void InvalidateHighEnd()
        {
            if (this.lowEndMode)
            {
                int x = this.ow.AllMaps[this.selectedMap].ParentID % 8;
                int y = this.ow.AllMaps[this.selectedMap].ParentID / 8;
                if (!this.ow.AllMaps[this.ow.AllMaps[this.selectedMap].ParentID].LargeMap)
                {
                    this.Invalidate(new Rectangle(x * 512, y * 512, 512, 512));
                }
                else
                {
                    this.Invalidate(new Rectangle(x * 512, y * 512, 1024, 1024));
                }
            }
            else
            {
                this.Invalidate(
                    new Rectangle(
                        this.owForm.splitContainer1.Panel2.HorizontalScroll.Value,
                        this.owForm.splitContainer1.Panel2.VerticalScroll.Value,
                        this.owForm.splitContainer1.Panel2.Width,
                        this.owForm.splitContainer1.Panel2.Height)
                );
            }
        }

        private void ObjCombobox_SelectedIndexChangedItem(object sender, EventArgs e)
        {
            byte id = (byte)this.owForm.objCombobox.SelectedIndex;
            if (this.owForm.objCombobox.SelectedIndex >= 23)
            {
                id = (byte)(((this.owForm.objCombobox.SelectedIndex - 23) * 2) + 0x80);
            }

            this.itemMode.lastselectedItem.ID = id;
            this.itemMode.SendItemData(this.itemMode.lastselectedItem);
            this.InvalidateHighEnd();
        }

        private void onMouseMove(object sender, MouseEventArgs e)
        {
            if (pan)
            {
                scrollingPoint = mainForm.PointToClient(Cursor.Position); // use mainform since it doesn't scroll!

                //calculate the difference between scrollingpoint and starting point here
                Point panPoint = new Point((scrollingPoint.X - startingPoint.X), (scrollingPoint.Y - startingPoint.Y));
                //startingPoint = scrollingPoint; // update it every frames because of scrollbar that value will increase expotentially
                HScrollProperties hScroll = mainForm.overworldEditor.splitContainer1.Panel2.HorizontalScroll;
                VScrollProperties vScroll = mainForm.overworldEditor.splitContainer1.Panel2.VerticalScroll;

                if (hScroll.Value >= 0 && hScroll.Value < hScroll.Maximum)
                {
                    int tempValue = startpanPoint.X - (panPoint.X);
                    tempValue = tempValue.Clamp(0, hScroll.Maximum);
                    hScroll.Value = tempValue;
                }
                if (vScroll.Value >= 0 && vScroll.Value < vScroll.Maximum)
                {
                    int tempValue = startpanPoint.Y - (panPoint.Y);
                    tempValue = tempValue.Clamp(0, vScroll.Maximum);
                    vScroll.Value = tempValue;
                }

                //this.InvalidateHighEnd();
                return; // prevent running extra code
            }


            switch (this.selectedMode)
            {
                case ObjectMode.Tile:
                    this.tilemode.OnMouseMove(e);
                    break;
                case ObjectMode.Overlay:
                    this.overlayMode.OnMouseMove(e);
                    break;
                case ObjectMode.OverlayAnimation:
                    this.overlayAnimationMode.OnMouseMove(e);
                    break;
                case ObjectMode.Exits:
                    this.exitmode.onMouseMove(e);
                    break;
                case ObjectMode.OWDoor:
                    this.doorMode.onMouseMove(e);
                    break;
                case ObjectMode.Entrances:
                    this.entranceMode.onMouseMove(e);
                    break;
                case ObjectMode.Itemmode:
                    this.itemMode.onMouseMove(e);
                    break;
                case ObjectMode.Spritemode:
                    this.spriteMode.onMouseMove(e);
                    break;
                case ObjectMode.Flute:
                    this.transportMode.onMouseMove(e);
                    break;
                case ObjectMode.Gravestone:
                    this.gravestoneMode.OnMouseMove(e);
                    break;
                case ObjectMode.Notemode:
                    this.noteMode.onMouseMove(e);
                    break;
            }

            this.InvalidateHighEnd();
        }

        public void Undo()
        {
            if (!NetZS.connected)
            {
                this.tilemode.Undo();
                this.InvalidateHighEnd();
            }
        }

        public void Redo()
        {
            if (!NetZS.connected)
            {
                this.tilemode.Redo();
                this.InvalidateHighEnd();
            }
        }

        public override void paste()
        {
            switch (this.selectedMode)
            {
                case ObjectMode.Tile:
                    this.tilemode.Paste();
                    break;
                case ObjectMode.Overlay:
                    //this.overlayMode.Paste();
                    break;
                case ObjectMode.Exits:
                    this.exitmode.Paste();
                    break;
                case ObjectMode.OWDoor:
                    //this.doorMode.Paste();
                    break;
                case ObjectMode.Entrances:
                    this.entranceMode.Paste();
                    break;
                case ObjectMode.Itemmode:
                    this.itemMode.Paste();
                    break;
                case ObjectMode.Spritemode:
                    this.spriteMode.Paste();
                    break;
                case ObjectMode.Flute:
                    //this.transportMode.Paste();
                    break;
                case ObjectMode.Gravestone:
                    //this.gravestoneMode.Paste();
                    break;
            }

            this.InvalidateHighEnd();
        }

        public override void copy()
        {
            switch (this.selectedMode)
            {
                case ObjectMode.Tile:
                    this.tilemode.Copy();
                    break;
                case ObjectMode.Overlay:
                    //this.overlayMode.Copy();
                    break;
                case ObjectMode.Exits:
                    this.exitmode.Copy();
                    break;
                case ObjectMode.OWDoor:
                    //this.doorMode.Copy();
                    break;
                case ObjectMode.Entrances:
                    this.entranceMode.Copy();
                    break;
                case ObjectMode.Itemmode:
                    this.itemMode.Copy();
                    break;
                case ObjectMode.Spritemode:
                    this.spriteMode.Copy();
                    break;
                case ObjectMode.Flute:
                    //this.transportMode.Copy();
                    break;
                case ObjectMode.Gravestone:
                    //this.gravestoneMode.Copy();
                    break;
            }

            this.InvalidateHighEnd();
        }

        public override void cut()
        {
            switch (this.selectedMode)
            {
                case ObjectMode.Tile:
                    //this.tilemode.Cut();
                    break;
                case ObjectMode.Overlay:
                    //this.overlayMode.Cut();
                    break;
                case ObjectMode.Exits:
                    this.exitmode.Cut();
                    break;
                case ObjectMode.OWDoor:
                    //this.doorMode.Cut();
                    break;
                case ObjectMode.Entrances:
                    this.entranceMode.Cut();
                    break;
                case ObjectMode.Itemmode:
                    this.itemMode.Cut();
                    break;
                case ObjectMode.Spritemode:
                    this.spriteMode.Cut();
                    break;
                case ObjectMode.Flute:
                    //this.transportMode.Cut();
                    break;
                case ObjectMode.Gravestone:
                    //this.gravestoneMode.Cut();
                    break;
            }

            this.InvalidateHighEnd();
        }

        /// <summary>
        ///     Creates a map32 tile map and saves the overworld tiles in the rom.
        /// </summary>
        /// <returns> True if saving failed. For example if the unique tile32 limit was passed. </returns>
        public bool SaveTiles()
        {
            if (!this.ow.CreateTile32Tilemap())
            {
                this.ow.Save32Tiles();
                //this.ow.savemapstorom();
                this.ow.SaveMap16Tiles();

                return false;
            }
            else
            {
                return true;
            }
        }

        Pen camPen = new Pen(Color.Red, 2);
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
            g.PixelOffsetMode = PixelOffsetMode.Half;

            if (this.initialized)
            {
                int x = 0;
                int y = 0;


                for (int i = ow.WorldOffset; i < 64 + ow.WorldOffset; i++)
                {
                    
                    if (i <= 0x9F)
                    {
                        ushort subscreenOverlay = ow.AllMaps[i].SubscreenOverlay;

                        g.CompositingMode = CompositingMode.SourceCopy; // Why over?

                        // Draw the base image (either a BG color or tilemap like the pyramid BG).
                        if (mainForm.overworldOverlayVisibleToolStripMenuItem.Checked)
                        {
                            // everything that is not these 3 should be drawn on top.
                            // 0x95 is the sky BG, 0x96 is the pyramid BG, and 0x9C is the lava BG.
                            if (subscreenOverlay == 0x95 || subscreenOverlay == 0x96 || subscreenOverlay == 0x9C)
                            {
                                g.DrawImage(ow.AllMaps[subscreenOverlay].GFXBitmap, new PointF(x * 512, y * 512));
                            }
                        }

                        g.FillRectangle(new SolidBrush(Palettes.OverworldBackgroundPalette[ow.AllMaps[i].ParentID]), new RectangleF(x * 512, y * 512, 512, 512));
                        g.CompositingMode = CompositingMode.SourceOver;
                        // Draw the actual tile maps.
                        g.DrawImage(ow.AllMaps[i].GFXBitmap, new PointF(x * 512, y * 512));

                        // Draw any subscreen overlays that go on top.
                        if (mainForm.overworldOverlayVisibleToolStripMenuItem.Checked)
                        {
                            // everything that is not these 3 should be drawn on top.
                            // 0x95 is the sky BG, 0x96 is the pyramid BG, and 0x9C is the lava BG.
                            // 0x93 is the second triforce room, 0x94 is the second master sword/ bridge area, 0x97 is the first fog, 0x9D is the second fog, 0x9E is the tree canopy, 0x9F is the rain.
                            if (subscreenOverlay != 0x95 && subscreenOverlay != 0x96 && subscreenOverlay != 0x9C && subscreenOverlay < 0xA0)
                            {
                                g.DrawImage(this.ow.AllMaps[subscreenOverlay].GFXBitmap, new Rectangle(x * 512, y * 512, 512, 512), 0, 0, 512, 512, GraphicsUnit.Pixel, ia);
                            }
                        }


                    }
                    x++;
                    if (x >= 8)
                    {
                        x = 0;
                        y++;
                    }
                }

                g.CompositingMode = CompositingMode.SourceOver;

                if (this.selecting)
                {
                    g.DrawRectangle(Pens.White, new Rectangle(this.globalmouseTileDownX * 16, this.globalmouseTileDownY * 16, (((this.mouseX_Real / 16) - this.globalmouseTileDownX) * 16) + 16, (((this.mouseY_Real / 16) - this.globalmouseTileDownY) * 16) + 16));
                }

                if (this.selectedMode == ObjectMode.OWDoor || this.selectedMode == ObjectMode.Tile)
                {
                    g.DrawImage(this.tilesgfxBitmap, new Rectangle((this.mouseX_Real / 16) * 16, (this.mouseY_Real / 16) * 16, this.selectedTileSizeX * 16, (this.selectedTile.Length / this.selectedTileSizeX) * 16), 0, 0, this.selectedTileSizeX * 16, (this.selectedTile.Length / this.selectedTileSizeX) * 16, GraphicsUnit.Pixel, ia);
                    g.DrawRectangle(Pens.LightGreen, new Rectangle((this.mouseX_Real / 16) * 16, (this.mouseY_Real / 16) * 16, this.selectedTileSizeX * 16, (this.selectedTile.Length / this.selectedTileSizeX) * 16));
                }

                
                if (showLinkCamera)
                {
                    if (this.ow.AllMaps[this.ow.AllMaps[this.mapHover].ParentID].LargeMap)
                    {
                        int my = (this.ow.AllMaps[this.mapHover].ParentID) / 8;
                        int mx = (this.ow.AllMaps[this.mapHover].ParentID) - (my * 8);
                        int camX = mouseX_Real = mouseX_Real - (mx*512) - 120;
                        int camY = mouseY_Real = mouseY_Real - (my*512) - 104;
                        if ((camX + 256) >= 1024)
                        {
                            camX = (1024 - 256);
                        }
                        if ((camX) < 0)
                        {
                            camX = 0;
                        }

                        if ((camY + 224) >= 1024)
                        {
                            camY = (1024 - 224);
                        }
                        if ((camY) < 0)
                        {
                            camY = 0;
                        }
                        g.DrawRectangle(camPen, new Rectangle(camX + (mx * 512), camY + (my * 512), 256, 224));
                    }
                    else
                    {
                        int my = (this.ow.AllMaps[this.mapHover].ParentID) / 8;
                        int mx = (this.ow.AllMaps[this.mapHover].ParentID) - (my * 8);
                        int camX = (mouseX_Real % 512) - 120;
                        int camY = (mouseY_Real % 512) - 104;
                        if ((camX + 256) >= 512)
                        {
                            camX = (512 - 256);
                        }
                        if ((camX) < 0)
                        {
                            camX = 0;
                        }

                        if ((camY + 224) >= 512)
                        {
                            camY = (512 - 224);
                        }
                        if ((camY) < 0)
                        {
                            camY = 0;
                        }
                        g.DrawRectangle(camPen, new Rectangle(camX + (mx * 512), camY + (my * 512), 256, 224));
                    }
                    
                }


                int offset = 0;
                if (this.selectedMap >= 128)
                {
                    offset = 128;
                }

                if ((this.mapHover + offset) < this.ow.AllMaps.Length)
                {
                    int my = (this.ow.AllMaps[this.mapHover + offset].ParentID - offset) / 8;
                    int mx = (this.ow.AllMaps[this.mapHover + offset].ParentID - offset) - (my * 8);

                    if (this.ow.AllMaps[this.mapHover + offset].LargeMap)
                    {
                        g.DrawRectangle(Pens.Orange, new Rectangle(mx * 512, my * 512, 1024, 1024));
                    }
                    else
                    {
                        g.DrawRectangle(Pens.Orange, new Rectangle(mx * 512, my * 512, 512, 512));
                    }
                }

                if (this.showExits)
                {
                    this.exitmode.Draw(g);
                }

                if (this.showEntrances)
                {
                    this.entranceMode.Draw(g);
                }

                if (this.showItems)
                {
                    this.itemMode.Draw(g);
                }

                // TODO: Only draw the graves on the LW for now but this should be changed later.
                if (this.ow.WorldOffset == 0)
                {
                    this.gravestoneMode.Draw(g);
                }

                if (this.showSprites)
                {
                    this.spriteMode.Draw(g);
                }

                if (this.showFlute)
                {
                    this.transportMode.Draw(g);
                }

                this.noteMode.Draw(g);

                if (this.entrancePreview)
                {
                    if (this.entranceMode.selectedEntrance != null)
                    {
                        g.DrawImage(this.owForm.tmpPreviewBitmap, this.entranceMode.selectedEntrance.X + 16, this.entranceMode.selectedEntrance.Y + 16);
                    }

                    if (this.exitmode.selectedExit != null)
                    {
                        g.DrawImage(this.owForm.tmpPreviewBitmap, this.exitmode.selectedExit.PlayerX + 16, this.exitmode.selectedExit.PlayerY + 16);
                    }
                }

                if (this.selectedMode == ObjectMode.Overlay)
                {
                    int mid = this.ow.AllMaps[this.selectedMap].ParentID;
                    int msy = (this.ow.AllMaps[this.selectedMap].ParentID - this.ow.WorldOffset) / 8;
                    int msx = (this.ow.AllMaps[this.selectedMap].ParentID - this.ow.WorldOffset) - (msy * 8);
                    if (showOverlayText)
                    {
                        this.drawText(g, (msx * 512) + 4, (msy * 512) + 64, "Selected Map : " + this.selectedMap.ToString("X2"));
                        this.drawText(g, (msx * 512) + 4, (msy * 512) + 80, "Selected Map PARENT : " + this.ow.AllMaps[this.selectedMap].ParentID.ToString("X2"));
                        this.drawText(g, (msx * 512) + 4, (msy * 512) + 4, "use ctrl key + click to delete overlay tiles");
                    }
                    for (int i = 0; i < this.ow.AllOverlays[mid].TileDataList.Count; i++)
                    {
                        int xo = this.ow.AllOverlays[mid].TileDataList[i].x * 16;
                        int yo = this.ow.AllOverlays[mid].TileDataList[i].y * 16;
                        int to = this.ow.AllOverlays[mid].TileDataList[i].tileId;
                        int toy = (to / 8) * 16;
                        int tox = (to % 8) * 16;
                        g.DrawImage(GFX.mapblockset16Bitmap, new Rectangle((msx * 512) + xo, (msy * 512) + yo, 16, 16), new Rectangle(tox, toy, 16, 16), GraphicsUnit.Pixel);

                        // g.DrawImage(GFX.currentOWgfx16Bitmap, new Rectangle(0, 0, 64, 64), new Rectangle(0, 0, 64, 64), GraphicsUnit.Pixel);
                        byte detect = this.compareTilePos(this.ow.AllOverlays[mid].TileDataList[i], this.ow.AllOverlays[mid].TileDataList.ToArray());

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

                    g.DrawImage(this.tilesgfxBitmap, new Rectangle((this.mouseX_Real / 16) * 16, (this.mouseY_Real / 16) * 16, this.selectedTileSizeX * 16, (this.selectedTile.Length / this.selectedTileSizeX) * 16), 0, 0, this.selectedTileSizeX * 16, (this.selectedTile.Length / this.selectedTileSizeX) * 16, GraphicsUnit.Pixel, ia);
                    g.DrawRectangle(Pens.LightGreen, new Rectangle((this.mouseX_Real / 16) * 16, (this.mouseY_Real / 16) * 16, this.selectedTileSizeX * 16, (this.selectedTile.Length / this.selectedTileSizeX) * 16));

                    this.drawText(g, 4, 24, this.globalmouseTileDownX.ToString());
                    this.drawText(g, 4, 48, this.globalmouseTileDownY.ToString());
                }
                else if (this.selectedMode == ObjectMode.OverlayAnimation)
                {
                    int mid = this.ow.AllMaps[this.selectedMap].ParentID;
                    int msy = (this.ow.AllMaps[this.selectedMap].ParentID - this.ow.WorldOffset) / 8;
                    int msx = (this.ow.AllMaps[this.selectedMap].ParentID - this.ow.WorldOffset) - (msy * 8);
                    if (showOverlayText)
                    {
                        this.drawText(g, (msx * 512) + 4, (msy * 512) + 96, "use mouse wheel to change frame");
                        this.drawText(g, (msx * 512) + 4, (msy * 512) + 32, "use shift key to display the whole animation");
                        this.drawText(g, (msx * 512) + 4, (msy * 512) + 64, "Selected Frame (dec) : " + this.overlayAnimationMode.selectedFrame);
                        this.drawText(g, (msx * 512) + 4, (msy * 512) + 80, "Selected Map PARENT : " + this.ow.AllMaps[this.selectedMap].ParentID.ToString("X2"));
                        this.drawText(g, (msx * 512) + 4, (msy * 512) + 4, "use ctrl key + click to delete overlay tiles");
                    }
                    Pen p2 = new Pen(new SolidBrush(Color.FromArgb(255, 0, 0, 255)));
                    if (overlayAnimationMode.selectedFrame != 0 || ModifierKeys == Keys.Shift)
                    {
                        if (ModifierKeys == Keys.Shift)
                        {
                            for (int j = 0; j < 255; j++)
                            {
                                for (int i = 0; i < this.ow.AllAnimationOverlays[mid].FramesList[j].Count; i++)
                                {
                                    int xo = this.ow.AllAnimationOverlays[mid].FramesList[j][i].x * 16;
                                    int yo = this.ow.AllAnimationOverlays[mid].FramesList[j][i].y * 16;
                                    int to = this.ow.AllAnimationOverlays[mid].FramesList[j][i].tileId;
                                    int toy = (to / 8) * 16;
                                    int tox = (to % 8) * 16;
                                    g.DrawImage(GFX.mapblockset16Bitmap, new Rectangle((msx * 512) + xo, (msy * 512) + yo, 16, 16), tox, toy, 16, 16, GraphicsUnit.Pixel, ia);
                                }
                            }

                        }
                        else
                        {

                            Pen p = new Pen(new SolidBrush(Color.FromArgb(64, 0, 0, 255)));
                            for (int i = 0; i < this.ow.AllAnimationOverlays[mid].FramesList[this.overlayAnimationMode.selectedFrame - 1].Count; i++)
                            {
                                int xo = this.ow.AllAnimationOverlays[mid].FramesList[this.overlayAnimationMode.selectedFrame - 1][i].x * 16;
                                int yo = this.ow.AllAnimationOverlays[mid].FramesList[this.overlayAnimationMode.selectedFrame - 1][i].y * 16;
                                int to = this.ow.AllAnimationOverlays[mid].FramesList[this.overlayAnimationMode.selectedFrame - 1][i].tileId;
                                int toy = (to / 8) * 16;
                                int tox = (to % 8) * 16;
                                g.DrawImage(GFX.mapblockset16Bitmap, new Rectangle((msx * 512) + xo, (msy * 512) + yo, 16, 16), tox, toy, 16, 16, GraphicsUnit.Pixel, ia);

                                // g.DrawImage(GFX.currentOWgfx16Bitmap, new Rectangle(0, 0, 64, 64), new Rectangle(0, 0, 64, 64), GraphicsUnit.Pixel);
                                byte detect = this.compareTilePos(this.ow.AllAnimationOverlays[mid].FramesList[this.overlayAnimationMode.selectedFrame - 1][i], this.ow.AllAnimationOverlays[mid].FramesList[this.overlayAnimationMode.selectedFrame - 1].ToArray());

                                if (detect == 0)
                                {
                                    g.DrawRectangle(p, new Rectangle((msx * 512) + xo, (msy * 512) + yo, (msx * 512) + 16, (msy * 512) + 16));
                                }

                                if ((detect & 0x01) != 0x01)
                                {
                                    g.DrawLine(p, (msx * 512) + xo, (msy * 512) + yo, (msx * 512) + xo, (msy * 512) + yo + 16);
                                }

                                if ((detect & 0x02) != 0x02)
                                {
                                    g.DrawLine(p, (msx * 512) + xo, (msy * 512) + yo, (msx * 512) + xo + 16, (msy * 512) + yo);
                                }

                                if ((detect & 0x04) != 0x04)
                                {
                                    g.DrawLine(p, (msx * 512) + xo + 16, (msy * 512) + yo, (msx * 512) + xo + 16, (msy * 512) + yo + 16);
                                }

                                if ((detect & 0x08) != 0x08)
                                {
                                    g.DrawLine(p, (msx * 512) + xo, (msy * 512) + yo + 16, (msx * 512) + xo + 16, (msy * 512) + yo + 16);
                                }
                            }
                        }
                    }
                    for (int i = 0; i < this.ow.AllAnimationOverlays[mid].FramesList[this.overlayAnimationMode.selectedFrame].Count; i++)
                    {

                        int xo = this.ow.AllAnimationOverlays[mid].FramesList[this.overlayAnimationMode.selectedFrame][i].x * 16;
                        int yo = this.ow.AllAnimationOverlays[mid].FramesList[this.overlayAnimationMode.selectedFrame][i].y * 16;
                        int to = this.ow.AllAnimationOverlays[mid].FramesList[this.overlayAnimationMode.selectedFrame][i].tileId;
                        int toy = (to / 8) * 16;
                        int tox = (to % 8) * 16;
                        g.DrawImage(GFX.mapblockset16Bitmap, new Rectangle((msx * 512) + xo, (msy * 512) + yo, 16, 16), new Rectangle(tox, toy, 16, 16), GraphicsUnit.Pixel);

                        // g.DrawImage(GFX.currentOWgfx16Bitmap, new Rectangle(0, 0, 64, 64), new Rectangle(0, 0, 64, 64), GraphicsUnit.Pixel);
                        byte detect = this.compareTilePos(this.ow.AllAnimationOverlays[mid].FramesList[this.overlayAnimationMode.selectedFrame][i], this.ow.AllAnimationOverlays[mid].FramesList[this.overlayAnimationMode.selectedFrame].ToArray());

                        if (detect == 0)
                        {
                            g.DrawRectangle(p2, new Rectangle((msx * 512) + xo, (msy * 512) + yo, (msx * 512) + 16, (msy * 512) + 16));
                        }

                        if ((detect & 0x01) != 0x01)
                        {
                            g.DrawLine(p2, (msx * 512) + xo, (msy * 512) + yo, (msx * 512) + xo, (msy * 512) + yo + 16);
                        }

                        if ((detect & 0x02) != 0x02)
                        {
                            g.DrawLine(p2, (msx * 512) + xo, (msy * 512) + yo, (msx * 512) + xo + 16, (msy * 512) + yo);
                        }

                        if ((detect & 0x04) != 0x04)
                        {
                            g.DrawLine(p2, (msx * 512) + xo + 16, (msy * 512) + yo, (msx * 512) + xo + 16, (msy * 512) + yo + 16);
                        }

                        if ((detect & 0x08) != 0x08)
                        {
                            g.DrawLine(p2, (msx * 512) + xo, (msy * 512) + yo + 16, (msx * 512) + xo + 16, (msy * 512) + yo + 16);
                        }
                    }
 

                    g.DrawImage(this.tilesgfxBitmap, new Rectangle((this.mouseX_Real / 16) * 16, (this.mouseY_Real / 16) * 16, this.selectedTileSizeX * 16, (this.selectedTile.Length / this.selectedTileSizeX) * 16), 0, 0, this.selectedTileSizeX * 16, (this.selectedTile.Length / this.selectedTileSizeX) * 16, GraphicsUnit.Pixel, ia);
                    g.DrawRectangle(Pens.LightGreen, new Rectangle((this.mouseX_Real / 16) * 16, (this.mouseY_Real / 16) * 16, this.selectedTileSizeX * 16, (this.selectedTile.Length / this.selectedTileSizeX) * 16));

                    this.drawText(g, 4, 24, this.globalmouseTileDownX.ToString());
                    this.drawText(g, 4, 48, this.globalmouseTileDownY.ToString());
                }

                    if (this.owForm.gridDisplay != 0)
                {
                    int gridsize = 512;
                    if (this.ow.AllMaps[this.ow.AllMaps[this.selectedMap].ParentID].LargeMap)
                    {
                        gridsize = 1024;
                    }

                    int temp = this.selectedMap;
                    temp %= 64;

                    x = this.ow.AllMaps[temp].ParentID % 8;
                    y = this.ow.AllMaps[temp].ParentID / 8;

                    for (int gx = 0; gx < (gridsize / this.owForm.gridDisplay); gx++)
                    {
                        g.DrawLine(
                            Constants.ThirdWhitePen1,
                            new Point((x * 512) + (gx * this.owForm.gridDisplay), y * 512),
                            new Point((x * 512) + (gx * this.owForm.gridDisplay), (y * 512) + gridsize));
                    }

                    for (int gy = 0; gy < (gridsize / this.owForm.gridDisplay); gy++)
                    {
                        g.DrawLine(
                            Constants.ThirdWhitePen1,
                            new Point((x * 512), (y * 512) + (gy * this.owForm.gridDisplay)),
                            new Point((x * 512) + gridsize, (y * 512) + (gy * this.owForm.gridDisplay)));
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
            this.ow.AllMaps[this.selectedMap].LoadPalette();
        }

        public override void deleteSelected()
        {
            switch (this.selectedMode)
            {
                case ObjectMode.Tile:
                    //this.tilemode.Delete();
                    break;
                case ObjectMode.Overlay:
                    //this.overlayMode.Delete();
                    break;
                case ObjectMode.Exits:
                    this.exitmode.Delete();
                    break;
                case ObjectMode.OWDoor:
                    //this.doorMode.Delete();
                    break;
                case ObjectMode.Entrances:
                    this.entranceMode.Delete();
                    break;
                case ObjectMode.Itemmode:
                    this.itemMode.Delete();
                    break;
                case ObjectMode.Spritemode:
                    this.spriteMode.Delete();
                    break;
                case ObjectMode.Flute:
                    //this.transportMode.Delete();
                    break;
                case ObjectMode.Gravestone:
                    //this.gravestoneMode.Delete();
                    break;
                case ObjectMode.Notemode:
                    this.noteMode.Delete();
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
            if (this.selectedMode == ObjectMode.Entrances)
            {
                this.entranceMode.onMouseDoubleClick(e);
            }
        }

        private void InitializeComponent()
        {
            ((ISupportInitialize)this).BeginInit();
            this.SuspendLayout();
            ((ISupportInitialize)this).EndInit();
            this.ResumeLayout(false);
        }
    }
}
