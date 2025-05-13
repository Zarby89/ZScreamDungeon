using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Lidgren.Network;
using ZeldaFullEditor.Gui.ExtraForms;
using ZeldaFullEditor.Properties;
using static ZeldaFullEditor.OverworldMap;

namespace ZeldaFullEditor.Gui
{
    public partial class OverworldEditor : UserControl
    {
        public Overworld overworld;
        public SceneOW scene;
        public bool propertiesChangedFromForm = false;
        public DungeonMain mainForm;
        public Bitmap tmpPreviewBitmap = new Bitmap(256, 256);
        public Bitmap scratchPadBitmap = new Bitmap(256, 3600);
        public ushort[,] scratchPadTiles = new ushort[16, 225];

        public byte gridDisplay = 0;
        private bool mouse_down = false;

        private bool selecting = false;
        private int globalmouseTileDownX = 0;
        private int globalmouseTileDownY = 0;
        private int mouseX_Real = 0;
        private int mouseY_Real = 0;
        private int lastTileHoverX = 0;
        private int lastTileHoverY = 0;

        private byte palSelected = 0;
        private int tile8selected = 0;

        private readonly ColorDialog cd = new ColorDialog();

        public static bool UseAreaSpecificBgColor = true;
        public static bool scratchPadGrid = false;
        public bool showUnusedTile16 = false;
        public bool showUsedTile32 = false;

        bool fromForm = false;

        Pen selectionPen = new Pen(Color.LimeGreen, 2);
        Brush unusedTile = new SolidBrush(Color.FromArgb(80, 255, 0, 0));

        public OverworldEditor()
        {
            InitializeComponent();
        }

        public void InitOpen(DungeonMain mainForm)
        {
            this.overworld = new Overworld();
            this.scene = new SceneOW(this, this.overworld, mainForm);
            this.scene.Location = Constants.Point_0_0;
            this.scene.Size = Constants.Size4096x4096;
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(this.scene);
            this.mainForm = mainForm;
            this.scene.CreateScene();
            this.scene.initialized = true;
            this.scene.Refresh();
            this.penModeButton.Tag = ObjectMode.Tile;
            this.fillModeButton.Tag = ObjectMode.FillTile;
            this.entranceModeButton.Tag = ObjectMode.Entrances;
            this.exitModeButton.Tag = ObjectMode.Exits;
            this.itemModeButton.Tag = ObjectMode.Itemmode;
            this.spriteModeButton.Tag = ObjectMode.Spritemode;
            this.transportModeButton.Tag = ObjectMode.Flute;
            this.overlayButton.Tag = ObjectMode.Overlay;
            this.gravestoneButton.Tag = ObjectMode.Gravestone;
            this.noteMode.Tag = ObjectMode.Notemode;
            this.overlayAnimationButton.Tag = ObjectMode.OverlayAnimation;
            this.stateCombobox.SelectedIndex = 1;
            this.scratchPicturebox.Image = this.scratchPadBitmap;

            music1Box.Items.AddRange(Constants.musicNamesOW);
            music2Box.Items.AddRange(Constants.musicNamesOW);
            music3Box.Items.AddRange(Constants.musicNamesOW);
            music4Box.Items.AddRange(Constants.musicNamesOW);

            ambient1Box.Items.AddRange(Constants.ambientNamesOW);
            ambient2Box.Items.AddRange(Constants.ambientNamesOW);
            ambient3Box.Items.AddRange(Constants.ambientNamesOW);
            ambient4Box.Items.AddRange(Constants.ambientNamesOW);

            for (int i = 0; i < overworld.AllEntrances.Length; i++)
            {
                string tname = "OW[" + i.ToString("X2") + "] -> UW";
                if (overworld.AllEntrances[i].Deleted)
                {
                    tname = "OW[" + i.ToString("X2") + "] DELETED";
                    owentrancesListbox.Items.Add(tname);

                    continue;
                }

                foreach (DataRoom dataRoom in ROMStructure.dungeonsRoomList)
                {
                    if (dataRoom.ID == DungeonsData.Entrances[overworld.AllEntrances[i].EntranceID].Room)
                    {
                        tname += "[" + overworld.AllEntrances[i].EntranceID.ToString("X2") + "]" + dataRoom.Name;

                        break;
                    }
                }

                owentrancesListbox.Items.Add(tname);
            }

            for (int i = 0; i < overworld.AllExits.Length; i++)
            {
                string tname = "Exit [" + i.ToString("X2") + "] -> From room " + overworld.AllExits[i].RoomID.ToString("X4");
                if (overworld.AllExits[i].RoomID >= 320)
                {
                    tname += " Ending Cutscene";
                }

                if (overworld.AllExits[i].PlayerX == 0xFFFF)
                {
                    tname += " DELETED";
                }

                overworldexitsListbox.Items.Add(tname);
            }

            owentrancesListbox.SelectedIndex = 0;
            overworldexitsListbox.SelectedIndex = 0;

            //setTilesGfx();
            bool fromFile = false;
            byte[] file = new byte[(225 * 16) * 2];

            if (File.Exists("ScratchPad.dat"))
            {
                using (FileStream fs = new FileStream("ScratchPad.dat", FileMode.Open, FileAccess.Read))
                {
                    fs.Read(file, 0, (int)fs.Length);
                    fs.Close();
                    fromFile = true;
                }
            }

            int t = 0;
            for (ushort x = 0; x < 225; x++)
            {
                for (ushort y = 0; y < 16; y++, t += 2)
                {
                    this.scratchPadTiles[y, x] = fromFile ? (ushort)((file[t] << 8) + file[t + 1]) : (ushort)0;
                }
            }

            GFX.editort16Bitmap.Palette = this.scene.ow.AllMaps[this.scene.selectedMap].GFXBitmap.Palette;
            this.UpdateTiles();
            this.pictureBox1.Refresh();
        }

        public void saveScratchPad()
        {
            byte[] file = new byte[(225 * 16) * 2];

            int t = 0;
            for (ushort x = 0; x < 225; x++)
            {
                for (ushort y = 0; y < 16; y++)
                {
                    file[t++] = (byte)((this.scratchPadTiles[y, x] >> 8) & 0xFF);
                    file[t++] = (byte)(this.scratchPadTiles[y, x] & 0xFF);
                }
            }

            using (FileStream fs = new FileStream("ScratchPad.dat", FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Write(file, 0, (int)fs.Length);
                fs.Close();
            }
        }

        /// <summary>
        ///     Updates GUI texts and states of the overworld properites.
        /// </summary>
        /// <param name="map"> The current overworld map. </param>
        /// <param name="gamestate"> The game state. </param>
        public void UpdateGUIProperties(OverworldMap map, int gamestate = 0)
        {
            this.propertiesChangedFromForm = true;
            this.OWProperty_BGGFX.HexValue = map.GFX;
            this.OWProperty_AuxPalette.HexValue = map.AuxPalette;
            this.OWProperty_SPRGFX.HexValue = map.SpriteGFX[gamestate];
            this.OWProperty_SPRPalette.HexValue = map.SpritePalette[gamestate];
            this.OWProperty_TileGFX0.HexValue = map.TileGFX0;
            this.OWProperty_TileGFX1.HexValue = map.TileGFX1;
            this.OWProperty_TileGFX2.HexValue = map.TileGFX2;
            this.OWProperty_TileGFX3.HexValue = map.TileGFX3;
            this.OWProperty_TileGFX4.HexValue = map.TileGFX4;
            this.OWProperty_TileGFX5.HexValue = map.TileGFX5;
            this.OWProperty_TileGFX6.HexValue = map.TileGFX6;
            this.OWProperty_TileGFX7.HexValue = map.TileGFX7;
            this.OWProperty_AniGFX.HexValue = map.AnimatedGFX;
            this.OWProperty_MainPalette.HexValue = map.MainPalette;
            this.OWProperty_SubscreenOverlay.HexValue = map.SubscreenOverlay;

            this.AreaSizeComboBox.SelectedIndex = (int)map.AreaSize;
            this.leftmosaicCheckbox.Checked = map.Mosaic.Left;
            this.rightmosaicCheckbox.Checked = map.Mosaic.Right;
            this.topmosaicCheckbox.Checked = map.Mosaic.Up;
            this.bottommosaicCheckbox.Checked = map.Mosaic.Down;
            this.propertiesChangedFromForm = false;

            fromForm = true;
            music1Box.SelectedIndex = scene.ow.AllMaps[this.scene.selectedMapParent].Music[0] & 0x0F;
            music2Box.SelectedIndex = scene.ow.AllMaps[this.scene.selectedMapParent].Music[1] & 0x0F;
            music3Box.SelectedIndex = scene.ow.AllMaps[this.scene.selectedMapParent].Music[2] & 0x0F;
            music4Box.SelectedIndex = scene.ow.AllMaps[this.scene.selectedMapParent].Music[3] & 0x0F;

            ambient1Box.SelectedIndex = ((scene.ow.AllMaps[this.scene.selectedMapParent].Music[0] & 0xF0) >> 4);
            ambient2Box.SelectedIndex = ((scene.ow.AllMaps[this.scene.selectedMapParent].Music[1] & 0xF0) >> 4);
            ambient3Box.SelectedIndex = ((scene.ow.AllMaps[this.scene.selectedMapParent].Music[2] & 0xF0) >> 4);
            ambient4Box.SelectedIndex = ((scene.ow.AllMaps[this.scene.selectedMapParent].Music[3] & 0xF0) >> 4);
            fromForm = false;

            if (scene.selectedMap >= 0x40)
            {
                music2Box.Enabled = false;
                music3Box.Enabled = false;
                music4Box.Enabled = false;
                ambient2Box.Enabled = false;
                ambient3Box.Enabled = false;
                ambient4Box.Enabled = false;
            }
        }

        private void ModeButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.owToolStrip.Items.Count; i++) // Uncheck all the other modes.
            {
                if (this.owToolStrip.Items[i] is ToolStripButton tt)
                {
                    tt.Checked = false;
                }
            }

            (sender as ToolStripButton).Checked = true;
            this.scene.selectedMode = (ObjectMode)(sender as ToolStripButton).Tag;
        }

        private void stateCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.overworld.GameState = (byte)this.stateCombobox.SelectedIndex;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.mainForm.SaveToolStripMenuItem_Click(sender, e);
        }

        private void OverworldPropertyTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!this.propertiesChangedFromForm)
            {
                OverworldMap mapParent = this.scene.ow.AllMaps[this.scene.ow.AllMaps[this.scene.selectedMap].ParentID];
                this.UpdateMapProperties(mapParent);
                this.SendMapProperties(mapParent);
                if (ispalPreview)
                {
                    OWProperty_MainPalette_MouseEnter(sender, null);

                    return;
                }

                if (sender == OWProperty_SPRGFX)
                {
                    OWProperty_SPRGFX_MouseEnter(sender, null);
                }
                else
                {
                    OWProperty_TileGFX0_MouseEnter(sender, null);
                }
            }
        }

        /// <summary>
        ///     Updates the map's properties based on the values on the overworld GUI.
        /// </summary>
        /// <param name="mapParent"> The map parent. </param>
        public void UpdateMapProperties(OverworldMap mapParent)
        {
            if (this.scene.ow.AllMaps[this.scene.selectedMap].ParentID == 255)
            {
                mapParent = this.scene.ow.AllMaps[this.scene.selectedMap];
            }

            mapParent.AuxPalette = (byte)this.OWProperty_AuxPalette.HexValue;
            mapParent.GFX = (byte)this.OWProperty_BGGFX.HexValue;
            mapParent.MessageID = (short)this.OWProperty_MessageID.HexValue;

            if (mapParent.Index >= 0x40)
            {
                mapParent.SpriteGFX[0] = (byte)this.OWProperty_SPRGFX.HexValue;
                mapParent.SpritePalette[0] = (byte)this.OWProperty_SPRPalette.HexValue;
            }
            else
            {
                this.scene.ow.AllMaps[mapParent.Index].SpriteGFX[this.scene.ow.GameState] = (byte)this.OWProperty_SPRGFX.HexValue;
                mapParent.SpritePalette[this.scene.ow.GameState] = (byte)this.OWProperty_SPRPalette.HexValue;
            }

            mapParent.MainPalette = (byte)this.OWProperty_MainPalette.HexValue;

            mapParent.TileGFX0 = (byte)this.OWProperty_TileGFX0.HexValue;
            mapParent.TileGFX1 = (byte)this.OWProperty_TileGFX1.HexValue;
            mapParent.TileGFX2 = (byte)this.OWProperty_TileGFX2.HexValue;
            mapParent.TileGFX3 = (byte)this.OWProperty_TileGFX3.HexValue;
            mapParent.TileGFX4 = (byte)this.OWProperty_TileGFX4.HexValue;
            mapParent.TileGFX5 = (byte)this.OWProperty_TileGFX5.HexValue;
            mapParent.TileGFX6 = (byte)this.OWProperty_TileGFX6.HexValue;
            mapParent.TileGFX7 = (byte)this.OWProperty_TileGFX7.HexValue;
            mapParent.AnimatedGFX = (byte)this.OWProperty_AniGFX.HexValue;

            mapParent.SubscreenOverlay = (ushort)this.OWProperty_SubscreenOverlay.HexValue;

            mapParent.BuildMap();

            if (mapParent.AreaSize == AreaSizeEnum.WideArea || mapParent.AreaSize == AreaSizeEnum.LargeArea)
            {
                this.scene.ow.AllMaps[mapParent.Index + 1].GFX = mapParent.GFX;
                this.scene.ow.AllMaps[mapParent.Index + 1].TileGFX0 = mapParent.TileGFX0;
                this.scene.ow.AllMaps[mapParent.Index + 1].TileGFX1 = mapParent.TileGFX1;
                this.scene.ow.AllMaps[mapParent.Index + 1].TileGFX2 = mapParent.TileGFX2;
                this.scene.ow.AllMaps[mapParent.Index + 1].TileGFX3 = mapParent.TileGFX3;
                this.scene.ow.AllMaps[mapParent.Index + 1].TileGFX4 = mapParent.TileGFX4;
                this.scene.ow.AllMaps[mapParent.Index + 1].TileGFX5 = mapParent.TileGFX5;
                this.scene.ow.AllMaps[mapParent.Index + 1].TileGFX6 = mapParent.TileGFX6;
                this.scene.ow.AllMaps[mapParent.Index + 1].TileGFX7 = mapParent.TileGFX7;
                this.scene.ow.AllMaps[mapParent.Index + 1].AnimatedGFX = mapParent.AnimatedGFX;
                this.scene.ow.AllMaps[mapParent.Index + 1].SubscreenOverlay = mapParent.SubscreenOverlay;
                this.scene.ow.AllMaps[mapParent.Index + 1].SpriteGFX = mapParent.SpriteGFX;
                this.scene.ow.AllMaps[mapParent.Index + 1].AuxPalette = mapParent.AuxPalette;
                this.scene.ow.AllMaps[mapParent.Index + 1].SpritePalette = mapParent.SpritePalette;

                this.scene.ow.AllMaps[mapParent.Index + 1].BuildMap();
            }

            if (mapParent.AreaSize == AreaSizeEnum.TallArea || mapParent.AreaSize == AreaSizeEnum.LargeArea)
            {
                this.scene.ow.AllMaps[mapParent.Index + 8].GFX = mapParent.GFX;
                this.scene.ow.AllMaps[mapParent.Index + 8].TileGFX0 = mapParent.TileGFX0;
                this.scene.ow.AllMaps[mapParent.Index + 8].TileGFX1 = mapParent.TileGFX1;
                this.scene.ow.AllMaps[mapParent.Index + 8].TileGFX2 = mapParent.TileGFX2;
                this.scene.ow.AllMaps[mapParent.Index + 8].TileGFX3 = mapParent.TileGFX3;
                this.scene.ow.AllMaps[mapParent.Index + 8].TileGFX4 = mapParent.TileGFX4;
                this.scene.ow.AllMaps[mapParent.Index + 8].TileGFX5 = mapParent.TileGFX5;
                this.scene.ow.AllMaps[mapParent.Index + 8].TileGFX6 = mapParent.TileGFX6;
                this.scene.ow.AllMaps[mapParent.Index + 8].TileGFX7 = mapParent.TileGFX7;
                this.scene.ow.AllMaps[mapParent.Index + 8].AnimatedGFX = mapParent.AnimatedGFX;
                this.scene.ow.AllMaps[mapParent.Index + 8].SubscreenOverlay = mapParent.SubscreenOverlay;
                this.scene.ow.AllMaps[mapParent.Index + 8].SpriteGFX = mapParent.SpriteGFX;
                this.scene.ow.AllMaps[mapParent.Index + 8].AuxPalette = mapParent.AuxPalette;
                this.scene.ow.AllMaps[mapParent.Index + 8].SpritePalette = mapParent.SpritePalette;

                this.scene.ow.AllMaps[mapParent.Index + 8].BuildMap();
            }

            if (mapParent.AreaSize == AreaSizeEnum.LargeArea)
            {
                this.scene.ow.AllMaps[mapParent.Index + 9].GFX = mapParent.GFX;
                this.scene.ow.AllMaps[mapParent.Index + 9].TileGFX0 = mapParent.TileGFX0;
                this.scene.ow.AllMaps[mapParent.Index + 9].TileGFX1 = mapParent.TileGFX1;
                this.scene.ow.AllMaps[mapParent.Index + 9].TileGFX2 = mapParent.TileGFX2;
                this.scene.ow.AllMaps[mapParent.Index + 9].TileGFX3 = mapParent.TileGFX3;
                this.scene.ow.AllMaps[mapParent.Index + 9].TileGFX4 = mapParent.TileGFX4;
                this.scene.ow.AllMaps[mapParent.Index + 9].TileGFX5 = mapParent.TileGFX5;
                this.scene.ow.AllMaps[mapParent.Index + 9].TileGFX6 = mapParent.TileGFX6;
                this.scene.ow.AllMaps[mapParent.Index + 9].TileGFX7 = mapParent.TileGFX7;
                this.scene.ow.AllMaps[mapParent.Index + 9].AnimatedGFX = mapParent.AnimatedGFX;
                this.scene.ow.AllMaps[mapParent.Index + 9].SubscreenOverlay = mapParent.SubscreenOverlay;
                this.scene.ow.AllMaps[mapParent.Index + 9].SpriteGFX = mapParent.SpriteGFX;
                this.scene.ow.AllMaps[mapParent.Index + 9].AuxPalette = mapParent.AuxPalette;
                this.scene.ow.AllMaps[mapParent.Index + 9].SpritePalette = mapParent.SpritePalette;

                this.scene.ow.AllMaps[mapParent.Index + 9].BuildMap();
            }

            // scene.updateMapGfx();
            this.scene.Invalidate();
            // scene.Refresh();
        }

        private void tilePictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (GFX.mapblockset16Bitmap != null)
            {
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
                e.Graphics.CompositingMode = CompositingMode.SourceCopy; // why was it over that's much slower than copy
                e.Graphics.DrawImage(
                    GFX.mapblockset16Bitmap,
                    new Rectangle(0, 0, 256, 16384),
                    new Rectangle(0, 0, 128, 8192),
                    GraphicsUnit.Pixel);

                if (this.scene.selectedTile.Length > 0)
                {
                    int x = (this.scene.selectedTile[0] % 8) * 32;
                    int y = (this.scene.selectedTile[0] / 8) * 32;

                    e.Graphics.DrawRectangle(selectionPen, new Rectangle(x, y, 32, 32));
                    //selectedTileLabel.Text = $"Selected tile: {scene.selectedTile[0]:X4}"; // do not put set label in paint wtf
                }

                if (!showUnusedTile16)
                {
                    return;
                }

                e.Graphics.CompositingMode = CompositingMode.SourceOver; // why was it over that's much slower than copy
                for (int i = 0; i < 4096; i++)
                {
                    if (!overworld.usedTiles16[i])
                    {
                        e.Graphics.FillRectangle(unusedTile, new Rectangle((i % 8) * 32, (i / 8) * 32, 32, 32));
                    }
                }

                //e.Graphics.FillRectangle(Brushes.Black, new RectangleF(128, 3408, 128, 688));
            }
        }

        public void AdjustTile16BoxScrollBar()
        {
            int y = (this.scene.selectedTile[0] / 8) * 32;

            if (y + this.tile16Tab.Size.Height > this.tilePictureBox.Size.Height)
            {
                y = this.tilePictureBox.Size.Height - this.tile16Tab.Size.Height;
            }

            // TODO: Fix this garbage, it doesn't update all of the time for some reason but works better without the if. -Jared_Brian_
            //if (y < tabPage1.VerticalScroll.Value || y > tabPage1.VerticalScroll.Value + tabPage1.Size.Height)
            //{
            this.tile16Tab.VerticalScroll.Value = y;
            this.tilePictureBox.Refresh();
            this.tile16Tab.Update();
            this.tile16Tab.Refresh();
            //}
        }

        private void tilePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.scene.selectedTileSizeX = 1;
            this.scene.selectedTile = new ushort[1] { (ushort)((e.X / 32) + ((e.Y / 32) * 8)) };
            if (scene.selectedMode == ObjectMode.Tile || scene.selectedMode == ObjectMode.FillTile)
            {
                objectGroupbox.Text = "Selected Tile " + scene.selectedTile[0].ToString("X4") + "   Selected Map " + scene.ow.AllMaps[scene.selectedMap].ParentID.ToString("X2");
                this.SelectedObjectID.Text = scene.selectedTile[0].ToString("X4");
            }

            this.tilePictureBox.Refresh();
        }

        /// <summary>
        /// Called when the LW button on the overworld editor form is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lwButton_Click(object sender, EventArgs e)
        {
            this.SelectMapOffset(0);
        }

        /// <summary>
        /// Called when the DW button on the overworld editor form is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dwButton_Click(object sender, EventArgs e)
        {
            this.SelectMapOffset(64);
        }

        /// <summary>
        /// Called when the SP button on the overworld editor form is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spButton_Click(object sender, EventArgs e)
        {
            this.SelectMapOffset(128);
        }

        private void SelectMapOffset(int o)
        {
            this.scene.selectedMap = o;
            this.scene.selectedMapParent = this.scene.ow.AllMaps[o].ParentID;
            this.scene.ow.WorldOffset = o;
            this.scene.updateMapGfx();

            this.scene.Refresh();
        }

        private void runtestButton_Click(object sender, EventArgs e)
        {
            this.mainForm.runtestButton_Click(sender, e);
        }

        private void tilePictureBox_DoubleClick(object sender, EventArgs e)
        {
            Tile16Editor ted = new Tile16Editor(this.scene);

            if (ted.ShowDialog() == DialogResult.OK)
            {
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    for (int i = 0; i < 159; i++)
                    {
                        if (this.scene.ow.AllMaps[i].NeedRefresh)
                        {
                            this.scene.ow.AllMaps[i].BuildMap();
                            this.scene.ow.AllMaps[i].NeedRefresh = false;
                        }
                    }
                }).Start();
            }
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            this.scene.mainForm.undoButton_Click(sender, e);
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            this.scene.mainForm.redoButton_Click(sender, e);
        }

        private void refreshToolStrip_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                for (int i = 0; i < 159; i++)
                {
                    if (this.mainForm.overworldEditor.scene.ow.AllMaps[i].NeedRefresh)
                    {
                        this.mainForm.overworldEditor.scene.ow.AllMaps[i].BuildMap();
                        this.mainForm.overworldEditor.scene.ow.AllMaps[i].NeedRefresh = false;
                    }
                }
            }).Start();
        }

        private void musicButton_Click(object sender, EventArgs e)
        {
            var owmf = new OWMusicForm();
            owmf.mapIndex = (byte)this.scene.selectedMapParent;
            owmf.musics[0] = this.scene.ow.AllMaps[this.scene.selectedMapParent].Music[0];
            owmf.musics[1] = this.scene.ow.AllMaps[this.scene.selectedMapParent].Music[1];
            owmf.musics[2] = this.scene.ow.AllMaps[this.scene.selectedMapParent].Music[2];
            owmf.musics[3] = this.scene.ow.AllMaps[this.scene.selectedMapParent].Music[3];

            if (owmf.ShowDialog() == DialogResult.OK)
            {
                this.scene.ow.AllMaps[this.scene.selectedMapParent].Music[0] = owmf.musics[0];
                this.scene.ow.AllMaps[this.scene.selectedMapParent].Music[1] = owmf.musics[1];
                this.scene.ow.AllMaps[this.scene.selectedMapParent].Music[2] = owmf.musics[2];
                this.scene.ow.AllMaps[this.scene.selectedMapParent].Music[3] = owmf.musics[3];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.mainForm.textEditor.SelectMessageID(this.OWProperty_MessageID.HexValue);

            this.mainForm.editorsTabControl.SelectTab(3);
            this.mainForm.textEditor.Refresh();
        }

        private void previewTextPicturebox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            ColorPalette colorPalette = GFX.currentfontgfx16Bitmap.Palette;
            int defaultColor = 6;

            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    colorPalette.Entries[i] = Color.Transparent;
                }
                else
                {
                    colorPalette.Entries[i] = GFX.roomBg1Bitmap.Palette.Entries[(defaultColor * 4) + i];
                }
            }

            GFX.currentfontgfx16Bitmap.Palette = colorPalette;

            // TODO: Make new brushes.
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(GFX.currentfontgfx16Bitmap, Constants.Rect_0_0_340_102, Constants.Rect_0_0_170_51, GraphicsUnit.Pixel);
            e.Graphics.FillRectangle(Constants.HalfRedBrush, Constants.Rect_336_0_4_102);
        }

        private void textidTextbox_Click(object sender, EventArgs e)
        {
            this.mainForm.textEditor.SelectMessageID(this.OWProperty_MessageID.HexValue);
            this.mainForm.textEditor.Refresh();
            this.previewTextPicturebox.Size = Constants.Size340x102;
            this.previewTextPicturebox.Visible = true;
            this.previewTextPicturebox.Refresh();
        }

        private void textidTextbox_Leave(object sender, EventArgs e)
        {
            this.previewTextPicturebox.Visible = false;
        }

        private void scratchPicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            this.globalmouseTileDownX = e.X / 16;
            this.globalmouseTileDownY = e.Y / 16;

            if (this.scene.needRedraw)
            {
                this.scene.needRedraw = false;
                return;
            }

            this.mouse_down = true;

            if (e.Button == MouseButtons.Left)
            {
                if (this.scene.selectedTile.Length >= 1)
                {
                    int y = 0;
                    int x = 0;
                    //ushort[] undotiles = new ushort[scene.selectedTile.Length];

                    for (int i = 0; i < this.scene.selectedTile.Length; i++)
                    {
                        if (this.globalmouseTileDownX + x <= 15)
                        {
                            this.scratchPadTiles[this.globalmouseTileDownX + x, this.globalmouseTileDownY + y] = this.scene.selectedTile[i];
                        }

                        x++;

                        if (x >= this.scene.selectedTileSizeX)
                        {
                            y++;
                            x = 0;
                        }
                    }
                }
                else
                {
                    this.scratchPadTiles[this.globalmouseTileDownX, this.globalmouseTileDownY] = this.scene.selectedTile[0];
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.selecting = true;
            }

            this.BuildScratchTilesGfx();
            this.scratchPicturebox.Refresh();
        }

        private void scratchPicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.mouse_down)
            {
                int tileX = e.X / 16;
                int tileY = e.Y / 16;

                if (e.Button == MouseButtons.Right)
                {
                    if (tileX == this.globalmouseTileDownX && tileY == this.globalmouseTileDownY)
                    {
                        this.scene.selectedTile = new ushort[1] { this.scratchPadTiles[this.globalmouseTileDownX, this.globalmouseTileDownY] };
                        this.scene.selectedTileSizeX = 1;
                    }
                    else
                    {
                        bool reverseX = false;
                        bool reverseY = false;
                        int sizeX = (tileX - this.globalmouseTileDownX) + 1;
                        int sizeY = (tileY - this.globalmouseTileDownY) + 1;

                        if (tileX < this.globalmouseTileDownX)
                        {
                            sizeX = (this.globalmouseTileDownX - tileX) + 1;
                            reverseX = true;
                        }

                        if (tileY < this.globalmouseTileDownY)
                        {
                            sizeY = (this.globalmouseTileDownY - tileY) + 1;
                            reverseY = true;
                        }

                        int pX = reverseX ? tileX : this.globalmouseTileDownX;
                        int pY = reverseY ? tileY : this.globalmouseTileDownY;

                        if (pX < 0)
                        {
                            pX = 0;
                        }

                        if (pY < 0)
                        {
                            pY = 0;
                        }

                        int rows = this.scratchPadTiles.GetLength(0);
                        int columns = this.scratchPadTiles.GetLength(1);
                        if (sizeX + pX >= rows)
                        {
                            sizeX = rows - pX;
                        }

                        if (sizeY + pY >= columns)
                        {
                            sizeY = columns - pY;
                        }

                        this.scene.selectedTileSizeX = sizeX;
                        this.scene.selectedTile = new ushort[sizeX * sizeY];

                        for (int y = 0; y < sizeY; y++)
                        {
                            for (int x = 0; x < sizeX; x++)
                            {
                                this.scene.selectedTile[x + (y * sizeX)] = this.scratchPadTiles[pX + x, pY + y];
                            }
                        }
                    }
                }
            }

            this.selecting = false;
            this.mouse_down = false;
            this.scratchPicturebox.Refresh();
        }

        private void scratchPicturebox_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.scene.initialized)
            {
                this.mouseX_Real = e.X;
                this.mouseY_Real = e.Y;
                int mouseTileX = e.X / 16;
                int mouseTileY = e.Y / 16;

                if (this.lastTileHoverX != mouseTileX || this.lastTileHoverY != mouseTileY)
                {
                    if (this.mouse_down)
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            int tileX = e.X / 16;
                            int tileY = e.Y / 16;
                            if (tileX <= 0)
                            {
                                tileX = 0;
                            }

                            if (tileY <= 0)
                            {
                                tileY = 0;
                            }

                            if (tileX > 16)
                            {
                                tileX = 16;
                            }

                            if (tileY > 225)
                            {
                                tileY = 225;
                            }

                            this.globalmouseTileDownX = tileX;
                            this.globalmouseTileDownY = tileY;

                            if (this.scene.selectedTile.Length >= 1)
                            {
                                int y = 0;
                                int x = 0;
                                for (int i = 0; i < this.scene.selectedTile.Length; i++)
                                {
                                    if (this.globalmouseTileDownX + x < 16 && this.globalmouseTileDownY + y < 225)
                                    {
                                        this.scratchPadTiles[this.globalmouseTileDownX + x, this.globalmouseTileDownY + y] = this.scene.selectedTile[i];
                                    }

                                    x++;

                                    if (x >= this.scene.selectedTileSizeX)
                                    {
                                        y++;
                                        x = 0;
                                    }
                                }
                            }
                        }

                        this.BuildScratchTilesGfx();
                    }

                    this.scratchPicturebox.Refresh();
                    this.lastTileHoverX = mouseTileX;
                    this.lastTileHoverY = mouseTileY;
                }
            }
        }

        private void scratchPicturebox_Paint(object sender, PaintEventArgs e)
        {
            if (GFX.mapblockset16Bitmap == null)
            {
                return;
            }

            // USE mapblockset16 to draw tiles on this !! :GRIMACING:
            //public static IntPtr mapblockset16 = Marshal.AllocHGlobal(1048576);
            //public static Bitmap mapblockset16Bitmap;
            //base.OnPaint(e);
            Graphics g = e.Graphics;
            ColorMatrix cm = new ColorMatrix();
            ImageAttributes ia = new ImageAttributes();
            cm.Matrix33 = 0.50f;
            cm.Matrix22 = 2f;
            ia.SetColorMatrix(cm);
            g.CompositingMode = CompositingMode.SourceCopy;
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;

            g.DrawImage(GFX.scratchblockset16Bitmap, 0, 0);

            // DRAW ALL THE TILES 16x225
            g.CompositingMode = CompositingMode.SourceOver;

            if (scratchPadGrid)
            {
                int gridsizeX = 256;
                int gridsizeY = 3600;

                for (int gx = 0; gx < (gridsizeX / 32); gx++)
                {
                    g.DrawLine(
                        Constants.ThirdWhitePen1,
                        new Point(gx * 32, 0),
                        new Point(gx * 32, gridsizeY));
                }

                for (int gy = 0; gy < ((gridsizeY / 32) + 1); gy++)
                {
                    g.DrawLine(
                        Constants.ThirdWhitePen1,
                        new Point(0, gy * 32),
                        new Point(gridsizeX, gy * 32));
                }
            }

            if (this.selecting)
            {
                g.DrawRectangle(Pens.White, new Rectangle((globalmouseTileDownX * 16), (globalmouseTileDownY * 16), (((mouseX_Real / 16) - globalmouseTileDownX) * 16) + 16, (((mouseY_Real / 16) - globalmouseTileDownY) * 16) + 16));
            }

            g.DrawImage(this.scene.tilesgfxBitmap, new Rectangle((this.mouseX_Real / 16) * 16, (this.mouseY_Real / 16) * 16, this.scene.selectedTileSizeX * 16, (this.scene.selectedTile.Length / this.scene.selectedTileSizeX) * 16), 0, 0, this.scene.selectedTileSizeX * 16, (this.scene.selectedTile.Length / this.scene.selectedTileSizeX) * 16, GraphicsUnit.Pixel, ia);

            g.DrawRectangle(Pens.LightGreen, new Rectangle((this.mouseX_Real / 16) * 16, (this.mouseY_Real / 16) * 16, this.scene.selectedTileSizeX * 16, (this.scene.selectedTile.Length / this.scene.selectedTileSizeX) * 16));

            g.DrawImage(this.scene.tilesgfxBitmap, new Rectangle((this.mouseX_Real / 16) * 16, (this.mouseY_Real / 16) * 16, this.scene.selectedTileSizeX * 16, (this.scene.selectedTile.Length / this.scene.selectedTileSizeX) * 16), 0, 0, this.scene.selectedTileSizeX * 16, (this.scene.selectedTile.Length / this.scene.selectedTileSizeX) * 16, GraphicsUnit.Pixel, ia);

            g.DrawRectangle(Pens.LightGreen, new Rectangle((this.mouseX_Real / 16) * 16, (this.mouseY_Real / 16) * 16, this.scene.selectedTileSizeX * 16, (this.scene.selectedTile.Length / this.scene.selectedTileSizeX) * 16));

            g.CompositingMode = CompositingMode.SourceCopy;
            //hideText = false;
        }

        public unsafe void BuildScratchTilesGfx()
        {
            GFX.scratchblockset16Bitmap.Palette = GFX.mapblockset16Bitmap.Palette;
            var gfx16Data = (byte*)GFX.mapblockset16.ToPointer(); // (byte*)allgfx8Ptr.ToPointer();
            var gfx16DataScratch = (byte*)GFX.scratchblockset16.ToPointer(); // (byte*)allgfx16Ptr.ToPointer();
            int ytile = 0;
            int xtile = 0;

            for (var i = 0; i < 3600; i++) // Number of tiles16 3748?
            {
                ushort srcTile = this.scratchPadTiles[xtile, ytile];
                // Console.WriteLine(srcTile);
                int srcTileY = srcTile / 8;
                int srcTileX = srcTile - (srcTileY * 8);
                int tPos = (xtile * 16) + (ytile * 4096);
                int srctPos = (srcTileX * 16) + (srcTileY * 2048);

                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        gfx16DataScratch[tPos + (x + (y * 256))] = gfx16Data[srctPos + (x + (y * 128))];
                    }
                }

                xtile++;
                if (xtile >= 16)
                {
                    xtile = 0;
                    ytile++;
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.None;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            //e.Graphics.DrawImage(GFX.currentOWgfx16Bitmap,new Rectangle(0,0,512,1024), new Rectangle(0,0,256,512),GraphicsUnit.Pixel);

            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            e.Graphics.DrawImage(GFX.editort16Bitmap, Constants.Rect_0_0_256_1024);

            int y = this.tile8selected / 16;
            int x = this.tile8selected - (y * 16);

            e.Graphics.DrawRectangle(Pens.GreenYellow, new Rectangle(x * 16, y * 16, 16, 16));
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Copy.
            if (this.tabControl1.SelectedTab.Name == "Tiles8")
            {
                /*
                int sx = 0;
                int sy = 0;
                int c = 0;

                int nx = 0;
                int ny = 0;
                for (int i = 0; i < 64; i++)
                {
                    for (int y = 0; y < 64; y += 2)
                    {
                        for (int x = 0; x < 64; x += 2)
                        {
                            //Console.WriteLine(overworld.tiles16[overworld.allmapsTilesLW[nx + (sx * 32), ny + (sy * 32)]].tile0.id);

                            overworld.tempTiles8_LW[x + (sx * 64), y + (sy * 64)] = overworld.tiles16[overworld.allmapsTilesLW[nx + (sx * 32), ny + (sy * 32)]].tile0;
                            overworld.tempTiles8_LW[x + (sx * 64) + 1, y + (sy * 64)] = overworld.tiles16[overworld.allmapsTilesLW[nx + (sx * 32), ny + (sy * 32)]].tile1;
                            overworld.tempTiles8_LW[x + (sx * 64), y + (sy * 64) + 1] = overworld.tiles16[overworld.allmapsTilesLW[nx + (sx * 32), ny + (sy * 32)]].tile2;
                            overworld.tempTiles8_LW[x + (sx * 64) + 1, y + (sy * 64) + 1] = overworld.tiles16[overworld.allmapsTilesLW[nx + (sx * 32), ny + (sy * 32)]].tile3;

                            overworld.tempTiles8_DW[x + (sx * 64), y + (sy * 64)] = overworld.tiles16[overworld.allmapsTilesDW[nx + (sx * 32), ny + (sy * 32)]].tile0;
                            overworld.tempTiles8_DW[x + (sx * 64) + 1, y + (sy * 64)] = overworld.tiles16[overworld.allmapsTilesDW[nx + (sx * 32), ny + (sy * 32)]].tile1;
                            overworld.tempTiles8_DW[x + (sx * 64), y + (sy * 64) + 1] = overworld.tiles16[overworld.allmapsTilesDW[nx + (sx * 32), ny + (sy * 32)]].tile2;
                            overworld.tempTiles8_DW[x + (sx * 64) + 1, y + (sy * 64) + 1] = overworld.tiles16[overworld.allmapsTilesDW[nx + (sx * 32), ny + (sy * 32)]].tile3;

                            if (i < 32)
                            {
                                overworld.tempTiles8_SP[x + (sx * 64), y + (sy * 64)] = overworld.tiles16[overworld.allmapsTilesSP[nx + (sx * 32), ny + (sy * 32)]].tile0;
                                overworld.tempTiles8_SP[x + (sx * 64) + 1, y + (sy * 64)] = overworld.tiles16[overworld.allmapsTilesSP[nx + (sx * 32), ny + (sy * 32)]].tile1;
                                overworld.tempTiles8_SP[x + (sx * 64), y + (sy * 64) + 1] = overworld.tiles16[overworld.allmapsTilesSP[nx + (sx * 32), ny + (sy * 32)]].tile2;
                                overworld.tempTiles8_SP[x + (sx * 64) + 1, y + (sy * 64) + 1] = overworld.tiles16[overworld.allmapsTilesSP[nx + (sx * 32), ny + (sy * 32)]].tile3;
                            }

                            nx++;
                        }

                        nx = 0;
                        ny++;
                    }

                    sx++;
                    if (sx >= 8)
                    {
                        sy++;
                        sx = 0;
                    }

                    c++;
                    if (c >= 64)
                    {
                        sx = 0;
                        sy = 0;
                        c = 0;
                    }

                    nx = 0;
                    ny = 0;
                }
                */
            }
            else
            {
                //overworld.createMap16Tilesmap();
                //Convert them back in tiles16
            }
        }

        public unsafe void updateSelectedTile16()
        {
            byte p = this.palSelected;
            this.tile8selected = 0;
            byte* destPtr = (byte*)GFX.editingtile16.ToPointer();
            byte* srcPtr = (byte*)GFX.currentOWgfx16Ptr.ToPointer();
            Tile16 t = this.overworld.Tile16List[this.scene.selectedTile[0]];

            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 4; x++)
                {
                    this.CopyTile(x, y, 0, 0, t.Tile0.id, p, destPtr, srcPtr, 16);
                }
            }

            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 4; x++)
                {
                    this.CopyTile(x, y, 8, 0, t.Tile1.id, p, destPtr, srcPtr, 16);
                }
            }

            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 4; x++)
                {
                    this.CopyTile(x, y, 0, 8, t.Tile2.id, p, destPtr, srcPtr, 16);
                }
            }

            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 4; x++)
                {
                    this.CopyTile(x, y, 8, 8, t.Tile3.id, p, destPtr, srcPtr, 16);
                }
            }

            // Bitmap b = new Bitmap(128, 512, 64, System.Drawing.Imaging.PixelFormat.Format4bppIndexed, GFX.currentOWgfx16Ptr);
            GFX.editort16Bitmap.Palette = this.scene.ow.AllMaps[this.scene.selectedMap].GFXBitmap.Palette;
        }

        public unsafe void UpdateTiles()
        {
            byte p = this.palSelected;

            this.tile8selected = 0;
            byte* destPtr = (byte*)GFX.editort16Ptr.ToPointer();
            byte* srcPtr = (byte*)GFX.currentOWgfx16Ptr.ToPointer();
            int xx = 0;
            int yy = 0;
            for (int i = 0; i < 1024; i++)
            {
                for (var y = 0; y < 8; y++)
                {
                    for (var x = 0; x < 4; x++)
                    {
                        this.CopyTile(x, y, xx, yy, i, p, destPtr, srcPtr);
                    }
                }

                xx += 8;
                if (xx >= 128)
                {
                    yy += 1024;
                    xx = 0;
                }
            }

            // Bitmap b = new Bitmap(128, 512, 64, System.Drawing.Imaging.PixelFormat.Format4bppIndexed, GFX.currentOWgfx16Ptr);
            GFX.editort16Bitmap.Palette = this.scene.ow.AllMaps[this.scene.selectedMap].GFXBitmap.Palette;
            this.pictureBox1.Refresh();
            this.palette8Box.Refresh();
        }

        private unsafe void CopyTile(int x, int y, int xx, int yy, TileInfo tile, int offset, byte* gfx16Pointer, byte* gfx8Pointer)
        {
            int mx = x;
            int my = y;
            byte r = 0;

            if (tile.H)
            {
                mx = 3 - x;
                r = 1;
            }

            if (tile.V)
            {
                my = 7 - y;
            }

            int tx = ((tile.id / 16) * 512) + ((tile.id - ((tile.id / 16) * 16)) * 4);
            int index = xx + yy + offset + (mx * 2) + (my * 16);
            int pixel = gfx8Pointer[tx + (y * 64) + x];

            gfx16Pointer[index + r ^ 1] = (byte)((pixel & 0x0F) + (tile.palette * 16));
            gfx16Pointer[index + r] = (byte)(((pixel >> 4) & 0x0F) + (tile.palette * 16));
        }

        private unsafe void CopyTile(int x, int y, int xx, int yy, int id, byte p, byte* gfx16Pointer, byte* gfx8Pointer, int destwidth = 128)
        {
            int mx = x;
            int my = y;
            byte r = 0;

            if (this.mirrorXCheckbox.Checked)
            {
                mx = 3 - x;
                r = 1;
            }

            if (this.mirrorYCheckbox.Checked)
            {
                my = 7 - y;
            }

            int tx = ((id / 16) * 512) + ((id - ((id / 16) * 16)) * 4);
            int index = xx + yy + (mx * 2) + (my * destwidth);
            int pixel = gfx8Pointer[tx + (y * 64) + x];

            gfx16Pointer[index + r ^ 1] = (byte)((pixel & 0x0F) + p * 16);
            gfx16Pointer[index + r] = (byte)(((pixel >> 4) & 0x0F) + p * 16);
        }

        private void mirrorXCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateTiles();
        }

        private void palette8Box_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 128; i++)
            {
                Color c = this.scene.ow.AllMaps[this.scene.selectedMap].GFXBitmap.Palette.Entries[i];
                e.Graphics.FillRectangle(new SolidBrush(c), new Rectangle((i % 16) * 16, (i / 16) * 16, 16, 16));
            }

            e.Graphics.DrawRectangle(Pens.GreenYellow, new Rectangle(0, this.palSelected * 16, 256, 16));
        }

        private void palette8Box_MouseDown(object sender, MouseEventArgs e)
        {
            this.palSelected = (byte)(e.Y / 16);
            this.UpdateTiles();
        }

        private void searchtilesButton_Click(object sender, EventArgs e)
        {
            Dictionary<ushort, ushort> alltilesIndexed = new Dictionary<ushort, ushort>();
            int sx = 0;
            int sy = 0;

            for (ushort i = 0; i < 3752; i++)
            {
                alltilesIndexed.Add(i, 0);
            }

            for (int i = 0; i < 64; i++)
            {
                for (int y = 0; y < 32; y += 1)
                {
                    for (int x = 0; x < 32; x += 1)
                    {
                        ushort LWTile = this.overworld.AllMapTile32LW[x + (sx * 32), y + (sy * 32)];
                        alltilesIndexed[LWTile]++;
                        ushort DWTile = this.overworld.AllMapTile32DW[x + (sx * 32), y + (sy * 32)];
                        alltilesIndexed[DWTile]++;

                        if (i < 32)
                        {
                            alltilesIndexed[this.overworld.AllMapTile32SP[x + (sx * 32), y + (sy * 32)]]++;
                        }
                    }
                }

                foreach (TilePos t in this.overworld.AllOverlays[i].TileDataList)
                {
                    alltilesIndexed[t.tileId]++;
                }

                foreach (TilePos t in this.overworld.AllOverlays[i + 64].TileDataList)
                {
                    alltilesIndexed[t.tileId]++;
                }

                sx++;
                if (sx >= 8)
                {
                    sy++;
                    sx = 0;
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<ushort, ushort> tiles in alltilesIndexed.OrderBy(key => key.Value))
            {
                // TODO: copy
                sb.AppendLine($"Tile - {tiles.Key:X4}: {tiles:X4}");
            }

            SearchTilesForm stf = new SearchTilesForm();
            stf.textBox1.Text = sb.ToString();
            stf.ShowDialog();
        }

        private void textidTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!this.propertiesChangedFromForm)
            {
                OverworldMap mapParent = this.scene.ow.AllMaps[this.scene.ow.AllMaps[this.scene.selectedMap].ParentID];

                if (this.scene.ow.AllMaps[this.scene.selectedMap].ParentID == 255)
                {
                    mapParent = this.scene.ow.AllMaps[this.scene.selectedMap];
                }

                mapParent.MessageID = (short)this.OWProperty_MessageID.HexValue;

                this.mainForm.textEditor.SelectMessageID(this.OWProperty_MessageID.HexValue);
                this.mainForm.textEditor.Refresh();
                this.previewTextPicturebox.Size = new Size(340, 102);
                this.previewTextPicturebox.Visible = true;
                this.previewTextPicturebox.Refresh();
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    this.overworld.AllMaps[this.scene.selectedMap].TilesUsed[x, y] = 0052;

                    //overworld.allmapsTilesLW[x, y] = 0052;
                }
            }

            this.scene.Refresh();
        }

        private void tilePictureBox_MouseEnter(object sender, EventArgs e)
        {
            this.scene.ow.AllMaps[this.scene.selectedMap].BuildMap();
            this.tilePictureBox.Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.tile8selected = (e.X / 16) + ((e.Y / 16) * 16);
            this.pictureBox1.Refresh();
        }

        private void currentTile8Box_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.CompositingMode = CompositingMode.SourceOver;
            this.updateSelectedTile16();
            e.Graphics.DrawImage(GFX.editingtile16Bitmap, Constants.Rect_0_0_64_64);
        }

        /// <summary>
        ///     Called when the largemap checkbox is clicke, upataes the world layout and then updates all of the sprites within that area.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void largemapCheckbox_Clicked(object sender, EventArgs e)
        {
            if (this.propertiesChangedFromForm)
            {
                return;
            }

            int parentID = this.scene.ow.AllMaps[this.scene.selectedMap].ParentID;
            this.SendLargeMapChanged(parentID, (AreaSizeEnum)this.AreaSizeComboBox.SelectedIndex);

            // TODO: Change this call to be from the combo box and not the old checkbox.
            this.UpdateLargeMap(parentID, (AreaSizeEnum)this.AreaSizeComboBox.SelectedIndex, this.scene.ow.AllMaps[parentID].AreaSize);
        }

        public void UpdateLargeMap(int mapID, AreaSizeEnum newAreaSize, AreaSizeEnum oldAreaSize)
        {
            if (newAreaSize == oldAreaSize)
            {
                this.AreaSizeComboBox.SelectedIndex = (int)oldAreaSize;

                return;
            }

            List<int> areasToReset = new List<int>();
            switch (oldAreaSize)
            {
                case AreaSizeEnum.LargeArea:
                    areasToReset.Add(1);
                    areasToReset.Add(8);
                    areasToReset.Add(9);

                    break;

                case AreaSizeEnum.WideArea:
                    areasToReset.Add(1);

                    break;

                case AreaSizeEnum.TallArea:
                    areasToReset.Add(8);

                    break;
            }

            // Check if we are able to change the area size. If we will end up overlapping another large area, then we cannot change the size.
            int badCount = 0;
            string badAreaString = string.Empty;

            foreach (int area in areasToReset)
            {
                OverworldMap currentArea = this.scene.ow.AllMaps[mapID + area];
                if (currentArea.AreaSize != AreaSizeEnum.SmallArea)
                {
                    if (currentArea.ParentID != this.scene.ow.AllMaps[mapID].ParentID)
                    {
                        badAreaString += (mapID + area).ToString("X2") + ", ";
                        badCount++;
                    }
                }
            }

            if (badCount > 0)
            {
                badAreaString = badAreaString.Remove(badAreaString.Length - 2);
                if (badCount == 1)
                {
                    MessageBox.Show("Cannot make overlapping large area. Area: " + badAreaString + " is already part of a large area.", "Bad Error", MessageBoxButtons.OK);
                }
                else if (badCount == 2)
                {
                    badAreaString = badAreaString.Remove(2, 1);
                    badAreaString = badAreaString.Insert(badAreaString.Length - 2, "and ");
                    MessageBox.Show("Cannot make overlapping large area. Areas: " + badAreaString + " are already part of a large area.", "Bad Error", MessageBoxButtons.OK);
                }
                else
                {
                    badAreaString = badAreaString.Insert(badAreaString.Length - 2, "and ");
                    MessageBox.Show("Cannot make overlapping large area. Areas: " + badAreaString + " are already part of a large area.", "Bad Error", MessageBoxButtons.OK);
                }

                this.AreaSizeComboBox.SelectedIndex = (int)oldAreaSize;

                return;
            }

            List<int> worlds = new List<int>() { 0x00 };
            if (mapID < 0x40)
            {
                // If we are in the light world, set the dark world opposite too.
                worlds.Add(0x40);
            }
            else if (mapID >= 0x40 && mapID < 0x80)
            {
                // If we are in the dark world, set the light world opposite too.
                worlds.Add(-0x40);
            }

            // Set the parent and old children area sizes to small just in case.
            foreach (int world in worlds)
            {
                foreach (int area in areasToReset)
                {
                    this.scene.ow.AllMaps[mapID + world + area].SetAreaSize(AreaSizeEnum.SmallArea);
                }
            }

            // Setup the areas that need to be added to the new parent area.
            List<(int offset, int parentOffset)> areasToAdd = new List<(int, int)>();
            switch (newAreaSize)
            {
                case AreaSizeEnum.SmallArea:
                    areasToAdd.Add((0, 0));

                    break;

                case AreaSizeEnum.LargeArea:
                    areasToAdd.Add((0, 0));
                    areasToAdd.Add((1, 1));
                    areasToAdd.Add((8, 2));
                    areasToAdd.Add((9, 3));

                    break;

                case AreaSizeEnum.WideArea:
                    areasToAdd.Add((0, 0));
                    areasToAdd.Add((1, 1));

                    break;

                case AreaSizeEnum.TallArea:
                    areasToAdd.Add((0, 0));
                    areasToAdd.Add((8, 2));

                    break;
            }

            // Set the parent and new children area sizes to the new size.
            foreach (int world in worlds)
            {
                foreach ((int offset, int parentOffset) area in areasToAdd)
                {
                    this.scene.ow.AllMaps[mapID + world + area.offset].SetAreaSize(newAreaSize, (byte)(mapID + world), (byte)area.parentOffset);
                }
            }

            // TODO: I don't think this is needed but double check.
            //this.scene.ow.AllMaps = this.scene.ow.AssignLargeMaps(this.scene.ow.AllMaps);

            Console.WriteLine("Updating object locations…");

            // Move all of the overworld objects to their non parent areas.
            if (oldAreaSize != AreaSizeEnum.SmallArea)
            {
                // If the area was a small one, there will not be any objects to move back.

                foreach (int world in worlds)
                {
                    int currentArea = mapID + world;

                    int movedObjectCount = 0;
                    foreach (EntranceOW entrance in this.scene.ow.AllEntrances.Where(x => x.MapID == currentArea))
                    {
                        // If the AreaX is >= 32 we need to add 1.
                        int pos = entrance.AreaX >= 32 ? 1 : 0;

                        // If the AreaY is >= 32 we need to add 8.
                        pos += entrance.AreaY >= 32 ? 8 : 0;

                        entrance.UpdateMapStuff(this.scene.ow.AllMaps[currentArea + pos].Index, newAreaSize);

                        movedObjectCount++;
                    }

                    Console.WriteLine("Total entrances moved: " + movedObjectCount);

                    movedObjectCount = 0;
                    foreach (EntranceOW hole in this.scene.ow.AllHoles.Where(x => x.MapID == currentArea))
                    {
                        // If the AreaX is >= 32 we need to add 1.
                        int pos = hole.AreaX >= 32 ? 1 : 0;

                        // If the AreaY is >= 32 we need to add 8.
                        pos += hole.AreaY >= 32 ? 8 : 0;

                        hole.UpdateMapStuff(this.scene.ow.AllMaps[currentArea + pos].Index, newAreaSize);

                        movedObjectCount++;
                    }

                    Console.WriteLine("Total holes moved: " + movedObjectCount);

                    movedObjectCount = 0;
                    foreach (TransportOW bird in this.scene.ow.AllBirds.Where(x => x.MapID == currentArea))
                    {
                        // If the AreaX is >= 32 we need to add 1.
                        int pos = bird.AreaX >= 32 ? 1 : 0;

                        // If the AreaY is >= 32 we need to add 8.
                        pos += bird.AreaY >= 32 ? 8 : 0;

                        bird.updateMapStuff(this.scene.ow.AllMaps[currentArea + pos].Index, this.scene.ow);

                        movedObjectCount++;
                    }

                    Console.WriteLine("Total brids moved: " + movedObjectCount);

                    movedObjectCount = 0;
                    foreach (TransportOW whirlpool in this.scene.ow.AllWhirlpools.Where(x => x.MapID == currentArea))
                    {
                        // If the AreaX is >= 32 we need to add 1.
                        int pos = whirlpool.AreaX >= 32 ? 1 : 0;

                        // If the AreaY is >= 32 we need to add 8.
                        pos += whirlpool.AreaY >= 32 ? 8 : 0;

                        whirlpool.updateMapStuff(this.scene.ow.AllMaps[currentArea + pos].Index, this.scene.ow);

                        movedObjectCount++;
                    }

                    Console.WriteLine("Total whirlpools moved: " + movedObjectCount);

                    movedObjectCount = 0;
                    foreach (ExitOW exit in this.scene.ow.AllExits.Where(x => x.MapID == currentArea))
                    {
                        // If the AreaX is >= 32 we need to add 1.
                        int pos = exit.AreaX >= 32 ? 1 : 0;

                        // If the AreaY is >= 32 we need to add 8.
                        pos += exit.AreaY >= 32 ? 8 : 0;

                        exit.UpdateMapStuff(this.scene.ow.AllMaps[currentArea + pos].Index, this.scene.ow);

                        movedObjectCount++;
                    }

                    Console.WriteLine("Total exits moved: " + movedObjectCount);

                    movedObjectCount = 0;
                    foreach (RoomPotSaveEditor item in this.scene.ow.AllItems.Where(x => x.RoomMapID == currentArea))
                    {
                        // If the GameX is >= 32 we need to add 1.
                        int pos = item.GameX >= 32 ? 1 : 0;

                        // If the GameY is >= 32 we need to add 8.
                        pos += item.GameY >= 32 ? 8 : 0;

                        item.UpdateMapStuff(this.scene.ow.AllMaps[currentArea + pos].Index, newAreaSize);

                        movedObjectCount++;
                    }

                    Console.WriteLine("Total items moved: " + movedObjectCount);

                    movedObjectCount = 0;
                    foreach (Sprite sprite0 in this.scene.ow.AllSprites[0].Where(x => x.MapID == currentArea))
                    {
                        // If the x is >= 32 we need to add 1.
                        int pos = sprite0.x >= 32 ? 1 : 0;

                        // If the y is >= 32 we need to add 8.
                        pos += sprite0.y >= 32 ? 8 : 0;

                        sprite0.updateMapStuff(this.scene.ow.AllMaps[currentArea + pos].Index, newAreaSize);

                        movedObjectCount++;
                    }

                    Console.WriteLine("Total sprites (0,1) moved: " + movedObjectCount);

                    movedObjectCount = 0;
                    foreach (Sprite sprite1 in this.scene.ow.AllSprites[1].Where(x => x.MapID == currentArea))
                    {
                        // If the x is >= 32 we need to add 1.
                        int pos = sprite1.x >= 32 ? 1 : 0;

                        // If the y is >= 32 we need to add 8.
                        pos += sprite1.y >= 32 ? 8 : 0;

                        sprite1.updateMapStuff(this.scene.ow.AllMaps[currentArea + pos].Index, newAreaSize);

                        movedObjectCount++;
                    }

                    Console.WriteLine("Total sprites (2) moved: " + movedObjectCount);

                    movedObjectCount = 0;
                    foreach (Sprite sprite2 in this.scene.ow.AllSprites[2].Where(x => x.MapID == currentArea))
                    {
                        // If the x is >= 32 we need to add 1.
                        int pos = sprite2.x >= 32 ? 1 : 0;

                        // If the y is >= 32 we need to add 8.
                        pos += sprite2.y >= 32 ? 8 : 0;

                        sprite2.updateMapStuff(this.scene.ow.AllMaps[currentArea + pos].Index, newAreaSize);

                        movedObjectCount++;
                    }

                    Console.WriteLine("Total sprites (3) moved: " + movedObjectCount);
                }
            }

            // Move all of the overworld objects to into the new parent area.
            foreach (int world in worlds)
            {
                foreach (int offset in areasToAdd.Select(x => x.offset))
                {
                    int currentArea = mapID + world + offset;

                    foreach (EntranceOW entrance in this.scene.ow.AllEntrances.Where(x => x.MapID == currentArea))
                    {
                        entrance.UpdateMapStuff(this.scene.ow.AllMaps[currentArea].ParentID, newAreaSize);
                    }

                    foreach (EntranceOW hole in this.scene.ow.AllHoles.Where(x => x.MapID == currentArea))
                    {
                        hole.UpdateMapStuff(this.scene.ow.AllMaps[currentArea].ParentID, newAreaSize);
                    }

                    foreach (TransportOW transport in this.scene.ow.AllBirds.Where(x => x.MapID == currentArea))
                    {
                        transport.updateMapStuff(this.scene.ow.AllMaps[currentArea].ParentID, this.scene.ow);
                    }

                    foreach (TransportOW transport in this.scene.ow.AllWhirlpools.Where(x => x.MapID == currentArea))
                    {
                        transport.updateMapStuff(this.scene.ow.AllMaps[currentArea].ParentID, this.scene.ow);
                    }

                    foreach (ExitOW exit in this.scene.ow.AllExits.Where(x => x.MapID == currentArea))
                    {
                        exit.UpdateMapStuff(this.scene.ow.AllMaps[currentArea].ParentID, this.scene.ow);
                    }

                    foreach (RoomPotSaveEditor item in this.scene.ow.AllItems.Where(x => x.RoomMapID == currentArea))
                    {
                        item.UpdateMapStuff(this.scene.ow.AllMaps[currentArea].ParentID, newAreaSize);
                    }

                    foreach (Sprite sprite in this.scene.ow.AllSprites[0].Where(x => x.MapID == currentArea))
                    {
                        sprite.updateMapStuff(this.scene.ow.AllMaps[currentArea].ParentID, newAreaSize);
                    }

                    foreach (Sprite sprite in this.scene.ow.AllSprites[1].Where(x => x.MapID == currentArea))
                    {
                        sprite.updateMapStuff(this.scene.ow.AllMaps[currentArea].ParentID, newAreaSize);
                    }

                    foreach (Sprite sprite in this.scene.ow.AllSprites[2].Where(x => x.MapID == currentArea))
                    {
                        sprite.updateMapStuff(this.scene.ow.AllMaps[currentArea].ParentID, newAreaSize);
                    }
                }
            }

            Console.WriteLine("Done updating object locations ");
        }

        /// <summary>
        /// Clears all overworld sprites of the selected stage (beginning, 1st, and 2nd phase)
        /// </summary>
        /// <param name="phase"></param>
        public void clearOverworldSprites(int phase)
        {
            this.overworld.AllSprites[phase].Clear();
        }

        /// <summary>
        /// Clears all overworld items
        /// </summary>
        public void clearOverworldItems()
        {
            this.overworld.AllItems.Clear();
        }

        /// <summary>
        /// Clears all overworld entrances
        /// </summary>
        public void clearOverworldEntrances()
        {
            for (int i = 0; i < this.overworld.AllEntrances.Length; i++)
            {
                var entrance = this.overworld.AllEntrances[i];

                entrance.X = 0xFFFF;
                entrance.Y = 0xFFFF;
                entrance.MapID = 0;
                entrance.MapPos = 0xFFFF;
                entrance.EntranceID = 0;
                entrance.Deleted = true;

                //Console.WriteLine(Room_Name.room_name[i] + " X:" + entrance.x + " Y:" + entrance.y + " MapID:" + entrance.mapId + " MapPos:" + entrance.mapPos + " EntranceID:" + entrance.entranceId + " Deleted:" + entrance.deleted);
            }
        }

        /// <summary>
        /// Clears all overworld entrances
        /// </summary>
        public void clearOverworldHoles()
        {
            for (int i = 0; i < this.overworld.AllHoles.Length; i++)
            {
                var entrance = this.overworld.AllHoles[i];

                entrance.X = 0xFFFF;
                entrance.Y = 0xFFFF;
                entrance.MapID = 0;
                entrance.MapPos = 0xFFFF;
                entrance.EntranceID = 0;
                entrance.Deleted = true;
            }
        }

        /// <summary>
        /// Clears all overworld exits
        /// </summary>
        public void clearOverworldExits()
        {
            int i = 0;
            foreach (var exit in this.overworld.AllExits)
            {
                exit.PlayerX = 0xFFFF;
                exit.PlayerY = 0xFFFF;
                exit.MapID = 0;
                exit.RoomID = 0;
                exit.Deleted = true;

                string tname = "Exit [" + i.ToString("X2") + "] -> From room " + overworld.AllExits[i].RoomID.ToString("X4") + " DELETED";
                overworldexitsListbox.Items[i] = tname;
                i++;

            }
        }

        /// <summary>
        /// Clears all of the overworld overlays
        /// </summary>
        public void clearOverworldOverlays()
        {
            foreach (var overlay in this.overworld.AllOverlays)
            {
                overlay.TileDataList.Clear();
            }
        }

        /// <summary>
        /// Clears all overworld sprites of the selected stage (beginning, 1st, and 2nd phase)
        /// </summary>
        /// <param name="phase"></param>
        public void clearAreaSprites(int phase)
        {
            this.overworld.AllSprites[phase].RemoveAll(o => o.MapID == this.scene.selectedMapParent);
        }

        /// <summary>
        /// Clears all of the selected area's items
        /// </summary>
        public void clearAreaItems()
        {
            this.overworld.AllItems.RemoveAll(o => o.RoomMapID == this.scene.selectedMapParent);
        }

        /// <summary>
        /// Clears all the selected area's entrances
        /// </summary>
        public void clearAreaEntrances()
        {
            foreach (EntranceOW entrance in this.overworld.AllEntrances)
            {
                if (entrance.MapID == this.scene.selectedMapParent)
                {
                    entrance.X = 0xFFFF;
                    entrance.Y = 0xFFFF;
                    entrance.MapID = 0;
                    entrance.MapPos = 0xFFFF;
                    entrance.EntranceID = 0;
                    entrance.Deleted = true;
                }
            }
        }

        /// <summary>
        /// Clears all the slected area's entrances
        /// </summary>
        public void clearAreaHoles()
        {
            foreach (var hole in this.overworld.AllHoles)
            {
                if (hole.MapID == this.scene.selectedMapParent)
                {
                    hole.X = 0xFFFF;
                    hole.Y = 0xFFFF;
                    hole.MapID = 0;
                    hole.MapPos = 0xFFFF;
                    hole.EntranceID = 0;
                    hole.Deleted = true;
                }
            }
        }

        /// <summary>
        /// Clears all of the selected area's exits
        /// </summary>
        public void clearAreaExits()
        {
            foreach (var exit in this.overworld.AllExits)
            {
                if (exit.MapID == this.scene.selectedMapParent)
                {
                    exit.PlayerX = 0xFFFF;
                    exit.PlayerY = 0xFFFF;
                    exit.MapID = 0;
                    exit.RoomID = 0;
                    exit.Deleted = true;
                }
            }
        }

        /// <summary>
        ///     Clears all of the selected area's overlays
        /// </summary>
        public void clearAreaOverlays()
        {
            this.overworld.AllOverlays[this.scene.selectedMapParent].TileDataList.Clear();
            this.scene.Refresh();
        }

        /// <summary>
        ///     Called when the area background color box is double cliked, brings up color editor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AreaBGColorPicturebox_MouseDoubleClick(object sender, EventArgs e)
        {
            int selectedParent = this.scene.ow.AllMaps[this.scene.selectedMap].ParentID;

            this.cd.Color = Palettes.OverworldBackgroundPalette[selectedParent];
            if (this.cd.ShowDialog() == DialogResult.OK)
            {
                Palettes.OverworldBackgroundPalette[selectedParent] = this.cd.Color;
                this.areaBGColorPictureBox.Refresh();
            }

            this.mainForm.overworldEditor.overworld.AllMaps[selectedParent].LoadPalette();
        }

        /// <summary>
        ///     Paints the Area Background color box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AreaBGColorPicturebox_Paint(object sender, PaintEventArgs e)
        {
            int selectedParent = this.scene.ow.AllMaps[this.scene.selectedMap].ParentID;

            if (selectedParent < Palettes.OverworldBackgroundPalette.Length)
            {
                e.Graphics.FillRectangle(new SolidBrush(Palettes.OverworldBackgroundPalette[selectedParent]), Constants.Rect_0_0_24_24);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Black), Constants.Rect_0_0_24_24);
            }
        }

        public void SetSelectedObjectLabels(int id, int x, int y)
        {
            this.SelectedObjectID.Text = id.ToString("X4");
            this.SelectedObjectX.Text = x.ToString("X2");
            this.SelectedObjectY.Text = y.ToString("X2");
        }

        public void SetSelectedObjectLabels(string id, string x, string y)
        {
            this.SelectedObjectID.Text = id;
            this.SelectedObjectX.Text = x;
            this.SelectedObjectY.Text = y;
        }

        private void exportPNGToolStripButton_Click(object sender, EventArgs e)
        {
            Bitmap temp = new Bitmap(4096, 4096);
            Graphics g = Graphics.FromImage(temp);

            if (UseAreaSpecificBgColor)
            {
                for (int i = 0; i < 64; i++)
                {
                    int x = (i % 8) * 512;
                    int y = (i / 8) * 512;

                    int k = this.overworld.AllMaps[i].ParentID;
                    g.FillRectangle(new SolidBrush(Palettes.OverworldBackgroundPalette[k]), new Rectangle(x, y, 512, 512));
                }
            }
            else
            {
                g.FillRectangle(new SolidBrush(Palettes.OverworldGrassPalettes[0]), new Rectangle(0, 0, 4096, 4096));
            }

            for (int i = 0; i < 64; i++)
            {
                int x = (i % 8) * 512;
                int y = (i / 8) * 512;

                g.DrawImage(this.overworld.AllMaps[i].GFXBitmap, x, y, new Rectangle(0, 0, 512, 512), GraphicsUnit.Pixel);
            }

            /*foreach (T32UniqueCounter t32 in mainForm.tilesToDraw)
            {
                // LW
                if (t32.x < 4096)
                {
                    byte alpha = (byte)(40 + t32.count);
                    if (alpha >= 160)
                    {
                        alpha = 160;
                    }
                    if (t32.count == 1)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(150, 55, 255, 0)), new Rectangle(t32.x, t32.y, 32, 32));
                    }
                    else if (t32.count <= 5)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(150, 255, 255, 0)), new Rectangle(t32.x, t32.y, 32, 32));
                    }
                    else
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(alpha, 255, 0, 0)), new Rectangle(t32.x, t32.y, 32, 32));
                    }

                }
            }
            */

            temp.Save("LW.png");

            temp = new Bitmap(4096, 4096);
            g = Graphics.FromImage(temp);

            if (UseAreaSpecificBgColor)
            {
                for (int i = 0; i < 64; i++)
                {
                    int x = (i % 8) * 512;
                    int y = (i / 8) * 512;

                    int k = this.overworld.AllMaps[i].ParentID;
                    g.FillRectangle(new SolidBrush(Palettes.OverworldBackgroundPalette[k + 64]), new Rectangle(x, y, 512, 512));
                }
            }
            else
            {
                g.FillRectangle(new SolidBrush(Palettes.OverworldGrassPalettes[1]), new Rectangle(0, 0, 4096, 4096));
            }

            for (int i = 0; i < 64; i++)
            {
                int x = (i % 8) * 512;
                int y = (i / 8) * 512;

                g.DrawImage(this.overworld.AllMaps[i + 64].GFXBitmap, x, y, new Rectangle(0, 0, 512, 512), GraphicsUnit.Pixel);
            }

            temp.Save("DW.png");

            temp = new Bitmap(4096, 4096);
            g = Graphics.FromImage(temp);

            if (UseAreaSpecificBgColor)
            {
                for (int i = 0; i < 32; i++)
                {
                    int x = (i % 8) * 512;
                    int y = (i / 8) * 512;

                    int k = this.overworld.AllMaps[i].ParentID;
                    g.FillRectangle(new SolidBrush(Palettes.OverworldBackgroundPalette[k + 128]), new Rectangle(x, y, 512, 512));
                }
            }
            else
            {
                g.FillRectangle(new SolidBrush(Palettes.OverworldGrassPalettes[1]), new Rectangle(0, 0, 4096, 4096));
            }

            for (int i = 0; i < 32; i++)
            {
                int x = (i % 8) * 512;
                int y = (i / 8) * 512;

                g.DrawImage(this.overworld.AllMaps[i + 128].GFXBitmap, x, y, new Rectangle(0, 0, 512, 512), GraphicsUnit.Pixel);
            }

            temp.Save("SP.png");
        }

        public void UpdateBGColorVisibility(bool x)
        {
            this.label7.Visible = x;
            this.areaBGColorPictureBox.Visible = x;
        }

        private void leftmosaicCheckbox_Click(object sender, EventArgs e)
        {
            int parentID = this.scene.ow.AllMaps[this.scene.selectedMap].ParentID;
            (bool Up, bool Down, bool Left, bool Right) tempMosaic = this.scene.ow.AllMaps[parentID].Mosaic;
            tempMosaic.Left = this.leftmosaicCheckbox.Checked;
            this.scene.ow.AllMaps[parentID].Mosaic = tempMosaic;
        }

        private void topmosaicCheckbox_Click(object sender, EventArgs e)
        {
            int parentID = this.scene.ow.AllMaps[this.scene.selectedMap].ParentID;
            (bool Up, bool Down, bool Left, bool Right) tempMosaic = this.scene.ow.AllMaps[parentID].Mosaic;
            tempMosaic.Up = this.topmosaicCheckbox.Checked;
            this.scene.ow.AllMaps[parentID].Mosaic = tempMosaic;
        }

        private void rightmosaicCheckbox_Click(object sender, EventArgs e)
        {
            int parentID = this.scene.ow.AllMaps[this.scene.selectedMap].ParentID;
            (bool Up, bool Down, bool Left, bool Right) tempMosaic = this.scene.ow.AllMaps[parentID].Mosaic;
            tempMosaic.Right = this.rightmosaicCheckbox.Checked;
            this.scene.ow.AllMaps[parentID].Mosaic = tempMosaic;
        }

        private void bottommosaicCheckbox_Click(object sender, EventArgs e)
        {
            int parentID = this.scene.ow.AllMaps[this.scene.selectedMap].ParentID;
            (bool Up, bool Down, bool Left, bool Right) tempMosaic = this.scene.ow.AllMaps[parentID].Mosaic;
            tempMosaic.Down = this.bottommosaicCheckbox.Checked;
            this.scene.ow.AllMaps[parentID].Mosaic = tempMosaic;
        }

        public void SendLargeMapChanged(int m, AreaSizeEnum areaSize)
        {
            if (!NetZS.connected)
            {
                return;
            }

            NetZSBuffer buffer = new NetZSBuffer(8);
            buffer.Write((byte)12); // sprite data
            buffer.Write((byte)NetZS.userID); // user ID
            buffer.Write((int)m);
            buffer.Write((byte)areaSize); // is checked
            NetOutgoingMessage msg = NetZS.client.CreateMessage();
            msg.Write(buffer.buffer);
            NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
            NetZS.client.FlushSendQueue();
        }

        public void SendMapProperties(OverworldMap map)
        {
            if (!NetZS.connected)
            {
                return;
            }

            NetZSBuffer buffer = new NetZSBuffer(16);
            buffer.Write((byte)13); // map properties
            buffer.Write((byte)NetZS.userID); // user ID
            buffer.Write((byte)map.Index);
            buffer.Write((byte)map.AuxPalette);
            buffer.Write((byte)map.GFX);
            buffer.Write((short)map.MessageID);

            if (map.Index >= 64)
            {
                buffer.Write((byte)0);
                buffer.Write((byte)map.SpriteGFX[0]);
                buffer.Write((byte)map.SpritePalette[0]);
            }
            else
            {
                buffer.Write((byte)this.scene.ow.GameState);
                buffer.Write((byte)map.SpriteGFX[this.scene.ow.GameState]);
                buffer.Write((byte)map.SpritePalette[this.scene.ow.GameState]);
            }

            NetOutgoingMessage msg = NetZS.client.CreateMessage();
            msg.Write(buffer.buffer);
            NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
            NetZS.client.FlushSendQueue();
        }

        private void music1Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fromForm)
            {
                this.scene.ow.AllMaps[this.scene.selectedMapParent].Music[0] = (byte)((ambient1Box.SelectedIndex << 4) + music1Box.SelectedIndex);
                this.scene.ow.AllMaps[this.scene.selectedMapParent].Music[1] = (byte)((ambient2Box.SelectedIndex << 4) + music2Box.SelectedIndex);
                this.scene.ow.AllMaps[this.scene.selectedMapParent].Music[2] = (byte)((ambient3Box.SelectedIndex << 4) + music3Box.SelectedIndex);
                this.scene.ow.AllMaps[this.scene.selectedMapParent].Music[3] = (byte)((ambient4Box.SelectedIndex << 4) + music4Box.SelectedIndex);
            }
        }

        byte[] previewSheets = new byte[1];
        byte globalPalPreview = 8;
        bool ispalPreview = false;

        private void OWProperty_SPRGFX_MouseEnter(object sender, EventArgs e)
        {
            ispalPreview = false;
            previewsheetPicturebox.Location = new Point(0, (sender as Hexbox).Location.Y + 48);

            previewSheets = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                previewSheets[i] = (byte)(ROM.DATA[Constants.sprite_blockset_pointer + (OWProperty_SPRGFX.HexValue * 4) + i] + 115);
            }

            previewsheetPicturebox.Height = (64 * 4);
            previewsheetPicturebox.Visible = true;
            previewsheetPicturebox.Refresh();
        }

        private void OWProperty_SPRGFX_MouseLeave(object sender, EventArgs e)
        {
            previewsheetPicturebox.Visible = false;
        }

        private void previewsheetPicturebox_Paint(object sender, PaintEventArgs e)
        {
            if (ispalPreview)
            {
                for (int i = 0; i < 256; i++)
                {
                    e.Graphics.FillRectangle(new SolidBrush(scene.ow.AllMaps[scene.selectedMapParent].GFXBitmap.Palette.Entries[i]), new Rectangle((i % 16) * 16, (i / 16) * 16, 16, 16));
                }
            }
            else
            {
                for (int i = 0; i < previewSheets.Length; i++)
                {
                    if (previewSheets[i] >= 0xDE)
                    {
                        previewSheets[i] = 0x00;
                    }
                }

                ColorPalette cp = GFX.allgfxBitmap.Palette;
                byte paloffset = 0;
                if (previewSheets.Length > 1)
                {
                    paloffset = 8;
                }

                for (int i = 0; i < 16; i++)
                {

                    cp.Entries[i] = scene.ow.AllMaps[scene.selectedMapParent].GFXBitmap.Palette.Entries[i + ((globalPalPreview + paloffset) * 16)];
                }

                GFX.allgfxBitmap.Palette = cp;

                e.Graphics.CompositingMode = CompositingMode.SourceCopy;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                for (int i = 0; i < previewSheets.Length; i++)
                {
                    e.Graphics.DrawImage(GFX.allgfxBitmap, new Rectangle(0, i * 64, 256, 64), new Rectangle(0, previewSheets[i] * 32, 128, 32), GraphicsUnit.Pixel);
                }
            }
        }

        private void paletteCyclingTimer_Tick(object sender, EventArgs e)
        {
            globalPalPreview++;
            if (globalPalPreview >= 8)
            {
                globalPalPreview = 0;
            }

            previewsheetPicturebox.Refresh();
        }

        private void OWProperty_TileGFX0_MouseLeave(object sender, EventArgs e)
        {
            previewsheetPicturebox.Visible = false;
        }

        private void OWProperty_TileGFX0_MouseEnter(object sender, EventArgs e)
        {
            ispalPreview = false;
            previewsheetPicturebox.Location = new Point(0, (sender as Hexbox).Location.Y + 48);
            //if ((sender as Hexbox).HexValue )
            previewSheets = new byte[1];
            previewSheets[0] = (byte)((sender as Hexbox).HexValue);

            previewsheetPicturebox.Height = 64;
            previewsheetPicturebox.Visible = true;
            previewsheetPicturebox.Refresh();
        }

        private void OWProperty_MainPalette_MouseEnter(object sender, EventArgs e)
        {
            ispalPreview = true;

            previewsheetPicturebox.Location = new Point(0, (sender as Hexbox).Location.Y + 48);
            previewsheetPicturebox.Visible = true;
            previewsheetPicturebox.Height = 256;
            previewsheetPicturebox.Refresh();
        }

        private void OWProperty_MainPalette_MouseLeave(object sender, EventArgs e)
        {
            ispalPreview = false;
            previewsheetPicturebox.Visible = false;
        }

        private void lwmodeButton_Click(object sender, EventArgs e)
        {
            this.SelectMapOffset(0);
        }

        private void owentrancesListbox_DoubleClick(object sender, EventArgs e)
        {
            entranceModeButton.PerformClick();

            EntranceOW eow = overworld.AllEntrances[owentrancesListbox.SelectedIndex];

            int xView = (eow.X - (splitContainer1.Panel2.Width / 2));
            xView = xView.Clamp(0, 4096 - splitContainer1.Panel2.Width);

            int yView = (eow.Y - (splitContainer1.Panel2.Height / 2));
            yView = yView.Clamp(0, 4096 - splitContainer1.Panel2.Width);
            splitContainer1.Panel2.AutoScrollPosition = new Point(xView, yView);

            scene.selectedMode = ObjectMode.Entrances;
            scene.entranceMode.selectedEntrance = eow;
            scene.entranceMode.lastselectedEntrance = eow;
            scene.entranceMode.onMouseDown(new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0));

            if (eow.MapID < 0x40)
            {
                this.SelectMapOffset(0x00);
            }
            else if (eow.MapID >= 0x40)
            {
                this.SelectMapOffset(0x40);
            }
        }

        public void owentrancesListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fromForm = true;
            if (owentrancesListbox.SelectedIndex != -1)
            {
                EntranceOW eow = overworld.AllEntrances[owentrancesListbox.SelectedIndex];

                scene.entranceMode.selectedEntrance = eow;
                scene.entranceMode.lastselectedEntrance = eow;
                //scene.entranceMode.onMouseDown(new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0));
                scene.entranceMode.ShowRoomPreview();

                owentrance_property_entranceid.HexValue = scene.entranceMode.lastselectedEntrance.EntranceID;
                owentrance_property_ishole.Checked = scene.entranceMode.lastselectedEntrance.IsHole;
                owentrance_property_mapid.HexValue = scene.entranceMode.lastselectedEntrance.MapID;
                owentrance_property_mappos.HexValue = scene.entranceMode.lastselectedEntrance.MapPos;
                owentrance_property_x.HexValue = scene.entranceMode.lastselectedEntrance.X;
                owentrance_property_y.HexValue = scene.entranceMode.lastselectedEntrance.Y;

                string text = "Entrance";

                if (scene.entranceMode.lastselectedEntrance != null)
                {
                    scene.owForm.SetSelectedObjectLabels(
                        scene.entranceMode.lastselectedEntrance.EntranceID,
                        scene.entranceMode.lastselectedEntrance.X,
                        scene.entranceMode.lastselectedEntrance.Y);
                }

                scene.owForm.objectGroupbox.Text = text;
            }

            fromForm = false;
        }

        private void owentrance_property_entranceid_TextChanged(object sender, EventArgs e)
        {
            if (!scene.entranceMode.lastselectedEntrance.Deleted)
            {
                if (!fromForm)
                {
                    scene.entranceMode.lastselectedEntrance.EntranceID = (byte)owentrance_property_entranceid.HexValue;
                    scene.entranceMode.lastselectedEntrance.IsHole = owentrance_property_ishole.Checked;
                    scene.entranceMode.lastselectedEntrance.MapID = (short)owentrance_property_mapid.HexValue;
                    scene.entranceMode.lastselectedEntrance.MapPos = (ushort)owentrance_property_mappos.HexValue;
                    scene.entranceMode.lastselectedEntrance.X = (ushort)owentrance_property_x.HexValue;
                    scene.entranceMode.lastselectedEntrance.Y = (ushort)owentrance_property_y.HexValue;

                    scene.entranceMode.lastselectedEntrance.UpdateMapStuff(scene.exitmode.lastselectedExit.MapID, this.scene.ow.AllMaps[scene.entranceMode.lastselectedEntrance.MapID].AreaSize);
                    string tname = "OW[" + owentrancesListbox.SelectedIndex.ToString("X2") + "] -> UW";
                    foreach (DataRoom dataRoom in ROMStructure.dungeonsRoomList)
                    {
                        if (dataRoom.ID == DungeonsData.Entrances[overworld.AllEntrances[owentrancesListbox.SelectedIndex].EntranceID].Room)
                        {
                            tname += "[" + overworld.AllEntrances[owentrancesListbox.SelectedIndex].EntranceID.ToString("X2") + "]" + dataRoom.Name;

                            break;
                        }
                    }

                    owentrancesListbox.Items[owentrancesListbox.SelectedIndex] = tname;
                }
            }
            else
            {
                string tname = "OW[" + owentrancesListbox.SelectedIndex.ToString("X2") + "] -> DELETED";
                owentrancesListbox.Items[owentrancesListbox.SelectedIndex] = tname;
            }
        }

        private void overworldexitsListbox_DoubleClick(object sender, EventArgs e)
        {
            exitModeButton.PerformClick();

            ExitOW eow = overworld.AllExits[overworldexitsListbox.SelectedIndex];

            int xView = (eow.PlayerX - (splitContainer1.Panel2.Width / 2));
            xView = xView.Clamp(0, 4096 - splitContainer1.Panel2.Width);

            int yView = (eow.PlayerY - (splitContainer1.Panel2.Height / 2));
            yView = yView.Clamp(0, 4096 - splitContainer1.Panel2.Width);
            splitContainer1.Panel2.AutoScrollPosition = new Point(xView, yView);

            scene.selectedMode = ObjectMode.Exits;
            scene.exitmode.selectedExit = eow;
            scene.exitmode.lastselectedExit = eow;
            scene.exitmode.onMouseDown(new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0));


            if (eow.MapID < 0x40)
            {
                this.SelectMapOffset(0);
            }
            else if (eow.MapID >= 0x40)
            {
                this.SelectMapOffset(0x40);
            }
        }

        private void roomUpDown_TextChanged(object sender, EventArgs e)
        {
            if (!fromForm)
            {
                scene.exitmode.lastselectedExit.RoomID = (ushort)owexit_room_property.HexValue;
                scene.exitmode.lastselectedExit.MapID = (byte)owexit_map_property.HexValue;
                scene.exitmode.lastselectedExit.PlayerX = (ushort)owexit_x_property.HexValue;
                scene.exitmode.lastselectedExit.PlayerY = (ushort)owexit_y_property.HexValue;
                scene.exitmode.lastselectedExit.CameraX = (ushort)owexit_xcamera_property.HexValue;
                scene.exitmode.lastselectedExit.CameraY = (ushort)owexit_ycamera_property.HexValue;
                scene.exitmode.lastselectedExit.XScroll = (ushort)owexit_xscroll_property.HexValue;
                scene.exitmode.lastselectedExit.YScroll = (ushort)owexit_yscroll_property.HexValue;
                scene.exitmode.lastselectedExit.DoorXEditor = (byte)owexit_doorx_property.HexValue;
                scene.exitmode.lastselectedExit.DoorXEditor = (byte)owexit_doory_property.HexValue;

                if (wooddoorradioButton.Checked)
                {
                    if (scene.exitmode.lastselectedExit.DoorXEditor == 0 && scene.exitmode.lastselectedExit.DoorYEditor == 0)
                    {
                        scene.exitmode.lastselectedExit.DoorXEditor = 1;
                    }

                    scene.exitmode.lastselectedExit.DoorType1 = (ushort)((scene.exitmode.lastselectedExit.DoorYEditor << 6) | (scene.exitmode.lastselectedExit.DoorXEditor & 0x3F) << 1);
                    scene.exitmode.lastselectedExit.DoorType2 = 0;
                }
                else if (sancdoorButton.Checked)
                {
                    if (scene.exitmode.lastselectedExit.DoorXEditor == 0 && scene.exitmode.lastselectedExit.DoorYEditor == 0)
                    {
                        scene.exitmode.lastselectedExit.DoorXEditor = 1;
                    }

                    scene.exitmode.lastselectedExit.DoorType2 = (ushort)((scene.exitmode.lastselectedExit.DoorYEditor << 6) | (scene.exitmode.lastselectedExit.DoorXEditor & 0x3F) << 1);
                    scene.exitmode.lastselectedExit.DoorType1 = 0;
                }
                else if (bombdoorradioButton.Checked)
                {
                    if (scene.exitmode.lastselectedExit.DoorXEditor == 0 && scene.exitmode.lastselectedExit.DoorYEditor == 0)
                    {
                        scene.exitmode.lastselectedExit.DoorXEditor = 1;
                    }

                    scene.exitmode.lastselectedExit.DoorType1 = (ushort)(((scene.exitmode.lastselectedExit.DoorYEditor << 6) | (scene.exitmode.lastselectedExit.DoorXEditor & 0x3F) << 1) + 0x8000);
                    scene.exitmode.lastselectedExit.DoorType2 = 0;
                }
                else if (castledoorradioButton.Checked)
                {
                    if (scene.exitmode.lastselectedExit.DoorXEditor == 0 && scene.exitmode.lastselectedExit.DoorYEditor == 0)
                    {
                        scene.exitmode.lastselectedExit.DoorXEditor = 1;
                    }

                    scene.exitmode.lastselectedExit.DoorType2 = (ushort)(((scene.exitmode.lastselectedExit.DoorYEditor << 6) | (scene.exitmode.lastselectedExit.DoorXEditor & 0x3F) << 1) + 0x8000);
                    scene.exitmode.lastselectedExit.DoorType1 = 0;
                }
                else
                {
                    scene.exitmode.lastselectedExit.DoorXEditor = 0;
                    scene.exitmode.lastselectedExit.DoorXEditor = 0;
                    scene.exitmode.lastselectedExit.DoorType2 = 0;
                    scene.exitmode.lastselectedExit.DoorType1 = 0;
                }

                scene.exitmode.lastselectedExit.UpdateMapStuff(scene.exitmode.lastselectedExit.MapID, overworld);

                string tname = "Exit [" + overworldexitsListbox.SelectedIndex.ToString("X2") + "] -> From room " + overworld.AllExits[overworldexitsListbox.SelectedIndex].RoomID.ToString("X4");
                if (overworld.AllExits[overworldexitsListbox.SelectedIndex].RoomID >= 320)
                {
                    tname += " Ending Cutscene";
                }

                if (overworld.AllExits[overworldexitsListbox.SelectedIndex].PlayerX == 0xFFFF)
                {
                    tname += " DELETED";
                }
                scene.exitmode.ShowExitPreview();
                overworldexitsListbox.Items[overworldexitsListbox.SelectedIndex] = tname;
                
                thumbnailBox.Refresh();
                scene.Refresh();
            }
        }

        public void overworldexitsListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fromForm = true;
            if (overworldexitsListbox.SelectedIndex != -1)
            {
                ExitOW eow = overworld.AllExits[overworldexitsListbox.SelectedIndex];

                scene.exitmode.selectedExit = eow;
                scene.exitmode.lastselectedExit = eow;
                //scene.exitmode.onMouseDown(new MouseEventArgs(MouseButtons.None, 0, 0, 0, 0));
                scene.exitmode.ShowExitPreview();

                owexit_room_property.HexValue = scene.exitmode.lastselectedExit.RoomID;
                owexit_map_property.HexValue = scene.exitmode.lastselectedExit.MapID;
                owexit_x_property.HexValue = scene.exitmode.lastselectedExit.PlayerX;
                owexit_y_property.HexValue = scene.exitmode.lastselectedExit.PlayerY;
                owexit_xcamera_property.HexValue = scene.exitmode.lastselectedExit.CameraX;
                owexit_ycamera_property.HexValue = scene.exitmode.lastselectedExit.CameraY;
                owexit_xscroll_property.HexValue = scene.exitmode.lastselectedExit.XScroll;
                owexit_yscroll_property.HexValue = scene.exitmode.lastselectedExit.YScroll;
                owexit_doorx_property.HexValue = scene.exitmode.lastselectedExit.DoorXEditor;
                owexit_doory_property.HexValue = scene.exitmode.lastselectedExit.DoorYEditor;
                nodoorradioButton.Checked = true;

                if ((scene.exitmode.lastselectedExit.DoorType1 & 0x8000) != 0)
                {
                    bombdoorradioButton.Checked = true;
                }
                else if (scene.exitmode.lastselectedExit.DoorType1 != 0)
                {
                    wooddoorradioButton.Checked = true;
                }
                else if ((scene.exitmode.lastselectedExit.DoorType2 & 0x8000) != 0)
                {
                    castledoorradioButton.Checked = true;
                }
                else if (scene.exitmode.lastselectedExit.DoorType2 != 0)
                {
                    sancdoorButton.Checked = true;
                }

                string text = "Exit";

                if (scene.exitmode.lastselectedExit != null)
                {
                    scene.owForm.SetSelectedObjectLabels(
                        scene.exitmode.lastselectedExit.MapID,
                        scene.exitmode.lastselectedExit.PlayerX,
                        scene.exitmode.lastselectedExit.PlayerY);
                }

                scene.owForm.objectGroupbox.Text = text;
            }

            fromForm = false;
        }

        private void setPositionButton_Click(object sender, EventArgs e)
        {
            if (scene.exitmode.lastselectedExit is null)
            {
                return;
            }

            scene.selectedMode = ObjectMode.OWDoor;
            if (scene.exitmode.lastselectedExit.DoorType1 != 0) // Wooden door
            {
                scene.selectedTile = new ushort[2];
                scene.selectedTileSizeX = 2;
                scene.selectedTile[0] = 1865;
                scene.selectedTile[1] = 1866;
            }
            else if ((scene.exitmode.lastselectedExit.DoorType2 & 0x8000) != 0) // Castle door
            {
                scene.selectedTile = new ushort[4];
                scene.selectedTileSizeX = 2;
                scene.selectedTile[0] = 3510;
                scene.selectedTile[1] = 3511;
                scene.selectedTile[2] = 3512;
                scene.selectedTile[3] = 3513;
            }
            else if ((scene.exitmode.lastselectedExit.DoorType2 & 0x7FFF) != 0) // Sanctuary door
            {
                scene.selectedTile = new ushort[2];
                scene.selectedTileSizeX = 2;
                scene.selectedTile[0] = 3502;
                scene.selectedTile[1] = 3503;
            }
        }
    }
}
