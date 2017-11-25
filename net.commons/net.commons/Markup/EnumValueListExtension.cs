#region

using System;
using System.Linq;
using System.Windows.Markup;

#endregion

namespace Net.Commons.Markup
{
    [MarkupExtensionReturnType(typeof(Enum[]))]
    public class EnumValueListExtension : MarkupExtension
    {
        public Type Type { get; set; }
        public bool WithNoneItem { get; set; } = false;
        public string NoneItemString { get; set; } = "<None>";

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
            var values = Enum.GetValues(Type).Cast<object>().ToList();
            if (WithNoneItem)
            {
                values.Insert(0, NoneItemString);
            }

            return values.ToArray();
        }
    }
}