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
using static ZeldaFullEditor.DungeonMain;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ZeldaFullEditor
{
//	[Serializable]
//	public class Scene2 : PictureBox
//	{
//		public readonly ZScreamer ZS;
//
//		public bool active = false;
//		public bool found = false;
//		public bool mouse_down = false;
//		public int mx = 0;
//		public int my = 0;
//		public int last_mx = 0;
//		public int last_my = 0;
//		public int dragx = 0;
//		public int dragy = 0;
//		public int move_x = 0;
//		public int move_y = 0;
//		public bool selection_resize = false;
//		public bool need_refresh = false;
//		public Rectangle[] doorArray = new Rectangle[48];
//		public Room room;
//		public bool showTexts = true;
//		public bool showLayer1 = true;
//		public bool showLayer2 = true;
//		public bool showGrid = false;
//		public bool showSpriteText = false;
//		public bool showBG2Outline = true;
//		public bool canSelectUnselectedBG = true;
//		public bool isDungeon = true;
//		//public List<Room> undoRooms = new List<Room>();
//		//public List<Room> redoRooms = new List<Room>();
//		//public PickObject pObj = new PickObject();
//		public dataObject selectedDragObject = null;
//		public dataObject selectedDragSprite = null;
//		public bool updating_info = false;
//
//		byte[] spriteFontSpacing = Constants.FontSpacings.DeepCopy();
//
//		public Scene2(ZScreamer zs = null)
//		{
//			ZS = zs ?? new ZScreamer(22);
//		}
//		//public Scene()
//		//{
//		//	ZS = new ZScreamer(22);
//		//}
//
//		public void drawText(Graphics g, int x, int y, string text, ImageAttributes ai = null, bool x2 = false)
//		{
//			if (showTexts)
//			{
//				text = text.ToUpper();
//				int cpos = 0;
//				for (int i = 0; i < text.Length; i++)
//				{
//					byte arrayPos = (byte) (text[i] - 32);
//					if ((byte) text[i] == 10)
//					{
//						y += 10;
//						cpos = 0;
//						continue;
//					}
//
//					if (ai == null)
//					{
//						if (x2)
//						{
//							g.DrawImage(ZS.GFXManager.spriteFont, new Rectangle(x + cpos, y, 16, 16), arrayPos * 8, 0, 8, 8, GraphicsUnit.Pixel);
//						}
//						else
//						{
//							g.DrawImage(ZS.GFXManager.spriteFont, new Rectangle(x + cpos, y, 8, 8), arrayPos * 8, 0, 8, 8, GraphicsUnit.Pixel);
//						}
//					}
//					else
//					{
//						g.DrawImage(ZS.GFXManager.spriteFont, new Rectangle(x + cpos, y, 8, 8), arrayPos * 8, 0, 8, 8, GraphicsUnit.Pixel, ai);
//					}
//
//					if (arrayPos > spriteFontSpacing.Length - 1)
//					{
//						cpos += 8;
//						continue;
//					}
//
//					if (x2)
//					{
//						cpos += (spriteFontSpacing[arrayPos] * 2);
//					}
//					else
//					{
//						cpos += spriteFontSpacing[arrayPos];
//					}
//				}
//			}
//		}
//
//
//		//public virtual void SetMode(ObjectMode o)
//		//{
//		//
//		//}
//
//
//		public virtual void Clear()
//		{
//			// TODO: Add something here?
//		}
//
//		public virtual void Delete()
//		{
//			// TODO: Add something here?
//		}
//
//		public virtual void selectAll()
//		{
//			// TODO: Add something here?
//		}
//
//		public virtual void Copy()
//		{
//			// TODO: Add something here?
//		}
//		public virtual void Cut()
//		{
//			// TODO: Add something here?
//		}
//		public virtual void Paste()
//		{
//			// TODO: Add something here?
//		}
//		public virtual void insertNew()
//		{
//			// TODO: Add something here?
//		}
//		public virtual void SendSelectedToBack()
//		{
//			// TODO: Add something here?
//		}
//		public virtual void UpdateSelectedZ(int i)
//		{
//			// TODO: Add something here?
//		}
//		public virtual void changeObject()
//		{
//			// TODO: Add something here?
//		}
//		public virtual void loadLayout()
//		{
//			// TODO: Add something here?
//		}
//		public virtual void DecreaseSelectedZ()
//		{
//			// TODO: Add something here?
//		}
//
//
//		public void drawEntrancePosition()
//		{
//			// TODO: Add something here?
//		}
//
//		public void drawDoorsPosition()
//		{
//			// TODO: Add something here?
//
//			/*
//            if (mouse_down)
//            {
//                if (room.selectedObject.Count > 0)
//                {
//                    if (room.selectedObject[0] is Room_Object)
//                    {
//                        if (((room.selectedObject[0] as Room_Object).options & ObjectOption.Door) == ObjectOption.Door)
//                        {
//                            for (int i = 0; i < 12; i++)
//                            {
//                                graphics.DrawRectangles(new Pen(new SolidBrush(Color.FromArgb(10, 0, 200, 0))), doorArray);
//                            }
//                        }
//                    }
//                }
//            }
//            */
//		}
//
//		// END OF DRAW CODE
//	}
}
