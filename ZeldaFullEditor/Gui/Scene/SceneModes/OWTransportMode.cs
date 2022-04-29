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
			if (e.Button != MouseButtons.Left || MouseIsDown) return;

			for (int i = 0; i < 0x11; i++)
			{
				TransportOW en = ZS.OverworldManager.allWhirlpools[i];
				if (en.IsInThisWorld(ZS.OverworldManager.WorldOffset) && en.MouseIsInHitbox(e))
				{
					SelectedTransport = LastSelectedTransport = en;
				}
			}
		}



		private void OnMouseMove_Transports(MouseEventArgs e)
		{
			if (MouseIsDown)
			{
				MoveDestinationToMouse(SelectedTransport, e);
			}
		}

		private void OnMouseUp_Transports(MouseEventArgs e)
		{
			if (SelectedTransport == null) return;

			// TODO integrate with properties tab
			if (e.Button == MouseButtons.Left)
			{
				LastSelectedTransport = SelectedTransport;
				SelectedTransport = null;
			}
		}

		public void Draw_Transports(Graphics g)
		{
			Brush bgrBrush;

			for (int i = 0; i < ZS.OverworldManager.allWhirlpools.Count; i++)
			{
				TransportOW e = ZS.OverworldManager.allWhirlpools[i];

				if (lowEndMode && e.MapID != ZS.OverworldManager.allmaps[CurrentMap].parent)
				{
					continue;
				}

				if (e.IsInThisWorld(ZS.OverworldManager.WorldOffset))
				{
					if (SelectedTransport != null && e == SelectedTransport)
					{
						bgrBrush = Constants.Azure200Brush;
						drawText(g, e.GlobalX - 1, e.GlobalY + 16, $"map : {e.MapID:X2}");
						drawText(g, e.GlobalX - 4, e.GlobalY + 36, $"mpos : {e.VRAMBase:X4}");
					}
					else
					{
						bgrBrush = Constants.Goldenrod200Brush;
					}

					g.DrawFilledRectangleWithOutline(e.SquareHitbox, Constants.Black200Pen, bgrBrush);
					drawText(g, e.GlobalX + 4, e.GlobalY + 4, $"{i:X2} - Transport");
				}
			}
		}
	}
}
