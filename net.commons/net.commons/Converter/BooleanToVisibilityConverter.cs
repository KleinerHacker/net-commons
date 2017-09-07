using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Microsoft.VisualBasic;
using net.commons.Markup;
using net.commons.Markup.Parameter;

namespace net.commons.Converter
{
    [ValueConversion(typeof(bool), typeof(Visibility), ParameterType = typeof(BooleanToVisibilityParam))]
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null &&  !(parameter is IBooleanToVisibilityParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(BooleanToVisibilityConverter)}: Needed is {nameof(IBooleanToVisibilityParam)}");

            var param = (IBooleanToVisibilityParam) parameter ?? new BooleanToVisibilityParamExtension().Build();

            var hiddenVisibility = param.ManageLayout ? Visibility.Hidden : Visibility.Collapsed;
            var isTrueVisibility = !param.Invert ? Visibility.Visible : hiddenVisibility;
            var isFalseVisibility = !param.Invert ? hiddenVisibility : Visibility.Visible;

            if (value == null || !(bool) value)
                return isFalseVisibility;

            return isTrueVisibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && !(parameter is IBooleanToVisibilityParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(BooleanToVisibilityConverter)}: Needed is {nameof(IBooleanToVisibilityParam)}");

            var param = (IBooleanToVisibilityParam)parameter ?? new BooleanToVisibilityParamExtension().Build();

            if (value == null)
                return false;

            switch ((Visibility) value)
            {
                case Visibility.Collapsed:
                case Visibility.Hidden:
                    return param.Invert;
                case Visibility.Visible:
                    return !param.Invert;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}