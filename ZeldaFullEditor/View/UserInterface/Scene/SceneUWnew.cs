namespace ZeldaFullEditor.View.UserInterface.Scene
{
	public partial class SceneUW : Scene
	{
		Rectangle lastSelectedRectangle;

		public DungeonEditMode CurrentMode => ZS.CurrentUWMode;

		bool resizing = false;

		private readonly ModeActions layer1Mode;
		private readonly ModeActions layer2Mode;
		private readonly ModeActions layer3Mode;
		private readonly ModeActions layerAllMode;
		private readonly ModeActions doorMode;
		private readonly ModeActions spriteMode;
		private readonly ModeActions secretsMode;
		private readonly ModeActions blockMode;
		private readonly ModeActions torchMode;
		private readonly ModeActions entranceMode;
		private readonly ModeActions collisionMode;

		public IDungeonPlaceable ObjectToPlace { get; set; }

		private Room room;
		public Room Room
		{
			get => room;
			set
			{
				room = value;
				RedrawRoom();
			}
		}

		private readonly Rectangle[] DoorRectangles;
		public SceneUW(ZScreamer zs) : base(zs)
		{
			Size = Constants.SupertileSize;

			DoorRectangles = BuildDoorRectangles();

			layer1Mode = layer2Mode = layer3Mode =
			layerAllMode = new ModeActions(OnMouseDown_Layer, OnMouseUp_Layer, OnMouseMove_Layer, OnMouseWheel_Layer,
				Copy_Layer, Paste_Layer, null, Delete_Layer, SelectAll_Layer);

			doorMode = new ModeActions(OnMouseDown_Door, OnMouseUp_Door, OnMouseMove_Door, OnMouseWheel_Door,
				Copy_Door, Paste_Door, Insert_Door, Delete_Door, SelectAll_Door);

			spriteMode = new ModeActions(OnMouseDown_Sprites, OnMouseUp_Sprites, OnMouseMove_Sprites, null,
				Copy_Sprites, Paste_Sprites, null, Delete_Sprites, SelectAll_Sprites);

			secretsMode = new ModeActions(OnMouseDown_Secrets, OnMouseUp_Secrets, OnMouseMove_Secrets, OnMouseWheel_Secrets,
				Copy_Secrets, Paste_Secrets, Insert_Secrets, Delete_Secrets, SelectAll_Secrets);

			blockMode = new ModeActions(OnMouseDown_Blocks, OnMouseUp_Blocks, OnMouseMove_Blocks, null,
				Copy_Blocks, Paste_Blocks, Insert_Blocks, Delete_Blocks, SelectAll_Blocks);

			torchMode = new ModeActions(OnMouseDown_Torch, OnMouseUp_Torch, OnMouseMove_Torch, null,
				Copy_Torch, Paste_Torch, Insert_Torch, Delete_Torch, SelectAll_Torch);

			entranceMode = new ModeActions(OnMouseDown_Entrance, OnMouseUp_Entrance, OnMouseMove_Entrance,
				null, null, null, null, null, null);

			collisionMode = new ModeActions(OnMouseDown_Collision, OnMouseUp_Collision, OnMouseMove_Collision, null,
				null, null, null, null, null);

			Paint += SceneUW_Paint;
		}

		public RoomLayer Layer { get; private set; }

		public void UpdateForMode(DungeonEditMode e)
		{
			ActiveMode = e switch
			{
				DungeonEditMode.Layer1 => layer1Mode,
				DungeonEditMode.Layer2 => layer2Mode,
				DungeonEditMode.Layer3 => layer3Mode,
				DungeonEditMode.LayerAll => layerAllMode,
				DungeonEditMode.Sprites => spriteMode,
				DungeonEditMode.Secrets => secretsMode,
				DungeonEditMode.Blocks => blockMode,
				DungeonEditMode.Torches => torchMode,
				DungeonEditMode.Doors => doorMode,
				DungeonEditMode.CollisionMap => collisionMode,
				DungeonEditMode.Entrances => entranceMode,
				_ => ModeActions.Nothing
			};

			Layer = e switch
			{
				DungeonEditMode.Layer1 => RoomLayer.Layer1,
				DungeonEditMode.Layer2 => RoomLayer.Layer2,
				DungeonEditMode.Layer3 => RoomLayer.Layer3,
				_ => RoomLayer.None
			};
		}

		public void MoveSelectedObjects()
		{
			foreach (var o in Room.SelectedObjects)
			{
				if (o is IFreelyPlaceable gg)
				{
					gg.RealX = (byte) (gg.GridX + MoveX).Clamp(0, 80);
					gg.RealY = (byte) (gg.GridY + MoveY).Clamp(0, 80);
				}
			}

			RedrawRoom();
		}

		public void Clear()
		{
			// TODO: Add something here?
			//graphics.Clear(this.BackColor);
		}

		public void HardRefresh()
		{
			RedrawRoom();
			Refresh();
		}

		private void RedrawRoom()
		{
			ZGUI.DungeonEditor.UpdateFormForSelectedObject(Room.OnlySelectedObject);

			// TODO ROOM.DRAW()

			RoomEditingArtist.CurrentRoom = Room;
			RoomEditingArtist.HardRefresh();

			Refresh();
		}

		public override void Refresh()
		{
			ZGUI.DungeonEditor.UpdateUIForRoom(Room, true);
			Invalidate();
			base.Refresh();
		}


		protected override void OnMouseDown(object sender, MouseEventArgs e)
		{
			if (Room is null) return;

			base.OnMouseDown(sender, e);
		}

		protected override void OnMouseMove(object sender, MouseEventArgs e)
		{
			if (MouseIsDown)
			{
				if (MouseX != LastX || MouseY != LastY)
				{
					MoveSelectedObjects();
				}
			}
			base.OnMouseDown(sender, e);
		}

		public void clearCustomCollisionMap()
		{
			throw new NotImplementedException();
		}

		public void getObjectsRectangle()
		{
			throw new NotImplementedException();
		}

		public override void Undo()
		{
			throw new NotImplementedException();
		}

		public override void Redo()
		{
			throw new NotImplementedException();
		}

		private void SceneUW_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			if (Room == null)
			{
				g.Clear(BackColor);
				return;
			}

			RoomEditingArtist.DrawSelfToImage(g);

			// Draw selection
			Pen selectionColor = MouseIsDown ? Pens.LimeGreen : Pens.Green;
			foreach (var o in Room.SelectedObjects)
			{
				g.DrawRectangle(selectionColor, o.BoundingBox);
			}

			// Draw BG2 outlines
			if (ZGUI.ShowBG2Outline)
			{
				foreach (var l in Room.AllObjects)
				{
					foreach (var o in l)
					{
						if (o.ObjectType.Specialness == ObjectSpecialType.LayerMask)
						{
							g.DrawRectangle(Pens.DarkCyan, o.BoundingBox);
						}
					}
				}
			}

			// Draw BG2 annotations
			if (ZGUI.invisibleObjectsTextToolStripMenuItem.Checked)
			{
				foreach (var l in Room.AllObjects)
				{
					foreach (var o in l)
					{
						if (o.ObjectType.Specialness == ObjectSpecialType.LayerMask)
						{
							g.DrawText(o.RealX, o.RealY, "BG2 mask");
						}
					}
				}
			}

			// Draw chest numbers
			int id = 0;
			if (ZGUI.showChestIDs)
			{
				foreach (var c in Room.ChestList)
				{
					if (c.IsAssociated)
					{
						g.DrawText(c.RealX + 6, c.RealY + 8, id.ToString());
					}
					id++;
				}
			}

			// TODO deal with overlapping shit
			// Draw door text
			id = 0;
			if (ZGUI.showDoorsIDs)
			{
				foreach (var d in Room.DoorsList)
				{
					g.DrawText(d.RealX + 12, d.RealY + 8, id.ToString());

					if (d.DoorType.IsExit)
					{
						g.DrawText(d.RealX + 6, d.RealY + 10, "Exit");
					}
					else if (d.DoorType.Category == DoorCategory.LayerSwap)
					{
						g.DrawText(d.RealX + 6, d.RealY + 10, "Layer swap");
					}
					else if (d.DoorType.Category == DoorCategory.DungeonSwap)
					{
						g.DrawText(d.RealX + 6, d.RealY + 10, "Dungeon swap");
					}

					id++;
				}
			}

			// Draw blocks with Ms
			foreach (var b in Room.BlocksList)
			{
				g.DrawImage(GraphicsManager.moveableBlock, b.RealX, b.RealY);
			}

			// Draw staircase targets
			foreach (var s in Room.AllStairs)
			{
				if (s.IsAssociated)
				{
					g.DrawText(s.RealX, s.RealY + 18, s.ToString());
				}
			}

			// Draw secret item names
			if (ZGUI.showItemsText)
			{
				foreach (var s in Room.SecretsList)
				{
					g.DrawText(s.RealX, s.RealY, s.Name);
				}
			}

			// Draw sprite names
			if (ZGUI.showSpriteText)
			{
				foreach (var s in Room.SpritesList)
				{
					g.DrawText(s.RealX, s.RealY, s.Name);
				}
			}

			// Draw selected entrance position
			if (ZGUI.DungeonEditor.selectedEntrance != null && ZGUI.entrancePositionToolStripMenuItem.Checked)
			{
				var n = ZGUI.DungeonEditor.selectedEntrance;
				if (n.RoomID == Room.RoomID)
				{
					g.DrawRectangle(Pens.Orange, n.CameraTriggerX - 128, n.CameraTriggerY - 116, 256, 224);
					int xx = n.XPosition & 0x1FF;
					int yy = n.YPosition & 0x1FF;
					g.DrawLine(Pens.White, xx - 4, yy, xx + 4, yy);
					g.DrawLine(Pens.White, xx, yy - 4, xx, yy + 4);
				}
			}

			// TODO add back with proper stuff
			// Draw grid
			//int wh = (512 / ZGUI.gridSize) + 1;
			//
			//for (int x = 0, l = 0; x < wh; x++, l += ZGUI.gridSize)
			//{
			//	g.DrawLine(Constants.HalfWhitePen, l, 0, l, 512);
			//	g.DrawLine(Constants.HalfWhitePen, 0, l, 512, l);
			//}

			// Done
			if (CurrentMode == DungeonEditMode.Doors)
			{
				g.DrawRectangles(Constants.ThirdGreenPen, DoorRectangles);
			}
			else if (CurrentMode == DungeonEditMode.CollisionMap)
			{
				Draw_Collision(g);
			}

		} // End Paint();


		private void ResetPlacementProperties()
		{
			ObjectToPlace = null;
		}

		// TODO
		private bool CheckIfObjectIsInvalidForPlacement()
		{
			ZeldaException spaghetti = null;

			// TODO probably a switch statement here
			// or maybe even delegates? idk
			if (ObjectToPlace is DungeonSprite && ZS.CurrentUWMode != DungeonEditMode.Sprites)
			{
				spaghetti = new ZeldaException("Sprites can only be placed while working in sprite mode.");
			}
			else if (ObjectToPlace is RoomObject && ZS.CurrentUWMode > DungeonEditMode.Layer3)
			{
				spaghetti = new ZeldaException("Objects can only be placed while working on backgrounds 1, 2, or 3.");
			}
			else if (ObjectToPlace is LightableTorch && ZS.CurrentUWMode != DungeonEditMode.Torches)
			{
				spaghetti = new ZeldaException("TORCHES");
			}
			else if (ObjectToPlace is PushableBlock && ZS.CurrentUWMode != DungeonEditMode.Blocks)
			{
				spaghetti = new ZeldaException("BLOCKS");
			}

			if (spaghetti != null)
			{
				MouseIsDown = false;
				ObjectToPlace = null;
				throw spaghetti;
			}

			return true;
		}
	}
}
