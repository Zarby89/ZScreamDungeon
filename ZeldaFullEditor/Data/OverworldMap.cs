using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ZeldaFullEditor.Gui;

namespace ZeldaFullEditor
{
    /// <summary>
    ///     A data class containing the temporary overwold data that is shown in the overworld editor window.
    ///     This class should only be used to keep values in, not for loading anything !!
    /// </summary>
    public class OverworldMap
    {
        /// <summary>
        ///     Gets the index of the map.
        ///     00 is the lost woods
        /// </summary>
        public byte Index { get; internal set; } = 0;

        /// <summary>
        ///     Gets the area'a parent ID. The parent ID of small areas will be set to their Index.
        ///     The parent ID of large areas will be equal to the top left most area of the 4.
        /// </summary>
        public byte ParentID { get; internal set; } = 0;

        /// <summary>
        ///     Gets a value indicating whether the map is part of a large area.
        /// </summary>
        public bool LargeMap { get; internal set; } = false;

        /// <summary>
        ///     Gets a value indicating what corner of a large area this map is.
        ///     0 1
        ///     2 3
        /// </summary>
        public byte LargeIndex { get; internal set; } = 0;

        /// <summary>
        ///     Gets or sets the GFX index of the map.
        /// </summary>
        public byte GFX { get; set; } = 0;

        /// <summary>
        ///     Gets or sets the sprite GFX index of the map.
        /// </summary>
        public byte[] SpriteGFX { get; set; } = new byte[3];

        /// <summary>
        ///     Gets or sets the Aux palette of the map.
        /// </summary>
        public byte AuxPalette { get; set; } = 0;

        /// <summary>
        ///     Gets or sets the Main palette of the map.
        /// </summary>
        public byte MainPalette { get; set; } = 0;

        /// <summary>
        ///     Gets or sets the sprite palette of the map.
        ///     There is one palette for each game phase (rain, pre Agah, post Agah).
        /// </summary>
        public byte[] SpritePalette { get; set; } = new byte[3];

        /// <summary>
        ///     Gets or sets the subscreen overlay of the map.
        ///     This is things like the rain overlay, lost woods fog overly, death mountain sky background, and the pyramid background.
        /// </summary>
        public ushort SubscreenOverlay { get; set; } = 0;

        /// <summary>
        ///     Gets or sets the map music.
        /// </summary>
        public byte[] Music { get; set; } = new byte[4];

        /// <summary>
        ///     Gets a value indicating whether this is the first time the map has been loaded.
        /// </summary>
        public bool FirstLoad { get; internal set; } = false;

        /// <summary>
        ///     Gets or sets the message ID for the map.
        /// </summary>
        public short MessageID { get; set; } = 0;

        /// <summary>
        ///     Gets a value indicating whether the game will use a mosaic transition when transitioning into or out of area.
        /// </summary>
        public bool Mosaic { get; internal set; } = false;

        /// <summary>
        ///     Gets the GFX pointer for the map.
        ///     TODO: Verify what this actually does.
        ///     Needs to be removed.
        /// </summary>
        public IntPtr GFXPointer { get; internal set; } = Marshal.AllocHGlobal(512 * 512);

        /// <summary>
        ///     Gets the GFX bitmap for the map.
        ///     TODO: Verify what this actually does.
        ///     Needs to be removed.
        /// </summary>
        public Bitmap GFXBitmap { get; internal set; }

        /// <summary>
        ///     Gets the static GFX index.
        ///     Essentially the GFX groups loaded from different tables and used to load all the gfx for each area.
        /// </summary>
        public byte[] StaticGFX { get; internal set; } = new byte[16];

        /// <summary>
        ///     Gets or sets the Animated GFX used to replace StaticGFX[7] with custom area specific animated GFX.
        /// </summary>
        public byte AnimatedGFX { get; set; }

        /// <summary>
        ///     Gets the used tiles.
        ///     TODO: Verify what this is used for.
        /// </summary>
        public ushort[,] TilesUsed;

        /// <summary>
        ///     Gets or sets a value indicating whether this map needs to be built again.
        /// </summary>
        public bool NeedRefresh { get; set; } = false;

        private Overworld overworld;

        /// <summary>
        /// Initializes a new instance of the <see cref="OverworldMap"/> class.
        /// </summary>
        /// <param name="index"> The index (Area ID). </param>
        /// <param name="overworld"> The containing Overworld. </param>
        public OverworldMap(byte index, Overworld overworld)
        {
            this.Index = index;
            this.overworld = overworld;
            this.ParentID = index;
            this.LargeIndex = 0;
            this.GFXBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, this.GFXPointer);

            this.MessageID = (short)ROM.ReadShort(Constants.overworldMessages + (this.ParentID * 2));

            if (index != 0x80)
            {
                if (index <= 128)
                {
                    this.LargeMap = ROM.DATA[Constants.overworldMapSize + (index & 0x3F)] != 0;
                }
                else
                {
                    this.LargeMap = index == 129 || index == 130 || index == 137 || index == 138;
                }
            }

            // If the custom overworld ASM has NOT already been applied, manually set the vanilla values.
            if (ROM.DATA[Constants.OverworldCustomASMHasBeenApplied] == 0x00)
            {
                // Set the main palette values.
                if (index < 0x40)
                {
                    this.MainPalette = 0;
                }
                else if (index >= 0x40 && index < 0x80)
                {
                    this.MainPalette = 1;
                }
                else if (index >= 0x80 && index < 0xA0)
                {
                    this.MainPalette = 0;
                }

                if (index == 0x03 || index == 0x05 || index == 0x07)
                {
                    this.MainPalette = 2;
                }
                else if (index == 0x43 || index == 0x45 || index == 0x47)
                {
                    this.MainPalette = 3;
                }
                else if (index == 0x88)
                {
                    this.MainPalette = 4;
                }

                // Set the mosaic values.
                this.Mosaic = index == 0x00 || index == 0x40 || index == 0x80 || index == 0x81 || index == 0x88;

                // Set the animated GFX values.
                if (index == 0x03 || index == 0x05 || index == 0x07 || index == 0x43 || index == 0x45 || index == 0x47)
                {
                    this.AnimatedGFX = 0x59;
                }
                else
                {
                    this.AnimatedGFX = 0x5B;
                }

                // Set the subscreen overlay values.
                this.SubscreenOverlay = 0x00FF;

                if (index == 0x00 || index == 0x40) // Add fog 2 to the lost woods and skull woods.
                {
                    this.SubscreenOverlay = 0x009D;
                }
                else if (index == 0x03 || index == 0x05 || index == 0x07) // Add the sky BG to LW death mountain.
                {
                    this.SubscreenOverlay = 0x0095;
                }
                else if (index == 0x43 || index == 0x45 || index == 0x47) // Add the lava to DW death mountain.
                {
                    this.SubscreenOverlay = 0x009C;
                }
                else if (index == 0x5B) // TODO: Might need this one too "index == 0x1B" but for now I don't think so.
                {
                    this.SubscreenOverlay = 0x0096;
                }
                else if (index == 0x70) // Add the rain to misery mire.
                {
                    this.SubscreenOverlay = 0x009F;
                }
                else if (index == 0x80) // Add fog 1 to the master sword area.
                {
                    this.SubscreenOverlay = 0x0097;
                }
                else if (index == 0x88) // Add the triforce room curtains to the triforce room.
                {
                    this.SubscreenOverlay = 0x0093;
                }
            }
            else
            {
                this.MainPalette = ROM.DATA[Constants.OverworldCustomMainPaletteArray + index];

                this.Mosaic = ROM.DATA[Constants.OverworldCustomMosaicArray + index] != 0x00;

                this.AnimatedGFX = ROM.DATA[Constants.OverworldCustomAnimatedGFXArray + index];

                this.SubscreenOverlay = ROM.DATA[Constants.OverworldCustomSubscreenOverlayArray + (index * 2)];
            }

            if (index < 64)
            {
                this.SpriteGFX[0] = ROM.DATA[Constants.overworldSpriteset + this.ParentID];
                this.SpriteGFX[1] = ROM.DATA[Constants.overworldSpriteset + this.ParentID + 64];
                this.SpriteGFX[2] = ROM.DATA[Constants.overworldSpriteset + this.ParentID + 128];
                this.GFX = ROM.DATA[Constants.mapGfx + this.ParentID];
                this.AuxPalette = ROM.DATA[Constants.overworldMapPalette + this.ParentID];
                this.SpritePalette[0] = ROM.DATA[Constants.overworldSpritePalette + this.ParentID];
                this.SpritePalette[1] = ROM.DATA[Constants.overworldSpritePalette + this.ParentID + 64];
                this.SpritePalette[2] = ROM.DATA[Constants.overworldSpritePalette + this.ParentID + 128];
                this.Music[0] = ROM.DATA[Constants.overworldMusicBegining + this.ParentID];
                this.Music[1] = ROM.DATA[Constants.overworldMusicZelda + this.ParentID];
                this.Music[2] = ROM.DATA[Constants.overworldMusicMasterSword + this.ParentID];
                this.Music[3] = ROM.DATA[Constants.overworldMusicAgahim + this.ParentID];
            }
            else if (index < 128)
            {
                this.SpriteGFX[0] = ROM.DATA[Constants.overworldSpriteset + this.ParentID + 128];
                this.SpriteGFX[1] = ROM.DATA[Constants.overworldSpriteset + this.ParentID + 128];
                this.SpriteGFX[2] = ROM.DATA[Constants.overworldSpriteset + this.ParentID + 128];
                this.GFX = ROM.DATA[Constants.mapGfx + this.ParentID];
                this.AuxPalette = ROM.DATA[Constants.overworldMapPalette + this.ParentID];
                this.SpritePalette[0] = ROM.DATA[Constants.overworldSpritePalette + this.ParentID + 128];
                this.SpritePalette[1] = ROM.DATA[Constants.overworldSpritePalette + this.ParentID + 128];
                this.SpritePalette[2] = ROM.DATA[Constants.overworldSpritePalette + this.ParentID + 128];

                this.Music[0] = ROM.DATA[Constants.overworldMusicDW + (this.ParentID - 64)];
            }
            else
            {
                // TODO: switch statement.
                if (index == 0x94)
                {
                    this.ParentID = 128;
                }
                else if (index == 0x95)
                {
                    this.ParentID = 03;
                }
                else if (index == 0x96) // Pyramid bg use 0x5B map.
                {
                    this.ParentID = 0x5B;
                }
                else if (index == 0x97) // Pyramid bg use 0x5B map.
                {
                    this.ParentID = 0x00;
                }
                else if (index == 156)
                {
                    this.ParentID = 67;
                }
                else if (index == 157)
                {
                    this.ParentID = 0;
                }
                else if (index == 158)
                {
                    this.ParentID = 0;
                }
                else if (index == 159)
                {
                    this.ParentID = 44;
                }
                else if (index == 136)
                {
                    this.ParentID = 136;
                }
                else if (index == 129 || index == 130 || index == 137 || index == 138)
                {
                    this.ParentID = 129;
                }

                this.MessageID = ROM.DATA[Constants.overworldMessages + this.ParentID];

                this.SpriteGFX[0] = ROM.DATA[Constants.overworldSpriteset + this.ParentID + 128];
                this.SpriteGFX[1] = ROM.DATA[Constants.overworldSpriteset + this.ParentID + 128];
                this.SpriteGFX[2] = ROM.DATA[Constants.overworldSpriteset + this.ParentID + 128];
                this.SpritePalette[0] = ROM.DATA[Constants.overworldSpritePalette + this.ParentID + 128];
                this.SpritePalette[1] = ROM.DATA[Constants.overworldSpritePalette + this.ParentID + 128];
                this.SpritePalette[2] = ROM.DATA[Constants.overworldSpritePalette + this.ParentID + 128];

                this.AuxPalette = ROM.DATA[Constants.overworldSpecialPALGroup + this.ParentID - 128];
                if ((index >= 0x80 && index <= 0x8A && index != 0x88) || index == 0x94)
                {
                    this.GFX = ROM.DATA[Constants.overworldSpecialGFXGroup + (this.ParentID - 128)];
                    this.AuxPalette = ROM.DATA[Constants.overworldSpecialPALGroup + 1];
                }
                else if (index == 0x88)
                {
                    this.GFX = 81;
                    this.AuxPalette = 0;
                }
                else // Pyramid bg use 0x5B map.
                {
                    this.GFX = ROM.DATA[Constants.mapGfx + this.ParentID];
                    this.AuxPalette = ROM.DATA[Constants.overworldMapPalette + this.ParentID];
                }
            }
        }

        /// <summary>
        ///     Builds the area tile map from the GFX and puts them into the overworld bitmap.
        ///     TODO: Confirm this.
        /// </summary>
        public void BuildMap()
        {
            if (this.LargeMap)
            {
                if (this.ParentID != this.Index)
                {
                    /*
                        sprgfx[0] = ROM.DATA[Constants.overworldSpriteset + parent];
                        sprgfx[1] = ROM.DATA[Constants.overworldSpriteset + parent + 64];
                        sprgfx[2] = ROM.DATA[Constants.overworldSpriteset + parent + 128];
                    */

                    if (!this.FirstLoad)
                    {
                        if (this.Index >= 0x80 && this.Index <= 0x8A && this.Index != 0x88)
                        {
                            this.GFX = ROM.DATA[Constants.overworldSpecialGFXGroup + (this.ParentID - 128)];
                            this.AuxPalette = ROM.DATA[Constants.overworldSpecialPALGroup + 1];
                        }
                        else if (this.Index == 0x88)
                        {
                            this.GFX = 81;
                            this.AuxPalette = 0;
                        }
                        else
                        {
                            this.GFX = ROM.DATA[Constants.mapGfx + this.ParentID];
                            this.AuxPalette = ROM.DATA[Constants.overworldMapPalette + this.ParentID];
                        }

                        this.FirstLoad = true;
                    }
                }
            }

            this.Buildtileset();
            this.BuildTiles16Gfx(); // Build on GFX.mapgfx16Ptr
            this.LoadPalette();

            int world = 0;

            if (this.Index < 64)
            {
                this.TilesUsed = this.overworld.AllMapTile32LW;
            }
            else if (this.Index < 128 && this.Index >= 64)
            {
                this.TilesUsed = this.overworld.AllMapTile32DW;
                world = 1;
            }
            else
            {
                this.TilesUsed = this.overworld.AllMapTile32SP;
                world = 2;
            }

            int superY = (this.Index - (world * 64)) / 8;
            int superX = this.Index - (world * 64) - (superY * 8);

            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    this.CopyTile8bpp16(x * 16, y * 16, this.TilesUsed[x + (superX * 32), y + (superY * 32)], this.GFXPointer, ZeldaFullEditor.GFX.mapblockset16);
                }
            }

            // 8x8 CODE NEW
            /*
            for (int y = 0; y < 32; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    CopyTile8bpp16From8((x*16), (y*16), tilesUsed[x + (superX * 32), y + (superY * 32)], gfxPtr, GFX.currentOWgfx16Ptr);
                }
            }
            */
        }

        /// <summary>
        ///     Copys the given Tile8 GFX from the source pointer to the destination pointer.
        /// </summary>
        /// <param name="x"> The X poistion for the tile. </param>
        /// <param name="y"> The Y poistion for the tile. </param>
        /// <param name="tile"> The index of the tile. </param>
        /// <param name="destinationPointer"> The destination pointer. </param>
        /// <param name="sourcePointer"> The source pointer. </param>
        public unsafe void CopyTile8bpp16(int x, int y, int tile, IntPtr destinationPointer, IntPtr sourcePointer)
        {
            int sourceY = tile / 8;
            int sourceX = tile - (sourceY * 8);
            int sourcePointerPosition = ((tile - ((tile / 8) * 8)) * 16) + ((tile / 8) * 2048); // (sourceX * 16) + (sourceY * 128);
            byte* sourcePtr = (byte*)sourcePointer.ToPointer();

            int destinationPointerPosition = x + (y * 512);
            byte* destPtr = (byte*)destinationPointer.ToPointer();

            for (int yStrip = 0; yStrip < 16; yStrip++)
            {
                for (int xStrip = 0; xStrip < 16; xStrip++)
                {
                    destPtr[destinationPointerPosition + xStrip + (yStrip * 512)] = sourcePtr[sourcePointerPosition + xStrip + (yStrip * 128)];
                }
            }
        }

        /// <summary>
        ///     Loads and then sets the palettes for the area.
        /// </summary>
        public void LoadPalette()
        {
            int previousPalId = 0;
            int previousSprPalId = 0;
            if (this.Index > 0)
            {
                previousPalId = ROM.DATA[Constants.overworldMapPalette + this.ParentID - 1];
                previousSprPalId = ROM.DATA[Constants.overworldSpritePalette + this.ParentID - 1];
            }

            if (this.AuxPalette >= 0xA3)
            {
                this.AuxPalette = 0xA3;
            }

            byte pal1 = ROM.DATA[Constants.overworldMapPaletteGroup + (this.AuxPalette * 4)]; // aux1
            byte pal2 = ROM.DATA[Constants.overworldMapPaletteGroup + (this.AuxPalette * 4) + 1]; // aux2
            byte pal3 = ROM.DATA[Constants.overworldMapPaletteGroup + (this.AuxPalette * 4) + 2]; // animated

            byte pal4 = ROM.DATA[Constants.overworldSpritePaletteGroup + (this.SpritePalette[this.overworld.GameState] * 2)]; // spr3
            byte pal5 = ROM.DATA[Constants.overworldSpritePaletteGroup + (this.SpritePalette[this.overworld.GameState] * 2) + 1]; // spr4

            Color[] aux1, aux2, main, animated, hud, spr, spr2;
            Color bgr = Palettes.OverworldGrassPalettes[0];

            if (pal1 == 255)
            {
                pal1 = ROM.DATA[Constants.overworldMapPaletteGroup + (previousPalId * 4)];
            }

            if (pal1 != 255)
            {
                if (pal1 >= 20)
                {
                    pal1 = 19;
                }

                aux1 = Palettes.OverworldAuxPalettes[pal1];
            }
            else
            {
                aux1 = Palettes.OverworldAuxPalettes[0];
            }

            if (pal2 == 255)
            {
                pal2 = ROM.DATA[Constants.overworldMapPaletteGroup + (previousPalId * 4) + 1];
            }

            if (pal2 != 255)
            {
                if (pal2 >= 20)
                {
                    pal2 = 19;
                }

                aux2 = Palettes.OverworldAuxPalettes[pal2];
            }
            else
            {
                aux2 = Palettes.OverworldAuxPalettes[0];
            }

            if (pal3 == 255)
            {
                pal3 = ROM.DATA[Constants.overworldMapPaletteGroup + (previousPalId * 4) + 2];
            }

            if (this.ParentID < 0x40)
            {
                if (OverworldEditor.UseAreaSpecificBgColor)
                {
                    bgr = Palettes.OverworldBackgroundPalette[this.ParentID];
                }
                else
                {
                    bgr = Palettes.OverworldGrassPalettes[0];
                }
            }
            else if (this.ParentID >= 0x40 && this.ParentID < 0x80)
            {
                if (OverworldEditor.UseAreaSpecificBgColor)
                {
                    bgr = Palettes.OverworldBackgroundPalette[this.ParentID];
                }
                else
                {
                    bgr = Palettes.OverworldGrassPalettes[1];
                }
            }
            else if (this.ParentID >= 128 && this.ParentID < Constants.NumberOfOWMaps)
            {
                if (OverworldEditor.UseAreaSpecificBgColor)
                {
                    bgr = Palettes.OverworldBackgroundPalette[this.ParentID];
                }
                else
                {
                    bgr = Palettes.OverworldGrassPalettes[2];
                }
            }

            if (this.overworld.AllMaps[this.ParentID].MainPalette != 255)
            {
                main = Palettes.OverworldMainPalettes[this.overworld.AllMaps[this.ParentID].MainPalette];
            }
            else
            {
                main = Palettes.OverworldMainPalettes[0];
            }

            if (pal3 >= 14)
            {
                pal3 = 13;
            }

            animated = Palettes.OverworldAnimatedPalettes[pal3];

            hud = Palettes.HudPalettes[0];
            if (pal4 == 255)
            {
                pal4 = ROM.DATA[Constants.overworldSpritePaletteGroup + (previousSprPalId * 2)]; // spr3
            }

            if (pal4 == 255)
            {
                pal4 = 0;
            }

            if (pal4 >= 24)
            {
                pal4 = 23;
            }

            spr = Palettes.SpritesAux3Palettes[pal4];

            if (pal5 == 255)
            {
                pal5 = ROM.DATA[Constants.overworldSpritePaletteGroup + (previousSprPalId * 2) + 1]; // spr3
            }

            if (pal5 == 255)
            {
                pal5 = 0;
            }

            if (pal5 >= 24)
            {
                pal5 = 23;
            }

            spr2 = Palettes.SpritesAux3Palettes[pal5];

            this.SetColorsPalette(main, animated, aux1, aux2, hud, bgr, spr, spr2);
        }

        /// <summary>
        ///     Builds the maps tile set and stores them in a buffer used in drawing.
        /// </summary>
        public void Buildtileset()
        {
            int indexWorld = 0x20;
            if (this.ParentID < 0x40)
            {
                indexWorld = 0x20;
            }
            else if (this.ParentID >= 0x40 && this.ParentID < 0x80)
            {
                indexWorld = 0x21;
            }
            else if (this.ParentID == 0x88)
            {
                indexWorld = 0x24;
            }

            // Sprites Blocksets
            this.StaticGFX[8] = 115 + 0;
            this.StaticGFX[9] = 115 + 1;
            this.StaticGFX[10] = 115 + 6;
            this.StaticGFX[11] = 115 + 7;

            for (int i = 0; i < 4; i++)
            {
                this.StaticGFX[12 + i] = (byte)(ROM.DATA[Constants.sprite_blockset_pointer + (this.SpriteGFX[this.overworld.GameState] * 4) + i] + 115);
            }

            // Main Blocksets
            for (int i = 0; i < 8; i++)
            {
                byte temp = ROM.DATA[Constants.overworldgfxGroups2 + (indexWorld * 8) + i];
                this.StaticGFX[i] = temp;
            }

            if (ROM.DATA[Constants.overworldgfxGroups + (this.GFX * 4)] != 0)
            {
                this.StaticGFX[3] = ROM.DATA[Constants.overworldgfxGroups + (this.GFX * 4)];
            }

            if (ROM.DATA[Constants.overworldgfxGroups + (this.GFX * 4) + 1] != 0)
            {
                this.StaticGFX[4] = ROM.DATA[Constants.overworldgfxGroups + (this.GFX * 4) + 1];
            }

            if (ROM.DATA[Constants.overworldgfxGroups + (this.GFX * 4) + 2] != 0)
            {
                this.StaticGFX[5] = ROM.DATA[Constants.overworldgfxGroups + (this.GFX * 4) + 2];
            }

            if (ROM.DATA[Constants.overworldgfxGroups + (this.GFX * 4) + 3] != 0)
            {
                this.StaticGFX[6] = ROM.DATA[Constants.overworldgfxGroups + (this.GFX * 4) + 3];
            }

            // Replace the animated tiles with the custom set ones.
            this.StaticGFX[7] = this.overworld.AllMaps[this.ParentID].AnimatedGFX;

            /*
			if (this.Parent >= 128 & this.Parent < 148)
			{
				this.StaticGFX[4] = 71;
				this.StaticGFX[5] = 72;
			}
			*/

            unsafe
            {
                // NEEDS TO BE EXECUTED AFTER THE TILESET ARE LOADED NOT BEFORE -_-
                byte* currentmapgfx8Data = (byte*)ZeldaFullEditor.GFX.currentOWgfx16Ptr.ToPointer(); // Loaded gfx for the current map (empty at this point).
                byte* allgfxData = (byte*)ZeldaFullEditor.GFX.allgfx16Ptr.ToPointer(); // All gfx of the game pack of 2048 bytes (4bpp).
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 2048; j++)
                    {
                        byte mapByte = allgfxData[j + (this.StaticGFX[i] * 2048)];
                        switch (i)
                        {
                            case 0:
                            case 3:
                            case 4:
                            case 5:
                                mapByte += 0x88;
                                break;
                        }

                        currentmapgfx8Data[(i * 2048) + j] = mapByte; // Upload used gfx data.
                    }
                }
            }
        }

        /// <summary>
        ///		Sets the given map to be a large map.
        /// </summary>
        /// <param name="parentIndex"> The index of the parent. </param>
        /// <param name="largeIndex"> The large map index. 0 for top left, 1 for top right, 2 for bottom left, and 3 for bottom right. </param>
        public void SetAsLargeMap(byte parentIndex, byte largeIndex)
        {
            this.ParentID = parentIndex;
            this.LargeMap = true;
            this.LargeIndex = largeIndex;
        }

        /// <summary>
        ///		Sets the given map to be a small map.
        /// </summary>
        /// <param name="parentIndex"> The parent index to set the map to, You should generally not use this. </param>
        public void SetAsSmallMap(byte? parentIndex = null)
        {
            if (parentIndex == null)
            {
                this.ParentID = this.Index;
            }
            else
            {
                this.ParentID = (byte)parentIndex;
            }

            this.LargeMap = false;
            this.LargeIndex = 0;
        }

        private unsafe void BuildTiles16Gfx()
        {
            var gfx16Data = (byte*)ZeldaFullEditor.GFX.mapblockset16.ToPointer(); // (byte*)allgfx8Ptr.ToPointer();
            var gfx8Data = (byte*)ZeldaFullEditor.GFX.currentOWgfx16Ptr.ToPointer(); // (byte*)allgfx16Ptr.ToPointer();
            int[] offsets = { 0, 8, 1024, 1032 };
            var yy = 0;
            var xx = 0;

            for (var i = 0; i < this.overworld.Tile16List.Count; i++) // Number of tiles16 3748?
            {
                // 8x8 tile draw
                // gfx8 = 4bpp so everyting is /2
                // Var tiles = ow.tiles16[i];
                for (var tile = 0; tile < 4; tile++)
                {
                    TileInfo info = this.overworld.Tile16List[i].TileInfoArray[tile];
                    int offset = offsets[tile];

                    for (var y = 0; y < 8; y++)
                    {
                        for (var x = 0; x < 4; x++)
                        {
                            this.CopyTile(x, y, xx, yy, offset, info, gfx16Data, gfx8Data);
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

        private unsafe void CopyTile(int x, int y, int xx, int yy, int offset, TileInfo tile, byte* gfx16Pointer, byte* gfx8Pointer) // map, current
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

            gfx16Pointer[index + r ^ 1] = (byte)((pixel & 0x0F) + (tile.palette * 16));
            gfx16Pointer[index + r] = (byte)(((pixel >> 4) & 0x0F) + (tile.palette * 16));
        }

        private unsafe void CopyTileToMap(int x, int y, int xx, int yy, int offset, TileInfo tile, byte* gfx16Pointer, byte* gfx8Pointer) // map, current
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
            var index = xx + (yy * 512) + offset + (mx * 2) + (my * 512);
            var pixel = gfx8Pointer[tx + (y * 64) + x];

            gfx16Pointer[index + r ^ 1] = (byte)((pixel & 0x0F) + (tile.palette * 16));
            gfx16Pointer[index + r] = (byte)(((pixel >> 4) & 0x0F) + (tile.palette * 16));
        }

        private void SetColorsPalette(Color[] main, Color[] animated, Color[] aux1, Color[] aux2, Color[] hud, Color bgrcolor, Color[] spr, Color[] spr2)
        {
            // Palettes infos, color 0 of a palette is always transparent (the arrays contains 7 colors width wide)
            // There is 16 color per line so 16*Y.

            // Left side of the palette - Main, Animated.
            Color[] currentPalette = new Color[256];

            // Main Palette, Location 0,2 : 35 colors [7x5]
            int k = 0;
            for (int y = 2; y < 7; y++)
            {
                for (int x = 1; x < 8; x++)
                {
                    currentPalette[x + (16 * y)] = main[k++];
                }
            }

            // Animated Palette, Location 0,7 : 7colors
            for (int x = 1; x < 8; x++)
            {
                currentPalette[(16 * 7) + x] = animated[x - 1];
            }

            // Right side of the palette - Aux1, Aux2

            // Aux1 Palette, Location 8,2 : 21 colors [7x3]
            k = 0;
            for (int y = 2; y < 5; y++)
            {
                for (int x = 9; x < 16; x++)
                {
                    currentPalette[x + (16 * y)] = aux1[k++];
                }
            }

            // Aux2 Palette, Location 8,5 : 21 colors [7x3]
            k = 0;
            for (int y = 5; y < 8; y++)
            {
                for (int x = 9; x < 16; x++)
                {
                    currentPalette[x + (16 * y)] = aux2[k++];
                }
            }

            // Hud Palette, Location 0,0 : 32 colors [16x2]
            for (int i = 0; i < 32; i++)
            {
                currentPalette[i] = hud[i];
            }

            // Hardcoded grass color (that might change to become invisible instead).
            for (int i = 0; i < 8; i++)
            {
                currentPalette[i * 16] = bgrcolor;
                currentPalette[(i * 16) + 8] = bgrcolor;
            }

            // Sprite Palettes
            k = 0;
            for (int y = 8; y < 9; y++)
            {
                for (int x = 1; x < 8; x++)
                {
                    currentPalette[x + (16 * y)] = Palettes.SpritesAux1Palettes[1][k++];
                }
            }

            // Sprite Palettes
            k = 0;
            for (int y = 8; y < 9; y++)
            {
                for (int x = 9; x < 16; x++)
                {
                    currentPalette[x + (16 * y)] = Palettes.SpritesAux3Palettes[0][k++];
                }
            }

            // Sprite Palettes
            k = 0;
            for (int y = 9; y < 13; y++)
            {
                for (int x = 1; x < 16; x++)
                {
                    currentPalette[x + (16 * y)] = Palettes.GlobalSpritePalettes[0][k++];
                }
            }

            // Sprite Palettes
            k = 0;
            for (int y = 13; y < 14; y++)
            {
                for (int x = 1; x < 8; x++)
                {
                    currentPalette[x + (16 * y)] = spr[k++];
                }
            }

            // Sprite Palettes
            k = 0;
            for (int y = 14; y < 15; y++)
            {
                for (int x = 1; x < 8; x++)
                {
                    currentPalette[x + (16 * y)] = spr2[k++];
                }
            }

            // Sprite Palettes
            k = 0;
            for (int y = 15; y < 16; y++)
            {
                for (int x = 1; x < 16; x++)
                {
                    currentPalette[x + (16 * y)] = Palettes.ArmorPalettes[0][k++];
                }
            }

            try
            {
                ColorPalette pal = ZeldaFullEditor.GFX.editort16Bitmap.Palette;
                for (int i = 0; i < 256; i++)
                {
                    pal.Entries[i] = currentPalette[i];
                    pal.Entries[(i / 16) * 16] = Color.Transparent;
                }

                ZeldaFullEditor.GFX.mapgfx16Bitmap.Palette = pal;
                ZeldaFullEditor.GFX.mapblockset16Bitmap.Palette = pal;

                /*
                for (int i = 0; i < 256; i++)
                {
                    if (index == 3)
                    {
                    }
                    else if (index == 4)
                    {
                        pal.Entries[(i / 16) * 16] = Color.Transparent;
                    }
                }
                */

                this.GFXBitmap.Palette = pal;
            }
            catch (Exception)
            {
                // TODO: Add exception message.
            }
        }

        #region Unused

        /// <summary>
        ///     TODO: Unused?
        /// </summary>
        /// <param name="xP"> The X position? </param>
        /// <param name="yP"> The Y position? </param>
        /// <param name="tileID"> The tile index. </param>
        /// <param name="destbmpPtr"> The destination bitmap pointer. </param>
        /// <param name="sourcebmpPtr"> The source bitmap pointer. </param>
        public unsafe void CopyTile8bpp16From8(int xP, int yP, int tileID, IntPtr destbmpPtr, IntPtr sourcebmpPtr)
        {
            var gfx16Data = (byte*)destbmpPtr.ToPointer(); // (byte*)allgfx8Ptr.ToPointer();
            var gfx8Data = (byte*)ZeldaFullEditor.GFX.currentOWgfx16Ptr.ToPointer(); // (byte*)allgfx16Ptr.ToPointer();
            int[] offsets = { 0, 8, 4096, 4104 };

            var tiles = this.overworld.Tile16List[tileID];

            for (var tile = 0; tile < 4; tile++)
            {
                TileInfo info = tiles.TileInfoArray[tile];
                int offset = offsets[tile];

                for (var y = 0; y < 8; y++)
                {
                    for (var x = 0; x < 4; x++)
                    {
                        this.CopyTileToMap(x, y, xP, yP, offset, info, gfx16Data, gfx8Data);
                    }
                }
            }
        }

        #endregion
    }
}
