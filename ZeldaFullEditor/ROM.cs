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

		public ushort Read16(int addr)
		{
			return (ushort) (DATA[addr++] | (DATA[addr++] << 8));
		}

		public int Read24(int addr)
		{
			return (ushort) (DATA[addr++] | (DATA[addr++] << 8) | (DATA[addr++] << 16));
		}

		public ushort Read16BE(int addr)
		{
			return (ushort) ((DATA[addr++] << 8) | DATA[addr++]);
		}

		public void Write16(int addr, params int[] words)
		{
			foreach (int i in words)
			{
				DATA[addr++] = (byte) i;
				DATA[addr++] = (byte) (i >> 8);
			}
		}

		public void Write16Continuous(ref int addr, params int[] words)
		{
			foreach (int i in words)
			{
				DATA[addr++] = (byte) i;
				DATA[addr++] = (byte) (i >> 8);
			}
		}

		public void Write24(int addr, params int[] words)
		{
			foreach (int i in words)
			{
				DATA[addr++] = (byte) i;
				DATA[addr++] = (byte) (i >> 8);
				DATA[addr++] = (byte) (i >> 16);
			}
		}

		public void Write16BE(int addr, params int[] words)
		{
			foreach (int i in words)
			{
				DATA[addr++] = (byte) (i >> 8);
				DATA[addr++] = (byte) i;
			}
		}

		public void Write24BE(int addr, params int[] words)
		{
			foreach (int i in words)
			{
				DATA[addr++] = (byte) (i >> 16);
				DATA[addr++] = (byte) (i >> 8);
				DATA[addr++] = (byte) i;
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
