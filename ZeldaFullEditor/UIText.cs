using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	/// <summary>
	/// Class for all text that is visible to the user.
	/// </summary>
	public static class UIText
	{

		//===========================================================================================
		// META
		//===========================================================================================
		public const string APPNAME = "ZScream";
		public const string VERSION = "1.0.3 Doodoo";

		public const string GITHUB = "https://github.com/Zarby89/ZScreamDungeon";
		public const string DISCORD = "https://discord.gg/8eJdz2YdW2";


		//===========================================================================================
		// File explorer
		//===========================================================================================
		public const string ROMExtension = ".sfc";
		public const string JPROMType = "ALTTP JP1.0 ROM Image|*.sfc;*.smc";
		public const string USROMType = "ALTTP US ROM Image|*.sfc;*.smc";
		public const string SNESROMType = "SNES ROM Image|*.sfc";

		public const string TestROM = "temp.sfc";

		public const string LayoutFolder = "Layout";

		public const string ExportedRoomDataExtension = ".zrd";
		public const string ExportedRoomDataType = "ZScream Room Data|*" + ExportedRoomDataExtension;
		public const string ExportedSpriteDataExtension = ".zsd";
		public const string ExportedSpriteDataType = "ZScream Sprite Data|*" + ExportedSpriteDataExtension;
		public const string ExportedOWMapDataExtension = ".zmd";
		public const string ExportedOWMapDataType = "ZScream Map Data|*" + ExportedOWMapDataExtension;
		public const string ExportedTileDataExtension = ".ztd";
		public const string ExportedTileDataType = "ZScream Tile Data|*" + ExportedTileDataExtension;

		public const string BMP8Type = "Indexed Image File (8 bits per pixel)|*.bmp";

		//===========================================================================================
		// Warnings
		//===========================================================================================
		public const string Range0toFF = "The selected value must be between 0x00 and 0xFF, inclusive.";



		public static string FormatSelectedObject(Room_Object o)
		{
			switch (o.options)
			{
				case ObjectOption.Torch:
					return string.Format("Selected object: {0:02X} torch", o.id);

				default:
					return string.Format("Selected object: {0:04X} {1}", o.id, o.name);
			}
		}

		public static string FormatSelectedSprite(Sprite s, string n)
		{
			return string.Format("Selected sprite: {0:02X} {1}", s.id, n);
		}
		public static string FormatSelectedPotItem(PotItem p, string n)
		{
			return string.Format("Selected prize: {0:02X} {1}", p.id, n);
		}
	}
}
