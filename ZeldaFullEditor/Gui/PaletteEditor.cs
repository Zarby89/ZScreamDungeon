namespace ZeldaFullEditor.Gui
{
	public partial class PaletteEditor : UserControl
	{
		Color tempColor;
		int tempIndex = -1;

		private readonly ColorDialog cd = new();

		private PartialPalette selectedPalette = null;
		int selectedX = 16;

		private readonly Dictionary<PartialPalette, PartialPalette> CachedPalettes = new();

		public PaletteEditor()
		{

			BackColor = Color.FromKnownColor(KnownColor.Control);
			InitializeComponent();
		}

		public void OnProjectLoad()
		{
			var pals = ZScreamer.ActivePaletteManager.AllPalettes;

			CachedPalettes.Clear();

			foreach (var (type, list) in pals)
			{
				// create UI element
				var text = type.ToString().Replace("Palette", String.Empty).SpaceOutString();
				var nodex = new TreeNode(text)
				{
					Name = type.ToString(),
					Tag = type,
				};

				int i = 0;
				foreach (var p in list)
				{
					CachedPalettes[p] = new(p);
					nodex.Nodes.Add($"{text} {i++:X2}");
				}
			}
		}

		private void applyButton_Click(object sender, EventArgs e)
		{
			UpdateCache();
		}

		private void UpdateCache()
		{
			foreach (var (orig, cache) in CachedPalettes)
			{
				cache.CopyColors(orig);
			}
		}

		private void RevertAll()
		{
			foreach (var (orig, cache) in CachedPalettes)
			{
				cache.CopyColors(orig);
			}
		}

		private void RevertSelectedPalette()
		{
			selectedPalette.CopyColors(CachedPalettes[selectedPalette]);
		}

		private void PaletteEditor_Load(object sender, EventArgs e)
		{
			// TODO: Add something here?
		}

		private void restoreallButton_Click(object sender, EventArgs e)
		{
			// Restore temp of all palettes
			
			if (UIText.VerifyWarning("You are about to restore all live palettes back to their latest cached state."))
			{
				RevertAll();
			}
		}

		private void restoreselButton_Click(object sender, EventArgs e)
		{
			RevertSelectedPalette();
			RefreshEveryone();

			// Restore the temp selected palette only
		}

		private void RefreshEveryone()
		{
			foreach (var s in ZScreamer.ActiveScreamer.all_rooms)
			{
				s.RefreshPalette();
			}

			ZScreamer.ActiveUWScene.HardRefresh();

			ZScreamer.ActiveOW.ForAllScreens(map => map.RefreshPalette());
			ZScreamer.ActiveOWScene.Refresh();

			palettePicturebox.Refresh();
		}

		private void palettesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			var parent = palettesTreeView.SelectedNode.Parent;
			var type = (PaletteType) parent.Tag;
			selectedPalette = ZScreamer.ActivePaletteManager.GetPaletteAt(type, palettesTreeView.SelectedNode.Index);

			selectedX = type.GetRealWidth();

			palettePicturebox.Refresh();
		}

		private void palettePicturebox_Paint(object sender, PaintEventArgs e)
		{
			if (selectedPalette is null)
			{
				e.Graphics.Clear(Color.FromKnownColor(KnownColor.Control));

			}
			else
			{
				int i = 0;
				foreach (var c in selectedPalette.GetNextColor())
				{
					if (c is not null) {
						e.Graphics.FillRectangle(
							new SolidBrush(((SNESColor) c).RealColor),
							new(i % 16 * 16, (i & ~0xF) * 16, 16, 16));
					}
				}
			}
		}

		private void palettePicturebox_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if ((e.X / 16) < selectedX && ((e.Y / 16) * selectedX) < selectedPalette.RealSize)
				{
					int cindex = (e.X / 16) + ((e.Y / 16) * selectedX);
					tempIndex = cindex;
					tempColor = selectedPalette.GetRealColorAt(cindex);
					// selectedPalette[cindex] = Color.Fuchsia;

					RefreshEveryone();
				}
			}
		}

		private void palettePicturebox_MouseUp(object sender, MouseEventArgs e)
		{
			if (tempIndex != -1)
			{
				selectedPalette.SetColorAt(tempIndex, tempColor);
				RefreshEveryone();
				tempIndex = -1;
			}
		}

		private void palettePicturebox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int cindex = -1;
			if ((e.X / 16) < selectedX && ((e.Y / 16) * selectedX) < selectedPalette.RealSize)
			{
				cindex = (e.X / 16) + ((e.Y / 16) * selectedX);
			}

			if (cindex != -1)
			{
				cd.Color = selectedPalette.GetRealColorAt(cindex);
				if (cd.ShowDialog() == DialogResult.OK)
				{
					selectedPalette.SetColorAt(cindex, cd.Color);
				}

				RefreshEveryone();
			}
		}

		private static void ExportSinglePaletteBlock(Color[][] paletteBlock, byte[] buffer, ref int count)
		{
			foreach (Color[] palette in paletteBlock)
			{
				ExportSinglePalette(palette, buffer, ref count);
			}
		}

		private static void ExportSinglePalette(Color[] palette, byte[] buffer, ref int count)
		{
			foreach (Color color in palette)
			{
				buffer[count++] = color.R;
				buffer[count++] = color.G;
				buffer[count++] = color.B;
			}
		}

		// Is called when the export palettes button is clicked, writes a .zpd file with all the palette colors.
		private void exportAllPalettes(object sender, EventArgs e)
		{

			using SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = UIText.ExportedPaletteDataType;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				byte[] colorArrayData = new byte[Constants.NumberOfColors * 3];
				ImportOrExportAllPalettes(export: true, colorArrayData);

				FileStream fileStreamMap = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write);

				fileStreamMap.Write(colorArrayData, 0, colorArrayData.Length);
				fileStreamMap.Close();
			}
		}

		private void importAllPalettes(object sender, EventArgs e)
		{
			using OpenFileDialog sfd = new OpenFileDialog();
			sfd.Filter = UIText.ExportedPaletteDataType;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				byte[] colorArrayData = new byte[Constants.NumberOfColors * 3];

				FileStream fileStreamMap = new FileStream(sfd.FileName, FileMode.Open, FileAccess.Read);
				fileStreamMap.Read(colorArrayData, 0, colorArrayData.Length);

				ImportOrExportAllPalettes(export: false, colorArrayData);
			}
		}

		private void ImportSinglePaletteBlock(Color[][] paletteBlock, byte[] buffer, ref int count)
		{
			for (int i = 0; i < paletteBlock.Length; i++)
			{
				ImportSinglePalette(paletteBlock[i], buffer, ref count);
			}
		}

		private void ImportSinglePalette(Color[] palette, byte[] buffer, ref int count)
		{
			for (int i = 0; i < palette.Length; i++)
			{
				palette[i] = Color.FromArgb(255, buffer[count++], buffer[count++], buffer[count++]);
			}
		}

		// TODO change this format and use a delegate and shit and all that
		private void ImportOrExportAllPalettes(bool export, byte[] buffer)
		{
			//object[] order =
			//{
			//		ZScreamer.ActivePaletteManager.HUD,
			//		ZScreamer.ActivePaletteManager.OverworldMain,
			//		ZScreamer.ActivePaletteManager.OverworldAux,
			//		ZScreamer.ActivePaletteManager.OverworldAnimated,
			//		ZScreamer.ActivePaletteManager.OverworldGrass,
			//		ZScreamer.ActivePaletteManager.SpriteGlobal,
			//		ZScreamer.ActivePaletteManager.PlayerMail,
			//		ZScreamer.ActivePaletteManager.PlayerSword,
			//		ZScreamer.ActivePaletteManager.PlayerShield,
			//		ZScreamer.ActivePaletteManager.SpriteAux1,
			//		ZScreamer.ActivePaletteManager.SpriteAux2,
			//		ZScreamer.ActivePaletteManager.SpriteAux3,
			//		ZScreamer.ActivePaletteManager.UnderworldMain
			//};
			//int count = 0;
			//foreach (object o in order)
			//{
			//	if (o is Color[][] block)
			//	{
			//		if (export)
			//		{
			//			ExportSinglePaletteBlock(block, buffer, ref count);
			//		}
			//		else
			//		{
			//			ImportSinglePaletteBlock(block, buffer, ref count);
			//		}
			//	}
			//	else if (o is Color[] palette)
			//	{
			//		if (export)
			//		{
			//			ExportSinglePalette(palette, buffer, ref count);
			//		}
			//		else
			//		{
			//			ImportSinglePalette(palette, buffer, ref count);
			//		}
			//	}
			//}
		}
	}
}
