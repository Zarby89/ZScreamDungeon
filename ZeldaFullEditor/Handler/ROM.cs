namespace ZeldaFullEditor.Handler;

/// <summary>
/// Provides a container and methods for manipulating a SNES ROM binary.
/// </summary>
public class ROMFile
{
	private byte[] DATA;

	public byte[] DataStream
	{
		get => DATA;
		init => DATA = value.DeepCopy();
	}

	public int Length => DATA.Length;

	/// <summary>
	/// Initializes a new instance of the <see cref="ROMFile"/> with an empty 2Mb data stream.
	/// </summary>
	public ROMFile()
	{
		DATA = new byte[Constants.ROMSize];
	}

	/// <summary>
	/// Creates a new ROM with the lorom mapping from the binary data found at <paramref name="path"/>.
	/// </summary>
	public ROMFile(string path)
	{
		var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
		var size = (int) fs.Length;
		if (fs.Length < Constants.ROMSize)
		{
			size = Constants.ROMSize;
		}

		DATA = new byte[size];
		if ((fs.Length & Constants.ROMHeaderSize) == Constants.ROMHeaderSize)
		{
			size = (int) (fs.Length - Constants.ROMHeaderSize);
			var tempRomData = new byte[fs.Length];
			fs.Read(tempRomData, 0, (int) fs.Length);
			Array.Copy(tempRomData, Constants.ROMHeaderSize, DATA, 0, size);
		}
		else
		{
			fs.Read(DATA, 0, (int) fs.Length);
		}

		fs.Close();
	}

	public void OhShitLastResortBackup(byte[] uhoh)
	{
		DATA = uhoh.DeepCopy();
	}

	/// <summary>
	/// Read or write a single byte at offset <paramref name="addr"/>.
	/// </summary>
	public byte this[int addr]
	{
		get => DATA[addr];
		set => DATA[addr] = value;
	}

	public void ApplyPatch(string path)
	{
		AsarCLR.Asar.init();

		if (!AsarCLR.Asar.patch(path, ref DATA))
		{
			MessageBox.Show("Error patching");
		}

		AsarCLR.Asar.close();
	}

	/// <summary>
	/// Writes an arbitrary number of <see langword="bytes"/> to ROM,
	/// consecutively starting at the given <paramref name="address"/>.
	/// </summary>.
	/// <param name="address">Start address</param>
	public void Write(int address, params byte[] bytes)
	{
		foreach (var b in bytes)
		{
			DATA[address++] = b;
		}
	}

	/// <summary>
	/// <para>
	/// Writes an arbitrary number of <see langword="bytes"/> to ROM,
	/// consecutively starting at the given <paramref name="address"/>.
	/// </para>
	/// <para>
	/// Passing <paramref name="address"/> with the <see langword="ref"/> keyword
	/// allows this method to take care of incrementation.
	/// </para>
	/// </summary>.
	/// <param name="address">Start address</param>
	public void WriteContinuous(ref int address, params byte[] bytes)
	{
		foreach (var b in bytes)
		{
			DATA[address++] = b;
		}
	}

	/// <summary>
	/// Returns an array of <paramref name="count"/> consecutive <see langword="bytes"/>
	/// beginning at <paramref name="address"/>.
	/// </summary>
	public byte[] Read8Many(int address, int count)
	{
		return DATA[address..(address + count)];
	}

	/// <summary>
	/// Gets the 16-bit word at the given <paramref name="address"/> in little endian.
	/// </summary>
	/// <returns>A <see langword="ushort"/> representing the <see langword="bytes"/> at
	/// <paramref name="address"/> and <paramref name="address"/>+1 when interpreted as
	/// a single, little-endian, 16-bit word.</returns>
	public ushort Read16(int address)
	{
		return (ushort) (DATA[address++] | DATA[address] << 8);
	}
	
	public ushort Read16Continuous(ref int address)
	{
		return (ushort) (DATA[address++] | DATA[address++] << 8);
	}


	/// <summary>
	/// Gets an array of 16-bit words at the given <paramref name="address"/> in little endian.
	/// </summary>
	public ushort[] Read16Many(int address, int count)
	{
		var ret = new ushort[count];

		for (int i = 0; i < count; i++)
		{
			ret[i] = (ushort) (DATA[address++] | DATA[address++] << 8);
		}

		return ret;
	}

	/// <summary>
	/// Gets the 24-bit word at the given <paramref name="address"/> in little endian.
	/// </summary>
	/// <returns>An <see langword="int"/> representing the <see langword="bytes"/> at
	/// <paramref name="address"/>, <paramref name="address"/>+1, and <paramref name="address"/>+2,
	/// when interpreted as a single, little-endian, 24-bit word.</returns>
	public int Read24(int address)
	{
		return DATA[address++] | (DATA[address++] << 8) | (DATA[address] << 16);
	}

	/// <summary>
	/// Gets the 16-bit word at the given <paramref name="address"/> in big endian.
	/// </summary>
	/// <returns>A <see langword="ushort"/> representing the <see langword="bytes"/> at
	/// <paramref name="address"/> and <paramref name="address"/>+1 when interpreted as
	/// a single, big-endian, 16-bit word.</returns>
	public ushort Read16BigEndian(int address)
	{
		return (ushort) ((DATA[address++] << 8) | DATA[address]);
	}

	/// <summary>
	/// Writes an arbitrary number of <see langword="ushorts"/> to ROM,
	/// consecutively starting at the given <paramref name="address"/>,
	/// splitting the constituent <see langword="bytes"/> and writing them
	/// in little-endian order.
	/// </summary>.
	public void Write16(int address, params int[] words)
	{
		foreach (var i in words)
		{
			DATA[address++] = (byte) i;
			DATA[address++] = (byte) (i >> 8);
		}
	}

	/// <summary>
	/// <para>
	/// Writes an arbitrary number of <see langword="ushorts"/> to ROM,
	/// consecutively starting at the given <paramref name="address"/>,
	/// splitting the constituent <see langword="bytes"/> and writing them
	/// in little-endian order.
	/// </para>
	/// <para>
	/// Passing <paramref name="address"/> with the <see langword="ref"/> keyword
	/// allows this method to take care of incrementation.
	/// </para>
	/// </summary>.
	public void Write16Continuous(ref int address, params int[] words)
	{
		foreach (var i in words)
		{
			DATA[address++] = (byte) i;
			DATA[address++] = (byte) (i >> 8);
		}
	}

	/// <summary>
	/// Writes an arbitrary number of 24-bit values passed as <see langword="ints"/> to ROM,
	/// consecutively starting at the given <paramref name="address"/>,
	/// splitting the constituent <see langword="bytes"/> and writing them
	/// in little-endian order.
	/// </summary>.
	public void Write24(int address, params int[] words)
	{
		foreach (var i in words)
		{
			DATA[address++] = (byte) i;
			DATA[address++] = (byte) (i >> 8);
			DATA[address++] = (byte) (i >> 16);
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
