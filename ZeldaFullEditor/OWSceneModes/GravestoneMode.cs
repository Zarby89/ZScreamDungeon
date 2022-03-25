using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Data;
namespace ZeldaFullEditor.OWSceneModes
{
	public class GravestoneMode
	{
		private readonly ZScreamer ZS;
		public Gravestone selectedGrave = null;
		public Gravestone lastselectedGrave = null;

		public GravestoneMode(ZScreamer parent)
		{
			ZS = parent;
		}

		public void onMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				for (int i = 0; i < 0x0F; i++)
				{
					Gravestone en = ZS.OverworldManager.graves[i];
					if (e.X >= en.xTilePos && e.X < en.xTilePos + 32 && e.Y >= en.yTilePos && e.Y < en.yTilePos + 32)
					{
						if (!ZS.OverworldScene.mouse_down)
						{
							selectedGrave = en;
							lastselectedGrave = en;
							//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
							ZS.OverworldScene.mouse_down = true;
						}
					}
				}
			}
		}

		public void onMouseMove(MouseEventArgs e)
		{
			if (ZS.OverworldScene.mouse_down)
			{
				int mouseTileX = e.X / 16;
				int mouseTileY = e.Y / 16;
				int mapX = (mouseTileX / 32);
				int mapY = (mouseTileY / 32);

				ZS.OverworldScene.mapHover = mapX + (mapY * 8);

				if (selectedGrave != null)
				{
					selectedGrave.xTilePos = (ushort) (ZS.OverworldScene.snapToGrid ? e.X & ~0x7 : e.X);
					selectedGrave.yTilePos = (ushort) (ZS.OverworldScene.snapToGrid ? e.Y & ~0x7 : e.Y);
				}
			}
		}

		public void onMouseUp(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (selectedGrave != null)
				{
					if (ZS.OverworldScene.mapHover >= 64)
					{
						ZS.OverworldScene.mapHover -= 64;
					}
					int mx = ZS.OverworldScene.mapHover - (ZS.OverworldScene.mapHover & ~0x7);
					int my = ZS.OverworldScene.mapHover / 8;

					byte xx = (byte) ((selectedGrave.xTilePos - (mx * 512)) / 16);
					byte yy = (byte) ((selectedGrave.yTilePos - (my * 512)) / 16);

					selectedGrave.tilemapPos = (ushort) ((((yy) << 6) | (xx & 0x3F)) << 1);

					lastselectedGrave = selectedGrave;
					selectedGrave = null;
					ZS.OverworldScene.mouse_down = false;
				}
			}
		}


		public void Draw(Graphics g)
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
				ZS.OverworldScene.drawText(g, e.xTilePos + 8, e.yTilePos + 8, i.ToString("X2"));

				//scene.drawText(g, e.xTilePos + 8, e.yTilePos + 40, e.tilemapPos.ToString("X4"));
				if (i == 0x0D) // Stairs
				{
					ZS.OverworldScene.drawText(g, e.xTilePos + 8, e.yTilePos + 16, "SPECIAL STAIRS");
				}

				if (i == 0x0E) // Hole
				{
					ZS.OverworldScene.drawText(g, e.xTilePos + 8, e.yTilePos + 16, "SPECIAL HOLE");
				}
			}
		}
	}
}
