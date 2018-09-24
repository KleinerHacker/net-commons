using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Net.Commons.Markup.Parameter;

namespace Net.Commons.Converter
{
    /// \ingroup wpf_single_converter
    /// <summary>
    /// Represent a value converter to convert a visibility value to an other visibility value based on an optional parameter of type <see cref="IVisibilityInverseParam"/>. 
    /// The parameter can used as Markup Extension, see <see cref="VisibilityInverseParamExtension"/>
    /// </summary>
    public class VisibilityInverseConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, string culture)
        {
            return Handle(value, parameter);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string culture)
        {
            return Handle(value, parameter);
        }

        private static object Handle(object value, object parameter)
        {
            if (value == null || (Visibility)value != Visibility.Visible)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }
    }
}
