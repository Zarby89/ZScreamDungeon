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
        public AreaSizeEnum AreaSize { get; internal set; } = AreaSizeEnum.SmallArea;

        /// <summary>
        ///     Gets a value indicating what corner of a large area this map is.
        ///     0 1
        ///     2 3
        /// </summary>
        public byte AreaSizeQuadrant { get; internal set; } = 0;

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
        ///     This is 4 bits, one for each direction leaving the area. Up, Down, Left, Right.
        /// </summary>
        public (bool Up, bool Down, bool Left, bool Right) Mosaic { get; set; } = (false, false, false, false);

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
        public byte[] StaticGFX { get; internal set; } = new byte[17];

        /// <summary>
        ///     Gets or sets the Animated GFX used to replace StaticGFX[7] with custom area specific animated GFX.
        /// </summary>
        public byte AnimatedGFX { get; set; }

        /// <summary>
        ///     Gets or sets the Tile GFX 0 used to replace StaticGFX[0] with custom area specific GFX.
        /// </summary>
        public byte TileGFX0 { get; set; }

        /// <summary>
        ///     Gets or sets the Tile GFX 1 used to replace StaticGFX[1] with custom area specific GFX.
        /// </summary>
        public byte TileGFX1 { get; set; }

        /// <summary>
        ///     Gets or sets the Tile GFX 2 used to replace StaticGFX[2] with custom area specific GFX.
        /// </summary>
        public byte TileGFX2 { get; set; }

        /// <summary>
        ///     Gets or sets the Tile GFX 3 used to replace StaticGFX[3] with custom area specific GFX.
        /// </summary>
        public byte TileGFX3 { get; set; }

        /// <summary>
        ///     Gets or sets the Tile GFX 4 used to replace StaticGFX[4] with custom area specific GFX.
        /// </summary>
        public byte TileGFX4 { get; set; }

        /// <summary>
        ///     Gets or sets the Tile GFX 5 used to replace StaticGFX[5] with custom area specific GFX.
        /// </summary>
        public byte TileGFX5 { get; set; }

        /// <summary>
        ///     Gets or sets the Tile GFX 6 used to replace StaticGFX[6] with custom area specific GFX.
        /// </summary>
        public byte TileGFX6 { get; set; }

        /// <summary>
        ///     Gets or sets the Tile GFX 7 used to replace StaticGFX[7] with custom area specific GFX.
        /// </summary>
        public byte TileGFX7 { get; set; }

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
            this.AreaSizeQuadrant = 0;
            this.GFXBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, this.GFXPointer);
            this.MessageID = (short)ROM.ReadShort(Constants.overworldMessages + (this.ParentID * 2));

            byte asmVersion = ROM.DATA[Constants.OverworldCustomASMHasBeenApplied];

            if (asmVersion < 3)
            {
                if (index < 0x80)
                {
                    // ASM version 3 was the implementation of Half areas, so if its not greater than 3 we need to swap the small and large area values.
                    switch (ROM.DATA[Constants.overworldScreenSize + (index & 0x3F)])
                    {
                        case 0:
                            this.AreaSize = AreaSizeEnum.LargeArea;
                            break;

                        case 1:
                        default:
                            this.AreaSize = AreaSizeEnum.SmallArea;
                            break;

                        // These values shouldn't be possible at this point, but just in case.
                        case 2:
                            this.AreaSize = AreaSizeEnum.WideArea;
                            break;

                        case 3:
                            this.AreaSize = AreaSizeEnum.TallArea;
                            break;
                    }
                }
                else
                {
                    // Before ASM version 3, SW areas were also hardcoded.
                    this.AreaSize = index == 0x81 || index == 0x82 || index == 0x89 || index == 0x81 ? AreaSizeEnum.LargeArea : AreaSizeEnum.SmallArea;
                }
            }
            else
            {
                this.AreaSize = (AreaSizeEnum)ROM.DATA[Constants.overworldScreenSize + index];
            }

            if (index < 0x40)
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
            else if (index < 0x80)
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
                switch (index)
                {
                    case 0x94:
                        this.ParentID = 0x80;
                        break;

                    case 0x95:
                        this.ParentID = 0x03;
                        break;

                    case 0x96:
                        // Pyramid BG use 0x5B map.
                        this.ParentID = 0x5B;
                        break;

                    case 0x97:
                        // Pyramid bg use 0x5B map.
                        this.ParentID = 0x00;
                        break;

                    case 0x9C:
                        this.ParentID = 0x43;
                        break;

                    case 0x9D:
                        this.ParentID = 0x00;
                        break;

                    case 0x9E:
                        this.ParentID = 0x00;
                        break;

                    case 0x9F:
                        this.ParentID = 0x2C;
                        break;

                    case 0x88:
                        this.ParentID = 0x88;
                        break;

                    case 0x81:
                    case 0x82:
                    case 0x89:
                    case 0x8A:
                        this.ParentID = 0x81;
                        break;
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
                else // Pyramid BG use 0x5B map.
                {
                    this.GFX = ROM.DATA[Constants.mapGfx + this.ParentID];
                    this.AuxPalette = ROM.DATA[Constants.overworldMapPalette + this.ParentID];
                }
            }

            // If the custom overworld ASM has NOT already been applied, manually set the vanilla values.
            if (asmVersion == 0x00)
            {
                // Set the main palette values.
                if (index < 0x40) // LW
                {
                    this.MainPalette = 0;
                }
                else if (index >= 0x40 && index < 0x80) // DW
                {
                    this.MainPalette = 1;
                }
                else if (index >= 0x80 && index < 0xA0) // SW
                {
                    this.MainPalette = 0;
                }

                if (index == 0x03 || index == 0x05 || index == 0x07) // LW Death Mountain
                {
                    this.MainPalette = 2;
                }
                else if (index == 0x43 || index == 0x45 || index == 0x47) // DW Death Mountain
                {
                    this.MainPalette = 3;
                }
                else if (index == 0x88) // Triforce room
                {
                    this.MainPalette = 4;
                }

                // Set the mosaic values.
                switch (index)
                {
                    case 0x00: // Leaving Skull Woods / Lost Woods
                    case 0x40: 
                        this.Mosaic = (false, true, false, true);

                        break;

                    case 0x02: // Going into Skull woods / Lost Woods west
                    case 0x0A:
                    case 0x42:
                    case 0x4A:
                        this.Mosaic = (false, false, true, false);
                        
                        break;

                    case 0x0F: // Going into Zora's Domain North
                    case 0x10: // Going into Skull Woods / Lost Woods North
                    case 0x11:
                    case 0x50:
                    case 0x51:
                        this.Mosaic = (true, false, false, false);

                        break;

                    case 0x80: // Leaving Zora's Domain, the Master Sword area, and the Triforce area
                    case 0x81:
                    case 0x88:
                        this.Mosaic = (false, true, false, false);

                        break;
                }

                int indexWorld = 0x20;

                if (this.ParentID >= 0x40 && this.ParentID < 0x80) // DW
                {
                    indexWorld = 0x21;
                }
                else if (this.ParentID == 0x88) // Triforce room
                {
                    indexWorld = 0x24;
                }

                // Main Blocksets
                this.TileGFX0 = (byte)ROM.DATA[Constants.overworldgfxGroups2 + (indexWorld * 8) + 0];
                this.TileGFX1 = (byte)ROM.DATA[Constants.overworldgfxGroups2 + (indexWorld * 8) + 1];
                this.TileGFX2 = (byte)ROM.DATA[Constants.overworldgfxGroups2 + (indexWorld * 8) + 2];
                this.TileGFX3 = (byte)ROM.DATA[Constants.overworldgfxGroups2 + (indexWorld * 8) + 3];
                this.TileGFX4 = (byte)ROM.DATA[Constants.overworldgfxGroups2 + (indexWorld * 8) + 4];
                this.TileGFX5 = (byte)ROM.DATA[Constants.overworldgfxGroups2 + (indexWorld * 8) + 5];
                this.TileGFX6 = (byte)ROM.DATA[Constants.overworldgfxGroups2 + (indexWorld * 8) + 6];
                this.TileGFX7 = (byte)ROM.DATA[Constants.overworldgfxGroups2 + (indexWorld * 8) + 7];

                // Replace the variable tiles with the variable ones.
                byte temp = ROM.DATA[Constants.overworldgfxGroups + (this.GFX * 4)];
                if (temp != 0)
                {
                    this.TileGFX3 = temp;
                }
                else
                {
                    this.TileGFX3 = 0xFF;
                }

                temp = ROM.DATA[Constants.overworldgfxGroups + (this.GFX * 4) + 1];
                if (temp != 0)
                {
                    this.TileGFX4 = temp;
                }
                else
                {
                    this.TileGFX4 = 0xFF;
                }

                temp = ROM.DATA[Constants.overworldgfxGroups + (this.GFX * 4) + 2];
                if (temp != 0)
                {
                    this.TileGFX5 = temp;
                }
                else
                {
                    this.TileGFX5 = 0xFF;
                }

                temp = ROM.DATA[Constants.overworldgfxGroups + (this.GFX * 4) + 3];
                if (temp != 0)
                {
                    this.TileGFX6 = temp;
                }
                else
                {
                    this.TileGFX6 = 0xFF;
                }

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

                if (index == 0x00 || index == 0x01 || index == 0x08 || index == 0x09 || index == 0x40 || index == 0x41 || index == 0x48 || index == 0x49) // Add fog 2 to the lost woods and skull woods.
                {
                    this.SubscreenOverlay = 0x009D;
                }
                else if (index == 0x03 || index == 0x04 || index == 0x0B || index == 0x0C || index == 0x05 || index == 0x06 || index == 0x0D || index == 0x0E || index == 0x07) // Add the sky BG to LW death mountain.
                {
                    this.SubscreenOverlay = 0x0095;
                }
                else if (index == 0x43 || index == 0x44 || index == 0x4B || index == 0x4C || index == 0x45 || index == 0x46 || index == 0x4D || index == 0x4E || index == 0x47) // Add the lava to DW death mountain.
                {
                    this.SubscreenOverlay = 0x009C;
                }
                else if (index == 0x5B || index == 0x5C || index == 0x63 || index == 0x64) // TODO: Might need this one too "index == 0x1B" but for now I don't think so.
                {
                    this.SubscreenOverlay = 0x0096;
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

                byte mosaicByte = ROM.DATA[Constants.OverworldCustomMosaicArray + index];
                // .... udlr
                this.Mosaic = ((mosaicByte & 0x08) != 0x00, (mosaicByte & 0x04) != 0x00, (mosaicByte & 0x02) != 0x00, (mosaicByte & 0x01) != 0x00);

                // This is just to load the GFX groups for ROMs that have an older version of the Overworld ASM already applied.
                if (asmVersion >= 0x01 && asmVersion != 0xFF)
                {
                    this.TileGFX0 = ROM.DATA[Constants.OverworldCustomTileGFXGroupArray + (index * 8) + 0];
                    this.TileGFX1 = ROM.DATA[Constants.OverworldCustomTileGFXGroupArray + (index * 8) + 1];
                    this.TileGFX2 = ROM.DATA[Constants.OverworldCustomTileGFXGroupArray + (index * 8) + 2];
                    this.TileGFX3 = ROM.DATA[Constants.OverworldCustomTileGFXGroupArray + (index * 8) + 3];
                    this.TileGFX4 = ROM.DATA[Constants.OverworldCustomTileGFXGroupArray + (index * 8) + 4];
                    this.TileGFX5 = ROM.DATA[Constants.OverworldCustomTileGFXGroupArray + (index * 8) + 5];
                    this.TileGFX6 = ROM.DATA[Constants.OverworldCustomTileGFXGroupArray + (index * 8) + 6];
                    this.TileGFX7 = ROM.DATA[Constants.OverworldCustomTileGFXGroupArray + (index * 8) + 7];

                    this.AnimatedGFX = ROM.DATA[Constants.OverworldCustomAnimatedGFXArray + index];
                }
                else
                {
                    int indexWorld = 0x20;

                    if (this.ParentID >= 0x40 && this.ParentID < 0x80) // DW
                    {
                        indexWorld = 0x21;
                    }
                    else if (this.ParentID == 0x88) // Triforce room
                    {
                        indexWorld = 0x24;
                    }

                    // Main Blocksets
                    this.TileGFX0 = (byte)ROM.DATA[Constants.overworldgfxGroups2 + (indexWorld * 8) + 0];
                    this.TileGFX1 = (byte)ROM.DATA[Constants.overworldgfxGroups2 + (indexWorld * 8) + 1];
                    this.TileGFX2 = (byte)ROM.DATA[Constants.overworldgfxGroups2 + (indexWorld * 8) + 2];
                    this.TileGFX3 = (byte)ROM.DATA[Constants.overworldgfxGroups2 + (indexWorld * 8) + 3];
                    this.TileGFX4 = (byte)ROM.DATA[Constants.overworldgfxGroups2 + (indexWorld * 8) + 4];
                    this.TileGFX5 = (byte)ROM.DATA[Constants.overworldgfxGroups2 + (indexWorld * 8) + 5];
                    this.TileGFX6 = (byte)ROM.DATA[Constants.overworldgfxGroups2 + (indexWorld * 8) + 6];
                    this.TileGFX7 = (byte)ROM.DATA[Constants.overworldgfxGroups2 + (indexWorld * 8) + 7];

                    // Replace the variable tiles with the variable ones.
                    // If the variable is 00 set it to 0xFF which is the new "don't load anything" value.
                    byte temp = ROM.DATA[Constants.overworldgfxGroups + (this.GFX * 4)];
                    if (temp != 0x00)
                    {
                        this.TileGFX3 = temp;
                    }
                    else
                    {
                        this.TileGFX3 = 0xFF;
                    }

                    temp = ROM.DATA[Constants.overworldgfxGroups + (this.GFX * 4) + 1];
                    if (temp != 0x00)
                    {
                        this.TileGFX4 = temp;
                    }
                    else
                    {
                        this.TileGFX4 = 0xFF;
                    }

                    temp = ROM.DATA[Constants.overworldgfxGroups + (this.GFX * 4) + 2];
                    if (temp != 0x00)
                    {
                        this.TileGFX5 = temp;
                    }
                    else
                    {
                        this.TileGFX5 = 0xFF;
                    }

                    temp = ROM.DATA[Constants.overworldgfxGroups + (this.GFX * 4) + 3];
                    if (temp != 0x00)
                    {
                        this.TileGFX6 = temp;
                    }
                    else
                    {
                        this.TileGFX6 = 0xFF;
                    }

                    // Set the animated GFX values.
                    if (index == 0x03 || index == 0x05 || index == 0x07 || index == 0x43 || index == 0x45 || index == 0x47)
                    {
                        this.AnimatedGFX = 0x59;
                    }
                    else
                    {
                        this.AnimatedGFX = 0x5B;
                    }
                }

                this.SubscreenOverlay = ROM.DATA[Constants.OverworldCustomSubscreenOverlayArray + (index * 2)];
            }
        }

        /// <summary>
        ///     Builds the area tile map from the GFX and puts them into the overworld bitmap.
        ///     TODO: Confirm this.
        /// </summary>
        public void BuildMap()
        {
            if (this.AreaSize != AreaSizeEnum.SmallArea && this.ParentID != this.Index)
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
                        this.GFX = 0x51;
                        this.AuxPalette = 0x00;
                    }
                    else
                    {
                        this.GFX = ROM.DATA[Constants.mapGfx + this.ParentID];
                        this.AuxPalette = ROM.DATA[Constants.overworldMapPalette + this.ParentID];
                    }

                    this.FirstLoad = true;
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
                if (pal1 >= Palettes.OverworldAuxPalettes.Length)
                {
                    pal1 = (byte)(Palettes.OverworldAuxPalettes.Length - 1);
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
                if (pal2 >= Palettes.OverworldAuxPalettes.Length)
                {
                    pal2 = (byte)(Palettes.OverworldAuxPalettes.Length - 1);
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

            int mainPalette = this.overworld.AllMaps[this.ParentID].MainPalette;
            if (mainPalette >= 0)
            {
                if (mainPalette < Palettes.OverworldMainPalettes.Length)
                {
                    main = Palettes.OverworldMainPalettes[mainPalette];
                }
                else
                {
                    main = Palettes.OverworldMainPalettes[Palettes.OverworldMainPalettes.Length - 1];
                }
            }
            else
            {
                main = Palettes.OverworldMainPalettes[0];
            }

            if (pal3 >= Palettes.OverworldAnimatedPalettes.Length)
            {
                pal3 = (byte)(Palettes.OverworldAnimatedPalettes.Length - 1);
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

            if (pal4 >= Palettes.SpritesAux3Palettes.Length)
            {
                pal4 = (byte)(Palettes.SpritesAux3Palettes.Length - 1);
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

            if (pal5 >= Palettes.SpritesAux3Palettes.Length)
            {
                pal5 = (byte)(Palettes.SpritesAux3Palettes.Length - 1);
            }

            spr2 = Palettes.SpritesAux3Palettes[pal5];

            this.SetColorsPalette(main, animated, aux1, aux2, hud, bgr, spr, spr2);
        }

        /// <summary>
        ///     Builds the maps tile set and stores them in a buffer used in drawing.
        /// </summary>
        public void Buildtileset()
        {
            // Replace the animated tiles with the custom set ones.
            this.StaticGFX[0] = this.overworld.AllMaps[this.ParentID].TileGFX0;
            this.StaticGFX[1] = this.overworld.AllMaps[this.ParentID].TileGFX1;
            this.StaticGFX[2] = this.overworld.AllMaps[this.ParentID].TileGFX2;
            this.StaticGFX[3] = this.overworld.AllMaps[this.ParentID].TileGFX3;
            this.StaticGFX[4] = this.overworld.AllMaps[this.ParentID].TileGFX4;
            this.StaticGFX[5] = this.overworld.AllMaps[this.ParentID].TileGFX5;
            this.StaticGFX[6] = this.overworld.AllMaps[this.ParentID].TileGFX6;
            this.StaticGFX[7] = this.overworld.AllMaps[this.ParentID].TileGFX7;

            this.StaticGFX[16] = this.overworld.AllMaps[this.ParentID].AnimatedGFX;

            // If the GFX are 0xFF they need to show the defualt GFX instead.
            int world = 0;
            if (this.ParentID >= 0x40 && this.ParentID < 0x80)
            {
                world = 8;
            }
            else if (this.ParentID >= 0x80)
            {
                world = 16;
            }

            for (int i = 0; i <  8; i++)
            {
                if (this.StaticGFX[i] == 0xFF)
                {
                    this.StaticGFX[i] = (byte)Constants.OverworldCustomDefaultTileGFX[i + world];
                }
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

                            // The first half of sheet 7 needs to load from the animated sheet.
                            case 7:
                                if (j < 1024)
                                {
                                    mapByte = allgfxData[j + (this.StaticGFX[16] * 2048)];
                                }

                                break;
                        }

                        currentmapgfx8Data[(i * 2048) + j] = mapByte; // Upload used gfx data.
                    }
                }
            }
        }

        /// <summary>
        ///     Sets the size of the area.
        /// </summary>
        /// <param name="areaSize"> The area size. </param>
        /// <param name="parentIndex"> The parent area. If null, this area will be its own parent. </param>
        /// <param name="largeIndex"> The position of this area relative to the parent. The top left is the parent. 0 - top left, 1 - top right, 2 - bottom left, 3 bottom right. </param>
        public void SetAreaSize(AreaSizeEnum areaSize, byte? parentIndex = null, byte largeIndex = 0)
        {
            if (parentIndex == null)
            {
                this.ParentID = this.Index;
            }
            else
            {
                this.ParentID = (byte)parentIndex;
            }

            this.AreaSizeQuadrant = largeIndex;
            this.AreaSize = areaSize;
        }

        private unsafe void BuildTiles16Gfx()
        {
            var gfx16Data = (byte*)ZeldaFullEditor.GFX.mapblockset16.ToPointer(); // (byte*)allgfx8Ptr.ToPointer();
            var gfx8Data = (byte*)ZeldaFullEditor.GFX.currentOWgfx16Ptr.ToPointer(); // (byte*)allgfx16Ptr.ToPointer();
            int[] offsets = { 0, 8, 1024, 1032 };
            var yy = 0;
            var xx = 0;

            for (var i = 0; i < Constants.NumberOfMap16Ex; i++) // Number of tiles16 3748?
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

        public enum AreaSizeEnum
        {
            SmallArea = 0,
            LargeArea = 1,
            WideArea = 2,
            TallArea = 3,
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
