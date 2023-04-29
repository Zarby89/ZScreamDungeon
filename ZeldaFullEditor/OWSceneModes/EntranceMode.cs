using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lidgren.Network;
using ZeldaFullEditor.Gui;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor.OWSceneModes
{
	public class EntranceMode
	{
		SceneOW scene;
		public EntranceOWEditor selectedEntrance = null;
		public EntranceOWEditor lastselectedEntrance = null;
		
		bool isLeftPress = false;

		public EntranceMode(SceneOW scene)
		{
			this.scene = scene;
		}

		public void Copy()
		{
			Clipboard.Clear();
			EntranceOWEditor ed = lastselectedEntrance.Copy();
			Clipboard.SetData("owentrance", ed);
		}

		public void Cut()
		{
			Clipboard.Clear();
			EntranceOWEditor ed = lastselectedEntrance.Copy();
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

		public EntranceOWEditor AddEntrance(bool hole, bool clipboard = false)
		{
			byte entranceID = 0;
			bool ishole = false;
			if (clipboard)
			{
				EntranceOWEditor data = (EntranceOWEditor) Clipboard.GetData("owentrance");
				if (data != null)
				{
					entranceID = data.entranceId;
					ishole = data.isHole;
				}
			}
			else
			{
				ishole = hole;
			}

			int found = -1;
			if (ishole)
			{
				for (int i = 0; i < scene.ow.allholes.Length; i++)
				{
					if (scene.ow.allholes[i].deleted)
					{
						byte mid = scene.ow.allmaps[scene.mapHover + scene.ow.worldOffset].parent;
						if (mid == 255)
						{
							mid = (byte) (scene.mapHover + scene.ow.worldOffset);
						}
						scene.ow.allholes[i].deleted = false;
						scene.ow.allholes[i].mapId = mid;
						scene.ow.allholes[i].x = (ushort) ((mxRightclick / 16) * 16);
						scene.ow.allholes[i].y = (ushort) ((myRightclick / 16) * 16);
						scene.ow.allholes[i].entranceId = entranceID;

						scene.ow.allholes[i].updateMapStuff(mid);

						

						found = i;
						selectedEntrance = scene.ow.allholes[i];
						scene.mouse_down = true;
						isLeftPress = true;

						//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
						break;
					}
				}
			}
			else
			{
				for (int i = 0; i < scene.ow.allentrances.Length; i++)
				{
					if (scene.ow.allentrances[i].deleted)
					{
						byte mid = scene.ow.allmaps[scene.mapHover + scene.ow.worldOffset].parent;
						if (mid == 255)
						{
							mid = (byte) (scene.mapHover + scene.ow.worldOffset);
						}
						scene.ow.allentrances[i].deleted = false;
						scene.ow.allentrances[i].mapId = mid;
						scene.ow.allentrances[i].x = (ushort) ((mxRightclick / 16) * 16);
						scene.ow.allentrances[i].y = (ushort) ((myRightclick / 16) * 16);
						scene.ow.allentrances[i].entranceId = entranceID;

						scene.ow.allentrances[i].updateMapStuff(mid);

						found = i;
						selectedEntrance = scene.ow.allentrances[i];
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

			return scene.ow.allentrances[found];
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

			for (int i = 0; i < scene.ow.allentrances.Length; i++)
			{
				EntranceOWEditor en = scene.ow.allentrances[i];
				if (en.mapId >= scene.ow.worldOffset && en.mapId < 64 + scene.ow.worldOffset)
				{
					if (e.X >= en.x && e.X < en.x + 16 && e.Y >= en.y && e.Y < en.y + 16)
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

			for (int i = 0; i < scene.ow.allholes.Length; i++)
			{
				EntranceOWEditor en = scene.ow.allholes[i];
				if (en.mapId >= scene.ow.worldOffset && en.mapId < 64 + scene.ow.worldOffset)
				{
					if (e.X >= en.x && e.X < en.x + 16 && e.Y >= en.y && e.Y < en.y + 16)
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

				int roomId = DungeonsData.entrances[selectedEntrance.entranceId].Room;
				if (roomId >= Constants.NumberOfRooms)
				{
					//scene.owForm.thumbnailBox.Visible = false;
					return;
				}

				if (scene.mainForm.lastRoomID != roomId)
				{
					scene.mainForm.previewRoom = DungeonsData.all_rooms[roomId];
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
			for (int i = 0; i < scene.ow.allentrances.Length; i++)
			{
				EntranceOWEditor en = scene.ow.allentrances[i];
				if (en.mapId >= scene.ow.worldOffset && en.mapId < 64 + scene.ow.worldOffset)
				{
					if (e.X >= en.x && e.X < en.x + 16 && e.Y >= en.y && e.Y < en.y + 16)
					{
						if (e.Button == MouseButtons.Left)
						{
							TreeNode[] treeNodes = scene.mainForm.entrancetreeView.Nodes[0].Nodes
									.Cast<TreeNode>()
									.Where(r => (int) (r.Tag) == en.entranceId)
									.ToArray();

							if (treeNodes.Length != 0)
							{
								scene.mainForm.entrancetreeView.SelectedNode = treeNodes[0];
							}

							scene.mainForm.addRoomTab(DungeonsData.entrances[en.entranceId].Room);
							scene.mainForm.editorsTabControl.SelectedIndex = 0;
							//scene.mainForm.dungeonButton_Click(scene.mainForm.dungeonButton, null);
						}
					}
				}
			}

			for (int i = 0; i < scene.ow.allholes.Length; i++)
			{
				EntranceOWEditor en = scene.ow.allholes[i];
				if (en.mapId >= scene.ow.worldOffset && en.mapId < 64 + scene.ow.worldOffset)
				{
					if (e.X >= en.x && e.X < en.x + 16 && e.Y >= en.y && e.Y < en.y + 16)
					{
						if (!scene.mouse_down)
						{
							if (e.Button == MouseButtons.Left)
							{
								TreeNode[] treeNodes = scene.mainForm.entrancetreeView.Nodes[0].Nodes
										.Cast<TreeNode>()
										.Where(r => (int) (r.Tag) == en.entranceId)
										.ToArray();

								if (treeNodes.Length != 0)
								{
									scene.mainForm.entrancetreeView.SelectedNode = treeNodes[0];
								}

								scene.mainForm.addRoomTab(DungeonsData.entrances[en.entranceId].Room);
								scene.mainForm.editorsTabControl.SelectedIndex = 0;
							}
						}
					}
				}
			}
		}

		public void Delete()
		{
			lastselectedEntrance.x = 0xFFFF;
			lastselectedEntrance.y = 0xFFFF;
			lastselectedEntrance.mapId = 0;
			lastselectedEntrance.mapPos = 0xFFFF;
			lastselectedEntrance.entranceId = 0;
			lastselectedEntrance.deleted = true;
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
						selectedEntrance.x = (e.X / 16) * 16;
						selectedEntrance.y = (e.Y / 16) * 16;
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
					byte mid = scene.ow.allmaps[scene.mapHover + scene.ow.worldOffset].parent;
					if (mid == 255)
					{
						mid = (byte) (scene.mapHover + scene.ow.worldOffset);
					}

					selectedEntrance.updateMapStuff(mid);
					SendEntranceData(selectedEntrance);
					selectedEntrance = null;
					scene.mouse_down = false;
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				ContextMenuStrip menu = new ContextMenuStrip();
				for (int i = 0; i < scene.ow.allentrances.Length; i++)
				{
					EntranceOWEditor en = scene.ow.allentrances[i];
					if (en.mapId >= scene.ow.worldOffset && en.mapId < 64 + scene.ow.worldOffset)
					{
						if (e.X >= en.x && e.X < en.x + 16 && e.Y >= en.y && e.Y < en.y + 16)
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

				for (int i = 0; i < scene.ow.allholes.Length; i++)
				{

					EntranceOWEditor en = scene.ow.allholes[i];
					if (en.mapId >= scene.ow.worldOffset && en.mapId < 64 + scene.ow.worldOffset)
					{
						if (e.X >= en.x && e.X < en.x + 16 && e.Y >= en.y && e.Y < en.y + 16)
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

			if(temp == "Add Hole")
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
			for (int i = 0; i < scene.ow.allentrances.Length; i++)
			{
				if (scene.ow.allentrances[i].deleted)
				{
					byte mid = scene.ow.allmaps[scene.mapHover + scene.ow.worldOffset].parent;
					if (mid == 255)
					{
						mid = (byte) (scene.mapHover + scene.ow.worldOffset);
					}
					scene.ow.allentrances[i].deleted = false;
					scene.ow.allentrances[i].mapId = mid;
					scene.ow.allentrances[i].x = (mxRightclick / 16) * 16;
					scene.ow.allentrances[i].y = (myRightclick / 16) * 16;
					scene.ow.allentrances[i].updateMapStuff(mid);
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
			ef.entranceId = lastselectedEntrance.entranceId;
			ef.mapId = lastselectedEntrance.mapId;
			ef.mapPos = lastselectedEntrance.mapPos;
			ef.x = lastselectedEntrance.x;
			ef.y = lastselectedEntrance.y;
			ef.isHole = lastselectedEntrance.isHole;

			if (ef.ShowDialog() == DialogResult.OK)
			{
				lastselectedEntrance.entranceId = ef.entranceId;
				lastselectedEntrance.mapId = ef.mapId;
				lastselectedEntrance.x = ef.x;
				lastselectedEntrance.y = ef.y;
				SendEntranceData(lastselectedEntrance);
			}
		}

		public void Draw(Graphics g)
		{
			if (scene.lowEndMode)
			{
				Brush bgrBrush = Constants.Goldenrod200Brush;
				g.CompositingMode = CompositingMode.SourceOver;

				for (int i = 0; i < scene.ow.allentrances.Length; i++)
				{
					EntranceOWEditor e = scene.ow.allentrances[i];
					if (e.mapId != scene.ow.allmaps[scene.selectedMap].parent)
					{
						continue;
					}

					if (e.mapId < 64 + scene.ow.worldOffset && e.mapId >= scene.ow.worldOffset)
					{
						if (selectedEntrance != null)
						{
							if (e == selectedEntrance)
							{
								bgrBrush = Constants.Azure200Brush;
								scene.drawText(g, e.x - 1, e.y + 26, "map : " + e.mapId.ToString());
								scene.drawText(g, e.x - 1, e.y + 36, "entrance : " + e.entranceId.ToString());
								scene.drawText(g, e.x - 1, e.y + 46, "mpos : " + e.mapPos.ToString());
							}
							else
							{
								bgrBrush = Constants.Goldenrod200Brush;
							}
						}

						g.FillRectangle(bgrBrush, new Rectangle(e.x, e.y, 16, 16));
						g.DrawRectangle(Constants.Black200Pen, new Rectangle(e.x, e.y, 16, 16));
						scene.drawText(g, e.x - 1, e.y + 9, e.entranceId.ToString("X2") + " - " + DungeonsData.all_rooms[DungeonsData.entrances[e.entranceId].Room].name);
					}
				}

				for (int i = 0; i < scene.ow.allholes.Length; i++)
				{
					EntranceOWEditor e = scene.ow.allholes[i];
					if (e.mapId != scene.ow.allmaps[scene.selectedMap].parent)
					{
						continue;
					}

					bgrBrush = Constants.Charcoal200Brush;
					if (e.mapId < 64 + scene.ow.worldOffset && e.mapId >= scene.ow.worldOffset)
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
						scene.drawText(g, e.x - 1, e.y + 9, e.entranceId.ToString("X2") + " - " + DungeonsData.all_rooms[DungeonsData.entrances[e.entranceId].Room].name);
					}
				}

				g.CompositingMode = CompositingMode.SourceCopy;
			}

			else
			{
				Brush bgrBrush = Constants.Goldenrod200Brush;
				g.CompositingMode = CompositingMode.SourceOver;

				for (int i = 0; i < scene.ow.allentrances.Length; i++)
				{
					EntranceOWEditor e = scene.ow.allentrances[i];

					if (e.mapId < 64 + scene.ow.worldOffset && e.mapId >= scene.ow.worldOffset)
					{
						if (selectedEntrance != null)
						{
							if (e == selectedEntrance)
							{
								bgrBrush = Constants.Azure200Brush;
								scene.drawText(g, e.x - 1, e.y + 26, "map : " + e.mapId.ToString());
								scene.drawText(g, e.x - 1, e.y + 36, "entrance : " + e.entranceId.ToString());
								scene.drawText(g, e.x - 1, e.y + 46, "mpos : " + e.mapPos.ToString());
							}
							else
							{
								bgrBrush = Constants.Goldenrod200Brush;
							}
						}

						g.FillRectangle(bgrBrush, new Rectangle(e.x, e.y, 16, 16));
						g.DrawRectangle(Constants.Black200Pen, new Rectangle(e.x, e.y, 16, 16));
						scene.drawText(g, e.x - 1, e.y + 9, e.entranceId.ToString("X2") + " - " + DungeonsData.all_rooms[DungeonsData.entrances[e.entranceId].Room].name);
					}
				}

				for (int i = 0; i < scene.ow.allholes.Length; i++)
				{
					EntranceOWEditor e = scene.ow.allholes[i];
					bgrBrush = Constants.Charcoal200Brush;

					if (e.mapId < 64 + scene.ow.worldOffset && e.mapId >= scene.ow.worldOffset)
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
						scene.drawText(g, e.x - 1, e.y + 9, e.entranceId.ToString("X2") + " - " + DungeonsData.all_rooms[DungeonsData.entrances[e.entranceId].Room].name);
					}
				}

				g.CompositingMode = CompositingMode.SourceCopy;
			}
		}


		public void SendEntranceData(EntranceOWEditor entrance)
		{
			NetZSBuffer buffer = new NetZSBuffer(24);
			buffer.Write((byte) 06); // entrance data
			buffer.Write((byte) NetZS.userID); //user ID
			buffer.Write((int) entrance.uniqueID);
			buffer.Write((byte) entrance.entranceId);
			buffer.Write((ushort) entrance.mapPos);
			buffer.Write((int) entrance.x);
			buffer.Write((int) entrance.y);
			buffer.Write((byte) entrance.AreaX);;
			buffer.Write((byte) entrance.AreaY);
			buffer.Write((short) entrance.mapId);
			buffer.Write((byte) (entrance.isHole ? 1 : 0));
			buffer.Write((byte) (entrance.deleted ? 1 : 0));
			NetOutgoingMessage msg = NetZS.client.CreateMessage();
			msg.Write(buffer.buffer);
			NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
			NetZS.client.FlushSendQueue();

		}


	}
}
