﻿global using System;
global using System.Collections.Generic;
global using System.Collections.Immutable;
global using System.ComponentModel;
global using System.Data;
global using System.Diagnostics;
global using System.Drawing;
global using System.Drawing.Drawing2D;
global using System.Drawing.Imaging;
global using System.Globalization;
global using System.IO;
global using System.Linq;
global using System.Reflection;
global using System.Runtime.InteropServices;
global using System.Text;
global using System.Threading;
global using System.Windows.Forms;

global using System.Text.RegularExpressions;

global using ZCompressLibrary;

global using ZeldaFullEditor.Data;
global using ZeldaFullEditor.Gui;
global using ZeldaFullEditor.Gui.ExtraForms;
global using ZeldaFullEditor.Gui.MainTabs;
global using ZeldaFullEditor.Handler;
global using ZeldaFullEditor.ALTTP;
global using ZeldaFullEditor.ALTTP.GameData;
global using ZeldaFullEditor.ALTTP.GameData.Defaults;
global using ZeldaFullEditor.ALTTP.GameData.GraphicsData;
global using ZeldaFullEditor.ALTTP.GameData.GraphicsData.GraphicsTiles;
global using ZeldaFullEditor.ALTTP.GameData.GraphicsData.Palettes;
global using ZeldaFullEditor.ALTTP.Overworld;
global using ZeldaFullEditor.ALTTP.Underworld;
global using ZeldaFullEditor.Properties;
global using ZeldaFullEditor.Utility;
global using ZeldaFullEditor.UserInterface.Drawing;
global using ZeldaFullEditor.UserInterface.Drawing.Artists;
global using ZeldaFullEditor.UserInterface.Drawing.SNESGraphics;
global using ZeldaFullEditor.UserInterface.GeneralControls;
global using ZeldaFullEditor.UserInterface.PrimaryEditors;
global using ZeldaFullEditor.UserInterface.UserControl;
global using ZeldaFullEditor.UserInterface.UserControl.Scene;

global using static ZeldaFullEditor.TheGUI;

namespace ZeldaFullEditor
{
	internal static class TheGUI {
		public static RoomArtist RoomEditingArtist { get; } = new RoomArtist(false);
		public static RoomArtist RoomPreviewArtist { get; } = new RoomArtist(true);

		public static ZScreamForm ZGUI = new();
	}
	
	static class Program
	{
		// var to keep track whether to show the console or not
		// 0 = dont show
		// 5 = show
		private static int showConsole = 0;

		[DllImport("kernel32.dll")]
		static extern IntPtr GetConsoleWindow();

		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetHighDpiMode(HighDpiMode.DpiUnawareGdiScaled);
			Application.SetCompatibleTextRenderingDefault(false);

			// Look for Command Line Arguments
			if (args != null)
			{
				// Loop through them all
				foreach (string arg in args)
				{
					// Look for hide console arg
					if (arg.Equals("-hideConsole"))
					{
						showConsole = 0;
					}

					// Look for show console arg
					if (arg.Equals("-showConsole"))
					{
						showConsole = 5;
					}

					// TODO: add other args
				}
			}

			// Hide console
			var handle = GetConsoleWindow();
			ShowWindow(handle, showConsole);

			// Run the app
			ZScreamer ZS = new ZScreamer();
			ZS.SetAsActiveScreamer();

			Application.Run(ZGUI);
		}
	}
}
