namespace ZeldaFullEditor.Utility
{
	/// <summary>
	/// Marks static fields and properties that are to be discovered by reflection for listing.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	internal sealed class PredefinedInstanceAttribute : Attribute
	{
	}
}
