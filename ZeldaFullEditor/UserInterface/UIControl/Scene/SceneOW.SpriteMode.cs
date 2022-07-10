namespace ZeldaFullEditor.UserInterface.UIControl.Scene;

public partial class SceneOW
{
	private const string NotInTheRain = "Can't add sprites to Dark World in rain state!";

	private OverworldSprite selectedSprite;
	private OverworldSprite lastselectedSprite;


	AddSprite addspr = new();

	private void OnMouseDown_Sprites(MouseEventArgs e)
	{
		for (int i = ZS.OverworldManager.WorldOffset; i < ZS.OverworldManager.WorldOffsetEnd; i++)
		{
			if (i > 159)
			{
				break;
			}

			foreach (var spr in ZS.OverworldManager.CurrentStateSprites) // TODO : Check if that need to be changed to LINQ mapid == maphover
			{
				if (spr.MouseIsInHitbox(e))
				{
					selectedSprite = spr;
					return;
				}
			}
		}
	}

	private void Copy_Sprites()
	{
		Clipboard.Clear();
		int sd = lastselectedSprite.ID;
		Clipboard.SetData(Constants.OverworldSpriteClipboardData, sd);
	}

	private void Paste_Sprites()
	{
		int data = (int) Clipboard.GetData(Constants.OverworldSpriteClipboardData);

		if (data != -1)
		{
			selectedFormSprite = new(SpriteType.Sprite00)
			{
				MapID = ZS.OverworldManager.allmaps[hoveredMap + ZS.OverworldManager.WorldOffset].ParentMapID
			}; // TODO

			if (selectedFormSprite.MapID >= 64 && ZS.OverworldManager.ActiveGameState < GameState.RescueState)
			{
				throw new ZeldaException(NotInTheRain);
			}

			ZS.OverworldManager.CurrentStateSprites.Add(selectedFormSprite);
			selectedSprite = selectedFormSprite;
			selectedFormSprite = null;
			MouseIsDown = true;
			IsLeftPress = true;
		}
	}

	// TODO make "TryToAddSprite" method
	private void OnMouseUp_Sprites(MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			byte mid = ZS.OverworldManager.allmaps[hoveredMap + ZS.OverworldManager.WorldOffset].ParentMapID;

			if (selectedFormSprite != null)
			{
				selectedFormSprite.MapID = mid;

				if (mid >= 64 && ZS.OverworldManager.ActiveGameState < GameState.RescueState)
				{
						throw new ZeldaException(NotInTheRain);
				}

				ZS.OverworldManager.CurrentStateSprites.Add(selectedFormSprite);
				selectedFormSprite = null;
			}
			if (selectedSprite != null)
			{
				selectedSprite.MapID = mid;
				lastselectedSprite = selectedSprite;
				selectedSprite = null;
			}
			else
			{
				lastselectedSprite = null;
			}
		}
		else if (e.Button == MouseButtons.Right)
		{
			ContextMenuStrip menu = new ContextMenuStrip();
			menu.Items.Add("Add Sprite");
			menu.Items.Add("Sprite Properties");
			menu.Items.Add("Delete Sprite");

			if (lastselectedSprite == null)
			{
				menu.Items[1].Enabled = false;
				menu.Items[2].Enabled = false;
			}

			menu.Items[0].Click += addSprite_Click;
			menu.Items[1].Click += spriteProperties_Click;
			menu.Items[2].Click += deleteSprite_Click;
			menu.Show(Cursor.Position);
		}

		ZGUI.OverworldEditor.objectGroupbox.Text = "Selected sprite";

		if (lastselectedSprite != null)
		{
			ZGUI.OverworldEditor.SetSelectedObjectLabels(
				lastselectedSprite.ID,
				lastselectedSprite.MapX,
				lastselectedSprite.MapY);
			ZGUI.OverworldEditor.objCombobox.DataSource = SpriteName.ListOfSprites;
			ZGUI.OverworldEditor.objCombobox.SelectedIndex = lastselectedSprite.ID;

			ZGUI.OverworldEditor.objCombobox.SelectedIndexChanged += ObjCombobox_SelectedIndexChangedSprite;
		}
	}

	private void deleteSprite_Click(object sender, EventArgs e)
	{
		Delete_Sprites();
	}

	private void spriteProperties_Click(object sender, EventArgs e)
	{
		// Nothing for now
	}

	// TODO add sprite method
	private void addSprite_Click(object sender, EventArgs e)
	{
		if (addspr.ShowDialog() == DialogResult.OK)
		{
			byte data = (byte) addspr.spriteListBox.SelectedIndex;
			selectedFormSprite = new OverworldSprite(SpriteType.Sprite00)
			{
				GlobalX = (ushort) MouseX,
				GlobalY = (ushort) MouseY,
			}; // TODO
			byte mid = ZS.OverworldManager.allmaps[hoveredMap + ZS.OverworldManager.WorldOffset].ParentMapID;

			selectedFormSprite.MapID = mid;

			if (mid >= 64 && ZS.OverworldManager.ActiveGameState < GameState.RescueState)
			{
				throw new ZeldaException(NotInTheRain);
			}

			ZS.OverworldManager.CurrentStateSprites.Add(selectedFormSprite);
			selectedSprite = selectedFormSprite;
			selectedFormSprite = null;
			MouseIsDown = true;
			IsLeftPress = true;
		}
	}

	private void OnMouseMove_Sprites(MouseEventArgs e)
	{
		if (!MouseIsDown)
		{
			FindHoveredEntity(ZS.OverworldManager.CurrentStateSprites, e);
			return;
		}

		if (selectedFormSprite != null)
		{
			selectedFormSprite.GlobalX = (ushort) (e.X & ~0xF);
			selectedFormSprite.GlobalY = (ushort) (e.Y & ~0xF);
			selectedFormSprite.SnapToGrid();
		}

		if (IsLeftPress && selectedSprite != null)
		{
			selectedSprite.GlobalX = (ushort) e.X;
			selectedSprite.GlobalY = (ushort) e.Y;
			selectedSprite.SnapToGrid();
		}
	}

	private void Delete_Sprites()
	{
		if (lastselectedSprite == null) return;

		for (int i = ZS.OverworldManager.WorldOffset; i < ZS.OverworldManager.WorldOffsetEnd; i++)
		{
			ZS.OverworldManager.CurrentStateSprites.Remove(lastselectedSprite);
		}

		lastselectedSprite = null;
	}

	public void Draw_Sprites(Graphics g)
	{
		Brush bgrBrush;
		Pen outline;

		for (int i = 0; i < ZS.OverworldManager.CurrentStateSprites.Count; i++)
		{
			var spr = ZS.OverworldManager.CurrentStateSprites[i];

			if (lowEndMode && spr.MapID != CurrentParentMapID)
			{
				continue;
			}

			if (spr.IsInThisWorld(ZS.OverworldManager.World))
			{
				if (spr == selectedSprite)
				{
					bgrBrush = UIColors.SpriteSelectedBrush;
					outline = UIColors.OutlineSelectedPen;
				}
				else if (hoveredEntity == spr)
				{
					bgrBrush = UIColors.SpriteBrush;
					outline = UIColors.OutlineHoverPen;
				}
				else
				{
					bgrBrush = UIColors.SpriteBrush;
					outline = UIColors.OutlinePen;
				}

				string txt;
				switch (SpriteTextView)
				{
					case TextView.NeverShowName:
						txt = $"{spr.ID:X2}";
						break;

					case TextView.AlwaysShowName:
					case TextView.ShowNameOnHover when spr == selectedSprite || spr == hoveredEntity:
						txt = $"{spr.ID:X2} - {spr.Name}";
						break;

					default:
					case TextView.ShowNameOnHover:
						goto case TextView.NeverShowName;
				}

				g.DrawFilledRectangleWithOutline(spr.BoundingBox, outline, bgrBrush);
				g.DrawText(spr.GlobalX + 4, spr.GlobalY + 4, txt);
			}
		}
	}

	private void SelectAll_Sprites()
	{
		throw new NotImplementedException();
	}
}
