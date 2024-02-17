using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace ZeldaFullEditor
{
	// have a "set up consecutive writes" thing, where ROM class will handle all address increments
	public static class ROM
	{
		public static volatile byte[] DATA;
		public static byte[] DATA2;
		public static byte[] TEMPDATA;
		public static StringBuilder romLog = new StringBuilder();
		public static bool logBlock = false;
		private static int biggerAddress = 0;
		private static string blockName = "";
		public static bool AdvancedLogs = true;
		public static List<LogInfos> advancedLogData = new List<LogInfos>();
		public static int uniqueSpriteID = 0;
		public static int uniqueItemID = 0;
		public static int uniqueEntranceID = 0;
		public static int uniqueExitID = 0;
		public static int uniqueTransportID = 0;
		public static int uniqueRoomObjectID = 0;
		public static int uniqueGraveID = 0;
		public static int spaceUsedOWSprites = 0;

		// TODO remove all the Write2, etc and create a protected mode
		/*
		public static bool WriteToOther { get; set; } = false;
		private static volatile byte[] realData;
		private static volatile byte[] secondaryData;

		public static volatile byte[] DATA => WriteToOther ? secondaryData : realData;
		*/





		public static void StartBlockLogWriting(string name, int addr)
		{
			var s = $"{name}\r\n{addr:X6}/{addr.PcToSnes():X6} [Block of Data]({name})\r\n";
			//romLog.Append(s);
			advancedLogData.Add(new LogInfos(addr, s));
			biggerAddress = addr;
			blockName = name;
			logBlock = false;
		}

		public static void EndBlockLogWriting()
		{
			//romLog.Append($"{biggerAddress:X6}/{biggerAddress.PcToSnes():X6} [END Block of Data({blockName})\r\n");
			logBlock = false;
		}

		public static void Write(int addr, byte value, WriteType info)
		{
			Write(addr, value, true, info.Text);
		}

		public static void Write(int addr, byte value, bool log = true, string info = null)
		{
			DATA[addr] = value;
			AdjustBlock(addr + 1);

			if (AdvancedLogs && log)
			{
				var s = $"{addr:X6}/{addr.PcToSnes():X6} : {value:X2} // {info ?? ""}\r\n";
				advancedLogData.Add(new LogInfos(addr, s));
				//romLog.Append(s);
			}
		}

		public static void Write(int addr, byte[] value, WriteType info)
		{
			Write(addr, value, true, info.Text);
		}

		public static void Write(int addr, byte[] value, bool log = true, string info = null)
		{
			AdjustBlock(addr + value.Length);

			Array.Copy(value, 0, DATA, addr, value.Length);

			if (AdvancedLogs && log)
			{
				var comA = $"{info} {addr:X6}/{addr.PcToSnes():X6} : ";
				var theBytes = value.Select(b => $"{b:X2}");
				var comB = string.Join(", ", theBytes);
				advancedLogData.Add(new LogInfos(addr, $"{comA}{comB} {info ?? ""}\r\n"));
			}
		}

		public static void WriteLong(int addr, int value, bool log = true, string info = null)
		{
			DATA[addr] = (byte) value;
			DATA[addr + 1] = (byte) (value >> 8);
			DATA[addr + 2] = (byte) (value >> 16);

			AdjustBlock(addr + 3);

			if (AdvancedLogs && log)
			{
				var s = $"{addr:X6}/{addr.PcToSnes():X6} : Long({value:X6}) // {info ?? ""}\r\n";
				//romLog.Append(s);
				advancedLogData.Add(new LogInfos(addr, s));
			}
		}

		public static void WriteShort(int addr, int value, WriteType w)
		{
			WriteShort(addr, value, true, w.Text);
		}

		public static void WriteShort(int addr, int value, bool log = true, string info = null)
		{
			DATA[addr] = (byte) value;
			DATA[addr + 1] = (byte) (value >> 8);

			AdjustBlock(addr + 2);

			if (AdvancedLogs && log)
			{
				var s = $"{addr:X6}/{addr.PcToSnes():X6} : Word({value:X4}) // {info ?? ""}\r\n";
				advancedLogData.Add(new LogInfos(addr, s));
				//romLog.Append(s);
			}
		}

		public static int ReadLong(int addr)
		{
			return (DATA[addr + 2] << 16) | (DATA[addr + 1] << 8) | DATA[addr];
		}

		public static Tile16 ReadTile16(int addr)
		{
			ushort t1 = (ushort) ((DATA[addr + 1] << 8) | DATA[addr]);
			ushort t2 = (ushort) ((DATA[addr + 3] << 8) | DATA[addr + 2]);
			ushort t3 = (ushort) ((DATA[addr + 5] << 8) | DATA[addr + 4]);
			ushort t4 = (ushort) ((DATA[addr + 7] << 8) | DATA[addr + 6]);
			return new Tile16((ulong) ((t1 << 48) | (t2 << 32) | (t3 << 16) | t4));
		}

		public static ushort ReadShort(int addr)
		{
			return (ushort) ((DATA[addr + 1] << 8) | DATA[addr]);
		}

		public static short ReadRealShort(int addr)
		{
			return (short) ((DATA[addr + 1] << 8) | DATA[addr]);
		}

		public static byte ReadByte(int addr)
		{
			return DATA[addr];
		}

		public static byte[] ReadBlock(int addr, int length)
		{
			byte[] arr = new byte[length];
			Array.Copy(DATA, addr, arr, 0, length);

			return arr;
		}

		public static short ReadReverseShort(int addr)
		{
			return (short) ((DATA[addr] << 8) | DATA[addr + 1]);
		}

		public static void SaveLogs()
		{
			string fname = "Logs.txt";
			var readOut = advancedLogData.OrderByDescending(o => int.MaxValue - o.address); // - to get free Ascending sort

			foreach (var s in readOut)
			{
				romLog.Append(s.text);
			}

			File.WriteAllText(fname, romLog.ToString());
			advancedLogData.Clear();
			romLog.Clear();
		}

		public static void WriteShort2(int addr, int value, bool log = false, string info = null)
		{
			DATA2[addr] = (byte) value;
			DATA2[addr + 1] = (byte) (value >> 8);

			AdjustBlock(addr + 2);

			if (AdvancedLogs && log)
			{
				romLog.Append($"{addr:X6}/{addr.PcToSnes():X6} : Word({value:X4}) // {info ?? ""}\r\n");
			}
		}

		public static void Write2(int addr, byte[] value, bool log = false, string info = null)
		{
			AdjustBlock(addr + value.Length);

			Array.Copy(value, 0, DATA2, addr, value.Length);

			if (AdvancedLogs && log)
			{
				var comA = $"{info} {addr:X6}/{addr.PcToSnes():X6} : ";
				var comB = string.Join(", ", value.Select(b => $"{b:X2}"));
				advancedLogData.Add(new LogInfos(addr, $"{comA}{comB} {info ?? ""}\r\n"));
			}
		}

		public static void Write2(int addr, byte value, bool log = false, string info = null)
		{
			DATA2[addr] = value;

			AdjustBlock(addr + 1);

			if (AdvancedLogs && log)
			{
				romLog.Append($"{addr:X6}/{addr.PcToSnes():X6} : {value:X2} // {info ?? ""}\r\n");
			}
		}

		public static void WriteLong2(int addr, int value, bool log = false, string info = null)
		{
			DATA2[addr] = (byte) value;
			DATA2[addr + 1] = (byte) (value >> 8);
			DATA2[addr + 2] = (byte) (value >> 16);

			AdjustBlock(addr + 3);

			if (AdvancedLogs && log)
			{
				romLog.Append($"{addr:X6}/{addr.PcToSnes():X6} : Long({value:X6}) // {info ?? ""}\r\n");
			}
		}

		private static void AdjustBlock(int addr)
		{
			if (logBlock)
			{
				if (addr > biggerAddress)
				{
					biggerAddress = addr;
				}
			}
		}
	}
}
