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

			for (int i = ZS.OverworldManager.worldOffset; i < 64 + ZS.OverworldManager.worldOffset; i++)
			{
				if (i > 159)
				{
					continue;
				}

				int gs = ZS.OverworldManager.gameState;
				foreach (var spr in ZS.OverworldManager.allsprites[gs]) // TODO : Check if that need to be changed to LINQ mapid == maphover
				{
					if (e.X >= spr.MapX && e.X <= spr.MapX + 16 && e.Y >= spr.MapY && e.Y <= spr.MapY + 16)
					{
						selectedSprite = spr;
					}

					//Console.WriteLine("X:" + spr.MapX + ", Y:" + spr.MapY);
				}
			}

			mouse_down = true;
		}

		private void Copy_Sprites()
		{
			Clipboard.Clear();
			int sd = lastselectedSprite.ID;
			Clipboard.SetData(Constants.OverworldSpriteClipboardData, sd);
		}

		private void Cut_Sprites()
		{
			Clipboard.Clear();
			int sd = lastselectedSprite.ID;
			Clipboard.SetData(Constants.OverworldSpriteClipboardData, sd);
			Delete();

			//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
		}

		private void Paste_Sprites()
		{
			int data = (int) Clipboard.GetData(Constants.OverworldSpriteClipboardData);
			if (data != -1)
			{
				selectedFormSprite = new OverworldSprite(0, (byte) data, 0, 0, 0, 0);
				byte mid = ZS.OverworldManager.allmaps[mapHover + ZS.OverworldManager.worldOffset].parent;
				if (mid == 255)
				{
					mid = (byte) (mapHover + ZS.OverworldManager.worldOffset);
				}

				selectedFormSprite.UpdateMapID(mid);
				int gs = ZS.OverworldManager.gameState;
				if (mid >= 64)
				{
					if (gs == 0)
					{
						MessageBox.Show("Can't add sprite in rain state in the Dark World!");
						return;
					}
				}

				ZS.OverworldManager.allsprites[gs].Add(selectedFormSprite);
				selectedSprite = ZS.OverworldManager.allsprites[gs].Last();
				selectedFormSprite = null;
				mouse_down = true;
				isLeftPress = true;

				//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
			}
		}


		private void OnMouseUp_Sprites(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				byte mid = ZS.OverworldManager.allmaps[mapHover + ZS.OverworldManager.worldOffset].parent;
				if (mid == 255)
				{
					mid = (byte) (mapHover + ZS.OverworldManager.worldOffset);
				}

				if (selectedFormSprite != null)
				{
					selectedFormSprite.UpdateMapID(mid);
					int gs = ZS.OverworldManager.gameState;

					if (mid >= 64)
					{
						if (gs == 0)
						{
							MessageBox.Show("Can't add sprite in rain state in the Dark World!");
							return;
						}
					}

					ZS.OverworldManager.allsprites[gs].Add(selectedFormSprite);
					selectedFormSprite = null;

					//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
				}
				if (selectedSprite != null)
				{
					selectedSprite.UpdateMapID(mid);
					lastselectedSprite = selectedSprite;
					selectedSprite = null;

					//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
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

			mouse_down = false;
		}

		private void deleteSprite_Click(object sender, EventArgs e)
		{
			Delete_Sprites();
		}

		private void spriteProperties_Click(object sender, EventArgs e)
		{
			// Nothing for now
		}

		private void addSprite_Click(object sender, EventArgs e)
		{
			if (addspr.ShowDialog() == DialogResult.OK)
			{
				byte data = (byte) addspr.spriteListBox.SelectedIndex;
				selectedFormSprite = new OverworldSprite(0, data, 0, 0, (mouseX_Real / 16), (mouseY_Real / 16));
				byte mid = ZS.OverworldManager.allmaps[mapHover + ZS.OverworldManager.worldOffset].parent;

				if (mid == 255)
				{
					mid = (byte) (mapHover + ZS.OverworldManager.worldOffset);
				}

				selectedFormSprite.UpdateMapID(mid);
				int gs = ZS.OverworldManager.gameState;

				if (mid >= 64)
				{
					if (gs == 0)
					{
						MessageBox.Show("Can't add sprite in rain state in the Dark World!");
						return;
					}
				}

				ZS.OverworldManager.allsprites[gs].Add(selectedFormSprite);
				selectedSprite = ZS.OverworldManager.allsprites[gs].Last();
				selectedFormSprite = null;
				mouse_down = true;
				isLeftPress = true;
			}
		}

		private void OnMouseMove_Sprites(MouseEventArgs e)
		{
			if (mouse_down)
			{
				if (selectedFormSprite != null)
				{
					selectedFormSprite.MapX = (byte) (e.X & ~0xF);
					selectedFormSprite.MapY = (byte) (e.Y & ~0xF);

					//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
				}

				if (isLeftPress)
				{
					mapHover = (e.X / 16 / 32) + (e.Y / 16 / 32 * 8);

					if (selectedSprite != null)
					{
						selectedSprite.MapX = (byte) (e.X & ~0xF);
						selectedSprite.MapY = (byte) (e.Y & ~0xF);

						//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
					}
				}
			}
		}

		private void Delete_Sprites()
		{
			if (lastselectedSprite != null)
			{
				for (int i = ZS.OverworldManager.worldOffset; i < 64 + ZS.OverworldManager.worldOffset; i++)
				{
					ZS.OverworldManager.allsprites[ZS.OverworldManager.gameState].Remove(lastselectedSprite);
				}

				lastselectedSprite = null;
				if (lowEndMode)
				{
					int x = ZS.OverworldManager.allmaps[selectedMap].parent % 8;
					int y = ZS.OverworldManager.allmaps[selectedMap].parent / 8;

					if (!ZS.OverworldManager.allmaps[ZS.OverworldManager.allmaps[selectedMap].parent].largeMap)
					{
						Invalidate(new Rectangle(x * 512, y * 512, 512, 512));
					}
					else
					{
						Invalidate(new Rectangle(x * 512, y * 512, 1024, 1024));
					}
				}
				else
				{
					Invalidate(new Rectangle(Program.OverworldForm.splitContainer1.Panel2.HorizontalScroll.Value,
						Program.OverworldForm.splitContainer1.Panel2.VerticalScroll.Value,
						Program.OverworldForm.splitContainer1.Panel2.Width,
						Program.OverworldForm.splitContainer1.Panel2.Height));
				}

				//scene.Invalidate();
			}
		}

		public void Draw_Sprites(Graphics g)
		{
			Brush bgrBrush = Constants.VibrantMagenta200Brush;
			g.CompositingMode = CompositingMode.SourceOver;

			for (int i = 0; i < ZS.OverworldManager.allsprites[ZS.OverworldManager.gameState].Count; i++)
			{
				var spr = ZS.OverworldManager.allsprites[ZS.OverworldManager.gameState][i];

				if (lowEndMode && spr.MapID != ZS.OverworldManager.allmaps[selectedMap].parent)
				{
					continue;
				}

				if (spr.MapID < 64 + ZS.OverworldManager.worldOffset && spr.MapID >= ZS.OverworldManager.worldOffset)
				{
					/*
                    if (selectedEntrance != null)
                    {
                        if (e == selectedEntrance)
                        {
                            bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 0, 55, 240));
                            scene.drawText(g, e.x - 1, e.y + 16, "map : " + e.mapId.ToString());
                            scene.drawText(g, e.x - 1, e.y + 26, "entrance : " + e.entranceId.ToString());
                            scene.drawText(g, e.x - 1, e.y + 36, "mpos : " + e.mapPos.ToString());
                        }
                        else
                        {
                            bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 255, 200, 16));
                        }
                    }
                    */
					g.DrawFilledRectangleWithOutline(spr.MapX, spr.MapY, 16, 16, Constants.Black200Pen, bgrBrush);
					drawText(g, spr.MapX + 4, spr.MapY + 4, spr.Name);
				}
			}

			g.CompositingMode = CompositingMode.SourceCopy;
		}

		private void SelectAll_Sprites()
		{
			throw new NotImplementedException();
		}

		/*
        public void Draw(Graphics g)
        {
            int transparency = 200;
            Brush bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 255, 0, 255));
            Pen contourPen = new Pen(Color.FromArgb((int)transparency, 0, 0, 0));
            g.CompositingMode = CompositingMode.SourceOver;

            for (int i = scene.ow.worldOffset; i < 64 + scene.ow.worldOffset; i++)
            {
                int gs = scene.ow.gameState;
                if (i >= 64 && i <= 128)
                {
                    gs = 0;
                }

                if (i <= 159)
                {
                    foreach (Sprite spr in scene.ow.allsprites[gs])
                    {
                        if (spr.mapid == 0)
                        {
                            if (selectedSprite == spr)
                            {
                                bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 00, 255, 0));
                                contourPen = new Pen(Color.FromArgb((int)transparency, 0, 0, 0));
                            }
                            else if (lastselectedSprite == spr)
                            {
                                bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 0, 180, 0));
                                contourPen = new Pen(Color.FromArgb((int)transparency, 0, 0, 0));
                            }
                            else
                            {
                                bgrBrush = new SolidBrush(Color.FromArgb((int)transparency, 255, 0, 255));
                                contourPen = new Pen(Color.FromArgb((int)transparency, 0, 0, 0));
                            }

                            g.FillRectangle(bgrBrush, new Rectangle((spr.MapX), spr.MapY, 16, 16));
                            g.DrawRectangle(contourPen, new Rectangle(spr.MapX, spr.MapY, 16, 16));
                            scene.drawText(g, spr.MapX + 4, spr.MapY + 4, spr.name);
                        }
                    }
                }

                if (scene.selectedFormSprite != null)
                {
                    g.FillRectangle(bgrBrush, new Rectangle((scene.selectedFormSprite.map_x), (scene.selectedFormSprite.map_y), 16, 16));
                    g.DrawRectangle(contourPen, new Rectangle((scene.selectedFormSprite.map_x), (scene.selectedFormSprite.map_y), 16, 16));
                    scene.drawText(g, (scene.selectedFormSprite.map_x) + 4, (scene.selectedFormSprite.map_y) + 4, scene.selectedFormSprite.name);
                }
                
            }

            g.CompositingMode = CompositingMode.SourceCopy;
        }
        */
	}
}
