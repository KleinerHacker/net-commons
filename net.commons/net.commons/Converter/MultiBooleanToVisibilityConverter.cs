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
    /// Represent a multi value converter to 
    /// </summary>
    public class MultiBooleanToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && !(parameter is IMultiBooleanToVisibilityParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(MultiBooleanToVisibilityConverter)}: Needed is {nameof(IMultiBooleanToVisibilityParam)}");

            var param = (IMultiBooleanToVisibilityParam) parameter ?? new MultiBooleanToVisibilityParamExtension().Build();

            switch (param.Logic)
            {
                case MultiBooleanLogic.All:
                    return HandleLogicAll(values, param.ManageLayout, param.Invert);
                case MultiBooleanLogic.Any:
                    return HandleLogicAny(values, param.ManageLayout, param.Invert);
                default:
                    throw new NotImplementedException();
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{nameof(MultiBooleanToVisibilityConverter)} does not support back converting");
        }

        #region Handlers

        private static object HandleLogicAll(object[] values, bool manageLayout, bool invert)
        {
            var hiddenVisibility = manageLayout ? Visibility.Hidden : Visibility.Collapsed;
            var isTrueVisibility = !invert ? Visibility.Visible : hiddenVisibility;
            var isFalseVisibility = !invert ? hiddenVisibility : Visibility.Visible;

            foreach (var value in values)
            {
                if (value == DependencyProperty.UnsetValue)
                    continue; //Ignore


                if (!(bool) value)
                {
                    return isFalseVisibility;
                }
            }

            return isTrueVisibility;
        }

        private static object HandleLogicAny(object[] values, bool manageLayout, bool invert)
        {
            var hiddenVisibility = manageLayout ? Visibility.Hidden : Visibility.Collapsed;
            var isTrueVisibility = !invert ? Visibility.Visible : hiddenVisibility;
            var isFalseVisibility = !invert ? hiddenVisibility : Visibility.Visible;

            bool result = false;
            foreach (var value in values)
            {
                if (value == DependencyProperty.UnsetValue)
                    continue; //Ignore


                if ((bool) value)
                {
                    result = true;
                    break;
                }
            }

            return result ? isTrueVisibility : isFalseVisibility;
        }

        #endregion
    }
}