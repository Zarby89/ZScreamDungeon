using System.Drawing;

namespace ZeldaFullEditor
{
	public static class UIColors
	{
		public const int EntityAlpha = 200;
		public const int EntitySelectedAlpha = 230;

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


		public static readonly Pen GridPen = new(Color.FromArgb(150, 255, 255, 255));
	}
}
