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
		public ExitOW selectedExit = null;
		public ExitOW lastselectedExit = null;

		private void Copy_Exit()
		{
			Clipboard.Clear();
			ExitOW ed = lastselectedExit.Copy();
			Clipboard.SetData(Constants.OverworldExitClipboardData, ed);
		}

		private void Paste_Exit()
		{
			ExitOW ae = AddExit(true);
			if (ae != null)
			{
				lastselectedExit = selectedExit = ae;
				mouse_down = true;
			}
		}

		public ExitOW AddExit(bool clipboard = false)
		{
			int found = -1;
			for (int i = 0; i < ZS.OverworldManager.allexits.Length; i++)
			{
				if (ZS.OverworldManager.allexits[i].deleted)
				{
					byte mid = ZS.OverworldManager.allmaps[mapHover + ZS.OverworldManager.worldOffset].parent;
					if (mid == 255)
					{
						mid = (byte) (mapHover + ZS.OverworldManager.worldOffset);
					}

					ZS.OverworldManager.allexits[i].deleted = false;
					ZS.OverworldManager.allexits[i].MapID = mid;
					ZS.OverworldManager.allexits[i].GlobalX = (ushort) ((mxRightclick / 16) * 16);
					ZS.OverworldManager.allexits[i].GlobalY = (ushort) ((myRightclick / 16) * 16);

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
							ZS.OverworldManager.allexits[i].roomId = data.roomId;
							ZS.OverworldManager.allexits[i].doorType1 = data.doorType1;
							ZS.OverworldManager.allexits[i].doorType2 = data.doorType2;
							ZS.OverworldManager.allexits[i].doorXEditor = data.doorXEditor;
							ZS.OverworldManager.allexits[i].doorYEditor = data.doorYEditor;
						}
					}

					ZS.OverworldManager.allexits[i].UpdateMapID(mid, ZS.OverworldManager);

					found = i;

					//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
					break;
				}
			}

			if (found == -1)
			{
				MessageBox.Show("No space available for new exits, delete one first");
				return null;
			}

			return ZS.OverworldManager.allexits[found];
		}

		private void OnMouseDown_Exit(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				for (int i = 0; i < 78; i++)
				{
					ExitOW en = ZS.OverworldManager.allexits[i];
					if (en.MapID >= ZS.OverworldManager.worldOffset && en.MapID < 64 + ZS.OverworldManager.worldOffset)
					{
						if (e.X >= en.GlobalX && e.X < en.GlobalX + 16 && e.Y >= en.GlobalY && e.Y < en.GlobalY + 16)
						{
							if (!mouse_down)
							{
								selectedExit = lastselectedExit = en;
								mouse_down = true;
							}
						}
					}
				}
			}

			if (selectedExit != null)
			{
				//scene.owForm.thumbnailBox.Visible = true;
				//scene.owForm.thumbnailBox.Size = new Size(256, 256);
				int roomId = selectedExit.roomId;
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
		}

		private void Delete_Exit() // Set exit data to 0
		{
			lastselectedExit.GlobalX = 0xFFFF;
			lastselectedExit.GlobalY = 0xFFFF;
			lastselectedExit.MapID = 0;
			lastselectedExit.roomId = 0;
			lastselectedExit.deleted = true;
			//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
		}

		private void OnMouseMove_Exit(MouseEventArgs e)
		{
			if (mouse_down)
			{

				mapHover = (e.X / 16 / 32) + (e.Y / 16 / 32 * 8);

				if (selectedExit != null)
				{
					selectedExit.GlobalX = (ushort) (snapToGrid ? e.X & ~0x7 : e.X);
					selectedExit.GlobalY = (ushort) (snapToGrid ? e.Y & ~0x7 : e.Y);

					byte mid = ZS.OverworldManager.allmaps[mapHover + ZS.OverworldManager.worldOffset].parent;
					if (mid == 255)
					{
						mid = (byte) (mapHover + ZS.OverworldManager.worldOffset);
					}

					selectedExit.UpdateMapID(mid, ZS.OverworldManager);

					//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
				}
			}
		}

		private void OnMouseUp_Exit(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (selectedExit != null)
				{
					lastselectedExit = selectedExit;
					selectedExit = null;
					mouse_down = false;
				}
			}
			// TODO IMouseCollidable
			else if (e.Button == MouseButtons.Right)
			{
				bool clickedon = false;
				ContextMenuStrip menu = new ContextMenuStrip();

				for (int i = 0; i < 78; i++)
				{
					ExitOW en = ZS.OverworldManager.allexits[i];
					if (en.MapID >= ZS.OverworldManager.worldOffset && en.MapID < 64 + ZS.OverworldManager.worldOffset)
					{
						if (e.X >= en.GlobalX && e.X < en.GlobalX + 16 && e.Y >= en.GlobalY && e.Y < en.GlobalY + 16)
						{

							if (lastselectedExit == null)
							{
								menu.Items[0].Enabled = false;
							}
						}
					}
				}

				if (!clickedon)
				{
					mxRightclick = e.X;
					myRightclick = e.Y;
					menu.Items.Add("Insert Exit");
					menu.Items[0].Click += insertExit_Click;
					menu.Show(Cursor.Position);
				}
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
				g.CompositingMode = CompositingMode.SourceOver;
				ExitOW ex = ZS.OverworldManager.allexits[i];

				if (lowEndMode && ex.MapID != ZS.OverworldManager.allmaps[selectedMap].parent)
				{
					continue;
				}

				if (ex.MapID < 64 + ZS.OverworldManager.worldOffset && ex.MapID >= ZS.OverworldManager.worldOffset)
				{
					Brush bgrBrush = Constants.LightGray200Brush;
					Brush fontBrush = Brushes.Black;

					if (lastselectedExit == ex || selectedExit == ex)
					{
						g.CompositingMode = CompositingMode.SourceOver;
						bgrBrush = Constants.MediumGray200Brush;
						g.DrawFilledRectangleWithOutline(ex.GlobalX, ex.GlobalY, 16, 16, Constants.Black200Pen, bgrBrush);
						drawText(g, ex.GlobalX + 4, ex.GlobalY + 4, $"{i:X2}");

						g.DrawRectangle(Pens.LightPink, new Rectangle(ex.ScrollX, ex.ScrollY, 256, 224));
						g.DrawLine(Pens.Blue, ex.CameraX - 8, ex.CameraY, ex.CameraX + 8, ex.CameraY);
						g.DrawLine(Pens.Blue, ex.CameraX, ex.CameraY - 8, ex.CameraX, ex.CameraY + 8);
						g.CompositingMode = CompositingMode.SourceCopy;
						continue;
					}

					g.DrawFilledRectangleWithOutline(ex.GlobalX, ex.GlobalY, 16, 16, Constants.Black200Pen, bgrBrush);
					drawText(g, ex.GlobalX + 4, ex.GlobalY + 4, $"{i:X2}");
				}
			}

			g.CompositingMode = CompositingMode.SourceCopy;
		}

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
