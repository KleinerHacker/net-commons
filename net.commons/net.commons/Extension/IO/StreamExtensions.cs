using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace net.commons.Extension.IO
{
    public static class StreamExtensions
    {
        #region Writer

        #region Default

        public static void Write(this Stream stream, byte[] buffer)
        {
            stream.Write(buffer, 0, buffer.Length);
        }

        public static Task WriteAsync(this Stream stream, byte[] buffer, CancellationToken token)
        {
            return stream.WriteAsync(buffer, 0, buffer.Length, token);
        }

        public static Task WriteAsync(this Stream stream, byte[] buffer)
        {
            return Task.WhenAny(stream.WriteAsync(buffer, 0, buffer.Length));
        }

        public static IAsyncResult BeginWrite(this Stream stream, byte[] buffer, AsyncCallback callback, object state)
        {
            return stream.BeginWrite(buffer, 0, buffer.Length, callback, state);
        }

        #endregion

        #region SByte

        public static void WriteSByte(this Stream stream, byte value)
        {
            stream.Write(value.ToByteArray());
        }

        public static Task WriteSByteAsync(this Stream stream, byte value, CancellationToken token)
        {
            return stream.WriteAsync(value.ToByteArray(), token);
        }

        public static Task WriteSByteAsync(this Stream stream, byte value)
        {
            return stream.WriteAsync(value.ToByteArray());
        }

        public static IAsyncResult BeginWriteSByte(this Stream stream, byte value, AsyncCallback callback, object state)
        {
            return stream.BeginWrite(value.ToByteArray(), callback, state);
        }

        #endregion

        #region Int16

        public static void WriteInt16(this Stream stream, short value)
        {
            stream.Write(value.ToByteArray());
        }

        public static Task WriteInt16Async(this Stream stream, short value, CancellationToken token)
        {
            return stream.WriteAsync(value.ToByteArray(), token);
        }

        public static Task WriteInt16Async(this Stream stream, short value)
        {
            return stream.WriteAsync(value.ToByteArray());
        }

        public static IAsyncResult BeginWriteInt16(this Stream stream, short value, AsyncCallback callback, object state)
        {
            return stream.BeginWrite(value.ToByteArray(), callback, state);
        }

        #endregion

        #region UInt16

        public static void WriteUInt16(this Stream stream, ushort value)
        {
            stream.Write(value.ToByteArray());
        }

        public static Task WriteUInt16Async(this Stream stream, ushort value, CancellationToken token)
        {
            return stream.WriteAsync(value.ToByteArray(), token);
        }

        public static Task WriteUInt16Async(this Stream stream, ushort value)
        {
            return stream.WriteAsync(value.ToByteArray());
        }

        public static IAsyncResult BeginWriteUInt16(this Stream stream, ushort value, AsyncCallback callback, object state)
        {
            return stream.BeginWrite(value.ToByteArray(), callback, state);
        }

        #endregion

        #region Int32

        public static void WriteInt32(this Stream stream, int value)
        {
            stream.Write(value.ToByteArray());
        }

        public static Task WriteInt32Async(this Stream stream, int value, CancellationToken token)
        {
            return stream.WriteAsync(value.ToByteArray(), token);
        }

        public static Task WriteInt32Async(this Stream stream, int value)
        {
            return stream.WriteAsync(value.ToByteArray());
        }

        public static IAsyncResult BeginWriteInt32(this Stream stream, int value, AsyncCallback callback, object state)
        {
            return stream.BeginWrite(value.ToByteArray(), callback, state);
        }

        #endregion

        #region UInt32

        public static void WriteUInt32(this Stream stream, uint value)
        {
            stream.Write(value.ToByteArray());
        }

        public static Task WriteUInt32Async(this Stream stream, uint value, CancellationToken token)
        {
            return stream.WriteAsync(value.ToByteArray(), token);
        }

        public static Task WriteUInt32Async(this Stream stream, uint value)
        {
            return stream.WriteAsync(value.ToByteArray());
        }

        public static IAsyncResult BeginWriteUInt32(this Stream stream, uint value, AsyncCallback callback, object state)
        {
            return stream.BeginWrite(value.ToByteArray(), callback, state);
        }

        #endregion

        #region Int64

        public static void WriteInt64(this Stream stream, long value)
        {
            stream.Write(value.ToByteArray());
        }

        public static Task WriteInt64Async(this Stream stream, long value, CancellationToken token)
        {
            return stream.WriteAsync(value.ToByteArray(), token);
        }

        public static Task WriteInt64Async(this Stream stream, long value)
        {
            return stream.WriteAsync(value.ToByteArray());
        }

        public static IAsyncResult BeginWriteInt64(this Stream stream, long value, AsyncCallback callback, object state)
        {
            return stream.BeginWrite(value.ToByteArray(), callback, state);
        }

        #endregion

        #region UInt64

        public static void WriteUInt64(this Stream stream, ulong value)
        {
            stream.Write(value.ToByteArray());
        }

        public static Task WriteUInt64Async(this Stream stream, ulong value, CancellationToken token)
        {
            return stream.WriteAsync(value.ToByteArray(), token);
        }

        public static Task WriteUInt64Async(this Stream stream, ulong value)
        {
            return stream.WriteAsync(value.ToByteArray());
        }

        public static IAsyncResult BeginWriteUInt64(this Stream stream, ulong value, AsyncCallback callback, object state)
        {
            return stream.BeginWrite(value.ToByteArray(), callback, state);
        }

        #endregion

        #region Double

        public static void WriteDouble(this Stream stream, float value)
        {
            stream.Write(value.ToByteArray());
        }

        public static Task WriteDoubleAsync(this Stream stream, float value, CancellationToken token)
        {
            return stream.WriteAsync(value.ToByteArray(), token);
        }

        public static Task WriteDoubleAsync(this Stream stream, float value)
        {
            return stream.WriteAsync(value.ToByteArray());
        }

        public static IAsyncResult BeginWriteDouble(this Stream stream, float value, AsyncCallback callback, object state)
        {
            return stream.BeginWrite(value.ToByteArray(), callback, state);
        }

        #endregion

        #region Single

        public static void WriteSingle(this Stream stream, float value)
        {
            stream.Write(value.ToByteArray());
        }

        public static Task WriteSingleAsync(this Stream stream, float value, CancellationToken token)
        {
            return stream.WriteAsync(value.ToByteArray(), token);
        }

        public static Task WriteSingleAsync(this Stream stream, float value)
        {
            return stream.WriteAsync(value.ToByteArray());
        }

        public static IAsyncResult BeginWriteSingle(this Stream stream, float value, AsyncCallback callback, object state)
        {
            return stream.BeginWrite(value.ToByteArray(), callback, state);
        }

        #endregion

        #region Boolean

        public static void WriteBoolean(this Stream stream, bool value)
        {
            stream.Write(value.ToByteArray());
        }

        public static Task WriteBooleanAsync(this Stream stream, bool value, CancellationToken token)
        {
            return stream.WriteAsync(value.ToByteArray(), token);
        }

        public static Task WriteBooleanAsync(this Stream stream, bool value)
        {
            return stream.WriteAsync(value.ToByteArray());
        }

        public static IAsyncResult BeginWriteBoolean(this Stream stream, bool value, AsyncCallback callback, object state)
        {
            return stream.BeginWrite(value.ToByteArray(), callback, state);
        }

        #endregion

        #region Character

        public static void WriteCharacter(this Stream stream, char value)
        {
            stream.Write(value.ToByteArray());
        }

        public static Task WriteCharacterAsync(this Stream stream, char value, CancellationToken token)
        {
            return stream.WriteAsync(value.ToByteArray(), token);
        }

        public static Task WriteCharacterAsync(this Stream stream, char value)
        {
            return stream.WriteAsync(value.ToByteArray());
        }

        public static IAsyncResult BeginWriteCharacter(this Stream stream, char value, AsyncCallback callback, object state)
        {
            return stream.BeginWrite(value.ToByteArray(), callback, state);
        }

        #endregion

        #region CharacterArray

        public static void WriteCharacterArray(this Stream stream, char[] value)
        {
            WriteCharacterArray(stream, value, Encoding.Default);
        }

        public static void WriteCharacterArray(this Stream stream, char[] value, Encoding encoding)
        {
            stream.Write(value.ToByteArray(encoding));
        }

        public static Task WriteCharacterArrayAsync(this Stream stream, char[] value, CancellationToken token)
        {
            return WriteCharacterArrayAsync(stream, value, Encoding.Default, token);
        }

        public static Task WriteCharacterArrayAsync(this Stream stream, char[] value, Encoding encoding, CancellationToken token)
        {
            return stream.WriteAsync(value.ToByteArray(encoding), token);
        }

        public static Task WriteCharacterArrayAsync(this Stream stream, char[] value)
        {
            return WriteCharacterArrayAsync(stream, value, Encoding.Default);
        }

        public static Task WriteCharacterArrayAsync(this Stream stream, char[] value, Encoding encoding)
        {
            return stream.WriteAsync(value.ToByteArray(encoding));
        }

        public static IAsyncResult BeginWriteCharacterArray(this Stream stream, char[] value, AsyncCallback callback, object state)
        {
            return BeginWriteCharacterArray(stream, value, Encoding.Default, callback, state);
        }

        public static IAsyncResult BeginWriteCharacterArray(this Stream stream, char[] value, Encoding encoding, AsyncCallback callback, object state)
        {
            return stream.BeginWrite(value.ToByteArray(encoding), callback, state);
        }

        #endregion

        #region String

        public static void WriteString(this Stream stream, string value)
        {
            WriteString(stream, value, Encoding.Default);
        }

        public static void WriteString(this Stream stream, string value, Encoding encoding)
        {
            stream.Write(value.ToByteArray(encoding));
        }

        public static Task WriteStringAsync(this Stream stream, string value, CancellationToken token)
        {
            return WriteStringAsync(stream, value, Encoding.Default, token);
        }

        public static Task WriteStringAsync(this Stream stream, string value, Encoding encoding, CancellationToken token)
        {
            return stream.WriteAsync(value.ToByteArray(encoding), token);
        }

        public static Task WriteStringAsync(this Stream stream, string value)
        {
            return WriteStringAsync(stream, value, Encoding.Default);
        }

        public static Task WriteStringAsync(this Stream stream, string value, Encoding encoding)
        {
            return stream.WriteAsync(value.ToByteArray(encoding));
        }

        public static IAsyncResult BeginWriteString(this Stream stream, string value, AsyncCallback callback, object state)
        {
            return BeginWriteString(stream, value, Encoding.Default, callback, state);
        }

        public static IAsyncResult BeginWriteString(this Stream stream, string value, Encoding encoding, AsyncCallback callback, object state)
        {
            return stream.BeginWrite(value.ToByteArray(encoding), callback, state);
        }

        #endregion

        #endregion

        #region Reader

        #region Default

        public static byte[] ReadFully(this Stream stream, int length)
        {
            var bytes = new byte[length];

            var countOfBytes = 0;
            do
            {
                var readBytes = stream.Read(bytes, countOfBytes, length - countOfBytes);
                if (readBytes == 0)
                    throw new EndOfStreamException("no more bytes to read, found was " + countOfBytes);
                countOfBytes += readBytes;
            } while (countOfBytes < length);

            return bytes;
        }

        public static async Task<byte[]> ReadFullyAsync(this Stream stream, int length, CancellationToken token)
        {
            var bytes = new byte[length];

            var countOfBytes = 0;
            do
            {
                var readBytes = await stream.ReadAsync(bytes, countOfBytes, length - countOfBytes, token);
                if (readBytes == 0)
                    throw new EndOfStreamException("no more bytes to read, found was " + countOfBytes);
                countOfBytes += readBytes;
            } while (countOfBytes < length);

            return bytes;
        }

        public static async Task<byte[]> ReadFullyAsync(this Stream stream, int length)
        {
            var bytes = new byte[length];

            var countOfBytes = 0;
            do
            {
                var readBytes = await stream.ReadAsync(bytes, countOfBytes, length - countOfBytes);
                if (readBytes == 0)
                    throw new EndOfStreamException("no more bytes to read, found was " + countOfBytes);
                countOfBytes += readBytes;
            } while (countOfBytes < length);

            return bytes;
        }

        public static IAsyncResult BeginReadFully(this Stream stream, int length, AsyncCallback callback, object state)
        {
            var task = Task.Run(() =>
            {
                var bytes = ReadFully(stream, length);
                callback.Invoke(Task.Run(() => bytes));
                return bytes;
            });
            return task;
        }

        public static byte[] EndReadFully(this Stream stream, IAsyncResult asyncResult)
        {
            var task = asyncResult as Task<byte[]>;
            if (task == null)
                throw new InvalidOperationException("Wrong async result");

            task.Wait();
            return task.Result;
        }

        #endregion

        #endregion
    }
}
