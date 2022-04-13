using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public class FloorNumber
	{
		public string Name { get; }
		public byte ByteValue { get; }

		private FloorNumber(string n, byte v)
		{
			Name = n;
			ByteValue = v;
		}

		public override string ToString()
		{
			return Name;
		}

		public static int FindFloorIndex(byte b)
		{
			for (int i = 0; i < floors.Length; i++)
			{
				if (b == floors[i].ByteValue)
				{
					return i;
				}
			}
			return -1;
		}

		public static readonly FloorNumber[] floors =
		{
			new FloorNumber("B8", 0xF8),
			new FloorNumber("B7", 0xF9),
			new FloorNumber("B6", 0xFA),
			new FloorNumber("B5", 0xFB),
			new FloorNumber("B4", 0xFC),
			new FloorNumber("B3", 0xFD),
			new FloorNumber("B2", 0xFE),
			new FloorNumber("B1", 0xFF),
			new FloorNumber("1F", 0x00),
			new FloorNumber("2F", 0x01),
			new FloorNumber("3F", 0x02),
			new FloorNumber("4F", 0x03),
			new FloorNumber("5F", 0x04),
			new FloorNumber("6F", 0x05),
			new FloorNumber("7F", 0x06),
			new FloorNumber("8F", 0x07)
		};
	}
}
