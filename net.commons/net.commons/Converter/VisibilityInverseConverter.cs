using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace net.commons.Converter
{
    [ValueConversion(typeof(Visibility), typeof(Visibility), ParameterType = typeof(bool))]
    public class VisibilityInverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || (Visibility) value != Visibility.Visible)
            {
                return Visibility.Visible;
            }
            else
            {
                return ConvertToVisibility(parameter);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }

        private Visibility ConvertToVisibility(object param)
        {
            if (param == null || !(bool)param)
                return Visibility.Collapsed;

            return Visibility.Hidden;
        }
    }
}
