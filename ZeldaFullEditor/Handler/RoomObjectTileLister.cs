namespace ZeldaFullEditor.Handler;

/// <summary>
/// <para>
/// Contains and provides functionality for distributing room object tile tables.
/// </para>
/// <para>
/// This class should be instantiated once per <see cref="ZScreamer"/>, after its ROM is loaded.
/// </para>
/// </summary>
public class RoomObjectTileLister
{

	private const int ListLength = 0x1A00;

	public Tile[] ObjectTilesList { get; init; } = null;

	public Tile this[int baseOffset, int tileOffset] => ObjectTilesList[(baseOffset / 2) + tileOffset];
	public Tile this[int realOffset] => ObjectTilesList[realOffset];



	public byte CurrentFloor1 { get; set; }

	public byte CurrentFloor2 { get; set; }

	private RoomObjectTileLister()
	{

	}

	public ushort[] GetUnsignedShorts(int baseIndex, int count)
	{
		return ObjectTilesList.Take(new Range(baseIndex, baseIndex + count)).Select(o => o.ToUnsignedShort()).ToArray();
	}

	public ushort[] GetUnsignedFloor1Shorts() => GetUnsignedShorts(CurrentFloor1 * 16, 8);
	public ushort[] GetUnsignedFloor2Shorts() => GetUnsignedShorts(CurrentFloor2 * 16, 8);

	/// <summary>
	/// Parses the ROM file for the given <see cref="ZScreamer"/>,
	/// using the respective offsets found in that Screamer.
	/// </summary>
	/// <returns>A new <see cref="RoomObjectTileLister"/> containing data for all existing room objects.</returns>
	/// 
	public static RoomObjectTileLister CreateTileListingsFromROM(ZScreamer ZS)
	{
		var ret = new Tile[ListLength];

		for (int i = 0, o = 0x009B52.SNEStoPC(); i < ListLength; i++, o += 2)
		{
			ret[i] = new Tile(ZS.ROM.Read16(o));
		}

		return new()
		{
			ObjectTilesList = ret
		};
	}
}
