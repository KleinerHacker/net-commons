using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using net.commons.Markup.Parameter;

namespace net.commons.Converter
{
    public class MultiBooleanConverter : IMultiValueConverter
    {
        public object Convert(object[] values, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && !(parameter is IMultiBooleanParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(MultiBooleanConverter)}: Needed is {nameof(IMultiBooleanParam)}");

            var param = (IMultiBooleanParam) parameter ?? new MultiBooleanParamExtension().Build();

            if (param.Logic == MultiBooleanLogic.All)
            {
                foreach (var value in values)
                {
                    if (value == DependencyProperty.UnsetValue)
                        continue; //Ignore


                    if (!(bool) value)
                    {
                        return param.Invert;
                    }
                }

                return !param.Invert;
            }
            else if (param.Logic == MultiBooleanLogic.Any)
            {
                bool result = false;
                foreach (var value in values)
                {
                    if (value == DependencyProperty.UnsetValue)
                        continue; //Ignore


                    if (!(bool)value)
                    {
                        return !param.Invert;
                    }
                }

                return param.Invert;
            } 
            else
                throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, System.Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{nameof(MultiBooleanConverter)} does not support back converting");
        }
    }
}