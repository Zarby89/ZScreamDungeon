﻿namespace ZeldaFullEditor.Utility;

/// <summary>
/// Contains fields for consistency with colors across the user interface.
/// </summary>
internal static class UIColors
{
	public const int EntityAlpha = 200;
	public const int EntitySelectedAlpha = 230;


	public static readonly Pen GridPen = new(Color.FromArgb(150, 255, 255, 255));

	//========================================================================================================================
	// Underworld editor
	//========================================================================================================================
	public const int RoomClosedAlpha = 150;

	public static readonly Pen SelectedRoomOutline = new(Color.Lime, 2);
	public static readonly Pen OpenedRoomOutline = new(Color.LimeGreen, 2);
	public static readonly Pen ExportedRoomOutline = new(Color.DarkTurquoise, 2);
	public static readonly Pen OpenedExportedRoomOutline = new(Color.SeaGreen, 2);

	//========================================================================================================================
	// Overworld editor
	//========================================================================================================================
	public static readonly SolidBrush SelectedBrush = new(Color.FromArgb(EntitySelectedAlpha, Color.Azure));

	public static readonly Pen OutlinePen = new(Color.FromArgb(EntitySelectedAlpha, Color.Black));
	public static readonly Pen OutlineSelectedPen = new(Color.FromArgb(EntitySelectedAlpha, Color.Azure));
	public static readonly Pen OutlineHoverPen = new(Color.FromArgb(EntitySelectedAlpha, 0xCC, 0xCC, 0xFF));

	public static readonly Color SpriteColor = Color.FromArgb(200, 50, 50);
	public static readonly SolidBrush SpriteBrush = new(Color.FromArgb(EntityAlpha, SpriteColor));
	public static readonly SolidBrush SpriteSelectedBrush = new(Color.FromArgb(EntitySelectedAlpha, SpriteColor));

	public static readonly Color SecretColor = Color.FromArgb(100, 200, 50);
	public static readonly SolidBrush SecretBrush = new(Color.FromArgb(EntityAlpha, SecretColor));
	public static readonly SolidBrush SecretSelectedBrush = new(Color.FromArgb(EntitySelectedAlpha, SecretColor));

	public static readonly Color EntranceColor = Color.FromArgb(230, 230, 230);
	public static readonly SolidBrush EntranceBrush = new(Color.FromArgb(EntityAlpha, EntranceColor));
	public static readonly SolidBrush EntranceSelectedBrush = new(Color.FromArgb(EntitySelectedAlpha, EntranceColor));

	public static readonly Color ExitColor = Color.FromArgb(250, 250, 50);
	public static readonly SolidBrush ExitBrush = new(Color.FromArgb(EntityAlpha, ExitColor));
	public static readonly SolidBrush ExitSelectedBrush = new(Color.FromArgb(EntitySelectedAlpha, ExitColor));

	public static readonly Color HoleEntranceColor = Color.FromArgb(50, 50, 50);
	public static readonly SolidBrush HoleEntranceBrush = new(Color.FromArgb(EntityAlpha, HoleEntranceColor));
	public static readonly SolidBrush HoleEntranceSelectedBrush = new(Color.FromArgb(EntitySelectedAlpha, HoleEntranceColor));

	public static readonly Color TransportColor = Color.FromArgb(50, 175, 175);
	public static readonly SolidBrush TransportBrush = new(Color.FromArgb(EntityAlpha, TransportColor));
	public static readonly SolidBrush TransportSelectedBrush = new(Color.FromArgb(EntitySelectedAlpha, TransportColor));

}
