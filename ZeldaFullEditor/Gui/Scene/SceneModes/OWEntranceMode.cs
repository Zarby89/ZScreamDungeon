using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using ZeldaFullEditor.Gui;

namespace ZeldaFullEditor
{
	public partial class SceneOW
	{
		private EntranceOWEditor selentrance, lastentrance;

		public EntranceOWEditor SelectedEntrance
		{
			get => selentrance;
			set
			{
				selentrance = value;
			}
		}

		public EntranceOWEditor LastSelectedEntrance
		{
			get => lastentrance;
			set
			{
				if (lastentrance == value) return;

				Program.OverworldForm.SetSelectedEntrance(lastentrance);
				lastentrance = value;
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
					entranceID = data.TargetEntranceID;
					ishole = data.IsPitEntrance;
				}
			}

			int found = -1;
			if (ishole)
			{
				for (int i = 0; i < ZS.OverworldManager.allholes.Length; i++)
				{
					if (ZS.OverworldManager.allholes[i].deleted)
					{
						byte mid = ZS.OverworldManager.allmaps[mapHover + ZS.OverworldManager.WorldOffset].parent;
						if (mid == 255)
						{
							mid = (byte) (mapHover + ZS.OverworldManager.WorldOffset);
						}
						ZS.OverworldManager.allholes[i].deleted = false;
						ZS.OverworldManager.allholes[i].MapID = mid;
						ZS.OverworldManager.allholes[i].GlobalX = (ushort) (mxRightclick & ~0x0F);
						ZS.OverworldManager.allholes[i].GlobalY = (ushort) (myRightclick & ~0x0F);
						ZS.OverworldManager.allholes[i].TargetEntranceID = entranceID;

						found = i;
						SelectedEntrance = ZS.OverworldManager.allholes[i];
						MouseIsDown = true;
						isLeftPress = true;

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
						byte mid = ZS.OverworldManager.allmaps[mapHover + ZS.OverworldManager.WorldOffset].parent;
						if (mid == 255)
						{
							mid = (byte) (mapHover + ZS.OverworldManager.WorldOffset);
						}
						ZS.OverworldManager.allentrances[i].deleted = false;
						ZS.OverworldManager.allentrances[i].MapID = mid;
						ZS.OverworldManager.allentrances[i].GlobalX = (ushort) (mxRightclick & ~0x0F);
						ZS.OverworldManager.allentrances[i].GlobalY = (ushort) (myRightclick & ~0x0F);
						ZS.OverworldManager.allentrances[i].TargetEntranceID = entranceID;

						found = i;
						SelectedEntrance = ZS.OverworldManager.allentrances[i];
						MouseIsDown = true;
						isLeftPress = true;

						break;
					}
				}
			}

			if (found == -1)
			{
				if (ishole)
				{
					throw new ZeldaException("No space available for new hole, delete one first");
				}
				else
				{
					throw new ZeldaException("No space available for new entrance, delete one first");
				}
			}

			return ZS.OverworldManager.allentrances[found];
		}

		// TODO fucking mess it is; need a delegate to loop everything probably
		private void OnMouseDown_Entrance(MouseEventArgs e)
		{
			if (MouseIsDown) return;
			isLeftPress = e.Button == MouseButtons.Left;

			for (int i = 0; i < ZS.OverworldManager.allentrances.Length; i++)
			{
				EntranceOWEditor en = ZS.OverworldManager.allentrances[i];
				if (en.IsInThisWorld(ZS.OverworldManager.WorldOffset) && en.MouseIsInHitbox(e))
				{
					if (e.Button == MouseButtons.Left)
					{
						SelectedEntrance = LastSelectedEntrance = en;
						
					}
					else if (e.Button == MouseButtons.Right)
					{
						LastSelectedEntrance = en;
						mxRightclick = e.X;
						myRightclick = e.Y;
					}
				}
			}

			for (int i = 0; i < ZS.OverworldManager.allholes.Length; i++)
			{
				EntranceOWEditor en = ZS.OverworldManager.allholes[i];
				if (en.IsInThisWorld(ZS.OverworldManager.WorldOffset) && en.MouseIsInHitbox(e))
				{
					if (e.Button == MouseButtons.Left)
					{
						SelectedEntrance = LastSelectedEntrance = en;
					}
					else if (e.Button == MouseButtons.Right)
					{
						LastSelectedEntrance = en;
						mxRightclick = e.X;
						myRightclick = e.Y;
					}
				}
			}

			if (SelectedEntrance == null) return;
			
			//ZS.OverworldManagerForm.thumbnailBox.Visible = true;
			//ZS.OverworldManagerForm.thumbnailBox.Size = new Size(256, 256);

			int roomId = ZS.entrances[SelectedEntrance.TargetEntranceID].RoomID;
			if (roomId >= Constants.NumberOfRooms)
			{
				//ZS.OverworldManagerForm.thumbnailBox.Visible = false;
				return;
			}

			if (Program.DungeonForm.lastRoomID != roomId)
			{
				Program.DungeonForm.previewRoom = ZS.all_rooms[roomId];
				Program.DungeonForm.previewRoom.reloadGfx();
				ZS.GFXManager.loadedPalettes = ZS.GFXManager.LoadDungeonPalette(Program.DungeonForm.previewRoom.Palette);
				Program.DungeonForm.DrawRoom();
				DrawTempEntrance();
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

		public void DrawTempEntrance()
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

				imageAtt.SetColorMatrix
				(
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

		public void OnMouseDoubleClick_Entrance(MouseEventArgs e)
		{
			for (int i = 0; i < ZS.OverworldManager.allentrances.Length; i++)
			{
				EntranceOWEditor en = ZS.OverworldManager.allentrances[i];
				if (en.IsInThisWorld(ZS.OverworldManager.WorldOffset) && en.MouseIsInHitbox(e))
				{
					if (e.Button == MouseButtons.Left)
					{
						TreeNode[] treeNodes = Program.DungeonForm.entrancetreeView.Nodes[0].Nodes
								.Cast<TreeNode>()
								.Where(r => (int) (r.Tag) == en.TargetEntranceID)
								.ToArray();

						if (treeNodes.Length != 0)
						{
							Program.DungeonForm.entrancetreeView.SelectedNode = treeNodes[0];
						}

						Program.DungeonForm.addRoomTab(ZS.entrances[en.TargetEntranceID].RoomID);
						Program.DungeonForm.editorsTabControl.SelectedIndex = 0;
						//Program.DungeonForm.dungeonButton_Click(Program.DungeonForm.dungeonButton, null);
					}
				}
			}

			for (int i = 0; i < ZS.OverworldManager.allholes.Length; i++)
			{
				EntranceOWEditor en = ZS.OverworldManager.allholes[i];
				if (en.IsInThisWorld(ZS.OverworldManager.WorldOffset) && en.MouseIsInHitbox(e))
				{
					if (!MouseIsDown)
					{
						if (e.Button == MouseButtons.Left)
						{
							TreeNode[] treeNodes = Program.DungeonForm.entrancetreeView.Nodes[0].Nodes
									.Cast<TreeNode>()
									.Where(r => (int) (r.Tag) == en.TargetEntranceID)
									.ToArray();

							if (treeNodes.Length != 0)
							{
								Program.DungeonForm.entrancetreeView.SelectedNode = treeNodes[0];
							}

							Program.DungeonForm.addRoomTab(ZS.entrances[en.TargetEntranceID].RoomID);
							Program.DungeonForm.editorsTabControl.SelectedIndex = 0;
						}
					}
				}
			}
		}

		private void Delete_Entrance()
		{
			LastSelectedEntrance.GlobalX = 0xFFFF;
			LastSelectedEntrance.GlobalY = 0xFFFF;
			LastSelectedEntrance.MapID = 0;
			LastSelectedEntrance.mapPos = 0xFFFF;
			LastSelectedEntrance.TargetEntranceID = 0;
			LastSelectedEntrance.deleted = true;
		}

		private void OnMouseMove_Entrance(MouseEventArgs e)
		{
			mapHover = (e.X / 16 / 32) + (e.Y / 16 / 32 * 8);

			if (SelectedEntrance != null)
			{
				if (isLeftPress && MouseIsDown)
				{
					SelectedEntrance.GlobalX = (ushort) (e.X & ~0x0F);
					SelectedEntrance.GlobalY = (ushort) (e.Y & ~0x0F);
				}
			}
		}


		int mxRightclick = 0;
		int myRightclick = 0;
		private void OnMouseUp_Entrance(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (SelectedEntrance != null)
				{
					byte mid = ZS.OverworldManager.allmaps[mapHover + ZS.OverworldManager.WorldOffset].parent;
					if (mid == 255)
					{
						mid = (byte) (mapHover + ZS.OverworldManager.WorldOffset);
					}

					SelectedEntrance.MapID = mid;
					SelectedEntrance = null;
				}
			}

			if (e.Button != MouseButtons.Right) return;
			
			ContextMenuStrip menu = new ContextMenuStrip();
			for (int i = 0; i < ZS.OverworldManager.allentrances.Length; i++)
			{
				EntranceOWEditor en = ZS.OverworldManager.allentrances[i];
				if (en.IsInThisWorld(ZS.OverworldManager.WorldOffset) && en.MouseIsInHitbox(e))
				{
					menu.Items.Add("Add Entrance");
					menu.Items.Add("Entrance Properties");
					menu.Items.Add("Delete Entrance");
					LastSelectedEntrance = en;
					SelectedEntrance = null;

					if (LastSelectedEntrance == null)
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

			for (int i = 0; i < ZS.OverworldManager.allholes.Length; i++)
			{

				EntranceOWEditor en = ZS.OverworldManager.allholes[i];
				if (en.IsInThisWorld(ZS.OverworldManager.WorldOffset) && en.MouseIsInHitbox(e))
				{
					
					menu.Items.Add("Add Entrance");
					menu.Items.Add("Entrance Properties");
					menu.Items.Add("Delete Entrance");
					LastSelectedEntrance = en;
					SelectedEntrance = null;

					if (LastSelectedEntrance == null)
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

			menu.Items.Add("Add Entrance");
			SelectedEntrance = null;
			menu.Items[0].Click += entranceAdd_Click;

			menu.Show(Cursor.Position);
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
					byte mid = ZS.OverworldManager.allmaps[mapHover + ZS.OverworldManager.WorldOffset].parent;
					if (mid == 255)
					{
						mid = (byte) (mapHover + ZS.OverworldManager.WorldOffset);
					}
					ZS.OverworldManager.allentrances[i].deleted = false;
					ZS.OverworldManager.allentrances[i].MapID = mid;
					ZS.OverworldManager.allentrances[i].GlobalX = (ushort) (mxRightclick & ~0xF);
					ZS.OverworldManager.allentrances[i].GlobalY = (ushort) (myRightclick & ~0xF);
					found = true;
					break;
				}
			}

			if (!found)
			{
				throw new ZeldaException("No space available for new entrances, delete one first");
			}
		}

		private void Delete_Click(object sender, EventArgs e)
		{
			Delete_Exit();
		}

		private void entranceProperty_Click(object sender, EventArgs e)
		{
			EntranceForm ef = new EntranceForm
			{
				entranceId = LastSelectedEntrance.TargetEntranceID,
				mapId = LastSelectedEntrance.MapID,
				mapPos = LastSelectedEntrance.mapPos,
				x = LastSelectedEntrance.GlobalX,
				y = LastSelectedEntrance.GlobalY,
				isHole = LastSelectedEntrance.IsPitEntrance
			};

			if (ef.ShowDialog() == DialogResult.OK)
			{
				LastSelectedEntrance.TargetEntranceID = ef.entranceId;
				LastSelectedEntrance.MapID = (byte) ef.mapId;
				LastSelectedEntrance.GlobalX = ef.x;
				LastSelectedEntrance.GlobalY = ef.y;

			}
		}

		private void Draw_Entrance(Graphics g)
		{
			Brush bgrBrush;
			for (int i = 0; i < ZS.OverworldManager.allentrances.Length; i++)
			{
				EntranceOWEditor e = ZS.OverworldManager.allentrances[i];
				if (lowEndMode && e.MapID != ZS.OverworldManager.allmaps[CurrentMap].parent)
				{
					continue;
				}

				if (e.IsInThisWorld(ZS.OverworldManager.WorldOffset))
				{
					if (SelectedEntrance != null && e == SelectedEntrance)
					{
						bgrBrush = Constants.Azure200Brush;
						drawText(g, e.GlobalX - 1, e.GlobalY + 26, "map : " + e.MapID.ToString());
						drawText(g, e.GlobalX - 1, e.GlobalY + 36, "entrance : " + e.TargetEntranceID.ToString());
						drawText(g, e.GlobalX - 1, e.GlobalY + 46, "mpos : " + e.mapPos.ToString());
					}
					else
					{
						bgrBrush = Constants.Goldenrod200Brush;
					}

					g.DrawFilledRectangleWithOutline(e.SquareHitbox, Constants.Black200Pen, bgrBrush);
					drawText(g, e.GlobalX - 1, e.GlobalY + 9, e.TargetEntranceID.ToString("X2") + " - " + ZS.all_rooms[ZS.entrances[e.TargetEntranceID].RoomID].Name);
				}
			}

			for (int i = 0; i < ZS.OverworldManager.allholes.Length; i++)
			{
				EntranceOWEditor e = ZS.OverworldManager.allholes[i];
				if (e.MapID != ZS.OverworldManager.allmaps[CurrentMap].parent)
				{
					continue;
				}

				if (e.IsInThisWorld(ZS.OverworldManager.WorldOffset))
				{
					bgrBrush = (e == SelectedEntrance) ? Constants.Azure200Brush : Constants.Charcoal200Brush;

					g.DrawFilledRectangleWithOutline(e.SquareHitbox, outline: Constants.Black200Pen, fill: bgrBrush);
					drawText(g, e.GlobalX - 1, e.GlobalY + 9, e.TargetEntranceID.ToString("X2") + " - " + ZS.all_rooms[ZS.entrances[e.TargetEntranceID].RoomID].Name);
				}
			}
		}
	}
}
