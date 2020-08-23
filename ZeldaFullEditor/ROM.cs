using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
    public static class ROM
    {
        public static byte[] DATA;
        public static StringBuilder romLog = new StringBuilder();
        public static bool logBlock = false;
        static int biggerAddress = 0;
        static string blockName = "";
        public static bool AdvancedLogs = false;
        public static void StartBlockLogWriting(string name,int addr)
        {
            romLog.Append(addr.ToString("X6") + "/" + Utils.PcToSnes(addr).ToString("X6") +" [Block of Data](" + name + ")\r\n");
            biggerAddress = addr;
            blockName = name;
            logBlock = true;
        }

        public static void EndBlockLogWriting()
        {
            romLog.Append(biggerAddress.ToString("X6") + "/" + Utils.PcToSnes(biggerAddress).ToString("X6") + " [END Block of Data](" + blockName + ")\r\n");
            logBlock = false;
        }


        public static void Write(int addr, byte value, bool log = false, string info = "")
        {
            DATA[addr] = value;
            if (logBlock)
            {
                if (addr + 1 > biggerAddress)
                {
                    biggerAddress = addr + 1;
                }
            }
            if (!AdvancedLogs)
            {
                return;
            }

            if (log)
            {
                romLog.Append(addr.ToString("X6") +"/" + Utils.PcToSnes(addr).ToString("X6") +" : " +value.ToString("X2") + " // " + info + "\r\n");
            }

        }

        public static void Write(int addr, byte[] value, bool log = false, string info = "")
        {
            if (logBlock)
            {
                if ((addr + value.Length) > biggerAddress)
                {
                    biggerAddress = (addr + value.Length);
                }
            }
            if (AdvancedLogs)
            {
                if (log)
                {
                    romLog.Append(addr.ToString("X6") + "/" + Utils.PcToSnes(addr).ToString("X6") + " : ");
                }
                for (int i = 0; i < value.Length; i++)
                {
                    DATA[addr + i] = value[i];
                    if (log)
                    {
                        romLog.Append(value[i].ToString("X2") + ", ");
                    }

                }
                if (log)
                {
                    romLog.Append("//" + info + "\r\n");
                }
            }
            else
            {
                for (int i = 0; i < value.Length; i++)
                {
                    DATA[addr + i] = value[i];
                }
            }

            
        }

        public static void WriteLong(int addr, int value, bool log = false, string info = "")
        {
            DATA[addr] = (byte)(value & 0xFF);
            DATA[addr + 1] = (byte)((value >> 8) & 0xFF);
            DATA[addr + 2] = (byte)((value >> 16) & 0xFF);
            if (logBlock)
            {
                if (addr + 3 > biggerAddress)
                {
                    biggerAddress = addr + 3;
                }
            }

            if (!AdvancedLogs)
            {
                return;
            }
            if (log)
            {
                romLog.Append(addr.ToString("X6") + "/" + Utils.PcToSnes(addr).ToString("X6") + " : Long(" + value.ToString("X6") + ") // " + info +"\r\n");
            }

        }

        public static void WriteShort(int addr, int value, bool log = false, string info = "")
        {
            DATA[addr] = (byte)(value & 0xFF);
            DATA[addr + 1] = (byte)((value >> 8) & 0xFF);
            if (logBlock)
            {
                if (addr + 2 > biggerAddress)
                {
                    biggerAddress = addr + 2;
                }
            }
            if (!AdvancedLogs)
            {
                return;
            }
            if (log)
            {
                romLog.Append(addr.ToString("X6") + "/" + Utils.PcToSnes(addr).ToString("X6") + " : Word(" + value.ToString("X4") + ") // "+info+"\r\n");
            }

        }

        public static int ReadLong(int addr)
        {
            return ((DATA[addr + 2] << 16) + (DATA[addr + 1] << 8) + DATA[addr]);
        }

        public static short ReadShort(int addr)
        {
            return (short)((DATA[addr + 1] << 8) + DATA[addr]);
        }

        public static short ReadReverseShort(int addr)
        {
            return (short)((DATA[addr] << 8) + DATA[addr+1]);
        }

        public static void SaveLogs()
        {
            string fname = "Logs.txt";
            File.WriteAllText(fname, romLog.ToString());
            romLog.Clear();

        }
    }
}
