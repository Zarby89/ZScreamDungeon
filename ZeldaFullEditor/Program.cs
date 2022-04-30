using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ZeldaFullEditor.Gui;

namespace ZeldaFullEditor
{
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

		public static DungeonMain DungeonForm { get; private set; }
		public static DungeonMain MainForm { get; private set; }
		public static OverworldEditor OverworldForm { get; private set; }
		public static TextEditor TextForm { get; private set; }

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
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

			DungeonForm = new DungeonMain();
			MainForm = DungeonForm;
			OverworldForm = new OverworldEditor();
			TextForm = new TextEditor();

			Application.Run(MainForm);
		}
	}
}
