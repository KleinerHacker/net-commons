using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.commons.Extension
{
    public static class StringExtensions
    {
        public static byte[] ToByteArray(this string value)
        {
            return ToByteArray(value, Encoding.Default);
        }

        public static byte[] ToByteArray(this string value, Encoding encoding)
        {
            return encoding.GetBytes(value);
        }

        public static string ToString(this byte[] value, int startIndex = 0)
        {
            return ToString(value, Encoding.Default, startIndex);
        }

        public static string ToString(this byte[] value, Encoding encoding, int startIndex = 0)
        {
            return encoding.GetString(value, startIndex, value.Length - startIndex);
        }

        public static string Repeat(this string value, int count)
        {
            var val = "";
            for (int i = 0; i < count; i++)
            {
                val += value;
            }

            return val;
        }
    }
}
