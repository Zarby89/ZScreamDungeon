using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZeldaFullEditor
{
    class IniFile
    {
        List<string> fileLines = new List<string>();
        string filename;
        public IniFile(string filename)
        {
            this.filename = filename;
            fileLines = File.ReadAllLines(filename).ToList();
        }

        public string GetValue(string section, string key)
        {
            bool foundSection = false;
            for (int i = 0; i < fileLines.Count; i++)
            {
                if (foundSection)
                {

                    string[] s = fileLines[i].Split('=');
                    if (s[0] == key)
                    {
                        return (s[1]);
                    }
                    if (fileLines[i][0] == '[')
                    {
                        break;
                    }
                    continue;
                }
                //Find Section
                if (fileLines[i] == "[" + section + "]")
                {
                    foundSection = true;
                }
            }

            return "ERRORCODE0";
        }

        public void SetValue(string section, string key,string value)
        {
            bool foundSection = false;
            for (int i = 0; i < fileLines.Count; i++)
            {
                if (foundSection)
                {
                    string[] s = fileLines[i].Split('=');
                    if (s[0] == key)
                    {
                        fileLines[i] = key + "=" + value;
                        return;
                    }
                    
                    
                    if (fileLines[i][0] == '[')
                    {
                        //if we didnt find that key then create it
                        fileLines.Insert(i-1, key + "=" + value);
                        return;
                    }
                    continue;
                }
                //Find Section
                if (fileLines[i] == "[" + section + "]")
                {
                    foundSection = true;
                }
            }


            if (foundSection == false)
            {
                fileLines.Add("[" + section + "]");
                fileLines.Add( key + "=" + value);
            }
            else
            {
                fileLines.Add(key + "=" + value);
            }
        }

        public void save()
        {
            File.WriteAllLines(filename,fileLines);
        }

    }
}
