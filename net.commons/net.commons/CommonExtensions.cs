using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.commons
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

        /*public static bool Contains(this Enum value, Enum other)
        {
            return (value & other) == other;
        }*/
    }
}
