using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ZeldaFullEditor
{

	public enum CollisionKey
	{
		One,
		Both,
		Both_With_Scroll,
		Moving_Floor,
		Moving_Water,
	}
}
