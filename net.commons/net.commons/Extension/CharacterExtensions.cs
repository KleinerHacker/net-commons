using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.commons.Extension
{
    public static class CharacterExtensions
    {
        public static byte[] ToByteArray(this char value)
        {
            return BitConverter.GetBytes(value);
        }

        public static char ToCharacter(this byte[] value, int startIndex = 0)
        {
            return BitConverter.ToChar(value, startIndex);
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
