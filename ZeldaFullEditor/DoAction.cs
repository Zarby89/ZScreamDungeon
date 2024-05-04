using System.Collections.Generic;
using System.Windows.Forms;

namespace ZeldaFullEditor
{
    public class DoAction
    {
        public ActionType type;
        public object[] parameters;
        public string Name { get; set; } // Used to display name in action list

        public DoAction(ActionType type, object[] parameters)
        {
            this.type = type;
            this.parameters = parameters;
            if (type == ActionType.Delete) // parameters = Object[], position in array
            {
                if (parameters[0] is Sprite[]) // Deleted sprites
                {
                    if ((parameters[0] as Sprite[]).Length == 1)
                    {
                        Name = "Sprite[" + (parameters[0] as Sprite[])[0].id + "]" + "Deleted from position : " + (parameters[1] as int[])[0].ToString();
                    }
                    else
                    {
                        Name = "Group of sprites deleted";
                    }
                }
            }
            else if (type == ActionType.Move) // parameters = Object[],old_x,old_y
            {
                if (parameters[0] is Sprite[]) // Deleted sprites
                {
                    if ((parameters[0] as Sprite[]).Length == 1)
                    {
                        Name = "Sprite[" + (parameters[0] as Sprite[])[0].id + "]" + "Moved from position : X:" + (parameters[1] as int[])[0].ToString() + ",Y:" + (parameters[2] as int[])[0].ToString();
                    }
                    else
                    {
                        Name = "Group of sprites moved";
                    }
                }
            }
            else if (type == ActionType.Change)
            {
                if ((parameters[0] as Sprite[]).Length == 1)
                {
                    Name = "Sprite[" + (parameters[0] as Sprite[])[0].id + "]" + "Changed to ID : :" + (parameters[1] as int[])[0].ToString();
                }
                else
                {
                    Name = "Group of sprites changed ID";
                }
            }
        }

        public void undo(Room room, List<DoAction> tempAction)
        {
            if (type == ActionType.Delete)
            {
                if (parameters[0] is Sprite[]) // Deleted sprites
                {
                    for (int i = 0; i < (parameters[0] as Sprite[]).Length; i++)
                    {
                        room.sprites.Insert((parameters[1] as int[])[i], (parameters[0] as Sprite[])[i]);
                    }
                }
                else if (parameters[0] is PotItem[]) // Deleted sprites
                {
                    for (int i = 0; i < (parameters[0] as PotItem[]).Length; i++)
                    {
                        room.pot_items.Insert((parameters[1] as int[])[i], (parameters[0] as PotItem[])[i]);
                    }
                }
                else if (parameters[0] is Room_Object[]) // Deleted sprites
                {
                    for (int i = 0; i < (parameters[0] as Room_Object[]).Length; i++)
                    {
                        room.tilesObjects.Insert((parameters[1] as int[])[i], (parameters[0] as Room_Object[])[i]);
                    }
                }
            }
            else if (type == ActionType.Move)
            {
                if (parameters[0] is Sprite[]) // Moved sprites
                {
                    for (int i = 0; i < (parameters[0] as Sprite[]).Length; i++)
                    {
                        int new_old_x = (parameters[0] as Sprite[])[i].x;
                        int new_old_y = (parameters[0] as Sprite[])[i].y;
                        (parameters[0] as Sprite[])[i].x = (byte)(parameters[1] as int[])[i]; // return to old_x
                        (parameters[0] as Sprite[])[i].y = (byte)(parameters[2] as int[])[i]; // return to old_y
                        (parameters[0] as Sprite[])[i].nx = (parameters[0] as Sprite[])[i].x;
                        (parameters[0] as Sprite[])[i].ny = (parameters[0] as Sprite[])[i].y;
                        (parameters[1] as int[])[i] = new_old_x; // Set them to oldpos for the redo function
                        (parameters[2] as int[])[i] = new_old_y; // Set them to oldpos for the redo function
                    }
                }
                else if (parameters[0] is PotItem[]) // Moved sprites
                {
                    for (int i = 0; i < (parameters[0] as PotItem[]).Length; i++)
                    {
                        int new_old_x = (parameters[0] as PotItem[])[i].x;
                        int new_old_y = (parameters[0] as PotItem[])[i].y;
                        (parameters[0] as PotItem[])[i].x = (byte)(parameters[1] as int[])[i]; // return to old_x
                        (parameters[0] as PotItem[])[i].y = (byte)(parameters[2] as int[])[i]; // return to old_y
                        (parameters[0] as PotItem[])[i].nx = (parameters[0] as PotItem[])[i].x;
                        (parameters[0] as PotItem[])[i].ny = (parameters[0] as PotItem[])[i].y;
                        (parameters[1] as int[])[i] = new_old_x; // Set them to oldpos for the redo function
                        (parameters[2] as int[])[i] = new_old_y; // Set them to oldpos for the redo function
                    }
                }
                else if (parameters[0] is Room_Object[]) // Moved tiles
                {
                    for (int i = 0; i < (parameters[0] as Room_Object[]).Length; i++)
                    {
                        int new_old_x = (parameters[0] as Room_Object[])[i].X;
                        int new_old_y = (parameters[0] as Room_Object[])[i].Y;
                        (parameters[0] as Room_Object[])[i].X = (byte)(parameters[1] as int[])[i]; // return to old_x
                        (parameters[0] as Room_Object[])[i].Y = (byte)(parameters[2] as int[])[i]; // return to old_y
                        (parameters[0] as Room_Object[])[i].nx = (byte)(parameters[1] as int[])[i];
                        (parameters[0] as Room_Object[])[i].ny = (byte)(parameters[2] as int[])[i];
                        (parameters[1] as int[])[i] = new_old_x; // Set them to oldpos for the redo function
                        (parameters[2] as int[])[i] = new_old_y; // Set them to oldpos for the redo function
                    }
                }
            }
            else if (type == ActionType.Change)
            {
                if (parameters[0] is Sprite[]) // Changed sprites
                {
                    for (int i = 0; i < (parameters[0] as Sprite[]).Length; i++)
                    {
                        int new_old_id = (parameters[0] as Sprite[])[i].id;
                        (parameters[0] as Sprite[])[i].id = (byte)(parameters[1] as int[])[i]; // return to old_x
                        (parameters[1] as int[])[i] = new_old_id; // Set them to oldid for the undo function
                        (parameters[0] as Sprite[])[i].updateBBox();
                    }
                }
                else if (parameters[0] is PotItem[]) // Changed sprites
                {
                    for (int i = 0; i < (parameters[0] as PotItem[]).Length; i++)
                    {
                        int new_old_id = (parameters[0] as PotItem[])[i].id;
                        (parameters[0] as PotItem[])[i].id = (byte)(parameters[1] as int[])[i]; // return to old_x
                        (parameters[1] as int[])[i] = new_old_id; // Set them to oldid for the undo function
                    }
                }
                else if (parameters[0] is Room_Object[]) //changed sprites
                {
                    for (int i = 0; i < (parameters[0] as Room_Object[]).Length; i++)
                    {
                        int new_old_id = (parameters[0] as Room_Object[])[i].id;
                        (parameters[0] as Room_Object[])[i].id = (byte)(parameters[1] as int[])[i]; // return to old_x
                        (parameters[1] as int[])[i] = new_old_id; // Set them to oldid for the undo function
                    }
                }
            }
            else if (type == ActionType.Add)
            {
                if (parameters[0] is Sprite[]) // Changed sprites
                {
                    for (int i = 0; i < (parameters[0] as Sprite[]).Length; i++)
                    {
                        room.sprites.Remove((parameters[0] as Sprite[])[i]);
                    }
                }
                else if (parameters[0] is PotItem[]) // Changed sprites
                {
                    for (int i = 0; i < (parameters[0] as PotItem[]).Length; i++)
                    {
                        room.pot_items.Remove((parameters[0] as PotItem[])[i]);
                    }
                }
                else if (parameters[0] is Room_Object[]) // Changed sprites
                {
                    for (int i = 0; i < (parameters[0] as Room_Object[]).Length; i++)
                    {
                        room.tilesObjects.Remove((parameters[0] as Room_Object[])[i]);
                    }
                }
            }

            tempAction.Insert(0, new DoAction(type, parameters));
        }

        public void redo(Room room, ListBox actionlist)
        {
            if (type == ActionType.Delete)
            {
                if (parameters[0] is Sprite[]) // Deleted sprites
                {
                    for (int i = 0; i < (parameters[0] as Sprite[]).Length; i++)
                    {
                        room.sprites.Remove((parameters[0] as Sprite[])[i]);
                    }
                }
                else if (parameters[0] is PotItem[])
                {
                    for (int i = 0; i < (parameters[0] as PotItem[]).Length; i++)
                    {
                        room.pot_items.Remove((parameters[0] as PotItem[])[i]);
                    }
                }
                else if (parameters[0] is Room_Object[])
                {
                    for (int i = 0; i < (parameters[0] as Room_Object[]).Length; i++)
                    {
                        room.tilesObjects.Remove((parameters[0] as Room_Object[])[i]);
                    }
                }
            }
            else if (type == ActionType.Move)
            {
                if (parameters[0] is Sprite[]) // Moved sprites
                {
                    for (int i = 0; i < (parameters[0] as Sprite[]).Length; i++)
                    {
                        int new_old_x = (parameters[0] as Sprite[])[i].x;
                        int new_old_y = (parameters[0] as Sprite[])[i].y;
                        (parameters[0] as Sprite[])[i].x = (byte)(parameters[1] as int[])[i]; // return to old_x
                        (parameters[0] as Sprite[])[i].y = (byte)(parameters[2] as int[])[i]; // return to old_y
                        (parameters[0] as Sprite[])[i].nx = (parameters[0] as Sprite[])[i].x;
                        (parameters[0] as Sprite[])[i].ny = (parameters[0] as Sprite[])[i].y;
                        (parameters[1] as int[])[i] = new_old_x; // Set them to oldpos for the undo function
                        (parameters[2] as int[])[i] = new_old_y; // Set them to oldpos for the undo function
                    }
                }
                else if (parameters[0] is PotItem[]) // Moved sprites
                {
                    for (int i = 0; i < (parameters[0] as PotItem[]).Length; i++)
                    {
                        int new_old_x = (parameters[0] as PotItem[])[i].x;
                        int new_old_y = (parameters[0] as PotItem[])[i].y;
                        (parameters[0] as PotItem[])[i].x = (byte)(parameters[1] as int[])[i]; // return to old_x
                        (parameters[0] as PotItem[])[i].y = (byte)(parameters[2] as int[])[i]; // return to old_y
                        (parameters[0] as PotItem[])[i].nx = (parameters[0] as PotItem[])[i].x;
                        (parameters[0] as PotItem[])[i].ny = (parameters[0] as PotItem[])[i].y;
                        (parameters[1] as int[])[i] = new_old_x; // Set them to oldpos for the undo function
                        (parameters[2] as int[])[i] = new_old_y; // Set them to oldpos for the undo function
                    }
                }
                else if (parameters[0] is Room_Object[]) // Moved sprites
                {
                    for (int i = 0; i < (parameters[0] as Room_Object[]).Length; i++)
                    {
                        int new_old_x = (parameters[0] as Room_Object[])[i].X;
                        int new_old_y = (parameters[0] as Room_Object[])[i].Y;
                        (parameters[0] as Room_Object[])[i].X = (byte)(parameters[1] as int[])[i]; // return to old_x
                        (parameters[0] as Room_Object[])[i].Y = (byte)(parameters[2] as int[])[i]; // return to old_y
                        (parameters[0] as Room_Object[])[i].nx = (parameters[0] as Room_Object[])[i].X;
                        (parameters[0] as Room_Object[])[i].ny = (parameters[0] as Room_Object[])[i].Y;
                        (parameters[1] as int[])[i] = new_old_x; // set them to oldpos for the undo function
                        (parameters[2] as int[])[i] = new_old_y; // set them to oldpos for the undo function
                    }
                }
            }
            else if (type == ActionType.Change)
            {
                if (parameters[0] is Sprite[]) // changed sprites
                {
                    for (int i = 0; i < (parameters[0] as Sprite[]).Length; i++)
                    {
                        int new_old_id = (parameters[0] as Sprite[])[i].id;
                        (parameters[0] as Sprite[])[i].id = (byte)(parameters[1] as int[])[i]; // return to old_x
                        (parameters[1] as int[])[i] = new_old_id; // Set them to oldid for the undo function
                        (parameters[0] as Sprite[])[i].updateBBox();
                    }
                }
                else if (parameters[0] is PotItem[]) // Changed sprites
                {
                    for (int i = 0; i < (parameters[0] as PotItem[]).Length; i++)
                    {
                        int new_old_id = (parameters[0] as PotItem[])[i].id;
                        (parameters[0] as PotItem[])[i].id = (byte)(parameters[1] as int[])[i]; // return to old_x
                        (parameters[1] as int[])[i] = new_old_id; // Set them to oldid for the undo function
                                                                  //(parameters[0] as PotItem[])[i].updateBBox();
                    }
                }
                else if (parameters[0] is Room_Object[]) // Changed sprites
                {
                    for (int i = 0; i < (parameters[0] as Room_Object[]).Length; i++)
                    {
                        int new_old_id = (parameters[0] as Room_Object[])[i].id;
                        (parameters[0] as Room_Object[])[i].id = (byte)(parameters[1] as int[])[i]; // return to old_x
                        (parameters[1] as int[])[i] = new_old_id; // Set them to oldid for the undo function
                                                                  //(parameters[0] as PotItem[])[i].updateBBox();
                    }
                }
            }
            else if (type == ActionType.Add)
            {
                if (parameters[0] is Sprite[]) // Changed sprites
                {
                    for (int i = 0; i < (parameters[0] as Sprite[]).Length; i++)
                    {
                        room.sprites.Add((parameters[0] as Sprite[])[i]);
                    }
                }
                else if (parameters[0] is PotItem[]) // Added pot item
                {
                    for (int i = 0; i < (parameters[0] as PotItem[]).Length; i++)
                    {
                        room.pot_items.Add((parameters[0] as PotItem[])[i]);
                    }
                }
                else if (parameters[0] is Room_Object[]) // Sdded pot item
                {
                    for (int i = 0; i < (parameters[0] as Room_Object[]).Length; i++)
                    {
                        room.tilesObjects.Add((parameters[0] as Room_Object[])[i]);
                    }
                }
            }

            actionlist.Items.Add(new DoAction(type, parameters));
        }
    }

    public enum ActionType
    {
        Move, Delete, Add, Change, Resize
    }
}
