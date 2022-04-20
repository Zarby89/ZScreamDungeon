using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.DungeonObjects
{
	public class DungeonRoom
	{
		public ushort RoomID { get; }

		private byte[] blocks = new byte[16];


		public DungeonObjectsList Layer1Objects { get; } = new DungeonObjectsList();
		public DungeonObjectsList Layer2Objects { get; } = new DungeonObjectsList();
		public DungeonObjectsList Layer3Objects { get; } = new DungeonObjectsList();

		public DungeonDoorsList DoorsList { get; } = new DungeonDoorsList();
		public DungeonRoomChestsHandler ChestList { get; }
		public DungeonSecretsList SecretsList { get; } = new DungeonSecretsList();
		public DungeonSpritesList SpritesList { get; } = new DungeonSpritesList();
		public DungeonBlocksList BlocksList { get; } = new DungeonBlocksList();
		public DungeonTorchList TorchList { get; } = new DungeonTorchList();

		public List<StaircaseRoom> StairsList { get; } = new List<StaircaseRoom>();
		public List<DungeonPlaceable> SelectedObjects { get; } = new List<DungeonPlaceable>();


		/// <summary>
		/// Returns an object if it is the only member of selected objects; otherwise, null
		/// </summary>
		public DungeonPlaceable OnlySelectedObject
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

		public bool HasUnsavedChanges { get; internal set; }
		public byte[] StairDestinations { get; } = new byte[4];

		private byte layout;
		public byte Layout
		{
			get => layout;
			set
			{
				value &= 0x07;
				layout = value;
				LayoutListing = ZS.LayoutLister[value];
			}
		}
		public RoomLayoutObjects LayoutListing { get; private set; }

		private bool moam = false;
		internal object collisionMap;

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

		public byte[] TileObjectData
		{
			// TODO add layout and shit
			get
			{
				var ret = new List<byte>();

				ret.Add(0x00); // TODO write floor
				ret.Add(0x00); // TODO write layout

				ret.AddRange(Layer1Objects.Data);
				ret.Add(0xFFFF);

				ret.AddRange(Layer2Objects.Data);
				ret.Add(0xFFFF);

				ret.AddRange(Layer3Objects.Data);

				if (DoorsList.Count > 0)
				{
					ret.Add(0xFFF0);

					ret.AddRange(DoorsList.Data);
				}

				ret.Add(0xFFFF);

				return ret.ToArray();
			}
		}

		public byte[] TorchesData
		{
			get
			{
				var ret = new List<byte>();
				ret.Add(RoomID);

				ret.AddRange(TorchList.Data);

				ret.Add(0xFFFF);

				return ret.ToArray();
			}
		}


		public bool IsEmpty
		{
			get
			{
				return Layer1Objects.Count == 0 &&
					Layer2Objects.Count == 0 &&
					Layer3Objects.Count == 0 &&
					DoorsList.Count == 0 &&
					ChestList.Count == 0 &&
					SecretsList.Count == 0 &&
					SpritesList.Count == 0 &&
					BlocksList.Count == 0 &&
					TorchList.Count == 0;
			}
		}

		// TODO implement and rename
		public ushort MessageID { get; set; }
		public byte blockset { get; set; }
		public byte spriteset { get; set; }
		public byte collision { get; set; }
		public byte palette { get; set; }
		public byte floor1 { get; set; }
		public byte floor2 { get; set; }
		public byte bg2 { get; set; }
		public byte effect { get; set; }
		public byte tag1 { get; set; }
		public byte tag2 { get; set; }

		public byte holewarp { get; set; }
		public byte staircase1 { get; set; }
		public byte staircase2 { get; set; }
		public byte staircase3 { get; set; }
		public byte staircase4 { get; set; }

		public byte holewarp_plane { get; set; }
		public byte staircase1Plane { get; set; }
		public byte staircase2Plane { get; set; }
		public byte staircase3Plane { get; set; }
		public byte staircase4Plane { get; set; }




		public bool damagepit { get; set; }

		private readonly ZScreamer ZS;
		private DungeonRoom(ZScreamer zs, ushort id)
		{
			RoomID = id;
			ZS = zs;
		}



		public unsafe void reloadAnimatedGfx()
		{
			int gfxanimatedPointer = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.gfx_animated_pointer, 3]);

			byte* newPdata = (byte*) ZS.GFXManager.allgfx16Ptr.ToPointer(); // Turn gfx16 (all 222 of them)
			byte* sheetsData = (byte*) ZS.GFXManager.currentgfx16Ptr.ToPointer(); // Into "room gfx16" 16 of them

			int data = 0;
			while (data < 512)
			{
				byte mapByte = newPdata[data + (92 * 2048) + (512 * ZS.GFXManager.animated_frame)];
				sheetsData[data + (7 * 2048)] = mapByte;

				mapByte = newPdata[data + (ZS.ROM[gfxanimatedPointer + blockset] * 2048) + (512 * ZS.GFXManager.animated_frame)];
				sheetsData[data + (7 * 2048) - 512] = mapByte;
				data++;
			}
		}

		public void reloadGfx(byte entrance_blockset = 0xFF)
		{
			for (int i = 0; i < 8; i++)
			{
				blocks[i] = ZS.GFXGroups.mainGfx[blockset][i];
				if (i >= 6 && i <= 6)
				{
					if (entrance_blockset != 0xFF) //3-6
					{
						// 6 is wrong for the entrance? -NOP need to fix that 
						// TODO: Find why this is wrong - Thats because of the stairs need to find a workaround
						if (ZS.GFXGroups.roomGfx[entrance_blockset][i - 3] != 0)
						{
							blocks[i] = ZS.GFXGroups.roomGfx[entrance_blockset][i - 3];
						}
					}
				}
			}

			blocks[8] = 115 + 0; // Static Sprites Blocksets (fairy,pot,ect...)
			blocks[9] = 115 + 10;
			blocks[10] = 115 + 6;
			blocks[11] = 115 + 7;
			for (int i = 0; i < 4; i++)
			{
				blocks[12 + i] = (byte) (ZS.GFXGroups.spriteGfx[spriteset + 64][i] + 115);
			} // 12-16 sprites

			unsafe
			{
				byte* newPdata = (byte*) ZS.GFXManager.allgfx16Ptr.ToPointer(); // Turn gfx16 (all 222 of them)
				byte* sheetsData = (byte*) ZS.GFXManager.currentgfx16Ptr.ToPointer(); // Into "room gfx16" 16 of them
				int sheetPos = 0;
				for (int i = 0; i < 16; i++)
				{
					int d = 0;
					int ioff = blocks[i] * 2048;
					while (d < 2048)
					{
						// NOTE LOAD BLOCKSETS SOMEWHERE FIRST
						byte mapByte = newPdata[d + ioff];
						if (i < 4) //removed switch
						{
							mapByte += 0x88;
						} // Last line of 6, first line of 7 ?

						sheetsData[d + sheetPos] = mapByte;
						d++;
					}

					sheetPos += 2048;
				}

				reloadAnimatedGfx();
			}
		}




		public static DungeonRoom BuildRoomFromROM(ZScreamer Z, ushort id)
		{
			DungeonRoom ret = new DungeonRoom(Z, id);

			// Load dungeon header
			int headerPointer = SNESFunctions.SNEStoPC(Z.ROM[Z.Offsets.room_header_pointer, 3]);

			ret.MessageID = Z.ROM[Z.Offsets.messages_id_dungeon + (id * 2), 2];

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

			// Load other stuff
			ret.LoadChests();
			ret.LoadBlocks();
			ret.LoadTorches();
			ret.LoadSecrets();
			ret.ReassociateChestsAndItems();

			return ret;
		}



		// TODO this is where we'll flush temporary edits to the new listing
		public void FlushChanges()
		{
			if (!HasUnsavedChanges)
			{
				return;
			}

			HasUnsavedChanges = false;
			throw new NotImplementedException();
		}


		private void LoadChests()
		{
			ChestList.Clear();

			int cpos = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.chests_data_pointer1, 3]);
			int clength = ZS.ROM[ZS.Offsets.chests_length_pointer, 2];

			for (int i = 0; i < clength; i += 3)
			{
				ushort roomid = (ushort) (ZS.ROM[cpos, size: 2] & 0x7FFF);
				cpos += 2;
				byte item = ZS.ROM[cpos++]; // get now so cpos is incremented too

				if (roomid == RoomID)
				{
					ChestList.Add(new DungeonChestItem(ItemReceipt.FindFromID(item)));
				}
			}
		}

		private void LoadBlocks()
		{
			int blockCount = ZS.ROM[ZS.Offsets.blocks_length, size: 2];

			int pos1 = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.blocks_pointer1, size: 3]);
			int pos2 = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.blocks_pointer2, size: 3]);
			int pos3 = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.blocks_pointer3, size: 3]);
			int pos4 = SNESFunctions.SNEStoPC(ZS.ROM[ZS.Offsets.blocks_pointer4, size: 3]);

			for (int j = 0, i = 0; j < blockCount; j += 4, i++)
			{
				ushort room = (ushort) (ZS.ROM[pos1 + i] | (ZS.ROM[pos2 + i] << 8));

				if (room != RoomID) continue;

				var p = UWTilemapPosition.CreateFromTileMapPosition(ZS.ROM[pos3 + i], (byte) (ZS.ROM[pos4 + i] & 0x3F));
				BlocksList.Add(
					new DungeonBlock()
					{
						X = p.X,
						Y = p.Y,
						Layer = p.Layer,
					}
				);
			}
		}

		private void LoadTorches()
		{
			int torchesSize = ZS.ROM[ZS.Offsets.torches_length_pointer, size: 2];
			int pos = ZS.Offsets.torch_data;
			int ending = pos + torchesSize;

			while (pos < ending)
			{
				ushort room = ZS.ROM[pos, size: 2];
				pos += 2;

				bool correctRoom = room == RoomID;

				ushort tpos = room; // assign it now to catch that one deleted thing in vanilla

				while (tpos != 0xFFFF)
				{
					tpos = ZS.ROM[pos, size: 2];
					pos += 2;

					if (correctRoom && tpos != 0xFFFF)
					{
						UWTilemapPosition tt = UWTilemapPosition.CreateFromTileMapPosition(tpos);
						TorchList.Add(
							new DungeonTorch()
							{
								X = tt.X,
								Y = tt.Y,
								Layer = tt.Layer,
							}
						);
					}
				}

				if (correctRoom)
				{
					break;
				}
			}
		}


		private void LoadSecrets()
		{
			int secpos = 0x010000 | ZS.ROM[ZS.Offsets.room_items_pointers + (RoomID * 2), 2];
			secpos = secpos.SNEStoPC();

			while (true)
			{
				byte b1 = ZS.ROM[secpos++];
				byte b2 = ZS.ROM[secpos++];

				if ((b1 & b2) == 0xFF) break;

				byte b3 = ZS.ROM[secpos++];

				var p = UWTilemapPosition.CreateFromTileMapPosition(b1, b2);

				SecretsList.Add(
					new DungeonSecret(SecretItemType.FindSecretFromID(b3))
					{
						X = p.X,
						Y = p.Y,
						Layer = p.Layer,
					}
				);

			}
		}

		public DungeonObjectsList GetLayerList(byte layer)
		{
			switch (layer)
			{
				case 1: return Layer1Objects;
				case 2: return Layer2Objects;
				case 3: return Layer3Objects;
			}
			return null;
		}

		public void DrawEntireRoom()
		{
			DrawFloor1();

			for (int i = 0; i < LayoutListing.Length; i++)
			{
				LayoutListing[i].Draw(ZS);
			}

			foreach (var r in Layer1Objects)
			{
				r.Draw(ZS);
			}

			foreach (var r in Layer2Objects)
			{
				r.Draw(ZS);
			}

			foreach (var r in Layer3Objects)
			{
				r.Draw(ZS);
			}

			foreach (var r in DoorsList)
			{
				r.Draw(ZS);
			}

			if (bg2 != Constants.LayerMergeOff)
			{
				ZS.DungeonForm.SetPalettesTransparent();
				DrawFloor2();
			}
			else
			{
				ZS.DungeonForm.SetPalettesBlack();
			}
		}

		private RoomObject ParseRoomObject(byte layer, byte b1, byte b2, byte b3, out byte posX, out byte posY)
		{
			return ParseRoomObject(ZS, layer, b1, b2, b3, out posX, out posY);
		}


		public static RoomObject ParseRoomObject(ZScreamer ZS, byte layer, byte b1, byte b2, byte b3, out byte posX, out byte posY)
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

			if (rtype.Resizeability == DungeonObjectSizeability.None)
			{
				size = 0;
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

		internal void LoadCollisionLayout(bool v)
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
			StairsList.Clear();
			Layer1Objects.Clear();
			Layer2Objects.Clear();
			Layer3Objects.Clear();
			DoorsList.Clear();
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
					DoorsList.Add(ParseDoorObject(b1, b2));
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

			DungeonSprite last = null;

			while (true)
			{
				byte b1 = data[offset++];

				if (b1 == Constants.SpriteTerminator) break;

				byte b2 = data[offset++];
				byte b3 = data[offset++];

				if (b3 == Constants.KeyDropID)
				{
					if (b1 == Constants.BigKeyDropToken)
					{
						last.KeyDrop = 2;
						continue;
					}
					else if (b1 == Constants.SmallKeyDropToken)
					{
						last.KeyDrop = 1;
						continue;
					}
				}

				byte subtype = (byte) ((b2 >> 5) | ((b1 & 0x60) >> 2));
				SpriteType t;

				if (subtype.BitsAllSet(0x07))
				{
					t = OverlordType.GetOverlordType(b3) ?? SpriteType.GetSpriteType(b3);
				}
				else
				{
					t = SpriteType.GetSpriteType(b3);
				}

				last = new DungeonSprite(t, RoomID)
				{
					X = (byte) (b2 & 0x1F),
					Y = (byte) (b1 & 0x1F),
					Layer = (byte) (b1 >> 1),
					Subtype = subtype
				};

				SpritesList.Add(last);
			}
		}

		public void ClearAll()
		{
			Layer1Objects.Clear();
			Layer2Objects.Clear();
			Layer3Objects.Clear();
			DoorsList.Clear();
			SecretsList.Clear();
			SpritesList.Clear();
			ChestList.Clear();
		}


		public void DrawWholeRoom()
		{

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


		private dynamic GetAssociatedList(DungeonPlaceable o)
		{
			if (o is RoomObject ro)
			{
				if (Layer1Objects.Contains(ro))
				{
					return Layer1Objects;
				}
				else if (Layer2Objects.Contains(ro))
				{
					return Layer2Objects;
				}
				else  if (Layer3Objects.Contains(ro))
				{
					return Layer3Objects;
				}
			}
			else if (o is DungeonDoorObject door)
			{
				if (DoorsList.Contains(door))
				{
					return DoorsList;
				}
			}

			return null;
		}

		public void SendToFront(DungeonPlaceable o)
		{
			var mylist = GetAssociatedList(o);

			if (mylist is List<DungeonPlaceable> l)
			{
				l.Remove(o);
				l.Insert(0, o);
				return;
			}
		}

		public void SendToBack(DungeonPlaceable o)
		{
			var mylist = GetAssociatedList(o);

			if (mylist is List<DungeonPlaceable> l)
			{
				l.Remove(o);
				l.Add(o);
				return;
			}
		}

		public void RemoveCurrentlySelectedObjectsFromList<T>(List<T> thisList) where T : DungeonPlaceable
		{
			List<DungeonPlaceable> check = new List<DungeonPlaceable>();
			check.AddRange(SelectedObjects);
			foreach (var o in check)
			{
				if (o is T r)
				{
					thisList.Remove(r);
					SelectedObjects.Remove(o);
				}
			}
		}

		/// <summary>
		/// Returns <see langword="true"/> if too many doors of a certain type.
		/// </summary>
		public bool AutoSortDoors()
		{
			var openabledoors = new List<DungeonDoorObject>();
			var shutterdoors = new List<DungeonDoorObject>();
			var otherdoors = new List<DungeonDoorObject>();


			foreach (DungeonDoorObject door in DoorsList)
			{
				switch (door.DoorType.Category)
				{
					case DoorCategory.Openable:
						openabledoors.Add(door);
						break;

					case DoorCategory.Shutter:
						shutterdoors.Add(door);
						break;

					default:
						otherdoors.Add(door);
						break;
				}
			}

			DoorsList.Clear();
			DoorsList.AddRange(openabledoors);
			DoorsList.AddRange(shutterdoors);
			DoorsList.AddRange(otherdoors);

			return (openabledoors.Count + shutterdoors.Count) > 4;
		}



		public bool[] GetBigChestListing(int count)
		{
			var ret = new bool[count];
			int cur = 0;


			foreach (RoomObject r in Layer1Objects.Concat(Layer2Objects).Concat(Layer3Objects))
			{
				if (r.IsChest)
				{
					ret[cur++] = r.IsBigChest;
					if (cur == count)
					{
						break;
					}
				}
			}

			return ret;
		}


		public void ReassociateChestsAndItems()
		{
			var chests = new List<RoomObject>();

			foreach (var r in Layer1Objects)
			{
				if (r.IsChest)
				{
					chests.Add(r);
				}
			}

			foreach (var r in Layer2Objects)
			{
				if (r.IsChest)
				{
					chests.Add(r);
				}
			}

			foreach (var r in Layer3Objects)
			{
				if (r.IsChest)
				{
					chests.Add(r);
				}
			}

			int i = 0;
			foreach (var c in ChestList)
			{
				c.AssociatedChest = null;
				if (i >= chests.Count) continue;

				c.AssociatedChest = chests[i++];
			}
		}








		// TODO THIS IS AWFUL

		public Rectangle[] getAllDoorPosition()
		{
			Rectangle[] rects = new Rectangle[48];
			int pos;
			float n;

			for (int i = 0, j = 0; i < 12; i++, j += 2) // Left
			{
				pos = ZS.ROM[0x197E + j, 2] / 2;
				n = (((float) pos / 64) - (byte) (pos / 64)) * 64;
				rects[i] = new Rectangle(((byte) n) * 8, (byte) (pos / 64) * 8, 32, 24);

				pos = ZS.ROM[0x1996 + j, 2] / 2;
				n = (((float) pos / 64) - (byte) (pos / 64)) * 64;
				rects[i + 12] = new Rectangle(((byte) n) * 8, (byte) ((pos / 64) + 1) * 8, 32, 24);

				pos = ZS.ROM[0x19AE + j, 2] / 2;
				n = (((float) pos / 64) - (byte) (pos / 64)) * 64;
				rects[i + 24] = new Rectangle(((byte) n) * 8, (byte) (pos / 64) * 8, 24, 32);

				pos = ZS.ROM[0x19C6 + j, 2] / 2;
				n = (((float) pos / 64) - (byte) (pos / 64)) * 64;
				rects[i + 36] = new Rectangle(((byte) n + 1) * 8, (byte) (pos / 64) * 8, 24, 32);
			}

			return rects;
		}
	}
}
