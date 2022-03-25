using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data
{
	public class DungeonRoomObject
	{
		private readonly string vn; public string VanillaName { get => vn; }

		private readonly DungeonObjectSet set; public DungeonObjectSet ObjectSet { get => set; }
		private readonly byte id; public byte ID { get => id; }

		private readonly DungeonObjectSizeability resize;
		public DungeonObjectSizeability Resizeability { get => resize; }

		/// <summary>
		/// What tile sets this object doesn't look like garbage in
		/// </summary>
		private readonly List<byte> goodsets;
		public List<byte> ValidTileSets { get => goodsets; }

		private readonly List<ObjCategory> cats;
		public List<ObjCategory> Categories { get => cats; }

		public ushort FullID
		{
			get
			{
				return (ushort) (((int) set << 8) | id);
			}
		}

		public DungeonRoomObject(int objectid, string vanillaname, DungeonObjectSizeability resizing,
			ObjCategory[] categories, byte[] gsets)
		{
			set = (DungeonObjectSet) (objectid >> 8);
			id = (byte) objectid;
			vn = vanillaname;
			resize = resizing;
			cats = categories.ToList();
			goodsets = gsets.ToList();
		}
		

		private DungeonRoomObject(int objectid, DungeonObjectSizeability resizing, ObjCategory[] categories, byte[] gsets)
		{
			string name = "PROBLEM";

			set = (DungeonObjectSet) (objectid >> 8);
			id = (byte) objectid;

			switch (set)
			{
				case DungeonObjectSet.Set0:
					name = DefaultEntities.ListOfSet0RoomObjects[id].Name;
					break;
				case DungeonObjectSet.Set1:
					name = DefaultEntities.ListOfSet1RoomObjects[id].Name;
					break;
				case DungeonObjectSet.Set2:
					name = DefaultEntities.ListOfSet2RoomObjects[id].Name;
					break;
			}

			vn = name;
			resize = resizing;
			cats = categories.ToList();
			goodsets = gsets.ToList();
		}

		/*
		 * All room object defaults
		 */
		public static DungeonRoomObject Object000 = new DungeonRoomObject(0x000, DungeonObjectSizeability.Horizontal,
			new ObjCategory[] { ObjCategory.Ceiling, ObjCategory.Collision, ObjCategory.BothLayers },
			new byte[] { 0 }
			);

		public static DungeonRoomObject Object001 = new DungeonRoomObject(0x001, DungeonObjectSizeability.Horizontal,
			new ObjCategory[] { ObjCategory.Wall, ObjCategory.Collision, ObjCategory.NorthSide, ObjCategory.UpperLayer },
			new byte[] { 0 }
			);

		public static DungeonRoomObject Object002 = new DungeonRoomObject(0x001, DungeonObjectSizeability.Horizontal,
			new ObjCategory[] { ObjCategory.Wall, ObjCategory.Collision, ObjCategory.SouthSide, ObjCategory.UpperLayer },
			new byte[] { 0 }
			);

		public static DungeonRoomObject Object003 = new DungeonRoomObject(0x001, DungeonObjectSizeability.Horizontal,
			new ObjCategory[] { ObjCategory.Wall, ObjCategory.Collision, ObjCategory.NorthSide, ObjCategory.LowerLayer },
			new byte[] { 0 }
			);

		public static DungeonRoomObject Object004 = new DungeonRoomObject(0x001, DungeonObjectSizeability.Horizontal,
			new ObjCategory[] { ObjCategory.Wall, ObjCategory.Collision, ObjCategory.SouthSide, ObjCategory.LowerLayer },
			new byte[] { 0 }
			);
	}

	public enum DungeonObjectSet
	{
		Set0 = 0,
		Set1 = 1,
		Set2 = 2
	}


	public enum DungeonObjectSizeability
	{
		None,
		Horizontal,
		Vertical,
		Both
	}

	public enum ObjCategory
	{
		NoCollision,
		Collision,
		DiagonalCollision,

		Wall,
		Ceiling,
		Floor,
		RoomDecoration,
		WallDecoration,

		Stairs,
		Pits,
		Ledge,
		Spikes,

		Manipulable, // pots, hammerpegs, torches, etc

		NorthSide,
		SouthSide,
		WestSide,
		EastSide,

		LowerLayer,
		UpperLayer,
		MetaLayer,
		BothLayers,
	}
}
