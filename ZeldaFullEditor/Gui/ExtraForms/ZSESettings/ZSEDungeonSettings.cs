using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaFullEditor.Properties;

namespace ZeldaFullEditor.Gui.ExtraForms.ZSESettings
{
    internal class ZSEDungeonSettings
    {
        [Category("Dungeon map colors")]
        [Browsable(true)]
        [DisplayName("Opened rooms outline color")]
        [DefaultValue(typeof(Color), "50 , 205, 50")]
        public Color openedRooms
        {
            get => Settings.Default.OpenedRoomOutline;
            set => Settings.Default.OpenedRoomOutline = value;
        }
        [Category("Dungeon map colors")]
        [Browsable(true)]
        [DisplayName("Opened rooms outline size")]
        [DefaultValue(2)]
        public int openedRoomsSize
        {
            get => Settings.Default.OpenedRoomOutlineSize;
            set => Settings.Default.OpenedRoomOutlineSize = value;
        }

        [Category("Dungeon map colors")]
        [Browsable(true)]
        [DisplayName("Selected opened room outline color")]
        [DefaultValue(typeof(Color), "0 , 255, 0")]
        public Color openedSelectedRoom
        {
            get => Settings.Default.SelectedRoomOutline;
            set => Settings.Default.SelectedRoomOutline = value;
        }

        [Category("Dungeon map colors")]
        [Browsable(true)]
        [DisplayName("Selected opened room outline size")]
        [DefaultValue(2)]
        public int openedSelectedRoomSize
        {
            get => Settings.Default.SelectedRoomOutlineSize;
            set => Settings.Default.SelectedRoomOutlineSize = value;
        }

        [Category("Dungeon map colors")]
        [Browsable(true)]
        [DisplayName("Opened selected exported room outline color")]
        [DefaultValue(typeof(Color), "46 , 139, 87")]
        public Color OpenedSelectedExportRoom
        {
            get => Settings.Default.OpenedExportedRoomOutline;
            set => Settings.Default.OpenedExportedRoomOutline = value;
        }

        [Category("Dungeon map colors")]
        [Browsable(true)]
        [DisplayName("Opened selected exported room outline size")]
        [DefaultValue(2)]
        public int OpenedSelectedExportRoomSize
        {
            get => Settings.Default.OpenedExportedRoomOutlineSize;
            set => Settings.Default.OpenedExportedRoomOutlineSize = value;
        }

        [Category("Dungeon map colors")]
        [Browsable(true)]
        [DisplayName("Selected exported rooms outline color")]
        [DefaultValue(typeof(Color), "0 , 205, 209")]
        public Color SelectedExportRooms
        {
            get => Settings.Default.ExportedRoomOutline;
            set => Settings.Default.ExportedRoomOutline = value;
        }

        [Category("Dungeon map colors")]
        [Browsable(true)]
        [DisplayName("Selected exported rooms outline size")]
        [DefaultValue(2)]
        public int SelectedExportRoomsSize
        {
            get => Settings.Default.ExportedRoomOutlineSize;
            set => Settings.Default.ExportedRoomOutlineSize = value;
        }

        //-------------------------------------------------------------------

        [Category("Dungeon editor colors")]
        [Browsable(true)]
        [DisplayName("Selected objects color (active)")]
        [DefaultValue(typeof(Color), "50 , 206, 50")]
        public Color SelectedObjectColor
        {
            get => Settings.Default.ObjectSelectedColor;
            set => Settings.Default.ObjectSelectedColor = value;
        }


        [Category("Dungeon editor colors")]
        [Browsable(true)]
        [DisplayName("Selected objects color (inactive)")]
        [DefaultValue(typeof(Color), "0 , 128, 0")]
        public Color SelectedLastObjectColor
        {
            get => Settings.Default.ObjectLastSelectedColor;
            set => Settings.Default.ObjectLastSelectedColor = value;
        }


        [Category("Dungeon editor colors")]
        [Browsable(true)]
        [DisplayName("Camera bounding box color")]
        [DefaultValue(typeof(Color), "255 , 165, 0")]
        public Color CameraColor
        {
            get => Settings.Default.CameraColor;
            set => Settings.Default.CameraColor = value;
        }

        [Category("Dungeon editor colors")]
        [Browsable(true)]
        [DisplayName("BG2 Masks color")]
        [DefaultValue(typeof(Color), "0 , 139, 139")]
        public Color BG2MaskColor
        {
            get => Settings.Default.BG2MaskColor;
            set => Settings.Default.BG2MaskColor = value;
        }
        
        [Category("Dungeon editor colors")]
        [Browsable(true)]
        [DisplayName("Selection box color")]
        [DefaultValue(typeof(Color), "255 , 255, 255")]
        public Color SelectionBoxColor
        {
            get => Settings.Default.SelectionBoxColor;
            set => Settings.Default.SelectionBoxColor = value;
        }
    }
}
