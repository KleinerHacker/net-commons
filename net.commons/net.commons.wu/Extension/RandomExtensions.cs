#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Net.Commons.Extension
{
    public static class RandomExtensions
    {
        private const string ALPHA = "abcdefghijklmnopqrstuvwxyz";
        private const string NUMERIC = "0123456789";

        public static T NextEnum<T>(this Random random, params T[] excludes)
        {
            var list = Enum.GetValues(typeof(T)).Cast<T>().ToList();

            var randomIndex = 0;
            do
            {
                randomIndex = random.Next(0, list.Count());
            } while (excludes.Contains(list[randomIndex]));

            return list[randomIndex];
        }

        public static bool NextBool(this Random random)
        {
            return random.Next() % 2 == 0;
        }

        public static string NextString(this Random random, int length, RandomStringType type = RandomStringType.All)
        {
            return NextString(random, length, length, type);
        }

        public static string NextString(this Random random, int minLength, int maxLength, RandomStringType type = RandomStringType.All)
        {
            var valueSpace = "";
            if (type.HasFlag(RandomStringType.AlphaLower))
            {
                valueSpace += ALPHA;
            }
            if (type.HasFlag(RandomStringType.AlphaUpper))
            {
                valueSpace += ALPHA.ToUpper();
            }
            if (type.HasFlag(RandomStringType.Numeric))
            {
                valueSpace += NUMERIC;
            }

            var value = "";
            var length = minLength == maxLength ? minLength : random.Next(minLength, maxLength);

            for (var i = 0; i < length; i++)
            {
                var index = random.Next(valueSpace.Length);
                value += valueSpace[index];
            }

            return value;
        }

        public static T NextOf<T>(this Random random, params T[] values)
        {
            var index = random.Next(values.Length);
            return values[index];
        }

        public static T NextOf<T>(this Random random, IEnumerable<T> values)
        {
            return NextOf(random, values.ToArray());
        }

        public static KeyValuePair<TK, TV> NextOf<TK, TV>(this Random random, IDictionary<TK, TV> dict)
        {
            var index = random.Next(dict.Count);
            return dict.ElementAt(index);
        }
    }

    [Flags]
    public enum RandomStringType : byte
    {
        AlphaLower = 1,
        AlphaUpper = 2,
        Numeric = 4,
        Alpha = AlphaLower | AlphaUpper,
        All = Alpha | Numeric
    }
}