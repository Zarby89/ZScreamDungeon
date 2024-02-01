using System;

namespace ZeldaFullEditor.Data
{
    [System.ComponentModel.DefaultBindingProperty]
    public class SpriteProperty
    {
        internal byte OamAllocation { get; set; } = 0;

        internal byte Palette { get; set; } = 0;

        internal byte Hitbox { get; set; } = 0;

        internal byte Tilehitbox { get; set; } = 0;

        internal byte Health { get; set; } = 0;

        internal byte Prizepack { get; set; } = 0;

        internal byte Bumpdamageclass { get; set; } = 0;

        internal bool Harmless { get; set; } = false;

        internal bool Deathprevent { get; set; } = false; // hidden

        internal bool Litetilehit { get; set; } = false; // hidden

        internal bool Recoilwithoutcollision { get; set; } = false;

        internal bool Beetarget { get; set; } = false;

        internal bool Immunepowder { get; set; } = false;

        internal bool Allowedbossfight { get; set; } = false;

        internal bool Customdeathanimation { get; set; } = false;

        internal bool Invulnerable { get; set; } = false;

        internal bool Smallshadow { get; set; } = false;

        internal bool Drawshadow { get; set; } = false;

        internal bool Graphicspage { get; set; } = false;

        internal bool Singlelayercollision { get; set; } = false;

        internal bool Ignoredbykillrooms { get; set; } = false;

        internal bool Persistoffscreenow { get; set; } = false;

        internal bool Deflectarrows { get; set; } = false;

        internal bool Overrideslashimminuty { get; set; } = false;

        internal bool Dielikeaboss { get; set; } = false;

        internal bool Invertpitbehavior { get; set; } = false;

        internal bool Ignorepitconveyors { get; set; } = false;

        internal bool Checkforwater { get; set; } = false;

        internal bool Blockedbyshield { get; set; } = false;

        internal bool Altdamagesound { get; set; } = false;

        internal bool Activeoffscreen { get; set; } = false;

        internal bool Dieoffscreen { get; set; } = false;

        internal bool Hiddenprop { get; set; } = false;

        internal bool Hiddenunused { get; set; } = false;

        internal bool Projectilelikecollision { get; set; } = false;

        internal bool Immunetoswordhammer { get; set; } = false;

        internal bool Bonkitem { get; set; } = false;

        internal bool Nopermadeathindungeons { get; set; } = false;

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
            Health = ROM.ReadByte(Constants.Sprite_Health + id);

            Harmless = addr0DB080.BitIsOn(0x80);
            Deathprevent = addr0DB080.BitIsOn(0x40);
            Litetilehit = addr0DB080.BitIsOn(0x20);
            OamAllocation = (byte)(addr0DB080 & 0x1F);

            Recoilwithoutcollision = addr0DB266.BitIsOn(0x80);
            Beetarget = addr0DB266.BitIsOn(0x40);
            Immunepowder = addr0DB266.BitIsOn(0x20);
            Allowedbossfight = addr0DB266.BitIsOn(0x10);
            Bumpdamageclass = (byte)(addr0DB266 & 0x0F);

            Customdeathanimation = addr0DB359.BitIsOn(0x80);
            Invulnerable = addr0DB359.BitIsOn(0x40);
            Smallshadow = addr0DB359.BitIsOn(0x20);
            Drawshadow = addr0DB359.BitIsOn(0x10);
            Graphicspage = addr0DB359.BitIsOn(0x01);
            Palette = (byte)((addr0DB359 & 0x0E) >> 1);

            Singlelayercollision = addr0DB44C.BitIsOn(0x80);
            Ignoredbykillrooms = addr0DB44C.BitIsOn(0x40);
            Persistoffscreenow = addr0DB44C.BitIsOn(0x20);
            Hitbox = (byte)(addr0DB44C & 0x1F);

            Tilehitbox = (byte)((addr0DB53F & 0xF0) >> 4);
            Deflectarrows = addr0DB53F.BitIsOn(0x08);
            Overrideslashimminuty = addr0DB53F.BitIsOn(0x04);
            Dielikeaboss = addr0DB53F.BitIsOn(0x02);
            Invertpitbehavior = addr0DB53F.BitIsOn(0x01);

            Ignorepitconveyors = addr0DB632.BitIsOn(0x80);
            Checkforwater = addr0DB632.BitIsOn(0x40);
            Blockedbyshield = addr0DB632.BitIsOn(0x20);
            Altdamagesound = addr0DB632.BitIsOn(0x10);
            Prizepack = (byte)(addr0DB632 & 0x0F);

            Activeoffscreen = addr0DB725.BitIsOn(0x80);
            Dieoffscreen = addr0DB725.BitIsOn(0x40);
            Hiddenprop = addr0DB725.BitIsOn(0x20);
            Hiddenunused = addr0DB725.BitIsOn(0x10);
            Projectilelikecollision = addr0DB725.BitIsOn(0x08);
            Immunetoswordhammer = addr0DB725.BitIsOn(0x04);
            Bonkitem = addr0DB725.BitIsOn(0x02);
            Nopermadeathindungeons = addr0DB725.BitIsOn(0x01);

            if (id <= 0xD7)
            {
                for (int i = 0; i < 8; i += 1)
                {
                    DamagesTaken[i * 2] = (byte)(DungeonsData.SpriteDamageTaken[(i) + (id * 8)] & 0x0F);
                    DamagesTaken[(i * 2) + 1] = (byte)((DungeonsData.SpriteDamageTaken[(i) + (id * 8)] & 0xF0) >> 4);
                }
            }
        }

        

        public void SaveToROM(byte id)
        {
            byte addr0DB080 = (byte)(OamAllocation | IntFunctions.MakeBitfield(Harmless, Deathprevent, Litetilehit));
            byte addr0DB266 = (byte)(Bumpdamageclass | IntFunctions.MakeBitfield(Recoilwithoutcollision, Beetarget, Immunepowder, Allowedbossfight));
            byte addr0DB359 = (byte)(IntFunctions.MakeBitfield(Customdeathanimation, Invulnerable, Smallshadow, Drawshadow, false, false, false, Graphicspage) | (Palette << 1));
            byte addr0DB44C = (byte)(Hitbox | IntFunctions.MakeBitfield(Singlelayercollision, Ignoredbykillrooms, Persistoffscreenow));
            byte addr0DB53F = (byte)(IntFunctions.MakeBitfield(false, false, false, false, Deflectarrows,Overrideslashimminuty,Dielikeaboss,Invertpitbehavior) | (Tilehitbox << 4));
            byte addr0DB632 = (byte)(Prizepack | IntFunctions.MakeBitfield(Ignorepitconveyors, Checkforwater, Blockedbyshield, Altdamagesound));
            byte addr0DB725 = IntFunctions.MakeBitfield(Activeoffscreen, Dieoffscreen, Hiddenprop, Hiddenunused, Projectilelikecollision, Immunetoswordhammer, Bonkitem, Nopermadeathindungeons);

            ROM.Write(Constants.Sprite_0DB080 + id, addr0DB080);
            ROM.Write(Constants.Sprite_0DB266 + id, addr0DB266);
            ROM.Write(Constants.Sprite_0DB359 + id, addr0DB359);
            ROM.Write(Constants.Sprite_0DB44C + id, addr0DB44C);
            ROM.Write(Constants.Sprite_0DB53F + id, addr0DB53F);
            ROM.Write(Constants.Sprite_0DB632 + id, addr0DB632);
            ROM.Write(Constants.Sprite_0DB725 + id, addr0DB725);
            ROM.Write(Constants.Sprite_Health + id, Health);

            for (int i = 0; i < 8; i += 1)
            {
                DungeonsData.SpriteDamageTaken[i + (id * 8)] = (byte)(DamagesTaken[(i * 2)] | (DamagesTaken[(i * 2) + 1] << 4));
            }

        }
    }
}