namespace ZeldaFullEditor.UserInterface.UIControl.Scene
{
	public partial class SceneOW
	{
		private OverworldExit lastexit;

		public OverworldExit SelectedExit { get; set; }

		public OverworldExit LastSelectedExit
		{
			get => lastexit;
			set
			{
				if (lastexit == value) return;

				ZGUI.OverworldEditor.SetSelectedExit(value);
				lastexit = value;
			}
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
					exit.GlobalX = (ushort) (mxRightclick & ~0xF);
					exit.GlobalY = (ushort) (myRightclick & ~0xF);

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

		private void OnMouseDown_Exit(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				for (int i = 0; i < 78; i++)
				{
					OverworldExit en = ZS.OverworldManager.allexits[i];
					if (en.IsInThisWorld(ZS.OverworldManager.World) && en.MouseIsInHitbox(e))
					{
						SelectedExit = LastSelectedExit = en;
						break;
					}
				}
			}

			if (SelectedExit == null) return;

			//scene.owForm.thumbnailBox.Visible = true;
			//scene.owForm.thumbnailBox.Size = new Size(256, 256);
			int roomId = SelectedExit.TargetRoomID;
			if (roomId >= Constants.NumberOfRooms) return;

			RoomPreviewArtist.CurrentRoom = ZS.all_rooms[roomId];
		}

		private void Delete_Exit() // Set exit data to 0
		{
			LastSelectedExit.GlobalX = Constants.NullEntrance;
			LastSelectedExit.GlobalY = Constants.NullEntrance;
			LastSelectedExit.MapID = 0;
		}

		private void OnMouseMove_Exit(MouseEventArgs e)
		{
			if (!MouseIsDown)
			{
				FindHoveredEntity(ZS.OverworldManager.allexits, e);
				return;
			}

			MoveDestinationToMouse(SelectedExit, e);
		}

		private void OnMouseUp_Exit(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && SelectedExit != null)
			{
				LastSelectedExit = SelectedExit;
				SelectedExit = null;
				return;
			}

			if (e.Button != MouseButtons.Right) return;

			bool clickedon = false;
			var menu = new ContextMenuStrip();

			if (!clickedon)
			{
				mxRightclick = e.X;
				myRightclick = e.Y;
				menu.Items.Add("Insert Exit");
				menu.Items[0].Click += insertExit_Click;
				menu.Show(Cursor.Position);
			}

		}

		public void insertExit_Click(object sender, EventArgs e)
		{
			AddExit();
		}

		public void exitDelete_Click(object sender, EventArgs e)
		{
			Delete_Exit();
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

		public void Draw_Exit(Graphics g)
		{
			Brush bgrBrush;
			Pen outline;

			for (int i = 0; i < 78; i++)
			{
				OverworldExit ex = ZS.OverworldManager.allexits[i];

				if (lowEndMode && ex.MapID != CurrentParentMapID)
				{
					continue;
				}

				if (ex.IsInThisWorld(ZS.OverworldManager.World))
				{
					string txt;
					if (SelectedExit == ex)
					{
						bgrBrush = UIColors.ExitSelectedBrush;
						outline = UIColors.OutlineSelectedPen;

						g.DrawRectangle(Pens.LightPink, new Rectangle(ex.ScrollX, ex.ScrollY, 256, 224));
						g.DrawLine(Pens.Blue, ex.CameraX - 8, ex.CameraY, ex.CameraX + 8, ex.CameraY);
						g.DrawLine(Pens.Blue, ex.CameraX, ex.CameraY - 8, ex.CameraX, ex.CameraY + 8);
					}
					else if (hoveredEntity == ex)
					{
						bgrBrush = UIColors.ExitBrush;
						outline = UIColors.OutlineHoverPen;
					}
					else
					{
						bgrBrush = UIColors.ExitBrush;
						outline = UIColors.OutlinePen;
					}

					switch (ExitTextView)
					{
						case TextView.NeverShowName:
							txt = $"{i:X2}";
							break;

						case TextView.AlwaysShowName:
						case TextView.ShowNameOnHover when ex == SelectedExit || ex == hoveredEntity:
							txt = $"{i:X2} from {ex.TargetRoomID:X3}";
							break;

						default:
						case TextView.ShowNameOnHover:
							goto case TextView.NeverShowName;
					}

					g.DrawFilledRectangleWithOutline(ex.BoundingBox, outline, bgrBrush);

					g.DrawText(ex.GlobalX + 4, ex.GlobalY + 4, txt);
				}
			}
		}
	}
}
