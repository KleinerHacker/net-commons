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
    /// Markup extension for <see cref="VisibilityInverseConverter"/> parameter to use in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(IVisibilityInverseParam))]
    public class VisibilityInverseParamExtension : MarkupExtension, IVisibilityInverseParam
    {
        /// <inheritdoc />
        public bool ManageLayout { get; set; } = false;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Build();
        }

        internal IVisibilityInverseParam Build()
        {
            return new VisibilityInverseParam(ManageLayout);
        }
    }

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Interface for the converter parameter of <see cref="VisibilityInverseConverter"/>, see <see cref="VisibilityInverseParam"/>
    /// </summary>
    public interface IVisibilityInverseParam
    {
        /// <summary>
        /// TRUE to manage layout (hidden), otherwise FALSE (collapsed) (default)
        /// </summary>
        bool ManageLayout { get; set; }
    }

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Converter parameter of <see cref="VisibilityInverseConverter"/>
    /// </summary>
    public sealed class VisibilityInverseParam : IVisibilityInverseParam
    {
        /// <inheritdoc />
        public bool ManageLayout { get; set; }

        public VisibilityInverseParam()
        {
        }

        public VisibilityInverseParam(bool manageLayout)
        {
            ManageLayout = manageLayout;
        }

        public override string ToString()
        {
            return $"{nameof(ManageLayout)}: {ManageLayout}";
        }
    }
}
