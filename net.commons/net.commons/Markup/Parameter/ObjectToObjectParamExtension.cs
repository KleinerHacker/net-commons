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
    /// Markup extension for <see cref="ObjectToObjectConverter"/> parameter to use in XAML
    /// </summary>
    [MarkupExtensionReturnType(typeof(IObjectToObjectParam))]
    public class ObjectToObjectParamExtension : MarkupExtension, IObjectToObjectParam
    {
        /// <inheritdoc />
        public object ReferenceValue { get; set; } = null;
        /// <inheritdoc />
        public object TrueResultValue { get; set; } = null;
        /// <inheritdoc />
        public object FalseResultValue { get; set; } = null;
        /// <inheritdoc />
        public object NullResultValue { get; set; } = null;
        /// <inheritdoc />
        public bool UseNullResultValue { get; set; } = false;
        /// <inheritdoc />
        public bool Invert { get; set; } = false;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Build();
        }

        internal IObjectToObjectParam Build()
        {
            return new ObjectToObjectParam(ReferenceValue, TrueResultValue, FalseResultValue, NullResultValue, UseNullResultValue, Invert);
        }
    }

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Interface for the converter parameter of <see cref="ObjectToObjectConverter"/>, see <see cref="ObjectToObjectParam"/>
    /// </summary>
    public interface IObjectToObjectParam
    {
        /// <summary>
        /// The reference value to check input value with
        /// </summary>
        object ReferenceValue { get; set; }
        /// <summary>
        /// The TRUE value (if check is successfully) to use as result value
        /// </summary>
        object TrueResultValue { get; set; }
        /// <summary>
        /// The FALSE value (if check has failed) to use as result value 
        /// </summary>
        object FalseResultValue { get; set; }
        /// <summary>
        /// The NULL value (if reference value is NULL and <see cref="UseNullResultValue"/> is set to TRUE) to use as result value
        /// </summary>
        object NullResultValue { get; set; }
        /// <summary>
        /// TRUE to allow check with NULL value if reference value is NULL (default FALSE)
        /// </summary>
        bool UseNullResultValue { get; set; }
        /// <summary>
        /// TRUE to invert result value, otherwise FALSE (default)
        /// </summary>
        bool Invert { get; set; }
    }

    /// \ingroup wpf_single_converter_param
    /// <summary>
    /// Converter parameter of <see cref="ObjectToObjectConverter"/>
    /// </summary>
    public sealed class ObjectToObjectParam : IObjectToObjectParam
    {
        /// <inheritdoc />
        public object ReferenceValue { get; set; }
        /// <inheritdoc />
        public object TrueResultValue { get; set; }
        /// <inheritdoc />
        public object FalseResultValue { get; set; }
        /// <inheritdoc />
        public object NullResultValue { get; set; }
        /// <inheritdoc />
        public bool UseNullResultValue { get; set; }
        /// <inheritdoc />
        public bool Invert { get; set; }

        public ObjectToObjectParam()
        {
        }

        public ObjectToObjectParam(object referenceValue, object trueResultValue, object falseResultValue, object nullResultValue, bool useNullResultValue, bool invert)
        {
            ReferenceValue = referenceValue;
            TrueResultValue = trueResultValue;
            FalseResultValue = falseResultValue;
            NullResultValue = nullResultValue;
            UseNullResultValue = useNullResultValue;
            Invert = invert;
        }

        public override string ToString()
        {
            return $"{nameof(ReferenceValue)}: {ReferenceValue}, {nameof(TrueResultValue)}: {TrueResultValue}, {nameof(FalseResultValue)}: {FalseResultValue}, {nameof(NullResultValue)}: {NullResultValue}, {nameof(UseNullResultValue)}: {UseNullResultValue}, {nameof(Invert)}: {Invert}";
        }
    }
}
