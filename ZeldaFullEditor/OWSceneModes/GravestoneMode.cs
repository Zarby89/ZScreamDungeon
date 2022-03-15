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
		SceneOW scene;
		public Gravestone selectedGrave = null;
		public Gravestone lastselectedGrave = null;

		public GravestoneMode(SceneOW scene)
		{
			this.scene = scene;
		}

		public void onMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				for (int i = 0; i < 0x0F; i++)
				{
					Gravestone en = scene.ow.graves[i];
					if (e.X >= en.xTilePos && e.X < en.xTilePos + 32 && e.Y >= en.yTilePos && e.Y < en.yTilePos + 32)
					{
						if (!scene.mouse_down)
						{
							selectedGrave = en;
							lastselectedGrave = en;
							//scene.Invalidate(new Rectangle(scene.mainForm.panel5.HorizontalScroll.Value, scene.mainForm.panel5.VerticalScroll.Value, scene.mainForm.panel5.Width, scene.mainForm.panel5.Height));
							scene.mouse_down = true;
						}
					}
				}
			}
		}

		public void onMouseMove(MouseEventArgs e)
		{
			if (scene.mouse_down)
			{
				int mouseTileX = e.X / 16;
				int mouseTileY = e.Y / 16;
				int mapX = (mouseTileX / 32);
				int mapY = (mouseTileY / 32);

				scene.mapHover = mapX + (mapY * 8);

				if (selectedGrave != null)
				{
					selectedGrave.xTilePos = (ushort) e.X;
					selectedGrave.yTilePos = (ushort) e.Y;
					if (scene.snapToGrid)
					{
						selectedGrave.xTilePos = (ushort) ((e.X / 8) * 8);
						selectedGrave.yTilePos = (ushort) ((e.Y / 8) * 8);
					}
				}
			}
		}

		public void onMouseUp(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (selectedGrave != null)
				{
					if (scene.mapHover >= 64)
					{
						scene.mapHover -= 64;
					}
					int mx = (scene.mapHover - ((scene.mapHover / 8) * 8));
					int my = ((scene.mapHover / 8));

					byte xx = (byte) ((selectedGrave.xTilePos - (mx * 512)) / 16);
					byte yy = (byte) ((selectedGrave.yTilePos - (my * 512)) / 16);

					selectedGrave.tilemapPos = (ushort) ((((yy) << 6) | (xx & 0x3F)) << 1);

					lastselectedGrave = selectedGrave;
					selectedGrave = null;
					scene.mouse_down = false;
				}
			}
		}


		public void Draw(Graphics g)
		{
			Pen bgrBrush = Constants.Magenta200Pen;
			g.CompositingMode = CompositingMode.SourceOver;

			for (int i = 0; i < scene.ow.graves.Length; i++)
			{
				Gravestone e = scene.ow.graves[i];

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
				scene.drawText(g, e.xTilePos + 8, e.yTilePos + 8, i.ToString("X2"));

				//scene.drawText(g, e.xTilePos + 8, e.yTilePos + 40, e.tilemapPos.ToString("X4"));
				if (i == 0x0D) // Stairs
				{
					scene.drawText(g, e.xTilePos + 8, e.yTilePos + 16, "SPECIAL STAIRS");
				}

				if (i == 0x0E) // Hole
				{
					scene.drawText(g, e.xTilePos + 8, e.yTilePos + 16, "SPECIAL HOLE");
				}
			}
		}
	}
}
