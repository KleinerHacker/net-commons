#region

using System;

#endregion

namespace Net.Commons.Extension
{
    public static class BooleanExtensions
    {
        public static byte[] ToByteArray(this bool value)
        {
            return BitConverter.GetBytes(value);
        }

        public static bool ToBoolean(this byte[] value, int startIndex = 0)
        {
            return BitConverter.ToBoolean(value, startIndex);
        }

        public static string ToString(this bool? value, string trueStr, string falseStr)
        {
            return ToString(value, trueStr, falseStr, falseStr);
        }

        public static string ToString(this bool? value, string trueStr, string falseStr, string nullStr)
        {
            return !value.HasValue ? nullStr : value.Value.ToString(trueStr, falseStr);
        }

        public static string ToString(this bool value, string trueStr, string falseStr)
        {
            return value ? trueStr : falseStr;
        }
    }
}