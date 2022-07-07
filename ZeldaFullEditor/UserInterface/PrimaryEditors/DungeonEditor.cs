﻿namespace ZeldaFullEditor.UserInterface.PrimaryEditors;

public partial class DungeonEditor : UserControl
{
	private static readonly Bitmap xTabButton = new(Resources.xbutton);

	private bool propertiesChangedFromForm;

	private readonly List<Room> opened_rooms = new();
	private readonly List<ushort> selectedMapPng = new();
	public UnderworldEntrance selectedEntrance = null;

	private readonly List<RoomObjectPreview> listoftilesobjects = new();
	private readonly List<SpritePreview> listofspritesobjects = new();

	int tpHotTracked = -1;
	int tpHotTrackedToClose = -1;
	int tpHotTrackedToCloseLast = -2;
	int lasttpHotTracked = -2;

	public ObjectViewer<RoomObjectPreview> objectViewer1;
	public ObjectViewer<SpritePreview> spritesView1;
	private VramViewer vramViewer;
	private CGRamViewer cgramViewer;

	public DungeonEditor()
	{
		InitializeComponent();

		vramViewer = new VramViewer();
		cgramViewer = new CGRamViewer();

		roomPropertyLayerCoupling.DataSource = LayerCouplingType.ListOf;
		roomProperty_collision.DataSource = LayerCollisionType.ListOf;
		roomProperty_effect.DataSource = LayerEffectType.ListOf;
		roomProperty_tag1.DataSource = RoomTagType.ListOf;
		roomProperty_tag2.DataSource = RoomTagType.ListOf;
		EntranceMusicBox.DataSource = MusicName.ListOfUnderworldMusics;

		mapPicturebox.Image = new Bitmap(256, 304);
		thumbnailBox.Size = new Size(256, 256);

		DoorTypeComboBox.DataSource = DungeonDoorType.ListOf;
		tileTypeCombobox.DataSource = TileTypeName.ListOfVanillaNames;
		EntranceProperties_FloorSel.DataSource = FloorNumber.ListOf;
		selecteditemobjectCombobox.DataSource = SecretsName.ListOfVanillaNames;
	}

	public void OnProjectLoad()
	{
		initEntrancesList();

		UnderWorldSceneHolder.Controls.Clear();
		UnderWorldSceneHolder.Controls.Add(ZScreamer.ActiveUWScene);
		addRoomTab(0x0104);

		//tabControl2_SelectedIndexChanged(tabControl2.TabPages[0], new EventArgs());



		// Initialize the map draw

		initObjectsList();

		ZScreamer.ActiveUWScene.Refresh();
	}

	private void initEntrancesList()
	{
		// Entrances
		for (int i = 0; i < 0x07; i++)
		{
			ZScreamer.ActiveScreamer.starting_entrances[i] = new UnderworldEntrance(ZScreamer.ActiveScreamer, (byte) i, true);
			string tname = $"[{i:X2}] - {RoomName.ListOfVanillaNames[ZScreamer.ActiveScreamer.starting_entrances[i].RoomID]:X3}";

			entrancetreeView.Nodes[1].Nodes.Add(
				new TreeNode(tname)
				{
					Tag = i,
				}
			);
		}

		for (int i = 0; i < Constants.NumberOfEntrances; i++)
		{
			ZScreamer.ActiveScreamer.entrances[i] = new(ZScreamer.ActiveScreamer, (byte) i, false);
			string tname = $"[{i:X2}] - {RoomName.ListOfVanillaNames[ZScreamer.ActiveScreamer.entrances[i].RoomID]:X3}";

			entrancetreeView.Nodes[0].Nodes.Add(
				new TreeNode(tname)
				{
					Tag = i,
				}
			);
		}

		entrancetreeView.SelectedNode = entrancetreeView.Nodes[0].Nodes[0];
		selectedEntrance = ZScreamer.ActiveScreamer.entrances[0];
	}

	public void SaveRooms()
	{
		foreach (TabPage tp in RoomTabControl.TabPages)
		{
			tp.Text = tp.Text.Trim('*');
		}

		foreach (Room r in opened_rooms)
		{
			r.FlushChanges();
		}
	}

	public void UpdateFormForSelectedObject(IHaveInfo o)
	{
		switch (o)
		{
			case DungeonSprite s:
				spritesubtypeUpDown.Value = s.Subtype;
				spriteoverlordCheckbox.Checked = s.IsCurrentlyOverlord;
				KeyDropComboBox.SelectedIndex = s.KeyDrop;
				break;

			case DungeonDoor d:
				throw new NotImplementedException();

			case DungeonSecret x:
				throw new NotImplementedException();
		}

		ZGUI.UpdateFormForSelectedObject(o);
	}

	public void UpdateFormForManySelectedObjects<T>(IEnumerable<T> l) where T : IHaveInfo
	{
		ZGUI.UpdateFormForManySelectedObjects(l);
	}

	public void UpdateUIForRoom(Room room, bool prevent = true)
	{
		if (room == null)
		{
			return;
		}

		propertiesChangedFromForm = prevent;

		roomPropertyLayerCoupling.SelectedItem = room.LayerCoupling;
		roomProperty_tag1.SelectedItem = room.Tag1;
		roomProperty_tag2.SelectedItem = room.Tag2;
		roomProperty_effect.SelectedItem = room.LayerEffect;
		roomProperty_collision.SelectedItem = room.LayerCollision;
		RoomProperty_IsDark.Checked = room.IsDark;

		roomProperty_pit.Checked = room.HasDamagingPits;
		roomProperty_sortsprite.Checked = room.MultiLayerOAM;

		RoomProperty_Blockset.HexValue = room.BackgroundTileset;
		RoomProperty_SpriteSet.HexValue = room.SpriteTileset;
		RoomProperty_Floor1.HexValue = room.Floor1Graphics;
		RoomProperty_Floor2.HexValue = room.Floor2Graphics;
		RoomProperty_MessageID.HexValue = room.MessageID;
		RoomProperty_Layout.HexValue = room.Layout;
		RoomProperty_Palette.HexValue = room.Palette;

		RoomProperty_DestinationPit.HexValue = room.Pits.Target;
		RoomProperty_DestinationStair1.HexValue = room.Stair1.Target;
		RoomProperty_DestinationStair2.HexValue = room.Stair2.Target;
		RoomProperty_DestinationStair3.HexValue = room.Stair3.Target;
		RoomProperty_DestinationStair4.HexValue = room.Stair4.Target;

		bg2checkbox1.Checked = room.Pits.TargetLayer == 2;
		bg2checkbox2.Checked = room.Stair1.TargetLayer == 2;
		bg2checkbox3.Checked = room.Stair2.TargetLayer == 2;
		bg2checkbox4.Checked = room.Stair3.TargetLayer == 2;
		bg2checkbox5.Checked = room.Stair4.TargetLayer == 2;

		propertiesChangedFromForm = false;
	}

	public void checkAnyChanges()
	{
		foreach (TabPage p in RoomTabControl.TabPages)
		{
			if ((p.Tag as Room).HasUnsavedChanges)
			{
				ZGUI.anychange = true;
				if (!p.Text.Contains('*'))
				{
					p.Text += "*";
				}
			}
		}
	}

	private void UpdateUnderworldMode_Collision(object sender, EventArgs e)
	{
		ZScreamer.ActiveScreamer.CurrentUWMode = DungeonEditMode.CollisionMap;

		//ZGUI.xScreenToolStripMenuItem.Checked = true;
		ZGUI.RefreshOnZoom();
		tileTypeCombobox.SelectedIndex = 0;
		collisionMapPanel.Visible = true;
	}

	public void UpdateUnderworldMode(DungeonEditMode m)
	{
		collisionMapPanel.Visible = m == DungeonEditMode.CollisionMap;

		foreach (Room room in opened_rooms)
		{
			room.ClearSelectedList(); // TODO necessary?
		}
	}

	public void UpdateRoomInfo()
	{
		if (!propertiesChangedFromForm && ZScreamer.ActiveUWScene.Room != null)
		{
			var room = ZScreamer.ActiveUWScene.Room;

			room.LayerEffect = (LayerEffectType) roomProperty_effect.SelectedItem;
			room.Tag1 = (RoomTagType) roomProperty_tag1.SelectedItem;
			room.Tag2 = (RoomTagType) roomProperty_tag2.SelectedItem;
			room.LayerCoupling = (LayerCouplingType) roomPropertyLayerCoupling.SelectedItem;
			room.LayerCollision = (LayerCollisionType) roomProperty_collision.SelectedItem;

			room.BackgroundTileset = (byte) RoomProperty_Blockset.HexValue;
			room.Floor1Graphics = (byte) RoomProperty_Floor1.HexValue;
			room.Floor2Graphics = (byte) RoomProperty_Floor2.HexValue;
			room.Layout = (byte) RoomProperty_Layout.HexValue;

			room.MessageID = (ushort) RoomProperty_MessageID.HexValue;
			room.Palette = (byte) RoomProperty_Palette.HexValue;

			room.Pits.Target = (byte) RoomProperty_DestinationPit.HexValue;
			room.Stair1.Target = (byte) RoomProperty_DestinationStair1.HexValue;
			room.Stair2.Target = (byte) RoomProperty_DestinationStair2.HexValue;
			room.Stair3.Target = (byte) RoomProperty_DestinationStair3.HexValue;
			room.Stair4.Target = (byte) RoomProperty_DestinationStair4.HexValue;

			room.Pits.TargetLayer = (byte) (bg2checkbox1.Checked ? 2 : 0);
			room.Stair1.TargetLayer = (byte) (bg2checkbox2.Checked ? 2 : 0);
			room.Stair2.TargetLayer = (byte) (bg2checkbox3.Checked ? 2 : 0);
			room.Stair3.TargetLayer = (byte) (bg2checkbox4.Checked ? 2 : 0);
			room.Stair4.TargetLayer = (byte) (bg2checkbox5.Checked ? 2 : 0);

			room.HasDamagingPits = roomProperty_pit.Checked;
			room.MultiLayerOAM = roomProperty_sortsprite.Checked;
			room.IsDark = RoomProperty_IsDark.Checked;

			room.SpriteTileset = (byte) RoomProperty_SpriteSet.HexValue;

			/*
                undoRoom[activeScene.room.index].Add((Room)activeScene.room.Clone());
                redoRoom[activeScene.room.index].Clear();
                */

			ZScreamer.ActiveUWScene.HardRefresh();
			ZScreamer.ActiveUWScene.Room.HasUnsavedChanges = true;
			checkAnyChanges();
		}
	}

	public void updateEntranceInfos()
	{
		if (!propertiesChangedFromForm && selectedEntrance != null)
		{
			selectedEntrance.Blockset = (byte) EntranceProperties_Blockset.HexValue;
			selectedEntrance.RoomID = (ushort) EntranceProperties_RoomID.HexValue;

			if (EntranceProperties_FloorSel.SelectedIndex >= 0)
			{
				selectedEntrance.Floor = (EntranceProperties_FloorSel.SelectedItem as FloorNumber).Value;
			}

			selectedEntrance.Dungeon = (byte) EntranceProperties_DungeonID.HexValue;
			selectedEntrance.Music = (MusicName) EntranceMusicBox.SelectedItem;

			selectedEntrance.AssociatedEntrance = (byte) EntranceProperties_Entrance.HexValue;

			selectedEntrance.OverworldEntranceLocation = (byte) EntranceProperties_Entrance.HexValue;

			selectedEntrance.Ladderbg = (byte) (entranceProperty_bg.Checked ? 0x10 : 0x00);

			selectedEntrance.cameraBoundaryQN = (byte) EntranceProperty_BoundaryQN.HexValue;
			selectedEntrance.cameraBoundaryFN = (byte) EntranceProperty_BoundaryFN.HexValue;
			selectedEntrance.cameraBoundaryQS = (byte) EntranceProperty_BoundaryQS.HexValue;
			selectedEntrance.cameraBoundaryFS = (byte) EntranceProperty_BoundaryFS.HexValue;
			selectedEntrance.cameraBoundaryQW = (byte) EntranceProperty_BoundaryQW.HexValue;
			selectedEntrance.cameraBoundaryFW = (byte) EntranceProperty_BoundaryFW.HexValue;
			selectedEntrance.cameraBoundaryQE = (byte) EntranceProperty_BoundaryQE.HexValue;
			selectedEntrance.cameraBoundaryFE = (byte) EntranceProperty_BoundaryFE.HexValue;

			selectedEntrance.XPosition = (ushort) EntranceProperties_PlayerX.HexValue;
			selectedEntrance.YPosition = (ushort) EntranceProperties_PlayerY.HexValue;
			selectedEntrance.CameraX = (ushort) EntranceProperties_CameraTriggerX.HexValue;
			selectedEntrance.CameraY = (ushort) EntranceProperties_CameraTriggerY.HexValue;
			selectedEntrance.CameraTriggerX = (ushort) EntranceProperties_CameraTriggerX.HexValue;
			selectedEntrance.CameraTriggerY = (ushort) EntranceProperties_CameraTriggerY.HexValue;


			if (int.TryParse(doorxTextbox.Text, NumberStyles.HexNumber, null, out int r) &&
				int.TryParse(dooryTextbox.Text, NumberStyles.HexNumber, null, out int rr))
			{
				selectedEntrance.OverworldEntranceLocation = (ushort) (((rr << 6) + (r & 0x3F)) << 1);
			}
			else
			{
				selectedEntrance.OverworldEntranceLocation = 0;
			}

			if (entranceProperty_quadbr.Checked)
			{
				selectedEntrance.Scrollquadrant = 0x12;
			}
			else if (entranceProperty_quadbl.Checked)
			{
				selectedEntrance.Scrollquadrant = 0x02;
			}
			else if (entranceProperty_quadtl.Checked)
			{
				selectedEntrance.Scrollquadrant = 0x00;
			}
			else if (entranceProperty_quadtr.Checked)
			{
				selectedEntrance.Scrollquadrant = 0x10;
			}

			//if (entranceProperty_quadbl)

			selectedEntrance.Scrolling = IntFunctions.SetFieldBits(
				bit1: entranceProperty_vscroll.Checked,
				bit5: entranceProperty_hscroll.Checked
				);

			ZScreamer.ActiveUWScene.HardRefresh();
			ZScreamer.ActiveUWScene.Room.HasUnsavedChanges = true;
		}
	}

	public void closeRoom(int index)
	{
		for (int j = 0; j < opened_rooms.Count; j++)
		{
			var room = opened_rooms[j];
			if (room.RoomID == index)
			{
				room.ClearSelectedList();
				opened_rooms.RemoveAt(j);
				return;
			}
		}
	}


	public void entrancetreeView_AfterSelect(object sender, TreeViewEventArgs e)
	{
		propertiesChangedFromForm = true;
		var en = selectedEntrance;
		if (e?.Node?.Tag is not null)
		{
			// TODO gross
			en = ZScreamer.ActiveScreamer.entrances[(int) e.Node.Tag];
			if (e.Node.Parent?.Name == "StartingEntranceNode")
			{
				en = ZScreamer.ActiveScreamer.starting_entrances[(int) e.Node.Tag];
			}
		}

		//propertyGrid2.SelectedObject = entrances[(int)e.Node.Tag];
		entranceProperty_bg.Checked = false;

		EntranceProperties_RoomID.HexValue = en.RoomID;
		EntranceProperties_DungeonID.HexValue = en.Dungeon;
		EntranceProperties_Blockset.HexValue = en.Blockset;
		EntranceMusicBox.SelectedItem = en.Music;
		EntranceProperties_Entrance.HexValue = en.AssociatedEntrance;

		EntranceProperties_Entrance.Enabled = en.IsSpawnPoint;

		EntranceProperties_PlayerX.HexValue = en.XPosition;
		EntranceProperties_PlayerY.HexValue = en.YPosition;
		EntranceProperties_CameraX.HexValue = en.CameraX;
		EntranceProperties_CameraY.HexValue = en.CameraY;
		EntranceProperties_CameraTriggerX.HexValue = en.CameraTriggerX;
		EntranceProperties_CameraTriggerY.HexValue = en.CameraTriggerY;


		EntranceProperties_FloorSel.SelectedItem = FloorNumber.FindFloor(en.Floor);

		EntranceProperties_Entrance.HexValue = en.OverworldEntranceLocation;

		if (en.Ladderbg.BitIsOn(0x10))
		{
			entranceProperty_bg.Checked = true;
		}

		if (ZScreamer.ActiveUWScene.Room is not null)
		{
			selectedEntrance = en;

			ZScreamer.ActiveUWScene.HardRefresh();
		}

		entranceProperty_vscroll.Checked = en.Scrolling.BitIsOn(0x02);
		entranceProperty_hscroll.Checked = en.Scrolling.BitIsOn(0x20);
		entranceProperty_quadbr.Checked = false;
		entranceProperty_quadbl.Checked = false;
		entranceProperty_quadtl.Checked = false;
		entranceProperty_quadtr.Checked = false;

		EntranceProperty_BoundaryQN.HexValue = en.cameraBoundaryQN;
		EntranceProperty_BoundaryFN.HexValue = en.cameraBoundaryFN;
		EntranceProperty_BoundaryQS.HexValue = en.cameraBoundaryQS;
		EntranceProperty_BoundaryFS.HexValue = en.cameraBoundaryFS;
		EntranceProperty_BoundaryQW.HexValue = en.cameraBoundaryQW;
		EntranceProperty_BoundaryFW.HexValue = en.cameraBoundaryFW;
		EntranceProperty_BoundaryQE.HexValue = en.cameraBoundaryQE;
		EntranceProperty_BoundaryFE.HexValue = en.cameraBoundaryFE;

		int p = (en.OverworldEntranceLocation & 0x7FFF) >> 1;
		doorxTextbox.Text = (p % 64).ToString("X2");
		dooryTextbox.Text = (p >> 6).ToString("X2");

		if (en.Scrollquadrant == 0x12) // Bottom right
		{
			entranceProperty_quadbr.Checked = true;
		}
		else if (en.Scrollquadrant == 0x02) // Bottom left
		{
			entranceProperty_quadbl.Checked = true;
		}
		else if (en.Scrollquadrant == 0x00) // Top left
		{
			entranceProperty_quadtl.Checked = true;
		}
		else if (en.Scrollquadrant == 0x10) // Top right
		{
			entranceProperty_quadtr.Checked = true;
		}

		propertiesChangedFromForm = false;
	}

	public void SelectAllRooms()
	{
		for (ushort i = 0; i < Constants.NumberOfRooms; i++)
		{
			selectedMapPng.Add(i);
		}
	}

	public void DeselectAllRooms()
	{
		selectedMapPng.Clear();
	}

	public void ExportMaps()
	{
		// Check what's the higher map and the left most, we don't care about right bottom

		//(map / 16) = Y position
		//map - (Y*16) = X position
		int lowerX = 16; // What we need to remove from the image to the left
		int lowerY = 16; // What we need to remove from the image to the right
		int higherX = 0; // What we need to remove from the image to the left
		int higherY = 0; // What we need to remove from the image to the right

		if (selectedMapPng.Count > 0)
		{
			var b = new Bitmap(8192, 10752);

			using (var gb = Graphics.FromImage(b))
			{
				foreach (ushort s in selectedMapPng)
				{
					if (s < ZScreamer.ActiveScreamer.all_rooms.Length && ZScreamer.ActiveScreamer.all_rooms[s] != null)
					{
						int cy = s / 16;
						int cx = s & 0xF;
						if (cx < lowerX) { lowerX = cx; }
						if (cy < lowerY) { lowerY = cy; }
						if (cx > higherX) { higherX = cx; }
						if (cy > higherY) { higherY = cy; }
						RoomPreviewArtist.CurrentRoom = ZScreamer.ActiveScreamer.all_rooms[s];

						gb.DrawImage(RoomPreviewArtist.FinalOutput, new Point(cx * 512, cy * 512));
					}
				}
			}

			int image_size_x = ((higherX - lowerX) * 512) + 512;
			int image_size_y = ((higherY - lowerY) * 512) + 512;
			int image_start_x = lowerX * 512;
			int image_start_y = lowerY * 512;
			Bitmap nb = new Bitmap(image_size_x, image_size_y);

			using (Graphics gb = Graphics.FromImage(nb))
			{
				gb.DrawImage(b, 0, 0, new Rectangle(image_start_x, image_start_y, image_size_x, image_size_y), GraphicsUnit.Pixel);
			}

			// TODO better names so we can have more than 1 map
			nb.Save("MapTest.png");
			b.Dispose();
			nb.Dispose();
		}
		else
		{
			var b = new Bitmap(512, 512);
			ZScreamer.ActiveUWScene.DrawToBitmap(b, Constants.ScreenSizedRectangle);
			b.Save("singlemap.png");
		}
	}

	private void searchTextbox_TextChanged(object sender, EventArgs e)
	{
		objectViewer1.SearchedText = searchTextbox.Text;
	}

	private void searchspriteTextbox_TextChanged(object sender, EventArgs e)
	{
		spritesView1.SearchedText = searchspriteTextbox.Text;
	}

	private void CloseTab(int i)
	{
		var room = (Room) RoomTabControl.TabPages[i].Tag;

		bool close;

		if (room.HasUnsavedChanges)
		{
			switch (UIText.WarnAboutSaving(UIText.RoomWarning))
			{
				case DialogResult.Yes:
					room.FlushChanges();
					close = true;
					break;

				case DialogResult.No:
					room.ClearChanges();
					close = true;
					break;

				default:
				case DialogResult.Cancel:
					close = false;
					break;
			}
		}
		else
		{
			close = true;
		}

		if (close)
		{
			closeRoom(room.RoomID);
			RoomTabControl.TabPages.RemoveAt(i);
			if (RoomTabControl.TabPages.Count == 0)
			{
				RoomTabControl.Visible = false;
				ZScreamer.ActiveUWScene.Clear();
				ZScreamer.ActiveUWScene.Room = null;
				ZScreamer.ActiveUWScene.Refresh();
			}
		}

		RoomTabControl.Refresh();
	}

	private void tabControl2_MouseClick(object sender, MouseEventArgs e)
	{
		//loadRoomList(0);
	}

	private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (RoomTabControl.TabPages.Count > 0)
		{
			ZScreamer.ActiveUWScene.Room = RoomTabControl.TabPages[RoomTabControl.SelectedIndex].Tag as Room;

			// TODO
			//if (ZScreamer.ActiveScreamer.undoRoom[ZScreamer.ActiveUWScene.Room.RoomID].Count > 0)
			//{
			//	undoButton.Enabled = true;
			//	undoToolStripMenuItem.Enabled = true;
			//}
			//else
			//{
			//	// TODO is this wrong?
			//	redoButton.Enabled = false;
			//	redoToolStripMenuItem.Enabled = false;
			//}
			//
			//if (ZScreamer.ActiveScreamer.redoRoom[ZScreamer.ActiveUWScene.Room.RoomID].Count > 0)
			//{
			//	redoButton.Enabled = true;
			//	redoToolStripMenuItem.Enabled = true;
			//}
			//else
			//{
			//	redoButton.Enabled = false;
			//	redoToolStripMenuItem.Enabled = false;
			//}

			ZScreamer.ActiveUWScene.Refresh();
		}
		else
		{
			ZScreamer.ActiveUWScene.Clear();
		}

		mapPicturebox.Refresh();
	}




	public void initObjectsList()
	{
		ObjectListPanel.Controls.Clear();
		SpriteListPanel.Controls.Clear();

		foreach (var o in RoomObjectType.ListOf)
		{
			RoomObjectPreview p = new(o, ZScreamer.ActiveScreamer.TileLister[o.FullID]);
			listoftilesobjects.Add(p);
			p.Draw(UXPreviewArtist);
		}

		foreach (var o in SpriteType.ListOf)
		{
			listofspritesobjects.Add(new(o));
		}

		foreach (var o in OverlordType.ListOf)
		{
			listofspritesobjects.Add(new(o));
		}

		objectViewer1 = new(listoftilesobjects)
		{
			Dock = DockStyle.Fill,
		};

		spritesView1 = new(listofspritesobjects)
		{
			Dock = DockStyle.Fill,
		};

		UXPreviewArtist.RefreshPalettesFrom(ZScreamer.ActiveUWScene.Room.CGPalette);
		UXPreviewArtist.RedrawAllPreviews();

		ObjectListPanel.Controls.Add(objectViewer1);
		SpriteListPanel.Controls.Add(spritesView1);
	}

	private void EntrancePropertyChanged(object sender, EventArgs e)
	{
		updateEntranceInfos();
	}

	private void litCheckbox_CheckedChanged(object sender, EventArgs e)
	{
		if (!ZScreamer.ActiveUWScene.IsUpdating && ZScreamer.ActiveUWScene.Room?.OnlySelectedObject is LightableTorch torch)
		{
			torch.Lit = litCheckbox.Checked;
		}
	}

	private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
	{
		if (KeyDropComboBox.SelectedIndex > 0 && ZScreamer.ActiveUWScene.Room?.OnlySelectedObject is DungeonSprite s)
		{
			foreach (var spr in ZScreamer.ActiveUWScene.Room.SpritesList)
			{
				spr.KeyDrop = 0;
			}
			s.KeyDrop = (byte) KeyDropComboBox.SelectedIndex;
			ZScreamer.ActiveUWScene.Refresh();
		}
	}

	private void spritesubtypeUpDown_ValueChanged(object sender, EventArgs e)
	{
		if (!ZScreamer.ActiveUWScene.IsUpdating && ZScreamer.ActiveUWScene.Room?.OnlySelectedObject is DungeonSprite spr)
		{
			spr.Subtype = (byte) spritesubtypeUpDown.Value;
		}
	}

	private void gotoRoomToolStripMenuItem_Click(object sender, EventArgs e)
	{
		GotoRoom gotoRoom = new GotoRoom();
		if (gotoRoom.ShowDialog() == DialogResult.OK)
		{
			addRoomTab((ushort) gotoRoom.SelectedRoom);
		}
	}

	private void mapPicturebox_Paint(object sender, PaintEventArgs e)
	{
		if (!ZGUI.projectLoaded)
		{
			return;
		}

		int xd = 0;
		int yd = 0;
		int yoff = 0;
		e.Graphics.Clear(SystemColors.ScrollBar);


		List<Room> opened = new();

		foreach (TabPage tp in RoomTabControl.TabPages)
		{
			opened.Add(tp.Tag as Room);
		}

		object selroom = RoomTabControl?.SelectedTab?.Tag;

		for (int i = 0; i < Constants.NumberOfRooms; i++)
		{
			var room = ZScreamer.ActiveScreamer.all_rooms[i];

			int alpha = opened.Contains(room) ? 255 : (HoveredRoom == i) ? 210 : 140;

			e.Graphics.DrawFilledRectangleWithOutline(xd, yd + yoff, 16, 16,
				Pens.LightSlateGray,
				new SolidBrush(Color.FromArgb(alpha, room.IsEmpty ? Color.Black : room.RoomColor))
			);

			Pen outline = (selroom == room, opened.Contains(room), selectedMapPng.Contains((ushort) i)) switch
			{
				(true, _, _) => UIColors.SelectedRoomOutline, // selected tab
				(false, true, false) => UIColors.OpenedRoomOutline, // opened tab
				(false, true, true) => UIColors.OpenedExportedRoomOutline, // opened and exported
				(false, false, true) => UIColors.ExportedRoomOutline, // opened and not exported

				_ => null
			};

			if (outline is not null)
			{
				e.Graphics.DrawRectangle(outline, xd + 1, yd + yoff + 1, 14, 14);
			}





			xd += 16;
			if (xd == 16 * 16)
			{
				yd += 16;
				yoff = (yd > 15 * 16) ? 8 : 0;
				xd = 0;
			}
		}

		//xd = 0;
		//yd = 0;
		//yoff = 0;
		//for (int i = 0; i < Constants.NumberOfRooms; i++)
		//{
		//	var room = ZScreamer.ActiveScreamer.all_rooms[i];
		//
		//	Pen outline = (selroom == room, opened.Contains(room), selectedMapPng.Contains((ushort) i)) switch
		//	{
		//		(true, _, _) => UIColors.SelectedRoomOutline, // selected tab
		//		(false, true, false) => UIColors.OpenedRoomOutline, // opened tab
		//		(false, true, true) => UIColors.OpenedExportedRoomOutline, // opened and exported
		//		(false, false, true) => UIColors.ExportedRoomOutline, // opened and not exported
		//
		//		_ => null
		//	};
		//
		//	if (outline is not null)
		//	{
		//		e.Graphics.DrawRectangle(outline, xd + 1, yd + yoff + 1, 14, 14);
		//	}
		//
		//	xd += 16;
		//	if (xd == 16 * 16)
		//	{
		//		yd += 16;
		//		yoff = (yd > 15 * 16) ? 8 : 0;
		//		xd = 0;
		//	}
		//}
	}

	private void DrawOnTab(object sender, DrawItemEventArgs e)
	{
		Graphics g = e.Graphics;
		Font font = (sender as TabControl).Font;

		Brush brr = Brushes.Black;

		if (tpHotTracked == e.Index || e.State == DrawItemState.Selected)
		{
			int off = (tpHotTrackedToClose == e.Index) ? 16 : 0;
			g.DrawImage(xTabButton, new(e.Bounds.X + 30, e.Bounds.Y, 16, 16), off, 0, 16, 16, GraphicsUnit.Pixel);
			brr = Brushes.Blue;
		}
		g.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.ControlLight)), e.Bounds);
		g.DrawString(RoomTabControl.TabPages[e.Index].Text, font, brr, new Rectangle(e.Bounds.X, e.Bounds.Y + 2, 64, 24));
	}

	private void tabControl2_MouseMove(object sender, MouseEventArgs e)
	{
		tpHotTrackedToClose = -1;
		for (int i = 0; i < RoomTabControl.TabPages.Count; i++)
		{
			var itemRect = RoomTabControl.GetTabRect(i);

			if (itemRect.Contains(e.Location))
			{
				var xRect = RoomTabControl.GetTabRect(i);
				xRect.X += 30;
				xRect.Width = 16;

				tpHotTracked = i;
				if (xRect.Contains(e.Location))
				{
					tpHotTrackedToClose = i;
				}

				//tabControl2.TabPages[i].Refresh();
			}
		}

		if (lasttpHotTracked != tpHotTracked || tpHotTrackedToCloseLast != tpHotTrackedToClose)
		{
			RoomTabControl.Refresh();
		}

		tpHotTrackedToCloseLast = tpHotTrackedToClose;
		lasttpHotTracked = tpHotTracked;
	}

	private void tabControl2_MouseLeave(object sender, EventArgs e)
	{
		tpHotTracked = -1;
		lasttpHotTracked = -2;
		tpHotTrackedToClose = -1;
		tpHotTrackedToCloseLast = -2;
		RoomTabControl.Refresh();
	}

	private void tabControl2_MouseEnter(object sender, EventArgs e)
	{
		tpHotTracked = -1;
		lasttpHotTracked = -2;
		tpHotTrackedToClose = -1;
		tpHotTrackedToCloseLast = -2;
		RoomTabControl.Refresh();
	}

	private void tabControl2_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Middle)
		{
			for (int i = 0; i < RoomTabControl.TabCount; i++)
			{
				if (RoomTabControl.GetTabRect(i).Contains(e.Location))
				{
					CloseTab(i);
				}
			}
		}
		else if (e.Button == MouseButtons.Left)
		{
			if (tpHotTrackedToClose != -1)
			{
				int ctab = tpHotTrackedToClose;
				if (tpHotTrackedToClose == RoomTabControl.SelectedIndex)
				{
					tpHotTrackedToClose = -1;
					RoomTabControl.SelectedIndex = 0;
				}

				CloseTab(ctab);
			}
		}
	}

	private void tabControl2_Deselecting(object sender, TabControlCancelEventArgs e)
	{
		if (tpHotTrackedToClose != -1)
		{
			e.Cancel = true;
		}
	}

	private int HoveredRoom = -1;

	private void mapPicturebox_MouseDown(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Right)
		{
			if (e.Y >= 256 && e.Y <= 264)
			{
				return;
			}

			thumbnailBox.Visible = true;
			
			if (HoveredRoom > 295)
			{
				return;
			}

			thumbnailBox.Refresh();
		}
	}

	private void thumbnailBox_Paint(object sender, PaintEventArgs e)
	{
		e.Graphics.Clear(Color.Black);

		RoomPreviewArtist.DrawSelfToImageSmall(e.Graphics, 0, 0);
		RoomPreviewArtist.DrawIDToImage(e.Graphics);

	}

	private void mapPicturebox_MouseUp(object sender, MouseEventArgs e)
	{
		thumbnailBox.Visible = false;
	}

	private void mapPicturebox_MouseMove(object sender, MouseEventArgs e)
	{
		if (maphoverCheckbox.Checked)
		{
			if (e.Y >= 256 && e.Y <= 264)
			{
				thumbnailBox.Visible = false;
				HoveredRoom = -1;
				return;
			}

			thumbnailBox.Visible = true;

			int yc = e.Y;
			if (e.Y > 256)
			{
				yc -= 8;
			}
			HoveredRoom = (e.X / 16) + (yc & ~0xF);

			if (HoveredRoom >= Constants.NumberOfRooms)
			{
				HoveredRoom = -1;
				thumbnailBox.Visible = false;
				return;
			}

			RoomPreviewArtist.CurrentRoom = ZScreamer.ActiveScreamer.all_rooms[HoveredRoom];
			mapPicturebox.Refresh();
			thumbnailBox.Refresh();
		}
	}


	private void RoomPropertyChanged(object sender, EventArgs e)
	{
		UpdateRoomInfo();
	}

	private void mapPicturebox_MouseLeave(object sender, EventArgs e)
	{
		thumbnailBox.Visible = false;
		HoveredRoom = -1;
	}

	private void objectViewer1_SelectedIndexChanged(object sender, EventArgs e)
	{
		ZScreamer.ActiveUWScene.ObjectToPlace = (IDungeonPlaceable) objectViewer1.CreateSelectedObject();
	}


	private void spritesView1_SelectedIndexChanged(object sender, EventArgs e)
	{
		ZScreamer.ActiveUWScene.ObjectToPlace = (IDungeonPlaceable) spritesView1.CreateSelectedObject();
	}

	private void selecteditemobjectCombobox_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (selecteditemobjectCombobox.SelectedIndex != -1 && ZScreamer.ActiveUWScene.Room?.OnlySelectedObject is DungeonSecret p)
		{
			p.SecretType = SecretItemType.GetTypeFromID((byte) (selecteditemobjectCombobox.SelectedItem as SecretsName).ID);
			ZScreamer.ActiveUWScene.Refresh();
		}
	}

	private void DoorTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		// Doors
		if (DoorTypeComboBox.SelectedIndex > 0 && ZScreamer.ActiveUWScene.Room?.OnlySelectedObject is DungeonDoor d)
		{
			var door = (DungeonDoorType) DoorTypeComboBox.SelectedItem;
			d.DoorTiles = ZScreamer.ActiveScreamer.TileLister.GetDoorTileSet(door.ID);
			d.DoorType = door;
			ZScreamer.ActiveUWScene.Room.HasUnsavedChanges = true;
			ZScreamer.ActiveUWScene.HardRefresh();
		}
	}


	public void addRoomTab(ushort roomId)
	{
		bool alreadyFound = false;
		foreach (Room room in opened_rooms)
		{
			if (room.RoomID == roomId)
			{
				alreadyFound = true;
				break;
			}
		}

		if (alreadyFound)
		{
			// Display message error room already opened
			//MessageBox.Show("That room is already opened !");
			foreach (TabPage tp in RoomTabControl.TabPages)
			{
				if ((tp.Tag as Room).RoomID == roomId)
				{
					RoomTabControl.SelectTab(tp);
					break;

					//tp.Select();
				}
			}

			return;
		}
		else
		{
			var r = ZScreamer.ActiveScreamer.all_rooms[roomId];

			/*
                if (DungeonsData.undoRoom[r.index].Count == 0)
                {
                    DungeonsData.undoRoom[r.index].Add((Room)r.Clone());
                    DungeonsData.redoRoom[r.index].Clear();
                    undoButton.Enabled = false;
                    undoToolStripMenuItem.Enabled = false;
                }
                else
                {
                    undoButton.Enabled = true;
                    undoToolStripMenuItem.Enabled = true;
                }
                */

			/*
                if (DungeonsData.redoRoom[r.index].Count > 0)
                {
                    redoButton.Enabled = true;
                    redoToolStripMenuItem.Enabled = true;
                }
                else
                {
                    redoButton.Enabled = false;
                    redoToolStripMenuItem.Enabled = false;
                }
                */

			//mapPropertyGrid.SelectedObject = r;

			opened_rooms.Add(r); // Add the double clicked room into rooms list     
			ZScreamer.ActiveUWScene.Room = r;

			//string tn = r.index.ToString("D3");
			//if (showRoomsInHexToolStripMenuItem.Checked)
			//{
			string tn = r.RoomID.ToString("X3");
			//}

			TabPage tp = new TabPage(tn)
			{
				Tag = r
			};
			RoomTabControl.TabPages.Add(tp);
			//objectsListbox.ClearSelected();
			RoomTabControl.SelectedTab = tp;

			//paletteViewer.update();
			ZScreamer.ActiveUWScene.HardRefresh();
		}

		if (RoomTabControl.TabPages.Count > 0)
		{
			RoomTabControl.Visible = true;
			ZScreamer.ActiveUWScene.HardRefresh();
		}

		cgramViewer.Refresh();
	}

	private void entrancetreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
	{
		if (e.Node.Tag != null)
		{
			var list = (e.Node.Parent == entrancetreeView.Nodes[0])
				? ZScreamer.ActiveScreamer.entrances
				: ZScreamer.ActiveScreamer.starting_entrances;
			addRoomTab(list[(int) e.Node.Tag].RoomID);
		}
	}

	private void mapPicturebox_MouseDoubleClick(object sender, MouseEventArgs e)
	{

		if (e.Y >= 256 && e.Y <= 264)
		{
			return;
		}

		int yc = e.Y;

		if (e.Y > 256)
		{
			yc -= 8;
		}

		int x = e.X / 16;
		int y = yc / 16;
		ushort roomId = (ushort) (x + (y * 16));

		if (ModifierKeys == Keys.Control)
		{
			// Check if map is already in
			ushort? alreadyIn = null;
			foreach (ushort s in selectedMapPng)
			{
				// If it was already in delete it
				if (s == roomId)
				{
					alreadyIn = s;
				}
			}

			if (alreadyIn != null)
			{
				selectedMapPng.Remove((ushort) alreadyIn);
			}
			else
			{
				selectedMapPng.Add(roomId);
			}

			//loadRoomList(roomId);
		}
		else
		{
			if (roomId < Constants.NumberOfRooms)
			{
				addRoomTab(roomId);
				//loadRoomList(roomId);
			}
		}

		mapPicturebox.Refresh();
	}
}
