#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

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

        public static unsafe IntPtr GetPointer<T>(this T value)
        {
            var reference = __makeref(value);
            var ptr = **(IntPtr**) (&reference);

            return ptr;
        }

        public static T ThisOrDefault<T>(this T value, T defaultValue)
        {
            return value.Equals(default(T)) ? defaultValue : value;
        }
    }
}