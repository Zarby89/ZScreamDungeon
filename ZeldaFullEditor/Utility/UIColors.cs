using System.Drawing;

namespace ZeldaFullEditor
{
	public static class UIColors
	{
		public const int EntityAlpha = 200;
		public const int EntitySelectedAlpha = 230;

		public static readonly SolidBrush SelectedBrush = new SolidBrush(Color.FromArgb(EntitySelectedAlpha, Color.Azure));

		public static readonly Pen OutlinePen = new Pen(Color.FromArgb(EntitySelectedAlpha, Color.Black));
		public static readonly Pen OutlineSelectedPen = new Pen(Color.FromArgb(EntitySelectedAlpha, Color.Azure));
		public static readonly Pen OutlineHoverPen = new Pen(Color.FromArgb(EntitySelectedAlpha, 0xCC, 0xCC, 0xFF));

		public static readonly Color SpriteColor = Color.FromArgb(200, 50, 50);
		public static readonly SolidBrush SpriteBrush = new SolidBrush(Color.FromArgb(EntityAlpha, SpriteColor));
		public static readonly SolidBrush SpriteSelectedBrush = new SolidBrush(Color.FromArgb(EntitySelectedAlpha, SpriteColor));

		public static readonly Color SecretColor = Color.FromArgb(100, 200, 50);
		public static readonly SolidBrush SecretBrush = new SolidBrush(Color.FromArgb(EntityAlpha, SecretColor));
		public static readonly SolidBrush SecretSelectedBrush = new SolidBrush(Color.FromArgb(EntitySelectedAlpha, SecretColor));

		public static readonly Color EntranceColor = Color.FromArgb(230, 230, 230);
		public static readonly SolidBrush EntranceBrush = new SolidBrush(Color.FromArgb(EntityAlpha, EntranceColor));
		public static readonly SolidBrush EntranceSelectedBrush = new SolidBrush(Color.FromArgb(EntitySelectedAlpha, EntranceColor));

		public static readonly Color ExitColor = Color.FromArgb(250, 250, 50);
		public static readonly SolidBrush ExitBrush = new SolidBrush(Color.FromArgb(EntityAlpha, ExitColor));
		public static readonly SolidBrush ExitSelectedBrush = new SolidBrush(Color.FromArgb(EntitySelectedAlpha, ExitColor));

		public static readonly Color HoleEntranceColor = Color.FromArgb(50, 50, 50);
		public static readonly SolidBrush HoleEntranceBrush = new SolidBrush(Color.FromArgb(EntityAlpha, HoleEntranceColor));
		public static readonly SolidBrush HoleEntranceSelectedBrush = new SolidBrush(Color.FromArgb(EntitySelectedAlpha, HoleEntranceColor));

		public static readonly Color TransportColor = Color.FromArgb(50, 175, 175);
		public static readonly SolidBrush TransportBrush = new SolidBrush(Color.FromArgb(EntityAlpha, TransportColor));
		public static readonly SolidBrush TransportSelectedBrush = new SolidBrush(Color.FromArgb(EntitySelectedAlpha, TransportColor));
	}
}
