#region

using System;
using System.Text;

#endregion

namespace net.commons.Extension
{
    public static class CharacterExtensions
    {
        public static byte[] ToByteArray(this char value)
        {
            return ToByteArray(value, Encoding.Default);
        }

        public static byte[] ToByteArray(this char value, Encoding encoding)
        {
            return new[] {value}.ToByteArray(encoding);
        }

        public static char ToCharacter(this byte[] value, int startIndex = 0)
        {
            return ToCharacter(value, Encoding.Default, startIndex);
        }

        public static char ToCharacter(this byte[] value, Encoding encoding, int startIndex = 0)
        {
            if (value.IsEmpty())
                throw new ArgumentException("Empty byte array");

            return value.ToCharacterArray(encoding, startIndex)[0];
        }

        public static byte[] ToByteArray(this char[] value)
        {
            return ToByteArray(value, Encoding.Default);
        }

        public static byte[] ToByteArray(this char[] value, Encoding encoding)
        {
            return encoding.GetBytes(value);
        }

        public static char[] ToCharacterArray(this byte[] value, int startIndex = 0)
        {
            return ToCharacterArray(value, Encoding.Default, startIndex);
        }

        public static char[] ToCharacterArray(this byte[] value, Encoding encoding, int startIndex = 0)
        {
            return encoding.GetChars(value, startIndex, value.Length - startIndex);
        }
    }
}