namespace ZeldaFullEditor.Modeling.Underworld
{
	public class RoomDestination
	{
		public byte Index { get; }
		public byte Target { get; set; } = 0;
		public byte TargetLayer { get; set; } = 0;

		public RoomObject AssociatedObject { get; set; } = null;
		public bool IsAssociated => AssociatedObject != null;

		public int RealX => AssociatedObject?.RealX ?? 0;
		public int RealY => AssociatedObject?.RealY ?? 0;

		public RoomDestination(byte i)
		{
			Index = i;
		}

		public void Reset()
		{
			AssociatedObject = null;
		}

		public override string ToString() => $"{Index}: To {Target:X2}";
	}
}
