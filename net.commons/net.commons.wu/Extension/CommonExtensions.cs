#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Net.Commons.Extension
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

        public static T ThisOrDefault<T>(this T value, T defaultValue)
        {
            return value.Equals(default(T)) ? defaultValue : value;
        }
    }
}