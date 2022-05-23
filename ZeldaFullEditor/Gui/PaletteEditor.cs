namespace ZeldaFullEditor.Gui
{
	public partial class PaletteEditor : UserControl
	{
		private readonly Color[][] HudPal = new Color[2][];
		private readonly Color[][] OverworldMainPal = new Color[6][];
		private readonly Color[][] OverworldAuxPal = new Color[20][];
		private readonly Color[][] OverworldAnimatedPal = new Color[14][];
		private readonly Color[][] DungeonMainPal = new Color[20][];
		private readonly Color[][] GlobalSpritesPal = new Color[2][];
		private readonly Color[][] SpritesAux1Pal = new Color[12][];
		private readonly Color[][] SpritesAux2Pal = new Color[11][];
		private readonly Color[][] SpritesAux3Pal = new Color[24][];
		private readonly Color[][] ShieldsPal = new Color[3][];
		private readonly Color[][] SwordsPal = new Color[4][];
		private readonly Color[][] ArmorsPal = new Color[5][];

		Color tempColor;
		int tempIndex = -1;

		private readonly ColorDialog cd = new();

		private PartialPalette selectedPalette = null;
		int selectedX = 16;

		public PaletteEditor()
		{

			BackColor = Color.FromKnownColor(KnownColor.Control);
			InitializeComponent();

			CreateTempPalettes();
			// Create temp of all palettes
			for (int i = 0; i < 2; i++)
			{
				palettesTreeView.Nodes["HudPal"].Nodes.Add("Hud " + i.ToString("D2"));
			}

			for (int i = 0; i < 6; i++)
			{
				palettesTreeView.Nodes["OverworldMainPal"].Nodes.Add("Main " + i.ToString("D2"));
			}

			for (int i = 0; i < 20; i++)
			{
				palettesTreeView.Nodes["OverworldAuxPal"].Nodes.Add("Aux " + i.ToString("D2"));
			}

			for (int i = 0; i < 14; i++)
			{
				palettesTreeView.Nodes["OverworldAnimatedPal"].Nodes.Add("Animated " + i.ToString("D2"));
			}

			for (int i = 0; i < 20; i++)
			{
				palettesTreeView.Nodes["DungeonMainPal"].Nodes.Add("Main " + i.ToString("D2"));
			}

			for (int i = 0; i < 2; i++)
			{
				palettesTreeView.Nodes["GlobalSpritesPal"].Nodes.Add("Global " + i.ToString("D2"));
			}

			for (int i = 0; i < 12; i++)
			{
				palettesTreeView.Nodes["SpritesAux1Pal"].Nodes.Add("Aux " + i.ToString("D2"));
			}

			for (int i = 0; i < 11; i++)
			{
				palettesTreeView.Nodes["SpritesAux2Pal"].Nodes.Add("Aux " + i.ToString("D2"));
			}

			for (int i = 0; i < 24; i++)
			{
				palettesTreeView.Nodes["SpritesAux3Pal"].Nodes.Add("Aux " + i.ToString("D2"));
			}

			for (int i = 0; i < 3; i++)
			{
				palettesTreeView.Nodes["ShieldsPal"].Nodes.Add("Shields " + i.ToString("D2"));
			}

			for (int i = 0; i < 4; i++)
			{
				palettesTreeView.Nodes["SwordsPal"].Nodes.Add("Swords " + i.ToString("D2"));
			}

			for (int i = 0; i < 5; i++)
			{
				palettesTreeView.Nodes["ArmorsPal"].Nodes.Add("Armors " + i.ToString("D2"));
			}
		}

		private void applyButton_Click(object sender, EventArgs e)
		{
			CreateTempPalettes();

			// Recreate temp of all palettes
		}

		private void PaletteEditor_Load(object sender, EventArgs e)
		{
			// TODO: Add something here?
		}

		private void restoreallButton_Click(object sender, EventArgs e)
		{
			// Restore temp of all palettes
			
			if (MessageBox.Show("Are you sure you want to restore all palettes " +
				"to the last applied values?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				RestoreallPalettes();
			}
		}

		private void restoreselButton_Click(object sender, EventArgs e)
		{
			restoreSelected();
			RefreshUnderworldGraphics();

			// Restore the temp selected palette only
		}

		private static void RefreshOverworld()
		{
			foreach (var s in ZScreamer.ActiveOW.allmaps)
			{
				s.MyArtist.ReloadPalettes();
				s.MyArtist.Invalidate();
			}

			ZScreamer.ActiveOWScene.Refresh();
		}

		private void RefreshUnderworldGraphics()
		{
			ZScreamer.ActiveUWScene.HardRefresh();
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

		private void restoreSelected()
		{
			var parent = palettesTreeView.SelectedNode.Parent;
			var pal = ZScreamer.ActivePaletteManager.GetPaletteAt((PaletteType) parent.Tag, palettesTreeView.SelectedNode.Index);

			throw new NotImplementedException();
			// need to write better back up system
			for (int i = 0; i < pal.RealSize; i++)
			{
				// pal.SetColorAt(i, )
			}

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

		private void CreateTempPalettes()
		{
			for (int i = 0; i < 2; i++)
			{
				HudPal[i] = new Color[ZScreamer.ActivePaletteManager.HUD[i].Length];
				for (int j = 0; j < ZScreamer.ActivePaletteManager.HUD[i].Length; j++)
				{
					HudPal[i][j] = ZScreamer.ActivePaletteManager.HUD[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 6; i++)
			{
				OverworldMainPal[i] = new Color[ZScreamer.ActivePaletteManager.OverworldMain[i].Length];
				for (int j = 0; j < ZScreamer.ActivePaletteManager.OverworldMain[i].Length; j++)
				{
					OverworldMainPal[i][j] = ZScreamer.ActivePaletteManager.OverworldMain[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 20; i++)
			{
				OverworldAuxPal[i] = new Color[ZScreamer.ActivePaletteManager.OverworldAux[i].Length];
				for (int j = 0; j < ZScreamer.ActivePaletteManager.OverworldAux[i].Length; j++)
				{
					OverworldAuxPal[i][j] = ZScreamer.ActivePaletteManager.OverworldAux[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 14; i++)
			{
				OverworldAnimatedPal[i] = new Color[ZScreamer.ActivePaletteManager.OverworldAnimated[i].Length];
				for (int j = 0; j < ZScreamer.ActivePaletteManager.OverworldAnimated[i].Length; j++)
				{
					OverworldAnimatedPal[i][j] = ZScreamer.ActivePaletteManager.OverworldAnimated[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 20; i++)
			{

				DungeonMainPal[i] = new Color[ZScreamer.ActivePaletteManager.UnderworldMain[i].Length];
				for (int j = 0; j < ZScreamer.ActivePaletteManager.UnderworldMain[i].Length; j++)
				{
					DungeonMainPal[i][j] = ZScreamer.ActivePaletteManager.UnderworldMain[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 2; i++)
			{
				GlobalSpritesPal[i] = new Color[ZScreamer.ActivePaletteManager.SpriteGlobal[i].Length];
				for (int j = 0; j < ZScreamer.ActivePaletteManager.SpriteGlobal[i].Length; j++)
				{
					GlobalSpritesPal[i][j] = ZScreamer.ActivePaletteManager.SpriteGlobal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 12; i++)
			{
				SpritesAux1Pal[i] = new Color[ZScreamer.ActivePaletteManager.SpriteAux1[i].Length];
				for (int j = 0; j < ZScreamer.ActivePaletteManager.SpriteAux1[i].Length; j++)
				{
					SpritesAux1Pal[i][j] = ZScreamer.ActivePaletteManager.SpriteAux1[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 11; i++)
			{
				SpritesAux2Pal[i] = new Color[ZScreamer.ActivePaletteManager.SpriteAux2[i].Length];
				for (int j = 0; j < ZScreamer.ActivePaletteManager.SpriteAux2[i].Length; j++)
				{
					SpritesAux2Pal[i][j] = ZScreamer.ActivePaletteManager.SpriteAux2[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 24; i++)
			{
				SpritesAux3Pal[i] = new Color[ZScreamer.ActivePaletteManager.SpriteAux3[i].Length];
				for (int j = 0; j < ZScreamer.ActivePaletteManager.SpriteAux3[i].Length; j++)
				{
					SpritesAux3Pal[i][j] = ZScreamer.ActivePaletteManager.SpriteAux3[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 3; i++)
			{

				ShieldsPal[i] = new Color[ZScreamer.ActivePaletteManager.PlayerShield[i].Length];
				for (int j = 0; j < ZScreamer.ActivePaletteManager.PlayerShield[i].Length; j++)
				{
					ShieldsPal[i][j] = ZScreamer.ActivePaletteManager.PlayerShield[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 4; i++)
			{
				SwordsPal[i] = new Color[ZScreamer.ActivePaletteManager.PlayerSword[i].Length];
				for (int j = 0; j < ZScreamer.ActivePaletteManager.PlayerSword[i].Length; j++)
				{
					SwordsPal[i][j] = ZScreamer.ActivePaletteManager.PlayerSword[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 5; i++)
			{
				ArmorsPal[i] = new Color[ZScreamer.ActivePaletteManager.PlayerMail[i].Length];
				for (int j = 0; j < ZScreamer.ActivePaletteManager.PlayerMail[i].Length; j++)
				{
					ArmorsPal[i][j] = ZScreamer.ActivePaletteManager.PlayerMail[i][j].NewCopy();
				}
			}
		}

		private void RestoreallPalettes()
		{
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < ZScreamer.ActivePaletteManager.HUD[i].Length; j++)
				{
					ZScreamer.ActivePaletteManager.HUD[i][j] = HudPal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < ZScreamer.ActivePaletteManager.OverworldMain[i].Length; j++)
				{
					ZScreamer.ActivePaletteManager.OverworldMain[i][j] = OverworldMainPal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 20; i++)
			{
				for (int j = 0; j < ZScreamer.ActivePaletteManager.OverworldAux[i].Length; j++)
				{
					ZScreamer.ActivePaletteManager.OverworldAux[i][j] = OverworldAuxPal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 14; i++)
			{
				for (int j = 0; j < ZScreamer.ActivePaletteManager.OverworldAnimated[i].Length; j++)
				{
					ZScreamer.ActivePaletteManager.OverworldAnimated[i][j] = OverworldAnimatedPal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 20; i++)
			{
				for (int j = 0; j < ZScreamer.ActivePaletteManager.UnderworldMain[i].Length; j++)
				{
					ZScreamer.ActivePaletteManager.UnderworldMain[i][j] = DungeonMainPal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < ZScreamer.ActivePaletteManager.SpriteGlobal[i].Length; j++)
				{
					ZScreamer.ActivePaletteManager.SpriteGlobal[i][j] = GlobalSpritesPal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 12; i++)
			{
				for (int j = 0; j < ZScreamer.ActivePaletteManager.SpriteAux1[i].Length; j++)
				{
					ZScreamer.ActivePaletteManager.SpriteAux1[i][j] = SpritesAux1Pal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 11; i++)
			{
				for (int j = 0; j < ZScreamer.ActivePaletteManager.SpriteAux2[i].Length; j++)
				{
					ZScreamer.ActivePaletteManager.SpriteAux2[i][j] = SpritesAux2Pal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 24; i++)
			{
				for (int j = 0; j < ZScreamer.ActivePaletteManager.SpriteAux3[i].Length; j++)
				{
					ZScreamer.ActivePaletteManager.SpriteAux3[i][j] = SpritesAux3Pal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < ZScreamer.ActivePaletteManager.PlayerShield[i].Length; j++)
				{
					ZScreamer.ActivePaletteManager.PlayerShield[i][j] = ShieldsPal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < ZScreamer.ActivePaletteManager.PlayerSword[i].Length; j++)
				{
					ZScreamer.ActivePaletteManager.PlayerSword[i][j] = SwordsPal[i][j].NewCopy();
				}
			}

			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < ZScreamer.ActivePaletteManager.PlayerMail[i].Length; j++)
				{

					ZScreamer.ActivePaletteManager.PlayerMail[i][j] = ArmorsPal[i][j].NewCopy();
				}
			}

			RefreshUnderworldGraphics();
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

					for (int i = 0; i < 159; i++)
					{
						ZScreamer.ActiveOW.allmaps[i].MyArtist.ReloadPalettes();

					}

					RefreshOverworld();
					RefreshUnderworldGraphics();
				}
			}
		}

		private void palettePicturebox_MouseUp(object sender, MouseEventArgs e)
		{
			if (tempIndex != -1)
			{
				selectedPalette.SetColorAt(tempIndex, tempColor);
				for (int i = 0; i < 159; i++)
				{
					ZScreamer.ActiveOW.allmaps[i].MyArtist.ReloadPalettes();
				}

				RefreshOverworld();
				RefreshUnderworldGraphics();
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

				RefreshOverworld();
				RefreshUnderworldGraphics();
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

		private void ImportOrExportAllPalettes(bool export, byte[] buffer)
		{
			object[] order =
			{
					ZScreamer.ActivePaletteManager.HUD,
					ZScreamer.ActivePaletteManager.OverworldMain,
					ZScreamer.ActivePaletteManager.OverworldAux,
					ZScreamer.ActivePaletteManager.OverworldAnimated,
					ZScreamer.ActivePaletteManager.OverworldGrass,
					ZScreamer.ActivePaletteManager.SpriteGlobal,
					ZScreamer.ActivePaletteManager.PlayerMail,
					ZScreamer.ActivePaletteManager.PlayerSword,
					ZScreamer.ActivePaletteManager.PlayerShield,
					ZScreamer.ActivePaletteManager.SpriteAux1,
					ZScreamer.ActivePaletteManager.SpriteAux2,
					ZScreamer.ActivePaletteManager.SpriteAux3,
					ZScreamer.ActivePaletteManager.UnderworldMain
			};
			int count = 0;
			foreach (object o in order)
			{
				if (o is Color[][] block)
				{
					if (export)
					{
						ExportSinglePaletteBlock(block, buffer, ref count);
					}
					else
					{
						ImportSinglePaletteBlock(block, buffer, ref count);
					}
				}
				else if (o is Color[] palette)
				{
					if (export)
					{
						ExportSinglePalette(palette, buffer, ref count);
					}
					else
					{
						ImportSinglePalette(palette, buffer, ref count);
					}
				}
			}
		}
	}
}
