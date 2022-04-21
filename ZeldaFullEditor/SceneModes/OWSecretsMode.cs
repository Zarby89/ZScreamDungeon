using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Data;
using ZeldaFullEditor.Data.DungeonObjects;

namespace ZeldaFullEditor.SceneModes
{
	public class OWSecretsMode : SceneMode
	{
		public OverworldSecret selectedItem;
		public OverworldSecret lastselectedItem;
		public bool isLeftPress = false;
		public OWSecretsMode(ZScreamer zs) : base(zs)
		{

		}

		public override void OnMouseWheel(MouseEventArgs e)
		{

		}

		public override void OnMouseDown(MouseEventArgs e)
		{
			isLeftPress = e.Button == MouseButtons.Left;

			foreach (var item in ZS.OverworldManager.allitems)
			{
				if (item.MapID >= 0 + (ZS.OverworldManager.worldOffset) && item.MapID < (64 + ZS.OverworldManager.worldOffset))
				{
					if (e.X >= item.X && e.X <= item.X + 16 && e.Y >= item.Y && e.Y <= item.Y + 16)
					{
						selectedItem = item;
						lastselectedItem = item;
						byte nid = item.ID;
						SecretItemType.FindSecretFromID(item.ID);

						//scene.mainForm.owcombobox.SelectedIndex = nid;
						//scene.mainForm.itemOWGroupbox.Visible = true;
					}
				}
			}

			ZS.OverworldScene.mouse_down = true;
		}

		public override void Copy()
		{
			Clipboard.Clear();
			var id = lastselectedItem.Clone();
			Clipboard.SetData(Constants.OverworldItemClipboardData, id);
		}

		public override void Cut()
		{
			Clipboard.Clear();
			var id = lastselectedItem.Clone();
			Clipboard.SetData(Constants.OverworldItemClipboardData, id);
			Delete();

			//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
		}

		public override void Paste()
		{
			var data = (OverworldSecret) Clipboard.GetData(Constants.OverworldItemClipboardData);
			if (data != null)
			{
				ZS.OverworldManager.allitems.Add(data);
				lastselectedItem = selectedItem = data;
				isLeftPress = true;
				ZS.OverworldScene.mouse_down = true;

				//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
			}
		}

		public override void OnMouseUp(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (selectedItem != null)
				{
					byte mid = ZS.OverworldManager.allmaps[ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset].parent;
					if (mid == 255)
					{
						mid = (byte) (ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset);
					}
					selectedItem.UpdateMapID(mid);
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

			ZS.OverworldScene.mouse_down = false;
		}

		private void deleteItem_Click(object sender, EventArgs e)
		{
			Delete();
		}

		private void addItem_Click(object sender, EventArgs e)
		{
			var pitem = new OverworldSecret(null);
			ZS.OverworldManager.allitems.Add(pitem);
			selectedItem = pitem;
			lastselectedItem = selectedItem;
			isLeftPress = true;
			ZS.OverworldScene.mouse_down = true;

			//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
		}

		public override void OnMouseMove(MouseEventArgs e)
		{
			ZS.OverworldScene.mouseX_Real = e.X;
			ZS.OverworldScene.mouseY_Real = e.Y;

			ZS.OverworldScene.mapHover = (e.X / 16 / 32) + (e.Y / 16 / 32 * 8);

			if (selectedItem != null)
			{
				if (isLeftPress)
				{
					if (ZS.OverworldScene.mouse_down)
					{
						selectedItem.X = (byte) (e.X & ~0xF);
						selectedItem.Y = (byte) (e.Y & ~0xF);

						// scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));

					}
				}
			}
		}

		public override void Delete()
		{
			if (lastselectedItem != null)
			{
				ZS.OverworldManager.allitems.Remove(lastselectedItem);
				lastselectedItem = null;

				//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
				//scene.mainForm.itemOWGroupbox.Visible = false;
			}
		}

		public void Draw(Graphics g)
		{
			Brush bgrBrush;
			g.CompositingMode = CompositingMode.SourceOver;
			foreach (var item in ZS.OverworldManager.allitems)
			{
				if (ZS.OverworldScene.lowEndMode && item.MapID != ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent)
				{
					continue;
				}

				if (item.MapID >= (0 + ZS.OverworldManager.worldOffset) && item.MapID < (64 + ZS.OverworldManager.worldOffset))
				{

					bgrBrush = (selectedItem == item) ? Constants.Turquoise200Brush : Constants.Scarlet200Brush;

					g.DrawFilledRectangleWithOutline(item.MapX, item.MapY, 16, 16, Constants.Black200Pen, bgrBrush);

					ZS.OverworldScene.drawText(g, item.X - 1, item.Y + 1, item.Name);
				}
			}

			g.CompositingMode = CompositingMode.SourceCopy;
		}

		public override void SelectAll()
		{
			throw new NotImplementedException();
		}
	}
}
