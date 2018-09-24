#region

using System;
using System.Globalization;
using System.Text;

#endregion

namespace Net.Commons.Extension
{
    public static class CharacterExtensions
    {
        public static byte[] ToByteArray(this char value, Encoding encoding)
        {
            return new[] {value}.ToByteArray(encoding);
        }

        public static char ToCharacter(this byte[] value, Encoding encoding, int startIndex = 0)
        {
            if (value.IsEmpty())
                throw new ArgumentException("Empty byte array");

            return value.ToCharacterArray(encoding, startIndex)[0];
        }

        public static byte[] ToByteArray(this char[] value, Encoding encoding)
        {
            return encoding.GetBytes(value);
        }

        public static char[] ToCharacterArray(this byte[] value, Encoding encoding, int startIndex = 0)
        {
            return encoding.GetChars(value, startIndex, value.Length - startIndex);
        }

        public static char ToUpper(this char value)
        {
            return ToUpper(value);
        }

        public static char ToLower(this char value)
        {
            return ToLower(value);
        }
    }
}