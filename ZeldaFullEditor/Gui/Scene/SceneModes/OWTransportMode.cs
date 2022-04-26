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
		public TransportOW selectedTransport = null;
		public TransportOW lastselectedTransport = null;

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
							if (!mouse_down)
							{
								selectedTransport = en;
								lastselectedTransport = en;
								//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
								mouse_down = true;
							}
						}
					}
				}
			}
		}

		private void OnMouseMove_Transports(MouseEventArgs e)
		{
			if (mouse_down)
			{
				mapHover = (e.X / 16 / 32) + (e.Y / 16 / 32 * 8);

				if (selectedTransport != null)
				{
					selectedTransport.GlobalX = (ushort) (snapToGrid ? e.X & ~0x7 : e.X);
					selectedTransport.GlobalY = (ushort) (snapToGrid ? e.Y & ~0x7 : e.Y);

					byte mid = ZS.OverworldManager.allmaps[mapHover + ZS.OverworldManager.worldOffset].parent;
					if (mid == 255)
					{
						mid = (byte) (mapHover + ZS.OverworldManager.worldOffset);
					}

					selectedTransport.UpdateMapID(mid, ZS.OverworldManager);

					//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
				}
			}
		}

		private void OnMouseUp_Transports(MouseEventArgs e)
		{
			// TODO integrate with properties tab
			if (e.Button == MouseButtons.Left)
			{
				if (selectedTransport != null)
				{
					lastselectedTransport = selectedTransport;
					selectedTransport = null;
					mouse_down = false;
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

				if (lowEndMode && e.MapID != ZS.OverworldManager.allmaps[selectedMap].parent)
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
