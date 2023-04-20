using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data
{
	internal class SongAddress
	{
		public int Bank { get; set; }
		public int NSPCAddress { get; set; }
		public int PCOffset { get; set; }
		public string SongName { get; set; }
		public int Length { get; set; }

		public SongAddress(int bank, int nspcAddress, string songName, int pcOffset, int length)
		{
			Bank = bank;
			NSPCAddress = nspcAddress;
			PCOffset = pcOffset;
			SongName = songName;
			Length = length;
		}

		public override string ToString()
		{
			return $"{SongName} ({Length.ToString()})";
		}
	}
}
