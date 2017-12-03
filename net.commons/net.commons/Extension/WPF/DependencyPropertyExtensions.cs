#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

#endregion

namespace Net.Commons.Extension.WPF
{
    public static class DependencyPropertyExtensions
    {
        /// <summary>
        /// Add an observer for this dependency property. <b>Please remove callback with <see cref="RemoveValueChanged"/> to avoid memory leaks!</b>
        /// </summary>
        /// <param name="dp"></param>
        /// <param name="depObj">Dependency Object that observe this property</param>
        /// <param name="callback">Callback method is called in case of property value change</param>
        /// <param name="runImmediately">TRUE to run immediately (with this method call), otherwise FALSE. Default is TRUE</param>
        /// <returns>TRUE if success</returns>
        public static void AddValueChanged(this DependencyProperty dp, DependencyObject depObj, EventHandler callback, bool runImmediately = true)
        {
            var dependencyPropertyDescriptor = DependencyPropertyDescriptor.FromProperty(dp, depObj.GetType());
            dependencyPropertyDescriptor.AddValueChanged(depObj, callback);
            DependencyPropertyUtils.RaiseAddPropertyObserver(dp, depObj);

            if (runImmediately)
            {
                callback(dp, new EventArgs());
            }
        }

        /// <summary>
        /// Remove an existing observer for this dependency property. <b>This call is needed to avoid memory leaks!</b>
        /// </summary>
        /// <param name="dp"></param>
        /// <param name="depObj">Dependency Object that observe this property</param>
        /// <param name="callback">Callback method is called in case of property value change</param>
        /// <returns>TRUE if success</returns>
        public static bool RemoveValueChanged(this DependencyProperty dp, DependencyObject depObj, EventHandler callback)
        {
            var dependencyPropertyDescriptor = DependencyPropertyDescriptor.FromProperty(dp, depObj.GetType());
            dependencyPropertyDescriptor.RemoveValueChanged(depObj, callback);
            DependencyPropertyUtils.RaiseRemovePropertyObserver(dp, depObj);

            return true;
        }
    }

    /// <summary>
    /// Utils for dependency properties
    /// </summary>
    public static class DependencyPropertyUtils
    {
        /// <summary>
        /// Is called if a new observer is added with call of <see cref="DependencyPropertyExtensions.AddValueChanged"/>
        /// </summary>
        public static event EventHandler<PropertyObserverEventArgs> AddPropertyObserver;
        /// <summary>
        /// Is called if an existing observer is removed with call of <see cref="DependencyPropertyExtensions.RemoveValueChanged"/>
        /// </summary>
        public static event EventHandler<PropertyObserverEventArgs> RemovePropertyObserver;

        internal static void RaiseAddPropertyObserver(DependencyProperty observedDependencyProperty, DependencyObject attachedDependencyObject)
        {
            AddPropertyObserver?.Invoke(null, new PropertyObserverEventArgs(observedDependencyProperty, attachedDependencyObject));
        }

        internal static void RaiseRemovePropertyObserver(DependencyProperty observedDependencyProperty, DependencyObject attachedDependencyObject)
        {
            RemovePropertyObserver?.Invoke(null, new PropertyObserverEventArgs(observedDependencyProperty, attachedDependencyObject));
        }
    }

    /// <summary>
    /// Args for property observer observing
    /// </summary>
    public class PropertyObserverEventArgs : EventArgs
    {
        /// <summary>
        /// Dependency Property that is observed by <see cref="AttachedDependencyObject"/>
        /// </summary>
        public DependencyProperty ObservedDependencyProperty { get; }
        /// <summary>
        /// Dependency Object that observe <see cref="ObservedDependencyProperty"/>
        /// </summary>
        public DependencyObject AttachedDependencyObject { get; }

        public PropertyObserverEventArgs(DependencyProperty observedDependencyProperty, DependencyObject attachedDependencyObject)
        {
            ObservedDependencyProperty = observedDependencyProperty;
            AttachedDependencyObject = attachedDependencyObject;
        }
    }
}