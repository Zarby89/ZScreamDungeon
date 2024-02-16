using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using Lidgren.Network;
using ZeldaFullEditor.Gui;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor.OWSceneModes
{
	public class EntranceMode
	{
		SceneOW scene;
		public EntranceOW selectedEntrance = null;
		public EntranceOW lastselectedEntrance = null;

		bool isLeftPress = false;

		public EntranceMode(SceneOW scene)
		{
			this.scene = scene;
		}

		public void Copy()
		{
			Clipboard.Clear();
			EntranceOW ed = lastselectedEntrance.Copy();
			Clipboard.SetData("owentrance", ed);
		}

		public void Cut()
		{
			Clipboard.Clear();
			EntranceOW ed = lastselectedEntrance.Copy();
			Clipboard.SetData("owentrance", ed);
			Delete();
		}

		public void Paste()
		{
			selectedEntrance = AddEntrance(false, true);
			if (selectedEntrance != null)
			{
				lastselectedEntrance = selectedEntrance;
				scene.mouse_down = true;
				isLeftPress = true;
				//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
			}
		}

		public EntranceOW AddEntrance(bool hole, bool clipboard = false)
		{
			byte entranceID = 0;
			bool ishole = false;
			if (clipboard)
			{
				EntranceOW data = (EntranceOW) Clipboard.GetData("owentrance");
				if (data != null)
				{
					entranceID = data.EntranceID;
					ishole = data.IsHole;
				}
			}
			else
			{
				ishole = hole;
			}

			int found = -1;
			if (ishole)
			{
				for (int i = 0; i < scene.ow.AllHoles.Length; i++)
				{
					if (scene.ow.AllHoles[i].Deleted)
					{
						byte mid = scene.ow.AllMaps[scene.mapHover + scene.ow.WorldOffset].ParentID;
						if (mid == 255)
						{
							mid = (byte) (scene.mapHover + scene.ow.WorldOffset);
						}
						scene.ow.AllHoles[i].Deleted = false;
						scene.ow.AllHoles[i].MapID = mid;
						scene.ow.AllHoles[i].X = (ushort) ((mxRightclick / 16) * 16);
						scene.ow.AllHoles[i].Y = (ushort) ((myRightclick / 16) * 16);
						scene.ow.AllHoles[i].EntranceID = entranceID;

						scene.ow.AllHoles[i].UpdateMapStuff(mid);



						found = i;
						selectedEntrance = scene.ow.AllHoles[i];
						scene.mouse_down = true;
						isLeftPress = true;

						//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
						break;
					}
				}
			}
			else
			{
				for (int i = 0; i < scene.ow.AllEntrances.Length; i++)
				{
					if (scene.ow.AllEntrances[i].Deleted)
					{
						byte mid = scene.ow.AllMaps[scene.mapHover + scene.ow.WorldOffset].ParentID;
						if (mid == 255)
						{
							mid = (byte) (scene.mapHover + scene.ow.WorldOffset);
						}
						scene.ow.AllEntrances[i].Deleted = false;
						scene.ow.AllEntrances[i].MapID = mid;
						scene.ow.AllEntrances[i].X = (ushort) ((mxRightclick / 16) * 16);
						scene.ow.AllEntrances[i].Y = (ushort) ((myRightclick / 16) * 16);
						scene.ow.AllEntrances[i].EntranceID = entranceID;

						scene.ow.AllEntrances[i].UpdateMapStuff(mid);

						found = i;
						selectedEntrance = scene.ow.AllEntrances[i];
						scene.mouse_down = true;
						isLeftPress = true;
						SendEntranceData(selectedEntrance);
						//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
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

			return scene.ow.AllEntrances[found];
		}

		public void onMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				isLeftPress = true;
			}
			else
			{
				isLeftPress = false;
			}

			for (int i = 0; i < scene.ow.AllEntrances.Length; i++)
			{
				EntranceOW en = scene.ow.AllEntrances[i];
				if (en.MapID >= scene.ow.WorldOffset && en.MapID < 64 + scene.ow.WorldOffset)
				{
					if (e.X >= en.X && e.X < en.X + 16 && e.Y >= en.Y && e.Y < en.Y + 16)
					{
						if (!scene.mouse_down)
						{
							if (e.Button == MouseButtons.Left)
							{
								selectedEntrance = en;
								lastselectedEntrance = en;
								scene.mouse_down = true;
							}
							else if (e.Button == MouseButtons.Right)
							{
								lastselectedEntrance = en;
								scene.mouse_down = true;
								mxRightclick = (e.X);
								myRightclick = (e.Y);
							}
						}
					}
				}
			}

			for (int i = 0; i < scene.ow.AllHoles.Length; i++)
			{
				EntranceOW en = scene.ow.AllHoles[i];
				if (en.MapID >= scene.ow.WorldOffset && en.MapID < 64 + scene.ow.WorldOffset)
				{
					if (e.X >= en.X && e.X < en.X + 16 && e.Y >= en.Y && e.Y < en.Y + 16)
					{
						if (!scene.mouse_down)
						{
							if (e.Button == MouseButtons.Left)
							{
								selectedEntrance = en;
								lastselectedEntrance = en;
								scene.mouse_down = true;
							}
							else if (e.Button == MouseButtons.Right)
							{
								lastselectedEntrance = en;
								scene.mouse_down = true;
								mxRightclick = (e.X);
								myRightclick = (e.Y);
							}
						}
					}
				}
			}

			if (selectedEntrance != null)
			{
				//scene.owForm.thumbnailBox.Visible = true;
				//scene.owForm.thumbnailBox.Size = new Size(256, 256);

				int roomId = DungeonsData.Entrances[selectedEntrance.EntranceID].Room;
				if (roomId >= Constants.NumberOfRooms)
				{
					//scene.owForm.thumbnailBox.Visible = false;
					return;
				}

				if (scene.mainForm.lastRoomID != roomId)
				{
					scene.mainForm.previewRoom = DungeonsData.AllRooms[roomId];
					scene.mainForm.previewRoom.reloadGfx();
					GFX.loadedPalettes = GFX.LoadDungeonPalette(scene.mainForm.previewRoom.palette);
					scene.mainForm.DrawRoom();
					DrawTempEntrance();
					scene.entrancePreview = true;
					//scene.Refresh();

					if (scene.mainForm.activeScene.room != null)
					{
						GFX.loadedPalettes = GFX.LoadDungeonPalette(scene.mainForm.activeScene.room.palette);
						scene.mainForm.activeScene.room.reloadGfx();
						scene.mainForm.activeScene.DrawRoom();
					}
				}

				scene.mainForm.lastRoomID = roomId;
			}
		}

		public void DrawTempEntrance()
		{
			Graphics g = Graphics.FromImage(scene.owForm.tmpPreviewBitmap);
			g.InterpolationMode = InterpolationMode.Bilinear;
			if (scene.mainForm.previewRoom.bg2 != Background2.Translucent || scene.mainForm.previewRoom.bg2 != Background2.Transparent ||
			 scene.mainForm.previewRoom.bg2 != Background2.OnTop || scene.mainForm.previewRoom.bg2 != Background2.Off)
			{
				g.DrawImage(GFX.roomBg2Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);
			}

			g.DrawImage(GFX.roomBg1Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);

			if (scene.mainForm.previewRoom.bg2 == Background2.Translucent || scene.mainForm.previewRoom.bg2 == Background2.Transparent)
			{
				float[][] matrixItems ={
			   new float[] {1f, 0, 0, 0, 0},
			   new float[] {0, 1f, 0, 0, 0},
			   new float[] {0, 0, 1f, 0, 0},
			   new float[] {0, 0, 0, 0.5f, 0},
			   new float[] {0, 0, 0, 0, 1}};
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
				g.DrawImage(GFX.roomBg2Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel, imageAtt);
			}
			else if (scene.mainForm.previewRoom.bg2 == Background2.OnTop)
			{
				g.DrawImage(GFX.roomBg2Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);
			}

			scene.mainForm.activeScene.drawText(g, 0, 0, "ROOM : " + scene.mainForm.previewRoom.index.ToString("X2"));
			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.Dispose();
		}

		public void onMouseDoubleClick(MouseEventArgs e)
		{
			for (int i = 0; i < scene.ow.AllEntrances.Length; i++)
			{
				EntranceOW en = scene.ow.AllEntrances[i];
				if (en.MapID >= scene.ow.WorldOffset && en.MapID < 64 + scene.ow.WorldOffset)
				{
					if (e.X >= en.X && e.X < en.X + 16 && e.Y >= en.Y && e.Y < en.Y + 16)
					{
						if (e.Button == MouseButtons.Left)
						{
							TreeNode[] treeNodes = scene.mainForm.entrancetreeView.Nodes[0].Nodes
									.Cast<TreeNode>()
									.Where(r => (int) (r.Tag) == en.EntranceID)
									.ToArray();

							if (treeNodes.Length != 0)
							{
								scene.mainForm.entrancetreeView.SelectedNode = treeNodes[0];
							}

							scene.mainForm.AddRoomTab(DungeonsData.Entrances[en.EntranceID].Room);
							scene.mainForm.editorsTabControl.SelectedIndex = 0;
							//scene.mainForm.dungeonButton_Click(scene.mainForm.dungeonButton, null);
						}
					}
				}
			}

			for (int i = 0; i < scene.ow.AllHoles.Length; i++)
			{
				EntranceOW en = scene.ow.AllHoles[i];
				if (en.MapID >= scene.ow.WorldOffset && en.MapID < 64 + scene.ow.WorldOffset)
				{
					if (e.X >= en.X && e.X < en.X + 16 && e.Y >= en.Y && e.Y < en.Y + 16)
					{
						if (!scene.mouse_down)
						{
							if (e.Button == MouseButtons.Left)
							{
								TreeNode[] treeNodes = scene.mainForm.entrancetreeView.Nodes[0].Nodes
										.Cast<TreeNode>()
										.Where(r => (int) (r.Tag) == en.EntranceID)
										.ToArray();

								if (treeNodes.Length != 0)
								{
									scene.mainForm.entrancetreeView.SelectedNode = treeNodes[0];
								}

								scene.mainForm.AddRoomTab(DungeonsData.Entrances[en.EntranceID].Room);
								scene.mainForm.editorsTabControl.SelectedIndex = 0;
							}
						}
					}
				}
			}
		}

		public void Delete()
		{
			lastselectedEntrance.X = 0xFFFF;
			lastselectedEntrance.Y = 0xFFFF;
			lastselectedEntrance.MapID = 0;
			lastselectedEntrance.MapPos = 0xFFFF;
			lastselectedEntrance.EntranceID = 0;
			lastselectedEntrance.Deleted = true;
			SendEntranceData(lastselectedEntrance);
			//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
		}

		public void onMouseMove(MouseEventArgs e)
		{
			int mouseTileX = e.X / 16;
			int mouseTileY = e.Y / 16;
			int mapX = (mouseTileX / 32);
			int mapY = (mouseTileY / 32);

			scene.mapHover = mapX + (mapY * 8);

			if (selectedEntrance != null)
			{
				if (isLeftPress)
				{
					if (scene.mouse_down)
					{
						selectedEntrance.X = (e.X / 16) * 16;
						selectedEntrance.Y = (e.Y / 16) * 16;
					}
				}

				//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
			}
		}


		int mxRightclick = 0;
		int myRightclick = 0;
		public void onMouseUp(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (selectedEntrance != null)
				{
					byte mid = scene.ow.AllMaps[scene.mapHover + scene.ow.WorldOffset].ParentID;
					if (mid == 255)
					{
						mid = (byte) (scene.mapHover + scene.ow.WorldOffset);
					}

					selectedEntrance.UpdateMapStuff(mid);
					SendEntranceData(selectedEntrance);
					selectedEntrance = null;
					scene.mouse_down = false;
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				ContextMenuStrip menu = new ContextMenuStrip();
				for (int i = 0; i < scene.ow.AllEntrances.Length; i++)
				{
					EntranceOW en = scene.ow.AllEntrances[i];
					if (en.MapID >= scene.ow.WorldOffset && en.MapID < 64 + scene.ow.WorldOffset)
					{
						if (e.X >= en.X && e.X < en.X + 16 && e.Y >= en.Y && e.Y < en.Y + 16)
						{
							menu.Items.Add("Add Entrance");
							menu.Items.Add("Add Hole");
							menu.Items.Add("Entrance Properties");
							menu.Items.Add("Delete Entrance/Hole");
							lastselectedEntrance = en;
							selectedEntrance = null;
							scene.mouse_down = false;

							if (lastselectedEntrance == null)
							{
								menu.Items[1].Enabled = false;
								menu.Items[2].Enabled = false;
							}

							menu.Items[0].Click += entranceAdd_Click;
							menu.Items[1].Click += entranceAdd_Click;
							menu.Items[2].Click += entranceProperty_Click;
							menu.Items[3].Click += Delete_Click;
							menu.Show(Cursor.Position);
							return;
						}
					}
				}

				for (int i = 0; i < scene.ow.AllHoles.Length; i++)
				{

					EntranceOW en = scene.ow.AllHoles[i];
					if (en.MapID >= scene.ow.WorldOffset && en.MapID < 64 + scene.ow.WorldOffset)
					{
						if (e.X >= en.X && e.X < en.X + 16 && e.Y >= en.Y && e.Y < en.Y + 16)
						{
							menu.Items.Add("Add Entrance");
							menu.Items.Add("Add Hole");
							menu.Items.Add("Hole Properties");
							menu.Items.Add("Delete Hole");
							lastselectedEntrance = en;
							selectedEntrance = null;
							scene.mouse_down = false;

							if (lastselectedEntrance == null)
							{
								menu.Items[1].Enabled = false;
								menu.Items[2].Enabled = false;
							}

							menu.Items[0].Click += entranceAdd_Click;
							menu.Items[1].Click += entranceAdd_Click;
							menu.Items[2].Click += entranceProperty_Click;
							menu.Items[3].Click += Delete_Click;
							menu.Show(Cursor.Position);
							return;
						}
					}
				}

				menu.Items.Add("Add Entrance");
				menu.Items[0].Click += entranceAdd_Click;
				menu.Items.Add("Add Hole");
				menu.Items[1].Click += entranceAdd_Click;

				selectedEntrance = null;
				scene.mouse_down = false;

				menu.Show(Cursor.Position);
				return;
			}
		}

		private void entranceAdd_Click(object sender, EventArgs e)
		{
			string temp = sender.ToString();

			if (temp == "Add Hole")
			{
				AddEntrance(true);
			}
			else
			{
				AddEntrance(false);
			}
		}

		private void insertEntrance_Click(object sender, EventArgs e)
		{
			bool found = false;
			for (int i = 0; i < scene.ow.AllEntrances.Length; i++)
			{
				if (scene.ow.AllEntrances[i].Deleted)
				{
					byte mid = scene.ow.AllMaps[scene.mapHover + scene.ow.WorldOffset].ParentID;
					if (mid == 255)
					{
						mid = (byte) (scene.mapHover + scene.ow.WorldOffset);
					}
					scene.ow.AllEntrances[i].Deleted = false;
					scene.ow.AllEntrances[i].MapID = mid;
					scene.ow.AllEntrances[i].X = (mxRightclick / 16) * 16;
					scene.ow.AllEntrances[i].Y = (myRightclick / 16) * 16;
					scene.ow.AllEntrances[i].UpdateMapStuff(mid);
					found = true;
					//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
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
			EntranceForm ef = new EntranceForm();
			ef.entranceId = lastselectedEntrance.EntranceID;
			ef.mapId = lastselectedEntrance.MapID;
			ef.mapPos = lastselectedEntrance.MapPos;
			ef.x = lastselectedEntrance.X;
			ef.y = lastselectedEntrance.Y;
			ef.isHole = lastselectedEntrance.IsHole;

			if (ef.ShowDialog() == DialogResult.OK)
			{
				lastselectedEntrance.EntranceID = ef.entranceId;
				lastselectedEntrance.MapID = ef.mapId;
				lastselectedEntrance.X = ef.x;
				lastselectedEntrance.Y = ef.y;
				SendEntranceData(lastselectedEntrance);
			}
		}

		public void Draw(Graphics g)
		{
			if (scene.lowEndMode)
			{
				Brush bgrBrush = Constants.Goldenrod200Brush;
				g.CompositingMode = CompositingMode.SourceOver;

				for (int i = 0; i < scene.ow.AllEntrances.Length; i++)
				{
					EntranceOW e = scene.ow.AllEntrances[i];
					if (e.MapID != scene.ow.AllMaps[scene.selectedMap].ParentID)
					{
						continue;
					}

					if (e.MapID < 64 + scene.ow.WorldOffset && e.MapID >= scene.ow.WorldOffset)
					{
						if (selectedEntrance != null)
						{
							if (e == selectedEntrance)
							{
								bgrBrush = Constants.Azure200Brush;
								scene.drawText(g, e.X - 1, e.Y + 26, "map : " + e.MapID.ToString());
								scene.drawText(g, e.X - 1, e.Y + 36, "entrance : " + e.EntranceID.ToString());
								scene.drawText(g, e.X - 1, e.Y + 46, "mpos : " + e.MapPos.ToString());
							}
							else
							{
								bgrBrush = Constants.Goldenrod200Brush;
							}
						}

						g.FillRectangle(bgrBrush, new Rectangle(e.X, e.Y, 16, 16));
						g.DrawRectangle(Constants.Black200Pen, new Rectangle(e.X, e.Y, 16, 16));
						scene.drawText(g, e.X - 1, e.Y + 9, e.EntranceID.ToString("X2") + " - " + DungeonsData.AllRooms[DungeonsData.Entrances[e.EntranceID].Room].name);
					}
				}

				for (int i = 0; i < scene.ow.AllHoles.Length; i++)
				{
					EntranceOW e = scene.ow.AllHoles[i];
					if (e.MapID != scene.ow.AllMaps[scene.selectedMap].ParentID)
					{
						continue;
					}

					bgrBrush = Constants.Charcoal200Brush;
					if (e.MapID < 64 + scene.ow.WorldOffset && e.MapID >= scene.ow.WorldOffset)
					{
						if (selectedEntrance != null)
						{
							if (e == selectedEntrance)
							{
								bgrBrush = Constants.Azure200Brush;
							}
						}

						g.FillRectangle(bgrBrush, new Rectangle(e.X, e.Y, 16, 16));
						g.DrawRectangle(Constants.Black200Pen, new Rectangle(e.X, e.Y, 16, 16));
						scene.drawText(g, e.X - 1, e.Y + 9, e.EntranceID.ToString("X2") + " - " + DungeonsData.AllRooms[DungeonsData.Entrances[e.EntranceID].Room].name);
					}
				}

				g.CompositingMode = CompositingMode.SourceCopy;
			}
			else
			{
				Brush bgrBrush = Constants.Goldenrod200Brush;
				g.CompositingMode = CompositingMode.SourceOver;

				for (int i = 0; i < scene.ow.AllEntrances.Length; i++)
				{
					EntranceOW e = scene.ow.AllEntrances[i];

					if (e.MapID < 64 + scene.ow.WorldOffset && e.MapID >= scene.ow.WorldOffset)
					{
						if (selectedEntrance != null)
						{
							if (e == selectedEntrance)
							{
								bgrBrush = Constants.Azure200Brush;
								scene.drawText(g, e.X - 1, e.Y + 26, "map : " + e.MapID.ToString());
								scene.drawText(g, e.X - 1, e.Y + 36, "entrance : " + e.EntranceID.ToString());
								scene.drawText(g, e.X - 1, e.Y + 46, "mpos : " + e.MapPos.ToString());
							}
							else
							{
								bgrBrush = Constants.Goldenrod200Brush;
							}
						}

						g.FillRectangle(bgrBrush, new Rectangle(e.X, e.Y, 16, 16));
						g.DrawRectangle(Constants.Black200Pen, new Rectangle(e.X, e.Y, 16, 16));
						scene.drawText(g, e.X - 1, e.Y + 9, e.EntranceID.ToString("X2") + " - " + DungeonsData.AllRooms[DungeonsData.Entrances[e.EntranceID].Room].name);
					}
				}

				for (int i = 0; i < scene.ow.AllHoles.Length; i++)
				{
					EntranceOW e = scene.ow.AllHoles[i];
					bgrBrush = Constants.Charcoal200Brush;

					if (e.MapID < 64 + scene.ow.WorldOffset && e.MapID >= scene.ow.WorldOffset)
					{
						if (selectedEntrance != null)
						{
							if (e == selectedEntrance)
							{
								bgrBrush = Constants.Azure200Brush;
							}
						}

						g.FillRectangle(bgrBrush, new Rectangle(e.X, e.Y, 16, 16));
						g.DrawRectangle(Constants.Black200Pen, new Rectangle(e.X, e.Y, 16, 16));
						scene.drawText(g, e.X - 1, e.Y + 9, e.EntranceID.ToString("X2") + " - " + DungeonsData.AllRooms[DungeonsData.Entrances[e.EntranceID].Room].name);
					}
				}

				g.CompositingMode = CompositingMode.SourceCopy;
			}
		}


		public void SendEntranceData(EntranceOW entrance)
		{
			if (!NetZS.connected) { return; }
			NetZSBuffer buffer = new NetZSBuffer(24);
			buffer.Write((byte) 06); // entrance data
			buffer.Write(NetZS.userID); //user ID
			buffer.Write(entrance.UniqueID);
			buffer.Write(entrance.EntranceID);
			buffer.Write(entrance.MapPos);
			buffer.Write(entrance.X);
			buffer.Write(entrance.Y);
			buffer.Write(entrance.AreaX); ;
			buffer.Write(entrance.AreaY);
			buffer.Write(entrance.MapID);
			buffer.Write((byte) (entrance.IsHole ? 1 : 0));
			buffer.Write((byte) (entrance.Deleted ? 1 : 0));
			NetOutgoingMessage msg = NetZS.client.CreateMessage();
			msg.Write(buffer.buffer);
			NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
			NetZS.client.FlushSendQueue();

		}


	}
}
