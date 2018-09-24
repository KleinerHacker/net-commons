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
    /// Markup extension for <see cref="ObjectToBooleanConverter"/> parameter to use in XAML
    /// </summary>
    [MarkupExtensionReturnType(ReturnType = typeof(IObjectToBooleanParam))]
    public class ObjectToBooleanParamExtension : MarkupExtension, IObjectToBooleanParam
    {
        /// <inheritdoc />
        public object ReferenceValue { get; set; } = null;
        /// <inheritdoc />
        public bool Invert { get; set; } = false;

        protected override object ProvideValue()
        {
            return Build();
        }

        internal IObjectToBooleanParam Build()
        {
            return new ObjectToBooleanParam(ReferenceValue, Invert);
        }
    }

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Interface for the converter parameter of <see cref="ObjectToBooleanConverter"/>, see <see cref="ObjectToBooleanParam"/>
    /// </summary>
    public interface IObjectToBooleanParam
    {
        /// <summary>
        /// The reference value to check value with
        /// </summary>
        object ReferenceValue { get; set; }
        /// <summary>
        /// TRUE to invert result, otherwise FALSE (default)
        /// </summary>
        bool Invert { get; set; }
    }

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Converter parameter of <see cref="ObjectToBooleanConverter"/>
    /// </summary>
    public sealed class ObjectToBooleanParam : IObjectToBooleanParam
    {
        /// <inheritdoc />
        public object ReferenceValue { get; set; }
        /// <inheritdoc />
        public bool Invert { get; set; }

        public ObjectToBooleanParam()
        {
        }

        public ObjectToBooleanParam(object referenceValue, bool invert)
        {
            ReferenceValue = referenceValue;
            Invert = invert;
        }

        public override string ToString()
        {
            return $"{nameof(ReferenceValue)}: {ReferenceValue}, {nameof(Invert)}: {Invert}";
        }
    }
}
