using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AsarCLR;
using System.IO;
using static System.Net.WebRequestMethods;

namespace ZeldaFullEditor
{
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
        public static string[] RequiredFiles = new string[] { "asar.dll", "DefaultNames.txt", "Lidgren.Network.dll", "ScratchPad.dat", "AreaSpecificBGColor.asm", "CustomCollision.asm", "MosaicChange.asm", "newgraves.asm", "tempPatch.asm", "ZScream.exe.config" };

        /// <summary>
        ///		The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Look for Command Line Arguments.
            if (args != null)
            {
                // Loop through them all.
                foreach (String arg in args)
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
            foreach (string file in RequiredFiles)
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
