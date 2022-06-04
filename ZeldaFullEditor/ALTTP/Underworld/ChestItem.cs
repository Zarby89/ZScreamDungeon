namespace ZeldaFullEditor.ALTTP.Underworld
{
	public class ChestItem : IDelegatedDraw, ITypeID, IDrawableSprite
	{
		public ItemReceipt ReceiptType { get; set; }

		public int RealX => AssociatedChest?.RealX ?? 0;
		public int RealY => AssociatedChest?.RealY ?? 0;

		public bool IsAssociated => AssociatedChest != null;

		public byte ID => ReceiptType?.ID ?? 0xFF;
		public int TypeID => ReceiptType?.ID ?? -1;

		public RoomObject AssociatedChest { get; set; }

		public ChestItem(ItemReceipt s)
		{
			ReceiptType = s;
		}

		public void Draw(IDrawArt art)
		{
			ReceiptType.Draw(art, this);
		}
	}
}
