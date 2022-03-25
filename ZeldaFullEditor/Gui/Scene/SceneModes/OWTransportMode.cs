using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
	public partial class SceneOW
	{
		private TransportOW selbird, lastbird;

		public TransportOW SelectedTransport
		{
			get => selbird;
			set
			{
				selbird = value;
			}
		}

		public TransportOW LastSelectedTransport
		{
			get => lastbird;
			set
			{
				if (lastbird == value) return;

				Program.OverworldForm.SetSelectedTransport(lastbird);
				lastbird = value;
			}
		}

		// TODO use IMouseCollidable
		private void OnMouseDown_Transports(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				for (int i = 0; i < 0x11; i++)
				{
					TransportOW en = ZS.OverworldManager.allWhirlpools[i];
					if (en.MapID >= ZS.OverworldManager.worldOffset && en.MapID < 64 + ZS.OverworldManager.worldOffset)
					{
						if (e.X >= en.GlobalX && e.X < en.GlobalX + 16 && e.Y >= en.GlobalY && e.Y < en.GlobalY + 16)
						{
							if (!MouseIsDown)
							{
								SelectedTransport = en;
								LastSelectedTransport = en;
								//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
								MouseIsDown = true;
							}
						}
					}
				}
			}
		}

		private void OnMouseMove_Transports(MouseEventArgs e)
		{
			if (MouseIsDown)
			{
				mapHover = (e.X / 16 / 32) + (e.Y / 16 / 32 * 8);

				if (SelectedTransport != null)
				{
					SelectedTransport.GlobalX = (ushort) (snapToGrid ? e.X & ~0x7 : e.X);
					SelectedTransport.GlobalY = (ushort) (snapToGrid ? e.Y & ~0x7 : e.Y);

					byte m2 = (byte) (mapHover + ZS.OverworldManager.worldOffset);

					byte mid = ZS.OverworldManager.allmaps[m2].parent;

					if (mid == 255)
					{
						mid = m2;
					}

					SelectedTransport.UpdateMapID(mid, ZS.OverworldManager);

					//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
				}
			}
		}

		private void OnMouseUp_Transports(MouseEventArgs e)
		{
			// TODO integrate with properties tab
			if (e.Button == MouseButtons.Left)
			{
				if (SelectedTransport != null)
				{
					LastSelectedTransport = SelectedTransport;
					SelectedTransport = null;
					MouseIsDown = false;
				}
			}
		}

		public void Draw_Transports(Graphics g)
		{
			Brush bgrBrush = Constants.DarkMint200Brush;
			g.CompositingMode = CompositingMode.SourceOver;

			for (int i = 0; i < ZS.OverworldManager.allWhirlpools.Count; i++)
			{
				TransportOW e = ZS.OverworldManager.allWhirlpools[i];

				if (lowEndMode && e.MapID != ZS.OverworldManager.allmaps[CurrentMap].parent)
				{
					continue;
				}

				if (e.MapID < 64 + ZS.OverworldManager.worldOffset && e.MapID >= ZS.OverworldManager.worldOffset)
				{
					if (SelectedTransport != null)
					{
						if (e == SelectedTransport)
						{
							bgrBrush = Constants.Azure200Brush;
							drawText(g, e.GlobalX - 1, e.GlobalY + 16, $"map : {e.MapID:X2}");
							drawText(g, e.GlobalX - 4, e.GlobalY + 36, $"mpos : {e.VRAMBase:X4}");
						}
						else
						{
							bgrBrush = Constants.Goldenrod200Brush;
						}
					}

					g.DrawFilledRectangleWithOutline(e.GlobalX, e.GlobalY, 16, 16, Constants.Black200Pen, bgrBrush);
					drawText(g, e.GlobalX + 4, e.GlobalY + 4, $"{i:X2} - Transport");
				}
			}
		}
	}
}
