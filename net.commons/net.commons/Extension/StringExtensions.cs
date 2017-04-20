#region

using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

#endregion

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
            for (var i = 0; i < count; i++)
            {
                val += value;
            }

            return val;
        }

        public static Match Match(this string value, string regex, bool ignoreCase = false)
        {
            return new Regex(regex, ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None).Match(value);
        }

        public static bool MatchWildcard(this string value, string wildcard, bool ignoreCase = false)
        {
            return LikeOperator.LikeString(value, wildcard, ignoreCase ? CompareMethod.Text : CompareMethod.Binary);
        }
    }
}