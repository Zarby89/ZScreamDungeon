﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor.Gui.MainTabs
{
	public partial class SpriteEditor : ScreamControl
	{
		public SpriteEditor(ZScreamer zs) : base(zs)
		{
			InitializeComponent();
		}
	}
}
