using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;

namespace net.commons.Markup
{
    [MarkupExtensionReturnType(typeof(int))]
    public class IntegerExtension : MarkupExtension
    {
        public long Value { get; set; }
        public IntegerType Type { get; set; } = IntegerType.Int32;

        public IntegerExtension()
        {
        }

        public IntegerExtension(long value)
        {
            Value = value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            switch (Type)
            {
                case IntegerType.Int64:
                    return Value;
                case IntegerType.Int32:
                    return (int) Value;
                case IntegerType.Int16:
                    return (short) Value;
                case IntegerType.Byte:
                    return (sbyte) Value;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    [MarkupExtensionReturnType(typeof(int))]
    public class UnsignedIntegerExtension : MarkupExtension
    {
        public ulong Value { get; set; }
        public IntegerType Type { get; set; } = IntegerType.Int32;

        public UnsignedIntegerExtension()
        {
        }

        public UnsignedIntegerExtension(ulong value)
        {
            Value = value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            switch (Type)
            {
                case IntegerType.Int64:
                    return Value;
                case IntegerType.Int32:
                    return (uint) Value;
                case IntegerType.Int16:
                    return (ushort) Value;
                case IntegerType.Byte:
                    return (byte) Value;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    [MarkupExtensionReturnType(typeof(double))]
    public class DecimalExtension : MarkupExtension
    {
        public double Value { get; set; }
        public DecimalType Type { get; set; } = DecimalType.Double;

        public DecimalExtension()
        {
        }

        public DecimalExtension(double value)
        {
            Value = value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            switch (Type)
            {
                case DecimalType.Double:
                    return Value;
                case DecimalType.Float:
                    return (float) Value;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    [MarkupExtensionReturnType(typeof(bool))]
    public class BooleanExtension : MarkupExtension
    {
        public bool Value { get; set; }

        public BooleanExtension()
        {
        }

        public BooleanExtension(bool value)
        {
            Value = value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }

    [MarkupExtensionReturnType(typeof(char))]
    public class CharacterExtension : MarkupExtension
    {
        public char Value { get; set; }

        public CharacterExtension()
        {
        }

        public CharacterExtension(char value)
        {
            Value = value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }

    [MarkupExtensionReturnType(typeof(string))]
    public class StringExtension : MarkupExtension
    {
        public string Value { get; set; }

        public StringExtension()
        {
        }

        public StringExtension(string value)
        {
            Value = value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value;
        }
    }

    public enum IntegerType
    {
        Int64,
        Int32,
        Int16,
        Byte
    }

    public enum DecimalType
    {
        Double,
        Float
    }
}