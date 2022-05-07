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
		public List<IDungeonPlaceable> SelectedObjects { get; } = new List<IDungeonPlaceable>();

		/// <summary>
		/// Returns an object if it is the only member of selected objects; otherwise, <see langword="null"/>.
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
			}
		}

		public byte?[] CollisionMap { get; } = new byte?[Constants.TilesPerTilemap];

		private bool moam = false;
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
			get => Layer1Objects.Count == 0 &&
					Layer2Objects.Count == 0 &&
					Layer3Objects.Count == 0 &&
					DoorsList.Count == 0 &&
					ChestList.Count == 0 &&
					SecretsList.Count == 0 &&
					SpritesList.Count == 0 &&
					BlocksList.Count == 0 &&
					TorchList.Count == 0;
		}

		// TODO implement and rename
		public ushort MessageID { get; set; }
		public byte BackgroundTileset { get; set; }
		public byte SpriteTileset { get; set; }
		public LayerCollisionType LayerCollision { get; set; }
		public byte Palette { get; set; }
		public byte Floor1Graphics { get; set; }
		public byte Floor2Graphics { get; set; }
		public LayerEffectType LayerEffect { get; set; }
		public LayerMergeType LayerMerging { get; set; }
		public byte Tag1 { get; set; }
		public byte Tag2 { get; set; }
		public bool IsDark { get; set; }

		public byte PreferredEntrance { get; set; }

		public DungeonDestination Pits { get; } = new DungeonDestination(0);
		public DungeonDestination Stair1 { get; } = new DungeonDestination(1);
		public DungeonDestination Stair2 { get; } = new DungeonDestination(2);
		public DungeonDestination Stair3 { get; } = new DungeonDestination(3);
		public DungeonDestination Stair4 { get; } = new DungeonDestination(4);

		public DungeonDestination[] AllStairs =>
			new DungeonDestination[] { Stair1, Stair2, Stair3, Stair4 };

		public bool HasDamagingPits { get; set; }

		private readonly ZScreamer ZS;
		private DungeonRoom(ZScreamer zs, ushort id)
		{
			RoomID = id;
			ZS = zs;
			Name = DefaultEntities.ListOfRoomNames[id].Name;
			ChestList = new DungeonRoomChestsHandler(this);
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

			int hpos = ((ZS.ROM[ZS.Offsets.room_header_pointers_bank] << 16) | ZS.ROM.Read16(headerPointer + (RoomID * 2))).SNEStoPC();
			byte b = ZS.ROM[hpos++];
			// TODO verify merge versus behavor

			LayerMerging = LayerMergeType.ListOf[b >> 5];
			LayerCollision = LayerCollisionType.ListOf[(b & 0x0C) >> 2];
			IsDark = (b & 0x01) == 0x01;
			Palette = ZS.ROM[hpos++];
			BackgroundTileset = ZS.ROM[hpos++];
			SpriteTileset = ZS.ROM[hpos++];
			//LayerMerging = LayerMergeType.ListOf[ZS.ROM[hpos++]];
			LayerEffect = LayerEffectType.ListOf[ZS.ROM[hpos++]];
			Tag1 = ZS.ROM[hpos++];
			Tag2 = ZS.ROM[hpos++];

			b = ZS.ROM[hpos++];

			Pits.TargetLayer = (byte) (b & 0x03);
			Stair1.TargetLayer = (byte) ((b >> 2) & 0x03);
			Stair2.TargetLayer = (byte) ((b >> 4) & 0x03);
			Stair3.TargetLayer = (byte) ((b >> 6) & 0x03);
			Stair4.TargetLayer = (byte) (ZS.ROM[hpos++] & 0x03);
			
			Pits.Target = ZS.ROM[hpos++];
			Stair1.Target = ZS.ROM[hpos++];
			Stair2.Target = ZS.ROM[hpos++];
			Stair3.Target = ZS.ROM[hpos++];
			Stair4.Target = ZS.ROM[hpos++];

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
			ResyncAllLists();
		}



		// TODO this is where we'll flush temporary edits to the new listing
		/// <summary>
		/// Flushes all pending changes to the keep buffer.
		/// </summary>
		public void FlushChanges()
		{
			if (!HasUnsavedChanges)
			{
				return;
			}

			HasUnsavedChanges = false;
			throw new NotImplementedException();
		}

		/// <summary>
		/// Deletes all pending changes and restores the edit buffer from the keep buffer.
		/// </summary>
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
					ChestList.Add(new DungeonChestItem(ItemReceipt.GetTypeFromID(item)));
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

				while (tpos != Constants.ObjectSentinel)
				{
					tpos = ZS.ROM.Read16(pos);
					pos += 2;

					if (correctRoom && tpos != Constants.ObjectSentinel)
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
					new DungeonSecret(SecretItemType.GetTypeFromID(b3))
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

		private RoomObject ParseRoomObject(byte b1, byte b2, byte b3)
		{
			return ParseRoomObject(ZS, b1, b2, b3);
		}


		public static RoomObject ParseRoomObject(ZScreamer ZS, byte b1, byte b2, byte b3)
		{
			byte size, posX, posY;
			ushort oid;

			if (b1 >= 0xFC) // Subtype 2
			{
				oid = (ushort) ((b3 & 0x3F) | 0x100);
				posX = (byte) ((b2 >> 4) | ((b1 & 0x03) << 4));
				posY = (byte) (((b2 & 0x0F) << 2) | (b3 >> 6));
				size = 0;
			}
			else if (b3 >= 0xF8) // Subtype 3
			{
				oid = (ushort) (0x0200 | ((b3 & 0x07) << 4) | ((b2 & 0x03) << 2) | (b1 & 0x03));
				posX = (byte) (b1 >> 2);
				posY = (byte) (b2 >> 2);
				size = 0;
			}
			else // Subtype1
			{
				oid = b3;
				posX = (byte) (b1 >> 2);
				posY = (byte) (b2 >> 2);
				size = (byte) (((b1 & 0x03) << 2) | (b2 & 0x03));
			}

			RoomObjectType rtype = RoomObjectType.GetTypeFromID(oid);
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
			Pits.Reset();
			Stair1.Reset();
			Stair2.Reset();
			Stair3.Reset();
			Stair4.Reset();
			ChestList.ResetAssociations();
			Layer1Objects.Clear();
			Layer2Objects.Clear();
			Layer3Objects.Clear();
			DoorsList.Clear();

			DungeonObjectsList currentList = Layer1Objects;
			Floor1Graphics = (byte) (data[offset] & 0x0F);
			Floor2Graphics = (byte) (data[offset++] >> 4);
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
						layer++;
						door = false;
						switch (layer)
						{
							case 0:
								currentList = Layer1Objects;
								break;
							
							case 1:
								currentList = Layer2Objects;
								break;
							
							case 2:
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

		private void LoadSpritesFromArray(byte[] data, int offset = 0)
		{
			MultiLayerOAM = data[offset++] == 1;

			DungeonSprite last = null;

			while (true)
			{
				byte b1 = data[offset++];

				if (b1 == Constants.SpriteSentinel) break;

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
					t = OverlordType.GetTypeFromID(b3) ?? SpriteType.GetTypeFromID(b3);
				}
				else
				{
					t = SpriteType.GetTypeFromID(b3);
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
			TorchList.Clear();
			BlocksList.Clear();
			ChestList.Clear();
			ResyncAllLists();
		}

		public bool AttemptToAddEntityAsSelected(IDungeonPlaceable o, DungeonEditMode m)
		{
			if (AttemptToAddEntity(o, m))
			{
				OnlySelectedObject = o;
				ResyncAllLists();
				return true;
			}

			return false;
		}


		private bool AttemptToAddEntity(IDungeonPlaceable o, DungeonEditMode m)
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

		private IDungeonPlaceable FindRelevantEntityUnderMouseForMode(DungeonEditMode em, int x, int y)
		{
			var l = FindRelevantListForMode(em);
			if (l == null) return null;

			return FindEntityUnderMouseInList(l, x, y);
		}


		private IList<IDungeonPlaceable> FindRelevantListForMode(DungeonEditMode em)
		{
			switch (em)
			{
				case DungeonEditMode.Layer1: return (IList<IDungeonPlaceable>) Layer1Objects;
				case DungeonEditMode.Layer2: return (IList<IDungeonPlaceable>) Layer2Objects;
				case DungeonEditMode.Layer3: return (IList<IDungeonPlaceable>) Layer3Objects;
				case DungeonEditMode.LayerAll: return (IList<IDungeonPlaceable>) Layer1Objects.Concat(Layer2Objects).Concat(Layer3Objects);
				case DungeonEditMode.Sprites: return (IList<IDungeonPlaceable>) SpritesList;
				case DungeonEditMode.Secrets: return (IList<IDungeonPlaceable>) SecretsList;
				case DungeonEditMode.Blocks: return (IList<IDungeonPlaceable>) BlocksList;
				case DungeonEditMode.Torches: return (IList<IDungeonPlaceable>) TorchList;
				case DungeonEditMode.Doors: return (IList<IDungeonPlaceable>) DoorsList;
				default: return null;
			}
		}


		private IDungeonPlaceable FindEntityUnderMouseInList(IList<IDungeonPlaceable> l, int x, int y)
		{
			for (int i = l.Count - 1; i >= 0; i--) // count down because the objects on top are the most visible
			{
				var o = l[i];
				if (o.PointIsInHitbox(x, y))
				{
					return o;
				}
			}
			return null;
		}

		private void ResyncAllLists()
		{
			ReassociateChestsAndItems();
			ReassociateStairsAndTargets();
		}



		// TODO finish listing
		private IList<IDungeonPlaceable> GetAssociatedList(IDungeonPlaceable o)
		{
			if (o is RoomObject ro)
			{
				if (Layer1Objects.Contains(ro))
				{
					return (IList<IDungeonPlaceable>) Layer1Objects;
				}
				else if (Layer2Objects.Contains(ro))
				{
					return (IList<IDungeonPlaceable>) Layer2Objects;
				}
				else if (Layer3Objects.Contains(ro))
				{
					return (IList<IDungeonPlaceable>) Layer3Objects;
				}
			}
			else if (o is DungeonDoor door)
			{
				if (DoorsList.Contains(door))
				{
					return (IList<IDungeonPlaceable>) DoorsList;
				}
			}

			return null;
		}

		private void SendOneToFront(IDungeonPlaceable o)
		{
			var mylist = GetAssociatedList(o);
			mylist?.Remove(o);
			mylist?.Add(o);
		}

		public void SendToFront(IDungeonPlaceable o)
		{
			SendOneToFront(o);
			ResyncAllLists();
		}

		private void SendOneToBack(IDungeonPlaceable o)
		{
			var mylist = GetAssociatedList(o);
			mylist?.Remove(o);
			mylist?.Insert(0, o);
		}

		public void SendToBack(IDungeonPlaceable o)
		{
			SendOneToBack(o);
			ResyncAllLists();
		}

		public void SendAllSelectedToFront()
		{
			foreach (var o in SelectedObjects)
			{
				SendOneToFront(o);
			}
			ResyncAllLists();
		}

		public void SendAllSelectedToBack()
		{
			foreach (var o in SelectedObjects)
			{
				SendOneToBack(o);
			}
			ResyncAllLists();
		}

		private void SendOneToLayer(IMultilayered o, RoomLayer layer)
		{
			if (o.Layer == layer)
			{
				return;
			}

			if (o is RoomObject r)
			{
				var d = GetLayerList(o.Layer);
				d.Remove(r);

				var l = GetLayerList(layer);
				l.Add(r);
			}

			o.Layer = layer;
		}

		internal void SendAllSelectedToLayer(RoomLayer layer)
		{
			foreach (IDungeonPlaceable o in SelectedObjects)
			{
				if (o is IMultilayered m)
				{
					SendOneToLayer(m, layer);
				}
			}
			ResyncAllLists();
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
			ResyncAllLists();
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

			ResyncAllLists();

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
		public void AddChest()
		{


			ReassociateChestsAndItems();
		}
		
		// TODO
		public void DeleteChest()
		{


			ReassociateChestsAndItems();
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

		private List<RoomObject> FindAllObjects(Predicate<RoomObject> test)
		{
			return (List<RoomObject>) (Layer1Objects.FindAll(test).Concat(Layer2Objects.FindAll(test)).Concat(Layer3Objects.FindAll(test)));
		}
		private void ReassociateChestsAndItems()
		{
			var chests = FindAllObjects(o => o.IsChest);

			int i = 0;
			foreach (var c in ChestList)
			{
				c.AssociatedChest = null;
				if (i >= chests.Count) continue;

				c.AssociatedChest = chests[i++];
			}
		}

		private void ReassociateStairsAndTargets()
		{
			var stairs = FindAllObjects(o => o.IsStairs);

			int count = stairs.Count();

			Stair1.AssociatedObject = count > 0 ? stairs[0] : null;
			Stair2.AssociatedObject = count > 1 ? stairs[1] : null;
			Stair3.AssociatedObject = count > 2 ? stairs[2] : null;
			Stair4.AssociatedObject = count > 3 ? stairs[3] : null;
		}


		public void ClearSelectedList()
		{
			SelectedObjects.Clear();
		}

		//================================================================================================
		// Data output
		//================================================================================================
		public byte[] GetHeaderData()
		{
			return new byte[]
			{
				(byte) ((LayerEffect.ID << 5) | (LayerCollision.ID << 2) | (IsDark ? 1 : 0)),
				Palette,
				BackgroundTileset,
				SpriteTileset,
				LayerMerging.ID,
				Tag1,
				Tag2,
				(byte) (Pits.TargetLayer | (Stair1.TargetLayer << 2)
					| (Stair2.TargetLayer << 4) | (Stair3.TargetLayer << 6)),
				Stair4.TargetLayer,
				Pits.Target,
				Stair1.Target,
				Stair2.Target,
				Stair3.Target,
				Stair4.Target
			};
		}

		public byte[] GetTorchesData()
		{
			var ret = new List<byte>();

			ret.Add(RoomID);

			ret.AddRange(TorchList.GetByteData());

			ret.Add(Constants.ObjectSentinel);

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
				ret.Add(Constants.ObjectSentinel);
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
