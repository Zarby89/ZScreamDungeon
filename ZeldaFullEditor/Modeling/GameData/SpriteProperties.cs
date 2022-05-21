namespace ZeldaFullEditor.Modeling.GameData
{
	/// <summary>
	/// Provides a container for all tabulated properties of a sprite.
	/// </summary>
	public class SpriteProperties
	{
		// OAMHarm
		public bool Harmless { get; set; }
		public bool UnknownM { get; set; }
		public bool SmallerTileHitbox { get; set; }
		public byte OAMAllocation { get; set; }

		public byte DataOAMHarm => IntFunctions.SetFieldBits(
			bit7: Harmless,
			bit6: UnknownM,
			bit5: SmallerTileHitbox,
			baseval: (byte) (OAMAllocation & 0x1F)
		);

		// Health
		public byte Health { get; set; }

		// Bump
		public bool IgnoreRecoilCollision { get; set; }
		public bool BeeTarget { get; set; }
		public bool ImperviousToPowder { get; set; }
		public bool AllowWithBoss { get; set; }
		public byte BumpClass { get; set; }
		public byte DataBump => IntFunctions.SetFieldBits(
			bit7: IgnoreRecoilCollision,
			bit6: BeeTarget,
			bit5: BeeTarget,
			bit4: AllowWithBoss,
			baseval: (byte) (BumpClass & 0x0F)
		);

		// OAMProp
		public bool CustomDeath { get; set; }
		public bool Impervious { get; set; }
		public bool SmallShadow { get; set; }
		public bool DrawShadow { get; set; }
		public byte Palette { get; set; }
		public bool NameTable { get; set; }
		public byte DataOAMProp => IntFunctions.SetFieldBits(
			bit7: CustomDeath,
			bit6: Impervious,
			bit5: SmallShadow,
			bit4: DrawShadow,
			bit0: NameTable,
			baseval: (byte) ((Palette & 0x7) << 1)
		);

		// Hitbox
		public bool SingleLayerCollision { get; set; }
		public bool IgnoreKillRoom { get; set; }
		public bool PersistOnOverworld { get; set; }
		public byte Hitbox { get; set; }
		public byte DataHitbox => IntFunctions.SetFieldBits(
			bit7: SingleLayerCollision,
			bit6: IgnoreKillRoom,
			bit5: PersistOnOverworld,
			baseval: (byte) (Hitbox & 0x1F)
		);

		// TileInteraction
		public byte TileHitbox { get; set; }
		public bool DeflectArrows { get; set; }
		public bool SlashableOverride { get; set; }
		public bool DieLikeABaws { get; set; }
		public bool PitOverride { get; set; }
		public byte DataTileInteraction => IntFunctions.SetFieldBits(
			baseval: (byte) (TileHitbox << 4),
			bit3: DeflectArrows,
			bit2: SlashableOverride,
			bit1: DieLikeABaws,
			bit0: PitOverride
		);

		// PrizePack
		public bool IgnoreMovingFloors { get; set; }
		public bool HandleWater { get; set; }
		public bool BlockedByShield { get; set; }
		public bool UseBossSFX { get; set; }
		public byte PrizePack { get; set; }
		public byte DataPrizePack => IntFunctions.SetFieldBits(
			bit7: IgnoreMovingFloors,
			bit6: HandleWater,
			bit5: BlockedByShield,
			bit4: UseBossSFX,
			baseval: (byte) (PrizePack & 0xF)
		);

		// Deflection
		public bool ActiveOffScreen { get; set; }
		public bool DieOffScreen { get; set; }
		public bool StatueForSomeReason { get; set; }
		public bool DeflectProjectiles { get; set; }
		public bool SimpleTileInteraction { get; set; }
		public bool ImperviousToSword { get; set; }
		public bool ArrowRumbling { get; set; }
		public bool NoPermaDeath { get; set; }
		public byte DataDeflection => IntFunctions.SetFieldBits(
			bit7: ActiveOffScreen,
			bit6: DieOffScreen,
			bit5: StatueForSomeReason,
			bit4: DeflectProjectiles,
			bit3: SimpleTileInteraction,
			bit2: ImperviousToSword,
			bit1: ArrowRumbling,
			bit0: NoPermaDeath
		);

		private SpriteProperties() { }


		public static readonly SpriteProperties Empty = new();

		public static SpriteProperties[] MakeNewSpriteListFromROM(ZScreamer zs)
		{
			var ret = new SpriteProperties[Constants.NumberOfValidSprites];
			for (var i = 0; i < Constants.NumberOfValidSprites; i++)
			{
				var s = new SpriteProperties();
				ret[i] = s;

				// OAMHarm
				var b = zs.ROM[zs.Offsets.SpriteOAMHarmData + i];
				s.Harmless = b.BitIsOn(0x80);
				s.UnknownM = b.BitIsOn(0x40);
				s.SmallerTileHitbox = b.BitIsOn(0x20);
				s.OAMAllocation = (byte) (b & 0x1F);

				// Health
				s.Health = zs.ROM[zs.Offsets.SpriteHealthData + i];

				// Bump
				b = zs.ROM[zs.Offsets.SpriteBumpData + i];
				s.IgnoreRecoilCollision = b.BitIsOn(0x80);
				s.BeeTarget = b.BitIsOn(0x40);
				s.ImperviousToPowder = b.BitIsOn(0x20);
				s.AllowWithBoss = b.BitIsOn(0x10);
				s.BumpClass = (byte) (b & 0x0F);

				// OAMProp
				b = zs.ROM[zs.Offsets.SpriteOAMPropData + i];
				s.CustomDeath = b.BitIsOn(0x80);
				s.Impervious = b.BitIsOn(0x40);
				s.SmallShadow = b.BitIsOn(0x20);
				s.DrawShadow = b.BitIsOn(0x10);
				s.Palette = (byte) (b >> 1 & 0x7);
				s.NameTable = b.BitIsOn(0x01);

				// Hitbox
				b = zs.ROM[zs.Offsets.SpriteHitboxData + i];
				s.SingleLayerCollision = b.BitIsOn(0x80);
				s.IgnoreKillRoom = b.BitIsOn(0x40);
				s.PersistOnOverworld = b.BitIsOn(0x20);
				s.Hitbox = (byte) (b & 0x1F);

				// TileInteraction
				b = zs.ROM[zs.Offsets.SpriteTileIntData + i];
				s.TileHitbox = (byte) (b >> 4);
				s.DeflectArrows = b.BitIsOn(0x08);
				s.SlashableOverride = b.BitIsOn(0x04);
				s.DieLikeABaws = b.BitIsOn(0x02);
				s.PitOverride = b.BitIsOn(0x01);

				// PrizePack
				b = zs.ROM[zs.Offsets.SpritePrizePackData + i];
				s.IgnoreMovingFloors = b.BitIsOn(0x80);
				s.HandleWater = b.BitIsOn(0x40);
				s.BlockedByShield = b.BitIsOn(0x20);
				s.UseBossSFX = b.BitIsOn(0x10);
				s.PrizePack = (byte) (b & 0x0F);

				// Deflection
				b = zs.ROM[zs.Offsets.SpriteDeflectionData + i];
				s.ActiveOffScreen = b.BitIsOn(0x80);
				s.DieOffScreen = b.BitIsOn(0x40);
				s.StatueForSomeReason = b.BitIsOn(0x20);
				s.DeflectProjectiles = b.BitIsOn(0x10);
				s.SimpleTileInteraction = b.BitIsOn(0x08);
				s.ImperviousToSword = b.BitIsOn(0x04);
				s.ArrowRumbling = b.BitIsOn(0x02);
				s.NoPermaDeath = b.BitIsOn(0x01);
			}

			return ret;
		}


	}
}
