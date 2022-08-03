using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ZeldaFullEditor.Gui;

namespace ZeldaFullEditor
{
	public class OverworldMap // This class should only be used to keep values in, not for loading anything !!
	{
		public byte parent = 0;
		public byte index = 0;
		public byte gfx = 0;
		public byte[] sprgfx = new byte[3];
		public byte palette = 0;
		public byte[] sprpalette = new byte[3];
		public byte[] musics = new byte[4];
		public bool firstLoad = false;
		public short messageID = 0;
		public bool largeMap = false;
		public IntPtr gfxPtr = Marshal.AllocHGlobal(512 * 512); // Needs to be removed
																//public IntPtr blockset16 = Marshal.AllocHGlobal(1048576); // Needs to be removed
																//public Bitmap blocksetBitmap; // Needs to be removed
		public Bitmap gfxBitmap; // Needs to be removed

		public byte[] staticgfx = new byte[16]; // Need to be used to display map and not pre render it!
		Overworld ow;
		public ushort[,] tilesUsed;

		public bool needRefresh = false;

		public OverworldMap(byte index, Overworld ow)
		{
			this.index = index;
			this.ow = ow;
			this.parent = index;
			gfxBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, gfxPtr);

			messageID = (short) ROM.ReadShort(Constants.overworldMessages + (parent * 2));

			if (index != 0x80)
			{
				if (index <= 128)
				{
					largeMap = ROM.DATA[Constants.overworldMapSize + (index & 0x3F)] != 0;
				}
				else
				{
					largeMap = (index == 129 || index == 130 || index == 137 || index == 138);
				}
			}

			if (index < 64)
			{
				sprgfx[0] = ROM.DATA[Constants.overworldSpriteset + parent];
				sprgfx[1] = ROM.DATA[Constants.overworldSpriteset + parent + 64];
				sprgfx[2] = ROM.DATA[Constants.overworldSpriteset + parent + 128];
				gfx = ROM.DATA[Constants.mapGfx + parent];
				palette = ROM.DATA[Constants.overworldMapPalette + parent];
				sprpalette[0] = ROM.DATA[Constants.overworldSpritePalette + parent];
				sprpalette[1] = ROM.DATA[Constants.overworldSpritePalette + parent + 64];
				sprpalette[2] = ROM.DATA[Constants.overworldSpritePalette + parent + 128];
				musics[0] = ROM.DATA[Constants.overworldMusicBegining + parent];
				musics[1] = ROM.DATA[Constants.overworldMusicZelda + parent];
				musics[2] = ROM.DATA[Constants.overworldMusicMasterSword + parent];
				musics[3] = ROM.DATA[Constants.overworldMusicAgahim + parent];
			}
			else if (index < 128)
			{
				sprgfx[0] = ROM.DATA[Constants.overworldSpriteset + parent + 128];
				sprgfx[1] = ROM.DATA[Constants.overworldSpriteset + parent + 128];
				sprgfx[2] = ROM.DATA[Constants.overworldSpriteset + parent + 128];
				gfx = ROM.DATA[Constants.mapGfx + parent];
				palette = ROM.DATA[Constants.overworldMapPalette + parent];
				sprpalette[0] = ROM.DATA[Constants.overworldSpritePalette + parent + 128];
				sprpalette[1] = ROM.DATA[Constants.overworldSpritePalette + parent + 128];
				sprpalette[2] = ROM.DATA[Constants.overworldSpritePalette + parent + 128];

				musics[0] = ROM.DATA[Constants.overworldMusicDW + (parent - 64)];
			}
			else
			{
				// TODO switch statement
				if (index == 0x94)
				{
					parent = 128;
				}
				else if (index == 0x95)
				{
					parent = 03;
				}
				else if (index == 0x96) // Pyramid bg use 0x5B map
				{
					parent = 0x5B;
				}
				else if (index == 0x97) // Pyramid bg use 0x5B map
				{
					parent = 0x00;
				}
				else if (index == 156)
				{
					parent = 67;
				}
				else if (index == 157)
				{
					parent = 0;
				}
				else if (index == 158)
				{
					parent = 0;
				}
				else if (index == 159)
				{
					parent = 44;
				}
				else if (index == 136)
				{
					parent = 136;
				}
				else if (index == 129 || index == 130 || index == 137 || index == 138)
				{
					parent = 129;
				}

				messageID = ROM.DATA[Constants.overworldMessages + parent];

				sprgfx[0] = ROM.DATA[Constants.overworldSpriteset + parent + 128];
				sprgfx[1] = ROM.DATA[Constants.overworldSpriteset + parent + 128];
				sprgfx[2] = ROM.DATA[Constants.overworldSpriteset + parent + 128];
				sprpalette[0] = ROM.DATA[Constants.overworldSpritePalette + parent + 128];
				sprpalette[1] = ROM.DATA[Constants.overworldSpritePalette + parent + 128];
				sprpalette[2] = ROM.DATA[Constants.overworldSpritePalette + parent + 128];

				palette = ROM.DATA[Constants.overworldSpecialPALGroup + parent - 128];
				if ((index >= 0x80 && index <= 0x8A && index != 0x88) || index == 0x94)
				{
					gfx = ROM.DATA[Constants.overworldSpecialGFXGroup + (parent - 128)];
					palette = ROM.DATA[Constants.overworldSpecialPALGroup + 1];
				}
				else if (index == 0x88)
				{
					gfx = 81;
					palette = 0;
				}
				else // Pyramid bg use 0x5B map
				{
					gfx = ROM.DATA[Constants.mapGfx + parent];
					palette = ROM.DATA[Constants.overworldMapPalette + parent];
				}
			}
		}

		public void BuildMap()
		{
			if (largeMap)
			{
				this.parent = ow.mapParent[index];

				if (parent != index)
				{
					//sprgfx[0] = ROM.DATA[Constants.overworldSpriteset + parent];
					//sprgfx[1] = ROM.DATA[Constants.overworldSpriteset + parent + 64];
					//sprgfx[2] = ROM.DATA[Constants.overworldSpriteset + parent + 128];

					if (!firstLoad)
					{
						if (index >= 0x80 && index <= 0x8A && index != 0x88)
						{
							gfx = ROM.DATA[Constants.overworldSpecialGFXGroup + (parent - 128)];
							palette = ROM.DATA[Constants.overworldSpecialPALGroup + 1];
						}
						else if (index == 0x88)
						{
							gfx = 81;
							palette = 0;
						}
						else
						{
							gfx = ROM.DATA[Constants.mapGfx + parent];
							palette = ROM.DATA[Constants.overworldMapPalette + parent];
						}

						firstLoad = true;
					}
				}
			}

			Buildtileset();
			BuildTiles16Gfx(); // Build on GFX.mapgfx16Ptr
			LoadPalette();

			int world = 0;

			if (index < 64)
			{
				tilesUsed = ow.allmapsTilesLW;
			}
			else if (index < 128 && index >= 64)
			{
				tilesUsed = ow.allmapsTilesDW;
				world = 1;
			}
			else
			{
				tilesUsed = ow.allmapsTilesSP;
				world = 2;
			}

			int superY = ((index - (world * 64)) / 8);
			int superX = index - (world * 64) - (superY * 8);

			for (int y = 0; y < 32; y++)
			{
				for (int x = 0; x < 32; x++)
				{
					CopyTile8bpp16((x * 16), (y * 16), tilesUsed[x + (superX * 32), y + (superY * 32)], gfxPtr, GFX.mapblockset16);
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

		public unsafe void CopyTile8bpp16(int x, int y, int tile, IntPtr destbmpPtr, IntPtr sourcebmpPtr)
		{
			int sourceY = (tile / 8);
			int sourceX = (tile) - ((sourceY) * 8);
			int sourcePtrPos = ((tile - ((tile / 8) * 8)) * 16) + ((tile / 8) * 2048); //(sourceX * 16) + (sourceY * 128);
			byte* sourcePtr = (byte*) sourcebmpPtr.ToPointer();

			int destPtrPos = (x + (y * 512));
			byte* destPtr = (byte*) destbmpPtr.ToPointer();

			for (int ystrip = 0; ystrip < 16; ystrip++)
			{
				for (int xstrip = 0; xstrip < 16; xstrip++)
				{
					destPtr[destPtrPos + xstrip + (ystrip * 512)] = sourcePtr[sourcePtrPos + xstrip + (ystrip * 128)];
				}
			}
		}

		public unsafe void CopyTile8bpp16From8(int xP, int yP, int tileID, IntPtr destbmpPtr, IntPtr sourcebmpPtr)
		{
			var gfx16Data = (byte*) destbmpPtr.ToPointer(); //(byte*)allgfx8Ptr.ToPointer();
			var gfx8Data = (byte*) GFX.currentOWgfx16Ptr.ToPointer(); //(byte*)allgfx16Ptr.ToPointer();
			int[] offsets = { 0, 8, 4096, 4104 };

			var tiles = ow.tiles16[tileID];

			for (var tile = 0; tile < 4; tile++)
			{
				TileInfo info = tiles.tilesinfos[tile];
				int offset = offsets[tile];

				for (var y = 0; y < 8; y++)
				{
					for (var x = 0; x < 4; x++)
					{
						CopyTileToMap(x, y, xP, yP, offset, info, gfx16Data, gfx8Data);
					}
				}
			}

		}

		private unsafe void BuildTiles16Gfx()
		{
			//Stopwatch sw = new Stopwatch();
			//sw.Start();
			var gfx16Data = (byte*) GFX.mapblockset16.ToPointer(); //(byte*)allgfx8Ptr.ToPointer();
			var gfx8Data = (byte*) GFX.currentOWgfx16Ptr.ToPointer(); //(byte*)allgfx16Ptr.ToPointer();
			int[] offsets = { 0, 8, 1024, 1032 };
			var yy = 0;
			var xx = 0;

			for (var i = 0; i < ow.tiles16.Count; i++) // Number of tiles16 3748?
			{
				// 8x8 tile draw
				// gfx8 = 4bpp so everyting is /2
				// Var tiles = ow.tiles16[i];

				for (var tile = 0; tile < 4; tile++)
				{
					TileInfo info = ow.tiles16[i].tilesinfos[tile];
					int offset = offsets[tile];

					for (var y = 0; y < 8; y++)
					{
						for (var x = 0; x < 4; x++)
						{
							CopyTile(x, y, xx, yy, offset, info, gfx16Data, gfx8Data);
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

			//sw.Stop();
			//Console.WriteLine("Map Tileset16 Generated in : " + sw.ElapsedMilliseconds);
		}

		private unsafe void CopyTile(int x, int y, int xx, int yy, int offset, TileInfo tile, byte* gfx16Pointer, byte* gfx8Pointer) // map,current
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

			gfx16Pointer[index + r ^ 1] = (byte) ((pixel & 0x0F) + tile.palette * 16);
			gfx16Pointer[index + r] = (byte) (((pixel >> 4) & 0x0F) + tile.palette * 16);
		}

		private unsafe void CopyTileToMap(int x, int y, int xx, int yy, int offset, TileInfo tile, byte* gfx16Pointer, byte* gfx8Pointer) // map,current
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

			gfx16Pointer[index + r ^ 1] = (byte) ((pixel & 0x0F) + tile.palette * 16);
			gfx16Pointer[index + r] = (byte) (((pixel >> 4) & 0x0F) + tile.palette * 16);
		}

		public void LoadPalette()
		{
			int previousPalId = 0;
			int previousSprPalId = 0;
			if (index > 0)
			{
				previousPalId = ROM.DATA[Constants.overworldMapPalette + parent - 1];
				previousSprPalId = ROM.DATA[Constants.overworldSpritePalette + parent - 1];
			}

			if (palette >= 0xA3)
			{
				palette = 0xA3;
			}

			byte pal0 = 0;

			byte pal1 = ROM.DATA[Constants.overworldMapPaletteGroup + (palette * 4)]; // aux1
			byte pal2 = ROM.DATA[Constants.overworldMapPaletteGroup + (palette * 4) + 1]; // aux2
			byte pal3 = ROM.DATA[Constants.overworldMapPaletteGroup + (palette * 4) + 2]; // animated

			byte pal4 = ROM.DATA[Constants.overworldSpritePaletteGroup + (sprpalette[ow.gameState] * 2)]; // spr3
			byte pal5 = ROM.DATA[Constants.overworldSpritePaletteGroup + (sprpalette[ow.gameState] * 2) + 1]; // spr4

			Color[] aux1, aux2, main, animated, hud, spr, spr2;
			Color bgr = Palettes.overworld_GrassPalettes[0];

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

				aux1 = Palettes.overworld_AuxPalettes[pal1];
			}
			else
			{
				aux1 = Palettes.overworld_AuxPalettes[0];
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

				aux2 = Palettes.overworld_AuxPalettes[pal2];
			}
			else
			{
				aux2 = Palettes.overworld_AuxPalettes[0];
			}

			if (pal3 == 255)
			{
				pal3 = ROM.DATA[Constants.overworldMapPaletteGroup + (previousPalId * 4) + 2];
			}

			if (parent < 0x40)
			{
				// Default LW Palette
				pal0 = 0;
				
				if(OverworldEditor.UseAreaSpecificBgColor)
				{
					bgr = Palettes.overworld_BackgroundPalette[parent];
				}
				else
				{
					bgr = Palettes.overworld_GrassPalettes[0];
				}

				// Hardcoded LW DM palettes if we are on one of those maps (might change it to read game code)
				if ((parent >= 0x03 && parent <= 0x07))
				{
					pal0 = 2;
				}
				else if (parent >= 0x0B && parent <= 0x0E)
				{
					pal0 = 2;
				}
			}
			else if (parent >= 0x40 && parent < 0x80)
			{
				// Default DW Palette
				pal0 = 1;
				if (OverworldEditor.UseAreaSpecificBgColor)
				{
					bgr = Palettes.overworld_BackgroundPalette[parent];
				}
				else
				{
					bgr = Palettes.overworld_GrassPalettes[1];
				}

				// Hardcoded DW DM palettes if we are on one of those maps (might change it to read game code)
				if (parent >= 0x43 && parent <= 0x47)
				{
					pal0 = 3;
				}
				else if (parent >= 0x4B && parent <= 0x4E)
				{
					pal0 = 3;
				}
			}
			else if (parent >= 128 && parent < Constants.NumberOfOWMaps)
			{
				// Default SP Palette
				pal0 = 0;

				if (OverworldEditor.UseAreaSpecificBgColor)
				{
					bgr = Palettes.overworld_BackgroundPalette[parent];
				}
				else
				{
					bgr = Palettes.overworld_GrassPalettes[2];
				}
			}

			if (parent == 0x88)
			{
				pal0 = 4;
			}

			/*
            else if (parent >= 128) //special area like Zora's domain, etc...
            {
                bgr = Palettes.overworld_GrassPalettes[2];
                pal0 = 4;
            }
            */

			if (pal0 != 255)
			{
				main = Palettes.overworld_MainPalettes[pal0];
			}
			else
			{
				main = Palettes.overworld_MainPalettes[0];
			}

			if (pal3 >= 14)
			{
				pal3 = 13;
			}
			animated = Palettes.overworld_AnimatedPalettes[(pal3)];

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
			spr = Palettes.spritesAux3_Palettes[pal4];

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
			spr2 = Palettes.spritesAux3_Palettes[pal5];

			SetColorsPalette(parent, main, animated, aux1, aux2, hud, bgr, spr, spr2);
		}

		private void SetColorsPalette(int index, Color[] main, Color[] animated, Color[] aux1, Color[] aux2, Color[] hud, Color bgrcolor, Color[] spr, Color[] spr2)
		{
			// Palettes infos, color 0 of a palette is always transparent (the arrays contains 7 colors width wide)
			// There is 16 color per line so 16*Y

			// Left side of the palette - Main, Animated
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
				currentPalette[(16 * 7) + (x)] = animated[(x - 1)];
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

			// Hardcoded grass color (that might change to become invisible instead)
			for (int i = 0; i < 8; i++)
			{
				currentPalette[(i * 16)] = bgrcolor;
				currentPalette[(i * 16) + 8] = bgrcolor;
			}

			// Sprite Palettes
			k = 0;
			for (int y = 8; y < 9; y++)
			{
				for (int x = 1; x < 8; x++)
				{
					currentPalette[x + (16 * y)] = Palettes.spritesAux1_Palettes[1][k++];
				}
			}

			// Sprite Palettes
			k = 0;
			for (int y = 8; y < 9; y++)
			{
				for (int x = 9; x < 16; x++)
				{
					currentPalette[x + (16 * y)] = Palettes.spritesAux3_Palettes[0][k++];
				}
			}

			// Sprite Palettes
			k = 0;
			for (int y = 9; y < 13; y++)
			{
				for (int x = 1; x < 16; x++)
				{
					currentPalette[x + (16 * y)] = Palettes.globalSprite_Palettes[0][k++];
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
					currentPalette[x + (16 * y)] = Palettes.armors_Palettes[0][k++];
				}
			}

			try
			{
				ColorPalette pal = GFX.editort16Bitmap.Palette;
				for (int i = 0; i < 256; i++)
				{
					pal.Entries[i] = currentPalette[i];
					pal.Entries[(i / 16) * 16] = Color.Transparent;
				}

				GFX.mapgfx16Bitmap.Palette = pal;
				GFX.mapblockset16Bitmap.Palette = pal;

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
				gfxBitmap.Palette = pal;
			}
			catch (Exception)
			{
				// TODO: Add exception message.
			}
		}

		public void Buildtileset()
		{
			int indexWorld = 0x20;
			if (parent < 0x40)
			{
				indexWorld = 0x20;
			}
			else if (parent >= 0x40 && parent < 0x80)
			{
				indexWorld = 0x21;
			}
			else if (parent == 0x88)
			{
				indexWorld = 36;
			}

			// Sprites Blocksets
			staticgfx[8] = 115 + 0;
			staticgfx[9] = 115 + 1;
			staticgfx[10] = 115 + 6;
			staticgfx[11] = 115 + 7;

			for (int i = 0; i < 4; i++)
			{
				staticgfx[12 + i] = (byte) (ROM.DATA[Constants.sprite_blockset_pointer + (sprgfx[ow.gameState] * 4) + i] + 115);
			}

			// Main Blocksets
			for (int i = 0; i < 8; i++)
			{
				byte temp = ROM.DATA[Constants.overworldgfxGroups2 + (indexWorld * 8) + i];
				staticgfx[i] = temp;
			}

			if (ROM.DATA[Constants.overworldgfxGroups + (gfx * 4)] != 0)
			{
				staticgfx[3] = ROM.DATA[Constants.overworldgfxGroups + (gfx * 4)];
			}
			if (ROM.DATA[Constants.overworldgfxGroups + (gfx * 4) + 1] != 0)
			{
				staticgfx[4] = ROM.DATA[Constants.overworldgfxGroups + (gfx * 4) + 1];
			}
			if (ROM.DATA[Constants.overworldgfxGroups + (gfx * 4) + 2] != 0)
			{
				staticgfx[5] = ROM.DATA[Constants.overworldgfxGroups + (gfx * 4) + 2];
			}
			if (ROM.DATA[Constants.overworldgfxGroups + (gfx * 4) + 3] != 0)
			{
				staticgfx[6] = ROM.DATA[Constants.overworldgfxGroups + (gfx * 4) + 3];
			}

			// Hardcoded overworld GFX Values, for death mountain
			if ((parent >= 0x03 && parent <= 0x07) || (parent >= 0x0B && parent <= 0x0E))
			{
				staticgfx[7] = 89;
			}
			else if ((parent >= 0x43 && parent <= 0x47) || (parent >= 0x4B && parent <= 0x4E))
			{
				staticgfx[7] = 89;
			}
			else
			{
				staticgfx[7] = 91;
			}

			/*
			if (parent >= 128 & parent < 148)
			{
				//staticgfx[4] = 71;
				//staticgfx[5] = 72;
			}
			*/

			//Stopwatch sw = new Stopwatch();
			//sw.Start();

			unsafe
			{
				// NEED TO BE EXECUTED AFTER THE TILESET ARE LOADED NOT BEFORE -_-
				byte* currentmapgfx8Data = (byte*) GFX.currentOWgfx16Ptr.ToPointer(); // Loaded gfx for the current map (empty at this point)
				byte* allgfxData = (byte*) GFX.allgfx16Ptr.ToPointer(); // All gfx of the game pack of 2048 bytes (4bpp)
				for (int i = 0; i < 16; i++)
				{
					for (int j = 0; j < 2048; j++)
					{
						byte mapByte = allgfxData[j + (staticgfx[i] * 2048)];
						switch (i)
						{
							case 0:
							case 3:
							case 4:
							case 5:
								mapByte += 0x88;
								break;
						}

						currentmapgfx8Data[(i * 2048) + j] = mapByte; // Upload used gfx data
					}
				}
			}

			//sw.Stop();
			//Console.WriteLine("maps gfx loop : " + sw.ElapsedMilliseconds.ToString());
		}
	}
}
