using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.OWSceneModes
{
	public class ItemMode : SceneMode
	{
		public RoomPotSaveEditor selectedItem;
		public RoomPotSaveEditor lastselectedItem;
		public bool isLeftPress = false;
		public ItemMode(ZScreamer parent) : base(parent)
		{
		}

		public override void OnMouseDown(MouseEventArgs e)
		{
			isLeftPress = e.Button == MouseButtons.Left;

			foreach (RoomPotSaveEditor item in ZS.OverworldManager.allitems)
			{
				if (item.roomMapId >= 0 + (ZS.OverworldManager.worldOffset) && item.roomMapId < (64 + ZS.OverworldManager.worldOffset))
				{
					if (e.X >= item.x && e.X <= item.x + 16 && e.Y >= item.y && e.Y <= item.y + 16)
					{
						selectedItem = item;
						lastselectedItem = item;
						byte nid = item.id;
						if (item.id.BitIsOn(0x80))
						{
							nid = (byte) (((item.id - 0x80) / 2) + 0x17);
						}

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
			RoomPotSaveEditor id = lastselectedItem.Copy();
			Clipboard.SetData(Constants.OverworldItemClipboardData, id);
		}

		public override void Cut()
		{
			Clipboard.Clear();
			RoomPotSaveEditor id = lastselectedItem.Copy();
			Clipboard.SetData(Constants.OverworldItemClipboardData, id);
			Delete();

			//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
		}

		public override void Paste()
		{
			RoomPotSaveEditor data = (RoomPotSaveEditor) Clipboard.GetData(Constants.OverworldItemClipboardData);
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
					selectedItem.updateMapStuff(mid);
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
			RoomPotSaveEditor pitem = new RoomPotSaveEditor(0, 0, 0, 0, false);
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
						selectedItem.x = e.X & ~0xF;
						selectedItem.y = e.Y & ~0xF;

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
			if (ZS.OverworldScene.lowEndMode)
			{
				Brush bgrBrush;
				g.CompositingMode = CompositingMode.SourceOver;
				foreach (RoomPotSaveEditor item in ZS.OverworldManager.allitems)
				{
					if (item.roomMapId != ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent)
					{
						continue;
					}

					if (item.roomMapId >= (0 + ZS.OverworldManager.worldOffset) && item.roomMapId < (64 + ZS.OverworldManager.worldOffset))
					{

						bgrBrush = (selectedItem == item) ? Constants.Turquoise200Brush : Constants.Scarlet200Brush;

						g.FillRectangle(bgrBrush, new Rectangle((item.x), (item.y), 16, 16));
						g.DrawRectangle(Constants.Black200Pen, new Rectangle((item.x), (item.y), 16, 16));
						byte nid = item.id;

						if (item.id.BitIsOn(0x80))
						{
							nid = (byte) (((item.id - 0x80) / 2) + 0x17);
						}

						if (nid > ItemsNames.name.Length)
						{
							continue;
						}

						ZS.OverworldScene.drawText(g, item.x - 1, item.y + 1, $"{item.id:X2} - {ItemsNames.name[nid]}");
					}
				}

				g.CompositingMode = CompositingMode.SourceCopy;
			}
			else
			{
				Brush bgrBrush;
				g.CompositingMode = CompositingMode.SourceOver;

				foreach (RoomPotSaveEditor item in ZS.OverworldManager.allitems)
				{
					if (item.roomMapId >= (0 + ZS.OverworldManager.worldOffset) && item.roomMapId < (64 + ZS.OverworldManager.worldOffset))
					{
						bgrBrush = (selectedItem == item) ? Constants.Turquoise200Brush : Constants.Scarlet200Brush;

						g.FillRectangle(bgrBrush, new Rectangle(item.x, item.y, 16, 16));
						g.DrawRectangle(Constants.Black200Pen, new Rectangle(item.x, item.y, 16, 16));
						byte nid = item.id;

						if (item.id.BitIsOn(0x80))
						{
							nid = (byte) (((item.id - 0x80) / 2) + 0x17);
						}

						if (nid > ItemsNames.name.Length)
						{
							continue;
						}

						ZS.OverworldScene.drawText(g, item.x - 1, item.y + 1, $"{item.id:X2} - {ItemsNames.name[nid]}");
					}
				}

				g.CompositingMode = CompositingMode.SourceCopy;
			}
		}
	}
}
