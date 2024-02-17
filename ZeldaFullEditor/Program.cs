using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
	/// <summary>
	///     Start program entry point.
	/// </summary>
	static class Program
	{
		// var to keep track whether to show the console or not.
		// 0 = dont show.
		// 5 = show.
		private static int showConsole = 5;

		[DllImport("kernel32.dll")]
		static extern IntPtr GetConsoleWindow();

		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		// All the files required for ZS to function.
		// The files "debug.asm", "spritesmove.asm" appear in the release but don't actually seem to be used anywhere in the solution.
		private static string[] requiredFiles = new string[] {
			"ZScream.exe.config",
			"ScratchPad.dat",
			"DefaultNames.txt",
			"asar.dll",
			"Lidgren.Network.dll",
			"basepatches.asm",
			"CustomCollision.asm",
			"newgraves.asm",
			"tempPatch.asm",
			"ZSCustomOverworld.asm",
		};

		/// <summary>
		///		The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// Look for Command Line Arguments.
			if (args != null)
			{
				// Loop through them all.
				foreach (string arg in args)
				{
					// Look for hide console arg.
					if (arg.Equals("-hideConsole"))
					{
						showConsole = 0;
					}

					// Look for show console arg.
					if (arg.Equals("-showConsole"))
					{
						showConsole = 5;
					}

					// TODO: add other args.
				}
			}

			// Hide console.
			var handle = GetConsoleWindow();
			ShowWindow(handle, showConsole);

			// Make sure all the other needed files are here so the dummies who keep trying to move the .exe will learn.
			foreach (string file in requiredFiles)
			{
				if (!System.IO.File.Exists(file))
				{
					UIText.WarnAboutMissingFile(file);

					Environment.Exit(1);
				}
			}

			// Run the app.
			Application.Run(new DungeonMain());
		}
	}
}
