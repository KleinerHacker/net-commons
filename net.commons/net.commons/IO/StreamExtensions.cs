using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace net.commons.IO
{
    public static class StreamExtensions
    {
        #region Writer

        public static void Write(this Stream stream, byte[] buffer)
        {
            stream.Write(buffer, 0, buffer.Length);
        }

        public static void WriteAsync(this Stream stream, byte[] buffer, CancellationToken token)
        {
            stream.WriteAsync(buffer, 0, buffer.Length, token);
        }

        public static void WriteAsync(this Stream stream, byte[] buffer)
        {
            stream.WriteAsync(buffer, 0, buffer.Length);
        }

        public static IAsyncResult BeginWrite(this Stream stream, byte[] buffer, AsyncCallback callback, object state)
        {
            return stream.BeginWrite(buffer, 0, buffer.Length, callback, state);
        }

        #endregion
    }
}
