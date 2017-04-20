#region

using System;
using System.Windows.Markup;

#endregion

namespace net.commons.Markup
{
    public class EnumValueExtension : MarkupExtension
    {
        public Type Type { get; set; }
        public string Value { get; set; }

        public EnumValueExtension()
        {
        }

        public EnumValueExtension(Type type, string value)
        {
            if (type == null || !type.IsEnum)
            {
                throw new ArgumentNullException(nameof(type));
            }
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }
            Type = type;
            Value = value;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.Parse(Type, Value);
        }
    }
}