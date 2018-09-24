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
    /// Represent a value converter to convert an object value to a visibility value based on an optional parameter of type <see cref="IObjectToVisibilityParam"/>. 
    /// The parameter can used as Markup Extension, see <see cref="ObjectToVisibilityParamExtension"/>
    /// </summary>
    public class ObjectToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, string culture)
        {
            if (parameter != null && !(parameter is IObjectToVisibilityParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(ObjectToVisibilityConverter)}: Needed is {nameof(IObjectToVisibilityParam)}");

            var param = (IObjectToVisibilityParam) parameter ?? new ObjectToVisibilityParamExtension().Build();
            
            var isTrueVisibility = !param.Invert ? Visibility.Visible : Visibility.Collapsed;
            var isFalseVisibility = !param.Invert ? Visibility.Collapsed : Visibility.Visible;

            if ((value == null || value == DependencyProperty.UnsetValue) && param.ReferenceValue == null)
                return isTrueVisibility;
            if (value == null)
                return isFalseVisibility;

            return value.Equals(param.ReferenceValue) ? isTrueVisibility : isFalseVisibility;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string culture)
        {
            if (parameter != null && !(parameter is IObjectToVisibilityParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(ObjectToVisibilityConverter)}: Needed is {nameof(IObjectToVisibilityParam)}");

            var param = (IObjectToVisibilityParam)parameter ?? new ObjectToVisibilityParamExtension().Build();

            switch ((Visibility) value)
            {
                case Visibility.Collapsed:
                    return param.Invert ? param.ReferenceValue : null;
                case Visibility.Visible:
                    return param.Invert ? null : param.ReferenceValue;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}