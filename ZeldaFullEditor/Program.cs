﻿//global using static ZeldaFullEditor.TheGUI;

global using System;
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
global using System.Runtime.InteropServices;
global using System.Text;
global using System.Threading;
global using System.Windows.Forms;
global using ZeldaFullEditor.Data;
global using ZeldaFullEditor.Data.Underworld;
global using ZeldaFullEditor.Gui;
global using ZeldaFullEditor.Gui.Drawing;
global using ZeldaFullEditor.Gui.MainTabs;
global using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor
{
	internal static class TheGUI{
		//public static DungeonMain DungeonForm { get; set; }
		//public static DungeonMain MainForm { get; set; }
		//public static OverworldEditor OverworldForm { get; set; }
		//public static TextEditor TextForm { get; set; }
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

		public static RoomArtist RoomEditingArtist { get; } = new RoomArtist(false);
		public static RoomArtist RoomPreviewArtist { get; } = new RoomArtist(true);

		public static DungeonEditor DungeonForm { get; set; }
		public static DungeonMain MainForm { get; set; }
		public static OverworldEditor OverworldForm { get; set; }
		public static TextEditor TextForm { get; set; }


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

			DungeonForm = new();
			MainForm = new DungeonMain();
			OverworldForm = new OverworldEditor();
			TextForm = new TextEditor();

			Application.Run(MainForm);
		}
	}
}
