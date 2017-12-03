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
    /// Markup extension for <see cref="MultiBooleanConverter"/> parameter to use in XAML
    /// </summary>
    [MarkupExtensionReturnType(typeof(IMultiBooleanParam))]
    public class MultiBooleanParamExtension : MarkupExtension, IMultiBooleanParam
    {
        /// <inheritdoc />
        public MultiBooleanLogic Logic { get; set; } = MultiBooleanLogic.Any;
        /// <inheritdoc />
        public bool Invert { get; set; } = false;

        public MultiBooleanParamExtension()
        {
        }

        public MultiBooleanParamExtension(MultiBooleanLogic logic)
        {
            Logic = logic;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Build();
        }

        internal IMultiBooleanParam Build()
        {
            return new MultiBooleanParam(Logic, Invert);
        }
    }

    /// \ingroup wpf_multi_converter_param
    /// <summary>
    /// Interface for the converter parameter of <see cref="MultiBooleanConverter"/>, see <see cref="MultiBooleanParam"/>
    /// </summary>
    public interface IMultiBooleanParam
    {
        /// <summary>
        /// Used logic for multi boolean conversion, defualt is Any
        /// </summary>
        MultiBooleanLogic Logic { get; set; }
        /// <summary>
        /// TRUE to invert result, otherwise FALSE (default)
        /// </summary>
        bool Invert { get; set; }
    }

    /// \ingroup wpf_multi_converter_param
    /// <summary>
    /// Cnverter parameter of <see cref="MultiBooleanConverter"/>
    /// </summary>
    public sealed class MultiBooleanParam : IMultiBooleanParam
    {
        /// <inheritdoc />
        public MultiBooleanLogic Logic { get; set; }
        /// <inheritdoc />
        public bool Invert { get; set; }

        public MultiBooleanParam()
        {
        }

        public MultiBooleanParam(MultiBooleanLogic logic, bool invert)
        {
            Logic = logic;
            Invert = invert;
        }

        public override string ToString()
        {
            return $"{nameof(Logic)}: {Logic}, {nameof(Invert)}: {Invert}";
        }
    }

    /// <summary>
    /// Multi Boolean Logic
    /// </summary>
    public enum MultiBooleanLogic
    {
        /// <summary>
        /// Any of the boolean values must be TRUE
        /// </summary>
        Any,
        /// <summary>
        /// All of the boolean values must be TRUE
        /// </summary>
        All
    }
}