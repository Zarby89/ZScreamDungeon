using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public interface IByteable
	{
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
