namespace ZeldaFullEditor.UserInterface.UIControl.Scene
{
	public partial class SceneOW
	{
		public Gravestone selectedGrave = null;
		public Gravestone lastselectedGrave = null;

		private void OnMouseDown_Graves(MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;

			for (int i = 0; i < 0x0F; i++)
			{
				// TODO IMouseCollidable
				Gravestone en = ZS.OverworldManager.graves[i];
				if (e.X >= en.xTilePos && e.X < en.xTilePos + 32 && e.Y >= en.yTilePos && e.Y < en.yTilePos + 32)
				{
					selectedGrave = en;
					lastselectedGrave = en;
				}
			}

		}

		private void OnMouseMove_Graves(MouseEventArgs e)
		{
			if (!MouseIsDown) return;

			if (selectedGrave != null)
			{
				selectedGrave.xTilePos = (ushort) (snapToGrid ? e.X & ~0x7 : e.X);
				selectedGrave.yTilePos = (ushort) (snapToGrid ? e.Y & ~0x7 : e.Y);
			}
		}

		private void OnMouseUp_Graves(MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left || selectedGrave == null) return;

			int mx = hoveredMap & 0x7;
			int my = (hoveredMap & 0x3F) >> 3;

			byte xx = (byte) ((selectedGrave.xTilePos - (mx * 512)) / 16);
			byte yy = (byte) ((selectedGrave.yTilePos - (my * 512)) / 16);

			selectedGrave.tilemapPos = (ushort) ((((yy) << 6) | (xx & 0x3F)) << 1);

			lastselectedGrave = selectedGrave;
			selectedGrave = null;
		}


		public void Draw_Graves(Graphics g)
		{
			Pen bgrBrush = Constants.Magenta200Pen;
			g.CompositingMode = CompositingMode.SourceOver;

			for (int i = 0; i < ZS.OverworldManager.graves.Length; i++)
			{
				Gravestone e = ZS.OverworldManager.graves[i];

				if (selectedGrave != null)
				{
					if (e == selectedGrave)
					{
						bgrBrush = Constants.MediumMint200Pen;
						//scene.g.DrawText(e.xTilePos + 8, e.yTilePos + 8, "ID : " + i.ToString("X2"));
					}
					else
					{
						bgrBrush = Constants.Magenta200Pen;
					}
				}

				g.DrawRectangle(bgrBrush, new Rectangle(e.xTilePos, e.yTilePos, 32, 32));
				g.DrawText(e.xTilePos + 8, e.yTilePos + 8, i.ToString("X2"));

				//scene.g.DrawText(e.xTilePos + 8, e.yTilePos + 40, e.tilemapPos.ToString("X4"));
				if (i == 0x0D) // Stairs
				{
					g.DrawText(e.xTilePos + 8, e.yTilePos + 16, "SPECIAL STAIRS");
				}

				if (i == 0x0E) // Hole
				{
					g.DrawText(e.xTilePos + 8, e.yTilePos + 16, "SPECIAL HOLE");
				}
			}
		}

		private void Delete_Graves()
		{
			throw new NotImplementedException();
		}
	}
}
