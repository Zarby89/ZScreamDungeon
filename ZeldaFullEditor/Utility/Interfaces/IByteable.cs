using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	/// <summary>
	/// Represents data which can be delivered as a continuous stream of bytes.
	/// </summary>
	public interface IByteable
	{
		/// <summary>
		/// Represents this object as byte-wise data in its current state.
		/// </summary>
		byte[] Data { get; }
	}
}
