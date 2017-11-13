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

        public static void SyncByKeyWith<TK, TV>(this IDictionary<TK, TV> dict, IList<KeyValuePair<TK, TV>> syncDict)
        {
            SyncByKeyWith(dict, syncDict.ToArray());
        }

        public static void SyncByKeyWith<TK, TV>(this IDictionary<TK, TV> dict, IList<KeyValuePair<TK, TV>> syncDict, Action<IDictionary<TK, TV>, TK, TV> overwriteAction)
        {
            SyncByKeyWith(dict, syncDict.ToArray(), overwriteAction);
        }

        public static void SyncByKeyWith<TK, TV>(this IDictionary<TK, TV> dict, params KeyValuePair<TK, TV>[] syncDict)
        {
            SyncByKeyWith(dict, syncDict.ToDictionary(pair => pair.Key, pair => pair.Value));
        }

        public static void SyncByKeyWith<TK, TV>(this IDictionary<TK, TV> dict, Action<IDictionary<TK, TV>, TK, TV> overwriteAction, params KeyValuePair<TK, TV>[] syncDict)
        {
            SyncByKeyWith(dict, syncDict.ToDictionary(pair => pair.Key, pair => pair.Value), overwriteAction);
        }

        public static void SyncByKeyWith<TK, TV>(this IDictionary<TK, TV> dict, IDictionary<TK, TV> syncDict)
        {
            SyncByKeyWith(dict, syncDict, (dic, key, value) => dic[key] = value);
        }

        public static void SyncByKeyWith<TK, TV>(this IDictionary<TK, TV> dict, IDictionary<TK, TV> syncDict, Action<IDictionary<TK, TV>, TK, TV> overwriteAction)
        {
            //Find removed
            var removedElements = dict.Keys.ToList().FindAll(value => !syncDict.Keys.Contains(value)).ToArray();
            //Find new
            var newElements = syncDict.Keys.ToList().FindAll(value => !dict.Keys.Contains(value)).ToArray();
            //Find already inserted elements
            var alreadyInsertedElements = dict.Keys.Where(syncDict.ContainsKey).ToArray();

            dict.RemoveAll(removedElements); //Remove in sync missed values 
            dict.AddAll(syncDict.Where(pair => newElements.Contains(pair.Key))); //Add new values from sync
            //Overwrite inserted elements with new(?) value
            foreach (var alreadyInsertedElement in alreadyInsertedElements)
            {
                overwriteAction(dict, alreadyInsertedElement, syncDict[alreadyInsertedElement]);
            }
        }

        public static void SyncByValueWith<TK, TV>(this IDictionary<TK, TV> dict, IList<KeyValuePair<TK, TV>> syncDict)
        {
            SyncByValueWith(dict, syncDict.ToArray());
        }

        public static void SyncByValueWith<TK, TV>(this IDictionary<TK, TV> dict, params KeyValuePair<TK, TV>[] syncDict)
        {
            SyncByValueWith(dict, syncDict.ToDictionary(pair => pair.Key, pair => pair.Value));
        }

        public static void SyncByValueWith<TK, TV>(this IDictionary<TK, TV> dict, IDictionary<TK, TV> syncDict)
        {
            //Find new
            var newElements = syncDict.ToList().FindAll(value => !dict.Values.Contains(value.Value)).Select(value => value.Key).ToArray();
            //Find removed
            var removedElements = dict.ToList().FindAll(value => !syncDict.Values.Contains(value.Value)).Select(value => value.Key).ToArray();

            dict.RemoveAll(removedElements);
            dict.AddAll(syncDict.Where(pair => newElements.Contains(pair.Key)));
        }
    }
}