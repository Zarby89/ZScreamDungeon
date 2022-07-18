namespace ZeldaFullEditor.UserInterface.UIControl.Scene;

public partial class SceneOW
{
	private OverworldSecret lastsecret;

	public OverworldSecret SelectedSecret { get; set; }
	public OverworldSecret LastSelectedSecret {
		get => lastsecret;
		set
		{
			if (lastsecret == value) return;

			lastsecret = value;
			ZGUI.UpdateFormForSelectedObject(lastsecret);
		}
	}

	private void OnMouseDown_Secrets(MouseEventArgs e)
	{
		foreach (var item in ZS.OverworldManager.allitems)
		{
			if (item.IsInThisWorld(ZS.OverworldManager.World) && item.MouseIsInHitbox(e))
			{
				SelectedSecret = item;
				LastSelectedSecret = item;
				SecretItemType.GetTypeFromID(item.ID);
				break;
				//scene.mainForm.owcombobox.SelectedIndex = nid;
				//scene.mainForm.itemOWGroupbox.Visible = true;
			}
		}
	}

	private void Copy_Secrets()
	{
		Clipboard.Clear();
		var id = LastSelectedSecret.Clone();
		Clipboard.SetData(Constants.OverworldItemClipboardData, id);
	}

	private void Paste_Secrets()
	{
		var data = (OverworldSecret) Clipboard.GetData(Constants.OverworldItemClipboardData);
		if (data != null)
		{
			ZS.OverworldManager.allitems.Add(data);
			LastSelectedSecret = SelectedSecret = data;
			IsLeftPress = true;
			MouseIsDown = true;
		}
	}

	private void OnMouseUp_Secrets(MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			if (SelectedSecret != null)
			{
				SelectedSecret.MapID = ZS.OverworldManager.allmaps[hoveredMap + ZS.OverworldManager.WorldOffset].ParentMapID;
				LastSelectedSecret = SelectedSecret;
				SelectedSecret = null;
			}
			else
			{
				LastSelectedSecret = null;
				//scene.mainForm.itemOWGroupbox.Visible = false;
			}
		}
		else if (e.Button == MouseButtons.Right)
		{
			ContextMenuStrip menu = new ContextMenuStrip();
			menu.Items.Add("Add Item");
			menu.Items.Add("Delete Item");

			if (LastSelectedSecret == null)
			{
				menu.Items[1].Enabled = false;
			}

			menu.Items[0].Click += addItem_Click;
			menu.Items[1].Click += deleteItem_Click;
			menu.Show(Cursor.Position);
		}

		ZGUI.OverworldEditor.objectGroupbox.Text = "Selected secret";

		if (LastSelectedSecret != null)
		{
			ZGUI.OverworldEditor.SetSelectedObjectLabels(
				LastSelectedSecret.ID,
				LastSelectedSecret.MapX,
				LastSelectedSecret.MapY);

			ZGUI.OverworldEditor.objCombobox.DataSource = SecretsName.ListOfVanillaNames;

			// TODO
			//ZGUI.OverworldEditor.objCombobox.SelectedItem = 

			ZGUI.OverworldEditor.objCombobox.SelectedIndexChanged += ObjCombobox_SelectedIndexChangedItem;
		}
	}

	private void deleteItem_Click(object sender, EventArgs e)
	{
		Delete_Secrets();
	}

	private void addItem_Click(object sender, EventArgs e)
	{
		var pitem = new OverworldSecret(null);
		ZS.OverworldManager.allitems.Add(pitem);
		SelectedSecret = pitem;
		LastSelectedSecret = SelectedSecret;
		IsLeftPress = true;
		MouseIsDown = true;
	}

	private void OnMouseMove_Secrets(MouseEventArgs e)
	{
		if (!MouseIsDown)
		{
			FindHoveredEntity(ZS.OverworldManager.allitems, e);
			return;
		}

		if (SelectedSecret != null && IsLeftPress)
		{
			SelectedSecret.GlobalX = (ushort) e.X;
			SelectedSecret.GlobalY = (ushort) e.Y;
			SelectedSecret.SnapToGrid();
		}
	}

	private void Delete_Secrets()
	{
		if (LastSelectedSecret != null)
		{
			ZS.OverworldManager.allitems.Remove(LastSelectedSecret);
			LastSelectedSecret = null;
		}
	}

	public void DrawSecrets(Graphics g)
	{
		Brush bgrBrush;
		Pen outline;
		g.CompositingMode = CompositingMode.SourceOver;
		foreach (var item in ZS.OverworldManager.allitems)
		{
			if (lowEndMode && item.MapID != CurrentParentMapID)
			{
				continue;
			}

			if (item.IsInThisWorld(ZS.OverworldManager.World))
			{
				string txt;
				if (SelectedSecret == item)
				{
					bgrBrush = UIColors.SecretSelectedBrush;
					outline = UIColors.OutlineSelectedPen;
				}
				else if (hoveredEntity == item)
				{
					bgrBrush = UIColors.SecretBrush;
					outline = UIColors.OutlineHoverPen;
				}
				else
				{
					bgrBrush = UIColors.SecretBrush;
					outline = UIColors.OutlinePen;
				}

				switch (SecretsTextView)
				{
					case TextView.NeverShowName:
						txt = $"{item.ID:X2}";
						break;

					case TextView.AlwaysShowName:
					case TextView.ShowNameOnHover when item == SelectedSecret || item == hoveredEntity:
						txt = $"{item.ID:X2} - {item.Name}";
						break;

					default:
					case TextView.ShowNameOnHover:
						goto case TextView.NeverShowName;
				}

				g.DrawFilledRectangleWithOutline(item.BoundingBox, outline, bgrBrush);

				g.DrawText(item.GlobalX + 3, item.GlobalY + 5, txt);
			}
		}
	}
}
