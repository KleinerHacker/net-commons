#region

using System;

#endregion

namespace net.commons.Extension
{
    public static class NumberExtensions
    {
        #region ToByteArray

        public static byte[] ToByteArray(this long value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToByteArray(this ulong value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToByteArray(this int value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToByteArray(this uint value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToByteArray(this short value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToByteArray(this ushort value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToByteArray(this byte value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToByteArray(this sbyte value)
        {
            return new[] {(byte) value};
        }

        public static byte[] ToByteArray(this float value)
        {
            return BitConverter.GetBytes(value);
        }

        public static byte[] ToByteArray(this double value)
        {
            return BitConverter.GetBytes(value);
        }

        #endregion

        #region FromByteArray

        public static long ToInt64(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToInt64(bytes, startIndex);
        }

        public static ulong ToUInt64(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToUInt64(bytes, startIndex);
        }

        public static int ToInt32(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToInt32(bytes, startIndex);
        }

        public static uint ToUInt32(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToUInt32(bytes, startIndex);
        }

        public static short ToInt16(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToInt16(bytes, startIndex);
        }

        public static ushort ToUInt16(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToUInt16(bytes, startIndex);
        }

        public static byte ToByte(this byte[] bytes, int startIndex = 0)
        {
            return bytes[startIndex];
        }

        public static sbyte ToSByte(this byte[] bytes, int startIndex = 0)
        {
            return (sbyte) bytes[startIndex];
        }

        public static double ToDouble(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToDouble(bytes, startIndex);
        }

        public static float ToSingle(this byte[] bytes, int startIndex = 0)
        {
            return BitConverter.ToSingle(bytes, startIndex);
        }

        #endregion

        #region Contains

        public static bool Contains(this long value, long second)
        {
            return (value & second) == second;
        }

        public static bool Contains(this ulong value, ulong second)
        {
            return (value & second) == second;
        }

        public static bool Contains(this int value, int second)
        {
            return (value & second) == second;
        }

        public static bool Contains(this uint value, uint second)
        {
            return (value & second) == second;
        }

        public static bool Contains(this short value, short second)
        {
            return (value & second) == second;
        }

        public static bool Contains(this ushort value, ushort second)
        {
            return (value & second) == second;
        }

        public static bool Contains(this byte value, byte second)
        {
            return (value & second) == second;
        }

        public static bool Contains(this sbyte value, sbyte second)
        {
            return (value & second) == second;
        }

        #endregion
    }
}