﻿namespace ZeldaFullEditor.View.Drawing.Artists
{
	public class ScreenArtist : Artist
	{
		public OverworldScreen MyScreen { get; }

		public override ushort[] Layer1TileMap => MyScreen.Tile16Map;

		public override PointeredImage Layer1Canvas { get; } = new(512, 512);

		public override ushort[] Layer2TileMap { get; } = new ushort[Constants.NumberOfTile16PerScreen];
		public override PointeredImage Layer2Canvas { get; } = new(512, 512);

		public override PointeredImage SpriteCanvas { get; } = new(512, 512);

		public override Bitmap FinalOutput { get; } = new(512, 512);

		public ScreenArtist(OverworldScreen screen) : base()
		{
			MyScreen = screen;
		}

		public void RebuildTileMap()
		{

		}

		public override Tile GetLayer1TileAt(int x, int y) => GetDrawnTileAt(x, y, Layer1TileMap);
		public override Tile GetLayer2TileAt(int x, int y) => GetDrawnTileAt(x, y, Layer2TileMap);

		private static Tile GetDrawnTileAt(int x, int y, ushort[] list)
		{
			var t16index = list[x / 2 + y / 2 * 32];

			var t16 = ZScreamer.ActiveOW.Tile16Sheet.GetTile16At(t16index);

			return (x % 2, y % 2) switch
			{
				(0, 0) => t16.Tile0,
				(1, 0) => t16.Tile1,
				(0, 1) => t16.Tile2,
				(1, 1) => t16.Tile0,
				_ => Tile.Empty // No, actually it does handle every case
			};
		}

		public override void RebuildBitMap()
		{
			var g = Graphics.FromImage(FinalOutput);

			g.SetClip(Constants.ScreenSizedRectangle);
			g.Clear(Color.Black);

			g.DrawScreen(Layer1Canvas.Bitmap, null);
			g.DrawScreen(SpriteCanvas.Bitmap, null);
		}

		public override void DrawSelfToImage(Graphics g)
		{
			g.DrawImage(FinalOutput, 0, 0);
		}

		public override void HardRefresh()
		{
			BackgroundPalette = MyScreen?.ScreenPalette ?? 0;
			SpritePalette = MyScreen?.GetSpritePaletteForGameState(ZScreamer.ActiveOW.GameState) ?? 0;

			BackgroundTileset = MyScreen?.Tileset ?? 0;
			SpriteTileset = MyScreen?.GetSpriteGraphicsForGameState(ZScreamer.ActiveOW.GameState) ?? 0;

			if (HasUnacknowledgedChanges)
			{
				ReloadPalettes();
				RebuildTileMap();
				RebuildBitMap();
			}

			base.HardRefresh();
		}

		public override void ReloadPalettes()
		{
			var copy = ZScreamer.ActivePaletteManager.LoadDungeonPalette(BackgroundPalette);

			var pindex = 0;
			var palettes = Layer1Canvas.Palette;

			for (var y = 0; y < copy.GetLength(1); y++)
			{
				for (var x = 0; x < copy.GetLength(0); x++)
				{
					palettes.Entries[pindex++] = copy[x, y];
				}
			}

			Palettes.FillInHalfPaletteZeros(palettes.Entries, Color.Black);

			Layer1Canvas.Palette = palettes;
			Layer2Canvas.Palette = palettes;
		}

		public override void DrawTileForPreview(Tile t, int indexoff) { }









		public void RebuidMap()
		{
			int x = 0, y = 0;
			foreach (var i in MyScreen.Tile16Map)
			{
				var t = ZScreamer.ActiveOW.Tile16Sheet.GetTile16At(i);

				CopyTile16ToCanvas(t, x, y);

				x++;
				if (x == 16)
				{
					y++;
					x = 0;
				}

			}
		}

		private void CopyTile16ToCanvas(Tile16 t, int x, int y)
		{
			x *= 2;
			y *= 2;
			CopyTile8ToCanvas(t.Tile0, x, y);
			CopyTile8ToCanvas(t.Tile1, x + 1, y);
			CopyTile8ToCanvas(t.Tile2, x, y + 1);
			CopyTile8ToCanvas(t.Tile3, x + 1, y + 1);

		}

		private void CopyTile8ToCanvas(Tile t, int x, int y)
		{

			//		int sourcePtrPos = ((tile & 0x7) << 4) + ((tile / 8) * 2048); //(sourceX * 16) + (sourceY * 128);
			//		byte* sourcePtr = (byte*) sourcebmpPtr.ToPointer();
			//
			//		int destPtrPos = (x + (y * 512));
			//		byte* destPtr = (byte*) destbmpPtr.ToPointer();
			//
			//		for (int ystrip = 0; ystrip < 16; ystrip++)
			//		{
			//			for (int xstrip = 0; xstrip < 16; xstrip++)
			//			{
			//				destPtr[destPtrPos + xstrip + (ystrip * 512)] = sourcePtr[sourcePtrPos + xstrip + (ystrip * 128)];
			//			}
			//		}



			throw new NotImplementedException();
		}

		//	private unsafe void CopyTile(int x, int y, int xx, int yy, int offset, in Tile tile, byte* gfx16Pointer, byte* gfx8Pointer) // map,current
		//	{
		//		int mx = tile.HFlip ? 3 - x : x;
		//		int my = tile.VFlip ? 7 - y : y;
		//
		//		int tx = ((tile.ID & ~0xF) << 5) | ((tile.ID & 0xF) << 2);
		//		var index = xx + yy + offset + (mx << 1) + (my << 7);
		//		var pixel = gfx8Pointer[tx + (y << 6) + x];
		//
		//		gfx16Pointer[index + (tile.HFlipByte ^ 1)] = (byte) ((pixel & 0x0F) | (tile.Palette << 4));
		//		gfx16Pointer[index + tile.HFlipByte] = (byte) ((pixel >> 4) | (tile.Palette << 4));
		//	}
		//
		//	public void ReloadPalettes()
		//	{
		//		int previousPalId = 0;
		//		int previousSprPalId = 0;
		//		if (MapID > 0)
		//		{
		//			previousPalId = ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.overworldMapPalette + ParentMapID - 1];
		//			previousSprPalId = ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.overworldSpritePalette + ParentMapID - 1];
		//		}
		//
		//		if (palette >= 0xA3)
		//		{
		//			palette = 0xA3;
		//		}
		//
		//		byte pal0 = 0;
		//
		//		byte pal1 = ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.overworldMapPaletteGroup + (palette * 4)]; // aux1
		//		byte pal2 = ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.overworldMapPaletteGroup + (palette * 4) + 1]; // aux2
		//		byte pal3 = ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.overworldMapPaletteGroup + (palette * 4) + 2]; // animated
		//
		//		byte pal4 = ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.overworldSpritePaletteGroup + (sprpalette[ZScreamer.ActiveOW.GameState] * 2)]; // spr3
		//		byte pal5 = ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.overworldSpritePaletteGroup + (sprpalette[ZScreamer.ActiveOW.GameState] * 2) + 1]; // spr4
		//
		//		Color[] aux1, aux2, main, animated, hud, spr, spr2;
		//		Color bgr = ZScreamer.ActivePaletteManager.OverworldGrass[0];
		//
		//		if (pal1 == 255)
		//		{
		//			pal1 = ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.overworldMapPaletteGroup + (previousPalId * 4)];
		//		}
		//		if (pal1 != 255)
		//		{
		//			if (pal1 >= 20)
		//			{
		//				pal1 = 19;
		//			}
		//
		//			aux1 = ZScreamer.ActivePaletteManager.OverworldAux[pal1];
		//		}
		//		else
		//		{
		//
		//			aux1 = ZScreamer.ActivePaletteManager.OverworldAux[0];
		//		}
		//
		//		if (pal2 == 255)
		//		{
		//			pal2 = ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.overworldMapPaletteGroup + (previousPalId * 4) + 1];
		//		}
		//		if (pal2 != 255)
		//		{
		//			if (pal2 >= 20)
		//			{
		//				pal2 = 19;
		//			}
		//
		//			aux2 = ZScreamer.ActivePaletteManager.OverworldAux[pal2];
		//		}
		//		else
		//		{
		//			aux2 = ZScreamer.ActivePaletteManager.OverworldAux[0];
		//		}
		//
		//		if (pal3 == 255)
		//		{
		//			pal3 = ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.overworldMapPaletteGroup + (previousPalId * 4) + 2];
		//		}
		//
		//		if (ParentMapID < 0x40)
		//		{
		//			// Default LW Palette
		//			pal0 = 0;
		//			bgr = ZScreamer.ActivePaletteManager.OverworldGrass[0];
		//
		//			// Hardcoded LW DM palettes if we are on one of those maps (might change it to read game code)
		//			if (ParentMapID >= 0x03 && ParentMapID <= 0x07)
		//			{
		//				pal0 = 2;
		//			}
		//			else if (ParentMapID >= 0x0B && ParentMapID <= 0x0E)
		//			{
		//				pal0 = 2;
		//			}
		//		}
		//		else if (ParentMapID < 0x80)
		//		{
		//			// Default DW Palette
		//			pal0 = 1;
		//			bgr = ZScreamer.ActivePaletteManager.OverworldGrass[1];
		//
		//			// Hardcoded DW DM palettes if we are on one of those maps (might change it to read game code)
		//			if (ParentMapID >= 0x43 && ParentMapID <= 0x47)
		//			{
		//				pal0 = 3;
		//			}
		//			else if (ParentMapID >= 0x4B && ParentMapID <= 0x4E)
		//			{
		//				pal0 = 3;
		//			}
		//		}
		//		else if (ParentMapID < Constants.NumberOfOWMaps)
		//		{
		//			// Default SP Palette
		//			pal0 = 0;
		//			bgr = ZScreamer.ActivePaletteManager.OverworldGrass[2];
		//		}
		//
		//		if (ParentMapID == 0x88)
		//		{
		//			pal0 = 4;
		//		}
		//
		//		/*
		//        else if (parent >= 128) //special area like Zora's domain, etc...
		//        {
		//            bgr = ZScreamer.ActivePaletteManager.overworld_GrassPalettes[2];
		//            pal0 = 4;
		//        }
		//        */
		//
		//		if (pal0 != 255)
		//		{
		//			main = ZScreamer.ActivePaletteManager.OverworldMain[pal0];
		//		}
		//		else
		//		{
		//			main = ZScreamer.ActivePaletteManager.OverworldMain[0];
		//		}
		//
		//		if (pal3 >= 14)
		//		{
		//			pal3 = 13;
		//		}
		//		animated = ZScreamer.ActivePaletteManager.OverworldAnimated[pal3];
		//
		//		hud = ZScreamer.ActivePaletteManager.HUD[0];
		//		if (pal4 == 255)
		//		{
		//			pal4 = ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.overworldSpritePaletteGroup + (previousSprPalId * 2)]; // spr3
		//
		//		}
		//
		//		if (pal4 == 255)
		//		{
		//			pal4 = 0;
		//		}
		//		else if (pal4 >= 24)
		//		{
		//			pal4 = 23;
		//		}
		//		spr = ZScreamer.ActivePaletteManager.SpriteAux3[pal4];
		//
		//		if (pal5 == 255)
		//		{
		//			pal5 = ZScreamer.ActiveROM[ZScreamer.ActiveOffsets.overworldSpritePaletteGroup + (previousSprPalId * 2) + 1]; // spr3
		//		}
		//
		//		if (pal5 == 255)
		//		{
		//			pal5 = 0;
		//		}
		//		else if (pal5 >= 24)
		//		{
		//			pal5 = 23;
		//		}
		//		spr2 = ZScreamer.ActivePaletteManager.SpriteAux3[pal5];
		//
		//		SetColorsPalette(ParentMapID, main, animated, aux1, aux2, hud, bgr, spr, spr2);
		//	}
		//
		//	private void SetColorsPalette(int index, Color[] main, Color[] animated, Color[] aux1, Color[] aux2, Color[] hud, Color bgrcolor, Color[] spr, Color[] spr2)
		//	{
		//		// Palettes infos, color 0 of a palette is always transparent (the arrays contains 7 colors width wide)
		//		// There is 16 color per line so 16*Y
		//
		//		// Left side of the palette - Main, Animated
		//		Color[] currentPalette = new Color[Constants.ColorsPerPalette * Constants.NumberOfPalettes];
		//
		//		// Main Palette, Location 0,2 : 35 colors [7x5]
		//		int k = 0;
		//		for (int y = 2 * Constants.ColorsPerPalette; y < 7 * Constants.ColorsPerPalette; y += Constants.ColorsPerPalette)
		//		{
		//			for (int x = 1; x < 8; x++)
		//			{
		//				currentPalette[x + y] = main[k++];
		//			}
		//		}
		//
		//		// Animated Palette, Location 0,7 : 7colors
		//		for (int x = 1; x < 8; x++)
		//		{
		//			currentPalette[(Constants.ColorsPerPalette * 7) + x] = animated[x - 1];
		//		}
		//
		//		// Right side of the palette - Aux1, Aux2 
		//
		//		// Aux1 Palette, Location 8,2 : 21 colors [7x3]
		//		k = 0;
		//		for (int y = 2 * Constants.ColorsPerPalette; y < 5 * Constants.ColorsPerPalette; y += Constants.ColorsPerPalette)
		//		{
		//			for (int x = 9; x < 16; x++)
		//			{
		//				currentPalette[x + y] = aux1[k++];
		//			}
		//		}
		//
		//		// Aux2 Palette, Location 8,5 : 21 colors [7x3]
		//		k = 0;
		//		for (int y = 5 * Constants.ColorsPerPalette; y < 8 * Constants.ColorsPerPalette; y += Constants.ColorsPerPalette)
		//		{
		//			for (int x = 9; x < 16; x++)
		//			{
		//				currentPalette[x + y] = aux2[k++];
		//			}
		//		}
		//
		//		// Hud Palette, Location 0,0 : 32 colors [16x2]
		//		for (int i = 0; i < 32; i++)
		//		{
		//			currentPalette[i] = hud[i];
		//		}
		//
		//		// TODO FOR JARED
		//		// Hardcoded grass color (that might change to become invisible instead)
		//		for (int i = 0; i < (8 * Constants.ColorsPerPalette + 8); i += 8)
		//		{
		//			currentPalette[i] = bgrcolor;
		//		}
		//
		//		// Sprite Palettes
		//		k = 0;
		//		for (int y = 8 * Constants.ColorsPerPalette; y < 9 * Constants.ColorsPerPalette; y += Constants.ColorsPerPalette)
		//		{
		//			for (int x = 1; x < 8; x++)
		//			{
		//				currentPalette[x + y] = ZScreamer.ActivePaletteManager.SpriteAux1[1][k++];
		//			}
		//		}
		//
		//		// Sprite Palettes
		//		k = 0;
		//		for (int y = 8 * Constants.ColorsPerPalette; y < 9 * Constants.ColorsPerPalette; y += Constants.ColorsPerPalette)
		//		{
		//			for (int x = 9; x < 16; x++)
		//			{
		//				currentPalette[x + y] = ZScreamer.ActivePaletteManager.SpriteAux3[0][k++];
		//			}
		//		}
		//
		//		// Sprite Palettes
		//		k = 0;
		//		for (int y = 9 * Constants.ColorsPerPalette; y < 13 * Constants.ColorsPerPalette; y += Constants.ColorsPerPalette)
		//		{
		//			for (int x = 1; x < 16; x++)
		//			{
		//				currentPalette[x + y] = ZScreamer.ActivePaletteManager.SpriteGlobal[0][k++];
		//			}
		//		}
		//
		//		// Sprite Palettes
		//		k = 0;
		//		for (int x = (13 * Constants.ColorsPerPalette) + 1; x < ((13 * Constants.ColorsPerPalette) + 8); x++)
		//		{
		//			currentPalette[x] = spr[k++];
		//		}
		//
		//		// Sprite Palettes
		//		k = 0;
		//		for (int x = (14 * Constants.ColorsPerPalette) + 1; x < ((14 * Constants.ColorsPerPalette) + 8); x++)
		//		{
		//			currentPalette[x] = spr2[k++];
		//		}
		//
		//		// Sprite Palettes
		//		k = 0;
		//		for (int x = (15 * Constants.ColorsPerPalette) + 1; x < 16 * 16; x++)
		//		{
		//			currentPalette[x] = ZScreamer.ActivePaletteManager.PlayerMail[0][k++];
		//		}
		//
		//		try
		//		{
		//			ColorPalette pal = ZScreamer.ActiveGraphicsManager.editort16Bitmap.Palette;
		//			for (int i = 0; i < Constants.ColorsPerPalette * Constants.NumberOfPalettes; i++)
		//			{
		//				pal.Entries[i] = currentPalette[i];
		//				// TODO this is stupid and inefficient
		//				pal.Entries[i & ~0xF] = Color.Transparent;
		//			}
		//
		//			ZScreamer.ActiveGraphicsManager.mapgfx16Bitmap.Palette = pal;
		//			ZScreamer.ActiveGraphicsManager.mapblockset16Bitmap.Palette = pal;
		//
		//			/*
		//            for (int i = 0; i < 256; i++)
		//            {
		//                if (index == 3)
		//                {
		//                    
		//                }
		//                else if (index == 4)
		//                {
		//                    pal.Entries[i & ~0xF] = Color.Transparent;
		//                }
		//            }
		//            */
		//			gfxBitmap.Palette = pal;
		//		}
		//		catch (Exception)
		//		{
		//			// TODO: Add exception message.
		//		}
		//	}
	}
}