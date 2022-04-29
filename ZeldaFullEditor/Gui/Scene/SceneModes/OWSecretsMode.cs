using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Data;

namespace ZeldaFullEditor
{
	public partial class SceneOW
	{
		public OverworldSecret selectedItem;
		public OverworldSecret lastselectedItem;

		private void OnMouseDown_Secrets(MouseEventArgs e)
		{
			isLeftPress = e.Button == MouseButtons.Left;

			foreach (var item in ZS.OverworldManager.allitems)
			{
				if (item.IsInThisWorld(ZS.OverworldManager.WorldOffset) && item.MouseIsInHitbox(e))
				{
					selectedItem = item;
					lastselectedItem = item;
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
			var id = lastselectedItem.Clone();
			Clipboard.SetData(Constants.OverworldItemClipboardData, id);
		}

		private void Paste_Secrets()
		{
			var data = (OverworldSecret) Clipboard.GetData(Constants.OverworldItemClipboardData);
			if (data != null)
			{
				ZS.OverworldManager.allitems.Add(data);
				lastselectedItem = selectedItem = data;
				isLeftPress = true;
				MouseIsDown = true;
			}
		}

		private void OnMouseUp_Secrets(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (selectedItem != null)
				{
					byte mid = ZS.OverworldManager.allmaps[mapHover + ZS.OverworldManager.WorldOffset].parent;
					if (mid == 255)
					{
						mid = (byte) (mapHover + ZS.OverworldManager.WorldOffset);
					}
					selectedItem.MapID = mid;
					lastselectedItem = selectedItem;
					selectedItem = null;
				}
				else
				{
					lastselectedItem = null;
					//scene.mainForm.itemOWGroupbox.Visible = false;
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				ContextMenuStrip menu = new ContextMenuStrip();
				menu.Items.Add("Add Item");
				menu.Items.Add("Delete Item");

				if (lastselectedItem == null)
				{
					menu.Items[1].Enabled = false;
				}

				menu.Items[0].Click += addItem_Click;
				menu.Items[1].Click += deleteItem_Click;
				menu.Show(Cursor.Position);
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
			selectedItem = pitem;
			lastselectedItem = selectedItem;
			isLeftPress = true;
			MouseIsDown = true;
		}

		private void OnMouseMove_Secrets(MouseEventArgs e)
		{
			mouseX_Real = e.X;
			mouseY_Real = e.Y;

			mapHover = (e.X / 16 / 32) + (e.Y / 16 / 32 * 8);

			if (selectedItem != null && isLeftPress && MouseIsDown)
			{
				selectedItem.MapX = (byte) (e.X & ~0xF);
				selectedItem.MapY = (byte) (e.Y & ~0xF);
			}
		}

		private void Delete_Secrets()
		{
			if (lastselectedItem != null)
			{
				ZS.OverworldManager.allitems.Remove(lastselectedItem);
				lastselectedItem = null;
			}
		}

		public void Draw_Secrets(Graphics g)
		{
			Brush bgrBrush;
			g.CompositingMode = CompositingMode.SourceOver;
			foreach (var item in ZS.OverworldManager.allitems)
			{
				if (lowEndMode && item.MapID != ZS.OverworldManager.allmaps[CurrentMap].parent)
				{
					continue;
				}

				if (item.IsInThisWorld(ZS.OverworldManager.WorldOffset))
				{
					bgrBrush = (selectedItem == item) ? Constants.Turquoise200Brush : Constants.Scarlet200Brush;

					g.DrawFilledRectangleWithOutline(item.SquareHitbox, Constants.Black200Pen, bgrBrush);

					drawText(g, item.GlobalX - 1, item.GlobalY + 1, item.Name);
				}
			}

			g.CompositingMode = CompositingMode.SourceCopy;
		}
	}
}
