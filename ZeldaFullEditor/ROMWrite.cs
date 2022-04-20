using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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

	public interface IROMWritable
	{
		ROMWritePack Data { get; }
	}

	public class ROMWrite
	{
		private readonly dynamic _data;
		public dynamic this[int i] => _data[i];

		public ROMWrite(dynamic data)
		{
			_data = data;
		}
	}

	public class ROMWritePack : Dictionary<string, ROMWrite>
	{

	}
}
