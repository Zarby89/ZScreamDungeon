namespace ZeldaFullEditor.UserInterface.UIControl.Scene
{
	//	public class SceneUW2 : Scene2
	//	{
	//		public Bitmap tempBitmap = new Bitmap(512, 512);
	//		public ushort[] doorsObject = new ushort[] { 0x138, 0x139, 0x13A, 0x13B, 0xF9E, 0xFA9, 0xF9F, 0xFA0, 0x12D, 0x12E, 0x12F, 0x12E, 0x12D, 0x4632, 0x4693 };
	//		Rectangle lastSelectedRectangle;
	//		SceneResizing resizeType = SceneResizing.none;
	//
	//		public bool forPreview = false;
	//
	//		bool resizing = false;
	//
	//		int rmx = 0;
	//		int rmy = 0;

	//
	//		// TODO: FIND PROBLEM THAT IS INCREASING SAVE TIME!!
	//		private void OnMouseMove(object sender, MouseEventArgs e)
	//		{
	//			ZGUI.GetXYMouseBasedOnZoom(e, out int MX, out int MY);
	//
	//			if (!colliding_chest)
	//			{
	//				ZGUI.toolTip1.Hide(this);
	//			}
	//
	//			if (mouse_down) // Slowdown problem in save caused by something here
	//			{
	//				//updating_info = true;
	//
	//				setMouseSizeMode(e); // Define the size of mx,my for each mode
	//				if (ZS.CurrentUWMode != DungeonEditMode.Doors)
	//				{
	//					if (mx != last_mx || my != last_my)
	//					{
	//						need_refresh = true;
	//
	//						if (room.selectedObject.Count > 0)
	//						{
	//							move_objects();
	//							room.has_changed = true;
	//							last_mx = mx;
	//							last_my = my;
	//							ZGUI.DungeonEditor.UpdateFormForSelectedObject((room.selectedObject[0]);
	//						}
	//
	//					}
	//
	//					
	//				}
	//				else // If it is a door
	//				{
	//					if (room.selectedObject.Count > 0 &&
	//						room.selectedObject[0] is object_door dobj &&
	//						doorArray != null)
	//					{
	//						for (int i = 0; i < 48; i++)
	//						{
	//							Rectangle r = doorArray[i];
	//							if (lastSelectedRectangle != r && new Rectangle(MX, MY, 1, 1).IntersectsWith(r))
	//							{
	//								lastSelectedRectangle = r;
	//								int doordir = i / 12;
	//								if (dobj.door_pos != (byte) ((i * 2) - (doordir * 12)) ||
	//									dobj.door_dir != (byte) doordir)
	//								{
	//									dobj.door_pos = (byte) ((i - (doordir * 12)) * 2);
	//									dobj.door_dir = (byte) doordir;
	//									dobj.updateId();
	//									dobj.Draw();
	//									room.has_changed = true;
	//								}
	//
	//								break;
	//							}
	//						}
	//					}
	//				}
	//
	//				DrawRoom();
	//				Refresh();
	//			}
	//		}
	//
	//
	//		public void drawDoorsPosition(Graphics g)
	//		{
	//			if (mouse_down && room.selectedObject.Count > 0 && room.selectedObject[0] is Room_Object rr)
	//			{
	//				if ((rr.options & ObjectOption.Door) == ObjectOption.Door)
	//				{
	//					//for (int i = 0; i < 12; i++)
	//					//{
	//					g.DrawRectangles(Constants.ThirdGreenPen, doorArray);
	//					//drawText(g,doorArray)
	//					//}
	//				}
	//			}
	//		}
	//
	//		public override void Clear()
	//		{
	//			// TODO: Add something here?
	//			//graphics.Clear(this.BackColor);
	//		}
	//
	//		private void OnMouseDown(object sender, MouseEventArgs e)
	//		{
	//			if (room == null)
	//			{
	//				return;
	//			}
	//
	//			ZGUI.GetXYMouseBasedOnZoom(e, out int MX, out int MY);
	//
	//			//this.Focus();
	//
	//			room.has_changed = true;
	//			ZGUI.DungeonEditor.checkAnyChanges();
	//
	//			switch (ZS.CurrentUWMode)
	//			{
	//				case DungeonEditMode.Layer1:
	//				case DungeonEditMode.Layer2:
	//				case DungeonEditMode.Layer3:
	//				case DungeonEditMode.LayerAll:
	//					if (room.selectedObject.Count == 1 && resizeType != SceneResizing.none)
	//					{
	//						//Room_Object obj = (room.selectedObject[0] as Room_Object);
	//						mouse_down = true;
	//						resizing = true;
	//						dragx = MX;
	//						dragy = MY;
	//						return;
	//					}
	//					break;
	//			}
	//
	//			if (ZGUI.DungeonEditor.tabControl1.SelectedIndex == 1) // If we are on object tab
	//			{
	//				switch (ZS.CurrentUWMode)
	//				{
	//					case DungeonEditMode.Layer1:
	//					case DungeonEditMode.Layer2:
	//					case DungeonEditMode.Layer3:
	//						if (selectedDragObject != null) // If there's an object selected
	//						{
	//							room.selectedObject.Clear(); // Clear the object buffer
	//
	//							// Add the new object in the buffer
	//							byte lay = 0;
	//							switch (ZS.CurrentUWMode)
	//							{
	//								case DungeonEditMode.Layer1:
	//									lay = 0;
	//									break;
	//								case DungeonEditMode.Layer2:
	//									lay = 1;
	//									break;
	//								case DungeonEditMode.Layer3:
	//									lay = 2;
	//									break;
	//							}
	//
	//							Room_Object ro = room.addObject(selectedDragObject.id, 0, 0, 0, lay);
	//
	//							if (ro != null)
	//							{
	//								ro.setRoom(room);
	//								ro.getObjectSize();
	//								room.tilesObjects.Add(ro);
	//								room.selectedObject.Add(ro);
	//								dragx = 0;
	//								dragy = 0;
	//							}
	//
	//							room.has_changed = true;
	//							mouse_down = true;
	//							selectedDragObject = null;
	//							ZGUI.DungeonEditor.objectViewer1.selectedObject = null;
	//							ZGUI.DungeonEditor.objectViewer1.Refresh();
	//						}
	//						break;
	//
	//					default:
	//						if (selectedDragObject != null) // If there's an object selected
	//						{
	//							selectedDragObject = null; // Set the object null
	//							ZGUI.DungeonEditor.objectViewer1.selectedIndex = -1;
	//							ZGUI.DungeonEditor.objectViewer1.selectedObject = null;
	//							ZGUI.DungeonEditor.objectViewer1.Refresh();
	//							mouse_down = false;
	//
	//							MessageBox.Show("Objects can only be placed while working on backgrounds 1, 2, or 3.");
	//							return;
	//						}
	//						break;
	//				}
	//			}
	//			else if (ZGUI.DungeonEditor.tabControl1.SelectedIndex == 2)
	//			{
	//				if (selectedDragSprite != null)
	//				{
	//					room.selectedObject.Clear();
	//
	//					Sprite spr = new Sprite(room, (byte) selectedDragSprite.id, 0, 0, selectedDragSprite.option, 0);
	//
	//					if (spr != null)
	//					{
	//						ZGUI.DungeonEditor.UpdateUnderworldMode(DungeonEditMode.Sprites);
	//						room.selectedObject.Add(spr);
	//						dragx = 0;
	//						dragy = 0;
	//						room.sprites.Add(spr);
	//					}
	//
	//					room.has_changed = true;
	//					mouse_down = true;
	//					selectedDragObject = null;
	//					selectedDragSprite = null;
	//
	//					ZGUI.DungeonEditor.spritesView1.selectedObject = null;
	//					ZGUI.DungeonEditor.spritesView1.Refresh();
	//				}
	//			}
	//
	//			if (!mouse_down)
	//			{
	//				doorArray = new Rectangle[48];
	//				found = false;
	//
	//				if (ZS.CurrentUWMode == DungeonEditMode.Blocks)
	//				{
	//					dragx = MX / 16;
	//					dragy = MY / 16;
	//
	//					if (room.selectedObject.Count == 1)
	//					{
	//						room.selectedObject.Clear();
	//					}
	//
	//					foreach (Sprite spr in room.sprites)
	//					{
	//						if (isMouseCollidingWith(spr, e) && !spr.selected)
	//						{
	//							room.selectedObject.Add(spr);
	//							found = true;
	//							break;
	//						}
	//					}
	//
	//					if (!found) // We didnt find any sprites to click on so just clear the selection
	//					{
	//						room.selectedObject.Clear();
	//					}
	//				}
	//				else if (ZS.CurrentUWMode == DungeonEditMode.Secrets)
	//				{
	//					dragx = MX / 8;
	//					dragy = MY / 8;
	//
	//					if (room.selectedObject.Count == 1)
	//					{
	//						//foreach (Object o in room.pot_items)
	//						//{
	//						//	// TODO: Add something here?
	//						//	//(o as PotItem).selected = false;
	//						//}
	//
	//						room.selectedObject.Clear();
	//					}
	//
	//					foreach (PotItem item in room.pot_items)
	//					{
	//						if (isMouseCollidingWith(item, e) && !item.selected)
	//						{
	//							room.selectedObject.Add(item);
	//							found = true;
	//							break;
	//						}
	//					}
	//
	//					if (!found) // We didnt find any items to click on so just clear the selection
	//					{
	//						room.selectedObject.Clear();
	//					}
	//				}
	//				else if (ZS.CurrentUWMode == DungeonEditMode.Layer1 || ZS.CurrentUWMode == DungeonEditMode.Layer2 ||
	//					ZS.CurrentUWMode == DungeonEditMode.Layer3 || ZS.CurrentUWMode == DungeonEditMode.LayerAll)
	//				{
	//					dragx = MX / 8;
	//					dragy = MY / 8;
	//					found = false;
	//
	//					for (int i = room.tilesObjects.Count - 1; i >= 0; i--)
	//					{
	//						Room_Object obj = room.tilesObjects[i];
	//						if (ZS.CurrentUWMode != DungeonEditMode.LayerAll && ((byte) ZS.CurrentUWMode != obj.layer))
	//						{
	//							continue;
	//						}
	//
	//						if (isMouseCollidingWith(obj, e))
	//						{
	//							if (room.selectedObject.Count != 0)
	//							{
	//								if (room.selectedObject.Contains(obj))
	//								{
	//									found = true;
	//									break;
	//								}
	//
	//								if (ModifierKeys != Keys.Shift && ModifierKeys != Keys.Control)
	//								{
	//									room.selectedObject.Clear();
	//								}
	//							}
	//
	//							if ((obj.options & ObjectOption.Bgr) != ObjectOption.Bgr
	//								&& (obj.options & ObjectOption.Door) != ObjectOption.Door
	//								&& (obj.options & ObjectOption.Torch) != ObjectOption.Torch
	//								&& (obj.options & ObjectOption.Block) != ObjectOption.Block)
	//							{
	//								for (int p = 0; p < obj.collisionPoint.Count; p++)
	//								{
	//									//Console.WriteLine(obj.collisionPoint[p].X);
	//									if (MX >= obj.collisionPoint[p].X && MX <= obj.collisionPoint[p].X + 8
	//										&& MY >= obj.collisionPoint[p].Y && MY <= obj.collisionPoint[p].Y + 8)
	//									{
	//										room.selectedObject.Add(obj);
	//										found = true;
	//
	//										break;
	//									}
	//								}
	//
	//								if (found)
	//								{
	//									break;
	//								}
	//							}
	//						}
	//					}
	//
	//					if (!found) // We didnt find any Tiles to click on so just clear the selection
	//					{
	//						if (ModifierKeys != Keys.Shift && ModifierKeys != Keys.Control)
	//						{
	//							//Console.WriteLine("we didnt find any object so clear all");
	//							room.selectedObject.Clear();
	//						}
	//					}
	//				}
	//				else if (ZS.CurrentUWMode == DungeonEditMode.Doors)
	//				{
	//					// Console.Write("Door mode");
	//					room.selectedObject.Clear();
	//					dragx = MX / 8;
	//					dragy = MY / 8;
	//
	//					for (int i = room.tilesObjects.Count - 1; i >= 0; i--)
	//					{
	//						Room_Object obj = room.tilesObjects[i];
	//						if (isMouseCollidingWith(obj, e))
	//						{
	//							if ((obj.options & ObjectOption.Door) == ObjectOption.Door)
	//							{
	//								// We found a door! hooray!
	//								room.selectedObject.Add(obj);
	//								obj.selected = true;
	//								doorArray = room.getAllDoorPosition(obj);
	//								need_refresh = true;
	//
	//								break;
	//							}
	//						}
	//					}
	//				}
	//				else if (ZS.CurrentUWMode == DungeonEditMode.Blocks)
	//				{
	//					room.selectedObject.Clear();
	//					dragx = MX / 8;
	//					dragy = MY / 8;
	//
	//					for (int i = room.tilesObjects.Count - 1; i >= 0; i--)
	//					{
	//						Room_Object obj = room.tilesObjects[i];
	//						if (isMouseCollidingWith(obj, e))
	//						{
	//							if ((obj.options & ObjectOption.Bgr) != ObjectOption.Bgr && (obj.options & ObjectOption.Block) == ObjectOption.Block)
	//							{
	//								room.selectedObject.Add(obj);
	//								need_refresh = true;
	//
	//								break;
	//							}
	//						}
	//					}
	//				}
	//				else if (ZS.CurrentUWMode == DungeonEditMode.Torches)
	//				{
	//					room.selectedObject.Clear();
	//					dragx = MX / 8;
	//					dragy = MY / 8;
	//
	//					for (int i = room.tilesObjects.Count - 1; i >= 0; i--)
	//					{
	//						Room_Object obj = room.tilesObjects[i];
	//						if (isMouseCollidingWith(obj, e))
	//						{
	//							if ((obj.options & ObjectOption.Bgr) != ObjectOption.Bgr && (obj.options & ObjectOption.Torch) == ObjectOption.Torch)
	//							{
	//								// We found a door
	//								room.selectedObject.Add(obj);
	//								need_refresh = true;
	//								DrawRoom();
	//								Refresh();
	//
	//								break;
	//							}
	//						}
	//					}
	//				}
	//				else if (ZS.CurrentUWMode == DungeonEditMode.CollisionMap)
	//				{
	//					// What happens when the mouse is clicked in the Collision map mode
	//					if (e.Button == MouseButtons.Left)
	//					{
	//						int px = e.X / 16;
	//						int py = e.Y / 16;
	//
	//						room.collisionMap[px + (py * 64)] = (byte) ZGUI.tileTypeCombobox.SelectedIndex;
	//					}
	//				}
	//
	//				mouse_down = true;
	//				move_x = 0;
	//				move_y = 0;
	//				mx = dragx;
	//				my = dragy;
	//				last_mx = mx;
	//				last_my = my;
	//			} end of mouse down
	//
	//			ZGUI.DungeonEditor.spritepropertyPanel.Visible = false;
	//			ZGUI.DungeonEditor.potitemobjectPanel.Visible = false;
	//			ZGUI.DungeonEditor.doorselectPanel.Visible = false;
	//			ZGUI.DungeonEditor.litCheckbox.Visible = false;
	//			updating_info = false;
	//
	//			if (room.selectedObject.Count > 0)
	//			{
	//				if (room.selectedObject[0] is Room_Object oo)
	//				{
	//					ZGUI.DungeonEditor.selectedGroupbox.Text = UIText.FormatSelectedObject(oo);
	//
	//					if (oo.options == ObjectOption.Door)
	//					{
	//						ZGUI.DungeonEditor.comboBox1.Enabled = false;
	//						ZGUI.DungeonEditor.doorselectPanel.Visible = true;
	//						int[] aposes = ZGUI.DungeonEditor.door_index.Select(
	//							(s, i) => new { s, i })
	//							.Where(x => x.s == (oo as object_door).door_type)
	//							.Select(x => x.i)
	//							.ToArray();
	//						int apos = 0;
	//
	//						if (aposes.Length > 0)
	//						{
	//							apos = aposes[0];
	//						}
	//
	//						ZGUI.DungeonEditor.comboBox2.SelectedIndex = apos;
	//						for (int i = 0; i < room.tilesObjects.Count; i++)
	//						{
	//							if (room.tilesObjects[i] == oo)
	//							{
	//								// TODO: Add something here?
	//								//mainForm.selectedZUpDown.Value = i;
	//							}
	//						}
	//
	//						updateSelectionObject(oo);
	//					}
	//					else if (oo.options == ObjectOption.Torch)
	//					{
	//						ZGUI.DungeonEditor.litCheckbox.Visible = true;
	//						ZGUI.DungeonEditor.litCheckbox.Checked = oo.lit;
	//						updateSelectionObject(oo);
	//					}
	//					else
	//					{
	//						ZGUI.DungeonEditor.comboBox1.Enabled = false;
	//
	//						for (int i = 0; i < room.tilesObjects.Count; i++)
	//						{
	//							if (room.tilesObjects[i] == oo)
	//							{
	//								// TODO: Add something here?
	//								//mainForm.selectedZUpDown.Value = i;
	//							}
	//						}
	//
	//						updateSelectionObject(oo);
	//					}
	//				}
	//				else if (room.selectedObject[0] is Sprite sp)
	//				{
	//					ZGUI.DungeonEditor.spritepropertyPanel.Visible = true;
	//					string name = null;
	//					if (sp.subtype.BitsAllSet(0x07))
	//					{
	//						if (sp.id <= 0x1A && sp.id > 0x00)
	//						{
	//							name = Sprites_Names.overlordnames[sp.id - 1];
	//						}
	//
	//						ZGUI.DungeonEditor.spriteoverlordCheckbox.Checked = true;
	//					}
	//					else
	//					{
	//						ZGUI.DungeonEditor.spriteoverlordCheckbox.Checked = false;
	//					}
	//
	//					name = name ?? Sprites_Names.name[sp.id];
	//
	//					ZGUI.DungeonEditor.selectedGroupbox.Text = UIText.FormatSelectedSprite(sp, name);
	//					ZGUI.DungeonEditor.comboBox1.Enabled = true;
	//					updateSelectionObject(sp);
	//				}
	//				else if (room.selectedObject[0] is PotItem pp)
	//				{
	//					ZGUI.DungeonEditor.potitemobjectPanel.Visible = true; // oO why this is not appearing
	//					int dropboxid = pp.id.BitIsOn(0x80)
	//						? ((pp.id - 0x80) / 2) + 0x17
	//						: pp.id;
	//
	//					// If for some reason the dropboxid >= 28
	//					if (dropboxid >= 28)
	//					{
	//						dropboxid = 27; // Prevent crash :yay:
	//					}
	//
	//					ZGUI.DungeonEditor.selectedGroupbox.Text = UIText.FormatSelectedPotItem(pp, ItemsNames.name[dropboxid]);
	//					ZGUI.DungeonEditor.selecteditemobjectCombobox.SelectedIndex = dropboxid;
	//					updateSelectionObject(pp);
	//				}
	//			}
	//
	//			updating_info = false;
	//		}
	//
	//		public unsafe void ClearBgGfx()
	//		{
	//			byte* bg1data = (byte*) ZS.GFXManager.roomBg1Ptr.ToPointer();
	//			byte* bg2data = (byte*) ZS.GFXManager.roomBg2Ptr.ToPointer();
	//
	//			for (int i = 0; i < 512 * 512; i++)
	//			{
	//				bg1data[i] = 0;
	//				bg2data[i] = 0;
	//			}
	//		}
	//
	//		public unsafe void DrawRoom()
	//		{
	//			if (room == null) return;
	//
	//			//Tile t = new Tile(0, false, false, 0, 0);
	//			//t.Draw(0, 0);
	//			ClearBgGfx(); // Technically not required
	//
	//			if (showLayer1)
	//			{
	//				room.DrawFloor1();
	//			}
	//
	//			if (room.bg2 != Constants.LayerMergeOff)
	//			{
	//				SetPalettesTransparent();
	//				if (showLayer2)
	//				{
	//					room.DrawFloor2();
	//				}
	//			}
	//			else
	//			{
	//				SetPalettesBlack();
	//			}
	//
	//			room.reloadLayout();
	//
	//			foreach (Room_Object o in room.tilesLayoutObjects)
	//			{
	//				o.collisionPoint.Clear();
	//				o.Draw();
	//			}
	//
	//			// Draw object on bitmap
	//
	//			// TODO can these ifs be merged?
	//			foreach (Room_Object o in room.tilesObjects)
	//			{
	//				if (o.options == ObjectOption.Door || o.layer != 2)
	//				{
	//					o.collisionPoint.Clear();
	//					o.Draw();
	//				}
	//				//if (o.options == ObjectOption.Door)
	//				//{
	//				//	o.collisionPoint.Clear();
	//				//	o.Draw();
	//				//}
	//			}
	//
	//			foreach (Room_Object o in room.tilesObjects)
	//			{
	//				// Draw doors here since they'll all be put on bg3 anyways
	//				if (o.layer == 2)
	//				{
	//					o.collisionPoint.Clear();
	//					o.Draw();
	//				}
	//			}
	//
	//			if (showLayer1)
	//			{
	//				ZS.GFXManager.DrawBG1();
	//			}
	//			if (showLayer2)
	//			{
	//				ZS.GFXManager.DrawBG2();
	//			}
	//			if (ZGUI.showSprite)
	//			{
	//				room.drawSprites();
	//			}
	//			if (ZGUI.showChest)
	//			{
	//				drawChests();
	//			}
	//			if (ZGUI.showItems)
	//			{
	//				room.drawPotsItems();
	//			}
	//
	//			ZGUI.cgramViewer.Refresh();
	//		}
	//
	//		public void drawChests()
	//		{
	//			if (room.chest_list.Count > 0)
	//			{
	//				int chest_count = 0;
	//				foreach (Room_Object o in room.tilesObjects)
	//				{
	//					if ((o.options & ObjectOption.Chest) == ObjectOption.Chest)
	//					{
	//						if (room.chest_list.Count > chest_count)
	//						{
	//							room.chest_list[chest_count].x = o.nx;
	//							room.chest_list[chest_count].y = o.ny;
	//							if (o.id == Constants.BigChestID)
	//							{
	//								room.chest_list[chest_count].bigChest = true;
	//							}
	//						}
	//
	//						chest_count++;
	//					}
	//				}
	//
	//				foreach (Chest c in room.chest_list)
	//				{
	//					if (c.item <= 75)
	//					{
	//						//g.DrawRectangle(Pens.Blue,(c.x * 8), (c.y - 2) * 8, 16, 16);
	//
	//						if (c.bigChest)
	//						{
	//							c.ItemsDraw(c.item, (c.x + 1) * 8, (c.y - 2) * 8);
	//						}
	//						else
	//						{
	//							c.ItemsDraw(c.item, c.x * 8, (c.y - 2) * 8);
	//						}
	//
	//						//graphics.DrawImage(ZS.GFXManager.chestitems_bitmap[c.item], (c.x * 8), (c.y - 2) * 8);
	//					}
	//				}
	//			}
	//		}
	//
	//		private unsafe void OnMouseUp(object sender, MouseEventArgs e)
	//		{
	//			resizing = false;
	//			if (mouse_down)
	//			{
	//				setMouseSizeMode(e);
	//
	//				mouse_down = false;
	//				if (room.selectedObject.Count == 0) // If we don't have any objects select we select what is in the rectangle
	//				{
	//					getObjectsRectangle();
	//				}
	//				else
	//				{
	//					setObjectsPosition();
	//				}
	//
	//				if (e.Button == MouseButtons.Right) // That's a problem
	//				{
	//					rmx = e.X;
	//					rmy = e.Y;
	//					ZGUI.DungeonEditor.nothingselectedcontextMenu.Items[0].Enabled = true;
	//					ZGUI.DungeonEditor.singleselectedcontextMenu.Items[0].Enabled = true;
	//					ZGUI.DungeonEditor.groupselectedcontextMenu.Items[0].Enabled = true;
	//					ZGUI.DungeonEditor.nothingselectedcontextMenu.Items[0].Visible = true;
	//					ZGUI.DungeonEditor.singleselectedcontextMenu.Items[0].Visible = true;
	//					ZGUI.DungeonEditor.groupselectedcontextMenu.Items[0].Visible = true;
	//					string nname = null;
	//
	//					// TODO copy
	//					switch (ZS.CurrentUWMode)
	//					{
	//						case DungeonEditMode.Chests:
	//							nname = "chest item";
	//							ZGUI.DungeonEditor.nothingselectedcontextMenu.Items[2].Visible = true;
	//							ZGUI.DungeonEditor.nothingselectedcontextMenu.Items[3].Visible = false;
	//							break;
	//
	//						case DungeonEditMode.Secrets:
	//							nname = "pot item";
	//							break;
	//
	//						case DungeonEditMode.Blocks:
	//							nname = "pushable block";
	//							break;
	//
	//						case DungeonEditMode.Torches:
	//							nname = "torch";
	//							break;
	//
	//						case DungeonEditMode.Doors:
	//							nname = "door";
	//							break;
	//
	//						case DungeonEditMode.CollisionMap:
	//							nname = "custom collision map";
	//							ZGUI.DungeonEditor.nothingselectedcontextMenu.Items[0].Visible = false;
	//							ZGUI.DungeonEditor.nothingselectedcontextMenu.Items[1].Visible = false;
	//							ZGUI.DungeonEditor.nothingselectedcontextMenu.Items[2].Visible = true;
	//							ZGUI.DungeonEditor.nothingselectedcontextMenu.Items[3].Visible = true;
	//							break;
	//
	//						case DungeonEditMode.Sprites:
	//							ZGUI.DungeonEditor.nothingselectedcontextMenu.Items[0].Visible = false;
	//							ZGUI.DungeonEditor.nothingselectedcontextMenu.Items[2].Visible = false;
	//							ZGUI.DungeonEditor.nothingselectedcontextMenu.Items[3].Visible = false;
	//							ZGUI.DungeonEditor.singleselectedcontextMenu.Items[0].Visible = false;
	//							ZGUI.DungeonEditor.groupselectedcontextMenu.Items[0].Visible = false;
	//							break;
	//
	//						case DungeonEditMode.Layer1:
	//						case DungeonEditMode.Layer2:
	//						case DungeonEditMode.Layer3:
	//						case DungeonEditMode.LayerAll:
	//							ZGUI.DungeonEditor.nothingselectedcontextMenu.Items[0].Visible = false;
	//							ZGUI.DungeonEditor.nothingselectedcontextMenu.Items[2].Visible = false;
	//							ZGUI.DungeonEditor.nothingselectedcontextMenu.Items[3].Visible = false;
	//							ZGUI.DungeonEditor.singleselectedcontextMenu.Items[0].Visible = false;
	//							ZGUI.DungeonEditor.groupselectedcontextMenu.Items[0].Visible = false;
	//							break;
	//					}
	//
	//
	//					if (nname != null)
	//					{
	//						string s = string.Format("Insert new {0}", nname);
	//						ZGUI.DungeonEditor.nothingselectedcontextMenu.Items[0].Text = s;
	//						ZGUI.DungeonEditor.singleselectedcontextMenu.Items[0].Text = s;
	//						ZGUI.DungeonEditor.groupselectedcontextMenu.Items[0].Text = s;
	//					}
	//
	//					if (room.selectedObject.Count == 0)
	//					{
	//						ZGUI.DungeonEditor.nothingselectedcontextMenu.Show(Cursor.Position);
	//					}
	//					else if (room.selectedObject.Count == 1)
	//					{
	//						ZGUI.DungeonEditor.singleselectedcontextMenu.Show(Cursor.Position);
	//					}
	//					else if (room.selectedObject.Count > 1)
	//					{
	//						ZGUI.DungeonEditor.groupselectedcontextMenu.Show(Cursor.Position);
	//					}
	//
	//					mouse_down = false;
	//				}
	//			}
	//
	//			DrawRoom();
	//			Refresh();
	//		}
	//
	//		public void setObjectsPosition()
	//		{
	//			if (room.selectedObject.Count > 0)
	//			{
	//				switch (ZS.CurrentUWMode)
	//				{
	//					case DungeonEditMode.Sprites:
	//						foreach (object o in room.selectedObject)
	//						{
	//							Sprite s = o as Sprite;
	//							s.x = s.nx;
	//							s.y = s.ny;
	//							//(o as Sprite).boundingbox
	//						}
	//						break;
	//
	//					case DungeonEditMode.Secrets:
	//						foreach (object o in room.selectedObject)
	//						{
	//							PotItem p = o as PotItem;
	//							p.x = p.nx;
	//							p.y = p.ny;
	//						}
	//						break;
	//
	//					case DungeonEditMode.Layer1:
	//					case DungeonEditMode.Layer2:
	//					case DungeonEditMode.Layer3:
	//					case DungeonEditMode.LayerAll:
	//						foreach (object o in room.selectedObject)
	//						{
	//							Room_Object r = o as Room_Object;
	//							r.x = r.nx;
	//							r.y = r.ny;
	//							r.ox = r.x;
	//							r.oy = r.y;
	//						}
	//						break;
	//
	//					case DungeonEditMode.Torches:
	//						foreach (object o in room.selectedObject)
	//						{
	//							Room_Object r = o as Room_Object;
	//							r.x = r.nx;
	//							r.y = r.ny;
	//							r.ox = r.x;
	//							r.oy = r.y;
	//						}
	//						break;
	//
	//					case DungeonEditMode.Blocks:
	//						foreach (object o in room.selectedObject)
	//						{
	//							Room_Object r = o as Room_Object;
	//							r.x = r.nx;
	//							r.y = r.ny;
	//							r.ox = r.x;
	//							r.oy = r.y;
	//						}
	//						break;
	//				}
	//			}
	//
	//			room.has_changed = true;
	//		}
	//
	//		// TODO switch statements and no casting the selected mode
	//		public void setMouseSizeMode(MouseEventArgs e)
	//		{
	//			ZGUI.GetXYMouseBasedOnZoom(e, out int MX, out int MY);
	//
	//			switch (ZS.CurrentUWMode)
	//			{
	//				case DungeonEditMode.Sprites:
	//					mx = MX / 16;
	//					my = MY / 16;
	//					break;
	//
	//				case DungeonEditMode.Secrets:
	//
	//				case DungeonEditMode.Layer1:
	//				case DungeonEditMode.Layer2:
	//				case DungeonEditMode.Layer3:
	//				case DungeonEditMode.LayerAll:
	//
	//				case DungeonEditMode.Torches:
	//				case DungeonEditMode.Blocks:
	//					mx = MX / 8;
	//					my = MY / 8;
	//					break;
	//			}
	//
	//			move_x = mx - dragx; // Number of tiles mouse is compared to starting drag point X
	//			move_y = my - dragy; // Number of tiles mouse is compared to starting drag point Y
	//		}
	//
	//		public void getObjectsRectangle()
	//		{
	//			if (room.selectedObject.Count == 0)
	//			{
	//				switch (ZS.CurrentUWMode)
	//				{
	//					case DungeonEditMode.Sprites:
	//						foreach (Sprite spr in room.sprites)
	//						{
	//							int rx = dragx;
	//							int ry = dragy;
	//
	//							if (move_x < 0)
	//							{
	//								Math.Abs(rx = dragx + move_x);
	//							}
	//							if (move_y < 0)
	//							{
	//								Math.Abs(ry = dragy + move_y);
	//							}
	//
	//							if (spr.boundingbox.IntersectsWith(new Rectangle(rx * 16, ry * 16, Math.Abs(move_x) * 16, Math.Abs(move_y) * 16)))
	//							{
	//								room.selectedObject.Add(spr);
	//							}
	//						}
	//						break;
	//
	//					case DungeonEditMode.Secrets:
	//						foreach (PotItem item in room.pot_items)
	//						{
	//							int rx = dragx;
	//							int ry = dragy;
	//							if (move_x < 0)
	//							{
	//								Math.Abs(rx = dragx + move_x);
	//							}
	//
	//							if (move_y < 0)
	//							{
	//								Math.Abs(ry = dragy + move_y);
	//							}
	//
	//							if (new Rectangle(item.x * 8, item.y * 8, 16, 16).IntersectsWith(
	//								new Rectangle(rx * 8, ry * 8, Math.Abs(move_x) * 8, Math.Abs(move_y) * 8)))
	//							{
	//								room.selectedObject.Add(item);
	//							}
	//						}
	//						break;
	//
	//					case DungeonEditMode.Layer1:
	//					case DungeonEditMode.Layer2:
	//					case DungeonEditMode.Layer3:
	//					case DungeonEditMode.LayerAll:
	//						foreach (Room_Object o in room.tilesObjects)
	//						{
	//							int rx = dragx;
	//							int ry = dragy;
	//
	//							if (move_x < 0)
	//							{
	//								Math.Abs(rx = dragx + move_x);
	//							}
	//							if (move_y < 0)
	//							{
	//								Math.Abs(ry = dragy + move_y);
	//							}
	//
	//							int yfix = o.diagonalFix
	//								? -(6 + o.size)
	//								: 0;
	//
	//							if (new Rectangle(
	//								(o.x + o.offsetX) * 8,
	//								(o.y + o.offsetY + yfix) * 8,
	//								o.width + o.offsetX,
	//								o.height + o.offsetY + yfix)
	//								.IntersectsWith(new Rectangle(rx * 8, ry * 8, Math.Abs(move_x) * 8, Math.Abs(move_y) * 8)))
	//							{
	//								if ((o.options & ObjectOption.Bgr) != ObjectOption.Bgr
	//									&& (o.options & ObjectOption.Door) != ObjectOption.Door
	//									&& (o.options & ObjectOption.Torch) != ObjectOption.Torch
	//									&& (o.options & ObjectOption.Block) != ObjectOption.Block)
	//								{
	//									if (ZS.CurrentUWMode == DungeonEditMode.LayerAll)
	//									{
	//										room.selectedObject.Add(o);
	//									}
	//									else if ((byte) ZS.CurrentUWMode == o.layer)
	//									{
	//										room.selectedObject.Add(o);
	//									}
	//								}
	//							}
	//						}
	//						break;
	//				}
	//			}
	//
	//			/*
	//            foreach(Room_Object o in room.selectedObject)
	//            {
	//                Console.WriteLine(o.id.ToString("X4") + o.name);
	//            }
	//            */
	//		}
	//
	//
	//		/*
	//        public void Undo()
	//        {
	//            if (DungeonsData.undoRoom[room.index].Count > 0)
	//            {
	//                DungeonsData.redoRoom[room.index].Add((Room)room.Clone());
	//                room = DungeonsData.undoRoom[room.index][(DungeonsData.undoRoom[room.index].Count - 1)];
	//                DungeonsData.undoRoom[room.index].RemoveAt(DungeonsData.undoRoom[room.index].Count - 1);
	//                updateRoomInfos(mainForm);
	//                room.reloadGfx();
	//                DrawRoom();
	//                Refresh();
	//                mainForm.redoButton.Enabled = true;
	//                mainForm.redoToolStripMenuItem.Enabled = true;
	//            }
	//            else
	//            {
	//                mainForm.undoButton.Enabled = false;
	//                mainForm.undoToolStripMenuItem.Enabled = false;
	//            }
	//
	//            //selection_resize = false;
	//            //room.selectedObject.Clear();
	//        }
	//        */
	//
	//		/*
	//        public void Redo()
	//        {
	//            if (DungeonsData.redoRoom[room.index].Count > 0)
	//            {
	//                DungeonsData.undoRoom[room.index].Add((Room)room.Clone());
	//                room = DungeonsData.redoRoom[room.index][(DungeonsData.redoRoom[room.index].Count - 1)];
	//                DungeonsData.redoRoom[room.index].RemoveAt(DungeonsData.redoRoom[room.index].Count - 1);
	//                updateRoomInfos(mainForm);
	//                room.reloadGfx();
	//                DrawRoom();
	//                Refresh();
	//                mainForm.undoButton.Enabled = true;
	//                mainForm.undoToolStripMenuItem.Enabled = true;
	//            }
	//            else
	//            {
	//                mainForm.redoButton.Enabled = false;
	//                mainForm.redoToolStripMenuItem.Enabled = false;
	//            }
	//        }
	//        */
	//
	//		public override void Paste()
	//		{
	//			if (!mouse_down)
	//			{
	//				List<SaveObject> data = null;
	//				try
	//				{
	//					data = (List<SaveObject>) Clipboard.GetData(Constants.ObjectZClipboardData);
	//				}
	//				catch (Exception) {}
	//
	//				if (data != null)
	//				{
	//					if (data.Count > 0)
	//					{
	//						int most_x = 512;
	//						int most_y = 512;
	//
	//						foreach (SaveObject o in data)
	//						{
	//							if (data.Count > 0)
	//							{
	//								if (o.x < most_x)
	//								{
	//									most_x = o.x;
	//								}
	//								if (o.y < most_y)
	//								{
	//									most_y = o.y;
	//								}
	//							}
	//							else
	//							{
	//								most_x = 0;
	//								most_y = 0;
	//							}
	//						}
	//
	//						room.selectedObject.Clear();
	//
	//						foreach (SaveObject o in data)
	//						{
	//							if (o.type == typeof(Sprite))
	//							{
	//								ZS.CurrentUWMode = DungeonEditMode.Sprites;
	//								Sprite spr = new Sprite(room, o.id, (byte) (o.x - most_x), (byte) (o.y - most_y), o.subtype, o.layer);
	//								room.sprites.Add(spr);
	//								room.selectedObject.Add(spr);
	//							}
	//							else if (o.type == typeof(Room_Object))
	//							{
	//								if ((o.options & ObjectOption.Door) == ObjectOption.Door)
	//								{
	//									ZS.CurrentUWMode = DungeonEditMode.Doors;
	//									object_door ro = new object_door(o.tid, o.x, o.y, 0, o.layer, ZS);
	//									ro.setRoom(room);
	//									ro.options = o.options;
	//									room.tilesObjects.Add(ro);
	//									room.selectedObject.Add(ro);
	//								}
	//								else
	//								{
	//									Room_Object ro = room.addObject(o.tid, (byte) (o.x - most_x), (byte) (o.y - most_y), o.size, o.layer);
	//
	//									if (ro != null)
	//									{
	//
	//										switch (ZS.CurrentUWMode)
	//										{
	//											case DungeonEditMode.LayerAll:
	//												// TODO???
	//												break;
	//
	//											case DungeonEditMode.Layer1:
	//											case DungeonEditMode.Layer2:
	//											case DungeonEditMode.Layer3:
	//												ro.layer = (byte) ZS.CurrentUWMode;
	//												break;
	//
	//											default:
	//												ZS.CurrentUWMode = DungeonEditMode.Layer1;
	//												break;
	//										}
	//
	//										ro.setRoom(room);
	//										ro.options = o.options;
	//										room.tilesObjects.Add(ro);
	//										room.selectedObject.Add(ro);
	//									}
	//								}
	//							}
	//							else if (o.type == typeof(PotItem))
	//							{
	//								ZS.CurrentUWMode = DungeonEditMode.Secrets;
	//								PotItem item = new PotItem((byte) o.tid, (byte) (o.x - most_x), (byte) (o.y - most_y), o.layer == 1, ZS);
	//								room.pot_items.Add(item);
	//								room.selectedObject.Add(item);
	//							}
	//						}
	//
	//						dragx = 0;
	//						dragy = 0;
	//						mouse_down = true;
	//					}
	//
	//					DrawRoom();
	//					Refresh();
	//				}
	//			}
	//		}
	//
	//		public override void Copy()
	//		{
	//			Clipboard.Clear();
	//			List<SaveObject> odata = new List<SaveObject>();
	//
	//			foreach (var o in room.selectedObject)
	//			{
	//				if (o is Sprite objS)
	//				{
	//					odata.Add(new SaveObject(objS));
	//					mouse_down = false;
	//				}
	//				else if (o is PotItem objP)
	//				{
	//					odata.Add(new SaveObject(objP));
	//					mouse_down = false;
	//				}
	//				else if (o is Room_Object objR)
	//				{
	//					odata.Add(new SaveObject(objR));
	//					mouse_down = false;
	//				}
	//			}
	//
	//			Clipboard.SetData(Constants.ObjectZClipboardData, odata);
	//		}
	//
	//		// TODO copy
	//		public override void loadLayout()
	//		{
	//			string f = Interaction.InputBox("Name of the layout to load", "Name?", "Layout00");
	//			BinaryReader br = new BinaryReader(new FileStream("Layout\\" + f, FileMode.Open, FileAccess.Read));
	//
	//			List<SaveObject> data = new List<SaveObject>();
	//
	//			while (br.BaseStream.Position != br.BaseStream.Length)
	//			{
	//				data.Add(new SaveObject(br, typeof(Room_Object)));
	//			}
	//
	//			if (data.Count > 0)
	//			{
	//				int most_x = 512;
	//				int most_y = 512;
	//				foreach (SaveObject o in data)
	//				{
	//					if (data.Count > 0)
	//					{
	//						if (o.x < most_x)
	//						{
	//							most_x = o.x;
	//						}
	//						if (o.y < most_y)
	//						{
	//							most_y = o.y;
	//						}
	//					}
	//					else
	//					{
	//						most_x = 0;
	//						most_y = 0;
	//					}
	//				}
	//				room.selectedObject.Clear();
	//
	//				foreach (SaveObject o in data)
	//				{
	//					if (o.type == typeof(Sprite))
	//					{
	//						Sprite spr = new Sprite(room, o.id, (byte) (o.x - most_x), (byte) (o.y - most_y), o.subtype, o.layer);
	//						room.sprites.Add(spr);
	//						room.selectedObject.Add(spr);
	//					}
	//					else if (o.type == typeof(Room_Object))
	//					{
	//						Room_Object ro = room.addObject(o.tid, (byte) (o.x - most_x), (byte) (o.y - most_y), o.size, o.layer);
	//						if (ro != null)
	//						{
	//							ro.setRoom(room);
	//							ro.options = o.options;
	//							room.tilesObjects.Add(ro);
	//							room.selectedObject.Add(ro);
	//						}
	//					}
	//				}
	//
	//				dragx = 0;
	//				dragy = 0;
	//				mouse_down = true;
	//			}
	//		}
	//
	//	}
}
