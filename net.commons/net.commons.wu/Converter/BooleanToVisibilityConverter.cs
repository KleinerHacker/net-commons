using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Microsoft.VisualBasic;
using Net.Commons.Markup;
using Net.Commons.Markup.Parameter;

namespace Net.Commons.Converter
{
    /// \ingroup wpf_single_converter
    /// <summary>
    /// Convert a boolean value to a visibility value based on an optional parameter of type <see cref="IBooleanToVisibilityParam"/>. 
    /// The parameter can used as Markup Extension, see <see cref="BooleanToVisibilityParamExtension"/>
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, string culture)
        {
            if (parameter != null &&  !(parameter is IBooleanToVisibilityParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(BooleanToVisibilityConverter)}: Needed is {nameof(IBooleanToVisibilityParam)}");

            var param = (IBooleanToVisibilityParam) parameter ?? new BooleanToVisibilityParamExtension().Build();
            
            var isTrueVisibility = !param.Invert ? Visibility.Visible : Visibility.Collapsed;
            var isFalseVisibility = !param.Invert ? Visibility.Collapsed : Visibility.Visible;

            if (value == null || !(bool) value)
                return isFalseVisibility;

            return isTrueVisibility;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string culture)
        {
            if (parameter != null && !(parameter is IBooleanToVisibilityParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(BooleanToVisibilityConverter)}: Needed is {nameof(IBooleanToVisibilityParam)}");

            var param = (IBooleanToVisibilityParam)parameter ?? new BooleanToVisibilityParamExtension().Build();

            if (value == null)
                return false;

            switch ((Visibility) value)
            {
                case Visibility.Collapsed:
                    return param.Invert;
                case Visibility.Visible:
                    return !param.Invert;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}