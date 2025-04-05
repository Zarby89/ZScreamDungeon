using System;
using System.Drawing;
using System.Linq;

namespace ZeldaFullEditor.OWSceneModes
{
    public class OWNote
    {
        public string text;
        public Font font;
        public Color color;
        public int x, y;
        public SizeF size;
        public int ID;

        private static int CurrentID;

        public OWNote(int x, int y, string text, Font font, Color color)
        {
            Bitmap b = new Bitmap(1, 1);
            Graphics g =  Graphics.FromImage(b);
            this.x = x.Clamp(0, 4088);
            this.y = y.Clamp(0, 4088);
            this.text = text;
            this.font = font;
            this.color = color;
            this.size = g.MeasureString(text, font);
            g.Dispose();
            b.Dispose();
            this.ID = CurrentID++;

            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            string s = "";
            s += x.ToString() + "|";
            s += y.ToString() + "|";
            s += text.ToString() + "|";
            s += color.R.ToString() + "," + color.G.ToString() + "," + color.B.ToString() + "|" ;
            s += font.Name + "|" + font.Style + "|" + font.Size + "@";

            return s;
        }

        public OWNote(string s)
        {
            Bitmap b = new Bitmap(1, 1);
            Graphics g = Graphics.FromImage(b);
            //167 | 146 | aaaaaaaaaaa | 255,255,255 | Microsoft Sans Serif, Regular,8,25
            string[] valuesString = s.Split('|');
            x = int.Parse(valuesString[0]);
            y = int.Parse(valuesString[1]);
            text = valuesString[2];
            string[] colors = valuesString[3].Split(',');
            color = Color.FromArgb(byte.Parse(colors[0]), byte.Parse(colors[1]), byte.Parse(colors[2]));
            string[] styleString = valuesString[5].Split(',');
            FontStyle fs = FontStyle.Regular;
            if (styleString.Contains("Regular"))
            {
                fs |= FontStyle.Regular;
            }

            if (styleString.Contains("Italic"))
            {
                fs |= FontStyle.Italic;
            }

            if (styleString.Contains("Bold"))
            {
                fs |= FontStyle.Bold;
            }

            if (styleString.Contains("Strikeout"))
            {
                fs |= FontStyle.Strikeout;
            }

            if (styleString.Contains("Underline"))
            {
                fs |= FontStyle.Underline;
            }

            font = new Font(valuesString[4], float.Parse(valuesString[6]), fs);

            this.size = g.MeasureString(text, font);
            g.Dispose();
            b.Dispose();
            Console.WriteLine(ToString());
        }
    }
}
