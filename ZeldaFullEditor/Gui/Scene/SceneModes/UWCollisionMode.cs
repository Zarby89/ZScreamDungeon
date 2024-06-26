﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Data.Underworld;

namespace ZeldaFullEditor
{
	public partial class SceneUW
	{
		private void OnMouseDown_Collision(MouseEventArgs e)
		{

		}

		private void OnMouseUp_Collision(MouseEventArgs e)
		{
			// Nothing
		}

		private void OnMouseMove_Collision(MouseEventArgs e)
		{

		}

		private void Draw_Collision(Graphics g)
		{
			int i = 0;
			foreach (byte? b in Room.CollisionMap)
			{
				if (b != null)
				{
					drawText(g, (i % 64 * 16) + 4, i / 64 * 16 + 4, ((byte) b).ToString("X2"));
				}
				i++;
			}
		}
	}
}
