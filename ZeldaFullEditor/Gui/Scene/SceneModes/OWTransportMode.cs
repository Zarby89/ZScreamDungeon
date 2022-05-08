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
		private OverworldTransport selbird, lastbird;

		public OverworldTransport SelectedTransport
		{
			get => selbird;
			set
			{
				selbird = value;
			}
		}

		public OverworldTransport LastSelectedTransport
		{
			get => lastbird;
			set
			{
				if (lastbird == value) return;

				Program.OverworldForm.SetSelectedTransport(lastbird);
				lastbird = value;
			}
		}

		private void OnMouseDown_Transports(MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;

			for (int i = 0; i < 0x11; i++)
			{
				OverworldTransport en = ZS.OverworldManager.AllTransports[i];
				if (en.IsInThisWorld(ZS.OverworldManager.World) && en.MouseIsInHitbox(e))
				{
					SelectedTransport = LastSelectedTransport = en;
				}
			}
		}



		private void OnMouseMove_Transports(MouseEventArgs e)
		{
			if (!MouseIsDown)
			{
				FindHoveredEntity(ZS.OverworldManager.AllTransports, e);

				return;
			}

			MoveDestinationToMouse(SelectedTransport, e);
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
			Pen outline;

			for (int i = 0; i < ZS.OverworldManager.AllTransports.Count; i++)
			{
				OverworldTransport e = ZS.OverworldManager.AllTransports[i];

				if (lowEndMode && e.MapID != ZS.OverworldManager.allmaps[CurrentMap].ParentMapID)
				{
					continue;
				}

				if (e.IsInThisWorld(ZS.OverworldManager.World))
				{
					string txt;
					if (SelectedTransport == e)
					{
						bgrBrush = UIColors.TransportSelectedBrush;
						outline = UIColors.OutlineSelectedPen;
					}
					else if (hoveredEntity == e)
					{
						bgrBrush = UIColors.TransportBrush;
						outline = UIColors.OutlineHoverPen;
					}
					else
					{
						bgrBrush = UIColors.TransportBrush;
						outline = UIColors.OutlinePen;
					}

					switch (TransportTextView)
					{
						// TODO might add more stuff in the future
						default:
						case TextView.NeverShowName:
							txt = $"{i:X2}";
							break;

					//case TextView.AlwaysShowName:
					//	txt = $"{e.ID} - {Transport.Name}";
					//	break;
					//
					//default:
					//case TextView.ShowNameOnHover:
					//	if (item == SelectedSecret || item == hoveredEntity)
					//	{
					//		goto case TextView.AlwaysShowName;
					//	}
					//	goto case TextView.NeverShowName;
					}

					g.DrawFilledRectangleWithOutline(e.SquareHitbox, outline, bgrBrush);

					g.DrawText(e.GlobalX + 3, e.GlobalY + 5, txt);
				}
			}
		}
	}
}
