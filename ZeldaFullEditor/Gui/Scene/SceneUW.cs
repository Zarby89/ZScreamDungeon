using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using ZeldaFullEditor.Properties;
using Microsoft.VisualBasic;
using System.IO.Compression;
using static ZeldaFullEditor.DungeonMain;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Globalization;

namespace ZeldaFullEditor
{
	public class SceneUW2 : Scene2
	{
		public Bitmap tempBitmap = new Bitmap(512, 512);
		public ushort[] doorsObject = new ushort[] { 0x138, 0x139, 0x13A, 0x13B, 0xF9E, 0xFA9, 0xF9F, 0xFA0, 0x12D, 0x12E, 0x12F, 0x12E, 0x12D, 0x4632, 0x4693 };
		Rectangle lastSelectedRectangle;
		SceneResizing resizeType = SceneResizing.none;

		public bool forPreview = false;

		bool resizing = false;

		int rmx = 0;
		int rmy = 0;

		public SceneUW2(ZScreamer parent) : base(parent)
		{
			//graphics = Graphics.FromImage(scene_bitmap);

			MouseDown += new MouseEventHandler(OnMouseDown);
			MouseUp += new MouseEventHandler(OnMouseUp);
			MouseMove += new MouseEventHandler(OnMouseMove);
			MouseDoubleClick += new MouseEventHandler(OnMouseDoubleClick);
			MouseWheel += new MouseEventHandler(OnMouseWheel);
			Paint += SceneUW_Paint;
		}

		protected void OnMouseWheel(object o, MouseEventArgs e)
		{			
			if (room.selectedObject.Count > 0 && room.selectedObject[0] is Room_Object objs)
			{
				if ((e.Delta > 0 && objs.IncreaseSize()) || (e.Delta < 0 && objs.DecreaseSize()))
				{
					ZS.DungeonForm.UpdateFormForSelectedObject(objs);
				}
			}

			DrawRoom();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
		}

		private void ResizeObject(Room_Object lastElement, int x, int y)
		{
			lastElement.UpdateSize();
			//if (8 != 0)
			//{

			if ((resizeType & SceneResizing.left) == SceneResizing.left)
			{
				if (x <= (dragx - lastElement.sizewidth))
				{
					if (lastElement.size < 15)
					{
						if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
						{
							byte bsize = lastElement.size;
							int sizex = ((bsize >> 2) & 0x03) + 1;
							lastElement.size = (byte) ((sizex << 2) | (bsize & 0x03));
						}
						else
						{
							lastElement.size++;
						}

						lastElement.x -= (byte) (lastElement.sizewidth / 8); // Object length size
						lastElement.nx -= (byte) (lastElement.sizewidth / 8); // Object length size
						dragx -= lastElement.sizewidth;
					}
				}
				else if (x >= (dragx + lastElement.sizewidth))
				{
					if (lastElement.size > 0)
					{
						if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
						{
							byte bsize = lastElement.size;
							int sizex = ((bsize >> 2) & 0x03) - 1;
							lastElement.size = (byte) ((sizex << 2) | (bsize & 0x03));
						}
						else
						{
							lastElement.size--;
						}

						lastElement.x += (byte) (lastElement.sizewidth / 8); // Object length size
						lastElement.nx += (byte) (lastElement.sizewidth / 8); // Object length size
						dragx += lastElement.sizewidth;
					}
				}
			}

			if ((resizeType & SceneResizing.right) == SceneResizing.right)
			{
				if (x >= (dragx + lastElement.sizewidth))
				{
					if (lastElement.size < 15)
					{
						if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
						{
							byte bsize = lastElement.size;
							int sizex = ((bsize >> 2) & 0x03) + 1;
							lastElement.size = (byte) ((sizex << 2) | (bsize * 0x03));
						}
						else
						{
							lastElement.size++;
						}

						//lastElement.x = 16; // Object length size
						dragx += lastElement.sizewidth;
					}
				}
				else if (x <= (dragx - lastElement.sizewidth))
				{
					if (lastElement.size > 0)
					{
						if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
						{
							byte bsize = lastElement.size;
							int sizex = ((bsize >> 2) & 0x03) - 1;
							lastElement.size = (byte) ((sizex << 2) | (bsize & 0x03));
						}
						else
						{
							lastElement.size--;
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
				if (y >= (dragy + lastElement.sizeheight))
				{
					if (lastElement.size < 15)
					{
						if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
						{
							byte bsize = lastElement.size;
							lastElement.size = (byte) ((bsize & 0x0C) | ((bsize & 0x03) + 1));
						}
						else
						{
							//Console.WriteLine(lastElement.sizeheight + "  Base Heigth : " + lastElement.baseheight);
							lastElement.size++;
						}

						//lastElement.x = 16; //object length size
						dragy += lastElement.sizeheight;
					}
				}
				else if (y <= (dragy - lastElement.sizeheight))
				{
					if (lastElement.size > 0)
					{
						if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
						{
							byte bsize = lastElement.size;
							lastElement.size = (byte) ((bsize & 0x0C) | (((bsize) & 0x03) - 1));
						}
						else
						{
							lastElement.size--;
						}

						//lastElement.x += 16; //object length size
						dragy -= lastElement.sizeheight;
					}
				}
			}

			if ((resizeType & SceneResizing.up) == SceneResizing.up)
			{
				if (y <= (dragy - lastElement.sizeheight))
				{
					if (lastElement.size < 15)
					{
						if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
						{
							byte bsize = lastElement.size;
							lastElement.size = (byte) ((bsize & 0x0C) | (((bsize) & 0x03) + 1));
						}
						else
						{
							lastElement.size++;
						}

						lastElement.y -= (byte) (lastElement.sizeheight / 8); // Object length size
						lastElement.ny -= (byte) (lastElement.sizeheight / 8); // Object length size
						dragy -= lastElement.sizeheight;
					}
				}
				else if (y >= (dragy + lastElement.sizeheight))
				{
					if (lastElement.size > 0)
					{
						if (lastElement.sort == (Sorting.Horizontal & Sorting.Vertical))
						{
							byte bsize = lastElement.size;
							lastElement.size = (byte) ((bsize & 0x0C) | (((bsize) & 0x03) - 1));
						}
						else
						{
							lastElement.size--;
						}

						lastElement.y += (byte) (lastElement.sizeheight / 8); // Object length size
						lastElement.ny += (byte) (lastElement.sizeheight / 8); // Object length size
						dragy += lastElement.sizeheight;
					}
				}
			}

			//}
		}

		// TODO: FIND PROBLEM THAT IS INCREASING SAVE TIME!!
		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			ZS.MainForm.GetXYMouseBasedOnZoom(e, out int MX, out int MY);

			Cursor = Cursors.Default;
			if (room == null)
			{
				return;
			}

			if (room.selectedObject.Count == 1)
			{
				if (room.selectedObject[0] is Room_Object lastElement)
				{
					if (resizing && resizeType != SceneResizing.none)
					{
						ResizeObject(lastElement, MX, MY);
						updateSelectionObject(lastElement); // That is just updating the texts/options on form
						DrawRoom();
						Refresh();
						return;
					}

					resizeType = SceneResizing.none;

					if ((lastElement.sort & Sorting.Horizontal) == (Sorting.Horizontal))
					{
						if (e.X >= (lastElement.x * 8) - 2 &&
							e.X <= ((lastElement.x * 8) + 2) &&
							e.Y >= (lastElement.y * 8) - 2 &&
							e.Y <= (lastElement.y * 8) + lastElement.height + 2)
						{
							resizeType |= SceneResizing.left;
						}

						if (e.X >= (lastElement.x * 8) + lastElement.width - 2 &&
							e.X <= (lastElement.x * 8) + lastElement.width + 2 &&
							e.Y >= (lastElement.y * 8) - 2 &&
							e.Y <= (lastElement.y * 8) + lastElement.height + 2)
						{
							resizeType |= SceneResizing.right;
						}
					}

					if ((lastElement.sort & Sorting.Vertical) == (Sorting.Vertical))
					{
						if (e.Y >= (lastElement.y * 8) - 2 &&
							e.Y <= (lastElement.y * 8) + 2 &&
							e.X >= (lastElement.x * 8) - 2 &&
							e.X <= (lastElement.x * 8) + lastElement.width + 2)
						{
							resizeType |= SceneResizing.up;
						}

						if (e.Y >= ((lastElement.y * 8) + lastElement.height) - 2 &&
							e.Y <= (lastElement.y * 8) + lastElement.height + 2 &&
													e.X >= (lastElement.x * 8) - 2 &&
							e.X <= (lastElement.x * 8) + lastElement.width + 2)
						{
							resizeType |= SceneResizing.down;
						}
					}
					//debugVariable = (int)resizeType;

					if (resizeType == (SceneResizing.left | SceneResizing.down))
					{
						Cursor = Cursors.SizeNESW;
					}
					else if (resizeType == (SceneResizing.up | SceneResizing.right))
					{
						Cursor = Cursors.SizeNESW;
					}
					else if (resizeType == (SceneResizing.up | SceneResizing.left))
					{
						Cursor = Cursors.SizeNWSE;
					}
					else if (resizeType == (SceneResizing.down | SceneResizing.right))
					{
						Cursor = Cursors.SizeNWSE;
					}
					else if (resizeType == SceneResizing.left || resizeType == SceneResizing.right)
					{
						Cursor = Cursors.SizeWE;
					}
					else if (resizeType == SceneResizing.up || resizeType == SceneResizing.down)
					{
						Cursor = Cursors.SizeNS;
					}
					else
					{
						Cursor = Cursors.Default;
					}

					if (resizeType != SceneResizing.none)
					{
						return;
					}
				}
			}

			if (ZS.CurrentUWMode == DungeonEditMode.Entrances)
			{
				
			}

			bool colliding_chest = false;
			if (ZS.CurrentUWMode == DungeonEditMode.Chests)
			{
				foreach (Chest c in room.chest_list)
				{
					if (MX >= (c.x * 8) && MY >= (c.y * 8) - 16 && MX <= (c.x * 8) + 16 && MY <= (c.y * 8) + 16)
					{
						ZS.MainForm.toolTip1.Show(ChestItems_Name.name[c.item] + " " + c.item.ToString("X2"), this, new Point(e.X, e.Y + 16));
						colliding_chest = true;
					}
				}
			}

			if (!colliding_chest)
			{
				ZS.MainForm.toolTip1.Hide(this);
			}

			if (mouse_down) // Slowdown problem in save caused by something here
			{
				//updating_info = true;

				setMouseSizeMode(e); // Define the size of mx,my for each mode
				if (ZS.CurrentUWMode != DungeonEditMode.Doors)
				{
					if (mx != last_mx || my != last_my)
					{
						need_refresh = true;

						if (room.selectedObject.Count > 0)
						{
							move_objects();
							room.has_changed = true;
							last_mx = mx;
							last_my = my;
							ZS.DungeonForm.UpdateFormForSelectedObject((room.selectedObject[0]);
						}

					}

					
				}
				else // If it is a door
				{
					if (room.selectedObject.Count > 0 &&
						room.selectedObject[0] is object_door dobj &&
						doorArray != null)
					{
						for (int i = 0; i < 48; i++)
						{
							Rectangle r = doorArray[i];
							if (lastSelectedRectangle != r && new Rectangle(MX, MY, 1, 1).IntersectsWith(r))
							{
								lastSelectedRectangle = r;
								int doordir = i / 12;
								if (dobj.door_pos != (byte) ((i * 2) - (doordir * 12)) ||
									dobj.door_dir != (byte) doordir)
								{
									dobj.door_pos = (byte) ((i - (doordir * 12)) * 2);
									dobj.door_dir = (byte) doordir;
									dobj.updateId();
									dobj.Draw();
									room.has_changed = true;
								}

								break;
							}
						}
					}
				}

				DrawRoom();
				Refresh();
			}
		}

		public void move_objects()
		{
			foreach (object o in room.selectedObject)
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
					ro.nx = (byte) (ro.x + move_x);
					ro.ny = (byte) (ro.y + move_y);

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
				g.Clear(BackColor);
				return;
			}

			// TODO can this be an or statement?
			if (ZS.MainForm.x2zoom)
			{
				g = Graphics.FromImage(tempBitmap);
			}

			if (forPreview)
			{
				g = Graphics.FromImage(tempBitmap);
			}

			g.SetClip(Constants.Rect_0_0_512_512);
			g.Clear(Color.Black);

			if (room.bg2 != Constants.LayerMergeTranslucent || room.bg2 != Constants.LayerMergeTransparent
				|| room.bg2 != Constants.LayerMergeOnTop || room.bg2 != Constants.LayerMergeOff)
			{
				g.DrawImage(ZS.GFXManager.roomBg2Bitmap, 0, 0);
			}

			//e.Graphics.DrawImage(ZS.GFXManager.roomBgLayoutBitmap,0,0);
			g.DrawImage(ZS.GFXManager.roomBg1Bitmap, 0, 0);

			if (room.bg2 == Constants.LayerMergeTranslucent || room.bg2 == Constants.LayerMergeTransparent)
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
				g.DrawImage(ZS.GFXManager.roomBg2Bitmap, Constants.Rect_0_0_512_512, 0, 0, 512, 512, GraphicsUnit.Pixel, imageAtt);
			}
			else if (room.bg2 == Constants.LayerMergeOnTop)
			{
				g.DrawImage(ZS.GFXManager.roomBg2Bitmap, 0, 0);
			}

			//e.Graphics.DrawImage(ZS.GFXManager.currentgfx16Bitmap, 0, -256);
			drawSelection(g);

			drawGrid(g);
			int superY = (room.index / 16);
			int superX = room.index - (superY * 16);

			int roomX = superX * 512;
			int roomY = superY * 512;

			if (ZS.MainForm.selectedEntrance != null)
			{
				if (ZS.MainForm.entranceCameraToolStripMenuItem.Checked)
				{
					g.DrawRectangle(Pens.Orange, new Rectangle(
						ZS.MainForm.selectedEntrance.CameraTriggerX - 128,
						ZS.MainForm.selectedEntrance.CameraTriggerY - 116,
						256,
						224));
				}

				if (ZS.MainForm.entrancePositionToolStripMenuItem.Checked)
				{
					int xpos = ZS.MainForm.selectedEntrance.XPosition - roomX;
					int ypos = ZS.MainForm.selectedEntrance.YPosition - roomY;
					g.DrawLine(Pens.White, xpos - 4, ypos, xpos + 4, ypos);
					g.DrawLine(Pens.White, xpos, ypos - 4, xpos, ypos + 4);
				}
			}

			//e.Graphics.DrawImage(ZS.GFXManager.roomObjectsBitmap,0,0);
			//e.Graphics.DrawImage(ZS.GFXManager., 0, -512);
			//drawText(e.Graphics,4,4, "This is a test? []()abc 1234567890-+");
			int stairCount = 0;
			int chestCount = 0;
			int doorCount = 0;

			foreach (Room_Object o in room.tilesObjects)
			{
				if (ZS.DungeonForm.showChestIDs && (o.id == Constants.ChestID || o.id == Constants.BigChestID))
				{
					drawText(g, (o.nx * 8) + 6, (o.ny * 8) + 8, chestCount.ToString());
					chestCount++;
				}

				// TODO :cry:
				// TODO magic numbers
				if (ZS.DungeonForm.invisibleObjectsTextToolStripMenuItem.Checked)
				{
					if (o.id == 0x273)
					{
						drawText(e.Graphics, o.x * 8, o.y * 8, "BG2\nFull\nMask");
					}
					else if (o.id == 0x22A)
					{
						drawText(e.Graphics, o.x * 8, o.y * 8, "Lamp");
					}
					else if (o.id == 0xAD)
					{
						drawText(e.Graphics, o.x * 8, o.y * 8, "AD ?");
					}
					else if (o.id == 0xAE)
					{
						drawText(e.Graphics, o.x * 8, o.y * 8, "AE ?");
					}
					else if (o.id == 0xAF)
					{
						drawText(e.Graphics, o.x * 8, o.y * 8, "AF ?");
					}
				}
				// TODO copy

				if (o.options == ObjectOption.Door)
				{
					if (ZS.DungeonForm.showDoorsIDs)
					{
						drawText(g, (o.x * 8) + 12, (o.y * 8), doorCount.ToString());
					}

					doorCount++;
					if ((o.id >> 8) == 18) // Exit door
					{
						drawText(g, (o.x * 8) + 6, (o.y * 8) + 8, "Exit");
					}
					else if ((o.id >> 8) == 0x16) // Exit door
					{
						drawText(g, (o.x * 8) + 6, (o.y * 8) + 8, "to");
						drawText(g, (o.x * 8) + 4, (o.y * 8) + 16, "bg2");
					}
				}

				if (o.options == ObjectOption.Block)
				{
					g.DrawImage(ZS.GFXManager.moveableBlock, o.nx * 8, o.ny * 8);
				}

				if (doorsObject.Contains(o.id))
				{
					drawText(g, o.nx * 8, o.ny * 8, "to : " + room.staircase_rooms[stairCount].ToString());
					stairCount++;
				}
			}

			if (ZS.MainForm.showSpriteText)
			{
				foreach (Sprite spr in room.sprites)
				{
					drawText(g, spr.nx * 16, spr.ny * 16, spr.name);
				}
			}

			if (ZS.MainForm.showChestText)
			{
				foreach (Chest c in room.chest_list)
				{
					drawText(g, c.x * 8, c.y * 8, ChestItems_Name.name[c.item]);
				}
			}

			if (ZS.MainForm.showItemsText)
			{
				foreach (PotItem c in room.pot_items)
				{
					int dropboxid = c.id;
					if (c.id.BitIsOn(0x80))
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

			if (ZS.MainForm.x2zoom)
			{
				e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
				e.Graphics.DrawImage(tempBitmap, Constants.Rect_0_0_1024_1024);
			}

			if (ZS.CurrentUWMode == DungeonEditMode.CollisionMap)
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

		private void OnMouseDown(object sender, MouseEventArgs e)
		{
			if (room == null)
			{
				return;
			}

			ZS.MainForm.GetXYMouseBasedOnZoom(e, out int MX, out int MY);

			//this.Focus();

			room.has_changed = true;
			ZS.DungeonForm.checkAnyChanges();

			if (ZS.CurrentUWMode == DungeonEditMode.Entrances)
			{
				ZS.DungeonForm.entrancetreeView_AfterSelect(null, null);
				ZS.CurrentUWMode = DungeonEditMode.LayerAll;
				return;
			}

			switch (ZS.CurrentUWMode)
			{
				case DungeonEditMode.Layer1:
				case DungeonEditMode.Layer2:
				case DungeonEditMode.Layer3:
				case DungeonEditMode.LayerAll:
					if (room.selectedObject.Count == 1 && resizeType != SceneResizing.none)
					{
						//Room_Object obj = (room.selectedObject[0] as Room_Object);
						mouse_down = true;
						resizing = true;
						dragx = MX;
						dragy = MY;
						return;
					}
					break;
			}

			if (ZS.DungeonForm.tabControl1.SelectedIndex == 1) // If we are on object tab
			{
				switch (ZS.CurrentUWMode)
				{
					case DungeonEditMode.Layer1:
					case DungeonEditMode.Layer2:
					case DungeonEditMode.Layer3:
						if (selectedDragObject != null) // If there's an object selected
						{
							room.selectedObject.Clear(); // Clear the object buffer

							// Add the new object in the buffer
							byte lay = 0;
							switch (ZS.CurrentUWMode)
							{
								case DungeonEditMode.Layer1:
									lay = 0;
									break;
								case DungeonEditMode.Layer2:
									lay = 1;
									break;
								case DungeonEditMode.Layer3:
									lay = 2;
									break;
							}

							Room_Object ro = room.addObject(selectedDragObject.id, 0, 0, 0, lay);

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
							ZS.DungeonForm.objectViewer1.selectedObject = null;
							ZS.DungeonForm.objectViewer1.Refresh();
						}
						break;

					default:
						if (selectedDragObject != null) // If there's an object selected
						{
							selectedDragObject = null; // Set the object null
							ZS.DungeonForm.objectViewer1.selectedIndex = -1;
							ZS.DungeonForm.objectViewer1.selectedObject = null;
							ZS.DungeonForm.objectViewer1.Refresh();
							mouse_down = false;

							MessageBox.Show("Objects can only be placed while working on backgrounds 1, 2, or 3.");
							return;
						}
						break;
				}
			}
			else if (ZS.DungeonForm.tabControl1.SelectedIndex == 2)
			{
				if (selectedDragSprite != null)
				{
					room.selectedObject.Clear();

					Sprite spr = new Sprite(room, (byte) selectedDragSprite.id, 0, 0, selectedDragSprite.option, 0);

					if (spr != null)
					{
						ZS.DungeonForm.UpdateUnderworldMode(DungeonEditMode.Sprites);
						room.selectedObject.Add(spr);
						dragx = 0;
						dragy = 0;
						room.sprites.Add(spr);
					}

					room.has_changed = true;
					mouse_down = true;
					selectedDragObject = null;
					selectedDragSprite = null;

					ZS.DungeonForm.spritesView1.selectedObject = null;
					ZS.DungeonForm.spritesView1.Refresh();
				}
			}

			if (!mouse_down)
			{
				doorArray = new Rectangle[48];
				found = false;

				if (ZS.CurrentUWMode == DungeonEditMode.Blocks)
				{
					dragx = MX / 16;
					dragy = MY / 16;

					if (room.selectedObject.Count == 1)
					{
						room.selectedObject.Clear();
					}

					foreach (Sprite spr in room.sprites)
					{
						if (isMouseCollidingWith(spr, e) && !spr.selected)
						{
							room.selectedObject.Add(spr);
							found = true;
							break;
						}
					}

					if (!found) // We didnt find any sprites to click on so just clear the selection
					{
						room.selectedObject.Clear();
					}
				}
				else if (ZS.CurrentUWMode == DungeonEditMode.Secrets)
				{
					dragx = MX / 8;
					dragy = MY / 8;

					if (room.selectedObject.Count == 1)
					{
						//foreach (Object o in room.pot_items)
						//{
						//	// TODO: Add something here?
						//	//(o as PotItem).selected = false;
						//}

						room.selectedObject.Clear();
					}

					foreach (PotItem item in room.pot_items)
					{
						if (isMouseCollidingWith(item, e) && !item.selected)
						{
							room.selectedObject.Add(item);
							found = true;
							break;
						}
					}

					if (!found) // We didnt find any items to click on so just clear the selection
					{
						room.selectedObject.Clear();
					}
				}
				else if (ZS.CurrentUWMode == DungeonEditMode.Layer1 || ZS.CurrentUWMode == DungeonEditMode.Layer2 ||
					ZS.CurrentUWMode == DungeonEditMode.Layer3 || ZS.CurrentUWMode == DungeonEditMode.LayerAll)
				{
					dragx = MX / 8;
					dragy = MY / 8;
					found = false;

					for (int i = room.tilesObjects.Count - 1; i >= 0; i--)
					{
						Room_Object obj = room.tilesObjects[i];
						if (ZS.CurrentUWMode != DungeonEditMode.LayerAll && ((byte) ZS.CurrentUWMode != obj.layer))
						{
							continue;
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

							if ((obj.options & ObjectOption.Bgr) != ObjectOption.Bgr
								&& (obj.options & ObjectOption.Door) != ObjectOption.Door
								&& (obj.options & ObjectOption.Torch) != ObjectOption.Torch
								&& (obj.options & ObjectOption.Block) != ObjectOption.Block)
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
				else if (ZS.CurrentUWMode == DungeonEditMode.Doors)
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
				else if (ZS.CurrentUWMode == DungeonEditMode.Blocks)
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
				else if (ZS.CurrentUWMode == DungeonEditMode.Torches)
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
				else if (ZS.CurrentUWMode == DungeonEditMode.CollisionMap)
				{
					// What happens when the mouse is clicked in the Collision map mode
					if (e.Button == MouseButtons.Left)
					{
						int px = e.X / 16;
						int py = e.Y / 16;

						room.collisionMap[px + (py * 64)] = (byte) ZS.MainForm.tileTypeCombobox.SelectedIndex;
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

			ZS.DungeonForm.spritepropertyPanel.Visible = false;
			ZS.DungeonForm.potitemobjectPanel.Visible = false;
			ZS.DungeonForm.doorselectPanel.Visible = false;
			ZS.DungeonForm.litCheckbox.Visible = false;
			updating_info = false;

			if (room.selectedObject.Count > 0)
			{
				if (room.selectedObject[0] is Room_Object oo)
				{
					ZS.DungeonForm.selectedGroupbox.Text = UIText.FormatSelectedObject(oo);

					if (oo.options == ObjectOption.Door)
					{
						ZS.DungeonForm.comboBox1.Enabled = false;
						ZS.DungeonForm.doorselectPanel.Visible = true;
						int[] aposes = ZS.DungeonForm.door_index.Select(
							(s, i) => new { s, i })
							.Where(x => x.s == (oo as object_door).door_type)
							.Select(x => x.i)
							.ToArray();
						int apos = 0;

						if (aposes.Length > 0)
						{
							apos = aposes[0];
						}

						ZS.DungeonForm.comboBox2.SelectedIndex = apos;
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
						ZS.DungeonForm.litCheckbox.Visible = true;
						ZS.DungeonForm.litCheckbox.Checked = oo.lit;
						updateSelectionObject(oo);
					}
					else
					{
						ZS.DungeonForm.comboBox1.Enabled = false;

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
					ZS.DungeonForm.spritepropertyPanel.Visible = true;
					string name = null;
					if (sp.subtype.BitsAllSet(0x07))
					{
						if (sp.id <= 0x1A && sp.id > 0x00)
						{
							name = Sprites_Names.overlordnames[sp.id - 1];
						}

						ZS.DungeonForm.spriteoverlordCheckbox.Checked = true;
					}
					else
					{
						ZS.DungeonForm.spriteoverlordCheckbox.Checked = false;
					}

					name = name ?? Sprites_Names.name[sp.id];

					ZS.DungeonForm.selectedGroupbox.Text = UIText.FormatSelectedSprite(sp, name);
					ZS.DungeonForm.comboBox1.Enabled = true;
					updateSelectionObject(sp);
				}
				else if (room.selectedObject[0] is PotItem pp)
				{
					ZS.DungeonForm.potitemobjectPanel.Visible = true; // oO why this is not appearing
					int dropboxid = pp.id.BitIsOn(0x80)
						? ((pp.id - 0x80) / 2) + 0x17
						: pp.id;

					// If for some reason the dropboxid >= 28
					if (dropboxid >= 28)
					{
						dropboxid = 27; // Prevent crash :yay:
					}

					ZS.DungeonForm.selectedGroupbox.Text = UIText.FormatSelectedPotItem(pp, ItemsNames.name[dropboxid]);
					ZS.DungeonForm.selecteditemobjectCombobox.SelectedIndex = dropboxid;
					updateSelectionObject(pp);
				}
			}

			updating_info = false;
		}

		public unsafe void ClearBgGfx()
		{
			byte* bg1data = (byte*) ZS.GFXManager.roomBg1Ptr.ToPointer();
			byte* bg2data = (byte*) ZS.GFXManager.roomBg2Ptr.ToPointer();

			for (int i = 0; i < 512 * 512; i++)
			{
				bg1data[i] = 0;
				bg2data[i] = 0;
			}
		}

		public unsafe void DrawRoom()
		{
			if (room == null) return;

			//Tile t = new Tile(0, false, false, 0, 0);
			//t.Draw(0, 0);
			ClearBgGfx(); // Technically not required

			if (showLayer1)
			{
				room.DrawFloor1();
			}

			if (room.bg2 != Constants.LayerMergeOff)
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
				if (o.options == ObjectOption.Door || o.layer != 2)
				{
					o.collisionPoint.Clear();
					o.Draw();
				}
				//if (o.options == ObjectOption.Door)
				//{
				//	o.collisionPoint.Clear();
				//	o.Draw();
				//}
			}

			foreach (Room_Object o in room.tilesObjects)
			{
				// Draw doors here since they'll all be put on bg3 anyways
				if (o.layer == 2)
				{
					o.collisionPoint.Clear();
					o.Draw();
				}
			}

			if (showLayer1)
			{
				ZS.GFXManager.DrawBG1();
			}
			if (showLayer2)
			{
				ZS.GFXManager.DrawBG2();
			}
			if (ZS.MainForm.showSprite)
			{
				room.drawSprites();
			}
			if (ZS.MainForm.showChest)
			{
				drawChests();
			}
			if (ZS.MainForm.showItems)
			{
				room.drawPotsItems();
			}

			ZS.MainForm.cgramViewer.Refresh();
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
							if (o.id == Constants.BigChestID)
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

						//graphics.DrawImage(ZS.GFXManager.chestitems_bitmap[c.item], (c.x * 8), (c.y - 2) * 8);
					}
				}
			}
		}

		public void drawGrid(Graphics graphics)
		{
			if (showGrid)
			{
				int s = ZS.MainForm.gridSize;
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
			ColorPalette palettes = ZS.GFXManager.roomBg1Bitmap.Palette;
			for (int y = 0; y < ZS.GFXManager.loadedPalettes.GetLength(1); y++)
			{
				for (int x = 0; x < ZS.GFXManager.loadedPalettes.GetLength(0); x++)
				{
					palettes.Entries[pindex++] = ZS.GFXManager.loadedPalettes[x, y];
				}
			}

			for (int y = 0; y < ZS.GFXManager.loadedSprPalettes.GetLength(1); y++)
			{
				for (int x = 0; x < ZS.GFXManager.loadedSprPalettes.GetLength(0); x++)
				{
					if (pindex < 256)
					{
						palettes.Entries[pindex++] = ZS.GFXManager.loadedSprPalettes[x, y];
					}
				}
			}

			for (int i = 0; i < Constants.TotalPaletteSize; i += Constants.ColorsPerHalfPalette)
			{
				palettes.Entries[i] = Color.Transparent;
			}

			ZS.GFXManager.roomBg1Bitmap.Palette = palettes;
			ZS.GFXManager.roomBg2Bitmap.Palette = palettes;
			ZS.GFXManager.roomBgLayoutBitmap.Palette = palettes;
		}

		public void SetPalettesBlack()
		{
			int pindex = 0;
			ColorPalette palettes = ZS.GFXManager.roomBg1Bitmap.Palette;
			for (int y = 0; y < ZS.GFXManager.loadedPalettes.GetLength(1); y++)
			{
				for (int x = 0; x < ZS.GFXManager.loadedPalettes.GetLength(0); x++)
				{
					palettes.Entries[pindex++] = ZS.GFXManager.loadedPalettes[x, y];
				}
			}

			for (int i = 0; i < Constants.TotalPaletteSize; i += Constants.ColorsPerHalfPalette)
			{
				palettes.Entries[i] = Color.Black;
			}

			ZS.GFXManager.roomBg1Bitmap.Palette = palettes;
			ZS.GFXManager.roomBg2Bitmap.Palette = palettes;
			ZS.GFXManager.roomBgLayoutBitmap.Palette = palettes;
		}

		private unsafe void OnMouseUp(object sender, MouseEventArgs e)
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
					ZS.DungeonForm.nothingselectedcontextMenu.Items[0].Enabled = true;
					ZS.DungeonForm.singleselectedcontextMenu.Items[0].Enabled = true;
					ZS.DungeonForm.groupselectedcontextMenu.Items[0].Enabled = true;
					ZS.DungeonForm.nothingselectedcontextMenu.Items[0].Visible = true;
					ZS.DungeonForm.singleselectedcontextMenu.Items[0].Visible = true;
					ZS.DungeonForm.groupselectedcontextMenu.Items[0].Visible = true;
					string nname = null;

					// TODO copy
					switch (ZS.CurrentUWMode)
					{
						case DungeonEditMode.Chests:
							nname = "chest item";
							ZS.DungeonForm.nothingselectedcontextMenu.Items[2].Visible = true;
							ZS.DungeonForm.nothingselectedcontextMenu.Items[3].Visible = false;
							break;

						case DungeonEditMode.Secrets:
							nname = "pot item";
							break;

						case DungeonEditMode.Blocks:
							nname = "pushable block";
							break;

						case DungeonEditMode.Torches:
							nname = "torch";
							break;

						case DungeonEditMode.Doors:
							nname = "door";
							break;

						case DungeonEditMode.CollisionMap:
							nname = "custom collision map";
							ZS.DungeonForm.nothingselectedcontextMenu.Items[0].Visible = false;
							ZS.DungeonForm.nothingselectedcontextMenu.Items[1].Visible = false;
							ZS.DungeonForm.nothingselectedcontextMenu.Items[2].Visible = true;
							ZS.DungeonForm.nothingselectedcontextMenu.Items[3].Visible = true;
							break;

						case DungeonEditMode.Sprites:
							ZS.DungeonForm.nothingselectedcontextMenu.Items[0].Visible = false;
							ZS.DungeonForm.nothingselectedcontextMenu.Items[2].Visible = false;
							ZS.DungeonForm.nothingselectedcontextMenu.Items[3].Visible = false;
							ZS.DungeonForm.singleselectedcontextMenu.Items[0].Visible = false;
							ZS.DungeonForm.groupselectedcontextMenu.Items[0].Visible = false;
							break;

						case DungeonEditMode.Layer1:
						case DungeonEditMode.Layer2:
						case DungeonEditMode.Layer3:
						case DungeonEditMode.LayerAll:
							ZS.DungeonForm.nothingselectedcontextMenu.Items[0].Visible = false;
							ZS.DungeonForm.nothingselectedcontextMenu.Items[2].Visible = false;
							ZS.DungeonForm.nothingselectedcontextMenu.Items[3].Visible = false;
							ZS.DungeonForm.singleselectedcontextMenu.Items[0].Visible = false;
							ZS.DungeonForm.groupselectedcontextMenu.Items[0].Visible = false;
							break;
					}


					if (nname != null)
					{
						string s = string.Format("Insert new {0}", nname);
						ZS.DungeonForm.nothingselectedcontextMenu.Items[0].Text = s;
						ZS.DungeonForm.singleselectedcontextMenu.Items[0].Text = s;
						ZS.DungeonForm.groupselectedcontextMenu.Items[0].Text = s;
					}

					if (room.selectedObject.Count == 0)
					{
						ZS.DungeonForm.nothingselectedcontextMenu.Show(Cursor.Position);
					}
					else if (room.selectedObject.Count == 1)
					{
						ZS.DungeonForm.singleselectedcontextMenu.Show(Cursor.Position);
					}
					else if (room.selectedObject.Count > 1)
					{
						ZS.DungeonForm.groupselectedcontextMenu.Show(Cursor.Position);
					}

					mouse_down = false;
				}
			}

			DrawRoom();
			Refresh();
		}

		private void OnMouseDoubleClick(object sender, MouseEventArgs e)
		{
			rmx = e.X;
			rmy = e.Y;
			addChest();
		}

		public void addChest()
		{
			int MX = rmx;
			int MY = rmy;

			if (ZS.MainForm.x2zoom)
			{
				MX /= 2;
				MY /= 2;
			}

			if (ZS.CurrentUWMode == DungeonEditMode.Chests)
			{
				Chest chestToRemove = null;
				bool foundChest = false;

				foreach (Chest c in room.chest_list)
				{
					if (MX >= (c.x * 8) && MX <= (c.x * 8) + 16 &&
						MY >= ((c.y - 2) * 8) && MY <= (c.y * 8) + 16)
					{
						ZS.DungeonForm.chestPicker.button1.Enabled = true; // Enable delete button
						DialogResult result = ZS.DungeonForm.chestPicker.ShowDialog();

						if (result == DialogResult.OK)
						{
							// Change chest item
							// TODO hexbox
							if (int.TryParse(ZS.DungeonForm.chestPicker.idtextbox.Text, out int r))
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
					ZS.DungeonForm.chestPicker.button1.Enabled = false; // Disable delete button

					if (ZS.DungeonForm.chestPicker.ShowDialog() == DialogResult.OK)
					{
						room.has_changed = true;
						// Change chest item
						// TODO hexbox
						Chest c = new Chest(ZS, (byte) (MX / 8), (byte) (MY / 8), (byte) ZS.DungeonForm.chestPicker.chestviewer1.selectedIndex, false, false);
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

			if (ZS.MainForm.x2zoom)
			{
				MX /= 2;
				MY /= 2;
			}

			if (ZS.CurrentUWMode == DungeonEditMode.Chests)
			{
				Chest chestToRemove = null;

				foreach (Chest c in room.chest_list)
				{
					if (MX >= (c.x * 8) && MX <= (c.x * 8) + 16 &&
						MY >= ((c.y - 2) * 8) && MY <= (c.y * 8) + 16)
					{
						//mainForm.chestPicker.button1.Enabled = true;//enable delete button
						//DialogResult result = mainForm.chestPicker.ShowDialog();

						chestToRemove = c;
						break;
					}
				}

				if (chestToRemove != null)
				{
					room.chest_list.Remove(chestToRemove);
				}

				need_refresh = true;
				DrawRoom();
				Refresh();
			}
		}

		public void deleteCollisionMapTile()
		{
			if (ZS.CurrentUWMode == DungeonEditMode.CollisionMap)
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
			while (i < Constants.TilesPerTilemap)
			{
				room.collisionMap[i++] = 0xFF;
			}

			need_refresh = true;
			Refresh();
		}

		public void setObjectsPosition()
		{
			if (room.selectedObject.Count > 0)
			{
				switch (ZS.CurrentUWMode)
				{
					case DungeonEditMode.Sprites:
						foreach (object o in room.selectedObject)
						{
							Sprite s = o as Sprite;
							s.x = s.nx;
							s.y = s.ny;
							//(o as Sprite).boundingbox
						}
						break;

					case DungeonEditMode.Secrets:
						foreach (object o in room.selectedObject)
						{
							PotItem p = o as PotItem;
							p.x = p.nx;
							p.y = p.ny;
						}
						break;

					case DungeonEditMode.Layer1:
					case DungeonEditMode.Layer2:
					case DungeonEditMode.Layer3:
					case DungeonEditMode.LayerAll:
						foreach (object o in room.selectedObject)
						{
							Room_Object r = o as Room_Object;
							r.x = r.nx;
							r.y = r.ny;
							r.ox = r.x;
							r.oy = r.y;
						}
						break;

					case DungeonEditMode.Torches:
						foreach (object o in room.selectedObject)
						{
							Room_Object r = o as Room_Object;
							r.x = r.nx;
							r.y = r.ny;
							r.ox = r.x;
							r.oy = r.y;
						}
						break;

					case DungeonEditMode.Blocks:
						foreach (object o in room.selectedObject)
						{
							Room_Object r = o as Room_Object;
							r.x = r.nx;
							r.y = r.ny;
							r.ox = r.x;
							r.oy = r.y;
						}
						break;
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
			ZS.MainForm.GetXYMouseBasedOnZoom(e, out int MX, out int MY);

			switch (ZS.CurrentUWMode)
			{
				case DungeonEditMode.Sprites:
					mx = MX / 16;
					my = MY / 16;
					break;

				case DungeonEditMode.Secrets:

				case DungeonEditMode.Layer1:
				case DungeonEditMode.Layer2:
				case DungeonEditMode.Layer3:
				case DungeonEditMode.LayerAll:

				case DungeonEditMode.Torches:
				case DungeonEditMode.Blocks:
					mx = MX / 8;
					my = MY / 8;
					break;
			}

			move_x = mx - dragx; // Number of tiles mouse is compared to starting drag point X
			move_y = my - dragy; // Number of tiles mouse is compared to starting drag point Y
		}

		public bool isMouseCollidingWith(object o, MouseEventArgs e)
		{
			ZS.MainForm.GetXYMouseBasedOnZoom(e, out int MX, out int MY);

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

				int yfix = objR.diagonalFix
					? -(6 + objR.size)
					: 0;

				if (MX >= ((objR.x + objR.offsetX) * 8) && MX <= ((objR.x + objR.offsetX) * 8) + objR.width &&
						MY >= ((objR.y + objR.offsetY + yfix) * 8) && MY <= ((objR.y + objR.offsetY + yfix) * 8) + objR.height)
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
				switch (ZS.CurrentUWMode)
				{
					case DungeonEditMode.Sprites:
						foreach (Sprite spr in room.sprites)
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

							if (spr.boundingbox.IntersectsWith(new Rectangle(rx * 16, ry * 16, Math.Abs(move_x) * 16, Math.Abs(move_y) * 16)))
							{
								room.selectedObject.Add(spr);
							}
						}
						break;

					case DungeonEditMode.Secrets:
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

							if (new Rectangle(item.x * 8, item.y * 8, 16, 16).IntersectsWith(
								new Rectangle(rx * 8, ry * 8, Math.Abs(move_x) * 8, Math.Abs(move_y) * 8)))
							{
								room.selectedObject.Add(item);
							}
						}
						break;

					case DungeonEditMode.Layer1:
					case DungeonEditMode.Layer2:
					case DungeonEditMode.Layer3:
					case DungeonEditMode.LayerAll:
						foreach (Room_Object o in room.tilesObjects)
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

							int yfix = o.diagonalFix
								? -(6 + o.size)
								: 0;

							if (new Rectangle(
								(o.x + o.offsetX) * 8,
								(o.y + o.offsetY + yfix) * 8,
								o.width + o.offsetX,
								o.height + o.offsetY + yfix)
								.IntersectsWith(new Rectangle(rx * 8, ry * 8, Math.Abs(move_x) * 8, Math.Abs(move_y) * 8)))
							{
								if ((o.options & ObjectOption.Bgr) != ObjectOption.Bgr
									&& (o.options & ObjectOption.Door) != ObjectOption.Door
									&& (o.options & ObjectOption.Torch) != ObjectOption.Torch
									&& (o.options & ObjectOption.Block) != ObjectOption.Block)
								{
									if (ZS.CurrentUWMode == DungeonEditMode.LayerAll)
									{
										room.selectedObject.Add(o);
									}
									else if ((byte) ZS.CurrentUWMode == o.layer)
									{
										room.selectedObject.Add(o);
									}
								}
							}
						}
						break;
				}
			}

			/*
            foreach(Room_Object o in room.selectedObject)
            {
                Console.WriteLine(o.id.ToString("X4") + o.name);
            }
            */
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

		}

		public override void Delete()
		{
			room.has_changed = true;
			ZS.DungeonForm.checkAnyChanges();

			foreach (object o in room.selectedObject)
			{
				if (o is Room_Object r)
				{
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

			room.selectedObject.Clear();
			DrawRoom();
			Refresh();
		}

		public override void Paste()
		{
			if (!mouse_down)
			{
				List<SaveObject> data = null;
				try
				{
					data = (List<SaveObject>) Clipboard.GetData(Constants.ObjectZClipboardData);
				}
				catch (Exception) {}

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
								if (o.x < most_x)
								{
									most_x = o.x;
								}
								if (o.y < most_y)
								{
									most_y = o.y;
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
							if (o.type == typeof(Sprite))
							{
								ZS.CurrentUWMode = DungeonEditMode.Sprites;
								Sprite spr = new Sprite(room, o.id, (byte) (o.x - most_x), (byte) (o.y - most_y), o.subtype, o.layer);
								room.sprites.Add(spr);
								room.selectedObject.Add(spr);
							}
							else if (o.type == typeof(Room_Object))
							{
								if ((o.options & ObjectOption.Door) == ObjectOption.Door)
								{
									ZS.CurrentUWMode = DungeonEditMode.Doors;
									object_door ro = new object_door(o.tid, o.x, o.y, 0, o.layer, ZS);
									ro.setRoom(room);
									ro.options = o.options;
									room.tilesObjects.Add(ro);
									room.selectedObject.Add(ro);
								}
								else
								{
									Room_Object ro = room.addObject(o.tid, (byte) (o.x - most_x), (byte) (o.y - most_y), o.size, o.layer);

									if (ro != null)
									{

										switch (ZS.CurrentUWMode)
										{
											case DungeonEditMode.LayerAll:
												// TODO???
												break;

											case DungeonEditMode.Layer1:
											case DungeonEditMode.Layer2:
											case DungeonEditMode.Layer3:
												ro.layer = (byte) ZS.CurrentUWMode;
												break;

											default:
												ZS.CurrentUWMode = DungeonEditMode.Layer1;
												break;
										}

										ro.setRoom(room);
										ro.options = o.options;
										room.tilesObjects.Add(ro);
										room.selectedObject.Add(ro);
									}
								}
							}
							else if (o.type == typeof(PotItem))
							{
								ZS.CurrentUWMode = DungeonEditMode.Secrets;
								PotItem item = new PotItem((byte) o.tid, (byte) (o.x - most_x), (byte) (o.y - most_y), o.layer == 1, ZS);
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

		public override void Copy()
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
				else if (o is PotItem objP)
				{
					odata.Add(new SaveObject(objP));
					mouse_down = false;
				}
				else if (o is Room_Object objR)
				{
					odata.Add(new SaveObject(objR));
					mouse_down = false;
				}
			}

			Clipboard.SetData(Constants.ObjectZClipboardData, odata);
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
						if (o.x < most_x)
						{
							most_x = o.x;
						}
						if (o.y < most_y)
						{
							most_y = o.y;
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
					if (o.type == typeof(Sprite))
					{
						Sprite spr = new Sprite(room, o.id, (byte) (o.x - most_x), (byte) (o.y - most_y), o.subtype, o.layer);
						room.sprites.Add(spr);
						room.selectedObject.Add(spr);
					}
					else if (o.type == typeof(Room_Object))
					{
						Room_Object ro = room.addObject(o.tid, (byte) (o.x - most_x), (byte) (o.y - most_y), o.size, o.layer);
						if (ro != null)
						{
							ro.setRoom(room);
							ro.options = o.options;
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

		public override void Cut()
		{
			Clipboard.Clear();
			//Room r = (Room)room.Clone();
			//clearUselessRoomStuff(r);
			room.has_changed = true;
			ZS.MainForm.checkAnyChanges();
			//undoRooms.Add(r);

			var odata = new List<SaveObject>();
			foreach (var o in room.selectedObject)
			{
				if (o is Sprite objS)
				{
					odata.Add(new SaveObject(objS));
				}
				else if (o is PotItem objP)
				{
					odata.Add(new SaveObject(objP));
				}
				else if (o is Room_Object objR)
				{
					odata.Add(new SaveObject(objR));
				}
			}

			Clipboard.SetData(Constants.ObjectZClipboardData, odata);

			foreach (object o in room.selectedObject)
			{
				if (o is Sprite objS)
				{
					room.sprites.Remove(objS);
				}
				else if (o is PotItem objP)
				{
					room.pot_items.Remove(objP);
				}
				else if (o is Room_Object objR)
				{
					room.tilesObjects.Remove(objR);
				}
			}

			room.selectedObject.Clear();
			DrawRoom();
			Refresh();
		}

		// TODO magic numbers
		public override void insertNew()
		{
			switch (ZS.CurrentUWMode)
			{
				case DungeonEditMode.Blocks:
					room.selectedObject.Clear();
					Room_Object rb = room.addObject(Constants.TorchPseudoID, 0, 0, 0, 0);

					if (rb != null)
					{
						rb.setRoom(room);
						rb.options = ObjectOption.Block;
						room.tilesObjects.Add(rb);
						room.selectedObject.Add(rb);
						dragx = 0;
						dragy = 0;
						mouse_down = true;
					}
					break;

				case DungeonEditMode.Secrets:
					room.selectedObject.Clear();
					PotItem p = new PotItem(1, 0, 0, false, ZS);
					room.pot_items.Add(p);
					room.selectedObject.Add(p);
					dragx = 0;
					dragy = 0;
					mouse_down = true;
					break;

				case DungeonEditMode.Chests:
					addChest();
					break;

				case DungeonEditMode.Torches:
					room.selectedObject.Clear();
					Room_Object rt = room.addObject(0x150, 0, 0, 0, 0);
					if (rt != null)
					{
						rt.setRoom(room);
						rt.options = ObjectOption.Torch;
						room.tilesObjects.Add(rt);
						room.selectedObject.Add(rt);
						dragx = 0;
						dragy = 0;
						mouse_down = true;
					}
					break;

				case DungeonEditMode.Doors:
					room.selectedObject.Clear();
					Room_Object rd = new object_door(0, 0, 0, 0, 0, ZS);
					if (rd != null)
					{
						rd.setRoom(room);
						rd.options = ObjectOption.Door;
						room.tilesObjects.Add(rd);
						Focus();
						//room.selectedObject.Add(ro);
					}
					break;

			}
			//else if ((byte) selectedMode >= 0 && (byte) selectedMode < 3) //if != allbg
			//{
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
			//}

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
	}
}
