namespace ZeldaFullEditor.UserInterface.UIControl
{
	public interface IPreview
	{
		public string Name { get; }
		public ImmutableArray<SearchCategory> Categories { get; }

		public object EntityType { get; }
	}
}
