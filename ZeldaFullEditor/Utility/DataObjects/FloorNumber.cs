namespace ZeldaFullEditor
{
	public class FloorNumber
	{
		public string Name { get; }
		public byte Value { get; }

		private FloorNumber(string n, byte v)
		{
			Name = n;
			Value = v;
		}

		public override string ToString() => Name;

		public static int FindFloorIndex(byte b)
		{
			// Code by bhaalsen
			// Array.FindIndex(floors, 0, floors.Length, f => f.ByteValue == b);

			for (int i = 0; i < floors.Length; i++)
			{
				if (b == floors[i].Value)
				{
					return i;
				}
			}
			return -1;
		}

		public static readonly FloorNumber[] floors =
		{
			new("B8", 0xF8),
			new("B7", 0xF9),
			new("B6", 0xFA),
			new("B5", 0xFB),
			new("B4", 0xFC),
			new("B3", 0xFD),
			new("B2", 0xFE),
			new("B1", 0xFF),
			new("1F", 0x00),
			new("2F", 0x01),
			new("3F", 0x02),
			new("4F", 0x03),
			new("5F", 0x04),
			new("6F", 0x05),
			new("7F", 0x06),
			new("8F", 0x07)
		};
	}
}
