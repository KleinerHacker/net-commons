using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Net.Commons.Converter;

namespace Net.Commons.Markup.Parameter
{
    /// \ingroup wpf_single_converter_param
    /// \ingroup wpf_markup
    /// <summary>
    /// Markup extension for <see cref="ObjectToVisibilityConverter"/> parameter to use in XAML
    /// </summary>
    [MarkupExtensionReturnType(typeof(IObjectToVisibilityParam))]
    public class ObjectToVisibilityParamExtension : MarkupExtension, IObjectToVisibilityParam
    {
        /// <inheritdoc />
        public object ReferenceValue { get; set; } = null;
        /// <inheritdoc />
        public bool Invert { get; set; } = false;
        /// <inheritdoc />
        public bool ManageLayout { get; set; } = false;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Build();
        }

        internal IObjectToVisibilityParam Build()
        {
            return new ObjectToVisibilityParam(ReferenceValue, Invert, ManageLayout);
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
        /// <summary>
        /// TRUE to manage layout (hidden), otherwise FALSE (collapsed) (default)
        /// </summary>
        bool ManageLayout { get; set; }
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
        /// <inheritdoc />
        public bool ManageLayout { get; set; }

        public ObjectToVisibilityParam()
        {
        }

        public ObjectToVisibilityParam(object referenceValue, bool inverse, bool manageLayout)
        {
            ReferenceValue = referenceValue;
            Invert = inverse;
            ManageLayout = manageLayout;
        }

        public override string ToString()
        {
            return $"{nameof(ReferenceValue)}: {ReferenceValue}, {nameof(Invert)}: {Invert}, {nameof(ManageLayout)}: {ManageLayout}";
        }
    }
}
