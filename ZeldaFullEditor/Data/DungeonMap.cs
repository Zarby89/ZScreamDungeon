using System.Collections.Generic;

namespace ZeldaFullEditor
{
	/// <summary>
	///     An object containing data about each dungeon map.
	/// </summary>
	public class DungeonMap
	{
		/// <summary>
		///     Gets or sets the boss room of the map.
		/// </summary>
		public ushort BossRoom { get; set; } = 0xFFFF;

		/// <summary>
		///     Gets or sets the number of floors the map has.
		/// </summary>
		public byte NumberOfFloors { get; set; } = 0;

		/// <summary>
		///     Gets or sets the number of basements the map has.
		/// </summary>
		public byte NumberOfBasements { get; set; } = 0;

		/// <summary>
		///     Gets or sets the rooms the map has.
		/// </summary>
		public List<byte[]> FloorRooms { get; set; } = new List<byte[]>();

		/// <summary>
		///     Gets or sets the gfx of the map.
		/// </summary>
		public List<byte[]> FloorGFX { get; set; } = new List<byte[]>();

		/// <summary>
		///     Initializes a new instance of the <see cref="DungeonMap"/> class.
		/// </summary>
		/// <param name="bossRoom"> The boss room. </param>
		/// <param name="numberOfFloors"> The number of floors. </param>
		/// <param name="numberOfBasements"> The number of basements. </param>
		/// <param name="floorRooms"> The floors. </param>
		/// <param name="floorGFX"> The floor GFX. </param>
		public DungeonMap(ushort bossRoom, byte numberOfFloors, byte numberOfBasements, List<byte[]> floorRooms, List<byte[]> floorGFX)
		{
			this.BossRoom = bossRoom;
			this.NumberOfFloors = numberOfFloors;
			this.NumberOfBasements = numberOfBasements;
			this.FloorRooms = new List<byte[]>(floorRooms);
			this.FloorGFX = new List<byte[]>(floorGFX);
		}
	}
}
