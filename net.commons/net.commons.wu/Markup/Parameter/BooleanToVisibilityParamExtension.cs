using System;
using Windows.UI.Xaml.Markup;
using Net.Commons.Converter;

namespace Net.Commons.Markup.Parameter
{
    /// \ingroup wpf_single_converter_param
    /// \ingroup wpf_markup
    /// <summary>
    /// Markup extension for <see cref="BooleanToVisibilityConverter"/> parameter to use in XAML
    /// </summary>
    [MarkupExtensionReturnType(ReturnType = typeof(IBooleanToVisibilityParam))]
    public class BooleanToVisibilityParamExtension : MarkupExtension, IBooleanToVisibilityParam
    {
        /// <inheritdoc />
        public bool Invert { get; set; } = false;

        protected override object ProvideValue()
        {
            return Build();
        }

        internal IBooleanToVisibilityParam Build()
        {
            return new BooleanToVisibilityParam(Invert);
        }
    }

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Represent an interface for the converter parameter of <see cref="BooleanToVisibilityConverter"/>, see <see cref="BooleanToVisibilityParam"/>
    /// </summary>
    public interface IBooleanToVisibilityParam
    {
        /// <summary>
        /// TRUE to invert the result value, otherwise FALSE (default)
        /// </summary>
        bool Invert { get; set; }
    }

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Represent the converter parameter of <see cref="BooleanToVisibilityConverter"/>
    /// </summary>
    public sealed class BooleanToVisibilityParam : IBooleanToVisibilityParam
    {
        /// <inheritdoc />
        public bool Invert { get; set; }

        public BooleanToVisibilityParam(bool inverse)
        {
            Invert = inverse;
        }

        public override string ToString()
        {
            return $"{nameof(Invert)}: {Invert}";
        }
    }
}
