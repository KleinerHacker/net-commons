#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace net.commons.Extension
{
    public static class DictionaryExtensions
    {
        private static readonly Random Random = new Random();

        public static void AddAll<TK, TV>(this IDictionary<TK, TV> dict, params KeyValuePair<TK, TV>[] keyValuePairs)
        {
            foreach (var keyValuePair in keyValuePairs)
            {
                dict.Add(keyValuePair);
            }
        }

        public static void AddAll<TK, TV>(this IDictionary<TK, TV> dict, IEnumerable<KeyValuePair<TK, TV>> keyValuePairs)
        {
            foreach (var keyValuePair in keyValuePairs)
            {
                dict.Add(keyValuePair);
            }
        }

        public static void AddAll<TK, TV>(this IDictionary<TK, TV> dict, IDictionary<TK, TV> other)
        {
            foreach (var keyValuePair in other)
            {
                dict.Add(keyValuePair);
            }
        }

        public static void RemoveAll<TK, TV>(this IDictionary<TK, TV> dict, params TK[] keys)
        {
            foreach (var key in keys)
            {
                dict.Remove(key);
            }
        }

        public static void RemoveAll<TK, TV>(this IDictionary<TK, TV> dict, IEnumerable<TK> keys)
        {
            foreach (var key in keys)
            {
                dict.Remove(key);
            }
        }

        public static bool Remove<TK, TV>(this IDictionary<TK, TV> dict, Predicate<KeyValuePair<TK, TV>> predicate)
        {
            foreach (var item in new Dictionary<TK, TV>(dict))
            {
                if (predicate(item))
                {
                    dict.Remove(item);
                    return true;
                }
            }

            return false;
        }

        public static int RemoveAll<TK, TV>(this IDictionary<TK, TV> dict, Predicate<KeyValuePair<TK, TV>> predicate)
        {
            var counter = 0;
            foreach (var item in new Dictionary<TK, TV>(dict))
            {
                if (predicate(item))
                {
                    dict.Remove(item);
                    counter++;
                }
            }

            return counter;
        }

        public static void SetAll<TK, TV>(this IDictionary<TK, TV> dict, params KeyValuePair<TK, TV>[] keyValuePairs)
        {
            dict.Clear();
            dict.AddAll(keyValuePairs);
        }

        public static void SetAll<TK, TV>(this IDictionary<TK, TV> dict, IEnumerable<KeyValuePair<TK, TV>> keyValuePairs)
        {
            dict.Clear();
            dict.AddAll(keyValuePairs);
        }

        public static void SetAll<TK, TV>(this IDictionary<TK, TV> dict, IDictionary<TK, TV> other)
        {
            dict.Clear();
            dict.AddAll(other);
        }

        public static TK GetRandomKey<TK, TV>(this IDictionary<TK, TV> dict)
        {
            var index = Random.Next(dict.Keys.Count);
            return dict.Keys.ElementAt(index);
        }

        public static TV GetRandomValue<TK, TV>(this IDictionary<TK, TV> dict)
        {
            var index = Random.Next(dict.Values.Count);
            return dict.Values.ElementAt(index);
        }

        public static KeyValuePair<TK, TV> GetRandom<TK, TV>(this IDictionary<TK, TV> dict)
        {
            var index = Random.Next(dict.Count);
            return dict.ElementAt(index);
        }
    }
}