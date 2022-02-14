using System;
using System.Collections.Generic;
using System.Linq;

namespace WarCardGame
{
    public static class Utils
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.OrderBy(a => Guid.NewGuid());
        }
    }
}