namespace ZeldaFullEditor.ALTTP.GameData.GraphicsData;

public readonly struct Tile32 : IEquatable<Tile32>
{
	/// <summary>
	/// The tile16 in the top-left corner
	/// </summary>
	public ushort Tile0 { get; }

	/// <summary>
	/// The tile16 in the top-right corner
	/// </summary>
	public ushort Tile1 { get; }

	/// <summary>
	/// The tile16 in the bottom-left corner
	/// </summary>
	public ushort Tile2 { get; }

	/// <summary>
	/// The tile16 in the bottom-right corner
	/// </summary>
	public ushort Tile3 { get; }

	public Tile32(ushort tile0, ushort tile1, ushort tile2, ushort tile3)
	{
		Tile0 = tile0;
		Tile1 = tile1;
		Tile2 = tile2;
		Tile3 = tile3;
	}

	public static bool operator ==(Tile32 a, Tile32 b)
	{
		return a.Tile0 == b.Tile0 && a.Tile1 == b.Tile1 && a.Tile2 == b.Tile2 && a.Tile3 == b.Tile3;
	}

	public static bool operator !=(Tile32 a, Tile32 b)
	{
		return a.Tile0 != b.Tile0 || a.Tile1 != b.Tile1 || a.Tile2 != b.Tile2 || a.Tile3 != b.Tile3;
	}

	public static readonly Tile32 Empty = new(0, 0, 0, 0);

	public override bool Equals(object obj) => obj switch
	{
		Tile32 other => Equals(other),
		_ => false,
	};

	public override int GetHashCode()
	{
		return (Tile0 | (Tile1 << 16)) ^ (Tile2 | (Tile3 << 16));
	}

	public bool Equals(Tile32 other)
	{
		return Tile0 == other.Tile0 && Tile1 == other.Tile1 && Tile2 == other.Tile2 && Tile3 == other.Tile3;
	}
}
