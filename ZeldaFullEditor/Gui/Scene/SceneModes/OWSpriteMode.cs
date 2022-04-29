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
		private OverworldSprite selectedSprite;
		private OverworldSprite lastselectedSprite;

		bool isLeftPress = false;

		Gui.AddSprite addspr = new Gui.AddSprite();

		private void OnMouseDown_Sprites(MouseEventArgs e)
		{
			isLeftPress = e.Button == MouseButtons.Left;

			for (int i = ZS.OverworldManager.WorldOffset; i < ZS.OverworldManager.WorldOffsetEnd; i++)
			{
				if (i > 159)
				{
					break;
				}

				int gs = ZS.OverworldManager.GameState;
				foreach (var spr in ZS.OverworldManager.allsprites[gs]) // TODO : Check if that need to be changed to LINQ mapid == maphover
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
				selectedFormSprite = new OverworldSprite(SpriteType.Sprite00); // TODO
				byte mid = ZS.OverworldManager.allmaps[mapHover + ZS.OverworldManager.WorldOffset].parent;
				if (mid == 255)
				{
					mid = (byte) (mapHover + ZS.OverworldManager.WorldOffset);
				}

				selectedFormSprite.MapID = mid;
				int gs = ZS.OverworldManager.GameState;
				if (mid >= 64 && gs == 0)
				{
					throw new ZeldaException("Can't add sprite in rain state in the Dark World!");
				}

				ZS.OverworldManager.allsprites[gs].Add(selectedFormSprite);
				selectedSprite = ZS.OverworldManager.allsprites[gs].Last();
				selectedFormSprite = null;
				MouseIsDown = true;
				isLeftPress = true;
			}
		}

		// TODO make "TryToAddSprite" method
		private void OnMouseUp_Sprites(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				byte mid = ZS.OverworldManager.allmaps[mapHover + ZS.OverworldManager.WorldOffset].parent;
				if (mid == 255)
				{
					mid = (byte) (mapHover + ZS.OverworldManager.WorldOffset);
				}

				if (selectedFormSprite != null)
				{
					selectedFormSprite.MapID = mid;
					int gs = ZS.OverworldManager.GameState;

					if (mid >= 64)
					{
						if (gs == 0)
						{
							throw new ZeldaException("Can't add sprite in rain state in the Dark World!");
						}
					}

					ZS.OverworldManager.allsprites[gs].Add(selectedFormSprite);
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
					GlobalX = (ushort) mouseX_Real,
					GlobalY = (ushort) mouseY_Real,
				}; // TODO
				byte mid = ZS.OverworldManager.allmaps[mapHover + ZS.OverworldManager.WorldOffset].parent;

				if (mid == 255)
				{
					mid = (byte) (mapHover + ZS.OverworldManager.WorldOffset);
				}

				selectedFormSprite.MapID = mid;
				int gs = ZS.OverworldManager.GameState;

				if (mid >= 64)
				{
					if (gs == 0)
					{
						throw new ZeldaException("Can't add sprite in rain state in the Dark World!");
					}
				}

				ZS.OverworldManager.allsprites[gs].Add(selectedFormSprite);
				selectedSprite = ZS.OverworldManager.allsprites[gs].Last();
				selectedFormSprite = null;
				MouseIsDown = true;
				isLeftPress = true;
			}
		}

		private void OnMouseMove_Sprites(MouseEventArgs e)
		{
			if (!MouseIsDown) return;
			
			if (selectedFormSprite != null)
			{
				selectedFormSprite.MapX = (byte) (e.X & ~0xF);
				selectedFormSprite.MapY = (byte) (e.Y & ~0xF);
			}

			if (isLeftPress)
			{
				mapHover = (e.X / 16 / 32) + (e.Y / 16 / 32 * 8);

				if (selectedSprite != null)
				{
					selectedSprite.MapX = (byte) (e.X & ~0xF);
					selectedSprite.MapY = (byte) (e.Y & ~0xF);
				}
			}
		}

		private void Delete_Sprites()
		{
			if (lastselectedSprite == null) return;

			
			for (int i = ZS.OverworldManager.WorldOffset; i < ZS.OverworldManager.WorldOffsetEnd; i++)
			{
				ZS.OverworldManager.allsprites[ZS.OverworldManager.GameState].Remove(lastselectedSprite);
			}

			lastselectedSprite = null;
		}

		public void Draw_Sprites(Graphics g)
		{
			Brush bgrBrush = Constants.VibrantMagenta200Brush;

			for (int i = 0; i < ZS.OverworldManager.allsprites[ZS.OverworldManager.GameState].Count; i++)
			{
				var spr = ZS.OverworldManager.allsprites[ZS.OverworldManager.GameState][i];

				if (lowEndMode && spr.MapID != ZS.OverworldManager.allmaps[CurrentMap].parent)
				{
					continue;
				}

				if (spr.IsInThisWorld(ZS.OverworldManager.WorldOffset))
				{
					g.DrawFilledRectangleWithOutline(spr.SquareHitbox, Constants.Black200Pen, bgrBrush);
					drawText(g, spr.RealX + 4, spr.RealY + 4, spr.Name);
				}
			}
		}

		private void SelectAll_Sprites()
		{
			throw new NotImplementedException();
		}
	}
}
