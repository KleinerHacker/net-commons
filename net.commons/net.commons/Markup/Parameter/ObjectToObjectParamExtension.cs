using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace net.commons.Markup.Parameter
{
    [MarkupExtensionReturnType(typeof(IObjectToObjectParam))]
    public class ObjectToObjectParamExtension : MarkupExtension, IObjectToObjectParam
    {
        public object ReferenceValue { get; set; } = null;
        public object TrueResultValue { get; set; } = null;
        public object FalseResultValue { get; set; } = null;
        public object NullResultValue { get; set; } = null;
        public bool UseNullResultValue { get; set; } = false;
        public bool Invert { get; set; } = false;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Build();
        }

        internal ObjectToObjectParam Build()
        {
            return new ObjectToObjectParam(ReferenceValue, TrueResultValue, FalseResultValue, NullResultValue, UseNullResultValue, Invert);
        }
    }

    public interface IObjectToObjectParam
    {
        object ReferenceValue { get; set; }
        object TrueResultValue { get; set; }
        object FalseResultValue { get; set; }
        object NullResultValue { get; set; }
        bool UseNullResultValue { get; set; }
        bool Invert { get; set; }
    }

    public sealed class ObjectToObjectParam : IObjectToObjectParam
    {
        public object ReferenceValue { get; set; }
        public object TrueResultValue { get; set; }
        public object FalseResultValue { get; set; }
        public object NullResultValue { get; set; }
        public bool UseNullResultValue { get; set; }
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
