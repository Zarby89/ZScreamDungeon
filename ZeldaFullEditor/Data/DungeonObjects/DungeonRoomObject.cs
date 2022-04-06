using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public class TilesList
	{
		private readonly Tile[] _list;

		public Tile this[int i] => _list[i];

		private TilesList(Tile[] list)
		{
			_list = list;
		}

		public static readonly TilesList EmptySet = new TilesList(new Tile[]
			{
				new Tile(0, 0), new Tile(0, 0), new Tile(0, 0), new Tile(0, 0)
			});

		public static TilesList CreateNewDefinition(ZScreamer ZS, int position, int count)
		{
			if (count <= 0)
			{
				return EmptySet;
			}

			Tile[] list = new Tile[count];

			for (int i = 0; i < count; i++)
			{
				list[i] = new Tile(ZS.ROM[position + i * 2], ZS.ROM[position + (i * 2) + 1]);
			}

			return new TilesList(list);
		}

		public static TilesList CreateNewDefinitionFromMultipleAddresses(ZScreamer ZS, params (int address, int count)[] sources)
		{
			int count = 0;

			foreach ((int, int) s in sources)
			{
				count += s.Item2;
			}

			if (count <= 0)
			{
				return EmptySet;
			}

			Tile[] list = new Tile[count];

			int i = 0;

			foreach((int, int) s in sources)
			{
				for (int j = 0; j < s.Item2; j++, i++)
				{
					list[i] = new Tile(ZS.ROM[s.Item1 + i * 2], ZS.ROM[s.Item1 + (i * 2) + 1]);
				}
			}

			return new TilesList(list);
		}
	}


	// TODO new way to handle objects that change with the floor settings
	[Serializable]
	public unsafe class RoomObject
	{
		public ushort ID { get; }
		public byte X { get; set; } = 0;
		public byte Y { get; set; } = 0;
		public byte Layer { get; set; } = 0;
		public byte Size { get; set; } = 0;

		public int Width { get; set; } = 16;
		public int Height { get; set; } = 16;

		public byte NX { get; set; }
		public byte NY { get; set; }
		public bool DiagonalFix { get; set; } = false;

		public DungeonRoomObject ObjectType { get; }

		public List<Point> CollisionPoints { get; private set; } = new List<Point>();
		public TilesList Tiles { get; }

		public RoomObject(DungeonRoomObject type, TilesList tiles, byte x = 0, byte y = 0, byte l = 0, byte s = 0)
		{
			ObjectType = type;
			NX = X = x;
			NY = Y = y;
			Layer = l;
			Size = s;
			Tiles = tiles;
		}

		public RoomObject Clone()
		{
			return new RoomObject(ObjectType, Tiles)
			{
				X = X,
				Y = Y,
				Layer = Layer,
				Size = Size,
				Width = Width,
				Height = Height,
				NX = NX,
				NY = NY,
				DiagonalFix = DiagonalFix,
				CollisionPoints = CollisionPoints.DeepCopy()
			};
		}


		public void Draw(ZScreamer ZS)
		{
			CollisionPoints.Clear();
			ObjectType.Draw(ZS, this);
		}

		public void UpdateSize()
		{
			Width = 8;
			Height = 8;
		}

		public virtual bool DecreaseSize()
		{
			UpdateSize();
			if (Size > 0)
			{
				Size--;
				return true;
			}
			return false;
		}

		/// <summary>
		/// Increases the object's size by 1.
		/// </summary>
		/// <returns><see langword="true"/> when successful</returns>
		public virtual bool IncreaseSize()
		{
			UpdateSize();
			if (Size < 15)
			{
				Size++;
				return true;
			}
			return false;
		}
	}

	/// <summary>
	/// Just a version of room objects for UI preview.
	/// </summary>
	public unsafe class RoomObjectPreview : RoomObject
	{
		public RoomObjectPreview(DungeonRoomObject type, TilesList tiles) : base(type, tiles) { }
	}






	public partial class DungeonRoomObject
	{
		public string VanillaName { get; }
		public DungeonObjectSet ObjectSet { get; }
		public byte ID { get; }
		public DungeonObjectSizeability Resizeability { get; }

		public DrawObject Draw { get; }
		public SpecialObjectType Specialness { get; }

		/// <summary>
		/// What tile sets this object doesn't look like garbage in
		/// </summary>
		public List<byte> PrettyTileSets { get; }

		public List<ObjCategory> Categories { get; }

		public ushort FullID { get; }

		private DungeonRoomObject(ushort objectid, DrawObject drawfunc, DungeonObjectSizeability resizing, ObjCategory[] categories, byte[] gsets,
			SpecialObjectType special = SpecialObjectType.None)
		{
			string name = "PROBLEM";

			ObjectSet = (DungeonObjectSet) (objectid >> 8);
			ID = (byte) objectid;
			FullID = objectid;

			switch (ObjectSet)
			{
				case DungeonObjectSet.Set0:
					name = DefaultEntities.ListOfSet0RoomObjects[ID].Name;
					break;
				case DungeonObjectSet.Set1:
					name = DefaultEntities.ListOfSet1RoomObjects[ID].Name;
					break;
				case DungeonObjectSet.Set2:
					name = DefaultEntities.ListOfSet2RoomObjects[ID].Name;
					break;
			}

			VanillaName = name;
			Resizeability = resizing;
			Specialness = special;
			Categories = categories.ToList();
			PrettyTileSets = gsets.ToList();
			Draw = drawfunc;
		}


	}

	public enum DungeonObjectSet
	{
		Set0 = 0,
		Set1 = 1,
		Set2 = 2
	}

	public enum SpecialObjectType
	{
		None,
		InterroomStairs,
		Chest,
		BigChest,
		PushBlock,
		Torch,
	}

	[Flags]
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
		BackgroundMask,

		RoomTransition,

		Stairs,
		Pits,
		Ledge,
		Spikes,
		ShallowWater,
		DeepWater,
		IcyFloor,
		PuzzlePegs,
		Conveyor,

		Secrets, 
		Manipulable, // pots, hammerpegs, torches, etc
		Hookshottable,

		NorthSide,
		SouthSide,
		WestSide,
		EastSide,

		NorthPerimeter,
		SouthPerimeter,
		EastPerimeter,
		WestPerimeter,

		LowerLayer,
		UpperLayer,
		MetaLayer,
	}
}
