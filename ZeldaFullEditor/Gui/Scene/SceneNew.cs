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

namespace ZeldaFullEditor
{
	public abstract class Scene : PictureBox
	{
		public readonly ZScreamer ZS;

		public bool Active => ZS.ActiveScene == this;

		public bool MouseIsDown { get; set; }
		public int MouseX { get; protected set; }
		public int MouseY { get; protected set; }
		public int MoveX { get; protected set; }
		public int MoveY { get; protected set; }
		public int LastX { get; protected set; }
		public int LastY { get; protected set; }
		public int DraggingX { get; protected set; }
		public int DraggingY { get; protected set; }


		public bool NeedsRefreshing { get; set; }

		protected Scene(ZScreamer parent)
		{
			ZS = parent;
		}

		public virtual void drawText(Graphics g, int x, int y, string text, ImageAttributes ai = null, bool x2 = false)
		{
			if (showTexts)
			{
				text = text.ToUpper();
				int cpos = 0;
				int size = (ai == null && !x2) ? 16 : 8;
				int spacingmult = x2 ? 2 : 1;

				foreach (char c in text)
				{
					byte arrayPos = (byte) (c - 32);
					if ((byte) c == 10)
					{
						y += 10;
						cpos = 0;
						continue;
					}

					g.DrawImage(ZS.GFXManager.spriteFont,
						new Rectangle(x + cpos, y, size, size), arrayPos * 8, 0, 8, 8, GraphicsUnit.Pixel, ai);

					if (arrayPos >= Constants.FontSpacings.Length)
					{
						cpos += 8;
						continue;
					}

					cpos += Constants.FontSpacings[arrayPos] * spacingmult;
				}
			}
		}


	}
}
