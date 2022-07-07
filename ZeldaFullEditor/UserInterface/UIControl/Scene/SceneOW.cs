namespace ZeldaFullEditor.UserInterface.UIControl.Scene;

public partial class SceneOW : Scene
{
	//public IntPtr allgfx8array = Marshal.AllocHGlobal(32768);

	//int selectedIndex = 0;
	public int CurrentMapID {
		get => CurrentMap.MapID;
		set => CurrentMap = ZScreamer.ActiveOW.allmaps[value];
	}

	public OverworldScreen CurrentMap { get; set; }
	public OverworldScreen CurrentParentMap => CurrentMap.ParentMap;
	public int CurrentParentMapID => CurrentMap.ParentMapID;
	public int CurrentParentVirtualMapID => CurrentMap.ParentMap.VirtualMapID;

	//public int lockedMap = -1;
	//must load all current map gfx
	public ushort[] selectedTile = new ushort[] { 0 };
	public int selectedTileSizeX = 1;
	private int globalmouseTileDownX = 0;
	private int globalmouseTileDownY = 0;
	private int localTileDownX => globalmouseTileDownX / Constants.NumberOfTile16PerStrip;
	private int localTileDownY => globalmouseTileDownY / Constants.NumberOfTile16PerStrip;
	public int lastTileHoverX = 0;
	public int lastTileHoverY = 0;
	public int lastHover = -1;
	public bool selecting = false;
	public IntPtr overlaygfxPtr = Marshal.AllocHGlobal(1024 * 1024);
	public IntPtr temptilesgfxPtr = Marshal.AllocHGlobal(1024 * 1024);
	public Bitmap tilesgfxBitmap;
	public Bitmap tileBitmap;
	public IntPtr tileBitmapPtr;
	public OverworldSprite selectedFormSprite;


	private int hoveredMap = 0;
	private OverworldEntity hoveredEntity = null;
	private bool snapToGrid = false;

	private readonly ModeActions tilemode;
	private readonly ModeActions exitmode;
	private readonly ModeActions doorMode;
	private readonly ModeActions entranceMode;
	private readonly ModeActions spriteMode;
	private readonly ModeActions itemMode;
	private readonly ModeActions transportMode;
	private readonly ModeActions overlayMode;
	private readonly ModeActions gravestoneMode;


	public TextView SpriteTextView { get; set; } = TextView.ShowNameOnHover;
	public TextView SecretsTextView { get; set; } = TextView.ShowNameOnHover;
	public TextView EntranceTextView { get; set; } = TextView.ShowNameOnHover;
	public TextView ExitTextView { get; set; } = TextView.ShowNameOnHover;
	public TextView TransportTextView { get; set; } = TextView.ShowNameOnHover;

	private bool entrancePreview = false;

	public bool lowEndMode = false;
	public bool HasUnsavedChanges { get; private set; }

	public SceneOW(ZScreamer zs) : base(zs)
	{

		Size = Constants.FullOverworldSize;

		//graphics = Graphics.FromImage(scene_bitmap);
		//this.Image = new Bitmap(4096, 4096);
		tilesgfxBitmap = new Bitmap(512, 512, 512, PixelFormat.Format8bppIndexed, temptilesgfxPtr);


		tilemode = new ModeActions(OnMouseDown_Tiles, OnMouseUp_Tiles, OnMouseMove_Tiles, null,
			Copy_Tiles, Paste_Tiles, null, Delete_Tiles, null);

		exitmode = new ModeActions(OnMouseDown_Exit, OnMouseUp_Exit, OnMouseMove_Exit, null,
			null, null, null, Delete_Exit, null);

		doorMode = new ModeActions(OnMouseDown_OWDoor, OnMouseUp_OWDoor, OnMouseMove_OWDoor, null,
			null, null, null, Delete_OWDoor, SelectAll_OWDoor);

		entranceMode = new ModeActions(OnMouseDown_Entrance, OnMouseUp_Entrance, OnMouseMove_Entrance, null,
			null, null, null, Delete_Entrance, null);

		spriteMode = new ModeActions(OnMouseDown_Sprites, OnMouseUp_Sprites, OnMouseMove_Sprites, null,
			Copy_Sprites, Paste_Sprites, null, Delete_Sprites, SelectAll_Sprites);

		itemMode = new ModeActions(OnMouseDown_Secrets, OnMouseUp_Secrets, OnMouseMove_Secrets, null,
			Copy_Secrets, Paste_Secrets, null, Delete_Secrets, null);

		transportMode = new ModeActions(OnMouseDown_Transports, OnMouseUp_Transports, OnMouseMove_Transports, null,
			null, null, null, null, null);

		overlayMode = new ModeActions(OnMouseDown_Overlay, OnMouseUp_Overlay, OnMouseMove_Overlay, null,
			Copy_Overlay, Paste_Overlay, null, Delete_Overlay, null);

		gravestoneMode = new ModeActions(OnMouseDown_Graves, OnMouseUp_Graves, OnMouseMove_Graves, null,
			null, null, null, Delete_Graves, null);

		//this.Width = 8192;
		//this.Height = 8192;
		//this.Size = new Size(8192, 8192);
		//this.Refresh();
	}

	public void UpdateForMode(OverworldEditMode e)
	{
		ActiveMode = e switch
		{
			OverworldEditMode.Tile16 => tilemode,
			OverworldEditMode.Tile16Fill => tilemode,
			OverworldEditMode.Sprites => spriteMode,
			OverworldEditMode.Secrets => itemMode,
			OverworldEditMode.Entrances => entranceMode,
			OverworldEditMode.Exits => exitmode,
			OverworldEditMode.Transports => transportMode,
			OverworldEditMode.Overlay => overlayMode,
			OverworldEditMode.Gravestones => gravestoneMode,
			OverworldEditMode.Doors => doorMode,
			_ => ModeActions.Nothing
		};
	}


	public void CreateScene()
	{
		//tileBitmapPtr = ZS.OverworldManager.allmaps[0].blockset16;
		//tileBitmap = new Bitmap(128, 8192, 128, PixelFormat.Format8bppIndexed, tileBitmapPtr);
	}

	protected override void OnMouseWheel(object sender, MouseEventArgs e)
	{
		((HandledMouseEventArgs) e).Handled = true;
		int xPos = ZGUI.OverworldEditor.splitContainer1.Panel2.HorizontalScroll.Value;
		int yPos = ZGUI.OverworldEditor.splitContainer1.Panel2.VerticalScroll.Value;

		if (ModifierKeys == Keys.Shift)
		{
			e.ScrollByValue(ref xPos, -48);
		}
		else
		{
			e.ScrollByValue(ref yPos, -48);
		}

		ZGUI.OverworldEditor.splitContainer1.Panel2.AutoScrollPosition = new Point(xPos, yPos);
		//e.Delta
		//base.OnMouseWheel(sender, e);
	}

	public void updateMapGfx()
	{
		if (CurrentMapID <= 159)
		{
			ZGUI.OverworldEditor.propertiesChangedFromForm = true;

			ZGUI.OverworldEditor.mapGroupbox.Text = $"Selected map: {CurrentParentMapID:X2}";

			ZGUI.OverworldEditor.OWProperty_MessageID.HexValue = CurrentMap.MessageID;

			ZGUI.OverworldEditor.UpdateGUIProperties(CurrentParentMap, ZS.OverworldManager.WorldOffset >= 64 ? 0 : ZS.OverworldManager.ActiveGameState);

			ZGUI.OverworldEditor.propertiesChangedFromForm = false;
			ZGUI.OverworldEditor.tilePictureBox.Refresh();

			ZGUI.OverworldEditor.areaBGColorPictureBox.Refresh();
		}

		ZS.OverworldManager.Tile16Sheet.UpdateToMatchScreen(CurrentParentMap);
		ZGUI.OverworldEditor.BuildScratchTilesGfx();
		ZGUI.OverworldEditor.scratchPicturebox.Refresh();
	}

	protected override void OnMouseDown(MouseEventArgs e)
	{
		int tileX = e.X / 16;
		int tileY = e.Y / 16;
		int mapId = (tileY / 32 * 8) + (tileX / 32);

		if (mapId < ZS.OverworldManager.allmaps.Length)
		{
			globalmouseTileDownX = tileX;
			globalmouseTileDownY = tileY;

			HasUnsavedChanges = true;
			CurrentMapID = mapId + ZS.OverworldManager.WorldOffset;

			ZGUI.OverworldEditor.previewTextPicturebox.Visible = false;
			updateMapGfx();
			ZGUI.OverworldEditor.updateTiles();

			base.OnMouseDown(e);

			//InvalidateScreens();
		}
		else
		{
			throw new ZeldaException("Invalid area selected!");
		}
	}

	private void FindHoveredEntity<T>(IEnumerable<T> list, MouseEventArgs e) where T : OverworldEntity
	{
		foreach (var o in list)
		{
			if (o.IsInThisWorld(ZS.OverworldManager.World) && o.MouseIsInHitbox(e))
			{
				hoveredEntity = o;
				Cursor = Cursors.Hand;
				return;
			}
		}
		hoveredEntity = null;
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		hoveredEntity = null;
		Cursor = Cursors.Default;
		snapToGrid = ModifierKeys != Keys.Control;
		hoveredMap = (e.X / 16 / 32) + (e.Y / 16 / 32 * 8);
		base.OnMouseMove(e);
	}

	protected override void OnMouseUp(object sender, MouseEventArgs e)
	{
		selecting = false;

		ZGUI.OverworldEditor.objCombobox.SelectedIndexChanged -= ObjCombobox_SelectedIndexChangedSprite;
		ZGUI.OverworldEditor.objCombobox.SelectedIndexChanged -= ObjCombobox_SelectedIndexChangedItem;

		base.OnMouseUp(sender, e);

		//InvalidateScreens();
	}


	private void ObjCombobox_SelectedIndexChangedSprite(object sender, EventArgs e)
	{
		byte id = (byte) (ZGUI.OverworldEditor.objCombobox.SelectedItem as SpriteName).ID;
		lastselectedSprite.Species = SpriteType.GetTypeFromID(id);

		//InvalidateScreens();
	}

	private void InvalidateScreens()
	{
		ZS.OverworldManager.ForAllMainScreens(map =>
		{
			if (map.ParentMap == CurrentParentMap)
			{
				map.InvalidateArt();
			}
		});
	}

	private void ObjCombobox_SelectedIndexChangedItem(object sender, EventArgs e)
	{
		byte id = (byte) (ZGUI.OverworldEditor.objCombobox.SelectedItem as SecretsName).ID;
		LastSelectedSecret.SecretType = SecretItemType.GetTypeFromID(id);
		//InvalidateScreens();
	}

	protected override void OnMouseMove(object sender, MouseEventArgs e)
	{
		base.OnMouseMove(sender, e);
	}

	public override void Undo()
	{
		if (undoList.Count > 0)
		{
			undoList[^1].Restore(ZS.OverworldManager);
			TileUndo tundo = (TileUndo) undoList[^1].Clone();
			tundo.usedTiles = undoList[^1].usedTiles;
			redoList.Add(tundo);
			undoList.RemoveAt(undoList.Count - 1);
		}

		Refresh();
	}

	public override void Redo()
	{
		if (redoList.Count > 0)
		{
			redoList[^1].RestoreRedo(ZS.OverworldManager);
			TileUndo tundo = (TileUndo) redoList[^1].Clone();
			tundo.usedTiles = redoList[^1].usedTiles;
			undoList.Add(tundo);
			redoList.RemoveAt(redoList.Count - 1);
		}

		Refresh();
	}

	/// <summary>
	/// Creates a map32 tile map and saves the overworld tiles in the rom. 
	/// </summary>
	public void SaveTiles()
	{
		ZS.OverworldManager.SaveTile32DefinitionsToROM();
		ZS.OverworldManager.SaveTile16DefinitionsToROM();
	}

	private void MoveDestinationToMouse(OverworldDestination dest, MouseEventArgs e)
	{
		if (dest != null)
		{
			dest.MapID = ZS.OverworldManager.allmaps[hoveredMap + ZS.OverworldManager.WorldOffset].ParentMapID;

			dest.GlobalX = (ushort) e.X;
			dest.GlobalY = (ushort) e.Y;

			if (snapToGrid)
			{
				dest.SnapToGrid();
			}

			dest.UpdateMapProperties(ZS.OverworldManager.allmaps[dest.MapID].IsPartOfLargeMap);
		}
	}


	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);

		Graphics g = e.Graphics;

		ColorMatrix cm = new ColorMatrix();
		ImageAttributes ia = new ImageAttributes();
		cm.Matrix33 = 0.50f;
		cm.Matrix22 = 2f;
		ia.SetColorMatrix(cm);
		g.CompositingMode = CompositingMode.SourceCopy;
		g.CompositingQuality = CompositingQuality.HighSpeed;
		g.InterpolationMode = InterpolationMode.NearestNeighbor;

		if (lowEndMode)
		{
			int x = CurrentParentMapID % 8;
			int y = CurrentParentMapID / 8;

			if (CurrentMap.IsPartOfLargeMap)
			{
				g.FillRectangle(new SolidBrush(ZS.PaletteManager.OverworldGrass[0]), new RectangleF(x * 512, y * 512, 1024, 1024));
				g.DrawImage(ZS.OverworldManager.allmaps[CurrentParentMapID].MyArtist.Layer1Canvas.Bitmap, new PointF(x * 512, y * 512));
				g.DrawImage(ZS.OverworldManager.allmaps[CurrentParentMapID + 1].MyArtist.Layer1Canvas.Bitmap, new PointF((x + 1) * 512, y * 512));
				g.DrawImage(ZS.OverworldManager.allmaps[CurrentParentMapID + 8].MyArtist.Layer1Canvas.Bitmap, new PointF(x * 512, (y + 1) * 512));
				g.DrawImage(ZS.OverworldManager.allmaps[CurrentParentMapID + 9].MyArtist.Layer1Canvas.Bitmap, new PointF((x + 1) * 512, (y + 1) * 512));
			}
			else
			{
				g.FillRectangle(new SolidBrush(ZS.PaletteManager.OverworldGrass[0]), new RectangleF(x * 512, y * 512, 512, 512));
				g.DrawImage(CurrentParentMap.MyArtist.Layer1Canvas.Bitmap, new PointF(x * 512, y * 512));
			}
		}
		else
		{
			// TODO make a single PointF and Rectangle variable to reuse
			int x = 0;
			int y = 0;
			g.CompositingMode = CompositingMode.SourceOver;
			for (int i = ZS.OverworldManager.WorldOffset; i < ZS.OverworldManager.WorldOffsetEnd; i++)
			{
				if (i > 159) continue;

				if (ZGUI.overworldOverlayVisibleToolStripMenuItem.Checked)
				{
					if (i is >= 0x03 and <= 0x07)
					{
						g.DrawImage(ZS.OverworldManager.allmaps[149].MyArtist.Layer1Canvas.Bitmap, new PointF(x, y));
					}
					else if (i is 91 or 92)
					{
						g.DrawImage(ZS.OverworldManager.allmaps[150].MyArtist.Layer1Canvas.Bitmap, new PointF(x, y));
					}
				}
				else
				{
					int grass = i switch {
						> 127 => 2,
						< 64 => 1,
						_ => 1,
					};
					g.DrawRectangle(new Pen(ZS.PaletteManager.OverworldGrass[grass]), new Rectangle(x, y, 512, 512));
				}
				ZS.OverworldManager.allmaps[i].MyArtist.DrawSelfToImage(g, new PointF(x, y));

				if (ZGUI.overworldOverlayVisibleToolStripMenuItem.Checked)
				{
					// TODO bad hardcoded
					//if (i == 0 || i == 1 || i == 8 || i == 9)
					//{
					//	g.CompositingMode = CompositingMode.SourceOver;
					//	g.DrawImage(ZS.OverworldManager.allmaps[157].gfxBitmap, new Rectangle(x, y, 512, 512), 0, 0, 512, 512, GraphicsUnit.Pixel, ia);
					//}
				}

				x += 512;
				if (x >= (8 * 512))
				{
					x = 0;
					y += 512;
				}

			}
		}

		if (selecting)
		{
			g.DrawRectangle(Pens.White, new Rectangle(globalmouseTileDownX * 16, globalmouseTileDownY * 16,
				(((MouseX / 16) - globalmouseTileDownX) * 16) + 16, (((MouseY / 16) - globalmouseTileDownY) * 16) + 16));
		}

		//if (ZS.CurrentOWMode == ObjectMode.OWDoor || ZS.CurrentOWMode == OverworldEditMode.Tile16)
		if (ZS.CurrentOWMode == OverworldEditMode.Tile16)
		{
			int wid = selectedTileSizeX * 16;
			int hei = selectedTile.Length / selectedTileSizeX * 16;
			Rectangle temp = new Rectangle(MouseX & ~0xF, MouseY & ~0x0F, wid, hei);
			g.DrawImage(tilesgfxBitmap, temp, 0, 0, wid, hei, GraphicsUnit.Pixel, ia);
			g.DrawRectangle(Pens.LightGreen, temp);
		}

		int offset = (CurrentMapID >= 128) ? 128 : 0;

		if ((hoveredMap + offset) < ZS.OverworldManager.allmaps.Length)
		{
			int my = (ZS.OverworldManager.allmaps[hoveredMap + offset].ParentMapID - offset) / 8;
			int mx = (ZS.OverworldManager.allmaps[hoveredMap + offset].ParentMapID - offset) - (my * 8);

			int rectumsize = ZS.OverworldManager.allmaps[hoveredMap + offset].IsPartOfLargeMap ? 1024 : 512;
			g.DrawRectangle(Pens.Orange, new Rectangle(mx * 512, my * 512, rectumsize, rectumsize));
		}

		if (ZGUI.showExits)
		{
			Draw_Exit(g);
		}

		if (ZGUI.showEntrances)
		{
			Draw_Entrance(g);
		}

		if (ZGUI.showItems)
		{
			Draw_Secrets(g);
		}

		Draw_Graves(g);


		if (ZGUI.showFlute)
		{
			Draw_Transports(g);
		}

		if (ZGUI.ShowSprites)
		{
			Draw_Sprites(g);
		}


		g.CompositingMode = CompositingMode.SourceCopy;

		if (entrancePreview)
		{
			OverworldEntity prev = (OverworldEntity)SelectedEntrance ?? SelectedExit;

			if (prev != null)
			{
				RoomPreviewArtist.DrawSelfToImageSmall(g, prev.GlobalX + 16, prev.GlobalY + 16);
			}
		}

		if (ZS.CurrentOWMode == OverworldEditMode.Overlay)
		{
			int mid = CurrentParentMapID;
			int msy = 512 * (CurrentParentVirtualMapID / 8);
			int msx = 512 * (CurrentParentVirtualMapID - (msy * 8));
		
			// TODO ugh wtf COPY	
			g.DrawText(0 + 4, 0 + 64, "Selected Map : " + CurrentMapID.ToString());
			g.DrawText(0 + 4, 0 + 80, "Selected Map PARENT : " + CurrentParentMapID.ToString());
			g.DrawText(msx + 4, msy + 4, "use ctrl key + click to delete overlay tiles");

			for (int i = 0; i < ZS.OverworldManager.alloverlays[mid].tilesData.Count; i++)
			{
				int xo = ZS.OverworldManager.alloverlays[mid].tilesData[i].MapX * 16;
				int yo = ZS.OverworldManager.alloverlays[mid].tilesData[i].MapY * 16;
				int to = ZS.OverworldManager.alloverlays[mid].tilesData[i].Tile16ID;
				int toy = (to / 8) * 16;
				int tox = (to % 8) * 16;
				g.DrawImage(ZScreamer.ActiveOW.Tile16Sheet.PreviewCanvas.Bitmap, new Rectangle(msx + xo, msy + yo, 16, 16), new Rectangle(tox, toy, 16, 16), GraphicsUnit.Pixel);
				//g.DrawImage(GFX.currentOWgfx16Bitmap, new Rectangle(0, 0, 64, 64), new Rectangle(0, 0, 64, 64), GraphicsUnit.Pixel);
				byte detect = CompareTilePos(ZS.OverworldManager.alloverlays[mid].tilesData[i], ZS.OverworldManager.alloverlays[mid].tilesData.ToArray());

				if (detect == 0)
				{
					g.DrawRectangle(Pens.White, new Rectangle(msx + xo, msy + yo, msx + 16, msy + 16));
				}
				if (!detect.BitIsOn(0x01))
				{
					g.DrawLine(Pens.White, msx + xo, msy + yo, msx + xo, msy + yo + 16);
				}
				if (!detect.BitIsOn(0x02))
				{
					g.DrawLine(Pens.White, msx + xo, msy + yo, msx + xo + 16, msy + yo);
				}
				if (!detect.BitIsOn(0x04))
				{
					g.DrawLine(Pens.White, msx + xo + 16, msy + yo, msx + xo + 16, msy + yo + 16);
				}
				if (!detect.BitIsOn(0x08))
				{
					g.DrawLine(Pens.White, msx + xo, msy + yo + 16, msx + xo + 16, msy + yo + 16);
				}
			}

			var temp = new Rectangle(MouseX & ~0xF, MouseY & ~0x0F, selectedTileSizeX * 16, selectedTile.Length / selectedTileSizeX * 16);
			g.DrawImage(tilesgfxBitmap, temp, 0, 0, selectedTileSizeX * 16, (selectedTile.Length / selectedTileSizeX) * 16, GraphicsUnit.Pixel, ia);
			g.DrawRectangle(Pens.LightGreen, temp);

			g.DrawText(4, 24, globalmouseTileDownX.ToString());
			g.DrawText(4, 48, globalmouseTileDownY.ToString());
		}

		if (ZGUI.OverworldEditor.gridDisplay != 0)
		{
			int gridsize = CurrentMap.IsPartOfLargeMap ? 1024 : 512;

			int x = 512 * (CurrentParentMapID % 8);
			int y = 512 * (CurrentParentMapID / 8);

			for (int gx = 0; gx < (gridsize / ZGUI.OverworldEditor.gridDisplay); gx++)
			{
				g.DrawLine(Constants.ThirdWhitePen1,
					new Point(x + gx * ZGUI.OverworldEditor.gridDisplay, y),
					new Point(x + gx * ZGUI.OverworldEditor.gridDisplay, y + gridsize));
			}

			for (int gy = 0; gy < (gridsize / ZGUI.OverworldEditor.gridDisplay); gy++)
			{
				g.DrawLine(Constants.ThirdWhitePen1,
					new Point(x, y + (gy * ZGUI.OverworldEditor.gridDisplay)),
					new Point(x + gridsize, y + (gy * ZGUI.OverworldEditor.gridDisplay)));
			}
		}

		g.CompositingMode = CompositingMode.SourceCopy;
		//hideText = false;

	}

	// 0 = none
	// 1 = left
	// 2 = up
	// 4 = right
	// 8 = bottom

	private static byte CompareTilePos(OverlayTile tpc, OverlayTile[] tpa)
	{
		byte detected = 0;
		foreach (OverlayTile t in tpa)
		{
			if (t.MapX == tpc.MapX - 1 && t.MapY == tpc.MapY)
			{
				detected |= 0x01;
			}
			else if (t.MapX == tpc.MapX + 1 && t.MapY == tpc.MapY)
			{
				detected |= 0x04;
			}
			else if (t.MapX == tpc.MapX && t.MapY == tpc.MapY - 1)
			{
				detected |= 0x02;
			}
			else if (t.MapX == tpc.MapX && t.MapY == tpc.MapY + 1)
			{
				detected |= 0x08;
			}
			else if (t.MapX == tpc.MapX && t.MapY == tpc.MapY)
			{
				detected |= 0x80;
			}
		}

		return detected;
	}

	private static OverlayTile CompareTilePosButZarbyGaveThisADumbName(OverlayTile tpc, OverlayTile[] tpa)
	{
		foreach (OverlayTile t in tpa)
		{
			if (t.MapX == tpc.MapX && t.MapY == tpc.MapY)
			{
				return t;
			}
		}
		return OverlayTile.GarbageTile;
	}

	public override void Refresh()
	{
		if (!CanIRefresh()) return;
		//InvalidateScreens();
		base.Refresh();
	}
}
