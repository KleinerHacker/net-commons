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
    /// \ingroup wpf_single_converter
    /// <summary>
    /// Represent a value converter to convert an object value to an other object value based on an optional parameter of type <see cref="IObjectToObjectParam"/>. 
    /// The parameter can used as Markup Extension, see <see cref="ObjectToObjectParamExtension"/>
    /// </summary>
    [ValueConversion(typeof(object), typeof(object), ParameterType = typeof(IObjectToObjectParam))]
    public class ObjectToObjectConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && !(parameter is IObjectToObjectParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(ObjectToObjectConverter)}: Needed is {nameof(IObjectToObjectParam)}");

            var param = (IObjectToObjectParam) parameter ?? new ObjectToObjectParamExtension().Build();

            var isTrue = !param.Invert ? param.TrueResultValue : param.FalseResultValue;
            var isFalse = !param.Invert ? param.FalseResultValue : param.TrueResultValue;

            if ((value == null || value == DependencyProperty.UnsetValue) && param.ReferenceValue == null)
                return param.UseNullResultValue ? param.NullResultValue : isTrue;
            if (value == null)
                return param.UseNullResultValue ? param.NullResultValue : isFalse;

            return value.Equals(param.ReferenceValue) ? isTrue : isFalse;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && !(parameter is IObjectToObjectParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(ObjectToObjectConverter)}: Needed is {nameof(IObjectToObjectParam)}");

            var param = (IObjectToObjectParam)parameter ?? new ObjectToObjectParamExtension().Build();

            var isTrue = !param.Invert ? param.ReferenceValue : Binding.DoNothing;
            var isFalse = !param.Invert ? Binding.DoNothing : param.ReferenceValue;

            if (value == null && param.TrueResultValue == null)
                return isTrue;
            if (value == null)
                return isFalse;

            return value.Equals(param.TrueResultValue) ? isTrue : isFalse;
        }
    }
}