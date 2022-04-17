using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public class DungeonRoom
	{
		public ushort RoomID { get; }

		public DungeonObjectsList Layer1Objects { get; } = new DungeonObjectsList();
		public DungeonObjectsList Layer2Objects { get; } = new DungeonObjectsList();
		public DungeonObjectsList Layer3Objects { get; } = new DungeonObjectsList();
		public DungeonDoorsList DungeonDoors { get; } = new DungeonDoorsList();
		public DungeonChestsList ChestList { get; } = new DungeonChestsList();
		public DungeonSecretsList SecretsList { get; } = new DungeonSecretsList();
		public DungeonSpritesList SpritesList { get; } = new DungeonSpritesList();

		public List<StaircaseRoom> StairsList { get; } = new List<StaircaseRoom>();
		public List<DungeonObject> SelectedObjects { get; } = new List<DungeonObject>();

		/// <summary>
		/// Returns an object if it is the only member of selected objects; otherwise, null
		/// </summary>
		public DungeonObject OnlySelectedObject
		{
			get
			{
				if (SelectedObjects.Count == 1)
				{
					return SelectedObjects[0];
				}
				return null;
			}
		}

		public bool HasUnsavedChanges { get; private set; }
		public byte[] StairDestinations { get; } = new byte[4];

		private byte layout;
		public byte Layout
		{
			get => layout;
			set
			{
				layout = value;
				// TODO layout draw/objects should probably be handled here with predefined layout lists
			}
		}

		private bool moam = false;
		internal object collisionMap;
		internal byte palette;
		internal int floor1;
		internal int bg2;
		internal int effect;
		internal int tag2;

		internal object[] collision_rectangles { get => throw new NotImplementedException(); }

		public bool MultiLayerOAM
		{
			get => moam;
			set
			{
				moam = value;
			}
		}


		// TODO
		public byte[] HeaderData
		{
			get
			{
				//(byte) ((((byte) all_rooms[i].bg2 & 0x07) << 5) + ((int) all_rooms[i].collision << 2) + (all_rooms[i].light ? 1 : 0)),
				//all_rooms[i].palette,
				//all_rooms[i].blockset,
				//all_rooms[i].spriteset,
				//(byte) all_rooms[i].effect,
				//(byte) all_rooms[i].tag1,
				//(byte) all_rooms[i].tag2,
				//(byte) ((all_rooms[i].holewarp_plane) | (all_rooms[i].staircase1Plane << 2) | (all_rooms[i].staircase2Plane << 4) | (all_rooms[i].staircase3Plane << 6)),
				//all_rooms[i].staircase4Plane,
				//all_rooms[i].holewarp,
				//all_rooms[i].staircase1,
				//all_rooms[i].staircase2,
				//all_rooms[i].staircase3,
				//all_rooms[i].staircase4
				return null;
			}
		}






		// TODO implement and rename
		public ushort MessageID { get; set; }
		public byte blockset { get; internal set; }
		public int tag1 { get; internal set; }
		public int collision { get; internal set; }


		private readonly ZScreamer ZS;
		private DungeonRoom(ZScreamer parent, ushort id)
		{
			RoomID = id;
			ZS = parent;
		}





		public static DungeonRoom BuildRoomFromROM(ZScreamer Z, ushort id)
		{
			DungeonRoom ret = new DungeonRoom(Z, id);

			// Load dungeon header
			int headerPointer = SNESFunctions.SNEStoPC(Z.ROM[Z.Offsets.room_header_pointer, 3]);
				
			int address = (Z.ROM[Z.Offsets.room_header_pointers_bank] << 16) | Z.ROM[headerPointer + (id * 2), size: 2];


			// Load room objects
			int objectPointer = SNESFunctions.SNEStoPC(Z.ROM[Z.Offsets.room_object_pointer, 3]);
			int room_address = objectPointer + (id * 3);

			int objects_location = SNESFunctions.SNEStoPC(Z.ROM[room_address, 3]);

			ret.LoadObjectsFromArray(Z.ROM.DataStream, offset: objects_location);
















			// Load sprites
			int spritePointer = 0x040000 | Z.ROM[Z.Offsets.rooms_sprite_pointer, 2];
			int sprite_address = SNESFunctions.SNEStoPC(Constants.DungeonSpritePointers | Z.ROM[spritePointer + (id * 2), size: 2]);
			ret.LoadSpritesFromArray(Z.ROM.DataStream, offset: sprite_address);


			return ret;
		}


		public void DrawEntireRoom()
		{
			foreach (RoomObject r in Layer1Objects)
			{
				r.Draw(ZS);
			}
		}


		private RoomObject ParseRoomObject(byte layer, byte b1, byte b2, byte b3, out byte posX, out byte posY)
		{
			byte size;
			ushort oid;

			if (b3 >= 0xF8) // Subtype 3
			{
				oid = (ushort) (0x0300 | ((b2 & 0x03) << 2) | (b1 & 0x03)); // TODO fix this ugly shit
				posX = (byte) ((b1 & 0xFC) >> 2);
				posY = (byte) ((b2 & 0xFC) >> 2);
				size = 0;
			}
			else if (b1 >= 0xFC) // Subtype 2
			{
				oid = (ushort) ((b3 & 0x3F) | 0x100);
				posX = (byte) ((b2 >> 4) | ((b1 & 0x03) << 4));
				posY = (byte) (((b2 & 0x0F) << 2) | (b3 >> 6));
				size = 0;
			}
			else // Subtype1
			{
				oid = b3;
				posX = (byte) ((b1 & 0xFC) >> 2);
				posY = (byte) ((b2 & 0xFC) >> 2);
				size = (byte) (((b1 & 0x03) << 2) | (b2 & 0x03));
			}

			RoomObjectType rtype = RoomObjectType.GetDungeonObject(oid);
			if (rtype == null)
			{
				return null;
			}

			TilesList defn = ZS.TileLister[oid];
			if (defn == null)
			{
				return null;
			}

			return
				new RoomObject(rtype, defn)
				{
					X = posX,
					Y = posY,
					Layer = layer,
					Size = size
				};
		}

		internal void ClearCollisionLayout()
		{
			throw new NotImplementedException();
		}

		internal void loadCollisionLayout(bool v)
		{
			throw new NotImplementedException();
		}

		private DungeonDoorObject ParseDoorObject(byte b1, byte b2)
		{
			return new DungeonDoorObject(
					DungeonDoorDraw.GetDirectionFromToken(b1),
					ZS.TileLister.GetDoorTileSet(b2)
				);
		}


		public void LoadObjectsFromArray(byte[] data, int offset = 0)
		{
			// Load chest items
			var chests = new List<ChestData>();

			int cpos = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.chests_data_pointer1, 3]);
			int clength = ZS.ROM[ZS.Offsets.chests_length_pointer, 2];

			for (int i = 0; i < clength; i++)
			{
				if ((ZS.ROM[cpos + (i * 3), 2] & 0x7FFF) == RoomID)
				{
					//There's a chest in that room !
					bool big = IntFunctions.BitIsOn(ZS.ROM[cpos + (i * 3), 2], 0x18000); // HACK: need to make this bigger than ushort.max

					chests.Add(new ChestData(ZS.ROM[cpos + (i * 3) + 2], big));
				}
			}

			StairsList.Clear();
			Layer1Objects.Clear();
			Layer2Objects.Clear();
			Layer3Objects.Clear();
			DungeonDoors.Clear();
			int staircount = 0;

			DungeonObjectsList currentList = Layer1Objects;
			Layout = (byte) ((data[offset++] >> 2) & 0x07);

			byte b1, b2, b3;
			byte layer = 0;
			bool door = false;
			bool ended = false;

			while (!ended)
			{
				b1 = data[offset++];
				b2 = data[offset++];

				if (b2 == 0xFF)
				{
					if (b1 == 0xFF)
					{
						door = false;
						layer++;
						switch (layer)
						{
							case 1:
								currentList = Layer1Objects;
								break;
							
							case 2:
								currentList = Layer2Objects;
								break;
							
							case 3:
								currentList = Layer3Objects;
								break;

							default:
								ended = true;
								break;
						}

						continue;
					}
					else if (b1 == 0xF0)
					{
						door = true;
						continue;
					}
				}

				if (door)
				{
					DungeonDoors.Add(ParseDoorObject(b1, b2));
				}
				else
				{
					b3 = data[offset++];
					RoomObject r = ParseRoomObject(
						layer, b1, b2, b3,
						out byte posX, out byte posY);

					if (r != null)
					{
						currentList.Add(r);
					}
					else
					{
						throw new Exception("Shit that's a bad room object.");
					}
				
					if (r.ObjectType.Specialness == SpecialObjectType.InterroomStairs)
					{
						if (staircount < 4)
						{
							StairsList.Add(new StaircaseRoom(posX, posY, $"To {StairDestinations[staircount++]:X2}"));
						}
						else
						{
							StairsList.Add(new StaircaseRoom(posX, posY, "BAD STAIR INDEX"));
						}
					}
					else if (r.ObjectType.Specialness == SpecialObjectType.Chest ||
						r.ObjectType.Specialness == SpecialObjectType.BigChest)
					{
						if (chests.Count > 0)
						{
							bool bigChest = r.ObjectType.Specialness == SpecialObjectType.BigChest;
							if (bigChest)
							{
								posX++;
							}
							ChestList.Add(new Chest(ZS, posX, posY, chests[0].itemIn, bigChest));
						}
					}
				}

			}
		}

		public RoomObject AddObject(ushort id, byte x, byte y, byte size, byte layer)
		{
			return
				new RoomObject(RoomObjectType.GetDungeonObject(id), ZS.TileLister[id])
				{
					X = x,
					Y = y,
					Size = size,
					Layer = layer
				};
		}


		public DungeonRoom Clone()
		{
			return this;
		}
		private void LoadSpritesFromArray(byte[] data, int offset = 0)
		{
			MultiLayerOAM = data[offset++] == 1;

			while (true)
			{
				byte b1 = data[offset++];

				if (b1 == Constants.SpriteTerminator) break;

				byte b2 = data[offset++];
				byte b3 = data[offset++];
			}
		}

		public void ClearAll()
		{
			Layer1Objects.Clear();
			Layer2Objects.Clear();
			Layer3Objects.Clear();
			DungeonDoors.Clear();
			SecretsList.Clear();
			SpritesList.Clear();
			ChestList.Clear();
		}


		public void reloadGfx(byte blockset = 0xFF)
		{
			throw new NotImplementedException();
		}

		internal void reloadLayout()
		{
			throw new NotImplementedException();
		}

		internal void DrawFloor1()
		{
			throw new NotImplementedException();
		}

		internal void DrawFloor2()
		{
			throw new NotImplementedException();
		}

		internal void update()
		{
			throw new NotImplementedException();
		}
	}
}
