using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using ZeldaFullEditor.Properties;
using Microsoft.VisualBasic;
using System.IO.Compression;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Globalization;

using ZeldaFullEditor.Data.DungeonObjects;

namespace ZeldaFullEditor
{
	public class SceneUW : Scene
	{
		public Bitmap tempBitmap = new Bitmap(512, 512);
		Rectangle lastSelectedRectangle;

		public bool forPreview = false;

		bool resizing = false;

		int rmx = 0;
		int rmy = 0;
		public bool showLayer1;
		public bool showLayer2;

		public DungeonRoom Room { get; set; }

		public SceneUW(ZScreamer parent) : base(parent)
		{
			//graphics = Graphics.FromImage(scene_bitmap);

			MouseDown += new MouseEventHandler(OnMouseDown);
			MouseUp += new MouseEventHandler(OnMouseUp);
			MouseMove += new MouseEventHandler(OnMouseMove);
			MouseDoubleClick += new MouseEventHandler(OnMouseDoubleClick);
			MouseWheel += SceneUW_MouseWheel;
			Paint += SceneUW_Paint;
		}

		private void SceneUW_MouseWheel(object sender, MouseEventArgs e)
		{
			if (Room.SelectedObjects.Count == 1 && Room.SelectedObjects[0] is RoomObject obj)
			{
				if ((e.Delta > 0 && obj.IncreaseSize()) || (e.Delta < 0 && obj.DecreaseSize()))
				{
					updateSelectionObject(obj);
				}
			}

			DrawRoom();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
		}

		private void ResizeObject(RoomObject lastElement, int x, int y)
		{
			throw new NotImplementedException();
		}

		// TODO: FIND PROBLEM THAT IS INCREASING SAVE TIME!!
		private void OnMouseMove(object sender, MouseEventArgs e)
		{
			ZS.MainForm.GetXYMouseBasedOnZoom(e, out int MX, out int MY);

			throw new NotImplementedException();
		}

		public void MoveObjects()
		{
			foreach (var o in Room.SelectedObjects)
			{
				if (o is IFreelyPlaceable gg)
				{
					gg.NX = (byte) (gg.X + MoveX).Clamp(0, 80);
					gg.NY = (byte) (gg.Y + MoveY).Clamp(0, 80);
				}
			}
		}

		private unsafe void SceneUW_Paint(object sender, PaintEventArgs e)
		{
			throw new NotImplementedException();
		}

		public void drawDoorsPosition(Graphics g)
		{
			if (MouseIsDown && Room.SelectedObjects.Count > 0 && Room.SelectedObjects[0] is DungeonDoorObject rr)
			{
				g.DrawRectangles(Constants.ThirdGreenPen, doorArray);
			}
		}

		public void Clear()
		{
			// TODO: Add something here?
			//graphics.Clear(this.BackColor);
		}

		private void OnMouseDown(object sender, MouseEventArgs e)
		{
			throw new NotImplementedException();
		}

		public unsafe void ClearBgGfx()
		{
			byte* bg1data = (byte*) ZS.GFXManager.roomBg1Ptr.ToPointer();
			byte* bg2data = (byte*) ZS.GFXManager.roomBg2Ptr.ToPointer();

			for (int i = 0; i < 512 * 512; i++)
			{
				bg1data[i] = 0;
				bg2data[i] = 0;
			}
		}

		public unsafe void DrawRoom(bool refresh = true)
		{
			throw new NotImplementedException();

			if (refresh)
			{
				Refresh();
			}
		}

		public void drawChests()
		{
			throw new NotImplementedException();
		}

		public void drawGrid(Graphics graphics)
		{
			if (showGrid)
			{
				int s = ZS.MainForm.gridSize;
				int wh = (512 / s) + 1;

				for (int x = 0, g = 0; x < wh; x++, g += s)
				{
					graphics.DrawLine(Constants.HalfWhitePen, g, 0, g, 512);
					graphics.DrawLine(Constants.HalfWhitePen, 0, g, 512, g);
				}
			}
		}

		public void SetPalettesTransparent()
		{
			int pindex = 0;
			ColorPalette palettes = ZS.GFXManager.roomBg1Bitmap.Palette;
			for (int y = 0; y < ZS.GFXManager.loadedPalettes.GetLength(1); y++)
			{
				for (int x = 0; x < ZS.GFXManager.loadedPalettes.GetLength(0); x++)
				{
					palettes.Entries[pindex++] = ZS.GFXManager.loadedPalettes[x, y];
				}
			}

			for (int y = 0; y < ZS.GFXManager.loadedSprPalettes.GetLength(1); y++)
			{
				for (int x = 0; x < ZS.GFXManager.loadedSprPalettes.GetLength(0); x++)
				{
					if (pindex < 256)
					{
						palettes.Entries[pindex++] = ZS.GFXManager.loadedSprPalettes[x, y];
					}
				}
			}

			for (int i = 0; i < Constants.TotalPaletteSize; i += Constants.ColorsPerHalfPalette)
			{
				palettes.Entries[i] = Color.Transparent;
			}

			ZS.GFXManager.roomBg1Bitmap.Palette = palettes;
			ZS.GFXManager.roomBg2Bitmap.Palette = palettes;
			ZS.GFXManager.roomBgLayoutBitmap.Palette = palettes;
		}

		public void SetPalettesBlack()
		{
			int pindex = 0;
			ColorPalette palettes = ZS.GFXManager.roomBg1Bitmap.Palette;
			for (int y = 0; y < ZS.GFXManager.loadedPalettes.GetLength(1); y++)
			{
				for (int x = 0; x < ZS.GFXManager.loadedPalettes.GetLength(0); x++)
				{
					palettes.Entries[pindex++] = ZS.GFXManager.loadedPalettes[x, y];
				}
			}

			for (int i = 0; i < Constants.TotalPaletteSize; i += Constants.ColorsPerHalfPalette)
			{
				palettes.Entries[i] = Color.Black;
			}

			ZS.GFXManager.roomBg1Bitmap.Palette = palettes;
			ZS.GFXManager.roomBg2Bitmap.Palette = palettes;
			ZS.GFXManager.roomBgLayoutBitmap.Palette = palettes;
		}

		private unsafe void OnMouseUp(object sender, MouseEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void OnMouseDoubleClick(object sender, MouseEventArgs e)
		{
			throw new NotImplementedException();
		}

		public void addChest()
		{
			throw new NotImplementedException();
		}

		public void deleteChestItem()
		{
			throw new NotImplementedException();
		}

		public void deleteCollisionMapTile()
		{
			throw new NotImplementedException();
		}

		public void clearCustomCollisionMap()
		{
			throw new NotImplementedException();
		}

		public void setObjectsPosition()
		{
			throw new NotImplementedException();
		}

		// TODO switch statements and no casting the selected mode
		public void setMouseSizeMode(MouseEventArgs e)
		{
			throw new NotImplementedException();
		}

		public bool isMouseCollidingWith<T>(T o, MouseEventArgs e) where T : IMouseCollidable
		{
			ZS.MainForm.GetXYMouseBasedOnZoom(e, out int MX, out int MY);

			return o.PointIsInHitbox(MX, MY);
		}

		public void getObjectsRectangle()
		{
			throw new NotImplementedException();
		}

		// TODO move to main form
		public void updateSelectionObject(object o)
		{
			throw new NotImplementedException();
		}


		public void SelectAll()
		{
			throw new NotImplementedException();
		}

		public void Delete()
		{
			throw new NotImplementedException();
		}

		public void Paste()
		{
			throw new NotImplementedException();
		}

		public void Copy()
		{
			throw new NotImplementedException();
		}

		public void Cut()
		{
			throw new NotImplementedException();
		}

		public void insertNew()
		{
			throw new NotImplementedException();
		}

		public void DecreaseSelectedZ()
		{
			throw new NotImplementedException();
		}

		public void UpdateSelectedZ(int position)
		{
			throw new NotImplementedException();
		}

		public void updateRoomInfos(DungeonMain mainForm)
		{
			mainForm.UpdateUIForRoom(Room, true);
		}
	}
}
