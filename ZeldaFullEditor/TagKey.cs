using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ZeldaFullEditor
{
    public enum TagKey
    {


        Nothing,
        NW_Kill_Enemy_to_Open,
        NE_Kill_Enemy_to_Open,
        SW_Kill_Enemy_to_Open,
        SE_Kill_Enemy_to_Open,
        W_Kill_Enemy_to_Open,
        E_Kill_Enemy_to_Open,
        N_Kill_Enemy_to_Open,
        S_Kill_Enemy_to_Open,
        Clear_Quadrant_to_Open,
        Clear_Room_to_Open,
        NW_Push_Block_to_Open,
        NE_Push_Block_to_Open,
        SW_Push_Block_to_Open,
        SE_Push_Block_to_Open,
        W_Push_Block_to_Open,
        E_Push_Block_to_Open,
        N_Push_Block_to_Open,
        S_Push_Block_to_Open,
        Push_Block_to_Open,
        Pull_Lever_to_Open,
        Clear_Level_to_Open,
        Switch_Open_Door_Hold,
        Switch_Open_Door_Toggle,
        Turn_off_Water,
        Turn_on_Water,
        Water_Gate,
        Water_Twin,
        Secret_Wall_Right,
        Secret_Wall_Left,
        Crash1,
        Crash2,
        Pull_Switch_to_bomb_Wall,
        Holes_0,
        Open_Chest_Activate_Holes_0,
        Holes_1,
        Holes_2,
        Kill_Enemy_to_clear_level,
        SE_Kill_Enemy_to_Move_Block,
        Trigger_activated_Chest,
        Pull_lever_to_Bomb_Wall,

        NW_Kill_Enemy_for_Chest,

        NE_Kill_Enemy_for_Chest,

        SW_Kill_Enemy_for_Chest,

        SE_Kill_Enemy_for_Chest,

        W_Kill_Enemy_for_Chest,

        E_Kill_Enemy_for_Chest,

        N_Kill_Enemy_for_Chest,

        S_Kill_Enemy_for_Chest,

        Clear_Quadrant_for_Chest,

        Clear_Room_for_Chest,

        Light_Torches_to_Open,

        Holes_3,

        Holes_4,

        Holes_5,

        Holes_6,

        Agahnim_Room,

        Holes_7,

        Holes_8,

        Open_Chest_for_Holes_8,

        Push_Block_for_Chest,

        Kill_to_open_Ganon_Door,

        Light_Torches_to_get_Chest,

        Kill_boss_Again

    }


    public enum EffectKey
    {
        Nothing,
        One,
        Moving_Floor,
        Moving_Water,
        Four,
        Red_Flashes,
        Light_Torch_to_See_Floor,
        Ganon_Room,
    }

    public enum CollisionKey
    {
        One,
        Both,
        Both_With_Scroll,
        Moving_Floor,
        Moving_Water,
    }
}
