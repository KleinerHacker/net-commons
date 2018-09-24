using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Net.Commons.Converter
{
    /// \ingroup wpf_single_converter
    /// <summary>
    /// Represent a value converter to inverse a boolean value. There are no specific parameters.
    /// </summary>
    public class InvertBooleanConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, string language)
        {
            return !((bool) value);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string language)
        {
            return !((bool) value);
        }
    }
}
