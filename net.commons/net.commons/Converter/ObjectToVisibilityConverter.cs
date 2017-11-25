using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Net.Commons.Markup.Parameter;

namespace Net.Commons.Converter
{
    [ValueConversion(typeof(object), typeof(Visibility), ParameterType = typeof(IObjectToVisibilityParam))]
    public class ObjectToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && !(parameter is IObjectToVisibilityParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(ObjectToVisibilityConverter)}: Needed is {nameof(IObjectToVisibilityParam)}");

            var param = (IObjectToVisibilityParam) parameter ?? new ObjectToVisibilityParamExtension().Build();

            var hiddenVisibility = param.ManageLayout ? Visibility.Hidden : Visibility.Collapsed;
            var isTrueVisibility = !param.Invert ? Visibility.Visible : hiddenVisibility;
            var isFalseVisibility = !param.Invert ? hiddenVisibility : Visibility.Visible;

            if ((value == null || value == DependencyProperty.UnsetValue) && param.ReferenceValue == null)
                return isTrueVisibility;
            if (value == null)
                return isFalseVisibility;

            return value.Equals(param.ReferenceValue) ? isTrueVisibility : isFalseVisibility;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && !(parameter is IObjectToVisibilityParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(ObjectToVisibilityConverter)}: Needed is {nameof(IObjectToVisibilityParam)}");

            var param = (IObjectToVisibilityParam)parameter ?? new ObjectToVisibilityParamExtension().Build();

            switch ((Visibility) value)
            {
                case Visibility.Hidden:
                case Visibility.Collapsed:
                    return param.Invert ? param.ReferenceValue : Binding.DoNothing;
                case Visibility.Visible:
                    return param.Invert ? Binding.DoNothing : param.ReferenceValue;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}