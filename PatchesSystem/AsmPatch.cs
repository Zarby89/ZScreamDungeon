using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data
{
    /// <summary>
    ///     Class used to load ASM file as data
    /// </summary>
    internal class AsmPatch
    {
        /// <summary>
        ///     Contains all the defines informations for the patch
        /// </summary>
        internal Dictionary<string, Dictionary<string, string>> PatchDefines = new Dictionary<string, Dictionary<string, string>>();

        /// <summary>
        ///     Gets or sets name of the patch that appears inside of the asm file
        /// </summary>
        public string PatchName { get; set; }

        /// <summary>
        ///     Version of the patch that appears inside of the asm file
        /// </summary>
        internal string PatchVersion;

        /// <summary>
        ///     Author of the patch that appears inside of the asm file
        /// </summary>
        internal string PatchAuthor;

        /// <summary>
        ///     Description of the patch that appears inside of the asm file
        /// </summary>
        internal string PatchDescription;

        /// <summary>
        ///     The entire patch as string
        /// </summary>
        internal string WholePatch;

        /// <summary>
        ///     The folder the patch has been loaded from
        /// </summary>
        internal string PatchFolder;

        /// <summary>
        ///     The filename only the patch has been loaded from
        /// </summary>
        internal string FileName;

        /// <summary>
        ///     Gets or sets a value indicating whether the folder the patch has been loaded from
        /// </summary>
        public bool PatchEnabled { get; set; } = true;

        public AsmPatch(string filename, string subfolder)
        {
            // filename provided contains path, but FileName contains only file name without path
            Dictionary<string, string> tempDefineData = new Dictionary<string, string>();
            this.PatchFolder = subfolder;
            this.FileName = Path.GetFileName(filename);
            WholePatch = File.ReadAllText(filename);
            string[] allLines = WholePatch.Split('\n');

            bool inDefine = false;
            bool enabledFound = false;
            bool readingDescription = false;
            foreach (string line in allLines)
            {
                if (line.Contains(";#PATCH_NAME"))
                {
                    PatchName = line.Split('=')[1];
                    continue;
                }

                if (line.Contains(";#PATCH_AUTHOR"))
                {
                    PatchAuthor = line.Split('=')[1];
                    continue;
                }

                if (line.Contains(";#PATCH_VERSION"))
                {
                    PatchVersion = line.Split('=')[1];
                    continue;
                }

                if (line.Contains(";#PATCH_DESCRIPTION"))
                {
                    readingDescription = true;
                    continue;
                }

                if (line.Contains(";#ENDPATCH_DESCRIPTION"))
                {
                    readingDescription = false;
                    continue;
                }

                if (readingDescription)
                {
                    
                    PatchDescription += line.TrimStart(';') + "\r\n";
                    
                    continue;
                }

                if (line.Contains(";#ENABLED"))
                {
                    inDefine = false;
                    enabledFound = true;
                    if (line.Split('=')[1].ToLower().Contains("true"))
                    {
                        PatchEnabled = true;
                    }
                    else
                    {
                        PatchEnabled = false;
                    }

                    continue;
                }

                if (line.Contains(";#DEFINE_START"))
                {
                    inDefine = true;
                    continue;
                }
                if (line.Contains(";#DEFINE_END"))
                {
                    inDefine = false;
                    break;
                }

                if (inDefine)
                {
                    if (line.Contains(";#"))
                    {
                        // if the line contains a comment command
                        string[] keyValue = line.Split('=');
                        tempDefineData.Add(keyValue[0].Substring(keyValue[0].IndexOf('#') + 1), keyValue[1]);
                        continue;
                    }
                    else if (line.StartsWith("!"))
                    {
                        string[] keyValue = line.Split('=');
                        tempDefineData.Add("_VALUE", keyValue[1]); // Do not appear in the script it's useless
                        PatchDefines.Add(keyValue[0], tempDefineData);
                        tempDefineData = new Dictionary<string, string>(); // reset it for the next one
                        Console.WriteLine("Found Define " + keyValue[0]);

                    }
                }
            }

            if (!enabledFound)
            {
                // If we didn't find any enabled line in the file just add it on line0
                WholePatch = WholePatch.Insert(0, ";#ENABLED=true\r\n");
            }
        }

        public void Save(string projectPath)
        {
            int pos = WholePatch.IndexOf(";#ENABLED=");
            int posEnd = WholePatch.IndexOf('\n',pos);
            WholePatch = WholePatch.Remove(pos, posEnd - pos);
            WholePatch = WholePatch.Insert(pos, ";#ENABLED=" + PatchEnabled.ToString());



            foreach (KeyValuePair<string, Dictionary<string, string>> keyValue in PatchDefines)
            {
                pos = WholePatch.IndexOf(keyValue.Key);
                posEnd = WholePatch.IndexOf('\n',pos);
                WholePatch = WholePatch.Remove(pos, posEnd - pos);
                WholePatch = WholePatch.Insert(pos, keyValue.Key + "= " + PatchDefines[keyValue.Key]["_VALUE"]);
            }


            File.WriteAllText(projectPath + "\\Patches\\" + PatchFolder + "\\" + FileName, WholePatch);
        }
    }
}
