#region

using System;
using System.Linq;
using System.Reflection;
using Windows.UI.Xaml.Markup;

#endregion

namespace Net.Commons.Markup
{
    [MarkupExtensionReturnType(ReturnType = typeof(Enum[]))]
    public class EnumValueListExtension : MarkupExtension
    {
        public System.Type Type { get; set; }
        public bool WithNoneItem { get; set; } = false;
        public string NoneItemString { get; set; } = "<None>";

        public EnumValueListExtension()
        {
        }

        public EnumValueListExtension(System.Type type)
        {
            if (type == null || !type.GetTypeInfo().IsEnum)
            {
                throw new ArgumentNullException(nameof(type));
            }
            Type = type;
        }

        protected override object ProvideValue()
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