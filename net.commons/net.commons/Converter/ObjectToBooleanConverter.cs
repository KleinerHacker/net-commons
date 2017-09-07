using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using net.commons.Markup.Parameter;

namespace net.commons.Converter
{
    [ValueConversion(typeof(object), typeof(bool), ParameterType = typeof(IObjectToBooleanParam))]
    public class ObjectToBooleanConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && !(parameter is IObjectToBooleanParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(ObjectToBooleanConverter)}: Needed is {nameof(IObjectToBooleanParam)}");

            var param = (IObjectToBooleanParam) parameter ?? new ObjectToBooleanParamExtension().Build();

            var isTrue = !param.Invert;
            var isFalse = param.Invert;

            if ((value == null || value == DependencyProperty.UnsetValue) && param.ReferenceValue == null)
                return isTrue;
            if (value == null)
                return isFalse;

            return value.Equals(param.ReferenceValue) ? isTrue : isFalse;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && !(parameter is IObjectToBooleanParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(ObjectToBooleanConverter)}: Needed is {nameof(IObjectToBooleanParam)}");

            var param = (IObjectToBooleanParam)parameter ?? new ObjectToBooleanParamExtension().Build();

            var isTrue = !param.Invert ? param.ReferenceValue : Binding.DoNothing;
            var isFalse = !param.Invert ? Binding.DoNothing : param.ReferenceValue;

            return (bool) value ? isTrue : isFalse;
        }
    }
}