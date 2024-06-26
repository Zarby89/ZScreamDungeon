﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeldaFullEditor.Data.Underworld;

namespace ZeldaFullEditor
{
	public partial class SceneUW
	{
		private void OnMouseDown_Torch(MouseEventArgs e)
		{

		}

		private void OnMouseUp_Torch(MouseEventArgs e)
		{

		}

		private void OnMouseMove_Torch(MouseEventArgs e)
		{

		}

		private void Copy_Torch()
		{

		}

		private void Paste_Torch()
		{

		}

		private void Delete_Torch()
		{
			Room.RemoveCurrentlySelectedObjectsFromList(Room.TorchList);
		}

		private void Insert_Torch()
		{
			var b = new DungeonTorch()
			{
				GridX = (byte) MouseX,
				GridY = (byte) MouseY,
				Layer = 0,
			};

			Room.AttemptToAddEntityAsSelected(b, CurrentMode);
		}

		private void SelectAll_Torch()
		{
			Room.ClearSelectedList();
			Room.SelectedObjects.AddRange(Room.TorchList);
		}
	}
}
