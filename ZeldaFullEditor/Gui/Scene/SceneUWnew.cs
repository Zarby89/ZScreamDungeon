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
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Globalization;

using ZeldaFullEditor.Data.DungeonObjects;

namespace ZeldaFullEditor
{
	public class SceneUW : Scene
	{
		public Bitmap tempBitmap = new Bitmap(512, 512);
		Rectangle lastSelectedRectangle;

		public bool forPreview = false;

		bool resizing = false;

		int rmx = 0;
		int rmy = 0;
		public bool showLayer1;
		public bool showLayer2;

		public DungeonRoom Room { get; set; }

		public SceneUW(ZScreamer parent) : base(parent)
		{
			//graphics = Graphics.FromImage(scene_bitmap);

			MouseDown += new MouseEventHandler(OnMouseDown);
			MouseUp += new MouseEventHandler(OnMouseUp);
			MouseMove += new MouseEventHandler(OnMouseMove);
			MouseDoubleClick += new MouseEventHandler(OnMouseDoubleClick);
			MouseWheel += SceneUW_MouseWheel;
			Paint += SceneUW_Paint;
		}

		private void SceneUW_MouseWheel(object sender, MouseEventArgs e)
		{
			if (Room.SelectedObjects.Count == 1 && Room.SelectedObjects[0] is RoomObject obj)
			{
				if ((e.Delta > 0 && obj.IncreaseSize()) || (e.Delta < 0 && obj.DecreaseSize()))
				{
					updateSelectionObject(obj);
				}
			}

			DrawRoom();
			Refresh();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
		}

		private void ResizeObject(RoomObject lastElement, int x, int y)
		{
			// TODO
		}

		// TODO: FIND PROBLEM THAT IS INCREASING SAVE TIME!!
		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			ZS.MainForm.GetXYMouseBasedOnZoom(e, out int MX, out int MY);

			Cursor = Cursors.Default;
			if (Room == null)
			{
				return;
			}

			if (Room.SelectedObjects.Count == 1)
			{
				if (Room.SelectedObjects[0] is RoomObject lastElement)
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
						if (e.X >= (lastElement.X * 8) - 2 &&
							e.X <= ((lastElement.X * 8) + 2) &&
							e.Y >= (lastElement.Y * 8) - 2 &&
							e.Y <= (lastElement.Y * 8) + lastElement.Height + 2)
						{
							resizeType |= SceneResizing.left;
						}

						if (e.X >= (lastElement.X * 8) + lastElement.Width - 2 &&
							e.X <= (lastElement.X * 8) + lastElement.Width + 2 &&
							e.Y >= (lastElement.Y * 8) - 2 &&
							e.Y <= (lastElement.Y * 8) + lastElement.Height + 2)
						{
							resizeType |= SceneResizing.right;
						}
					}

					if ((lastElement.sort & Sorting.Vertical) == (Sorting.Vertical))
					{
						if (e.Y >= (lastElement.Y * 8) - 2 &&
							e.Y <= (lastElement.Y * 8) + 2 &&
							e.X >= (lastElement.X * 8) - 2 &&
							e.X <= (lastElement.X * 8) + lastElement.Width + 2)
						{
							resizeType |= SceneResizing.up;
						}

						if (e.Y >= ((lastElement.Y * 8) + lastElement.Height) - 2 &&
							e.Y <= (lastElement.Y * 8) + lastElement.Height + 2 &&
													e.X >= (lastElement.X * 8) - 2 &&
							e.X <= (lastElement.X * 8) + lastElement.Width + 2)
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
				if (ZS.DungeonForm.selectedEntrance != null)
				{
					int ey = Room.RoomID >> 4;
					int ex = Room.RoomID & 0xF;

					if (ZS.DungeonForm.gridEntranceCheckbox.Checked)
					{
						MX &= ~0x7;
						MY &= ~0x7;
					}

					ZS.DungeonForm.selectedEntrance.XPosition = (ushort) (MX + (ex * 512));
					ZS.DungeonForm.selectedEntrance.YPosition = (ushort) (MY + (ey * 512));
					ZS.DungeonForm.selectedEntrance.CameraTriggerX = (ushort) MX;
					ZS.DungeonForm.selectedEntrance.CameraTriggerY = (ushort) MY;
					ZS.DungeonForm.selectedEntrance.RoomID = Room.RoomID;

					if (ZS.DungeonForm.selectedEntrance.CameraTriggerX > 383)
					{
						ZS.DungeonForm.selectedEntrance.CameraTriggerX = 383;
					}
					else if (ZS.DungeonForm.selectedEntrance.CameraTriggerX < 128)
					{
						ZS.DungeonForm.selectedEntrance.CameraTriggerX = 128;
					}

					if (ZS.DungeonForm.selectedEntrance.CameraTriggerY > 392)
					{
						ZS.DungeonForm.selectedEntrance.CameraTriggerY = 392;
					}
					else if (ZS.DungeonForm.selectedEntrance.CameraTriggerY < 112)
					{
						ZS.DungeonForm.selectedEntrance.CameraTriggerY = 112;
					}

					ZS.DungeonForm.selectedEntrance.CameraY = (ushort) (ZS.DungeonForm.selectedEntrance.CameraTriggerX + (ex * 512));
					ZS.DungeonForm.selectedEntrance.CameraX = (ushort) (ZS.DungeonForm.selectedEntrance.CameraTriggerY + (ey * 512));

					ZS.DungeonForm.selectedEntrance.CameraY = ZS.DungeonForm.selectedEntrance.XPosition;
					ZS.DungeonForm.selectedEntrance.CameraX = ZS.DungeonForm.selectedEntrance.YPosition;



					int scrollXRange = ZS.DungeonForm.selectedEntrance.CameraX % 512;
					if (scrollXRange >= 350)
					{
						ZS.DungeonForm.selectedEntrance.CameraX = (ushort) ((ey * 512) + 256 + 16);
					}
					else if (scrollXRange <= 150)
					{
						ZS.DungeonForm.selectedEntrance.CameraX = (ushort) (ey * 512);
					}
					else
					{
						ZS.DungeonForm.selectedEntrance.CameraX = (ushort) (ZS.DungeonForm.selectedEntrance.YPosition - 112);
					}

					int scrollYRange = ZS.DungeonForm.selectedEntrance.CameraY % 512;
					if (scrollYRange >= 350)
					{
						ZS.DungeonForm.selectedEntrance.CameraY = (ushort) ((ex * 512) + 256);
					}
					else if (scrollYRange <= 150)
					{
						ZS.DungeonForm.selectedEntrance.CameraY = (ushort) (ex * 512);
					}
					else
					{
						ZS.DungeonForm.selectedEntrance.CameraY = (ushort) (ZS.DungeonForm.selectedEntrance.XPosition - 128);
					}

					ZS.DungeonForm.selectedEntrance.AutoCalculateScrollBoundaries();

					DrawRoom();
					Refresh();
					return;
				}
			}

			bool colliding_chest = false;
			if (ZS.CurrentUWMode == DungeonEditMode.Chests)
			{
				foreach (Chest c in Room.ChestList)
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

			if (MouseIsDown) // Slowdown problem in save caused by something here
			{
				//updating_info = true;

				setMouseSizeMode(e); // Define the size of mx,my for each mode
				if (ZS.CurrentUWMode != DungeonEditMode.Doors)
				{
					if (mx != last_mx || my != last_my)
					{
						NeedsRefreshing = true;

						if (Room.SelectedObjects.Count > 0)
						{
							move_objects();
							Room.HasUnsavedChanges = true;
							last_mx = mx;
							last_my = my;
							updateSelectionObject(Room.SelectedObjects[0]);
						}

					}


				}
				else // If it is a door
				{
					if (Room.SelectedObjects.Count > 0 &&
						Room.SelectedObjects[0] is object_door dobj &&
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
									Room.HasUnsavedChanges = true;
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
			foreach (DungeonObject o in Room.SelectedObjects)
			{
				if (o is IFreelyPlaceable gg)
				{
					gg.NX = (byte) (gg.X + MoveX).Clamp(0, 80);
					gg.NY = (byte) (gg.Y + MoveY).Clamp(0, 80);
				}
			}
		}

		private unsafe void SceneUW_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			if (Room == null)
			{
				g.Clear(BackColor);
				return;
			}

			// TODO can this be an or statement?
			if (ZS.MainForm.x2zoom || forPreview)
			{
				g = Graphics.FromImage(tempBitmap);
			}

			g.SetClip(Constants.Rect_0_0_512_512);
			g.Clear(Color.Black);

			if (Room.bg2 != Constants.LayerMergeTranslucent || Room.bg2 != Constants.LayerMergeTransparent
				|| Room.bg2 != Constants.LayerMergeOnTop || Room.bg2 != Constants.LayerMergeOff)
			{
				g.DrawImage(ZS.GFXManager.roomBg2Bitmap, 0, 0);
			}

			//e.Graphics.DrawImage(ZS.GFXManager.roomBgLayoutBitmap,0,0);
			g.DrawImage(ZS.GFXManager.roomBg1Bitmap, 0, 0);

			if (Room.bg2 == Constants.LayerMergeTranslucent || Room.bg2 == Constants.LayerMergeTransparent)
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
			else if (Room.bg2 == Constants.LayerMergeOnTop)
			{
				g.DrawImage(ZS.GFXManager.roomBg2Bitmap, 0, 0);
			}

			//e.Graphics.DrawImage(ZS.GFXManager.currentgfx16Bitmap, 0, -256);
			drawSelection(g);

			drawGrid(g);
			int superY = (Room.RoomID / 16);
			int superX = Room.RoomID - (superY * 16);

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

			var AllObjects = Room.Layer1Objects.Concat(Room.Layer2Objects).Concat(Room.Layer3Objects);

			foreach (RoomObject o in AllObjects)
			{
				if (ZS.DungeonForm.showChestIDs && o.IsChest)
				{
					drawText(g, (o.NX * 8) + 6, (o.NY * 8) + 8, chestCount.ToString());
					chestCount++;
				}

				// TODO :cry:
				// TODO magic numbers
				if (ZS.DungeonForm.invisibleObjectsTextToolStripMenuItem.Checked)
				{
					if (o.ObjectType.Specialness == SpecialObjectType.LayerMask)
					{
						//drawText(e.Graphics, o.x * 8, o.y * 8, "BG2\nFull\nMask");
					}
				}
				// TODO copy
			}

			foreach (DungeonDoorObject d in Room.DungeonDoors)
			{
				if (ZS.DungeonForm.showDoorsIDs)
				{
					drawText(g, (d.X * 8) + 12, d.Y * 8, doorCount.ToString());
				}

				doorCount++;
				if (d.ID == 18) // Exit door
				{
					drawText(g, (d.X * 8) + 6, (d.Y * 8) + 8, "Exit");
				}
				else if (d.ID == 0x16) // Exit door
				{
					drawText(g, (d.X * 8) + 6, (d.Y * 8) + 8, "to");
					drawText(g, (d.X * 8) + 4, (d.Y * 8) + 16, "bg2");
				}
			}

			// TODO oh god
				if (o.options == ObjectOption.Block)
				{
					g.DrawImage(ZS.GFXManager.moveableBlock, o.nx * 8, o.ny * 8);
				}

				if (doorsObject.Contains(o.id))
				{
					drawText(g, o.nx * 8, o.ny * 8, "to : " + Room.staircase_rooms[stairCount].ToString());
					stairCount++;
				}

			if (ZS.MainForm.showSpriteText)
			{
				foreach (Sprite spr in Room.SpritesList)
				{
					drawText(g, spr.nx * 16, spr.ny * 16, spr.name);
				}
			}

			if (ZS.MainForm.showChestText)
			{
				foreach (Chest c in Room.chest_list)
				{
					drawText(g, c.x * 8, c.y * 8, ChestItems_Name.name[c.item]);
				}
			}

			if (ZS.MainForm.showItemsText)
			{
				foreach (PotItem c in Room.SecretsList)
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
					if (Room.collisionMap[i] != 0xFF)
					{
						drawText(e.Graphics, ((i % 64) * 16) + 4, (((i / 64) * 16)) + 4, Room.collisionMap[i].ToString("X2"));
					}
				}
			}

			// @scawful: Test for collision layout code 
			Task.Factory.StartNew(() =>
			{
				if (Console.ReadKey().Key == ConsoleKey.UpArrow)
				{
					Room.loadCollisionLayout(true);
				}
			});
		}

		public void drawDoorsPosition(Graphics g)
		{
			if (MouseIsDown && Room.SelectedObjects.Count > 0 && Room.SelectedObjects[0] is Room_Object rr)
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
			if (Room == null)
			{
				return;
			}

			ZS.MainForm.GetXYMouseBasedOnZoom(e, out int MX, out int MY);

			//this.Focus();
			ZS.ActiveScene = this;

			Room.HasUnsavedChanges = true;
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
					if (Room.SelectedObjects.Count == 1 && resizeType != SceneResizing.none)
					{
						//Room_Object obj = (room.selectedObject[0] as Room_Object);
						MouseIsDown = true;
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
							Room.SelectedObjects.Clear(); // Clear the object buffer

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

							Room_Object ro = Room.addObject(selectedDragObject.id, 0, 0, 0, lay);

							if (ro != null)
							{
								ro.setRoom(Room);
								ro.getObjectSize();
								Room.tilesObjects.Add(ro);
								Room.SelectedObjects.Add(ro);
								dragx = 0;
								dragy = 0;
							}

							Room.HasUnsavedChanges = true;
							MouseIsDown = true;
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
							MouseIsDown = false;

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
					Room.SelectedObjects.Clear();

					Sprite spr = new Sprite(Room, (byte) selectedDragSprite.id, 0, 0, selectedDragSprite.option, 0);

					if (spr != null)
					{
						ZS.DungeonForm.UpdateUnderworldMode(DungeonEditMode.Sprites);
						Room.SelectedObjects.Add(spr);
						dragx = 0;
						dragy = 0;
						Room.SpritesList.Add(spr);
					}

					Room.HasUnsavedChanges = true;
					MouseIsDown = true;
					selectedDragObject = null;
					selectedDragSprite = null;

					ZS.DungeonForm.spritesView1.selectedObject = null;
					ZS.DungeonForm.spritesView1.Refresh();
				}
			}

			if (!MouseIsDown)
			{
				doorArray = new Rectangle[48];
				found = false;

				if (ZS.CurrentUWMode == DungeonEditMode.Blocks)
				{
					dragx = MX / 16;
					dragy = MY / 16;

					if (Room.SelectedObjects.Count == 1)
					{
						Room.SelectedObjects.Clear();
					}

					foreach (Sprite spr in Room.SpritesList)
					{
						if (isMouseCollidingWith(spr, e) && !spr.selected)
						{
							Room.SelectedObjects.Add(spr);
							found = true;
							break;
						}
					}

					if (!found) // We didnt find any sprites to click on so just clear the selection
					{
						Room.SelectedObjects.Clear();
					}
				}
				else if (ZS.CurrentUWMode == DungeonEditMode.Secrets)
				{
					dragx = MX / 8;
					dragy = MY / 8;

					if (Room.SelectedObjects.Count == 1)
					{
						//foreach (Object o in room.pot_items)
						//{
						//	// TODO: Add something here?
						//	//(o as PotItem).selected = false;
						//}

						Room.SelectedObjects.Clear();
					}

					foreach (PotItem item in Room.pot_items)
					{
						if (isMouseCollidingWith(item, e) && !item.selected)
						{
							Room.SelectedObjects.Add(item);
							found = true;
							break;
						}
					}

					if (!found) // We didnt find any items to click on so just clear the selection
					{
						Room.SelectedObjects.Clear();
					}
				}
				else if (ZS.CurrentUWMode == DungeonEditMode.Layer1 || ZS.CurrentUWMode == DungeonEditMode.Layer2 ||
					ZS.CurrentUWMode == DungeonEditMode.Layer3 || ZS.CurrentUWMode == DungeonEditMode.LayerAll)
				{
					dragx = MX / 8;
					dragy = MY / 8;
					found = false;

					for (int i = Room.tilesObjects.Count - 1; i >= 0; i--)
					{
						Room_Object obj = Room.tilesObjects[i];
						if (ZS.CurrentUWMode != DungeonEditMode.LayerAll && ((byte) ZS.CurrentUWMode != obj.layer))
						{
							continue;
						}

						if (isMouseCollidingWith(obj, e))
						{
							if (Room.SelectedObjects.Count != 0)
							{
								if (Room.SelectedObjects.Contains(obj))
								{
									found = true;
									break;
								}

								if (ModifierKeys != Keys.Shift && ModifierKeys != Keys.Control)
								{
									Room.SelectedObjects.Clear();
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
										Room.SelectedObjects.Add(obj);
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
							Room.SelectedObjects.Clear();
						}
					}
				}
				else if (ZS.CurrentUWMode == DungeonEditMode.Doors)
				{
					// Console.Write("Door mode");
					Room.SelectedObjects.Clear();
					dragx = MX / 8;
					dragy = MY / 8;

					for (int i = Room.tilesObjects.Count - 1; i >= 0; i--)
					{
						Room_Object obj = Room.tilesObjects[i];
						if (isMouseCollidingWith(obj, e))
						{
							if ((obj.options & ObjectOption.Door) == ObjectOption.Door)
							{
								// We found a door! hooray!
								Room.SelectedObjects.Add(obj);
								obj.selected = true;
								doorArray = Room.getAllDoorPosition(obj);
								NeedsRefreshing = true;

								break;
							}
						}
					}
				}
				else if (ZS.CurrentUWMode == DungeonEditMode.Blocks)
				{
					Room.SelectedObjects.Clear();
					dragx = MX / 8;
					dragy = MY / 8;

					for (int i = Room.tilesObjects.Count - 1; i >= 0; i--)
					{
						Room_Object obj = Room.tilesObjects[i];
						if (isMouseCollidingWith(obj, e))
						{
							if ((obj.options & ObjectOption.Bgr) != ObjectOption.Bgr && (obj.options & ObjectOption.Block) == ObjectOption.Block)
							{
								Room.SelectedObjects.Add(obj);
								NeedsRefreshing = true;

								break;
							}
						}
					}
				}
				else if (ZS.CurrentUWMode == DungeonEditMode.Torches)
				{
					Room.SelectedObjects.Clear();
					dragx = MX / 8;
					dragy = MY / 8;

					for (int i = Room.tilesObjects.Count - 1; i >= 0; i--)
					{
						Room_Object obj = Room.tilesObjects[i];
						if (isMouseCollidingWith(obj, e))
						{
							if ((obj.options & ObjectOption.Bgr) != ObjectOption.Bgr && (obj.options & ObjectOption.Torch) == ObjectOption.Torch)
							{
								// We found a door
								Room.SelectedObjects.Add(obj);
								NeedsRefreshing = true;
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

						Room.collisionMap[px + (py * 64)] = (byte) ZS.MainForm.tileTypeCombobox.SelectedIndex;
					}
				}

				MouseIsDown = true;
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

			if (Room.SelectedObjects.Count > 0)
			{
				if (Room.SelectedObjects[0] is Room_Object oo)
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
						for (int i = 0; i < Room.tilesObjects.Count; i++)
						{
							if (Room.tilesObjects[i] == oo)
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

						for (int i = 0; i < Room.tilesObjects.Count; i++)
						{
							if (Room.tilesObjects[i] == oo)
							{
								// TODO: Add something here?
								//mainForm.selectedZUpDown.Value = i;
							}
						}

						updateSelectionObject(oo);
					}
				}
				else if (Room.SelectedObjects[0] is Sprite sp)
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
				else if (Room.SelectedObjects[0] is PotItem pp)
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
			if (Room == null) return;

			//Tile t = new Tile(0, false, false, 0, 0);
			//t.Draw(0, 0);
			ClearBgGfx(); // Technically not required

			if (showLayer1)
			{
				Room.DrawFloor1();
			}

			if (Room.bg2 != Constants.LayerMergeOff)
			{
				SetPalettesTransparent();
				if (showLayer2)
				{
					Room.DrawFloor2();
				}
			}
			else
			{
				SetPalettesBlack();
			}

			Room.reloadLayout();

			foreach (Room_Object o in Room.tilesLayoutObjects)
			{
				o.collisionPoint.Clear();
				o.Draw();
			}

			// Draw object on bitmap

			// TODO can these ifs be merged?
			foreach (Room_Object o in Room.tilesObjects)
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

			foreach (Room_Object o in Room.tilesObjects)
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
				Room.drawSprites();
			}
			if (ZS.MainForm.showChest)
			{
				drawChests();
			}
			if (ZS.MainForm.showItems)
			{
				Room.drawPotsItems();
			}

			ZS.MainForm.cgramViewer.Refresh();
		}

		public void drawChests()
		{
			if (Room.chest_list.Count > 0)
			{
				int chest_count = 0;
				foreach (Room_Object o in Room.tilesObjects)
				{
					if ((o.options & ObjectOption.Chest) == ObjectOption.Chest)
					{
						if (Room.chest_list.Count > chest_count)
						{
							Room.chest_list[chest_count].x = o.nx;
							Room.chest_list[chest_count].y = o.ny;
							if (o.id == Constants.BigChestID)
							{
								Room.chest_list[chest_count].bigChest = true;
							}
						}

						chest_count++;
					}
				}

				foreach (Chest c in Room.ChestList)
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
			if (MouseIsDown)
			{
				setMouseSizeMode(e);

				MouseIsDown = false;
				if (Room.SelectedObjects.Count == 0) // If we don't have any objects select we select what is in the rectangle
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

					if (Room.SelectedObjects.Count == 0)
					{
						ZS.DungeonForm.nothingselectedcontextMenu.Show(Cursor.Position);
					}
					else if (Room.SelectedObjects.Count == 1)
					{
						ZS.DungeonForm.singleselectedcontextMenu.Show(Cursor.Position);
					}
					else if (Room.SelectedObjects.Count > 1)
					{
						ZS.DungeonForm.groupselectedcontextMenu.Show(Cursor.Position);
					}

					MouseIsDown = false;
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

				foreach (Chest c in Room.ChestList)
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

							Room.HasUnsavedChanges = true;
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
						Room.HasUnsavedChanges = true;
						// Change chest item
						// TODO hexbox
						Chest c = new Chest(ZS, (byte) (MX / 8), (byte) (MY / 8), (byte) ZS.DungeonForm.chestPicker.chestviewer1.selectedIndex, false, false);
						Room.ChestList.Add(c);
					}
				}

				if (chestToRemove != null)
				{
					Room.ChestList.Remove(chestToRemove);
				}

				NeedsRefreshing = true;
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

				foreach (Chest c in Room.ChestList)
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
					Room.ChestList.Remove(chestToRemove);
				}

				NeedsRefreshing = true;
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

				Room.collisionMap[px + (py * 64)] = 0xFF;

				NeedsRefreshing = true;
				Refresh();
			}
		}

		public void clearCustomCollisionMap()
		{
			if (Room == null)
			{
				return;
			}

			int i = 0;
			while (i < Constants.TilesPerTilemap)
			{
				Room.collisionMap[i++] = 0xFF;
			}

			NeedsRefreshing = true;
			Refresh();
		}

		public void setObjectsPosition()
		{
			if (Room.SelectedObjects.Count > 0)
			{
				switch (ZS.CurrentUWMode)
				{
					case DungeonEditMode.Sprites:
						foreach (object o in Room.SelectedObjects)
						{
							Sprite s = o as Sprite;
							s.x = s.nx;
							s.y = s.ny;
							//(o as Sprite).boundingbox
						}
						break;

					case DungeonEditMode.Secrets:
						foreach (object o in Room.SelectedObjects)
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
						foreach (object o in Room.SelectedObjects)
						{
							Room_Object r = o as Room_Object;
							r.x = r.nx;
							r.y = r.ny;
							r.ox = r.x;
							r.oy = r.y;
						}
						break;

					case DungeonEditMode.Torches:
						foreach (object o in Room.SelectedObjects)
						{
							Room_Object r = o as Room_Object;
							r.x = r.nx;
							r.y = r.ny;
							r.ox = r.x;
							r.oy = r.y;
						}
						break;

					case DungeonEditMode.Blocks:
						foreach (object o in Room.SelectedObjects)
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

			Room.HasUnsavedChanges = true;

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
			if (Room.SelectedObjects.Count == 0)
			{
				switch (ZS.CurrentUWMode)
				{
					case DungeonEditMode.Sprites:
						foreach (Sprite spr in Room.SpritesList)
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
								Room.SelectedObjects.Add(spr);
							}
						}
						break;

					case DungeonEditMode.Secrets:
						foreach (PotItem item in Room.pot_items)
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
								Room.SelectedObjects.Add(item);
							}
						}
						break;

					case DungeonEditMode.Layer1:
					case DungeonEditMode.Layer2:
					case DungeonEditMode.Layer3:
					case DungeonEditMode.LayerAll:
						foreach (Room_Object o in Room.tilesObjects)
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
										Room.SelectedObjects.Add(o);
									}
									else if ((byte) ZS.CurrentUWMode == o.layer)
									{
										Room.SelectedObjects.Add(o);
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

		// TODO move to main form
		public void updateSelectionObject(object o)
		{
			if (Room.SelectedObjects.Count == 1)
			{
				int? objx = null;
				int? objy = null;
				int? objs = null;
				int? objl = null;
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
					if (objR.size >= 16)
					{
						objR.size = 0;
					}
					if (objR.layer >= 3)
					{
						objR.size = 2;
					}

					objdata = Room.getSelectedObjectHex();
					objx = objR.nx;
					objy = objR.ny;
					objs = objR.size;
					objl = objR.layer;

					int z = 0;

					foreach (Room_Object door in Room.tilesObjects)
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
				else if (o is object_door dobj)
				{
					if (dobj.nx >= 63)
					{
						dobj.nx = 63;
					}
					if (dobj.ny >= 63)
					{
						dobj.ny = 63;
					}
					if (dobj.size >= 16)
					{
						dobj.size = 0;
					}
					if (dobj.layer >= 3)
					{
						dobj.size = 2;
					}

					objx = dobj.nx;
					objy = dobj.ny;
					objl = dobj.layer;
				}
				else if (o is Sprite spr)
				{
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

					ZS.DungeonForm.spritesubtypeUpDown.Value = spr.subtype;
					ZS.DungeonForm.spriteoverlordCheckbox.Checked = spr.subtype.BitsAllSet(0x07);
					ZS.DungeonForm.comboBox1.SelectedIndex = spr.keyDrop;

					updating_info = false;
					//info = name + "\nId : " + id + "\nX : " + x + "\nY : " + y + "\nLayer : " + layer;
				}
				else if (o is PotItem poti)
				{
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

				ZS.DungeonForm.SelectedObjectDataX.Text = objx?.ToString("X2") ?? UIText.NullField;
				ZS.DungeonForm.SelectedObjectDataY.Text = objy?.ToString("X2") ?? UIText.NullField;
				ZS.DungeonForm.SelectedObjectDataSize.Text = objs?.ToString("X2") ?? UIText.NullField;
				ZS.DungeonForm.SelectedObjectDataLayer.Text = objl?.ToString("X2") ?? UIText.NullField;

				if (objdata != null)
				{
					ZS.DungeonForm.SelectedObjectDataHEX.Text =
						string.Format("{0:X2} {1:X2} {2:X2}", objdata[0], objdata[1], objdata[2]);
				}
				else
				{
					ZS.DungeonForm.SelectedObjectDataHEX.Text = UIText.NullField;
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
			Room.SelectedObjects.Clear();
			if (ZS.CurrentUWMode == DungeonEditMode.Sprites)
			{
				foreach (Sprite spr in Room.SpritesList)
				{
					Room.SelectedObjects.Add(spr);
				}
			}
			else if (ZS.CurrentUWMode == DungeonEditMode.Layer1 ||
				ZS.CurrentUWMode == DungeonEditMode.Layer2 ||
				ZS.CurrentUWMode == DungeonEditMode.Layer3)
			{
				byte lay = (byte) ZS.CurrentUWMode;
				foreach (Room_Object o in Room.tilesObjects)
				{
					if (o.options == ObjectOption.Nothing && o.layer == lay)
					{
						Room.SelectedObjects.Add(o);
					}
				}
			}
			// fewer conditionals to have this separate from other layers
			else if (ZS.CurrentUWMode == DungeonEditMode.LayerAll)
			{
				foreach (Room_Object o in Room.tilesObjects)
				{
					if (o.options == ObjectOption.Nothing)
					{
						Room.SelectedObjects.Add(o);
					}
				}
			}

			Refresh();
		}

		public override void Delete()
		{
			Room.HasUnsavedChanges = true;
			ZS.DungeonForm.checkAnyChanges();

			foreach (object o in Room.SelectedObjects)
			{
				if (o is Room_Object r)
				{
					Room.tilesObjects.Remove(r);
				}
				else if (o is Sprite s)
				{
					Room.SpritesList.Remove(s);
				}
				else if (o is PotItem p)
				{
					Room.pot_items.Remove(p);
				}
			}

			Room.SelectedObjects.Clear();
			DrawRoom();
			Refresh();
		}

		public override void Paste()
		{
			if (!MouseIsDown)
			{
				List<SaveObject> data = null;
				try
				{
					data = (List<SaveObject>) Clipboard.GetData(Constants.ObjectZClipboardData);
				}
				catch (Exception) { }

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

						Room.SelectedObjects.Clear();

						foreach (SaveObject o in data)
						{
							if (o.type == typeof(Sprite))
							{
								ZS.CurrentUWMode = DungeonEditMode.Sprites;
								Sprite spr = new Sprite(Room, o.id, (byte) (o.x - most_x), (byte) (o.y - most_y), o.subtype, o.layer);
								Room.SpritesList.Add(spr);
								Room.SelectedObjects.Add(spr);
							}
							else if (o.type == typeof(Room_Object))
							{
								if ((o.options & ObjectOption.Door) == ObjectOption.Door)
								{
									ZS.CurrentUWMode = DungeonEditMode.Doors;
									object_door ro = new object_door(o.tid, o.x, o.y, 0, o.layer, ZS);
									ro.setRoom(Room);
									ro.options = o.options;
									Room.tilesObjects.Add(ro);
									Room.SelectedObjects.Add(ro);
								}
								else
								{
									Room_Object ro = Room.addObject(o.tid, (byte) (o.x - most_x), (byte) (o.y - most_y), o.size, o.layer);

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

										ro.setRoom(Room);
										ro.options = o.options;
										Room.tilesObjects.Add(ro);
										Room.SelectedObjects.Add(ro);
									}
								}
							}
							else if (o.type == typeof(PotItem))
							{
								ZS.CurrentUWMode = DungeonEditMode.Secrets;
								PotItem item = new PotItem((byte) o.tid, (byte) (o.x - most_x), (byte) (o.y - most_y), o.layer == 1, ZS);
								Room.pot_items.Add(item);
								Room.SelectedObjects.Add(item);
							}
						}

						dragx = 0;
						dragy = 0;
						MouseIsDown = true;
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

			foreach (var o in Room.SelectedObjects)
			{
				if (o is Sprite objS)
				{
					odata.Add(new SaveObject(objS));
					MouseIsDown = false;
				}
				else if (o is PotItem objP)
				{
					odata.Add(new SaveObject(objP));
					MouseIsDown = false;
				}
				else if (o is Room_Object objR)
				{
					odata.Add(new SaveObject(objR));
					MouseIsDown = false;
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
				Room.SelectedObjects.Clear();

				foreach (SaveObject o in data)
				{
					if (o.type == typeof(Sprite))
					{
						Sprite spr = new Sprite(Room, o.id, (byte) (o.x - most_x), (byte) (o.y - most_y), o.subtype, o.layer);
						Room.SpritesList.Add(spr);
						Room.SelectedObjects.Add(spr);
					}
					else if (o.type == typeof(Room_Object))
					{
						Room_Object ro = Room.addObject(o.tid, (byte) (o.x - most_x), (byte) (o.y - most_y), o.size, o.layer);
						if (ro != null)
						{
							ro.setRoom(Room);
							ro.options = o.options;
							Room.tilesObjects.Add(ro);
							Room.SelectedObjects.Add(ro);
						}
					}
				}

				dragx = 0;
				dragy = 0;
				MouseIsDown = true;
			}
		}

		public override void Cut()
		{
			Clipboard.Clear();
			//Room r = (Room)room.Clone();
			//clearUselessRoomStuff(r);
			Room.HasUnsavedChanges = true;
			ZS.MainForm.checkAnyChanges();
			//undoRooms.Add(r);

			var odata = new List<SaveObject>();
			foreach (var o in Room.SelectedObjects)
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

			foreach (object o in Room.SelectedObjects)
			{
				if (o is Sprite objS)
				{
					Room.SpritesList.Remove(objS);
				}
				else if (o is PotItem objP)
				{
					Room.pot_items.Remove(objP);
				}
				else if (o is Room_Object objR)
				{
					Room.tilesObjects.Remove(objR);
				}
			}

			Room.SelectedObjects.Clear();
			DrawRoom();
			Refresh();
		}

		// TODO magic numbers
		public override void insertNew()
		{
			switch (ZS.CurrentUWMode)
			{
				case DungeonEditMode.Blocks:
					Room.SelectedObjects.Clear();
					Room_Object rb = Room.addObject(Constants.TorchPseudoID, 0, 0, 0, 0);

					if (rb != null)
					{
						rb.setRoom(Room);
						rb.options = ObjectOption.Block;
						Room.tilesObjects.Add(rb);
						Room.SelectedObjects.Add(rb);
						dragx = 0;
						dragy = 0;
						MouseIsDown = true;
					}
					break;

				case DungeonEditMode.Secrets:
					Room.SelectedObjects.Clear();
					PotItem p = new PotItem(1, 0, 0, false, ZS);
					Room.pot_items.Add(p);
					Room.SelectedObjects.Add(p);
					dragx = 0;
					dragy = 0;
					MouseIsDown = true;
					break;

				case DungeonEditMode.Chests:
					addChest();
					break;

				case DungeonEditMode.Torches:
					Room.SelectedObjects.Clear();
					Room_Object rt = Room.addObject(0x150, 0, 0, 0, 0);
					if (rt != null)
					{
						rt.setRoom(Room);
						rt.options = ObjectOption.Torch;
						Room.tilesObjects.Add(rt);
						Room.SelectedObjects.Add(rt);
						dragx = 0;
						dragy = 0;
						MouseIsDown = true;
					}
					break;

				case DungeonEditMode.Doors:
					Room.SelectedObjects.Clear();
					Room_Object rd = new object_door(0, 0, 0, 0, 0, ZS);
					if (rd != null)
					{
						rd.setRoom(Room);
						rd.options = ObjectOption.Door;
						Room.tilesObjects.Add(rd);
						Focus();
						ZS.ActiveScene = this;
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
			if (Room.SelectedObjects.Count > 0)
			{
				if (Room.SelectedObjects[0] is Room_Object)
				{
					foreach (Room_Object o in Room.SelectedObjects)
					{
						for (int i = 0; i < Room.tilesObjects.Count; i++)
						{
							if (o == Room.tilesObjects[i])
							{
								if (i > 0)
								{
									Room.tilesObjects.RemoveAt(i);
									Room.tilesObjects.Insert(i - 1, o);
								}

								break;
							}
						}
					}
				}

				DrawRoom();
				Refresh();
				MouseIsDown = false;
			}
		}

		public override void UpdateSelectedZ(int position)
		{
			if (Room.SelectedObjects.Count > 0)
			{
				if (Room.SelectedObjects[0] is Room_Object)
				{
					foreach (Room_Object o in Room.SelectedObjects)
					{
						for (int i = 0; i < Room.tilesObjects.Count; i++)
						{
							if (o == Room.tilesObjects[i])
							{
								if (i < Room.tilesObjects.Count - 1)
								{
									Room.tilesObjects.RemoveAt(i);
									Room.tilesObjects.Insert(position, o);
								}

								break;
							}
						}
					}
				}

				DrawRoom();
				Refresh();
				MouseIsDown = false;
			}
		}

		public void updateRoomInfos(DungeonMain mainForm)
		{
			mainForm.UpdateUIForRoom(Room, true);
		}
	}
}
