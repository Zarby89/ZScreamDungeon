using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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
        string[] tilesTypesNames = new string[]
            {
                "00 - Nothing",
                "01 - Collision",
                "02 - Collision (short)",
                "03 - Collision",
                "04 - Collision (short ledge)",
                "05 - Nothing",
                "06 - Nothing",
                "07 - Nothing",
                "08 - Deep water",
                "09 - Shallow water",
                "0A - Short water ladder",
                "0B - Collision / Deep water",
                "0C - Overlay mask",
                "0D - Spike floor",
                "0E - GT ice",
                "0F - Ice palace ice",
                "10 - Slope ◤",
                "11 - Slope ◥",
                "12 - Slope ◣",
                "13 - Slope ◢",
                "14 - Nothing",
                "15 - Nothing",
                "16 - Nothing",
                "17 - Nothing",
                "18 - Slope ◤",
                "19 - Slope ◥",
                "1A - Slope ◣",
                "1B - Slope ◢",
                "1C - Layer 2 overlay",
                "1D - North single-layer auto stairs",
                "1E - North layer-swap auto stairs",
                "1F - North layer-swap auto stairs",
                "20 - Pit",
                "21 - Nothing",
                "22 - Manual stairs",
                "23 - Pot switch",
                "24 - Pressure switch",
                "25 - Nothing",
                "26 - Collision near stairs",
                "27 - General hookable object",
                "28 - North ledge",
                "29 - South ledge",
                "2A - East ledge",
                "2B - West ledge",
                "2C - ◤ ledge",
                "2D - ◣ ledge",
                "2E - ◥ ledge",
                "2F - ◢ ledge",
                "30 - Straight inter-room stairs south/up 0",
                "31 - Straight inter-room stairs south/up 1",
                "32 - Straight inter-room stairs south/up 2",
                "33 - Straight inter-room stairs south/up 3",
                "34 - Straight inter-room stairs north/down 0",
                "35 - Straight inter-room stairs north/down 1",
                "36 - Straight inter-room stairs north/down 2",
                "37 - Straight inter-room stairs north/down 3",
                "38 - Straight inter-room stairs north/down edge",
                "39 - Straight inter-room stairs south/up edge",
                "3A - Star tile (inactive on load)",
                "3B - Star tile (active on load)",
                "3C - Nothing",
                "3D - South single-layer auto stairs",
                "3E - South layer-swap auto stairs",
                "3F - South layer-swap auto stairs",
                "40 - Thick grass",
                "41 - Nothing",
                "42 - Gravestone / Tower of Hera ledge shadows",
                "43 - Skull Woods entrance / Hera columns",
                "44 - Spike",
                "45 - Nothing",
                "46 - Desert Tablet",
                "47 - Nothing",
                "48 - Diggable ground",
                "49 - Nothing",
                "4A - Diggable ground",
                "4B - Warp tile",
                "4C - Nothing / Square corner",
                "4D - Nothing / Square corner",
                "4E - Square corner",
                "4F - Square corner",
                "50 - Green bush",
                "51 - Dark bush",
                "52 - Gray rock",
                "53 - Black rock",
                "54 - Readable",
                "55 - Big gray rock",
                "56 - Big black rock",
                "57 - Bonk rocks",
                "58 - Chest 0",
                "59 - Chest 1",
                "5A - Chest 2",
                "5B - Chest 3",
                "5C - Chest 4",
                "5D - Chest 5",
                "5E - Spiral stairs",
                "5F - Spiral stairs",
                "60 - Rupee tile",
                "61 - Nothing",
                "62 - Bombable floor",
                "63 - Minigame chest",
                "64 - Nothing",
                "65 - Nothing",
                "66 - Crystal peg down",
                "67 - Crystal peg up",
                "68 - Upwards conveyor",
                "69 - Downwards conveyor",
                "6A - Leftwards conveyor",
                "6B - Rightwards conveyor",
                "6C - North vines",
                "6D - South vines",
                "6E - West vines",
                "6F - East vines",
                "70 - Manipulable 0",
                "71 - Manipulable 1",
                "72 - Manipulable 2",
                "73 - Manipulable 3",
                "74 - Manipulable 4",
                "75 - Manipulable 5",
                "76 - Manipulable 6",
                "77 - Manipulable 7",
                "78 - Manipulable 8",
                "79 - Manipulable 9",
                "7A - Manipulable A",
                "7B - Manipulable B",
                "7C - Manipulable C",
                "7D - Manipulable D",
                "7E - Manipulable E",
                "7F - Manipulable F",
                "80 - North/South door",
                "81 - East/West door",
                "82 - North/South shutter door",
                "83 - East/West shutter door",
                "84 - North/South layer 2 door",
                "85 - East/West layer 2 door",
                "86 - North/South layer 2 shutter door",
                "87 - East/West layer 2 shutter door",
                "88 - Some type of door",
                "89 - East/West transport door",
                "8A - Some type of door",
                "8B - Some type of door",
                "8C - Some type of door",
                "8D - Some type of door",
                "8E - Entrance door",
                "8F - Entrance door",
                "90 - Layer toggle shutter door",
                "91 - Layer toggle shutter door",
                "92 - Layer toggle shutter door",
                "93 - Layer toggle shutter door",
                "94 - Layer toggle shutter door",
                "95 - Layer toggle shutter door",
                "96 - Layer toggle shutter door",
                "97 - Layer toggle shutter door",
                "98 - Layer+Dungeon toggle shutter door",
                "99 - Layer+Dungeon toggle shutter door",
                "9A - Layer+Dungeon toggle shutter door",
                "9B - Layer+Dungeon toggle shutter door",
                "9C - Layer+Dungeon toggle shutter door",
                "9D - Layer+Dungeon toggle shutter door",
                "9E - Layer+Dungeon toggle shutter door",
                "9F - Layer+Dungeon toggle shutter door",
                "A0 - North/South Dungeon swap door",
                "A1 - Dungeon toggle door",
                "A2 - Dungeon toggle door",
                "A3 - Dungeon toggle door",
                "A4 - Dungeon toggle door",
                "A5 - Dungeon toggle door",
                "A6 - Nothing",
                "A7 - Nothing",
                "A8 - Layer+Dungeon toggle shutter door",
                "A9 - Layer+Dungeon toggle shutter door",
                "AA - Layer+Dungeon toggle shutter door",
                "AB - Layer+Dungeon toggle shutter door",
                "AC - Layer+Dungeon toggle shutter door",
                "AD - Layer+Dungeon toggle shutter door",
                "AE - Layer+Dungeon toggle shutter door",
                "AF - Layer+Dungeon toggle shutter door",
                "B0 - Somaria ─",
                "B1 - Somaria │",
                "B2 - Somaria ┌",
                "B3 - Somaria └",
                "B4 - Somaria ┐",
                "B5 - Somaria ┘",
                "B6 - Somaria ⍰ 1 way",
                "B7 - Somaria ┬",
                "B8 - Somaria ┴",
                "B9 - Somaria ├",
                "BA - Somaria ┤",
                "BB - Somaria ┼",
                "BC - Somaria ⍰ 2 way",
                "BD - Somaria ┼ crossover",
                "BE - Pipe entrance",
                "BF - Nothing",
                "C0 - Torch 0",
                "C1 - Torch 1",
                "C2 - Torch 2",
                "C3 - Torch 3",
                "C4 - Torch 4",
                "C5 - Torch 5",
                "C6 - Torch 6",
                "C7 - Torch 7",
                "C8 - Torch 8",
                "C9 - Torch 9",
                "CA - Torch A",
                "CB - Torch B",
                "CC - Torch C",
                "CD - Torch D",
                "CE - Torch E",
                "CF - Torch F",
                "D0 - Nothing",
                "D1 - Nothing",
                "D2 - Nothing",
                "D3 - Nothing",
                "D4 - Nothing",
                "D5 - Nothing",
                "D6 - Nothing",
                "D7 - Nothing",
                "D8 - Nothing",
                "D9 - Nothing",
                "DA - Nothing",
                "DB - Nothing",
                "DC - Nothing",
                "DD - Nothing",
                "DE - Nothing",
                "DF - Nothing",
                "E0 - Nothing",
                "E1 - Nothing",
                "E2 - Nothing",
                "E3 - Nothing",
                "E4 - Nothing",
                "E5 - Nothing",
                "E6 - Nothing",
                "E7 - Nothing",
                "E8 - Nothing",
                "E9 - Nothing",
                "EA - Nothing",
                "EB - Nothing",
                "EC - Nothing",
                "ED - Nothing",
                "EE - Nothing",
                "EF - Nothing",
                "F0 - Door 0 bottom",
                "F1 - Door 1 bottom",
                "F2 - Door 2 bottom",
                "F3 - Door 3 bottom",
                "F4 - Door X bottom",
                "F5 - Door X bottom",
                "F6 - Door X bottom",
                "F7 - Door X bottom",
                "F8 - Door 0 top",
                "F9 - Door 1 top",
                "FA - Door 2 top",
                "FB - Door 3 top",
                "FC - Door X top",
                "FD - Door X top",
                "FE - Door X top",
                "FF - Door X top",
            };

        private bool MadeChange = false;
        private bool cancelClosing = false;

        public Tile16Editor(SceneOW scene)
        {
            this.scene = scene;
            InitializeComponent();

            panel1.VerticalScroll.SmallChange = 32;
            panel1.VerticalScroll.LargeChange = 32;
        }

        /// <summary>
        /// Called every frame? updates the appearance of the tile 8 window
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
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
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
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
            e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
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

                        currentmapgfx8Data[(i * 2048) + j] = mapByte; // Upload used gfx data
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

            if (NetZS.connected)
            {
                NetZSBuffer buffer = new NetZSBuffer((short)((zsnetTiles16ID.Count * 10) + 8));
                buffer.Write((byte)18); // tile data cmd
                buffer.Write(NetZS.userID); // user id
                buffer.Write((short)zsnetTiles16ID.Count);  // numbers of tiles changed
                for (int i = 0; i < zsnetTiles16ID.Count; i++)
                {
                    buffer.Write(zsnetTiles16ID[i]);
                    buffer.Write((ushort)zsnetTiles16[i].Tile0.toShort());
                    buffer.Write((ushort)zsnetTiles16[i].Tile1.toShort());
                    buffer.Write((ushort)zsnetTiles16[i].Tile2.toShort());
                    buffer.Write((ushort)zsnetTiles16[i].Tile3.toShort());
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
            tileTypeBox.Items.Clear();
            tileTypeBox.Items.AddRange(tilesTypesNames);
        }

        private void gridcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            pictureboxTile16.Refresh();
            pictureboxTile8.Refresh();
        }

        private void pictureboxTile8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
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

        private void Tile16CopyBtn_Click(object sender, EventArgs e)
        {
            copiedTileLabel.Text = "Copied Tile: " + scene.selectedTile[0].ToString("X4");
            copiedTile = allTiles[scene.selectedTile[0]];
        }

        private void Tile16PasteBtn_Click(object sender, EventArgs e)
        {
            allTiles[scene.selectedTile[0]] = copiedTile;

            BuildTiles16Gfx();
            pictureboxTile16.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            if (openFileDialog.ShowDialog() == DialogResult.OK) 
            { 
                BinaryReader br = new BinaryReader(new FileStream(openFileDialog.FileName,FileMode.Open,FileAccess.Read));
                //br.ReadUInt16();
                //allTiles[scene.selectedTile[0]].Tile0
                int tstart = scene.selectedTile[0];
                ushort[] tilemapdata = new ushort[(br.BaseStream.Length/2)];
                int tilemapHeight = tilemapdata.Length / tilewidthimportHexbox.HexValue;
                int tilemapWidth = tilewidthimportHexbox.HexValue;
                for (int i = 0; i < tilemapdata.Length; i++)
                { 
                    tilemapdata[i] = br.ReadUInt16();
                }

                br.Close();

                for (int h = 0; h < tilemapHeight/2; h++)
                {

                    for (int i = 0; i < tilemapWidth; i++)
                    {
                        if (i % 2 == 0)
                        {
                            allTiles[tstart + (i / 2) + ((h) * (tilemapWidth/2))].Tile0 = new TileInfo(tilemapdata[i + ((h) * (tilemapWidth * 2))]);
                        }
                        else
                        {
                            allTiles[tstart + (i / 2) + ((h) * (tilemapWidth/2))].Tile1 = new TileInfo(tilemapdata[i + ((h) * (tilemapWidth * 2))]);
                        }

                        if (i % 2 == 0)
                        {
                            allTiles[tstart + (i / 2) + ((h) * (tilemapWidth/2))].Tile2 = new TileInfo(tilemapdata[i + ((h) * (tilemapWidth * 2)) + tilemapWidth]);
                        }
                        else
                        {
                            allTiles[tstart + (i / 2) + ((h) * (tilemapWidth/2))].Tile3 = new TileInfo(tilemapdata[i + ((h) * (tilemapWidth * 2)) + tilemapWidth]);
                        }
                    }
                }
                for (int j = 0; j < tilemapHeight / 2; j++)
                {
                    for (int i = 0; i < tilemapWidth / 2; i++)
                    {
                        scene.owForm.scratchPadTiles[i,j] = (ushort)(i + (j * 8));
                    }
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
    }
}
