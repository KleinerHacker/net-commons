#region

using System;
using System.Windows.Markup;

#endregion

namespace net.commons.Markup
{
    public class NativeValueExtension : MarkupExtension
    {
        public NativeType Type { get; set; }
        public string Value { get; set; }

        public NativeValueExtension()
        {
        }

        public NativeValueExtension(NativeType type, string value)
        {
            Type = type;
            Value = value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            switch (Type)
            {
                case NativeType.Boolean:
                    return Boolean.Parse(Value);
                case NativeType.Integer:
                    return Int64.Parse(Value);
                case NativeType.Decimal:
                    return Double.Parse(Value);
                case NativeType.Character:
                    return Char.Parse(Value);
                default:
                    throw new NotImplementedException();
            }
        }
    }

    public enum NativeType
    {
        Boolean,
        Integer,
        Decimal,
        Character
    }
}