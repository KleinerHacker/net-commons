using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Net.Commons.Converter
{
    /// \ingroup wpf_single_converter
    /// <summary>
    /// Represent a value converter to convert a visibility value in case of hidden / collapsed to the inverted state of managed layout. There are no needed parameters.
    /// </summary>
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