namespace ZeldaFullEditor.UserInterface.UIControl.Scene;

public partial class SceneOW
{
	private IOverworldUWLink lastenex;

	public IOverworldUWLink SelectedEntranceExit { get; set; }

	public IOverworldUWLink LastSelectedEntranceExit
	{
		get => lastenex;
		set
		{
			if (lastenex == value) return;

			lastenex = value;
			switch (lastenex)
			{
				case OverworldEntrance en:
					ZGUI.OverworldEditor.SetSelectedEntrance(en);
					ZGUI.UpdateFormForSelectedObject(en);
					break;

				case OverworldExit ex:
					ZGUI.OverworldEditor.SetSelectedExit(ex);
					break;
			}

			
		}
	}

	public OverworldExit SelectedExit
	{
		get => SelectedEntranceExit as OverworldExit;
		set => SelectedEntranceExit = value;
	}

	public OverworldExit LastSelectedExit
	{
		get => LastSelectedEntranceExit as OverworldExit;
		set => LastSelectedEntranceExit = value;
	}

	public OverworldEntrance SelectedEntrance
	{
		get => SelectedEntranceExit as OverworldEntrance;
		set => SelectedEntranceExit = value;
	}

	public OverworldEntrance LastSelectedEntrance
	{
		get => LastSelectedEntranceExit as OverworldEntrance;
		set => LastSelectedEntranceExit = value;
	}






	private void OnMouseDown_EntranceExit(MouseEventArgs e)
	{
		SelectedEntranceExit = GetEntranceExit(ZS.OverworldManager.allentrances)
			?? GetEntranceExit(ZS.OverworldManager.allholes)
			?? GetEntranceExit(ZS.OverworldManager.allexits);

		if (e.Button == MouseButtons.Left)
		{
			SelectedEntranceExit = LastSelectedEntranceExit;
		}

		if (SelectedEntranceExit is null) return;
		;
		int roomId = SelectedEntranceExit switch
		{
			OverworldEntrance ee => ZS.entrances[ee.TargetEntranceID].RoomID,
			OverworldExit xx => xx.TargetRoomID,
			_ => 0
		};

		if (roomId >= Constants.NumberOfRooms) return;

		RoomPreviewArtist.CurrentRoom = ZS.all_rooms[roomId];

		IOverworldUWLink GetEntranceExit(IOverworldUWLink[] list)
		{
			foreach (var en in list)
			{
				if (en.IsInThisWorld(ZS.OverworldManager.World) && en.MouseIsInHitbox(e))
				{
					return en;
				}
			}

			return null;
		}
	}

	private void Delete_EntranceExit()
	{
		if (LastSelectedEntranceExit is null) return;

		LastSelectedEntranceExit.GlobalX = Constants.NullEntrance;
		LastSelectedEntranceExit.GlobalY = Constants.NullEntrance;
		LastSelectedEntranceExit.MapID = 0;
		LastSelectedEntranceExit.TargetID = 0xFFFF;
	}

	private void OnMouseMove_EntranceExit(MouseEventArgs e)
	{
		if (!MouseIsDown)
		{
			FindHoveredEntity(ZS.OverworldManager.allentrances, e);

			if (hoveredEntity is null)
			{
				FindHoveredEntity(ZS.OverworldManager.allholes, e);
			}

			if (hoveredEntity is null)
			{
				FindHoveredEntity(ZS.OverworldManager.allexits, e);
			}

			return;
		}

		if (IsLeftPress && SelectedEntranceExit is not null)
		{
			SelectedEntranceExit.GlobalX = (ushort) e.X;
			SelectedEntranceExit.GlobalY = (ushort) e.Y;
			SelectedEntranceExit.SnapToGrid();
		}
	}

	private void OnMouseUp_EntranceExit(MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			if (SelectedEntranceExit is not null)
			{
				SelectedEntranceExit.MapID = ZS.OverworldManager.allmaps[hoveredMap + ZS.OverworldManager.WorldOffset].ParentMapID;
				SelectedEntranceExit = null;
			}
		}

		if (e.Button != MouseButtons.Right) return;

//		ContextMenuStrip menu = new ContextMenuStrip();
//		for (int i = 0; i < ZS.OverworldManager.allentrances.Length; i++)
//		{
//			OverworldEntrance en = ZS.OverworldManager.allentrances[i];
//			if (en.IsInThisWorld(ZS.OverworldManager.World) && en.MouseIsInHitbox(e))
//			{
//				menu.Items.Add("Add Entrance");
//				menu.Items.Add("Delete Entrance");
//				LastSelectedEntrance = en;
//				SelectedEntrance = null;
//
//				if (LastSelectedEntrance == null)
//				{
//					menu.Items[1].Enabled = false;
//				}
//
//				menu.Items[0].Click += entranceAdd_Click;
//				menu.Items[1].Click += Delete_Click;
//				menu.Show(Cursor.Position);
//				return;
//			}
//		}
//
//		for (int i = 0; i < ZS.OverworldManager.allholes.Length; i++)
//		{
//
//			OverworldEntrance en = ZS.OverworldManager.allholes[i];
//			if (en.IsInThisWorld(ZS.OverworldManager.World) && en.MouseIsInHitbox(e))
//			{
//
//				menu.Items.Add("Add Entrance");
//				menu.Items.Add("Delete Entrance");
//				LastSelectedEntrance = en;
//				SelectedEntrance = null;
//
//				if (LastSelectedEntrance == null)
//				{
//					menu.Items[1].Enabled = false;
//				}
//
//				menu.Items[0].Click += entranceAdd_Click;
//				menu.Items[1].Click += Delete_Click;
//				menu.Show(Cursor.Position);
//				return;
//
//			}
//		}
//
//		menu.Items.Add("Add Entrance");
//		SelectedEntrance = null;
//		menu.Items[0].Click += entranceAdd_Click;
//
//		menu.Show(Cursor.Position);
	}

	private void DrawEntrancesAndExits(Graphics g)
	{
		Brush bgrBrush;
		Pen outline;

		if (ZGUI.showExits)
		{
			DrawEntranceExitList(ZS.OverworldManager.allexits, UIColors.ExitBrush, UIColors.ExitSelectedBrush);
		}

		if (ZGUI.showEntrances)
		{
			DrawEntranceExitList(ZS.OverworldManager.allentrances, UIColors.EntranceBrush, UIColors.EntranceSelectedBrush);
			DrawEntranceExitList(ZS.OverworldManager.allholes, UIColors.HoleEntranceBrush, UIColors.HoleEntranceSelectedBrush);
		}
		

		void DrawEntranceExitList(IEnumerable<IOverworldUWLink> list, SolidBrush col, SolidBrush sel)
		{
			int i = 0;
			foreach (var ent in list)
			{
				if (ent.IsInThisWorld(ZS.OverworldManager.World))
				{
					string txt;
					if (SelectedEntranceExit == ent)
					{
						bgrBrush = sel;
						outline = UIColors.OutlineSelectedPen;
					}
					else if (hoveredEntity == ent)
					{
						bgrBrush = col;
						outline = UIColors.OutlineHoverPen;
					}
					else
					{
						bgrBrush = col;
						outline = UIColors.OutlinePen;
					}

					switch (EntranceTextView)
					{
						case TextView.NeverShowName:
							txt = $"{i:X2}";
							break;

						case TextView.AlwaysShowName:
						case TextView.ShowNameOnHover when ent == SelectedEntranceExit || ent == hoveredEntity:
							txt = ent switch
							{
								OverworldEntrance enn => $"{i:X2} is {enn.TargetEntranceID:X2} to {ZS.all_rooms[ZS.entrances[enn.TargetEntranceID].RoomID].Name}",
								OverworldExit exx => $"{i:X2} from {exx.TargetRoomID:X3}",
								_ => "Uh oh"
							};
								
							break;

						default:
						case TextView.ShowNameOnHover:
							goto case TextView.NeverShowName;
					}

					g.DrawFilledRectangleWithOutline(ent.BoundingBox, outline, bgrBrush);

					g.DrawText(ent.GlobalX, ent.GlobalY + 9, txt);
					i++;
				}
			}
		}; // end draw Action
	}


	public OverworldExit AddExit(bool clipboard = false)
	{
		int found = -1;
		for (int i = 0; i < ZS.OverworldManager.allexits.Length; i++)
		{
			var exit = ZS.OverworldManager.allexits[i];
			if (exit.Deleted)
			{
				exit.MapID = ZS.OverworldManager.allmaps[hoveredMap + ZS.OverworldManager.WorldOffset].ParentMapID;
				exit.GlobalX = (ushort) (RightClickedXAt & ~0xF);
				exit.GlobalY = (ushort) (RightClickedYAt & ~0xF);

				if (clipboard)
				{
					OverworldExit data = (OverworldExit) Clipboard.GetData(Constants.OverworldExitClipboardData);
					if (data != null)
					{
						exit.CameraX = data.CameraX;
						exit.CameraY = data.CameraY;
						exit.ScrollX = data.ScrollX;
						exit.ScrollY = data.ScrollY;
						exit.unk1 = data.unk1;
						exit.unk2 = data.unk2;
						exit.TargetRoomID = data.TargetRoomID;
						exit.doorType1 = data.doorType1;
						exit.doorType2 = data.doorType2;
						exit.doorXEditor = data.doorXEditor;
						exit.doorYEditor = data.doorYEditor;
					}
				}

				exit.UpdateMapProperties(ZScreamer.ActiveOW.allmaps[exit.MapID].IsPartOfLargeMap);

				found = i;
				break;
			}
		}

		if (found == -1)
		{
			MessageBox.Show("No space available for new exits, delete one first.");
			return null;
		}

		return ZS.OverworldManager.allexits[found];
	}

	public OverworldEntrance AddEntrance(bool clipboard = false)
	{
		byte entranceID = 0;
		bool ishole = false;
		if (clipboard)
		{
			var data = (OverworldEntrance) Clipboard.GetData(Constants.OverworldEntranceClipboardData);
			if (data != null)
			{
				entranceID = data.TargetEntranceID;
				ishole = data.IsPitEntrance;
			}
		}

		var list = ishole ? ZS.OverworldManager.allholes : ZS.OverworldManager.allentrances;
		OverworldEntrance found = null;

		foreach (var e in list)
		{
			if (e.Deleted)
			{
				found = e;
				break;
			}
		}

		if (found is null)
		{
			if (ishole)
			{
				throw new ZeldaException("No space available for a new hole. Delete one first.");
			}
			else
			{
				throw new ZeldaException("No space available for a new entrance. Delete one first.");
			}
		}

		found.MapID = ZS.OverworldManager.allmaps[hoveredMap + ZS.OverworldManager.WorldOffset].ParentMapID;
		found.GlobalX = (ushort) (RightClickedXAt & ~0x0F);
		found.GlobalY = (ushort) (RightClickedYAt & ~0x0F);
		found.TargetEntranceID = entranceID;

		SelectedEntrance = found;
		MouseIsDown = true;
		IsLeftPress = true;

		return found;
	}

	// TODO move to the side tab
	//ZS.CurrentOWMode = OverworldEditMode.Doors;
	//if (lastselectedExit.doorType1 != 0) // Wooden door
	//{
	//	selectedTile = new ushort[2];
	//	selectedTileSizeX = 2;
	//	selectedTile[0] = 1865;
	//	selectedTile[1] = 1866;
	//
	//}
	//else if ((lastselectedExit.doorType2 & 0x8000) != 0) // Castle door
	//{
	//	selectedTile = new ushort[4];
	//	selectedTileSizeX = 2;
	//	selectedTile[0] = 3510;
	//	selectedTile[1] = 3511;
	//	selectedTile[2] = 3512;
	//	selectedTile[3] = 3513;
	//}
	//else if ((lastselectedExit.doorType2 & 0x7FFF) != 0) // Sanctuary door
	//{
	//	selectedTile = new ushort[2];
	//	selectedTileSizeX = 2;
	//	selectedTile[0] = 3502;
	//	selectedTile[1] = 3503;
	//}
}
