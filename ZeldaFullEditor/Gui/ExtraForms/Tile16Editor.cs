using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        Tile16[] allTiles = new Tile16[Constants.NumberOfMap16];

        ushort searchedTile = 0xFFFF;

        Tile16 copiedTile;

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

            e.Graphics.DrawRectangle(Pens.GreenYellow, new Rectangle(x * 16, y * 16, 16, 16));
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
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.AssumeLinear;
            //e.Graphics.DrawImage(GFX.editortileBitmap, new Rectangle(0, 0, 64, 64));
            e.Graphics.DrawImage(GFX.mapblockset16Bitmap, new RectangleF(0f, 0f, 256.5f, 16000f), new RectangleF(0, 0, 128, 8000), GraphicsUnit.Pixel);
            //e.Graphics.DrawImage(GFX.mapblockset16Bitmap, new RectangleF(256f, 0f, 256.5f, 8000f), new RectangleF(0, 4000, 128, 4000-192), GraphicsUnit.Pixel);

            if (gridcheckBox.Checked)
            {
                for (int x = 0; x < 16; x++)
                {
                    e.Graphics.DrawLine(Constants.White100Pen1, x * 32, 0, x * 32, 16000);

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
        }

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
            // When right clicked, get the select the tile 8 from the corrisponding quadrant of the tile 16
            else
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
            tileTypeBox.SelectedIndex = (int)tempTiletype[t.id];
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

            for (var i = 0; i < Constants.NumberOfMap16; i++) // Number of tiles16 3748? // its 3752
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

        private void button1_Click(object sender, EventArgs e)
        {
            List<ushort> zsnetTiles16ID = new List<ushort>();
            List<Tile16> zsnetTiles16 = new List<Tile16>();
            for (int i = 0; i < Constants.NumberOfMap16; i++)
            {
                if (NetZS.connected)
                {
                    if (scene.ow.Tile16List[i].GetLongData() != allTiles[i].GetLongData())
                    {
                        zsnetTiles16.Add(allTiles[i]);
                        zsnetTiles16ID.Add((ushort)i);
                    }
                }

                // check all tiles that changed
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

            this.Close();
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

        // TODO for kan ah fuck
        public void loadTilesNames()
        {
            tilesTypesNames[0x00] = "0x00 - Normal tile(no interaction)";
            tilesTypesNames[0x01] = "0x01 - Blocked";
            tilesTypesNames[0x02] = "0x02 - Blocked)";
            tilesTypesNames[0x03] = "0x03 - Blocked";
            tilesTypesNames[0x04] = "0x04 - Normal? Unknown";
            tilesTypesNames[0x05] = "0x05 - Normal tile(no interaction)";
            tilesTypesNames[0x06] = "0x06 - Normal tile(no interaction)";
            tilesTypesNames[0x07] = "0x07 - Normal tile(no interaction)";

            tilesTypesNames[0x08] = "0x08 - Deep Water";
            tilesTypesNames[0x09] = "0x09 - Shallow Water";

            tilesTypesNames[0x0C] = "0x0C - Moving Floor";
            tilesTypesNames[0x0D] = "0x0D - Sprite Floor";

            tilesTypesNames[0x1C] = "0x1C - Top of in room staircase";

            tilesTypesNames[0x20] = "0x20 - Hole Tile";
            tilesTypesNames[0x22] = "0x22 - Wooden steps(slow you down)";
            tilesTypesNames[0x27] = "0x27 - (empty chest and maybe others)";

            tilesTypesNames[0x28] = "0x28 - Ledge leading up";
            tilesTypesNames[0x29] = "0x29 - Ledge leading down";
            tilesTypesNames[0x2A] = "0x2A - Ledge leading left";
            tilesTypesNames[0x2B] = "0x2B - Ledge leading right";
            tilesTypesNames[0x2C] = "0x2C - Ledge leading up + left";
            tilesTypesNames[0x2D] = "0x2D - Ledge leading down + left";
            tilesTypesNames[0x2E] = "0x2E - Ledge leading up + right";
            tilesTypesNames[0x2F] = "0x2F - Ledge leading down + right";

            tilesTypesNames[0x40] = "0x40 - Grass Tile";
            tilesTypesNames[0x44] = "0x44 - Cactus Tile";
            tilesTypesNames[0x48] = "0x48 - aftermath tiles of picking things up?";
            tilesTypesNames[0x4A] = "0x4A - aftermath tiles of picking things up?";
            tilesTypesNames[0x4B] = "0x4B - Warp Tile";
            tilesTypesNames[0x4C] = "0x4C - Certain mountain tiles?";
            tilesTypesNames[0x4D] = "0x4D - Certain mountain tiles?";
            tilesTypesNames[0x4E] = "0x4E - Certain mountain tiles?";
            tilesTypesNames[0x4F] = "0x4F - Certain mountain tiles?";


            tilesTypesNames[0x50] = "0x50 - bush";
            tilesTypesNames[0x51] = "0x51 - off color bush";
            tilesTypesNames[0x52] = "0x52 - small light rock";
            tilesTypesNames[0x53] = "0x53 - small heavy rock";
            tilesTypesNames[0x54] = "0x54 - sign";
            tilesTypesNames[0x55] = "0x55 - large light rock";
            tilesTypesNames[0x56] = "0x56 - large heavy rock";

            tilesTypesNames[0x58] = "0x58 - Chest block";
            tilesTypesNames[0x59] = "0x59 - Chest block";
            tilesTypesNames[0x5A] = "0x5A - Chest block";
            tilesTypesNames[0x5B] = "0x5B - Chest block";
            tilesTypesNames[0x5C] = "0x5C - Chest block";
            tilesTypesNames[0x5D] = "0x5D - Chest block";

            tilesTypesNames[0x63] = "0x63 - Minigame chest tile";
            tilesTypesNames[0xB0] = "0xB0 - Hole Tile or Somaria?";

            tilesTypesNames[0xC0] = "0xC0 - Torch";
            tilesTypesNames[0xC1] = "0xC1 - Torch";
            tilesTypesNames[0xC2] = "0xC2 - Torch";
            tilesTypesNames[0xC3] = "0xC3 - Torch";
            tilesTypesNames[0xC4] = "0xC4 - Torch";
            tilesTypesNames[0xC5] = "0xC5 - Torch";
            tilesTypesNames[0xC6] = "0xC6 - Torch";
            tilesTypesNames[0xC7] = "0xC7 - Torch";
            tilesTypesNames[0xC8] = "0xC8 - Torch";
            tilesTypesNames[0xC9] = "0xC9 - Torch";
            tilesTypesNames[0xCA] = "0xCA - Torch";
            tilesTypesNames[0xCB] = "0xCB - Torch";
            tilesTypesNames[0xCC] = "0xCC - Torch";
            tilesTypesNames[0xCD] = "0xCD - Torch";
            tilesTypesNames[0xCE] = "0xCE - Torch";
            tilesTypesNames[0xCF] = "0xCF - Torch";

            tilesTypesNames[0xF0] = "0xF0 - Key door 1";
            tilesTypesNames[0xF1] = "0xF1 - Key door 2";

            tileTypeBox.Items.Clear();
            tileTypeBox.Items.AddRange(tilesTypesNames);
        }

        // TODO switch to entities.cs version, etc
        string[] tilesTypesNames = new string[0xFF];

        private void gridcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            pictureboxTile16.Refresh();
            pictureboxTile8.Refresh();
        }

        private void pictureboxTile8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            scene.mainForm.editorsTabControl.SelectedIndex = 2;
            scene.mainForm.gfxEditor.selectedSheet = scene.ow.AllMaps[scene.selectedMap].StaticGFX[(e.Y / 64)];
            scene.mainForm.gfxEditor.allgfxPicturebox.Refresh();
            this.Close();
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
    }
}
