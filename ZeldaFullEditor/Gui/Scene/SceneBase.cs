using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor
{
	public class Scene : PictureBox
	{
		public bool active = false;
		public bool found = false;
		public bool mouse_down = false;
		public int mx = 0;
		public int my = 0;
		public int last_mx = 0;
		public int last_my = 0;
		public int dragx = 0;
		public int dragy = 0;
		public int move_x = 0;
		public int move_y = 0;
		public bool selection_resize = false;
		public bool need_refresh = false;
		public Rectangle[] doorArray = new Rectangle[48];
		public Room room;
		public ObjectMode selectedMode;
		public bool showTexts = true;
		public bool showLayer1 = true;
		public bool showLayer2 = true;
		public bool showGrid = false;
		public bool showSpriteText = false;
		public bool showBG2Outline = true;
		public DungeonMain mainForm;
		public bool canSelectUnselectedBG = true;
		public bool isDungeon = true;
		//public List<Room> undoRooms = new List<Room>();
		//public List<Room> redoRooms = new List<Room>();
		//public PickObject pObj = new PickObject();
		public SelectedObject selectedDragObject = null;
		public SelectedObject selectedDragSprite = null;
		public bool updating_info = false;

		byte[] spriteFontSpacing = Utils.DeepCopyBytes(Constants.FontSpacings);

		public void drawText(Graphics g, int x, int y, string text, ImageAttributes ai = null, bool x2 = false)
		{
			if (showTexts)
			{
				text = text.ToUpper();
				int cpos = 0;
				for (int i = 0; i < text.Length; i++)
				{
					byte arrayPos = (byte) (text[i] - 32);
					if ((byte) text[i] == 10)
					{
						y += 10;
						cpos = 0;
						continue;
					}

					if (ai == null)
					{
						if (x2)
						{
							g.DrawImage(GFX.spriteFont, new Rectangle(x + cpos, y, 16, 16), arrayPos * 8, 0, 8, 8, GraphicsUnit.Pixel);
						}
						else
						{
							g.DrawImage(GFX.spriteFont, new Rectangle(x + cpos, y, 8, 8), arrayPos * 8, 0, 8, 8, GraphicsUnit.Pixel);
						}
					}
					else
					{
						g.DrawImage(GFX.spriteFont, new Rectangle(x + cpos, y, 8, 8), arrayPos * 8, 0, 8, 8, GraphicsUnit.Pixel, ai);
					}

					if (arrayPos > spriteFontSpacing.Length - 1)
					{
						cpos += 8;
						continue;
					}

					if (x2)
					{
						cpos += (spriteFontSpacing[arrayPos] * 2);
					}
					else
					{
						cpos += spriteFontSpacing[arrayPos];
					}
				}
			}
		}

		public virtual void Clear()
		{
			//T ODO: Add something here?
		}

		public virtual void deleteSelected()
		{
			// TODO: Add something here?
		}

		public virtual void selectAll()
		{
			// TODO: Add something here?
		}

		public virtual void copy()
		{
			// TODO: Add something here?
		}
		public virtual void cut()
		{
			// TODO: Add something here?
		}
		public virtual void paste()
		{
			// TODO: Add something here?
		}
		public virtual void insertNew()
		{
			// TODO: Add something here?
		}
		public virtual void SendSelectedToBack()
		{
			// TODO: Add something here?
		}
		public virtual void UpdateSelectedZ(int i)
		{
			// TODO: Add something here?
		}
		public virtual void changeObject()
		{
			// TODO: Add something here?
		}
		public virtual void loadLayout()
		{
			// TODO: Add something here?
		}
		public virtual void DecreaseSelectedZ()
		{
			// TODO: Add something here?
		}

		public void drawSelection(Graphics graphics)
		{
			foreach (Object o in room.selectedObject)
			{
				if (o is Sprite sb)
				{
					graphics.DrawRectangle(new Pen(new SolidBrush(Settings.Default.ObjectLastSelectedColor), 1), sb.boundingbox);
				}
				else if (o is PotItem pp)
				{
					graphics.DrawRectangle(new Pen(new SolidBrush(Settings.Default.ObjectLastSelectedColor), 1), new Rectangle(pp.nx * 8, pp.ny * 8, 16, 16));
				}
				else if (o is Room_Object obj)
				{
					int yfix = 0;
					if (obj.diagonalFix)
					{
						yfix = -(6 + obj.Size);
					}
					graphics.DrawRectangle(new Pen(new SolidBrush(Settings.Default.ObjectLastSelectedColor), 1), new Rectangle((obj.nx + obj.offsetX) * 8, (obj.ny + obj.offsetY + yfix) * 8, obj.width, obj.height));
				}
			}

			if (showBG2Outline)
			{
				if (room.bg2 != Background2.Off)
				{
					foreach (Room_Object obj in room.tilesObjects)
					{
						// Draw doors here since they'll all be put on bg3 anyways
						if (obj.showRectangle)
						{
							int yfix = 0;
							if (obj.diagonalFix)
							{
								yfix = -(6 + obj.Size);
							}

							graphics.DrawRectangle(new Pen(new SolidBrush(Settings.Default.BG2MaskColor), 1),
								new Rectangle((obj.nx + obj.offsetX) * 8,
								(obj.ny + obj.offsetY + yfix) * 8,
								obj.width, obj.height));
						}
					}
				}
			}

			if (mouse_down)
			{
				int rx = dragx;
				int ry = dragy;
				if (move_x < 0) { Math.Abs(rx = dragx + move_x); }
				if (move_y < 0) { Math.Abs(ry = dragy + move_y); }

				if (room.selectedObject.Count == 0)
				{
					if (selectedMode == ObjectMode.Spritemode)
					{
						graphics.DrawRectangle(new Pen(new SolidBrush(Settings.Default.SelectionBoxColor), 1), new Rectangle(rx * 16, ry * 16, Math.Abs(move_x) * 16, Math.Abs(move_y) * 16));
					}
					else
					{
						graphics.DrawRectangle(new Pen(new SolidBrush(Settings.Default.SelectionBoxColor), 1), new Rectangle(rx * 8, ry * 8, Math.Abs(move_x) * 8, Math.Abs(move_y) * 8));
					}
				}

				foreach (Object o in room.selectedObject)
				{
					if (o is Sprite sb)
					{
						graphics.DrawRectangle(new Pen(new SolidBrush(Settings.Default.ObjectSelectedColor), 1), sb.boundingbox);
					}
					else if (o is PotItem pp)
					{
						graphics.DrawRectangle(new Pen(new SolidBrush(Settings.Default.ObjectSelectedColor), 1), new Rectangle(pp.nx * 8, pp.ny * 8, 16, 16));
					}
					else if (o is Room_Object obj)
					{
						int yfix = 0;
						if (obj.diagonalFix)
						{
							yfix = -(6 + obj.Size);
						}

						graphics.DrawRectangle(new Pen(new SolidBrush(Settings.Default.ObjectSelectedColor), 1), new Rectangle((obj.nx + obj.offsetX) * 8, (obj.ny + obj.offsetY + yfix) * 8, obj.width, obj.height));
					}
				}
			}
		}

		public void drawEntrancePosition()
		{
			// TODO: Add something here?
		}

		public void drawDoorsPosition()
		{
			// TODO: Add something here?

			/*
            if (mouse_down)
            {
                if (room.selectedObject.Count > 0)
                {
                    if (room.selectedObject[0] is Room_Object)
                    {
                        if (((room.selectedObject[0] as Room_Object).options & ObjectOption.Door) == ObjectOption.Door)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                graphics.DrawRectangles(new Pen(new SolidBrush(Color.FromArgb(10, 0, 200, 0))), doorArray);
                            }
                        }
                    }
                }
            }
            */
		}

		private void InitializeComponent()
		{
			((System.ComponentModel.ISupportInitialize) (this)).BeginInit();
			this.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this)).EndInit();
			this.ResumeLayout(false);
		}

		// END OF DRAW CODE
	}
}
