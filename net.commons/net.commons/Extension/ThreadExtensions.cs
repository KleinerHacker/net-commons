#region

using System;
using System.Security.Permissions;
using System.Windows.Threading;

#endregion

namespace net.commons.Extension
{
    public static class ThreadExtensions
    {
        /// <summary>
        ///     Simulate an event on a dispatcher thread
        /// </summary>
        /// <param name="dispatcher"></param>
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static void SimulateEvents(this Dispatcher dispatcher)
        {
            var frame = new DispatcherFrame();
            dispatcher.BeginInvoke(DispatcherPriority.Background,
                new DispatcherOperationCallback(o =>
                {
                    frame.Continue = false;
                    return null;
                }), frame);

            try
            {
                Dispatcher.PushFrame(frame);
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}