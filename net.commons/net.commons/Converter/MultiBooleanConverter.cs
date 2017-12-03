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
    /// \ingroup wpf_multi_converter
    /// <summary>
    /// Represent a multi value converter to convert multiple booleans to one boolean based on an optional parameter of type <see cref="IMultiBooleanParam"/>. 
    /// The parameter can used as Markup Extension, see <see cref="MultiBooleanParamExtension"/>
    /// </summary>
    public class MultiBooleanConverter : IMultiValueConverter
    {
        public object Convert(object[] values, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && !(parameter is IMultiBooleanParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(MultiBooleanConverter)}: Needed is {nameof(IMultiBooleanParam)}");

            var param = (IMultiBooleanParam) parameter ?? new MultiBooleanParamExtension().Build();

            switch (param.Logic)
            {
                case MultiBooleanLogic.All:
                    return HandleLogicAll(values, param.Invert);
                case MultiBooleanLogic.Any:
                    return HandleLogicAny(values, param.Invert);
                default:
                    throw new NotImplementedException();
            }
        }

        public object[] ConvertBack(object value, System.Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{nameof(MultiBooleanConverter)} does not support back converting");
        }

        #region Handlers

        private static object HandleLogicAll(object[] values, bool invert)
        {
            foreach (var value in values)
            {
                if (value == DependencyProperty.UnsetValue)
                    continue; //Ignore


                if (!(bool)value)
                {
                    return invert;
                }
            }

            return !invert;
        }

        private static object HandleLogicAny(object[] values, bool invert)
        {
            bool result = false;
            foreach (var value in values)
            {
                if (value == DependencyProperty.UnsetValue)
                    continue; //Ignore


                if ((bool)value)
                {
                    result = true;
                    break;
                }
            }

            return result ? !invert : invert;
        }

        #endregion
    }
}