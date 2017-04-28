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
    [ValueConversion(typeof(Visibility), typeof(Visibility))]
    public class VisibilityManageLayoutConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || (Visibility) value == Visibility.Visible)
            {
                return value;
            }

            switch ((Visibility) value)
            {
                case Visibility.Collapsed:
                    return Visibility.Hidden;
                case Visibility.Hidden:
                    return Visibility.Collapsed;
                default:
                    throw new NotImplementedException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}