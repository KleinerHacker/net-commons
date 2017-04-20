#region

using System;
using System.Windows.Markup;

#endregion

namespace net.commons.Markup
{
    public class EnumValueListExtension : MarkupExtension
    {
        public Type Type { get; set; }

        public EnumValueListExtension()
        {
        }

        public EnumValueListExtension(Type type)
        {
            if (type == null || !type.IsEnum)
            {
                throw new ArgumentNullException(nameof(type));
            }
            Type = type;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(Type);
        }
    }
}