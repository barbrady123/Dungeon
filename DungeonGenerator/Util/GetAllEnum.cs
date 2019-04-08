using System;
using System.Collections.Generic;
using System.Linq;

namespace Whitehouse.Dungeon.Generator.Util
{
	public class GetAllEnum
    {
        public static IEnumerable<T> ValuesOf<T>()
        {			
            return typeof (T).IsEnum ? Enum.GetValues(typeof(T)).OfType<T>() : null;
        }
	}
}
