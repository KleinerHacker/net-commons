using System;

namespace net.commons.Extension
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
    }
}
