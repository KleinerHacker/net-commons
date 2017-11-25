#region

using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

#endregion

namespace Net.Commons.Extension
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

        public static bool IsEmpty(this string value)
        {
            return value.Length <= 0;
        }

        public static bool Contains(this string value, string other, bool ignoreCase)
        {
            return ignoreCase ? value.ToLower().Contains(other.ToLower()) : value.Contains(other);
        }

        public static string ToLowerWords(this string value)
        {
            return ToLowerWords(value, CultureInfo.CurrentCulture);
        }

        public static string ToLowerWords(this string value, CultureInfo cultureInfo)
        {
            return ToCaseWords(value, cultureInfo, false);
        }

        public static string ToUpperWords(this string value)
        {
            return ToUpperWords(value, CultureInfo.CurrentCulture);
        }

        public static string ToUpperWords(this string value, CultureInfo cultureInfo)
        {
            return ToCaseWords(value, cultureInfo, true);
        }

        private static string ToCaseWords(string value, CultureInfo cultureInfo, bool upper)
        {
            var parts = value.Split(' ');

            var result = "";
            foreach (var part in parts)
            {
                if (part.IsEmpty())
                {
                    result += " ";
                    continue;
                }

                result += (upper ? part[0].ToUpper(cultureInfo) : part[0].ToLower(cultureInfo)) + part.Substring(1) + " ";
            }
            
            return result.IsEmpty() ? result : result.Substring(0, result.Length - 1);
        }

        public static string Replace(this string value, string oldValue, string newValue, bool ignoreCase, int maxReplacing = -1)
        {
            var result = value;
            var counter = 0;
            var max = maxReplacing < 0 ? int.MaxValue : maxReplacing;
            while (result.Contains(oldValue, ignoreCase) && counter < maxReplacing)
            {
                var indexOf = result.IndexOf(oldValue, StringComparison.Ordinal);
                result = result.Remove(indexOf, oldValue.Length);
                result = result.Insert(indexOf, newValue);

                if (maxReplacing >= 0)
                {
                    counter++;
                }
            }

            return result;
        }
    }
}