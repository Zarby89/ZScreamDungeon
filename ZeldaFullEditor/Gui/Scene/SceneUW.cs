using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lidgren.Network;
using Microsoft.VisualBasic;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor
{
	public class SceneUW : Scene
	{
		public Bitmap tempBitmap = new Bitmap(512, 512);
		public short[] doorsObject = new short[] { 0x138, 0x139, 0x13A, 0x13B, 0xF9E, 0xFA9, 0xF9F, 0xFA0, 0x12D, 0x12E, 0x12F, 0x12E, 0x12D, 0x4632, 0x4693 };
		Rectangle lastSelectedRectangle;
		SceneResizing resizeType = SceneResizing.none;

		public bool forPreview = false;

		bool resizing = false;

		int rmx = 0;
		int rmy = 0;

		public SceneUW(DungeonMain f)
		{
			//graphics = Graphics.FromImage(scene_bitmap);

			this.MouseDown += new MouseEventHandler(onMouseDown);
			this.MouseUp += new MouseEventHandler(onMouseUp);
			this.MouseMove += new MouseEventHandler(onMouseMove);
			this.MouseDoubleClick += new MouseEventHandler(onMouseDoubleClick);
			this.MouseWheel += SceneUW_MouseWheel;
			this.Paint += SceneUW_Paint;
			mainForm = f;
		}

		private void SceneUW_MouseWheel(object sender, MouseEventArgs e)
		{
			if (room.selectedObject.Count > 0)
			{
				if (room.selectedObject[0] is Room_Object objs)
				{
					if (e.Delta > 0)
					{
						if (objs.Size < 15)
						{
							objs.UpdateSize();
							objs.Size++;
							updateSelectionObject(objs);
						}
					}
					else if (e.Delta < 0)
					{
						if (objs.Size > 0)
						{
							objs.UpdateSize();
							objs.Size--;

							if (objs.Size >= 16)
							{
								objs.Size = 15;
							}
							updateSelectionObject(objs);
						}
					}

					if (NetZS.connected)
					{
						NetZSBuffer buffer = new NetZSBuffer(12);
						buffer.Write((byte) 20); // tile data cmd
						buffer.Write(NetZS.userID); // user id
						buffer.Write(room.index); //room index 4
						buffer.Write((room.selectedObject[0] as Room_Object).uniqueID); // 4
						buffer.Write((room.selectedObject[0] as Room_Object).Size); //byte

						NetOutgoingMessage msg = NetZS.client.CreateMessage();
						msg.Write(buffer.buffer);
						NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
						NetZS.client.FlushSendQueue();
					}


				}
			}

			this.DrawRoom();
			this.Refresh();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
		}

		private void ResizeObject(Room_Object lastElement, int x, int y)
		{
			lastElement.UpdateSize();

			if (NetZS.connected)
			{
				return; // prevent updating with mouse
			}
			//if (8 != 0)
			//{

			if ((resizeType & SceneResizing.left) == SceneResizing.left)
			{
				if (x <= (dragx) - lastElement.sizewidth)
				{
					if (lastElement.Size < 15)
					{
						if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
						{
							byte bsize = lastElement.Size;
							int sizex = ((bsize >> 2) & 0x03) + 1;
							lastElement.Size = (byte) ((sizex << 2) | (bsize & 0x03));
						}
						else
						{
							lastElement.Size++;
						}

						lastElement.X -= (byte) (lastElement.sizewidth / 8); // Object length size
						lastElement.nx -= (byte) (lastElement.sizewidth / 8); // Object length size
						dragx -= lastElement.sizewidth;
					}
				}
				else if (x >= (dragx) + lastElement.sizewidth)
				{
					if (lastElement.Size > 0)
					{
						if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
						{
							byte bsize = lastElement.Size;
							int sizex = ((bsize >> 2) & 0x03) - 1;
							lastElement.Size = (byte) ((sizex << 2) | (bsize & 0x03));
						}
						else
						{
							lastElement.Size--;
						}

						lastElement.X += (byte) (lastElement.sizewidth / 8); // Object length size
						lastElement.nx += (byte) (lastElement.sizewidth / 8); // Object length size
						dragx += lastElement.sizewidth;
					}
				}
			}

			if ((resizeType & SceneResizing.right) == SceneResizing.right)
			{
				if (x >= (dragx) + lastElement.sizewidth)
				{
					if (lastElement.Size < 15)
					{
						if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
						{
							byte bsize = lastElement.Size;
							int sizex = ((bsize >> 2) & 0x03) + 1;
							lastElement.Size = (byte) ((sizex << 2) | (bsize * 0x03));
						}
						else
						{
							lastElement.Size++;
						}

						//lastElement.x = 16; // Object length size
						dragx += lastElement.sizewidth;
					}
				}
				else if (x <= (dragx) - lastElement.sizewidth)
				{
					if (lastElement.Size > 0)
					{
						if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
						{
							byte bsize = lastElement.Size;
							int sizex = ((bsize >> 2) & 0x03) - 1;
							lastElement.Size = (byte) ((sizex << 2) | (bsize & 0x03));
						}
						else
						{
							lastElement.Size--;
						}

						//lastElement.x += 16; // Object length size
						dragx -= lastElement.sizewidth;
					}
				}
			}

			//}
			//if (8 != 0)
			//{
			if ((resizeType & SceneResizing.down) == SceneResizing.down)
			{
				if (y >= (dragy) + lastElement.sizeheight)
				{
					if (lastElement.Size < 15)
					{
						if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
						{
							byte bsize = lastElement.Size;
							lastElement.Size = (byte) ((bsize & 0x0C) | ((bsize & 0x03) + 1));
						}
						else
						{
							//Console.WriteLine(lastElement.sizeheight + "  Base Heigth : " + lastElement.baseheight);
							lastElement.Size++;
						}

						//lastElement.x = 16; //object length size
						dragy += lastElement.sizeheight;
					}
				}
				else if (y <= (dragy) - lastElement.sizeheight)
				{
					if (lastElement.Size > 0)
					{
						if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
						{
							byte bsize = lastElement.Size;
							lastElement.Size = (byte) ((bsize & 0x0C) | (((bsize) & 0x03) - 1));
						}
						else
						{
							lastElement.Size--;
						}

						//lastElement.x += 16; //object length size
						dragy -= lastElement.sizeheight;
					}
				}
			}

			if ((resizeType & SceneResizing.up) == SceneResizing.up)
			{
				if (y <= (dragy) - lastElement.sizeheight)
				{
					if (lastElement.Size < 15)
					{
						if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
						{
							byte bsize = lastElement.Size;
							lastElement.Size = (byte) ((bsize & 0x0C) | (((bsize) & 0x03) + 1));
						}
						else
						{
							lastElement.Size++;
						}

						lastElement.Y -= (byte) (lastElement.sizeheight / 8); // Object length size
						lastElement.ny -= (byte) (lastElement.sizeheight / 8); // Object length size
						dragy -= lastElement.sizeheight;
					}
				}
				else if (y >= (dragy) + lastElement.sizeheight)
				{
					if (lastElement.Size > 0)
					{
						if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
						{
							byte bsize = lastElement.Size;
							lastElement.Size = (byte) ((bsize & 0x0C) | (((bsize) & 0x03) - 1));
						}
						else
						{
							lastElement.Size--;
						}

						lastElement.Y += (byte) (lastElement.sizeheight / 8); // Object length size
						lastElement.ny += (byte) (lastElement.sizeheight / 8); // Object length size
						dragy += lastElement.sizeheight;
					}
				}
			}

			//}
		}

		// TODO: FIND PROBLEM THAT IS INCREASING SAVE TIME!!
		private void onMouseMove(object sender, MouseEventArgs e)
		{
			this.mainForm.GetXYMouseBasedOnZoom(e, out int MX, out int MY);

			this.Cursor = Cursors.Default;
			if (this.room == null)
			{
				return;
			}

			if (this.room.selectedObject.Count == 1)
			{
				if (this.room.selectedObject[0] is Room_Object lastElement)
				{
					if (this.resizing && this.resizeType != SceneResizing.none)
					{
						this.ResizeObject(lastElement, MX, MY);
						this.updateSelectionObject(lastElement); // That is just updating the texts/options on form
						this.DrawRoom();
						this.Refresh();
						return;
					}

					this.resizeType = SceneResizing.none;

					if ((lastElement.sort & Sorting.Horizontal) == Sorting.Horizontal)
					{
						if (e.X >= (lastElement.X * 8) - 2 &&
							e.X <= ((lastElement.X * 8) + 2) &&
							e.Y >= (lastElement.Y * 8) - 2 &&
							e.Y <= (lastElement.Y * 8) + lastElement.height + 2)
						{
							this.resizeType |= SceneResizing.left;
						}

						if (e.X >= (lastElement.X * 8) + lastElement.width - 2 &&
							e.X <= (lastElement.X * 8) + lastElement.width + 2 &&
							e.Y >= (lastElement.Y * 8) - 2 &&
							e.Y <= (lastElement.Y * 8) + lastElement.height + 2)
						{
							this.resizeType |= SceneResizing.right;
						}
					}

					if ((lastElement.sort & Sorting.Vertical) == Sorting.Vertical)
					{
						if (e.Y >= (lastElement.Y * 8) - 2 &&
							e.Y <= (lastElement.Y * 8) + 2 &&
							e.X >= (lastElement.X * 8) - 2 &&
							e.X <= (lastElement.X * 8) + lastElement.width + 2)
						{
							this.resizeType |= SceneResizing.up;
						}

						if (e.Y >= ((lastElement.Y * 8) + lastElement.height) - 2 &&
							e.Y <= (lastElement.Y * 8) + lastElement.height + 2 &&
													e.X >= (lastElement.X * 8) - 2 &&
							e.X <= (lastElement.X * 8) + lastElement.width + 2)
						{
							this.resizeType |= SceneResizing.down;
						}
					}

					/* debugVariable = (int)resizeType; */

					if (this.resizeType == (SceneResizing.left | SceneResizing.down))
					{
						this.Cursor = Cursors.SizeNESW;
					}
					else if (this.resizeType == (SceneResizing.up | SceneResizing.right))
					{
						this.Cursor = Cursors.SizeNESW;
					}
					else if (this.resizeType == (SceneResizing.up | SceneResizing.left))
					{
						this.Cursor = Cursors.SizeNWSE;
					}
					else if (this.resizeType == (SceneResizing.down | SceneResizing.right))
					{
						this.Cursor = Cursors.SizeNWSE;
					}
					else if (this.resizeType == SceneResizing.left || this.resizeType == SceneResizing.right)
					{
						this.Cursor = Cursors.SizeWE;
					}
					else if (this.resizeType == SceneResizing.up || this.resizeType == SceneResizing.down)
					{
						this.Cursor = Cursors.SizeNS;
					}
					else
					{
						this.Cursor = Cursors.Default;
					}

					if (this.resizeType != SceneResizing.none)
					{
						return;
					}
				}
			}

			if (this.selectedMode == ObjectMode.EntrancePlacing)
			{
				if (this.mainForm.selectedEntrance != null)
				{
					int ey = 512 * (this.room.index >> 4);
					int ex = 512 * (this.room.index & 0xF);
					int adjustedMouseX = MX;
					int adjustedMouseY = MY;

					Entrance sel = this.mainForm.selectedEntrance;
					if (this.mainForm.gridEntranceCheckbox.Checked)
					{
						// Limit the positions to multiples of 8.
						adjustedMouseX &= ~0x7;
						adjustedMouseY &= ~0x7;
					}

					sel.XPosition = (ushort) (adjustedMouseX + ex);
					sel.YPosition = (ushort) (adjustedMouseY + ey);

					// 128 - 383 is the valid X range where the camera can be placed and 112 - 392 is the valid Y range where the camera can be placed.
					// Any less or more than the valid would result in the camera showing outside of the room and the camera not clipping correctly to walls.
					sel.CameraTriggerX = Utils.Clamp((ushort) (adjustedMouseX += 7), Constants.CameraTriggerXLow, Constants.CameraTriggerXHigh);
					sel.CameraTriggerY = Utils.Clamp((ushort) adjustedMouseY, Constants.CameraTriggerYLow, Constants.CameraTriggerYHigh);

					sel.ScrollQuadrant = 0x00;

					// TODO: Document all of these magic numbers.
					if (MX >= 256)
					{
						sel.ScrollQuadrant |= 0x10;
					}

					if (adjustedMouseY >= 256)
					{
						sel.ScrollQuadrant |= 0x02;
					}

					if ((ushort) (sel.YPosition % 512) <= 150)
					{
						sel.CameraX = (ushort) ey;
					}
					else if ((ushort) (sel.YPosition % 512) >= 350)
					{
						sel.CameraX = (ushort) (ey + 256 + 16);
					}
					else
					{
						sel.CameraX = (ushort) (sel.YPosition - 112);
					}

					if ((ushort) (sel.XPosition % 512) <= 150)
					{
						sel.CameraY = (ushort) ex;
					}
					else if ((ushort) (sel.XPosition % 512) >= 350)
					{
						sel.CameraY = (ushort) (ex + 256);
					}
					else
					{
						sel.CameraY = (ushort) (sel.XPosition - 128);
					}

					this.mainForm.selectedEntrance.CameraBoundaryQN = (byte) (this.mainForm.selectedEntrance.CameraX >> 8);
					this.mainForm.selectedEntrance.CameraBoundaryFN = (byte) (this.mainForm.selectedEntrance.CameraX >> 8 & 0xFE);
					this.mainForm.selectedEntrance.CameraBoundaryQS = (byte) (this.mainForm.selectedEntrance.CameraX >> 8);
					this.mainForm.selectedEntrance.CameraBoundaryFS = (byte) (this.mainForm.selectedEntrance.CameraX >> 8 | 0x01);
					this.mainForm.selectedEntrance.CameraBoundaryQW = (byte) (this.mainForm.selectedEntrance.CameraY >> 8);
					this.mainForm.selectedEntrance.CameraBoundaryFW = (byte) (this.mainForm.selectedEntrance.CameraY >> 8 & 0xFE);
					this.mainForm.selectedEntrance.CameraBoundaryQE = (byte) (this.mainForm.selectedEntrance.CameraY >> 8);
					this.mainForm.selectedEntrance.CameraBoundaryFE = (byte) (this.mainForm.selectedEntrance.CameraY >> 8 | 0x01);

					this.DrawRoom();
					this.Refresh();
					return;
				}
			}

			bool colliding_chest = false;
			if (this.selectedMode == ObjectMode.Chestmode)
			{
				foreach (Chest c in this.room.chest_list)
				{
					if (MX >= (c.x * 8) && MY >= (c.y * 8) - 16 && MX <= (c.x * 8) + 16 && MY <= (c.y * 8) + 16)
					{
						this.mainForm.toolTip1.Show(ChestItems_Name.name[c.item] + " " + c.item.ToString("X2"), this, new Point(e.X, e.Y + 16));
						colliding_chest = true;
					}
				}
			}

			if (!colliding_chest)
			{
				this.mainForm.toolTip1.Hide(this);
			}

			if (this.mouse_down) // Slowdown problem in save caused by something here
			{
				/* updating_info = true; */

				this.setMouseSizeMode(e); // Define the size of mx,my for each mode
				if (this.selectedMode != ObjectMode.Doormode)
				{
					if (this.mx != this.last_mx || this.my != this.last_my)
					{
						this.need_refresh = true;

						if (this.room.selectedObject.Count > 0)
						{
							this.move_objects();
							this.room.has_changed = true;
							this.last_mx = this.mx;
							this.last_my = this.my;
							this.updateSelectionObject(this.room.selectedObject[0]);
						}
					}
				}
				else // If it is a door
				{
					if (this.room.selectedObject.Count > 0 &&
						this.room.selectedObject[0] is object_door dobj &&
						this.doorArray != null)
					{
						for (int i = 0; i < 48; i++)
						{
							Rectangle r = this.doorArray[i];
							if (this.lastSelectedRectangle != r && new Rectangle(MX, MY, 1, 1).IntersectsWith(r))
							{
								this.lastSelectedRectangle = r;
								int doordir = i / 12;
								if (dobj.door_pos != (byte) ((i * 2) - (doordir * 12)) ||
									dobj.door_dir != (byte) doordir)
								{
									dobj.door_pos = (byte) ((i - (doordir * 12)) * 2);
									dobj.door_dir = (byte) doordir;
									dobj.updateId();
									dobj.Draw();
									this.room.has_changed = true;
								}

								break;
							}
						}
					}
				}

				this.DrawRoom();
				this.Refresh();
			}
		}

		public void move_objects()
		{
			foreach (Object o in room.selectedObject)
			{
				if (o is Sprite sp)
				{
					sp.nx = (byte) (sp.x + move_x);
					sp.ny = (byte) (sp.y + move_y);

					if (sp.nx > 80)
					{
						sp.nx = 0;
					}
					if (sp.ny > 80)
					{
						sp.ny = 0;
					}
				}
				else if (o is PotItem pp)
				{
					pp.nx = (byte) (pp.x + move_x);
					pp.ny = (byte) (pp.y + move_y);

					if (pp.nx > 80)
					{
						pp.nx = 0;
					}
					if (pp.ny > 80)
					{
						pp.ny = 0;
					}
				}
				else if (o is Room_Object ro)
				{
					ro.nx = (byte) (ro.X + move_x);
					ro.ny = (byte) (ro.Y + move_y);

					if (ro.nx > 80)
					{
						ro.nx = 0;
					}
					if (ro.ny > 80)
					{
						ro.ny = 0;
					}
				}
			}
		}

		private unsafe void SceneUW_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			if (room == null)
			{
				g.Clear(this.BackColor);

				return;
			}

			// TODO can this be an or statement?
			if (mainForm.x2zoom)
			{
				g = Graphics.FromImage(tempBitmap);
			}

			if (forPreview)
			{
				g = Graphics.FromImage(tempBitmap);
			}

			g.SetClip(Constants.Rect_0_0_512_512);
			g.Clear(Color.Black);

			if (room.bg2 != Background2.Translucent || room.bg2 != Background2.Transparent || room.bg2 != Background2.OnTop || room.bg2 != Background2.Off)
			{
				g.DrawImage(GFX.roomBg2Bitmap, 0, 0);
			}

			//e.Graphics.DrawImage(GFX.roomBgLayoutBitmap,0,0);
			g.DrawImage(GFX.roomBg1Bitmap, 0, 0);

			if (room.bg2 == Background2.Translucent || room.bg2 == Background2.Transparent)
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
				   ColorAdjustType.Bitmap);

				//GFX.roomBg2Bitmap.MakeTransparent(Color.Black);
				g.DrawImage(GFX.roomBg2Bitmap, Constants.Rect_0_0_512_512, 0, 0, 512, 512, GraphicsUnit.Pixel, imageAtt);
			}
			else if (room.bg2 == Background2.OnTop)
			{
				g.DrawImage(GFX.roomBg2Bitmap, 0, 0);
			}

			//e.Graphics.DrawImage(GFX.currentgfx16Bitmap, 0, -256);
			drawSelection(g);

			drawGrid(g);
			int superY = (room.index / 16);
			int superX = room.index - (superY * 16);

			int roomX = superX * 512;
			int roomY = superY * 512;

			if (mainForm.entranceCameraToolStripMenuItem.Checked)
			{
				if (mainForm.selectedEntrance != null)
				{
					int localCameraX = mainForm.selectedEntrance.CameraTriggerX - 128;
					int localCameraY = mainForm.selectedEntrance.CameraTriggerY - 116;

					g.DrawRectangle(Pens.Orange, new Rectangle(localCameraX, localCameraY, 256, 224));
					//Console.WriteLine(localCameraX + "," + localCameraY);
				}
			}

			if (mainForm.entrancePositionToolStripMenuItem.Checked)
			{
				if (mainForm.selectedEntrance != null)
				{
					int xpos = mainForm.selectedEntrance.XPosition - roomX;
					int ypos = mainForm.selectedEntrance.YPosition - roomY;
					g.DrawLine(Pens.White, xpos - 4, ypos, xpos + 4, ypos);
					g.DrawLine(Pens.White, xpos, ypos - 4, xpos, ypos + 4);
				}
			}

			//e.Graphics.DrawImage(GFX.roomObjectsBitmap,0,0);
			//e.Graphics.DrawImage(GFX., 0, -512);
			//drawText(e.Graphics,4,4, "This is a test? []()abc 1234567890-+");
			int stairCount = 0;
			int chestCount = 0;
			int doorCount = 0;

			foreach (Room_Object o in room.tilesObjects)
			{
				if (mainForm.showChestIDs && (o.id == 0xF99 || o.id == 0xFB1))
				{
					drawText(g, (o.nx * 8) + 6, (o.ny * 8) + 8, chestCount.ToString());
					chestCount++;
				}

				if (mainForm.invisibleObjectsTextToolStripMenuItem.Checked)
				{
					if (o.id == 0xFF3)
					{
						drawText(e.Graphics, o.X * 8, o.Y * 8, "BG2\nFull\nMask");
					}
					else if (o.id == 0xFAA)
					{
						drawText(e.Graphics, o.X * 8, o.Y * 8, "Lamp");
					}
					else if (o.id == 0xAD)
					{
						drawText(e.Graphics, o.X * 8, o.Y * 8, "AD ?");
					}
					else if (o.id == 0xAE)
					{
						drawText(e.Graphics, o.X * 8, o.Y * 8, "AE ?");
					}
					else if (o.id == 0xAF)
					{
						drawText(e.Graphics, o.X * 8, o.Y * 8, "AF ?");
					}
				}
				// TODO copy

				if (mainForm.showDoorsIDs && o.options == ObjectOption.Door)
				{
					if (mainForm.showDoorsIDs)
					{
						drawText(g, (o.X * 8) + 12, (o.Y * 8), doorCount.ToString());
					}

					doorCount++;
					if ((o.id >> 8) == 18) // Exit door
					{
						drawText(g, (o.X * 8) + 6, (o.Y * 8) + 8, "Exit");
					}
					else if ((o.id >> 8) == 0x16) // Exit door
					{
						drawText(g, (o.X * 8) + 6, (o.Y * 8) + 8, "to");
						drawText(g, (o.X * 8) + 4, (o.Y * 8) + 16, "bg2");
					}
				}

				if (o.options == ObjectOption.Block)
				{
					g.DrawImage(GFX.moveableBlock, o.nx * 8, o.ny * 8);
				}

				if (mainForm.showStairIDs && doorsObject.Contains(o.id))
				{
					drawText(g, o.nx * 8, o.ny * 8, "to : " + room.staircase_rooms[stairCount].ToString());
					stairCount++;
				}
			}

			if (mainForm.showSpriteText)
			{
				foreach (Sprite spr in room.sprites)
				{
					drawText(g, spr.nx * 16, spr.ny * 16, spr.name);
				}
			}

			if (mainForm.showChestText)
			{
				foreach (Chest c in room.chest_list)
				{
					drawText(g, c.x * 8, c.y * 8, ChestItems_Name.name[c.item]);
				}
			}

			if (mainForm.showItemsText)
			{
				foreach (PotItem c in room.pot_items)
				{
					int dropboxid = c.id;
					if ((c.id & 0x80) == 0x80) // It is a special object
					{
						dropboxid = ((c.id - 0x80) / 2) + 0x17; // No idea if it will work
					}

					// If for some reason the dropboxid >= 28
					if (dropboxid >= 28)
					{
						dropboxid = 27; // Prevent crash :yay:
					}

					drawText(g, c.nx * 8, c.ny * 8, ItemsNames.name[dropboxid]);
				}
			}

			drawDoorsPosition(g);
			if (mainForm.x2zoom)
			{
				e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
				e.Graphics.DrawImage(tempBitmap, Constants.Rect_0_0_1024_1024);
			}

			if (selectedMode == ObjectMode.CollisionMap)
			{
				for (int i = 0; i < 4096; i++)
				{
					if (room.collisionMap[i] != 0xFF)
					{
						drawText(e.Graphics, ((i % 64) * 16) + 4, (((i / 64) * 16)) + 4, room.collisionMap[i].ToString("X2"));
					}
				}
			}

			// @scawful: Test for collision layout code 
			Task.Factory.StartNew(() =>
			{
				if (Console.ReadKey().Key == ConsoleKey.UpArrow)
				{
					room.loadCollisionLayout(true);
				}
			});
		}

		public void drawDoorsPosition(Graphics g)
		{
			if (mouse_down && room.selectedObject.Count > 0 && room.selectedObject[0] is Room_Object rr)
			{
				if ((rr.options & ObjectOption.Door) == ObjectOption.Door)
				{
					//for (int i = 0; i < 12; i++)
					//{
					g.DrawRectangles(Constants.ThirdGreenPen, doorArray);
					//drawText(g,doorArray)
					//}
				}
			}
		}

		public override void Clear()
		{
			// TODO: Add something here?
			//graphics.Clear(this.BackColor);
		}

		private void onMouseDown(object sender, MouseEventArgs e)
		{
			if (room == null)
			{
				return;
			}

			mainForm.GetXYMouseBasedOnZoom(e, out int MX, out int MY);

			//this.Focus();
			mainForm.activeScene = this;

			room.has_changed = true;
			mainForm.CheckAnyChanges();

			if (selectedMode == ObjectMode.EntrancePlacing)
			{
				mainForm.entrancetreeView_AfterSelect(MX, MY);
				selectedMode = ObjectMode.Bgallmode;
				return;
			}

			if ((byte) selectedMode >= 0 && (byte) selectedMode <= 3)
			{
				if (room.selectedObject.Count == 1 && resizeType != SceneResizing.none)
				{
					//Room_Object obj = (room.selectedObject[0] as Room_Object);
					mouse_down = true;
					resizing = true;
					dragx = MX;
					dragy = MY;
					return;
				}
			}

			if (mainForm.tabControl1.SelectedIndex == 1) // If we are on object tab
			{
				if ((byte) selectedMode <= 2) // If selected mode == bg1,bg2,bg3
				{
					if (selectedDragObject != null) // If there's an object selected
					{
						room.selectedObject.Clear(); // Clear the object buffer

						// Add the new object in the buffer
						Room_Object ro = room.addObject(selectedDragObject.ID, 0, 0, 0, (byte) selectedMode);

						if (ro != null)
						{
							ro.setRoom(room);
							ro.getObjectSize();
							room.tilesObjects.Add(ro);
							room.selectedObject.Add(ro);
							dragx = 0;
							dragy = 0;
						}

						room.has_changed = true;
						mouse_down = true;
						selectedDragObject = null;
						mainForm.objectViewer1.selectedObject = null;
						mainForm.objectViewer1.Refresh();
					}
				}
				else if (selectedDragObject != null) // If there's an object selected
				{
					selectedDragObject = null; // Set the object null
					mainForm.objectViewer1.selectedIndex = -1;
					mainForm.objectViewer1.selectedObject = null;
					mainForm.objectViewer1.Refresh();
					mouse_down = false;

					MessageBox.Show("Objects can only be placed while working on backgrounds 1, 2, or 3.");
					return;
				}
			}
			else if (mainForm.tabControl1.SelectedIndex == 2)
			{
				if (selectedDragSprite != null)
				{
					room.selectedObject.Clear();

					Sprite spr = new Sprite(room, (byte) selectedDragSprite.ID, 0, 0, selectedDragSprite.Option, 0);

					if (spr != null)
					{
						mainForm.Update_modes_buttons(mainForm.spritemodeButton, new EventArgs());
						room.selectedObject.Add(spr);
						dragx = 0;
						dragy = 0;
						room.sprites.Add(spr);
					}

					room.has_changed = true;
					mouse_down = true;
					selectedDragObject = null;
					selectedDragSprite = null;

					mainForm.spritesView1.selectedObject = null;
					mainForm.spritesView1.Refresh();
				}
			}

			if (!mouse_down)
			{
				doorArray = new Rectangle[48];
				found = false;

				if (selectedMode == ObjectMode.Spritemode)
				{
					dragx = MX / 16;
					dragy = MY / 16;

					if (room.selectedObject.Count == 1)
					{
						room.selectedObject.Clear();
					}

					foreach (Sprite spr in room.sprites)
					{
						if (isMouseCollidingWith(spr, e))
						{
							if (!spr.selected)
							{
								room.selectedObject.Add(spr);
								found = true;
								break;
							}
						}
					}

					if (!found) // We didnt find any sprites to click on so just clear the selection
					{
						room.selectedObject.Clear();
					}
				}
				else if (selectedMode == ObjectMode.Itemmode)
				{
					dragx = MX / 8;
					dragy = MY / 8;

					if (room.selectedObject.Count == 1)
					{
						foreach (Object o in room.pot_items)
						{
							// TODO: Add something here?
							//(o as PotItem).selected = false;
						}

						room.selectedObject.Clear();
					}

					foreach (PotItem item in room.pot_items)
					{
						if (isMouseCollidingWith(item, e))
						{
							if (!item.selected)
							{
								room.selectedObject.Add(item);
								found = true;
								break;
							}
						}
					}

					if (!found) // We didnt find any items to click on so just clear the selection
					{
						room.selectedObject.Clear();
					}
				}
				else if ((byte) selectedMode >= 0 && (byte) selectedMode <= 3)
				{
					dragx = MX / 8;
					dragy = MY / 8;
					found = false;

					for (int i = room.tilesObjects.Count - 1; i >= 0; i--)
					{
						Room_Object obj = room.tilesObjects[i];
						if (selectedMode != ObjectMode.Bgallmode)
						{
							if ((byte) selectedMode != (byte) obj.Layer)
							{
								continue;
							}
						}

						if (isMouseCollidingWith(obj, e))
						{
							if (room.selectedObject.Count != 0)
							{
								if (room.selectedObject.Contains(obj))
								{
									found = true;
									break;
								}

								if (ModifierKeys != Keys.Shift && ModifierKeys != Keys.Control)
								{
									room.selectedObject.Clear();
								}
							}

							if ((obj.options & ObjectOption.Bgr) != ObjectOption.Bgr && (obj.options & ObjectOption.Door) != ObjectOption.Door && (obj.options & ObjectOption.Torch) != ObjectOption.Torch && (obj.options & ObjectOption.Block) != ObjectOption.Block)
							{
								for (int p = 0; p < obj.collisionPoint.Count; p++)
								{
									//Console.WriteLine(obj.collisionPoint[p].X);
									if (MX >= obj.collisionPoint[p].X && MX <= obj.collisionPoint[p].X + 8
										&& MY >= obj.collisionPoint[p].Y && MY <= obj.collisionPoint[p].Y + 8)
									{
										room.selectedObject.Add(obj);
										found = true;

										break;
									}
								}

								if (found)
								{
									break;
								}
							}
						}
					}

					if (!found) // We didnt find any Tiles to click on so just clear the selection
					{
						if (ModifierKeys != Keys.Shift && ModifierKeys != Keys.Control)
						{
							//Console.WriteLine("we didnt find any object so clear all");
							room.selectedObject.Clear();
						}
					}
				}
				else if (selectedMode == ObjectMode.Doormode)
				{
					// Console.Write("Door mode");
					room.selectedObject.Clear();
					dragx = MX / 8;
					dragy = MY / 8;

					for (int i = room.tilesObjects.Count - 1; i >= 0; i--)
					{
						Room_Object obj = room.tilesObjects[i];
						if (isMouseCollidingWith(obj, e))
						{
							if ((obj.options & ObjectOption.Door) == ObjectOption.Door)
							{
								// We found a door! hooray!
								room.selectedObject.Add(obj);
								obj.selected = true;
								doorArray = room.getAllDoorPosition(obj);
								need_refresh = true;

								break;
							}
						}
					}
				}
				else if (selectedMode == ObjectMode.Blockmode)
				{
					room.selectedObject.Clear();
					dragx = MX / 8;
					dragy = MY / 8;

					for (int i = room.tilesObjects.Count - 1; i >= 0; i--)
					{
						Room_Object obj = room.tilesObjects[i];
						if (isMouseCollidingWith(obj, e))
						{
							if ((obj.options & ObjectOption.Bgr) != ObjectOption.Bgr && (obj.options & ObjectOption.Block) == ObjectOption.Block)
							{
								room.selectedObject.Add(obj);
								need_refresh = true;

								break;
							}
						}
					}
				}
				else if (selectedMode == ObjectMode.Torchmode)
				{
					room.selectedObject.Clear();
					dragx = MX / 8;
					dragy = MY / 8;

					for (int i = room.tilesObjects.Count - 1; i >= 0; i--)
					{
						Room_Object obj = room.tilesObjects[i];
						if (isMouseCollidingWith(obj, e))
						{
							if ((obj.options & ObjectOption.Bgr) != ObjectOption.Bgr && (obj.options & ObjectOption.Torch) == ObjectOption.Torch)
							{
								// We found a door
								room.selectedObject.Add(obj);
								need_refresh = true;
								DrawRoom();
								Refresh();

								break;
							}
						}
					}
				}
				else if (selectedMode == ObjectMode.Warpmode)
				{
					room.selectedObject.Clear();
					dragx = MX / 8;
					dragy = MY / 8;
					int doorCount = 0;
					foreach (Room_Object o in room.tilesObjects)
					{
						if (doorsObject.Contains(o.id))
						{
							if (isMouseCollidingWith(o, e))
							{
								string warpid = Interaction.InputBox("New Warp Room", "Room Id", room.staircase_rooms[doorCount].ToString("X2"));

								if (byte.TryParse(warpid, NumberStyles.HexNumber, null, out byte b))
								{
									room.staircase_rooms[doorCount] = b;
									updateRoomInfos(mainForm);
								}
								else
								{
									MessageBox.Show(UIText.Range0toFF);
								}
							}

							doorCount++;
						}
						else if (o.id == 0xFCA)
						{
							if (isMouseCollidingWith(o, e))
							{
								string warpid = Interaction.InputBox("New Warp Room", "Room Id", room.holewarp.ToString("X2"));
								if (byte.TryParse(warpid, NumberStyles.HexNumber, null, out byte b))
								{
									room.holewarp = b;
									updateRoomInfos(mainForm);
								}
								else
								{
									MessageBox.Show(UIText.Range0toFF);
								}
							}
						}
					}
				}
				else if (selectedMode == ObjectMode.CollisionMap)
				{
					// What happens when the mouse is clicked in the Collision map mode
					if (e.Button == MouseButtons.Left)
					{
						int px = e.X / 16;
						int py = e.Y / 16;

						room.collisionMap[px + (py * 64)] = (byte) mainForm.tileTypeCombobox.SelectedIndex;
					}
				}

				mouse_down = true;
				move_x = 0;
				move_y = 0;
				mx = dragx;
				my = dragy;
				last_mx = mx;
				last_my = my;
			}

			mainForm.spritepropertyPanel.Visible = false;
			mainForm.potitemobjectPanel.Visible = false;
			mainForm.doorselectPanel.Visible = false;
			mainForm.litCheckbox.Visible = false;
			updating_info = false;

			if (room.selectedObject.Count > 0)
			{
				if (room.selectedObject[0] is Room_Object oo)
				{
					updating_info = true;

					if (oo.options == ObjectOption.Door)
					{
						string name = oo.name;
						string id = oo.id.ToString("X4");
						mainForm.comboBox1.Enabled = false;
						mainForm.selectedGroupbox.Text = "Selected object: " + id + " " + name + "";
						mainForm.doorselectPanel.Visible = true;
						mainForm.doorselectPanel.BringToFront();
						int[] aposes = mainForm.DoorIndex.Select((s, i) => new { s, i }).Where(x => x.s == (oo as object_door).door_type).Select(x => x.i).ToArray();
						int apos = 0;

						if (aposes.Length > 0)
						{
							apos = aposes[0];
						}

						mainForm.comboBox2.SelectedIndex = apos;
						for (int i = 0; i < room.tilesObjects.Count; i++)
						{
							if (room.tilesObjects[i] == oo)
							{
								// TODO: Add something here?
								//mainForm.selectedZUpDown.Value = i;
							}
						}

						updateSelectionObject(oo);
					}
					else if (oo.options == ObjectOption.Torch)
					{
						mainForm.selectedGroupbox.Text = UIText.FormatSelectedObject(oo);
						updating_info = true;
						mainForm.litCheckbox.Visible = true;
						mainForm.litCheckbox.Checked = oo.lit;
						updateSelectionObject(oo);
						updating_info = false;
					}
					else
					{
						mainForm.comboBox1.Enabled = false;

						mainForm.selectedGroupbox.Text = UIText.FormatSelectedObject(oo);

						for (int i = 0; i < room.tilesObjects.Count; i++)
						{
							if (room.tilesObjects[i] == oo)
							{
								// TODO: Add something here?
								//mainForm.selectedZUpDown.Value = i;
							}
						}

						updateSelectionObject(oo);
					}
				}
				else if (room.selectedObject[0] is Sprite sp)
				{
					mainForm.spritepropertyPanel.Visible = true;
					mainForm.spritepropertyPanel.BringToFront();
					updating_info = true;
					string name = Sprites_Names.name[sp.id];
					if ((sp.subtype & 0x07) == 0x07)
					{
						if (sp.id <= 0x1A && sp.id > 0x00)
						{
							name = Sprites_Names.overlordnames[sp.id - 1];
						}

						mainForm.spriteoverlordCheckbox.Checked = true;
					}
					else
					{
						mainForm.spriteoverlordCheckbox.Checked = false;
					}

					mainForm.selectedGroupbox.Text = UIText.FormatSelectedSprite(sp, name);
					mainForm.comboBox1.Enabled = true;
					updateSelectionObject(sp);
				}
				else if (room.selectedObject[0] is PotItem pp)
				{
					updating_info = true; // ?
					mainForm.potitemobjectPanel.Visible = true; // oO why this is not appearing
					mainForm.potitemobjectPanel.BringToFront();
					int dropboxid = pp.id;

					if ((pp.id & 0x80) == 0x80) // It is a special object
					{
						dropboxid = ((pp.id - 0x80) / 2) + 0x17; // No idea if it will work
					}

					// If for some reason the dropboxid >= 28
					if (dropboxid >= 28)
					{
						dropboxid = 27; // Prevent crash :yay:
					}

					mainForm.selectedGroupbox.Text = UIText.FormatSelectedPotItem(pp, ItemsNames.name[dropboxid]);
					mainForm.selecteditemobjectCombobox.SelectedIndex = dropboxid;
					updateSelectionObject(pp);
					updating_info = false;
				}
			}

			updating_info = false;
		}

		public unsafe void ClearBgGfx()
		{
			byte* bg1data = (byte*) GFX.roomBg1Ptr.ToPointer();
			byte* bg2data = (byte*) GFX.roomBg2Ptr.ToPointer();

			for (int i = 0; i < 512 * 512; i++)
			{
				bg1data[i] = 0;
				bg2data[i] = 0;
			}
		}

		public unsafe void DrawRoom()
		{
			if (room == null)
			{
				return;
			}

			//Tile t = new Tile(0, false, false, 0, 0);
			//t.Draw(0, 0);
			ClearBgGfx(); // Technically not required

			if (showLayer1)
			{
				room.DrawFloor1();
			}

			if (room.bg2 != Background2.Off)
			{
				SetPalettesTransparent();
				if (showLayer2)
				{
					room.DrawFloor2();
				}
			}
			else
			{
				SetPalettesBlack();
			}

			room.reloadLayout();

			foreach (Room_Object o in room.tilesLayoutObjects)
			{
				o.collisionPoint.Clear();
				o.Draw();
			}

			// Draw object on bitmap

			// TODO can these ifs be merged?
			foreach (Room_Object o in room.tilesObjects)
			{
				if (o.Layer != Room_Object.LayerType.BG3)
				{
					o.collisionPoint.Clear();
					o.Draw();
				}

				if (o.options == ObjectOption.Door)
				{
					o.collisionPoint.Clear();
					o.Draw();
				}
			}

			foreach (Room_Object o in room.tilesObjects)
			{
				// Draw doors here since they'll all be put on bg3 anyways
				if (o.Layer == Room_Object.LayerType.BG3)
				{
					o.collisionPoint.Clear();
					o.Draw();
				}
			}

			if (showLayer1)
			{
				GFX.DrawBG1();
			}
			if (showLayer2)
			{
				GFX.DrawBG2();
			}
			if (mainForm.showSprite)
			{
				room.drawSprites();
			}
			if (mainForm.showChest)
			{
				drawChests();
			}
			if (mainForm.showItems)
			{
				room.drawPotsItems();
			}

			mainForm.cgramViewer.Refresh();
		}

		public void drawChests()
		{
			if (room.chest_list.Count > 0)
			{
				int chest_count = 0;
				foreach (Room_Object o in room.tilesObjects)
				{
					if ((o.options & ObjectOption.Chest) == ObjectOption.Chest)
					{
						if (room.chest_list.Count > chest_count)
						{
							room.chest_list[chest_count].x = o.nx;
							room.chest_list[chest_count].y = o.ny;
							if (o.id == 0xFB1)
							{
								room.chest_list[chest_count].bigChest = true;
							}
						}

						chest_count++;
					}
				}

				foreach (Chest c in room.chest_list)
				{
					if (c.item <= 75)
					{
						//g.DrawRectangle(Pens.Blue,(c.x * 8), (c.y - 2) * 8, 16, 16);

						if (c.bigChest)
						{
							c.ItemsDraw(c.item, (c.x + 1) * 8, (c.y - 2) * 8);
						}
						else
						{
							c.ItemsDraw(c.item, c.x * 8, (c.y - 2) * 8);
						}

						//graphics.DrawImage(GFX.chestitems_bitmap[c.item], (c.x * 8), (c.y - 2) * 8);
					}
				}
			}
		}

		public void drawGrid(Graphics graphics)
		{
			if (showGrid)
			{
				int s = mainForm.gridSize;
				int wh = (512 / s) + 1;

				for (int x = 0; x < wh; x++)
				{
					graphics.DrawLine(Constants.HalfWhitePen, x * s, 0, x * s, 512);
				}

				for (int y = 0; y < wh; y++)
				{
					graphics.DrawLine(Constants.HalfWhitePen, 0, y * s, 512, y * s);
				}
			}
		}

		public void SetPalettesTransparent()
		{
			int pindex = 0;
			ColorPalette palettes = GFX.roomBg1Bitmap.Palette;
			for (int y = 0; y < GFX.loadedPalettes.GetLength(1); y++)
			{
				for (int x = 0; x < GFX.loadedPalettes.GetLength(0); x++)
				{
					palettes.Entries[pindex++] = GFX.loadedPalettes[x, y];
				}
			}

			for (int y = 0; y < GFX.loadedSprPalettes.GetLength(1); y++)
			{
				for (int x = 0; x < GFX.loadedSprPalettes.GetLength(0); x++)
				{
					if (pindex < 256)
					{
						palettes.Entries[pindex++] = GFX.loadedSprPalettes[x, y];
					}
				}
			}

			for (int i = 0; i < 16; i++)
			{
				palettes.Entries[i * 16] = Color.Transparent;
				palettes.Entries[(i * 16) + 8] = Color.Transparent;
			}

			GFX.roomBg1Bitmap.Palette = palettes;
			GFX.roomBg2Bitmap.Palette = palettes;
			GFX.roomBgLayoutBitmap.Palette = palettes;
		}

		public void SetPalettesBlack()
		{
			int pindex = 0;
			ColorPalette palettes = GFX.roomBg1Bitmap.Palette;
			for (int y = 0; y < GFX.loadedPalettes.GetLength(1); y++)
			{
				for (int x = 0; x < GFX.loadedPalettes.GetLength(0); x++)
				{
					palettes.Entries[pindex++] = GFX.loadedPalettes[x, y];
				}
			}

			for (int i = 0; i < 16; i++)
			{
				palettes.Entries[i * 16] = Color.Black;
				palettes.Entries[(i * 16) + 8] = Color.Black;
			}

			GFX.roomBg1Bitmap.Palette = palettes;
			GFX.roomBg2Bitmap.Palette = palettes;
			GFX.roomBgLayoutBitmap.Palette = palettes;
		}

		private unsafe void onMouseUp(object sender, MouseEventArgs e)
		{
			resizing = false;
			if (mouse_down)
			{
				setMouseSizeMode(e);

				mouse_down = false;
				if (room.selectedObject.Count == 0) // If we don't have any objects select we select what is in the rectangle
				{
					getObjectsRectangle();
				}
				else
				{
					setObjectsPosition();
				}

				if (e.Button == MouseButtons.Right) // That's a problem
				{
					rmx = e.X;
					rmy = e.Y;
					mainForm.nothingselectedcontextMenu.Items[0].Enabled = true;
					mainForm.singleselectedcontextMenu.Items[0].Enabled = true;
					mainForm.groupselectedcontextMenu.Items[0].Enabled = true;
					mainForm.nothingselectedcontextMenu.Items[0].Visible = true;
					mainForm.singleselectedcontextMenu.Items[0].Visible = true;
					mainForm.groupselectedcontextMenu.Items[0].Visible = true;
					string nname = null;

					// TODO copy
					switch (selectedMode)
					{
						case ObjectMode.Chestmode:
							nname = "chest item";
							mainForm.nothingselectedcontextMenu.Items[2].Visible = true;
							mainForm.nothingselectedcontextMenu.Items[3].Visible = false;
							break;

						case ObjectMode.Itemmode:
							nname = "pot item";
							break;

						case ObjectMode.Blockmode:
							nname = "pushable block";
							break;

						case ObjectMode.Torchmode:
							nname = "torch";
							break;

						case ObjectMode.Doormode:
							nname = "door";
							break;

						case ObjectMode.CollisionMap:
							nname = "custom collision map";
							mainForm.nothingselectedcontextMenu.Items[0].Visible = false;
							mainForm.nothingselectedcontextMenu.Items[1].Visible = false;
							mainForm.nothingselectedcontextMenu.Items[2].Visible = true;
							mainForm.nothingselectedcontextMenu.Items[3].Visible = true;
							break;

						case ObjectMode.Spritemode:
							mainForm.nothingselectedcontextMenu.Items[0].Visible = false;
							mainForm.nothingselectedcontextMenu.Items[2].Visible = false;
							mainForm.nothingselectedcontextMenu.Items[3].Visible = false;
							mainForm.singleselectedcontextMenu.Items[0].Visible = false;
							mainForm.groupselectedcontextMenu.Items[0].Visible = false;
							break;

						case ObjectMode.Bg1mode:
						case ObjectMode.Bg2mode:
						case ObjectMode.Bg3mode:
						case ObjectMode.Bgallmode:
							mainForm.nothingselectedcontextMenu.Items[0].Visible = false;
							mainForm.nothingselectedcontextMenu.Items[2].Visible = false;
							mainForm.nothingselectedcontextMenu.Items[3].Visible = false;
							mainForm.singleselectedcontextMenu.Items[0].Visible = false;
							mainForm.groupselectedcontextMenu.Items[0].Visible = false;
							break;
					}


					if (nname != null)
					{
						string s = string.Format("Insert new {0}", nname);
						mainForm.nothingselectedcontextMenu.Items[0].Text = s;
						mainForm.singleselectedcontextMenu.Items[0].Text = s;
						mainForm.groupselectedcontextMenu.Items[0].Text = s;
					}

					if (room.selectedObject.Count == 0)
					{
						mainForm.nothingselectedcontextMenu.Show(Cursor.Position);
					}
					else if (room.selectedObject.Count == 1)
					{
						mainForm.singleselectedcontextMenu.Show(Cursor.Position);
					}
					else if (room.selectedObject.Count > 1)
					{
						mainForm.groupselectedcontextMenu.Show(Cursor.Position);
					}

					mouse_down = false;
				}
			}

			DrawRoom();
			Refresh();
		}

		private void onMouseDoubleClick(object sender, MouseEventArgs e)
		{
			rmx = e.X;
			rmy = e.Y;
			addChest();
		}

		public void addChest()
		{
			int MX = rmx;
			int MY = rmy;

			if (mainForm.x2zoom)
			{
				MX /= 2;
				MY /= 2;
			}

			if (selectedMode == ObjectMode.Chestmode)
			{
				Chest chestToRemove = null;
				bool foundChest = false;

				foreach (Chest c in room.chest_list)
				{
					if (MX >= (c.x * 8) && MX <= (c.x * 8) + 16 &&
						MY >= ((c.y - 2) * 8) && MY <= ((c.y) * 8) + 16)
					{
						mainForm.chestPicker.button1.Enabled = true; // Enable delete button
						DialogResult result = mainForm.chestPicker.ShowDialog();

						if (result == DialogResult.OK)
						{
							// Change chest item
							if (int.TryParse(mainForm.chestPicker.idtextbox.Text, out int r))
							{
								c.item = (byte) r;
							}

							room.has_changed = true;
						}
						else if (result == DialogResult.Abort)
						{
							chestToRemove = c;
						}

						foundChest = true;
						break;
					}
				}

				if (!foundChest)
				{
					mainForm.chestPicker.button1.Enabled = false; // Disable delete button
					DialogResult result = mainForm.chestPicker.ShowDialog();

					if (result == DialogResult.OK)
					{
						room.has_changed = true;
						// Change chest item
						Chest c = new Chest((byte) (MX / 8), (byte) (MY / 8), (byte) mainForm.chestPicker.chestviewer1.selectedIndex, false, false);
						room.chest_list.Add(c);
					}
				}

				if (chestToRemove != null)
				{
					room.chest_list.Remove(chestToRemove);
				}

				need_refresh = true;
			}
		}

		public void deleteChestItem()
		{
			int MX = rmx;
			int MY = rmy;

			if (mainForm.x2zoom)
			{
				MX /= 2;
				MY /= 2;
			}

			if (selectedMode == ObjectMode.Chestmode)
			{
				Chest chestToRemove = null;

				foreach (Chest c in room.chest_list)
				{
					if (MX >= (c.x * 8) && MX <= (c.x * 8) + 16 &&
						MY >= ((c.y - 2) * 8) && MY <= ((c.y) * 8) + 16)
					{
						//mainForm.chestPicker.button1.Enabled = true;//enable delete button
						//DialogResult result = mainForm.chestPicker.ShowDialog();

						chestToRemove = c;
						break;
					}
				}

				if (chestToRemove != null)
				{
					Console.WriteLine("delete chest item." + chestToRemove.item);

					room.chest_list.Remove(chestToRemove);
				}

				need_refresh = true;
				DrawRoom();
				Refresh();
			}
		}

		public void deleteCollisionMapTile()
		{
			if (selectedMode == ObjectMode.CollisionMap)
			{
				int px = rmx / 16;
				int py = rmy / 16;

				room.collisionMap[px + (py * 64)] = 0xFF;

				need_refresh = true;
				Refresh();
			}
		}

		public void clearCustomCollisionMap()
		{
			if (room == null)
			{
				return;
			}

			int i = 0;
			while (i < 4096)
			{
				room.collisionMap[i++] = 0xFF;
			}

			need_refresh = true;
			Refresh();
		}

		// TODO switch statements
		public void setObjectsPosition()
		{
			if (room.selectedObject.Count > 0)
			{
				if (selectedMode == ObjectMode.Spritemode)
				{
					foreach (Object o in room.selectedObject)
					{
						(o as Sprite).x = (o as Sprite).nx;
						(o as Sprite).y = (o as Sprite).ny;
						//(o as Sprite).boundingbox
					}
				}
				else if (selectedMode == ObjectMode.Itemmode)
				{
					foreach (Object o in room.selectedObject)
					{
						(o as PotItem).x = (o as PotItem).nx;
						(o as PotItem).y = (o as PotItem).ny;
					}
				}
				else if ((byte) selectedMode >= 0 && (byte) selectedMode <= 3)
				{


					foreach (Object o in room.selectedObject)
					{
						(o as Room_Object).X = (o as Room_Object).nx;
						(o as Room_Object).Y = (o as Room_Object).ny;
						(o as Room_Object).ox = (o as Room_Object).X;
						(o as Room_Object).oy = (o as Room_Object).Y;
					}

					if (NetZS.connected)
					{
						SendObjectsData();
					}



				}
				else if (selectedMode == ObjectMode.Torchmode)
				{
					foreach (Object o in room.selectedObject)
					{
						(o as Room_Object).X = (o as Room_Object).nx;
						(o as Room_Object).Y = (o as Room_Object).ny;
						(o as Room_Object).ox = (o as Room_Object).X;
						(o as Room_Object).oy = (o as Room_Object).Y;
					}
				}
				else if (selectedMode == ObjectMode.Blockmode)
				{
					foreach (Object o in room.selectedObject)
					{
						(o as Room_Object).X = (o as Room_Object).nx;
						(o as Room_Object).Y = (o as Room_Object).ny;
						(o as Room_Object).ox = (o as Room_Object).X;
						(o as Room_Object).oy = (o as Room_Object).Y;
					}
				}
			}

			room.has_changed = true;

			/*
            if (mainForm.undoRoom[room.index].Count > 10)
            {
                Room a = mainForm.undoRoom[room.index][0];
                mainForm.undoRoom[room.index].RemoveAt(0);
                a = null;

                mainForm.undoRoom[room.index].Add((Room)room.Clone());
                mainForm.redoRoom[room.index].Clear();
                mainForm.undoButton.Enabled = true;
                mainForm.undoToolStripMenuItem.Enabled = true;
                mainForm.redoButton.Enabled = false;
                mainForm.redoToolStripMenuItem.Enabled = false;
            }
            else
            {
                mainForm.undoRoom[room.index].Add((Room)room.Clone());
                mainForm.redoRoom[room.index].Clear();
                mainForm.undoButton.Enabled = true;
                mainForm.undoToolStripMenuItem.Enabled = true;
                mainForm.redoButton.Enabled = false;
                mainForm.redoToolStripMenuItem.Enabled = false;
            }
            */
		}

		// TODO switch statements and no casting the selected mode
		public void setMouseSizeMode(MouseEventArgs e)
		{
			mainForm.GetXYMouseBasedOnZoom(e, out int MX, out int MY);

			if (selectedMode == ObjectMode.Spritemode)
			{
				mx = MX / 16;
				my = MY / 16;
			}
			else if (selectedMode == ObjectMode.Itemmode)
			{
				mx = MX / 8;
				my = MY / 8;
			}
			else if ((byte) selectedMode >= 0 && (byte) selectedMode <= 3)
			{
				mx = MX / 8;
				my = MY / 8;
			}
			else if (selectedMode == ObjectMode.Torchmode || selectedMode == ObjectMode.Blockmode)
			{
				mx = MX / 8;
				my = MY / 8;
			}

			move_x = mx - dragx; // Number of tiles mouse is compared to starting drag point X
			move_y = my - dragy; // Number of tiles mouse is compared to starting drag point Y
		}

		public bool isMouseCollidingWith(Object o, MouseEventArgs e)
		{
			mainForm.GetXYMouseBasedOnZoom(e, out int MX, out int MY);

			if (o is Sprite objS)
			{
				if (MX >= objS.boundingbox.X && MX <= objS.boundingbox.X + objS.boundingbox.Width &&
				MY >= objS.boundingbox.Y && MY <= objS.boundingbox.Y + objS.boundingbox.Height)
				{
					return true;
				}
			}
			else if (o is PotItem objP)
			{
				if (MX >= (objP.x * 8) && MX <= (objP.x * 8) + 16 &&
					MY >= (objP.y * 8) && MY <= (objP.y * 8) + 16)
				{
					return true;
				}
			}
			else if (o is Room_Object objR)
			{
				//if ((o as Room_Object).layer == (byte)selectedMode || selectedMode == ObjectMode.Bgallmode)
				//{

				int yfix = 0;
				if (objR.diagonalFix)
				{
					yfix = -(6 + objR.Size);
				}

				if (MX >= ((objR.X + objR.offsetX) * 8) && MX <= ((objR.X + objR.offsetX) * 8) + (objR.width) &&
						MY >= ((objR.Y + objR.offsetY + yfix) * 8) && MY <= ((objR.Y + objR.offsetY + yfix) * 8) + (objR.height))
				{
					return true;
				}
				//}
			}

			return false;
		}

		public void getObjectsRectangle()
		{
			if (room.selectedObject.Count == 0)
			{
				if (selectedMode == ObjectMode.Spritemode) // We're looking for sprites
				{
					foreach (Sprite spr in room.sprites)
					{
						int rx = dragx;
						int ry = dragy;
						if (move_x < 0) { Math.Abs(rx = dragx + move_x); }
						if (move_y < 0) { Math.Abs(ry = dragy + move_y); }

						if (spr.boundingbox.IntersectsWith(new Rectangle(rx * 16, ry * 16, Math.Abs(move_x) * 16, Math.Abs(move_y) * 16)))
						{
							room.selectedObject.Add(spr);
						}
					}
				}
				else if (selectedMode == ObjectMode.Itemmode)// wW're looking for pot items
				{
					foreach (PotItem item in room.pot_items)
					{
						int rx = dragx;
						int ry = dragy;
						if (move_x < 0)
						{
							Math.Abs(rx = dragx + move_x);
						}

						if (move_y < 0)
						{
							Math.Abs(ry = dragy + move_y);
						}

						if ((new Rectangle(item.x * 8, item.y * 8, 16, 16)).IntersectsWith(new Rectangle(rx * 8, ry * 8, Math.Abs(move_x) * 8, Math.Abs(move_y) * 8)))
						{
							room.selectedObject.Add(item);
						}
					}
				}
				else if ((byte) selectedMode >= 0 && (byte) selectedMode <= 3) // We're looking for tiles
				{
					foreach (Room_Object o in room.tilesObjects)
					{
						int rx = dragx;
						int ry = dragy;
						if (move_x < 0) { Math.Abs(rx = dragx + move_x); }
						if (move_y < 0) { Math.Abs(ry = dragy + move_y); }

						int yfix = 0;
						if (o.diagonalFix)
						{
							yfix = -(6 + o.Size);
						}

						if ((new Rectangle(
							(o.X + o.offsetX) * 8,
							(o.Y + o.offsetY + yfix) * 8,
							(o.width + o.offsetX),
							(o.height + o.offsetY + yfix))
							).IntersectsWith(new Rectangle(rx * 8, ry * 8, Math.Abs(move_x) * 8, Math.Abs(move_y) * 8)))
						{
							if ((o.options & ObjectOption.Bgr) != ObjectOption.Bgr && (o.options & ObjectOption.Door) != ObjectOption.Door && (o.options & ObjectOption.Torch) != ObjectOption.Torch && (o.options & ObjectOption.Block) != ObjectOption.Block)
							{
								if (selectedMode == ObjectMode.Bgallmode)
								{
									room.selectedObject.Add(o);
								}
								else if ((byte) selectedMode == (byte) o.Layer)
								{
									room.selectedObject.Add(o);
								}
							}
						}
					}
				}
			}

			/*
            foreach(Room_Object o in room.selectedObject)
            {
                Console.WriteLine(o.id.ToString("X4") + o.name);
            }
            */
		}

		private const int garbageobjdata = -999999;
		public void updateSelectionObject(object o)
		{
			if (room.selectedObject.Count == 1)
			{
				int objx = garbageobjdata;
				int objy = garbageobjdata;
				int objs = garbageobjdata;
				int objl = garbageobjdata;
				byte[] objdata = null;

				if (o is Room_Object objR)
				{
					if (objR.nx >= 63)
					{
						objR.nx = 63;
					}

					if (objR.ny >= 63)
					{
						objR.ny = 63;
					}

					if (objR.Size >= 16)
					{
						objR.Size = 0;
					}

					objdata = room.getSelectedObjectHex();
					objx = objR.nx;
					objy = objR.ny;
					objs = objR.Size;
					objl = (int) objR.Layer;

					int z = 0;

					foreach (Room_Object door in room.tilesObjects)
					{
						if (door.options == ObjectOption.Door)
						{
							if (door == o)
							{
								//mainForm.object_z_label.Text = "Z: " + z.ToString(); //where's my door 0 :scream:
								break;
							}

							z++;
						}
					}

					/*
                    if ((o.options & ObjectOption.Door) == ObjectOption.Door)
                    {
                        byte door_pos = (byte)((o.id & 0xF0) >> 3);
                        byte door_dir = (byte)((o.id & 0x03));
                        byte door_type = (byte)((o.id >> 8) & 0xFF);
                        id = o.id.ToString("X4") + "\nDoor Type : " + door_type.ToString("X2");
                        id += "\nDoor Direction : " + door_dir.ToString("X2");
                        id += "\nDoor Position : " + door_pos.ToString("X2");
                    }

                    if ((o.options & ObjectOption.Chest) == ObjectOption.Chest)
                    {
                        id += "\nBig Chest ? : " + room.chest_list[0].bigChest.ToString();
                    }
                    */
				}
				else if (o is object_door)
				{
					object_door dobj = (o as object_door);
					if (dobj.nx >= 63)
					{
						dobj.nx = 63;
					}
					if (dobj.ny >= 63)
					{
						dobj.ny = 63;
					}
					if (dobj.Size >= 16)
					{
						dobj.Size = 0;
					}

					objx = dobj.nx;
					objy = dobj.ny;
					objl = (int) dobj.Layer;
				}
				else if (o is Sprite)
				{
					Sprite spr = (o as Sprite);
					if (spr.nx >= 31)
					{
						spr.nx = 31;
					}
					if (spr.ny >= 31)
					{
						spr.ny = 31;
					}
					if (spr.layer >= 2)
					{
						spr.layer = 1;
					}

					objx = spr.nx;
					objy = spr.ny;
					objl = spr.layer;

					mainForm.spritesubtypeUpDown.Value = spr.subtype;

					mainForm.spriteoverlordCheckbox.Checked = (spr.subtype & 0x07) == 0x07;
					mainForm.comboBox1.SelectedIndex = spr.keyDrop;

					updating_info = false;
					//info = name + "\nId : " + id + "\nX : " + x + "\nY : " + y + "\nLayer : " + layer;
				}
				else if (o is PotItem)
				{
					PotItem poti = (o as PotItem);
					if (poti.nx >= 63)
					{
						poti.nx = 63;
					}
					if (poti.ny >= 63)
					{
						poti.ny = 63;
					}
					if (poti.layer >= 2) // NVM
					{
						poti.layer = 1;
					}

					objx = poti.nx;
					objy = poti.nx;
					objl = poti.layer;
				}


				if (objx != garbageobjdata)
				{
					mainForm.SelectedObjectDataX.Text = objx.ToString("X2");
				}
				else
				{
					mainForm.SelectedObjectDataX.Text = "-";
				}

				if (objy != garbageobjdata)
				{
					mainForm.SelectedObjectDataY.Text = objy.ToString("X2");
				}
				else
				{
					mainForm.SelectedObjectDataY.Text = "-";
				}

				if (objs != garbageobjdata)
				{
					mainForm.SelectedObjectDataSize.Text = objs.ToString("X2");
				}
				else
				{
					mainForm.SelectedObjectDataSize.Text = "-";
				}

				if (objl != garbageobjdata)
				{
					mainForm.SelectedObjectDataLayer.Text = objl.ToString("X2");
				}
				else
				{
					mainForm.SelectedObjectDataLayer.Text = "-";
				}

				if (objdata != null)
				{
					mainForm.SelectedObjectDataHEX.Text =
						string.Format("{0:X2} {1:X2} {2:X2}",
						objdata[0], objdata[1], objdata[2]
						);
				}
				else
				{
					mainForm.SelectedObjectDataHEX.Text = "-";
				}
			}
		}

		/*
        public void Undo()
        {
            if (DungeonsData.undoRoom[room.index].Count > 0)
            {
                DungeonsData.redoRoom[room.index].Add((Room)room.Clone());
                room = DungeonsData.undoRoom[room.index][(DungeonsData.undoRoom[room.index].Count - 1)];
                DungeonsData.undoRoom[room.index].RemoveAt(DungeonsData.undoRoom[room.index].Count - 1);
                updateRoomInfos(mainForm);
                room.reloadGfx();
                DrawRoom();
                Refresh();
                mainForm.redoButton.Enabled = true;
                mainForm.redoToolStripMenuItem.Enabled = true;
            }
            else
            {
                mainForm.undoButton.Enabled = false;
                mainForm.undoToolStripMenuItem.Enabled = false;
            }

            //selection_resize = false;
            //room.selectedObject.Clear();
        }
        */

		/*
        public void Redo()
        {
            if (DungeonsData.redoRoom[room.index].Count > 0)
            {
                DungeonsData.undoRoom[room.index].Add((Room)room.Clone());
                room = DungeonsData.redoRoom[room.index][(DungeonsData.redoRoom[room.index].Count - 1)];
                DungeonsData.redoRoom[room.index].RemoveAt(DungeonsData.redoRoom[room.index].Count - 1);
                updateRoomInfos(mainForm);
                room.reloadGfx();
                DrawRoom();
                Refresh();
                mainForm.undoButton.Enabled = true;
                mainForm.undoToolStripMenuItem.Enabled = true;
            }
            else
            {
                mainForm.redoButton.Enabled = false;
                mainForm.redoToolStripMenuItem.Enabled = false;
            }
        }
        */

		public override void selectAll()
		{
			room.selectedObject.Clear();
			if (selectedMode == ObjectMode.Spritemode)
			{
				foreach (Sprite spr in room.sprites)
				{
					room.selectedObject.Add(spr);
				}
			}

			foreach (Room_Object o in room.tilesObjects)
			{
				if (o.options == ObjectOption.Nothing && ((byte) selectedMode <= 3))
				{
					if (selectedMode == ObjectMode.Bgallmode)
					{
						room.selectedObject.Add(o);
					}
					else if ((byte) this.selectedMode == (byte) o.Layer)
					{
						room.selectedObject.Add(o);
					}
				}
			}

			Refresh();
		}

		public override void deleteSelected()
		{
			room.has_changed = true;
			mainForm.CheckAnyChanges();

			foreach (Object o in room.selectedObject)
			{
				if (o is Room_Object r)
				{
					r.deleted = true;
					room.tilesObjects.Remove(r);
				}
				else if (o is Sprite s)
				{
					room.sprites.Remove(s);
				}
				else if (o is PotItem p)
				{
					room.pot_items.Remove(p);
				}

			}
			SendObjectsData();
			room.selectedObject.Clear();
			DrawRoom();
			Refresh();
		}

		public override void paste()
		{
			if (!mouse_down)
			{
				List<SaveObject> data = null;
				try
				{
					data = (List<SaveObject>) Clipboard.GetData("ObjectZ");
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}

				if (data != null)
				{
					if (data.Count > 0)
					{
						int most_x = 512;
						int most_y = 512;

						foreach (SaveObject o in data)
						{
							if (data.Count > 0)
							{
								if (o.X < most_x)
								{
									most_x = o.X;
								}
								if (o.Y < most_y)
								{
									most_y = o.Y;
								}
							}
							else
							{
								most_x = 0;
								most_y = 0;
							}
						}

						room.selectedObject.Clear();
						foreach (SaveObject o in data)
						{
							if (o.Type == typeof(Sprite))
							{
								selectedMode = ObjectMode.Spritemode;
								Sprite spr = (new Sprite(room, o.ID, (byte) (o.X - most_x), (byte) (o.Y - most_y), o.Subtype, o.Layer));
								room.sprites.Add(spr);
								room.selectedObject.Add(spr);
							}
							else if (o.Type == typeof(Room_Object))
							{
								if ((o.Options & ObjectOption.Door) == ObjectOption.Door)
								{
									selectedMode = ObjectMode.Doormode;
									object_door ro = new object_door(o.TileID, o.X, o.Y, 0, o.Layer);
									ro.setRoom(room);
									ro.options = o.Options;
									room.tilesObjects.Add(ro);
									room.selectedObject.Add(ro);
								}
								else
								{
									Room_Object ro = room.addObject(o.TileID, (byte) (o.X - most_x), (byte) (o.Y - most_y), o.Size, o.Layer);

									if (ro != null)
									{
										if ((byte) selectedMode > 3) // If it not BGAll or bg1-3
										{
											selectedMode = ObjectMode.Bg1mode; // Set it on bg1 by default
										}
										else if ((byte) selectedMode == 3) // If it bgall do nothing
										{
											// TODO: Add something here?
										}
										else // If it actually a layer set the roomobject on the current selected layer
										{
											ro.Layer = (Room_Object.LayerType) this.selectedMode;
										}

										ro.setRoom(room);
										ro.options = o.Options;
										room.tilesObjects.Add(ro);
										room.selectedObject.Add(ro);
									}
								}
							}
							else if (o.Type == typeof(PotItem))
							{
								selectedMode = ObjectMode.Itemmode;
								PotItem item = (new PotItem((byte) o.TileID, (byte) (o.X - most_x), (byte) (o.Y - most_y), o.Layer == 1));
								room.pot_items.Add(item);
								room.selectedObject.Add(item);
							}
						}

						dragx = 0;
						dragy = 0;
						mouse_down = true;
					}

					DrawRoom();
					Refresh();
				}
			}
		}

		public override void copy()
		{
			Clipboard.Clear();
			List<SaveObject> odata = new List<SaveObject>();

			foreach (var o in room.selectedObject)
			{
				if (o is Sprite objS)
				{
					odata.Add(new SaveObject(objS));
					mouse_down = false;
				}
				if (o is PotItem objP)
				{
					odata.Add(new SaveObject(objP));
					mouse_down = false;
				}
				if (o is Room_Object objR)
				{
					odata.Add(new SaveObject(objR));
					mouse_down = false;
				}
			}

			Clipboard.SetData("ObjectZ", odata);
		}

		// TODO copy
		public override void loadLayout()
		{
			string f = Interaction.InputBox("Name of the layout to load", "Name?", "Layout00");
			BinaryReader br = new BinaryReader(new FileStream("Layout\\" + f, FileMode.Open, FileAccess.Read));

			List<SaveObject> data = new List<SaveObject>();

			while (br.BaseStream.Position != br.BaseStream.Length)
			{
				data.Add(new SaveObject(br, typeof(Room_Object)));
			}

			if (data.Count > 0)
			{
				int most_x = 512;
				int most_y = 512;
				foreach (SaveObject o in data)
				{
					if (data.Count > 0)
					{
						if (o.X < most_x)
						{
							most_x = o.X;
						}
						if (o.Y < most_y)
						{
							most_y = o.Y;
						}
					}
					else
					{
						most_x = 0;
						most_y = 0;
					}
				}
				room.selectedObject.Clear();

				foreach (SaveObject o in data)
				{
					if (o.Type == typeof(Sprite))
					{
						Sprite spr = (new Sprite(room, o.ID, (byte) (o.X - most_x), (byte) (o.Y - most_y), o.Subtype, o.Layer));
						room.sprites.Add(spr);
						room.selectedObject.Add(spr);
					}
					else if (o.Type == typeof(Room_Object))
					{
						Room_Object ro = room.addObject(o.TileID, (byte) (o.X - most_x), (byte) (o.Y - most_y), o.Size, o.Layer);
						if (ro != null)
						{
							ro.setRoom(room);
							ro.options = o.Options;
							room.tilesObjects.Add(ro);
							room.selectedObject.Add(ro);
						}
					}
				}

				dragx = 0;
				dragy = 0;
				mouse_down = true;
			}
		}

		public override void cut()
		{
			Clipboard.Clear();
			//Room r = (Room)room.Clone();
			//clearUselessRoomStuff(r);
			room.has_changed = true;
			mainForm.CheckAnyChanges();
			//undoRooms.Add(r);

			var odata = new List<SaveObject>();
			foreach (var o in room.selectedObject)
			{
				if (o is Sprite objS)
				{
					odata.Add(new SaveObject(objS));
				}
				if (o is PotItem objP)
				{
					odata.Add(new SaveObject(objP));
				}
				if (o is Room_Object objR)
				{
					odata.Add(new SaveObject(objR));
					objR.deleted = true;
				}
			}
			SendObjectsData();
			Clipboard.SetData("ObjectZ", odata);

			foreach (var o in room.selectedObject)
			{
				if (o is Sprite objS)
				{
					room.sprites.Remove(objS);
				}
				if (o is PotItem objP)
				{
					room.pot_items.Remove(objP);
				}
				if (o is Room_Object objR)
				{
					room.tilesObjects.Remove(objR);
				}
			}

			room.selectedObject.Clear();
			DrawRoom();
			Refresh();
		}

		// TODO switch statements and magic numbers
		public override void insertNew()
		{
			// If block selected
			if (selectedMode == ObjectMode.Blockmode)
			{
				room.selectedObject.Clear();
				Room_Object ro = room.addObject(0x0E00, 0, 0, 0, 0);

				if (ro != null)
				{
					ro.setRoom(room);
					ro.options = ObjectOption.Block;
					room.tilesObjects.Add(ro);
					room.selectedObject.Add(ro);
					dragx = 0;
					dragy = 0;
					mouse_down = true;
				}
			}
			else if (selectedMode == ObjectMode.Itemmode)
			{
				room.selectedObject.Clear();
				PotItem p = new PotItem(1, 0, 0, false);
				room.pot_items.Add(p);
				room.selectedObject.Add(p);
				dragx = 0;
				dragy = 0;
				mouse_down = true;
			}
			else if (selectedMode == ObjectMode.Chestmode)
			{
				addChest();
			}
			else if (selectedMode == ObjectMode.Torchmode)
			{
				room.selectedObject.Clear();
				Room_Object ro = room.addObject(0x150, 0, 0, 0, 0);
				if (ro != null)
				{
					ro.setRoom(room);
					ro.options = ObjectOption.Torch;
					room.tilesObjects.Add(ro);
					room.selectedObject.Add(ro);
					dragx = 0;
					dragy = 0;
					mouse_down = true;
				}
			}
			else if (selectedMode == ObjectMode.Doormode)
			{
				room.selectedObject.Clear();
				Room_Object ro = new object_door(0, 0, 0, 0, 0);
				if (ro != null)
				{
					ro.setRoom(room);
					ro.options = ObjectOption.Door;
					room.tilesObjects.Add(ro);
					this.Focus();
					mainForm.activeScene = this;
					//room.selectedObject.Add(ro);
				}
			}
			else if ((byte) selectedMode >= 0 && (byte) selectedMode < 3) //if != allbg
			{
				//picker object :thinking:
				//pObj.createObjects(room);
				//pObj.ShowDialog();

				/*
                if (pObj.selectedObject != -1)
                {
                    room.selectedObject.Clear();
                    Room_Object ro = room.addObject(pObj.selectedObject, (byte)0, (byte)0, 0, (byte)selectedMode);
                    if (ro != null)
                    {
                        ro.setRoom(room);
                        ro.get_scroll_x();
                        ro.get_scroll_y();
                        if (ro.special_zero_size != 0)
                        {
                            ro.size = 1;
                        }
       
                        room.tilesObjects.Add(ro);
                        room.selectedObject.Add(ro);
                        dragx = 0;
                        dragy = 0;
                        mouse_down = true;
                        need_refresh = true;
                        room.reloadGfx();
                    }
                }
                */
			}

			DrawRoom();
			Refresh();
		}

		public override void DecreaseSelectedZ()
		{
			if (room.selectedObject.Count > 0)
			{
				if (room.selectedObject[0] is Room_Object)
				{
					foreach (Room_Object o in room.selectedObject)
					{
						for (int i = 0; i < room.tilesObjects.Count; i++)
						{
							if (o == room.tilesObjects[i])
							{
								if (i > 0)
								{
									room.tilesObjects.RemoveAt(i);
									room.tilesObjects.Insert(i - 1, o);
								}

								break;
							}
						}
					}
				}

				DrawRoom();
				Refresh();
				mouse_down = false;
			}
		}

		public override void UpdateSelectedZ(int position)
		{
			if (room.selectedObject.Count > 0)
			{
				if (room.selectedObject[0] is Room_Object)
				{
					foreach (Room_Object o in room.selectedObject)
					{
						for (int i = 0; i < room.tilesObjects.Count; i++)
						{
							if (o == room.tilesObjects[i])
							{
								if (i < room.tilesObjects.Count - 1)
								{
									room.tilesObjects.RemoveAt(i);
									room.tilesObjects.Insert(position, o);
								}

								break;
							}
						}
					}
				}

				DrawRoom();
				Refresh();
				mouse_down = false;
			}
		}

		private void InitializeComponent()
		{
			((System.ComponentModel.ISupportInitialize) (this)).BeginInit();
			this.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this)).EndInit();
			this.ResumeLayout(false);
		}

		public void updateRoomInfos(DungeonMain mainForm)
		{
			mainForm.UpdateUIForRoom(room, true);
		}

		public void SendObjectsData()
		{
			if (!NetZS.connected)
			{
				return;
			}
			NetZSBuffer buffer = new NetZSBuffer((short) ((room.selectedObject.Count * 15) + 12));
			buffer.Write((byte) 19); // tile data cmd
			buffer.Write(NetZS.userID); // user id
			buffer.Write(room.index); //room index 4
			buffer.Write(room.selectedObject.Count); //4
													 //DungeonsData.all_rooms[0].tilesObjects = DungeonsData.all_rooms[0].tilesObjects.OrderBy(x => x.posinarray);

			foreach (object o in room.selectedObject)
			{
				Room_Object roomObject = o as Room_Object;

				buffer.Write(roomObject.uniqueID); // 4bytes

				buffer.Write(roomObject.id);
				buffer.Write(roomObject.X);
				buffer.Write(roomObject.Y);
				buffer.Write(roomObject.ox);
				buffer.Write(roomObject.oy);
				buffer.Write((byte) roomObject.Layer);
				buffer.Write(roomObject.Size);
				buffer.Write((byte) (roomObject.deleted ? 1 : 0));
				short zIndex = 0;

				foreach (object ro in room.tilesObjects)
				{
					if (ro == o)
					{
						break;
					}

					zIndex++;
				}

				buffer.Write(zIndex);
			}

			NetOutgoingMessage msg = NetZS.client.CreateMessage();
			msg.Write(buffer.buffer);
			NetZS.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
			NetZS.client.FlushSendQueue();
		}
	}
}
