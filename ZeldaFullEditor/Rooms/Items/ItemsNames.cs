using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public static class ItemsNames
    {

        public static void loadFromFile(string file = "DefaultNames.txt")
        {
            string[] s = File.ReadAllLines(file);
            int l = 0;
            bool found = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == "[Items Names]")
                {
                    l = 0;
                    found = true;
                    continue;
                }

                if (found)
                {
                    if (s[i].Length > 0)
                    {
                        if (s[i][0] == '/' && s[i][1] == '/')
                        {
                            continue;
                        }
                        if (l >= 0x1C)
                        {
                            break;
                        }
                        name[l] = s[i];
                        l++;
                    }
                }
            }

        }
        public static string[] name = new string[]
        {
                "Nothing","Rupee","RockCrab","Bee","Random","Bomb","Heart ","Blue Rupee",
                "Key","Arrow","Bomb ","Heart  ","Magic","Big Magic","Chicken","Green Soldier","AliveRock?","Blue Soldier",
                "Ground Bomb"," Heart","Fairy","Heart","Nothing ","Hole","Warp","Staircase","Bombable","Switch" };

    }
}
