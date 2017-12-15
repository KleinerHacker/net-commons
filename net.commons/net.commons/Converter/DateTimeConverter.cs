using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Net.Commons.Extension;
using Net.Commons.Markup;
using Net.Commons.Markup.Parameter;

namespace Net.Commons.Converter
{
    /// \ingroup wpf_single_converter
    /// <summary>
    /// Represent a value converter to convert a DateTime to a string value (first date, second time) based on an optional parameter of type <see cref="IDateTimeParam"/>. 
    /// The parameter can used as Markup Extension, see <see cref="DateTimeParamExtension"/>
    /// </summary>
    [ValueConversion(typeof(DateTime), typeof(string), ParameterType = typeof(IDateTimeParam))]
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && !(parameter is IDateTimeParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(DateTimeConverter)}: Needed is {nameof(IDateTimeParam)}");

            var param = (IDateTimeParam)parameter ?? new DateTimeParamExtension().Build();

            if (value == null)
                return null;

            var dateTime = (DateTime) value;
            var result = "";
            switch (param.DatePresentation)
            {
                case DatePresentation.None:
                    break;
                case DatePresentation.Short:
                    result += dateTime.ToShortDateString();
                    break;
                case DatePresentation.Long:
                    result += dateTime.ToLongDateString();
                    break;
                default:
                    throw new NotImplementedException();
            }
            if (!result.IsEmpty() && param.TimePresentation != TimePresentation.None)
            {
                result += param.Separator;
            }
            switch (param.TimePresentation)
            {
                case TimePresentation.None:
                    break;
                case TimePresentation.Short:
                    result += dateTime.ToShortTimeString();
                    break;
                case TimePresentation.Long:
                    result += dateTime.ToLongTimeString();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{nameof(DateTimeConverter)} does not support back converting");
        }
    }
}