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
	[Serializable]
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

	}
}
