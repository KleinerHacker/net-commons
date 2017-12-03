using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Net.Commons.Converter;

namespace Net.Commons.Markup.Parameter
{
    /// \ingroup wpf_multi_converter_param
    /// \ingroup wpf_markup
    /// <summary>
    /// Markup extension for <see cref="MultiBooleanToVisibilityConverter"/> parameter to use in XAML
    /// </summary>
    [MarkupExtensionReturnType(typeof(IMultiBooleanToVisibilityParam))]
    public class MultiBooleanToVisibilityParamExtension : MarkupExtension, IMultiBooleanToVisibilityParam
    {
        /// <inheritdoc />
        public MultiBooleanLogic Logic { get; set; } = MultiBooleanLogic.Any;
        /// <inheritdoc />
        public bool Invert { get; set; }
        /// <inheritdoc />
        public bool ManageLayout { get; set; }

        public MultiBooleanToVisibilityParamExtension()
        {
        }

        public MultiBooleanToVisibilityParamExtension(MultiBooleanLogic logic)
        {
            Logic = logic;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Build();
        }

        internal IMultiBooleanToVisibilityParam Build()
        {
            return new MultiBooleanToVisibilityParam(Logic, ManageLayout, Invert);
        }
    }

    /// \ingroup wpf_multi_converter_param
    /// <summary>
    /// Interface for the converter parameter of <see cref="MultiBooleanToVisibilityConverter"/>, see <see cref="MultiBooleanToVisibilityParam"/>
    /// </summary>
    public interface IMultiBooleanToVisibilityParam
    {
        /// <summary>
        /// Used logic to run conversion, default is Any
        /// </summary>
        MultiBooleanLogic Logic { get; set; }
        /// <summary>
        /// TRUE to invert result value, otherwise FALSE (default)
        /// </summary>
        bool Invert { get; set; }
        /// <summary>
        /// TRUE to manage layout (hidden), otherwise FALSE (collapsed) (default)
        /// </summary>
        bool ManageLayout { get; set; }
    }

    /// \ingroup wpf_multi_converter_param
    /// <summary>
    /// Converter parameter of <see cref="MultiBooleanToVisibilityConverter"/>
    /// </summary>
    public sealed class MultiBooleanToVisibilityParam : IMultiBooleanToVisibilityParam
    {
        /// <inheritdoc />
        public MultiBooleanLogic Logic { get; set; }
        /// <inheritdoc />
        public bool ManageLayout { get; set; }
        /// <inheritdoc />
        public bool Invert { get; set; }

        public MultiBooleanToVisibilityParam()
        {
        }

        public MultiBooleanToVisibilityParam(MultiBooleanLogic logic, bool manageLayout, bool invert)
        {
            Logic = logic;
            ManageLayout = manageLayout;
            Invert = invert;
        }

        public override string ToString()
        {
            return $"{nameof(Logic)}: {Logic}, {nameof(ManageLayout)}: {ManageLayout}, {nameof(Invert)}: {Invert}";
        }
    }
}
