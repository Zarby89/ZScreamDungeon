using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.SceneModes
{
	public class OWSpriteMode : SceneMode
	{
		Sprite selectedSprite;
		public Sprite lastselectedSprite;

		bool isLeftPress = false;

		Gui.AddSprite addspr;
		public OWSpriteMode(ZScreamer zs) : base(zs)
		{
			addspr = new Gui.AddSprite(ZS);
		}

		public override void OnMouseDown(MouseEventArgs e)
		{
			isLeftPress = e.Button == MouseButtons.Left;

			for (int i = ZS.OverworldManager.worldOffset; i < 64 + ZS.OverworldManager.worldOffset; i++)
			{
				if (i > 159)
				{
					continue;
				}

				int gs = ZS.OverworldManager.gameState;
				foreach (Sprite spr in ZS.OverworldManager.allsprites[gs]) // TODO : Check if that need to be changed to LINQ mapid == maphover
				{
					if (e.X >= spr.map_x && e.X <= spr.map_x + 16 && e.Y >= spr.map_y && e.Y <= spr.map_y + 16)
					{
						selectedSprite = spr;
					}

					//Console.WriteLine("X:" + spr.map_x + ", Y:" + spr.map_y);
				}
			}

			ZS.OverworldScene.mouse_down = true;
		}

		public override void OnMouseWheel(MouseEventArgs e)
		{

		}

		public override void Copy()
		{
			Clipboard.Clear();
			int sd = lastselectedSprite.id;
			Clipboard.SetData(Constants.OverworldSpriteClipboardData, sd);
		}

		public override void Cut()
		{
			Clipboard.Clear();
			int sd = lastselectedSprite.id;
			Clipboard.SetData(Constants.OverworldSpriteClipboardData, sd);
			Delete();

			//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
		}

		public override void Paste()
		{
			int data = (int) Clipboard.GetData(Constants.OverworldSpriteClipboardData);
			if (data != -1)
			{
				ZS.OverworldScene.selectedFormSprite = new Sprite(0, (byte) data, 0, 0, 0, 0);
				byte mid = ZS.OverworldManager.allmaps[ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset].parent;
				if (mid == 255)
				{
					mid = (byte) (ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset);
				}

				ZS.OverworldScene.selectedFormSprite.updateMapStuff(mid);
				int gs = ZS.OverworldManager.gameState;
				if (mid >= 64)
				{
					if (gs == 0)
					{
						MessageBox.Show("Can't add sprite in rain state in the Dark World!");
						return;
					}
				}

				ZS.OverworldManager.allsprites[gs].Add(ZS.OverworldScene.selectedFormSprite);
				selectedSprite = ZS.OverworldManager.allsprites[gs].Last();
				ZS.OverworldScene.selectedFormSprite = null;
				ZS.OverworldScene.mouse_down = true;
				isLeftPress = true;

				//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
			}
		}


		public override void OnMouseUp(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				byte mid = ZS.OverworldManager.allmaps[ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset].parent;
				if (mid == 255)
				{
					mid = (byte) (ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset);
				}

				if (ZS.OverworldScene.selectedFormSprite != null)
				{
					ZS.OverworldScene.selectedFormSprite.updateMapStuff(mid);
					int gs = ZS.OverworldManager.gameState;

					if (mid >= 64)
					{
						if (gs == 0)
						{
							MessageBox.Show("Can't add sprite in rain state in the Dark World!");
							return;
						}
					}

					ZS.OverworldManager.allsprites[gs].Add(ZS.OverworldScene.selectedFormSprite);
					ZS.OverworldScene.selectedFormSprite = null;

					//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
				}
				if (selectedSprite != null)
				{
					selectedSprite.updateMapStuff(mid);
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

			ZS.OverworldScene.mouse_down = false;
		}

		private void deleteSprite_Click(object sender, EventArgs e)
		{
			Delete();
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
				ZS.OverworldScene.selectedFormSprite = new Sprite(0, data, 0, 0, (ZS.OverworldScene.mouseX_Real / 16), (ZS.OverworldScene.mouseY_Real / 16));
				byte mid = ZS.OverworldManager.allmaps[ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset].parent;

				if (mid == 255)
				{
					mid = (byte) (ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset);
				}

				ZS.OverworldScene.selectedFormSprite.updateMapStuff(mid);
				int gs = ZS.OverworldManager.gameState;

				if (mid >= 64)
				{
					if (gs == 0)
					{
						MessageBox.Show("Can't add sprite in rain state in the Dark World!");
						return;
					}
				}

				ZS.OverworldManager.allsprites[gs].Add(ZS.OverworldScene.selectedFormSprite);
				selectedSprite = ZS.OverworldManager.allsprites[gs].Last();
				ZS.OverworldScene.selectedFormSprite = null;
				ZS.OverworldScene.mouse_down = true;
				isLeftPress = true;
			}
		}

		public override void OnMouseMove(MouseEventArgs e)
		{
			if (ZS.OverworldScene.mouse_down)
			{
				if (ZS.OverworldScene.selectedFormSprite != null)
				{
					ZS.OverworldScene.selectedFormSprite.map_x = e.X & ~0xF;
					ZS.OverworldScene.selectedFormSprite.map_y = e.Y & ~0xF;

					//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
				}

				if (isLeftPress)
				{
					ZS.OverworldScene.mapHover = (e.X / 16 / 32) + (e.Y / 16 / 32 * 8);

					if (selectedSprite != null)
					{
						selectedSprite.map_x = e.X & ~0xF;
						selectedSprite.map_y = e.Y & ~0xF;

						//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
					}
				}
			}
		}

		public override void Delete()
		{
			if (lastselectedSprite != null)
			{
				for (int i = ZS.OverworldManager.worldOffset; i < 64 + ZS.OverworldManager.worldOffset; i++)
				{
					ZS.OverworldManager.allsprites[ZS.OverworldManager.gameState].Remove(lastselectedSprite);
				}

				lastselectedSprite = null;
				if (ZS.OverworldScene.lowEndMode)
				{
					int x = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent % 8;
					int y = ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent / 8;

					if (!ZS.OverworldManager.allmaps[ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent].largeMap)
					{
						ZS.OverworldScene.Invalidate(new Rectangle(x * 512, y * 512, 512, 512));
					}
					else
					{
						ZS.OverworldScene.Invalidate(new Rectangle(x * 512, y * 512, 1024, 1024));
					}
				}
				else
				{
					ZS.OverworldScene.Invalidate(new Rectangle(ZS.OverworldForm.splitContainer1.Panel2.HorizontalScroll.Value,
						ZS.OverworldForm.splitContainer1.Panel2.VerticalScroll.Value,
						ZS.OverworldForm.splitContainer1.Panel2.Width,
						ZS.OverworldForm.splitContainer1.Panel2.Height));
				}

				//scene.Invalidate();
			}
		}

		public void Draw(Graphics g)
		{
			if (ZS.OverworldScene.lowEndMode)
			{
				Brush bgrBrush = Constants.VibrantMagenta200Brush;
				g.CompositingMode = CompositingMode.SourceOver;

				for (int i = 0; i < ZS.OverworldManager.allsprites[ZS.OverworldManager.gameState].Count; i++)
				{
					Sprite spr = ZS.OverworldManager.allsprites[ZS.OverworldManager.gameState][i];

					if (spr.mapid != ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent)
					{
						continue;
					}

					if (spr.mapid < 64 + ZS.OverworldManager.worldOffset && spr.mapid >= ZS.OverworldManager.worldOffset)
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

						g.FillRectangle(bgrBrush, new Rectangle(spr.map_x, spr.map_y, 16, 16));
						g.DrawRectangle(Constants.Black200Pen, new Rectangle(spr.map_x, spr.map_y, 16, 16));
						ZS.OverworldScene.drawText(g, spr.map_x + 4, spr.map_y + 4, spr.name);
					}
				}

				g.CompositingMode = CompositingMode.SourceCopy;
			}
			else
			{
				Brush bgrBrush = Constants.VibrantMagenta200Brush;
				g.CompositingMode = CompositingMode.SourceOver;

				for (int i = 0; i < ZS.OverworldManager.allsprites[ZS.OverworldManager.gameState].Count; i++)
				{
					Sprite spr = ZS.OverworldManager.allsprites[ZS.OverworldManager.gameState][i];

					if (spr.mapid < 64 + ZS.OverworldManager.worldOffset && spr.mapid >= ZS.OverworldManager.worldOffset)
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

						g.FillRectangle(bgrBrush, new Rectangle(spr.map_x, spr.map_y, 16, 16));
						g.DrawRectangle(Constants.Black200Pen, new Rectangle(spr.map_x, spr.map_y, 16, 16));
						ZS.OverworldScene.drawText(g, spr.map_x + 4, spr.map_y + 4, spr.name);
					}
				}

				g.CompositingMode = CompositingMode.SourceCopy;
			}
		}

		public override void SelectAll()
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

                            g.FillRectangle(bgrBrush, new Rectangle((spr.map_x), spr.map_y, 16, 16));
                            g.DrawRectangle(contourPen, new Rectangle(spr.map_x, spr.map_y, 16, 16));
                            scene.drawText(g, spr.map_x + 4, spr.map_y + 4, spr.name);
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
