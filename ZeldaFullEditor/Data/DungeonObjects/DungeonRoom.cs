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

		public List<RoomObject> RoomObjectList { get; } = new List<RoomObject>();
		public List<Chest> ChestList { get; } = new List<Chest>();
		public List<PotItem> SecretsList { get; } = new List<PotItem>();

		public List<StaircaseRoom> StairsList { get; } = new List<StaircaseRoom>();
		public List<object> SelectedObjects { get; } = new List<object>();

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

		public bool MultiLayerOAM
		{
			get => moam;
			set
			{
				moam = value;
			}
		}

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
			foreach (RoomObject r in RoomObjectList)
			{
				r.Draw(ZS);
			}
		}


		private RoomObject ParseRoomObject(in byte layer, in byte b1, in byte b2, in byte b3, out byte posX, out byte posY)
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

			return new RoomObject(rtype, defn, posX, posY, layer, size);
		}

		private void LoadObjectsFromArray(byte[] data, int offset = 0)
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
			int staircount = 0;

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
						ended = layer == 3;
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
					// TODO adding doors
				}
				else
				{
					b3 = data[offset++];
					RoomObject r = ParseRoomObject(
						in layer, in b1, in b2, in b3,
						out byte posX, out byte posY);

					if (r != null)
					{
						RoomObjectList.Add(r);
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



			RoomObjectList.Clear();
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
	}
}
