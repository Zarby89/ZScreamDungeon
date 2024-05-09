using System;

namespace ZeldaFullEditor.Data
{
    [System.ComponentModel.DefaultBindingProperty]
    public class SpriteProperty
    {
        internal byte OAMAllocation { get; set; } = 0;

        internal byte Palette { get; set; } = 0;

        internal byte Hitbox { get; set; } = 0;

        internal byte TileHitBox { get; set; } = 0;

        internal byte Health { get; set; } = 0;

        internal byte PrizePack { get; set; } = 0;

        internal byte BumpDamageClass { get; set; } = 0;

        internal bool Harmless { get; set; } = false;

        internal bool DeathPrevent { get; set; } = false; // hidden

        internal bool LiteTileHit { get; set; } = false; // hidden

        internal bool RecoilWithoutCollision { get; set; } = false;

        internal bool BeeTarget { get; set; } = false;

        internal bool ImmunePowder { get; set; } = false;

        internal bool AllowedBossFight { get; set; } = false;

        internal bool CustomDeathAnimation { get; set; } = false;

        internal bool Invulnerable { get; set; } = false;

        internal bool SmallShadow { get; set; } = false;

        internal bool DrawShadow { get; set; } = false;

        internal bool GraphicsPage { get; set; } = false;

        internal bool Singlelayercollision { get; set; } = false;

        internal bool Ignoredbykillrooms { get; set; } = false;

        internal bool Persistoffscreenow { get; set; } = false;

        internal bool Deflectarrows { get; set; } = false;

        internal bool ZeroDamageOverride { get; set; } = false;

        internal bool DieLikeABoss { get; set; } = false;

        internal bool Invertpitbehavior { get; set; } = false;

        internal bool IgnorePitConveyors { get; set; } = false;

        internal bool CheckForWater { get; set; } = false;

        internal bool BlockedByShield { get; set; } = false;

        internal bool AltDamageSound { get; set; } = false;

        internal bool ActiveOffScreen { get; set; } = false;

        internal bool DieOffScreen { get; set; } = false;

        internal bool HiddenProp { get; set; } = false;

        internal bool HiddenUnused { get; set; } = false;

        internal bool ProjectileLikeCollision { get; set; } = false;

        internal bool ImmuneToSwordHammer { get; set; } = false;

        internal bool Bonkitem { get; set; } = false;

        internal bool NoPermaDeathInDungeons { get; set; } = false;

        internal byte[] DamagesTaken = new byte[16];

        public SpriteProperty(byte id)
        {
            byte addr0DB080 = ROM.ReadByte(Constants.Sprite_0DB080 + id);
            byte addr0DB266 = ROM.ReadByte(Constants.Sprite_0DB266 + id);
            byte addr0DB359 = ROM.ReadByte(Constants.Sprite_0DB359 + id);
            byte addr0DB44C = ROM.ReadByte(Constants.Sprite_0DB44C + id);
            byte addr0DB53F = ROM.ReadByte(Constants.Sprite_0DB53F + id);
            byte addr0DB632 = ROM.ReadByte(Constants.Sprite_0DB632 + id);
            byte addr0DB725 = ROM.ReadByte(Constants.Sprite_0DB725 + id);

            // $0E50
            Health = ROM.ReadByte(Constants.Sprite_Health + id);

            // $0E40
            Harmless = addr0DB080.BitIsOn(0x80);
            DeathPrevent = addr0DB080.BitIsOn(0x40);
            LiteTileHit = addr0DB080.BitIsOn(0x20);
            OAMAllocation = (byte)(addr0DB080 & 0x1F);

            // $0CD2
            RecoilWithoutCollision = addr0DB266.BitIsOn(0x80);
            BeeTarget = addr0DB266.BitIsOn(0x40);
            ImmunePowder = addr0DB266.BitIsOn(0x20);
            AllowedBossFight = addr0DB266.BitIsOn(0x10);
            BumpDamageClass = (byte)(addr0DB266 & 0x0F);

            // $0E60 and $0F50 (only last 4 bits go into $0F50)
            CustomDeathAnimation = addr0DB359.BitIsOn(0x80);
            Invulnerable = addr0DB359.BitIsOn(0x40);
            SmallShadow = addr0DB359.BitIsOn(0x20);
            DrawShadow = addr0DB359.BitIsOn(0x10);
            GraphicsPage = addr0DB359.BitIsOn(0x01);
            Palette = (byte)((addr0DB359 & 0x0E) >> 1); // Bit shifted to make it easier to set later. Before we save to rom we shift it back.

            // $0F60
            Singlelayercollision = addr0DB44C.BitIsOn(0x80);
            Ignoredbykillrooms = addr0DB44C.BitIsOn(0x40);
            Persistoffscreenow = addr0DB44C.BitIsOn(0x20);
            Hitbox = (byte)(addr0DB44C & 0x1F);

            // $0B6B
            TileHitBox = addr0DB53F.GetHighNibble(); // Bit shifted to make it easier to set later. Before we save to rom we shift it back.
            Deflectarrows = addr0DB53F.BitIsOn(0x08);
            ZeroDamageOverride = addr0DB53F.BitIsOn(0x04);
            DieLikeABoss = addr0DB53F.BitIsOn(0x02);
            Invertpitbehavior = addr0DB53F.BitIsOn(0x01);

            // $0BE0
            IgnorePitConveyors = addr0DB632.BitIsOn(0x80);
            CheckForWater = addr0DB632.BitIsOn(0x40);
            BlockedByShield = addr0DB632.BitIsOn(0x20);
            AltDamageSound = addr0DB632.BitIsOn(0x10);
            PrizePack = addr0DB632.GetLowNibble(); ;

            // $0CAA
            ActiveOffScreen = addr0DB725.BitIsOn(0x80);
            DieOffScreen = addr0DB725.BitIsOn(0x40);
            HiddenProp = addr0DB725.BitIsOn(0x20);
            HiddenUnused = addr0DB725.BitIsOn(0x10);
            ProjectileLikeCollision = addr0DB725.BitIsOn(0x08);
            ImmuneToSwordHammer = addr0DB725.BitIsOn(0x04);
            Bonkitem = addr0DB725.BitIsOn(0x02);
            NoPermaDeathInDungeons = addr0DB725.BitIsOn(0x01);

            if (id < 0xD8)
            {
                for (int i = 0; i < 8; i += 1)
                {
                    DamagesTaken[(i * 2) + 1] = DungeonsData.SpriteDamageTaken[i + (id * 8)].GetLowNibble();
                    DamagesTaken[(i * 2)] = DungeonsData.SpriteDamageTaken[i + (id * 8)].GetHighNibble();
                }
            }
        }

        public void SaveToROM(byte id)
        {
			// $0E40
			byte addr0DB080 = (byte) (IntFunctions.MakeBitfield(bit7: Harmless, bit6: DeathPrevent, bit5: LiteTileHit) | OAMAllocation);

			// $0CD2
			byte addr0DB266 = (byte) (IntFunctions.MakeBitfield(bit7: RecoilWithoutCollision, bit6: BeeTarget, bit5: ImmunePowder, bit4: AllowedBossFight) | BumpDamageClass);

			// $0E60 (full) and $0F50 (low nibble only)
			byte addr0DB359 = (byte) (IntFunctions.MakeBitfield(bit7: CustomDeathAnimation, bit6: Invulnerable, bit5: SmallShadow, bit4: DrawShadow, bit0: GraphicsPage) | (Palette << 1));

			// $0F60
			byte addr0DB44C = (byte) (IntFunctions.MakeBitfield(bit7: Singlelayercollision, bit6: Ignoredbykillrooms, bit5: Persistoffscreenow) | Hitbox);

			// $0B6B
			byte addr0DB53F = (byte) ((TileHitBox << 4) | IntFunctions.MakeBitfield(bit3: Deflectarrows, bit2: ZeroDamageOverride, bit1: DieLikeABoss, bit0: Invertpitbehavior));

			// $0BE0
			byte addr0DB632 = (byte) (IntFunctions.MakeBitfield(bit7: IgnorePitConveyors, bit6: CheckForWater, bit5: BlockedByShield, bit4: AltDamageSound) | PrizePack);

			// $0CAA
			byte addr0DB725 = IntFunctions.MakeBitfield(bit7: ActiveOffScreen, bit6: DieOffScreen, bit5: HiddenProp, bit4: HiddenUnused, bit3: ProjectileLikeCollision, bit2: ImmuneToSwordHammer, bit1: Bonkitem, bit0: NoPermaDeathInDungeons);

			ROM.Write(Constants.Sprite_0DB080 + id, addr0DB080);
            ROM.Write(Constants.Sprite_0DB266 + id, addr0DB266);
            ROM.Write(Constants.Sprite_0DB359 + id, addr0DB359);
            ROM.Write(Constants.Sprite_0DB44C + id, addr0DB44C);
            ROM.Write(Constants.Sprite_0DB53F + id, addr0DB53F);
            ROM.Write(Constants.Sprite_0DB632 + id, addr0DB632);
            ROM.Write(Constants.Sprite_0DB725 + id, addr0DB725);
            ROM.Write(Constants.Sprite_Health + id, Health);

            for (int i = 0; i < 8; i ++)
            {
                DungeonsData.SpriteDamageTaken[i + (id * 8)] = (byte)((DamagesTaken[(i * 2)]<<4) | (DamagesTaken[(i * 2)+1]));
            }
        }
    }
}
