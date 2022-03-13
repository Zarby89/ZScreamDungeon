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
		public static byte[] DATA2;
		public static byte[] TEMPDATA;
		public static StringBuilder romLog = new StringBuilder();
		public static bool logBlock = false;
		static int biggerAddress = 0;
		static string blockName = "";
		public static bool AdvancedLogs = true;
		public static List<LogInfos> advancedLogData = new List<LogInfos>();

		public static void StartBlockLogWriting(string name, int addr)
		{

			//romLog.Append(addr.ToString("X6") + "/" + Utils.PcToSnes(addr).ToString("X6") +" [Block of Data](" + name + ")\r\n");
			advancedLogData.Add(new LogInfos(addr, name + "\r\n" + addr.ToString("X6") + "/" + Utils.PcToSnes(addr).ToString("X6") + " [Block of Data](" + name + ")\r\n"));
			biggerAddress = addr;
			blockName = name;
			logBlock = false;
		}

		public static void EndBlockLogWriting()
		{
			//romLog.Append(biggerAddress.ToString("X6") + "/" + Utils.PcToSnes(biggerAddress).ToString("X6") + " [END Block of Data](" + blockName + ")\r\n");
			logBlock = false;
		}

		public static void Write(int addr, byte value, bool log = true, string info = "NO INFOS")
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
				advancedLogData.Add(new LogInfos(addr, addr.ToString("X6") + "/" + Utils.PcToSnes(addr).ToString("X6") + " : " + value.ToString("X2") + " // " + info + "\r\n"));

				//romLog.Append(addr.ToString("X6") +"/" + Utils.PcToSnes(addr).ToString("X6") +" : " +value.ToString("X2") + " // " + info + "\r\n");
			}
		}

		public static void Write(int addr, byte[] value, bool log = true, string info = "")
		{
			StringBuilder sb = new StringBuilder();
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

					sb.Append(info + " " + addr.ToString("X6") + "/" + Utils.PcToSnes(addr).ToString("X6") + " : ");
				}

				for (int i = 0; i < value.Length; i++)
				{
					DATA[addr + i] = value[i];
					if (log)
					{
						sb.Append(value[i].ToString("X2") + ", ");
					}
				}
			}
			else
			{
				for (int i = 0; i < value.Length; i++)
				{
					DATA[addr + i] = value[i];
				}
			}
			advancedLogData.Add(new LogInfos(addr, sb.ToString() + info + "\r\n"));
			sb.Clear();
		}

		public static void WriteLong(int addr, int value, bool log = true, string info = "")
		{
			DATA[addr] = (byte) (value & 0xFF);
			DATA[addr + 1] = (byte) ((value >> 8) & 0xFF);
			DATA[addr + 2] = (byte) ((value >> 16) & 0xFF);

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
				//romLog.Append(addr.ToString("X6") + "/" + Utils.PcToSnes(addr).ToString("X6") + " : Long(" + value.ToString("X6") + ") // " + info +"\r\n");
				advancedLogData.Add(new LogInfos(addr, addr.ToString("X6") + "/" + Utils.PcToSnes(addr).ToString("X6") + " : Long(" + value.ToString("X6") + ") // " + info + "\r\n"));
			}
		}

		public static void WriteShort(int addr, int value, bool log = true, string info = "")
		{
			DATA[addr] = (byte) (value & 0xFF);
			DATA[addr + 1] = (byte) ((value >> 8) & 0xFF);

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
				//romLog.Append(addr.ToString("X6") + "/" + Utils.PcToSnes(addr).ToString("X6") + " : Word(" + value.ToString("X4") + ") // "+info+"\r\n");
				advancedLogData.Add(new LogInfos(addr, addr.ToString("X6") + "/" + Utils.PcToSnes(addr).ToString("X6") + " : Word(" + value.ToString("X4") + ") // " + info + "\r\n"));
			}
		}

		public static int ReadLong(int addr)
		{
			return ((DATA[addr + 2] << 16) + (DATA[addr + 1] << 8) + DATA[addr]);
		}

		public static Tile16 ReadTile16(int addr)
		{
			ushort t1 = (ushort) ((DATA[addr + 1] << 8) + DATA[addr]);
			ushort t2 = (ushort) ((DATA[addr + 3] << 8) + DATA[addr + 2]);
			ushort t3 = (ushort) ((DATA[addr + 5] << 8) + DATA[addr + 4]);
			ushort t4 = (ushort) ((DATA[addr + 7] << 8) + DATA[addr + 6]);
			return new Tile16((ulong) ((t1 << 48) + (t2 << 32) + (t3 << 16) + t4));
		}

		public static ushort ReadShort(int addr)
		{
			return (ushort) ((DATA[addr + 1] << 8) + DATA[addr]);
		}

		public static short ReadRealShort(int addr)
		{
			return (short) ((DATA[addr + 1] << 8) + DATA[addr]);
		}

		public static ushort ReadByte(int addr)
		{
			return DATA[addr];
		}

		public static short ReadReverseShort(int addr)
		{
			return (short) ((DATA[addr] << 8) + DATA[addr + 1]);
		}

		public static void SaveLogs()
		{
			string fname = "Logs.txt";
			advancedLogData = advancedLogData.OrderByDescending(o => o.address).ToList();
			for (int i = advancedLogData.Count - 1; i > -1; i--)
			{
				romLog.Append(advancedLogData[i].text);
			}
			File.WriteAllText(fname, romLog.ToString());
			advancedLogData.Clear();
			romLog.Clear();
		}

		public static void WriteShort2(int addr, int value, bool log = false, string info = "")
		{
			DATA2[addr] = (byte) (value & 0xFF);
			DATA2[addr + 1] = (byte) ((value >> 8) & 0xFF);

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
				romLog.Append(addr.ToString("X6") + "/" + Utils.PcToSnes(addr).ToString("X6") + " : Word(" + value.ToString("X4") + ") // " + info + "\r\n");
			}
		}

		public static void Write2(int addr, byte[] value, bool log = false, string info = "")
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
					DATA2[addr + i] = value[i];
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
					DATA2[addr + i] = value[i];
				}
			}
		}

		public static void Write2(int addr, byte value, bool log = false, string info = "")
		{
			DATA2[addr] = value;
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
				romLog.Append(addr.ToString("X6") + "/" + Utils.PcToSnes(addr).ToString("X6") + " : " + value.ToString("X2") + " // " + info + "\r\n");
			}
		}

		public static void WriteLong2(int addr, int value, bool log = false, string info = "")
		{
			DATA2[addr] = (byte) (value & 0xFF);
			DATA2[addr + 1] = (byte) ((value >> 8) & 0xFF);
			DATA2[addr + 2] = (byte) ((value >> 16) & 0xFF);

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
				romLog.Append(addr.ToString("X6") + "/" + Utils.PcToSnes(addr).ToString("X6") + " : Long(" + value.ToString("X6") + ") // " + info + "\r\n");
			}
		}
	}
}
