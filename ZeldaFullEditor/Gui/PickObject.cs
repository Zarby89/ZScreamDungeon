using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
    public partial class PickObject : Form
    {
        public PickObject()
        {
            InitializeComponent();
           
        }
        public bool alreadyInit = false;
        public List<Room_Object> roomObjects = new List<Room_Object>();
        public Room room;
        private void PickObject_Load(object sender, EventArgs e)
        {
            
        }
        
        public void createObjects(Room room)
        {
            
            this.room = room;
            if (alreadyInit == true)
            {
                return;
            }
            alreadyInit = true;
            //Parallel.For(0, 0xE8, i => //all type 1 objects
            for (int i = 0;i<0xE8;i++)
            {
                addObject((short)i, 0, 0, 0, 0);
            }//);
            //Parallel.For(0x100, 0x140, i => //all type 1 objects
            for (int i = 0x100; i < 0x140; i++)
            {
                addObject((short)i, 0, 0, 0, 0);
            }//);
            //Parallel.For(0xF80, 0xFFF, i => //all type 1 objects
            for (int i = 0xF80; i < 0xFFF; i++)
            {
                addObject((short)i, 0, 0, 0, 0);
            }//);

            sortingCombobox.Items.Clear();
            foreach (var e in Enum.GetValues(typeof(Sorting)))
            {
                if ((Sorting)e == Sorting.Horizontal || (Sorting)e == Sorting.Vertical || (Sorting)e == Sorting.NonScalable)
                {
                    continue;
                }
                sortingCombobox.Items.Add(((Sorting)e).GetDescription());
            }
            sortingCombobox.SelectedIndex = 0;
            
            timer1.Enabled = true;
        }
        public async void setupObjects()
        {
            imageList1.Images.Clear();
            tileobjectsListview.Items.Clear();
            await Task.Run(() =>
            {
                foreach (Room_Object o in roomObjects)
                {
                    if (o == null)
                    {
                        continue;
                    }
                    o.setRoom(room);
                    o.DrawOnBitmap();
                    Bitmap tempbitmap = new Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    
                        using (Graphics g = Graphics.FromImage(tempbitmap))
                        {
                            g.DrawImage(o.bitmap, 0, 0);
                        }
                        imageList1.Images.Add(o.id.ToString(),tempbitmap );
                    
                      
                    
                    ListViewItem item = new ListViewItem(o.id.ToString("X3") + "  " + o.name);
                    item.Tag = o.id;
                    item.ImageKey = o.id.ToString();
                    tileobjectsListview.Items.Add(item);

                }
            });

            sortObject();
        }

        public void sortObject()
        {

            tileobjectsListview.BeginUpdate();
            tileobjectsListview.Items.Clear();
            //Sorting sort;
            Sorting sort = EnumEx.GetValueFromDescription<Sorting>(sortingCombobox.SelectedItem.ToString());
            Sorting sortsizing = Sorting.All;
            if (horizontalCheckbox.Checked)
            {
                sortsizing = sortsizing | Sorting.Horizontal;
            }
            if (verticalCheckbox.Checked)
            {
                sortsizing = sortsizing | Sorting.Vertical;
            }
            if (nonscalableCheckbox.Checked)
            {
                sortsizing = sortsizing | Sorting.NonScalable;
            }

            //listView1
            tileobjectsListview.Items.AddRange(roomObjects
                .Where(x => x != null)
                .Where(x => sort == 0 || (x.sort & sort) > 0)
                .Where(x => (x.sort & sortsizing) > 0)
                .Where(x => (x.name.ToLower().Contains(searchText)))
                .OrderBy(x => x.id)
                .Select(x => new ListViewItem(x.id.ToString("X3") + " " + x.name) { ImageKey = x.id.ToString(), Tag = x.id })
                .ToArray());
            tileobjectsListview.EndUpdate();
        }


        public void addObject(short oid, byte x, byte y, byte size, byte layer)
        {
            if (oid <= 0xFF)
            {
                switch (oid)
                {
                    case 0x00:
                        roomObjects.Add(new object_00(oid, x, y, 1, layer));
                        break;
                    case 0x01:
                        roomObjects.Add(new object_01(oid, x, y, 1, layer));
                        break;
                    case 0x02:
                        roomObjects.Add(new object_02(oid, x, y, 1, layer));
                        break;
                    case 0x03:
                        roomObjects.Add(new object_03(oid, x, y, size, layer));
                        break;
                    case 0x04:
                        roomObjects.Add(new object_04(oid, x, y, size, layer));
                        break;
                    case 0x05:
                        roomObjects.Add(new object_05(oid, x, y, size, layer));
                        break;
                    case 0x06:
                        roomObjects.Add(new object_06(oid, x, y, size, layer));
                        break;
                    case 0x07:
                        roomObjects.Add(new object_07(oid, x, y, size, layer));
                        break;
                    case 0x08:
                        roomObjects.Add(new object_08(oid, x, y, size, layer));
                        break;
                    case 0x09:
                        roomObjects.Add(new object_09(oid, x, y, size, layer));
                        break;
                    case 0x0A:
                        roomObjects.Add(new object_0A(oid, x, y, size, layer));
                        break;
                    case 0x0B:
                        roomObjects.Add(new object_0B(oid, x, y, size, layer));
                        break;
                    case 0x0C:
                        roomObjects.Add(new object_0C(oid, x, y, size, layer));
                        break;
                    case 0x0D:
                        roomObjects.Add(new object_0D(oid, x, y, size, layer));
                        break;
                    case 0x0E:
                        roomObjects.Add(new object_0E(oid, x, y, size, layer));
                        break;
                    case 0x0F:
                        roomObjects.Add(new object_0F(oid, x, y, size, layer));
                        break;
                    case 0x10:
                        roomObjects.Add(new object_10(oid, x, y, size, layer));
                        break;
                    case 0x11:
                        roomObjects.Add(new object_11(oid, x, y, size, layer));
                        break;
                    case 0x12:
                        roomObjects.Add(new object_12(oid, x, y, size, layer));
                        break;
                    case 0x13:
                        roomObjects.Add(new object_13(oid, x, y, size, layer));
                        break;
                    case 0x14:
                        roomObjects.Add(new object_14(oid, x, y, size, layer));
                        break;
                    case 0x15:
                        roomObjects.Add(new object_15(oid, x, y, size, layer));
                        break;
                    case 0x16:
                        roomObjects.Add(new object_16(oid, x, y, size, layer));
                        break;
                    case 0x17:
                        roomObjects.Add(new object_17(oid, x, y, size, layer));
                        break;
                    case 0x18:
                        roomObjects.Add(new object_18(oid, x, y, size, layer));
                        break;
                    case 0x19:
                        roomObjects.Add(new object_19(oid, x, y, size, layer));
                        break;
                    case 0x1A:
                        roomObjects.Add(new object_1A(oid, x, y, size, layer));
                        break;
                    case 0x1B:
                        roomObjects.Add(new object_1B(oid, x, y, size, layer));
                        break;
                    case 0x1C:
                        roomObjects.Add(new object_1C(oid, x, y, size, layer));
                        break;
                    case 0x1D:
                        roomObjects.Add(new object_1D(oid, x, y, size, layer));
                        break;
                    case 0x1E:
                        roomObjects.Add(new object_1E(oid, x, y, size, layer));
                        break;
                    case 0x1F:
                        roomObjects.Add(new object_1F(oid, x, y, size, layer));
                        break;
                    case 0x20:
                        roomObjects.Add(new object_20(oid, x, y, size, layer));
                        break;
                    case 0x21:
                        roomObjects.Add(new object_21(oid, x, y, size, layer));
                        break;
                    case 0x22:
                        roomObjects.Add(new object_22(oid, x, y, size, layer));
                        break;
                    case 0x23:
                        roomObjects.Add(new object_23(oid, x, y, size, layer));
                        break;
                    case 0x24:
                        roomObjects.Add(new object_24(oid, x, y, size, layer));
                        break;
                    case 0x25:
                        roomObjects.Add(new object_25(oid, x, y, size, layer));
                        break;
                    case 0x26:
                        roomObjects.Add(new object_26(oid, x, y, size, layer));
                        break;
                    case 0x27:
                        roomObjects.Add(new object_27(oid, x, y, size, layer));
                        break;
                    case 0x28:
                        roomObjects.Add(new object_28(oid, x, y, size, layer));
                        break;
                    case 0x29:
                        roomObjects.Add(new object_29(oid, x, y, size, layer));
                        break;
                    case 0x2A:
                        roomObjects.Add(new object_2A(oid, x, y, size, layer));
                        break;
                    case 0x2B:
                        roomObjects.Add(new object_2B(oid, x, y, size, layer));
                        break;
                    case 0x2C:
                        roomObjects.Add(new object_2C(oid, x, y, size, layer));
                        break;
                    case 0x2D:
                        roomObjects.Add(new object_2D(oid, x, y, size, layer));
                        break;
                    case 0x2E:
                        roomObjects.Add(new object_2E(oid, x, y, size, layer));
                        break;
                    case 0x2F:
                        roomObjects.Add(new object_2F(oid, x, y, size, layer));
                        break;
                    case 0x30:
                        roomObjects.Add(new object_30(oid, x, y, size, layer));
                        break;
                    case 0x31:
                        roomObjects.Add(new object_31(oid, x, y, size, layer));
                        break;
                    case 0x32:
                        roomObjects.Add(new object_32(oid, x, y, size, layer));
                        break;
                    case 0x33:
                        roomObjects.Add(new object_33(oid, x, y, size, layer));
                        break;
                    case 0x34:
                        roomObjects.Add(new object_34(oid, x, y, size, layer));
                        break;
                    case 0x35:
                        roomObjects.Add(new object_35(oid, x, y, size, layer));
                        break;
                    case 0x36:
                        roomObjects.Add(new object_36(oid, x, y, size, layer));
                        break;
                    case 0x37:
                        roomObjects.Add(new object_37(oid, x, y, size, layer));
                        break;
                    case 0x38:
                        roomObjects.Add(new object_38(oid, x, y, size, layer));
                        break;
                    case 0x39:
                        roomObjects.Add(new object_39(oid, x, y, size, layer));
                        break;
                    case 0x3A:
                        roomObjects.Add(new object_3A(oid, x, y, size, layer));
                        break;
                    case 0x3B:
                        roomObjects.Add(new object_3B(oid, x, y, size, layer));
                        break;
                    case 0x3C:
                        roomObjects.Add(new object_3C(oid, x, y, size, layer));
                        break;
                    case 0x3D:
                        roomObjects.Add(new object_3D(oid, x, y, size, layer));
                        break;
                    case 0x3E:
                        roomObjects.Add(new object_3E(oid, x, y, size, layer));
                        break;
                    case 0x3F:
                        roomObjects.Add(new object_3F(oid, x, y, size, layer));
                        break;
                    case 0x40:
                        roomObjects.Add(new object_40(oid, x, y, size, layer));
                        break;
                    case 0x41:
                        roomObjects.Add(new object_41(oid, x, y, size, layer));
                        break;
                    case 0x42:
                        roomObjects.Add(new object_42(oid, x, y, size, layer));
                        break;
                    case 0x43:
                        roomObjects.Add(new object_43(oid, x, y, size, layer));
                        break;
                    case 0x44:
                        roomObjects.Add(new object_44(oid, x, y, size, layer));
                        break;
                    case 0x45:
                        roomObjects.Add(new object_45(oid, x, y, size, layer));
                        break;
                    case 0x46:
                        roomObjects.Add(new object_46(oid, x, y, size, layer));
                        break;
                    case 0x47:
                        roomObjects.Add(new object_47(oid, x, y, size, layer));
                        break;
                    case 0x48:
                        roomObjects.Add(new object_48(oid, x, y, size, layer));
                        break;
                    case 0x49:
                        roomObjects.Add(new object_49(oid, x, y, size, layer));
                        break;
                    case 0x4A:
                        roomObjects.Add(new object_4A(oid, x, y, size, layer));
                        break;
                    case 0x4B:
                        roomObjects.Add(new object_4B(oid, x, y, size, layer));
                        break;
                    case 0x4C:
                        roomObjects.Add(new object_4C(oid, x, y, size, layer));
                        break;
                    case 0x4D:
                        roomObjects.Add(new object_4D(oid, x, y, size, layer));
                        break;
                    case 0x4E:
                        roomObjects.Add(new object_4E(oid, x, y, size, layer));
                        break;
                    case 0x4F:
                        roomObjects.Add(new object_4F(oid, x, y, size, layer));
                        break;
                    case 0x50:
                        roomObjects.Add(new object_50(oid, x, y, size, layer));
                        break;
                    case 0x51:
                        roomObjects.Add(new object_51(oid, x, y, size, layer));
                        break;
                    case 0x52:
                        roomObjects.Add(new object_52(oid, x, y, size, layer));
                        break;
                    case 0x53:
                        roomObjects.Add(new object_53(oid, x, y, size, layer));
                        break;
                    case 0x54:
                        roomObjects.Add(new object_54(oid, x, y, size, layer));
                        break;
                    case 0x55:
                        roomObjects.Add(new object_55(oid, x, y, size, layer));
                        break;
                    case 0x56:
                        roomObjects.Add(new object_56(oid, x, y, size, layer));
                        break;
                    case 0x57:
                        roomObjects.Add(new object_57(oid, x, y, size, layer));
                        break;
                    case 0x58:
                        roomObjects.Add(new object_58(oid, x, y, size, layer));
                        break;
                    case 0x59:
                        roomObjects.Add(new object_59(oid, x, y, size, layer));
                        break;
                    case 0x5A:
                        roomObjects.Add(new object_5A(oid, x, y, size, layer));
                        break;
                    case 0x5B:
                        roomObjects.Add(new object_5B(oid, x, y, size, layer));
                        break;
                    case 0x5C:
                        roomObjects.Add(new object_5C(oid, x, y, size, layer));
                        break;
                    case 0x5D:
                        roomObjects.Add(new object_5D(oid, x, y, size, layer));
                        break;
                    case 0x5E:
                        roomObjects.Add(new object_5E(oid, x, y, size, layer));
                        break;
                    case 0x5F:
                        roomObjects.Add(new object_5F(oid, x, y, size, layer));
                        break;
                    case 0x60:
                        roomObjects.Add(new object_60(oid, x, y, 1, layer));
                        break;
                    case 0x61:
                        roomObjects.Add(new object_61(oid, x, y, 1, layer));
                        break;
                    case 0x62:
                        roomObjects.Add(new object_62(oid, x, y, 1, layer));
                        break;
                    case 0x63:
                        roomObjects.Add(new object_63(oid, x, y, size, layer));
                        break;
                    case 0x64:
                        roomObjects.Add(new object_64(oid, x, y, size, layer));
                        break;
                    case 0x65:
                        roomObjects.Add(new object_65(oid, x, y, size, layer));
                        break;
                    case 0x66:
                        roomObjects.Add(new object_66(oid, x, y, size, layer));
                        break;
                    case 0x67:
                        roomObjects.Add(new object_67(oid, x, y, size, layer));
                        break;
                    case 0x68:
                        roomObjects.Add(new object_68(oid, x, y, size, layer));
                        break;
                    case 0x69:
                        roomObjects.Add(new object_69(oid, x, y, size, layer));
                        break;
                    case 0x6A:
                        roomObjects.Add(new object_6A(oid, x, y, size, layer));
                        break;
                    case 0x6B:
                        roomObjects.Add(new object_6B(oid, x, y, size, layer));
                        break;
                    case 0x6C:
                        roomObjects.Add(new object_6C(oid, x, y, size, layer));
                        break;
                    case 0x6D:
                        roomObjects.Add(new object_6D(oid, x, y, size, layer));
                        break;
                    case 0x6E:
                        roomObjects.Add(new object_6E(oid, x, y, size, layer));
                        break;
                    case 0x6F:
                        roomObjects.Add(new object_6F(oid, x, y, size, layer));
                        break;
                    case 0x70:
                        roomObjects.Add(new object_70(oid, x, y, size, layer));
                        break;
                    case 0x71:
                        roomObjects.Add(new object_71(oid, x, y, size, layer));
                        break;
                    case 0x72:
                        roomObjects.Add(new object_72(oid, x, y, size, layer));
                        break;
                    case 0x73:
                        roomObjects.Add(new object_73(oid, x, y, size, layer));
                        break;
                    case 0x74:
                        roomObjects.Add(new object_74(oid, x, y, size, layer));
                        break;
                    case 0x75:
                        roomObjects.Add(new object_75(oid, x, y, size, layer));
                        break;
                    case 0x76:
                        roomObjects.Add(new object_76(oid, x, y, size, layer));
                        break;
                    case 0x77:
                        roomObjects.Add(new object_77(oid, x, y, size, layer));
                        break;
                    case 0x78:
                        roomObjects.Add(new object_78(oid, x, y, size, layer));
                        break;
                    case 0x79:
                        roomObjects.Add(new object_79(oid, x, y, size, layer));
                        break;
                    case 0x7A:
                        roomObjects.Add(new object_7A(oid, x, y, size, layer));
                        break;
                    case 0x7B:
                        roomObjects.Add(new object_7B(oid, x, y, size, layer));
                        break;
                    case 0x7C:
                        roomObjects.Add(new object_7C(oid, x, y, size, layer));
                        break;
                    case 0x7D:
                        roomObjects.Add(new object_7D(oid, x, y, size, layer));
                        break;
                    case 0x7E:
                        roomObjects.Add(new object_7E(oid, x, y, size, layer));
                        break;
                    case 0x7F:
                        roomObjects.Add(new object_7F(oid, x, y, size, layer));
                        break;
                    case 0x80:
                        roomObjects.Add(new object_80(oid, x, y, size, layer));
                        break;
                    case 0x81:
                        roomObjects.Add(new object_81(oid, x, y, size, layer));
                        break;
                    case 0x82:
                        roomObjects.Add(new object_82(oid, x, y, size, layer));
                        break;
                    case 0x83:
                        roomObjects.Add(new object_83(oid, x, y, size, layer));
                        break;
                    case 0x84:
                        roomObjects.Add(new object_84(oid, x, y, size, layer));
                        break;
                    case 0x85:
                        roomObjects.Add(new object_85(oid, x, y, size, layer));
                        break;
                    case 0x86:
                        roomObjects.Add(new object_86(oid, x, y, size, layer));
                        break;
                    case 0x87:
                        roomObjects.Add(new object_87(oid, x, y, size, layer));
                        break;
                    case 0x88:
                        roomObjects.Add(new object_88(oid, x, y, size, layer));
                        break;
                    case 0x89:
                        roomObjects.Add(new object_89(oid, x, y, size, layer));
                        break;
                    case 0x8A:
                        roomObjects.Add(new object_8A(oid, x, y, size, layer));
                        break;
                    case 0x8B:
                        roomObjects.Add(new object_8B(oid, x, y, size, layer));
                        break;
                    case 0x8C:
                        roomObjects.Add(new object_8C(oid, x, y, size, layer));
                        break;
                    case 0x8D:
                        roomObjects.Add(new object_8D(oid, x, y, size, layer));
                        break;
                    case 0x8E:
                        roomObjects.Add(new object_8E(oid, x, y, size, layer));
                        break;
                    case 0x8F:
                        roomObjects.Add(new object_8F(oid, x, y, size, layer));
                        break;
                    case 0x90:
                        roomObjects.Add(new object_90(oid, x, y, 1, layer));
                        break;
                    case 0x91:
                        roomObjects.Add(new object_91(oid, x, y, 1, layer));
                        break;
                    case 0x92:
                        roomObjects.Add(new object_92(oid, x, y, 1, layer));
                        break;
                    case 0x93:
                        roomObjects.Add(new object_93(oid, x, y, 1, layer));
                        break;
                    case 0x94:
                        roomObjects.Add(new object_94(oid, x, y, size, layer));
                        break;
                    case 0x95:
                        roomObjects.Add(new object_95(oid, x, y, size, layer));
                        break;
                    case 0x96:
                        roomObjects.Add(new object_96(oid, x, y, size, layer));
                        break;
                    case 0x97:
                        roomObjects.Add(new object_97(oid, x, y, size, layer));
                        break;
                    case 0x98:
                        roomObjects.Add(new object_98(oid, x, y, size, layer));
                        break;
                    case 0x99:
                        roomObjects.Add(new object_99(oid, x, y, size, layer));
                        break;
                    case 0x9A:
                        roomObjects.Add(new object_9A(oid, x, y, size, layer));
                        break;
                    case 0x9B:
                        roomObjects.Add(new object_9B(oid, x, y, size, layer));
                        break;
                    case 0x9C:
                        roomObjects.Add(new object_9C(oid, x, y, size, layer));
                        break;
                    case 0x9D:
                        roomObjects.Add(new object_9D(oid, x, y, size, layer));
                        break;
                    case 0x9E:
                        roomObjects.Add(new object_9E(oid, x, y, size, layer));
                        break;
                    case 0x9F:
                        roomObjects.Add(new object_9F(oid, x, y, size, layer));
                        break;
                    case 0xA0:
                        roomObjects.Add(new object_A0(oid, x, y, size, layer));
                        break;
                    case 0xA1:
                        roomObjects.Add(new object_A1(oid, x, y, size, layer));
                        break;
                    case 0xA2:
                        roomObjects.Add(new object_A2(oid, x, y, size, layer));
                        break;
                    case 0xA3:
                        roomObjects.Add(new object_A3(oid, x, y, size, layer));
                        break;
                    case 0xA4:
                        roomObjects.Add(new object_A4(oid, x, y, size, layer));
                        break;
                    case 0xA5:
                        roomObjects.Add(new object_A5(oid, x, y, size, layer));
                        break;
                    case 0xA6:
                        roomObjects.Add(new object_A6(oid, x, y, size, layer));
                        break;
                    case 0xA7:
                        roomObjects.Add(new object_A7(oid, x, y, size, layer));
                        break;
                    case 0xA8:
                        roomObjects.Add(new object_A8(oid, x, y, size, layer));
                        break;
                    case 0xA9:
                        roomObjects.Add(new object_A9(oid, x, y, size, layer));
                        break;
                    case 0xAA:
                        roomObjects.Add(new object_AA(oid, x, y, size, layer));
                        break;
                    case 0xAB:
                        roomObjects.Add(new object_AB(oid, x, y, size, layer));
                        break;
                    case 0xAC:
                        roomObjects.Add(new object_AC(oid, x, y, size, layer));
                        break;
                    case 0xAD:
                        roomObjects.Add(new object_AD(oid, x, y, size, layer));
                        break;
                    case 0xAE:
                        roomObjects.Add(new object_AE(oid, x, y, size, layer));
                        break;
                    case 0xAF:
                        roomObjects.Add(new object_AF(oid, x, y, size, layer));
                        break;
                    case 0xB0:
                        roomObjects.Add(new object_B0(oid, x, y, size, layer));
                        break;
                    case 0xB1:
                        roomObjects.Add(new object_B1(oid, x, y, size, layer));
                        break;
                    case 0xB2:
                        roomObjects.Add(new object_B2(oid, x, y, size, layer));
                        break;
                    case 0xB3:
                        roomObjects.Add(new object_B3(oid, x, y, size, layer));
                        break;
                    case 0xB4:
                        roomObjects.Add(new object_B4(oid, x, y, size, layer));
                        break;
                    case 0xB5:
                        roomObjects.Add(new object_B5(oid, x, y, size, layer));
                        break;
                    case 0xB6:
                        roomObjects.Add(new object_B6(oid, x, y, size, layer));
                        break;
                    case 0xB7:
                        roomObjects.Add(new object_B7(oid, x, y, size, layer));
                        break;
                    case 0xB8:
                        roomObjects.Add(new object_B8(oid, x, y, 1, layer));
                        break;
                    case 0xB9:
                        roomObjects.Add(new object_B9(oid, x, y, 1, layer));
                        break;
                    case 0xBA:
                        roomObjects.Add(new object_BA(oid, x, y, size, layer));
                        break;
                    case 0xBB:
                        roomObjects.Add(new object_BB(oid, x, y, size, layer));
                        break;
                    case 0xBC:
                        roomObjects.Add(new object_BC(oid, x, y, size, layer));
                        break;
                    case 0xBD:
                        roomObjects.Add(new object_BD(oid, x, y, size, layer));
                        break;
                    case 0xBE:
                        roomObjects.Add(new object_BE(oid, x, y, size, layer));
                        break;
                    case 0xBF:
                        roomObjects.Add(new object_BF(oid, x, y, size, layer));
                        break;
                    case 0xC0:
                        roomObjects.Add(new object_C0(oid, x, y, size, layer));
                        break;
                    case 0xC1:
                        roomObjects.Add(new object_C1(oid, x, y, size, layer));
                        break;
                    case 0xC2:
                        roomObjects.Add(new object_C2(oid, x, y, size, layer));
                        break;
                    case 0xC3:
                        roomObjects.Add(new object_C3(oid, x, y, size, layer));
                        break;
                    case 0xC4:
                        roomObjects.Add(new object_C4(oid, x, y, size, layer));
                        break;
                    case 0xC5:
                        roomObjects.Add(new object_C5(oid, x, y, size, layer));
                        break;
                    case 0xC6:
                        roomObjects.Add(new object_C6(oid, x, y, size, layer));
                        break;
                    case 0xC7:
                        roomObjects.Add(new object_C7(oid, x, y, size, layer));
                        break;
                    case 0xC8:
                        roomObjects.Add(new object_C8(oid, x, y, size, layer));
                        break;
                    case 0xC9:
                        roomObjects.Add(new object_C9(oid, x, y, size, layer));
                        break;
                    case 0xCA:
                        roomObjects.Add(new object_CA(oid, x, y, size, layer));
                        break;
                    case 0xCB:
                        roomObjects.Add(new object_CB(oid, x, y, size, layer));
                        break;
                    case 0xCC:
                        roomObjects.Add(new object_CC(oid, x, y, size, layer));
                        break;
                    case 0xCD:
                        roomObjects.Add(new object_CD(oid, x, y, size, layer));
                        break;
                    case 0xCE:
                        roomObjects.Add(new object_CE(oid, x, y, size, layer));
                        break;
                    case 0xCF:
                        roomObjects.Add(new object_CF(oid, x, y, size, layer));
                        break;
                    case 0xD0:
                        roomObjects.Add(new object_D0(oid, x, y, size, layer));
                        break;
                    case 0xD1:
                        roomObjects.Add(new object_D1(oid, x, y, size, layer));
                        break;
                    case 0xD2:
                        roomObjects.Add(new object_D2(oid, x, y, size, layer));
                        break;
                    case 0xD3:
                        roomObjects.Add(new object_D3(oid, x, y, size, layer));
                        break;
                    case 0xD4:
                        roomObjects.Add(new object_D4(oid, x, y, size, layer));
                        break;
                    case 0xD5:
                        roomObjects.Add(new object_D5(oid, x, y, size, layer));
                        break;
                    case 0xD6:
                        roomObjects.Add(new object_D6(oid, x, y, size, layer));
                        break;
                    case 0xD7:
                        roomObjects.Add(new object_D7(oid, x, y, size, layer));
                        break;
                    case 0xD8:
                        roomObjects.Add(new object_D8(oid, x, y, size, layer));
                        break;
                    case 0xD9:
                        roomObjects.Add(new object_D9(oid, x, y, size, layer));
                        break;
                    case 0xDA:
                        roomObjects.Add(new object_DA(oid, x, y, size, layer));
                        break;
                    case 0xDB:
                        roomObjects.Add(new object_DB(oid, x, y, size, layer));
                        break;
                    case 0xDC:
                        roomObjects.Add(new object_DC(oid, x, y, size, layer));
                        break;
                    case 0xDD:
                        roomObjects.Add(new object_DD(oid, x, y, size, layer));
                        break;
                    case 0xDE:
                        roomObjects.Add(new object_DE(oid, x, y, size, layer));
                        break;
                    case 0xDF:
                        roomObjects.Add(new object_DF(oid, x, y, size, layer));
                        break;
                    case 0xE0:
                        roomObjects.Add(new object_E0(oid, x, y, size, layer));
                        break;
                    case 0xE1:
                        roomObjects.Add(new object_E1(oid, x, y, size, layer));
                        break;
                    case 0xE2:
                        roomObjects.Add(new object_E2(oid, x, y, size, layer));
                        break;
                    case 0xE3:
                        roomObjects.Add(new object_E3(oid, x, y, size, layer));
                        break;
                    case 0xE4:
                        roomObjects.Add(new object_E4(oid, x, y, size, layer));
                        break;
                    case 0xE5:
                        roomObjects.Add(new object_E5(oid, x, y, size, layer));
                        break;
                    case 0xE6:
                        roomObjects.Add(new object_E6(oid, x, y, size, layer));
                        break;
                    case 0xE7:
                        roomObjects.Add(new object_E7(oid, x, y, size, layer));
                        break;
                    case 0xE8:
                        roomObjects.Add(new object_E8(oid, x, y, size, layer));
                        break;
                    case 0xE9:
                        roomObjects.Add(new object_E9(oid, x, y, size, layer));
                        break;
                    case 0xEA:
                        roomObjects.Add(new object_EA(oid, x, y, size, layer));
                        break;
                    case 0xEB:
                        roomObjects.Add(new object_EB(oid, x, y, size, layer));
                        break;
                    case 0xEC:
                        roomObjects.Add(new object_EC(oid, x, y, size, layer));
                        break;
                    case 0xED:
                        roomObjects.Add(new object_ED(oid, x, y, size, layer));
                        break;
                    case 0xEE:
                        roomObjects.Add(new object_EE(oid, x, y, size, layer));
                        break;
                    case 0xEF:
                        roomObjects.Add(new object_EF(oid, x, y, size, layer));
                        break;
                }
            }
            else
            {
                if (oid == 0xE00) //Block
                {
                    roomObjects.Add(new object_Block(oid, x, y, 0, layer));
                }


                if ((oid & 0xF00) == 0xF00) //subtype 3
                {
                    switch (oid)
                    {
                        case 0xF80:
                            roomObjects.Add(new object_F80(oid, x, y, size, layer));
                            break;
                        case 0xF81:
                            roomObjects.Add(new object_F81(oid, x, y, size, layer));
                            break;
                        case 0xF82:
                            roomObjects.Add(new object_F82(oid, x, y, size, layer));
                            break;
                        case 0xF83:
                            roomObjects.Add(new object_F83(oid, x, y, size, layer));
                            break;
                        case 0xF84:
                            roomObjects.Add(new object_F84(oid, x, y, size, layer));
                            break;
                        case 0xF85:
                            roomObjects.Add(new object_F85(oid, x, y, size, layer));
                            break;
                        case 0xF86:
                            roomObjects.Add(new object_F86(oid, x, y, size, layer));
                            break;
                        case 0xF87:
                            roomObjects.Add(new object_F87(oid, x, y, size, layer));
                            break;
                        case 0xF88:
                            roomObjects.Add(new object_F88(oid, x, y, size, layer));
                            break;
                        case 0xF89:
                            roomObjects.Add(new object_F89(oid, x, y, size, layer));
                            break;
                        case 0xF8A:
                            roomObjects.Add(new object_F8A(oid, x, y, size, layer));
                            break;
                        case 0xF8B:
                            roomObjects.Add(new object_F8B(oid, x, y, size, layer));
                            break;
                        case 0xF8C:
                            roomObjects.Add(new object_F8C(oid, x, y, size, layer));
                            break;
                        case 0xF8D:
                            roomObjects.Add(new object_F8D(oid, x, y, size, layer));
                            break;
                        case 0xF8E:
                            roomObjects.Add(new object_F8E(oid, x, y, size, layer));
                            break;
                        case 0xF8F:
                            roomObjects.Add(new object_F8F(oid, x, y, size, layer));
                            break;
                        case 0xF90:
                            roomObjects.Add(new object_F90(oid, x, y, size, layer));
                            break;
                        case 0xF91:
                            roomObjects.Add(new object_F91(oid, x, y, size, layer));
                            break;
                        case 0xF92:
                            roomObjects.Add(new object_F92(oid, x, y, size, layer));
                            break;
                        case 0xF93:
                            roomObjects.Add(new object_F93(oid, x, y, size, layer));
                            break;
                        case 0xF94:
                            roomObjects.Add(new object_F94(oid, x, y, size, layer));
                            break;
                        case 0xF95:
                            roomObjects.Add(new object_F95(oid, x, y, size, layer));
                            break;
                        case 0xF96:
                            roomObjects.Add(new object_F96(oid, x, y, size, layer));
                            break;
                        case 0xF97:
                            roomObjects.Add(new object_F97(oid, x, y, size, layer));
                            break;
                        case 0xF98:
                            roomObjects.Add(new object_F98(oid, x, y, size, layer));
                            break;
                        case 0xF99:
                            roomObjects.Add(new object_F99(oid, x, y, size, layer));
                            break;
                        case 0xF9A:
                            roomObjects.Add(new object_F9A(oid, x, y, size, layer));
                            break;
                        case 0xF9B:
                            roomObjects.Add(new object_F9B(oid, x, y, size, layer));
                            break;
                        case 0xF9C:
                            roomObjects.Add(new object_F9C(oid, x, y, size, layer));
                            break;
                        case 0xF9D:
                            roomObjects.Add(new object_F9D(oid, x, y, size, layer));
                            break;
                        case 0xF9E:
                            roomObjects.Add(new object_F9E(oid, x, y, size, layer));
                            break;
                        case 0xF9F:
                            roomObjects.Add(new object_F9F(oid, x, y, size, layer));
                            break;
                        case 0xFA0:
                            roomObjects.Add(new object_FA0(oid, x, y, size, layer));
                            break;
                        case 0xFA1:
                            roomObjects.Add(new object_FA1(oid, x, y, size, layer));
                            break;
                        case 0xFA2:
                            roomObjects.Add(new object_FA2(oid, x, y, size, layer));
                            break;
                        case 0xFA3:
                            roomObjects.Add(new object_FA3(oid, x, y, size, layer));
                            break;
                        case 0xFA4:
                            roomObjects.Add(new object_FA4(oid, x, y, size, layer));
                            break;
                        case 0xFA5:
                            roomObjects.Add(new object_FA5(oid, x, y, size, layer));
                            break;
                        case 0xFA6:
                            roomObjects.Add(new object_FA6(oid, x, y, size, layer));
                            break;
                        case 0xFA7:
                            roomObjects.Add(new object_FA7(oid, x, y, size, layer));
                            break;
                        case 0xFA8:
                            roomObjects.Add(new object_FA8(oid, x, y, size, layer));
                            break;
                        case 0xFA9:
                            roomObjects.Add(new object_FA9(oid, x, y, size, layer));
                            break;
                        case 0xFAA:
                            roomObjects.Add(new object_FAA(oid, x, y, size, layer));
                            break;
                        case 0xFAB:
                            roomObjects.Add(new object_FAB(oid, x, y, size, layer));
                            break;
                        case 0xFAC:
                            roomObjects.Add(new object_FAC(oid, x, y, size, layer));
                            break;
                        case 0xFAD:
                            roomObjects.Add(new object_FAD(oid, x, y, size, layer));
                            break;
                        case 0xFAE:
                            roomObjects.Add(new object_FAE(oid, x, y, size, layer));
                            break;
                        case 0xFAF:
                            roomObjects.Add(new object_FAF(oid, x, y, size, layer));
                            break;
                        case 0xFB0:
                            roomObjects.Add(new object_FB0(oid, x, y, size, layer));
                            break;
                        case 0xFB1:
                            roomObjects.Add(new object_FB1(oid, x, y, size, layer));
                            break;
                        case 0xFB2:
                            roomObjects.Add(new object_FB2(oid, x, y, size, layer));
                            break;
                        case 0xFB3:
                            roomObjects.Add(new object_FB3(oid, x, y, size, layer));
                            break;
                        case 0xFB4:
                            roomObjects.Add(new object_FB4(oid, x, y, size, layer));
                            break;
                        case 0xFB5:
                            roomObjects.Add(new object_FB5(oid, x, y, size, layer));
                            break;
                        case 0xFB6:
                            roomObjects.Add(new object_FB6(oid, x, y, size, layer));
                            break;
                        case 0xFB7:
                            roomObjects.Add(new object_FB7(oid, x, y, size, layer));
                            break;
                        case 0xFB8:
                            roomObjects.Add(new object_FB8(oid, x, y, size, layer));
                            break;
                        case 0xFB9:
                            roomObjects.Add(new object_FB9(oid, x, y, size, layer));
                            break;
                        case 0xFBA:
                            roomObjects.Add(new object_FBA(oid, x, y, size, layer));
                            break;
                        case 0xFBB:
                            roomObjects.Add(new object_FBA(oid, x, y, size, layer));
                            break;
                        case 0xFBC:
                            roomObjects.Add(new object_FBC(oid, x, y, size, layer));
                            break;
                        case 0xFBD:
                            roomObjects.Add(new object_FBD(oid, x, y, size, layer));
                            break;
                        case 0xFBE:
                            roomObjects.Add(new object_FBE(oid, x, y, size, layer));
                            break;
                        case 0xFBF:
                            roomObjects.Add(new object_FBF(oid, x, y, size, layer));
                            break;
                        case 0xFC0:
                            roomObjects.Add(new object_FC0(oid, x, y, size, layer));
                            break;
                        case 0xFC1:
                            roomObjects.Add(new object_FC1(oid, x, y, size, layer));
                            break;
                        case 0xFC2:
                            roomObjects.Add(new object_FC2(oid, x, y, size, layer));
                            break;
                        case 0xFC3:
                            roomObjects.Add(new object_FC3(oid, x, y, size, layer));
                            break;
                        case 0xFC4:
                            roomObjects.Add(new object_FC4(oid, x, y, size, layer));
                            break;
                        case 0xFC5:
                            roomObjects.Add(new object_FC5(oid, x, y, size, layer));
                            break;
                        case 0xFC6:
                            roomObjects.Add(new object_FC6(oid, x, y, size, layer));
                            break;
                        case 0xFC7:
                            roomObjects.Add(new object_FC7(oid, x, y, size, layer));
                            break;
                        case 0xFC8:
                            roomObjects.Add(new object_FC8(oid, x, y, size, layer));
                            break;
                        case 0xFC9:
                            roomObjects.Add(new object_FC9(oid, x, y, size, layer));
                            break;
                        case 0xFCA:
                            roomObjects.Add(new object_FCA(oid, x, y, size, layer));
                            break;
                        case 0xFCB:
                            roomObjects.Add(new object_FCB(oid, x, y, size, layer));
                            break;
                        case 0xFCC:
                            roomObjects.Add(new object_FCC(oid, x, y, size, layer));
                            break;
                        case 0xFCD:
                            roomObjects.Add(new object_FCD(oid, x, y, size, layer));
                            break;
                        case 0xFCE:
                            roomObjects.Add(new object_FCE(oid, x, y, size, layer));
                            break;
                        case 0xFCF:
                            roomObjects.Add(new object_FCF(oid, x, y, size, layer));
                            break;
                        case 0xFD0:
                            roomObjects.Add(new object_FD0(oid, x, y, size, layer));
                            break;
                        case 0xFD1:
                            roomObjects.Add(new object_FD1(oid, x, y, size, layer));
                            break;
                        case 0xFD2:
                            roomObjects.Add(new object_FD2(oid, x, y, size, layer));
                            break;
                        case 0xFD3:
                            roomObjects.Add(new object_FD3(oid, x, y, size, layer));
                            break;
                        case 0xFD4:
                            roomObjects.Add(new object_FD4(oid, x, y, size, layer));
                            break;
                        case 0xFD5:
                            roomObjects.Add(new object_FD5(oid, x, y, size, layer));
                            break;
                        case 0xFD6:
                            roomObjects.Add(new object_FD6(oid, x, y, size, layer));
                            break;
                        case 0xFD7:
                            roomObjects.Add(new object_FD7(oid, x, y, size, layer));
                            break;
                        case 0xFD8:
                            roomObjects.Add(new object_FD8(oid, x, y, size, layer));
                            break;
                        case 0xFD9:
                            roomObjects.Add(new object_FD9(oid, x, y, size, layer));
                            break;
                        case 0xFDA:
                            roomObjects.Add(new object_FDA(oid, x, y, size, layer));
                            break;
                        case 0xFDB:
                            roomObjects.Add(new object_FDB(oid, x, y, size, layer));
                            break;
                        case 0xFDC:
                            roomObjects.Add(new object_FDC(oid, x, y, size, layer));
                            break;
                        case 0xFDD:
                            roomObjects.Add(new object_FDD(oid, x, y, size, layer));
                            break;
                        case 0xFDE:
                            roomObjects.Add(new object_FDE(oid, x, y, size, layer));
                            break;
                        case 0xFDF:
                            roomObjects.Add(new object_FDF(oid, x, y, size, layer));
                            break;
                        case 0xFE0:
                            roomObjects.Add(new object_FE0(oid, x, y, size, layer));
                            break;
                        case 0xFE1:
                            roomObjects.Add(new object_FE1(oid, x, y, size, layer));
                            break;
                        case 0xFE2:
                            roomObjects.Add(new object_FE2(oid, x, y, size, layer));
                            break;
                        case 0xFE3:
                            roomObjects.Add(new object_FE3(oid, x, y, size, layer));
                            break;
                        case 0xFE4:
                            roomObjects.Add(new object_FE4(oid, x, y, size, layer));
                            break;
                        case 0xFE5:
                            roomObjects.Add(new object_FE5(oid, x, y, size, layer));
                            break;
                        case 0xFE6:
                            roomObjects.Add(new object_FE6(oid, x, y, size, layer));
                            break;
                        case 0xFE7:
                            roomObjects.Add(new object_FE7(oid, x, y, size, layer));
                            break;
                        case 0xFE8:
                            roomObjects.Add(new object_FE8(oid, x, y, size, layer));
                            break;
                        case 0xFE9:
                            roomObjects.Add(new object_FE9(oid, x, y, size, layer));
                            break;
                        case 0xFEA:
                            roomObjects.Add(new object_FEA(oid, x, y, size, layer));
                            break;
                        case 0xFEB:
                            roomObjects.Add(new object_FEB(oid, x, y, size, layer));
                            break;
                        case 0xFEC:
                            roomObjects.Add(new object_FEC(oid, x, y, size, layer));
                            break;
                        case 0xFED:
                            roomObjects.Add(new object_FED(oid, x, y, size, layer));
                            break;
                        case 0xFEE:
                            roomObjects.Add(new object_FEE(oid, x, y, size, layer));
                            break;
                        case 0xFEF:
                            roomObjects.Add(new object_FEF(oid, x, y, size, layer));
                            break;
                        case 0xFF0:
                            roomObjects.Add(new object_FF0(oid, x, y, size, layer));
                            break;
                        case 0xFF1:
                            roomObjects.Add(new object_FF1(oid, x, y, size, layer));
                            break;
                        case 0xFF2:
                            roomObjects.Add(new object_FF2(oid, x, y, size, layer));
                            break;
                        case 0xFF3:
                            roomObjects.Add(new object_FF3(oid, x, y, size, layer));
                            break;
                        case 0xFF4:
                            roomObjects.Add(new object_FF4(oid, x, y, size, layer));
                            break;
                        case 0xFF5:
                            roomObjects.Add(new object_FF5(oid, x, y, size, layer));
                            break;
                    }
                }
                //subtype2
                else if ((oid & 0x100) == 0x100) //subtype2? non scalable
                {
                    roomObjects.Add(new Subtype2_Multiple(oid, x, y, 0, layer));
                }

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
             pictureBox1.Image = new Bitmap(256, 256);
             using (Graphics g = Graphics.FromImage(pictureBox1.Image))
             {
                
                 g.Clear(Color.Azure);
                 if (tileobjectsListview.SelectedItems.Count > 0)
                 {
                     if (tileobjectsListview.SelectedItems[0] != null)
                     {
                        Room_Object o = roomObjects.Find(x => x.id == (short)tileobjectsListview.SelectedItems[0].Tag);
                        o.setRoom(room);
                        o.resetSize();
                        o.get_scroll_x();
                        o.get_scroll_y();
                        o.DrawOnBitmap();
                        g.DrawImage(o.bitmap, 128 - (o.bitmap.Width / 2), 128 - (o.bitmap.Height / 2));
                     }
                 }
             }

            //o.setRoom(room);
            //o.DrawOnBitmap();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //setupObjects();
            //timer1.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sortObject();
        }
        public short selectedObject = -1;
        private void okButton_Click(object sender, EventArgs e)
        {
            if (tileobjectsListview.SelectedItems.Count > 0)
            {
                selectedObject = (short)tileobjectsListview.SelectedItems[0].Tag;
                this.Close();
            }
            else
            {
                MessageBox.Show("You must select an object");
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string searchText = "";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchText = textBox1.Text.ToLower();
            sortObject();
        }
    }
}
