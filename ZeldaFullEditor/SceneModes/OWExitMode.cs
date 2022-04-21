using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.SceneModes
{
	public class OWExitMode : SceneMode
	{
		public ExitOW selectedExit = null;
		public ExitOW lastselectedExit = null;

		int mxRightclick = 0;
		int myRightclick = 0;

		ExitEditorForm exitPropForm;

		public OWExitMode(ZScreamer zs) : base(zs)
		{
			exitPropForm = new ExitEditorForm(ZS);
		}

		public override void Copy()
		{
			Clipboard.Clear();
			ExitOW ed = lastselectedExit.Copy();
			Clipboard.SetData(Constants.OverworldExitClipboardData, ed);
		}

		public override void Cut()
		{
			Clipboard.Clear();
			ExitOW ed = lastselectedExit.Copy();
			Clipboard.SetData(Constants.OverworldExitClipboardData, ed);
			Delete();
		}

		public override void Paste()
		{
			ExitOW ae = AddExit(true);
			if (ae != null)
			{
				lastselectedExit = selectedExit = ae;
				ZS.OverworldScene.mouse_down = true;
			}
		}

		public override void OnMouseWheel(MouseEventArgs e)
		{

		}

		public ExitOW AddExit(bool clipboard = false)
		{
			int found = -1;
			for (int i = 0; i < ZS.OverworldManager.allexits.Length; i++)
			{
				if (ZS.OverworldManager.allexits[i].deleted)
				{
					byte mid = ZS.OverworldManager.allmaps[ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset].parent;
					if (mid == 255)
					{
						mid = (byte) (ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset);
					}

					ZS.OverworldManager.allexits[i].deleted = false;
					ZS.OverworldManager.allexits[i].MapID = mid;
					ZS.OverworldManager.allexits[i].playerX = (ushort) ((mxRightclick / 16) * 16);
					ZS.OverworldManager.allexits[i].playerY = (ushort) ((myRightclick / 16) * 16);

					if (clipboard)
					{
						ExitOW data = (ExitOW) Clipboard.GetData(Constants.OverworldExitClipboardData);
						if (data != null)
						{
							ZS.OverworldManager.allexits[i].cameraX = data.cameraX;
							ZS.OverworldManager.allexits[i].cameraY = data.cameraY;
							ZS.OverworldManager.allexits[i].xScroll = data.xScroll;
							ZS.OverworldManager.allexits[i].yScroll = data.yScroll;
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

		public override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				for (int i = 0; i < 78; i++)
				{
					ExitOW en = ZS.OverworldManager.allexits[i];
					if (en.MapID >= ZS.OverworldManager.worldOffset && en.MapID < 64 + ZS.OverworldManager.worldOffset)
					{
						if (e.X >= en.playerX && e.X < en.playerX + 16 && e.Y >= en.playerY && e.Y < en.playerY + 16)
						{
							if (!ZS.OverworldScene.mouse_down)
							{
								selectedExit = lastselectedExit = en;
								//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
								ZS.OverworldScene.mouse_down = true;
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

				if (ZS.DungeonForm.lastRoomID != roomId)
				{
					ZS.DungeonForm.previewRoom = ZS.all_rooms[roomId];
					ZS.DungeonForm.previewRoom.reloadGfx();
					ZS.GFXManager.loadedPalettes = ZS.GFXManager.LoadDungeonPalette(ZS.DungeonForm.previewRoom.Palette);
					ZS.DungeonForm.DrawRoom();
					DrawTempExit();
					ZS.OverworldScene.entrancePreview = true;
					//scene.Refresh();

					if (ZS.UnderworldScene.Room != null)
					{
						ZS.GFXManager.loadedPalettes = ZS.GFXManager.LoadDungeonPalette(ZS.UnderworldScene.Room.Palette);
						ZS.UnderworldScene.Room.reloadGfx();
						ZS.UnderworldScene.NeedsRefreshing = true;
					}
				}

				ZS.DungeonForm.lastRoomID = roomId;
			}
		}

		public override void Delete() // Set exit data to 0
		{
			lastselectedExit.playerX = 0xFFFF;
			lastselectedExit.playerY = 0xFFFF;
			lastselectedExit.MapID = 0;
			lastselectedExit.roomId = 0;
			lastselectedExit.deleted = true;
			//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
		}

		public override void OnMouseMove(MouseEventArgs e)
		{
			if (ZS.OverworldScene.mouse_down)
			{

				ZS.OverworldScene.mapHover = (e.X / 16 / 32) + (e.Y / 16 / 32 * 8);

				if (selectedExit != null)
				{
					selectedExit.playerX = (ushort) (ZS.OverworldScene.snapToGrid ? e.X & ~0x7 : e.X);
					selectedExit.playerY = (ushort) (ZS.OverworldScene.snapToGrid ? e.Y & ~0x7 : e.Y);

					byte mid = ZS.OverworldManager.allmaps[ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset].parent;
					if (mid == 255)
					{
						mid = (byte) (ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset);
					}

					selectedExit.UpdateMapID(mid, ZS.OverworldManager);

					//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
				}
			}
		}

		public override void OnMouseUp(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (selectedExit != null)
				{
					lastselectedExit = selectedExit;
					selectedExit = null;
					ZS.OverworldScene.mouse_down = false;
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				bool clickedon = false;
				ContextMenuStrip menu = new ContextMenuStrip();

				for (int i = 0; i < 78; i++)
				{
					ExitOW en = ZS.OverworldManager.allexits[i];
					if (en.MapID >= ZS.OverworldManager.worldOffset && en.MapID < 64 + ZS.OverworldManager.worldOffset)
					{
						if (e.X >= en.playerX && e.X < en.playerX + 16 && e.Y >= en.playerY && e.Y < en.playerY + 16)
						{
							menu.Items.Add("Exit Properties");
							lastselectedExit = en;
							selectedExit = null;
							ZS.OverworldScene.mouse_down = false;

							if (lastselectedExit == null)
							{
								menu.Items[0].Enabled = false;
							}

							clickedon = true;
							menu.Items[0].Click += exitProperty_Click;
							menu.Items.Add("Delete Exit");
							menu.Items[1].Click += exitDelete_Click;
							menu.Show(Cursor.Position);
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
			Delete();
		}

		public void exitProperty_Click(object sender, EventArgs e)
		{
			exitPropForm.SetExit(lastselectedExit);
			DialogResult dr = exitPropForm.ShowDialog();

			if (dr == DialogResult.OK)
			{
				int index = Array.IndexOf(ZS.OverworldManager.allexits, lastselectedExit);
				lastselectedExit = ZS.OverworldManager.allexits[index] = exitPropForm.editingExit;
				ZS.CurrentOWMode = OverworldEditMode.Exits;
				//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
			}
			else if (dr == DialogResult.Yes)
			{
				ZS.CurrentOWMode = OverworldEditMode.Doors;
				if (lastselectedExit.doorType1 != 0) // Wooden door
				{
					ZS.OverworldScene.selectedTile = new ushort[2];
					ZS.OverworldScene.selectedTileSizeX = 2;
					ZS.OverworldScene.selectedTile[0] = 1865;
					ZS.OverworldScene.selectedTile[1] = 1866;

				}
				else if ((lastselectedExit.doorType2 & 0x8000) != 0) // Castle door
				{
					ZS.OverworldScene.selectedTile = new ushort[4];
					ZS.OverworldScene.selectedTileSizeX = 2;
					ZS.OverworldScene.selectedTile[0] = 3510;
					ZS.OverworldScene.selectedTile[1] = 3511;
					ZS.OverworldScene.selectedTile[2] = 3512;
					ZS.OverworldScene.selectedTile[3] = 3513;
				}
				else if ((lastselectedExit.doorType2 & 0x7FFF) != 0) // Sanctuary door
				{
					ZS.OverworldScene.selectedTile = new ushort[2];
					ZS.OverworldScene.selectedTileSizeX = 2;
					ZS.OverworldScene.selectedTile[0] = 3502;
					ZS.OverworldScene.selectedTile[1] = 3503;
				}
			}
			else
			{
				ZS.CurrentOWMode = OverworldEditMode.Exits;
			}

			selectedExit = null;
			ZS.OverworldScene.mouse_down = false;
		}

		public void Draw(Graphics g)
		{
			for (int i = 0; i < 78; i++)
			{
				g.CompositingMode = CompositingMode.SourceOver;
				ExitOW ex = ZS.OverworldManager.allexits[i];

				if (ZS.OverworldScene.lowEndMode && ex.MapID != ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent)
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
						g.DrawFilledRectangleWithOutline(ex.playerX, ex.playerY, 16, 16, Constants.Black200Pen, bgrBrush);
						ZS.OverworldScene.drawText(g, ex.playerX + 4, ex.playerY + 4, $"{i:X2}");

						g.DrawRectangle(Pens.LightPink, new Rectangle(ex.xScroll, ex.yScroll, 256, 224));
						g.DrawLine(Pens.Blue, ex.cameraX - 8, ex.cameraY, ex.cameraX + 8, ex.cameraY);
						g.DrawLine(Pens.Blue, ex.cameraX, ex.cameraY - 8, ex.cameraX, ex.cameraY + 8);
						g.CompositingMode = CompositingMode.SourceCopy;
						continue;
					}

					g.DrawFilledRectangleWithOutline(ex.playerX, ex.playerY, 16, 16, Constants.Black200Pen, bgrBrush);
					ZS.OverworldScene.drawText(g, ex.playerX + 4, ex.playerY + 4, $"{i:X2}");
				}
			}

			g.CompositingMode = CompositingMode.SourceCopy;
		}

		public void DrawTempExit()
		{
			Graphics g = Graphics.FromImage(ZS.OverworldForm.tmpPreviewBitmap);
			g.InterpolationMode = InterpolationMode.Bilinear;
			if (ZS.DungeonForm.previewRoom.Layer2Mode != Constants.LayerMergeTranslucent || ZS.DungeonForm.previewRoom.Layer2Mode != Constants.LayerMergeTransparent ||
			 ZS.DungeonForm.previewRoom.Layer2Mode != Constants.LayerMergeOnTop || ZS.DungeonForm.previewRoom.Layer2Mode != Constants.LayerMergeOff)
			{
				g.DrawImage(ZS.GFXManager.roomBg2Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);
			}

			g.DrawImage(ZS.GFXManager.roomBg1Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);

			if (ZS.DungeonForm.previewRoom.Layer2Mode == Constants.LayerMergeTranslucent || ZS.DungeonForm.previewRoom.Layer2Mode == Constants.LayerMergeTransparent)
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
			else if (ZS.DungeonForm.previewRoom.Layer2Mode == Constants.LayerMergeOnTop)
			{
				g.DrawImage(ZS.GFXManager.roomBg2Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);
			}

			ZS.UnderworldScene.drawText(g, 0, 0, "ROOM : " + ZS.DungeonForm.previewRoom.RoomID.ToString("X2"));
			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.Dispose();
		}

		public override void SelectAll()
		{
			throw new NotImplementedException();
		}
	}
}
