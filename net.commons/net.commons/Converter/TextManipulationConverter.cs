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
    /// Represent a value converter to convert a text (string) value to an other text (string) value based on an optional parameter of type <see cref="ITextManipulationParam"/>.<br/>
    /// There are this converter parameters, based on parameter interface above:
    /// <ul>
    ///     <li><see cref="ITextManipulationChangeCaseParam"/>, usable with Markup Extension <see cref="TextManipulationChangeCaseParamExtension"/></li>
    ///     <li><see cref="ITextManipulationReplaceParam"/>, usable with Markup Extension <see cref="TextManipulationReplaceParamExtension"/></li>
    /// </ul>
    /// </summary>
    [ValueConversion(typeof(string), typeof(string), ParameterType = typeof(ITextManipulationParam))]
    public class TextManipulationConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null && !(parameter is ITextManipulationParam))
                throw new ArgumentException($"Wrong parameter type for converter {nameof(TextManipulationConverter)}: Needed is {nameof(ITextManipulationParam)}");

            var param = (ITextManipulationParam) parameter;

            if (value == null)
                return null;
            if (parameter == null)
                return value.ToString();
            
            if (param is ITextManipulationChangeCaseParam)
            {
                var changeCaseParam = (ITextManipulationChangeCaseParam) param;
                switch (changeCaseParam.Type)
                {
                    case ChangeCaseType.Upper:
                        switch (changeCaseParam.Variant)
                        {
                            case ChangeCaseVariant.AllCharacters:
                                return value.ToString().ToUpper(culture);
                            case ChangeCaseVariant.WordsOnly:
                                return value.ToString().ToUpperWords(culture);
                            default:
                                throw new NotImplementedException();
                        }
                    case ChangeCaseType.Lower:
                        switch (changeCaseParam.Variant)
                        {
                            case ChangeCaseVariant.AllCharacters:
                                return value.ToString().ToLower(culture);
                            case ChangeCaseVariant.WordsOnly:
                                return value.ToString().ToLowerWords(culture);
                            default:
                                throw new NotImplementedException();
                        }
                    default:
                        throw new NotImplementedException();
                }
            }
            else if (param is ITextManipulationReplaceParam)
            {
                var replaceParam = (ITextManipulationReplaceParam) param;
                return value.ToString().Replace(replaceParam.SourceString, replaceParam.TargetString, replaceParam.IgnoreCase, replaceParam.Repeat);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException($"{nameof(TextManipulationConverter)} does not support back converting");
        }
    }
}