using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using ZeldaFullEditor.Gui;

namespace ZeldaFullEditor.SceneModes
{
	public class OWEntranceMode : SceneMode
	{
		public EntranceOWEditor selectedEntrance = null;
		public EntranceOWEditor lastselectedEntrance = null;
		bool isLeftPress = false;

		public OWEntranceMode(ZScreamer zs) : base(zs)
		{

		}

		public override void OnMouseWheel(MouseEventArgs e)
		{

		}

		public override void Copy()
		{
			Clipboard.Clear();
			EntranceOWEditor ed = lastselectedEntrance.Copy();
			Clipboard.SetData(Constants.OverworldEntranceClipboardData, ed);
		}

		public override void Cut()
		{
			Clipboard.Clear();
			EntranceOWEditor ed = lastselectedEntrance.Copy();
			Clipboard.SetData(Constants.OverworldEntranceClipboardData, ed);
			Delete();

		}

		public override void Paste()
		{
			selectedEntrance = AddEntrance(true);
			if (selectedEntrance != null)
			{
				lastselectedEntrance = selectedEntrance;
				ZS.OverworldScene.mouse_down = true;
				isLeftPress = true;
				//scene.Invalidate(new Rectangle(ZS.DungeonForm.panel5.HorizontalScroll.Value, ZS.DungeonForm.panel5.VerticalScroll.Value, ZS.DungeonForm.panel5.Width, ZS.DungeonForm.panel5.Height));
			}
		}

		public EntranceOWEditor AddEntrance(bool clipboard = false)
		{
			byte entranceID = 0;
			bool ishole = false;
			if (clipboard)
			{
				EntranceOWEditor data = (EntranceOWEditor) Clipboard.GetData(Constants.OverworldEntranceClipboardData);
				if (data != null)
				{
					entranceID = data.entranceId;
					ishole = data.isHole;
				}
			}

			int found = -1;
			if (ishole)
			{
				for (int i = 0; i < ZS.OverworldManager.allholes.Length; i++)
				{
					if (ZS.OverworldManager.allholes[i].deleted)
					{
						byte mid = ZS.OverworldManager.allmaps[ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset].parent;
						if (mid == 255)
						{
							mid = (byte) (ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset);
						}
						ZS.OverworldManager.allholes[i].deleted = false;
						ZS.OverworldManager.allholes[i].MapID = mid;
						ZS.OverworldManager.allholes[i].x = (ushort) ((mxRightclick / 16) * 16);
						ZS.OverworldManager.allholes[i].y = (ushort) ((myRightclick / 16) * 16);
						ZS.OverworldManager.allholes[i].entranceId = entranceID;

						ZS.OverworldManager.allholes[i].UpdateMapID(mid);

						found = i;
						selectedEntrance = ZS.OverworldManager.allholes[i];
						ZS.OverworldScene.mouse_down = true;
						isLeftPress = true;

						//scene.Invalidate(new Rectangle(ZS.DungeonForm.panel5.HorizontalScroll.Value, ZS.DungeonForm.panel5.VerticalScroll.Value, ZS.DungeonForm.panel5.Width, ZS.DungeonForm.panel5.Height));
						break;
					}
				}
			}
			else
			{
				for (int i = 0; i < ZS.OverworldManager.allentrances.Length; i++)
				{
					if (ZS.OverworldManager.allentrances[i].deleted)
					{
						byte mid = ZS.OverworldManager.allmaps[ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset].parent;
						if (mid == 255)
						{
							mid = (byte) (ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset);
						}
						ZS.OverworldManager.allentrances[i].deleted = false;
						ZS.OverworldManager.allentrances[i].MapID = mid;
						ZS.OverworldManager.allentrances[i].x = (ushort) ((mxRightclick / 16) * 16);
						ZS.OverworldManager.allentrances[i].y = (ushort) ((myRightclick / 16) * 16);
						ZS.OverworldManager.allentrances[i].entranceId = entranceID;

						ZS.OverworldManager.allentrances[i].UpdateMapID(mid);

						found = i;
						selectedEntrance = ZS.OverworldManager.allentrances[i];
						ZS.OverworldScene.mouse_down = true;
						isLeftPress = true;

						//scene.Invalidate(new Rectangle(ZS.DungeonForm.panel5.HorizontalScroll.Value, ZS.DungeonForm.panel5.VerticalScroll.Value, ZS.DungeonForm.panel5.Width, ZS.DungeonForm.panel5.Height));
						break;
					}
				}
			}

			if (found == -1)
			{
				if (ishole)
				{
					MessageBox.Show("No space available for new hole, delete one first");
				}
				else
				{
					MessageBox.Show("No space available for new entrance, delete one first");
				}

				return null;
			}

			return ZS.OverworldManager.allentrances[found];
		}

		public override void OnMouseDown(MouseEventArgs e)
		{
			isLeftPress = e.Button == MouseButtons.Left;

			for (int i = 0; i < ZS.OverworldManager.allentrances.Length; i++)
			{
				EntranceOWEditor en = ZS.OverworldManager.allentrances[i];
				if (en.MapID >= ZS.OverworldManager.worldOffset && en.MapID < 64 + ZS.OverworldManager.worldOffset)
				{
					if (e.X >= en.x && e.X < en.x + 16 && e.Y >= en.y && e.Y < en.y + 16)
					{
						if (!ZS.OverworldScene.mouse_down)
						{
							if (e.Button == MouseButtons.Left)
							{
								selectedEntrance = lastselectedEntrance = en;
								ZS.OverworldScene.mouse_down = true;
							}
							else if (e.Button == MouseButtons.Right)
							{
								lastselectedEntrance = en;
								ZS.OverworldScene.mouse_down = true;
								mxRightclick = e.X;
								myRightclick = e.Y;
							}
						}
					}
				}
			}

			for (int i = 0; i < ZS.OverworldManager.allholes.Length; i++)
			{
				EntranceOWEditor en = ZS.OverworldManager.allholes[i];
				if (en.MapID >= ZS.OverworldManager.worldOffset && en.MapID < 64 + ZS.OverworldManager.worldOffset)
				{
					if (e.X >= en.x && e.X < en.x + 16 && e.Y >= en.y && e.Y < en.y + 16)
					{
						if (!ZS.OverworldScene.mouse_down)
						{
							if (e.Button == MouseButtons.Left)
							{
								selectedEntrance = lastselectedEntrance = en;
								ZS.OverworldScene.mouse_down = true;
							}
							else if (e.Button == MouseButtons.Right)
							{
								lastselectedEntrance = en;
								ZS.OverworldScene.mouse_down = true;
								mxRightclick = e.X;
								myRightclick = e.Y;
							}
						}
					}
				}
			}

			if (selectedEntrance != null)
			{
				//ZS.OverworldManagerForm.thumbnailBox.Visible = true;
				//ZS.OverworldManagerForm.thumbnailBox.Size = new Size(256, 256);

				int roomId = ZS.entrances[selectedEntrance.entranceId].RoomID;
				if (roomId >= Constants.NumberOfRooms)
				{
					//ZS.OverworldManagerForm.thumbnailBox.Visible = false;
					return;
				}

				if (ZS.DungeonForm.lastRoomID != roomId)
				{
					ZS.DungeonForm.previewRoom = ZS.all_rooms[roomId];
					ZS.DungeonForm.previewRoom.reloadGfx();
					ZS.GFXManager.loadedPalettes = ZS.GFXManager.LoadDungeonPalette(ZS.DungeonForm.previewRoom.Palette);
					ZS.DungeonForm.DrawRoom();
					DrawTempEntrance();
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

		public void DrawTempEntrance()
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

				imageAtt.SetColorMatrix
				(
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

		public void OnMouseDoubleClick(MouseEventArgs e)
		{
			for (int i = 0; i < ZS.OverworldManager.allentrances.Length; i++)
			{
				EntranceOWEditor en = ZS.OverworldManager.allentrances[i];
				if (en.MapID >= ZS.OverworldManager.worldOffset && en.MapID < 64 + ZS.OverworldManager.worldOffset)
				{
					if (e.X >= en.x && e.X < en.x + 16 && e.Y >= en.y && e.Y < en.y + 16)
					{
						if (e.Button == MouseButtons.Left)
						{
							TreeNode[] treeNodes = ZS.DungeonForm.entrancetreeView.Nodes[0].Nodes
									.Cast<TreeNode>()
									.Where(r => (int) (r.Tag) == en.entranceId)
									.ToArray();

							if (treeNodes.Length != 0)
							{
								ZS.DungeonForm.entrancetreeView.SelectedNode = treeNodes[0];
							}

							ZS.DungeonForm.addRoomTab(ZS.entrances[en.entranceId].RoomID);
							ZS.DungeonForm.editorsTabControl.SelectedIndex = 0;
							//ZS.DungeonForm.dungeonButton_Click(ZS.DungeonForm.dungeonButton, null);
						}
					}
				}
			}

			for (int i = 0; i < ZS.OverworldManager.allholes.Length; i++)
			{
				EntranceOWEditor en = ZS.OverworldManager.allholes[i];
				if (en.MapID >= ZS.OverworldManager.worldOffset && en.MapID < 64 + ZS.OverworldManager.worldOffset)
				{
					if (e.X >= en.x && e.X < en.x + 16 && e.Y >= en.y && e.Y < en.y + 16)
					{
						if (!ZS.OverworldScene.mouse_down)
						{
							if (e.Button == MouseButtons.Left)
							{
								TreeNode[] treeNodes = ZS.DungeonForm.entrancetreeView.Nodes[0].Nodes
										.Cast<TreeNode>()
										.Where(r => (int) (r.Tag) == en.entranceId)
										.ToArray();

								if (treeNodes.Length != 0)
								{
									ZS.DungeonForm.entrancetreeView.SelectedNode = treeNodes[0];
								}

								ZS.DungeonForm.addRoomTab(ZS.entrances[en.entranceId].RoomID);
								ZS.DungeonForm.editorsTabControl.SelectedIndex = 0;
							}
						}
					}
				}
			}
		}

		public override void Delete()
		{
			lastselectedEntrance.x = 0xFFFF;
			lastselectedEntrance.y = 0xFFFF;
			lastselectedEntrance.MapID = 0;
			lastselectedEntrance.mapPos = 0xFFFF;
			lastselectedEntrance.entranceId = 0;
			lastselectedEntrance.deleted = true;

			//scene.Invalidate(new Rectangle(ZS.DungeonForm.panel5.HorizontalScroll.Value, ZS.DungeonForm.panel5.VerticalScroll.Value, ZS.DungeonForm.panel5.Width, ZS.DungeonForm.panel5.Height));
		}

		public override void OnMouseMove(MouseEventArgs e)
		{

			ZS.OverworldScene.mapHover = (e.X / 16 / 32) + (e.Y / 16 / 32 * 8);

			if (selectedEntrance != null)
			{
				if (isLeftPress && ZS.OverworldScene.mouse_down)
				{
					selectedEntrance.x = e.X & ~0x0F;
					selectedEntrance.y = e.Y & ~0x0F;
				}

				//scene.Invalidate(new Rectangle(ZS.DungeonForm.panel5.HorizontalScroll.Value, ZS.DungeonForm.panel5.VerticalScroll.Value, ZS.DungeonForm.panel5.Width, ZS.DungeonForm.panel5.Height));
			}
		}


		int mxRightclick = 0;
		int myRightclick = 0;
		public override void OnMouseUp(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (selectedEntrance != null)
				{
					byte mid = ZS.OverworldManager.allmaps[ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset].parent;
					if (mid == 255)
					{
						mid = (byte) (ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset);
					}

					selectedEntrance.UpdateMapID(mid);
					selectedEntrance = null;
					ZS.OverworldScene.mouse_down = false;
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				ContextMenuStrip menu = new ContextMenuStrip();
				for (int i = 0; i < ZS.OverworldManager.allentrances.Length; i++)
				{
					EntranceOWEditor en = ZS.OverworldManager.allentrances[i];
					if (en.MapID >= ZS.OverworldManager.worldOffset && en.MapID < 64 + ZS.OverworldManager.worldOffset)
					{
						if (e.X >= en.x && e.X < en.x + 16 && e.Y >= en.y && e.Y < en.y + 16)
						{
							menu.Items.Add("Add Entrance");
							menu.Items.Add("Entrance Properties");
							menu.Items.Add("Delete Entrance");
							lastselectedEntrance = en;
							selectedEntrance = null;
							ZS.OverworldScene.mouse_down = false;

							if (lastselectedEntrance == null)
							{
								menu.Items[1].Enabled = false;
								menu.Items[2].Enabled = false;
							}

							menu.Items[0].Click += entranceAdd_Click;
							menu.Items[1].Click += entranceProperty_Click;
							menu.Items[2].Click += Delete_Click;
							menu.Show(Cursor.Position);
							return;
						}
					}
				}

				for (int i = 0; i < ZS.OverworldManager.allholes.Length; i++)
				{

					EntranceOWEditor en = ZS.OverworldManager.allholes[i];
					if (en.MapID >= ZS.OverworldManager.worldOffset && en.MapID < 64 + ZS.OverworldManager.worldOffset)
					{
						if (e.X >= en.x && e.X < en.x + 16 && e.Y >= en.y && e.Y < en.y + 16)
						{
							menu.Items.Add("Add Entrance");
							menu.Items.Add("Entrance Properties");
							menu.Items.Add("Delete Entrance");
							lastselectedEntrance = en;
							selectedEntrance = null;
							ZS.OverworldScene.mouse_down = false;

							if (lastselectedEntrance == null)
							{
								menu.Items[1].Enabled = false;
								menu.Items[2].Enabled = false;
							}

							menu.Items[0].Click += entranceAdd_Click;
							menu.Items[1].Click += entranceProperty_Click;
							menu.Items[2].Click += Delete_Click;
							menu.Show(Cursor.Position);
							return;
						}
					}
				}

				menu.Items.Add("Add Entrance");
				selectedEntrance = null;
				ZS.OverworldScene.mouse_down = false;
				menu.Items[0].Click += entranceAdd_Click;

				menu.Show(Cursor.Position);
				return;
			}
		}

		private void entranceAdd_Click(object sender, EventArgs e)
		{
			AddEntrance();
		}

		private void insertEntrance_Click(object sender, EventArgs e)
		{
			bool found = false;
			for (int i = 0; i < ZS.OverworldManager.allentrances.Length; i++)
			{
				if (ZS.OverworldManager.allentrances[i].deleted)
				{
					byte mid = ZS.OverworldManager.allmaps[ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset].parent;
					if (mid == 255)
					{
						mid = (byte) (ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset);
					}
					ZS.OverworldManager.allentrances[i].deleted = false;
					ZS.OverworldManager.allentrances[i].MapID = mid;
					ZS.OverworldManager.allentrances[i].x = mxRightclick & ~0xF;
					ZS.OverworldManager.allentrances[i].y = myRightclick & ~0xF;
					ZS.OverworldManager.allentrances[i].UpdateMapID(mid);
					found = true;
					//scene.Invalidate(new Rectangle(ZS.DungeonForm.panel5.HorizontalScroll.Value, ZS.DungeonForm.panel5.VerticalScroll.Value, ZS.DungeonForm.panel5.Width, ZS.DungeonForm.panel5.Height));
					break;
				}
			}

			if (!found)
			{
				MessageBox.Show("No space available for new entrances, delete one first");
			}
		}

		private void Delete_Click(object sender, EventArgs e)
		{
			Delete();
		}

		private void entranceProperty_Click(object sender, EventArgs e)
		{
			EntranceForm ef = new EntranceForm(ZS);
			ef.entranceId = lastselectedEntrance.entranceId;
			ef.mapId = lastselectedEntrance.MapID;
			ef.mapPos = lastselectedEntrance.mapPos;
			ef.x = lastselectedEntrance.x;
			ef.y = lastselectedEntrance.y;
			ef.isHole = lastselectedEntrance.isHole;

			if (ef.ShowDialog() == DialogResult.OK)
			{
				lastselectedEntrance.entranceId = ef.entranceId;
				lastselectedEntrance.MapID = (byte) ef.mapId;
				lastselectedEntrance.x = ef.x;
				lastselectedEntrance.y = ef.y;

			}
		}

		public void Draw(Graphics g)
		{
			Brush bgrBrush = Constants.Goldenrod200Brush;
			g.CompositingMode = CompositingMode.SourceOver;

			for (int i = 0; i < ZS.OverworldManager.allentrances.Length; i++)
			{
				EntranceOWEditor e = ZS.OverworldManager.allentrances[i];
				if (ZS.OverworldScene.lowEndMode && e.MapID != ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent)
				{
					continue;
				}

				if (e.MapID < 64 + ZS.OverworldManager.worldOffset && e.MapID >= ZS.OverworldManager.worldOffset)
				{
					if (selectedEntrance != null)
					{
						if (e == selectedEntrance)
						{
							bgrBrush = Constants.Azure200Brush;
							ZS.OverworldScene.drawText(g, e.x - 1, e.y + 26, "map : " + e.MapID.ToString());
							ZS.OverworldScene.drawText(g, e.x - 1, e.y + 36, "entrance : " + e.entranceId.ToString());
							ZS.OverworldScene.drawText(g, e.x - 1, e.y + 46, "mpos : " + e.mapPos.ToString());
						}
						else
						{
							bgrBrush = Constants.Goldenrod200Brush;
						}
					}

					g.DrawFilledRectangleWithOutline(e.x, e.y, 16, 16, Constants.Black200Pen, bgrBrush);
					ZS.OverworldScene.drawText(g, e.x - 1, e.y + 9, e.entranceId.ToString("X2") + " - " + ZS.all_rooms[ZS.entrances[e.entranceId].RoomID].Name);
				}
			}

			for (int i = 0; i < ZS.OverworldManager.allholes.Length; i++)
			{
				EntranceOWEditor e = ZS.OverworldManager.allholes[i];
				if (e.MapID != ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent)
				{
					continue;
				}

				bgrBrush = Constants.Charcoal200Brush;
				if (e.MapID < 64 + ZS.OverworldManager.worldOffset && e.MapID >= ZS.OverworldManager.worldOffset)
				{
					if (selectedEntrance != null)
					{
						if (e == selectedEntrance)
						{
							bgrBrush = Constants.Azure200Brush;
						}
					}

					g.FillRectangle(bgrBrush, new Rectangle(e.x, e.y, 16, 16));
					g.DrawRectangle(Constants.Black200Pen, new Rectangle(e.x, e.y, 16, 16));
					ZS.OverworldScene.drawText(g, e.x - 1, e.y + 9, e.entranceId.ToString("X2") + " - " + ZS.all_rooms[ZS.entrances[e.entranceId].RoomID].Name);
				}
			}

			g.CompositingMode = CompositingMode.SourceCopy;
		}

		public override void SelectAll()
		{
			throw new NotImplementedException();
		}
	}
}
