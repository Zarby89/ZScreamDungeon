using System;
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
		private void OnMouseDown_Blocks(MouseEventArgs e)
		{
			Program.MainForm.GetXYMouseBasedOnZoom(e, out int MX, out int MY);
		}

		private void OnMouseUp_Blocks(MouseEventArgs e)
		{
			// Nothing
		}

		private void OnMouseMove_Blocks(MouseEventArgs e)
		{

		}

		private void Copy_Blocks()
		{

		}

		private void Paste_Blocks()
		{

		}

		private void Delete_Blocks()
		{
			Room.RemoveCurrentlySelectedObjectsFromList(Room.BlocksList);
		}
		
		private void Insert_Blocks()
		{
			var b = new DungeonBlock()
			{
				GridX = (byte) MouseX,
				GridY = (byte) MouseY,
				Layer = 0,
			};

			Room.AttemptToAddEntityAsSelected(b, CurrentMode);
		}

		private void SelectAll_Blocks()
		{
			Room.ClearSelectedList();
			Room.SelectedObjects.AddRange(Room.BlocksList);
		}
	}
}
