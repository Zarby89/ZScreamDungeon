namespace ZeldaFullEditor
{
	public partial class SceneOW
	{
		private OverworldTransport lastbird;

		public OverworldTransport SelectedTransport { get; set; }

		public OverworldTransport LastSelectedTransport
		{
			get => lastbird;
			set
			{
				if (lastbird == value) return;

				lastbird = value;
				ZGUI.OverworldEditor.SetSelectedTransport(lastbird);
				ZGUI.UpdateFormForSelectedObject(lastbird);
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

				if (lowEndMode && e.MapID != CurrentParentMapID)
				{
					continue;
				}

				if (!e.IsInThisWorld(ZS.OverworldManager.World)) continue;
				
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

				var txt = TransportTextView switch
				{
					// TODO might add more stuff in the future
					_ => $"{i:X2}",
				};

				g.DrawFilledRectangleWithOutline(e.BoundingBox, outline, bgrBrush);

				g.DrawText(e.GlobalX + 3, e.GlobalY + 5, txt);
			}
		}
	}
}
