#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

#endregion

namespace net.commons.Extension.WPF
{
    public static class DependencyPropertyExtensions
    {
        public static void AddValueChanged(this DependencyProperty dp, DependencyObject depObj, EventHandler callback, bool runImmediately = true)
        {
            DependencyPropertyDescriptor.FromProperty(dp, depObj.GetType()).AddValueChanged(depObj, callback);
            if (runImmediately)
            {
                callback(dp, new EventArgs());
            }
        }

        public static void RemoveValueChanged(this DependencyProperty dp, DependencyObject depObj, EventHandler callback)
        {
            DependencyPropertyDescriptor.FromProperty(dp, depObj.GetType()).RemoveValueChanged(depObj, callback);
        }
    }
}