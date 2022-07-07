namespace ZeldaFullEditor.ALTTP.Underworld
{
	public class Room
	{
		private const ushort CollisionSinglesMarker = 0xF0F0;


		public ushort RoomID { get; }

		public string Name { get; set; }

		public DungeonObjectsList Layer1Objects { get; } = new();
		public DungeonObjectsList Layer2Objects { get; } = new();
		public DungeonObjectsList Layer3Objects { get; } = new();

		public DungeonObjectsList[] AllObjects => new[] { Layer1Objects, Layer2Objects, Layer3Objects };

		public DungeonDoorsList DoorsList { get; } = new();
		public ChestItemsHandler ChestList { get; }
		public DungeonSecretsList SecretsList { get; } = new();
		public DungeonSpritesList SpritesList { get; } = new();
		public DungeonBlocksList BlocksList { get; } = new();
		public DungeonTorchList TorchList { get; } = new();
		public List<IDungeonPlaceable> SelectedObjects { get; } = new();

		public FullPalette CGPalette { get; private set; }

		public GraphicsSet LoadedGraphics { get; private set; } = new GraphicsSet();

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

			internal set
			{
				SelectedObjects.Clear();
				SelectedObjects.Add(value);
			}
		}

		public bool HasUnsavedChanges { get; internal set; }

		public NeedsNewArt Redrawing { get; internal set; }


		private byte layout;
		public byte Layout
		{
			get => layout;
			set
			{
				value &= 0x07;
				if (layout == value) return;

				layout = value;
				Redrawing |= NeedsNewArt.UpdatedLayer1Tilemap;
			}
		}

		public byte?[] CollisionMap { get; private set; } = new byte?[Constants.TilesPerTilemap];

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

		public ushort MessageID { get; set; }

		private byte bgtiles;
		public byte BackgroundTileset {
			get => bgtiles;
			set
			{
				if (bgtiles == value) return;
				bgtiles = value;
				RefreshTilesets();
			}
		}

		private byte sprtiles;
		public byte SpriteTileset
		{
			get => sprtiles;
			set
			{
				if (sprtiles == value) return;
				sprtiles = value;
				RefreshTilesets();
			}
		}

		public LayerCollisionType LayerCollision { get; set; }

		private byte pal;
		public byte Palette {
			get => pal;
			set
			{
				if (pal == value) return;
				pal = value;
				RefreshPalette();
			}
		}


		private byte f1gfx, f2gfx;
		public byte Floor1Graphics {
			get => f1gfx;
			set
			{
				if (f1gfx == value) return;
				f1gfx = value;
				Redrawing = NeedsNewArt.UpdatedAllTilemaps;
			}
		}
		
		public byte Floor2Graphics {
			get => f2gfx;
			set
			{
				if (f2gfx == value) return;
				f2gfx = value;
				Redrawing = NeedsNewArt.UpdatedAllTilemaps;
			}
		}

		public LayerEffectType LayerEffect { get; set; }

		private LayerCouplingType coupling;
		public LayerCouplingType LayerCoupling {
			get => coupling;
			set
			{
				if (coupling == value) return;
				coupling = value;
				Redrawing = NeedsNewArt.UpdatedLayering;
			}
		}
		public RoomTagType Tag1 { get; set; }
		public RoomTagType Tag2 { get; set; }

		public bool IsDark { get; set; }

		private byte entrancegfx;
		public byte PreferredEntrance {
			get => entrancegfx;
			set
			{
				if (entrancegfx == value) return;
				entrancegfx = value;
				RefreshTilesets();
			}
		}

		public RoomDestination Pits { get; } = new RoomDestination(0);
		public RoomDestination Stair1 { get; } = new RoomDestination(1);
		public RoomDestination Stair2 { get; } = new RoomDestination(2);
		public RoomDestination Stair3 { get; } = new RoomDestination(3);
		public RoomDestination Stair4 { get; } = new RoomDestination(4);

		public RoomDestination[] AllStairs => new [] { Stair1, Stair2, Stair3, Stair4 };

		public bool HasDamagingPits { get; set; }

		public Color RoomColor => CGPalette[2, 4].RealColor;

		private readonly ZScreamer ZS;
		private Room(ZScreamer zs, ushort id)
		{
			RoomID = id;
			ZS = zs;
			Name = RoomName.ListOfVanillaNames[id].Name;
			ChestList = new ChestItemsHandler(this);
		}

		public static Room BuildRoomFromROM(ZScreamer Z, ushort id)
		{
			var ret = new Room(Z, id);
			ret.ReloadRoomFromROM();
			return ret;
		}

		private void ReloadRoomFromROM()
		{
			// Load dungeon header
			var headerPointer = ZS.ROM.Read24(ZS.Offsets.room_header_pointer).SNEStoPC();

			MessageID = ZS.ROM.Read16(ZS.Offsets.messages_id_dungeon + RoomID * 2);

			var hpos = (ZS.ROM[ZS.Offsets.room_header_pointers_bank] << 16 | ZS.ROM.Read16(headerPointer + RoomID * 2)).SNEStoPC();
			var b = ZS.ROM[hpos++];
			// TODO verify merge versus behavor

			LayerCoupling = LayerCouplingType.ListOf[b >> 5];
			LayerCollision = LayerCollisionType.ListOf[(b & 0x0C) >> 2];
			IsDark = (b & 0x01) == 0x01;
			pal = ZS.ROM[hpos++];
			bgtiles = ZS.ROM[hpos++];
			sprtiles = ZS.ROM[hpos++];
			//LayerMerging = LayerMergeType.ListOf[ZS.ROM[hpos++]];
			LayerEffect = LayerEffectType.ListOf[ZS.ROM[hpos++]];
			Tag1 = RoomTagType.GetTypeFromID(ZS.ROM[hpos++]);
			Tag2 = RoomTagType.GetTypeFromID(ZS.ROM[hpos++]);

			b = ZS.ROM[hpos++];

			Pits.TargetLayer = (byte) (b & 0x03);
			Stair1.TargetLayer = (byte) (b >> 2 & 0x03);
			Stair2.TargetLayer = (byte) (b >> 4 & 0x03);
			Stair3.TargetLayer = (byte) (b >> 6 & 0x03);
			Stair4.TargetLayer = (byte) (ZS.ROM[hpos++] & 0x03);

			Pits.Target = ZS.ROM[hpos++];
			Stair1.Target = ZS.ROM[hpos++];
			Stair2.Target = ZS.ROM[hpos++];
			Stair3.Target = ZS.ROM[hpos++];
			Stair4.Target = ZS.ROM[hpos++];

			// Load room objects
			var objectPointer = ZS.ROM.Read24(ZS.Offsets.room_object_pointer).SNEStoPC();
			var room_address = objectPointer + RoomID * 3;

			var objects_location = ZS.ROM.Read24(room_address).SNEStoPC();

			LoadObjectsFromArray(ZS.ROM.DataStream, offset: objects_location);


			// Load sprites
			var spritePointer = 0x040000 | ZS.ROM.Read16(ZS.Offsets.rooms_sprite_pointer);
			var sprite_address = (Constants.DungeonSpritePointers | ZS.ROM.Read16(spritePointer + RoomID * 2)).SNEStoPC();
			LoadSpritesFromArray(ZS.ROM.DataStream, offset: sprite_address);

			// Load other stuff
			LoadChests();
			LoadBlocks();
			LoadTorches();
			LoadSecrets();
			ResyncAllLists();

			LoadCustomCollisionFromRom();
			RefreshPalette();
			RefreshTilesets();
		}

		public void InvalidateTilemaps()
		{
			Redrawing |= NeedsNewArt.UpdatedAllTilemaps;
		}

		public void RefreshTilesets()
		{
			LoadedGraphics = ZS.GFXManager.CreateUnderworldGraphicsSet(
				BackgroundTileset,
				SpriteTileset,
				BackgroundTileset);
			Redrawing |= NeedsNewArt.UpdatedAllTilesets;
			Redrawing |= NeedsNewArt.UpdatedSpriteTileset;
		}

		public void RefreshPalette()
		{
			CGPalette = ZS.PaletteManager.CreateDungeonPalette(Palette);

			Redrawing |= NeedsNewArt.UpdatedAllPalettes;
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

		public void RemoveIfThereOrAddToSelectedObjects(IDungeonPlaceable d)
		{
			if (SelectedObjects.Contains(d))
			{
				SelectedObjects.Remove(d);
				return;
			}
			SelectedObjects.Add(d);
		}

		public void DoForAllRoomObjects(Action<RoomObject> act)
		{
			foreach (var r in Layer1Objects)
			{
				act(r);
			}

			foreach (var r in Layer2Objects)
			{
				act(r);
			}

			foreach (var r in Layer3Objects)
			{
				act(r);
			}
		}

		public void Undo()
		{
			throw new NotImplementedException();
			HasUnsavedChanges = true;
		}

		public void Redo()
		{
			throw new NotImplementedException();
			HasUnsavedChanges = true;
		}

		private void LoadChests()
		{
			ChestList.Clear();

			var cpos = ZS.ROM.Read24(ZS.Offsets.chests_data_pointer1).SNEStoPC();
			int clength = ZS.ROM.Read16(ZS.Offsets.chests_length_pointer);

			for (var i = 0; i < clength; i += 3)
			{
				var roomid = (ushort) (ZS.ROM.Read16(cpos) & 0x7FFF);
				cpos += 2;
				var item = ZS.ROM[cpos++]; // get now so cpos is incremented too

				if (roomid == RoomID)
				{
					ChestList.Add(new(ItemReceipt.GetTypeFromID(item)));
				}
			}
		}

		private void LoadBlocks()
		{
			int blockCount = ZS.ROM.Read16(ZS.Offsets.blocks_length);

			var pos1 = ZS.ROM.Read24(ZS.Offsets.blocks_pointer1).SNEStoPC();
			var pos2 = ZS.ROM.Read24(ZS.Offsets.blocks_pointer2).SNEStoPC();
			var pos3 = ZS.ROM.Read24(ZS.Offsets.blocks_pointer3).SNEStoPC();
			var pos4 = ZS.ROM.Read24(ZS.Offsets.blocks_pointer4).SNEStoPC();

			for (int j = 0, i = 0; j < blockCount; j += 4, i++)
			{
				var room = (ushort) (ZS.ROM[pos1 + i] | ZS.ROM[pos2 + i] << 8);

				if (room != RoomID) continue;

				var (x, y, layer) = UWTilemapPosition.CreateXYZFromTileMap(ZS.ROM[pos3 + i], (byte) (ZS.ROM[pos4 + i] & 0x3F));
				BlocksList.Add(
					new PushableBlock()
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
			var pos = ZS.Offsets.torch_data;
			var ending = pos + torchesSize;

			while (pos < ending)
			{
				var room = ZS.ROM.Read16(pos);
				pos += 2;

				var correctRoom = room == RoomID;

				var tpos = room; // assign it now to catch that one deleted thing in vanilla

				while (tpos != Constants.ObjectSentinel)
				{
					tpos = ZS.ROM.Read16(pos);
					pos += 2;

					if (correctRoom && tpos != Constants.ObjectSentinel)
					{
						var (x, y, layer) = UWTilemapPosition.CreateXYZFromTileMap(tpos);
						TorchList.Add(
							new LightableTorch()
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
			var secpos = 0x010000 | ZS.ROM.Read16(ZS.Offsets.room_items_pointers + RoomID * 2);
			secpos = secpos.SNEStoPC();

			while (true)
			{
				var b1 = ZS.ROM[secpos++];
				var b2 = ZS.ROM[secpos++];

				if ((b1 & b2) == 0xFF) break;

				var b3 = ZS.ROM[secpos++];

				var (x, y, layer) = UWTilemapPosition.CreateXYZFromTileMap(b1, b2);

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

		public DungeonObjectsList GetLayerList(RoomLayer layer) => layer switch
		{
			RoomLayer.Layer1 => Layer1Objects,
			RoomLayer.Layer2 => Layer2Objects,
			RoomLayer.Layer3 => Layer3Objects,
			_ => null,
		};

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
				oid = (ushort) (b3 & 0x3F | 0x100);
				posX = (byte) (b2 >> 4 | (b1 & 0x03) << 4);
				posY = (byte) ((b2 & 0x0F) << 2 | b3 >> 6);
				size = 0;
			}
			else if (b3 >= 0xF8) // Subtype 3
			{
				oid = (ushort) (0x0200 | (b3 & 0x07) << 4 | (b2 & 0x03) << 2 | b1 & 0x03);
				posX = (byte) (b1 >> 2);
				posY = (byte) (b2 >> 2);
				size = 0;
			}
			else // Subtype1
			{
				oid = b3;
				posX = (byte) (b1 >> 2);
				posY = (byte) (b2 >> 2);
				size = (byte) ((b1 & 0x03) << 2 | b2 & 0x03);
			}

			var rtype = RoomObjectType.GetTypeFromID(oid);
			if (rtype == null)
			{
				return null;
			}

			var defn = ZS.TileLister[oid];
			if (defn == null)
			{
				return null;
			}

			if (rtype.Resizeability == ObjectResizability.None)
			{
				size = 0;
			}

			return new(rtype, defn)
			{
				GridX = posX,
				GridY = posY,
				Size = size
			};
		}

		internal void ClearCollisionLayout()
		{
			CollisionMap = new byte?[Constants.TilesPerTilemap];
		}

		private void LoadCustomCollisionFromRom()
		{
			int offset = ZS.ROM.Read24(ZS.Offsets.CustomCollisionTable + (3 * RoomID));

			if (offset == 0) return;

			offset = offset.SNEStoPC();

			ushort next = ZS.ROM.Read16Continuous(ref offset);

			while (next is not Constants.ObjectSentinel or CollisionSinglesMarker )
			{
				var (x0, y0, _) = UWTilemapPosition.CreateXYZFromTileMap(next);

				byte w = ZS.ROM[offset++];
				byte h = ZS.ROM[offset++];

				for (int y = y0; y < y0 + h; y++)
				{
					for (int x = x0; x < x0 + w; x++)
					{
						CollisionMap[x + y * 64] = ZS.ROM[offset++];
					}
				}

				next = ZS.ROM.Read16Continuous(ref offset);
			}

			if (next is Constants.ObjectSentinel) return;

			next = ZS.ROM.Read16Continuous(ref offset);

			while (next != Constants.ObjectSentinel)
			{
				byte tile = ZS.ROM[offset++];
				CollisionMap[next / 2] = tile;

				next = ZS.ROM.Read16Continuous(ref offset);
			}
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

			var currentList = Layer1Objects;
			Floor1Graphics = (byte) (data[offset] & 0x0F);
			Floor2Graphics = (byte) (data[offset++] >> 4);
			Layout = (byte) (data[offset++] >> 2 & 0x07);

			byte b1, b2, b3;
			byte layer = 0;
			var door = false;

			while (true)
			{
				b1 = data[offset++];
				b2 = data[offset++];

				if (b2 == 0xFF)
				{
					if (b1 == 0xFF)
					{
						door = false;

						layer++;

						currentList = layer switch
						{
							(byte) RoomLayer.Layer1 => Layer1Objects,
							(byte) RoomLayer.Layer2 => Layer2Objects,
							(byte) RoomLayer.Layer3 => Layer3Objects,
							_ => null,
						};

						if (currentList is null) break;

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
					var r = ParseRoomObject(b1, b2, b3);

					if (r != null)
					{
						r.Layer = (RoomLayer) layer;
						currentList.Add(r);
					}
					else
					{
						throw new NullReferenceException("Shit that's a bad room object.");
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
				var b1 = data[offset++];

				if (b1 == Constants.SpriteSentinel) break;

				var b2 = data[offset++];
				var b3 = data[offset++];

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

				var subtype = (byte) (b2 >> 5 | (b1 & 0x60) >> 2);
				SpriteType t;

				if (subtype.BitsAllSet(0x07))
				{
					t = OverlordType.GetTypeFromID(b3) ?? SpriteType.GetTypeFromID(b3);
				}
				else
				{
					t = SpriteType.GetTypeFromID(b3);
				}

				last = new(t)
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

		private bool AttemptToAddEntity(IDungeonPlaceable o, DungeonEditMode m) => (m, o) switch
		{
			(DungeonEditMode.Layer1, RoomObject ro1) => AddRoomObject(ro1, Layer1Objects),
			(DungeonEditMode.Layer2, RoomObject ro2) => AddRoomObject(ro2, Layer2Objects),
			(DungeonEditMode.Layer3, RoomObject ro3) => AddRoomObject(ro3, Layer3Objects),
			(DungeonEditMode.Doors, DungeonDoor dr) => AddDoor(dr),
			(DungeonEditMode.Sprites, DungeonSprite so) => AddSprite(so),
			(DungeonEditMode.Blocks, PushableBlock bo) => AddBlock(bo),
			(DungeonEditMode.Torches, LightableTorch to) => AddTorch(to),
			(_, _) => false
		};

		private static void WarnIfTooMany(string entity, int count, int limit)
		{
			if (count > limit)
			{
				UIText.GeneralWarning(
				$"There are too many {entity}." +
				$"\nOnly {limit} may be placed in a single room." +
				$"\nYou may continue working, but be aware that staying in this state will likely cause corruption."
				);
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
				var count = CountLimitedObjects(lim);
				// TODO fill in limits
				// TODO maybe move elsewhere
				switch (lim)
				{
					case DungeonLimits.StarTiles:
						WarnIfTooMany("star tiles", count, 16);
						break;

				}
			}

			l.Add(o);

			HasUnsavedChanges = true;
			return true;
		}

		private bool AddSprite(DungeonSprite s)
		{
			var sprites = 0;
			var overlords = 0;

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

			WarnIfTooMany("overlord sprites", overlords, 8);
			WarnIfTooMany("non-overlord sprites", sprites, 16);

			SpritesList.Add(s);

			HasUnsavedChanges = true;
			return true;
		}

		private int CountLimitedObjects(DungeonLimits type)
		{
			var count = 0;

			DoForAllRoomObjects(o =>
			{
				if (o.LimitClass == type)
				{
					count++;
				}
			});

			return count;
		}

		private int CountManipulables()
		{
			var count = BlocksList.Count;

			DoForAllRoomObjects(o =>
			{
				if (o.LimitClass == DungeonLimits.GeneralManipulable)
				{
					count += o.Size + 1;
				}
				else if (o.LimitClass == DungeonLimits.GeneralManipulable4x)
				{
					count += 4;
				}
			});

			return count;
		}

		private void ValidateManipulables()
		{
			WarnIfTooMany("manipulable objects", CountManipulables(), 16);
		}

		private bool AddBlock(PushableBlock b)
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

		private bool AddTorch(LightableTorch t)
		{
			WarnIfTooMany("torches", TorchList.Count, 16);

			TorchList.Add(t);

			HasUnsavedChanges = true;
			return true;
		}

		private IDungeonPlaceable FindRelevantEntityUnderMouseForMode(DungeonEditMode em, int x, int y)
		{
			var l = FindRelevantListForMode(em);
			if (l is null) return null;

			return FindEntityUnderMouseInList(l, x, y);
		}


		private IList<IDungeonPlaceable> FindRelevantListForMode(DungeonEditMode em) => em switch
		{
			DungeonEditMode.Layer1 => (IList<IDungeonPlaceable>) Layer1Objects,
			DungeonEditMode.Layer2 => (IList<IDungeonPlaceable>) Layer2Objects,
			DungeonEditMode.Layer3 => (IList<IDungeonPlaceable>) Layer3Objects,
			DungeonEditMode.LayerAll => (IList<IDungeonPlaceable>) Layer1Objects.Concat(Layer2Objects).Concat(Layer3Objects),
			DungeonEditMode.Sprites => (IList<IDungeonPlaceable>) SpritesList,
			DungeonEditMode.Secrets => (IList<IDungeonPlaceable>) SecretsList,
			DungeonEditMode.Blocks => (IList<IDungeonPlaceable>) BlocksList,
			DungeonEditMode.Torches => (IList<IDungeonPlaceable>) TorchList,
			DungeonEditMode.Doors => (IList<IDungeonPlaceable>) DoorsList,
			_ => null,
		};


		private static IDungeonPlaceable FindEntityUnderMouseInList(IList<IDungeonPlaceable> l, int x, int y)
		{
			for (var i = l.Count - 1; i >= 0; i--) // count down because the objects on top are the most visible
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
			foreach (var o in SelectedObjects)
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
			var check = new List<IDungeonPlaceable>();
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
		/// Reorders doors with openable doors first, followed by shutter doors, then everything else.
		/// </summary>
		public void AutoSortDoors()
		{
			var openabledoors = new List<DungeonDoor>();
			var shutterdoors = new List<DungeonDoor>();
			var otherdoors = new List<DungeonDoor>();

			foreach (var door in DoorsList)
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
			WarnIfTooMany("openable + shutter doors", openabledoors.Count + shutterdoors.Count, 4);
		}

		public void AddChest()
		{
			throw new NotImplementedException();

			ReassociateChestsAndItems();
		}

		public void DeleteChest()
		{
			throw new NotImplementedException();

			ReassociateChestsAndItems();
		}



		public bool[] GetBigChestListing(int count)
		{
			var ret = new bool[count];
			var cur = 0;

			foreach (var l in AllObjects)
			{
				foreach (var r in l)
				{
					if (r.IsChest)
					{
						ret[cur++] = r.IsBigChest;
						if (cur == count)
						{
							return ret;
						}
					}
				}
			}

			return ret;
		}

		private List<RoomObject> FindAllObjects(Predicate<RoomObject> test)
		{
			List<RoomObject> ret = Layer1Objects.FindAll(test);
			ret.AddRange(Layer2Objects.FindAll(test));
			ret.AddRange(Layer3Objects.FindAll(test));

			return ret;
		}

		private void ReassociateChestsAndItems()
		{
			var chests = FindAllObjects(o => o.IsChest);

			var i = 0;
			foreach (var c in ChestList)
			{
				c.AssociatedChest = null;
				if (i >= chests.Count) continue;

				c.AssociatedChest = chests[i++];
			}

			HasUnsavedChanges = true;
		}

		private void ReassociateStairsAndTargets()
		{
			var stairs = FindAllObjects(o => o.IsStairs);

			var count = stairs.Count;

			Stair1.AssociatedObject = count > 0 ? stairs[0] : null;
			Stair2.AssociatedObject = count > 1 ? stairs[1] : null;
			Stair3.AssociatedObject = count > 2 ? stairs[2] : null;
			Stair4.AssociatedObject = count > 3 ? stairs[3] : null;

			HasUnsavedChanges = true;
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
				(byte) (LayerEffect.ID << 5 | LayerCollision.ID << 2 | (IsDark ? 1 : 0)),
				Palette,
				BackgroundTileset,
				SpriteTileset,
				LayerCoupling.ID,
				Tag1.ID,
				Tag2.ID,
				(byte) (Pits.TargetLayer | Stair1.TargetLayer << 2 | Stair2.TargetLayer << 4 | Stair3.TargetLayer << 6),
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

			ret.Add16(RoomID);

			ret.AddRange(TorchList.GetByteData());

			ret.Add16(Constants.ObjectSentinel);

			return ret.ToArray();
		}

		public bool HasNonemptyCustomCollision()
		{
			foreach (var b in CollisionMap)
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

			// all rectangles for collision
			var red = new List<Rectangle>();

			throw new NotImplementedException();

			foreach (var rectum in red)
			{
				var (l, h) = UWTilemapPosition.CreateLowAndHighBytesFromXYZ((byte) rectum.X, (byte) rectum.Y, 0);
				ret.Add(l);
				ret.Add(h);
				ret.Add((byte) rectum.Width);
				ret.Add((byte) rectum.Height);

				for (int y = rectum.Y; y < rectum.Y + rectum.Height; y++)
				{
					for (int x = rectum.X; x < rectum.X + rectum.Width; x++)
					{
						ret.Add(CollisionMap[x + 32 * y] ?? 0x00);
					}
				}
			}

			if (ret.Count > 0)
			{
				ret.Add16(Constants.ObjectSentinel);
			}

			return ret.ToArray();
		}
	}
}
