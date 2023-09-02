using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using ZeldaFullEditor;

namespace ZeldaFullEditor.Data
{
    public class SpriteProperty
    {
        internal byte oamSlot = 0;
        internal byte palette = 0;
        internal byte hitbox = 0;
        internal byte inthitbox = 0;
        internal byte health = 0;
        internal byte damagetype = 0;
        internal byte prizepack = 0;

        internal bool drawShadow = false;
        internal bool deathAnim = false;
        internal bool boss = false;
        internal bool blockable = false;
        internal bool statis = false;
        internal bool persist = false;
        internal bool fall = false;
        internal bool alternatesound = false;
        internal bool ignorecollision = false;
        internal bool tileinteraction = false;
        internal bool imperviousswordhammer = false;
        internal bool deflectprojectile = false;
        internal bool imperviousarrow = false;
        internal bool collideless = false;
        internal bool harmless = false;
        internal bool invulnerable = false;
        internal bool adjcoord = false;
        internal bool waterspr = false;
        internal bool statue = false;
        internal bool highspeed = false;





        public SpriteProperty(byte id)
        {
            if ((ROM.ReadByte(Constants.sprHarmlessOamSlotVelocity + id) & 0x80) == 0x80)
            {
                harmless = true;
            }

            if ((ROM.ReadByte(Constants.sprHarmlessOamSlotVelocity + id) & 0x40) == 0x40)
            {
                highspeed = true;
            }

            oamSlot = (byte)(ROM.ReadByte(Constants.sprHarmlessOamSlotVelocity + id) & 0x3F);

            health = (byte)(ROM.ReadByte(Constants.sprHealth + id));
            damagetype = (byte)(ROM.ReadByte(Constants.sprDamage + id));

            if ((ROM.ReadByte(Constants.sprDeathAnimImpervAllShadowsPalette + id) & 0x80) == 0x80)
            {
                deathAnim = true;
            }

            if ((ROM.ReadByte(Constants.sprDeathAnimImpervAllShadowsPalette + id) & 0x40) == 0x40)
            {
                invulnerable = true;
            }

            if ((ROM.ReadByte(Constants.sprDeathAnimImpervAllShadowsPalette + id) & 0x20) == 0x20)
            {
                drawShadow = true;
            }

            palette = (byte)((ROM.ReadByte(Constants.sprDeathAnimImpervAllShadowsPalette + id) & 0x0E) >> 1);

            if ((ROM.ReadByte(Constants.sprHitboxPersistStatis + id) & 0x80) == 0x80) // both layer
            {
                collideless = true;
            }

            if ((ROM.ReadByte(Constants.sprHitboxPersistStatis + id) & 0x40) == 0x40)
            {
                statis = true;
            }

            if ((ROM.ReadByte(Constants.sprHitboxPersistStatis + id) & 0x20) == 0x20)
            {
                persist = true;
            }

            hitbox = (byte)(ROM.ReadByte(Constants.sprHitboxPersistStatis + id) & 0x1F);


            if ((ROM.ReadByte(Constants.sprBossFallDeflectArrow + id) & 0x08) == 0x08)
            {
                imperviousarrow = true;
            }

            if ((ROM.ReadByte(Constants.sprBossFallDeflectArrow + id) & 0x02) == 0x02)
            {
                boss = true;
            }

            if ((ROM.ReadByte(Constants.sprBossFallDeflectArrow + id) & 0x01) == 0x01)
            {
                fall = true;
            }

            if ((ROM.ReadByte(Constants.sprInteractWaterBlockSoundPrize + id) & 0x80) == 0x80)
            {
                tileinteraction = true;
            }

            if ((ROM.ReadByte(Constants.sprInteractWaterBlockSoundPrize + id) & 0x40) == 0x40)
            {
                waterspr = true;
            }

            if ((ROM.ReadByte(Constants.sprInteractWaterBlockSoundPrize + id) & 0x20) == 0x20)
            {
                blockable = true;
            }

            if ((ROM.ReadByte(Constants.sprInteractWaterBlockSoundPrize + id) & 0x10) == 0x10)
            {
                alternatesound = true;
            }

            prizepack = (byte)(ROM.ReadByte(Constants.sprInteractWaterBlockSoundPrize + id) & 0x0F);

            if ((ROM.ReadByte(Constants.sprStatueDeflectProjImpervSwordHammerArrows + id) & 0x20) == 0x20)
            {
                statue = true;
            }

            if ((ROM.ReadByte(Constants.sprStatueDeflectProjImpervSwordHammerArrows + id) & 0x10) == 0x10)
            {
                deflectprojectile = true;
            }

            if ((ROM.ReadByte(Constants.sprStatueDeflectProjImpervSwordHammerArrows + id) & 0x04) == 0x04)
            {
                imperviousswordhammer = true;
            }

            if ((ROM.ReadByte(Constants.sprStatueDeflectProjImpervSwordHammerArrows + id) & 0x02) == 0x02)
            {
                imperviousarrow = true;
            }



        }
        public void SaveToROM(byte id)
        {
            byte sprDeathAnimImpervAllShadowsPalette = (byte)(ROM.ReadByte(Constants.sprDeathAnimImpervAllShadowsPalette + id) & 0x01);
            byte sprStatueDeflectProjImpervSwordHammerArrows = (byte)(ROM.ReadByte(Constants.sprStatueDeflectProjImpervSwordHammerArrows + id) & 0xC1);
            byte sprBossFallDeflectArrow = (byte)(ROM.ReadByte(Constants.sprBossFallDeflectArrow + id) & 0xF4);
            byte sprHitboxPersistStatis = 0;
            byte sprInteractWaterBlockSoundPrize = prizepack;
            byte sprHarmlessOamSlotVelocity = 0;



            if (deathAnim)
            {
                sprDeathAnimImpervAllShadowsPalette |= 0x80;
            }

            if (drawShadow)
            {
                sprDeathAnimImpervAllShadowsPalette |= 0x20;
            }

            if (invulnerable)
            {
                sprDeathAnimImpervAllShadowsPalette |= 0x40;
            }

            sprDeathAnimImpervAllShadowsPalette |= (byte)(palette << 1);

            sprHarmlessOamSlotVelocity = oamSlot;
            if (harmless)
            {
                sprHarmlessOamSlotVelocity |= 0x80;
            }

            if (highspeed)
            {
                sprHarmlessOamSlotVelocity |= 0x40;
            }

            sprHitboxPersistStatis = hitbox;

            if (collideless)
            {
                sprHitboxPersistStatis |= 0x80;
            }
            if (statis)
            {
                sprHitboxPersistStatis |= 0x40;
            }

            if (persist)
            {
                sprHitboxPersistStatis |= 0x20;
            }

            hitbox = (byte)(ROM.ReadByte(Constants.sprHitboxPersistStatis + id) & 0x1F);


            if (boss)
            {
                sprBossFallDeflectArrow |= 0x02;
            }

            if (fall)
            {
                sprBossFallDeflectArrow |= 0x01;
            }

            if (imperviousarrow)
            {
                sprBossFallDeflectArrow |= 0x08;
            }


            if (waterspr)
            {
                sprInteractWaterBlockSoundPrize |= 0x40;
            }
            if (blockable)
            {
                sprInteractWaterBlockSoundPrize |= 0x20;
            }
            if (alternatesound)
            {
                sprInteractWaterBlockSoundPrize |= 0x10;
            }
            if (tileinteraction)
            {
                sprInteractWaterBlockSoundPrize |= 0x80;
            }

            if (statue)
            {
                sprStatueDeflectProjImpervSwordHammerArrows |= 0x20;
            }
            if (deflectprojectile)
            {
                sprStatueDeflectProjImpervSwordHammerArrows |= 0x10;
            }
            if (imperviousswordhammer)
            {
                sprStatueDeflectProjImpervSwordHammerArrows |= 0x04;
            }
            if (imperviousarrow)
            {
                sprStatueDeflectProjImpervSwordHammerArrows |= 0x02;
            }


            ROM.Write(Constants.sprHealth + id, health);
            ROM.Write(Constants.sprDamage + id, damagetype);

            ROM.Write(Constants.sprDeathAnimImpervAllShadowsPalette + id, sprDeathAnimImpervAllShadowsPalette);
            ROM.Write(Constants.sprHarmlessOamSlotVelocity + id, sprHarmlessOamSlotVelocity);
            ROM.Write(Constants.sprHitboxPersistStatis + id, sprHitboxPersistStatis);
            ROM.Write(Constants.sprBossFallDeflectArrow + id, sprBossFallDeflectArrow);
            ROM.Write(Constants.sprInteractWaterBlockSoundPrize + id, sprInteractWaterBlockSoundPrize);
            ROM.Write(Constants.sprStatueDeflectProjImpervSwordHammerArrows + id, sprStatueDeflectProjImpervSwordHammerArrows);



        }



    }

}

