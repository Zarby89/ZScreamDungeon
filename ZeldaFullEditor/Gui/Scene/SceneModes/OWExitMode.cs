using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
	public partial class SceneOW
	{
		private ExitOW selexit, lastexit;

		public ExitOW SelectedExit
		{
			get => selexit;
			set
			{
				selexit = value;
			}
		}

		public ExitOW LastSelectedExit
		{
			get => lastexit;
			set
			{
				if (lastexit == value) return;

				Program.OverworldForm.SetSelectedExit(value);
				lastexit = value;
			}
		}

		public ExitOW AddExit(bool clipboard = false)
		{
			int found = -1;
			for (int i = 0; i < ZS.OverworldManager.allexits.Length; i++)
			{
				if (ZS.OverworldManager.allexits[i].Deleted)
				{
					byte mid = ZS.OverworldManager.allmaps[mapHover + ZS.OverworldManager.WorldOffset].parent;
					if (mid == 255)
					{
						mid = (byte) (mapHover + ZS.OverworldManager.WorldOffset);
					}

					ZS.OverworldManager.allexits[i].Deleted = false;
					ZS.OverworldManager.allexits[i].MapID = mid;
					ZS.OverworldManager.allexits[i].GlobalX = (ushort) (mxRightclick & ~0xF);
					ZS.OverworldManager.allexits[i].GlobalY = (ushort) (myRightclick & ~0xF);

					if (clipboard)
					{
						ExitOW data = (ExitOW) Clipboard.GetData(Constants.OverworldExitClipboardData);
						if (data != null)
						{
							ZS.OverworldManager.allexits[i].CameraX = data.CameraX;
							ZS.OverworldManager.allexits[i].CameraY = data.CameraY;
							ZS.OverworldManager.allexits[i].ScrollX = data.ScrollX;
							ZS.OverworldManager.allexits[i].ScrollY = data.ScrollY;
							ZS.OverworldManager.allexits[i].unk1 = data.unk1;
							ZS.OverworldManager.allexits[i].unk2 = data.unk2;
							ZS.OverworldManager.allexits[i].TargetRoomID = data.TargetRoomID;
							ZS.OverworldManager.allexits[i].doorType1 = data.doorType1;
							ZS.OverworldManager.allexits[i].doorType2 = data.doorType2;
							ZS.OverworldManager.allexits[i].doorXEditor = data.doorXEditor;
							ZS.OverworldManager.allexits[i].doorYEditor = data.doorYEditor;
						}
					}

					ZS.OverworldManager.allexits[i].UpdateMapProperties(ZScreamer.ActiveOW.allmaps[ZS.OverworldManager.allexits[i].MapID].largeMap);

					found = i;
					break;
				}
			}

			if (found == -1)
			{
				MessageBox.Show("No space available for new exits, delete one first.");
				return null;
			}

			return ZS.OverworldManager.allexits[found];
		}

		private void OnMouseDown_Exit(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && !MouseIsDown)
			{
				for (int i = 0; i < 78; i++)
				{
					ExitOW en = ZS.OverworldManager.allexits[i];
					if (en.IsInThisWorld(ZS.OverworldManager.WorldOffset) && en.MouseIsInHitbox(e))
					{
						SelectedExit = LastSelectedExit = en;
						break;
					}
				}
			}

			if (SelectedExit == null) return;
			
			//scene.owForm.thumbnailBox.Visible = true;
			//scene.owForm.thumbnailBox.Size = new Size(256, 256);
			int roomId = SelectedExit.TargetRoomID;
			if (roomId >= Constants.NumberOfRooms)
			{
				//scene.owForm.thumbnailBox.Visible = false;
				return;
			}

			if (Program.DungeonForm.lastRoomID != roomId)
			{
				Program.DungeonForm.previewRoom = ZS.all_rooms[roomId];
				Program.DungeonForm.previewRoom.reloadGfx();
				ZS.GFXManager.loadedPalettes = ZS.GFXManager.LoadDungeonPalette(Program.DungeonForm.previewRoom.Palette);
				Program.DungeonForm.DrawRoom();
				DrawTempExit();
				entrancePreview = true;
				//scene.Refresh();

				if (ZS.UnderworldScene.Room != null)
				{
					ZS.GFXManager.loadedPalettes = ZS.GFXManager.LoadDungeonPalette(ZS.UnderworldScene.Room.Palette);
					ZS.UnderworldScene.Room.reloadGfx();
					ZS.UnderworldScene.TriggerRefresh = true;
				}
			}

			Program.DungeonForm.lastRoomID = roomId;	
		}

		private void Delete_Exit() // Set exit data to 0
		{
			LastSelectedExit.GlobalX = 0xFFFF;
			LastSelectedExit.GlobalY = 0xFFFF;
			LastSelectedExit.MapID = 0;
			LastSelectedExit.TargetRoomID = 0;
			LastSelectedExit.Deleted = true;
		}

		private void OnMouseMove_Exit(MouseEventArgs e)
		{
			if (MouseIsDown)
			{
				MoveDestinationToMouse(SelectedExit, e);
			}
		}

		private void OnMouseUp_Exit(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && SelectedExit != null)
			{
				LastSelectedExit = SelectedExit;
				SelectedExit = null;
				return;
			}

			if (e.Button != MouseButtons.Right) return;
			
			bool clickedon = false;
			ContextMenuStrip menu = new ContextMenuStrip();

			if (!clickedon)
			{
				mxRightclick = e.X;
				myRightclick = e.Y;
				menu.Items.Add("Insert Exit");
				menu.Items[0].Click += insertExit_Click;
				menu.Show(Cursor.Position);
			}
			
		}

		public void insertExit_Click(object sender, EventArgs e)
		{
			AddExit();
		}

		public void exitDelete_Click(object sender, EventArgs e)
		{
			Delete_Exit();
		}

		// TODO move to the side tab
		//ZS.CurrentOWMode = OverworldEditMode.Doors;
		//if (lastselectedExit.doorType1 != 0) // Wooden door
		//{
		//	selectedTile = new ushort[2];
		//	selectedTileSizeX = 2;
		//	selectedTile[0] = 1865;
		//	selectedTile[1] = 1866;
		//
		//}
		//else if ((lastselectedExit.doorType2 & 0x8000) != 0) // Castle door
		//{
		//	selectedTile = new ushort[4];
		//	selectedTileSizeX = 2;
		//	selectedTile[0] = 3510;
		//	selectedTile[1] = 3511;
		//	selectedTile[2] = 3512;
		//	selectedTile[3] = 3513;
		//}
		//else if ((lastselectedExit.doorType2 & 0x7FFF) != 0) // Sanctuary door
		//{
		//	selectedTile = new ushort[2];
		//	selectedTileSizeX = 2;
		//	selectedTile[0] = 3502;
		//	selectedTile[1] = 3503;
		//}

		public void Draw_Exit(Graphics g)
		{
			for (int i = 0; i < 78; i++)
			{
				ExitOW ex = ZS.OverworldManager.allexits[i];

				if (lowEndMode && ex.MapID != ZS.OverworldManager.allmaps[CurrentMap].parent)
				{
					continue;
				}

				if (ex.IsInThisWorld(ZS.OverworldManager.WorldOffset))
				{
					Brush bgrBrush = Constants.LightGray200Brush;

					if (LastSelectedExit == ex || SelectedExit == ex)
					{
						bgrBrush = Constants.MediumGray200Brush;
						g.DrawFilledRectangleWithOutline(ex.SquareHitbox, Constants.Black200Pen, bgrBrush);
						drawText(g, ex.GlobalX + 4, ex.GlobalY + 4, $"{i:X2}");

						g.DrawRectangle(Pens.LightPink, new Rectangle(ex.ScrollX, ex.ScrollY, 256, 224));
						g.DrawLine(Pens.Blue, ex.CameraX - 8, ex.CameraY, ex.CameraX + 8, ex.CameraY);
						g.DrawLine(Pens.Blue, ex.CameraX, ex.CameraY - 8, ex.CameraX, ex.CameraY + 8);
						continue;
					}

					g.DrawFilledRectangleWithOutline(ex.SquareHitbox, Constants.Black200Pen, bgrBrush);
					drawText(g, ex.GlobalX + 4, ex.GlobalY + 4, $"{i:X2}");
				}
			}
		}

		// TODO move this dumb shit to the dungeon room class
		public void DrawTempExit()
		{
			Graphics g = Graphics.FromImage(Program.OverworldForm.tmpPreviewBitmap);
			g.InterpolationMode = InterpolationMode.Bilinear;
			if (Program.DungeonForm.previewRoom.Layer2Mode != Constants.LayerMergeTranslucent || Program.DungeonForm.previewRoom.Layer2Mode != Constants.LayerMergeTransparent ||
			 Program.DungeonForm.previewRoom.Layer2Mode != Constants.LayerMergeOnTop || Program.DungeonForm.previewRoom.Layer2Mode != Constants.LayerMergeOff)
			{
				g.DrawImage(ZS.GFXManager.roomBg2Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);
			}

			g.DrawImage(ZS.GFXManager.roomBg1Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);

			if (Program.DungeonForm.previewRoom.Layer2Mode == Constants.LayerMergeTranslucent || Program.DungeonForm.previewRoom.Layer2Mode == Constants.LayerMergeTransparent)
			{
				float[][] matrixItems ={
					new float[] {1f, 0, 0, 0, 0},
					new float[] {0, 1f, 0, 0, 0},
					new float[] {0, 0, 1f, 0, 0},
					new float[] {0, 0, 0, 0.5f, 0},
					new float[] {0, 0, 0, 0, 1}
				};
				ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

				// Create an ImageAttributes object and set its color matrix.
				ImageAttributes imageAtt = new ImageAttributes();
				imageAtt.SetColorMatrix(
				   colorMatrix,
				   ColorMatrixFlag.Default,
				   ColorAdjustType.Bitmap
				);

				//GFX.roomBg2Bitmap.MakeTransparent(Color.Black);
				g.DrawImage(ZS.GFXManager.roomBg2Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel, imageAtt);
			}
			else if (Program.DungeonForm.previewRoom.Layer2Mode == Constants.LayerMergeOnTop)
			{
				g.DrawImage(ZS.GFXManager.roomBg2Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);
			}

			ZS.UnderworldScene.drawText(g, 0, 0, "ROOM : " + Program.DungeonForm.previewRoom.RoomID.ToString("X2"));
			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.Dispose();
		}
	}
}
