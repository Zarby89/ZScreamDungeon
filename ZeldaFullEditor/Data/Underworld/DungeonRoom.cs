using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor.Data.Underworld
{
	public class DungeonRoom
	{
		public ushort RoomID { get; }

		private readonly byte[] blocks = new byte[16];

		public string Name { get; set; }

		public DungeonObjectsList Layer1Objects { get; } = new DungeonObjectsList();
		public DungeonObjectsList Layer2Objects { get; } = new DungeonObjectsList();
		public DungeonObjectsList Layer3Objects { get; } = new DungeonObjectsList();

		public DungeonObjectsList[] AllObjects =>
			new DungeonObjectsList[] { Layer1Objects, Layer2Objects, Layer3Objects };

		public DungeonDoorsList DoorsList { get; } = new DungeonDoorsList();
		public DungeonRoomChestsHandler ChestList { get; }
		public DungeonSecretsList SecretsList { get; } = new DungeonSecretsList();
		public DungeonSpritesList SpritesList { get; } = new DungeonSpritesList();
		public DungeonBlocksList BlocksList { get; } = new DungeonBlocksList();
		public DungeonTorchList TorchList { get; } = new DungeonTorchList();

		public DungeonDestinationsHandler Destinations { get; } = new DungeonDestinationsHandler();
		public List<IDungeonPlaceable> SelectedObjects { get; } = new List<IDungeonPlaceable>();

		/// <summary>
		/// Returns an object if it is the only member of selected objects; otherwise, null
		/// </summary>
		public IDungeonPlaceable OnlySelectedObject
		{
			get
			{
				if (SelectedObjects.Count == 1)
				{
					return SelectedObjects[0];
				}
				return null;
			}

			private set
			{
				SelectedObjects.Clear();
				SelectedObjects.Add(value);
			}
		}

		public bool HasUnsavedChanges { get; internal set; }

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
		public ImmutableArray<RoomObject> LayoutListing { get; private set; }

		private bool moam = false;

		public byte?[] CollisionMap { get; } = new byte?[Constants.TilesPerTilemap];

		public bool MultiLayerOAM
		{
			get => moam;
			set
			{
				moam = value;
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
		public byte BackgroundTileset { get; set; }
		public byte SpriteTileset { get; set; }
		public byte Layer2Behavior { get; set; }
		public byte Palette { get; set; }
		public byte Floor1Graphics { get; set; }
		public byte Floor2Graphics { get; set; }
		public byte Layer2Mode { get; set; }
		public LayerMergeType LayerMerging { get; set; }
		public byte Tag1 { get; set; }
		public byte Tag2 { get; set; }
		public bool IsDark { get; set; }
		public DungeonDestination Pits => Destinations.Pits;
		public DungeonDestination Stair1 => Destinations.Stair1;
		public DungeonDestination Stair2 => Destinations.Stair2;
		public DungeonDestination Stair3 => Destinations.Stair3;
		public DungeonDestination Stair4 => Destinations.Stair4;

		public DungeonDestination[] AllStairs =>
			new DungeonDestination[] { Stair1, Stair2, Stair3, Stair4 };

		public bool HasDamagingPits { get; set; }

		private readonly ZScreamer ZS;
		private DungeonRoom(ZScreamer zs, ushort id)
		{
			RoomID = id;
			ZS = zs;
		}

		public void reloadGfx(byte entrance_blockset = 0xFF)
		{
			for (int i = 0; i < 8; i++)
			{
				blocks[i] = ZS.GFXGroups.mainGfx[BackgroundTileset][i];
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
				blocks[12 + i] = (byte) (ZS.GFXGroups.spriteGfx[SpriteTileset + 64][i] + 115);
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

		private unsafe void reloadAnimatedGfx()
		{
			int gfxanimatedPointer = ZS.ROM.Read24(ZS.Offsets.gfx_animated_pointer).SNEStoPC();

			byte* newPdata = (byte*) ZS.GFXManager.allgfx16Ptr.ToPointer(); // Turn gfx16 (all 222 of them)
			byte* sheetsData = (byte*) ZS.GFXManager.currentgfx16Ptr.ToPointer(); // Into "room gfx16" 16 of them

			int data = 0;
			while (data < 512)
			{
				byte mapByte = newPdata[data + (92 * 2048) + (512 * ZS.GFXManager.animated_frame)];
				sheetsData[data + (7 * 2048)] = mapByte;

				mapByte = newPdata[data + (ZS.ROM[gfxanimatedPointer + BackgroundTileset] * 2048) + (512 * ZS.GFXManager.animated_frame)];
				sheetsData[data + (7 * 2048) - 512] = mapByte;
				data++;
			}
		}


		public static DungeonRoom BuildRoomFromROM(ZScreamer Z, ushort id)
		{
			DungeonRoom ret = new DungeonRoom(Z, id);
			ret.ReloadRoomFromROM();
			return ret;
		}

		private void ReloadRoomFromROM() {
			// Load dungeon header
			int headerPointer = ZS.ROM.Read24(ZS.Offsets.room_header_pointer).SNEStoPC();

			MessageID = ZS.ROM.Read16(ZS.Offsets.messages_id_dungeon + (RoomID * 2));

			int hpos = (ZS.ROM[ZS.Offsets.room_header_pointers_bank] << 16) | ZS.ROM.Read16(headerPointer + (RoomID * 2));
			byte b = ZS.ROM[hpos++];
			Layer2Mode = (byte) (b >> 5);
			Layer2Behavior = (byte) ((b & 0x0C) >> 2);
			IsDark = (b & 0x01) == 0x01;
			Palette = ZS.ROM[hpos++];
			BackgroundTileset = ZS.ROM[hpos++];
			SpriteTileset = ZS.ROM[hpos++];
			LayerMerging = LayerMergeType.ListOf[ZS.ROM[hpos++]];
			Tag1 = ZS.ROM[hpos++];
			Tag2 = ZS.ROM[hpos++];

			b = ZS.ROM[hpos++];

			Destinations.Pits.Layer = (byte) (b & 0x03);
			Destinations.Stair1.Layer = (byte) ((b >> 2) & 0x03);
			Destinations.Stair2.Layer = (byte) ((b >> 4) & 0x03);
			Destinations.Stair3.Layer = (byte) ((b >> 6) & 0x03);
			Destinations.Stair4.Layer = (byte) (ZS.ROM[hpos++] & 0x03);
			
			Destinations.Pits.Target = ZS.ROM[hpos++];
			Destinations.Stair1.Target = ZS.ROM[hpos++];
			Destinations.Stair2.Target = ZS.ROM[hpos++];
			Destinations.Stair3.Target = ZS.ROM[hpos++];
			Destinations.Stair4.Target = ZS.ROM[hpos++];

			// Load room objects
			int objectPointer = ZS.ROM.Read24(ZS.Offsets.room_object_pointer).SNEStoPC();
			int room_address = objectPointer + (RoomID * 3);

			int objects_location = ZS.ROM.Read24(room_address).SNEStoPC();

			LoadObjectsFromArray(ZS.ROM.DataStream, offset: objects_location);


			// Load sprites
			int spritePointer = 0x040000 | ZS.ROM.Read16(ZS.Offsets.rooms_sprite_pointer);
			int sprite_address = (Constants.DungeonSpritePointers | ZS.ROM.Read16(spritePointer + (RoomID * 2))).SNEStoPC();
			LoadSpritesFromArray(ZS.ROM.DataStream, offset: sprite_address);

			// Load other stuff
			LoadChests();
			LoadBlocks();
			LoadTorches();
			LoadSecrets();
			ReassociateChestsAndItems();
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

		public void ClearChanges()
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

			int cpos = ZS.ROM.Read24(ZS.Offsets.chests_data_pointer1).SNEStoPC();
			int clength = ZS.ROM.Read16(ZS.Offsets.chests_length_pointer);

			for (int i = 0; i < clength; i += 3)
			{
				ushort roomid = (ushort) (ZS.ROM.Read16(cpos) & 0x7FFF);
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
			int blockCount = ZS.ROM.Read16(ZS.Offsets.blocks_length);

			int pos1 = ZS.ROM.Read24(ZS.Offsets.blocks_pointer1).SNEStoPC();
			int pos2 = ZS.ROM.Read24(ZS.Offsets.blocks_pointer2).SNEStoPC();
			int pos3 = ZS.ROM.Read24(ZS.Offsets.blocks_pointer3).SNEStoPC();
			int pos4 = ZS.ROM.Read24(ZS.Offsets.blocks_pointer4).SNEStoPC();

			for (int j = 0, i = 0; j < blockCount; j += 4, i++)
			{
				ushort room = (ushort) (ZS.ROM[pos1 + i] | (ZS.ROM[pos2 + i] << 8));

				if (room != RoomID) continue;

				UWTilemapPosition.CreateXYZFromTileMap(ZS.ROM[pos3 + i], (byte) (ZS.ROM[pos4 + i] & 0x3F),
					out byte x, out byte y, out byte layer);
				BlocksList.Add(
					new DungeonBlock()
					{
						GridX = x,
						GridY = y,
						Layer = (RoomLayer) layer,
					}
				);
			}
		}

		private void LoadTorches()
		{
			int torchesSize = ZS.ROM.Read16(ZS.Offsets.torches_length_pointer);
			int pos = ZS.Offsets.torch_data;
			int ending = pos + torchesSize;

			while (pos < ending)
			{
				ushort room = ZS.ROM.Read16(pos);
				pos += 2;

				bool correctRoom = room == RoomID;

				ushort tpos = room; // assign it now to catch that one deleted thing in vanilla

				while (tpos != 0xFFFF)
				{
					tpos = ZS.ROM.Read16(pos);
					pos += 2;

					if (correctRoom && tpos != 0xFFFF)
					{
						UWTilemapPosition.CreateXYZFromTileMap(tpos, out byte x, out byte y, out byte layer);
						TorchList.Add(
							new DungeonTorch()
							{
								GridX = x,
								GridY = y,
								Layer = (RoomLayer) layer,
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
			int secpos = 0x010000 | ZS.ROM.Read16(ZS.Offsets.room_items_pointers + (RoomID * 2));
			secpos = secpos.SNEStoPC();

			while (true)
			{
				byte b1 = ZS.ROM[secpos++];
				byte b2 = ZS.ROM[secpos++];

				if ((b1 & b2) == 0xFF) break;

				byte b3 = ZS.ROM[secpos++];

				UWTilemapPosition.CreateXYZFromTileMap(b1, b2, out byte x, out byte y, out byte layer);

				SecretsList.Add(
					new DungeonSecret(SecretItemType.FindSecretFromID(b3))
					{
						GridX = x,
						GridY = y,
						Layer = (RoomLayer) layer,
					}
				);

			}
		}

		public DungeonObjectsList GetLayerList(RoomLayer layer)
		{
			switch (layer)
			{
				case RoomLayer.Layer1: return Layer1Objects;
				case RoomLayer.Layer2: return Layer2Objects;
				case RoomLayer.Layer3: return Layer3Objects;
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

			if (Layer2Mode != Constants.LayerMergeOff)
			{
				Program.DungeonForm.SetPalettesTransparent();
				DrawFloor2();
			}
			else
			{
				Program.DungeonForm.SetPalettesBlack();
			}
		}

		private RoomObject ParseRoomObject(byte b1, byte b2, byte b3)
		{
			return ParseRoomObject(ZS, b1, b2, b3);
		}


		public static RoomObject ParseRoomObject(ZScreamer ZS, byte b1, byte b2, byte b3)
		{
			byte size, posX, posY;
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
					GridX = posX,
					GridY = posY,
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

		private DungeonDoor ParseDoorObject(byte b1, byte b2)
		{
			return new DungeonDoor(
					DungeonDoorDraw.GetDirectionFromToken(b1),
					ZS.TileLister.GetDoorTileSet(b2)
				);
		}


		public void LoadObjectsFromArray(byte[] data, int offset = 0)
		{
			// Load chest items
			Destinations.Clear();
			ChestList.ResetAssociations();
			Layer1Objects.Clear();
			Layer2Objects.Clear();
			Layer3Objects.Clear();
			DoorsList.Clear();

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
					RoomObject r = ParseRoomObject(b1, b2, b3);

					if (r != null)
					{
						r.Layer = (RoomLayer) layer;
						currentList.Add(r);
					}
					else
					{
						throw new Exception("Shit that's a bad room object.");
					}
				}

			}
		}

		public RoomObject AddObject(ushort id, byte x, byte y, byte size, byte layer)
		{
			return
				new RoomObject(RoomObjectType.GetDungeonObject(id), ZS.TileLister[id])
				{
					GridX = x,
					GridY = y,
					Size = size,
					Layer = (RoomLayer) layer
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

				last = new DungeonSprite(t)
				{
					RoomID = RoomID,
					GridX = (byte) (b2 & 0x1F),
					GridY = (byte) (b1 & 0x1F),
					Layer = (RoomLayer) (b1 >> 7),
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

		public bool AttemptToAddEntityAsSelected(IDungeonPlaceable o, DungeonEditMode m)
		{
			if (AttemptToAddEntity(o, m))
			{
				OnlySelectedObject = o;
				return true;
			}

			return false;
		}


		public bool AttemptToAddEntity(IDungeonPlaceable o, DungeonEditMode m)
		{

			switch (m)
			{
				case DungeonEditMode.Layer1:
				case DungeonEditMode.Layer2:
				case DungeonEditMode.Layer3:
					var l = GetLayerList((RoomLayer) m);
					if (l == null) return false;
					if (!(o is RoomObject ro)) return false;

					return AddRoomObject(ro, l);

				case DungeonEditMode.Doors:
					if (!(o is DungeonDoor dr)) return false;
					return AddDoor(dr);

				case DungeonEditMode.Sprites:
					if (!(o is DungeonSprite so)) return false;
					return AddSprite(so);

				case DungeonEditMode.Blocks:
					if (!(o is DungeonBlock bo)) return false;
					return AddBlock(bo);

				case DungeonEditMode.Torches:
					if (!(o is DungeonTorch to)) return false;
					return AddTorch(to);

				default:
					return false;
			}
		}

		// TODO logic for too many of certain things
		private bool AddRoomObject(RoomObject o, DungeonObjectsList l)
		{
			var lim = o.LimitClass;

			// TODO 
			if (lim == DungeonLimits.GeneralManipulable || lim == DungeonLimits.GeneralManipulable4x)
			{
				ValidateManipulables();
			}
			else if (lim != DungeonLimits.None)
			{
				int count = CountLimitedObjects(lim);
				// TODO fill in limits
				// TODO maybe move elsewhere
				switch (lim)
				{
					case DungeonLimits.StarTiles:
						if (count > 16)
						{
							throw new ZeldaException("Too many star tiles!!!");
						}
						break;

				}
			}


			l.Add(o);

			HasUnsavedChanges = true;
			return true;
		}

		private bool AddSprite(DungeonSprite s)
		{
			int sprites = 0;
			int overlords = 0;

			foreach (var k in SpritesList)
			{
				if (k.IsCurrentlyOverlord)
				{
					overlords++;
				}
				else
				{
					sprites++;
				}
			}

			if (overlords > 7)
			{
				throw new ZeldaException("There are too many overlords. Only 8 may be placed in a single room.");
			}

			if (sprites > 16)
			{
				throw new ZeldaException("There are too many non-overlord sprites. Only 16 may be placed in a single room.");
			}

			SpritesList.Add(s);

			HasUnsavedChanges = true;
			return true;
		}
		
		private int CountLimitedObjects(DungeonLimits type)
		{
			int count = 0;

			foreach (var l in AllObjects)
			{
				foreach (var o in l)
				{
					if (o.LimitClass == type)
					{
						count++;
					}
				}
			}

			return count;
		}

		private int CountManipulables()
		{
			int count = BlocksList.Count;

			foreach (var l in AllObjects)
			{
				foreach (var o in l)
				{
					if (o.LimitClass == DungeonLimits.GeneralManipulable)
					{
						count += o.Size + 1;
					}
					else if (o.LimitClass == DungeonLimits.GeneralManipulable4x)
					{
						count += 4;
					}
				}
			}

			return count;
		}

		private void ValidateManipulables()
		{
			if (CountManipulables() > 16)
			{
				throw new ZeldaException("Too many manipulable objects!");
			}
		}


		private bool AddBlock(DungeonBlock b)
		{
			ValidateManipulables();

			BlocksList.Add(b);

			HasUnsavedChanges = true;
			return true;
		}	

		private bool AddDoor(DungeonDoor d)
		{
			DoorsList.Add(d);

			HasUnsavedChanges = true;
			return true;
		}
		
		// TODO
		private bool AddTorch(DungeonTorch t)
		{
			if (TorchList.Count >= 16)
			{
				throw new ZeldaException("You cannot place more than 16 torches in a room.");
			}

			TorchList.Add(t);

			HasUnsavedChanges = true;
			return true;
		}



		private dynamic GetAssociatedList(IDungeonPlaceable o)
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
				else if (Layer3Objects.Contains(ro))
				{
					return Layer3Objects;
				}
			}
			else if (o is DungeonDoor door)
			{
				if (DoorsList.Contains(door))
				{
					return DoorsList;
				}
			}

			return null;
		}

		public void SendToFront(IDungeonPlaceable o)
		{
			var mylist = GetAssociatedList(o);

			if (mylist is List<IDungeonPlaceable> l)
			{
				l.Remove(o);
				l.Insert(0, o);
				return;
			}
		}

		public void SendAllSelectedToFront()
		{
			foreach (var o in SelectedObjects)
			{
				SendToFront(o);
			}
		}

		public void SendAllSelectedToBack()
		{
			foreach (var o in SelectedObjects)
			{
				SendToBack(o);
			}
		}

		public void SendToBack(IDungeonPlaceable o)
		{
			var mylist = GetAssociatedList(o);

			if (mylist is List<IDungeonPlaceable> l)
			{
				l.Remove(o);
				l.Add(o);
				return;
			}
		}

		internal void SendAllSelectedToLayer(RoomLayer layer)
		{
			foreach (IDungeonPlaceable o in SelectedObjects)
			{
				if (o is IMultilayered m)
				{
					if (m.Layer == layer)
					{
						continue;
					}

					if (m is RoomObject r)
					{
						var d = GetLayerList(m.Layer);
						d.Remove(r);

						var l = GetLayerList(layer);
						l.Add(r);
					}

					m.Layer = layer;
				}
			}
		}
		public object FindFirstCollidingObject<T>(IEnumerable<T> list, int x, int y) where T : IMouseCollidable
		{
			foreach (var o in list)
			{
				if (o.PointIsInHitbox(x, y))
				{
					return o;
				}
			}

			return null;
		}

		public void RemoveCurrentlySelectedObjectsFromList<T>(List<T> thisList) where T : IDungeonPlaceable
		{
			List<IDungeonPlaceable> check = new List<IDungeonPlaceable>();
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
			var openabledoors = new List<DungeonDoor>();
			var shutterdoors = new List<DungeonDoor>();
			var otherdoors = new List<DungeonDoor>();


			foreach (DungeonDoor door in DoorsList)
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


		// @author: scawful
		private List<CollisionRectangle> LoadCollisionLayout()
		{
			var ret = new List<CollisionRectangle>();
			var freespace = new bool[CollisionMap.Length];

			for (ushort i = 0; i < CollisionMap.Length; i++)
			{
				byte? check = CollisionMap[i];

				if (check == null || !freespace[i])
				{
					continue;
				}

				if (CollisionMap[i+1] == null && CollisionMap[i+64] == null)
				{
					freespace[i] = true;
					ret.Add(new CollisionRectangle(1, 1, i, (byte) check));
					continue;
				}

				int rectumw = 1;
				int rectumh = 64;

				while (CollisionMap[i + rectumw] != null)
				{
					rectumw++;
				}

				while  (((i + rectumh) < Constants.TilesPerTilemap)
						&& CollisionMap[i + rectumh] != null)
				{
					rectumh += 64;
				}

				var rectumadd = new List<byte>();
				for (int y = 0; y < rectumh; y += 64)
				{
					for (int x = 0; x < rectumw; x++)
					{
						rectumadd.Add((byte) CollisionMap[i + x + y]);
					}
				}

				ret.Add(new CollisionRectangle((byte) rectumw, (byte) (rectumh / 64), i, rectumadd.ToArray()));
			}

			return ret;
		}

		// TODO
		public bool AddChest()
		{


			ReassociateChestsAndItems();

			return true;
		}
		
		// TODO
		public bool DeleteChest()
		{


			ReassociateChestsAndItems();

			return true;
		}



		public bool[] GetBigChestListing(int count)
		{
			var ret = new bool[count];
			int cur = 0;

			foreach (var l in AllObjects)
			{
				foreach (var r in l)
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

		public void ReassociateStairsAndTargets()
		{
			var stairs = new List<RoomObject>();

			foreach (var r in Layer1Objects)
			{
				if (r.IsStairs)
				{
					stairs.Add(r);
				}
			}

			foreach (var r in Layer2Objects)
			{
				if (r.IsStairs)
				{
					stairs.Add(r);
				}
			}

			foreach (var r in Layer3Objects)
			{
				if (r.IsStairs)
				{
					stairs.Add(r);
				}
			}

			int count = stairs.Count();

			if (count > 0)
			{
				Destinations.Stair1.AssociatedObject = stairs[0];
			}

			if (count > 1)
			{
				Destinations.Stair1.AssociatedObject = stairs[1];
			}

			if (count > 2)
			{
				Destinations.Stair1.AssociatedObject = stairs[2];
			}

			if (count > 3)
			{
				Destinations.Stair1.AssociatedObject = stairs[3];
			}
		}


		public void ClearSelectedList()
		{
			SelectedObjects.Clear();
		}

		//================================================================================================
		// Data output
		//================================================================================================

		// TODO
		public byte[] GetHeaderData()
		{
			return new byte[]
			{
				(byte) ((Layer2Mode << 5) | (Layer2Behavior << 2) | (IsDark ? 1 : 0)),
				Palette,
				BackgroundTileset,
				SpriteTileset,
				LayerMerging.ID,
				Tag1,
				Tag2,
				(byte) (Destinations.Pits.Layer | (Destinations.Stair1.Layer << 2)
					| (Destinations.Stair2.Layer << 4) | (Destinations.Stair3.Layer << 6)),
				Destinations.Stair4.Layer,
				Destinations.Pits.Target,
				Destinations.Stair1.Target,
				Destinations.Stair2.Target,
				Destinations.Stair3.Target,
				Destinations.Stair4.Target
			};
		}

		public byte[] GetTileObjectData()
		{
			// TODO add layout and shit
			var ret = new List<byte>();

			ret.Add(0x00); // TODO write floor
			ret.Add(0x00); // TODO write layout

			ret.AddRange(Layer1Objects.GetByteData());
			ret.Add(0xFFFF);

			ret.AddRange(Layer2Objects.GetByteData());
			ret.Add(0xFFFF);

			ret.AddRange(Layer3Objects.GetByteData());

			if (DoorsList.Count > 0)
			{
				ret.Add(0xFFF0);

				ret.AddRange(DoorsList.GetByteData());
			}

			ret.Add(0xFFFF);

			return ret.ToArray();
		}

		public byte[] GetTorchesData()
		{
			var ret = new List<byte>();

			ret.Add(RoomID);

			ret.AddRange(TorchList.GetByteData());

			ret.Add(0xFFFF);

			return ret.ToArray();
		}

		public bool CheckForNonemptyCollision()
		{
			foreach (byte? b in CollisionMap)
			{
				if (b != null)
				{
					return true;
				}
			}
			return false;
		}

		public byte[] GetCollisionData()
		{
			var ret = new List<byte>();
			var red = LoadCollisionLayout();

			foreach (var rectum in red)
			{
				ret.Add(rectum.Position);
				ret.Add(rectum.Width);
				ret.Add(rectum.Height);
				ret.AddRange(rectum.TileData);
			}

			if (ret.Count() > 0)
			{
				ret.Add(0xFFFF);
			}

			return ret.ToArray();
		}

		public void ClearCustomCollision()
		{
			for(int i = 0; i < CollisionMap.Length; i++)
			{
				CollisionMap[i] = null;
			}
			HasUnsavedChanges = true;
		}
	}
}
