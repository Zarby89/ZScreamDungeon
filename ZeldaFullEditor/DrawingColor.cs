using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor {
	public class DrawingColor : IDisposable {
		private bool disposedValue;
		public Color Color { get; }
		public SolidBrush Brush { get; }
		public Pen Pen { get; }

		public DrawingColor(Color color) {
			Color = color;
			Brush = new SolidBrush(color);
			Pen = new Pen(color);
		}

		public DrawingColor(int r, int g, int b) : this(Color.FromArgb(255, r, g, b)) {

		}

		public DrawingColor(int a, int r, int g, int b) : this(Color.FromArgb(a, r, g, b)) {

		}



		protected virtual void Dispose(bool disposing) {
			if (!disposedValue) {
				if (disposing) {
					Brush.Dispose();
					Pen.Dispose();
				}

				disposedValue = true;
			}
		}

		public void Dispose() {
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}


		public static implicit operator Color(DrawingColor d) => d.Color;
		public static implicit operator SolidBrush(DrawingColor d) => d.Brush;
		public static implicit operator Pen(DrawingColor d) => d.Pen;
	}
}
