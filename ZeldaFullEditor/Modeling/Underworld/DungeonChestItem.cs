using ZeldaFullEditor.View.Drawing;
using ZeldaFullEditor.View.Drawing.Artists;

namespace ZeldaFullEditor.Modeling.Underworld
{
	public class DungeonChestItem : IDelegatedDraw, ITypeID, IDrawableSprite
	{
		public ItemReceipt ReceiptType { get; set; }

		public int RealX => AssociatedChest?.RealX ?? 0;
		public int RealY => AssociatedChest?.RealY ?? 0;

		public bool IsAssociated => AssociatedChest != null;

		public byte ID => ReceiptType?.ID ?? 0xFF;
		public int TypeID => ReceiptType?.ID ?? -1;

		public RoomObject AssociatedChest { get; set; }

		public DungeonChestItem(ItemReceipt s)
		{
			ReceiptType = s;
		}

		public void Draw(Artist art)
		{
			ReceiptType.Draw(art, this);
		}
	}
}
