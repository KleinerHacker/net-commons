#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace net.commons.Extension
{
    public static class CollectionExtensions
    {
        private static readonly Random Random = new Random();

        public static bool IsEmpty<T>(this IEnumerable<T> value)
        {
            return !value.Any();
        }

        public static void Shuffle<T>(this T[] value, ShuffleHardness shuffleHardness = ShuffleHardness.Medium)
        {
            for (var i = 0; i < value.Length; i++)
            {
                for (var r = 0; r < (int) shuffleHardness; r++)
                {
                    //Random Index
                    var index = Random.Next(value.Length);
                    //Swap
                    var tmp = value[index];
                    value[index] = value[i];
                    value[i] = tmp;
                }
            }
        }

        public static void Shuffle<T>(this IList<T> value, ShuffleHardness shuffleHardness = ShuffleHardness.Medium)
        {
            for (var i = 0; i < value.Count; i++)
            {
                for (var r = 0; r < (int) shuffleHardness; r++)
                {
                    //Random Index
                    var index = Random.Next(value.Count);
                    //Swap
                    var tmp = value[index];
                    value[index] = value[i];
                    value[i] = tmp;
                }
            }
        }

        public static T GetRandom<T>(this IEnumerable<T> value)
        {
            if (value.IsEmpty())
                return default(T);

            var index = Random.Next(value.Count());
            return value.ElementAt(index);
        }

        public static void AddAll<T>(this IList<T> list, params T[] values)
        {
            foreach (var value in values)
            {
                list.Add(value);
            }
        }

        public static void AddAll<T>(this IList<T> list, IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                list.Add(value);
            }
        }

        public static void RemoveAll<T>(this IList<T> list, params T[] values)
        {
            foreach (var value in values)
            {
                list.Remove(value);
            }
        }

        public static void RemoveAll<T>(this IList<T> list, IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                list.Remove(value);
            }
        }

        public static void RemoveAllAt<T>(this IList<T> list, params int[] values)
        {
            foreach (var value in values)
            {
                list.RemoveAt(value);
            }
        }

        public static void RemoveAllAt<T>(this IList<T> list, IEnumerable<int> values)
        {
            foreach (var value in values)
            {
                list.RemoveAt(value);
            }
        }

        public static void SetAll<T>(this IList<T> list, params T[] values)
        {
            list.Clear();
            list.AddAll(values);
        }

        public static void SetAll<T>(this IList<T> list, IEnumerable<T> values)
        {
            list.Clear();
            list.AddAll(values);
        }

        public static void RemoveAllFrom<T>(this IList<T> list, int index)
        {
            if (index < 0 || index >= list.Count)
                throw new ArgumentOutOfRangeException();

            do
            {
                list.RemoveAt(index);
            } while (index >= list.Count);
        }

        public static bool Remove<T>(this IList<T> list, Predicate<T> predicate)
        {
            foreach (var item in new List<T>(list))
            {
                if (predicate(item))
                {
                    list.Remove(item);
                    return true;
                }
            }

            return false;
        }

        public static int RemoveAll<T>(this IList<T> list, Predicate<T> predicate)
        {
            var counter = 0;
            foreach (var item in new List<T>(list))
            {
                if (predicate(item))
                {
                    list.Remove(item);
                    counter++;
                }
            }

            return counter;
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="startIndex">Inclusive</param>
        /// <param name="endIndex">Exclusive</param>
        /// <returns></returns>
        public static IList<T> SubList<T>(this IEnumerable<T> list, int startIndex, int endIndex = -1)
        {
            if (startIndex < 0 || startIndex >= list.Count())
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            if (endIndex > list.Count())
                throw new ArgumentOutOfRangeException(nameof(endIndex));

            var end = (endIndex < 0 ? list.Count() : endIndex);
            var l = new List<T>();
            for (var i = startIndex; i < end; i++)
            {
                l.Add(list.ElementAt(i));
            }

            return l;
        }

        /// <summary>
        ///     Sync lists
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="syncCollection"></param>
        public static void SyncWith<T>(this ICollection<T> collection, ICollection<T> syncCollection)
        {
            if (collection == null)
            {
                throw new NullReferenceException();
            }
            if (syncCollection == null)
            {
                return;
            }

            var removeList = collection.Where(item => !syncCollection.Any(syncItem => item.Equals(syncItem))).ToList();
            foreach (var removeItem in removeList)
            {
                collection.Remove(removeItem);
            }

            var addList = syncCollection.Where(item => !collection.Any(syncItem => item.Equals(syncItem))).ToList();
            foreach (var addItem in addList)
            {
                collection.Add(addItem);
            }
        }
    }

    public enum ShuffleHardness : byte
    {
        Minimum = 1,
        Medium = 3,
        Hard = 5,
        Maximum = 10
    }
}