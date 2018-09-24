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
    /// Represent a value converter to convert an object value to a boolean value based on an optional parameter of type <see cref="IObjectToBooleanParam"/>. 
    /// The parameter can used as Markup Extension, see <see cref="ObjectToBooleanParamExtension"/>
    /// </summary>
    public class ObjectToBooleanConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, string culture)
        {
            if (parameter != null && !(parameter is IObjectToBooleanParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(ObjectToBooleanConverter)}: Needed is {nameof(IObjectToBooleanParam)}");

            var param = (IObjectToBooleanParam) parameter ?? new ObjectToBooleanParamExtension().Build();

            var isTrue = !param.Invert;
            var isFalse = param.Invert;

            if ((value == null || value == DependencyProperty.UnsetValue) && param.ReferenceValue == null)
                return isTrue;
            if (value == null)
                return isFalse;

            return value.Equals(param.ReferenceValue) ? isTrue : isFalse;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string culture)
        {
            if (parameter != null && !(parameter is IObjectToBooleanParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(ObjectToBooleanConverter)}: Needed is {nameof(IObjectToBooleanParam)}");

            var param = (IObjectToBooleanParam)parameter ?? new ObjectToBooleanParamExtension().Build();

            var isTrue = !param.Invert ? param.ReferenceValue : false;
            var isFalse = !param.Invert ? false : param.ReferenceValue;

            return (bool) value ? isTrue : isFalse;
        }
    }
}