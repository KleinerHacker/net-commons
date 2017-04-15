using System;
using System.Collections.Generic;
using System.Linq;

namespace net.commons.Extension
{
    public static class CommonExtensions
    {
        public static bool In<T>(this T value, params T[] values)
        {
            return values.Contains(value);
        }

        public static bool In<T>(this T value, ICollection<T> values)
        {
            return values.Contains(value);
        }
    }
}
