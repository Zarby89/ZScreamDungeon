using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaFullEditor
{
	public class ImmutableArray<T>
	{
		protected readonly T[] _list;

		public int Length => _list.Length;

		public T this[int i] => _list[i];

		public ImmutableArray(T[] list)
		{
			_list = list;
		}

		public ImmutableArray(List<T> list)
		{
			_list = list.ToArray();
		}
	}
}
