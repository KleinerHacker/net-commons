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
    [ValueConversion(typeof(string), typeof(string), ParameterType = typeof(ITextManipulationParam))]
    public class TextManipulationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            if (parameter == null)
            {
                return value.ToString();
            } else if (!(parameter is ITextManipulationParam))
            {
                throw new ArgumentException("parameter for this converter must be " + nameof(ITextManipulationParam) + ", set with " + nameof(TextManipulationParamExtension));
            }

            var manipulation = (ITextManipulationParam) parameter;
            if (manipulation is TextManipulationChangeCaseParam)
            {
                var changeCaseParam = manipulation as TextManipulationChangeCaseParam;
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
            else if (manipulation is TextManipulationReplaceParam)
            {
                var replaceParam = manipulation as TextManipulationReplaceParam;
                return value.ToString().Replace(replaceParam.SourceString, replaceParam.TargetString, replaceParam.IgnoreCase, replaceParam.Repeat);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}