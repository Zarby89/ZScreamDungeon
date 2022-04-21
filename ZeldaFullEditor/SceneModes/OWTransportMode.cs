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
	public class OWTransportMode : SceneMode
	{
		public TransportOW selectedTransport = null;
		public TransportOW lastselectedTransport = null;

		public OWTransportMode(ZScreamer zs) : base(zs)
		{
		}

		public override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				for (int i = 0; i < 0x11; i++)
				{
					TransportOW en = ZS.OverworldManager.allWhirlpools[i];
					if (en.MapID >= ZS.OverworldManager.worldOffset && en.MapID < 64 + ZS.OverworldManager.worldOffset)
					{
						if (e.X >= en.playerX && e.X < en.playerX + 16 && e.Y >= en.playerY && e.Y < en.playerY + 16)
						{
							if (!ZS.OverworldScene.mouse_down)
							{
								selectedTransport = en;
								lastselectedTransport = en;
								//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
								ZS.OverworldScene.mouse_down = true;
							}
						}
					}
				}
			}
		}

		public override void OnMouseMove(MouseEventArgs e)
		{
			if (ZS.OverworldScene.mouse_down)
			{
				ZS.OverworldScene.mapHover = (e.X / 16 / 32) + (e.Y / 16 / 32 * 8);

				if (selectedTransport != null)
				{
					selectedTransport.playerX = (ushort) (ZS.OverworldScene.snapToGrid ? e.X & ~0x7 : e.X);
					selectedTransport.playerY = (ushort) (ZS.OverworldScene.snapToGrid ? e.Y & ~0x7 : e.Y);

					byte mid = ZS.OverworldManager.allmaps[ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset].parent;
					if (mid == 255)
					{
						mid = (byte) (ZS.OverworldScene.mapHover + ZS.OverworldManager.worldOffset);
					}

					selectedTransport.UpdateMapID(mid, ZS.OverworldManager);

					//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
				}
			}
		}

		public override void OnMouseUp(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (selectedTransport != null)
				{
					lastselectedTransport = selectedTransport;
					selectedTransport = null;
					ZS.OverworldScene.mouse_down = false;
				}
			}
			else if (e.Button == MouseButtons.Right)
			{
				for (int i = 0; i < 0x11; i++)
				{
					TransportOW en = ZS.OverworldManager.allWhirlpools[i];
					if (en.MapID >= ZS.OverworldManager.worldOffset && en.MapID < 64 + ZS.OverworldManager.worldOffset)
					{
						if (e.X >= en.playerX && e.X < en.playerX + 16 && e.Y >= en.playerY && e.Y < en.playerY + 16)
						{
							ContextMenuStrip menu = new ContextMenuStrip();
							menu.Items.Add("Whirlpool Properties");
							lastselectedTransport = en;
							selectedTransport = null;
							ZS.OverworldScene.mouse_down = false;

							if (lastselectedTransport == null)
							{
								menu.Items[0].Enabled = false;
							}

							menu.Items[0].Click += exitProperty_Click;
							menu.Show(Cursor.Position);
						}
					}
				}

				//scene.Invalidate(new Rectangle((scene.owForm.splitContainer1.Panel2.HorizontalScroll.Value), (scene.owForm.splitContainer1.Panel2.VerticalScroll.Value), (scene.owForm.splitContainer1.Panel2.Width), (scene.owForm.splitContainer1.Panel2.Height)));
			}
		}

		public override void OnMouseWheel(MouseEventArgs e)
		{

		}

		private void exitProperty_Click(object sender, EventArgs e)
		{
			WhirlpoolForm wf = new WhirlpoolForm();
			wf.textBox1.Text = lastselectedTransport.whirlpoolPos.ToString();

			if (wf.ShowDialog() == DialogResult.OK)
			{
				ushort.TryParse(wf.textBox1.Text, out ushort v);
				lastselectedTransport.whirlpoolPos = v;
			}
		}

		public void Draw(Graphics g)
		{
			Brush bgrBrush = Constants.DarkMint200Brush;
			g.CompositingMode = CompositingMode.SourceOver;

			for (int i = 0; i < ZS.OverworldManager.allWhirlpools.Count; i++)
			{
				TransportOW e = ZS.OverworldManager.allWhirlpools[i];

				if (ZS.OverworldScene.lowEndMode && e.MapID != ZS.OverworldManager.allmaps[ZS.OverworldScene.selectedMap].parent)
				{
					continue;
				}

				if (e.MapID < 64 + ZS.OverworldManager.worldOffset && e.MapID >= ZS.OverworldManager.worldOffset)
				{
					if (selectedTransport != null)
					{
						if (e == selectedTransport)
						{
							bgrBrush = Constants.Azure200Brush;
							ZS.OverworldScene.drawText(g, e.playerX - 1, e.playerY + 16, $"map : {e.MapID:X2}");
							//scene.drawText(g, e.playerX - 1, e.playerY + 26, "entrance : " + e.mapId.ToString());
							ZS.OverworldScene.drawText(g, e.playerX - 4, e.playerY + 36, $"mpos : {e.vramLocation:X4}");
						}
						else
						{
							bgrBrush = Constants.Goldenrod200Brush;
						}
					}

					g.DrawFilledRectangleWithOutline(e.playerX, e.playerY, 16, 16, Constants.Black200Pen, bgrBrush);
					ZS.OverworldScene.drawText(g, e.playerX + 4, e.playerY + 4, $"{i:X2} - Transport");

					/*
                     if (i > 8)
                     {
                         scene.drawText(g, e.playerX + 4, e.playerY + 4, i.ToString("X2") + " - Transport - " + i.ToString("X2"));
                     }
                     else
                     {
                         scene.drawText(g, e.playerX + 4, e.playerY + 4, i.ToString("X2") + " - Transport - " + i.ToString("X2"));
                     }
                     */
				}
			}
		}

		// TODO
		public override void Copy()
		{
			throw new NotImplementedException();
		}

		public override void Cut()
		{
			throw new NotImplementedException();
		}

		public override void Paste()
		{
			throw new NotImplementedException();
		}

		public override void Delete()
		{
			throw new NotImplementedException();
		}

		public override void SelectAll()
		{
			throw new NotImplementedException();
		}
	}
}
