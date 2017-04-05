using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.commons
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

        /*public static string NextString(this Random random, int minLength, int maxLength, RandomStringType type)
        {
            if (type.Con)
        }*/
    }

    public enum RandomStringType : byte
    {
        AlphaLower = 1,
        AlphaUpper = 2,
        Numeric = 4
    }
}
