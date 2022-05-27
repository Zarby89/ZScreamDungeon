namespace ZeldaFullEditor.UserInterface.UserControl.Scene
{
	public partial class SceneOW
	{
		private OverworldEntrance lastentrance;

		public OverworldEntrance SelectedEntrance { get; set; }

		public OverworldEntrance LastSelectedEntrance
		{
			get => lastentrance;
			set
			{
				if (lastentrance == value) return;

				lastentrance = value;
				ZGUI.OverworldEditor.SetSelectedEntrance(lastentrance);
				ZGUI.UpdateFormForSelectedObject(lastentrance);
			}
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
			found.GlobalX = (ushort) (mxRightclick & ~0x0F);
			found.GlobalY = (ushort) (myRightclick & ~0x0F);
			found.TargetEntranceID = entranceID;

			SelectedEntrance = found;
			MouseIsDown = true;
			IsLeftPress = true;

			return found;
		}

		private void OnMouseDown_Entrance(MouseEventArgs e)
		{

			LastSelectedEntrance = GetEntrance(ZS.OverworldManager.allentrances) ?? GetEntrance(ZS.OverworldManager.allholes);

			if (e.Button == MouseButtons.Left)
			{
				SelectedEntrance = LastSelectedEntrance;
			}
			else if (e.Button == MouseButtons.Right)
			{
				mxRightclick = e.X;
				myRightclick = e.Y;
			}


			if (SelectedEntrance == null) return;

			int roomId = ZS.entrances[SelectedEntrance.TargetEntranceID].RoomID;
			if (roomId >= Constants.NumberOfRooms) return;

			RoomPreviewArtist.SetRoomAndDrawImmediately(ZS.all_rooms[roomId]);

			OverworldEntrance GetEntrance(OverworldEntrance[] list)
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

		public void DrawTempEntrance()
		{
			//Graphics g = Graphics.FromImage(ZGUI.OverworldEditor.tmpPreviewBitmap);
			//g.InterpolationMode = InterpolationMode.Bilinear;
			//if (ZGUI.DungeonEditor.previewRoom.LayerEffect != Constants.LayerMergeTranslucent || ZGUI.DungeonEditor.previewRoom.LayerEffect != Constants.LayerMergeTransparent ||
			// ZGUI.DungeonEditor.previewRoom.LayerEffect != Constants.LayerMergeOnTop || ZGUI.DungeonEditor.previewRoom.LayerEffect != Constants.LayerMergeOff)
			//{
			//	g.DrawImage(ZS.GFXManager.roomBg2Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);
			//}
			//
			//g.DrawImage(ZS.GFXManager.roomBg1Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);
			//
			//if (ZGUI.DungeonEditor.previewRoom.LayerEffect == Constants.LayerMergeTranslucent || ZGUI.DungeonEditor.previewRoom.LayerEffect == Constants.LayerMergeTransparent)
			//{
			//	float[][] matrixItems ={
			//		new float[] {1f, 0, 0, 0, 0},
			//		new float[] {0, 1f, 0, 0, 0},
			//		new float[] {0, 0, 1f, 0, 0},
			//		new float[] {0, 0, 0, 0.5f, 0},
			//		new float[] {0, 0, 0, 0, 1}
			//	};
			//	ColorMatrix colorMatrix = new ColorMatrix(matrixItems);
			//
			//	// Create an ImageAttributes object and set its color matrix.
			//	ImageAttributes imageAtt = new ImageAttributes();
			//
			//	imageAtt.SetColorMatrix
			//	(
			//	   colorMatrix,
			//	   ColorMatrixFlag.Default,
			//	   ColorAdjustType.Bitmap
			//	);
			//
			//	//GFX.roomBg2Bitmap.MakeTransparent(Color.Black);
			//	g.DrawImage(ZS.GFXManager.roomBg2Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel, imageAtt);
			//}
			//else if (ZGUI.DungeonEditor.previewRoom.LayerEffect == Constants.LayerMergeOnTop)
			//{
			//	g.DrawImage(ZS.GFXManager.roomBg2Bitmap, Constants.Rect_0_0_256_256, 0, 0, 512, 512, GraphicsUnit.Pixel);
			//}
			//
			//ZS.UnderworldScene.g.DrawText(0, 0, "ROOM : " + ZGUI.DungeonEditor.previewRoom.RoomID.ToString("X2"));
			//g.InterpolationMode = InterpolationMode.NearestNeighbor;
			//g.Dispose();
		}

		private void Delete_Entrance()
		{
			LastSelectedEntrance.GlobalX = Constants.NullEntrance;
			LastSelectedEntrance.GlobalY = Constants.NullEntrance;
			LastSelectedEntrance.MapID = 0;
			LastSelectedEntrance.TargetEntranceID = 0;
		}

		private void OnMouseMove_Entrance(MouseEventArgs e)
		{
			if (!MouseIsDown)
			{
				FindHoveredEntity(ZS.OverworldManager.allentrances, e);

				if (hoveredEntity == null)
				{
					FindHoveredEntity(ZS.OverworldManager.allholes, e);

				}

				return;
			}

			if (IsLeftPress && SelectedEntrance != null)
			{
				SelectedEntrance.GlobalX = (ushort) e.X;
				SelectedEntrance.GlobalY = (ushort) e.Y;
				SelectedEntrance.SnapToGrid();
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
					SelectedEntrance.MapID = ZS.OverworldManager.allmaps[hoveredMap + ZS.OverworldManager.WorldOffset].ParentMapID;
					SelectedEntrance = null;
				}
			}

			if (e.Button != MouseButtons.Right) return;

			ContextMenuStrip menu = new ContextMenuStrip();
			for (int i = 0; i < ZS.OverworldManager.allentrances.Length; i++)
			{
				OverworldEntrance en = ZS.OverworldManager.allentrances[i];
				if (en.IsInThisWorld(ZS.OverworldManager.World) && en.MouseIsInHitbox(e))
				{
					menu.Items.Add("Add Entrance");
					menu.Items.Add("Delete Entrance");
					LastSelectedEntrance = en;
					SelectedEntrance = null;

					if (LastSelectedEntrance == null)
					{
						menu.Items[1].Enabled = false;
					}

					menu.Items[0].Click += entranceAdd_Click;
					menu.Items[1].Click += Delete_Click;
					menu.Show(Cursor.Position);
					return;
				}
			}

			for (int i = 0; i < ZS.OverworldManager.allholes.Length; i++)
			{

				OverworldEntrance en = ZS.OverworldManager.allholes[i];
				if (en.IsInThisWorld(ZS.OverworldManager.World) && en.MouseIsInHitbox(e))
				{

					menu.Items.Add("Add Entrance");
					menu.Items.Add("Delete Entrance");
					LastSelectedEntrance = en;
					SelectedEntrance = null;

					if (LastSelectedEntrance == null)
					{
						menu.Items[1].Enabled = false;
					}

					menu.Items[0].Click += entranceAdd_Click;
					menu.Items[1].Click += Delete_Click;
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
			for (int i = 0; i < ZS.OverworldManager.allentrances.Length; i++)
			{
				if (ZS.OverworldManager.allentrances[i].Deleted)
				{
					ZS.OverworldManager.allentrances[i].MapID = ZS.OverworldManager.allmaps[hoveredMap + ZS.OverworldManager.WorldOffset].ParentMapID;
					ZS.OverworldManager.allentrances[i].GlobalX = (ushort) (mxRightclick & ~0xF);
					ZS.OverworldManager.allentrances[i].GlobalY = (ushort) (myRightclick & ~0xF);
					return;
				}
			}

			throw new ZeldaException("No space available for new entrances; Delete one first.");
		}

		private void Delete_Click(object sender, EventArgs e)
		{
			Delete_Exit();
		}

		private void Draw_Entrance(Graphics g)
		{
			Brush bgrBrush;
			Pen outline;

			DrawEntranceList(ZS.OverworldManager.allentrances, UIColors.EntranceBrush, UIColors.EntranceSelectedBrush);
			DrawEntranceList(ZS.OverworldManager.allholes, UIColors.HoleEntranceBrush, UIColors.HoleEntranceSelectedBrush);

			void DrawEntranceList(IEnumerable<OverworldEntrance> list, SolidBrush col, SolidBrush sel)
			{
				int i = 0;
				foreach (var ent in list)
				{
					if (ent.IsInThisWorld(ZS.OverworldManager.World))
					{
						string txt;
						if (SelectedEntrance == ent)
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

						switch (SecretsTextView)
						{
							case TextView.NeverShowName:
								txt = $"{i:X2}";
								break;

							case TextView.AlwaysShowName:
							case TextView.ShowNameOnHover when ent == SelectedEntrance || ent == hoveredEntity:
								txt = $"{i:X2} is {ent.TargetEntranceID:X2} to {ZS.all_rooms[ZS.entrances[ent.TargetEntranceID].RoomID].Name}";
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
	}
}
