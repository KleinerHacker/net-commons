using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace net.commons.Extension
{
    public static class EventHandlerExtensions
    {
        /// <summary>
        /// Call the event handler without throw exception directly
        /// </summary>
        /// <param name="eventHandler"></param>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="exceptionHandler"></param>
        public static void Invoke(this EventHandler eventHandler, object sender, EventArgs args, Action<ExceptionInfo> exceptionHandler = null)
        {
            foreach (EventHandler @delegate in eventHandler.GetInvocationList())
            {
                try
                {
                    @delegate.Invoke(sender, args);
                }
                catch (Exception e)
                {
                    exceptionHandler?.Invoke(new ExceptionInfo(e, @delegate.Method));
                }
            }
        }

        /// <summary>
        /// Call the event handler without throw exception directly
        /// </summary>
        /// <param name="eventHandler"></param>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="exceptionHandler"></param>
        public static void Invoke<T>(this EventHandler<T> eventHandler, object sender, T args, Action<ExceptionInfo> exceptionHandler = null)
        {
            foreach (EventHandler<T> @delegate in eventHandler.GetInvocationList())
            {
                try
                {
                    @delegate.Invoke(sender, args);
                }
                catch (Exception e)
                {
                    exceptionHandler?.Invoke(new ExceptionInfo(e, @delegate.Method));
                }
            }
        }
    }

    public class ExceptionInfo
    {
        public Exception Exception { get; }
        public MethodInfo InvocationMethod { get; }

        public ExceptionInfo(Exception exception, MethodInfo invocationMethod)
        {
            Exception = exception;
            InvocationMethod = invocationMethod;
        }
    }
}
