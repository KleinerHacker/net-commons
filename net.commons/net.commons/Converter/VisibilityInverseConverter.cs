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
    [ValueConversion(typeof(Visibility), typeof(Visibility), ParameterType = typeof(IVisibilityInverseParam))]
    public class VisibilityInverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Handle(value, parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Handle(value, parameter);
        }

        private static object Handle(object value, object parameter)
        {
            if (parameter != null && !(parameter is IVisibilityInverseParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(VisibilityInverseConverter)}: Needed is {nameof(IVisibilityInverseParam)}");

            var param = (IVisibilityInverseParam)parameter ?? new VisibilityInverseParamExtension().Build();

            if (value == null || (Visibility)value != Visibility.Visible)
            {
                return Visibility.Visible;
            }
            else
            {
                return param.ManageLayout ? Visibility.Hidden : Visibility.Collapsed;
            }
        }
    }
}
