using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public class Charactertable
    {
        Dictionary<string, byte> kanji = new Dictionary<string, byte>();
        Dictionary<string, byte> tablechar = new Dictionary<string, byte>();

        public byte[] textToHex(string text)
        {
            text = text.Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty);
            int pos = 0;
            List<byte> bytes = new List<byte>();
            while (pos < text.Length)
            {
                //F6
                if ((text[pos] == '[') && (text[pos + 1] == 'S') && (text[pos + 2] == 'C') && (text[pos + 3] == 'L') && (text[pos + 4] == ']'))
                {
                    bytes.Add(0xF6);
                    pos += 5;
                    continue;
                }
                //F7
                if ((text[pos] == '[') && (text[pos + 1] == 'L') && (text[pos + 2] == 'N') && (text[pos + 3] == '1') && (text[pos + 4] == ']'))
                {
                    pos += 5;
                    bytes.Add(0xF7);
                    continue;
                }
                //F8
                if ((text[pos] == '[') && (text[pos + 1] == 'L') && (text[pos + 2] == 'N') && (text[pos + 3] == '2') && (text[pos + 4] == ']'))
                {
                    pos += 5;
                    bytes.Add(0xF8);
                    continue;
                }
                //F9
                if ((text[pos] == '[') && (text[pos + 1] == 'L') && (text[pos + 2] == 'N') && (text[pos + 3] == '3') && (text[pos + 4] == ']'))
                {
                    pos += 5;
                    bytes.Add(0xF9);
                    continue;
                }
                //FA
                if ((text[pos] == '[') && (text[pos + 1] == 'W') && (text[pos + 2] == 'F') && (text[pos + 3] == 'K') && (text[pos + 4] == ']'))
                {
                    pos += 5;
                    bytes.Add(0xFA);
                    continue;
                }
                //FC
                if ((text[pos] == '[') && (text[pos + 1] == 'S') && (text[pos + 2] == 'P') && (text[pos + 3] == 'D') && (text[pos + 4] == ' ') && (text[pos + 7] == ']'))
                {
                    bytes.Add(0xFC);
                    bytes.Add(byte.Parse(text[pos + 5].ToString() + text[pos + 6].ToString(), System.Globalization.NumberStyles.HexNumber));
                    pos += 8;
                    continue;
                }
                //FE67
                if ((text[pos] == '[') && (text[pos + 1] == 'P') && (text[pos + 2] == 'I') && (text[pos + 3] == 'C') && (text[pos + 4] == ']'))
                {
                    bytes.Add(0xFE);
                    bytes.Add(0x67);
                    pos += 5;
                    continue;
                }
                //FE68
                if ((text[pos] == '[') && (text[pos + 1] == 'C') && (text[pos + 2] == 'H') && (text[pos + 3] == '1') && (text[pos + 4] == ']'))
                {
                    bytes.Add(0xFE);
                    bytes.Add(0x68);
                    pos += 5;
                    continue;
                }
                //FE71
                if ((text[pos] == '[') && (text[pos + 1] == 'C') && (text[pos + 2] == 'H') && (text[pos + 3] == '2') && (text[pos + 4] == ']'))
                {
                    bytes.Add(0xFE);
                    bytes.Add(0x71);
                    pos += 5;
                    continue;
                }
                //FE72
                if ((text[pos] == '[') && (text[pos + 1] == 'C') && (text[pos + 2] == 'H') && (text[pos + 3] == '3') && (text[pos + 4] == ']'))
                {
                    bytes.Add(0xFE);
                    bytes.Add(0x72);
                    pos += 5;
                    continue;
                }
                //FE69
                if ((text[pos] == '[') && (text[pos + 1] == 'I') && (text[pos + 2] == 'T') && (text[pos + 3] == 'M') && (text[pos + 4] == ']'))
                {
                    bytes.Add(0xFE);
                    bytes.Add(0x69);
                    pos += 5;
                    continue;
                }
                //FE6A
                if ((text[pos] == '[') && (text[pos + 1] == 'N') && (text[pos + 2] == 'A') && (text[pos + 3] == 'M') && (text[pos + 4] == ']'))
                {
                    bytes.Add(0xFE);
                    bytes.Add(0x6A);
                    pos += 5;
                    continue;
                }
                //FE6B
                if ((text[pos] == '[') && (text[pos + 1] == 'W') && (text[pos + 2] == 'I') && (text[pos + 3] == 'N') && (text[pos + 4] == ' ') && (text[pos + 7] == ']'))
                {
                    bytes.Add(0xFE);
                    bytes.Add(0x6B);
                    bytes.Add(byte.Parse(text[pos + 5].ToString() + text[pos + 6].ToString(), System.Globalization.NumberStyles.HexNumber));
                    //text = text.Replace("[NAM]", "NAME");
                    pos += 8;
                    continue;
                }
                //FE6C
                if ((text[pos] == '[') && (text[pos + 1] == 'N') && (text[pos + 2] == 'B') && (text[pos + 3] == 'R') && (text[pos + 4] == ' ') && (text[pos + 7] == ']'))
                {
                    bytes.Add(0xFE);
                    bytes.Add(0x6C);
                    bytes.Add(byte.Parse(text[pos + 5].ToString() + text[pos + 6].ToString(), System.Globalization.NumberStyles.HexNumber));
                    pos += 8;
                    continue;
                }
                //FE6D
                if ((text[pos] == '[') && (text[pos + 1] == 'P') && (text[pos + 2] == 'O') && (text[pos + 3] == 'S') && (text[pos + 4] == ' ') && (text[pos + 7] == ']'))
                {
                    bytes.Add(0xFE);
                    bytes.Add(0x6D);
                    bytes.Add(byte.Parse(text[pos + 5].ToString() + text[pos + 6].ToString(), System.Globalization.NumberStyles.HexNumber));
                    //arguments = text[pos + 5], text[pos + 6]
                    pos += 8;
                    continue;
                }
                //FE6E
                if ((text[pos] == '[') && (text[pos + 1] == 'S') && (text[pos + 2] == 'C') && (text[pos + 3] == 'S') && (text[pos + 4] == ' ') && (text[pos + 7] == ']'))
                {
                    bytes.Add(0xFE);
                    bytes.Add(0x6E);
                    bytes.Add(byte.Parse(text[pos + 5].ToString() + text[pos + 6].ToString(), System.Globalization.NumberStyles.HexNumber));
                    //arguments = text[pos + 5], text[pos + 6]
                    pos += 8;
                    continue;
                }
                //FE77 oO what is wrong
                if ((text[pos] == '[') && (text[pos + 1] == 'C') && (text[pos + 2] == 'O') && (text[pos + 3] == 'L') && (text[pos + 4] == ' ') && (text[pos + 7] == ']'))
                {
                    bytes.Add(0xFE);
                    bytes.Add(0x77);
                    bytes.Add(byte.Parse(text[pos + 5].ToString() + text[pos + 6].ToString(), System.Globalization.NumberStyles.HexNumber));
                    pos += 8;
                    continue;
                }
                //FE78
                if ((text[pos] == '[') && (text[pos + 1] == 'W') && (text[pos + 2] == 'A') && (text[pos + 3] == 'I') && (text[pos + 4] == ' ') && (text[pos + 7] == ']'))
                {
                    bytes.Add(0xFE);
                    bytes.Add(0x78);
                    bytes.Add(byte.Parse(text[pos + 5].ToString() + text[pos + 6].ToString(), System.Globalization.NumberStyles.HexNumber));
                    pos += 8;
                    continue;
                }
                //FE79
                if ((text[pos] == '[') && (text[pos + 1] == 'S') && (text[pos + 2] == 'N') && (text[pos + 3] == 'D') && (text[pos + 4] == ' ') && (text[pos + 7] == ']'))
                {
                    bytes.Add(0xFE);
                    bytes.Add(0x79);
                    bytes.Add(byte.Parse(text[pos + 5].ToString() + text[pos + 6].ToString(), System.Globalization.NumberStyles.HexNumber));
                    //arguments = text[pos + 5], text[pos + 6]
                    pos += 8;
                    continue;
                }
                //FE
                if ((text[pos] == '[') && (text[pos + 3] == ']'))
                {
                    bytes.Add(byte.Parse(text[pos + 1].ToString() + text[pos + 2].ToString(), System.Globalization.NumberStyles.HexNumber));
                    pos += 4;
                    continue;
                }

                if (text[pos] == ' ')
                {
                    bytes.Add(0xFF);
                    pos += 1;
                    continue;
                }

                    ushort cvalue = charToHex(text[pos].ToString());
                if ((cvalue & 0xFD00) == 0xFD00)
                {
                    bytes.Add(0xFD); bytes.Add((byte)(cvalue & 0xFF));
                }
                else
                {
                    bytes.Add((byte)cvalue);
                }
                pos++;

            }

            bytes.Add(0xFB);

            return bytes.ToArray();
            

        }


        public string hexToChar(byte hex, bool iskanji = false)
        {
            var c = kanji.FirstOrDefault(x => x.Value == hex);
            if (iskanji == true)
            {
                c = kanji.FirstOrDefault(x => x.Value == hex);
                if (c.Key != null)
                {
                    return c.Key;
                }
            }

            if (hex >= 0xA0 && hex <= 0xA9) // 0-9
            {
                hex -= 0x70;
                return ((char)hex).ToString(); //A-Z
            }

            if (hex >= 0xAA && hex < 0xAA + 26)
            {
                hex -= 0x69;
                return ((char)hex).ToString();
            }


            c = tablechar.FirstOrDefault(x => x.Value == hex);
            if (c.Key != null)
            {
                return c.Key;
            }
           
            return null;
        }

        public ushort charToHex(string c)
        {
            if (c == "あ")
            {
                return 0x00;
            }
            if (c == "娘")
            {
                return (ushort)(0xFD00);
            }


            var hex = tablechar.FirstOrDefault(x => x.Key == c);
            if (hex.Value != 0)
            {
                return hex.Value;
            }

            hex = kanji.FirstOrDefault(x => x.Key == c);
            if (hex.Value != 0)
            {
                return (ushort)((0xFD00) + hex.Value);
            }
            //48-57 numeric
            //65-90 A-Z
            /*if ( hex.Value >= 48 && hex.Value <= 57)//return number
            {
                return (ushort)(hex.Value +0x70);
            }

            if (hex.Value >= 65 && hex.Value <= 90)//return letter
            {
                return (ushort)(hex.Value + 0x69);
            }*/
            //if code reach here for whatever reason return 0xFFFF as error result
           // Console.WriteLine("Reached FFFF in chartohex : " + c);
            return (ushort)(0xFFFF);

        }

        public Charactertable(bool jp = false)
        {
            if (jp)
            {
                kanji.Add("娘", 0x00);
                kanji.Add("城", 0x01);
                kanji.Add("行", 0x02);
                kanji.Add("教", 0x03);
                kanji.Add("会", 0x04);
                kanji.Add("神", 0x05);
                kanji.Add("父", 0x06);
                kanji.Add("訪", 0x07);
                kanji.Add("頼", 0x08);
                kanji.Add("通", 0x09);
                kanji.Add("願", 0x0A);
                kanji.Add("平", 0x0B);
                kanji.Add("和", 0x0C);
                kanji.Add("司", 0x0D);
                kanji.Add("書", 0x0E);
                kanji.Add("戻", 0x0F);
                kanji.Add("様", 0x10);
                kanji.Add("子", 0x11);
                kanji.Add("湖", 0x12);
                kanji.Add("達", 0x13);
                kanji.Add("彼", 0x14);
                kanji.Add("女", 0x15);
                kanji.Add("言", 0x16);
                kanji.Add("祭", 0x17);
                kanji.Add("早", 0x18);
                kanji.Add("雨", 0x19);
                kanji.Add("剣", 0x1A);
                kanji.Add("盾", 0x1B);
                kanji.Add("解", 0x1C);
                kanji.Add("抜", 0x1D);
                kanji.Add("者", 0x1E);
                kanji.Add("味", 0x1F);
                kanji.Add("方", 0x20);
                kanji.Add("無", 0x21);
                kanji.Add("事", 0x22);
                kanji.Add("出", 0x23);
                kanji.Add("本", 0x24);
                kanji.Add("当", 0x25);
                kanji.Add("私", 0x26);
                kanji.Add("他", 0x27);
                kanji.Add("救", 0x28);
                kanji.Add("倒", 0x29);
                kanji.Add("度", 0x2A);
                kanji.Add("国", 0x2B);
                kanji.Add("退", 0x2C);
                kanji.Add("魔", 0x2D);
                kanji.Add("伝", 0x2E);
                kanji.Add("説", 0x2F);
                kanji.Add("必", 0x30);
                kanji.Add("要", 0x31);
                kanji.Add("良", 0x32);
                kanji.Add("地", 0x33);
                kanji.Add("図", 0x34);
                kanji.Add("印", 0x35);
                kanji.Add("思", 0x36);
                kanji.Add("気", 0x37);
                kanji.Add("人", 0x38);
                kanji.Add("間", 0x39);
                kanji.Add("兵", 0x3A);
                kanji.Add("病", 0x3B);
                kanji.Add("法", 0x3C);
                kanji.Add("屋", 0x3D);
                kanji.Add("手", 0x3E);
                kanji.Add("住", 0x3F);
                kanji.Add("連", 0x40);
                kanji.Add("恵", 0x41);
                kanji.Add("表", 0x42);
                kanji.Add("金", 0x43);
                kanji.Add("王", 0x44);
                kanji.Add("信", 0x45);
                kanji.Add("裏", 0x46);
                kanji.Add("取", 0x47);
                kanji.Add("引", 0x48);
                kanji.Add("入", 0x49);
                kanji.Add("口", 0x4A);
                kanji.Add("開", 0x4B);
                kanji.Add("見", 0x4C);
                kanji.Add("正", 0x4D);
                kanji.Add("幸", 0x4E);
                kanji.Add("運", 0x4F);
                kanji.Add("呼", 0x50);
                kanji.Add("物", 0x51);
                kanji.Add("付", 0x52);
                kanji.Add("紋", 0x53);
                kanji.Add("章", 0x54);
                kanji.Add("所", 0x55);
                kanji.Add("家", 0x56);
                kanji.Add("闇", 0x57);
                kanji.Add("読", 0x58);
                kanji.Add("左", 0x59);
                kanji.Add("側", 0x5A);
                kanji.Add("札", 0x5B);
                kanji.Add("穴", 0x5C);
                kanji.Add("道", 0x5D);
                kanji.Add("男", 0x5E);
                kanji.Add("大", 0x5F);
                kanji.Add("声", 0x60);
                kanji.Add("下", 0x61);
                kanji.Add("犯", 0x62);
                kanji.Add("花", 0x63);
                kanji.Add("深", 0x64);
                kanji.Add("森", 0x65);
                kanji.Add("水", 0x66);
                kanji.Add("若", 0x67);
                kanji.Add("美", 0x68);
                kanji.Add("探", 0x69);
                kanji.Add("今", 0x6A);
                kanji.Add("士", 0x6B);
                kanji.Add("店", 0x6C);
                kanji.Add("好", 0x6D);
                kanji.Add("代", 0x6E);
                kanji.Add("名", 0x6F);
                kanji.Add("迷", 0x70);
                kanji.Add("立", 0x71);
                kanji.Add("上", 0x72);
                kanji.Add("光", 0x73);
                kanji.Add("点", 0x74);
                kanji.Add("目", 0x75);
                kanji.Add("的", 0x76);
                kanji.Add("押", 0x77);
                kanji.Add("前", 0x78);
                kanji.Add("夜", 0x79);
                kanji.Add("十", 0x7A);
                kanji.Add("字", 0x7B);
                kanji.Add("北", 0x7C);
                kanji.Add("急", 0x7D);
                kanji.Add("昔", 0x7E);
                kanji.Add("果", 0x7F);
                kanji.Add("奥", 0x80);
                kanji.Add("選", 0x81);
                kanji.Add("続", 0x82);
                kanji.Add("結", 0x83);
                kanji.Add("定", 0x84);
                kanji.Add("悪", 0x85);
                kanji.Add("向", 0x86);
                kanji.Add("歩", 0x87);
                kanji.Add("時", 0x88);
                kanji.Add("使", 0x89);
                kanji.Add("古", 0x8A);
                kanji.Add("何", 0x8B);
                kanji.Add("村", 0x8C);
                kanji.Add("長", 0x8D);
                kanji.Add("配", 0x8E);
                kanji.Add("匹", 0x8F);
                kanji.Add("殿", 0x90);
                kanji.Add("守", 0x91);
                kanji.Add("精", 0x92);
                kanji.Add("知", 0x93);
                kanji.Add("山", 0x94);
                kanji.Add("誰", 0x95);
                kanji.Add("足", 0x96);
                kanji.Add("冷", 0x97);
                kanji.Add("黄", 0x98);
                kanji.Add("力", 0x99);
                kanji.Add("宝", 0x9A);
                kanji.Add("求", 0x9B);
                kanji.Add("先", 0x9C);
                kanji.Add("消", 0x9D);
                kanji.Add("封", 0x9E);
                kanji.Add("捕", 0x9F);
                kanji.Add("勇", 0xA0);
                kanji.Add("年", 0xA1);
                kanji.Add("姿", 0xA2);
                kanji.Add("話", 0xA3);
                kanji.Add("色", 0xA4);
                kanji.Add("々", 0xA5);
                kanji.Add("真", 0xA6);
                kanji.Add("紅", 0xA7);
                kanji.Add("場", 0xA8);
                kanji.Add("炎", 0xA9);
                kanji.Add("空", 0xAA);
                kanji.Add("面", 0xAB);
                kanji.Add("音", 0xAC);
                kanji.Add("吹", 0xAD);
                kanji.Add("中", 0xAE);
                kanji.Add("祈", 0xAF);
                kanji.Add("起", 0xB0);
                kanji.Add("右", 0xB1);
                kanji.Add("念", 0xB2);
                kanji.Add("再", 0xB3);
                kanji.Add("生", 0xB4);
                kanji.Add("庭", 0xB5);
                kanji.Add("路", 0xB6);
                kanji.Add("部", 0xB7);
                kanji.Add("川", 0xB8);
                kanji.Add("血", 0xB9);
                kanji.Add("完", 0xBA);
                kanji.Add("矢", 0xBB);
                kanji.Add("現", 0xBC);
                kanji.Add("在", 0xBD);
                kanji.Add("全", 0xBE);
                kanji.Add("体", 0xBF);
                kanji.Add("文", 0xC0);
                kanji.Add("秘", 0xC1);
                kanji.Add("密", 0xC2);
                kanji.Add("感", 0xC3);
                kanji.Add("賢", 0xC4);
                kanji.Add("陣", 0xC5);
                kanji.Add("残", 0xC6);
                kanji.Add("百", 0xC7);
                kanji.Add("近", 0xC8);
                kanji.Add("朝", 0xC9);
                kanji.Add("助", 0xCA);
                kanji.Add("術", 0xCB);
                kanji.Add("粉", 0xCC);
                kanji.Add("火", 0xCD);
                kanji.Add("注", 0xCE);
                kanji.Add("意", 0xCF);
                kanji.Add("走", 0xD0);
                kanji.Add("敵", 0xD1);
                kanji.Add("玉", 0xD2);
                kanji.Add("復", 0xD3);
                kanji.Add("活", 0xD4);
                kanji.Add("塔", 0xD5);
                kanji.Add("来", 0xD6);
                kanji.Add("帰", 0xD7);
                kanji.Add("忘", 0xD8);
                kanji.Add("東", 0xD9);
                kanji.Add("青", 0xDA);
                kanji.Add("持", 0xDB);
                kanji.Add("込", 0xDC);
                kanji.Add("逃", 0xDD);
                kanji.Add("銀", 0xDE);
                kanji.Add("勝", 0xDF);
                kanji.Add("集", 0xE0);
                kanji.Add("始", 0xE1);
                kanji.Add("攻", 0xE2);
                kanji.Add("撃", 0xE3);
                kanji.Add("命", 0xE4);
                kanji.Add("老", 0xE5);
                kanji.Add("心", 0xE6);
                kanji.Add("新", 0xE7);
                kanji.Add("世", 0xE8);
                kanji.Add("界", 0xE9);
                kanji.Add("箱", 0xEA);
                kanji.Add("木", 0xEB);
                kanji.Add("対", 0xEC);
                kanji.Add("特", 0xED);
                kanji.Add("賊", 0xEE);
                kanji.Add("洞", 0xEF);
                kanji.Add("支", 0xF0);
                kanji.Add("盗", 0xF1);
                kanji.Add("族", 0xF2);
                kanji.Add("能", 0xF3);
                //kanji.Add("力", 0xF4);
                kanji.Add("多", 0xF5);
                kanji.Add("聖", 0xF6);
                kanji.Add("両", 0xF7);
                kanji.Add("民", 0xF8);
                kanji.Add("予", 0xF9);
                kanji.Add("小", 0xFA);
                kanji.Add("強", 0xFB);
                kanji.Add("投", 0xFC);
                kanji.Add("服", 0xFD);
                kanji.Add("月", 0xFE);
                kanji.Add("姫", 0xFF);

                tablechar.Add("0", 0xA0);
                tablechar.Add("1", 0xA1);
                tablechar.Add("2", 0xA2);
                tablechar.Add("3", 0xA3);
                tablechar.Add("4", 0xA4);
                tablechar.Add("5", 0xA5);
                tablechar.Add("6", 0xA6);
                tablechar.Add("7", 0xA7);
                tablechar.Add("8", 0xA8);
                tablechar.Add("9", 0xA9);
                tablechar.Add("A", 0xAA);
                tablechar.Add("B", 0xAB);
                tablechar.Add("C", 0xAC);
                tablechar.Add("D", 0xAD);
                tablechar.Add("E", 0xAE);
                tablechar.Add("F", 0xAF);
                tablechar.Add("G", 0xB0);
                tablechar.Add("H", 0xB1);
                tablechar.Add("I", 0xB2);
                tablechar.Add("J", 0xB3);
                tablechar.Add("K", 0xB4);
                tablechar.Add("L", 0xB5);
                tablechar.Add("M", 0xB6);
                tablechar.Add("N", 0xB7);
                tablechar.Add("O", 0xB8);
                tablechar.Add("P", 0xB9);
                tablechar.Add("Q", 0xBA);
                tablechar.Add("R", 0xBB);
                tablechar.Add("S", 0xBC);
                tablechar.Add("T", 0xBD);
                tablechar.Add("U", 0xBE);
                tablechar.Add("V", 0xBF);
                tablechar.Add("W", 0xC0);
                tablechar.Add("X", 0xC1);
                tablechar.Add("Y", 0xC2);
                tablechar.Add("Z", 0xC3);

                tablechar.Add("『", 0xC4);
                tablechar.Add("』", 0xC5);
                tablechar.Add("?",0xC6);
                tablechar.Add("!",0xC7);
                tablechar.Add(",",0xC8);
                tablechar.Add("-",0xC9);
                tablechar.Add("🡄", 0xCA);
                tablechar.Add("🡆", 0xCB);
                tablechar.Add("…",0xCC);
                tablechar.Add(".",0xCD);
                tablechar.Add("~",0xCE);
                tablechar.Add("â", 0xCF);
                tablechar.Add("ß", 0xD0);
                tablechar.Add("ĉ", 0xD1);
                tablechar.Add("ù", 0xD4);
                tablechar.Add("ê", 0xD5);
                tablechar.Add("╒", 0xD6);
                tablechar.Add("Γ", 0xD7);
                tablechar.Add("'",0xD8);
                tablechar.Add("%",0xDD); // Hylian Bird
                tablechar.Add("^",0xDE); // Hylian Ankh
                tablechar.Add("=",0xDF); // Hylian Wavy lines
                tablechar.Add("↑",0xE0);
                tablechar.Add("↓",0xE1);
                tablechar.Add("→",0xE2);
                tablechar.Add("←",0xE3);
                tablechar.Add("≥",0xE4); // cursor


                tablechar.Add("あ",0x00);
                tablechar.Add("い",0x01);
                tablechar.Add("う",0x02);
                tablechar.Add("え",0x03);
                tablechar.Add("お",0x04);
                tablechar.Add("や",0x05);
                tablechar.Add("ゆ",0x06);
                tablechar.Add("よ",0x07);
                tablechar.Add("か",0x08);
                tablechar.Add("き",0x09);
                tablechar.Add("く",0x0A);
                tablechar.Add("け",0x0B);
                tablechar.Add("こ",0x0C);
                tablechar.Add("わ",0x0D);
                tablechar.Add("を",0x0E);
                tablechar.Add("ん",0x0F);
                tablechar.Add("さ",0x10);
                tablechar.Add("し",0x11);
                tablechar.Add("す",0x12);
                tablechar.Add("せ",0x13);
                tablechar.Add("そ",0x14);
                tablechar.Add("が",0x15);
                tablechar.Add("ぎ",0x16);
                tablechar.Add("ぐ",0x17);
                tablechar.Add("た",0x18);
                tablechar.Add("ち",0x19);
                tablechar.Add("つ",0x1A);
                tablechar.Add("て",0x1B);
                tablechar.Add("と",0x1C);
                tablechar.Add("げ",0x1D);
                tablechar.Add("ご",0x1E);
                tablechar.Add("ざ",0x1F);
                tablechar.Add("な",0x20);
                tablechar.Add("に",0x21);
                tablechar.Add("ぬ",0x22);
                tablechar.Add("ね",0x23);
                tablechar.Add("の",0x24);
                tablechar.Add("じ",0x25);
                tablechar.Add("ず",0x26);
                tablechar.Add("ぜ",0x27);
                tablechar.Add("は",0x28);
                tablechar.Add("ひ",0x29);
                tablechar.Add("ふ",0x2A);
                tablechar.Add("へ",0x2B);
                tablechar.Add("ほ",0x2C);
                tablechar.Add("ぞ",0x2D);
                tablechar.Add("だ",0x2E);
                tablechar.Add("ぢ",0x2F);
                tablechar.Add("ま",0x30);
                tablechar.Add("み",0x31);
                tablechar.Add("む",0x32);
                tablechar.Add("め",0x33);
                tablechar.Add("も",0x34);
                tablechar.Add("づ",0x35);
                tablechar.Add("で",0x36);
                tablechar.Add("ど",0x37);
                tablechar.Add("ら",0x38);
                tablechar.Add("り",0x39);
                tablechar.Add("る",0x3A);
                tablechar.Add("れ",0x3B);
                tablechar.Add("ろ",0x3C);
                tablechar.Add("ば",0x3D);
                tablechar.Add("び",0x3E);
                tablechar.Add("ぶ",0x3F);
                tablechar.Add("べ",0x40);
                tablechar.Add("ぼ",0x41);
                tablechar.Add("ぱ",0x42);
                tablechar.Add("ぴ",0x43);
                tablechar.Add("ぷ",0x44);
                tablechar.Add("ぺ",0x45);
                tablechar.Add("ぽ",0x46);
                tablechar.Add("ゃ",0x47);
                tablechar.Add("ゅ",0x48);
                tablechar.Add("ょ",0x49);
                tablechar.Add("っ",0x4A);
                tablechar.Add("ぁ",0x4B);
                tablechar.Add("ぃ",0x4C);
                tablechar.Add("ぅ",0x4D);
                tablechar.Add("ぇ",0x4E);
                tablechar.Add("ぉ",0x4F);
                tablechar.Add("ア",0x50);
                tablechar.Add("イ",0x51);
                tablechar.Add("ウ",0x52);
                tablechar.Add("エ",0x53);
                tablechar.Add("オ",0x54);
                tablechar.Add("ヤ",0x55);
                tablechar.Add("ユ",0x56);
                tablechar.Add("ヨ",0x57);
                tablechar.Add("カ",0x58);
                tablechar.Add("キ",0x59);
                tablechar.Add("ク",0x5A);
                tablechar.Add("ケ",0x5B);
                tablechar.Add("コ",0x5C);
                tablechar.Add("ワ",0x5D);
                tablechar.Add("ヲ",0x5E);
                tablechar.Add("ン",0x5F);
                tablechar.Add("サ",0x60);
                tablechar.Add("シ",0x61);
                tablechar.Add("ス",0x62);
                tablechar.Add("セ",0x63);
                tablechar.Add("ソ",0x64);
                tablechar.Add("ガ",0x65);
                tablechar.Add("ギ",0x66);
                tablechar.Add("グ",0x67);
                tablechar.Add("タ",0x68);
                tablechar.Add("チ",0x69);
                tablechar.Add("ツ",0x6A);
                tablechar.Add("テ",0x6B);
                tablechar.Add("ト",0x6C);
                tablechar.Add("ゲ",0x6D);
                tablechar.Add("ゴ",0x6E);
                tablechar.Add("ザ",0x6F);
                tablechar.Add("ナ",0x70);
                tablechar.Add("ニ",0x71);
                tablechar.Add("ヌ",0x72);
                tablechar.Add("ネ",0x73);
                tablechar.Add("ノ",0x74);
                tablechar.Add("ジ",0x75);
                tablechar.Add("ズ",0x76);
                tablechar.Add("ゼ",0x77);
                tablechar.Add("ハ",0x78);
                tablechar.Add("ヒ",0x79);
                tablechar.Add("フ",0x7A);
                tablechar.Add("ヘ",0x7B);
                tablechar.Add("ホ",0x7C);
                tablechar.Add("ゾ",0x7D);
                tablechar.Add("ダ",0x7E);
                    //7F Oo
                tablechar.Add("マ",0x80);
                tablechar.Add("ミ",0x81);
                tablechar.Add("ム",0x82);
                tablechar.Add("メ",0x83);
                tablechar.Add("モ",0x84);
                tablechar.Add("ヅ",0x85);
                tablechar.Add("デ",0x86);
                tablechar.Add("ド",0x87);
                tablechar.Add("ラ",0x88);
                tablechar.Add("リ",0x89);
                tablechar.Add("ル",0x8A);
                tablechar.Add("レ",0x8B);
                tablechar.Add("ロ",0x8C);
                tablechar.Add("バ",0x8D);
                tablechar.Add("ビ",0x8E);
                tablechar.Add("ブ",0x8F);
                tablechar.Add("ベ",0x90);
                tablechar.Add("ボ",0x91);
                tablechar.Add("パ",0x92);
                tablechar.Add("ピ",0x93);
                tablechar.Add("プ",0x94);
                tablechar.Add("ペ",0x95);
                tablechar.Add("ポ",0x96);
                tablechar.Add("ャ",0x97);
                tablechar.Add("ュ",0x98);
                tablechar.Add("ョ",0x99);
                tablechar.Add("ッ",0x9A);
                tablechar.Add("ァ",0x9B);
                tablechar.Add("ィ",0x9C);
                tablechar.Add("ゥ",0x9D);
                tablechar.Add("ェ",0x9E);
                tablechar.Add("ォ",0x9F);
            }
        }
    }
}
