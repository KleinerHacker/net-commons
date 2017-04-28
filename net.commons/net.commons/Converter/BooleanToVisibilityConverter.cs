using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using net.commons.Markup;

namespace net.commons.Converter
{
    [ValueConversion(typeof(bool), typeof(Visibility), ParameterType = typeof(VisibilityParam))]
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibilityParam = AnalyzeAndGetParam(parameter);

            if (value == null || !(bool) value)
            {
                return visibilityParam.Inverse ? Visibility.Visible : ConvertToHiddenOrCollapse(visibilityParam.ManageLayout);
            }
            else
            {
                return visibilityParam.Inverse ? ConvertToHiddenOrCollapse(visibilityParam.ManageLayout) : Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibilityParam = AnalyzeAndGetParam(parameter);

            return visibilityParam.Inverse ? value == null || (Visibility) value != Visibility.Visible : value != null && (Visibility) value == Visibility.Visible;
        }

        private static VisibilityParam AnalyzeAndGetParam(object parameter)
        {
            if (parameter != null && !(parameter is VisibilityParam))
            {
                throw new ArgumentException("parameter for this converter must be " + nameof(VisibilityParam) + ", set with " + nameof(VisibilityParamExtension));
            }

            var visibilityParam = parameter == null ? new VisibilityParamExtension().Build() : (VisibilityParam)parameter;
            return visibilityParam;
        }

        private Visibility ConvertToHiddenOrCollapse(bool manageLayout)
        {
            return manageLayout ? Visibility.Hidden : Visibility.Collapsed;
        }
    }
}
