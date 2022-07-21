namespace ZeldaFullEditor.UserInterface.UIControl.Scene;

public partial class SceneUW : Scene
{
	public DungeonEditMode CurrentMode => ZS.CurrentUWMode;

	private bool Selecting = false;

	private IDungeonPlaceable hoveredEntity = null;

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

			RoomEditingArtist.CurrentRoom = Room;
			UpdateDungeonForm();

			Refresh();
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

		spriteMode = new ModeActions(OnMouseDown_Sprites, OnMouseUp_Sprites, OnMouseMove_Sprites, OnMouseWheel_Sprites,
			Copy_Sprites, Paste_Sprites, null, Delete_Sprites, SelectAll_Sprites);

		secretsMode = new ModeActions(OnMouseDown_Secrets, OnMouseUp_Secrets, OnMouseMove_Secrets, OnMouseWheel_Secrets,
			Copy_Secrets, Paste_Secrets, Insert_Secrets, Delete_Secrets, SelectAll_Secrets);

		blockMode = new ModeActions(OnMouseDown_Blocks, OnMouseUp_Blocks, OnMouseMove_Blocks, null,
			Copy_Blocks, Paste_Blocks, Insert_Blocks, Delete_Blocks, SelectAll_Blocks);

		torchMode = new ModeActions(OnMouseDown_Torch, OnMouseUp_Torch, OnMouseMove_Torch, null,
			Copy_Torch, Paste_Torch, Insert_Torch, Delete_Torch, SelectAll_Torch);

		entranceMode = new ModeActions(OnMouseDown_Entrance, null, OnMouseMove_Entrance,
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

	private Rectangle GetSelectionRectangle()
	{
		return new Rectangle(
			Math.Min(MouseX, LastX),
			Math.Min(MouseY, LastY),
			Math.Abs(MoveX),
			Math.Abs(MoveY)
		);
	}

	private void FindHoveredEntity(IEnumerable<IDungeonPlaceable> list, MouseEventArgs e)
	{
		hoveredEntity = list.LastOrDefault(o => o.MouseIsInHitbox(e));
	}
	
	private void SelectAllEntitiesInRectangle(IEnumerable<IDungeonPlaceable> list)
	{
		if (!Selecting) return;

		var rect = GetSelectionRectangle();

		foreach (var o in list)
		{
			if (o.IsCapturedByRectangle(rect))
			{
				Room.AddObjectToSelectedIfItIsntThere(o);
			}
		}

		UpdateDungeonForm();
	}


	private void UpdateDungeonForm()
	{
		if (Room is null) return;

		if (Room.SelectedObjects.Count > 1)
		{
			ZGUI.DungeonEditor.UpdateFormForManySelectedObjects(Room.SelectedObjects);
			return;
		}
		ZGUI.DungeonEditor.UpdateFormForSelectedObject(Room.OnlySelectedObject);
	}

	private void HandleSelectingHoveredObject()
	{
		if (hoveredEntity is IFreelyPlaceable f)
		{
			f.LockPosition();
		}

		if (ModifierKeys == Keys.Control)
		{
			if (hoveredEntity is null)
			{
				Selecting = true;
				return;
			}
			Room.RemoveIfThereOrAddToSelectedObjects(hoveredEntity);
		}
		else
		{
			if (hoveredEntity is null)
			{
				Room.ClearSelectedList();
				Selecting = true;
			}
			else if (Room.SelectedObjects.Contains(hoveredEntity))
			{
				return;
			}
			else
			{
				Room.OnlySelectedObject = hoveredEntity;
			}
		}
		UpdateDungeonForm();
	}

	public void MoveSelectedObjects()
	{
		if (Room is null) return;

		if (Room.OnlySelectedObject is DungeonDoor d)
		{
			var loc = DungeonDoorPosition.ListOf.FirstOrDefault(p => p.BoundingBox.Contains(MouseX, MouseY), null);
			if (loc is null) return;
			d.Position = loc;
		}
		else
		{
			foreach (var o in Room.SelectedObjects)
			{
				if (o is IFreelyPlaceable gg)
				{
					gg.MoveByDelta(MoveX, MoveY);
				}
			}
		}

		UpdateDungeonForm();

		InvalidateRoomTilemapAndArtist();
	}

	public void Clear()
	{
		// TODO: Add something here?
	}

	public void HardRefresh()
	{
		InvalidateRoomTilemapAndArtist();
		Refresh();
	}

	public override void Refresh()
	{
		if (!CanIRefresh()) return;
		ZGUI.DungeonEditor.UpdateUIForRoom(Room, true);
		base.Refresh();
	}


	protected override void OnMouseDown(object sender, MouseEventArgs e)
	{
		if (Room is null) return;

		base.OnMouseDown(sender, e);
	}

	protected override void OnMouseUp(object sender, MouseEventArgs e)
	{
		if (Room is null) return;

		if (!Selecting)
		{
			foreach (var o in Room.SelectedObjects)
			{
				if (o is IFreelyPlaceable f)
				{
					f.LockPosition();
				}
			}
		}

		base.OnMouseUp(sender, e);

		Selecting = false;
	}

	private void InvalidateRoomTilemapAndArtist()
	{
		if (Room is null) return;

		Room.Redrawing |= CurrentMode switch
		{
			DungeonEditMode.Layer1 => NeedsNewArt.UpdatedAllTilemaps,
			DungeonEditMode.Layer2 => NeedsNewArt.UpdatedAllTilemaps,
			DungeonEditMode.LayerAll => NeedsNewArt.UpdatedAllTilemaps,
			DungeonEditMode.Sprites => NeedsNewArt.UpdatedSpritesLayer,
			DungeonEditMode.Secrets => NeedsNewArt.UpdatedSpritesLayer,
			DungeonEditMode.Entrances => NeedsNewArt.Nothing,
			_ => NeedsNewArt.UpdatedAllTilemaps
		};

		RoomEditingArtist.Invalidate();
	}

	protected override void OnMouseMove(object sender, MouseEventArgs e)
	{
		if (MouseIsDown && !Selecting)
		{
			if (MouseX != LastX || MouseY != LastY)
			{
				MoveSelectedObjects();
			}
		}
		base.OnMouseMove(sender, e);
	}

	public void clearCustomCollisionMap()
	{
		Room?.ClearCollisionLayout();
	}

	public void getObjectsRectangle()
	{
		throw new NotImplementedException();
	}

	public override void Undo()
	{
		Room?.Undo();
	}

	public override void Redo()
	{
		Room?.Redo();
	}

	private void SceneUW_Paint(object sender, PaintEventArgs e)
	{
		Graphics g = e.Graphics;

		if (Room is null)
		{
			g.Clear(BackColor);
			return;
		}

		RoomEditingArtist.DrawSelfToImage(g);

		// Draw BG2 outlines / annotations
		Action<RoomObject> invisibles = null;

		if (ZGUI.ShowBG2Outline)
		{
			invisibles += o =>
			{
				if (o.ObjectType.Specialness == ObjectSpecialType.LayerMask)
				{
					g.DrawRectangle(Pens.DarkCyan, o.BoundingBox);
				}
			};
		}

		if (ZGUI.invisibleObjectsTextToolStripMenuItem.Checked)
		{
			invisibles += o =>
			{
				if (o.ObjectType.Specialness == ObjectSpecialType.LayerMask)
				{
					g.DrawText(o.RealX, o.RealY, "BG2 mask");
				}
			};
		}

		if (invisibles is not null)
		{
			Room.ForAllRoomObjects(invisibles);
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
				g.DrawText(d.RealX + 12, d.RealY + 4, id.ToString());

				if (d.DoorType.IsExit)
				{
					g.DrawText(d.RealX + 6, d.RealY + 13, "Exit");
				}
				else if (d.DoorType.Category == DoorCategory.LayerSwap)
				{
					g.DrawText(d.RealX - 8, d.RealY + 13, "Layer swap");
				}
				else if (d.DoorType.Category == DoorCategory.DungeonSwap)
				{
					g.DrawText(d.RealX - 13, d.RealY + 13, "Dungeon swap");
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
				g.DrawText(s.RealX, s.RealY + 13, s.ToString());
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
		if (ZGUI.entrancePositionToolStripMenuItem.Checked && ZGUI.DungeonEditor.selectedEntrance is UnderworldEntrance enn)
		{
			if (enn.RoomID == Room.RoomID)
			{
				g.DrawRectangle(Pens.Orange, enn.CameraTriggerX - 128, enn.CameraTriggerY - 116, 256, 224);
				int xx = enn.XPosition & 0x1FF;
				int yy = enn.YPosition & 0x1FF;
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
			foreach (var d in DungeonDoorPosition.ListOf)
			{
				g.DrawRectangle(Pens.Red, d.BoundingBox);
			}

			foreach (var d in Room.DoorsList)
			{
				g.DrawRectangle(Pens.Yellow, d.BoundingBox);

				if (d.DoorType.Category == DoorCategory.Meta) continue;

				var od = d.Position.Partner;
				if (od is not null)
				{
					g.DrawRectangle(Pens.GreenYellow, od.BoundingBox);
				}
			}
		}
		else if (CurrentMode == DungeonEditMode.CollisionMap)
		{
			DrawCustomCollision(g);
		}

		// Draw selected objects
		Pen selectionColor = MouseIsDown ? Pens.Yellow : Pens.GhostWhite;
		foreach (var o in Room.SelectedObjects)
		{
			g.DrawRectangle(selectionColor, o.BoundingBox);
		}

		if (hoveredEntity is not null)
		{
			g.DrawRectangle(Pens.Aqua, hoveredEntity.BoundingBox);
		}

		if (Selecting)
		{
			g.DrawRectangle(Pens.CornflowerBlue, GetSelectionRectangle());
		}

	} // End Paint();


	private void ResetPlacementProperties()
	{
		ObjectToPlace = null;
	}

	// TODO
	private bool CheckIfObjectIsInvalidForPlacement()
	{
		ZeldaException spaghetti = (ObjectToPlace, ZS.CurrentUWMode) switch
		{
			(DungeonSprite, not DungeonEditMode.Sprites)
				=> new ZeldaException("Sprites can only be placed while working in sprite mode."),

			(RoomObject, not (DungeonEditMode.Layer1 or DungeonEditMode.Layer2 or DungeonEditMode.Layer3))
				=> new ZeldaException("Objects can only be placed while working on backgrounds 1, 2, or 3."),

			(LightableTorch, not DungeonEditMode.Torches)
				=> new ZeldaException("TORCHES"),

			(PushableBlock, not DungeonEditMode.Blocks)
				=> new ZeldaException("BLOCKS"),

			_ => null
		};

		if (spaghetti is not null)
		{
			MouseIsDown = false;
			ObjectToPlace = null;
			throw spaghetti;
		}

		return true;
	}
}
