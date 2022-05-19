using System.Text.RegularExpressions;

namespace ZeldaFullEditor
{
	/// <summary>
	/// Class for consistency with text that is visible to the user.
	/// </summary>
	public static class UIText
	{
		//===========================================================================================
		// META
		//===========================================================================================
		public const string APPNAME = "ZScream";
		public const string VERSION = "4.0.0";

		public const string GITHUB = "https://github.com/Zarby89/ZScreamDungeon";
		public const string DISCORD = "https://discord.gg/8eJdz2YdW2";

		//===========================================================================================
		// File explorer
		//===========================================================================================
		public const string ROMExtension = ".sfc";
		public const string JPROMType = "ALTTP JP1.0 ROM Image|*.sfc;*.smc";
		public const string USROMType = "ALTTP US ROM Image|*.sfc;*.smc";
		public const string SNESROMType = "SNES ROM Image|*" + ROMExtension;

		public const string TestROM = "temp" + ROMExtension;

		public const string LayoutFolder = "Layout";

		public const string ExportedRoomDataExtension = ".zrd";
		public const string ExportedRoomDataType = "ZScream Room Data|*" + ExportedRoomDataExtension;

		public const string ExportedSpriteDataExtension = ".zsd";
		public const string ExportedSpriteDataType = "ZScream Sprite Data|*" + ExportedSpriteDataExtension;

		public const string ExportedOWMapDataExtension = ".zmd";
		public const string ExportedOWMapDataType = "ZScream Map Data|*" + ExportedOWMapDataExtension;

		public const string ExportedTileDataExtension = ".ztd";
		public const string ExportedTileDataType = "ZScream Tile Data|*" + ExportedTileDataExtension;

		public const string ExportedPaletteDataExtension = ".zpd";
		public const string ExportedPaletteDataType = "ZScream Palette Data|*" + ExportedPaletteDataExtension;

		public const string BMP8Type = "Indexed Image File (8 bits per pixel)|*.bmp";

		//===========================================================================================
		// Warnings
		//===========================================================================================
		public const string Range0toFF = "The selected value must be between 0x00 and 0xFF, inclusive.";

		//===========================================================================================
		// Formatting
		//===========================================================================================
		public const string NullField = "-";

		/// <summary>
		/// Returns a path with system-specific path separators, where each argument is a different segment of the file path.
		/// </summary>
		public static string GetFileName(params string[] p)
		{
			StringBuilder ret = new StringBuilder((p.Length * 2) - 1);
			int i = p.Length;
			foreach (string s in p)
			{
				ret.Append(s);
				if (--i > 0)
				{
					ret.Append(Path.DirectorySeparatorChar);
				}
			}
			return ret.ToString();
		}

		//===========================================================================================
		// Messages
		//===========================================================================================
		public const string DefaultWarning = "You have unsaved changes that will be lost.";
		public const string RoomWarning = "You have unsaved room changes that will be lost by closing this tab.";
		public const string CloseROMWarning = "Closing this ROM will result in all unsaved changes being lost.";

		public static DialogResult WarnAboutSaving(string message = DefaultWarning)
		{
			return MessageBox.Show(
					$"{message}\nDo you wish to save before continuing?",
					"Unsaved changes",
					MessageBoxButtons.YesNoCancel,
					MessageBoxIcon.Warning
				);
		}

		public static void GeneralWarning(string message)
		{
			MessageBox.Show(
				message,
				"Warning",
				MessageBoxButtons.OK,
				MessageBoxIcon.Warning
			);
		}

		public static void CryAboutSaving(string message = "OHNO")
		{
			MessageBox.Show
			(
				"Failed to save;\n" + message,
				"Bad Error",
				MessageBoxButtons.OK
			);
		}

		//===========================================================================================
		// Extension functions
		//===========================================================================================
		public static string ToFormattedString(this RoomObjectCategory b)
		{
			return string.Join(" ", Regex.Split(b.ToString(), @"[A-Z]", RegexOptions.None));
		}

		public static string ToLayerString(this RoomLayer l) => l switch
		{
			RoomLayer.Layer1 => "Layer 1",
			RoomLayer.Layer2 => "Layer 2",
			RoomLayer.Layer3 => "Mask layer",
			_ => "None",
		};

		public static string ToSimpleListing(this byte[] bl)
		{
			StringBuilder ret = new StringBuilder(bl.Length * 2 - 1);
			int i = bl.Length;
			foreach (byte b in bl)
			{
				ret.Append(b.ToString("X2"));
				if (--i > 0)
				{
					ret.Append(' ');
				}
			}
			return ret.ToString();
		}
	}
}
