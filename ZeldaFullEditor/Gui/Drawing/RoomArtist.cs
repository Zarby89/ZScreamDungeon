using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ZeldaFullEditor.Data.Underworld;

namespace ZeldaFullEditor
{
	public class RoomArtist : Artist
	{
		public DungeonRoom CurrentRoom { get; set; }

		public override ushort[] Layer1TileMap { get; } = new ushort[Constants.TilesPerUnderworldRoom];
		public override IntPtr Layer1Pointer { get; } = Marshal.AllocHGlobal(512 * 512);
		public override Bitmap Layer1Bitmap { get; }

		public override ushort[] Layer2TileMap { get; } = new ushort[Constants.TilesPerUnderworldRoom];
		public override IntPtr Layer2Pointer { get; } = Marshal.AllocHGlobal(512 * 512);
		public override Bitmap Layer2Bitmap { get; }

		public override IntPtr SpriteCanvasPointer { get; } = Marshal.AllocHGlobal(512 * 512);
		public override Bitmap SpriteCanvas { get; }

		public override Bitmap FinalOutput { get; } = new Bitmap(512, 512);

		private bool drawid;

		public RoomArtist(bool includeRoomID) : base()
		{
			Layer1Bitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, Layer1Pointer);
			Layer2Bitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, Layer2Pointer);
			SpriteCanvas = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, SpriteCanvasPointer);
			drawid = includeRoomID;
		}

		public void RebuildTileMap()
		{
			ZScreamer.ActiveScreamer.TileLister.CurrentFloor1 = CurrentRoom.Floor1Graphics;
			ZScreamer.ActiveScreamer.TileLister.CurrentFloor2 = CurrentRoom.Floor2Graphics;

			var Floor2Shorts = ZScreamer.ActiveScreamer.TileLister[Constants.Floor2ObjectID].ToUnsignedShorts();
			FillTilemapWithFloorShort(Layer2TileMap, Floor2Shorts);

			var Floor1Shorts = ZScreamer.ActiveScreamer.TileLister[Constants.Floor1ObjectID].ToUnsignedShorts();
			FillTilemapWithFloorShort(Layer1TileMap, Floor1Shorts);

			DrawEntireList(ZScreamer.ActiveScreamer.LayoutLister[CurrentRoom.Layout]);
			DrawEntireList(CurrentRoom.Layer1Objects);
			DrawEntireList(CurrentRoom.Layer2Objects);
			DrawEntireList(CurrentRoom.Layer3Objects);
			DrawEntireList(CurrentRoom.DoorsList);

			//if (Layer2Mode != Constants.LayerMergeOff)
			//{
			//	Program.DungeonForm.SetPalettesTransparent();
			//}
			//else
			//{
			//	Program.DungeonForm.SetPalettesBlack();
			//}

			void DrawEntireList(IEnumerable<IDelegatedDraw> list)
			{
				foreach (var o in list)
				{
					o.Draw(this);
				}
			}
		}

		public override void RebuildBitMap()
		{
			if (CurrentRoom == null) return;

			Graphics g = Graphics.FromImage(FinalOutput);

			g.SetClip(Constants.Rect_0_0_512_512);
			g.Clear(Color.Black);

			ImageAttributes draw = null;

			if (CurrentRoom.LayerMerging.Layer2Translucent)
			{
				draw = new ImageAttributes();
				draw.SetColorMatrix(
					new ColorMatrix(TranslucencyMatrix),
					ColorMatrixFlag.Default,
					ColorAdjustType.Bitmap
				);
			}

			Bitmap top;
			Bitmap bottom;

			if (CurrentRoom.LayerMerging.Layer2Visible)
			{
				top = Layer1Bitmap;
				bottom = null;
			}
			else if (CurrentRoom.LayerMerging.Layer2OnTop)
			{
				top = Layer2Bitmap;
				bottom = Layer1Bitmap;
			}
			else
			{
				top = Layer1Bitmap;
				bottom = Layer2Bitmap;
			}

			g.DrawImage(top, Constants.Rect_0_0_512_512, 0, 0, 512, 512, GraphicsUnit.Pixel, draw);
			if (bottom != null)
			{
				g.DrawImage(bottom, Constants.Rect_0_0_512_512, 0, 0, 512, 512, GraphicsUnit.Pixel, draw);
			}
		}

		public override void DrawSelfToImage(Graphics g)
		{
			if (CurrentRoom == null) return;

			g.DrawImage(FinalOutput, 0, 0);

			if (drawid)
			{
				g.DrawText(0, 0, $"ROOM: {CurrentRoom.RoomID:X3}");
			}
		}

		public void SetRoomAndDrawImmediately(DungeonRoom room)
		{
			if (CurrentRoom == room) return;

			CurrentRoom = room;
			HardRefresh();
		}

		public override void HardRefresh()
		{
			BackgroundPalette = CurrentRoom?.Palette ?? 0;
			SpritePalette = CurrentRoom?.Palette ?? 0;

			BackgroundTileset = CurrentRoom?.BackgroundTileset ?? 0;
			SpriteTileset = CurrentRoom?.SpriteTileset ?? 0;

			ReloadPalettes();
			ReloadTileSetGraphics();
			RebuildTileMap();
			RebuildBitMap();
		}

		protected override void ReloadPalettes()
		{
			var copy = ZScreamer.ActivePaletteManager.LoadDungeonPalette(BackgroundPalette);

			int pindex = 0;
			ColorPalette palettes = Layer1Bitmap.Palette;

			for (int y = 0; y < copy.GetLength(1); y++)
			{
				for (int x = 0; x < copy.GetLength(0); x++)
				{
					palettes.Entries[pindex++] = copy[x, y];
				}
			}

			Palettes.FillInHalfPaletteZeros(palettes.Entries, Color.Black);

			ZScreamer.ActiveGraphicsManager.roomBg1Bitmap.Palette = palettes;
			ZScreamer.ActiveGraphicsManager.roomBg2Bitmap.Palette = palettes;
			ZScreamer.ActiveGraphicsManager.roomBgLayoutBitmap.Palette = palettes;
		}

		private void FillTilemapWithFloorShort(ushort[] tilemap, ushort[] floor)
		{
			for (int x = 0; x < 16 * 4; x += 4)
			{
				for (int y = 0; y < (64 * 32 * 2); y += 2 * 64)
				{
					tilemap[x + y] = floor[0];
					tilemap[x + y + 1] = floor[1];
					tilemap[x + y + 2] = floor[2];
					tilemap[x + y + 3] = floor[3];
					tilemap[x + y + 64] = floor[4];
					tilemap[x + y + 65] = floor[5];
					tilemap[x + y + 66] = floor[6];
					tilemap[x + y + 67] = floor[7];
				}
			}
		}

		public unsafe override void ReloadTileSetGraphics()
		{
			byte[] blocks = new byte[16];
			byte bgtiles = CurrentRoom?.BackgroundTileset ?? 0x00;
			byte? entrance = // use entrance graphics only for non previews when using entrance graphics everywhere
				(Program.DungeonForm.visibleEntranceGFX && !drawid)
				? Program.DungeonForm.selectedEntrance?.Blockset
				: CurrentRoom?.PreferredEntrance;
			byte[] entGraphics = ZScreamer.ActiveScreamer.GFXGroups.roomGfx[entrance ?? 0x00];

			for (int i = 0; i < 8; i++)
			{
				blocks[i] = ZScreamer.ActiveScreamer.GFXGroups.mainGfx[bgtiles][i];
				if (i == 6 && entrance != null && entGraphics[i - 3] != 0)
				{
					blocks[i] = entGraphics[i - 3];
				}
			}

			blocks[8] = 115 + 0; // Static Sprites Blocksets (fairy,pot,ect...)
			blocks[9] = 115 + 10;
			blocks[10] = 115 + 6;
			blocks[11] = 115 + 7;
			for (int i = 0; i < 4; i++)
			{
				blocks[12 + i] = (byte) (ZScreamer.ActiveScreamer.GFXGroups.spriteGfx[(CurrentRoom?.SpriteTileset ?? 0x00) + 64][i] + 115);
			} // 12-16 sprites

			byte* newPdata = (byte*) ZScreamer.ActiveGraphicsManager.allgfx16Ptr.ToPointer(); // Turn gfx16 (all 222 of them)
			byte* sheetsData = (byte*) ZScreamer.ActiveGraphicsManager.currentgfx16Ptr.ToPointer(); // Into "room gfx16" 16 of them
			int sheetPos = 0;
			for (int i = 0; i < 16; i++)
			{
				int d = 0;
				int ioff = blocks[i] * 2048;
				while (d < 2048)
				{
					// NOTE LOAD BLOCKSETS SOMEWHERE FIRST
					byte mapByte = newPdata[d + ioff];
					if (i < 4) //removed switch
					{
						mapByte += 0x88;
					} // Last line of 6, first line of 7 ?

					sheetsData[d + sheetPos] = mapByte;
					d++;
				}

				sheetPos += 2048;
			}

			int gfxanimatedPointer = ZScreamer.ActiveScreamer.ROM.Read24(ZScreamer.ActiveScreamer.Offsets.gfx_animated_pointer).SNEStoPC();

			for (int data = 0; data < 512; data++)
			{
				byte mapByte = newPdata[data + (92 * 2048) + (512 * ZScreamer.ActiveGraphicsManager.animated_frame)];
				sheetsData[data + (7 * 2048)] = mapByte;

				mapByte = newPdata[data + (ZScreamer.ActiveScreamer.ROM[gfxanimatedPointer + bgtiles] * 2048) +
					(512 * ZScreamer.ActiveGraphicsManager.animated_frame)];
				sheetsData[data + (7 * 2048) - 512] = mapByte;
			}
		}

		protected unsafe override void DrawBackground(IntPtr pointer, ushort[] buffer)
		{
			byte* ptr = (byte*) pointer.ToPointer();

			var alltilesData = (byte*) LoadedGraphicsPointer.ToPointer();

			for (int y = 0; y < 64 * 64; y += 64)
			{
				for (int x = 0; x < 64; x++)
				{
					DrawTileToBuffer(new Tile(buffer[x + y]), x, y, ptr, alltilesData);
				}
			}
		}

		public override void DrawTileForPreview(Tile t, int indexoff) { }
	}
}
