using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor.Gui
{
    public partial class Tile16Editor : Form
    {
        SceneOW scene;
        ushort tile8selected = 0;
        bool fromForm = false;
        byte[] tempTiletype = new byte[0x200];

        Tile16[] allTiles = new Tile16[Constants.NumberOfMap16Ex];

        ushort searchedTile = 0xFFFF;

        Tile16 copiedTile;

        // TODO: Switch to entities.cs version, etc.
        string[] tilesTypesNames = new string[0xFF];

        private bool MadeChange = false;
        private bool cancelClosing = false;

        Label[] sheetLabels = new Label[16];

        Color fColor = Color.FromArgb(200, 255, 200, 200);
        Font f = new Font("Arial", 12, FontStyle.Regular);
        byte[] IndividualSheetsCollisionsData = new byte[0x2000];

        int lastIndex = -1;
        bool mouseDown = false;

        public Tile16Editor(SceneOW scene)
        {
            this.scene = scene;
            InitializeComponent();

            panel1.VerticalScroll.SmallChange = 32;
            panel1.VerticalScroll.LargeChange = 32;
            byte[] sheets = new byte[8];
            sheets[0] = scene.ow.AllMaps[scene.selectedMap].TileGFX0;
            sheets[1] = scene.ow.AllMaps[scene.selectedMap].TileGFX1;
            sheets[2] = scene.ow.AllMaps[scene.selectedMap].TileGFX2;
            sheets[3] = scene.ow.AllMaps[scene.selectedMap].TileGFX3;
            sheets[4] = scene.ow.AllMaps[scene.selectedMap].TileGFX4;
            sheets[5] = scene.ow.AllMaps[scene.selectedMap].TileGFX5;
            sheets[6] = scene.ow.AllMaps[scene.selectedMap].TileGFX6;
            sheets[7] = scene.ow.AllMaps[scene.selectedMap].TileGFX7;

            for (int i = 0; i<8; i++)
            {
                sheetLabels[i] = new Label();
                sheetLabels[i].Text = sheets[i].ToString("X2");
                sheetLabels[i].Font = sheetLabel.Font;
                sheetLabels[i].Location = new Point(257, 28 + (i * 64));
            }

            panel2.Controls.AddRange(sheetLabels);
        }

        /// <summary>
        ///     TODO: Called every frame? updates the appearance of the tile 8 window.
        /// </summary>
        public unsafe void updateTiles()
        {
            ushort.TryParse(tileUpDown.Text, System.Globalization.NumberStyles.HexNumber, null, out ushort tempTile);

            tile8selected = tempTile;

            byte p = (byte)paletteUpDown.Value;
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
                        CopyTile(x, y, xx, yy, i, p, destPtr, srcPtr);
                    }
                }

                xx += 8;
                if (xx >= 128)
                {
                    yy += 1024;
                    xx = 0;
                }
            }

            GFX.editort16Bitmap.Palette = scene.ow.AllMaps[scene.selectedMap].GFXBitmap.Palette;
            pictureboxTile8.Refresh();
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
            var index = xx + yy + offset + (mx * 2) + (my * 16);
            var pixel = gfx8Pointer[tx + (y * 64) + x];

            gfx16Pointer[index + r ^ 1] = (byte)((pixel & 0x0F) + tile.palette * 16);
            gfx16Pointer[index + r] = (byte)(((pixel >> 4) & 0x0F) + tile.palette * 16);
        }

        private unsafe void CopyTile(int x, int y, int xx, int yy, int id, byte p, byte* gfx16Pointer, byte* gfx8Pointer)
        {
            int mx = x;
            int my = y;
            byte r = 0;

            if (mirrorXCheckbox.Checked)
            {
                mx = 3 - x;
                r = 1;
            }
            if (mirrorYCheckbox.Checked)
            {
                my = 7 - y;
            }

            int tx = ((id / 16) * 512) + ((id - ((id / 16) * 16)) * 4);
            var index = xx + yy + (mx * 2) + (my * 128);
            var pixel = gfx8Pointer[tx + (y * 64) + x];

            gfx16Pointer[index + r ^ 1] = (byte)((pixel & 0x0F) + p * 16);
            gfx16Pointer[index + r] = (byte)(((pixel >> 4) & 0x0F) + p * 16);
        }

        private void pictureboxTile8_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            e.Graphics.DrawImage(GFX.editort16Bitmap, Constants.Rect_0_0_256_1024);

            if (gridcheckBox.Checked)
            {
                for (int xs = 0; xs < 16; xs++)
                {
                    e.Graphics.DrawLine(Constants.ThirdWhitePen1, xs * 16, 0, xs * 16, 1024);

                }
                for (int ys = 0; ys < 256; ys++)
                {
                    e.Graphics.DrawLine(Constants.ThirdWhitePen1, 0, ys * 16, 256, ys * 16);
                }
            }

            int y = (tile8selected / 16);
            int x = tile8selected - (y * 16);

            
            e.Graphics.DrawRectangle(Pens.GreenYellow, new Rectangle(x * 16, y * 16, tiledrawsizeHexbox.HexValue*16, tiledrawsizeHexbox.HexValue * 16));
        }

        private void mirrorXCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!fromForm)
            {
                updateTiles();
            }

            if (tile8selected >= 512)
            {
                tileTypeBox.Enabled = false;
            }
            else
            {
                tileTypeBox.Enabled = true;
                tileTypeBox.SelectedIndex = (int)tempTiletype[tile8selected];
            }
        }

        private void pictureboxTile16_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.CompositingQuality = CompositingQuality.Default;
            e.Graphics.CompositingMode = CompositingMode.SourceCopy;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            //e.Graphics.DrawImage(GFX.editortileBitmap, new Rectangle(0, 0, 64, 64));
            e.Graphics.DrawImage(GFX.mapblockset16Bitmap, new RectangleF(0f, 0f, 256.5f, Constants.Tile16EdiorBitmapSizex2), new RectangleF(0, 0, 128, Constants.Tile16EdiorBitmapSize), GraphicsUnit.Pixel);
            //e.Graphics.DrawImage(GFX.mapblockset16Bitmap, new RectangleF(256f, 0f, 256.5f, 8000f), new RectangleF(0, 4000, 128, 4000-192), GraphicsUnit.Pixel);

            if (gridcheckBox.Checked)
            {
                for (int x = 0; x < 16; x++)
                {
                    e.Graphics.DrawLine(Constants.White100Pen1, x * 32, 0, x * 32, Constants.Tile16EdiorBitmapSizex2);

                }
                for (int y = 0; y < 512; y++)
                {
                    e.Graphics.DrawLine(Constants.White100Pen1, 0, y * 32, 256, y * 32);
                }
            }

            int xP = (scene.selectedTile[0] % 8) * 32;
            int yP = ((scene.selectedTile[0] / 8)) * 32;

            if (searchedTile != 0xFFFF)
            {
                int xP2 = (searchedTile % 8) * 32;
                int yP2 = ((searchedTile / 8)) * 32;
                e.Graphics.DrawRectangle(Constants.Orange220Pen1, new Rectangle(xP2, yP2, 32, 32));
            }

            /*
            if (scene.selectedTile[0] >= 2000)
            {
                yP -= 8000;
                xP += 256;
            }
            */
            e.Graphics.DrawRectangle(Constants.Red220Pen1, new Rectangle(xP, yP, 32, 32));

            //e.Graphics.DrawLine(new Pen(Color.FromArgb(80, Color.White), 1), 32, 0, 32, 64);
            //e.Graphics.DrawLine(new Pen(Color.FromArgb(80, Color.White), 1), 0, 32, 64, 32);

            // This is the logic that determines how to highlight tiles when right clicking the tile8 box.
            if (highlightedTile8)
            {
                e.Graphics.CompositingMode = CompositingMode.SourceOver;
                ushort.TryParse(tileUpDown.Text, System.Globalization.NumberStyles.HexNumber, null, out ushort selectedTile);

                for (int i = 0; i < allTiles.Length; i++)
                {
                    int tileX = i % 8;
                    int tileY = i / 8;
                    if (selectedTile == allTiles[i].Tile0.id)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(80, 150, 0, 210)), new Rectangle((tileX * 2) * 16, (tileY * 2) * 16, 16, 16));
                    }

                    if (selectedTile == allTiles[i].Tile1.id)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(80, 150, 0, 210)), new Rectangle(((tileX * 2) * 16) + 16, (tileY * 2) * 16, 16, 16));
                    }

                    if (selectedTile == allTiles[i].Tile2.id)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(80, 150, 0, 210)), new Rectangle((tileX * 2) * 16, ((tileY * 2) * 16) + 16, 16, 16));
                    }

                    if (selectedTile == allTiles[i].Tile3.id)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(80, 150, 0, 210)), new Rectangle(((tileX * 2) * 16) + 16, ((tileY * 2) * 16) + 16, 16, 16));
                    }
                }
            }
        }

        public bool highlightedTile8 = false;

        /// <summary>
        /// Called when the tile 8 window is single left clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureboxTile8_MouseDown(object sender, MouseEventArgs e)
        {
            fromForm = true;
            int tid = (e.X / 16) + ((e.Y / 16) * 16);
            tileUpDown.Text = tid.ToString("X2");
            if (tid < 512)
            {
                tileTypeBox.SelectedIndex = (int)tempTiletype[tid];
            }

            if (e.Button == MouseButtons.Right)
            {
                highlightedTile8 = true;

                pictureboxTile16.Refresh();
            }

            pictureboxTile8.Refresh();
            fromForm = false;

            updateTiles();
        }

        private void pictureboxTile8_MouseUp(object sender, MouseEventArgs e)
        {
            fromForm = true;

            if (e.Button == MouseButtons.Right)
            {
                highlightedTile8 = false;

                pictureboxTile16.Refresh();
            }

            pictureboxTile8.Refresh();
            fromForm = false;

            updateTiles();
        }

        /// <summary>
        /// Called when the tile 16 window is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureboxTile16_MouseDown(object sender, MouseEventArgs e)
        {
            int offset = (e.X < 256) ? 0 : 1992;
            int yp = e.Y;

            int t16 = offset + (e.X / 32) + ((e.Y / 32) * 8);
            int t8x = (e.X / 16) & 0x01;
            int t8y = (e.Y / 16) & 0x01;
            int t8i = 0;

            scene.selectedTile = new ushort[1] { (ushort)t16 };

            tile16GroupBox.Text = "Selected tile 16: " + t16.ToString("X4");

            // When left clicked, draw the tile 8 selected in the corrisponding quadrant of the tile 16
            if (e.Button == MouseButtons.Left)
            {
                if (tiledrawsizeHexbox.HexValue == 1)
                {
                    TileInfo t = new TileInfo(tile8selected,
                        (byte)paletteUpDown.Value,
                        inFrontCheckbox.Checked,
                        mirrorXCheckbox.Checked,
                        mirrorYCheckbox.Checked);

                    if (t8x == 0 && t8y == 0)
                    {
                        allTiles[t16] = new Tile16(t, allTiles[t16].Tile1, allTiles[t16].Tile2, allTiles[t16].Tile3);
                    }
                    else if (t8x == 1 && t8y == 0)
                    {
                        allTiles[t16] = new Tile16(allTiles[t16].Tile0, t, allTiles[t16].Tile2, allTiles[t16].Tile3);
                    }
                    else if (t8x == 0 && t8y == 1)
                    {
                        allTiles[t16] = new Tile16(allTiles[t16].Tile0, allTiles[t16].Tile1, t, allTiles[t16].Tile3);
                    }
                    else if (t8x == 1 && t8y == 1)
                    {
                        allTiles[t16] = new Tile16(allTiles[t16].Tile0, allTiles[t16].Tile1, allTiles[t16].Tile2, t);
                    }

                    BuildTiles16Gfx();
                }
                else if (tiledrawsizeHexbox.HexValue == 2)
                {
                    TileInfo t = new TileInfo(tile8selected,
                    (byte)paletteUpDown.Value,
                    inFrontCheckbox.Checked,
                    mirrorXCheckbox.Checked,
                    mirrorYCheckbox.Checked);

                    TileInfo t2 = new TileInfo((ushort)(tile8selected + 1),
                    (byte)paletteUpDown.Value,
                    inFrontCheckbox.Checked,
                    mirrorXCheckbox.Checked,
                    mirrorYCheckbox.Checked);

                    TileInfo t3 = new TileInfo((ushort)(tile8selected + 16),
                    (byte)paletteUpDown.Value,
                    inFrontCheckbox.Checked,
                    mirrorXCheckbox.Checked,
                    mirrorYCheckbox.Checked);

                    TileInfo t4 = new TileInfo((ushort)(tile8selected + 17),
                    (byte)paletteUpDown.Value,
                    inFrontCheckbox.Checked,
                    mirrorXCheckbox.Checked,
                    mirrorYCheckbox.Checked);

                    allTiles[t16] = new Tile16(t, t2, t3, t4);

                    if (mirrorXCheckbox.Checked) // invert tiles
                    {
                        allTiles[t16] = new Tile16(t2, t, t4, t3);
                    }

                    if (mirrorYCheckbox.Checked) // invert tiles
                    {
                        allTiles[t16] = new Tile16(t3, t4, t, t2);
                    }

                    if (mirrorXCheckbox.Checked && mirrorYCheckbox.Checked)
                    {
                        allTiles[t16] = new Tile16(t4, t3, t2, t);
                    }

                    BuildTiles16Gfx();
                }
                else if (tiledrawsizeHexbox.HexValue == 4)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            TileInfo t = new TileInfo((ushort)(tile8selected + (i * 2) + (j * 32)),
                            (byte)paletteUpDown.Value,
                            inFrontCheckbox.Checked,
                            mirrorXCheckbox.Checked,
                            mirrorYCheckbox.Checked);

                            TileInfo t2 = new TileInfo((ushort)(tile8selected + 1 + (i *2) + (j * 32)),
                            (byte)paletteUpDown.Value,
                            inFrontCheckbox.Checked,
                            mirrorXCheckbox.Checked,
                            mirrorYCheckbox.Checked);

                            TileInfo t3 = new TileInfo((ushort)(tile8selected + 16 + (i * 2) + (j * 32)),
                            (byte)paletteUpDown.Value,
                            inFrontCheckbox.Checked,
                            mirrorXCheckbox.Checked,
                            mirrorYCheckbox.Checked);

                            TileInfo t4 = new TileInfo((ushort)(tile8selected + 17 + (i * 2) + (j * 32)),
                            (byte)paletteUpDown.Value,
                            inFrontCheckbox.Checked,
                            mirrorXCheckbox.Checked,
                            mirrorYCheckbox.Checked);

                            allTiles[t16 + i + (j*8)] = new Tile16(t, t2, t3, t4);
                        }
                    }

                    BuildTiles16Gfx();
                }
            }

            // When right clicked, get the select the tile 8 from the corrisponding quadrant of the tile 16
            else if (e.Button == MouseButtons.Right)
            {
                if (t8x == 0 && t8y == 0)
                {
                    updateTileInfoFrom16(allTiles[t16].Tile0);
                }
                else if (t8x == 1 && t8y == 0)
                {
                    updateTileInfoFrom16(allTiles[t16].Tile1);
                }
                else if (t8x == 0 && t8y == 1)
                {
                    updateTileInfoFrom16(allTiles[t16].Tile2);
                }
                else if (t8x == 1 && t8y == 1)
                {
                    updateTileInfoFrom16(allTiles[t16].Tile3);
                }
            }

            this.MadeChange = true;

            pictureboxTile16.Refresh();
        }

        private void updateTileInfoFrom16(TileInfo t)
        {
            fromForm = true;
            tileUpDown.Text = t.id.ToString("X2");
            paletteUpDown.Value = t.palette;
            mirrorXCheckbox.Checked = t.H;
            mirrorYCheckbox.Checked = t.V;
            inFrontCheckbox.Checked = t.O;
            
            tileTypeBox.SelectedIndex = (int)tempTiletype[t.id%512];
            fromForm = false;

            updateTiles();
        }

        private unsafe void BuildTiles16Gfx()
        {
            var gfx16Data = (byte*)GFX.mapblockset16.ToPointer(); //(byte*)allgfx8Ptr.ToPointer();
            var gfx8Data = (byte*)GFX.currentOWgfx16Ptr.ToPointer(); //(byte*)allgfx16Ptr.ToPointer();
            int[] offsets = { 0, 8, 1024, 1032 };
            var yy = 0;
            var xx = 0;

            for (var i = 0; i < Constants.NumberOfMap16Ex; i++) // Number of tiles16 3748? // its 3752
            {
                // 8x8 tile draw
                // gfx8 = 4bpp so everyting is /2
                var tiles = allTiles[i];

                for (var tile = 0; tile < 4; tile++)
                {
                    TileInfo info = tiles.TileInfoArray[tile];
                    int offset = offsets[tile];

                    for (var y = 0; y < 8; y++)
                    {
                        for (var x = 0; x < 4; x++)
                        {
                            CopyTile16(x, y, xx, yy, offset, info, gfx16Data, gfx8Data);
                        }
                    }
                }

                xx += 16;
                if (xx >= 128)
                {
                    yy += 2048;
                    xx = 0;
                }
            }
        }

        private unsafe void CopyTile16(int x, int y, int xx, int yy, int offset, TileInfo tile, byte* gfx16Pointer, byte* gfx8Pointer) // map,current
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
            var index = xx + yy + offset + (mx * 2) + (my * 128);
            var pixel = gfx8Pointer[tx + (y * 64) + x];

            gfx16Pointer[index + r ^ 1] = (byte)((pixel & 0x0F) + tile.palette * 16);
            gfx16Pointer[index + r] = (byte)(((pixel >> 4) & 0x0F) + tile.palette * 16);
        }

        private void Tile16Editor_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 0xFF; i++)
            {
                tilesTypesNames[i] = i.ToString("X2") + " - ????";
            }

            loadTilesNames();

            for (int i = 0; i < 0x200; i++)
            {
                tempTiletype[i] = scene.ow.AllTileTypes[i];
            }

            tiletypesheetCombobox.SelectedIndex = 0;
            scene.ow.Tile16List.CopyTo(allTiles);

            unsafe
            {
                // Update gfx to be on selected map
                byte* currentmapgfx8Data = (byte*)GFX.currentOWgfx16Ptr.ToPointer(); // Loaded gfx for the current map (empty at this point)
                byte* allgfxData = (byte*)GFX.allgfx16Ptr.ToPointer(); // All gfx of the game pack of 2048 bytes (4bpp)
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 2048; j++)
                    {
                        byte mapByte = allgfxData[j + (scene.ow.AllMaps[scene.selectedMap].StaticGFX[i] * 2048)];

                        // 4bpp check
                        if (GFX.sheets4bpp[scene.ow.AllMaps[scene.selectedMap].StaticGFX[i]] == 0)
                        {
                            switch (i)
                            {
                                case 0:
                                case 3:
                                case 4:
                                case 5:
                                    mapByte += 0x88;
                                    break;

                                // The first half of sheet 7 needs to load from the animated sheet.
                                case 7:
                                    if (j < 1024)
                                    {
                                        mapByte = allgfxData[j + (scene.ow.AllMaps[scene.selectedMap].StaticGFX[16] * 2048)];
                                    }

                                    break;
                            }
                        }

                        currentmapgfx8Data[(i * 2048) + j] = mapByte; // Upload used gfx data
                    }
                }
            }


            for (int i = 0; i < 0x2000; i++)
            {
                IndividualSheetsCollisionsData[i] = ROM.DATA[Constants.IndividualSheetsCollisions+i];
            }

            bool unused = true;
            for (int i = 0; i < 32; i++)
            {
                if (IndividualSheetsCollisionsData[0x3A * 0x40 + i] != 0)
                {
                    unused = false;
                }
            }

            if (unused)
            {
                if (MessageBox.Show("Your rom seems to be using old collisions do you want to convert them to newer collision?", "Converting", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int j = 0; j < 0x80; j++)
                    {
                        for (int i = 0; i < 0x40; i++)
                        {
                            if ((gfxslotcollision[j] != 0xFF))
                            {
                                IndividualSheetsCollisionsData[(j * 0x40) + i] = ROM.DATA[Constants.overworldTilesType + (gfxslotcollision[j] * 0x40) + i];
                            }
                        }
                    }
                }
            }
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            this.SaveChanges();
        }

        private void SaveChanges()
        {
            List<ushort> zsnetTiles16ID = new List<ushort>();
            List<Tile16> zsnetTiles16 = new List<Tile16>();
            for (int i = 0; i < Constants.NumberOfMap16Ex; i++)
            {
                if (NetZS.connected)
                {
                    if (scene.ow.Tile16List[i].GetLongData() != allTiles[i].GetLongData())
                    {
                        zsnetTiles16.Add(allTiles[i]);
                        zsnetTiles16ID.Add((ushort)i);
                    }
                }

                // Check all tiles that changed.
                scene.ow.Tile16List[i] = allTiles[i];
            }

            for(int i = 0; i< 0x2000;i++)
            {
                ROM.DATA[Constants.IndividualSheetsCollisions + i] = IndividualSheetsCollisionsData[i]; 
            }

            if (NetZS.connected)
            {
                NetZSBuffer buffer = new NetZSBuffer((short)((zsnetTiles16ID.Count * 10) + 8));
                buffer.Write((byte)18); // tile data cmd
                buffer.Write(NetZS.userID); // user id
                buffer.Write((short)zsnetTiles16ID.Count);  // numbers of tiles changed
                for (int i = 0; i < zsnetTiles16ID.Count; i++)
                {
                    buffer.Write(zsnetTiles16ID[i]);
                    buffer.Write(zsnetTiles16[i].Tile0.toShort());
                    buffer.Write(zsnetTiles16[i].Tile1.toShort());
                    buffer.Write(zsnetTiles16[i].Tile2.toShort());
                    buffer.Write(zsnetTiles16[i].Tile3.toShort());
                }

                NetOutgoingMessage msg = NetZS.client.CreateMessage();
                msg.Write(buffer.buffer);
                NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
                NetZS.client.FlushSendQueue();
            }

            for (int i = 0; i < 0x200; i++)
            {
                scene.ow.AllTileTypes[i] = tempTiletype[i];
            }

            for (int i = 0; i < 159; i++)
            {
                scene.ow.AllMaps[i].NeedRefresh = true;
            }

            scene.ow.AllMaps[scene.selectedMap].BuildMap();
            scene.ow.AllMaps[scene.selectedMap].NeedRefresh = false;

            scene.owForm.tilePictureBox.Refresh();
            scene.owForm.splitContainer1.Panel2.Refresh();

            this.MadeChange = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tileTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!fromForm)
            {
                tempTiletype[tile8selected] = (byte)tileTypeBox.SelectedIndex;
            }
        }

        public void loadTilesNames()
        {
            tilesTypesNames = Constants.TileTypes;
           
            tileTypeBox.Items.Clear();
            tileTypeBox.Items.AddRange(tilesTypesNames);
            tiletypesheetCombobox.Items.Clear();
            tiletypesheetCombobox.Items.AddRange(tilesTypesNames);
        }

        private void gridcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            pictureboxTile16.Refresh();
            pictureboxTile8.Refresh();
        }

        private void pictureboxTile8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            this.Close();

            if (this.cancelClosing)
            {
                this.cancelClosing = false;

                return;
            }

            this.scene.mainForm.editorsTabControl.SelectedIndex = 2;
            this.scene.mainForm.gfxEditor.selectedSheet = this.scene.ow.AllMaps[this.scene.selectedMap].StaticGFX[(e.Y / 64)];
            this.scene.mainForm.gfxEditor.allgfxPicturebox.Refresh();

            this.scene.mainForm.gfxEditor.panel1.AutoScrollPosition = new Point(0, this.scene.mainForm.gfxEditor.selectedSheet * 64);
            this.scene.mainForm.gfxEditor.panel1.Refresh();
        }

        private void Tile16Editor_Shown(object sender, EventArgs e)
        {
            panel1.VerticalScroll.Value = ((scene.selectedTile[0] / 8) * 32);
            panel1.PerformLayout();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ushort tsearch;
            ushort.TryParse(tile16searchTextbox.Text, System.Globalization.NumberStyles.HexNumber, null, out tsearch);
            searchedTile = tsearch;
            panel1.VerticalScroll.Value = ((searchedTile / 8) * 32);
            panel1.PerformLayout();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            if (openFileDialog.ShowDialog() != DialogResult.OK) 
            {
                return;
            }

            BinaryReader binaryReader = new BinaryReader(new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read));
            //br.ReadUInt16();
            //allTiles[scene.selectedTile[0]].Tile0
            int tstart = scene.selectedTile[0];
            ushort[] tilemapdata = new ushort[(binaryReader.BaseStream.Length / 2)];
            int tilemapHeight = tilemapdata.Length / tilewidthimportHexbox.HexValue;
            int tilemapWidth = tilewidthimportHexbox.HexValue;
            for (int i = 0; i < tilemapdata.Length; i++)
            {
                tilemapdata[i] = binaryReader.ReadUInt16();
            }

            binaryReader.Close();

            for (int height = 0; height < tilemapHeight / 2; height++)
            {
                for (int width = 0; width < tilemapWidth; width++)
                {
                    if (width % 2 == 0)
                    {
                        allTiles[tstart + (width / 2) + (height * (tilemapWidth / 2))].Tile0 = new TileInfo(tilemapdata[width + (height * (tilemapWidth * 2))]);
                    }
                    else
                    {
                        allTiles[tstart + (width / 2) + (height * (tilemapWidth / 2))].Tile1 = new TileInfo(tilemapdata[width + (height * (tilemapWidth * 2))]);
                    }

                    if (width % 2 == 0)
                    {
                        allTiles[tstart + (width / 2) + (height * (tilemapWidth / 2))].Tile2 = new TileInfo(tilemapdata[width + (height * (tilemapWidth * 2)) + tilemapWidth]);
                    }
                    else
                    {
                        allTiles[tstart + (width / 2) + (height * (tilemapWidth / 2))].Tile3 = new TileInfo(tilemapdata[width + (height * (tilemapWidth * 2)) + tilemapWidth]);
                    }
                }
            }

            for (int height = 0; height < tilemapHeight / 2; height++)
            {
                for (int width = 0; width < tilemapWidth / 2; width++)
                {
                    scene.owForm.scratchPadTiles[width, height] = (ushort)(width + (height * 8));
                }
            }
        }

        private void tiledrawsizeHexbox_TextChanged(object sender, EventArgs e)
        {
            pictureboxTile8.Refresh();
        }

        private void Tile16Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.MadeChange)
            {
                return;
            }

            switch (UIText.WarnTile16EditorToGFXEditorSwitch())
            {
                case DialogResult.Yes:
                    this.SaveChanges();
                    break;

                case DialogResult.No:
                    break;

                case DialogResult.Cancel:
                default:
                    e.Cancel = true;
                    this.cancelClosing = true;
                    break;
            }
        }

        private void copyRangeButton_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("ZST16");
            int startTileID = scene.selectedTile[0];
            for (int i = 0; i < copyrangeUpdown.Value; i++)
            {
                stringBuilder.Append(allTiles[startTileID + i].Tile0.toShort().ToString("X4"));
                stringBuilder.Append(allTiles[startTileID + i].Tile1.toShort().ToString("X4"));
                stringBuilder.Append(allTiles[startTileID + i].Tile2.toShort().ToString("X4"));
                stringBuilder.Append(allTiles[startTileID + i].Tile3.toShort().ToString("X4"));
            }

            Clipboard.SetText(stringBuilder.ToString());
        }

        private void pasteRangeButton_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string data = Clipboard.GetText();
                int startTileID = scene.selectedTile[0];
                if (data.StartsWith("ZST16"))
                {
                    data = data.Substring(5);
                    for (int i = 0; i < data.Length / 16; i++)
                    {
                        allTiles[startTileID + i].Tile0 = GFX.gettilesinfo(ushort.Parse(data.Substring((i * 16), 4), System.Globalization.NumberStyles.HexNumber));
                        allTiles[startTileID + i].Tile1 = GFX.gettilesinfo(ushort.Parse(data.Substring((i * 16) + 4, 4), System.Globalization.NumberStyles.HexNumber));
                        allTiles[startTileID + i].Tile2 = GFX.gettilesinfo(ushort.Parse(data.Substring((i * 16) + 8, 4), System.Globalization.NumberStyles.HexNumber));
                        allTiles[startTileID + i].Tile3 = GFX.gettilesinfo(ushort.Parse(data.Substring((i * 16) + 12, 4), System.Globalization.NumberStyles.HexNumber));
                    }
                }
            }

            BuildTiles16Gfx();
            pictureboxTile16.Refresh();
        }

        private void collisionsheetPicturebox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            ColorPalette colorPalette = GFX.allgfxBitmap.Palette;
            Color[] oldColors = new Color[8];
            for(int i = 0; i< 8;i++)
            {
                oldColors[i] = colorPalette.Entries[i];
                colorPalette.Entries[i] = Color.FromArgb(i * 32, i * 32, i * 32);
            }

            GFX.allgfxBitmap.Palette = colorPalette;
            e.Graphics.DrawImage(GFX.allgfxBitmap, new Rectangle(0, 0, 512, 128), new Rectangle(0,(int)(selectedsheetUpDown.Value*32),128,32), GraphicsUnit.Pixel);
            for (int i = 0; i < 8; i++)
            {
                colorPalette.Entries[i] = oldColors[i];
            }

            GFX.allgfxBitmap.Palette = colorPalette;
            for(int i = 0; i< 4;i++)
            {
                e.Graphics.DrawLine(new Pen(new SolidBrush(fColor), 1),new Point(0,i*32), new Point(512,i*32));
            }

            for (int i = 0; i < 16; i++)
            {
                e.Graphics.DrawLine(new Pen(new SolidBrush(fColor), 1), new Point(i * 32,0), new Point(i * 32, 128));
            }

            for (int i = 0; i < 0x40;i++)
            {
                e.Graphics.DrawString(IndividualSheetsCollisionsData[(int)(selectedsheetUpDown.Value*0x40)+i].ToString("X2") , f, new SolidBrush(fColor), 4+ ((i % 16)*32),4+ ((i / 16) * 32));
            }
        }

        private void selectedsheetUpDown_ValueChanged(object sender, EventArgs e)
        {
            collisionsheetPicturebox.Invalidate();
        }

        byte[] gfxslotcollision = new byte[0x80]
        {
            0xFF, // 0X00
            0xFF, // 0X01
            0xFF, // 0X02
            0xFF, // 0X03
            0xFF, // 0X04
            0xFF, // 0X05
            0xFF, // 0X06
            0xFF, // 0X07
            0xFF, // 0X08
            0xFF, // 0X09
            0xFF, // 0X0A
            0xFF, // 0X0B
            0xFF, // 0X0C
            0xFF, // 0X0D
            0xFF, // 0X0E
            0xFF, // 0X0F
            0xFF, // 0X10
            0xFF, // 0X11
            0xFF, // 0X12
            0xFF, // 0X13
            0xFF, // 0X14
            0xFF, // 0X15
            0xFF, // 0X16
            0xFF, // 0X17
            0xFF, // 0X18
            0xFF, // 0X19
            0xFF, // 0X1A
            0xFF, // 0X1B
            0xFF, // 0X1C
            0xFF, // 0X1D
            0xFF, // 0X1E
            0xFF, // 0X1F
            0xFF, // 0X20
            0xFF, // 0X21
            0xFF, // 0X22
            0xFF, // 0X23
            0xFF, // 0X24
            0xFF, // 0X25
            0xFF, // 0X26
            0xFF, // 0X27
            0xFF, // 0X28
            0xFF, // 0X29
            0xFF, // 0X2A
            0x04, // 0x2B
            0x05, // 0x2C
            0x04, // 0x2D
            0x05, // 0x2E
            0x04, // 0x2F

            0x05, // 0x30
            0x04, // 0x31
            0x05, // 0x32
            0x04, // 0x33
            0x05, // 0x34
            0x04, // 0x35
            0x05, // 0x36
            0x04, // 0x37
            0x05, // 0x38
            0x00, // 0x39 ; MENU
            0x00, // 0x3A
            0x01, // 0x3B
            0x02, // 0x3C
            0x03, // 0x3D
            0x06, // 0x3E
            0x06, // 0x3F

            0x00, // 0x40 ; LOGO
            0x00, // 0x41 ; LOGO
            0x00, // 0x42
            0x01, // 0x43
            0x02, // 0x44
            0x03, // 0x45
            0x00, // 0x46 ; TRIFORCE ROOM
            0x04, // 0x47
            0x05, // 0x48
            0x05, // 0x49
            0x05, // 0x4A
            0x05, // 0x4B
            0x05, // 0x4C
            0x05, // 0x4D
            0x05, // 0x4E
            0x05, // 0x4F

            0x04, // 0x50
            0x04, // 0x51
            0x04, // 0x52
            0x04, // 0x53
            0x05, // 0x54
            0x04, // 0x55
            0x04, // 0x56
            0x04, // 0x57
            0x07, // 0x58 ; ANIMATED
            0x07, // 0x59 ; ANIMATED
            0x07, // 0x5A ; ANIMATED
            0x07, // 0x5B ; ANIMATED
            0x07, // 0x5C ; ANIMATED
            0x07, // 0x5D ; ANIMATED
            0x07, // 0x5E ; ANIMATED
            0x07, // 0x5F ; ANIMATED

            0x04, // 0x60
            0xFF, // 0x61
            0xFF, // 0x62
            0xFF, // 0x63
            0xFF, // 0x64
            0xFF, // 0x65
            0xFF, // 0x66
            0xFF, // 0x67
            0xFF, // 0x68
            0xFF, // 0x69
            0xFF, // 0x6A
            0xFF, // 0x6B
            0xFF, // 0x6C
            0xFF, // 0x6D
            0xFF, // 0x6E
            0xFF, // 0x6F

            0xFF, // 0x70
            0xFF, // 0x71
            0xFF, // 0x72
            0xFF, // 0x73
            0xFF, // 0x74
            0xFF, // 0x75
            0xFF, // 0x76
            0xFF, // 0x77
            0xFF, // 0x78
            0xFF, // 0x79
            0xFF, // 0x7A
            0xFF, // 0x7B
            0xFF, // 0x7C
            0xFF, // 0x7D
            0xFF, // 0x7E
            0xFF, // 0x7F
        };

        private void vanillacopycolButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wanna use old collision it'll overwrite actual newer collisions", "Converting", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            for (int j = 0; j < 0x80; j++)
            {
                for (int i = 0; i < 0x40; i++)
                {
                    if ((gfxslotcollision[j] != 0xFF))
                    {
                        IndividualSheetsCollisionsData[(j * 0x40) + i] = ROM.DATA[Constants.overworldTilesType + (gfxslotcollision[j] * 0x40) + i];
                    }
                }
            }
        }

        private void collisionsheetPicturebox_MouseDown(object sender, MouseEventArgs e)
        {
            int index = (e.X/32) + ((e.Y/32) * 16);
            lastIndex = index;

            IndividualSheetsCollisionsData[(int)(selectedsheetUpDown.Value * 0x40) + index] = (byte)tiletypesheetCombobox.SelectedIndex;
            mouseDown = true;
            collisionsheetPicturebox.Invalidate();
        }

        private void collisionsheetPicturebox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int index = (e.X / 32) + ((e.Y / 32) * 16);
                if (index != lastIndex)
                {
                    IndividualSheetsCollisionsData[(int)(selectedsheetUpDown.Value * 0x40) + index] = (byte)tiletypesheetCombobox.SelectedIndex;
                    collisionsheetPicturebox.Invalidate();
                }

                lastIndex = index;
            }
        }

        private void collisionsheetPicturebox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
