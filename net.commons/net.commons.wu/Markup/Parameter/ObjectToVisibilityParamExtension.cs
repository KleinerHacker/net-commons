using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Markup;
using Net.Commons.Converter;

namespace Net.Commons.Markup.Parameter
{
    /// \ingroup wpf_single_converter_param
    /// \ingroup wpf_markup
    /// <summary>
    /// Markup extension for <see cref="ObjectToVisibilityConverter"/> parameter to use in XAML
    /// </summary>
    [MarkupExtensionReturnType(ReturnType = typeof(IObjectToVisibilityParam))]
    public class ObjectToVisibilityParamExtension : MarkupExtension, IObjectToVisibilityParam
    {
        /// <inheritdoc />
        public object ReferenceValue { get; set; } = null;
        /// <inheritdoc />
        public bool Invert { get; set; } = false;

        protected override object ProvideValue()
        {
            return Build();
        }

        internal IObjectToVisibilityParam Build()
        {
            return new ObjectToVisibilityParam(ReferenceValue, Invert);
        }
    }

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Interface for the converter parameter of <see cref="ObjectToVisibilityConverter"/>, see <see cref="ObjectToVisibilityParam"/>
    /// </summary>
    public interface IObjectToVisibilityParam
    {
        /// <summary>
        /// The reference value to check input value with
        /// </summary>
        object ReferenceValue { get; set; }
        /// <summary>
        /// TRUE to invert result value, otherwise FALSE (default)
        /// </summary>
        bool Invert { get; set; }
    }

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Converter parameter of <see cref="ObjectToVisibilityConverter"/>
    /// </summary>
    public sealed class ObjectToVisibilityParam : IObjectToVisibilityParam
    {
        /// <inheritdoc />
        public object ReferenceValue { get; set; }
        /// <inheritdoc />
        public bool Invert { get; set; }

        public ObjectToVisibilityParam()
        {
        }

        public ObjectToVisibilityParam(object referenceValue, bool inverse)
        {
            ReferenceValue = referenceValue;
            Invert = inverse;
        }

        public override string ToString()
        {
            return $"{nameof(ReferenceValue)}: {ReferenceValue}, {nameof(Invert)}: {Invert}";
        }
    }
}
