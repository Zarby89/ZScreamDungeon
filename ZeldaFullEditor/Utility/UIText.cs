namespace ZeldaFullEditor.Utility;

/// <summary>
/// Contains methods and fields for consistency with text that is visible to the user.
/// </summary>
internal static class UIText
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

	public const string TestROM = $"temp{ROMExtension}";

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
	public static string CreateFilePath(params string[] p)
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

	/// <summary>
	/// Prompts the user to verify an action that will result in the loss of unsaved changes
	/// with the following behavior expected to be taken after the user responds:
	/// <list type="bullet">
	/// <item>Yes will perform the action after saving the changes.</item>
	/// <item>No will perform the action after discarding the changes.</item>
	/// <item>Cancel will abort the action and leave the changes unsaved.</item>
	/// </list>
	/// </summary>
	/// <returns>A <see cref="DialogResult"/> specifying the user's selection.</returns>
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

	/// <summary>
	/// Prompts users to verify a drastic change.
	/// </summary>
	/// <returns>
	/// Returns <see langword="true"/> if the user selects "Yes" and
	/// <see langword="false"/> if the use selects "No".
	/// </returns>
	public static bool VerifyWarning(string message)
	{
		return MessageBox.Show(
			$"{message}\nAre you sure you wish to perform this action?",
			"Confirm action",
			MessageBoxButtons.YesNo,
			MessageBoxIcon.Warning
		) == DialogResult.Yes;
	}
	public static void CryAboutSaving(string message = "OHNO")
	{
		MessageBox.Show
		(
			"Failed to save:\n" + message,
			"Bad Error",
			MessageBoxButtons.OK
		);
	}

	//===========================================================================================
	// Extension functions
	//===========================================================================================
	public static string ToLayerString(this RoomLayer l) => l switch
	{
		RoomLayer.Layer1 => "Layer 1",
		RoomLayer.Layer2 => "Layer 2",
		RoomLayer.Layer3 => "Mask layer",
		_ => "None",
	};

	/// <summary>
	/// Splits a PascalCase string into individual words by adding spaces between capital letters and numbers.
	/// </summary>
	public static string SpaceOutString(this string s)
	{
		return string.Join(" ", Regex.Split(s.ToString(), @"(?=[A-Z]|\d+)", RegexOptions.None));
	}

	/// <summary>
	/// Formats an array of <see langword="byte"/> values as unqualified hexadecimal values
	/// delimited by a single space.
	/// </summary>
	/// <returns>A <see langword="string"/> representing the data within this array.</returns>
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
