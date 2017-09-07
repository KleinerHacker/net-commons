using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace net.commons.Markup
{
    [MarkupExtensionReturnType(typeof(long[]))]
    public class IntegerArrayExtension : MarkupExtension
    {
        public long[] Array { get; set; }
        public IntegerType Type { get; set; } = IntegerType.Int32;

        public IntegerArrayExtension()
        {
        }

        public IntegerArrayExtension(long value)
        {
            Array = new[] {value};
        }

        public IntegerArrayExtension(long value, int size)
        {
            Array = new long[size];
            for (var i = 0; i < size; i++)
            {
                Array[i] = value;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            switch (Type)
            {
                case IntegerType.Int64:
                    return Array;
                case IntegerType.Int32:
                    return Array.Select(item => (int) item).ToArray();
                case IntegerType.Int16:
                    return Array.Select(item => (short) item).ToArray();
                case IntegerType.Byte:
                    return Array.Select(item => (sbyte) item).ToArray();
                default:
                    throw new NotImplementedException();
            }
        }
    }

    [MarkupExtensionReturnType(typeof(ulong[]))]
    public class UnsignedIntegerArrayExtension : MarkupExtension
    {
        public ulong[] Array { get; set; }
        public IntegerType Type { get; set; } = IntegerType.Int32;

        public UnsignedIntegerArrayExtension()
        {
        }

        public UnsignedIntegerArrayExtension(ulong value)
        {
            Array = new[] { value };
        }

        public UnsignedIntegerArrayExtension(ulong value, int size)
        {
            Array = new ulong[size];
            for (var i = 0; i < size; i++)
            {
                Array[i] = value;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            switch (Type)
            {
                case IntegerType.Int64:
                    return Array;
                case IntegerType.Int32:
                    return Array.Select(item => (uint)item).ToArray();
                case IntegerType.Int16:
                    return Array.Select(item => (ushort)item).ToArray();
                case IntegerType.Byte:
                    return Array.Select(item => (byte)item).ToArray();
                default:
                    throw new NotImplementedException();
            }
        }
    }

    [MarkupExtensionReturnType(typeof(double[]))]
    public class DecimalArrayExtension : MarkupExtension
    {
        public double[] Array { get; set; }
        public DecimalType Type { get; set; } = DecimalType.Double;

        public DecimalArrayExtension()
        {
        }

        public DecimalArrayExtension(double value)
        {
            Array = new[] { value };
        }

        public DecimalArrayExtension(double value, int size)
        {
            Array = new double[size];
            for (var i = 0; i < size; i++)
            {
                Array[i] = value;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            switch (Type)
            {
                case DecimalType.Double:
                    return Array;
                case DecimalType.Float:
                    return Array.Select(item => (float) item).ToArray();
                default:
                    throw new NotImplementedException();
            }
        }
    }

    [MarkupExtensionReturnType(typeof(bool[]))]
    public class BooleanArrayExtension : MarkupExtension
    {
        public bool[] Array { get; set; }

        public BooleanArrayExtension()
        {
        }

        public BooleanArrayExtension(bool value)
        {
            Array = new[] { value };
        }

        public BooleanArrayExtension(bool value, int size)
        {
            Array = new bool[size];
            for (var i = 0; i < size; i++)
            {
                Array[i] = value;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Array;
        }
    }

    [MarkupExtensionReturnType(typeof(char[]))]
    public class CharacterArrayExtension : MarkupExtension
    {
        public char[] Array { get; set; }

        public CharacterArrayExtension()
        {
        }

        public CharacterArrayExtension(char value)
        {
            Array = new[] { value };
        }

        public CharacterArrayExtension(char value, int size)
        {
            Array = new char[size];
            for (var i = 0; i < size; i++)
            {
                Array[i] = value;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Array;
        }
    }

    [MarkupExtensionReturnType(typeof(string[]))]
    public class StringArrayExtension : MarkupExtension
    {
        public string[] Array { get; set; }

        public StringArrayExtension()
        {
        }

        public StringArrayExtension(string value)
        {
            Array = new[] { value };
        }

        public StringArrayExtension(string value, int size)
        {
            Array = new string[size];
            for (var i = 0; i < size; i++)
            {
                Array[i] = value;
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Array;
        }
    }
}