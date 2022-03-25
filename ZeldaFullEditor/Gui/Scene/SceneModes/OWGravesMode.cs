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
		public Gravestone selectedGrave = null;
		public Gravestone lastselectedGrave = null;

		private void OnMouseDown_Graves(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				for (int i = 0; i < 0x0F; i++)
				{
					Gravestone en = ZS.OverworldManager.graves[i];
					if (e.X >= en.xTilePos && e.X < en.xTilePos + 32 && e.Y >= en.yTilePos && e.Y < en.yTilePos + 32)
					{
						if (!MouseIsDown)
						{
							selectedGrave = en;
							lastselectedGrave = en;
							//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
							MouseIsDown = true;
						}
					}
				}
			}
		}

		private void OnMouseMove_Graves(MouseEventArgs e)
		{
			if (MouseIsDown)
			{
				int mouseTileX = e.X / 16;
				int mouseTileY = e.Y / 16;
				int mapX = (mouseTileX / 32);
				int mapY = (mouseTileY / 32);

				mapHover = mapX + (mapY * 8);

				if (selectedGrave != null)
				{
					selectedGrave.xTilePos = (ushort) (snapToGrid ? e.X & ~0x7 : e.X);
					selectedGrave.yTilePos = (ushort) (snapToGrid ? e.Y & ~0x7 : e.Y);
				}
			}
		}

		private void OnMouseUp_Graves(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (selectedGrave != null)
				{
					if (mapHover >= 64)
					{
						mapHover -= 64;
					}
					int mx = mapHover - (mapHover & ~0x7);
					int my = mapHover / 8;

					byte xx = (byte) ((selectedGrave.xTilePos - (mx * 512)) / 16);
					byte yy = (byte) ((selectedGrave.yTilePos - (my * 512)) / 16);

					selectedGrave.tilemapPos = (ushort) ((((yy) << 6) | (xx & 0x3F)) << 1);

					lastselectedGrave = selectedGrave;
					selectedGrave = null;
					MouseIsDown = false;
				}
			}
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
						//scene.drawText(g, e.xTilePos + 8, e.yTilePos + 8, "ID : " + i.ToString("X2"));
					}
					else
					{
						bgrBrush = Constants.Magenta200Pen;
					}
				}

				g.DrawRectangle(bgrBrush, new Rectangle(e.xTilePos, e.yTilePos, 32, 32));
				drawText(g, e.xTilePos + 8, e.yTilePos + 8, i.ToString("X2"));

				//scene.drawText(g, e.xTilePos + 8, e.yTilePos + 40, e.tilemapPos.ToString("X4"));
				if (i == 0x0D) // Stairs
				{
					drawText(g, e.xTilePos + 8, e.yTilePos + 16, "SPECIAL STAIRS");
				}

				if (i == 0x0E) // Hole
				{
					drawText(g, e.xTilePos + 8, e.yTilePos + 16, "SPECIAL HOLE");
				}
			}
		}

		private void Delete_Graves()
		{
			throw new NotImplementedException();
		}
	}
}
