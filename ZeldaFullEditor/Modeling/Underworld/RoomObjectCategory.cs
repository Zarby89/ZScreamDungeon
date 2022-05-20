namespace ZeldaFullEditor.Modeling.Underworld
{
	public enum RoomObjectCategory
	{
		/// <summary>
		/// This object does not contain any solid collision.
		/// </summary>
		NoCollision,

		/// <summary>
		/// This object contains solid collision.
		/// </summary>
		Collision,

		/// <summary>
		/// This object contains sloped collision.
		/// </summary>
		DiagonalCollision,

		/// <summary>
		/// This object's design intent is to be used as a wall enclosing a room.
		/// </summary>
		Wall,

		/// <summary>
		/// This object's design intent is to be used as a ceiling on the exterior of the area.
		/// </summary>
		Ceiling,

		/// <summary>
		/// This object's design intent is to be used as a floor or carpet.
		/// </summary>
		Floor,

		/// <summary>
		/// This object should be placed on a floor in the interior of the room.
		/// </summary>
		RoomDecoration,

		WallDecoration,

		/// <summary>
		/// This object is meant to mask away areas of one layer to expose another.
		/// </summary>
		LayerMask,

		/// <summary>
		/// This object is intended to transition the player between rooms.
		/// </summary>
		RoomTransition,

		/// <summary>
		/// 
		/// </summary>
		Stairs,
		Pits,
		Ledge,
		Spikes,
		ShallowWater,
		DeepWater,
		IcyFloor,
		PuzzlePegs,
		Conveyor,

		Secrets,

		/// <summary>
		/// This object may be directly manipulated by the player.
		/// </summary>
		Manipulable,

		/// <summary>
		/// This object contains collision that can be latched with the hookshot.
		/// </summary>
		Hookshottable,

		NorthSide,
		SouthSide,
		WestSide,
		EastSide,

		NorthPerimeter,
		SouthPerimeter,
		EastPerimeter,
		WestPerimeter,

		LowerLayer,
		UpperLayer,
		MetaLayer,
	}
}
