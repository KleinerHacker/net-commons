#region

using System;
using System.Collections.Generic;
using System.Windows;

#endregion

namespace net.commons.Extension.WPF
{
    //TODO: Out of memory
    public static class DependencyPropertyExtensions
    {
        private static readonly IDictionary<DependencyProperty, IDictionary<Type, IList<PropertyChangedCallback>>> CallbackDict = new Dictionary<DependencyProperty, IDictionary<Type, IList<PropertyChangedCallback>>>();

        public static void AddPropertyChangeCallback(this DependencyProperty dp, Type type, PropertyChangedCallback callback)
        {
            if (!CallbackDict.ContainsKey(dp))
            {
                CallbackDict.Add(dp, new Dictionary<Type, IList<PropertyChangedCallback>>());
            }
            if (!CallbackDict[dp].ContainsKey(type))
            {
                CallbackDict[dp].Add(type, new List<PropertyChangedCallback>());
                dp.AddOwner(type, new PropertyMetadata((o, args) =>
                {
                    foreach (var propertyChangedCallback in CallbackDict[dp][type])
                    {
                        propertyChangedCallback.Invoke(o, args);
                    }
                }));
            }

            CallbackDict[dp][type].Add(callback);
        }
    }
}