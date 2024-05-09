using System.IO;
namespace ZeldaFullEditor
{

    public static class Room_Name
    {
        public static void loadFromFile(string file = "DefaultNames.txt")
        {
            string[] s = File.ReadAllLines(file);
            int l = 0;
            bool found = false;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == "[Rooms Names]")
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
                        if (l >= 296)
                        {
                            break;
                        }

                        room_name[l] = s[i];
                        l++;
                    }
                }
            }
        }

        public static string[] room_name = new string[296];
    }
}
