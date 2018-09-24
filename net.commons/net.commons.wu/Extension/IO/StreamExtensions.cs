#region

using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace Net.Commons.Extension.IO
{
    public static class StreamExtensions
    {
        #region Writer

        #region Default

        public static void Write(this Stream stream, byte[] buffer)
        {
            stream.Write(buffer, 0, buffer.Length);
        }

        public static async Task WriteAsync(this Stream stream, byte[] buffer, CancellationToken token)
        {
            await stream.WriteAsync(buffer, 0, buffer.Length, token);
        }

        public static async Task WriteAsync(this Stream stream, byte[] buffer)
        {
            await Task.WhenAny(stream.WriteAsync(buffer, 0, buffer.Length));
        }

        #endregion

        #region SByte

        public static void WriteSByte(this Stream stream, sbyte value)
        {
            stream.Write(value.ToByteArray());
        }

        public static async Task WriteSByteAsync(this Stream stream, sbyte value, CancellationToken token)
        {
            await stream.WriteAsync(value.ToByteArray(), token);
        }

        public static async Task WriteSByteAsync(this Stream stream, sbyte value)
        {
            await stream.WriteAsync(value.ToByteArray());
        }

        #endregion

        #region Int16

        public static void WriteInt16(this Stream stream, short value)
        {
            stream.Write(value.ToByteArray());
        }

        public static async Task WriteInt16Async(this Stream stream, short value, CancellationToken token)
        {
            await stream.WriteAsync(value.ToByteArray(), token);
        }

        public static async Task WriteInt16Async(this Stream stream, short value)
        {
            await stream.WriteAsync(value.ToByteArray());
        }

        #endregion

        #region UInt16

        public static void WriteUInt16(this Stream stream, ushort value)
        {
            stream.Write(value.ToByteArray());
        }

        public static async Task WriteUInt16Async(this Stream stream, ushort value, CancellationToken token)
        {
            await stream.WriteAsync(value.ToByteArray(), token);
        }

        public static async Task WriteUInt16Async(this Stream stream, ushort value)
        {
            await stream.WriteAsync(value.ToByteArray());
        }

        #endregion

        #region Int32

        public static void WriteInt32(this Stream stream, int value)
        {
            stream.Write(value.ToByteArray());
        }

        public static async Task WriteInt32Async(this Stream stream, int value, CancellationToken token)
        {
            await stream.WriteAsync(value.ToByteArray(), token);
        }

        public static async Task WriteInt32Async(this Stream stream, int value)
        {
            await stream.WriteAsync(value.ToByteArray());
        }

        #endregion

        #region UInt32

        public static void WriteUInt32(this Stream stream, uint value)
        {
            stream.Write(value.ToByteArray());
        }

        public static async Task WriteUInt32Async(this Stream stream, uint value, CancellationToken token)
        {
            await stream.WriteAsync(value.ToByteArray(), token);
        }

        public static async Task WriteUInt32Async(this Stream stream, uint value)
        {
            await stream.WriteAsync(value.ToByteArray());
        }

        #endregion

        #region Int64

        public static void WriteInt64(this Stream stream, long value)
        {
            stream.Write(value.ToByteArray());
        }

        public static async Task WriteInt64Async(this Stream stream, long value, CancellationToken token)
        {
            await stream.WriteAsync(value.ToByteArray(), token);
        }

        public static async Task WriteInt64Async(this Stream stream, long value)
        {
            await stream.WriteAsync(value.ToByteArray());
        }

        #endregion

        #region UInt64

        public static void WriteUInt64(this Stream stream, ulong value)
        {
            stream.Write(value.ToByteArray());
        }

        public static async Task WriteUInt64Async(this Stream stream, ulong value, CancellationToken token)
        {
            await stream.WriteAsync(value.ToByteArray(), token);
        }

        public static async Task WriteUInt64Async(this Stream stream, ulong value)
        {
            await stream.WriteAsync(value.ToByteArray());
        }

        #endregion

        #region Double

        public static void WriteDouble(this Stream stream, double value)
        {
            stream.Write(value.ToByteArray());
        }

        public static async Task WriteDoubleAsync(this Stream stream, double value, CancellationToken token)
        {
            await stream.WriteAsync(value.ToByteArray(), token);
        }

        public static async Task WriteDoubleAsync(this Stream stream, double value)
        {
            await stream.WriteAsync(value.ToByteArray());
        }

        #endregion

        #region Single

        public static void WriteSingle(this Stream stream, float value)
        {
            stream.Write(value.ToByteArray());
        }

        public static async Task WriteSingleAsync(this Stream stream, float value, CancellationToken token)
        {
            await stream.WriteAsync(value.ToByteArray(), token);
        }

        public static async Task WriteSingleAsync(this Stream stream, float value)
        {
            await stream.WriteAsync(value.ToByteArray());
        }

        #endregion

        #region Boolean

        public static void WriteBoolean(this Stream stream, bool value)
        {
            stream.Write(value.ToByteArray());
        }

        public static async Task WriteBooleanAsync(this Stream stream, bool value, CancellationToken token)
        {
            await stream.WriteAsync(value.ToByteArray(), token);
        }

        public static async Task WriteBooleanAsync(this Stream stream, bool value)
        {
            await stream.WriteAsync(value.ToByteArray());
        }

        #endregion

        #region Character

        public static void WriteCharacter(this Stream stream, char value, Encoding encoding)
        {
            var bytes = value.ToByteArray(encoding);
            stream.WriteByte((byte) bytes.Length);
            stream.Write(bytes);
        }

        public static async Task WriteCharacterAsync(this Stream stream, char value, Encoding encoding, CancellationToken token)
        {
            await Task.Run(() => WriteCharacter(stream, value, encoding), token);
        }

        public static async Task WriteCharacterAsync(this Stream stream, char value, Encoding encoding)
        {
            await Task.Run(() => WriteCharacter(stream, value, encoding));
        }

        public static IAsyncResult BeginWriteCharacter(this Stream stream, char value, Encoding encoding, AsyncCallback callback, object state)
        {
            var task = Task.Run(() => WriteCharacter(stream, value, encoding));
            callback.Invoke(task);

            return task;
        }

        #endregion

        #region CharacterArray

        public static void WriteCharacterArray(this Stream stream, char[] value, Encoding encoding)
        {
            var bytes = value.ToByteArray(encoding);
            stream.WriteInt32(bytes.Length);
            stream.Write(bytes);
        }

        public static async Task WriteCharacterArrayAsync(this Stream stream, char[] value, Encoding encoding, CancellationToken token)
        {
            await Task.Run(() => WriteCharacterArray(stream, value, encoding), token);
        }

        public static async Task WriteCharacterArrayAsync(this Stream stream, char[] value, Encoding encoding)
        {
            await Task.Run(() => WriteCharacterArray(stream, value, encoding));
        }

        public static IAsyncResult BeginWriteCharacterArray(this Stream stream, char[] value, Encoding encoding, AsyncCallback callback, object state)
        {
            var task = Task.Run(() => WriteCharacterArray(stream, value, encoding));
            callback.Invoke(task);

            return task;
        }

        #endregion

        #region String

        public static void WriteString(this Stream stream, string value, Encoding encoding)
        {
            var bytes = value.ToByteArray(encoding);
            stream.WriteInt32(bytes.Length);
            stream.Write(bytes);
        }

        public static async Task WriteStringAsync(this Stream stream, string value, Encoding encoding, CancellationToken token)
        {
            await Task.Run(() => WriteString(stream, value, encoding), token);
        }

        public static async Task WriteStringAsync(this Stream stream, string value, Encoding encoding)
        {
            await Task.Run(() => WriteString(stream, value, encoding));
        }

        public static IAsyncResult BeginWriteString(this Stream stream, string value, Encoding encoding, AsyncCallback callback, object state)
        {
            var task = Task.Run(() => WriteString(stream, value, encoding));
            callback.Invoke(task);

            return task;
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

        #region SByte

        public static sbyte ReadSByte(this Stream stream)
        {
            var b = stream.ReadByte();
            if (b < 0)
                throw new EndOfStreamException();

            return (sbyte) (byte) b;
        }

        public static async Task<sbyte> ReadSByteAsync(this Stream stream, CancellationToken token)
        {
            return await Task.Run(() => ReadSByte(stream), token);
        }

        public static async Task<sbyte> ReadSByteAsync(this Stream stream)
        {
            return await Task.Run(() => ReadSByte(stream));
        }

        public static IAsyncResult BeginReadSByte(this Stream stream, AsyncCallback callback, object state)
        {
            var task = Task.Run(() => ReadSByte(stream));
            callback.Invoke(task);

            return task;
        }

        public static sbyte EndReadSByte(this Stream stream, IAsyncResult asyncResult)
        {
            var task = asyncResult as Task<sbyte>;
            if (task == null)
                throw new InvalidOperationException("Wrong async result");

            task.Wait();
            return task.Result;
        }

        #endregion

        #region Int16

        public static short ReadInt16(this Stream stream)
        {
            var bytes = new byte[sizeof(short)];
            var read = stream.Read(bytes, 0, bytes.Length);
            if (read <= 0)
                throw new EndOfStreamException();

            return bytes.ToInt16();
        }

        public static async Task<short> ReadInt16Async(this Stream stream, CancellationToken token)
        {
            return await Task.Run(() => ReadInt16(stream), token);
        }

        public static async Task<short> ReadInt16Async(this Stream stream)
        {
            return await Task.Run(() => ReadInt16(stream));
        }

        public static IAsyncResult BeginReadInt16(this Stream stream, AsyncCallback callback, object state)
        {
            var task = Task.Run(() => ReadInt16(stream));
            callback.Invoke(task);

            return task;
        }

        public static short EndReadInt16(this Stream stream, IAsyncResult asyncResult)
        {
            var task = asyncResult as Task<short>;
            if (task == null)
                throw new InvalidOperationException("Wrong async result");

            task.Wait();
            return task.Result;
        }

        #endregion

        #region UInt16

        public static ushort ReadUInt16(this Stream stream)
        {
            var bytes = new byte[sizeof(ushort)];
            var read = stream.Read(bytes, 0, bytes.Length);
            if (read <= 0)
                throw new EndOfStreamException();

            return bytes.ToUInt16();
        }

        public static async Task<ushort> ReadUInt16Async(this Stream stream, CancellationToken token)
        {
            return await Task.Run(() => ReadUInt16(stream), token);
        }

        public static async Task<ushort> ReadUInt16Async(this Stream stream)
        {
            return await Task.Run(() => ReadUInt16(stream));
        }

        public static IAsyncResult BeginReadUInt16(this Stream stream, AsyncCallback callback, object state)
        {
            var task = Task.Run(() => ReadUInt16(stream));
            callback.Invoke(task);

            return task;
        }

        public static ushort EndReadUInt16(this Stream stream, IAsyncResult asyncResult)
        {
            var task = asyncResult as Task<ushort>;
            if (task == null)
                throw new InvalidOperationException("Wrong async result");

            task.Wait();
            return task.Result;
        }

        #endregion

        #region Int32

        public static int ReadInt32(this Stream stream)
        {
            var bytes = new byte[sizeof(int)];
            var read = stream.Read(bytes, 0, bytes.Length);
            if (read <= 0)
                throw new EndOfStreamException();

            return bytes.ToInt32();
        }

        public static async Task<int> ReadInt32Async(this Stream stream, CancellationToken token)
        {
            return await Task.Run(() => ReadInt32(stream), token);
        }

        public static async Task<int> ReadInt32Async(this Stream stream)
        {
            return await Task.Run(() => ReadInt32(stream));
        }

        public static IAsyncResult BeginReadInt32(this Stream stream, AsyncCallback callback, object state)
        {
            var task = Task.Run(() => ReadInt32(stream));
            callback.Invoke(task);

            return task;
        }

        public static int EndReadInt32(this Stream stream, IAsyncResult asyncResult)
        {
            var task = asyncResult as Task<int>;
            if (task == null)
                throw new InvalidOperationException("Wrong async result");

            task.Wait();
            return task.Result;
        }

        #endregion

        #region UInt32

        public static uint ReadUInt32(this Stream stream)
        {
            var bytes = new byte[sizeof(uint)];
            var read = stream.Read(bytes, 0, bytes.Length);
            if (read <= 0)
                throw new EndOfStreamException();

            return bytes.ToUInt32();
        }

        public static async Task<uint> ReadUInt32Async(this Stream stream, CancellationToken token)
        {
            return await Task.Run(() => ReadUInt32(stream), token);
        }

        public static async Task<uint> ReadUInt32Async(this Stream stream)
        {
            return await Task.Run(() => ReadUInt32(stream));
        }

        public static IAsyncResult BeginReadUInt32(this Stream stream, AsyncCallback callback, object state)
        {
            var task = Task.Run(() => ReadUInt32(stream));
            callback.Invoke(task);

            return task;
        }

        public static uint EndReadUInt32(this Stream stream, IAsyncResult asyncResult)
        {
            var task = asyncResult as Task<uint>;
            if (task == null)
                throw new InvalidOperationException("Wrong async result");

            task.Wait();
            return task.Result;
        }

        #endregion

        #region Int64

        public static long ReadInt64(this Stream stream)
        {
            var bytes = new byte[sizeof(long)];
            var read = stream.Read(bytes, 0, bytes.Length);
            if (read <= 0)
                throw new EndOfStreamException();

            return bytes.ToInt64();
        }

        public static async Task<long> ReadInt64Async(this Stream stream, CancellationToken token)
        {
            return await Task.Run(() => ReadInt64(stream), token);
        }

        public static async Task<long> ReadInt64Async(this Stream stream)
        {
            return await Task.Run(() => ReadInt64(stream));
        }

        public static IAsyncResult BeginReadInt64(this Stream stream, AsyncCallback callback, object state)
        {
            var task = Task.Run(() => ReadInt64(stream));
            callback.Invoke(task);

            return task;
        }

        public static long EndReadInt64(this Stream stream, IAsyncResult asyncResult)
        {
            var task = asyncResult as Task<long>;
            if (task == null)
                throw new InvalidOperationException("Wrong async result");

            task.Wait();
            return task.Result;
        }

        #endregion

        #region UInt64

        public static ulong ReadUInt64(this Stream stream)
        {
            var bytes = new byte[sizeof(ulong)];
            var read = stream.Read(bytes, 0, bytes.Length);
            if (read <= 0)
                throw new EndOfStreamException();

            return bytes.ToUInt64();
        }

        public static async Task<ulong> ReadUInt64Async(this Stream stream, CancellationToken token)
        {
            return await Task.Run(() => ReadUInt64(stream), token);
        }

        public static async Task<ulong> ReadUInt64Async(this Stream stream)
        {
            return await Task.Run(() => ReadUInt64(stream));
        }

        public static IAsyncResult BeginReadUInt64(this Stream stream, AsyncCallback callback, object state)
        {
            var task = Task.Run(() => ReadUInt64(stream));
            callback.Invoke(task);

            return task;
        }

        public static ulong EndReadUInt64(this Stream stream, IAsyncResult asyncResult)
        {
            var task = asyncResult as Task<ulong>;
            if (task == null)
                throw new InvalidOperationException("Wrong async result");

            task.Wait();
            return task.Result;
        }

        #endregion

        #region Double

        public static double ReadDouble(this Stream stream)
        {
            var bytes = new byte[sizeof(double)];
            var read = stream.Read(bytes, 0, bytes.Length);
            if (read <= 0)
                throw new EndOfStreamException();

            return bytes.ToDouble();
        }

        public static async Task<double> ReadDoubleAsync(this Stream stream, CancellationToken token)
        {
            return await Task.Run(() => ReadDouble(stream), token);
        }

        public static async Task<double> ReadDoubleAsync(this Stream stream)
        {
            return await Task.Run(() => ReadDouble(stream));
        }

        public static IAsyncResult BeginReadDouble(this Stream stream, AsyncCallback callback, object state)
        {
            var task = Task.Run(() => ReadDouble(stream));
            callback.Invoke(task);

            return task;
        }

        public static double EndReadDouble(this Stream stream, IAsyncResult asyncResult)
        {
            var task = asyncResult as Task<double>;
            if (task == null)
                throw new InvalidOperationException("Wrong async result");

            task.Wait();
            return task.Result;
        }

        #endregion

        #region Single

        public static float ReadSingle(this Stream stream)
        {
            var bytes = new byte[sizeof(float)];
            var read = stream.Read(bytes, 0, bytes.Length);
            if (read <= 0)
                throw new EndOfStreamException();

            return bytes.ToSingle();
        }

        public static async Task<float> ReadSingleAsync(this Stream stream, CancellationToken token)
        {
            return await Task.Run(() => ReadSingle(stream), token);
        }

        public static async Task<float> ReadSingleAsync(this Stream stream)
        {
            return await Task.Run(() => ReadSingle(stream));
        }

        public static IAsyncResult BeginReadSingle(this Stream stream, AsyncCallback callback, object state)
        {
            var task = Task.Run(() => ReadSingle(stream));
            callback.Invoke(task);

            return task;
        }

        public static float EndReadSingle(this Stream stream, IAsyncResult asyncResult)
        {
            var task = asyncResult as Task<float>;
            if (task == null)
                throw new InvalidOperationException("Wrong async result");

            task.Wait();
            return task.Result;
        }

        #endregion

        #region Boolean

        public static bool ReadBoolean(this Stream stream)
        {
            var bytes = new byte[sizeof(bool)];
            var read = stream.Read(bytes, 0, bytes.Length);
            if (read <= 0)
                throw new EndOfStreamException();

            return bytes.ToBoolean();
        }

        public static async Task<bool> ReadBooleanAsync(this Stream stream, CancellationToken token)
        {
            return await Task.Run(() => ReadBoolean(stream), token);
        }

        public static async Task<bool> ReadBooleanAsync(this Stream stream)
        {
            return await Task.Run(() => ReadBoolean(stream));
        }

        public static IAsyncResult BeginReadBoolean(this Stream stream, AsyncCallback callback, object state)
        {
            var task = Task.Run(() => ReadBoolean(stream));
            callback.Invoke(task);

            return task;
        }

        public static bool EndReadBoolean(this Stream stream, IAsyncResult asyncResult)
        {
            var task = asyncResult as Task<bool>;
            if (task == null)
                throw new InvalidOperationException("Wrong async result");

            task.Wait();
            return task.Result;
        }

        #endregion

        #region Character

        public static char ReadCharacter(this Stream stream, Encoding encoding)
        {
            var length = stream.ReadByte();
            if (length < 0)
                throw new EndOfStreamException();
            var bytes = stream.ReadFully(length);

            return bytes.ToCharacter(encoding);
        }

        public static async Task<char> ReadCharacterAsync(this Stream stream, Encoding encoding, CancellationToken token)
        {
            return await Task.Run(() => ReadCharacter(stream, encoding), token);
        }

        public static async Task<char> ReadCharacterAsync(this Stream stream, Encoding encoding)
        {
            return await Task.Run(() => ReadCharacter(stream, encoding));
        }

        public static IAsyncResult BeginReadCharacter(this Stream stream, Encoding encoding, AsyncCallback callback, object state)
        {
            var task = Task.Run(() => ReadCharacter(stream, encoding));
            callback.Invoke(task);

            return task;
        }

        public static char EndReadCharacter(this Stream stream, IAsyncResult asyncResult)
        {
            var task = asyncResult as Task<char>;
            if (task == null)
                throw new InvalidOperationException("Wrong async result");

            task.Wait();
            return task.Result;
        }

        #endregion

        #region CharacterArray

        public static char[] ReadCharacterArray(this Stream stream, Encoding encoding)
        {
            var length = stream.ReadInt32();
            var bytes = stream.ReadFully(length);

            return bytes.ToCharacterArray(encoding);
        }

        public static async Task<char[]> ReadCharacterArrayAsync(this Stream stream, Encoding encoding, CancellationToken token)
        {
            return await Task.Run(() => ReadCharacterArray(stream, encoding), token);
        }

        public static async Task<char[]> ReadCharacterArrayAsync(this Stream stream, Encoding encoding)
        {
            return await Task.Run(() => ReadCharacterArray(stream, encoding));
        }

        public static IAsyncResult BeginReadCharacterArray(this Stream stream, Encoding encoding, AsyncCallback callback, object state)
        {
            var task = Task.Run(() => ReadCharacterArray(stream, encoding));
            callback.Invoke(task);

            return task;
        }

        public static char[] EndReadCharacterArray(this Stream stream, IAsyncResult asyncResult)
        {
            var task = asyncResult as Task<char[]>;
            if (task == null)
                throw new InvalidOperationException("Wrong async result");

            task.Wait();
            return task.Result;
        }

        #endregion

        #region String

        public static string ReadString(this Stream stream, Encoding encoding)
        {
            var length = stream.ReadInt32();
            var bytes = stream.ReadFully(length);

            return bytes.ToString(encoding);
        }

        public static async Task<string> ReadStringAsync(this Stream stream, Encoding encoding, CancellationToken token)
        {
            return await Task.Run(() => ReadString(stream, encoding), token);
        }

        public static async Task<string> ReadStringAsync(this Stream stream, Encoding encoding)
        {
            return await Task.Run(() => ReadString(stream, encoding));
        }

        public static IAsyncResult BeginReadString(this Stream stream, Encoding encoding, AsyncCallback callback, object state)
        {
            var task = Task.Run(() => ReadString(stream, encoding));
            callback.Invoke(task);

            return task;
        }

        public static string EndReadString(this Stream stream, IAsyncResult asyncResult)
        {
            var task = asyncResult as Task<string>;
            if (task == null)
                throw new InvalidOperationException("Wrong async result");

            task.Wait();
            return task.Result;
        }

        #endregion

        #endregion
    }
}