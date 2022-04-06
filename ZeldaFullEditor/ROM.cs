using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public class ROMFile
	{
		private byte[] DATA = new byte[Constants.ROMSize];

		public byte[] DataStream => DATA;

		public int Length => DATA.Length;

		public ROMFile()
		{

		}

		public bool OhShitLastResortBackup(byte[] uhoh)
		{
			DATA = (byte[]) uhoh.Clone();
			return true;
		}

		/// <summary>
		/// Read or write a single byte at offset <paramref name="addr"/>.
		/// </summary>
		public byte this[int addr]
		{
			get => DATA[addr];
			set => DATA[addr] = value;
		}

		/// <summary>
		/// Read or write an integer of size <paramref name="size"/> bytes at offset <paramref name="addr"/>.
		/// Up to 4 bytes may be accessed at once via this operation.
		/// <br/>
		/// Reads of 0 or greater than 4 will be treated as 1 byte access.
		/// <para>
		/// Little-endian conversion is automatically handled by this operation.
		/// <br/>
		/// Use negative values of <paramref name="size"/> for big-endian access.
		/// </para>
		/// The data type returned depends on the size of the access:<br/>
		/// 1 - <see langword="byte"/><br/>
		/// 2 - <see langword="ushort"/><br/>
		/// 3 - <see langword="int"/><br/>
		/// 4 - <see langword="int"/><br/>
		/// </summary>
		// This use of a second parameter is frowned upon, but I don't care.
		public dynamic this[int addr, int size]
		{
			get
			{
				switch (size)
				{
					default:
					case 1:
					case -1:
						return DATA[addr];

					case 2:
						return (ushort) (DATA[addr] | (DATA[addr + 1] << 8));

					case -2:
						return (ushort) (DATA[addr + 1] | (DATA[addr] << 8));

					case 3:
						return DATA[addr] | (DATA[addr + 1] << 8) | (DATA[addr + 2] << 16);

					case -3:
						return DATA[addr + 2] | (DATA[addr + 1] << 8) | (DATA[addr] << 16);

					case 4:
						return DATA[addr] | (DATA[addr + 1] << 8) | (DATA[addr + 2] << 16) | (DATA[addr + 3] << 24);

					case -4:
						return DATA[addr+3] | (DATA[addr + 2] << 8) | (DATA[addr + 1] << 16) | (DATA[addr] << 24);
				}
			}

			set
			{
				switch (size)
				{
					case 1:
					case -1:
						DATA[addr] = (byte) value;
						break;

					case 2:
						DATA[addr] = (byte) value;
						DATA[addr + 1] = (byte) (value >> 8);
						break;

					case -2:
						DATA[addr + 1] = (byte) value;
						DATA[addr] = (byte) (value >> 8);
						break;

					case 3:
						DATA[addr] = (byte) value;
						DATA[addr + 1] = (byte) (value >> 8);
						DATA[addr + 2] = (byte) (value >> 16);
						break;

					case -3:
						DATA[addr + 2] = (byte) value;
						DATA[addr + 1] = (byte) (value >> 8);
						DATA[addr] = (byte) (value >> 16);
						break;

					case 4:
						DATA[addr] = (byte) value;
						DATA[addr + 1] = (byte) (value >> 8);
						DATA[addr + 2] = (byte) (value >> 16);
						DATA[addr + 3] = (byte) (value >> 24);
						break;

					case -4:
						DATA[addr + 3] = (byte) value;
						DATA[addr + 2] = (byte) (value >> 8);
						DATA[addr + 1] = (byte) (value >> 16);
						DATA[addr] = (byte) (value >> 24);
						break;

					case 0:
						throw new Exception("What does 0 byte access even mean?");

					default:
						throw new Exception("Quick access cannot exceed 4 bytes.");
				}
			}
		}

		public void LoadNewROM(string filename)
		{
			FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
			int size = (int) fs.Length;
			if (fs.Length < Constants.ROMSize)
			{
				size = Constants.ROMSize;
			}

			DATA = new byte[size];
			if ((fs.Length & Constants.ROMHeaderSize) == Constants.ROMHeaderSize)
			{
				size = (int) (fs.Length - Constants.ROMHeaderSize);
				byte[] tempRomData = new byte[fs.Length];
				fs.Read(tempRomData, 0, (int) fs.Length);
				Array.Copy(tempRomData, Constants.ROMHeaderSize, DATA, 0, size);
			}
			else
			{
				fs.Read(DATA, 0, (int) fs.Length);
			}

			fs.Close();
		}

		public void ApplyPatch(string path)
		{
			AsarCLR.Asar.init();

			if (!AsarCLR.Asar.patch(path, ref DATA))
			{
				System.Windows.Forms.MessageBox.Show("Error patching");
			}

			AsarCLR.Asar.close();
		}

		public void Write(int addr, params byte[] bytes)
		{
			foreach (byte b in bytes)
			{
				DATA[addr++] = b;
			}
		}

		/// <summary>
		/// Writes an arbitrary number of bytes to ROM,
		/// while incrementing the address passed to it for continuous writes.
		/// </summary>
		/// <param name="addr"></param>
		/// <param name="bytes"></param>
		public void WriteContinuous(ref int addr, params byte[] bytes)
		{
			foreach (byte b in bytes)
			{
				DATA[addr++] = b;
			}
		}

		public ROMFile Clone()
		{
			return new ROMFile()
				{
					DATA = DATA.DeepCopy()
				};
		}
	}
}
