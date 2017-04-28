using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using net.commons.Extension;
using net.commons.Markup;

namespace net.commons.Converter
{
    [ValueConversion(typeof(DateTime), typeof(string), ParameterType = typeof(DateTimeParam))]
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return "";
            }
            if (parameter != null && !(parameter is DateTimeParam))
            {
                throw new ArgumentException("parameter for this converter must be " + nameof(DateTimeParam) + ", set with " + nameof(DateTimeParamExtension));
            }

            var dateTimeParam = parameter == null ? new DateTimeParamExtension().Build() : (DateTimeParam) parameter;

            var dateTime = (DateTime) value;
            var result = "";
            switch (dateTimeParam.DatePresentation)
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
            if (!result.IsEmpty() && dateTimeParam.TimePresentation != TimePresentation.None)
            {
                result += dateTimeParam.Separator;
            }
            switch (dateTimeParam.TimePresentation)
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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}